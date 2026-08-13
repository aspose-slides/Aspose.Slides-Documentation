---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides สำหรับ .NET 14.6.0
linktitle: Aspose.Slides สำหรับ .NET 14.6.0
type: docs
weight: 80
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/
keywords:
- การย้าย
- โค้ดรุ่นเก่า
- โค้ดสมัยใหม่
- แนวทางรุ่นเก่า
- แนวทางสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ทบทวนการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้เสียหายใน Aspose.Slides สำหรับ .NET เพื่อการย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP อย่างราบรื่น"
---
{{% alert color="info" %}} 

หน้านี้แสดงรายการทุก [เพิ่ม](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) คลาส, เมธอด, คุณสมบัติ ฯลฯ, [ข้อจำกัด](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) ใหม่ และ [การเปลี่ยนแปลง](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) ที่แนะนำมาพร้อมกับ API Aspose.Slides for .NET 14.6.0

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
### **อินเทอร์เฟซ, เมธอด และคุณสมบัติที่เพิ่มเข้ามา**
#### **เพิ่มอินเทอร์เฟซ Aspose.Slides.Charts.IErrorBarsFormat**
นี้เป็นการแสดงแท่งข้อผิดพลาดของชุดข้อมูลในแผนภูมิ

ในกรณีของประเภทค่าที่กำหนดเอง, เพื่อระบุค่าให้ใช้คุณสมบัติ ErrorBarCustomValues ของจุดข้อมูลเฉพาะในคอลเลกชัน DataPoints ของชุดข้อมูล

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    IErrorBarsFormat errBarX = chart.ChartData.Series[0].ErrorBarsXFormat;

    IErrorBarsFormat errBarY = chart.ChartData.Series[0].ErrorBarsYFormat;

    errBarX.IsVisible = true;

    errBarY.IsVisible = true;

    errBarX.ValueType = ErrorBarValueType.Fixed;

    errBarX.Value = 0.1f;

    errBarY.ValueType = ErrorBarValueType.Percentage;

    errBarY.Value = 5;

    errBarX.Type = ErrorBarType.Plus;

    errBarY.Format.Line.Width = 2;

    errBarX.HasEndCap = true;

    pres.Save("ErrorBars.pptx", SaveFormat.Pptx);

}

``` 
#### **เพิ่มอินเทอร์เฟซ Aspose.Slides.Charts.IErrorBarsCustomValues**
เมื่อคุณสมบัติ IErrorBarsFormat.ValueType มีค่าเท่ากับ Custom, เพื่อระบุค่าให้ใช้คุณสมบัติ ErrorBarCustomValues ของจุดข้อมูลเฉพาะในคอลเลกชัน DataPoints

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    IChartSeries series = chart.ChartData.Series[0];

    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;

    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;

    errBarX.IsVisible = true;

    errBarY.IsVisible = true;

    errBarX.ValueType = ErrorBarValueType.Custom;

    errBarY.ValueType = ErrorBarValueType.Custom;

    IChartDataPointCollection points = series.DataPoints;

    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;

    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;

    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;

    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    for (int i = 0; i < points.Count; i++)

    {

        points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;

        points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;

        points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;

        points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;

    }

    pres.Save("ErrorBarsCustomValues", SaveFormat.Pptx);

}

``` 
#### **เพิ่มอินเทอร์เฟซ Aspose.Slides.Charts.IDataSourceTypeForErrorBarsCustomValues**
ระบุประเภทของค่าในรายการคุณสมบัติ ChartDataPoint.ErrorBarsCustomValues

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    IChartSeries series = chart.ChartData.Series[0];

    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;

    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;

    errBarX.IsVisible = true;

    errBarY.IsVisible = true;

    errBarX.ValueType = ErrorBarValueType.Custom;

    errBarY.ValueType = ErrorBarValueType.Custom;

    IChartDataPointCollection points = series.DataPoints;

    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;

    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;

    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;

    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    for (int i = 0; i < points.Count; i++)

    {

        points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;

        points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;

        points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;

        points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;

    }

    pres.Save("ErrorBarsCustomValues", SaveFormat.Pptx);

}

``` 
#### **เพิ่มเมธอด Aspose.Slides.IShapeCollection.AddClone(...), และ .InsertClone(...)**
เมธอดต่อไปนี้เพิ่ม/แทรกสำเนาของรูปร่างที่ระบุลงในคอลเลกชัน 

- Aspose.Slides.IShapeCollection.AddClone(IShape sourceShape)
- Aspose.Slides.IShapeCollection.AddClone(IShape sourceShape, float x, float y)
- Aspose.Slides.IShapeCollection.AddClone(IShape sourceShape, float x, float y, float width, float height)
- Aspose.Slides.IShapeCollection.InsertClone(int index, IShape sourceShape)
- Aspose.Slides.IShapeCollection.InsertClone(int index, IShape sourceShape, float x, float y)
- Aspose.Slides.IShapeCollection.InsertClone(int index, IShape sourceShape, float x, float y, float width, float height)

``` csharp
using Aspose.Slides;


 using (Presentation srcPres = new Presentation("Source Frame.pptx"))

{

    IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;

    ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);

    ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);

    IShapeCollection destShapes = destSlide.Shapes;

    destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);

    destShapes.AddClone(sourceShapes[2]);

    destShapes.AddClone(sourceShapes[3], 50, 200, 50, 50);

    destShapes.AddClone(sourceShapes[4]);

    destShapes.AddClone(sourceShapes[5], 300, 300, 50, 200);

    destShapes.InsertClone(0, sourceShapes[0], 50, 150);

}
``` 
#### **เพิ่ม Enum ViewType, อินเทอร์เฟซ IViewProperties, คลาส ViewProperties และคุณสมบัติ IPresentation.ViewProperties**
IPresentation.ViewProperty ช่วยให้นักพัฒนาสามารถเปลี่ยนประเภทการมองเห็นของการนำเสนอและการแสดงโน้ตเมื่อการนำเสนอถูกเปิดใน PowerPoint

``` csharp
using Aspose.Slides;


 using(Presentation p = new Presentation())

{

    p.ViewProperties.LastView = ViewType.SlideMasterView;

}
```