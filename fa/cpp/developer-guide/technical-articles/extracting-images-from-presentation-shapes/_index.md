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
description: "تصاویر را از اشکال در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای C++ استخراج کنید - راه‌حلی سریع و مناسب برای کدنویسی."
---
## **مرور کلی**

تصاویر در یک ارائه می‌توانند در چند نوع شکل ظاهر شوند: به عنوان قاب‌های تصویر عادی، به عنوان پر کردن تصویر اعمال‌شده به اشکال، به عنوان تصاویر پیش‌نمایش شیء OLE، به عنوان تصاویر بندانگشتی فریم‌های ویدئو یا صدا، به عنوان تصاویر بزرگ‌نمایی، یا به عنوان تصاویری که داخل جدول، نمودار و اشکال SmartArt تو در تو هستند. Aspose.Slides این تصاویر را در مجموعه‌تصاویر ارائه ذخیره می‌کند که از طریق اشیاء [IImageCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimagecollection/) و [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) در دسترس هستند.

اگر فقط نیاز دارید هر منبع تصویری که در ارائه جاسازی شده است را صادر کنید، از `presentation->get_Images()` مرور کنید. این مقاله بر روی یک کار متفاوت تمرکز می‌کند: پیمایش اشکال برای یافتن مکان‌هایی که تصاویر در اسلایدها استفاده می‌شوند، طوری که فایل‌های ذخیره‌شده بتوانند زمینه مفیدی مانند شماره اسلاید، موقعیت شکل و نوع منبع (قاب تصویر، تصویر پر، پیش‌نمایش رسانه، پیش‌نمایش OLE یا تصویر بزرگ‌نمایی) را حفظ کنند.

{{% alert title="Tip" color="info" %}}
از [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/)::`get_BinaryData()` برای حفظ داده‌های تصویری رمزگذاری‌شده اصلی و نوع فایل استفاده کنید. از [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/)::`get_Image()` همراه با [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/)::`Save` زمانی استفاده کنید که بخواهید خروجی را به قالب خاصی مانند PNG نرمال کنید.
{{% /alert %}}

## **متدهای کمکی مشترک**

متدهای کمکی زیر مثال‌ها را کوتاه نگه می‌دارند. `SaveOriginalImage` بایت‌های جاسازی‌شده اصلی را می‌نویسد، پسوند ایمن را از نوع MIME انتخاب می‌کند و باینری‌های تکراری تصویر را بر پایه هش SHA‑256 نادیده می‌گیرد.

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
    if (savedImageHashes->Contains(imageHash))
    {
        return false;
    }

    savedImageHashes->Add(imageHash);

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

## **استخراج تصاویر از قاب‌های تصویر**

از این روش برای تصاویری که به‌صورت اشیای مستقل وارد شده‌اند استفاده کنید. یک [IPictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipictureframe/) تصویر خود را در `get_PictureFormat()->get_Picture()->get_Image()` ذخیره می‌کند که یک شیء [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) را برمی‌گرداند.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
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

    return 0;
}
```

## **استخراج تصاویر از اشکال پر شده با تصویر**

اشکال می‌توانند تصویر را به‌عنوان پرکننده خود استفاده کنند. ابتدا نوع پرکننده شکل را بررسی کنید: اگر [FillType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/filltype/)::`Picture` نباشد، تصویری برای استخراج از آن پرکننده وجود ندارد. مثال زیر اشیاء [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) را مدیریت می‌کند و هر تصویر را از طریق [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/)::`get_Image()` به‌صورت PNG ذخیره می‌نماید.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

int main()
{
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

    return 0;
}
```

## **استخراج تصاویر پیش‌نمایش از فریم‌های شیء OLE**

یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ioleobjectframe/) می‌تواند تصویر جایگزینی داشته باشد که PowerPoint به‌عنوان پیش‌نمایش شیء در اسلاید استفاده می‌کند. این تصویر از طریق `get_SubstitutePictureFormat()->get_Picture()->get_Image()` در دسترس است. استخراج این تصویر، تصویر پیش‌نمایش را می‌دهد نه محتویات بسته OLE جاسازی‌شده.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
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

    return 0;
}
```

## **استخراج تصاویر پیش‌نمایش از فریم‌های ویدئو**

یک [IVideoFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/) نیز می‌تواند تصویر پیش‌نمایش را در `get_PictureFormat()->get_Picture()->get_Image()` ذخیره کند. این تصویر پوستر یا بندانگشتی است که در اسلاید نشان داده می‌شود، نه فریمی استخراج‌شده از جریان ویدئو.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
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

    return 0;
}
```

## **استخراج تصاویر پیش‌نمایش از فریم‌های صدا**

یک [IAudioFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iaudioframe/) می‌تواند یک بندانگشتی را در `get_PictureFormat()->get_Picture()->get_Image()` ذخیره کند. این تصویر، تصویری است که برای شیء صدا در اسلاید نشان داده می‌شود.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
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

    return 0;
}
```

## **استخراج تصاویر از اشیای بزرگ‌نمایی**

اشکال [IZoomFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/izoomframe/) و [ISectionZoomFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isectionzoomframe/) می‌توانند از تصاویر سفارشی استفاده کنند. تصویر بزرگ‌نمایی را با فراخوانی `get_ZoomImage()` از فریم بزرگ‌نمایی بخوانید.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
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

    return 0;
}
```

## **استخراج تصاویر از فریم‌های بزرگ‌نمایی خلاصه**

یک [ISummaryZoomFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isummaryzoomframe/) نیز یک شکل است. آیتم‌های بخش آن می‌توانند از تصاویر سفارشی استفاده کنند که از طریق متد `get_ZoomImage()` هر بخش بزرگ‌نمایی خلاصه در دسترس است.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
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

    return 0;
}
```

## **استخراج تصاویر از اشکال جدول**

یک [ITable](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itable/) یک شکل است. تصاویر در جدول معمولاً به‌صورت پرکننده تصویر در سلول‌های جدول ذخیره می‌شوند.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
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

    return 0;
}
```

## **استخراج تصاویر از اشکال نمودار**

یک [IChart](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichart/) یک شکل است. مثال زیر تصویری را از پرکننده تصویر ناحیه نمودار استخراج می‌کند.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
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

    return 0;
}
```

## **استخراج تصاویر از اشکال SmartArt**

یک شیء [ISmartArt](https://reference.aspose.com/slides/fa/cpp/aspose.slides.smartart/ismartart/) یک شکل است. بسته به طرح‌بندی SmartArt، ممکن است تصاویر در پرکننده‌های نقطه‌چین گره یا در فرمت‌های پرکنندهٔ شکل‌های گره ذخیره شوند.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
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

    return 0;
}
```

## **شامل کردن تصاویر داخل اشکال گروهی**

اشکال گروهی مجموعهٔ اشکال خود را دارند. متد کمکی مشترک `EnumerateShapes` گزینهٔ `includeGroupedShapes` دارد. هنگام نیاز به بررسی اشکال داخل اشیای [IGroupShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/igroupshape/) آن را به `true` تنظیم کنید. مثال زیر تصاویر را از قاب‌های تصویر، اشکال پر شده با تصویر، پیش‌نمایش‌های شیء OLE، بندانگشت‌های فریم ویدئو و صدا استخراج می‌کند. برای شامل کردن تصاویر جدول، نمودار، SmartArt و بزرگ‌نمایی خلاصه نیز، منطق استخراج تخصصی بخش‌های قبلی را باز استفاده کنید در حالی که همان پیمایش بازگشتی اشکال را حفظ می‌کنید.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/hashset.h>
#include <system/environment.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

int main()
{
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

    return 0;
}
```

## **موارد خاص و نکات عملی**

- **تصاویر تکراری:** چندین شکل ممکن است به یک تصویر یا به تصاویر جداگانه‌ای با بایت‌های یکسان ارجاع دهند. قبل از نوشتن فایل‌ها هش [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/)::`get_BinaryData()` را محاسبه کنید تا برای هر تصویر منحصربه‌فرد یک خروجی داشته باشید.
- **دادهٔ اصلی در مقابل خروجی تبدیل‌شده:** ذخیرهٔ [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/)::`get_BinaryData()` داده‌های JPEG، PNG، GIF، SVG، EMF یا WMF جاسازی‌شده را حفظ می‌کند. ذخیرهٔ [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/)::`get_Image()` از طریق [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/)::`Save` زمانی مفید است که نیاز به قالب خروجی یکسان داشته باشید.
- **انواع پرکنندهٔ پشتیبانی‌نشده:** اشکال تک‌رنگ، گرادیان، الگو و بدون پرکننده تصویر شامل پرکنندهٔ تصویر نمی‌شوند. قبل از خواندن `get_PictureFillFormat()` نوع [FillType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/filltype/) را بررسی کنید.
- **اشکال گروهی:** مجموعهٔ اشکال اسلاید سطح بالایی گروه‌ها را صاف نمی‌کند. هنگام اهمیت محتوای گروهی، به‌صورت بازگشتی [IGroupShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/igroupshape/)::`get_Shapes()` را بررسی کنید.
- **پیش‌نمایش‌های شیء OLE:** یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ioleobjectframe/) ممکن است تصویر پیش‌نمایش را از طریق `get_SubstitutePictureFormat()` نمایش دهد، اما این تصویر فقط پیش‌نمایش اسلاید است و محتوای فایل جاسازی‌شده در داخل شیء OLE نیست.
- **بندانگشت‌های فریم ویدئو:** یک [IVideoFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/) ممکن است تصویر پیش‌نمایش را از طریق `get_PictureFormat()` ارائه دهد، اما این تصویر فقط پوستر نمایش‌داده‌شده در اسلاید است و از جریان ویدئو استخراج نمی‌شود.
- **بندانگشت‌های فریم صدا:** یک [IAudioFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iaudioframe/) ممکن است یک آیکون یا بندانگشت را از طریق `get_PictureFormat()` نمایش دهد؛ این دادهٔ صوتی جاسازی‌شده نیست.
- **تصاویر بزرگ‌نمایی:** اشکال بزرگ‌نمایی اسلاید، بزرگ‌نمایی بخش و بزرگ‌نمایی خلاصه می‌توانند از اشیای سفارشی [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) از طریق `get_ZoomImage()` استفاده کنند.
- **مدل‌های تو در توی شکل:** اشیای جدول، نمودار و SmartArt پیاده‌سازی [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) را دارند، اما تصاویر آنها اغلب در اشیای فرمت‌بندی سلول جدول، عنصر نمودار یا گره SmartArt تو در تو ذخیره می‌شود.
- **تصاویر برش‌خورده یا تبدیل‌شده:** دسترسی به [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) تصویر منبع ذخیره‌شده را می‌دهد. این تصویر برش، شفافیت، تغییر رنگ، چرخش یا سایر اثرات بصری اعمال‌شده توسط شکل را رندر نمی‌کند.

## **سؤال‌های متداول**

### آیا می‌توانم تصویر اصلی را بدون برش، اثرات یا تبدیلات شکل استخراج کنم؟

بله. به شیء [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) دسترسی یافته و `get_BinaryData()` آن را بر روی دیسک بنویسید. این کار دادهٔ تصویر رمزگذاری‌شدهٔ اصلی ذخیره‌شده در ارائه را حفظ می‌کند، نه نحوهٔ رندر تصویر روی اسلاید.

### آیا می‌توانم هر تصویر استخراج‌شده را به‌صورت PNG صادر کنم؟

بله. از [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/)::`get_Image()` برای دریافت شیء [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/) استفاده کنید و سپس [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/)::`Save` را با [ImageFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imageformat/)::`Png` فراخوانی کنید. این کار خروجی را به PNG تبدیل می‌کند و ممکن است نوع فایل اصلی یا دادهٔ برداری را حفظ نکند.

### چگونه از ذخیرهٔ یک تصویر بیش از یک‌بار جلوگیری کنم؟

هش [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/)::`get_BinaryData()` را محاسبه کنید و هش‌ها را در یک مجموعه نگه دارید. اگر تصویر جدیدی دارای هشی باشد که از قبل وجود دارد، آن را نادیده بگیرید یا مرجع دیگری به فایل خروجی موجود ثبت کنید.

### چرا برخی اشکال تصویر تولید نمی‌کنند؟

قاب‌های تصویر، اشکال پر شده با تصویر، فریم‌های شیء OLE، فریم‌های رسانه‌ای، فریم‌های بزرگ‌نمایی، جدول‌ها، نمودارها و اشیای SmartArt می‌توانند به تصاویر ارجاع دهند. برخی انواع شکل‌ها تصویر را از طریق اشیای فرمت‌بندی تو در تو ارائه می‌دهند، بنابراین بررسی سادهٔ `get_PictureFormat()` یا `get_FillFormat()` شکلی کافی نیست.

### آیا می‌توانم بندانگشت نشان‌داده‌شده برای فریم ویدئو را استخراج کنم؟

بله. از [IVideoFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ivideoframe/)::`get_PictureFormat()` استفاده کنید و `get_PictureFormat()->get_Picture()->get_Image()` را بخوانید. این کار تصویر پوستر ذخیره‌شده با فریم ویدئو را استخراج می‌کند، نه فریمی تولید شده از فایل ویدئویی.

### چگونه می‌توانم تعیین کنم کدام اشکال از یک تصویر خاص در مجموعهٔ تصاویر ارائه استفاده می‌کنند؟

Aspose.Slides لینک‌های معکوس از [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) به اشکال را ذخیره نمی‌کند. در طول پیمایش یک نگاشت بسازید: هر زمان که به یک ارجاع تصویر برخوردید، شماره اسلاید، مسیر شکل و هش تصویر یا آیتم مجموعه را ثبت کنید.

### آیا می‌توانم تصاویر جاسازی‌شده داخل اشیای OLE، مانند اسناد پیوست‌شده، را استخراج کنم؟

می‌توانید پیش‌نمایش اسلاید شیء OLE را از [IOleObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ioleobjectframe/)::`get_SubstitutePictureFormat()` استخراج کنید. اما این پیش‌نمایش همان سند جاسازی‌شده نیست. برای استخراج تصاویر از داخل فایل جاسازی‌شده، دادهٔ OLE را استخراج کرده و با ابزارهای مناسب برای آن نوع فایل بررسی کنید.