---
title: استخراج الصور من أشكال العرض التقديمي في C++
linktitle: صورة من الشكل
type: docs
weight: 90
url: /ar/cpp/extracting-images-from-presentation-shapes/
keywords:
- استخراج الصورة
- استرجاع الصورة
- PowerPoint
- OpenDocument
- العرض التقديمي
- C++
- Aspose.Slides
description: "استخراج الصور من الأشكال في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides للغة C++ - حل سريع وسهل الاستخدام في الكود."
---
## **نظرة عامة**

يمكن أن تظهر الصور في العرض التقديمي بأنواع متعددة من الأشكال: كإطارات صور عادية، كملء صور يُطبق على الأشكال، كصورة معاينة لكائن OLE، كصورة مصغرة لإطار فيديو أو صوت، كصور تكبير، أو كصور متداخلة داخل الأشكال من نوع جدول أو مخطط أو SmartArt. يقوم Aspose.Slides بتخزين تلك الصور في مجموعة صور العرض التقديمي، التي يمكن الوصول إليها عبر كائنات [IImageCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimagecollection/) و[IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/).

إذا كنت بحاجة فقط إلى تصدير كل موارد الصور المدمجة في العرض التقديمي، فقم بالتكرار عبر `presentation->get_Images()`. يركز هذا المقال على مهمة مختلفة: اجتياز الأشكال للعثور على أماكن استخدام الصور في الشرائح، بحيث يمكن للملفات المحفوظة الاحتفاظ بسياق مفيد مثل رقم الشريحة، موضع الشكل، ونوع المصدر (إطار صورة، ملء صورة، معاينة وسائط، معاينة OLE، أو صورة تكبير).

{{% alert title="نصيحة" color="info" %}}

استخدم [IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/)::`get_BinaryData()` للحفاظ على بيانات الصورة المشفرة الأصلية ونوع الملف. استخدم [IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/)::`get_Image()` مع [IImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/)::`Save` عندما ترغب في تحويل المخرجات إلى تنسيق محدد مثل PNG.

{{% /alert %}}

## **أساليب المساعدة المشتركة**

الأساليب المساعدة أدناه تجعل الأمثلة قصيرة. `SaveOriginalImage` يكتب البايتات المدمجة الأصلية، يختار امتدادات آمنة من نوع MIME، ويتخطى الصور المكررة عبر تجزئة SHA‑256.

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

## **استخراج الصور من إطارات الصور**

استخدم هذا النهج للصور التي تم إدراجها ككائنات مستقلة. يخزن [IPictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipictureframe/) صورته في `get_PictureFormat()->get_Picture()->get_Image()`، والذي يعيد كائنًا من نوع [IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/).

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

## **استخراج الصور من الأشكال المملوءة بالصور**

يمكن للأشكال أن تستخدم صورة كملء لها. تحقق أولاً من نوع ملء الشكل: إذا لم يكن [FillType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/filltype/)::`Picture`، فلا توجد صورة لاستخراجها من ذلك الملء. يتعامل المثال أدناه مع كائنات [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) ويحفظ كل صورة كـ PNG عبر [IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/)::`get_Image()`.

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

## **استخراج صور المعاينة من إطارات كائن OLE**

يمكن أن يحتوي [IOleObjectFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ioleobjectframe/) على صورة بديلة يستخدمها PowerPoint كمعاينة للكائن على الشريحة. تتوفر هذه الصورة عبر `get_SubstitutePictureFormat()->get_Picture()->get_Image()`. استخراج هذه الصورة يعطيك صورة المعاينة، وليس محتويات حزمة OLE المدمجة.

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

## **استخراج صور المعاينة من إطارات الفيديو**

يمكن أيضًا أن يخزن [IVideoFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ivideoframe/) صورة معاينة في `get_PictureFormat()->get_Picture()->get_Image()`. هذه هي الصورة البوستر أو المصغرة التي تظهر على الشريحة، وليس إطارًا مستخرجًا من تدفق الفيديو.

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

## **استخراج صور المعاينة من إطارات الصوت**

يمكن لـ [IAudioFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iaudioframe/) تخزين صورة مصغرة في `get_PictureFormat()->get_Picture()->get_Image()`. هذه هي الصورة التي تظهر لكائن الصوت على الشريحة.

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

## **استخراج الصور من كائنات التكبير**

يمكن لأشكال [IZoomFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/izoomframe/) و[ISectionZoomFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isectionzoomframe/) استخدام صور مخصصة. اقرأ `get_ZoomImage()` من إطار التكبير.

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

## **استخراج الصور من إطارات التكبير الملخصة**

[ISummaryZoomFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isummaryzoomframe/) هو أيضًا شكل. يمكن لعناصر القسم الخاصة به أن تستخدم صورًا مخصصة، تُعرض عبر طريقة كل قسم `get_ZoomImage()`.

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

## **استخراج الصور من أشكال الجداول**

[ITable](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itable/) هو شكل. عادةً ما تُخزن الصور في جدول كملء صورة في خلايا الجدول.

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

## **استخراج الصور من أشكال المخططات**

[IChart](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichart/) هو شكل. يوضح المثال أدناه كيفية استخراج صورة من ملء صورة منطقة المخطط.

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

## **استخراج الصور من أشكال SmartArt**

[ISmartArt](https://reference.aspose.com/slides/ar/cpp/aspose.slides.smartart/ismartart/) هو كائن شكل. وفقًا لتخطيط SmartArt، قد تُخزن الصور في ملء نقاط العقد أو في تنسيقات ملء أشكال العقد.

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

## **تضمين الصور داخل الأشكال المجمعة**

تحتوي الأشكال المجمعة على مجموعات أشكال خاصة بها. يوفر المساعد المشترك `EnumerateShapes` خيار `includeGroupedShapes`. اضبطه على `true` عندما ترغب في فحص الأشكال داخل كائنات [IGroupShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/igroupshape/). يوضح المثال أدناه استخراج الصور من إطارات الصور، الأشكال المملوءة بالصور، معاينات كائنات OLE، المصغرات لإطارات الفيديو والصوت. لتضمين صور الجداول والمخططات وSmartArt وتكبير الملخص أيضًا، أعد استخدام منطق الاستخراج المتخصص من الأقسام السابقة مع الحفاظ على نفس اجتياز الأشكال المتكرر.

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

## **حالات خاصة وملاحظات عملية**

- **الصور المكررة:** قد تشير عدة أشكال إلى نفس الصورة أو إلى صور منفصلة ذات بايتات متطابقة. احسب تجزئة [IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/)::`get_BinaryData()` قبل كتابة الملفات إذا كنت تريد ملف إخراج واحد لكل صورة فريدة.
- **البيانات الأصلية مقابل الإخراج المحول:** حفظ [IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/)::`get_BinaryData()` يحافظ على بيانات JPEG أو PNG أو GIF أو SVG أو EMF أو WMF المدمجة. حفظ [IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/)::`get_Image()` عبر [IImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/)::`Save` مفيد عندما ترغب في تنسيق إخراج موحد.
- **أنواع الملء غير المدعومة:** الأشكال الصلبة، المتدرجة، النمطية، وبدون ملء لا تحتوي على ملء صورة. تحقق من [FillType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/filltype/) قبل قراءة `get_PictureFillFormat()`.
- **الأشكال المجمعة:** مجموعة الأشكال العليا في الشريحة لا تُسطّح المجموعات. افحص [IGroupShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/igroupshape/)::`get_Shapes()` بشكل متكرر عندما تكون محتويات المجموعة مهمة.
- **معاينات كائن OLE:** قد يُظهر [IOleObjectFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ioleobjectframe/) صورة معاينة عبر `get_SubstitutePictureFormat()`، لكنها مجرد معاينة شريحة وليست الملف المدمج داخل كائن OLE.
- **مصغرات إطار الفيديو:** قد يُظهر [IVideoFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ivideoframe/) صورة معاينة عبر `get_PictureFormat()`، لكنها مجرد البوستر المعروض على الشريحة ولا تُستخرج من تدفق الفيديو.
- **مصغرات إطار الصوت:** قد يُظهر [IAudioFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iaudioframe/) أيقونة أو مصغرة عبر `get_PictureFormat()`؛ إنها ليست البيانات الصوتية المدمجة.
- **صور التكبير:** قد تستخدم أشكال تكبير الشريحة، تكبير القسم، وتكبير الملخص صورًا مخصصة عبر كائنات [IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/) من خلال `get_ZoomImage()`.
- **نماذج الأشكال المتداخلة:** تُنفّذ كائنات الجدول، المخطط، وSmartArt [IShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/)، لكن صورها غالبًا ما تُخزن في خلايا الجدول المتداخلة أو عناصر المخطط أو كائنات تنسيق عقد SmartArt.
- **الصور المقصوصة أو المحوّلة:** الحصول على [IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/) يمنحك المورد المخزن للصورة. لا يتم تطبيق القص، الشفافية، إعادة التلوين، الدوران أو أي تأثيرات بصرية أخرى تم تطبيقها على الشكل.

## **الأسئلة الشائعة**

### هل يمكن استخراج الصورة الأصلية دون قص أو تأثيرات أو تحويلات الشكل؟

نعم. يمكنك الوصول إلى كائن [IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/) وكتابة `get_BinaryData()` إلى القرص. سيحافظ ذلك على الصورة المشفرة الأصلية المخزنة في العرض التقديمي، وليس على طريقة عرض الصورة على الشريحة.

### هل يمكن تصدير كل صورة مُستخرجة كـ PNG؟

نعم. استخدم [IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/)::`get_Image()` للحصول على كائن [IImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/)، ثم استدعِ [IImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/)::`Save` مع [ImageFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imageformat/)::`Png`. سيحوّل ذلك الإخراج وقد لا يحافظ على نوع الملف الأصلي أو البيانات المتجهية.

### كيف يمكن تجنب حفظ نفس الصورة أكثر من مرة؟

استخدم تجزئة [IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/)::`get_BinaryData()` واحتفظ بالتجزئات في مجموعة. إذا كان للصورة الجديدة تجزئة موجودة مسبقًا، فتخَّها أو سجِّل إشارة أخرى إلى ملف الإخراج الموجود.

### لماذا لا تنتج بعض الأشكال صورة؟

يمكن لإطارات الصور، الأشكال المملوءة بالصور، إطارات كائن OLE، أطر الوسائط، أطر التكبير، الجداول، المخططات، وكائنات SmartArt أن تشير إلى صور. بعض أنواع الأشكال تُظهر الصور عبر كائنات تنسيق متداخلة، لذا قد لا يكون فحص `get_PictureFormat()` أو `get_FillFormat()` كافيًا.

### هل يمكن استخراج المصغرة المعروضة لإطار الفيديو؟

نعم. استخدم [IVideoFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ivideoframe/)::`get_PictureFormat()` وقراءة `get_PictureFormat()->get_Picture()->get_Image()`. سيستخرج ذلك صورة البوستر المخزنة مع إطار الفيديو، وليس إطارًا مُستخرجًا من ملف الفيديو.

### كيف يمكنني تحديد الأشكال التي تستخدم صورة معينة من مجموعة صور العرض؟

لا يخزن Aspose.Slides روابط عكسية من [IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/) إلى الأشكال. قم بإنشاء خريطة أثناء الاجتياز: كلما وجدت إشارة صورة، سجِّل رقم الشريحة، مسار الشكل، وتجزئة الصورة أو عنصر المجموعة.

### هل يمكن استخراج الصور المدمجة داخل كائنات OLE، مثل المستندات المرفقة؟

يمكنك استخراج معاينة الشريحة لكائن OLE عبر [IOleObjectFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ioleobjectframe/)::`get_SubstitutePictureFormat()`. ومع ذلك، هذه المعاينة ليست المستند المدمج نفسه. لاستخراج الصور من داخل الملف المدمج، استخرج بيانات OLE وافحصها بأدوات ملائمة لنوع الملف.