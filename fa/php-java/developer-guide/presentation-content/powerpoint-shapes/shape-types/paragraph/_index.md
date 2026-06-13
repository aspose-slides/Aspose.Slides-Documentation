---
title: دریافت حدود پاراگراف از ارائه‌ها در PHP
linktitle: پاراگراف
type: docs
weight: 60
url: /fa/php-java/paragraph/
keywords:
- حدود پاراگراف
- حدود بخش متنی
- مختصات پاراگراف
- مختصات بخش
- اندازه پاراگراف
- اندازه بخش متنی
- فریم متن
- پاورپوینت
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه حدود پاراگراف و بخش‌های متنی را در Aspose.Slides برای PHP از طریق Java بازیابی کنید تا موقعیت متن را در ارائه‌های PowerPoint بهینه کنید."
---
## **بررسی کلی**

این مقاله نحوه دریافت حدود، اندازه و مختصات پاراگراف‌ها و بخش‌های متنی در Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه با استفاده از `getRect()` مستطیل یک پاراگراف را در یک `TextFrame` دریافت کنید، چگونه مختصات پاراگراف و بخش را در چارچوب متنی سلول جدول دریافت کنید، و جزئیات مهمی مانند واحدهای اندازه‌گیری، تأثیر شکست متن بر حدود، تبدیل پیکسل و مقادیر قالب‌بندی مؤثر پاراگراف را برجسته می‌کند.

## **دریافت مختصات پاراگراف و بخش در یک TextFrame**
با استفاده از Aspose.Slides برای PHP از طریق Java، توسعه‌دهندگان اکنون می‌توانند مختصات مستطیلی پاراگراف را در مجموعه پاراگراف‌های یک TextFrame دریافت کنند. همچنین امکان دریافت [مختصات بخش](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/#getCoordinates) در مجموعه بخش‌های یک پاراگراف را فراهم می‌کند. در این بخش، با کمک یک مثال نشان خواهیم داد چگونه مختصات مستطیلی پاراگراف را همراه با موقعیت بخش داخل پاراگراف به دست آوریم.

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textFrame = $shape->getTextFrame();
  foreach($textFrame->getParagraphs() as $paragraph) {
    foreach($paragraph->getPortions() as $portion) {
      $point = $portion->getCoordinates();
    }
  }
```

## **دریافت مختصات مستطیلی یک پاراگراف**
با استفاده از روش [**getRect()**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/#getRect) توسعه‌دهندگان می‌توانند مستطیل حدود پاراگراف را دریافت کنند.

```php
  $pres = new Presentation("HelloWorld.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    $rect = $textFrame->getParagraphs()->get_Item(0)->getRect();
    echo("X: " . $rect->$x . " Y: " . $rect->$y . " Width: " . $rect->$width . " Height: " . $rect->$height);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **دریافت اندازه پاراگراف و بخش داخل TextFrame سلول جدول**
برای دریافت اندازه و مختصات [Portion](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Portion) یا [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Paragraph) در یک TextFrame سلول جدول، می‌توانید از روش‌های [Portion::getRect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/#getRect) و [Paragraph::getRect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/#getRect) استفاده کنید.

این کد نمونه عملیات توصیف شده را نشان می‌دهد:

```php
  $pres = new Presentation("source.pptx");
  try {
    $tbl = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $cell = $tbl->getRows()->get_Item(1)->get_Item(1);
    $x = $tbl->getX() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetX();
    $y = $tbl->getY() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetY();
    foreach($cell->getTextFrame()->getParagraphs() as $para) {
      if ($para->getText()->equals("")) {
        continue;
      }
      $rect = $para->getRect();
      $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
      $shape->getFillFormat()->setFillType(FillType::NoFill);
      $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
      $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
      foreach($para->getPortions() as $portion) {
        if ($portion->getText()->contains("0")) {
          $rect = $portion->getRect();
          $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
          $shape->getFillFormat()->setFillType(FillType::NoFill);
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سوالات متداول**

**مختصات برگشت‌گرفته‌شده برای پاراگراف و بخش‌های متنی بر حسب چه واحدی اندازه‌گیری می‌شوند؟**

در واحد نقطه (points) است، به طوری که 1 اینچ = 72 نقطه. این برای تمام مختصات و ابعاد روی اسلاید اعمال می‌شود.

**آیا شکسته شدن متن (wrapping) بر حدود پاراگراف تاثیر می‌گذارد؟**

بله. اگر [wrapping](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/setwraptext/) در [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) فعال باشد، متن برای متناسب شدن با عرض ناحیه شکسته می‌شود که باعث تغییر حدود واقعی پاراگراف می‌شود.

**آیا می‌توان مختصات پاراگراف را به‌طور قابل اعتماد به پیکسل‌ها در تصویر خروجی نگاشت؟**

بله. برای تبدیل نقطه به پیکسل از فرمول استفاده کنید: pixels = points × (DPI / 72). نتیجه بسته به DPI انتخاب‌شده برای رندر/خروجی متفاوت است.

**چگونه می‌توان پارامترهای قالب‌بندی «موثر» پاراگراف را با در نظر گرفتن وراثت سبک دریافت کرد؟**

از [ساختار داده قالب‌بندی مؤثر پاراگراف](/slides/fa/php-java/shape-effective-properties/) استفاده کنید؛ این ساختار مقادیر نهایی یکپارچه برای تورفتگی‌ها، فاصله‌ها، بسته شدن متن، RTL و موارد دیگر را بر می‌گرداند.