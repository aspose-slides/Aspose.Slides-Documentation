---
title: تبدیل ارائه‌های PowerPoint در حالت Handout با استفاده از Java
linktitle: حالت Handout
type: docs
weight: 150
url: /fa/java/convert-powerpoint-in-handout-mode/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- حالت توزیع
- توزیع
- PPT
- PPTX
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "ارائه‌ها را به توزیع‌ها در Java تبدیل کنید. اسلایدها را در هر صفحه تنظیم کنید، یادداشت‌ها را نگه دارید، با Aspose.Slides به PDF یا تصاویر صادر کنید، همراه با نمونه کد Java. به صورت رایگان امتحان کنید."
---
## **مقدمه**

Aspose.Slides به شما امکان می‌دهد ارائه‌ها را به فرمت‌های خروجی که حالت Handout را پشتیبانی می‌کنند، تبدیل کنید. در این حالت، اسلایدهای متعدد در یک صفحه چیده می‌شوند که برای چاپ مواد ارائه در کنفرانس‌ها، سمینارها و رویدادهای مشابه مفید است.

حالت Handout از طریق متد `setSlidesLayoutOptions` پیکربندی می‌شود که در [IPdfOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipdfoptions/)، [IRenderingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/irenderingoptions/)، [IHtmlOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihtmloptions/) و [ITiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiffoptions/) موجود است. برای تعریف چیدمان Handout، از شیء [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/handoutlayoutingoptions/) استفاده کنید.

برای تنظیم ابعاد صفحه Handout و جهت آن قبل از صادرات، به [اندازه صفحه یادداشت‌ها](/slides/fa/java/notes-size/) مراجعه کنید.

## **صادر کردن در حالت Handout**

برای صادرات یک ارائه در حالت Handout، متد `setSlidesLayoutOptions` را برای گزینه‌های صادرات هدف تنظیم کنید و یک نمونه از [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/handoutlayoutingoptions/) اختصاص دهید که تعداد اسلایدها در هر صفحه و پارامترهای نمایش مرتبط را تعریف می‌کند.

در زیر یک مثال کد نشان داده شده است که نحوه تبدیل یک ارائه به PDF در حالت Handout را نمایش می‌دهد.

```java
import com.aspose.slides.*;

// یک ارائه را بارگیری کنید.
Presentation presentation = new Presentation("sample.pptx");
try {
    // تنظیم گزینه‌های صادرات.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // ۴ اسلاید در یک صفحه به صورت افقی
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // چاپ شماره اسلایدها
    slidesLayoutOptions.setPrintFrameSlide(true);                     // چاپ یک قاب دور اسلایدها
    slidesLayoutOptions.setPrintComments(false);                      // بدون نظرات

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // صادر کردن ارائه به PDF با چیدمان انتخاب‌شده.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" title="Warning" %}}
به خاطر داشته باشید که متد `setSlidesLayoutOptions` فقط برای برخی فرمت‌های خروجی مانند PDF، HTML، TIFF و هنگام رندر به‌صورت تصویر در دسترس است.
{{% /alert %}} 

## **سوالات متداول**

**حداکثر تعداد پیش‌نمایش اسلایدها در هر صفحه در حالت Handout چقدر است؟**

Aspose.Slides از [پیش‌تنظیم‌ها](https://reference.aspose.com/slides/fa/java/com.aspose.slides/handouttype/) تا ۹ پیش‌نمایش در هر صفحه با ترتیب افقی یا عمودی پشتیبانی می‌کند: ۱، ۲، ۳، ۴ (افقی/عمودی)، ۶ (افقی/عمودی) و ۹ (افقی/عمودی).

**آیا می‌توانم یک شبکه سفارشی مانند ۵ یا ۸ اسلاید در هر صفحه تعریف کنم؟**

خیر. تعداد و ترتیب پیش‌نمایش‌ها به‌‌صورت کامل توسط کلاس [HandoutType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/handouttype/) کنترل می‌شود؛ طرح‌بندی‌های دلخواه پشتیبانی نمی‌شوند.

**آیا می‌توانم اسلایدهای مخفی را در خروجی Handout گنجانده کنم؟**

بله. اسلایدهای مخفی را با استفاده از متد `setShowHiddenSlides` در تنظیمات صادرات برای فرمت هدف، مانند [PdfOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pdfoptions/)، [HtmlOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/htmloptions/) یا [TiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/) فعال کنید.