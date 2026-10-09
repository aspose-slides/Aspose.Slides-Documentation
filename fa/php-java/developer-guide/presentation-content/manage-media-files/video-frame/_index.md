---
title: مدیریت فریم‌های ویدئویی در ارائه‌ها با استفاده از PHP
linktitle: فریم ویدئویی
type: docs
weight: 10
url: /fa/php-java/video-frame/
keywords:
- افزودن ویدئو
- ایجاد ویدئو
- جاسازی ویدئو
- استخراج ویدئو
- دریافت ویدئو
- فریم ویدئویی
- منبع وب
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید به‌صورت برنامه‌نویسی فریم‌های ویدئویی را در اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای PHP از طریق Java اضافه و استخراج کنید. راهنمای سریع نحوه انجام."
---
## **مقدمه**

ویدیوها می‌توانند به توضیح ایده‌ها و جلب توجه مخاطبان کمک کنند. Aspose.Slides برای PHP از طریق Java به شما امکان می‌دهد فریم‌های ویدئویی را به اسلایدها اضافه کنید، تنظیمات پخش را تنظیم کنید، زیرنویس‌ها را مدیریت کنید و داده‌های ویدئوی جاسازی‌شده را استخراج کنید.

PowerPoint از ویدیوهای محلی و لینک‌های به ویدیوهای آنلاین، مانند ویدیوهای YouTube، پشتیبانی می‌کند.

برای نمایش داده‌های ویدئویی و فریم‌های ویدئویی، Aspose.Slides کلاس [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/)، کلاس [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) و سایر انواع مرتبط را فراهم می‌کند.

## **ایجاد یک فریم ویدئوی جاسازی‌شده**

اگر فایل ویدیویی که می‌خواهید به اسلاید اضافه کنید به صورت محلی ذخیره شده باشد، می‌توانید یک فریم ویدئویی ایجاد کنید تا ویدیو را در ارائه خود جاسازی کنید.

این مثال ویدیوی محلی را در اولین اسلاید یک ارائه موجود جاسازی می‌کند و نتیجه را ذخیره می‌نماید. مختصات و ابعاد فریم بر حسب پوینت هستند. جریان (stream) تا پایان ذخیره‌سازی باز می‌ماند زیرا [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) آن را در زمانی که ارائه از آن استفاده می‌کند، قفل می‌دارد.

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

همچنین می‌توانید مسیر ویدئوی محلی را مستقیماً به [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame) پاس دهید. این مثال ویدیو را در اولین اسلاید یک ارائه جدید جاسازی می‌کند. ویدیو باید تا زمان ذخیره‌سازی ارائه در دسترس باقی بماند.

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

## **ایجاد یک فریم ویدئویی با ویدئوی منبع وب**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) از ویدیوهای آنلاین در ارائه‌ها پشتیبانی می‌کند. می‌توانید فریمی ایجاد کنید که به ویدئوی آنلاین، مانند ویدئوی YouTube، لینک داشته باشد.

این مثال لینک ویدئوی YouTube و تصویر بندانگشتی آن را به اولین اسلاید اضافه می‌کند. شناسه ویدیو را تغییر دهید تا از ویدئوی دیگری استفاده کنید. روش [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) پخش خودکار را درخواست می‌کند. دانلود تصویر بندانگشتی و پخش ویدیو به اتصال اینترنتی نیاز دارد. نمایشگر ارائه نیز باید از پخش ویدیوهای آنلاین پشتیبانی کند.

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

## **پخش یک ویدیو در حالت تمام‌صفحه**

در یک ارائه آموزشی، می‌توانید یک نمایش نرم‌افزار را در حالت تمام‌صفحه پخش کنید تا مخاطبان جزئیات را ببینند. برای فعال‌سازی این رفتار در حین پخش، [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) را با مقدار `true` صدا بزنید.

این مثال یک ارائه را باز می‌کند، اولین [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) را در اولین اسلاید پیدا می‌کند و پخش تمام‌صفحه را فعال می‌سازد. ارائه ورودی باید حداقل یک اسلاید با فریم ویدئویی موجود در اولین اسلاید داشته باشد.

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

پخش تمام‌صفحه نحوه نمایش ویدیو را کنترل می‌کند. به صورت مستقل، [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) تعیین می‌کند که آیا ویدیو به‌صورت خودکار یا با کلیک شروع شود و [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) تعیین می‌کند که آیا تکرار شود یا نه. برای انتخاب رفتار شروع، حالت پخش را به [VideoPlayModePreset::Auto یا VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) تنظیم کنید. این مثال تنظیمات شروع و حلقه موجود را حفظ می‌کند.

## **بازگشت ویدیو به ابتدا پس از پخش**

در یک ارائه آموزشی، بازگشت یک ویدئوی نمایش به ابتدا باعث می‌شود که برای ارائه‌دهنده آمادهٔ پخش مجدد باشد. برای بازگرداندن ویدیو به ابتدا پس از پایان پخش، [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) را با مقدار `true` صدا بزنید.

این مثال یک ارائه را باز می‌کند، اولین [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) را در اولین اسلاید پیدا می‌کند و بازگشت به ابتدا را فعال می‌سازد. حلقه‌گذاری غیرفعال می‌شود تا پخش بتواند به پایان برسد و پخش روی کلیک تنظیم می‌شود. ارائه ورودی باید حداقل یک اسلاید با فریم ویدئویی موجود در اولین اسلاید داشته باشد.

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

بازگشت به ابتدا ویدیو را به ابتدای آن برمی‌گرداند بدون اینکه دوباره شروع شود. در مقابل، فراخوانی [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) با مقدار `true` باعث تکرار خودکار پخش می‌شود. وقتی می‌خواهید ویدیو به پایان برسد و آمادهٔ پخش مجدد بماند، حلقه را غیرفعال نگه دارید. [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) به‌صورت مستقل کنترل شروع خودکار یا با کلیک را بر عهده دارد؛ این مثال از [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) استفاده می‌کند تا ارائه‌دهنده زمان شروع پخش را کنترل کند. تنظیم حالت پخش پس از تنظیم حلقه انجام می‌شود، همان‌گونه که در مثال نشان داده شده است. بازگشت به ابتدا به‌صورت مستقل از [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) عمل می‌کند.

## **برش فریم ویدئویی**

از [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) و [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd) برای صرف‌نظر کردن از بخشی از ابتدای یا انتهای ویدیو هنگام پخش استفاده کنید. هر دو مقدار بر حسب میلی‌ثانیه هستند. برش تنظیمات پخش را بدون تغییر داده‌های ویدئوی جاسازی‌شده تغییر می‌دهد.

**تنظیمات برش**

این مثال ویدئوی محلی را جاسازی می‌کند و دو ثانیه و نیم اول و یک ثانیه انتهای آن را هنگام پخش نادیده می‌گیرد. از ویدیویی طولانی‌تر از 3.5 ثانیه استفاده کنید تا بخشی قابل پخش باقی بماند.

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

**خواندن تنظیمات برش**

این مثال مقادیر برش فریم ویدئویی اول در اولین اسلاید را به میلی‌ثانیه چاپ می‌کند. ارائه باید حداقل یک اسلاید داشته باشد. اگر آن اسلاید فریم ویدئویی نداشته باشد، چیزی چاپ نمی‌شود. مثال قبلی مقادیر 2500 و 1000 را تولید می‌کند.

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

Aspose.Slides به شما اجازه می‌دهد زیرنویس‌های بسته برای فریم‌های ویدئویی در ارائه‌های PowerPoint را مدیریت کنید. زیرنویس‌ها در قالب WebVTT ذخیره می‌شوند و از طریق متد [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks) در دسترس قرار می‌گیرند.

**افزودن زیرنویس به فریم ویدئویی**

این مثال ویدئوی محلی را جاسازی می‌کند و یک مسیر زیرنویس WebVTT با برچسب English اضافه می‌نماید. زمان‌بندی زیرنویس‌ها باید با ویدیو مطابقت داشته باشد. ارائه ذخیره‌شده شامل هر دو ویدیو و زیرنویس‌های آن می‌شود.

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

کلاس [CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) همچنین یک overload فراهم می‌کند که به شما امکان می‌دهد زیرنویس‌ها را از یک جریان (stream) اضافه کنید.

**استخراج زیرنویس‌ها از فریم ویدئویی**

این مثال تمام مسیرهای زیرنویس را از فریم‌های ویدئویی در اولین اسلاید به‌صورت فایل‌های جداگانهٔ WebVTT ذخیره می‌کند. اعداد ترتیبی فایل‌های خروجی را متمایز نگه می‌دارند. کنسول تعداد مسیرهای استخراج‌شده را گزارش می‌دهد. ارائه باید حداقل یک اسلاید داشته باشد.

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

هر شیء [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/) شناسهٔ زیرنویس، برچسب، دادهٔ باینری و متن زیرنویس را به‌صورت رشتهٔ UTF-8 عرضه می‌کند.

**حذف زیرنویس‌ها از فریم ویدئویی**

این مثال تمام زیرنویس‌ها را از فریم ویدئویی در اولین موقعیت شکل در اولین اسلاید حذف می‌کند و نتیجه را ذخیره می‌نماید. فرض می‌شود اسلاید و شکل وجود داشته باشند و شکل یک فریم ویدئویی باشد.

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

اگر نیاز به حذف تنها یک مسیر زیرنویس داشته باشید، به جای [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear) از متدهای [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) یا [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) استفاده کنید.

## **استخراج ویدیو از اسلاید**

علاوه بر افزودن ویدیو به اسلایدها، Aspose.Slides به شما اجازه می‌دهد ویدیوهای جاسازی‌شده در ارائه‌ها را استخراج کنید.

این مثال ویدیوهای جاسازی‌شده را از هر اسلاید به‌صورت فایل‌های باینری شماره‌گذاری‌شده استخراج می‌کند. ویدیوهای لینک‌شده به دلیل نداشتن دادهٔ جاسازی‌شده نادیده گرفته می‌شوند. کنسول نوع MIME هر ویدیو و مجموع شمارش را چاپ می‌کند. خروجی از پسوند عمومی `.bin` استفاده می‌کند؛ در صورت نیاز می‌توانید آن را به‌گونه‌ای تغییر دهید که با نوع رسانه گزارش‌شده تطابق داشته باشد.

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

## **سؤال‌های متداول**

**کدام پارامترهای پخش ویدیو برای یک فریم ویدئویی قابل تغییر هستند؟**

شما می‌توانید [حالت پخش](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) (خودکار یا با کلیک) و [حلقه](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) را کنترل کنید. این گزینه‌ها از طریق متدهای شیء [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) در دسترس هستند.

**آیا افزودن ویدیو حجم فایل PPTX را افزایش می‌دهد؟**

بله. وقتی ویدئوی محلی را جاسازی می‌کنید، داده‌های باینری در سند گنجانده می‌شود، بنابراین اندازهٔ ارائه به‌تناسب با اندازهٔ فایل افزایش می‌یابد. وقتی به یک ویدئوی آنلاین لینک می‌دهید و تصویر بندانگشتی اضافه می‌کنید، ارائه فقط لینک و تصویر پیش‌نمایش را ذخیره می‌کند نه دادهٔ ویدئو، بنابراین افزایش حجم معمولاً کمتر است.

**آیا می‌توان ویدیو در یک فریم ویدئویی موجود را بدون تغییر موقعیت و اندازه آن جایگزین کرد؟**

بله. می‌توانید محتوای [ویدئو](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo) را داخل فریم تعویض کنید در حالی که شکل هندسی آن حفظ می‌شود؛ این سناریوی رایجی برای به‌روزرسانی رسانه در یک طرح موجود است.

**آیا می‌توان نوع محتوا (MIME) یک ویدئوی جاسازی‌شده را تعیین کرد؟**

بله. یک ویدئوی جاسازی‌شده دارای [نوع محتوا](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType) است که می‌توانید آن را بخوانید و استفاده کنید، برای مثال هنگام ذخیره‌سازی روی دیسک.