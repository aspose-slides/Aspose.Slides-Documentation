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
- شیء باینری
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه ارائه‌های PowerPoint و OpenDocument را در Python باز کنید، رمزهای عبور باز کردن را فراهم کنید و با Aspose.Slides برای Python از طریق .NET مصرف حافظه را کاهش دهید."
---
## **مقدمه**

[Aspose.Slides برای Python از طریق .NET](https://products.aspose.com/slides/fa/python-net/) می‌تواند ارائه‌های PowerPoint و OpenDocument را از فایل‌ها و جریان‌ها بارگذاری کند. پس از بارگذاری یک ارائه، می‌توانید ساختار آن را بررسی کنید، اسلایدها را ویرایش کنید، منابع را مدیریت کنید و آن را در قالب اصلی یا قالب دیگری که پشتیبانی می‌شود ذخیره کنید.

رفتار بارگذاری می‌تواند از طریق کلاس [LoadOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/) سفارشی شود. به عنوان مثال، می‌توانید یک رمز عبور باز کردن ارائه دهید، اشیای باینری بزرگ را خارج از حافظه نگه دارید یا داده‌های باینری تعبیه‌شده را حذف کنید.

## **باز کردن ارائه‌ها**

برای باز کردن یک ارائه موجود، مسیر فایل آن را به سازنده [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) بدهید. از عبارت `with` استفاده کنید تا دسته‌های فایل، داده‌های موقت و سایر منابع به‌سرعت آزاد شوند.

مثال زیر در Python نشان می‌دهد چگونه یک ارائه را باز کنید و تعداد اسلایدهای آن را به‌دست آورید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **باز کردن ارائه‌های محافظت‌شده با رمز عبور**

یک رمز عبور باز کردن محتوای ارائه را رمزنگاری می‌کند. برای بارگذاری کامل ارائه، رمز عبور صحیح را به [LoadOptions.password](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/password/) اختصاص داده و گزینه‌ها را به سازنده [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) بدهید. اگر رمز عبور فقدان یا نادرست باشد، بارگذاری شکست می‌خورد.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

برای شناسایی رمز عبور، اعتبارسنجی و جریان‌های کاری رمزنگاری، به [Password-Protect Presentations](/slides/fa/python-net/password-protected-presentation/) مراجعه کنید. اگر یک ارائه رمزنگاری‌شده عمدیاً با خصوصیات عمومی سند ذخیره شده باشد، می‌توان این خصوصیات را بدون رمز عبور خواند؛ برای اطلاعات بیشتر به [Manage Presentation Properties](/slides/fa/python-net/presentation-properties/) نگاه کنید.

## **باز کردن ارائه‌های بزرگ**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/blob_management_options/) نحوهٔ مدیریت اشیای باینری بزرگ مانند تصاویر، صدا و ویدیو را توسط Aspose.Slides کنترل می‌کند. می‌توانید فایل منبع را قفل نگه دارید، اجازهٔ ایجاد فایل‌های موقت را بدهید و مقدار داده‌های BLOB نگه‌داشته‌شده در حافظه را محدود کنید.

این کد Python نشان می‌دهد چگونه یک ارائه بزرگ (مثلاً ۲ گیگابایت) را بارگذاری کنید:

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
با `PresentationLockingBehavior.KEEP_LOCKED`، فایل منبع تا زمانی که شیء `Presentation` آزاد نشود، قفل می‌ماند. در حالی که این شیء زنده است، فایل منبع را جابجا، بازنویسی یا حذف نکنید.

Aspose.Slides ممکن است محتویات یک جریان ورودی را در هنگام بارگذاری کپی کند. برای ارائه‌های بزرگ، استفاده از مسیر فایل عموماً کارآمدتر از استفاده از جریان است. برای گزینه‌های اضافی ذخیره‌سازی و مدیریت حافظه به [Manage BLOBs](/slides/fa/python-net/manage-blob/) مراجعه کنید.
{{% /alert %}}

## **بارگذاری ارائه‌ها بدون اشیای باینری تعبیه‌شده**

یک ارائه ممکن است شامل داده‌های باینری تعبیه‌شده باشد که برنامه به آن نیاز ندارد یا نمی‌خواهد آن را نگه دارد. مثال‌ها شامل:

- پروژه‌های VBA که از طریق [Presentation.vba_project](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/vba_project/) قابل دسترسی هستند؛
- داده‌های OLE تعبیه‌شده که از طریق [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/) در دسترس هستند؛
- داده‌های کنترل ActiveX که از طریق [Control.active_x_control_binary](https://reference.aspose.com/slides/fa/python-net/aspose.slides/control/active_x_control_binary/) قابل دسترسی هستند.

[LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) را به `True` تنظیم کنید تا این داده‌های باینری در حین بارگذاری حذف شوند. ارائه بارگذاری‌شده را ذخیره کنید تا نتیجهٔ پاک‌سازی‌شده حفظ شود.

این گزینه مواجهه با بارهای باینری تعبیه‌شدهٔ ناخواسته را کاهش می‌دهد، اما جایگزین یک سیستم کامل شناسایی بدافزار یا پاک‌سازی محتوا نیست.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**چگونه می‌توانم بفهمم که یک فایل خراب است و نمی‌توان آن را باز کرد؟**

Aspose.Slides هنگام بارگذاری یک استثنای تجزیه یا قالب‌بندی را ارتقاء می‌دهد. این شکست را جدا از خطای رمز عبور نادرست مدیریت کنید تا برنامه بتواند دلیل را به‌دقت گزارش دهد.

**اگر قلم‌های لازم وجود نداشته باشند، چه اتفاقی می‌افتد؟**

ارائه همچنان می‌تواند بارگذاری شود، اما رندرینگ و خروجی ممکن است قلم‌ها را جایگزین کند. می‌توانید [configure font substitution](/slides/fa/python-net/font-substitution/) یا [provide custom fonts](/slides/fa/python-net/custom-font/) را انجام دهید تا خروجی پیش‌بینی‌پذیرتر باشد.

**آیا بارگذاری یک ارائه، رسانه‌های تعبیه‌شدهٔ آن را نیز بارگذاری می‌کند؟**

صدا و ویدیوهای تعبیه‌شده از طریق مدل شیء ارائه در دسترس می‌شوند. منابع خارجی بر اساس رفتار پیش‌فرض بارگذاری منابع حل می‌شوند و ممکن است در صورتی که مکان‌های آن‌ها قابل دسترسی نباشد، در دسترس نباشند.