---
title: مدیریت جعبه‌های متن در ارائه‌ها در .NET
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
description: "Aspose.Slides برای .NET امکان ایجاد، ویرایش و تکثیر جعبه‌های متن در فایل‌های PowerPoint و OpenDocument را به‌سادگی فراهم می‌کند و خودکارسازی ارائه‌های شما را بهبود می‌بخشد."
---
## **معرفی**

متن‌ها در اسلایدها معمولاً در جعبه‌های متن یا اشکال وجود دارند. بنابراین، برای افزودن متن به یک اسلاید، ابتدا باید یک جعبه متن اضافه کنید و سپس متنی داخل آن قرار دهید. 

برای این که بتوانید شکلی که می‌تواند متن را در خود نگهداری کند اضافه کنید، Aspose.Slides برای .NET رابط [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape) را فراهم می‌کند. 

{{% alert title="Note" color="warning" %}} 

Aspose.Slides همچنین رابط [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape) را برای افزودن اشکال به اسلایدها فراهم می‌کند. با این حال، تمام اشکالی که از طریق رابط `IShape` اضافه می‌شوند امکان نگهداری متن را ندارند. اشکالی که از طریق رابط [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape) اضافه می‌شوند معمولاً متن دارند. 

بنابراین، هنگام کار با یک شکل موجود که می‌خواهید متن به آن اضافه کنید، ممکن است بخواهید بررسی و تأیید کنید که این شکل از طریق رابط `IAutoShape` تبدیل شده است. فقط در این صورت می‌توانید با [TextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/properties/textframe) کار کنید که یک ویژگی تحت `IAutoShape` است. بخش [Update Text](https://docs.aspose.com/slides/fa/net/manage-textbox/#update-text) را در این صفحه ببینید.

{{% /alert %}}

## **ایجاد جعبه متن در یک اسلاید**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید. 
2. مرجع اولین اسلاید را از طریق اندیس آن دریافت کنید. 
3. یک شیء [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape) با [ShapeType](https://reference.aspose.com/slides/fa/net/aspose.slides/igeometryshape/properties/shapetype) برابر `Rectangle` در موقعیت مشخصی از اسلاید اضافه کنید و مرجع شیء `IAutoShape` تازه اضافه شده را دریافت کنید. 
4. یک ویژگی `TextFrame` به شیء `IAutoShape` اضافه کنید که متنی را در خود نگه می‌دارد. در مثال زیر، این متن را افزودیم: *Aspose TextBox* 
5. در نهایت، فایل PPTX را از طریق شیء `Presentation` ذخیره کنید. 

این کد C#—یک پیاده‌سازی از مراحل فوق—نحوه افزودن متن به یک اسلاید را نشان می‌دهد:

```c#
// یک نمونه از PresentationEx ایجاد می‌کند
using (Presentation pres = new Presentation())
{

    // اولین اسلاید را در ارائه دریافت می‌کند
    ISlide sld = pres.Slides[0];

    // یک AutoShape با نوع تنظیم‌شده به Rectangle اضافه می‌کند
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // یک TextFrame به Rectangle اضافه می‌کند
    ashp.AddTextFrame(" ");

    // به فریم متن دسترسی می‌یابد
    ITextFrame txtFrame = ashp.TextFrame;

    // شیء Paragraph را برای فریم متن ایجاد می‌کند
    IParagraph para = txtFrame.Paragraphs[0];

    // شیء Portion را برای پاراگراف ایجاد می‌کند
    IPortion portion = para.Portions[0];

    // متن را تنظیم می‌کند
    portion.Text = "Aspose TextBox";

    // ارائه را روی دیسک ذخیره می‌کند
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **بررسی شکل جعبه متن**

Aspose.Slides ویژگی [IsTextBox](https://reference.aspose.com/slides/fa/net/aspose.slides/autoshape/istextbox/) را از رابط [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) فراهم می‌کند تا بتوانید اشکال را بررسی و جعبه‌های متن را شناسایی کنید.

![جعبه متن و شکل](istextbox.png)

این کد C# نحوه بررسی اینکه آیا یک شکل به عنوان جعبه متن ایجاد شده است را نشان می‌دهد:

```c#
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

توجه داشته باشید که اگر فقط یک AutoShape را با استفاده از متد `AddAutoShape` از رابط [IShapeCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/) اضافه کنید، ویژگی `IsTextBox` آن AutoShape مقدار `false` برمی‌گرداند. اما پس از افزودن متن به AutoShape با استفاده از متد `AddTextFrame` یا ویژگی `Text`, ویژگی `IsTextBox` مقدار `true` برمی‌گرداند.

```cs
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

## **افزودن ستون‌ها به جعبه متن**

Aspose.Slides ویژگی‌های [ColumnCount](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/properties/columncount) و [ColumnSpacing](https://reference.aspose.com/slides/fa/net/aspose.slides/textframeformat/properties/columnspacing) (از رابط [ITextFrameFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat) و کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/textframeformat)) را فراهم می‌کند تا بتوانید ستون‌هایی به جعبه‌های متن اضافه کنید. شما می‌توانید تعداد ستون‌ها در جعبه متن را مشخص کنید و سپس فاصله بین ستون‌ها را بر حسب پوینت تعیین کنید. 

این کد C# عملکرد توضیح داده شده را نشان می‌دهد:

```c#
using (Presentation presentation = new Presentation())
{
	// دریافت اولین اسلاید در ارائه
	ISlide slide = presentation.Slides[0];

	// یک AutoShape با نوع تنظیم‌شده به Rectangle اضافه می‌کند
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// یک TextFrame به Rectangle اضافه می‌کند
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// قالب متن TextFrame را دریافت می‌کند
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// تعداد ستون‌ها در TextFrame را مشخص می‌کند
	format.ColumnCount = 3;

	// فاصله بین ستون‌ها را مشخص می‌کند
	format.ColumnSpacing = 10;

	// ارائه را ذخیره می‌کند
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **افزودن ستون‌ها به چارچوب متن**

Aspose.Slides برای .NET ویژگی [ColumnCount](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat/properties/columncount) را از رابط [ITextFrameFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframeformat) فراهم می‌کند که امکان افزودن ستون‌ها به چارچوب‌های متن را می‌دهد. با استفاده از این ویژگی می‌توانید تعداد ستون‌های دلخواه خود را در یک چارچوب متن مشخص کنید. 

این کد C# نشان می‌دهد چگونه یک ستون داخل یک چارچوب متن اضافه کنید:

```c#
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
        Debug.Assert(double.NaN == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
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

Aspose.Slides به شما امکان تغییر یا به‌روزرسانی متنی موجود در جعبه متن یا تمام متون موجود در یک ارائه را می‌دهد. 

این کد C# یک عملیات را نشان می‌دهد که در آن تمام متون در یک ارائه به‌روزرسانی یا تغییر می‌یابند:

```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) // بررسی می‌کند که آیا شکل از فریم متن پشتیبانی می‌کند (IAutoShape). 
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) // مرور پاراگراف‌ها در فریم متن
               {
                   foreach (IPortion portion in paragraph.Portions) // مرور هر بخش در پاراگراف
                   {
                       portion.Text = portion.Text.Replace("years", "months"); // تغییر متن
                       portion.PortionFormat.FontBold = NullableBool.True; // تغییر قالب‌بندی
                   }
               }
           }
       }
   }
  
   // ذخیرهٔ ارائهٔ تغییر یافته
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **افزودن جعبه متن با پیوند**

می‌توانید یک پیوند را داخل جعبه متن درج کنید. هنگام کلیک بر جعبه متن، کاربران به باز کردن پیوند هدایت می‌شوند. 

1. یک نمونه از کلاس `Presentation` ایجاد کنید. 
2. مرجع اولین اسلاید را از طریق اندیس آن دریافت کنید.  
3. یک شیء `AutoShape` با `ShapeType` برابر `Rectangle` در موقعیت مشخصی از اسلاید اضافه کنید و مرجع شیء AutoShape تازه اضافه شده را دریافت کنید. 
4. یک `TextFrame` به شیء `AutoShape` اضافه کنید که متن پیش‌فرض *Aspose TextBox* را در خود دارد. 
5. کلاس `IHyperlinkManager` را نمونه‌سازی کنید. 
6. شیء `IHyperlinkManager` را به ویژگی [HyperlinkClick](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/properties/hyperlinkclick) اختصاص دهید که با بخش دلخواه شما از `TextFrame` مرتبط است. 
7. در نهایت، فایل PPTX را از طریق شیء `Presentation` ذخیره کنید. 

این کد C#—یک پیاده‌سازی از مراحل فوق—نحوه افزودن جعبه متن با پیوند به یک اسلاید را نشان می‌دهد:

```c#
// یک شیء از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
Presentation pptxPresentation = new Presentation();

// اولین اسلاید را در ارائه دریافت می‌کند
ISlide slide = pptxPresentation.Slides[0];

// یک شیء AutoShape با نوع تنظیم‌شده به Rectangle اضافه می‌کند
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// شکل را به AutoShape تبدیل می‌کند
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// به ویژگی ITextFrame مربوط به AutoShape دسترسی پیدا می‌کند
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// مقداری متن به فریم اضافه می‌کند
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// پیوند (Hyperlink) برای متن بخش تنظیم می‌شود
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// ارائه PPTX را ذخیره می‌کند
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **FAQ**

**چه تفاوتی بین جعبه متن و مکان‌نگهدار متن هنگام کار با اسلایدهای اصلی وجود دارد؟**

یک [placeholder](/slides/fa/net/manage-placeholder/) سبک/موقعیت را از [master](https://reference.aspose.com/slides/fa/net/aspose.slides/masterslide/) به ارث می‌برد و می‌تواند در [layouts](https://reference.aspose.com/slides/fa/net/aspose.slides/layoutslide/) بازنویسی شود، در حالی که یک جعبه متن عادی یک شیء مستقل بر روی یک اسلاید خاص است و هنگام تغییر لایه‌ها تغییر نمی‌کند.

**چگونه می‌توانم یک جایگزینی متن بزرگ‌مقیاس در تمام ارائه انجام دهم بدون اینکه متن داخل نمودارها، جدول‌ها و SmartArt را تغییر دهم؟**

تکرار خود را فقط به auto‑shapes‌هایی که دارای فریم متن هستند محدود کنید و اشیای توکار ([charts](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/fa/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/fa/net/aspose.slides.smartart/smartart/)) را با مرور مجموعه‌های آن‌ها جداگانه یا نادیده گرفتن این نوع اشیاء حذف کنید.