---
title: استخراج تصاویر از اشکال ارائه در C++
linktitle: تصویر از شکل
type: docs
weight: 90
url: /fa/cpp/extracting-images-from-presentation-shapes/
keywords:
- استخراج تصویر
- بازیابی تصویر
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "تصاویر را از اشکال در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای C++ استخراج کنید - راه‌حل سریع و مناسب برای کدنویسی."
---
## **مرور کلی**

تصاویر در یک ارائه می‌توانند در انواع مختلفی از اشکال ظاهر شوند: به عنوان چارچوب‌های تصویر عادی، به عنوان پرکردن تصویری که بر روی اشکال اعمال می‌شود، به عنوان پیش‌نمایش تصاویر شیء OLE، به عنوان تصویر بندانگشتی فریم‌های ویدیو یا صدا، به عنوان تصاویر بزرگنمایی، یا به عنوان تصاویر تو در تو درون اشکال جدول، نمودار و SmartArt. Aspose.Slides این تصاویر را در مجموعه تصاویر ارائه ذخیره می‌کند که از طریق [IImageCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimagecollection/) و [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) در دسترس است.

اگر فقط نیاز دارید تمام منابع تصویری جاسازی شده در یک ارائه را صادر کنید، از `presentation->get_Images()` عبور کنید. این مقاله بر روی کار دیگری متمرکز است: پیمایش اشکال برای یافتن مکان‌های استفاده از تصاویر در اسلایدها، به‌طوری‌که فایل‌های ذخیره‌شده بتوانند زمینه مفیدی مانند شماره اسلاید، موقعیت شکل و نوع منبع (چارچوب تصویر، پرکردن تصویر، پیش‌نمایش رسانه، پیش‌نمایش OLE یا تصویر بزرگنمایی) را حفظ کنند.

{{% alert title="Tip" color="primary" %}}
از [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/)::`get_BinaryData()` برای حفظ داده‌های باینری تصویر اصلی کدگذاری‌شده و نوع فایل استفاده کنید. از [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/)::`get_Image()` همراه با [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/)::`Save` هنگامی که می‌خواهید خروجی را به فرمت خاصی مثل PNG نرمال کنید، استفاده کنید.
{{% /alert %}}

## **متدهای کمکی مشترک**

متدهای کمکی زیر مثال‌ها را کوتاه نگه می‌دارند. `SaveOriginalImage` بایت‌های جاسازی شده اصلی را می‌نویسد، پسوند امنی را بر اساس نوع MIME انتخاب می‌کند و باینری‌های تصویر تکراری را بر پایهٔ هش SHA‑256 حذف می‌کند.

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

## **استخراج تصاویر از چارچوب‌های تصویر**

از این روش برای تصاویری که به عنوان اشیاء مستقل وارد می‌شوند استفاده کنید. یک [IPictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipictureframe/) تصویر خود را در `get_PictureFormat()->get_Picture()->get_Image()` ذخیره می‌کند که یک شیء [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) برمی‌گرداند.

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

## **استخراج تصاویر از اشکال پرشده‑تصویر**

اشکال می‌توانند از یک تصویر به‌عنوان پرکردن استفاده کنند. ابتدا نوع پرکردن شکل را بررسی کنید: اگر برابر با [FillType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/filltype/)::`Picture` نباشد، تصویری برای استخراج از این پرکردن وجود ندارد. مثال زیر اشیاء [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) را مدیریت می‌کند و هر تصویر را از طریق [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/)::`get_Image()` به صورت PNG ذخیره می‌کند.

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

## **استخراج تصاویر پیش‌نمایش از چارچوب‌های شیء OLE**

یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ioleobjectframe/) می‌تواند تصویر جایگزینی داشته باشد که PowerPoint به‌عنوان پیش‌نمایش شیء در اسلاید استفاده می‌کند. این تصویر از طریق `get_SubstitutePictureFormat()->get_Picture()->get_Image()` در دسترس است. استخراج این تصویر، پیش‌نمایش را می‌دهد نه محتویات بستهٔ OLE جاسازی شده.

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

## **استخراج تصاویر پیش‌نمایش از چارچوب‌های ویدیو**

یک [IVideoFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/) نیز می‌تواند تصویر پیش‌نمایش را در `get_PictureFormat()->get_Picture()->get_Image()` ذخیره کند. این تصویر پوستر یا بندانگشتی نشان‌داده‌شده بر روی اسلاید است، نه فریمی استخراج‌شده از جریان ویدیو.

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

## **استخراج تصاویر پیش‌نمایش از چارچوب‌های صدا**

یک [IAudioFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iaudioframe/) می‌تواند تصویر بندانگشتی را در `get_PictureFormat()->get_Picture()->get_Image()` ذخیره کند. این تصویر همان نمادی است که برای شیء صدا بر روی اسلاید نمایش داده می‌شود.

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

## **استخراج تصاویر از اشیاء زوم**

اشکال [IZoomFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/izoomframe/) و [ISectionZoomFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isectionzoomframe/) می‌توانند از تصاویر سفارشی استفاده کنند. `get_ZoomImage()` را از چارچوب زوم بخوانید.

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

## **استخراج تصاویر از چارچوب‌های زوم خلاصه**

یک [ISummaryZoomFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isummaryzoomframe/) نیز یک شکل است. موارد بخش خلاصه می‌توانند از تصاویر سفارشی استفاده کنند که از طریق متد `get_ZoomImage()` هر بخش زوم خلاصه در دسترس است.

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

## **استخراج تصاویر از اشکال جدول**

یک [ITable](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itable/) یک شکل است. تصاویر در جدول معمولاً به‌صورت پرکردن تصویر در سلول‌های جدول ذخیره می‌شوند.

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

## **استخراج تصاویر از اشکال نمودار**

یک [IChart](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichart/) یک شکل است. مثال زیر تصویری را از پرکردن تصویر ناحیهٔ نمودار استخراج می‌کند.

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

## **استخراج تصاویر از اشکال SmartArt**

یک شیء [ISmartArt](https://reference.aspose.com/slides/fa/cpp/aspose.slides.smartart/ismartart/) یک شکل است. بسته به طرح‌بندی SmartArt، ممکن است تصاویر در پرکردن گلوله‌های گره یا در قالب پرکردن اشکال گره‌ها ذخیره شوند.

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

## **شامل تصاویر داخل اشکال گروهی**

اشکال گروهی مجموعهٔ اشکال خودشان را دارند. متد کمکی مشترک `EnumerateShapes` گزینهٔ `includeGroupedShapes` دارد. وقتی می‌خواهید اشکال داخل اشیاء [IGroupShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/igroupshape/) را بررسی کنید این گزینه را به `true` تنظیم کنید. مثال زیر تصاویر را از چارچوب‌های تصویر، اشکال پرشده‑تصویر، پیش‌نمایش‌های شیء OLE، بندانگشتی فریم‌های ویدیو و بندانگشتی فریم‌های صدا استخراج می‌کند. برای شامل کردن تصاویر جدول، نمودار، SmartArt و زوم خلاصه نیز می‌توانید منطق استخراج تخصصی بخش‌های قبلی را بازاستفاده کنید در حالی که همان پیمایش بازگشتی شکل را نگه می‌دارید.

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

## **موارد خاص و نکات عملی**

- **تصاویر تکراری:** چندین شکل ممکن است به یک تصویر یکسان یا به تصاویری با بایت‌های یکسان ارجاع دهند. قبل از نوشتن فایل‌ها هش [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/)::`get_BinaryData()` را محاسبه کنید اگر می‌خواهید برای هر تصویر منحصر به‌فرد یک فایل خروجی داشته باشید.
- **دادهٔ اصلی در مقابل خروجی تبدیل‌شده:** ذخیره کردن [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/)::`get_BinaryData()` دادهٔ JPEG، PNG، GIF، SVG، EMF یا WMF جاسازی شده را حفظ می‌کند. ذخیره کردن [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/)::`get_Image()` از طریق [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/)::`Save` زمانی مفید است که می‌خواهید فرمت خروجی یکسانی داشته باشید.
- **انواع پرکردن پشتیبانی‌نشده:** اشکال با پرکردن ثابت، گرادیان، الگو و بدون پرکردن تصویر ندارند. قبل از خواندن `get_PictureFillFormat()` نوع [FillType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/filltype/) را بررسی کنید.
- **اشکال گروهی:** مجموعهٔ اشکال سطح‑بالای اسلاید گروه‌ها را صاف نمی‌کند. وقتی محتویات گروه مهم است به‌صورت بازگشتی [IGroupShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/igroupshape/)::`get_Shapes()` را بررسی کنید.
- **پیش‌نمایش‌های شیء OLE:** یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ioleobjectframe/) ممکن است تصویر پیش‌نمایش را از طریق `get_SubstitutePictureFormat()` ارائه دهد، اما این تصویر فقط پیش‌نمایش اسلاید است؛ نه فایل جاسازی شده داخل شیء OLE.
- **بندانگشتی‌های فریم ویدیو:** یک [IVideoFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/) ممکن است تصویر پیش‌نمایش را از طریق `get_PictureFormat()` ارائه دهد، اما این تصویر فقط پوستر نشان‌داده‌شده بر اسلاید است؛ نه فریمی استخراج‌شده از جریان ویدیو.
- **بندانگشتی‌های فریم صدا:** یک [IAudioFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iaudioframe/) ممکن است نماد یا بندانگشتی را از طریق `get_PictureFormat()` ارائه دهد؛ این تصویر دادهٔ صوتی جاسازی شده نیست.
- **تصاویر زوم:** اشکال زوم اسلاید، زوم بخش و زوم خلاصه ممکن است از اشیاء سفارشی [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) از طریق `get_ZoomImage()` استفاده کنند.
- **مدل‌های تو در توی اشکال:** اشیاء جدول، نمودار و SmartArt پیاده‌سازی [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) را دارند، اما تصاویر آن‌ها اغلب در قالب‌های تو در تو سلول جدول، عنصر نمودار یا گره‌های SmartArt ذخیره می‌شوند.
- **تصاویر برش‌خورده یا تبدیل‌شده:** دسترسی به [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) منبع تصویر ذخیره‌شده را می‌دهد. این روش برش، شفافیت، تغییر رنگ، چرخش یا دیگر اثرات بصری اعمال‌شده توسط شکل را رندر نمی‌کند.

## **پرسش‌های متداول**

**آیا می‌توانم تصویر اصلی را بدون برش، جلوه‌ها یا تبدیل‌های شکلی استخراج کنم؟**

بله. به شیء [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) دسترسی پیدا کنید و `get_BinaryData()` را روی دیسک بنویسید. این کار تصویر کدگذاری‌شدهٔ اصلی ذخیره‌شده در ارائه را حفظ می‌کند، نه نحوهٔ رندر تصویر بر اسلاید.

**آیا می‌توانم هر تصویر استخراج‌شده را به‌صورت PNG صادر کنم؟**

بله. از [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/)::`get_Image()` برای دریافت یک شیء [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/) استفاده کنید، سپس [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/)::`Save` را با [ImageFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imageformat/)::`Png` صدا بزنید. این کار خروجی را به PNG تبدیل می‌کند و ممکن است نوع فایل یا دادهٔ برداری اصلی را حفظ نکند.

**چگونه از ذخیرهٔ یک تصویر بیش از یک بار جلوگیری کنم؟**

از هش [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/)::`get_BinaryData()` استفاده کنید و هش‌ها را در یک مجموعه نگهداری کنید. اگر تصویر جدیدی هشی داشته باشد که قبلاً موجود است، آن را نادیده بگیرید یا یک مرجع دیگر به فایل خروجی موجود ثبت کنید.

**چرا برخی اشکال تصویر تولید نمی‌کنند؟**

چارچوب‌های تصویر، اشکال پرشده‑تصویر، چارچوب‌های شیء OLE، چارچوب‌های رسانه‌ای، چارچوب‌های زوم، جداول، نمودارها و اشیاء SmartArt می‌توانند به تصاویر ارجاع دهند. برخی انواع اشکال تصاویر را از طریق اشیاء قالب‌بندی تو در تو در دسترس می‌گذارند، بنابراین بررسی سادهٔ `get_PictureFormat()` یا `get_FillFormat()` شکل همیشه کافی نیست.

**آیا می‌توانم بندانگشتی نشان‌داده‌شده برای یک فریم ویدیو را استخراج کنم؟**

بله. از [IVideoFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/)::`get_PictureFormat()` استفاده کنید و `get_PictureFormat()->get_Picture()->get_Image()` را بخوانید. این کار تصویر پوستر ذخیره‌شده همراه فریم ویدیو را استخراج می‌کند، نه فریمی تولید‌شده از فایل ویدیو.

**چگونه می‌توانم تعیین کنم کدام اشکال از تصویری خاص در مجموعهٔ تصاویر ارائه استفاده می‌کنند؟**

Aspose.Slides پیوند معکوسی از [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) به اشکال ذخیره نمی‌کند. در حین پیمایش یک نگاشت بسازید: هر بار که به یک مرجع تصویر برخوردید، شماره اسلاید، مسیر شکل و هش یا شناسهٔ مورد از مجموعهٔ تصویر را ثبت کنید.

**آیا می‌توانم تصاویر جاسازی‌شده داخل اشیاء OLE، مانند اسناد پیوست‌شده، را استخراج کنم؟**

می‌توانید پیش‌نمایش اسلاید شیء OLE را از [IOleObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ioleobjectframe/)::`get_SubstitutePictureFormat()` استخراج کنید. اما این پیش‌نمایش همان سند جاسازی شده نیست. برای استخراج تصاویر داخل فایل جاسازی‌شده، دادهٔ OLE را استخراج کنید و با ابزارهای مربوط به نوع فایل آن بررسی نمایید.