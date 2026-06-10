---
title: Képek kinyerése a prezentáció alakzataiból Androidon Java használatával
linktitle: Kép az alakzatról
type: docs
weight: 100
url: /hu/androidjava/extracting-images-from-presentation-shapes/
keywords:
- kép kinyerése
- kép lekérése
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Képek kinyerése a PowerPoint és OpenDocument prezentációk alakzataiból az Aspose.Slides for Android Java használatával – gyors, kódközpontú megoldás."
---
## **Áttekintés**

A prezentációban lévő képek többféle alakzat típusban jelenhetnek meg: egyszerű képkockaként, alakzatokra alkalmazott képtöltésként, OLE-objektum előnézeti képeként, videó- vagy audio keret bélyegképeként, nagyítási képként, vagy táblázat, diagram és SmartArt alakzatokba ágyazott képeként. Az Aspose.Slides ezeket a képeket a prezentáció képgyűjteményében tárolja, amelyet az [IImageCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagecollection/) és az [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) objektumok biztosítanak.

Ha csak a prezentációba beágyazott minden képeszközt szeretné exportálni, akkor iteráljon a `presentation.getImages()` felett. Ez a cikk egy másik feladatra összpontosít: az alakzatok bejárása annak megállapításához, hogy hol használnak képeket a diákon, így a mentett fájlok hasznos kontextust is megőrizhetnek, például a dia számát, az alakzat pozícióját és a forrástípust (képkocka, kitöltő kép, média előnézet, OLE előnézet vagy nagyítási kép).

{{% alert title="Tip" color="primary" %}}
Használja az [IPPImage.getBinaryData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/#getBinaryData--) metódust az eredeti kódolt képadatok és fájltípus megőrzéséhez. Használja az [IPPImage.getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/#getImage--) metódust az [IImage.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-)‑vel, ha a kimenetet egy adott formátumra, például PNG‑re szeretné normalizálni.
{{% /alert %}}

## **Megosztott segédmetódusok**

Az alábbi segédmetódusok rövidítik a példákat. A `saveOriginalImage` az eredeti beágyazott bájtokat írja, a MIME‑típusból biztonságos kiterjesztést választ, és az SHA‑256 hash alapján kihagyja a duplikált képbiteket.

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

## **Képek kinyerése képkockákból**

Használja ezt a megközelítést a önálló objektumként beszúrt képekhez. Az [IPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/) a képet a `getPictureFormat().getPicture().getImage()` metódusban tárolja, amely egy [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) objektumot ad vissza.

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

## **Képek kinyerése képpel kitöltött alakzatokból**

Az alakzatok képet használhatnak kitöltésként. Először ellenőrizze az alakzat kitöltési típusát: ha nem [FillType.Picture](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/), akkor nincs kép, amelyet ebből a kitöltésből ki lehetne nyerni. Az alábbi példa a [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) objektumokat kezeli, és minden képet PNG‑ként ment az [IPPImage.getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/#getImage--) segítségével.

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

## **Előnézeti képek kinyerése OLE objektum keretekből**

Egy [IOleObjectFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ioleobjectframe/) helyettesítő képet tartalmazhat, amelyet a PowerPoint az objektum előnézeteként használ a dián. Ez a kép a `getSubstitutePictureFormat().getPicture().getImage()` metóduson keresztül érhető el. Ennek a képnek a kinyerése az előnézeti képet adja, nem az beágyazott OLE csomag tartalmát.

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

## **Előnézeti képek kinyerése videó keretekből**

Egy [IVideoFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/) szintén tárolhat előnézeti képet a `getPictureFormat().getPicture().getImage()` metódusban. Ez a poszter vagy bélyegkép, amely a dián jelenik meg, nem a videófolyamból dekódolt keret.

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

## **Előnézeti képek kinyerése audio keretekből**

Egy [IAudioFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iaudioframe/) tárolhat bélyegképet a `getPictureFormat().getPicture().getImage()` metódusban. Ez a kép jelenik meg az audio objektumnál a dián.

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

## **Képek kinyerése zoom objektumokból**

Az [IZoomFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/izoomframe/) és a [ISectionZoomFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isectionzoomframe/) alakzatok egyéni képeket használhatnak. Olvassa a `getZoomImage()` metódust a zoom keretből.

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

## **Képek kinyerése összegző zoom keretekből**

Az [ISummaryZoomFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isummaryzoomframe/) szintén egy alakzat. Szakaszelemei egyéni képeket használhatnak, amelyeket az egyes összegző zoom szakaszok `getZoomImage()` metódusa ad hozzá.

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

## **Képek kinyerése táblázat alakzatokból**

Egy [ITable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itable/) egy alakzat. A táblázatban lévő képek általában képpel kitöltött táblázatcellákban tárolódnak.

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

## **Képek kinyerése diagram alakzatokból**

Egy [IChart](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichart/) egy alakzat. Az alábbi példa egy képet nyer ki a diagram területének képpel kitöltéséből.

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

## **Képek kinyerése SmartArt alakzatokból**

Egy [ISmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ismartart/) objektum egy alakzat. A SmartArt elrendezésétől függően a képek a csomópont golyó kitöltésében vagy a csomópont alakzatok kitöltési formátumaiban tárolódhatnak.

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

## **Képek belefoglalása csoportosított alakzatokba**

A csoportosított alakzatok saját alakzategyüttesekkel rendelkeznek. A megosztott `enumerateShapes` segédnek van egy `includeGroupedShapes` beállítása. Állítsa `true`‑ra, ha a [IGroupShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/igroupshape/) objektumokon belüli alakzatokat szeretné ellenőrizni. Az alábbi példa képeket nyer ki képkockákból, képpel kitöltött alakzatokból, OLE objektum előnézetekből, videó keret bélyegképekből és audio keret bélyegképekből. A táblázat, diagram, SmartArt és összegző zoom képek belefoglalásához használja újra az előző szakaszokban bemutatott speciális kinyerési logikát, miközben megtartja ugyanazt a rekurzív alakzat bejárást.

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

## **Szélhelyzetek és gyakorlati megjegyzések**

- **Duplicate images:** Több alakzat hivatkozhat ugyanarra a képre vagy különálló képekre azonos bájtokkal. Hash‑eljük a [IPPImage.getBinaryData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/#getBinaryData--) metódust, mielőtt fájlokat írnánk, ha egy kimeneti fájlt szeretnénk minden egyedi képhez.
- **Original data vs. converted output:** Az [IPPImage.getBinaryData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/#getBinaryData--) mentése megőrzi a beágyazott JPEG, PNG, GIF, SVG, EMF vagy WMF adatokat. Az [IPPImage.getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/#getImage--) mentése az [IImage.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) segítségével akkor hasznos, ha konzisztens kimeneti formátumra, például PNG‑re van szükség.
- **Unsupported fill types:** A szilárd, színátmenetes, mintás és üres kitöltésű alakzatok nem tartalmaznak képpót kitöltést. Ellenőrizze a [FillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/) előtt, hogy ne olvassa a `getPictureFillFormat()`‑ot.
- **Grouped shapes:** A felső szintű dia alakzategyűjtemény nem laposítja a csoportokat. Rekurzívan ellenőrizze a [IGroupShape.getShapes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/igroupshape/#getShapes--) metódust, ha a csoportos tartalom számít.
- **OLE object previews:** Egy [IOleObjectFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ioleobjectframe/) előnézeti képet adhat a `getSubstitutePictureFormat()`‑on keresztül, de ez csak a dia előnézet. Nem az OLE objektum beágyazott fájlja.
- **Video frame thumbnails:** Egy [IVideoFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/) előnézeti képet adhat a `getPictureFormat()`‑on keresztül, de ez csak a dián megjelenő poszter. Nem a videó folyamából nyert keret.
- **Audio frame thumbnails:** Egy [IAudioFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iaudioframe/) ikon vagy bélyegkép adhat a `getPictureFormat()`‑en keresztül; ez nem a beágyazott audio adat.
- **Zoom images:** Dia zoom, szekció zoom és összegző zoom alakzatok egyéni [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) objektumokat használhatnak a `getZoomImage()`‑en keresztül.
- **Nested shape models:** A táblázat, diagram és SmartArt objektumok az [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) implementálják, de képeik gyakran beágyazott táblázatcellában, diagram elemben vagy SmartArt csomópont formázási objektumban tárolódnak.
- **Cropped or transformed pictures:** Az [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) elérése a tárolt képeszközt adja. Nem jeleníti meg a vágást, átlátszóságot, újraszínezést, forgatást vagy egyéb vizuális hatásokat, amelyeket az alakzat alkalmaz.

## **FAQ**

**Can I extract the original image without cropping, effects, or shape transformations?**  
Igen. Hozzáfér a [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) objektumhoz, és a [IPPImage.getBinaryData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/#getBinaryData--)‑t írja lemezre. Ez megőrzi a prezentációban tárolt eredeti kódolt képet, nem pedig azt, ahogy a kép a dián megjelenik.

**Can I export every extracted image as PNG?**  
Igen. Használja az [IPPImage.getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/#getImage--)‑t egy [IImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/) objektum megszerzéséhez, majd hívja meg az [IImage.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-)‑t a [ImageFormat.Png](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imageformat/)‑szel. Ez a kimenetet PNG‑re konvertálja, és előfordulhat, hogy nem őrzi meg az eredeti fájltípust vagy vektor adatot.

**How do I avoid saving the same image more than once?**  
Használjon hash‑t az [IPPImage.getBinaryData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/#getBinaryData--)‑ről, és tárolja a hash‑eket egy halmazban. Ha egy új kép hash‑e már létezik, hagyja ki, vagy jegyezze fel, hogy ugyanarra a kimeneti fájlra mutat.

**Why do some shapes not produce an image?**  
Képkockák, képpel kitöltött alakzatok, OLE objektum keretek, média keretek, zoom keretek, táblázatok, diagramok és SmartArt objektumok hivatkozhatnak képekre. Néhány alakzat típus képeket rejtett formázó objektumokon keresztül tesz elérhetővé, ezért egy egyszerű `getPictureFormat()` vagy `getFillFormat()` ellenőrzés nem mindig elegendő.

**Can I extract the thumbnail shown for a video frame?**  
Igen. Használja a [IVideoFrame.getPictureFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/#getPictureFormat--)‑t, és olvassa a `getPictureFormat().getPicture().getImage()`‑t. Ez a videó kerethez tárolt poszterképet nyeri ki, nem egy a videófájlból generált keretet.

**How can I determine which shapes use a specific image from the presentation image collection?**  
Az Aspose.Slides nem tárol visszaható hivatkozásokat az [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) és az alakzatok között. Építsen fel egy leképezést a bejárás során: minden képhivatkozás megtalálásakor rögzítse a dia számát, az alakzat útvonalát és a kép hash‑ét vagy gyűjteménybeli indexét.

**Can I extract images embedded inside OLE objects, such as attached documents?**  
Kivonhatja az OLE objektum dia előnézetét a [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--)‑en keresztül. Azonban ez az előnézet nem a beágyazott dokumentum maga. A beágyazott fájlban lévő képek kinyeréséhez először ki kell nyerni az OLE adatot, majd a megfelelő eszközökkel elemezni a fájltípus tartalmát.