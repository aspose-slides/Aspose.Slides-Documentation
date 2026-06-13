---
title: ایجاد یک نمایش‌گر ارائه در PHP
linktitle: نمایش‌گر ارائه
type: docs
weight: 50
url: /fa/php-java/presentation-viewer/
keywords:
- مشاهده ارائه
- نمایش‌گر ارائه
- ایجاد نمایش‌گر ارائه
- مشاهده PPT
- مشاهده PPTX
- مشاهده ODP
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "یک نمایش‌گر ارائه سفارشی با استفاده از Aspose.Slides برای PHP از طریق Java ایجاد کنید. به‌راحتی فایل‌های PowerPoint و OpenDocument را بدون Microsoft PowerPoint نمایش دهید."
---
## **معرفی**

Aspose.Slides برای PHP از طریق Java برای ایجاد فایل‌های ارائه با اسلایدها استفاده می‌شود. این اسلایدها می‌توانند با باز کردن ارائه‌ها در Microsoft PowerPoint، به‌عنوان مثال، مشاهده شوند. اما گاهی توسعه‌دهندگان ممکن است نیاز داشته باشند اسلایدها را به‌عنوان تصویر در نمایش‑گر تصویر مورد علاقه خود مشاهده کنند یا نمایش‑گر ارائه خود را بسازند. در چنین مواردی، Aspose.Slides امکان خروجی گرفتن یک اسلاید به‌صورت تصویر را فراهم می‌کند. این مقاله نحوه انجام این کار را توصیف می‌کند.

## **تولید تصویر SVG از یک اسلاید**

برای تولید تصویر SVG از یک اسلاید ارائه با Aspose.Slides، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس[Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک جریان فایل (file stream) باز کنید.
1. اسلاید را به‌عنوان تصویر SVG در جریان فایل ذخیره کنید.

```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream);
$svgStream->close();

$presentation->dispose();
```

## **تولید SVG با شناسه‌ شکل سفارشی**

می‌توان از Aspose.Slides برای تولید یک[SVG](https://docs.fileformat.com/page-description-language/svg/) از اسلایدی با شناسه‌ شکل سفارشی استفاده کرد. برای این کار، از متد `setId` در[SvgShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgshape/) استفاده کنید. می‌توان از `CustomSvgShapeFormattingController` برای تنظیم شناسه شکل استفاده کرد.

```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$shapeFormattingController = java_closure(new CustomSvgShapeFormattingController(0), null, java("com.aspose.slides.ISvgShapeFormattingController"));

$svgOptions = new SVGOptions();
$svgOptions->setShapeFormattingController($shapeFormattingController);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream, $svgOptions);
$svgStream->close();

$presentation->dispose();
```
```php
class CustomSvgShapeFormattingController {
    private $m_shapeIndex;

    public function __construct($shapeStartIndex) {
        $this->m_shapeIndex = $shapeStartIndex;
    }

    public function formatShape($svgShape, $shape) {
        $svgShape->setId(sprintf("shape-%d", $m_shapeIndex++));
    }
}
```

## **ایجاد تصویر بندانگشتی اسلاید**

Aspose.Slides به شما کمک می‌کند تا تصاویر بندانگشتی اسلایدها را تولید کنید. برای تولید یک تصویر بندانگشتی از اسلاید با استفاده از Aspose.Slides، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس[Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید را بر اساس ایندکس آن دریافت کنید.
1. تصویر بندانگشت اسلاید مرجع را با مقیاس تعریف‌شده دریافت کنید.
1. تصویر بندانگشت را در هر فرمت تصویری دلخواه ذخیره کنید.

```php
$slideIndex = 0;
$scaleX = 1.0;
$scaleY = $scaleX;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($scaleX, $scaleY);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```

## **ایجاد تصویر بندانگشتی اسلاید با ابعاد تعریف‌شده توسط کاربر**

برای ایجاد تصویر بندانگشتی اسلاید با ابعاد تعریف‌شده توسط کاربر، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس[Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید را بر اساس ایندکس آن دریافت کنید.
1. تصویر بندانگشت اسلاید مرجع را با ابعاد تعریف‌شده دریافت کنید.
1. تصویر بندانگشت را در هر فرمت تصویری دلخواه ذخیره کنید.

```php
$slideIndex = 0;
$slideSize = new Java("java.awt.Dimension", 1200, 800);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($slideSize);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```

## **ایجاد تصویر بندانگشتی اسلاید با یادداشت‌های گوینده**

برای تولید تصویر بندانگشتی اسلاید همراه با یادداشت‌های گوینده با استفاده از Aspose.Slides، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس[RenderingOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/renderingoptions/) ایجاد کنید.
1. از متد `RenderingOptions.setSlidesLayoutOptions` برای تنظیم موقعیت یادداشت‌های گوینده استفاده کنید.
1. یک نمونه از کلاس[Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید را بر اساس ایندکس آن دریافت کنید.
1. تصویر بندانگشت اسلاید مرجع را با گزینه‌های رندرینگ دریافت کنید.
1. تصویر بندانگشت را در هر فرمت تصویری دلخواه ذخیره کنید.

```php
$slideIndex = 0;

$layoutingOptions = new NotesCommentsLayoutingOptions();
$layoutingOptions->setNotesPosition(NotesPositions::BottomTruncated);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutingOptions);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($renderingOptions);
$image->save("output.png", ImageFormat::Png);
$image->dispose();

$presentation->dispose();
```

## **مثال زنده**

می‌توانید برنامهٔ رایگان[**Aspose.Slides Viewer**](https://products.aspose.app/slides/fa/viewer/) را امتحان کنید تا ببینید با API Aspose.Slides چه می‌توانید پیاده‌سازی کنید:

![مشاهده‌گر آنلاین پاورپوینت](online-PowerPoint-viewer.png)

## **سوالات متداول**

**آیا می‌توانم یک نمایش‌گر ارائه را در یک برنامه وب تعبیه کنم؟**

بله. می‌توانید از Aspose.Slides در سمت سرور برای رندر کردن اسلایدها به‌صورت تصویر یا HTML استفاده کنید و آن‌ها را در مرورگر نمایش دهید. ویژگی‌های ناوبری و بزرگ‌نمایی می‌توانند با JavaScript برای تجربه‌ای تعاملی پیاده‌سازی شوند.

**بهترین روش برای نمایش اسلایدها در یک نمایش‌گر سفارشی چیست؟**

روش پیشنهادی این است که هر اسلاید را به‌صورت تصویر (مثلاً PNG یا SVG) رندر کنید یا با استفاده از Aspose.Slides به HTML تبدیل کنید، سپس خروجی را داخل یک PictureBox (برای دسکتاپ) یا یک Container HTML (برای وب) نمایش دهید.

**چگونه می‌توانم ارائه‌های بزرگ با تعداد زیاد اسلاید را مدیریت کنم؟**

برای مجموعه‌های بزرگ، بارگذاری تنبل (lazy‑loading) یا رندرینگ بر‑تقاضای اسلایدها را در نظر بگیرید. این بدان معناست که محتوای یک اسلاید فقط زمانی تولید می‌شود که کاربر به آن هدایت شود، که باعث کاهش مصرف حافظه و زمان بارگذاری می‌شود.