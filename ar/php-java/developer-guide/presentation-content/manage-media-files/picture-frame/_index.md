---
title: إدارة إطارات الصور في العروض باستخدام PHP
linktitle: إطار الصورة
type: docs
weight: 10
url: /ar/php-java/picture-frame/
keywords:
- إطار الصورة
- إضافة إطار الصورة
- إنشاء إطار الصورة
- إضافة صورة
- إنشاء صورة
- استخراج صورة
- صورة نقطية
- صورة متجهة
- قص صورة
- منطقة مقصوصة
- خاصية StretchOff
- تنسيق إطار الصورة
- خصائص إطار الصورة
- مقياس نسبي
- تأثير الصورة
- نسبة الأبعاد
- شفافية الصورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "أضف إطارات الصور إلى عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للـ PHP عبر Java. سهل سير عملك وعزز تصميم الشرائح."
---

إطار الصورة هو شكل يحتوي على صورة—فهو مثل الصورة داخل إطار. 

يمكنك إضافة صورة إلى شريحة عبر إطار صورة. بهذه الطريقة، يمكنك تنسيق الصورة عن طريق تنسيق إطار الصورة.

{{% alert  title="Tip" color="primary" %}} 
توفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—تمكن الأشخاص من إنشاء عروض تقديمية بسرعة من الصور. 
{{% /alert %}} 

## **إنشاء إطار صورة**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. إنشاء كائن [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) عن طريق إضافة صورة إلى [ImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) المرتبط بكائن العرض التقديمي الذي سيُستخدم لملء الشكل.
4. تحديد عرض وارتفاع الصورة.
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) بناءً على عرض وارتفاع الصورة عبر طريقة `addPictureFrame` التي يوفرها كائن الشكل المرتبط بالشريحة المرجعية.
6. إضافة إطار صورة (يحتوي على الصورة) إلى الشريحة.
7. حفظ العرض التقديمي المعدل كملف PPTX.

يعرض لك هذا الكود PHP كيفية إنشاء إطار صورة:
```php
  # ينشئ كائن من الفئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # ينشئ كائن من الفئة Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # يضيف إطار صورة بارتفاع وعرض متساويين للصورة
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
تتيح لك إطارات الصورة إنشاء شرائح عرض تقديمي بسرعة بناءً على الصور. عند دمج إطار الصورة مع خيارات الحفظ في Aspose.Slides، يمكنك التحكم بعمليات الإدخال/الإخراج لتحويل الصور من تنسيق إلى آخر. قد ترغب في زيارة هذه الصفحات: تحويل [image إلى JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); تحويل [JPG إلى image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/)، تحويل [PNG إلى JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/)، تحويل [SVG إلى PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/). 
{{% /alert %}}

## **إنشاء إطار صورة مع مقياس نسبي**

عن طريق تعديل مقياس الصورة النسبي، يمكنك إنشاء إطار صورة أكثر تعقيدًا. 

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. إضافة صورة إلى مجموعة صور العرض التقديمي.
4. إنشاء كائن [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) عن طريق إضافة صورة إلى [ImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) المرتبط بكائن العرض التقديمي الذي سيُستخدم لملء الشكل.
5. تحديد العرض والارتفاع النسبيين للصورة في إطار الصورة.
6. حفظ العرض التقديمي المعدل كملف PPTX.

يعرض لك هذا الكود PHP كيفية إنشاء إطار صورة مع مقياس نسبي:
```php
  # إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إنشاء كائن من فئة Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # إضافة إطار صورة بارتفاع وعرض مساويين للصورة
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # ضبط النسبة النسبية للعرض والارتفاع
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


## **استخراج صور نقطية من إطارات الصورة**

يمكنك استخراج الصور النقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) وحفظها بصيغ PNG أو JPG أو صيغ أخرى. يوضح المثال البرمجي أدناه كيفية استخراج صورة من المستند "sample.pptx" وحفظها بصيغة PNG.
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

عندما يحتوي العرض التقديمي على رسومات SVG موضوعة داخل أشكال [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/)، يتيح لك Aspose.Slides for PHP via Java استرجاع الصور المتجهة الأصلية بجودة كاملة. من خلال استعراض مجموعة أشكال الشريحة، يمكنك تحديد كل [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/)، والتحقق مما إذا كان كائن [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) يحمل محتوى SVG، ثم حفظ تلك الصورة إلى القرص أو إلى تدفق بصيغتها الأصلية SVG.

المثال البرمجي التالي يوضح كيفية استخراج صورة SVG من إطار صورة:
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


## **الحصول على شفافية صورة**

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


## **تنسيق إطار الصورة**

توفر Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار صورة. باستخدام هذه الخيارات، يمكنك تعديل إطار الصورة ليتوافق مع المتطلبات المحددة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. إنشاء كائن [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) عن طريق إضافة صورة إلى [ImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) المرتبط بكائن العرض التقديمي الذي سيُستخدم لملء الشكل.
4. تحديد عرض وارتفاع الصورة.
5. إنشاء `PictureFrame` بناءً على عرض وارتفاع الصورة عبر طريقة [addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) التي يوفرها كائن [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) المرتبط بالشريحة المرجعية.
6. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.
7. تعيين لون حدود إطار الصورة.
8. تعيين عرض حدود إطار الصورة.
9. تدوير إطار الصورة بإعطائه قيمة إيجابية أو سلبية.
   * القيمة الإيجابية تدور الصورة باتجاه عقارب الساعة. 
   * القيمة السلبية تدور الصورة عكس اتجاه عقارب الساعة.
10. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.
11. حفظ العرض التقديمي المعدل كملف PPTX.

يوضح هذا الكود PHP عملية تنسيق إطار الصورة:
```php
  # ينشئ كائن من فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # ينشئ كائن من فئة Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # يضيف إطار صورة بارتفاع وعرض مساويين للصورة
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
طوَّرت Aspose مؤخرًا أداة **Collage Maker** مجانية ([Collage Maker](https://products.aspose.app/slides/collage)). إذا احتجت إلى دمج صور JPG/JPEG أو PNG، أو إنشاء شبكات من الصور، يمكنك استخدام هذه الخدمة. 
{{% /alert %}}

## **إضافة صورة كرابط**

لتقليل حجم العروض التقديمية الكبيرة، يمكنك إضافة صور (أو مقاطع فيديو) عبر روابط بدلاً من تضمين الملفات مباشرةً في العرض. يوضح هذا الكود PHP كيفية إضافة صورة وفيديو إلى عنصر نائب:
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


## **حذف المناطق المقصوصة من إطار الصورة**

إذا كنت ترغب في حذف المناطق المقصوصة من صورة موجودة داخل إطار، يمكنك استخدام طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas). تُعيد هذه الطريقة الصورة المقصوصة أو الصورة الأصلية إذا كان التقليم غير ضروري.

يوضح هذا الكود PHP العملية:
```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # يحصل على إطار الصورة من الشريحة الأولى
    $picFrame = $slide->getShapes()->get_Item(0);
    # يحذف المناطق المقصوصة من صورة إطار الصورة ويعيد الصورة المقصوصة
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
تضيف طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) الصورة المقصوصة إلى مجموعة صور العرض التقديمي. إذا كانت الصورة مستخدمة فقط في [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) المعالجة، يمكن لهذا الإعداد تقليل حجم العرض. وإلا، سيزداد عدد الصور في العرض الناتج.

تحول هذه الطريقة ملفات WMF/EMF إلى صورة PNG نقطية أثناء عملية القص. 
{{% /alert %}}

## **قفل نسبة الأبعاد**

إذا رغبت في أن يحتفظ الشكل الذي يحتوي على صورة بنسبة أبعاده حتى بعد تعديل أبعاد الصورة، يمكنك استخدام طريقة [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) لضبط إعداد *قفل نسبة الأبعاد*.

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
    # تعيين الشكل للحفاظ على نسبة الأبعاد عند تغيير الحجم
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="NOTE" color="warning" %}} 
هذا الإعداد *قفل نسبة الأبعاد* يحافظ فقط على نسبة أبعاد الشكل ولا يؤثر على الصورة التي يحتويها. 
{{% /alert %}}

## **استخدام خاصية StretchOff**

باستخدام طرق [setStretchOffsetLeft](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/)، [setStretchOffsetTop](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsettop/)، [setStretchOffsetRight](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) و[setStretchOffsetBottom](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) من فئة [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/)، يمكنك تحديد مستطيل ملء.

عند تحديد تمديد لصورة، يتم تحجيم مستطيل المصدر ليتناسب مع مستطيل الملء المحدد. يحدد كل جانب من جوانب مستطيل الملء نسبة مئوية من الإزاحة عن الجانب المقابل من صندوق حد الشكل. النسبة المئوية الإيجابية تعني تقليص، والسلبية تعني توسيع.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرسها.
3. إضافة مستطيل `AutoShape`. 
4. إنشاء صورة.
5. تعيين نوع ملء الشكل.
6. تعيين وضع ملء صورة الشكل.
7. إضافة صورة لتعبئة الشكل.
8. تحديد إزاحات الصورة من الجانب المقابل لصندوق حد الشكل.
9. حفظ العرض التقديمي المعدل كملف PPTX.

يوضح هذا الكود PHP عملية استخدام خاصية StretchOff:
```php
  # ينشئ كائن من فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # ينشئ كائن من فئة ImageEx
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
    # يحدد الصورة لتعبئة الشكل
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # يحدد إزاحات الصورة من الحافة المقابلة لصندوق حدود الشكل
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

**كيف يمكنني معرفة صيغ الصور المدعومة لإطار الصورة؟**

يدعم Aspose.Slides كلًا من الصور النقطية (PNG، JPEG، BMP، GIF، إلخ) والصور المتجهة (مثل SVG) عبر كائن الصورة المخصص لـ [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/). عادةً ما تتداخل قائمة الصيغ المدعومة مع قدرات محرك تحويل الشرائح والصور.

**كيف سيؤثر إضافة عشرات الصور الكبيرة على حجم وأداء ملف PPTX؟**

تزيد تضمين الصور الكبيرة من حجم الملف واستهلاك الذاكرة؛ بينما يساعد ربط الصور على تقليل حجم العرض التقديمي لكنه يتطلب بقاء الملفات الخارجية متاحة. يوفر Aspose.Slides إمكانية إضافة الصور عبر الروابط لتقليل حجم الملف.

**كيف يمكنني قفل كائن صورة لمنع تحريكه/تغييره غير مقصود؟**

استخدم [قفل الأشكال](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/getpictureframelock/) لـ [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) (مثل منع التحريك أو تغيير الحجم). يدعم آلية القفل أنواعًا متعددة من الأشكال بما فيها [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/).

**هل تُحافظ على دقة متجه SVG عند تصدير العرض التقديمي إلى PDF/صور؟**

يسمح Aspose.Slides باستخراج SVG من [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) كمتجه أصلي. عند [التصدير إلى PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/) أو [الصيغ النقطية](/slides/ar/php-java/convert-powerpoint-to-png/)، قد يتم تحويله إلى نقطية حسب إعدادات التصدير؛ ومع ذلك يظل SVG الأصلي محفوظًا كمتجه كما يظهر سلوك الاستخراج.