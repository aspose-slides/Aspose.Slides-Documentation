---
title: Extrahovat obrázky z tvarů prezentace v .NET
linktitle: Obrázek z tvaru
type: docs
weight: 90
url: /cs/net/extracting-images-from-presentation-shapes/
keywords:
- extrahovat obrázek
- získat obrázek
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Extrahujte obrázky z tvarů v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET - rychlé, kódu přátelské řešení."
---
## **Přehled**

Obrázky v prezentaci se mohou vyskytovat v několika typech tvarů: jako běžné rámečky obrázků, jako výplně obrázkem aplikované na tvary, jako náhledové obrázky OLE objektů, jako miniatury video‑ nebo audio‑snímků, jako obrázky přiblížení nebo jako obrázky vnořené uvnitř tabulky, grafu a tvarů SmartArt. Aspose.Slides ukládá tyto obrázky do kolekce obrázků prezentace, která je zpřístupněna prostřednictvím objektů [ImageCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/imagecollection/) a [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/).

Pokud potřebujete pouze exportovat každý obrázek vložený v prezentaci, projděte `presentation.Images`. Tento článek se zaměřuje na jiný úkol: procházet tvary a zjistit, kde jsou obrázky použity na snímcích, aby uložené soubory mohly zachovat užitečný kontext, jako je číslo snímku, umístění tvaru a typ zdroje (rámeček obrázku, výplň obrázkem, náhled média, OLE náhled nebo obrázek přiblížení).

{{% alert title="Tip" color="info" %}}
Použijte [IPPImage.BinaryData](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) k zachování původních kódovaných dat obrázku a typu souboru. Použijte [IPPImage.Image](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) s [IImage.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/) v situaci, kdy chcete normalizovat výstup na konkrétní formát, například PNG.
{{% /alert %}}

## **Sdílené pomocné metody**

Níže uvedené pomocné metody zkracují příklady. `SaveOriginalImage` zapisuje původní vložené bajty, vybírá bezpečnou příponu z MIME typu a přeskočí duplicitní binární obrázky pomocí SHA‑256 hashe.

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

## **Extrahovat obrázky z rámců obrázků**

Použijte tento postup pro obrázky vložené jako samostatné objekty. [IPictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ipictureframe/) ukládá svůj obrázek v `PictureFormat.Picture.Image`, což vrací objekt [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/).

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

## **Extrahovat obrázky z tvarů vyplněných obrázkem**

Tvary mohou používat obrázek jako výplň. Nejprve zkontrolujte typ výplně tvaru: pokud není [FillType.Picture](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/), neexistuje žádný obrázek, který by šlo z této výplně získat. Níže uvedený příklad pracuje s objekty [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) a ukládá každý obrázek jako PNG pomocí [IPPImage.Image](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/).

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

## **Extrahovat náhledové obrázky z OLE rámců objektů**

[IOleObjectFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ioleobjectframe/) může mít náhradní obrázek, který PowerPoint používá jako náhled objektu na snímku. Tento obrázek je k dispozici prostřednictvím `SubstitutePictureFormat.Picture.Image`. Extrahování tohoto obrázku vám poskytne náhled, nikoli vložený obsah OLE balíčku.

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

## **Extrahovat náhledové obrázky z video‑rámců**

[IVideoFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/) může také uložit náhledový obrázek v `PictureFormat.Picture.Image`. Jedná se o plakát nebo miniaturu zobrazenou na snímku, nikoli o snímek dekódovaný z video proudu.

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

## **Extrahovat náhledové obrázky z audio‑rámců**

[IAudioFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/iaudioframe/) může uložit miniaturu v `PictureFormat.Picture.Image`. Jedná se o obrázek zobrazený pro audio objekt na snímku.

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

## **Extrahovat obrázky ze Zoom objektů**

[IZoomFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/izoomframe/) a [ISectionZoomFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/isectionzoomframe/) mohou používat vlastní obrázky. Přečtěte `ZoomImage` ze zoom rámce.

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

## **Extrahovat obrázky ze Summary Zoom rámců**

[ISummaryZoomFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/isummaryzoomframe/) je také tvarem. Jeho položky sekcí mohou používat vlastní obrázky, které jsou vystaveny prostřednictvím vlastnosti `ZoomImage` každé sekce summary zoom.

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

## **Extrahovat obrázky z tabulkových tvarů**

[ITable](https://reference.aspose.com/slides/cs/net/aspose.slides/itable/) je tvarem. Obrázky v tabulce jsou obvykle uloženy jako výplně obrázkem v buňkách tabulky.

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

## **Extrahovat obrázky z grafických tvarů**

[IChart](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichart/) je tvarem. Níže uvedený příklad extrahuje obrázek z výplně obrázkem oblastí grafu.

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

## **Extrahovat obrázky ze SmartArt tvarů**

[ISmartArt](https://reference.aspose.com/slides/cs/net/aspose.slides.smartart/ismartart/) je objekt tvaru. V závislosti na rozvržení SmartArt mohou být obrázky uloženy ve výplních odrážek uzlů nebo ve výplňových formátech tvarů uzlů.

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

## **Zahrnout obrázky uvnitř seskupených tvarů**

Seskupené tvary obsahují vlastní kolekce tvarů. Sdílená pomocná metoda `EnumerateShapes` má možnost `includeGroupedShapes`. Nastavte ji na `true`, pokud chcete prozkoumat tvary uvnitř objektů [IGroupShape](https://reference.aspose.com/slides/cs/net/aspose.slides/igroupshape/). Níže uvedený příklad extrahuje obrázky z rámců obrázků, tvarů vyplněných obrázkem, náhledů OLE objektů, miniatur video‑rámců a miniatur audio‑rámců. Pro zahrnutí obrázků z tabulek, grafů, SmartArt a summary zoom také znovu použijte specializovanou logiku extrakce z předchozích sekcí při zachování stejného rekurzivního procházení tvarů.

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

## **Hraniční případy a praktické poznámky**

- **Duplicitní obrázky:** Více tvarů může odkazovat na stejný obrázek nebo na různé obrázky s identickými bajty. Vytvořte hash pomocí [IPPImage.BinaryData](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) před zápisem souborů, pokud chcete jeden výstupní soubor na unikátní obrázek.
- **Původní data vs. konvertovaný výstup:** Ukládání [IPPImage.BinaryData](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) zachovává vložená data JPEG, PNG, GIF, SVG, EMF nebo WMF. Ukládání [IPPImage.Image](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) pomocí [IImage.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/) je užitečné, když chcete jednotný výstupní formát.
- **Nepodporované typy výplní:** Tvary se solidní, gradientní, vzorovou nebo prázdnou výplní neobsahují obrázek. Zkontrolujte [FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/) před čtením `PictureFillFormat`.
- **Seskupené tvary:** Kolekce tvarů na úrovni snímku nevyrovnává skupiny. Rekurzivně prohlédněte [IGroupShape.Shapes](https://reference.aspose.com/slides/cs/net/aspose.slides/igroupshape/), pokud je seskupený obsah důležitý.
- **Náhledy OLE objektů:** [IOleObjectFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ioleobjectframe/) může vystavit náhledový obrázek přes `SubstitutePictureFormat`, ale tento obrázek je jen náhled snímku. Nejedná se o vložený soubor uvnitř OLE objektu.
- **Miniatury video‑rámců:** [IVideoFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/) může vystavit náhledový obrázek přes `PictureFormat`, ale tento obrázek je jen plakát zobrazený na snímku. Není extrahován z video proudu.
- **Miniatury audio‑rámců:** [IAudioFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/iaudioframe/) může vystavit ikonu nebo miniaturu přes `PictureFormat`; nejde o vložená audio data.
- **Zoom obrázky:** Tvary slide zoom, section zoom a summary zoom mohou používat vlastní objekty [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) přes `ZoomImage`.
- **Vnořené modely tvarů:** Objektů tabulka, graf a SmartArt implementují [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/), ale jejich obrázky jsou často uloženy ve vnořených buňkách tabulky, prvcích grafu nebo formátovacích objektech uzlů SmartArt.
- **Oříznuté nebo transformované obrázky:** Přístup k [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) vám poskytne uložený obrázkový zdroj. Neprezentuje oříznutí, průhlednost, přebarvení, rotaci ani jiné vizuální efekty aplikované tvarem.

## **Často kladené otázky**

### Můžu extrahovat původní obrázek bez oříznutí, efektů nebo transformací tvaru?

Ano. Získejte objekt [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) a zapište [IPPImage.BinaryData](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) na disk. Tím zachováte původní kódovaný obrázek uložený v prezentaci, nikoli způsob, jak je obrázek vykreslen na snímku.

### Můžu exportovat každý extrahovaný obrázek jako PNG?

Ano. Použijte [IPPImage.Image](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) pro získání objektu [IImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/) a poté volejte [IImage.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/) s parametrem [ImageFormat.Png](https://reference.aspose.com/slides/cs/net/aspose.slides/imageformat/). Tím se výstup konvertuje a nemusí zachovat původní typ souboru ani vektorová data.

### Jak zabránit vícečetnému uložení stejného obrázku?

Použijte hash z [IPPImage.BinaryData](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) a ukládejte hashe v množině. Pokud nový obrázek má hash, který již existuje, přeskočte jej nebo zaznamenejte další odkaz na existující výstupní soubor.

### Proč některé tvary neprodukují obrázek?

Rámečky obrázků, tvary vyplněné obrázkem, OLE objektové rámce, mediální rámce, zoom rámce, tabulky, grafy a SmartArt objekty mohou odkazovat na obrázky. Některé typy tvarů vystavují obrázky přes vnořené formátovací objekty, takže jednoduchá kontrola `PictureFormat` nebo `FillFormat` nemusí být vždy dostatečná.

### Můžu extrahovat miniaturu zobrazenou pro video‑rámec?

Ano. Použijte [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/) a přečtěte `PictureFormat.Picture.Image`. Tím získáte plakátový obrázek uložený s video‑rámcem, ne snímek generovaný z video souboru.

### Jak mohu určit, které tvary používají konkrétní obrázek z kolekce obrázků prezentace?

Aspose.Slides neukládá zpětné odkazy z [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) na tvary. Vytvořte mapu během procházení: kdykoli najdete odkaz na obrázek, zaznamenejte číslo snímku, cestu tvaru a hash nebo položku kolekce obrázku.

### Můžu extrahovat obrázky vložené uvnitř OLE objektů, například připojené dokumenty?

Můžete extrahovat náhled OLE objektu z [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ioleobjectframe/). Tento náhled však není samotný vložený dokument. Pro extrakci obrázků uvnitř vloženého souboru musíte extrahovat OLE data a prozkoumat je pomocí nástrojů vhodných pro daný typ souboru.