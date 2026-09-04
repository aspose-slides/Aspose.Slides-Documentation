---
title: حفاظت از ارائه‌ها با رمز عبور در PHP
linktitle: محافظت رمز عبور
type: docs
weight: 20
url: /fa/php-java/password-protected-presentation/
keywords:
- ارائه‌ی محافظت‌شده با رمز عبور
- رمز عبور باز کردن
- رمزنگاری PowerPoint
- رمزگشایی PowerPoint
- اعتبارسنجی رمز عبور ارائه
- بررسی رمز عبور ارائه
- باز کردن ارائه‌ی رمزنگاری‌شده
- حذف رمزنگاری
- PowerPoint
- PPT
- PPTX
- ارائه
- PHP
- Aspose.Slides
description: "رمزنگاری، تشخیص، اعتبارسنجی، باز کردن و رمزگشایی ارائه‌های PowerPoint PPT و PPTX محافظت‌شده با رمز عبور در PHP با Aspose.Slides."
---
## **نمای کلی**

یک رمز عبور باز کردن یک ارائه را رمزنگاری می‌کند. برای بارگذاری و مشاهده محتوای ارائه، رمز عبور صحیح لازم است، بنابراین این محافظت محرمانگی را فراهم می‌کند.

رمز عبور باز کردن متفاوت از رمز عبور حفاظت نوشتنی است. حفاظت نوشتنی اجازه اصلاح را محدود می‌کند اما محتوا را رمزنگاری نمی‌کند و ارائه را از بارگذاری منع نمی‌کند. برای مدیریت رمزهای عبور جهت اصلاح ارائه‌ها، به [Write-Protect Presentations](/slides/fa/php-java/write-protected-presentation/) مراجعه کنید.

روال‌های زیر برای ارائه‌های PPT و PPTX هر دو اعمال می‌شوند. مثال‌ها از هر دو فرمت استفاده می‌کنند، جایی که رفتار مبتنی بر فایل و مبتنی بر جریان مهم است.

## **رمزنگاری یک ارائه با رمز عبور باز کردن**

از [ProtectionManager::encrypt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/protectionmanager/#encrypt) برای اختصاص رمز عبور باز کردن استفاده کنید. سپس از [Presentation::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#save) برای ذخیرهٔ ارائهٔ رمزنگاری‌شده استفاده کنید.

مثال زیر یک ارائهٔ PPTX را رمزنگاری می‌کند:

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

## **حفظ عمومی خصوصیات سند**

به‌صورت پیش‌فرض، Aspose.Slides خصوصیات سند را در رمزنگاری ارائه گنجانده است. متد [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) این رفتار را به‌صورت مستقل از رمزنگاری محتوای اسلاید کنترل می‌کند. قبل از فراخوانی [ProtectionManager::encrypt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/protectionmanager/#encrypt) مقدار `false` را ارسال کنید وقتی یک سامانهٔ فهرست‌سازی، طبقه‌بندی، جستجو یا مدیریت اسناد باید بدون رمز عبور باز کردن، فراداده‌ها را بخواند.

مثال زیر یک ارائهٔ PPTX رمزنگاری‌شده ایجاد می‌کند در حالی که خصوصیات سند داخلی آن عمومی باقی می‌مانند:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $properties = $presentation->getDocumentProperties();
    $properties->setAuthor("Contoso Knowledge Management");
    $properties->setTitle("Quarterly Product Roadmap");
    $properties->setKeywords("roadmap, planning, internal");

    $presentation->getSlides()->get_Item(0)->setName("Encrypted presentation content");
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("public-properties-encrypted.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ارسال مقدار `false` به [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) اسلایدها، مسترها، چیدمان‌ها، اشکال، رسانه‌ها یا سایر محتوای ارائه را عمومی نمی‌کند. این فقط بر خصوصیات سند تأثیر می‌گذارد. برای خواندن آن خصوصیات بدون بارگذاری محتوای رمزنگاری‌شده، به [Manage Presentation Properties](/slides/fa/php-java/presentation-properties/) مراجعه کنید.

## **بارگذاری یک ارائهٔ رمزنگاری‌شده**

مقدار [LoadOptions::setPassword](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/#setPassword) را برابر با رمز عبور باز کردن تنظیم کنید و هنگام بارگذاری فایل، این گزینه‌ها را به [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) پاس دهید. بارگذاری زمانی که رمز عبور باز کردن لازم است اما رمز ارائه‌شده موجود نیست یا نادرست است، با شکست مواجه می‌شود.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # با ارائهٔ رمزگشایی‌شده کار کنید.
} finally {
    $presentation->dispose();
}
```

## **حذف رمزنگاری از یک ارائه**

ارائه را با رمز عبور باز کردن خود بارگذاری کنید، [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/fa/php-java/aspose.slides/protectionmanager/#removeEncryption) را فراخوانی کنید و نتیجه را ذخیره کنید. ارائهٔ ذخیره‌شده سپس می‌تواند بدون رمز عبور بارگذاری شود.

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

## **اعتبارسنجی رمز عبور باز کردن قبل از بارگذاری**

از [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationfactory/#getPresentationInfo) برای دریافت [PresentationInfo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/) بدون ایجاد یک نمونه کامل از ارائه استفاده کنید. قبل از درخواست یا اعتبارسنجی رمز عبور، [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#isPasswordProtected) را بررسی کنید. وقتی حفاظت موجود باشد، مقدار ارائه‌شده را با [PresentationInfo::checkPassword](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#checkPassword) اعتبارسنجی کنید.

### **روال مسیر فایل**

مثال زیر رمز عبور باز کردن را برای یک فایل PPTX اعتبارسنجی می‌کند، مقدار اعتبارسنجی‌شده را به [LoadOptions::setPassword](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/#setPassword) پاس می‌دهد و سپس ارائهٔ کامل را بارگذاری می‌کند:

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

نسخهٔ جریان‌وار [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationfactory/#getPresentationInfo) همان روال را فراهم می‌کند. قبل از بارگذاری ارائهٔ کامل از آن جریان، موقعیت یک جریان قابل جستجو را بازنشانی کنید.

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

### **مقادیر بازگشتی checkPassword**

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#checkPassword) فقط زمانی که ارائه دارای رمز عبور باز کردن باشد و رمز ارائه‌شده صحیح باشد، مقدار `true` برمی‌گرداند. در هر یک از موارد زیر مقدار `false` برمی‌گردد:

- رمز عبور نادرست است.
- ارائه رمز عبور باز کردن ندارد.
- رمز عبور ارائه‌شده `null` یا خالی است.

این رفتار برای ارائه‌های PPT و PPTX یکسان است.

## **بررسی این که آیا یک ارائهٔ بارگذاری‌شده رمزنگاری شده است**

بعد از بارگذاری یک ارائه با رمز عبور صحیح، [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/fa/php-java/aspose.slides/protectionmanager/#isEncrypted) را بررسی کنید تا تأیید کنید که ارائهٔ منبع رمزنگاری شده است. برای کشف حفاظت رمز عبور باز کردن قبل از بارگذاری، همان‌طور که در بالا نشان داده شد، از [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#isPasswordProtected) استفاده کنید.

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
رمزهای عبور باز کردن را در لاگ‌ها ثبت نکنید یا در پیام‌های تشخیصی گنجانش ندهید. از تلاش‌های تکراری و غیرضروری برای اعتبارسنجی خودداری کنید، رمزها را در حافظه تنها به مدت نیاز نگه دارید و نتیجهٔ موفق اعتبارسنجی را هنگام بارگذاری فوری ارائه، مجدداً استفاده کنید.

خصوصیات عمومی سند ممکن است علیرغم رمزنگاری محتوای ارائه، نام نویسندگان، عناوین، موضوعات، کلمات کلیدی، اطلاعات شرکت، نظرات و مقادیر سفارشی را فاش کنند. متادیتای حساس را همراه با ارائه رمزنگاری کنید. نگه‌داشتن خصوصیات به‌صورت عمومی باید تصمیمی صریح باشد که تنها زمانی اتخاذ می‌شود که سیستم‌ها باید بدون رمز عبور باز کردن، فایل را فهرست، طبقه‌بندی، جستجو یا مدیریت کنند.
{{% /alert %}}

## **رمزگذاری یک ارائه به‌صورت آنلاین**

1. برنامهٔ [Aspose.Slides Lock](https://products.aspose.app/slides/fa/lock) را باز کنید.
1. ارائه را انتخاب یا بارگذاری کنید.
1. رمز عبوری برای حفاظت نمایش وارد کنید.
1. به‌اختیار، رمز عبور جداگانه‌ای برای حفاظت ویرایش وارد کنید.
1. حفاظت را اعمال کنید و فایل حاصل را دانلود نمایید.

{{% alert color="info" title="See also" %}}
- [حفاظت نوشتنی از ارائه‌ها](/slides/fa/php-java/write-protected-presentation/)
- [امضای دیجیتال در پاورپوینت](/slides/fa/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**تفاوت بین رمز عبور باز کردن و رمز عبور حفاظت نوشتنی چیست؟**

یک رمز عبور باز کردن، ارائه را رمزنگاری می‌کند و برای بارگذاری محتوای آن لازم است. یک رمز عبور حفاظت نوشتنی، اجازه اصلاح را محدود می‌کند بدون اینکه محتوا را رمزنگاری کند.

**آیا می‌توانم رمز عبور باز کردن را بدون بارگذاری تمام اسلایدها اعتبارسنجی کنم؟**

بله. اطلاعات ارائه را به دست آورید، بررسی کنید آیا حفاظت رمز عبور باز کردن وجود دارد یا نه، و قبل از ایجاد یک نمونه کامل از ارائه، رمز عبور را اعتبارسنجی کنید.

**آیا یک برنامه می‌تواند متادیتا را بدون رمز عبور باز کردن بخواند؟**

بله، اما فقط زمانی که ارائه با غیرفعال کردن رمزنگاری خصوصیات سند رمزنگاری شده باشد. در این صورت برنامه باید از حالت بارگذاری فقط‑خصوصیات‑سند که در [Manage Presentation Properties](/slides/fa/php-java/presentation-properties/) توضیح داده شده است، استفاده کند.

**آیا روندهای بررسی رمز عبور هم برای PPT و هم برای PPTX پشتیبانی می‌شود؟**

بله. تشخیص و اعتبارسنجی رمز عبور بر پایه مسیر فایل و بر پایه جریان، برای ارائه‌های PPT و PPTX به‌طور یکسان رفتار می‌کنند.