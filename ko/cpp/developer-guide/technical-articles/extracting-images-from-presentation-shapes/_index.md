---
title: C++에서 프레젠테이션 도형의 이미지 추출
linktitle: 도형의 이미지
type: docs
weight: 90
url: /ko/cpp/extracting-images-from-presentation-shapes/
keywords:
- 이미지 추출
- 이미지 가져오기
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 도형에서 이미지를 추출합니다 - 빠르고 코드 친화적인 솔루션."
---
## **개요**

프레젠테이션의 이미지에는 여러 형태가 있을 수 있습니다: 일반 그림 프레임, 도형에 적용된 그림 채우기, OLE 개체 미리 보기 이미지, 비디오 또는 오디오 프레임 썸네일, 줌 이미지, 또는 표, 차트 및 SmartArt 도형 내부에 중첩된 이미지 등. Aspose.Slides는 이러한 이미지를 프레젠테이션 이미지 컬렉션에 저장하며, 이는 [IImageCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimagecollection/) 및 [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/) 객체를 통해 노출됩니다.

프레젠테이션에 포함된 모든 이미지 리소스를 내보내기만 하면 된다면 `presentation->get_Images()`를 순회하면 됩니다. 이 문서는 다른 작업에 초점을 맞춥니다: 슬라이드에서 이미지가 사용된 위치를 찾기 위해 도형을 탐색하고, 저장된 파일에 슬라이드 번호, 도형 위치, 원본 유형(그림 프레임, 채우기 이미지, 미디어 미리 보기, OLE 미리 보기 또는 줌 이미지)과 같은 유용한 컨텍스트를 유지하도록 합니다.

{{% alert title="Tip" color="primary" %}}
[IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/)::`get_BinaryData()`를 사용하면 원본 인코딩된 이미지 데이터와 파일 형식을 보존할 수 있습니다. 특정 형식(PNG 등)으로 출력하려면 [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/)::`get_Image()`와 [IImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/)::`Save`를 사용하세요.
{{% /alert %}}

## **공통 도우미 메서드**

아래 도우미 메서드는 예제를 간결하게 유지합니다. `SaveOriginalImage`는 원본 바이트를 기록하고 MIME 유형에서 안전한 확장자를 선택하며 SHA-256 해시로 중복 이미지 바이너리를 건너뜁니다.

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

## **그림 프레임에서 이미지 추출**

독립 객체로 삽입된 그림에 대해 이 방법을 사용합니다. [IPictureFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipictureframe/)은 `get_PictureFormat()->get_Picture()->get_Image()`를 통해 그림을 저장하며, 이는 [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/) 객체를 반환합니다.

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

## **그림 채우기 도형에서 이미지 추출**

도형은 그림을 채우기로 사용할 수 있습니다. 먼저 도형의 채우기 유형을 확인하세요: [FillType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/filltype/)::`Picture`가 아니면 해당 채우기에서 추출할 그림이 없습니다. 아래 예제는 [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/) 객체를 처리하고, 각 이미지를 [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/)::`get_Image()`를 통해 PNG로 저장합니다.

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

## **OLE 개체 프레임에서 미리 보기 이미지 추출**

[IOleObjectFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ioleobjectframe/)는 PowerPoint가 슬라이드에서 개체의 미리 보기로 사용하는 대체 그림을 가질 수 있습니다. 이 그림은 `get_SubstitutePictureFormat()->get_Picture()->get_Image()`를 통해 얻을 수 있습니다. 이 그림을 추출하면 미리 보기 이미지가 얻어지며, OLE 패키지의 실제 내용은 포함되지 않습니다.

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

## **비디오 프레임에서 미리 보기 이미지 추출**

[IVideoFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ivideoframe/)도 `get_PictureFormat()->get_Picture()->get_Image()`를 통해 미리 보기 이미지를 저장할 수 있습니다. 이는 슬라이드에 표시되는 포스터 또는 썸네일이며, 비디오 스트림에서 디코딩된 프레임이 아닙니다.

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

## **오디오 프레임에서 미리 보기 이미지 추출**

[IAudioFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iaudioframe/)는 `get_PictureFormat()->get_Picture()->get_Image()`를 통해 썸네일을 저장할 수 있습니다. 이는 슬라이드에 표시되는 오디오 객체의 이미지입니다.

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

## **줌 객체에서 이미지 추출**

[IZoomFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/izoomframe/) 및 [ISectionZoomFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isectionzoomframe/) 도형은 사용자 정의 이미지를 사용할 수 있습니다. 줌 프레임의 `get_ZoomImage()`를 읽으세요.

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

## **요약 줌 프레임에서 이미지 추출**

[ISummaryZoomFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isummaryzoomframe/)도 도형입니다. 각 요약 줌 섹션은 `get_ZoomImage()` 메서드를 통해 사용자 정의 이미지를 제공할 수 있습니다.

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

## **표 도형에서 이미지 추출**

[ITable](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itable/)는 도형이며, 표 안의 이미지는 보통 셀의 그림 채우기로 저장됩니다.

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

## **차트 도형에서 이미지 추출**

[IChart](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichart/)도 도형입니다. 아래 예제는 차트 영역의 그림 채우기에서 이미지를 추출합니다.

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

## **SmartArt 도형에서 이미지 추출**

[ISmartArt](https://reference.aspose.com/slides/ko/cpp/aspose.slides.smartart/ismartart/) 객체는 도형입니다. SmartArt 레이아웃에 따라 이미지는 노드 글머리 기호 채우기 또는 노드 도형의 채우기 형식에 저장될 수 있습니다.

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

## **그룹화된 도형 내부 이미지 포함**

그룹화된 도형은 자체 도형 컬렉션을 가집니다. 공유된 `EnumerateShapes` 도우미는 `includeGroupedShapes` 옵션을 제공합니다. [IGroupShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/igroupshape/) 객체 내부의 도형을 검사하려면 이를 `true`로 설정하십시오. 아래 예제는 그림 프레임, 그림 채우기 도형, OLE 개체 미리 보기, 비디오 프레임 썸네일, 오디오 프레임 썸네일에서 이미지를 추출합니다. 표, 차트, SmartArt 및 요약 줌 이미지도 포함하려면 이전 섹션의 전용 추출 로직을 재사용하면서 동일한 재귀 도형 순회를 유지하십시오.

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

## **예외 상황 및 실용적인 참고 사항**

- **중복 이미지:** 여러 도형이 동일한 이미지를 참조하거나 바이트가 동일한 별도 이미지를 가질 수 있습니다. 고유 이미지당 하나의 출력 파일만 만들려면 파일을 쓸 때 [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/)::`get_BinaryData()`의 해시를 확인하십시오.
- **원본 데이터 vs. 변환된 출력:** [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/)::`get_BinaryData()`를 저장하면 JPEG, PNG, GIF, SVG, EMF 또는 WMF와 같은 원본 인코딩 데이터를 보존합니다. [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/)::`get_Image()`를 [IImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/)::`Save`와 함께 사용하면 PNG와 같은 일관된 형식으로 변환할 수 있습니다.
- **지원되지 않는 채우기 유형:** 단색, 그라디언트, 패턴 및 무채우기 도형에는 그림 채우기가 포함되지 않습니다. `get_PictureFillFormat()`을 읽기 전에 [FillType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/filltype/)을 확인하세요.
- **그룹화된 도형:** 최상위 슬라이드 도형 컬렉션은 그룹을 평탄화하지 않습니다. 그룹화된 내용이 중요한 경우 [IGroupShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/igroupshape/)::`get_Shapes()`를 재귀적으로 검사하십시오.
- **OLE 개체 미리 보기:** [IOleObjectFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ioleobjectframe/)는 `get_SubstitutePictureFormat()`을 통해 미리 보기 이미지를 제공할 수 있지만, 이는 슬라이드 미리 보기일 뿐 OLE 개체 내부에 포함된 파일은 아닙니다.
- **비디오 프레임 썸네일:** [IVideoFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ivideoframe/)는 `get_PictureFormat()`을 통해 미리 보기 이미지를 제공하지만, 이는 슬라이드에 표시되는 포스터일 뿐 비디오 스트림에서 추출된 프레임은 아닙니다.
- **오디오 프레임 썸네일:** [IAudioFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iaudioframe/)는 `get_PictureFormat()`을 통해 아이콘 또는 썸네일을 제공하지만, 이는 삽입된 오디오 데이터와는 별개입니다.
- **줌 이미지:** 슬라이드 줌, 섹션 줌 및 요약 줌 도형은 `get_ZoomImage()`를 통해 사용자 정의 [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/) 객체를 사용할 수 있습니다.
- **중첩된 도형 모델:** 표, 차트 및 SmartArt 객체는 [IShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/)를 구현하지만, 이미지가 종종 중첩된 표 셀, 차트 요소 또는 SmartArt 노드 서식 객체에 저장됩니다.
- **잘라내기 또는 변형된 그림:** [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/)에 접근하면 저장된 이미지 리소스를 얻을 수 있지만, 도형이 적용한 잘라내기, 투명도, 색상 변경, 회전 등의 시각 효과는 반영되지 않습니다.

## **FAQ**

**원본 이미지를 잘라내기, 효과 또는 도형 변형 없이 추출할 수 있나요?**

예. [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/) 객체에 접근하여 `get_BinaryData()`를 디스크에 기록하면 프레젠테이션에 저장된 원본 인코딩 이미지를 보존할 수 있습니다. 슬라이드에 렌더링되는 방식은 반영되지 않습니다.

**추출한 모든 이미지를 PNG로 내보낼 수 있나요?**

예. [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/)::`get_Image()`를 사용해 [IImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/) 객체를 얻은 뒤, [IImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/)::`Save`와 [ImageFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imageformat/)::`Png`를 호출하면 PNG로 변환됩니다. 이 경우 원본 파일 형식이나 벡터 데이터는 보존되지 않을 수 있습니다.

**같은 이미지를 여러 번 저장하지 않으려면 어떻게 하나요?**

[IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/)::`get_BinaryData()`의 해시를 계산하고 이를 집합에 보관하십시오. 새로운 이미지의 해시가 이미 존재하면 해당 이미지를 건너뛰거나 기존 출력 파일에 대한 참조만 기록하면 됩니다.

**왜 일부 도형에서는 이미지가 생성되지 않나요?**

그림 프레임, 그림 채우기 도형, OLE 개체 프레임, 미디어 프레임, 줌 프레임, 표, 차트 및 SmartArt 객체는 이미지를 참조할 수 있습니다. 일부 도형은 중첩된 서식 객체를 통해 이미지를 제공하므로 단순히 `get_PictureFormat()`이나 도형의 `get_FillFormat()`만 검사하는 것으로는 충분하지 않을 수 있습니다.

**비디오 프레임에 표시되는 썸네일을 추출할 수 있나요?**

예. [IVideoFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ivideoframe/)::`get_PictureFormat()`을 사용하고 `get_PictureFormat()->get_Picture()->get_Image()`를 읽으면 비디오 프레임에 저장된 포스터 이미지를 추출할 수 있습니다. 이는 비디오 파일에서 생성된 프레임이 아니라 저장된 썸네일입니다.

**프레젠테이션 이미지 컬렉션에서 특정 이미지가 사용된 도형을 어떻게 찾나요?**

Aspose.Slides는 [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/)에서 도형으로의 역링크를 저장하지 않습니다. 순회 중에 이미지 참조를 찾을 때마다 슬라이드 번호, 도형 경로 및 이미지 해시 또는 컬렉션 항목을 기록하여 매핑을 구축하십시오.

**OLE 개체 내부에 포함된 이미지(예: 첨부 문서)를 추출할 수 있나요?**

[IOleObjectFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ioleobjectframe/)::`get_SubstitutePictureFormat()`을 통해 슬라이드 미리 보기 이미지는 추출할 수 있지만, 해당 미리 보기 자체는 임베디드 문서가 아닙니다. 내부 파일에서 이미지를 추출하려면 OLE 데이터를 추출한 뒤 해당 파일 형식에 맞는 도구로 검사해야 합니다.