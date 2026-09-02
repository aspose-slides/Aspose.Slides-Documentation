---
title: إدارة كائنات حبر العرض التقديمي في C++
linktitle: إدارة الحبر
type: docs
weight: 95
url: /ar/cpp/manage-ink/
keywords:
- حبر
- كائن حبر
- أثر حبر
- إدارة الحبر
- رسم الحبر
- رسم
- تصدير الحبر
- عرض الحبر
- إخفاء الحبر
- IInkOptions
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "إدارة كائنات حبر PowerPoint، تعديل الآثار وخصائص الفرشاة، والتحكم في مظهر الحبر أثناء تصدير PDF وHTML وSVG وTIFF والصور باستخدام Aspose.Slides للـ C++."
---
## **المقدمة**

يقدم PowerPoint ميزة الحبر التي تتيح لك رسم خطوط حرة. يمكن استخدام الحبر لتسليط الضوء على كائنات أخرى، وإظهار الاتصالات والعمليات، وجذب الانتباه إلى عناصر معينة في الشريحة.

تحتوي مساحة الأسماء [Aspose.Slides.Ink](https://reference.aspose.com/slides/ar/cpp/aspose.slides.ink/) على الفئات والواجهات اللازمة للعمل مع كائنات الحبر. على سبيل المثال، تمثل الواجهة [IInk](https://reference.aspose.com/slides/ar/cpp/aspose.slides.ink/iink/) كائن حبر على الشريحة.

## **الاختلافات بين الكائنات العادية وكائنات الحبر**

عادةً ما يتم تمثيل الكائنات في شريحة PowerPoint بواسطة كائنات الشكل. في أبسط صورها، الشكل هو حاوية تعرف مساحة الكائن نفسه (إطارها) بالإضافة إلى خصائص مثل حجم الحاوية وشكلها والخلفية. لمزيد من المعلومات، راجع [Shape Layout Format](https://docs.aspose.com/slides/ar/cpp/shape-manipulations/#access-layout-formats-for-shape).

ومع ذلك، عند معالجة PowerPoint لكائن حبر، يتجاهل جميع خصائص إطار الكائن (الحاوية) باستثناء حجمه. يتم تحديد حجم منطقة الحاوية بواسطة طريقتي [IShape::get_Width](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_width/) و[IShape::get_Height](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_height/):

![ink_powerpoint1](ink_powerpoint1.png)

## **آثار الحبر**

آثار الحبر هي عنصر أساسي يُستخدم لتسجيل مسار القلم أثناء كتابة الحبر الرقمي. يُخزن الأثر تسلسلًا من النقاط المتصلة.

أبسط شكل من أشكال الترميز يُحدد إحداثيات X وY لكل نقطة عينة. عند عرض جميع النقاط المتصلة، ينتج عنها صورة مثل هذه:

![ink_powerpoint2](ink_powerpoint2.png)

## **خصائص الفرشاة للرسم**

تُستخدم الفرشاة لرسم الخطوط التي تربط نقاط أثر الحبر. للفرشاة لونها وحجمها الخاصين، يُمثلها الطريقتان [IInkBrush::get_Color](https://reference.aspose.com/slides/ar/cpp/aspose.slides.ink/iinkbrush/get_color/) و[IInkBrush::get_Size](https://reference.aspose.com/slides/ar/cpp/aspose.slides.ink/iinkbrush/get_size/).

### **تعيين لون فرشاة الحبر**

هذا الكود C++ يوضح كيفية تعيين لون فرشاة الحبر:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Color(System::Drawing::Color::get_Red());

presentation->Dispose();
```

### **تعيين حجم فرشاة الحبر**

هذا الكود C++ يوضح كيفية تعيين حجم فرشاة الحبر:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));

presentation->Dispose();
```

عادةً لا يتطابق عرض وارتفاع الفرشاة، لذا لا يعرض PowerPoint حجم الفرشاة (قسم البيانات المقابل يصبح رماديًا). عندما يتطابق عرض وارتفاع الفرشاة، يعرض PowerPoint حجمه بهذه الطريقة:

![ink_powerpoint3](ink_powerpoint3.png)

لتوضيح الأمر، لنزيد ارتفاع كائن الحبر ونستعرض الأبعاد المهمة:

![ink_powerpoint4](ink_powerpoint4.png)

الحاوية (الإطار) لا تأخذ في الاعتبار حجم الفرشات—دائمًا ما تفترض أن سمك الخط صفر (انظر الصورة السابقة).

لذا، لتحديد المنطقة المرئية لكامل كائن الحبر، يجب أخذ حجم فرشاة آثاره في الاعتبار. هنا، تم تحجيم الكائن الهدف (أثر نص مكتوب يدويًا) ليتناسب مع حجم الحاوية (الإطار). عندما يتغير حجم الحاوية، يبقى حجم الفرشاة ثابتًا، والعكس صحيح.

![ink_powerpoint5](ink_powerpoint5.png)

يستخدم PowerPoint سلوكًا مشابهًا لكائنات النص:

![ink_powerpoint6](ink_powerpoint6.png)

## **التحكم في مظهر الحبر أثناء التصدير والعرض**

توفر Aspose.Slides الواجهة [IInkOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/iinkoptions/) للتحكم في كيفية ظهور كائنات الحبر في المخرجات المصدرة أو المعروضة. يمكنك استخدام طرقها لإخفاء الحبر تمامًا أو لتغيير طريقة تفسير عمليات قناع فرشاة الحبر.

تتوفر خيارات الحبر من خلال خيارات التصدير أو العرض لعدة أنواع من المخرجات:

| الإخراج | طريقة خيارات الحبر |
| --- | --- |
| PDF | [PdfOptions::get_InkOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/pdfoptions/get_inkoptions/) |
| HTML | [HtmlOptions::get_InkOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/htmloptions/get_inkoptions/) |
| SVG | [SVGOptions::get_InkOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/svgoptions/get_inkoptions/) |
| TIFF | [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) |
| صورة الشريحة | [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) |

الضبطان المتاحان من خلال هذه الطرق هما:

- [IInkOptions::set_HideInk](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/iinkoptions/set_hideink/) يحدد ما إذا كانت كائنات الحبر تُضمّن في المخرج. القيمة الافتراضية هي `false`.
- [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) يحدد ما إذا كانت عملية القناع تُفسَّر كعتامة عند عرض فرشاة الحبر. القيمة الافتراضية هي `true`؛ عيّنها إلى `false` لاستخدام عملية ROP بدلاً من ذلك.

### **إخفاء كائنات الحبر في مخرجات PDF**

بشكل افتراضي، تظل كائنات الحبر مرئية أثناء التصدير. استدعِ [IInkOptions::set_HideInk](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/iinkoptions/set_hideink/) مع `true` عندما تحتاج إلى مخرج نظيف بدون تعليقات مكتوبة يدويًا أو محتوى حبر آخر.

المثال التالي بلغة C++ يصدر عرض تقديمي إلى PDF مع إخفاء جميع كائنات الحبر:

```cpp
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::PdfOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->get_InkOptions()->set_HideInk(true);

presentation->Save(u"presentation_without_ink.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **إخفاء كائنات الحبر عند عرض شريحة كصورة**

لإخفاء كائنات الحبر عند عرض الشرائح كصور نقطية، قم بتكوين [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) ومرّر خيارات العرض إلى طريقة [ISlide::GetImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islide/getimage/).

المثال التالي بلغة C++ يعرض الشريحة الأولى كصورة PNG بدون كائنات حبر:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::ImageFormat;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::RenderingOptions;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->get_InkOptions()->set_HideInk(true);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions);
image->Save(u"slide_without_ink.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

### **التحكم في عرض قناع الحبر**

طريقة [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) تتحكم في طريقة تفسير عمليات القناع عند عرض فرشات الحبر. القيمة الافتراضية هي `true`، أي استخدام العتامة. استدعِ الطريقة مع `false` لاستخدام عملية ROP بدلاً من ذلك.

المثال التالي بلغة C++ يصدر شريحة إلى SVG ويستخدم عرضًا قائمًا على ROP لعمليات قناع الحبر:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SVGOptions;
using System::MakeObject;
using System::IO::File;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->get_InkOptions()->set_InterpretMaskOpAsOpacity(false);

auto stream = File::Create(u"slide.svg");
presentation->get_Slide(0)->WriteAsSvg(stream, svgOptions);

stream->Dispose();
presentation->Dispose();
```

يمكن تطبيق نفس الإعداد عبر [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) عند تصدير عرض تقديمي أو عرض شريحة إلى TIFF.

### **اختيار إما إخفاء الحبر أو الحفاظ عليه**

استخدم [IInkOptions::set_HideInk](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/iinkoptions/set_hideink/) مع `true` عندما ينبغي أن يكون الملف المصدر نسخة نظيفة من عرض تقديمي مشروح، على سبيل المثال نسخة نهائية موجهة للتوزيع بدون علامات مراجعة.

اترك الحبر مرئيًا (الإعداد الافتراضي `false`) عندما تكون تعليقات الحبر جزءًا من المحتوى المقصود، مثل ملاحظات المراجعة، الملاحظات المكتوبة يدويًا، التمييز، أو الرسومات التي يجب أن تبقى مرئية في النتيجة المصدرة. يتيح ذلك للتطبيقات إنشاء مخرجات مراجعة ونهائية منفصلة من نفس العرض دون تعديل كائنات الحبر الأصلية.

## **الأسئلة المتكررة**

**هل يمكنني تغيير لون أو حجم ضربة حبر موجودة؟**

نعم. احصل على الأثر من [IInk::get_Traces](https://reference.aspose.com/slides/ar/cpp/aspose.slides.ink/iink/get_traces/)، ثم غير [IInkTrace::get_Brush](https://reference.aspose.com/slides/ar/cpp/aspose.slides.ink/iinktrace/get_brush/). يمكنك استدعاء [IInkBrush::set_Color](https://reference.aspose.com/slides/ar/cpp/aspose.slides.ink/iinkbrush/set_color/) و[IInkBrush::set_Size](https://reference.aspose.com/slides/ar/cpp/aspose.slides.ink/iinkbrush/set_size/) على الفرشاة.

**هل يؤدي إخفاء الحبر إلى تعديل العرض التقديمي الأصلي؟**

لا. [IInkOptions::set_HideInk](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/iinkoptions/set_hideink/) يؤثر فقط على النتيجة المعروضة أو المصدرة؛ ولا يزيل أو يعديل كائنات الحبر في العرض التقديمي الأصلي.

**ما هي صيغ التصدير التي تدعم خيارات الحبر؟**

يمكنك تكوين خيارات الحبر للـ PDF وHTML وSVG وTIFF وصور الشرائح النقطية من خلال خيارات التصدير أو العرض المقابلة المذكورة أعلاه.

**قراءة إضافية**

* لقراءة عن الأشكال بشكل عام،参见 [PowerPoint Shapes](https://docs.aspose.com/slides/ar/cpp/powerpoint-shapes/) .
* لمزيد من المعلومات حول القيم الفعّالة،参见 [Shape Effective Properties](https://docs.aspose.com/slides/ar/cpp/shape-effective-properties/#get-effective-font-height-value) .
* لتفاصيل تصدير PDF،参见 [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/ar/cpp/convert-powerpoint-to-pdf/) .
* لتفاصيل تصدير HTML،参见 [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/ar/cpp/convert-powerpoint-to-html/) .
* لتفاصيل تصدير SVG،参见 [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/ar/cpp/render-a-slide-as-an-svg-image/) .
* لتفاصيل تصدير TIFF،参见 [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/ar/cpp/convert-powerpoint-to-tiff/) .
* لتفاصيل عرض الشرائح كصور،参见 [Convert Presentation Slides to Images](https://docs.aspose.com/slides/ar/cpp/convert-slide/) .