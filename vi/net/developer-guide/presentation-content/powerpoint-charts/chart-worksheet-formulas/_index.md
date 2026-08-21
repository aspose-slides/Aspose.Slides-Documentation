---
title: Áp dụng công thức bảng tính biểu đồ trong bản trình chiếu trên .NET
linktitle: Công thức bảng tính
type: docs
weight: 70
url: /vi/net/chart-worksheet-formulas/
keywords:
- bảng tính biểu đồ
- bảng tính biểu đồ
- công thức biểu đồ
- công thức bảng tính
- công thức bảng tính
- sổ làm việc dữ liệu biểu đồ
- tính toán công thức
- văn hoá ưu tiên
- công thức đặc thù văn hoá
- DBCS
- hằng số logic
- hằng số số
- hằng số chuỗi
- hằng số lỗi
- toán tử số học
- toán tử so sánh
- kiểu A1
- kiểu R1C1
- hàm định trước
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Áp dụng các công thức kiểu Excel trong bảng tính biểu đồ Aspose.Slides cho .NET, tính lại các giá trị và sử dụng kết quả trong biểu đồ PowerPoint."
---
## **Tổng quan**

Biểu đồ PowerPoint thường lưu trữ dữ liệu nguồn trong một bảng tính được nhúng. Trong Aspose.Slides cho .NET, bạn có thể truy cập bảng tính đó thông qua **sổ làm việc dữ liệu biểu đồ**, ghi các giá trị đầu vào, gán công thức cho các ô, tính các công thức được hỗ trợ và sử dụng các ô đã tính làm dữ liệu cho biểu đồ.

Bài viết này giải thích quy trình công thức toàn diện: tạo biểu đồ, điền dữ liệu vào bảng tính, gán công thức dạng A1 hoặc R1C1, tính lại chúng, đọc các giá trị đã tính, kết nối các ô đó với một chuỗi biểu đồ và lưu bản trình chiếu. Nó cũng mô tả cú pháp công thức được hỗ trợ, tập hợp hàm tích hợp, giá trị đã lưu trong bộ nhớ đệm, công thức không được hỗ trợ và các lỗi đặc thù của bảng tính.

## **Bảng tính và Công thức cho Biểu đồ**

Một bảng tính biểu đồ chứa các danh mục, tên chuỗi và giá trị được biểu đồ sử dụng. Trong PowerPoint, bạn có thể kiểm tra bảng tính bằng cách mở **trình chỉnh sửa dữ liệu biểu đồ**:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

Trong Aspose.Slides, bảng tính được tiếp cận qua [sổ làm việc dữ liệu biểu đồ](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/). Sử dụng thuộc tính [Formula](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatacell/formula/) cho công thức dạng A1 và thuộc tính [R1C1Formula](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatacell/r1c1formula/) cho công thức dạng R1C1. Sau khi thay đổi các ô đầu vào hoặc công thức, gọi [CalculateFormulas](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) để tính lại các công thức được hỗ trợ và cập nhật giá trị ô tương ứng.

Một ô đã tính vẫn cung cấp kết quả thông qua thuộc tính [Value](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatacell/value/). Điều này quan trọng khi bạn cần kiểm tra kết quả công thức trong mã hoặc sử dụng ô làm điểm dữ liệu cho biểu đồ.

## **Tạo Biểu đồ và Tính Công thức trong Bảng tính**

Ví dụ sau minh họa quy trình từ đầu đến cuối. Nó tạo một biểu đồ cột nhóm, xóa dữ liệu mẫu, ghi các giá trị doanh thu và chi phí theo quý, tính lợi nhuận bằng công thức, đọc kết quả, sử dụng các ô đã tính làm giá trị cho biểu đồ và lưu bản trình chiếu.

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

Các điểm dữ liệu biểu đồ tham chiếu `D2:D4`, vì vậy biểu đồ sử dụng các giá trị lợi nhuận đã tính. Không có lời gọi làm mới biểu đồ riêng trong quy trình này: tính lại sổ làm việc trước, sau đó sử dụng hoặc lưu dữ liệu biểu đồ trỏ tới các ô đã tính.

## **Sử dụng Công thức Kiểu A1**

Ký hiệu A1 xác định cột bằng chữ và hàng bằng số. Gán các biểu thức kiểu A1 thông qua [IChartDataCell.Formula](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatacell/formula/).

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

Các dạng tham chiếu A1 phổ biến là:

| Tham chiếu | Tương đối | Tuyệt đối | Kết hợp |
|---|---|---|---|
| Ô | `A2` | `$A$2` | `A$2`, `$A2` |
| Hàng | `2:2` | `$2:$2` | — |
| Cột | `A:A` | `$A:$A` | — |
| Dải | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Tham chiếu tương đối có thể thay đổi khi công thức được di chuyển hoặc sao chép bởi ứng dụng bảng tính. Tham chiếu tuyệt đối giữ cố định cả hai tọa độ, trong khi tham chiếu kết hợp chỉ cố định một hàng hoặc một cột.

## **Sử dụng Công thức Kiểu R1C1**

Ký hiệu R1C1 xác định cả hàng và cột bằng số. Tham chiếu tương đối sử dụng khoảng cách trong dấu ngoặc vuông. Gán cú pháp này thông qua [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatacell/r1c1formula/).

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

Các dạng tham chiếu R1C1 phổ biến là:

| Tham chiếu | Tương đối | Tuyệt đối | Kết hợp |
|---|---|---|---|
| Ô | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Hàng | `R[2]` | `R2` | — |
| Cột | `C[3]` | `C3` | — |
| Dải | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Ví dụ, trong ô `D2`, `RC[-2]` có nghĩa là ô cùng hàng, hai cột sang trái (`B2`).

## **Hằng số và Toán tử trong Công thức**

Bộ đánh giá công thức tích hợp hỗ trợ giá trị logic, số nguyên, chuỗi, giá trị lỗi bảng tính, toán tử số học và toán tử so sánh.

### **Hằng số và Giá trị Nguyên thụ**

| Kiểu | Ví dụ | Ghi chú |
|---|---|---|
| Logic | `TRUE`, `FALSE` | Có thể dùng trực tiếp trong biểu thức logic như `A2=TRUE`. |
| Số | `1`, `0.5`, `.3`, `1E-2` | Hỗ trợ ký hiệu thập phân và khoa học. |
| Chuỗi | `"abc"`, `"2/3/2020 12:00"` | Các literal chuỗi được bao trong dấu ngoặc kép trong công thức. |
| Kết quả lỗi | `#DIV/0!`, `#N/A`, `#REF!` | Một công thức hợp lệ có thể trả về giá trị lỗi bảng tính thay vì kết quả bình thường. |

Ví dụ này sử dụng một số kiểu hằng số:

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

### **Toán tử Số học**

| Toán tử | Ý nghĩa | Ví dụ |
|---|---|---|
| `+` | Cộng hoặc dấu cộng một ngôi | `2+3` |
| `-` | Trừ hoặc dấu âm | `2-3`, `-3` |
| `*` | Nhân | `2*3` |
| `/` | Chia | `2/3` |
| `%` | Phần trăm | `30%` |
| `^` | Lũy thừa | `2^3` |

Sử dụng dấu ngoặc để làm rõ thứ tự tính, ví dụ `(A2+B2)*C2`.

### **Toán tử So sánh**

Các biểu thức so sánh trả về giá trị logic.

| Toán tử | Ý nghĩa | Ví dụ |
|---|---|---|
| `=` | Bằng | `A2=3` |
| `<>` | Không bằng | `A2<>3` |
| `>` | Lớn hơn | `A2>3` |
| `>=` | Lớn hơn hoặc bằng | `A2>=3` |
| `<` | Nhỏ hơn | `A2<3` |
| `<=` | Nhỏ hơn hoặc bằng | `A2<=3` |

## **Các Hàm Được Định nghĩa Trước Được Hỗ trợ**

Aspose.Slides bao gồm một bộ đánh giá công thức tích hợp cho bảng tính biểu đồ, nhưng nó không phải là một động cơ tính toán Excel đầy đủ. Tập hợp hàm được tài liệu hoá chỉ giới hạn ở các hàm dưới đây. Đừng cho rằng bất kỳ hàm Excel nào cũng có thể được tính lại bởi [CalculateFormulas](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Hàm | Mục đích hoặc dạng hỗ trợ | Ví dụ |
|---|---|---|
| `ABS` | Giá trị tuyệt đối | `ABS(A2)` |
| `AVERAGE` | Trung bình số học | `AVERAGE(B2:B5)` |
| `CEILING` | Làm tròn lên tới bội số | `CEILING(A2,5)` |
| `CHOOSE` | Chọn giá trị theo chỉ mục | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Nối các giá trị văn bản | `CONCAT(A2,B2)` |
| `CONCATENATE` | Nối các giá trị văn bản | `CONCATENATE(A2," ",B2)` |
| `DATE` | Tạo giá trị ngày theo hệ thống ngày 1900 | `DATE(2026,8,19)` |
| `DAYS` | Trả về số ngày giữa các ngày | `DAYS(B2,A2)` |
| `FIND` | Tìm một chuỗi trong chuỗi khác | `FIND("-",A2)` |
| `FINDB` | Tìm chuỗi theo byte | `FINDB("a",A2)` |
| `IF` | Kết quả có điều kiện | `IF(A2>0,A2,0)` |
| `INDEX` | Dạng tham chiếu | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Dạng vectơ | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Dạng vectơ | `MATCH(A2,B2:B5,0)` |
| `MAX` | Giá trị lớn nhất | `MAX(B2:B5)` |
| `SUM` | Tổng các giá trị | `SUM(B2:B5)` |
| `VLOOKUP` | Tìm kiếm dọc | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Các hạn chế trong bảng quan trọng: `INDEX` được mô tả ở dạng tham chiếu, trong khi `LOOKUP` và `MATCH` ở dạng vectơ. `DATE` sử dụng hệ thống ngày 1900. Các tính năng và hàm không được liệt kê ở đây nên được xem là không được hỗ trợ bởi bộ đánh giá công thức Aspose.Slides trừ khi được tài liệu hoá riêng.

## **Tính Công thức với Văn hoá Ưu tiên**

Một số hàm sổ làm việc biểu đồ diễn giải văn bản dựa trên quy tắc văn hoá riêng. Điều này đặc biệt quan trọng đối với các hàm dành cho ngôn ngữ sử dụng bộ ký tự đôi byte (DBCS). Để tính đúng các công thức như vậy, tạo [LoadOptions](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/), đặt thuộc tính [ISpreadsheetOptions.PreferredCulture](https://reference.aspose.com/slides/vi/net/aspose.slides/ispreadsheetoptions/preferredculture/) thông qua [LoadOptions.SpreadsheetOptions](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/spreadsheetoptions/), rồi tải bản trình chiếu.

Ví dụ sau chọn văn hoá Nhật Bản, mở bản trình chiếu với các tùy chọn tải đã cấu hình và gọi [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) cho mỗi sổ làm việc biểu đồ:

```csharp
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Charts;

var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        PreferredCulture = CultureInfo.GetCultureInfo("ja-JP")
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            chart.ChartData.ChartDataWorkbook.CalculateFormulas();
        }
    }
}
```

Văn hoá ưu tiên là một phần của cấu hình tải bản trình chiếu, vì vậy hãy chỉ định nó trước khi tạo đối tượng [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/). Sử dụng văn hoá phù hợp với các công thức trong sổ làm việc; ví dụ, dùng `ja-JP` cho các công thức cần tuân theo quy tắc tính DBCS của Nhật Bản.

## **Tính Lại và Giá Trị Được Lưu trong Bộ Nhớ Đệm**

Các tệp bảng tính thường lưu cả công thức và giá trị đã tính cuối cùng. Aspose.Slides do đó có thể đọc giá trị được lưu trong bộ nhớ đệm từ [IChartDataCell.Value](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatacell/value/) khi bản trình chiếu được tải và dữ liệu biểu đồ tương ứng chưa bị thay đổi.

Sau khi thay đổi các ô đầu vào hoặc công thức, đừng dựa vào kết quả đã lưu cũ. Gọi [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) trước khi đọc các giá trị đã tính hoặc lưu dữ liệu biểu đồ phụ thuộc vào chúng.

Đối với các công thức nằm ngoài tập hợp được hỗ trợ, Aspose.Slides có thể không thể phân tích cú pháp công thức hoặc xác định các phụ thuộc. Nếu sổ làm việc đã được sửa đổi, giá trị đã lưu trước đó không còn đáng tin cậy. Trong trường hợp đó, việc đọc giá trị của ô có dữ liệu không được hỗ trợ có thể gây ra ngoại lệ [CellUnsupportedDataException](https://reference.aspose.com/slides/vi/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Nếu biểu đồ của bạn phụ thuộc vào các hàm Excel mà Aspose.Slides không tính toán, hãy tính các công thức đó bằng một động cơ bảng tính hỗ trợ và ghi lại các giá trị đã tính vào sổ làm việc biểu đồ. Đừng thay thế các công thức không được hỗ trợ bằng các giá trị ước đoán.

## **Xử Lý Lỗi Công Thức**

Có hai loại vấn đề cần phân biệt.

Một công thức có thể hợp lệ nhưng trả về lỗi bảng tính như `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` hoặc `#VALUE!`. Trong trường hợp này, token lỗi là kết quả của ô và có thể được trả về qua thuộc tính `Value`.

Một công thức cũng có thể thất bại ở mức phân tích cú pháp, tham chiếu, phụ thuộc hoặc dữ liệu không được hỗ trợ. Aspose.Slides cung cấp các ngoại lệ đặc thù cho những trường hợp này: [CellInvalidFormulaException](https://reference.aspose.com/slides/vi/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/vi/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/vi/net/aspose.slides.spreadsheet/cellcircularreferenceexception/), và [CellUnsupportedDataException](https://reference.aspose.com/slides/vi/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Khi công thức đến từ mẫu hoặc đầu vào người dùng, hãy xử lý các ngoại lệ này xung quanh việc tính lại và truy cập giá trị:

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

## **Giới Hạn Thực Tế**

Hỗ trợ công thức trong bảng tính biểu đồ được thiết kế cho một tập hợp con đã định của các tính toán bảng tính, không phải cho tính tương thích đầy đủ với Excel. Hãy nhớ các ràng buộc này khi thiết kế quy trình báo cáo:

- Chỉ sử dụng các hằng số, toán tử, tham chiếu và hàm được tài liệu hoá khi bạn cần Aspose.Slides tính lại công thức.
- Tính lại sau khi thay đổi các ô mà kết quả công thức phụ thuộc.
- Xem các giá trị đã lưu trong bộ nhớ đệm từ bản trình chiếu đã tải như các ảnh chụp nhanh, không phải là thay thế cho việc tính lại sau khi chỉnh sửa.
- Kiểm tra các công thức từ các mẫu hiện có trước khi dựa vào giá trị đã tính, đặc biệt khi chúng sử dụng các hàm nằm ngoài danh sách tài liệu.
- Đối với các công thức yêu cầu động cơ tính toán bảng tính đầy đủ, hãy tính chúng bên ngoài và sau đó cập nhật sổ làm việc biểu đồ với các giá trị kết quả.

## **Câu Hỏi Thường Gặp**

**Sự khác nhau giữa `Formula` và `R1C1Formula` là gì?**

[Formula](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatacell/formula/) lưu trữ biểu thức dạng A1 như `B2-C2`. [R1C1Formula](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatacell/r1c1formula/) lưu trữ biểu thức dạng R1C1 như `RC[-2]-RC[-1]`. Hãy dùng kiểu ký hiệu phù hợp nhất với cách bạn tạo hoặc sao chép công thức.

**Tôi có cần đọc chính ô hay giá trị của nó sau khi tính lại?**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/getcell/) trả về một `IChartDataCell`. Để lấy kết quả đã tính, đọc thuộc tính [Value](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatacell/value/) của ô đó sau khi đã tính lại.

**Khi nào tôi nên gọi `CalculateFormulas`?**

Gọi [CalculateFormulas](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) sau khi thay đổi giá trị đầu vào hoặc công thức và trước khi bạn dựa vào kết quả đã tính. Điều này cập nhật các giá trị của các công thức mà bộ đánh giá tích hợp hỗ trợ.

**Aspose.Slides có hỗ trợ mọi hàm Excel không?**

Không. Bộ đánh giá tích hợp chỉ hỗ trợ một tập hợp hàm đã được tài liệu hoá. Các hàm nằm ngoài tập hợp này không nên được cho là sẽ tính lại đúng. Nếu cần tương thích công thức Excel đầy đủ, hãy thực hiện tính toán bằng một động cơ bảng tính thích hợp và ghi các giá trị cuối cùng vào sổ làm việc biểu đồ.

**Điều gì xảy ra nếu bản trình chiếu đã tải chứa công thức không được hỗ trợ?**

Nếu dữ liệu biểu đồ chưa thay đổi, sổ làm việc có thể vẫn chứa giá trị đã lưu trong bộ nhớ đệm từ trước. Sau khi dữ liệu liên quan được sửa đổi, giá trị đã lưu có thể không còn hợp lệ. Truy cập vào ô có công thức không thể xử lý có thể gây ra [CellUnsupportedDataException](https://reference.aspose.com/slides/vi/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Giá trị lỗi công thức có giống như các ngoại lệ .NET không?**

Không. Giá trị như `#DIV/0!` là một giá trị bảng tính được tạo ra bởi một phép tính hợp lệ. Các ngoại lệ như [CellInvalidFormulaException](https://reference.aspose.com/slides/vi/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) hoặc [CellCircularReferenceException](https://reference.aspose.com/slides/vi/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) chỉ ra rằng công thức không thể được xử lý bình thường.

**Biểu đồ có tự động cập nhật khi ô công thức thay đổi không?**

Một chuỗi biểu đồ có thể tham chiếu các ô trong sổ làm việc. Hãy tính lại sổ làm việc trước, sau đó lưu hoặc render bản trình chiếu. Nếu các điểm dữ liệu biểu đồ tham chiếu các ô đã tính, biểu đồ sẽ sử dụng các giá trị ô đã cập nhật; không cần phương thức làm mới biểu đồ riêng cho quy trình này.

**Biểu đồ có thể sử dụng sổ làm việc Excel bên ngoài không?**

Có, dữ liệu biểu đồ có thể được cấu hình để sử dụng sổ làm việc bên ngoài thông qua API dữ liệu biểu đồ. Tuy nhiên, quy trình tính công thức mô tả trong bài này chỉ liên quan đến sổ làm việc dữ liệu biểu đồ và tập hợp công thức được Aspose.Slides đánh giá. Đừng cho rằng [CalculateFormulas](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) cung cấp tính toán đầy đủ cho bất kỳ công thức nào trong tệp XLSX bên ngoài.

**Tôi có thể sử dụng công thức tham chiếu tới bảng tính hoặc sổ làm việc khác không?**

Các tham chiếu kiểu Excel có thể tồn tại trong sổ làm việc biểu đồ, nhưng việc đánh giá công thức bị giới hạn bởi bộ phân tích và tập hợp hàm hỗ trợ. Nếu một tham chiếu chéo trang hoặc bên ngoài là cần thiết, hãy xác nhận công thức chính xác với phiên bản Aspose.Slides mục tiêu của bạn. Đối với quy trình cần khả năng tương thích tham chiếu Excel rộng, hãy tính toán sổ làm việc bên ngoài và ghi lại các giá trị đã giải quyết vào dữ liệu biểu đồ.

**Chuỗi công thức có phải bắt đầu bằng `=` không?**

Các ví dụ API Aspose.Slides gán các biểu thức như `B2-C2` hoặc `SUM(B2:B5)` mà không có dấu `=` ở đầu. Sử dụng dạng này giữ cho các công thức được tạo ra nhất quán với các ví dụ API được tài liệu hoá.