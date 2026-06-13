---
title: تبدیل ارائه‌های PowerPoint به PDF با یادداشت‌ها در JavaScript
linktitle: PowerPoint به PDF با یادداشت‌ها
type: docs
weight: 50
url: /fa/nodejs-java/convert-powerpoint-to-pdf-with-notes/
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
- ذخیره ارائه به‌عنوان PDF
- ذخیره PPT به‌عنوان PDF
- ذخیره PPTX به‌عنوان PDF
- صدور PPT به PDF
- صدور PPTX به PDF
- یادداشت‌های گوینده
- PDF با یادداشت‌ها
- Node.js
- JavaScript
- Aspose.Slides
description: "تبدیل فرمت‌های PPT و PPTX به PDF با یادداشت‌ها در JavaScript با استفاده از Aspose.Slides برای Node.js. حفظ چیدمان‌ها و یادداشت‌های گوینده برای ارائه‌های حرفه‌ای."
---
## **مرور کلی**

در این مقاله، یاد می‌گیرید چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides به فرمت PDF همراه با یادداشت‌های گوینده تبدیل کنید. این راهنما گام‌های لازم را پوشش می‌دهد و نمونه‌های کد را برای کمک به انجام مؤثر این کار ارائه می‌کند. در پایان این مقاله، قادر خواهید بود:

- پیاده‌سازی فرآیند تبدیل برای تبدیل اسلایدهای PowerPoint به اسناد PDF در حالی که یادداشت‌های گوینده حفظ می‌شوند.
- سفارشی‌سازی PDF خروجی به‌طوری که یادداشت‌های گوینده گنجانده و بر اساس نیازهای شما قالب‌بندی شوند.

## **تبدیل PowerPoint به PDF با یادداشت‌ها**

متد `save` در کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) می‌تواند برای تبدیل ارائهٔ PPT یا PPTX به PDF همراه با یادداشت‌های گوینده استفاده شود. با Aspose.Slides، به سادگی ارائه را بارگذاری می‌کنید، گزینه‌های چینش را با استفاده از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/notescommentslayoutingoptions/) پیکربندی می‌کنید تا یادداشت‌های گوینده گنجانده شوند، و سپس فایل را به صورت PDF ذخیره می‌کنید. قطعه کد زیر نشان می‌دهد چگونه یک ارائهٔ نمونه را به PDF در نمای اسلایدهای یادداشت تبدیل کنید.

```js
let presentation = new asposeSlides.Presentation("sample.pptx");

// پیکربندی گزینه‌های PDF برای رندر کردن یادداشت‌های گوینده.
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // رندر کردن یادداشت‌های گوینده در زیر اسلاید.

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="primary" %}} 
ممکن است بخواهید مبدل آنلاین پاورپوینت به PDF Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/fa/conversion) را بررسی کنید. 
{{% /alert %}}