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
- إطار الفيديو
- مصدر ويب
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجياً في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides للغة PHP عبر Java. دليل سريع خطوة بخطوة."
---

يمكن للفيديو الموضوع بشكل مناسب في عرض تقديمي أن يجعل رسالتك أكثر إقناعًا ويزيد من مستويات التفاعل مع جمهورك.  

يتيح لك PowerPoint إضافة مقاطع فيديو إلى شريحة في عرض تقديمي بطريقتين:

* إضافة أو تضمين فيديو محلي (محفوظ على جهازك)
* إضافة فيديو عبر الإنترنت (من مصدر ويب مثل YouTube).

لتمكينك من إضافة مقاطع فيديو (كائنات الفيديو) إلى عرض تقديمي، توفر مكتبة Aspose.Slides الفئة [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/)، الفئة [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) وأنواع أخرى ذات صلة.

## **Create Embedded Video Frames**

إذا كان ملف الفيديو الذي تريد إضافته إلى الشريحة مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي.  

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  
1. احصل على مرجع الشريحة عبر فهرسها.  
1. أضف كائنًا من النوع [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) ومرّر مسار ملف الفيديو لتضمينه مع العرض التقديمي.  
1. أضف كائنًا من النوع [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) لإنشاء إطار للفيديو.  
1. احفظ العرض التقديمي المعدل.  

يعرض هذا الشيفرة PHP كيفية إضافة فيديو مخزن محليًا إلى عرض تقديمي:
```php
  # إنشاء كائن من الفئة Presentation
  $pres = new Presentation("pres.pptx");
  try {
    # تحميل الفيديو
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # الحصول على الشريحة الأولى وإضافة إطار فيديو
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # حفظ العرض التقديمي إلى القرص
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


بدلاً من ذلك، يمكنك إضافة فيديو بتمرير مسار ملفه مباشرة إلى طريقة [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addvideoframe/):
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



## **Create Video Frames with Video from Web Sources**

يدعم Microsoft [PowerPoint 2013 والإصدارات الأحدث](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) مقاطع فيديو YouTube في العروض التقديمية. إذا كان الفيديو الذي تريد استخدامه متاحًا عبر الإنترنت (مثل YouTube)، يمكنك إضافته إلى عرضك التقديمي عبر رابطه الإلكتروني.  

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).  
1. احصل على مرجع الشريحة عبر فهرسها.  
1. أضف كائنًا من النوع [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) ومرّر الرابط إلى الفيديو.  
1. عيّن صورة مصغرة لإطار الفيديو.  
1. احفظ العرض التقديمي.  

يعرض هذا الشيفرة PHP كيفية إضافة فيديو من الويب إلى شريحة في عرض PowerPoint:
```php
  # ينشئ كائن Presentation الذي يمثل ملف عرض تقديمي
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


## **Extract Video from Slides**

إلى جانب إضافة مقاطع فيديو إلى الشرائح، تسمح لك Aspose.Slides باستخراج مقاطع الفيديو المضمَّنة في العروض التقديمية.

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) لتحميل العرض التقديمي الذي يحتوي على الفيديو.  
2. تجول عبر جميع كائنات [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/).  
3. تجول عبر جميع كائنات [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) للعثور على كائن [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).  
4. احفظ الفيديو على القرص.  

يعرض هذا الشيفرة PHP كيفية استخراج الفيديو من شريحة عرض تقديمي:
```php
  # ينشئ كائن Presentation الذي يمثل ملف عرض تقديمي
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


## **FAQ**

**ما هي معلمات تشغيل الفيديو التي يمكن تغييرها لإطار الفيديو؟**

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setplaymode/) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setplayloopmode/). هذه الخيارات متاحة عبر خصائص كائن [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عندما تقوم بتضمين فيديو محلي، تُضمَّن البيانات الثنائية في المستند، وبالتالي يزداد حجم العرض التقديمي بما يتناسب مع حجم الملف. عندما تضيف فيديو عبر الإنترنت، يُضمَّن رابط وصورة مصغرة فقط، لذا يكون الزيادة أصغر.

**هل يمكنني استبدال الفيديو في إطار فيديو موجود دون تغيير موضعه وحجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/setembeddedvideo/) داخل الإطار مع الحفاظ على هندسة الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) لفيديو مضمَّن؟**

نعم. للفيديو المضمَّن نوع [محتوى](https://reference.aspose.com/slides/php-java/aspose.slides/video/getcontenttype/) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه على القرص.