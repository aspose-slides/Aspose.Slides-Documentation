---
title: تصدير شرائح العرض التقديمي كصور SVG في بايثون عبر جافا
linktitle: الشريحة إلى SVG
type: docs
weight: 50
url: /ar/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint إلى SVG
- العرض التقديمي إلى SVG
- الشريحة إلى SVG
- PPT إلى SVG
- PPTX إلى SVG
- خيارات تصدير SVG
- SVG تفاعلي
- PowerPoint
- العرض التقديمي
- Python
- Java
- Aspose.Slides
description: "تصدير شرائح PowerPoint كصور SVG في بايثون عبر جافا والتحكم في الخطوط والنصوص والصور والمعرفات والأحداث باستخدام Aspose.Slides."
---
## **نظرة عامة**

SVG هو تنسيق صورة قائم على XML قابل للتوسيع يعمل بشكل جيد للنشر على الويب، وعارض الشرائح، وسير عمل الوصول، والمعالجة التلقائية بعد الإنشاء. تقوم Aspose.Slides بتصدير كل شريحة إلى ملف SVG منفصل وتتيح لك التحكم في كيفية كتابة النصوص، الخطوط، الصور، وعناصر SVG.

استخدم [SVGOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgoptions/) عندما يجب أن يكون SVG المُصدَّر مضغوطًا، متوقعًا عبر المتصفحات، أو جاهزًا للاستخدام التفاعلي.

## **تصدير شريحة كـ SVG**

أنشئ [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/)، حدد شريحة، واكتبها إلى تدفق باستخدام [Slide.writeAsSvg](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/). تتطلب الأمثلة وجود ملف `presentation.pptx` موجود. كل مثال يبدأ الـ JVM إذا لزم الأمر ويغلق تدفقات الخرج الخاصة به. المثال التالي يصدر كل شريحة في عرض تقديمي إلى ملف SVG منفصل.

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

يستخدم اسم الملف [Slide.getSlideNumber](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getSlideNumber) بدلاً من فهرس الحلقة. يمكنك أيضًا تصدير شكل فردي باستخدام [Shape.writeAsSvg](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/) عندما يحتاج عارض الشرائح أو صفحة الويب إلى ذلك الشكل فقط.

## **تكوين إخراج SVG**

[SVGOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgoptions/) يتحكم في عرض SVG. بالنسبة لإطارات النص، [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgoptions/#setUseFrameSize) يضم إطار النص في منطقة العرض، و[SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgoptions/#setUseFrameRotation) يحدد ما إذا كان يتم تطبيق دوران الإطار. اضبط [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) إلى `True` عندما يجب عرض النص بدون أربطة الخط.

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

### **تحويل كل النص إلى رسومات متجهة**

اضبط [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgoptions/#setVectorizeText) إلى `True` لكتابة كل نص الشريحة كرسومات متجهة. هذا يلغي الاعتماد على الخطوط ويجعل النتيجة البصرية أكثر اتساقًا عبر المتصفحات، لكن النص لم يعد قابلًا للتحديد أو البحث كالنص SVG.

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

### **اختر طريقة معالجة الخطوط الخارجية**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) يستخدم قيمة [SvgExternalFontsHandling](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgexternalfontshandling/) للخطوط التي يتم تحميلها خارجيًا. اختر `AddLinksToFontFiles` للإشارة إلى ملفات خطوط منفصلة، `Embed` لتضمين بيانات الخط داخل SVG، أو `Vectorize` لعرض النص الذي يستخدم الخطوط الخارجية كرسومات فقط. تحقق من ترخيص الخط قبل تضمين الخطوط.

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

استخدم [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgoptions/#setPicturesCompression) لتقليل دقة الصور المضمنة، و[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) لحذف المناطق المقتطفة من المصدر، و[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgoptions/#setJpegQuality) للتحكم في جودة ترميز JPEG. هذه الإعدادات تقلل حجم الملف على حساب دقة الصورة أو احتفاظ ببيانات الصورة.

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

## **تعيين معرفات ثابتة للأشكال والنص**

استخدم وحدة تحكم تنسيق بايثون مسجلة عبر `jpype.JProxy` لتعيين قيم [SvgShape.setId](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgshape/#setId) إلى الأشكال و قيم [SvgTSpan.setId](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgtspan/#setId) إلى عناصر النص `tspan`. عيّن الوكيل باستخدام [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

المتحكم التالي يستخدم [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getOfficeInteropShapeId)، وهو ثابت طوال عمر الشكل، ومضounter قابل للتكرار للـ text spans الخاصة به. هذا يجعل المعرفات المُولدة مناسبة للمعالجة اللاحقة لعرض تقديمي غير متغيّر.

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

في وحدة تحكم تنسيق بايثون، استدعِ [SvgShape.setEventHandler](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgshape/#setEventHandler) مع قيمة [SvgEvent](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgevent/) لإضافة معالج حدث جافاسكريبت إلى شكل مُصدَّر. سجل المتحكم عبر `jpype.JProxy` وعيّنّه باستخدام [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgoptions/#setShapeFormattingController). عرّف دالة جافاسكريبت في الصفحة أو مستند SVG الذي يستضيف النتيجة.

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

يمكن للصفحة المستضيفة تعريف دالة جافاسكريبت التي يشير إليها المعالج. تعيين المعرفات ومعالجات الأحداث يتيح لعارضات الشرائح، وتعزيزات الوصول، وغيرها من سير عمل SVG التفاعلية.

## **الأسئلة الشائعة**

**متى يجب استخدام [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgoptions/#setVectorizeText) بدلاً من [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)?**

استخدم [SVGOptions.setVectorizeText] عندما يجب أن يكون كل النص مستقلًا عن الخطوط. استخدم [SvgExternalFontsHandling.Vectorize] عندما ينبغي تحويل النص الذي يستخدم خطوطًا خارجية فقط إلى رسومات.

**ما هي أفضل طريقة لجعل ملف SVG أصغر؟**

ابدأ بضغط الصور المضمنة، حذف المناطق المقتطفة من الصورة، واختيار ملفات خطوط مرتبطة عندما يمكن للبيئة المستهدفة تقديمها. اختبر النتيجة لأن خفض دقة الصورة، خفض جودة JPEG، وتحويل النص إلى رسومات متجهة كل منها يملك مفاضلات مختلفة بين الجودة والحجم.

**هل يمكنني تعديل عناصر SVG المُصدَّرة بعد التصدير؟**

نعم. عيّن المعرفات عبر وحدة تحكم تنسيق، ثم حدد عناصر SVG المتطابقة في أداة المعالجة اللاحقة أو سكربت المتصفح.