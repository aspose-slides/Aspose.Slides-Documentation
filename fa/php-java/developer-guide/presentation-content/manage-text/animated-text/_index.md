---
title: "انیمیشن متن پاورپوینت در PHP"
linktitle: "متن متحرک"
type: docs
weight: 60
url: /fa/php-java/animated-text/
keywords:
- متن متحرک
- انیمیشن متن
- پاراگراف متحرک
- انیمیشن پاراگراف
- افکت انیمیشن
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "ایجاد متن متحرک پویا در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای PHP از طریق Java، با نمونه‌های کد بهینه و آسان برای پیگیری."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه می‌توانید با متن‌های متحرک در Aspose.Slides کار کنید، با اعمال افکت‌های انیمیشن به پاراگراف‌های جداگانه و دریافت افکت‌هایی که قبلاً به پاراگراف‌های موجود در یک قاب متن اختصاص داده شده‌اند. تمرکز این مقاله بر روش‌های API مورد استفاده برای افزودن انیمیشن در سطح پاراگراف و بررسی افکت‌های انیمیشن موجود در پاراگراف‌ها در یک ارائه است.

## **افزودن افکت‌های انیمیشن به پاراگراف‌ها**

ما متد [**addEffect()**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) را به کلاس [**Sequence**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Sequence) اضافه کردیم. این متد به شما امکان می‌دهد تا افکت‌های انیمیشن را به یک پاراگراف تک اضافه کنید. این کد نمونه نشان می‌دهد که چگونه می‌توانید یک افکت انیمیشن را به یک پاراگراف اضافه کنید:

```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # پاراگراف را برای افزودن افکت انتخاب کنید
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # افزودن افکت انیمیشن Fly به پاراگراف انتخاب شده
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **دریافت افکت‌های انیمیشن پاراگراف‌ها**

ممکن است بخواهید افکت‌های انیمیشنی که به یک پاراگراف اضافه شده‌اند را پیدا کنید—به عنوان مثال، در یک سناریو ممکن است بخواهید افکت‌های انیمیشن یک پاراگراف را به دست آورید زیرا قصد دارید آن افکت‌ها را به پاراگراف یا شکل دیگری اعمال کنید.

Aspose.Slides برای PHP از طریق Java به شما امکان می‌دهد تمام افکت‌های انیمیشن اعمال شده بر پاراگراف‌های موجود در یک قاب متن (شکل) را دریافت کنید. این کد نمونه نشان می‌دهد که چگونه می‌توانید افکت‌های انیمیشن یک پاراگراف را به دست آورید:

```php
  $pres = new Presentation("Presentation.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
      $effects = $sequence->getEffectsByParagraph($paragraph);
      if (java_values($Array->getLength($effects)) > 0) {
        echo("Paragraph \"" . $paragraph->getText() . "\" has " . $effects[0]->getType() . " effect.");
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **سوالات متداول**

**انیمیشن‌های متن چه تفاوتی با انتقالات اسلاید دارند و آیا می‌توان آنها را ترکیب کرد؟**

انیمیشن‌های متن رفتار اشیا را در طول زمان در یک اسلاید کنترل می‌کنند، در حالی که [transitions](/slides/fa/php-java/slide-transition/) نحوهٔ تغییر اسلایدها را تعیین می‌کنند. این دو مستقل هستند و می‌توانند همراه هم استفاده شوند؛ ترتیب پخش توسط جدول زمانی انیمیشن و تنظیمات انتقال تعیین می‌شود.

**آیا انیمیشن‌های متن هنگام خروجی به PDF یا تصویر حفظ می‌شوند؟**

خیر. PDF و تصاویر رستر ثابت هستند، بنابراین حالت واحدی از اسلاید را بدون حرکت می‌بینید. برای حفظ حرکت، از خروجی [video](/slides/fa/php-java/convert-powerpoint-to-video/) یا [HTML](/slides/fa/php-java/export-to-html5/) استفاده کنید.

**آیا انیمیشن‌های متن در طرح‌بندی‌ها و اسلاید مستر کار می‌کنند؟**

افکت‌های اعمال شده بر اشیای طرح‌بندی/مستر به اسلایدها ارث می‌رسند، اما زمان‌بندی و تعامل آنها با انیمیشن‌های سطح اسلاید به ترتیب نهایی روی اسلاید بستگی دارد.