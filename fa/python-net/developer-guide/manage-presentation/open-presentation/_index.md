---
title: "باز کردن ارائه‌ها در پایتون"
linktitle: "باز کردن ارائه‌ها"
type: docs
weight: 20
url: /fa/python-net/open-presentation/
keywords:
- "باز کردن PowerPoint"
- "باز کردن ارائه"
- "باز کردن PPTX"
- "باز کردن PPT"
- "باز کردن ODP"
- "بارگذاری ارائه"
- "بارگذاری PPTX"
- "بارگذاری PPT"
- "بارگذاری ODP"
- "ارائه محافظت‌شده"
- "ارائه بزرگ"
- "منبع خارجی"
- "شیء باینری"
- "پایتون"
- "Aspose.Slides"
description: "یاد بگیرید چگونه ارائه‌های PowerPoint و OpenDocument را در پایتون باز کنید، گذرواژه‌های بازشو را فراهم کنید، و با Aspose.Slides برای پایتون از طریق .NET مصرف حافظه را کاهش دهید."
---
## **مقدمه**

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/fa/python-net/) می‌تواند ارائه‌های PowerPoint و OpenDocument را از فایل‌ها و جریان‌ها بارگذاری کند. پس از بارگذاری یک ارائه، می‌توانید ساختار آن را بررسی کنید، اسلایدها را ویرایش کنید، منابع را مدیریت کنید و آن را در فرمت اصلی یا فرمت پشتیبانی‌شده دیگر ذخیره کنید.

رفتار بارگذاری می‌تواند از طریق کلاس [LoadOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/) سفارشی‌سازی شود. برای مثال، می‌توانید یک رمز عبور بازشو ارائه دهید، اشیای بزرگ باینری را خارج از حافظه نگه دارید یا داده‌های باینری جاسازی‌شده را حذف کنید.

## **بازکردن ارائه‌ها**

پس از بارگذاری یک فایل یا جریان، می‌توانید [فرمت اصلی ارائه را تعیین کنید](/slides/fa/python-net/detect-presentation-source-format/) تا روش پردازش آن توسط برنامه‌تان انتخاب شود.

برای باز کردن یک ارائه موجود، مسیر فایل آن را به سازنده [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) بدهید. از یک عبارت `with` استفاده کنید تا دسته‌های فایل، داده‌های موقت و سایر منابع به‌سرعت آزاد شوند.

مثال زیر در پایتون نشان می‌دهد چگونه یک ارائه را باز کنید و تعداد اسلایدهای آن را به‌دست آورید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **بازکردن ارائه‌های محافظت‌شده با رمز عبور**

یک رمز عبور بازشو محتوای ارائه را رمزگذاری می‌کند. برای بارگذاری کامل ارائه، رمز عبور صحیح را به [LoadOptions.password](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/password/) اختصاص داده و گزینه‌ها را به سازنده [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) پاس کنید. بارگذاری زمانی که رمز عبور موجود نباشد یا نادرست باشد، انجام نمی‌شود.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

برای شناسایی رمز عبور، اعتبارسنجی و گردش‌کارهای رمزگذاری، به [Password-Protect Presentations](/slides/fa/python-net/password-protected-presentation/) مراجعه کنید. اگر یک ارائه رمزگذاری‌شده عمداً با خصوصیات عمومی سند ذخیره شده باشد، می‌توان این خصوصیات را بدون رمز عبور خواند؛ به [Manage Presentation Properties](/slides/fa/python-net/presentation-properties/) نگاه کنید.

## **بازکردن ارائه‌های بزرگ**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/blob_management_options/) کنترل می‌کند Aspose.Slides چگونه اشیای باینری بزرگ مانند تصویرها، صوت و ویدئو را مدیریت می‌کند. می‌توانید فایل منبع را قفل نگه دارید، اجازه فایل‌های موقت بدهید و مقدار داده‌های BLOB نگهداری‌شده در حافظه را محدود کنید.

این کد پایتون نشان می‌دهد چگونه یک ارائه بزرگ (مثلاً ۲ گیگابایت) را بارگذاری کنید:

```python
import aspose.slides as slides
file_path = "large-presentation.pptx"

load_options = slides.LoadOptions()
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024

with slides.Presentation(file_path, load_options) as presentation:
    presentation.slides[0].name = "Large presentation"
    presentation.save("large-presentation-copy.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
با `PresentationLockingBehavior.KEEP_LOCKED`، فایل منبع تا زمانی که شیء `Presentation` آزاد نشود، قفل می‌ماند. در حین وجود این شیء، فایل منبع را جابه‌جا، بازنویسی یا حذف نکنید.
{{% /alert %}}

Aspose.Slides ممکن است هنگام بارگذاری، محتویات یک جریان ورودی را کپی کند. برای ارائه‌های بزرگ، استفاده از مسیر فایل معمولاً کارآمدتر از یک جریان است. برای گزینه‌های اضافی ذخیره‌سازی و مدیریت حافظه به [Manage BLOBs](/slides/fa/python-net/manage-blob/) مراجعه کنید.

## **بارگذاری ارائه‌ها بدون اشیای باینری جاسازی‌شده**

یک ارائه ممکن است داده‌های باینری جاسازی‌شده داشته باشد که برنامه نیاز نداشته باشد یا نخواهد نگه دارد. مثال‌ها شامل:

- پروژه‌های VBA، که از طریق [Presentation.vba_project](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/vba_project/) در دسترس هستند؛
- داده‌های OLE جاسازی‌شده، که از طریق [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/) در دسترس هستند؛
- داده‌های کنترل ActiveX، که از طریق [Control.active_x_control_binary](https://reference.aspose.com/slides/fa/python-net/aspose.slides/control/active_x_control_binary/) در دسترس هستند.

[LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) را به `True` تنظیم کنید تا این داده‌های باینری در هنگام بارگذاری حذف شوند. ارائه بارگذاری‌شده را ذخیره کنید تا نتیجه پاک‌سازی‌شده حفظ شود.

این گزینه خطر مواجهه با محتوای جاسازی‌شده ناخواسته را کاهش می‌دهد، اما یک سیستم کامل شناسایی مخرب یا پاک‌سازی محتوا نیست.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**چگونه می‌توانم بفهمم که یک فایل خراب است و نمی‌توان آن را باز کرد؟**

Aspose.Slides هنگام بارگذاری یک استثنای تجزیه یا فرمت را پرتاب می‌کند. این شکست را جدا از خطای رمز عبور نادرست مدیریت کنید تا برنامه بتواند دلیل دقیق را گزارش دهد.

**اگر قلم‌های مورد نیاز موجود نباشند چه اتفاقی می‌افتد؟**

ارائه هنوز می‌تواند بارگذاری شود، اما رندرینگ و خروجی ممکن است قلم‌ها را جایگزین کند. می‌توانید [پیکربندی جایگزینی قلم](/slides/fa/python-net/font-substitution/) یا [ارائه قلم‌های سفارشی](/slides/fa/python-net/custom-font/) را انجام دهید تا خروجی قابل پیش‌بینی‌تر باشد.

**آیا بارگذاری یک ارائه، رسانه‌های جاسازی‌شده آن را نیز بارگذاری می‌کند؟**

صدا و ویدئوی جاسازی‌شده از طریق مدل شیء ارائه در دسترس می‌شوند. منابع خارجی بر اساس رفتار پیش‌فرض بارگذاری منابع حل می‌شوند و ممکن است اگر مکان آن‌ها قابل دسترس نباشد، در دسترس نباشند.