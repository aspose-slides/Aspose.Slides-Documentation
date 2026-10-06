---
title: إدارة SmartArt في عروض PowerPoint التقديمية باستخدام Python
linktitle: إدارة SmartArt
type: docs
weight: 10
url: /ar/python-net/manage-smartart/
keywords:
- SmartArt
- نص SmartArt
- نوع التخطيط
- خاصية مخفية
- مخطط المؤسسة
- مخطط المؤسسة بالصورة
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية بناء وتعديل SmartArt في PowerPoint باستخدام Aspose.Slides for Python عبر .NET مع أمثلة شفرة واضحة تسرّع تصميم الشرائح والأتمتة."
---
## **نظرة عامة**

SmartArt هو مخطط PowerPoint مكوّن من العقد وأشكال العقد وتخطيط. باستخدام Aspose.Slides for Python عبر .NET، يمكنك إنشاء SmartArt، قراءة النص من عقده، تغيير تخطيطه، فحص العقد المخفية، تكوين تخطيطات مخطط المؤسسة، وإنشاء مخططات تنظيمية بالصور.

## **الحصول على نص من كائن SmartArt**

يمكن أن يحتوي عقدة SmartArt على شكل أو أكثر. لقراءة النص من أشكال العقد، قم بالتكرار عبر [SmartArt.all_nodes](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/all_nodes/)، ثم اقرأ [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) الذي تُعيده [SmartArtShape.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/text_frame/).

تتطلب الأمثلة عرضًا تقديميًا يحتوي على شريحة واحدة على الأقل وكائن SmartArt كشكل أول على تلك الشريحة. تُطبع كل إطار نص متاح إلى وحدة التحكم.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        for node in shape.all_nodes:
            for node_shape in node.shapes:
                if node_shape.text_frame is not None:
                    print(node_shape.text_frame.text)
```

## **تغيير نوع التخطيط لكائن SmartArt**

يتحكم تخطيط SmartArt في كيفية ترتيب العقد وربطها. تُنشئ المثال التالي كائن SmartArt باستخدام قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST`، وتغيّرها إلى القيمة `BASIC_PROCESS`، ثم تُحفظ العرض التقديمي. يتم قياس الموضع والحجم المُمرّر إلى [ShapeCollection.add_smart_art](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_smart_art/) بالنقاط. اضبط [SmartArt.layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/layout/) لتغيير التخطيط.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **التحقق مما إذا كانت عقدة SmartArt مخفية**

تشير [SmartArtNode.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/is_hidden/) إلى ما إذا كانت العقدة مخفية في نموذج بيانات SmartArt. يمكن أن تكون العقد المخفية موجودة في الهيكل حتى عندما لا يُظهر التخطيط المحدد لها كعناصر مخطط مرئية.

تضيف المثال التالي عقدة إلى كائن SmartArt يستخدم قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` وتتحقق من حالة الإخفاء للعقدة المُضافة. تُطبع رسالة إذا كانت العقدة مخفية وتُحفظ المخطط.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)
    node = smart_art.all_nodes.add_node()
    is_hidden = node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", slides.export.SaveFormat.PPTX)
```

## **الحصول على تخطيط مخطط المؤسسة أو تعيينه**

بالنسبة لمخططات SmartArt التي تستخدم تخطيط مخطط المؤسسة، تُحدّد [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) كيفية ترتيب العقد الفرعية تحت عقدة أصلية. على سبيل المثال، يمكنك ضبط العقد الفرعية لتعلق من اليسار أو اليمين أو كلا الجانبين، اعتمادًا على [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) المحدد.

تنشئ المثال التالي مخطط مؤسسة وتضبط التخطيط للعقدة الأولى إلى قيمة [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING`. يُحدد الفهرس الصفري `0` العقدة العليا الأولى؛ وتُستخدم العقد الفرعية الترتيب المحدد. ثم يُحفظ العرض التقديمي المعدل.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)
    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **إنشاء مخطط مؤسسة بصورة**

مخطط المؤسسة بالصورة هو تخطيط SmartArt مُصمَّم لمخططات الهرمية التي تتضمن مواضع للصور. استخدم قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` عند إضافة كائن SmartArt إلى شريحة. يحفظ هذا المثال مخططًا يحتوي على مواضع للصور؛ لكنه لا يُملئ تلك المواضع بالصور.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **تحويل المخططات القديمة إلى مجموعات من الأشكال**

عند تحديث عرض تقديمي موجود، قد تحتاج إلى تحديث مخطط مؤسسة تم إنشاؤه أصلاً في PowerPoint 97–2003. تمثّل Aspose.Slides هذه المخططات القديمة ككائنات [LegacyDiagram](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/). استخدم [LegacyDiagram.convert_to_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/convert_to_group_shape/) لتحويل مخطط إلى مجموعة من الأشكال بحيث يمكنك تعديل العناصر البصرية الفردية. راجع [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/) للحصول على التفاصيل.

تضيف عملية التحويل مجموعة جديدة إلى مجموعة الأشكال دون إزالة المخطط الأصلي. بعد التحويل الناجح، أزل الأصلي باستخدام [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) لتجنّب المحتوى المكرر. اجمع المخططات القديمة في قائمة قبل تحويلها بحيث لا يتعطّل التكرار عند إضافة وإزالة الأشكال.

يفتح المثال التالي عرضًا تقديميًا، يبحث في كل شريحة، يحوّل المخططات إلى مجموعات من الأشكال، ثم يحفظ العرض التقديمي المحدث بصيغة PPTX.

```python
import aspose.slides as slides

with slides.Presentation("legacy-diagrams.ppt") as presentation:
    for slide in presentation.slides:
        legacy_diagrams = [shape for shape in slide.shapes if isinstance(shape, slides.LegacyDiagram)]
        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convert_to_group_shape()

            if group_shape is not None:
                slide.shapes.remove(legacy_diagram)

    presentation.save("modernized.pptx", slides.export.SaveFormat.PPTX)
```

يحتوي العرض التقديمي المحفوظ على مجموعات قابلة للتحرير من الأشكال مكان المخططات القديمة التي تم تحويلها، دون ترك أي مخططات أصلية بجانبها. افتح ملف PPTX في PowerPoint لتحرير العناصر الفردية داخل كل مجموعة، مثل النص أو التعبئة أو الموضع.

## **الأسئلة المتكررة**

**هل يدعم SmartArt العكس أو الانعكاس للغات RTL؟**

نعم. تقوم الخاصية [SmartArt.is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) بتغيير اتجاه المخطط من اليسار إلى اليمين إلى اليمين إلى اليسار، أو العكس، عندما يدعم تخطيط SmartArt المختار العكس.

**كيف يمكنني نسخ SmartArt إلى الشريحة نفسها أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**

يمكنك [نسخ شكل SmartArt](/slides/ar/python-net/shape-manipulations/) باستخدام [ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/) أو [نسخ الشريحة بالكامل](/slides/ar/python-net/clone-slides/) التي تحتوي على SmartArt. كلا الطريقتين تحتفظ بالحجم والموضع والتنسيق.

**كيف أقوم بعرض SmartArt كصورة نقطية للمعاينة أو التصدير إلى الويب؟**

[اعرض الشريحة](/slides/ar/python-net/convert-powerpoint-to-png/) أو العرض التقديمي بالكامل إلى PNG أو JPEG. يتم عرض SmartArt كجزء من الشريحة.

**كيف يمكنني العثور على كائن SmartArt محدد في شريحة إذا كان هناك عدة كائنات؟**

حدد قيمة مميزة لـ [Shape.alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) أو [Shape.name](https://reference.aspose.com/slides/python-net/aspose.slides/shape/name/) على شكل SmartArt، وابحث عن تلك القيمة في [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/)، ثم تحقق من أن الشكل المطابق هو [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/).