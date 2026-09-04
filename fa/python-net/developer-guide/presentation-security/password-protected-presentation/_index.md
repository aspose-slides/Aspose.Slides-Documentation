---
title: محافظت از ارائه‌ها با رمز عبور در پایتون
linktitle: حفاظت از رمز عبور
type: docs
weight: 20
url: /fa/python-net/password-protected-presentation/
keywords:
- ارائه حفاظت‌شده با رمز عبور
- رمز عبور باز کردن
- رمزگذاری پاورپوینت
- رمزگشایی پاورپوینت
- اعتبارسنجی رمز عبور ارائه
- بررسی رمز عبور ارائه
- باز کردن ارائه رمزگذاری‌شده
- حذف رمزنگاری
- پاورپوینت
- PPT
- PPTX
- ارائه
- پایتون
- Aspose.Slides
description: "رمزگذاری، شناسایی، اعتبارسنجی، باز کردن و رمزگشایی ارائه‌های پاورپوینت PPT و PPTX محافظت‌شده با رمز عبور در پایتون با Aspose.Slides."
---
## **بررسی کلی**

یک رمز عبور باز کردن یک ارائه را رمزگذاری می‌کند. برای بارگذاری و مشاهدهٔ محتوای ارائه، رمز عبور صحیح ضروری است، بنابراین این حفاظت محرمانگی را فراهم می‌کند.

رمز عبور باز کردن با رمز عبور حفاظت نوشتاری متفاوت است. حفاظت نوشتاری تغییرات را محدود می‌کند اما محتوای ارائه را رمزگذاری نمی‌کند و مانع از بارگذاری ارائه نمی‌شود. برای مدیریت رمزها برای اصلاح ارائه‌ها، به [Write-Protect Presentations](/slides/fa/python-net/write-protected-presentation/) مراجعه کنید.

گردش‌های کاری زیر برای هر دو نوع ارائهٔ PPT و PPTX اعمال می‌شود. مثال‌ها از هر دو قالب استفاده می‌کنند که رفتار مبتنی بر فایل و مبتنی بر جریان آن‌ها مهم است.

## **رمزگذاری یک ارائه با رمز عبور باز کردن**

از [ProtectionManager.encrypt](https://reference.aspose.com/slides/fa/python-net/aspose.slides/protectionmanager/encrypt/) برای اختصاص یک رمز عبور باز کردن استفاده کنید. سپس از [Presentation.save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/save/) برای ذخیرهٔ ارائهٔ رمزگذاری‌شده استفاده کنید.

مثال زیر یک ارائهٔ PPTX را رمزگذاری می‌کند:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **حفظ عمومی ویژگی‌های سند**

به‌طور پیش‌فرض، Aspose.Slides ویژگی‌های سند را در رمزگذاری ارائه شامل می‌شود. ویژگی [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/fa/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) این رفتار را به‌صورت مستقل از رمزگذاری محتوای اسلاید کنترل می‌کند. قبل از فراخوانی [ProtectionManager.encrypt](https://reference.aspose.com/slides/fa/python-net/aspose.slides/protectionmanager/encrypt/) آن را روی `False` تنظیم کنید زمانی که یک سیستم فهرست‌سازی، طبقه‌بندی، جستجو یا مدیریت سند باید فراداده‌ها را بدون رمز عبور باز کردن بخواند.

مثال زیر یک ارائهٔ PPTX رمزگذاری‌شده ایجاد می‌کند در حالی که ویژگی‌های سند داخلی آن عمومی می‌مانند:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    properties = presentation.document_properties
    properties.author = "Contoso Knowledge Management"
    properties.title = "Quarterly Product Roadmap"
    properties.keywords = "roadmap, planning, internal"

    presentation.slides[0].name = "Encrypted presentation content"
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", slides.export.SaveFormat.PPTX)
```

تنظیم `encrypt_document_properties` روی `False` اسلایدها، مسترها، طرح‌بندی‌ها، اشکال، رسانه‌ها یا سایر محتوای ارائه را عمومی نمی‌کند. این تنظیم فقط بر ویژگی‌های سند تأثیر دارد. برای خواندن آن ویژگی‌ها بدون بارگذاری محتوای رمزگذاری‌شده، به [Manage Presentation Properties](/slides/fa/python-net/presentation-properties/) مراجعه کنید.

## **بارگذاری یک ارائهٔ رمزگذاری‌شده**

مقدار [LoadOptions.password](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/password/) را به رمز عبور باز کردن تنظیم کنید و هنگام بارگذاری فایل این گزینه‌ها را به [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) پاس دهید. بارگذاری در صورتی که رمز عبور باز کردن لازم باشد اما رمز ارائه‌شده یافت نشود یا نادرست باشد، با شکست مواجه می‌شود.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # کار با ارائه رمزگشایی‌شده.
    pass
```

## **حذف رمزنگاری از یک ارائه**

ارائه را با رمز عبور باز کردن آن بارگذاری کنید، [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/fa/python-net/aspose.slides/protectionmanager/remove_encryption/) را فراخوانی کنید و نتیجه را ذخیره کنید. سپس می‌توان ارائهٔ ذخیره‌شده را بدون نیاز به رمز عبور بارگذاری کرد.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **اعتبارسنجی رمز عبور باز کردن قبل از بارگذاری**

از [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationfactory/get_presentation_info/) برای به‌دست‌آوردن [PresentationInfo](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/) بدون ایجاد یک نمونهٔ کامل از ارائه استفاده کنید. قبل از درخواست یا اعتبارسنجی رمز عبور، [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/is_password_protected/) را بررسی کنید. زمانی که حفاظت وجود دارد، مقدار ارائه‌شده را با [PresentationInfo.check_password](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/check_password/) اعتبارسنجی کنید.

### **گردش کار مسیر فایل**

مثال زیر یک رمز عبور باز کردن برای یک فایل PPTX را اعتبارسنجی می‌کند، مقدار اعتبارسنجی‌شده را به [LoadOptions.password](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/password/) می‌گذارد و سپس ارائهٔ کامل را بارگذاری می‌کند:

```python
import aspose.slides as slides

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)

if not presentation_info.is_password_protected:
    print("The presentation does not have an opening password.")
elif not presentation_info.check_password(password):
    print("The opening password is incorrect.")
else:
    load_options = slides.LoadOptions()
    load_options.password = password

    with slides.Presentation(file_path, load_options) as presentation:
        print("The presentation was validated and loaded successfully.")
```

### **گردش کار جریان**

نسخهٔ جریان‌دار [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationfactory/get_presentation_info/) همان گردش کار را فراهم می‌کند. قبل از بارگذاری ارائهٔ کامل از آن جریان، موقعیت یک جریان قابل جستجو را بازنشانی کنید.

مثال زیر از یک فایل PPT استفاده می‌کند:

```python
import aspose.slides as slides

password = "open_password"

with open("protected-presentation.ppt", "rb") as presentation_stream:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(presentation_stream)

    if not presentation_info.is_password_protected:
        print("The presentation does not have an opening password.")
    elif not presentation_info.check_password(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.seek(0)
        load_options = slides.LoadOptions()
        load_options.password = password

        with slides.Presentation(presentation_stream, load_options) as presentation:
            print("The presentation was validated and loaded successfully.")
```

### **مقادیر برگشتی CheckPassword**

[PresentationInfo.check_password](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/check_password/) فقط زمانی که ارائه دارای رمز عبور باز کردن باشد و رمز ارائه‌شده صحیح باشد، `True` برمی‌گرداند. در هر یک از موارد زیر `False` برمی‌گرداند:

- رمز عبور نادرست است.
- ارائه رمز عبور باز کردن ندارد.
- رمز عبور ارائه‌شده `None` یا خالی است.

رفتار برای ارائه‌های PPT و PPTX یکسان است.

## **بررسی اینکه آیا یک ارائهٔ بارگذاری‌شده رمزگذاری شده است یا خیر**

پس از بارگذاری یک ارائه با رمز عبور صحیح، [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/fa/python-net/aspose.slides/protectionmanager/is_encrypted/) را بررسی کنید تا تأیید کنید که ارائهٔ منبع رمزگذاری شده است. برای شناسایی حفاظت رمز عبور باز کردن قبل از بارگذاری، همان‌طور که در بالا نشان داده شد، از `PresentationInfo.is_password_protected` استفاده کنید.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **توصیه‌های امنیتی**

{{% alert color="warning" title="Security" %}}
رمزهای عبور باز کردن را لاگ نکنید و در پیام‌های تشخیصی گنجانده نشوند. از تلاش‌های تکراری و غیرضروری برای اعتبارسنجی خودداری کنید، رمزها را در حافظه فقط به‌مدت زمان مورد نیاز نگه دارید و در صورت بارگذاری فوری ارائه، نتیجهٔ اعتبارسنجی موفق را مجدداً استفاده کنید.

ویژگی‌های عمومی سند ممکن است نام‌های نویسنده، عناوین، موضوعات، کلیدواژه‌ها، اطلاعات شرکت، نظرات و مقادیر سفارشی را حتی زمانی که محتوای ارائه رمزگذاری شده است، فاش کنند. متادیتای حساس را همراه با ارائه رمزگذاری کنید. نگه داشتن ویژگی‌ها به‌صورت عمومی باید تصمیمی صریح باشد که تنها زمانی اتخاذ شود که سیستم‌ها مجبور باشند بدون رمز عبور باز کردن، فایل را فهرست‌بندی، طبقه‌بندی، جستجو یا مدیریت کنند.
{{% /alert %}}

## **رمزگذاری یک ارائه به‌صورت آنلاین**

1. برنامهٔ [Aspose.Slides Lock](https://products.aspose.app/slides/fa/lock) را باز کنید.
1. ارائه را انتخاب یا بارگذاری کنید.
1. رمز عبوری برای حفاظت از مشاهده وارد کنید.
1. در صورت تمایل رمز عبور جداگانه‌ای برای حفاظت از ویرایش وارد کنید.
1. حفاظت را اعمال کرده و فایل حاصل را دانلود کنید.

{{% alert color="info" title="See also" %}}
- [محافظت نوشتاری ارائه‌ها](/slides/fa/python-net/write-protected-presentation/)
- [امضای دیجیتال در پاورپوینت](/slides/fa/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **سوالات متداول**

**تفاوت رمز عبور باز کردن و رمز عبور حفاظت نوشتاری چیست؟**

یک رمز عبور باز کردن ارائه را رمزگذاری می‌کند و برای بارگذاری محتوای آن ضروری است. یک رمز عبور حفاظت نوشتاری تغییرات را محدود می‌کند بدون اینکه محتوا را رمزگذاری کند.

**آیا می‌توانم رمز عبور باز کردن را بدون بارگذاری تمام اسلایدها اعتبارسنجی کنم؟**

بله. اطلاعات ارائه را به‌دست آورید، بررسی کنید که آیا حفاظت رمز عبور باز کردن موجود است یا خیر، و قبل از ایجاد یک نمونهٔ کامل از ارائه، رمز عبور را اعتبارسنجی کنید.

**آیا یک برنامه می‌تواند متادیتا را بدون رمز عبور باز کردن بخواند؟**

بله، اما فقط وقتی که ارائه با تنظیم `encrypt_document_properties` روی `False` رمزگذاری شده باشد. برنامه سپس باید از حالت بارگذاری فقط‑ویژگی‑های‑سند توصیف‌شده در [Manage Presentation Properties](/slides/fa/python-net/presentation-properties/) استفاده کند.

**آیا گردش‌های کاری بررسی رمز عبور برای هر دو PPT و PPTX پشتیبانی می‌شوند؟**

بله. شناسایی و اعتبارسنجی رمز عبور بر پایه مسیر فایل و جریان برای ارائه‌های PPT و PPTX به‌یک‌دست رفتار می‌کنند.