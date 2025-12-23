---
title: تحسين إدارة الصور في العروض التقديمية باستخدام PHP
linktitle: إدارة الصور
type: docs
weight: 10
url: /ar/php-java/image/
keywords:
- إضافة صورة
- إضافة صورة
- إضافة صورة نقطية
- استبدال صورة
- استبدال صورة
- من الويب
- خلفية
- إضافة PNG
- إضافة JPG
- إضافة SVG
- إضافة EMF
- إضافة WMF
- إضافة TIFF
- PowerPoint
- OpenDocument
- عرض تقديمي
- EMF
- SVG
- PHP
- Aspose.Slides
description: "تبسيط إدارة الصور في PowerPoint وOpenDocument باستخدام Aspose.Slides للـ PHP عبر Java، مع تحسين الأداء وأتمتة سير العمل الخاص بك."
---

## **الصور في شرائح العرض**

تجعل الصور العروض التقديمية أكثر جاذبية وإثارة للاهتمام. في Microsoft PowerPoint، يمكنك إدراج الصور من ملف أو من الإنترنت أو من مواقع أخرى على الشرائح. وبالمثل، يتيح لك Aspose.Slides إضافة الصور إلى شرائح في عروضك التقديمية عبر إجراءات مختلفة. 

{{% alert  title="Tip" color="primary" %}} 

توفر Aspose محولات مجانية—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—تتيح للناس إنشاء عروض تقديمية بسرعة من الصور. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

إذا كنت ترغب في إضافة صورة ككائن إطار—وخاصة إذا كنت تخطط لاستخدام خيارات تنسيق قياسية لتغيير حجمها، وإضافة تأثيرات، وما إلى ذلك—انظر إلى [Picture Frame](https://docs.aspose.com/slides/php-java/picture-frame/).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

يمكنك التعامل مع عمليات الإدخال/الإخراج المتعلقة بالصور وعروض PowerPoint لتحويل صورة من تنسيق إلى آخر. راجع الصفحات التالية: تحويل [image to JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); تحويل [JPG to image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); تحويل [JPG to PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), تحويل [PNG to JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); تحويل [PNG to SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), تحويل [SVG to PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).

{{% /alert %}}

يدعم Aspose.Slides عمليات التعامل مع الصور بهذه الصيغ الشائعة: JPEG، PNG، GIF، وغيرها. 

## **إضافة صور مخزنة محليًا إلى الشرائح**

يمكنك إضافة صورة واحدة أو عدة صور من جهازك إلى شريحة في العرض التقديمي. يوضح لك هذا المثال البرمجي كيفية إضافة صورة إلى شريحة:
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

إذا كانت الصورة التي تريد إضافتها إلى شريحة غير متوفرة على جهازك، يمكنك إضافة الصورة مباشرة من الويب. 

يُظهر لك هذا المثال البرمجي كيفية إضافة صورة من الويب إلى شريحة :
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $imageUrl = new URL("[REPLACE WITH URL]");
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

الشريحة الرئيسية هي الشريحة العلوية التي تخزن وتتحكم في المعلومات (السمة، التخطيط، إلخ) لجميع الشرائح التي تحتها. لذا، عندما تضيف صورة إلى الشريحة الرئيسية، تظهر تلك الصورة على كل شريحة تحتها. 

يُظهر لك هذا المثال البرمجي بلغة Java كيفية إضافة صورة إلى الشريحة الرئيسية:
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


## **إضافة صور كخلفيات للشرائح**

قد تقرر استخدام صورة كخلفية لشريحة معينة أو لعدة شرائح. في هذه الحالة، عليك الاطلاع على *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/php-java/presentation-background/#setting-images-as-background-for-slides)*.

## **إضافة SVG إلى العروض التقديمية**
يمكنك إضافة أو إدراج أي صورة في عرض تقديمي باستخدام طريقة [addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) التي تنتمي إلى واجهة [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).

لإنشاء كائن صورة بناءً على صورة SVG، يمكنك فعل ذلك بهذه الطريقة:

1. إنشاء كائن SvgImage لإدراجه في ImageShapeCollection
2. إنشاء كائن PPImage من ISvgImage
3. إنشاء كائن PictureFrame باستخدام واجهة IPPImage

يُظهر لك هذا المثال البرمجي كيفية تنفيذ الخطوات أعلاه لإضافة صورة SVG إلى عرض تقديمي:
```php
  # إنشاء فئة Presentation التي تمثل ملف PPTX
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
تحويل Aspose.Slides من SVG إلى مجموعة من الأشكال مشابه للوظيفة الموجودة في PowerPoint للتعامل مع صور SVG:

![PowerPoint Popup Menu](img_01_01.png)

توفر هذه الميزة أحد التحميلات الزائدة لطريقة [addGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) في واجهة [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) التي تستقبل كائن [ISvgImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISvgImage) كمعامل أول.

يُظهر لك هذا المثال البرمجي كيفية استخدام الطريقة الموصوفة لتحويل ملف SVG إلى مجموعة من الأشكال:
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
    # تحويل صورة SVG إلى مجموعة من الأشكال مع تحجيمها إلى حجم الشريحة
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


## **إضافة صور كـ EMF إلى الشرائح**
يتيح لك Aspose.Slides for PHP via Java إنشاء صور EMF من جداول Excel وإضافة الصور كـ EMF في الشرائح باستخدام Aspose.Cells. 

يُظهر لك هذا المثال البرمجي كيفية تنفيذ المهمة الموصوفة:
```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # احفظ دفتر العمل إلى التدفق
  $sr = new SheetRender($sheet, $options);
  $pres = new Presentation();
  try {
    $pres->getSlides()->removeAt(0);
    $EmfSheetName = "";
    for($j = 0; $j < java_values($sr->getPageCount()) ; $j++) {
      $EmfSheetName = "test" . $sheet->getName() . " Page" . $j + 1 . ".out.emf";
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


## **استبدال الصور في مجموعة الصور**

Aspose.Slides يتيح لك استبدال الصور المخزنة في مجموعة صور العرض التقديمي (بما في ذلك تلك المستخدمة بواسطة أشكال الشرائح). يوضح هذا القسم عدة أساليب لتحديث الصور في المجموعة. توفر الـ API طرقًا مباشرة لاستبدال صورة باستخدام بيانات بايت خام، أو مثال [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/)، أو صورة أخرى موجودة بالفعل في المجموعة.

1. تحميل ملف العرض التقديمي الذي يحتوي على الصور باستخدام الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. تحميل صورة جديدة من ملف إلى مصفوفة بايت.
3. استبدال الصورة المستهدفة بالصورة الجديدة باستخدام مصفوفة البايت.
4. في النهج الثاني، تحميل الصورة إلى كائن [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) واستبدال الصورة المستهدفة بذلك الكائن.
5. في النهج الثالث، استبدال الصورة المستهدفة بصورة موجودة بالفعل في مجموعة صور العرض التقديمي.
6. كتابة العرض التقديمي المعدل كملف PPTX.
```php
// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation("sample.pptx");
try {
    // الطريقة الأولى.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new Java("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // الطريقة الثانية.
    $newImage = Images::fromFile("image1.png");
    $oldImage = $presentation->getImages()->get_Item(1);
    $oldImage->replaceImage($newImage);
    $newImage->dispose();
    
    // الطريقة الثالثة.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));
    
    // حفظ العرض التقديمي إلى ملف.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


{{% alert title="Info" color="info" %}}

باستخدام محول Aspose FREE [Text to GIF](https://products.aspose.app/slides/text-to-gif) يمكنك بسهولة تحريك النصوص، إنشاء GIFs من النصوص، إلخ. 

{{% /alert %}}

## **الأسئلة المتكررة**

**هل يبقى دقة الصورة الأصلية سليمة بعد الإدراج؟**

نعم. تُحفظ بكسلات المصدر، لكن المظهر النهائي يعتمد على كيفية مقاس [picture](/slides/ar/php-java/picture-frame/) على الشريحة وأي ضغط يُطبق عند الحفظ.

**ما هي أفضل طريقة لاستبدال الشعار نفسه عبر عشرات الشرائح دفعة واحدة؟**

ضع الشعار على الشريحة الرئيسية أو على أحد التخطيطات واستبدله في مجموعة صور العرض التقديمي—ستنتشر التحديثات إلى جميع العناصر التي تستخدم هذا المورد.

**هل يمكن تحويل SVG المدخَل إلى أشكال قابلة للتحرير؟**

نعم. يمكنك تحويل SVG إلى مجموعة من الأشكال، وبعد ذلك تصبح الأجزاء الفردية قابلة للتحرير باستخدام خصائص الشكل القياسية.

**كيف يمكنني تعيين صورة كخلفية لعدة شرائح في آن واحد؟**

[Assign the image as the background](/slides/ar/php-java/presentation-background/) على الشريحة الرئيسية أو التخطيط المعني—أي شرائح تستخدم تلك الشريحة/التخطيط ستحصل على الخلفية.

**كيف أمنع انفجار حجم العرض التقديمي بسبب كثرة الصور؟**

أعد استخدام مصدر صورة واحد بدلًا من النسخ المتعددة، اختر دقة معقولة، طبق الضغط عند الحفظ، واحتفظ بالرسوم المتكررة على الشريحة الرئيسية حيث يناسب.