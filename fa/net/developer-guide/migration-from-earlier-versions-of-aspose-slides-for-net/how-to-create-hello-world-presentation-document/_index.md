---
title: نحوه ایجاد ارائه‌های Hello World در .NET
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
description: "یک ارائه PowerPoint Hello World به فرمت‌های PPT، PPTX و ODP در .NET با Aspose.Slides با استفاده از هر دو API قدیمی و مدرن در یک راهنمای ساده ایجاد کنید."
---
{{% alert color="info" %}} 

یک [API Aspose.Slides برای .NET](/slides/fa/net/) جدید منتشر شده است و اکنون این محصول واحد قابلیت تولید اسناد PowerPoint از ابتدا و ویرایش اسناد موجود را دارد.

{{% /alert %}} 
## **پشتیبانی از کدهای قدیمی**
برای استفاده از کدهای قدیمی که با نسخه‌های Aspose.Slides for .NET قبل از 13.x توسعه یافته‌اند، باید برخی تغییرات جزئی در کد خود اعمال کنید و کد همانند قبل کار خواهد کرد. تمام کلاس‌هایی که در Aspose.Slides for .NET قدیم تحت نام‌فضاهای Aspose.Slide و Aspose.Slides.Pptx موجود بودند، اکنون در یک نام‌فضای Aspose.Slides واحد ترکیب شده‌اند. لطفاً به قطعه کد ساده زیر برای ایجاد یک سند ارائه Hello World در API قدیمی Aspose.Slides نگاه کنید و مراحل توضیح داده‌شده برای مهاجرت به API ترکیبی جدید را دنبال کنید.
## **Legacy Aspose.Slides for .NET Approach**
```c#
using System.Drawing;
using Aspose.Slides;

//یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل PPT است
Presentation pres = new Presentation();

//یک شیء License ایجاد می‌کند
License license = new License();

//مجوز Aspose.Slides برای .NET را تنظیم می‌کند تا از محدودیت‌های ارزیابی جلوگیری شود
license.SetLicense("Aspose.Slides.lic");

//یک اسلاید خالی به ارائه اضافه می‌کند و مرجع آن را دریافت می‌کند
//آن اسلاید خالی
Slide slide = pres.AddEmptySlide();

//یک مستطیل (X=2400, Y=1800, Width=1000 & Height=500) به اسلاید اضافه می‌کند
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//خطوط مستطیل را مخفی می‌کند
rect.LineFormat.ShowLines = false;

//یک فریم متنی به مستطیل اضافه می‌کند با متن پیش‌فرض "Hello World"
rect.AddTextFrame("Hello World");

//حذف اولین اسلاید ارائه که همیشه توسط
//Aspose.Slides برای .NET به‌صورت پیش‌فرض در هنگام ایجاد ارائه اضافه می‌شود
pres.Slides.RemoveAt(0);

//نوشتن ارائه به صورت یک فایل PPT
pres.Write("C:\\hello.ppt");
```



## **New Aspose.Slides for .NET 13.x Approach**
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