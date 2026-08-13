---
title: چگونه ارائه Hello World را در .NET ایجاد کنیم
linktitle: ارائه Hello World
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
- description: "یک راهنمای ساده برای ایجاد یک ارائه PowerPoint PPT، PPTX و ODP Hello World در .NET با استفاده از Aspose.Slides و هر دو API قدیم و جدید."
---
{{% alert color="info" %}} 

یک [Aspose.Slides for .NET API](/slides/fa/net/) جدید منتشر شده است و اکنون این محصول واحد توانایی ایجاد اسناد PowerPoint از ابتدا و ویرایش اسناد موجود را پشتیبانی می‌کند.

{{% /alert %}} 
## **پشتیبانی از کدهای قدیمی**
برای استفاده از کدهای قدیمی که با نسخه‌های پیش از 13.x Aspose.Slides for .NET توسعه یافته‌اند، باید برخی تغییرات جزئی در کد خود ایجاد کنید و کد همان‌طور که قبلاً کار می‌کرد، عمل خواهد کرد. تمام کلاس‌هایی که در Aspose.Slides for .NET قدیمی تحت فضاهای نام Aspose.Slide و Aspose.Slides.Pptx وجود داشتند، اکنون در یک فضای نام واحد Aspose.Slides ادغام شده‌اند. لطفاً نمونه کد ساده زیر را که برای ایجاد یک سند ارائه Hello World در API قدیمی Aspose.Slides استفاده می‌شود، بررسی کنید و مراحل انتقال به API جدید ادغام‌شده را دنبال کنید.
## **رویکرد قدیمی Aspose.Slides for .NET**
```c#
using System.Drawing;
using Aspose.Slides;

//یک شی Presentation ایجاد می‌کند که نمایانگر یک فایل PPT است
Presentation pres = new Presentation();

//یک شی License ایجاد می‌کند
License license = new License();

//مجوز Aspose.Slides for .NET را تنظیم می‌کند تا محدودیت‌های ارزیابی را از بین ببرد
license.SetLicense("Aspose.Slides.lic");

//اضافه کردن یک اسلاید خالی به ارائه و دریافت مرجع
//اسلاید خالی
Slide slide = pres.AddEmptySlide();

//اضافه کردن یک مستطیل (X=2400, Y=1800, Width=1000 & Height=500) به اسلاید
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//پنهان کردن خطوط مستطیل
rect.LineFormat.ShowLines = false;

//اضافه کردن یک فریم متن به مستطیل با متن پیش‌فرض "Hello World"
rect.AddTextFrame("Hello World");

//حذف اولین اسلاید ارائه که همیشه توسط
//Aspose.Slides for .NET به‌صورت پیش‌فرض هنگام ایجاد ارائه اضافه می‌شود
pres.Slides.RemoveAt(0);

//نوشتن ارائه به‌صورت یک فایل PPT
pres.Write("C:\\hello.ppt");
```

## **رویکرد جدید Aspose.Slides for .NET 13.x**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantiate Presentation
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
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```