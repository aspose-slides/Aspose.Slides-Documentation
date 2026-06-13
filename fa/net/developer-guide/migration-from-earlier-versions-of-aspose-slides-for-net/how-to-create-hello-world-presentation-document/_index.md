---
title: "نحوه ایجاد ارائه‌های Hello World در .NET"
linktitle: "ارائه Hello World"
type: docs
weight: 10
url: /fa/net/how-to-create-hello-world-presentation-document/
keywords:
- مهاجرت
- سلام دنیا
- کدهای قدیمی
- کدهای مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
- description: "یک ارائه PowerPoint PPT، PPTX و ODP Hello World را در .NET با Aspose.Slides با استفاده از هر دو API قدیمی و مدرن در یک راهنمای ساده ایجاد کنید."
---
{{% alert color="primary" %}} 
یک [Aspose.Slides for .NET API](/slides/fa/net/) جدید منتشر شده است و اکنون این محصول واحد قابلیت تولید اسناد PowerPoint از صفر و ویرایش اسناد موجود را دارد.
{{% /alert %}} 
## **پشتیبانی از کدهای قدیم**
برای استفاده از کدهای قدیمی که با Aspose.Slides for .NET نسخه‌های قبل از 13.x توسعه یافته‌اند، نیاز به اعمال برخی تغییرات جزئی در کد خود دارید و کد همانند قبل کار خواهد کرد. تمام کلاس‌هایی که در Aspose.Slides for .NET قبلی تحت فضاهای نام Aspose.Slide و Aspose.Slides.Pptx وجود داشتند، اکنون در یک فضای نام Aspose.Slides ادغام شده‌اند. لطفاً به قطعه کد ساده زیر برای ایجاد سند ارائه Hello World در API قدیمی Aspose.Slides نگاهی بیندازید و مراحل توصیف‌شده برای مهاجرت به API جدید ادغام‌شده را دنبال کنید.
## **رویکرد قدیمی Aspose.Slides for .NET**
```c#
//یک شیء Presentation را که نمایانگر یک فایل PPT است، ایجاد کنید
Presentation pres = new Presentation();

//یک شیء License ایجاد کنید
License license = new License();

//مجوز Aspose.Slides for .NET را تنظیم کنید تا محدودیت‌های ارزیابی حذف شود
license.SetLicense("Aspose.Slides.lic");

//اضافه‌کردن یک اسلاید خالی به ارائه و دریافت مرجع آن
//از آن اسلاید خالی
Slide slide = pres.AddEmptySlide();

//اضافه‌کردن یک مستطیل (X=2400, Y=1800, Width=1000 & Height=500) به اسلاید
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//پنهان‌کردن خطوط مستطیل
rect.LineFormat.ShowLines = false;

//اضافه‌کردن یک فریم متن به مستطیل با "Hello World" به عنوان متن پیش‌فرض
rect.AddTextFrame("Hello World");

//حذف اولین اسلاید ارائه که همواره توسط
//Aspose.Slides for .NET به‌صورت پیش‌فرض هنگام ایجاد ارائه اضافه می‌شود
pres.Slides.RemoveAt(0);

//نوشتن ارائه به صورت یک فایل PPT
pres.Write("C:\\hello.ppt");
```



## **رویکرد جدید Aspose.Slides for .NET 13.x**
```c#
// نمونه‌سازی Presentation
Presentation pres = new Presentation();

// Get the first slide
ISlide sld = (ISlide)pres.Slides[0];

// Add an AutoShape of Rectangle type
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Add ITextFrame to the Rectangle
ashp.AddTextFrame("Hello World");

// Change the text color to Black (which is White by default)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Change the line color of the rectangle to White
ashp.ShapeStyle.LineColor.Color = Color.White;

// Remove any fill formatting in the shape
ashp.FillFormat.FillType = FillType.NoFill;

// Save the presentation to disk
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```