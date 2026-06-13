---
title: ایجاد یک نمایشگر ارائه در C++
linktitle: نمایشگر ارائه
type: docs
weight: 50
url: /fa/cpp/presentation-viewer/
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
- C++
- Aspose.Slides
description: "یک نمایشگر ارائه سفارشی در C++ با استفاده از Aspose.Slides ایجاد کنید. به راحتی فایل‌های PowerPoint و OpenDocument را بدون Microsoft PowerPoint نمایش دهید."
---
## **مقدمه**

Aspose.Slides برای C++ برای ایجاد فایل‌های ارائه با اسلایدها استفاده می‌شود. این اسلایدها می‌توانند با باز کردن ارائه‌ها در Microsoft PowerPoint، به عنوان مثال، مشاهده شوند. اما گاهی توسعه‌دهندگان ممکن است نیاز داشته باشند اسلایدها را به‌عنوان تصویر در نمایشگر تصویر دلخواه خود مشاهده کنند یا نمایشگر ارائه خود را ایجاد کنند. در چنین مواردی، Aspose.Slides به شما امکان می‌دهد یک اسلاید فردی را به صورت تصویر صادر کنید. این مقاله نحوه انجام این کار را توضیح می‌دهد.

## **تولید تصویر SVG از یک اسلاید**

برای تولید یک تصویر SVG از یک اسلاید ارائه با Aspose.Slides، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک جریان فایل باز کنید.
1. اسلاید را به‌عنوان تصویر SVG در جریان فایل ذخیره کنید.

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream);
svgStream->Dispose();

presentation->Dispose();
```

## **تولید SVG با شناسه شکل سفارشی**

می‌توانید از Aspose.Slides برای تولید یک [SVG](https://docs.fileformat.com/page-description-language/svg/) از یک اسلاید با شناسه شکل سفارشی استفاده کنید. برای این کار، از متد `set_Id` در [ISvgShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/isvgshape/) استفاده کنید. `CustomSvgShapeFormattingController` می‌تواند برای تنظیم شناسه شکل به کار رود.

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<CustomSvgShapeFormattingController>());

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```
```cpp
class CustomSvgShapeFormattingController : public ISvgShapeFormattingController
{
private:
    int m_shapeIndex;

public:
    CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape)
    {
        svgShape->set_Id(String::Format(u"shape-{0}", m_shapeIndex++));
    }
};
```

## **ایجاد تصویر بندانگشتی اسلاید**

Aspose.Slides به شما کمک می‌کند تا تصاویر بندانگشتی اسلایدها را تولید کنید. برای تولید یک بندانگشتی از اسلاید با استفاده از Aspose.Slides، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید را بر اساس ایندکس آن دریافت کنید.
1. تصویر بندانگشتی اسلاید مرجع را با مقیاس تعریف‌شده دریافت کنید.
1. تصویر بندانگشتی را در هر فرمت تصویری دلخواهی ذخیره کنید.

```cpp
auto slideIndex = 0;
auto scaleX = 1;
auto scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **ایجاد بندانگشتی اسلاید با ابعاد تعریف‌شده توسط کاربر**

برای ایجاد تصویر بندانگشتی اسلاید با ابعاد تعریف‌شده توسط کاربر، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید را بر اساس ایندکس آن دریافت کنید.
1. تصویر بندانگشتی اسلاید مرجع را با ابعاد تعریف‌شده دریافت کنید.
1. تصویر بندانگشتی را در هر فرمت تصویری دلخواهی ذخیره کنید.

```cpp
auto slideIndex = 0;
auto slideSize = Size(1200, 800);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(slideSize);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **ایجاد بندانگشتی اسلاید با یادداشت‌های سخنران**

برای تولید بندانگشتی اسلاید همراه با یادداشت‌های سخنران با استفاده از Aspose.Slides، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [RenderingOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/renderingoptions/) ایجاد کنید.
1. از متد `RenderingOptions.set_SlidesLayoutOptions` برای تنظیم موقعیت یادداشت‌های سخنران استفاده کنید.
1. یک نمونه از کلاس [ارائه](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید را بر اساس ایندکس آن دریافت کنید.
1. تصویر بندانگشتی اسلاید مرجع را با گزینه‌های رندرینگ دریافت کنید.
1. تصویر بندانگشتی را در هر فرمت تصویری دلخواهی ذخیره کنید.

```cpp
auto slideIndex = 0;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_NotesPosition(NotesPositions::BottomTruncated);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(renderingOptions);
image->Save(u"output.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **مثال زنده**

می‌توانید برنامهٔ رایگان [**Aspose.Slides Viewer**](https://products.aspose.app/slides/fa/viewer/) را امتحان کنید تا ببینید چه چیزی می‌توانید با API Aspose.Slides پیاده‌سازی کنید:

![نمایشگر آنلاین PowerPoint](online-PowerPoint-viewer.png)

## **سوالات متداول**

**آیا می‌توانم یک نمایشگر ارائه را در یک برنامه وب جاسازی کنم؟**

بله. می‌توانید از Aspose.Slides در سمت سرور برای رندر کردن اسلایدها به‌صورت تصاویر یا HTML استفاده کنید و آن‌ها را در مرورگر نمایش دهید. ویژگی‌های ناوبری و بزرگ‌نمایی می‌توانند با JavaScript برای تجربه تعاملی پیاده‌سازی شوند.

**بهترین روش برای نمایش اسلایدها در یک نمایشگر سفارشی چیست؟**

روش پیشنهادی این است که هر اسلاید را به‌صورت تصویر (مثلاً PNG یا SVG) رندر کنید یا با استفاده از Aspose.Slides به HTML تبدیل کنید، سپس خروجی را داخل یک PictureBox (برای دسکتاپ) یا یک container HTML (برای وب) نمایش دهید.

**چگونه می‌توانم ارائه‌های بزرگ با اسلایدهای زیاد را مدیریت کنم؟**

برای ارائه‌های بزرگ، بارگذاری تنبل (lazy-loading) یا رندرینگ بر‑تقاضا (on-demand) اسلایدها را در نظر بگیرید. این به این معناست که محتوای اسلاید تنها زمانی که کاربر به آن می‌رود تولید شود، که باعث کاهش مصرف حافظه و زمان بارگذاری می‌شود.