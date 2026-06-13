---
title: ایجاد یک نمایشگر ارائه بر روی اندروید
linktitle: نمایشگر ارائه
type: docs
weight: 50
url: /fa/androidjava/presentation-viewer/
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
- Android
- Java
- Aspose.Slides
description: "یک نمایشگر ارائه سفارشی در جاوا با استفاده از Aspose.Slides برای اندروید ایجاد کنید. به راحتی فایل‌های PowerPoint و OpenDocument را بدون نیاز به Microsoft PowerPoint نمایش دهید."
---
## **معرفی**

Aspose.Slides برای Android از طریق Java برای ایجاد فایل‌های ارائه با اسلایدها استفاده می‌شود. این اسلایدها می‌توانند با باز کردن ارائه‌ها در Microsoft PowerPoint، به‌عنوان مثال، مشاهده شوند. با این حال، گاهی توسعه‌دهندگان ممکن است نیاز داشته باشند اسلایدها را به‌صورت تصویر در نمایشگر تصویر دلخواه خود مشاهده کنند یا نمایشگر ارائه خود را بسازند. در چنین مواردی، Aspose.Slides امکان استخراج یک اسلاید به‌صورت تصویر را فراهم می‌کند. این مقاله روش انجام آن را توضیح می‌دهد.

## **تولید تصویر SVG از یک اسلاید**

برای تولید تصویر SVG از یک اسلاید ارائه با Aspose.Slides، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) را ایجاد کنید.
1. مرجع اسلاید را با استفاده از ایندکس آن دریافت کنید.
1. یک جریان فایل (file stream) باز کنید.
1. اسلاید را به‌عنوان تصویر SVG در جریان فایل ذخیره کنید.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **تولید SVG با شناسه شکل سفارشی**

Aspose.Slides می‌تواند برای تولید یک [SVG](https://docs.fileformat.com/page-description-language/svg/) از یک اسلاید با شناسه شکل سفارشی استفاده شود. برای این کار، از متد `setId` در [ISvgShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isvgshape/) استفاده کنید. می‌توان از `CustomSvgShapeFormattingController` برای تنظیم شناسه شکل استفاده کرد.

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
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController()
    {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **ایجاد تصویر بندانگشت اسلاید**

Aspose.Slides به شما کمک می‌کند تا تصاویر بندانگشت اسلایدها را ایجاد کنید. برای تولید یک بندانگشت از اسلاید با استفاده از Aspose.Slides، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) را ایجاد کنید.
1. مرجع اسلاید را با استفاده از ایندکس آن دریافت کنید.
1. تصویر بندانگشت اسلاید مرجع را با مقیاس تعریف‌شده دریافت کنید.
1. تصویر بندانگشت را در هر فرمت تصویری دلخواه ذخیره کنید.

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

## **ایجاد تصویر بندانگشت اسلاید با ابعاد تعریف‌شده توسط کاربر**

برای ایجاد تصویر بندانگشت اسلاید با ابعاد تعریف‌شده توسط کاربر، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) را ایجاد کنید.
1. مرجع اسلاید را با استفاده از ایندکس آن دریافت کنید.
1. تصویر بندانگشت اسلاید مرجع را با ابعاد تعریف‌شده دریافت کنید.
1. تصویر بندانگشت را در هر فرمت تصویری دلخواه ذخیره کنید.

```java
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **ایجاد تصویر بندانگشت اسلاید با یادداشت‌های سخنران**

برای تولید تصویر بندانگشت اسلاید با یادداشت‌های سخنران با استفاده از Aspose.Slides، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [RenderingOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/renderingoptions/) را ایجاد کنید.
1. از متد `RenderingOptions.setSlidesLayoutOptions` برای تنظیم موقعیت یادداشت‌های سخنران استفاده کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) را ایجاد کنید.
1. مرجع اسلاید را با استفاده از ایندکس آن دریافت کنید.
1. تصویر بندانگشت اسلاید مرجع را با گزینه‌های رندرینگ دریافت کنید.
1. تصویر بندانگشت را در هر فرمت تصویری دلخواه ذخیره کنید.

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

شما می‌توانید برنامه رایگان [**Aspose.Slides Viewer**](https://products.aspose.app/slides/fa/viewer/) را امتحان کنید تا ببینید با API Aspose.Slides چه می‌توانید پیاده‌سازی کنید:

![نمایشگر آنلاین PowerPoint](online-PowerPoint-viewer.png)

## **سوالات متداول**

**آیا می‌توانم یک نمایشگر ارائه را در یک برنامه وب جاسازی کنم؟**

بله. می‌توانید از Aspose.Slides در سمت سرور برای تبدیل اسلایدها به تصویر یا HTML استفاده کنید و آن‌ها را در مرورگر نمایش دهید. قابلیت‌های ناوبری و زوم می‌توانند با JavaScript برای تجربه تعاملی پیاده‌سازی شوند.

**بهترین روش برای نمایش اسلایدها در یک نمایشگر سفارشی چیست؟**

روش پیشنهادی این است که هر اسلاید را به‌صورت تصویر (مثلاً PNG یا SVG) رندر کنید یا با استفاده از Aspose.Slides به HTML تبدیل کنید، سپس خروجی را در یک picture box (برای دسکتاپ) یا یک container HTML (برای وب) نمایش دهید.

**چگونه می‌توانم ارائه‌های بزرگ با اسلایدهای بسیاری را مدیریت کنم؟**

برای مجموعه‌های بزرگ، بارگذاری تنبل (lazy-loading) یا رندرینگ بر‑تقاضا برای اسلایدها را در نظر بگیرید. یعنی محتوای یک اسلاید فقط زمانی تولید می‌شود که کاربر به آن هدایت شود، که حافظه و زمان بارگذاری را کاهش می‌دهد.