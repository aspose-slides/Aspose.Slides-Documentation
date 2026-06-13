---
title: باز کردن ارائه‌ها در Python
linktitle: باز کردن ارائه‌ها
type: docs
weight: 20
url: /fa/python-net/open-presentation/
keywords:
- باز کردن PowerPoint
- باز کردن ارائه
- باز کردن PPTX
- باز کردن PPT
- باز کردن ODP
- بارگذاری ارائه
- بارگذاری PPTX
- بارگذاری PPT
- بارگذاری ODP
- ارائه محافظت‌شده
- ارائه بزرگ
- منبع خارجی
- شی باینری
- Python
- Aspose.Slides
description: "به راحتی ارائه‌های PowerPoint (.pptx، .ppt) و OpenDocument (.odp) را با Aspose.Slides برای Python از طریق .NET — سریع، قابل اعتماد، کاملاً مجهز."
---
## **مقدمه**

علاوه بر ایجاد ارائه‌های PowerPoint از ابتدا، Aspose.Slides به شما امکان باز کردن ارائه‌های موجود را نیز می‌دهد. پس از بارگذاری یک ارائه، می‌توانید اطلاعات مربوط به آن را استخراج کنید، محتوای اسلایدها را ویرایش کنید، اسلایدهای جدید اضافه کنید، اسلایدهای موجود را حذف کنید و کارهای دیگری انجام دهید.

## **باز کردن ارائه‌ها**

برای باز کردن یک ارائه موجود، یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید و مسیر فایل را به سازنده آن پاس دهید.

مثال زیر در Python نشان می‌دهد چگونه یک ارائه را باز کنید و تعداد اسلایدهای آن را دریافت کنید:

```python
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد کنید و مسیر فایل را به سازنده آن پاس دهید.
with slides.Presentation("sample.pptx") as presentation:
    # تعداد کل اسلایدهای موجود در ارائه را چاپ کنید.
    print(presentation.slides.length)
```

## **باز کردن ارائه‌های دارای رمز عبور**

زمانی که نیاز به باز کردن ارائه‌ای با حفاظت رمز عبور دارید، رمز عبور را از طریق ویژگی [password](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/password/) کلاس [LoadOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/) به منظور رمزگشایی و بارگذاری ارائه پاس می‌دهید. کد Python زیر این عملیات را نشان می‌دهد:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # انجام عملیات روی ارائه رمزگشایی شده.
```

## **باز کردن ارائه‌های بزرگ**

Aspose.Slides گزینه‌هایی را فراهم می‌کند—به ویژه ویژگی [blob_management_options](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/blob_management_options/) در کلاس [LoadOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/)—تا به شما در بارگذاری ارائه‌های بزرگ کمک کند.

این کد Python بارگذاری یک ارائه بزرگ (به عنوان مثال، ۲ گیگابایت) را نشان می‌دهد:

```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# رفتار KeepLocked را انتخاب کنید—فایل ارائه برای طول عمر 
# نمونه Presentation قفل خواهد ماند، اما نیازی به بارگذاری در حافظه یا کپی به فایل موقت نیست.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 مگابایت

with slides.Presentation(file_path, load_options) as presentation:
    # ارائه بزرگ بارگذاری شد و می‌توان از آن استفاده کرد، در حالی که مصرف حافظه کم می‌ماند.

    # اعمال تغییرات روی ارائه.
    presentation.slides[0].name = "Large presentation"

    # ذخیره ارائه به فایل دیگر. در طول این عملیات مصرف حافظه کم می‌ماند.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # این کار را نکنید! یک استثنای I/O پرتاب خواهد شد زیرا فایل تا زمان آزاد شدن شیء Presentation قفل می‌ماند.
    os.remove(file_path)

# این کار اینجا مجاز است. فایل منبع دیگر توسط شیء Presentation قفل نشده است.
os.remove(file_path)
```

{{% alert color="info" title="Info" %}}
برای دور زدن برخی محدودیت‌ها هنگام کار با جریان‌ها، Aspose.Slides ممکن است محتوای یک جریان را کپی کند. بارگذاری یک ارائه بزرگ از یک جریان باعث کپی شدن ارائه می‌شود و می‌تواند سرعت بارگذاری را کاهش دهد. بنابراین، زمانی که نیاز به بارگذاری یک ارائه بزرگ دارید، به شدت توصیه می‌کنیم از مسیر فایل ارائه به جای یک جریان استفاده کنید.

هنگام ایجاد یک ارائه که شامل اشیاء بزرگ (ویدئو، صوت، تصاویر با وضوح بالا و غیره) باشد، می‌توانید از [BLOB management](/slides/fa/python-net/manage-blob/) برای کاهش مصرف حافظه استفاده کنید.
{{%/alert %}}

## **بارگذاری ارائه‌ها بدون اشیای باینری توکار**

یک ارائه PowerPoint می‌تواند انواع زیر از اشیای باینری توکار را داشته باشد:

- پروژه VBA (قابل دسترسی از طریق [Presentation.vba_project](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/vba_project/));
- داده‌های توکار شی OLE (قابل دسترسی از طریق [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/));
- داده‌های باینری کنترل ActiveX (قابل دسترسی از طریق [Control.active_x_control_binary](https://reference.aspose.com/slides/fa/python-net/aspose.slides/control/active_x_control_binary/)).

با استفاده از ویژگی [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) می‌توانید یک ارائه را بدون هیچ‌یک از اشیای باینری توکار بارگذاری کنید.

این ویژگی برای حذف محتویات باینری احتمالی مخرب مفید است. کد Python زیر نشان می‌دهد چگونه یک ارائه را بدون هیچ‌یک از محتویات باینری توکار بارگذاری کنید:

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # انجام عملیات بر روی ارائه.
```

## **سوالات متداول**

**چگونه می‌توانم بفهمم که یک فایل خراب است و نمی‌توان آن را باز کرد؟**

در هنگام بارگذاری یک استثنای تجزیه/اعتبارسنجی قالب دریافت خواهید کرد. چنین خطاها اغلب به ساختار ZIP نامعتبر یا رکوردهای PowerPoint خراب اشاره می‌کنند.

**اگر فونت‌های مورد نیاز هنگام باز کردن موجود نباشند چه اتفاقی می‌افتد؟**

فایل باز می‌شود، اما بعداً هنگام [rendering/export](/slides/fa/python-net/convert-presentation/) ممکن است فونت‌ها جایگزین شوند. برای جلوگیری از این موضوع می‌توانید [Configure font substitutions](/slides/fa/python-net/font-substitution/) یا [add the required fonts](/slides/fa/python-net/custom-font/) را به محیط اجرایی اضافه کنید.

**در مورد رسانه‌های توکار (ویدئو/صوت) هنگام باز کردن چه می‌شود؟**

آنها به عنوان منابع ارائه در دسترس می‌شوند. اگر رسانه‌ها از طریق مسیرهای خارجی ارجاع داده شوند، اطمینان حاصل کنید این مسیرها در محیط شما قابل دسترسی هستند؛ در غیر این صورت ممکن است [rendering/export](/slides/fa/python-net/convert-presentation/) رسانه‌ها را حذف کند.