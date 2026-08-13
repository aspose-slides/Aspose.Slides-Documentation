---
title: Bilder aus Präsentationsformen in Java extrahieren
linktitle: Bild aus Form
type: docs
weight: 100
url: /de/java/extracting-images-from-presentation-shapes/
keywords:
- Bild extrahieren
- Bild abrufen
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Bilder aus Formen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Java extrahieren - schnelle, codefreundliche Lösung."
---
## **Übersicht**

Bilder in einer Präsentation können in mehreren Formtypen auftreten: als gewöhnliche Bildrahmen, als Bildfüllungen, die auf Formen angewendet werden, als OLE‑Objekt‑Vorschau‑Bilder, als Miniaturansichten von Video‑ oder Audio‑Frames, als Zoom‑Bilder oder als in Tabellen‑, Diagramm‑ und SmartArt‑Formen verschachtelte Bilder. Aspose.Slides speichert diese Bilder in der Präsentations‑Bildsammlung, die über die Objekte [IImageCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimagecollection/) und [IPPImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/) bereitgestellt werden.

Wenn Sie nur jede in einer Präsentation eingebettete Bildressource exportieren müssen, iterieren Sie über `presentation.getImages()`. Dieser Artikel konzentriert sich auf eine andere Aufgabe: das Durchlaufen von Formen, um zu ermitteln, wo Bilder auf Folien verwendet werden, sodass die gespeicherten Dateien nützlichen Kontext wie die Foliennummer, die Formposition und den Quelltyp (Bildrahmen, Füllbild, Medien‑Vorschau, OLE‑Vorschau oder Zoom‑Bild) behalten können.

{{% alert title="Hinweis" color="info" %}}
Verwenden Sie [IPPImage.getBinaryData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/#getBinaryData--) , um die ursprünglich codierten Bilddaten und den Dateityp beizubehalten. Verwenden Sie [IPPImage.getImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/#getImage--) zusammen mit [IImage.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimage/#save-java.lang.String-int-) , wenn Sie die Ausgabe in ein bestimmtes Format wie PNG normalisieren möchten.
{{% /alert %}}

## **Gemeinsame Hilfsmethoden**

Die untenstehenden Hilfsmethoden halten die Beispiele kurz. `saveOriginalImage` schreibt die original eingebetteten Bytes, ermittelt eine sichere Erweiterung aus dem MIME‑Typ und überspringt doppelte Bild‑Binärdaten anhand des SHA‑256‑Hashes.

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

## **Bilder aus Bildrahmen extrahieren**

Verwenden Sie diesen Ansatz für Bilder, die als eigenständige Objekte eingefügt wurden. Ein [IPictureFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipictureframe/) speichert sein Bild in `getPictureFormat().getPicture().getImage()`, was ein [IPPImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/)‑Objekt zurückgibt.

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

## **Bilder aus bildgefüllten Formen extrahieren**

Formen können ein Bild als Füllung verwenden. Prüfen Sie zunächst den Fülltyp der Form: Wenn er nicht [FillType.Picture](https://reference.aspose.com/slides/de/java/com.aspose.slides/filltype/) ist, gibt es kein Bild, das aus dieser Füllung extrahiert werden kann. Das nachstehende Beispiel behandelt [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/)‑Objekte und speichert jedes Bild als PNG über [IPPImage.getImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/#getImage--).

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

## **Vorschau‑Bilder aus OLE‑Objekt‑Frames extrahieren**

Ein [IOleObjectFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/ioleobjectframe/) kann ein Ersatzbild besitzen, das PowerPoint als Vorschau des Objekts auf einer Folie verwendet. Dieses Bild ist über `getSubstitutePictureFormat().getPicture().getImage()` verfügbar. Das Extrahieren dieses Bildes liefert das Vorschau‑Bild, nicht den eingebetteten OLE‑Paketinhalt.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util Set;
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

## **Vorschau‑Bilder aus Video‑Frames extrahieren**

Ein [IVideoFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideoframe/) kann ebenfalls ein Vorschau‑Bild in `getPictureFormat().getPicture().getImage()` speichern. Dies ist das Poster‑ oder Miniaturbild, das auf der Folie angezeigt wird, nicht ein Frame, der aus dem Videostrom dekodiert wurde.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util Set;
import java.util List;

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

## **Vorschau‑Bilder aus Audio‑Frames extrahieren**

Ein [IAudioFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/iaudioframe/) kann ein Vorschaubild in `getPictureFormat().getPicture().getImage()` speichern. Dies ist das Bild, das für das Audio‑Objekt auf der Folie angezeigt wird.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util Set;
import java.util List;

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

## **Bilder aus Zoom‑Objekten extrahieren**

[IZoomFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/izoomframe/) und [ISectionZoomFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/isectionzoomframe/)‑Formen können benutzerdefinierte Bilder verwenden. Lesen Sie `getZoomImage()` vom Zoom‑Frame.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util Set;
import java.util List;

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

## **Bilder aus Summary‑Zoom‑Frames extrahieren**

Ein [ISummaryZoomFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/isummaryzoomframe/) ist ebenfalls eine Form. Seine Abschnittselemente können benutzerdefinierte Bilder verwenden, die über die Methode `getZoomImage()` jedes Summary‑Zoom‑Abschnitts bereitgestellt werden.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util Set;
import java.util List;

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

## **Bilder aus Tabellen‑Formen extrahieren**

Ein [ITable](https://reference.aspose.com/slides/de/java/com.aspose.slides/itable/) ist eine Form. Bilder in einer Tabelle werden normalerweise als Bildfüllungen in Tabellenzellen gespeichert.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.Set;
import java.util List;

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

## **Bilder aus Diagramm‑Formen extrahieren**

Ein [IChart](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichart/) ist eine Form. Das nachstehende Beispiel extrahiert ein Bild aus der Bildfüllung des Diagrammbereichs.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util Set;
import java.util List;

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

## **Bilder aus SmartArt‑Formen extrahieren**

Ein [ISmartArt](https://reference.aspose.com/slides/de/java/com.aspose.slides/ismartart/)‑Objekt ist eine Form. Je nach SmartArt‑Layout können Bilder in den Aufzählungs‑Füllungen von Knoten oder in den Füllformaten von Knotenkörpern gespeichert sein.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util Set;
import java.util List;

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

## **Bilder in gruppierten Formen einbinden**

Gruppierte Formen besitzen eigene Form‑Sammlungen. Die gemeinsam genutzte Hilfsmethode `enumerateShapes` verfügt über die Option `includeGroupedShapes`. Setzen Sie sie auf `true`, wenn Sie Formen innerhalb von [IGroupShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/igroupshape/)‑Objekten untersuchen möchten. Das nachstehende Beispiel extrahiert Bilder aus Bildrahmen, bildgefüllten Formen, OLE‑Objekt‑Vorschauen, Video‑Frame‑Miniaturansichten und Audio‑Frame‑Miniaturansichten. Um auch Bilder aus Tabellen, Diagrammen, SmartArt und Summary‑Zoom‑Formen zu berücksichtigen, nutzen Sie die spezialisierte Extraktionslogik aus den vorherigen Abschnitten und behalten dabei die gleiche rekursive Form‑Durchquerung bei.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util Set;
import java.util List;

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

## **Randfälle und praktische Hinweise**

- **Doppelte Bilder:** Mehrere Formen können auf dasselbe Bild verweisen oder unterschiedliche Bilder mit identischen Bytes besitzen. Erzeugen Sie einen Hash von [IPPImage.getBinaryData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/#getBinaryData--) bevor Sie Dateien schreiben, wenn Sie pro eindeutigem Bild nur eine Ausgabedatei wünschen.
- **Originaldaten vs. konvertierte Ausgabe:** Das Speichern von [IPPImage.getBinaryData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/#getBinaryData--) bewahrt die eingebetteten JPEG‑, PNG‑, GIF‑, SVG‑, EMF‑ oder WMF‑Daten. Das Speichern von [IPPImage.getImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/#getImage--) über [IImage.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimage/#save-java.lang.String-int-) ist sinnvoll, wenn Sie ein einheitliches Ausgabeformat benötigen.
- **Nicht unterstützte Fülltypen:** Formen mit Vollfarbe, Verlauf, Muster oder ohne Füllung enthalten keine Bildfüllung. Prüfen Sie [FillType](https://reference.aspose.com/slides/de/java/com.aspose.slides/filltype/), bevor Sie `getPictureFillFormat()` lesen.
- **Gruppierte Formen:** Die oberste Form‑Sammlung einer Folie flacht Gruppen nicht ab. Durchlaufen Sie rekursiv [IGroupShape.getShapes](https://reference.aspose.com/slides/de/java/com.aspose.slides/igroupshape/#getShapes--), wenn gruppierter Inhalt relevant ist.
- **OLE‑Objekt‑Vorschauen:** Ein [IOleObjectFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/ioleobjectframe/) kann ein Vorschau‑Bild über `getSubstitutePictureFormat()` bereitstellen, doch dieses Bild ist nur die Folien‑Vorschau und nicht die eingebettete Datei im OLE‑Objekt.
- **Video‑Frame‑Miniaturansichten:** Ein [IVideoFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideoframe/) kann ein Vorschau‑Bild über `getPictureFormat()` bereitstellen, doch dieses Bild ist nur das Poster, das auf der Folie angezeigt wird. Es wird nicht aus dem Videostrom extrahiert.
- **Audio‑Frame‑Miniaturansichten:** Ein [IAudioFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/iaudioframe/) kann ein Symbol oder Miniaturbild über `getPictureFormat()` bereitstellen; dies ist nicht das eingebettete Audiodatum.
- **Zoom‑Bilder:** Slide‑Zoom, Section‑Zoom und Summary‑Zoom‑Formen können benutzerdefinierte [IPPImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/)‑Objekte über `getZoomImage()` verwenden.
- **Verschachtelte Form‑Modelle:** Tabellen‑, Diagramm‑ und SmartArt‑Objekte implementieren [IShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/), jedoch werden ihre Bilder häufig in verschachtelten Tabellenzellen, Diagrammelementen oder SmartArt‑Knoten‑Formatierungsobjekten gespeichert.
- **Zugeschnittene oder transformierte Bilder:** Der Zugriff auf [IPPImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/) liefert die gespeicherte Bildressource. Es werden keine Zuschnitte, Transparenz, Umfärbungen, Drehungen oder andere visuelle Effekte, die von der Form angewendet werden, gerendert.

## **FAQ**

### Kann ich das Originalbild ohne Zuschnitt, Effekte oder Form‑Transformationen extrahieren?

Ja. Greifen Sie auf das [IPPImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/)‑Objekt zu und schreiben Sie [IPPImage.getBinaryData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/#getBinaryData--) auf die Festplatte. Dadurch wird das ursprünglich codierte Bild erhalten, das in der Präsentation gespeichert ist, nicht die Art und Weise, wie das Bild auf der Folie gerendert wird.

### Kann ich jedes extrahierte Bild als PNG exportieren?

Ja. Verwenden Sie [IPPImage.getImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/#getImage--), um ein [IImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimage/)‑Objekt zu erhalten, und rufen Sie dann [IImage.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimage/#save-java.lang.String-int-) mit [ImageFormat.Png](https://reference.aspose.com/slides/de/java/com.aspose.slides/imageformat/) auf. Dies konvertiert die Ausgabe und kann den ursprünglichen Dateityp oder Vektordaten nicht erhalten.

### Wie vermeide ich, dass dasselbe Bild mehr als einmal gespeichert wird?

Verwenden Sie einen Hash von [IPPImage.getBinaryData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/#getBinaryData--) und bewahren Sie die Hashes in einer Menge auf. Wenn ein neues Bild einen bereits vorhandenen Hash hat, überspringen Sie es oder vermerken Sie einen weiteren Verweis auf die bestehende Ausgabedatei.

### Warum erzeugen einige Formen kein Bild?

Bildrahmen, bildgefüllte Formen, OLE‑Objekt‑Frames, Medien‑Frames, Zoom‑Frames, Tabellen, Diagramme und SmartArt‑Objekte können auf Bilder verweisen. Einige Formtypen stellen Bilder über verschachtelte Formatierungsobjekte bereit, sodass ein einfacher Aufruf von `getPictureFormat()` oder `getFillFormat()` nicht immer ausreicht.

### Kann ich das Miniaturbild eines Video‑Frames extrahieren?

Ja. Verwenden Sie [IVideoFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/ivideoframe/) und lesen Sie `getPictureFormat().getPicture().getImage()`. Damit wird das Poster‑Bild extrahiert, das mit dem Video‑Frame gespeichert ist, nicht ein Frame, das aus der Videodatei generiert wird.

### Wie kann ich bestimmen, welche Formen ein bestimmtes Bild aus der Präsentations‑Bildsammlung verwenden?

Aspose.Slides speichert keine Rückverweise von [IPPImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/ippimage/) zu Formen. Erstellen Sie während der Durchquerung eine Zuordnung: Wann immer Sie eine Bildreferenz finden, notieren Sie die Foliennummer, den Formpfad und den Bild‑Hash oder das Sammlungs‑Element.

### Kann ich Bilder extrahieren, die in OLE‑Objekten eingebettet sind, z. B. angehängte Dokumente?

Sie können die Folien‑Vorschau des OLE‑Objekts über [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) extrahieren. Diese Vorschau ist jedoch nicht das eingebettete Dokument selbst. Um Bilder aus der eingebetteten Datei zu extrahieren, müssen Sie die OLE‑Daten auslesen und mit Werkzeugen für den jeweiligen Dateityp analysieren.