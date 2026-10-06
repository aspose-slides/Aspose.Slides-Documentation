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
- مخطط تنظيم
- مخطط تنظيم بالصور
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إنشاء وتحرير SmartArt في PowerPoint باستخدام Aspose.Slides للغة Python عبر Java مع أمثلة شفرة واضحة تسرع تصميم الشرائح والأتمتة."
---
## **نظرة عامة**

SmartArt هو مخطط PowerPoint يتكون من العقد وأشكال العقد وتخطيط. باستخدام Aspose.Slides للغة Python عبر Java، يمكنك إنشاء SmartArt، قراءة النص من عقده، تغيير تخطيطه، فحص العقد المخفية، تكوين تخطيطات مخطط المنظمة، وإنشاء مخططات منظمة بالصور.

## **الحصول على النص من كائن SmartArt**

يمكن أن تحتوي عقدة SmartArt على شكل واحد أو أكثر. لقراءة النص من أشكال العقد، قم بالتكرار عبر [SmartArt.getAllNodes](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#getAllNodes)، ثم اقرأ [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) التي يتم إرجاعها بواسطة [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartshape/#getTextFrame).

يتطلب المثال عرضًا تقديميًا يحتوي على شريحة واحدة على الأقل وكائن SmartArt كأول شكل في تلك الشريحة. يطبع كل إطار نص متاح إلى وحدة التحكم.

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

## **تغيير نوع التخطيط لكائن SmartArt**

يتحكم تخطيط SmartArt في كيفية ترتيب العقد وربطها. يخلق المثال التالي كائن SmartArt باستخدام قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList`، ثم يغيّرها إلى القيمة `BasicProcess`، ويحفظ العرض التقديمي. يتم قياس الموقع والحجم الممررين إلى [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSmartArt) بالنقاط. استخدم [SmartArt.setLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setLayout) لتغيير التخطيط.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **التحقق مما إذا كانت عقدة SmartArt مخفية**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#isHidden) يشير إلى ما إذا كانت العقدة مخفية في نموذج بيانات SmartArt. يمكن أن توجد العقد المخفية في البنية حتى عندما لا يعرض التخطيط المحددها كعناصر مخطط مرئية.

يضيف المثال التالي عقدة إلى كائن SmartArt يستخدم قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `RadialCycle` ويتحقق من حالة إخفاء العقدة المضافة. يطبع رسالة إذا كانت العقدة مخفية ويحفظ المخطط.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)
    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الحصول على تخطيط مخطط المنظمة أو تعيينه**

بالنسبة لمخططات SmartArt التي تستخدم تخطيط مخطط المنظمة، يحدد كل من [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) و[SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) كيفية ترتيب العقد الفرعية تحت عقدة أصلية. على سبيل المثال، يمكنك ضبط العقد الفرعية لتتدلى من اليسار أو اليمين أو كلا الجانبين، اعتمادًا على [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) المحدد.

يخلق المثال التالي مخطط منظمة ويضبط التخطيط للعقدة الأولى إلى قيمة [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`. يحدد الفهرس الصفري `0` العقدة العليا الأولى؛ وتستخدم عقدها الفرعية الترتيب المحدد. ثم يتم حفظ العرض التقديمي المعدل.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)
    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **إنشاء مخطط منظمة بالصورة**

مخطط المنظمة بالصورة هو تخطيط SmartArt مصمم لمخططات التسلسل الهرمي التي تتضمن نوافير صور. استخدم قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` عند إضافة كائن SmartArt إلى شريحة. يحفظ هذا المثال مخططًا يحتوي على نوافير صور؛ لكنه لا يملأ النوافير بالصور.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تحويل المخططات القديمة إلى مجموعات من الأشكال**

عند تحديث عرض تقديمي موجود، قد تحتاج إلى تحديث مخطط منظمة تم إنشاؤه أصلاً في PowerPoint 97–2003. تمثل Aspose.Slides هذه المخططات القديمة ككائنات [LegacyDiagram](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/). استخدم [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/#convertToGroupShape) لتحويل مخطط إلى مجموعة من الأشكال حتى تتمكن من تحرير العناصر البصرية الفردية. راجع [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/) للحصول على التفاصيل.

تضيف عملية التحويل مجموعة جديدة إلى مجموعة الأشكال دون إزالة المخطط الأصلي. بعد إكمال التحويل بنجاح، احذف الأصلي باستخدام [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) لتجنب المحتوى المكرر. اجمع المخططات القديمة في قائمة قبل تحويلها بحيث لا يؤثر إضافة وإزالة الأشكال على عملية التكرار.

يفتح المثال التالي عرضًا تقديميًا، يبحث في كل شريحة، يحول المخططات إلى مجموعات من الأشكال، ويحفظ العرض التقديمي المحدث كملف PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LegacyDiagram, Presentation, SaveFormat

presentation = Presentation("legacy-diagrams.ppt")
try:
    for slide in presentation.getSlides():
        legacy_diagrams = []
        for shape in slide.getShapes():
            if isinstance(shape, LegacyDiagram):
                legacy_diagrams.append(shape)

        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convertToGroupShape()

            if group_shape is not None:
                slide.getShapes().remove(legacy_diagram)

    presentation.save("modernized.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

يحتوي العرض التقديمي المحفوظ على مجموعات من الأشكال القابلة للتعديل بدلاً من المخططات القديمة المحولة، دون وجود أي مخططات أصلية بجانبها. افتح ملف PPTX في PowerPoint لتحرير العناصر الفردية داخل كل مجموعة، مثل النص أو التعبئة أو الموقع.

## **الأسئلة الشائعة**

**هل يدعم SmartArt الانعكاس أو العكس للغات من اليمين إلى اليسار؟**

نعم. طريقة [SmartArt.setReversed](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setReversed) تغير اتجاه المخطط من اليسار إلى اليمين إلى اليمين إلى اليسار، أو العكس، عندما يدعم تخطيط SmartArt المختار العكس.

**كيف يمكنني نسخ SmartArt إلى الشريحة نفسها أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**

يمكنك [استنساخ شكل SmartArt](/slides/ar/python-java/shape-manipulations/) باستخدام [ShapeCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addClone) أو [استنساخ الشريحة كاملة](/slides/ar/python-java/clone-slides/) التي تحتوي على SmartArt. يحافظ كلا النهجين على الحجم والموقع والتنسيق.

**كيف يمكنني تحويل SmartArt إلى صورة نقطية للمعاينة أو تصدير الويب؟**

[قم بتصدير الشريحة](/slides/ar/python-java/convert-powerpoint-to-png/) أو العرض التقديمي كاملًا إلى PNG أو JPEG. يتم تصيير SmartArt كجزء من الشريحة.

**كيف يمكنني العثور على كائن SmartArt محدد في شريحة إذا كان هناك عدة كائنات؟**

استخدم [Shape.setAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setAlternativeText) أو [Shape.setName](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setName) لتعيين نص بديل مميز أو اسم إلى شكل SmartArt، ابحث عن تلك القيمة في [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes)، ثم تحقق أن الشكل المطابق هو [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/).