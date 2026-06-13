---
title: تبدیل ارائه‌های PowerPoint به PDF با یادداشت‌ها در اندروید
linktitle: PowerPoint به PDF با یادداشت‌ها
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
- PDF با یادداشت‌ها
- اندروید
- جاوا
- Aspose.Slides
description: "قالب‌های PPT و PPTX را با استفاده از Aspose.Slides برای اندروید از طریق جاوا به PDF با یادداشت‌ها تبدیل کنید. چیدمان‌ها و یادداشت‌های سخنران را برای ارائه‌های حرفه‌ای حفظ کنید."
---
## **بررسی کلی**

در این مقاله، خواهید آموخت که چگونه ارائه‌های PowerPoint را با یادداشت‌های سخنران به فرمت PDF تبدیل کنید با استفاده از Aspose.Slides. این راهنما گام‌های لازم را پوشش می‌دهد و مثال‌های کد را ارائه می‌دهد تا بتوانید این کار را به‌صورت کارآمد انجام دهید. در پایان این مقاله، قادر خواهید بود:

- فرآیند تبدیل را پیاده‌سازی کنید تا اسلایدهای PowerPoint را به اسناد PDF تبدیل کرده و یادداشت‌های سخنران را حفظ کنید.
- خروجی PDF را سفارشی کنید تا اطمینان حاصل شود که یادداشت‌های سخنران گنجانده شده و مطابق نیازهای شما قالب‌بندی شوند.

## **تبدیل PowerPoint به PDF با یادداشت‌ها**

متد `save` در کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) می‌تواند برای تبدیل یک ارائه PPT یا PPTX به PDF همراه با یادداشت‌های سخنران استفاده شود. با Aspose.Slides، کافی است ارائه را بارگذاری کنید، گزینه‌های چیدمان را با استفاده از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/notescommentslayoutingoptions/) تنظیم کنید تا یادداشت‌های سخنران گنجانده شوند، و سپس فایل را به صورت PDF ذخیره کنید. بخش کد زیر نشان می‌دهد که چگونه یک ارائه نمونه را در نمای اسلایدهای یادداشت به PDF تبدیل کنید.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
	// تنظیم گزینه‌های PDF برای رندر کردن یادداشت‌های سخنران.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // رندر کردن یادداشت‌های سخنران زیر اسلاید.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// ذخیرهٔ ارائه به PDF با یادداشت‌های سخنران.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="primary" %}} 
ممکن است بخواهید مبدل آنلاین PowerPoint به PDF Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/fa/conversion) را بررسی کنید. 
{{% /alert %}}