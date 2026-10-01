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
- ذخیره ارائه به عنوان PDF
- ذخیره PPT به عنوان PDF
- ذخیره PPTX به عنوان PDF
- صدور PPT به PDF
- صدور PPTX به PDF
- یادداشت‌های گوینده
- PDF با یادداشت‌ها
- Java
- Aspose.Slides
description: "فرمت‌های PPT و PPTX را با استفاده از Aspose.Slides برای Java به PDF با یادداشت‌ها تبدیل کنید. چیدمان‌ها و یادداشت‌های گوینده را برای ارائه‌های حرفه‌ای حفظ کنید."
---
## **نمایش کلی**

در این مقاله، خواهید آموخت که چگونه ارائه‌های PowerPoint را به فرمت PDF با یادداشت‌های گوینده تبدیل کنید با استفاده از Aspose.Slides. این راهنما گام‌های لازم را پوشش می‌دهد و مثال‌های کدی ارائه می‌کند تا به‌صورت کارآمد این کار را انجام دهید. در پایان این مقاله، قادر خواهید بود:

- فرآیند تبدیل را پیاده‌سازی کنید تا اسلایدهای PowerPoint را به اسناد PDF تبدیل کنید و یادداشت‌های گوینده را حفظ کنید.
- خروجی PDF را سفارشی کنید تا اطمینان حاصل شود که یادداشت‌های گوینده گنجانده شده و مطابق نیازهای شما قالب‌بندی شده‌اند.

برای تنظیم ابعاد و جهت صفحه یادداشت‌ها قبل از خروجی‌گیری، به [اندازه صفحه یادداشت‌ها](/slides/fa/java/notes-size/) مراجعه کنید.

## **تبدیل PowerPoint به PDF با یادداشت‌ها**

متد `save` در کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) می‌تواند برای تبدیل ارائه PPT یا PPTX به PDF با یادداشت‌های گوینده استفاده شود. با Aspose.Slides، به سادگی ارائه را بارگذاری می‌کنید، گزینه‌های چیدمان را با استفاده از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/notescommentslayoutingoptions/) برای گنجاندن یادداشت‌های گوینده پیکربندی می‌کنید و سپس فایل را به‌عنوان PDF ذخیره می‌کنید. قطعه کد زیر نشان می‌دهد چگونه یک ارائه نمونه را به PDF در نمای اسلاید یادداشت‌ها تبدیل کنیم.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// پیکربندی گزینه‌های PDF برای رندر کردن یادداشت‌های گوینده.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // نمایش یادداشت‌های گوینده در زیر اسلاید.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// ذخیره ارائه به PDF با یادداشت‌های گوینده.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}
ممکن است بخواهید Aspose [تبدیل‌کننده آنلاین PowerPoint به PDF](https://products.aspose.app/slides/fa/conversion) را بررسی کنید.
{{% /alert %}}