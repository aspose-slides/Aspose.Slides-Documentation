---
title: مدیریت گره‌های شکل SmartArt در ارائه‌ها با استفاده از Python
linktitle: گره شکل SmartArt
type: docs
weight: 30
url: /fa/python-java/manage-smartart-shape-node/
keywords:
- گره SmartArt
- گره فرزند
- افزودن گره
- موقعیت گره
- دسترسی به گره
- حذف گره
- موقعیت سفارشی
- گره معاون
- فرمت پر کردن
- رندر گره
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "مدیریت گره‌های شکل SmartArt در PPT و PPTX با Aspose.Slides برای Python via Java. دریافت نمونه‌های واضح کد و نکاتی برای بهینه‌سازی ارائه‌های شما."
---
## **بررسی کلی**

گرافیک‌های SmartArt در ارائه‌های PowerPoint از طریق گره‌هایی که متن را در خود دارند و ساختار دیاگرام را تعریف می‌کنند، سازماندهی می‌شوند. Aspose.Slides به شما امکان می‌دهد به‌صورت برنامه‌نویسی با این گره‌های SmartArt کار کنید: افزودن گره‌های جدید و گره‌های فرزند، درج گره‌های فرزند در موقعیت خاص، دسترسی به گره‌های موجود و خواندن متن، سطح و موقعیت آن‌ها.

این مقاله نحوه مدیریت گره‌های شکل SmartArt را توضیح می‌دهد. نشان می‌دهد چگونه گره‌ها را حذف کنید، با گره‌های فرزند بر اساس شاخص یا موقعیت کار کنید، گره معاون را به گره عادی تبدیل کنید، موقعیت، اندازه و چرخش شکل گره‌های SmartArt را تنظیم کنید، فرمت پر کردن گره را مشخص کنید و یک تصویر بندانگشتی برای گره فرزند SmartArt تولید کنید.

## **افزودن یک گره SmartArt**
Aspose.Slides for Python via Java یک API برای مدیریت شکل‌های SmartArt فراهم می‌کند. مثال زیر یک گره و یک گره فرزند را به یک شکل SmartArt اضافه می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بسازید و ارائه‌ای که شامل یک شکل SmartArt است را بارگذاری کنید.
1. اولین اسلاید را بر حسب شاخص آن دریافت کنید.
1. بر روی تمامی اشکال موجود در اولین اسلاید تکرار کنید.
1. بررسی کنید آیا شکل یک نمونه از [SmartArt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartart/) است یا خیر.
1. یک [گره جدید](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartartnodecollection/#addNode) به مجموعه [گره‌های](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartart/#getAllNodes) شکل SmartArt اضافه کنید و متن آن را از طریق [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) تنظیم کنید.
1. یک [گره فرزند](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartartnode/#getChildNodes) به گره جدید اضافه کنید و متن آن را از طریق [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) تنظیم کنید.
1. ارائه را ذخیره کنید.

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

## **افزودن یک گره SmartArt در موقعیت خاص**
مثال زیر یک گره فرزند را در موقعیت خاصی در یک گره SmartArt اضافه می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بسازید.
1. اولین اسلاید را بر حسب شاخص آن دریافت کنید.
1. یک شکل [SmartArt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartart/) با چیدمان [StackedList](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartartlayouttype/#StackedList) به اسلاید اضافه کنید.
1. به اولین گره در شکل SmartArt اضافه شده دسترسی پیدا کنید.
1. با استفاده از [addNodeByPosition](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartartnodecollection/#addNodeByPosition) یک گره فرزند به گره انتخاب شده در موقعیت 2 اضافه کنید و متن آن را تنظیم کنید.
1. ارائه را ذخیره کنید.

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

## **دسترسی به یک گره SmartArt**
مثال زیر به گره‌های یک شکل SmartArt دسترسی پیدا می‌کند. چیدمانی که توسط [getLayout](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartart/#getLayout) برگردانده می‌شود فقط قابل خواندن است و هنگام افزودن شکل SmartArt تعیین می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بسازید و ارائه‌ای که شامل یک شکل SmartArt است را بارگذاری کنید.
1. اولین اسلاید را بر حسب شاخص آن دریافت کنید.
1. بر روی تمامی اشکال موجود در اولین اسلاید تکرار کنید.
1. بررسی کنید آیا شکل یک نمونه از [SmartArt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartart/) است یا خیر.
1. بر روی تمامی [گره‌ها](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartart/#getAllNodes) در شکل SmartArt تکرار کنید.
1. موقعیت، سطح و متن هر گره SmartArt را بخوانید و نمایش دهید.

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

## **دسترسی به گره فرزند SmartArt**
مثال زیر به گره‌های فرزند هر گره در یک شکل SmartArt دسترسی پیدا می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بسازید و ارائه‌ای که شامل یک شکل SmartArt است را بارگذاری کنید.
1. اولین اسلاید را بر حسب شاخص آن دریافت کنید.
1. بر روی تمامی اشکال موجود در اولین اسلاید تکرار کنید.
1. بررسی کنید آیا شکل یک نمونه از [SmartArt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartart/) است یا خیر.
1. بر روی تمامی [گره‌ها](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartart/#getAllNodes) در شکل SmartArt تکرار کنید.
1. برای هر گره، بر روی [گره‌های فرزند](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartartnode/#getChildNodes) آن تکرار کنید.
1. موقعیت، سطح و متن [گره فرزند](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartartnode/#getChildNodes) را بخوانید و نمایش دهید.

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

## **دسترسی به گره فرزند SmartArt در موقعیت خاص**
مثال زیر به یک گره فرزند در شاخص خاصی در مجموعه گره‌های والد خود دسترسی پیدا می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بسازید.
1. اولین اسلاید را بر حسب شاخص آن دریافت کنید.
1. یک شکل SmartArt با چیدمان [StackedList](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartartlayouttype/#StackedList) اضافه کنید.
1. به شکل SmartArt اضافه شده دسترسی پیدا کنید.
1. گره‌ای با شاخص 0 در شکل SmartArt را دریافت کنید.
1. با استفاده از [get_Item](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartartnodecollection/#get_Item) گره فرزند با شاخص 1 را دریافت کنید.
1. موقعیت، سطح و متن [گره فرزند](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartartnode/#getChildNodes) را بخوانید و نمایش دهید.

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

## **حذف یک گره SmartArt**
مثال زیر یک گره را از یک شکل SmartArt حذف می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بسازید و ارائه‌ای که شامل یک شکل SmartArt است را بارگذاری کنید.
1. اولین اسلاید را بر حسب شاخص آن دریافت کنید.
1. بر روی تمامی اشکال موجود در اولین اسلاید تکرار کنید.
1. بررسی کنید آیا شکل یک نمونه از [SmartArt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartart/) است یا خیر.
1. اطمینان حاصل کنید که شکل [SmartArt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartart/) حداقل یک گره دارد.
1. گره SmartArt مورد نظر برای حذف را انتخاب کنید.
1. گره انتخاب شده را با استفاده از [removeNode](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartartnodecollection/#removeNode) حذف کنید.
1. ارائه را ذخیره کنید.

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

## **حذف یک گره SmartArt از موقعیت خاص**
مثال زیر یک گره فرزند را در شاخص خاصی در مجموعه گره‌های یک گره SmartArt حذف می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بسازید و ارائه‌ای که شامل یک شکل SmartArt است را بارگذاری کنید.
1. اولین اسلاید را بر حسب شاخص آن دریافت کنید.
1. بر روی تمامی اشکال موجود در اولین اسلاید تکرار کنید.
1. بررسی کنید آیا شکل یک نمونه از [SmartArt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartart/) است یا خیر.
1. گره SmartArt با شاخص 0 را در صورت وجود دریافت کنید.
1. اطمینان حاصل کنید که گره SmartArt انتخاب شده حداقل دو گره فرزند دارد.
1. گره فرزند با شاخص 1 را با استفاده از [removeNode](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartartnodecollection/#removeNode) حذف کنید.
1. ارائه را ذخیره کنید.

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

## **تنظیم موقعیت سفارشی برای گره فرزند در شیء SmartArt**
Aspose.Slides for Python via Java امکان تنظیم موقعیت یک [SmartArtShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartartshape/) را با استفاده از [setX](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#setX) و [setY](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#setY) فراهم می‌کند. مثال زیر موقعیت، اندازه و چرخش سفارشی را برای شکل‌های گره SmartArt تنظیم می‌کند. افزودن گره‌های جدید موقعیت و اندازه تمام گره‌ها را مجدداً محاسبه می‌کند. موقعیت‌گذاری سفارشی اجازه می‌دهد گره‌ها را مطابق نیاز خود ترتیب دهید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

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

## **بررسی یک گره معاون**
{{% alert color="info" title="نکته" %}} 

این بخش به بررسی شکل‌های SmartArt پرداخته شده به اسلایدهای ارائه به‌صورت برنامه‌نویسی با استفاده از Aspose.Slides for Python via Java می‌پردازد.

{{% /alert %}} 

شکل SmartArt منبع زیر در این مثال استفاده می‌شود.

|![SmartArt shape](https://i.imgur.com/FItwczY.png)|
| :- |
|**شکل: SmartArt منبع بر روی اسلاید**|

مثال زیر گره‌های معاون در مجموعه گره‌های SmartArt را شناسایی کرده و آنها را به گره‌های عادی تبدیل می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بسازید و ارائه‌ای که شامل یک شکل SmartArt است را بارگذاری کنید.
1. اولین اسلاید را بر حسب شاخص آن دریافت کنید.
1. بر روی تمامی اشکال موجود در اولین اسلاید تکرار کنید.
1. بررسی کنید آیا شکل یک نمونه از [SmartArt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartart/) است یا خیر.
1. بر روی تمام گره‌ها در شکل SmartArt تکرار کنید و بررسی کنید آیا آنها [Assistant Nodes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartartnode/#isAssistant) هستند یا خیر.
1. هر گره معاون را به یک گره عادی تغییر دهید.
1. ارائه را ذخیره کنید.

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
|**شکل: گره‌های معاون در یک شکل SmartArt بر روی اسلاید تغییر یافتند**|

## **تنظیم فرمت پر کردن گره**
Aspose.Slides for Python via Java امکان افزودن شکل‌های سفارشی SmartArt و تنظیم فرمت پر کردن آنها را فراهم می‌کند. این مقاله توضیح می‌دهد چگونه شکل‌های SmartArt را ایجاد و دسترسی پیدا کنید و فرمت پر کردن آنها را با استفاده از Aspose.Slides for Python via Java تنظیم کنید.

لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بسازید.
1. یک اسلاید را بر حسب شاخص آن دریافت کنید.
1. یک شکل [SmartArt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartart/) با چیدمان [ClosedChevronProcess](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartartlayouttype/#ClosedChevronProcess) اضافه کنید.
1. برای گره‌های شکل SmartArt، [FillFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getFillFormat) را تنظیم کنید.
1. ارائه اصلاح‌شده را به صورت فایل PPTX بنویسید.

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

## **تولید تصویر بندانگشتی از گره فرزند SmartArt**
برای تولید تصویر بندانگشتی از یک گره فرزند SmartArt، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بسازید.
1. یک [شکل SmartArt اضافه کنید](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addSmartArt).
1. یک گره را بر حسب شاخص آن دریافت کنید.
1. تصویر بندانگشتی را دریافت کنید.
1. تصویر بندانگشتی را در هر فرمت تصویر دلخواهی ذخیره کنید.

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

## **سوالات متداول**

**آیا انیمیشن SmartArt پشتیبانی می‌شود؟**

بله. SmartArt به‌عنوان یک شکل عادی در نظر گرفته می‌شود، بنابراین می‌توانید [انیمیشن‌های استاندارد](/slides/fa/python-java/shape-animation/) (ورود، خروج، تأکید، مسیرهای حرکتی) را اعمال کنید و زمان‌بندی را تنظیم کنید. در صورت نیاز می‌توانید شکل‌های داخل گره‌های SmartArt را نیز متحرک کنید.

**چگونه می‌توانم به‌طور قابل اطمینان یک SmartArt خاص را بر روی اسلاید پیدا کنم اگر شناسه داخلی آن ناشناخته باشد؟**

با اختصاص و جستجو بر اساس [متن جایگزین](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getAlternativeText) می‌توانید متن جایگزین متمایزی به SmartArt بدهید و برنامه‌نویسی آن را بدون وابستگی به شناسه‌های داخلی پیدا کنید.

**آیا ظاهر SmartArt هنگام تبدیل ارائه به PDF حفظ می‌شود؟**

بله. Aspose.Slides هنگام [خروجی PDF](/slides/fa/python-java/convert-powerpoint-to-pdf/)، SmartArt را با دقت بصری بالا رندر می‌کند و چیدمان، رنگ‌ها و اثرات را حفظ می‌کند.

**آیا می‌توانم تصویر کامل SmartArt را استخراج کنم (برای پیش‌نمایش یا گزارش‌ها)؟**

بله. می‌توانید یک شکل SmartArt را به [فرمت‌های رستر](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getImage) یا به [SVG](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#writeAsSvgToBytes) رندر کنید تا خروجی برداری مقیاس‌پذیر داشته باشید، که برای بندانگشتی‌ها، گزارش‌ها یا استفاده در وب مناسب است.