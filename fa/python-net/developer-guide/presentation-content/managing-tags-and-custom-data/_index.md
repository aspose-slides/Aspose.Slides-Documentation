---
title: مدیریت برچسب‌ها و داده‌های سفارشی در ارائه‌ها با پایتون
linktitle: برچسب‌ها و داده‌های سفارشی
type: docs
weight: 300
url: /fa/python-net/managing-tags-and-custom-data/
keywords:
- ویژگی‌های سند
- برچسب
- داده‌های سفارشی
- XML سفارشی
- بخش XML سفارشی
- فراداده XML
- ItemId
- افزودن برچسب
- جفت مقادیر
- PowerPoint
- ارائه
- پایتون
- Aspose.Slides
description: "بیاموزید چگونه برچسب‌ها و داده‌های XML سفارشی را در ارائه‌های PowerPoint با Aspose.Slides برای پایتون از طریق .NET مدیریت کنید، شامل افزودن، خواندن، به‌روزرسانی، بررسی و حذف بخش‌های XML سفارشی."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که Aspose.Slides چگونه با برچسب‌ها و داده‌های سفارشی در ارائه‌های PowerPoint کار می‌کند. داده‌های خاص یک ارائه می‌تواند به‌صورت برچسب یا بخش‌های XML سفارشی ذخیره شود. برچسب‌ها جفت‌های ساده‌ی کلید‑مقدار رشته‌ای هستند، در حالی که بخش‌های XML سفارشی می‌توانند فراداده ساختاریافته و بارهای XML مخصوص برنامه را ذخیره کنند.

Aspose.Slides APIهایی برای افزودن، خواندن، به‌روزرسانی، بررسی و حذف بخش‌های XML سفارشی در سطوح ارائه، اسلاید و شکل فراهم می‌کند. بخش‌های XML سفارشی برای یکپارچه‌سازی‌هایی که اطلاعاتی مانند شناسه‌های مدیریت سند، وضعیت گردش کار، فراداده‌های انطباق، داده‌های بایندینگ قالب یا سایر داده‌های ساختاریافتهٔ برنامه‌محور را داخل یک ارائه ذخیره می‌کنند، مفید هستند.

## **ذخیره‌سازی داده‌ها در فایل‌های ارائه**

فایل‌های PPTX — فایل‌هایی با پسوند `.pptx` — در قالب PresentationML ذخیره می‌شوند که بخشی از مشخصات Office Open XML است. Office Open XML ساختار بسته و روابط استفاده‑شده برای ذخیره محتوای ارائه و داده‌های مرتبط را تعریف می‌کند.

یک ارائه شامل بخش‌های متعدد است که توسط روابط به هم متصل می‌شوند. برای مثال، یک بخش اسلاید شامل محتوای یک اسلاید است و می‌تواند روابط صریحی به سایر بخش‌ها داشته باشد که در ISO/IEC 29500 تعریف شده‌اند.

داده‌های سفارشی می‌توانند به‌صورت برچسب‌ها ([TagCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/tagcollection/)) یا بخش‌های XML سفارشی ([CustomXmlPartCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/customxmlpartcollection/)) ذخیره شوند. هر دو از طریق کلاس [`CustomData`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/customdata/) در دسترس هستند.

{{% alert color="primary" %}}
برچسب‌ها جفت‌های سادهٔ کلید‑مقدار رشته‌ای را ذخیره می‌کنند. بخش‌های XML سفارشی داده‌های XML ساختاریافته را ذخیره می‌کنند و می‌توانند به یک ارائه، اسلاید یا شکل مرتبط شوند.
{{% /alert %}}

## **کار با بخش‌های XML سفارشی**

خاصیت [`CustomData.custom_xml_parts`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/customdata/custom_xml_parts/) مجموعهٔ بخش‌های XML سفارشی مرتبط با شیء ارائهٔ خاص را برمی‌گرداند. برای مثال:

- `presentation.custom_data.custom_xml_parts` شامل بخش‌های XML سفارشی مرتبط با خود ارائه است.
- `slide.custom_data.custom_xml_parts` شامل بخش‌های XML سفارشی مرتبط با یک اسلاید خاص است.
- `shape.custom_data.custom_xml_parts` شامل بخش‌های XML سفارشی مرتبط با یک شکل خاص است.

از [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/all_custom_xml_parts/) زمانی که نیاز به بررسی تمام بخش‌های XML سفارشی در ارائه دارید، بدون توجه به محل ارتباط، استفاده کنید.

### **افزودن یک بخش XML سفارشی به ارائه**

از [`CustomXmlPartCollection.add`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/customxmlpartcollection/add/) برای افزودن داده‌های XML به مجموعهٔ بخش‌های XML سفارشی استفاده کنید. XML باید معتبر و غیرخالی باشد.

مثال زیر فرادادهٔ ساختاریافته را به مجموعهٔ داده‌های سفارشی در سطح ارائه اضافه می‌کند:

```py
import uuid
import aspose.slides as slides

custom_xml_content = (
    '<?xml version="1.0" encoding="UTF-8"?>'
    '<metadata xmlns="urn:example:metadata">'
    '<documentId>DOC-1001</documentId>'
    '<workflowState>Draft</workflowState>'
    '</metadata>'
)

with slides.Presentation() as presentation:
    custom_xml_part = presentation.custom_data.custom_xml_parts.add(custom_xml_content)

    # متد add به‌صورت خودکار یک شناسه اختصاص می‌دهد. فقط در صورت نیاز یک GUID خاص تنظیم کنید.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("presentation_with_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

متد `add` می‌تواند XML را به‌عنوان آرایه بایتی یا جریان نیز بپذیرد که زمانی مفید است که محتوی XML از پیش به شکل باینری موجود باشد.

### **افزودن یک بخش XML سفارشی به اسلاید یا شکل**

داده‌های XML می‌توانند به یک اسلاید یا شکل خاص به‌جای کل ارائه مرتبط شوند. این کار زمانی مفید است که فراداده تنها به یک شیء خاص مانند کلید قالب، شناسهٔ رکورد خارجی یا اطلاعات بایندینگ مربوط باشد.

مثال زیر یک بخش XML سفارشی را به یک اسلاید و دیگری را به یک شکل اضافه می‌کند:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.custom_data.custom_xml_parts.add(
        '<slideMetadata xmlns="urn:example:slides">'
        '<templateKey>TitleSlide</templateKey>'
        '</slideMetadata>'
    )

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 250, 80)

    shape.text_frame.text = "Customer data"
    shape.custom_data.custom_xml_parts.add(
        '<shapeMetadata xmlns="urn:example:shapes">'
        '<recordId>CRM-4281</recordId>'
        '</shapeMetadata>'
    )

    presentation.save("object_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

سطحی که بخش به آن اضافه می‌شود تعیین می‌کند کدام مجموعهٔ `custom_data.custom_xml_parts` شیء شامل رابطهٔ آن بخش است. داده‌های سطح ارائه برای فرادادهٔ سراسری سند مناسب‌اند، داده‌های سطح اسلاید برای اطلاعات مربوط به اسلاید خاص و داده‌های سطح شکل برای فرادادهٔ مرتبط با یک شکل منفرد.

### **فهرست و بررسی تمام بخش‌های XML سفارشی**

از [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/all_custom_xml_parts/) برای بازیابی تمام بخش‌های XML سفارشی از یک ارائه استفاده کنید. هر [`CustomXmlPart`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/customxmlpart/) شناسه، محتوای XML و طرح‌نامه‌های فضای نام مرتبط خود را نشان می‌دهد.

مثال زیر تمام بخش‌های XML سفارشی و طرح‌نامه‌های فضای نام آن‌ها را فهرست می‌کند:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        print("ItemId: " + str(custom_xml_part.item_id))
        print("XML:")
        print(custom_xml_part.xml_as_string)

        for namespace_schema in custom_xml_part.namespace_schemas:
            print("Namespace schema: " + namespace_schema)

        print()
```

خاصیت [`CustomXmlPart.namespace_schemas`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/customxmlpart/namespace_schemas/) طرح‌نامه‌های XML مرتبط با بخش XML سفارشی را برمی‌گرداند. این اطلاعات می‌تواند هنگام بررسی ارائه‌هایی که XML تولید شده توسط سیستم‌های خارجی را شامل می‌شوند، مفید باشد.

### **خواندن و به‌روزرسانی محتوای XML و ItemId**

از [`CustomXmlPart.xml_as_string`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/customxmlpart/xml_as_string/) برای کار با XML به‌صورت رشتهٔ UTF‑8 یا از [`CustomXmlPart.xml_data`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/customxmlpart/xml_data/) برای کار با بایت‌های خام XML استفاده کنید. هر دو خاصیت قابل خواندن و به‌روزرسانی هستند.

خاصیت [`CustomXmlPart.item_id`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/customxmlpart/item_id/) GUID شناسایی‌کنندهٔ بخش XML سفارشی در سند Office Open XML را شامل می‌شود. در صورت نیاز یکپارچه‌سازی به شناسهٔ جدیدی، می‌تواند تغییر یابد.

مثال زیر محتوای XML و شناسه را به‌روزرسانی می‌کند:

```py
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_part = presentation.all_custom_xml_parts[0]

    # XML فعلی را به‌صورت متن بخوانید.
    current_xml_content = custom_xml_part.xml_as_string
    print(current_xml_content)

    # XML را به‌عنوان رشته UTF-8 به‌روز کنید.
    custom_xml_part.xml_as_string = (
        '<metadata xmlns="urn:example:metadata">'
        '<documentId>DOC-1001</documentId>'
        '<workflowState>Approved</workflowState>'
        '</metadata>'
    )

    # xml_data همان محتوای XML را به‌صورت بایت‌های خام ارائه می‌دهد.
    custom_xml_data = custom_xml_part.xml_data
    print(custom_xml_data.decode("utf-8"))

    # در صورت نیاز یکپارچه‌سازی، شناسه را جایگزین کنید.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("updated_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

هنگام اختصاص `xml_as_string` یا `xml_data`، XML معتبر و غیرخالی فراهم کنید. بسته به این که برنامه بیشتر با رشته‌ها یا داده‌های بایتی کار می‌کند، یکی از این دو نمایندگی را استفاده کنید.

### **حذف یک بخش XML سفارشی**

Aspose.Slides راه‌های متعددی برای حذف داده‌های XML سفارشی ارائه می‌دهد:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/customxmlpart/remove/) بخش XML سفارشی را از ارائه حذف می‌کند.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/customxmlpartcollection/remove/) یک بخش خاص را از مجموعهٔ بخش‌های XML سفارشی حذف می‌کند.
- [`CustomXmlPartCollection.remove_at`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/customxmlpartcollection/remove_at/) بخش را در ایندکس مشخصی از مجموعه حذف می‌کند.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/customxmlpartcollection/clear/) تمام بخش‌ها را از یک مجموعهٔ خاص حذف می‌کند.

مثال زیر یک بخش XML سفارشی سطح ارائه را بر پایهٔ ارجاع حذف می‌کند:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_parts = presentation.custom_data.custom_xml_parts

    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

اگر قبلاً یک `CustomXmlPart` دارید و می‌خواهید آن بخش را از ارائه حذف کنید نه از یک مجموعهٔ خاص، متد `custom_xml_part.remove()` را فراخوانی کنید.

همچنین می‌توانید با استفاده از ایندکس حذف کنید:

```py
presentation.custom_data.custom_xml_parts.remove_at(0)
```

### **پاک‌سازی تمام بخش‌های XML سفارشی از یک مجموعه**

از `clear` زمانی استفاده کنید که تمام بخش‌های XML سفارشی مرتبط با یک شیء ارائه باید حذف شوند.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.slides[0].custom_data.custom_xml_parts.clear()

    presentation.save("slide_custom_xml_cleared.pptx", slides.export.SaveFormat.PPTX)
```

`clear` فقط بر مجموعهٔ انتخاب‌شده اثر می‌گذارد. برای مثال، پاک‌سازی مجموعهٔ یک اسلاید، مجموعهٔ سطح ارائه یا سطح شکل را پاک نمی‌کند.

برای حذف هر بخش XML سفارشی در ارائه، می‌توانید روی `all_custom_xml_parts` حلقه بزنید و هر بخش را حذف کنید:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

### **مدیریت بخش‌های XML سفارشی پیوندی یا مشترک**

در یک ارائه Office Open XML، همان بخش XML سفارشی می‌تواند از بیش از یک شیء ارائه ارجاع داده شود. برای مثال، یک فایل موجود می‌تواند روابطی از اسلایدها یا اشکال متعدد به همان بخش XML سفارشی زیرین داشته باشد.

یک بخش مشترک باید به‌عنوان یک شیء دادهٔ واحد با ارجاعات متعدد در نظر گرفته شود:

- به‌روزرسانی `xml_as_string`، `xml_data` یا `item_id` بخش XML سفارشی زیرین را تغییر می‌دهد، بنابراین تغییر در هر مکانی که آن بخش ارجاع شده باشد، اعمال می‌شود.
- `item_id` می‌تواند برای شناسایی همان بخش XML سفارشی هنگام بررسی مجموعه‌های سطح شیء استفاده شود.
- حذف یک بخش از یک مجموعهٔ `custom_xml_parts` خاص فقط آن را از همان مجموعه حذف می‌کند. برای حذف کامل بخش از ارائه، از `CustomXmlPart.remove()` استفاده کنید.
- قبل از حذف یا جایگزینی یک بخش مشترک، مجموعه‌های سطح شیء را بررسی کنید تا مشخص شود آیا اسلایدها یا اشکال دیگر هنوز به آن ارجاع دارند یا نه.

 overloadهای `add` یک بخش XML سفارشی جدید از محتوای XML ایجاد می‌کنند؛ آن‌ها یک `CustomXmlPart` موجود را می‌پذیرند. بنابراین روابط مشترک بیش‌تر در هنگام بارگذاری ارائه‌هایی که از پیش شامل آن‌ها هستند، مشاهده می‌شود.

مثال زیر مجموعه‌های سطح ارائه، اسلاید و شکل را بر پایهٔ `item_id` بررسی می‌کند و بخش‌های ارجاع داده شده از بیش از یک مکان را گزارش می‌دهد:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for custom_xml_part in custom_xml_parts:
            references_by_item_id.setdefault(custom_xml_part.item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.custom_data.custom_xml_parts)

    for slide_index, slide in enumerate(presentation.slides):
        register_custom_xml_parts(
            "Slide " + str(slide_index + 1),
            slide.custom_data.custom_xml_parts
        )

        for shape_index, shape in enumerate(slide.shapes):
            register_custom_xml_parts(
                "Slide " + str(slide_index + 1) + ", shape " + str(shape_index),
                shape.custom_data.custom_xml_parts
            )

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part: " + str(item_id))

            for owner_name in owner_names:
                print("  Referenced by: " + owner_name)
```

این نوع بررسی قبل از تغییر یا حذف داده‌های XML سفارشی در ارائه‌های تولید شده توسط سیستم‌های خارجی مفید است، چرا که همان بخش فراداده ممکن است در بیش از یک رابطه شرکت داشته باشد.

## **دریافت مقادیر برچسب‌ها**

در Slides، یک برچسب معادل ویژگی `DocumentProperties.keywords` است. این کد نمونه نشان می‌دهد که چگونه می‌توانید مقدار یک برچسب را با Aspose.Slides for Python via .NET برای [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) دریافت کنید:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    keywords = presentation.document_properties.keywords
```

## **افزودن برچسب‌ها به ارائه‌ها**

Aspose.Slides به شما امکان می‌دهد برچسب‌ها را به ارائه‌ها اضافه کنید. یک برچسب معمولاً شامل دو مورد است:

- نام یک ویژگی سفارشی، به‌عنوان مثال `MyTag`؛
- مقدار ویژگی سفارشی، به‌عنوان مثال `My Tag Value`.

اگر نیاز دارید ارائه‌ها را بر پایهٔ یک قانون یا ویژگی خاص طبقه‌بندی کنید، می‌توانید برای این منظور برچسب اضافه کنید. برای مثال، اگر می‌خواهید ارائه‌های کشورهای آمریکای شمالی را دسته‌بندی کنید، می‌توانید برچسب «NorthAmerican» ایجاد کرده و نام کشور مربوطه را به‌عنوان مقدار آن انتساب دهید.

این کد نمونه نشان می‌دهد که چگونه یک برچسب به یک [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) اضافه شود با استفاده از Aspose.Slides for Python via .NET:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    tags = presentation.custom_data.tags
    tags.add("MyTag", "My Tag Value")
```

برچسب‌ها می‌توانند برای یک [Slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/) نیز تنظیم شوند:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.custom_data.tags.add("tag", "value")
```

یا برای یک [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/) منفرد:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **محدودیت‌ها**

برچسب‌های اضافه شده از طریق مجموعهٔ `custom_data.tags` فقط در فایل PowerPoint ذخیره می‌شوند. آن‌ها **به** ساختار برچسب PDF هنگام صادرات ارائه به PDF منتقل نمی‌شوند. بنابراین، یک شناسهٔ سفارشی که به‌عنوان برچسب اختصاص داده شده است، نمی‌تواند از PDF برچسب‌دار بازیابی شود.

**راه‌حل**: می‌توانید یک شناسهٔ سفارشی را در **متن Alt** شیء (به‌عنوان مثال، `shape.alternative_text = "MyId"`) ذخیره کنید. پس از صادرات به PDF، متن Alt ممکن است در ساختار برچسب PDF ظاهر شود.

## **سوالات متداول**

**آیا می‌توانم تمام برچسب‌ها را از یک ارائه، اسلاید یا شکل در یک عملیات حذف کنم؟**

بله. مجموعهٔ [tag collection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/tagcollection/) از عملیات [clear](https://reference.aspose.com/slides/fa/python-net/aspose.slides/tagcollection/clear/) پشتیبانی می‌کند که تمام جفت‌های کلید‑مقدار را یک‌باره حذف می‌کند.

**چگونه می‌توان یک برچسب را تنها بر پایه نام آن بدون پیمایش کل مجموعه حذف کرد؟**

از [remove(name)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/tagcollection/remove/) روی [TagCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/tagcollection/) برای حذف برچسب بر پایه کلید استفاده کنید.

**چگونه می‌توان فهرست کامل نام‌های برچسب‌ها را برای تحلیل یا فیلتر دریافت کرد؟**

از [get_names_of_tags](https://reference.aspose.com/slides/fa/python-net/aspose.slides/tagcollection/get_names_of_tags/) روی [tag collection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/tagcollection/) استفاده کنید؛ این متد آرایه‌ای از تمام نام‌های برچسب‌ها را برمی‌گرداند.

**چگونه می‌توان تمام بخش‌های XML سفارشی را بدون در نظر گرفتن محل ذخیره‌شان پیدا کرد؟**

از [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/all_custom_xml_parts/) برای بازیابی تمام بخش‌های XML سفارشی در ارائه استفاده کنید.

**آیا باید برای به‌روزرسانی یک بخش XML سفارشی `xml_as_string` یا `xml_data` را استفاده کنم؟**

زمانی که برنامه با متن XML UTF‑8 کار می‌کند، از `xml_as_string` استفاده کنید. وقتی XML از پیش به‌صورت آرایه بایتی موجود است یا پردازش باینری راحت‌تر است، از `xml_data` استفاده کنید. هر دو خاصیت محتوای XML یک بخش XML سفارشی را نشان می‌دهند.