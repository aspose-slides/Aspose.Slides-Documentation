---
title: Áp dụng công thức bảng tính biểu đồ trong bản trình chiếu .NET
linktitle: Công thức Bảng tính
type: docs
weight: 70
url: /vi/net/chart-worksheet-formulas/
keywords:
- bảng tính biểu đồ
- bảng tính của biểu đồ
- công thức biểu đồ
- công thức bảng tính
- công thức bảng tính
- sổ làm việc dữ liệu biểu đồ
- tính toán công thức
- hằng logic
- hằng số số
- hằng chuỗi
- hằng lỗi
- toán tử số học
- toán tử so sánh
- kiểu A1
- kiểu R1C1
- hàm đã định nghĩa trước
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Áp dụng công thức kiểu Excel trong Aspose.Slides cho bảng tính biểu đồ .NET, tính lại giá trị và sử dụng kết quả trong biểu đồ PowerPoint."
---
## **Tổng quan**

Biểu đồ PowerPoint thường lưu trữ dữ liệu nguồn trong một bảng tính được nhúng. Trong Aspose.Slides cho .NET, bạn có thể truy cập bảng tính đó thông qua chart data workbook, ghi giá trị đầu vào, gán công thức cho các ô, tính toán các công thức được hỗ trợ và sử dụng các ô đã tính toán làm dữ liệu biểu đồ.

Bài viết này giải thích quy trình công thức đầy đủ: tạo biểu đồ, điền dữ liệu vào bảng tính, gán công thức kiểu A1 hoặc R1C1, tính lại chúng, đọc giá trị đã tính, kết nối các ô đó với chuỗi dữ liệu biểu đồ và lưu bản trình bày. Ngoài ra còn mô tả cú pháp công thức được hỗ trợ, tập hợp hàm tích hợp, giá trị đã lưu trong bộ nhớ đệm, các công thức không được hỗ trợ và lỗi đặc thù của bảng tính.

## **Bảng tính biểu đồ và công thức**

Một bảng tính biểu đồ chứa các danh mục, tên chuỗi và giá trị được biểu đồ sử dụng. Trong PowerPoint, bạn có thể xem bảng tính bằng cách mở trình chỉnh sửa dữ liệu biểu đồ:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

Trong Aspose.Slides, bảng tính được mở ra thông qua [chart data workbook](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/). Sử dụng thuộc tính [Formula](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatacell/formula/) cho công thức kiểu A1 và thuộc tính [R1C1Formula](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatacell/r1c1formula/) cho công thức kiểu R1C1. Sau khi thay đổi các ô đầu vào hoặc công thức, gọi [CalculateFormulas](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) để tính lại các công thức được hỗ trợ và cập nhật giá trị ô tương ứng.

Một ô đã tính vẫn cung cấp kết quả qua thuộc tính [Value](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatacell/value/). Điều này quan trọng khi bạn cần kiểm tra kết quả công thức trong mã hoặc sử dụng ô làm điểm dữ liệu biểu đồ.

## **Tạo biểu đồ và tính công thức bảng tính**

Ví dụ dưới đây minh họa quy trình từ đầu đến cuối. Nó tạo một biểu đồ cột nhóm, xóa dữ liệu mẫu, ghi giá trị doanh thu và chi phí quý, tính lợi nhuận bằng công thức, đọc kết quả, sử dụng các ô đã tính làm giá trị biểu đồ và lưu bản trình bày.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
workbook.Clear(worksheetIndex);

var category1 = workbook.GetCell(worksheetIndex, "A2", "Q1");
var category2 = workbook.GetCell(worksheetIndex, "A3", "Q2");
var category3 = workbook.GetCell(worksheetIndex, "A4", "Q3");

workbook.GetCell(worksheetIndex, "B1", "Revenue");
workbook.GetCell(worksheetIndex, "C1", "Expenses");
workbook.GetCell(worksheetIndex, "D1", "Profit");

workbook.GetCell(worksheetIndex, "B2").Value = 120.0;
workbook.GetCell(worksheetIndex, "C2").Value = 80.0;
workbook.GetCell(worksheetIndex, "B3").Value = 150.0;
workbook.GetCell(worksheetIndex, "C3").Value = 95.0;
workbook.GetCell(worksheetIndex, "B4").Value = 135.0;
workbook.GetCell(worksheetIndex, "C4").Value = 110.0;

var profit1 = workbook.GetCell(worksheetIndex, "D2");
var profit2 = workbook.GetCell(worksheetIndex, "D3");
var profit3 = workbook.GetCell(worksheetIndex, "D4");

profit1.Formula = "B2-C2";
profit2.Formula = "B3-C3";
profit3.Formula = "B4-C4";

workbook.CalculateFormulas();

var q1Profit = Convert.ToDouble(profit1.Value); // 40
var q2Profit = Convert.ToDouble(profit2.Value); // 55
var q3Profit = Convert.ToDouble(profit3.Value); // 25

Console.WriteLine($"Q1 profit: {q1Profit}");
Console.WriteLine($"Q2 profit: {q2Profit}");
Console.WriteLine($"Q3 profit: {q3Profit}");

chart.ChartData.Categories.Add(category1);
chart.ChartData.Categories.Add(category2);
chart.ChartData.Categories.Add(category3);

var profitSeries = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, "D1"), chart.Type);
profitSeries.DataPoints.AddDataPointForBarSeries(profit1);
profitSeries.DataPoints.AddDataPointForBarSeries(profit2);
profitSeries.DataPoints.AddDataPointForBarSeries(profit3);
profitSeries.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("chart-formulas.pptx", SaveFormat.Pptx);
```

Các điểm dữ liệu biểu đồ tham chiếu `D2:D4`, vì vậy biểu đồ sử dụng các giá trị lợi nhuận đã tính. Không có lời gọi refresh biểu đồ riêng trong quy trình này: tính lại workbook trước, sau đó sử dụng hoặc lưu dữ liệu biểu đồ mà đang trỏ tới các ô đã tính.

## **Sử dụng công thức kiểu A1**

Cú pháp A1 xác định cột bằng chữ và hàng bằng số. Gán biểu thức kiểu A1 thông qua [IChartDataCell.Formula](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatacell/formula/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "C3").Value = 10;
workbook.GetCell(0, "F2").Value = 2;
workbook.GetCell(0, "G2").Value = 3;
workbook.GetCell(0, "H2").Value = 4;

var cell = workbook.GetCell(0, "A2");
cell.Formula = "C3+SUM(F2:H2)";

workbook.CalculateFormulas();

var value = cell.Value; // 19
```

Các dạng tham chiếu A1 phổ biến:

| Tham chiếu | Tương đối | Tuyệt đối | Hỗn hợp |
|---|---|---|---|
| Ô | `A2` | `$A$2` | `A$2`, `$A2` |
| Hàng | `2:2` | `$2:$2` | — |
| Cột | `A:A` | `$A:$A` | — |
| Phạm vi | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Tham chiếu tương đối có thể thay đổi khi công thức được di chuyển hoặc sao chép bởi ứng dụng bảng tính. Tham chiếu tuyệt đối giữ cố định cả hai tọa độ, trong khi tham chiếu hỗn hợp chỉ cố định một hàng hoặc một cột.

## **Sử dụng công thức kiểu R1C1**

Cú pháp R1C1 xác định cả hàng và cột bằng số. Tham chiếu tương đối sử dụng offset trong dấu ngoặc vuông. Gán cú pháp này thông qua [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatacell/r1c1formula/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "B2").Value = 12;
workbook.GetCell(0, "C2").Value = 5;

var cell = workbook.GetCell(0, "D2");
cell.R1C1Formula = "RC[-2]-RC[-1]";

workbook.CalculateFormulas();

var value = cell.Value; // 7
```

Các dạng tham chiếu R1C1 phổ biến:

| Tham chiếu | Tương đối | Tuyệt đối | Hỗn hợp |
|---|---|---|---|
| Ô | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Hàng | `R[2]` | `R2` | — |
| Cột | `C[3]` | `C3` | — |
| Phạm vi | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Ví dụ, trong ô `D2`, `RC[-2]` có nghĩa là ô cùng hàng, hai cột sang trái (`B2`).

## **Các hằng số và toán tử công thức**

Trình đánh giá công thức tích hợp hỗ trợ giá trị logic, hằng số số, chuỗi, giá trị lỗi bảng tính, toán tử số học và toán tử so sánh.

### **Hằng số và hằng nguyên**

| Kiểu | Ví dụ | Ghi chú |
|---|---|---|
| Logic | `TRUE`, `FALSE` | Có thể dùng trực tiếp trong biểu thức logic như `A2=TRUE`. |
| Số | `1`, `0.5`, `.3`, `1E-2` | Hỗ trợ ký hiệu thập phân và khoa học. |
| Chuỗi | `"abc"`, `"2/3/2020 12:00"` | Văn bản được đặt trong dấu ngoặc kép trong công thức. |
| Kết quả lỗi | `#DIV/0!`, `#N/A`, `#REF!` | Một công thức hợp lệ có thể trả về giá trị lỗi bảng tính thay vì kết quả bình thường. |

Ví dụ này sử dụng một số loại hằng số:

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "A2").Value = false;
workbook.GetCell(0, "B2").Formula = "A2=TRUE";
workbook.GetCell(0, "C2").Formula = "1+0.5";
workbook.GetCell(0, "D2").Formula = ".3*1E-2";
workbook.GetCell(0, "E2").Formula = "\"abc\"";
workbook.GetCell(0, "F2").Formula = "2/0";

workbook.CalculateFormulas();

var logicalValue = workbook.GetCell(0, "B2").Value; // Sai
var numericValue = workbook.GetCell(0, "C2").Value; // 1.5
var scientificValue = workbook.GetCell(0, "D2").Value; // 0.003
var stringValue = workbook.GetCell(0, "E2").Value; // abc
var errorValue = workbook.GetCell(0, "F2").Value; // #DIV/0!
```

### **Toán tử số học**

| Toán tử | Ý nghĩa | Ví dụ |
|---|---|---|
| `+` | Cộng hoặc dấu cộng đơn | `2+3` |
| `-` | Trừ hoặc dấu trừ đơn | `2-3`, `-3` |
| `*` | Nhân | `2*3` |
| `/` | Chia | `2/3` |
| `%` | Phần trăm | `30%` |
| `^` | Lũy thừa | `2^3` |

Sử dụng dấu ngoặc để làm rõ thứ tự tính, ví dụ `(A2+B2)*C2`.

### **Toán tử so sánh**

Các biểu thức so sánh trả về giá trị logic.

| Toán tử | Ý nghĩa | Ví dụ |
|---|---|---|
| `=` | Bằng | `A2=3` |
| `<>` | Khác | `A2<>3` |
| `>` | Lớn hơn | `A2>3` |
| `>=` | Lớn hơn hoặc bằng | `A2>=3` |
| `<` | Nhỏ hơn | `A2<3` |
| `<=` | Nhỏ hơn hoặc bằng | `A2<=3` |

## **Các hàm được định nghĩa trước hỗ trợ**

Aspose.Slides bao gồm một trình đánh giá công thức tích hợp cho bảng tính biểu đồ, nhưng nó không phải là một engine tính toán Excel hoàn chỉnh. Bộ hàm được tài liệu hoá giới hạn ở các hàm dưới đây. Đừng cho rằng bất kỳ hàm Excel nào cũng có thể được tính lại bằng [CalculateFormulas](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Hàm | Mục đích hoặc dạng hỗ trợ | Ví dụ |
|---|---|---|
| `ABS` | Giá trị tuyệt đối | `ABS(A2)` |
| `AVERAGE` | Trung bình cộng | `AVERAGE(B2:B5)` |
| `CEILING` | Làm tròn lên đến bội số | `CEILING(A2,5)` |
| `CHOOSE` | Chọn giá trị theo chỉ mục | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Nối các giá trị văn bản | `CONCAT(A2,B2)` |
| `CONCATENATE` | Nối các giá trị văn bản | `CONCATENATE(A2," ",B2)` |
| `DATE` | Tạo giá trị ngày theo hệ 1900 | `DATE(2026,8,19)` |
| `DAYS` | Trả về số ngày giữa các ngày | `DAYS(B2,A2)` |
| `FIND` | Tìm một chuỗi trong chuỗi khác | `FIND("-",A2)` |
| `FINDB` | Tìm theo byte | `FINDB("a",A2)` |
| `IF` | Kết quả có điều kiện | `IF(A2>0,A2,0)` |
| `INDEX` | Dạng tham chiếu | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Dạng vector | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Dạng vector | `MATCH(A2,B2:B5,0)` |
| `MAX` | Giá trị lớn nhất | `MAX(B2:B5)` |
| `SUM` | Tổng các giá trị | `SUM(B2:B5)` |
| `VLOOKUP` | Tìm kiếm dọc | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Các hạn chế trong bảng quan trọng: `INDEX` được tài liệu hoá dưới dạng tham chiếu, trong khi `LOOKUP` và `MATCH` được tài liệu hoá dưới dạng vector. `DATE` sử dụng hệ 1900. Các tính năng và hàm không có trong danh sách này nên được coi là không được hỗ trợ bởi trình đánh giá công thức Aspose.Slides trừ khi được tài liệu hoá riêng.

## **Tính lại và giá trị đã lưu trong bộ đệm**

Các tệp bảng tính thường lưu cả công thức và giá trị đã tính cuối cùng. Aspose.Slides do đó có thể đọc giá trị đã lưu từ [IChartDataCell.Value](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatacell/value/) khi tải bản trình bày và dữ liệu biểu đồ liên quan chưa bị thay đổi.

Sau khi thay đổi các ô đầu vào hoặc công thức, đừng dựa vào kết quả bộ đệm cũ. Gọi [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) trước khi đọc các giá trị đã tính hoặc lưu dữ liệu biểu đồ phụ thuộc vào chúng.

Đối với các công thức nằm ngoài tập hợp hỗ trợ, Aspose.Slides có thể không phân tích được công thức hoặc xác định được các phụ thuộc. Nếu workbook đã bị sửa đổi, giá trị đã lưu trước đó không còn đáng tin cậy. Trong trường hợp đó, việc đọc giá trị của ô có dữ liệu không được hỗ trợ có thể gây ra [CellUnsupportedDataException](https://reference.aspose.com/slides/vi/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Nếu biểu đồ của bạn phụ thuộc vào các hàm Excel mà Aspose.Slides không đánh giá, hãy tính các công thức đó bằng một engine bảng tính hỗ trợ và ghi lại các giá trị đã tính vào workbook biểu đồ. Đừng thay thế các công thức không hỗ trợ bằng giá trị ước tính.

## **Xử lý lỗi công thức**

Có hai loại vấn đề cần phân biệt.

Một công thức có thể hợp lệ nhưng tạo ra kết quả lỗi bảng tính như `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` hoặc `#VALUE!`. Trong trường hợp này, token lỗi là kết quả của ô và có thể trả về qua `Value`.

Một công thức cũng có thể thất bại ở mức phân tích, tham chiếu, phụ thuộc hoặc dữ liệu không được hỗ trợ. Aspose.Slides cung cấp các ngoại lệ đặc thù bảng tính cho các trường hợp này: [CellInvalidFormulaException](https://reference.aspose.com/slides/vi/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/vi/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/vi/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) và [CellUnsupportedDataException](https://reference.aspose.com/slides/vi/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Khi công thức đến từ mẫu hoặc đầu vào người dùng, hãy bắt các ngoại lệ này xung quanh quá trình tính lại và truy cập giá trị:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Spreadsheet;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;
var cell = workbook.GetCell(0, "A2");
cell.Formula = "SUM(B2:B5)";

try
{
    workbook.CalculateFormulas();
    Console.WriteLine(cell.Value);
}
catch (CellInvalidFormulaException ex)
{
    Console.Error.WriteLine($"Invalid formula: {ex.Message}");
}
catch (CellInvalidReferenceException ex)
{
    Console.Error.WriteLine($"Invalid cell reference: {ex.Message}");
}
catch (CellCircularReferenceException ex)
{
    Console.Error.WriteLine($"Circular reference: {ex.Message}");
}
catch (CellUnsupportedDataException ex)
{
    Console.Error.WriteLine($"Unsupported spreadsheet data: {ex.Message}");
}
```

## **Giới hạn thực tiễn**

Hỗ trợ công thức trong bảng tính biểu đồ được thiết kế cho một tập hợp con đã định của các tính toán bảng tính, không phải để tương thích đầy đủ với Excel. Hãy nhớ các ràng buộc này khi thiết kế quy trình báo cáo:

- Chỉ sử dụng các hằng, toán tử, tham chiếu và hàm được tài liệu hoá khi cần Aspose.Slides tính lại công thức.
- Tính lại sau khi thay đổi các ô mà kết quả công thức phụ thuộc.
- Xem các giá trị đã lưu trong bộ đệm từ bản trình bày đã tải như là ảnh chụp nhanh, không phải là thay thế cho việc tính lại sau khi chỉnh sửa.
- Kiểm tra các công thức từ mẫu hiện có trước khi dựa vào giá trị đã tính, đặc biệt khi chúng sử dụng hàm ngoài danh sách tài liệu.
- Đối với các công thức yêu cầu engine tính toán bảng tính toàn diện, hãy tính chúng bên ngoài rồi cập nhật workbook biểu đồ với các giá trị đã tính.

## **Câu hỏi thường gặp**

**Sự khác nhau giữa `Formula` và `R1C1Formula` là gì?**

[Formula](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatacell/formula/) lưu biểu thức kiểu A1 như `B2-C2`. [R1C1Formula](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatacell/r1c1formula/) lưu biểu thức kiểu R1C1 như `RC[-2]-RC[-1]`. Sử dụng cú pháp phù hợp với cách bạn tạo hoặc sao chép công thức.

**Tôi có cần đọc ô hoặc giá trị của ô sau khi tính không?**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/getcell/) trả về một `IChartDataCell`. Để lấy kết quả đã tính, đọc thuộc tính [Value](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatacell/value/) của ô đó sau khi tính lại.

**Khi nào tôi nên gọi `CalculateFormulas`?**

Gọi [CalculateFormulas](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) sau khi thay đổi giá trị đầu vào hoặc công thức và trước khi bạn phụ thuộc vào các kết quả đã tính. Điều này cập nhật các giá trị của các công thức mà trình đánh giá tích hợp hỗ trợ.

**Aspose.Slides có hỗ trợ mọi hàm Excel không?**

Không. Trình đánh giá tích hợp chỉ hỗ trợ một tập hợp hàm đã được tài liệu hoá. Các hàm nằm ngoài tập hợp đó không nên được cho là sẽ tính lại đúng. Nếu cần tính toán công thức Excel đầy đủ, hãy thực hiện bằng một engine bảng tính phù hợp và ghi các giá trị cuối cùng vào workbook biểu đồ.

**Điều gì xảy ra nếu bản trình bày đã tải chứa công thức không được hỗ trợ?**

Nếu dữ liệu biểu đồ không thay đổi, workbook có thể vẫn chứa giá trị đã tính được lưu trong bộ đệm trước đó. Sau khi dữ liệu liên quan bị sửa đổi, giá trị đã lưu có thể không còn hợp lệ. Truy cập vào ô có công thức không thể xử lý có thể gây ra [CellUnsupportedDataException](https://reference.aspose.com/slides/vi/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Giá trị lỗi công thức có giống như ngoại lệ .NET không?**

Không. Một kết quả như `#DIV/0!` là giá trị bảng tính được tạo ra bởi một phép tính hợp lệ. Các ngoại lệ như [CellInvalidFormulaException](https://reference.aspose.com/slides/vi/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) hoặc [CellCircularReferenceException](https://reference.aspose.com/slides/vi/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) cho biết công thức không thể được xử lý bình thường.

**Biểu đồ có tự động cập nhật khi ô công thức thay đổi không?**

Một chuỗi dữ liệu biểu đồ có thể tham chiếu tới các ô workbook. Tính lại workbook trước, sau đó lưu hoặc render bản trình bày. Nếu các điểm dữ liệu biểu đồ tham chiếu các ô đã tính, biểu đồ sẽ sử dụng các giá trị ô đã cập nhật; không cần lời gọi refresh biểu đồ riêng.

**Biểu đồ có thể sử dụng workbook Excel bên ngoài không?**

Có, dữ liệu biểu đồ có thể được cấu hình để sử dụng workbook bên ngoài thông qua API dữ liệu biểu đồ. Tuy nhiên, quy trình tính công thức mô tả trong bài viết này liên quan đến workbook dữ liệu biểu đồ và tập hợp công thức được Aspose.Slides đánh giá. Đừng cho rằng [CalculateFormulas](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) cung cấp việc tính lại đầy đủ các công thức tùy ý trong tệp XLSX bên ngoài.

**Tôi có thể dùng công thức tham chiếu tới bảng tính hoặc workbook khác không?**

Các tham chiếu kiểu Excel có thể tồn tại trong workbook biểu đồ, nhưng việc đánh giá công thức bị hạn chế bởi bộ phân tích và tập hợp hàm được hỗ trợ. Nếu tham chiếu chéo bảng hoặc bên ngoài là thiết yếu, hãy xác thực công thức chính xác với phiên bản Aspose.Slides mục tiêu. Đối với quy trình cần tương thích tham chiếu Excel rộng, hãy tính workbook bên ngoài và ghi lại các giá trị đã giải quyết vào dữ liệu biểu đồ.

**Chuỗi công thức có nên bắt đầu bằng `=` không?**

Các ví dụ API Aspose.Slides gán biểu thức như `B2-C2` hoặc `SUM(B2:B5)` mà không có dấu `=` ở đầu. Sử dụng dạng này giúp công thức được tạo nhất quán với các ví dụ tài liệu API.