using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

internal static partial class Program
{
    private static void RemoveKnownUnreferencedImage(string package, string part)
    {
        if (!part.StartsWith("ppt/media/", StringComparison.Ordinal) || !part.EndsWith(".png", StringComparison.Ordinal))
            throw new InvalidDataException("Only a nominated PNG media part is supported.");
        using var zip = ZipFile.Open(package, ZipArchiveMode.Update);
        foreach (var relationPart in zip.Entries.Where(e => e.FullName.EndsWith(".rels", StringComparison.Ordinal)).ToArray())
        {
            string name = relationPart.FullName;
            int split = name.LastIndexOf("/_rels/", StringComparison.Ordinal);
            string owner = name == "_rels/.rels" ? "" : name[..split] + "/" + name[(split + 7)..^5];
            using var stream = relationPart.Open();
            var xml = System.Xml.Linq.XDocument.Load(stream);
            foreach (var relationship in xml.Root!.Elements())
            {
                if ((string?)relationship.Attribute("TargetMode") == "External")
                    continue;
                string? target = (string?)relationship.Attribute("Target");
                if (target == null)
                    continue;
                var absolute = new Uri(new Uri("https://package.invalid/" + owner), target);
                if (absolute.Host == "package.invalid" && Uri.UnescapeDataString(absolute.AbsolutePath.TrimStart('/')) == part)
                    throw new InvalidDataException("Refusing to remove referenced image part.");
            }
        }

        var entry = zip.GetEntry(part);
        if (entry == null)
            throw new InvalidDataException("Nominated image part is absent.");
        entry.Delete();
    }
}
