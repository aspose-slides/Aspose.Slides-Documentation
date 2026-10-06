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
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "یاد بگیرید چگونه SmartArt در PowerPoint را با Aspose.Slides برای Python از طریق Java بسازید و ویرایش کنید، با استفاده از نمونه‌های کد واضح که طراحی اسلاید و خودکارسازی را تسریع می‌کنند."
---
## **نمای کلی**

SmartArt یک نمودار PowerPoint ساخته شده از گره‌ها، اشکال گره و یک طرح‌بندی است. با Aspose.Slides for Python via Java می‌توانید SmartArt ایجاد کنید، متن را از گره‌های آن بخوانید، طرح‌بندی آن را تغییر دهید، گره‌های پنهان را بررسی کنید، طرح‌بندی نمودار سازمانی را پیکربندی کنید و نمودارهای سازمانی تصویری ایجاد کنید.

## **دریافت متن از یک شیء SmartArt**

یک گره SmartArt می‌تواند یک یا چند شکل داشته باشد. برای خواندن متن از اشکال گره، از طریق [SmartArt.getAllNodes](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#getAllNodes) پیمایش کنید، سپس [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) بازگردانده شده توسط [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartshape/#getTextFrame) را بخوانید.

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

طرح‌بندی SmartArt تعیین می‌کند گره‌ها چگونه چیده و به هم متصل می‌شوند. مثال زیر یک شیء SmartArt را با مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList` ایجاد می‌کند، آن را به مقدار `BasicProcess` تغییر می‌دهد و ارائه را ذخیره می‌کند. موقعیت و اندازه‌ای که به [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSmartArt) پاس داده می‌شود بر حسب نقطه (points) اندازه‌گیری می‌شود. برای تغییر طرح‌بندی از [SmartArt.setLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setLayout) استفاده کنید.

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

## **بررسی اینکه آیا گره SmartArt پنهان است**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#isHidden) نشان می‌دهد آیا گره در مدل داده‌های SmartArt مخفی است یا خیر. گره‌های مخفی می‌توانند در ساختار وجود داشته باشند حتی زمانی که طرح‌بندی انتخاب‌شده آن‌ها را به‌عنوان عناصر نمایان نمودار نشان نمی‌دهد.

مثال زیر یک گره به شیء SmartArt که از مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `RadialCycle` استفاده می‌کند، اضافه می‌کند و وضعیت مخفی بودن گره اضافه‌شده را بررسی می‌کند. در صورت مخفی بودن گره، پیغامی چاپ می‌شود و نمودار ذخیره می‌شود.

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

## **دریافت یا تنظیم طرح‌بندی نمودار سازمانی**

برای نمودارهای SmartArt که از طرح‌بندی نمودار سازمانی استفاده می‌کنند، [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) و [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) نحوه چیدمان گره‌های فرزند زیر یک گره والد را مشخص می‌کنند. به‌عنوان مثال می‌توانید گره‌های فرزند را طوری تنظیم کنید که از سمت چپ، راست یا هر دو طرف آویزان شوند، بسته به مقدار انتخاب‌شدهٔ [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/).

مثال زیر یک نمودار سازمانی ایجاد می‌کند و برای اولین گره، طرح‌بندی [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` را تنظیم می‌کند. اندیس صفر مبنای صفر، اولین گره سطح بالایی را انتخاب می‌کند؛ گره‌های فرزند آن از ترتیب انتخاب‌شده استفاده می‌کنند. سپس ارائهٔ اصلاح‌شده ذخیره می‌شود.

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

## **ایجاد نمودار سازمانی تصویر**

نمودار سازمانی تصویر یک طرح‌بندی SmartArt است که برای نمودارهای سلسله‌مراتبی شامل محل‌نگهدارهای تصویر طراحی شده است. هنگام افزودن شیء SmartArt به یک اسلاید، مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` را استفاده کنید. این مثال یک نمودار با محل‌نگهدارهای تصویر ذخیره می‌کند؛ اما این محل‌نگهدارها را با تصویر پر نمی‌کند.

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

## **تبدیل نمودارهای قدیمی به گروه‌هایی از اشکال**

هنگام به‌روزرسانی یک ارائهٔ موجود، ممکن است نیاز داشته باشید نمودار سازمانی که ابتدا در PowerPoint 97–2003 ایجاد شده بود را به‌روز کنید. Aspose.Slides این نمودارهای قدیمی را به عنوان اشیای [LegacyDiagram](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/) نمایش می‌دهد. برای تبدیل یک نمودار به گروهی از اشکال و امکان ویرایش عناصر بصری به‌صورت جداگانه از [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/#convertToGroupShape) استفاده کنید. برای جزئیات بیشتر به [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/) مراجعه کنید.

تبدیل یک گروه جدید به مجموعهٔ اشکال اضافه می‌کند بدون این‌که نمودار اصلی حذف شود. پس از موفقیت در تبدیل، برای جلوگیری از محتوای تکراری با استفاده از [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) نمودار اصلی را حذف کنید. قبل از تبدیل، نمودارهای قدیمی را در یک لیست جمع‌آوری کنید تا افزودن و حذف اشکال باعث اختلال در تکرار نشوند.

مثال زیر یک ارائه را باز می‌کند، هر اسلاید را جستجو می‌کند، نمودارها را به گروه‌هایی از اشکال تبدیل می‌کند و ارائهٔ به‌روزشده را به‌صورت PPTX ذخیره می‌کند.

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

ارائهٔ ذخیره‌شده شامل گروه‌های قابل ویرایش از اشکال به‌جای نمودارهای قدیمی تبدیل‌شده است و دیگر هیچ نمودار اصلی‌ای در کنار آن‌ها وجود ندارد. فایل PPTX را در PowerPoint باز کنید تا عناصر فردی داخل هر گروه، مانند متن، رنگ‌پر یا موقعیت آن‌ها را ویرایش کنید.

## **پرسش‌های متداول**

**آیا SmartArt از آینه‌سازی یا معکوس‌سازی برای زبان‌های راست به چپ (RTL) پشتیبانی می‌کند؟**

بله. متد [SmartArt.setReversed](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setReversed) جهت نمودار را از چپ به راست به راست به چپ یا بالعکس تغییر می‌دهد، به‌شرطی که طرح‌بندی SmartArt انتخاب‌شده از معکوس‌سازی پشتیبانی کند.

**چگونه می‌توانم SmartArt را در همان اسلاید یا در ارائهٔ دیگری کپی کنم در حالی که قالب‌بندی حفظ می‌شود؟**

می‌توانید [یک نسخه از شکل SmartArt ایجاد کنید](/slides/fa/python-java/shape-manipulations/) با استفاده از [ShapeCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addClone) یا [یک نسخه از کل اسلاید ایجاد کنید](/slides/fa/python-java/clone-slides/) که SmartArt را شامل می‌شود. هر دو روش اندازه، موقعیت و قالب‌بندی را حفظ می‌کنند.

**چگونه می‌توانم SmartArt را به یک تصویر رستر برای پیش‌نمایش یا خروجی وب رندر کنم؟**

[اسلاید را رندر کنید](/slides/fa/python-java/convert-powerpoint-to-png/) یا کل ارائه را به PNG یا JPEG تبدیل کنید. SmartArt به‌عنوان بخشی از اسلاید رندر می‌شود.

**چگونه می‌توانم یک شیء SmartArt خاص را در یک اسلاید پیدا کنم اگر چندین مورد وجود داشته باشد؟**

از [Shape.setAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setAlternativeText) یا [Shape.setName](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setName) برای اختصاص متن جایگزین یا نام متمایزی به شکل SmartArt استفاده کنید، سپس آن مقدار را در [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) جستجو کنید و سپس بررسی کنید که شکل یافت‌شده یک [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/) باشد.