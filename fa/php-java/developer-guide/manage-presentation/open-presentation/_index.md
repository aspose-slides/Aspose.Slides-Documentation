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
- شیء دودویی
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه ارائه‌های PowerPoint و OpenDocument را در PHP باز کنید، رمزهای عبور باز کردن را فراهم کنید، بارگذاری منابع را کنترل کنید و با Aspose.Slides برای PHP از طریق Java مصرف حافظه را کاهش دهید."
---
## **معرفی**

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/fa/php-java/) می‌تواند ارائه‌های PowerPoint و OpenDocument را از فایل‌ها و جریان‌ها بارگذاری کند. پس از بارگذاری یک ارائه، می‌توانید ساختار آن را بررسی کنید، اسلایدها را ویرایش کنید، منابع را مدیریت کنید و آن را در قالب اصلی یا قالب پشتیبانی‌شده دیگر ذخیره کنید.

رفتار بارگذاری می‌تواند از طریق کلاس [LoadOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/) سفارشی شود. به عنوان مثال، می‌توانید رمز عبور باز کردن را فراهم کنید، اشیاء دودویی بزرگ را خارج از حافظه heap جاوا نگه دارید، منابع خارجی را کنترل کنید یا داده‌های دودویی جاسازی‌شده را حذف کنید.

## **باز کردن ارائه‌ها**

پس از بارگذاری یک فایل یا جریان، می‌توانید [فرمت اصلی ارائه را تعیین کنید](/slides/fa/php-java/detect-presentation-source-format/) تا انتخاب کنید برنامه شما چگونه آن را پردازش می‌کند.

برای باز کردن یک ارائه موجود، مسیر فایل آن را به سازنده [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) پاس دهید. پس از استفاده ارائه را آزاد (Dispose) کنید تا دستگیره‌های فایل، داده‌های موقت و سایر منابع به‌سرعت آزاد شوند.

کد مثال زیر به زبان PHP نشان می‌دهد چگونه یک ارائه را باز کنید و تعداد اسلایدهای آن را به دست آورید:

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

یک رمز عبور باز کردن، محتوای ارائه را رمزگذاری می‌کند. برای بارگذاری کامل ارائه، رمز صحیح را به [LoadOptions::setPassword](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/#setPassword) پاس دهید و گزینه‌ها را به سازنده [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ارائه کنید. در صورت عدم وجود یا نادرست بودن رمز عبور، بارگذاری شکست می‌خورد.

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

برای شناسایی رمز عبور، اعتبارسنجی و جریان‌های کاری رمزگذاری، به [Password-Protect Presentations](/slides/fa/php-java/password-protected-presentation/) مراجعه کنید. اگر یک ارائه رمزگذاری‌شده عمداً با ویژگی‌های عمومی سند ذخیره شده باشد، می‌توان این ویژگی‌ها را بدون رمز عبور خواند؛ به [Manage Presentation Properties](/slides/fa/php-java/presentation-properties/) نگاه کنید.

## **باز کردن ارائه‌های بزرگ**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) گزینه‌هایی را برمی‌گرداند که نحوهٔ مدیریت اشیاء دودویی بزرگ مانند تصویرها، صدا و ویدیو توسط Aspose.Slides را کنترل می‌کند. می‌توانید فایل منبع را قفل نگه دارید، فایل‌های موقت را مجاز کنید و میزان داده‌های BLOB نگهداری‌شده در حافظه را محدود کنید.

کد PHP زیر بارگذاری یک ارائه بزرگ (مثلاً ۲ گیگابایت) را نشان می‌دهد:

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

{{% alert color="info" title="Note" %}}
با استفاده از [PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked)، فایل منبع تا زمانی که نمونهٔ ارائه آزاد (disposed) شود، قفل می‌ماند. در حالی که آن نمونه زنده است، فایل منبع را جابجا، بازنویسی یا حذف نکنید.

Aspose.Slides ممکن است محتویات یک جریان ورودی را هنگام بارگذاری کپی کند. برای ارائه‌های بزرگ، مسیر فایل معمولاً نسبت به یک جریان کارایی بیشتری دارد. برای گزینه‌های اضافی ذخیره‌سازی و مدیریت حافظه به [Manage BLOBs](/slides/fa/php-java/manage-blob/) مراجعه کنید.
{{% /alert %}}

## **کنترل منابع خارجی**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) یک پیاده‌سازی از رابط Java [IResourceLoadingCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iresourceloadingcallback/) را از طریق PHP/Java Bridge می‌پذیرد. این Callback می‌تواند داده‌های جایگزین فراهم کند، یک منبع را مجدداً مسیربندی کند، از لودر پیش‌فرض استفاده کند یا منبع را نادیده بگیرد. این در مواردی مفید است که ارائه‌ها شامل تصویرهای خارجی باشند که باید بر اساس قوانین امنیتی یا ذخیره‌سازی خاص برنامه حل شوند.

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

## **بارگذاری ارائه‌ها بدون اشیاء دودویی جاسازی‌شده**

یک ارائه ممکن است شامل داده‌های دودویی جاسازی‌شده باشد که برنامه به آن نیازی ندارد یا نمی‌خواهد نگه دارد. مثال‌ها شامل:

- پروژه‌های VBA، که از طریق [Presentation::getVbaProject](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getVbaProject) در دسترس هستند؛
- داده‌های OLE جاسازی‌شده، که از طریق [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/fa/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) در دسترس هستند؛
- داده‌های کنترل ActiveX، که از طریق [Control::getActiveXControlBinary](https://reference.aspose.com/slides/fa/php-java/aspose.slides/control/#getActiveXControlBinary) در دسترس هستند.

با تنظیم [LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) به `true`، این داده‌های دودویی هنگام بارگذاری حذف می‌شوند. برای حفظ نتیجهٔ پاک‌سازی‌شده، ارائه بارگذاری‌شده را ذخیره کنید.

این گزینه خطر نمایش محتوای جاسازی‌شدهٔ ناخواسته را کاهش می‌دهد، اما یک سیستم کامل تشخیص مخرب یا پاک‌سازی محتوا نیست.

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

## **سؤال‌های متداول**

**چگونه می‌توانم بفهمم که یک فایل خراب است و نمی‌تواند باز شود؟**

Aspose.Slides هنگام بارگذاری یک استثنای تجزیه یا فرمت پرتاب می‌کند. این شکست را جدا از خطای غلط بودن رمز عبور مدیریت کنید تا برنامه بتواند دلیل را به‌دقت گزارش دهد.

**اگر قلم‌های مورد نیاز موجود نباشند چه اتفاقی می‌افتد؟**

ارائه هنوز می‌تواند بارگذاری شود، اما رندر و خروجی ممکن است قلم‌ها را جایگزین کند. می‌توانید [پیکربندی جایگزینی قلم](/slides/fa/php-java/font-substitution/) یا [ارائه قلم‌های سفارشی](/slides/fa/php-java/custom-font/) را تنظیم کنید تا خروجی پیش‌بینی‌پذیرتر باشد.

**آیا بارگذاری یک ارائه همچنین رسانه‌های جاسازی‌شده آن را بارگذاری می‌کند؟**

صدا و ویدیوهای جاسازی‌شده از طریق مدل شیء ارائه در دسترس می‌شوند. منابع خارجی بر اساس رفتار پیکربندی‌شدهٔ بارگذاری منابع حل می‌شوند و ممکن است در صورتی که مکان‌هایشان قابل دسترسی نباشد، در دسترس نباشند.