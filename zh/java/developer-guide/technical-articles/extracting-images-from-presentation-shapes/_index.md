---
title: 从 Java 中的演示文稿形状提取图像
linktitle: 形状中的图像
type: docs
weight: 100
url: /zh/java/extracting-images-from-presentation-shapes/
keywords:
- 提取图像
- 获取图像
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 从 PowerPoint 和 OpenDocument 演示文稿中提取形状图像 - 快速、代码友好的解决方案。"
---
## **概述**

演示文稿中的图像可以以多种形状类型出现：普通图片框、用于形状的图片填充、OLE 对象预览图像、视频或音频帧缩略图、缩放图像，或作为嵌套在表格、图表和 SmartArt 形状中的图像。Aspose.Slides 将这些图像存储在演示文稿图像集合中，可通过 [IImageCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides.iimagecollection/) 和 [IPPImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides.ippimage/) 对象访问。

如果您只需导出演示文稿中嵌入的每个图像资源，可遍历 `presentation.getImages()`。本文关注的是另一项任务：遍历形状以查找图像在幻灯片中的使用位置，从而在保存的文件中保留幻灯片编号、形状位置和来源类型（图片框、填充图像、媒体预览、OLE 预览或缩放图像）等有用的上下文。

{{% alert title="Tip" color="primary" %}}
使用 [IPPImage.getBinaryData](https://reference.aspose.com/slides/zh/java/com.aspose.slides.ippimage/#getBinaryData--) 可保留原始编码的图像数据和文件类型。需要将输出统一为特定格式（例如 PNG）时，可使用 [IPPImage.getImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides.ippimage/#getImage--) 配合 [IImage.save](https://reference.aspose.com/slides/zh/java/com.aspose.slides.iimage/#save-java.lang.String-int-)。
{{% /alert %}}

## **共享帮助方法**

下面的帮助方法简化了示例。`saveOriginalImage` 写入原始嵌入字节，根据 MIME 类型选择安全扩展名，并通过 SHA-256 哈希跳过重复的图像二进制数据。

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

## **从图片框提取图像**

对于作为独立对象插入的图片，请使用此方法。[IPictureFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides.ipictureframe/) 将其图片存储在 `getPictureFormat().getPicture().getImage()` 中，返回一个 [IPPImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides.ippimage/) 对象。

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

## **从填充图片的形状提取图像**

形状可以使用图片进行填充。首先检查形状的填充类型：如果不是 [FillType.Picture](https://reference.aspose.com/slides/zh/java/com.aspose.slides.filltype/)，则该填充中不存在可提取的图片。下面的示例处理 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides.iautoshape/) 对象，并通过 [IPPImage.getImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides.ippimage/#getImage--) 将每个图像保存为 PNG。

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

## **从 OLE 对象框提取预览图像**

[IOleObjectFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides.ioleobjectframe/) 可以拥有 PowerPoint 在幻灯片上用作对象预览的替代图片。该图像可通过 `getSubstitutePictureFormat().getPicture().getImage()` 获取。提取此图片得到的是预览图像，而不是嵌入的 OLE 包内容。

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

## **从视频框提取预览图像**

[IVideoFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides.ivideoframe/) 也可以在 `getPictureFormat().getPicture().getImage()` 中存储预览图像。这是幻灯片上显示的海报或缩略图，而不是从视频流解码的帧。

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

## **从音频框提取预览图像**

[IAudioFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides.iaudioframe/) 可以在 `getPictureFormat().getPicture().getImage()` 中存储缩略图。这是幻灯片上音频对象显示的图像。

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

## **从缩放对象提取图像**

[IZoomFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides.izoomframe/) 和 [ISectionZoomFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides.isectionzoomframe/) 形状可以使用自定义图像。请读取缩放框的 `getZoomImage()`。

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

## **从汇总缩放框提取图像**

[ISummaryZoomFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides.isummaryzoomframe/) 同样是形状。其各节项可以使用自定义图像，可通过每个汇总缩放段的 `getZoomImage()` 方法获取。

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

## **从表格形状提取图像**

[ITable](https://reference.aspose.com/slides/zh/java/com.aspose.slides.itable/) 是一种形状。表格中的图像通常存储为单元格的图片填充。

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

## **从图表形状提取图像**

[IChart](https://reference.aspose.com/slides/zh/java/com.aspose.slides.ichart/) 是一种形状。下面的示例从图表区域的图片填充中提取图像。

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

## **从 SmartArt 形状提取图像**

[ISmartArt](https://reference.aspose.com/slides/zh/java/com.aspose.slides.ismartart/) 对象是形状。根据 SmartArt 布局，图像可能存储在节点项目符号填充中或节点形状的填充格式中。

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

## **包括分组形状内部的图像**

分组形状包含自己的形状集合。共享的 `enumerateShapes` 帮助方法具有 `includeGroupedShapes` 选项。当您想检查 [IGroupShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides.igroupshape/) 对象内部的形状时，将其设为 `true`。下面的示例提取图片框、填充图片的形状、OLE 对象预览、视频帧缩略图和音频帧缩略图中的图像。若要同时包括表格、图表、SmartArt 和汇总缩放图像，请在保持相同递归形状遍历的同时，复用前面章节的专用提取逻辑。

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

- **重复图像：** 多个形状可能引用同一图像或不同的但字节相同的图像。在写文件之前对 [IPPImage.getBinaryData](https://reference.aspose.com/slides/zh/java/com.aspose.slides.ippimage/#getBinaryData--) 进行哈希，以便为每个唯一图像生成一个输出文件。
- **原始数据与转换输出：** 保存 [IPPImage.getBinaryData](https://reference.aspose.com/slides/zh/java/com.aspose.slides.ippimage/#getBinaryData--) 能保留嵌入的 JPEG、PNG、GIF、SVG、EMF 或 WMF 数据。通过 [IImage.save](https://reference.aspose.com/slides/zh/java/com.aspose.slides.iimage/#save-java.lang.String-int-) 保存 [IPPImage.getImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides.ippimage/#getImage--) 则在需要统一输出格式时有用。
- **不支持的填充类型：** 实心、渐变、图案和无填充的形状不包含图片填充。在读取 `getPictureFillFormat()` 之前，请检查 [FillType](https://reference.aspose.com/slides/zh/java/com.aspose.slides.filltype/)。
- **分组形状：** 顶层幻灯片形状集合不会展开分组。当分组内容重要时，请递归检查 [IGroupShape.getShapes](https://reference.aspose.com/slides/zh/java/com.aspose.slides.igroupshape/#getShapes--)。
- **OLE 对象预览：** [IOleObjectFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides.ioleobjectframe/) 可能通过 `getSubstitutePictureFormat()` 暴露预览图像，但该图像仅为幻灯片预览，并非 OLE 对象内部嵌入的文件。
- **视频帧缩略图：** [IVideoFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides.ivideoframe/) 可能通过 `getPictureFormat()` 暴露预览图像，但该图像仅为幻灯片上显示的海报，而非从视频流中提取的帧。
- **音频帧缩略图：** [IAudioFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides.iaudioframe/) 可能通过 `getPictureFormat()` 暴露图标或缩略图；这并非嵌入的音频数据。
- **缩放图像：** 幻灯片缩放、章节缩放和汇总缩放形状可能通过 `getZoomImage()` 使用自定义的 [IPPImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides.ippimage/) 对象。
- **嵌套形状模型：** 表格、图表和 SmartArt 对象实现了 [IShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides.ishape/)，但它们的图像通常存储在嵌套的表格单元格、图表元素或 SmartArt 节点格式对象中。
- **裁剪或变换的图片：** 访问 [IPPImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides.ippimage/) 可获得存储的图像资源。但它不会渲染形状所应用的裁剪、透明度、重新着色、旋转或其他视觉效果。

## **常见问题**

**是否可以在不裁剪、效果或形状变换的情况下提取原始图像？**

可以。访问 [IPPImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides.ippimage/) 对象并将 [IPPImage.getBinaryData](https://reference.aspose.com/slides/zh/java/com.aspose.slides.ippimage/#getBinaryData--) 写入磁盘。这样可以保留演示文稿中存储的原始编码图像，而不是图像在幻灯片上的渲染方式。

**是否可以将每个提取的图像导出为 PNG？**

可以。使用 [IPPImage.getImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides.ippimage/#getImage--) 获取 [IImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides.iimage/) 对象，然后使用 [ImageFormat.Png](https://reference.aspose.com/slides/zh/java/com.aspose.slides.imageformat/) 调用 [IImage.save](https://reference.aspose.com/slides/zh/java/com.aspose.slides.iimage/#save-java.lang.String-int-)。这会转换输出，但可能不保留原始文件类型或矢量数据。

**如何避免多次保存同一图像？**

对 [IPPImage.getBinaryData](https://reference.aspose.com/slides/zh/java/com.aspose.slides.ippimage/#getBinaryData--) 进行哈希并将哈希值存入集合。若新图像的哈希已存在，则跳过或记录对已有输出文件的另一个引用。

**为什么某些形状未产生图像？**

图片框、填充图片的形状、OLE 对象框、媒体框、缩放框、表格、图表和 SmartArt 对象可以引用图像。某些形状类型通过嵌套的格式对象暴露图像，仅检查 `getPictureFormat()` 或形状的 `getFillFormat()` 并不足以覆盖所有情况。

**是否可以提取视频帧显示的缩略图？**

可以。使用 [IVideoFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides.ivideoframe/) 并读取 `getPictureFormat().getPicture().getImage()`。这会提取随视频帧存储的海报图像，而不是从视频文件生成的帧。

**如何确定演示文稿图像集合中哪些形状使用了特定图像？**

Aspose.Slides 不存储从 [IPPImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides.ippimage/) 到形状的反向链接。遍历时建立映射：每当发现图像引用时，记录幻灯片编号、形状路径以及图像哈希或集合项。

**是否可以提取嵌入在 OLE 对象内部的图像，例如附加的文档？**

可以从 [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides.ioleobjectframe/#getSubstitutePictureFormat--) 提取 OLE 对象的幻灯片预览。但该预览并非嵌入的文档本身。若要提取嵌入文件内部的图像，需要先提取 OLE 数据，再使用相应文件类型的工具进行检查。