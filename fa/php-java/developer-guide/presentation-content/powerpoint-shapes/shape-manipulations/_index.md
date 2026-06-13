---
title: مدیریت اشکال ارائه در PHP
linktitle: دستکاری اشکال
type: docs
weight: 40
url: /fa/php-java/shape-manipulations/
keywords:
- اشکال PowerPoint
- اشکال ارائه
- اشکال روی اسلاید
- پیدا کردن اشکال
- کلون کردن اشکال
- حذف اشکال
- مخفی کردن اشکال
- تغییر ترتیب اشکال
- دریافت شناسه Interop Shape
- متن جایگزین اشکال
- فرمت‌های چیدمان اشکال
- اشکال به صورت SVG
- اشکال به SVG
- تراز کردن اشکال
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال را در Aspose.Slides برای PHP از طریق Java ایجاد، ویرایش و بهینه‌سازی کنید و ارائه‌های PowerPoint با کارایی بالا ارائه دهید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه با اشکال در ارائه‌ها با استفاده از Aspose.Slides کار کنید. نشان می‌دهد چگونه یک شکل را روی اسلاید پیدا کنید، آن را کلون کنید، حذف کنید، مخفی کنید، ترتیب آن را تغییر دهید، شناسه Interop شکل را دریافت کنید و متن جایگزین برای شناسایی و پردازش‌های بعدی تنظیم کنید.

همچنین نحوه دسترسی به فرمت‌های چیدمان برای اشکال، رندر کردن یک شکل به صورت SVG، تراز کردن اشکال روی اسلاید و استفاده از ویژگی‌های چرخش برای بازتاب افقی و عمودی را پوشش می‌دهد. علاوه بر این، مقاله شامل یک بخش کوتاه FAQ درباره ترکیب اشکال، ترتیب لایه‌بندی و قفل‌کردن شکل است.

## **یافتن یک شکل روی اسلاید**
این موضوع تکنیکی ساده را توصیف می‌کند تا برای توسعه‌دهندگان آسان‌تر شود که یک شکل خاص را روی اسلاید بدون استفاده از شناسه داخلی آن پیدا کنند. مهم است بدانید که فایل‌های ارائه PowerPoint راهی برای شناسایی اشکال روی اسلاید به جز یک شناسه یکتای داخلی ندارند. برای توسعه‌دهندگان پیدا کردن یک شکل با استفاده از شناسه یکتای داخلی آن دشوار به نظر می‌رسد. تمام اشکالی که به اسلایدها اضافه می‌شوند دارای متن Alt هستند. ما به توسعه‌دهندگان پیشنهاد می‌کنیم برای یافتن شکل خاص از متن جایگزین استفاده کنند. می‌توانید از MS PowerPoint برای تعریف متن جایگزین برای اشیائی که قصد تغییر آنها را در آینده دارید، استفاده کنید.

پس از تنظیم متن جایگزین برای هر شکل دلخواه، می‌توانید همان ارائه را با Aspose.Slides برای PHP از طریق Java باز کنید و از طریق تمام اشکال اضافه شده به یک اسلاید عبور کنید. در هر حلقه می‌توانید متن جایگزین شکل را بررسی کنید و شکل دارای متن جایگزین منطبق، همان شکلی خواهد بود که به دنبال آن هستید. برای نمایش بهتر این تکنیک، یک روش به نام [findShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) ایجاد کرده‌ایم که کار پیدا کردن یک شکل خاص در اسلاید را انجام می‌دهد و به سادگی آن شکل را برمی‌گرداند.

```php
  # یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر فایل ارائه است
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # متن جایگزین شکلی که باید پیدا شود
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("Shape Name: " . $shape->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **کلون کردن یک شکل**
برای کلون کردن یک شکل به یک اسلاید با استفاده از Aspose.Slides برای PHP از طریق Java:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
1. مرجع یک اسلاید را با استفاده از ایندکس آن به دست آورید.
1. به مجموعه اشکال اسلاید منبع دسترسی پیدا کنید.
1. اسلاید جدیدی به ارائه اضافه کنید.
1. اشکال را از مجموعه اشکال اسلاید منبع به اسلاید جدید کلون کنید.
1. ارائه اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

مثال زیر یک گروه شکل را به یک اسلاید اضافه می‌کند.

```php
  # یک شیء از کلاس Presentation ایجاد می‌کند
  $pres = new Presentation("Source Frame.pptx");
  try {
    $sourceShapes = $pres->getSlides()->get_Item(0)->getShapes();
    $blankLayout = $pres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destSlide = $pres->getSlides()->addEmptySlide($blankLayout);
    $destShapes = $destSlide->getShapes();
    $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
    $destShapes->addClone($sourceShapes->get_Item(2));
    $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);
    # فایل PPTX را بر روی دیسک ذخیره کنید
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **حذف یک شکل**
Aspose.Slides برای PHP از طریق Java به توسعه‌دهندگان اجازه می‌دهد هر شکل را حذف کنند. برای حذف شکل از هر اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
1. به اولین اسلاید دسترسی پیدا کنید.
1. شکل با متن جایگزین خاص را پیدا کنید.
1. شکل را حذف کنید.
1. فایل را بر روی دیسک ذخیره کنید.

```php
  # ایجاد شیء Presentation
  $pres = new Presentation();
  try {
    # دریافت اولین اسلاید
    $sld = $pres->getSlides()->get_Item(0);
    # افزودن خودشکل از نوع مستطیل
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $altText = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item(0);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $sld->getShapes()->remove($ashp);
      }
    }
    # ذخیره ارائه بر روی دیسک
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **مخفی کردن یک شکل**
Aspose.Slides برای PHP از طریق Java به توسعه‌دهندگان اجازه می‌دهد هر شکل را مخفی کنند. برای مخفی کردن شکل از هر اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
1. به اولین اسلاید دسترسی پیدا کنید.
1. شکل با متن جایگزین خاص را پیدا کنید.
1. شکل را مخفی کنید.
1. فایل را بر روی دیسک ذخیره کنید.

```php
  # یک شیء از کلاس Presentation که نمایانگر PPTX است ایجاد می‌کند
  $pres = new Presentation();
  try {
    # دریافت اولین اسلاید
    $sld = $pres->getSlides()->get_Item(0);
    # افزودن خودشکل از نوع مستطیل
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $alttext = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item($i);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $ashp->setHidden(true);
      }
    }
    # ذخیره ارائه بر روی دیسک
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تغییر ترتیب شکل**
Aspose.Slides برای PHP از طریق Java به توسعه‌دهندگان اجازه می‌دهد ترتیب اشکال را تغییر دهند. تغییر ترتیب مشخص می‌کند کدام شکل در جلو و کدام در عقب قرار گیرد. برای تغییر ترتیب شکل از هر اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
1. به اولین اسلاید دسترسی پیدا کنید.
1. یک شکل اضافه کنید.
1. متنی در فریم متنی شکل اضافه کنید.
1. شکل دیگر را با همان مختصات اضافه کنید.
1. ترتیب اشکال را تغییر دهید.
1. فایل را بر روی دیسک ذخیره کنید.

```php
  $pres = new Presentation("ChangeShapeOrder.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 365, 400, 150);
    $shp3->getFillFormat()->setFillType(FillType::NoFill);
    $shp3->addTextFrame(" ");
    $para = $shp3->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Watermark Text Watermark Text Watermark Text");
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 200, 365, 400, 150);
    $slide->getShapes()->reorder(2, $shp3);
    $pres->save("Reshape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **دریافت شناسه Interop Shape**
Aspose.Slides برای PHP از طریق Java به توسعه‌دهندگان اجازه می‌دهد شناسه یکتای یک شکل را در دامنه اسلاید دریافت کنند، در تضاد با روش [getUniqueId](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getuniqueid/) که شناسه یکتا را در دامنه ارائه برمی‌گرداند. متد [getOfficeInteropShapeId](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getofficeinteropshapeid/) به کلاس [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/) اضافه شده است. مقدار برگردانده‌شده توسط این متد متناظر با مقدار Id شیء Microsoft.Office.Interop.PowerPoint.Shape است. نمونه کد زیر آورده شده است.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # دریافت شناسه یکتای شکل در دامنه اسلاید
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم متن جایگزین برای یک شکل**
Aspose.Slides برای PHP از طریق Java به توسعه‌دهندگان اجازه می‌دهد `AlternateText` هر شکل را تنظیم کنند.
اشکال در ارائه می‌توانند با `Alternative Text` یا روش [Shape Name](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/setname/) متمایز شوند.
متدهای [setAlternativeText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/setalternativetext/) و [getAlternativeText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getalternativetext/) می‌توانند توسط Aspose.Slides و همچنین Microsoft PowerPoint خوانده یا تنظیم شوند.
با استفاده از این روش، می‌توانید یک شکل را برچسب‌گذاری کنید و عملیات‌های مختلفی مانند حذف، مخفی‌کردن یا تغییر ترتیب اشکال روی اسلاید را انجام دهید.
برای تنظیم `AlternateText` یک شکل، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
1. به اولین اسلاید دسترسی پیدا کنید.
1. هر شکلی را به اسلاید اضافه کنید.
1. کاری با شکل اضافه‌شده جدید انجام دهید.
1. از میان اشکال عبور کنید تا شکل مورد نظر را پیدا کنید.
1. `AlternativeText` را تنظیم کنید.
1. فایل را بر روی دیسک ذخیره کنید.

```php
  # یک شیء از کلاس Presentation که نمایانگر PPTX است ایجاد می‌کند
  $pres = new Presentation();
  try {
    # دریافت اولین اسلاید
    $sld = $pres->getSlides()->get_Item(0);
    # افزودن خودشکل از نوع مستطیل
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      $shape = $sld->getShapes()->get_Item($i);
      if (!java_is_null($shape)) {
        $shape->setAlternativeText("User Defined");
      }
    }
    # ذخیره ارائه بر روی دیسک
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **دسترسی به فرمت‌های چیدمان برای یک شکل**
Aspose.Slides برای PHP از طریق Java یک API ساده برای دسترسی به فرمت‌های چیدمان یک شکل فراهم می‌کند. این مقاله نشان می‌دهد چگونه می‌توانید به فرمت‌های چیدمان دسترسی پیدا کنید.

نمونه کد زیر ارائه شده است.

```php
  $pres = new Presentation("pres.pptx");
  try {
    foreach($pres->getLayoutSlides() as $layoutSlide) {
      foreach($layoutSlide->getShapes() as $shape) {
        $fillFormats = $shape->getFillFormat();
        $lineFormats = $shape->getLineFormat();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **رندر کردن یک شکل به صورت SVG**
اکنون Aspose.Slides برای PHP از طریق Java از رندر کردن یک شکل به صورت SVG پشتیبانی می‌کند. متد [writeAsSvg](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/writeassvg/) (و overload آن) به کلاس [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/) اضافه شده است. این متد امکان ذخیره محتوای شکل به عنوان فایل SVG را فراهم می‌کند. قطعه کد زیر نشان می‌دهد چگونه شکل اسلاید را به یک فایل SVG صادر کنید.

```php
  $pres = new Presentation("TestExportShapeToSvg.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "SingleShape.svg");
    try {
      $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->writeAsSvg($stream);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تراز کردن یک شکل**
Aspose.Slides امکان تراز کردن اشکال را یا نسبت به حاشیه‌های اسلاید یا نسبت به یکدیگر فراهم می‌کند. برای این منظور، متد overload شده [SlidesUtil::alignShapes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideutil/alignshapes/) اضافه شده است. enumeration [ShapesAlignmentType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapesalignmenttype/) گزینه‌های تراز ممکن را تعریف می‌کند.

**مثال 1**

کد منبع زیر اشکال با ایندکس‌های 1، 2 و 4 را در طول حاشیه بالایی اسلاید تراز می‌کند.

```php
  $pres = new Presentation("example.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape1 = $slide->getShapes()->get_Item(1);
    $shape2 = $slide->getShapes()->get_Item(2);
    $shape3 = $slide->getShapes()->get_Item(4);
    SlideUtil->alignShapes(ShapesAlignmentType::AlignTop, true, $pres->getSlides()->get_Item(0), array($slide->getShapes()->indexOf($shape1), $slide->getShapes()->indexOf($shape2), $slide->getShapes()->indexOf($shape3) ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**مثال 2**

مثال زیر نشان می‌دهد چگونه کل مجموعه اشکال را نسبت به شکل انتهایی پایین مجموعه تراز کنید.

```php
  $pres = new Presentation("example.pptx");
  try {
    SlideUtil->alignShapes(ShapesAlignmentType::AlignBottom, false, $pres->getSlides()->get_Item(0));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ویژگی‌های Flip**

در Aspose.Slides، کلاس [ShapeFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapeframe/) کنترل بازتاب افقی و عمودی اشکال را از طریق ویژگی‌های `flipH` و `flipV` فراهم می‌کند. هر دو ویژگی از نوع [NullableBool](https://reference.aspose.com/slides/fa/php-java/aspose.slides/nullablebool/) هستند و مقادیر `True` برای بازتاب، `False` برای عدم بازتاب یا `NotDefined` برای استفاده از رفتار پیش‌فرض را می‌پذیرند. این مقادیر از طریق [Frame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#getFrame) شکل قابل دسترسی است.

برای تغییر تنظیمات flip، یک نمونه جدید از [ShapeFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapeframe/) با موقعیت و اندازه فعلی شکل، مقادیر دلخواه برای `flipH` و `flipV` و زاویه دوران ساخته می‌شود. اختصاص این نمونه به [Frame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#getFrame) شکل و ذخیره ارائه، تبدیل‌های بازتابی را اعمال و در فایل خروجی ذخیره می‌کند.

فرض کنید فایلی به نام sample.pptx داریم که اسلاید اول آن شامل یک شکل با تنظیمات پیش‌فرض flip است، همان‌طور که در زیر نشان داده شده است.

![The shape to be flipped](shape_to_be_flipped.png)

کد زیر ویژگی‌های flip فعلی شکل را بازیابی می‌کند و آن را به صورت افقی و عمودی بازتاب می‌دهد.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    // دریافت ویژگی بازتاب افقی شکل.
    $horizontalFlip = $shape->getFrame()->getFlipH();
    echo "Horizontal flip: ", $horizontalFlip, "\n";

    // دریافت ویژگی بازتاب عمودی شکل.
    $verticalFlip = $shape->getFrame()->getFlipV();
    echo "Vertical flip: ", $verticalFlip, "\n";

    $x = $shape->getFrame()->getX();
    $y = $shape->getFrame()->getY();
    $width = $shape->getFrame()->getWidth();
    $height = $shape->getFrame()->getHeight();
    $flipH = NullableBool::True; // بازتاب افقی.
    $flipV = NullableBool::True; // بازتاب افقی.
    $rotation = $shape->getFrame()->getRotation();

    $shape->setFrame(new ShapeFrame($x, $y, $width, $height, $flipH, $flipV, $rotation));

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![The flipped shape](flipped_shape.png)

## **FAQ**

**آیا می‌توانم اشکال (union/intersect/subtract) را روی اسلاید همانند یک ویرایشگر دسکتاپ ترکیب کنم؟**

یک API عملیات Boolean داخلی وجود ندارد. می‌توانید با ساخت طرح دلخواه خود، مثلاً محاسبه هندسه حاصل (از طریق [GeometryPath](https://reference.aspose.com/slides/fa/php-java/aspose.slides/geometrypath/)) و ایجاد یک شکل جدید با این مرز، تقریب بزنید؛ در صورت نیاز، اشکال اصلی را حذف کنید.

**چگونه می‌توانم ترتیب لایه‌بندی (z-order) را کنترل کنم تا یک شکل همیشه «روی بالا» بماند؟**

ترتیب درج/انتقال را در مجموعه [shapes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseslide/#getShapes) اسلاید تغییر دهید. برای نتایج پیش‌بینی‌پذیر، پس از تمام تغییرات دیگر اسلاید، ترتیب z را نهایی کنید.

**آیا می‌توانم یک شکل را «قفل» کنم تا کاربران در PowerPoint نتوانند آن را ویرایش کنند؟**

بله. پرچم‌های حفاظت سطح شکل (مثل قفل انتخاب، جابجایی، تغییر اندازه، ویرایش متن) را تنظیم کنید. در صورت نیاز، محدودیت‌ها را بر روی مستر یا چیدمان اعمال کنید. توجه داشته باشید این محافظت سطح UI است نه یک ویژگی امنیتی؛ برای محافظت قوی‌تر می‌توانید با محدودیت‌های سطح فایل مانند [توصیه‌های فقط‑خواندنی یا گذرواژه‌ها](/slides/fa/php-java/password-protected-presentation/) ترکیب کنید.