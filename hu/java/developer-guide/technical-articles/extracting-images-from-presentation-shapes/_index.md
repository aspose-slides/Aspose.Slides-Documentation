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
description: "Képek kinyerése a PowerPoint és OpenDocument prezentációk alakzataiból az Aspose.Slides for Java segítségével – gyors, kódbarát megoldás."
---
## **Áttekintés**

A prezentációban lévő képek többféle alakú formában jelenhetnek meg: egyszerű képkeretekként, alakzatok képpel kitöltöttként, OLE objektum előnézeti képekként, videó‑ vagy hangsáv‑keret bélyegképeként, nagyítási képként, vagy táblázat, diagram és SmartArt alakzatokba ágyazott képként. Az Aspose.Slides ezeket a képeket a prezentáció képgyűjteményében tárolja, amely a [IImageCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides.iimagecollection/) és az [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/) objektumokon keresztül érhető el.

Ha csak a prezentációba beágyazott minden képernyőforrást szeretnéd exportálni, akkor a `presentation.getImages()`‑t kell végigjárnod. Ez a cikk egy másik feladatra fókuszál: az alakzatok bejárására, hogy megtaláljuk, hol használják a képeket a diákkban, így a mentett fájlok megőrizhetik a hasznos kontextust, például a dia számát, az alakzat pozícióját és a forrástípust (képkeret, kitöltő kép, média‑előnézet, OLE‑előnézet vagy nagyítási kép).

{{% alert title="Tip" color="info" %}}
Használd az [IPPImage.getBinaryData](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/#getBinaryData--) metódust az eredeti kódolt képadatok és fájltípus megőrzéséhez. Használd az [IPPImage.getImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/#getImage--)‑t a [IImage.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides.iimage/#save-java.lang.String-int-)‑val, ha a kimenetet egy meghatározott formátumra (például PNG) szeretnéd normalizálni.
{{% /alert %}}

## **Közös Segédfüggvények**

Az alábbi segédfüggvények röviden tartják a példákat. A `saveOriginalImage` az eredeti beágyazott bájtokat írja ki, a MIME‑típusból biztonságos kiterjesztést választ, és a SHA‑256 hash alapján kihagyja az ismétlődő képbinarisokat.

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

## **Képek kinyerése képkeretekből**

Ezt a megközelítést használjuk, ha a képeket önálló objektumként illesztették be. Egy [IPictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ipictureframe/) a képét a `getPictureFormat().getPicture().getImage()`‑en keresztül tárolja, amely egy [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/) objektumot ad vissza.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.Set;
import java.util.List;

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

Az alakzatok képet használhatnak kitöltésként. Először ellenőrizd az alakzat kitöltéstípusát: ha nem [FillType.Picture](https://reference.aspose.com/slides/hu/java/com.aspose.slides.filltype/), nincs kinyerhető kép a kitöltésből. Az alábbi példa a [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides.iautoshape/) objektumokat kezeli, és minden képet PNG‑ként ment az [IPPImage.getImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/#getImage--) használatával.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;

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

## **Előnézeti képek kinyerése OLE objektumkeretekből**

Egy [IOleObjectFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ioleobjectframe/) helyettesítő képet tartalmazhat, amelyet a PowerPoint az objektum előnézeti képeként használ a dián. Ez a kép a `getSubstitutePictureFormat().getPicture().getImage()`‑en keresztül érhető el. A kép kinyerése csak az előnézeti képet adja, nem az OLE‑csomag beágyazott tartalmát.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.Set;
import java.util.List;

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

## **Előnézeti képek kinyerése videókeretekből**

Egy [IVideoFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ivideoframe/) szintén tárolhat előnézeti képet a `getPictureFormat().getPicture().getImage()`‑en keresztül. Ez a poszter vagy bélyegkép, amely a dián látható, nem a videófolyamból dekódolt képkocka.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.Set;
import java.util.List;

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

## **Előnézeti képek kinyerése hangsáv‑keretekből**

Egy [IAudioFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides.iaudioframe/) tárolhat bélyegképet a `getPictureFormat().getPicture().getImage()`‑en keresztül. Ez a kép a hangobjektushoz tartozó dián megjelenő ikon.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.Set;
import java.util.List;

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

## **Képek kinyerése nagyítási objektumokból**

[IZoomFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides.izoomframe/) és [ISectionZoomFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides.isectionzoomframe/) alakzatok használhatnak egyéni képeket. Olvasd a `getZoomImage()`‑t a nagyítási keretből.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.Set;
import java.util.List;

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

## **Képek kinyerése összefoglaló nagyítási keretekből**

Egy [ISummaryZoomFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides.isummaryzoomframe/) szintén alakzat. Szekcióelemei egyéni képeket használhatnak, amelyeket az egyes összefoglaló nagyítási szekció `getZoomImage()` metódusa ad vissza.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.Set;
import java.util.List;

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

## **Képek kinyerése táblázat‑alakzatokból**

Egy [ITable](https://reference.aspose.com/slides/hu/java/com.aspose.slides.itable/) alakzat. A táblázatokban lévő képek általában a táblacellák kép‑kitöltéseiben tárolódnak.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.Set;
import java.util.List;

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

## **Képek kinyerése diagram‑alakzatokból**

Egy [IChart](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ichart/) alakzat. Az alábbi példa a diagram területének képpel kitöltéséből nyeri ki a képet.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.Set;
import java.util.List;

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

## **Képek kinyerése SmartArt‑alakzatokból**

Egy [ISmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ismartart/) objektum alakzat. A SmartArt elrendezésétől függően a képek a csomópont golyó‑kitöltésében vagy a csomópont alakzatok kitöltési formátumaiban tárolódhatnak.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.Set;
import java.util.List;

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

A csoportosított alakzatok saját alakzategységgel rendelkeznek. A megosztott `enumerateShapes` segédfüggvénynek van egy `includeGroupedShapes` opciója. Állítsd `true`‑ra, ha a [IGroupShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides.igroupshape/) objektumok belsejében lévő alakzatokat is vizsgálni szeretnéd. Az alábbi példa képeket nyer ki képkeretekből, képpel kitöltött alakzatokból, OLE‑objektum előnézetekből, videó‑keret bélyegképekből és audio‑keret bélyegképekből. A táblázat, diagram, SmartArt és összefoglaló nagyítási képek bevonásához használj újra a korábbi szakaszok speciális kinyerési logikáját, miközben ugyanazt a rekurzív alakzat‑traverszt használod.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.Set;
import java.util.List;

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

## **Speciális esetek és gyakorlati megjegyzések**

- **Ismétlődő képek:** Több alakzat hivatkozhat ugyanarra a képre vagy azonos bájtokkal rendelkező külön képekre. Használd a [IPPImage.getBinaryData](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/#getBinaryData--) hash‑elését a fájlok írása előtt, ha egy kimeneti fájlt szeretnél minden egyedi képhez.
- **Eredeti adatok vs. konvertált kimenet:** A [IPPImage.getBinaryData](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/#getBinaryData--) mentése megőrzi a beágyazott JPEG, PNG, GIF, SVG, EMF vagy WMF adatot. A [IPPImage.getImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/#getImage--) mentése a [IImage.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides.iimage/#save-java.lang.String-int-)‑val akkor hasznos, ha egységes kimeneti formátumra (például PNG) van szükséged.
- **Nem támogatott kitöltéstípusok:** Szilárd, fokozatos, mintázatos és nincs‑kitöltésű alakzatok nem tartalmaznak képi kitöltést. Ellenőrizd a [FillType](https://reference.aspose.com/slides/hu/java/com.aspose.slides.filltype/)‑t, mielőtt a `getPictureFillFormat()`‑ot hívnád.
- **Csoportosított alakzatok:** A felső szintű dia‑alakzatgyűjtemény nem laposítja a csoportokat. Rekurzívan vizsgáld meg a [IGroupShape.getShapes](https://reference.aspose.com/slides/hu/java/com.aspose.slides.igroupshape/#getShapes--)‑t, ha a csoportos tartalom számít.
- **OLE‑objektum előnézetek:** Egy [IOleObjectFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ioleobjectframe/) a `getSubstitutePictureFormat()`‑on keresztül előnézeti képet adhat, de ez csak a dia‑előnézet. Nem az OLE‑objektumban beágyazott fájl.
- **Videó‑keret bélyegképek:** Egy [IVideoFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ivideoframe/) a `getPictureFormat()`‑on keresztül előnézeti képet adhat, de ez csak a dián megjelenő poszter, nem a videófolyamból kinyert kép.
- **Audio‑keret bélyegképek:** Egy [IAudioFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides.iaudioframe/) ikon vagy bélyegkép a `getPictureFormat()`‑on keresztül, de ez nem a beágyazott audio adat.
- **Nagyítási képek:** Dia‑nagyítás, szekció‑nagyítás és összefoglaló nagyítás alakzatok egyéni [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/) objektumokat használhatnak a `getZoomImage()`‑en keresztül.
- **Beágyazott alakzati modellek:** A táblázat, diagram és SmartArt objektumok [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ishape/)‑t valósítanak meg, de képeik gyakran beágyazott táblacellák, diagram‑elemek vagy SmartArt‑csomópont formázási objektumokban tárolódnak.
- **Levágott vagy átalakított képek:** Az [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/) elérése csak a tárolt képernyőforrást adja vissza. Nem jeleníti meg a vágást, áttetszőséget, átszínezést, forgatást vagy egyéb vizuális effekteket, amelyeket az alakzat alkalmaz.

## **GYIK**

### Kivonhatom az eredeti képet vágás, effektus vagy alakzatrajzolás nélkül?

Igen. Hozzáférhetsz az [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/) objektumhoz, és a [IPPImage.getBinaryData](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/#getBinaryData--)‑t leírhatod lemezre. Ez megőrzi a prezentációban tárolt eredeti kódolt képet, nem azt, ahogyan a kép a dián megjelenik.

### Exportálhatom az összes kinyert képet PNG‑ként?

Igen. Használd az [IPPImage.getImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/#getImage--)‑t egy [IImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides.iimage/) objektum beszerzéséhez, majd hívd a [IImage.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides.iimage/#save-java.lang.String-int-)‑t a [ImageFormat.Png](https://reference.aspose.com/slides/hu/java/com.aspose.slides.imageformat/)‑al. Ez konvertálja a kimenetet, és előfordulhat, hogy nem őrzi meg az eredeti fájltípust vagy vektoradatot.

### Hogyan kerülhetem el ugyanannak a képnek a többszöri mentését?

Használj hash‑t a [IPPImage.getBinaryData](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/#getBinaryData--)‑ből, és tartsd a hasheket egy halmazban. Ha egy új kép hash‑e már létezik, hagyd ki, vagy rögzíts egy további hivatkozást a már létező kimeneti fájlra.

### Miért nem ad ki képet egyes alakzatok?

Képkeretek, képpel kitöltött alakzatok, OLE‑objektum keretek, média‑keretek, nagyítási keretek, táblázatok, diagramok és SmartArt objektumok hivatkozhatnak képekre. Néhány alakzat típus képeket rejtett formázási objektumokon keresztül tesz elérhetővé, ezért egy egyszerű `getPictureFormat()` vagy `getFillFormat()` ellenőrzés nem mindig elegendő.

### Kinyerhetem a videókerethez tartozó bélyegképet?

Igen. Használj [IVideoFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ivideoframe/)-t, és olvasd a `getPictureFormat().getPicture().getImage()`‑t. Ez a videókerettel együtt tárolt poszterképet adja vissza, nem a videófájlból generált képkockát.

### Hogyan határozhatom meg, hogy melyik alakzat használja a prezentáció képgyűjteményének egy adott képét?

Az Aspose.Slides nem tárol visszafelé mutató hivatkozásokat az [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ippimage/) és az alakzatok között. A bejárás során építs fel egy leképezést: amikor képhivatkozást találsz, rögzítsd a dia számát, az alakzat útvonalát és a kép hash‑ét vagy gyűjtemény‑elemet.

### Kinyerhetek beágyazott képeket OLE‑objektumokból, például csatolt dokumentumokból?

Kinyerheted az OLE‑objektum dia‑előnézetét a [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides.ioleobjectframe/#getSubstitutePictureFormat--)‑en keresztül. Azonban ez az előnézet nem maga a beágyazott dokumentum. Az OLE‑objektumban lévő fájl képeinek kinyeréséhez először ki kell nyerni magát az OLE‑adatot, majd a megfelelő eszközökkel elemezni azt.