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
- متادیتای سند
- ویرایش متادیتا
- زبان اصلاح
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "مدیریت کامل ویژگی‌های ارائه در Aspose.Slides برای Python via .NET و بهینه‌سازی جستجو، برندینگ و جریان کار در فایل‌های PowerPoint شما."
---
## **مقدمه**

Aspose.Slides دو نوع ویژگی سند را پشتیبانی می‌کند: **Built-in** و **Custom**. هر دو نوع این ویژگی‌ها به راحتی می‌توانند با استفاده از API Aspose.Slides دسترسی و مدیریت شوند.

Aspose.Slides به شما امکان کار با ویژگی‌های سند ارائه را از طریق کلاس [DocumentProperties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/) می‌دهد. یک نمونه از این کلاس توسط خصوصیت [Presentation.document_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/document_properties/) بازگردانده می‌شود. مثال‌های زیر نشان می‌دهند چطور این ویژگی‌ها را بخوانید، تغییر دهید و مدیریت کنید.

{{% alert color="primary" %}} 
لطفاً توجه داشته باشید که نمی‌توانید مقادیر را در فیلدهای **Application** و **Producer** تنظیم کنید، زیرا Aspose Ltd. و Aspose.Slides for Python via .NET x.x.x در این فیلدها نمایش داده می‌شوند.
{{% /alert %}} 

## **مدیریت ویژگی‌های ارائه**

Microsoft PowerPoint ویژگی‌ای برای افزودن برخی ویژگی‌ها به فایل‌های ارائه فراهم می‌کند. این ویژگی‌های سند امکان ذخیره‌سازی اطلاعات مفید همراه با اسناد (فایل‌های ارائه) را فراهم می‌آورند. دو نوع ویژگی سند به شرح زیر وجود دارند:

- ویژگی‌های تعریف‌شده توسط سیستم (Built-in)  
- ویژگی‌های تعریف‌شده توسط کاربر (Custom)

ویژگی‌های **Built-in** شامل اطلاعات کلی درباره سند مانند عنوان سند، نام نویسنده، آمار سند و غیره هستند. ویژگی‌های **Custom** آن دسته از ویژگی‌ها هستند که توسط کاربران به صورت جفت **نام/مقدار** تعریف می‌شوند، به‌طوری که هر دو نام و مقدار توسط کاربر تعیین می‌شوند. با استفاده از Aspose.Slides for Python via .NET، توسعه‌دهندگان می‌توانند به مقادیر ویژگی‌های Built-in و همچنین ویژگی‌های Custom دسترسی پیدا کرده و آن‌ها را تغییر دهند. Microsoft PowerPoint 2007 امکان مدیریت ویژگی‌های سند فایل‌های ارائه را فراهم می‌کند. کافی است بر روی نماد Office کلیک کرده و سپس گزینه **Prepare | Properties | Advanced Properties** را در منوی Microsoft PowerPoint 2007 انتخاب کنید. پس از انتخاب گزینه **Advanced Properties**، گفتگویی ظاهر می‌شود که به شما اجازه می‌دهد ویژگی‌های سند فایل PowerPoint را مدیریت کنید. در **Properties Dialog** می‌توانید صفحه‌های تب متعددی مانند **General**, **Summary**, **Statistics**, **Contents** و **Custom** را مشاهده کنید. همه این صفحات تب امکان تنظیم انواع مختلف اطلاعات مرتبط با فایل‌های PowerPoint را فراهم می‌کنند. تب **Custom** برای مدیریت ویژگی‌های سفارشی فایل‌های PowerPoint استفاده می‌شود.

## **دسترسی به ویژگی‌های Built-in**
این ویژگی‌ها که توسط شیء **IDocumentProperties** افشا می‌شوند شامل: **Creator(Author)**, **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** و **Title**.
```py
import aspose.slides as slides

# نمونه‌سازی کلاس Presentation که نمایشگر ارائه است
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
    # ایجاد مرجع به شیء مرتبط با Presentation
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

تغییر ویژگی‌های Built-in فایل‌های ارائه به سادگی دسترسی به آن‌ها است. می‌توانید به‌سادگی یک مقدار رشته‌ای را به هر ویژگی دلخواه اختصاص دهید و مقدار ویژگی تغییر خواهد کرد. در مثال زیر نشان دادیم که چگونه می‌توان ویژگی‌های سند Built-in یک فایل ارائه را تغییر داد.

```py
import aspose.slides as slides

# نمونه‌سازی کلاس Presentation که نمایشگر Presentation است
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
    # ایجاد مرجع به شیء مرتبط با Presentation
    documentProperties = presentation.document_properties

    # تنظیم ویژگی‌های داخلی
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # ذخیره ارائه شما به یک فایل
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **افزودن ویژگی‌های سفارشی به ارائه**

Aspose.Slides for Python via .NET همچنین به توسعه‌دهندگان اجازه می‌دهد مقادیر سفارشی برای ویژگی‌های سند ارائه اضافه کنند. مثالی در زیر نشان می‌دهد چگونه ویژگی‌های سفارشی را برای یک ارائه تنظیم کنید.

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

    # دریافت نام ویژگی در شاخص خاص
    getPropertyName = documentProperties.get_custom_property_name(2)

    # حذف ویژگی انتخاب‌شده
    documentProperties.remove_custom_property(getPropertyName)

    # ذخیره‌سازی ارائه
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **دسترسی و تغییر ویژگی‌های سفارشی**

Aspose.Slides for Python via .NET همچنین به توسعه‌دهندگان اجازه می‌دهد مقادیر ویژگی‌های سفارشی را دسترسی و تغییر دهند. مثالی در زیر نشان می‌دهد چگونه می‌توانید همه این ویژگی‌های سفارشی را برای یک ارائه دسترسی و تغییر دهید.

```py
import aspose.slides as slides

# نمونه‌سازی کلاس Presentation که نمایانگر فایل PPTX است
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # ایجاد مرجع به شیء document_properties مرتبط با Presentation
    documentProperties = presentation.document_properties

    # دسترسی و تغییر ویژگی‌های سفارشی
    for i in range(documentProperties.count_of_custom_properties):
        # نمایش نام‌ها و مقادیر ویژگی‌های سفارشی
        print("Custom Property Name : " + documentProperties.get_custom_property_name(i))
        print("Custom Property Value : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # تغییر مقادیر ویژگی‌های سفارشی
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "New Value " + str(i + 1))
    # ذخیره ارائه شما به یک فایل
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم زبان اصلاح**

Aspose.Slides ویژگی `Language_Id` را (که توسط کلاس [PortionFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/) افشا می‌شود) فراهم می‌کند تا بتوانید زبان اصلاح برای یک سند PowerPoint را تنظیم کنید. زبان اصلاح زبانی است که املا و دستور زبان در PowerPoint برای آن بررسی می‌شود.

این کد Python نشان می‌دهد چگونه زبان اصلاح برای یک PowerPoint تنظیم شود:

```python
import aspose.slides as slides

with slides.Presentation(path + "SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # تنظیم شناسه زبان اصلاح
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

برای دیدن نحوه کار با ویژگی‌های سند از طریق API Aspose.Slides، برنامه آنلاین [**Aspose.Slides Metadata**](https://products.aspose.app/slides/fa/metadata) را امتحان کنید:

[![مشاهده و ویرایش متادیتای پاورپوینت](slides-metadata.png)](https://products.aspose.app/slides/fa/metadata)

## **سوالات متداول**

**چگونه می‌توانم یک ویژگی Built-in را از یک ارائه حذف کنم؟**

ویژگی‌های Built-in جزئی جدایی‌ناپذیر از ارائه هستند و نمی‌توان آن‌ها را به‌طور کامل حذف کرد. اما می‌توانید مقدار آن‌ها را تغییر داده یا در صورت امکان به مقدار خالی تنظیم کنید.

**اگر ویژگی سفارشی که قبلاً موجود است را اضافه کنم چه اتفاقی می‌افتد؟**

اگر ویژگی سفارشی‌ای را که قبلاً موجود است اضافه کنید، مقدار موجود آن با مقدار جدید بازنویسی می‌شود. نیازی به حذف یا بررسی قبلی ویژگی ندارید، زیرا Aspose.Slides به‌صورت خودکار مقدار ویژگی را به‌روز می‌کند.

**آیا می‌توانم ویژگی‌های ارائه را بدون بارگذاری کامل ارائه دسترسی داشته باشم؟**

بله، می‌توانید ویژگی‌های ارائه را بدون بارگذاری کامل با استفاده از متد [get_presentation_info](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationfactory/get_presentation_info/) از کلاس [PresentationFactory](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationfactory/) دسترسی پیدا کنید. سپس با استفاده از متد [read_document_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/read_document_properties/) ارائه شده توسط کلاس [PresentationInfo](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/) می‌توانید ویژگی‌ها را به‌صورت کارآمد بخوانید و حافظه را صرفه‌جویی کنید و عملکرد را بهبود ببخشید.