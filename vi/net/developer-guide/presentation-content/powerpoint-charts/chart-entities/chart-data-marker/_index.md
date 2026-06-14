---
title: Quản lý dấu dữ liệu biểu đồ trong bản trình bày trên .NET
linktitle: Dấu dữ liệu
type: docs
url: /vi/net/chart-data-marker/
keywords:
- biểu đồ
- điểm dữ liệu
- dấu
- tùy chọn dấu
- kích thước dấu
- loại lấp đầy
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách tùy chỉnh dấu dữ liệu biểu đồ trong Aspose.Slides cho .NET, nâng cao tác động của bản trình bày trên các định dạng PPT và PPTX với các ví dụ mã C# rõ ràng."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với các dấu dữ liệu biểu đồ trong Aspose.Slides. Nó cho thấy cách tạo biểu đồ, truy cập một chuỗi và các điểm dữ liệu của nó, áp dụng việc lấp đầy bằng hình ảnh cho các dấu ở mức điểm dữ liệu, điều chỉnh kích thước dấu, và lưu bản trình bày đã cập nhật. Ngoài ra, nó cũng lưu ý rằng các hình dạng dấu tiêu chuẩn có sẵn thông qua enumeration `MarkerStyleType` và giao diện dấu được giữ nguyên khi xuất biểu đồ sang các định dạng raster hoặc SVG.

## **Đặt tùy chọn dấu biểu đồ**
Các dấu có thể được đặt trên các điểm dữ liệu của biểu đồ trong các chuỗi cụ thể. Để đặt tùy chọn dấu biểu đồ, vui lòng thực hiện các bước sau:

- Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
- Tạo biểu đồ mặc định.
- Đặt hình ảnh.
- Lấy chuỗi biểu đồ đầu tiên.
- Thêm điểm dữ liệu mới.
- Ghi bản trình bày ra đĩa.

Trong ví dụ dưới đây, chúng tôi đã đặt tùy chọn dấu biểu đồ ở mức điểm dữ liệu.

```c#
// Tạo một thể hiện của lớp Presentation
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Tạo biểu đồ mặc định
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

// Lấy chỉ mục worksheet dữ liệu biểu đồ mặc định
int defaultWorksheetIndex = 0;

// Lấy worksheet dữ liệu biểu đồ
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Xóa chuỗi demo
chart.ChartData.Series.Clear();

// Thêm chuỗi mới
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);

// Đặt hình ảnh
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// Đặt hình ảnh
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// Lấy chuỗi biểu đồ đầu tiên
IChartSeries series = chart.ChartData.Series[0];

// Thêm điểm mới (1:3) ở đó.
IChartDataPoint point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, (double)2.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, (double)3.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 4, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

// Thay đổi dấu của chuỗi biểu đồ
series.Marker.Size = 15;

// Lưu bản trình bày vào đĩa
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```

## **Câu hỏi thường gặp**

**Các hình dạng dấu nào có sẵn mặc định?**

Các hình dạng tiêu chuẩn có sẵn (hình tròn, hình vuông, hình thoi, hình tam giác, v.v.); danh sách được xác định bởi enumeration [MarkerStyleType](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/markerstyletype/). Nếu bạn cần một hình dạng không tiêu chuẩn, hãy sử dụng dấu với lấp đầy bằng hình ảnh để mô phỏng hình ảnh tùy chỉnh.

**Các dấu có được giữ nguyên khi xuất biểu đồ thành ảnh hoặc SVG không?**

Có. Khi render biểu đồ sang [định dạng raster](/slides/vi/net/convert-powerpoint-to-png/) hoặc lưu [hình dạng dưới dạng SVG](/slides/vi/net/render-a-slide-as-an-svg-image/), các dấu giữ nguyên giao diện và cài đặt của chúng, bao gồm kích thước, màu lấp đầy và đường viền.