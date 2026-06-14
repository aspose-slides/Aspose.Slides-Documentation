---
title: API công khai và các thay đổi không tương thích ngược trong Aspose.Slides cho .NET 15.2.0
linktitle: Aspose.Slides cho .NET 15.2.0
type: docs
weight: 140
url: /vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- di chuyển
- mã cũ
- mã hiện đại
- phương pháp cũ
- phương pháp hiện đại
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Xem xét các cập nhật API công khai và các thay đổi gây lỗi trong Aspose.Slides cho .NET để di chuyển một cách suôn sẻ các giải pháp bản trình chiếu PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="primary" %}}

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính [được thêm](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) hoặc [bị xóa](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) và các thay đổi khác được giới thiệu trong API Aspose.Slides for .NET 15.2.0.

{{% /alert %}}
## **Thay đổi API công khai**
#### **Các phương thức AddDataPointForDoughnutSeries đã được thêm**
Hai phiên bản overload của phương thức IChartDataPointCollection.AddDataPointForDoughnutSeries() đã được thêm để đưa các điểm dữ liệu vào các chuỗi của loại biểu đồ Doughnut.
#### **Lớp Aspose.Slides.SmartArt.SmartArtShape đã kế thừa từ lớp Aspose.Slides.GeometryShape**
Lớp Aspose.Slides.SmartArt.SmartArtShape đã kế thừa từ lớp Aspose.Slides.GeometryShape. Thay đổi này cải thiện mô hình đối tượng Aspose.Slides và thêm các tính năng mới cho lớp SmartArtShape.
#### **Các phương thức để xóa Điểm dữ liệu biểu đồ và Danh mục biểu đồ theo chỉ mục đã được thêm**
Phương thức IChartDataPointCollection.RemoveAt(int index) đã được thêm để xóa điểm dữ liệu biểu đồ theo chỉ mục của nó.
Phương thức IChartCategoryCollection.RemoveAt(int index) đã được thêm để xóa danh mục biểu đồ theo chỉ mục của nó.
#### **Giá trị PptXPptY đã được thêm vào enumeraton Aspose.Slides.Animation.PropertyType**
Giá trị PptXPptY đã được thêm vào enumeraton Aspose.Slides.Animation.PropertyType trong phạm vi sửa lỗi vấn đề tuần tự hoá.
#### **Phương thức System.Drawing.Color GetAutomaticSeriesColor() đã được thêm vào Aspose.Slides.Charts.IChartSeries**
Phương thức GetAutomaticSeriesColor trả về màu tự động của chuỗi dựa trên chỉ mục chuỗi và kiểu biểu đồ. Màu này được sử dụng mặc định nếu FillType bằng NotDefined.

``` csharp



using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}
```