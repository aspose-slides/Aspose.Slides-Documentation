---
title: عرض شرائح العرض التقديمي كصور SVG في بايثون عبر جافا
linktitle: شريحة إلى SVG
type: docs
weight: 50
url: /ar/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint إلى SVG
- العرض التقديمي إلى SVG
- شريحة إلى SVG
- PPT إلى SVG
- PPTX إلى SVG
- خيارات تصدير SVG
- SVG تفاعلي
- PowerPoint
- العرض التقديمي
- Python
- Java
- Aspose.Slides
description: "تصدير شرائح PowerPoint كصور SVG في Python عبر Java والتحكم في الخطوط والنصوص والصور والمعرفات والأحداث باستخدام Aspose.Slides."
---
## **نظرة عامة**

SVG هو تنسيق صورة قائم على XML قابل للتوسعة يعمل جيدًا للنشر على الويب، عارضات الشرائح، تدفقات عمل إمكانية الوصول، والمعالجة اللاحقة الآلية. تقوم Aspose.Slides بتصدير كل شريحة إلى ملف SVG منفصل وتسمح لك بالتحكم في كيفية كتابة النصوص، الخطوط، الصور، وعناصر SVG.

استخدم [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) عندما يجب أن يكون SVG المُصدَّر مضغوطًا، متوقعًا عبر المتصفحات، أو جاهزًا للاستخدام التفاعلي.

## **تصدير شريحة كـ SVG**

أنشئ [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)، اختر شريحة، واكتبها إلى تدفق باستخدام [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). تتطلب الأمثلة وجود ملف `presentation.pptx` موجود. كل مثال يبدأ JVM إذا لزم الأمر ويغلق تدفقات الإخراج الخاصة به. المثال التالي يصدر كل شريحة في عرض تقديمي كملف SVG منفصل.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        output_file_name = f"slide-{slide.getSlideNumber()}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

يستخدم اسم الملف [Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber) بدلاً من فهرس الحلقة. يمكنك أيضًا تصدير شكل فردي باستخدام [Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) عندما يحتاج عارض الشرائح أو صفحة الويب ذلك الشكل فقط.

## **تكوين إنتاج SVG**

[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) يتحكم في تصيير SVG. لإطارات النص، [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) يدرج إطار النص في مساحة التصيير، و[SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) يحدِّد ما إذا كان سيتم تطبيق دوران الإطار. عيّن [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) إلى `True` عندما يجب تصيير النص دون ربطات.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setDisableFontLigatures(True)
    svg_options.setUseFrameSize(True)
    svg_options.setUseFrameRotation(False)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-custom-options.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **التحكم في قص نهايات الخط عند رؤوس السهام**

SVG 1.1 لا يحتوي على إعداد إدخال علامة لتحديد موضع توقف الخط تحت رأس السهم. بشكل افتراضي، تقوم Aspose.Slides بتقليل طول الخط المُصدَّر بحيث لا يبرز سُطْرُه عبر العلامة. استدعِ [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableLineEndCropping) مع `True` لرسم السُّطْر حتى نقطة النهاية الأصلية للخط. يؤثر هذا الإعداد فقط على إنتاج SVG. يبقى الخط في موضعه وطوله على الشريحة.

يرسم المثال رؤوس سهام مثلثية وماسية على خطوط بعرض نقطتين وعشرة نقاط. يصدر الشريحة نفسها مرتين، مع تغيير خيار القص فقط.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, Presentation, ShapeType, SVGOptions
from java.awt import Color
from java.io import FileOutputStream

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    y = 40

    for style in [LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond]:
        for width in [2, 10]:
            line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0)
            line_format = line.getLineFormat()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
            line_format.setWidth(width)
            line_format.setEndArrowheadStyle(style)
            y += 50

    svg_options = SVGOptions()
    for disable_cropping, output_file_name in [(False, "cropped.svg"), (True, "uncropped.svg")]:
        svg_options.setDisableLineEndCropping(disable_cropping)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

تظهر المقارنة رأس السهم المثلثي على الخط بعرض 10 نقاط. عند تمكين القص، تكون القمة حادة. عند تعطيل القص، يبرز السُّطْر عبر الجوانب المائلة للعلامة ويترك نهاية مسطحة.

![Enlarged 10-point triangle with a sharp tip when cropping is enabled and a flat end when cropping is disabled](line-end-cropping.png)

في باقي الخطوط من المثال، يكون السُّطْر البارز أقل وضوحًا على المثلث بعرض نقطتين. يغطي الألماسة المملوءة نهاية السُّطْر في كلا العرضين.

## **التحكم في النصوص والخطوط**

عند تصدير الشرائح إلى SVG، يمكنك التحكم فيما إذا كان النص يبقى نصًا أو يُحوَّل إلى رسومات متجهة، وكيفية تضمين الخطوط الخارجية أو الإشارة إليها. تساعدك الخيارات التالية على موازنة التناسق البصري، قابلية اختيار النص، واعتماد الخطوط في SVG المُصدَّر.

### **تحويل كل النص إلى متجهات**

عيّن [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) إلى `True` لكتابة كل نص الشريحة كرسومات متجهة. يزيل ذلك الاعتماد على الخطوط ويجعل النتيجة البصرية أكثر تماسكًا عبر المتصفحات، لكن النص يصبح غير قابل للاختيار أو البحث كـ SVG نصي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setVectorizeText(True)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-vectorized-text.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

### **اختر كيفية التعامل مع الخطوط الخارجية**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) يستخدم قيمة [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/) للخطوط التي تُحمَّل خارجيًا. اختر `AddLinksToFontFiles` للإشارة إلى ملفات خطوط منفصلة، `Embed` لتضمين بيانات الخط داخل SVG، أو `Vectorize` لتصوير النص الذي يستخدم خطوطًا خارجية كرسومات. تحقق من تراخيص الخط قبل تضمينه.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgExternalFontsHandling
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    font_modes = [
        ("slide-with-font-links.svg", SvgExternalFontsHandling.AddLinksToFontFiles),
        ("slide-with-embedded-fonts.svg", SvgExternalFontsHandling.Embed),
        ("slide-with-vectorized-external-fonts.svg", SvgExternalFontsHandling.Vectorize),
    ]
    for output_file_name, font_mode in font_modes:
        svg_options = SVGOptions()
        svg_options.setExternalFontsHandling(font_mode)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

## **تقليل حجم الصور المضمنة**

استخدم [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) لتقليل دقة الصور المضمنة، و[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) لحذف المناطق المقتطعة من المصدر، و[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) للتحكم في جودة ترميز JPEG. هذه الإعدادات تقلل حجم الملف على حساب دقة الصورة أو البيانات المحتفظ بها.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setPicturesCompression(PicturesCompression.Dpi150)
    svg_options.setDeletePicturesCroppedAreas(True)
    svg_options.setJpegQuality(80)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("compressed-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **التحكم في دقة تمثيل الميتافائل كصورة نقطية**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) يحدد الحد الأدنى لدقة تمثيل الميتافائل كصورة نقطية أثناء تصدير SVG. استخدمه لموازنة التفاصيل وحجم الملف عندما يتم تمثيل صورة EMF أو WMF كصورة نقطية. لا يحدد DPI عالميًا للـ SVG ولا يجبر كل كائن على الشريحة على أن يصبح صورة نقطية.

حمّل [metafile-rasterization.pptx](metafile-rasterization.pptx)، الذي يحتوي على صورة EMF بخطوط قطرية متقاربة. المثال التالي يصدر شريحته الأولى بثلاث دقات تمثيل مختلفة عبر [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). جميع إعدادات التصدير الأخرى تبقى متطابقة ليتم مقارنة النتائج.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("metafile-rasterization.pptx")
try:
    for dpi in [72, 150, 300]:
        svg_options = SVGOptions()
        svg_options.setMetafileRasterizationDpi(dpi)
        svg_options.setPicturesCompression(PicturesCompression.Dpi330)
        svg_options.setJpegQuality(90)

        output_file_name = f"slide-{dpi}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            presentation.getSlides().get_Item(0).writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

في الناتج، تحولت صورة EMF إلى PNG مضمَّن في كل SVG. القياسات التالية تخص العرض المقدم؛ ليست صيغة عامة لتحويل DPI إلى أبعاد بكسلية.

| دقة تمثيل الميتافائل (DPI) | أبعاد PNG المضمَّن | حجم ملف SVG (بايت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

المقارنة أدناه تُظهر نفس مساحة الصورة النقطية المضمَّنة عند نفس حجم العرض المكبَّر. تظهر الخطوط القطرية بكسلية ملحوظة عند 72 DPI وحواف أكثر سلاسة عند الدقات الأعلى، بينما ينمو حجم ملف SVG. زيادة القيمة لا تحسن كل التفاصيل بالضرورة ولا تغير كل صورة مُصدَّرة.

![Enlarged diagonal-line detail at 72, 150, and 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) يتحكم في تقليل دقة الصورة وقد يُخفى تأثير تغيير دقة تمثيل الميتافائل. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) يتحكم في جودة ترميز JPEG، وليس في دقة تمثيل الميتافائل.

## **إسناد معرفات ثابتة للأشكال والنصوص**

استخدم متحكم تنسيق Python مسجَّل عبر `jpype.JProxy` لإسناد قيم [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId) إلى الأشكال و[SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId) إلى عناصر النص `tspan`. أسنِ المتحكم عبر [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

المتحكم التالي يستخدم [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId)، وهو ثابت طوال عمر الشكل، وعدَّادًا قابلًا للتكرار لنصوصه. يجعل ذلك المعرفات المولدة مناسبة للمعالجة اللاحقة لعروض تقديمية غير معدَّلة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

class StableSvgIdController:
    def __init__(self):
        self.current_shape_id = ""
        self.text_span_index = 0

    def formatShape(self, svg_shape, shape):
        self.current_shape_id = f"shape-{shape.getOfficeInteropShapeId()}"
        self.text_span_index = 0
        svg_shape.setId(self.current_shape_id)

    def formatText(self, svg_tspan, portion, text_frame):
        svg_tspan.setId(f"{self.current_shape_id}-text-{self.text_span_index}")
        self.text_span_index += 1


presentation = Presentation("presentation.pptx")
try:
    controller = StableSvgIdController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeAndTextFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-stable-ids.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **إضافة معالجات أحداث SVG**

في متحكم تنسيق Python، استدعِ [SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler) مع قيمة [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/) لإضافة معالج جافاسكريبت إلى الشكل المُصدَّر. سجِّل المتحكم عبر `jpype.JProxy` وأسنِه عبر [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController). عرِّف دالة جافاسكريبت في الصفحة أو مستند SVG الذي يستضيف النتيجة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgEvent
from java.io import FileOutputStream

class SvgEventController:
    def formatShape(self, svg_shape, shape):
        if shape.getName() == "ActionButton":
            svg_shape.setId("action-button")
            svg_shape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)")


presentation = Presentation("presentation.pptx")
try:
    controller = SvgEventController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("interactive-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

يمكن للصفحة المستضيفة تعريف دالة جافاسكريبت التي يشير إليها المعالج. إسناد المعرفات ومعالجات الأحداث يتيح عارضات الشرائح، تحسينات إمكانية الوصول، وسير عمل SVG تفاعلية أخرى.

## **الأسئلة الشائعة**

**متى يجب عليّ استخدام [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) بدلاً من [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)؟**

استخدم [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) عندما يجب أن يكون كل النص مستقلًا عن الخطوط. استخدم [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) عندما ينبغي تحويل النص الذي يستخدم خطوطًا خارجية فقط إلى رسومات.

**ما هي أفضل طريقة لجعل SVG أصغر؟**

ابدأ بضغط الصور المضمنة، حذف المناطق المقصوصة من الصور، واختيار ملفات خطوط مرتبطة عندما يمكن للبيئة المستهدفة تقديمها. اختبر النتيجة لأن تقليل دقة الصورة، خفض جودة JPEG، وتحويل النص إلى متجهات كلّها لها تأثيرات مختلفة على الجودة والحجم.

**هل يمكن تعديل عناصر SVG المُصدَّرة بعد التصدير؟**

نعم. إسناد المعرفات عبر متحكم تنسيق، ثم اختيار العناصر المطابقة في أداة المعالجة اللاحقة أو سكريبت المتصفح.