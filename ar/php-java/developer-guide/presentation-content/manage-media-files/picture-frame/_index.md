---
title: إدارة إطارات الصورة في العروض التقديمية باستخدام PHP
linktitle: إطار الصورة
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
- تنسيق إطار الصورة
- خصائص إطار الصورة
- مقياس نسبي
- تأثير الصورة
- نسبة العرض إلى الارتفاع
- شفافية الصورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "أضف إطارات الصورة إلى عروض PowerPoint و OpenDocument باستخدام Aspose.Slides لـ PHP عبر Java. سَهل سير العمل وحسّن تصاميم الشرائح."
---
## **المقدمة**

إطار الصورة هو شكل يحتوي على صورة — إنه كالصورة داخل إطار.

يمكنك إضافة صورة إلى شريحة عبر إطار صورة. بهذه الطريقة، يمكنك تنسيق الصورة من خلال تنسيق إطار الصورة.

{{% alert  title="نصيحة" color="primary" %}} 
توفر Aspose محولات مجانية — [JPEG إلى PowerPoint](https://products.aspose.app/slides/ar/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/ar/import/png-to-ppt) — تتيح للناس إنشاء عروض تقديمية بسرعة من الصور. 
{{% /alert %}} 

## **إنشاء إطار صورة**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).  
2. الحصول على مرجع الشريحة عبر فهرسها.  
3. إنشاء كائن [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) بإضافة صورة إلى [ImageCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagecollection/) المرتبط بكائن العرض الذي سيُستخدم لملء الشكل.  
4. تحديد عرض الصورة وارتفاعها.  
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/) بناءً على عرض وارتفاع الصورة عبر طريقة `addPictureFrame` التي يُ exposedها كائن الشكل المرتبط بالشريحة المرجعية.  
6. إضافة إطار صورة (المحتوي على الصورة) إلى الشريحة.  
7. كتابة العرض المعدل كملف PPTX.  

هذا الكود PHP يوضح كيفية إنشاء إطار صورة:

```php
  # يخلق مثالًا من فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يخلق مثالًا من فئة Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # يضيف إطار صورة بالارتفاع والعرض المتطابقين للصورة
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
تسمح إطارات الصورة بإنشاء شرائح عرض بسرعة بناءً على الصور. عند دمج إطار الصورة مع خيارات الحفظ Aspose.Slides، يمكنك التحكم بعمليات الإدخال/الإخراج لتحويل الصور من تنسيق إلى آخر. قد ترغب في الاطلاع على هذه الصفحات: تحويل [صورة إلى JPG](https://products.aspose.com/slides/ar/php-java/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/ar/php-java/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/ar/php-java/conversion/jpg-to-png/)، تحويل [PNG إلى JPG](https://products.aspose.com/slides/ar/php-java/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/ar/php-java/conversion/png-to-svg/)، تحويل [SVG إلى PNG](https://products.aspose.com/slides/ar/php-java/conversion/svg-to-png/). 
{{% /alert %}}

## **إنشاء إطار صورة مع مقياس نسبي**

عن طريق تعديل مقياس الصورة النسبي، يمكنك إنشاء إطار صورة أكثر تعقيدًا.  

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).  
2. الحصول على مرجع الشريحة عبر فهرسها.  
3. إضافة صورة إلى مجموعة صور العرض.  
4. إنشاء كائن [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) بإضافة صورة إلى [ImageCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagecollection/) المرتبط بكائن العرض الذي سيُستخدم لملء الشكل.  
5. تحديد العرض والارتفاع النسبيين للصورة داخل إطار الصورة.  
6. كتابة العرض المعدل كملف PPTX.  

هذا الكود PHP يوضح كيفية إنشاء إطار صورة مع مقياس نسبي:

```php
  # إنشاء فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # احصل على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إنشاء فئة Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # أضف إطار صورة بالارتفاع والعرض المتطابقين للصورة
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # ضبط مقياس العرض والارتفاع النسبي
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # اكتب ملف PPTX إلى القرص
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **استخراج الصور النقطية من إطارات الصورة**

يمكنك استخراج الصور النقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/) وحفظها بصيغ PNG أو JPG وغيرها. يوضح مثال الكود أدناه كيفية استخراج صورة من المستند "sample.pptx" وحفظها بصيغة PNG.

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

عندما يحتوي عرض تقديمي على رسومات SVG موضوعة داخل أشكال [PictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/)، يتيح Aspose.Slides for PHP via Java استرجاع الصور المتجهة الأصلية بدقة كاملة. عن طريق استعراض مجموعة أشكال الشريحة، يمكنك