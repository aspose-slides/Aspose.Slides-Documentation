---
title: باز کردن ارائه‌ها در پایتون از طریق جاوا
linktitle: باز کردن ارائه
type: docs
weight: 20
url: /fa/python-java/open-presentation/
keywords:
- باز کردن پاورپوینت
- باز کردن ارائه
- باز کردن PPTX
- باز کردن PPT
- باز کردن ODP
- بارگذاری ارائه
- بارگذاری PPTX
- بارگذاری PPT
- بارگذاری ODP
- ارائهٔ محافظت‌شده
- ارائهٔ بزرگ
- منبع خارجی
- شیء باینری
- پایتون
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه ارائه‌های PowerPoint و OpenDocument را در پایتون از طریق جاوا باز کنید، گذرواژه‌های باز کردن را فراهم کنید، بارگذاری منابع را کنترل کنید و با Aspose.Slides برای پایتون از طریق جاوا مصرف حافظه را کاهش دهید."
---
## **مقدمه**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/fa/python-java/) می‌تواند ارائه‌های PowerPoint و OpenDocument را از فایل‌ها و جریان‌ها بارگذاری کند. پس از بارگذاری یک ارائه، می‌توانید ساختار آن را بررسی کنید، اسلایدها را ویرایش کنید، منابع را مدیریت کنید و آن را در قالب اصلی یا قالب پشتیبانی‌شده دیگری ذخیره کنید.

رفتار بارگذاری می‌تواند از طریق کلاس [LoadOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/) سفارشی شود. برای مثال، می‌توانید گذرواژهٔ باز کردن را ارائه دهید، اشیای باینری بزرگ را خارج از حافظهٔ heap جاوا نگه دارید، منابع خارجی را کنترل کنید یا داده‌های باینری جاسازی‌شده را حذف کنید.

## **باز کردن ارائه‌ها**

برای باز کردن یک ارائهٔ موجود، مسیر فایل آن را به سازندهٔ [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) پاس دهید. پس از استفاده، ارائه را آزاد کنید تا دسته‌ها، داده‌های موقت و سایر منابع به‌سرعت آزاد شوند.

کد پایتون زیر نشان می‌دهد چگونه یک ارائه را باز کنید و تعداد اسلایدهای آن را دریافت کنید:

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

## **باز کردن ارائه‌های دارای گذرواژه**

یک گذرواژهٔ باز کردن محتویات ارائه را رمزنگاری می‌کند. برای بارگذاری کامل ارائه، گذرواژهٔ صحیح را به متد [LoadOptions.setPassword](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setPassword) بدهید و گزینه‌ها را به سازندهٔ [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ارسال کنید. در صورت عدم وجود یا نادرست بودن گذرواژه، بارگذاری ناموفق خواهد شد.

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

برای تشخیص گذرواژه، اعتبارسنجی و جریان‌های کاری رمزنگاری، به [Password‑Protect Presentations](/slides/fa/python-java/password-protected-presentation/) مراجعه کنید. اگر یک ارائهٔ رمزنگاری‌شده عمداً با ویژگی‌های عمومی سند ذخیره شده باشد، این ویژگی‌ها بدون گذرواژه قابل خواندن‌اند؛ برای جزئیات به [Manage Presentation Properties](/slides/fa/python-java/presentation-properties/) نگاه کنید.

## **باز کردن ارائه‌های بزرگ**

متد [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) گزینه‌هایی را برمی‌گرداند که نحوهٔ مدیریت اشیای باینری بزرگ مانند تصاویر، صدا و ویدئو توسط Aspose.Slides را کنترل می‌کند. می‌توانید فایل منبع را قفل نگه دارید، اجازهٔ ایجاد فایل‌های موقت را بدهید و میزان دادهٔ BLOB نگهداری‌شده در حافظه را محدود کنید.

کد پایتون زیر نحوهٔ بارگذاری یک ارائه بزرگ (مثلاً ۲ گیگابایت) را نشان می‌دهد:

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
با استفاده از [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked)، فایل منبع تا زمانی که نمونهٔ ارائه آزاد نشود، قفل می‌ماند. در حالی که این نمونه زنده است، فایل منبع را جابجا، بازنویسی یا حذف نکنید.

Aspose.Slides ممکن است هنگام بارگذاری، محتویات یک جریان ورودی را کپی کند. برای ارائه‌های بزرگ، مسیر فایل عموماً کارایی بالاتری نسبت به یک جریان دارد. برای گزینه‌های اضافی ذخیره‌سازی و مدیریت حافظه به [Manage BLOBs](/slides/fa/python-java/manage-blob/) مراجعه کنید.
{{% /alert %}}

## **کنترل منابع خارجی**

متد [LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) یک پروکسی JPype که رابط فراخوانی بارگذاری منبع جاوا را پیاده‌سازی می‌کند، می‌پذیرد. این فراخوانی می‌تواند دادهٔ جایگزین فراهم کند، منبعی را بازگردانی کند، از بارگذار پیش‌فرض استفاده کند یا منبع را نادیده بگیرد. این ویژگی زمانی مفید است که ارائه‌ها شامل تصاویر خارجی باشند که باید بر اساس قوانین امنیتی یا ذخیره‌سازی خاص برنامه حل شوند.

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

## **بارگذاری ارائه‌ها بدون اشیای باینری جاسازی‌شده**

یک ارائه ممکن است شامل داده‌های باینری جاسازی‌شده باشد که برنامه به آن‌ها نیازی ندارد یا نمی‌خواهد نگهداری کند. مثال‌ها شامل:

- پروژه‌های VBA که از طریق [Presentation.getVbaProject](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getVbaProject) در دسترس هستند؛
- داده‌های OLE جاسازی‌شده که از طریق [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) قابل دسترسی‌اند؛
- داده‌های کنترل ActiveX که از طریق [Control.getActiveXControlBinary](https://reference.aspose.com/slides/fa/python-java/aspose.slides/control/#getActiveXControlBinary) در دسترس هستند.

با تنظیم [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) بر روی `True` می‌توانید این داده‌های باینری را هنگام بارگذاری حذف کنید. ارائهٔ بارگذاری‌شده را ذخیره کنید تا نتیجهٔ پاک‌سازی شده حفظ شود.

این گزینه میزان تماس با payloadهای جاسازی‌شده‌ی ناخواسته را کاهش می‌دهد، اما یک سیستم کامل تشخیص بدافزار یا پاک‌سازی محتوا نیست.

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

**چگونه می‌توانم تشخیص دهم که یک فایل خراب است و نمی‌تواند باز شود؟**

Aspose.Slides هنگام بارگذاری یک استثنای پارس یا فرمت را پرتاب می‌کند. این شکست را جدا از خطای گذرواژهٔ نادرست مدیریت کنید تا برنامه بتواند علت را به‌دقت گزارش دهد.

**اگر قلم‌های موردنیاز موجود نباشند، چه اتفاقی می‌افتد؟**

ارائه هنوز می‌تواند بارگذاری شود، اما رندرینگ و خروجی ممکن است قلم‌ها را جایگزین کند. می‌توانید [configure font substitution](/slides/fa/python-java/font-substitution/) یا [provide custom fonts](/slides/fa/python-java/custom-font/) را اعمال کنید تا خروجی پیش‌بینی‌پذیرتر باشد.

**آیا بارگذاری یک ارائه همچنین رسانه‌های جاسازی‌شده را بارگذاری می‌کند؟**

صدا و ویدئوی جاسازی‌شده از طریق مدل شیء ارائه در دسترس می‌شوند. منابع خارجی براساس رفتار پیکربندی‌شدهٔ بارگذاری منبع حل می‌شوند و ممکن است در دسترس نباشند اگر محل آن‌ها قابل دسترسی نباشد.