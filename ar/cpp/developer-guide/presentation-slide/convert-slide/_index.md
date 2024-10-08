---
title: تحويل الشريحة
type: docs
weight: 41
url: /ar/cpp/convert-slide/
keywords: 
- تحويل الشريحة إلى صورة
- تصدير الشريحة كصورة
- حفظ الشريحة كصورة
- الشريحة إلى صورة
- الشريحة إلى PNG
- الشريحة إلى JPEG
- الشريحة إلى بت ماب
- C++
- Aspose.Slides لـ C++
description: "تحويل شريحة PowerPoint إلى صورة (بت ماب، PNG، أو JPG) في C++"
---

Aspose.Slides لـ C++ يسمح لك بتحويل الشرائح (في العروض التقديمية) إلى صور. هذه هي تنسيقات الصور المدعومة: BMP، PNG، JPG (JPEG)، GIF، وغيرها.

لتحويل شريحة إلى صورة، قم بما يلي:

1. أولاً، قم بتعيين معلمات التحويل وأجسام الشرائح للتحويل باستخدام:
   * واجهة [ITiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_tiff_options) أو
   * واجهة [IRenderingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_rendering_options).

2. ثانيًا، قم بتحويل الشريحة إلى صورة باستخدام طريقة [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) .

## **حول بت ماب وتنسيقات الصور الأخرى**

[بت ماب](https://reference.aspose.com/slides/cpp/class/system.drawing.bitmap) هو كائن يسمح لك بالعمل مع الصور المعرفة بواسطة بيانات البكسل. يمكنك استخدام مثيل من هذه الفئة لحفظ الصور في مجموعة واسعة من التنسيقات (BMP، JPG، PNG، إلخ).

{{% alert title="معلومات" color="info" %}}

طورت Aspose مؤخرًا محولًا عبر الإنترنت [نص إلى GIF](https://products.aspose.app/slides/text-to-gif).

{{% /alert %}}

## **تحويل الشرائح إلى بت ماب وحفظ الصور في PNG**

تظهر لك هذه الشيفرة C++ كيفية تحويل الشريحة الأولى من عرض تقديمي إلى كائن بت ماب ثم كيفية حفظ الصورة بتنسيق PNG:

```cpp
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

// تحويل الشريحة الأولى من العرض التقديمي إلى كائن بت ماب
System::SharedPtr<IImage> image = pres->get_Slide(0)->GetImage();
                 
// حفظ الصورة بتنسيق PNG
image->Save(u"Slide_0.png", ImageFormat::Png);
```

{{% alert title="نصيحة" color="primary" %}}

يمكنك تحويل شريحة إلى كائن بت ماب ثم استخدام الكائن مباشرة في مكان ما. أو يمكنك تحويل شريحة إلى بت ماب ثم حفظ الصورة بتنسيق JPEG أو أي تنسيق آخر تفضله.

{{% /alert %}}  

## **تحويل الشرائح إلى صور بأحجام مخصصة**

قد تحتاج إلى الحصول على صورة بحجم معين. باستخدام تحميل زائد من [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/)، يمكنك تحويل شريحة إلى صورة بأبعاد محددة (طول وعرض).

توضح هذه الشيفرة النموذجية عملية التحويل المقترحة باستخدام طريقة [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) في C++:

```cpp
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");
// تحويل الشريحة الأولى في العرض التقديمي إلى بت ماب بالحجم المحدد
auto image = pres->get_Slide(0)->GetImage(Size(1820, 1040));
// حفظ الصورة بتنسيق JPEG
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);
```

## **تحويل الشرائح التي تحتوي على ملاحظات وتعليقات إلى صور**

تحتوي بعض الشرائح على ملاحظات وتعليقات.

توفر Aspose.Slides واجهتين—[ITiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_tiff_options) و [IRenderingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_rendering_options)—تتيح لك التحكم في عرض الشرائح في الصور. تحتوي كلا الواجهتين على واجهة [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options) التي تتيح لك إضافة ملاحظات وتعليقات على شريحة عند تحويل تلك الشريحة إلى صورة.

{{% alert title="معلومات" color="info" %}} 

مع واجهة [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options)، يمكنك تحديد موقعك المفضل للملاحظات والتعليقات في الصورة الناتجة.

{{% /alert %}} 

تظهر هذه الشيفرة C++ عملية التحويل لشريحة تحتوي على ملاحظات وتعليقات:

```cpp
auto pres = System::MakeObject<Presentation>(u"PresentationNotesComments.pptx");
// إنشاء خيارات العرض
auto options = System::MakeObject<RenderingOptions>();
auto notesCommentsLayouting = options->get_NotesCommentsLayouting();
// تعيين موضع الملاحظات على الصفحة
notesCommentsLayouting->set_NotesPosition(NotesPositions::BottomTruncated);
// تعيين موضع التعليقات على الصفحة 
notesCommentsLayouting->set_CommentsPosition(CommentsPositions::Right);
// تعيين عرض منطقة إخراج التعليقات
notesCommentsLayouting->set_CommentsAreaWidth(500);
// تعيين لون منطقة التعليقات
notesCommentsLayouting->set_CommentsAreaColor(Color::get_AntiqueWhite());

// تحويل الشريحة الأولى من العرض التقديمي إلى كائن بت ماب
auto image = pres->get_Slide(0)->GetImage(options, 2.f, 2.f);

// حفظ الصورة بتنسيق GIF
image->Save(u"Slide_Notes_Comments_0.gif", ImageFormat::Gif);
```

{{% alert title="ملاحظة" color="warning" %}} 

في أي عملية تحويل شريحة إلى صورة، لا يمكنك تمرير القيمة BottomFull (لتحديد موضع الملاحظات) إلى طريقة [set_NotesPositions()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options) لأن نص الملاحظة قد يكون كبيرًا، مما يعني أنه قد لا يتناسب مع حجم الصورة المحدد.

{{% /alert %}} 

## **تحويل الشرائح إلى صور باستخدام ITiffOptions**

توفر واجهة [ITiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_tiff_options) تحكمًا أكبر (من حيث المعلمات) على الصورة الناتجة. باستخدام هذه الواجهة، يمكنك تحديد الحجم، والدقة، ولوحة الألوان، وغيرها من المعلمات للصورة الناتجة.

تظهر هذه الشيفرة C++ عملية التحويل حيث يتم استخدام ITiffOptions لإخراج صورة بالأبيض والأسود بدقة 300dpi وحجم 2160 × 2800:

```cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"PresentationNotesComments.pptx");

// الحصول على شريحة بواسطة فهرسها
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// إنشاء كائن TiffOptions
System::SharedPtr<TiffOptions> options = System::MakeObject<TiffOptions>();
options->set_ImageSize(Size(2160, 2880));

// تعيين الخط المستخدم في حالة عدم العثور على الخط المصدر
options->set_DefaultRegularFont(u"Arial Black");

// تعيين موضع الملاحظات على الصفحة 
options->get_NotesCommentsLayouting()->set_NotesPosition(NotesPositions::BottomTruncated);

// تعيين تنسيق البكسل (أبيض وأسود)
options->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);

// تعيين الدقة
options->set_DpiX(300);
options->set_DpiY(300);

// تحويل الشريحة إلى كائن بت ماب
System::SharedPtr<Bitmap> image = slide->GetImage(options);

// حفظ الصورة بتنسيق BMP
image->Save(u"PresentationNotesComments.bmp", ImageFormat::Tiff);
```

## **تحويل جميع الشرائح إلى صور**

يسمح لك Aspose.Slides بتحويل جميع الشرائح في عرض تقديمي واحد إلى صور. في الأساس، يمكنك تحويل العرض التقديمي (بكامل محتواه) إلى صور.

تظهر هذه الشيفرة النموذجية كيفية تحويل جميع الشرائح في عرض تقديمي إلى صور في C++:

```cpp
// مسار دليل الإخراج
System::String outputDir = u"D:\\PresentationImages";

auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

// عرض العرض التقديمي إلى مصفوفة صور شريحة تلو الأخرى
for (int32_t i = 0; i < pres->get_Slides()->get_Count(); i++)
{
    // التحكم في الشرائح المخفية (عدم عرض الشرائح المخفية)
    if (pres->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // تحويل الشريحة إلى كائن بت ماب
    auto image = pres->get_Slide(i)->GetImage(2.f, 2.f);

    // إنشاء اسم الملف لصورة
    auto outputFilePath = Path::Combine(outputDir, String(u"Slide_") + i + u".jpg");

    // حفظ الصورة بتنسيق PNG
    image->Save(outputFilePath, ImageFormat::Png);
}
```