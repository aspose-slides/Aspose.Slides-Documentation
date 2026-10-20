---
title: Tạo biểu đồ Excel và nhúng chúng vào bản trình chiếu dưới dạng đối tượng OLE
type: docs
weight: 50
url: /vi/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Biểu đồ Excel
- nhúng biểu đồ
- đối tượng OLE
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tạo một biểu đồ Excel bằng Aspose.Cells cho .NET và nhúng workbook vào bản trình chiếu PowerPoint với Aspose.Slides, bao gồm cả bản xem trước biểu đồ."
---
## **Tổng quan**

Bài viết này hướng dẫn cách tạo biểu đồ cột Excel bằng Aspose.Cells for .NET và nhúng workbook của nó vào bản trình chiếu PowerPoint bằng Aspose.Slides for .NET. Workbook được nhúng chứa cả dữ liệu nguồn và biểu đồ. Một bản xem trước PNG riêng hiển thị biểu đồ trên slide trước khi đối tượng OLE được kích hoạt.

Kết quả là một đối tượng Excel được nhúng, không phải biểu đồ PowerPoint gốc. Việc chỉnh sửa workbook qua OLE yêu cầu một ứng dụng desktop hỗ trợ kích hoạt OLE và cài đặt Excel tương thích.

## **Yêu cầu trước**

Thêm tham chiếu tới Aspose.Cells for .NET và Aspose.Slides for .NET trong dự án C# của bạn. Ví dụ sử dụng các câu lệnh cấp cao nhất và yêu cầu C# 9 trở lên. Microsoft Office không bắt buộc để tạo bản trình chiếu với các thư viện này.

Không cần tệp đầu vào: ví dụ tạo dữ liệu và biểu đồ trong bộ nhớ, rồi ghi `OutputChart.pptx` vào thư mục làm việc hiện tại. Áp dụng giấy phép cho cả hai sản phẩm khi chạy ngoài chế độ đánh giá.

## **Cách nhúng hoạt động**

1. Tạo một workbook với một worksheet dữ liệu và một chart sheet.  
2. Đánh dấu chart sheet là active để workbook mở trên biểu đồ.  
3. Đặt phạm vi hiển thị OLE của workbook và render biểu đồ thành PNG.  
4. Lưu workbook dưới dạng XLSX trong bộ nhớ và nhúng các byte đó vào một slide.  
5. Gán PNG làm bản xem trước của đối tượng OLE và lưu bản trình chiếu dưới dạng PPTX.  

Phạm vi hiển thị của workbook và khung trên slide có các vai trò khác nhau. [SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) nhận các chỉ số hàng và cột bắt đầu/kết thúc dựa trên chỉ số không. [ChartCollection.Add](https://reference.aspose.com/cells/net/aspose.cells.charts/chartcollection/add/) thay vào đó nhận hàng trên cùng, cột trái, hàng dưới và cột phải. Ví dụ sử dụng chỉ số hàng 55 và chỉ số cột 25 làm giới hạn góc dưới‑phải; các giá trị này là lựa chọn bố cục, không phải số lượng hàng hoặc cột dữ liệu.

Khung slide sử dụng đơn vị điểm. Ví dụ vừa khít nó trong slide và căn giữa trong khi duy trì tỷ lệ khung hình của PNG, thay vì kéo dài bản xem trước để lấp đầy slide.

## **Tạo và Nhúng Biểu Đồ**

Ví dụ hoàn chỉnh sau đây điền `DataSheet` với bốn hàng và năm cột giá trị. Mỗi hàng trở thành một series biểu đồ. `ChartSheet` được chọn làm sheet hoạt động trước khi workbook được lưu.

Workbook được lưu một cách rõ ràng dưới dạng XLSX, khớp với phần mở rộng `xlsx` được truyền tới [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/). PNG được tải trực tiếp từ luồng của nó mà không cần chuyển đổi bitmap trung gian. Gán nó thông qua [SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/substitutepictureformat/) thay thế placeholder OLE mặc định.

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "DataSheet";

int[,] values =
{
    { 67, 44, 46, 43, 24 },
    { 86, 64, 97, 29, 40 },
    { 68, 89, 78, 69, 38 },
    { 91, 48, 60, 26, 25 }
};

for (var row = 0; row < values.GetLength(0); row++)
{
    for (var column = 0; column < values.GetLength(1); column++)
    {
        dataSheet.Cells[row, column].PutValue(values[row, column]);
    }
}

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
chartSheet.Name = "ChartSheet";

var lastChartRow = 55;
var lastChartColumn = 25;
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, lastChartRow, lastChartColumn);
var chart = chartSheet.Charts[chartIndex];
for (var row = 1; row <= values.GetLength(0); row++)
{
    chart.NSeries.Add($"DataSheet!A{row}:E{row}", false);
}

workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
workbook.Worksheets.SetOleSize(0, lastChartRow, 0, lastChartColumn);

// Render bản xem trước biểu đồ và tuần tự hoá workbook có thể chỉnh sửa riêng biệt.
using var chartImageStream = new MemoryStream();
chart.ToImage(chartImageStream, Aspose.Cells.Drawing.ImageType.Png);
chartImageStream.Position = 0;
using var chartImage = Images.FromStream(chartImageStream);

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Xlsx);
var workbookBytes = workbookStream.ToArray();

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var slideSize = presentation.SlideSize.Size;

// Fit the preview within the slide without changing its aspect ratio.
var scale = Math.Min(slideSize.Width / chartImage.Width, slideSize.Height / chartImage.Height);
var frameWidth = chartImage.Width * scale;
var frameHeight = chartImage.Height * scale;
var frameX = (slideSize.Width - frameWidth) / 2;
var frameY = (slideSize.Height - frameHeight) / 2;

var embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
var previewImage = presentation.Images.AddImage(chartImage);
oleFrame.SubstitutePictureFormat.Picture.Image = previewImage;

presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Kết Quả Mong Đợi**

`OutputChart.pptx` chứa một slide với một workbook Excel được nhúng và bản xem trước biểu đồ. Workbook chứa dữ liệu gốc và một biểu đồ cột với bốn series. Bản xem trước được căn giữa trên slide và giữ nguyên tỷ lệ của nó.

![Biểu đồ cột Excel hiển thị như bản xem trước của một workbook được nhúng](excel-chart-ole-preview.png)

Trong môi trường PowerPoint desktop tương thích có Excel, nhấp đúp vào đối tượng để kích hoạt và chỉnh sửa workbook được nhúng. Việc kích hoạt và chỉnh sửa phụ thuộc vào hỗ trợ OLE và cài đặt bảo mật của ứng dụng chủ.

## **Câu hỏi thường gặp**

**Tại sao cần hình ảnh xem trước?**

Workbook được nhúng và bản xem trước trên slide là các nội dung riêng biệt. Cung cấp một hình ảnh biểu đồ để slide hiển thị biểu đồ thay vì placeholder mặc định "EMBEDDED OLE OBJECT". Xem [Vấn đề xem trước đối tượng khi thêm OleObjectFrame](/slides/vi/net/object-preview-issue-when-adding-oleobjectframe/).

**Bản xem trước có được cập nhật tự động khi tôi thay đổi workbook trong mã không?**

Xem bản xem trước như một ảnh chụp nhanh. Khi cập nhật dữ liệu workbook bằng chương trình, tạo lại hình ảnh biểu đồ và thay thế bản xem trước cũng như dữ liệu workbook được nhúng.

**Tôi có thể sử dụng XLS thay vì XLSX không?**

Có. Lưu workbook ở định dạng XLS và sử dụng `xls` làm phần mở rộng dữ liệu được nhúng. Phần mở rộng phải khớp với định dạng workbook thực tế; chỉ thay đổi phần mở rộng mà không chuyển đổi dữ liệu sẽ không có hiệu lực.

**Tại sao đối tượng có thể thay đổi kích thước sau khi kích hoạt?**

Ứng dụng chủ có thể cập nhật cách trình bày của đối tượng OLE khi nó kích hoạt workbook. Cả phạm vi hiển thị OLE của workbook và kích thước khung slide đều quan trọng. Xem [Giải pháp hoạt động cho việc thay đổi kích thước biểu đồ trong PPTX](/slides/vi/net/working-solution-for-chart-resizing-in-pptx/).

## **Các phần liên quan**

- [Giải pháp hoạt động cho việc thay đổi kích thước biểu đồ trong PPTX](/slides/vi/net/working-solution-for-chart-resizing-in-pptx/)
- [Vấn đề xem trước đối tượng khi thêm OleObjectFrame](/slides/vi/net/object-preview-issue-when-adding-oleobjectframe/)
- [Cập nhật đối tượng OLE tự động bằng Add‑In PowerPoint](/slides/vi/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)