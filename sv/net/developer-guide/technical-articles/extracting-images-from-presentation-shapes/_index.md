---
title: Extrahera bilder från presentationsformer i .NET
linktitle: Bild från form
type: docs
weight: 90
url: /sv/net/extracting-images-from-presentation-shapes/
keywords:
- extrahera bild
- hämta bild
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Extrahera bilder från former i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för .NET - snabb, kodvänlig lösning."
---
## **Översikt**

Bilder i en presentation kan förekomma i flera formtyper: som vanliga bildramar, som bildfyllningar som tillämpas på former, som förhandsgranskningsbilder för OLE‑objekt, som miniatyrbilder för video‑ eller ljudramar, som zoom‑bilder eller som bilder som är inbäddade i tabell-, diagram‑ och SmartArt‑former. Aspose.Slides lagrar dessa bilder i presentationens bildsamling, som exponeras via [ImageCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/imagecollection/) och [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/)‑objekt.

Om du bara behöver exportera varje bildresurs som är inbäddad i en presentation, iterera genom `presentation.Images`. Denna artikel fokuserar på en annan uppgift: att gå igenom former för att hitta var bilder används på bilderna, så att de sparade filerna kan behålla användbar information såsom bildnummer, formens position och källtypen (bildram, fyllningsbild, medieförhandsgranskning, OLE‑förhandsgranskning eller zoom‑bild).

{{% alert title="Tip" color="primary" %}}
Använd [IPPImage.BinaryData](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/) för att bevara den ursprungliga kodade bilddata och filtyp. Använd [IPPImage.Image](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/) med [IImage.Save](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/) när du vill normalisera utdata till ett specifikt format som PNG.
{{% /alert %}}

## **Delade hjälpfunktioner**

Hjälpfunktionerna nedan håller exemplen korta. `SaveOriginalImage` skriver de ursprungliga inbäddade byten, väljer en säker filändelse från MIME‑typen och hoppar över dubblett‑bildbinärer med SHA‑256‑hash.

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

## **Extrahera bilder från bildramar**

Använd detta tillvägagångssätt för bilder som infogats som fristående objekt. En [IPictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ipictureframe/) lagrar sin bild i `PictureFormat.Picture.Image`, vilket returnerar ett [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/)‑objekt.

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

## **Extrahera bilder från bildfyllda former**

Former kan använda en bild som fyllning. Kontrollera först formens fyllningstyp: om den inte är [FillType.Picture](https://reference.aspose.com/slides/sv/net/aspose.slides/filltype/), finns det ingen bild att extrahera från den fyllningen. Exemplet nedan hanterar [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/)‑objekt och sparar varje bild som PNG via [IPPImage.Image](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/).

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

## **Extrahera förhandsgranskningsbilder från OLE‑objektramar**

En [IOleObjectFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ioleobjectframe/) kan ha en ersättningsbild som PowerPoint använder som objektets förhandsgranskning på en bild. Denna bild är tillgänglig via `SubstitutePictureFormat.Picture.Image`. Att extrahera denna bild ger dig förhandsgranskningsbilden, inte det inbäddade OLE‑paketets innehåll.

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

## **Extrahera förhandsgranskningsbilder från videoramlar**

En [IVideoFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideoframe/) kan också lagra en förhandsgranskningsbild i `PictureFormat.Picture.Image`. Detta är den poster‑ eller miniatyrbild som visas på bilden, inte en bildruta avkodad från videoströmmen.

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

## **Extrahera förhandsgranskningsbilder från ljudramar**

En [IAudioFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/iaudioframe/) kan lagra en miniatyrbild i `PictureFormat.Picture.Image`. Detta är bilden som visas för ljudobjektet på bilden.

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

## **Extrahera bilder från zoom‑objekt**

[IZoomFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/izoomframe/) och [ISectionZoomFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/isectionzoomframe/)‑former kan använda anpassade bilder. Läs `ZoomImage` från zoom‑ramen.

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

## **Extrahera bilder från sammanfattnings‑zoom‑ramar**

En [ISummaryZoomFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/isummaryzoomframe/) är också en form. Dess avsnittselement kan använda anpassade bilder, som exponeras via varje sammanfattnings‑zoom‑avsnitts `ZoomImage`‑egenskap.

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

## **Extrahera bilder från tabellformer**

En [ITable](https://reference.aspose.com/slides/sv/net/aspose.slides/itable/) är en form. Bilder i en tabell lagras vanligtvis som bildfyllningar i tabellceller.

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

## **Extrahera bilder från diagramformer**

En [IChart](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichart/) är en form. Exemplet nedan extraherar en bild från diagramområdets bildfyllning.

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

## **Extrahera bilder från SmartArt‑former**

Ett [ISmartArt](https://reference.aspose.com/slides/sv/net/aspose.slides.smartart/ismartart/)‑objekt är en form. Beroende på SmartArt‑layouten kan bilder lagras i nodpunkt‑fyllningar eller i fyllningsformat för nodformer.

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

## **Inkludera bilder inuti grupperade former**

Grupperade former innehåller sina egna formsamlingar. Den delade hjälpfunktionen `EnumerateShapes` har ett alternativ `includeGroupedShapes`. Sätt det till `true` när du vill inspektera former inuti [IGroupShape](https://reference.aspose.com/slides/sv/net/aspose.slides/igroupshape/)‑objekt. Exemplet nedan extraherar bilder från bildramar, bildfyllda former, OLE‑objekt‑förhandsgranskningar, videoramin‑miniatyrer och ljudram‑miniatyrer. För att även inkludera tabell‑, diagram‑, SmartArt‑ och sammanfattnings‑zoom‑bilder, återanvänd den specialiserade extraheringslogiken från de föregående avsnitten samtidigt som du behåller samma rekursiva formtraversering.

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

## **Särskilda fall och praktiska noteringar**

- **Dubblettbilder:** Flera former kan referera till samma bild eller separata bilder med identiska byte. Hasha [IPPImage.BinaryData](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/) innan du skriver filer om du vill ha en utdatfil per unik bild.
- **Ursprunglig data vs. konverterad utdata:** Att spara [IPPImage.BinaryData](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/) bevarar den inbäddade JPEG‑, PNG‑, GIF‑, SVG‑, EMF‑ eller WMF‑data. Att spara [IPPImage.Image](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/) via [IImage.Save](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/) är användbart när du vill ha ett enhetligt format för utdata.
- **Ej stödda fyllning‑typer:** Solida, gradient‑, mönster‑ och ingen‑fyllning‑former innehåller ingen bildfyllning. Kontrollera [FillType](https://reference.aspose.com/slides/sv/net/aspose.slides/filltype/) innan du läser `PictureFillFormat`.
- **Grupperade former:** Den översta bildens formsamling plattar inte till grupper. Inspektera rekursivt [IGroupShape.Shapes](https://reference.aspose.com/slides/sv/net/aspose.slides/igroupshape/) när grupperat innehåll är viktigt.
- **OLE‑objekt‑förhandsgranskningar:** En [IOleObjectFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ioleobjectframe/) kan exponera en förhandsgranskningsbild via `SubstitutePictureFormat`, men den bilden är endast bildens förhandsgranskning. Det är inte den inbäddade filen i OLE‑objektet.
- **Videoramin‑miniaturer:** En [IVideoFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideoframe/) kan exponera en förhandsgranskningsbild via `PictureFormat`, men den bilden är endast den poster som visas på bilden. Den extraheras inte från videoströmmen.
- **Ljudram‑miniaturer:** En [IAudioFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/iaudioframe/) kan exponera en ikon eller miniatyr via `PictureFormat`; det är inte den inbäddade ljuddata.
- **Zoom‑bilder:** Slide‑zoom‑, sektion‑zoom‑ och sammanfattnings‑zoom‑former kan använda anpassade [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/)‑objekt via `ZoomImage`.
- **Inbäddade formmodeller:** Tabell‑, diagram‑ och SmartArt‑objekt implementerar [IShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/), men deras bilder lagras ofta i inbäddade tabellceller, diagram‑element eller SmartArt‑nodformateringsobjekt.
- **Beskurna eller transformerade bilder:** Att åtkomma [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/) ger dig den lagrade bildresursen. Det renderar inte beskärning, transparens, omfärgning, rotation eller andra visuella effekter som tillämpas av formen.

## **FAQ**

**Kan jag extrahera den ursprungliga bilden utan beskärning, effekter eller formtransformeringar?**

Ja. Åtkom [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/)‑objektet och skriv [IPPImage.BinaryData](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/) till disk. Detta bevarar den ursprungliga kodade bilden som lagras i presentationen, inte hur bilden renderas på bilden.

**Kan jag exportera varje extraherad bild som PNG?**

Ja. Använd [IPPImage.Image](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/) för att få ett [IImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/)‑objekt, och anropa sedan [IImage.Save](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/) med [ImageFormat.Png](https://reference.aspose.com/slides/sv/net/aspose.slides/imageformat/). Detta konverterar utdata och kanske inte bevarar den ursprungliga filtypen eller vektordata.

**Hur undviker jag att spara samma bild mer än en gång?**

Använd en hash av [IPPImage.BinaryData](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/) och behåll hasharna i en uppsättning. Om en ny bild har en hash som redan finns, hoppa över den eller registrera en annan referens till den befintliga utdatafilen.

**Varför ger vissa former ingen bild?**

Bildramar, bildfyllda former, OLE‑objektramar, mediaramar, zoom‑ramar, tabeller, diagram och SmartArt‑objekt kan referera till bilder. Vissa formtyper exponerar bilder genom inbäddade formateringsobjekt, så en enkel kontroll av `PictureFormat` eller formens `FillFormat` räcker inte alltid.

**Kan jag extrahera miniatyrbilden som visas för en videoram?**

Ja. Använd [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ivideoframe/) och läs `PictureFormat.Picture.Image`. Detta extraherar poster‑bilden som lagras med videoramen, inte en bildruta genererad från videofilen.

**Hur kan jag avgöra vilka former som använder en specifik bild från presentationens bildsamling?**

Aspose.Slides lagrar inte omvända länkar från [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/) till former. Bygg en mappning under traverseringen: när du hittar en bildreferens, registrera bildnumret, formens sökväg och bildhash eller samlingsobjekt.

**Kan jag extrahera bilder som är inbäddade i OLE‑objekt, som bifogade dokument?**

Du kan extrahera OLE‑objektets bildförhandsgranskning från [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ioleobjectframe/). Men den förhandsgranskningen är inte det inbäddade dokumentet. För att extrahera bilder från den inbäddade filen, extrahera OLE‑data och undersök den med verktyg för den filtypen.