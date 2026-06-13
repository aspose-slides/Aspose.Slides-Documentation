---
title: تبدیل ارائه‌های PowerPoint به PDF با یادداشت‌ها در Java
linktitle: PowerPoint به PDF با یادداشت‌ها
type: docs
weight: 50
url: /fa/java/convert-powerpoint-to-pdf-with-notes/
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
- ذخیره ارائه به‌صورت PDF
- ذخیره PPT به PDF
- ذخیره PPTX به PDF
- صدور PPT به PDF
- صدور PPTX به PDF
- یادداشت‌های سخنران
- PDF با یادداشت‌ها
- Java
- Aspose.Slides
description: "تبدیل فرمت‌های PPT و PPTX به PDF با یادداشت‌ها با استفاده از Aspose.Slides برای Java. حفظ چیدمان‌ها و یادداشت‌های سخنران برای ارائه‌های حرفه‌ای."
---
## **بررسی کلی**

در این مقاله، خواهید آموخت که چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides به فرمت PDF همراه با یادداشت‌های سخنران تبدیل کنید. این راهنما مراحل لازم را پوشش می‌دهد و نمونه‌های کد را برای انجام کار به‌صورت کارآمد ارائه می‌کند. در پایان این مقاله، خواهید توانست:

- فرایند تبدیل را برای تبدیل اسلایدهای PowerPoint به اسناد PDF به‌طوری که یادداشت‌های سخنران حفظ شوند، پیاده‌سازی کنید.
- خروجی PDF را سفارشی کنید تا اطمینان حاصل شود که یادداشت‌های سخنران گنجانده شده و طبق نیازهای شما قالب‌بندی شوند.

## **تبدیل پاورپوینت به PDF با یادداشت‌ها**

متد `save` در کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) می‌تواند برای تبدیل یک ارائه PPT یا PPTX به PDF همراه با یادداشت‌های سخنران استفاده شود. با Aspose.Slides، به سادگی ارائه را بارگذاری می‌کنید، گزینه‌های چیدمان را با استفاده از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/notescommentslayoutingoptions/) پیکربندی می‌کنید تا یادداشت‌های سخنران گنجانده شوند و سپس فایل را به‌عنوان PDF ذخیره می‌کنید. قطعه کد زیر نشان می‌دهد که چگونه یک ارائه نمونه را به PDF در نمای اسلاید یادداشت‌ها تبدیل کنید.

```java
Presentation presentation = new Presentation("sample.pptx");

// پیکربندی گزینه‌های PDF برای نمایش یادداشت‌های سخنران.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // نمایش یادداشت‌های سخنران در زیر اسلاید.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// ذخیره ارائه به PDF همراه با یادداشت‌های سخنران.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="primary" %}} 
ممکن است بخواهید Aspose [مبدل آنلاین PowerPoint به PDF](https://products.aspose.app/slides/fa/conversion) را بررسی کنید. 
{{% /alert %}}