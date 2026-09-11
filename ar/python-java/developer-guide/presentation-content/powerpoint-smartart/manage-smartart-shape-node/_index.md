---
title: إدارة عقد أشكال SmartArt في العروض التقديمية باستخدام Python
linktitle: عقدة شكل SmartArt
type: docs
weight: 30
url: /ar/python-java/manage-smartart-shape-node/
keywords:
- عقدة SmartArt
- عقدة فرعية
- إضافة عقدة
- موضع العقدة
- الوصول إلى العقدة
- إزالة العقدة
- موضع مخصص
- عقدة مساعدة
- تنسيق التعبئة
- تصيير العقدة
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إدارة عقد أشكال SmartArt في ملفات PPT و PPTX باستخدام Aspose.Slides for Python عبر Java. احصل على أمثلة شفرة واضحة ونصائح لتبسيط عروضك التقديمية."
---
## **نظرة عامة**

يتم تنظيم رسومات SmartArt في عروض PowerPoint عبر عقد تحتوي على نص وتحدد هيكل المخطط. تتيح لك Aspose.Slides العمل مع عقد SmartArt برمجياً: إضافة عقد جديدة وعقد فرعية، إدراج عقد فرعية في موضع محدد، الوصول إلى العقد الموجودة، وقراءة نصها، ومستواها، وموقعها.

تشرح هذه المقالة كيفية إدارة عقد شكل SmartArt. توضح كيفية إزالة العقد، والعمل مع العقد الفرعية حسب الفهرس أو الموضع، وتحويل عقدة مساعدة إلى عقدة عادية، وضبط الموضع والحجم والدوران لأشكال عقد SmartArt، وتعيين تنسيقات التعبئة للعقد، وتوليد صورة مصغرة لعقدة فرعية من SmartArt.

## **إضافة عقدة SmartArt**
توفر Aspose.Slides for Python via Java واجهة برمجة تطبيقات لإدارة أشكال SmartArt. المثال التالي يضيف عقدة وعقدة فرعية إلى شكل SmartArt.

1. أنشئ مثيلاً من الفئة [العرض التقديمي](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) وحمّل العرض الذي يحتوي على شكل SmartArt.
1. احصل على الشريحة الأولى بحسب فهرستها.
1. حلق عبر كل شكل في الشريحة الأولى.
1. تحقق مما إذا كان الشكل نسخة من [SmartArt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartart/).
1. [أضف عقدة جديدة](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartartnodecollection/#addNode) إلى مجموعة [العقد](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartart/#getAllNodes) في شكل SmartArt، واضبط نصها عبر [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/).
1. [أضف](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartartnodecollection/#addNode) [عقدة فرعية](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartartnode/#getChildNodes) إلى العقدة الجديدة واضبط نصها عبر [TextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/).
1. احفظ العرض.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("SimpleSmartArt.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            node = smart_art.getAllNodes().addNode()
            node.getTextFrame().setText("Test")
            child_node = node.getChildNodes().addNode()
            child_node.getTextFrame().setText("New Node Added")
    presentation.save("AddSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **إضافة عقدة SmartArt في موضع محدد**
المثال التالي يضيف عقدة فرعية في موضع معين داخل عقدة SmartArt.

1. أنشئ مثيلاً من الفئة [العرض التقديمي](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
1. احصل على الشريحة الأولى بحسب فهرستها.
1. أضف شكل [SmartArt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartart/) باستخدام تخطيط [StackedList](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartartlayouttype/#StackedList) إلى الشريحة.
1. وصل إلى العقدة الأولى في شكل SmartArt المضاف.
1. أضف عقدة فرعية إلى العقدة المحددة في الموضع 2 باستخدام [addNodeByPosition](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartartnodecollection/#addNodeByPosition) واضبط نصها.
1. احفظ العرض.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    child_node = node.getChildNodes().addNodeByPosition(2)
    child_node.getTextFrame().setText("Sample Text Added")
    presentation.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الوصول إلى عقدة SmartArt**
المثال التالي يصل إلى العقد في شكل SmartArt. التخطيط الذي يُرجع بواسطة [getLayout](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartart/#getLayout) هو قراءة فقط ويتم تعيينه عند إضافة شكل SmartArt.

1. أنشئ مثيلاً من الفئة [العرض التقديمي](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) وحمّل العرض الذي يحتوي على شكل SmartArt.
1. احصل على الشريحة الأولى بحسب فهرستها.
1. حلق عبر كل شكل في الشريحة الأولى.
1. تحقق مما إذا كان الشكل نسخة من [SmartArt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartart/).
1. حلق عبر جميع [العقد](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartart/#getAllNodes) في شكل SmartArt.
1. اقرأ واعرض موضع كل عقدة SmartArt ومستواها ونصها.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("SmartArtShape.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                print(node.getTextFrame().getText(), " ", node.getLevel(), " ", node.getPosition())
finally:
    presentation.dispose()
```

## **الوصول إلى عقدة فرعية في SmartArt**
المثال التالي يصل إلى العقد الفرعية لكل عقدة في شكل SmartArt.

1. أنشئ مثيلاً من الفئة [العرض التقديمي](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) وحمّل العرض الذي يحتوي على شكل SmartArt.
1. احصل على الشريحة الأولى بحسب فهرستها.
1. حلق عبر كل شكل في الشريحة الأولى.
1. تحقق مما إذا كان الشكل نسخة من [SmartArt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartart/).
1. حلق عبر جميع [العقد](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartart/#getAllNodes) في شكل SmartArt.
1. لكل عقدة، حلق عبر [العقد الفرعية](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartartnode/#getChildNodes) الخاصة بها.
1. اقرأ واعرض موضع [العقدة الفرعية](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartartnode/#getChildNodes) ومستواها ونصها.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessChildNodes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                parent_node = smart_art.getAllNodes().get_Item(i)
                for j in range(parent_node.getChildNodes().size()):
                    node = parent_node.getChildNodes().get_Item(j)
                    print("j = ", j, ", Text = ", node.getTextFrame().getText(), ",  Level = ", node.getLevel(), ", Position = ", node.getPosition())
finally:
    presentation.dispose()
```

## **الوصول إلى عقدة فرعية في SmartArt بموضع محدد**
المثال التالي يصل إلى عقدة فرعية في فهرس محدد داخل مجموعة العقد للعنصر الأصل.

1. أنشئ مثيلاً من الفئة [العرض التقديمي](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
1. احصل على الشريحة الأولى بحسب فهرستها.
1. أضف شكل SmartArt باستخدام تخطيط [StackedList](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartartlayouttype/#StackedList).
1. وصل إلى شكل SmartArt المضاف.
1. وصل إلى العقدة في الفهرس 0 داخل شكل SmartArt.
1. وصل إلى العقدة الفرعية في الفهرس 1 باستخدام [get_Item](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartartnodecollection/#get_Item).
1. اقرأ واعرض موضع [العقدة الفرعية](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartartnode/#getChildNodes) ومستواها ونصها.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    position = 1
    child_node = node.getChildNodes().get_Item(position)
    print("Text = ", child_node.getTextFrame().getText(), ",  Level = ", child_node.getLevel(), ", Position = ", child_node.getPosition())
finally:
    presentation.dispose()
```

## **إزالة عقدة SmartArt**
المثال التالي يزيل عقدة من شكل SmartArt.

1. أنشئ مثيلاً من الفئة [العرض التقديمي](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) وحمّل العرض الذي يحتوي على شكل SmartArt.
1. احصل على الشريحة الأولى بحسب فهرستها.
1. حلق عبر كل شكل في الشريحة الأولى.
1. تحقق مما إذا كان الشكل نسخة من [SmartArt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartart/).
1. تحقق من أن شكل SmartArt يحتوي على عقدة واحدة على الأقل.
1. اختر عقدة SmartArt التي تريد حذفها.
1. أزل العقدة المحددة باستخدام [removeNode](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartartnodecollection/#removeNode).
1. احفظ العرض.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                smart_art.getAllNodes().removeNode(node)
    presentation.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **إزالة عقدة SmartArt من موضع محدد**
المثال التالي يزيل عقدة فرعية في فهرس محدد داخل مجموعة عقد SmartArt.

1. أنشئ مثيلاً من الفئة [العرض التقديمي](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) وحمّل العرض الذي يحتوي على شكل SmartArt.
1. احصل على الشريحة الأولى بحسب فهرستها.
1. حلق عبر كل شكل في الشريحة الأولى.
1. تحقق مما إذا كان الشكل نسخة من [SmartArt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartart/).
1. وصل إلى عقدة SmartArt في الفهرس 0 إذا كانت موجودة.
1. تحقق من أن العقدة المحددة لديها عقدتين فرعيتين على الأقل.
1. أزل العقدة الفرعية في الفهرس 1 باستخدام [removeNode](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartartnodecollection/#removeNode).
1. احفظ العرض.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                if node.getChildNodes().size() >= 2:
                    node.getChildNodes().removeNode(1)
    presentation.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعيين موضع مخصص لعقدة فرعية في كائن SmartArt**
يدعم Aspose.Slides for Python via Java تعيين موضع [SmartArtShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartartshape/) باستخدام [setX](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#setX) و[setY](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#setY). المثال التالي يحدد موضعًا مخصصًا، وحجمًا، ودورانًا لأشكال عقد SmartArt. إضافة عقد جديدة يعيد حساب مواضع وأحجام جميع العقد. يتيح التحديد المخصص ترتيب العقد حسب الحاجة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart)
    node = smart_art.getAllNodes().get_Item(1)
    shape = node.getShapes().get_Item(1)
    shape.setX(shape.getX() + shape.getWidth() * 2)
    shape.setY(shape.getY() - shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(2)
    shape = node.getShapes().get_Item(1)
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2)
    node = smart_art.getAllNodes().get_Item(3)
    shape = node.getShapes().get_Item(1)
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(4)
    shape = node.getShapes().get_Item(1)
    shape.setRotation(90)
    presentation.save("SmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **التحقق من عقدة مساعدة**
{{% alert color="info" title="ملاحظة" %}} 

يستكشف هذا القسم أشكال SmartArt التي تُضاف إلى شرائح العرض برمجياً باستخدام Aspose.Slides for Python via Java.

{{% /alert %}} 

يُستخدم شكل SmartArt التالي كمصدر في هذا المثال.

|![SmartArt shape](https://i.imgur.com/FItwczY.png)|
| :- |
|**الشكل: شكل SmartArt الأصلي على شريحة**|

المثال التالي يحدد العقد المساعدة في مجموعة عقد SmartArt ويحولها إلى عقد عادية.

1. أنشئ مثيلاً من الفئة [العرض التقديمي](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) وحمّل العرض الذي يحتوي على شكل SmartArt.
1. احصل على الشريحة الأولى بحسب فهرستها.
1. حلق عبر كل شكل في الشريحة الأولى.
1. تحقق مما إذا كان الشكل نسخة من [SmartArt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartart/).
1. حلق عبر جميع العقد في شكل SmartArt وتحقق مما إذا كانت [عقد مساعدة](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartartnode/#isAssistant).
1. غيّر كل عقدة مساعدة إلى عقدة عادية.
1. احفظ العرض.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddNodes.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                if node.isAssistant():
                    node.setAssistant(False)
    presentation.save("ChangeAssistantNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**الشكل: تم تغيير العقد المساعدة في شكل SmartArt على شريحة**|

## **تعيين تنسيق تعبئة العقدة**
يتيح Aspose.Slides for Python via Java إمكانية إضافة أشكال SmartArt مخصصة وتعيين تنسيق تعبئتها. تشرح هذه المقالة كيفية إنشاء والوصول إلى أشكال SmartArt وتعيين تنسيق تعبئتها باستخدام Aspose.Slides for Python via Java.

يرجى اتباع الخطوات أدناه:

1. أنشئ مثيلاً من الفئة [العرض التقديمي](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
1. احصل على شريحة بحسب فهرستها.
1. أضف شكل [SmartArt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartart/) بتخطيط [ClosedChevronProcess](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartartlayouttype/#ClosedChevronProcess).
1. عيّن [FillFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getFillFormat) لعقد شكل SmartArt.
1. احفظ العرض المعدّل كملف PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess)
    node = chevron.getAllNodes().addNode()
    node.getTextFrame().setText("Some text")
    for item in node.getShapes():
        item.getFillFormat().setFillType(FillType.Solid)
        item.getFillFormat().getSolidFillColor().setColor(Color.RED)
    presentation.save("TestSmart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **توليد صورة مصغرة لعقدة فرعية في SmartArt**
لتوليد صورة مصغرة لعقدة فرعية في SmartArt، اتبع الخطوات التالية:

1. أنشئ مثيلاً من الفئة [العرض التقديمي](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
1. [أضف شكل SmartArt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addSmartArt).
1. احصل على عقدة بحسب فهرستها.
1. احصل على صورة المصغرة.
1. احفظ صورة المصغرة بأي تنسيق صورة تفضله.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType, ImageFormat

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle)
    node = smart_art.getNodes().get_Item(1)
    image = node.getShapes().get_Item(0).getImage()
    try:
        image.save("SmartArt_ChildNode_Thumbnail.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**هل تدعم الرسوم المتحركة لـ SmartArt؟**

نعم. يُعامل SmartArt كشكل عادي، لذا يمكنك [تطبيق الرسوم المتحركة القياسية](/slides/ar/python-java/shape-animation/) (دخول، خروج، تأكيد، مسارات الحركة) وضبط التوقيت. يمكنك أيضاً تحريك الأشكال داخل عقد SmartArt عند الحاجة.

**كيف يمكنني تحديد موقع SmartArt معين على شريحة إذا كان معرفه الداخلي غير معروف؟**

استخدم وابحث عبر [النص البديل](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getAlternativeText). ضبط نص بديل مميز على SmartArt يتيح العثور عليه برمجياً دون الاعتماد على المعرفات الداخلية.

**هل سيحافظ مظهر SmartArt عند تحويل العرض إلى PDF؟**

نعم. تقوم Aspose.Slides بتصدير SmartArt بجودة بصرية عالية أثناء [تصدير PDF](/slides/ar/python-java/convert-powerpoint-to-pdf/)، مع الحفاظ على التخطيط، والألوان، والتأثيرات.

**هل يمكن استخراج صورة كاملة لـ SmartArt (للمعاينات أو التقارير)؟**

نعم. يمكنك تصدير شكل SmartArt إلى [تنسيقات نقطية](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getImage) أو إلى [SVG](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#writeAsSvgToBytes) للحصول على مخرجات متجهية قابلة للتوسع، ما يجعلها مناسبة للصور المصغرة، التقارير، أو الاستخدام على الويب.