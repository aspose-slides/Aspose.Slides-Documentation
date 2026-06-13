---
title: ایجاد یک مرورگر ارائه در جاوا
linktitle: مرورگر ارائه
type: docs
weight: 50
url: /fa/java/presentation-viewer/
keywords:
- مشاهده ارائه
- مرورگر ارائه
- ایجاد مرورگر ارائه
- مشاهده PPT
- مشاهده PPTX
- مشاهده ODP
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "یک مرورگر ارائه سفارشی در جاوا با استفاده از Aspose.Slides ایجاد کنید. به راحتی فایل‌های PowerPoint و OpenDocument را بدون نیاز به Microsoft PowerPoint نمایش دهید."
---
## **معرفی**

Aspose.Slides for Java برای ایجاد فایل‌های ارائه با اسلایدها استفاده می‌شود. این اسلایدها می‌توانند با باز کردن ارائه‌ها در Microsoft PowerPoint، برای مثال، مشاهده شوند. با این حال، گاهی توسعه‌دهندگان ممکن است نیاز داشته باشند اسلایدها را به عنوان تصویر در مرورگر تصویر موردنظر خود مشاهده کنند یا مرورگر ارائه خود را ایجاد کنند. در چنین مواردی، Aspose.Slides به شما امکان صادر کردن یک اسلاید به صورت تصویر را می‌دهد. این مقاله توصیف می‌کند چگونه این کار را انجام دهید.

## **ایجاد تصویر SVG از یک اسلاید**

برای ایجاد تصویر SVG از یک اسلاید ارائه با Aspose.Slides، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید را با استفاده از ایندکس آن دریافت کنید.
1. یک جریان فایل باز کنید.
1. اسلاید را به عنوان تصویر SVG در جریان فایل ذخیره کنید.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **ایجاد SVG با شناسه شکل سفارشی**

Aspose.Slides می‌تواند برای ایجاد یک [SVG](https://docs.fileformat.com/page-description-language/svg/) از یک اسلاید با شناسه شکل سفارشی استفاده شود. برای این کار، از متد `setId` موجود در [ISvgShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isvgshape/) استفاده کنید. `CustomSvgShapeFormattingController` می‌تواند برای تنظیم شناسه شکل استفاده شود.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

SVGOptions svgOptions = new SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```java
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController {
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController() {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex) {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape) {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **ایجاد تصویر بندانگشتی اسلاید**

Aspose.Slides به شما کمک می‌کند تا تصاویر بندانگشتی اسلایدها را ایجاد کنید. برای ایجاد یک بندانگشتی از اسلاید با استفاده از Aspose.Slides، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید را با استفاده از ایندکس آن دریافت کنید.
1. تصویر بندانگشتی اسلاید مرجع را با مقیاس تعریف‌شده دریافت کنید.
1. تصویر بندانگشتی را در هر قالب تصویر دلخواهی ذخیره کنید.

```java
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **ایجاد تصویر بندانگشتی اسلاید با ابعاد تعریف‌شده توسط کاربر**

برای ایجاد تصویر بندانگشتی اسلاید با ابعاد تعریف‌شده توسط کاربر، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید را با استفاده از ایندکس آن دریافت کنید.
1. تصویر بندانگشتی اسلاید مرجع را با ابعاد تعریف‌شده دریافت کنید.
1. تصویر بندانگشتی را در هر قالب تصویر دلخواهی ذخیره کنید.

```java
int slideIndex = 0;
Dimension slideSize = new Dimension(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **ایجاد تصویر بندانگشتی اسلاید با یادداشت‌های سخنران**

برای ایجاد تصویر بندانگشتی اسلاید با یادداشت‌های سخنران با استفاده از Aspose.Slides، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [RenderingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/renderingoptions/) ایجاد کنید.
1. از متد `RenderingOptions.setSlidesLayoutOptions` برای تنظیم موقعیت یادداشت‌های سخنران استفاده کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید را با استفاده از ایندکس آن دریافت کنید.
1. تصویر بندانگشتی اسلاید مرجع را با گزینه‌های رندرینگ دریافت کنید.
1. تصویر بندانگشتی را در هر قالب تصویر دلخواهی ذخیره کنید.

```java
int slideIndex = 0;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(NotesPositions.BottomTruncated);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(renderingOptions);
image.save("output.png", ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **مثال زنده**

می‌توانید برنامه‌ی رایگان [**Aspose.Slides Viewer**](https://products.aspose.app/slides/fa/viewer/) را امتحان کنید تا ببینید با API Aspose.Slides چه می‌توانید پیاده‌سازی کنید:

![مشاهده‌کننده آنلاین PowerPoint](online-PowerPoint-viewer.png)

## **پرسش‌های متداول**

**آیا می‌توانم یک مرورگر ارائه را در برنامه وب جاسازی کنم؟**

بله. می‌توانید از Aspose.Slides در سمت سرور برای رندر کردن اسلایدها به صورت تصویر یا HTML استفاده کنید و آن‌ها را در مرورگر نمایش دهید. ویژگی‌های ناوبری و زوم می‌توانند با JavaScript برای تجربه‌ای تعاملی پیاده‌سازی شوند.

**بهترین روش برای نمایش اسلایدها در یک مرورگر سفارشی چیست؟**

روش پیشنهادی این است که هر اسلاید را به عنوان یک تصویر (مثلاً PNG یا SVG) رندر کنید یا با استفاده از Aspose.Slides به HTML تبدیل کنید، سپس خروجی را داخل یک picture box (برای دسکتاپ) یا یک کانتینر HTML (برای وب) نمایش دهید.

**چگونه می‌توانم ارائه‌های بزرگ با تعداد زیادی اسلاید را مدیریت کنم؟**

برای مجموعه‌های بزرگ، می‌توانید از بارگذاری تنبل (lazy-loading) یا رندرینگ برخواست (on-demand) اسلایدها استفاده کنید. این به این معناست که محتوای یک اسلاید فقط زمانی تولید می‌شود که کاربر به آن مراجعه کند، که حافظه و زمان بارگذاری را کاهش می‌دهد.