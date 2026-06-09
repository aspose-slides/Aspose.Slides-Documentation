---
title: Εξαγωγή εικόνων από σχήματα παρουσίασης σε .NET
linktitle: Εικόνα από σχήμα
type: docs
weight: 90
url: /el/net/extracting-images-from-presentation-shapes/
keywords:
- εξαγωγή εικόνας
- ανάκτηση εικόνας
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Εξαγωγή εικόνων από σχήματα σε παρουσιάσεις PowerPoint και OpenDocument με Aspose.Slides για .NET - γρήγορη, φιλική προς τον κώδικα λύση."
---
## **Επισκόπηση**

Οι εικόνες σε μια παρουσίαση μπορούν να εμφανιστούν σε διάφορους τύπους σχήματος: ως συνηθισμένα πλαίσια εικόνων, ως γεμίσματα εικόνας που εφαρμόζονται σε σχήματα, ως εικόνες προεπισκόπησης αντικειμένου OLE, ως μικρογραφίες πλαισίων βίντεο ή ήχου, ως εικόνες ζουμ ή ως εικόνες ενσωματωμένες μέσα σε σχήματα πίνακα, διαγράμματος και SmartArt. Το Aspose.Slides αποθηκεύει αυτές τις εικόνες στη συλλογή εικόνων της παρουσίασης, η οποία εκτίθεται μέσω των αντικειμένων [ImageCollection](https://reference.aspose.com/slides/el/net/aspose.slides/imagecollection/) και [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/).

Αν χρειάζεστε μόνο να εξαγάγετε κάθε ενσωματωμένο πόρο εικόνας σε μια παρουσίαση, επαναλάβετε το `presentation.Images`. Αυτό το άρθρο επικεντρώνεται σε διαφορετικό έργο: τη διαπέραση των σχημάτων για να βρεθεί πού χρησιμοποιούνται οι εικόνες στις διαφάνειες, ώστε τα αποθηκευμένα αρχεία να διατηρούν χρήσιμα συμφραζόμενα όπως ο αριθμός της διαφάνειας, η θέση του σχήματος και ο τύπος πηγής (πλαίσιο εικόνας, γεμιστική εικόνα, προεπισκόπηση πολυμέσων, προεπισκόπηση OLE ή εικόνα ζουμ).

{{% alert title="Συμβουλή" color="primary" %}}
Χρησιμοποιήστε το [IPPImage.BinaryData](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/) για να διατηρήσετε τα αρχικά κωδικοποιημένα δεδομένα της εικόνας και τον τύπο αρχείου. Χρησιμοποιήστε το [IPPImage.Image](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/) μαζί με το [IImage.Save](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/) όταν θέλετε να κανονικοποιήσετε την έξοδο σε συγκεκριμένη μορφή όπως PNG.
{{% /alert %}}

## **Κοινές Βοηθητικές Μεθόδους**

Οι παρακάτω βοηθητικές μέθοδοι διατηρούν τα παραδείγματα σύντομα. Το `SaveOriginalImage` γράφει τα αρχικά ενσωματωμένα bytes, επιλέγει ασφαλή επέκταση από τον τύπο MIME και παραλείπει διπλότυπα δυαδικά δεδομένα εικόνας με βάση το hash SHA-256.

```c#
using Aspose.Slides;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

private static bool SaveOriginalImage(
    IPPImage image,
    string outputDirectory,
    string fileNameBase,
    ISet<string> savedImageHashes)
{
    byte[] imageData = image.BinaryData;
    string imageHash = GetSha256Hash(imageData);
    if (!savedImageHashes.Add(imageHash))
    {
        return false;
    }

    string extension = GetExtensionFromContentType(image.ContentType);
    string fileName = $"{fileNameBase}.{extension}";
    string outputPath = Path.Combine(outputDirectory, fileName);
    File.WriteAllBytes(outputPath, imageData);
    return true;
}

private static void SaveImageAsPng(IPPImage image, string outputDirectory, string fileNameBase)
{
    string fileName = $"{fileNameBase}.png";
    string outputPath = Path.Combine(outputDirectory, fileName);

    using (IImage outputImage = image.Image)
    {
        outputImage.Save(outputPath, ImageFormat.Png);
    }
}

private static IPPImage GetPictureFillImage(IFillFormat fillFormat)
{
    if (fillFormat == null || fillFormat.FillType != FillType.Picture)
    {
        return null;
    }

    return fillFormat.PictureFillFormat.Picture.Image;
}

private static IEnumerable<(IShape Shape, string NamePart)> EnumerateShapes(
    IShapeCollection shapes,
    string prefix,
    bool includeGroupedShapes)
{
    int shapeCount = shapes.Count;
    for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        IShape shape = shapes[shapeIndex];
        int displayIndex = shapeIndex + 1;
        string shapeNamePart = $"{prefix}_shape_{displayIndex}";
        yield return (shape, shapeNamePart);

        if (includeGroupedShapes && shape is IGroupShape groupShape)
        {
            foreach ((IShape Shape, string NamePart) childShape in EnumerateShapes(
                groupShape.Shapes,
                shapeNamePart,
                includeGroupedShapes))
            {
                yield return childShape;
            }
        }
    }
}

private static string GetSha256Hash(byte[] data)
{
    using (SHA256 sha256 = SHA256.Create())
    {
        byte[] hash = sha256.ComputeHash(data);
        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
    }
}

private static string GetExtensionFromContentType(string contentType)
{
    if (string.IsNullOrWhiteSpace(contentType))
    {
        return "bin";
    }

    string mediaType = contentType.Split(';')[0].Trim().ToLowerInvariant();
    switch (mediaType)
    {
        case "image/jpeg":
            return "jpg";
        case "image/png":
            return "png";
        case "image/gif":
            return "gif";
        case "image/bmp":
            return "bmp";
        case "image/tiff":
            return "tiff";
        case "image/x-emf":
        case "image/emf":
            return "emf";
        case "image/x-wmf":
        case "image/wmf":
            return "wmf";
        case "image/svg+xml":
            return "svg";
        default:
            if (mediaType.StartsWith("image/"))
            {
                string extension = mediaType.Substring("image/".Length);
                return MakeSafeFileNamePart(extension);
            }

            return "bin";
    }
}

private static string MakeSafeFileNamePart(string value)
{
    foreach (char invalidCharacter in Path.GetInvalidFileNameChars())
    {
        value = value.Replace(invalidCharacter, '_');
    }

    return value;
}
```

## **Εξαγωγή Εικόνων από Πλαίσια Εικόνας**

Χρησιμοποιήστε αυτήν την προσέγγιση για εικόνες που έχουν εισαχθεί ως αυτόνομα αντικείμενα. Ένα [IPictureFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ipictureframe/) αποθηκεύει την εικόνα του στο `PictureFormat.Picture.Image`, το οποίο επιστρέφει ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/).

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "extracted-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IPictureFrame pictureFrame)
            {
                IPPImage image = pictureFrame.PictureFormat.Picture.Image;
                SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
            }
        }
    }
}
```

## **Εξαγωγή Εικόνων από Σχήματα με Γέμισμα Εικόνας**

Τα σχήματα μπορούν να χρησιμοποιούν μια εικόνα ως γέμισμα. Ελέγξτε πρώτα τον τύπο γεμίσματος του σχήματος: αν δεν είναι [FillType.Picture](https://reference.aspose.com/slides/el/net/aspose.slides/filltype/), δεν υπάρχει εικόνα προς εξαγωγή από αυτό το γέμισμα. Το παρακάτω παράδειγμα χειρίζεται αντικείμενα [IAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/iautoshape/) και αποθηκεύει κάθε εικόνα ως PNG μέσω του [IPPImage.Image](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/).

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "shape-fill-images");
Directory.CreateDirectory(outputDirectory);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IAutoShape autoShape)
            {
                IPPImage image = GetPictureFillImage(autoShape.FillFormat);
                if (image != null)
                {
                    SaveImageAsPng(image, outputDirectory, item.NamePart);
                }
            }
        }
    }
}
```

## **Εξαγωγή Ε εικόνων Προεπισκόπησης από Πλαίσια Αντικειμένου OLE**

Ένα [IOleObjectFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ioleobjectframe/) μπορεί να διαθέτει μια εναλλακτική εικόνα που το PowerPoint χρησιμοποιεί ως προεπισκόπηση του αντικειμένου σε μια διαφάνεια. Αυτή η εικόνα είναι διαθέσιμη μέσω του `SubstitutePictureFormat.Picture.Image`. Η εξαγωγή αυτής της εικόνας σας δίνει την εικόνα προεπισκόπησης, όχι τα ενσωματωμένα περιεχόμενα του πακέτου OLE.

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "ole-preview-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IOleObjectFrame oleObjectFrame)
            {
                IPPImage image = oleObjectFrame.SubstitutePictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_ole_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **Εξαγωγή Εικόνων Προεπισκόπησης από Πλαίσια Βίντεο**

Ένα [IVideoFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ivideoframe/) μπορεί επίσης να αποθηκεύει μια εικόνα προεπισκόπησης στο `PictureFormat.Picture.Image`. Αυτή είναι η αφίσα ή μικρογραφία που εμφανίζεται στη διαφάνεια, όχι ένα καρέ που προέρχεται από τη ροή του βίντεο.

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "video-preview-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IVideoFrame videoFrame)
            {
                IPPImage image = videoFrame.PictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_video_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **Εξαγωγή Ε εικόνων Προεπισκόπησης από Πλαίσια Ήχου**

Ένα [IAudioFrame](https://reference.aspose.com/slides/el/net/aspose.slides/iaudioframe/) μπορεί να αποθηκεύει μια μικρογραφία στο `PictureFormat.Picture.Image`. Αυτή είναι η εικόνα που εμφανίζεται για το αντικείμενο ήχου στη διαφάνεια.

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "audio-preview-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IAudioFrame audioFrame)
            {
                IPPImage image = audioFrame.PictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_audio_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **Εξαγωγή Ε εικόνων από Αντικείμενα Ζουμ**

Τα σχήματα [IZoomFrame](https://reference.aspose.com/slides/el/net/aspose.slides/izoomframe/) και [ISectionZoomFrame](https://reference.aspose.com/slides/el/net/aspose.slides/isectionzoomframe/) μπορούν να χρησιμοποιούν προσαρμοσμένες εικόνες. Διαβάστε το `ZoomImage` από το πλαίσιο ζουμ.

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "zoom-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IZoomFrame zoomFrame && zoomFrame.ZoomImage != null)
            {
                string fileNameBase = $"{item.NamePart}_zoom";
                SaveOriginalImage(zoomFrame.ZoomImage, outputDirectory, fileNameBase, savedImageHashes);
                continue;
            }

            if (item.Shape is ISectionZoomFrame sectionZoomFrame && sectionZoomFrame.ZoomImage != null)
            {
                string fileNameBase = $"{item.NamePart}_section_zoom";
                SaveOriginalImage(sectionZoomFrame.ZoomImage, outputDirectory, fileNameBase, savedImageHashes);
                continue;
            }

        }
    }
}
```

## **Εξαγωγή Ε εικόνων από Πλαίσια Σύνοψης Ζουμ**

Ένα [ISummaryZoomFrame](https://reference.aspose.com/slides/el/net/aspose.slides/isummaryzoomframe/) είναι επίσης σχήμα. Τα στοιχεία της ενότητας του μπορούν να χρησιμοποιούν προσαρμοσμένες εικόνες, οι οποίες εκτίθενται μέσω της ιδιότητας `ZoomImage` κάθε ενότητας σύνοψης ζουμ.

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "summary-zoom-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is ISummaryZoomFrame summaryZoomFrame)
            {
                int sectionCount = summaryZoomFrame.SummaryZoomCollection.Count;
                for (int sectionIndex = 0; sectionIndex < sectionCount; sectionIndex++)
                {
                    ISummaryZoomSection section = summaryZoomFrame.SummaryZoomCollection[sectionIndex];
                    if (section.ZoomImage != null)
                    {
                        int displayIndex = sectionIndex + 1;
                        string fileNameBase = $"{item.NamePart}_summary_zoom_{displayIndex}";
                        SaveOriginalImage(section.ZoomImage, outputDirectory, fileNameBase, savedImageHashes);
                    }
                }
            }
        }
    }
}
```

## **Εξαγωγή Ε εικόνων από Σχήματα Πίνακα**

Ένα [ITable](https://reference.aspose.com/slides/el/net/aspose.slides/itable/) είναι σχήμα. Οι εικόνες σε έναν πίνακα συνήθως αποθηκεύονται ως γεμίσματα εικόνας στα κελιά του πίνακα.

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "table-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: true))
        {
            if (item.Shape is ITable table)
            {
                int rowCount = table.Rows.Count;
                int columnCount = table.Columns.Count;
                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                    {
                        ICell cell = table[columnIndex, rowIndex];
                        IPPImage image = GetPictureFillImage(cell.CellFormat.FillFormat);
                        if (image != null)
                        {
                            string fileNameBase = $"{item.NamePart}_cell_{rowIndex + 1}_{columnIndex + 1}";
                            SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }
}
```

## **Εξαγωγή Ε εικόνων από Σχήματα Διαγράμματος**

Ένα [IChart](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichart/) είναι σχήμα. Το παρακάτω παράδειγμα εξάγει μια εικόνα από το γέμισμα εικόνας της περιοχής του διαγράμματος.

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "chart-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: true))
        {
            if (item.Shape is Aspose.Slides.Charts.IChart chart)
            {
                IFillFormat fillFormat = chart.FillFormat;
                IPPImage image = GetPictureFillImage(fillFormat);
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_chart_area";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **Εξαγωγή Ε εικόνων από Σχήματα SmartArt**

Ένα αντικείμενο [ISmartArt](https://reference.aspose.com/slides/el/net/aspose.slides.smartart/ismartart/) είναι σχήμα. Ανάλογα με τη διάταξη του SmartArt, οι εικόνες μπορεί να αποθηκεύονται σε γεμίσματα κουκίδων κόμβου ή στα φορμάτ γεμίσματος των σχημάτων κόμβου.

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "smartart-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: true))
        {
            if (item.Shape is Aspose.Slides.SmartArt.ISmartArt smartArt)
            {
                int nodeCount = smartArt.AllNodes.Count;
                for (int nodeIndex = 0; nodeIndex < nodeCount; nodeIndex++)
                {
                    Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes[nodeIndex];
                    IPPImage bulletImage = GetPictureFillImage(node.BulletFillFormat);
                    if (bulletImage != null)
                    {
                        string fileNameBase = $"{item.NamePart}_smartart_node_{nodeIndex + 1}_bullet";
                        SaveOriginalImage(bulletImage, outputDirectory, fileNameBase, savedImageHashes);
                    }

                    int nodeShapeCount = node.Shapes.Count;
                    for (int nodeShapeIndex = 0; nodeShapeIndex < nodeShapeCount; nodeShapeIndex++)
                    {
                        var nodeShape = node.Shapes[nodeShapeIndex];
                        IPPImage image = GetPictureFillImage(nodeShape.FillFormat);
                        if (image != null)
                        {
                            string fileNameBase = $"{item.NamePart}_smartart_node_{nodeIndex + 1}_shape_{nodeShapeIndex + 1}";
                            SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }
}
```

## **Συμπερίληψη Ε εικόνων μέσα σε Ομαδοποιημένα Σχήματα**

Τα ομαδοποιημένα σχήματα περιέχουν τις δικές τους συλλογές σχημάτων. Η κοινή βοηθητική μέθοδος `EnumerateShapes` διαθέτει την επιλογή `includeGroupedShapes`. Ορίστε την σε `true` όταν θέλετε να εξετάσετε τα σχήματα μέσα σε αντικείμενα [IGroupShape](https://reference.aspose.com/slides/el/net/aspose.slides/igroupshape/). Το παρακάτω παράδειγμα εξάγει εικόνες από πλαίσια εικόνας, σχήματα με γέμισμα εικόνας, προεπισκοπήσεις αντικειμένου OLE, μικρογραφίες πλαισίων βίντεο και μικρογραφίες πλαισίων ήχου. Για να συμπεριλάβετε επίσης εικόνες από πίνακες, διαγράμματα, SmartArt και σύνοψη ζουμ, επαναχρησιμοποιήστε τη εξειδικευμένη λογική εξαγωγής από τις προηγούμενες ενότητες διατηρώντας την ίδια αναδρομική διαπέραση των σχημάτων.

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "all-shape-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: true))
        {
            if (item.Shape is IPictureFrame pictureFrame)
            {
                IPPImage image = pictureFrame.PictureFormat.Picture.Image;
                SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
                continue;
            }

            if (item.Shape is IAutoShape autoShape)
            {
                IPPImage image = GetPictureFillImage(autoShape.FillFormat);
                if (image != null)
                {
                    SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
                }

                continue;
            }

            if (item.Shape is IOleObjectFrame oleObjectFrame)
            {
                IPPImage image = oleObjectFrame.SubstitutePictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_ole_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (item.Shape is IVideoFrame videoFrame)
            {
                IPPImage image = videoFrame.PictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_video_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (item.Shape is IAudioFrame audioFrame)
            {
                IPPImage image = audioFrame.PictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_audio_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **Περιπτώσεις Άκρων και Πρακτικές Σημειώσεις**

- **Διπλότυπες εικόνες:** Πολλά σχήματα μπορεί να αναφέρουν την ίδια εικόνα ή διαφορετικές εικόνες με ταυτοσυμβατικά bytes. Δημιουργήστε hash του [IPPImage.BinaryData](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/) πριν από τη γραφή των αρχείων αν θέλετε ένα αρχείο εξόδου ανά μοναδική εικόνα.
- **Αρχικά δεδομένα vs. μετατρεπόμενη έξοδος:** Η αποθήκευση του [IPPImage.BinaryData](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/) διατηρεί τα ενσωματωμένα δεδομένα JPEG, PNG, GIF, SVG, EMF ή WMF. Η αποθήκευση του [IPPImage.Image](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/) μέσω του [IImage.Save](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/) είναι χρήσιμη όταν θέλετε μια συνεπή μορφή εξόδου.
- **Μη υποστηριζόμενοι τύποι γεμίσματος:** Σχήματα με συμπαγές, διαβάθμιση, μοτίβο ή χωρίς γέμισμα δεν περιέχουν γέμισμα εικόνας. Ελέγξτε το [FillType](https://reference.aspose.com/slides/el/net/aspose.slides/filltype/) πριν διαβάσετε το `PictureFillFormat`.
- **Ομαδοποιημένα σχήματα:** Η συλλογή σχημάτων της διαφάνειας στο ανώτερο επίπεδο δεν «ισοπεδώνει» τις ομάδες. Εξετάστε αναδρομικά τα [IGroupShape.Shapes](https://reference.aspose.com/slides/el/net/aspose.slides/igroupshape/) όταν το ομαδοποιημένο περιεχόμενο έχει σημασία.
- **Προεπισκοπήσεις αντικειμένου OLE:** Ένα [IOleObjectFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ioleobjectframe/) μπορεί να εκθέσει μια εικόνα προεπισκόπησης μέσω του `SubstitutePictureFormat`, αλλά αυτή η εικόνα είναι μόνο η προεπισκόπηση της διαφάνειας. Δεν είναι το ενσωματωμένο αρχείο μέσα στο αντικείμενο OLE.
- **Μικρογραφίες πλαισίων βίντεο:** Ένα [IVideoFrame](https://reference.aspose.com/slides/el/net/aspose.slides/ivideoframe/) μπορεί να εκθέσει μια εικόνα προεπισκόπησης μέσω του `PictureFormat`, αλλά αυτή η εικόνα είναι μόνο η αφίσα που εμφανίζεται στη διαφάνεια. Δεν εξάγεται από τη ροή βίντεο.
- **Μικρογραφίες πλαισίων ήχου:** Ένα [IAudioFrame](https://reference.aspose.com/slides/el/net/aspose.slides/iaudioframe/) μπορεί να εκθέσει ένα εικονίδιο ή μικρογραφία μέσω του `PictureFormat`; δεν είναι τα ενσωματωμένα δεδομένα ήχου.
- **Εικόνες ζουμ:** Τα σχήματα ζουμ διαφάνειας, ενότητας και σύνοψης μπορεί να χρησιμοποιούν προσαρμοσμένα [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/) μέσω του `ZoomImage`.
- **Διασυνδεδεμένα μοντέλα σχημάτων:** Τα αντικείμενα πίνακα, διαγράμματος και SmartArt υλοποιούν το [IShape](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/), αλλά οι εικόνες τους συχνά αποθηκεύονται σε εσωτερικά αντικείμενα μορφοποίησης κυψελών πίνακα, στοιχείων διαγράμματος ή κόμβων SmartArt.
- **Περικομμένες ή μετασχηματισμένες εικόνες:** Η πρόσβαση στο [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/) σας παρέχει τον αποθηκευμένο πόρο εικόνας. Δεν αποδίδει περικοπές, διαφάνεια, αλλαγή χρώματος, περιστροφή ή άλλα οπτικά εφέ που εφαρμόζει το σχήμα.

## **Συχνές Ερωτήσεις**

**Μπορώ να εξάγω την αρχική εικόνα χωρίς περικοπές, εφέ ή μετασχηματισμούς σχήματος;**

Ναι. Πρόσβαση στο αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/) και εγγραφή του [IPPImage.BinaryData](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/) στον δίσκο. Αυτό διατηρεί την αρχική κωδικοποιημένη εικόνα που είναι αποθηκευμένη στην παρουσίαση, όχι τον τρόπο που η εικόνα αποδίδεται στη διαφάνεια.

**Μπορώ να εξάγω κάθε εξαγόμενη εικόνα ως PNG;**

Ναι. Χρησιμοποιήστε το [IPPImage.Image](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/) για να λάβετε ένα αντικείμενο [IImage](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/) και, στη συνέχεια, καλέστε το [IImage.Save](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/) με το [ImageFormat.Png](https://reference.aspose.com/slides/el/net/aspose.slides/imageformat/). Αυτό μετατρέπει την έξοδο και μπορεί να μην διατηρήσει τον αρχικό τύπο αρχείου ή τα διανυσματικά δεδομένα.

**Πώς μπορώ να αποφεύγω την αποθήκευση της ίδιας εικόνας περισσότερες από μία φορές;**

Χρησιμοποιήστε ένα hash του [IPPImage.BinaryData](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/) και διατηρήστε τα hash σε ένα σύνολο. Αν μια νέα εικόνα έχει hash που υπάρχει ήδη, παραλείψτε την ή καταγράψτε μια άλλη αναφορά στο υπάρχον αρχείο εξόδου.

**Γιατί ορισμένα σχήματα δεν παράγουν εικόνα;**

Τα πλαίσια εικόνας, τα σχήματα με γέμισμα εικόνας, τα πλαίσια αντικειμένου OLE, τα μέσα πλαισίων, τα πλαίσια ζουμ, οι πίνακες, τα διαγράμματα και τα αντικείμενα SmartArt μπορούν να αναφέρουν εικόνες. Ορισμένοι τύποι σχημάτων εκθέτουν εικόνες μέσω εσωτερικών αντικειμένων μορφοποίησης, οπότε ένας απλός έλεγχος `PictureFormat` ή `FillFormat` του σχήματος δεν είναι πάντα επαρκής.

**Μπορώ να εξάγω τη μικρογραφία που εμφανίζεται για ένα πλαίσιο βίντεο;**

Ναι. Χρησιμοποιήστε το [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ivideoframe/) και διαβάστε το `PictureFormat.Picture.Image`. Αυτό εξάγει την εικόνα αφίσας που είναι αποθηκευμένη με το πλαίσιο βίντεο, όχι ένα καρέ που δημιουργείται από το αρχείο βίντεο.

**Πώς μπορώ να προσδιορίσω ποια σχήματα χρησιμοποιούν μια συγκεκριμένη εικόνα από τη συλλογή εικόνων της παρουσίασης;**

Το Aspose.Slides δεν αποθηκεύει αντίστροφους συνδέσμους από το [IPPImage](https://reference.aspose.com/slides/el/net/aspose.slides/ippimage/) προς τα σχήματα. Δημιουργήστε έναν χάρτη κατά τη διάρκεια της διαπέρασης: κάθε φορά που βρίσκετε μια αναφορά εικόνας, καταγράψτε τον αριθμό της διαφάνειας, τη διαδρομή του σχήματος και το hash ή το στοιχείο της συλλογής εικόνας.

**Μπορώ να εξάγω εικόνες ενσωματωμένες μέσα σε αντικείμενα OLE, όπως συνημμένα έγγραφα;**

Μπορείτε να εξαγάγετε την προεπισκόπηση διαφάνειας του αντικειμένου OLE από το [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ioleobjectframe/). Ωστόσο, αυτή η προεπισκόπηση δεν είναι το ενσωματωμένο έγγραφο αυτό καθαυτό. Για να εξαγάγετε εικόνες από το ενσωματωμένο αρχείο, εξαγάγετε τα δεδομένα OLE και ελέγξτε τα με εργαλεία κατάλληλα για τον τύπο του αρχείου.