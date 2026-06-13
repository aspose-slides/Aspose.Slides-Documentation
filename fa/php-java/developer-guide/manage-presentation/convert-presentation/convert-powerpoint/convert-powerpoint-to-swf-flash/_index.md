---
title: تبدیل ارائه‌های PowerPoint به SWF Flash در PHP
linktitle: PowerPoint به SWF
type: docs
weight: 80
url: /fa/php-java/convert-powerpoint-to-swf-flash/
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
- صادر کردن PPT به SWF
- صادر کردن PPTX به SWF
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "تبدیل PowerPoint (PPT/PPTX) به SWF Flash در PHP با Aspose.Slides. نمونه‌های کد قدم به قدم، خروجی سریع و با کیفیت، بدون اتوماسیون PowerPoint."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه می‌توان ارائه‌های PowerPoint را با استفاده از Aspose.Slides به فرمت SWF تبدیل کرد. همچنین نشان می‌دهد که چگونه می‌توان یک ارائه را با استفاده از روش [Presentation::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/save/) به فایل SWF ذخیره کرد و خروجی را با [SwfOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/swfoptions/) پیکربندی کرد، از جمله تنظیمات نمایشگر و چیدمان یادداشت‌ها یا نظرات.

## **تبدیل ارائه‌ها به فلش**

متد [save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/save/) که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ارائه شده است می‌تواند برای تبدیل کل ارائه به یک سند **SWF** استفاده شود. مثال زیر نشان می‌دهد که چگونه می‌توان یک ارائه را با استفاده از گزینه‌های ارائه‌شده توسط کلاس [SWFOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/swfoptions/) به سند **SWF** تبدیل کرد. همچنین می‌توانید با استفاده از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/notescommentslayoutingoptions/) نظرات را در SWF تولید شده گنجانده کنید.

```php
  $pres = new Presentation("Sample.pptx");
  try {
    $swfOptions = new SwfOptions();
    $swfOptions->setViewerIncluded(false);
    $swfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # ذخیره ارائه
    $pres->save("Sample.swf", SaveFormat::Swf, $swfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **پرسش‌های متداول**

**آیا می‌توانم اسلایدهای مخفی را در SWF گنجانده کنم؟**

بله. با استفاده از متد [setShowHiddenSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/swfoptions/setshowhiddenslides/) در [SwfOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/swfoptions/) می‌توانید اسلایدهای مخفی را فعال کنید. به طور پیش‌فرض، اسلایدهای مخفی صادر نمی‌شوند.

**چگونه می‌توانم فشرده‌سازی و اندازه نهایی SWF را کنترل کنم؟**

از متد [setCompressed](https://reference.aspose.com/slides/fa/php-java/aspose.slides/swfoptions/setcompressed/) و [adjust JPEG quality](https://reference.aspose.com/slides/fa/php-java/aspose.slides/swfoptions/setjpegquality/) استفاده کنید تا بین اندازه فایل و کیفیت تصویر تعادل برقرار کنید.

**متد 'setViewerIncluded' به چه منظوری است و چه موقع باید آن را غیرفعال کنم؟**

[setViewerIncluded](https://reference.aspose.com/slides/fa/php-java/aspose.slides/swfoptions/setviewerincluded/) یک رابط کاربری پخش‌کننده توکار (کنترل‌های ناوبری، پنل‌ها، جستجو) را اضافه می‌کند. اگر قصد استفاده از پخش‌کننده خودتان را دارید یا به یک چارچوب SWF بدون UI نیاز دارید، آن را غیرفعال کنید.

**اگر یک فونت منبع در دستگاه خروجی موجود نباشد چه می‌شود؟**

Aspose.Slides فونت را با فونتی که از طریق [setDefaultRegularFont](https://reference.aspose.com/slides/fa/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) در [SwfOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/swfoptions/) مشخص می‌کنید جایگزین می‌کند تا از استفاده ناخواسته از فونت پیش‌فرض جلوگیری شود.