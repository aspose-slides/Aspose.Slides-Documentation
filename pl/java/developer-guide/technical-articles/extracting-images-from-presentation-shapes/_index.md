---
title: Wyodrębnianie obrazów z kształtów prezentacji w Javie
linktitle: Obraz z kształtu
type: docs
weight: 100
url: /pl/java/extracting-images-from-presentation-shapes/
keywords:
- wyodrębnić obraz
- pobrać obraz
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Wyodrębnianie obrazów z kształtów w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Javy – szybkie, przyjazne dla kodu rozwiązanie."
---
## **Przegląd**

Obrazy w prezentacji mogą występować w kilku typach kształtów: jako zwykłe ramki obrazów, jako wypełnienia obrazami zastosowane do kształtów, jako obrazy podglądu obiektów OLE, jako miniatury klatek wideo lub audio, jako obrazy powiększeń, lub jako obrazy zagnieżdżone w kształtach tabel, wykresów i SmartArt. Aspose.Slides przechowuje te obrazy w kolekcji obrazów prezentacji, udostępnianej poprzez obiekty [IImageCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimagecollection/) i [IPPImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/).

Jeśli potrzebujesz jedynie wyeksportować każdy zasób obrazu osadzonego w prezentacji, przeiteruj `presentation.getImages()`. Ten artykuł koncentruje się na innym zadaniu: przeszukiwaniu kształtów w celu znalezienia, gdzie obrazy są używane na slajdach, tak aby zapisane pliki mogły zachować przydatny kontekst, taki jak numer slajdu, pozycja kształtu i typ źródła (ramka obrazu, wypełnienie obrazem, podgląd multimediów, podgląd OLE lub obraz powiększenia).

{{% alert title="Tip" color="info" %}}
Użyj [IPPImage.getBinaryData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/#getBinaryData--) aby zachować oryginalne zakodowane dane obrazu i typ pliku. Użyj [IPPImage.getImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/#getImage--) wraz z [IImage.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/#save-java.lang.String-int-) gdy chcesz znormalizować wynikowy format, np. PNG.
{{% /alert %}}

## **Wspólne Metody Pomocnicze**

Poniższe metody pomocnicze skracają przykłady. `saveOriginalImage` zapisuje oryginalne osadzone bajty, wybiera bezpieczne rozszerzenie na podstawie typu MIME i pomija duplikaty binarnych obrazów przy użyciu skrótu SHA-256.

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

## **Wyodrębnianie Obrazów z Ram Ekspozycyjnych**

Użyj tego podejścia dla obrazów wstawionych jako odrębne obiekty. [IPictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipictureframe/) przechowuje swój obraz w `getPictureFormat().getPicture().getImage()`, co zwraca obiekt [IPPImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/).

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

## **Wyodrębnianie Obrazów z Kształtów Wypełnionych Obrazem**

Kształty mogą używać obrazu jako wypełnienia. Najpierw sprawdź typ wypełnienia kształtu: jeśli nie jest to [FillType.Picture](https://reference.aspose.com/slides/pl/java/com.aspose.slides/filltype/), nie ma obrazu do wyodrębnienia z tego wypełnienia. Poniższy przykład obsługuje obiekty [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) i zapisuje każdy obraz jako PNG przy użyciu [IPPImage.getImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/#getImage--).

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

## **Wyodrębnianie Obrazów Podglądu z Ram OLE**

[IOleObjectFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ioleobjectframe/) może mieć zastępczy obraz, którego PowerPoint używa jako podglądu obiektu na slajdzie. Ten obraz jest dostępny przez `getSubstitutePictureFormat().getPicture().getImage()`. Wyodrębnienie tego obrazu daje podgląd, a nie osadzone treści pakietu OLE.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util Set;
import java.util List;

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

## **Wyodrębnianie Obrazów Podglądu z Ram Wideo**

[IVideoFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideoframe/) może również przechowywać obraz podglądu w `getPictureFormat().getPicture().getImage()`. Jest to plakat lub miniatura wyświetlana na slajdzie, a nie klatka zdekodowana z strumienia wideo.

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

## **Wyodrębnianie Obrazów Podglądu z Ram Audio**

[IAudioFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iaudioframe/) może przechowywać miniaturę w `getPictureFormat().getPicture().getImage()`. Jest to obraz wyświetlany dla obiektu audio na slajdzie.

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

## **Wyodrębnianie Obrazów z Obiektów Powiększenia**

Kształty [IZoomFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/izoomframe/) i [ISectionZoomFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isectionzoomframe/) mogą używać niestandardowych obrazów. Odczytaj `getZoomImage()` z ramy powiększenia.

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

## **Wyodrębnianie Obrazów z Ram Podsumowujących Powiększeń**

[ISummaryZoomFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isummaryzoomframe/) jest również kształtem. Jego elementy sekcji mogą używać własnych obrazów, udostępnianych przez metodę `getZoomImage()` każdego podsumowującego ramienia sekcji.

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

## **Wyodrębnianie Obrazów z Kształtów Tabel**

[ITable](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itable/) jest kształtem. Obrazy w tabeli są zazwyczaj przechowywane jako wypełnienia obrazem w komórkach tabeli.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util Set;
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

## **Wyodrębnianie Obrazów z Kształtów Wykresów**

[IChart](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichart/) jest kształtem. Poniższy przykład wyodrębnia obraz z wypełnienia obrazu obszaru wykresu.

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

## **Wyodrębnianie Obrazów z Kształtów SmartArt**

[ISmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ismartart/) jest obiektem kształtu. W zależności od układu SmartArt, obrazy mogą być przechowywane w wypełnieniach punktorów węzłów lub w formatach wypełnienia kształtów węzłów.

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

## **Dołączanie Obrazów w Kształtach Grupowanych**

Kształty grupowane zawierają własne kolekcje kształtów. Wspólna metoda pomocnicza `enumerateShapes` ma opcję `includeGroupedShapes`. Ustaw ją na `true`, gdy chcesz przeglądać kształty wewnątrz obiektów [IGroupShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/igroupshape/). Poniższy przykład wyodrębnia obrazy z ramek obrazów, kształtów wypełnionych obrazem, podglądów obiektów OLE, miniatur klatek wideo i miniatur klatek audio. Aby dołączyć także obrazy tabel, wykresów, SmartArt i podsumowujących powiększeń, użyj specjalistycznej logiki wyodrębniania z poprzednich sekcji, zachowując tę samą rekurencyjną traversację kształtów.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.Set;
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

## **Przypadki Brzegowe i Praktyczne Uwagi**

- **Duplikaty obrazów:** Wielokrotne kształty mogą odwoływać się do tego samego obrazu lub do oddzielnych obrazów o identycznych bajtach. Oblicz skrót [IPPImage.getBinaryData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/#getBinaryData--) przed zapisem plików, jeśli chcesz uzyskać jeden plik wyjściowy na każdy unikalny obraz.
- **Oryginalne dane vs. przekonwertowany wynik:** Zapisując [IPPImage.getBinaryData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/#getBinaryData--) zachowujesz osadzony JPEG, PNG, GIF, SVG, EMF lub WMF. Zapisując [IPPImage.getImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/#getImage--) przy użyciu [IImage.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/#save-java.lang.String-int-) jest przydatny, gdy potrzebny jest spójny format wyjściowy.
- **Nieobsługiwane typy wypełnień:** Kształty o wypełnieniach stałych, gradientowych, wzorcowych i bez wypełnienia nie zawierają obrazu wypełnienia. Sprawdź [FillType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/filltype/) przed odczytem `getPictureFillFormat()`.
- **Kształty grupowane:** Górna kolekcja kształtów slajdu nie spłaszcza grup. Rekursywnie sprawdzaj [IGroupShape.getShapes](https://reference.aspose.com/slides/pl/java/com.aspose.slides/igroupshape/#getShapes--) gdy zawartość grup ma znaczenie.
- **Podglądy obiektów OLE:** [IOleObjectFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ioleobjectframe/) może udostępniać obraz podglądu przez `getSubstitutePictureFormat()`, ale jest to jedynie podgląd slajdu. Nie jest to osadzony plik wewnątrz obiektu OLE.
- **Miniatury klatek wideo:** [IVideoFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideoframe/) może udostępniać obraz podglądu przez `getPictureFormat()`, ale jest to jedynie plakat wyświetlany na slajdzie. Nie jest to klatka wyodrębniona ze strumienia wideo.
- **Miniatury klatek audio:** [IAudioFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iaudioframe/) może udostępniać ikonę lub miniaturę przez `getPictureFormat()`; nie jest to osadzony dźwięk.
- **Obrazy powiększeń:** Kształty powiększenia slajdu, sekcji i podsumowania mogą używać własnych obiektów [IPPImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/) poprzez `getZoomImage()`.
- **Zagnieżdżone modele kształtów:** Obiekty tabel, wykresów i SmartArt implementują [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/), ale ich obrazy często są przechowywane w zagnieżdżonych obiektach formatowania komórek tabeli, elementów wykresu lub węzłów SmartArt.
- **Przycięte lub przekształcone obrazy:** Dostęp do [IPPImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/) daje dostęp do przechowywanego zasobu obrazu. Nie renderuje przycięć, przezroczystości, zmian koloru, rotacji ani innych efektów wizualnych zastosowanych przez kształt.

## **FAQ**

### Czy mogę wyodrębnić oryginalny obraz bez przycinania, efektów lub przekształceń kształtu?

Tak. Uzyskaj obiekt [IPPImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/) i zapisz [IPPImage.getBinaryData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/#getBinaryData--) na dysk. Zachowuje to oryginalnie zakodowany obraz przechowywany w prezentacji, a nie sposób jego renderowania na slajdzie.

### Czy mogę wyeksportować każdy wyodrębniony obraz jako PNG?

Tak. Użyj [IPPImage.getImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/#getImage--) aby uzyskać obiekt [IImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/), a następnie wywołaj [IImage.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/#save-java.lang.String-int-) z [ImageFormat.Png](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imageformat/). To konwertuje wynik i może nie zachować oryginalnego typu pliku ani danych wektorowych.

### Jak uniknąć zapisywania tego samego obrazu więcej niż raz?

Użyj skrótu [IPPImage.getBinaryData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/#getBinaryData--) i przechowuj skróty w zbiorze. Jeśli nowy obraz ma skrót, który już istnieje, pomiń go lub zanotuj kolejne odniesienie do istniejącego pliku wyjściowego.

### Dlaczego niektóre kształty nie generują obrazu?

Ramki obrazów, kształty wypełnione obrazem, ramki obiektów OLE, ramki multimedialne, ramki powiększeń, tabele, wykresy i obiekty SmartArt mogą odwoływać się do obrazów. Niektóre typy kształtów udostępniają obrazy poprzez zagnieżdżone obiekty formatowania, więc proste sprawdzenie `getPictureFormat()` lub `getFillFormat()` nie zawsze wystarczy.

### Czy mogę wyodrębnić miniaturę wyświetlaną dla klatki wideo?

Tak. Użyj [IVideoFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ivideoframe/) i odczytaj `getPictureFormat().getPicture().getImage()`. To wyodrębnia obraz plakatu przechowywany razem z ramą wideo, a nie klatkę wygenerowaną z pliku wideo.

### Jak mogę określić, które kształty używają konkretnego obrazu z kolekcji obrazów prezentacji?

Aspose.Slides nie przechowuje odwrotnych odnośników od [IPPImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/) do kształtów. Zbuduj mapowanie podczas traversacji: za każdym razem, gdy znajdziesz odwołanie do obrazu, zapisz numer slajdu, ścieżkę kształtu oraz skrót obrazu lub pozycję w kolekcji.

### Czy mogę wyodrębnić obrazy osadzone w obiektach OLE, np. dołączonych dokumentach?

Możesz wyodrębnić podgląd slajdu obiektu OLE z [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--). Jednak ten podgląd nie jest samym osadzonym dokumentem. Aby wyodrębnić obrazy z wewnątrz pliku osadzonego, wyodrębnij dane OLE i przeanalizuj je narzędziami przeznaczonymi dla tego typu pliku.