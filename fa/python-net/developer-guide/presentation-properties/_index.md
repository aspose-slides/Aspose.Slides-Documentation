---
title: مدیریت ویژگی‌های ارائه با پایتون
linktitle: ویژگی‌های ارائه
type: docs
weight: 70
url: /fa/python-net/presentation-properties/
keywords:
- ویژگی‌های PowerPoint
- ویژگی‌های ارائه
- ویژگی‌های سند
- ویژگی‌های داخلی
- ویژگی‌های سفارشی
- ویژگی‌های پیشرفته
- مدیریت ویژگی‌ها
- تغییر ویژگی‌ها
- فراداده سند
- ویرایش فراداده
- زبان تصحیح املایی
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "ویژگی‌های ارائه را در Aspose.Slides for Python via .NET به‌طور کامل مسلط شوید و جستجو، برندینگ و جریان کار را در فایل‌های PowerPoint خود بهبود بخشید."
---
## **مقدمه**

Aspose.Slides از دو نوع ویژگی سند پشتیبانی می‌کند: **Built-in** و **Custom**. هر دو این نوع ویژگی‌ها به راحتی می‌توانند با استفاده از API Aspose.Slides دسترسی و مدیریت شوند.

Aspose.Slides به شما اجازه می‌دهد تا با ویژگی‌های سند ارائه از طریق کلاس [DocumentProperties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/) کار کنید. یک نمونه از این کلاس توسط ویژگی [Presentation.document_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/document_properties/) بازگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این ویژگی‌ها را بخوانید، تغییر دهید و مدیریت کنید.

{{% alert color="info" title="Note" %}}
لطفاً توجه داشته باشید که نمی‌توانید مقادیر را برای فیلدهای **Application** و **Producer** تنظیم کنید، زیرا Aspose Ltd. و Aspose.Slides for Python via .NET x.x.x در این فیلدها نمایش داده می‌شوند.
{{% /alert %}} 

## **مدیریت ویژگی‌های ارائه**

Microsoft PowerPoint ویژگی‌ای برای افزودن برخی ویژگی‌ها به فایل‌های ارائه فراهم می‌کند. این ویژگی‌های سند اجازه می‌دهند اطلاعات مفیدی همراه با اسناد (فایل‌های ارائه) ذخیره شوند. دو نوع ویژگی سند به شرح زیر وجود دارد

- ویژگی‌های تعریف‌شده توسط سیستم (Built-in)
- ویژگی‌های تعریف‌شده توسط کاربر (Custom)

ویژگی‌های **Built-in** شامل اطلاعات کلی درباره سند مانند عنوان سند، نام نویسنده، آمار سند و غیره هستند. ویژگی‌های **Custom** آن‌هایی هستند که توسط کاربران به صورت جفت **Name/Value** تعریف می‌شوند، که هر دو نام و مقدار توسط کاربر تعیین می‌شود. با استفاده از Aspose.Slides for Python via .NET، توسعه‌دهندگان می‌توانند به مقادیر ویژگی‌های ساختاری و سفارشی دسترسی داشته و آنها را تغییر دهند. Microsoft PowerPoint 2007 اجازه مدیریت ویژگی‌های سند فایل‌های ارائه را می‌دهد. برای این کار کافی است روی نماد Office کلیک کنید و سپس گزینه منوی **Prepare | Properties | Advanced Properties** در Microsoft PowerPoint 2007 را انتخاب کنید. پس از انتخاب گزینه منوی **Advanced Properties**، دیالگی ظاهر می‌شود که امکان مدیریت ویژگی‌های سند فایل PowerPoint را فراهم می‌کند. در **Properties Dialog**، می‌توانید مشاهده کنید که صفحات تب متعددی مانند **General, Summary, Statistics, Contents and Custom** وجود دارد. تمامی این صفحات تب امکان پیکربندی انواع مختلف اطلاعات مربوط به فایل‌های PowerPoint را می‌دهند. برگه **Custom** برای مدیریت ویژگی‌های سفارشی فایل‌های PowerPoint استفاده می‌شود.

## **دسترسی به ویژگی‌های Built-in**

این ویژگی‌ها که توسط شیء **IDocumentProperties** افشا می‌شوند شامل: **Creator(Author)**، **Description**، **Keywords**، **Created** (تاریخ ایجاد)، **Modified** (تاریخ اصلاح)، **Printed** (آخرین تاریخ چاپ)، **LastModifiedBy**، **Keywords**، **SharedDoc** (آیا بین تولیدکنندگان مختلف به اشتراک گذاشته شده است؟)، **PresentationFormat**، **Subject** و **Title** است.
```py
import aspose.slides as slides

# شیء Presentation را که نمایانگر ارائه است ایجاد کنید
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # ایجاد یک مرجع به شیء مرتبط با Presentation
    documentProperties = pres.document_properties

    # نمایش ویژگی‌های داخلی
    print("category : " + documentProperties.category)
    print("Current Status : " + documentProperties.content_status)
    print("Creation Date : " + str(documentProperties.created_time))
    print("Author : " + documentProperties.author)
    print("Description : " + documentProperties.comments)
    print("KeyWords : " + documentProperties.keywords)
    print("Last Modified By : " + documentProperties.last_saved_by)
    print("Supervisor : " + documentProperties.manager)
    print("Modified Date : " + str(documentProperties.last_saved_time))
    print("Presentation Format : " + documentProperties.presentation_format)
    print("Last Print Date : " + str(documentProperties.last_printed))
    print("Is Shared between producers : " + str(documentProperties.shared_doc))
    print("Subject : " + documentProperties.subject)
    print("Title : " + documentProperties.title)
```

## **تغییر ویژگی‌های Built-in**

تغییر ویژگی‌های ساختاری فایل‌های ارائه به همان سادگی دسترسی به آن‌ها است. می‌توانید به سادگی یک مقدار رشته‌ای به هر ویژگی دلخواه اختصاص دهید و مقدار ویژگی تغییر خواهد کرد. در مثال زیر، نشان دادیم که چگونه می‌توانیم ویژگی‌های سند ساختاری فایل ارائه را تغییر دهیم.
```py
import aspose.slides as slides

# نمونه‌سازی کلاس Presentation که نمایانگر ارائه است
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # ایجاد یک مرجع به شیء مرتبط با Presentation
    documentProperties = presentation.document_properties

    # تنظیم ویژگی‌های داخلی
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # ارائه را در یک فایل ذخیره کنید
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **افزودن ویژگی‌های سفارشی به ارائه**

Aspose.Slides for Python via .NET همچنین به توسعه‌دهندگان امکان می‌دهد مقادیر سفارشی برای ویژگی‌های سند ارائه اضافه کنند. یک مثال در زیر نشان می‌دهد چگونه می‌توان ویژگی‌های سفارشی را برای یک ارائه تنظیم کرد.
```py
import aspose.slides as slides

# نمونه‌سازی کلاس Presentation
with slides.Presentation() as presentation:
    # دریافت ویژگی‌های سند
    documentProperties = presentation.document_properties

    # افزودن ویژگی‌های سفارشی
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # دریافت نام ویژگی در ایندکس خاص
    getPropertyName = documentProperties.get_custom_property_name(2)

    # حذف ویژگی انتخاب‌شده
    documentProperties.remove_custom_property(getPropertyName)

    # ذخیره ارائه
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **دستیابی و تغییر ویژگی‌های سفارشی**

Aspose.Slides for Python via .NET همچنین به توسعه‌دهندگان امکان می‌دهد به مقادیر ویژگی‌های سفارشی دسترسی داشته باشند. یک مثال در زیر نشان می‌دهد چگونه می‌توانید به همه این ویژگی‌های سفارشی برای یک ارائه دسترسی پیدا کنید و آنها را تغییر دهید.
```py
import aspose.slides as slides

# نمونه‌سازی کلاس Presentation که نمایانگر فایل PPTX است
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # ایجاد یک مرجع به شیء document_properties مرتبط با Presentation
    documentProperties = presentation.document_properties

    # دسترسی و تغییر ویژگی‌های سفارشی
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # نمایش نام‌ها و مقادیر ویژگی‌های سفارشی
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # تغییر مقادیر ویژگی‌های سفارشی
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # ارائه خود را در یک فایل ذخیره کنید
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` مقدار را از طریق لیست تک‌عنصری که به عنوان آرگومان دوم پاس داده می‌شود بر می‌گرداند و مقدار ذخیره‌شده به نوع عنصری که قبلاً در آن لیست وجود دارد تبدیل می‌شود. مثال بالا از `[""]` استفاده می‌کند، بنابراین ویژگی‌های رشته‌ای را می‌خواند؛ برای خواندن ویژگی‌ای که به عنوان عدد ذخیره شده است، یک جای‌دار عددی مانند `[0]` پاس دهید—در غیر این صورت فراخوانی یک `InvalidCastException` را ایجاد می‌کند.

## **تنظیم زبان تصحیح املایی**

Aspose.Slides ویژگی `Language_Id` (که توسط کلاس [PortionFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/) افشا می‌شود) را فراهم می‌کند تا بتوانید زبان تصحیح املایی برای یک سند PowerPoint تنظیم کنید. زبان تصحیح املایی زبانی است که املا و نگارش در PowerPoint برای آن بررسی می‌شود.

این کد Python نشان می‌دهد چگونه زبان تصحیح املایی برای یک PowerPoint تنظیم شود:
```python
import aspose.slides as slides

with slides.Presentation("SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # تنظیم شناسهٔ زبان تصحیح املایی
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **تنظیم زبان پیش‌فرض**

این کد Python نشان می‌دهد چگونه زبان پیش‌فرض برای یک ارائه کامل PowerPoint تنظیم شود:
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en_US"

with slides.Presentation(load_options) as pres:
    shp = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 150)
    text_frame = shp.text_frame
    text_frame.text = "New Text"

    print(text_frame.paragraphs[0].portions[0].portion_format.language_id)
```

## **مثال زنده**

سعی کنید برنامه آنلاین [**Aspose.Slides Metadata**](https://products.aspose.app/slides/fa/metadata) را امتحان کنید تا ببینید چگونه با ویژگی‌های سند از طریق API Aspose.Slides کار می‌کنید:
[![مشاهده و ویرایش فراداده PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/fa/metadata)

## **سوالات متداول**

**چگونه می‌توانم یک ویژگی Built-in را از یک ارائه حذف کنم؟**

ویژگی‌های Built-in بخش جدایی‌ناپذیری از ارائه هستند و نمی‌توان آن‌ها را به‌طور کامل حذف کرد. با این حال، می‌توانید مقدار آن‌ها را تغییر دهید یا اگر ویژگی خاص اجازه دهد، آن‌ها را خالی کنید.

**اگر یک ویژگی سفارشی که قبلاً وجود دارد را اضافه کنم چه اتفاقی می‌افتد؟**

اگر یک ویژگی سفارشی که پیش از این وجود داشته باشد اضافه کنید، مقدار موجود آن با مقدار جدید جایگزین می‌شود. نیازی به حذف یا بررسی پیشین ویژگی نیست، زیرا Aspose.Slides به‌صورت خودکار مقدار ویژگی را به‌روزرسانی می‌کند.

**آیا می‌توانم بدون بارگذاری کامل ارائه به ویژگی‌های آن دسترسی داشته باشم؟**

بله. از [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationfactory/get_presentation_info/) استفاده کنید و سپس [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/read_document_properties/) برای خواندن فراداده‌های ذخیره‌شده سند بدون ایجاد یک نمونه [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) استفاده کنید. برای مثال کامل گزارش‌گیری و محدودیت‌های خاص فرمت، به [Build a Lightweight Presentation Inventory](/slides/fa/python-net/examine-presentation/) مراجعه کنید.