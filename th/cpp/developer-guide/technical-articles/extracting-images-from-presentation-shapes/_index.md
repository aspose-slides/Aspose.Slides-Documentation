---
title: ดึงรูปภาพจากรูปร่างในพรีเซนเทชันด้วย C++
linktitle: รูปภาพจากรูปร่าง
type: docs
weight: 90
url: /th/cpp/extracting-images-from-presentation-shapes/
keywords:
- ดึงรูปภาพ
- รับรูปภาพ
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- C++
- Aspose.Slides
description: "ดึงรูปภาพจากรูปร่างในพรีเซนเทชัน PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ C++ - วิธีแก้ไขที่รวดเร็วและเป็นมิตรต่อโค้ด."
---
## **ภาพรวม**

รูปภาพในงานพรีเซนเทชันอาจปรากฏในหลายประเภทของรูปร่างได้: เป็นกรอบรูปภาพทั่วไป, เป็นการเติมภาพที่ใช้กับรูปร่าง, เป็นภาพตัวอย่างของวัตถุ OLE, เป็นภาพย่อของเฟรมวิดีโอหรือออดิโอ, เป็นภาพซูม, หรือเป็นรูปภาพที่ฝังอยู่ภายในรูปร่างตาราง, แผนภูมิ และ SmartArt. Aspose.Slides จัดเก็บรูปภาพเหล่านั้นในคอลเลกชันรูปภาพของพรีเซนเทชัน ซึ่งเปิดให้ใช้ผ่านอ็อบเจ็กต์ [IImageCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimagecollection/) และ [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/).

หากคุณต้องการส่งออกทรัพยากรรูปภาพทุกไฟล์ที่ฝังอยู่ในพรีเซนเทชัน ให้วนลูปผ่าน `presentation->get_Images()` เท่านั้น. บทความนี้มุ่งเน้นงานที่ต่างออกไป: การท่องรูปร่างเพื่อค้นหาที่ที่รูปภาพถูกใช้บนสไลด์ เพื่อให้ไฟล์ที่บันทึกได้เก็บบริบทที่มีประโยชน์ เช่น หมายเลขสไลด์, ตำแหน่งรูปร่าง, และประเภทแหล่งที่มา (กรอบรูปภาพ, การเติมภาพ, ตัวอย่างสื่อ, ตัวอย่าง OLE, หรือภาพซูม).

{{% alert title="Tip" color="primary" %}}
ใช้ [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/)::`get_BinaryData()` เพื่อคงข้อมูลรูปภาพที่ถูกเข้ารหัสต้นฉบับและประเภทไฟล์. ใช้ [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/)::`get_Image()` ร่วมกับ [IImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/)::`Save` เมื่อคุณต้องการทำให้ผลลัพธ์เป็นรูปแบบที่กำหนด เช่น PNG.
{{% /alert %}}

## **วิธีช่วยเหลือที่ใช้ร่วมกัน**

เมธอดช่วยเหลือด้านล่างทำให้ตัวอย่างสั้นลง. `SaveOriginalImage` จะเขียนไบต์ที่ฝังไว้ต้นฉบับ, เลือกส่วนขยายที่ปลอดภัยจาก MIME type, และข้ามไบนารีรูปภาพที่ซ้ำกันโดยใช้แฮช SHA‑256.

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

## **ดึงรูปภาพจากกรอบรูปภาพ**

ใช้วิธีนี้สำหรับรูปที่แทรกเป็นอ็อบเจ็กต์อิสระ. [IPictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipictureframe/) เก็บรูปภาพของมันใน `get_PictureFormat()->get_Picture()->get_Image()`, ซึ่งคืนค่าอ็อบเจ็กต์ [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/).

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

## **ดึงรูปภาพจากรูปร่างที่เติมด้วยรูปภาพ**

รูปร่างสามารถใช้รูปเป็นการเติมได้. ตรวจสอบประเภทการเติมของรูปร่างก่อน: หากไม่ใช่ [FillType](https://reference.aspose.com/slides/th/cpp/aspose.slides/filltype/)::`Picture` จะไม่มีรูปให้ดึงจากการเติมนั้น. ตัวอย่างด้านล่างจัดการกับอ็อบเจ็กต์ [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) และบันทึกรูปแต่ละรูปเป็น PNG ผ่าน [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/)::`get_Image()`.

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

## **ดึงรูปภาพตัวอย่างจากกรอบวัตถุ OLE**

[IOleObjectFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ioleobjectframe/) สามารถมีรูปภาพทดแทนที่ PowerPoint ใช้เป็นตัวอย่างของวัตถุบนสไลด์. รูปภาพนี้สามารถเข้าถึงได้ผ่าน `get_SubstitutePictureFormat()->get_Picture()->get_Image()`. การดึงรูปภาพนี้จะให้ตัวอย่างภาพ, ไม่ได้เป็นเนื้อหาแพ็คเกจ OLE ที่ฝังอยู่.

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

## **ดึงรูปภาพตัวอย่างจากกรอบวิดีโอ**

[IVideoFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideoframe/) สามารถเก็บรูปภาพตัวอย่างใน `get_PictureFormat()->get_Picture()->get_Image()`. นี่คือโปสเตอร์หรือภาพย่อที่แสดงบนสไลด์, ไม่ได้เป็นเฟรมที่ถอดรหัสจากสตรีมวิดีโอ.

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

## **ดึงรูปภาพตัวอย่างจากกรอบออดิโอ**

[IAudioFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/iaudioframe/) สามารถเก็บภาพย่อใน `get_PictureFormat()->get_Picture()->get_Image()`. นี่คือรูปภาพที่แสดงสำหรับออบเจ็กต์ออดิโอบนสไลด์.

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

## **ดึงรูปภาพจากวัตถุซูม**

รูปร่าง [IZoomFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/izoomframe/) และ [ISectionZoomFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/isectionzoomframe/) สามารถใช้รูปภาพกำหนดเองได้. อ่านค่า `get_ZoomImage()` จากกรอบซูม.

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

## **ดึงรูปภาพจากกรอบซูมสรุป**

[ISummaryZoomFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/isummaryzoomframe/) ก็เป็นรูปร่างเช่นกัน. รายการส่วนของซูมสรุปสามารถใช้รูปภาพกำหนดเองได้, ซึ่งเปิดให้เข้าถึงผ่านเมธอด `get_ZoomImage()` ของแต่ละส่วนซูมสรุป.

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

## **ดึงรูปภาพจากรูปร่างตาราง**

[ITable](https://reference.aspose.com/slides/th/cpp/aspose.slides/itable/) เป็นรูปร่าง. รูปภาพในตารางมักถูกเก็บเป็นการเติมรูปภาพในเซลล์ของตาราง.

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

## **ดึงรูปภาพจากรูปร่างแผนภูมิ**

[IChart](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichart/) เป็นรูปร่าง. ตัวอย่างด้านล่างดึงรูปภาพจากการเติมรูปภาพของพื้นที่แผนภูมิ.

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

## **ดึงรูปภาพจากรูปร่าง SmartArt**

[ISmartArt](https://reference.aspose.com/slides/th/cpp/aspose.slides.smartart/ismartart/) เป็นอ็อบเจ็กต์รูปร่าง. ขึ้นอยู่กับการจัดวางของ SmartArt, รูปภาพอาจถูกเก็บในการเติมจุดสัญลักษณ์ของโหนดหรือในรูปแบบการเติมของรูปร่างโหนด.

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

## **รวมรูปภาพที่อยู่ภายในรูปร่างกลุ่ม**

รูปร่างที่เป็นกลุ่มจะมีคอลเลกชันรูปร่างของตนเอง. เมธอดช่วยเหลือ `EnumerateShapes` ที่ใช้ร่วมกันมีตัวเลือก `includeGroupedShapes`. ตั้งค่าเป็น `true` เมื่อคุณต้องการตรวจสอบรูปร่างภายในอ็อบเจ็กต์ [IGroupShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/igroupshape/). ตัวอย่างด้านล่างดึงรูปภาพจากกรอบรูปภาพ, รูปร่างที่เติมด้วยรูปภาพ, ตัวอย่าง OLE, ภาพย่อเฟรมวิดีโอ, และภาพย่อเฟรมออดิโอ. เพื่อรวมรูปภาพจากตาราง, แผนภูมิ, SmartArt, และซูมสรุปด้วย, ให้ใช้ตรรกะการดึงพิเศษจากส่วนก่อนหน้าโดยคงการท่องรูปร่างแบบเรียกซ้ำเดิม.

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

## **กรณีขอบเขตและหมายเหตุเชิงปฏิบัติ**

- **รูปภาพซ้ำ:** รูปร่างหลายรูปอาจอ้างอิงรูปภาพเดียวกันหรือรูปภาพแยกต่างหากที่มีไบต์เท่ากัน. ควรทำแฮช [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/)::`get_BinaryData()` ก่อนเขียนไฟล์ หากต้องการให้มีไฟล์ผลลัพธ์หนึ่งไฟล์ต่อรูปภาพที่เป็นเอกลักษณ์.
- **ข้อมูลต้นฉบับ vs. ผลลัพธ์ที่แปลง:** การบันทึก [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/)::`get_BinaryData()` จะคงข้อมูล JPEG, PNG, GIF, SVG, EMF หรือ WMF ที่ฝังไว้. การบันทึก [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/)::`get_Image()` ผ่าน [IImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/)::`Save` มีประโยชน์เมื่อคุณต้องการรูปแบบผลลัพธ์ที่สม่ำเสมอ.
- **ประเภทการเติมที่ไม่รองรับ:** รูปร่างที่เป็นสีทึบ, ไล่ระดับสี, ลาย, หรือไม่มีการเติมจะไม่บรรจุการเติมรูปภาพ. ตรวจสอบ [FillType](https://reference.aspose.com/slides/th/cpp/aspose.slides/filltype/) ก่อนอ่าน `get_PictureFillFormat()`.
- **รูปร่างกลุ่ม:** คอลเลกชันรูปร่างระดับบนของสไลด์จะไม่ทำให้กลุ่มแบน. ตรวจสอบ [IGroupShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/igroupshape/)::`get_Shapes()` อย่างเรียกซ้ำเมื่อเนื้อหากลุ่มสำคัญ.
- **ตัวอย่าง OLE:** [IOleObjectFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ioleobjectframe/) อาจเปิดให้เข้าถึงภาพตัวอย่างผ่าน `get_SubstitutePictureFormat()`, แต่ภาพนั้นเป็นเพียงภาพตัวอย่างสไลด์ ไม่ใช่ไฟล์ที่ฝังอยู่ในอ็อบเจ็กต์ OLE.
- **ภาพย่อเฟรมวิดีโอ:** [IVideoFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideoframe/) อาจเปิดให้เข้าถึงภาพตัวอย่างผ่าน `get_PictureFormat()`, แต่ภาพนั้นเป็นเพียงโปสเตอร์ที่แสดงบนสไลด์ ไม่ได้มาจากการถอดเฟรมจากสตรีมวิดีโอ.
- **ภาพย่อเฟรมออดิโอ:** [IAudioFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/iaudioframe/) อาจเปิดให้เข้าถึงไอคอนหรือภาพย่อผ่าน `get_PictureFormat()`; ไม่ได้เป็นข้อมูลออดิโอที่ฝังอยู่.
- **ภาพซูม:** รูปร่างซูมสไลด์, ซูมส่วน, และซูมสรุปอาจใช้รูปภาพกำหนดเองจากอ็อบเจ็กต์ [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/) ผ่าน `get_ZoomImage()`.
- **รูปแบบรูปร่างซ้อนกัน:** อ็อบเจ็กต์ตาราง, แผนภูมิ, และ SmartArt ติดตั้ง [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/) แต่ภาพของพวกมันมักถูกเก็บในเซลล์ตารางที่ซ้อนกัน, องค์ประกอบแผนภูมิ, หรืออ็อบเจ็กต์การจัดรูปแบบโหนดของ SmartArt.
- **รูปภาพที่ถูกครอปหรือแปลง:** การเข้าถึง [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/) จะให้ทรัพยากรภาพที่จัดเก็บไว้เท่านั้น. จะไม่ทำให้แสดงการครอป, ความโปร่งใส, การเปลี่ยนสี, การหมุน, หรือเอฟเฟกต์ภาพอื่น ๆ ที่รูปร่างอาจนำไปใช้.

## **คำถามที่พบบ่อย**

**ฉันสามารถดึงรูปภาพต้นฉบับโดยไม่ครอป, ไม่เอฟเฟกต์, หรือไม่แปลงรูปร่างได้หรือไม่?**  

ใช่. เข้าถึงอ็อบเจ็กต์ [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/) แล้วเขียน `get_BinaryData()` ไปยังดิสก์. วิธีนี้จะคงรูปภาพที่ถูกเข้ารหัสต้นฉบับที่เก็บในพรีเซนเทชัน, ไม่ใช่วิธีที่ภาพถูกเรนเดอร์บนสไลด์.

**ฉันสามารถส่งออกรูปภาพที่ดึงทั้งหมดเป็น PNG ได้หรือไม่?**  

ใช่. ใช้ [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/)::`get_Image()` เพื่อรับอ็อบเจ็กต์ [IImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/), จากนั้นเรียก [IImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/)::`Save` พร้อมกับ [ImageFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/imageformat/)::`Png`. วิธีนี้จะแปลงผลลัพธ์และอาจไม่คงประเภทไฟล์เดิมหรือข้อมูลเวคเตอร์.

**ฉันจะหลีกเลี่ยงการบันทึกรูปภาพเดียวกันหลายครั้งได้อย่างไร?**  

ใช้แฮชของ [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/)::`get_BinaryData()` แล้วเก็บแฮชเหล่านั้นในชุดข้อมูล. หากรูปภาพใหม่มีแฮชที่มีอยู่แล้ว, ข้ามการบันทึกหรือบันทึกการอ้างอิงอื่นไปยังไฟล์ผลลัพธ์ที่มีอยู่.

**ทำไมบางรูปร่างถึงไม่สร้างรูปภาพได้?**  

กรอบรูปภาพ, รูปร่างที่เติมด้วยรูปภาพ, กรอบวัตถุ OLE, กรอบสื่อ, กรอบซูม, ตาราง, แผนภูมิ, และออบเจ็กต์ SmartArt สามารถอ้างอิงรูปภาพได้. บางประเภทรูปร่างอาจเปิดให้เข้าถึงรูปภาพผ่านอ็อบเจ็กต์การจัดรูปแบบที่ซ้อนกัน, ดังนั้นการตรวจสอบเพียง `get_PictureFormat()` หรือ `get_FillFormat()` ของรูปร่างอาจไม่เพียงพอ.

**ฉันสามารถดึงภาพย่อที่แสดงสำหรับเฟรมวิดีโอได้หรือไม่?**  

ใช่. ใช้ [IVideoFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ivideoframe/)::`get_PictureFormat()` แล้วอ่าน `get_PictureFormat()->get_Picture()->get_Image()`. วิธีนี้จะดึงภาพโปสเตอร์ที่เก็บไว้กับเฟรมวิดีโอ, ไม่ใช่เฟรมที่สร้างจากไฟล์วิดีโอ.

**ฉันจะกำหนดได้ว่ารูปร่างใดใช้รูปภาพใดจากคอลเลกชันรูปภาพของพรีเซนเทชัน?**  

Aspose.Slides ไม่เก็บลิงก์ย้อนกลับจาก [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/) ไปยังรูปร่าง. คุณต้องสร้างแผนที่ขณะท่อง: ทุกครั้งที่พบการอ้างอิงรูปภาพ, บันทึกหมายเลขสไลด์, เส้นทางรูปร่าง, และแฮชหรือรายการจากคอลเลกชันรูปภาพ.

**ฉันสามารถดึงรูปภาพที่ฝังอยู่ภายในอ็อบเจ็กต์ OLE, เช่น เอกสารที่แนบมา, ได้หรือไม่?**  

คุณสามารถดึงตัวอย่างสไลด์ของอ็อบเจ็กต์ OLE จาก [IOleObjectFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ioleobjectframe/)::`get_SubstitutePictureFormat()` ได้. อย่างไรก็ตาม ตัวอย่างนั้นไม่ใช่เอกสารที่ฝังอยู่จริง. เพื่อดึงรูปภาพจากไฟล์ที่ฝังไว้, คุณต้องดึงข้อมูล OLE ออกมาแล้วตรวจสอบด้วยเครื่องมือที่สนับสนุนประเภทไฟล์นั้น.