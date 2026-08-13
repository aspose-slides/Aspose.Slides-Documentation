---
title: Képek kinyerése a prezentáció alakzataiból Androidon Java segítségével
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
description: "Képek kinyerése alakzatokból PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Android Java használatával – gyors, kódközpontú megoldás."
---
## **Áttekintés**

A prezentációban a képek többféle alakzattípusban jelenhetnek meg: egyszerű képkeretekként, alakzatokra alkalmazott képpel kitöltésekként, OLE‑objektum előnézeti képeként, videó‑ vagy hangkeret bélyegképeként, nagyítási képként, vagy a táblázat, diagram és SmartArt alakzatokba ágyazott képekként. Az Aspose.Slides ezeket a képeket a prezentáció képgyűjteményében tárolja, amelyet a [IImageCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagecollection/) és a [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) objektumok biztosítanak.

Ha csak minden a prezentációba beágyazott képernyöforrást szeretnéd exportálni, iterálj a `presentation.getImages()`-en. Ez a cikk egy másik feladatra összpontosít: átlépi a alakzatokat, hogy megtalálja, hol használják a képeket a diákon, így a mentett fájlok megőrzik a hasznos kontextust, például a dia számát, az alakzat pozícióját és a forrástípust (képkeret, kitöltő kép, média előnézet, OLE előnézet vagy nagyítási kép).

{{% alert title="Tip" color="info" %}}
Használd a [IPPImage.getBinaryData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/#getBinaryData--)‑t az eredeti kódolt képadatok és fájltípus megőrzéséhez. Használd a [IPPImage.getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/#getImage--)‑et a [IImage.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-)‑tel, ha a kimenetet egy meghatározott formátumba (például PNG) szeretnéd normalizálni.
{{% /alert %}}

## **Közös Segítő Metódusok**

Az alábbi segítő metódusok röviden tartják a példákat. A `saveOriginalImage` az eredeti beágyazott bájtokat írja, a MIME‑típus alapján biztonságos kiterjesztést választ, és az SHA‑256 hash alapján kihagyja a duplikált képbájtokat.

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

Ezt a megközelítést önálló objektumként beszúrt képekre használd. Az [IPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/) a képet a `getPictureFormat().getPicture().getImage()`‑ben tárolja, amely egy [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) objektust ad vissza. Vedd figyelembe, hogy az [IVideoFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/) és az [IAudioFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iaudioframe/) is az [IPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/)‑ből származik, ezért ez az `instanceof` ellenőrzés a média kereteket is megtalálja, és azok előnézeti képeit exportálja; előbb teszteld ezeket a típusokat, ha külön akarod kezelni őket, ahogy az oldal utolsó példája mutatja.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

Az alakzatok képet használhatnak kitöltésként. Először ellenőrizd az alakzat kitöltés típusát: ha nem [FillType.Picture](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/), akkor nincs kinyerhető kép a kitöltésből. Az alábbi példa a [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) objektusokat kezeli, és minden képet PNG‑ként ment a [IPPImage.getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/#getImage--)‑on keresztül.

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

Egy [IOleObjectFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ioleobjectframe/) rendelkezhet helyettesítő képpel, amelyet a PowerPoint az objektum előnézeteként használ a dián. Ez a kép a `getSubstitutePictureFormat().getPicture().getImage()`‑on keresztül érhető el. Ennek a képrészletnek a kinyerése az előnézeti képet adja, nem az OLE csomag beágyazott tartalmát.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

Egy [IVideoFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/) is tárolhat előnézeti képet a `getPictureFormat().getPicture().getImage()`‑ben. Ez a dián megjelenő poszter vagy bélyegkép, nem egy a videó áramlatból dekódolt keret.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

## **Előnézeti képek kinyerése hangkeretekből**

Egy [IAudioFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iaudioframe/) tárolhat bélyegképet a `getPictureFormat().getPicture().getImage()`‑ben. Ez a kép jelenik meg a hangobjektusnál a dián.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

[IZoomFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/izoomframe/) és [ISectionZoomFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isectionzoomframe/) alakzatok saját egyedi képeket használhatnak. Olvasd a `getZoomImage()`‑t a nagyítási kerettől.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

Egy [ISummaryZoomFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isummaryzoomframe/) szintén egy alakzat. A szekcióelemei egyedi képeket használhatnak, amelyeket az egyes összefoglaló nagyítási szekciók `getZoomImage()` metódusa ad vissza.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

Egy [ITable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itable/) alakzat. A táblázatban lévő képek általában képpel kitöltött cellákban tárolódnak.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

Egy [IChart](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichart/) alakzat. Az alábbi példa a diagram területének képpel kitöltéséből nyer ki egy képet.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util Set;

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

Egy [ISmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ismartart/) objektum alakzat. A SmartArt elrendezéstől függően a képek a csomópontok felsorolás kitöltésében vagy a csomópont alakzatok kitöltési formátumaiban tárolódhatnak.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util Set;

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

A csoportosított alakzatok saját alakzategységeket tartalmaznak. A közös `enumerateShapes` segítőben van egy `includeGroupedShapes` opció. Állítsd `true`‑ra, ha a [IGroupShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/igroupshape/) objektumokban lévő alakzatokat is vizsgálni szeretnéd. Az alábbi példa a képkeretekből, képpel kitöltött alakzatokból, OLE objektum előnézetekből, videókeret bélyegképekből és hangkeret bélyegképekből nyer ki képeket. A táblázat, diagram, SmartArt és összefoglaló nagyítási képek belefoglalásához használd újra a korábbi szakaszok speciális kinyerési logikáját, miközben ugyanazt a rekurzív alakzatátjárást tartod fenn.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util Set;

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

## **Különleges esetek és gyakorlati megjegyzések**

- **Duplikált képek:** Több alakzat is hivatkozhat ugyanarra a képre vagy különálló, azonos bájtokkal rendelkező képekre. Használd a [IPPImage.getBinaryData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/#getBinaryData--) hash‑ét a fájlok írása előtt, ha egy kimeneti fájlt szeretnél minden egyedi képhez.
- **Eredeti adat vs. konvertált kimenet:** A [IPPImage.getBinaryData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/#getBinaryData--) mentése megőrzi a beágyazott JPEG, PNG, GIF, SVG, EMF vagy WMF adatot. A [IPPImage.getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/#getImage--) mentése a [IImage.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-)‑en keresztül hasznos, ha egységes kimeneti formátumot szeretnél.
- **Nem támogatott kitöltés típusok:** Szilárd, színátmenetes, mintás és üres kitöltésű alakzatok nem tartalmaznak képpel kitöltést. Ellenőrizd a [FillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/)‑et a `getPictureFillFormat()` olvasása előtt.
- **Csoportosított alakzatok:** A felső szintű dia alakzategyűjtemény nem laposítja a csoportokat. Rekurzívan vizsgáld a [IGroupShape.getShapes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/igroupshape/#getShapes--)‑et, ha a csoportosított tartalom fontos.
- **OLE objektum előnézetek:** Egy [IOleObjectFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ioleobjectframe/) megjeleníthet egy előnézeti képet a `getSubstitutePictureFormat()`‑en keresztül, de ez a kép csak a diaszintű előnézetet jelenti. Nem a OLE objektumban beágyazott fájl.
- **Videókeret bélyegképek:** Egy [IVideoFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/) előnézeti képet mutathat a `getPictureFormat()`‑en keresztül, de ez a kép csak a dián megjelenő posztert jelenti. Nem a videó áramlatból kerül kinyerésre.
- **Hangkeret bélyegképek:** Egy [IAudioFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iaudioframe/) ikon vagy bélyegképet jeleníthet meg a `getPictureFormat()`‑en keresztül; ez nem a beágyazott hangadat.
- **Nagyítási képek:** Dia nagyítás, szekció nagyítás és összefoglaló nagyítás alakzatok saját egyedi [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) objektumokat használhatnak a `getZoomImage()`‑on keresztül.
- **Beágyazott alakzatszerkezetek:** A táblázat, diagram és SmartArt objektumok [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/)‑t valósítanak meg, de képeik gyakran beágyazott táblázatcellák, diagram elemek vagy SmartArt csomópont formázási objektumokban tárolódnak.
- **Vágott vagy átalakított képek:** A [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) elérése a tárolt kép erőforrást adja. Nem jeleníti meg a vágást, átlátszóságot, színátmenetet, elforgatást vagy az alakzat által alkalmazott egyéb vizuális effektusokat.

## **GYIK**

### Kinyerhetem az eredeti képet vágás, effektus vagy alakzatter: nélkül?

Igen. Hozzáférhetsz az [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) objektumhoz, és a [IPPImage.getBinaryData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/#getBinaryData--)‑t le tudod írni a lemezre. Ez megőrzi a prezentációban tárolt eredeti kódolt képet, nem pedig a dián megjelenített képet.

### Exportálhatom-e az összes kinyert képet PNG formátumban?

Igen. Használd a [IPPImage.getImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/#getImage--)‑et egy [IImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/) objektum lekéréséhez, majd hívd a [IImage.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-)‑t a [ImageFormat.Png](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imageformat/)‑val. Ez a kimenetet PNG‑re konvertálja, és előfordulhat, hogy nem őrzi meg az eredeti fájltípust vagy vektoradatot.

### Hogyan kerülhetem el, hogy ugyanazt a képet többször mentsük?

Használj hash‑t a [IPPImage.getBinaryData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/#getBinaryData--)‑ről, és tárold a hasheket egy halmazban. Ha egy új kép hash‑e már létezik, hagyd ki, vagy rögzíts egy másik hivatkozást a meglévő kimeneti fájlra.

### Miért nem adnak képet bizonyos alakzatok?

Képkeretek, képpel kitöltött alakzatok, OLE objektumkeretek, média keretek, nagyítási keretek, táblázatok, diagramok és SmartArt objektumok hivatkozhatnak képekre. Néhány alakzattípus beágyazott formázó objektumokon keresztül teszi elérhetővé a képeket, ezért egy egyszerű `getPictureFormat()` vagy alakzat `getFillFormat()` ellenőrzés nem mindig elegendő.

### Kinyerhető a videókerethez tartozó bélyegkép?

Igen. Használd a [IVideoFrame.getPictureFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivideoframe/#getPictureFormat--)‑t, és olvasd a `getPictureFormat().getPicture().getImage()`‑t. Ez kinyeri a videókerettel együtt tárolt poszterképet, nem egy a videófájlból generált keretet.

### Hogyan határozhatom meg, mely alakzatok használják a prezentáció képgyűjteményéből származó adott képet?

Az Aspose.Slides nem tárol visszautalásokat a [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) és az alakzatok között. Építs leképezést az áthaladás során: amikor egy kép hivatkozást találsz, rögzítsd a dia számát, az alakzat útvonalát és a kép hash‑ét vagy a gyűjtemény elemét.

### Kinyerhetek képeket OLE objektumokba ágyazva, például csatolt dokumentumokból?

Kivonhatod az OLE objektum dia előnézetét a [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--)‑ról. Azonban ez az előnézet nem maga a beágyazott dokumentum. A beágyazott fájlban található képek kivonásához először az OLE adatot kell kinyerni, majd a megfelelő fájltípusú eszközökkel elemezni.