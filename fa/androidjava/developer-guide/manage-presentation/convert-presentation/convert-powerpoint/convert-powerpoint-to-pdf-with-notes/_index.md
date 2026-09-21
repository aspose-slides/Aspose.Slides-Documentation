---
title: تبدیل ارائه‌های PowerPoint به PDF همراه با یادداشت‌ها در Android
linktitle: PowerPoint به PDF همراه با یادداشت‌ها
type: docs
weight: 50
url: /fa/androidjava/convert-powerpoint-to-pdf-with-notes/
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
- PDF همراه با یادداشت‌ها
- Android
- Java
- Aspose.Slides
description: "فرمت‌های PPT و PPTX را با استفاده از Aspose.Slides برای Android از طریق Java به PDF همراه با یادداشت تبدیل کنید. طرح‌ها و یادداشت‌های سخنران را برای ارائه‌های حرفه‌ای حفظ کنید."
---
## **بررسی کلی**

در این مقاله، با نحوه تبدیل ارائه‌های PowerPoint به فرمت PDF همراه با یادداشت‌های سخنران با استفاده از Aspose.Slides آشنا می‌شوید. این راهنما مراحل لازم را پوشش می‌دهد و مثال‌های کد ارائه می‌کند تا بتوانید این کار را به‌صورت کارآمد انجام دهید. در پایان این مقاله قادر خواهید بود:

- پیاده‌سازی فرآیند تبدیل اسلایدهای PowerPoint به اسناد PDF در حالی که یادداشت‌های سخنران حفظ می‌شوند.
- سفارشی‌سازی PDF خروجی به‌گونه‌ای که یادداشت‌های سخنران گنجانده شده و مطابق نیازهای شما قالب‌بندی شوند.

برای تعیین ابعاد و جهت‌گیری صفحه یادداشت‌ها پیش از صادرات، به [Notes Page Size](/slides/fa/androidjava/notes-size/) مراجعه کنید.

## **تبدیل PowerPoint به PDF با یادداشت‌ها**

متد `save` در کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) می‌تواند برای تبدیل ارائهٔ PPT یا PPTX به PDF همراه با یادداشت‌های سخنران استفاده شود. با Aspose.Slides، به سادگی ارائه را بارگذاری می‌کنید، گزینه‌های چینش را با استفاده از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/notescommentslayoutingoptions/) پیکربندی می‌کنید تا یادداشت‌های سخنران گنجانده شوند و سپس فایل را به‌عنوان PDF ذخیره می‌کنید. قطعهٔ کد زیر نحوهٔ تبدیل یک ارائهٔ نمونه به PDF در نمای اسلاید یادداشت‌ها را نشان می‌دهد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
	// پیکربندی گزینه‌های PDF برای رندر کردن یادداشت‌های سخنران.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // رندر کردن یادداشت‌های سخنران زیر اسلاید.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// ذخیرهٔ ارائه به PDF همراه با یادداشت‌های سخنران.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
ممکن است بخواهید به تبدیل‌کنندهٔ آنلاین Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/fa/conversion) نگاهی بیندازید.
{{% /alert %}}