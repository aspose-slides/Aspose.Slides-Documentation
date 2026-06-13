---
title: تبدیل ارائه‌های PowerPoint به TIFF با یادداشت‌ها در PHP
linktitle: PowerPoint به TIFF با یادداشت‌ها
type: docs
weight: 100
url: /fa/php-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به TIFF
- ارائه به TIFF
- اسلاید به TIFF
- PPT به TIFF
- PPTX به TIFF
- ذخیره PPT به عنوان TIFF
- ذخیره PPTX به عنوان TIFF
- صادر کردن PPT به TIFF
- صادر کردن PPTX به TIFF
- PowerPoint با یادداشت‌ها
- ارائه با یادداشت‌ها
- اسلاید با یادداشت‌ها
- PPT با یادداشت‌ها
- PPTX با یادداشت‌ها
- TIFF با یادداشت‌ها
- PHP
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint به TIFF با یادداشت‌ها با استفاده از Aspose.Slides برای PHP از طریق Java. یاد بگیرید چگونه اسلایدها را با یادداشت‌های سخنران به‌صورت کارآمد صادر کنید."
---
## **مقدمه**

Aspose.Slides for PHP via Java راه‌حل ساده‌ای برای تبدیل ارائه‌های PowerPoint و OpenDocument (PPT، PPTX و ODP) همراه با یادداشت‌ها به فرمت TIFF فراهم می‌کند. این فرمت به‌طور گسترده برای ذخیره‌سازی تصویر با کیفیت بالا، چاپ و بایگانی اسناد استفاده می‌شود. با Aspose.Slides می‌توانید نه تنها کل ارائه‌ها را به همراه یادداشت‌های سخنران صادر کنید، بلکه تصویرهای کوچک اسلایدها را در نمای Notes Slide نیز تولید نمایید. فرآیند تبدیل ساده و کارآمد است و از متد `save` کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) برای تبدیل کل ارائه به مجموعه‌ای از تصاویر TIFF استفاده می‌کند در حالی که یادداشت‌ها و طرح‌بندی حفظ می‌شوند.

## **تبدیل یک ارائه به TIFF با یادداشت‌ها**

ذخیره یک ارائه PowerPoint یا OpenDocument به TIFF همراه با یادداشت‌ها با استفاده از Aspose.Slides for PHP via Java شامل مراحل زیر است:

1. نمونه‌سازی کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) : بارگذاری فایل PowerPoint یا OpenDocument.  
2. پیکربندی گزینه‌های چیدمان خروجی : از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/notescommentslayoutingoptions/) برای مشخص کردن نحوه نمایش یادداشت‌ها و نظرات استفاده کنید.  
3. ذخیره ارائه به TIFF : گزینه‌های پیکربندی‌شده را به متد [save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#save) پاس دهید.

فرض کنیم فایلی به نام "speaker_notes.pptx" با اسلاید زیر داریم:

![اسلاید ارائه با یادداشت‌های سخنران](slide_with_notes.png)

قطعه کد زیر نحوه تبدیل ارائه به تصویر TIFF در نمای Notes Slide را با استفاده از متد [setSlidesLayoutOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) نشان می‌دهد.

```php
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
$presentation = new Presentation("speaker_notes.pptx");
try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull); // نمایش یادداشت‌ها زیر اسلاید.

    // پیکربندی گزینه‌های TIFF با چیدمان یادداشت‌ها.
    $tiffOptions = new TiffOptions();
    $tiffOptions->setDpiX(300);
    $tiffOptions->setDpiY(300);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // ذخیره ارائه به TIFF همراه با یادداشت‌های سخنران.
    $presentation->save("TIFF_with_notes.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![تصویر TIFF با یادداشت‌های سخنران](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
به Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online) مراجعه کنید.
{{% /alert %}}

## **سوالات متداول**

**آیا می‌توانم موقعیت ناحیه یادداشت‌ها را در TIFF حاصل کنترل کنم؟**

بله. از [notes layout settings](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) استفاده کنید تا بین گزینه‌هایی مانند `None`، `BottomTruncated` یا `BottomFull` انتخاب کنید؛ که به ترتیب یادداشت‌ها را پنهان می‌کند، در یک صفحه می‌گنجاند یا اجازه می‌دهد روی صفحات اضافی ادامه یابند.

**چگونه می‌توانم حجم فایل TIFF همراه با یادداشت‌ها را بدون کاهش محسوس کیفیت کاهش دهم؟**

یک [compression](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/setcompressiontype/) کارآمد (مثلاً `LZW` یا `RLE`) انتخاب کنید، DPI معقولی تنظیم کنید و در صورت امکان از [pixel format](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/setpixelformat/) پایین‌تر (مانند 8 بیتی یا 1 بیتی برای تک‌رنگ) استفاده کنید. کمی کاهش [image dimensions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/setimagesize/) نیز می‌تواند بدون آسیب قابل توجه به قابلیت خواندن مفید باشد.

**آیا فونت در یادداشت‌ها بر نتیجه تأثیر می‌گذارد اگر فونت‌های اصلی در سیستم موجود نباشند؟**

بله. نبود فونت‌ها باعث [substitution](/slides/fa/php-java/font-selection-sequence/) می‌شود که می‌تواند متریک‌های متن و ظاهر را تغییر دهد. برای اجتناب از این مشکل، [فونت‌های مورد نیاز را فراهم کنید](/slides/fa/php-java/custom-font/) یا یک [fallback font]( /slides/fa/php-java/fallback-font/) پیش‌فرض تنظیم کنید تا قلم‌های موردنظر استفاده شوند.