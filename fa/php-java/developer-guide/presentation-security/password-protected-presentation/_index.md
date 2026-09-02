---
title: حفاظت از ارائه‌ها با رمز عبور در PHP
linktitle: حفاظت با رمز عبور
type: docs
weight: 20
url: /fa/php-java/password-protected-presentation/
keywords:
- ارائهٔ محافظت‌شده با رمز عبور
- رمز عبور باز کردن
- رمزگذاری پاورپوینت
- رمزگشایی پاورپوینت
- اعتبارسنجی رمز عبور ارائه
- بررسی رمز عبور ارائه
- باز کردن ارائهٔ رمزگذاری‌شده
- حذف رمزگذاری
- پاورپوینت
- PPT
- PPTX
- ارائه
- PHP
- Aspose.Slides
description: "رمزگذاری، شناسایی، اعتبارسنجی، باز کردن و رمزگشایی ارائه‌های پاورپوینت PPT و PPTX محافظت‌شده با رمز عبور در PHP با Aspose.Slides."
---
## **نمای کلی**

یک رمز عبور باز کردن، یک ارائه را رمزگذاری می‌کند. برای بارگذاری و مشاهده محتوای ارائه، رمز عبور صحیح لازم است، بنابراین این حفاظت قابلیت محرمانگی را فراهم می‌کند.

یک رمز عبور باز کردن متفاوت از رمز عبور محافظت نوشتاری است. محافظت نوشتاری تغییرات را محدود می‌کند اما محتوای ارائه را رمزگذاری نمی‌کند و از بارگذاری ارائه جلوگیری نمی‌کند. برای مدیریت رمزهای عبور جهت اصلاح ارائه‌ها، به [Write-Protect Presentations](/slides/fa/php-java/write-protected-presentation/) مراجعه کنید.

روال‌های زیر برای هر دو ارائهٔ PPT و PPTX اعمال می‌شوند. مثال‌ها از هر دو قالب استفاده می‌کنند در مواردی که رفتار مبتنی بر فایل و مبتنی بر جریان اهمیت دارد.

## **رمزگذاری یک ارائه با رمز عبور باز کردن**

از [ProtectionManager::encrypt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/protectionmanager/#encrypt) برای اختصاص یک رمز عبور باز کردن استفاده کنید. سپس از [Presentation::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#save) برای ذخیرهٔ ارائهٔ رمزگذاری شده استفاده کنید.

مثال زیر یک ارائهٔ PPTX را رمزگذاری می‌کند:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **بارگذاری یک ارائهٔ رمزگذاری شده**

با استفاده از [LoadOptions::setPassword](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/#setPassword) رمز عبور باز کردن را تنظیم کنید و هنگام بارگذاری فایل، گزینه‌ها را به [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) پاس بدهید. اگر رمز عبور باز کردن لازم باشد ولی رمز ارائه‌شده گم باشد یا نادرست باشد، بارگذاری با شکست مواجه می‌شود.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # کار با ارائهٔ رمزگشائی شده.
} finally {
    $presentation->dispose();
}
```

## **حذف رمزگذاری از یک ارائه**

ارائه را با رمز عبور باز کردن آن بارگذاری کنید، [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/fa/php-java/aspose.slides/protectionmanager/#removeEncryption) را فراخوانی کنید و نتیجه را ذخیره کنید. پس از ذخیره، می‌توان ارائهٔ ذخیره‌شده را بدون رمز عبور بارگذاری کرد.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **اعتبارسنجی رمز عبور باز کردن پیش از بارگذاری**

از [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationfactory/#getPresentationInfo) برای دریافت [PresentationInfo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/) بدون ایجاد یک نمونهٔ کامل ارائه استفاده کنید. قبل از درخواست یا اعتبارسنجی رمز عبور، [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#isPasswordProtected) را بررسی کنید. هنگامی که حفاظت وجود دارد، مقدار ارائه‌شده را با [PresentationInfo::checkPassword](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#checkPassword) اعتبارسنجی کنید.

### **روال مسیر فایل**

مثال زیر یک رمز عبور باز کردن را برای یک فایل PPTX اعتبارسنجی می‌کند، مقدار اعتبارسنجی‌شده را به [LoadOptions::setPassword](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/#setPassword) پاس می‌دهد و سپس ارائهٔ کامل را بارگذاری می‌کند:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$filePath = "protected-presentation.pptx";
$password = "open_password";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);

if (!$presentationInfo->isPasswordProtected()) {
    echo("The presentation does not have an opening password.\n");
} elseif (!$presentationInfo->checkPassword($password)) {
    echo("The opening password is incorrect.\n");
} else {
    $loadOptions = new LoadOptions();
    $loadOptions->setPassword($password);

    $presentation = new Presentation($filePath, $loadOptions);
    try {
        echo("The presentation was validated and loaded successfully.\n");
    } finally {
        $presentation->dispose();
    }
}
```

### **روال جریان**

بارگذاری جریان از [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationfactory/#getPresentationInfo) همان روال را فراهم می‌کند. قبل از بارگذاری ارائهٔ کامل از آن جریان، موقعیت یک جریان قابل جستجو را بازنشانی کنید.

مثال زیر از یک فایل PPT استفاده می‌کند:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$password = "open_password";

$presentationStream = new Java("java.io.FileInputStream", "protected-presentation.ppt");
try {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($presentationStream);

    if (!$presentationInfo->isPasswordProtected()) {
        echo("The presentation does not have an opening password.\n");
    } elseif (!$presentationInfo->checkPassword($password)) {
        echo("The opening password is incorrect.\n");
    } else {
        $presentationStream->getChannel()->position(0);

        $loadOptions = new LoadOptions();
        $loadOptions->setPassword($password);

        $presentation = new Presentation($presentationStream, $loadOptions);
        try {
            echo("The presentation was validated and loaded successfully.\n");
        } finally {
            $presentation->dispose();
        }
    }
} finally {
    $presentationStream->close();
}
```

### **مقادیر برگشتی checkPassword**

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#checkPassword) تنها زمانی که ارائه یک رمز عبور باز کردن داشته باشد و رمز ارائه‌شده صحیح باشد، مقدار `true` را برمی‌گرداند. در هر یک از موارد زیر مقدار `false` برگردانده می‌شود:

- رمز عبور نادرست است.
- ارائه رمز عبور باز کردن ندارد.
- رمز عبور ارائه‌شده `null` یا خالی است.

رفتار برای ارائه‌های PPT و PPTX یکسان است.

## **بررسی اینکه آیا یک ارائه بارگذاری‌شده رمزگذاری شده است**

پس از بارگذاری یک ارائه با رمز عبور صحیح، [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/fa/php-java/aspose.slides/protectionmanager/#isEncrypted) را بررسی کنید تا تأیید کنید که ارائهٔ مبدا رمزگذاری شده است. برای شناسایی حفاظت با رمز عبور باز کردن پیش از بارگذاری، همانند بالا از [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#isPasswordProtected) استفاده کنید.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
    echo("The presentation is encrypted: " . ($isEncrypted ? "true" : "false") . "\n");
} finally {
    $presentation->dispose();
}
```

## **توصیه‌های امنیتی**

{{% alert color="warning" title="Security" %}}
رمزهای عبور باز کردن را در لاگ ثبت نکنید یا در پیام‌های تشخیصی گنجانده نشوند. از تلاش‌های مکرر و غیرضروری برای اعتبارسنجی جلوگیری کنید، رمزهای عبور را در حافظه فقط تا زمانی که نیاز است نگه دارید و پس از یک اعتبارسنجی موفق، نتیجهٔ آن را هنگام بارگذاری فوری ارائه دوباره استفاده کنید.
{{% /alert %}}

## **حافظت از یک ارائه با رمز عبور به صورت آنلاین**

1. برنامهٔ [Aspose.Slides Lock](https://products.aspose.app/slides/fa/lock) را باز کنید.
1. ارائه را انتخاب یا بارگذاری کنید.
1. رمز عبوری برای محافظت از نمایش وارد کنید.
1. در صورت نیاز، رمز عبور جداگانه‌ای برای محافظت از ویرایش وارد کنید.
1. حفاظت را اعمال کنید و فایل حاصل را دانلود کنید.

{{% alert color="info" title="See also" %}}
- [محافظت نوشتاری از ارائه‌ها](/slides/fa/php-java/write-protected-presentation/)
- [امضای دیجیتال در پاورپوینت](/slides/fa/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **پرسش‌های متداول**

**تفاوت رمز عبور باز کردن با رمز عبور محافظت نوشتاری چیست؟**

یک رمز عبور باز کردن ارائه را رمزگذاری می‌کند و برای بارگذاری محتوای آن لازم است. یک رمز عبور محافظت نوشتاری تغییرات را محدود می‌کند بدون اینکه محتوا را رمزگذاری کند.

**آیا می‌توانم یک رمز عبور باز کردن را بدون بارگذاری تمام اسلایدها اعتبارسنجی کنم؟**

بله. اطلاعات ارائه را دریافت کنید، بررسی کنید آیا حفاظت با رمز عبور باز کردن وجود دارد یا نه، و قبل از ایجاد یک نمونهٔ کامل از ارائه، رمز عبور را اعتبارسنجی کنید.

**آیا روال‌های بررسی رمز عبور برای هر دو PPT و PPTX پشتیبانی می‌شوند؟**

بله. شناسایی و اعتبارسنجی رمز عبور بر مبنای مسیر فایل و جریان برای هر دو ارائهٔ PPT و PPTX به‌صورت یکسان عمل می‌کند.