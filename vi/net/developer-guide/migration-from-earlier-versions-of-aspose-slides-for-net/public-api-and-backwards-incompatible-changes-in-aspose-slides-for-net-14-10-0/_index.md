---
title: API công khai và các thay đổi không tương thích ngược trong Aspose.Slides cho .NET 14.10.0
linktitle: Aspose.Slides cho .NET 14.10.0
type: docs
weight: 120
url: /vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
keywords:
- di chuyển
- mã legacy
- mã hiện đại
- cách tiếp cận legacy
- cách tiếp cận hiện đại
- PowerPoint
- OpenDocument
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Xem lại các cập nhật API công khai và các thay đổi gây phá vỡ trong Aspose.Slides cho .NET để dễ dàng di chuyển các giải pháp trình bày PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="primary" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các mục khác đã [được thêm](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) hoặc [được xoá](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/), và các thay đổi khác được giới thiệu trong API Aspose.Slides cho .NET 14.10.0.

{{% /alert %}} 
## **Thay đổi API công khai**
#### **Loại trường Aspose.Slides.FieldType.Footer đã được thêm**
Loại trường Footer đã được thêm để hỗ trợ khả năng tạo các trường loại này và để tuần tự hoá bản trình bày hợp lệ.
#### **Phần tử enum ShapeElementFillSource.Own đã bị xóa**
Phần tử enum ShapeElementFillSource.Own đã bị xóa vì trùng lặp. Hãy sử dụng ShapeElementFillSource.Shape thay vì ShapeElementFillSource.Own.
#### **Các phương thức để xóa Điểm dữ liệu biểu đồ và Danh mục đã được thêm**
Các phương thức sau, cho phép xóa một điểm dữ liệu biểu đồ khỏi bộ sưu tập điểm dữ liệu biểu đồ đã được thêm:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

Phương thức sau, cho phép xóa một danh mục biểu đồ khỏi bộ sưu tập chứa, đã được thêm:

IChartCategory.Remove()

``` csharp

 using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

    chart.ChartData.Categories[0].Remove(); //xóa bằng ChartCategory.Remove()

    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //xóa bằng ChartCategoryCollection.Remove()

    foreach (var ser in chart.ChartData.Series)

    {

        ser.DataPoints[0].Remove();//xóa bằng ChartDataPoint.Remove()

        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()

    }

    pres.Save(outPath, SaveFormat.Pptx);

}

``` 
#### **Các thuộc tính Aspose.Slides.ParagraphFormat lỗi thời đã bị xóa**
Các thuộc tính BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle đã bị xóa. Chúng đã được đánh dấu là lỗi thời từ lâu.
#### **Các hàm khởi tạo không hữu ích và lỗi thời đã bị xóa**
Các hàm khởi tạo sau đã bị xóa:

- Aspose.Slides.Effects.AlphaBiLevel(System.Single)
- Aspose.Slides.Effects.AlphaModulateFixed(System.Single)
- Aspose.Slides.Effects.AlphaReplace(System.Single)
- Aspose.Slides.Effects.BiLevel(System.Single)
- Aspose.Slides.Effects.Blur(System.Double,System.Boolean)
- Aspose.Slides.Effects.HSL(System.Single,System.Single,System.Single)
- Aspose.Slides.Effects.ImageTransformOperation(Aspose.Slides.Effects.ImageTransformOperationCollection)
- Aspose.Slides.Effects.Luminance(System.Single,System.Single)
- Aspose.Slides.Effects.Tint(System.Single,System.Single)
- Aspose.Slides.PortionFormat(Aspose.Slides.ParagraphFormat)
- Aspose.Slides.PortionFormat(Aspose.Slides.Portion)
- Aspose.Slides.PortionFormat(Aspose.Slides.PortionFormat)