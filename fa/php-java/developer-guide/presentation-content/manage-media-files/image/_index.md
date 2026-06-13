---
title: بهینه‌سازی مدیریت تصویر در ارائه‌ها با استفاده از PHP
linktitle: مدیریت تصاویر
type: docs
weight: 10
url: /fa/php-java/image/
keywords:
- افزودن تصویر
- افزودن عکس
- افزودن بیت‌مپ
- جایگزینی تصویر
- جایگزینی عکس
- از وب
- پس‌زمینه
- افزودن PNG
- افزودن JPG
- افزودن SVG
- افزودن EMF
- افزودن WMF
- افزودن TIFF
- PowerPoint
- OpenDocument
- ارائه
- EMF
- SVG
- PHP
- Aspose.Slides
description: "مدیریت تصویر را در PowerPoint و OpenDocument با Aspose.Slides برای PHP از طریق Java به‌صورت بهینه و خودکار کنید، کارایی را بهبود بخشیده و جریان کار شما را خودکار می‌کند."
---
## **مقدمه**

تصاویر ارائه‌ها را جذاب و جالب‌تر می‌کنند. در Microsoft PowerPoint می‌توانید تصاویر را از یک فایل، اینترنت یا مکان‌های دیگر به اسلایدها وارد کنید. به همان شکل، Aspose.Slides به شما امکان می‌دهد تا با روش‌های مختلف تصاویر را به اسلایدهای ارائه‌ی خود اضافه کنید. 

{{% alert  title="Tip" color="primary" %}} 

Aspose مبدل‌های رایگان—[JPEG به PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG به PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—را ارائه می‌دهد که به افراد امکان می‌کند به سرعت از تصاویر ارائه‌ها را ایجاد کنند. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

اگر می‌خواهید تصویری را به‌عنوان یک شیء قاب اضافه کنید—به‌ویژه اگر قصد دارید از گزینه‌های قالب‌بندی استاندارد بر روی آن برای تغییر اندازه، افزودن افکت‌ها و غیره استفاده کنید—به [قاب تصویر](/slides/fa/php-java/picture-frame/) مراجعه کنید.

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

می‌توانید عملیات ورودی/خروجی مرتبط با تصاویر و ارائه‌های PowerPoint را برای تبدیل یک تصویر از یک قالب به قالب دیگر دستکاری کنید. این صفحات را ببینید: تبدیل [تصویر به JPG](https://products.aspose.com/slides/fa/php-java/conversion/image-to-jpg/)؛ تبدیل [JPG به تصویر](https://products.aspose.com/slides/fa/php-java/conversion/jpg-to-image/)؛ تبدیل [JPG به PNG](https://products.aspose.com/slides/fa/php-java/conversion/jpg-to-png/)، تبدیل [PNG به JPG](https://products.aspose.com/slides/fa/php-java/conversion/png-to-jpg/)؛ تبدیل [PNG به SVG](https://products.aspose.com/slides/fa/php-java/conversion/png-to-svg/)، تبدیل [SVG به PNG](https://products.aspose.com/slides/fa/php-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides عملیات با تصاویر را در این قالب‌های محبوب پشتیبانی می‌کند: JPEG، PNG، GIF و سایرین. 

## **افزودن تصاویر ذخیره‌شده به‌صورت محلی به اسلایدها**

می‌توانید یک یا چند تصویر را که بر روی کامپیوتر شما هستند به یک اسلاید در یک ارائه اضافه کنید. این کد نمونه نحوه افزودن یک تصویر به اسلاید را نشان می‌دهد:

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

## **افزودن تصاویر از وب به اسلایدها**

اگر تصویری که می‌خواهید به اسلاید اضافه کنید بر روی کامپیوتر شما موجود نیست، می‌توانید تصویر را مستقیماً از وب اضافه کنید. 

این کد نمونه نشان می‌دهد که چگونه یک تصویر را از وب به یک اسلاید اضافه کنید:

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

## **افزودن تصاویر به اسلاید مسترها**

یک اسلاید مستر بالاترین اسلاید است که اطلاعات (قالب، چیدمان و غیره) درباره تمام اسلایدهای زیرین را ذخیره و کنترل می‌کند. بنابراین، زمانی که تصویری را به یک اسلاید مستر اضافه کنید، آن تصویر در هر اسلاید تحت آن مستر ظاهر می‌شود. 

این کد نمونه جاوا نشان می‌دهد چگونه یک تصویر را به اسلاید مستر اضافه کنید:

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

## **افزودن تصاویر به‌عنوان پس‌زمینه اسلاید**

ممکن است تصمیم بگیرید از یک تصویر به‌عنوان پس‌زمینه اسلاید خاص یا چند اسلاید استفاده کنید. در این صورت، باید نحوه [تنظیم یک تصویر به‌عنوان پس‌زمینه اسلاید](/slides/fa/php-java/presentation-background/#set-an-image-as-a-slide-background) را ببینید.

## **افزودن SVG به ارائه‌ها**

می‌توانید هر تصویری را به یک ارائه اضافه یا وارد کنید با استفاده از متد [addPictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/addpictureframe/) که بخشی از کلاس [ShapeCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/) است. 

برای ایجاد شیء تصویر بر پایه تصویر SVG، می‌توانید این کار را به این روش انجام دهید:

1. یک شیء SvgImage ایجاد کنید تا به ImageShapeCollection وارد شود
2. یک شیء PPImage از ISvgImage ایجاد کنید
3. یک شیء PictureFrame با استفاده از کلاس PPImage ایجاد کنید

این کد نمونه نشان می‌دهد چگونه مراحل فوق را برای افزودن تصویر SVG به یک ارائه پیاده‌سازی کنید:
```php
  # ایجاد نمونه از کلاس Presentation که نمایانگر فایل PPTX است
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

## **تبدیل SVG به مجموعه‌ای از اشکال**

تبدیل SVG به مجموعه‌ای از اشکال در Aspose.Slides شبیه به عملکرد PowerPoint است که برای کار با تصاویر SVG استفاده می‌شود:

![PowerPoint Popup Menu](img_01_01.png)

این عملکرد توسط یکی از overloadهای متد [addGroupShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/addgroupshape/) از کلاس [ShapeCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/) که یک شیء [SvgImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgimage/) را به‌عنوان اولین آرگومان می‌گیرد، ارائه می‌شود.

این کد نمونه نشان می‌دهد چگونه از روش توصیف‌شده برای تبدیل یک فایل SVG به مجموعه‌ای از اشکال استفاده کنید:

```php
  # ایجاد ارائه جدید
  $presentation = new Presentation();
  try {
    # خواندن محتوای فایل SVG
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

    # ایجاد شیء SvgImage
    $svgImage = new SvgImage($svgContent);
    # دریافت اندازه اسلاید
    $slideSize = $presentation->getSlideSize()->getSize();
    # تبدیل تصویر SVG به گروهی از شکل‌ها و مقیاس‌بندی آن به اندازه اسلاید
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape($svgImage, 0.0, 0.0, $slideSize->getWidth(), $slideSize->getHeight());
    # ذخیره ارائه در قالب PPTX
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **افزودن تصاویر به‌صورت EMF به اسلایدها**

Aspose.Slides برای PHP از طریق Java به شما امکان می‌دهد تصاویر EMF را از صفحات Excel تولید کنید و با Aspose.Cells این تصاویر را به‌صورت EMF به اسلایدها اضافه کنید.  

این کد نمونه نشان می‌دهد چگونه این کار توصیف‌شده را انجام دهید:

```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # ذخیره کتاب کار در جریان
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

## **جایگزینی تصاویر در مجموعه تصویر**

Aspose.Slides به شما اجازه می‌دهد تصاویر ذخیره‌شده در مجموعه تصویر یک ارائه (از جمله آن‌هایی که توسط شکل‌های اسلاید استفاده می‌شوند) را جایگزین کنید. این بخش چندین رویکرد برای به‌روز کردن تصاویر در مجموعه نشان می‌دهد. API روش‌های ساده‌ای برای جایگزینی یک تصویر با استفاده از داده‌های بایتی خام، یک نمونه [IImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/iimage/) یا تصویر دیگری که قبلاً در مجموعه موجود است، فراهم می‌کند. 

1. فایل ارائه‌ای که شامل تصاویر است را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) بارگذاری کنید.
2. یک تصویر جدید را از فایل به یک آرایه بایت بارگذاری کنید.
3. تصویر هدف را با تصویر جدید با استفاده از آرایه بایت جایگزین کنید.
4. در رویکرد دوم، تصویر را به یک شیء [IImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/iimage/) بارگذاری کنید و تصویر هدف را با آن شیء جایگزین کنید.
5. در رویکرد سوم، تصویر هدف را با تصویری که قبلاً در مجموعه تصویر ارائه وجود دارد، جایگزین کنید.
6. ارائه‌ی اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

```php
// ایجاد نمونه‌ای از کلاس Presentation که نمایانگر یک فایل ارائه است.
$presentation = new Presentation("sample.pptx");
try {
    // روش اول.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new Java("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // روش دوم.
    $newImage = Images::fromFile("image1.png");
    $oldImage = $presentation->getImages()->get_Item(1);
    $oldImage->replaceImage($newImage);
    $newImage->dispose();
    
    // روش سوم.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));
    
    // ذخیره ارائه در یک فایل.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}

با استفاده از مبدل رایگان Aspose [متن به GIF](https://products.aspose.app/slides/fa/text-to-gif) می‌توانید به‌راحتی متون را انیمیشن کنید، GIFهایی از متون بسازید و غیره. 

{{% /alert %}}

## **پرسش‌های متداول**

**آیا وضوح تصویر اصلی پس از وارد شدن دست نخورده می‌ماند؟**

بله. پیکسل‌های منبع حفظ می‌شوند، اما ظاهر نهایی به این بستگی دارد که چگونه [تصویر](/slides/fa/php-java/picture-frame/) در اسلاید مقیاس‌بندی شده و چه فشرده‌سازی در ذخیره‌سازی اعمال شده است.

**بهترین روش برای جایگزینی یک لوگو مشابه در ده‌ها اسلاید به‌صورت همزمان چیست؟**

لوگو را بر روی اسلاید مستر یا یک چیدمان قرار دهید و آن را در مجموعه تصویر ارائه جایگزین کنید—به‌روزرسانی‌ها به تمام عناصری که از این منبع استفاده می‌کنند انتشار می‌یابد.

**آیا می‌توان SVG وارد شده را به شکل‌های قابل ویرایش تبدیل کرد؟**

بله. می‌توانید یک SVG را به یک گروه از شکل‌ها تبدیل کنید، پس از آن بخش‌های جداگانه با ویژگی‌های استاندارد شکل قابل ویرایش می‌شوند.

**چگونه می‌توانم یک تصویر را به‌عنوان پس‌زمینه برای چند اسلاید به‌صورت همزمان تنظیم کنم؟**

[تصویر را به‌عنوان پس‌زمینه اختصاص دهید](/slides/fa/php-java/presentation-background/) بر روی اسلاید مستر یا چیدمان مربوطه—هر اسلایدی که از این مستر/چیدمان استفاده می‌کند پس‌زمینه را به ارث می‌برد.

**چگونه می‌توانم از بزرگ شدن بیش از حد اندازه ارائه به‌دلیل تعداد زیاد تصاویر جلوگیری کنم؟**

به‌جای تکرار، یک منبع تصویر واحد را مجدداً استفاده کنید، وضوح‌های معقول را انتخاب کنید، هنگام ذخیره‌سازی فشرده‌سازی اعمال کنید و گرافیک‌های تکراری را در مستر حفظ کنید در صورتی که مناسب باشد.