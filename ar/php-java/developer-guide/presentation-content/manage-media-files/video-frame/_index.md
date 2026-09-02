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
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجيًا في شرائح PowerPoint و OpenDocument باستخدام Aspose.Slides للـ PHP عبر Java. دليل سريع عملي."
---
## **المقدمة**

يمكن أن يجعل الفيديو الموجود في المكان المناسب داخل العرض التقديمي رسالتك أكثر إقناعًا ويزيد من مستويات التفاعل مع الجمهور.

يسمح PowerPoint بإضافة مقاطع فيديو إلى شريحة في العرض التقديمي بطريقتين:

* إضافة أو تضمين فيديو محلي (مخزن على جهازك)
* إضافة فيديو عبر الإنترنت (من مصدر ويب مثل YouTube).

لإضافة مقاطع فيديو (كائنات فيديو) إلى العرض التقديمي، توفر Aspose.Slides الفئة [Video](https://reference.aspose.com/slides/ar/php-java/aspose.slides/video/) والفئة [VideoFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/) وأنواع أخرى ذات صلة.

## **إنشاء إطارات فيديو مضمَّنة**

إذا كان ملف الفيديو الذي تريد إضافته إلى شريحتك مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في العرض التقديمي.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).  
1. الحصول على مرجع الشريحة عبر فهرستها.  
1. إضافة كائن [Video](https://reference.aspose.com/slides/ar/php-java/aspose.slides/video/) وتمرير مسار ملف الفيديو لتضمينه مع العرض التقديمي.  
1. إضافة كائن [VideoFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/) لإنشاء إطار للفيديو.  
1. حفظ العرض التقديمي المعدل.  

هذا المثال بلغة PHP يوضح كيفية إضافة فيديو مخزن محليًا إلى العرض التقديمي:

```php
  # ينشئ فئة Presentation
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

بدلاً من ذلك، يمكنك إضافة فيديو عن طريق تمرير مسار الملف مباشرةً إلى الطريقة [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/addvideoframe/):

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

## **إنشاء إطارات فيديو من مصادر ويب**

يدعم Microsoft [PowerPoint 2013 والإصدارات الأحدث](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) مقاطع الفيديو من YouTube في العروض التقديمية. إذا كان الفيديو الذي تريد استخدامه متاحًا عبر الإنترنت (مثل YouTube)، يمكنك إضافته إلى العرض التقديمي من خلال رابطه على الويب.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).  
1. الحصول على مرجع الشريحة عبر فهرستها.  
1. إضافة كائن [Video](https://reference.aspose.com/slides/ar/php-java/aspose.slides/video/) وتمرير رابط الفيديو.  
1. تعيين صورة مصغرة لإطار الفيديو.  
1. حفظ العرض التقديمي.  

هذا المثال بلغة PHP يوضح كيفية إضافة فيديو من الويب إلى شريحة في عرض PowerPoint:

```php
  # ينشئ كائن Presentation يمثل ملف عرض تقديمي
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

## **قَص إطار الفيديو**

تتيح Aspose.Slides التحكم في الجزء الذي يُشغَّل من الفيديو عن طريق تعيين قيمتي القطع من البداية والقطع من النهاية عبر [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/#setTrimFromStart) و[VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/#setTrimFromEnd). تُحدَّد القيمتين بالميليثانية وتحدد مقدار الوقت المُتَخطى من بداية ونهاية الفيديو على التوالي. تُغيِّر هذه الإعدادات طريقة تشغيل الفيديو في العرض التقديمي؛ ولا تقوم بقطع أو تعديل بيانات الفيديو المضمَّنة.

**تعيين إعدادات القطع**

لإنشاء إطار فيديو وتعيين إعدادات القطع الخاصة به:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).  
1. إضافة كائن [Video](https://reference.aspose.com/slides/ar/php-java/aspose.slides/video/) إلى العرض التقديمي.  
1. إضافة كائن [VideoFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/) إلى شريحة.  
1. تعيين قيمتي القطع من البداية والقطع من النهاية عبر [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/#setTrimFromStart) و[VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/#setTrimFromEnd).  
1. حفظ العرض التقديمي المعدل.  

الكود التالي يتخطى أول 2.5 ثانية وآخر ثانية من الفيديو المضمَّن أثناء التشغيل:

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

**قراءة إعدادات القطع**

لفحص إعدادات القطع الحالية، حمِّل عرض تقديمي، ابحث عن كائن [VideoFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/) بين الأشكال في الشريحة الأولى، واقرأ القيم عبر [VideoFrame::getTrimFromStart](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/#getTrimFromStart) و[VideoFrame::getTrimFromEnd](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/#getTrimFromEnd).

الكود التالي يجد أول إطار فيديو في الشريحة الأولى ويُظهر إعدادات القطع بالميليثانية:

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

## **إدارة تسميات الفيديو**

تتيح Aspose.Slides إدارة التسميات المغلقة (closed captions) لإطارات الفيديو في عروض PowerPoint. تُحفظ التسميات بتنسيق WebVTT وتُستخرج عبر طريقة [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/#getCaptionTracks).

**إضافة تسميات إلى إطار فيديو**

لإضافة تسميات إلى إطار فيديو:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).  
1. إضافة فيديو إلى العرض التقديمي.  
1. إضافة كائن [VideoFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/) إلى شريحة.  
1. استخدام مجموعة [CaptionsCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/captionscollection/) التي تُرجِعها طريقة [getCaptionTracks](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/#getCaptionTracks) لإضافة مسار تسمية WebVTT.  
1. حفظ العرض التقديمي المعدل.  

الكود التالي يوضح كيفية إضافة تسميات إلى إطار فيديو:

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

توفر الفئة [CaptionsCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/captionscollection/) أيضًا نسخة مُحمَّلة تسمح لك بإضافة تسميات من تدفق (stream).

**استخراج التسميات من إطار فيديو**

لاستخراج التسميات من إطار فيديو:

1. تحميل العرض التقديمي الذي يحتوي على الفيديو.  
1. العثور على كائن [VideoFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/) المستهدف.  
1. iterating عبر مجموعة [getCaptionTracks](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/#getCaptionTracks).  
1. حفظ كل مسار تسمية إلى ملف `.vtt`.  

الكود التالي يوضح كيفية استخراج التسميات من إطار فيديو:

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
                // يحفظ مسار التسمية إلى ملف WebVTT.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

كل كائن [Captions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/captions/) يُظهر معرف التسمية، التسمية، البيانات الثنائية، ونص التسمية كسلسلة UTF-8.

**إزالة التسميات من إطار فيديو**

لإزالة التسميات من إطار فيديو:

1. تحميل العرض التقديمي الذي يحتوي على الفيديو.  
1. الحصول على كائن [VideoFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/) المستهدف.  
1. إزالة مسارات التسميات من مجموعة [getCaptionTracks](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/#getCaptionTracks).  
1. حفظ العرض التقديمي المعدل.  

الكود التالي يوضح كيفية إزالة جميع التسميات من إطار فيديو:

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

إذا كنت بحاجة إلى إزالة مسار تسمية واحد فقط، استخدم الطريقتين [remove](https://reference.aspose.com/slides/ar/php-java/aspose.slides/captionscollection/#remove) أو [removeAt](https://reference.aspose.com/slides/ar/php-java/aspose.slides/captionscollection/#removeAt) بدلًا من [clear](https://reference.aspose.com/slides/ar/php-java/aspose.slides/captionscollection/#clear).

## **استخراج الفيديو من الشرائح**

إلى جانب إضافة الفيديو إلى الشرائح، تسمح Aspose.Slides باستخراج الفيديوهات المضمَّنة في العروض التقديمية.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) لتحميل العرض التقديمي الذي يحتوي على الفيديو.  
2. iterating عبر جميع كائنات [Slide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/).  
3. iterating عبر جميع كائنات [Shape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/) للعثور على كائن [VideoFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/).  
4. حفظ الفيديو إلى القرص.  

الكود PHP التالي يوضح كيفية استخراج الفيديو من شريحة في عرض PowerPoint:

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

## **الأسئلة المتكررة**

**ما المعلمات القابلة للتغيير لتشغيل إطار الفيديو؟**

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/setplaymode/) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/setplayloopmode/). تتوفر هذه الخيارات عبر خصائص كائن [VideoFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/).

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عند تضمين فيديو محلي، تُدرَج البيانات الثنائية في المستند، وبالتالي يزداد حجم العرض التقديمي بنسبة حجم الملف. عند إضافة فيديو عبر الإنترنت، يُضمَّن رابط وصورة مصغرة فقط، لذا يكون الزيادة أصغر.

**هل يمكن استبدال الفيديو في إطار فيديو موجود دون تغيير موقعه وحجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/ar/php-java/aspose.slides/videoframe/setembeddedvideo/) داخل الإطار مع الحفاظ على أبعاد الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) للفيديو المضمَّن؟**

نعم. للفيديو المضمَّن [نوع محتوى](https://reference.aspose.com/slides/ar/php-java/aspose.slides/video/getcontenttype/) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه إلى القرص.