---
title: إدارة إطارات الفيديو في العروض التقديمية باستخدام PHP
linktitle: إطار الفيديو
type: docs
weight: 10
url: /ar/php-java/video-frame/
keywords:
- إضافة فيديو
- إنشاء فيديو
- تضمين فيديو
- استخراج فيديو
- استرجاع فيديو
- إطار فيديو
- مصدر ويب
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلّم كيفية إضافة واستخراج إطارات الفيديو برمجيًا في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides لـ PHP عبر Java. دليل سريع خطوة بخطوة."
---
## **المقدمة**

يمكن للفيديوهات أن تساعد في توضيح الأفكار وجذب الجمهور. يتيح Aspose.Slides for PHP عبر Java إمكانية إضافة إطارات فيديو إلى الشرائح، وضبط إعدادات التشغيل، وإدارة التسميات التوضيحية، واستخراج بيانات الفيديو المضمنة.

يدعم PowerPoint مقاطع الفيديو المحلية وروابط مقاطع الفيديو على الإنترنت، مثل مقاطع YouTube.

لتمثيل بيانات الفيديو وإطارات الفيديو، يوفر Aspose.Slides الفئة [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) والفئة [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) وأنواع أخرى ذات صلة.

## **إنشاء إطار فيديو مضمّن**

إذا كان ملف الفيديو الذي تريد إضافةه إلى شريحتك مخزّنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي.

يضمن هذا المثال فيديوً محليًا على الشريحة الأولى من عرض تقديمي موجود ويحفظ النتيجة. إحداثيات الإطار وأبعاده بوحدات النقاط. يظل التدفق مفتوحًا حتى تنتهي عملية الحفظ لأن [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) يبقيه مقفلًا أثناء استخدام العرض التقديمي له.

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

يمكنك أيضًا تمرير مسار فيديو محلي مباشرة إلى [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame). يضمن هذا المثال الفيديو على الشريحة الأولى من عرض تقديمي جديد. يجب أن يبقى الفيديو قابلاً للوصول حتى يتم حفظ العرض التقديمي.

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

## **إنشاء إطار فيديو مع فيديو من مصدر ويب**

يدعم Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) مقاطع الفيديو عبر الإنترنت في العروض التقديمية. يمكنك إنشاء إطار فيديو يربط إلى فيديو على الإنترنت، مثل فيديو YouTube.

يضيف هذا المثال رابط فيديو YouTube وصورة مصغرة إلى الشريحة الأولى. استبدل معرف الفيديو لاستخدام فيديو آخر. تطلب طريقة [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) التشغيل التلقائي. يتطلب تحميل الصورة المصغرة وتشغيل الفيديو اتصالًا بالإنترنت. يجب أن يدعم عارض العرض التقديمي أيضًا تشغيل الفيديو عبر الإنترنت.

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

## **تشغيل فيديو في وضع ملء الشاشة**

في عرض تقديمي تدريبي، يمكنك تشغيل عرض توضيحي للبرنامج في وضع ملء الشاشة حتى يتمكن الجمهور من رؤية التفاصيل. استدعِ [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) مع `true` لتمكين هذا السلوك أثناء التشغيل.

يفتح هذا المثال عرض تقديمي، يجد أول [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) في الشريحة الأولى، ويفعل تشغيل ملء الشاشة. يجب أن يحتوي عرض الإدخال على شريحة واحدة على الأقل تحتوي على إطار فيديو موجود في الشريحة الأولى.

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

يتحكم تشغيل ملء الشاشة في طريقة عرض الفيديو. بشكل مستقل، تتحكم [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) فيما إذا كان يبدأ تلقائيًا أو بنقرة، وتتحكم [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) فيما إذا كان يكرر. لاختيار سلوك البدء، اضبط وضع التشغيل على [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/). يحافظ المثال على إعدادات البدء والتكرار الحالية.

## **إرجاع الفيديو إلى البداية بعد التشغيل**

في عرض تقديمي تدريبي، إرجاع فيديو العرض إلى بدايته يجعله جاهزًا للمقدم لتشغيله مرة أخرى. استدعِ [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) مع `true` لإرجاع الفيديو إلى البداية بعد انتهاء التشغيل.

يفتح هذا المثال عرضًا تقديميًا، يجد أول [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) في الشريحة الأولى، ويفعل الإرجاع. يعطل التكرار حتى يمكن انتهاء التشغيل ويضبط التشغيل للبدء عند النقر. يجب أن يحتوي عرض الإدخال على شريحة واحدة على الأقل تحتوي على إطار فيديو موجود في الشريحة الأولى.

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

إرجاع الفيديو يعيده إلى بدايته دون تشغيله مرة أخرى. على العكس، استدعاء [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) مع `true` يكرر التشغيل تلقائيًا. أبقِ التكرار معطلاً عندما تريد أن ينتهي الفيديو ويظل جاهزًا لإعادة التشغيل. تتحكم [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) بشكل مستقل في بدء التشغيل تلقائيًا أو عند النقر؛ يستخدم هذا المثال [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) بحيث يتحكم المقدم في توقيت بدء التشغيل. اضبط وضع التشغيل بعد إعداد التكرار، كما هو موضح في المثال. يعمل إرجاع الفيديو بشكل مستقل عن [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode).

## **تقليم إطار فيديو**

استخدم [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) و[VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd) لتجاوز جزء من بداية أو نهاية الفيديو أثناء التشغيل. القيمتان بوحدة المليثانية. يغير التقليم إعدادات التشغيل دون تعديل بيانات الفيديو المضمنة.

**تعيين إعدادات التقليم**

يضمن هذا المثال فيديوً محليًا ويتخطى الثواني الأولى 2.5 والثانية الأخيرة أثناء التشغيل. استخدم فيديوًا أطول من 3.5 ثوانٍ بحيث يبقى جزء قابل للتشغيل.

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

**قراءة إعدادات التقليم**

يطبع هذا المثال قيم التقليم لأول إطار فيديو في الشريحة الأولى بالمليثانية. يجب أن يحتوي العرض على شريحة واحدة على الأقل. إذا لم تحتوي تلك الشريحة على إطار فيديو، لن يُطبع شيء. ينتج المثال السابق القيم 2500 و1000.

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

## **إدارة تسميات الفيديو**

يتيح Aspose.Slides لك إدارة التسمية التوضيحية المغلقة لإطارات الفيديو في عروض PowerPoint. تُحفظ التسميات في صيغة WebVTT وتُعرض عبر طريقة [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks).

### **إضافة تسميات إلى إطار فيديو**

يضمن هذا المثال فيديوً محليًا ويضيف مسار تسمية WebVTT مع تسمية English. يجب أن تتطابق طوابع التوقيت مع الفيديو. يتضمن العرض الم保存 الفيديو وتسميعاته.

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

توفر فئة [CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) أيضًا نسخة مُحمّلة تسمح لك بإضافة تسميات من تدفق.

### **استخراج التسميات من إطار فيديو**

يحفظ هذا المثال جميع مسارات التسميات من إطارات الفيديو في الشريحة الأولى كملفات WebVTT منفصلة. تحافظ الأرقام المتتالية على تميز ملفات الإخراج. يوضح وحدة التحكم عدد المسارات المستخرجة. يجب أن يحتوي العرض على شريحة واحدة على الأقل.

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

كل كائن من نوع [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/) يكشف عن معرّف التسمية، والملصق، والبيانات الثنائية، ونص التسمية كسلسلة UTF-8.

### **إزالة التسميات من إطار فيديو**

يزيل هذا المثال جميع التسميات من إطار الفيديو الموجود في الموضع الأول للشكل في الشريحة الأولى ويحفظ النتيجة. يفترض أن الشريحة والشكل موجودان وأن الشكل هو إطار فيديو.

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

إذا كنت تحتاج إلى إزالة مسار تسمية واحد فقط، استخدم طريقتي [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) أو [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) بدلاً من [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear).

### **بحث عن تسميات الفيديو**

ترجع [Captions::getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) المسار الكامل WebVTT، بما في ذلك الرأس، وخطوط التوقيت، ونص التسمية. يمكنك البحث في الإشارات في الذاكرة للعثور على عبارة منطوقة وطابعها الزمني. على سبيل المثال، قد يحتوي مسار English في الشريحة 2 على النص التالي.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

يفتح المثال `captioned_media.pptx` ويستخدم [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks) لقراءة مسارات كل إطار فيديو من المستوى الأعلى في كل شريحة. في إشارة نصية عادية، يحتوي خط التوقيت على `-->`، ويسطر فارغ ينهي الإشارة. عندما تحتوي التسمية على كلمة “café” بأي حالة حرفية، يطبع المثال رقم الشريحة، وملصق المسار، وخط التوقيت الأصلي، والتسمية الكاملة.

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

تنتج عملية البحث عن كلمة “café” تطابقًا واحدًا للمسار التجريبي. يستبعد البحث رأس المسار ويحافظ على إعداد التوقيت في الناتج.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **استخراج فيديو من شريحة**

إلى جانب إضافة مقاطع الفيديو إلى الشرائح، يتيح Aspose.Slides استخراج مقاطع الفيديو المضمنة في العروض التقديمية.

يستخرج هذا المثال مقاطع الفيديو المضمنة من كل شريحة إلى ملفات ثنائية منفصلة ومرقمة. تُتخطى الفيديوهات المرتبطة لأنها لا تحتوي على بيانات مدمجة. تطبع وحدة التحكم نوع MIME لكل فيديو والعدد الإجمالي. يستخدم الإخراج الامتداد العام `.bin`؛ غيّره ليتطابق مع نوع الوسائط المبلغ عنه عند الحاجة.

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

## **الأسئلة المتكررة**

**ما هي معلمات تشغيل الفيديو التي يمكن تغييرها لإطار الفيديو؟**

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) (تلقائي أو بنقرة) و[التكرار](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode). تتوفر هذه الخيارات عبر طرق كائن [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عندما تدمج فيديوً محليًا، تُضمَّن البيانات الثنائية في المستند، فيزداد حجم العرض بنسبة حجم الملف. عندما تربط فيديوًا على الإنترنت وتضيف صورة مصغرة، يخزن العرض الرابط وصورة المعاينة بدلاً من بيانات الفيديو، لذا عادة ما يكون الزيادة أصغر.

**هل يمكنني استبدال الفيديو في إطار فيديو موجود دون تغيير موقعه وحجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo) داخل الإطار مع الحفاظ على أبعاد الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) للفيديو المضمّن؟**

نعم. للفيديو المضمّن [نوع محتوى](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه إلى القرص.