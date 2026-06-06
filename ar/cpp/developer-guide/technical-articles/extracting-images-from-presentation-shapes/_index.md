---
title: استخراج الصور من أشكال العرض التقديمي في C++
linktitle: الصورة من الشكل
type: docs
weight: 90
url: /ar/cpp/extracting-images-from-presentation-shapes/
keywords:
- استخراج الصورة
- استرداد الصورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "استخراج الصور من الأشكال في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides للـ C++ - حل سريع ومناسب للشفرة."
---
## **نظرة عامة**

يمكن أن تظهر الصور في عرض تقديمي بأنواع متعددة من الأشكال: كإطارات صور عادية، أو كملء صور مطبق على الأشكال، أو كصور معاينة لكائنات OLE، أو كصور مصغرة لإطارات الفيديو أو الصوت، أو كصور تكبير، أو كصور مدمجة داخل أشكال الجداول أو المخططات أو SmartArt. يقوم Aspose.Slides بتخزين هذه الصور في مجموعة صور العرض التقديمي، التي تُعرَض عبر كائنات [IImageCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimagecollection/) و[IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/).

إذا كنت بحاجة فقط لتصدير كل مورد صورة مضمّن في العرض التقديمي، يمكنك التجوال عبر `presentation->get_Images()`. تركّز هذه المقالة على مهمة مغايرة: استعراض الأشكال لتحديد أين تُستَخدم الصور على الشرائح، بحيث يمكن للملفات المحفوظة أن تحتفظ بسياق مفيد مثل رقم الشريحة، موقع الشكل، ونوع المصدر (إطار صورة، صورة ملء، معاينة وسائط، معاينة OLE، أو صورة تكبير).

{{% alert title="Tip" color="primary" %}}
استخدم [IPPImage]::`get_BinaryData()` للحفاظ على بيانات الصورة المشفرة الأصلية ونوع الملف. استخدم [IPPImage]::`get_Image()` مع [IImage]::`Save` عندما تريد تحويل المخرجات إلى تنسيق محدد مثل PNG.
{{% /alert %}}

## **طرق المساعدة المشتركة**

الطرق المساعدة أدناه تجعل الأمثلة مختصرة. تقوم `SaveOriginalImage` بكتابة البايتات المضمنة الأصلية، وتختار امتدادًا آمنًا من نوع MIME، وتتخطى النسخ المكررة من الصور باستخدام تجزئة SHA‑256.

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

## **استخراج الصور من إطارات الصورة**

استخدم هذا النهج للصور المُدرَجة ككائنات مستقلة. يخزن [IPictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipictureframe/) صورته في `get_PictureFormat()->get_Picture()->get_Image()`، والتي تُعيد كائنًا من نوع [IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/).

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

## **استخراج الصور من الأشكال المملوءة بالصور**

يمكن للأشكال استخدام صورة كملئ لها. تحقق أولًا من نوع ملئ الشكل: إذا لم يكن [FillType]::`Picture`، فلا توجد صورة لاستخراجها من هذا الملئ. يعالج المثال أدناه كائنات [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) ويحفظ كل صورة كملف PNG عبر [IPPImage]::`get_Image()`.

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

## **استخراج صور المعاينة من إطارات كائن OLE**

يمكن لـ [IOleObjectFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ioleobjectframe/) أن يحتوي على صورة بديلة يستخدمها PowerPoint كمعاينة للكائن على الشريحة. تتوفر هذه الصورة عبر `get_SubstitutePictureFormat()->get_Picture()->get_Image()`. استخراج هذه الصورة يعطيك صورة المعاينة، وليس محتويات حزمة OLE المضمّنة.

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

## **استخراج صور المعاينة من إطارات الفيديو**

يمكن لـ [IVideoFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ivideoframe/) أيضًا تخزين صورة معاينة في `get_PictureFormat()->get_Picture()->get_Image()`. هذه هي الملصق أو الصورة المصغرة المعروضة على الشريحة، وليست إطارًا مُستخرجًا من تدفق الفيديو.

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

## **استخراج صور المعاينة من إطارات الصوت**

يمكن لـ [IAudioFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iaudioframe/) تخزين صورة مصغرة في `get_PictureFormat()->get_Picture()->get_Image()`. هذه هي الصورة المعروضة لكائن الصوت على الشريحة.

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

## **استخراج الصور من كائنات التكبير**

يمكن للأشكال من نوع [IZoomFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/izoomframe/) و[ISectionZoomFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isectionzoomframe/) استخدام صور مخصصة. اقرأ `get_ZoomImage()` من إطار التكبير.

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

## **استخراج الصور من إطارات التكبير التجميعي**

يُعدّ [ISummaryZoomFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isummaryzoomframe/) أيضًا شكلًا. قد تستخدم عناصر القسم الخاصة به صورًا مخصصة، تُعرَض عبر طريقة `get_ZoomImage()` لكل قسم تكبير تجميعي.

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

## **استخراج الصور من أشكال الجداول**

يُعدّ [ITable](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itable/) شكلًا. تُخزّن الصور في جدول عادةً كملء صور في خلايا الجدول.

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

## **استخراج الصور من أشكال المخططات**

يُعدّ [IChart](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichart/) شكلًا. يستخرج المثال أدناه صورة من ملء صورة منطقة المخطط.

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

## **استخراج الصور من أشكال SmartArt**

يُعدّ [ISmartArt](https://reference.aspose.com/slides/ar/cpp/aspose.slides.smartart/ismartart/) كائنًا شكلًا. حسب تخطيط SmartArt، قد تُخزّن الصور في ملء نقاط الرصاص للعُقَد أو في تنسيقات ملء أشكال العُقَد.

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

## **تضمين الصور داخل الأشكال المجمعة**

تحتوي الأشكال المجمعة على مجموعات أشكال خاصة بها. يحتوي المساعد المشترك `EnumerateShapes` على خيار `includeGroupedShapes`. اضبطه على `true` عندما ترغب في فحص الأشكال داخل كائنات [IGroupShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/igroupshape/). يستخرج المثال أدناه الصور من إطارات الصورة، الأشكال المملوءة بالصور، معاينات كائنات OLE، مصغرات إطارات الفيديو، ومصغرات إطارات الصوت. لتضمين صور الجداول والمخططات وSmartArt وكذلك صور التكبير التجميعي، أعد استخدام منطق الاستخراج المتخصص من الأقسام السابقة مع الحفاظ على نفس تجوال الأشكال العودي.

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

## **حالات حافة وملاحظات عملية**

- **الصور المكررة:** قد تشير عدة أشكال إلى نفس الصورة أو إلى صور منفصلة ذات بايتات متطابقة. احسب تجزئة [IPPImage]::`get_BinaryData()` قبل كتابة الملفات إذا رغبت في ملف خروج واحد لكل صورة فريدة.
- **البيانات الأصلية مقابل المخرجات المحوَّلة:** حفظ [IPPImage]::`get_BinaryData()` يحافظ على بيانات JPEG أو PNG أو GIF أو SVG أو EMF أو WMF المضمّنة. حفظ [IPPImage]::`get_Image()` عبر [IImage]::`Save` مفيد عندما تريد تنسيق إخراج موحد.
- **أنواع الملء غير المدعومة:** لا تحتوي الأشكال ذات الملء الصلب أو المتدرج أو النمطي أو غير المملوء على ملء صورة. تحقق من [FillType] قبل قراءة `get_PictureFillFormat()`.
- **الأشكال المجمعة:** مجموعة أشكال الشريحة الأعلى لا تُسطّح المجموعات. افحص [IGroupShape]::`get_Shapes()` عكسيًا عندما تكون محتويات المجموعة مهمة.
- **معاينات كائن OLE:** قد يُظهر [IOleObjectFrame] صورة معاينة عبر `get_SubstitutePictureFormat()`، لكن هذه الصورة هي مجرد معاينة للشفرة، وليست الملف المضمّن داخل كائن OLE.
- **مصغرات إطارات الفيديو:** قد يُظهر [IVideoFrame] صورة معاينة عبر `get_PictureFormat()`، لكن هذه الصورة هي الملصق المعروض على الشريحة فقط، وليست إطارًا مُستخرجًا من تدفق الفيديو.
- **مصغرات إطارات الصوت:** قد يُظهر [IAudioFrame] أيقونة أو مصغرة عبر `get_PictureFormat()`؛ فهي ليست البيانات الصوتية المضمّنة.
- **صور التكبير:** قد تستخدم أشكال تكبير الشريحة أو القسم أو التجميع صورًا مخصصة عبر كائنات [IPPImage] عبر `get_ZoomImage()`.
- **نماذج الأشكال المتداخلة:** تُنفّذ كائنات الجدول والمخطط وSmartArt واجهة [IShape]، لكن صورها غالبًا ما تُخزّن في كائنات تنسيق خلية الجدول أو عنصر المخطط أو عقدة SmartArt المتداخلة.
- **الصور المقصوصة أو المُحوَّلة:** يُعطيك الوصول إلى [IPPImage] المورد الصوري المخزن. لا يُظهر قصًّا، شفافية، إعادة تلوين، دوران أو أي تأثيرات بصرية أخرى تُطبّق على الشكل.

## **الأسئلة المتكررة**

**هل يمكن استخراج الصورة الأصلية دون قص أو تأثيرات أو تحولات الشكل؟**

نعم. احصل على كائن [IPPImage] واكتب `get_BinaryData()` إلى القرص. هذا يحافظ على الصورة المشفرة الأصلية المخزّنة في العرض التقديمي، وليس على طريقة عرضها على الشريحة.

**هل يمكن تصدير كل صورة مستخرجة كملف PNG؟**

نعم. استخدم [IPPImage]::`get_Image()` للحصول على كائن [IImage]، ثم استدعِ [IImage]::`Save` مع [ImageFormat]::`Png`. سيُحوِّل هذا المخرجات وقد لا يحافظ على نوع الملف الأصلي أو البيانات المتجهية.

**كيف أتجنب حفظ الصورة نفسها أكثر من مرة؟**

استخدم تجزئة [IPPImage]::`get_BinaryData()` واحتفظ بالتجزئات في مجموعة. إذا كان للصورة الجديدة تجزئة موجودة بالفعل، فتجاوزها أو سجّل مرجعًا آخر إلى ملف الإخراج الموجود.

**لماذا لا تنتج بعض الأشكال صورة؟**

يمكن لإطارات الصورة، الأشكال المملوءة بالصور، إطارات كائن OLE، إطارات الوسائط، إطارات التكبير، الجداول، المخططات، وكائنات SmartArt أن تُشير إلى صور. بعض أنواع الأشكال تُظهر الصور عبر كائنات تنسيق متداخلة، لذا فحص `get_PictureFormat()` أو `get_FillFormat()` وحده قد لا يكون كافيًا.

**هل يمكن استخراج المصغرة المعروضة لإطار الفيديو؟**

نعم. استخدم [IVideoFrame]::`get_PictureFormat()` واقرأ `get_PictureFormat()->get_Picture()->get_Image()`. هذا يُستخرج صورة الملصق المخزّنة مع إطار الفيديو، وليس إطارًا مُستخرجًا من ملف الفيديو.

**كيف يمكنني تحديد أي الأشكال تستخدم صورة معينة من مجموعة صور العرض التقديمي؟**

لا يخزن Aspose.Slides روابط عكسية من [IPPImage] إلى الأشكال. قم بإنشاء خريطة أثناء التجوال: كلما وجدت مرجع صورة، سجّل رقم الشريحة، مسار الشكل، وتجزيئة الصورة أو عنصر المجموعة.

**هل يمكن استخراج الصور المضمَّنة داخل كائنات OLE، مثل المستندات المرفقة؟**

يمكنك استخراج معاينة شريحة كائن OLE عبر [IOleObjectFrame]::`get_SubstitutePictureFormat()`. ومع ذلك، تلك المعاينة ليست المستند المضمّن نفسه. لاستخراج الصور من داخل الملف المضمّن، استخرج بيانات OLE وافحصها بأدوات مناسبة لنوع ذلك الملف.