---
title: تحويل شرائح العروض التقديمية إلى صور في بايثون
linktitle: شريحة إلى صورة
type: docs
weight: 35
url: /ar/python-java/convert-slide/
keywords:
- تحويل شريحة
- تصدير شريحة
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
- Python
- Aspose.Slides
description: "تحويل الشرائح من عروض PPT وPPTX وODP إلى صيغ PNG وJPEG وGIF وTIFF وEMF وغيرها من صيغ الصور في بايثون باستخدام Aspose.Slides."
---
## **المقدمة**

يمكن لـ Aspose.Slides for Python via Java أن يعرض شرائح فردية من عروض PowerPoint وOpenDocument كصيغ PNG وJPEG وGIF وTIFF وغيرها من صيغ الصور.

لتحويل شريحة إلى صورة، اتبع الخطوات التالية:

1. حمّل العرض باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
2. اختر الشريحة التي تريد عرضها.
3. إذا لزم الأمر، اضبط عملية العرض باستخدام الفئة [RenderingOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/renderingoptions/) أو الفئة [TiffOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tiffoptions/).
4. استدعِ الطريقة [Slide.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getImage). تُعيد كائن صورة.
5. احفظ الصورة وحدد صيغة الإخراج باستخدام قيمة [ImageFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imageformat/).

## **تحويل شريحة إلى صورة PNG**

أبسط طريقة للتحويل تستخدم إعدادات العرض الافتراضية. يمكن معالجتها في الذاكرة أو حفظها كملف.

المثال التالي بلغة Python يعرض الشريحة الأولى ويحفظها كصورة PNG:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage()
    try:
        image.save("Slide_0.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **تحويل الشرائح إلى صور بأحجام مخصصة**

استخدم نسخة overload من [Slide.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getImage) التي تقبل قيمة [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) لتصوير شريحة بأبعاد بكسلية دقيقة.

المثال التالي ينشئ صورة JPEG بأبعاد 1820 × 1040:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

image_size = Dimension(1820, 1040)

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(image_size)
    try:
        image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **تحويل الشرائح مع الملاحظات والتعليقات إلى صور**

بشكل افتراضي، لا تتضمن صور الشرائح الملاحظات أو التعليقات. مرّر كائنًا من نوع [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notescommentslayoutingoptions/) إلى الطريقة [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) للتحكم في موضع ظهور الملاحظات والتعليقات.

المثال التالي يضع ملاحظات مقصوصة أسفل الشريحة وتعليقات إلى يمينها:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Color

scale_x = 2.0
scale_y = scale_x

comments_area_color = Color(250, 235, 215)

layout_options = NotesCommentsLayoutingOptions()
layout_options.setNotesPosition(NotesPositions.BottomTruncated)
layout_options.setCommentsPosition(CommentsPositions.Right)
layout_options.setCommentsAreaWidth(500)
layout_options.setCommentsAreaColor(comments_area_color)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("Presentation_with_notes_and_comments.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(rendering_options, scale_x, scale_y)
    try:
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
في تحويل الشرائح إلى صور، لا تمرر [BottomFull](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notespositions/#BottomFull) إلى الطريقة [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). قد تحتوي الملاحظات على نص أكثر مما تستطيع الصورة الثابتة استيعابه. استخدم [BottomTruncated](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notespositions/#BottomTruncated) بدلاً من ذلك.
{{% /alert %}}

## **تحويل الشرائح إلى صور باستخدام خيارات TIFF**

تتيح لك الفئة [TiffOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tiffoptions/) التحكم في الحجم والدقة والخصائص الأخرى لصورة TIFF المستخرجة.

المثال التالي يعرض الشريحة الأولى كصورة TIFF بأبعاد 2160 × 2880 ودقة 300 DPI:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, TiffOptions
from java.awt import Dimension

image_size = Dimension(2160, 2880)

tiff_options = TiffOptions()
tiff_options.setImageSize(image_size)
tiff_options.setDpiX(300)
tiff_options.setDpiY(300)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(tiff_options)
    try:
        image.save("output.tiff", ImageFormat.Tiff)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
دعم TIFF غير مضمون في إصدارات Java الأقدم من JDK 9.
{{% /alert %}}

## **تحويل جميع الشرائح إلى صور**

تجول عبر مجموعة الشرائح لتحويل كامل العرض إلى مجموعة من الصور. تشمل الشرائح المخفية ما لم تقم بتجاوزها صراحةً.

المثال التالي يعرض كل شريحة كصورة JPEG بمعاملات تكبير أفقية وعمودية مقدارها 2:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = scale_x

presentation = Presentation("Presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for index in range(slide_count):
        slide = presentation.getSlides().get_Item(index)
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"Slide_{index}.jpg", ImageFormat.Jpeg)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **إنشاء مخرجات Metafile معززة**

ملف Metafile المعزز (EMF) مفيد عندما يجب تبادل الرسومات القائمة على المتجهات مع Microsoft Office أو تطبيقات Windows الأخرى التي تدعم ملفات metafile. على عكس الصورة القائمة على البكسل، يمكن لـ EMF الاحتفاظ بعمليات الرسم المتجهية التي تُكَبَّر دون فقدان الحدة. ومع ذلك، يُعتبر EMF في المقام الأول تنسيق توافق لتطبيقات تدعم ملفات metafile لنظام Windows، وليس تنسيق تبادل شامل. بالإضافة إلى ذلك، قد يُخزن محتوى الشريحة المعقد، مثل الصور النقطية وبعض التأثيرات، كعناصر مُرصَّصة داخل حاوية ملف المتجه.

### **تصدير شريحة إلى EMF**

تكتب الطريقة [Slide.writeAsEmf](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/) كائنًا من نوع [Slide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/) إلى تدفق الهدف بصيغة EMF. المثال التالي يحمل عرضًا، يختار الشريحة الأولى، ويكتبها إلى تدفق ملف EMF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = FileOutputStream("Slide_0.emf")
    try:
        slide.writeAsEmf(emf_stream)
    finally:
        emf_stream.close()
finally:
    presentation.dispose()
```

المستدعي يملك التدفق الممرّر إلى [Slide.writeAsEmf](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/) وهو مسؤول عن إغلاقه، كما هو موضح أعلاه.

### **تحويل صورة SVG إلى EMF وإضافتها إلى عرض تقديمي**

استخدم [SvgImage.writeAsEmf](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgimage/) لتحويل محتوى SVG إلى EMF. يمكن إضافة البايتات الناتجة إلى العرض عبر [ImageCollection.addImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagecollection/#addImage) ووضعها على شريحة باستخدام [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addPictureFrame).

المثال التالي ينشئ كائن [SvgImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgimage/) من شفرة SVG، يحوله إلى EMF في الذاكرة، يُدرج الملف المتجه في الشريحة الأولى، ويحفظ العرض:

```python
import jpype
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage
from java.io import ByteArrayOutputStream

svg_content = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>"
svg_image = SvgImage(svg_content)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = ByteArrayOutputStream()
    try:
        svg_image.writeAsEmf(emf_stream)

        emf_data = emf_stream.toByteArray()
        image = presentation.getImages().addImage(emf_data)
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image)
    finally:
        emf_stream.close()

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

طريقة [SvgImage.writeAsEmf](https://reference.aspose.com/slides/ar/python-java/aspose.slides/svgimage/) لا تتولى ملكية تدفق الوجهة. يقوم [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) بتخزين جميع البيانات التي تم إنشاؤها في الذاكرة، لذلك لا يلزم إعادة تعيين الموضع قبل استدعاء [ByteArrayOutputStream.toByteArray](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html#toByteArray--). يظل مصفوفة البايتات المرجعة صالحة بعد إغلاق التدفق.

يتوفر إنشاء ملفات EMF على أنظمة التشغيل التي يدعمها Aspose.Slides for Python via Java وتكوين JDK المختار، لكن قد يختلف العرض عبر الأنظمة عندما تكون الخطوط أو تبعيات الرسومات غير متوفرة. قم بتثبيت الخطوط المستخدمة في المحتوى الأصلي أو اضبط استبدالات مناسبة، واتبع [متطلبات النظام](/slides/ar/python-java/system-requirements/) لـ Aspose.Slides for Python via Java، وتحقق من النتيجة في التطبيق المستهدف لاستهلاك EMF. غالبًا ما تكون تطبيقات Linux وmacOS ذات دعم محدود أو غير متسق لعرض وتحرير ملفات metafile الخاصة بـ Windows.

## **عرض الإيموجي الملونة**

{{% alert title="Note" color="info" %}}
لعرض الإيموجي الملونة بشكل صحيح عند تحويل شرائح العرض إلى صور، يجب تثبيت خطوط الإيموجي المستخدمة في العرض وتوافرها على النظام الذي يُجري التحويل. على سبيل المثال، إذا كان العرض يستخدم **Segoe UI Emoji** وكان هذا الخط غير موجود، قد تظهر الإيموجي بالأبيض والأسود في الصور الناتجة.
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يدعم Aspose.Slides عرض الشرائح مع الرسوم المتحركة؟**

لا. الطريقة [Slide.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getImage) تُظهر صورة ثابتة للشريحة ولا تُصدّر الرسوم المتحركة.

**هل يمكن تصدير الشرائح المخفية كصور؟**

نعم. يمكن عرض الشرائح المخفية مثل الشرائح العادية. قم بإدراجها في حلقة المعالجة، كما هو موضح في المثال أعلاه.

**هل تُحافظ صور الشرائح على الظلال وغيرها من التأثيرات؟**

نعم. يقوم Aspose.Slides بعرض الظلال والشفافية وغيرها من التأثيرات الرسومية المدعومة في صور الشرائح.