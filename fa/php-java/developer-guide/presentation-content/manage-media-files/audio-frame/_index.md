---
title: "مدیریت فریم‌های صوتی در ارائه‌ها با استفاده از PHP"
linktitle: "فریم صوتی"
type: docs
weight: 10
url: /fa/php-java/audio-frame/
keywords:
- "صدا"
- "فریم صوتی"
- "تصویر بندانگشتی"
- "افزودن صدا"
- "ویژگی‌های صدا"
- "گزینه‌های صدا"
- "استخراج صدا"
- "PHP"
- "Aspose.Slides"
description: "صدای اسلایدها را جاسازی کنید، نماد صوتی را تغییر دهید، پخش را پیکربندی کنید، زیرنویس‌های WebVTT را مدیریت کنید و صداهای انتقال اسلاید را با Aspose.Slides برای PHP از طریق Java استخراج کنید."
---
## **نمای کلی**

یک فریم صوتی به شما امکان می‌دهد تا یک صدا را بر روی اسلاید پخش کنید. با Aspose.Slides برای PHP از طریق Java، می‌توانید یک کلیپ صوتی را جاسازی کنید، تصویر نمایانگر آن را انتخاب کنید، تنظیمات پخش را تغییر دهید و زیرنویس‌ها را پیوست کنید. همچنین می‌توانید صدایی که به یک انتقال اسلاید اختصاص داده شده است را بازیابی کنید.

## **ایجاد فریم‌های صوتی**

از [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) برای جاسازی یک کلیپ صوتی محلی در اسلاید اول استفاده کنید. دو مختصهٔ اول موقعیت فریم را بر روی اسلاید تعیین می‌کند و دو مقدار بعدی عرض و ارتفاع آن را بر حسب پوینت تنظیم می‌کند. این مثال از [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) برای شروع خودکار کلیپ و از [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) برای انتخاب پیش‌تنظیم صدای بلند استفاده می‌کند.

```php
use aspose\slides\AudioPlayModePreset;
use aspose\slides\AudioVolumeMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->setPlayMode(AudioPlayModePreset::Auto);
    $audioFrame->setVolume(AudioVolumeMode::Loud);

    $presentation->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تغییر تصویر بندانگشتی فریم صوتی**

به‌طور پیش‌فرض، یک فریم صوتی یک آیکن بلندگو را نمایش می‌دهد. برای نمایش یک تصویر بندانگشت سفارشی، یک تصویر را با [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) به ارائه اضافه کنید و با [setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/setimage/) آن را بر روی تصویر فریم تنظیم کنید. این مثال از یک JPEG به‌عنوان تصویر بندانگشت برای یک کلیپ صوتی جاسازی شده استفاده می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
    } finally {
        $audioStream->close();
    }

    $imageStream = new Java("java.io.FileInputStream", "eagle.jpeg");
    try {
        $thumbnail = $presentation->getImages()->addImage($imageStream);
    } finally {
        $imageStream->close();
    }
    $audioFrame->getPictureFormat()->getPicture()->setImage($thumbnail);

    $presentation->save("example_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تغییر گزینه‌های پخش صدا**

کنترل‌های **Audio Options** در PowerPoint تعیین می‌کنند که یک کلیپ چه زمانی شروع شود، چقدر صدا داشته باشد و در طول نمایش اسلاید چگونه رفتار کند.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| کنترل PowerPoint | متد Aspose.Slides برای PHP از طریق Java |
| --- | --- |
| شروع | [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) |
| پیش‌تنظیم صدا | [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) |
| پخش در تمام اسلایدها | [setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayacrossslides/) |
| حلقه تا توقف | [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayloopmode/) |
| پنهان کردن در طول نمایش | [setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/sethideatshowing/) |
| بازگرداندن پس از پخش | [setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setrewindaudio/) |
| محو شدن ورودی | [setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration) |
| محو شدن خروجی | [setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration) |
| برش زمان شروع صدا | [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) |
| برش زمان پایان صدا | [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) |
| نوار تنظیم صدا | [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) |

این مثال اولین فریم صوتی را در اسلاید اول پیدا می‌کند، با [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) پخش را با کلیک آغاز می‌کند و پیش‌تنظیم صدای کم را انتخاب می‌کند. کلیپ در تمام اسلایدها ادامه می‌یابد و حلقه‌سازی غیرفعال است. آیکن در طول نمایش مخفی می‌ماند و پس از پخش کلیپ باز می‌گردد.

```php
use aspose\slides\AudioPlayModePreset;
use aspose\slides\AudioVolumeMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->setPlayAcrossSlides(true);
        $audioFrame->setPlayLoopMode(false);
        $audioFrame->setPlayMode(AudioPlayModePreset::OnClick);
        $audioFrame->setVolume(AudioVolumeMode::Low);
        $audioFrame->setHideAtShowing(true);
        $audioFrame->setRewindAudio(true);

        $presentation->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

برای کلیپی که طول آن بیش از 3.5 ثانیه است، این مثال 1.5 ثانیهٔ اول و 2 ثانیهٔ آخر آن را حذف می‌کند. [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) مدت زمان حذف شده از انتهای کلیپ را می‌گیرد. برای به دست آوردن زمان پایان که در PowerPoint نمایش داده می‌شود، این جبران را از طول کامل کلیپ کم کنید. کلیپ برش‌خورده در مدت 200 میلی‌ثانیه محو ورود می‌شود و در 500 میلی‌ثانیه محو خروج. همهٔ چهار متد مقادیر را بر حسب میلی‌ثانیه می‌پذیرند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->setTrimFromStart(1500);
    $audioFrame->setTrimFromEnd(2000);
    $audioFrame->setFadeInDuration(200);
    $audioFrame->setFadeOutDuration(500);

    $presentation->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

برای تنظیم حجم پخش به درصد خاصی، از [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) استفاده کنید. این مثال حجم اولین فریم صوتی در اسلاید اول را روی 85٪ تنظیم می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->setVolumeValue(85);
        $presentation->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

## **مدیریت زیرنویس‌های صوتی**

هر فریم صوتی دسترسی به مسیرهای زیرنویس خود را از طریق [getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#getCaptionTracks) فراهم می‌کند. از این مجموعه می‌توانید زیرنویس‌های WebVTT را به کلیپ پیوست کنید، مسیرهای موجود را استخراج کنید یا آن‌ها را حذف کنید.

### **افزودن زیرنویس صوتی**

این مثال یک کلیپ صوتی را در اسلاید اول جاسازی می‌کند و با [add](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#add) یک مسیر WebVTT محلی را پیوست می‌کند. آرگومان اول برچسب مسیر را عرضه می‌کند و دوم فایل حاوی زیرنویس‌های زمان‌دار را می‌شناسد.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **استخراج زیرنویس‌های صوتی**

این مثال هر مسیر زیرنویسی که به فریم صوتی در اسلاید اول پیوست شده است را استخراج می‌کند. بایت‌های برگشت‌خورده توسط [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getBinaryData) را در یک فایل WebVTT می‌نویسد و شناسه برگشت‌خورده توسط [getCaptionId](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getCaptionId) را به‌عنوان نام فایل استفاده می‌کند تا هر مسیر خروجی جداگانه داشته باشد.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (!java_instanceof($shape, $audioFrameType)) {
            continue;
        }
        $tracks = $shape->getCaptionTracks();
        $trackCount = java_values($tracks->getCount());
        for ($j = 0; $j < $trackCount; $j++) {
            $track = $tracks->get_Item($j);
            $fileName = $track->getCaptionId() . ".vtt";
            $audioCaptions = $track->getBinaryData();
            $output = new Java("java.io.FileOutputStream", $fileName);
            try {
                $output->write($audioCaptions);
            } finally {
                $output->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

### **حذف زیرنویس‌های صوتی**

از [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) یا [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) برای حذف یک مسیر خاص استفاده کنید. این مثال با [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear) تمام زیرنویس‌ها را از اولین فریم صوتی در اسلاید اول حذف می‌کند در حالی که کلیپ را حفظ می‌نماید.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->getCaptionTracks()->clear();
        $presentation->save("audio_without_captions.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

### **یافتن خط در زیرنویس‌های صوتی**

برای یافتن خطی در زیرنویس‌های صوتی اسلاید اول، متن برگشت‌خورده توسط [getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) را در حافظه جستجو کنید. در یک Cue متنی ساده WebVTT، خط زمان‌بندی شامل `-->` است، خطوط زیرنویس پس از آن می‌آیند و یک خط خالی Cue را خاتمه می‌دهد. این مثال برچسب مسیر و هر خط زیرنویس حاوی «café» را چاپ می‌کند.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (!java_instanceof($shape, $audioFrameType)) {
            continue;
        }
        $tracks = $shape->getCaptionTracks();
        $trackCount = java_values($tracks->getCount());
        for ($j = 0; $j < $trackCount; $j++) {
            $track = $tracks->get_Item($j);
            $inCue = false;
            $captions = (string) $track->getDataAsString();
            foreach (preg_split('/\R/u', $captions) as $line) {
                if ($line === "") {
                    $inCue = false;
                } elseif (strpos($line, "-->") !== false) {
                    $inCue = true;
                } elseif ($inCue && preg_match('/café/iu', $line)) {
                    echo $track->getLabel() . ": " . $line . "\n";
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **استخراج صدا**

یک انتقال اسلاید می‌تواند صدای مخصوص به خود را داشته باشد. برای بازیابی آن، بر روی انتقال اسلاید [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/getsound/) را فراخوانی کنید. این مثال بایت‌های برگشت‌خورده توسط [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/) را می‌گیرد و تعداد بایت‌ها را چاپ می‌کند. اگر اسلاید اول صدای انتقال نداشته باشد، به‌جای آن پیامی چاپ می‌شود.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AudioSlide.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $sound = $slide->getSlideShowTransition()->getSound();
    if (java_is_null($sound)) {
        echo "The first slide has no transition sound.\n";
    } else {
        $audioData = $sound->getBinaryData();
        $array = new JavaClass("java.lang.reflect.Array");
        echo "Transition sound: " . $array->getLength($audioData) . " bytes.\n";
    }
} finally {
    $presentation->dispose();
}
```

## **پرسش‌های متداول**

**آیا می‌توانم همان کلیپ صوتی را در چندین اسلاید بدون تکرار استفاده کنم؟**

بله. کلیپ را یکبار به [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) ارائه اضافه کنید و همان شیء صوتی را برای هر اسلاید به [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) پاس دهید.

**آیا می‌توانم صدای موجود در یک فریم صوتی را جایگزین کنم؟**

بله. برای صدای لینک‌شده، از [setLinkPathLong](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/) برای اشاره به فایل جایگزین استفاده کنید. برای صدای جاسازی‌شده، با [setEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/) کلیپ دیگری از مجموعهٔ صوتی ارائه انتخاب کنید. هر دو روش فریم موجود را حفظ می‌کنند.

**آیا برش کردن داده‌های صوتی ذخیره شده در ارائه را تغییر می‌دهد؟**

خیر. [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) و [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) مرزهای پخش را تنظیم می‌کنند. شما همچنان می‌توانید کلیپ کامل را از [getEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/getembeddedaudio/) دریافت کنید.