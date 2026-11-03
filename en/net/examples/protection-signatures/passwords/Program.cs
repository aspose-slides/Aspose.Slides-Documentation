using System.Threading.Tasks;
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);
    private static bool IsPasswordRejected(string path, string? password)
    {
        try
        {
            using var unexpected = new Presentation(path, new LoadOptions { Password = password });
            return false;
        }
        catch (InvalidPasswordException)
        {
            return true;
        }
    }

    private static void ProtectPresentation()
    {
        const string password = "reader-demo";
        using (var original = new Presentation())
        {
            Label(original.Slides[0], "Private example").Name = "sample";
            original.Save("original.pptx", SaveFormat.Pptx);
        }

        string originalHash = Hash("original.pptx");
        using (var encrypt = new Presentation("original.pptx"))
        {
            encrypt.ProtectionManager.Encrypt(password);
            encrypt.Save("encrypted.pptx", SaveFormat.Pptx);
        }

        Require(PresentationFactory.Instance.GetPresentationInfo("encrypted.pptx").IsEncrypted, "Output is not encrypted.");
        bool missingRejected = IsPasswordRejected("encrypted.pptx", null);
        bool wrongRejected = IsPasswordRejected("encrypted.pptx", "incorrect-demo-password");
        Require(missingRejected && wrongRejected, "Incorrect credentials were accepted.");
        using (var authorized = new Presentation("encrypted.pptx", new LoadOptions { Password = password }))
        {
            Require(authorized.Slides[0].Shapes.OfType<IAutoShape>().Single(shape => shape.Name == "sample").TextFrame.Text == Context.ExpectedText("Private example"), "Content changed.");
            authorized.ProtectionManager.RemoveEncryption();
            authorized.Save("decrypted.pptx", SaveFormat.Pptx);
        }

        Require(!PresentationFactory.Instance.GetPresentationInfo("decrypted.pptx").IsEncrypted, "Encryption remains.");
        using (var plain = new Presentation("decrypted.pptx"))
            Require(plain.Slides.Count == 1, "Decrypted copy is unreadable.");
        Require(SavedText("decrypted.pptx").Contains("Private example"), "Decrypted persisted content differs.");
        Require(Hash("original.pptx") == originalHash, "Original was changed.");
        Report(new { encrypted = true, correct_password = true, wrong_rejected = wrongRejected, missing_rejected = missingRejected, encryption_removed = true, original_unchanged = true });
    }
}
