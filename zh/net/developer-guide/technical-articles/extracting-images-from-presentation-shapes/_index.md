---
title: 在 .NET 中从演示文稿形状提取图像
linktitle: 形状图像
type: docs
weight: 90
url: /zh/net/extracting-images-from-presentation-shapes/
keywords:
- 提取图像
- 检索图像
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 从 PowerPoint 和 OpenDocument 演示文稿的形状中提取图像 - 快速、代码友好的解决方案。"
---
## **概述**

演示文稿中的图像可以出现在多种形状类型中：普通图片框、作为形状填充的图片、OLE 对象预览图像、视频或音频帧缩略图、缩放图像，或嵌套在表格、图表和 SmartArt 形状中的图像。Aspose.Slides 将这些图像存储在演示文稿的图像集合中，可通过 [ImageCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/imagecollection/) 和 [IPPImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/) 对象访问。

如果您只需要导出演示文稿中嵌入的每个图像资源，请遍历 `presentation.Images`。本文重点介绍另一种任务：遍历形状以查找图像在幻灯片中的使用位置，从而在保存文件时保留幻灯片编号、形状位置和来源类型（图片框、填充图片、媒体预览、OLE 预览或缩放图像）等有用上下文。

{{% alert title="Tip" color="primary" %}}
使用 [IPPImage.BinaryData](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/) 来保留原始的编码图像数据和文件类型。当您想将输出规范化为特定格式（如 PNG）时，使用 [IPPImage.Image](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/) 与 [IImage.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/)。
{{% /alert %}}

## **共享帮助方法**

下面的帮助方法使示例保持简短。`SaveOriginalImage` 写入原始嵌入字节，从 MIME 类型选择安全的扩展名，并通过 SHA-256 哈希跳过重复的图像二进制。

```c#
using Aspose.Slides;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

private static bool SaveOriginalImage(
    IPPImage image,
    string outputDirectory,
    string fileNameBase,
    ISet<string> savedImageHashes)
{
    byte[] imageData = image.BinaryData;
    string imageHash = GetSha256Hash(imageData);
    if (!savedImageHashes.Add(imageHash))
    {
        return false;
    }

    string extension = GetExtensionFromContentType(image.ContentType);
    string fileName = $"{fileNameBase}.{extension}";
    string outputPath = Path.Combine(outputDirectory, fileName);
    File.WriteAllBytes(outputPath, imageData);
    return true;
}

private static void SaveImageAsPng(IPPImage image, string outputDirectory, string fileNameBase)
{
    string fileName = $"{fileNameBase}.png";
    string outputPath = Path.Combine(outputDirectory, fileName);

    using (IImage outputImage = image.Image)
    {
        outputImage.Save(outputPath, ImageFormat.Png);
    }
}

private static IPPImage GetPictureFillImage(IFillFormat fillFormat)
{
    if (fillFormat == null || fillFormat.FillType != FillType.Picture)
    {
        return null;
    }

    return fillFormat.PictureFillFormat.Picture.Image;
}

private static IEnumerable<(IShape Shape, string NamePart)> EnumerateShapes(
    IShapeCollection shapes,
    string prefix,
    bool includeGroupedShapes)
{
    int shapeCount = shapes.Count;
    for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        IShape shape = shapes[shapeIndex];
        int displayIndex = shapeIndex + 1;
        string shapeNamePart = $"{prefix}_shape_{displayIndex}";
        yield return (shape, shapeNamePart);

        if (includeGroupedShapes && shape is IGroupShape groupShape)
        {
            foreach ((IShape Shape, string NamePart) childShape in EnumerateShapes(
                groupShape.Shapes,
                shapeNamePart,
                includeGroupedShapes))
            {
                yield return childShape;
            }
        }
    }
}

private static string GetSha256Hash(byte[] data)
{
    using (SHA256 sha256 = SHA256.Create())
    {
        byte[] hash = sha256.ComputeHash(data);
        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
    }
}

private static string GetExtensionFromContentType(string contentType)
{
    if (string.IsNullOrWhiteSpace(contentType))
    {
        return "bin";
    }

    string mediaType = contentType.Split(';')[0].Trim().ToLowerInvariant();
    switch (mediaType)
    {
        case "image/jpeg":
            return "jpg";
        case "image/png":
            return "png";
        case "image/gif":
            return "gif";
        case "image/bmp":
            return "bmp";
        case "image/tiff":
            return "tiff";
        case "image/x-emf":
        case "image/emf":
            return "emf";
        case "image/x-wmf":
        case "image/wmf":
            return "wmf";
        case "image/svg+xml":
            return "svg";
        default:
            if (mediaType.StartsWith("image/"))
            {
                string extension = mediaType.Substring("image/".Length);
                return MakeSafeFileNamePart(extension);
            }

            return "bin";
    }
}

private static string MakeSafeFileNamePart(string value)
{
    foreach (char invalidCharacter in Path.GetInvalidFileNameChars())
    {
        value = value.Replace(invalidCharacter, '_');
    }

    return value;
}
```

## **从图片框提取图像**

该方法适用于作为独立对象插入的图片。一个 [IPictureFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ipictureframe/) 将其图片存储在 `PictureFormat.Picture.Image`，该属性返回一个 [IPPImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/) 对象。

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "extracted-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IPictureFrame pictureFrame)
            {
                IPPImage image = pictureFrame.PictureFormat.Picture.Image;
                SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
            }
        }
    }
}
```

## **从填充图片的形状提取图像**

形状可以使用图片作为填充。首先检查形状的填充类型：如果不是 [FillType.Picture](https://reference.aspose.com/slides/zh/net/aspose.slides/filltype/)，则没有可提取的图片。下面的示例处理 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/) 对象，并通过 [IPPImage.Image](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/) 将每个图像保存为 PNG。

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "shape-fill-images");
Directory.CreateDirectory(outputDirectory);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IAutoShape autoShape)
            {
                IPPImage image = GetPictureFillImage(autoShape.FillFormat);
                if (image != null)
                {
                    SaveImageAsPng(image, outputDirectory, item.NamePart);
                }
            }
        }
    }
}
```

## **从 OLE 对象框提取预览图像**

[IOleObjectFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ioleobjectframe/) 可以拥有 PowerPoint 用作对象预览的替代图片。该图片可通过 `SubstitutePictureFormat.Picture.Image` 访问。提取此图片可得到预览图像，而不是嵌入的 OLE 包内容。

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "ole-preview-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IOleObjectFrame oleObjectFrame)
            {
                IPPImage image = oleObjectFrame.SubstitutePictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_ole_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **从视频帧提取预览图像**

[IVideoFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ivideoframe/) 也可以在 `PictureFormat.Picture.Image` 中存储预览图像。这是幻灯片上显示的海报或缩略图，而不是从视频流中解码的帧。

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "video-preview-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IVideoFrame videoFrame)
            {
                IPPImage image = videoFrame.PictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_video_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **从音频帧提取预览图像**

[IAudioFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/iaudioframe/) 可以在 `PictureFormat.Picture.Image` 中存储缩略图。这是幻灯片上为音频对象显示的图像。

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "audio-preview-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IAudioFrame audioFrame)
            {
                IPPImage image = audioFrame.PictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_audio_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **从缩放对象提取图像**

[IZoomFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/izoomframe/) 和 [ISectionZoomFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/isectionzoomframe/) 形状可以使用自定义图像。读取缩放框的 `ZoomImage`。

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "zoom-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IZoomFrame zoomFrame && zoomFrame.ZoomImage != null)
            {
                string fileNameBase = $"{item.NamePart}_zoom";
                SaveOriginalImage(zoomFrame.ZoomImage, outputDirectory, fileNameBase, savedImageHashes);
                continue;
            }

            if (item.Shape is ISectionZoomFrame sectionZoomFrame && sectionZoomFrame.ZoomImage != null)
            {
                string fileNameBase = $"{item.NamePart}_section_zoom";
                SaveOriginalImage(sectionZoomFrame.ZoomImage, outputDirectory, fileNameBase, savedImageHashes);
                continue;
            }

        }
    }
}
```

## **从摘要缩放框提取图像**

[ISummaryZoomFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/isummaryzoomframe/) 也是一种形状。其章节项可以使用自定义图像，通过每个摘要缩放章节的 `ZoomImage` 属性公开。

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "summary-zoom-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is ISummaryZoomFrame summaryZoomFrame)
            {
                int sectionCount = summaryZoomFrame.SummaryZoomCollection.Count;
                for (int sectionIndex = 0; sectionIndex < sectionCount; sectionIndex++)
                {
                    ISummaryZoomSection section = summaryZoomFrame.SummaryZoomCollection[sectionIndex];
                    if (section.ZoomImage != null)
                    {
                        int displayIndex = sectionIndex + 1;
                        string fileNameBase = $"{item.NamePart}_summary_zoom_{displayIndex}";
                        SaveOriginalImage(section.ZoomImage, outputDirectory, fileNameBase, savedImageHashes);
                    }
                }
            }
        }
    }
}
```

## **从表格形状提取图像**

[ITable](https://reference.aspose.com/slides/zh/net/aspose.slides/itable/) 是一种形状。表格中的图像通常以图片填充的形式存储在单元格中。

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "table-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: true))
        {
            if (item.Shape is ITable table)
            {
                int rowCount = table.Rows.Count;
                int columnCount = table.Columns.Count;
                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                    {
                        ICell cell = table[columnIndex, rowIndex];
                        IPPImage image = GetPictureFillImage(cell.CellFormat.FillFormat);
                        if (image != null)
                        {
                            string fileNameBase = $"{item.NamePart}_cell_{rowIndex + 1}_{columnIndex + 1}";
                            SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }
}
```

## **从图表形状提取图像**

[IChart](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichart/) 是一种形状。下面的示例从图表区域的图片填充中提取图像。

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "chart-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: true))
        {
            if (item.Shape is Aspose.Slides.Charts.IChart chart)
            {
                IFillFormat fillFormat = chart.FillFormat;
                IPPImage image = GetPictureFillImage(fillFormat);
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_chart_area";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **从 SmartArt 形状提取图像**

[ISmartArt](https://reference.aspose.com/slides/zh/net/aspose.slides.smartart/ismartart/) 对象是形状。根据 SmartArt 布局，图像可能存储在节点项目符号填充中或节点形状的填充格式中。

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "smartart-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: true))
        {
            if (item.Shape is Aspose.Slides.SmartArt.ISmartArt smartArt)
            {
                int nodeCount = smartArt.AllNodes.Count;
                for (int nodeIndex = 0; nodeIndex < nodeCount; nodeIndex++)
                {
                    Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes[nodeIndex];
                    IPPImage bulletImage = GetPictureFillImage(node.BulletFillFormat);
                    if (bulletImage != null)
                    {
                        string fileNameBase = $"{item.NamePart}_smartart_node_{nodeIndex + 1}_bullet";
                        SaveOriginalImage(bulletImage, outputDirectory, fileNameBase, savedImageHashes);
                    }

                    int nodeShapeCount = node.Shapes.Count;
                    for (int nodeShapeIndex = 0; nodeShapeIndex < nodeShapeCount; nodeShapeIndex++)
                    {
                        var nodeShape = node.Shapes[nodeShapeIndex];
                        IPPImage image = GetPictureFillImage(nodeShape.FillFormat);
                        if (image != null)
                        {
                            string fileNameBase = $"{item.NamePart}_smartart_node_{nodeIndex + 1}_shape_{nodeShapeIndex + 1}";
                            SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }
}
```

## **包括分组形状中的图像**

分组形状拥有自己的形状集合。共享的 `EnumerateShapes` 帮助方法提供 `includeGroupedShapes` 选项。希望检查 [IGroupShape](https://reference.aspose.com/slides/zh/net/aspose.slides/igroupshape/) 对象内部形状时，将其设为 `true`。下面的示例从图片框、填充图片的形状、OLE 对象预览、视频帧缩略图和音频帧缩略图中提取图像。若还想包括表格、图表、SmartArt 和摘要缩放图像，只需在保持相同递归遍历的前提下复用前面章节的专用提取逻辑。

```c#
string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "all-shape-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: true))
        {
            if (item.Shape is IPictureFrame pictureFrame)
            {
                IPPImage image = pictureFrame.PictureFormat.Picture.Image;
                SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
                continue;
            }

            if (item.Shape is IAutoShape autoShape)
            {
                IPPImage image = GetPictureFillImage(autoShape.FillFormat);
                if (image != null)
                {
                    SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
                }

                continue;
            }

            if (item.Shape is IOleObjectFrame oleObjectFrame)
            {
                IPPImage image = oleObjectFrame.SubstitutePictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_ole_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (item.Shape is IVideoFrame videoFrame)
            {
                IPPImage image = videoFrame.PictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_video_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (item.Shape is IAudioFrame audioFrame)
            {
                IPPImage image = audioFrame.PictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_audio_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **边缘情况和实用说明**

- **重复图像：** 多个形状可能引用同一图像，或不同图像但字节完全相同。写入文件前对 [IPPImage.BinaryData](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/) 进行哈希，可实现每个唯一图像只输出一次。
- **原始数据 vs. 转换输出：** 保存 [IPPImage.BinaryData](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/) 会保留嵌入的 JPEG、PNG、GIF、SVG、EMF 或 WMF 数据。通过 [IPPImage.Image](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/) 再调用 [IImage.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/) 则适用于需要统一输出格式的场景。
- **不支持的填充类型：** 实色、渐变、图案和无填充的形状不包含图片填充。读取 `PictureFillFormat` 前请先检查 [FillType](https://reference.aspose.com/slides/zh/net/aspose.slides/filltype/)。
- **分组形状：** 顶层幻灯片形状集合不会自动展开组。需要递归检查 [IGroupShape.Shapes](https://reference.aspose.com/slides/zh/net/aspose.slides/igroupshape/) 以获取组内内容。
- **OLE 对象预览：** [IOleObjectFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ioleobjectframe/) 可能通过 `SubstitutePictureFormat` 暴露预览图像，但该图像仅用于幻灯片预览，非 OLE 对象内部的嵌入文件。
- **视频帧缩略图：** [IVideoFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ivideoframe/) 可能通过 `PictureFormat` 暴露预览图像，但该图像仅是幻灯片上显示的海报，不是从视频流中提取的帧。
- **音频帧缩略图：** [IAudioFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/iaudioframe/) 可能通过 `PictureFormat` 暴露图标或缩略图；这并不是嵌入的音频数据。
- **缩放图像：** 幻灯片缩放、章节缩放和摘要缩放形状可能通过 `ZoomImage` 使用自定义 [IPPImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/) 对象。
- **嵌套形状模型：** 表格、图表和 SmartArt 对象实现了 [IShape](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/)，但它们的图像通常存储在嵌套的单元格、图表元素或 SmartArt 节点的格式对象中。
- **裁剪或变换的图片：** 访问 [IPPImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/) 能获取存储的图像资源。它不包含形状所施加的裁剪、透明度、重新着色、旋转或其他视觉效果。

## **常见问题**

**是否可以在不裁剪、不应用效果或形状变换的情况下提取原始图像？**

可以。访问 [IPPImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/) 对象并将 [IPPImage.BinaryData](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/) 写入磁盘，即可保留演示文稿中存储的原始编码图像，而不是在幻灯片上渲染后的效果。

**是否可以将所有提取的图像导出为 PNG？**

可以。使用 [IPPImage.Image](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/) 获取 [IImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/) 对象，然后调用 [IImage.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/) 并指定 [ImageFormat.Png](https://reference.aspose.com/slides/zh/net/aspose.slides/imageformat/) 。这会将输出转换为 PNG，但可能不保留原始文件类型或矢量数据。

**如何避免对同一图像多次保存？**

对 [IPPImage.BinaryData](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/) 计算哈希并将哈希存入集合。若新图像的哈希已存在，则跳过保存或记录对已有输出文件的另一个引用。

**为什么有些形状没有生成图像？**

图片框、填充图片的形状、OLE 对象框、媒体框、缩放框、表格、图表和 SmartArt 对象都可以引用图像。某些形状类型通过嵌套的格式对象暴露图像，仅检查 `PictureFormat` 或形状的 `FillFormat` 并不足以捕获所有情况。

**是否可以提取视频帧显示的缩略图？**

可以。使用 [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ivideoframe/) 并读取 `PictureFormat.Picture.Image` 即可提取随视频帧存储的海报图像，而不是从视频文件中生成的帧。

**如何确定哪些形状使用了演示文稿图像集合中的特定图像？**

Aspose.Slides 不会为 [IPPImage](https://reference.aspose.com/slides/zh/net/aspose.slides/ippimage/) 保存指向形状的反向链接。遍历时建立映射：每当发现图像引用时，记录幻灯片编号、形状路径以及图像哈希或集合项。

**能否提取嵌入在 OLE 对象内部的图像（例如附带的文档）？**

您可以通过 [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ioleobjectframe/) 提取 OLE 对象的幻灯片预览图像。但该预览图像并非嵌入的文档本身。要提取嵌入文件内部的图像，需要先提取 OLE 数据并使用相应文件类型的工具进行检查。