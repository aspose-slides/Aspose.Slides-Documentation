---
title: إطار الصورة
type: docs
weight: 10
url: /ar/php-java/picture-frame/
keywords: "إضافة إطار صورة، إنشاء إطار صورة، إضافة صورة، إنشاء صورة، استخراج صورة، خاصية StretchOff، تنسيق إطار الصورة، خصائص إطار الصورة، عرض PowerPoint، Java، Aspose.Slides لPHP عبر Java"
description: "إضافة إطار صورة إلى عرض PowerPoint "

---

إطار الصورة هو شكل يحتوي على صورة—مثل صورة في إطار.

يمكنك إضافة صورة إلى شريحة من خلال إطار الصورة. بهذه الطريقة، يمكنك تنسيق الصورة عن طريق تنسيق إطار الصورة.

{{% alert  title="نصيحة" color="primary" %}} 

توفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و [PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—تسمح للأشخاص بإنشاء عروض تقديمية بسرعة من الصور. 

{{% /alert %}} 

## **إنشاء إطار صورة**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. احصل على مرجع شريحة من خلال مؤشرها. 
3. أنشئ كائن [IPPImage]() عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) المرتبطة بكائن العرض الذي سيتم استخدامه لملء الشكل.
4. حدد عرض الصورة وارتفاعها.
5. أنشئ [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/PictureFrame) بناءً على عرض الصورة وارتفاعها من خلال طريقة `AddPictureFrame` المعروضة بواسطة كائن الشكل المرتبط بالشريحة المشار إليها.
6. أضف إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.
7. اكتب العرض المعدل كملف PPTX.

هذا الكود PHP يوضح لك كيفية إنشاء إطار صورة:

```php
  # يثبّت كائن فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يثبّت كائن الفئة Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # يضيف إطار صورة بارتفاع وعرض الصورة المكافئين
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

تسمح لك إطارات الصور بإنشاء شرائح عروض تقديمية بسرعة بناءً على الصور. عند دمج إطار الصورة مع خيارات الحفظ في Aspose.Slides، يمكنك التلاعب بعمليات الإدخال/الإخراج لتحويل الصور من تنسيق إلى آخر. قد ترغب في الاطلاع على هذه الصفحات: تحويل [صورة إلى JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/)، تحويل [PNG إلى JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/)، تحويل [SVG إلى PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).

{{% /alert %}}

## **إنشاء إطار صورة بمقياس نسبي**

من خلال تغيير النطاق النسبي لصورة، يمكنك إنشاء إطار صورة أكثر تعقيدًا. 

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. احصل على مرجع شريحة من خلال مؤشرها. 
3. أضف صورة إلى مجموعة الصور في العرض.
4. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) المرتبطة بكائن العرض الذي سيتم استخدامه لملء الشكل.
5. حدد عرض الصورة وارتفاعها النسبي في إطار الصورة.
6. اكتب العرض المعدل كملف PPTX.

هذا الكود PHP يوضح لك كيفية إنشاء إطار صورة بمقياس نسبي:

```php
  # يثبّت كائن فئة Presentation التي تمثل PPTX
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يثبّت كائن الفئة Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # يضيف إطار صورة بارتفاع وعرض مكافئين للصورة
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # تعيين النسبة المئوية لعرض وارتفاع الصورة
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # يكتب ملف PPTX إلى القرص
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **استخراج صورة من إطار الصورة**

يمكنك استخراج الصور من كائنات [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/PictureFrame) وحفظها في تنسيق PNG، JPG، وتنسيقات أخرى. المثال البرمجي أدناه يوضح كيفية استخراج صورة من المستند "sample.pptx" وحفظها في تنسيق PNG.

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

## **الحصول على شفافية الصورة**

تسمح لك Aspose.Slides بالحصول على شفافية الصورة. هذا الكود PHP يوضح العملية:

```php
  $presentation = new Presentation($folderPath . "Test.pptx");
  $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
  foreach($imageTransform as $effect) {
    if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $alphaModulateFixed = $effect;
      $transparencyValue = 100 - $alphaModulateFixed->getAmount();
      echo("شفافية الصورة: " . $transparencyValue);
    }
  }
```

## **تنسيق إطار الصورة**

توفر Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار الصورة. باستخدام تلك الخيارات، يمكنك تغيير إطار الصورة ليناسب متطلبات محددة.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. احصل على مرجع شريحة من خلال مؤشرها. 
3. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/IPPImage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection) المرتبطة بكائن العرض الذي سيتم استخدامه لملء الشكل.
4. حدد عرض الصورة وارتفاعها.
5. أنشئ `PictureFrame` بناءً على عرض الصورة وارتفاعها من خلال طريقة [AddPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) المعروضة من قبل كائن [IShapes](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) المرتبط بالشريحة المشار إليها.
6. أضف إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.
7. حدد لون خط إطار الصورة.
8. حدد عرض خط إطار الصورة.
9. قم بتدوير إطار الصورة بإعطائه قيمة إيجابية أو سلبية.
   * القيمة الإيجابية تدور الصورة في اتجاه عقارب الساعة. 
   * القيمة السلبية تدور الصورة في الاتجاه المعاكس.
10. أضف إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.
11. اكتب العرض المعدل كملف PPTX.

هذا الكود PHP يوضح عملية تنسيق إطار الصورة:

```php
  # يثبّت كائن فئة Presentation التي تمثل PPTX
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يثبّت كائن الفئة Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # يضيف إطار صورة بارتفاع وعرض مكافئين للصورة
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # تطبق بعض التنسيقات على PictureFrameEx
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

{{% alert title="نصيحة" color="primary" %}}

طورت Aspose مؤخرًا [صانع الكولاج المجاني](https://products.aspose.app/slides/collage). إذا كنت بحاجة أبدًا إلى [دمج JPG/JPEG](https://products.aspose.app/slides/collage/jpg) أو صور PNG، أو [إنشاء شبكات من الصور](https://products.aspose.app/slides/collage/photo-grid)، يمكنك استخدام هذه الخدمة. 

{{% /alert %}}

## **إضافة صورة كرابط**

لتجنب أحجام العروض الكبيرة، يمكنك إضافة صور (أو مقاطع فيديو) من خلال روابط بدلاً من تضمين الملفات مباشرة في العروض التقديمية. هذا الكود PHP يوضح لك كيفية إضافة صورة وفيديو إلى عنصر نائب:

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

## **قص صورة**

هذا الكود PHP يوضح لك كيفية قص صورة موجودة على شريحة:

```php
  $pres = new Presentation();
  # ينشئ كائن صورة جديدة
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
    # يقص الصورة (القيم بالنسبة المئوية)
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

## حذف المناطق المقصوصة من الصورة

إذا كنت ترغب في حذف المناطق المقصوصة من صورة تحتويها إطار، يمكنك استخدام الطريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--). هذه الطريقة ترجع الصورة المقصوصة أو الصورة الأصلية إذا كان القص غير ضروري.

هذا الكود PHP يوضح العملية:

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # يحصل على إطار الصورة من الشريحة الأولى
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

{{% alert title="ملاحظة" color="warning" %}} 

تضيف طريقة [deletePictureCroppedAreas()](https://reference.aspose.com/slides/php-java/aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) الصورة المقصوصة إلى مجموعة صور العرض. إذا تم استخدام الصورة فقط في [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) المعالجة، يمكن أن يقلل هذا الإعداد حجم العرض. خلاف ذلك، قد يزداد عدد الصور في العرض الناتج.

تحول هذه الطريقة ملفات WMF/EMF المتجهة إلى صورة PNG نقطية في عملية القص. 

{{% /alert %}}

## **قفل نسبة العرض إلى الارتفاع**

إذا كنت ترغب في أن يحتفظ شكل يحتوي على صورة بنسبته حتى بعد تغيير أبعاد الصورة، يمكنك استخدام الطريقة [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) لتعيين إعداد *قفل نسبة العرض إلى الارتفاع*.

هذا الكود PHP يوضح لك كيفية قفل نسبة العرض إلى الارتفاع لشكل:

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
    # تعيين الشكل للاحتفاظ بنسبة العرض إلى الارتفاع عند تغيير الحجم
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="ملاحظة" color="warning" %}} 

يحتفظ إعداد *قفل نسبة العرض إلى الارتفاع* فقط بنسبة العرض إلى الارتفاع للشكل وليس للصورة التي يحتوي عليها.

{{% /alert %}}

## **استخدام خاصية StretchOff**

باستخدام الخاصيات [StretchOffsetLeft](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-)، [StretchOffsetTop](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetTop--)، [StretchOffsetRight](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetRight--) و [StretchOffsetBottom](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat) والفئة [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IPictureFillFormat)، يمكنك تحديد مستطيل تعبئة.

عند تحديد التمدد لصورة، يتم تغيير مقطع مصدر ليتناسب مع المستطيل المخصص. يتم تعريف كل حافة من المستطيل المخصص بواسطة نسبة مئوية من حافة الشكل. تحدد النسبة المئوية الإيجابية إدخالًا بينما تحدد النسبة السلبية إدخالًا خارجيًا.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentatio).
2. احصل على مرجع شريحة من خلال مؤشرها.
3. أضف مستطيلًا `AutoShape`. 
4. أنشئ صورة.
5. حدد نوع تعبئة الشكل.
6. حدد وضع تعبئة صورة الشكل.
7. أضف صورة محددة لتعبئة الشكل.
8. حدد انزياحات الصورة من الحافة المقابلة لصندوق الشكل.
9. اكتب العرض المعدل كملف PPTX.

هذا الكود PHP يوضح عملية يتم فيها استخدام خاصية StretchOff:

```php
  # يثبّت كائن فئة Prseetation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # يثبّت كائن الفئة ImageEx
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # يضيف AutoShape محدد كإطار
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # يحدد نوع تعبئة الشكل
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # يحدد وضع تعبئة صورة الشكل
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # يحدد الصورة لتعبئة الشكل
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # يحدد انزياحات الصورة من الحافة المقابلة لصندوق الشكل
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