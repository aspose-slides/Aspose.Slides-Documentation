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
- مخطط المؤسسة بالصورة
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إنشاء وتعديل SmartArt في PowerPoint باستخدام Aspose.Slides للـ Python عبر .NET مع أمثلة شفرة واضحة تسرّع تصميم الشرائح والأتمتة."
---

## **نظرة عامة**

هذا الدليل يوضح كيفية إنشاء ومعالجة SmartArt في Aspose.Slides للـ Python. ستتعلم كيفية استخراج النص من SmartArt (بما في ذلك محتوى [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) داخل أشكال العقد)، إضافة SmartArt إلى الشرائح وتغيير تخطيطه، الكشف عن العقد المخفية ومعالجتها، تكوين تخطيطات مخطط المؤسسة، وإنشاء مخططات مؤسسة بالصورة—كل ذلك بأمثلة Python مختصرة قابلة للنسخ واللصق تفتح [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)، تتعامل مع الشرائح وعقد SmartArt، وتحفظ النتائج إلى PPTX. 

## **استخراج النص من SmartArt**

خاصية `text_frame` لـ [SmartArtShape](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/) تتيح لك استرجاع جميع النصوص من شكل SmartArt—not فقط النص الموجود في عقده. يظهر المثال التالي كيفية الحصول على النص من عقدة SmartArt.

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
1. الحصول على مرجع إلى شريحة بحسب الفهرس.
1. إضافة شكل SmartArt بتخطيط `BASIC_BLOCK_LIST`.
1. تغيير تخطيطه إلى `BASIC_PROCESS`.
1. حفظ العرض التقديمي كملف PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # إضافة شكل SmartArt بتخطيط BASIC_BLOCK_LIST.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    # تغيير نوع التخطيط إلى BASIC_PROCESS.
    smart.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    # حفظ العرض التقديمي.
    presentation.save("ChangedSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **التحقق من الخاصية المخفية لـ SmartArt**

خاصية `SmartArtNode.is_hidden` تعيد `True` إذا كانت العقدة مخفية في نموذج البيانات. للتحقق مما إذا كانت عقدة SmartArt مخفية، اتبع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. إضافة شكل SmartArt بتخطيط `RADIAL_CYCLE`.
1. إضافة عقدة إلى SmartArt.
1. فحص خاصية `is_hidden`.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # إضافة شكل SmartArt بتخطيط RADIAL_CYCLE.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    # إضافة عقدة إلى SmartArt.
    node = smart.all_nodes.add_node()

    # فحص الخاصية is_hidden.
    if node.is_hidden:
        print("The node is hidden.")
```

## **الحصول على نوع مخطط المؤسسة أو تعيينه**

خاصية `SmartArtNode.organization_chart_layout` تحصل أو تضبط نوع مخطط المؤسسة المرتبط بالعقدة الحالية. للحصول على أو ضبط نوع مخطط المؤسسة، اتبع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. إضافة شكل SmartArt إلى الشريحة.
1. الحصول على أو ضبط نوع مخطط المؤسسة.
1. حفظ العرض التقديمي كملف PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # إضافة شكل SmartArt بتخطيط ORGANIZATION_CHART.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    # ضبط نوع مخطط المؤسسة.
    smart.nodes[0].organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    # حفظ العرض التقديمي.
    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **إنشاء مخطط مؤسسة بالصورة**

توفر Aspose.Slides للـ Python واجهة برمجة تطبيقات بسيطة لإنشاء مخططات مؤسسة بالصورة بسهولة. لإنشاء مخطط على شريحة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع إلى الشريحة بحسب الفهرس.
1. إضافة مخطط بالصورة بالنوع المطلوب والبيانات الافتراضية.
1. حفظ العرض التقديمي المعدل كملف PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)
    
    presentation.save("OrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**هل يدعم SmartArt عكس الاتجاه للغات RTL؟**

نعم. خاصية [is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) تعكس اتجاه المخطط (LTR/RTL) إذا كان نوع SmartArt المحدد يدعم العكس.

**كيف يمكنني نسخ SmartArt إلى نفس الشريحة أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**

يمكنك [نسخ شكل SmartArt](/slides/ar/python-net/shape-manipulations/) عبر مجموعة الأشكال ([ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/)) أو [نسخ الشريحة بالكامل](/slides/ar/python-net/clone-slides/) التي تحتوي على هذا الشكل. كلا الطريقتين تحافظان على الحجم والموقع والتنسيق.

**كيف يمكنني تحويل SmartArt إلى صورة نقطية للمعاينة أو تصدير الويب؟**

[قم بتحويل الشريحة](/slides/ar/python-net/convert-powerpoint-to-png/) (أو العرض التقديمي كاملًا) إلى PNG/JPEG عبر API التي تحول الشرائح/العروض إلى صور—سيتم رسم SmartArt كجزء من الشريحة.

**كيف يمكنني برمجيًا اختيار SmartArt معين على شريحة إذا كان هناك عدة أشكال؟**

ممارسة شائعة هي استخدام [النص البديل](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/alternative_text/) (Alt Text) أو [الاسم](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/name/) والبحث عن الشكل بواسطة تلك السمة داخل [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/)، ثم فحص النوع للتأكد من أنه [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/). الوثائق توضح تقنيات شائعة للعثور على الأشكال والعمل معها.