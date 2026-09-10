---
title: مدیریت برچسب‌ها و داده‌های سفارشی در ارائه‌ها با استفاده از Python
linktitle: برچسب‌ها و داده‌های سفارشی
type: docs
weight: 300
url: /fa/python-java/managing-tags-and-custom-data/
keywords:
- ویژگی‌های سند
- برچسب
- داده‌های سفارشی
- XML سفارشی
- بخش XML سفارشی
- متادیتای XML
- ItemId
- افزودن برچسب
- مقادیر جفتی
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه برچسب‌ها و داده‌های XML سفارشی را در ارائه‌های PowerPoint با Aspose.Slides برای Python via Java مدیریت کنید، از جمله افزودن، خواندن، به‌روزرسانی، بررسی و حذف بخش‌های XML سفارشی."
---
## **مروری کلی**

این مقاله توضیح می‌دهد که Aspose.Slides چگونه با برچسب‌ها و داده‌های سفارشی در ارائه‌های PowerPoint کار می‌کند. داده‌های مخصوص ارائه می‌تواند به صورت برچسب یا بخش‌های XML سفارشی ذخیره شود. برچسب‌ها جفت‌های کلید‑مقدار رشته‌ای ساده هستند، در حالی که بخش‌های XML سفارشی می‌توانند متادیتای ساختاریافته و محتوای XML اختصاصی برنامه را ذخیره کنند.

Aspose.Slides APIهایی برای افزودن، خواندن، به‌روزرسانی، بررسی و حذف بخش‌های XML سفارشی در سطوح ارائه، اسلاید و شکل ارائه می‌دهد. بخش‌های XML سفارشی برای ادغام‌هایی که اطلاعاتی مانند شناسه‌های مدیریت سند، وضعیت جریان کار، متادیتای انطباق، داده‌های بایندینگ قالب یا سایر داده‌های ساختاریافته برنامه‌ای را داخل یک ارائه ذخیره می‌کنند، مفید هستند.

## **ذخیره‌سازی داده‌ها در فایل‌های ارائه**

فایل‌های PPTX—فایل‌هایی با پسوند `.pptx`—در قالب PresentationML ذخیره می‌شوند که بخشی از استاندارد Office Open XML است. Office Open XML ساختار بسته و روابط مورد استفاده برای ذخیره محتویات ارائه و داده‌های مرتبط را تعریف می‌کند.

یک ارائه شامل چندین بخش متصل به هم از طریق روابط است. برای مثال، بخش اسلاید شامل محتوای یک اسلاید واحد است و می‌تواند روابط صریحی به بخش‌های دیگر داشته باشد که توسط ISO/IEC 29500 تعریف می‌شود.

داده‌های سفارشی می‌توانند به صورت برچسب‌ها ([TagCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tagcollection/)) یا بخش‌های XML سفارشی ([CustomXmlPartCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpartcollection/)) ذخیره شوند. هر دو از طریق کلاس [CustomData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customdata/) در دسترس هستند.

{{% alert color="info" title="Note" %}}
برچسب‌ها جفت‌های کلید‑مقدار رشته‌ای ساده را ذخیره می‌کنند. بخش‌های XML سفارشی داده‌های XML ساختاریافته را ذخیره می‌کنند و می‌توانند به یک ارائه، اسلاید یا شکل مرتبط شوند.
{{% /alert %}}

## **کار با بخش‌های XML سفارشی**

متد [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customdata/#getCustomXmlParts) مجموعهٔ بخش‌های XML سفارشی مرتبط با شیء خاصی از ارائه را برمی‌گرداند. برای مثال:

- مجموعهٔ [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customdata/#getCustomXmlParts) ارائه شامل بخش‌های XML سفارشی مرتبط با خود ارائه است.
- مجموعهٔ [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customdata/#getCustomXmlParts) اسلاید شامل بخش‌های XML سفارشی مرتبط با آن اسلاید خاص است.
- مجموعهٔ [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customdata/#getCustomXmlParts) شکل شامل بخش‌های XML سفارشی مرتبط با آن شکل خاص است.

وقتی لازم است تمام بخش‌های XML سفارشی موجود در ارائه را صرف‌نظر از مکان ارتباطشان بررسی کنید، از [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getAllCustomXmlParts) استفاده کنید.

### **افزودن یک بخش XML سفارشی به ارائه**

از [CustomXmlPartCollection.add](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpartcollection/#add) برای افزودن داده‌های XML به مجموعهٔ بخش‌های XML سفارشی استفاده کنید. XML باید معتبر و غیر خالی باشد.

مثال زیر متادیتای ساختاریافته را به مجموعهٔ داده‌های سفارشی در سطح ارائه اضافه می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation()
try:
    custom_xml_content = '<?xml version="1.0" encoding="UTF-8"?><metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Draft</workflowState></metadata>'
    custom_xml_part = presentation.getCustomData().getCustomXmlParts().add(custom_xml_content)

    # دستور add یک شناسه را به‌صورت خودکار اختصاص می‌دهد. تنها زمانی که لازم باشد یک UUID خاص تنظیم کنید.
    item_id = UUID.randomUUID()
    custom_xml_part.setItemId(item_id)

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

متد [add](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpartcollection/#add) همچنین می‌تواند XML را به صورت آرایهٔ بایت یا جریان ورودی دریافت کند؛ که وقتی محتوای XML قبلاً به شکل باینری موجود باشد، مفید است.

### **افزودن یک بخش XML سفارشی به اسلاید یا شکل**

داده‌های XML سفارشی می‌توانند به یک اسلاید یا شکل خاص، نه کل ارائه، مرتبط شوند. این زمانی مفید است که متادیتا تنها به یک شیء خاص اشاره داشته باشد، مانند کلید قالب، شناسهٔ رکورد خارجی یا اطلاعات بایندینگ.

مثال زیر یک بخش XML سفارشی را به یک اسلاید و بخش دیگری را به یک شکل اضافه می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_xml_content = '<slideMetadata xmlns="urn:example:slides"><templateKey>TitleSlide</templateKey></slideMetadata>'
    slide.getCustomData().getCustomXmlParts().add(slide_xml_content)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80)
    shape.getTextFrame().setText("Customer data")
    shape_xml_content = '<shapeMetadata xmlns="urn:example:shapes"><recordId>CRM-4281</recordId></shapeMetadata>'
    shape.getCustomData().getCustomXmlParts().add(shape_xml_content)

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

سطحی که یک بخش به آن اضافه می‌شود، تعیین می‌کند کدام مجموعهٔ [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customdata/#getCustomXmlParts) شامل رابطه به آن بخش باشد. داده‌های سطح ارائه برای متادیتای سراسری سند مناسب هستند، داده‌های سطح اسلاید برای اطلاعاتی که به یک اسلاید خاص تعلق دارد، و داده‌های سطح شکل برای متادیتای مربوط به یک شکل منفرد.

### **لیست و بررسی تمام بخش‌های XML سفارشی**

از [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getAllCustomXmlParts) برای بازیابی تمام بخش‌های XML سفارشی از یک ارائه استفاده کنید. هر [CustomXmlPart](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpart/) شناسه، محتوای XML و طرح‌واره‌های فضای نام مرتبط را نشان می‌دهد.

مثال زیر تمام بخش‌های XML سفارشی و طرح‌واره‌های فضای نام آن‌ها را فهرست می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        print("ItemId:", custom_xml_part.getItemId())
        print("XML:")
        print(custom_xml_part.getXmlAsString())

        for namespace_schema in custom_xml_part.getNamespaceSchemas():
            print("Namespace schema:", namespace_schema)

        print()
finally:
    presentation.dispose()
```

متد [CustomXmlPart.getNamespaceSchemas](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpart/#getNamespaceSchemas) طرح‌واره‌های XML مرتبط با بخش XML سفارشی را برمی‌گرداند. این اطلاعات می‌تواند هنگام بررسی ارائه‌هایی که XML تولید شده توسط سیستم‌های خارجی را شامل می‌شوند، مفید باشد.

### **خواندن و به‌روزرسانی محتوای XML و ItemId**

از [CustomXmlPart.getXmlAsString](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpart/#getXmlAsString) و [setXmlAsString](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpart/#setXmlAsString) برای کار با XML به صورت رشتهٔ UTF‑8 استفاده کنید، یا از [getXmlData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpart/#getXmlData) و [setXmlData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpart/#setXmlData) برای کار با بایت‌های خام XML.

متد [CustomXmlPart.getItemId](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpart/#getItemId) UUID شناسایی کنندهٔ بخش XML سفارشی در سند Office Open XML را برمی‌گرداند. وقتی یک ادغام به یک شناسهٔ جدید نیاز دارد، از [setItemId](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpart/#setItemId) استفاده کنید.

مثال زیر محتویات XML و شناسه را به‌روزرسانی می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getAllCustomXmlParts()
    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]

        # XML فعلی را به‌عنوان متن بخوانید.
        current_xml_content = custom_xml_part.getXmlAsString()
        print(current_xml_content)

        # XML را به‌عنوان رشته UTF-8 به‌روز کنید.
        custom_xml_content = '<metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Approved</workflowState></metadata>'
        custom_xml_part.setXmlAsString(custom_xml_content)

        # متد getXmlData محتوای XML را به‌صورت بایت‌های خام فراهم می‌کند.
        custom_xml_data = custom_xml_part.getXmlData()
        print(bytes(custom_xml_data).decode("utf-8"))

        # شناسه را هنگام نیاز ادغام جایگزین کنید.
        item_id = UUID.randomUUID()
        custom_xml_part.setItemId(item_id)

        presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx)
    else:
        print("No custom XML parts found.")
finally:
    presentation.dispose()
```

هنگام فراخوانی [setXmlAsString](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpart/#setXmlAsString) یا [setXmlData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpart/#setXmlData)، XML معتبر و غیر خالی ارائه کنید. بسته به این که برنامه عمدتاً با رشته‌ها یا داده‌های بایتی کار می‌کند، از یکی از این دو نمایندگی استفاده کنید.

### **حذف یک بخش XML سفارشی**

Aspose.Slides چند روش برای حذف داده‌های XML سفارشی ارائه می‌دهد:

- [CustomXmlPart.remove](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpart/#remove) بخش XML سفارشی را از ارائه حذف می‌کند.
- [CustomXmlPartCollection.remove](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpartcollection/#remove) بخش خاصی را از یک مجموعهٔ بخش‌های XML سفارشی حذف می‌کند.
- [CustomXmlPartCollection.removeAt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpartcollection/#removeAt) بخش را در یک اندیس مشخص از مجموعه حذف می‌کند.
- [CustomXmlPartCollection.clear](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpartcollection/#clear) تمام بخش‌ها را از یک مجموعهٔ خاص حذف می‌کند.

مثال زیر یک بخش XML سفارشی در سطح ارائه را از طریق مرجع حذف می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_part = custom_xml_parts.get_Item(0)
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

اگر قبلاً یک [CustomXmlPart](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpart/) داشته باشید و بخواهید آن را مستقیماً از ارائه حذف کنید، به جای اشاره به یک مجموعه خاص، متد [CustomXmlPart.remove](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpart/#remove) را فراخوانی کنید.

همچنین می‌توانید مورد را بر اساس اندیس حذف کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_parts.removeAt(0)
finally:
    presentation.dispose()
```

### **پاک‌سازی تمام بخش‌های XML سفارشی از یک مجموعه**

وقتی باید تمام بخش‌های XML سفارشی مرتبط با یک شیء خاص از ارائه حذف شوند، از [clear](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpartcollection/#clear) استفاده کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear()

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

متد [clear](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpartcollection/#clear) فقط بر روی مجموعهٔ انتخاب شده تأثیر می‌گذارد. به عنوان مثال، پاک‌سازی مجموعهٔ یک اسلاید، مجموعهٔ سطح ارائه یا سطح شکل را پاک نمی‌کند.

برای حذف هر بخش XML سفارشی در ارائه، می‌توانید از طریق [getAllCustomXmlParts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getAllCustomXmlParts) پیمایش کنید و هر بخش را حذف نمایید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **کار با بخش‌های XML سفارشی پیوندی یا مشترک**

در یک ارائه Office Open XML، یک بخش XML سفارشی می‌تواند از بیش از یک شیء ارائه ارجاع داده شود. برای مثال، یک فایل موجود می‌تواند روابطی از چندین اسلاید یا شکل به همان بخش XML سفارشی پایه داشته باشد.

یک بخش مشترک باید به عنوان یک شیء داده با چندین ارجاع در نظر گرفته شود:

- به‌روزرسانی آن با [setXmlAsString](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpart/#setXmlAsString)، [setXmlData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpart/#setXmlData) یا [setItemId](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpart/#setItemId) باعث تغییر بخش XML سفارشی زیرین می‌شود، بنابراین تغییر در هر جایی که آن بخش ارجاع شده است اعمال می‌شود.
- [getItemId](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpart/#getItemId) می‌تواند برای شناسایی یک بخش XML سفارشی یکسان هنگام بررسی مجموعه‌های سطح شیء استفاده شود.
- حذف یک بخش از یک مجموعهٔ خاص [getCustomXmlParts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customdata/#getCustomXmlParts) آن را فقط از آن مجموعه حذف می‌کند. وقتی هدف حذف بخش از خود ارائه است، از [CustomXmlPart.remove](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpart/#remove) استفاده کنید.
- قبل از حذف یا جایگزینی یک بخش مشترک، مجموعه‌های سطح شیء را بررسی کنید تا ببینید آیا اسلایدها یا شکل‌های دیگر هنوز به آن ارجاع دارند یا نه.

اورلودهای [add](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpartcollection/#add) یک بخش XML سفارشی جدید از محتوای XML ایجاد می‌کنند؛ آن‌ها ورودی یک [CustomXmlPart](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpart/) موجود را قبول نمی‌کنند. بنابراین، روابط مشترک بیشتر زمانی مشاهده می‌شوند که ارائه‌هایی که از قبل شامل آن‌ها هستند، بارگذاری می‌شوند.

مثال زیر مجموعه‌های سطح ارائه، اسلاید و شکل را بر اساس `ItemId` بررسی می‌کند و بخش‌هایی که از بیش از یک مکان ارجاع شده‌اند را گزارش می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for i in range(custom_xml_parts.size()):
            custom_xml_part = custom_xml_parts.get_Item(i)
            item_id = str(custom_xml_part.getItemId())
            references_by_item_id.setdefault(item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.getCustomData().getCustomXmlParts())

    for slide_index in range(presentation.getSlides().size()):
        slide = presentation.getSlides().get_Item(slide_index)
        register_custom_xml_parts(f"Slide {slide_index + 1}", slide.getCustomData().getCustomXmlParts())

        for shape_index in range(slide.getShapes().size()):
            shape = slide.getShapes().get_Item(shape_index)
            register_custom_xml_parts(f"Slide {slide_index + 1}, shape {shape_index}", shape.getCustomData().getCustomXmlParts())

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part:", item_id)
            for owner_name in owner_names:
                print("  Referenced by:", owner_name)
finally:
    presentation.dispose()
```

این نوع بررسی قبل از تغییر یا حذف داده‌های XML سفارشی در ارائه‌های تولید شده توسط سیستم‌های خارجی مفید است، زیرا یک بخش متادیتا ممکن است در بیش از یک رابطه شرکت داشته باشد.

## **دریافت مقدار برچسب‌ها**

در اسلایدها، یک برچسب متناظر با متد [DocumentProperties.getKeywords](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#getKeywords) است. این کد نمونه نشان می‌دهد چگونه می‌توان مقدار یک برچسب را با Aspose.Slides برای Python via Java برای [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) دریافت کرد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    keywords = presentation.getDocumentProperties().getKeywords()
finally:
    presentation.dispose()
```

## **افزودن برچسب‌ها به ارائه‌ها**

Aspose.Slides امکان افزودن برچسب‌ها به ارائه‌ها را فراهم می‌کند. یک برچسب معمولاً شامل دو مورد است:

- نام یک ویژگی سفارشی، برای مثال `MyTag`؛
- مقدار ویژگی سفارشی، برای مثال `My Tag Value`.

اگر نیاز به طبقه‌بندی ارائه‌ها بر اساس یک قاعده یا ویژگی خاص داشته باشید، می‌توانید برای این منظور برچسب اضافه کنید. به عنوان مثال، اگر می‌خواهید ارائه‌های کشورهای آمریکای شمالی را دسته‌بندی کنید، می‌توانید یک برچسب «North American» ایجاد کرده و کشور مربوطه را به‌عنوان مقدار آن تنظیم کنید.

این کد نمونه نشان می‌دهد چگونه یک برچسب به یک [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) اضافه شود با استفاده از Aspose.Slides برای Python via Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    tags = presentation.getCustomData().getTags()
    tags.set_Item("MyTag", "My Tag Value")
finally:
    presentation.dispose()
```

برچسب‌ها می‌توانند برای یک [Slide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/) نیز تنظیم شوند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

یا برای یک [Shape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/) جداگانه:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50)
    shape.getTextFrame().setText("My text")
    shape.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

### **محدودیت‌ها**

برچسب‌هایی که از طریق مجموعهٔ [CustomData.getTags](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customdata/#getTags) اضافه می‌شوند، تنها در فایل PowerPoint ذخیره می‌شوند. آن‌ها **به** ساختار برچسب PDF هنگام صادر کردن ارائه به PDF منتقل نمی‌شوند. بنابراین، یک شناسهٔ سفارشی که به‌عنوان برچسب اختصاص داده شده است، نمی‌تواند از PDF برچسب‌دار بازیابی شود.

**راه‌حل**: می‌توانید یک شناسهٔ سفارشی را در **متن Alt** شیء (به عنوان مثال، [Shape.setAlternativeText](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#setAlternativeText) با مقدار `"MyId"` ) ذخیره کنید. پس از صادر کردن به PDF، متن Alt ممکن است در ساختار برچسب PDF ظاهر شود.

## **پرسش‌های متداول**

**آیا می‌توانم تمام برچسب‌ها را از یک ارائه، اسلاید یا شکل در یک عملیات حذف کنم؟**

بله. مجموعهٔ [tag collection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tagcollection/) از عملیات [clear](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tagcollection/#clear) پشتیبانی می‌کند که تمام جفت‌های کلید‑مقدار را به‌طور همزمان حذف می‌نماید.

**چگونه می‌توانم یک برچسب واحد را براساس نام آن بدون پیمایش کل مجموعه حذف کنم؟**

از متد [remove](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tagcollection/#remove) روی مجموعهٔ برچسب‌ها استفاده کنید تا برچسب را با کلیدش حذف نمایید.

**چگونه می‌توانم فهرست کامل نام‌های برچسب‌ها را برای تجزیه و تحلیل یا فیلتر کردن به‌دست آورم؟**

از متد [getNamesOfTags](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tagcollection/#getNamesOfTags) روی مجموعهٔ برچسب‌ها استفاده کنید؛ این متد یک آرایه شامل تمام نام‌های برچسب را برمی‌گرداند.

**چگونه می‌توانم تمام بخش‌های XML سفارشی را بدون در نظر گرفتن محل ذخیره‌سازی پیدا کنم؟**

از [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getAllCustomXmlParts) برای بازیابی تمام بخش‌های XML سفارشی در ارائه استفاده کنید.

**کدام متد را باید برای به‌روزرسانی یک بخش XML سفارشی انتخاب کنم: [getXmlAsString]/[setXmlAsString] یا [getXmlData]/[setXmlData]؟**

زمانی که برنامه با متن XML UTF‑8 کار می‌کند، از [getXmlAsString](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpart/#getXmlAsString) و [setXmlAsString](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpart/#setXmlAsString) استفاده کنید. وقتی XML به صورت آرایهٔ بایت موجود است یا پردازش باینری ترجیح داده می‌شود، از [getXmlData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpart/#getXmlData) و [setXmlData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/customxmlpart/#setXmlData) استفاده کنید. هر دو نمایندگی به محتوای XML یک بخش XML سفارشی اشاره دارند.