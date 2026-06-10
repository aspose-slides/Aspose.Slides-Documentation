---
title: Képek kinyerése a prezentáció alakzataiból Java-ban
linktitle: Kép az alakzatról
type: docs
weight: 100
url: /hu/java/extracting-images-from-presentation-shapes/
keywords:
- kép kinyerése
- kép lekérése
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Képek kinyerése alakzatokból PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Java-val - gyors, kódközpontú megoldás."
---
## **Overview**

A prezentációban lévő képek többféle alakzattípusban jelenhetnek meg: egyszerű képkeretként, alakzatokra alkalmazott kép kitöltésként, OLE objektum előnézeti képként, videó‑ vagy hangkeret bélyegképeként, nagyítási képként, vagy táblázat, diagram és SmartArt alakzatokba ágyazott képekként. Az Aspose.Slides ezeket a képeket a prezentáció képgyűjteményében tárolja, amely a [IImageCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides.iimagecollection/) és a [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/) objektumokon keresztül érhető el.

Ha csak az összes, a prezentációba beágyazott képernyőforrást szeretné exportálni, iteráljon a `presentation.getImages()`-en. Ez a cikk egy másik feladatra összpontosít: a alakzatok bejárására, hogy megtalálja, hol használják a képeket a diákon, így a mentett fájlok megőrzik a hasznos kontextust, például a dia számát, az alakzat pozícióját és a forrást (képkeret, kitöltő kép, média előnézet, OLE előnézet vagy nagyítási kép).

{{% alert title="Tip" color="primary" %}}
Használja a [IPPImage.getBinaryData](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/#getBinaryData--) metódust az eredeti kódolt képadatok és fájltípus megőrzéséhez. Használja a [IPPImage.getImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/#getImage--) metódust a [IImage.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides.iimage/#save-java.lang.String-int-) segítségével, ha az outputot egy egységes formátumra, például PNG‑re szeretné normalizálni.
{{% /alert %}}

## **Shared Helper Methods**

Az alábbi segédmetódusok rövidre fogják a példákat. A `saveOriginalImage` az eredeti beágyazott bájtokat írja, a MIME‑típus alapján biztonságos kiterjesztést választ, és SHA‑256 hash‑el kihagyja a duplikált képbinárisokat.

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;
import java.security.MessageDigest;
import java.util.ArrayList;
import java.util.List;
import java.util.Locale;
import java.util.Set;

private static final class ShapeReference
{
    private final IShape shape;
    private final String namePart;

    private ShapeReference(IShape shape, String namePart)
    {
        this.shape = shape;
        this.namePart = namePart;
    }
}

private static boolean saveOriginalImage(
    IPPImage image,
    String outputDirectory,
    String fileNameBase,
    Set<String> savedImageHashes) throws Exception
{
    byte[] imageData = image.getBinaryData();
    String imageHash = getSha256Hash(imageData);
    if (!savedImageHashes.add(imageHash))
    {
        return false;
    }

    String extension = getExtensionFromContentType(image.getContentType());
    String fileName = fileNameBase + "." + extension;
    File outputFile = new File(outputDirectory, fileName);

    FileOutputStream outputStream = new FileOutputStream(outputFile);
    try
    {
        outputStream.write(imageData);
    }
    finally
    {
        outputStream.close();
    }

    return true;
}

private static void saveImageAsPng(IPPImage image, String outputDirectory, String fileNameBase)
{
    String fileName = fileNameBase + ".png";
    File outputFile = new File(outputDirectory, fileName);
    String outputPath = outputFile.getPath();

    IImage outputImage = image.getImage();
    try
    {
        outputImage.save(outputPath, ImageFormat.Png);
    }
    finally
    {
        if (outputImage != null)
        {
            outputImage.dispose();
        }
    }
}

private static IPPImage getPictureFillImage(IFillFormat fillFormat)
{
    if (fillFormat == null || fillFormat.getFillType() != FillType.Picture)
    {
        return null;
    }

    return fillFormat.getPictureFillFormat().getPicture().getImage();
}

private static List<ShapeReference> enumerateShapes(
    IShapeCollection shapes,
    String prefix,
    boolean includeGroupedShapes)
{
    List<ShapeReference> shapeReferences = new ArrayList<ShapeReference>();
    int shapeCount = shapes.size();
    for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        IShape shape = shapes.get_Item(shapeIndex);
        int displayIndex = shapeIndex + 1;
        String shapeNamePart = prefix + "_shape_" + displayIndex;
        ShapeReference shapeReference = new ShapeReference(shape, shapeNamePart);
        shapeReferences.add(shapeReference);

        if (includeGroupedShapes && shape instanceof IGroupShape)
        {
            IGroupShape groupShape = (IGroupShape)shape;
            IShapeCollection childShapes = groupShape.getShapes();
            List<ShapeReference> childReferences = enumerateShapes(
                childShapes,
                shapeNamePart,
                includeGroupedShapes);
            shapeReferences.addAll(childReferences);
        }
    }

    return shapeReferences;
}

private static String getSha256Hash(byte[] data) throws Exception
{
    MessageDigest messageDigest = MessageDigest.getInstance("SHA-256");
    byte[] hashBytes = messageDigest.digest(data);
    StringBuilder hashBuilder = new StringBuilder();
    for (byte hashByte : hashBytes)
    {
        String hexValue = Integer.toHexString(hashByte & 0xff);
        if (hexValue.length() == 1)
        {
            hashBuilder.append('0');
        }

        hashBuilder.append(hexValue);
    }

    return hashBuilder.toString();
}

private static String getExtensionFromContentType(String contentType)
{
    if (contentType == null || contentType.trim().length() == 0)
    {
        return "bin";
    }

    String mediaType = contentType.split(";")[0].trim().toLowerCase(Locale.ROOT);
    if ("image/jpeg".equals(mediaType))
    {
        return "jpg";
    }

    if ("image/png".equals(mediaType))
    {
        return "png";
    }

    if ("image/gif".equals(mediaType))
    {
        return "gif";
    }

    if ("image/bmp".equals(mediaType))
    {
        return "bmp";
    }

    if ("image/tiff".equals(mediaType))
    {
        return "tiff";
    }

    if ("image/x-emf".equals(mediaType) || "image/emf".equals(mediaType))
    {
        return "emf";
    }

    if ("image/x-wmf".equals(mediaType) || "image/wmf".equals(mediaType))
    {
        return "wmf";
    }

    if ("image/svg+xml".equals(mediaType))
    {
        return "svg";
    }

    if (mediaType.startsWith("image/"))
    {
        String extension = mediaType.substring("image/".length());
        return makeSafeFileNamePart(extension);
    }

    return "bin";
}

private static String makeSafeFileNamePart(String value)
{
    return value.replaceAll("[^A-Za-z0-9._-]", "_");
}
```

## **Extract Images from Picture Frames**

Használja ezt a megközelítést a önálló objektumként beillesztett képekhez. Egy [IPictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ipictureframe/) a képét a `getPictureFormat().getPicture().getImage()`‑en keresztül tárolja, ami egy [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/) objektumot ad vissza.

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "extracted-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IPictureFrame)
            {
                IPictureFrame pictureFrame = (IPictureFrame)shapeReference.shape;
                IPPImage image = pictureFrame.getPictureFormat().getPicture().getImage();
                saveOriginalImage(image, outputDirectory, shapeReference.namePart, savedImageHashes);
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Extract Images from Picture-Filled Shapes**

Az alakzatok képet használhatnak kitöltésként. Először ellenőrizze az alakzat kitöltés típusát: ha nem [FillType.Picture](https://reference.aspose.com/slides/hu/java/com.aspose.slides.filltype/), nincs kép, amit a kitöltésből ki lehetne nyerni. Az alábbi példa a [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides.iautoshape/) objektumokat kezeli, és minden képet PNG‑ként ment a [IPPImage.getImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/#getImage--) használatával.

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "shape-fill-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IAutoShape)
            {
                IAutoShape autoShape = (IAutoShape)shapeReference.shape;
                IFillFormat fillFormat = autoShape.getFillFormat();
                IPPImage image = getPictureFillImage(fillFormat);
                if (image != null)
                {
                    saveImageAsPng(image, outputDirectory, shapeReference.namePart);
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Extract Preview Images from OLE Object Frames**

Egy [IOleObjectFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ioleobjectframe/) helyettesítő képet tartalmazhat, amelyet a PowerPoint a objektum dián megjelenő előnézeteként használ. Ez a kép a `getSubstitutePictureFormat().getPicture().getImage()`‑en keresztül érhető el. Ennek a képnek a kinyerése az előnézeti képet adja, nem pedig a beágyazott OLE‑csomag tartalmát.

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "ole-preview-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IOleObjectFrame)
            {
                IOleObjectFrame oleObjectFrame = (IOleObjectFrame)shapeReference.shape;
                IPPImage image = oleObjectFrame.getSubstitutePictureFormat().getPicture().getImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_ole_preview";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Extract Preview Images from Video Frames**

Egy [IVideoFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ivideoframe/) szintén tárolhat előnézeti képet a `getPictureFormat().getPicture().getImage()`‑en keresztül. Ez a poszter vagy bélyegkép, amely a dián látható, nem pedig a videófolyamból dekódolt keret.

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "video-preview-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IVideoFrame)
            {
                IVideoFrame videoFrame = (IVideoFrame)shapeReference.shape;
                IPPImage image = videoFrame.getPictureFormat().getPicture().getImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_video_preview";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Extract Preview Images from Audio Frames**

Egy [IAudioFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides.iaudioframe/) tárolhat egy bélyegképet a `getPictureFormat().getPicture().getImage()`‑en keresztül. Ez a hangobjektushoz tartozó kép a dián.

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "audio-preview-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IAudioFrame)
            {
                IAudioFrame audioFrame = (IAudioFrame)shapeReference.shape;
                IPPImage image = audioFrame.getPictureFormat().getPicture().getImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_audio_preview";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Extract Images from Zoom Objects**

Az [IZoomFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides.izoomframe/) és az [ISectionZoomFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides.isectionzoomframe/) alakzatok egyedi képeket használhatnak. Olvassa ki a `getZoomImage()`‑t a zoom keretből.

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "zoom-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IZoomFrame)
            {
                IZoomFrame zoomFrame = (IZoomFrame)shapeReference.shape;
                IPPImage image = zoomFrame.getZoomImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_zoom";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                    continue;
                }
            }

            if (shapeReference.shape instanceof ISectionZoomFrame)
            {
                ISectionZoomFrame sectionZoomFrame = (ISectionZoomFrame)shapeReference.shape;
                IPPImage image = sectionZoomFrame.getZoomImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_section_zoom";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                    continue;
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Extract Images from Summary Zoom Frames**

Az [ISummaryZoomFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides.isummaryzoomframe/) szintén egy alakzat. A szekcióelemei egyedi képeket használhatnak, amelyeket az egyes összegző zoom szekciók `getZoomImage()` metódusa szolgáltat.

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "summary-zoom-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof ISummaryZoomFrame)
            {
                ISummaryZoomFrame summaryZoomFrame = (ISummaryZoomFrame)shapeReference.shape;
                int sectionCount = summaryZoomFrame.getSummaryZoomCollection().size();
                for (int sectionIndex = 0; sectionIndex < sectionCount; sectionIndex++)
                {
                    ISummaryZoomSection section = summaryZoomFrame.getSummaryZoomCollection().get_Item(sectionIndex);
                    IPPImage image = section.getZoomImage();
                    if (image != null)
                    {
                        int displayIndex = sectionIndex + 1;
                        String fileNameBase = shapeReference.namePart + "_summary_zoom_" + displayIndex;
                        saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                    }
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Extract Images from Table Shapes**

Az [ITable](https://reference.aspose.com/slides/hu/java/com.aspose.slides.itable/) egy alakzat. A táblázatban lévő képek általában képilletként tárolódnak a táblázatcellák kitöltéseiben.

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "table-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, true);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof ITable)
            {
                ITable table = (ITable)shapeReference.shape;
                int rowCount = table.getRows().size();
                int columnCount = table.getColumns().size();
                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                    {
                        ICell cell = table.get_Item(columnIndex, rowIndex);
                        IFillFormat fillFormat = cell.getCellFormat().getFillFormat();
                        IPPImage image = getPictureFillImage(fillFormat);
                        if (image != null)
                        {
                            int displayRow = rowIndex + 1;
                            int displayColumn = columnIndex + 1;
                            String fileNameBase = shapeReference.namePart + "_cell_" + displayRow + "_" + displayColumn;
                            saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Extract Images from Chart Shapes**

Az [IChart](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ichart/) egy alakzat. Az alábbi példa a diagram területének képillet kitöltéséből nyeri ki a képet.

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "chart-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, true);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IChart)
            {
                IChart chart = (IChart)shapeReference.shape;
                IFillFormat fillFormat = chart.getFillFormat();
                IPPImage image = getPictureFillImage(fillFormat);
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_chart_area";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Extract Images from SmartArt Shapes**

Egy [ISmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ismartart/) objektum alakzat. A SmartArt elrendezésétől függően a képek tárolhatók a csomópontok golyókitöltéseiben vagy a csomópont alakzatok kitöltési formátumaiban.

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "smartart-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, true);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof ISmartArt)
            {
                ISmartArt smartArt = (ISmartArt)shapeReference.shape;
                int nodeCount = smartArt.getAllNodes().size();
                for (int nodeIndex = 0; nodeIndex < nodeCount; nodeIndex++)
                {
                    ISmartArtNode node = smartArt.getAllNodes().get_Item(nodeIndex);
                    IFillFormat bulletFillFormat = node.getBulletFillFormat();
                    IPPImage bulletImage = getPictureFillImage(bulletFillFormat);
                    if (bulletImage != null)
                    {
                        int displayNode = nodeIndex + 1;
                        String fileNameBase = shapeReference.namePart + "_smartart_node_" + displayNode + "_bullet";
                        saveOriginalImage(bulletImage, outputDirectory, fileNameBase, savedImageHashes);
                    }

                    int nodeShapeCount = node.getShapes().size();
                    for (int nodeShapeIndex = 0; nodeShapeIndex < nodeShapeCount; nodeShapeIndex++)
                    {
                        ISmartArtShape nodeShape = node.getShapes().get_Item(nodeShapeIndex);
                        IFillFormat fillFormat = nodeShape.getFillFormat();
                        IPPImage image = getPictureFillImage(fillFormat);
                        if (image != null)
                        {
                            int displayNode = nodeIndex + 1;
                            int displayNodeShape = nodeShapeIndex + 1;
                            String fileNameBase = shapeReference.namePart + "_smartart_node_" + displayNode + "_shape_" + displayNodeShape;
                            saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Include Images Inside Grouped Shapes**

A csoportosított alakzatok saját alakzatgyűjteménnyel rendelkeznek. A megosztott `enumerateShapes` segédnek van egy `includeGroupedShapes` opciója. Állítsa `true`‑ra, ha a [IGroupShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides.igroupshape/) objektumok belsejében lévő alakzatokat is vizsgálni szeretné. Az alábbi példa képeket nyer ki képkeretekből, kép‑kitöltésű alakzatokból, OLE objektum előnézetekből, videókeret bélyegképekből és hangkeret bélyegképekből. A táblázat-, diagram-, SmartArt- és összegző nagyítási képek felvételéhez használja újra az előző szakaszok specializált kinyerési logikáját, miközben ugyanazt a rekurzív alakzatbejárást tartja.

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "all-shape-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, true);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IOleObjectFrame)
            {
                IOleObjectFrame oleObjectFrame = (IOleObjectFrame)shapeReference.shape;
                IPPImage image = oleObjectFrame.getSubstitutePictureFormat().getPicture().getImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_ole_preview";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (shapeReference.shape instanceof IVideoFrame)
            {
                IVideoFrame videoFrame = (IVideoFrame)shapeReference.shape;
                IPPImage image = videoFrame.getPictureFormat().getPicture().getImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_video_preview";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (shapeReference.shape instanceof IAudioFrame)
            {
                IAudioFrame audioFrame = (IAudioFrame)shapeReference.shape;
                IPPImage image = audioFrame.getPictureFormat().getPicture().getImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_audio_preview";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (shapeReference.shape instanceof IPictureFrame)
            {
                IPictureFrame pictureFrame = (IPictureFrame)shapeReference.shape;
                IPPImage image = pictureFrame.getPictureFormat().getPicture().getImage();
                saveOriginalImage(image, outputDirectory, shapeReference.namePart, savedImageHashes);
                continue;
            }

            if (shapeReference.shape instanceof IAutoShape)
            {
                IAutoShape autoShape = (IAutoShape)shapeReference.shape;
                IFillFormat fillFormat = autoShape.getFillFormat();
                IPPImage image = getPictureFillImage(fillFormat);
                if (image != null)
                {
                    saveOriginalImage(image, outputDirectory, shapeReference.namePart, savedImageHashes);
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Edge Cases and Practical Notes**

- **Duplicate images:** Több alakzat hivatkozhat ugyanarra a képre, vagy különböző képekre, amelyek azonos bájtokat tartalmaznak. Használja a [IPPImage.getBinaryData](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/#getBinaryData--) hash‑ét, mielőtt fájlokat írna, ha egy kimeneti fájlt szeretne egyedi képhez.
- **Original data vs. converted output:** A [IPPImage.getBinaryData](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/#getBinaryData--) mentése megőrzi a beágyazott JPEG, PNG, GIF, SVG, EMF vagy WMF adatot. A [IPPImage.getImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/#getImage--) és a [IImage.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides.iimage/#save-java.lang.String-int-) használata hasznos, ha egységes output formátumra, például PNG‑re van szükség.
- **Unsupported fill types:** Szilárd, gradiensek, mintázat és üres kitöltésű alakzatok nem tartalmaznak kép‑kitöltést. Ellenőrizze a [FillType](https://reference.aspose.com/slides/hu/java/com.aspose.slides.filltype/) értéket, mielőtt a `getPictureFillFormat()`‑t hívná.
- **Grouped shapes:** A felső szintű dia‑alakzatgyűjtemény nem laposítja a csoportokat. Rekurzívan ellenőrizze a [IGroupShape.getShapes](https://reference.aspose.com/slides/hu/java/com.aspose.slides.igroupshape/#getShapes--) metódust, ha a csoportos tartalom számít.
- **OLE object previews:** Egy [IOleObjectFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ioleobjectframe/) előnézeti képet adhat a `getSubstitutePictureFormat()`‑en keresztül, de ez csak a dia‑előnézet. Nem a beágyazott fájl az OLE objektumban.
- **Video frame thumbnails:** Egy [IVideoFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ivideoframe/) előnézeti képet adhat a `getPictureFormat()`‑en keresztül, de ez csak a dián megjelenő poszter. Nem a videófolyamból származik.
- **Audio frame thumbnails:** Egy [IAudioFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides.iaudioframe/) ikon vagy bélyegkép jelenhet meg a `getPictureFormat()`‑en keresztül; ez nem a beágyazott hangadat.
- **Zoom images:** Dia‑zoom, szekció‑zoom és összegző zoom alakzatok egyedi [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/) objektumokat használhatnak a `getZoomImage()` segítségével.
- **Nested shape models:** A táblázat, diagram és SmartArt objektumok implementálják a [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ishape/) interfészt, de képeik gyakran beágyazott táblázatcellák, diagram‑elemek vagy SmartArt‑csomópont formázási objektumokban tárolódnak.
- **Cropped or transformed pictures:** Az [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/) elérése a tárolt képforrást adja vissza. Nem jeleníti meg a vágást, átlátszóságot, színátmenetet, forgatást vagy egyéb vizuális hatásokat, amelyeket az alakzat alkalmaz.

## **FAQ**

**Can I extract the original image without cropping, effects, or shape transformations?**

Igen. Hozzáférhet a [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/) objektumhoz, és a [IPPImage.getBinaryData](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/#getBinaryData--) segítségével írhatja a lemezre. Ez megőrzi a prezentációban tárolt eredeti kódolt képet, nem pedig a dián megjelenő változatot.

**Can I export every extracted image as PNG?**

Igen. Használja a [IPPImage.getImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/#getImage--) metódust egy [IImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides.iimage/) objektum megszerzéséhez, majd hívja a [IImage.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides.iimage/#save-java.lang.String-int-) metódust a [ImageFormat.Png](https://reference.aspose.com/slides/hu/java/com.aspose.slides.imageformat/) paraméterrel. Ez átalakítja a kimenetet, és nem feltétlenül őrzi meg az eredeti fájltípust vagy vektoralapú adatot.

**How do I avoid saving the same image more than once?**

Használjon hash‑t a [IPPImage.getBinaryData](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/#getBinaryData--) alapján, és tárolja a hash‑eket egy halmazban. Ha egy új kép hash‑e már létezik, hagyja ki, vagy rögzítsen egy másik hivatkozást a már meglévő kimeneti fájlra.

**Why do some shapes not produce an image?**

Képkeretek, kép‑kitöltésű alakzatok, OLE objektum keretek, média keretek, zoom keretek, táblázatok, diagramok és SmartArt objektumok hivatkozhatnak képekre. Néhány alakzattípus képet rejtett formázási objektumokon keresztül tesz elérhetővé, ezért egy egyszerű `getPictureFormat()` vagy `getFillFormat()` ellenőrzés nem mindig elegendő.

**Can I extract the thumbnail shown for a video frame?**

Igen. Használja a [IVideoFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ivideoframe/) objektumot, és olvassa a `getPictureFormat().getPicture().getImage()`‑t. Ez a videókerethez tárolt posztert (bélyegképet) nyeri ki, nem pedig egy a videóból generált keretet.

**How can I determine which shapes use a specific image from the presentation image collection?**

Az Aspose.Slides nem tárol visszafele mutató hivatkozásokat a [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/) és az alakzatok között. A bejárás során építsen fel egy leképezést: amikor egy képreferenciát talál, jegyezze fel a dia számát, az alakzat útvonalát és a kép hash‑ét vagy a gyűjtemény elemét.

**Can I extract images embedded inside OLE objects, such as attached documents?**

Kivonhatja az OLE objektum dia‑előnézetét a [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ioleobjectframe/#getSubstitutePictureFormat--) segítségével. Azonban ez az előnézet nem maga a beágyazott dokumentum. A beágyazott fájlból származó képek kinyeréséhez exportálja az OLE adatot, majd megfelelő eszközökkel vizsgálja meg azt.