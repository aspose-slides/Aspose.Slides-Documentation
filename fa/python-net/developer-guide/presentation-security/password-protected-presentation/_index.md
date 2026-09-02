---
title: حفاظت با رمز عبور ارائه‌ها در پایتون
linktitle: حفاظت رمز عبور
type: docs
weight: 20
url: /fa/python-net/password-protected-presentation/
keywords:
- ارائه محافظت‌شده با رمز عبور
- رمز عبور باز کردن
- رمزنگاری PowerPoint
- رمزگشایی PowerPoint
- اعتبارسنجی رمز عبور ارائه
- بررسی رمز عبور ارائه
- باز کردن ارائه رمزگذاری‌شده
- حذف رمزگذاری
- PowerPoint
- PPT
- PPTX
- ارائه
- پایتون
- Aspose.Slides
description: "رمزنگاری، شناسایی، اعتبارسنجی، باز کردن و رمزگشایی ارائه‌های PowerPoint PPT و PPTX محافظت‌شده با رمز عبور در پایتون با Aspose.Slides."
---
## **مروری کلی**

یک رمز عبور برای باز کردن یک ارائه را رمزگذاری می‌کند. برای بارگذاری و مشاهده محتوای ارائه، رمز عبور صحیح لازم است، بنابراین این حفاظت محرمانگی را فراهم می‌کند.

رمز عبور باز کردن با رمز عبور محافظت نوشتن متفاوت است. محافظت نوشتن محدودیت در اصلاح ایجاد می‌کند اما محتوا را رمزگذاری نمی‌کند و مانع بارگذاری ارائه نمی‌شود. برای مدیریت رمزهای عبور برای اصلاح ارائه‌ها، به [Write-Protect Presentations](/slides/fa/python-net/write-protected-presentation/) مراجعه کنید.

گردش کارهای زیر برای ارائه‌های PPT و PPTX هر دو اعمال می‌شود. مثال‌ها هر دو فرمت را به کار می‌برند جایی که رفتار مبتنی بر فایل و مبتنی بر جریان اهمیت دارد.

## **رمزگذاری یک ارائه با رمز عبور باز کردن**

از [ProtectionManager.encrypt](https://reference.aspose.com/slides/fa/python-net/aspose.slides/protectionmanager/encrypt/) برای اختصاص یک رمز عبور باز کردن استفاده کنید. سپس از [Presentation.save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/save/) برای ذخیره ارائه رمزگذاری‌شده استفاده کنید.

مثال زیر یک ارائه PPTX را رمزگذاری می‌کند:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **بارگذاری یک ارائه رمزگذاری‌شده**

با تنظیم [LoadOptions.password](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/password/) به رمز عبور باز کردن و ارسال این گزینه‌ها به [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) هنگام بارگذاری فایل، عمل بارگذاری انجام می‌شود. اگر رمز عبور باز کردن لازم باشد ولی رمز ارائه‌شده گمشده یا نادرست باشد، بارگذاری با خطا مواجه می‌شود.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # با ارائه رمزگشایی‌شده کار کنید.
    pass
```

## **حذف رمزگذاری از یک ارائه**

ارائه را با رمز عبور باز کردن آن بارگذاری کنید، [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/fa/python-net/aspose.slides/protectionmanager/remove_encryption/) را فراخوانی کنید و نتیجه را ذخیره نمایید. پس از ذخیره، می‌توان ارائه را بدون نیاز به رمز عبور بارگذاری کرد.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **اعتبارسنجی رمز عبور باز کردن قبل از بارگذاری**

از [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationfactory/get_presentation_info/) برای دریافت [PresentationInfo](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/) بدون ایجاد یک نمونه کامل از ارائه استفاده کنید. پیش از درخواست یا اعتبارسنجی رمز عبور، [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/is_password_protected/) را بررسی کنید. زمانی که حفاظت وجود دارد، مقدار ارائه‌شده را با [PresentationInfo.check_password](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/check_password/) اعتبارسنجی کنید.

### **گردش کار مسیر پرونده**

مثال زیر رمز عبور باز کردن را برای یک فایل PPTX اعتبارسنجی می‌کند، مقدار اعتبارسنجی‌شده را به [LoadOptions.password](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/password/) می‌گذارد و سپس ارائه کامل را بارگذاری می‌نماید:

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

بارگذاری جریان‌ای از [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationfactory/get_presentation_info/) همان گردش کار را فراهم می‌کند. قبل از بارگذاری ارائه کامل از آن جریان، موقعیت یک جریان قابل جستجو را بازنشانی کنید.

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

### **مقادیر بازگشت CheckPassword**

[PresentationInfo.check_password](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/check_password/) فقط زمانی که ارائه دارای رمز عبور باز کردن باشد و رمز ارائه‌شده صحیح باشد، `True` باز می‌گرداند. در هر یک از موارد زیر `False` باز می‌گردد:

- رمز عبور نادرست است.
- ارائه رمز عبور باز کردن ندارد.
- رمز عبور ارائه‌شده `None` یا خالی است.

این رفتار برای ارائه‌های PPT و PPTX یکسان است.

## **بررسی اینکه آیا یک ارائه بارگذاری‌شده رمزگذاری‌شده است**

پس از بارگذاری یک ارائه با رمز عبور صحیح، [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/fa/python-net/aspose.slides/protectionmanager/is_encrypted/) را بررسی کنید تا تأیید کنید که ارائه منبع رمزگذاری شده است. برای شناسایی حفاظت با رمز عبور باز کردن قبل از بارگذاری، از `PresentationInfo.is_password_protected` همان‌طور که در بالا نشان داده شد، استفاده کنید.

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
رمزهای عبور باز کردن را در لاگ‌ها ثبت نکنید و در پیام‌های تشخیصی گنجانده نشود. از تلاش‌های تکراری و غیرضروری برای اعتبارسنجی جلوگیری کنید، رمزها را در حافظه تنها به مدت لازم نگه دارید و نتایج اعتبارسنجی موفق را هنگام بارگذاری فوری ارائه مجددا استفاده کنید.
{{% /alert %}}

## **حفاظت با رمز عبور از یک ارائه به‌صورت آنلاین**

1. برنامه [Aspose.Slides Lock](https://products.aspose.app/slides/fa/lock) را باز کنید.
1. ارائه را انتخاب یا بارگذاری کنید.
1. رمز عبوری برای حفاظت نمایش وارد کنید.
1. در صورت نیاز رمز عبور جداگانه‌ای برای حفاظت ویرایش وارد کنید.
1. محافظت را اعمال کرده و فایل حاصل را دانلود کنید.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/fa/python-net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/fa/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **سوالات متداول**

**تفاوت رمز عبور باز کردن و رمز عبور محافظت نوشتن چیست؟**

یک رمز عبور باز کردن ارائه را رمزگذاری می‌کند و برای بارگذاری محتوای آن لازم است. یک رمز عبور محافظت نوشتن محدودیت در اصلاح ایجاد می‌کند بدون اینکه محتوا را رمزگذاری کند.

**آیا می‌توانم یک رمز عبور باز کردن را بدون بارگذاری تمام اسلایدها اعتبارسنجی کنم؟**

بله. اطلاعات ارائه را به‌دست آورید، بررسی کنید آیا حفاظت با رمز عبور باز کردن وجود دارد یا خیر، و قبل از ایجاد یک نمونه کامل از ارائه، رمز عبور را اعتبارسنجی کنید.

**آیا گردش کارهای بررسی رمز عبور هر دو PPT و PPTX را پشتیبانی می‌کنند؟**

بله. شناسایی و اعتبارسنجی رمز عبور بر پایه مسیر فایل و جریان برای ارائه‌های PPT و PPTX به‌صورت یکسان عمل می‌کند.