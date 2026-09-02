---
title: مدیریت جعبه‌های متنی در ارائه‌ها در .NET
linktitle: مدیریت جعبه متن
type: docs
weight: 20
url: /fa/net/manage-textbox/
keywords:
- جعبه متن
- قاب متن
- افزودن متن
- به‌روزرسانی متن
- ایجاد جعبه متن
- بررسی جعبه متن
- افزودن ستون متن
- افزودن پیوند
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ایجاد، ویرایش و تکثیر جعبه‌های متنی را در فایل‌های PowerPoint و OpenDocument آسان می‌کند و خودکارسازی ارائه‌های شما را ارتقا می‌دهد."
---
## **مقدمه**

متن‌ها در اسلایدها معمولاً در جعبه‌های متن یا اشکال قرار می‌گیرند. بنابراین، برای افزودن متن به یک اسلاید، ابتدا باید یک جعبه متن اضافه کنید و سپس متنی داخل آن قرار دهید.

برای این که بتوانید شکلی که می‌تواند متن را در خود نگه دارد اضافه کنید، Aspose.Slides for .NET رابط [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape) را فراهم می‌کند.

{{% alert title="Note" color="warning" %}} 
Aspose.Slides همچنین رابط [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape) را برای افزودن اشکال به اسلایدها ارائه می‌دهد. اما همه اشکالی که از طریق رابط `IShape` اضافه می‌شوند قادر به نگهداری متن نیستند. اشکالی که از طریق رابط [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape) اضافه می‌شوند معمولاً متن دارند.

به همین دلیل، وقتی با یک شکل موجود که می‌خواهید به آن متن اضافه کنید سر و کار دارید، ممکن است بخواهید بررسی کنید که آیا آن شکل از طریق رابط `IAutoShape` تبدیل (cast) شده است یا نه. تنها پس از این می‌توانید با [TextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/properties/textframe) کار کنید، که یک ویژگی از `IAutoShape` است. بخش [Update Text](https://docs.aspose.com/slides/fa/net/manage-textbox/#update-text) در این صفحه را ببینید. 
{{% /alert %}}

## **ایجاد یک جعبه متن در اسلاید**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
2. مرجع اولین اسلاید را از طریق اندیس آن دریافت کنید.  
3. یک شیء [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape) با `ShapeType` برابر `Rectangle` در موقعیتی مشخص روی اسلاید اضافه کنید و مرجع شیء `IAutoShape` تازه اضافه‌شده را به دست آورید.  
4. ویژگی `TextFrame` را به شیء `IAutoShape` اضافه کنید تا متنی در آن قرار بگیرد. در مثال زیر این متن را اضافه کردیم: *Aspose TextBox*  
5. در نهایت فایل PPTX را از طریق شیء `Presentation` بنویسید.  

این کد C#—که پیاده‌سازی مراحل فوق است—نحوه افزودن متن به یک اسلاید را نشان می‌دهد:

```c#
using Aspose.Slides;

// نمونه‌سازی PresentationEx
using (Presentation pres = new Presentation())
{

    // اسلاید اول ارائه را دریافت می‌کند
    ISlide sld = pres.Slides[0];

    // یک AutoShape با نوع Rectangle اضافه می‌کند
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // یک TextFrame به Rectangle اضافه می‌کند
    ashp.AddTextFrame(" ");

    // به فریم متن دسترسی پیدا می‌کند
    ITextFrame txtFrame = ashp.TextFrame;

    // شی Paragraph را برای فریم متن ایجاد می‌کند
    IParagraph para = txtFrame.Paragraphs[0];

    // شی Portion را برای پاراگراف ایجاد می‌کند
    IPortion portion = para.Portions[0];

    // متن را تنظیم می‌کند
    portion.Text = "Aspose TextBox";

    // ارائه را روی دیسک ذخیره می‌کند
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **بررسی یک شکل جعبه متن**

Aspose.Slides ویژگی [IsTextBox](https://reference.aspose.com/slides/fa/net/aspose.slides/autoshape/istextbox/) را از رابط [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) ارائه می‌دهد تا بتوانید اشکال را بررسی کرده و جعبه‌های متن را شناسایی کنید.

![جعبه متن و شکل](istextbox.png)

این کد C# نشان می‌دهد چطور بررسی کنید که آیا یک شکل به عنوان جعبه متن ایجاد شده است یا نه:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    Aspose.Slides.LowCode.ForEach.Shape(presentation, (shape, slide, index) =>
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "shape is a text box" : "shape is not a text box");
        }
    });
}
```

توجه داشته باشید که اگر فقط یک AutoShape را با روش `AddAutoShape` از رابط [IShapeCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/) اضافه کنید، ویژگی `IsTextBox` آن AutoShape مقدار `false` را بر می‌گرداند. اما پس از افزودن متن به AutoShape با روش `AddTextFrame` یا ویژگی `Text`، ویژگی `IsTextBox` مقدار `true` را بر می‌گرداند.

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    // shape1.IsTextBox برابر false است
    shape1.AddTextFrame("shape 1");
    // shape1.IsTextBox برابر true است

    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
    // shape2.IsTextBox برابر false است
    shape2.TextFrame.Text = "shape 2";
    // shape2.IsTextBox برابر true است

    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
    // shape3.IsTextBox برابر false است
    shape3.AddTextFrame("");
    // shape3.IsTextBox برابر false است

    IAutoShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
    // shape4.IsTextBox برابر false است
    shape4.TextFrame.Text = "";
    // shape4.IsTextBox برابر false است
}
```

## **یافتن شکلی که یک TextFrame را مالک است**

در کدهای عمومی پردازش متن، ممکن است یک [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) دریافت کنید بدون این که از پیش بدانید کدام شیء ارائه (presentation) آن را شامل می‌شود. از ویژگی [ITextFrame.ParentShape](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/parentshape/) برای بازگشت به [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/) صاحب استفاده کنید.

برای یک TextFrame که به یک [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) یا شکل دیگری حاوی متن تعلق دارد، ویژگی `ITextFrame.ParentShape` تنظیم شده و `ITextFrame.ParentCell` مقدار `null` دارد. هر دو ویژگی فقط برای ناوبری هستند و فقط خوانده می‌شوند، بنابراین خواندن آن‌ها مالکیت را تغییر نمی‌دهد. قبل از دسترسی به شکل، همیشه مقدار برگشتی را برای `null` بررسی کنید.

برای یک مثال کامل که مالکان شکل و سلول جدول را شناسایی می‌کند، شامل اشکال مرتبط با نودهای SmartArt، به صفحه [Search and Replace Text](/slides/fa/net/search-and-replace-text/) مراجعه کنید.

## **افزودن ستون‌ها به یک جعبه متن**

Aspose.Slides ویژگی‌های [ColumnCount](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/properties/columncount) و [ColumnSpacing](https://reference.aspose.com/slides/fa/net/aspose.slides/textframeformat/properties/columnspacing) را (از رابط [ITextFrameFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat) و کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/textframeformat)) فراهم می‌کند تا بتوانید ستون‌هایی به جعبه‌های متن اضافه کنید. شما می‌توانید تعداد ستون‌ها را مشخص کنید و سپس فاصله بین ستون‌ها را بر حسب پوینت تنظیم کنید.

این کد C# عملکرد توضیح‌داده‌شده را نشان می‌دهد:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
	// اسلاید اول ارائه را دریافت می‌کند
	ISlide slide = presentation.Slides[0];

	// یک AutoShape با نوع Rectangle اضافه می‌کند
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// یک TextFrame به Rectangle اضافه می‌کند
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// فرمت متن TextFrame را دریافت می‌کند
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// تعداد ستون‌ها در TextFrame را مشخص می‌کند
	format.ColumnCount = 3;

	// فاصله بین ستون‌ها را مشخص می‌کند
	format.ColumnSpacing = 10;

	// ارائه را ذخیره می‌کند
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **افزودن ستون‌ها به یک TextFrame**

Aspose.Slides for .NET ویژگی [ColumnCount](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/properties/columncount) را (از رابط [ITextFrameFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat)) ارائه می‌دهد که امکان افزودن ستون به TextFrameها را می‌دهد. با استفاده از این ویژگی می‌توانید تعداد ستون دلخواه خود را در یک TextFrame مشخص کنید.

این کد C# نشان می‌دهد چطور یک ستون داخل TextFrame اضافه کنید:

```c#
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

string outPptxFileName = "ColumnsTest.pptx";
using (Presentation pres = new Presentation())
{
    IAutoShape shape1 = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.TextFrame.TextFrameFormat;

    format.ColumnCount = 2;
    shape1.TextFrame.Text = "All these columns are forced to stay within a single text container -- " +
                                "you can add or delete text - and the new or remaining text automatically adjusts " +
                                "itself to stay within the container. You cannot have text spill over from one container " +
                                "to other, though -- because PowerPoint's column options for text are limited!";
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(double.IsNaN(((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing));
    }

    format.ColumnSpacing = 20;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(20 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnCount = 3;
    format.ColumnSpacing = 15;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(3 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(15 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }
}
```

## **به‌روزرسانی متن**

Aspose.Slides به شما اجازه می‌دهد متن موجود در یک جعبه متن یا تمام متن‌های موجود در یک ارائه را تغییر یا به‌روزرسانی کنید.

این کد C# عملی را نشان می‌دهد که در آن تمام متن‌های یک ارائه به‌روزرسانی یا تغییر می‌یابند:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) // بررسی می‌کند که آیا شکل پشتیبانی از فریم متن (IAutoShape) دارد.
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) // مرور پاراگراف‌ها در فریم متن
               {
                   foreach (IPortion portion in paragraph.Portions) // مرور هر بخش (Portion) در پاراگراف
                   {
                       portion.Text = portion.Text.Replace("years", "months"); // تغییر متن
                       portion.PortionFormat.FontBold = NullableBool.True; // تغییر فرمت
                   }
               }
           }
       }
   }
  
   // ذخیره ارائهٔ تغییر یافته
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **افزودن یک جعبه متن با پیوند (Hyperlink)**

می‌توانید لینکی داخل جعبه متن قرار دهید. وقتی جعبه متن کلیک شود، کاربران به باز کردن آن لینک هدایت می‌شوند.

1. یک نمونه از کلاس `Presentation` ایجاد کنید.  
2. مرجع اولین اسلاید را از طریق اندیس آن دریافت کنید.  
3. یک شیء `AutoShape` با `ShapeType` برابر `Rectangle` در موقعیتی مشخص روی اسلاید اضافه کنید و مرجع شیء تازه اضافه‌شده را بدست آورید.  
4. یک `TextFrame` به شیء `AutoShape` اضافه کنید که متن پیش‌فرض *Aspose TextBox* را داشته باشد.  
5. کلاس `IHyperlinkManager` را نمونه‌سازی کنید.  
6. شیء `IHyperlinkManager` را به ویژگی [HyperlinkClick](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/properties/hyperlinkclick) که مرتبط با بخشی از `TextFrame` مورد نظر شماست، اختصاص دهید.  
7. در نهایت فایل PPTX را از طریق شیء `Presentation` بنویسید.  

این کد C#—که پیاده‌سازی مراحل فوق است—نحوه افزودن یک جعبه متن با لینک به یک اسلاید را نشان می‌دهد:

```c#
using Aspose.Slides;

// یک شیء از کلاس Presentation که نمایانگر یک فایل PPTX است را نمونه‌سازی می‌کند
Presentation pptxPresentation = new Presentation();

// اسلاید اول ارائه را دریافت می‌کند
ISlide slide = pptxPresentation.Slides[0];

// یک شیء AutoShape با نوع Rectangle اضافه می‌کند
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// شکل را به AutoShape تبدیل می‌کند
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// به ویژگی ITextFrame مرتبط با AutoShape دسترسی پیدا می‌کند
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// متن را به فریم اضافه می‌کند
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// پیوند (Hyperlink) برای متن Portion را تنظیم می‌کند
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// ارائه PPTX را ذخیره می‌کند
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **سوالات متداول**

**تفاوت جعبه متن و جای‌گیر متن (placeholder) در اسلایدهای اصلی (master) چیست؟**

یک [placeholder](/slides/fa/net/manage-placeholder/) سبک/موقعیت خود را از [master](https://reference.aspose.com/slides/fa/net/aspose.slides/masterslide/) ارث‌بری می‌کند و می‌تواند در [layouts](https://reference.aspose.com/slides/fa/net/aspose.slides/layoutslide/) بازنویسی شود، در حالی که یک جعبه متن عادی یک شیء مستقل در یک اسلاید خاص است و هنگام تغییر لایه‌ها (layouts) تغییر نمی‌کند.

**چگونه می‌توان یک جایگزینی متنی انبوه در سراسر ارائه انجام داد بدون اینکه به متن داخل نمودارها، جدول‌ها و SmartArt دست بزنم؟**

تکرار خود را به AutoShapeهایی که دارای TextFrame هستند محدود کنید و اشیاء جاسازی‌شده ([charts](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chart/)، [tables](https://reference.aspose.com/slides/fa/net/aspose.slides/table/)، [SmartArt](https://reference.aspose.com/slides/fa/net/aspose.slides.smartart/smartart/)) را یا در مجموعه‌های جداگانه پیمایش کنید یا از آن نوع اشیاء عبور کنید.