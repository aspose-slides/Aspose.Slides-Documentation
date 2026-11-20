---
title: إدارة إطارات الصوت في العروض التقديمية باستخدام PHP
linktitle: إطار الصوت
type: docs
weight: 10
url: /ar/php-java/audio-frame/
keywords:
- صوت
- إطار صوت
- صورة مصغرة
- إضافة صوت
- خصائص الصوت
- خيارات الصوت
- استخراج الصوت
- PHP
- Aspose.Slides
description: "تضمين الصوت في الشرائح، تغيير أيقونة الصوت، تكوين التشغيل، إدارة ترجمات WebVTT، واستخراج أصوات انتقال الشرائح باستخدام Aspose.Slides for PHP عبر Java."
---
## **نظرة عامة**

يتيح لك إطار الصوت تشغيل مقطع صوتي على الشريحة. باستخدام Aspose.Slides for PHP عبر Java، يمكنك تضمين مقطع صوتي، اختيار الصورة التي تمثله، ضبط التشغيل، وإرفاق الترجمات. يمكنك أيضًا استرداد الصوت المعيّن لانتقال الشريحة.

## **إنشاء إطارات صوتية**

استخدم [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) لتضمين مقطع صوتي محلي على الشريحة الأولى. تُحدِّد الإحداثيتان الأوليان موضع الإطار على الشريحة، وتُحدِّد القيمتان التاليتان عرضه وارتفاعه، جميعها بالنقاط. تستدعي هذه الأمثلة [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) لبدء تشغيل المقطع تلقائيًا وتستدعي [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) لاختيار إعداد الصوت المسبق.

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

## **تغيير صورة معاينة إطار الصوت**

بشكل افتراضي، يعرض إطار الصوت أيقونة مكبر صوت. لعرض صورة معاينة مخصصة، أضف صورة إلى العرض التقديمي باستخدام [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) واضبطها على صورة الإطار عبر [setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/setimage/). تستخدم الأمثلة ملف JPEG كصورة معاينة لمقطع صوتي مضمّن.

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

## **تغيير خيارات تشغيل الصوت**

تتحكم عناصر **خيارات الصوت** في PowerPoint في متى يبدأ المقطع، ومستوى صوته، وكيفية تصرفه أثناء العرض التقديمي.

![عناصر تحكم خيارات الصوت في PowerPoint لإطار صوتي](audio_frame_0.png)

| عنصر تحكم PowerPoint | طريقة Aspose.Slides for PHP عبر Java |
| --- | --- |
| البدء | [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) |
| إعداد الصوت المسبق | [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) |
| التشغيل عبر الشرائح | [setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayacrossslides/) |
| التكرار حتى الإيقاف | [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayloopmode/) |
| إخفاء أثناء العرض | [setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/sethideatshowing/) |
| إرجاع التشغيل بعد الانتهاء | [setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setrewindaudio/) |
| تلاشي الدخول | [setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration) |
| تلاشي الخروج | [setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration) |
| قص وقت بدء الصوت | [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) |
| قص وقت انتهاء الصوت | [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) |
| شريط تمرير مستوى الصوت | [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) |

تجد الأمثلة أول إطار صوتي على الشريحة الأولى، وتستدعي [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) لتشغيله بنقرة، وتختار إعداد الصوت المنخفض. يستمر المقطع عبر الشرائح مع تعطيل التكرار. يبقى الرمز مخفيًا أثناء العرض، ويُعاد تشغيل المقطع بعد الانتهاء.

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

للمقاطع التي تتجاوز 3.5 ثوانٍ، يتخطى المثال الثواني 1.5 الأولى و2 الأخيرة. يأخذ [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) المدة التي يجب إزالتها من نهاية المقطع. للحصول على وقت الانتهاء المعروض في PowerPoint، اطرح هذا الإزاحة من المدة الكلية للمقطع. يشتمل المقطع المقصوص على تلاشي دخول خلال 200 مللي ثانية وتلاشي خروج خلال 500 مللي ثانية. جميع الطرق الأربع تأخذ القيم بالمللي ثانية.

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

لتحديد مستوى الصوت كنسبة مئوية محددة، استخدم [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue). تُعيّن هذه الأمثلة أول إطار صوتي على الشريحة الأولى إلى 85٪.

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

## **إدارة ترجمات الصوت**

يوفر كل إطار صوتي إمكانية الوصول إلى مسارات الترجمات الخاصة به عبر [getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#getCaptionTracks). استخدم المجموعة لإرفاق ترجمات WebVTT بالمقاطع، أو لتصدير المسارات الموجودة، أو لإزالتها.

### **إضافة ترجمات صوتية**

تضمّن الأمثلة مقطعًا صوتيًا على الشريحة الأولى وتستدعي [add](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#add) لإرفاق مسار WebVTT محلي. تُزوِّد الوسيطة الأولى تسمية المسار، وتُحدِّد الوسيطة الثانية الملف الذي يحتوي على الترجمات المُحدَّدة بالوقت.

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

### **استخراج ترجمات صوتية**

تصدّر هذه الأمثلة كل مسار ترجمة مرفق بإطار صوتي على الشريحة الأولى. تكتب البايتات التي تُعيدها [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getBinaryData) إلى ملف WebVTT وتستخدم المُعرِّف الذي تُعيده [getCaptionId](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getCaptionId) كاسم للملف بحيث يكون لكل مسار مخرج منفصل.

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

### **إزالة ترجمات صوتية**

استخدم [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) أو [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) لحذف مسار فردي. تستعمل الأمثلة [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear) لإزالة جميع الترجمات من أول إطار صوتي على الشريحة الأولى مع الحفاظ على المقطع.

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

### **البحث عن سطر في ترجمات الصوت**

للبحث عن سطر في ترجمات الصوت على الشريحة الأولى، ابحث في النص الذي تُعيده [getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) في الذاكرة. في Cue نصي بسيط بتنسيق WebVTT، يحتوي سطر التوقيت على `-->`، وتتبعه سطور الترجمات، ويساهم سطر فارغ في إنهاء الـCue. تُظهر الأمثلة تسمية المسار وكل سطر ترجمة يحتوي على كلمة “café”.

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

## **استخراج الصوت**

يمكن أن يحتوي انتقال الشريحة على صوت خاص به. لاسترداده، استدعِ [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/getsound/) على انتقال الشريحة. تُصلِّط الأمثلة إلى البايتات التي تُعيدها [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/) وتطبع عدد البايتات. إذا لم تكن الشريحة الأولى تحتوي على صوت انتقال، تُطبع رسالة بدلاً من ذلك.

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

## **الأسئلة الشائعة**

**هل يمكن إعادة استخدام نفس المقطع الصوتي عبر عدة شرائح بدون تكراره؟**

نعم. أضف المقطع مرة واحدة إلى [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) الخاصة بالعرض التقديمي، ومرّر كائن الصوت نفسه إلى [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) لكل شريحة.

**هل يمكن استبدال الصوت في إطار صوتي موجود؟**

نعم. للصوت المرتبط، استخدم [setLinkPathLong](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/) لتوجيهه إلى ملف الاستبدال. للصوت المُضمّن، اختر مقطعًا آخر من مجموعة الصوت في العرض التقديمي عبر [setEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/). كلا الطريقتين تحافظان على الإطار الحالي.

**هل يؤدي القص إلى تغيير بيانات الصوت المخزّنة في العرض التقديمي؟**

لا. يُحدِّد كل من [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) و[setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) حدود التشغيل. لا يزال بإمكانك استرداد المقطع الكامل عبر [getEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/getembeddedaudio/).