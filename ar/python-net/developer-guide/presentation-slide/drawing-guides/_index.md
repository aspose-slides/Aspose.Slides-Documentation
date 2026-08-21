---
title: إدارة أدلة الرسم في العروض التقديمية باستخدام بايثون
linktitle: أدلة الرسم
type: docs
weight: 85
url: /ar/python-net/drawing-guides/
keywords:
- دليل الرسم
- دليل أفقي
- دليل عمودي
- دليل محاذاة
- عرض الشريحة
- الشريحة الرئيسية
- شريحة التخطيط
- قالب الملاحظات
- قالب النشرة
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إضافة، الوصول إلى، وإزالة أدلة الرسم الأفقية والعمودية في عروض PowerPoint التقديمية باستخدام Aspose.Slides لبايثون عبر .NET."
---
## **نظرة عامة**

دلالات الرسم هي خطوط أفقية وعمودية قابلة للتعديل تساعد المستخدمين على محاذاة الأشكال بشكل ثابت أثناء تحرير عرض تقديمي في PowerPoint. وهي مفيدة بشكل خاص عندما يولد تطبيق عرضًا تقديميًا سيتم تنقيحه يدويًا لاحقًا: يمكن للتطبيق حفظ نفس أدوات المحاذاة التي يجب على المؤلفين اتباعها عند إضافة المحتوى أو تحريكه.

دلالات الرسم هي أدوات تحرير، ليست محتوى الشريحة. لا تظهر في عرض الشرائح أو في المخرجات المُصوَّرة. Aspose.Slides for Python via .NET يُظهرها من خلال الواجهة [IDrawingGuidesCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/idrawingguidescollection/) . تمثَّل الدلالة بواسطة [IDrawingGuide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/idrawingguide/) وتحتوي على اتجاه وموقع ولون.

الموقع يُقاس بالنقاط من الزاوية العلوية اليسرى للشريحة أو القالب المناسب. يستخدم الدليل العمودي إحداثيًا أفقيًا، عادةً بين الصفر وعرض الشريحة. يستخدم الدليل الأفقي إحداثيًا عموديًا، عادةً بين الصفر وارتفاع الشريحة.

## **إضافة الدلالات إلى عرض الشريحة**

استخدم [ICommonSlideViewProperties.drawing_guides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/icommonslideviewproperties/drawing_guides/) لإدارة الدلالات المعروضة أثناء تحرير الشرائح العادية. استدعِ [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/ar/python-net/aspose.slides/idrawingguidescollection/add/) مع قيمة [Orientation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/orientation/) وموقع بالنقاط.

المثال التالي يضيف دليلًا عموديًا واحدًا إلى يمين مركز الشريحة ودليلًا أفقيًا أسفله:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 + 12.5)
    guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 12.5)

    presentation.save("drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى دلالات الرسم**

خاصية [IDrawingGuidesCollection.count](https://reference.aspose.com/slides/ar/python-net/aspose.slides/idrawingguidescollection/count/) والفهرس يوفّران إمكانية الوصول إلى الدلالات الموجودة. يمكن قراءة أو تعديل خصائص [IDrawingGuide.orientation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/idrawingguide/orientation/)، [IDrawingGuide.position](https://reference.aspose.com/slides/ar/python-net/aspose.slides/idrawingguide/position/)، و[IDrawingGuide.color](https://reference.aspose.com/slides/ar/python-net/aspose.slides/idrawingguide/color/).

المثال التالي يقرأ دلالات عرض الشريحة من العرض التقديمي الذي تم إنشاؤه أعلاه:

```py
import aspose.slides as slides

with slides.Presentation("drawing-guides.pptx") as presentation:
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    for index in range(guides.count):
        guide = guides[index]
        print(f"Guide {index}: orientation = {guide.orientation}, position = {guide.position}, color = {guide.color}")
```

## **إضافة الدلالات إلى الشرائح الرئيسية والفرعية**

يمكن للقالب الرئيسي لكل شريحة وفرع من شرائحه أن يمتلك مجموعة دلالات رسم خاصة به. استخدم [IMasterSlide.drawing_guides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imasterslide/drawing_guides/) للقالب الرئيسي و[ILayoutSlide.drawing_guides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ilayoutslide/drawing_guides/) لشريحة فرعية.

المثال التالي يضيف دليلًا عموديًا إلى أول شريحة رئيسية ودليلًا أفقيًا إلى أول شريحة فرعية:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    master_guides = presentation.masters[0].drawing_guides
    layout_guides = presentation.layout_slides[0].drawing_guides

    master_guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 - 20)
    layout_guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **إضافة الدلالات إلى القوالب الملاحظة وقوالب النشرات**

تدعم القوالب الملاحظة وقوالب النشرات أيضًا دلالات الرسم. استخدم [IMasterNotesSlide.drawing_guides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imasternotesslide/drawing_guides/) و[IMasterHandoutSlide.drawing_guides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imasterhandoutslide/drawing_guides/) للوصول إلى مجموعاتهما. إذا لم يحتوي العرض التقديمي على أحد هذه القوالب، فإن [IMasterNotesSlideManager.set_default_master_notes_slide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imasternotesslidemanager/set_default_master_notes_slide/) أو [IMasterHandoutSlideManager.set_default_master_handout_slide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) ينشئ القالب الافتراضي ويعيده.

المثال التالي يضيف دليلًا أفقيًا إلى قالب ملاحظات ودليلًا عموديًا إلى قالب نشرة:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    notes_size = presentation.notes_size.size
    notes_master = presentation.master_notes_slide_manager.set_default_master_notes_slide()
    handout_master = presentation.master_handout_slide_manager.set_default_master_handout_slide()

    notes_master.drawing_guides.add(slides.Orientation.HORIZONTAL, notes_size.height / 2 + 50)
    handout_master.drawing_guides.add(slides.Orientation.VERTICAL, notes_size.width / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **مسح دلالات الرسم**

استدعِ [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/ar/python-net/aspose.slides/idrawingguidescollection/clear/) لإزالة كل دليل من مجموعة معينة. مسح مجموعة واحدة لا يؤثر على الدلالات المخزنة في نطاق آخر.

المثال التالي يمسح دلالات عرض الشريحة وجميع الدلالات على القوالب الرئيسية، الشرائح الفرعية، قالب الملاحظات، وقالب النشرة دون إنشاء قوالب مفقودة:

```py
import aspose.slides as slides

with slides.Presentation("presentation-with-guides.pptx") as presentation:
    presentation.view_properties.slide_view_properties.drawing_guides.clear()

    for master_slide in presentation.masters:
        master_slide.drawing_guides.clear()

    for layout_slide in presentation.layout_slides:
        layout_slide.drawing_guides.clear()

    notes_master = presentation.master_notes_slide_manager.master_notes_slide
    if notes_master is not None:
        notes_master.drawing_guides.clear()

    handout_master = presentation.master_handout_slide_manager.master_handout_slide
    if handout_master is not None:
        handout_master.drawing_guides.clear()

    presentation.save("presentation-without-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**هل تظهر دلالات الرسم في عرض الشرائح أو الصور المصدَّرة؟**

لا. دلالات الرسم هي أدوات محاذاة للتحرير ولا تُعرض كمحتوى في العرض التقديمي.

**هل يمكن إضافة دليل رسم مباشرة إلى شريحة عادية واحدة؟**

دلالات تحرير الشرائح العادية تُخزن في خصائص عرض الشريحة الخاصة بالعرض التقديمي. تتوفر مجموعات دلالات منفصلة للقوالب الرئيسية، الشرائح الفرعية، القوالب الملاحظة، والقوالب النشرة.

**ما الوحدات المستخدمة لمواقع الدلالات؟**

المواقع تُحدَّد بالنقاط، حيث يساوي 72 نقطة بوصة واحدة. تُقاس المواقع العمودية من الحافة اليسرى، وتُقاس المواقع الأفقية من الحافة العلوية.

**هل مسح دلالات الرسم يزيل الأشكال أو يغيّر محتوى الشريحة؟**

لا. طريقة `clear` تزيل فقط الدلالات في المجموعة المختارة. تبقى الأشكال ومحتوى الشريحة الآخر دون تغيير.