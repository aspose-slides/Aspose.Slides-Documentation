---
title: محافظت با رمز عبور ارائه‌ها در پایتون
linktitle: حفاظت رمز عبور
type: docs
weight: 20
url: /fa/python-java/password-protected-presentation/
keywords:
- ارائه با رمز عبور
- رمز عبور بازشو
- رمزنگاری پاورپوینت
- رمزگشایی پاورپوینت
- اعتبارسنجی رمز عبور ارائه
- بررسی رمز عبور ارائه
- بازکردن ارائه رمزنگاری‌شده
- حذف رمزنگاری
- پاورپوینت
- PPT
- PPTX
- ارائه
- پایتون
- Aspose.Slides
description: "رمزنگاری، تشخیص، اعتبارسنجی، باز کردن و رمزگشایی ارائه‌های پاورپوینت PPT و PPTX با رمز عبور با استفاده از Aspose.Slides برای پایتون از طریق جاوا."
---
## **نمای کلی**

یک رمز عبور بازشو یک ارائه را رمزنگاری می‌کند. برای بارگذاری و مشاهده محتوای ارائه، رمز صحیح لازم است، بنابراین این حفاظت محرمانگی را فراهم می‌آورد.

یک رمز عبور بازشو با رمز عبور محافظت نوشتن متفاوت است. محافظت نوشتن فقط اصلاح را محدود می‌کند اما محتوا را رمزنگاری نمی‌کند و مانع بارگذاری ارائه نمی‌شود. برای مدیریت رمزهای عبور جهت اصلاح ارائه‌ها، به [Write-Protect Presentations](/slides/fa/python-java/write-protected-presentation/) مراجعه کنید.

روال‌های زیر برای هر دو نوع ارائه PPT و PPTX اعمال می‌شوند. مثال‌ها هر دو فرمت را استفاده می‌کنند، جایی که رفتار مبتنی بر فایل یا جریان مهم است.

## **رمزنگاری یک ارائه با رمز عبور بازشو**

از [ProtectionManager.encrypt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/protectionmanager/#encrypt) برای اختصاص یک رمز عبور بازشو استفاده کنید. سپس از [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) برای ذخیرهٔ ارائه رمزنگاری‌شده استفاده کنید.

مثال زیر یک ارائه PPTX را رمزنگاری می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **حفظ عمومی ویژگی‌های سند**

به طور پیش‌فرض، Aspose.Slides ویژگی‌های سند را در رمزنگاری ارائه درج می‌کند. متد [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) این رفتار را به‌صورت مستقل از رمزنگاری محتوای اسلایدها کنترل می‌کند. هنگامیکه یک سیستم فهرست‌بندی، طبقه‌بندی، جستجو یا مدیریت سند باید فراداده‌ها را بدون رمز عبور بازشو بخواند، پیش از فراخوانی [ProtectionManager.encrypt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/protectionmanager/#encrypt) مقدار `False` را پاس کنید.

مثال زیر یک ارائه PPTX رمزنگاری‌شده ایجاد می‌کند در حالی که ویژگی‌های داخلی سند آن عمومی باقی می‌مانند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    properties = presentation.getDocumentProperties()
    properties.setAuthor("Contoso Knowledge Management")
    properties.setTitle("Quarterly Product Roadmap")
    properties.setKeywords("roadmap, planning, internal")

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content")
    presentation.getProtectionManager().setEncryptDocumentProperties(False)
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ارسال `False` به [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/fa/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) اسلایدها، مسترها، چیدمان‌ها، اشکال، رسانه‌ها یا سایر محتوای ارائه را عمومی نمی‌کند. این تنظیم فقط بر ویژگی‌های سند تأثیر می‌گذارد. برای خواندن این ویژگی‌ها بدون بارگذاری محتوای رمزنگاری‌شده، به [Manage Presentation Properties](/slides/fa/python-java/presentation-properties/) مراجعه کنید.

## **بارگذاری یک ارائه رمزنگاری‌شده**

مقدار [LoadOptions.setPassword](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setPassword) را به رمز عبور بازشو تنظیم کنید و گزینه‌ها را هنگام بارگذاری فایل به [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) پاس دهید. اگر رمز عبور بازشو لازم باشد اما رمز ارائه‌شده موجود نباشد یا نادرست باشد، بارگذاری با شکست مواجه می‌شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    # با ارائه رمزگشایی‌شده کار کنید.
    pass
finally:
    presentation.dispose()
```

## **حذف رمزنگاری از یک ارائه**

ارائه را با رمز عبور بازشو آن بارگذاری کنید، متد [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/fa/python-java/aspose.slides/protectionmanager/#removeEncryption) را فراخوانی کنید و نتیجه را ذخیره کنید. پس از آن می‌توان ارائهٔ ذخیره‌شده را بدون رمز عبور بارگذاری کرد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    presentation.getProtectionManager().removeEncryption()
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **اعتبارسنجی یک رمز عبور بازشو پیش از بارگذاری**

از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationfactory/#getPresentationInfo) برای به‌دست آوردن [PresentationInfo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/) بدون ایجاد یک نمونهٔ کامل از ارائه استفاده کنید. قبل از درخواست یا اعتبارسنجی رمز عبور، [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#isPasswordProtected) را بررسی کنید. وقتی حفاظت موجود باشد، مقدار ارائه‌شده را با [PresentationInfo.checkPassword](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#checkPassword) اعتبارسنجی کنید.

### **روال مسیر فایل**

مثال زیر یک رمز عبور بازشو برای فایل PPTX اعتبارسنجی می‌کند، مقدار اعتبارسنجی‌شده را به [LoadOptions.setPassword](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setPassword) پاس می‌دهد و سپس ارائهٔ کامل را بارگذاری می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)

if not presentation_info.isPasswordProtected():
    print("The presentation does not have an opening password.")
elif not presentation_info.checkPassword(password):
    print("The opening password is incorrect.")
else:
    load_options = LoadOptions()
    load_options.setPassword(password)

    presentation = Presentation(file_path, load_options)
    try:
        print("The presentation was validated and loaded successfully.")
    finally:
        presentation.dispose()
```

### **روال جریان**

بارگذاری جریان‌افزودهٔ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationfactory/#getPresentationInfo) همان روال را ارائه می‌دهد. قبل از بارگذاری ارائهٔ کامل از آن جریان، موقعیت یک جریان قابل جستجو را بازنشانی کنید.

مثال زیر از یک فایل PPT استفاده می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

FileInputStream = jpype.JClass("java.io.FileInputStream")

password = "open_password"

presentation_stream = FileInputStream("protected-presentation.ppt")
try:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(presentation_stream)

    if not presentation_info.isPasswordProtected():
        print("The presentation does not have an opening password.")
    elif not presentation_info.checkPassword(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.getChannel().position(0)

        load_options = LoadOptions()
        load_options.setPassword(password)

        presentation = Presentation(presentation_stream, load_options)
        try:
            print("The presentation was validated and loaded successfully.")
        finally:
            presentation.dispose()
finally:
    presentation_stream.close()
```

### **مقادیر بازگشتی checkPassword**

متد [PresentationInfo.checkPassword](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#checkPassword) تنها زمانی `True` برمی‌گرداند که ارائه دارای رمز عبور بازشو باشد و رمز ارائه‌شده صحیح باشد. در هر یک از موارد زیر `False` برمی‌گرداند:

- رمز عبور نادرست است.
- ارائه رمز عبور بازشو ندارد.
- رمز عبور ارائه‌شده `None` یا خالی است.

این رفتار برای ارائه‌های PPT و PPTX یکسان است.

## **بررسی اینکه آیا یک ارائه بارگذاری‌شده رمزنگاری شده است**

پس از بارگذاری یک ارائه با رمز عبور صحیح، [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/fa/python-java/aspose.slides/protectionmanager/#isEncrypted) را بررسی کنید تا تأیید کنید که ارائهٔ منبع رمزنگاری شده است. برای تشخیص وجود حفاظت رمز عبور بازشو پیش از بارگذاری، همان‌طور که در بالا نشان داده شد، از [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#isPasswordProtected) استفاده کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    is_encrypted = presentation.getProtectionManager().isEncrypted()
    print(f"The presentation is encrypted: {is_encrypted}")
finally:
    presentation.dispose()
```

## **توصیه‌های امنیتی**

{{% alert color="warning" title="Security" %}}
رمزهای عبور بازشو را در لاگ‌ها ثبت نکنید و در پیام‌های تشخیصی قرار ندهید. از تلاش‌های تکراری و بی‌مورد برای اعتبارسنجی جلوگیری کنید، رمزها را در حافظه تنها به مدت مورد نیاز نگه دارید و در صورت بارگذاری فوری ارائه، نتیجهٔ اعتبارسنجی موفق را دوباره استفاده کنید.

ویژگی‌های عمومی سند ممکن است نام‌های نویسنده، عناوین، موضوعات، کلمات کلیدی، اطلاعات شرکت، نظرات و مقادیر سفارشی را حتی در حالی که محتوای ارائه رمزنگاری شده است، فاش کنند. متادیتای حساس را همراه با ارائه رمزنگاری کنید. عمومی نگه داشتن ویژگی‌ها باید تصمیم صریحی باشد که فقط زمانی اتخاذ می‌شود که سیستم‌ها مجبور به فهرست‌بندی، طبقه‌بندی، جستجو یا مدیریت فایل بدون رمز عبور بازشو باشند.
{{% /alert %}}

## **حفاظت با رمز عبور یک ارائه به‌صورت آنلاین**

1. برنامه [Aspose.Slides Lock](https://products.aspose.app/slides/fa/lock) را باز کنید.
1. ارائه را انتخاب یا بارگذاری کنید.
1. یک رمز عبور برای حفاظت از نمایش وارد کنید.
1. در صورت نیاز، رمز عبور جداگانه‌ای برای حفاظت از ویرایش وارد کنید.
1. محافظت را اعمال کنید و فایل حاصل را دانلود کنید.

{{% alert color="info" title="See also" %}}
- [محافظت نوشتن از ارائه‌ها](/slides/fa/python-java/write-protected-presentation/)
- [امضای دیجیتال در پاورپوینت](/slides/fa/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**تفاوت رمز عبور بازشو و رمز عبور محافظت نوشتن چیست؟**

رمز عبور بازشو ارائه را رمزنگاری می‌کند و برای بارگذاری محتوا لازم است. رمز عبور محافظت نوشتن فقط اصلاح را محدود می‌کند بدون اینکه محتوا را رمزنگاری کند.

**آیا می‌توانم رمز عبور بازشو را بدون بارگذاری تمام اسلایدها اعتبارسنجی کنم؟**

بله. اطلاعات ارائه را به‌دست آورید، بررسی کنید که آیا حفاظت با رمز عبور بازشو وجود دارد یا نه، و قبل از ایجاد یک نمونهٔ کامل از ارائه، رمز عبور را اعتبارسنجی کنید.

**آیا یک برنامه می‌تواند متادیتا را بدون رمز عبور بازشو بخواند؟**

بله، اما تنها زمانی که ارائه با غیرفعال‌سازی رمزنگاری ویژگی‌های سند رمزنگاری شده باشد. در این حالت برنامه باید از حالت بارگذاری فقط‑ویژگی‑های‑سند که در [Manage Presentation Properties](/slides/fa/python-java/presentation-properties/) شرح داده شده، استفاده کند.

**آیا روال‌های بررسی رمز عبور هم برای PPT و هم برای PPTX پشتیبانی می‌شوند؟**

بله. تشخیص و اعتبارسنجی رمز عبور بر مبنای مسیر فایل و بر مبنای جریان برای ارائه‌های PPT و PPTX به‌یک شکل عمل می‌کند.