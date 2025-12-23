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
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجياً في شرائح PowerPoint و OpenDocument باستخدام Aspose.Slides للـ PHP عبر Java. دليل سريع خطوة بخطوة."
---

يمكن للفيديو الموضوع بشكل جيد في العرض التقديمي أن يجعل رسالتك أكثر إقناعًا ويزيد من مستويات التفاعل مع جمهورك. 

PowerPoint يسمح لك بإضافة مقاطع فيديو إلى شريحة في العرض التقديمي بطريقتين:

* إضافة أو تضمين فيديو محلي (مخزن على جهازك)
* إضافة فيديو عبر الإنترنت (من مصدر ويب مثل YouTube).

لسماحك بإضافة مقاطع فيديو (كائنات فيديو) إلى عرض تقديمي، توفر Aspose.Slides الواجهة [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/)، والواجهة [IVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ivideoframe/)، وأنواع أخرى ذات صلة.

## **إنشاء إطارات فيديو مضمّنة**

إذا كان ملف الفيديو الذي تريد إضافته إلى شريحتك مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي. 

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)class.
1. الحصول على مرجع الشريحة عبر فهرستها. 
1. إضافة كائن [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/) وتمرير مسار ملف الفيديو لتضمين الفيديو مع العرض التقديمي.
1. إضافة كائن [IVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ivideoframe/) لإنشاء إطار للفيديو.
1. حفظ العرض التقديمي المعدل. 

يعرض لك هذا الكود PHP كيفية إضافة فيديو مخزن محليًا إلى عرض تقديمي:
```php
  # ينشئ كائن فئة Presentation
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


بدلاً من ذلك، يمكنك إضافة فيديو بتمرير مسار ملفه مباشرة إلى طريقة [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-):
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


## **إنشاء إطارات فيديو باستخدام فيديو من مصادر الويب**

يدعم Microsoft [PowerPoint 2013 والإصدارات الأحدث](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) مقاطع فيديو YouTube في العروض التقديمية. إذا كان الفيديو الذي تريد استخدامه متاحًا على الإنترنت (مثلاً على YouTube)، يمكنك إضافته إلى عرضك التقديمي عبر الرابط الويب الخاص به. 

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)class.
1. الحصول على مرجع الشريحة عبر فهرستها. 
1. إضافة كائن [IVideo](https://reference.aspose.com/slides/php-java/aspose.slides/ivideo/) وتمرير رابط الفيديو.
1. تعيين صورة مصغرة لإطار الفيديو. 
1. حفظ العرض التقديمي. 

يعرض لك هذا الكود PHP كيفية إضافة فيديو من الويب إلى شريحة في عرض PowerPoint التقديمي:
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


## **استخراج الفيديو من الشرائح**

إلى جانب إضافة مقاطع الفيديو إلى الشرائح، تسمح لك Aspose.Slides باستخراج مقاطع الفيديو المدمجة في العروض التقديمية.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) لتحميل العرض التقديمي الذي يحتوي على الفيديو.
2. التنقل عبر جميع كائنات [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide/).
3. التنقل عبر جميع كائنات [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/) للعثور على كائن [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).
4. حفظ الفيديو إلى القرص.

يعرض لك هذا الكود PHP كيفية استخراج الفيديو من شريحة عرض تقديمي:
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

**ما هي معلمات تشغيل الفيديو التي يمكن تغييرها لإطار الفيديو (VideoFrame)؟**

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setplaymode/) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setplayloopmode/). تتوفر هذه الخيارات عبر خصائص كائن [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عند تضمين فيديو محلي، يتم تضمين البيانات الثنائية في المستند، وبالتالي يزداد حجم العرض التقديمي بنسبة حجم الملف. عند إضافة فيديو عبر الإنترنت، يتم تضمين رابط وصورة مصغرة، لذا يكون الزيادة في الحجم أصغر.

**هل يمكنني استبدال الفيديو في إطار فيديو (VideoFrame) موجود دون تغيير موضعه وحجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setembeddedvideo/) داخل الإطار مع الحفاظ على هندسة الشكل؛ وهذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) للفيديو المدمج؟**

نعم. يحتوي الفيديو المدمج على [نوع المحتوى](https://reference.aspose.com/slides/php-java/aspose.slides/video/getcontenttype/) الذي يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه إلى القرص.