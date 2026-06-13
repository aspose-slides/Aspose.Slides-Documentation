---
title: "باز کردن ارائه‌ها در PHP"
linktitle: "باز کردن ارائه"
type: docs
weight: 20
url: /fa/php-java/open-presentation/
keywords:
- "باز کردن پاورپوینت"
- "باز کردن OpenDocument"
- "باز کردن ارائه"
- "باز کردن PPTX"
- "باز کردن PPT"
- "باز کردن ODP"
- "بارگیری ارائه"
- "بارگیری PPTX"
- "بارگیری PPT"
- "بارگیری ODP"
- "ارائه محافظت‌شده"
- "ارائه بزرگ"
- "منبع خارجی"
- "شی باینری"
- PHP
- Aspose.Slides
description: "به‌راحتی ارائه‌های PowerPoint (.pptx، .ppt) و OpenDocument (.odp) را با Aspose.Slides برای PHP از طریق Java باز کنید — سریع، قابل اعتماد، کاملاً دارای ویژگی‌ها."
---
## **مقدمه**

فراتر از ایجاد ارائه‌های پاورپوینت از ابتدا، Aspose.Slides همچنین به شما امکان می‌دهد ارائه‌های موجود را باز کنید. پس از بارگذاری یک ارائه، می‌توانید اطلاعات مربوط به آن را بازیابی کنید، محتویات اسلاید را ویرایش کنید، اسلایدهای جدید اضافه کنید، اسلایدهای موجود را حذف کنید و موارد دیگر.

## **باز کردن ارائه‌ها**

برای باز کردن یک ارائه موجود، کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) را نمونه‌سازی کنید و مسیر فایل را به سازنده آن پاس دهید.

```php
// نمونه‌سازی کلاس Presentation و ارسال مسیر فایل به سازنده آن.
$presentation = new Presentation("Sample.pptx");
try {
    // نمایش تعداد کل اسلایدهای موجود در ارائه.
    echo($presentation->getSlides()->size());
} finally {
    $presentation->dispose();
}
```

## **باز کردن ارائه‌های محافظت‌شده با رمزعبور**

زمانی که نیاز به باز کردن یک ارائه محافظت‌شده با رمزعبور دارید، رمزعبور را از طریق متد [setPassword](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/#setPassword) کلاس [LoadOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/) پاس کنید تا رمزگشایی و بارگذاری شود. کد PHP زیر این عملیات را نشان می‌دهد:

```php
$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$presentation = new Presentation("Sample.pptx", $loadOptions);
try {
    // عملیات روی ارائه رمزگشایی‌شده را انجام دهید.
} finally {
    $presentation->dispose();
}
```

## **باز کردن ارائه‌های بزرگ**

Aspose.Slides گزینه‌هایی ارائه می‌دهد—به‌ویژه متد [getBlobManagementOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) در کلاس [LoadOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/)—تا به شما در بارگذاری ارائه‌های بزرگ کمک کند.

کد PHP زیر بارگذاری یک ارائه بزرگ (به‌عنوان مثال، ۲ گیگابایت) را نشان می‌دهد:

```php
$filePath = "LargePresentation.pptx";

$loadOptions = new LoadOptions();
// رفتار KeepLocked را انتخاب کنید—فایل ارائه برای مدت زمان عمر
// شی Presentation قفل می‌ماند، اما نیازی به بارگذاری در حافظه یا کپی به فایل موقت نیست.
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024); // ۱۰ مگابایت

$presentation = new Presentation($filePath, $loadOptions);
try {
    // ارائه بزرگ بارگذاری شده و می‌توان از آن استفاده کرد، در حالی که مصرف حافظه کم باقی می‌ماند.

    // تغییرات مورد نیاز در ارائه اعمال شود.
    $presentation->getSlides()->get_Item(0)->setName("Very large presentation");

    // ارائه را در فایل دیگری ذخیره کنید. در طول این عملیات مصرف حافظه کم می‌ماند.
    $presentation->save("LargePresentation-copy.pptx", SaveFormat::Pptx);
	
	// این کار را انجام ندهید! یک استثنای I/O ایجاد می‌شود زیرا فایل تا زمان آزاد شدن شی ارائه قفل است.
	//unlink($filePath);
} finally {
    $presentation->dispose();
}
// در اینجا انجامش مشکلی ندارد. فایل منبع دیگر توسط شی ارائه قفل نشده است.
unlink($filePath);
```

{{% alert color="info" title="Info" %}}
برای دور زدن برخی محدودیت‌ها هنگام کار با استریم‌ها، Aspose.Slides ممکن است محتوای یک استریم را کپی کند. بارگذاری یک ارائه بزرگ از استریم باعث کپی شدن ارائه می‌شود و می‌تواند سرعت بارگذاری را کم کند. بنابراین، زمانی که نیاز به بارگذاری یک ارائه بزرگ دارید، به‌شدت توصیه می‌کنیم از مسیر فایل ارائه به‌جای استریم استفاده کنید.

هنگام ایجاد ارائه‌ای که شامل اشیای بزرگ (ویدئو، صدا، تصاویر با وضوح بالا و غیره) باشد، می‌توانید از [مدیریت BLOB](/slides/fa/php-java/manage-blob/) برای کاهش مصرف حافظه استفاده کنید.
{{%/alert %}}

## **کنترل منابع خارجی**

Aspose.Slides رابط [IResourceLoadingCallback](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iresourceloadingcallback/) را فراهم می‌کند که به شما امکان مدیریت منابع خارجی را می‌دهد. کد PHP زیر نشان می‌دهد چگونه از رابط `IResourceLoadingCallback` استفاده کنید:

```php
class ImageLoadingHandler {
    function resourceLoading($args) {
        if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
            // بارگیری تصویر جایگزین.
			$bytes = file_get_contents("aspose-logo.jpg");
			$javaByteArray = java_values($bytes);
            $args->setData($javaByteArray);
            return ResourceLoadingAction::UserProvided;
        } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
            // تنظیم URL جایگزین.
            $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }
        // رد کردن تمام تصاویر دیگر.
        return ResourceLoadingAction::Skip;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("Sample.pptx", $loadOptions);
```

## **بارگذاری ارائه‌ها بدون اشیای باینری جاسازی‌شده**

یک ارائه پاورپوینت می‌تواند شامل انواع زیر از اشیای باینری جاسازی‌شده باشد:

- پروژه VBA (قابل دسترسی از طریق [Presentation.getVbaProject](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getVbaProject));
- داده‌های جاسازی‌شده شی OLE (قابل دسترسی از طریق [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/fa/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- داده‌های باینری کنترل ActiveX (قابل دسترسی از طریق [Control.getActiveXControlBinary](https://reference.aspose.com/slides/fa/php-java/aspose.slides/control/#getActiveXControlBinary)).

با استفاده از متد [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) می‌توانید یک ارائه را بدون هیچ‌یک از اشیای باینری جاسازی‌شده بارگذاری کنید.

این متد برای حذف محتوای باینری که ممکن است مخرب باشد مفید است. کد PHP زیر نشان می‌دهد چگونه یک ارائه را بدون هیچ محتوای باینری جاسازی‌شده بارگذاری کنید:

```php
$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("malware.ppt", $loadOptions);
try {
    // انجام عملیات روی ارائه.
} finally {
    $presentation->dispose();
}
```

## **سوالات متداّل**

**چگونه می‌توانم تشخیص دهم که یک فایل خراب است و نمی‌توان آن را باز کرد؟**

در هنگام بارگذاری، استثنای تجزیه/اعتبارسنجی فرمیت دریافت می‌کنید. چنین خطاهایی معمولاً به ساختار ZIP نامعتبر یا رکوردهای خراب پاورپوینت اشاره می‌کنند.

**چه واقع می‌شود اگر فونت‌های مورد نیاز هنگام باز کردن موجود نباشند؟**

فایل باز می‌شود، اما بعداً ممکن است در [رندر/خروجی](/slides/fa/php-java/convert-presentation/) فونت‌ها جایگزین شوند. برای جلوگیری از این‌موضوع می‌توانید [پیکربندی جایگزینی فونت‌ها](/slides/fa/php-java/font-substitution/) یا [اضافه کردن فونت‌های مورد نیاز](/slides/fa/php-java/custom-font/) به محیط زمان اجرا را انجام دهید.

**در مورد رسانه‌های جاسازی‌شده (ویدئو/صدا) هنگام باز کردن چه اتفاقی می‌افتد؟**

آنها به‌عنوان منابع ارائه در دسترس قرار می‌گیرند. اگر رسانه‌ها از طریق مسیرهای خارجی ارجاع داده شوند، اطمینان حاصل کنید این مسیرها در محیط شما قابل دسترسی‌اند؛ در غیر این صورت ممکن است در [رندر/خروجی](/slides/fa/php-java/convert-presentation/) رسانه‌ها حذف شوند.