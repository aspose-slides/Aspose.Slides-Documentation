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
- نسبت عرض به ارتفاع
- شفافیت تصویر
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "قاب‌های تصویر را به ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای PHP از طریق Java اضافه کنید. جریان کاری خود را بهبود بخشید و طراحی اسلایدها را ارتقا دهید."
---
## **مقدمه**

قاب تصویر یک شکل است که تصویری را در خود نگه می‌دارد — همانند یک تصویر در یک قاب.

می‌توانید با استفاده از یک قاب تصویر، تصویر را به اسلاید اضافه کنید. به این ترتیب، می‌توانید تصویر را با قالب‌بندی قاب تصویر فرمت کنید.

{{% alert  title="Tip" color="primary" %}} 
Aspose تبدیل‌کننده‌های رایگان—[JPEG به PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG به PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—را ارائه می‌دهد که به کاربران امکان می‌دهد به سرعت از تصاویر ارائه‌ها را ایجاد کنند. 
{{% /alert %}} 

## **ایجاد یک قاب تصویر**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.  
2. از طریق ایندکس، مرجع یک اسلاید را دریافت کنید.  
3. یک شیء [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) ایجاد کنید با افزودن یک تصویر به [ImageCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagecollection/) مرتبط با شیء presentation که برای پر کردن شکل استفاده می‌شود.  
4. عرض و ارتفاع تصویر را مشخص کنید.  
5. یک [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) بر اساس عرض و ارتفاع تصویر ایجاد کنید از طریق متد `addPictureFrame` که توسط شیء shape مرتبط با اسلاید مرجع ارائه می‌شود.  
6. قاب تصویر (حاوی تصویر) را به اسلاید اضافه کنید.  
7. ارائهٔ تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.  

این کد PHP نشان می‌دهد که چگونه یک قاب تصویر ایجاد کنید:

```php
  # یک نمونه از کلاس Presentation که نمایانگر یک فایل PPTX است ایجاد می‌کند
  $pres = new Presentation();
  try {
    # اسلاید اول را دریافت می‌کند
    $sld = $pres->getSlides()->get_Item(0);
    # یک نمونه از کلاس Image ایجاد می‌کند
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # یک قاب تصویر با ارتفاع و عرض برابر با تصویر اضافه می‌کند
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # فایل PPTX را روی دیسک می‌نویسد
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 
قاب‌های تصویر به شما امکان می‌دهند سریعاً اسلایدهای ارائه را بر پایه تصاویر ایجاد کنید. وقتی قاب تصویر را با گزینه‌های ذخیره Aspose.Slides ترکیب می‌کنید، می‌توانید عملیات ورودی/خروجی را برای تبدیل تصاویر از یک فرمت به فرمت دیگر مدیریت کنید. ممکن است بخواهید این صفحات را ببینید: تبدیل [تصویر به JPG](https://products.aspose.com/slides/fa/php-java/conversion/image-to-jpg/); تبدیل [JPG به تصویر](https://products.aspose.com/slides/fa/php-java/conversion/jpg-to-image/); تبدیل [JPG به PNG](https://products.aspose.com/slides/fa/php-java/conversion/jpg-to-png/)، تبدیل [PNG به JPG](https://products.aspose.com/slides/fa/php-java/conversion/png-to-jpg/); تبدیل [PNG به SVG](https://products.aspose.com/slides/fa/php-java/conversion/png-to-svg/)، تبدیل [SVG به PNG](https://products.aspose.com/slides/fa/php-java/conversion/svg-to-png/). 
{{% /alert %}}

## **ایجاد یک قاب تصویر با مقیاس نسبی**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.  
2. از طریق ایندکس، مرجع یک اسلاید را دریافت کنید.  
3. یک تصویر را به مجموعهٔ تصاویر ارائه اضافه کنید.  
4. یک شیء [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) ایجاد کنید با افزودن یک تصویر به [ImageCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagecollection/) مرتبط با شیء presentation که برای پر کردن شکل استفاده می‌شود.  
5. عرض و ارتفاع نسبی تصویر را در قاب تصویر مشخص کنید.  
6. ارائهٔ تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.  

این کد PHP نشان می‌دهد که چگونه یک قاب تصویر با مقیاس نسبی ایجاد کنید:

```php
  # ایجاد نمونه از کلاس Presentation که نمایانگر PPTX است
  $pres = new Presentation();
  try {
    # دریافت اسلاید اول
    $sld = $pres->getSlides()->get_Item(0);
    # ایجاد نمونه از کلاس Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # افزودن قاب تصویر با ارتفاع و عرض مساوی با تصویر
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # تنظیم مقیاس نسبی عرض و ارتفاع
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # نوشتن فایل PPTX بر روی دیسک
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **استخراج تصاویر رستر از قاب‌های تصویر**

می‌توانید تصاویر رستری را از اشیای [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) استخراج کرده و در قالب‌های PNG، JPG و سایر فرمت‌ها ذخیره کنید. مثال کد زیر نشان می‌دهد چگونه یک تصویر را از سند "sample.pptx" استخراج و در قالب PNG ذخیره کنید.

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

وقتی یک ارائه شامل گرافیک‌های SVG باشد که داخل اشکال [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) قرار گرفته‌اند، Aspose.Slides برای PHP از طریق Java به شما امکان می‌دهد تا تصاویر برداری اصلی را با وفاداری کامل بازیابی کنید. با پیمایش مجموعهٔ اشکال اسلاید، می‌توانید هر [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) را شناسایی کنید، بررسی کنید آیا [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) زیرین محتویات SVG دارد یا نه، و سپس آن تصویر را به‌صورت بومی SVG روی دیسک یا یک جریان ذخیره کنید.

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

Aspose.Slides به شما اجازه می‌دهد اثر شفافیتی که بر روی یک تصویر اعمال شده است را دریافت کنید. این کد PHP عملیات را نشان می‌دهد:

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

## **قاب‌بندی تصویر**

Aspose.Slides گزینه‌های قالب‌بندی بسیاری را ارائه می‌دهد که می‌توان بر روی یک قاب تصویر اعمال کرد. با استفاده از این گزینه‌ها می‌توانید قاب تصویر را برای برآورده کردن نیازهای خاص تغییر دهید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.  
2. از طریق ایندکس، مرجع یک اسلاید را دریافت کنید.  
3. یک شیء [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) ایجاد کنید با افزودن یک تصویر به [ImageCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagecollection/) مرتبط با شیء presentation که برای پر کردن شکل استفاده می‌شود.  
4. عرض و ارتفاع تصویر را مشخص کنید.  
5. یک `PictureFrame` بر اساس عرض و ارتفاع تصویر ایجاد کنید از طریق متد [addPictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/addpictureframe/) که توسط شیء [ShapeCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/) مرتبط با اسلاید مرجع ارائه می‌شود.  
6. قاب تصویر (حاوی تصویر) را به اسلاید اضافه کنید.  
7. رنگ خط قاب تصویر را تنظیم کنید.  
8. عرض خط قاب تصویر را تنظیم کنید.  
9. قاب تصویر را با مقدار مثبت یا منفی چرخانده کنید.  
   * مقدار مثبت تصویر را به جهت ساعتگرد چرخانده می‌شود.  
   * مقدار منفی تصویر را به جهت پادساعتگرد چرخانده می‌شود.  
10. قاب تصویر (حاوی تصویر) را به اسلاید اضافه کنید.  
11. ارائهٔ تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.  

این کد PHP فرآیند قالب‌بندی قاب تصویر را نشان می‌دهد:

```php
  # یک نمونه از کلاس Presentation که نمایانگر PPTX است ایجاد می‌کند
  $pres = new Presentation();
  try {
    # اسلاید اول را دریافت می‌کند
    $sld = $pres->getSlides()->get_Item(0);
    # یک نمونه از کلاس Image ایجاد می‌کند
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # یک قاب تصویر با ارتفاع و عرض برابر با تصویر اضافه می‌کند
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # اعمال برخی قالب‌بندی‌ها به PictureFrameEx
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # فایل PPTX را بر روی دیسک می‌نویسد
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tip" color="primary" %}} 
Aspose اخیراً یک [Collage Maker رایگان](https://products.aspose.app/slides/fa/collage) توسعه داده است. اگر نیاز به [ادغام JPG/JPEG](https://products.aspose.app/slides/fa/collage/jpg) یا تصاویر PNG داشته باشید، یا [ایجاد گریدهای تصویری](https://products.aspose.app/slides/fa/collage/photo-grid) بخواهید، می‌توانید از این سرویس استفاده کنید. 
{{% /alert %}}

## **افزودن تصویر به‌صورت لینک**

برای جلوگیری از بزرگ شدن حجم ارائه، می‌توانید به‌جای جاسازی مستقیم فایل‌ها، تصاویر (یا ویدئوها) را از طریق لینک‌ها اضافه کنید. این کد PHP نشان می‌دهد چگونه یک تصویر و یک ویدئو را در یک جای‌دار اضافه کنید:

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

این کد PHP نشان می‌دهد چگونه یک تصویر موجود در یک اسلاید را برش دهید:

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
    # افزودن یک PictureFrame به اسلاید
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # برش تصویر (مقادیر درصدی)
    $picFrame->getPictureFormat()->setCropLeft(23.6);
    $picFrame->getPictureFormat()->setCropRight(21.5);
    $picFrame->getPictureFormat()->setCropTop(3);
    $picFrame->getPictureFormat()->setCropBottom(31);
    # ذخیره نتایج
    $pres->save($outPptxFile, SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **حذف نواحی برش‌خورده یک تصویر**

اگر می‌خواهید نواحی برش‌خوردهٔ یک تصویر موجود در یک قاب را حذف کنید، می‌توانید از متد [deletePictureCroppedAreas()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) استفاده کنید. این متد تصویر برش‌خورده یا تصویر اصلی را برمی‌گرداند اگر برش لازم نباشد.

این کد PHP عملیات را نشان می‌دهد:

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # دریافت PictureFrame از اسلاید اول
    $picFrame = $slide->getShapes()->get_Item(0);
    # حذف نواحی برش‌خوردهٔ تصویر PictureFrame و برگرداندن تصویر برش‌خورده
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # ذخیره نتایج
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 
متد [deletePictureCroppedAreas()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) تصویر برش‌خورده را به مجموعهٔ تصاویر ارائه اضافه می‌کند. اگر تصویر فقط در [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) پردازش‌شده استفاده شود، این تنظیم می‌تواند حجم ارائه را کاهش دهد؛ در غیر این صورت، تعداد تصاویر در ارائهٔ نهایی افزایش می‌یابد.  

این متد در عملیات برش، فایل‌های متا‌فایل WMF/EMF را به تصویر PNG رستر تبدیل می‌کند. 
{{% /alert %}}

## **فشرده‌سازی تصاویر**

می‌توانید با استفاده از متد [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) یک تصویر داخل یک ارائه را فشرده کنید. این متد تصویر را با کاهش اندازهٔ آن براساس اندازهٔ شکل و وضوح مشخص‌شده فشرده می‌کند و امکان حذف نواحی برش‌خورده را نیز فراهم می‌آورد.

این ویژگی اندازه و وضوح تصویر را مشابه ویژگی **Picture Format -> Compress Pictures -> Resolution** در PowerPoint تنظیم می‌کند.

مثال‌های PHP زیر نشان می‌دهند چگونه با تعیین وضوح هدف و در صورت تمایل حذف نواحی برش‌خورده، یک تصویر را در ارائه فشرده کنید:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # تصویر را با وضوح هدف 150 DPI (وضوح وب) فشرده کنید و نواحی برش‌خورده را حذف کنید.
    $result = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);

    # نتیجهٔ فشرده‌سازی را بررسی کنید.
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

یا با استفاده مستقیم از مقدار DPI سفارشی:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # تصویر را به 150 DPI (وضوح وب) فشرده کنید و نواحی برش‌خورده را حذف کنید.
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
متد تصویر را بر پایهٔ اندازهٔ شکل و DPI ارائه‌شده به وضوح پایین‌تر تبدیل می‌کند. نواحی برش‌خورده نیز می‌توانند برای بهینه‌سازی حجم حذف شوند.  
اگر تصویر یک متا‌فایل (WMF/EMF) یا SVG باشد، فشرده‌سازی اعمال نمی‌شود. همچنین کیفیت JPEG بر پایهٔ وضوح حفظ یا کمی کاهش می‌یابد، مشابه نحوهٔ کار PowerPoint با JPEGهای با وضوح بالا. 
{{% /alert %}}

## **قفل کردن نسبت ابعاد**

اگر می‌خواهید شکلی که حاوی تصویر است حتی پس از تغییر ابعاد تصویر، نسبت ابعاد خود را حفظ کند، می‌توانید از متد [setAspectRatioLocked](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) برای تنظیم گزینه *Lock Aspect Ratio* استفاده کنید.

این کد PHP نشان می‌دهد چگونه نسبت ابعاد یک شکل را قفل کنید:

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
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 
این تنظیم *Lock Aspect Ratio* فقط نسبت ابعاد شکل را حفظ می‌کند و نه تصویری که درون آن قرار دارد. 
{{% /alert %}}

## **استفاده از ویژگی StretchOff**

با استفاده از متدهای [setStretchOffsetLeft](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/)، [setStretchOffsetTop](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/setstretchoffsettop/)، [setStretchOffsetRight](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) و [setStretchOffsetBottom](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) از کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/) می‌توانید یک مستطیل پر‌کننده تعریف کنید.

هنگامی که برای یک تصویر کشش تعریف شود، مستطیل منبع به‌گونه‌ای مقیاس می‌شود که داخل مستطیل پر‌کنندهٔ مشخص‌شده جای بگیرد. هر لبهٔ مستطیل پر‌کننده توسط مقدار درصدی از لبهٔ متناظر جعبهٔ محدود کنندهٔ شکل تعریف می‌شود. مقدار درصدی مثبت یک تورم داخلی و مقدار درصدی منفی یک برون‌گردانی را مشخص می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.  
2. از طریق ایندکس، مرجع یک اسلاید را دریافت کنید.  
3. یک مستطیل `AutoShape` اضافه کنید.  
4. یک تصویر ایجاد کنید.  
5. نوع پر کردن شکل را تنظیم کنید.  
6. حالت پر کردن تصویری شکل را تنظیم کنید.  
7. تصویر تنظیم‌شده را برای پر کردن شکل اضافه کنید.  
8. افست‌های تصویر را نسبت به لبه‌های متناظر جعبهٔ محدود کنندهٔ شکل مشخص کنید.  
9. ارائهٔ تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.  

این کد PHP فرآیندی را نشان می‌دهد که در آن از ویژگی StretchOff استفاده می‌شود:

```php
  # یک نمونه از کلاس Presentation که نمایانگر فایل PPTX است ایجاد می‌کند
  $pres = new Presentation();
  try {
    # اسلاید اول را دریافت می‌کند
    $slide = $pres->getSlides()->get_Item(0);
    # یک نمونه از کلاس ImageEx ایجاد می‌کند
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # یک AutoShape با تنظیم شکل به Rectangle اضافه می‌کند
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # نوع پر کردن شکل را تنظیم می‌کند
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # حالت پر کردن تصویر شکل را تنظیم می‌کند
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # تصویر را برای پر کردن شکل تنظیم می‌کند
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # افست‌های تصویر را نسبت به لبهٔ متناظر جعبهٔ محدودکنندهٔ شکل مشخص می‌کند
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # فایل PPTX را بر روی دیسک می‌نویسد
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **پرسش‌های متداول**

**چگونه می‌توانم بفهمم کدام فرمت‌های تصویر برای PictureFrame پشتیبانی می‌شوند؟**  
Aspose.Slides هم تصاویر رستری (PNG، JPEG، BMP، GIF و غیره) و هم تصاویر برداری (مانند SVG) را از طریق شیء تصویری که به یک [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) اختصاص داده می‌شود، پشتیبانی می‌کند. فهرست فرمت‌های پشتیبانی‌شده عموماً با قابلیت‌های موتور تبدیل اسلاید و تصویر هم‌پوشانی دارد.

**افزودن ده‌ها تصویر بزرگ چه تأثیری بر حجم و عملکرد PPTX دارد؟**  
جاسازی تصاویر بزرگ حجم فایل و مصرف حافظه را افزایش می‌دهد؛ لینک‌دادن به تصاویر به کاهش حجم ارائه کمک می‌کند اما نیازمند این است که فایل‌های خارجی در دسترس باقی بمانند. Aspose.Slides امکان افزودن تصاویر به‌صورت لینک را برای کاهش حجم فایل فراهم می‌کند.

**چگونه می‌توان یک شیء تصویر را از جابه‌جایی/تغییر اندازهٔ تصادفی محافظت کرد؟**  
از [قفل‌های شکل](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/getpictureframelock/) برای یک [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) استفاده کنید (مثلاً غیرفعال‌سازی جابه‌جایی یا تغییر اندازه). مکانیزم قفل برای انواع مختلفی از شکل‌ها، از جمله [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) پشتیبانی می‌شود.

**آیا صحت برداری SVG هنگام خروجی گرفتن ارائه به PDF/تصاویر حفظ می‌شود؟**  
Aspose.Slides اجازه می‌دهد SVG را از یک [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) به‌عنوان بردار اصلی استخراج کنید. هنگام [خروجی به PDF](/slides/fa/php-java/convert-powerpoint-to-pdf/) یا [فرمت‌های رستر](/slides/fa/php-java/convert-powerpoint-to-png/)، نتیجه ممکن است بسته به تنظیمات خروجی رستر شود؛ اما این نکته که SVG اصلی به عنوان بردار ذخیره شده است، توسط رفتار استخراج تأیید می‌شود.