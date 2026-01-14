---
title: إدارة إطارات الصورة في العروض باستخدام PHP
linktitle: إطار صورة
type: docs
weight: 10
url: /ar/php-java/picture-frame/
keywords:
- إطار صورة
- إضافة إطار صورة
- إنشاء إطار صورة
- إضافة صورة
- إنشاء صورة
- استخراج صورة
- صورة نقطية
- صورة متجهة
- قص صورة
- منطقة مقصوصة
- خاصية StretchOff
- تنسيق إطار صورة
- خصائص إطار صورة
- مقياس نسبي
- تأثير صورة
- نسبة الأبعاد
- شفافية الصورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إضافة إطارات صورة إلى عروض PowerPoint و OpenDocument باستخدام Aspose.Slides لـ PHP عبر Java. بسط سير العمل وعزز تصاميم الشرائح."
---

الإطار الصوري هو شكل يحتوي على صورة — إنه مثل صورة داخل إطار.

يمكنك إضافة صورة إلى شريحة عبر إطار صوري. بهذه الطريقة، يمكنك تنسيق الصورة من خلال تنسيق الإطار الصوري.

{{% alert  title="Tip" color="primary" %}} 

توفر Aspose محولات مجانية —[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — تمكّن المستخدمين من إنشاء عروض تقديمية بسرعة من الصور. 

{{% /alert %}} 

## **Create a Picture Frame**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. إنشاء كائن [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) بإضافة صورة إلى [Imagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل.
4. تحديد عرض الصورة وارتفاعها.
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) بناءً على عرض الصورة وارتفاعها عبر طريقة `addPictureFrame` التي يوفرها كائن الشكل المرتبط بالشريحة المرجعية.
6. إضافة إطار صوري (يحتوي على الصورة) إلى الشريحة.
7. كتابة العرض المعدل كملف PPTX.

هذا الكود PHP يوضح كيفية إنشاء إطار صوري:
```php
  # ينشئ كائن فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # ينشئ كائن فئة Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # يضيف إطار صورة بارتفاع وعرض الصورة المقابل
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # يحفظ ملف PPTX إلى القرص
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="warning" %}} 

تسمح الإطارات الصورية بإنشاء شرائح عرض بسرعة بناءً على الصور. عند دمج إطار صوري مع خيارات الحفظ Aspose.Slides، يمكنك التحكم في عمليات الإدخال/الإخراج لتحويل الصور من تنسيق إلى آخر. قد ترغب في زيارة هذه الصفحات: تحويل [image to JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/)؛ تحويل [JPG to image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/)؛ تحويل [JPG to PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/)، تحويل [PNG to JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/)؛ تحويل [PNG to SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/)، تحويل [SVG to PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).

{{% /alert %}}

## **Create a Picture Frame with Relative Scale**

بتغيير مقياس الصورة النسبي، يمكنك إنشاء إطار صوري أكثر تعقيدًا.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. إضافة صورة إلى مجموعة صور العرض.
4. إنشاء كائن [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) بإضافة صورة إلى [Imagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل.
5. تحديد العرض والارتفاع النسبيين للصورة في إطار الصوري.
6. كتابة العرض المعدل كملف PPTX.

هذا الكود PHP يوضح كيفية إنشاء إطار صوري مع مقياس نسبي:
```php
  # ينشئ فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # ينشئ فئة Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # يضيف إطار صورة بارتفاع وعرض مساويين للصورة
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # ضبط مقياس العرض والارتفاع النسبي
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # حفظ ملف PPTX إلى القرص
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Extract Raster Images from Picture Frames**

يمكنك استخراج الصور النقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) وحفظها بصيغة PNG أو JPG أو صيغ أخرى. يوضح المثال البرمجي أدناه كيفية استخراج صورة من المستند "sample.pptx" وحفظها بصيغة PNG.
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


## **Extract SVG Images from Picture Frames**

عند احتواء عرض تقديمي على رسومات SVG داخل أشكال [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/)، يتيح Aspose.Slides for PHP via Java استرداد الصور المتجهة الأصلية بدقة كاملة. من خلال استعراض مجموعة أشكال الشريحة، يمكنك التعرف على كل [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/)، والتحقق مما إذا كان كائن [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) الأساسي يحتوي على محتوى SVG، ثم حفظ تلك الصورة إلى قرص أو تدفق بصيغة SVG الأصلية.

المثال البرمجي التالي يوضح كيفية استخراج صورة SVG من إطار صوري:
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


## **Get Transparency of an Image**

يسمح Aspose.Slides بالحصول على تأثير الشفافية المطبق على صورة. يوضح هذا الكود PHP العملية:
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


## **Picture Frame Formatting**

يوفر Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار صوري. باستخدام هذه الخيارات، يمكنك تعديل إطار صوري ليتناسب مع متطلبات محددة.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. إنشاء كائن [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) بإضافة صورة إلى [Imagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل.
4. تحديد عرض الصورة وارتفاعها.
5. إنشاء `PictureFrame` بناءً على عرض الصورة وارتفاعها عبر طريقة [addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) التي يوفرها كائن [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) المرتبط بالشريحة المرجعية.
6. إضافة إطار الصوري (الذي يحتوي على الصورة) إلى الشريحة.
7. تعيين لون حد إطار الصوري.
8. تعيين عرض حد إطار الصوري.
9. تدوير إطار الصوري بإعطائه قيمة إما موجبة أو سالبة.
   * القيمة الموجبة تدور الصورة باتجاه عقارب الساعة. 
   * القيمة السالبة تدور الصورة عكس اتجاه عقارب الساعة.
10. إضافة إطار الصوري (الذي يحتوي على الصورة) إلى الشريحة.
11. كتابة العرض المعدل كملف PPTX.

هذا الكود PHP يوضح عملية تنسيق إطار صوري:
```php
  # ينشئ فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # ينشئ فئة Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # يضيف إطار صورة بارتفاع وعرض مساويين للصورة
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # يطبق بعض التنسيق على PictureFrameEx
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # يحفظ ملف PPTX إلى القرص
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="Tip" color="primary" %}}

طوّرت Aspose مؤخرًا أداة [Collage Maker مجانية](https://products.aspose.app/slides/collage). إذا احتجت إلى [دمج صور JPG/JPEG](https://products.aspose.app/slides/collage/jpg) أو PNG، أو [إنشاء شبكات من الصور](https://products.aspose.app/slides/collage/photo-grid)، يمكنك استخدام هذه الخدمة. 

{{% /alert %}}

## **Add an Image as a Link**

لتقليل حجم العروض التقديمية الكبيرة، يمكنك إضافة الصور (أو الفيديوهات) عبر روابط بدلاً من تضمين الملفات مباشرةً في العروض. يوضح هذا الكود PHP كيفية إضافة صورة وفيديو إلى عنصر نائب:
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


## **Crop Images**

يظهر هذا الكود PHP كيفية قص صورة موجودة على شريحة:
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
    # يضيف إطار صورة إلى شريحة
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # يقص الصورة (قيم النسبة المئوية)
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


## **Delete Cropped Areas of a Picture**

إذا أردت حذف المناطق المقصوصة من صورة موجودة داخل إطار، يمكنك استخدام طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas). تُرجع هذه الطريقة الصورة المقصوصة أو الصورة الأصلية إذا لم يكن القص ضروريًا.

هذا الكود PHP يوضح العملية:
```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # يحصل على إطار الصورة من الشريحة الأولى
    $picFrame = $slide->getShapes()->get_Item(0);
    # يزيل مناطق القص من صورة إطار الصورة ويعيد الصورة المقصوصة
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

طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) تضيف الصورة المقصوصة إلى مجموعة صور العرض. إذا كانت الصورة مستخدمة فقط في [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) المُعالجة، يمكن لهذا الإعداد تقليل حجم العرض. وإلا، سيزداد عدد الصور في العرض الناتج.

تحول هذه الطريقة ملفات WMF/EMF إلى صورة PNG نقطية أثناء عملية القص. 

{{% /alert %}}

## **Lock Aspect Ratio**

إذا رغبت في أن يحتفظ شكل يحتوي على صورة بنسبة أبعاده حتى بعد تغيير أبعاد الصورة، يمكنك استخدام طريقة [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) لتفعيل إعداد *Lock Aspect Ratio*.

هذا الكود PHP يوضح كيفية قفل نسبة أبعاد الشكل:
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
    # تعيين الشكل للحفاظ على نسبة الأبعاد عند التحجيم
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="NOTE" color="warning" %}} 

إعداد *Lock Aspect Ratio* يحافظ فقط على نسبة أبعاد الشكل وليس الصورة التي يحتويها.

{{% /alert %}}

## **Use the StretchOff Property**

باستخدام الطرق [setStretchOffsetLeft](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/)، [setStretchOffsetTop](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsettop/)، [setStretchOffsetRight](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) و[setStretchOffsetBottom](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) من فئة [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/)، يمكنك تحديد مستطيل ملء.

عند تحديد تمديد لصورة، يتم تحجيم مستطيل المصدر ليتناسب مع مستطيل الملء المحدد. كل حافة من حواف مستطيل الملء تُحدَّد بنسبة مئوية من الحافة المقابلة لإطار الشكل. النسبة المئوية الموجبة تشير إلى تقليص، بينما النسبة السالبة تشير إلى توسيع.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرستها.
3. إضافة مستطيل `AutoShape`. 
4. إنشاء صورة.
5. تعيين نوع ملء الشكل.
6. تعيين وضع ملء صورة الشكل.
7. إضافة صورة للملء.
8. تحديد إزاحات الصورة من الحافة المقابلة لإطار الشكل.
9. كتابة العرض المعدل كملف PPTX.

هذا الكود PHP يوضح عملية استخدام خاصية StretchOff:
```php
  # ينشئ كائن الفئة Presentation الذي يمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # ينشئ كائن الفئة ImageEx
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # يضيف AutoShape من النوع Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # يحدد نوع تعبئة الشكل
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # يحدد وضع تعبئة الصورة للشكل
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # يضبط الصورة لتملأ الشكل
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # يحدد إزاحات الصورة من الحافة المقابلة لإطار الصندوق المحيط بالشكل
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


## **FAQ**

**How can I find out which image formats are supported for PictureFrame?**

يدعم Aspose.Slides كلًا من الصور النقطية (PNG, JPEG, BMP, GIF, إلخ) والصور المتجهة (مثل SVG) عبر كائن الصورة المعين إلى [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/). عادةً ما تتقاطع قائمة الصيغ المدعومة مع إمكانات محرك تحويل الشرائح والصور.

**How will adding dozens of large images affect PPTX size and performance?**

يزيد إدراج صور كبيرة من حجم الملف واستهلاك الذاكرة؛ ربط الصور يساعد على تقليل حجم العرض لكن يتطلب بقاء الملفات الخارجية متاحة. يوفر Aspose.Slides القدرة على إضافة صور عبر روابط لتقليل حجم الملف.

**How can I lock an image object from accidental moving/resizing?**

استخدم [قفل الأشكال](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/getpictureframelock/) لـ [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) (مثلاً، تعطيل النقل أو تغيير الحجم). يوضح آلية القفل للأشكال في مقال [الحماية](/slides/ar/php-java/applying-protection-to-presentation/) وتدعم أنواعًا متعددة من الأشكال، بما في ذلك [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/).

**Is SVG vector fidelity preserved when exporting a presentation to PDF/images?**

يسمح Aspose.Slides باستخراج SVG من [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) كمتجه أصلي. عند [التصدير إلى PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/) أو [الصيغ النقطية](/slides/ar/php-java/convert-powerpoint-to-png/)، قد يتم تحويله إلى نقطي اعتمادًا على إعدادات التصدير؛ لكن يبقى حفظ SVG الأصلي كمتجه مؤكدًا بسلوك الاستخراج.