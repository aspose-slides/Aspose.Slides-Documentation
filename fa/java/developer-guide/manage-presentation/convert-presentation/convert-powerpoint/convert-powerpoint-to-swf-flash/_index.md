---
title: تبدیل ارائه‌های PowerPoint به SWF Flash در Java
linktitle: PowerPoint به SWF
type: docs
weight: 80
url: /fa/java/convert-powerpoint-to-swf-flash/
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
- ذخیره PPT به عنوان SWF
- ذخیره PPTX به عنوان SWF
- صادرات PPT به SWF
- صادرات PPTX به SWF
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "تبدیل PowerPoint (PPT/PPTX) به SWF Flash در Java با Aspose.Slides. نمونه‌های کد گام به گام، خروجی با کیفیت سریع، بدون اتوماسیون PowerPoint."
---
## **مروری کلی**

این مقاله توضیح می‌دهد که چگونه ارائه‌های PowerPoint را به SWF تبدیل کنید با استفاده از Aspose.Slides. این مقاله نشان می‌دهد چگونه یک ارائه را به‌عنوان یک فایل SWF ذخیره کنید با روش [Presentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) و چگونه صادرات را با [SwfOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/swfoptions/) پیکربندی کنید، شامل تنظیمات نمایشگر و چیدمان یادداشت‌ها یا نظرات.

## **تبدیل ارائه‌ها به فلش**

متد [save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ارائه می‌شود می‌تواند برای تبدیل کل ارائه به سند **SWF** استفاده شود. مثال زیر نشان می‌دهد چگونه یک ارائه را به سند **SWF** تبدیل کنید با استفاده از گزینه‌های ارائه شده توسط کلاس [**SWFOptions**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SwfOptions). همچنین می‌توانید نظرات را در SWF تولید شده با استفاده از کلاس [**ISWFOptions**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISwfOptions) و اینترفیس [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/INotesCommentsLayoutingOptions) گنجانده کنید.

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // ذخیره‌سازی ارائه
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**آیا می‌توانم اسلایدهای پنهان را در SWF گنجانده کنم؟**

بله. اسلایدهای پنهان را با استفاده از متد [setShowHiddenSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) در [SwfOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/swfoptions/) فعال کنید. به طور پیش‌فرض، اسلایدهای پنهان صادر نمی‌شوند.

**چگونه می‌توانم فشرده‌سازی و اندازه نهایی SWF را کنترل کنم؟**

از متد [setCompressed](https://reference.aspose.com/slides/fa/java/com.aspose.slides/swfoptions/#setCompressed-boolean-) و [adjust JPEG quality](https://reference.aspose.com/slides/fa/java/com.aspose.slides/swfoptions/#setJpegQuality-int-) استفاده کنید تا بین حجم فایل و کیفیت تصویر تعادل برقرار کنید.

**'setViewerIncluded' برای چه منظوری است و کی باید آن را غیرفعال کنم؟**

[setViewerIncluded](https://reference.aspose.com/slides/fa/java/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) یک رابط کاربری پخش‌کننده توکار (کنترل‌های ناوبری، پنل‌ها، جستجو) را اضافه می‌کند. اگر قصد دارید از پخش‌کننده خود استفاده کنید یا به یک چارچوب SWF ساده بدون UI نیاز دارید، آن را غیرفعال کنید.

**چه می‌شود اگر قلم منبع در دستگاه صادرات موجود نباشد؟**

Aspose.Slides قلمی را که با استفاده از متد [setDefaultRegularFont](https://reference.aspose.com/slides/fa/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) در [SwfOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/swfoptions/) مشخص می‌کنید جایگزین خواهد کرد تا از استفاده ناخواسته یک قلم جایگزین جلوگیری شود.