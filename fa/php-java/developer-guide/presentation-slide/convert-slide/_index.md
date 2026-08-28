---
title: تبدیل اسلایدهای ارائه به تصویر در PHP
linktitle: اسلاید به تصویر
type: docs
weight: 35
url: /fa/php-java/convert-slide/
keywords: 
- تبدیل اسلاید
- استخراج اسلاید
- اسلاید به تصویر
- ذخیره اسلاید به عنوان تصویر
- اسلاید به EMF
- اسلاید به PNG
- اسلاید به JPEG
- اسلاید به بیت‌مپ
- اسلاید به TIFF
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "اسلایدها را از ارائه‌های PPT، PPTX و ODP به فرمت‌های تصویر PNG، JPEG، GIF، TIFF، EMF و سایر فرمت‌های تصویری در PHP با Aspose.Slides تبدیل کنید."
---
## **مقدمه**

Aspose.Slides for PHP via Java می‌تواند اسلایدهای تک‌تکی از ارائه‌های PowerPoint و OpenDocument را به فرمت‌های تصویری PNG، JPEG، GIF، TIFF و سایر فرمت‌ها رندر کند.

برای تبدیل یک اسلاید به تصویر، مراحل زیر را دنبال کنید:

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) بارگذاری کنید.
2. اسلایدی که می‌خواهید رندر کنید را انتخاب کنید.
3. در صورت لزوم، رندرینگ را با کلاس‌های [RenderingOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/renderingoptions/) یا [TiffOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/) پیکربندی کنید.
4. متد [Slide::getImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/#getImage) را فراخوانی کنید. این متد یک شیء [IImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/iimage/) را بر می‌گرداند.
5. متد [IImage::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/iimage/#save) را فراخوانی کنید و فرمت خروجی را با مقدار [ImageFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imageformat/) مشخص کنید.

## **تبدیل یک اسلاید به تصویر PNG**

ساده‌ترین تبدیل از تنظیمات پیش‌فرض رندرینگ استفاده می‌کند. شیء [IImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/iimage/) حاصل می‌تواند در حافظه پردازش یا در یک فایل ذخیره شود.

مثال PHP زیر اسلاید اول را رندر کرده و به عنوان تصویر PNG ذخیره می‌کند:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage();
    try {
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **تبدیل اسلایدها به تصویر با اندازه‌های سفارشی**

از overload متد [Slide::getImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/#getImage) که مقدار [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) می‌گیرد استفاده کنید تا اسلاید را با ابعاد پیکسلی دقیق رندر کنید.

مثال زیر یک تصویر JPEG با ابعاد ۱۸۲۰ × ۱۰۴۰ ایجاد می‌کند:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($imageSize);
    try {
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **تبدیل اسلایدها با یادداشت‌ها و نظرات به تصویر**

به طور پیش‌فرض، تصاویر اسلاید شامل یادداشت‌ها یا نظرات نیستند. یک شیء [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/notescommentslayoutingoptions/) را به متد [RenderingOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) پاس دهید تا مکان نمایش یادداشت‌ها و نظرات را کنترل کنید.

مثال زیر یادداشت‌های کوتاه شده را زیر اسلاید و نظرات را به راست آن قرار می‌دهد:

```php
use aspose\slides\CommentsPositions;
use aspose\slides\ImageFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$scaleX = 2;
$scaleY = $scaleX;

$commentsAreaColor = new Java("java.awt.Color", 250, 235, 215);

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setNotesPosition(NotesPositions::BottomTruncated);
$layoutOptions->setCommentsPosition(CommentsPositions::Right);
$layoutOptions->setCommentsAreaWidth(500);
$layoutOptions->setCommentsAreaColor($commentsAreaColor);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($renderingOptions, $scaleX, $scaleY);
    try {
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
در تبدیل اسلاید به تصویر، مقدار [BottomFull](https://reference.aspose.com/slides/fa/php-java/aspose.slides/notespositions/) را به متد [NotesCommentsLayoutingOptions::setNotesPosition](https://reference.aspose.com/slides/fa/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) پاس ندهید. یادداشت‌ها ممکن است متنی بیشتر از اندازه ثابت تصویر داشته باشند. به جای آن از [BottomTruncated](https://reference.aspose.com/slides/fa/php-java/aspose.slides/notespositions/) استفاده کنید.
{{% /alert %}}

## **تبدیل اسلایدها به تصویر با استفاده از گزینه‌های TIFF**

کلاس [TiffOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/) به شما امکان کنترل اندازه، وضوح و سایر ویژگی‌های تصویر TIFF رندر شده را می‌دهد.

مثال زیر اسلاید اول را به عنوان تصویر TIFF با ابعاد ۲۱۶۰ × ۲۸۸۰ و وضوح ۳۰۰ DPI رندر می‌کند:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\TiffOptions;

$imageSize = new Java("java.awt.Dimension", 2160, 2880);

$tiffOptions = new TiffOptions();
$tiffOptions->setImageSize($imageSize);
$tiffOptions->setDpiX(300);
$tiffOptions->setDpiY(300);

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($tiffOptions);
    try {
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
پشتیبانی از TIFF در نسخه‌های Java قدیمی‌تر از JDK 9 تضمین نمی‌شود.
{{% /alert %}}

## **تبدیل تمام اسلایدها به تصویر**

از مجموعه اسلایدها عبور کنید تا کل ارائه را به مجموعه‌ای از تصاویر تبدیل کنید. اسلایدهای مخفی شامل می‌شوند مگر اینکه به‌طور صریح آن‌ها را نادیده بگیرید.

مثال زیر هر اسلاید را به عنوان تصویر JPEG با عوامل مقیاس افقی و عمودی ۲ رندر می‌کند:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("Slide_" . $index . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **ایجاد خروجی Enhanced Metafile**

Enhanced Metafile (EMF) زمانی مفید است که گرافیک‌های برداری باید با Microsoft Office یا دیگر برنامه‌های ویندوزی که از metafileهای ویندوز پشتیبانی می‌کنند، مبادله شوند. برخلاف تصویر پیکسل‌محور، یک EMF می‌تواند عملیات رسم برداری را حفظ کند به‌طوری که بدون از دست دادن وضوح مقیاس می‌شود. با این حال، EMF عمدتاً یک فرمت سازگاری برای برنامه‌هایی است که از metafileهای ویندوز پشتیبانی می‌کنند و نه یک فرمت تعویض عمومی. علاوه بر این، محتوای پیچیده اسلاید، مانند تصاویر بیت‌مپ و برخی افکت‌ها، ممکن است به‌صورت عناصر رستری در داخل کانتینر متافایل برداری ذخیره شوند.

### **صادر کردن اسلاید به EMF**

متد [Slide::writeAsEmf](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/#writeAsEmf) یک اسلاید را به یک جریان هدف در فرمت EMF می‌نویسد. مثال زیر یک ارائه را بارگذاری می‌کند، اسلاید اول را انتخاب می‌کند و آن را به یک جریان فایل EMF می‌نویسد:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.FileOutputStream", "Slide_0.emf");
    try {
        $slide->writeAsEmf($emfStream);
    } finally {
        $emfStream->close();
    }
} finally {
    $presentation->dispose();
}
```

صدا‌گذار مالک جریان پاس داده شده به [Slide::writeAsEmf](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/#writeAsEmf) است و مسئول بستن آن است، همان‌طور که در بالا نشان داده شد.

### **تبدیل تصویر SVG به EMF و افزودن آن به ارائه**

از [SvgImage::writeAsEmf](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgimage/#writeAsEmf) برای تبدیل محتوای SVG به EMF استفاده کنید. بایت‌های حاصل می‌توانند از طریق [ImageCollection::addImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagecollection/#addImage) به ارائه اضافه شوند و با [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/#addPictureFrame) روی یک اسلاید قرار گیرند.

مثال زیر یک [SvgImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgimage/) از کد SVG ایجاد می‌کند، آن را به یک EMF در حافظه تبدیل می‌کند، متافایل را در اسلاید اول درج می‌کند و ارائه را ذخیره می‌نماید:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$svgContent = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>';
$svgImage = new SvgImage($svgContent);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $svgImage->writeAsEmf($emfStream);

        $emfData = $emfStream->toByteArray();
        $image = $presentation->getImages()->addImage($emfData);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, $image);
    } finally {
        $emfStream->close();
    }

    $presentation->save("Presentation_with_emf.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[SvgImage::writeAsEmf](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgimage/#writeAsEmf) مالکیت جریان مقصد را تصاحب نمی‌کند. یک [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) تمام داده‌های تولید شده را در حافظه ذخیره می‌کند، بنابراین قبل از فراخوانی `toByteArray` نیازی به تنظیم مجدد موقعیت نیست. آرایه بایتی برگردانده‌شده پس از بسته شدن جریان نیز معتبر می‌ماند.

تولید EMF در سیستم‌عامل‌های پشتیبانی‌شده توسط Aspose.Slides for PHP via Java و پیکربندی JDK موجود است، اما رندر ممکن است بین سکوها متفاوت باشد وقتی که قلم‌ها یا وابستگی‌های گرافیکی در دسترس نباشند. قلم‌های مورد استفاده در محتوای منبع را نصب کنید یا جایگزین‌های مناسب پیکربندی کنید، [نیازمندی‌های پلتفرم](/slides/fa/php-java/system-requirements/) برای Aspose.Slides for PHP via Java را دنبال کنید و نتیجه را در برنامه هدف مصرف‌کننده EMF اعتبارسنجی کنید. برنامه‌های لینوکس و macOS اغلب پشتیبانی محدود یا ناسازگاری برای نمایش و ویرایش metafileهای ویندوز دارند.

## **رندر رنگی ایموجی‌ها**

{{% alert title="Note" color="info" %}}
برای رندر صحیح ایموجی‌های رنگی هنگام تبدیل اسلایدهای ارائه به تصویر، قلم‌های ایموجی مورد استفاده در ارائه باید نصب شده و در سیستم performing conversion قابل دسترسی باشند. به‌عنوان مثال، اگر ارائه از **Segoe UI Emoji** استفاده کند و این قلم موجود نباشد، ایموجی‌ها ممکن است به صورت تک‌رنگ در تصاویر خروجی ظاهر شوند.
{{% /alert %}}

## **سوالات متداول**

**آیا Aspose.Slides قابلیت رندر اسلایدها با انیمیشن‌ها را دارد؟**

خیر. متد [Slide::getImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/#getImage) یک تصویر ثابت از اسلاید را رندر می‌کند و انیمیشن‌ها را صادر نمی‌کند.

**آیا می‌توان اسلایدهای مخفی را به عنوان تصویر صادر کرد؟**

بله. اسلایدهای مخفی می‌توانند همانند اسلایدهای عادی رندر شوند. آنها را در حلقه پردازش گنجانده کنید، همان‌طور که در مثال بالا نشان داده شد.

**آیا سایه‌ها و سایر افکت‌ها در تصاویر اسلاید حفظ می‌شوند؟**

بله. Aspose.Slides سایه‌ها، شفافیت و سایر افکت‌های گرافیکی پشتیبانی‌شده را در تصاویر اسلاید رندر می‌کند.