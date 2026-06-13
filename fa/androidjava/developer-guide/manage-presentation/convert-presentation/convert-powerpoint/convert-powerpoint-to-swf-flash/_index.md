---
title: تبدیل ارائه‌های PowerPoint به فرمت SWF Flash در اندروید
linktitle: PowerPoint به SWF
type: docs
weight: 80
url: /fa/androidjava/convert-powerpoint-to-swf-flash/
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
- Android
- Java
- Aspose.Slides
description: "تبدیل PowerPoint (PPT/PPTX) به فرمت SWF Flash در Java با Aspose.Slides برای Android. نمونه‌های کد گام‌به‌گام، خروجی سریع با کیفیت، بدون نیاز به خودکارسازی PowerPoint."
---
## **بررسی کلی**

این مقاله نحوه تبدیل ارائه‌های PowerPoint به فرمت SWF را با استفاده از Aspose.Slides توضیح می‌دهد. نشان می‌دهد چگونه یک ارائه را به عنوان فایل SWF با استفاده از متد [Presentation.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) ذخیره کنید و چگونه خروجی را با [SwfOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/swfoptions/) پیکربندی کنید، از جمله تنظیمات نمایشگر و چیدمان یادداشت‌ها یا نظرات.

## **تبدیل PPT(X) به SWF**
متد [Save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ارائه شده است می‌تواند برای تبدیل کل ارائه به سند **SWF** استفاده شود. مثال زیر نشان می‌دهد چگونه یک ارائه را به سند **SWF** تبدیل کنید با استفاده از گزینه‌های ارائه‌شده توسط کلاس [**SWFOptions**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SwfOptions). همچنین می‌توانید نظرات را در SWF تولید شده با استفاده از کلاس [**ISWFOptions**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISwfOptions) و رابط [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions) گنجانید.

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // در حال ذخیره‌سازی ارائه
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**آیا می‌توانم اسلایدهای مخفی را در SWF گنجاند؟**

بله. اسلایدهای مخفی را با استفاده از متد [setShowHiddenSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) در [SwfOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/swfoptions/) فعال کنید. به طور پیش‌فرض، اسلایدهای مخفی صادر نمی‌شوند.

**چگونه می‌توانم فشرده‌سازی و اندازه نهایی SWF را کنترل کنم؟**

از متد [setCompressed](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/swfoptions/#setCompressed-boolean-) و [adjust JPEG quality](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/swfoptions/#setJpegQuality-int-) استفاده کنید تا میان حجم فایل و کیفیت تصویر تعادل برقرار شود.

**'setViewerIncluded' برای چه منظوری است و چه زمانی باید آن را غیرفعال کنم؟**

[setViewerIncluded](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) یک رابط کاربری پخش‌کننده توکار (کنترل‌های ناوبری، پنل‌ها، جستجو) را اضافه می‌کند. اگر قصد دارید از پخش‌کننده خود استفاده کنید یا به یک چارچوب SWF بدون واسط کاربری نیاز دارید، آن را غیرفعال کنید.

**اگر یک فونت منبع در ماشین صادر کننده موجود نباشد چه می‌شود؟**

Aspose.Slides فونتی که با استفاده از [setDefaultRegularFont](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) در [SwfOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/swfoptions/) مشخص کرده‌اید را جایگزین می‌کند تا از بازگشت ناخواسته جلوگیری شود.