---
title: Trích xuất hình ảnh từ các hình dạng trong bản trình bày bằng C++
linktitle: Hình ảnh từ hình dạng
type: docs
weight: 90
url: /vi/cpp/extracting-images-from-presentation-shapes/
keywords:
- trích xuất hình ảnh
- lấy lại hình ảnh
- PowerPoint
- OpenDocument
- bản trình bày
- C++
- Aspose.Slides
description: "Trích xuất hình ảnh từ các hình dạng trong bản trình bày PowerPoint và OpenDocument bằng Aspose.Slides cho C++ - giải pháp nhanh chóng, thân thiện với mã."
---
## **Tổng quan**

Hình ảnh trong một bài thuyết trình có thể xuất hiện ở nhiều loại hình dạng: dưới dạng khung ảnh thông thường, dưới dạng hình ảnh nền được áp dụng cho các hình dạng, dưới dạng hình ảnh xem trước đối tượng OLE, dưới dạng hình thu nhỏ khung video hoặc âm thanh, dưới dạng hình ảnh thu phóng, hoặc dưới dạng hình ảnh lồng trong các hình dạng bảng, biểu đồ và SmartArt. Aspose.Slides lưu trữ các hình ảnh đó trong bộ sưu tập hình ảnh của bản trình bày, được mở ra qua các đối tượng [IImageCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimagecollection/) và [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) .

Nếu bạn chỉ cần xuất mọi tài nguyên hình ảnh được nhúng trong một bản trình bày, hãy lặp qua `presentation->get_Images()`. Bài viết này tập trung vào một nhiệm vụ khác: duyệt các hình dạng để tìm nơi ảnh được sử dụng trên các slide, để các tệp đã lưu có thể giữ ngữ cảnh hữu ích như số slide, vị trí hình dạng và loại nguồn (khung ảnh, ảnh nền, xem trước media, xem trước OLE, hoặc ảnh thu phóng).

{{% alert title="Tip" color="primary" %}}
Sử dụng [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/)::`get_BinaryData()` để bảo tồn dữ liệu ảnh đã mã hoá gốc và loại tệp. Sử dụng [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/)::`get_Image()` cùng với [IImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/)::`Save` khi bạn muốn chuẩn hoá đầu ra sang một định dạng cụ thể như PNG.
{{% /alert %}}

## **Phương thức trợ giúp chung**

Các phương thức trợ giúp bên dưới giúp các ví dụ ngắn gọn. `SaveOriginalImage` ghi các byte nhúng gốc, chọn phần mở rộng an toàn từ loại MIME, và bỏ qua các ảnh nhị phân trùng lặp bằng hàm băm SHA-256.

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

## **Trích xuất hình ảnh từ khung ảnh**

Sử dụng cách tiếp cận này cho các hình ảnh được chèn dưới dạng đối tượng độc lập. Một [IPictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipictureframe/) lưu trữ ảnh của nó trong `get_PictureFormat()->get_Picture()->get_Image()`, trả về một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) .

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

## **Trích xuất hình ảnh từ các hình dạng được điền bằng ảnh**

Các hình dạng có thể sử dụng ảnh làm màu nền. Trước tiên kiểm tra loại nền của hình dạng: nếu không phải là [FillType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/filltype/)::`Picture`, thì không có ảnh để trích xuất từ nền đó. Ví dụ dưới đây xử lý các đối tượng [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) và lưu mỗi ảnh dưới dạng PNG thông qua [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/)::`get_Image()`.

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

## **Trích xuất hình ảnh xem trước từ khung đối tượng OLE**

Một [IOleObjectFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ioleobjectframe/) có thể có một ảnh thay thế mà PowerPoint dùng làm xem trước cho đối tượng trên slide. Ảnh này có sẵn qua `get_SubstitutePictureFormat()->get_Picture()->get_Image()`. Việc trích xuất ảnh này sẽ cho bạn hình ảnh xem trước, không phải nội dung gói OLE đã nhúng.

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

## **Trích xuất hình ảnh xem trước từ khung video**

Một [IVideoFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ivideoframe/) cũng có thể lưu trữ ảnh xem trước trong `get_PictureFormat()->get_Picture()->get_Image()`. Đây là ảnh bìa hoặc thumbnail hiển thị trên slide, không phải một khung được giải mã từ luồng video.

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

## **Trích xuất hình ảnh xem trước từ khung âm thanh**

Một [IAudioFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iaudioframe/) có thể lưu trữ thumbnail trong `get_PictureFormat()->get_Picture()->get_Image()`. Đây là hình ảnh hiển thị cho đối tượng âm thanh trên slide.

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

## **Trích xuất hình ảnh từ đối tượng Zoom**

[IZoomFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/izoomframe/) và [ISectionZoomFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isectionzoomframe/) có thể sử dụng ảnh tùy chỉnh. Đọc `get_ZoomImage()` từ khung zoom.

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

## **Trích xuất hình ảnh từ khung Summary Zoom**

Một [ISummaryZoomFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/isummaryzoomframe/) cũng là một hình dạng. Các mục phần của nó có thể sử dụng ảnh tùy chỉnh, được lộ ra qua phương thức `get_ZoomImage()` của từng phần summary zoom.

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

## **Trích xuất hình ảnh từ hình dạng bảng**

Một [ITable](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itable/) là một hình dạng. Hình ảnh trong bảng thường được lưu dưới dạng nền ảnh trong các ô bảng.

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

## **Trích xuất hình ảnh từ hình dạng biểu đồ**

Một [IChart](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichart/) là một hình dạng. Ví dụ dưới đây trích xuất một ảnh từ nền ảnh của khu vực biểu đồ.

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

## **Trích xuất hình ảnh từ hình dạng SmartArt**

Một đối tượng [ISmartArt](https://reference.aspose.com/slides/vi/cpp/aspose.slides.smartart/ismartart/) là một hình dạng. Tùy theo bố cục SmartArt, hình ảnh có thể được lưu trong nền bullet của nút hoặc trong định dạng nền của các hình dạng nút.

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

## **Bao gồm hình ảnh bên trong các hình dạng nhóm**

Các hình dạng nhóm chứa bộ sưu tập hình dạng riêng. Trợ giúp chung `EnumerateShapes` có tùy chọn `includeGroupedShapes`. Đặt nó thành `true` khi bạn muốn kiểm tra các hình dạng bên trong các đối tượng [IGroupShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/igroupshape/) . Ví dụ dưới đây trích xuất hình ảnh từ khung ảnh, các hình dạng được điền bằng ảnh, xem trước đối tượng OLE, thumbnail khung video và thumbnail khung âm thanh. Để bao gồm cả hình ảnh bảng, biểu đồ, SmartArt và summary zoom, hãy tái sử dụng logic trích xuất chuyên biệt từ các phần trước đồng thời duy trì cùng quá trình duyệt hình dạng đệ quy.

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

## **Trường hợp biên và lưu ý thực tiễn**

- **Hình ảnh trùng lặp:** Nhiều hình dạng có thể tham chiếu cùng một hình ảnh hoặc các hình ảnh riêng biệt có byte giống nhau. Tạo hash [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/)::`get_BinaryData()` trước khi ghi tệp nếu bạn muốn một tệp đầu ra cho mỗi hình ảnh duy nhất.
- **Dữ liệu gốc vs. đầu ra đã chuyển đổi:** Lưu [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/)::`get_BinaryData()` bảo tồn dữ liệu JPEG, PNG, GIF, SVG, EMF hoặc WMF được nhúng. Lưu [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/)::`get_Image()` qua [IImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/)::`Save` hữu ích khi bạn muốn một định dạng đầu ra nhất quán.
- **Các loại nền không hỗ trợ:** Các hình dạng rắn, gradient, pattern và không có nền không chứa ảnh nền. Kiểm tra [FillType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/filltype/) trước khi đọc `get_PictureFillFormat()`.
- **Hình dạng nhóm:** Bộ sưu tập hình dạng cấp cao của slide không làm phẳng các nhóm. Kiểm tra đệ quy [IGroupShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/igroupshape/)::`get_Shapes()` khi nội dung nhóm quan trọng.
- **Xem trước đối tượng OLE:** Một [IOleObjectFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ioleobjectframe/) có thể lộ ảnh xem trước qua `get_SubstitutePictureFormat()`, nhưng ảnh này chỉ là xem trước trên slide. Nó không phải là tệp được nhúng bên trong đối tượng OLE.
- **Thumbnail khung video:** Một [IVideoFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ivideoframe/) có thể lộ ảnh xem trước qua `get_PictureFormat()`, nhưng ảnh này chỉ là poster hiển thị trên slide. Nó không được trích xuất từ luồng video.
- **Thumbnail khung âm thanh:** Một [IAudioFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iaudioframe/) có thể lộ biểu tượng hoặc thumbnail qua `get_PictureFormat()`; nó không phải là dữ liệu âm thanh đã nhúng.
- **Hình ảnh zoom:** Các hình dạng zoom slide, section zoom và summary zoom có thể sử dụng các đối tượng [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) tùy chỉnh qua `get_ZoomImage()`.
- **Mô hình hình dạng lồng nhau:** Các đối tượng bảng, biểu đồ và SmartArt triển khai [IShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/) , nhưng các hình ảnh của chúng thường được lưu trong các đối tượng định dạng ô bảng, phần tử biểu đồ hoặc nút SmartArt.
- **Ảnh đã cắt hoặc biến dạng:** Truy cập [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) cho bạn tài nguyên ảnh đã lưu. Nó không thực hiện việc cắt, trong suốt, đổi màu, xoay hoặc các hiệu ứng trực quan khác mà hình dạng áp dụng.

## **Câu hỏi thường gặp**

**Tôi có thể trích xuất ảnh gốc mà không cắt, không có hiệu ứng hay biến đổi hình dạng không?**

Có. Truy cập đối tượng [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) và ghi [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/)::`get_BinaryData()` ra đĩa. Điều này bảo tồn ảnh đã mã hoá gốc được lưu trong bản trình bày, không phải cách ảnh được hiển thị trên slide.

**Tôi có thể xuất mọi ảnh đã trích xuất dưới dạng PNG không?**

Có. Sử dụng [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/)::`get_Image()` để có đối tượng [IImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/) , sau đó gọi [IImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/)::`Save` với [ImageFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imageformat/)::`Png`. Điều này chuyển đổi đầu ra và có thể không bảo tồn loại tệp gốc hoặc dữ liệu vector.

**Làm sao tôi tránh lưu cùng một ảnh nhiều lần?**

Sử dụng hàm băm của [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/)::`get_BinaryData()` và giữ các hash trong một tập hợp. Nếu một ảnh mới có hash đã tồn tại, bỏ qua hoặc ghi lại một tham chiếu khác tới tệp đầu ra hiện có.

**Tại sao một số hình dạng không tạo ra ảnh?**

Khung ảnh, các hình dạng được điền bằng ảnh, khung đối tượng OLE, khung media, khung zoom, bảng, biểu đồ và đối tượng SmartArt có thể tham chiếu ảnh. Một số loại hình dạng lộ ảnh qua các đối tượng định dạng lồng nhau, vì vậy việc chỉ kiểm tra `get_PictureFormat()` hoặc `get_FillFormat()` của hình dạng không luôn đủ.

**Tôi có thể trích xuất thumbnail hiển thị cho khung video không?**

Có. Sử dụng [IVideoFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ivideoframe/)::`get_PictureFormat()` và đọc `get_PictureFormat()->get_Picture()->get_Image()`. Điều này trích xuất ảnh poster được lưu cùng khung video, không phải một khung được tạo ra từ tệp video.

**Làm sao tôi xác định hình dạng nào dùng một ảnh cụ thể từ bộ sưu tập hình ảnh của bản trình bày?**

Aspose.Slides không lưu liên kết ngược từ [IPPImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ippimage/) tới các hình dạng. Xây dựng bản đồ trong quá trình duyệt: mỗi khi tìm thấy tham chiếu ảnh, ghi lại số slide, đường dẫn hình dạng và hash ảnh hoặc mục trong bộ sưu tập.

**Tôi có thể trích xuất ảnh nhúng bên trong các đối tượng OLE, chẳng hạn như tài liệu đính kèm?**

Bạn có thể trích xuất xem trước slide của đối tượng OLE từ [IOleObjectFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ioleobjectframe/)::`get_SubstitutePictureFormat()` . Tuy nhiên, xem trước này không phải là tài liệu được nhúng. Để trích xuất ảnh từ bên trong tệp nhúng, hãy xuất dữ liệu OLE và kiểm tra bằng các công cụ phù hợp với loại tệp đó.