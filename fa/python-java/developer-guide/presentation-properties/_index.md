---
title: مدیریت ویژگی‌های ارائه در Python
linktitle: ویژگی‌های ارائه
type: docs
weight: 70
url: /fa/python-java/presentation-properties/
keywords:
- ویژگی‌های PowerPoint
- ویژگی‌های ارائه
- ویژگی‌های سند
- ویژگی‌های تعبیه‌شده
- ویژگی‌های سفارشی
- ویژگی‌های پیشرفته
- مدیریت ویژگی‌ها
- اصلاح ویژگی‌ها
- فراداده سند
- ویرایش فراداده
- زبان تصحیح
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "ویژگی‌های ارائه را در Aspose.Slides برای Python از طریق Java به‌طور کامل مدیریت کنید و جستجو، برندینگ و جریان کار را در فایل‌های PowerPoint و OpenDocument خود بهینه‌سازی کنید."
---
## **مقدمه**

Aspose.Slides برای Python از طریق Java از ویژگی‌های سند **تعبیه‌شده** و **سفارشی** پشتیبانی می‌کند. از این ویژگی‌ها برای خواندن و به‌روزرسانی متادیتای ارائه، مانند نویسنده، عنوان و مقادیر تعریف‌شده توسط کاربر استفاده کنید.

Aspose.Slides به شما امکان می‌دهد با ویژگی‌های سند ارائه از طریق کلاس [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) کار کنید. یک نمونه از این کلاس توسط [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) برگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این ویژگی‌ها را بخوانید، تغییر دهید و مدیریت کنید.

{{% alert color="info" title="Note" %}}
Aspose.Slides متادیتای برنامه و تولیدکننده را هنگام ذخیره‌سازی ارائه‌ها مدیریت می‌کند؛ این فیلدها نرم‌افزاری که خروجی را ایجاد کرده است شناسایی می‌کنند.
{{% /alert %}}

## **مدیریت ویژگی‌های ارائه**

ویژگی‌های سند اطلاعات توصیفی را در کنار محتوای ارائه ذخیره می‌کنند. آن‌ها به دو دسته تقسیم می‌شوند:

- **ویژگی‌های تعبیه‌شده** شامل متادیتای استانداردی مانند عنوان، نویسنده و آمار سند هستند.
- **ویژگی‌های سفارشی** جفت‌های نام/مقدار تعریف‌شده توسط کاربر را ذخیره می‌کنند.

Aspose.Slides برای Python از طریق Java دسترسی به هر دو دسته را فراهم می‌کند. در PowerPoint، **File → Info → Properties → Advanced Properties** را انتخاب کنید تا متادیتای سند را بررسی کنید. این گفت‌و‌گو اطلاعات را در برگه‌هایی مانند **Summary**، **Statistics**، **Contents** و **Custom** دسته‌بندی می‌کند. از برگه **Custom** برای مدیریت ویژگی‌های تعریف‌شده توسط کاربر استفاده کنید.

## **خواندن ویژگی‌های عمومی از یک ارائهٔ رمزشده**

یک گذرواژهٔ باز کردن به طور معمول هر دو محتوای ارائه و ویژگی‌های سند را محافظت می‌کند. زمانی که یک ارائه پس از فراخوانی [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) با مقدار `False` رمزگذاری می‌شود، ویژگی‌های سند آن عمومی می‌مانند. سپس یک برنامه می‌تواند [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) را با مقدار `True` فراخوانی کند و متادیتای عمومی را بدون ارائهٔ گذرواژهٔ باز کردن بخواند.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) کنترل می‌کند Aspose.Slides چه چیزی را بارگذاری می‌کند؛ هیچ چیزی را رمزگشایی نمی‌کند. اگر ویژگی‌ها در رمزگذاری گنجانده شوند، بارگذاری آن‌ها بدون گذرواژه ناموفق می‌شود. اگر ارائه رمزشده نباشد، گزینه نادیده گرفته می‌شود و ارائه کامل بارگذاری می‌شود.

این مثال نیاز به یک ارائهٔ رمزشده دارد که ویژگی‌های سند آن به‌صورت عمومی باقی مانده‌اند. حالت بارگذاری را از طریق [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) بررسی می‌کند و سپس ویژگی‌های تعبیه‌شده را با استفاده از [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) می‌خواند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setOnlyLoadDocumentProperties(True)

presentation = Presentation("public-properties-encrypted.pptx", load_options)
try:
    if presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        properties = presentation.getDocumentProperties()

        print("Author: ", properties.getAuthor())
        print("Title: ", properties.getTitle())
        print("Keywords: ", properties.getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    presentation.dispose()
```

در این حالت، محتویات اسلایدها بارگذاری نمی‌شود. اسلایدها، مسترها، چیدمان‌ها، اشکال، رسانه‌ها و سایر اشیاء ارائه در دسترس نیستند. برنامه‌ها باید همیشه قبل از انجام عملی که نیاز به مدل شیء کامل ارائه دارد، [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) را بررسی کنند.

{{% alert color="warning" title="Warning" %}}
متادیتای عمومی ممکن است نام‌های نویسنده، عناوین، موضوعات، کلمات کلیدی، اطلاعات شرکت، نظرات و مقادیر سفارشی را فاش کند. ویژگی‌های حساس را همراه با ارائه رمزگذاری کنید. آن‌ها را عمومی بگذارید فقط زمانی که سیستم‌های ایندکس‌گذاری، طبقه‌بندی، جستجو یا مدیریت سند نیاز خاصی برای دسترسی به آن‌ها بدون گذرواژه دارند.
{{% /alert %}}

## **به‌روزرسانی ویژگی‌های یک ارائهٔ رمزشده**

برای یک فایل PPTX رمزشده، ارائه‌ای که پس از فراخوانی [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) با `True` بارگذاری می‌شود، برای خواندن متادیتای عمومی در نظر گرفته شده است. Aspose.Slides نمی‌تواند ویژگی‌های تغییر یافته را از آن شیء فقط‑متادیتا ذخیره کند زیرا ویژگی‌های عمومی باید با داده‌های متناظر داخل ارائهٔ رمزشده سازگار بمانند. بنابراین به‌روزرسانی آن‌ها نیاز به گذرواژهٔ باز کردن صحیح و بارگذاری کامل دارد.

این مثال نیاز به یک ارائهٔ PPTX رمزشده دارد که ویژگی‌های سند عمومی دارد و گذرواژهٔ باز کردن شناخته‌شده‌ای دارد. با استفاده از [LoadOptions.setPassword](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setPassword) ارائهٔ کامل را باز می‌کند، ویژگی‌های تعبیه‌شدهٔ عمومی را به‌روز می‌کند و نتیجه را ذخیره می‌کند. سپس با [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#isEncrypted) صحت حفظ رمزگذاری را بررسی می‌کند و متادیتای عمومی را بدون گذرواژه دوباره باز می‌کند تا مقادیر جدید را تأیید کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, PresentationFactory, SaveFormat

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation(input_path, load_options)
try:
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap")
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed")
    
    presentation.save(output_path, SaveFormat.Pptx)
finally:
    presentation.dispose()

presentation_info = PresentationFactory.getInstance().getPresentationInfo(output_path)
print("The presentation is encrypted: ", presentation_info.isEncrypted())

metadata_load_options = LoadOptions()
metadata_load_options.setOnlyLoadDocumentProperties(True)

metadata_presentation = Presentation(output_path, metadata_load_options)
try:
    if metadata_presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        print("Title: ", metadata_presentation.getDocumentProperties().getTitle())
        print("Keywords: ", metadata_presentation.getDocumentProperties().getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    metadata_presentation.dispose()
```

اگر برنامه اجازهٔ رمزگشایی یا بارگذاری محتوای ارائه را نداشته باشد، باید ویژگی‌های عمومی یک فایل PPTX رمزشده را به‌عنوان فقط‑خواندنی در نظر بگیرد.

## **دسترسی به ویژگی‌های تعبیه‌شده**

کلاس [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) متادیتای تعبیه‌شده را از طریق متدهای getter مانند [getAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getAuthor)، [getTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTitle) و [getCreatedTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCreatedTime) نمایش می‌دهد. این مثال یک ارائهٔ موجود را باز می‌کند و متادیتای ذخیره‌شده آن را در کنسول چاپ می‌کند. مقادیر بسته به ارائهٔ ورودی متفاوت هستند؛ برخی فیلدها ممکن است خالی باشند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AccessBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    print("Category:", document_properties.getCategory())
    print("Content status:", document_properties.getContentStatus())
    print("Creation date:", document_properties.getCreatedTime())
    print("Author:", document_properties.getAuthor())
    print("Comments:", document_properties.getComments())
    print("Keywords:", document_properties.getKeywords())
    print("Last modified by:", document_properties.getLastSavedBy())
    print("Manager:", document_properties.getManager())
    print("Modified date:", document_properties.getLastSavedTime())
    print("Presentation format:", document_properties.getPresentationFormat())
    print("Last print date:", document_properties.getLastPrinted())
    print("Is shared between producers:", document_properties.getSharedDoc())
    print("Subject:", document_properties.getSubject())
    print("Title:", document_properties.getTitle())
finally:
    presentation.dispose()
```

### **گزارش شمارهٔ بازبینی و مدت زمان ویرایش**

برای گزارش یک ردیف برای هر فایل PPTX در پوشه `presentations`، از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) و [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) استفاده کنید تا [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) آن را بدون بارگذاری اسلایدها برای ویرایش بخوانید. API Python via Java مدت زمان ویرایش را بر حسب میلی‌ثانیه برمی‌گرداند. مثال آن را به صورت ساعت، دقیقه و ثانیه قالب‌بندی می‌کند و برای مدت‌های ۲۴ ساعت یا بیشتر شمارش روز را اضافه می‌کند.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

factory = PresentationFactory.getInstance()
print("File | RevisionNumber | TotalEditingTime")
for path in sorted(Path("presentations").glob("*.pptx")):
    if not path.is_file():
        continue

    info = factory.getPresentationInfo(str(path))
    properties = info.readDocumentProperties()
    total_seconds = int(properties.getTotalEditingTime()) // 1000
    days, remaining_seconds = divmod(total_seconds, 86400)
    hours, remaining_seconds = divmod(remaining_seconds, 3600)
    minutes, seconds = divmod(remaining_seconds, 60)
    editing_time = f"{hours:02d}:{minutes:02d}:{seconds:02d}"
    if days:
        editing_time = f"{days}.{editing_time}"

    print(f"{path.name} | {properties.getRevisionNumber()} | {editing_time}")
```

برای ارائه‌ای که زمان ویرایش ثبت‌شدهٔ آن ۱ روز، ۲ ساعت و ۵ دقیقه باشد، گزارش خروجی زیر را نشان می‌دهد.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[getRevisionNumber](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getRevisionNumber) مقداری را می‌خواند که برنامه‌ها می‌توانند با [setRevisionNumber](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setRevisionNumber) تغییر دهند. شمارهٔ بازبینی به تنهایی نمی‌تواند تعداد دفعات ذخیرهٔ ارائه یا تاریخچهٔ نسخه‌ها را تعیین کند.

[getTotalEditingTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTotalEditingTime) مدت زمان ویرایش ثبت‌شده در فایل را می‌خواند. مقدار `00:00:00` به این معناست که مدت زمان ذخیره‌شده صفر است، حتی اگر کسی ارائه را ویرایش کرده باشد.

## **تغییر ویژگی‌های تعبیه‌شده**

برای به‌روزرسانی متادیتای تعبیه‌شده، از متدهای setter روی شیء برگردانده‌شده توسط [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) استفاده کنید. این مثال یک ارائهٔ موجود را باز می‌کند، [setAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setAuthor)، [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setTitle)، [setSubject](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setSubject)، [setComments](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setComments) و [setManager](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setManager) را فراخوانی می‌کند و سپس ارائهٔ به‌روز شده را با [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) ذخیره می‌کند. فایل PPTX ذخیره‌شده شامل متادیتای جدید خواهد بود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("ModifyBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.setAuthor("Aspose.Slides for Python via Java")
    document_properties.setTitle("Manage PowerPoint Presentation Properties")
    document_properties.setSubject("Modify Built-in Properties")
    document_properties.setComments("Aspose description")
    document_properties.setManager("Aspose manager")

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **مدیریت پایهٔ پیوندهای فرامشی**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getHyperlinkBase) پایهٔ سطری برای پیوندهای نسبی در سطح سند را برمی‌گرداند. از [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setHyperlinkBase) برای تغییر یا پاک کردن آن استفاده کنید. این کار هنگام جابه‌جایی یک ارائه و فایل‌های پیوست شده‌اش به مکان دیگری مفید است. این ویژگی با [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) پیوندهای منفرد متفاوت است: تغییر پایه آدرس‌های ذخیره‌شدهٔ پیوندها را بازنویسی نمی‌کند و مقصدهای مطلق را تغییر نمی‌دهد.

این مثال نیاز به ارائه‌ای دارد که هم یک پیوند نسبی مانند `target.html` و هم یک پیوند مطلق مانند `https://example.org/absolute.html` داشته باشد. پایهٔ موجود را می‌خواند، آدرس پایهٔ جدیدی اختصاص می‌دهد و برای بررسی مقدار، ارائه را ذخیره و دوباره باز می‌کند. سپس پایه را با رشتهٔ خالی پاک می‌کند و مقدار خالی را در فایل ذخیره‌شدهٔ جداگانه تأیید می‌کند. آدرس پایهٔ مثال را با مسیر فایل‌های پیوست خود جایگزین کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("hyperlinks.pptx")
try:
    print("Original base:", presentation.getDocumentProperties().getHyperlinkBase())

    new_base = "https://example.com/new/"
    presentation.getDocumentProperties().setHyperlinkBase(new_base)
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx)

    updated_presentation = Presentation("hyperlinks-updated.pptx")
    try:
        print("Base preserved:", new_base == updated_presentation.getDocumentProperties().getHyperlinkBase())

        updated_presentation.getDocumentProperties().setHyperlinkBase("")
        updated_presentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx)

        cleared_presentation = Presentation("hyperlinks-cleared.pptx")
        try:
            print("Base cleared:", "" == cleared_presentation.getDocumentProperties().getHyperlinkBase())
        finally:
            cleared_presentation.dispose()
    finally:
        updated_presentation.dispose()
finally:
    presentation.dispose()
```

دو پیام تأیید باید مقدار `True` را چاپ کنند. پاک کردن پایه آدرس‌های پیوندهای منفرد را دست‌نخورده می‌گذارد.

یک پیوند نسبی به `target.pptx` زمانی که پایه به پوشهٔ `old` اشاره می‌کرد، `old/target.pptx` را باز می‌کرد. پس از تغییر پایه به پوشهٔ `new`، ذخیره و بازگشایی ارائه، همان پیوند `new/target.pptx` را باز می‌کرد. یک پیوند مطلق به همان فایل ادامه داد. قبل و بعد از جابه‌جایی ارائه یا تغییر پایه، پیوندهای نسبی خود را در PowerPoint تست کنید.

## **افزودن ویژگی‌های سفارشی به ارائه**

ویژگی‌های سفارشی متادیتایی را ذخیره می‌کنند که فیلد تعبیه‌شدهٔ متناظری ندارند. متد [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) به شما اجازه می‌دهد مقدار را بر اساس نام ویژگی اختصاص دهید. این مثال یک ارائه ایجاد می‌کند، دو مقدار متنی و یک مقدار عددی نسخه (با استفاده از `jpype.JInt` برای ارسال یک عدد صحیح جاوا) اضافه می‌کند و ارائه را با [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) ذخیره می‌کند. اختصاص مقدار به یک نام موجود، مقدار آن ویژگی را بازنویسی می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.set_Item("Reviewed by", "John Smith")
    document_properties.set_Item("Confidentiality level", "Internal")
    document_properties.set_Item("Document version", jpype.JInt(2))

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **دسترسی و تغییر ویژگی‌های سفارشی**

این مثال یک ارائه حاوی ویژگی‌های سفارشی را باز می‌کند و با استفاده از [getCountOfCustomProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCountOfCustomProperties) روی آن‌ها تکرار می‌کند. [getCustomPropertyName](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCustomPropertyName) یک اندیس صفر‑مبنا می‌گیرد و نام استفاده‌شده توسط [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) را برمی‌گرداند. مثال هر نام و مقدار اصلی را چاپ می‌کند، هر مقدار را با یک رشتهٔ عددی جایگزین می‌کند بی‌توجه به نوع اصلی آن و تغییرات را ذخیره می‌نماید. اگر ویژگی سفارشی وجود نداشته باشد، حلقه هیچ تغییری اعمال نمی‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessAndModifyProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    for i in range(document_properties.getCountOfCustomProperties()):
        property_name = document_properties.getCustomPropertyName(i)
        property_value = document_properties.get_Item(property_name)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value)

        document_properties.set_Item(property_name, f"New Value {i + 1}")

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **مثال زنده**

سعی کنید برنامهٔ آنلاین [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) را برای مشاهدهٔ نحوه کار با ویژگی‌های سند با استفاده از API Aspose.Slides امتحان کنید:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **سوالات متداول**

**چگونه می‌توان یک ویژگی تعبیه‌شده را از یک ارائه حذف کرد؟**

ویژگی‌های تعبیه‌شده جزئی جدی از ارائه هستند و نمی‌توان آن‌ها را به‌طور کامل حذف کرد. اما می‌توانید مقدار آن‌ها را تغییر دهید یا اگر ویژگی خاص اجازهٔ خالی‌سازی را می‌دهد، مقادیر را خالی کنید.

**اگر یک ویژگی سفارشی که قبلاً وجود دارد را اضافه کنم چه می‌شود؟**

اگر یک ویژگی سفارشی که قبلاً وجود دارد را اضافه کنید، مقدار موجود آن با مقدار جدید بازنویسی می‌شود. نیازی به حذف یا بررسی قبلی ویژگی ندارید، زیرا Aspose.Slides به‌صورت خودکار مقدار ویژگی را به‌روز می‌کند.

**آیا می‌توان بدون بارگذاری کامل ارائه به ویژگی‌های آن دسترسی پیدا کرد؟**

بله. می‌توانید از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) و سپس [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) استفاده کنید تا متادیتای ذخیره‌شدهٔ سند را بدون ایجاد یک نمونهٔ [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) بخوانید. برای مثال کامل گزارش و محدودیت‌های خاص فرمت، به [ساخت فهرست سبک ارائه](/slides/fa/python-java/examine-presentation/) مراجعه کنید.

**آیا می‌توان ویژگی‌های عمومی یک ارائهٔ رمزشده را بدون گذرواژهٔ باز کردن آن خواند؟**

بله. ارائه باید پس از فراخوانی [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) با `False` رمزشده باشد و پس از فراخوانی [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) با `True` بارگذاری شود.

**آیا می‌توان یک فایل PPTX رمزشده را در حالت فقط‑ویژگی‑مستند به‌روزرسانی کرد؟**

خیر. داده‌های ویژگی عمومی و رمزگذاری‌شده باید سازگار باقی بمانند، بنابراین به‌روزرسانی یک فایل PPTX رمزشده نیازمند بارگذاری کامل ارائه با گذرواژهٔ باز کردن صحیح است.