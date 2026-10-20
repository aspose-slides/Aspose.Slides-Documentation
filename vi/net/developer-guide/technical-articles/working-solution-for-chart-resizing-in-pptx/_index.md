---
title: Giải pháp hoạt động cho việc thay đổi kích thước biểu đồ trong PPTX
type: docs
weight: 60
url: /vi/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- thay đổi kích thước biểu đồ
- biểu đồ Excel
- đối tượng OLE
- nhúng biểu đồ
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Khắc phục việc thay đổi kích thước biểu đồ không mong muốn trong PPTX khi sử dụng các đối tượng OLE Excel nhúng với Aspose.Slides cho .NET. Đặt kích thước biểu đồ cố định để giữ cho kích thước biểu đồ và khung OLE nhất quán."
---
## **Bối cảnh**

Biểu đồ Excel được nhúng dưới dạng đối tượng OLE trong bản trình chiếu PowerPoint sử dụng các thành phần Aspose có thể thay đổi kích thước sau khi kích hoạt lần đầu. Điều này có thể gây ra sự khác biệt đáng chú ý về giao diện của biểu đồ trước và sau khi kích hoạt. Bài viết này giải thích tại sao việc thay đổi kích thước xảy ra và chỉ ra cách ngăn ngừa bằng cách khớp kích thước biểu đồ cố định với khung OLE.

Trong [Tạo biểu đồ Excel và nhúng chúng dưới dạng đối tượng OLE trong bản trình chiếu](/slides/vi/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), chúng tôi đã giải thích cách tạo một biểu đồ Excel bằng Aspose.Cells for .NET và nhúng nó vào bản trình chiếu PowerPoint bằng Aspose.Slides for .NET. Để giải quyết [vấn đề xem trước đối tượng](/slides/vi/net/object-preview-issue-when-adding-oleobjectframe/), chúng tôi đã gán hình ảnh biểu đồ cho khung đối tượng OLE của biểu đồ. Trong bản trình chiếu đầu ra, khi bạn nhấp đúp vào khung đối tượng OLE hiển thị hình ảnh biểu đồ, biểu đồ Excel sẽ được kích hoạt. Người dùng có thể chỉnh sửa sổ tính Excel được nhúng và sau đó quay lại slide bằng cách nhấp ra ngoài sổ tính đã kích hoạt. Kích thước của khung đối tượng OLE thay đổi khi người dùng quay lại slide, và hệ số thay đổi kích thước khác nhau tùy thuộc vào kích thước gốc của cả khung OLE và sổ tính Excel được nhúng.

## **Nguyên nhân của việc thay đổi kích thước**

Sổ tính Excel được nhúng có kích thước cửa sổ riêng, mà Excel cố gắng duy trì khi đối tượng được kích hoạt lần đầu. Khung OLE trên slide có kích thước được định nghĩa độc lập. Khi sổ tính Excel được kích hoạt, Excel và PowerPoint sẽ thương lượng kích thước của đối tượng để duy trì tỉ lệ như một phần của quá trình nhúng. Sự khác biệt giữa cửa sổ sổ tính và khung OLE do đó có thể gây ra việc thay đổi kích thước.

## **Giải pháp hoạt động**

Khớp kích thước biểu đồ với khung OLE trên slide và giữ cho kích thước biểu đồ độc lập với cửa sổ sổ tính. Giải pháp này hoạt động với một bản trình chiếu mới hoặc một mẫu hiện có.

Ví dụ yêu cầu Aspose.Cells for .NET và Aspose.Slides for .NET. Nó tạo một biểu đồ cột đơn giản trên một sheet biểu đồ hoạt động và nhúng sổ tính ở định dạng XLS. Không gán hình ảnh xem trước cho biểu đồ; biểu đồ sẽ hiển thị khi đối tượng OLE được kích hoạt trong PowerPoint.

Ví dụ tạo một bản trình chiếu mới với khung OLE kích thước 9.5 × 4 inch, đặt cách lề trái 0.5 inch và cách lề trên 1 inch. Tọa độ và kích thước slide được tính bằng điểm (72 điểm mỗi inch). Đối với một bản trình chiếu hiện có, xem [Sử dụng mẫu](#use-a-template).

## **Đặt kích thước biểu đồ cố định**

Đặt [SizeWithWindow](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/sizewithwindow/) thành false để kích thước biểu đồ không phụ thuộc vào cửa sổ sổ tính. Đặt kích thước của [ChartObject](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/chartobject/) thông qua [Width](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/width/) và [Height](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/height/), chuyển đổi điểm sang pixel bằng 96 pixel mỗi inch: một khung có kích thước 684 × 288 điểm tương đương với biểu đồ 912 × 384 pixel. Đặt [PrintSize](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/printsize/) thành giá trị Custom của [PrintSizeType](https://reference.aspose.com/cells/net/aspose.cells/printsizetype/). Ví dụ nhúng sổ tính bằng [AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addoleobjectframe/) và lưu bản trình chiếu với khung OLE 9.5 × 4 inch.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "Data";
dataSheet.Cells["A1"].PutValue(10);
dataSheet.Cells["A2"].PutValue(20);

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, 20, 10);
var chart = chartSheet.Charts[chartIndex];
chart.NSeries.Add("Data!A1:A2", true);
workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Các tọa độ và kích thước slide được tính bằng điểm (72 điểm mỗi inch).
var width = 684f; // 9,5 inch.
var height = 288f; // 4 inch.

chart.SizeWithWindow = false;
// Chuyển đổi điểm sang pixel biểu đồ bằng 96 pixel mỗi inch.
chart.ChartObject.Width = (int)(width / 72f * 96f);
chart.ChartObject.Height = (int)(height / 72f * 96f);
chart.PrintSize = Aspose.Cells.PrintSizeType.Custom;

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Excel97To2003);
var dataInfo = new OleEmbeddedDataInfo(workbookStream.ToArray(), "xls");
slide.Shapes.AddOleObjectFrame(36, 72, width, height, dataInfo);

presentation.Save("chart-fixed-size.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Sử dụng mẫu**

Luận lý xác định kích thước là như nhau đối với một bản trình chiếu hiện có. Để điều chỉnh ví dụ:

1. Tải bản trình chiếu mẫu thay vì tạo một bản trình chiếu trống.
1. Kiểm tra rằng slide đầu tiên chứa ít nhất ba hình dạng, sau đó sử dụng hình dạng ở chỉ mục 2 làm chỗ giữ chỗ.
1. Lấy chiều rộng và chiều cao của khung từ hình dạng đó thay vì sử dụng các giá trị cố định 684 và 288. Giữ nguyên các phép tính kích thước.
1. Thêm khung OLE tại vị trí của chỗ giữ chỗ thay vì các tọa độ cố định 36 và 72.
1. Xóa chỗ giữ chỗ trước khi lưu bản trình chiếu.

## **Câu hỏi thường gặp**

**Tại sao biểu đồ Excel được nhúng của tôi lại thay đổi kích thước sau khi kích hoạt trong PowerPoint?**

Điều này xảy ra vì Excel cố gắng khôi phục kích thước cửa sổ gốc khi lần đầu kích hoạt, trong khi khung đối tượng OLE trong PowerPoint có kích thước riêng của nó. PowerPoint và Excel sẽ thương lượng kích thước để duy trì tỉ lệ, dẫn đến việc thay đổi kích thước.

**Làm sao tôi có thể giữ cho kích thước biểu đồ và khung OLE luôn nhất quán?**

Đặt kích thước biểu đồ cố định khớp với khung OLE và sử dụng kích thước in biểu đồ tùy chỉnh trước khi nhúng sổ tính. Ví dụ ở trên cho thấy các cài đặt và chuyển đổi đơn vị cần thiết.

**Việc khớp kích thước cửa sổ sổ tính có đủ không?**

Chỉ khớp kích thước cửa sổ sổ tính không đảm bảo ngăn khung OLE thay đổi kích thước sau khi kích hoạt. Cần sử dụng kích thước biểu đồ cố định như trong ví dụ.

**Giải pháp này có hoạt động với cả bản trình chiếu dựa trên mẫu và bản trình chiếu mới không?**

Có. Đối với mẫu, sử dụng kích thước và vị trí của chỗ giữ chỗ. Đối với bản trình chiếu mới, chỉ định trực tiếp kích thước và vị trí khung.

**Tôi có thể sử dụng ví dụ này với các biểu đồ được tạo trong các chương trình bảng tính khác không?**

Ví dụ sử dụng sổ tính Excel được tạo bằng Aspose.Cells. Nó không minh họa hành vi kích hoạt cho các chương trình bảng tính khác.

## **Các phần liên quan**

- [Tạo biểu đồ Excel và nhúng chúng dưới dạng đối tượng OLE trong bản trình chiếu](/slides/vi/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Cập nhật đối tượng OLE tự động bằng Add‑In PowerPoint](/slides/vi/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)