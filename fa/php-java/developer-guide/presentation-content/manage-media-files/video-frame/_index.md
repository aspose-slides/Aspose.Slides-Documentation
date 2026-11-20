---
title: مدیریت قاب‌های ویدیو در ارائه‌ها با استفاده از PHP
linktitle: قاب ویدیو
type: docs
weight: 10
url: /fa/php-java/video-frame/
keywords:
- افزودن ویدیو
- ایجاد ویدیو
- تعبیه ویدیو
- استخراج ویدیو
- بازیابی ویدیو
- قاب ویدیو
- منبع وب
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه به‌صورت برنامه‌نویسی قاب‌های ویدیو را در اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای PHP از طریق Java اضافه و استخراج کنید. راهنمای سریع گام‌به‌گام."
---
## **معرفی**

ویدیوها می‌توانند به توضیح ایده‌ها و جلب توجه مخاطب کمک کنند. Aspose.Slides برای PHP از طریق Java به شما امکان اضافه کردن قاب‌های ویدیو به اسلایدها، تنظیم تنظیمات پخش، مدیریت زیرنویس‌ها و استخراج داده‌های ویدیو تعبیه‌شده را می‌دهد.

PowerPoint از ویدیوهای محلی و پیوندهای به ویدیوهای آنلاین، مانند ویدیوهای YouTube، پشتیبانی می‌کند.

برای نمایش داده‌های ویدیو و قاب‌های ویدیو، Aspose.Slides کلاس [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) ، کلاس [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) و سایر انواع مرتبط را ارائه می‌دهد.

## **ایجاد یک قاب ویدیو تعبیه‌شده**

اگر فایل ویدیویی که می‌خواهید به اسلاید اضافه کنید به‌صورت محلی ذخیره شده باشد، می‌توانید یک قاب ویدیو ایجاد کنید تا ویدیو را در ارائه خود تعبیه کنید.

این مثال یک ویدیو محلی را در اسلاید اول یک ارائه موجود تعبیه می‌کند و نتیجه را ذخیره می‌نماید. مختصات و ابعاد قاب بر حسب پوینت هستند. جریان (stream) تا پایان ذخیره‌سازی باز می‌ماند زیرا [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) در حین استفاده ارائه، آن را قفل نگه می‌دارد.

```php
use aspose\slides\LoadingStreamBehavior;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $slide = $presentation->getSlides()->get_Item(0);

    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::KeepLocked);
    $slide->getShapes()->addVideoFrame(10, 10, 150, 250, $video);

    $presentation->save("embedded_video.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

همچنین می‌توانید مسیر ویدیو محلی را به‌صورت مستقیم به متد [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame) پاس بدهید. این مثال ویدیو را در اسلاید اول یک ارائه جدید تعبیه می‌کند. ویدیو باید تا زمان ذخیره‌سازی ارائه در دسترس بماند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addVideoFrame(50, 150, 300, 150, "video.avi");

    $presentation->save("video_from_path.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ایجاد یک قاب ویدیو با ویدیو از منبع وب**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) از ویدیوهای آنلاین در ارائه‌ها پشتیبانی می‌کند. می‌توانید یک قاب ویدیو ایجاد کنید که به یک ویدیو آنلاین، مانند یک ویدیو YouTube، پیوند دارد.

این مثال یک پیوند ویدیو YouTube و تصویر بندانگشتی آن را به اسلاید اول اضافه می‌کند. شناسه ویدیو را تغییر دهید تا از ویدیوی دیگری استفاده کنید. متد [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) درخواست پخش خودکار را می‌دهد. دانلود تصویر بندانگشتی و پخش ویدیو نیاز به دسترسی به اینترنت دارد. مشاهده‌کننده ارائه نیز باید از پخش ویدیو آنلاین پشتیبانی کند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoId = "aqz-KE-bpKQ";
    $videoUrl = "https://www.youtube.com/embed/" . $videoId;
    $videoFrame = $slide->getShapes()->addVideoFrame(10, 10, 427, 240, $videoUrl);
    $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

    $thumbnailUrl = "https://img.youtube.com/vi/" . $videoId . "/hqdefault.jpg";
    $thumbnailLocation = new Java("java.net.URL", $thumbnailUrl);
    $thumbnailStream = $thumbnailLocation->openStream();
    try {
        $thumbnail = $presentation->getImages()->addImage($thumbnailStream);
        $videoFrame->getPictureFormat()->getPicture()->setImage($thumbnail);
    } finally {
        $thumbnailStream->close();
    }

    $presentation->save("online_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **پخش ویدیو در حالت تمام‌صفحه**

در یک ارائه آموزشی، می‌توانید یک نمایش نرم‌افزاری را در حالت تمام‌صفحه پخش کنید تا مخاطب جزئیات را ببیند. با صدا زدن [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) با مقدار `true` این رفتار در زمان پخش فعال می‌شود.

این مثال یک ارائه را باز می‌کند، اولین [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) را در اسلاید اول پیدا می‌کند و پخش تمام‌صفحه را فعال می‌سازد. ارائه ورودی باید حداقل یک اسلاید با یک قاب ویدیو موجود در اسلاید اول داشته باشد.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setFullScreenMode(true);
            break;
        }
    }

    $presentation->save("full_screen_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

پخش تمام‌صفحه تصمیم می‌گیرد ویدیو چگونه نمایش داده شود. به‌صورت مستقل، [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) تعیین می‌کند که آیا به‌صورت خودکار یا با کلیک شروع شود و [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) تعیین می‌کند که آیا تکرار شود یا نه. برای انتخاب رفتار شروع، حالت پخش را به یکی از [VideoPlayModePreset::Auto یا VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) تنظیم کنید. این مثال تنظیمات شروع و حلقه موجود را حفظ می‌کند.

## **بازگرداندن ویدیو به ابتدا پس از پخش**

در یک ارائه آموزشی، بازگرداندن یک ویدیو نمایش به آغاز آن باعث می‌شود برای ارائه‌دهنده آماده پخش دوباره باشد. با صدا زدن [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) با مقدار `true` پس از پایان پخش، ویدیو به ابتدا باز می‌گردد.

این مثال یک ارائه را باز می‌کند، اولین [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) را در اسلاید اول پیدا می‌کند و بازگرداندن به ابتدا را فعال می‌سازد. حلقه‌پذیری را غیرفعال می‌کند تا پخش بتواند به پایان برسد و حالت پخش را روی شروع با کلیک تنظیم می‌کند. ارائه ورودی باید حداقل یک اسلاید با یک قاب ویدیو موجود در اسلاید اول داشته باشد.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setRewindVideo(true);
            $videoFrame->setPlayLoopMode(false);
            $videoFrame->setPlayMode(VideoPlayModePreset::OnClick);
            break;
        }
    }

    $presentation->save("rewind_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

بازگرداندن ویدیو را بدون شروع مجدد آن به ابتدا می‌برد. در مقابل، صدا زدن [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) با مقدار `true` پخش را به‌صورت خودکار تکرار می‌کند. وقتی می‌خواهید ویدیو به پایان برسد و آماده بازپخش بماند، حلقه‌پذیری را غیرفعال کنید. [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) به‌طور مستقل کنترل می‌کند که آیا پخش به‌صورت خودکار یا با کلیک شروع شود؛ این مثال از [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) استفاده می‌کند تا ارائه‌دهنده زمان شروع پخش را کنترل کند. حالت پخش را پس از تنظیم حلقه تنظیم کنید، همان‌طور که در مثال نشان داده شده است. بازگرداندن به‌صورت مستقل از [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) عمل می‌کند.

## **قاطع کردن (Trim) یک قاب ویدیو**

از [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) و [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd) برای حذف بخشی از آغاز یا انتهای ویدیو در زمان پخش استفاده کنید. هر دو مقدار بر حسب میلی‌ثانیه هستند. قاطع کردن تنظیمات پخش را بدون تغییر داده‌های ویدیو تعبیه‌شده تغییر می‌دهد.

**تنظیمات قاطع کردن**

این مثال یک ویدیو محلی را تعبیه می‌کند و در زمان پخش، اولین ۲٫۵ ثانیه و آخرین یک ثانیه را حذف می‌کند. از ویدیویی که طول آن بیش از ۳٫۵ ثانیه باشد استفاده کنید تا بخشی قابل پخش باقی بماند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);
    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**خواندن تنظیمات قاطع کردن**

این مثال مقادیر قاطع‌کردن اولین قاب ویدیو در اسلاید اول را به میلی‌ثانیه چاپ می‌کند. ارائه باید حداقل یک اسلاید داشته باشد. اگر آن اسلاید هیچ قاب ویدیو نداشته باشد، هیچ چیزی چاپ نمی‌شود. مثال قبلی مقادیر ۲۵۰۰ و ۱۰۰۰ را تولید می‌کند.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            echo "Trim from start: " . java_values($videoFrame->getTrimFromStart()) . " ms\n";
            echo "Trim from end: " . java_values($videoFrame->getTrimFromEnd()) . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **مدیریت زیرنویس‌های ویدیو**

Aspose.Slides به شما اجازه می‌دهد زیرنویس‌های بسته (closed captions) برای قاب‌های ویدیو در ارائه‌های PowerPoint را مدیریت کنید. زیرنویس‌ها در قالب WebVTT ذخیره می‌شوند و از طریق متد [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks) در دسترس هستند.

### **افزودن زیرنویس به یک قاب ویدیو**

این مثال یک ویدیو محلی را تعبیه می‌کند و یک ردیف زیرنویس WebVTT با برچسب English اضافه می‌کند. زمان‌بندی زیرنویس باید با ویدیو مطابقت داشته باشد. ارائه ذخیره‌شده شامل هر دو ویدیو و زیرنویس آن می‌شود.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

کلاس [CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) نیز یک بارگذاری (overload) دارد که اجازه می‌دهد زیرنویس‌ها را از یک جریان (stream) اضافه کنید.

### **استخراج زیرنویس‌ها از یک قاب ویدیو**

این مثال تمام ردیف‌های زیرنویس را از قاب‌های ویدیو در اسلاید اول به‌صورت فایل‌های جداگانه WebVTT ذخیره می‌کند. اعداد متوالی باعث می‌شود فایل‌های خروجی متمایز بمانند. کنسول تعداد ردیف‌های استخراج‌شده را گزارش می‌دهد. ارائه باید حداقل یک اسلاید داشته باشد.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $trackCount = 0;
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $captionCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $captionCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                $trackCount++;
                $outputStream = new Java("java.io.FileOutputStream", "captions_" . $trackCount . ".vtt");
                try {
                    $outputStream->write($captionTrack->getBinaryData());
                } finally {
                    $outputStream->close();
                }
            }
        }
    }

    echo "Caption tracks extracted: " . $trackCount . "\n";
} finally {
    $presentation->dispose();
}
```

هر شیء [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/) شناسه زیرنویس، برچسب، داده‌های باینری و متن زیرنویس را به‌عنوان رشته UTF‑8 باز می‌کند.

### **حذف زیرنویس‌ها از یک قاب ویدیو**

این مثال تمام زیرنویس‌ها را از قاب ویدیو در اولین موقعیت شکل در اسلاید اول حذف می‌کند و نتیجه را ذخیره می‌نماید. فرض می‌شود اسلاید و شکل موجود بوده و شکل یک قاب ویدیو باشد.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFrame = $slide->getShapes()->get_Item(0);
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

اگر فقط می‌خواهید یک ردیف زیرنویس را حذف کنید، به جای [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear) از متدهای [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) یا [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) استفاده کنید.

### **جستجوی زیرنویس‌های ویدیو**

[Captions::getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) کل ردیف WebVTT را شامل سرآیند، خطوط زمان‌بندی و متن زیرنویس باز می‌گرداند. می‌توانید کدهای (cues) را در حافظه جستجو کنید تا عبارت گفتاری و زمان‌بندی آن را پیدا کنید. برای مثال، یک ردیف انگلیسی در اسلاید ۲ ممکن است شامل متن زیر باشد.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

مثال فایل `captioned_media.pptx` را باز می‌کند و با استفاده از [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks) ردیف‌های هر قاب ویدیو سطح بالای هر اسلاید را می‌خواند. در یک cue متنی ساده، خط زمان‌بندی شامل `-->` است و یک خط خالی پایان cue را نشان می‌دهد. هنگامی که زیرنویس شامل کلمه “café” در هر ترکیب حروفی باشد، مثال شماره اسلاید، برچسب ردیف، خط زمان‌بندی اصلی و کل زیرنویس را چاپ می‌کند.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("captioned_media.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                continue;
            }
            $trackCount = java_values($shape->getCaptionTracks()->getCount());
            for ($index = 0; $index < $trackCount; $index++) {
                $track = $shape->getCaptionTracks()->get_Item($index);
                $lines = preg_split('/\r\n|\n|\r/', java_values($track->getDataAsString()));
                $lineCount = count($lines);
                for ($i = 0; $i < $lineCount; $i++) {
                    $timing = $lines[$i];
                    if (strpos($timing, "-->") === false) {
                        continue;
                    }
                    $captionLines = [];
                    while (++$i < $lineCount && $lines[$i] !== "") {
                        $captionLines[] = $lines[$i];
                    }
                    $caption = implode("\n", $captionLines);
                    if (preg_match('/café/iu', $caption)) {
                        printf("Slide %d | %s | %s\n", java_values($slide->getSlideNumber()), java_values($track->getLabel()), $timing);
                        echo $caption, "\n";
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

جستجو برای “café” یک مطابقت برای ردیف نمونه تولید می‌کند. جستجو سرآیند ردیف را مستثنی می‌کند و تنظیم زمان‌بندی را در خروجی حفظ می‌نماید.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **استخراج ویدیو از یک اسلاید**

علاوه بر افزودن ویدیوها به اسلایدها، Aspose.Slides به شما امکان استخراج ویدیوهای تعبیه‌شده در ارائه‌ها را می‌دهد.

این مثال ویدیوهای تعبیه‌شده را از هر اسلاید استخراج می‌کند و در فایل‌های باینری شماره‌دار جداگانه ذخیره می‌سازد. ویدیوهای پیوندی (linked) نادیده گرفته می‌شوند زیرا داده تعبیه‌شده‌ای ندارند. کنسول نوع MIME هر ویدیو و تعداد کل آن‌ها را چاپ می‌کند. خروجی از پسوند عمومی `.bin` استفاده می‌کند؛ در صورت نیاز می‌توانید آن را با نوع رسانه گزارش‌شده تغییر دهید.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_videos.pptx");
try {
    $videoCount = 0;
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $videoFrame = $shape;
                $video = $videoFrame->getEmbeddedVideo();
                if (java_is_null($video)) {
                    echo "Skipped a linked video: no embedded data is available.\n";
                    continue;
                }

                $videoCount++;
                $outputStream = new Java("java.io.FileOutputStream", "extracted_video_" . $videoCount . ".bin");
                try {
                    $outputStream->write($video->getBinaryData());
                } finally {
                    $outputStream->close();
                }
                echo "Video " . $videoCount . ": " . java_values($video->getContentType()) . "\n";
            }
        }
    }

    echo "Embedded videos extracted: " . $videoCount . "\n";
} finally {
    $presentation->dispose();
}
```

## **سؤالات متداول**

**کدام پارامترهای پخش ویدیو می‌توانند برای یک قاب ویدیو تغییر یابند؟**

می‌توانید [mode پخش](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) (auto یا on click) و [looping](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) را کنترل کنید. این گزینه‌ها از طریق متدهای شیء [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) در دسترس هستند.

**آیا افزودن یک ویدیو بر حجم فایل PPTX تأثیر می‌گذارد؟**

بله. وقتی یک ویدیو محلی را تعبیه می‌کنید، داده‌های باینری در سند گنجانده می‌شود، بنابراین اندازه ارائه به نسبت حجم فایل افزایش می‌یابد. وقتی به یک ویدیو آنلاین پیوند می‌دهید و یک تصویر بندانگشتی اضافه می‌کنید، ارائه فقط پیوند و تصویر پیش‌نمایش را ذخیره می‌کند، بنابراین افزایش حجم معمولاً کمتر است.

**آیا می‌توانید ویدیو را در یک قاب ویدیو موجود بدون تغییر موقعیت و اندازه آن جایگزین کنید؟**

بله. می‌توانید محتوای [ویدیو](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo) را درون قاب تعویض کنید در حالی که هندسهٔ شکل حفظ می‌شود؛ این سناریوی رایج برای به‌روزرسانی رسانه در یک قالب موجود است.

**آیا می‌توان نوع محتوا (MIME) یک ویدیو تعبیه‌شده را مشخص کرد؟**

بله. یک ویدیو تعبیه‌شده دارای [content type](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType) است که می‌توانید آن را بخوانید و استفاده کنید، برای مثال هنگام ذخیره‌سازی بر روی دیسک.