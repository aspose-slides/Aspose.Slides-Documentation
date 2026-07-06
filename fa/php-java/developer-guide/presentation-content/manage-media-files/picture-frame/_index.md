---
title: مدیریت قاب‌های تصویر در ارائه‌ها با استفاده از PHP
linktitle: قاب تصویر
type: docs
weight: 10
url: /fa/php-java/picture-frame/
keywords:
- قاب تصویر
- افزودن قاب تصویر
- ایجاد قاب تصویر
- افزودن تصویر
- ایجاد تصویر
- استخراج تصویر
- تصویر رستر
- تصویر برداری
- برش تصویر
- ناحیه برش‌خورده
- ویژگی StretchOff
- قالب‌بندی قاب تصویر
- ویژگی‌های قاب تصویر
- مقیاس نسبی
- اثر تصویر
- نسبت ابعاد
- شفافیت تصویر
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "قاب‌های تصویر را به ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای PHP از طریق Java اضافه کنید. جریان کاری خود را به‌صورت ساده کنید و طراحی اسلایدها را بهبود ببخشید."
---
## **مقدمه**

قاب تصویر یک شکل است که یک تصویر را در بر می‌گیرد—مانند یک تصویر درون قاب. 

می‌توانید یک تصویر را از طریق یک قاب تصویر به اسلاید اضافه کنید. به این ترتیب می‌توانید تصویر را با قالب‌بندی قاب تصویر قالب‌بندی کنید.

{{% alert  title="Tip" color="primary" %}} 

Aspose مبدل‌های رایگانی—[JPEG to PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG to PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—ارائه می‌دهد که به کاربران امکان می‌دهد به سرعت از تصاویر ارائه‌ها (پرزنتیشن) را ایجاد کنند. 

{{% /alert %}} 

## **ایجاد یک قاب تصویر**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک شیء [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) با افزودن یک تصویر به [ImageCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagecollection/) مربوط به شیء ارائه که برای پر کردن شکل استفاده می‌شود، ایجاد کنید.  
4. عرض و ارتفاع تصویر را مشخص کنید.  
5. یک [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) بر اساس عرض و ارتفاع تصویر از طریق متد `addPictureFrame` که توسط شیء shape مربوط به اسلاید مرجع ارائه می‌شود، ایجاد کنید.  
6. قاب تصویر (حاوی تصویر) را به اسلاید اضافه کنید.  
7. ارائه‌ی تغییر یافته را به عنوان فایل PPTX بنویسید.  

این کد PHP نشان می‌دهد چگونه یک قاب تصویر ایجاد کنید:

```php
  # یک نمونه از کلاس Presentation که نمایانگر یک فایل PPTX است
  $pres = new Presentation();
  try {
    # دریافت اولین اسلاید
    $sld = $pres->getSlides()->get_Item(0);
    # یک نمونه از کلاس Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # یک قاب تصویر با ارتفاع و عرض معادل تصویر اضافه می‌کند
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # نوشتن فایل PPTX به دیسک
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 

قاب‌های تصویر به شما امکان می‌دهند به سرعت اسلایدهای ارائه مبتنی بر تصاویر ایجاد کنید. وقتی قاب تصویر را با گزینه‌های ذخیره Aspose.Slides ترکیب می‌کنید، می‌توانید عملیات ورودی/خروجی را برای تبدیل تصاویر از یک فرمت به فرمت دیگر کنترل کنید. ممکن است این صفحات برای شما مفید باشند: تبدیل [image to JPG](https://products.aspose.com/slides/fa/php-java/conversion/image-to-jpg/); تبدیل [JPG to image](https://products.aspose.com/slides/fa/php-java/conversion/jpg-to-image/); تبدیل [JPG to PNG](https://products.aspose.com/slides/fa/php-java/conversion/jpg-to-png/), تبدیل [PNG to JPG](https://products.aspose.com/slides/fa/php-java/conversion/png-to-jpg/); تبدیل [PNG to SVG](https://products.aspose.com/slides/fa/php-java/conversion/png-to-svg/), تبدیل [SVG to PNG](https://products.aspose.com/slides/fa/php-java/conversion/svg-to-png/). 

{{% /alert %}}

## **ایجاد یک قاب تصویر با مقیاس نسبی**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک تصویر را به مجموعه تصاویر ارائه اضافه کنید.  
4. یک شیء [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) با افزودن یک تصویر به [ImageCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagecollection/) مربوط به شیء ارائه که برای پر کردن شکل استفاده می‌شود، ایجاد کنید.  
5. عرض و ارتفاع نسبی تصویر را در قاب تصویر مشخص کنید.  
6. ارائه‌ی تغییر یافته را به عنوان فایل PPTX بنویسید.  

این کد PHP نشان می‌دهد چگونه یک قاب تصویر با مقیاس نسبی ایجاد کنید:

```php
  # یک نمونه از کلاس Presentation که نمایانگر PPTX است
  $pres = new Presentation();
  try {
    # دریافت اولین اسلاید
    $sld = $pres->getSlides()->get_Item(0);
    # یک نمونه از کلاس Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # اضافه کردن Picture Frame با ارتفاع و عرض معادل تصویر
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # تنظیم مقیاس نسبی عرض و ارتفاع
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # نوشتن فایل PPTX به دیسک
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **استخراج تصاویر رستر از قاب‌های تصویر**

می‌توانید تصاویر رستر را از اشیاء [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) استخراج کرده و در فرمت‌های PNG، JPG و دیگر فرمت‌ها ذخیره کنید. مثال کد زیر نشان می‌دهد چگونه یک تصویر را از سند «sample.pptx» استخراج کرده و در فرمت PNG ذخیره کنید.

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

## **استخراج تصاویر SVG از قاب‌های تصویر**

هنگامی که یک ارائه شامل گرافیک‌های SVG باشد که درون اشکال [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) قرار گرفته‌اند، Aspose.Slides برای PHP via Java به شما اجازه می‌دهد تا تصاویر برداری اصلی را با تمام صحت دریافت کنید. با پیمایش مجموعه اشکال اسلاید می‌توانید هر [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) را شناسایی کرده، بررسی کنید آیا [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) زیرین محتوای SVG دارد یا نه، و سپس آن تصویر را به صورت فایل SVG اصلی ذخیره کنید.

مثال کد زیر نشان می‌دهد چگونه یک تصویر SVG را از یک قاب تصویر استخراج کنید:

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

## **دریافت شفافیت یک تصویر**

Aspose.Slides به شما اجازه می‌دهد تا اثر شفافیتی که بر روی یک تصویر اعمال شده است را دریافت کنید. این کد PHP عملیات را نشان می‌دهد:

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

## **دریافت روشنایی و کنتراست یک تصویر**

Aspose.Slides به شما اجازه می‌دهد تا اثر روشنایی و کنتراست که بر روی یک تصویر اعمال شده است را دریافت کنید. کلاس [Luminance](https://reference.aspose.com/slides/fa/php-java/aspose.slides/luminance/) این اثر تبدیل تصویر را نشان می‌دهد.

این کد PHP نشان می‌دهد چگونه تنظیمات روشنایی و کنتراست را از یک قاب تصویر دریافت کنید:

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

## **قالب‌بندی قاب تصویر**

Aspose.Slides گزینه‌های قالب‌بندی متعددی را برای اعمال بر روی یک قاب تصویر فراهم می‌کند. با استفاده از این گزینه‌ها می‌توانید قاب تصویر را طوری تغییر دهید که با نیازهای خاص سازگار باشد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک شیء [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) با افزودن یک تصویر به [ImageCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagecollection/) مربوط به شیء ارائه که برای پر کردن شکل استفاده می‌شود، ایجاد کنید.  
4. عرض و ارتفاع تصویر را مشخص کنید.  
5. یک `PictureFrame` بر اساس عرض و ارتفاع تصویر از طریق متد [addPictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/addpictureframe/) که توسط شیء [ShapeCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/) مربوط به اسلاید مرجع ارائه می‌شود، ایجاد کنید.  
6. قاب تصویر (حاوی تصویر) را به اسلاید اضافه کنید.  
7. رنگ خط قاب تصویر را تنظیم کنید.  
8. عرض خط قاب تصویر را تنظیم کنید.  
9. قاب تصویر را با مقدار مثبت یا منفی چرخانده کنید.  
   * مقدار مثبت تصویر را در جهت ساعتگرد می‌چرخاند.  
   * مقدار منفی تصویر را در جهت پادساعتگرد می‌چرخاند.  
10. قاب تصویر (حاوی تصویر) را به اسلاید اضافه کنید.  
11. ارائه‌ی تغییر یافته را به عنوان فایل PPTX بنویسید.  

این کد PHP فرآیند قالب‌بندی قاب تصویر را نشان می‌دهد:

```php
  # یک نمونه از کلاس Presentation که نمایانگر PPTX است
  $pres = new Presentation();
  try {
    # دریافت اولین اسلاید
    $sld = $pres->getSlides()->get_Item(0);
    # یک نمونه از کلاس Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # یک قاب تصویر با ارتفاع و عرض معادل تصویر اضافه می‌کند
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # اعمال برخی قالب‌بندی‌ها به PictureFrameEx
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # نوشتن فایل PPTX به دیسک
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tip" color="primary" %}}

Aspose اخیراً یک [Collage Maker رایگان](https://products.aspose.app/slides/fa/collage) توسعه داده است. اگر نیاز دارید [JPG/JPEG را ادغام کنید](https://products.aspose.app/slides/fa/collage/jpg) یا تصاویر PNG، [شبکه‌ای از عکس‌ها بسازید](https://products.aspose.app/slides/fa/collage/photo-grid)، می‌توانید از این سرویس استفاده کنید. 

{{% /alert %}}

## **اضافه کردن تصویر به عنوان لینک**

برای جلوگیری از بزرگ شدن اندازه ارائه، می‌توانید تصاویر (یا ویدیوها) را از طریق لینک اضافه کنید به جای اینکه فایل‌ها را مستقیماً در ارائه جاسازی کنید. این کد PHP نشان می‌دهد چگونه یک تصویر و ویدیو را در یک placeholder اضافه کنید:

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

## **برش تصاویر**

این کد PHP نشان می‌دهد چگونه یک تصویر موجود بر روی اسلاید را برش دهید:

```php
  $pres = new Presentation();
  # ایجاد شیء تصویر جدید
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
    # اضافه کردن یک PictureFrame به یک اسلاید
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # برش تصویر (مقدارهای درصدی)
    $picFrame->getPictureFormat()->setCropLeft(23.6);
    $picFrame->getPictureFormat()->setCropRight(21.5);
    $picFrame->getPictureFormat()->setCropTop(3);
    $picFrame->getPictureFormat()->setCropBottom(31);
    # ذخیره نتیجه
    $pres->save($outPptxFile, SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **حذف نواحی برش‌خورده یک تصویر**

اگر می‌خواهید نواحی برش‌خورده یک تصویر موجود در یک قاب را حذف کنید، می‌توانید از متد [deletePictureCroppedAreas()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) استفاده کنید. این متد تصویر برش‌خورده یا تصویر اصلی را در صورتی که برش لازم نباشد، بر می‌گرداند.

این کد PHP عملیات را نشان می‌دهد:

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # دریافت PictureFrame از اسلاید نخست
    $picFrame = $slide->getShapes()->get_Item(0);
    # حذف نواحی برش‌خورده تصویر PictureFrame و بازگرداندن تصویر برش‌خورده
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # ذخیره نتیجه
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 

متد [deletePictureCroppedAreas()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) تصویر برش‌خورده را به مجموعه تصاویر ارائه اضافه می‌کند. اگر تصویر تنها در [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) پردازش‌شده استفاده شود، این تنظیم می‌تواند حجم ارائه را کاهش دهد. در غیر این صورت، تعداد تصاویر در ارائه نهایی افزایش می‌یابد.

این متد در عملیات برش، فایل‌های متا‌فایل WMF/EMF را به تصویر PNG رستری تبدیل می‌کند. 

{{% /alert %}}

## **فشرده‌سازی تصاویر**

می‌توانید یک تصویر موجود در یک ارائه را با استفاده از متد [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) فشرده کنید. این متد تصویر را با کاهش اندازه بر پایه اندازه شکل و وضوح تعیین‌شده فشرده می‌کند و گزینه حذف نواحی برش‌خورده را نیز داراست.

این کار به‌صورت مشابه ویژگی **Picture Format -> Compress Pictures -> Resolution** در PowerPoint تنظیم می‌شود.

مثال‌های PHP زیر نشان می‌دهند چگونه با تعیین وضوح هدف و حذف اختیاری نواحی برش‌خورده، یک تصویر را در یک ارائه فشرده کنید:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # فشرده‌سازی تصویر با وضوح هدف 150 DPI (وضوح وب) و حذف نواحی برش‌خورده.
    $result = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);

    # بررسی نتیجه فشرده‌سازی.
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

یا با استفاده مستقیم از مقدار DPI دلخواه:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # فشرده‌سازی تصویر به 150 DPI (وضوح وب)، حذف نواحی برش‌خورده.
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

این متد تصویر را بر پایه اندازه شکل و DPI ارائه شده به وضوح پایین‌تری تبدیل می‌کند. نواحی برش‌خورده نیز می‌توانند برای بهینه‌سازی حجم فایل حذف شوند.  
اگر تصویر یک متا‌فایل (WMF/EMF) یا SVG باشد، فشرده‌سازی اعمال نمی‌شود. همچنین، کیفیت JPEG بر پایه وضوح حفظ یا کمی کاهش می‌یابد، مشابه کاری که PowerPoint با JPEGهای با وضوح بالا انجام می‌دهد. 

{{% /alert %}}

## **قفل کردن نسبت عرض به ارتفاع**

اگر می‌خواهید شکلی که شامل یک تصویر است حتی پس از تغییر ابعاد تصویر، نسبت عرض به ارتفاع خود را حفظ کند، می‌توانید از متد [setAspectRatioLocked](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) برای تنظیم ویژگی *Lock Aspect Ratio* استفاده کنید.

این کد PHP نشان می‌دهد چگونه نسبت عرض به ارتفاع یک شکل را قفل کنید:

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
    # تنظیم شکل برای حفظ نسبت عرض به ارتفاع هنگام تغییر اندازه
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 

این تنظیم *Lock Aspect Ratio* فقط نسبت عرض به ارتفاع شکل را حفظ می‌کند و نه تصویری که درون آن قرار دارد. 

{{% /alert %}}

## **استفاده از ویژگی StretchOff**

با استفاده از متدهای [setStretchOffsetLeft](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/)، [setStretchOffsetTop](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/setstretchoffsettop/)، [setStretchOffsetRight](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) و [setStretchOffsetBottom](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) از کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/)، می‌توانید یک مستطیل پر کردن تعیین کنید.

هنگامی که کشش برای یک تصویر مشخص می‌شود، یک مستطیل منبع به منظور متناسب شدن با مستطیل پر کردن تعریف‌شده مقیاس می‌شود. هر لبه از مستطیل پر کردن توسط درصدی از لبه متناظر جعبه محاطی شکل تعریف می‌شود. درصد مثبت یک تو رفتگی و درصد منفی یک خروجی را نشان می‌دهد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک مستطیل `AutoShape` اضافه کنید.  
4. یک تصویر ایجاد کنید.  
5. نوع پر کردن شکل را تنظیم کنید.  
6. حالت پر کردن تصویر شکل را تنظیم کنید.  
7. تصویر تنظیم‌شده را برای پر کردن شکل اضافه کنید.  
8. افست‌های تصویر را از لبه‌های متناظر جعبه محاطی شکل مشخص کنید.  
9. ارائه‌ی تغییر یافته را به عنوان فایل PPTX بنویسید.  

این کد PHP نشان می‌دهد که چگونه از ویژگی StretchOff استفاده شود:

```php
  # یک نمونه از کلاس Presentation که نمایانگر یک فایل PPTX است
  $pres = new Presentation();
  try {
    # دریافت اولین اسلاید
    $slide = $pres->getSlides()->get_Item(0);
    # یک نمونه از کلاس ImageEx
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # افزودن AutoShape به شکل Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # تنظیم نوع پر شدن شکل
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # تنظیم حالت پر کردن تصویر برای شکل
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # تنظیم تصویر برای پر کردن شکل
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # مشخص کردن افست‌های تصویر از لبه متناظر جعبه محاطی شکل
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # نوشتن فایل PPTX به دیسک
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سؤالات متداول**

**چگونه می‌توانم بفهمم چه فرمت‌های تصویری برای PictureFrame پشتیبانی می‌شوند؟**

Aspose.Slides هر دو نوع تصویر رستری (PNG, JPEG, BMP, GIF و غیره) و تصاویر برداری (مثلاً SVG) را از طریق شیء تصویری که به یک [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) اختصاص داده می‌شود، پشتیبانی می‌کند. فهرست فرمت‌های پشتیبانی‌شده عموماً با توانایی‌های موتور تبدیل اسلاید و تصویر همپوشانی دارد.

**اضافه‌کردن ده‌ها تصویر بزرگ چه تأثیری بر اندازه و عملکرد فایل PPTX دارد؟**

جاسازی تصاویر بزرگ حجم فایل و استفاده از حافظه را افزایش می‌دهد؛ لینک کردن تصاویر به کاهش حجم ارائه کمک می‌کند اما فایل‌های خارجی باید در دسترس بمانند. Aspose.Slides امکان افزودن تصویر به‌صورت لینک را برای کاهش حجم فایل فراهم می‌کند.

**چگونه می‌توانم یک شیء تصویری را از جابجایی/تغییر اندازه تصادفی قفل کنم؟**

از [قفل‌های شکل](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/getpictureframelock/) برای یک [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) استفاده کنید (مثلاً غیر فعال کردن جابجایی یا تغییر اندازه). این مکانیزم قفل‌گذاری برای انواع مختلف شکل‌ها، از جمله [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) پشتیبانی می‌شود.

**آیا صحت برداری SVG هنگام خروجی‌گیری ارائه به PDF/تصاویر حفظ می‌شود؟**

Aspose.Slides اجازه می‌دهد تا یک SVG را از یک [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) به‌عنوان بردار اصلی استخراج کنید. هنگام [خروجی‌گیری به PDF](/slides/fa/php-java/convert-powerpoint-to-pdf/) یا [فرمت‌های رستری](/slides/fa/php-java/convert-powerpoint-to-png/)، نتیجه ممکن است بسته به تنظیمات خروجی به صورت رستری شود؛ اما این که SVG اصلی به‌صورت بردار ذخیره شده است، توسط رفتار استخراج تأیید می‌شود.