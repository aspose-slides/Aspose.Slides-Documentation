---
title: إطار الصورة
type: docs
weight: 10
url: /cpp/picture-frame/
keywords: "إضافة إطار الصورة، إنشاء إطار الصورة، إضافة صورة، إنشاء صورة، استخراج صورة، خاصية StretchOff، تنسيق إطار الصورة، خصائص إطار الصورة، عرض PowerPoint، C++، CPP، Aspose.Slides لـ C++"
description: "إضافة إطار صورة إلى عرض PowerPoint في C++"
---

إطار الصورة هو شكل يحتوي على صورة—مثل صورة في إطار.

يمكنك إضافة صورة إلى الشريحة من خلال إطار الصورة. بهذه الطريقة، يمكنك تنسيق الصورة من خلال تنسيق إطار الصورة.

{{% alert title="نصيحة" color="primary" %}} 

توفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—تتيح للناس إنشاء عروض تقديمية بسرعة من الصور.

{{% /alert %}} 

## **إنشاء إطار صورة**

1. أنشئ مثيل من [فئة Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. احصل على مرجع الشريحة من خلال فهرسها.
3. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) المرتبطة بكائن العرض الذي سيتم استخدامه لملء الشكل.
4. حدد عرض وارتفاع الصورة.
5. أنشئ [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_frame) بناءً على عرض وارتفاع الصورة من خلال طريقة `AddPictureFrame` المعروضة بواسطة كائن الشكل المرتبط بالشريحة المُرجعة.
6. أضف إطار صورة (يحتوي على الصورة) إلى الشريحة.
7. اكتب العرض المعدل كملف PPTX.

يوضح هذا الكود بلغة C++ كيفية إنشاء إطار صورة:

```c++
// المسار إلى دليل المستندات.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// تحميل العرض المطلوب
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
SharedPtr<ISlide> slide = pres->get_Slide(0);

// تحميل الصورة التي ستتم إضافتها إلى مجموعة الصور في العرض
// الحصول على الصورة
auto image = Images::FromFile(filePath);

// إضافة صورة إلى مجموعة الصور في العرض
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// إضافة إطار صورة إلى الشريحة
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// تعيين قياس العرض والارتفاع النسبي
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// تطبيق بعض التنسيق على إطار الصورة
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// كتابة ملف PPTX على القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 

تتيح لك إطارات الصورة إنشاء شرائح عرض تقديمي بسرعة استنادًا إلى الصور. عندما تجمع بين إطار الصورة مع خيارات الحفظ في Aspose.Slides، يمكنك التعامل مع عمليات الإدخال / الإخراج لتحويل الصور من تنسيق إلى آخر. قد ترغب في رؤية هذه الصفحات: تحويل [الصورة إلى JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/)؛ تحويل [JPG إلى صورة](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/)؛ تحويل [JPG إلى PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/)، تحويل [PNG إلى JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/)؛ تحويل [PNG إلى SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/)، تحويل [SVG إلى PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **إنشاء إطار صورة مع معدل قياس نسبي**

من خلال تغيير قياس الصورة النسبي، يمكنك إنشاء إطار صورة أكثر تعقيدًا.

1. أنشئ مثيل من [فئة Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. احصل على مرجع الشريحة من خلال فهرسها.
3. أضف صورة إلى مجموعة الصور في العرض.
4. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) المرتبطة بكائن العرض الذي سيتم استخدامه لملء الشكل.
5. حدد العرض والارتفاع النسبي للصورة في إطار الصورة.
6. اكتب العرض المعدل كملف PPTX.

يوضح هذا الكود بلغة C++ كيفية إنشاء إطار صورة مع معدل قياس نسبي:

```c++
// المسار إلى دليل المستندات.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// تحميل العرض المطلوب
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
SharedPtr<ISlide> slide = pres->get_Slide(0);

// تحميل الصورة التي سيتم إضافتها إلى مجموعة الصور في العرض
// الحصول على الصورة
auto image = Images::FromFile(filePath);

// إضافة صورة إلى مجموعة الصور في العرض
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// إضافة إطار صورة إلى الشريحة
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// تعيين قياس العرض والارتفاع النسبي
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// كتابة ملف PPTX على القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **استخراج الصورة من إطار الصورة**

يمكنك استخراج الصور من كائنات [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_frame) وحفظها في PNG وJPG وبتنسيقات أخرى. يوضح المثال البرمجي أدناه كيفية استخراج صورة من وثيقة "sample.pptx" وحفظها بتنسيق PNG.

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

## **الحصول على شفافية الصورة**

تسمح Aspose.Slides لك بالحصول على شفافية الصورة. يوضح هذا الكود بلغة C++ العملية:

```c++
auto presentation = System::MakeObject<Presentation>(u"Test.pptx");
auto pictureFrame = System::ExplicitCast<IPictureFrame>(presentation->get_Slide(0)->get_Shape(0));
auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<IAlphaModulateFixed>(effect))
    {
        float transparencyValue = 100.0f - (System::ExplicitCast<IAlphaModulateFixed>(effect))->get_Amount();
        System::Console::WriteLine(System::String(u"شفافية الصورة: ") + transparencyValue);
    }
}
```

## **تنسيق إطار الصورة**

توفر Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار الصورة. باستخدام تلك الخيارات، يمكنك تغيير إطار الصورة لجعله يتطابق مع متطلبات معينة.

1. أنشئ مثيل من [فئة Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. احصل على مرجع الشريحة من خلال فهرسها.
3. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) المرتبطة بكائن العرض الذي سيتم استخدامه لملء الشكل.
4. حدد عرض وارتفاع الصورة.
5. أنشئ `PictureFrame` بناءً على عرض وارتفاع الصورة من خلال طريقة [AddPictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) المعروضة بواسطة كائن [IShapes](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) المرتبط بالشريحة المُرجعة.
6. أضف إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.
7. قم بتعيين لون خط إطار الصورة.
8. قم بتعيين عرض خط إطار الصورة.
9. قم بتدوير إطار الصورة عن طريق إعطائه قيمة إيجابية أو سلبية.
   * القيمة الإيجابية تدور الصورة في اتجاه عقارب الساعة.
   * القيمة السلبية تدور الصورة في عكس اتجاه عقارب الساعة.
10. أضف إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.
11. اكتب العرض المعدل كملف PPTX.

يوضح هذا الكود بلغة C++ عملية تنسيق إطار الصورة:

```c++
// المسار إلى دليل المستندات.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// تحميل العرض المطلوب
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// تحميل الصورة التي سيتم إضافتها إلى مجموعة الصور في العرض
// الحصول على الصورة
auto image = Images::FromFile(filePath);

// إضافة صورة إلى مجموعة الصور في العرض
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// إضافة إطار صورة إلى الشريحة
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// تعيين قياس العرض والارتفاع النسبي
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// كتابة ملف PPTX على القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="نصيحة" color="primary" %}}

طورت Aspose مؤخرًا [صانع الكولاج المجاني](https://products.aspose.app/slides/collage). إذا كنت بحاجة إلى [دمج JPG/JPEG](https://products.aspose.app/slides/collage/jpg) أو صور PNG، أو [إنشاء شبكات من الصور](https://products.aspose.app/slides/collage/photo-grid)، يمكنك استخدام هذه الخدمة.

{{% /alert %}}

## **إضافة صورة كارتباط**

لتجنب أحجام العرض الكبيرة، يمكنك إضافة الصور (أو مقاطع الفيديو) من خلال روابط بدلاً من تضمين الملفات مباشرة في العروض. يوضح هذا الكود بلغة C++ كيفية إضافة صورة وفيديو إلى عنصر نائب:

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

## **قص الصورة**

يوضح هذا الكود بلغة C++ كيفية قص صورة موجودة على شريحة:

``` CPP
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// إنشاء كائن صورة جديد
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// إضافة إطار صورة إلى الشريحة
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// قص الصورة (قيم النسبة المئوية)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// حفظ النتيجة
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **حذف المناطق المقصوصة من الصورة**

إذا كنت ترغب في حذف المناطق المقصوصة من صورة موجودة في إطار، يمكنك استخدام طريقة [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). تقوم هذه الطريقة بإرجاع الصورة المقصوصة أو الصورة الأصلية إذا كان القص غير ضروري.

يوضح هذا الكود بلغة C++ العملية:

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// الحصول على إطار الصورة من الشريحة الأولى
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// حذف المناطق المقصوصة من صورة إطار الصورة وإرجاع الصورة المقصوصة
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// حفظ النتيجة
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="ملاحظة" color="warning" %}} 

تضيف طريقة [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) الصورة المقصوصة إلى مجموعة صور العرض. إذا كانت الصورة مستخدمة فقط في [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) المعالجة، فإن هذا الإعداد يمكن أن يقلل من حجم العرض. خلاف ذلك، سيزداد عدد الصور في العرض الناتج.

تحول هذه الطريقة ملفات WMF/EMF المتجهة إلى صورة PNG نقطية أثناء عملية القص.

{{% /alert %}}

## **قفل نسبة الأبعاد**

إذا كنت ترغب في الحفاظ على الشكل الذي يحتوي على صورة على نسبة أبعاده حتى بعد تغيير أبعاد الصورة، يمكنك استخدام طريقة [set_AspectRatioLocked()](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) لتعيين إعداد *قفل نسبة الأبعاد*.

يوضح هذا الكود بلغة C++ كيفية قفل نسبة أبعاد الشكل:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// جعل الشكل يحتفظ بنسبة الأبعاد عند تغيير الحجم
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="ملاحظة" color="warning" %}} 

يحافظ إعداد *قفل نسبة الأبعاد* فقط على نسبة الأبعاد للشكل وليس الصورة التي يحتوي عليها.

{{% /alert %}}

## **استخدام خاصية StretchOff**

باستخدام خصائص [StretchOffsetLeft](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471)، [StretchOffsetTop](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a)، [StretchOffsetRight](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) و[StretchOffsetBottom](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_fill_format) وفئة [PictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format)، يمكنك تحديد مستطيل التعبئة.

عند تحديد تمدد للصورة، يتم تعديل مستطيل المصدر ليتناسب مع مستطيل التعبئة المحدد. يتم تعريف كل حافة من مستطيل التعبئة بواسطة نسبة مئوية من الحافة المقابلة لصندوق الحدود الخاص بالشكل. تحدد النسبة المئوية الإيجابية إدخال. تحدد النسبة المئوية السلبية إدخال للخارج.

1. أنشئ مثيل من [فئة Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. احصل على مرجع الشريحة من خلال فهرسها.
3. أضف شكل مستطيل. 
4. أنشئ صورة.
5. حدد نوع تعبئة الشكل.
6. حدد وضع تعبئة الصورة للشكل.
7. أضف صورة محددة لملء الشكل.
8. حدد إزاحات الصورة من الحافة المقابلة لصندوق الحدود الخاص بالشكل.
9. اكتب العرض المعدل كملف PPTX.

يوضح هذا الكود بلغة C++ عملية يتم فيها استخدام خاصية StretchOff:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// تعيين الصورة لتتمدد من كل جانب داخل جسم الشكل
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```