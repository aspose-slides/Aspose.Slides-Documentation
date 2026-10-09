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
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجيًا في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides for PHP عبر Java. دليل سريع عملي."
---
## **المقدمة**

يمكن للفيديوهات أن تساعد في شرح الأفكار وإشراك الجمهور. تتيح لك Aspose.Slides for PHP عبر Java إضافة إطارات فيديو إلى الشرائح، وضبط إعدادات التشغيل، وإدارة الترجمات، واستخراج بيانات الفيديو المضمنة.

يدعم PowerPoint الفيديوهات المحلية والروابط إلى الفيديوهات على الإنترنت، مثل فيديوهات YouTube.

لتمثيل بيانات الفيديو وإطارات الفيديو، توفر Aspose.Slides الفئة [فيديو](https://reference.aspose.com/slides/php-java/aspose.slides/video/)، الفئة [إطار فيديو](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/)، وأنواع أخرى ذات صلة.

## **إنشاء إطار فيديو مضمّن**

إذا كان ملف الفيديو الذي تريد إضافته إلى شريحتك مخزّنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي.

يقوم هذا المثال بتضمين فيديو محلي على الشريحة الأولى من عرض تقديمي موجود ويحفظ النتيجة. إحداثيات الإطار وأبعاده بوحدات النقاط. يبقى التيار مفتوحًا حتى ينتهي الحفظ لأن [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) يبقيه مقفولًا أثناء استخدام العرض التقديمي له.

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

يمكنك أيضًا تمرير مسار الفيديو المحلي مباشرة إلى [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame). يقوم هذا المثال بتضمين الفيديو على الشريحة الأولى من عرض تقديمي جديد. يجب أن يظل الفيديو متاحًا حتى يتم حفظ العرض التقديمي.

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

يدعم Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) الفيديوهات عبر الإنترنت في العروض التقديمية. يمكنك إنشاء إطار فيديو يرتبط بفيديو عبر الإنترنت، مثل فيديو YouTube.

يضيف هذا المثال رابط فيديو YouTube وصورة مصغرة إلى الشريحة الأولى. استبدل معرف الفيديو لاستخدام فيديو آخر. طريقة [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) تطلب تشغيلًا تلقائيًا. تنزيل الصورة المصغرة وتشغيل الفيديو يتطلبان اتصالًا بالإنترنت. يجب أن يدعم عارض العرض التقديمي أيضًا تشغيل الفيديو عبر الإنترنت.

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

في عرض تدريبي، يمكنك تشغيل عرض توضيحي للبرنامج في وضع ملء الشاشة بحيث يراها الجمهور بالتفصيل. استدعِ [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) مع `true` لتمكين هذا السلوك أثناء التشغيل.

يفتح هذا المثال عرضًا تقديميًا، يجد أول [إطار فيديو](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) في الشريحة الأولى، ويفعل تشغيل ملء الشاشة. يجب أن يحتوي العرض التقديمي المدخل على شريحة واحدة على الأقل مع إطار فيديو موجود في الشريحة الأولى.

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

تشغيل ملء الشاشة يتحكم في طريقة عرض الفيديو. بشكل مستقل، تتحكم [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) في ما إذا كان يبدأ تلقائيًا أو عند النقر، وتتحكم [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) في ما إذا كان يكرّر. لاختيار سلوك البدء، عيّن وضع التشغيل إلى [VideoPlayModePreset::Auto أو VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/). يحافظ المثال على إعدادات البدء والتكرار الحالية.

## **إعادة تموضع الفيديو بعد التشغيل**

في عرض تدريبي، إعادة تشغيل فيديو التوضيح إلى بدايته يجعلها جاهزة للمقدم لتشغيله مرة أخرى. استدعِ [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) مع `true` لإرجاع الفيديو إلى بدايته بعد انتهاء التشغيل.

يفتح هذا المثال عرضًا تقديميًا، يجد أول [إطار فيديو](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) في الشريحة الأولى، ويفعل الإعادة إلى البداية. يعطل التكرار حتى يتمكن التشغيل من الانتهاء ويعيّن التشغيل للبدء عند النقر. يجب أن يحتوي العرض التقديمي المدخل على شريحة واحدة على الأقل مع إطار فيديو موجود في الشريحة الأولى.

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

الإعادة إلى البداية تُعيد الفيديو إلى بدايته دون تشغيله مرة أخرى. على النقيض من ذلك، استدعاء [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) مع `true` يكرر التشغيل تلقائيًا. أبقِ التكرار معطلاً عندما تريد أن ينتهي الفيديو ويبقى جاهزًا لإعادة التشغيل. تتحكم [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) بشكل مستقل في التشغيل التلقائي أو عند النقر؛ يستخدم هذا المثال [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) بحيث يسيطر المقدم على بدء التشغيل. عيّن وضع التشغيل بعد إعداد التكرار، كما هو موضح في المثال. تعمل الإعادة إلى البداية بشكل مستقل عن [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode).

## **قص إطار فيديو**

استخدم [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) و[VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd) لتخطي جزء من بداية أو نهاية الفيديو أثناء التشغيل. كلا القيمتين بوحدة المللي ثانية. القص يغيّر إعدادات التشغيل دون تعديل بيانات الفيديو المضمّن.

**إعدادات القص**

يقوم هذا المثال بتضمين فيديو محلي ويتخطى أول 2.5 ثانية وآخر ثانية واحدة أثناء التشغيل. استخدم فيديوً أطول من 3.5 ثانية حتى يبقى جزء قابل للتشغيل.

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

**قراءة إعدادات القص**

يطبع هذا المثال قيم قص أول إطار فيديو على الشريحة الأولى بالمللي ثانية. يجب أن يحتوي العرض التقديمي على شريحة واحدة على الأقل. إذا لم تحتوي تلك الشريحة على إطار فيديو، لا يُطبع شيء. ينتج المثال السابق قيمتين 2500 و1000.

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

## **إدارة ترجمات الفيديو**

تسمح لك Aspose.Slides بإدارة الترجمات المغلقة لإطارات الفيديو في عروض PowerPoint. تُخزن الترجمات بتنسيق WebVTT وتُظهر عبر طريقة [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks).

**إضافة ترجمات إلى إطار فيديو**

يقوم هذا المثال بتضمين فيديو محلي ويضيف مسار ترجمة WebVTT معلم بـ "English". يجب أن تتطابق طوابع زمنية الترجمة مع الفيديو. يتضمن العرض التقديمي المحفوظ كلًا من الفيديو وترجماته.

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

توفر الفئة [CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) أيضًا حملًا إضافيًا يتيح لك إضافة الترجمات من تدفق.

**استخراج ترجمات من إطار فيديو**

يحفظ هذا المثال جميع مسارات الترجمات من إطارات الفيديو على الشريحة الأولى كملفات WebVTT منفصلة. تُستخدم الأرقام المتسلسلة للحفاظ على تميز ملفات الإخراج. يسجل الطرفية عدد المسارات المستخرجة. يجب أن يحتوي العرض التقديمي على شريحة واحدة على الأقل.

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

كل كائن [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/) يكشف عن معرف الترجمة، اللقب، البيانات الثنائية، ونص الترجمة كسلسلة UTF-8.

**إزالة ترجمات من إطار فيديو**

يزيل هذا المثال جميع الترجمات من إطار الفيديو في أول موضع شكل على الشريحة الأولى ويحفظ النتيجة. يفترض وجود الشريحة والشكل وأن الشكل هو إطار فيديو.

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

إذا كنت بحاجة إلى إزالة مسار ترجمة واحد فقط، استخدم طريقة [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) أو [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) بدلًا من [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear).

## **استخراج فيديو من شريحة**

بالإضافة إلى إضافة فيديوهات إلى الشرائح، تتيح لك Aspose.Slides استخراج الفيديوهات المضمنة في العروض التقديمية.

يستخرج هذا المثال الفيديوهات المضمنة من كل شريحة إلى ملفات ثنائية منفصلة مرقمة. تُهمل الفيديوهات المرتبطة لأنها لا تحتوي على بيانات مضمَّنة. يطبع الطرفية نوع MIME لكل فيديو وإجمالي العدد. يستخدم الإخراج الامتداد العام `.bin`؛ عدّل الامتداد ليتطابق مع نوع الوسائط المُبلغ عنه عند الحاجة.

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

## **الأسئلة الشائعة**

**ما هي معلمات تشغيل الفيديو التي يمكن تعديلها لإطار الفيديو؟**

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode). تتوفر هذه الخيارات عبر طرق كائن [إطار فيديو](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عندما تُضمّن فيديو محلي، تُضمّن البيانات الثنائية في المستند، فيزداد حجم العرض التقديمي بما يتناسب مع حجم الملف. عند ربط فيديو عبر الإنترنت وإضافة صورة مصغرة، يخزن العرض التقديمي الرابط وصورة المعاينة بدلاً من بيانات الفيديو، لذا يكون الزيادة عادة أصغر.

**هل يمكنني استبدال الفيديو في إطار فيديو موجود دون تغيير موضعه وحجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo) داخل الإطار مع الحفاظ على هندسة الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) للفيديو المضمّن؟**

نعم. للفيديو المضمّن [نوع محتوى](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه على القرص.