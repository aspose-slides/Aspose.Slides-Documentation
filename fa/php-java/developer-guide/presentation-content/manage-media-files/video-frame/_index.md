---
title: "مدیریت فریم‌های ویدئویی در ارائه‌ها با استفاده از PHP"
linktitle: "فریم ویدئویی"
type: docs
weight: 10
url: /fa/php-java/video-frame/
keywords:
- "افزودن ویدئو"
- "ایجاد ویدئو"
- "جاسازی ویدئو"
- "استخراج ویدئو"
- "بازیابی ویدئو"
- "فریم ویدئو"
- "منبع وب"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "PHP"
- "Aspose.Slides"
description: "بیاموزید چگونه به‌صورت برنامه‌نویسی فریم‌های ویدئویی را در اسلایدهای PowerPoint و OpenDocument اضافه و استخراج کنید با استفاده از Aspose.Slides برای PHP از طریق Java. راهنمای سریع گام‌به‌گام."
---
## **معرفی**

یک ویدئوی به‌خوبی قرار داده‌شده در ارائه می‌تواند پیام شما را جذاب‌تر کند و سطح تعامل با مخاطبان را افزایش دهد.

PowerPoint امکان افزودن ویدئوها به یک اسلاید در یک ارائه را به دو روش فراهم می‌کند:

* اضافه یا جاسازی یک ویدئوی محلی (ذخیره‌شده بر روی دستگاه شما)
* افزودن یک ویدئوی آنلاین (از منبع وبی مانند یوتیوب).

برای این که بتوانید ویدئوها (اشیای ویدئویی) را به یک ارائه اضافه کنید، Aspose.Slides کلاس [Video](https://reference.aspose.com/slides/fa/php-java/aspose.slides/video/)، کلاس [VideoFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/videoframe/) و سایر انواع مرتبط را ارائه می‌دهد.

## **ایجاد فریم‌های ویدئوی جاسازی‌شده**

اگر فایل ویدئویی که می‌خواهید به اسلاید خود اضافه کنید به‌صورت محلی ذخیره شده باشد، می‌توانید یک فریم ویدئویی ایجاد کنید تا ویدئو را در ارائه خود جاسازی کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.  
1. از طریق اندیس آن، مرجع یک اسلاید را بدست آورید.  
1. یک شیء [Video](https://reference.aspose.com/slides/fa/php-java/aspose.slides/video/) اضافه کنید و مسیر فایل ویدئویی را به‌عنوان پارامتر پاس دهید تا ویدئو در ارائه جاسازی شود.  
1. یک شیء [VideoFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/videoframe/) اضافه کنید تا یک فریم برای ویدئو ایجاد شود.  
1. ارائه‌ی اصلاح‌شده را ذخیره کنید.  

این کد PHP نشان می‌دهد چگونه یک ویدئوی ذخیره‌شده محلی را به یک ارائه اضافه کنید:

```php
  # ایجاد نمونه از کلاس Presentation
  $pres = new Presentation("pres.pptx");
  try {
    # بارگذاری ویدئو
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # دریافت اولین اسلاید و افزودن فریم ویدئو
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # ذخیره‌سازی ارائه روی دیسک
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

به‌طور جایگزین، می‌توانید با پاس کردن مسیر فایل ویدئو مستقیماً به متد [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/addvideoframe/) یک ویدئو اضافه کنید:

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $vf = $sld->getShapes()->addVideoFrame(50, 150, 300, 150, "video1.avi");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ایجاد فریم‌های ویدئویی با ویدئوهای منبع وب**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) از ویدئوهای YouTube در ارائه‌ها پشتیبانی می‌کند. اگر ویدئویی که قصد استفاده دارید به صورت آنلاین در دسترس باشد (مثلاً در YouTube)، می‌توانید آن را از طریق لینک وب به ارائه خود اضافه کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.  
1. از طریق اندیس آن، مرجع یک اسلاید را دریافت کنید.  
1. یک شیء [Video](https://reference.aspose.com/slides/fa/php-java/aspose.slides/video/) اضافه کنید و لینک ویدئو را به آن پاس دهید.  
1. یک تصویر بندانگشتی برای فریم ویدئو تنظیم کنید.  
1. ارائه را ذخیره کنید.  

این کد PHP نشان می‌دهد چگونه یک ویدئوی وب را به یک اسلاید در ارائه PowerPoint اضافه کنید:

```php
  # یک شیء Presentation که نمایانگر یک فایل ارائه است را ایجاد می‌کند
  $pres = new Presentation();
  try {
    addVideoFromYouTube($pres, "Tj75Arhq5ho");
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```

## **مدیریت زیرنویس‌های ویدئویی**

Aspose.Slides به شما امکان مدیریت زیرنویس‌های بسته برای فریم‌های ویدئویی در ارائه‌های PowerPoint را می‌دهد. زیرنویس‌ها در قالب WebVTT ذخیره می‌شوند و از طریق متد [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/fa/php-java/aspose.slides/videoframe/#getCaptionTracks) قابل دسترسی هستند.

**افزودن زیرنویس به فریم ویدئویی**

برای افزودن زیرنویس به فریم ویدئویی:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.  
1. یک ویدئو به ارائه اضافه کنید.  
1. یک شیء [VideoFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/videoframe/) به یک اسلاید اضافه کنید.  
1. از مجموعه [CaptionsCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/captionscollection/) که توسط [getCaptionTracks](https://reference.aspose.com/slides/fa/php-java/aspose.slides/videoframe/#getCaptionTracks) بازگردانده می‌شود استفاده کنید تا یک مسیر زیرنویس WebVTT اضافه کنید.  
1. ارائه‌ی اصلاح‌شده را ذخیره کنید.  

کد زیر نشان می‌دهد چگونه زیرنویس‌ها را به فریم ویدئویی اضافه کنید:

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // یک مسیر زیرنویس جدید را از یک فایل WebVTT اضافه می‌کند.
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

کلاس [CaptionsCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/captionscollection/) همچنین یک overload ارائه می‌دهد که به شما اجازه می‌دهد زیرنویس‌ها را از یک جریان (stream) اضافه کنید.

**استخراج زیرنویس‌ها از فریم ویدئویی**

برای استخراج زیرنویس‌ها از فریم ویدئویی:

1. ارائه‌ای که حاوی ویدئو است را بارگذاری کنید.  
1. شیء [VideoFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/videoframe/) هدف را پیدا کنید.  
1. در مجموعه [getCaptionTracks](https://reference.aspose.com/slides/fa/php-java/aspose.slides/videoframe/#getCaptionTracks) پیمایش کنید.  
1. هر مسیر زیرنویس را به یک فایل `.vtt` ذخیره کنید.  

کد زیر نشان می‌دهد چگونه زیرنویس‌ها را از فریم ویدئویی استخراج کنید:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trackCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                // مسیر زیرنویس را در یک فایل WebVTT ذخیره می‌کند.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

هر شیء [Captions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/captions/) شناسه زیرنویس، برچسب، داده‌های باینری و متن زیرنویس را به صورت یک رشته UTF-8 نمایان می‌کند.

**حذف زیرنویس‌ها از فریم ویدئویی**

برای حذف زیرنویس‌ها از فریم ویدئویی:

1. ارائه‌ای که حاوی ویدئو است را بارگذاری کنید.  
1. شیء [VideoFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/videoframe/) هدف را دریافت کنید.  
1. مسیرهای زیرنویس را از مجموعه [getCaptionTracks](https://reference.aspose.com/slides/fa/php-java/aspose.slides/videoframe/#getCaptionTracks) حذف کنید.  
1. ارائه اصلاح‌شده را ذخیره کنید.  

کد زیر نشان می‌دهد چگونه تمام زیرنویس‌ها را از فریم ویدئویی حذف کنید:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // نوع: VideoFrame

    // تمام زیرنویس‌ها را از فریم ویدئویی حذف می‌کند.
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

اگر نیاز به حذف تنها یک مسیر زیرنویس دارید، به‌جای [clear](https://reference.aspose.com/slides/fa/php-java/aspose.slides/captionscollection/#clear) از متدهای [remove](https://reference.aspose.com/slides/fa/php-java/aspose.slides/captionscollection/#remove) یا [removeAt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/captionscollection/#removeAt) استفاده کنید.

## **استخراج ویدئو از اسلایدها**

علاوه بر افزودن ویدئوها به اسلایدها، Aspose.Slides به شما اجازه می‌دهد ویدئوهای جاسازی‌شده در ارائه‌ها را استخراج کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید تا ارائه‌ای که شامل ویدئو است را بارگذاری کنید.  
2. از طریق تمام اشیای [Slide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/) پیمایش کنید.  
3. از طریق تمام اشیای [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/) پیمایش کنید تا یک [VideoFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/videoframe/) پیدا کنید.  
4. ویدئو را بر روی دیسک ذخیره کنید.  

این کد PHP نشان می‌دهد چگونه ویدئو را از یک اسلاید ارائه استخراج کنید:

```php
  # یک شیء Presentation که نمایانگر یک فایل ارائه است را ایجاد می‌کند
  $pres = new Presentation("VideoSample.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
          $vf = $shape;
          $type = $vf->getEmbeddedVideo()->getContentType();
          $ss = $type->lastIndexOf('-');
          $buffer = $vf->getEmbeddedVideo()->getBinaryData();
          # پسوند فایل را دریافت می‌کند
          $charIndex = $type->indexOf("/");
          $type = $type->substring($charIndex + 1);
          $fop = new Java("java.io.FileOutputStream", "testing2." . $type);
          $fop->write($buffer);
          $fop->flush();
          $fop->close();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سوالات متداول**

**کدام پارامترهای پخش ویدئو می‌توانند برای VideoFrame تغییر کنند؟**

شما می‌توانید حالت [playback mode](https://reference.aspose.com/slides/fa/php-java/aspose.slides/videoframe/setplaymode/) (خودکار یا با کلیک) و [looping](https://reference.aspose.com/slides/fa/php-java/aspose.slides/videoframe/setplayloopmode/) را کنترل کنید. این گزینه‌ها از طریق ویژگی‌های شیء [VideoFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/videoframe/) در دسترس هستند.

**آیا افزودن ویدئو بر اندازه فایل PPTX تأثیر می‌گذارد؟**

بله. هنگامی که یک ویدئوی محلی را جاسازی می‌کنید، داده‌های باینری در سند گنجانده می‌شوند، بنابراین اندازه ارائه به نسبت اندازه فایل بزرگ‌تر می‌شود. وقتی یک ویدئوی آنلاین اضافه می‌کنید، فقط یک لینک و تصویر بندانگشتی جاسازی می‌شود، بنابراین افزایش اندازه کمتر است.

**آیا می‌توانم ویدئو را در یک VideoFrame موجود بدون تغییر موقعیت و اندازه‌اش جایگزین کنم؟**

بله. می‌توانید محتوای [video content](https://reference.aspose.com/slides/fa/php-java/aspose.slides/videoframe/setembeddedvideo/) داخل فریم را تعویض کنید در حالی که هندسه شکل حفظ می‌شود؛ این یک سناریوی رایج برای به‌روزرسانی رسانه در یک چیدمان موجود است.

**آیا می‌توان نوع محتوا (MIME) یک ویدئوی جاسازی‌شده را تعیین کرد؟**

بله. یک ویدئوی جاسازی‌شده دارای یک [content type](https://reference.aspose.com/slides/fa/php-java/aspose.slides/video/getcontenttype/) است که می‌توانید آن را بخوانید و استفاده کنید، برای مثال هنگام ذخیره‌سازی بر روی دیسک.