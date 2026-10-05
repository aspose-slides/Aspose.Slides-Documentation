---
title: مدیریت OLE در ارائه‌ها با استفاده از PHP
linktitle: مدیریت OLE
type: docs
weight: 40
url: /fa/php-java/manage-ole/
keywords:
- شیء OLE
- پیوند و جاسازی اشیاء
- افزودن OLE
- جاسازی OLE
- افزودن شیء
- جاسازی شیء
- افزودن فایل
- جاسازی فایل
- شیء مرتبط
- فایل مرتبط
- تغییر OLE
- آیکون OLE
- عنوان OLE
- استخراج OLE
- استخراج شیء
- استخراج فایل
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "مدیریت شیء OLE را در فایل‌های PowerPoint و OpenDocument با Aspose.Slides برای PHP از طریق Java بهینه کنید. محتوای OLE را به‌صورت یکپارچه جاسازی، به‌روزرسانی و صادر کنید."
---
## **معرفی**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) فناوری مایکروسافت است که به شما امکان می‌دهد داده‌ها و اشیائی که در یک برنامه ایجاد شده‌اند را از طریق لینک یا جاگذاری در برنامهٔ دیگر قرار دهید. 

{{% /alert %}} 

یک نمودار ایجاد شده در MS Excel را در نظر بگیرید. سپس این نمودار داخل یک اسلاید PowerPoint قرار می‌گیرد. آن نمودار Excel به‌عنوان یک شیء OLE محسوب می‌شود. 

- یک شیء OLE ممکن است به‌صورت یک آیکون ظاهر شود. در این حالت، هنگام دوبار کلیک بر روی آیکون، نمودار در برنامهٔ مرتبط (Excel) باز می‌شود یا از شما درخواست می‌شود برنامه‌ای برای باز کردن یا ویرایش شیء انتخاب کنید.
- یک شیء OLE ممکن است محتویات واقعی خود را نمایش دهد، مانند محتویات یک نمودار. در این حالت، نمودار در PowerPoint فعال می‌شود، رابط نمودار بارگذاری می‌شود و می‌توانید داده‌های نمودار را در PowerPoint ویرایش کنید.

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) به شما امکان می‌دهد OLE Objects را به عنوان فریم‌های شیء OLE در اسلایدها وارد کنید ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)).

## **افزودن فریم‌های شیء OLE به اسلایدها**

فرض کنید قبلاً یک نمودار در Microsoft Excel ایجاد کرده‌اید و می‌خواهید آن را به‌عنوان یک فریم شیء OLE در اسلاید جاگذاری کنید با استفاده از Aspose.Slides for PHP via Java؛ می‌توانید این کار را به‌صورت زیر انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. فایل Excel را به‌عنوان یک آرایه بایت بخوانید.  
4. فریم [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) را به اسلاید اضافه کنید که شامل آرایه بایت و اطلاعات دیگر درباره شیء OLE باشد.  
5. ارائهٔ اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.  

در مثال زیر، یک نمودار از فایل Excel را به‌عنوان فریم شیء OLE به یک اسلاید اضافه کردیم با استفاده از Aspose.Slides for PHP via Java.  
**Note** اینکه سازنده‌ی [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) یک پسوند شیء قابل جاگذاری را به‌عنوان پارامتر دوم می‌گیرد. این پسوند به PowerPoint امکان می‌دهد نوع فایل را به‌درستی تفسیر کند و برنامهٔ مناسب برای باز کردن این شیء OLE را انتخاب کند.

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// آماده‌سازی داده‌ها برای شیء OLE.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// افزودن فریم شیء OLE به اسلاید.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **افزودن فریم‌های شیء OLE مرتبط**

Aspose.Slides for PHP via Java به شما اجازه می‌دهد یک [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) را بدون جاگذاری داده، تنها با لینک به فایل اضافه کنید.

این کد PHP نشان می‌دهد چگونه یک [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) را با یک فایل Excel مرتبط به یک اسلاید اضافه کنید:

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// افزودن فریم شیء OLE با یک فایل Excel مرتبط.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **دسترسی به فریم‌های شیء OLE**

اگر یک شیء OLE قبلاً در یک اسلاید نهفته باشد، می‌توانید به‌راحتی آن را پیدا یا دسترسی پیدا کنید به این شکل:

1. یک ارائه حاوی شیء OLE نهفته را با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) بارگذاری کنید.  
2. مرجع اسلاید را با استفاده از ایندکس آن دریافت کنید.  
3. به شکل [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) دسترسی پیدا کنید. در مثال ما، از PPTX قبلاً ایجاد شده‌ای استفاده کردیم که تنها یک شکل در اسلاید اول دارد.  
4. پس از دسترسی به فریم شیء OLE، می‌توانید هر عملیاتی را روی آن انجام دهید.  

در مثال زیر، یک فریم شیء OLE (یک شیء نمودار Excel نهفته در اسلاید) و داده‌های فایل آن دسترسی پیدا می‌شوند.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // دریافت داده‌های فایل جاسازی‌شده.
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // دریافت پسوند فایل جاسازی‌شده.
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```

### **دسترسی به ویژگی‌های فریم شیء OLE مرتبط**

Aspose.Slides به شما امکان می‌دهد به ویژگی‌های فریم شیء OLE مرتبط دسترسی پیدا کنید.

این کد PHP نشان می‌دهد چگونه بررسی کنید آیا یک شیء OLE لینک شده است و سپس مسیر فایل لینک شده را بدست آورید:

```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // بررسی اینکه آیا شیء OLE لینک شده است.
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // چاپ مسیر کامل فایل لینک‌شده.
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // چاپ مسیر نسبی فایل لینک‌شده در صورت وجود.
        // فقط ارائه‌های PPT می‌توانند مسیر نسبی را داشته باشند.
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```

## **تغییر داده‌های شیء OLE**

{{% alert color="info" title="Note" %}}

در این بخش، مثال کد زیر از [Aspose.Cells for PHP via Java](https://docs.aspose.com/cells/php-java/) استفاده می‌کند.

{{% /alert %}}

اگر یک شیء OLE قبلاً در یک اسلاید نهفته باشد، می‌توانید به‌راحتی آن را دسترسی پیدا کنید و داده‌های آن را به این شکل تغییر دهید:

1. یک ارائه حاوی شیء OLE نهفته را با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) بارگذاری کنید.  
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.  
3. به شکل [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) دسترسی پیدا کنید. در مثال ما، از PPTX قبلاً ایجاد شده‌ای استفاده کردیم که یک شکل در اسلاید اول دارد.  
4. پس از دسترسی به فریم شیء OLE، می‌توانید هر عملیاتی را روی آن انجام دهید.  
5. یک شیء `Workbook` ایجاد کنید و به داده‌های OLE دسترسی پیدا کنید.  
6. `Worksheet` موردنظر را دسترسی پیدا کنید و داده‌ها را اصلاح کنید.  
7. `Workbook` به‌روز شده را در یک استریم ذخیره کنید.  
8. داده‌های شیء OLE را از استریم تغییر دهید.  

در مثال زیر، یک فریم شیء OLE (یک شیء نمودار Excel نهفته در اسلاید) دسترسی پیدا می‌شود و داده‌های فایل آن برای به‌روزرسانی داده‌های نمودار اصلاح می‌شود.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new Java("java.io.ByteArrayInputStream", $oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // داده‌های شیء OLE را به عنوان یک شیء Workbook بخوانید.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // داده‌های Workbook را اصلاح کنید.
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // داده‌های شیء فریم OLE را تغییر دهید.
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **درج انواع فایل‌های دیگر در اسلایدها**

به‌جز نمودارهای Excel، Aspose.Slides for PHP via Java به شما اجازه می‌دهد انواع دیگری از فایل‌ها را به اسلایدها وارد کنید. برای مثال می‌توانید فایل‌های HTML، PDF و ZIP را به‌عنوان اشیاء وارد کنید. وقتی کاربر روی شیء درج‌شده دوبار کلیک می‌کند، به‌صورت خودکار در برنامهٔ مربوطه باز می‌شود یا از کاربر خواسته می‌شود برنامهٔ مناسب را برای باز کردن آن انتخاب کند.

این کد PHP نشان می‌دهد چگونه HTML و ZIP را به یک اسلاید وارد کنید:

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

## **تنظیم انواع فایل برای اشیاء نهفته**

هنگام کار با ارائه‌ها، ممکن است نیاز داشته باشید اشیاء OLE قدیمی را با اشیاء جدید جایگزین کنید یا یک شیء OLE پشتیبانی‌نشده را با یک شیء پشتیبانی‌شده جایگزین کنید. Aspose.Slides for PHP via Java به شما امکان می‌دهد نوع فایل برای یک شیء نهفته تنظیم کنید، به‌طوری که بتوانید داده‌های فریم OLE یا پسوند آن را به‌روزرسانی کنید.

این کد PHP نشان می‌دهد چگونه نوع فایل را برای یک شیء OLE نهفته به `zip` تنظیم کنید:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// نوع فایل را به ZIP تغییر دهید.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **تنظیم تصاویر آیکون و عناوین برای اشیاء نهفته**

پس از جاگذاری یک شیء OLE، یک پیش‌نمایش شامل تصویر آیکون به‌صورت خودکار اضافه می‌شود. این پیش‌نمایش همان چیزی است که کاربران پیش از دسترسی یا باز کردن شیء OLE می‌بینند. اگر بخواهید از یک تصویر و متن خاص به‌عنوان عناصر در پیش‌نمایش استفاده کنید، می‌توانید با استفاده از Aspose.Slides for PHP via Java تصویر آیکون و عنوان را تنظیم کنید.

این کد PHP نشان می‌دهد چگونه تصویر آیکون و عنوان را برای یک شیء نهفته تنظیم کنید:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// افزودن یک تصویر به منابع ارائه.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// تنظیم عنوان و تصویر برای پیش‌نمایش OLE.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **جلوگیری از تغییر اندازه و موقعیت فریم شیء OLE**

پس از اینکه یک شیء OLE مرتبط را به یک اسلاید ارائه اضافه کردید، هنگام باز کردن ارائه در PowerPoint ممکن است پیغامی مبنی بر به‌روز رسانی لینک‌ها دریافت کنید. کلیک بر دکمه «Update Links» می‌تواند اندازه و موقعیت فریم شیء OLE را تغییر دهد زیرا PowerPoint داده‌ها را از شیء OLE مرتبط به‌روز می‌کند و پیش‌نمایش شیء را تازه می‌سازد. برای جلوگیری از این اعلان، متد [setUpdateAutomatic](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) کلاس [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) را با `false` فراخوانی کنید:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$oleFrame->setUpdateAutomatic(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **استخراج فایل‌های نهفته**

Aspose.Slides for PHP via Java به شما امکان می‌دهد فایل‌های نهفته در اسلایدها به‌عنوان اشیاء OLE را به این شکل استخراج کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ایجاد کنید که شامل اشیاء OLE موردنظر برای استخراج باشد.  
2. در تمام اشکال موجود در ارائه حلقه بزنید و به اشکال [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) دسترسی پیدا کنید.  
3. داده‌های فایل‌های نهفته را از فریم‌های شیء OLE استخراج کرده و بر روی دیسک بنویسید.  

این کد PHP نشان می‌دهد چگونه فایل‌های نهفته در یک اسلاید را به‌عنوان اشیاء OLE استخراج کنید:

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

## **سؤالات متداول**

**آیا محتویات OLE هنگام خروجی گرفتن اسلایدها به PDF/تصاویر رندر می‌شود؟**

آنچه روی اسلاید قابل رؤیت است رندر می‌شود — آیکون/تصویر جایگزین (پیش‌نمایش). محتویات «زنده» OLE در حین رندر اجرا نمی‌شوند. در صورت نیاز، پیش‌نمایش سفارشی خود را تنظیم کنید تا ظاهر موردنظر در PDF خروجی تضمین شود.

برای حفظ فایل نهفته به‌عنوان پیوست PDF، متد [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) را با `true` فراخوانی کنید. این گزینه به‌صورت پیش‌فرض غیرفعال است. برای مثال و دستورالعمل‌های بررسی پیوست، به [Preserve Embedded OLE Files as PDF Attachments](/slides/fa/php-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments) مراجعه کنید.

**چگونه می‌توان یک شیء OLE را روی اسلاید قفل کرد تا کاربران نتوانند آن را در PowerPoint جابه‌جا یا ویرایش کنند؟**

شکل را قفل کنید: Aspose.Slides قفل‌های سطح شکل را فراهم می‌کند. این یک رمزنگاری نیست، اما به‌طور مؤثر از ویرایش‌ها و جابه‌جایی‌های ناخواسته جلوگیری می‌کند.

**آیا مسیرهای نسبی برای اشیاء OLE مرتبط در قالب PPTX حفظ می‌شوند؟**

در PPTX اطلاعات «مسیر نسبی» موجود نیست — فقط مسیر کامل ذخیره می‌شود. مسیرهای نسبی در قالب قدیمی PPT یافت می‌شوند. برای قابلیت حمل، مسیرهای مطلق قابل اعتماد/URIهای قابل دسترس یا جاگذاری را ترجیح دهید.