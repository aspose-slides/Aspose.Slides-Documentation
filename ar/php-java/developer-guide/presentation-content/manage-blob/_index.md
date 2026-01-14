---
title: إدارة كائنات BLOB في العروض التقديمية باستخدام PHP لاستخدام فعال للذاكرة
linktitle: إدارة BLOB
type: docs
weight: 10
url: /ar/php-java/manage-blob/
keywords:
- كائن كبير
- عنصر كبير
- ملف كبير
- إضافة BLOB
- تصدير BLOB
- إضافة صورة كـ BLOB
- تقليل الذاكرة
- استهلاك الذاكرة
- عرض تقديمي كبير
- ملف مؤقت
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إدارة بيانات BLOB في Aspose.Slides لـ PHP عبر Java لتبسيط عمليات ملفات PowerPoint و OpenDocument لتحسين معالجة العروض التقديمية بفعالية."
---

## **حول BLOB**

**BLOB** (**Binary Large Object**) عادةً ما يكون عنصرًا كبيرًا (صورة، عرض تقديمي، مستند أو وسائط) يتم حفظه بصيغة ثنائية.

Aspose.Slides for PHP via Java يتيح لك استخدام BLOBs للكائنات بطريقة تقلل من استهلاك الذاكرة عند التعامل مع ملفات كبيرة.

{{% alert title="Info" color="info" %}}
لتجاوز بعض القيود عند التفاعل مع الدفقات، قد تقوم Aspose.Slides بنسخ محتوى الدفق. تحميل عرض تقديمي كبير عبر الدفق سيؤدي إلى نسخ محتويات العرض وتسبب بطء التحميل. لذلك، عند نيتك تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض وليس الدفق الخاص به.
{{% /alert %}}

## **استخدام BLOB لتقليل استهلاك الذاكرة**

### **إضافة ملف كبير عبر BLOB إلى عرض تقديمي**

[Aspose.Slides](/slides/ar/php-java/) for Java يتيح لك إضافة ملفات كبيرة (في هذه الحالة، ملف فيديو كبير) عبر عملية تشمل BLOBs لتقليل استهلاك الذاكرة.

هذا المثال في Java يوضح كيفية إضافة ملف فيديو كبير عبر عملية BLOB إلى عرض تقديمي:
```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # إنشاء عرض تقديمي جديد سيتم إضافة الفيديو إليه
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # لنضيف الفيديو إلى العرض التقديمي - اخترنا سلوك KeepLocked لأننا
      # ليس لدينا نية للوصول إلى ملف "veryLargeVideo.avi".
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # يحفظ العرض التقديمي. أثناء إخراج عرض تقديمي كبير، يظل استهلاك الذاكرة
      # منخفضًا طوال دورة حياة كائن pres
      $pres->save("presentationWithLargeVideo.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **تصدير ملف كبير عبر BLOB من عرض تقديمي**
Aspose.Slides for PHP via Java يتيح لك تصدير ملفات كبيرة (في هذه الحالة، ملف صوت أو فيديو) عبر عملية تشمل BLOBs من العروض. على سبيل المثال، قد تحتاج إلى استخراج ملف وسائط كبير من عرض تقديمي دون تحميله إلى ذاكرة جهازك. عبر تصدير الملف عبر عملية BLOB، تحافظ على استهلاك الذاكرة منخفضًا.

هذا الكود يوضح العملية الموصوفة:
```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # يقفل ملف المصدر ولا يقوم بتحميله إلى الذاكرة
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # إنشاء كائن Presentation، وقفل ملف "hugePresentationWithAudiosAndVideos.pptx".
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # لنقوم بحفظ كل فيديو في ملف. لتجنب استهلاك عالي للذاكرة، نحتاج إلى مخزن وسيتم استخدامه
    # لنقل البيانات من تيار فيديو العرض إلى تيار لملف فيديو جديد تم إنشاؤه.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # يتكرر عبر جميع الفيديوهات
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # يفتح تيار فيديو العرض. يرجى الملاحظة أننا تجنبنا عمدًا الوصول إلى الخصائص
      # مثل video.BinaryData - لأن هذه الخاصية تُعيد مصفوفة بايت تحتوي على الفيديو بالكامل، مما
      # يسبب تحميل البايتات إلى الذاكرة. نستخدم video.GetStream، التي تُعيد Stream - ولا
      # تتطلب منا تحميل الفيديو بالكامل إلى الذاكرة.
      $presVideoStream = $video->getStream();
      try {
        $outputFileStream = new Java("java.io.FileOutputStream", "video" . $index . ".avi");
        try {
          $bytesRead;
          while ($bytesRead = $presVideoStream->read($buffer, 0, java_values($Array->getLength($buffer))) > 0) {
            $outputFileStream->write($buffer, 0, $bytesRead);
          } 
        } finally {
          $outputFileStream->close();
        }
      } finally {
        $presVideoStream->close();
      }
      # سيظل استهلاك الذاكرة منخفضًا بغض النظر عن حجم الفيديو أو العرض.
    }
    # إذا لزم الأمر، يمكنك تطبيق نفس الخطوات على ملفات الصوت.
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```


### **إضافة صورة كـ BLOB إلى عرض تقديمي**
باستخدام الأساليب من فئة [ImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) يمكنك إضافة صورة كبيرة كدفق لجعلها تُعامل كـ BLOB.

هذا الكود في PHP يوضح كيفية إضافة صورة كبيرة عبر عملية BLOB:
```php
  $pathToLargeImage = "large_image.jpg";
  # ينشئ عرضًا تقديميًا جديدًا ستتم إضافة الصورة إليه.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # لنضيف الصورة إلى العرض التقديمي - نختار سلوك KeepLocked لأننا
      # لا نهدف إلى الوصول إلى ملف "largeImage.png".
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # يحفظ العرض التقديمي. أثناء إخراج عرض تقديمي كبير، يكون استهلاك الذاكرة
      # منخفضًا طوال دورة حياة كائن pres.
      $pres->save("presentationWithLargeImage.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الذاكرة والعروض التقديمية الكبيرة**

عادةً، لتحميل عرض تقديمي كبير، تحتاج الأجهزة إلى الكثير من الذاكرة المؤقتة. يتم تحميل كل محتوى العرض إلى الذاكرة ويتوقف استخدام الملف (الذي تم تحميل العرض منه).

اعتبر عرض تقديمي PowerPoint كبير (large.pptx) يحتوي على ملف فيديو بحجم 1.5 جيجابايت. الطريقة القياسية لتحميل العرض موضحة في هذا الكود PHP:
```php
  $pres = new Presentation("large.pptx");
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


لكن هذه الطريقة تستهلك حوالي 1.6 جيجابايت من الذاكرة المؤقتة.

### **تحميل عرض تقديمي كبير كـ BLOB**
من خلال العملية التي تشمل BLOB، يمكنك تحميل عرض تقديمي كبير مع استخدام قليل من الذاكرة. يصف هذا الكود PHP التنفيذ حيث تُستخدم عملية BLOB لتحميل ملف عرض تقديمي كبير (large.pptx):
```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $pres = new Presentation("large.pptx", $loadOptions);
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **تغيير مجلد الملفات المؤقتة**
عند استخدام عملية BLOB، يُنشئ جهازك ملفات مؤقتة في المجلد الافتراضي للملفات المؤقتة. إذا رغبت في حفظ الملفات المؤقتة في مجلد مختلف، يمكنك تغيير إعدادات التخزين باستخدام `setTempFilesRootPath`:
```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```


{{% alert title="Info" color="info" %}}
عند استخدام `setTempFilesRootPath`، لا ينشئ Aspose.Slides مجلدًا تلقائيًا لتخزين الملفات المؤقتة. عليك إنشاء المجلد يدويًا.
{{% /alert %}}

## **الأسئلة الشائعة**

**ما البيانات في عرض Aspose.Slides التي تُعامل كـ BLOB وتتحكم فيها خيارات BLOB؟**
الكائنات الثنائية الكبيرة مثل الصور، الصوت والفيديو تُعامل كـ BLOB. ملف العرض الكامل أيضًا يتضمن معالجة BLOB عند تحميله أو حفظه. تُدار هذه الكائنات بواسطة سياسات BLOB التي تتيح لك إدارة استهلاك الذاكرة وتفريغها إلى ملفات مؤقتة عند الحاجة.

**أين يمكنني تكوين قواعد معالجة BLOB أثناء تحميل العرض؟**
استخدم [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) مع [BlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/blobmanagementoptions/). هناك يمكنك ضبط حد الذاكرة للـ BLOB، السماح أو عدم السماح بالملفات المؤقتة، اختيار مسار الجذر للملفات المؤقتة، وتحديد سلوك قفل المصدر.

**هل تؤثر إعدادات BLOB على الأداء، وكيف أوازن بين السرعة والذاكرة؟**
نعم. الاحتفاظ بالـ BLOB في الذاكرة ي maximizes السرعة لكنه يزيد استهلاك RAM؛ تقليل حد الذاكرة ينقل المزيد من العمل إلى الملفات المؤقتة، مما يُقلل RAM على حساب مزيد من I/O. استخدم طريقة [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) لتحقيق التوازن المناسب لحجم عملك والبيئة.

**هل تساعد خيارات BLOB عند فتح عروض تقديمية ضخمة جدًا (مثلاً جيجابايتات)؟**
نعم. تم تصميم [BlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/blobmanagementoptions/) لهذه السيناريوهات: تمكين الملفات المؤقتة واستخدام قفل المصدر يمكن أن يقلل بشكل كبير من استهلاك RAM القمة ويستقر معالجة العروض الضخمة.

**هل يمكنني استخدام سياسات BLOB عند التحميل من الدفقات بدلاً من ملفات القرص؟**
نعم. تُطبق نفس القواعد على الدفقات: يمكن لكائن العرض امتلاك وقفل الدفق الإدخالي (حسب وضع القفل المختار)، وتُستخدم الملفات المؤقتة عندما يُسمح بذلك، مما يحافظ على استهلاك الذاكرة بشكل متوقع أثناء المعالجة.