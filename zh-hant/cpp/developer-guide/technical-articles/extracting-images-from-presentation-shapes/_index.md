---
title: 從 C++ 簡報形狀提取圖像
linktitle: 形狀中的圖像
type: docs
weight: 90
url: /zh-hant/cpp/extracting-images-from-presentation-shapes/
keywords:
- 提取圖像
- 取得圖像
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 從 PowerPoint 與 OpenDocument 簡報的形狀中提取圖像 - 快速、程式碼友善的解決方案。"
---
## **概觀**

簡報中的圖像可以以多種形狀類型出現：普通圖片框、套用於形狀的圖片填充、OLE 物件預覽圖像、影片或音訊框縮圖、縮放圖像，或是嵌入於表格、圖表與 SmartArt 形狀內的圖像。Aspose.Slides 會將這些圖像儲存在簡報的圖像集合中，通過 [IImageCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimagecollection/) 與 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/) 物件公開。

若您只需要匯出簡報內嵌的所有圖像資源，請遍歷 `presentation->get_Images()`。本文聚焦於不同的任務：遍歷形狀以找出投影片上使用圖像的位置，從而在儲存檔案時保留有用的上下文資訊，如投影片編號、形狀位置與來源類型（圖片框、填充圖像、媒體預覽、OLE 預覽或縮放圖像）。

{{% alert title="Tip" color="primary" %}}
使用 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/)::`get_BinaryData()` 可保留原始編碼的圖像資料與檔案類型。若希望將輸出正規化為特定格式（例如 PNG），請使用 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/)::`get_Image()` 搭配 [IImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimage/)::`Save`。
{{% /alert %}}

## **共用協助方法**

以下協助方法用於簡化範例。`SaveOriginalImage` 會寫入原始嵌入位元組，根據 MIME 類型選擇安全的副檔名，並依 SHA-256 雜湊跳過重複的圖像二進位資料。

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

## **從圖片框提取圖像**

對於作為獨立物件插入的圖片，請使用此方式。[IPictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipictureframe/) 會將圖片儲存在 `get_PictureFormat()->get_Picture()->get_Image()`，該方法返回一個 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/) 物件。

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

## **從填充圖片的形狀提取圖像**

形狀可以使用圖片作為填充。首先檢查形狀的填充類型：如果不是 [FillType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/filltype/)::`Picture`，則該填充中沒有可提取的圖片。以下範例處理 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/) 物件，並透過 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/)::`get_Image()` 將每張圖像保存為 PNG。

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

## **從 OLE 物件框提取預覽圖像**

[IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ioleobjectframe/) 可以有 PowerPoint 用於在投影片上顯示的替代圖片。此圖像可透過 `get_SubstitutePictureFormat()->get_Picture()->get_Image()` 取得。提取此圖片會得到預覽圖像，而非嵌入的 OLE 套件內容。

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

## **從影片框提取預覽圖像**

[IVideoFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideoframe/) 也可以在 `get_PictureFormat()->get_Picture()->get_Image()` 中存放預覽圖像。這是投影片上顯示的海報或縮圖，而不是從影片流中解碼的畫面。

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

## **從音訊框提取預覽圖像**

[IAudioFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iaudioframe/) 可以在 `get_PictureFormat()->get_Picture()->get_Image()` 中存放縮圖。這是投影片上音訊物件的顯示圖像。

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

## **從縮放物件提取圖像**

[IZoomFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/izoomframe/) 與 [ISectionZoomFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isectionzoomframe/) 形狀可以使用自訂圖像。從縮放框讀取 `get_ZoomImage()`。

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

## **從摘要縮放框提取圖像**

[ISummaryZoomFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isummaryzoomframe/) 也是一種形狀。其區段項目可以使用自訂圖像，透過每個摘要縮放區段的 `get_ZoomImage()` 方法取得。

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

## **從表格形狀提取圖像**

[ITable](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itable/) 本身即為形狀。表格中的圖像通常以圖片填充的形式儲存在表格儲存格內。

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

## **從圖表形狀提取圖像**

[IChart](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichart/) 為形狀。以下範例從圖表區域的圖片填充中提取圖像。

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

## **從 SmartArt 形狀提取圖像**

[ISmartArt](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.smartart/ismartart/) 物件屬於形狀。根據 SmartArt 版面配置，圖像可能儲存在節點項目符號填充或節點形狀的填充格式中。

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

## **在群組形狀內部包含圖像**

群組形狀擁有自己的形狀集合。共用的 `EnumerateShapes` 協助方法提供 `includeGroupedShapes` 參數。當您想檢查 [IGroupShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/igroupshape/) 內的形狀時，將其設為 `true`。以下範例從圖片框、填充圖片的形狀、OLE 物件預覽、影片框縮圖與音訊框縮圖中提取圖像。若還要同時包含表格、圖表、SmartArt 以及摘要縮放圖像，請在相同的遞迴形狀遍歷過程中重用前述各節的專屬提取邏輯。

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

## **邊緣情況與實務說明**

- **重複圖像**：多個形狀可能引用相同的圖像，或是不同圖像卻擁有相同的位元組。在寫入檔案前，對 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/)::`get_BinaryData()` 計算雜湊，以保證每個唯一圖像只產生一個輸出檔案。  
- **原始資料 vs. 轉換後輸出**：保存 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/)::`get_BinaryData()` 會保留嵌入的 JPEG、PNG、GIF、SVG、EMF 或 WMF 資料。若希望統一輸出格式，則使用 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/)::`get_Image()` 並透過 [IImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimage/)::`Save`。  
- **不受支援的填充類型**：實色、漸層、圖案與無填充的形狀不含圖片填充。在讀取 `get_PictureFillFormat()` 前，先檢查 [FillType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/filltype/)。  
- **群組形狀**：頂層投影片形狀集合並不會自動展開群組。當群組內容重要時，請遞迴檢查 [IGroupShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/igroupshape/)::`get_Shapes()`。  
- **OLE 物件預覽**：[IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ioleobjectframe/) 可能透過 `get_SubstitutePictureFormat()` 暴露預覽圖像，但該圖像僅為投影片預覽，並非 OLE 物件內嵌的檔案。  
- **影片框縮圖**：[IVideoFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideoframe/) 可能透過 `get_PictureFormat()` 暴露預覽圖像，這僅是投影片上顯示的海報，並未從影片流中提取。  
- **音訊框縮圖**：[IAudioFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iaudioframe/) 可能透過 `get_PictureFormat()` 暴露圖示或縮圖，這並非嵌入的音訊資料本身。  
- **縮放圖像**：投影片縮放、區段縮放與摘要縮放形狀可能使用自訂 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/) 物件，透過 `get_ZoomImage()` 取得。  
- **巢狀形狀模型**：表格、圖表與 SmartArt 物件皆實作 [IShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/)，但它們的圖像往往儲存在巢狀的儲存格、圖表元素或 SmartArt 節點格式物件中。  
- **裁切或變形的圖片**：存取 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/) 可取得儲存的圖像資源，但不會套用形狀所做的裁切、透明度、重上色、旋轉或其他視覺效果。

## **常見問題**

**我能否在不裁切、套用特效或形狀變形的情況下提取原始圖像？**  
可以。存取 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/) 物件，將 `get_BinaryData()` 寫入磁碟即可保留簡報中儲存的原始編碼圖像，而非投影片上呈現的效果。

**我能否將所有提取的圖像都匯出為 PNG？**  
可以。使用 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/)::`get_Image()` 取得 [IImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimage/) 物件，然後呼叫 [IImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimage/)::`Save`，並傳入 [ImageFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imageformat/)::`Png`。此做法會轉換輸出格式，可能無法保留原始檔案類型或向量資料。

**如何避免同一圖像被多次儲存？**  
對 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/)::`get_BinaryData()` 計算雜湊，將雜湊值存入集合。若新圖像的雜湊已存在，則跳過寫檔或記錄為同一輸出檔案的另一個參考。

**為什麼有些形狀不會產生圖像？**  
圖片框、填充圖片的形狀、OLE 物件框、媒體框、縮放框、表格、圖表與 SmartArt 物件都可能引用圖像。但是某些形狀類型的圖像是透過巢狀的格式物件暴露，僅檢查 `get_PictureFormat()` 或形狀的 `get_FillFormat()` 未必足夠。

**我能提取影片框顯示的縮圖嗎？**  
可以。使用 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ivideoframe/)::`get_PictureFormat()`，再讀取 `get_PictureFormat()->get_Picture()->get_Image()`。這會提取與影片框一起儲存的海報圖像，而非從影片檔案中產生的畫面。

**如何判斷哪些形狀使用了簡報圖像集合中的特定圖像？**  
Aspose.Slides 並未從 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/) 反向連結回形狀。您需要在遍歷過程中自行建立映射：每當發現圖像參考時，記錄投影片編號、形狀路徑以及圖像雜湊或集合項目。

**我能提取嵌入於 OLE 物件中的圖像（例如附加的文件）嗎？**  
您可以透過 [IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ioleobjectframe/)::`get_SubstitutePictureFormat()` 提取該 OLE 物件在投影片上的預覽圖像。但此預覽並非嵌入的文件本身。若要從嵌入檔案中提取圖像，需先將 OLE 資料解壓，然後使用相應檔案類型的工具進行檢查。