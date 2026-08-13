---
title: إدارة إطارات الصور في العروض التقديمية باستخدام C++
linktitle: إطار صورة
type: docs
weight: 10
url: /ar/cpp/picture-frame/
keywords:
- إطار صورة
- إضافة إطار صورة
- إنشاء إطار صورة
- إضافة صورة
- إنشاء صورة
- استخراج صورة
- صورة نقطية
- صورة متجهية
- قص صورة
- منطقة مقصوصة
- خاصية StretchOff
- تنسيق إطار صورة
- خصائص إطار صورة
- مقياس نسبي
- تأثير الصورة
- نسبة الأبعاد
- شفافية الصورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "إضافة إطارات صورة إلى عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة C++. سهل سير عملك وعزز تصاميم الشرائح."
---
## **المقدمة**

إطار الصورة هو شكل يحتوي على صورة — إنه كالصورة داخل إطار. 

يمكنك إضافة صورة إلى شريحة عبر إطار صورة. بهذه الطريقة، يمكنك تنسيق الصورة عن طريق تنسيق إطار الصورة.

{{% alert  title="Tip" color="info" %}} 
توفر Aspose محولات مجانية—[JPEG to PowerPoint](https://products.aspose.app/slides/ar/import/jpg-to-ppt) و[PNG to PowerPoint](https://products.aspose.app/slides/ar/import/png-to-ppt)—تمكن الأشخاص من إنشاء عروض تقديمية بسرعة من الصور. 
{{% /alert %}} 

## **إنشاء إطار صورة**

1. إنشاء كائن من فئة [Presentation class](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation).
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_p_p_image) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_image_collection) المرتبط بكائن العرض التقديمي والذي سيُستخدم لملء الشكل.
4. تحديد عرض الصورة وارتفاعها.
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.picture_frame) بناءً على عرض الصورة وارتفاعها من خلال طريقة `AddPictureFrame` التي تكشفها كائن الشكل المرتبط بالشريحة المشار إليها.
6. إضافة إطار صورة (يحتوي على الصورة) إلى الشريحة.
7. حفظ العرض التقديمي المعدل كملف PPTX.

يعرض هذا الكود بلغة C++ كيفية إنشاء إطار صورة:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <drawing/color.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// مسار دليل المستندات.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// تحميل العرض التقديمي المطلوب
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
SharedPtr<ISlide> slide = pres->get_Slide(0);

// تحميل الصورة التي سيتم إضافتها إلى مجموعة صور العرض التقديمي
// الحصول على الصورة
auto image = Images::FromFile(filePath);

// إضافة صورة إلى مجموعة صور العرض التقديمي
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// إضافة إطار صورة إلى الشريحة
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// ضبط العرض والارتفاع بالمقياس النسبي
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// تطبيق بعض التنسيقات على إطار الصورة
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// كتابة ملف PPTX إلى القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 
تتيح إطارات الصورة إنشاء شرائح عرض تقديمي بسرعة بناءً على الصور. عندما تجمع بين إطار الصورة وخيارات الحفظ في Aspose.Slides، يمكنك التحكم في عمليات الإدخال/الإخراج لتحويل الصور من صيغة إلى أخرى. قد ترغب في الاطلاع على هذه الصفحات: تحويل [image to JPG](https://products.aspose.com/slides/ar/cpp/conversion/image-to-jpg/); تحويل [JPG to image](https://products.aspose.com/slides/ar/cpp/conversion/jpg-to-image/); تحويل [JPG to PNG](https://products.aspose.com/slides/ar/cpp/conversion/jpg-to-png/), تحويل [PNG to JPG](https://products.aspose.com/slides/ar/cpp/conversion/png-to-jpg/); تحويل [PNG to SVG](https://products.aspose.com/slides/ar/cpp/conversion/png-to-svg/), تحويل [SVG to PNG](https://products.aspose.com/slides/ar/cpp/conversion/svg-to-png/).
{{% /alert %}}

## **إنشاء إطار صورة مع مقياس نسبي**

عن طريق تعديل مقياس الصورة النسبي، يمكنك إنشاء إطار صورة أكثر تعقيدًا. 

1. إنشاء كائن من فئة [Presentation class](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation).
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. إضافة صورة إلى مجموعة صور العرض التقديمي.
4. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_p_p_image) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_image_collection) المرتبط بكائن العرض التقديمي والذي سيُستخدم لملء الشكل.
5. تحديد العرض والارتفاع النسبيين للصورة داخل إطار الصورة.
6. حفظ العرض التقديمي المعدل كملف PPTX.

يوضح مثال الشيفرة أدناه كيفية إنشاء إطار صورة مع مقياس نسبي:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// مسار دليل المستندات.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// تحميل العرض التقديمي المطلوب
// الوصول إلى الشريحة الأولى
SharedPtr<ISlide> slide = pres->get_Slide(0);

// تحميل الصورة التي ستُضاف إلى مجموعة صور العرض التقديمي
// الحصول على الصورة
auto image = Images::FromFile(filePath);

// إضافة صورة إلى مجموعة صور العرض التقديمي
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// إضافة إطار صورة إلى الشريحة
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// ضبط العرض والارتفاع بالمقياس النسبي
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Writes ملف PPTX إلى القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **استخراج الصور النقطية من إطارات الصور**

يمكنك استخراج الصور النقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.picture_frame) وحفظها بصيغ PNG، JPG، وغيرها. يوضح مثال الشيفرة أدناه كيفية استخراج صورة من المستند "sample.pptx" وحفظها بصيغة PNG.

```c++
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_Image();

    image->Save(u"slide_1_shape_1.png", ImageFormat::Png);
}

presentation->Dispose();
```

## **استخراج صور SVG من إطارات الصور**

عندما يحتوي عرض تقديمي على رسومات SVG موضوعة داخل أشكال [PictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/pictureframe/) ، يتيح Aspose.Slides للـ C++ استرجاع صور المتجه الأصلية بجودة كاملة. من خلال استعراض مجموعة أشكال الشريحة، يمكنك تحديد كل [PictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/pictureframe/)، والتحقق مما إذا كان [IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/) الأساسي يحتوي على محتوى SVG، ثم حفظ تلك الصورة على القرص أو تدفق بصيغة SVG الأصلية.

يعرض المثال التالي كيفية استخراج صورة SVG من إطار صورة:

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(shape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto svgImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SvgImage();
    if (svgImage != nullptr)
    {
        File::WriteAllText(u"output.svg", svgImage->get_SvgContent());
    }
}

presentation->Dispose();
```

## **الحصول على شفافية الصورة**

يتيح Aspose.Slides الحصول على تأثير الشفافية المطبق على صورة. يوضح هذا الكود بلغة C++ العملية:

```c++
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"Test.pptx");
auto pictureFrame = System::ExplicitCast<IPictureFrame>(presentation->get_Slide(0)->get_Shape(0));
auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<IAlphaModulateFixed>(effect))
    {
        float transparencyValue = 100.0f - (System::ExplicitCast<IAlphaModulateFixed>(effect))->get_Amount();
        System::Console::WriteLine(System::String(u"Picture transparency: ") + transparencyValue);
    }
}
```

{{% alert color="info" %}} 
جميع التأثيرات المطبقة على الصور يمكن العثور عليها في [Aspose::Slides::Effects](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/).
{{% /alert %}}

## **الحصول على السطوع والتباين للصورة**

يتيح Aspose.Slides الحصول على تأثير السطوع والتباين المطبق على صورة. تمثل الواجهة [ILuminance](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/iluminance/) هذا التأثير التحويلي للصورة.

يوضح هذا الكود بلغة C++ كيفية الحصول على إعدادات السطوع والتباين من إطار صورة:

```c++
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shape(0);
auto pictureFrame = System::ExplicitCast<IPictureFrame>(shape);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<ILuminance>(effect))
    {
        auto luminance = System::ExplicitCast<ILuminance>(effect)->GetEffective();
        auto brightness = luminance->get_Brightness();
        auto contrast = luminance->get_Contrast();

        Console::WriteLine(System::String(u"Brightness: ") + brightness);
        Console::WriteLine(System::String(u"Contrast: ") + contrast);
    }
}

presentation->Dispose();
```

## **تنسيق إطار الصورة**

يوفر Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار الصورة. باستخدام هذه الخيارات، يمكنك تعديل إطار الصورة لتلبية متطلبات محددة.

1. إنشاء كائن من فئة [Presentation class](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation).
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_p_p_image) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_image_collection) المرتبط بكائن العرض التقديمي والذي سيُستخدم لملء الشكل.
4. تحديد عرض الصورة وارتفاعها.
5. إنشاء `PictureFrame` بناءً على عرض الصورة وارتفاعها من خلال طريقة [AddPictureFrame](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) التي تكشفها كائن [IShapes](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_shape_collection) المرتبط بالشريحة المشار إليها.
6. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.
7. تعيين لون خط إطار الصورة.
8. تعيين عرض خط إطار الصورة.
9. تدوير إطار الصورة بإعطائه قيمة موجبة أو سالبة.  
   * القيمة الموجبة تدور الصورة في اتجاه عقارب الساعة.  
   * القيمة السالبة تدور الصورة في الاتجاه العكسى لعقارب الساعة.
10. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.
11. حفظ العرض التقديمي المعدل كملف PPTX.

يوضح هذا الكود بلغة C++ عملية تنسيق إطار الصورة:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// مسار دليل المستندات.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// تحميل العرض التقديمي المطلوب
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// تحميل الصورة التي ستُضاف إلى مجموعة صور العرض التقديمي
// الحصول على الصورة
auto image = Images::FromFile(filePath);

// إضافة صورة إلى مجموعة صور العرض التقديمي
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// إضافة إطار صورة إلى الشريحة
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// ضبط العرض والارتفاع بالمقياس النسبي
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// كتابة ملف PPTX إلى القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="info" %}}
قامت Aspose مؤخرًا بتطوير [free Collage Maker](https://products.aspose.app/slides/ar/collage). إذا احتجت إلى [دمج JPG/JPEG](https://products.aspose.app/slides/ar/collage/jpg) أو PNG، أو [إنشاء شبكات من الصور](https://products.aspose.app/slides/ar/collage/photo-grid)، يمكنك استخدام هذه الخدمة. 
{{% /alert %}}

## **إضافة صورة كرابط**

لتجنب أحجام العروض الكبيرة، يمكنك إضافة صور (أو مقاطع فيديو) عبر روابط بدلاً من تضمين الملفات مباشرة في العروض. يوضح هذا الكود بلغة C++ كيفية إضافة صورة وفيديو إلى عنصر نائب:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IVideoFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/collections/list.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapesToRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IShape>>>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

for (auto& autoShape : shapes)
{
    if (autoShape->get_Placeholder() == nullptr)
        continue;

    switch (autoShape->get_Placeholder()->get_Type())
    {
        case Aspose::Slides::PlaceholderType::Picture:
        {
            auto pictureFrame = shapes->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), nullptr);
            pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            shapesToRemove->Add(autoShape);
            break;
        }

        case Aspose::Slides::PlaceholderType::Media:
        {
            auto videoFrame = shapes->AddVideoFrame(autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), u"");
            videoFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            videoFrame->set_LinkPathLong(u"https://youtu.be/t_1LYZ102RA");
            shapesToRemove->Add(autoShape);
            break;
        }
    }
}

for (auto& shape : shapesToRemove)
{
    shapes->Remove(shape);
}

presentation->Save(u"output.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **قص الصور**

يوضح هذا الكود بلغة C++ كيفية قص صورة موجودة على شريحة:

``` CPP
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
// إنشاء كائن صورة جديد
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(u"image.png"));

// إضافة إطار صورة إلى شريحة
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// قص الصورة (قيم النسبة المئوية)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// حفظ النتيجة
presentation->Save(u"cropped.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **حذف المناطق المقصوصة من الإطار**

إذا كنت ترغب في حذف المناطق المقصوصة لصورة موجودة داخل إطار، يمكنك استخدام طريقة [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). تُعيد هذه الطريقة الصورة المقصوصة أو الصورة الأصلية إذا لم يكن القَصّ ضروريًا.

يوضح هذا الكود بلغة C++ العملية:

```c++
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// يجلب إطار الصورة من الشريحة الأولى
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// يحذف المناطق المقصوصة من صورة إطار الصورة ويعيد الصورة المقصوصة
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// يحفظ النتيجة
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="NOTE" color="warning" %}} 
طريقة [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) تضيف الصورة المقصوصة إلى مجموعة صور العرض التقديمي. إذا كانت الصورة مستخدمة فقط في [PictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/pictureframe/) المعالجة، يمكن لهذا الإعداد تقليل حجم العرض. وإلا، سيزيد عدد الصور في العرض الناتج. 

تحول الطريقة ملفات WMF/EMF إلى صورة PNG نقطية أثناء عملية القَص. 
{{% /alert %}}

## **ضغط الصور**

يمكنك ضغط صورة في عرض تقديمي باستخدام طريقة [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/compressimage/). تقوم هذه الطريقة بضغط الصورة عن طريق تقليل حجمها بناءً على حجم الشكل والدقة المحددة، مع إمكانية حذف المناطق المقصوصة.

إنها تضبط حجم الصورة ودقتها بصورة مشابهة لميزة **Picture Format -> Compress Pictures -> Resolution** في PowerPoint.

توضح الأمثلة التالية بلغة C++ كيفية ضغط صورة في عرض تقديمي بتحديد دقة مستهدفة وحذف المناطق المقصوصة إذا رغبت:

```c++
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// ضغط الصورة بدقة مستهدفة 150 DPI (دقة الويب) وإزالة المناطق المقصوصة.
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// تحقق من نتيجة الضغط.
if (result)
{
    System::Console::WriteLine(u"Image successfully compressed.");
}
else
{
    System::Console::WriteLine(u"Image compression failed or no changes were necessary.");
}

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

أو باستخدام قيمة DPI مخصصة مباشرة:

```c++
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// ضغط الصورة إلى 150 DPI (دقة الويب)، مع إزالة المناطق المقصوصة.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}} 
تحول الطريقة الصورة إلى دقة أقل بناءً على حجم الشكل وDPI المقدم. يمكن أيضًا حذف المناطق المقصوصة لتحسين حجم الملف. إذا كانت الصورة ملفًا ميتافي (WMF/EMF) أو SVG، فلن يتم تطبيق الضغط. كذلك، تحافظ جودة JPEG أو تُخفض قليلاً وفقًا للدقة، كما يفعل PowerPoint مع JPEG عالي الدقة. 
{{% /alert %}}

## **قفل نسبة الأبعاد**

إذا أردت أن يحتفظ الشكل الذي يحتوي على صورة بنسبة أبعاده حتى بعد تغيير أبعاد الصورة، يمكنك استخدام طريقة [set_AspectRatioLocked()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) لتعيين إعداد *Lock Aspect Ratio*. 

يوضح هذا الكود بلغة C++ كيفية قفل نسبة أبعاد الشكل:

```c++
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// set shape to have to preserve aspect ratio on resizing
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTE" color="warning" %}} 
إعداد *Lock Aspect Ratio* يحافظ فقط على نسبة أبعاد الشكل ولا يؤثر على الصورة التي يحتويها. 
{{% /alert %}}

## **استخدام خاصية StretchOff**

باستخدام خصائص [StretchOffsetLeft](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471)، [StretchOffsetTop](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a)، [StretchOffsetRight](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) و[StretchOffsetBottom](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_picture_fill_format) والفئة [PictureFillFormat](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.picture_fill_format)، يمكنك تحديد مستطيل ملء. 

عند تحديد تمدد الصورة، يتم تعديل حجم المستطيل المصدر ليتناسب مع مستطيل الملء المحدد. كل حافة من حواف مستطيل الملء تُعرَّف بنسبة إزاحة من الحافة المقابلة لإطار الشكل. النسبة الموجبة تمثل تقليلًا داخليًا، بينما النسبة السالبة تمثل توسيعًا خارجيًا.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation).
2. الحصول على مرجع الشريحة عبر فهرستها.
3. إضافة مستطيل `AutoShape`.
4. إنشاء صورة.
5. تحديد نوع ملء الشكل.
6. تحديد وضع ملء الصورة للشكل.
7. إضافة صورة لتعبئة الشكل.
8. تحديد إزاحات الصورة من الحافة المقابلة لإطار الشكل.
9. حفظ العرض التقديمي المعدل كملف PPTX.

يوضح هذا الكود بلغة C++ عملية استخدام خاصية StretchOff:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// Sets the image stretched from each side in the shape body
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **FAQ**

### كيف يمكنني معرفة صيغ الصور المدعومة لإطار الصورة (PictureFrame)؟

يدعم Aspose.Slides كلًا من الصور النقطية (PNG، JPEG، BMP، GIF، إلخ) والصور المتجهية (مثل SVG) عبر كائن الصورة المرفق بـ [PictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/pictureframe/). عادةً ما تتقاطع قائمة الصيغ المدعومة مع قدرات محرك التحويل داخل الشرائح.

### كيف سيؤثر إضافة العشرات من الصور الكبيرة على حجم PPTX والأداء؟

تزيد الصور المضمَّنة من حجم الملف واستهلاك الذاكرة؛ ربط الصور يقلل حجم العرض لكنه يتطلب بقاء الملفات الخارجية متاحة. يوفر Aspose.Slides إمكانية إضافة الصور عبر الروابط لتقليل حجم الملف.

### كيف يمكنني قفل كائن صورة من التحريك أو إعادة التحجيم غير المقصود؟

استخدم أقفال الشكل عبر [shape locks](https://reference.aspose.com/slides/ar/cpp/aspose.slides/pictureframe/get_pictureframelock/) لـ [PictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/pictureframe/) (مثلاً، تعطيل التحريك أو التحجيم). يشرح مقالة الحماية الخاصة بالأشكال هذا الآلية وتدعم أنواعًا متعددة من الأشكال بما فيها [PictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/pictureframe/).

### هل يتم الحفاظ على دقة المتجهات في SVG عند تصدير العرض إلى PDF/صور؟

يسمح Aspose.Slides باستخراج SVG من [PictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/pictureframe/) كمتجه أصلي. عند التصدير إلى PDF (/slides/ar/cpp/convert-powerpoint-to-pdf/) أو صيغ النقطية (/slides/ar/cpp/convert-powerpoint-to-png/)، قد تُرسم النتيجة كصورة نقطية وفقًا لإعدادات التصدير؛ لكن سلوك الاستخراج يؤكد أن SVG الأصلي يبقى كمتجه.