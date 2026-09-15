---
title: إنشاء عارض عروض تقديمية في Python عبر Java
linktitle: عارض عروض تقديمية
type: docs
weight: 50
url: /ar/python-java/presentation-viewer/
keywords:
- عرض العرض التقديمي
- عارض العروض التقديمية
- إنشاء عارض عروض تقديمية
- عرض PPT
- عرض PPTX
- عرض ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إنشاء عارض عروض تقديمية مخصص في Python عبر Java باستخدام Aspose.Slides. عرض ملفات PowerPoint و OpenDocument بسهولة دون Microsoft PowerPoint."
---
## **المقدمة**

يتم استخدام Aspose.Slides for Python عبر Java لإنشاء ملفات العروض التقديمية التي تحتوي على شرائح. يمكن عرض هذه الشرائح بفتح العروض في Microsoft PowerPoint، على سبيل المثال. ومع ذلك، قد يحتاج المطورون أحيانًا إلى عرض الشرائح كصور في عارض الصور المفضل لديهم أو إنشاء عارض عروضهم الخاص. في مثل هذه الحالات، يسمح Aspose.Slides بتصدير شريحة واحدة كصورة. يصف هذا المقال كيفية القيام بذلك.

## **إنشاء صورة SVG من شريحة**

لإنشاء صورة SVG من شريحة عرض باستخدام Aspose.Slides، يرجى اتباع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة بواسطة فهرستها.
3. فتح تدفق بايت.
4. حفظ الشريحة كصورة SVG إلى التدفق وكتابتها في ملف.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import ByteArrayOutputStream

slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **إنشاء SVG مع معرف شكل مخصص**

يمكن استخدام Aspose.Slides لإنشاء [SVG](https://docs.fileformat.com/page-description-language/svg/) من شريحة بمعرف شكل مخصص. للقيام بذلك، استخدم الطريقة [SvgShape.setId](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgshape/#setId) من الفئة [SvgShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgshape/). يمكن استخدام `CustomSvgShapeFormattingController` لتعيين معرف الشكل.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import ByteArrayOutputStream

class CustomSvgShapeFormattingController:
    def __init__(self, shape_start_index=0):
        self.shape_index = shape_start_index

    def formatShape(self, svg_shape, shape):
        svg_shape.setId(f"shape-{self.shape_index}")
        self.shape_index += 1


slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    controller = CustomSvgShapeFormattingController()
    controller_proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(controller_proxy)

    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream, svg_options)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **إنشاء صورة مصغرة للشريحة**

يساعدك Aspose.Slides على إنشاء صور مصغرة للشرائح. لإنشاء صورة مصغرة لشريحة باستخدام Aspose.Slides، يرجى اتباع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة بواسطة فهرستها.
3. الحصول على الصورة المصغرة للشريحة المرجعية بمقياس محدد.
4. حفظ الصورة المصغرة بأي صيغة صورة مرغوبة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat

slide_index = 0
scale_x = 1.0
scale_y = scale_x

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(scale_x, scale_y)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **إنشاء صورة مصغرة للشريحة بأبعاد يحددها المستخدم**

لإنشاء صورة مصغرة للشريحة بأبعاد يحددها المستخدم، يرجى اتباع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة بواسطة فهرستها.
3. الحصول على الصورة المصغرة للشريحة المرجعية بالأبعاد المحددة.
4. حفظ الصورة المصغرة بأي صيغة صورة مرغوبة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat
from java.awt import Dimension

slide_index = 0
slide_size = Dimension(1200, 800)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(slide_size)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **إنشاء صورة مصغرة للشريحة مع ملاحظات المتحدث**

لإنشاء صورة مصغرة لشريحة مع ملاحظات المتحدث باستخدام Aspose.Slides، يرجى اتباع الخطوات التالية:

1. إنشاء كائن من الفئة [RenderingOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/renderingoptions/).
2. استخدام الطريقة [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) لتحديد موضع ملاحظات المتحدث.
3. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
4. الحصول على مرجع الشريحة بواسطة فهرستها.
5. الحصول على الصورة المصغرة للشريحة المرجعية باستخدام خيارات العرض.
6. حفظ الصورة المصغرة بأي صيغة صورة مرغوبة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, RenderingOptions

slide_index = 0
layouting_options = NotesCommentsLayoutingOptions()
layouting_options.setNotesPosition(NotesPositions.BottomTruncated)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layouting_options)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(rendering_options)
    try:
        image.save("output.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **مثال حي**

يمكنك تجربة تطبيق [**Aspose.Slides Viewer**](https://products.aspose.app/slides/ar/viewer/) المجاني لمعرفة ما يمكنك تنفيذه باستخدام Aspose.Slides API:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **الأسئلة المتكررة**

**هل يمكنني تضمين عارض عروض داخل تطبيق ويب؟**

نعم. يمكنك استخدام Aspose.Slides على الخادم لتصوير الشرائح كصور أو HTML وعرضها في المتصفح. يمكن تنفيذ ميزات التنقل والتكبير باستخدام JavaScript لتجربة تفاعلية.

**ما هي أفضل طريقة لعرض الشرائح داخل عارض مخصص؟**

النهج الموصى به هو تصوير كل شريحة كصورة (مثل PNG أو SVG) أو تحويلها إلى HTML باستخدام Aspose.Slides، ثم عرض الناتج داخل عنصر صورة (للتطبيقات المكتبية) أو داخل حاوية HTML (للتطبيقات الويب).

**كيف يمكنني التعامل مع عروض تقديمية كبيرة تحتوي على عدد كبير من الشرائح؟**

للعروض الكبيرة، يُنصح باستخدام التحميل المتأخر أو التصوير عند الطلب للشرائح. يعني ذلك توليد محتوى الشريحة فقط عندما ينتقل المستخدم إليها، مما يقلل من استهلاك الذاكرة ووقت التحميل.