---
title: إدارة BLOB للعرض التقديمي في PHP لاستخدام الذاكرة بكفاءة
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
description: "إدارة بيانات BLOB في Aspose.Slides لـ PHP عبر Java لتسهيل عمليات ملفات PowerPoint و OpenDocument لضمان معالجة عرض تقديمي فعّالة."
---

## **حول BLOB**

**BLOB** (**Binary Large Object**) عادةً ما يكون عنصرًا كبيرًا (صورة، عرض تقديمي، مستند، أو وسائط) يُحفظ بتنسيقات ثنائية.

Aspose.Slides for PHP via Java يتيح لك استخدام BLOB للكائنات بطريقة تقلل من استهلاك الذاكرة عند التعامل مع ملفات كبيرة.

{{% alert title="Info" color="info" %}}

لتجاوز بعض القيود عند التفاعل مع التدفقات، قد تقوم Aspose.Slides بنسخ محتوى التدفق. تحميل عرض تقديمي كبير عبر تدفقه سيتسبب في نسخ محتويات العرض التقديمي ويؤدي إلى بطء التحميل. لذا، عندما تنوي تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض التقديمي وليس تدفقه.

{{% /alert %}}

## **استخدام BLOB لتقليل استهلاك الذاكرة**

### **إضافة ملف كبير عبر BLOB إلى عرض تقديمي**

[Aspose.Slides](/slides/ar/php-java/) for Java يتيح لك إضافة ملفات كبيرة (في هذه الحالة، ملف فيديو كبير) عبر عملية تشمل BLOB لتقليل استهلاك الذاكرة.

هذا المثال Java يوضح كيفية إضافة ملف فيديو كبير عبر عملية BLOB إلى عرض تقديمي:
```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # ينشئ عرض تقديمي جديد سيتم إضافة الفيديو إليه
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # لنضيف الفيديو إلى العرض التقديمي - اخترنا سلوك KeepLocked لأننا
      # لا ننوي الوصول إلى ملف "veryLargeVideo.avi" .
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

Aspose.Slides for PHP via Java يتيح لك تصدير ملفات كبيرة (مثل ملف صوت أو فيديو) عبر عملية تشمل BLOB من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج ملف وسائط كبير من عرض تقديمي دون تحميله إلى ذاكرة جهازك. عبر تصدير الملف عبر عملية BLOB، تحافظ على استهلاك الذاكرة منخفضًا.

هذا الكود يوضح العملية الم описана:
```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # يقفل ملف المصدر ولا يقوم بتحميله في الذاكرة
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # إنشاء كائن العرض التقديمي، قفل ملف "hugePresentationWithAudiosAndVideos.pptx".
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # لنحفظ كل فيديو في ملف. لمنع استهلاك عالي للذاكرة، نحتاج إلى مخزن وسيُستخدم
    # لنقل البيانات من تدفق فيديو العرض التقديمي إلى تدفق لملف فيديو تم إنشاؤه حديثًا.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # يتنقل عبر مقاطع الفيديو
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # يفتح تدفق فيديو العرض التقديمي. يرجى الملاحظة أننا تجنبنا عمدًا الوصول إلى الخصائص
      # مثل video.BinaryData - لأن هذه الخاصية تُرجع مصفوفة بايت تحتوي على الفيديو بالكامل، مما يؤدي إلى
      # تحميل البايتات في الذاكرة. نستخدم video.GetStream التي تُرجع تدفقًا - ولا تقوم
      # بمتطلب تحميل الفيديو كاملًا في الذاكرة.
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
      # سيظل استهلاك الذاكرة منخفضًا بغض النظر عن حجم الفيديو أو العرض التقديمي.
    }
    # إذا لزم الأمر، يمكنك تطبيق نفس الخطوات على ملفات الصوت.
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```



### **إضافة صورة كـ BLOB إلى عرض تقديمي**

باستخدام أساليب من الواجهة [**IImageCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) والفئة [**ImageCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/ImageCollection)، يمكنك إضافة صورة كبيرة كـ stream لتعاملها كـ BLOB.

هذا الكود PHP يوضح كيفية إضافة صورة كبيرة عبر عملية BLOB:
```php
  $pathToLargeImage = "large_image.jpg";
  # ينشئ عرض تقديمي جديد سيتم إضافة الصورة إليه.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # لنضيف الصورة إلى العرض التقديمي - نختار سلوك KeepLocked لأننا
      # لا نعتزم الوصول إلى ملف "largeImage.png" .
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # يحفظ العرض التقديمي. أثناء إخراج عرض تقديمي كبير، يظل استهلاك الذاكرة
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

عادةً، لتحميل عرض تقديمي كبير، تحتاج الحواسيب إلى الكثير من الذاكرة المؤقتة. يتم تحميل جميع محتويات العرض التقديمي إلى الذاكرة ويتوقف استخدام الملف (الذي تم تحميل العرض التقديمي منه).

اعتبر عرض تقديمي PowerPoint كبير (large.pptx) يحتوي على ملف فيديو بحجم 1.5 جيجابايت. الطريقة القياسية لتحميل العرض التقديمي موصوفة في هذا الكود PHP:
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


لكن هذه الطريقة تستهلك نحو 1.6 جيجابايت من الذاكرة المؤقتة.

### **تحميل عرض تقديمي كبير كـ BLOB**

من خلال العملية التي تشمل BLOB، يمكنك تحميل عرض تقديمي كبير مع استخدام ذاكرة قليلة. يصف هذا الكود PHP التنفيذ حيث تُستخدم عملية BLOB لتحميل ملف عرض تقديمي كبير (large.pptx):
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

عند استخدام عملية BLOB، ينشئ جهازك ملفات مؤقتة في المجلد الافتراضي للملفات المؤقتة. إذا رغبت في حفظ الملفات المؤقتة في مجلد مختلف، يمكنك تعديل إعدادات التخزين باستخدام `TempFilesRootPath`:
```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```


{{% alert title="Info" color="info" %}}

عند استخدام `TempFilesRootPath`، لا تقوم Aspose.Slides بإنشاء مجلد تلقائيًا لتخزين الملفات المؤقتة. عليك إنشاء المجلد يدويًا.

{{% /alert %}}

## **الأسئلة الشائعة**

**ما البيانات في عرض Aspose.Slides التي تُعامل كـ BLOB وتُتحكم بها خيارات BLOB؟**

الكائنات الثنائية الكبيرة مثل الصور، الصوت، والفيديو تُعامل كـ BLOB. كما يشارك ملف العرض التقديمي بالكامل في معالجة BLOB عند تحميله أو حفظه. تُحكم هذه الكائنات بسياسات BLOB التي تتيح لك إدارة استهلاك الذاكرة وتحويل البيانات إلى ملفات مؤقتة عند الحاجة.

**أين يمكنني تكوين قواعد معالجة BLOB أثناء تحميل العرض التقديمي؟**

استخدم [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) مع [BlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/blobmanagementoptions/). هناك تحدد حد الذاكرة داخلية لـ BLOB، وتسمح أو تمنع الملفات المؤقتة، وتختار المسار الجذري للملفات المؤقتة، وتحدد سلوك قفل المصدر.

**هل تؤثر إعدادات BLOB على الأداء، وكيف يمكن موازنة السرعة مقابل الذاكرة؟**

نعم. إبقاء BLOB في الذاكرة يعزز السرعة لكنه يزيد استهلاك RAM؛ خفض حد الذاكرة يوجه المزيد من العمل إلى الملفات المؤقتة، مما يقلل RAM لكنه يزيد عمليات I/O. استخدم طريقة [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) لتحقيق التوازن المناسب لحالتك وبيئتك.

**هل تساعد خيارات BLOB عند فتح عروض تقديمية ضخمة جدًا (مثلاً عدة جيجابايت)؟**

نعم. تم تصميم [BlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/blobmanagementoptions/) لهذا النوع من السيناريوهات: تفعيل الملفات المؤقتة واستخدام قفل المصدر يمكن أن يقللا بشكل كبير من أقصى استهلاك للذاكرة ويستقران عملية المعالجة للعرض الضخم.

**هل يمكنني استخدام سياسات BLOB عند التحميل من تدفقات بدلاً من ملفات القرص؟**

نعم. تُطبق نفس القواعد على التدفقات: يمكن للكائن العرض التقديمي امتلاك قفل للتدفق المدخل (حسب وضع القفل المختار)، وتُستخدم الملفات المؤقتة عندما يُسمح بذلك، مما يحافظ على استهلاك الذاكرة متوقعًا أثناء المعالجة.