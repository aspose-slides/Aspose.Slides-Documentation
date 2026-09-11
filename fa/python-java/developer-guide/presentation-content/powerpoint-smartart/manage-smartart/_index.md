---
title: مدیریت SmartArt در ارائه‌های PowerPoint با استفاده از Python
linktitle: مدیریت SmartArt
type: docs
weight: 10
url: /fa/python-java/manage-smartart/
keywords:
- SmartArt
- متن SmartArt
- نوع طرح‌بندی
- ویژگی مخفی
- نمودار سازمانی
- نمودار سازمانی تصویری
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه با Aspose.Slides برای Python از طریق Java، SmartArt پاورپوینت را با استفاده از نمونه‌های کد واضح که سرعت طراحی اسلاید و خودکارسازی را افزایش می‌دهند، بسازید و ویرایش کنید."
---
## **مرور کلی**

SmartArt یک نمودار PowerPoint است که از گره‌ها، شکل‌های گره و یک طرح‌بندی ساخته شده است. با Aspose.Slides برای Python از طریق Java، می‌توانید SmartArt ایجاد کنید، متن را از گره‌های آن بخوانید، طرح‌بندی آن را تغییر دهید، گره‌های مخفی را بررسی کنید، طرح‌بندی‌های نمودار سازمانی را پیکربندی کنید و نمودارهای سازمانی تصویری ایجاد کنید.

## **دریافت متن از یک شیء SmartArt**

یک گره SmartArt می‌تواند یک یا چند شکل را شامل شود. برای خواندن متن قابل مشاهده، از طریق [SmartArt.getAllNodes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartart/#getAllNodes) پیمایش کنید، سپس [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) برگردانده شده توسط [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartartshape/#getTextFrame) را بخوانید.

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

## **تغییر نوع طرح‌بندی یک شیء SmartArt**

طرح‌بندی SmartArt تعیین می‌کند که گره‌ها چگونه چینش و متصل شوند. مثال زیر یک شیء SmartArt با مقدار `BasicBlockList` از [SmartArtLayoutType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartartlayouttype/) ایجاد می‌کند، آن را به مقدار `BasicProcess` تغییر می‌دهد و ارائه را ذخیره می‌کند.

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

## **بررسی اینکه آیا یک گره SmartArt مخفی است**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartartnode/#isHidden) نشان می‌دهد که آیا گره در مدل داده‌های SmartArt مخفی است یا نه. گره‌های مخفی می‌توانند در ساختار وجود داشته باشند حتی اگر طرح‌بندی انتخاب‌شده آن‌ها را به عنوان عناصر قابل مشاهده نمودار نمایش ندهد.

مثال زیر یک گره به شیء SmartArt که از مقدار `RadialCycle` از [SmartArtLayoutType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartartlayouttype/) استفاده می‌کند، افزوده و وضعیت مخفی بودن گره را بررسی می‌کند.

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

## **دریافت یا تنظیم طرح‌بندی نمودار سازمانی**

برای نمودارهای SmartArt که از یک طرح‌بندی نمودار سازمانی استفاده می‌کنند، [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) و [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) تعریف می‌کنند که گره‌های فرزند تحت یک گره والد چگونه چینش شوند. به عنوان مثال، می‌توانید گره‌های فرزند را طوری تنظیم کنید که از سمت چپ، راست یا هر دو طرف آویزان شوند، بسته به [OrganizationChartLayoutType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/organizationchartlayouttype/) انتخاب‌شده.

مثال زیر یک نمودار سازمانی ایجاد می‌کند و طرح‌بندی گره اول را به مقدار `LeftHanging` از [OrganizationChartLayoutType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/organizationchartlayouttype/) تنظیم می‌نماید.

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

## **ایجاد نمودار سازمانی تصویری**

نمودار سازمانی تصویری یک طرح‌بندی SmartArt است که برای نمودارهای سلسله‌مراتبی شامل جای‌دارهای تصویر طراحی شده است. هنگام افزودن شیء SmartArt به اسلاید، مقدار `PictureOrganizationChart` از [SmartArtLayoutType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartartlayouttype/) را استفاده کنید.

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

## **سوالات متداول**

**آیا SmartArt از انعکاس یا معکوس کردن برای زبان‌های راست به چپ پشتیبانی می‌کند؟**

بله. متد [SmartArt.setReversed](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartart/#setReversed) جهت نمودار را از چپ به راست به راست به چپ یا بالعکس تغییر می‌دهد، هنگامی که طرح‌بندی SmartArt انتخاب‌شده از معکوس شدن پشتیبانی می‌کند.

**چگونه می‌توانم SmartArt را به همان اسلاید یا به ارائه‌ای دیگر کپی کنم در حالی که قالب‌بندی حفظ شود؟**

می‌توانید [شکل SmartArt را کلون کنید](/slides/fa/python-java/shape-manipulations/) با استفاده از [ShapeCollection.addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addClone) یا کلون کردن کل اسلایدی که شامل SmartArt است [کلون اسلاید](/slides/fa/python-java/clone-slides/). هر دو روش اندازه، موقعیت و قالب‌بندی را حفظ می‌کنند.

**چگونه می‌توانم SmartArt را به تصویر رستری برای پیش‌نمایش یا صادرات وب رندر کنم؟**

[اسلاید را رندر کنید](/slides/fa/python-java/convert-powerpoint-to-png/) یا کل ارائه را به فرمت PNG یا JPEG. SmartArt به عنوان بخشی از اسلاید رندر می‌شود.

**چگونه می‌توان یک شیء SmartArt خاص را در یک اسلاید پیدا کنم اگر چندین مورد وجود داشته باشد؟**

یک مقدار متمایز برای [Shape.getAlternativeText](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getAlternativeText) یا [Shape.getName](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getName) روی شکل SmartArt تنظیم کنید، سپس آن مقدار را در [BaseSlide.getShapes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/#getShapes) جستجو کنید و در نهایت بررسی کنید که شکل مطابق یک [SmartArt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartart/) باشد.