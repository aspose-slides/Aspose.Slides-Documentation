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
- ذخیره ارائه به صورت PDF
- ذخیره PPT به PDF
- ذخیره PPTX به PDF
- صادرات PPT به PDF
- صادرات PPTX به PDF
- یادداشت‌های سخنران
- PDF با یادداشت‌ها
- Node.js
- JavaScript
- Aspose.Slides
description: "فرمت‌های PPT و PPTX را به PDF با یادداشت‌ها در JavaScript با استفاده از Aspose.Slides برای Node.js تبدیل کنید. چیدمان‌ها و یادداشت‌های سخنران را برای ارائه‌های حرفه‌ای حفظ کنید."
---
## **نمای کلی**

در این مقاله، نحوه تبدیل ارائه‌های PowerPoint به قالب PDF همراه با یادداشت‌های سخنران با استفاده از Aspose.Slides را یاد خواهید گرفت. این راهنما مراحل لازم را پوشش می‌دهد و مثال‌های کد برای کمک به انجام مؤثر این کار ارائه می‌کند. در پایان این مقاله، قادر خواهید بود:

- پیاده‌سازی فرآیند تبدیل برای تبدیل اسلایدهای PowerPoint به اسناد PDF در حالی که یادداشت‌های سخنران حفظ می‌شوند.
- سفارشی‌سازی PDF خروجی برای اطمینان از گنجاندن و قالب‌بندی یادداشت‌های سخنران طبق نیازهای شما.

برای تنظیم ابعاد و جهت‌گیری صفحه یادداشت‌ها قبل از خروجی، به [Notes Page Size](/slides/fa/nodejs-java/notes-size/) مراجعه کنید.

## **تبدیل PowerPoint به PDF با یادداشت‌ها**

متد `save` در کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) می‌تواند برای تبدیل یک ارائه PPT یا PPTX به PDF همراه با یادداشت‌های سخنران استفاده شود. با Aspose.Slides، به سادگی ارائه را بارگذاری می‌کنید، گزینه‌های چیدمان را با استفاده از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/notescommentslayoutingoptions/) برای گنجاندن یادداشت‌های سخنران پیکربندی می‌کنید، و سپس فایل را به صورت PDF ذخیره می‌کنید. قطعه کد زیر نشان می‌دهد چگونه یک ارائه نمونه را به PDF در نمای اسلایدهای یادداشت تبدیل کنید.

```js
const asposeSlides = require("aspose.slides.via.java");

let presentation = new asposeSlides.Presentation("sample.pptx");

// پیکربندی گزینه‌های PDF برای رندر کردن یادداشت‌های سخنران.
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // رندر کردن یادداشت‌های سخنران در زیر اسلاید.

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// ذخیره ارائه به PDF با یادداشت‌های سخنران.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}
ممکن است بخواهید Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/fa/conversion) را بررسی کنید.
{{% /alert %}}