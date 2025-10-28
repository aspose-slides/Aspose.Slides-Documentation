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
- مخطط تنظيمي
- مخطط تنظيمي بالصورة
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إنشاء وتحرير SmartArt في PowerPoint باستخدام Aspose.Slides for Python عبر .NET باستخدام أمثلة شفرة واضحة تُسرّع تصميم الشرائح والأتمتة."
---

## **نظرة عامة**

يظهر هذا الدليل كيفية إنشاء ومعالجة SmartArt في Aspose.Slides for Python. ستتعلم كيفية استخراج النص من SmartArt (بما في ذلك محتوى [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) داخل أشكال العقد)، إضافة SmartArt إلى الشرائح وتغيير تخطيطه، اكتشاف ومعالجة العقد المخفية، تكوين تخطيطات المخططات التنظيمية، وإنشاء مخططات تنظيمية بصور—كل ذلك باستخدام أمثلة Python مختصرة يمكن نسخه ولصقه لفتح [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)، والعمل مع الشرائح وعقد SmartArt، وحفظ النتائج إلى PPTX. 

## **استخراج النص من SmartArt**

تسمح لك الخاصية `text_frame` في [SmartArtShape](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/) باسترجاع جميع النصوص من شكل SmartArt—not فقط النص الموجود في عقده. يوضح الكود التالي كيفية الحصول على النص من عقدة SmartArt.

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

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع إلى شريحة بواسطة فهرسها.
1. أضف شكل SmartArt باستخدام تخطيط `BASIC_BLOCK_LIST`.
1. غيّر تخطيطه إلى `BASIC_PROCESS`.
1. احفظ العرض التقديمي كملف PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add a SmartArt shape with the BASIC_BLOCK_LIST layout.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    # Change the layout type to BASIC_PROCESS.
    smart.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    # Save the presentation.
    presentation.save("ChangedSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **التحقق من الخاصية المخفية لـ SmartArt**

تُعيد الخاصية `SmartArtNode.is_hidden` القيمة `True` إذا كانت العقدة مخفية في نموذج البيانات. للتحقق مما إذا كانت عقدة SmartArt مخفية، اتبع الخطوات التالية:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. أضف شكل SmartArt باستخدام تخطيط `RADIAL_CYCLE`.
1. أضف عقدة إلى SmartArt.
1. تحقق من الخاصية `is_hidden`.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add a SmartArt shape with the RADIAL_CYCLE layout.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    # Add a node to the SmartArt.
    node = smart.all_nodes.add_node()

    # Check the is_hidden property.
    if node.is_hidden:
        print("The node is hidden.")
```

## **الحصول على نوع مخطط تنظيمي أو تعيينه**

تُتيح الخاصية `SmartArtNode.organization_chart_layout` الحصول على أو تعيين نوع المخطط التنظيمي المرتبط بالعقدة الحالية. للحصول على أو تعيين نوع المخطط التنظيمي، اتبع الخطوات التالية:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. أضف شكل SmartArt إلى الشريحة.
1. احصل على أو عيّن نوع المخطط التنظيمي.
1. احفظ العرض التقديمي كملف PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add a SmartArt shape with the ORGANIZATION_CHART layout.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    # Set the organization chart type.
    smart.nodes[0].organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    # Save the presentation.
    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **إنشاء مخطط تنظيمي بصورة**

توفر Aspose.Slides for Python واجهة برمجة تطبيقات بسيطة لإنشاء مخططات تنظيمية بصور بسهولة. لإنشاء مخطط على شريحة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع إلى الشريحة بواسطة فهرسها.
1. أضف مخططًا بالبيانات الافتراضية من النوع المطلوب.
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

**هل يدعم SmartArt الانعكاس/العكس للغات من اليمين إلى اليسار؟**

نعم. الخاصية [is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) تغير اتجاه المخطط (LTR/RTL) إذا كان نوع SmartArt المختار يدعم العكس.

**كيف يمكنني نسخ SmartArt إلى نفس الشريحة أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**

يمكنك [نسخ شكل SmartArt](/slides/ar/python-net/shape-manipulations/) عبر مجموعة الأشكال ([ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/)) أو [نسخ الشريحة بالكامل](/slides/ar/python-net/clone-slides/) التي تحتوي على هذا الشكل. كلا الأسلوبين يحافظان على الحجم والموقع والأسلوب.

**كيف أقوم بتحويل SmartArt إلى صورة نقطية للمعاينة أو لتصدير الويب؟**

[حوّل الشريحة](/slides/ar/python-net/convert-powerpoint-to-png/) (أو العرض الكامل) إلى PNG/JPEG عبر الواجهة التي تحول الشرائح/العروض إلى صور—سيتم رسم SmartArt كجزء من الشريحة.

**كيف يمكنني برمجيًا اختيار SmartArt معين على شريحة إذا كان هناك عدة أشكال؟**

الممارسة الشائعة هي استخدام [النص البديل](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/alternative_text/) (Alt Text) أو [الاسم](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/name/) والبحث عن الشكل عبر تلك الصفة داخل [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/)، ثم التحقق من النوع للتأكد أنه [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/). الوثائق تصف التقنيات المعتادة للعثور على الأشكال والعمل معها.