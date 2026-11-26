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
- ویژگی‌های پیش‌فرض
- ویژگی‌های سفارشی
- ویژگی‌های پیشرفته
- مدیریت ویژگی‌ها
- تغییر ویژگی‌ها
- فرادادهٔ سند
- ویرایش فراداده
- زبان اصلاحیه
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "در Aspose.Slides برای Python via .NET بر ویژگی‌های ارائه تسلط پیدا کنید و جستجو، برندینگ و جریان کاری را در فایل‌های PowerPoint خود بهینه کنید."
---
## **معرفی**

Aspose.Slides for Python via .NET از **ویژگی‌های پیش‌فرض** و **سفارشی** سند پشتیبانی می‌کند. از این ویژگی‌ها برای خواندن و به‌روزرسانی فراداده ارائه، مانند نویسنده، عنوان و مقادیر تعریف‌شده توسط کاربر استفاده کنید.

Aspose.Slides به شما امکان کار با ویژگی‌های سند ارائه را از طریق کلاس [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) می‌دهد. یک نمونه از این کلاس توسط [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) بازگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این ویژگی‌ها را بخوانید، تغییر دهید و مدیریت کنید.

{{% alert color="info" title="Note" %}}
Aspose.Slides متادیتای برنامه و تولیدکننده را هنگام ذخیره‌سازی ارائه‌ها مدیریت می‌کند؛ این فیلدها نرم‌افزار سازنده خروجی را شناسایی می‌کنند.
{{% /alert %}}

## **مدیریت ویژگی‌های ارائه**

ویژگی‌های سند اطلاعات توصیفی را همراه با محتوای ارائه ذخیره می‌کنند. آنها به دو دسته تقسیم می‌شوند:

- **ویژگی‌های پیش‌فرض** شامل فراداده‌های استاندارد مانند عنوان، نویسنده و آمار سند هستند.
- **ویژگی‌های سفارشی** جفت نام/مقدار تعریف‌شده توسط کاربر را ذخیره می‌کنند.

Aspose.Slides for Python via .NET دسترسی به هر دو دسته را فراهم می‌کند. در PowerPoint، برای بررسی فراداده سند، **File → Info → Properties → Advanced Properties** را انتخاب کنید. این گفت‌و‌گو اطلاعات را به زبانه‌های **خلاصه**، **آمار**, **محتوا** و **سفارشی** گروه‌بندی می‌کند. از زبانه **سفارشی** برای مدیریت ویژگی‌های تعریف‌شده توسط کاربر استفاده کنید.

## **خواندن ویژگی‌های عمومی از یک ارائه رمزگذاری‌شده**

معمولاً یک رمز عبور بازگشایی هم محتوای ارائه و هم ویژگی‌های سند را محافظت می‌کند. هنگامی که یک ارائه با [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) روی `False` رمزگذاری شود، ویژگی‌های سند آن عمومی می‌مانند. سپس یک برنامه می‌تواند [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) را روی `True` تنظیم کند و فراداده عمومی را بدون ارائه رمز عبور بازگشایی بخواند.

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) تعیین می‌کند Aspose.Slides چه چیزی را بارگذاری می‌کند؛ هیچ چیزی را رمزگشایی نمی‌کند. اگر ویژگی‌ها در رمزگذاری گنجانده شده باشند، بارگذاری آنها بدون رمز عبور شکست می‌خورد. اگر ارائه رمزگذاری نشده باشد، این گزینه نادیده گرفته می‌شود و ارائه کامل بارگذاری می‌شود.

این مثال نیازمند ارائه‌ای رمزگذاری‌شده است که ویژگی‌های سند آن عمومی باقی مانده‌اند. حالت بارگذاری را از طریق [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) بررسی می‌کند و سپس ویژگی‌های پیش‌فرض را از طریق [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) می‌خواند:

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

در این حالت محتوای اسلاید بارگذاری نمی‌شود. اسلایدها، مسترها، لایه‌ها، اشکال، رسانه‌ها و سایر اشیای ارائه در دسترس نیستند. برنامه‌ها باید همیشه قبل از انجام عملیاتی که به مدل شیٔ کامل ارائه نیاز دارد، [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) را بررسی کنند.

{{% alert color="warning" title="Security" %}}
متادیتای عمومی ممکن است نام نویسندگان، عناوین، موضوعات، کلیدواژه‌ها، اطلاعات شرکت، نظرات و مقادیر سفارشی را افشا کند. ویژگی‌های حساس را به‌همراه ارائه رمزگذاری کنید. آنها را فقط زمانی عمومی بگذارید که سیستم‌های ایندکس‌گذاری، طبقه‌بندی، جستجو یا مدیریت سند نیاز خاصی برای دسترسی بدون رمز عبور داشته باشند.
{{% /alert %}}

## **به‌روزرسانی ویژگی‌های یک ارائه رمزگذاری‌شده**

برای یک فایل PPTX رمزگذاری‌شده، ارائه‌ای که با [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) بارگذاری می‌شود، برای خواندن متادیتای عمومی هدف‌گذاری شده است. Aspose.Slides نمی‌تواند ویژگی‌های تغییر یافته را از آن شیٔ فقط‑متادیتا ذخیره کند، زیرا ویژگی‌های عمومی باید با داده‌های مربوطه داخل ارائه رمزگذاری‌شده سازگار باشند. بنابراین به‌روزرسانی آنها نیازمند رمز عبور بازگشایی صحیح و بارگذاری کامل است.

این مثال نیازمند یک ارائه PPTX رمزگذاری‌شده با ویژگی‌های سند عمومی و رمز عبور بازگشایی شناخته‌شده است. ارائه کامل را با [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) باز می‌کند، ویژگی‌های پیش‌فرض عمومی را به‌روزرسانی می‌کند و نتیجه را ذخیره می‌نماید. سپس با استفاده از [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) اطمینان می‌یابد که رمزگذاری حفظ شده و متادیتای عمومی را بدون رمز عبور باز می‌کند تا مقادیر جدید را تأیید کند:

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

اگر برنامه اجازهٔ رمزگشایی یا بارگذاری محتوای ارائه را نداشته باشد، باید ویژگی‌های عمومی یک فایل PPTX رمزگذاری‌شده را به‌عنوان فقط‑خواندنی در نظر بگیرد.

## **دسترسی به ویژگی‌های پیش‌فرض**

کلاس [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) فراداده‌های پیش‌فرض را از طریق ویژگی‌های تایپ‌شده مانند [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/)، [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/) و [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/) در دسترس می‌گذارد. این مثال یک ارائه موجود را باز می‌کند و فراداده‌های ذخیره‌شده آن را در کنسول چاپ می‌کند. مقادیر بسته به ارائه ورودی متفاوت‌اند؛ برخی فیلدها ممکن است خالی باشند.

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

### **گزارش شماره بازنگری و زمان ویرایش**

برای گزارش شماره بازنگری و زمان کل ویرایش برای هر فایل PPTX در پوشهٔ `presentations`، از [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) برای بازیابی [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) بدون بارگذاری اسلایدها برای ویرایش استفاده کنید. پایتون مدت زمان را به‌صورت `timedelta` نمایش می‌دهد و در صورت رسیدن زمان ثبت‌شده به ۲۴ ساعت، تعداد روزها را نیز شامل می‌شود.

```python
from pathlib import Path

import aspose.slides as slides

print("File | RevisionNumber | TotalEditingTime")
for path in Path("presentations").glob("*.pptx"):
    if path.is_file():
        info = slides.PresentationFactory.instance.get_presentation_info(str(path))
        properties = info.read_document_properties()
        print(f"{path.name} | {properties.revision_number} | {properties.total_editing_time}")
```

برای یک ارائه با ۱ روز، ۲ ساعت و ۵ دقیقه زمان ویرایش ثبت‌شده، گزارش شامل ردیف زیر خواهد بود.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1 day, 2:05:00
```

[DocumentProperties.revision_number](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/revision_number/) فراداده قابل نوشتن است. تنها مقدار آن نمی‌تواند تعداد دفعات ذخیره شدن ارائه یا تاریخچهٔ نسخه‌های آن را تعیین کند.

[DocumentProperties.total_editing_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/total_editing_time/) مدت زمان ویرایشی ذخیره‌شده در فایل را گزارش می‌دهد. مقدار `0:00:00` به این معناست که مدت زمان ثبت‌شده صفر است، حتی اگر شخصی ارائه را ویرایش کرده باشد.

## **تغییر ویژگی‌های پیش‌فرض**

برای به‌روزرسانی فراداده‌های پیش‌فرض، مقادیر را به ویژگی‌های قابل نوشتن که توسط [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) نمایش داده می‌شوند، اختصاص دهید. این مثال یک ارائه موجود را باز می‌کند، [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/)، [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/)، [DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/)، [DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/) و [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/) را تنظیم می‌نماید و سپس ارائه به‌روزشده را با [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) ذخیره می‌کند. فایل PPTX ذخیره‌شده حاوی متادیتای جدید خواهد بود.

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

## **مدیریت Hyperlink Base**

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) پایهٔ سند برای لینک‌های نسبی را ذخیره می‌کند. این ویژگی هنگام جابجا کردن یک ارائه و فایل‌های پیوست به مکان دیگر مفید است. این مقدار جدا از [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) یک لینک منفرد است: تغییر پایه باعث تغییر آدرس‌های ذخیره‌شده یا مقصدهای مطلق نمی‌شود.

مثال نیازمند ارائه‌ای است که هم یک لینک نسبی مانند `target.html` و هم یک لینک مطلق به یک فایل یا وب‌سایت داشته باشد. پایهٔ موجود را می‌خواند، پایهٔ جدیدی اختصاص می‌دهد و پس از ذخیره و بازگشایی مجدد، مقدار را بررسی می‌کند. سپس پایه را با `""` پاک می‌کند و مقدار خالی را در فایل ذخیره‌شدهٔ دیگری تأیید می‌کند. پایهٔ مثال را با مکان فایل‌های پیوست خود جایگزین کنید.

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

دو پیام تأیید باید `True` چاپ کنند. پاک کردن پایه آدرس‌های لینک‌های منفرد را دست نخورده می‌گذارد.

یک لینک نسبی به `target.pptx`، وقتی پایه به پوشهٔ `old` اشاره می‌کرد، `old/target.pptx` را باز می‌کرد. پس از تغییر پایه به پوشهٔ `new`، ذخیره و بازگشایی مجدد، همان لینک `new/target.pptx` را باز می‌کرد. یک لینک مطلق همچنان همان فایل را باز می‌داشت. لینک‌های نسبی خود را در PowerPoint قبل و بعد از جابه‌جایی ارائه یا تغییر پایه تست کنید.

## **افزودن ویژگی‌های سفارشی به ارائه**

ویژگی‌های سفارشی فراداده‌ای را ذخیره می‌کنند که فیلد پیش‌فرضی برای آن‌ها وجود ندارد. متد [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) به شما اجازه می‌دهد مقدار را بر اساس نام ویژگی اختصاص دهید. این مثال یک ارائه می‌سازد، دو مقدار متنی و یک مقدار عددی نسخه را اضافه می‌کند و سپس ارائه را با [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) ذخیره می‌نماید. اختصاص مقدار به نام موجود، مقدار آن ویژگی را جایگزین می‌کند.

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

این مثال یک ارائه حاوی ویژگی‌های سفارشی را باز می‌کند و از [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) برای پیمایش آن‌ها استفاده می‌نماید. [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) یک اندیس صفر‑محور می‌گیرد و نام استفاده شده توسط [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) را برمی‌گرداند. مثال نیازمند ارائه‌ای است که تمام ویژگی‌های سفارشی آن از نوع رشته باشند. هر نام و مقدار اصلی را چاپ می‌کند، هر مقدار را با رشته‌ای شماره‌دار جایگزین می‌نماید و تغییرات را ذخیره می‌کند. اگر ویژگی سفارشی‌ای وجود نداشته باشد، حلقه تغییری اعمال نمی‌کند.

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

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) مقدار را از طریق لیست تک‌عنصری که به عنوان آرگومان دوم به آن پاس می‌شود، برمی‌گرداند. جای‌نگهدارنده باید با نوع ویژگی ذخیره‌شده مطابقت داشته باشد: برای رشته `[""]` و برای عدد صحیح `[0]` استفاده کنید. عدم تطابق نوع منجر به `InvalidCastException` می‌شود؛ جای‌نگهدارنده را بر اساس طرح‌وارهٔ ویژگی‌ سفارشی خود انتخاب کنید.

## **مثال زنده**

سعی کنید برنامهٔ آنلاین [نمایش و ویرایش متادیتای PowerPoint](https://products.aspose.app/slides/metadata) را مشاهده کنید تا ببینید چگونه با استفاده از API Aspose.Slides با ویژگی‌های سند کار کنید:

[![نمایش و ویرایش متادیتای PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **سؤالات متداول**

**چگونه می‌توان یک ویژگی پیش‌فرض را از یک ارائه حذف کرد؟**

ویژگی‌های پیش‌فرض بخشی یکپارچه از ارائه هستند و نمی‌توانند کاملاً حذف شوند. با این حال، می‌توانید مقادیر آن‌ها را تغییر دهید یا در صورت امکان آن‌ها را خالی کنید.

**اگر یک ویژگی سفارشی که از قبل وجود دارد اضافه کنم چه اتفاقی می‌افتد؟**

اگر یک ویژگی سفارشی که از قبل وجود دارد اضافه کنید، مقدار موجود با مقدار جدید بازنویسی می‌شود. نیازی به حذف یا بررسی قبلی ویژگی نیست، زیرا Aspose.Slides به‌طور خودکار مقدار ویژگی را به‌روز می‌کند.

**آیا می‌توانم ویژگی‌های ارائه را بدون بارگذاری کامل ارائه دسترسی داشته باشم؟**

بله. از [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) سپس [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) استفاده کنید تا فرادادهٔ سند ذخیره‌شده را بدون ایجاد نمونهٔ [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) بخوانید. برای مثال کامل گزارش و محدودیت‌های فرمات‑خاص، بخش [ساخت موجودی سبک ارائه](/slides/fa/python-net/examine-presentation/) را ببینید.

**آیا می‌توانم ویژگی‌های عمومی یک ارائه رمزگذاری‌شده را بدون رمز عبور بازگشایی آن بخوانم؟**

بله. ارائه باید با [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) روی `False` رمزگذاری شده باشد و باید با [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) روی `True` بارگذاری شود.

**آیا می‌توانم یک فایل PPTX رمزگذاری‌شده را در حالت صرفاً‑ویژگی‑سند به‌روز کنم؟**

خیر. داده‌های عمومی و رمزگذاری‌شده باید سازگار باقی بمانند، بنابراین به‌روزرسانی یک فایل PPTX رمزگذاری‌شده مستلزم بارگذاری کامل ارائه با رمز عبور بازگشایی صحیح است.