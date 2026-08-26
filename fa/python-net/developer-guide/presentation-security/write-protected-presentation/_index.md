---
title: محافظت‌نوشتن ارائه‌ها در پایتون
linktitle: محافظت نوشتن
type: docs
weight: 25
url: /fa/python-net/write-protected-presentation/
keywords:
- محافظت نوشتن
- محافظت نوشتن پاورپوینت
- رمز عبور برای اصلاح
- محدود کردن ویرایش ارائه
- حذف محافظت نوشتن
- اعتبارسنجی رمز عبور اصلاح
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "قرار دادن، شناسایی، اعتبارسنجی و حذف رمزهای محافظت‌نوشتن در ارائه‌های PowerPoint PPT و PPTX با استفاده از Aspose.Slides برای پایتون."
---
## **معرفی**

رمز عبور محافظت‌ازنوشتن محدودیت اصلاح یک ارائه را اعمال می‌کند اما محتوای آن را رمزنگاری نمی‌کند. کاربران می‌توانند ارائه محافظت‌ازنوشتن را بدون رمز عبور بارگیری و مشاهده کنند. بسته به برنامه، ممکن است بتوانند محتوا را ویرایش کرده و تحت نام دیگری ذخیره کنند، بنابراین محافظت‌ازنوشتن نباید به عنوان مکانیزم محرمانگی در نظر گرفته شود.

رمز عبور بازکردن هدف متفاوتی دارد: ارائه را رمزنگاری می‌کند و برای بارگیری محتوای آن لازم است. برای رمزنگاری یک ارائه یا اعتبارسنجی رمز عبور بازکردن، به [ارائه‌های محافظت‌شده با رمزعبور](/slides/fa/python-net/password-protected-presentation/) مراجعه کنید.

روش‌های کاری در این مقاله برای ارائه‌های PPT و PPTX هر دو اعمال می‌شود. مثال‌ها از فایل‌های PPTX استفاده می‌کنند؛ هنگام ذخیره به PPT، پسوند `.ppt` و قالب ذخیره‌سازی PPT مربوطه را استفاده کنید.

## **تنظیم محافظت‌ازنوشتن بر یک ارائه**

از [ProtectionManager.set_write_protection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/protectionmanager/set_write_protection/) برای اختصاص یک رمز عبور برای اصلاح یک ارائه استفاده کنید. ذخیره‌سازی ارائه تنظیم محافظت را حفظ می‌کند.

مثال زیر محافظت‌ازنوشتن را بر یک ارائه PPTX تنظیم می‌کند:
```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.set_write_protection("modify_password")
    presentation.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **بارگیری یک ارائه محافظت‌ازنوشتن**

به دلیل اینکه محافظت‌ازنوشتن محتوای ارائه را رمزنگاری نمی‌کند، برای بارگیری ارائه نیازی به رمز عبور نیست. رمز عبور تنها زمانی مرتبط است که اعتبارسنجی مجوز اصلاح ارائه محافظت‌شده انجام شود.
```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

رمز عبور محافظت‌ازنوشتن را به [LoadOptions.password](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/password/) ارسال نکنید. این ویژگی یک رمز عبور بازکردن برای محتوای رمزنگاری‌شده می‌پذیرد. اگر یک ارائه هر دو نوع محافظت را داشته باشد، رمز عبور بازکردن را برای بارگیری آن ارائه کنید و رمز عبور محافظت‌ازنوشتن را به صورت جداگانه مدیریت کنید.

## **حذف محافظت‌ازنوشتن از یک ارائه**

از [ProtectionManager.remove_write_protection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/protectionmanager/remove_write_protection/) برای حذف محدودیت اصلاح استفاده کنید، سپس ارائه را ذخیره کنید.
```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    presentation.protection_manager.remove_write_protection()
    presentation.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **بررسی اینکه آیا یک ارائه محافظت‌ازنوشتن است**

برای بررسی یک فایل بدون ایجاد یک نمونه کامل از [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/)، تابع [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationfactory/get_presentation_info/) را صدا بزنید و [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/is_write_protected/) را بررسی کنید. این ویژگی از [NullableBool](https://reference.aspose.com/slides/fa/python-net/aspose.slides/nullablebool/) استفاده می‌کند و وقتی محافظت‌ازنوشتن شناسایی شود `NullableBool.TRUE` را بازمی‌گرداند.
```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected == slides.NullableBool.TRUE:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

بارگذاری با جریان از [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationfactory/get_presentation_info/) همان اطلاعات را برای ارائه‌ای که به صورت جریان ارائه می‌شود، فراهم می‌کند.

## **اعتبارسنجی رمز عبور محافظت‌ازنوشتن**

از [PresentationInfo.check_write_protection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/check_write_protection/) برای اعتبارسنجی رمز عبور اصلاح بدون بارگیری کامل ارائه استفاده کنید. ابتدا [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/is_write_protected/) را بررسی کنید تا برنامه فقط زمانی که محافظت‌ازنوشتن وجود دارد، درخواست یا اعتبارسنجی رمز عبور را انجام دهد.
```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected != slides.NullableBool.TRUE:
    print("The presentation is not write protected.")
elif presentation_info.check_write_protection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

متد [PresentationInfo.check_write_protection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/check_write_protection/) فقط رمز عبور محافظت‌ازنوشتن را اعتبارسنجی می‌کند. این متد رمز عبور بازکردن را اعتبارسنجی نمی‌کند و نمی‌تواند تعیین کند آیا محتوای رمزنگاری‌شده قابل بارگیری است یا نه. برعکس، متد [PresentationInfo.check_password](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentationinfo/check_password/) فقط یک رمز عبور بازکردن را اعتبارسنجی می‌کند. اگر یک ارائه کامل قبلاً بارگیری شده باشد، [ProtectionManager.check_write_protection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/protectionmanager/check_write_protection/) چک معادل محافظت‌ازنوشتن را از طریق مدیر محافظت خود فراهم می‌کند.

در برنامه‌های تولیدی، رمزهای عبور را لاگ نکنید و در پیام‌های تشخیصی وارد نکنید. از تلاش‌های تکراری و غیرضروری برای اعتبارسنجی جلوگیری کنید و رمزها را در حافظه تنها به مدت لازم نگه دارید.

{{% alert color="info" title="موارد مرتبط" %}}
- [ارائه‌های محافظت‌شده با رمزعبور](/slides/fa/python-net/password-protected-presentation/)
- [ارائه‌های فقط خواندنی](/slides/fa/python-net/read-only-presentation/)
- [امضای دیجیتال در پاورپوینت](/slides/fa/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **سوالات متداول**

**آیا محافظت‌ازنوشتن یک ارائه را رمزنگاری می‌کند؟**

خیر. این محدودیت اصلاح اعمال می‌کند اما محتوای ارائه برای بارگیری و مشاهده در دسترس می‌ماند.

**آیا رمز عبور محافظت‌ازنوشتن برای باز کردن یک ارائه لازم است؟**

خیر. تنها یک رمز عبور بازکردن برای بارگیری محتوای رمزنگاری‌شده ارائه لازم است.

**آیا یک ارائه می‌تواند همزمان رمز عبور بازکردن و رمز عبور محافظت‌ازنوشتن داشته باشد؟**

بله. رمز عبور بازکردن را از طریق گزینه‌های بارگیری برای باز کردن ارائه رمزنگاری‌شده فراهم کنید و هنگام نیاز به مجوز اصلاح، رمز عبور محافظت‌ازنوشتن را به صورت جداگانه اعتبارسنجی کنید.