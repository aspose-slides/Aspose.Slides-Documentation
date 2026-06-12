---
title: Afbeeldingen extraheren uit presentatievormen in .NET
linktitle: Afbeelding van vorm
type: docs
weight: 90
url: /nl/net/extracting-images-from-presentation-shapes/
keywords:
- afbeelding extraheren
- afbeelding ophalen
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Afbeeldingen extraheren uit vormen in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor .NET - snelle, codevriendelijke oplossing."
---
## **Overzicht**

Afbeeldingen in een presentatie kunnen in verschillende vormtypen voorkomen: als gewone foto‑kaders, als foto‑opvullingen toegepast op vormen, als OLE‑object‑preview‑afbeeldingen, als miniaturen van video‑ of audio‑frames, als zoom‑afbeeldingen, of als afbeeldingen die genest zijn in tabel‑, grafiek‑ en SmartArt‑vormen. Aspose.Slides slaat die afbeeldingen op in de presentatie‑afbeeldingscollectie, toegankelijk via [ImageCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/imagecollection/) en [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) objecten.

Als je alleen elke afbeeldingsbron die in een presentatie is ingebed wilt exporteren, itereren door `presentation.Images`. Dit artikel richt zich op een andere taak: vormen doorlopen om te achterhalen waar afbeeldingen op dia’s worden gebruikt, zodat de opgeslagen bestanden bruikbare context kunnen behouden zoals het dia‑nummer, de vormpositie en het type bron (foto‑kader, opvul‑afbeelding, media‑preview, OLE‑preview of zoom‑afbeelding).

{{% alert title="Tip" color="primary" %}}
Gebruik [IPPImage.BinaryData](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) om de oorspronkelijke gecodeerde afbeeldingsgegevens en bestandstype te behouden. Gebruik [IPPImage.Image](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) met [IImage.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/) wanneer je de uitvoer wilt normaliseren naar een specifiek formaat zoals PNG.
{{% /alert %}}

## **Gedeelde hulpfuncties**

De hulpfuncties hieronder houden de voorbeelden kort. `SaveOriginalImage` schrijft de oorspronkelijke ingebedde bytes, kiest een veilige extensie op basis van het MIME‑type, en slaat dubbele afbeeldings‑binaries over door een SHA‑256‑hash.

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

## **Afbeeldingen extraheren uit foto‑kaders**

Gebruik deze aanpak voor afbeeldingen die als zelfstandige objecten zijn ingevoegd. Een [IPictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ipictureframe/) slaat zijn foto op in `PictureFormat.Picture.Image`, wat een [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) object retourneert.

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

## **Afbeeldingen extraheren uit foto‑gevulde vormen**

Vormen kunnen een foto als opvulling gebruiken. Controleer eerst het opvullingstype van de vorm: als het niet [FillType.Picture](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) is, is er geen foto om uit die opvulling te halen. Het voorbeeld hieronder behandelt [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) objecten en slaat elke afbeelding op als PNG via [IPPImage.Image](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/).

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

## **Preview‑afbeeldingen extraheren uit OLE‑objectkaders**

Een [IOleObjectFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ioleobjectframe/) kan een vervangende foto hebben die PowerPoint gebruikt als de preview van het object op een dia. Deze afbeelding is beschikbaar via `SubstitutePictureFormat.Picture.Image`. Het extraheren van deze foto levert de preview‑afbeelding op, niet de ingebedde OLE‑pakket‑inhoud.

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

## **Preview‑afbeeldingen extraheren uit video‑kaders**

Een [IVideoFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/) kan ook een preview‑afbeelding opslaan in `PictureFormat.Picture.Image`. Dit is de poster‑ of miniatuurafbeelding die op de dia wordt getoond, niet een frame dat uit de videostroom is gedecodeerd.

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

## **Preview‑afbeeldingen extraheren uit audio‑kaders**

Een [IAudioFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/iaudioframe/) kan een miniatuur opslaan in `PictureFormat.Picture.Image`. Dit is de afbeelding die wordt getoond voor het audio‑object op de dia.

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

## **Afbeeldingen extraheren uit zoom‑objecten**

[IZoomFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/izoomframe/) en [ISectionZoomFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/isectionzoomframe/) vormen kunnen aangepaste afbeeldingen gebruiken. Lees `ZoomImage` van het zoom‑frame.

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

## **Afbeeldingen extraheren uit samenvattende zoom‑kaders**

Een [ISummaryZoomFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/isummaryzoomframe/) is ook een vorm. De sectie‑items kunnen aangepaste afbeeldingen gebruiken, toegankelijk via de `ZoomImage`‑eigenschap van elk samenvattend zoom‑sectie‑item.

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

## **Afbeeldingen extraheren uit tabel‑vormen**

Een [ITable](https://reference.aspose.com/slides/nl/net/aspose.slides/itable/) is een vorm. Afbeeldingen in een tabel worden meestal opgeslagen als foto‑opvullingen in tabelcellen.

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

## **Afbeeldingen extraheren uit grafiek‑vormen**

Een [IChart](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichart/) is een vorm. Het voorbeeld hieronder haalt een afbeelding uit de foto‑opvulling van het grafiekgebied.

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

## **Afbeeldingen extraheren uit SmartArt‑vormen**

Een [ISmartArt](https://reference.aspose.com/slides/nl/net/aspose.slides.smartart/ismartart/) object is een vorm. Afhankelijk van de SmartArt‑lay-out kunnen afbeeldingen worden opgeslagen in knooppunt‑bullet‑opvullingen of in de opvullingsformaten van knooppunt‑vormen.

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

## **Afbeeldingen opnemen in gegroepeerde vormen**

Gegroepeerde vormen bevatten hun eigen vormcollecties. De gedeelde `EnumerateShapes`‑helper heeft een `includeGroupedShapes`‑optie. Zet deze op `true` wanneer je vormen binnen [IGroupShape](https://reference.aspose.com/slides/nl/net/aspose.slides/igroupshape/) objecten wilt inspecteren. Het voorbeeld hieronder haalt afbeeldingen uit foto‑kaders, foto‑gevulde vormen, OLE‑object‑previews, video‑frame‑miniaturen en audio‑frame‑miniaturen. Om ook tabel‑, grafiek‑, SmartArt‑ en samenvattende zoom‑afbeeldingen mee te nemen, hergebruik je de gespecialiseerde extractielogica uit de vorige secties terwijl je dezelfde recursieve vorm‑doorloop behoudt.

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

## **Randgevallen en praktische opmerkingen**

- **Dubbele afbeeldingen:** Meerdere vormen kunnen naar dezelfde afbeelding verwijzen of naar afzonderlijke afbeeldingen met identieke bytes. Hash [IPPImage.BinaryData](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) vóór het wegschrijven van bestanden als je één uitvoerbestand per unieke afbeelding wilt.
- **Originele data vs. geconverteerde output:** Het opslaan van [IPPImage.BinaryData](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) behoudt de ingebedde JPEG, PNG, GIF, SVG, EMF of WMF data. Het opslaan van [IPPImage.Image](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) via [IImage.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/) is nuttig wanneer je een consistent uitvoerformaat wilt.
- **Niet‑ondersteunde opvullingstypen:** Solide, gradient, patroon‑ en geen‑opvulling‑vormen bevatten geen foto‑opvulling. Controleer [FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) vóór het lezen van `PictureFillFormat`.
- **Gegroepeerde vormen:** De bovenliggende dia‑vormcollectie vlakt groepen niet af. Inspecteer recursief [IGroupShape.Shapes](https://reference.aspose.com/slides/nl/net/aspose.slides/igroupshape/) wanneer gegroepeerde inhoud van belang is.
- **OLE‑object‑previews:** Een [IOleObjectFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ioleobjectframe/) kan een preview‑afbeelding blootleggen via `SubstitutePictureFormat`, maar die afbeelding is alleen de slide‑preview. Het is niet het ingebedde bestand binnen het OLE‑object.
- **Video‑frame‑miniaturen:** Een [IVideoFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/) kan een preview‑afbeelding blootleggen via `PictureFormat`, maar die afbeelding is alleen de poster die op de dia wordt getoond. Het wordt niet uit de videostroom geëxtraheerd.
- **Audio‑frame‑miniaturen:** Een [IAudioFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/iaudioframe/) kan een icoon of miniatuur blootleggen via `PictureFormat`; het is niet de ingebedde audio‑data.
- **Zoom‑afbeeldingen:** Slide‑zoom, sectie‑zoom en samenvattende zoom‑vormen kunnen aangepaste [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) objecten gebruiken via `ZoomImage`.
- **Geneste vorm‑modellen:** Tabel‑, grafiek‑ en SmartArt‑objecten implementeren [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/), maar hun afbeeldingen worden vaak opgeslagen in geneste tabel‑cel, grafiek‑element of SmartArt‑knooppunt‑formatteerobjecten.
- **Bijsneden of getransformeerde foto’s:** Toegang tot [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) geeft je de opgeslagen afbeeldingsbron. Het renderen van bijsnijden, transparantie, herkleuring, rotatie of andere visuele effecten die op de vorm zijn toegepast, gebeurt niet.

## **FAQ**

**Kan ik de originele afbeelding extraheren zonder bijsnijden, effecten of vorm‑transformaties?**

Ja. Gebruik het [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) object en schrijf [IPPImage.BinaryData](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) naar schijf. Dit behoudt de oorspronkelijke gecodeerde afbeelding die in de presentatie is opgeslagen, niet de manier waarop de afbeelding op de dia wordt weergegeven.

**Kan ik elke geëxtraheerde afbeelding als PNG exporteren?**

Ja. Gebruik [IPPImage.Image](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) om een [IImage](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/) object te krijgen, en roep vervolgens [IImage.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/) aan met [ImageFormat.Png](https://reference.aspose.com/slides/nl/net/aspose.slides/imageformat/). Dit zet de output om en behoudt mogelijk niet het oorspronkelijke bestandstype of vector‑data.

**Hoe voorkom ik dat ik dezelfde afbeelding meer dan één keer opsla?**

Gebruik een hash van [IPPImage.BinaryData](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) en houd de hashes bij in een set. Als een nieuwe afbeelding een hash heeft die al bestaat, sla je deze over of registreer je een extra verwijzing naar het bestaande output‑bestand.

**Waarom leveren sommige vormen geen afbeelding?**

Foto‑kaders, foto‑gevulde vormen, OLE‑object‑kaders, media‑kaders, zoom‑kaders, tabellen, grafieken en SmartArt‑objecten kunnen naar afbeeldingen verwijzen. Sommige vorm‑types exposen afbeeldingen via geneste formatteerobjecten, dus een eenvoudige `PictureFormat`‑ of vorm‑`FillFormat`‑controle is niet altijd voldoende.

**Kan ik de miniatuur van een video‑frame extraheren?**

Ja. Gebruik [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/) en lees `PictureFormat.Picture.Image`. Dit haalt de poster‑afbeelding op die bij het video‑frame is opgeslagen, niet een frame dat uit het videobestand is gegenereerd.

**Hoe kan ik bepalen welke vormen een specifieke afbeelding uit de presentatie‑afbeeldingscollectie gebruiken?**

Aspose.Slides slaat geen omgekeerde koppelingen op van [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) naar vormen. Bouw tijdens de doorloop een mapping: wanneer je een afbeeldingsreferentie tegenkomt, noteer je het dia‑nummer, het vormpad en de afbeelding‑hash of collectiewaarde.

**Kan ik afbeeldingen extraheren die ingebed zijn in OLE‑objecten, zoals bijgevoegde documenten?**

Je kunt de slide‑preview van het OLE‑object extraheren via [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ioleobjectframe/). Deze preview is echter niet het ingebedde document zelf. Om afbeeldingen uit het ingebedde bestand te halen, moet je de OLE‑data extraheren en deze met geschikte gereedschappen voor dat bestandstype inspecteren.