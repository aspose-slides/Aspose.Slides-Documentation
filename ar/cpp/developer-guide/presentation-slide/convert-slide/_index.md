---
title: تحويل شرائح العرض إلى صور في C++
linktitle: شريحة إلى صورة
type: docs
weight: 41
url: /ar/cpp/convert-slide/
keywords:
- تحويل الشريحة
- تصدير الشريحة
- شريحة إلى صورة
- حفظ الشريحة كصورة
- شريحة إلى EMF
- شريحة إلى PNG
- شريحة إلى JPEG
- شريحة إلى bitmap
- شريحة إلى TIFF
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تحويل الشرائح من عروض PPT و PPTX و ODP إلى PNG و JPEG و GIF و TIFF و EMF وغيرها من تنسيقات الصور في C++ باستخدام Aspose.Slides for C++."
---
## **المقدمة**

يمكن لـ Aspose.Slides for C++ عرض الشرائح الفردية من عروض PowerPoint و OpenDocument كملفات PNG و JPEG و GIF و TIFF وغيرها من تنسيقات الصور.

لتحويل شريحة إلى صورة، اتبع الخطوات التالية:

1. حمّل العرض باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
2. حدّد الشريحة التي تريد عرضها.
3. إذا لزم الأمر، قم بتكوين العرض باستخدام الفئة [RenderingOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/renderingoptions/) أو الفئة [TiffOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/tiffoptions/).
4. استدعِ الطريقة [ISlide::GetImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islide/getimage/). تُعيد كائن [IImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/).
5. استدعِ الطريقة [IImage::Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/save/) وحدد تنسيق الإخراج باستخدام قيمة [ImageFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imageformat/).

## **تحويل شريحة إلى صورة PNG**

أبسط عملية تحويل تستخدم إعدادات العرض الافتراضية. يمكن معالجة كائن [IImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/) الناتج في الذاكرة أو حفظه إلى ملف.

المثال التالي بلغة C++ يعرض الشريحة الأولى ويحفظها كصورة PNG:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage();
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **تحويل الشرائح إلى صور بأحجام مخصصة**

استخدم النسخة الزائدة من [ISlide::GetImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islide/getimage/) التي تقبل قيمة [Size](https://reference.aspose.com/slides/ar/cpp/system.drawing/size/) لعرض شريحة بأبعاد بكسل دقيقة.

المثال التالي ينشئ صورة JPEG بحجم 1820 × 1040:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(imageSize);
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **تحويل الشرائح مع الملاحظات والتعليقات إلى صور**

افتراضيًا، لا تتضمن صور الشرائح الملاحظات أو التعليقات. عيّن كائن [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/notescommentslayoutingoptions/) إلى الطريقة [RenderingOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/renderingoptions/set_slideslayoutoptions/) للتحكم في مكان ظهور الملاحظات والتعليقات.

المثال التالي يضع الملاحظات المقتطعة أسفل الشريحة والتعليقات إلى يمينها:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto layoutOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomTruncated);
layoutOptions->set_CommentsPosition(CommentsPositions::Right);
layoutOptions->set_CommentsAreaWidth(500);
layoutOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutOptions);

auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(renderingOptions, scaleX, scaleY);
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Warning" color="warning" %}}
في تحويل الشرائح إلى صور، لا تقم بتعيين الطريقة [NotesCommentsLayoutingOptions::set_NotesPosition](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) إلى القيمة [BottomFull](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/notespositions/). قد تحتوي الملاحظات على نص أكبر مما يمكن أن تستوعبه حجم الصورة الثابت. استخدم [BottomTruncated](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/notespositions/) بدلاً من ذلك.
{{% /alert %}}

## **تحويل الشرائح إلى صور باستخدام خيارات TIFF**

تتيح لك الفئة [TiffOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/tiffoptions/) التحكم في الحجم والدقة والخصائص الأخرى لصورة TIFF المُعالجة.

المثال التالي يعرض الشريحة الأولى كصورة TIFF بحجم 2160 × 2880 بدقة 300 DPI:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/TiffOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(tiffOptions);
image->Save(u"output.tiff", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **تحويل جميع الشرائح إلى صور**

قم بالتكرار عبر مجموعة الشرائح لتحويل العرض الكامل إلى سلسلة من الصور. تشمل الشرائح المخفية ما لم تقم بتخطيها صراحةً.

المثال التالي يعرض كل شريحة كصورة JPEG بمعاملات تكبير أفقية ورأسية مقدارها 2:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

int32_t slideCount = presentation->get_Slides()->get_Count();
for (int32_t index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"Slide_{0}.jpg", index), ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

## **إنشاء مخرجات Enhanced Metafile**

‏Enhanced Metafile (EMF) مفيد عندما يجب تبادل الرسومات القائمة على المتجهات مع Microsoft Office أو تطبيقات Windows الأخرى التي تدعم ملفات التعريف الوِندوزية. على عكس الصورة القائمة على البكسل، يمكن لـ EMF الاحتفاظ بعمليات الرسم المتجهية التي تُ伸扩 دون فقدان الحدة. ومع ذلك، يُعَد EMF في المقام الأول تنسيق توافق لتطبيقات تدعم ملفات التعريف الوِندوزية، وليس تنسيق تبادل عالمي. بالإضافة إلى ذلك، قد يتم تخزين محتوى شريحة معقد، مثل الصور النقطية وبعض التأثيرات، كعناصر raster داخل حاوية ملف التعريف المتجه.

### **تصدير شريحة إلى EMF**

الطريقة [ISlide::WriteAsEmf](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islide/writeasemf/) تكتب كائن [ISlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islide/) إلى تدفق هدف بتنسيق EMF. المثال التالي يحمل عرضًا، يحدد الشريحة الأولى، ويكتبها إلى تدفق ملف EMF:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto emfStream = File::Create(u"Slide_0.emf");
slide->WriteAsEmf(emfStream);

emfStream->Close();
presentation->Dispose();
```

المستدعي يملك التدفق الممرّر إلى [ISlide::WriteAsEmf](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islide/writeasemf/) ويجب أن يغلقه أو يتخلص منه. تقوم Aspose.Slides بالكتابة في الموضع الحالي للتدفق وتتركه مفتوحًا.

### **تحويل صورة SVG إلى EMF وإضافتها إلى عرض**

استخدم [ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isvgimage/writeasemf/) لتحويل محتوى SVG إلى EMF. يمكن إضافة البايتات الناتجة إلى العرض عبر [IImageCollection::AddImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimagecollection/addimage/) ووضعها على شريحة باستخدام [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/addpictureframe/).

المثال التالي ينشئ [SvgImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/svgimage/) من ترميز SVG، يحوله إلى EMF في الذاكرة، يدرج ملف التعريف على الشريحة الأولى، ويحفظ العرض:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String svgContent = u"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto emfStream = MakeObject<MemoryStream>();
svgImage->WriteAsEmf(emfStream);

auto emfData = emfStream->ToArray();
auto image = presentation->get_Images()->AddImage(emfData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, image);

presentation->Save(u"Presentation_with_emf.pptx", SaveFormat::Pptx);

emfStream->Close();
presentation->Dispose();
```

[ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isvgimage/writeasemf/) لا يملك ملكية تدفق الوجهة. بعد الكتابة، يكون موضع التدفق في نهاية البيانات المُولّدة. يستدعي المثال [MemoryStream::ToArray](https://reference.aspose.com/slides/ar/cpp/system.io/memorystream/toarray/) للحصول على المخزن الكامل بغض النظر عن موضع التدفق الحالي، ثم يمرر ذلك المصفوفة البايتية إلى [IImageCollection::AddImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimagecollection/addimage/). احتفظ بالتدفق مفتوحًا حتى ينتهي المستهلك من قراءته، ثم أغلقه بعد ذلك.

تتوفر إنشاء ملفات EMF على أنظمة التشغيل التي تدعمها Aspose.Slides for C++، لكن عملية العرض قد تختلف بين المنصات عندما تكون الخطوط أو تبعيات الرسوميات الأصلية غير متوفرة. ثبّت الخطوط المستخدمة في المحتوى الأصلي أو قم بتكوين بدائل مناسبة، واتبع [متطلبات النظام](/slides/ar/cpp/system-requirements/) لـ Aspose.Slides for C++، وتحقق من النتيجة في التطبيق المستهدف الذي يتعامل مع EMF. غالبًا ما تكون التطبيقات على Linux وmacOS ذات دعم محدود أو غير متسق لعرض وتحرير ملفات التعريف الوِندوزية.

## **عرض الرموز التعبيرية الملونة**

{{% alert title="ملاحظة" color="info" %}}
لعرض الرموز التعبيرية الملونة بشكل صحيح عند تحويل شرائح العروض إلى صور، يجب تثبيت خطوط الرموز التعبيرية المستخدمة في العرض وتوفرها على النظام الذي يجري التحويل. على سبيل المثال، إذا كان العرض يستخدم **Segoe UI Emoji** وكان هذا الخط غير موجود، قد تظهر الرموز التعبيرية بالأبيض والأسود في الصور الناتجة.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يدعم Aspose.Slides عرض الشرائح مع الرسوم المتحركة؟**

لا. الطريقة [ISlide::GetImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islide/getimage/) تعرض صورة ثابتة للشريحة ولا تصدر الرسوم المتحركة.

**هل يمكن تصدير الشرائح المخفية كصور؟**

نعم. يمكن عرض الشرائح المخفية مثل الشرائح العادية. ضمنها في حلقة المعالجة، كما هو موضح في المثال أعلاه.

**هل يتم الحفاظ على الظلال وغيرها من التأثيرات في صور الشرائح؟**

نعم. يقوم Aspose.Slides بعرض الظلال والشفافية وغيرها من التأثيرات الرسومية المدعومة في صور الشرائح.