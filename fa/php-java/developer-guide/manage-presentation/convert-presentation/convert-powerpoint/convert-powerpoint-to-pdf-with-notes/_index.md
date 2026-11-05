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
- ذخیره PPT به عنوان PDF
- ذخیره PPTX به عنوان PDF
- خروجی PPT به PDF
- خروجی PPTX به PDF
- یادداشت‌های گوینده
- PDF با یادداشت‌ها
- PHP
- Aspose.Slides
description: "تبدیل فرمت‌های PPT و PPTX به PDF با یادداشت‌ها با استفاده از Aspose.Slides برای PHP از طریق Java. حفظ چیدمان‌ها و یادداشت‌های گوینده برای ارائه‌های حرفه‌ای."
---
## **نمای کلی**

در این مقاله، نحوه تبدیل ارائه‌های PowerPoint به فرمت PDF همراه با یادداشت‌های گوینده با استفاده از Aspose.Slides را یاد خواهید گرفت. این راهنما گام‌های ضروری را پوشش می‌دهد و نمونه‌های کد را ارائه می‌کند تا به شما کمک کند این کار را به‌صورت کارآمد انجام دهید. در پایان این مقاله، قادر خواهید بود:

- فرآیند تبدیل را پیاده‌سازی کنید تا اسلایدهای PowerPoint را به سندهای PDF تبدیل کنید در حالی که یادداشت‌های گوینده حفظ می‌شوند.
- خروجی PDF را سفارشی کنید تا اطمینان حاصل شود که یادداشت‌های گوینده گنجانده شده و مطابق نیازهای شما قالب‌بندی شده‌اند.

برای تنظیم ابعاد و جهت‌گیری صفحه یادداشت‌ها قبل از خروجی، به [اندازه صفحه یادداشت](/slides/fa/php-java/notes-size/) مراجعه کنید.

## **تبدیل PowerPoint به PDF با یادداشت‌ها**

متد `save` در کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) می‌تواند برای تبدیل ارائه‌ی PPT یا PPTX به PDF همراه با یادداشت‌های گوینده استفاده شود. با Aspose.Slides، به سادگی ارائه را بارگذاری می‌کنید، گزینه‌های چیدمان را با استفاده از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/notescommentslayoutingoptions/) تنظیم می‌کنید تا یادداشت‌های گوینده گنجانده شوند، و سپس فایل را به‌عنوان PDF ذخیره می‌کنید. قطعه کد زیر نحوه تبدیل یک ارائه نمونه به PDF در نمای اسلایدهای یادداشت را نشان می‌دهد.

```php
$presentation = new Presentation("sample.pptx");

// Configure PDF options for rendering speaker notes. -> پیکربندی گزینه‌های PDF برای رندر کردن یادداشت‌های گوینده.

$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // Render speaker notes below the slide. -> رندر کردن یادداشت‌های گوینده زیر اسلاید.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// Save the presentation to PDF with speaker notes.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="info" title="Note" %}}
شما ممکن است بخواهید Aspose [مبدل آنلاین PowerPoint به PDF](https://products.aspose.app/slides/fa/conversion) را بررسی کنید.
{{% /alert %}}