---
title: API công khai và các thay đổi không tương thích ngược trong Aspose.Slides cho .NET 14.6.0
linktitle: Aspose.Slides cho .NET 14.6.0
type: docs
weight: 80
url: /vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/
keywords:
- di chuyển
- mã cũ
- mã hiện đại
- phương pháp cũ
- phương pháp hiện đại
- PowerPoint
- OpenDocument
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Xem lại các cập nhật API công khai và các thay đổi gây phá vỡ trong Aspose.Slides cho .NET để di chuyển một cách suôn sẻ các giải pháp bản trình bày PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="info" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các mục khác [đã thêm](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/), bất kỳ [hạn chế](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) mới và các [thay đổi](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) khác được giới thiệu cùng với API Aspose.Slides for .NET 14.6.0.

{{% /alert %}} 
## **Các thay đổi API công khai**
### **Các giao diện, phương thức và thuộc tính được thêm**
#### **Đã thêm giao diện Aspose.Slides.Charts.IErrorBarsFormat**
Điều này đại diện cho các thanh lỗi của chuỗi biểu đồ.

Trong trường hợp kiểu giá trị tùy chỉnh, để chỉ định một giá trị, sử dụng thuộc tính ErrorBarCustomValues của điểm dữ liệu cụ thể trong bộ sưu tập DataPoints của chuỗi.

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
#### **Đã thêm giao diện Aspose.Slides.Charts.IErrorBarsCustomValues**
Khi thuộc tính IErrorBarsFormat.ValueType bằng Custom, để chỉ định một giá trị, sử dụng thuộc tính ErrorBarCustomValues của điểm dữ liệu cụ thể trong bộ sưu tập DataPoints.

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
#### **Đã thêm giao diện Aspose.Slides.Charts.IDataSourceTypeForErrorBarsCustomValues**
Xác định các kiểu giá trị trong danh sách thuộc tính ChartDataPoint.ErrorBarsCustomValues.

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
#### **Đã thêm các phương thức Aspose.Slides.IShapeCollection.AddClone(...), và .InsertClone(...)**
Các phương thức sau thêm/chen một bản sao của hình dạng đã chỉ định vào bộ sưu tập. 

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
#### **Đã thêm Enum ViewType, giao diện IViewProperties, lớp ViewProperties và thuộc tính IPresentation.ViewProperties**
IPresentation.ViewProperty cho phép các nhà phát triển thay đổi loại chế độ xem của bản trình bày và hiển thị ghi chú khi bản trình bày được mở trong PowerPoint.

``` csharp
using Aspose.Slides;


 using(Presentation p = new Presentation())

{

    p.ViewProperties.LastView = ViewType.SlideMasterView;

}
```