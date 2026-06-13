---
title: مدیریت کنترل‌های ActiveX در ارائه‌ها با استفاده از PHP
linktitle: ActiveX
type: docs
weight: 80
url: /fa/php-java/activex/
keywords:
- ActiveX
- کنترل ActiveX
- مدیریت ActiveX
- افزودن ActiveX
- تغییر ActiveX
- پخش‌کننده رسانه
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "بیاموزید چگونه Aspose.Slides برای PHP از طریق Java از ActiveX برای خودکارسازی و بهبود ارائه‌های PowerPoint استفاده می‌کند و به توسعه‌دهندگان کنترل قدرتمندی بر روی اسلایدها می‌دهد."
---
## **معرفی**

کنترل‌های ActiveX در ارائه‌ها استفاده می‌شوند. Aspose.Slides برای PHP از طریق Java به شما امکان افزودن و مدیریت کنترل‌های ActiveX را می‌دهد، اما نسبت به اشکال معمولی ارائه کمی پیچیده‌تر هستند. ما پشتیبانی از افزودن کنترل Active Media Player را در Aspose.Slides پیاده‌سازی کردیم. توجه داشته باشید که کنترل‌های ActiveX شکل نیستند؛ آن‌ها بخشی از [ShapeCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/) ارائه نیستند. آن‌ها بخشی از [ControlCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/controlcollection/) جداگانه هستند. در این موضوع، نحوه کار با آنها را نشان می‌دهیم.

## **افزودن یک کنترل ActiveX Media Player به اسلاید**
برای افزودن یک کنترل Media Player ActiveX، این کارها را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید و یک ارائه خالی تولید کنید.
2. اسلاید هدف را در [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) دسترسی پیدا کنید.
3. کنترل Media Player ActiveX را با استفاده از متد [addControl](https://reference.aspose.com/slides/fa/php-java/aspose.slides/controlcollection/addcontrol/) که توسط [ControlCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/controlcollection/) در دسترس است، اضافه کنید.
4. به کنترل Media Player ActiveX دسترسی پیدا کنید و مسیر ویدیو را با استفاده از ویژگی‌های آن تنظیم کنید.
5. ارائه را به عنوان فایل PPTX ذخیره کنید.

این کد نمونه، بر پایهٔ مراحل فوق، نحوه افزودن کنترل Media Player ActiveX به یک اسلاید را نشان می‌دهد:

```php
  # یک نمونه خالی از ارائه ایجاد کنید
  $pres = new Presentation();
  try {
    # افزودن کنترل ActiveX Media Player
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # دسترسی به کنترل ActiveX Media Player و تعیین مسیر ویدیو
    $pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL", "Wildlife.wmv");
    # ذخیره ارائه
    $pres->save("Output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تغییر یک کنترل ActiveX**
{{% alert color="primary" %}} 

Aspose.Slides برای PHP از طریق Java نسخه 7.1.0 و نسخه‌های جدیدتر با اجزایی برای مدیریت کنترل‌های ActiveX مجهز شده است. می‌توانید به کنترل ActiveX که قبلاً به ارائه شما اضافه شده دسترسی پیدا کنید و از طریق ویژگی‌های آن آن را اصلاح یا حذف کنید.

{{% /alert %}} 

برای مدیریت یک کنترل ساده ActiveX مانند یک جعبه متن و دکمهٔ فرمان ساده در یک اسلاید، این کارها را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید و ارائه‌ای که شامل کنترل‌های ActiveX است بارگذاری کنید.
2. یک مرجع اسلاید را بر اساس ایندکس آن دریافت کنید.
3. کنترل‌های ActiveX موجود در اسلاید را با دسترسی به [ControlCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/controlcollection/) دسترسی پیدا کنید.
4. با استفاده از شیء [Control](https://reference.aspose.com/slides/fa/php-java/aspose.slides/control/) به کنترل ActiveX TextBox1 دسترسی پیدا کنید.
5. خواص کنترل ActiveX TextBox1 که شامل متن، فونت، ارتفاع فونت و موقعیت فریم است را تغییر دهید.
6. کنترل دوم به نام CommandButton1 را دسترسی پیدا کنید.
7. عنوان دکمه، فونت و موقعیت آن را تغییر دهید.
8. موقعیت فریم‌های کنترل‌های ActiveX را جابجا کنید.
9. ارائه اصلاح شده را به فایل PPTX بنویسید.

این کد نمونه، بر پایهٔ مراحل فوق، نحوه مدیریت یک کنترل ساده ActiveX را نشان می‌دهد: 

```php
  # دسترسی به ارائه با کنترل‌های ActiveX
  $pres = new Presentation("ActiveX.pptm");
  try {
    # دسترسی به اولین اسلاید در ارائه
    $slide = $pres->getSlides()->get_Item(0);
    # تغییر متن TextBox
    $control = $slide->getControls()->get_Item(0);
    if (!java_is_null($control->getName()->equalsIgnoreCase("TextBox1") && $control->getProperties())) {
      $newText = "Changed text";
      $control->getProperties()->set_Item("Value", $newText);
      # تغییر تصویر جایگزین. PowerPoint این تصویر را هنگام فعال‌سازی ActiveX جایگزین می‌کند,
      # بنابراین گاهی اجازه دارد تصویر بدون تغییر بماند.
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->window);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $graphics->drawString($newText, 10, 20);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # تغییر عنوان دکمه
    $control = $pres->getSlides()->get_Item(0)->getControls()->get_Item(1);
    if (!java_is_null($control->getName()->equalsIgnoreCase("CommandButton1") && $control->getProperties())) {
      $newCaption = "Show MessageBox";
      $control->getProperties()->set_Item("Caption", $newCaption);
      # تغییر جایگزین
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->control);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $metrics = $graphics->getFontMetrics($font);
      $graphics->drawString($newCaption, $image->getWidth() - $metrics->stringWidth($newCaption) / 2, 20);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # جابجا کردن 100 نقطه پایین
    foreach($pres->getSlides()->get_Item(0)->getControls() as $ctl) {
      $frame = $ctl->getFrame();
      $ctl->setFrame(new ShapeFrame($frame->getX(), $frame->getY() + 100, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation()));
    }
    $pres->save("withActiveX-edited_java.pptm", SaveFormat::Pptm);
    # حذف کنترل‌ها
    $pres->getSlides()->get_Item(0)->getControls()->clear();
    $pres->save("withActiveX-cleared_java.pptm", SaveFormat::Pptm);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **پرسش‌های متداول**

**آیا Aspose.Slides کنترل‌های ActiveX را هنگام خواندن و ذخیره مجدد حفظ می‌کند اگر نتوانند در زمان اجرا Java اجرا شوند؟**

بله. Aspose.Slides آن‌ها را به عنوان بخشی از ارائه در نظر می‌گیرد و می‌تواند ویژگی‌ها و فریم‌هایشان را بخواند/تغییر دهد؛ اجرای خود کنترل‌ها برای حفظ آن‌ها لازم نیست.

**کنترل‌های ActiveX چگونه با اشیاء OLE در یک ارائه متفاوت هستند؟**

کنترل‌های ActiveX کنترل‌های تعاملی مدیریت‌شده هستند (دکمه‌ها، جعبه‌های متن، پخش‌کنندهٔ رسانه)، در حالی که [OLE](/slides/fa/php-java/manage-ole/) به اشیای برنامهٔ جاساز شده اشاره دارد (به‌عنوان مثال یک برگهٔ Excel). آن‌ها به‌صورت متفاوتی ذخیره و مدیریت می‌شوند و مدل‌های ویژگی متفاوتی دارند.

**آیا رویدادهای ActiveX و ماکروهای VBA در صورتی که فایل توسط Aspose.Slides اصلاح شده باشد کار می‌کنند؟**

Aspose.Slides نشانه‌گذاری و متادیتای موجود را حفظ می‌کند؛ اما رویدادها و ماکروها تنها در PowerPoint روی ویندوز و زمانی که امنیت اجازه دهد اجرا می‌شوند. این کتابخانه VBA را اجرا نمی‌کند.