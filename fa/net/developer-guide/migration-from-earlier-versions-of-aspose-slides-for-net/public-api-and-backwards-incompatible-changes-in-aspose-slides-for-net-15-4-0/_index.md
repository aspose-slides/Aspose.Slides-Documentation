---
title: "API عمومی و تغییرات ناسازگار با نسخه‌های قبلی در Aspose.Slides برای .NET 15.4.0"
linktitle: "Aspose.Slides برای .NET 15.4.0"
type: docs
weight: 150
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- مهاجرت
- کدهای قدیمی
- کدهای مدرن
- رویکرد قدیمی
- رویکرد مدرن
- پاورپوینت
- سند باز
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای .NET را بررسی کنید تا بتوانید به‌صورت روان راه‌حل‌های ارائهٔ PowerPoint PPT, PPTX و ODP خود را مهاجرت دهید."
---
{{% alert color="info" %}} 

این صفحه تمام کلاس‌ها، متدها، خصوصیات و موارد مشابه که ‎[added](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) یا ‎[removed](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) شده‌اند، و سایر تغییرات معرفی‌شده با API Aspose.Slides for .NET 15.4.0 را فهرست می‌کند.

{{% /alert %}} 
## **تغییرات API عمومی**
#### **Enum OrganizationChartLayoutType اضافه شده است**
Enum Aspose.Slides.SmartArt.OrganizationChartLayoutType نوع قالب‌بندی گره‌های فرزند در نمودار سازمانی را نمایان می‌کند.
#### **متد IBulletFormat.ApplyDefaultParagraphIndentsShifts اضافه شده است**
متد Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts در صورت فعال بودن بولت‌ها، جابه‌جایی‌های پیش‌فرض غیر صفر برای تورفتگی (Indent) و حاشیه چپ (MarginLeft) پاراگراف مؤثر را تنظیم می‌کند (مانند PowerPoint زمانی که بولت/شماره‌گذاری پاراگراف فعال باشد). اگر بولت‌ها غیرفعال باشند، فقط تورفتگی و حاشیه چپ پاراگراف بازنشانی می‌شود (مانند PowerPoint زمانی که بولت/شماره‌گذاری غیرفعال شود).
نمونه‌ها را در ‎[اینجا](/slides/fa/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx) مشاهده کنید:
#### **متد IConnector.Reroute اضافه شده است**
متد Aspose.Slides.IConnector.Reroute اتصال‌دهنده را به‌گونه‌ای مسیر می‌دهد که کوتاه‌ترین مسیر ممکن بین اشکالی که به هم وصل می‌کند اتخاذ شود. برای این کار، متد Reroute() ممکن است مقادیر StartShapeConnectionSiteIndex و EndShapeConnectionSiteIndex را تغییر دهد.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  connector.Reroute();

  input.Save("output.pptx", SaveFormat.Pptx);

}

``` 
#### **متد IPresentation.GetSlideById اضافه شده است**
متد Aspose.Slides.IPresentation.GetSlideById(System.UInt32) یک Slide، MasterSlide یا LayoutSlide را بر اساس شناسه اسلاید (slide Id) برمی‌گرداند.

``` csharp
using System.Diagnostics;
using Aspose.Slides;


 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}
``` 
#### **ویژگی IShape.ConnectionSiteCount اضافه شده است**
ویژگی Aspose.Slides.IShape.ConnectionSiteCount تعداد نقاط اتصال روی شکل را برمی‌گرداند.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  uint wantedIndex = 6;

  if (ellipse.ConnectionSiteCount > wantedIndex)

  {

    connector.StartShapeConnectionSiteIndex = wantedIndex;

  }

  input.Save("output.pptx", SaveFormat.Pptx);

}
``` 
#### **ویژگی ISmartArt.IsReversed اضافه شده است**
ویژگی Aspose.Slides.SmartArt.ISmartArt.IsReversed امکان دریافت یا تنظیم وضعیت نمودار SmartArt را نسبت به چپ‑به‑راست (LTR) یا راست‑به‑چپ (RTL) فراهم می‌کند، در صورتی که نمودار از معکوس‌سازی پشتیبانی کند.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **ویژگی ISmartArt.Nodes اضافه شده است**
ویژگی Aspose.Slides.SmartArt.ISmartArt.Nodes مجموعه‌ای از گره‌های ریشه در شیء SmartArt را برمی‌گرداند.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // انتخاب گره ریشه دوم

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **ویژگی ISmartArtNode.IsHidden اضافه شده است**
ویژگی Aspose.Slides.SmartArt.ISmartArtNode.IsHidden در صورتی که این گره در مدل داده مخفی باشد مقدار true برمی‌گرداند.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //true برمی‌گرداند

  if(hidden)

  {

    //برخی عملیات یا اعلان‌ها را انجام بدهید

  }

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **ویژگی ISmartArtNode.OrganizationChartLayout اضافه شده است**
ویژگی Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout امکان دریافت یا تنظیم نوع نمودار سازمانی مرتبط با گره فعلی را فراهم می‌کند.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **متد set برای ویژگی ISmartArt.Layout اضافه شده است**
متد set برای ویژگی Aspose.Slides.SmartArt.ISmartArt.Layout اضافه شده است. این متد امکان تغییر نوع طرح‌بندی یک نمودار موجود را فراهم می‌کند.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **تغییرات جزئی API**
**این فهرست تغییرات جزئی API است:**

|Enum Aspose.Slides.BevelColorMode |حذف شد، enum استفاده‌نشده |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |حذف شد، ویژگی استفاده‌نشده |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |اضافه شد |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |حذف شد |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |حذف شد به عنوان منسوخ |