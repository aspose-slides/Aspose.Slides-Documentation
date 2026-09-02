---
title: تحويل شرائح العروض التقديمية إلى صور في C++
linktitle: الشريحة إلى صورة
type: docs
weight: 41
url: /ar/cpp/convert-slide/
keywords:
- تحويل الشريحة
- تصدير الشريحة
- الشريحة إلى صورة
- حفظ الشريحة كصورة
- الشريحة إلى PNG
- الشريحة إلى JPEG
- الشريحة إلى bitmap
- الشريحة إلى TIFF
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تحويل الشرائح من PPT و PPTX و ODP إلى صور في C++ باستخدام Aspose.Slides—سرعة، جودة عالية في العرض مع أمثلة شفرة واضحة."
---
## **المقدمة**

تمكنك Aspose.Slides for C++ من تحويل شرائح العروض التقديمية PowerPoint و OpenDocument بسهولة إلى صيغ صور مختلفة، بما في ذلك BMP و PNG و JPG (JPEG) و GIF وغيرها.

لتحويل شريحة إلى صورة، اتبع الخطوات التالية:

1. حدد إعدادات التحويل المطلوبة واختر الشرائح التي تريد تصديرها باستخدام:
    - واجهة [ITiffOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/itiffoptions/) ، أو
    - واجهة [IRenderingOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/irenderingoptions/) .
2. أنشئ صورة الشريحة عن طريق استدعاء طريقة [GetImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islide/getimage/) .

‏[Bitmap](https://reference.aspose.com/slides/ar/cpp/system.drawing/bitmap/) هو كائن يتيح لك العمل مع الصور المعرفة ببيانات البكسل. يمكنك استخدام نسخة من هذه الفئة لحفظ الصور بمجموعة واسعة من الصيغ (BMP، JPG، PNG، إلخ).

## **تحويل الشرائح إلى صور نقطية وحفظ الصور بصيغة PNG**

يمكنك تحويل شريحة إلى كائن bitmap واستخدامه مباشرةً في تطبيقك. بدلاً من ذلك، يمكنك تحويل الشريحة إلى bitmap ثم حفظ الصورة بصيغة JPEG أو أي صيغة مفضلة أخرى.

يعرض هذا الكود C++ كيفية تحويل الشريحة الأولى من العرض التقديمي إلى كائن bitmap ثم حفظ الصورة بصيغة PNG:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Convert the first slide in the presentation to a bitmap.
auto image = presentation->get_Slide(0)->GetImage();

// Save the image in the PNG format.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **تحويل الشرائح إلى صور بأحجام مخصصة**

قد تحتاج إلى الحصول على صورة بحجم معين. باستخدام أحد إصدارات طريقة [GetImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islide/getimage/)، يمكنك تحويل شريحة إلى صورة بأبعاد محددة (العرض والارتفاع). 

يعرض رمز العينة كيف يتم ذلك:

```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// تحويل الشريحة الأولى في العرض التقديمي إلى صورة نقطية بالحجم المحدد.
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// حفظ الصورة بصيغة JPEG.
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **تحويل الشرائح مع الملاحظات والتعليقات إلى صور**

قد تحتوي بعض الشرائح على ملاحظات وتعليقات.

توفر Aspose.Slides واجهتين —[ITiffOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/itiffoptions/) و[IRenderingOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/irenderingoptions/)— تتيح لك التحكم في تقديم شرائح العروض التقديمية كصور. تتضمن كلتا الواجهتين طريقة `set_SlidesLayoutOptions` التي تمكنك من تكوين عرض الملاحظات والتعليقات على الشريحة أثناء تحويلها إلى صورة.

باستخدام الفئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/notescommentslayoutingoptions/)، يمكنك تحديد الوضع المفضل للملاحظات والتعليقات في الصورة الناتجة.

يعرض هذا الكود C++ كيفية تحويل شريحة مع ملاحظات وتعليقات:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// Load a presentation file.
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // تعيين موضع الملاحظات.
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // تعيين موضع التعليقات.
notesCommentsOptions->set_CommentsAreaWidth(500);                          // تعيين عرض منطقة التعليقات.
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // تعيين اللون لمنطقة التعليقات.

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
في أي عملية تحويل شريحة إلى صورة، لا يمكن للطريقة [set_NotesPosition](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) تطبيق `BottomFull` (لتحديد موقع الملاحظات) لأن نص الملاحظة قد يكون كبيرًا جدًا، مما يجعله غير قادر على التناسب مع حجم الصورة المحدد.
{{% /alert %}} 

## **تحويل الشرائح إلى صور باستخدام خيارات TIFF**

توفر واجهة [ITiffOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/itiffoptions/) تحكمًا أكبر في صورة TIFF الناتجة من خلال السماح لك بتحديد معلمات مثل الحجم، الدقة، لوحة الألوان، وغيرها.

يعرض هذا الكود C++ عملية تحويل يتم فيها استخدام خيارات TIFF لإنتاج صورة بالأبيض والأسود بدقة 300 DPI وحجم 2160 × 2800:

```cpp 
// تحميل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// الحصول على الشريحة الأولى من العرض التقديمي.
auto slide = presentation->get_Slide(0);

// تهيئة إعدادات صورة TIFF الناتجة.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // تعيين حجم الصورة.
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // تعيين تنسيق البكسل (أبيض وأسود).
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

Aspose.Slides يتيح لك تحويل جميع الشرائح في عرض تقديمي إلى صور، مما يحول العرض بالكامل إلى سلسلة من الصور.

يعرض رمز العينة كيفية تحويل جميع الشرائح في عرض تقديمي إلى صور في C++:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// عرض العرض التقديمي إلى صور شريحة بشريحة.
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // التحكم في الشرائح المخفية (لا تعرض الشرائح المخفية).
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

## **عرض الرموز التعبيرية الملونة**

{{% alert title="Note" color="warning" %}} 
لعرض الرموز التعبيرية الملونة بشكل صحيح عند تحويل شرائح العرض التقديمي إلى صور، يجب أن تكون خطوط الرموز التعبيرية المستخدمة في العرض مثبتة ومتاحة على النظام الذي يقوم بالتحويل. على سبيل المثال، إذا كان العرض يستخدم **Segoe UI Emoji** وكانت هذه الخط غير موجودة، قد تظهر الرموز التعبيرية بالأبيض والأسود في الصور الناتجة.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل تدعم Aspose.Slides عرض الشرائح مع الرسوم المتحركة؟**

لا، طريقة `GetImage` تحفظ صورة ثابتة فقط للشريحة، دون الرسوم المتحركة.

**هل يمكن تصدير الشرائح المخفية كصور؟**

نعم، يمكن معالجة الشرائح المخفية كما الشرائح العادية. فقط تأكد من تضمينها في حلقة المعالجة.

**هل يمكن حفظ الصور مع الظلال والتأثيرات؟**

نعم، تدعم Aspose.Slides عرض الظلال، والشفافية، وغيرها من التأثيرات الرسومية عند حفظ الشرائح كصور.