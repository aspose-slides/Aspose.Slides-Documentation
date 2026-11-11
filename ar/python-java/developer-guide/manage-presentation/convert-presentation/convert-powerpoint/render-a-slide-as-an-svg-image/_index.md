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
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تصدير شرائح PowerPoint كصور SVG في بايثون عبر جافا والتحكم في الخطوط والنصوص والصور والمعرفات والأحداث باستخدام Aspose.Slides."
---
## **نظرة عامة**

SVG هو تنسيق صور قائم على XML وقابل للتوسع يعمل بشكل جيد للنشر على الويب، وعارض الشرائح، وسير عمل الوصول، ومعالجة ما بعد الإصدارات الآلية. تقوم Aspose.Slides بتصدير كل شريحة إلى ملف SVG منفصل وتسمح لك بالتحكم في كيفية كتابة النص، والخطوط، والصور، وعناصر SVG.

استخدم [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) عندما يتوجب أن يكون ملف SVG المُصدَّر مضغوطًا، ومتوقعًا عبر المتصفحات، أو جاهزًا للاستخدام التفاعلي.

## **تصدير شريحة كملف SVG**

أنشئ [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)، اختر شريحة، واكتبها إلى تدفق باستخدام [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). تتطلب الأمثلة وجود ملف `presentation.pptx` موجود. كل مثال يبدأ تشغيل JVM إذا لزم الأمر ويغلق تدفقات الإخراج الخاصة به. المثال التالي يصدر كل شريحة في عرض تقديمي كملف SVG منفصل.

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

يستخدم اسم الملف [Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber) بدلاً من فهرس الحلقة. يمكنك أيضًا تصدير شكل فردي باستخدام [Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) عندما يحتاج عارض الشرائح أو صفحة ويب إلى ذلك الشكل فقط.

## **تهيئة إخراج SVG**

[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) يتحكم في إنشاء SVG. بالنسبة لإطارات النص، [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) يضم إطار النص في مساحة الإنشاء، و[SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) يحدد ما إذا كان يتم تطبيق تدوير الإطار. اضبط [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) على `True` عندما يجب عرض النص بدون أحرف ربط.

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

## **التحكم في النص والخطوط**

عند تصدير الشرائح إلى SVG، يمكنك التحكم فيما إذا كان يبقى النص كنص أو يتحول إلى رسومات متجهة، وكيفية تضمين الخطوط الخارجية أو الإشارة إليها. تساعدك الخيارات التالية على موازنة التناسق البصري، واختيار النص، واعتماديات الخط في ملف SVG المُصدَّر.

### **تحويل كل النص إلى متجهات**

اضبط [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) على `True` لكتابة كل نص الشريحة كرسوم متجهة. هذا يقضي على اعتماديات الخط ويجعل النتيجة البصرية أكثر اتساقًا عبر المتصفحات، لكن النص لن يكون قابلًا للتحديد أو البحث كنص SVG.

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

### **اختيار طريقة معالجة الخطوط الخارجية**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) يستخدم قيمة [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/) للخطوط التي تُحمَّل خارجيًا. اختر `AddLinksToFontFiles` للإشارة إلى ملفات خطوط منفصلة، `Embed` لتضمين بيانات الخط في SVG، أو `Vectorize` لتجسيد النص الذي يستخدم خطوطًا خارجية كرسومات فقط. تحقق من ترخيص الخط قبل تضمينه.

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

## **تقليل حجم الصور المدمجة**

استخدم [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) لتقليل دقة الصور المدمجة، و[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) لحذف المناطق المقصوصة من المصادر، و[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) للتحكم في جودة ترميز JPEG. هذه الإعدادات تقلل حجم الملف على حساب دقة الصورة أو البيانات المحتفظ بها.

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

## **التحكم في دقة تحويل الميتا‑فائل إلى نقطية**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) يحدد الحد الأدنى لدقة تحويل الميتا‑فائل إلى صور نقطية أثناء تصدير SVG. استخدمه لتحقيق توازن بين التفاصيل وحجم الملف عندما يتم تحويل صورة EMF أو WMF إلى نقطية. لا يحدد DPI عالميًا للـ SVG ولا يجبر كل كائن في الشريحة على أن يصبح صورة نقطية.

قم بتحميل [metafile-rasterization.pptx](metafile-rasterization.pptx)، والذي يحتوي على صورة EMF بخطوط قطرية متقاربة. المثال التالي يصدر شريحة الأولى بثلاث دقات rasterization عبر [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). جميع إعدادات التصدير الأخرى تبقى متطابقة حتى يمكن مقارنة النتائج.

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

في الناتج، أصبحت صورة EMF صورة PNG مدمجة واحدة في كل SVG. القياسات التالية تخص العرض التقديمي المرفق؛ فهي ليست صيغة عامة لتحويل DPI إلى أبعاد البكسل.

| DPI لتحويل الميتا‑فائل إلى نقطية | أبعاد PNG المدمجة | حجم ملف SVG (بايت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

المقارنة أدناه تُظهر نفس منطقة الصورة النقطية المدمجة بالحجم المعروض المكبر نفسه. الخطوط القطرية تُظهر بكسلة واضحة عند 72 DPI وحواف أكثر سلاسة عند الدقات الأعلى، بينما يزداد حجم ملف SVG. زيادة القيمة لا تحسن كل التفاصيل بالضرورة ولا تغير كل صورة مُصدَّرة.

![تفصيل الخط القطري المكبر عند 72 و150 و300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) يتحكم في تقليل دقة الصورة ويمكنه إخفاء تأثير تغيير دقة تحويل الميتا‑فائل إلى نقطية. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) يتحكم في جودة ترميز JPEG، وليس في دقة تحويل الميتا‑فائل إلى نقطية.

## **تعيين معرفات ثابتة للأشكال والنص**

استخدم وحدة تحكم تنسيق Python مسجلة عبر `jpype.JProxy` لتعيين قيم [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId) للأشكال و[SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId) لعناصر النص `tspan`. عيّن الوكيل باستخدام [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

الوحدة التالية تستخدم [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId)، وهو ثابت طوال فترة وجود الشكل، ومؤشرًا قابلًا للتكرار لتحديد الفواصل النصية. يجعل ذلك المعرفات المولدة مناسبة لمعالجة ما بعد عرض تقديمي غير معدل.

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

في وحدة تحكم تنسيق Python، استدعِ [SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler) بقيمة [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/) لإضافة معالج أحداث JavaScript إلى شكل مُصدَّر. سجِّل المتحكم عبر `jpype.JProxy` وعينه باستخدام [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController). عرِّف دالة JavaScript في الصفحة أو مستند SVG الذي يستضيف النتيجة.

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

يمكن للصفحة المضيفة تعريف دالة JavaScript التي يشير إليها المعالج. يتيح تعيين المعرفات ومعالجات الأحداث لمُعَارِضي الشرائح، وتعزيزات الوصول، وغير ذلك من سير عمل SVG التفاعلية.

## **الأسئلة المتكررة**

**متى يجب استخدام [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) بدلاً من [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)؟**

استخدم [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) عندما يجب أن يكون كل النص مستقلًا عن الخطوط. استخدم [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) عندما يجب تحويل النص الذي يستخدم خطوطًا خارجية فقط إلى رسومات.

**ما هي أفضل طريقة لجعل ملف SVG أصغر؟**

ابدأ بضغط الصور المدمجة، حذف المناطق المقصوصة من الصورة، واختيار ملفات خطوط مرتبطة عندما يمكن للبيئة المستهدفة تقديمها. اختبر النتيجة لأن تقليل دقة الصورة، انخفاض جودة JPEG، والنص المتجسَّد كلّها لها مقايضات جودة وحجم مختلفة.

**هل يمكن تعديل عناصر SVG المُصدَّرة بعد التصدير؟**

نعم. عيّن المعرفات عبر وحدة تحكم تنسيق، ثم اختر العناصر المطابقة في SVG باستخدام أداة ما بعد المعالجة أو برنامج نصي في المتصفح.