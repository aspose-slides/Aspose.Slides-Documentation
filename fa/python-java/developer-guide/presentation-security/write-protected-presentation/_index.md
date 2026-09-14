---
title: محافظت نوشتاری ارائه‌ها در پایتون
linktitle: محافظت نوشتاری
type: docs
weight: 25
url: /fa/python-java/write-protected-presentation/
keywords:
- محافظت نوشتاری
- محافظت نوشتاری پاورپوینت
- رمز عبور برای ویرایش
- محدود کردن ویرایش ارائه
- حذف محافظت نوشتاری
- اعتبارسنجی رمز عبور اصلاح
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "رمزهای عبور محافظت نوشتاری را در ارائه‌های PowerPoint با فرمت PPT و PPTX تنظیم، شناسایی، اعتبارسنجی و حذف کنید با استفاده از Aspose.Slides برای پایتون از طریق جاوا."
---
## **مقدمه**

یک رمز عبور محافظت نوشتاری، تغییر یک ارائه را محدود می‌کند اما محتوا را رمزنگاری نمی‌کند. کاربران می‌توانند یک ارائه محافظت‌شده نوشتاری را بدون رمز عبور بارگذاری و مشاهده کنند. بسته به برنامه، ممکن است بتوانند محتوا را ویرایش کرده و تحت نام دیگری ذخیره کنند، بنابراین محافظت نوشتاری نباید به عنوان مکانیزم محرمانگی در نظر گرفته شود.

یک رمز عبور باز کردن هدف متفاوتی دارد: ارائه را رمزنگاری می‌کند و برای بارگذاری محتوا ضروری است. برای رمزنگاری یک ارائه یا اعتبارسنجی رمز عبور باز کردن، به [Password-Protect Presentations](/slides/fa/python-java/password-protected-presentation/) مراجعه کنید.

روال‌های آورده شده در این مقاله برای ارائه‌های PPT و PPTX هر دو اعمال می‌شود. مثال‌ها از فایل‌های PPTX استفاده می‌کنند؛ هنگام ذخیره به قالب PPT، پسوند `.ppt` و قالب ذخیره‌سازی PPT مرتبط را به کار بگیرید.

## **تنظیم محافظت نوشتاری روی یک ارائه**

از [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/protectionmanager/#setWriteProtection) برای اختصاص رمز عبور به منظور اصلاح یک ارائه استفاده کنید. ذخیرهٔ ارائه تنظیمات محافظت را حفظ می‌کند.

مثال زیر محافظت نوشتاری را بر روی یک ارائه PPTX تنظیم می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().setWriteProtection("modify_password")
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **بارگذاری یک ارائه محافظت‌شده نوشتاری**

از آنجا که محافظت نوشتاری محتوا را رمزنگاری نمی‌کند، برای بارگذاری ارائه نیازی به رمز عبور نیست. رمز عبور تنها در هنگام تأیید مجوز برای اصلاح ارائه محافظت‌شده مورد نیاز است.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("write-protected-pres.pptx")
try:
    print("Slide count: " + str(presentation.getSlides().size()))
finally:
    presentation.dispose()
```

رمز عبور محافظت نوشتاری را به [LoadOptions.setPassword](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setPassword) ارسال نکنید. آن متد فقط رمز عبور باز کردن برای محتویات رمزنگاری‌شده را می‌پذیرد. اگر یک ارائه هر دو نوع محافظت را داشته باشد، رمز عبور باز کردن را برای بارگذاری ارائه ارائه دهید و رمز عبور محافظت نوشتاری را به‌صورت جداگانه مدیریت کنید.

## **حذف محافظت نوشتاری از یک ارائه**

از [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/protectionmanager/#removeWriteProtection) برای حذف محدودیت اصلاح استفاده کنید، سپس ارائه را ذخیره کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("write-protected-pres.pptx")
try:
    presentation.getProtectionManager().removeWriteProtection()
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **بررسی اینکه آیا یک ارائه محافظت نوشتاری دارد یا خیر**

برای بررسی یک فایل بدون ایجاد یک نمونهٔ کامل از [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/)، متد [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationfactory/#getPresentationInfo) را فراخوانی کنید و [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#isWriteProtected) را بررسی کنید. این متد از [NullableBool](https://reference.aspose.com/slides/fa/python-java/aspose.slides/nullablebool/) استفاده می‌کند و هنگام شناسایی محافظت نوشتاری مقدار `NullableBool.True_` را برمی‌گرداند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() == NullableBool.True_:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

نسخهٔ استریم از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationfactory/#getPresentationInfo) همان اطلاعات را برای ارائه‌ای که به صورت استریم ارائه می‌شود، فراهم می‌کند.

## **اعتبارسنجی رمز عبور محافظت نوشتاری**

از [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#checkWriteProtection) برای اعتبارسنجی رمز عبور اصلاح بدون بارگذاری کامل ارائه استفاده کنید. ابتدا [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#isWriteProtected) را بررسی کنید تا برنامه فقط زمانی که محافظت نوشتاری موجود باشد، رمز عبور را درخواست یا اعتبارسنجی کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() != NullableBool.True_:
    print("The presentation is not write protected.")
elif presentation_info.checkWriteProtection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#checkWriteProtection) فقط رمز عبور محافظت نوشتاری را معتبر می‌سازد. این متد رمز عبور باز کردن یا امکان بارگذاری محتواهای رمزنگاری‌شده را بررسی نمی‌کند. در عوض، [PresentationInfo.checkPassword](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationinfo/#checkPassword) فقط رمز عبور باز کردن را معتبر می‌سازد. اگر یک ارائه کامل قبلاً بارگذاری شده باشد، [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/protectionmanager/#checkWriteProtection) از طریق مدیر محافظت، بررسی معادل محافظت نوشتاری را فراهم می‌کند.

در برنامه‌های تولیدی، رمزهای عبور را لاگ نکنید یا در پیام‌های تشخیصی گنجانده نکنید. از تلاش‌های تکراری و بی‌مورد برای اعتبارسنجی جلوگیری کنید و رمزهای عبور را در حافظه تنها به مدت لازم نگه دارید.

{{% alert color="info" title="همچنین" %}}
- [Password-Protect Presentations](/slides/fa/python-java/password-protected-presentation/)
- [Read-Only Presentations](/slides/fa/python-java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/fa/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **پرسش‌های متداول**

**آیا محافظت نوشتاری یک ارائه را رمزنگاری می‌کند؟**

خیر. این محدودیت فقط اصلاح را اعمال می‌کند اما محتویات ارائه برای بارگذاری و نمایش در دسترس می‌ماند.

**آیا برای باز کردن یک ارائه نیاز به رمز عبور محافظت نوشتاری است؟**

خیر. فقط یک رمز عبور باز کردن برای بارگذاری محتویات رمزنگاری‌شدهٔ ارائه لازم است.

**آیا یک ارائه می‌تواند همزمان یک رمز عبور باز کردن و یک رمز عبور محافظت نوشتاری داشته باشد؟**

بله. رمز عبور باز کردن را از طریق گزینه‌های بارگذاری برای باز کردن ارائه رمزنگاری‌شده فراهم کنید و رمز عبور محافظت نوشتاری را به‌صورت جداگانه زمانی که نیاز به مجوز اصلاح باشد، اعتبارسنجی کنید.