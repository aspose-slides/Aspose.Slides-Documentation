---
title: إدارة SmartArt في عروض PowerPoint التقديمية باستخدام Python
linktitle: إدارة SmartArt
type: docs
weight: 10
url: /ar/python-net/manage-smartart/
keywords:
- SmartArt
- النص من SmartArt
- نوع التخطيط
- الخاصية المخفية
- مخطط التنظيم
- مخطط تنظيم بالصور
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إنشاء وتعديل SmartArt في PowerPoint باستخدام Aspose.Slides لـ Python عبر .NET باستخدام أمثلة شفرة واضحة تسرّع تصميم الشرائح والأتمتة."
---
## **نظرة عامة**

SmartArt هو مخطط PowerPoint مكوّن من العقد وأشكال العقد وتخطيط. باستخدام Aspose.Slides لـ Python عبر .NET، يمكنك إنشاء SmartArt، قراءة النص من عقده، تعديل التخطيط، فحص العقد المخفية، تكوين تخطيطات مخططات التنظيم، وإنشاء مخططات تنظيمية بالصور.

## **استخراج النص من كائن SmartArt**

يمكن لعقدة SmartArt أن تحتوي على شكل واحد أو أكثر. لقراءة النص الظاهر، قم بالتكرار عبر [SmartArt.all_nodes](https://reference.aspose.com/slides/ar/python-net/aspose.slides.smartart/smartart/all_nodes/)، ثم اقرأ [TextFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/) التي تُرجعها [SmartArtShape.text_frame](https://reference.aspose.com/slides/ar/python-net/aspose.slides.smartart/smartartshape/text_frame/).

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        smart_art = shape

        for smart_art_node in smart_art.all_nodes:
            for smart_art_shape in smart_art_node.shapes:
                if smart_art_shape.text_frame is not None:
                    print(smart_art_shape.text_frame.text)
```

## **تغيير نوع التخطيط لكائن SmartArt**

يتحكم تخطيط SmartArt في كيفية ترتيب العقد وربطها. المثال التالي ينشئ كائن SmartArt باستخدام قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/ar/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST`، يغيّرها إلى القيمة `BASIC_PROCESS`، ويحفظ العرض التقديمي.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **التحقق مما إذا كانت عقدة SmartArt مخفية**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/ar/python-net/aspose.slides.smartart/smartartnode/is_hidden/) يدل على ما إذا كانت العقدة مخفية في نموذج بيانات SmartArt. يمكن أن توجد العقد المخفية في الهيكل حتى عندما لا يعرض التخطيط المحددها كعناصر مخطط مرئية.

المثال التالي يضيف عقدة إلى كائن SmartArt يستخدم قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/ar/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` ويفحص حالة إخفاء العقدة.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    smart_art_node = smart_art.all_nodes.add_node()
    is_hidden = smart_art_node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", slides.export.SaveFormat.PPTX)
```

## **الحصول على أو تعيين تخطيط مخطط التنظيم**

بالنسبة لمخططات SmartArt التي تستخدم تخطيط مخطط تنظيم، [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/ar/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) يحدد كيفية ترتيب العقد الفرعية تحت عقدة أصلية. على سبيل المثال، يمكنك تعيين العقد الفرعية لتتدَلّ من اليسار أو اليمين أو كلا الجانبين، اعتمادًا على [OrganizationChartLayoutType](https://reference.aspose.com/slides/ar/python-net/aspose.slides.smartart/organizationchartlayouttype/) المحدد.

المثال التالي ينشئ مخطط تنظيم ويضبط تخطيط العقدة الأولى إلى قيمة [OrganizationChartLayoutType](https://reference.aspose.com/slides/ar/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING`.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **إنشاء مخطط تنظيم بالصور**

مخطط تنظيم بالصور هو تخطيط SmartArt مصمم لمخططات الهرمية التي تشمل نوافير صور. استخدم قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/ar/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` عند إضافة كائن SmartArt إلى شريحة.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

**هل يدعم SmartArt النقل أو العكس للغات من اليمين إلى اليسار؟**

نعم. خاصية [SmartArt.is_reversed](https://reference.aspose.com/slides/ar/python-net/aspose.slides.smartart/smartart/is_reversed/) تغير اتجاه المخطط من اليسار إلى اليمين إلى اليمين إلى اليسار، أو العكس، عندما يدعم التخطيط المختار لعكس الاتجاه.

**كيف يمكنني نسخ SmartArt إلى الشريحة نفسها أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**

يمكنك [استنساخ شكل SmartArt](/slides/ar/python-net/shape-manipulations/) باستخدام [ShapeCollection.add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/add_clone/) أو [استنساخ الشريحة بالكامل](/slides/ar/python-net/clone-slides/) التي تحتوي على SmartArt. كلا النهجين يحافظان على الحجم والموقع والتنسيق.

**كيف أقوم بتحويل SmartArt إلى صورة نقطية للمعاينة أو لتصدير الويب؟**

[قم بتحويل الشريحة](/slides/ar/python-net/convert-powerpoint-to-png/) أو العرض التقديمي بالكامل إلى PNG أو JPEG. يتم تحويل SmartArt كجزء من الشريحة.

**كيف يمكنني العثور على كائن SmartArt محدد في شريحة إذا كان هناك عدة كائنات؟**

قم بتعيين قيمة مميزة لـ [Shape.alternative_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/alternative_text/) أو [Shape.name](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/name/) على شكل SmartArt، ابحث عن تلك القيمة في [Slide.shapes](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/shapes/)، ثم تحقق من أن الشكل المطابق هو [SmartArt](https://reference.aspose.com/slides/ar/python-net/aspose.slides.smartart/smartart/).