---
title: إدارة تكبير العرض التقديمي في Python عبر Java
linktitle: إدارة التكبير
type: docs
weight: 60
url: /ar/python-java/manage-zoom/
keywords:
- تكبير
- إطار التكبير
- تكبير الشريحة
- تكبير القسم
- تكبير الملخص
- إضافة تكبير
- PowerPoint
- العرض التقديمي
- Python
- Java
- Aspose.Slides
description: "إنشاء وتخصيص التكبير باستخدام Aspose.Slides لـ Python عبر Java — الانتقال بين الأقسام، إضافة الصور المصغرة والانتقالات عبر عروض PPT و PPTX و ODP."
---
## **المقدمة**

Zooms in PowerPoint allow you to jump to and from specific slides, sections, and portions of a presentation. When you are presenting, this ability to navigate quickly across content might prove very useful.

![overview_image](overview.png)

* لتلخيص عرض تقديمي كامل في شريحة واحدة، استخدم [Summary Zoom](#summary-zoom).
* لعرض الشرائح المحددة فقط، استخدم [Slide Zoom](#slide-zoom).
* لعرض قسم واحد فقط، استخدم [Section Zoom](#section-zoom).

## **تكبير الشرائح**
يمكن أن يجعل تكبير الشرائح عرضك التقديمي أكثر ديناميكية، مما يسمح لك بالتنقل بحرية بين الشرائح بأي ترتيب تختاره دون مقاطعة تدفق العرض التقديمي. تكبير الشرائح مفيد للعروض القصيرة التي لا تحتوي على أقسام عديدة، ولكن يمكنك أيضًا استخدامه في سيناريوهات عرض مختلفة.

يساعدك تكبير الشرائح على التعمق في عدة قطع من المعلومات بينما تشعر كأنك على لوحة واحدة.

![overview_image](slidezoomsel.png)

للكائنات الخاصة بتكبير الشرائح، توفر Aspose.Slides تعداد [ZoomImageType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/zoomimagetype/)، والفئة [ZoomFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/zoomframe/)، وبعض الأساليب في فئة [ShapeCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/).

### **إنشاء إطارات التكبير**
يمكنك إضافة إطار تكبير إلى شريحة بهذه الطريقة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. إنشاء شرائح جديدة للربط بإطارات التكبير.
3. إضافة نص تعريف وخلفية إلى الشرائح التي تم إنشاؤها.
4. إضافة إطارات التكبير (التي تحتوي على مراجع الشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود Python يوضح لك كيفية إنشاء إطار تكبير على شريحة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # يضيف شرائح جديدة إلى العرض التقديمي
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  ينشئ خلفية للشريحة الثانية
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  ينشئ مربع نص للشريحة الثانية
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  ينشئ خلفية للشريحة الثالثة
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  ينشئ مربع نص للشريحة الثالثة
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # يضيف كائنات ZoomFrame
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  يحفظ العرض التقديمي
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **إنشاء إطارات تكبير بصور مخصصة**
With Aspose.Slides for Python via Java, you can create a zoom frame with a different slide preview image this way:
1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. إنشاء شريحة جديدة للربط بإطار التكبير.
3. إضافة نص تعريف وخلفية إلى الشريحة.
4. إنشاء كائن [PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بـ [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) التي ستُستخدم لملء الإطار.
5. إضافة إطارات التكبير (التي تحتوي على مرجع الشريحة التي تم إنشاؤها) إلى الشريحة الأولى.
6. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود Python يوضح لك كيفية إنشاء إطار تكبير بصورة مختلفة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # يضيف شريحة جديدة إلى العرض التقديمي
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  ينشئ خلفية للشريحة الثانية
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  ينشئ مربع نص للشريحة الثانية
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  ينشئ صورة جديدة لكائن التكبير
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # يضيف كائن ZoomFrame
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture)

    #  يحفظ العرض التقديمي
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **تنسيق إطارات التكبير**
في الأقسام السابقة، أظهرنا لك كيفية إنشاء إطارات تكبير بسيطة. لإنشاء إطارات تكبير أكثر تعقيدًا، عليك تعديل تنسيق الإطار البسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على إطار التكبير.

يمكنك التحكم في تنسيق إطار التكبير على شريحة بهذه الطريقة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. إنشاء شرائح جديدة للربط بإطارات التكبير.
3. إضافة نص تعريف وخلفية إلى الشرائح التي تم إنشاؤها.
4. إضافة إطارات التكبير (التي تحتوي على مراجع الشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. إنشاء كائن [PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بـ [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) التي ستُستخدم لملء الإطار.
6. تعيين صورة مخصصة لكائن إطار التكبير الأول.
7. تغيير تنسيق الخط لكائن إطار التكبير الثاني.
8. إزالة الخلفية من صورة كائن إطار التكبير الثاني.
9. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود Python يوضح لك كيفية تغيير تنسيق إطار التكبير على شريحة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # يضيف شرائح جديدة إلى العرض التقديمي
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  ينشئ خلفية للشريحة الثانية
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  ينشئ مربع نص للشريحة الثانية
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  ينشئ خلفية للشريحة الثالثة
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  ينشئ مربع نص للشريحة الثالثة
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # يضيف كائنات ZoomFrame
    first_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    second_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  ينشئ صورة جديدة لكائن التكبير
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  يعيّن صورة مخصصة لكائن first_zoom_frame
    first_zoom_frame.setZoomImage(picture)

    #  يعيّن تنسيق إطار التكبير لكائن second_zoom_frame
    second_zoom_frame.getLineFormat().setWidth(5)
    second_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    second_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink)
    second_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)

    #  إعداد لتحديد عدم إظهار الخلفية لكائن second_zoom_frame
    second_zoom_frame.setShowBackground(False)

    #  يحفظ العرض التقديمي
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تكبير القسم**
تكبير القسم هو رابط إلى قسم في عرضك التقديمي. يمكنك استخدام تكبير الأقسام للعودة إلى الأقسام التي تريد التأكيد عليها. أو يمكنك استخدامها لتوضيح كيفية اتصال أجزاء معينة من العرض التقديمي.

![overview_image](seczoomsel.png)

للكائنات الخاصة بتكبير القسم، توفر Aspose.Slides الفئة [SectionZoomFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sectionzoomframe/) وبعض الأساليب في فئة [ShapeCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/).

### **إنشاء إطارات تكبير القسم**
يمكنك إضافة إطار تكبير قسم إلى شريحة بهذه الطريقة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. إنشاء شريحة جديدة.
3. إضافة خلفية مميزة إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد للربط بإطار التكبير.
5. إضافة إطار تكبير قسم (الذي يحتوي على مراجع القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود Python يوضح لك كيفية إنشاء إطار تكبير على شريحة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # يضيف شريحة جديدة إلى العرض التقديمي
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  يضيف قسمًا جديدًا إلى العرض التقديمي
    presentation.getSections().addSection("Section 1", slide)

    #  يضيف كائن SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  يحفظ العرض التقديمي
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **إنشاء إطارات تكبير القسم بصور مخصصة**
Using Aspose.Slides for Python via Java, you can create a section zoom frame with a different slide preview image this way:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. إنشاء شريحة جديدة.
3. إضافة خلفية مميزة إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد للربط بإطار التكبير.
5. إنشاء كائن [PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بـ [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) التي ستُستخدم لملء الإطار.
6. إضافة إطار تكبير قسم (الذي يحتوي على مرجع القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
7. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود Python يوضح لك كيفية إنشاء إطار تكبير بصورة مختلفة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # يضيف شريحة جديدة إلى العرض التقديمي
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  يضيف قسمًا جديدًا إلى العرض التقديمي
    presentation.getSections().addSection("Section 1", slide)

    #  ينشئ صورة جديدة لكائن التكبير
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  يضيف كائن SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1), picture)

    #  يحفظ العرض التقديمي
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **تنسيق إطارات تكبير القسم**
لإنشاء إطارات تكبير قسم أكثر تعقيدًا، عليك تعديل تنسيق إطار بسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على إطار تكبير القسم.

يمكنك التحكم في تنسيق إطار تكبير القسم على شريحة بهذه الطريقة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. إنشاء شريحة جديدة.
3. إضافة خلفية مميزة إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد للربط بإطار التكبير.
5. إضافة إطار تكبير قسم (الذي يحتوي على مراجع القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. تغيير حجم وموقع كائن تكبير القسم الذي تم إنشاؤه.
7. إنشاء كائن [PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بـ [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) التي ستُستخدم لملء الإطار.
8. تعيين صورة مخصصة لكائن إطار تكبير القسم الذي تم إنشاؤه.
9. تفعيل قدرة *العودة إلى الشريحة الأصلية من القسم المرتبط*.
10. إزالة الخلفية من صورة كائن إطار تكبير القسم.
11. تغيير تنسيق الخط لكائن إطار تكبير القسم.
12. تغيير مدة الانتقال.
13. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود Python يوضح لك كيفية تغيير تنسيق إطار تكبير القسم:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # يضيف شريحة جديدة إلى العرض التقديمي
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  يضيف قسمًا جديدًا إلى العرض التقديمي
    presentation.getSections().addSection("Section 1", slide)

    #  يضيف كائن SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  تنسيق كائن SectionZoomFrame
    section_zoom_frame.setX(100)
    section_zoom_frame.setY(300)
    section_zoom_frame.setWidth(100)
    section_zoom_frame.setHeight(75)

    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    section_zoom_frame.setZoomImage(picture)

    section_zoom_frame.setReturnToParent(True)
    section_zoom_frame.setShowBackground(False)

    section_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    section_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray)
    section_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    section_zoom_frame.getLineFormat().setWidth(2.5)

    section_zoom_frame.setTransitionDuration(1.5)

    #  يحفظ العرض التقديمي
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تكبير الملخص**
A summary zoom is like a landing page where all the pieces of your presentation are displayed at once. When you're presenting, you can use the zoom to go from one place in your presentation to another in any order you like. You can get creative, skip ahead, or revisit pieces of your slide show without interrupting the flow of your presentation.

![overview_image](sumzoomsel.png)

For summary zoom objects, Aspose.Slides provides the [SummaryZoomFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/summaryzoomsection/), and [SummaryZoomSectionCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/summaryzoomsectioncollection/) classes and some methods in the [ShapeCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/) class.

### **إنشاء تكبير ملخص**
يمكنك إضافة إطار تكبير ملخص إلى شريحة بهذه الطريقة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. إنشاء شرائح جديدة بخلفية مميزة وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار تكبير الملخص إلى الشريحة الأولى.
4. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود Python يوضح لك كيفية إنشاء إطار تكبير ملخص على شريحة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # يضيف شريحة جديدة إلى العرض التقديمي
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  يضيف قسمًا جديدًا إلى العرض التقديمي
    presentation.getSections().addSection("Section 1", slide)

    # يضيف شريحة جديدة إلى العرض التقديمي
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  يضيف قسمًا جديدًا إلى العرض التقديمي
    presentation.getSections().addSection("Section 2", slide)

    # يضيف شريحة جديدة إلى العرض التقديمي
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  يضيف قسمًا جديدًا إلى العرض التقديمي
    presentation.getSections().addSection("Section 3", slide)

    # يضيف شريحة جديدة إلى العرض التقديمي
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  يضيف قسمًا جديدًا إلى العرض التقديمي
    presentation.getSections().addSection("Section 4", slide)

    #  يضيف كائن SummaryZoomFrame
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  يحفظ العرض التقديمي
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **إضافة وإزالة قسم تكبير الملخص**
All sections in a summary zoom frame are represented by [SummaryZoomSection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/summaryzoomsection/) objects, which are stored in the [SummaryZoomSectionCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/summaryzoomsectioncollection/) object. You can add or remove a summary zoom section object through the [SummaryZoomSectionCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/summaryzoomsectioncollection/) class this way:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. إنشاء شرائح جديدة بخلفية مميزة وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار تكبير ملخص إلى الشريحة الأولى.
4. إضافة شريحة جديدة وقسم إلى العرض التقديمي.
5. إضافة القسم الذي تم إنشاؤه إلى إطار تكبير الملخص.
6. إزالة القسم الأول من إطار تكبير الملخص.
7. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود Python يوضح لك كيفية إضافة وإزالة الأقسام في إطار تكبير ملخص:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # يضيف شريحة جديدة إلى العرض التقديمي
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  يضيف قسمًا جديدًا إلى العرض التقديمي
    presentation.getSections().addSection("Section 1", slide)

    # يضيف شريحة جديدة إلى العرض التقديمي
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  يضيف قسمًا جديدًا إلى العرض التقديمي
    presentation.getSections().addSection("Section 2", slide)

    #  يضيف كائن SummaryZoomFrame
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    # يضيف شريحة جديدة إلى العرض التقديمي
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  يضيف قسمًا جديدًا إلى العرض التقديمي
    third_section = presentation.getSections().addSection("Section 3", slide)

    #  يضيف قسمًا إلى ملخص التكبير
    summary_zoom_frame.getSummaryZoomCollection().addSummaryZoomSection(third_section)

    #  يزيل القسم من ملخص التكبير
    summary_zoom_frame.getSummaryZoomCollection().removeSummaryZoomSection(presentation.getSections().get_Item(1))

    #  يحفظ العرض التقديمي
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **تنسيق أقسام تكبير الملخص**
To create more complicated summary zoom section objects, you have to alter a simple frame's formatting. There are several formatting options you can apply to a summary zoom section object.

يمكنك التحكم في تنسيق كائن قسم تكبير الملخص داخل إطار تكبير ملخص بهذه الطريقة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. إنشاء شرائح جديدة بخلفية مميزة وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار تكبير ملخص إلى الشريحة الأولى.
4. الحصول على كائن قسم تكبير الملخص الأول من [SummaryZoomSectionCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/summaryzoomsectioncollection/).
5. إنشاء كائن [PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بـ [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) التي ستُستخدم لملء الإطار.
6. تعيين صورة مخصصة لكائن قسم تكبير الملخص.
7. تفعيل قدرة *العودة إلى الشريحة الأصلية من القسم المرتبط*.
8. تغيير تنسيق الخط لكائن قسم تكبير الملخص.
9. تغيير مدة الانتقال.
10. حفظ العرض التقديمي المعدل كملف PPTX.

هذا الكود Python يوضح لك كيفية تغيير تنسيق كائن قسم تكبير الملخص:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # يضيف شريحة جديدة إلى العرض التقديمي
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  يضيف قسمًا جديدًا إلى العرض التقديمي
    presentation.getSections().addSection("Section 1", slide)

    # يضيف شريحة جديدة إلى العرض التقديمي
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  يضيف قسمًا جديدًا إلى العرض التقديمي
    presentation.getSections().addSection("Section 2", slide)

    #  يضيف كائن SummaryZoomFrame
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  يحصل على أول كائن SummaryZoomSection
    summary_section = summary_zoom_frame.getSummaryZoomCollection().get_Item(0)

    #  تنسيق كائن SummaryZoomSection
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    summary_section.setZoomImage(picture)

    summary_section.setReturnToParent(False)

    summary_section.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    summary_section.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black)
    summary_section.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    summary_section.getLineFormat().setWidth(1.5)

    summary_section.setTransitionDuration(1.5)

    #  يحفظ العرض التقديمي
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**هل يمكنني التحكم في العودة إلى الشريحة 'الأصلية' بعد عرض الهدف؟**

نعم. يدعم كل من [ZoomFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/zoomframe/) أو [SectionZoomFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sectionzoomframe/) العودة إلى الشريحة الأصلية عبر [setReturnToParent](https://reference.aspose.com/slides/ar/python-java/aspose.slides/zoomobject/#setReturnToParent)، الذي يعيد المشاهدين بعد زيارة المحتوى المستهدف عندما يكون مفعلاً.

**هل يمكنني ضبط 'السرعة' أو مدة انتقال التكبير؟**

نعم. يدعم التكبير تعيين مدة الانتقال عبر [setTransitionDuration](https://reference.aspose.com/slides/ar/python-java/aspose.slides/zoomobject/#setTransitionDuration) بحيث يمكنك التحكم في طول مدة الرسوم المتحركة للقفزة.

**هل هناك حدود لعدد كائنات التكبير التي يمكن أن يحتويها العرض التقديمي؟**

لا يوجد حد ثابت موثق في واجهة برمجة التطبيقات. تعتمد الحدود العملية على تعقيد العرض التقديمي بشكل عام وأداء المشاهد. يمكنك إضافة الكثير من إطارات التكبير، لكن يجب مراعاة حجم الملف ووقت التقديم.