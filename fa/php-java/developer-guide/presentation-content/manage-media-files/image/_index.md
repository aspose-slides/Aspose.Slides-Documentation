---
title: بهینه‌سازی مدیریت تصویر در ارائه‌ها با استفاده از PHP
linktitle: مدیریت تصاویر
type: docs
weight: 10
url: /fa/php-java/image/
keywords:
- اضافه کردن تصویر
- اضافه کردن عکس
- اضافه کردن بیت‌مپ
- جایگزینی تصویر
- جایگزینی عکس
- از وب
- پس‌زمینه
- افزودن PNG
- افزودن JPG
- افزودن SVG
- منابع خارجی SVG
- حل‌کننده SVG
- تصاویر SVG لینک‌شده
- فونت‌های SVG
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
description: "بهینه‌سازی مدیریت تصویر در PowerPoint و OpenDocument با Aspose.Slides برای PHP از طریق Java، بهبود عملکرد و خودکارسازی جریان کار شما."
---
## **مقدمه**

تصاویر ارائه‌ها را جذاب‌تر و بصری‌تر می‌کنند. در Microsoft PowerPoint می‌توانید عکس‌ها را از فایل‌ها، اینترنت یا منابع دیگر به اسلایدها اضافه کنید. به‌طور مشابه، Aspose.Slides به شما امکان می‌دهد تا تصاویر را به اسلایدهای ارائه به چندین روش اضافه کنید.

{{% alert  title="نکته" color="primary" %}} 

Aspose مبدل‌های رایگانی را ارائه می‌دهد—[JPEG به PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG به PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—که به شما امکان می‌دهد به سرعت ارائه‌ها را از تصاویر ایجاد کنید. 

{{% /alert %}} 

{{% alert title="اطلاعات" color="info" %}}

اگر می‌خواهید تصویری را به‌عنوان یک قاب عکس اضافه کنید—به‌ویژه اگر قصد دارید آن را تغییر اندازه دهید، اثرات اعمال کنید یا از گزینه‌های استاندارد قالب‌بندی استفاده کنید—به [قاب عکس](/slides/fa/php-java/picture-frame/) مراجعه کنید. 

{{% /alert %}} 

{{% alert title="توجه" color="warning" %}}

می‌توانید تصاویر را از یک فرمت به فرمت دیگر تبدیل کنید. صفحه‌های زیر را ببینید: تبدیل [image به JPG](https://products.aspose.com/slides/fa/php-java/conversion/image-to-jpg/)، [JPG به image](https://products.aspose.com/slides/fa/php-java/conversion/jpg-to-image/)، [JPG به PNG](https://products.aspose.com/slides/fa/php-java/conversion/jpg-to-png/)، [PNG به JPG](https://products.aspose.com/slides/fa/php-java/conversion/png-to-jpg/)، [PNG به SVG](https://products.aspose.com/slides/fa/php-java/conversion/png-to-svg/)، و [SVG به PNG](https://products.aspose.com/slides/fa/php-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides از تصاویر در فرمت‌های محبوبی مانند JPEG، PNG، BMP، GIF و سایرین پشتیبانی می‌کند. 

## **اضافه کردن تصاویر ذخیره‌شده به‌صورت محلی به اسلایدها**

می‌توانید یک یا چند تصویر ذخیره‌شده بر روی کامپیوتر خود را به یک اسلاید ارائه اضافه کنید. کد نمونه PHP زیر نشان می‌دهد چگونه یک تصویر را به اسلاید اضافه کنید:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $picture = null;
    $image = Images::fromFile("image.png");
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
    $pres->dispose();
}
```

## **اضافه کردن تصاویر از وب به اسلایدها**

اگر تصویری که می‌خواهید به اسلاید اضافه کنید بر روی کامپیوتر شما ذخیره نشده باشد، می‌توانید آن را مستقیماً از وب اضافه کنید. 

کد نمونه PHP زیر نشان می‌دهد چگونه یک تصویر را از وب به اسلاید اضافه کنید:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $imageUrl = new Java("java.net.URL", "[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();

    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 1024);

        while (($read = java_values($inputStream->read($buffer, 0, $Array->getLength($buffer)))) != -1) {
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
    $pres->dispose();
}
```

## **اضافه کردن تصاویر به مستر اسلاید**

یک مستر اسلاید اطلاعاتی مانند تم و طرح‌بندی اسلایدهای استفاده‌کننده از آن را ذخیره و کنترل می‌کند. هنگامی که تصویری را به یک مستر اسلاید اضافه می‌کنید، تصویر در هر اسلایدی که بر پایه آن مستر ساخته شده است ظاهر می‌شود. 

کد نمونه PHP زیر نشان می‌دهد چگونه یک تصویر را به یک مستر اسلاید اضافه کنید:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();

    $picture = null;
    $image = Images::fromFile("image.png");
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
    $pres->dispose();
}
```

## **اضافه کردن تصاویر به‌عنوان پس‌زمینه اسلاید**

می‌توانید یک تصویر را به‌عنوان پس‌زمینه یک یا چند اسلاید استفاده کنید. برای جزئیات، به *[تنظیم تصاویر به‌عنوان پس‌زمینه برای اسلایدها](/slides/fa/php-java/presentation-background/#setting-images-as-background-for-slides)* مراجعه کنید.

## **اضافه کردن SVG به ارائه‌ها**

محتویات SVG می‌تواند با استفاده از کلاس [SvgImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgimage/) به یک ارائه اضافه شود. شیء تصویر SVG حاصل سپس می‌تواند به مجموعه تصاویر ارائه اضافه شده و برای ایجاد یک قاب عکس استفاده شود.

مثال PHP زیر یک رشته SVG خودکفا را وارد می‌کند. تمام تصاویر، سبک‌ها و سایر منابع استفاده‌شده توسط این SVG به‌صورت مستقیم در محتوای SVG تعبیه می‌شوند.

```php
$svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" .
    "    <rect width='320' height='180' fill='#4F81BD'/>" .
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" .
    "</svg>";

$presentation = new Presentation();
try {
    $svgImage = new SvgImage($svgContent);
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("self-contained-svg.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **وارد کردن محتوای SVG با منابع خارجی**

فایل‌های SVG صادر شده از ابزارهای طراحی، ویرایشگرهای نمودار، سیستم‌های آیکون و خطوط لوله وب ممکن است به منابعی که خارج از سند SVG ذخیره شده‌اند ارجاع دهند. برای مثال، یک SVG می‌تواند شامل یک لینک تصویر مانند `images/photo.png`، مقدار CSS `url(...)`، یا URL فونت باشد.

برای وارد کردن چنین محتوای SVG، یک پیاده‌سازی از [ExternalResourceResolver](https://reference.aspose.com/slides/fa/php-java/aspose.slides/externalresourceresolver/) ایجاد کنید و آن را به همراه یک URI پایه به سازنده مناسب [SvgImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgimage/) ارسال کنید. URI پایه مکان سند SVG را شناسایی می‌کند و برای حل لینک‌های نسبی استفاده می‌شود.

شیء تصویر SVG دسترسی به اطلاعات درباره SVG واردشده را فراهم می‌کند:

- `getSvgContent()` رشته SVG markup را به‌عنوان یک رشته برمی‌گرداند.
- `getSvgData()` محتوای SVG را به‌عنوان آرایه بایت برمی‌گرداند.
- `getBaseUri()` URI پایه استفاده‌شده برای لینک‌های نسبی را برمی‌گرداند.
- `getExternalResourceResolver()` حل‌کننده اختصاص داده‌شده به تصویر SVG را برمی‌گرداند.

### **پیاده‌سازی یک حل‌کننده منبع خارجی**

این حل‌کننده دو متد دارد:

- `resolveUri` URI پایه و لینک منبع نسبی را ترکیب کرده و یک URI مطلق برمی‌گرداند. وقتی لینک قابل حل نیست یا مجاز نیست `null` برگردانید.
- `getEntity` یک جریان خواندنی برای URI منبع مطلق برمی‌گرداند. وقتی منبع گمشده، مسدود یا در دسترس نیست `null` برگردانید. در صورت مناسب می‌تواند یک جریان جایگزین نیز برگردانده شود.

حل‌کننده زیر فقط منابع لینک‌شده را از یک دایرکتوری محلی مجاز بارگذاری می‌کند. منابع شبکه و مسیرهای خارج از دایرکتوری مجاز مسدود می‌شوند. یک تصویر جایگزین اختیاری برای لینک‌های تصویر حل‌نشده برگردانده می‌شود.

```php
class LocalSvgResourceResolver extends ExternalResourceResolver
{
    private $allowedRoot;
    private $fallbackImageData;

    public function __construct($allowedRoot, $fallbackImageData)
    {
        parent::__construct();

        $Paths = new JavaClass("java.nio.file.Paths");
        $this->allowedRoot = $Paths->get($allowedRoot)->toAbsolutePath()->normalize();
        $this->fallbackImageData = $fallbackImageData;
    }

    public function resolveUri($baseUri, $relativeUri)
    {
        if ($baseUri === null || trim(java_values($baseUri)) === "" ||
            $relativeUri === null || trim(java_values($relativeUri)) === "") {
            return null;
        }

        try {
            $URI = new JavaClass("java.net.URI");
            $baseAddress = $URI->create($baseUri);
            $absoluteAddress = $baseAddress->resolve($relativeUri);

            // این حل‌کننده عمداً فقط فایل‌های محلی را اجازه می‌دهد.
            if (strcasecmp(java_values($absoluteAddress->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($absoluteAddress)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            return $resourcePath->toUri()->toString();
        } catch (JavaException $e) {
            return null;
        }
    }

    public function getEntity($absoluteUri)
    {
        try {
            $URI = new JavaClass("java.net.URI");
            $resourceUri = $URI->create($absoluteUri);

            if (strcasecmp(java_values($resourceUri->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($resourceUri)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            $Files = new JavaClass("java.nio.file.Files");
            if (java_values($Files->exists($resourcePath))) {
                return $Files->newInputStream($resourcePath);
            }

            // فقط برای منابع تصویری از یک جایگزین استفاده کنید. بازگرداندن یک جریان تصویر
            // برای فونت یا استایل‌شِیت گمشده معتبر نخواهد بود.
            if ($this->fallbackImageData !== null && $this->isImageFile($resourcePath)) {
                return new Java("java.io.ByteArrayInputStream", $this->fallbackImageData);
            }
        } catch (JavaException $e) {
            return null;
        }

        return null;
    }

    private function isInsideAllowedRoot($resourcePath)
    {
        return java_values($resourcePath->normalize()->startsWith($this->allowedRoot));
    }

    private function isImageFile($path)
    {
        $fileName = strtolower(java_values($path->getFileName()->toString()));

        return str_ends_with($fileName, ".png") ||
            str_ends_with($fileName, ".jpg") ||
            str_ends_with($fileName, ".jpeg") ||
            str_ends_with($fileName, ".gif") ||
            str_ends_with($fileName, ".bmp");
    }
}
```

### **حل‌کردن منابع لینک‌شده هنگام وارد کردن SVG**

فرض کنید `assets/diagram.svg` شامل یک ارجاع نسبی مانند زیر باشد:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

مثال PHP زیر URI فایل SVG را به‌عنوان URI پایه ارسال می‌کند و یک حل‌کننده سفارشی فراهم می‌نماید. حل‌کننده لینک تصویر نسبی را به یک URI مطلق تبدیل کرده و یک جریان شامل منبع لینک‌شده را برمی‌گرداند در حالی که Aspose.Slides SVG را پردازش می‌کند.

```php
$Paths = new JavaClass("java.nio.file.Paths");
$Files = new JavaClass("java.nio.file.Files");
$StandardCharsets = new JavaClass("java.nio.charset.StandardCharsets");

$svgFilePath = $Paths->get("assets", "diagram.svg")->toAbsolutePath()->normalize();
$assetDirectory = $svgFilePath->getParent();

$svgData = $Files->readAllBytes($svgFilePath);
$svgContent = new Java("java.lang.String", $svgData, $StandardCharsets->UTF_8);

// URI پایه مکان سند SVG را نشان می‌دهد.
$baseUri = $svgFilePath->toUri()->toString();

$fallbackImageData = null;
$fallbackImagePath = $assetDirectory->resolve("fallback.png");
if (java_values($Files->exists($fallbackImagePath))) {
    $fallbackImageData = $Files->readAllBytes($fallbackImagePath);
}

$resolver = new LocalSvgResourceResolver(java_values($assetDirectory->toString()), $fallbackImageData);
$svgImage = new SvgImage($svgContent, $resolver, $baseUri);

// شیء تصویر SVG محتوای منبع، داده‌های باینری، URI پایه و حل‌کننده را در اختیار می‌گذارد.
$importedContent = $svgImage->getSvgContent();
$importedData = $svgImage->getSvgData();
$importedBaseUri = $svgImage->getBaseUri();
$importedResolver = $svgImage->getExternalResourceResolver();

$presentation = new Presentation();
try {
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("svg-with-linked-resources.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

کلاس `SvgImage` همچنین overloadهایی ارائه می‌دهد که داده‌های SVG را به‌عنوان آرایه بایت یا یک جریان ورودی می‌پذیرند، به‌همراه یک حل‌کننده منبع خارجی و یک URI پایه.

{{% alert title="مهم" color="warning" %}}

حل‌کننده منابع، منابع خارجی را در حین پردازش و رندر SVG توسط Aspose.Slides در دسترس می‌گذارد. این حل‌کننده محتوای اصلی SVG را تغییر نمی‌دهد یا به‌صورت خودکار منابع حل‌شده را در آن درج نمی‌کند.

هنگامی که یک تصویر SVG به مجموعه تصاویر ارائه اضافه می‌شود، فایل PPTX می‌تواند هر دو نمای SVG اصلی و یک تصویر رستر جایگزین را شامل شود. یک منبع لینک‌شده می‌تواند در تصویر جایگزین تولید شده ظاهر شود در حالی که لینک نسبی مانند `images/photo.png` در SVG ذخیره‌شده بدون تغییر می‌ماند. برنامه‌ای که نمای SVG بومی را رندر می‌کند ممکن است محتوای لینک‌شده را در صورت عدم دسترسی به منبع خارجی اصلی نادیده بگیرد.

{{% /alert %}}

### **ایجاد یک تصویر SVG قابل حمل**

برای ایجاد یک تصویر SVG که به فایل‌های خارجی وابسته نیست، قبل از ساخت `SvgImage`، SVG را خودکفا کنید. برای مثال، URLهای تصویر لینک‌شده را با URIهای `data:` که شامل داده تصویر هستند جایگزین کنید:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

پس از اینکه تمام منابع مورد نیاز در محتوای SVG تعبیه شدند، `SvgImage` را ایجاد کنید، آن را به مجموعه تصاویر ارائه اضافه کنید و همان‌طور که در مثال قبلی نشان داده شد، در یک قاب عکس وارد کنید.

### **برخورد با منابع گمشده یا مسدودشده**

`null` را از `resolveUri` برگردانید وقتی URI منبع نامعتبر، ممنوع یا غیرقابل حل باشد. `null` را از `getEntity` برگردانید وقتی منبع قابل خواندن نباشد. Aspose.Slides در صورت امکان پردازش SVG را بدون آن منبع ادامه می‌دهد.

یک جریان جایگزین می‌تواند برای منبع گمشده برگردانده شود، اما محتویات آن باید با نوع منبع درخواستی سازگار باشد. برای مثال، فقط برای یک تصویر گمشده یک جریان تصویر برگردانید، نه برای یک فونت یا استایل‌شیٹ.

{{% alert title="امنیت" color="warning" %}}

از حل مسیرهای فایل دلخواه یا URLهای شبکه بدون محدودیت از فایل‌های SVG غیرقابل اعتماد خودداری کنید. طرح‌ها، دایرکتوری‌ها و میزبان‌های مجاز را محدود کنید. برای منابع شبکه، همچنین زمان‌سنجی اتصال، محدودیت‌های اندازه پاسخ و اعتبارسنجی محتوا را اعمال کنید.

{{% /alert %}}

## **تبدیل SVG به مجموعه‌ای از اشکال**

Aspose.Slides می‌تواند یک SVG را به مجموعه‌ای از شکل‌ها تبدیل کند، مشابه عملکرد متناظر در PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

این عملکرد توسط overloadی از متد [addGroupShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/addgroupshape/) در کلاس [ShapeCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/) ارائه می‌شود که یک شیء [SvgImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgimage/) را به‌عنوان اولین آرگومان می‌گیرد.

کد نمونه PHP زیر نشان می‌دهد چگونه از این متد برای تبدیل یک فایل SVG به مجموعه‌ای از شکل‌ها استفاده کنید:

```php
// نام فایل SVG منبع.
$svgFileName = "sample.svg";

// نام فایل خروجی ارائه.
$outPptxPath = "presentation.pptx";

// یک ارائه جدید ایجاد کنید.
$presentation = new Presentation();
try {
    // محتویات فایل SVG را بخوانید.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $svgFileName));
    try {
        $svgContent = $Array->newInstance($Byte, $dis->available());
        $dis->readFully($svgContent);
    } finally {
        if (!java_is_null($dis)) {
            $dis->close();
        }
    }

    // یک شیء SvgImage ایجاد کنید.
    $svgImage = new SvgImage($svgContent);

    // اندازه اسلاید را دریافت کنید.
    $slideSize = $presentation->getSlideSize()->getSize();

    // تصویر SVG را به یک گروه از شکل‌ها تبدیل کنید و به اندازه اسلاید مقیاس‌گذاری کنید.
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape(
        $svgImage,
        0.0,
        0.0,
        $slideSize->getWidth(),
        $slideSize->getHeight()
    );

    // ارائه را در قالب PPTX ذخیره کنید.
    $presentation->save($outPptxPath, SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $presentation->dispose();
}
```

## **اضافه کردن تصاویر به‌صورت EMF به اسلایدها**

Aspose.Slides برای PHP از طریق Java به شما امکان می‌دهد تا تصاویر EMF را از ورق‌های Excel با Aspose.Cells تولید کنید و آنها را به اسلایدهای ارائه اضافه کنید.

کد نمونه PHP زیر نشان می‌دهد چگونه این کار را انجام دهید:

```php
$book = new Workbook("chart.xlsx");
$sheet = $book->getWorksheets()->get(0);

$options = new ImageOrPrintOptions();
$options->setHorizontalResolution(200);
$options->setVerticalResolution(200);
$options->setImageType(ImageType::EMF);

// ذخیره کتاب کار به یک جریان.
$sr = new SheetRender($sheet, $options);
$pres = new Presentation();
try {
    $pres->getSlides()->removeAt(0);

    for ($j = 0; $j < java_values($sr->getPageCount()); $j++) {
        $emfSheetName = "test" . $sheet->getName() . " Page" . ($j + 1) . ".out.emf";
        $sr->toImage($j, $emfSheetName);

        // افزودن فایل به همان شکل تا تصویر به‌صورت برداری EMF باقی بماند به‌جای رستر شدن.
        $picture = null;
        $imageStream = new Java("java.io.FileInputStream", $emfSheetName);
        try {
            $picture = $pres->getImages()->addImage($imageStream);
        } finally {
            $imageStream->close();
        }

        $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle,
            0,
            0,
            $pres->getSlideSize()->getSize()->getWidth(),
            $pres->getSlideSize()->getSize()->getHeight(),
            $picture
        );
    }

    $pres->save("output.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **جایگزینی تصاویر در مجموعه تصاویر**

Aspose.Slides به شما اجازه می‌دهد تا تصاویر ذخیره‌شده در مجموعه تصویر یک ارائه، از جمله تصاویری که توسط شکل‌های اسلاید استفاده می‌شوند، جایگزین کنید. این بخش چندین روش برای به‌روزرسانی تصاویر در مجموعه را توصیف می‌کند. می‌توانید یک تصویر را با استفاده از داده بایت خالص، یک نمونه [IImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/iimage/) یا تصویر دیگری که از قبل در مجموعه وجود دارد، جایگزین کنید.

مراحل زیر را دنبال کنید:

1. پرزنتیشن حاوی تصاویر را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) بارگذاری کنید.
2. یک تصویر جدید را از فایل به‌صورت آرایه بایت بارگذاری کنید.
3. تصویر هدف را با تصویر جدید با استفاده از آرایه بایت جایگزین کنید.
4. در روش دوم، تصویر را به‌صورت یک شیء [IImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/iimage/) بارگذاری کنید و تصویر هدف را با آن شیء جایگزین کنید.
5. در روش سوم، تصویر هدف را با تصویری که از پیش در مجموعه تصویر ارائه وجود دارد، جایگزین کنید.
6. پرزنتیشن تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

```php
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
$presentation = new Presentation("sample.pptx");
try {
    // روش اول.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new JavaClass("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // روش دوم.
    $newImage = Images::fromFile("image1.png");
    try {
        $oldImage = $presentation->getImages()->get_Item(1);
        $oldImage->replaceImage($newImage);
    } finally {
        if (!java_is_null($newImage)) {
            $newImage->dispose();
        }
    }

    // روش سوم.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));

    // ذخیره ارائه در یک فایل.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="اطلاعات" color="info" %}}

با مبدل رایگان [Text to GIF](https://products.aspose.app/slides/fa/text-to-gif) Aspose می‌توانید به سادگی متن را انیمیت کنید و GIF از متن ایجاد کنید. 

{{% /alert %}}

## **سؤالات متداول**

**آیا رزولوشن تصویر اصلی پس از درج حفظ می‌شود؟**

بله. پیکسل‌های منبع حفظ می‌شوند، اما ظاهر نهایی بستگی به این دارد که چگونه [picture](/slides/fa/php-java/picture-frame/) در اسلاید مقیاس‌بندی شده و هر گونه فشرده‌سازی اعمال‌شده هنگام ذخیره.

**بهترین راه برای جایگزینی لوگوی یکسان در ده‌ها اسلاید به‌صورت همزمان چیست؟**

لوگو را بر روی مستر اسلاید یا یک طرح‌بندی قرار دهید و آن را در مجموعه تصویر ارائه جایگزین کنید—به‌روزرسانی‌ها به تمام عناصری که از آن منبع استفاده می‌کنند، انتشار می‌یابد.

**آیا یک SVG واردشده می‌تواند به اشکال قابل ویرایش تبدیل شود؟**

بله. می‌توانید SVG را به یک گروه از اشکال تبدیل کنید، پس از آن بخش‌های منفرد قابل ویرایش با ویژگی‌های استاندارد شکل می‌شوند.

**چگونه می‌توانم یک تصویر را به‌عنوان پس‌زمینه برای چندین اسلاید به‌صورت همزمان تنظیم کنم؟**

تصویر را به‌عنوان پس‌زمینه [تخصیص دهید](/slides/fa/php-java/presentation-background/) بر روی مستر اسلاید یا طرح‌بندی مربوطه—هر اسلایدی که از آن مستر/طرح‌بندی استفاده می‌کند، پس‌زمینه را به ارث می‌برد.

**چگونه می‌توانم از بزرگ‌شدن بیش از حد یک ارائه به‌دلیل تعداد زیاد تصاویر جلوگیری کنم؟**

یک منبع تصویر را به‌جای تکرار استفاده کنید، رزولوشن‌های معقول انتخاب کنید، هنگام ذخیره فشرده‌سازی اعمال کنید و گرافیک‌های تکراری را در مستر نگه دارید در جایی که مناسب است.