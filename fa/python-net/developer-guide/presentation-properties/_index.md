---
title: مدیریت ویژگی‌های ارائه با پایتون
linktitle: ویژگی‌های ارائه
type: docs
weight: 70
url: /fa/python-net/presentation-properties/
keywords:
- ویژگی‌های پاورپوینت
- ویژگی‌های ارائه
- ویژگی‌های سند
- ویژگی‌های از پیش تعریف‌شده
- ویژگی‌های سفارشی
- ویژگی‌های پیشرفته
- مدیریت ویژگی‌ها
- تغییر ویژگی‌ها
- ابرداده‌های سند
- ویرایش ابرداده
- زبان بررسی
- زبان پیش‌فرض
- پاورپوینت
- OpenDocument
- ارائه
- پایتون
- Aspose.Slides
description: "ویژگی‌های ارائه را در Aspose.Slides for Python via .NET به‌صورت کامل مدیریت کنید و جستجو، برندینگ و جریان کار را در فایل‌های پاورپوینت خود بهینه‌سازی کنید."
---
## **معرفی**

Aspose.Slides for Python via .NET از ویژگی‌های سند **از پیش تعریف‌شده** و **سفارشی** پشتیبانی می‌کند. از این ویژگی‌ها برای خواندن و به‑روزرسانی متاداده‌های ارائه، مانند نویسنده، عنوان و مقادیر تعریف‌شده توسط کاربر استفاده کنید.

Aspose.Slides به شما امکان می‌دهد که با ویژگی‌های سند ارائه از طریق کلاس [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) کار کنید. یک نمونه از این کلاس توسط [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) برگردانده می‌شود. مثال‌های زیر نحوه خواندن، تغییر و مدیریت این ویژگی‌ها را نشان می‌دهند.

{{% alert color="info" title="Note" %}}
Aspose.Slides متاداده‌های برنامه و سازنده را هنگام ذخیره ارائه‌ها مدیریت می‌کند؛ این فیلدها نرم‌افزاری را که خروجی را ایجاد کرده است شناسایی می‌کنند.
{{% /alert %}}

## **مدیریت ویژگی‌های ارائه**

ویژگی‌های سند اطلاعات توصیفی را در کنار محتوای ارائه ذخیره می‌کنند. این ویژگی‌ها در دو دسته قرار می‌گیرند:

- **ویژگی‌های از پیش تعریف‌شده** شامل متاداده‌های استاندارد مانند عنوان، نویسنده و آمار سند هستند.
- **ویژگی‌های سفارشی** جفت نام/مقدار تعریف‌شده توسط کاربر را ذخیره می‌کنند.

Aspose.Slides for Python via .NET به هر دو دسته دسترسی می‌دهد. در PowerPoint، برای بررسی متاداده‌های سند **File → Info → Properties → Advanced Properties** را انتخاب کنید. این دیالوگ اطلاعات را در تب‌های **Summary**, **Statistics**, **Contents** و **Custom** گروه‌بندی می‌کند. برای مدیریت ویژگی‌های تعریف‌شده توسط کاربر از تب **Custom** استفاده کنید.

## **خواندن ویژگی‌های عمومی از یک ارائه‌ی رمزنگار شده**

یک گذرواژهٔ باز کردن معمولاً محتوای ارائه و ویژگی‌های سند را محافظت می‌کند. وقتی ارائه‌ای با [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) برابر `False` رمزنگاری می‌شود، ویژگی‌های سند آن عمومی می‌مانند. سپس یک برنامه می‌تواند [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) را برابر `True` تنظیم کند و متاداده‌های عمومی را بدون ارائهٔ گذرواژهٔ باز کردن بخواند.

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) کنترل می‌کند که Aspose.Slides چه چیزی را بارگذاری می‌کند؛ هیچ‌ چیزی را رمزگشایی نمی‌کند. اگر ویژگی‌ها در رمزنگاری گنجانده شده باشند، بارگذاری آن‌ها بدون گذرواژه منجر به خطا می‌شود. اگر ارائه رمزنگاری نشده باشد، این گزینه نادیده گرفته می‌شود و کل ارائه بارگذاری می‌شود.

این مثال به ارائه‌ای رمزنگاری‌شده نیاز دارد که ویژگی‌های سند آن عمومی باقی مانده‌اند. با استفاده از [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) حالت بارگذاری را بررسی می‌کند و سپس ویژگی‌های از پیش تعریف‌شده را از طریق [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) می‌خواند:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        document_properties = presentation.document_properties

        print("Author: " + document_properties.author)
        print("Title: " + document_properties.title)
        print("Keywords: " + document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

در این حالت، محتوای اسلایدها بارگذاری نمی‌شود. اسلایدها، مسترها، طرح‌ها، اشکال، رسانه و سایر اشیای ارائه در دسترس نیستند. برنامه‌ها باید همیشه قبل از انجام عملی که به مدل کامل شیء ارائه احتیاج دارد، [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) را بررسی کنند.

{{% alert color="warning" title="Security" %}}
متاداده‌های عمومی ممکن است نام نویسندگان، عناوین، موضوعات، کلمات کلیدی، اطلاعات شرکت، نظرات و مقادیر سفارشی را فاش کنند. ویژگی‌های حساس را همراه با ارائه رمزنگاری کنید. تنها وقتی که سیستم‌های ایندکس‌گذاری، طبقه‌بندی، جستجو یا مدیریت سند نیاز مشخصی به دسترسی بدون گذرواژه داشته باشند، آن‌ها را عمومی بگذارید.
{{% /alert %}}

## **به‌روزرسانی ویژگی‌های یک ارائه‌ی رمزنگار شده**

برای یک فایل PPTX رمزنگاری‌شده، یک ارائهٔ بارگذاری‌شده با [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) تنها برای خواندن متاداده‌های عمومی منظور شده است. Aspose.Slides نمی‌تواند ویژگی‌های تغییر یافته را از این شیء تنها‑متاداده ذخیره کند، زیرا ویژگی‌های عمومی باید با داده‌های مربوطه داخل ارائهٔ رمزنگاری‌شده همخوانی داشته باشند. به‌روزرسانی آن‌ها بنابراین نیاز به گذرواژهٔ صحیح باز کردن و بارگذاری کامل دارد.

این مثال به یک ارائهٔ PPTX رمزنگاری‌شده با ویژگی‌های سند عمومی و یک گذرواژهٔ باز کردن شناخته‌شده نیاز دارد. با استفاده از [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) کل ارائه را بارگذاری می‌کند، ویژگی‌های عمومی از پیش تعریف‌شده را به‌روزرسانی می‌کند و نتیجه را ذخیره می‌نماید. سپس با [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) بررسی می‌کند که رمزنگاری حفظ شده است و دوباره متاداده‌های عمومی را بدون گذرواژه باز می‌کند تا مقادیر جدید را تأیید کند:

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    document_properties = presentation.document_properties
    document_properties.title = "Updated Product Roadmap"
    document_properties.keywords = "roadmap, planning, indexed"
    
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

اگر برنامه‌ای اجازهٔ رمزگشایی یا بارگذاری محتوای ارائه را نداشته باشد، ویژگی‌های عمومی یک فایل PPTX رمزنگاری‌شده را به عنوان فقط‑خواندنی در نظر بگیرد.

## **دسترسی به ویژگی‌های از پیش تعریف‌شده**

کلاس [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) متاداده‌های از پیش تعریف‌شده را از طریق ویژگی‌های تایپی مانند [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/)، [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/) و [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/) باز می‌کند. این مثال یک ارائهٔ موجود را باز می‌کند و متاداده‌های ذخیره‌شدهٔ آن را در کنسول چاپ می‌نماید. مقادیر بسته به ارائهٔ ورودی متفاوت هستند؛ برخی فیلدها ممکن است خالی باشند.

```python
import aspose.slides as slides

with slides.Presentation("AccessBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    print("Category:", document_properties.category)
    print("Content status:", document_properties.content_status)
    print("Creation date:", document_properties.created_time)
    print("Author:", document_properties.author)
    print("Comments:", document_properties.comments)
    print("Keywords:", document_properties.keywords)
    print("Last modified by:", document_properties.last_saved_by)
    print("Manager:", document_properties.manager)
    print("Modified date:", document_properties.last_saved_time)
    print("Presentation format:", document_properties.presentation_format)
    print("Last print date:", document_properties.last_printed)
    print("Is shared between producers:", document_properties.shared_doc)
    print("Subject:", document_properties.subject)
    print("Title:", document_properties.title)
```

## **تغییر ویژگی‌های از پیش تعریف‌شده**

برای به‌روزرسانی متاداده‌های از پیش تعریف‌شده، مقادیر را به ویژگی‌های قابل نوشتن که توسط [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) نمایش داده می‌شوند اختصاص دهید. این مثال یک ارائهٔ موجود را باز می‌کند، [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/)، [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/)، [DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/)، [DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/) و [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/) را تنظیم می‌کند و سپس ارائهٔ به‌روزرسانی‌شده را با [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) ذخیره می‌کند. فایل PPTX ذخیره‌شده شامل متاداده‌های جدید خواهد بود.

```python
import aspose.slides as slides

with slides.Presentation("ModifyBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    document_properties.author = "Aspose.Slides for Python via .NET"
    document_properties.title = "Manage PowerPoint Presentation Properties"
    document_properties.subject = "Modify Built-in Properties"
    document_properties.comments = "Aspose description"
    document_properties.manager = "Aspose manager"

    presentation.save("DocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **مدیریت پایهٔ پیوندهای فراخورده**

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) پایهٔ سند را برای پیوندهای نسبی ذخیره می‌کند. این ویژگی هنگام جابجایی یک ارائه و فایل‌های مرتبط به مکان دیگری مفید است. این مقدار متفاوت از [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) یک پیوند منفرد است: تغییر پایه باعث بازنویسی آدرس‌های ذخیره‌شده یا تغییر مقصدهای مطلق نمی‌شود.

این مثال به ارائه‌ای حاوی یک پیوند نسبی مانند `target.html` و یک پیوند مطلق به یک فایل یا وب‌سایت نیاز دارد. ابتدا پایهٔ فعلی را می‌خواند، پایهٔ جدیدی اختصاص می‌دهد و ارائه را ذخیره و دوباره باز می‌کند تا مقدار را بررسی کند. سپس پایه را با `""` پاک می‌کند و مقدار خالی را در فایلی جداگانه تأیید می‌کند. آدرس پایهٔ مثال را با مکان فایل‌های لینک‌شدهٔ خود جایگزین کنید.

```python
import aspose.slides as slides

with slides.Presentation("hyperlinks.pptx") as presentation:
    print("Original base:", presentation.document_properties.hyperlink_base)

    new_base = "https://example.com/new/"
    presentation.document_properties.hyperlink_base = new_base
    presentation.save("hyperlinks-updated.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-updated.pptx") as updated_presentation:
    print("Base preserved:", updated_presentation.document_properties.hyperlink_base == new_base)

    updated_presentation.document_properties.hyperlink_base = ""
    updated_presentation.save("hyperlinks-cleared.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-cleared.pptx") as cleared_presentation:
    print("Base cleared:", cleared_presentation.document_properties.hyperlink_base == "")
```

دو پیام تأیید باید `True` چاپ کنند. پاک کردن پایه، آدرس‌های پیوندهای منفرد را دست نخورده می‌گذارد.

یک پیوند نسبی به `target.pptx` وقتی پایه به پوشهٔ `old` اشاره می‌کرد، `old/target.pptx` را باز می‌کرد. پس از تغییر پایه به پوشهٔ `new`، ذخیره و بازگشایی ارائه، همان پیوند `new/target.pptx` را باز می‌کند. یک پیوند مطلق همان فایل را باز می‌کرد. پیوندهای نسبی خود را در PowerPoint قبل و بعد از جابجایی ارائه یا تغییر پایه تست کنید.

## **افزودن ویژگی‌های سفارشی به ارائه**

ویژگی‌های سفارشی متاداده‌هایی را ذخیره می‌کنند که فیلدهای از پیش تعریف‌شده‌ای برای آن‌ها وجود ندارد. متد [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) به شما امکان می‌دهد مقدار را بر اساس نام ویژگی اختصاص دهید. این مثال یک ارائه ایجاد می‌کند، دو مقدار متنی و یک مقدار عددی نسخه را اضافه می‌کند و ارائه را با [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) ذخیره می‌نماید. اختصاص مقدار به نامی که از قبل وجود دارد، مقدار آن ویژگی را جایگزین می‌کند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    document_properties = presentation.document_properties

    document_properties.set_custom_property_value("Reviewed by", "John Smith")
    document_properties.set_custom_property_value("Confidentiality level", "Internal")
    document_properties.set_custom_property_value("Document version", 2)

    presentation.save("CustomDocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **دسترسی و تغییر ویژگی‌های سفارشی**

این مثال یک ارائه حاوی ویژگی‌های سفارشی را باز می‌کند و با استفاده از [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) بر روی آن‌ها پیمایش می‌کند. [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) یک اندیس صفر‑محور می‌گیرد و نامی را برمی‌گرداند که توسط [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) استفاده می‌شود. این مثال به ارائه‌ای نیاز دارد که تمام ویژگی‌های سفارشی آن رشته باشند. هر نام و مقدار اصلی را چاپ می‌کند، هر مقدار را با یک رشته شماره‌دار جایگزین می‌کند و تغییرات را ذخیره می‌نماید. اگر ویژگی سفارشی وجود نداشته باشد، حلقه هیچ تغییری اعمال نمی‌کند.

```python
import aspose.slides as slides

with slides.Presentation("AccessAndModifyProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    for i in range(document_properties.count_of_custom_properties):
        property_name = document_properties.get_custom_property_name(i)
        property_value = [""]
        document_properties.get_custom_property_value(property_name, property_value)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value[0])

        document_properties.set_custom_property_value(property_name, "New Value " + str(i + 1))

    presentation.save("CustomProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) مقدار را از طریق لیست تک‌عنصری که به عنوان آرگومان دوم پاس داده می‌شود برمی‌گرداند. جای‌گیرنده باید با نوع ویژگی ذخیره‌شده مطابقت داشته باشد: برای رشته `[""]` و برای عدد صحیح `[0]` استفاده کنید. عدم تطابق نوع منجر به `InvalidCastException` می‌شود؛ جای‌گیرنده را بر اساس طرح ویژگی سفارشی خود انتخاب کنید.

## **مثال زنده**

سعی کنید برنامهٔ آنلاین [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) را برای مشاهده نحوه کار با ویژگی‌های سند با استفاده از API Aspose.Slides امتحان کنید:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **سوالات متداول**

**چگونه می‌توان یک ویژگی از پیش تعریف‌شده را از یک ارائه حذف کرد؟**

ویژگی‌های از پیش تعریف‌شده جزئی جدایی‌ناپذیر از ارائه هستند و نمی‌توانند به‌طور کامل حذف شوند. با این حال می‌توانید مقادیر آن‌ها را تغییر دهید یا در صورت امکان به مقدار خالی تنظیم کنید.

**اگر ویژگی سفارشی که قبلاً وجود دارد را اضافه کنم چه اتفاقی می‌افتد؟**

اگر ویژگی سفارشی‌ای که پیش از این موجود است را اضافه کنید، مقدار قبلی آن با مقدار جدید جایگزین می‌شود. نیازی به حذف یا بررسی ویژگی پیش از افزودن ندارید، زیرا Aspose.Slides به‌طور خودکار مقدار ویژگی را به‌روزرسانی می‌کند.

**آیا می‌توان ویژگی‌های ارائه را بدون بارگذاری کامل ارائه دسترسی پیدا کرد؟**

بله. می‌توانید از [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) سپس [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) استفاده کنید تا متاداده‌های ذخیره‌شدهٔ سند را بدون ایجاد نمونهٔ [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) بخوانید. برای مثال کامل گزارش‌گیری به [Build a Lightweight Presentation Inventory](/slides/fa/python-net/examine-presentation/) مراجعه کنید.

**آیا می‌توان ویژگی‌های عمومی یک ارائهٔ رمزنگار شده را بدون گذرواژهٔ باز کردن آن خواند؟**

بله. ارائه باید با [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) برابر `False` رمزنگاری شده باشد و با [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) برابر `True` بارگذاری شود.

**آیا می‌توان یک فایل PPTX رمزنگار شده را در حالت فقط‑ویژگی‑سند به‌روزرسانی کرد؟**

خیر. داده‌های عمومی و رمزنگاری‌شده باید همگام باشند، بنابراین به‌روزرسانی یک فایل PPTX رمزنگار شده مستلزم بارگذاری کامل ارائه با گذرواژهٔ صحیح باز کردن است.