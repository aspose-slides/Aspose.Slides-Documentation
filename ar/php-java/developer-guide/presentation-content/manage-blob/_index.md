---
title: إدارة Blob
type: docs
weight: 10
url: /php-java/manage-blob/
description: إدارة Blob في عرض PowerPoint باستخدام PHP. استخدم Blob لتقليل استهلاك الذاكرة في عرض PowerPoint باستخدام PHP. أضف ملفًا كبيرًا عبر Blob إلى عرض PowerPoint باستخدام PHP. قم بتصدير ملف كبير عبر Blob من عرض PowerPoint باستخدام PHP. قم بتحميل عرض PowerPoint كبير كـ Blob باستخدام PHP.
---

## **حول BLOB**

**BLOB** (**عناصر ثنائية كبيرة**) هو عادةً عنصر كبير (صورة، عرض، وثيقة، أو وسائط) محفوظ بتنسيقات ثنائية.

تتيح لك Aspose.Slides لـ PHP عبر Java استخدام BLOBs للأشياء بطريقة تقلل من استهلاك الذاكرة عند التعامل مع ملفات كبيرة.

{{% alert title="معلومات" color="info" %}}

لتجاوز بعض القيود عند التفاعل مع تدفقات البيانات، قد تقوم Aspose.Slides بنسخ محتوى التدفق. سيسفر تحميل عرض كبير من خلال تدفقه عن نسخ محتوى العرض ويتسبب في بطء التحميل. لذلك، عندما تنوي تحميل عرض كبير، نوصي بشدة باستخدام مسار ملف العرض وليس تدفقه.

{{% /alert %}}

## **استخدام BLOB لتقليل استهلاك الذاكرة**

### **إضافة ملف كبير عبر BLOB إلى عرض**

تتيح لك [Aspose.Slides](/slides/php-java/) لـ Java إضافة ملفات كبيرة (في هذه الحالة، ملف فيديو كبير) من خلال عملية تتضمن BLOBs لتقليل استهلاك الذاكرة.

يوضح لك هذا المثال كيفية إضافة ملف فيديو كبير من خلال عملية BLOB إلى عرض:

```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # ينشئ عرض تقديمي جديد سيتم إضافة الفيديو إليه
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # دعنا نضيف الفيديو إلى العرض - اخترنا سلوك KeepLocked لأنه لا نعتزم الوصول إلى
      # ملف "veryLargeVideo.avi".
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # يحفظ العرض. بينما يتم إخراج عرض كبير، يبقى استهلاك الذاكرة منخفضًا من خلال دورة حياة كائن pres
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


### **تصدير ملف كبير عبر BLOB من العرض**
تتيح لك Aspose.Slides لـ PHP عبر Java تصدير ملفات كبيرة (في هذه الحالة، ملف صوتي أو فيديو) من خلال عملية تتضمن BLOBs من العروض. على سبيل المثال، قد تحتاج إلى استخراج ملف وسائط كبير من عرض ولكن لا ترغب في تحميل الملف في ذاكرة جهاز الكمبيوتر الخاص بك. من خلال تصدير الملف عبر عملية BLOB، يمكنك الحفاظ على استهلاك الذاكرة منخفضًا.

يوضح هذا الكود العملية الموصوفة:

```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # يغلق الملف المصدر ولا يقوم بتحميله في الذاكرة
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # ينشئ مثيل العرض، ويقفل ملف "hugePresentationWithAudiosAndVideos.pptx".
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # دعنا نحفظ كل فيديو في ملف. لمنع استهلاك ذاكرة عالية، نحتاج إلى مخزن مؤقت سيتم استخدامه
    # لنقل البيانات من تدفق فيديو العرض إلى تدفق لملف فيديو جديد تم إنشاؤه.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # يتكرر عبر مقاطع الفيديو
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # يفتح تدفق فيديو العرض. يرجى ملاحظة أننا تجنبنا عمدًا الوصول إلى الخصائص
      # مثل video.BinaryData - لأن هذه الخاصية تعيد مصفوفة بايت تحتوي على فيديو كامل، مما يؤدي بعد ذلك
      # إلى تحميل بايت إلى الذاكرة. نحن نستخدم video.GetStream، الذي سيعيد Stream - ولا يتطلب منا
      # تحميل الفيديو بالكامل في الذاكرة.
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
      # سيبقى استهلاك الذاكرة منخفضًا بغض النظر عن حجم الفيديو أو العرض.
    }
    # إذا لزم الأمر، يمكنك تطبيق نفس الخطوات على ملفات الصوت.
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

### **إضافة صورة كـ BLOB في العرض**
باستخدام الطرق من واجهة [**IImageCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) والفئة [**ImageCollection** ](https://reference.aspose.com/slides/php-java/aspose.slides/ImageCollection)، يمكنك إضافة صورة كبيرة كتيار لتتم معالجتها كـ BLOB.

يوضح هذا الكود PHP كيفية إضافة صورة كبيرة عبر عملية BLOB:

```php
  $pathToLargeImage = "large_image.jpg";
  # ينشئ عرض تقديمي جديد سيتم إضافة الصورة إليه.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # دعنا نضيف الصورة إلى العرض - اخترنا سلوك KeepLocked لأنه لا نعتزم الوصول إلى
      # ملف "largeImage.png".
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # يحفظ العرض. بينما يتم إخراج عرض كبير، يبقى استهلاك الذاكرة منخفضًا من خلال دورة حياة كائن pres
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

## **الذاكرة والعروض الكبيرة**

عادةً ما تتطلب تحميل عرض تقديمي كبير، أجهزة الكمبيوتر الكثير من الذاكرة المؤقتة. يتم تحميل محتوى العرض بالكامل في الذاكرة ويتوقف استخدام الملف (الذي تم تحميل العرض منه).

اعتبر عرض PowerPoint كبير (large.pptx) يحتوي على ملف فيديو سعة 1.5 جيجابايت. يتم وصف الطريقة القياسية لتحميل العرض في هذا الكود PHP:

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

### **تحميل عرض كبير كـ BLOB**

من خلال العملية التي تنطوي على BLOB، يمكنك تحميل عرض تقديمي كبير مع استخدام ذاكرة قليلة. يصف هذا الكود PHP التنفيذ حيث يتم استخدام عملية BLOB لتحميل ملف عرض كبير (large.pptx):

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

عند استخدام عملية BLOB، يقوم الكمبيوتر الخاص بك بإنشاء ملفات مؤقتة في مجلد الملفات المؤقتة الافتراضي. إذا كنت ترغب في الاحتفاظ بالملفات المؤقتة في مجلد مختلف، يمكنك تغيير إعدادات التخزين باستخدام `TempFilesRootPath`:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```

{{% alert title="معلومات" color="info" %}}

عند استخدام `TempFilesRootPath`، لا تقوم Aspose.Slides بإنشاء مجلد تلقائيًا لتخزين الملفات المؤقتة. يتعين عليك إنشاء المجلد يدويًا.

{{% /alert %}}