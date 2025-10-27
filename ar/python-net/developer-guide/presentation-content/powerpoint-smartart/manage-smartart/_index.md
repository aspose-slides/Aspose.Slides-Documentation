---
title: إدارة SmartArt في عروض PowerPoint باستخدام Python
linktitle: إدارة SmartArt
type: docs
weight: 10
url: /ar/python-net/manage-smartart/
keywords:
- SmartArt
- النص من SmartArt
- نوع التخطيط
- الخاصية المخفية
- مخطط المؤسسة
- مخطط المؤسسة بالصور
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إنشاء وتعديل SmartArt في PowerPoint باستخدام Aspose.Slides للـ Python عبر .NET مع أمثلة شفرة واضحة تُسرّع تصميم الشرائح والأتمتة."
---

## **نظرة عامة**

يُظهر هذا الدليل كيفية إنشاء ومعالجة SmartArt في Aspose.Slides للـ Python. ستتعلم كيفية استخراج النص من SmartArt (بما في ذلك محتوى [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) داخل أشكال العقد)، إضافة SmartArt إلى الشرائح وتغيير تخطيطه، اكتشاف ومعالجة العقد المخفية، تكوين تخطيطات مخطط المؤسسة، وإنشاء مخططات مؤسسة بالصور—كل ذلك بأمثلة Python مختصرة قابلة للنسخ واللصق تفتح [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)، تتعامل مع الشرائح وعقد SmartArt، وتحفظ النتائج كملف PPTX.

## **استخراج النص من SmartArt**

خاصية `text_frame` في [SmartArtShape](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/) تتيح لك استرجاع كل النص من شكل SmartArt—not فقط النص الموجود داخل عقده. يوضح الكود التالي كيفية الحصول على النص من عقدة SmartArt.

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

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع إلى شريحة حسب فهرستها.
1. أضف شكل SmartArt باستخدام تخطيط `BASIC_BLOCK_LIST`.
1. غيّر تخطيطه إلى `BASIC_PROCESS`.
1. احفظ العرض كملف PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # أضف شكل SmartArt بتخطيط BASIC_BLOCK_LIST.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    # غيّر نوع التخطيط إلى BASIC_PROCESS.
    smart.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    # احفظ العرض.
    presentation.save("ChangedSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **التحقق من الخاصية المخفية لـ SmartArt**

خاصية `SmartArtNode.is_hidden` تُعيد `True` إذا كانت العقدة مخفية في نموذج البيانات. للتحقق مما إذا كانت عقدة SmartArt مخفية، اتبع الخطوات التالية:

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. أضف شكل SmartArt باستخدام تخطيط `RADIAL_CYCLE`.
1. أضف عقدة إلى SmartArt.
1. تحقق من خاصية `is_hidden`.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # أضف شكل SmartArt بتخطيط RADIAL_CYCLE.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    # أضف عقدة إلى SmartArt.
    node = smart.all_nodes.add_node()

    # تحقق من خاصية is_hidden.
    if node.is_hidden:
        print("The node is hidden.")
```

## **الحصول على نوع مخطط المؤسسة أو تعيينه**

خاصية `SmartArtNode.organization_chart_layout` تُستَخدم للحصول على أو تعيين نوع مخطط المؤسسة المرتبط بالعقدة الحالية. للحصول على أو تعيين نوع مخطط المؤسسة، اتبع الخطوات التالية:

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. أضف شكل SmartArt إلى الشريحة.
1. احصل على أو عيّن نوع مخطط المؤسسة.
1. احفظ العرض كملف PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # أضف شكل SmartArt بتخطيط ORGANIZATION_CHART.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    # عيّن نوع مخطط المؤسسة.
    smart.nodes[0].organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    # احفظ العرض.
    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **إنشاء مخطط مؤسسة بالصور**

توفر Aspose.Slides للـ Python واجهة برمجة تطبيقات بسيطة لإنشاء مخططات مؤسسة بالصور بسهولة. لإنشاء مخطط على شريحة:

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع إلى الشريحة حسب فهرستها.
1. أضف مخططًا بالبيانات الافتراضية للنوع المطلوب.
1. احفظ العرض المعدل كملف PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)
    
    presentation.save("OrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

**هل يدعم SmartArt الانعكاس/العكس للغات RTL؟**

نعم. خاصية [is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) تُغيّر اتجاه المخطط (LTR/RTL) إذا كان نوع SmartArt المحدد يدعم العكس.

**كيف يمكنني نسخ SmartArt إلى نفس الشريحة أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**

يمكنك [استنساخ شكل SmartArt](/slides/ar/python-net/shape-manipulations/) عبر مجموعة الأشكال ([ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/)) أو [استنساخ الشريحة بأكملها](/slides/ar/python-net/clone-slides/) التي تحتوي على هذا الشكل. كلا الأسلوبين يحافظان على الحجم والموقع والتنسيق.

**كيف يمكنني عرض SmartArt كصورة نقطية للمعاينة أو التصدير إلى الويب؟**

[قم بتحويل الشريحة](/slides/ar/python-net/convert-powerpoint-to-png/) (أو العرض بالكامل) إلى PNG/JPEG عبر API الذي يحول الشرائح/العروض إلى صور—سيتم رسم SmartArt كجزء من الشريحة.

**كيف يمكنني اختيار SmartArt معين برمجيًا إذا كان هناك عدة أشكال؟**

الممارسة الشائعة هي استخدام [النص البديل](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/alternative_text/) (Alt Text) أو [الاسم](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/name/) والبحث عن الشكل بواسطة تلك السمة ضمن [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/)، ثم التحقق من النوع للتأكد من أنه [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/). يصف المستند التقنيات الشائعة للعثور على الأشكال والعمل معها.