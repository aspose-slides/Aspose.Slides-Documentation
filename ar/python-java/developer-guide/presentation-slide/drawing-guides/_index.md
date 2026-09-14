---
title: إدارة الأدلة الرسومية في العروض التقديمية بلغة Python
linktitle: الأدلة الرسومية
type: docs
weight: 85
url: /ar/python-java/drawing-guides/
keywords:
- دليل رسم
- دليل أفقي
- دليل عمودي
- دليل محاذاة
- عرض الشريحة
- شريحة قالب
- شريحة تخطيط
- قالب ملاحظات
- قالب نشرة
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إضافة، الوصول، ومسح الأدلة الرسومية الأفقية والعمودية في عروض PowerPoint باستخدام Aspose.Slides للغة Python عبر Java."
---
## **نظرة عامة**

الدلائل الرسمية هي خطوط أفقية وعامودية قابلة للتعديل تساعد المستخدمين على محاذاة الأشكال بشكل ثابت أثناء تحرير عرض تقديمي في PowerPoint. تكون مفيدة بشكل خاص عندما يقوم تطبيق بإنشاء عرض تقديمي سيُعدل يدويًا لاحقًا: يمكن للتطبيق حفظ نفس أدوات المحاذاة التي يجب على المؤلفين اتباعها عند إضافة المحتوى أو تحريكه.

الدلائل الرسمية هي أدوات تحرير، ليست محتوى الشريحة. لا تظهر في عرض الشرائح أو في المخرجات المرسومة. Aspose.Slides for Python via Java يعرّفها من خلال الفئة [DrawingGuidesCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/drawingguidescollection/) . الدليل يُمثَّل بـ [DrawingGuide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/drawingguide/) وله اتجاه وموقع ولون.

الموقع يُقاس بالنقاط من الزاوية العليا اليسرى للشفرة أو القالب المناسب. يستخدم الدليل العمودي إحداثيًا أفقيًا، عادةً بين الصفر وعرض الشريحة. يستخدم الدليل الأفقي إحداثيًا عموديًا، عادةً بين الصفر وارتفاع الشريحة.

## **إضافة الأدلة إلى عرض الشريحة**

استخدم [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) لإدارة الأدلة المعروضة أثناء تحرير الشرائح العادية. استدعِ [DrawingGuidesCollection.add](https://reference.aspose.com/slides/ar/python-java/aspose.slides/drawingguidescollection/#add) مع قيمة [Orientation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/orientation/) وموقع بالنقاط.

المثال التالي يضيف دليلًا عموديًا واحدًا إلى يمين مركز الشريحة ودليلًا أفقيًا أسفله:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    guides.add(Orientation.Vertical, slide_size.getWidth() / 2 + 12.5)
    guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 12.5)

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الوصول إلى الأدلة الرسمية**

توفر الطريقتان [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/ar/python-java/aspose.slides/drawingguidescollection/#getCount) و [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/ar/python-java/aspose.slides/drawingguidescollection/#get_Item) إمكانية الوصول إلى الأدلة الموجودة. تعيد الطرائق [DrawingGuide.getOrientation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/drawingguide/#getOrientation)، [DrawingGuide.getPosition](https://reference.aspose.com/slides/ar/python-java/aspose.slides/drawingguide/#getPosition)، و [DrawingGuide.getColor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/drawingguide/#getColor) قيمًا يمكن أيضًا تعديلها عبر طرق setter المقابلة.

المثال التالي يقرأ أدلة عرض الشريحة من العرض التقديمي الذي تم إنشاؤه أعلاه:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("drawing-guides.pptx")
try:
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    for index in range(guides.getCount()):
        guide = guides.get_Item(index)
        print(f"Guide {index}: orientation = {guide.getOrientation()}, position = {guide.getPosition()}, color = {guide.getColor()}")
finally:
    presentation.dispose()
```

## **إضافة الأدلة إلى القالب والشرائح التخطيطية**

يمكن لقالب الشريحة وكل من شرائحه التخطيطية أن يمتلك مجموعات دلائل رسمية خاصة به. استخدم [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslide/#getDrawingGuides) للقالب و [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutslide/#getDrawingGuides) للشرائح التخطيطية.

المثال التالي يضيف دليلًا عموديًا إلى أول شريحة قالب ودليلًا أفقيًا إلى أول شريحة تخطيط:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    master_guides = presentation.getMasters().get_Item(0).getDrawingGuides()
    layout_guides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides()

    master_guides.add(Orientation.Vertical, slide_size.getWidth() / 2 - 20)
    layout_guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **إضافة الأدلة إلى قوالب الملاحظات والنشرات**

قوالب الملاحظات وقوالب النشرات تدعم أيضًا الأدلة الرسمية. استخدم [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masternotesslide/#getDrawingGuides) و [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterhandoutslide/#getDrawingGuides) للوصول إلى مجموعاتهم. إذا لم يحتوي العرض التقديمي على أحد هذه القوالب، فإن `MasterNotesSlideManager.setDefaultMasterNotesSlide` أو `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` ينشئ القالب الافتراضي ويعيده.

المثال التالي يضيف دليلًا أفقيًا إلى قالب ملاحظات ودليلًا عموديًا إلى قالب نشرة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    notes_size = presentation.getNotesSize().getSize()
    notes_master = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide()
    handout_master = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    notes_master.getDrawingGuides().add(Orientation.Horizontal, notes_size.getHeight() / 2 + 50)
    handout_master.getDrawingGuides().add(Orientation.Vertical, notes_size.getWidth() / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **مسح الأدلة الرسمية**

استدعِ [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/ar/python-java/aspose.slides/drawingguidescollection/#clear) لإزالة جميع الأدلة من مجموعة معينة. مسح مجموعة واحدة لا يؤثر على الأدلة المخزنة في نطاق آخر.

المثال التالي يمسح أدلة عرض الشريحة وجميع الأدلة على قوالب الشرائح، الشرائح التخطيطية، قالب الملاحظات، وقالب النشرة دون إنشاء القوالب المفقودة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation-with-guides.pptx")
try:
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear()

    for master_slide in presentation.getMasters():
        master_slide.getDrawingGuides().clear()

    for layout_slide in presentation.getLayoutSlides():
        layout_slide.getDrawingGuides().clear()

    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()
    if notes_master is not None:
        notes_master.getDrawingGuides().clear()

    handout_master = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()
    if handout_master is not None:
        handout_master.getDrawingGuides().clear()

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**هل تظهر الأدلة الرسمية في عرض الشرائح أو الصور المُصدَّرة؟**

لا. الأدلة الرسمية هي أدوات محاذاة للتحرير ولا تُظهر كجزء من محتوى العرض.

**هل يمكن إضافة دليل رسمية مباشرة إلى شريحة عادية فردية؟**

يتم تخزين أدلة تحرير الشرائح العادية في خصائص عرض الشرائح الخاصة بالعرض التقديمي. تتوفر مجموعات أدلة منفصلة لقوالب الشرائح، الشرائح التخطيطية، قوالب الملاحظات، وقوالب النشرات.

**ما هي الوحدات المستخدمة لمواقع الأدلة؟**

تُحدد المواقع بالنقاط، حيث 72 نقطة تساوي بوصة واحدة. تُقاس المواقع العمودية من الحد الأيسر، وتُقاس المواقع الأفقية من الحد العلوي.

**هل يؤدي مسح الأدلة الرسمية إلى إزالة الأشكال أو تعديل محتوى الشريحة؟**

لا. طريقة [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/ar/python-java/aspose.slides/drawingguidescollection/#clear) تزيل فقط الأدلة في المجموعة المختارة. تبقى الأشكال وغيرها من محتوى الشريحة دون تغيير.