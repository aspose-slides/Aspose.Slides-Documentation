---
title: Liên kết biểu đồ với sổ làm việc bên ngoài
description: Liên kết dữ liệu biểu đồ với một sổ làm việc bên ngoài và làm mới nó.
type: docs
url: /vi/features/external-chart-workbook/
weight: 1070
feature_id: external-chart-workbook
feature_group: charts
translationKey: slides-feature-external-chart-workbook
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-workbook/
---
## **Tổng quan**

Liên kết một biểu đồ với một sổ làm việc bên ngoài thay vì nhúng toàn bộ dữ liệu nguồn vào bản trình bày. Bạn có thể đặt đường dẫn tới sổ làm việc và chọn có cập nhật biểu đồ từ tệp đó hay không. Biểu đồ đã lưu cũng có thể chứa dữ liệu hiển thị được lưu trong bộ nhớ đệm.

## **Ví dụ sử dụng**

Ví dụ C# này sử dụng Aspose.Slides cho .NET. Tạo một sổ làm việc bán hàng hợp lệ với North = 55 và South = 40 và ghi nó dưới dạng sales.xlsx bên cạnh đầu ra. Đặt lại giá trị North của biểu đồ thành 20, sau đó liên kết biểu đồ với đường dẫn tuyệt đối của sổ làm việc và làm mới: North sẽ trở lại 55. Phạm vi rõ ràng bao gồm tiêu đề và hai hàng dữ liệu. Giữ sales.xlsx khả dụng khi mở lại hoặc cập nhật biểu đồ đã liên kết; bản trình bày không nhúng tệp bên ngoài này. Không cần tệp đầu vào. Nó lưu *external-chart-workbook.pptx* và *external-chart-workbook.png*. Cài đặt thư viện bằng [hướng dẫn cài đặt](/slides/vi/net/installation/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using System.IO;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 620, 350);
chart.HasTitle = false;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);
var firstCategory = workbook.GetCell(0, 1, 0, "North");
var secondCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);
var nameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(nameCell, chart.Type);
var firstValue = workbook.GetCell(0, 1, 1, 20);
var secondValue = workbook.GetCell(0, 2, 1, 40);
series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);
firstValue.Value = 55;
var workbookPath = Path.GetFullPath("sales.xlsx");
using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var workbookFile = File.Create(workbookPath))
{
    workbookStream.CopyTo(workbookFile);
}
firstValue.Value = 20;
chart.ChartData.SetExternalWorkbook(workbookPath, true);
chart.ChartData.SetRange("Sheet1!$A$1:$B$3");
presentation.Save("external-chart-workbook.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("external-chart-workbook.png", ImageFormat.Png);
```

## **Câu hỏi thường gặp**

### **Tôi có thể đọc mọi giá trị đã lưu trong bộ nhớ đệm khi tệp liên kết bị thiếu không?**

Aspose.Slides cho .NET 26.11 có thể [đọc các giá trị biểu đồ đã lưu trực tiếp](/slides/vi/net/chart-workbook/#read-cached-chart-values-without-a-workbook) mà không mở sổ làm việc liên kết. Điều này bao gồm các giá trị thường, giá trị X/Y, kích thước bong bóng và giá trị danh mục khi các bộ nhớ đệm đó tồn tại. Dữ liệu đã lưu có thể thiếu hoặc lỗi thời; nó không phải là một sổ làm việc đầy đủ. Việc làm mới từ nguồn vẫn yêu cầu một sổ làm việc hỗ trợ có sẵn. Đối với các SDK và phiên bản khác, hãy kiểm tra hướng dẫn biểu đồ tương ứng của chúng.

### **Điều gì xảy ra nếu sổ làm việc bên ngoài được di chuyển?**

Cập nhật đường dẫn sổ làm việc bên ngoài của biểu đồ tới vị trí mới, và đảm bảo tệp đó khả dụng ở bất kỳ nơi nào bản trình bày được xử lý. Không nên dựa vào dữ liệu đã lưu trong bộ nhớ đệm cho các hoạt động truy cập dữ liệu đầy đủ khi nó bị thiếu.

### **Tôi có thể chọn có làm mới dữ liệu biểu đồ đã lưu trong bộ nhớ đệm khi liên kết hay không?**

Có. Chọn có cập nhật dữ liệu biểu đồ khi thiết lập liên kết hay không. Việc làm mới yêu cầu một sổ làm việc hỗ trợ có sẵn; bỏ qua làm mới sẽ ghi lại liên kết mà không đọc các giá trị mới từ tệp đó.

## **Hướng dẫn**

- [Quản lý sổ làm việc biểu đồ trong bản trình bày bằng .NET](/slides/vi/net/chart-workbook/)

Tính năng liên quan: [Điền dữ liệu vào biểu đồ có thể chỉnh sửa](/slides/vi/features/chart-data-binding/).