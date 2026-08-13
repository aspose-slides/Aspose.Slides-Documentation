---
title: API công cộng và các thay đổi không tương thích ngược trong Aspose.Slides cho .NET 14.10.0
linktitle: Aspose.Slides cho .NET 14.10.0
type: docs
weight: 120
url: /vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
keywords:
- di chuyển
- mã legacy
- mã hiện đại
- phương pháp legacy
- phương pháp hiện đại
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Xem lại các cập nhật API công cộng và các thay đổi phá vỡ trong Aspose.Slides cho .NET để di chuyển một cách suôn sẻ các giải pháp bài thuyết trình PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="info" %}} 
Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các mục khác đã được [thêm](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) hoặc [bị xóa](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/), và các thay đổi khác được giới thiệu trong API Aspose.Slides for .NET 14.10.0.
{{% /alert %}} 
## **Thay đổi API công cộng**
#### **Aspose.Slides.FieldType.Footer Field Type đã được Thêm**
Kiểu trường Footer đã được thêm để thực hiện khả năng tạo các trường loại này và để việc tuần tự hoá bản trình chiếu hợp lệ.
#### **Enum Element ShapeElementFillSource.Own đã bị Xóa**
Phần tử enum ShapeElementFillSource.Own đã bị xóa vì trùng lặp. Hãy sử dụng ShapeElementFillSource.Shape thay vì ShapeElementFillSource.Own.
#### **Methods for Chart Data Points, Categories Removing Have Been Added**
Các phương thức sau, cho phép xóa điểm dữ liệu biểu đồ khỏi bộ sưu tập điểm dữ liệu biểu đồ, đã được thêm:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

Phương thức sau, cho phép xóa một danh mục biểu đồ khỏi bộ sưu tập chứa, đã được thêm:

IChartCategory.Remove()

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

    pres.Save("chart.pptx", SaveFormat.Pptx);
}
``` 
#### **Obsolete Aspose.Slides.ParagraphFormat Properties Have Been Removed**
Các thuộc tính BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle đã bị xóa. Chúng đã được đánh dấu là lỗi thời từ lâu.
#### **Unuseful and Obsolete Constructors Have Been Removed**
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