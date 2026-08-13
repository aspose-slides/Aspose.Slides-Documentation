---
title: تبدیل ارائه‌های PowerPoint به PDF با یادداشت‌ها در Android
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
- ذخیره ارائه به صورت PDF
- ذخیره PPT به PDF
- ذخیره PPTX به PDF
- صادرات PPT به PDF
- صادرات PPTX به PDF
- یادداشت‌های گوینده
- PDF با یادداشت‌ها
- Android
- Java
- Aspose.Slides
description: "فرمت‌های PPT و PPTX را با استفاده از Aspose.Slides برای Android از طریق Java به PDF با یادداشت‌ها تبدیل کنید. چیدمان‌ها و یادداشت‌های گوینده را برای ارائه‌های حرفه‌ای حفظ کنید."
---
## **مرور کلی**

در این مقاله، نحوهٔ تبدیل ارائه‌های PowerPoint به قالب PDF به همراه یادداشت‌های گوینده با استفاده از Aspose.Slides را یاد می‌گیرید. این راهنما مراحل ضروری را پوشش می‌دهد و مثال‌های کد ارائه می‌کند تا به‌صورت کارآمد این کار را انجام دهید. در پایان مقاله قادر خواهید بود:

- فرایند تبدیل را پیاده‌سازی کنید تا اسلایدهای PowerPoint را به اسناد PDF تبدیل کنید و در عین حال یادداشت‌های گوینده را حفظ کنید.
- خروجی PDF را سفارشی کنید تا اطمینان حاصل شود یادداشت‌های گوینده گنجانده شده و مطابق نیازهای شما قالب‌بندی شده‌اند.

## **تبدیل PowerPoint به PDF با یادداشت‌ها**

متد `save` در کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) می‌تواند برای تبدیل ارائه PPT یا PPTX به PDF همراه با یادداشت‌های گوینده مورد استفاده قرار گیرد. با Aspose.Slides، به سادگی ارائه را بارگذاری کنید، گزینه‌های چیدمان را با استفاده از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/notescommentslayoutingoptions/) برای گنجاندن یادداشت‌های گوینده پیکربندی کنید و سپس فایل را به صورت PDF ذخیره کنید. قطعه کد زیر نشان می‌دهد چگونه یک ارائه نمونه را به PDF در نمای اسلایدهای یادداشت‌ها تبدیل کنید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
	// پیکربندی گزینه‌های PDF برای رندر کردن یادداشت‌های گوینده.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // رندر کردن یادداشت‌های گوینده در زیر اسلاید.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// ذخیرهٔ ارائه به PDF با یادداشت‌های گوینده.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="info" %}} 

ممکن است بخواهید مبدل آنلاین PowerPoint به PDF Aspose را بررسی کنید: [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/fa/conversion).

{{% /alert %}}