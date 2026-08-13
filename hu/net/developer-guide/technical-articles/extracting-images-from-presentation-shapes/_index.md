---
title: Képek kinyerése a prezentáció alakzataiból .NET-ben
linktitle: Kép az alakzatból
type: docs
weight: 90
url: /hu/net/extracting-images-from-presentation-shapes/
keywords:
- kép kinyerése
- kép lekérése
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Képek kinyerése alakzatokból PowerPoint és OpenDocument prezentációkban az Aspose.Slides for .NET használatával - gyors, kódközpontú megoldás."
---
## **Áttekintés**

A dián lévő képek többféle alakzattípusban jelenhetnek meg: egyszerű képkeretként, alakzatokra alkalmazott képkitöltésként, OLE‑objektum előnézeti képekként, videó- vagy hangkeret bélyegképeként, zoom képekként, vagy táblázat, diagram és SmartArt alakzatok belsejébe ágyazott képekként. Az Aspose.Slides ezeket a képeket a prezentáció képgat gyűjteményében tárolja, amelyet a [ImageCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/imagecollection/) és a [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) objektumok tesznek elérhetővé.

Ha csak minden beágyazott képernyőforrást szeretnél exportálni egy prezentációból, akkor iterálj a `presentation.Images`‑en. Ez a cikk egy másik feladatra összpontosít: alakzatok bejárására, hogy megtalálja, hol használják a képeket a diákon, így a mentett fájlok megtarthatják a hasznos kontextust, például a dia számát, az alakzat pozícióját és a forrástípust (képkeret, kitöltő kép, média előnézet, OLE előnézet vagy zoom kép).

{{% alert title="Tip" color="info" %}}
Használd az [IPPImage.BinaryData](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) metódust az eredeti kódolt képadat és fájltípus megőrzéséhez. Használd az [IPPImage.Image](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) metódust a [IImage.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/)‑vel, ha a kimenetet egy adott formátumra, például PNG‑re szeretnéd normalizálni.
{{% /alert %}}

## **Közös Segítő Metódusok**

Az alábbi segítő metódusok röviden tartják a példákat. A `SaveOriginalImage` az eredeti beágyazott bájtokat írja, a MIME típusból biztonságos kiterjesztést választ, és a SHA-256 hash alapján kihagyja a duplikált kép binárisokat.

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

## **Képek kinyerése képkeretből**

Ezt a megközelítést önálló objektumként beszúrt képekhez használd. Az [IPictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ipictureframe/) a képét a `PictureFormat.Picture.Image` tulajdonában tárolja, amely egy [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) objektumot ad vissza.

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

## **Képek kinyerése képpel kitöltött alakzatokból**

Az alakzatok képet használhatnak kitöltésként. Először ellenőrizd az alakzat kitöltés típusát: ha nem [FillType.Picture](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/), akkor nincs kép, amit ebből a kitöltésből ki lehetne nyerni. Az alábbi példa kezeli a [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) objektumokat, és minden képet PNG formátumban ment az [IPPImage.Image](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) segítségével.

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

## **Előnézeti képek kinyerése OLE objektumkeretekből**

Egy [IOleObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ioleobjectframe/) helyettesítő képet is tartalmazhat, amelyet a PowerPoint az objektum dián látható előnézeteként használ. Ez a kép a `SubstitutePictureFormat.Picture.Image` útján érhető el. Ennek a képnek a kinyerése az előnézeti képet adja, nem a beágyazott OLE csomag tartalmát.

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

## **Előnézeti képek kinyerése videókeretekből**

Egy [IVideoFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/) szintén tárolhat előnézeti képet a `PictureFormat.Picture.Image` tulajdonában. Ez a poszter vagy bélyegkép, amely a dián látható, nem pedig a videó folyamából dekódolt képkocka.

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

## **Előnézeti képek kinyerése hangkeretekből**

Egy [IAudioFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/iaudioframe/) tárolhat bélyegképet a `PictureFormat.Picture.Image` tulajdonában. Ez a kép jelenik meg a hangobjektumhoz a dián.

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

## **Képek kinyerése zoom objektumokból**

Az [IZoomFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/izoomframe/) és [ISectionZoomFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/isectionzoomframe/) alakzatok egyéni képeket használhatnak. Olvasd ki a `ZoomImage`‑t a zoom keretből.

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

## **Képek kinyerése összegző zoom keretekből**

Az [ISummaryZoomFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/isummaryzoomframe/) szintén egy alakzat. Szakasz elemei egyéni képeket használhatnak, amelyeket minden összegző zoom szakasz `ZoomImage` tulajdonsága tesz elérhetővé.

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

## **Képek kinyerése táblázat alakzatokból**

Az [ITable](https://reference.aspose.com/slides/hu/net/aspose.slides/itable/) egy alakzat. A táblázatban lévő képek általában képpel kitöltött táblázatcellákban tárolódnak.

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

## **Képek kinyerése diagram alakzatokból**

Az [IChart](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichart/) egy alakzat. Az alábbi példa egy képet nyer ki a diagram területének képpel kitöltéséből.

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

## **Képek kinyerése SmartArt alakzatokból**

Az [ISmartArt](https://reference.aspose.com/slides/hu/net/aspose.slides.smartart/ismartart/) objektum egy alakzat. A SmartArt elrendezésétől függően a képek a csomópontok felsorolás kitöltéseiben vagy a csomópont alakzatok kitöltési formátumaiban tárolódhatnak.

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

## **Képek belefoglalása csoportosított alakzatokba**

A csoportosított alakzatok saját alakzattárakat tartalmaznak. A közös `EnumerateShapes` segítőnek van egy `includeGroupedShapes` opciója. Állítsd `true`‑ra, ha az [IGroupShape](https://reference.aspose.com/slides/hu/net/aspose.slides/igroupshape/) objektumok belsejében lévő alakzatokat is szeretnéd ellenőrizni. Az alábbi példa képeket nyer ki képkeretekből, képpel kitöltött alakzatokból, OLE objektum előnézetekből, videókeret bélyegképekből és hangkeret bélyegképekből. Ha a táblázat, diagram, SmartArt és összegző zoom képeket is bele akarod foglalni, használd újra a korábbi szakaszokban bemutatott speciális kinyerési logikát, miközben ugyanazt a rekurzív alakzat bejárást alkalmazod.

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

## **Különleges esetek és gyakorlati megjegyzések**

- **Duplikált képek:** Több alakzat is hivatkozhat ugyanarra a képre vagy különálló képekre, amelyek azonos bájtokkal rendelkeznek. Használd a [IPPImage.BinaryData](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) hash‑elését a fájlok írása előtt, ha egy kimeneti fájlt szeretnél az egyedi képre.
- **Eredeti adat vs. konvertált kimenet:** A [IPPImage.BinaryData](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) mentése megőrzi a beágyazott JPEG, PNG, GIF, SVG, EMF vagy WMF adatot. Az [IPPImage.Image](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) mentése a [IImage.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/)‑vel hasznos, ha egységes kimeneti formátumot, például PNG‑t szeretnél.
- **Nem támogatott kitöltéstípusok:** Szilárd, fokozatos, mintás és nincs kitöltésű alakzatok nem tartalmaznak képpel kitöltést. Ellenőrizd a [FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/)‑t, mielőtt a `PictureFillFormat`‑ot olvasnád.
- **Csoportosított alakzatok:** A felső szintű diá alakzattár nem laposítja a csoportokat. Rekurzívan ellenőrizd a [IGroupShape.Shapes](https://reference.aspose.com/slides/hu/net/aspose.slides/igroupshape/)‑t, ha a csoportos tartalom fontos.
- **OLE objektum előnézetek:** Egy [IOleObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ioleobjectframe/) előnézeti képet mutathat a `SubstitutePictureFormat` segítségével, de ez csak a dia előnézete. Nem a beágyazott fájl az OLE objektumban.
- **Videókeret bélyegképek:** Egy [IVideoFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/) előnézeti képet mutathat a `PictureFormat`‑on keresztül, de ez csak a dián látható poszter. Nem a videó folyamából nyert képkocka.
- **Hangkeret bélyegképek:** Egy [IAudioFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/iaudioframe/) ikon vagy bélyegkép jelenhet meg a `PictureFormat`‑on; ez nem a beágyazott hangadat.
- **Zoom képek:** Dia zoom, szakasz zoom és összegző zoom alakzatok egyéni [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) objektumokat használhatnak a `ZoomImage`‑en keresztül.
- **Beágyazott alakzati modellek:** A táblázat, diagram és SmartArt objektumok implementálják az [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/)‑t, de képeik gyakran beágyazott táblázatcella, diagram elem vagy SmartArt csomópont formázási objektumokban tárolódnak.
- **Vágott vagy átalakított képek:** Az [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) elérése a tárolt kép erőforrást adja. Nem ábrázolja a vágást, átlátszóságot, újraszínezést, forgatást vagy egyéb vizuális hatásokat, amelyeket az alakzat alkalmaz.

## **GYIK**

### Kivonhatom‑e az eredeti képet vágás, hatás vagy alakzattranszformáció nélkül?

Igen. Hozzáférhetsz a [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) objektumhoz, és a [IPPImage.BinaryData](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/)‑t lemezre írod. Ez megőrzi a prezentációban tárolt eredeti kódolt képet, nem pedig azt, ahogyan a kép a dián megjelenik.

### Exportálhatom‑e minden kinyert képet PNG‑ként?

Igen. Használd az [IPPImage.Image](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/)‑t egy [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) objektum lekéréséhez, majd hívd meg az [IImage.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/)‑t az [ImageFormat.Png](https://reference.aspose.com/slides/hu/net/aspose.slides/imageformat/)‑el. Ez átalakítja a kimenetet, és előfordulhat, hogy nem őrzi meg az eredeti fájltípust vagy vektor adatot.

### Hogyan kerülhetem el, hogy ugyanazt a képet több alkalommal mentsem?

Használj hash‑t a [IPPImage.BinaryData](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/)‑ból, és tárold a hash‑eket egy halmazban. Ha egy új kép hash‑e már létezik, hagyd ki, vagy rögzíts egy további hivatkozást a már meglévő kimeneti fájlra.

### Miért nem ad ki néhány alakzat képet?

Képkeretek, képpel kitöltött alakzatok, OLE objektumkeretek, média keretek, zoom keretek, táblázatok, diagramok és SmartArt objektumok hivatkozhatnak képekre. Néhány alakzattípus beágyazott formázási objektumokon keresztül teszi elérhetővé a képeket, így egy egyszerű `PictureFormat` vagy alakzat `FillFormat` ellenőrzés gyakran nem elegendő.

### Kinyerhető‑e a videókerethez tartozó bélyegkép?

Igen. Használd a [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/)‑t, és olvasd a `PictureFormat.Picture.Image`‑t. Ez a videókerettel tárolt poszter képet nyeri ki, nem egy a videófájlból generált képkockát.

### Hogyan határozhatom meg, hogy mely alakzatok használnak egy adott képet a prezentáció képgat gyűjteményéből?

Az Aspose.Slides nem tárol visszacsatoló hivatkozásokat a [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/)‑ből alakzatokra. Építs egy leképezést a bejárás során: amikor képhivatkozást találsz, rögzítsd a dia számát, az alakzat útvonalát, valamint a kép hash‑ét vagy a gyűjtemény elemét.

### Kinyerhető‑e a beágyazott OLE‑objektumokban lévő képek, például a csatolt dokumentumok?

A [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ioleobjectframe/) segítségével ki tudod nyerni az OLE objektum diával kapcsolatos előnézetét. Azonban ez az előnézet nem maga a beágyazott dokumentum. Ahhoz, hogy a beágyazott fájlon belüli képeket kinyerd, ki kell nyerned az OLE adatot, majd a fájltípusnak megfelelő eszközökkel vizsgálni.