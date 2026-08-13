---
title: Afbeeldingen extraheren uit presentatie‑vormen in Android via Java
linktitle: Afbeelding van vorm
type: docs
weight: 100
url: /nl/androidjava/extracting-images-from-presentation-shapes/
keywords:
- afbeelding extraheren
- afbeelding ophalen
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Afbeeldingen extraheren uit vormen in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor Android via Java – snelle, code‑vriendelijke oplossing."
---
## **Overzicht**

Afbeeldingen in een presentatie kunnen in verschillende vormtypen voorkomen: als gewone afbeeldingframes, als afbeeldingvullingen die op vormen worden toegepast, als OLE‑objectvoorbeeldafbeeldingen, als miniatuurafbeeldingen van video‑ of audio‑frames, als zoom‑afbeeldingen, of als afbeeldingen die genest zijn in tabel‑, diagram‑ en SmartArt‑vormen. Aspose.Slides slaat die afbeeldingen op in de presentatie‑afbeeldingscollectie, toegankelijk via [IImageCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimagecollection/) en [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/) objecten.

Als u alleen elke in een presentatie ingebedde afbeeldingsbron wilt exporteren, iterate dan over `presentation.getImages()`. Dit artikel richt zich op een andere taak: vormen doorlopen om te ontdekken waar afbeeldingen worden gebruikt op dia's, zodat de opgeslagen bestanden nuttige context kunnen behouden zoals het slidennummer, de vormpositie en het bron‑type (afbeeldingsframe, vulafbeelding, mediavoorbeeld, OLE‑voorbeeld of zoom‑afbeelding).

{{% alert title="Tip" color="info" %}}
Gebruik [IPPImage.getBinaryData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/#getBinaryData--) om de oorspronkelijk gecodeerde afbeeldingsdata en bestands­type te behouden. Gebruik [IPPImage.getImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/#getImage--) samen met [IImage.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) wanneer u de uitvoer wilt normaliseren naar een specifiek formaat zoals PNG.
{{% /alert %}}

## **Gedeelde Helper‑methoden**

De hulpmethoden hieronder houden de voorbeelden kort. `saveOriginalImage` schrijft de oorspronkelijke ingebedde bytes, kiest een veilige extensie op basis van het MIME‑type, en slaat dubbele afbeeldings‑binaire bestanden over op basis van een SHA‑256‑hash.

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

## **Afbeeldingen extraheren uit afbeeldingsframes**

Gebruik deze aanpak voor afbeeldingen die als zelfstandige objecten zijn ingevoegd. Een [IPictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipictureframe/) slaat zijn afbeelding op in `getPictureFormat().getPicture().getImage()`, wat een [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/) object teruggeeft. Merk op dat [IVideoFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/) en [IAudioFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iaudioframe/) afstammen van [IPictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipictureframe/), dus deze `instanceof`‑controle treft ook mediaframes en exporteert hun voorbeeld‑afbeeldingen; test eerst op die types wanneer u ze apart wilt behandelen, zoals het laatste voorbeeld op deze pagina doet.

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

## **Afbeeldingen extraheren uit met afbeelding gevulde vormen**

Vormen kunnen een afbeelding als vulling gebruiken. Controleer eerst het vultype van de vorm: als het niet [FillType.Picture](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/filltype/) is, is er geen afbeelding om uit die vulling te halen. Het voorbeeld hieronder behandelt [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) objecten en slaat elke afbeelding op als PNG via [IPPImage.getImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/#getImage--).

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

## **Voorbeeld‑afbeeldingen extraheren uit OLE‑objectframes**

Een [IOleObjectFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ioleobjectframe/) kan een vervangende afbeelding hebben die PowerPoint gebruikt als het voorbeeld van het object op een dia. Deze afbeelding is beschikbaar via `getSubstitutePictureFormat().getPicture().getImage()`. Het extraheren van deze afbeelding levert de voorbeeld‑afbeelding, niet de ingebedde OLE‑pakketinhoud.

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

## **Voorbeeld‑afbeeldingen extraheren uit videoframes**

Een [IVideoFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/) kan ook een voorbeeldafbeelding opslaan in `getPictureFormat().getPicture().getImage()`. Dit is de poster‑ of miniatuurafbeelding die op de dia wordt getoond, niet een frame dat uit de videostroom is gedecodeerd.

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

## **Voorbeeld‑afbeeldingen extraheren uit audio‑frames**

Een [IAudioFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iaudioframe/) kan een miniatuur opslaan in `getPictureFormat().getPicture().getImage()`. Dit is de afbeelding die wordt getoond voor het audio‑object op de dia.

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

## **Afbeeldingen extraheren uit zoom‑objecten**

[IZoomFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/izoomframe/) en [ISectionZoomFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isectionzoomframe/) vormen kunnen aangepaste afbeeldingen gebruiken. Lees `getZoomImage()` van het zoom‑frame.

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

## **Afbeeldingen extraheren uit samenvattings‑zoom‑frames**

Een [ISummaryZoomFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isummaryzoomframe/) is ook een vorm. De sectie‑items kunnen aangepaste afbeeldingen gebruiken, toegankelijk via de `getZoomImage()`‑methode van elk samenvattings‑zoom‑segment.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util Set;

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

## **Afbeeldingen extraheren uit tabel‑vormen**

Een [ITable](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itable/) is een vorm. Afbeeldingen in een tabel worden meestal opgeslagen als afbeeldingvullingen in tabelcellen.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util Set;

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

## **Afbeeldingen extraheren uit diagram‑vormen**

Een [IChart](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichart/) is een vorm. Het voorbeeld hieronder haalt een afbeelding uit de afbeeldingvulling van het diagramgebied.

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

## **Afbeeldingen extraheren uit SmartArt‑vormen**

Een [ISmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ismartart/) object is een vorm. Afhankelijk van de SmartArt‑indeling kunnen afbeeldingen worden opgeslagen in opsommingsteken‑vullingen van knooppunten of in de vulformaten van knooppunt‑vormen.

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

## **Afbeeldingen opnemen in gegroepeerde vormen**

Gegroepeerde vormen bevatten hun eigen vormcollecties. De gedeelde helper `enumerateShapes` heeft een `includeGroupedShapes`‑optie. Zet deze op `true` wanneer u vormen binnen [IGroupShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/igroupshape/) objecten wilt inspecteren. Het voorbeeld hieronder extraheert afbeeldingen uit afbeelding‑frames, met afbeelding gevulde vormen, OLE‑objectvoorbeelden, videoframe‑miniaturen en audio‑frame‑miniaturen. Om ook tabel‑, diagram‑, SmartArt‑ en samenvattings‑zoom‑afbeeldingen op te nemen, hergebruik de gespecialiseerde extractielogica uit de voorgaande secties terwijl u dezelfde recursieve vorm‑traversal behoudt.

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

## **Randgevallen en praktische aantekeningen**

- **Dubbele afbeeldingen:** Meerdere vormen kunnen naar dezelfde afbeelding verwijzen of naar verschillende afbeeldingen met identieke bytes. Hash [IPPImage.getBinaryData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/#getBinaryData--) vóór het schrijven van bestanden als u één uitvoerbestand per unieke afbeelding wilt.
- **Originele data vs. geconverteerde uitvoer:** Het opslaan van [IPPImage.getBinaryData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/#getBinaryData--) behoudt de ingebedde JPEG, PNG, GIF, SVG, EMF of WMF data. Het opslaan van [IPPImage.getImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/#getImage--) via [IImage.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) is nuttig wanneer u een consistent uitvoerformaat wilt.
- **Niet‑ondersteunde vultypes:** Effen, gradient, patroon en geen‑vulling vormen bevatten geen afbeeldingvulling. Controleer [FillType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/filltype/) vóór het lezen van `getPictureFillFormat()`.
- **Gegroepeerde vormen:** De bovenliggende dia‑vormcollectie maakt geen platte weergave van groepen. Inspecteer recursief [IGroupShape.getShapes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/igroupshape/#getShapes--) wanneer gegroepeerde inhoud van belang is.
- **OLE‑objectvoorbeelden:** Een [IOleObjectFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ioleobjectframe/) kan een voorbeeldafbeelding blootleggen via `getSubstitutePictureFormat()`, maar die afbeelding is slechts het dia‑voorbeeld. Het is niet het ingebedde bestand binnen het OLE‑object.
- **Videoframe‑miniaturen:** Een [IVideoFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/) kan een voorbeeldafbeelding blootleggen via `getPictureFormat()`, maar die afbeelding is enkel de poster die op de dia wordt getoond. Het wordt niet uit de videostroom gehaald.
- **Audio‑frame‑miniaturen:** Een [IAudioFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iaudioframe/) kan een pictogram of miniatuur blootleggen via `getPictureFormat()`; het is niet de ingebedde audio‑data.
- **Zoom‑afbeeldingen:** Slide‑zoom, sectie‑zoom en samenvattings‑zoom vormen kunnen aangepaste [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/) objecten gebruiken via `getZoomImage()`.
- **Geneste vormmodellen:** Tabel‑, diagram‑ en SmartArt‑objecten implementeren [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/), maar hun afbeeldingen worden vaak opgeslagen in geneste tabelcel‑, diagram‑element‑ of SmartArt‑knooppunt‑opmaakobjecten.
- **Bijsneden of getransformeerde afbeeldingen:** Toegang tot [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/) levert de opgeslagen afbeeldingsresource. Het rendert geen bijsnijden, transparantie, herkleuring, rotatie of andere visuele effecten die door de vorm zijn toegepast.

## **FAQ**

### Kan ik de originele afbeelding extraheren zonder bijsnijden, effecten of vorm‑transformaties?

Ja. Benader het [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/) object en schrijf [IPPImage.getBinaryData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/#getBinaryData--) naar schijf. Dit behoudt de oorspronkelijk gecodeerde afbeelding die in de presentatie is opgeslagen, niet de manier waarop de afbeelding op de dia wordt weergegeven.

### Kan ik elke geëxtraheerde afbeelding exporteren als PNG?

Ja. Gebruik [IPPImage.getImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/#getImage--) om een [IImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/) object te krijgen, en roep vervolgens [IImage.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) aan met [ImageFormat.Png](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imageformat/). Dit converteert de uitvoer en kan het oorspronkelijke bestandstype of vector‑data niet behouden.

### Hoe vermijd ik dat dezelfde afbeelding meer dan één keer wordt opgeslagen?

Gebruik een hash van [IPPImage.getBinaryData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/#getBinaryData--) en bewaar de hashes in een set. Als een nieuwe afbeelding een hash heeft die al bestaat, sla deze dan over of registreer een andere verwijzing naar het bestaande uitvoerbestand.

### Waarom produceren sommige vormen geen afbeelding?

Afbeeldingsframes, met afbeelding gevulde vormen, OLE‑objectframes, mediaframes, zoom‑frames, tabellen, diagrammen en SmartArt‑objecten kunnen naar afbeeldingen verwijzen. Sommige vormtypes leggen afbeeldingen bloot via geneste opmaakobjecten, dus een eenvoudige `getPictureFormat()` of `getFillFormat()` controle is niet altijd voldoende.

### Kan ik de miniatuur die wordt getoond voor een videoframe extraheren?

Ja. Gebruik [IVideoFrame.getPictureFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/#getPictureFormat--) en lees `getPictureFormat().getPicture().getImage()`. Dit extrahert de poster‑afbeelding die bij het videoframe is opgeslagen, niet een frame dat uit het videobestand is gegenereerd.

### Hoe kan ik bepalen welke vormen een specifieke afbeelding uit de presentatie‑afbeeldingscollectie gebruiken?

Aspose.Slides slaat geen omgekeerde koppelingen op van [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/) naar vormen. Bouw tijdens de traversie een mapping op: telkens wanneer u een afbeeldingsreferentie vindt, noteer het slidennummer, het vormpad en de afbeeldings‑hash of collectie‑item.

### Kan ik afbeeldingen extraheren die zijn ingebed in OLE‑objecten, zoals bijgevoegde documenten?

U kunt het voorbeeld van het OLE‑object op de dia extraheren via [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--). Echter, dat voorbeeld is niet het ingebedde document zelf. Om afbeeldingen uit het ingebedde bestand te extraheren, moet u de OLE‑data extraheren en deze met tools voor dat bestandstype onderzoeken.