---
title: إدارة كائنات الحبر في العرض التقديمي باستخدام Python عبر Java
linktitle: إدارة الحبر
type: docs
weight: 95
url: /ar/python-java/manage-ink/
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
- InkOptions
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: إدارة كائنات الحبر في PowerPoint، تعديل الآثار وخصائص الفرشاة، والتحكم في مظهر الحبر أثناء تصدير PDF وHTML وSVG وTIFF والصور باستخدام Aspose.Slides لـ Python عبر Java.
---
## **المقدمة**

يقدم PowerPoint ميزة الحبر التي تتيح لك رسم ضربات حرة. يمكن استخدام الحبر لتسليط الضوء على كائنات أخرى، وإظهار الاتصالات والعمليات، وجذب الانتباه إلى عناصر محددة على الشريحة.

توفر Aspose.Slides الأنواع اللازمة للعمل مع كائنات الحبر. على سبيل المثال، تمثل الفئة [Ink](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ink/) كائن حبر على الشريحة.

## **الفرق بين الكائنات العادية وكائنات الحبر**

يتم تمثيل الكائنات على شريحة PowerPoint عادةً بواسطة كائنات الشكل. في أبسط أشكالها، الشكل هو حاوية تحدد مساحة الكائن نفسه (إطارها) إلى جانب خصائص مثل حجم الحاوية، الشكل، والخلفية. لمزيد من المعلومات، راجع [Shape Layout Format](/slides/ar/python-java/shape-manipulations/#access-layout-formats-for-shape).

ومع ذلك، عندما يتعامل PowerPoint مع كائن حبر، يتجاهل جميع خصائص إطار الكائن (الحاوية) باستثناء حجمه. يتم تحديد حجم منطقة الحاوية بواسطة طريقتي [Shape.getWidth](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getWidth) و[Shape.getHeight](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getHeight) القياسيتين:

![ink_powerpoint1](ink_powerpoint1.png)

## **آثار الحبر**

آثار الحبر هي عنصر أساسي يُستخدم لتسجيل مسار القلم عندما يكتب المستخدم حبرًا رقميًا. يخزن الأثر تسلسلًا من النقاط المتصلة.

أبسط شكل للترميز يحدد إحداثيات X وY لكل نقطة عينة. عندما يتم عرض جميع النقاط المتصلة، تُنتج صورة كهذه:

![ink_powerpoint2](ink_powerpoint2.png)

## **خصائص الفرشاة للرسم**

تُستخدم الفرشاة لرسم الخطوط التي تربط نقاط أثر الحبر. للفرشاة لونها وحجمها الخاصين، ويُمثل ذلك بطريقتي [InkBrush.getColor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/inkbrush/#getColor) و[InkBrush.getSize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/inkbrush/#getSize).

### **ضبط لون فرشاة الحبر**

يعرض هذا الكود Python كيفية ضبط لون فرشاة الحبر:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush.setColor(Color.RED)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

### **ضبط حجم فرشاة الحبر**

يعرض هذا الكود Python كيفية ضبط حجم فرشاة الحبر:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush_size = Dimension(5, 10)
            brush.setSize(brush_size)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

عمومًا، لا يتطابق عرض وارتفاع الفرشاة، لذا لا يعرض PowerPoint حجم الفرشاة (يظهر القسم المقابل من البيانات باللون الرمادي). عندما يتطابق عرض وارتفاع الفرشاة، يظهر PowerPoint حجمه بهذه الطريقة:

![ink_powerpoint3](ink_powerpoint3.png)

للتوضيح، دعونا نزيد ارتفاع كائن الحبر ونستعرض الأبعاد المهمة:

![ink_powerpoint4](ink_powerpoint4.png)

الحاوية (الإطار) لا تأخذ في الاعتبار حجم الفرش؛ فهي دائمًا تفترض أن سمك الخط صفر (انظر الصورة السابقة).

لذلك، لتحديد المنطقة المرئية لكائن الحبر بالكامل، يجب مراعاة حجم فرشاة آثاره. هنا، تم تحجيم الكائن الهدف (أثر النص المكتوب بخط اليد) إلى حجم الحاوية (الإطار). عندما يتغير حجم الحاوية، يبقى حجم الفرش ثابتًا، والعكس صحيح.

![ink_powerpoint5](ink_powerpoint5.png)

يستخدم PowerPoint سلوكًا مشابهًا لكائنات النص:

![ink_powerpoint6](ink_powerpoint6.png)

## **التحكم في مظهر الحبر أثناء التصدير والعرض**

توفر Aspose.Slides الفئة [InkOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/inkoptions/) للتحكم في كيفية ظهور كائنات الحبر في المخرجات المُصدَّرة أو المعروضة. يمكنك استخدام خصائصها لإخفاء الحبر بالكامل أو لتغيير طريقة تفسير عمليات قناع فرشاة الحبر.

تتوفر خيارات الحبر من خلال خيارات التصدير أو العرض للعديد من صيغ الإخراج:

| الإخراج | خاصية خيارات الحبر |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tiffoptions/#getInkOptions) |
| صورة الشريحة | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/renderingoptions/#getInkOptions) |

الطرق التالية في الفئة [InkOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/inkoptions/) تكشف عن الإعدادين نفسهما:

- [getHideInk](https://reference.aspose.com/slides/ar/python-java/aspose.slides/inkoptions/#getHideInk) يحدد ما إذا كانت كائنات الحبر مضمنة في المخرج. القيمة الافتراضية هي `False`.
- [getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ar/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) يحدد ما إذا كانت عملية القناع تُفسَّر كعتامة عند عرض فرشاة الحبر. القيمة الافتراضية هي `True`؛ استدعِ [setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ar/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) مع `False` لاستخدام عملية ROP بدلاً من ذلك.

### **إخفاء كائنات الحبر في مخرجات PDF**

افتراضيًا، تظل كائنات الحبر مرئية أثناء التصدير. لإنشاء مخرج نظيف بدون تعليقات مكتوبة يدويًا أو محتوى حبر آخر، استدعِ [InkOptions.setHideInk](https://reference.aspose.com/slides/ar/python-java/aspose.slides/inkoptions/#setHideInk) مع `True`.

المثال التالي بلغة Python يصدر عرض تقديمي إلى PDF مع إخفاء جميع كائنات الحبر:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PdfOptions, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.getInkOptions().setHideInk(True)

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **إخفاء كائنات الحبر عند عرض الشريحة كصورة**

لإخفاء كائنات الحبر عند عرض الشرائح كصور نقطية، اضبط [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/renderingoptions/#getInkOptions) ومرّر خيارات العرض إلى [Slide.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getImage).

المثال التالي بلغة Python يعرض الشريحة الأولى كصورة PNG بدون كائنات الحبر:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RenderingOptions, ImageFormat

presentation = Presentation("presentation.pptx")
try:
    rendering_options = RenderingOptions()
    rendering_options.getInkOptions().setHideInk(True)

    slide = presentation.getSlides().get_Item(0)
    image = slide.getImage(rendering_options)
    try:
        image.save("slide_without_ink.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

### **التحكم في عرض قناع الحبر**

الإعداد [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ar/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) يتحكم في كيفية تفسير عمليات القناع عند عرض فرشات الحبر. القيمة الافتراضية هي `True`، والتي تستخدم العتامة. لاستخدام عملية ROP بدلاً من ذلك، استدعِ [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ar/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) مع `False`.

المثال التالي بلغة Python يصدر شريحة إلى SVG ويستخدم عرضًا يعتمد على ROP لعمليات قناع الحبر:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.getInkOptions().setInterpretMaskOpAsOpacity(False)

    stream = FileOutputStream("slide.svg")
    try:
        slide = presentation.getSlides().get_Item(0)
        slide.writeAsSvg(stream, svg_options)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

يمكن تطبيق الإعداد نفسه عبر [TiffOptions.getInkOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tiffoptions/#getInkOptions) عند تصدير عرض تقديمي أو عرض شريحة إلى TIFF.

### **اختر إما إخفاء الحبر أو الحفاظ عليه**

عندما تحتاج إلى نسخة نظيفة من عرض تقديمي مشروح للتوزيع دون علامات مراجعة، استدعِ [InkOptions.setHideInk](https://reference.aspose.com/slides/ar/python-java/aspose.slides/inkoptions/#setHideInk) مع `True` أثناء التصدير.

اترك [InkOptions.getHideInk](https://reference.aspose.com/slides/ar/python-java/aspose.slides/inkoptions/#getHideInk) بقيمته الافتراضية `False` عندما تكون تعليقات الحبر جزءًا من المحتوى المقصود، مثل تعليقات المراجعة، الملاحظات المكتوبة يدويًا، التحديدات، أو الرسومات التي يجب أن تبقى مرئية في النتيجة المُصدَّرة. يتيح ذلك للتطبيقات إنشاء مخرجات مراجعة ونهائية منفصلة من نفس العرض التقديمي دون تعديل كائنات الحبر الأصلية.

## **الأسئلة المتكررة**

**هل يمكنني تغيير لون أو حجم ضربة حبر موجودة؟**

نعم. احصل على الأثر عبر [Ink.getTraces](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ink/#getTraces)، ثم غير [InkTrace.getBrush](https://reference.aspose.com/slides/ar/python-java/aspose.slides/inktrace/#getBrush). استدعِ [InkBrush.setColor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/inkbrush/#setColor) أو [InkBrush.setSize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/inkbrush/#setSize) لتغيير الفرشاة.

**هل يؤدي إخفاء الحبر إلى تغيير العرض التقديمي الأصلي؟**

لا. استدعاء [InkOptions.setHideInk](https://reference.aspose.com/slides/ar/python-java/aspose.slides/inkoptions/#setHideInk) ي影响 فقط النتيجة المعروضة أو المُصدَّرة؛ ولا يزيل أو يُعدِّل كائنات الحبر في العرض التقديمي الأصلي.

**أي صيغ تصدير تدعم خيارات الحبر؟**

يمكنك ضبط خيارات الحبر لصيغ PDF وHTML وSVG وTIFF وصور الشرائح النقطية من خلال خيارات التصدير أو العرض المقابلة المذكورة أعلاه.

**قراءة إضافية**

* لقراءة عن الأشكال بشكل عام، راجع قسم [PowerPoint Shapes](/slides/ar/python-java/powerpoint-shapes/).
* لمزيد من المعلومات حول القيم الفعّالة، انظر [Shape Effective Properties](/slides/ar/python-java/shape-effective-properties/#get-effective-font-height-value).
* لتفاصيل تصدير PDF، راجع [Convert PPT and PPTX to PDF](/slides/ar/python-java/convert-powerpoint-to-pdf/).
* لتفاصيل تصدير HTML، راجع [Convert PowerPoint Presentations to HTML](/slides/ar/python-java/convert-powerpoint-to-html/).
* لتفاصيل تصدير SVG، راجع [Render Presentation Slides as SVG Images](/slides/ar/python-java/render-a-slide-as-an-svg-image/).
* لتفاصيل تصدير TIFF، راجع [Convert PowerPoint Presentations to TIFF](/slides/ar/python-java/convert-powerpoint-to-tiff/).
* لتفاصيل عرض الشرائح كصور، راجع [Convert Presentation Slides to Images](/slides/ar/python-java/convert-slide/).