---
title: إطار الفيديو
type: docs
weight: 10
url: /ar/php-java/video-frame/
keywords: "إضافة فيديو، إنشاء إطار فيديو، استخراج فيديو، عرض PowerPoint، Java، Aspose.Slides لـ PHP عبر Java"
description: "إضافة إطار فيديو إلى عرض PowerPoint"
---

يمكن أن يجعل الفيديو موضوع تم وضعه بشكل جيد في العرض رسالتك أكثر تأثيرًا ويزيد من مستويات الانخراط مع جمهورك.

تسمح PowerPoint لك بإضافة مقاطع الفيديو إلى شريحة في العرض بطريقتين:

* إضافة أو تضمين فيديو محلي (مخزن على جهازك)
* إضافة فيديو عبر الإنترنت (من مصدر ويب مثل YouTube).

للسماح لك بإضافة مقاطع الفيديو (كائنات الفيديو) إلى العرض، توفر Aspose.Slides واجهة [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/) وواجهة [IVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ivideoframe/) وأنواع أخرى ذات صلة.

## **إنشاء إطار فيديو مضمن**

إذا كان ملف الفيديو الذي ترغب في إضافته إلى شريحتك مخزناً محلياً، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إضافة كائن [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/) وتمرير مسار ملف الفيديو لتضمين الفيديو مع العرض.
1. إضافة كائن [IVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ivideoframe/) لإنشاء إطار للفيديو.
1. حفظ العرض المعدل.

يعرض هذا الكود PHP كيفية إضافة فيديو مخزن محليًا إلى عرض:

```php
  # إنشاء مثيل لفئة Presentation
  $pres = new Presentation("pres.pptx");
  try {
    # تحميل الفيديو
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # الحصول على الشريحة الأولى وإضافة إطار فيديو
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # حفظ العرض على القرص
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

بدلاً من ذلك، يمكنك إضافة فيديو عن طريق تمرير مسار ملفه مباشرة إلى الطريقة [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :

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

## **إنشاء إطار فيديو مع فيديو من مصدر ويب**

تدعم Microsoft [PowerPoint 2013 وما بعده](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) مقاطع الفيديو من YouTube في العروض التقديمية. إذا كان الفيديو الذي ترغب في استخدامه متاحًا عبر الإنترنت (مثل YouTube)، يمكنك إضافته إلى عرضك من خلال رابط الويب الخاص به.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إضافة كائن [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/) وتمرير الرابط إلى الفيديو.
1. تعيين صورة مصغرة لإطار الفيديو.
1. حفظ العرض.

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

## **استخراج الفيديو من الشريحة**

بالإضافة إلى إضافة مقاطع الفيديو إلى الشرائح، تسمح Aspose.Slides لك باستخراج مقاطع الفيديو المضمّنة في العروض التقديمية.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) لتحميل العرض الذي يحتوي على الفيديو.
2. التكرار عبر جميع كائنات [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide/).
3. التكرار عبر جميع كائنات [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/) للعثور على [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).
4. حفظ الفيديو على القرص.

يعرض هذا الكود PHP كيفية استخراج الفيديو من شريحة العرض:

```php
  # إنشاء كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation("VideoSample.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
          $vf = $shape;
          $type = $vf->getEmbeddedVideo()->getContentType();
          $ss = $type->lastIndexOf('-');
          $buffer = $vf->getEmbeddedVideo()->getBinaryData();
          # الحصول على امتداد الملف
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