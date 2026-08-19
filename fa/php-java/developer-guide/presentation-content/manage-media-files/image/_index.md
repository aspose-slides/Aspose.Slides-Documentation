---
title: بهینه‌سازی مدیریت تصویر در ارائه‌ها با استفاده از PHP
linktitle: مدیریت تصاویر
type: docs
weight: 10
url: /fa/php-java/image/
keywords:
- اضافه کردن تصویر
- اضافه کردن عکس
- جایگزینی تصویر
- مجموعه تصویر
- قاب تصویر
- تصویر پیوندی
- پس‌زمینه
- اضافه کردن PNG
- اضافه کردن JPG
- اضافه کردن SVG
- SVG به اشکال
- منابع SVG خارجی
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه تصاویر رستر و SVG را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای PHP via Java اضافه، بازاستفاده، پیونددهی، جایگزینی و مدیریت کنید."
---
## **معرفی**

Aspose.Slides for PHP via Java چند روش برای کار با تصاویر ارائه می‌دهد و هر یک هدف متفاوتی دارند. می‌توانید یک تصویر را در ارائه ذخیره کنید، در یک قاب تصویر نمایش دهید، به‌عنوان پس‌زمینه اسلاید استفاده کنید، به یک تصویر خارجی پیوند دهید، منبع تصویر مشترک را جایگزین کنید یا محتوای SVG را به اشکال قابل ویرایش تبدیل کنید.

این مقاله بر روی منابع تصویر و نحوه استفاده آنها در سراسر یک ارائه متمرکز است. برای برش، شفافیت، افکت‌ها، کشش و قالب‌بندی‌های دیگر اعمال‌شده به یک قاب تصویر منفرد، به [قاب تصویر](/slides/fa/php-java/picture-frame/) مراجعه کنید.

## **درک مدل تصویر**

مفاهیم API زیر مرتبط هستند اما قابل تعویض نیستند:

- [مجموعه تصویر ارائه](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagecollection/) منابع تصویری را که توسط ارائه استفاده می‌شوند ذخیره می‌کند. برای اضافه‌کردن داده تصویر و دریافت منبع [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) از `ImageCollection::addImage` استفاده کنید.
- یک [قاب تصویر](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) یک شکل است که تصویر را روی یک اسلاید، لایه یا مستر نمایش می‌دهد. برای قرار دادن منبع تصویر بر روی اسلاید از `ShapeCollection::addPictureFrame` استفاده کنید.
- پس‌زمینه اسلاید از تصویر به‌عنوان بخشی از رنگ‌آمیزی اسلاید استفاده می‌کند نه به‌عنوان یک شکل، لذا رفتار متفاوتی نسبت به قاب تصویر دارد.
- `PPImage::replaceImage` یک منبع تصویر را جایگزین می‌کند. اگر چندین عنصر ارائه از آن منبع استفاده کنند، همه از جایگزین استفاده می‌کنند.
- تبدیل SVG به اشکال، اشکال قابل ویرایش اسلاید ایجاد می‌کند. پس از تبدیل، محتوا دیگر به‌عنوان یک منبع تصویر واحد مدیریت نمی‌شود.

یک جریان کاری معمول به این ترتیب است: داده تصویر را به مجموعه تصویر اضافه کنید، یک [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) دریافت کنید، سپس آن منبع را در یک یا چند قاب تصویر یا پرکننده استفاده کنید.

## **افزودن تصویر جاسازی‌شده**

برای درج یک تصویر محلی، فایل را بارگذاری کنید، به مجموعه تصویر اضافه کنید و یک قاب تصویر که از `PPImage` بازگشتی استفاده می‌کند ایجاد کنید.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $image = Images::fromFile("photo.png");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

تصویری که به این شکل افزوده می‌شود در ارائه جاسازی می‌شود، بنابراین فایل نهایی به موجود بودن فایل تصویر اصلی وابسته نیست.

### **افزودن تصویر از وب**

وقتی تصویری از طریق HTTP یا HTTPS در دسترس باشد، بایت‌های آن را دانلود کنید، به مجموعه تصویر ارائه اضافه کنید و منبع تصویری بازگشتی را همانند یک تصویر محلی استفاده کنید.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $imageUrl = new Java("java.net.URL", "https://example.com/image.png");
    $connection = $imageUrl->openConnection();
    $connection->setConnectTimeout(10000);
    $connection->setReadTimeout(10000);

    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 8192);
        $bufferLength = $Array->getLength($buffer);

        while (($bytesRead = java_values($inputStream->read($buffer, 0, $bufferLength))) != -1) {
            $outputStream->write($buffer, 0, $bytesRead);
        }

        $ppImage = $presentation->getImages()->addImage($outputStream->toByteArray());
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $presentation->save("presentation-from-web.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

در برنامه‌های طولانی‌مدت، به‌جای ایجاد مکرر زیرساخت‌های شبکه، از یک کلاینت HTTP یا استراتژی مدیریت اتصال مناسب برای برنامه استفاده کنید. همچنین URLهای دوردست، اندازه پاسخ و نوع محتوا را وقتی منبع مورد اعتماد نیست، اعتبارسنجی کنید.

## **بازاستفاده از تصاویر در اسلایدها**

اگر همان تصویر بیش از یک‌بار مورد نیاز است، یک‌بار آن را به ارائه اضافه کنید و هنگام ایجاد قاب‌های تصویر بیشتر از [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) بازگشتی استفاده کنید. این کار از بارگذاری مکرر داده منبع جلوگیری می‌کند و رابطه بین منبع تصویر مشترک و استفاده‌های آن را واضح می‌کند.

برای گرافیک‌هایی که باید به‌طور خودکار در بسیاری از اسلایدها ظاهر شوند، مانند لوگوی شرکت، در نظر بگیرید که قاب تصویر را بر روی یک [مستر اسلاید](/slides/fa/php-java/slide-master/) یا لایه قرار دهید به‌جای افزودن شکل معادل به هر اسلاید.

## **استفاده از تصویر به‌عنوان پس‌زمینه اسلاید**

یک تصویر پس‌زمینه به پرکنندهٔ اسلاید اختصاص می‌یابد؛ به‌عنوان یک شکل قاب تصویر اضافه نمی‌شود. این برای موقعی مفید است که تصویر باید تمام پس‌زمینه اسلاید را پوشش دهد و نباید به‌عنوان یک شیء عادی اسلاید دست‌کاری شود.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = Images::fromFile("background.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("background-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

برای گزینه‌های پس‌زمینهٔ بیشتر، از جمله پس‌زمینه‌های مستر و لایه، به [پس‌زمینهٔ ارائه](/slides/fa/php-java/presentation-background/) مراجعه کنید.

## **تصاویر جاسازی‌شده و تصاویر پیوندی**

تصاویر جاسازی‌شده و پیوندی تعادل‌های متفاوتی در قابلیت حمل و اندازهٔ فایل دارند:

- **تصویر جاسازی‌شده:** داده تصویر داخل ارائه ذخیره می‌شود. ارائه خودکفا است، اما اندازهٔ فایل شامل داده تصویر می‌شود.
- **تصویر پیوندی:** ارائه مسیر یا URL یک تصویر خارجی را ذخیره می‌کند. این می‌تواند اندازهٔ ارائه را کاهش دهد، اما منبع خارجی باید در زمان باز کردن یا رندر کردن ارائه در دسترس باشد.

یک تصویر پیوندی می‌تواند از طریق `Picture::setLinkPathLong` (https://reference.aspose.com/slides/fa/php-java/aspose.slides/picture/) به مسیر یا URL خارجی اختصاص یابد، نه از طریق جاسازی داده تصویر.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, null);
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://example.com/image.png");

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

از تصاویر پیوندی فقط زمانی استفاده کنید که محیط استقرار بتواند به طور قابل اعتماد به منبع خارجی دسترسی داشته باشد. برای ارائه‌هایی که باید آفلاین کار کنند یا بین سیستم‌ها جابجا شوند، معمولاً تصاویر جاسازی‌شده ایمن‌تر هستند.

## **کار با تصاویر SVG**

SVG یک فرمت برداری است، بنابراین برای آیکن‌ها، نمودارها و سایر گرافیک‌هایی که باید بدون از دست دادن جزئیات مقیاس‌پذیر باشند، مفید است. Aspose.Slides هم به‌عنوان منبع تصویر و هم به‌عنوان منبعی برای اشکال قابل ویرایش اسلاید از SVG پشتیبانی می‌کند.

### **افزودن SVG به‌عنوان تصویر**

یک [SvgImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgimage/) ایجاد کنید، آن را به مجموعه تصویر اضافه کنید و منبع تصویر حاصل را در یک قاب تصویر قرار دهید.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("icon.svg");
    $svgImage = new SvgImage($svgContent);

    $ppImage = $presentation->getImages()->addImage($svgImage);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 200, $ppImage);

    $presentation->save("svg-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **فایل‌های SVG با منابع خارجی**

یک SVG می‌تواند به تصویرهای خارجی، stylesheetها یا فونت‌ها ارجاع دهد. برای این موارد، `SvgImage` سازندگویی ارائه می‌دهد که یک `[ExternalResourceResolver](https://reference.aspose.com/slides/fa/php-java/aspose.slides/externalresourceresolver/)` و یک URI پایه می‌پذیرند. resolver می‌تواند یک URI نسبی را به یک URI مطلق مجاز نگاشت کند و برای منبع درخواست‌شده یک جریان (stream) بازگرداند.

resolver منابع خارجی را هنگام پردازش SVG توسط Aspose.Slides در دسترس می‌گذارد، اما SVG را به یک سند خودمحافظ بازنویسی نمی‌کند. اگر SVG باید قابل حمل بماند، منابع مورد نیاز آن را داخل خود SVG جاسازی کنید، برای مثال با استفاده از URIهای `data:` برای تصاویر پیوندی.

وقتی فایل‌های SVG از منابع نامطمئن می‌آیند، طرح‌ها، موقعیت‌های فایل و میزبان‌هایی که resolver می‌تواند به آن‌ها دسترسی داشته باشد را محدود کنید. resolverهای شبکه باید زمان‌سنجی، محدودیت اندازه پاسخ و اعتبارسنجی محتوا را نیز اعمال کنند.

### **تبدیل SVG به اشکال قابل ویرایش**

Aspose.Slides می‌تواند یک SVG را به گروهی از اشکال قابل ویرایش اسلاید تبدیل کند، مشابه دستور متناظر PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

از overload `ShapeCollection::addGroupShape` (https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/addgroupshape/) که یک `SvgImage` می‌پذیرد برای انجام تبدیل استفاده کنید.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("diagram.svg");
    $svgImage = new SvgImage($svgContent);

    $slideSize = $presentation->getSlideSize()->getSize();
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addGroupShape($svgImage, 0, 0, $slideSize->getWidth(), $slideSize->getHeight());

    $presentation->save("editable-svg-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

از تبدیل SVG‑به‑اشکال زمانی استفاده کنید که عناصر برداری منفرد نیاز به ویرایش به‌عنوان اشکال PowerPoint داشته باشند. اگر SVG فقط برای نمایش کافی است، نگه‌داشتن آن به‌عنوان تصویر ساده‌تر است و از ایجاد بسیاری از اشکال جداگانه جلوگیری می‌کند.

## **جایگزینی یک منبع تصویر موجود**

زمانی که می‌خواهید یک منبع تصویر موجود را جایگزین کنید، از `PPImage::replaceImage` (https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) استفاده کنید. این به‌ویژه برای گرافیک‌های مشترکی مانند لوگوها مفید است.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $imageToReplace = $presentation->getImages()->get_Item(0);

    $replacementImage = Images::fromFile("new-logo.png");
    try {
        $imageToReplace->replaceImage($replacementImage);
    } finally {
        if (!java_is_null($replacementImage)) {
            $replacementImage->dispose();
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

اگر چندین قاب تصویر، پس‌زمینه، مستر یا لایه از همان منبع تصویر استفاده می‌کنند، جایگزینی آن منبع تمام استفاده‌ها را به‌روز می‌کند. اگر تنها یک قاب تصویر باید تغییر کند، به‌جای جایگزینی منبع مشترک، یک تصویر متفاوت به آن قاب اختصاص دهید.

`PPImage::replaceImage` همچنین overloadهایی ارائه می‌دهد که یک آرایه بایت یا یک `[PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/)` دیگر می‌پذیرند.

## **راهنمای عملی مدیریت تصویر**

### **کنترل اندازه ارائه**

تصاویر رستر بزرگ می‌توانند اندازهٔ ارائه را غیرضروری بزرگ کنند. از تصاویر منبع با ابعاد مناسب برای اندازهٔ نمایش موردنظر استفاده کنید، در صورت امکان منابع تصویر مشترک را بازاستفاده کنید و از جاسازی نسخه‌های تکراری یک گرافیک با وضوح کامل خودداری کنید.

برای تصاویر رستری که قبلاً در قاب‌های تصویر قرار گرفته‌اند، `PictureFillFormat::compressImage` (https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/) می‌تواند داده تصویر را بر اساس وضوح انتخابی و تنظیمات برش کاهش دهد. این پردازش قاب تصویر است نه مدیریت مجموعه تصویر، بنابراین برای عملیات قالب‌بندی مرتبط به [قاب تصویر](/slides/fa/php-java/picture-frame/) مراجعه کنید.

### **انتخاب بین محتوای جاسازی‌شده و پیوندی**

جاسازی، ارائه را قابل حمل می‌کند زیرا تمام داده‌های تصویر مورد نیاز با فایل همراه است. پیوند می‌تواند اندازهٔ فایل را کاهش دهد، اما وابستگی خارجی ایجاد می‌کند. از پیوند فقط زمانی استفاده کنید که این وابستگی قابل قبول و ثابت باشد.

### **بازاستفاده از برند مشترک**

برای لوگوها، واترمارک‌ها یا گرافیک‌های تزئینی تکراری، از یک منبع تصویر استفاده کنید و آن را بازاستفاده کنید. اگر گرافیک متعلق به طراحی ارائه است نه به محتوای اسلاید، آن را بر روی یک مستر یا لایه قرار دهید تا توسط اسلایدهای مناسب به ارث برسد.

### **حفظ قابلیت حمل منابع SVG**

یک SVG خودمحافظ حمل و رندر ثابت‌تری دارد نسبت به SVGی که به فایل‌ها یا منابع شبکهٔ خارجی وابسته است. در صورت امکان، قبل از وارد کردن SVG، منابع مورد نیاز را جاسازی کنید. تبدیل SVG به اشکال فقط زمانی انجام شود که عناصر برداری منفرد نیاز به ویرایش داشته باشند.

### **استفاده از API تصویر مدرن چندپلتفرمی**

برای کد جدید PHP via Java، به‌جای API عمومی قدیمی مبتنی بر `java.awt.image.BufferedImage`، از APIهای Aspose.Slides `[IImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/iimage/)` و `[Images](https://reference.aspose.com/slides/fa/php-java/aspose.slides/images/)` استفاده کنید. برای راهنمای مهاجرت به [API مدرن](/slides/fa/php-java/modern-api/) مراجعه کنید.

WMF و EMF نیاز به ملاحظات ویژه دارند. وقتی این فرمت‌ها از طریق `[IImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/iimage/)` عبور می‌کنند، `ImageCollection::addImage` (https://reference.aspose.com/slides/fa/php-java/aspose.slides/imagecollection/) متافایل را به یک نمایه PNG رستر تبدیل می‌کند قبل از درج. اگر حفظ دادهٔ متافایل مهم است، به‌جای overload بایت‌استریم‑پایه `ImageCollection::addImage` استفاده کنید. تولید محتوی EMF از صفحات گسترده یا محصولات دیگر یک جریان کاری یکپارچه‌سازی جداگانه است و خارج از دامنهٔ این مقاله قرار می‌گیرد.

## **پرسش‌های متداول**

**تفاوت بین مجموعه تصویر و یک قاب تصویر چیست؟**

مجموعه تصویر منابع تصویری قابل بازاستفاده را ذخیره می‌کند. یک قاب تصویر یک شکل اسلاید است که یکی از آن منابع را نمایش می‌دهد و قالب‌بندی‌های خاص قاب مانند برش و افکت‌ها را فراهم می‌کند.

**بهترین روش برای جایگزینی یک لوگو در همه‌جا چیست؟**

اگر لوگو به‌عنوان یک منبع تصویر مشترک موجود است، آن منبع را با `PPImage::replaceImage` (https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) جایگزین کنید. برای برندینگ سراسری ارائه، قرار دادن لوگو روی یک مستر یا لایه نیز می‌تواند محتوای تکراری اسلایدها را کاهش دهد.

**چرا یک تصویر پیوندی در کامپیوتر دیگر ناپدید می‌شود؟**

یک تصویر پیوندی به فایل یا URL خارجی خود وابسته است. اگر آن منبع از کامپیوتر دیگر قابل دسترسی نباشد، تصویر پیوندی در دسترس نخواهد بود. وقتی ارائه باید خودکفا باشد، تصویر را جاسازی کنید.

**آیا می‌توان یک SVG درج‌شده را به‌عنوان اشکال PowerPoint ویرایش کرد؟**

بله. با `ShapeCollection::addGroupShape` (https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/addgroupshape/) SVG را تبدیل کنید؛ گروه حاصل شامل اشکال قابل ویرایش اسلاید است نه یک تصویر SVG واحد.

**چگونه می‌توانم ارائه‌های دارای تصاویر متعدد را کوچکتر نگه دارم؟**

از منابع تصویر مشترک بازاستفاده کنید، از منابع رستر بزرگ و غیرضروری خودداری کنید، در صورت مناسب تصاویر رستر را فشرده کنید، برندینگ تکراری را بر روی مستر یا لایه‌ها نگه دارید و فقط زمانی از تصاویر پیوندی استفاده کنید که وابستگی خارجی قابل قبول باشد.