---
title: 从 C++ 演示文稿形状中提取图像
linktitle: 形状中的图像
type: docs
weight: 90
url: /zh/cpp/extracting-images-from-presentation-shapes/
keywords:
- 提取图像
- 检索图像
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 从 PowerPoint 和 OpenDocument 演示文稿的形状中提取图像 —— 快速、代码友好的解决方案。"
---
## **概述**

演示文稿中的图像可以出现在多种形状类型中：普通图片框、填充到形状的图片、OLE 对象的预览图像、视频或音频帧的缩略图、缩放图像，或嵌入表格、图表和 SmartArt 形状中的图像。Aspose.Slides 将这些图像存储在演示文稿的图像集合中，可通过 [IImageCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimagecollection/) 和 [IPPImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/) 对象访问。

如果只需要导出演示文稿中嵌入的每个图像资源，请遍历 `presentation->get_Images()`。本文关注的是另一项任务：遍历形状以查找幻灯片中使用图像的位置，从而在保存文件时保留有用的上下文信息，如幻灯片编号、形状位置以及来源类型（图片框、填充图片、媒体预览、OLE 预览或缩放图像）。

{{% alert title="提示" color="primary" %}}

使用 [IPPImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/)::`get_BinaryData()` 可保留原始的编码图像数据及文件类型。使用 [IPPImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/)::`get_Image()` 并结合 [IImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimage/)::`Save` 时，可将输出规范化为特定格式（如 PNG）。

{{% /alert %}}

## **共享帮助方法**

下面的帮助方法用于简化示例。`SaveOriginalImage` 写入原始嵌入字节，根据 MIME 类型选择安全的扩展名，并通过 SHA-256 哈希跳过重复的图像二进制。

```cpp
#include <vector>
#include <system/array.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <security/cryptography/hash_algorithm.h>
#include <system/text/string_builder.h>
#include <DOM/FillType.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGroupShape.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlidesPicture.h>
#include <IImage.h>
#include <ImageFormat.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace System::Security::Cryptography;
using namespace System::Text;

struct ShapeInfo
{
    SharedPtr<IShape> Shape;
    String NamePart;
};

String GetSha256Hash(ArrayPtr<uint8_t> data);
String GetExtensionFromContentType(String contentType);
String MakeSafeFileNamePart(String value);

bool SaveOriginalImage(
    SharedPtr<IPPImage> image,
    String outputDirectory,
    String fileNameBase,
    SharedPtr<HashSet<String>> savedImageHashes)
{
    auto imageData = image->get_BinaryData();
    String imageHash = GetSha256Hash(imageData);
    if (!savedImageHashes->Add(imageHash))
    {
        return false;
    }

    String extension = GetExtensionFromContentType(image->get_ContentType());
    String fileName = String::Format(u"{0}.{1}", fileNameBase, extension);
    String outputPath = Path::Combine(outputDirectory, fileName);
    File::WriteAllBytes(outputPath, imageData);
    return true;
}

void SaveImageAsPng(SharedPtr<IPPImage> image, String outputDirectory, String fileNameBase)
{
    String fileName = String::Format(u"{0}.png", fileNameBase);
    String outputPath = Path::Combine(outputDirectory, fileName);

    auto outputImage = image->get_Image();
    outputImage->Save(outputPath, ImageFormat::Png);
    outputImage->Dispose();
}

SharedPtr<IPPImage> GetPictureFillImage(SharedPtr<IFillFormat> fillFormat)
{
    if (fillFormat == nullptr || fillFormat->get_FillType() != FillType::Picture)
    {
        return nullptr;
    }

    return fillFormat->get_PictureFillFormat()->get_Picture()->get_Image();
}

void EnumerateShapes(
    SharedPtr<IShapeCollection> shapes,
    String prefix,
    bool includeGroupedShapes,
    std::vector<ShapeInfo>& result)
{
    int shapeCount = shapes->get_Count();
    for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        auto shape = shapes->idx_get(shapeIndex);
        int displayIndex = shapeIndex + 1;
        String shapeNamePart = String::Format(u"{0}_shape_{1}", prefix, displayIndex);
        result.push_back({ shape, shapeNamePart });

        auto groupShape = System::AsCast<IGroupShape>(shape);
        if (includeGroupedShapes && groupShape != nullptr)
        {
            EnumerateShapes(groupShape->get_Shapes(), shapeNamePart, includeGroupedShapes, result);
        }
    }
}

String GetSha256Hash(ArrayPtr<uint8_t> data)
{
    auto sha256 = HashAlgorithm::Create(u"SHA256");
    auto hash = sha256->ComputeHash(data);
    auto builder = MakeObject<StringBuilder>();

    int hashLength = hash->get_Length();
    for (int index = 0; index < hashLength; index++)
    {
        uint8_t hashByte = hash[index];
        builder->Append(String::Format(u"{0:x2}", hashByte));
    }

    sha256->Dispose();
    return builder->ToString();
}

String GetExtensionFromContentType(String contentType)
{
    if (String::IsNullOrWhiteSpace(contentType))
    {
        return u"bin";
    }

    int separatorIndex = contentType.IndexOf(u";");
    String mediaType = separatorIndex >= 0 ? contentType.Substring(0, separatorIndex) : contentType;
    mediaType = mediaType.Trim().ToLower();

    if (mediaType == u"image/jpeg")
    {
        return u"jpg";
    }
    if (mediaType == u"image/png")
    {
        return u"png";
    }
    if (mediaType == u"image/gif")
    {
        return u"gif";
    }
    if (mediaType == u"image/bmp")
    {
        return u"bmp";
    }
    if (mediaType == u"image/tiff")
    {
        return u"tiff";
    }
    if (mediaType == u"image/x-emf" || mediaType == u"image/emf")
    {
        return u"emf";
    }
    if (mediaType == u"image/x-wmf" || mediaType == u"image/wmf")
    {
        return u"wmf";
    }
    if (mediaType == u"image/svg+xml")
    {
        return u"svg";
    }
    if (mediaType.StartsWith(u"image/"))
    {
        String extension = mediaType.Substring(String(u"image/").get_Length());
        return MakeSafeFileNamePart(extension);
    }

    return u"bin";
}

String MakeSafeFileNamePart(String value)
{
    auto invalidCharacters = Path::GetInvalidFileNameChars();
    int invalidCharacterCount = invalidCharacters->get_Length();
    for (int index = 0; index < invalidCharacterCount; index++)
    {
        value = value.Replace(invalidCharacters[index], u'_');
    }

    return value;
}
```

## **从图片框提取图像**

对作为独立对象插入的图片使用此方法。[IPictureFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipictureframe/) 将其图片存储在 `get_PictureFormat()->get_Picture()->get_Image()` 中，返回一个 [IPPImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/) 对象。

```cpp
String inputPath = u"sample.pptx";
String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"extracted-images");
Directory::CreateDirectory_(outputDirectory);

auto savedImageHashes = MakeObject<HashSet<String>>();

auto presentation = MakeObject<Presentation>(inputPath);
int slideCount = presentation->get_Slides()->get_Count();
for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

    std::vector<ShapeInfo> shapeInfos;
    EnumerateShapes(slide->get_Shapes(), slidePrefix, false, shapeInfos);

    for (const ShapeInfo& item : shapeInfos)
    {
        auto pictureFrame = System::AsCast<IPictureFrame>(item.Shape);
        if (pictureFrame != nullptr)
        {
            auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
            SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
        }
    }
}

presentation->Dispose();
```

## **从填充图片的形状提取图像**

形状可以使用图片作为填充。首先检查形状的填充类型：如果不是 [FillType](https://reference.aspose.com/slides/zh/cpp/aspose.slides/filltype/)::`Picture`，则该填充中没有图片可提取。下面的示例处理 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/) 对象，并通过 [IPPImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/)::`get_Image()` 将每个图像保存为 PNG。

```cpp
String inputPath = u"sample.pptx";
String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"shape-fill-images");
Directory::CreateDirectory_(outputDirectory);

auto presentation = MakeObject<Presentation>(inputPath);
int slideCount = presentation->get_Slides()->get_Count();
for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

    std::vector<ShapeInfo> shapeInfos;
    EnumerateShapes(slide->get_Shapes(), slidePrefix, false, shapeInfos);

    for (const ShapeInfo& item : shapeInfos)
    {
        auto autoShape = System::AsCast<IAutoShape>(item.Shape);
        if (autoShape != nullptr)
        {
            auto image = GetPictureFillImage(autoShape->get_FillFormat());
            if (image != nullptr)
            {
                SaveImageAsPng(image, outputDirectory, item.NamePart);
            }
        }
    }
}

presentation->Dispose();
```

## **从 OLE 对象框提取预览图像**

[IOleObjectFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ioleobjectframe/) 可以有 PowerPoint 用作对象在幻灯片上预览的替代图片。该图像可通过 `get_SubstitutePictureFormat()->get_Picture()->get_Image()` 获取。提取此图片得到的是预览图像，而不是嵌入的 OLE 包内容。

```cpp
String inputPath = u"sample.pptx";
String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"ole-preview-images");
Directory::CreateDirectory_(outputDirectory);

auto savedImageHashes = MakeObject<HashSet<String>>();

auto presentation = MakeObject<Presentation>(inputPath);
int slideCount = presentation->get_Slides()->get_Count();
for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

    std::vector<ShapeInfo> shapeInfos;
    EnumerateShapes(slide->get_Shapes(), slidePrefix, false, shapeInfos);

    for (const ShapeInfo& item : shapeInfos)
    {
        auto oleObjectFrame = System::AsCast<IOleObjectFrame>(item.Shape);
        if (oleObjectFrame != nullptr)
        {
            auto image = oleObjectFrame->get_SubstitutePictureFormat()->get_Picture()->get_Image();
            if (image != nullptr)
            {
                String fileNameBase = String::Format(u"{0}_ole_preview", item.NamePart);
                SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
            }
        }
    }
}

presentation->Dispose();
```

## **从视频帧提取预览图像**

[IVideoFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideoframe/) 也可以在 `get_PictureFormat()->get_Picture()->get_Image()` 中存储预览图像。这是幻灯片上显示的海报或缩略图，而不是从视频流中解码的帧。

```cpp
String inputPath = u"sample.pptx";
String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"video-preview-images");
Directory::CreateDirectory_(outputDirectory);

auto savedImageHashes = MakeObject<HashSet<String>>();

auto presentation = MakeObject<Presentation>(inputPath);
int slideCount = presentation->get_Slides()->get_Count();
for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

    std::vector<ShapeInfo> shapeInfos;
    EnumerateShapes(slide->get_Shapes(), slidePrefix, false, shapeInfos);

    for (const ShapeInfo& item : shapeInfos)
    {
        auto videoFrame = System::AsCast<IVideoFrame>(item.Shape);
        if (videoFrame != nullptr)
        {
            auto image = videoFrame->get_PictureFormat()->get_Picture()->get_Image();
            if (image != nullptr)
            {
                String fileNameBase = String::Format(u"{0}_video_preview", item.NamePart);
                SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
            }
        }
    }
}

presentation->Dispose();
```

## **从音频帧提取预览图像**

[IAudioFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iaudioframe/) 可以在 `get_PictureFormat()->get_Picture()->get_Image()` 中存储缩略图。这是幻灯片上音频对象显示的图像。

```cpp
String inputPath = u"sample.pptx";
String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"audio-preview-images");
Directory::CreateDirectory_(outputDirectory);

auto savedImageHashes = MakeObject<HashSet<String>>();

auto presentation = MakeObject<Presentation>(inputPath);
int slideCount = presentation->get_Slides()->get_Count();
for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

    std::vector<ShapeInfo> shapeInfos;
    EnumerateShapes(slide->get_Shapes(), slidePrefix, false, shapeInfos);

    for (const ShapeInfo& item : shapeInfos)
    {
        auto audioFrame = System::AsCast<IAudioFrame>(item.Shape);
        if (audioFrame != nullptr)
        {
            auto image = audioFrame->get_PictureFormat()->get_Picture()->get_Image();
            if (image != nullptr)
            {
                String fileNameBase = String::Format(u"{0}_audio_preview", item.NamePart);
                SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
            }
        }
    }
}

presentation->Dispose();
```

## **从缩放对象提取图像**

[IZoomFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/izoomframe/) 和 [ISectionZoomFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isectionzoomframe/) 形状可以使用自定义图像。读取缩放框的 `get_ZoomImage()`。

```cpp
String inputPath = u"sample.pptx";
String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"zoom-images");
Directory::CreateDirectory_(outputDirectory);

auto savedImageHashes = MakeObject<HashSet<String>>();

auto presentation = MakeObject<Presentation>(inputPath);
int slideCount = presentation->get_Slides()->get_Count();
for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

    std::vector<ShapeInfo> shapeInfos;
    EnumerateShapes(slide->get_Shapes(), slidePrefix, false, shapeInfos);

    for (const ShapeInfo& item : shapeInfos)
    {
        auto zoomFrame = System::AsCast<IZoomFrame>(item.Shape);
        if (zoomFrame != nullptr && zoomFrame->get_ZoomImage() != nullptr)
        {
            String fileNameBase = String::Format(u"{0}_zoom", item.NamePart);
            SaveOriginalImage(zoomFrame->get_ZoomImage(), outputDirectory, fileNameBase, savedImageHashes);
            continue;
        }

        auto sectionZoomFrame = System::AsCast<ISectionZoomFrame>(item.Shape);
        if (sectionZoomFrame != nullptr && sectionZoomFrame->get_ZoomImage() != nullptr)
        {
            String fileNameBase = String::Format(u"{0}_section_zoom", item.NamePart);
            SaveOriginalImage(sectionZoomFrame->get_ZoomImage(), outputDirectory, fileNameBase, savedImageHashes);
            continue;
        }
    }
}

presentation->Dispose();
```

## **从摘要缩放框提取图像**

[ISummaryZoomFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isummaryzoomframe/) 也是一种形状。其章节项可以使用自定义图像，通过每个摘要缩放章节的 `get_ZoomImage()` 方法公开。

```cpp
String inputPath = u"sample.pptx";
String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"summary-zoom-images");
Directory::CreateDirectory_(outputDirectory);

auto savedImageHashes = MakeObject<HashSet<String>>();

auto presentation = MakeObject<Presentation>(inputPath);
int slideCount = presentation->get_Slides()->get_Count();
for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

    std::vector<ShapeInfo> shapeInfos;
    EnumerateShapes(slide->get_Shapes(), slidePrefix, false, shapeInfos);

    for (const ShapeInfo& item : shapeInfos)
    {
        auto summaryZoomFrame = System::AsCast<ISummaryZoomFrame>(item.Shape);
        if (summaryZoomFrame != nullptr)
        {
            auto summaryZoomCollection = summaryZoomFrame->get_SummaryZoomCollection();
            int sectionCount = summaryZoomCollection->get_Count();
            for (int sectionIndex = 0; sectionIndex < sectionCount; sectionIndex++)
            {
                auto section = summaryZoomCollection->idx_get(sectionIndex);
                if (section->get_ZoomImage() != nullptr)
                {
                    int displayIndex = sectionIndex + 1;
                    String fileNameBase = String::Format(u"{0}_summary_zoom_{1}", item.NamePart, displayIndex);
                    SaveOriginalImage(section->get_ZoomImage(), outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}

presentation->Dispose();
```

## **从表格形状提取图像**

[ITable](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itable/) 是一种形状。表格中的图像通常存储为单元格的图片填充。

```cpp
String inputPath = u"sample.pptx";
String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"table-images");
Directory::CreateDirectory_(outputDirectory);

auto savedImageHashes = MakeObject<HashSet<String>>();

auto presentation = MakeObject<Presentation>(inputPath);
int slideCount = presentation->get_Slides()->get_Count();
for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

    std::vector<ShapeInfo> shapeInfos;
    EnumerateShapes(slide->get_Shapes(), slidePrefix, true, shapeInfos);

    for (const ShapeInfo& item : shapeInfos)
    {
        auto table = System::AsCast<ITable>(item.Shape);
        if (table != nullptr)
        {
            int rowCount = table->get_Rows()->get_Count();
            int columnCount = table->get_Columns()->get_Count();
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    auto column = table->get_Column(columnIndex);
                    auto cell = column->idx_get(rowIndex);
                    auto image = GetPictureFillImage(cell->get_CellFormat()->get_FillFormat());
                    if (image != nullptr)
                    {
                        String fileNameBase = String::Format(
                            u"{0}_cell_{1}_{2}", item.NamePart, rowIndex + 1, columnIndex + 1);
                        SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                    }
                }
            }
        }
    }
}

presentation->Dispose();
```

## **从图表形状提取图像**

[IChart](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichart/) 是一种形状。下面的示例从图表区域的图片填充中提取图像。

```cpp
String inputPath = u"sample.pptx";
String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"chart-images");
Directory::CreateDirectory_(outputDirectory);

auto savedImageHashes = MakeObject<HashSet<String>>();

auto presentation = MakeObject<Presentation>(inputPath);
int slideCount = presentation->get_Slides()->get_Count();
for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

    std::vector<ShapeInfo> shapeInfos;
    EnumerateShapes(slide->get_Shapes(), slidePrefix, true, shapeInfos);

    for (const ShapeInfo& item : shapeInfos)
    {
        auto chart = System::AsCast<Aspose::Slides::Charts::IChart>(item.Shape);
        if (chart != nullptr)
        {
            auto fillFormat = chart->get_FillFormat();
            auto image = GetPictureFillImage(fillFormat);
            if (image != nullptr)
            {
                String fileNameBase = String::Format(u"{0}_chart_area", item.NamePart);
                SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
            }
        }
    }
}

presentation->Dispose();
```

## **从 SmartArt 形状提取图像**

[ISmartArt](https://reference.aspose.com/slides/zh/cpp/aspose.slides.smartart/ismartart/) 对象是形状。根据 SmartArt 布局，图像可能存储在节点项目符号填充中或节点形状的填充格式中。

```cpp
String inputPath = u"sample.pptx";
String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"smartart-images");
Directory::CreateDirectory_(outputDirectory);

auto savedImageHashes = MakeObject<HashSet<String>>();

auto presentation = MakeObject<Presentation>(inputPath);
int slideCount = presentation->get_Slides()->get_Count();
for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

    std::vector<ShapeInfo> shapeInfos;
    EnumerateShapes(slide->get_Shapes(), slidePrefix, true, shapeInfos);

    for (const ShapeInfo& item : shapeInfos)
    {
        auto smartArt = System::AsCast<Aspose::Slides::SmartArt::ISmartArt>(item.Shape);
        if (smartArt != nullptr)
        {
            int nodeCount = smartArt->get_AllNodes()->get_Count();
            for (int nodeIndex = 0; nodeIndex < nodeCount; nodeIndex++)
            {
                auto node = smartArt->get_NodeFromAll(nodeIndex);
                auto bulletImage = GetPictureFillImage(node->get_BulletFillFormat());
                if (bulletImage != nullptr)
                {
                    String fileNameBase = String::Format(
                        u"{0}_smartart_node_{1}_bullet", item.NamePart, nodeIndex + 1);
                    SaveOriginalImage(bulletImage, outputDirectory, fileNameBase, savedImageHashes);
                }

                int nodeShapeCount = node->get_Shapes()->get_Count();
                for (int nodeShapeIndex = 0; nodeShapeIndex < nodeShapeCount; nodeShapeIndex++)
                {
                    auto nodeShape = node->get_Shape(nodeShapeIndex);
                    auto image = GetPictureFillImage(nodeShape->get_FillFormat());
                    if (image != nullptr)
                    {
                        String fileNameBase = String::Format(
                            u"{0}_smartart_node_{1}_shape_{2}",
                            item.NamePart,
                            nodeIndex + 1,
                            nodeShapeIndex + 1);
                        SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                    }
                }
            }
        }
    }
}

presentation->Dispose();
```

## **包括组内形状中的图像**

组形状包含各自的形状集合。共享的 `EnumerateShapes` 帮助方法具有 `includeGroupedShapes` 选项。当需要检查 [IGroupShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/igroupshape/) 对象内部的形状时，将其设为 `true`。下面的示例从图片框、填充图片的形状、OLE 对象预览、视频帧缩略图和音频帧缩略图中提取图像。若想同时包括表格、图表、SmartArt 和摘要缩放图像，只需在保持相同递归形状遍历的前提下，复用前面章节的专用提取逻辑。

```cpp
String inputPath = u"sample.pptx";
String outputDirectory = Path::Combine(Environment::get_CurrentDirectory(), u"all-shape-images");
Directory::CreateDirectory_(outputDirectory);

auto savedImageHashes = MakeObject<HashSet<String>>();

auto presentation = MakeObject<Presentation>(inputPath);
int slideCount = presentation->get_Slides()->get_Count();
for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    String slidePrefix = String::Format(u"slide_{0}", slide->get_SlideNumber());

    std::vector<ShapeInfo> shapeInfos;
    EnumerateShapes(slide->get_Shapes(), slidePrefix, true, shapeInfos);

    for (const ShapeInfo& item : shapeInfos)
    {
        auto pictureFrame = System::AsCast<IPictureFrame>(item.Shape);
        if (pictureFrame != nullptr)
        {
            auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
            SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
            continue;
        }

        auto autoShape = System::AsCast<IAutoShape>(item.Shape);
        if (autoShape != nullptr)
        {
            auto image = GetPictureFillImage(autoShape->get_FillFormat());
            if (image != nullptr)
            {
                SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
            }

            continue;
        }

        auto oleObjectFrame = System::AsCast<IOleObjectFrame>(item.Shape);
        if (oleObjectFrame != nullptr)
        {
            auto image = oleObjectFrame->get_SubstitutePictureFormat()->get_Picture()->get_Image();
            if (image != nullptr)
            {
                String fileNameBase = String::Format(u"{0}_ole_preview", item.NamePart);
                SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
            }

            continue;
        }

        auto videoFrame = System::AsCast<IVideoFrame>(item.Shape);
        if (videoFrame != nullptr)
        {
            auto image = videoFrame->get_PictureFormat()->get_Picture()->get_Image();
            if (image != nullptr)
            {
                String fileNameBase = String::Format(u"{0}_video_preview", item.NamePart);
                SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
            }

            continue;
        }

        auto audioFrame = System::AsCast<IAudioFrame>(item.Shape);
        if (audioFrame != nullptr)
        {
            auto image = audioFrame->get_PictureFormat()->get_Picture()->get_Image();
            if (image != nullptr)
            {
                String fileNameBase = String::Format(u"{0}_audio_preview", item.NamePart);
                SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
            }
        }
    }
}

presentation->Dispose();
```

## **边缘情况及实用说明**

- **重复图像**：多个形状可能引用同一图像，或不同图像的字节完全相同。在写入文件前，对 [IPPImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/)::`get_BinaryData()` 进行哈希，以实现每个唯一图像只输出一次。
- **原始数据 vs. 转换后输出**：保存 [IPPImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/)::`get_BinaryData()` 可保留嵌入的 JPEG、PNG、GIF、SVG、EMF 或 WMF 数据。通过 [IPPImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/)::`get_Image()` 并调用 [IImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimage/)::`Save` 时，可将输出统一为特定格式。
- **不受支持的填充类型**：实色、渐变、图案和无填充形状不包含图片填充。读取 `get_PictureFillFormat()` 前请先检查 [FillType](https://reference.aspose.com/slides/zh/cpp/aspose.slides/filltype/)。
- **组形状**：顶层幻灯片形状集合不会自动展平组。需要递归检查 [IGroupShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/igroupshape/)::`get_Shapes()`，当组内容重要时。
- **OLE 对象预览**：[IOleObjectFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ioleobjectframe/) 可能通过 `get_SubstitutePictureFormat()` 暴露预览图像，但该图像仅是幻灯片预览，而不是 OLE 对象内部的嵌入文件。
- **视频帧缩略图**：[IVideoFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideoframe/) 可能通过 `get_PictureFormat()` 暴露预览图像，该图像仅是幻灯片上显示的海报，未从视频流中提取。
- **音频帧缩略图**：[IAudioFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iaudioframe/) 可能通过 `get_PictureFormat()` 暴露图标或缩略图；这并非嵌入的音频数据。
- **缩放图像**：幻灯片缩放、章节缩放和摘要缩放形状可能通过 `get_ZoomImage()` 使用自定义 [IPPImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/) 对象。
- **嵌套形状模型**：表格、图表和 SmartArt 对象实现了 [IShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/)，但它们的图像通常存储在嵌套的表格单元格、图表元素或 SmartArt 节点格式对象中。
- **裁剪或转换后的图片**：访问 [IPPImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/) 可获得存储的图像资源。它不包含形状所施加的裁剪、透明度、重新着色、旋转或其他视觉效果。

## **常见问题解答**

**能否在不裁剪、无特效或形状转换的情况下提取原始图像？**

可以。访问 [IPPImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/) 对象并将 `get_BinaryData()` 写入磁盘。这样保留的是演示文稿中存储的原始编码图像，而不是在幻灯片上渲染的方式。

**能否将所有提取的图像导出为 PNG？**

可以。使用 [IPPImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/)::`get_Image()` 获取 [IImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimage/) 对象，然后调用 [IImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimage/)::`Save` 并传入 [ImageFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imageformat/)::`Png`。这会转换输出格式，可能不保留原始文件类型或矢量数据。

**如何避免同一图像被多次保存？**

对 [IPPImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/)::`get_BinaryData()` 计算哈希并将哈希存入集合。若新图像的哈希已存在，则跳过保存或记录对已有输出文件的另一个引用。

**为什么有些形状没有生成图像？**

图片框、填充图片的形状、OLE 对象框、媒体框、缩放框、表格、图表和 SmartArt 对象可以引用图像。某些形状类型通过嵌套的格式对象公开图像，仅检查 `get_PictureFormat()` 或形状的 `get_FillFormat()` 并不足以捕获所有情况。

**能否提取视频帧显示的缩略图？**

可以。使用 [IVideoFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ivideoframe/)::`get_PictureFormat()` 并读取 `get_PictureFormat()->get_Picture()->get_Image()`。这提取的是与视频帧一起存储的海报图像，而不是从视频文件生成的帧。

**如何确定哪些形状使用了演示文稿图像集合中的特定图像？**

Aspose.Slides 不会存储从 [IPPImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/) 到形状的逆向链接。遍历时构建映射：每当发现图像引用时，记录幻灯片编号、形状路径以及图像哈希或集合项。

**能否提取嵌入在 OLE 对象内部的图像（例如附件文档）？**

可以从 [IOleObjectFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ioleobjectframe/)::`get_SubstitutePictureFormat()` 提取 OLE 对象的幻灯片预览。但该预览并非嵌入的文档本身。若要提取嵌入文件内部的图像，需要先提取 OLE 数据并使用相应文件类型的工具进行检查。