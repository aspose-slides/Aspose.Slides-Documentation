---
title: مدیریت OLE در ارائه‌ها با استفاده از PHP
linktitle: مدیریت OLE
type: docs
weight: 40
url: /fa/php-java/manage-ole/
keywords:
- شیء OLE
- پیوند و جاسازی شیء
- افزودن OLE
- جاسازی OLE
- افزودن شیء
- جاسازی شیء
- افزودن فایل
- جاسازی فایل
- شیء پیوندی
- فایل پیوندی
- تغییر OLE
- آیکون OLE
- عنوان OLE
- استخراج OLE
- استخراج شیء
- استخراج فایل
- پاورپوینت
- ارائه
- PHP
- Aspose.Slides
description: "بهینه‌سازی مدیریت اشیاء OLE در فایل‌های PowerPoint و OpenDocument با Aspose.Slides برای PHP از طریق Java. به‌صورت یکپارچه OLE را جاسازی، به‌روزرسانی و صادر کنید."
---
## **مقدمه**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) یک فناوری مایکروسافت است که اجازه می‌دهد داده‌ها و اشیائی که در یک برنامه ایجاد شده‌اند، از طریق ارتباط یا جاسازی در برنامه دیگری قرار گیرند. 

{{% /alert %}} 

به یک نمودار ایجاد شده در MS Excel توجه کنید. سپس این نمودار داخل یک اسلاید PowerPoint قرار می‌گیرد. آن نمودار Excel به عنوان یک شیء OLE در نظر گرفته می‌شود. 

- یک شیء OLE ممکن است به صورت یک آیکون نمایش داده شود. در این حالت، هنگام دوبار کلیک روی آیکون، نمودار در برنامه مرتبط خود (Excel) باز می‌شود یا از شما خواسته می‌شود برنامه‌ای را برای باز کردن یا ویرایش شیء انتخاب کنید. 
- یک شیء OLE ممکن است محتوای واقعی خود را نشان دهد، مانند محتوای یک نمودار. در این حالت، نمودار در PowerPoint فعال می‌شود، رابط کاربری نمودار بارگذاری می‌شود و می‌توانید داده‌های نمودار را درون PowerPoint تغییر دهید. 

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/fa/php-java/) به شما امکان می‌دهد OLE Objects را به اسلایدها به‌عنوان چارچوب‌های شیء OLE وارد کنید ([OleObjectFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/oleobjectframe/)).

## **افزودن چارچوب‌های شیء OLE به اسلایدها**

فرض کنید قبلاً یک نمودار در Microsoft Excel ایجاد کرده‌اید و می‌خواهید آن را به‌صورت یک چارچوب شیء OLE در یک اسلاید جاسازی کنید با استفاده از Aspose.Slides for PHP via Java؛ می‌توانید این کار را به این روش انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید را بر اساس ایندکس آن دریافت کنید.
1. فایل Excel را به‌عنوان آرایه بایت بخوانید.
1. چارچوب [OleObjectFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/oleobjectframe/) را به اسلاید اضافه کنید که شامل آرایه بایت و سایر اطلاعات مربوط به شیء OLE است.
1. ارائه‌ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

در مثال زیر، یک نمودار از یک فایل Excel را به‌عنوان یک چارچوب شیء OLE به یک اسلاید اضافه کردیم با استفاده از Aspose.Slides for PHP via Java.  
**توجه** که سازندهٔ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/oleembeddeddatainfo/) یک پسوند شیء جاسازی‌شدنی را به‌عنوان پارامتر دوم می‌گیرد. این پسوند به PowerPoint امکان می‌دهد نوع فایل را به‌درستی تفسیر کرده و برنامه مناسب برای باز کردن این شیء OLE را انتخاب کند.

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// Prepare data for the OLE object.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// Add the OLE object frame to the slide.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **افزودن چارچوب‌های شیء OLE پیوندی**

Aspose.Slides for PHP via Java به شما امکان می‌دهد یک [OleObjectFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/oleobjectframe/) را بدون جاسازی داده‌ها بلکه فقط با یک پیوند به فایل اضافه کنید.

این کد PHP نشان می‌دهد چگونه یک [OleObjectFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/oleobjectframe/) با فایل Excel پیوندی به یک اسلاید اضافه کنید:

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// Add an OLE object frame with a linked Excel file.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **دسترسی به چارچوب‌های شیء OLE**

اگر یک شیء OLE از پیش در یک اسلاید جاسازی شده باشد، می‌توانید به راحتی آن را به این روش پیدا یا دسترسی پیدا کنید:

1. یک ارائه حاوی شیء OLE جاسازی‌شده را با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) بارگذاری کنید.
2. مرجع اسلاید را با استفاده از ایندکس آن دریافت کنید.
3. به شکل [OleObjectFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/oleobjectframe/) دسترسی پیدا کنید. در مثال ما، از PPTX قبلاً ایجاد شده استفاده کردیم که فقط یک شکل در اسلاید اول دارد.
4. پس از دسترسی به چارچوب شیء OLE، می‌توانید هر عملیاتی را بر آن انجام دهید.

در مثال زیر، یک چارچوب شیء OLE (شیء نمودار Excel جاسازی‌شده در یک اسلاید) و داده‌های فایل آن دسترسی پیدا می‌شوند.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // دریافت داده‌های فایل جاسازی‌شده.
    // دریافت پسوند فایل جاسازی‌شده.
    // ...
}
```

### **دسترسی به ویژگی‌های چارچوب شیء OLE پیوندی**

Aspose.Slides به شما امکان می‌دهد به ویژگی‌های چارچوب شیء OLE پیوندی دسترسی پیدا کنید.

این کد PHP نشان می‌دهد چگونه بررسی کنید آیا یک شیء OLE پیوندی است و سپس مسیر فایل پیوندی را به‌دست آورید:

```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // بررسی کنید آیا شیء OLE پیوندی است.
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // مسیر کامل فایل پیوندی را چاپ کنید.
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // مسیر نسبی فایل پیوندی را در صورت وجود چاپ کنید.
        // فقط ارائه‌های PPT می‌توانند مسیر نسبی را شامل شوند.
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```

## **تغییر داده‌های شیء OLE**

{{% alert color="primary" %}} 

در این بخش، مثال کد زیر از [Aspose.Cells for PHP via Java](/cells/php-java/) استفاده می‌کند.

{{% /alert %}}

اگر یک شیء OLE از پیش در یک اسلاید جاسازی شده باشد، می‌توانید به راحتی به آن شیء دسترسی پیدا کنید و داده‌های آن را به این روش تغییر دهید:

1. یک ارائه حاوی شیء OLE جاسازی‌شده را با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) بارگذاری کنید.
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید. 
3. به شکل [OleObjectFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/oleobjectframe/) دسترسی پیدا کنید. در مثال ما، از PPTX قبلاً ایجاد شده استفاده کردیم که یک شکل در اسلاید اول دارد.
4. پس از دسترسی به چارچوب شیء OLE، می‌توانید هر عملیاتی را بر آن انجام دهید.
5. یک شیء `Workbook` ایجاد کنید و به داده‌های OLE دسترسی پیدا کنید.
6. `Worksheet` مورد نظر را دسترسی پیدا کنید و داده‌ها را اصلاح کنید.
7. `Workbook` به‌روزشده را در یک جریان ذخیره کنید.
8. داده‌های شیء OLE را از جریان تغییر دهید.

در مثال زیر، یک چارچوب شیء OLE (شیء نمودار Excel جاسازی‌شده در یک اسلاید) دسترسی پیدا می‌کند و داده‌های فایل آن برای بروزرسانی داده‌های نمودار تغییر می‌یابد.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new ByteArrayInputStream($oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // داده‌های شیء OLE را به‌عنوان یک شیء Workbook بخوانید.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // داده‌های ورک‌بوک را تغییر دهید.
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // داده‌های شیء چارچوب OLE را تغییر دهید.
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **جاسازی انواع دیگر فایل‌ها در اسلایدها**

علاوه بر نمودارهای Excel، Aspose.Slides for PHP via Java به شما امکان می‌دهد انواع دیگر فایل‌ها را در اسلایدها جاسازی کنید. به عنوان مثال، می‌توانید فایل‌های HTML، PDF و ZIP را به‌عنوان اشیاء وارد کنید. وقتی کاربری دو بار روی شیء وارد شده کلیک کند، به‌طور خودکار در برنامه مربوطه باز می‌شود یا از کاربر درخواست می‌شود برنامه مناسب برای باز کردن آن را انتخاب کند.

این کد PHP نشان می‌دهد چگونه HTML و ZIP را در یک اسلاید جاسازی کنید:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$htmlData = file_get_contents("sample.html");
$htmlDataInfo = new OleEmbeddedDataInfo($htmlData, "html");
$htmlOleFrame = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $htmlDataInfo);
$htmlOleFrame->setObjectIcon(true);

$zipData = file_get_contents("sample.zip");
$zipDataInfo = new OleEmbeddedDataInfo($zipData, "zip");
$zipOleFrame = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $zipDataInfo);
$zipOleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **تنظیم نوع فایل برای اشیای جاسازی‌شده**

هنگام کار با ارائه‌ها، ممکن است نیاز داشته باشید اشیای OLE قدیمی را با جدیدها جایگزین کنید یا یک شیء OLE پشتیبانی‌نشده را با یک شیء پشتیبانی‌شده عوض کنید. Aspose.Slides for PHP via Java به شما امکان می‌دهد نوع فایل برای یک شیء جاسازی‌شده تنظیم کنید و به‌این‌وسیلۀ داده‌های چارچوب OLE یا پسوند آن را به‌روزرسانی کنید.

این کد PHP نشان می‌دهد چگونه نوع فایل برای یک شیء OLE جاسازی‌شده را به `zip` تنظیم کنید:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// تغییر نوع فایل به ZIP.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **تنظیم تصاویر آیکون و عناوین برای اشیای جاسازی‌شده**

پس از جاسازی یک شیء OLE، پیش‌نمایشی شامل یک تصویر آیکون به‌طور خودکار افزوده می‌شود. این پیش‌نمایش همان چیزی است که کاربران قبل از دسترسی یا باز کردن شیء OLE می‌بینند. اگر می‌خواهید از تصویر و متن خاصی به‌عنوان عناصر در پیش‌نمایش استفاده کنید، می‌توانید تصویر آیکون و عنوان را با استفاده از Aspose.Slides for PHP via Java تنظیم کنید.

این کد PHP نشان می‌دهد چگونه تصویر آیکون و عنوان را برای یک شیء جاسازی‌شده تنظیم کنید:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// یک تصویر به منابع ارائه اضافه کنید.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Set a title and the image for the OLE preview.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **جلوگیری از تغییر اندازه و موقعیت چارچوب شیء OLE**

پس از افزودن یک شیء OLE پیوندی به یک اسلاید ارائه، وقتی ارائه را در PowerPoint باز می‌کنید، ممکن است پیغامی مبنی بر به‌روزرسانی پیوندها ببینید. کلیک کردن روی دکمه «Update Links» ممکن است اندازه و موقعیت چارچوب شیء OLE را تغییر دهد زیرا PowerPoint داده‌ها را از شیء OLE پیوندی به‌روزرسانی می‌کند و پیش‌نمایش شیء را تازه می‌سازد. برای جلوگیری از این درخواست PowerPoint، متد `setUpdateAutomatic` کلاس [OleObjectFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/oleobjectframe/) را روی `false` تنظیم کنید:

```php
$oleFrame->setUpdateAutomatic(false);
```

## **استخراج فایل‌های جاسازی‌شده**

Aspose.Slides for PHP via Java به شما امکان می‌دهد فایل‌های جاسازی‌شده در اسلایدها را به‌عنوان اشیای OLE به این روش استخراج کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید که شامل اشیای OLEی که قصد استخراج آنها را دارید، باشد.
2. بر تمام اشکال موجود در ارائه حلقه بزنید و به اشکال [OLEObjectFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/oleobjectframe/) دسترسی پیدا کنید.
3. داده‌های فایل‌های جاسازی‌شده را از چارچوب‌های شیء OLE استخراج کنید و روی دیسک بنویسید.

این کد PHP نشان می‌دهد چگونه فایل‌های جاسازی‌شده در یک اسلاید را به‌عنوان اشیای OLE استخراج کنید:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$shapeCount = java_values($slide->getShapes()->size());
for ($index = 0; $index < $shapeCount; $index++) {
    $shape = $slide->getShapes()->get_Item($index);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $oleFrame = $shape;

        $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

        $filePath = "OLE_object_" . $index . $fileExtension;
        file_put_contents($filePath, $fileData);
    }
}

$presentation->dispose();
```

## **FAQ**

**آیا محتوای OLE هنگام خروجی گرفتن اسلایدها به PDF/تصاویر رندر می‌شود؟**

آنچه در اسلاید قابل مشاهده است رندر می‌شود — آیکون/تصویر جایگزین (پیشنمایش). محتوای زنده OLE در هنگام رندر اجرا نمی‌شود. در صورت نیاز، تصویر پیش‌نمایش خود را تنظیم کنید تا ظاهر مورد انتظار در PDF خروجی تأیید شود.

**چگونه می‌توانم یک شیء OLE را در اسلاید قفل کنم تا کاربران نتوانند آن را در PowerPoint جابه‌جا یا ویرایش کنند؟**

شکل را قفل کنید: Aspose.Slides قفل‌های سطح شکل را ارائه می‌دهد. این قفل‌گذاری رمزنگاری نیست، اما به‌طور مؤثری از ویرایش‌ها و جابه‌جایی‌های ناخواسته جلوگیری می‌کند.

**آیا مسیرهای نسبی برای اشیای OLE پیوندی در فرمت PPTX حفظ می‌شوند؟**

در PPTX اطلاعات «مسیر نسبی» موجود نیست — فقط مسیر کامل ذخیره می‌شود. مسیرهای نسبی در فرمت قدیمی PPT یافت می‌شوند. برای قابل حمل بودن، مسیرهای مطمئن مطلق/URIهای قابل دسترسی یا جاسازی را ترجیح دهید.