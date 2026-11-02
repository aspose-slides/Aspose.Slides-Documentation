---
title: مدیریت خواص ارائه در Python
linktitle: خواص ارائه
type: docs
weight: 70
url: /fa/python-java/presentation-properties/
keywords:
- خواص PowerPoint
- خواص ارائه
- خواص سند
- خواص توکار
- خواص سفارشی
- خواص پیشرفته
- مدیریت خواص
- تغییر خواص
- فراداده سند
- ویرایش فراداده
- زبان تصحیح
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "مدیریت کامل خواص ارائه در Aspose.Slides برای Python از طریق Java و بهینه‌سازی جستجو، برندسازی و جریان کار در فایل‌های PowerPoint و OpenDocument شما."
---
## **معرفی**

Aspose.Slides for Python via Java از ویژگی‌های **توکار** و **سفارشی** برای خواص سند پشتیبانی می‌کند. از این خواص برای خواندن و به‌روزرسانی فراداده‌های ارائه، مانند نویسنده، عنوان و مقادیر تعریف‌شده توسط کاربر استفاده کنید.

Aspose.Slides به شما اجازه می‌دهد تا با خواص سند ارائه از طریق کلاس [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) کار کنید. یک نمونه از این کلاس توسط [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) بازگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این خواص را بخوانید، تغییر دهید و مدیریت کنید.

{{% alert color="info" title="Note" %}}
Aspose.Slides هنگام ذخیره ارائه‌ها، متاداده‌های برنامه و تولیدکننده را مدیریت می‌کند؛ این فیلدها نرم‌افزاری را که خروجی را ایجاد کرده است شناسایی می‌کنند.
{{% /alert %}}

## **مدیریت خواص ارائه**

خواص سند اطلاعات توصیفی را در کنار محتوای ارائه ذخیره می‌کنند. آن‌ها به دو دسته تقسیم می‌شوند:

- **خواص توکار** شامل متاداده‌های استاندارد مانند عنوان، نویسنده و آمار سند هستند.
- **خواص سفارشی** جفت‌های نام/مقدار تعریف‌شده توسط کاربر را ذخیره می‌کنند.

Aspose.Slides for Python via Java دسترسی به هر دو دسته را فراهم می‌کند. در PowerPoint، **File → Info → Properties → Advanced Properties** را انتخاب کنید تا متاداده‌های سند را بررسی کنید. دیالوگ اطلاعات را در برگه‌هایی مانند **Summary**, **Statistics**, **Contents**, و **Custom** گروه‌بندی می‌کند. از برگه **Custom** برای مدیریت خواص تعریف‌شده توسط کاربر استفاده کنید.

## **خواندن خواص عمومی از یک ارائه رمزگذاری‌شده**

یک رمز عبور باز کردن معمولاً هم محتوای ارائه و هم خواص سند را محافظت می‌کند. وقتی یک ارائه پس از فراخوانی [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) با `False` رمزگذاری شود، خواص سند آن به‌صورت عمومی باقی می‌مانند. سپس یک برنامه می‌تواند با فراخوانی [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) با `True`، متاداده‌های عمومی را بدون ارائه رمز عبور باز کردن بخواند.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) مشخص می‌کند که Aspose.Slides چه چیزی را بارگذاری می‌کند؛ این متد هیچ چیز را رمزگشایی نمی‌کند. اگر خواص در رمزگذاری گنجانده شوند، بارگذاری آن‌ها بدون رمز عبور شکست می‌خورد. اگر ارائه رمزگذاری نشده باشد، این گزینه نادیده گرفته می‌شود و کل ارائه بارگذاری می‌شود.

این مثال به یک ارائهٔ رمزگذاری‌شده نیاز دارد که خواص سند آن به‌صورت عمومی باقی مانده باشد. حالت بارگذاری از طریق [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) تأیید شده و سپس خواص توکار از طریق [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) خوانده می‌شود:

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

در این حالت، محتوای اسلاید بارگذاری نمی‌شود. اسلایدها، مسترها، لایه‌ها، اشکال، رسانه‌ها و سایر اشیای ارائه در دسترس نیستند. برنامه‌ها باید همیشه قبل از انجام عملی که به مدل شیء کامل ارائه نیاز دارد، [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) را بررسی کنند.

{{% alert color="warning" title="Warning" %}}
متاداده‌های عمومی ممکن است نام‌های نویسندگان، عناوین، موضوعات، کلمات کلیدی، اطلاعات شرکت، نظرات و مقادیر سفارشی را فاش کنند. خواص حساسی را همراه با ارائه رمزگذاری کنید. تنها در صورتی که سیستم‌های ایندکس‌گذاری، طبقه‌بندی، جستجو یا مدیریت سند نیاز خاصی به دسترسی بدون رمز عبور داشته باشند، آن‌ها را عمومی نگه دارید.
{{% /alert %}}

## **به‌روزرسانی خواص یک ارائه رمزگذاری‌شده**

برای یک فایل PPTX رمزگذاری‌شده، ارائه‌ای که پس از فراخوانی [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) با `True` بارگذاری می‌شود، برای خواندن متاداده‌های عمومی در نظر گرفته شده است. Aspose.Slides نمی‌تواند خواص تغییر یافته را از این شیء فقط‑متاداده ذخیره کند، زیرا خواص عمومی باید با داده‌های مربوطه در داخل ارائهٔ رمزگذاری‌شده سازگار بمانند. بنابراین به‌روزرسانی آن‌ها نیاز به رمز عبور باز کردن صحیح و بارگذاری کامل دارد.

این مثال به یک ارائهٔ PPTX رمزگذاری‌شده با خواص سند عمومی و رمز عبور باز کردن شناخته‌شده نیاز دارد. ابتدا با استفاده از [LoadOptions.setPassword](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setPassword) ارائهٔ کامل را باز می‌کند، خواص توکار عمومی را به‌روزرسانی می‌کند و نتیجه را ذخیره می‌نماید. سپس با استفاده از [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#isEncrypted) تأیید می‌کند که رمزگذاری حفظ شده و متاداده‌های عمومی را بدون رمز عبور باز می‌کند تا مقادیر جدید را تأیید کند:

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

اگر برنامه اجازهٔ رمزگشایی یا بارگذاری محتوای ارائه را نداشته باشد، باید خواص عمومی یک فایل PPTX رمزگذاری‌شده را به‌عنوان فقط‑خواندنی در نظر بگیرد.

## **دسترس به خواص توکار**

کلاس [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) متاداده‌های توکار را از طریق متدهای getter مانند [getAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getAuthor)، [getTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTitle) و [getCreatedTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCreatedTime) در دسترس قرار می‌دهد. این مثال یک ارائهٔ موجود را باز می‌کند و متاداده‌های ذخیره شده را در کنسول چاپ می‌کند. مقادیر بسته به ارائهٔ ورودی متفاوت هستند؛ برخی فیلدها ممکن است خالی باشند.

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

## **تغییر خواص توکار**

برای به‌روزرسانی متاداده‌های توکار، از متدهای setter بر روی شیء بازگردانده‌شده توسط [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) استفاده کنید. این مثال یک ارائهٔ موجود را باز می‌کند، [setAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setAuthor)، [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setTitle)، [setSubject](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setSubject)، [setComments](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setComments) و [setManager](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setManager) را فراخوانی می‌کند و سپس با [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) ارائهٔ به‌روز شده را ذخیره می‌نماید. فایل PPTX ذخیره‌شده شامل متاداده‌های جدید خواهد بود.

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

## **مدیریت پایهٔ هایپرلینک**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getHyperlinkBase) پایهٔ سطری برای پیوندهای نسبی در سطح سند را برمی‌گرداند. برای تغییر یا پاک کردن آن از [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setHyperlinkBase) استفاده کنید. این کار زمانی مفید است که یک ارائه و فایل‌های مرتبط آن را به مکان دیگری منتقل می‌کنید. این ویژگی مستقل از [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) یک پیوند فردی است: تغییر پایه آدرس‌های ذخیره‌شدهٔ پیوند را بازنویسی نمی‌کند و مقصدهای مطلق را تغییر نمی‌دهد.

این مثال به ارائه‌ای نیاز دارد که هم یک پیوند نسبی مانند `target.html` و هم یک پیوند مطلق مانند `https://example.org/absolute.html` داشته باشد. ابتدا پایهٔ فعلی را می‌خواند، پایهٔ جدیدی اختصاص می‌دهد و ارائه را ذخیره و دوباره باز می‌کند تا مقدار را بررسی کند. سپس پایه را با رشتهٔ خالی پاک می‌کند و مقدار خالی را در فایلی جداگانه تأیید می‌نماید. آدرس پایهٔ مثال را با مکان فایل‌های پیوندی خود جایگزین کنید.

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

دو پیام تأیید باید `True` چاپ کنند. پاک‌کردن پایه آدرس‌های پیوندهای فردی را دست‌نخورده باقی می‌گذارد.

یک پیوند نسبی به `target.pptx` وقتی پایه به پوشهٔ `old` اشاره می‌کرد، `old/target.pptx` را باز می‌کرد. پس از تغییر پایه به پوشهٔ `new`، ذخیره و بارگذاری مجدد ارائه، همان پیوند `new/target.pptx` را باز می‌کند. یک پیوند مطلق همچنان همان فایل را باز می‌کند. پیوندهای نسبی خود را در PowerPoint قبل و بعد از جابجایی ارائه یا تغییر پایه بررسی کنید.

## **افزودن خواص سفارشی به ارائه**

خواص سفارشی متاداده‌هایی را ذخیره می‌کنند که فیلد توکار متناظری ندارند. متد [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) امکان اختصاص مقدار بر حسب نام خاصیت را می‌دهد. این مثال یک ارائه ایجاد می‌کند، دو مقدار متنی و یک مقدار عددی نسخه (با استفاده از `jpype.JInt` برای ارسال یک عدد صحیح جاوا) اضافه می‌نماید و با [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) ارائه را ذخیره می‌کند. اختصاص مقدار به نام موجود، مقدار آن خاصیت را بازنویسی می‌کند.

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

## **دسترس و تغییر خواص سفارشی**

این مثال یک ارائه حاوی خواص سفارشی را باز می‌کند و با استفاده از [getCountOfCustomProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCountOfCustomProperties) بر روی آن‌ها تکرار می‌نماید. [getCustomPropertyName](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCustomPropertyName) یک اندیس صفر‑پایه می‌گیرد و نامی را برمی‌گرداند که توسط [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) استفاده شده است. مثال هر نام و مقدار اصلی را چاپ می‌کند، هر مقدار را با رشته‌ای شماره‌دار جایگزین می‌نماید صرف‌نظر از نوع اصلی آن، و تغییرات را ذخیره می‌کند. اگر خاصیتی سفارشی وجود نداشته باشد، حلقه هیچ تغییری ایجاد نمی‌کند.

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

اپلیکیشن آنلاین [**مشاهده و ویرایش فراداده‌های PowerPoint**](https://products.aspose.app/slides/metadata) را امتحان کنید تا ببینید چگونه با استفاده از API Aspose.Slides با خواص سند کار می‌کنید:

[![مشاهده و ویرایش فراداده‌های PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **سوالات متداول**

**چگونه می‌توانم یک خاصیت توکار را از یک ارائه حذف کنم؟**

خواص توکار بخش جدایی‌ناپذیر ارائه هستند و نمی‌توانند به‌طور کامل حذف شوند. اما می‌توانید مقدار آن‌ها را تغییر دهید یا در صورت اجازهٔ خاصیت، به مقدار خالی تنظیم کنید.

**چه اتفاقی می‌افتد اگر یک خاصیت سفارشی را اضافه کنم که قبلاً وجود دارد؟**

اگر خاصیت سفارشی‌ای را اضافه کنید که از پیش موجود است، مقدار فعلی آن با مقدار جدید جایگزین می‌شود. نیازی به حذف یا بررسی قبلی خاصیت ندارید، زیرا Aspose.Slides به‌صورت خودکار مقدار خاصیت را به‌روز می‌کند.

**آیا می‌توانم خواص ارائه را بدون بارگذاری کامل ارائه دریافت کنم؟**

بله. می‌توانید از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) استفاده کنید و سپس با [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) متاداده‌های سند ذخیره‌شده را بدون ایجاد یک نمونهٔ [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) بخوانید. برای مثال کامل گزارش‌گیری و محدودیت‌های مخصوص فرمت، به مقالهٔ [Build a Lightweight Presentation Inventory](/slides/fa/python-java/examine-presentation/) مراجعه کنید.

**آیا می‌توانم خواص عمومی یک ارائه رمزگذاری‌شده را بدون رمز عبور باز کردن آن بخوانم؟**

بله. ارائه باید پس از فراخوانی [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) با `False` رمزگذاری شده باشد و سپس پس از فراخوانی [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) با `True` بارگذاری شود.

**آیا می‌توانم یک فایل PPTX رمزگذاری‌شده را در حالت فقط‑متاداده‑سند به‌روزرسانی کنم؟**

خیر. داده‌های عمومی و رمزگذاری‌شده باید سازگار باقی بمانند، بنابراین به‌روزرسانی یک فایل PPTX رمزگذاری‌شده نیازمند بارگذاری کامل ارائه با رمز عبور باز کردن صحیح است.