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
description: "Afbeeldingen extraheren uit vormen in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor .NET - snelle, programmeervriendelijke oplossing."
---
## **Overzicht**

Afbeeldingen in een presentatie kunnen in verschillende vormtypen voorkomen: als gewone afbeeldingskaders, als afbeeldingsvullingen toegepast op vormen, als voorbeeldafbeeldingen van OLE‑objecten, als miniaturen van video‑ of audio‑frames, als zoomafbeeldingen, of als afbeeldingen genest binnen tabellen, grafieken en SmartArt‑vormen. Aspose.Slides slaat die afbeeldingen op in de afbeeldingsverzameling van de presentatie, toegankelijk via de objecten [ImageCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/imagecollection/) en [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) objects.

Als u alleen elke in de presentatie ingebedde afbeeldingsbron wilt exporteren, doorloop dan `presentation.Images`. Dit artikel richt zich op een andere taak: vormen doorlopen om te vinden waar afbeeldingen op de dia's worden gebruikt, zodat de opgeslagen bestanden nuttige context kunnen behouden, zoals het dia‑nummer, de vormpositie en het brontype (afbeeldingskader, vullingsafbeelding, mediavoorbeeld, OLE‑voorbeeld of zoomafbeelding).

{{% alert title="Tip" color="info" %}}

Gebruik [IPPImage.BinaryData](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) om de oorspronkelijk gecodeerde afbeeldingsgegevens en bestandstype te behouden. Gebruik [IPPImage.Image](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) met [IImage.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/) wanneer u de uitvoer wilt normaliseren naar een specifiek formaat zoals PNG.

{{% /alert %}}

## **Gedeelde helpermethoden**

De helpermethoden hieronder houden de voorbeelden kort. `SaveOriginalImage` schrijft de oorspronkelijk ingebedde bytes, kiest een veilige extensie op basis van het MIME‑type, en slaat dubbele afbeeldingsbinaire bestanden over op basis van een SHA‑256‑hash.

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

## **Afbeeldingen extraheren uit afbeeldingskaders**

Gebruik deze aanpak voor afbeeldingen die als zelfstandige objecten zijn ingevoegd. Een [IPictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ipictureframe/) slaat zijn afbeelding op in `PictureFormat.Picture.Image`, wat een [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) object retourneert.

```c#
using Aspose.Slides;

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

## **Afbeeldingen extraheren uit met afbeeldingen gevulde vormen**

Vormen kunnen een afbeelding als vulling gebruiken. Controleer eerst het vullingstype van de vorm: als het niet [FillType.Picture](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) is, is er geen afbeelding om uit die vulling te extraheren. Het voorbeeld hieronder behandelt [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) objecten en slaat elke afbeelding op als PNG via [IPPImage.Image](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/).

```c#
using Aspose.Slides;

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

## **Voorbeeldafbeeldingen extraheren uit OLE‑objectkaders**

Een [IOleObjectFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ioleobjectframe/) kan een vervangende afbeelding hebben die PowerPoint gebruikt als voorbeeld van het object op een dia. Deze afbeelding is beschikbaar via `SubstitutePictureFormat.Picture.Image`. Het extraheren van deze afbeelding levert de voorbeeldafbeelding op, niet de ingebedde OLE‑pakketinhoud.

```c#
using Aspose.Slides;

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

## **Voorbeeldafbeeldingen extraheren uit video‑frames**

Een [IVideoFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/) kan ook een voorbeeldafbeelding opslaan in `PictureFormat.Picture.Image`. Dit is de poster‑ of miniatuurfoto die op de dia wordt getoond, niet een frame dat is gedecodeerd uit de videostroom.

```c#
using Aspose.Slides;

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

## **Voorbeeldafbeeldingen extraheren uit audio‑frames**

Een [IAudioFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/iaudioframe/) kan een miniatuur opslaan in `PictureFormat.Picture.Image`. Dit is de afbeelding die wordt getoond voor het audio‑object op de dia.

```c#
using Aspose.Slides;

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
using Aspose.Slides;

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

## **Afbeeldingen extraheren uit samenvattende zoom‑frames**

Een [ISummaryZoomFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/isummaryzoomframe/) is ook een vorm. De sectie‑items kunnen aangepaste afbeeldingen gebruiken, toegankelijk via de `ZoomImage`‑eigenschap van elke samenvattende zoom‑sectie.

```c#
using Aspose.Slides;

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

Een [ITable](https://reference.aspose.com/slides/nl/net/aspose.slides/itable/) is een vorm. Afbeeldingen in een tabel worden meestal opgeslagen als afbeeldingenvullingen in tabelcellen.

```c#
using Aspose.Slides;

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

Een [IChart](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichart/) is een vorm. Het voorbeeld hieronder haalt een afbeelding uit de afbeeldingenvulling van het diagramgebied.

```c#
using Aspose.Slides;

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

Een [ISmartArt](https://reference.aspose.com/slides/nl/net/aspose.slides.smartart/ismartart/) object is een vorm. Afhankelijk van de SmartArt‑indeling kunnen afbeeldingen worden opgeslagen in de kogel‑vullingen van knooppunten of in de vullingsformaten van knooppunt‑vormen.

```c#
using Aspose.Slides;

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

Gegroepeerde vormen bevatten hun eigen vormcollecties. De gedeelde helper `EnumerateShapes` heeft een `includeGroupedShapes`‑optie. Zet deze op `true` wanneer u vormen binnen [IGroupShape](https://reference.aspose.com/slides/nl/net/aspose.slides/igroupshape/) objecten wilt inspecteren. Het voorbeeld hieronder extrahert afbeeldingen uit afbeeldingskaders, met afbeeldingenvulling gevulde vormen, OLE‑objectvoorbeelden, miniaturen van video‑frames en miniaturen van audio‑frames. Om ook tabel-, grafiek-, SmartArt- en samenvattende zoom‑afbeeldingen op te nemen, hergebruik de gespecialiseerde extractielogica uit de vorige secties terwijl u dezelfde recursieve vormdoorloop behoudt.

```c#
using Aspose.Slides;

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

- **Duplicaatafbeeldingen:** Meerdere vormen kunnen naar dezelfde afbeelding verwijzen of naar verschillende afbeeldingen met identieke bytes. Hash [IPPImage.BinaryData](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) vóór het schrijven van bestanden als u één uitvoerbestand per unieke afbeelding wilt.
- **Oorspronkelijke gegevens vs. geconverteerde uitvoer:** Het opslaan van [IPPImage.BinaryData](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) behoudt de ingebedde JPEG-, PNG-, GIF-, SVG-, EMF- of WMF‑gegevens. Het opslaan van [IPPImage.Image](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) via [IImage.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/) is nuttig wanneer u een consistent uitvoerformaat wilt.
- **Niet‑ondersteunde vullingstypen:** Vormen met een effen, verloop, patroon of zonder vulling bevatten geen afbeeldingenvulling. Controleer [FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) voordat u `PictureFillFormat` leest.
- **Gegroepeerde vormen:** De boven‑level dia‑vormcollectie maakt geen platte weergave van groepen. Doorloop recursief [IGroupShape.Shapes](https://reference.aspose.com/slides/nl/net/aspose.slides/igroupshape/) wanneer gegroepeerde inhoud van belang is.
- **OLE‑objectvoorbeelden:** Een [IOleObjectFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ioleobjectframe/) kan een voorbeeldafbeelding blootleggen via `SubstitutePictureFormat`, maar die afbeelding is alleen het dia‑voorbeeld. Het is niet het ingebedde bestand in het OLE‑object.
- **Miniaturen van video‑frames:** Een [IVideoFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/) kan een voorbeeldafbeelding blootleggen via `PictureFormat`, maar die afbeelding is alleen de poster die op de dia wordt getoond. Het wordt niet geëxtraheerd uit de videostroom.
- **Miniaturen van audio‑frames:** Een [IAudioFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/iaudioframe/) kan een pictogram of miniatuur blootleggen via `PictureFormat`; het is niet de ingebedde audio‑data.
- **Zoom‑afbeeldingen:** Slide‑zoom, sectie‑zoom en samenvattende zoom‑vormen kunnen aangepaste [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) objecten gebruiken via `ZoomImage`.
- **Geneste vormmodellen:** Tabel‑, grafiek‑ en SmartArt‑objecten implementeren [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/), maar hun afbeeldingen worden vaak opgeslagen in geneste tabelcel‑, diagram‑element‑ of SmartArt‑knooppunt‑formattering objecten.
- **Bijgesneden of getransformeerde afbeeldingen:** Toegang tot [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) geeft u de opgeslagen afbeeldingsbron. Het rendert geen bijsnijden, transparantie, herkleuring, rotatie of andere visuele effecten die door de vorm worden toegepast.

## **FAQ**

### Kan ik de originele afbeelding extraheren zonder bijsnijden, effecten of vormtransformaties?

Ja. Benader het [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) object en schrijf [IPPImage.BinaryData](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) naar schijf. Hiermee behoudt u de oorspronkelijk gecodeerde afbeelding die in de presentatie is opgeslagen, niet de manier waarop de afbeelding op de dia wordt gerenderd.

### Kan ik elke geëxtraheerde afbeelding exporteren als PNG?

Ja. Gebruik [IPPImage.Image](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) om een [IImage](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/) object te verkrijgen, en roep vervolgens [IImage.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/) aan met [ImageFormat.Png](https://reference.aspose.com/slides/nl/net/aspose.slides/imageformat/). Dit converteert de uitvoer en behoudt mogelijk niet het originele bestandstype of vectorgegevens.

### Hoe voorkom ik dat dezelfde afbeelding meer dan één keer wordt opgeslagen?

Gebruik een hash van [IPPImage.BinaryData](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) en bewaar de hashes in een set. Als een nieuwe afbeelding een hash heeft die al bestaat, sla deze dan over of noteer een andere referentie naar het bestaande uitvoerbestand.

### Waarom leveren sommige vormen geen afbeelding?

Afbeeldingskaders, met afbeeldingenvulling gevulde vormen, OLE‑objectkaders, mediakaders, zoomkaders, tabellen, grafieken en SmartArt‑objecten kunnen naar afbeeldingen verwijzen. Sommige vormtypen exposeren afbeeldingen via geneste opmaakobjecten, dus een eenvoudige controle van `PictureFormat` of vorm `FillFormat` is niet altijd voldoende.

### Kan ik de miniatuur extraheren die wordt getoond voor een video‑frame?

Ja. Gebruik [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ivideoframe/) en lees `PictureFormat.Picture.Image`. Hiermee wordt de poster‑afbeelding geëxtraheerd die bij het video‑frame is opgeslagen, niet een frame dat is gegenereerd uit het videobestand.

### Hoe kan ik bepalen welke vormen een specifieke afbeelding uit de afbeeldingsverzameling van de presentatie gebruiken?

Aspose.Slides slaat geen omgekeerde koppelingen van [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) naar vormen op. Bouw tijdens het doorlopen een mapping op: wanneer u een afbeeldingsreferentie vindt, noteer dan het dia‑nummer, het vormpad en de afbeeldingshash of collectie‑item.

### Kan ik afbeeldingen extraheren die ingebed zijn in OLE‑objecten, zoals bijgevoegde documenten?

U kunt het dia‑voorbeeld van het OLE‑object extraheren via [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ioleobjectframe/). Dit voorbeeld is echter niet het ingebedde document zelf. Om afbeeldingen uit het ingebedde bestand te extraheren, moet u de OLE‑gegevens extraheren en deze inspecteren met tools voor dat bestandstype.