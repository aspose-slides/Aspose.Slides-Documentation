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
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجياً في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides for PHP عبر Java. دليل سريع عملي."
---
يمكن للفيديو الموضوع بشكل مناسب في العرض التقديمي أن يجعل رسالتك أكثر إقناعًا ويزيد من مستوى التفاعل مع جمهورك.

PowerPoint يتيح لك إضافة مقاطع فيديو إلى شريحة في عرض تقديمي بطريقتين:

* إضافة فيديو محلي أو تضمينه (مخزن على جهازك)
* إضافة فيديو عبر الإنترنت (من مصدر ويب مثل يوتيوب).

لتمكينك من إضافة مقاطع فيديو (كائنات فيديو) إلى عرض تقديمي، توفر Aspose.Slides فئة [Video](https://reference.aspose.com/slides/ar/php-java/aspose.slides/video/) وفئة [VideoFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/) وغيرها من الأنواع ذات الصلة.

## **إنشاء إطارات فيديو مدمجة**

إذا كان ملف الفيديو الذي ترغب في إضافته إلى شريحتك مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة عبر فهرستها.
3. إضافة كائن [Video](https://reference.aspose.com/slides/ar/php-java/aspose.slides/video/) وتمرير مسار ملف الفيديو لتضمينه مع العرض التقديمي.
4. إضافة كائن [VideoFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/) لإنشاء إطار للفيديو.
5. حفظ العرض التقديمي المعدل.

يعرض هذا الكود PHP كيفية إضافة فيديو مخزن محليًا إلى عرض تقديمي:

```php
  # إنشاء كائن من فئة Presentation
  $pres = new Presentation("pres.pptx");
  try {
    # يحمل الفيديو
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # يحصل على الشريحة الأولى ويضيف إطار فيديو
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # يحفظ العرض التقديمي إلى القرص
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

بدلاً من ذلك، يمكنك إضافة فيديو بتمرير مسار ملفه مباشرة إلى طريقة [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/addvideoframe/):

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

## **إنشاء إطارات فيديو باستخدام فيديو من مصادر ويب**

يدعم Microsoft [PowerPoint 2013 والإصدارات الأحدث](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) مقاطع الفيديو من يوتيوب في العروض التقديمية. إذا كان الفيديو الذي تريد استخدامه متاحًا على الإنترنت (مثل يوتيوب)، يمكنك إضافته إلى العرض التقديمي من خلال رابطه على الويب.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة عبر فهرستها.
3. إضافة كائن [Video](https://reference.aspose.com/slides/ar/php-java/aspose.slides/video/) وتمرير الرابط إلى الفيديو.
4. ضبط صورة مصغرة لإطار الفيديو.
5. حفظ العرض التقديمي.

يعرض هذا الكود PHP كيفية إضافة فيديو من الويب إلى شريحة في عرض PowerPoint:

```php
  # إنشاء كائن Presentation يمثل ملف عرض تقديمي
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

## **إدارة تسميات الفيديو المقفولة**

تتيح لك Aspose.Slides إدارة التسميات المقفولة لإطارات الفيديو في عروض PowerPoint. تُخزن التسميات بتنسيق WebVTT وتُظهر عبر طريقة [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/#getCaptionTracks).

**إضافة تسميات إلى إطار فيديو**

لإضافة تسميات إلى إطار فيديو:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
2. إضافة فيديو إلى العرض التقديمي.
3. إضافة كائن [VideoFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/) إلى شريحة.
4. استخدام مجموعة [CaptionsCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/captionscollection/) التي تُرجعها الطريقة [getCaptionTracks](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/#getCaptionTracks) لإضافة مسار تسمية WebVTT.
5. حفظ العرض التقديمي المعدل.

يعرض الكود التالي كيفية إضافة تسميات إلى إطار فيديو:

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // يضيف مسار تسميات جديد من ملف WebVTT.
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

توفر فئة [CaptionsCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/captionscollection/) أيضًا نسخة زائدة تسمح لك بإضافة تسميات من تدفق بيانات.

**استخراج التسميات من إطار فيديو**

لاستخراج التسميات من إطار فيديو:

1. تحميل العرض التقديمي الذي يحتوي على الفيديو.
2. العثور على كائن [VideoFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/) المستهدف.
3. التنقل خلال مجموعة [getCaptionTracks](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/#getCaptionTracks).
4. حفظ كل مسار تسمية إلى ملف `.vtt`.

يعرض الكود التالي كيفية استخراج التسميات من إطار فيديو:

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
                // يحفظ مسار التسميات إلى ملف WebVTT.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

كل كائن [Captions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/captions/) يكشف عن معرف التسمية، التسمية، البيانات الثنائية، ونص التسمية كسلسلة UTF-8.

**إزالة التسميات من إطار فيديو**

لإزالة التسميات من إطار فيديو:

1. تحميل العرض التقديمي الذي يحتوي على الفيديو.
2. الحصول على كائن [VideoFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/) المستهدف.
3. إزالة مسارات التسميات من مجموعة [getCaptionTracks](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/#getCaptionTracks).
4. حفظ العرض التقديمي المعدل.

يعرض الكود التالي كيفية إزالة جميع التسميات من إطار فيديو:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // النوع: VideoFrame

    // يزيل جميع التسميات من إطار الفيديو.
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

إذا كنت بحاجة إلى إزالة مسار تسمية واحد فقط، استخدم طرق [remove](https://reference.aspose.com/slides/ar/php-java/aspose.slides/captionscollection/#remove) أو [removeAt](https://reference.aspose.com/slides/ar/php-java/aspose.slides/captionscollection/#removeAt) بدلاً من [clear](https://reference.aspose.com/slides/ar/php-java/aspose.slides/captionscollection/#clear).

## **استخراج الفيديو من الشرائح**

بالإضافة إلى إضافة الفيديوهات إلى الشرائح، تتيح لك Aspose.Slides استخراج الفيديوهات المدمجة في العروض التقديمية.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) لتحميل العرض التقديمي الذي يحتوي على الفيديو.
2. التنقل خلال جميع كائنات [Slide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/).
3. التنقل خلال جميع كائنات [Shape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/) للعثور على كائن [VideoFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/).
4. حفظ الفيديو إلى القرص.

يعرض هذا الكود PHP كيفية استخراج الفيديو من شريحة عرض تقديمي:

```php
  # ينشئ كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation("VideoSample.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
          $vf = $shape;
          $type = $vf->getEmbeddedVideo()->getContentType();
          $ss = $type->lastIndexOf('-');
          $buffer = $vf->getEmbeddedVideo()->getBinaryData();
          # يحصل على امتداد الملف
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

## **الأسئلة الشائعة**

**ما هي معلمات تشغيل الفيديو التي يمكن تغييرها لإطار VideoFrame؟**

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/setplaymode/) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/setplayloopmode/). هذه الخيارات متاحة عبر خصائص كائن [VideoFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/).

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عندما تقوم بتضمين فيديو محلي، تُضمّن البيانات الثنائية في المستند، وبالتالي ينمو حجم العرض التقديمي بنسبة حجم الملف. عندما تضيف فيديوًا عبر الإنترنت، يتم تضمين رابط وصورة مصغرة، لذا يكون الارتفاع في الحجم أصغر.

**هل يمكنني استبدال الفيديو في إطار VideoFrame موجود دون تغيير موضعه وحجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/setembeddedvideo/) داخل الإطار مع الحفاظ على هندسة الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) للفيديو المدمج؟**

نعم. للفيديو المدمج [نوع محتوى](https://reference.aspose.com/slides/ar/php-java/aspose.slides/video/getcontenttype/) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه على القرص.