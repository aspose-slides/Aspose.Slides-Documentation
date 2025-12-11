---
title: تحويل شرائح العرض التقديمي إلى صور في C++
linktitle: شريحة إلى صورة
type: docs
weight: 41
url: /ar/cpp/convert-slide/
keywords:
- تحويل الشريحة
- تصدير الشريحة
- شريحة إلى صورة
- حفظ الشريحة كصورة
- شريحة إلى PNG
- شريحة إلى JPEG
- شريحة إلى bitmap
- شريحة إلى TIFF
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تحويل الشرائح من PPT و PPTX و ODP إلى صور في C++ باستخدام Aspose.Slides - سريع، عرض عالي الجودة مع أمثلة شفرة واضحة."
---

## **نظرة عامة**

Aspose.Slides for C++ يتيح لك تحويل شرائح PowerPoint وOpenDocument إلى صيغ صور مختلفة، بما في ذلك BMP وPNG وJPG (JPEG) وGIF وغيرها.

لتحويل شريحة إلى صورة، اتبع الخطوات التالية:

1. عرّف إعدادات التحويل المطلوبة وحدد الشرائح التي تريد تصديرها باستخدام:
    - واجهة [ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/) ، أو
    - واجهة [IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/) .
2. أنشئ صورة الشريحة باستدعاء طريقة [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) .

الـ[Bitmap](https://reference.aspose.com/slides/cpp/system.drawing/bitmap/) هو كائن يتيح لك العمل مع الصور المعرفة ببيانات البكسل. يمكنك استخدام نسخة من هذا الصنف لحفظ الصور بمجموعة واسعة من الصيغ (BMP وJPG وPNG وغيرها).

## **تحويل الشرائح إلى Bitmaps وحفظ الصور بصيغة PNG**

يمكنك تحويل شريحة إلى كائن bitmap واستخدامه مباشرة في تطبيقك. بدلاً من ذلك، يمكنك تحويل الشريحة إلى bitmap ثم حفظ الصورة بصيغة JPEG أو أي صيغة مفضلة أخرى.

يعرض هذا الكود C++ كيفية تحويل الشريحة الأولى في عرض تقديمي إلى كائن bitmap ثم حفظ الصورة بصيغة PNG:
```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// تحويل الشريحة الأولى في العرض التقديمي إلى كائن bitmap.
auto image = presentation->get_Slide(0)->GetImage();

// حفظ الصورة بصيغة PNG.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```


## **تحويل الشرائح إلى صور بأحجام مخصصة**

قد تحتاج إلى الحصول على صورة بحجم معين. باستخدام أحد النسخ المت overloaded من طريقة [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/)، يمكنك تحويل شريحة إلى صورة بأبعاد محددة (العرض والارتفاع).

يعرض هذا المثال كيفية القيام بذلك:
```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// تحويل الشريحة الأولى في العرض التقديمي إلى كائن bitmap بالحجم المحدد.
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// حفظ الصورة بصيغة JPEG.
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```


## **تحويل الشرائح مع الملاحظات والتعليقات إلى صور**

بعض الشرائح قد تحتوي على ملاحظات وتعليقات.

يوفر Aspose.Slides واجهتين—[ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/) و[IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/)—تسمحان لك بالتحكم في رسم شرائح العرض إلى صور. كلتا الواجهتين تشمل طريقة `set_SlidesLayoutOptions`، التي تمكنك من تكوين رسم الملاحظات والتعليقات على الشريحة عند تحويلها إلى صورة.

باستخدام صنف [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/)، يمكنك تحديد الموضع المفضل للملاحظات والتعليقات في الصورة الناتجة.

يعرض هذا الكود C++ كيفية تحويل شريحة تحتوي على ملاحظات وتعليقات:
```cpp 
float scaleX = 2;
float scaleY = scaleX;

// Load a presentation file.
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // تعيين موضع الملاحظات.
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // تعيين موضع التعليقات.
notesCommentsOptions->set_CommentsAreaWidth(500);                          // تعيين عرض مساحة التعليقات.
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // تعيين لون مساحة التعليقات.

// Create the rendering options.
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// Convert the first slide of the presentation to an image.
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// Save the image in the GIF format.
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```


{{% alert title="Note" color="warning" %}} 

في أي عملية تحويل شريحة إلى صورة، لا يمكن لطريقة [set_NotesPosition](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) تطبيق `BottomFull` (لتحديد موضع الملاحظات) لأن نص الملاحظة قد يكون كبيرًا جدًا بحيث لا يتسع داخل حجم الصورة المحدد.

{{% /alert %}} 

## **تحويل الشرائح إلى صور باستخدام خيارات TIFF**

توفر واجهة [ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/) تحكمًا أكبر في صورة TIFF الناتجة من خلال السماح لك بتحديد معلمات مثل الحجم، الدقة، لوحة الألوان، وأكثر.

يعرض هذا الكود C++ عملية تحويل حيث تُستخدم خيارات TIFF لإنتاج صورة أبيض-أسود بدقة 300 DPI وحجم 2160 × 2800:
```cpp 
// تحميل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// الحصول على الشريحة الأولى من العرض التقديمي.
auto slide = presentation->get_Slide(0);

// تكوين إعدادات صورة TIFF الناتجة.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // تعيين حجم الصورة.
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // تعيين تنسيق البكسل (أسود وأبيض).
tiffOptions->set_DpiX(300);                                         // تعيين الدقة الأفقية.
tiffOptions->set_DpiY(300);                                         // تعيين الدقة العمودية.

// تحويل الشريحة إلى صورة باستخدام الخيارات المحددة.
auto image = slide->GetImage(tiffOptions);

// حفظ الصورة بصيغة TIFF.
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```


## **تحويل جميع الشرائح إلى صور**

يتيح Aspose.Slides لك تحويل جميع الشرائح في عرض تقديمي إلى صور، مما يحول العرض بالكامل إلى سلسلة من الصور.

يعرض هذا المثال كيفية تحويل جميع الشرائح في عرض تقديمي إلى صور باستخدام C++:
```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// تحويل العرض التقديمي إلى صور شريحة بشريحة.
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // التحكم في الشرائح المخفية (عدم عرض الشرائح المخفية).
    if (presentation->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // تحويل الشريحة إلى صورة.
    auto image = presentation->get_Slide(i)->GetImage(scaleX, scaleY);

    // حفظ الصورة بصيغة JPEG.
    image->Save(String::Format(u"Slide_{0}.jpg", i), ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```


## **الأسئلة الشائعة**

**هل يدعم Aspose.Slides رسم الشرائح مع الرسوم المتحركة؟**

لا، طريقة `GetImage` تحفظ فقط صورة ثابتة للشريحة، بدون رسوم متحركة.

**هل يمكن تصدير الشرائح المخفية كصور؟**

نعم، يمكن معالجة الشرائح المخفية كما تُعامل الشرائح العادية. فقط تأكد من تضمينها في حلقة المعالجة.

**هل يمكن حفظ الصور بظلال وتأثيرات؟**

نعم، يدعم Aspose.Slides رسم الظلال والشفافية وغيرها من التأثيرات الرسومية عند حفظ الشرائح كصور.