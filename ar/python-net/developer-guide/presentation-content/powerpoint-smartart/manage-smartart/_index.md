---
title: إدارة SmartArt في عروض PowerPoint التقديمية باستخدام Python
linktitle: إدارة SmartArt
type: docs
weight: 10
url: /ar/python-net/manage-smartart/
keywords:
- SmartArt
- نص من SmartArt
- نوع التخطيط
- الخاصية المخفية
- مخطط تنظيمي
- مخطط تنظيمي بصري
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إنشاء وتعديل SmartArt في PowerPoint باستخدام Aspose.Slides for Python عبر .NET باستخدام أمثلة شفرة واضحة تسرّع تصميم الشرائح والأتمتة."
---

## **نظرة عامة**

يوضح هذا الدليل كيفية إنشاء ومعالجة SmartArt في Aspose.Slides للغة Python. ستتعلم كيفية استخراج النص من SmartArt (بما في ذلك محتوى [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) داخل أشكال العقد)، إضافة SmartArt إلى الشرائح وتبديل تخطيطه، اكتشاف ومعالجة العقد المخفية، تكوين تخطيطات مخططات التنظيم، وإنشاء مخططات تنظيمية بالصور — كل ذلك باستخدام أمثلة Python مختصرة قابلة للنسخ واللصق التي تفتح [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)، وتعمل مع الشرائح وعقد SmartArt، وتحفظ النتائج كملف PPTX. 

## **الحصول على النص من SmartArt**

تتيح خاصية `text_frame` في [SmartArtShape](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/) استرجاع جميع النصوص من شكل SmartArt — ليس فقط النص الموجود في عقده. يوضح الكود النموذجي التالي كيفية الحصول على النص من عقدة SmartArt.
```py
import aspose.slides as slides

with slides.Presentation("SmartArt.pptx") as presentation:
    slide = presentation.slides[0]
    smart_art = slide.shapes[0]

    for smart_art_node in smart_art.all_nodes:
        for node_shape in smart_art_node.shapes:
            if node_shape.text_frame is not None:
                print(node_shape.text_frame.text)
```


## **تغيير نوع تخطيط SmartArt**

لتغيير نوع تخطيط SmartArt، اتبع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى شريحة بحسب فهرستها.
3. إضافة شكل SmartArt باستخدام تخطيط `BASIC_BLOCK_LIST`.
4. تغيير تخطيطه إلى `BASIC_PROCESS`.
5. حفظ العرض التقديمي كملف PPTX.
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # أضف شكل SmartArt باستخدام تخطيط BASIC_BLOCK_LIST.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    # غيّر نوع التخطيط إلى BASIC_PROCESS.
    smart.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    # احفظ العرض التقديمي.
    presentation.save("ChangedSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```


## **التحقق من الخاصية المخفية لـ SmartArt**

تُعيد الخاصية `SmartArtNode.is_hidden` القيمة `True` إذا كانت العقدة مخفية في نموذج البيانات. للتحقق مما إذا كانت عقدة SmartArt مخفية، اتبع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. إضافة شكل SmartArt باستخدام تخطيط `RADIAL_CYCLE`.
3. إضافة عقدة إلى SmartArt.
4. التحقق من الخاصية `is_hidden`.
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # أضف شكل SmartArt باستخدام تخطيط RADIAL_CYCLE.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    # أضف عقدة إلى SmartArt.
    node = smart.all_nodes.add_node()

    # تحقق من خاصية is_hidden.
    if node.is_hidden:
        print("The node is hidden.")
```


## **الحصول على أو تعيين نوع مخطط التنظيم**

تُتيح الخاصية `SmartArtNode.organization_chart_layout` الحصول على أو تعيين نوع مخطط التنظيم المرتبط بالعقدة الحالية. للحصول على أو تعيين نوع مخطط التنظيم، اتبع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. إضافة شكل SmartArt إلى الشريحة.
3. الحصول على نوع مخطط التنظيم أو تعيينه.
4. حفظ العرض التقديمي كملف PPTX.
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # أضف شكلاً SmartArt باستخدام تخطيط ORGANIZATION_CHART.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    # عيّن نوع مخطط التنظيم.
    smart.nodes[0].organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    # احفظ العرض التقديمي.
    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```


## **إنشاء مخطط تنظيم بصري**

توفر Aspose.Slides للغة Python واجهة برمجة تطبيقات بسيطة لإنشاء مخططات تنظيم بصري بسهولة. لإنشاء مخطط على شريحة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة بحسب فهرستها.
3. إضافة مخطط ببيانات افتراضية من النوع المطلوب.
4. حفظ العرض التقديمي المعدل كملف PPTX.
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)
    
    presentation.save("OrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة الشائعة**

**هل يدعم SmartArt عكس/انعكاس للغات من اليمين إلى اليسار؟**

نعم. خاصية [is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) تغير اتجاه المخطط (من اليسار إلى اليمين / من اليمين إلى اليسار) إذا كان نوع SmartArt المختار يدعم العكس.

**كيف يمكنني نسخ SmartArt إلى نفس الشريحة أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**

يمكنك [clone the SmartArt shape](/slides/ar/python-net/shape-manipulations/) عبر مجموعة الأشكال ([ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/)) أو [clone the entire slide](/slides/ar/python-net/clone-slides/) التي تحتوي على هذا الشكل. كلا النهجين يحافظان على الحجم والموضع والتنسيق.

**كيف يمكنني تصيير SmartArt كصورة نقطية للمعاينة أو لتصدير ويب؟**

[Render the slide](/slides/ar/python-net/convert-powerpoint-to-png/) (أو العرض التقديمي بالكامل) إلى PNG/JPEG عبر API الذي يحول الشرائح/العروض التقديمية إلى صور — سيتم رسم SmartArt كجزء من الشريحة.

**كيف يمكنني برمجيًا اختيار SmartArt محدد على شريحة إذا كان هناك عدة؟**

ممارسة شائعة هي استخدام [alternative text](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/alternative_text/) (نص بديل) أو [name](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/name/) والبحث عن الشكل عبر تلك السمة داخل [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/)، ثم التحقق من النوع لتأكيد أنه [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/). الوثائق تصف التقنيات النموذجية للعثور على الأشكال والعمل معها.