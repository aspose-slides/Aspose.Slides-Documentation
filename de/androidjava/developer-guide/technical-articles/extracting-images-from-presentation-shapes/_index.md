---
title: Bilder aus Präsentationsformen in Android via Java extrahieren
linktitle: Bild aus Form
type: docs
weight: 100
url: /de/androidjava/extracting-images-from-presentation-shapes/
keywords:
- Bild extrahieren
- Bild abrufen
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Bilder aus Formen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Android via Java extrahieren - schnelle, code-freundliche Lösung."
---
## **Übersicht**

Bilder in einer Präsentation können in mehreren Form‑Typen auftreten: als gewöhnliche Bildrahmen, als Bildfüllungen, die auf Formen angewendet werden, als Vorschau­bilder von OLE‑Objekten, als Miniaturansichten von Video‑ oder Audio‑Frames, als Zoom‑Bilder oder als in Tabellen‑, Diagramm‑ und SmartArt‑Formen verschachtelte Bilder. Aspose.Slides speichert diese Bilder in der Bildsammlung der Präsentation, die über die Objekte [IImageCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimagecollection/) und [IPPImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/) bereitgestellt wird.

Wenn Sie nur jede in einer Präsentation eingebettete Bildressource exportieren müssen, iterieren Sie über `presentation.getImages()`. Dieser Artikel konzentriert sich auf eine andere Aufgabe: das Durchlaufen von Formen, um zu ermitteln, wo Bilder auf Folien verwendet werden, sodass die gespeicherten Dateien nützlichen Kontext wie Foliennummer, Form‑Position und Quelltyp (Bildrahmen, Füllbild, Medien‑Vorschau, OLE‑Vorschau oder Zoom‑Bild) beibehalten können.

{{% alert title="Tip" color="info" %}}
Verwenden Sie [IPPImage.getBinaryData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/#getBinaryData--) um die original kodierten Bilddaten und den Dateityp beizubehalten. Verwenden Sie [IPPImage.getImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/#getImage--) zusammen mit [IImage.save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-), wenn Sie die Ausgabe in ein bestimmtes Format wie PNG normalisieren möchten.
{{% /alert %}}

## **Gemeinsame Hilfsmethoden**

Die untenstehenden Hilfsmethoden halten die Beispiele kurz. `saveOriginalImage` schreibt die original eingebetteten Bytes, wählt eine sichere Erweiterung aus dem MIME‑Typ und überspringt doppelte Bild‑Binärdaten anhand eines SHA‑256‑Hashes.

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

Verwenden Sie diesen Ansatz für Bilder, die als eigenständige Objekte eingefügt wurden. Ein [IPictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipictureframe/) speichert sein Bild in `getPictureFormat().getPicture().getImage()`, was ein [IPPImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/)‑Objekt zurückgibt. Beachten Sie, dass [IVideoFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/) und [IAudioFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iaudioframe/) von [IPictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipictureframe/) abgeleitet sind, sodass diese `instanceof`‑Prüfung ebenfalls Medien‑Frames erfasst und deren Vorschau‑Bilder exportiert; prüfen Sie zuerst auf diese Typen, wenn Sie sie getrennt behandeln möchten, wie das letzte Beispiel auf dieser Seite zeigt.

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

## **Bilder aus bildgefüllten Formen extrahieren**

Formen können ein Bild als Füllung verwenden. Prüfen Sie zunächst den Fülltyp der Form: Ist er nicht [FillType.Picture](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/filltype/), gibt es kein Bild zum Extrahieren. Das folgende Beispiel behandelt [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/)‑Objekte und speichert jedes Bild als PNG über [IPPImage.getImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/#getImage--).

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

Ein [IOleObjectFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ioleobjectframe/) kann ein Ersatzbild besitzen, das PowerPoint als Vorschau des Objekts auf einer Folie verwendet. Dieses Bild ist über `getSubstitutePictureFormat().getPicture().getImage()` verfügbar. Das Extrahieren dieses Bildes liefert das Vorschau‑Bild, nicht den Inhalt des eingebetteten OLE‑Pakets.

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

## **Vorschau‑Bilder aus Video‑Frames extrahieren**

Ein [IVideoFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/) kann ebenfalls ein Vorschau‑Bild in `getPictureFormat().getPicture().getImage()` speichern. Dies ist das Poster‑ oder Miniaturbild, das auf der Folie angezeigt wird, nicht ein aus dem Videostream decodierter Frame.

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

## **Vorschau‑Bilder aus Audio‑Frames extrahieren**

Ein [IAudioFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iaudioframe/) kann ein Miniaturbild in `getPictureFormat().getPicture().getImage()` speichern. Dies ist das Bild, das für das Audio‑Objekt auf der Folie angezeigt wird.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util Set;

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

[IZoomFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/izoomframe/) und [ISectionZoomFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isectionzoomframe/) können benutzerdefinierte Bilder verwenden. Lesen Sie `getZoomImage()` vom Zoom‑Frame.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util Set;

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

Ein [ISummaryZoomFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isummaryzoomframe/) ist ebenfalls eine Form. Seine Abschnittselemente können benutzerdefinierte Bilder verwenden, die über die Methode `getZoomImage()` jedes Summary‑Zoom‑Abschnitts bereitgestellt werden.

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

## **Bilder aus Tabell‑Formen extrahieren**

Ein [ITable](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itable/) ist eine Form. Bilder in einer Tabelle werden gewöhnlich als Bildfüllungen in Tabellenzellen gespeichert.

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

## **Bilder aus Diagramm‑Formen extrahieren**

Ein [IChart](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichart/) ist eine Form. Das folgende Beispiel extrahiert ein Bild aus der Bildfüllung des Diagrammbereichs.

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

## **Bilder aus SmartArt‑Formen extrahieren**

Ein [ISmartArt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ismartart/)‑Objekt ist eine Form. Abhängig vom SmartArt‑Layout können Bilder in Knoten‑Aufzählungs‑Füllungen oder in den Füllformaten von Knotenformen gespeichert sein.

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

## **Bilder in gruppierten Formen einschließen**

Gruppierte Formen besitzen eigene Form‑Sammlungen. Der gemeinsame Hilfsmethoden‑Aufruf `enumerateShapes` hat eine Option `includeGroupedShapes`. Setzen Sie sie auf `true`, wenn Sie Formen innerhalb von [IGroupShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/igroupshape/)‑Objekten untersuchen wollen. Das folgende Beispiel extrahiert Bilder aus Bildrahmen, bildgefüllten Formen, OLE‑Objekt‑Vorschauen, Video‑Frame‑Miniaturansichten und Audio‑Frame‑Miniaturansichten. Um außerdem Bilder aus Tabellen, Diagrammen, SmartArt und Summary‑Zoom‑Bildern zu berücksichtigen, verwenden Sie die spezialisierte Extraktionslogik aus den vorherigen Abschnitten und behalten die gleiche rekursive Form‑Durchquerung bei.

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

## **Randfälle und praktische Hinweise**

- **Doppelte Bilder:** Mehrere Formen können auf dasselbe Bild oder auf verschiedene Bilder mit identischen Bytes verweisen. Hashen Sie [IPPImage.getBinaryData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/#getBinaryData--) bevor Sie Dateien schreiben, wenn Sie pro eindeutigem Bild nur eine Ausgabedatei erzeugen möchten.
- **Originaldaten vs. konvertierte Ausgabe:** Das Speichern von [IPPImage.getBinaryData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/#getBinaryData--) bewahrt die eingebetteten JPEG‑, PNG‑, GIF‑, SVG‑, EMF‑ oder WMF‑Daten. Das Speichern von [IPPImage.getImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/#getImage--) über [IImage.save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) ist nützlich, wenn Sie ein einheitliches Ausgabeformat benötigen.
- **Nicht unterstützte Fülltypen:** Solide, Verlauf‑, Muster‑ und keine‑Füll‑Formen enthalten keine Bildfüllung. Prüfen Sie [FillType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/filltype/) bevor Sie `getPictureFillFormat()` aufrufen.
- **Gruppierte Formen:** Die oberste Form‑Sammlung einer Folie flacht Gruppen nicht ab. Durchlaufen Sie rekursiv [IGroupShape.getShapes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/igroupshape/#getShapes--) wenn gruppierter Inhalt relevant ist.
- **OLE‑Objekt‑Vorschauen:** Ein [IOleObjectFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ioleobjectframe/) kann ein Vorschau‑Bild über `getSubstitutePictureFormat()` bereitstellen, aber dieses Bild ist nur die Folien‑Vorschau. Es ist nicht die im OLE‑Objekt eingebettete Datei.
- **Video‑Frame‑Miniaturansichten:** Ein [IVideoFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/) kann ein Vorschau‑Bild über `getPictureFormat()` bereitstellen, jedoch ist dieses Bild nur das Poster, das auf der Folie angezeigt wird. Es wird nicht aus dem Videostream extrahiert.
- **Audio‑Frame‑Miniaturansichten:** Ein [IAudioFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iaudioframe/) kann ein Symbol oder Miniaturbild über `getPictureFormat()` bereitstellen; es ist nicht das eingebettete Audiodaten‑File.
- **Zoom‑Bilder:** Folien‑Zoom, Abschnitts‑Zoom und Summary‑Zoom‑Formen können benutzerdefinierte [IPPImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/)‑Objekte über `getZoomImage()` verwenden.
- **Verschachtelte Form‑Modelle:** Tabellen-, Diagramm‑ und SmartArt‑Objekte implementieren [IShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/), aber ihre Bilder werden häufig in verschachtelten Tabellenzell‑, Diagrammelement‑ oder SmartArt‑Knoten‑Formatierungsobjekten gespeichert.
- **Zugeschnittene oder transformierte Bilder:** Der Zugriff auf [IPPImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/) liefert das gespeicherte Bild‑Ressourcen‑Objekt. Es werden keine Beschnitt‑, Transparenz‑, Umfärbungs‑, Rotations‑ oder anderen visuellen Effekte, die von der Form angewendet werden, gerendert.

## **FAQ**

### Kann ich das Original‑Bild ohne Beschnitt, Effekte oder Form‑Transformationen extrahieren?

Ja. Greifen Sie auf das [IPPImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/)‑Objekt zu und schreiben Sie [IPPImage.getBinaryData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/#getBinaryData--) auf die Festplatte. Dadurch bleibt das original kodierte Bild erhalten, das in der Präsentation gespeichert ist, und nicht die Art, wie das Bild auf der Folie gerendert wird.

### Kann ich jedes extrahierte Bild als PNG exportieren?

Ja. Verwenden Sie [IPPImage.getImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/#getImage--), um ein [IImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimage/)‑Objekt zu erhalten, und rufen Sie dann [IImage.save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) mit [ImageFormat.Png](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imageformat/) auf. Dies konvertiert die Ausgabe und kann den ursprünglichen Dateityp oder Vektordaten nicht erhalten.

### Wie vermeide ich, dass dasselbe Bild mehrmals gespeichert wird?

Verwenden Sie einen Hash von [IPPImage.getBinaryData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/#getBinaryData--) und speichern Sie die Hashes in einer Menge. Hat ein neues Bild einen bereits vorhandenen Hash, überspringen Sie es oder vermerken Sie einen weiteren Verweis auf die bestehende Ausgabedatei.

### Warum erzeugen manche Formen kein Bild?

Bildrahmen, bildgefüllte Formen, OLE‑Objekt‑Frames, Medien‑Frames, Zoom‑Frames, Tabellen, Diagramme und SmartArt‑Objekte können Bilder referenzieren. Einige Form‑Typen stellen Bilder über verschachtelte Format‑Objekte bereit, sodass ein einfacher Aufruf von `getPictureFormat()` oder `getFillFormat()` nicht immer ausreicht.

### Kann ich das Miniaturbild eines Video‑Frames extrahieren?

Ja. Verwenden Sie [IVideoFrame.getPictureFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ivideoframe/#getPictureFormat--) und lesen Sie `getPictureFormat().getPicture().getImage()`. Damit wird das Poster‑Bild extrahiert, das mit dem Video‑Frame gespeichert ist, nicht ein Frame, der aus der Videodatei generiert wurde.

### Wie kann ich bestimmen, welche Formen ein bestimmtes Bild aus der Präsentations‑Bildsammlung verwenden?

Aspose.Slides speichert keine Rückverknüpfungen von [IPPImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/) zu Formen. Erstellen Sie während der Durchquerung eine Zuordnung: Wann immer Sie eine Bild‑Referenz finden, protokollieren Sie Folien‑Nummer, Form‑Pfad und Bild‑Hash oder das Sammlungs‑Element.

### Kann ich Bilder extrahieren, die in OLE‑Objekten eingebettet sind, etwa angehängte Dokumente?

Sie können die Folien‑Vorschau des OLE‑Objekts über [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) extrahieren. Diese Vorschau ist jedoch nicht das eingebettete Dokument selbst. Um Bilder aus der eingebetteten Datei zu extrahieren, müssen Sie die OLE‑Daten auslesen und mit geeigneten Werkzeugen für den jeweiligen Dateityp untersuchen.