---
title: "إدارة إطارات الصور في العروض التقديمية باستخدام C++"
linktitle: "إطار الصورة"
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
- صورة متجهة
- قص صورة
- منطقة مقصوصة
- خاصية StretchOff
- تنسيق إطار الصورة
- خصائص إطار الصورة
- مقياس نسبي
- تأثير الصورة
- نسبة الأبعاد
- شفافية الصورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "أضف إطارات صور إلى عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة C++. سهل سير العمل وتعزيز تصاميم الشرائح."
---
## **مقدمة**

إطار الصورة هو شكل يحتوي على صورة—إنه مثل صورة داخل إطار.

يمكنك إضافة صورة إلى شريحة عبر إطار صورة. بهذه الطريقة، يمكنك تنسيق الصورة عن طريق تنسيق إطار الصورة.

{{% alert  title="Tip" color="primary" %}} 

توفر Aspose محولات مجانية—[JPEG to PowerPoint](https://products.aspose.app/slides/ar/import/jpg-to-ppt) و[PNG to PowerPoint](https://products.aspose.app/slides/ar/import/png-to-ppt)—التي تتيح للناس إنشاء عروض تقديمية بسرعة من الصور. 

{{% /alert %}} 

## **إنشاء إطار صورة**

1. إنشاء نسخة من فئة [Presentation class](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation).
2. احصل على مرجع الشريحة عبر رقمها. 
3. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_p_p_image) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_image_collection) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل.
4. حدد عرض وارتفاع الصورة.
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.picture_frame) استنادًا إلى عرض وارتفاع الصورة عبر طريقة `AddPictureFrame` التي يوفرها كائن الشكل المرتبط بالشريحة المشار إليها.
6. أضف إطار صورة (يحتوي على الصورة) إلى الشريحة.
7. احفظ العرض المعدل كملف PPTX.

هذا الكود C++ يوضح كيفية إنشاء إطار صورة:

```c++
// مسار دليل المستندات.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// تحميل العرض التقديمي المطلوب
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
SharedPtr<ISlide> slide = pres->get_Slide(0);

// تحميل الصورة التي ستُضاف إلى مجموعة صور العرض
// الحصول على الصورة
auto image = Images::FromFile(filePath);

// إضافة صورة إلى مجموعة صور العرض
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// إضافة إطار صورة إلى الشريحة
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// ضبط عرض وارتفاع المقياس النسبي
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// تطبيق بعض التنسيقات على إطار الصورة
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// حفظ ملف PPTX إلى القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 

تسمح لك إطارات الصور بإنشاء شرائح عروض تقديمية بسرعة استنادًا إلى الصور. عندما تجمع بين إطار الصورة وخيارات الحفظ في Aspose.Slides، يمكنك التحكم بعمليات الإدخال/الإخراج لتحويل الصور من تنسيق إلى آخر. قد ترغب في زيارة هذه الصفحات: تحويل [image to JPG](https://products.aspose.com/slides/ar/cpp/conversion/image-to-jpg/); تحويل [JPG to image](https://products.aspose.com/slides/ar/cpp/conversion/jpg-to-image/); تحويل [JPG to PNG](https://products.aspose.com/slides/ar/cpp/conversion/jpg-to-png/)، تحويل [PNG to JPG](https://products.aspose.com/slides/ar/cpp/conversion/png-to-jpg/); تحويل [PNG to SVG](https://products.aspose.com/slides/ar/cpp/conversion/png-to-svg/)، تحويل [SVG to PNG](https://products.aspose.com/slides/ar/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **إنشاء إطار صورة بمقياس نسبي**

عن طريق تعديل مقياس الصورة النسبي، يمكنك إنشاء إطار صورة أكثر تعقيدًا. 

1. إنشاء نسخة من فئة [Presentation class](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation).
2. احصل على مرجع الشريحة عبر رقمها. 
3. إضافة صورة إلى مجموعة صور العرض.
4. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_p_p_image) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_image_collection) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل.
5. تحديد العرض والارتفاع النسبيين للصورة في إطار الصورة.
6. احفظ العرض المعدل كملف PPTX.

هذا الكود C++ يوضح كيفية إنشاء إطار صورة بمقياس نسبي:

```c++
// مسار دليل المستندات.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// تحميل العرض التقديمي المطلوب.
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى.
SharedPtr<ISlide> slide = pres->get_Slide(0);

// تحميل الصورة التي ستُضاف إلى مجموعة صور العرض.
// الحصول على الصورة.
auto image = Images::FromFile(filePath);

// إضافة صورة إلى مجموعة صور العرض.
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// إضافة إطار صورة إلى الشريحة.
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// ضبط عرض وارتفاع المقياس النسبي.
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// حفظ ملف PPTX إلى القرص.
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **استخراج صور نقطية من إطارات الصور**

يمكنك استخراج الصور النقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.picture_frame) وحفظها بصيغة PNG أو JPG أو صيغ أخرى. يوضح مثال الشيفرة أدناه كيفية استخراج صورة من المستند "sample.pptx" وحفظها بصيغة PNG.

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);
    
if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SystemImage();

    image->Save(u"slide_1_shape_1.png", ImageFormat::get_Png());
}

presentation->Dispose();
```

## **استخراج صور SVG من إطارات الصور**

عندما يحتوي عرض على رسومات SVG موضوعة داخل أشكال [PictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/pictureframe/)، يتيح Aspose.Slides for C++ استرجاع الصور المتجهة الأصلية بجودة عالية. من خلال استعراض مجموعة أشكال الشريحة، يمكنك تحديد كل [PictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/pictureframe/)، والتحقق مما إذا كان [IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/) يحمل محتوى SVG، ثم حفظ تلك الصورة إلى قرص أو تدفق بصيغة SVG الأصلية.

الشيفرة التالية توضح كيفية استخراج صورة SVG من إطار صورة:

```cpp
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

يسمح Aspose.Slides لك بالحصول على تأثير الشفافية المطبق على الصورة. يوضح هذا الكود C++ العملية:

```c++
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

{{% alert color="primary" %}} 
جميع التأثيرات المطبقة على الصور يمكن العثور عليها في [Aspose::Slides::Effects](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/).
{{% /alert %}}

## **الحصول على سطوع وتباين الصورة**

يسمح Aspose.Slides لك بالحصول على تأثير السطوع والتباين المطبق على الصورة. تمثل الواجهة [ILuminance](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/iluminance/) هذا التحول لتأثير الصورة.

يظهر هذا الكود C++ كيفية الحصول على إعدادات السطوع والتباين من إطار صورة:

```c++
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

توفر Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار صورة. باستخدام هذه الخيارات، يمكنك تعديل إطار الصورة ليتطابق مع المتطلبات المحددة.

1. إنشاء نسخة من فئة [Presentation class](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation).
2. احصل على مرجع الشريحة عبر رقمها. 
3. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_p_p_image) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_image_collection) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل.
4. تحديد عرض وارتفاع الصورة.
5. إنشاء `PictureFrame` استنادًا إلى عرض وارتفاع الصورة عبر طريقة [AddPictureFrame](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) التي يوفرها كائن [IShapes](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_shape_collection) المرتبط بالشريحة المشار إليها.
6. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.
7. ضبط لون خط إطار الصورة.
8. ضبط عرض خط إطار الصورة.
9. تدوير إطار الصورة بإعطائه قيمة موجبة أو سالبة.
   * القيمة الموجبة تدور الصورة باتجاه عقارب الساعة. 
   * القيمة السالبة تدور الصورة عكس اتجاه عقارب الساعة.
10. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.
11. احفظ العرض المعدل كملف PPTX.

هذا الكود C++ يوضح عملية تنسيق إطار الصورة:

```c++
// مسار دليل المستندات.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// تحميل العرض التقديمي المطلوب.
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى.
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// تحميل الصورة التي ستُضاف إلى مجموعة صور العرض.
// الحصول على الصورة.
auto image = Images::FromFile(filePath);

// إضافة صورة إلى مجموعة صور العرض.
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// إضافة إطار صورة إلى الشريحة.
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// ضبط عرض وارتفاع المقياس النسبي.
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//كتابة ملف PPTX إلى القرص.
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="primary" %}}

طوّرت Aspose مؤخرًا [أداة مجانية لإنشاء الكولاج](https://products.aspose.app/slides/ar/collage). إذا احتجت إلى دمج صور JPG/JPEG أو PNG، أو إنشاء شبكات من الصور، يمكنك استخدام هذه الخدمة. 

{{% /alert %}}

## **إضافة صورة كرابط**

لتقليل حجم العرض الكبير، يمكنك إضافة الصور (أو مقاطع الفيديو) عبر روابط بدلاً من تضمين الملفات مباشرة في العرض. يوضح هذا الكود C++ كيفية إضافة صورة وفيديو إلى عنصر نائب:

```cpp
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

يظهر هذا الكود C++ كيفية قص صورة موجودة على شريحة:

``` CPP
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// ينشئ كائن صورة جديد
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// يضيف إطار صورة إلى شريحة
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// يقص الصورة (قيم النسبة المئوية)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// يحفظ النتيجة
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **حذف مناطق مقصوصة من إطار الصورة**

إذا رغبت بحذف المناطق المقصوصة من صورة موجودة داخل إطار، يمكنك استخدام طريقة [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). تُعيد هذه الطريقة الصورة المقصوصة أو الصورة الأصلية إذا لم يكن القص ضروريًا.

يظهر هذا الكود C++ العملية:

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// يحصل على إطار الصورة من الشريحة الأولى
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// يحذف المناطق المقصوصة من صورة إطار الصورة ويعيد الصورة المقصوصة
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// يحفظ النتيجة
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="NOTE" color="warning" %}} 

طريقة [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) تضيف الصورة المقصوصة إلى مجموعة صور العرض. إذا كانت الصورة تُستخدم فقط في [PictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/pictureframe/) المعالجة، يمكن لهذا الإعداد تقليل حجم العرض. وإلا، سيزداد عدد الصور في العرض الناتج.

تحول هذه الطريقة ملفات WMF/EMF إلى صورة PNG نقطية أثناء عملية القص. 

{{% /alert %}}

## **ضغط الصور**

يمكنك ضغط صورة في عرض باستخدام طريقة [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/compressimage/).
هذه الطريقة تضغط الصورة عن طريق تقليل حجمها بناءً على حجم الشكل والدقة المحددة، مع إمكانية حذف المناطق المقصوصة.

إنها تضبط حجم الصورة ودقتها مشابهًا لميزة **Picture Format → Compress Pictures → Resolution** في PowerPoint.

توضح الأمثلة C++ التالية كيفية ضغط صورة في عرض بتحديد دقة هدف وإزالة المناطق المقصوصة اختياريًا:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// ضغط الصورة بدقة مستهدفة 150 DPI (دقة الويب) وإزالة المناطق المقصوصة.
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// التحقق من نتيجة الضغط.
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
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// ضغط الصورة إلى 150 DPI (دقة الويب)، مع إزالة المناطق المقصوصة.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}

تحول الطريقة الصورة إلى دقة أقل بناءً على حجم الشكل وDPI المقدم. يمكن أيضًا حذف المناطق المقصوصة لتحسين حجم الملف.
إذا كانت الصورة ملف ميتافايل (WMF/EMF) أو SVG، لن يتم تطبيق الضغط. كما يتم الحفاظ على جودة JPEG أو تقليلها قليلًا بناءً على الدقة، مشابهًا لما يفعله PowerPoint مع JPEG عالي الدقة.

{{% /alert %}}

## **قفل نسبة الأبعاد**

إذا أردت أن يحتفظ الشكل الذي يحتوي على صورة بنسبة أبعادها حتى بعد تغيير أبعاد الصورة، يمكنك استخدام طريقة [set_AspectRatioLocked()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) لتعيين إعداد *قفل نسبة الأبعاد*.

يظهر هذا الكود C++ كيفية قفل نسبة أبعاد الشكل:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// ضبط الشكل للحفاظ على نسبة الأبعاد عند تغيير الحجم
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTE" color="warning" %}} 

إعداد *قفل نسبة الأبعاد* يحافظ فقط على نسبة أبعاد الشكل وليس الصورة التي يحتويها.

{{% /alert %}}

## **استخدام خاصية StretchOff**

باستخدام خصائص [StretchOffsetLeft](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471)، [StretchOffsetTop](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a)، [StretchOffsetRight](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) و[StretchOffsetBottom](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_picture_fill_format) وفئة [PictureFillFormat](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.picture_fill_format)، يمكنك تحديد مستطيل ملء.

عند تحديد تمدد الصورة، يتم تحجيم المستطيل الأصلي ليتناسب مع مستطيل الملء المحدد. كل حد من حدود مستطيل الملء يُعرف بنسبة إزاحة من الحد المقابل لصندوق حدود الشكل. النسبة الموجبة تعني إدخال، والنسبة السالبة تعني خروج.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation).
2. احصل على مرجع الشريحة عبر رقمها.
3. إضافة مستطيل `AutoShape`. 
4. إنشاء صورة.
5. ضبط نوع ملء الشكل.
6. ضبط وضع ملء صورة الشكل.
7. إضافة صورة للملء.
8. تحديد إزاحات الصورة من الحد المقابل لصندوق حدود الشكل.
9. احفظ العرض المعدل كملف PPTX.

هذا الكود C++ يوضح عملية استخدام خاصية StretchOff:

``` cpp
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

## **الأسئلة الشائعة**

**كيف يمكنني معرفة تنسيقات الصور المدعومة لإطار الصورة؟**

يدعم Aspose.Slides كلًا من الصور النقطية (PNG, JPEG, BMP, GIF, إلخ) والصور المتجهة (مثل SVG) عبر كائن الصورة المرفق بـ [PictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/pictureframe/). القائمة المدعومة تتقاطع عمومًا مع قدرات محرك تحويل الشرائح والصور.

**كيف سيؤثر إضافة العشرات من الصور الكبيرة على حجم PPTX وأدائه؟**

تؤدي تضمين الصور الكبيرة إلى زيادة حجم الملف واستهلاك الذاكرة؛ ربط الصور يساعد في تقليل حجم العرض لكنه يتطلب بقاء الملفات الخارجية متاحة. يتيح Aspose.Slides إمكانية إضافة الصور عبر روابط لتقليل حجم الملف.

**كيف يمكنني قفل كائن الصورة لمنعه من التحرك أو إعادة الحجم بطريق الخطأ؟**

استخدم [قفل الشكل](https://reference.aspose.com/slides/ar/cpp/aspose.slides/pictureframe/get_pictureframelock/) لـ [PictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/pictureframe/) (مثل تعطيل التحريك أو إعادة الحجم). تم شرح آلية القفل للأشكال في مقالة [الحماية](/slides/ar/cpp/applying-protection-to-presentation/) وتدعم أنواعًا متعددة من الأشكال بما فيها [PictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/pictureframe/).

**هل يتم الحفاظ على دقة SVG المتجهة عند تصدير العرض إلى PDF/صور؟**

يسمح Aspose.Slides باستخراج SVG من [PictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/pictureframe/) كمتجه أصلي. عند التصدير إلى PDF أو صيغ نقطية، قد يتم تحويله إلى نقطية وفقًا لإعدادات التصدير؛ لكن حفظه كمتجه يتم التأكد منه عبر سلوك الاستخراج.