---
title: مدیریت ویژگی‌های ارائه با Python
linktitle: ویژگی‌های ارائه
type: docs
weight: 70
url: /fa/python-net/presentation-properties/
keywords:
- ویژگی‌های PowerPoint
- ویژگی‌های ارائه
- ویژگی‌های سند
- ویژگی‌های توکار
- ویژگی‌های سفارشی
- ویژگی‌های پیشرفته
- مدیریت ویژگی‌ها
- اصلاح ویژگی‌ها
- فراداده سند
- ویرایش فراداده
- زبان اصلاح
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "ویژگی‌های ارائه را در Aspose.Slides برای Python via .NET مدیریت کنید و جستجو، برندینگ و گردش کار را در فایل‌های PowerPoint خود بهینه کنید."
---
## **مقدمه**

Aspose.Slides دو نوع ویژگی سند را پشتیبانی می‌کند: **Built-in** و **Custom**. هر دو نوع این ویژگی‌ها به راحتی می‌توانند با استفاده از API Aspose.Slides دسترسی پیدا کرده و مدیریت شوند.

Aspose.Slides به شما امکان کار با ویژگی‌های سند ارائه را از طریق کلاس [DocumentProperties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/documentproperties/) می‌دهد. یک نمونه از این کلاس توسط ویژگی [Presentation.document_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/document_properties/) برگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این ویژگی‌ها را بخوانید، تغییر دهید و مدیریت کنید.

{{% alert color="info" title="Note" %}}
لطفاً توجه داشته باشید که نمی‌توانید مقادیری را برای فیلدهای **Application** و **Producer** تنظیم کنید، زیرا Aspose Ltd. و Aspose.Slides for Python via .NET x.x.x در این فیلدها نمایش داده می‌شوند.
{{% /alert %}} 

## **مدیریت ویژگی‌های ارائه**

Microsoft PowerPoint ویژگی افزودن برخی ویژگی‌ها به فایل‌های ارائه را فراهم می‌کند. این ویژگی‌های سند امکان ذخیره‌سازی اطلاعات مفید همراه با اسناد (فایل‌های ارائه) را فراهم می‌کنند. دو نوع ویژگی سند به شرح زیر هستند:

- ویژگی‌های تعریف‌شده توسط سیستم (Built-in)
- ویژگی‌های تعریف‌شده توسط کاربر (Custom)

ویژگی‌های **Built-in** اطلاعات کلی درباره سند مانند عنوان سند، نام نویسنده، آمار سند و غیره را شامل می‌شوند. ویژگی‌های **Custom** ویژگی‌هایی هستند که توسط کاربران به صورت جفت **Name/Value** تعریف می‌شوند، به‌طوری که هر دو نام و مقدار توسط کاربر تعیین می‌شود. با استفاده از Aspose.Slides for Python via .NET، توسعه‌دهندگان می‌توانند مقادیر ویژگی‌های Built-in و همچنین ویژگی‌های Custom را دسترسی و تغییر دهند. Microsoft PowerPoint 2007 امکان مدیریت ویژگی‌های سند فایل‌های ارائه را فراهم می‌کند. کافی است آیکون Office را کلیک کنید و سپس **Prepare | Properties | Advanced Properties** را در منوی Microsoft PowerPoint 2007 انتخاب کنید. پس از انتخاب **Advanced Properties**، یک دیالوگ ظاهر می‌شود که به شما اجازه می‌دهد ویژگی‌های سند فایل PowerPoint را مدیریت کنید. در **Properties Dialog** می‌توانید صفحات تب متعددی مانند **General, Summary, Statistics, Contents and Custom** را ببینید. تمام این صفحات تب امکان پیکربندی انواع مختلف اطلاعات مرتبط با فایل‌های PowerPoint را فراهم می‌کنند. برگه **Custom** برای مدیریت ویژگی‌های سفارشی فایل‌های PowerPoint استفاده می‌شود.

## **خواندن ویژگی‌های عمومی از ارائه رمزگذاری‌شده**

یک گذرواژه باز کردن معمولاً محتوای ارائه و ویژگی‌های سند را محافظت می‌کند. وقتی یک ارائه با [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) برابر `False` رمزگذاری می‌شود، ویژگی‌های سند آن عمومی باقی می‌مانند. سپس یک برنامه می‌تواند [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/only_load_document_properties/) را برابر `True` تنظیم کند و متادیتای عمومی را بدون ارائه گذرواژه باز خواند.

`only_load_document_properties` تعیین می‌کند که Aspose.Slides چه چیزی را بارگذاری می‌کند؛ هیچ چیز را رمزگشایی نمی‌کند. اگر ویژگی‌ها در رمزگذاری گنجانده شوند، بارگذاری آنها بدون گذرواژه شکست می‌خورد. اگر ارائه رمزگذاری نشده باشد، این گزینه نادیده گرفته می‌شود و کل ارائه بارگذاری می‌شود.

مثال زیر حالت بارگذاری را از طریق [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/fa/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) تأیید می‌کند و سپس ویژگی‌های Built-in را از طریق [Presentation.document_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/document_properties/) می‌خواند:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        properties = presentation.document_properties

        print("Author: " + properties.author)
        print("Title: " + properties.title)
        print("Keywords: " + properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

در این حالت، محتویات اسلاید بارگذاری نمی‌شود. اسلایدها، مسترها، قالب‌ها، شکل‌ها، رسانه‌ها و دیگر اشیای ارائه در دسترس نیستند. برنامه‌ها باید همیشه قبل از انجام عملیاتی که نیاز به مدل کامل شیء ارائه دارد، `is_only_document_properties_loaded` را بررسی کنند.

{{% alert color="warning" title="Security" %}}
متادیتای عمومی ممکن است نام نویسندگان، عناوین، موضوعات، کلمات کلیدی، اطلاعات شرکت، نظرات و مقادیر سفارشی را افشا کند. ویژگی‌های حساس را همراه با ارائه رمزگذاری کنید. فقط در زمانی که سیستم‌های ایندکس‌سازی، طبقه‌بندی، جستجو یا مدیریت سند نیاز خاصی به دسترسی بدون گذرواژه دارند، آنها را عمومی بگذارید.
{{% /alert %}}

## **به‌روزرسانی ویژگی‌های یک ارائه رمزگذاری‌شده**

برای یک فایل PPTX رمزگذاری‌شده، ارائه‌ای که با `only_load_document_properties` بارگذاری می‌شود برای خواندن متادیتای عمومی در نظر گرفته شده است. Aspose.Slides نمی‌تواند ویژگی‌های تغییر یافته را از آن شیء فقط‑متادیتا ذخیره کند، زیرا ویژگی‌های عمومی باید با داده‌های مربوطه داخل ارائه رمزگذاری‌شده سازگار بمانند. به‌روزرسانی آنها بنابراین نیاز به گذرواژه باز کردن صحیح و بارگذاری کامل دارد.

مثال زیر ارائه را با [LoadOptions.password](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/password/) باز می‌کند، ویژگی‌های Built-in عمومی را به‌روزرسانی می‌کند و نتیجه را ذخیره می‌کند. سپس از [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/is_encrypted/) استفاده می‌کند تا تأیید کند رمزگذاری حفظ شده و متادیتای عمومی را بدون گذرواژه مجدداً باز می‌کند تا مقادیر جدید را بررسی کند:

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    presentation.document_properties.title = "Updated Product Roadmap"
    presentation.document_properties.keywords = "roadmap, planning, indexed"
    presentation.save(output_path, slides.export.SaveFormat.PPTX)

presentation_info = slides.PresentationFactory.instance.get_presentation_info(output_path)
print("The presentation is encrypted: " + str(presentation_info.is_encrypted))

metadata_load_options = slides.LoadOptions()
metadata_load_options.only_load_document_properties = True

with slides.Presentation(output_path, metadata_load_options) as metadata_presentation:
    if metadata_presentation.protection_manager.is_only_document_properties_loaded:
        print("Title: " + metadata_presentation.document_properties.title)
        print("Keywords: " + metadata_presentation.document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

اگر برنامه مجاز به رمزگشایی یا بارگذاری محتوای ارائه نباشد، باید ویژگی‌های عمومی یک فایل PPTX رمزگذاری‌شده را به‌عنوان فقط‑خواندنی در نظر بگیرد.

## **دسترسی به ویژگی‌های Built-in**

این ویژگی‌ها که توسط شیء **IDocumentProperties** نمایش داده می‌شوند شامل: **Creator(Author)**، **Description**، **Keywords**، **Created** (تاریخ ایجاد)، **Modified** (تاریخ اصلاح)، **Printed** (آخرین تاریخ چاپ)، **LastModifiedBy**، **SharedDoc** (آیا بین تولید‌کنندگان مختلف به اشتراک گذاشته شده؟)، **PresentationFormat**، **Subject** و **Title** می‌باشند.
```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation که نمایانگر ارائه است
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # ایجاد یک مرجع به شیء مرتبط با Presentation
    documentProperties = pres.document_properties

    # نمایش ویژگی‌های توکار
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

تغییر ویژگی‌های Built-in فایل‌های ارائه به اندازه دسترسی به آنها آسان است. به سادگی می‌توانید مقدار رشته‌ای را به هر ویژگی دلخواه اختصاص دهید و مقدار ویژگی تغییر خواهد کرد. در مثال زیر نشان داده‌ایم چگونه می‌توانیم ویژگی‌های سند Built-in فایل ارائه را تغییر دهیم.

```py
import aspose.slides as slides

# نمونه‌ای از کلاس Presentation که نمایانگر ارائه است
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # ایجاد یک مرجع به شیء مرتبط با Presentation
    documentProperties = presentation.document_properties

    # تنظیم ویژگی‌های توکار
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # ذخیره ارائه خود به یک فایل
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **افزودن ویژگی‌های سفارشی به ارائه**

Aspose.Slides for Python via .NET همچنین به توسعه‌دهندگان اجازه می‌دهد مقادیر سفارشی برای ویژگی‌های سند ارائه اضافه کنند. مثال زیر نشان می‌دهد چگونه ویژگی‌های سفارشی را برای یک ارائه تنظیم کنیم.

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

    # ذخیره ارائه
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **دسترسی و تغییر ویژگی‌های سفارشی**

Aspose.Slides for Python via .NET همچنین به توسعه‌دهندگان اجازه می‌دهد به مقادیر ویژگی‌های سفارشی دسترسی پیدا کنند. مثال زیر نشان می‌دهد چگونه می‌توانید تمام این ویژگی‌های سفارشی را برای یک ارائه دسترسی و تغییر دهید.

```py
import aspose.slides as slides

# ایجاد نمونه از کلاس Presentation که نمایانگر PPTX است
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # ایجاد یک مرجع به شیء document_properties مرتبط با Presentation
    documentProperties = presentation.document_properties

    # دسترسی و اصلاح ویژگی‌های سفارشی
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # نمایش نام‌ها و مقادیر ویژگی‌های سفارشی
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # اصلاح مقدارهای ویژگی‌های سفارشی
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # ذخیره ارائه شما به یک فایل
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` مقدار را از طریق لیست تک‌عنصری که به عنوان آرگومان دوم پاس می‌شود برمی‌گرداند و مقدار ذخیره‌شده به نوع عنصری که قبلاً در آن لیست وجود دارد تبدیل می‌شود. مثال بالا از `[""]` استفاده می‌کند، بنابراین ویژگی‌های رشته‌ای را می‌خواند؛ برای خواندن ویژگی‌ای که به عنوان عدد ذخیره شده، یک جایگیر عددی مانند `[0]` پاس دهید—در غیر این صورت فراخوانی یک `InvalidCastException` را ایجاد می‌کند.

## **تنظیم زبان اصلاح**

Aspose.Slides ویژگی `Language_Id` (که توسط کلاس [PortionFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/portionformat/) نمایش داده می‌شود) را فراهم می‌کند تا زبان اصلاح برای یک سند PowerPoint تنظیم شود. زبان اصلاح زبانی است که املا و گرامر در PowerPoint برای آن بررسی می‌شود.

این کد Python نشان می‌دهد چگونه زبان اصلاح برای یک PowerPoint تنظیم شود:

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

    # تنظیم شناسه زبان اصلاح
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **تنظیم زبان پیش‌فرض**

این کد Python نشان می‌دهد چگونه زبان پیش‌فرض برای یک ارائه PowerPoint کامل تنظیم شود:

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

سعی کنید برنامه آنلاین [**Aspose.Slides Metadata**](https://products.aspose.app/slides/fa/metadata) را امتحان کنید تا ببینید چگونه می‌توان با ویژگی‌های سند از طریق API Aspose.Slides کار کرد:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/fa/metadata)

## **سوالات متداول**

**چگونه می‌توانم یک ویژگی Built-in را از یک ارائه حذف کنم؟**

ویژگی‌های Built-in جزئی جدایی‌ناپذیر از ارائه هستند و نمی‌توان آنها را به‌طور کامل حذف کرد. با این حال، می‌توانید مقادیر آنها را تغییر داده یا در صورت امکان به مقدار خالی تنظیم کنید.

**چه می‌شود اگر یک ویژگی سفارشی که از قبل وجود دارد را اضافه کنم؟**

اگر یک ویژگی سفارشی که از قبل وجود دارد را اضافه کنید، مقدار موجود آن با مقدار جدید بازنویسی می‌شود. نیازی به حذف یا بررسی پیشین ویژگی ندارید، زیرا Aspose.Slides به‌صورت خودکار مقدار ویژگی را به‌روزرسانی می‌کند.

**آیا می‌توانم ویژگی‌های ارائه را بدون بارگذاری کامل ارائه دسترسی پیدا کنم؟**

بله. می‌توانید از [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationfactory/get_presentation_info/) و سپس [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/read_document_properties/) استفاده کنید تا متادیتای ذخیره‌شده سند را بدون ایجاد یک نمونه [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) بخوانید. برای یک مثال کامل گزارش‌گیری و محدودیت‌های خاص فرمت، به مقاله [Build a Lightweight Presentation Inventory](/slides/fa/python-net/examine-presentation/) مراجعه کنید.

**آیا می‌توانم ویژگی‌های عمومی یک ارائه رمزگذاری‌شده را بدون گذرواژه باز کردن آن بخوانم؟**

بله. ارائه باید با `encrypt_document_properties` برابر `False` رمزگذاری شده باشد و باید با `only_load_document_properties` برابر `True` بارگذاری شود.

**آیا می‌توانم یک فایل PPTX رمزگذاری‌شده را در حالت فقط‑ویژگی‑سند به‌روزرسانی کنم؟**

خیر. داده‌های عمومی و رمزگذاری‌شده باید سازگار بمانند، بنابراین به‌روزرسانی یک فایل PPTX رمزگذاری‌شده نیاز به بارگذاری کامل ارائه با گذرواژه باز کردن صحیح دارد.