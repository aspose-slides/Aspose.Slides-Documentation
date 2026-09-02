---
title: إدارة كائنات حبر العرض التقديمي في .NET
linktitle: إدارة الحبر
type: docs
weight: 95
url: /ar/net/manage-ink/
keywords:
- حبر
- كائن حبر
- أثر الحبر
- إدارة الحبر
- رسم الحبر
- الرسم
- تصدير الحبر
- عرض الحبر
- إخفاء الحبر
- IInkOptions
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدارة كائنات حبر PowerPoint، تعديل الآثار وخصائص الفرشاة، والتحكم في مظهر الحبر أثناء تصدير PDF وHTML وSVG وTIFF والصور باستخدام Aspose.Slides لـ .NET."
---
## **المقدمة**

يقدّم PowerPoint ميزة الحبر التي تتيح لك رسم خطوط حرة. يمكن استخدام الحبر لتسليط الضوء على الكائنات الأخرى، وإظهار الاتصالات والعمليات، وجذب الانتباه إلى عناصر محددة في الشريحة.

تحتوي مساحة الأسماء [Aspose.Slides.Ink](https://reference.aspose.com/slides/ar/net/aspose.slides.ink/) على الفئات والواجهات اللازمة للعمل مع كائنات الحبر. على سبيل المثال، تمثل الواجهة [IInk](https://reference.aspose.com/slides/ar/net/aspose.slides.ink/iink/) كائن حبر في الشريحة.

## **الفرق بين الكائنات العادية وكائنات الحبر**

عادةً ما تُمثَّل الكائنات في شريحة PowerPoint بكائنات الشكل. في أبسط أشكالها، يُعد الشكل حاوية تُعرّف مساحة الكائن نفسه (الإطار) إلى جانب خصائص مثل حجم الحاوية، الشكل، والخلفية. لمزيد من المعلومات، راجع [Shape Layout Format](https://docs.aspose.com/slides/ar/net/shape-manipulations/#access-layout-formats-for-shape).

ومع ذلك، عند معالجة PowerPoint لكائن حبر، يتم تجاهل جميع خصائص إطار الكائن (الحاوية) باستثناء حجمه. يتم تحديد حجم مساحة الحاوية بواسطة خصائص [IShape.Width](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/width/) و[IShape.Height](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/height/) القياسية:

![ink_powerpoint1](ink_powerpoint1.png)

## **آثار الحبر**

آثار الحبر هي عنصر أساسي يُستخدم لتسجيل مسار القلم أثناء كتابة الحبر الرقمي. يخزن الأثر سلسلة من النقاط المتصلة.

أبسط أشكال الترميز تُحدد إحداثيات X وY لكل نقطة عينة. عندما يتم عرض جميع النقاط المتصلة، ينتج عنها صورة كهذه:

![ink_powerpoint2](ink_powerpoint2.png)

## **خصائص الفرشاة للرسم**

تُستَخدم الفرشاة لرسم الخطوط التي تربط نقاط أثر الحبر. للفرشاة لونها وحجمها الخاصين، يُمثِّلان بخصائص [IInkBrush.Color](https://reference.aspose.com/slides/ar/net/aspose.slides.ink/iinkbrush/color/) و[IInkBrush.Size](https://reference.aspose.com/slides/ar/net/aspose.slides.ink/iinkbrush/size/).

### **تعيين لون فرشاة الحبر**

يوضح هذا الكود C# كيفية تعيين لون فرشاة الحبر:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Color = Color.Red;
```

### **تعيين حجم فرشاة الحبر**

يوضح هذا الكود C# كيفية تعيين حجم فرشاة الحبر:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Size = new SizeF(5f, 10f);
```

عمومًا، لا يتطابق عرض وارتفاع الفرشاة، لذا لا يعرض PowerPoint حجم الفرشاة (القسم المعني من البيانات مُظلّل). عندما يتطابق عرض وارتفاع الفرشاة، يعرض PowerPoint حجمه بهذا الشكل:

![ink_powerpoint3](ink_powerpoint3.png)

لتوضيح ذلك، لنقم بزيادة ارتفاع كائن الحبر ومراجعة الأبعاد الهامة:

![ink_powerpoint4](ink_powerpoint4.png)

لا تحتسب الحاوية (الإطار) حجم الفرش—in؛ فهي تفترض دائمًا أن سمك الخط صفر (انظر الصورة السابقة).

لذلك، لتحديد المنطقة الظاهرة لكائن الحبر بأكمله، يجب أخذ حجم فرشاة آثاره في الاعتبار. هنا، تم تحجيم الكائن المستهدف (أثر النص المكتوب يدويًا) ليتناسب مع حجم الحاوية (الإطار). عندما يتغير حجم الحاوية، يبقى حجم الفرشاة ثابتًا، والعكس صحيح.

![ink_powerpoint5](ink_powerpoint5.png)

يستخدم PowerPoint سلوكًا مشابهًا لكائنات النص:

![ink_powerpoint6](ink_powerpoint6.png)

## **التحكم في مظهر الحبر أثناء التصدير والعرض**

يوفر Aspose.Slides الواجهة [IInkOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/iinkoptions/) للتحكم في كيفية ظهور كائنات الحبر في النتيجة المصدَّرة أو المعروضة. يمكنك استخدام خصائصها لإخفاء الحبر تمامًا أو تغيير طريقة تفسير عمليات قناع فرشاة الحبر.

تتوفر خيارات الحبر عبر خيارات التصدير أو العرض لعدة أنواع من المخرجات:

| الإخراج | خاصية خيارات الحبر |
| --- | --- |
| PDF | [`PdfOptions.InkOptions`](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pdfoptions/inkoptions/) |
| HTML | [`HtmlOptions.InkOptions`](https://reference.aspose.com/slides/ar/net/aspose.slides.export/htmloptions/inkoptions/) |
| SVG | [`SVGOptions.InkOptions`](https://reference.aspose.com/slides/ar/net/aspose.slides.export/svgoptions/inkoptions/) |
| TIFF | [`TiffOptions.InkOptions`](https://reference.aspose.com/slides/ar/net/aspose.slides.export/tiffoptions/inkoptions/) |
| صورة الشريحة | [`RenderingOptions.InkOptions`](https://reference.aspose.com/slides/ar/net/aspose.slides.export/renderingoptions/inkoptions/) |

الاعدادتان المتاحتان عبر هذه الخصائص:

- [`HideInk`](https://reference.aspose.com/slides/ar/net/aspose.slides.export/iinkoptions/hideink/) يحدد ما إذا كانت كائنات الحبر تُضمّن في المخرج. القيمة الافتراضية هي `false`.
- [`InterpretMaskOpAsOpacity`](https://reference.aspose.com/slides/ar/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) يحدد ما إذا كانت عملية القناع تُفسَّر كعتمة عند عرض فرشاة الحبر. القيمة الافتراضية هي `true`؛ قم بتعيينها إلى `false` لاستخدام عملية ROP بدلاً من ذلك.

### **إخفاء كائنات الحبر في مخرج PDF**

بشكل افتراضي، تظل كائنات الحبر مرئية أثناء التصدير. عيّن [IInkOptions.HideInk](https://reference.aspose.com/slides/ar/net/aspose.slides.export/iinkoptions/hideink/) إلى `true` عندما تحتاج إلى مخرج نظيف خالٍ من التعليقات المكتوبة يدويًا أو أي محتوى حبر آخر.

المثال التالي بلغة C# يصدر عرضًا تقديميًا إلى PDF مع إخفاء جميع كائنات الحبر:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var pdfOptions = new PdfOptions();
pdfOptions.InkOptions.HideInk = true;

presentation.Save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
```

### **إخفاء كائنات الحبر عند عرض الشريحة كصورة**

لإخفاء كائنات الحبر عند عرض الشرائح كصور نقطية، قم بتهيئة [RenderingOptions.InkOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/renderingoptions/inkoptions/) ومرّر خيارات العرض إلى طريقة [ISlide.GetImage](https://reference.aspose.com/slides/ar/net/aspose.slides/islide/getimage/).

المثال التالي بلغة C# يعرض الشريحة الأولى كصورة PNG دون كائنات حبر:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var renderingOptions = new RenderingOptions();
renderingOptions.InkOptions.HideInk = true;

using var image = presentation.Slides[0].GetImage(renderingOptions);
image.Save("slide_without_ink.png", ImageFormat.Png);
```

### **التحكم في عرض قناع الحبر**

تتحكم الخاصية [IInkOptions.InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ar/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) في طريقة تفسير عمليات القناع عند عرض فرشاة الحبر. القيمة الافتراضية هي `true`، والتي تستخدم العتمة. عيّن الخاصية إلى `false` لاستخدام عملية ROP بدلاً من ذلك.

المثال التالي بلغة C# يصدر شريحة إلى SVG ويستخدم عرضًا معتمدًا على ROP لعمليات قناع الحبر:

```c#
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var svgOptions = new SVGOptions();
svgOptions.InkOptions.InterpretMaskOpAsOpacity = false;

using var stream = File.Create("slide.svg");
presentation.Slides[0].WriteAsSvg(stream, svgOptions);
```

يمكن تطبيق الإعداد نفسه عبر [TiffOptions.InkOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/tiffoptions/inkoptions/) عند تصدير عرض تقديمي أو عرض شريحة إلى TIFF.

### **اختيار إخفاء أو الحفاظ على الحبر**

استخدم [IInkOptions.HideInk](https://reference.aspose.com/slides/ar/net/aspose.slides.export/iinkoptions/hideink/) مع قيمة `true` عندما يجب أن يكون الملف المصدر نسخة نظيفة من عرض تقديمي مشروح، مثل نسخة نهائية موجهة للتوزيع دون علامات مراجعة.

اترك [IInkOptions.HideInk](https://reference.aspose.com/slides/ar/net/aspose.slides.export/iinkoptions/hideink/) على قيمته الافتراضية `false` عندما تكون تعليقات الحبر جزءًا من المحتوى المقصود، مثل تعليقات المراجعة، الملاحظات المكتوبة يدويًا، التظليل، أو الرسومات التي يجب أن تظل مرئية في النتيجة المصدَّرة. يتيح هذا للتطبيقات إنشاء مخرجات مراجعة ونهائية منفصلة من نفس العرض التقديمي دون تعديل كائنات الحبر الأصلية.

## **الأسئلة المتكررة**

**هل يمكنني تغيير لون أو حجم خط الحبر الموجود؟**

نعم. احصل على الأثر من [IInk.Traces](https://reference.aspose.com/slides/ar/net/aspose.slides.ink/iink/traces/)، ثم غيّر [IInkTrace.Brush](https://reference.aspose.com/slides/ar/net/aspose.slides.ink/iinktrace/brush/). يمكنك تعيين خصائص [IInkBrush.Color](https://reference.aspose.com/slides/ar/net/aspose.slides.ink/iinkbrush/color/) و[IInkBrush.Size](https://reference.aspose.com/slides/ar/net/aspose.slides.ink/iinkbrush/size/).

**هل تغيير إخفاء الحبر يؤثر على العرض التقديمي الأصلي؟**

لا. يؤثر [IInkOptions.HideInk](https://reference.aspose.com/slides/ar/net/aspose.slides.export/iinkoptions/hideink/) فقط على النتيجة المعروضة أو المصدَّرة؛ ولا يزيل أو يغيّر كائنات الحبر في العرض التقديمي الأصلي.

**ما صيغ التصدير التي تدعم خيارات الحبر؟**

يمكنك تكوين خيارات الحبر للـ PDF، HTML، SVG، TIFF، وصور الشرائح النقطية عبر خيارات التصدير أو العرض المذكورة أعلاه.

**مزيد من القراءة**

* لقراءة حول الأشكال بشكل عام، راجع قسم [PowerPoint Shapes](https://docs.aspose.com/slides/ar/net/powerpoint-shapes/).
* لمزيد من المعلومات حول القيم الفعّالة، انظر [Shape Effective Properties](https://docs.aspose.com/slides/ar/net/shape-effective-properties/#get-effective-font-height-value).
* لتفاصيل تصدير PDF، راجع [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/ar/net/convert-powerpoint-to-pdf/).
* لتفاصيل تصدير HTML، راجع [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/ar/net/convert-powerpoint-to-html/).
* لتفاصيل تصدير SVG، راجع [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/ar/net/render-a-slide-as-an-svg-image/).
* لتفاصيل تصدير TIFF، راجع [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/ar/net/convert-powerpoint-to-tiff/).
* لتفاصيل عرض الشرائح كصور، راجع [Convert Presentation Slides to Images](https://docs.aspose.com/slides/ar/net/convert-slide/).