---
title: إدارة SmartArt في عروض PowerPoint التقديمية باستخدام Python
linktitle: إدارة SmartArt
type: docs
weight: 10
url: /ar/python-java/manage-smartart/
keywords:
  - SmartArt
  - نص SmartArt
  - نوع التخطيط
  - خاصية مخفية
  - مخطط تنظيمي
  - مخطط تنظيمي بصري
  - PowerPoint
  - عرض تقديمي
  - Python
  - Aspose.Slides
description: "تعلّم كيفية إنشاء وتعديل SmartArt في PowerPoint باستخدام Aspose.Slides لـ Python عبر Java مع أمثلة شفرة واضحة تُسرّع تصميم الشرائح والأتمتة."
---
## **نظرة عامة**

SmartArt هو مخطط PowerPoint مكوّن من العقد، أشكال العقد، وتخطيط. مع Aspose.Slides لـ Python عبر Java، يمكنك إنشاء SmartArt، قراءة النص من عقده، تغيير تخطيطه، فحص العقد المخفية، تكوين تخطيطات مخطط التنظيم، وإنشاء مخططات تنظيمية بصور.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, SmartArt):
        smart_art = shape

        for node in smart_art.getAllNodes():
            for node_shape in node.getShapes():
                if node_shape.getTextFrame() is not None:
                    print(node_shape.getTextFrame().getText())
finally:
    presentation.dispose()
```

## **الحصول على النص من كائن SmartArt**

يمكن لعقدة SmartArt أن تحتوي على شكل واحد أو أكثر. لقراءة النص الظاهر، قم بالتكرار عبر [SmartArt.getAllNodes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartart/#getAllNodes)، ثم اقرأ الـ [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/) الذي تُعيده [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartartshape/#getTextFrame).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)

    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تغيير نوع التخطيط لكائن SmartArt**

يتحكم تخطيط SmartArt في كيفية ترتيب العقد وربطها. المثال التالي ينشئ كائن SmartArt باستخدام قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList`، ثم يغيّره إلى القيمة `BasicProcess`، ويحفظ العرض التقديمي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)

    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **التحقق مما إذا كانت عقدة SmartArt مخفيّة**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartartnode/#isHidden) يُشير إلى ما إذا كانت العقدة مخفيّة في نموذج بيانات SmartArt. يمكن أن توجد العقد المخفيّة في البنية حتى عندما لا يعرض التخطيط المختارها كعناصر مخطط مرئية.

المثال التالي يضيف عقدة إلى كائن SmartArt يستخدم قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartartlayouttype/) `RadialCycle` ويفحص حالة إخفاء العقدة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)

    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الحصول على أو ضبط تخطيط مخطط التنظيم**

بالنسبة لمخططات SmartArt التي تستخدم تخطيط مخطط التنظيم، تُحدد [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) و[SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) كيفية ترتيب العقد الفرعية تحت عقدة أصلية. على سبيل المثال، يمكنك ضبط العقد الفرعية لتتعليق من اليسار أو اليمين أو كلا الجانبين، وفقًا لـ [OrganizationChartLayoutType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/organizationchartlayouttype/) المختار.

المثال التالي ينشئ مخطط تنظيم ويضبط تخطيط العقدة الأولى إلى قيمة [OrganizationChartLayoutType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **إنشاء مخطط تنظيم بصري**

مخطط التنظيم البصري هو تخطيط SmartArt مُصمم لمخططات التسلسل الهرمي التي تتضمن نواقل صور. استخدم قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` عند إضافة كائن SmartArt إلى شريحة.

## **الأسئلة المتكررة**

**هل يدعم SmartArt المرآة أو العكس للغات من اليمين إلى اليسار؟**

نعم. طريقة [SmartArt.setReversed](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartart/#setReversed) تُغيّر اتجاه المخطط من اليسار إلى اليمين إلى اليمين إلى اليسار، أو العكس، عندما يدعم التخطيط المختار في SmartArt العكس.

**كيف يمكنني نسخ SmartArt إلى نفس الشريحة أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**

يمكنك [استنساخ شكل SmartArt](/slides/ar/python-java/shape-manipulations/) باستخدام [ShapeCollection.addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addClone) أو [استنساخ الشريحة كاملة](/slides/ar/python-java/clone-slides/) التي تحتوي على SmartArt. كلا الطريقتين تحافظان على الحجم والموقع والتنسيق.

**كيف أقوم بعرض SmartArt كصورة نقطية للمعاينة أو تصدير الويب؟**

[قم بعرض الشريحة](/slides/ar/python-java/convert-powerpoint-to-png/) أو العرض التقديمي كاملًا إلى PNG أو JPEG. يتم عرض SmartArt كجزء من الشريحة.

**كيف يمكنني العثور على كائن SmartArt محدد في شريحة إذا كان هناك عدة؟**

قم بتعيين قيمة مميزة لـ [Shape.getAlternativeText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getAlternativeText) أو [Shape.getName](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getName) على شكل SmartArt، وابحث عن تلك القيمة في [BaseSlide.getShapes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/#getShapes)، ثم تحقق من أن الشكل المطابق هو [SmartArt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartart/).