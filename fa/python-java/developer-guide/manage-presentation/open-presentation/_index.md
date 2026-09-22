---
title: باز کردن ارائه‌ها در Python از طریق Java
linktitle: باز کردن ارائه
type: docs
weight: 20
url: /fa/python-java/open-presentation/
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
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه ارائه‌های PowerPoint و OpenDocument را در Python از طریق Java باز کنید، رمزهای عبور باز کردن را فراهم کنید، بارگذاری منابع را کنترل کنید و با Aspose.Slides برای Python از طریق Java مصرف حافظه را کاهش دهید."
---
## **مقدمه**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/fa/python-java/) می‌تواند ارائه‌های PowerPoint و OpenDocument را از فایل‌ها و جریان‌ها بارگذاری کند. پس از بارگذاری یک ارائه، می‌توانید ساختار آن را بررسی کنید، اسلایدها را ویرایش کنید، منابع را مدیریت کنید و آن را در قالب اصلی یا قالب دیگر پشتیبانی‌شده ذخیره کنید.

رفتار بارگذاری می‌تواند از طریق کلاس [LoadOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/) سفارشی شود. به عنوان مثال، می‌توانید رمز عبور باز کردن را ارائه دهید، اشیاء باینری بزرگ را خارج از حافظهٔ heap جاوا نگه دارید، منابع خارجی را کنترل کنید یا داده‌های باینری درج‌شده را حذف کنید.

## **باز کردن ارائه‌ها**

پس از بارگذاری یک فایل یا جریان، می‌توانید قالب اصلی ارائه را تعیین کنید تا انتخاب کنید برنامه‌تان چگونه آن را پردازش می‌کند.

برای باز کردن یک ارائه موجود، مسیر فایل آن را به سازنده [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) پاس دهید. پس از استفاده، ارائه را آزاد کنید تا دست handleهای فایل، داده‌های موقت و سایر منابع به‌سرعت آزاد شوند.

مثال زیر پایتون نشان می‌دهد چگونه یک ارائه را باز کنید و تعداد اسلایدهای آن را به دست آورید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **باز کردن ارائه‌های دارای رمز عبور**

یک رمز عبور باز کردن محتویات ارائه را رمزگذاری می‌کند. برای بارگذاری کامل ارائه، رمز عبور صحیح را به [LoadOptions.setPassword](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setPassword) پاس دهید و گزینه‌ها را به سازنده [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ارائه کنید. اگر رمز عبور موجود نباشد یا نادرست باشد، بارگذاری شکست می‌خورد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-presentation.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

برای تشخیص رمز عبور، اعتبارسنجی و جریان‌های کاری رمزگذاری، به [Password-Protect Presentations](/slides/fa/python-java/password-protected-presentation/) مراجعه کنید. اگر یک ارائه رمزگذاری‌شده عمداً با خواص عمومی سند ذخیره شده باشد، می‌توان این خواص را بدون رمز عبور خواند؛ به [Manage Presentation Properties](/slides/fa/python-java/presentation-properties/) نگاه کنید.

## **باز کردن ارائه‌های بزرگ**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) گزینه‌هایی را برمی‌گرداند که کنترل می‌کند Aspose.Slides چگونه اشیاء بزرگ باینری مانند تصاویر، صدا و ویدئو را مدیریت می‌کند. می‌توانید فایل منبع را قفل نگه دارید، فایل‌های موقت را اجازه دهید و مقدار داده‌های BLOB نگهداری‌شده در حافظه را محدود کنید.

کد پایتون زیر بارگذاری یک ارائه بزرگ (مثلاً ۲ گیگابایت) را نشان می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

file_path = "large-presentation.pptx"

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024)

presentation = Presentation(file_path, load_options)
try:
    presentation.getSlides().get_Item(0).setName("Large presentation")
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
با [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked)، فایل منبع تا زمانی که نمونهٔ ارائه آزاد نشود، قفل می‌ماند. هنگام زنده بودن آن نمونه، فایل منبع را جابه‌جا، بازنویسی یا حذف نکنید.

Aspose.Slides ممکن است هنگام بارگذاری، محتویات یک جریان ورودی را کپی کند. برای ارائه‌های بزرگ، مسیر فایل به‌طور کلی کارآمدتر از یک جریان است. برای گزینه‌های اضافی ذخیره‌سازی و مدیریت حافظه به [Manage BLOBs](/slides/fa/python-java/manage-blob/) مراجعه کنید.
{{% /alert %}}

## **کنترل منابع خارجی**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) یک پروکسی JPype که رابط فراخوانی بارگذاری منابع جاوا را پیاده‌سازی می‌کند می‌پذیرد. این فراخوانی می‌تواند داده‌های جایگزین ارائه دهد، یک منبع را دوباره مسیردهی کند، از بارگذار پیش‌فرض استفاده کند یا منبع را نادیده بگیرد. این هنگامی مفید است که ارائه‌ها شامل تصاویر خارجی باشند که باید بر اساس قوانین امنیتی یا ذخیره‌سازی مخصوص برنامه حل شوند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadOptions, Presentation, ResourceLoadingAction

class ImageLoadingHandler:
    def resourceLoading(self, resource_loading_arguments):
        is_jpeg = str(resource_loading_arguments.getOriginalUri()).lower().endswith(".jpg")
        approved_image_path = Path("approved-image.jpg")
        if not is_jpeg or not approved_image_path.exists():
            return ResourceLoadingAction.Skip

        try:
            image_data = approved_image_path.read_bytes()
            java_image_data = jpype.JArray(jpype.JByte)(image_data)
            resource_loading_arguments.setData(java_image_data)
            return ResourceLoadingAction.UserProvided
        except OSError:
            print("The approved replacement image could not be read.")
            return ResourceLoadingAction.Skip

load_options = LoadOptions()
image_loading_handler = ImageLoadingHandler()
callback = jpype.JProxy("com.aspose.slides.IResourceLoadingCallback", inst=image_loading_handler)
load_options.setResourceLoadingCallback(callback)

presentation = Presentation("presentation-with-external-images.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **بارگذاری ارائه‌ها بدون اشیاء باینری جاسازی‌شده**

یک ارائه ممکن است شامل داده‌های باینری جاسازی‌شده‌ای باشد که برنامه به آن نیازی ندارد یا نمی‌خواهد نگه دارد. مثال‌ها شامل:

- پروژه‌های VBA، که از طریق [Presentation.getVbaProject](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getVbaProject) در دسترس هستند؛
- داده‌های OLE جاسازی‌شده، که از طریق [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) در دسترس هستند؛
- داده‌های کنترل ActiveX، که از طریق [Control.getActiveXControlBinary](https://reference.aspose.com/slides/fa/python-java/aspose.slides/control/#getActiveXControlBinary) در دسترس هستند.

LoadOptions.setDeleteEmbeddedBinaryObjects را روی `True` تنظیم کنید تا این داده‌های باینری هنگام بارگذاری حذف شوند. ارائه بارگذاری‌شده را ذخیره کنید تا نتیجهٔ پاک‌سازی‌شده حفظ شود.

این گزینه خطر در معرض بودن در برابر محتویات جاسازی‌شدهٔ ناخواسته را کاهش می‌دهد، اما یک سیستم کامل تشخیص بدافزار یا پاک‌سازی محتوا نیست.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setDeleteEmbeddedBinaryObjects(True)

presentation = Presentation("presentation-with-embedded-data.pptx", load_options)
try:
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **سوالات متداول**

**چگونه می‌توانم تشخیص دهم که یک فایل خراب است و نمی‌توان آن را باز کرد؟**

Aspose.Slides هنگام بارگذاری استثنای تجزیه یا قالب را می‌اندازد. این شکست را به‌صورت جداگانه از خطای رمز عبور نادرست مدیریت کنید تا برنامه بتواند علت را به‌درستی گزارش دهد.

**اگر قلم‌های مورد نیاز موجود نباشند چه می‌شود؟**

ارائه هنوز می‌تواند بارگذاری شود، اما رندرینگ و خروجی ممکن است قلم‌ها را جایگزین کنند. می‌توانید جایگزینی قلم‌ها را پیکربندی کنید یا قلم‌های سفارشی ارائه دهید تا خروجی پیش‌بینی‌پذیرتر باشد.

**آیا بارگذاری یک ارائه همچنین رسانه‌های جاسازی‌شده آن را بارگذاری می‌کند؟**

صدا و ویدئوهای جاسازی‌شده از طریق مدل شیء ارائه در دسترس قرار می‌گیرند. منابع خارجی بر اساس رفتار پیکربندی‌شدهٔ بارگذاری منابع حل می‌شوند و ممکن است در صورت عدم دسترسی به مکان‌های آن‌ها، در دسترس نباشند.