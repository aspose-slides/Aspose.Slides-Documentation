---
title: Manage SmartArt in PowerPoint Presentations Using Python
linktitle: Manage SmartArt
type: docs
weight: 10
url: /ar/python-net/developer-guide/presentation-content/powerpoint-smartart/manage-smartart/
keywords:
- SmartArt
- text from SmartArt
- layout type
- hidden property
- organization chart
- picture organization chart
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Learn to build and edit PowerPoint SmartArt with Aspose.Slides for Python via .NET using clear code samples that speed up slide design and automation."
---

## **نظرة عامة**

هذا الدليل يوضح كيفية إنشاء وتعديل SmartArt في Aspose.Slides لـ Python. ستتعلم كيفية استخراج النص من SmartArt (بما في ذلك محتوى [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) داخل أشكال العقد)، إضافة SmartArt إلى الشرائح وتغيير تخطيطه، اكتشاف ومعالجة العقد المخفية، تكوين تخطيطات مخطط المؤسسة، وإنشاء مخططات مؤسسة بصورة—كل ذلك باستخدام أمثلة Python مختصرة يمكن نسخها ولصقها تفتح [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)، وتعمل مع الشرائح وعقد SmartArt، وتحفظ النتائج إلى PPTX. 

## **الحصول على النص من SmartArt**

تسمح خاصية `text_frame` في [SmartArtShape](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/) باسترجاع كل النص من شكل SmartArt—not فقط النص الموجود داخل عقده. يُظهر الكود التالي كيفية الحصول على النص من عقدة SmartArt.

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

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع إلى شريحة بحسب فهرسها.
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

ترجع الخاصية `SmartArtNode.is_hidden` القيمة `True` إذا كانت العقدة مخفية في نموذج البيانات. للتحقق مما إذا كانت عقدة SmartArt مخفية، اتبع الخطوات التالية:

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
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
        print("The node is hidden.")  # النص هنا يبقى بالإنجليزية لتطابق المثال
```

## **الحصول على أو تعيين نوع مخطط المؤسسة**

ترجع أو تعيّن الخاصية `SmartArtNode.organization_chart_layout` نوع مخطط المؤسسة المرتبط بالعقدة الحالية. للحصول أو لتعيين نوع مخطط المؤسسة، اتبع الخطوات التالية:

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. أضف شكل SmartArt إلى الشريحة.
1. احصل على أو عيّن نوع مخطط المؤسسة.
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

## **إنشاء مخطط مؤسسة بصورة**

توفر Aspose.Slides لـ Python واجهة برمجة تطبيقات بسيطة لإنشاء مخططات مؤسسة بصورة بسهولة. لإنشاء مخطط على شريحة:

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع إلى الشريحة بحسب فهرسها.
1. أضف مخططًا من النوع المطلوب ببيانات افتراضية.
1. احفظ العرض التقديمي المعدل كملف PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)
    
    presentation.save("OrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**هل يدعم SmartArt المرآة/العكس للغات من اليمين إلى اليسار؟**

نعم. الخاصية [is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) تعكس اتجاه المخطط (LTR/RTL) إذا كان نوع SmartArt المختار يدعم العكس.

**كيف يمكنني نسخ SmartArt إلى نفس الشريحة أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**

يمكنك [استنساخ شكل SmartArt](/slides/ar/python-net/shape-manipulations/) عبر مجموعة الأشكال ([ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/)) أو [استنساخ الشريحة بالكامل](/slides/ar/python-net/clone-slides/) التي تحتوي على هذا الشكل. كلا الطريقتين تحافظان على الحجم، الموقع، والتنسيق.

**كيف أقوم بتحويل SmartArt إلى صورة نقطية للمعاينة أو للتصدير إلى الويب؟**

[قم بتحويل الشريحة](/slides/ar/python-net/convert-powerpoint-to-png/) (أو العرض التقديمي بأكمله) إلى PNG/JPEG عبر الواجهة التي تحول الشرائح/العروض إلى صور—سيتم رسم SmartArt كجزء من الشريحة.

**كيف يمكنني اختيار SmartArt محدد برمجيًا على شريحة إذا كان هناك عدة أشكال؟**

الممارسة الشائعة هي استخدام [النص البديل](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/alternative_text/) (Alt Text) أو [الاسم](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/name/) والبحث عن الشكل بواسطة هذه السمة داخل [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/)، ثم التحقق من النوع للتأكد أنه [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/). الوثائق تصف تقنيات شائعة للعثور على الأشكال والعمل معها.