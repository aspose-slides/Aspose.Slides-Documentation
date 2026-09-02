---
title: مدیریت قاب‌های ویدئویی در ارائه‌ها با استفاده از PHP
linktitle: قاب ویدئویی
type: docs
weight: 10
url: /fa/php-java/video-frame/
keywords:
- افزودن ویدئو
- ایجاد ویدئو
- جاسازی ویدئو
- استخراج ویدئو
- دریافت ویدئو
- قاب ویدئویی
- منبع وب
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه به‌صورت برنامه‌نویسی قاب‌های ویدئویی را در اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای PHP via Java اضافه و استخراج کنید. راهنمای سریع نحوه انجام."
---
## **مقدمه**

یک ویدئوی به‌خوبی قرار‌گرفته در یک ارائه می‌تواند پیام شما را جذاب‌تر کند و سطح تعامل با مخاطبان را افزایش دهد. 

PowerPoint به شما اجازه می‌دهد ویدئوها را به یک اسلاید در یک ارائه به دو روش اضافه کنید:

* اضافه یا جاسازی یک ویدئوی محلی (در دستگاه شما ذخیره شده)
* اضافه کردن یک ویدئوی آنلاین (از منبع وبی مانند YouTube).

برای این‌که بتوانید ویدئوها (شیء‌های ویدئویی) را به یک ارائه اضافه کنید، Aspose.Slides کلاس [Video](https://reference.aspose.com/slides/fa/php-java/aspose.slides/video/) ، کلاس [VideoFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/videoframe/) و سایر انواع مرتبط را فراهم می‌کند.

## **ایجاد قاب‌های ویدئوی جاسازی‌شده**

اگر فایل ویدئویی که می‌خواهید به اسلاید خود اضافه کنید به صورت محلی ذخیره شده باشد، می‌توانید یک قاب ویدئویی ایجاد کنید تا ویدئو را در ارائه خود جاسازی کنید. 

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید. 
1. یک شیء [Video](https://reference.aspose.com/slides/fa/php-java/aspose.slides/video/) اضافه کنید و مسیر فایل ویدئو را برای جاسازی ویدئو در ارائه عبور دهید.
1. یک شیء [VideoFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/videoframe/) اضافه کنید تا یک قاب برای ویدئو ایجاد شود.
1. ارائه اصلاح‌شده را ذخیره کنید. 

این کد PHP به شما نشان می‌دهد چگونه یک ویدئوی ذخیره‌شده به‌صورت محلی را به یک ارائه اضافه کنید:

```php
  # یک شیء از کلاس Presentation می‌سازد
  $pres = new Presentation("pres.pptx");
  try {
    # ویدئو را بارگذاری می‌کند
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # اولین اسلاید را دریافت می‌کند و یک قاب ویدئویی اضافه می‌کند
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # ارائه را روی دیسک ذخیره می‌کند
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

به‌طور جایگزین، می‌توانید با عبور مستقیم مسیر فایل به متد [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/addvideoframe/) یک ویدئو اضافه کنید:

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


## **ایجاد قاب‌های ویدئویی با ویدئوی از منابع وبی**

Microsoft [PowerPoint 2013 و جدیدتر](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) از ویدئوهای YouTube در ارائه‌ها پشتیبانی می‌کند. اگر ویدئویی که می‌خواهید استفاده کنید به صورت آنلاین در دسترس باشد (مثلاً در YouTube)، می‌توانید آن را از طریق پیوند وب به ارائه خود اضافه کنید. 

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید
1. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید. 
1. یک شیء [Video](https://reference.aspose.com/slides/fa/php-java/aspose.slides/video/) اضافه کنید و پیوند به ویدئو را عبور دهید.
1. یک تصویر بندانگشتی برای قاب ویدئو تنظیم کنید. 
1. ارائه را ذخیره کنید. 

این کد PHP به شما نشان می‌دهد چگونه یک ویدئوی وب را به یک اسلاید در یک ارائه PowerPoint اضافه کنید:

```php
  # یک شیء Presentation که نمایانگر یک فایل ارائه است را نمونه‌سازی می‌کند
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

## **قلم‌برداری یک قاب ویدئویی**

Aspose.Slides به شما امکان می‌دهد تا بخشی از ویدئویی که پخش می‌شود را با تنظیم مقادیر trim‑from‑start و trim‑from‑end از طریق [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/fa/php-java/aspose.slides/videoframe/#setTrimFromStart) و [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/fa/php-java/aspose.slides/videoframe/#setTrimFromEnd) کنترل کنید. هر دو مقدار بر حسب میلی‌ثانیه تعیین می‌شوند و نشان می‌دهند چه مقدار زمان از ابتدای و انتهای ویدئو به ترتیب صرف‌نظر شود. این تنظیمات پخش ویدئو را در ارائه تغییر می‌دهند؛ آن‌ها فایل باینری ویدئوی جاسازی‌شده را برش یا تغییری نمی‌دهند.

**تنظیمات برش**

برای ایجاد یک قاب ویدئویی و تنظیمات برش آن:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. یک شیء [Video] به ارائه اضافه کنید.
1. یک شیء [VideoFrame] به یک اسلاید اضافه کنید.
1. مقادیر trim‑from‑start و trim‑from‑end را از طریق [VideoFrame::setTrimFromStart] و [VideoFrame::setTrimFromEnd] تنظیم کنید.
1. ارائه اصلاح‌شده را ذخیره کنید.

کد مثال زیر اولین ۲٫۵ ثانیه و آخرین یک ثانیه از یک ویدئوی جاسازی‌شده را در حین پخش صرف‌نظر می‌کند:

```php
$presentation = new Presentation();
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $video = $presentation->getVideos()->addVideo(
        $videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);

    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

**خواندن تنظیمات برش**

برای بررسی تنظیمات برش موجود، یک ارائه را بارگذاری کنید، شیء [VideoFrame] را در میان اشکال اسلاید اول پیدا کنید، و مقادیر را از طریق [VideoFrame::getTrimFromStart] و [VideoFrame::getTrimFromEnd] بخوانید.

کد مثال زیر اولین قاب ویدئویی را در اسلاید اول پیدا می‌کند و تنظیمات برش آن را برحسب میلی‌ثانیه گزارش می‌دهد:

```php
$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trimFromStart = java_values($videoFrame->getTrimFromStart());
            $trimFromEnd = java_values($videoFrame->getTrimFromEnd());

            echo "Trim from start: " . $trimFromStart . " ms\n";
            echo "Trim from end: " . $trimFromEnd . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **مدیریت زیرنویس‌های ویدئویی**

Aspose.Slides به شما امکان مدیریت زیرنویس‌های بسته برای قاب‌های ویدئویی در ارائه‌های PowerPoint را می‌دهد. زیرنویس‌ها در قالب WebVTT ذخیره می‌شوند و از طریق متد [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/fa/php-java/aspose.slides/videoframe/#getCaptionTracks) در دسترس هستند.

**افزودن زیرنویس به یک قاب ویدئویی**

برای افزودن زیرنویس به یک قاب ویدئویی:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. یک ویدئو به ارائه اضافه کنید.
1. یک شیء [VideoFrame] به یک اسلاید اضافه کنید.
1. از مجموعه [CaptionsCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/captionscollection/) که توسط [getCaptionTracks](https://reference.aspose.com/slides/fa/php-java/aspose.slides/videoframe/#getCaptionTracks) برگردانده می‌شود، برای افزودن یک ردیف زیرنویس WebVTT استفاده کنید.
1. ارائه اصلاح‌شده را ذخیره کنید.

کد زیر نشان می‌دهد چگونه زیرنویس‌ها را به یک قاب ویدئویی اضافه کنید:

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // یک مسیر زیرنویس جدید از فایل WebVTT اضافه می‌کند.
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

کلاس [CaptionsCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/captionscollection/) همچنین یک overload فراهم می‌کند که به شما اجازه می‌دهد زیرنویس‌ها را از یک جریان (stream) اضافه کنید.

**استخراج زیرنویس‌ها از یک قاب ویدئویی**

برای استخراج زیرنویس‌ها از یک قاب ویدئویی:

1. ارائه‌ای که شامل ویدئو است را بارگذاری کنید.
1. شیء [VideoFrame] هدف را پیدا کنید.
1. در مجموعه [getCaptionTracks](https://reference.aspose.com/slides/fa/php-java/aspose.slides/videoframe/#getCaptionTracks) تکرار کنید.
1. هر ردیف زیرنویس را در یک فایل `.vtt` ذخیره کنید.

کد زیر نشان می‌دهد چگونه زیرنویس‌ها را از یک قاب ویدئویی استخراج کنید:

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
                // ردیف زیرنویس را در یک فایل WebVTT ذخیره می‌کند.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

هر شیء [Captions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/captions/) شناسه زیرنویس، برچسب، داده‌های باینری و متن زیرنویس را به صورت رشته UTF‑8 ارائه می‌دهد.

**حذف زیرنویس‌ها از یک قاب ویدئویی**

برای حذف زیرنویس‌ها از یک قاب ویدئویی:

1. ارائه‌ای که شامل ویدئو است را بارگذاری کنید.
1. شیء [VideoFrame] هدف را دریافت کنید.
1. ردیف‌های زیرنویس را از مجموعه [getCaptionTracks](https://reference.aspose.com/slides/fa/php-java/aspose.slides/videoframe/#getCaptionTracks) حذف کنید.
1. ارائه اصلاح‌شده را ذخیره کنید.

کد زیر نشان می‌دهد چگونه تمام زیرنویس‌ها را از یک قاب ویدئویی حذف کنید:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // نوع: VideoFrame

    // تمام زیرنویس‌ها را از قاب ویدئویی حذف می‌کند.
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

اگر نیاز دارید تنها یک ردیف زیرنویس را حذف کنید، به جای [clear](https://reference.aspose.com/slides/fa/php-java/aspose.slides/captionscollection/#clear) از متدهای [remove](https://reference.aspose.com/slides/fa/php-java/aspose.slides/captionscollection/#remove) یا [removeAt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/captionscollection/#removeAt) استفاده کنید.

## **استخراج ویدئو از اسلایدها**

علاوه بر افزودن ویدئوها به اسلایدها، Aspose.Slides به شما امکان استخراج ویدئوهای جاسازی‌شده در ارائه‌ها را می‌دهد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید تا ارائه‌ای که شامل ویدئو است را بارگذاری کنید.
2. در تمام اشیاء [Slide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/) تکرار کنید.
3. در تمام اشیاء [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/) تکرار کنید تا یک [VideoFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/videoframe/) پیدا کنید.
4. ویدئو را روی دیسک ذخیره کنید.

این کد PHP نشان می‌دهد چگونه ویدئوی موجود در یک اسلاید ارائه را استخراج کنید:

```php
  # یک شیء Presentation که نمایانگر یک فایل ارائه است را نمونه‌سازی می‌کند
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

## **پرسش‌های متداول**

**کدام پارامترهای پخش ویدئو می‌توانند برای VideoFrame تغییر کنند؟**

می‌توانید حالت [playback mode](https://reference.aspose.com/slides/fa/php-java/aspose.slides/videoframe/setplaymode/) (به‌صورت خودکار یا با کلیک) و [looping](https://reference.aspose.com/slides/fa/php-java/aspose.slides/videoframe/setplayloopmode/) را کنترل کنید. این گزینه‌ها از طریق ویژگی‌های شیء [VideoFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/videoframe/) در دسترس هستند.

**آیا افزودن یک ویدئو بر حجم فایل PPTX تأثیر می‌گذارد؟**

بله. هنگامی که یک ویدئوی محلی را جاسازی می‌کنید، داده‌های باینری در سند گنجانده می‌شود، بنابراین حجم ارائه نسبت به حجم فایل افزایش می‌یابد. هنگام افزودن یک ویدئوی آنلاین، فقط یک پیوند و تصویر بندانگشتی جاسازی می‌شود، بنابراین افزایش حجم کمتر است.

**آیا می‌توانم ویدئو را در یک VideoFrame موجود بدون تغییر موقعیت و اندازه آن جایگزین کنم؟**

بله. می‌توانید محتویات [video content](https://reference.aspose.com/slides/fa/php-java/aspose.slides/videoframe/setembeddedvideo/) را داخل قاب تعویض کنید در حالی که شکل (geometry) حفظ می‌شود؛ این یک سناریوی رایج برای بروزرسانی رسانه در یک طرح‌بندی موجود است.

**آیا می‌توان نوع محتوا (MIME) یک ویدئوی جاسازی‌شده را تعیین کرد؟**

بله. یک ویدئوی جاسازی‌شده دارای یک [content type](https://reference.aspose.com/slides/fa/php-java/aspose.slides/video/getcontenttype/) است که می‌توانید آن را بخوانید و استفاده کنید، برای مثال هنگام ذخیره‌سازی آن بر روی دیسک.