---
title: إدارة كائنات الحبر في العروض التقديمية باستخدام Python
linktitle: إدارة الحبر
type: docs
weight: 95
url: /ar/python-net/manage-ink/
keywords:
- حبر
- كائن حبر
- أثر الحبر
- إدارة الحبر
- رسم الحبر
- رسم
- تصدير الحبر
- تصوير الحبر
- إخفاء الحبر
- InkOptions
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إدارة كائنات حبر PowerPoint، تعديل الآثار وخصائص الفرشاة، والتحكم في مظهر الحبر أثناء تصدير PDF وHTML وSVG وTIFF والصور باستخدام Aspose.Slides للغة Python عبر .NET."
---
## **المقدمة**

PowerPoint يوفر ميزة الحبر التي تتيح لك رسم ضربات حرة. يمكن استخدام الحبر لتسليط الضوء على الكائنات الأخرى، وإظهار الاتصالات والعمليات، وجذب الانتباه إلى عناصر محددة على الشريحة.

المساحة الاسمية [aspose.slides.ink](https://reference.aspose.com/slides/ar/python-net/aspose.slides.ink/) تحتوي على الفئات اللازمة للعمل مع كائنات الحبر. على سبيل المثال، الفئة [Ink](https://reference.aspose.com/slides/ar/python-net/aspose.slides.ink/ink/) تمثل كائن حبر على شريحة.

## **الاختلافات بين الكائنات العادية وكائنات الحبر**

الكائنات على شريحة PowerPoint عادة ما تُمثَّل بواسطة كائنات الشكل. في أبسط صورها، الشكل هو حاوية تحدد مساحة الكائن نفسها (إطاره) بالإضافة إلى خصائص مثل حجم الحاوية، الشكل، والخلفية. لمزيد من المعلومات، راجع [Shape Layout Format](https://docs.aspose.com/slides/ar/python-net/shape-manipulations/#access-layout-formats-for-shape).

ومع ذلك، عندما يتعامل PowerPoint مع كائن حبر، يتجاهل جميع خصائص إطار الكائن (الحاوية) باستثناء حجمه. يتم تحديد حجم مساحة الحاوية بواسطة خصائص [Ink.width](https://reference.aspose.com/slides/ar/python-net/aspose.slides.ink/ink/width/) و[Ink.height](https://reference.aspose.com/slides/ar/python-net/aspose.slides.ink/ink/height/) القياسية:

![ink_powerpoint1](ink_powerpoint1.png)

## **آثار الحبر**

آثار الحبر هي عنصر أساسي يُستخدم لتسجيل مسار القلم عندما يكتب المستخدم حبرًا رقميًا. تخزن الآثار سلسلة من النقاط المتصلة.

أبسط شكل للترميز يحدد إحداثيات X وY لكل نقطة عينة. عندما يتم عرض جميع النقاط المتصلة، ينتج عنها صورة مثل هذه:

![ink_powerpoint2](ink_powerpoint2.png)

## **خصائص الفرشاة للرسم**

تُستخدم الفرشاة لرسم الخطوط التي تربط نقاط أثر الحبر. خصائصها [InkBrush.color](https://reference.aspose.com/slides/ar/python-net/aspose.slides.ink/inkbrush/color/) و[InkBrush.size](https://reference.aspose.com/slides/ar/python-net/aspose.slides.ink/inkbrush/size/) تتحكم في اللون والحجم.

### **تعيين لون فرشاة الحبر**

يظهر هذا الكود Python كيفية تعيين لون فرشاة الحبر:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.color = draw.Color.red
```

### **تعيين حجم فرشاة الحبر**

يظهر هذا الكود Python كيفية تعيين حجم فرشاة الحبر:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.size = draw.SizeF(5.0, 10.0)
```

بشكل عام، عرض وارتفاع الفرشاة لا يتطابقان، لذا لا يعرض PowerPoint حجم الفرشاة (قسم البيانات المقابل مظلل بالرمادي). عندما يتطابق عرض وارتفاع الفرشاة، يعرض PowerPoint حجمه بهذه الطريقة:

![ink_powerpoint3](ink_powerpoint3.png)

للتوضيح، لنقم بزيادة ارتفاع كائن الحبر ومراجعة الأبعاد المهمة:

![ink_powerpoint4](ink_powerpoint4.png)

الحاوية (الإطار) لا تأخذ في الاعتبار حجم الفرشات—دائمًا ما تفترض أن سمك الخط صفر (انظر الصورة السابقة).

لذلك، لتحديد المنطقة الظاهرة لكامل كائن الحبر، يجب أخذ حجم فرشاة الآثار في الاعتبار. هنا، تم تحجيم الكائن المستهدف (أثر النص المكتوب يدويًا) إلى حجم الحاوية (الإطار). عند تغير حجم الحاوية، يبقى حجم الفرشاة ثابتًا، والعكس صحيح.

![ink_powerpoint5](ink_powerpoint5.png)

يستخدم PowerPoint سلوكًا مشابهًا لكائنات النص:

![ink_powerpoint6](ink_powerpoint6.png)

## **التحكم في مظهر الحبر أثناء التصدير والتصوير**

توفر Aspose.Slides الفئة [InkOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/inkoptions/) للتحكم في كيفية ظهور كائنات الحبر في المخرجات المصدرة أو المصورة. يمكنك استخدام خصائصها لإخفاء الحبر بالكامل أو لتغيير طريقة تفسير عمليات قناع فرشاة الحبر.

تتوفر خيارات الحبر عبر خيارات التصدير أو التصوير لعدة أنواع من المخرجات:

| المخرج | خاصية خيارات الحبر |
| --- | --- |
| PDF | [`PdfOptions.ink_options`](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/pdfoptions/ink_options/) |
| HTML | [`HtmlOptions.ink_options`](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/htmloptions/ink_options/) |
| SVG | [`SVGOptions.ink_options`](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/svgoptions/ink_options/) |
| TIFF | [`TiffOptions.ink_options`](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/tiffoptions/ink_options/) |
| صورة الشريحة | [`RenderingOptions.ink_options`](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/renderingoptions/ink_options/) |

الإعدادان المتاحان عبر هذه الخصائص هما:

- [`InkOptions.hide_ink`](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/inkoptions/hide_ink/) يحدد ما إذا كانت كائنات الحبر تُدرج في المخرج. القيمة الافتراضية هي `False`.
- [`InkOptions.interpret_mask_op_as_opacity`](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) يحدد ما إذا كانت عملية القناع تُفسَّر كعتامة عند تصوير فرشاة الحبر. القيمة الافتراضية هي `True`؛ عيّنها إلى `False` لاستخدام عملية ROP بدلاً من ذلك.

### **إخفاء كائنات الحبر في مخرج PDF**

بشكل افتراضي، تبقى كائنات الحبر مرئية أثناء التصدير. عيّن [InkOptions.hide_ink](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/inkoptions/hide_ink/) إلى `True` عندما تحتاج إلى مخرج نظيف بدون تعليقات يدوية أو محتوى حبر آخر.

المثال التالي في Python يصدر عرضًا تقديميًا إلى PDF مع إخفاء جميع كائنات الحبر:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    pdf_options = slides.export.PdfOptions()
    pdf_options.ink_options.hide_ink = True

    presentation.save("presentation_without_ink.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **إخفاء كائنات الحبر عند تصوير شريحة كصورة**

لإخفاء كائنات الحبر عند تصوير الشرائح كصور نقطية، اضبط [RenderingOptions.ink_options](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/renderingoptions/ink_options/) ومرّر خيارات التصوير إلى طريقة [Slide.get_image](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/get_image/).

المثال التالي في Python يصور الشريحة الأولى كصورة PNG بدون كائنات حبر:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    rendering_options = slides.export.RenderingOptions()
    rendering_options.ink_options.hide_ink = True

    with presentation.slides[0].get_image(rendering_options) as image:
        image.save("slide_without_ink.png", slides.ImageFormat.PNG)
```

### **التحكم في تصوير قناع الحبر**

خاصية [InkOptions.interpret_mask_op_as_opacity](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) تتحكم في كيفية تفسير عمليات القناع عند تصوير فرشاة الحبر. القيمة الافتراضية هي `True`، والتي تستخدم العتامة. عيّن الخاصية إلى `False` لاستخدام عملية ROP بدلاً من ذلك.

المثال التالي في Python يصدر شريحة إلى SVG ويستخدم تصويرًا قائمًا على ROP لعمليات قناع الحبر:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.ink_options.interpret_mask_op_as_opacity = False

    with open("slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

يمكن تطبيق نفس الإعداد عبر [TiffOptions.ink_options](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/tiffoptions/ink_options/) عند تصدير عرض تقديمي أو تصوير شريحة إلى TIFF.

### **اختر ما إذا كان يجب إخفاء أو الحفاظ على الحبر**

عيّن [InkOptions.hide_ink](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/inkoptions/hide_ink/) إلى `True` عندما يجب أن يكون الملف المُصدَّر نسخة نظيفة من عرض تقديمي مُعلَّق، على سبيل المثال نسخة نهائية موجهة للتوزيع بدون علامات مراجعة.

اترك [InkOptions.hide_ink](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/inkoptions/hide_ink/) على قيمته الافتراضية `False` عندما تكون تعليقات الحبر جزءًا من المحتوى المقصود، مثل تعليقات المراجعة، الملاحظات المكتوبة يدويًا، التظليلات، أو الرسومات التي يجب أن تبقى مرئية في النتيجة المُصدَّرة. يتيح ذلك للتطبيقات إنشاء مخرجات مراجعة ونهائية منفصلة من نفس العرض التقديمي دون تعديل كائنات الحبر المصدرية.

## **الأسئلة المتكررة**

**هل يمكنني تغيير لون أو حجم ضربة حبر موجودة؟**

نعم. احصل على الأثر من [Ink.traces](https://reference.aspose.com/slides/ar/python-net/aspose.slides.ink/ink/traces/)، ثم قم بتغيير [InkTrace.brush](https://reference.aspose.com/slides/ar/python-net/aspose.slides.ink/inktrace/brush/). يمكنك تعيين لون [InkBrush.color](https://reference.aspose.com/slides/ar/python-net/aspose.slides.ink/inkbrush/color/) وحجم [InkBrush.size](https://reference.aspose.com/slides/ar/python-net/aspose.slides.ink/inkbrush/size/) للفرشاة.

**هل يغيّر إخفاء الحبر العرض التقديمي الأصلي؟**

لا. [InkOptions.hide_ink](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/inkoptions/hide_ink/) يؤثر فقط على النتيجة المصوَّرة أو المُصدَّرة؛ ولا يزيل أو يعدل كائنات الحبر في العرض التقديمي الأصلي.

**ما تنسيقات التصدير التي تدعم خيارات الحبر؟**

يمكنك ضبط خيارات الحبر لـ PDF وHTML وSVG وTIFF وصور الشرائح النقطية عبر خيارات التصدير أو التصوير المقابلة الموضحة أعلاه.

**قراءة إضافية**

* لقراءة المزيد عن الأشكال بشكل عام، راجع قسم [PowerPoint Shapes](https://docs.aspose.com/slides/ar/python-net/powerpoint-shapes/).
* لمزيد من المعلومات حول القيم الفعّالة، راجع [Shape Effective Properties](https://docs.aspose.com/slides/ar/python-net/shape-effective-properties/#get-effective-font-height-value).
* لتفاصيل حول تصدير PDF، راجع [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/ar/python-net/convert-powerpoint-to-pdf/).
* لتفاصيل حول تصدير HTML، راجع [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/ar/python-net/convert-powerpoint-to-html/).
* لتفاصيل حول تصدير SVG، راجع [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/ar/python-net/render-a-slide-as-an-svg-image/).
* لتفاصيل حول تصدير TIFF، راجع [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/ar/python-net/convert-powerpoint-to-tiff/).
* لتفاصيل حول تصوير الشريحة إلى صورة، راجع [Convert Presentation Slides to Images](https://docs.aspose.com/slides/ar/python-net/convert-slide/).