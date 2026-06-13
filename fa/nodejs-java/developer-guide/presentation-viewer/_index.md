---
title: ساخت یک نمایشگر ارائه در جاوا اسکریپت
linktitle: نمایشگر ارائه
type: docs
weight: 50
url: /fa/nodejs-java/presentation-viewer/
keywords:
- مشاهده ارائه
- نمایشگر ارائه
- ایجاد نمایشگر ارائه
- مشاهده PPT
- مشاهده PPTX
- مشاهده ODP
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- جاوا اسکریپت
- Aspose.Slides
description: "یک نمایشگر ارائه سفارشی در جاوا اسکریپت با Aspose.Slides برای Node.js ایجاد کنید. به راحتی فایل‌های PowerPoint و OpenDocument را بدون نیاز به Microsoft PowerPoint نمایش دهید."
---
## **معرفی**

Aspose.Slides برای Node.js از طریق Java برای ایجاد فایل‌های ارائه با اسلایدها استفاده می‌شود. این اسلایدها را می‌توان با باز کردن ارائه‌ها در Microsoft PowerPoint، به عنوان مثال، مشاهده کرد. با این حال، گاهی اوقات توسعه‌دهندگان ممکن است نیاز داشته باشند اسلایدها را به عنوان تصویر در نمایشگر تصویر مورد علاقه خود مشاهده کنند یا نمایشگر ارائه خود را ایجاد کنند. در این موارد، Aspose.Slides به شما امکان می‌دهد یک اسلاید جداگانه را به صورت تصویر استخراج کنید. این مقاله توضیح می‌دهد چگونه این کار را انجام دهید.

## **تولید تصویر SVG از یک اسلاید**

برای تولید یک تصویر SVG از یک اسلاید ارائه با Aspose.Slides، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) را ایجاد کنید.
1. مرجع اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک جریان فایل باز کنید.
1. اسلاید را به عنوان تصویر SVG در جریان فایل ذخیره کنید.

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **تولید SVG با شناسه شکل سفارشی**

می‌توانید از Aspose.Slides برای تولید یک [SVG](https://docs.fileformat.com/page-description-language/svg/) از یک اسلاید با شناسه شکل سفارشی استفاده کنید. برای این کار، از متد `setId` موجود در [SvgShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgshape/) استفاده کنید. `CustomSvgShapeFormattingController` می‌تواند برای تنظیم شناسه شکل استفاده شود.

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgOptions = new aspose.slides.SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController(0));

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```javascript
class CustomSvgShapeFormattingController {
    constructor(shapeStartIndex = 0) {
        this.m_shapeIndex = shapeStartIndex;
    }

    formatShape(svgShape, shape) {
        svgShape.setId(`shape-${this.m_shapeIndex++}`);
    }
}
```

## **ایجاد تصویر بندانگشتی اسلاید**

Aspose.Slides به شما کمک می‌کند تا تصاویر بندانگشتی اسلایدها را تولید کنید. برای تولید یک تصویر بندانگشتی از یک اسلاید با استفاده از Aspose.Slides، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) را ایجاد کنید.
1. مرجع اسلاید را بر اساس ایندکس آن دریافت کنید.
1. تصویر بندانگشتی اسلاید مرجع را با مقیاس تعریف‌شده دریافت کنید.
1. تصویر بندانگشتی را در هر فرمت تصویری دلخواهی ذخیره کنید.

```javascript
const slideIndex = 0;
const scaleX = 1;
const scaleY = scaleX;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **ایجاد تصویر بندانگشتی اسلاید با ابعاد تعریف‌شده توسط کاربر**

برای ایجاد تصویر بندانگشتی اسلاید با ابعاد تعریف‌شده توسط کاربر، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) را ایجاد کنید.
1. مرجع اسلاید را بر اساس ایندکس آن دریافت کنید.
1. تصویر بندانگشتی اسلاید مرجع را با ابعاد تعریف‌شده دریافت کنید.
1. تصویر بندانگشتی را در هر فرمت تصویری دلخواهی ذخیره کنید.

```javascript
var slideIndex = 0;
var slideSize = java.newInstanceSync("java.awt.Dimension", 1200, 800);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(slideSize);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **ایجاد تصویر بندانگشتی اسلاید با یادداشت‌های سخنران**

برای تولید تصویر بندانگشتی یک اسلاید همراه با یادداشت‌های سخنران با استفاده از Aspose.Slides، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [RenderingOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/renderingoptions/) را ایجاد کنید.
1. از متد `RenderingOptions.setSlidesLayoutOptions` برای تنظیم موقعیت یادداشت‌های سخنران استفاده کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) را ایجاد کنید.
1. مرجع اسلاید را بر اساس ایندکس آن دریافت کنید.
1. تصویر بندانگشتی اسلاید مرجع را با گزینه‌های رندرینگ دریافت کنید.
1. تصویر بندانگشتی را در هر فرمت تصویری دلخواهی ذخیره کنید.

```javascript
var slideIndex = 0;

var layoutingOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);

var renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(renderingOptions);
image.save("output.png", aspose.slides.ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **مثال زنده**

می‌توانید برنامهٔ رایگان [**Aspose.Slides Viewer**](https://products.aspose.app/slides/fa/viewer/) را امتحان کنید تا ببینید با API Aspose.Slides چه می‌توانید پیاده‌سازی کنید:

![نمایشگر آنلاین پاورپوینت](online-PowerPoint-viewer.png)

## **پرسش‌های متداول**

**آیا می‌توانم یک نمایشگر ارائه را در یک برنامه وب Node.js جاسازی کنم؟**

بله. می‌توانید از Aspose.Slides در سمت سرور برای رندر کردن اسلایدها به صورت تصویر یا HTML استفاده کنید و آن‌ها را در مرورگر نمایش دهید. ویژگی‌های ناوبری و زوم می‌توانند با JavaScript برای تجربه‌ای تعاملی پیاده‌سازی شوند.

**بهترین روش برای نمایش اسلایدها در یک نمایشگر سفارشی چیست؟**

روش پیشنهادی این است که هر اسلاید را به صورت تصویر (مانند PNG یا SVG) رندر کنید یا با استفاده از Aspose.Slides به HTML تبدیل کنید، سپس خروجی را داخل یک picture box (برای دسکتاپ) یا container HTML (برای وب) نمایش دهید.

**چگونه می‌توانم ارائه‌های بزرگ با اسلایدهای متعدد را مدیریت کنم؟**

برای مجموعه‌های بزرگ، بارگذاری تنبل (lazy-loading) یا رندرینگ بر‑طلب (on‑demand) اسلایدها را در نظر بگیرید. این به این معنی است که محتویات یک اسلاید فقط زمانی که کاربر به آن می‌رود تولید می‌شود و حافظه و زمان بارگذاری را کاهش می‌دهد.