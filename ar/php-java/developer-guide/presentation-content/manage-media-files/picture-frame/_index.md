---
title: إدارة إطارات الصور في العروض التقديمية باستخدام PHP
linktitle: إطار الصورة
type: docs
weight: 10
url: /ar/php-java/picture-frame/
keywords:
- إطار الصورة
- إضافة إطار صورة
- إنشاء إطار صورة
- إضافة صورة
- إنشاء صورة
- استخراج صورة
- صورة نقطية
- صورة متجهة
- قطع صورة
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
description: "أضف إطارات صور إلى عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للـ PHP عبر Java. سهل سير العمل وعزز تصاميم الشرائح."
---

إطار الصورة هو شكل يحتوي على صورة — إنه يشبه الصورة داخل إطار.

يمكنك إضافة صورة إلى شريحة عبر إطار صورة. بهذه الطريقة، يمكنك تنسيق الصورة من خلال تنسيق إطار الصورة.

{{% alert  title="Tip" color="primary" %}} 
توفر Aspose محولات مجانية —[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)— تسمح للناس بإنشاء عروض تقديمية بسرعة من الصور. 
{{% /alert %}} 

## **Create a Picture Frame**

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. الحصول على مرجع الشريحة عبر فهرسها.  
3. إنشاء كائن [IPPImage]() بإضافة صورة إلى مجموعة [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل.  
4. تحديد عرض الصورة وارتفاعها.  
5. إنشاء كائن [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/PictureFrame) بناءً على عرض الصورة وارتفاعها عبر طريقة `AddPictureFrame` التي يوفرها كائن الشكل المرتبط بالشريحة المشار إليها.  
6. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.  
7. كتابة العرض المعدل كملف PPTX.  

هذا الكود PHP يوضح كيفية إنشاء إطار صورة:  
```php
  # ينشئ كائن الفئة Presentation الذي يمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # ينشئ كائن الفئة Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # يضيف إطار صورة بنفس ارتفاع وعرض الصورة
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
تسمح إطارات الصورة بإنشاء شرائح عرض بسرعة بناءً على الصور. عند دمج إطار الصورة مع خيارات الحفظ في Aspose.Slides، يمكنك التحكم في عمليات الإدخال/الإخراج لتحويل الصور من تنسيق إلى آخر. قد ترغب في الاطلاع على هذه الصفحات: تحويل [image to JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); تحويل [JPG to image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); تحويل [JPG to PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), تحويل [PNG to JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); تحويل [PNG to SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), تحويل [SVG to PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/). 
{{% /alert %}}

## **Create a Picture Frame with Relative Scale**

بتعديل مقياس الصورة النسبي، يمكنك إنشاء إطار صورة أكثر تعقيدًا.  

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. الحصول على مرجع الشريحة عبر فهرسها.  
3. إضافة صورة إلى مجموعة صور العرض.  
4. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) بإضافة صورة إلى مجموعة [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل.  
5. تحديد العرض والارتفاع النسبيين للصورة داخل إطار الصورة.  
6. كتابة العرض المعدل كملف PPTX.  

هذا الكود PHP يوضح كيفية إنشاء إطار صورة بمقياس نسبي:  
```php
  # إنشاء كائن الفئة Presentation الذي يمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إنشاء كائن الفئة Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # إضافة إطار صورة مع ارتفاع وعرض يساويان الصورة
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # ضبط مقياس العرض والارتفاع النسبي
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # كتابة ملف PPTX إلى القرص
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Extract Raster Images from Picture Frames**

يمكنك استخراج الصور النقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/PictureFrame) وحفظها بتنسيقات PNG، JPG وغيرها. يوضح المثال البرمجي أدناه كيفية استخراج صورة من المستند "sample.pptx" وحفظها بتنسيق PNG.  
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

عندما يحتوي عرض تقديمي على رسومات SVG موضوعة داخل أشكال [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/)، يتيح Aspose.Slides for PHP via Java استرجاع الصور المتجهة الأصلية بجودة كاملة. من خلال استعراض مجموعة أشكال الشريحة، يمكنك تحديد كل [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/)، والتحقق مما إذا كان [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) يحمل محتوى SVG، ثم حفظ تلك الصورة إلى القرص أو إلى تيار بصيغتها الأصلية SVG.

الكود التالي يوضح كيفية استخراج صورة SVG من إطار صورة:  
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

تتيح Aspose.Slides الحصول على تأثير الشفافية المطبق على صورة. يوضح هذا الكود PHP العملية:  
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

توفر Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار صورة. باستخدام هذه الخيارات، يمكنك تعديل إطار الصورة ليتطابق مع المتطلبات المحددة.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. الحصول على مرجع الشريحة عبر فهرسها.  
3. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) بإضافة صورة إلى مجموعة [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل.  
4. تحديد عرض الصورة وارتفاعها.  
5. إنشاء كائن `PictureFrame` بناءً على عرض الصورة وارتفاعها عبر طريقة [AddPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) التي يوفرها كائن [IShapes](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) المرتبط بالشريحة المشار إليها.  
6. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.  
7. ضبط لون خط إطار الصورة.  
8. ضبط عرض خط إطار الصورة.  
9. تدوير إطار الصورة إما بقيمة موجبة أو سالبة.  
   * القيمة الموجبة تدور الصورة باتجاه عقارب الساعة.  
   * القيمة السالبة تدور الصورة عكس اتجاه عقارب الساعة.  
10. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة مرة أخرى.  
11. كتابة العرض المعدل كملف PPTX.  

هذا الكود PHP يوضح عملية تنسيق إطار الصورة:  
```php
  # ينشئ كائن الفئة Presentation الذي يمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # ينشئ كائن الفئة Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # يضيف إطار صورة بارتفاع وعرض يساويان الصورة
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # يطبق بعض التنسيقات على PictureFrameEx
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
طورت Aspose مؤخرًا أداة [free Collage Maker](https://products.aspose.app/slides/collage) مجانًا. إذا احتجت إلى دمج صور JPG/JPEG أو PNG، أو إنشاء شبكات من الصور، يمكنك استخدام هذه الخدمة. 
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
    # يقتطع الصورة (قيم النسبة المئوية)
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

إذا رغبت بحذف المناطق المقطوعة من صورة موجودة داخل إطار، يمكنك استخدام طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) . تُعيد هذه الطريقة الصورة المقطوعة أو الصورة الأصلية إذا لم يكن هناك حاجة للقص.

هذا الكود PHP يوضح العملية:  
```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # يحصل على إطار الصورة من الشريحة الأولى
    $picFrame = $slide->getShapes()->get_Item(0);
    # يحذف مناطق القص من صورة إطار الصورة ويعيد الصورة المقصوصة
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
تضيف طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) الصورة المقطوعة إلى مجموعة صور العرض. إذا كانت الصورة تُستخدم فقط في [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) المعالج، يمكن لهذا الإعداد تقليل حجم العرض. وإلا، سيزداد عدد الصور في العرض الناتج. 

تحول هذه الطريقة ملفات WMF/EMF إلى صورة PNG نقطية أثناء عملية القص. 
{{% /alert %}}

## **Lock Aspect Ratio**

إذا رغبت في أن يحتفظ الشكل الذي يحتوي على صورة بنسبة أبعاده حتى بعد تغيير أبعاد الصورة، يمكنك استخدام طريقة [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) لضبط إعداد *قفل نسبة الأبعاد*.

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
يُحافظ إعداد *قفل نسبة الأبعاد* فقط على نسبة أبعاد الشكل وليس على الصورة التي يحتويها. 
{{% /alert %}}

## **Use the StretchOff Property**

باستخدام خصائص [StretchOffsetLeft](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-)، [StretchOffsetTop](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetTop--)، [StretchOffsetRight](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetRight--) و[StretchOffsetBottom](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat) وفئة [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat)، يمكنك تحديد مستطيل ملء.

عند تحديد تمديد الصورة، يتم تحجيم المستطيل المصدر ليتناسب مع مستطيل الملء المحدد. كل حافة من حواف مستطيل الملء تُعرَّف بنسبة مئوية تُقاس من الحافة المقابلة لصندوق حدود الشكل. النسبة المئوية الموجبة تُحدِّد تقليصًا، والسالبة تُحدِّد توسعًا.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentatio).  
2. الحصول على مرجع الشريحة عبر فهرسها.  
3. إضافة شكل مستطيل `AutoShape`.  
4. إنشاء صورة.  
5. تعيين نوع ملء الشكل.  
6. تعيين وضع ملء صورة الشكل.  
7. إضافة صورة للملء داخل الشكل.  
8. تحديد إزاحات الصورة من الحافة المقابلة لصندوق حدود الشكل.  
9. كتابة العرض المعدل كملف PPTX.  

هذا الكود PHP يوضح عملية استخدام خاصية StretchOff:  
```php
  # ينشئ فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # ينشئ كائن فئة ImageEx
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # يضيف AutoShape مضبوطة على المستطيل
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # يحدد نوع التعبئة للشكل
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # يحدد وضع تعبئة الصورة للشكل
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # يحدد الصورة لملء الشكل
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

**كيف يمكنني معرفة تنسيقات الصور المدعومة لإطار الصورة؟**  
يدعم Aspose.Slides كلًا من الصور النقطية (PNG، JPEG، BMP، GIF، إلخ) والصور المتجهة (مثل SVG) عبر كائن الصورة المعيّن إلى [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/). عادةً ما تتقاطع قائمة التنسيقات المدعومة مع قدرات محرك تحويل الشرائح والصور.

**كيف سيؤثر إضافة العشرات من الصور الكبيرة على حجم PPTX وأدائه؟**  
تزيد تضمين الصور الكبيرة من حجم الملف واستهلاك الذاكرة؛ وربط الصور يقلل من حجم العرض لكنه يتطلب بقاء الملفات الخارجية متاحة. توفر Aspose.Slides إمكانية إضافة الصور عبر الروابط لتقليل حجم الملف.

**كيف يمكنني قفل كائن الصورة لمنعه من التحرك/تغيير الحجم عن طريق الخطأ؟**  
استخدم [قفل الأشكال](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/getpictureframelock/) لـ [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) (مثلاً، تعطيل التحريك أو تغيير الحجم). تُشرح آلية القفل للأشكال في مقالة [الحماية](/slides/ar/php-java/applying-protection-to-presentation/) وتُدعم لأنواع متعددة من الأشكال بما فيها [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/).

**هل يتم الحفاظ على جودة المتجهات SVG عند تصدير العرض إلى PDF/صور؟**  
يسمح Aspose.Slides باستخراج SVG من [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) كمتجه أصلي. عند [التصدير إلى PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/) أو [التنسيقات النقطية](/slides/ar/php-java/convert-powerpoint-to-png/)، قد يتم تحويله إلى نقطي حسب إعدادات التصدير؛ ومع ذلك، يظل الـ SVG الأصلي محفوظًا كمتجه حسب سلوك الاستخراج.