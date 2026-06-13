---
title: API عمومی و تغییرات ناسازگار در Aspose.Slides برای .NET 15.4.0
linktitle: Aspose.Slides برای .NET 15.4.0
type: docs
weight: 150
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- مهاجرت
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
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای .NET را مرور کنید تا بتوانید راه‌حل‌های ارائه PowerPoint (PPT، PPTX) و ODP خود را به‌صورت روان منتقل کنید."
---
{{% alert color="primary" %}}
این صفحه تمام کلاس‌ها، متدها، خصوصیات و موارد دیگر که [اضافه](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) یا [حذف](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) شده‌اند و سایر تغییراتی که در API Aspose.Slides for .NET نسخه 15.4.0 معرفی شده‌اند را فهرست می‌کند.
{{% /alert %}}
## **تغییرات API عمومی**
#### **Enum OrganizationChartLayoutType اضافه شده است**
Enum Aspose.Slides.SmartArt.OrganizationChartLayoutType نوع قالب‌بندی گره‌های فرزند در یک نمودار سازمانی را نشان می‌دهد.
#### **Method IBulletFormat.ApplyDefaultParagraphIndentsShifts اضافه شده است**
متد Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts جابه‌جایی‌های پیش‌فرض غیر صفر برای تورفتگی (Indent) و MarginLeft پاراگراف مؤثر را زمانی که گلوله‌ها فعال است تنظیم می‌کند (مانند PowerPoint وقتی که پاراگراف‌های بولت/شماره‌گذاری فعال می‌شوند). اگر گلوله‌ها غیرفعال باشند، فقط تورفتگی و MarginLeft پاراگراف بازنشانی می‌شود (مانند PowerPoint وقتی که بولت/شماره‌گذاری غیرفعال می‌شود).

مثال‌ها را [اینجا](/slides/fa/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx) ببینید:
#### **Method IConnector.Reroute اضافه شده است**
متد Aspose.Slides.IConnector.Reroute اتصال‌دهنده را طوری تغییر مسیر می‌دهد که کوتاه‌ترین مسیر ممکن بین شکل‌هایی که به هم وصل می‌شود را بگیرد. برای این کار، متد Reroute() ممکن است مقدار StartShapeConnectionSiteIndex و EndShapeConnectionSiteIndex را تغییر دهد.

``` csharp

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
#### **Method IPresentation.GetSlideById اضافه شده است**
متد Aspose.Slides.IPresentation.GetSlideById(System.UInt32) یک Slide، MasterSlide یا LayoutSlide را بر اساس شناسه اسلاید برمی‌گرداند.

``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

```
#### **Property IShape.ConnectionSiteCount اضافه شده است**
خصوصیت Aspose.Slides.IShape.ConnectionSiteCount تعداد نقاط اتصال روی شکل را برمی‌گرداند.

``` csharp

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
#### **Property ISmartArt.IsReversed اضافه شده است**
خصوصیت Aspose.Slides.SmartArt.ISmartArt.IsReversed امکان دریافت یا تنظیم وضعیت نمودار SmartArt نسبت به (چپ به راست) LTR یا (راست به چپ) RTL را فراهم می‌کند، اگر نمودار از وارون‌سازی پشتیبانی کند.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

```
#### **Property ISmartArt.Nodes اضافه شده است**
خصوصیت Aspose.Slides.SmartArt.ISmartArt.Nodes مجموعه گره‌های ریشه‌ای در شیء SmartArt را برمی‌گرداند.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // انتخاب گره ریشه دوم

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

```
#### **Property ISmartArtNode.IsHidden اضافه شده است**
خصوصیت Aspose.Slides.SmartArt.ISmartArtNode.IsHidden در صورت اینکه این گره در مدل داده مخفی باشد مقدار true برمی‌گرداند.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //true را برمی‌گرداند

  if(hidden)

  {

    //برخی اقدامات یا اعلان‌ها انجام شود

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

```
#### **Property ISmartArtNode.OrganizationChartLayout اضافه شده است**
خصوصیت Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout امکان دریافت یا تنظیم نوع نمودار سازمانی مرتبط با گرهٔ فعلی را فراهم می‌کند.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

```
#### **Set Method for Property ISmartArt.Layout اضافه شده است**
متد set برای خصوصیت Aspose.Slides.SmartArt.ISmartArt.Layout اضافه شده است. این متد امکان تغییر نوع چینش (layout) یک نمودار موجود را می‌دهد.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

```
#### **تغییرات جزئی API**
**این فهرست تغییرات جزئی API است:**

|Enum Aspose.Slides.BevelColorMode |حذف شده، enum استفاده نشده |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |حذف شده، خصوصیت استفاده نشده |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |اضافه شد |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>ارث‌بری از IParagraphFormatEffectiveData از ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>ارث‌بری از IThreeDFormat از ISlideComponent |حذف شد |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |حذف شد به عنوان منسوخ |