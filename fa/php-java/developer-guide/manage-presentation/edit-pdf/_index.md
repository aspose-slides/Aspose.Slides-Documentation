---
title: ویرایش اسناد PDF در PHP
linktitle: ویرایش PDF
type: docs
weight: 65
url: /fa/php-java/edit-pdf/
keywords:
- ویرایش PDF
- جایگزینی متن PDF
- PDF به PPTX
- PPTX به PDF
- PHP
- Aspose.Slides
description: "اسناد PDF را در PHP با وارد کردن آنها به Aspose.Slides، جایگزینی متن و ذخیره ارائهٔ اصلاح‌شده به صورت PDF ویرایش کنید."
---
## **نمای کلی**

Aspose.Slides برای PHP از طریق Java به شما امکان می‌دهد محتوای PDF را با وارد کردن صفحات آن به‌صورت اسلاید، ویرایش ارائه و سپس صادر کردن مجدد به PDF ویرایش کنید. این مقاله یک جایگزینی متن ساده را نشان می‌دهد. ارائه در حافظه باقی می‌ماند، بنابراین ذخیره‌سازی یک فایل PPTX میانی اختیاری است.

## **جایگزینی متن در PDF**

از [SlideCollection::addFromPdf](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/#addFromPdf) برای وارد کردن صفحات، [Presentation::replaceText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#replaceText) برای به‌روزرسانی متن و [Presentation::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#save) برای صادر کردن نتیجه استفاده کنید.

مثال زیر انتظار دارد که `input.pdf` پس از وارد شدن شامل کلمه «Draft» به‌عنوان متن قابل ویرایش باشد. این کلمه را با «Final» جایگزین می‌کند و `edited.pdf` را می‌نویسد. پاک کردن اسلاید اولیه قبل از وارد کردن، یک صفحه خالی اضافه در خروجی را جلوگیری می‌کند. جستجو تنها کلمات کامل با همان حروف بزرگ و کوچک را مطابقت می‌دهد؛ `null` به این معنی است که کال‌بک نتیجه لازم نیست.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextSearchOptions;

$presentation = new Presentation();
try {
    $presentation->getSlides()->removeAt(0);

    $presentation->getSlides()->addFromPdf("input.pdf");

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);
    $presentation->replaceText("Draft", "Final", $searchOptions, null);

    $presentation->save("edited.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

برای گزینه‌های بیشتر، به [جستجو و جایگزینی متن](/slides/fa/php-java/search-and-replace-text/) و [تبدیل پاورپوینت به PDF](/slides/fa/php-java/convert-powerpoint-to-pdf/) مراجعه کنید.

{{% alert color="info" title="Note" %}}
جایگزینی متن بر روی متن‌های وارد شده اعمال می‌شود و نه متن داخل تصاویر اسکن‌شده. تبدیل می‌تواند بر چیدمان و قالب‌بندی تأثیر بگذارد، بنابراین خروجی را بازبینی کنید، به‌ویژه هنگامی که متن جایگزین طولانی‌تر از متن اصلی باشد.
{{% /alert %}}

## **سوالات متداول**

**آیا قبل از صادر کردن PDF نیاز به ذخیره فایل PPTX دارم؟**

خیر. می‌توانید همان ارائه را در حافظه ویرایش و صادر کنید. فقط در صورتی که بخواهید ادامه دهید آن را در PowerPoint ویرایش کنید، یک نسخه PPTX ذخیره کنید؛ به [ذخیره ارائه‌ها](/slides/fa/php-java/save-presentation/) مراجعه کنید.

**چرا ممکن است برخی متن‌ها تغییر نکنند؟**

در این مثال کلمه کامل «Draft» با حروف دقیق مطابقت داده می‌شود. متنی که به‌عنوان تصویر وارد شده یا در فریم‌های متنی جداگانه تقسیم شده است لزوماً با جستجو مطابقت نخواهد داشت. محتوای وارد شده را بررسی کنید و جستجو را برای سند خود تنظیم کنید.