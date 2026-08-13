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
- خروجی PPT به PDF
- خروجی PPTX به PDF
- یادداشت‌های گوینده
- PDF با یادداشت‌ها
- Java
- Aspose.Slides
description: "فرمت‌های PPT و PPTX را با یادداشت‌ها به PDF تبدیل کنید با استفاده از Aspose.Slides برای Java. چیدمان‌ها و یادداشت‌های گوینده را برای ارائه‌های حرفه‌ای حفظ کنید."
---
## **بررسی کلی**

در این مقاله، نحوه تبدیل ارائه‌های PowerPoint به قالب PDF همراه با یادداشت‌های گوینده با استفاده از Aspose.Slides را می‌آموزید. این راهنما مراحل لازم را پوشش می‌دهد و مثال‌های کد را فراهم می‌کند تا به‌صورت کارآمد این کار را انجام دهید. در پایان این مقاله می‌توانید:

- فرآیند تبدیل را پیاده‌سازی کنید تا اسلایدهای PowerPoint را به اسناد PDF تبدیل کنید و در عین حال یادداشت‌های گوینده حفظ شوند.
- خروجی PDF را سفارشی کنید تا اطمینان حاصل شود که یادداشت‌های گوینده گنجانده شده و بر اساس نیازهای شما قالب‌بندی شوند.

## **تبدیل PowerPoint به PDF با یادداشت‌ها**

`save` متد در کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) می‌تواند برای تبدیل یک ارائه PPT یا PPTX به PDF همراه با یادداشت‌های گوینده استفاده شود. با Aspose.Slides، به‌سادگی ارائه را بارگذاری می‌کنید، گزینه‌های چیدمان را با استفاده از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/notescommentslayoutingoptions/) پیکربندی می‌کنید تا یادداشت‌های گوینده گنجانده شوند، و سپس فایل را به‌عنوان PDF ذخیره می‌کنید. قطعه کد زیر نشان می‌دهد چگونه یک ارائه نمونه را در نمای اسلایدهای یادداشت‌ها به PDF تبدیل کنید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// پیکربندی گزینه‌های PDF برای رندر کردن یادداشت‌های گوینده.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // رندر کردن یادداشت‌های گوینده زیر اسلاید.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" %}} 
ممکن است بخواهید مبدل آنلاین PowerPoint به PDF Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/fa/conversion) را بررسی کنید. 
{{% /alert %}}