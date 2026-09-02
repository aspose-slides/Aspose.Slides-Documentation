---
title: محافظت نوشتاری ارائه‌ها در PHP
linktitle: حفاظت نوشتاری
type: docs
weight: 25
url: /fa/php-java/write-protected-presentation/
keywords:
- حفاظت نوشتاری
- محافظت نوشتاری PowerPoint
- رمز عبور برای تغییر
- محدود کردن ویرایش ارائه
- حذف حفاظت نوشتاری
- اعتبارسنجی رمز عبور تغییر
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "تنظیم، شناسایی، اعتبارسنجی و حذف رمزهای عبور حفاظت نوشتاری در ارائه‌های PowerPoint PPT و PPTX با استفاده از Aspose.Slides برای PHP."
---
## **مقدمه**

رمز عبور حفاظت نوشتاری، تغییرات ارائه را محدود می‌کند اما محتوای آن را رمزنگاری نمی‌کند. کاربران می‌توانند یک ارائه محافظت‌شده توسط نوشتار را بدون رمز عبور بارگیری و مشاهده کنند. بسته به برنامه، ممکن است قادر به ویرایش محتوا و ذخیره آن با نام متفاوت نیز باشند، بنابراین حفاظت نوشتاری نباید به‌عنوان یک مکانیزم محرمانگی در نظر گرفته شود.

یک رمز عبور باز کردن هدف متفاوتی دارد: ارائه را رمزنگاری می‌کند و برای بارگیری محتوای آن لازم است. برای رمزنگاری یک ارائه یا اعتبارسنجی رمز عبور باز کردن، به [Password-Protect Presentations](/slides/fa/php-java/password-protected-presentation/) مراجعه کنید.

جریان‌های کاری در این مقاله برای ارائه‌های PPT و PPTX هر دو اعمال می‌شود. مثال‌ها از فایل‌های PPTX استفاده می‌کنند؛ هنگام ذخیره به PPT، از پسوند `.ppt` و قالب ذخیره‌سازی PPT مربوطه استفاده کنید.

## **تنظیم حفاظت نوشتاری بر روی یک ارائه**

از [ProtectionManager::setWriteProtection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/protectionmanager/#setWriteProtection) برای اختصاص یک رمز عبور جهت تغییر یک ارائه استفاده کنید. ذخیرهٔ ارائه تنظیمات حفاظت را نگه می‌دارد.

مثال زیر حفاظت نوشتاری را بر روی یک ارائه PPTX تنظیم می‌کند:
```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->setWriteProtection("modify_password");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **بارگیری یک ارائه محافظت‌شده نوشتاری**

از آنجا که حفاظت نوشتاری محتوای ارائه را رمزنگاری نمی‌کند، برای بارگیری ارائه نیازی به رمز عبور نیست. رمز عبور فقط زمانی مربوط است که اعتبارسنجی مجوز تغییر ارائهٔ محافظت‌شده انجام می‌شود.
```php
use aspose\slides\Presentation;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    echo("Slide count: " . $presentation->getSlides()->size() . "\n");
} finally {
    $presentation->dispose();
}
```

رمز عبور حفاظت نوشتاری را به [LoadOptions::setPassword](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/#setPassword) پاس ندهید. این متد یک رمز عبور باز کردن برای محتوای رمزنگاری‌شده را می‌پذیرد. اگر یک ارائه هر دو نوع حفاظت را داشته باشد، برای بارگیری آن رمز عبور باز کردن را فراهم کنید و رمز عبور حفاظت نوشتاری را به‌صورت جداگانه مدیریت کنید.

## **حذف حفاظت نوشتاری از یک ارائه**

از [ProtectionManager::removeWriteProtection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/protectionmanager/#removeWriteProtection) برای حذف محدودیت تغییر استفاده کنید، سپس ارائه را ذخیره کنید.
```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **بررسی اینکه آیا یک ارائه محافظت نوشتاری دارد یا نه**

برای بررسی یک فایل بدون ایجاد یک نمونه کامل از [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/)، متد [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationfactory/#getPresentationInfo) را صدا بزنید و [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#isWriteProtected) را بررسی کنید. این متد از [NullableBool](https://reference.aspose.com/slides/fa/php-java/aspose.slides/nullablebool/) استفاده می‌کند و زمانی که حفاظت نوشتاری شناسایی شود، `NullableBool::True` را برمی‌گرداند.
```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() == NullableBool::True) {
    echo("The presentation is write protected.\n");
} else {
    echo("Write protection was not detected.\n");
}
```

بارگذاری مبتنی بر جریان [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationfactory/#getPresentationInfo) همان اطلاعات را برای ارائه‌ای که به‌صورت جریان ارائه می‌شود، فراهم می‌کند.

## **اعتبارسنجی رمز عبور حفاظت نوشتاری**

از [PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#checkWriteProtection) برای اعتبارسنجی رمز عبور تغییر بدون بارگیری کامل ارائه استفاده کنید. ابتدا [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#isWriteProtected) را بررسی کنید تا برنامه فقط هنگام وجود حفاظت نوشتاری، درخواست یا اعتبارسنجی رمز عبور را انجام دهد.
```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() != NullableBool::True) {
    echo("The presentation is not write protected.\n");
} elseif ($presentationInfo->checkWriteProtection("modify_password")) {
    echo("The write-protection password is correct.\n");
} else {
    echo("The write-protection password is incorrect.\n");
}
```

[PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#checkWriteProtection) تنها رمز عبور حفاظت نوشتاری را اعتبارسنجی می‌کند. این متد رمز عبور باز کردن یا تعیین قابلیت بارگیری محتواهای رمزنگاری‌شده را اعتبارسنجی نمی‌کند. در مقابل، [PresentationInfo::checkPassword](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#checkPassword) تنها رمز عبور باز کردن را اعتبارسنجی می‌کند. اگر یک ارائه کامل قبلاً بارگیری شده باشد، [ProtectionManager::checkWriteProtection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/protectionmanager/#checkWriteProtection) بررسی معادل حفاظت نوشتاری را از طریق مدیر حفاظت خود فراهم می‌کند.

در برنامه‌های تولیدی، رمزهای عبور را در لاگ‌ها ثبت نکنید یا در پیام‌های تشخیص خطا گنجانده نشوند. از تلاش‌های تکراری و غیرضروری برای اعتبارسنجی جلوگیری کنید و رمزهای عبور را در حافظه تنها به‌مدت لازم نگه دارید.

{{% alert color="info" title="See also" %}}
- [محافظت از ارائه‌ها با رمز عبور](/slides/fa/php-java/password-protected-presentation/)
- [ارائه‌های فقط‌خواندنی](/slides/fa/php-java/read-only-presentation/)
- [امضای دیجیتال در پاورپوینت](/slides/fa/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **سوالات متداول**

**آیا حفاظت نوشتاری یک ارائه را رمزنگاری می‌کند؟**  
خیر. این محدودیت تغییرات را اعمال می‌کند ولی محتوای ارائه برای بارگیری و مشاهده در دسترس می‌ماند.

**آیا رمز عبور حفاظت نوشتاری برای باز کردن یک ارائه لازم است؟**  
خیر. فقط یک رمز عبور باز کردن برای بارگیری محتوای رمزنگاری‌شدهٔ ارائه لازم است.

**آیا یک ارائه می‌تواند هم‌زمان دارای رمز عبور باز کردن و رمز عبور حفاظت نوشتاری باشد؟**  
بله. رمز عبور باز کردن را از طریق گزینه‌های بارگیری برای باز کردن ارائهٔ رمزنگاری‌شده ارائه دهید و رمز عبور حفاظت نوشتاری را به‌صورت جداگانه هنگام نیاز به مجوز تغییر اعتبارسنجی کنید.