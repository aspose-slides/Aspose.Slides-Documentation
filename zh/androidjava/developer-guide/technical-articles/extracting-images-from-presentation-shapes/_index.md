---
title: 通过 Java 在 Android 中从演示文稿形状提取图像
linktitle: 形状中的图像
type: docs
weight: 100
url: /zh/androidjava/extracting-images-from-presentation-shapes/
keywords:
- 提取图像
- 检索图像
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "通过 Java 使用 Aspose.Slides for Android 从 PowerPoint 和 OpenDocument 演示文稿的形状中提取图像——快速、代码友好的解决方案。"
---
## **概述**

演示文稿中的图像可以出现在多种形状类型中：普通图片框、作为形状填充的图片、OLE 对象预览图像、视频或音频帧的缩略图、缩放图像，或嵌套在表格、图表和 SmartArt 形状中的图像。Aspose.Slides 将这些图像存储在演示文稿的图像集合中，可通过 [IImageCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iimagecollection/) 和 [IPPImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ippimage/) 对象访问。

如果只需要导出演示文稿中嵌入的每个图像资源，只需遍历 `presentation.getImages()`。本文重点介绍另一项任务：遍历形状以查找幻灯片中使用图像的位置，从而在保存文件时保留有用的上下文信息，如幻灯片编号、形状位置以及来源类型（图片框、填充图像、媒体预览、OLE 预览或缩放图像）。

{{% alert title="Tip" color="primary" %}}
使用 [IPPImage.getBinaryData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ippimage/#getBinaryData--) 可保留原始编码的图像数据和文件类型。需要将输出统一为特定格式（例如 PNG）时，可使用 [IPPImage.getImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ippimage/#getImage--) 配合 [IImage.save](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-)。
{{% /alert %}}

## **共享辅助方法**

下面的辅助方法用于保持示例简洁。`saveOriginalImage` 写入原始嵌入字节，从 MIME 类型中选择安全的扩展名，并通过 SHA-256 哈希跳过重复的图像二进制。

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

## **从图片框中提取图像**

对作为独立对象插入的图片使用此方法。[IPictureFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipictureframe/) 将其图片存储在 `getPictureFormat().getPicture().getImage()`，该方法返回一个 [IPPImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ippimage/) 对象。

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

## **从填充图片的形状中提取图像**

形状可以使用图片作为填充。首先检查形状的填充类型：如果不是 [FillType.Picture](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/filltype/)，则不存在可提取的图片。下面的示例处理 [IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/) 对象，并通过 [IPPImage.getImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ippimage/#getImage--) 将每个图像保存为 PNG。

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

## **从 OLE 对象框中提取预览图像**

[IOleObjectFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ioleobjectframe/) 可以拥有 PowerPoint 在幻灯片上用作对象预览的替代图片。该图像可通过 `getSubstitutePictureFormat().getPicture().getImage()` 获取。提取此图片得到的仅是预览图像，而不是嵌入的 OLE 包内容。

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

## **从视频帧中提取预览图像**

[IVideoFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideoframe/) 也可以在 `getPictureFormat().getPicture().getImage()` 中存储预览图像。此图像是幻灯片上显示的海报或缩略图，而不是从视频流中解码的帧。

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

## **从音频帧中提取预览图像**

[IAudioFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iaudioframe/) 可以在 `getPictureFormat().getPicture().getImage()` 中存储缩略图。这是幻灯片上显示的音频对象图标。

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

## **从缩放对象中提取图像**

[IZoomFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/izoomframe/) 和 [ISectionZoomFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/isectionzoomframe/) 形状可以使用自定义图像。请读取缩放帧的 `getZoomImage()`。

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

## **从摘要缩放帧中提取图像**

[ISummaryZoomFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/isummaryzoomframe/) 也是一种形状。其章节项可以使用自定义图像，通过每个摘要缩放章节的 `getZoomImage()` 方法获取。

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

## **从表格形状中提取图像**

[ITable](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itable/) 是一种形状。表格中的图像通常以单元格的图片填充方式存储。

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

## **从图表形状中提取图像**

[IChart](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichart/) 是一种形状。下面的示例从图表区域的图片填充中提取图像。

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

## **从 SmartArt 形状中提取图像**

[ISmartArt](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ismartart/) 对象是一种形状。根据 SmartArt 布局，图像可能存储在节点项目符号填充或节点形状的填充格式中。

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

## **在组合形状中包含图像**

组合形状拥有自己的形状集合。共享的 `enumerateShapes` 辅助方法提供 `includeGroupedShapes` 选项。需要检查 [IGroupShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/igroupshape/) 对象内部的形状时，将其设为 `true`。下面的示例提取图片框、填充图片的形状、OLE 对象预览、视频帧缩略图和音频帧缩略图中的图像。若还想包括表格、图表、SmartArt 和摘要缩放图像，可在保持相同递归形状遍历的前提下，复用前面章节的专用提取逻辑。

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

## **边缘情况和实用说明**

- **重复图像**：多个形状可能引用同一图像，或不同图像的字节完全相同。写入文件前对 [IPPImage.getBinaryData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ippimage/#getBinaryData--) 进行哈希，以实现每个唯一图像仅输出一次。
- **原始数据 vs. 转换后输出**：保存 [IPPImage.getBinaryData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ippimage/#getBinaryData--) 可保留嵌入的 JPEG、PNG、GIF、SVG、EMF 或 WMF 数据。通过 [IPPImage.getImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ippimage/#getImage--) 再调用 [IImage.save](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) 保存时，可统一为一致的输出格式。
- **不支持的填充类型**：实色、渐变、图案和无填充形状不包含图片填充。读取 `getPictureFillFormat()` 前请检查 [FillType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/filltype/)。
- **组合形状**：顶层幻灯片形状集合不会自动展开组合。需要递归检查 [IGroupShape.getShapes](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/igroupshape/#getShapes--)，当组合内容重要时如此操作。
- **OLE 对象预览**：[IOleObjectFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ioleobjectframe/) 可能通过 `getSubstitutePictureFormat()` 暴露预览图像，但该图像仅为幻灯片预览，并非嵌入的 OLE 文件本身。
- **视频帧缩略图**：[IVideoFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideoframe/) 可能通过 `getPictureFormat()` 暴露预览图像，该图像仅为幻灯片上显示的海报，而非从视频流中提取的帧。
- **音频帧缩略图**：[IAudioFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iaudioframe/) 可能通过 `getPictureFormat()` 暴露图标或缩略图；这并非嵌入的音频数据本身。
- **缩放图像**：幻灯片缩放、章节缩放和摘要缩放形状可能通过 `getZoomImage()` 使用自定义的 [IPPImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ippimage/) 对象。
- **嵌套形状模型**：表格、图表和 SmartArt 对象实现了 [IShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/)，但其图像通常存储在嵌套的表格单元格、图表元素或 SmartArt 节点的格式对象中。
- **裁剪或变换的图片**：访问 [IPPImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ippimage/) 只能获取存储的图像资源，不会渲染形状所施加的裁剪、透明度、重新着色、旋转或其他视觉效果。

## **常见问答**

**是否可以在不裁剪、无特效或形状变换的情况下提取原始图像？**  
可以。访问 [IPPImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ippimage/) 对象并将 [IPPImage.getBinaryData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ippimage/#getBinaryData--) 写入磁盘，即可保留演示文稿中存储的原始编码图像，而不是在幻灯片上的渲染方式。

**是否可以将所有提取的图像导出为 PNG？**  
可以。使用 [IPPImage.getImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ippimage/#getImage--) 获取 [IImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iimage/) 对象，然后调用 [IImage.save](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) 并指定 [ImageFormat.Png](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imageformat/) 进行转换。这样会改变输出格式，可能不会保留原始文件类型或矢量数据。

**如何避免多次保存同一图像？**  
对 [IPPImage.getBinaryData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ippimage/#getBinaryData--) 计算哈希并将哈希存入集合。若新图像的哈希已存在，则跳过保存或记录对已有输出文件的另一个引用。

**为什么有些形状没有生成图像？**  
图片框、填充图片的形状、OLE 对象框、媒体框、缩放框、表格、图表和 SmartArt 对象可以引用图像。某些形状类型通过嵌套的格式对象暴露图像，仅检查 `getPictureFormat()` 或形状的 `getFillFormat()` 可能不足以发现所有图像。

**是否可以提取视频帧显示的缩略图？**  
可以。使用 [IVideoFrame.getPictureFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideoframe/#getPictureFormat--) 并读取 `getPictureFormat().getPicture().getImage()`。这将提取随视频帧一起存储的海报图像，而不是从视频文件中生成的帧。

**如何确定演示文稿图像集合中的特定图像被哪些形状使用？**  
Aspose.Slides 不会为 [IPPImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ippimage/) 到形状建立反向链接。遍历时构建映射：每当找到图像引用时，记录幻灯片编号、形状路径以及图像哈希或集合项。

**是否可以提取嵌入在 OLE 对象内部的图像，例如附件文档中的图像？**  
可以从 [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) 提取 OLE 对象的幻灯片预览，但该预览并非嵌入的文档本身。若要提取嵌入文件内部的图像，需要先提取 OLE 数据，然后使用相应文件类型的工具进行检查。