---
title: "إدارة إطارات الصور في العروض التقديمية باستخدام PHP"
linktitle: "إطار الصورة"
type: docs
weight: 10
url: /ar/php-java/picture-frame/
keywords:
- "إطار صورة"
- "إضافة إطار صورة"
- "إنشاء إطار صورة"
- "إضافة صورة"
- "إنشاء صورة"
- "استخراج صورة"
- "صورة نقطية"
- "صورة متجهة"
- "اقتصاص صورة"
- "منطقة مقصوصة"
- "خاصية StretchOff"
- "تنسيق إطار الصورة"
- "خصائص إطار الصورة"
- "مقياس نسبي"
- "تأثير الصورة"
- "نسبة الأبعاد"
- "شفافية الصورة"
- "PowerPoint"
- "OpenDocument"
- "عرض تقديمي"
- "PHP"
- "Aspose.Slides"
description: "أضف إطارات صور إلى عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للـ PHP عبر Java. سهل سير العمل الخاص بك وعزز تصاميم الشرائح."
---
## **المقدمة**

إطار الصورة هو شكل يحتوي على صورة—إنه مثل صورة داخل إطار.

يمكنك إضافة صورة إلى شريحة عبر إطار صورة. بهذه الطريقة، يمكنك تنسيق الصورة من خلال تنسيق إطار الصورة.

{{% alert  title="Tip" color="primary" %}} 

توفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/ar/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/ar/import/png-to-ppt)—تتيح للناس إنشاء عروض تقديمية بسرعة من الصور. 

{{% /alert %}} 

## **إنشاء إطار صورة**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة من خلال فهرستها. 
3. إنشاء كائن [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) عبر إضافة صورة إلى [ImageCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagecollection/) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل.
4. تحديد عرض وارتفاع الصورة.
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/) بناءً على عرض وارتفاع الصورة عبر طريقة `addPictureFrame` المتوفرة في كائن الشكل المرتبط بالشريحة المرجعية.
6. إضافة إطار صورة (يحوي الصورة) إلى الشريحة.
7. حفظ العرض المعدل كملف PPTX.

يعرض هذا الكود PHP كيفية إنشاء إطار صورة:

```php
  # ينشئ مثالًا من فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # ينشئ مثالًا من فئة Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # يضيف إطار صورة بأبعاد مطابقة لارتفاع وعرض الصورة
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # يكتب ملف PPTX إلى القرص
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 

تسمح إطارات الصور بإنشاء شرائح عرض بسرعة بناءً على الصور. عند دمج إطار الصورة مع خيارات الحفظ في Aspose.Slides، يمكنك التحكم في عمليات الإدخال/الإخراج لتحويل الصور من تنسيق إلى آخر. قد ترغب في زيارة هذه الصفحات: تحويل [الصورة إلى JPG](https://products.aspose.com/slides/ar/php-java/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/ar/php-java/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/ar/php-java/conversion/jpg-to-png/)، تحويل [PNG إلى JPG](https://products.aspose.com/slides/ar/php-java/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/ar/php-java/conversion/png-to-svg/)، تحويل [SVG إلى PNG](https://products.aspose.com/slides/ar/php-java/conversion/svg-to-png/).

{{% /alert %}}

## **إنشاء إطار صورة مع مقياس نسبي**

عن طريق تعديل مقياس الصورة النسبي، يمكنك إنشاء إطار صورة أكثر تعقيدًا.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة من خلال فهرستها. 
3. إضافة صورة إلى مجموعة صور العرض.
4. إنشاء كائن [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) عبر إضافة صورة إلى [ImageCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagecollection/) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل.
5. تحديد العرض والارتفاع النسبيين للصورة داخل إطار الصورة.
6. حفظ العرض المعدل كملف PPTX.

يعرض هذا الكود PHP كيفية إنشاء إطار صورة مع مقياس نسبي:

```php
  # أنشئ فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # احصل على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # أنشئ فئة Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # أضف إطار صورة بأبعاد مساوية لارتفاع وعرض الصورة
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # ضبط مقياس النسبي للعرض والارتفاع
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # احفظ ملف PPTX إلى القرص
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **استخراج الصور النقطية من إطارات الصورة**

يمكنك استخراج الصور النقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/) وحفظها بصيغة PNG أو JPG أو صيغ أخرى. توضح مثال الشفرة أدناه كيفية استخراج صورة من المستند "sample.pptx" وحفظها بصيغة PNG.

```php
  $presentation = new Presentation("sample.pptx");
  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $firstShape = $firstSlide->getShapes()->get_Item(0);
    if (java_instanceof($firstShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
      $pictureFrame = $firstShape;
      try {
        $slideImage = $pictureFrame->getPictureFormat()->getPicture()->getImage()->getImage();
        $slideImage->save("slide_1_shape_1.png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    $presentation->dispose();
  }
```

## **استخراج صور SVG من إطارات الصورة**

عند احتواء عرض تقديمي على رسومات SVG موضوعة داخل أشكال [PictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/)، يتيح Aspose.Slides for PHP via Java استرجاع الصور المتجهة الأصلية بجودة كاملة. من خلال استعراض مجموعة أشكال الشريحة، يمكنك تحديد كل [PictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/)، والتحقق مما إذا كان [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) الأساسي يحتوي على محتوى SVG، ثم حفظ تلك الصورة إلى قرص أو تدفق بصيغة SVG الأصلية.

يظهر المثال التالي كيفية استخراج صورة SVG من إطار صورة:

```php
$presentation = new Presentation("sample.pptx");

try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $svgImage = $shape->getPictureFormat()->getPicture()->getImage()->getSvgImage();

        if ($svgImage !== null) {
            file_put_contents("output.svg", $svgImage->getSvgData());
        }
    }
} finally {
    $presentation->dispose();
}
```

## **الحصول على شفافية الصورة**

يتيح Aspose.Slides الحصول على تأثير الشفافية المطبق على صورة. يوضح هذا الكود PHP العملية:

```php
  $presentation = new Presentation("Test.pptx");
  $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
  foreach($imageTransform as $effect) {
    if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $alphaModulateFixed = $effect;
      $transparencyValue = 100 - $alphaModulateFixed->getAmount();
      echo("Picture transparency: " . $transparencyValue);
    }
  }
```

## **الحصول على السطوع والتباين للصورة**

يتيح Aspose.Slides الحصول على تأثير السطوع والتباين المطبق على صورة. تمثل الفئة [Luminance](https://reference.aspose.com/slides/ar/php-java/aspose.slides/luminance/) هذا التأثير التحولي للصورة.

يوضح هذا الكود PHP كيفية الحصول على إعدادات السطوع والتباين من إطار صورة:

```php
  $presentation = new Presentation("sample.pptx");

  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $pictureFrame = $shape;

    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransformCount = java_values($imageTransform->size());
    for ($index = 0; $index < $imageTransformCount; $index++) {
      $effect = $imageTransform->get_Item($index);
      if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
        $luminance = $effect->getEffective();
        $brightness = java_values($luminance->getBrightness());
        $contrast = java_values($luminance->getContrast());

        echo("Brightness: " . $brightness . PHP_EOL);
        echo("Contrast: " . $contrast . PHP_EOL);
      }
    }
  } finally {
    $presentation->dispose();
  }
```

## **تنسيق إطار الصورة**

يوفر Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار صورة. باستخدام هذه الخيارات، يمكنك تعديل إطار الصورة ليتوافق مع متطلبات معينة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة من خلال فهرستها. 
3. إنشاء كائن [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) عبر إضافة صورة إلى [ImageCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagecollection/) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل.
4. تحديد عرض وارتفاع الصورة.
5. إنشاء `PictureFrame` بناءً على عرض وارتفاع الصورة عبر طريقة [addPictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/addpictureframe/) المتوفرة في كائن [ShapeCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/) المرتبط بالشريحة المرجعية.
6. إضافة إطار الصورة (يحوي الصورة) إلى الشريحة.
7. ضبط لون خط إطار الصورة.
8. ضبط عرض خط إطار الصورة.
9. تدوير إطار الصورة بإعطائه قيمة موجبة أو سالبة.
   * القيمة الموجبة تدور الصورة باتجاه عقارب الساعة. 
   * القيمة السالبة تدور الصورة عكس اتجاه عقارب الساعة.
10. إضافة إطار الصورة (يحوي الصورة) إلى الشريحة.
11. حفظ العرض المعدل كملف PPTX.

يوضح هذا الكود PHP عملية تنسيق إطار الصورة:

```php
  # ينشئ فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # ينشئ فئة Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # يضيف إطار صورة بأبعاد مساوية لارتفاع وعرض الصورة
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # يطبق بعض التنسيق على PictureFrameEx
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # يكتب ملف PPTX إلى القرص
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tip" color="primary" %}}

طورت Aspose مؤخرًا أداة [Collage Maker مجانية](https://products.aspose.app/slides/ar/collage). إذا احتجت إلى [دمج صور JPG/JPEG](https://products.aspose.app/slides/ar/collage/jpg) أو PNG، أو [إنشاء شبكة من الصور](https://products.aspose.app/slides/ar/collage/photo-grid)، يمكنك استخدام هذه الخدمة. 

{{% /alert %}}

## **إضافة صورة كارتباط**

لتقليل حجم العروض الكبيرة، يمكنك إضافة صور (أو فيديوهات) عبر روابط بدلاً من تضمين الملفات مباشرة في العروض. يوضح هذا الكود PHP كيفية إضافة صورة وفيديو إلى عنصر نائب:

```php
  $presentation = new Presentation("input.pptx");
  try {
    $shapesToRemove = new Java("java.util.ArrayList");
    $shapesCount = $presentation->getSlides()->get_Item(0)->getShapes()->size();
    for($i = 0; $i < java_values($shapesCount) ; $i++) {
      $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item($i);
      if (java_is_null($autoShape->getPlaceholder())) {
        continue;
      }
      switch ($autoShape->getPlaceholder()->getType()) {
        case PlaceholderType::Picture :
          $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, $autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), null);
          $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $shapesToRemove->add($autoShape);
          break;
        case PlaceholderType::Media :
          $videoFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addVideoFrame($autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), "");
          $videoFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $videoFrame->setLinkPathLong("https://youtu.be/t_1LYZ102RA");
          $shapesToRemove->add($autoShape);
          break;
      }
    }
    foreach($shapesToRemove as $shape) {
      $presentation->getSlides()->get_Item(0)->getShapes()->remove($shape);
    }
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **قص الصور**

يوضح هذا الكود PHP كيفية قص صورة موجودة على شريحة:

```php
  $pres = new Presentation();
  # ينشئ كائن صورة جديد
  try {
    $picture;
    $image = Images->fromFile($imagePath);
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # يضيف PictureFrame إلى شريحة
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # يقطع الصورة (قيم النسبة المئوية)
    $picFrame->getPictureFormat()->setCropLeft(23.6);
    $picFrame->getPictureFormat()->setCropRight(21.5);
    $picFrame->getPictureFormat()->setCropTop(3);
    $picFrame->getPictureFormat()->setCropBottom(31);
    # يحفظ النتيجة
    $pres->save($outPptxFile, SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **حذف المناطق المقصوصة من صورة**

إذا رغبت في حذف المناطق المقصوصة من صورة داخل إطار، يمكنك استخدام طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas). تُعيد هذه الطريقة الصورة المقصوصة أو الصورة الأصلية إذا لم يكن القَص مطلوبًا.

يوضح هذا الكود PHP العملية:

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # يحصل على PictureFrame من الشريحة الأولى
    $picFrame = $slide->getShapes()->get_Item(0);
    # يحذف المناطق المقصوصة من صورة PictureFrame ويعيد الصورة المقصوصة
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # يحفظ النتيجة
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 

تضيف طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) الصورة المقصوصة إلى مجموعة صور العرض. إذا كانت الصورة مستخدمة فقط في [PictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/) المعالج، يمكن لهذا الإعداد تقليل حجم العرض. وإلا، سيزداد عدد الصور في العرض الناتج.

تحول هذه الطريقة ملفات WMF/EMF الميتافيائل إلى صورة PNG نقطية أثناء عملية القَص. 

{{% /alert %}}

## **ضغط الصور**

يمكنك ضغط صورة في عرض باستخدام طريقة [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_). تُقلص هذه الطريقة الصورة عبر تقليل حجمها بناءً على حجم الشكل والدقة المحددة، مع خيار حذف المناطق المقصوصة.

تكيف حجم الصورة ودقتها مشابهًا لميزة **Picture Format → Compress Pictures → Resolution** في PowerPoint.

توضح أمثلة PHP التالية كيفية ضغط صورة في عرض عبر تحديد دقة هدف وإزالة المناطق المقصوصة اختياريًا:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # ضغط الصورة بدقة مستهدفة 150 DPI (دقة الويب) وإزالة المناطق المقصوصة.
    $result = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);

    # تحقق من نتيجة الضغط.
    if ($result) {
        echo "Image successfully compressed.";
    } else {
        echo "Image compression failed or no changes were necessary.";
    }

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

أو باستخدام قيمة DPI مخصصة مباشرة:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # ضغط الصورة إلى 150 DPI (دقة الويب)، مع إزالة المناطق المقصوصة.
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

تحول الطريقة الصورة إلى دقة أقل بناءً على حجم الشكل وDPI المقدم. يمكن أيضًا حذف المناطق المقصوصة لتحسين حجم الملف.  
إذا كانت الصورة ملف ميتافيائل (WMF/EMF) أو SVG، لن يتم تطبيق الضغط. كما يُحافظ على جودة JPEG أو تُخفض قليلًا بناءً على الدقة، كما هو الحال في PowerPoint للصور JPEG عالية الدقة.

{{% /alert %}}

## **قفل نسبة الأبعاد**

إذا رغبت في احتفاظ الشكل الذي يحتوي على صورة بنسبة أبعاده حتى بعد تغيير أبعاد الصورة، يمكنك استخدام طريقة [setAspectRatioLocked](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) لتفعيل إعداد *Lock Aspect Ratio*.

يوضح هذا الكود PHP كيفية قفل نسبة أبعاد الشكل:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $layout = $pres->getLayoutSlides()->getByType(SlideLayoutType::Custom);
    $emptySlide = $pres->getSlides()->addEmptySlide($layout);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $pictureFrame = $emptySlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $presImage->getWidth(), $presImage->getHeight(), $picture);
    # اجعل الشكل يحافظ على نسبة الأبعاد عند تغيير الحجم
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 

يحافظ إعداد *Lock Aspect Ratio* على نسبة أبعاد الشكل فقط ولا يؤثر على الصورة التي يحتويها.

{{% /alert %}}

## **استخدام خاصية StretchOff**

باستخدام الطرق [setStretchOffsetLeft](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/)، [setStretchOffsetTop](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/setstretchoffsettop/)، [setStretchOffsetRight](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) و[setStretchOffsetBottom](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) من فئة [PictureFillFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/)، يمكنك تحديد مستطيل ملء.

عند تحديد تمديد للصورة، يتم تحجيم مستطيل المصدر ليناسب مستطيل الملء المحدد. يُعرّف كل جانب من جوانب مستطيل الملء بنسبة إزاحة من الجانب المقابل لمستطيل حدود الشكل. النسبة الموجبة تحدد إدخالًا بينما النسبة السالبة تحدد خروجًا.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة من خلال فهرستها.
3. إضافة مستطيل `AutoShape`. 
4. إنشاء صورة.
5. ضبط نوع ملء الشكل.
6. ضبط وضع ملء الصورة للشكل.
7. إضافة صورة للملء.
8. تحديد إزاحات الصورة من الجانب المقابل لمستطيل حدود الشكل.
9. حفظ العرض المعدل كملف PPTX.

يوضح هذا الكود PHP عملية استخدام خاصية StretchOff:

```php
  # ينشئ فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # ينشئ فئة ImageEx
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # يضيف AutoShape من نوع Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # يضبط نوع ملء الشكل
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # يضبط وضع ملء الصورة للشكل
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # يضبط الصورة لملء الشكل
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # يحدد إزاحات الصورة من الحافة المقابلة لمستطيل حدود الشكل
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # يكتب ملف PPTX إلى القرص
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **الأسئلة المتكررة**

**How can I find out which image formats are supported for PictureFrame?**  
يمكنك معرفة صيغ الصور المدعومة لإطار الصورة عبر Aspose.Slides التي تدعم كلًا من الصور النقطية (PNG, JPEG, BMP, GIF, إلخ) والصور المتجهة (مثل SVG) من خلال كائن الصورة المخصص لـ [PictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/). تتقاطع قائمة الصيغ المدعومة عادةً مع قدرات محرك تحويل الشرائح والصور.

**How will adding dozens of large images affect PPTX size and performance?**  
إدراج صور كبيرة يزيد حجم الملف واستهلاك الذاكرة؛ ربط الصور يساعد في تقليل حجم العرض لكنه يتطلب بقاء الملفات الخارجية متاحة. يوفر Aspose.Slides إمكانية إضافة الصور عبر الرابط لتقليل حجم الملف.

**How can I lock an image object from accidental moving/resizing?**  
استخدم [قفل الشكل](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/getpictureframelock/) لإطار الصورة (مثلاً، تعطيل التحريك أو التحجيم). يُدعم نظام القفل مجموعة متنوعة من أنواع الأشكال بما في ذلك [PictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/).

**Is SVG vector fidelity preserved when exporting a presentation to PDF/images?**  
يسمح Aspose.Slides باستخراج SVG من [PictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/) كمتجه أصلي. عند [التصدير إلى PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/) أو [الصيغ النقطية](/slides/ar/php-java/convert-powerpoint-to-png/)، قد يتم تحويله إلى نقطية حسب إعدادات التصدير؛ يبقى أن SVG الأصلي يُحفظ كمتجه ويظهر ذلك عند استخراج الصورة.