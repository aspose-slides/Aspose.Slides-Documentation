---
title: ایجاد یک نمایشگر ارائه در .NET
linktitle: نمایشگر ارائه
type: docs
weight: 50
url: /fa/net/presentation-viewer/
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
- .NET
- C#
- Aspose.Slides
description: "یک نمایشگر ارائه سفارشی در .NET با استفاده از Aspose.Slides ایجاد کنید. به راحتی فایل‌های PowerPoint و OpenDocument را بدون نیاز به Microsoft PowerPoint نمایش دهید."
---
## **مقدمه**

Aspose.Slides برای .NET برای ایجاد فایل‌های ارائه با اسلایدها استفاده می‌شود. این اسلایدها می‌توانند با باز کردن ارائه‌ها در Microsoft PowerPoint، به عنوان مثال، مشاهده شوند. اما گاهی ممکن است توسعه‌دهندگان نیاز داشته باشند اسلایدها را به صورت تصویر در برنامه مشاهده‌گر تصویر دلخواه خود مشاهده کنند یا از آن‌ها در یک برنامه مشاهده‌گر سفارشی استفاده کنند. در چنین مواردی، Aspose.Slides به شما امکان می‌دهد اسلایدهای منفرد را به عنوان تصویر استخراج کنید. این مقاله توضیح می‌دهد چگونه این کار را انجام دهید.

## **تولید تصویر SVG از یک اسلاید**

برای تولید تصویر SVG از یک اسلاید ارائه با استفاده از Aspose.Slides، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. مرجع اسلاید را بر اساس شاخص آن دریافت کنید.
1. یک فایل استریم باز کنید.
1. اسلاید را به عنوان تصویر SVG در فایل استریم ذخیره کنید.

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream);
    }
}
```

## **تولید SVG با شناسه شکل سفارشی**

Aspose.Slides می‌تواند برای تولید یک [SVG](https://docs.fileformat.com/page-description-language/svg/) از یک اسلاید با یک `ID` شکل سفارشی استفاده شود. برای این کار، از ویژگی Id در رابط [ISvgShape](https://reference.aspose.com/slides/fa/net/aspose.slides.export/isvgshape) استفاده کنید. می‌توانید از کلاس `CustomSvgShapeFormattingController` برای تنظیم شناسه شکل استفاده کنید.

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];
    
    SVGOptions svgOptions = new SVGOptions
    {
        ShapeFormattingController = new CustomSvgShapeFormattingController()
    };

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream, svgOptions);
    }
}
```

```c#
class CustomSvgShapeFormattingController : ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);
    }
}
```

## **ایجاد تصویر بندانگشتی اسلاید**

Aspose.Slides به شما کمک می‌کند تصاویر بندانگشتی اسلایدها را تولید کنید. برای تولید یک تصویر بندانگشتی از یک اسلاید با استفاده از Aspose.Slides، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. مرجع اسلاید را بر اساس شاخص آن دریافت کنید.
1. یک تصویر بندانگشتی از اسلید مرجع با مقیاس دلخواه ایجاد کنید.
1. تصویر بندانگشتی را در فرمت تصویری مورد نظر خود ذخیره کنید.

```c#
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(scaleX, scaleY))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **ایجاد تصویر بندانگشتی اسلاید با ابعاد تعیین‌شده توسط کاربر**

برای ایجاد تصویر بندانگشتی اسلاید با ابعاد تعریف‌شده توسط کاربر، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. مرجع اسلاید را بر اساس شاخص آن دریافت کنید.
1. یک تصویر بندانگشتی از اسلاید مرجع با ابعاد مشخص‌شده تولید کنید.
1. تصویر بندانگشتی را در فرمت تصویری مورد نظر خود ذخیره کنید.

```c#
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(slideSize))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **ایجاد تصویر بندانگشتی اسلاید با یادداشت‌های گوینده**

برای تولید یک تصویر بندانگشتی از یک اسلاید با یادداشت‌های گوینده با استفاده از Aspose.Slides، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [RenderingOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/renderingoptions/) ایجاد کنید.
1. از ویژگی `RenderingOptions.SlidesLayoutOptions` برای تنظیم موقعیت یادداشت‌های گوینده استفاده کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. مرجع اسلاید را بر اساس شاخص آن دریافت کنید.
1. یک تصویر بندانگشتی از اسلاید مرجع با استفاده از گزینه‌های رندرینگ ایجاد کنید.
1. تصویر بندانگشتی را در فرمت تصویری مورد نظر خود ذخیره کنید.

```c#
int slideIndex = 0;

RenderingOptions renderingOptions = new RenderingOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomTruncated
    }
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(renderingOptions))
    {
        image.Save("output.png", ImageFormat.Png);
    }
}
```

## **مثال زنده**

سعی کنید برنامه رایگان [**Aspose.Slides Viewer**](https://products.aspose.app/slides/fa/viewer/) را امتحان کنید تا ببینید با Aspose.Slides API می‌توانید چه کاری انجام دهید:

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/fa/viewer/)

## **سؤالات متداول**

**آیا می‌توانم یک برنامه مشاهده‌گر ارائه را در یک برنامه وب ASP.NET درج کنم؟**

بله. می‌توانید از Aspose.Slides در سمت سرور برای رندر کردن اسلایدها به عنوان تصویر یا HTML استفاده کنید و آن‌ها را در مرورگر نمایش دهید. ویژگی‌های ناوبری و زوم می‌توانند با JavaScript برای تجربه تعاملی پیاده‌سازی شوند.

**بهترین روش برای نمایش اسلایدها در یک مشاهده‌گر سفارشی .NET چیست؟**

رویکرد پیشنهادی این است که هر اسلاید را به عنوان یک تصویر (مانند PNG یا SVG) رندر کنید یا با استفاده از Aspose.Slides به HTML تبدیل کنید، سپس خروجی را در یک picture box (برای دسکتاپ) یا یک کانتینر HTML (برای وب) نمایش دهید.

**چگونه می‌توانم ارائه‌های بزرگ با اسلایدهای متعدد را مدیریت کنم؟**

برای مجموعه‌های بزرگ، می‌توانید بارگذاری تنبل یا رندر بر اساس تقاضا را در نظر بگیرید. این به معنای تولید محتوای اسلاید تنها زمانی است که کاربر به آن مراجعه می‌کند، که مصرف حافظه و زمان بارگذاری را کاهش می‌دهد.