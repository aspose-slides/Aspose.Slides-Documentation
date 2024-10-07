---
title: فتح العرض التقديمي
linktitle: فتح العرض التقديمي
type: docs
weight: 20
url: /php-java/open-presentation/
keywords: "فتح PowerPoint، PPTX، PPT، فتح العرض التقديمي، تحميل العرض التقديمي، Java"
description: "فتح أو تحميل عرض تقديمي PPT، PPTX، ODP"
---

بالإضافة إلى إنشاء عروض PowerPoint من الصفر، تتيح لك Aspose.Slides فتح العروض التقديمية الموجودة. بعد تحميل عرض تقديمي، يمكنك الحصول على معلومات حول العرض التقديمي، وتعديل العرض التقديمي (المحتوى في الشرائح)، وإضافة شرائح جديدة أو إزالة الشرائح الموجودة، إلخ.

## فتح العرض التقديمي

لفتح عرض تقديمي موجود، تحتاج ببساطة إلى تهيئة فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) وتمرير مسار الملف (للعرض التقديمي الذي تريد فتحه) إلى المُنشئ الخاص بها.

يوضح لك هذا الرمز PHP كيفية فتح عرض تقديمي وأيضًا معرفة عدد الشرائح التي يحتوي عليها:

```php
  # تهيئة فئة Presentation وتمرير مسار الملف إلى مُنشئها
  $pres = new Presentation("Presentation.pptx");
  try {
    # طباعة العدد الإجمالي للشرائح الموجودة في العرض التقديمي
    echo($pres->getSlides()->size());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **فتح عرض تقديمي محمي بكلمة مرور**

عندما تحتاج إلى فتح عرض تقديمي محمي بكلمة مرور، يمكنك تمرير كلمة المرور عبر خاصية [Password](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#getPassword--) (من فئة [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/)) لفك تشفير العرض التقديمي وتحميل العرض التقديمي. يوضح هذا الرمز PHP العملية:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("YOUR_PASSWORD");
  $pres = new Presentation("pres.pptx", $loadOptions);
  try {
    # القيام ببعض الأعمال مع العرض التقديمي المفكوك التشفير
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## فتح عرض تقديمي كبير

تقدم Aspose.Slides خيارات (خاصية [BlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setBlobManagementOptions-com.aspose.slides.IBlobManagementOptions-) على وجه الخصوص) تحت فئة [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions) للسماح لك بتحميل عروض تقديمية كبيرة.

يوضح هذا المثال Java عملية يتم فيها تحميل عرض تقديمي كبير (say 2GB in size):

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(0);
  $pres = new Presentation("veryLargePresentation.pptx", $loadOptions);
  try {
    # تم تحميل العرض التقديمي الكبير ويمكن استخدامه، ولكن استهلاك الذاكرة لا يزال منخفضًا.
    # إجراء تغييرات على العرض التقديمي.
    $pres->getSlides()->get_Item(0)->setName("عرض تقديمي كبير جداً");
    # سيتم حفظ العرض التقديمي في ملف آخر. يبقى استهلاك الذاكرة منخفضًا أثناء العملية
    $pres->save("veryLargePresentation-copy.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="info" title="معلومات" %}}

لتجاوز بعض القيود عند التفاعل مع دفق، قد تقوم Aspose.Slides بنسخ محتوى الدفق. سيؤدي تحميل عرض تقديمي كبير من خلال دفقه إلى نسخ محتويات العرض التقديمي والتسبب في بطء التحميل. لذلك، عندما تنوي تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض التقديمي وليس دفقه.

عندما تريد إنشاء عرض تقديمي يحتوي على كائنات كبيرة (فيديو، صوت، صور كبيرة، إلخ)، يمكنك استخدام [تسهيلات Blob](https://docs.aspose.com/slides/php-java/manage-blob/) لتقليل استهلاك الذاكرة.

{{%/alert %}} 

## تحميل العرض التقديمي

تقدم Aspose.Slides [IResourceLoadingCallback](https://reference.aspose.com/slides/php-java/aspose.slides/iresourceloadingcallback/) مع طريقة واحدة للسماح لك بإدارة الموارد الخارجية. يوضح لك هذا الرمز PHP كيفية استخدام واجهة `IResourceLoadingCallback`:

```php

class ImageLoadingHandler {
    function resourceLoading($args) {
      if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
        # يحمل صورة بديلة
        $file = new Java("java.io.File", "aspose-logo.jpg");
        $Array = new JavaClass("java.lang.reflect.Array");
        $Byte = new JavaClass("java.lang.Byte");
        $imageBytes = $Array->newInstance($Byte, $Array->getLength($file));
        try {
            $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $file));
            $dis->readFully($imageBytes);
        } finally {
            if (!java_is_null($dis)) $dis->close();
        }
          $args->setData($imageBytes);
          return ResourceLoadingAction::UserProvided;
      } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
        # تعيين عنوان URL البديل
        $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
        return ResourceLoadingAction::Default;
      }
      # يتخطى جميع الصور الأخرى
      return ResourceLoadingAction::Skip;
    }
  }

  $opts = new LoadOptions();
  $loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));
  $opts->setResourceLoadingCallback($loadingHandler);
  $pres = new Presentation("presentation.pptx", $opts);
```

## تحميل العرض التقديمي بدون كائنات ثنائية مدمجة

يمكن أن يحتوي العرض التقديمي PowerPoint على الأنواع التالية من الكائنات الثنائية المدمجة:

- مشروع VBA ([IPresentation.VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/));
- بيانات كائن OLE المدمجة ([IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- بيانات كائن ActiveX الثنائية ([IControl.ActiveXControlBinary](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getActiveXControlBinary--));

باستخدام خاصية [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-)، يمكنك تحميل العرض التقديمي بدون أي كائنات ثنائية مدمجة.

يمكن أن تكون هذه الخاصية مفيدة لإزالة المحتوى الثنائي الضار المحتمل.

يوضح الكود كيفية تحميل وحفظ عرض تقديمي بدون أي محتوى ضار:

```java
  $loadOptions = new LoadOptions();
  $loadOptions->setDeleteEmbeddedBinaryObjects(true);

  $pres = new Presentation("malware.ppt", $loadOptions);
  try {
    $pres->save("clean.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null(pres)) { 
      $pres->dispose();
    }
  }
```

## فتح وحفظ العرض التقديمي

خطوات فتح وحفظ العرض التقديمي:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) وتمرير الملف الذي تريد فتحه.
2. حفظ العرض التقديمي.  

```php
  # تهيئة كائن Presentation يمثل ملف PPT
  $pres = new Presentation();
  try {
    # ...قيام ببعض الأعمال هنا...
    # حفظ العرض التقديمي الخاص بك في ملف
    $pres->save("demoPass.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```