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
- نسبة العرض إلى الارتفاع
- شفافية الصورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "أضف إطارات الصور إلى عروض PowerPoint و OpenDocument باستخدام Aspose.Slides للغة C++. سهل سير عملك وعزز تصاميم الشرائح."
---

إطار الصورة هو شكل يحتوي على صورة — إنه مثل صورة داخل إطار.

يمكنك إضافة صورة إلى شريحة عبر إطار صورة. بهذه الطريقة، يمكنك تنسيق الصورة عن طريق تنسيق إطار الصورة.

{{% alert  title="نصيحة" color="primary" %}} 
توفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—تسمح للناس بإنشاء عروض تقديمية بسرعة من الصور. 
{{% /alert %}} 

## **إنشاء إطار صورة**

1. إنشاء كائن من فئة [Presentation class](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. احصل على مرجع الشريحة عبر فهرستها.
3. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) عن طريق إضافة صورة إلى مجموعة [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل.
4. حدد عرض وارتفاع الصورة.
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_frame) استنادًا إلى عرض وارتفاع الصورة عبر طريقة `AddPictureFrame` التي يوفرها كائن الشكل المرتبط بالشريحة المشار إليها.
6. إضافة إطار صورة (المحتوي على الصورة) إلى الشريحة.
7. حفظ العرض المعدل كملف PPTX.

يوضح لك هذا الكود C++ كيفية إنشاء إطار صورة:
```c++
// مسار دليل المستندات.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// تحميل العرض التقديمي المطلوب
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
SharedPtr<ISlide> slide = pres->get_Slide(0);

// تحميل الصورة التي ستُضاف إلى مجموعة صور العرض التقديمي
// الحصول على الصورة
auto image = Images::FromFile(filePath);

// إضافة صورة إلى مجموعة صور العرض التقديمي
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// إضافة إطار صورة إلى الشريحة
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// تعيين نسبة العرض والارتفاع النسبية
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// تطبيق بعض التنسيقات على إطار الصورة
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

//كتابة ملف PPTX إلى القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


{{% alert color="warning" %}} 
تسمح لك إطارات الصور بإنشاء شرائح عرض تقديمي بسرعة استنادًا إلى الصور. عندما تجمع بين إطار الصورة مع خيارات الحفظ في Aspose.Slides، يمكنك التحكم في عمليات الإدخال/الإخراج لتحويل الصور من تنسيق إلى آخر. قد ترغب في زيارة هذه الصفحات: تحويل [صورة إلى JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/)، تحويل [PNG إلى JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/)، تحويل [SVG إلى PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/). 
{{% /alert %}}

## **إنشاء إطار صورة مع مقياس نسبي**

عن طريق تعديل مقياس الصورة النسبي، يمكنك إنشاء إطار صورة أكثر تعقيدًا.

1. إنشاء كائن من فئة [Presentation class](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. احصل على مرجع الشريحة عبر فهرستها.
3. إضافة صورة إلى مجموعة صور العرض.
4. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) عن طريق إضافة صورة إلى مجموعة [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل.
5. تحديد العرض والارتفاع النسبيين للصورة داخل إطار الصورة.
6. حفظ العرض المعدل كملف PPTX.

يوضح لك هذا الكود C++ كيفية إنشاء إطار صورة مع مقياس نسبي:
```c++
// مسار دليل المستندات.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// تحميل العرض التقديمي المطلوب
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
SharedPtr<ISlide> slide = pres->get_Slide(0);

// تحميل الصورة التي ستُضاف إلى مجموعة صور العرض التقديمي
// الحصول على الصورة
auto image = Images::FromFile(filePath);

// إضافة صورة إلى مجموعة صور العرض التقديمي
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// إضافة إطار صورة إلى الشريحة
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// تعيين نسبة العرض والارتفاع النسبية
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// كتابة ملف PPTX إلى القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **استخراج الصور النقطية من إطارات الصورة**

يمكنك استخراج الصور النقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_frame) وحفظها بصيغ PNG، JPG، وغيرها. يوضح المثال البرمجي أدناه كيفية استخراج صورة من المستند "sample.pptx" وحفظها بتنسيق PNG.
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


## **استخراج صور SVG من إطارات الصورة**

عندما يحتوي عرض على رسومات SVG موضوعة داخل أشكال [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) ، يسمح Aspose.Slides للـ C++ باسترجاع الصور المتجهة الأصلية بجودة كاملة. من خلال استعراض مجموعة أشكال الشريحة، يمكنك تحديد كل [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/)، وفحص ما إذا كان كائن [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) يحتوي على محتوى SVG، ثم حفظ تلك الصورة إلى القرص أو تدفق بصيغتها الأصلية SVG.

يوضح المثال البرمجي التالي كيفية استخراج صورة SVG من إطار صورة:
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

تسمح لك Aspose.Slides بالحصول على تأثير الشفافية المطبق على الصورة. يظهر هذا الكود C++ العملية:
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
يمكن العثور على جميع التأثيرات المطبقة على الصور في [Aspose::Slides::Effects](https://reference.aspose.com/slides/cpp/aspose.slides.effects/). 
{{% /alert %}}

## **تنسيق إطار الصورة**

توفر Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار الصورة. باستخدام هذه الخيارات، يمكنك تعديل إطار الصورة ليتطابق مع المتطلبات المحددة.

1. إنشاء كائن من فئة [Presentation class](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. احصل على مرجع الشريحة عبر فهرستها.
3. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) عن طريق إضافة صورة إلى مجموعة [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل.
4. حدد عرض وارتفاع الصورة.
5. إنشاء `PictureFrame` استنادًا إلى عرض وارتفاع الصورة عبر طريقة [AddPictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) التي يوفرها كائن [IShapes](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) المرتبط بالشريحة المشار إليها.
6. إضافة إطار الصورة (المحتوي على الصورة) إلى الشريحة.
7. تعيين لون حد إطار الصورة.
8. تعيين عرض حد إطار الصورة.
9. تدوير إطار الصورة عن طريق إعطائه قيمة إيجابية أو سلبية.
   * قيمة إيجابية تدور الصورة مع عقارب الساعة.
   * قيمة سلبية تدور الصورة عكس عقارب الساعة.
10. إضافة إطار الصورة (المحتوي على الصورة) إلى الشريحة.
11. حفظ العرض المعدل كملف PPTX.

يوضح هذا الكود C++ عملية تنسيق إطار الصورة:
```c++
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

// تعيين نسبة العرض والارتفاع النسبية
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// كتابة ملف PPTX إلى القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


{{% alert title="نصيحة" color="primary" %}}

قامت Aspose مؤخرًا بتطوير [صانع كولاج مجاني](https://products.aspose.app/slides/collage). إذا احتجت إلى دمج صور JPG/JPEG أو PNG، أو إنشاء شبكات من الصور، يمكنك استخدام هذه الخدمة. 
{{% /alert %}}

## **إضافة صورة كارتباط**

لتجنب أحجام عروض تقديمية كبيرة، يمكنك إضافة الصور (أو الفيديوهات) من خلال روابط بدلاً من تضمين الملفات مباشرةً في العروض. يظهر لك هذا الكود C++ كيفية إضافة صورة وفيديو إلى عنصر نائب:
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

يوضح لك هذا الكود C++ كيفية قص صورة موجودة على شريحة:
```CPP
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// إنشاء كائن صورة جديد
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// إضافة إطار صورة إلى شريحة
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// اقتصاص الصورة (قيم النسبة المئوية)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// حفظ النتيجة
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **حذف المناطق المقصوصة من الصورة**

إذا رغبت في حذف المناطق المقصوصة من صورة موجودة في إطار، يمكنك استخدام طريقة [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). تُعيد هذه الطريقة الصورة المقتطة أو الصورة الأصلية إذا لم يكن القص ضروريًا.

يوضح هذا الكود C++ العملية:
```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Gets the PictureFrame from the first slide
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Deletes cropped areas of the PictureFrame image and returns the cropped image
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Saves the result
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```


{{% alert title="ملاحظة" color="warning" %}} 

تضيف طريقة [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) الصورة المقتطة إلى مجموعة صور العرض. إذا كانت الصورة مستخدمة فقط في [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) المعالجة، يمكن لهذا الإعداد تقليل حجم العرض. وإلا، سيزيد عدد الصور في العرض الناتج.

تحوِّل هذه الطريقة ملفات WMF/EMF إلى صور PNG نقطية في عملية القص. 
{{% /alert %}}

## **قفل نسبة العرض إلى الارتفاع**

إذا أردت أن يحتفظ الشكل الذي يحتوي على صورة بنسبة عرضه إلى ارتفاعه حتى بعد تغيير أبعاد الصورة، يمكنك استخدام طريقة [set_AspectRatioLocked()](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) لتفعيل إعداد *قفل نسبة العرض إلى الارتفاع*.

يوضح هذا الكود C++ كيفية قفل نسبة عرض الشكل:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// set shape to have to preserve aspect ratio on resizing
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```


{{% alert title="ملاحظة" color="warning" %}} 

إعداد *قفل نسبة العرض إلى الارتفاع* يحافظ فقط على نسبة الشكل وليس الصورة التي يحتويها. 
{{% /alert %}}

## **استخدام خاصية StretchOff**

باستخدام الخصائص [StretchOffsetLeft](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471)، [StretchOffsetTop](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a)، [StretchOffsetRight](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) و[StretchOffsetBottom](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_fill_format) وفئة [PictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format)، يمكنك تحديد مستطيل تعبئة.

عند تحديد تمديد الصورة، يتم تحجيم المستطيل المصدر ليناسب مستطيل التعبئة المحدد. كل حافة من حواف مستطيل التعبئة تُعرف بنسبة إزاحة من الحافة المقابلة لمستطيل حدود الشكل. النسبة الموجبة تعني داخلي، والنسبة السالبة تعني خارجي.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. احصل على مرجع الشريحة عبر فهرستها.
3. إضافة مستطيل `AutoShape`.
4. إنشاء صورة.
5. تعيين نوع تعبئة الشكل.
6. تعيين وضع تعبئة صورة الشكل.
7. إضافة صورة تعبئة لتعبئة الشكل.
8. تحديد إزاحات الصورة من الحافة المقابلة لمستطيل حدود الشكل.
9. حفظ العرض المعدل كملف PPTX.

يوضح هذا الكود C++ عملية استخدام خاصية StretchOff:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// يضبط تمدد الصورة من كل جانب في جسم الشكل
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```


## **الأسئلة المتكررة**

**كيف يمكنني معرفة تنسيقات الصور المدعومة لإطار الصورة؟**

يدعم Aspose.Slides كلًّا من الصور النقطية (PNG، JPEG، BMP، GIF، إلخ) والصور المتجهة (مثل SVG) عبر كائن الصورة المُعيّن إلى [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/). عمومًا تتقاطع قائمة التنسيقات المدعومة مع قدرات محرك التحويل للشرائح والصور.

**كيف سيؤثر إضافة العشرات من الصور الكبيرة على حجم PPTX والأداء؟**

تؤدي إضافة الصور الكبيرة إلى زيادة حجم الملف واستهلاك الذاكرة؛ ربط الصور يساعد على تقليل حجم العرض لكنه يتطلب توافر الملفات الخارجية. يوفر Aspose.Slides إمكانية إضافة الصور عبر رابط لتقليل حجم الملف.

**كيف يمكنني قفل كائن الصورة لمنع تحريكه/تغييره غير مقصود؟**

استخدم [قفل الأشكال](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/get_pictureframelock/) لإطار الصورة (مثلاً، تعطيل التحريك أو تغيير الحجم). يُشرح آلية القفل للأشكال في مقالة الحماية المنفصلة [/slides/cpp/applying-protection-to-presentation/] وتُدعم لأنواع متعددة من الأشكال بما في ذلك [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/).

**هل يتم الحفاظ على دقة متجهات SVG عند تصدير العرض إلى PDF/صور؟**

يتيح Aspose.Slides استخراج SVG من [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) كمتجه أصلي. عند التصدير إلى PDF أو تنسيقات نقطية، قد يتم تحويل النتيجة إلى نقطية بحسب إعدادات التصدير؛ ومع ذلك يبقى أن الـ SVG الأصلي مخزنًا كمتجه كما يؤكد سلوك الاستخراج.