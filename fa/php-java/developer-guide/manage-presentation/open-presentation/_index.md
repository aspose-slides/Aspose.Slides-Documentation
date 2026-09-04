---
title: باز کردن ارائه‌ها در PHP
linktitle: باز کردن ارائه
type: docs
weight: 20
url: /fa/php-java/open-presentation/
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
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه ارائه‌های PowerPoint و OpenDocument را در PHP باز کنید، رمزهای عبور باز کردن را ارائه دهید، بارگذاری منابع را کنترل کنید و استفاده از حافظه را با Aspose.Slides برای PHP از طریق Java کاهش دهید."
---
## **معرفی**

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/fa/php-java/) می‌تواند ارائه‌های PowerPoint و OpenDocument را از فایل‌ها و جریان‌ها بارگذاری کند. پس از بارگذاری یک ارائه، می‌توانید ساختار آن را بررسی کنید، اسلایدها را ویرایش کنید، منابع را مدیریت کنید و آن را در فرمت اصلی یا فرمت پشتیبانی‌شده دیگر ذخیره کنید.

رفتار بارگذاری می‌تواند از طریق کلاس [LoadOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/) سفارشی شود. به عنوان مثال، می‌توانید یک رمز عبور باز کردن ارائه دهید، اشیاء باینری بزرگ را خارج از حافظه heap جاوا نگه دارید، منابع خارجی را کنترل کنید یا داده‌های باینری جاسازی‌شده را حذف کنید.

## **باز کردن ارائه‌ها**

برای باز کردن یک ارائه موجود، مسیر فایل آن را به سازنده [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) پاس دهید. پس از استفاده، ارائه را آزاد کنید تا دستگیره‌های فایل، داده‌های موقت و سایر منابع به‌سرعت آزاد شوند.

مثال زیر PHP نشان می‌دهد که چگونه یک ارائه را باز کنید و تعداد اسلایدهای آن را دریافت کنید:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **باز کردن ارائه‌های دارای رمز عبور**

یک رمز عبور باز کردن، محتویات ارائه را رمزنگاری می‌کند. برای بارگذاری کامل ارائه، رمز عبور صحیح را به [LoadOptions::setPassword](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/#setPassword) پاس دهید و گزینه‌ها را به سازنده [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ارائه کنید. در صورتی که رمز عبور وجود نداشته باشد یا نادرست باشد، بارگذاری ناموفق می‌شود.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-presentation.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

برای کشف، اعتبارسنجی و روندهای رمزنگاری رمز عبور، به [Password-Protect Presentations](/slides/fa/php-java/password-protected-presentation/) مراجعه کنید. اگر یک ارائه رمزگذاری‌شده عمداً با ویژگی‌های سند عمومی ذخیره شده باشد، می‌توان این ویژگی‌ها را بدون رمز عبور خواند؛ به [Manage Presentation Properties](/slides/fa/php-java/presentation-properties/) نگاه کنید.

## **باز کردن ارائه‌های بزرگ**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) گزینه‌هایی را برمی‌گرداند که کنترل می‌کند Aspose.Slides چگونه اشیاء بزرگ باینری مانند تصاویر، صدا و ویدیو را مدیریت می‌کند. می‌توانید فایل منبع را قفل نگه دارید، فایل‌های موقت را اجازه دهید و مقدار داده‌های BLOB نگهداری‌شده در حافظه را محدود کنید.

کد زیر PHP نشان می‌دهد که چگونه یک ارائه بزرگ (به عنوان مثال ۲ گیگابایت) را بارگذاری کنید:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationLockingBehavior;
use aspose\slides\SaveFormat;

$filePath = "large-presentation.pptx";

$loadOptions = new LoadOptions();
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024);

$presentation = new Presentation($filePath, $loadOptions);
try {
    $presentation->getSlides()->get_Item(0)->setName("Large presentation");
    $presentation->save("large-presentation-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="نکته" %}}
با استفاده از [PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked)، فایل منبع تا زمان آزاد شدن نمونه ارائه قفل می‌ماند. تا زمانی که آن نمونه زنده است، فایل منبع را جابجا، بازنویسی یا حذف نکنید.

Aspose.Slides ممکن است محتوای یک جریان ورودی را هنگام بارگذاری کپی کند. برای ارائه‌های بزرگ، مسیر فایل به‌طور کلی کارآمدتر از یک جریان است. برای گزینه‌های اضافی ذخیره‌سازی و مدیریت حافظه، به [Manage BLOBs](/slides/fa/php-java/manage-blob/) مراجعه کنید.
{{% /alert %}}

## **کنترل منابع خارجی**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) یک پیاده‌سازی از رابط Java [IResourceLoadingCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iresourceloadingcallback/) را از طریق PHP/Java Bridge می‌پذیرد. این callback می‌تواند داده‌های جایگزین فراهم کند، منبعی را بازگردانی کند، از لودر پیش‌فرض استفاده کند یا منبع را نادیده بگیرد. این زمانی مفید است که ارائه‌ها شامل تصاویر خارجی باشند که باید بر اساس قوانین امنیتی یا ذخیره‌سازی مخصوص برنامه حل شوند.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ResourceLoadingAction;

class ImageLoadingHandler {
    function resourceLoading($args) {
        $originalUri = strtolower(java_values($args->getOriginalUri()));
        $approvedImagePath = "approved-image.jpg";
        $isJpeg = substr($originalUri, -4) === ".jpg";

        if (!$isJpeg || !file_exists($approvedImagePath)) {
            return ResourceLoadingAction::Skip;
        }

        $imageData = file_get_contents($approvedImagePath);
        if ($imageData === false) {
            echo("The approved replacement image could not be read.\n");
            return ResourceLoadingAction::Skip;
        }

        $args->setData(java_values($imageData));
        return ResourceLoadingAction::UserProvided;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("presentation-with-external-images.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **بارگذاری ارائه‌ها بدون اشیاء باینری جاسازی‌شده**

یک ارائه ممکن است حاوی داده‌های باینری جاسازی‌شده باشد که یک برنامه به آن نیاز ندارد یا نمی‌خواهد آن را نگه دارد. مثال‌ها شامل:

- پروژه‌های VBA، که از طریق [Presentation::getVbaProject](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getVbaProject) در دسترس هستند؛
- داده‌های OLE جاسازی‌شده، که از طریق [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/fa/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) در دسترس هستند؛
- داده‌های کنترل ActiveX، که از طریق [Control::getActiveXControlBinary](https://reference.aspose.com/slides/fa/php-java/aspose.slides/control/#getActiveXControlBinary) در دسترس هستند.

برای حذف این داده‌های باینری هنگام بارگذاری، [LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) را به `true` تنظیم کنید. ارائه بارگذاری‌شده را ذخیره کنید تا نتیجه تصفیه‌شده حفظ شود.

این گزینه خطر مواجهه با بارهای جاسازی‌شده ناخواسته را کاهش می‌دهد، اما یک سیستم کامل شناسایی بدافزار یا تصفیه محتوا نیست.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("presentation-with-embedded-data.pptx", $loadOptions);
try {
    $presentation->save("presentation-without-embedded-data.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **سوالات متداول**

**چگونه می‌توانم تشخیص دهم که یک فایل خراب است و نمی‌تواند باز شود؟**

Aspose.Slides در هنگام بارگذاری یک استثنای تجزیه یا قالب پرتاب می‌کند. این شکست را جدا از خطای رمز عبور نادرست مدیریت کنید تا برنامه بتواند علت را به‌دقت گزارش دهد.

**اگر فونت‌های مورد نیاز موجود نباشند چه می‌شود؟**

ارائه همچنان می‌تواند بارگذاری شود، اما رندر و خروجی ممکن است فونت‌ها را جایگزین کند. می‌توانید [configure font substitution](/slides/fa/php-java/font-substitution/) یا [provide custom fonts](/slides/fa/php-java/custom-font/) را تنظیم کنید تا خروجی پیش‌بینی‌پذیرتر باشد.

**آیا بارگذاری یک ارائه، رسانه‌های جاسازی‌شده آن را نیز بارگذاری می‌کند؟**

صدا و ویدیوهای جاسازی‌شده از طریق مدل شیء ارائه قابل دسترسی می‌شوند. منابع خارجی بر اساس رفتار تنظیم‌شده بارگذاری منابع حل می‌شوند و ممکن است اگر مکان‌های آن‌ها قابل دسترسی نباشد، در دسترس نباشند.