---
title: تبدیل ارائه‌های PowerPoint به SWF Flash در JavaScript
linktitle: PowerPoint به SWF
type: docs
weight: 80
url: /fa/nodejs-java/convert-powerpoint-to-swf-flash/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به SWF
- ارائه به SWF
- اسلاید به SWF
- PPT به SWF
- PPTX به SWF
- PowerPoint به Flash
- ارائه به Flash
- اسلاید به Flash
- PPT به Flash
- PPTX به Flash
- ذخیره PPT به صورت SWF
- ذخیره PPTX به صورت SWF
- صدور PPT به SWF
- صدور PPTX به SWF
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "تبدیل PowerPoint (PPT/PPTX) به SWF Flash با Aspose.Slides برای Node.js. نمونه‌های کد گام به گام، خروجی سریع با کیفیت، بدون اتوماسیون PowerPoint."
---
## **مروری کلی**

این مقاله توضیح می‌دهد چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides به فرمت SWF تبدیل کنید. همچنین نشان می‌دهد چگونه یک ارائه را با متد [Presentation.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#save) به فایل SWF ذخیره کنید و چگونگی پیکربندی خروجی با [SwfOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/swfoptions/)، شامل تنظیمات نمایشگر و چیدمان یادداشت‌ها یا نظرات، نشان می‌دهد.

## **تبدیل PPT(X) به SWF**
متد [save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ارائه شده است می‌تواند برای تبدیل کل ارائه به سند **SWF** استفاده شود. مثال زیر نشان می‌دهد چگونه یک ارائه را با استفاده از گزینه‌های ارائه‌شده توسط کلاس [**SWFOptions**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SwfOptions) به سند **SWF** تبدیل کنید. همچنین می‌توانید نظرات را در SWF تولید شده با استفاده از کلاس‌های [**SWFOptions**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SwfOptions) و [**NotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/NotesCommentsLayoutingOptions) گنجانید.

```javascript
var pres = new aspose.slides.Presentation("Sample.pptx");
try {
    var swfOptions = new aspose.slides.SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // ذخیره ارائه
    pres.save("Sample.swf", aspose.slides.SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سوالات متداول**

**آیا می‌توانم اسلایدهای مخفی را در SWF گنجانم؟**

بله. از متد [setShowHiddenSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/swfoptions/setshowhiddenslides/) در [SwfOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/swfoptions/) استفاده کنید. به‌طور پیش‌فرض اسלایدهای مخفی صادر نمی‌شوند.

**چگونه می‌توانم فشرده‌سازی و اندازه نهایی SWF را کنترل کنم؟**

از متدهای [setCompressed](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/swfoptions/setcompressed/) و [setJpegQuality](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/swfoptions/setjpegquality/) استفاده کنید تا بین اندازه فایل و کیفیت تصویر تعادل برقرار کنید.

**متد 'setViewerIncluded' برای چه منظوری است و کی باید از آن استفاده کنم؟**

[setViewerIncluded](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/swfoptions/setviewerincluded/) یک رابط کاربری پخش‌کننده توکار (کنترل‌های ناوبری، پنل‌ها، جستجو) اضافه می‌کند. اگر قصد دارید پخش‌کننده خود را استفاده کنید یا به یک فریم SWF ساده بدون رابط کاربری نیاز دارید، از آن استفاده کنید.

**اگر یک فونت منبع در دستگاه خروجی موجود نباشد چه اتفاقی می‌افتد؟**

Aspose.Slides فونت مورد نظر شما را که از طریق [setDefaultRegularFont](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) در [SwfOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/swfoptions/) تعیین می‌کنید جایگزین می‌کند تا از استفاده غیرقصدی از فونت پیش‌فرض جلوگیری شود.