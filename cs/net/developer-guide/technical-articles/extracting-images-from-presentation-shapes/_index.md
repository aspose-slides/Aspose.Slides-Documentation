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
description: "Extrahujte obrázky z tvarů v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET - rychlé, programátorsky přívětivé řešení."
---
## **Přehled**

Obrázky v prezentaci se mohou vyskytovat v několika typech tvarů: jako obyčejné rámečky obrázků, jako výplně obrázkem aplikované na tvary, jako náhledové obrázky OLE objektů, jako miniatury video‑ nebo audio‑rámců, jako zoom obrázky nebo jako obrázky vnořené v tabulkových, grafových a SmartArt tvarech. Aspose.Slides ukládá tyto obrázky do kolekce obrázků prezentace, která je zpřístupněna přes objekty [ImageCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/imagecollection/) a [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/).

Pokud potřebujete jen exportovat všechny vložené obrázkové zdroje v prezentaci, projděte `presentation.Images`. Tento článek se zaměřuje na jiný úkol: procházet tvary a najít, kde jsou obrázky použity na snímcích, aby uložené soubory mohly zachovat užitečný kontext, jako je číslo snímku, pozice tvaru a typ zdroje (rámeček obrázku, výplň obrázkem, náhled média, náhled OLE nebo zoom obrázek).

{{% alert title="Tip" color="primary" %}}
Použijte [IPPImage.BinaryData](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) k zachování původních zakódovaných dat obrázku a typu souboru. Použijte [IPPImage.Image](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) s [IImage.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/) když chcete výstup normalizovat na konkrétní formát, např. PNG.
{{% /alert %}}

## **Sdílené pomocné metody**

Níže uvedené pomocné metody udržují příklady stručné. `SaveOriginalImage` zapisuje původní vložené bajty, volí bezpečnou příponu podle MIME typu a přeskočí duplicitní binární obrázky pomocí SHA‑256 hash.

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

## **Extrahovat obrázky z rámečků obrázků**

Použijte tento přístup pro obrázky vložené jako samostatné objekty. [IPictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ipictureframe/) ukládá svůj obrázek v `PictureFormat.Picture.Image`, což vrací objekt [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/).

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

## **Extrahovat obrázky z tvarů vyplněných obrázkem**

Tvary mohou používat obrázek jako svou výplň. Nejprve zkontrolujte typ výplně tvaru: pokud není [FillType.Picture](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/), neexistuje obrázek, který by se dal z výplně extrahovat. Níže uvedený příklad pracuje s objekty [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) a ukládá každý obrázek jako PNG pomocí [IPPImage.Image](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/).

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

## **Extrahovat náhledové obrázky z OLE objektových rámečků**

[IOleObjectFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ioleobjectframe/) může mít náhradní obrázek, který PowerPoint používá jako náhled objektu na snímku. Tento obrázek je dostupný přes `SubstitutePictureFormat.Picture.Image`. Extrahování tohoto obrázku vám poskytne náhled, nikoli vložený obsah OLE balíčku.

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

## **Extrahovat náhledové obrázky z video‑rámců**

[IVideoFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/) může také uložit náhledový obrázek v `PictureFormat.Picture.Image`. Jedná se o plakát nebo miniaturu zobrazenou na snímku, ne o snímek dekódovaný z video‑proudu.

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

## **Extrahovat náhledové obrázky z audio‑rámců**

[IAudioFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/iaudioframe/) může uložit miniaturu v `PictureFormat.Picture.Image`. Jedná se o obrázek zobrazený pro audio‑objekt na snímku.

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

## **Extrahovat obrázky ze zoom objektů**

Tvary [IZoomFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/izoomframe/) a [ISectionZoomFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/isectionzoomframe/) mohou používat vlastní obrázky. Přečtěte `ZoomImage` ze zoom rámce.

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

## **Extrahovat obrázky z souhrnných zoom rámců**

[ISummaryZoomFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/isummaryzoomframe/) je také tvar. Jeho sekční položky mohou používat vlastní obrázky, které jsou vystaveny prostřednictvím vlastnosti `ZoomImage` každé sekce souhrnného zoomu.

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

## **Extrahovat obrázky z tabulkových tvarů**

[ITable](https://reference.aspose.com/slides/cs/net/aspose.slides/itable/) je tvar. Obrázky v tabulce jsou obvykle uloženy jako výplně obrázkem v buňkách tabulky.

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

## **Extrahovat obrázky z grafových tvarů**

[IChart](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichart/) je tvar. Níže uvedený příklad extrahuje obrázek z výplně oblasti grafu.

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

## **Extrahovat obrázky ze SmartArt tvarů**

[ISmartArt](https://reference.aspose.com/slides/cs/net/aspose.slides.smartart/ismartart/) je objekt tvaru. V závislosti na rozvržení SmartArt mohou být obrázky uloženy v výplních odrážek uzlů nebo ve výplňových formátech tvarů uzlů.

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

## **Zahrnout obrázky uvnitř seskupených tvarů**

Seskupené tvary obsahují vlastní kolekce tvarů. Sdílený pomocník `EnumerateShapes` má volbu `includeGroupedShapes`. Nastavte ji na `true`, když chcete prozkoumat tvary uvnitř objektů [IGroupShape](https://reference.aspose.com/slides/cs/net/aspose.slides/igroupshape/). Níže uvedený příklad extrahuje obrázky z rámečků obrázků, tvarů vyplněných obrázkem, náhledů OLE objektů, miniatur video‑rámců a miniatur audio‑rámců. Pro zahrnutí obrázků z tabulek, grafů, SmartArt a souhrnných zoomů použijte specializovanou logiku extrakce z předchozích sekcí a zachovejte stejný rekurzivní průchod tvary.

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

## **Hraniční případy a praktické poznámky**

- **Duplicitní obrázky:** Více tvarů může odkazovat na stejný obrázek nebo na různé obrázky se stejnými bajty. Před zápisem souborů hashujte [IPPImage.BinaryData](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/), pokud chcete mít jeden výstupní soubor pro každou unikátní podobu.
- **Původní data vs. konvertovaný výstup:** Ukládání [IPPImage.BinaryData](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) zachovává vložená data JPEG, PNG, GIF, SVG, EMF nebo WMF. Ukládání [IPPImage.Image](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) přes [IImage.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/) je užitečné, když chcete jednotný výstupní formát.
- **Nepodporované typy výplní:** Tvary se solidní, gradientní, vzorovanou nebo žádnou výplní neobsahují obrázek. Před čtením `PictureFillFormat` zkontrolujte [FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/).
- **Seskupené tvary:** Kolekce tvarů na úrovni snímku nevyrovnává skupiny. Rekurzivně prozkoumejte [IGroupShape.Shapes](https://reference.aspose.com/slides/cs/net/aspose.slides/igroupshape/), pokud je obsah skupiny podstatný.
- **Náhledy OLE objektů:** [IOleObjectFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ioleobjectframe/) může exposovat náhledový obrázek přes `SubstitutePictureFormat`, ale tento obrázek je jen náhled na snímku, ne vložený soubor uvnitř OLE objektu.
- **Miniatury video‑rámců:** [IVideoFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/) může exposovat náhledový obrázek přes `PictureFormat`, ale jedná se jen o plakát zobrazený na snímku, ne o snímek extrahovaný z video proudu.
- **Miniatury audio‑rámců:** [IAudioFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/iaudioframe/) může exposovat ikonu nebo miniaturu přes `PictureFormat`; nejde o vložená audio data.
- **Zoom obrázky:** Tvary slide zoom, section zoom a summary zoom mohou používat vlastní [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) objekty přes `ZoomImage`.
- **Vnořené modely tvarů:** Tabulkové, grafové a SmartArt objekty implementují [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/), ale jejich obrázky jsou často uloženy v vnořených objektech formátování buněk, prvků grafu nebo uzlů SmartArt.
- **Oříznuté nebo transformované obrázky:** Přístupem k [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) získáte uložený zdroj obrázku. Neposkytuje oříznutí, průhlednost, přeobarvení, rotaci ani jiné vizuální efekty aplikované tvarem.

## **Často kladené otázky**

**Mohu extrahovat původní obrázek bez oříznutí, efektů nebo transformací tvaru?**

Ano. Přistupte k objektu [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) a zapište [IPPImage.BinaryData](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) na disk. Tím zachováte původní zakódovaný obrázek uložený v prezentaci, nikoli způsob, jakým je obrázek vykreslen na snímku.

**Mohu exportovat každý extrahovaný obrázek jako PNG?**

Ano. Použijte [IPPImage.Image](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) k získání objektu [IImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/) a poté zavolejte [IImage.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/) s [ImageFormat.Png](https://reference.aspose.com/slides/cs/net/aspose.slides/imageformat/). Tím se výstup převede a nemusí zachovat původní typ souboru nebo vektorová data.

**Jak zabránit vícenásobnému uložení stejného obrázku?**

Použijte hash [IPPImage.BinaryData](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) a ukládejte hashe do množiny. Pokud nový obrázek má hash, který již existuje, přeskočte jej nebo zaznamenejte další odkaz na existující výstupní soubor.

**Proč některé tvary neprodukují žádný obrázek?**

Rámečky obrázků, tvary vyplněné obrázkem, OLE objektové rámečky, mediální rámečky, zoom rámečky, tabulky, grafy a SmartArt objekty mohou odkazovat na obrázky. Některé typy tvarů exposují obrázky přes vnořené objekty formátování, takže jednoduchá kontrola `PictureFormat` nebo `FillFormat` tvaru nemusí být vždy dostačující.

**Mohu extrahovat miniaturu zobrazenou pro video‑rámec?**

Ano. Použijte [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ivideoframe/) a přečtěte `PictureFormat.Picture.Image`. Tím získáte plakát obrázek uložený s video‑rámcem, nikoli snímek vygenerovaný z video souboru.

**Jak zjistit, které tvary používají konkrétní obrázek z kolekce obrázků prezentace?**

Aspose.Slides neukládá reverzní odkazy z [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) na tvary. Během průchodu si vytvořte mapování: kdykoli najdete odkaz na obrázek, zaznamenejte číslo snímku, cestu tvaru a hash nebo položku kolekce.

**Mohu extrahovat obrázky vložené uvnitř OLE objektů, např. připojených dokumentů?**

Z [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ioleobjectframe/) můžete získat náhled OLE objektu na snímku. Tento náhled však není samotný vložený dokument. Pro extrakci obrázků uvnitř vloženého souboru musíte extrahovat OLE data a prozkoumat je pomocí nástrojů určených pro daný typ souboru.