---
title: إدارة OLE
type: docs
weight: 40
url: /php-java/manage-ole/
keywords:
- إضافة OLE
- تضمين OLE
- إضافة كائن
- تضمين كائن
- تضمين ملف
- كائن مرتبط
- ربط وتضمين الكائن
- كائن OLE
- PowerPoint 
- عرض تقديمي
- PHP
- Java
- Aspose.Slides for PHP عبر Java
description: إضافة كائنات OLE إلى عروض PowerPoint في PHP
---

{{% alert color="primary" %}} 

OLE  (ربط وتضمين الكائن) هي تقنية من مايكروسوفت تسمح بتضمين البيانات والكائنات التي تم إنشاؤها في تطبيق واحد داخل تطبيق آخر من خلال الربط أو التضمين. 

{{% /alert %}} 

اعتبر مخططًا تم إنشاؤه في MS Excel. يتم وضع المخطط بعد ذلك داخل شريحة PowerPoint. يعتبر ذلك المخطط من نوع OLE. 

- قد يظهر كائن OLE كرمز. في هذه الحالة، عندما تنقر نقرًا مزدوجًا على الرمز، يتم فتح المخطط في تطبيقه المرتبط (Excel)، أو يُطلب منك تحديد تطبيق لفتح أو تعديل الكائن. 
- قد يعرض كائن OLE المحتويات الفعلية—على سبيل المثال، محتويات المخطط. في هذه الحالة، يتم تفعيل المخطط في PowerPoint، ويتم تحميل واجهة المخطط، ويمكنك تعديل بيانات المخطط داخل تطبيق PowerPoint.

[Aspose.Slides for PHP عبر Java](https://products.aspose.com/slides/php-java/) يسمح لك بإدراج كائنات OLE في الشرائح كإطارات كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame)).

## **إضافة إطارات كائن OLE إلى الشرائح**
بافتراض أنك قمت بالفعل بإنشاء مخطط في Microsoft Excel وترغب في تضمين ذلك المخطط في شريحة كإطار كائن OLE باستخدام Aspose.Slides for PHP عبر Java، يمكنك القيام بذلك على النحو التالي:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
1. الحصول على مرجع الشريحة باستخدام فهرسها.
1. فتح ملف Excel الذي يحتوي على كائن المخطط وحفظه في `MemoryStream`.
1. إضافة [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame) إلى الشريحة التي تحتوي على مصفوفة البايتات وغيرها من المعلومات حول كائن OLE.
1. كتابة العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، أضفنا مخططًا من ملف Excel إلى شريحة كإطار كائن OLE باستخدام Aspose.Slides for PHP عبر Java.
**ملاحظة** أن مُنشئ [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IOleEmbeddedDataInfo) يأخذ امتداد كائن قابل للتضمين كمعامل ثانٍ. يتيح هذا الامتداد لـ PowerPoint تفسير نوع الملف بشكل صحيح واختيار التطبيق الصحيح لفتح هذا الكائن OLE.

```php
  # إنشاء مثيل من فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # تحميل ملف Excel إلى دفق
    $fs = new Java("java.io.FileInputStream", "book1.xlsx");
    $Array = new java_class("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $mstream = new Java("java.io.ByteArrayOutputStream");
    $buf = $Array->newInstance($Byte, 4096);
    while (true) {
      $bytesRead = $fs->read($buf, 0, $Array->getLength($buf));
      if ($bytesRead <= 0) {
        break;
      }
      $mstream->write($buf, 0, $bytesRead);
    } 
    $fs->close();
    # إنشاء كائن بيانات للتضمين
    $dataInfo = new OleEmbeddedDataInfo($mstream->toByteArray(), "xlsx");
    $mstream->close();
    # إضافة شكل إطار كائن Ole
    $oleObjectFrame = $sld->getShapes()->addOleObjectFrame(0, 0, $pres->getSlideSize()->getSize()->getWidth(), $pres->getSlideSize()->getSize()->getHeight(), $dataInfo);
    # كتابة ملف PPTX إلى القرص
    $pres->save("OleEmbed_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **الوصول إلى إطارات كائن OLE**
إذا كان هناك كائن OLE مدمج بالفعل في الشريحة، يمكنك العثور على ذلك الكائن أو الوصول إليه بسهولة بهذه الطريقة:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
1. الحصول على مرجع الشريحة باستخدام فهرسها.
1. الوصول إلى شكل إطار كائن OLE.

   في مثالنا، استخدمنا PPTX الذي تم إنشاؤه مسبقًا، والذي يحتوي على شكل واحد فقط في الشريحة الأولى. ثم قمنا *بتحويل* ذلك الكائن إلى [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame). كان هذا هو إطار كائن OLE المطلوب الوصول إليه.
1. بمجرد الوصول إلى إطار كائن OLE، يمكنك إجراء أي عملية عليه.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel مدمج في شريحة)—ثم يتم كتابة بيانات ملفه إلى ملف Excel.

```php
  # تحميل ملف PPTX إلى كائن Presentation
  $pres = new Presentation("AccessingOLEObjectFrame.pptx");
  try {
    # الوصول إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # تحويل الشكل إلى OleObjectFrame
    $oleObjectFrame = $sld->getShapes()->get_Item(0);
    # قراءة كائن OLE وكتابته إلى القرص
    if (!java_is_null($oleObjectFrame)) {
      # الحصول على بيانات الملف المضمن
      $data = $oleObjectFrame->getEmbeddedData()->getEmbeddedFileData();
      # الحصول على امتداد الملف المضمن
      $fileExtention = $oleObjectFrame->getEmbeddedData()->getEmbeddedFileExtension();
      # إنشاء مسار لحفظ الملف المستخرج
      $extractedPath = "excelFromOLE_out" . $fileExtention;
      # حفظ البيانات المستخرجة
      $fstr = new Java("java.io.FileOutputStream", $extractedPath);
      $Array = new java_class("java.lang.reflect.Array");
      try {
        $fstr->write($data, 0, $Array->getLength($data));
      } finally {
        $fstr->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تغيير بيانات كائن OLE**

إذا كان كائن OLE مدمجًا بالفعل في الشريحة، يمكنك الوصول بسهولة إلى ذلك الكائن وتعديل بياناته بهذه الطريقة:

1. فتح العرض التقديمي المطلوب الذي يحتوي على كائن OLE المضمن عن طريق إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. الوصول إلى شكل إطار كائن OLE.

   في مثالنا، استخدمنا PPTX الذي تم إنشاؤه مسبقًا والذي يحتوي على شكل واحد فقط في الشريحة الأولى. قمنا *بتحويل* ذلك الكائن إلى [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame). كان هذا هو إطار كائن OLE المطلوب الوصول إليه.
1. بمجرد الوصول إلى إطار كائن OLE، يمكنك إجراء أي عملية عليه.
1. إنشاء كائن Workbook والوصول إلى بيانات OLE.
1. الوصول إلى ورقة العمل المطلوبة وتعديل البيانات.
1. حفظ Workbook المحدث في التدفقات.
1. تغيير بيانات كائن OLE من بيانات التدفق.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel مدمج في شريحة)—ثم يتم تعديل بيانات ملفه لتغيير بيانات المخطط:

```php
  $pres = new Presentation("ChangeOLEObjectData.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $ole = null;
    # المرور عبر جميع الأشكال لإطار Ole
    foreach($slide->getShapes() as $shape) {
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $ole = $shape;
      }
    }
    if (!java_is_null($ole)) {
      $msln = new ByteArrayInputStream($ole->getEmbeddedData()->getEmbeddedFileData());
      try {
        # قراءة بيانات الكائن في Workbook
        $Wb = new Workbook($msln);
        $msout = new Java("java.io.ByteArrayOutputStream");
        try {
          # تعديل بيانات دفتر العمل
          $Wb->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
          $Wb->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
          $Wb->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
          $Wb->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);
          $so1 = new OoxmlSaveOptions(SaveFormat::XLSX);
          $Wb->save($msout, $so1);
          # تغيير بيانات كائن إطار Ole
          $newData = new OleEmbeddedDataInfo($msout->toByteArray(), $ole->getEmbeddedData()->getEmbeddedFileExtension());
          $ole->setEmbeddedData($newData);
        } finally {
          if (!java_is_null($msout)) {
            $msout->close();
          }
        }
      } finally {
        if (!java_is_null($msln)) {
          $msln->close();
        }
      }
    }
    $pres->save("OleEdit_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## تضمين أنواع ملفات أخرى في الشرائح

بخلاف مخططات Excel، يسمح Aspose.Slides for PHP عبر Java بتضمين أنواع أخرى من الملفات في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML وPDF وZIP ككائنات في شريحة. عند النقر نقرًا مزدوجًا على الكائن المضمن، يتم تشغيل الكائن تلقائيًا في البرنامج المناسب، أو يتلقى المستخدم توجيهًا لاختيار برنامج مناسب لفتح الكائن.

يوضح لك هذا الكود PHP كيفية تضمين HTML وZIP في شريحة:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "embedOle.html"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $htmlBytes = $bytes;

    $dataInfoHtml = new OleEmbeddedDataInfo($htmlBytes, "html");
    $oleFrameHtml = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $dataInfoHtml);
    $oleFrameHtml->setObjectIcon(true);
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "embedOle.zip"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $zipBytes = $bytes;

    $dataInfoZip = new OleEmbeddedDataInfo($zipBytes, "zip");
    $oleFrameZip = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $dataInfoZip);
    $oleFrameZip->setObjectIcon(true);
    $pres->save("embeddedOle.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## إعداد أنواع الملفات لكائنات مضمنة

عند العمل على العروض التقديمية، قد تحتاج إلى استبدال كائنات OLE القديمة بأخرى جديدة. أو قد تحتاج إلى استبدال كائن OLE غير المدعوم بكائن مدعوم. 

يسمح Aspose.Slides for PHP عبر Java لك بتعيين نوع الملف لكائن مضمن. بهذه الطريقة، يمكنك تغيير بيانات إطار OLE أو امتداده.

هذا الكود يوضح لك كيفية تعيين نوع الملف لكائن OLE المضمن:

```php
  $pres = new Presentation("embeddedOle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $oleObjectFrame = $slide->getShapes()->get_Item(0);
    echo("الامتداد الحالي للبيانات المضمنة هو: " . $oleObjectFrame->getEmbeddedData()->getEmbeddedFileExtension());
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "embedOle.zip"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $oleObjectFrame->setEmbeddedData(new OleEmbeddedDataInfo($bytes, "zip"));

    $pres->save("embeddedChanged.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## إعداد صور الرموز والعناوين لكائنات مضمنة

بعد تضمين كائن OLE، تتم إضافة معاينة تتكون من صورة رمز وعنوان تلقائيًا. إن المعاينة هي ما يراه المستخدمون قبل الوصول إلى كائن OLE أو فتحه. 

إذا كنت تريد استخدام صورة ونص محددين كعناصر في المعاينة، يمكنك تعيين صورة الرمز والعنوان باستخدام Aspose.Slides for PHP عبر Java.

يوضح لك هذا الكود PHP كيفية تعيين صورة الرمز والعنوان لكائن مضمن:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $oleObjectFrame = $slide->getShapes()->get_Item(0);
    $oleImage;
    $image = Images->fromFile("image.png");
    try {
      $oleImage = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $oleObjectFrame->setSubstitutePictureTitle("عنواني");
    $oleObjectFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
    $oleObjectFrame->setObjectIcon(false);
    $pres->save("embeddedOle-newImage.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **منع إطار كائن OLE من تغيير الحجم وإعادة وضعه**

بعد إضافة كائن OLE مرتبط إلى شريحة عرض تقديمي، عند فتح العرض التقديمي في PowerPoint، قد ترى رسالة تطلب منك تحديث الروابط. قد يؤدي النقر على زر "تحديث الروابط" إلى تغيير حجم وإعادة وضع إطار كائن OLE لأن PowerPoint يقوم بتحديث البيانات من كائن OLE المرتبط ويقوم بتحديث معاينة الكائن. لمنع PowerPoint من المطالبة بتحديث بيانات الكائن، قم بتعيين طريقة `setUpdateAutomatic` من فئة [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) إلى `false`:

```php
$oleObjectFrame->setUpdateAutomatic(false);
```

## استخراج الملفات المضمنة

يسمح Aspose.Slides for PHP عبر Java باستخراج الملفات المضمنة في الشرائح ككائنات OLE بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) التي تحتوي على كائن OLE الذي تنوي استخراجه.
2. المرور عبر جميع الأشكال في العرض التقديمي والوصول إلى شكل [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe).
3. الوصول إلى بيانات الملف المضمن من إطار كائن OLE وكتابتها إلى القرص. 

يوضح لك هذا الكود PHP كيفية استخراج ملف مضمن في شريحة ككائن OLE:

```php
  $pres = new Presentation("embeddedOle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    for($index = 0; $index < java_values($slide->getShapes()->size()) ; $index++) {
      $shape = $slide->getShapes()->get_Item($index);
      $oleFrame = $shape;
      if (!java_is_null($oleFrame)) {
        $data = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $extension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
        # حفظ البيانات المستخرجة
        $fstr = new Java("java.io.FileOutputStream", "oleFrame" . $index . $extension);
        $Array = new java_class("java.lang.reflect.Array");
        try {
          $fstr->write($data, 0, $Array->getLength($data));
        } finally {
          $fstr->close();
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