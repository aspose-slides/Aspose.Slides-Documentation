---
title: مدیریت هایپرلینک‌های ارائه در PHP
linktitle: مدیریت هایپرلینک
type: docs
weight: 20
url: /fa/php-java/manage-hyperlinks/
keywords:
- افزودن URL
- افزودن هایپرلینک
- ایجاد هایپرلینک
- قالب‌بندی هایپرلینک
- حذف هایپرلینک
- به‌روزرسانی هایپرلینک
- هایپرلینک متن
- هایپرلینک اسلاید
- هایپرلینک شکل
- هایپرلینک تصویر
- هایپرلینک ویدیو
- هایپرلینک قابل تغییر
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "به‌راحتی هایپرلینک‌ها را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای PHP از طریق Java مدیریت کنید — تعامل و جریان کار را در چند دقیقه بهبود دهید."
---
## **مقدمه**

یک هایپرلینک مرجعی به یک شیء یا داده یا مکانی در یک مطلب است. این‌ها هایپرلینک‌های رایج در ارائه‌های PowerPoint هستند:

* لینک‌ها به وب‌سایت‌ها داخل متن‌ها، اشکال یا رسانه‌ها
* لینک‌ها به اسلایدها

Aspose.Slides برای PHP از طریق Java به شما امکان انجام بسیاری از وظایف مرتبط با هایپرلینک‌ها در ارائه‌ها را می‌دهد.

{{% alert color="primary" %}} 
ممکن است بخواهید Aspose ساده، [ویرایشگر آنلاین رایگان PowerPoint](https://products.aspose.app/slides/fa/editor) را بررسی کنید.
{{% /alert %}} 

## **افزودن هایپرلینک‌های URL**

### **افزودن هایپرلینک‌های URL به متن**

این کد PHP به شما نشان می‌دهد چگونه یک هایپرلینک وب‌سایت را به یک متن اضافه کنید:
```php
  $presentation = new Presentation();
  try {
    $shape1 = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $shape1->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $portionFormat::setFontHeight(32);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **افزودن هایپرلینک‌های URL به اشکال یا قاب‌ها**

این کد نمونه به شما نشان می‌دهد چگونه یک هایپرلینک وب‌سایت را به یک شکل اضافه کنید:
```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);
    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **افزودن هایپرلینک‌های URL به رسانه‌ها**

Aspose.Slides به شما امکان افزودن هایپرلینک به تصاویر، فایل‌های صوتی و ویدئویی را می‌دهد.

این کد نمونه به شما نشان می‌دهد چگونه یک هایپرلینک به یک **تصویر** اضافه کنید:
```php
  $pres = new Presentation();
  try {
    # افزودن تصویر به ارائه
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # ایجاد فریم تصویر در اسلاید 1 بر اساس تصویر قبلاً افزوده شده
    $pictureFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pictureFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $pictureFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

این کد نمونه به شما نشان می‌دهد چگونه یک هایپرلینک به یک **فایل صوتی** اضافه کنید:
```php
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "audio.mp3"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $audio = $pres->getAudios()->addAudio($bytes);

    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->addAudioFrameEmbedded(10, 10, 100, 100, $audio);
    $audioFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $audioFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

این کد نمونه به شما نشان می‌دهد چگونه یک هایپرلینک به یک **ویدئو** اضافه کنید:
```php
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "video.avi"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $video = $pres->getVideos()->addVideo($bytes);

    $videoFrame = $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 100, 100, $video);
    $videoFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $videoFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert  title="Tip"  color="primary"  %}} 
ممکن است بخواهید *[مدیریت OLE](/slides/fa/php-java/manage-ole/)* را ببینید.
{{% /alert %}}

## **استفاده از هایپرلینک‌ها برای ایجاد فهرست مطالب**

از آنجا که هایپرلینک‌ها به شما امکان افزودن مرجع به اشیاء یا مکان‌ها را می‌دهند، می‌توانید از آن‌ها برای ایجاد فهرست مطالب استفاده کنید.

این کد نمونه به شما نشان می‌دهد چگونه یک فهرست مطالب با هایپرلینک‌ها ایجاد کنید:
```php
  $pres = new Presentation();
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    $secondSlide = $pres->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());
    $contentTable = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $contentTable->getFillFormat()->setFillType(FillType::NoFill);
    $contentTable->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $contentTable->getTextFrame()->getParagraphs()->clear();
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");
    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);
    $paragraph->getPortions()->add($linkPortion);
    $contentTable->getTextFrame()->getParagraphs()->add($paragraph);
    $pres->save("link_to_slide.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **قالب‌بندی هایپرلینک‌ها**

### **رنگ**

با متد [setColorSource](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlink/setcolorsource/) در کلاس [Hyperlink](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlink/) می‌توانید رنگ هایپرلینک‌ها را تنظیم کنید و همچنین اطلاعات رنگ را از هایپرلینک‌ها دریافت کنید. این ویژگی برای اولین بار در PowerPoint 2019 معرفی شد، بنابراین تغییرات مربوط به این خاصیت در نسخه‌های قدیمی‌تر PowerPoint اعمال نمی‌شود.

این کد نمونه یک عمل را نشان می‌دهد که در آن هایپرلینک‌های با رنگ‌های مختلف به یک اسلاید اضافه شدند:
```php
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $shape1->addTextFrame("This is a sample of colored hyperlink.");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setColorSource(HyperlinkColorSource->PortionFormat);
    $portionFormat::getFillFormat()->setFillType(FillType::Solid);
    $portionFormat::getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $shape2 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $shape2->addTextFrame("This is a sample of usual hyperlink.");
    $shape2->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $pres->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **حذف هایپرلینک‌ها از ارائه‌ها**

### **حذف هایپرلینک‌ها از متن**

این کد PHP به شما نشان می‌دهد چگونه هایپرلینک را از یک متن در اسلاید ارائه حذف کنید:
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    foreach($slide->getShapes() as $shape) {
      $autoShape = $shape;
      if (!java_is_null($autoShape)) {
        foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
          foreach($paragraph->getPortions() as $portion) {
            $portion->getPortionFormat()->getHyperlinkManager()->removeHyperlinkClick();
          }
        }
      }
    }
    $pres->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **حذف هایپرلینک‌ها از اشکال یا قاب‌ها**

این کد PHP به شما نشان می‌دهد چگونه هایپرلینک را از یک شکل در اسلاید ارائه حذف کنید:
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    foreach($slide->getShapes() as $shape) {
      $shape->getHyperlinkManager()->removeHyperlinkClick();
    }
    $pres->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **هایپرلینک قابل تغییر**

کلاس [Hyperlink](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlink/) قابل تغییر است. با استفاده از این کلاس می‌توانید مقادیر این خصوصیات را تغییر دهید:

- [Hyperlink.setTargetFrame(String)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlink/settargetframe/)
- [Hyperlink.setTooltip(String)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlink/settooltip/)
- [Hyperlink.setHistory(boolean)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlink/sethistory/)
- [Hyperlink.setHighlightClick(boolean)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlink/sethighlightclick/)
- [Hyperlink.setStopSoundOnClick(boolean)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlink/setstopsoundonclick/)

این قطعه کد نشان می‌دهد چگونه یک هایپرلینک به اسلاید اضافه کنید و بعداً ابزارنمای آن را ویرایش کنید:
```php
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $shape1->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $portionFormat::setFontHeight(32);
    $pres->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ویژگی‌های پشتیبانی‌شده در IHyperlinkQueries**

می‌توانید [HyperlinkQueries](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlinkqueries/) را از یک ارائه، اسلاید یا متنی که برای آن هایپرلینک تعریف شده است، دسترسی داشته باشید.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/gethyperlinkqueries/)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/gethyperlinkqueries/)

کلاس [HyperlinkQueries](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlinkqueries/) این متدها و ویژگی‌ها را پشتیبانی می‌کند:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/)

## **سؤالات متداول**

**چگونه می‌توانم ناوبری داخلی نه فقط به یک اسلاید، بلکه به یک «بخش» یا اولین اسلاید یک بخش ایجاد کنم؟**

بخش‌ها در PowerPoint گروه‌بندی‌ای از اسلایدها هستند؛ ناوبری به‌صورت فنی به یک اسلاید خاص اشاره می‌کند. برای «ناوبری به یک بخش»، معمولاً به اولین اسلاید آن بخش لینک می‌دهید.

**آیا می‌توانم یک هایپرلینک به عناصر اسلاید مستر اضافه کنم تا در تمام اسلایدها کار کند؟**

بله. عناصر اسلاید مستر و چیدمان از هایپرلینک پشتیبانی می‌کنند. این لینک‌ها در اسلایدهای فرزند ظاهر می‌شوند و در حین نمایش اسلاید قابلیت کلیک دارند.

**آیا هایپرلینک‌ها هنگام خروجی گرفتن به PDF، HTML، تصاویر یا ویدئو حفظ می‌شوند؟**

در [PDF](/slides/fa/php-java/convert-powerpoint-to-pdf/) و [HTML](/slides/fa/php-java/convert-powerpoint-to-html/) بله—لینک‌ها عموماً حفظ می‌شوند. هنگام خروجی به [تصاویر](/slides/fa/php-java/convert-powerpoint-to-png/) و [ویدئو](/slides/fa/php-java/convert-powerpoint-to-video/) قابلیت کلیک شدن منتقل نمی‌شود زیرا این فرمت‌ها (فریم‌های رستر/ویدئو) از هایپرلینک پشتیبانی نمی‌کنند.