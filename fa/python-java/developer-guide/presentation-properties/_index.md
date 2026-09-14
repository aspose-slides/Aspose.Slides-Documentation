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
description: "مدیریت ویژگی‌های ارائه در Aspose.Slides برای Python via Java و بهینه‌سازی جستجو، برندینگ و جریان کار در فایل‌های PowerPoint و OpenDocument خود."
---
## **معرفی**

Aspose.Slides دو نوع ویژگی سند را پشتیبانی می‌کند: **Built-in** و **Custom**. هر دو نوع این ویژگی‌ها به راحتی می‌توانند با استفاده از API Aspose.Slides دسترسی و مدیریت شوند.

Aspose.Slides به شما امکان کار با ویژگی‌های سند ارائه را از طریق کلاس [DocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/) می‌دهد. یک نمونه از این کلاس توسط متد [Presentation.getDocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getDocumentProperties) برگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این ویژگی‌ها را خوانده، تغییر داده و مدیریت کنید.

{{% alert color="info" title="Note" %}}
لطفاً توجه داشته باشید که فیلدهای **Application** و **AppVersion** نمی‌توانند تغییر کنند. Aspose.Slides در هر ذخیره‌سازی آنها را بازنویسی می‌کند، بنابراین یک ارائه ذخیره‌شده همیشه «Aspose.Slides for Java» و نسخه کتابخانه‌ای که آن را تولید کرده است را گزارش می‌دهد. هر مقدار پاس داده‌شده به متد [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#setNameOfApplication) هنگام نوشتن ارائه نادیده گرفته می‌شود.
{{% /alert %}}

## **ویژگی‌های سند در PowerPoint**

Microsoft PowerPoint 2007 به شما اجازه می‌دهد ویژگی‌های سند فایل‌های ارائه را مدیریت کنید. روی آیکون Office کلیک کنید و **Prepare | Properties | Advanced Properties** را انتخاب کنید، همان‌طور که در زیر نشان داده شده است:

|**مورد منوی Advanced Properties را انتخاب کنید**|
| :- |
|![ویژگی‌های سند PowerPoint](https://i.imgur.com/ZrmuCD6.jpg)|

پس از انتخاب **Advanced Properties**، دیالوگی ظاهر می‌شود که می‌توانید ویژگی‌های سند فایل PowerPoint را در آن مدیریت کنید:

|**دیالوگ Properties**|
| :- |
|![ویژگی‌های سند PowerPoint](https://i.imgur.com/LibmdQd.jpg)|

دیالوگ **Properties** شامل تب‌هایی مانند **General**, **Summary**, **Statistics**, **Contents** و **Custom** است. این تب‌ها به شما امکان پیکربندی انواع مختلف اطلاعات درباره فایل‌های PowerPoint را می‌دهند. برای مدیریت ویژگی‌های سفارشی از تب **Custom** استفاده کنید.

## **کار با ویژگی‌های سند با استفاده از Aspose.Slides برای Python via Java**

همان‌طور که در بالا شرح داده شد، Aspose.Slides برای Python via Java هر دو ویژگی **Built-in** و **Custom** را پشتیبانی می‌کند. کلاس [DocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/) نمایانگر ویژگی‌های سند مرتبط با یک فایل ارائه است.

از متد [Presentation.getDocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getDocumentProperties) برای دسترسی به این ویژگی‌ها همان‌طور که در زیر توضیح داده شده استفاده کنید.

## **خواندن ویژگی‌های عمومی از یک ارائه رمزگذاری‌شده**

یک رمز عبور باز کردن معمولاً هم محتویات ارائه و هم ویژگی‌های سند را محافظت می‌کند. وقتی یک ارائه با پاس دادن `false` به متد [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) رمزگذاری می‌شود، ویژگی‌های سند آن عمومی می‌مانند. سپس برنامه می‌تواند با پاس کردن `true` به متد [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) متادیتای عمومی را بدون ارائه رمز عبور باز کردن بخواند.

گزینهٔ بارگذاری فقط ویژگی‌های سند، چیزی را که Aspose.Slides بارگذاری می‌کند کنترل می‌کند؛ چیزی را رمزگشایی نمی‌کند. اگر ویژگی‌ها در رمزگذاری گنجانده شده باشند، بارگذاری آنها بدون رمز عبور ناموفق خواهد بود. اگر ارائه رمزگذاری نشده باشد، این گزینه نادیده گرفته می‌شود و ارائه کامل بارگذاری می‌شود.

مثال زیر حالت بارگذاری را از طریق متد [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/fa/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) تأیید می‌کند و سپس ویژگی‌های Built-in را از طریق متد [Presentation.getDocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getDocumentProperties) می‌خواند:

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

در این حالت، محتویات اسلاید بارگذاری نمی‌شود. اسلایدها، مسترها، طرح‌ها، اشکال، رسانه‌ها و سایر اشیای ارائه در دسترس نیستند. برنامه‌ها باید همیشه قبل از انجام عملیاتی که نیاز به مدل شیء کامل ارائه دارد، از متد [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/fa/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) بررسی کنند.

{{% alert color="warning" title="Warning" %}}
متادیتای عمومی می‌تواند نام نویسندگان، عناوین، موضوعات، کلیدواژه‌ها، اطلاعات شرکت، نظرات و مقادیر سفارشی را فاش کند. ویژگی‌های حساسی را همراه با ارائه رمزگذاری کنید. تنها زمانی که سیستم‌های ایندکس‌گذاری، طبقه‌بندی، جستجو یا مدیریت سند نیاز خاصی به دسترسی بدون رمز عبور داشته باشند، آنها را عمومی نگه دارید.
{{% /alert %}}

## **به‌روزرسانی ویژگی‌های یک ارائه رمزگذاری‌شده**

برای فایل PPTX رمزگذاری‌شده، ارائه‌ای که در حالت فقط‑ویژگی‑سند بارگذاری می‌شود، برای خواندن متادیتای عمومی در نظر گرفته شده است. Aspose.Slides نمی‌تواند ویژگی‌های تغییر یافته را از آن شیء تنها‑متادیتا ذخیره کند، زیرا ویژگی‌های عمومی باید با داده‌های مربوطه در داخل ارائه رمزگذاری‌شده سازگار بمانند. بنابراین به‌روزرسانی آنها به رمز عبور باز کردن صحیح و بارگذاری کامل نیاز دارد.

مثال زیر ارائه را با استفاده از متد [LoadOptions.setPassword](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setPassword) باز می‌کند، ویژگی‌های Built-in عمومی را به‌روزرسانی می‌کند و نتیجه را ذخیره می‌نماید. سپس با متد [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#isEncrypted) اطمینان می‌شود که رمزگذاری حفظ شده و متادیتای عمومی را بدون رمز عبور باز می‌کند تا مقادیر جدید را تأیید کند:

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

اگر برنامه اجازهٔ رمزگشایی یا بارگذاری محتویات ارائه را نداشته باشد، باید ویژگی‌های عمومی یک فایل PPTX رمزگذاری‌شده را به‌عنوان فقط‑خواندنی در نظر بگیرد.

## **دسترسی به ویژگی‌های Built‑in**

ویژگی‌های Built‑in که توسط [DocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/) افشا می‌شوند شامل: **Creator** (نویسنده)، **Description**, **Created** (تاریخ ایجاد)، **Modified** (تاریخ تغییر)، **Printed** (تاریخ چاپ آخر)، **LastModifiedBy**, **Keywords**, **SharedDoc** (آیا بین تولیدکنندگان مختلف به‌اشتراک گذاشته شده است؟)، **PresentationFormat**, **Subject** و **Title** می‌باشند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, DocumentProperties

# نمونه‌سازی کلاس Presentation که نمایانگر ارائه است
presentation = Presentation("Presentation.pptx")
try:
    # ایجاد یک مرجع به شیء DocumentProperties مرتبط با Presentation
    properties = presentation.getDocumentProperties()

    # نمایش ویژگی‌های داخلی
    print("Category : ", properties.getCategory())
    print("Current Status : ", properties.getContentStatus())
    print("Creation Date : ", properties.getCreatedTime())
    print("Author : ", properties.getAuthor())
    print("Description : ", properties.getComments())
    print("KeyWords : ", properties.getKeywords())
    print("Last Modified By : ", properties.getLastSavedBy())
    print("Supervisor : ", properties.getManager())
    print("Modified Date : ", properties.getLastSavedTime())
    print("Presentation Format : ", properties.getPresentationFormat())
    print("Last Print Date : ", properties.getLastPrinted())
    print("Is Shared between producers : ", properties.getSharedDoc())
    print("Subject : ", properties.getSubject())
    print("Title : ", properties.getTitle())
finally:
    presentation.dispose()
```

## **تغییر ویژگی‌های Built‑in**

تغییر ویژگی‌های Built‑in به سادگی دسترسی به آنها است. از متد setter مربوطه برای اختصاص مقدار جدید استفاده کنید. مثال زیر ویژگی‌های سند Built‑in را با استفاده از Aspose.Slides برای Python via Java تغییر می‌دهد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # یک مرجع به شیء DocumentProperties مرتبط با Presentation ایجاد کنید
    properties = presentation.getDocumentProperties()

    # ویژگی‌های داخلی را تنظیم کنید
    properties.setAuthor("Aspose.Slides for Python via Java")
    properties.setTitle("Modifying Presentation Properties")
    properties.setSubject("Aspose Subject")
    properties.setComments("Aspose Description")
    properties.setManager("Aspose Manager")

    # ارائه خود را در یک فایل ذخیره کنید
    presentation.save("DocProps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

این مثال ویژگی‌های Built‑in ارائه را که می‌توانند به‌صورت زیر مشاهده شوند، تغییر می‌دهد:

|**ویژگی‌های سند Built‑in پس از تغییر**|
| :- |
|![ویژگی‌های سند PowerPoint](https://i.imgur.com/zz1N9de.jpg)|

## **افزودن ویژگی‌های سفارشی به سند**

Aspose.Slides برای Python via Java همچنین به توسعه‌دهندگان اجازه می‌دهد ویژگی‌های سفارشی به ارائه‌ها اضافه کنند. مثال زیر سه ویژگی سفارشی اضافه می‌کند، سپس نام ذخیره‌شده در شاخص 2 را جستجو کرده و آن ویژگی را حذف می‌کند، به‌طوری که ارائه ذخیره‌شده دو ویژگی باقی‌مانده را نگه می‌دارد. ویژگی‌های سفارشی به ترتیب حروف الفبا فهرست می‌شوند، نه به ترتیبی که اضافه شده‌اند.

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # دریافت ویژگی‌های سند
    properties = presentation.getDocumentProperties()

    # افزودن ویژگی‌های سفارشی
    properties.set_Item("New Custom", jpype.JInt(12))
    properties.set_Item("My Name", "Mudassir")
    properties.set_Item("Custom", jpype.JInt(124))

    # دریافت نام ویژگی در ایندکس مشخص
    property_name = properties.getCustomPropertyName(2)

    # حذف ویژگی انتخاب شده
    properties.removeCustomProperty(property_name)

    # ذخیره ارائه
    presentation.save("CustomDemo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|**ویژگی‌های سفارشی سند اضافه شده**|
| :- |
|![ویژگی‌های سند PowerPoint](https://i.imgur.com/HdKcxI9.png)|

## **دسترسی و تغییر ویژگی‌های سفارشی**

Aspose.Slides برای Python via Java همچنین به توسعه‌دهندگان اجازه می‌دهد مقادیر ویژگی‌های سفارشی را دسترسی و تغییر دهند. مثال زیر نحوه دسترسی و تغییر همه ویژگی‌های سفارشی در یک ارائه را نشان می‌دهد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # ایجاد یک مرجع به شیء DocumentProperties مرتبط با Presentation
    properties = presentation.getDocumentProperties()

    # دسترسی و تغییر ویژگی‌های سفارشی
    for i in range(properties.getCountOfCustomProperties()):
        property_name = properties.getCustomPropertyName(i)
        # نمایش نام‌ها و مقادیر ویژگی‌های سفارشی
        print("Custom Property Name : ", property_name)
        print("Custom Property Value : ", properties.get_Item(property_name))

        # تغییر مقادیر ویژگی‌های سفارشی
        properties.set_Item(property_name, f"New Value {i + 1}")

    # ذخیره ارائه شما در یک فایل
    presentation.save("CustomDemoModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

این مثال ویژگی‌های سفارشی یک ارائه [PPTX](https://docs.fileformat.com/presentation/pptx/) را تغییر می‌دهد. شکل‌های زیر ویژگی‌های سفارشی ارائه را قبل و بعد از تغییر نشان می‌دهند:

|**ویژگی‌های سفارشی قبل از تغییر**|
| :- |
|![ویژگی‌های سند PowerPoint](https://i.imgur.com/Ze7YHvi.jpg)|

|**ویژگی‌های سفارشی بعد از تغییر**|
| :- |
|![ویژگی‌های سند PowerPoint](https://i.imgur.com/Tofu0CL.jpg)|

## **ویژگی‌های پیشرفتهٔ سند**

{{% alert color="info" title="Note" %}}
روش‌های جدید [readDocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#readDocumentProperties)، [updateDocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) و [writeBindedPresentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) به کلاس [PresentationInfo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/) اضافه شده‌اند و رفتار متد [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/fa/python-java/aspose.slides/documentproperties/#setLastSavedTime) تغییر کرده است.
{{% /alert %}}

دو روش جدید [readDocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#readDocumentProperties) و [updateDocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) به کلاس [PresentationInfo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/) اضافه شده‌اند. این متدها دسترسی سریع به ویژگی‌های سند را فراهم کرده و امکان تغییر و به‌روزرسانی ویژگی‌ها را بدون بارگذاری کل ارائه می‌دهند.

جریان کاری معمول برای بارگذاری ویژگی‌ها، تغییر مقادیر آنها و به‌روزرسانی سند می‌تواند به‌صورت زیر پیاده‌سازی شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

# اطلاعات ارائه را بخوانید
presentation_info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx")

# دریافت ویژگی‌های فعلی
properties = presentation_info.readDocumentProperties()

# تنظیم مقادیر جدید فیلدهای Author و Title
properties.setAuthor("New Author")
properties.setTitle("New Title")

# به‌روزرسانی ارائه با مقادیر جدید
presentation_info.updateDocumentProperties(properties)
presentation_info.writeBindedPresentation("presentation.pptx")
```

روش دیگری برای استفاده از ویژگی‌های یک ارائه خاص به‌عنوان قالب برای به‌روزرسانی ویژگی‌ها در ارائه‌های دیگر وجود دارد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("template.pptx")
template = presentation_info.readDocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

def update_by_template(path, template):
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

یک قالب جدید می‌تواند از ابتدا ایجاد شده و سپس برای به‌روزرسانی چندین ارائه استفاده شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, DocumentProperties

template = DocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

## **تنظیم زبان تصحیح املایی**

Aspose.Slides متد [PortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portionformat/#setLanguageId) را فراهم می‌کند تا بتوانید زبان تصحیح املایی یک سند PowerPoint را تنظیم کنید. زبان تصحیح املایی زبانی است که املا و گرامر در ارائه برای آن بررسی می‌شود.

این کد Python نشان می‌دهد چگونه زبان تصحیح املایی یک PowerPoint تنظیم شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, FontData

pptx_file_name = "presentation.pptx"

presentation = Presentation(pptx_file_name)
try:
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    new_portion = Portion()

    font = FontData("SimSun")
    portion_format = new_portion.getPortionFormat()
    portion_format.setComplexScriptFont(font)
    portion_format.setEastAsianFont(font)
    portion_format.setLatinFont(font)

    portion_format.setLanguageId("zh-CN") # تنظیم شناسه زبان تصحیح املایی

    new_portion.setText("1。")
    paragraph.getPortions().add(new_portion)
finally:
    presentation.dispose()
```

## **تنظیم زبان پیش‌فرض**

این کد Python نشان می‌دهد چگونه زبان پیش‌فرض برای تمام ارائه PowerPoint تنظیم شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    # یک شکل مستطیل با متن اضافه می‌کند
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("New Text")

    # زبان اولین قسمت را بررسی می‌کند
    print(shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **مثال زنده**

سعی کنید برنامه آنلاین [**Aspose.Slides Metadata**](https://products.aspose.app/slides/fa/metadata) را آزمایش کنید تا ببینید چگونه می‌توانید با ویژگی‌های سند از طریق API Aspose.Slides کار کنید:

[![مشاهده و ویرایش متادیتای PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/fa/metadata)

## **سوالات متداول**

**چگونه می‌توان یک ویژگی Built‑in را از یک ارائه حذف کرد؟**

ویژگی‌های Built‑in بخشی جدایی‌ناپذیر از ارائه هستند و نمی‌توان آنها را کاملاً حذف کرد. با این حال، می‌توانید مقادیر آنها را تغییر دهید یا در صورت اجازهٔ ویژگی موردنظر، به مقدار خالی تنظیم کنید.

**اگر یک ویژگی سفارشی که از قبل وجود دارد را اضافه کنم چه می‌شود؟**

اگر یک ویژگی سفارشی که از پیش موجود است را اضافه کنید، مقدار موجود آن با مقدار جدید بازنویسی می‌شود. نیازی به حذف یا بررسی پیشین ویژگی ندارید، زیرا Aspose.Slides به‌صورت خودکار مقدار ویژگی را به‌روز می‌کند.

**آیا می‌توان به ویژگی‌های ارائه بدون بارگذاری کامل آن دسترسی پیدا کرد؟**

بله. می‌توان از متد [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationfactory/#getPresentationInfo) سپس متد [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#readDocumentProperties) برای خواندن متادیتای ذخیره‌شده سند بدون ایجاد نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) استفاده کرد. برای مثال کامل گزارش‌دهی و محدودیت‌های خاص فرمت، به مقالهٔ [Build a Lightweight Presentation Inventory](/slides/fa/python-java/examine-presentation/) مراجعه کنید.

**آیا می‌توان ویژگی‌های عمومی یک ارائه رمزگذاری‌شده را بدون رمز عبور باز کردن آن خواند؟**

بله. رمزگذاری ویژگی‌های سند باید پیش از رمزگذاری ارائه غیرفعال شده باشد و ارائه باید در حالت فقط‑ویژگی‑سند بارگذاری شده باشد.

**آیا می‌توان یک فایل PPTX رمزگذاری‌شده را در حالت فقط‑ویژگی‑سند به‌روزرسانی کرد؟**

خیر. داده‌های عمومی و رمزگذاری‌شده باید سازگار باقی بمانند، بنابراین به‌روزرسانی یک فایل PPTX رمزگذاری‌شده مستلزم بارگذاری کامل ارائه با رمز عبور صحیح باز کردن است.