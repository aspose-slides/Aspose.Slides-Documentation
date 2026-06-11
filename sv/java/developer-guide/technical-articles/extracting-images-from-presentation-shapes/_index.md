---
title: Extrahera bilder från presentationsformer i Java
linktitle: Bild från form
type: docs
weight: 100
url: /sv/java/extracting-images-from-presentation-shapes/
keywords:
- extrahera bild
- hämta bild
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Extrahera bilder från former i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Java - snabb, kodvänlig lösning."
---
## **Översikt**

Bilder i en presentation kan visas i flera formtyper: som vanliga bildramar, som bildfyllningar som appliceras på former, som OLE‑objektsförhandsgranskningsbilder, som video‑ eller ljudram‑miniatyrer, som zoom‑bilder eller som bilder inbäddade i tabell-, diagram‑ och SmartArt‑former. Aspose.Slides lagrar dessa bilder i presentationens bildsamling, som exponeras via [IImageCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides.iimagecollection/) och [IPPImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides.ippimage/)‑objekt.

Om du bara behöver exportera varje bildresurs som är inbäddad i en presentation, iterera genom `presentation.getImages()`. Den här artikeln fokuserar på en annan uppgift: att gå igenom former för att hitta var bilder används på bilderna, så att de sparade filerna kan behålla användbar kontext som bildnummer, formposition och källtyp (bildram, fyllningsbild, medieförhandsgranskning, OLE‑förhandsgranskning eller zoom‑bild).

{{% alert title="Tips" color="primary" %}}
Använd [IPPImage.getBinaryData](https://reference.aspose.com/slides/sv/java/com.aspose.slides.ippimage/#getBinaryData--) för att bevara den ursprungliga kodade bilddatan och filtypen. Använd [IPPImage.getImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides.ippimage/#getImage--) med [IImage.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides.iimage/#save-java.lang.String-int-) när du vill normalisera utdata till ett specifikt format som PNG.
{{% /alert %}}

## **Gemensamma hjälpfunktioner**

Hjälpfunktionerna nedan håller exemplen korta. `saveOriginalImage` skriver de ursprungliga inbäddade bytena, väljer en säker filändelse från MIME‑typen och hoppar över duplicate bild‑binaries med SHA‑256‑hash.

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

## **Extrahera bilder från bildramar**

Använd detta tillvägagångssätt för bilder som infogats som fristående objekt. En [IPictureFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides.ipictureframe/) lagrar sin bild i `getPictureFormat().getPicture().getImage()`, vilket returnerar ett [IPPImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides.ippimage/)‑objekt.

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

## **Extrahera bilder från bildfyllda former**

Former kan använda en bild som fyllning. Kontrollera først formens fyllningstyp: om den inte är [FillType.Picture](https://reference.aspose.com/slides/sv/java/com.aspose.slides.filltype/), finns det ingen bild att extrahera från den fyllningen. Exemplet nedan hanterar [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides.iautoshape/)‑objekt och sparar varje bild som PNG via [IPPImage.getImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides.ippimage/#getImage--).

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

## **Extrahera förhandsgranskningsbilder från OLE‑objektramar**

En [IOleObjectFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides.ioleobjectframe/) kan ha en ersättningsbild som PowerPoint använder som objektets förhandsgranskning på en bild. Denna bild är tillgänglig via `getSubstitutePictureFormat().getPicture().getImage()`. Att extrahera denna bild ger dig förhandsgranskningen, inte det inbäddade OLE‑paketets innehåll.

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

## **Extrahera förhandsgranskningsbilder från videoramar**

En [IVideoFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides.ivideoframe/) kan också lagra en förhandsgranskningsbild i `getPictureFormat().getPicture().getImage()`. Detta är postern eller miniatyren som visas på bilden, inte en bildruta avkodad från videoströmmen.

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

## **Extrahera förhandsgranskningsbilder från ljudramar**

En [IAudioFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides.iaudioframe/) kan lagra en miniatyr i `getPictureFormat().getPicture().getImage()`. Detta är bilden som visas för ljudobjektet på bilden.

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

## **Extrahera bilder från zoom‑objekt**

[IZoomFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides.izoomframe/) och [ISectionZoomFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides.isectionzoomframe/)‑former kan använda anpassade bilder. Läs `getZoomImage()` från zoom‑ramen.

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

## **Extrahera bilder från sammanfattnings‑zoom‑ramar**

En [ISummaryZoomFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides.isummaryzoomframe/) är också en form. Dess sektionsobjekt kan använda anpassade bilder, som exponeras via varje sammanfattnings‑zoom‑sektionens `getZoomImage()`‑metod.

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

## **Extrahera bilder från tabellformer**

En [ITable](https://reference.aspose.com/slides/sv/java/com.aspose.slides.itable/) är en form. Bilder i en tabell lagras vanligtvis som bildfyllningar i tabellceller.

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

## **Extrahera bilder från diagramformer**

En [IChart](https://reference.aspose.com/slides/sv/java/com.aspose.slides.ichart/) är en form. Exemplet nedan extraherar en bild från diagrammets bildfyllning.

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

## **Extrahera bilder från SmartArt‑former**

Ett [ISmartArt](https://reference.aspose.com/slides/sv/java/com.aspose.slides.ismartart/)‑objekt är en form. Beroende på SmartArt‑layout kan bilder lagras i nod‑punkt‑fyllningar eller i fyllningsformaten för nodformer.

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

## **Inkludera bilder i grupperade former**

Grupperade former innehåller egna form‑samlingar. Den gemensamma hjälpfunktionen `enumerateShapes` har ett `includeGroupedShapes`‑alternativ. Sätt det till `true` när du vill inspektera former inuti [IGroupShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides.igroupshape/)‑objekt. Exemplet nedan extraherar bilder från bildramar, bildfyllda former, OLE‑objekt‑förhandsgranskningar, video‑ram‑miniatyrer och ljud‑ram‑miniatyrer. För att också inkludera tabell-, diagram‑, SmartArt‑ och sammanfattnings‑zoom‑bilder, återanvänd den specialiserade extraheringslogiken från de föregående avsnitten samtidigt som du behåller samma rekursiva form‑traversering.

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

## **Särskilda fall och praktiska anmärkningar**

- **Dubblettbilder:** Flera former kan referera till samma bild eller separata bilder med identiska byten. Hasha [IPPImage.getBinaryData](https://reference.aspose.com/slides/sv/java/com.aspose.slides.ippimage/#getBinaryData--) innan du skriver filer om du vill ha en utdatasfil per unik bild.
- **Originaldata vs. konverterad output:** Att spara [IPPImage.getBinaryData](https://reference.aspose.com/slides/sv/java/com.aspose.slides.ippimage/#getBinaryData--) bevarar den inbäddade JPEG‑, PNG‑, GIF‑, SVG‑, EMF‑ eller WMF‑datan. Att spara [IPPImage.getImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides.ippimage/#getImage--) via [IImage.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides.iimage/#save-java.lang.String-int-) är användbart när du vill ha ett enhetligt output‑format.
- **Ej stödjulda fyllningstyper:** Enfärgade, gradient‑, mönster‑ och ingen‑fyllning‑former innehåller ingen bildfyllning. Kontrollera [FillType](https://reference.aspose.com/slides/sv/java/com.aspose.slides.filltype/) innan du läser `getPictureFillFormat()`.
- **Grupperade former:** Den översta bild‑form‑samlingen plattar inte till grupper. Inspektera rekursivt [IGroupShape.getShapes](https://reference.aspose.com/slides/sv/java/com.aspose.slides.igroupshape/#getShapes--) när gruppat innehåll är viktigt.
- **OLE‑objekt‑förhandsgranskningar:** En [IOleObjectFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides.ioleobjectframe/) kan exponera en förhandsgranskningsbild via `getSubstitutePictureFormat()`, men den bilden är bara bildens förhandsgranskning. Det är inte den inbäddade filen i OLE‑objektet.
- **Video‑ram‑miniatyrer:** En [IVideoFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides.ivideoframe/) kan exponera en förhandsgranskningsbild via `getPictureFormat()`, men den bilden är bara postern som visas på bilden. Den extraheras inte från videoströmmen.
- **Audio‑ram‑miniatyrer:** En [IAudioFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides.iaudioframe/) kan exponera en ikon eller miniatyr via `getPictureFormat()`; det är inte den inbäddade ljuddatan.
- **Zoom‑bilder:** Slide‑zoom, sektion‑zoom och sammanfattnings‑zoom‑former kan använda anpassade [IPPImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides.ippimage/)‑objekt via `getZoomImage()`.
- **Inbäddade formmodeller:** Tabell-, diagram‑ och SmartArt‑objekt implementerar [IShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides.ishape/), men deras bilder lagras ofta i inbäddade tabellcell‑, diagram‑element‑ eller SmartArt‑nod‑formateringsobjekt.
- **Beskurna eller transformerade bilder:** Att komma åt [IPPImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides.ippimage/) ger dig den lagrade bildresursen. Det renderar inte beskärning, transparens, omfärgning, rotation eller andra visuella effekter som applicerats av formen.

## **Vanliga frågor**

**Kan jag extrahera den ursprungliga bilden utan beskärning, effekter eller formtransformationer?**

Ja. Kom åt [IPPImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides.ippimage/)-objektet och skriv [IPPImage.getBinaryData](https://reference.aspose.com/slides/sv/java/com.aspose.slides.ippimage/#getBinaryData--) till disk. Detta bevarar den ursprungliga kodade bilden som lagrats i presentationen, inte hur bilden renderas på bilden.

**Kan jag exportera varje extraherad bild som PNG?**

Ja. Använd [IPPImage.getImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides.ippimage/#getImage--) för att få ett [IImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides.iimage/)-objekt och anropa sedan [IImage.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides.iimage/#save-java.lang.String-int-) med [ImageFormat.Png](https://reference.aspose.com/slides/sv/java/com.aspose.slides.imageformat/). Detta omvandlar utdata och kan missa den ursprungliga filtypen eller vektordatan.

**Hur undviker jag att spara samma bild mer än en gång?**

Använd en hash av [IPPImage.getBinaryData](https://reference.aspose.com/slides/sv/java/com.aspose.slides.ippimage/#getBinaryData--) och håll hasharna i en uppsättning. Om en ny bild har en hash som redan finns, hoppa över den eller registrera en annan referens till den befintliga utdatafilen.

**Varför genererar vissa former ingen bild?**

Bildramar, bildfyllda former, OLE‑objektramar, mediarämar, zoom‑ramar, tabeller, diagram och SmartArt‑objekt kan referera till bilder. Vissa formtyper exponerar bilder via inbäddade formateringsobjekt, så en enkel `getPictureFormat()`‑ eller `getFillFormat()`‑kontroll är inte alltid tillräcklig.

**Kan jag extrahera miniatyren som visas för en videoram?**

Ja. Använd [IVideoFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides.ivideoframe/) och läs `getPictureFormat().getPicture().getImage()`. Detta extraherar postern som lagrats med videoramen, inte en bildruta genererad från videofilen.

**Hur kan jag avgöra vilka former som använder en specifik bild från presentationens bildsamling?**

Aspose.Slides lagrar inga omvända länkar från [IPPImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides.ippimage/) till former. Bygg en mappning under traversering: varje gång du hittar en bildreferens, registrera bildnumret, formens sökväg och bild‑hash eller samlingsobjekt.

**Kan jag extrahera bilder som är inbäddade i OLE‑objekt, t.ex. bifogade dokument?**

Du kan extrahera OLE‑objektets slide‑förhandsgranskning via [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides.ioleobjectframe/#getSubstitutePictureFormat--). Den förhandsgranskningen är dock inte själva det inbäddade dokumentet. För att extrahera bilder inuti den inbäddade filen måste du extrahera OLE‑data och inspektera den med verktyg för den filtypen.