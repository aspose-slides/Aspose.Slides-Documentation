---
title: تبدیل ارائه‌های PowerPoint به PDF با یادداشت‌ها در PHP
linktitle: PowerPoint به PDF با یادداشت‌ها
type: docs
weight: 50
url: /fa/php-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به PDF
- ارائه به PDF
- اسلاید به PDF
- PPT به PDF
- PPTX به PDF
- ذخیره ارائه به عنوان PDF
- ذخیره PPT به PDF
- ذخیره PPTX به PDF
- صادرات PPT به PDF
- صادرات PPTX به PDF
- یادداشت‌های سخنران
- PDF با یادداشت‌ها
- PHP
- Aspose.Slides
description: "قالب‌های PPT و PPTX را به PDF با یادداشت‌ها با استفاده از Aspose.Slides برای PHP از طریق Java تبدیل کنید. چیدمان‌ها و یادداشت‌های سخنران را برای ارائه‌های حرفه‌ای حفظ کنید."
---
## **مرور کلی**

در این مقاله، نحوه تبدیل ارائه‌های PowerPoint به قالب PDF با یادداشت‌های سخنران با استفاده از Aspose.Slides را یاد می‌گیرید. این راهنما مراحل لازم را پوشش می‌دهد و نمونه‌های کد را برای کمک به انجام کار به‌صورت کارآمد ارائه می‌کند. در پایان این مقاله قادر خواهید بود:

- فرآیند تبدیل را پیاده‌سازی کنید تا اسلایدهای PowerPoint را به اسناد PDF تبدیل کنید در حالی که یادداشت‌های سخنران حفظ می‌شوند.
- خروجی PDF را سفارشی کنید تا اطمینان حاصل شود که یادداشت‌های سخنران درج شده و مطابق نیازهای شما قالب‌بندی شوند.

## **تبدیل PowerPoint به PDF با یادداشت‌ها**

متد `save` در کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) می‌تواند برای تبدیل ارائه PPT یا PPTX به PDF با یادداشت‌های سخنران استفاده شود. با Aspose.Slides، به سادگی ارائه را بارگذاری می‌کنید، گزینه‌های چیدمان را با استفاده از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/notescommentslayoutingoptions/) تنظیم می‌کنید تا یادداشت‌های سخنران گنجانده شود، و سپس فایل را به‌صورت PDF ذخیره می‌کنید. قطعه کد زیر نحوه تبدیل یک ارائه نمونه به PDF در نمای اسلاید یادداشت‌ها را نشان می‌دهد.

```php
$presentation = new Presentation("sample.pptx");

// تنظیم گزینه‌های PDF برای رندر کردن یادداشت‌های سخنران.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // رندر کردن یادداشت‌های سخنران زیر اسلاید.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// ذخیره ارائه به PDF با یادداشت‌های سخنران.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="primary" %}} 
ممکن است بخواهید مبدل آنلاین PowerPoint به PDF Aspose را بررسی کنید: [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/fa/conversion). 
{{% /alert %}}