---
title: تبدیل PPT و PPTX به JPG در PHP
linktitle: PowerPoint به JPG
type: docs
weight: 60
url: /fa/php-java/convert-powerpoint-to-jpg/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به JPG
- ارائه به JPG
- اسلاید به JPG
- PPT به JPG
- PPTX به JPG
- ذخیره PowerPoint به عنوان JPG
- ذخیره ارائه به عنوان JPG
- ذخیره اسلاید به عنوان JPG
- ذخیره PPT به عنوان JPG
- ذخیره PPTX به عنوان JPG
- صدور PPT به JPG
- صدور PPTX به JPG
- PHP
- Aspose.Slides
description: "اسلایدهای PowerPoint (PPT, PPTX) را به تصاویر JPG با کیفیت بالا در PHP با Aspose.Slides برای PHP با استفاده از مثال‌های کد سریع و قابل اطمینان تبدیل کنید."
---
## **مقدمه**

تبدیل ارائه‌های PowerPoint و OpenDocument به تصاویر JPG به اشتراک‌گذاری اسلایدها، بهبود عملکرد و افزودن محتوا به وب‌سایت‌ها یا برنامه‌ها کمک می‌کند. Aspose.Slides به شما امکان تبدیل فایل‌های PPTX، PPT و ODP به تصاویر JPEG با کیفیت بالا را می‌دهد. این راهنما روش‌های مختلف تبدیل را توضیح می‌دهد.

با این ویژگی‌ها، پیاده‌سازی نمایشگر ارائه خود و ایجاد تصویر کوچک برای هر اسلاید آسان می‌شود. این می‌تواند مفید باشد اگر بخواهید اسلایدهای ارائه را در برابر کپی محافظت کنید یا ارائه را در حالت فقط‑خواندنی نمایش دهید. Aspose.Slides به شما امکان می‌دهد کل ارائه یا اسلاید خاصی را به فرمت‌های تصویری تبدیل کنید.

## **تبدیل PowerPoint PPT/PPTX به JPG**

مراحل تبدیل PPT/PPTX به JPG به شرح زیر است:

1. یک نمونه از نوع [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.  
2. شیء اسلاید از نوع [Slide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/) را از مجموعهٔ [Presentation::getSlides()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation#getSlides--) دریافت کنید.  
3. تصویر کوچک هر اسلاید را ایجاد کرده و سپس آن را به JPG تبدیل کنید. روش [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/#getImage) برای دریافت تصویر کوچک یک اسلاید استفاده می‌شود. متد [getImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/#getImage) باید از اسلاید مورد نیاز نوع [Slide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/) فراخوانی شود و مقیاس‌های تصویر کوچک نتیجه به متد پاس داده می‌شوند.  
4. پس از به‌دست آوردن تصویر کوچک اسلاید، متد [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) را از شیء تصویر کوچک فراخوانی کنید. نام فایل نتیجه و فرمت تصویر را به آن پاس دهید.  

{{% alert color="primary" %}}
**نکته**: تبدیل PPT/PPTX به JPG با تبدیل به انواع دیگر در API Aspose.Slides متفاوت است. برای انواع دیگر معمولاً از متد [**Presentation::Save(String fname, int format, SaveOptions options)**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/save/) استفاده می‌کنید، اما در اینجا باید از متد [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) استفاده کنید.  
{{% /alert %}} 

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    foreach($pres->getSlides() as $sld) {
      # ایجاد تصویر با مقیاس کامل
      $slideImage = $sld->getImage(1.0, 1.0);
      # ذخیره تصویر بر روی دیسک با فرمت JPEG
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تبدیل PowerPoint PPT/PPTX به JPG با ابعاد سفارشی**

برای تغییر ابعاد تصویر کوچک و تصویر JPG حاصل، می‌توانید مقادیر *ScaleX* و *ScaleY* را با پاس کردن آن‌ها به متدهای [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/#getImage) تنظیم کنید:  

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    # تعریف ابعاد
    $desiredX = 1200;
    $desiredY = 800;
    # دریافت مقادیر مقیاس‌دار X و Y
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    foreach($pres->getSlides() as $sld) {
      # ایجاد تصویر با مقیاس کامل
      $slideImage = $sld->getImage($ScaleX, $ScaleY);
      # ذخیره تصویر بر روی دیسک با فرمت JPEG
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **رندر نظرات هنگام ذخیره اسلایدها به عنوان تصویر**

Aspose.Slides برای PHP از طریق Java قابلیتی فراهم می‌کند که به شما امکان می‌دهد نظرات موجود در اسلایدهای یک ارائه را هنگام تبدیل آن اسلایدها به تصاویر رندر کنید. این کد PHP عمل موردنظر را نشان می‌دهد:  

```php
  $pres = new Presentation("presentation.pptx");
  try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomTruncated);
    $opts = new RenderingOptions();
    $opts->setSlidesLayoutOptions($notesOptions);
    foreach($pres->getSlides() as $sld) {
      $slideImage = $sld->getImage($opts, new Java("java.awt.Dimension", 740, 960));
      try {
        $slideImage->save(String->format("Slide_%d.png", $sld->getSlideNumber()));
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="نکته" color="primary" %}}
Aspose یک برنامهٔ وب [FREE Collage web app](https://products.aspose.app/slides/fa/collage) رایگان ارائه می‌دهد. با استفاده از این سرویس آنلاین می‌توانید تصاویر [JPG به JPG](https://products.aspose.app/slides/fa/collage/jpg) یا PNG به PNG را ترکیب کنید، [photo grids](https://products.aspose.app/slides/fa/collage/photo-grid) ایجاد کنید و غیره.  

با استفاده از همان اصول شرح داده‌شده در این مقاله، می‌توانید تصاویر را از یک فرمت به فرمت دیگر تبدیل کنید. برای اطلاعات بیشتر، به این صفحات مراجعه کنید: تبدیل [image to JPG](https://products.aspose.com/slides/fa/php-java/conversion/image-to-jpg/); تبدیل [JPG to image](https://products.aspose.com/slides/fa/php-java/conversion/jpg-to-image/); تبدیل [JPG to PNG](https://products.aspose.com/slides/fa/php-java/conversion/jpg-to-png/), تبدیل [PNG to JPG](https://products.aspose.com/slides/fa/php-java/conversion/png-to-jpg/); تبدیل [PNG to SVG](https://products.aspose.com/slides/fa/php-java/conversion/png-to-svg/), تبدیل [SVG to PNG](https://products.aspose.com/slides/fa/php-java/conversion/svg-to-png/).  
{{% /alert %}}

## **سؤالات متداول**

**آیا این روش از تبدیل دسته‌ای پشتیبانی می‌کند؟**  
بله، Aspose.Slides امکان تبدیل دسته‌ای چندین اسلاید به JPG را در یک عملیات فراهم می‌کند.  

**آیا تبدیل از SmartArt، نمودارها و سایر اشیای پیچیده پشتیبانی می‌کند؟**  
بله، Aspose.Slides تمام محتوا شامل SmartArt، نمودارها، جدول‌ها، اشکال و موارد دیگر را رندر می‌کند. با این حال، دقت رندر ممکن است نسبت به PowerPoint کمی متفاوت باشد، به‌ویژه هنگام استفاده از قلم‌های سفارشی یا غایب.  

**آیا محدودیتی برای تعداد اسلایدهایی که می‌توان پردازش کرد وجود دارد؟**  
Aspose.Slides خود هیچ محدودیت سخت‌گیرانه‌ای بر تعداد اسلایدهایی که می‌توانید پردازش کنید اعمال نمی‌کند. با این حال، ممکن است هنگام کار با ارائه‌های بزرگ یا تصاویر با وضوح بالا با خطای کمبود حافظه مواجه شوید.  

## **همچنین ببینید**

سایر گزینه‌های تبدیل PPT/PPTX به تصویر را ببینید مانند:

- [تبدیل PPT/PPTX به SVG](/slides/fa/php-java/render-a-slide-as-an-svg-image/).