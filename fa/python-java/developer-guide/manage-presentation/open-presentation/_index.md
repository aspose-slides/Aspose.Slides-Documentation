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
- ارائه محافظت‌شده
- ارائه بزرگ
- منبع خارجی
- شی باینری
- پایتون
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه ارائه‌های PowerPoint و OpenDocument را در پایتون از طریق جاوا باز کنید، گذرواژه‌های باز کردن را فراهم کنید، بارگذاری منابع را کنترل کنید و با Aspose.Slides برای پایتون از طریق جاوا مصرف حافظه را کاهش دهید."
---
## **مقدمه**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/fa/python-java/) می‌تواند ارائه‌های PowerPoint و OpenDocument را از فایل‌ها و جریان‌ها بارگذاری کند. پس از بارگذاری یک ارائه، می‌توانید ساختار آن را بررسی کنید، اسلایدها را ویرایش کنید، منابع را مدیریت کنید و آن را در قالب اصلی یا قالب پشتیبانی شده دیگر ذخیره کنید.

رفتار بارگذاری می‌تواند از طریق کلاس [LoadOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/) سفارشی شود. به عنوان مثال، می‌توانید یک گذرواژه باز کردن ارائه دهید، اشیاء باینری بزرگ را خارج از حافظه heap جاوا نگه دارید، منابع خارجی را کنترل کنید یا داده‌های باینری جاسازی‌شده را حذف کنید.

## **باز کردن ارائه‌ها**

برای باز کردن یک ارائه موجود، مسیر فایل آن را به سازنده [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) پاس بدهید. پس از استفاده، ارائه را آزاد کنید تا دسته‌های فایل، داده‌های موقت و سایر منابع به‌سرعت آزاد شوند.

مثال زیر در Python نشان می‌دهد چگونه یک ارائه را باز کنید و تعداد اسلایدهای آن را به‌دست آورید:

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

یک گذرواژه باز کردن محتویات ارائه را رمزگذاری می‌کند. برای بارگذاری کامل ارائه، گذرواژه صحیح را به [LoadOptions.setPassword](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setPassword) پاس بدهید و گزینه‌ها را به سازنده [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ارائه کنید. در صورت عدم وجود یا نادرست بودن گذرواژه، بارگذاری شکست می‌خورد.

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

برای تشخیص، اعتبارسنجی و جریان‌های کاری رمزگذاری گذرواژه، به [Password-Protect Presentations](/slides/fa/python-java/password-protected-presentation/) مراجعه کنید. اگر یک ارائه رمزگذاری‌شده عمداً با ویژگی‌های عمومی سند ذخیره شده باشد، می‌توان این ویژگی‌ها را بدون گذرواژه خواند؛ به [Manage Presentation Properties](/slides/fa/python-java/presentation-properties/) نگاه کنید.

## **باز کردن ارائه‌های بزرگ**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) گزینه‌هایی را برمی‌گرداند که کنترل می‌کند Aspose.Slides چگونه اشیاء باینری بزرگ مانند تصویرها، صدا و ویدیو را مدیریت کند. می‌توانید فایل منبع را قفل نگه دارید، اجازهٔ استفاده از فایل‌های موقت را بدهید و مقدار داده‌های BLOB نگهداری شده در حافظه را محدود کنید.

کد زیر در Python نشان می‌دهد چگونه یک ارائه بزرگ (به عنوان مثال ۲ گیگابایت) را بارگذاری کنید:

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
با استفاده از [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked)، فایل منبع تا زمانی که نمونهٔ ارائه آزاد نشود، قفل می‌ماند. هنگام زنده بودن آن نمونه، فایل منبع را جابه‌جا، بازنویسی یا حذف نکنید.

Aspose.Slides ممکن است محتویات یک جریان ورودی را هنگام بارگذاری کپی کند. برای ارائه‌های بزرگ، به‌طور کلی مسیر فایل نسبت به یک جریان کارآمدتر است. برای گزینه‌های اضافی ذخیره‌سازی و مدیریت حافظه، به [Manage BLOBs](/slides/fa/python-java/manage-blob/) مراجعه کنید.
{{% /alert %}}

## **کنترل منابع خارجی**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) یک پراکسی JPype که رابط فراخوانی بارگذاری منبع جاوا را پیاده‌سازی می‌کند، می‌پذیرد. این فراخوانی می‌تواند داده‌های جایگزین فراهم کند، منبعی را بازگردانی کند، از بارگذار پیش‌فرض استفاده کند یا منبع را نادیده بگیرد. این زمانی مفید است که ارائه‌ها شامل تصویرهای خارجی باشند که باید بر اساس قوانین امنیتی یا ذخیره‌سازی مخصوص به برنامه حل شوند.

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

یک ارائه ممکن است حاوی داده‌های باینری جاسازی‌شده باشد که برنامه به آن نیازی ندارد یا نمی‌خواهد نگه دارد. نمونه‌ها شامل:

- پروژه‌های VBA، قابل دسترسی از طریق [Presentation.getVbaProject](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getVbaProject);
- داده‌های OLE جاسازی‌شده، قابل دسترسی از طریق [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- داده‌های کنترل ActiveX، قابل دسترسی از طریق [Control.getActiveXControlBinary](https://reference.aspose.com/slides/fa/python-java/aspose.slides/control/#getActiveXControlBinary).

برای حذف این داده‌های باینری هنگام بارگذاری، [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) را روی `True` تنظیم کنید. ارائه بارگذاری‌شده را ذخیره کنید تا نتیجهٔ پاک‌سازی شده حفظ شود.

این گزینه در معرض شدن به بارهای جاسازی‌شده نامطلوب را کاهش می‌دهد، اما یک سیستم کامل تشخیص بدافزار یا پاک‌سازی محتوا نیست.

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

Aspose.Slides هنگام بارگذاری یک استثنا مربوط به تجزیه یا فرمت پرتاب می‌کند. این شکست را به‌صورت جداگانه از خطای گذرواژه نادرست مدیریت کنید تا برنامه بتواند علت را به‌دقت گزارش دهد.

**چه اتفاقی می‌افتد اگر قلم‌های مورد نیاز موجود نباشند؟**

ارائه ممکن است همچنان بارگذاری شود، اما رندرینگ و صادرات ممکن است قلم‌ها را جایگزین کنند. می‌توانید [پیکربندی جایگزینی قلم](/slides/fa/python-java/font-substitution/) یا [ارائه قلم‌های سفارشی](/slides/fa/python-java/custom-font/) را تنظیم کنید تا خروجی قابل پیش‌بینی‌تر باشد.

**آیا بارگذاری یک ارائه همچنین رسانه‌های جاسازی‌شده آن را بارگذاری می‌کند؟**

صدا و ویدئوی جاسازی‌شده از طریق مدل شیء ارائه در دسترس قرار می‌گیرند. منابع خارجی بر اساس رفتار بارگذاری منبع پیکربندی‌شده حل می‌شوند و ممکن است در صورت عدم امکان دسترسی به مکان‌های آنها در دسترس نباشند.