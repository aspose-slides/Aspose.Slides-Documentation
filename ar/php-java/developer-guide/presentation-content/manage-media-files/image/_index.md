---
title: صورة
type: docs
weight: 10
url: /ar/php-java/image/
description: العمل مع الصور في الشرائح في عرض باوربوينت باستخدام PHP. إضافة الصور من القرص أو من الإنترنت إلى الشرائح في باوربوينت باستخدام PHP. إضافة الصور إلى شريحة رئيسية أو كخلفية شريحة باستخدام PHP. إضافة SVG إلى عرض باوربوينت باستخدام PHP. تحويل SVG إلى أشكال في باوربوينت باستخدام PHP. إضافة الصور كـ EMF في الشرائح باستخدام PHP.
---

## **الصور في الشرائح في العروض التقديمية**

تجعل الصور العروض التقديمية أكثر جاذبية واهتمامًا. في مايكروسوفت باوربوينت، يمكنك إدراج الصور من ملف أو الإنترنت أو مواقع أخرى إلى الشرائح. وبالمثل، يتيح لك Aspose.Slides إضافة الصور إلى الشرائح في عروضك التقديمية من خلال إجراءات مختلفة.

{{% alert title="نصيحة" color="primary" %}} 

يوفر Aspose محولات مجانية—[JPEG إلى باوربوينت](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى باوربوينت](https://products.aspose.app/slides/import/png-to-ppt)—تتيح للناس إنشاء عروض تقديمية بسرعة من الصور. 

{{% /alert %}} 

{{% alert title="معلومات" color="info" %}}

إذا كنت ترغب في إضافة صورة ككائن إطاري—خاصة إذا كنت تخطط لاستخدام خيارات التنسيق القياسية عليها لتغيير حجمها، وإضافة تأثيرات، وما إلى ذلك—راجع [إطار الصورة](https://docs.aspose.com/slides/php-java/picture-frame/).

{{% /alert %}} 

{{% alert title="ملاحظة" color="warning" %}}

يمكنك معالجة عمليات الإدخال/الإخراج التي تتعلق بالصور والعروض التقديمية باوربوينت لتحويل صورة من تنسيق إلى آخر. راجع هذه الصفحات: تحويل [صورة إلى JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/)؛ تحويل [JPG إلى صورة](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/)؛ تحويل [JPG إلى PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/)؛ تحويل [PNG إلى JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/)؛ تحويل [PNG إلى SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/)؛ تحويل [SVG إلى PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).

{{% /alert %}}

يدعم Aspose.Slides العمليات مع الصور في هذه التنسيقات الشائعة: JPEG، PNG، GIF، وغيرها.

## **إضافة صور مخزنة محليًا إلى الشرائح**

يمكنك إضافة صورة واحدة أو عدة صور من جهاز الكمبيوتر الخاص بك إلى شريحة في عرض تقديمي. هذا الكود النموذجي يوضح لك كيفية إضافة صورة إلى شريحة:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إضافة صور من الويب إلى الشرائح**

إذا كانت الصورة التي تريد إضافتها إلى شريحة غير متاحة على جهاز الكمبيوتر الخاص بك، يمكنك إضافة الصورة مباشرة من الويب.

هذا الكود النموذجي يوضح لك كيفية إضافة صورة من الويب إلى شريحة:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $imageUrl = new URL("[استبدل بعنوان URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new java_class("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    try {
      $buffer = $Array->newInstance($Byte, 1024);
      $read;
      while ($read = $inputStream->read($buffer, 0, $Array->getLength($buffer)) != -1) {
        $outputStream->write($buffer, 0, $read);
      } 
      $outputStream->flush();
      $image = $pres->getImages()->addImage($outputStream->toByteArray());
      $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
      if (!java_is_null($inputStream)) {
        $inputStream->close();
      }
      $outputStream->close();
    }
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إضافة صور إلى الشريحة الرئيسية**

الشريحة الرئيسية هي الشريحة العليا التي تخزن وتتحكم في المعلومات (الثيم، التخطيط، إلخ) حول جميع الشرائح التي تندرج تحتها. لذلك، عندما تضيف صورة إلى شريحة رئيسية، ستظهر تلك الصورة في كل شريحة تحت تلك الشريحة الرئيسية.

هذا الكود التجريبي يوضح لك كيفية إضافة صورة إلى شريحة رئيسية:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إضافة صور كخلفية للشريحة**

يمكنك أن تقرر استخدام صورة كخلفية لشريحة معينة أو عدة شرائح. في هذه الحالة، عليك أن ترى *[تعيين الصور كخلفيات للشرائح](https://docs.aspose.com/slides/php-java/presentation-background/#setting-images-as-background-for-slides)*.

## **إضافة SVG إلى العروض التقديمية**
يمكنك إضافة أو إدراج أي صورة في عرض تقديمي باستخدام الطريقة [addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) التي تنتمي إلى واجهة [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).

لإنشاء كائن صورة بناءً على صورة SVG، يمكنك القيام بذلك على هذا النحو:

1. إنشاء كائن SvgImage لإدراجه في مجموعة ImageShapeCollection
2. إنشاء كائن PPImage من ISvgImage
3. إنشاء كائن PictureFrame باستخدام واجهة IPPImage

هذا الكود النموذجي يوضح لك كيفية تنفيذ الخطوات المذكورة أعلاه لإضافة صورة SVG إلى عرض تقديمي:
```php
  # إنشاء كلاس Presentation الذي يمثل ملف PPTX
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = new String($bytes);

    $svgImage = new SvgImage($svgContent);
    $ppImage = $pres->getImages()->addImage($svgImage);
    $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تحويل SVG إلى مجموعة من الأشكال**
يشبه تحويل Aspose.Slides لـ SVG إلى مجموعة من الأشكال الوظيفة المستخدمة في باوربوينت للعمل مع صور SVG:

![قائمة منبثقة باوربوينت](img_01_01.png)

تقدم الوظيفة بواسطة أحد التحميلات الزائدة لطريقة [addGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) من واجهة [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) التي تأخذ كائن [ISvgImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISvgImage) كأول وسيط.

هذا الكود التجريبي يوضح لك كيفية استخدام الطريقة الموصوفة لتحويل ملف SVG إلى مجموعة من الأشكال:

```php
  # إنشاء عرض تقديمي جديد
  $presentation = new Presentation();
  try {
    # قراءة محتوى ملف SVG
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = $bytes;

    # إنشاء كائن SvgImage
    $svgImage = new SvgImage($svgContent);
    # الحصول على حجم الشريحة
    $slideSize = $presentation->getSlideSize()->getSize();
    # تحويل صورة SVG إلى مجموعة من الأشكال مع توسيعها لتناسب حجم الشريحة
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape($svgImage, 0.0, 0.0, $slideSize->getWidth(), $slideSize->getHeight());
    # حفظ العرض التقديمي بصيغة PPTX
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **إضافة صور كـ EMF في الشرائح**
يتيح لك Aspose.Slides لـ PHP عبر Java إنتاج صور EMF من جداول البيانات وإضافة الصور كـ EMF في الشرائح باستخدام Aspose.Cells. 

هذا الكود النموذجي يوضح لك كيفية القيام بالمهمة الموصوفة:

```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # حفظ دفتر العمل إلى تيار
  $sr = new SheetRender($sheet, $options);
  $pres = new Presentation();
  try {
    $pres->getSlides()->removeAt(0);
    $EmfSheetName = "";
    for($j = 0; $j < java_values($sr->getPageCount()) ; $j++) {
      $EmfSheetName = "test" . $sheet->getName() . " صفحة" . $j + 1 . ".out.emf";
      $sr->toImage($j, $EmfSheetName);
      $picture;
      $image = Images->fromFile($EmfSheetName);
      try {
        $picture = $pres->getImages()->addImage($image);
      } finally {
        if (!java_is_null($image)) {
          $image->dispose();
        }
      }
      $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
      $m = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $pres->getSlideSize()->getSize()->getWidth(), $pres->getSlideSize()->getSize()->getHeight(), $picture);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="معلومات" color="info" %}}

باستخدام محول Aspose المجاني [النص إلى GIF](https://products.aspose.app/slides/text-to-gif)، يمكنك بسهولة تحريك النصوص، وإنشاء GIFs من النصوص، وما إلى ذلك. 

{{% /alert %}}