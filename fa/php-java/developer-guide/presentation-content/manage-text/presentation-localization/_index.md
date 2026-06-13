---
title: خودکارسازی بومی‌سازی ارائه در PHP
linktitle: بومی‌سازی ارائه
type: docs
weight: 100
url: /fa/php-java/presentation-localization/
keywords:
- تغییر زبان
- بررسی املایی
- شناسه زبان
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "بومی‌سازی اسلایدهای PowerPoint و OpenDocument را با Aspose.Slides برای PHP از طریق Java به‌صورت خودکار انجام دهید، با استفاده از نمونه‌های کد عملی و نکات برای گسترش سریع جهانی."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه با استفاده از Aspose.Slides، شناسه `LanguageId` را برای متن در یک ارائه تنظیم کنید. این مقاله نشان می‌دهد چگونه یک ارائه را باز کنید، شکل متنی اضافه کنید، شناسه زبان را به یک بخش متن اختصاص دهید و نتیجه را به عنوان فایل PPTX ذخیره کنید.

## **تغییر زبان برای متن ارائه و شکل**
- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
- مرجع یک اسلاید را با استفاده از شاخص آن به دست آورید.
- یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) از نوع [Rectangle](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ShapeType#Rectangle) را به اسلاید اضافه کنید.
- متنی به TextFrame اضافه کنید.
- به متن [تنظیم شناسه زبان](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setLanguageId) اعمال کنید.
- ارائه را به عنوان فایل PPTX ذخیره کنید.

اجرای گام‌های فوق در مثال زیر نشان داده شده است.

```php
  $pres = new Presentation("test.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    $shape->addTextFrame("Text to apply spellcheck language");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLanguageId("en-EN");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سوالات متداول**

**آیا شناسه زبان ترجمه خودکار متن را فعال می‌کند؟**

خیر. [Language ID](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setLanguageId) در Aspose.Slides زبان را برای بررسی املایی و گرامری ذخیره می‌کند، اما متن را ترجمه یا تغییر نمی‌دهد. این یک متادیتا است که PowerPoint برای بررسی می‌فهمد.

**آیا شناسه زبان بر جداسازی واژه‌ها (هایفن‌گذاری) و شکست خط هنگام رندرینگ تأثیر می‌گذارد؟**

در Aspose.Slides، [language ID](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setLanguageId) برای بررسی است. کیفیت هایفن‌گذاری و شکست خط عمدتاً به در دسترس بودن [فونت‌های مناسب](/slides/fa/php-java/powerpoint-fonts/) و تنظیمات چیدمان/شکست خط برای سیستم نوشتاری وابسته است. برای اطمینان از رندرینگ صحیح، فونت‌های مورد نیاز را در دسترس قرار دهید، [قوانین جایگزینی فونت](/slides/fa/php-java/font-substitution/) را پیکربندی کنید و/یا [فونت‌ها را جاسازی](/slides/fa/php-java/embedded-font/) کنید.

**آیا می‌توانم زبان‌های مختلف را در یک پاراگراف واحد تنظیم کنم؟**

بله. [Language ID](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setLanguageId) در سطح بخش متن اعمال می‌شود، بنابراین یک پاراگراف می‌تواند چندین زبان با تنظیمات بررسی متفاوت را ترکیب کند.