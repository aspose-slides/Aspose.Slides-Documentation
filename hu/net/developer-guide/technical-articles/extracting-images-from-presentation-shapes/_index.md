---
title: Képek kinyerése prezentáció alakzatokból .NET-ben
linktitle: Kép az alakzatról
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
description: "Képek kinyerése alakzatokból PowerPoint és OpenDocument prezentációkból az Aspose.Slides for .NET segítségével – gyors, kódközpontú megoldás."
---
## **Áttekintés**

A prezentációban lévő képek többféle alakzattípusban jelenhetnek meg: egyszerű képkeretként, alakzatokhoz alkalmazott képkitöltésként, OLE objektum előnézeti képeként, videó‑ vagy hangkeret bélyegképeként, zoom‑képként, vagy táblázat-, diagram‑ és SmartArt‑alakzatokba ágyazott képekként. Az Aspose.Slides ezeket a képeket a prezentáció képgyűjteményében tárolja, amely a [ImageCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/imagecollection/) és [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) objektumokon keresztül érhető el.

Ha csak a prezentációba ágyazott minden képernyőforrást szeretné exportálni, iteráljon a `presentation.Images` gyűjteményen. Ez a cikk egy másik feladatra összpontosít: a diákon található képek felhasználási helyeinek megtalálásához alakzatokat kell bejárni, hogy a mentett fájlok megtarthassák a hasznos kontextust, például a dia számát, az alakzat pozícióját és a forrástípust (képkeret, kitöltő kép, média előnézet, OLE előnézet vagy zoom‑kép).

{{% alert title="Tip" color="primary" %}}
Használja a [IPPImage.BinaryData](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) metódust az eredeti kódolt képadatok és fájltípus megőrzéséhez. A [IPPImage.Image](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) és az [IImage.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) kombinációját akkor válassza, ha a kimenetet egy meghatározott formátumra (például PNG) szeretné normalizálni.
{{% /alert %}}

## **Megosztott Segédfüggvények**

Az alábbi segédfüggvények rövidítik a példákat. A `SaveOriginalImage` az eredeti beágyazott bájtokat írja ki, a MIME‑típus alapján biztonságos kiterjesztést választ, és az SHA‑256 hash alapján kihagyja a duplicate kép binárisokat.

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

## **Képek kinyerése képkeretekből**

Ezt a megközelítést használja önálló objektumként beillesztett képekhez. Az [IPictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ipictureframe/) a képét a `PictureFormat.Picture.Image` tulajdonságban tárolja, amely egy [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) objektumot ad vissza.

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

## **Képek kinyerése kép‑kitöltésű alakzatokból**

Az alakzatok képet használhatnak kitöltésként. Először ellenőrizze az alakzat kitöltés típusát: ha nem [FillType.Picture](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/) a típus, akkor nincs kép, amelyet ebből a kitöltésből ki lehetne nyerni. Az alábbi példa a [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) objektumokkal dolgozik, és minden képet PNG‑ként ment a [IPPImage.Image](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) segítségével.

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

## **Előnézeti képek kinyerése OLE objektumkeretekből**

Az [IOleObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ioleobjectframe/) rendelkezhet helyettesítő képpel, amelyet a PowerPoint az objektum előnézeteként jelenít meg a dián. Ez a kép a `SubstitutePictureFormat.Picture.Image` tulajdonságon keresztül érhető el. Ennek a képrészletnek a kinyerése az előnézeti képet adja, nem az OLE‑csomag beágyazott tartalmát.

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

## **Előnézeti képek kinyerése videókeretekből**

Az [IVideoFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/) szintén tárolhat előnézeti képet a `PictureFormat.Picture.Image` tulajdonságban. Ez a poszter vagy bélyegkép, amely a dián látható, nem egy a videófolyamból dekódolt keret.

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

## **Előnézeti képek kinyerése hangkeretekből**

Az [IAudioFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/iaudioframe/) tárolhat bélyegképet a `PictureFormat.Picture.Image` tulajdonságban. Ez a kép a hangobjektus megjelenítése a dián.

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

## **Képek kinyerése zoom objektumokból**

Az [IZoomFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/izoomframe/) és az [ISectionZoomFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/isectionzoomframe/) alakzatok egyedi képeket használhatnak. Olvassa ki a `ZoomImage` tulajdonságot a zoomkeretből.

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

## **Képek kinyerése összegző zoomkeretekből**

Az [ISummaryZoomFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/isummaryzoomframe/) is egy alakzat. Szekcióelemei egyedi képeket használhatnak, melyek az egyes összegző zoom szekciók `ZoomImage` tulajdonságán keresztül érhetők el.

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

## **Képek kinyerése táblázat alakzatokból**

Az [ITable](https://reference.aspose.com/slides/hu/net/aspose.slides/itable/) egy alakzat. A táblázatban lévő képek általában képkitöltésként vannak tárolva a táblázat celláiban.

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

## **Képek kinyerése diagram alakzatokból**

Az [IChart](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichart/) egy alakzat. Az alábbi példa a diagram területének képkitöltéséből nyer ki egy képet.

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

## **Képek kinyerése SmartArt alakzatokból**

Az [ISmartArt](https://reference.aspose.com/slides/hu/net/aspose.slides.smartart/ismartart/) objektum egy alakzat. A SmartArt elrendezésétől függően a képek a csomópontok felsorolás‑kitöltésében vagy a csomópont alakzatok kitöltési formátumaiban tárolódhatnak.

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

## **Képek belefoglalása csoportosított alakzatokba**

A csoportosított alakzatok saját alakzategyüttesekkel rendelkeznek. A megosztott `EnumerateShapes` segédfüggvénynek van egy `includeGroupedShapes` opciója. Állítsa `true`‑ra, ha a [IGroupShape](https://reference.aspose.com/slides/hu/net/aspose.slides/igroupshape/) objektumok belsejét is vizsgálni szeretné. Az alábbi példa képeket nyer ki képkeretekből, kép‑kitöltésű alakzatokból, OLE‑objektum előnézetekből, videókeret bélyegképekből és hangkeret bélyegképekből. A táblázat, diagram, SmartArt és összegző zoom képek bevonásához használja újra a korábbi szakaszokban bemutatott speciális kinyerési logikát, miközben ugyanazt a rekurzív alakzatbejárást alkalmazza.

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

## **Szegélyes esetek és gyakorlati megjegyzések**

- **Duplikált képek:** Több alakzat hivatkozhat ugyanarra a képre, vagy különálló képek lehetnek azonos bájtokkal. A [IPPImage.BinaryData](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) hashelése a fájlok írása előtt biztosítja, hogy egy kimeneti fájl legyen minden egyedi képhez.
- **Eredeti adat vs. konvertált kimenet:** A [IPPImage.BinaryData](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) mentése megőrzi a beágyazott JPEG, PNG, GIF, SVG, EMF vagy WMF adatot. A [IPPImage.Image](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) és az [IImage.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) használata akkor hasznos, ha egységes kimeneti formátumra (például PNG) van szükség.
- **Nem támogatott kitöltéstípusok:** Szilárd, fokozatos, mintás és üres kitöltésű alakzatok nem tartalmaznak képkitöltést. Ellenőrizze a [FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/) értékét, mielőtt a `PictureFillFormat`‑ot olvasná.
- **Csoportosított alakzatok:** A felső szintű dia‑alakzatgyűjtemény nem laposítja a csoportokat. Rekurzívan vizsgálja meg a [IGroupShape.Shapes](https://reference.aspose.com/slides/hu/net/aspose.slides/igroupshape/) elemeket, ha a csoportos tartalom fontos.
- **OLE‑objektum előnézetek:** Egy [IOleObjectFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ioleobjectframe/) a `SubstitutePictureFormat`‑on keresztül előnézeti képet jeleníthet meg, de ez csak a dia előnézete, nem az OLE‑objektumban beágyazott fájl.
- **Videókeret bélyegképek:** Egy [IVideoFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/) a `PictureFormat`‑on keresztül előnézeti képet ad, de ez csak a dián megjelenő poszter, nem a videófolyamból származó keret.
- **Hangkeret bélyegképek:** Egy [IAudioFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/iaudioframe/) az `PictureFormat`‑on keresztül ikont vagy bélyegképet jeleníthet meg; ez nem a beágyazott hangadat.
- **Zoom‑képek:** Diázoom, szekció‑zoom és összegző‑zoom alakzatok egyedi [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) objektumokat használhatnak a `ZoomImage`‑en keresztül.
- **Egymásba ágyazott alakzatiemodellek:** A táblázat, diagram és SmartArt objektumok implementálják az [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/) interfészt, de képeik gyakran beágyazott táblázatcellák, diagram‑elemek vagy SmartArt‑csomópont formázó objektumokban tárolódnak.
- **Vágott vagy átalakított képek:** A [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) elérése a tárolt képforrásra ad vissza. Nem alkalmazza a vágást, átlátszóságot, újraszínezést, forgatást vagy egyéb vizuális effektusokat, amelyeket az alakzat alkalmaz.

## **GYIK**

**Kinyerhetem az eredeti képet vágás, hatások vagy alakzattranszformációk nélkül?**

Igen. Hívja meg a [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) objektumot, és írja a [IPPImage.BinaryData](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) adatokat lemezre. Ez megőrzi a prezentációban tárolt eredeti kódolt képet, nem pedig a dián megjelenített verziót.

**Exportálhatom minden kinyert képet PNG‑ként?**

Igen. Használja a [IPPImage.Image](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) metódust az [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) objektum megszerzéséhez, majd hívja meg az [IImage.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/)‑t a [ImageFormat.Png](https://reference.aspose.com/slides/hu/net/aspose.slides/imageformat/) paraméterrel. Ez a kimenetet PNG‑re konvertálja, és előfordulhat, hogy nem őrzi meg az eredeti fájltípust vagy vektoralapú adatot.

**Hogyan kerülhetem el, hogy ugyanazt a képet többször is mentsem?**

Használjon hash‑t a [IPPImage.BinaryData](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) alapján, és tárolja a hash‑eket egy halmazban. Ha egy új kép hash‑e már létezik, hagyja ki a mentést, vagy rögzítsen egy másik hivatkozást a már létező kimeneti fájlra.

**Miért nem készül kép bizonyos alakzatokból?**

Képkeretek, kép‑kitöltésű alakzatok, OLE‑objektumkeretek, média keretek, zoom‑keretek, táblázatok, diagramok és SmartArt objektumok hivatkozhatnak képekre. Néhány alakzat típus beágyazott formázóobjektumokon keresztül teszi elérhetővé a képet, ezért egy egyszerű `PictureFormat` vagy `FillFormat` ellenőrzés nem mindig elegendő.

**Kinyerhetem a videókerethez tartozó bélyegképet?**

Igen. Használja a [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ivideoframe/)‑et, és olvassa a `PictureFormat.Picture.Image` tulajdonságot. Ez a videókerethez társított posztert, azaz a bélyegképet nyeri ki, nem a videofájlból generált keretet.

**Hogyan tudom meghatározni, mely alakzatok használják a prezentáció képgyűjteményének egy adott képét?**

Az Aspose.Slides nem tárol visszacsatoló hivatkozásokat a [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) és az alakzatok között. A bejárás során építsen fel egy térképet: amikor egy képhivatkozást talál, rögzítse a dia számát, az alakzat útvonalát és a kép hash‑ét vagy gyűjteményindexét.

**Kinyerhetem a beágyazott OLE‑objektumokban lévő képeket, például a csatolt dokumentumokban?**

A [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ioleobjectframe/) segítségével csak az OLE‑objektum dia‑előnézetét nyerheti ki. Ez az előnézet azonban nem a beágyazott dokumentum. A beágyazott fájlban lévő képek kinyeréséhez először ki kell nyerni az OLE‑adatot, majd a megfelelő eszközökkel elemezni az adott fájltípust.