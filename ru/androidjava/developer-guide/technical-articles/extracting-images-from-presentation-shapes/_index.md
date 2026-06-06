---
title: "Извлечение изображений из фигур презентации в Android через Java"
linktitle: "Изображение из фигуры"
type: docs
weight: 100
url: /ru/androidjava/extracting-images-from-presentation-shapes/
keywords:
- извлечь изображение
- получить изображение
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Извлечение изображений из фигур в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Android через Java — быстрое, удобное для кода решение."
---
## **Обзор**

Изображения в презентации могут появляться в нескольких типах фигур: как обычные рамки с изображением, как заливка изображением, как превью‑изображения OLE‑объектов, как миниатюры видео‑ или аудио‑кадров, как изображения зум‑объектов или как изображения, вложенные в таблицы, диаграммы и SmartArt‑фигуры. Aspose.Slides хранит эти изображения в коллекции изображений презентации, доступ к которой осуществляется через объекты [IImageCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagecollection/) и [IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/).

Если вам нужно просто экспортировать каждый ресурс изображения, встроенный в презентацию, переберите `presentation.getImages()`. Эта статья посвящена другой задаче: обходу фигур для поиска использованных изображений на слайдах, чтобы сохраняемые файлы могли содержать полезный контекст, такой как номер слайда, положение фигуры и тип источника (рамка с изображением, заливка, превью медиа, превью OLE или зум‑изображение).

{{% alert title="Tip" color="primary" %}}
Используйте [IPPImage.getBinaryData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/#getBinaryData--) для сохранения оригинальных закодированных данных изображения и типа файла. Используйте [IPPImage.getImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/#getImage--) вместе с [IImage.save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) когда требуется нормализовать вывод в конкретный формат, например PNG.
{{% /alert %}}

## **Общие вспомогательные методы**

Ниже приведены вспомогательные методы, позволяющие сократить примеры. `saveOriginalImage` записывает оригинальные вложенные байты, выбирает безопасное расширение из MIME‑типа и пропускает дублирующие бинарные изображения по хэшу SHA‑256.

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

## **Извлечение изображений из рамок с изображением**

Используйте этот подход для картинок, вставленных как отдельные объекты. [IPictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframe/) хранит свою картинку в `getPictureFormat().getPicture().getImage()`, что возвращает объект [IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/).

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

## **Извлечение изображений из фигур, залитых картинкой**

Фигуры могут использовать картинку в качестве заливки. Сначала проверьте тип заливки фигуры: если это не [FillType.Picture](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/filltype/), картинка для извлечения отсутствует. Пример ниже работает с объектами [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) и сохраняет каждое изображение как PNG через [IPPImage.getImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/#getImage--).

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

## **Извлечение превью‑изображений из рамок OLE‑объектов**

[IOleObjectFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ioleobjectframe/) может иметь заменяющую картинку, которую PowerPoint использует как превью объекта на слайде. Это изображение доступно через `getSubstitutePictureFormat().getPicture().getImage()`. Извлечение этой картинки дает вам превью‑изображение, а не содержимое вложенного OLE‑пакета.

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

## **Извлечение превью‑изображений из видеокадров**

[IVideoFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ivideoframe/) также может хранить превью‑изображение в `getPictureFormat().getPicture().getImage()`. Это постер или миниатюра, отображаемая на слайде, а не кадр, декодированный из видеопотока.

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

## **Извлечение превью‑изображений из аудиокадров**

[IAudioFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iaudioframe/) может хранить миниатюру в `getPictureFormat().getPicture().getImage()`. Это изображение, показываемое для аудио‑объекта на слайде.

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

## **Извлечение изображений из зум‑объектов**

[IZoomFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/izoomframe/) и [ISectionZoomFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isectionzoomframe/) могут использовать пользовательские изображения. Читайте `getZoomImage()` из зум‑кадра.

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

## **Извлечение изображений из Summary Zoom Frames**

[ISummaryZoomFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isummaryzoomframe/) также является фигурой. Ее элементы секций могут использовать пользовательские изображения, доступные через метод `getZoomImage()` каждой секции summary‑зум.

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

## **Извлечение изображений из фигур‑таблиц**

[ITable](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/itable/) является фигурой. Изображения в таблице обычно хранятся как заливка картинкой в ячейках таблицы.

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

## **Извлечение изображений из фигур‑диаграмм**

[IChart](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ichart/) является фигурой. Пример ниже извлекает изображение из заливки области диаграммы.

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

## **Извлечение изображений из фигур‑SmartArt**

[ISmartArt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ismartart/) является фигурой. В зависимости от макета SmartArt изображения могут храниться в заливках маркеров узлов или в форматах заливки фигур узлов.

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

## **Включение изображений внутри сгруппированных фигур**

Сгруппированные фигуры содержат собственные коллекции фигур. Общий вспомогательный метод `enumerateShapes` имеет параметр `includeGroupedShapes`. Установите его в `true`, когда необходимо просматривать фигуры внутри объектов [IGroupShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/igroupshape/). Пример ниже извлекает изображения из рамок с изображением, фигур, залитых картинкой, превью OLE‑объектов, миниатюр видео‑ и аудио‑кадров. Чтобы добавить изображения из таблиц, диаграмм, SmartArt и summary‑zoom, повторно используйте специализированную логику извлечения из предыдущих разделов, сохраняя тот же рекурсивный обход фигур.

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

## **Пограничные случаи и практические замечания**

- **Дублирующие изображения:** Несколько фигур могут ссылаться на одно и то же изображение или на разные изображения с одинаковыми байтами. Хешируйте [IPPImage.getBinaryData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/#getBinaryData--) перед записью файлов, если требуется один файл на уникальное изображение.
- **Оригинальные данные vs. преобразованный вывод:** Сохранение [IPPImage.getBinaryData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/#getBinaryData--) сохраняет внедрённые JPEG, PNG, GIF, SVG, EMF или WMF. Сохранение [IPPImage.getImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/#getImage--) через [IImage.save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) полезно, когда нужен единый формат вывода.
- **Неподдерживаемые типы заливки:** Сплошные, градиентные, шаблонные и беззаливные фигуры не содержат заливку картинкой. Проверьте [FillType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/filltype/) перед чтением `getPictureFillFormat()`.
- **Сгруппированные фигуры:** Коллекция фигур верхнего уровня слайда не разворачивает группы. Рекурсивно проверяйте [IGroupShape.getShapes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/igroupshape/#getShapes--) когда важен контент внутри групп.
- **Превью OLE‑объектов:** [IOleObjectFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ioleobjectframe/) может предоставлять превью‑изображение через `getSubstitutePictureFormat()`, но это лишь превью слайда, а не вложенный файл OLE‑объекта.
- **Миниатюры видеокадров:** [IVideoFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ivideoframe/) может предоставлять превью‑изображение через `getPictureFormat()`, но это только постер, а не кадр, извлечённый из видеопотока.
- **Миниатюры аудиокадров:** [IAudioFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iaudioframe/) может предоставлять иконку или миниатюру через `getPictureFormat()`; это не сами аудио‑данные.
- **Зум‑изображения:** Фигуры slide‑zoom, section‑zoom и summary‑zoom могут использовать пользовательские объекты [IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/) через `getZoomImage()`.
- **Вложенные модели фигур:** Таблицы, диаграммы и SmartArt реализуют [IShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/), но их изображения часто хранятся в вложенных объектах форматирования ячеек таблицы, элементов диаграммы или узлов SmartArt.
- **Обрезанные или трансформированные картинки:** Доступ к [IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/) даёт вам хранимый ресурс изображения. Он не учитывает обрезку, прозрачность, перецветку, вращение или другие визуальные эффекты, применённые фигурой.

## **FAQ**

**Могу ли я извлечь оригинальное изображение без обрезки, эффектов или трансформаций фигуры?**

Да. Получите объект [IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/) и запишите [IPPImage.getBinaryData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/#getBinaryData--) на диск. Это сохраняет оригинальное закодированное изображение, хранящееся в презентации, а не его визуальное представление на слайде.

**Можно ли экспортировать каждое извлечённое изображение как PNG?**

Да. Используйте [IPPImage.getImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/#getImage--) чтобы получить объект [IImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/), затем вызовите [IImage.save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) с параметром [ImageFormat.Png](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imageformat/). Это преобразует вывод и может не сохранить оригинальный тип файла или векторные данные.

**Как избежать многократного сохранения одного и того же изображения?**

Создайте хеш от [IPPImage.getBinaryData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/#getBinaryData--) и храните хеши в наборе. Если новое изображение имеет уже существующий хеш, пропустите его или запишите другую ссылку на уже созданный файл.

**Почему некоторые фигуры не дают изображения?**

Рамки с изображением, фигуры, залитые картинкой, OLE‑рамки, медиа‑рамки, зум‑рамки, таблицы, диаграммы и SmartArt могут ссылаться на изображения. Некоторые типы фигур раскрывают изображения через вложенные объекты форматирования, поэтому простая проверка `getPictureFormat()` или `getFillFormat()` не всегда достаточна.

**Можно ли извлечь миниатюру, отображаемую для видеокадра?**

Да. Используйте [IVideoFrame.getPictureFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ivideoframe/#getPictureFormat--) и прочитайте `getPictureFormat().getPicture().getImage()`. Это извлечёт постер‑изображение, хранящееся вместе с видеокадром, а не кадр, сгенерированный из видеофайла.

**Как определить, какие фигуры используют конкретное изображение из коллекции изображений презентации?**

Aspose.Slides не хранит обратные ссылки от [IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/) к фигурам. Постройте отображение во время обхода: каждый раз, когда находите ссылку на изображение, фиксируйте номер слайда, путь к фигуре и хеш или элемент коллекции.

**Могу ли я извлечь изображения, вложенные в OLE‑объекты, например, прикреплённые документы?**

Вы можете извлечь превью‑изображение OLE‑объекта через [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--). Однако это превью не является самим вложенным документом. Чтобы извлечь изображения изнутри вложенного файла, сначала извлеките данные OLE‑объекта и проанализируйте их с помощью соответствующих инструментов.