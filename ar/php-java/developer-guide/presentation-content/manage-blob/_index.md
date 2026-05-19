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
description: "إدارة بيانات BLOB في Aspose.Slides لـ PHP عبر Java لتبسيط عمليات ملفات PowerPoint وOpenDocument لتحسين معالجة العروض التقديمية بكفاءة."
---
## **نظرة عامة**

توفر Aspose.Slides معالجة تعتمد على BLOB للبيانات الثنائية الكبيرة في العروض التقديمية للمساعدة في تقليل استهلاك الذاكرة عند التعامل مع الصور الكبيرة والصوت والفيديو وملفات العروض التقديمية.

توضح هذه المقالة كيفية استخدام المعالجة القائمة على BLOB لإضافة وسائط كبيرة إلى عرض تقديمي، وتصدير وسائط كبيرة من عرض تقديمي، وتحميل عروض تقديمية كبيرة بكفاءة أكبر. كما توضح كيف يمكن استخدام الملفات المؤقتة أثناء المعالجة وكيفية تغيير المجلد المستخدم لتخزينها.

{{% alert title="Info" color="info" %}}
لتجاوز بعض القيود عند التعامل مع التدفقات، قد تقوم Aspose.Slides بنسخ محتوى التدفق. تحميل عرض تقديمي كبير عبر تدفقه سيؤدي إلى نسخ محتويات العرض ويجعل التحميل بطيئًا. لذلك، عندما تنوي تحميل عرض تقديمي كبير، نوصيك بشدة باستخدام مسار ملف العرض وليس التدفق.
{{% /alert %}}

## **استخدام BLOB لتقليل استهلاك الذاكرة**

### **إضافة ملف كبير عبر BLOB إلى عرض تقديمي**

[Aspose.Slides](/slides/ar/php-java/) for Java يسمح لك بإضافة ملفات كبيرة (في هذه الحالة، ملف فيديو كبير) عبر عملية تتضمن BLOB لتقليل استهلاك الذاكرة.

هذا المثال بجافا يوضح كيفية إضافة ملف فيديو كبير عبر عملية BLOB إلى عرض تقديمي:

```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # إنشاء عرض تقديمي جديد سيتم إضافة الفيديو إليه
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # دعنا نضيف الفيديو إلى العرض - اخترنا سلوك KeepLocked لأننا
      # ليس لدينا نية للوصول إلى ملف "veryLargeVideo.avi".
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # يحفظ العرض التقديمي. أثناء إنتاج عرض تقديمي كبير، يظل استهلاك الذاكرة
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
Aspose.Slides for PHP via Java يسمح لك بتصدير ملفات كبيرة (في هذه الحالة، ملف صوت أو فيديو) عبر عملية تتضمن BLOB من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج ملف وسائط كبير من عرض تقديمي دون تحميله إلى ذاكرة جهاز الكمبيوتر. عبر تصدير الملف عبر عملية BLOB، يمكنك الحفاظ على استهلاك منخفض للذاكرة.

هذا الكود يوضح العملية الموضحة:

```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # يقفل ملف المصدر ولا يقوم بتحميله إلى الذاكرة
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # إنشاء نسخة من Presentation، قفل ملف "hugePresentationWithAudiosAndVideos.pptx".
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # لنحفظ كل فيديو إلى ملف. لمنع الاستهلاك العالي للذاكرة، نحتاج إلى مخزن سيُستخدم
    # لنقل البيانات من تدفق فيديو العرض إلى تدفق لملف فيديو جديد تم إنشاؤه.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # يتكرر عبر مقاطع الفيديو
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # يفتح تدفق فيديو العرض. يرجى ملاحظة أننا تجنبنا عن قصد الوصول إلى الخصائص
      # مثل video.BinaryData - لأن هذه الخاصية تُعيد مصفوفة بايت تحتوي على الفيديو كاملًا، مما
      # يسبب تحميل البايتات إلى الذاكرة. نستخدم video.GetStream، الذي سيعيد Stream - ولا يتطلب
      # تحميل الفيديو بالكامل إلى الذاكرة.
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
باستخدام الطرق المتوفرة في فئة [ImageCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagecollection/) يمكنك إضافة صورة كبيرة كتيار لتعاملها كـ BLOB.

هذا الكود بـ PHP يوضح كيفية إضافة صورة كبيرة عبر عملية BLOB:

```php
  $pathToLargeImage = "large_image.jpg";
  # ينشئ عرض تقديمي جديد سيتم إضافة الصورة إليه.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # لنضيف الصورة إلى العرض التقديمي - نختار سلوك KeepLocked لأننا
      # ليس لدينا نية للوصول إلى ملف "largeImage.png".
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # يحفظ العرض التقديمي. أثناء إنتاج عرض تقديمي كبير، يظل استهلاك الذاكرة
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

عادةً، لتحميل عرض تقديمي كبير يحتاج الحاسوب إلى كمية كبيرة من الذاكرة المؤقتة. يتم تحميل كل محتوى العرض إلى الذاكرة ويتوقف الملف (الذي تم تحميل العرض منه) عن الاستخدام.

اعتبر عرض PowerPoint كبير (large.pptx) يحتوي على ملف فيديو بحجم 1.5 جيجابايت. الطريقة القياسية لتحميل العرض موصوفة في هذا الكود PHP:

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

من خلال العملية التي تتضمن BLOB، يمكنك تحميل عرض تقديمي كبير مع استخدام قليل من الذاكرة. يصف هذا الكود PHP التنفيذ حيث تُستخدم عملية BLOB لتحميل ملف عرض تقديمي كبير (large.pptx):

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

### **تغيير المجلد للملفات المؤقتة**

عند استخدام عملية BLOB، ينشئ حاسوبك ملفات مؤقتة في المجلد الافتراضي للملفات المؤقتة. إذا أردت حفظ الملفات المؤقتة في مجلد مختلف، يمكنك تغيير إعدادات التخزين باستخدام `setTempFilesRootPath`:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```

{{% alert title="Info" color="info" %}}
عند استخدام `setTempFilesRootPath`، لا تقوم Aspose.Slides بإنشاء مجلد لتخزين الملفات المؤقتة تلقائيًا. عليك إنشاء المجلد يدويًا.
{{% /alert %}}

### **تحرير كائنات العرض لتفريغ الذاكرة**

أثناء معالجة العروض التقديمية الكبيرة، تأكد من التخلص من مثيل [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) بشكل صحيح لإطلاق الذاكرة التي كان يشغلها. استدعِ `dispose()` بعد الانتهاء من استخدام العرض لتحرير الموارد غير المدارة.

```php
$presentation = new Presentation("large.pptx");

# ...معالجة العرض التقديمي...
$presentation->save("large.pdf", SaveFormat::Pdf);

# إخلاء الموارد صراحةً.
$presentation->dispose();
```

## **الأسئلة الشائعة**

**ما هي البيانات في عرض Aspose.Slides التي تُعامل كـ BLOB وتتحكم فيها خيارات BLOB؟**

تُعامل الكائنات الثنائية الكبيرة مثل الصور والصوت والفيديو كـ BLOB. كما أن الملف الكامل للعرض يتضمن معالجة BLOB عند تحميله أو حفظه. تُحكم هذه الكائنات بسياسات BLOB التي تسمح لك بإدارة استهلاك الذاكرة وتحويل البيانات إلى ملفات مؤقتة عند الحاجة.

**أين يمكنني تكوين قواعد معالجة BLOB أثناء تحميل العرض التقديمي؟**

استخدم [LoadOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/) مع [BlobManagementOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/blobmanagementoptions/). هناك يمكنك تعيين الحد الأقصى للذاكرة للـ BLOB، السماح أو منع إنشاء ملفات مؤقتة، اختيار المسار الجذر للملفات المؤقتة، وتحديد سلوك قفل المصدر.

**هل تؤثر إعدادات BLOB على الأداء، وكيف يمكن موازنة السرعة مقابل الذاكرة؟**

نعم. الاحتفاظ بـ BLOB في الذاكرة يعظم السرعة لكنه يزيد استهلاك RAM؛ خفض حد الذاكرة ينقل المزيد من العمل إلى الملفات المؤقتة، مما يقلل الذاكرة على حساب دخول/خروج إضافي للقرص. استخدم طريقة [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/ar/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) لتحقيق التوازن المناسب لحِمل عملك وبيئتك.

**هل تساعد خيارات BLOB عند فتح عروض تقديمية ضخمة للغاية (مثلاً جيجابايت)؟**

نعم. تم تصميم [BlobManagementOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/blobmanagementoptions/) لمثل هذه السيناريوهات: تمكين الملفات المؤقتة واستخدام قفل المصدر يمكن أن يقلل بشكل كبير من ذروّة استهلاك RAM ويستقر المعالجة لعروض ضخمة جدًا.

**هل يمكنني استخدام سياسات BLOB عند التحميل من التدفقات بدلاً من ملفات القرص؟**

نعم. تنطبق القواعد نفسها على التدفقات: يمكن للعرض أن يمتلك ويقفل تدفق الإدخال (اعتمادًا على وضع القفل المختار)، وتُستخدم الملفات المؤقتة عندما يُسمح بها، مما يحافظ على استهلاك ذاكرة متوقع أثناء المعالجة.