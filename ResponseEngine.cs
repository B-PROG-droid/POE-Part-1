using System;
using System.Collections.Generic;
using System.Linq;

// ✔ Fixed: removed namespace — all other classes have no namespace, 
//          keeping this in Part_1_POE namespace would cause a 
//          'type not found' error when Chatbot calls ResponseEngine.GetResponse()
public class ResponseEngine
{
    // ✔ Fixed: changed from internal to public so Chatbot can access it
    private static readonly List<(string[] Keywords, string Response)> _responses =
        new List<(string[], string)>
    {
        (
            new[] { "password", "passwords", "passphrase" },
            "🔑  Password Tips:\n" +
            "   • Use at least 12 characters mixing UPPER, lower, numbers & symbols.\n" +
            "   • Never reuse the same password across sites.\n" +
            "   • Consider a trusted password manager (e.g. Bitwarden, 1Password).\n" +
            "   • Use a passphrase like 'Coffee!Runs@Midnight7' — easy to remember, hard to crack."
        ),
        (
            new[] { "phishing", "scam", "fake email", "spoofing" },
            "🎣  Phishing Awareness:\n" +
            "   • Always verify the sender's email address — look for subtle misspellings.\n" +
            "   • Legitimate organisations never ask for passwords via email.\n" +
            "   • Hover over links before clicking to preview the real URL.\n" +
            "   • When in doubt, contact the company directly using their official website."
        ),
        (
            new[] { "link", "url", "website", "click" },
            "🔗  Safe Browsing:\n" +
            "   • Look for 'https://' and the padlock icon before entering any data.\n" +
            "   • Avoid shortened URLs from untrusted sources — use a URL expander first.\n" +
            "   • Bookmark sites you use often instead of Googling them every time.\n" +
            "   • Use a browser extension like uBlock Origin to block malicious ads."
        ),
        (
            new[] { "safe", "safety", "protect", "secure", "security" },
            "🛡️  General Security:\n" +
            "   • Keep your OS, apps and antivirus up to date.\n" +
            "   • Use a reputable antivirus / endpoint-protection tool.\n" +
            "   • Lock your screen whenever you step away from your device.\n" +
            "   • Back up important data using the 3-2-1 rule: 3 copies, 2 media types, 1 offsite."
        ),
        (
            new[] { "2fa", "mfa", "two factor", "multi factor", "authenticator" },
            "📱  Two-Factor Authentication (2FA):\n" +
            "   • Always enable 2FA/MFA on email, banking and social accounts.\n" +
            "   • Prefer authenticator apps (Google Authenticator, Authy) over SMS codes.\n" +
            "   • Never share a one-time code with anyone — support staff won't ask for it.\n" +
            "   • Hardware keys (YubiKey) offer the strongest 2FA protection."
        ),
        (
            new[] { "wifi", "wi-fi", "network", "public wifi", "vpn" },
            "📶  Network & Wi-Fi Safety:\n" +
            "   • Avoid accessing sensitive accounts on public Wi-Fi without a VPN.\n" +
            "   • Use WPA3 encryption on your home router; change the default credentials.\n" +
            "   • A VPN encrypts your traffic — choose one that doesn't log your activity.\n" +
            "   • Disable Wi-Fi & Bluetooth when not in use to avoid passive scanning."
        ),
        (
            new[] { "malware", "virus", "ransomware", "spyware", "trojan" },
            "🦠  Malware Protection:\n" +
            "   • Never open email attachments from unknown senders.\n" +
            "   • Download software only from official sources or verified app stores.\n" +
            "   • Ransomware spreads fast — offline backups are your best recovery option.\n" +
            "   • Run regular full-system scans with an updated antivirus tool."
        ),
        (
            new[] { "social media", "facebook", "instagram", "twitter", "privacy settings" },
            "📢  Social Media Safety:\n" +
            "   • Review and tighten your privacy settings — limit who sees your posts.\n" +
            "   • Avoid sharing your location, travel plans or daily routine publicly.\n" +
            "   • Be sceptical of friend/follow requests from people you don't know.\n" +
            "   • Oversharing personal details can be used for social engineering attacks."
        ),
        (
            new[] { "update", "patch", "software update", "firmware" },
            "🔄  Updates & Patching:\n" +
            "   • Enable automatic updates — most attacks exploit known, patched vulnerabilities.\n" +
            "   • Update routers, smart-home devices and IoT gadgets — they're often forgotten.\n" +
            "   • Uninstall software you no longer use; old apps can be hidden entry points.\n" +
            "   • Check for firmware updates on your router every few months."
        ),
        (
            new[] { "backup", "data loss", "recovery", "cloud" },
            "💾  Data Backup:\n" +
            "   • Follow the 3-2-1 rule: 3 copies, 2 different media, 1 stored offsite.\n" +
            "   • Test your backups regularly — a backup you haven't tested may not restore.\n" +
            "   • Encrypt sensitive backups before uploading them to the cloud.\n" +
            "   • Cloud services (Google Drive, OneDrive) are NOT a substitute for full backups."
        ),
        (
            new[] { "help", "topics", "what can you do", "commands" },
            "💡  Topics I can help with:\n" +
            "   password · phishing · links · safe browsing · 2fa · wifi · vpn\n" +
            "   malware · social media · updates · backup · privacy\n\n" +
            "   Just type any of those words and I'll share tips!"
        )
    };

    public static string GetResponse(string userInput)
    {
        string input = userInput.ToLower();

        foreach (var (keywords, response) in _responses)
        {
            if (keywords.Any(k => input.Contains(k)))
                return response;
        }

        return "❓ I didn't quite understand that. Type 'help' to see what topics I can assist with.";
    }
}