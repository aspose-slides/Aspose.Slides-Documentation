---
title: Áp dụng công thức Worksheet biểu đồ trong bản trình chiếu bằng C++
linktitle: Công thức Worksheet
type: docs
weight: 70
url: /vi/cpp/chart-worksheet-formulas/
keywords:
- bảng tính biểu đồ
- worksheet biểu đồ
- công thức biểu đồ
- công thức worksheet
- công thức bảng tính
- workbook dữ liệu biểu đồ
- tính toán công thức
- hằng logic
- hằng số học
- hằng chuỗi
- hằng lỗi
- toán tử số học
- toán tử so sánh
- kiểu A1
- kiểu R1C1
- hàm định nghĩa trước
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Áp dụng công thức kiểu Excel trong các worksheet biểu đồ của Aspose.Slides cho C++, tính lại các giá trị và sử dụng kết quả trong biểu đồ PowerPoint."
---
## **Tổng quan**

Biểu đồ PowerPoint thường lưu trữ dữ liệu nguồn của chúng trong một worksheet nhúng. Trong Aspose.Slides cho C++, bạn có thể truy cập worksheet đó thông qua chart data workbook, ghi giá trị đầu vào, gán công thức cho các ô, tính các công thức được hỗ trợ và sử dụng các ô đã tính toán làm dữ liệu biểu đồ.

Bài viết này giải thích quy trình công thức hoàn chỉnh: tạo một biểu đồ, điền dữ liệu vào worksheet của nó, gán công thức kiểu A1 hoặc R1C1, tính lại chúng, đọc các giá trị đã tính, kết nối các ô đó với một series biểu đồ và lưu bản trình chiếu. Nó cũng mô tả cú pháp công thức được hỗ trợ, tập hợp hàm tích hợp, giá trị đã lưu trong bộ nhớ đệm, các công thức không được hỗ trợ và các lỗi đặc thù của bảng tính.

## **Worksheet và Công thức của Biểu đồ**

Một worksheet của biểu đồ chứa các danh mục, tên series và giá trị được biểu đồ sử dụng. Trong PowerPoint, bạn có thể kiểm tra worksheet bằng cách mở trình chỉnh sửa dữ liệu biểu đồ:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

Trong Aspose.Slides, worksheet được mở ra qua giao diện [IChartDataWorkbook](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdataworkbook/). Sử dụng [IChartDataCell::set_Formula](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatacell/set_formula/) cho công thức kiểu A1 và [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) cho công thức kiểu R1C1. Sau khi thay đổi các ô đầu vào hoặc công thức, gọi [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) để tính lại các công thức được hỗ trợ và cập nhật giá trị ô tương ứng.

Một ô đã tính vẫn cung cấp kết quả qua [IChartDataCell::get_Value](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatacell/get_value/). Điều này quan trọng khi bạn cần kiểm tra kết quả công thức trong mã hoặc sử dụng ô làm điểm dữ liệu cho biểu đồ.

## **Tạo Biểu đồ và Tính Công thức trong Worksheet**

Ví dụ sau minh họa quy trình đầu cuối. Nó tạo một biểu đồ cột nhóm, xóa dữ liệu mẫu, ghi giá trị doanh thu và chi phí quý, tính lợi nhuận bằng công thức, đọc kết quả, sử dụng các ô đã tính làm giá trị biểu đồ và lưu bản trình chiếu.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 350.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();
const int32_t worksheetIndex = 0;

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();
workbook->Clear(worksheetIndex);

auto category1 = workbook->GetCell(worksheetIndex, u"A2", ObjectExt::Box<String>(u"Q1"));
auto category2 = workbook->GetCell(worksheetIndex, u"A3", ObjectExt::Box<String>(u"Q2"));
auto category3 = workbook->GetCell(worksheetIndex, u"A4", ObjectExt::Box<String>(u"Q3"));

workbook->GetCell(worksheetIndex, u"B1", ObjectExt::Box<String>(u"Revenue"));
workbook->GetCell(worksheetIndex, u"C1", ObjectExt::Box<String>(u"Expenses"));
workbook->GetCell(worksheetIndex, u"D1", ObjectExt::Box<String>(u"Profit"));

workbook->GetCell(worksheetIndex, u"B2")->set_Value(ObjectExt::Box<double>(120.0));
workbook->GetCell(worksheetIndex, u"C2")->set_Value(ObjectExt::Box<double>(80.0));
workbook->GetCell(worksheetIndex, u"B3")->set_Value(ObjectExt::Box<double>(150.0));
workbook->GetCell(worksheetIndex, u"C3")->set_Value(ObjectExt::Box<double>(95.0));
workbook->GetCell(worksheetIndex, u"B4")->set_Value(ObjectExt::Box<double>(135.0));
workbook->GetCell(worksheetIndex, u"C4")->set_Value(ObjectExt::Box<double>(110.0));

auto profit1 = workbook->GetCell(worksheetIndex, u"D2");
auto profit2 = workbook->GetCell(worksheetIndex, u"D3");
auto profit3 = workbook->GetCell(worksheetIndex, u"D4");

profit1->set_Formula(u"B2-C2");
profit2->set_Formula(u"B3-C3");
profit3->set_Formula(u"B4-C4");

workbook->CalculateFormulas();

auto q1Profit = profit1->get_Value(); // 40
auto q2Profit = profit2->get_Value(); // 55
auto q3Profit = profit3->get_Value(); // 25

chartData->get_Categories()->Add(category1);
chartData->get_Categories()->Add(category2);
chartData->get_Categories()->Add(category3);

auto profitSeries = chartData->get_Series()->Add(workbook->GetCell(worksheetIndex, u"D1"), chart->get_Type());
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit1);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit2);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit3);
profitSeries->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

presentation->Save(u"chart-formulas.pptx", SaveFormat::Pptx);
```

Các điểm dữ liệu biểu đồ tham chiếu `D2:D4`, vì vậy biểu đồ sử dụng các giá trị lợi nhuận đã tính. Không có lời gọi làm mới biểu đồ riêng trong quy trình này: tính lại workbook trước, sau đó sử dụng hoặc lưu dữ liệu biểu đồ trỏ tới các ô đã tính.

## **Sử dụng Công thức Kiểu A1**

Ký hiệu A1 xác định các cột bằng chữ và các hàng bằng số. Gán các biểu thức kiểu A1 qua [IChartDataCell::set_Formula](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatacell/set_formula/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"C3")->set_Value(ObjectExt::Box<int32_t>(10));
workbook->GetCell(0, u"F2")->set_Value(ObjectExt::Box<int32_t>(2));
workbook->GetCell(0, u"G2")->set_Value(ObjectExt::Box<int32_t>(3));
workbook->GetCell(0, u"H2")->set_Value(ObjectExt::Box<int32_t>(4));

auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"C3+SUM(F2:H2)");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 19
```

Các dạng tham chiếu A1 thông thường là:

| Tham chiếu | Tương đối | Tuyệt đối | Kết hợp |
|---|---|---|---|
| Ô | `A2` | `$A$2` | `A$2`, `$A2` |
| Hàng | `2:2` | `$2:$2` | — |
| Cột | `A:A` | `$A:$A` | — |
| Phạm vi | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Tham chiếu tương đối có thể thay đổi khi công thức được di chuyển hoặc sao chép bởi ứng dụng bảng tính. Tham chiếu tuyệt đối giữ cả hai tọa độ cố định, trong khi tham chiếu kết hợp chỉ cố định một hàng hoặc một cột.

## **Sử dụng Công thức Kiểu R1C1**

Ký hiệu R1C1 xác định cả hàng và cột bằng số. Tham chiếu tương đối dùng các độ lệch trong dấu ngoặc vuông. Gán cú pháp này qua [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"B2")->set_Value(ObjectExt::Box<int32_t>(12));
workbook->GetCell(0, u"C2")->set_Value(ObjectExt::Box<int32_t>(5));

auto cell = workbook->GetCell(0, u"D2");
cell->set_R1C1Formula(u"RC[-2]-RC[-1]");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 7
```

Các dạng tham chiếu R1C1 thông thường là:

| Tham chiếu | Tương đối | Tuyệt đối | Kết hợp |
|---|---|---|---|
| Ô | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Hàng | `R[2]` | `R2` | — |
| Cột | `C[3]` | `C3` | — |
| Phạm vi | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Ví dụ, trong ô `D2`, `RC[-2]` có nghĩa là ô cùng hàng cách hai cột sang trái (`B2`).

## **Hằng và Toán tử trong Công thức**

Trình đánh giá công thức tích hợp hỗ trợ các giá trị logic, hằng số số, chuỗi, giá trị lỗi bảng tính, các toán tử số học và các toán tử so sánh.

### **Hằng và Hằng số**

| Kiểu | Ví dụ | Ghi chú |
|---|---|---|
| Logic | `TRUE`, `FALSE` | Có thể dùng trực tiếp trong biểu thức logic như `A2=TRUE`. |
| Số | `1`, `0.5`, `.3`, `1E-2` | Hỗ trợ ký hiệu thập phân và khoa học. |
| Chuỗi | `"abc"`, `"2/3/2020 12:00"` | Các hằng chuỗi được đặt trong dấu ngoặc kép đôi trong công thức. |
| Kết quả lỗi | `#DIV/0!`, `#N/A`, `#REF!` | Một công thức hợp lệ có thể đánh giá thành giá trị lỗi bảng tính thay vì kết quả bình thường. |

Ví dụ này sử dụng một số loại hằng:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"A2")->set_Value(ObjectExt::Box<bool>(false));
workbook->GetCell(0, u"B2")->set_Formula(u"A2=TRUE");
workbook->GetCell(0, u"C2")->set_Formula(u"1+0.5");
workbook->GetCell(0, u"D2")->set_Formula(u".3*1E-2");
workbook->GetCell(0, u"E2")->set_Formula(u"\"abc\"");
workbook->GetCell(0, u"F2")->set_Formula(u"2/0");

workbook->CalculateFormulas();

auto logicalValue = workbook->GetCell(0, u"B2")->get_Value(); // Sai
auto numericValue = workbook->GetCell(0, u"C2")->get_Value(); // 1.5
auto scientificValue = workbook->GetCell(0, u"D2")->get_Value(); // 0.003
auto stringValue = workbook->GetCell(0, u"E2")->get_Value(); // abc
auto errorValue = workbook->GetCell(0, u"F2")->get_Value(); // #DIV/0!
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

## **Các Hàm Được Định Nghĩa Trước Được Hỗ Trợ**

Aspose.Slides bao gồm một trình đánh giá công thức tích hợp cho worksheet biểu đồ, nhưng không phải là một engine tính toán Excel đầy đủ. Tập hợp hàm được tài liệu giới hạn ở các hàm dưới đây. Đừng cho rằng bất kỳ hàm Excel nào cũng có thể được tính lại bằng [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Hàm | Mục đích hoặc dạng hỗ trợ | Ví dụ |
|---|---|---|
| `ABS` | Giá trị tuyệt đối | `ABS(A2)` |
| `AVERAGE` | Trung bình số học | `AVERAGE(B2:B5)` |
| `CEILING` | Làm tròn lên tới bội số | `CEILING(A2,5)` |
| `CHOOSE` | Chọn giá trị theo chỉ mục | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Nối các giá trị văn bản | `CONCAT(A2,B2)` |
| `CONCATENATE` | Nối các giá trị văn bản | `CONCATENATE(A2," ",B2)` |
| `DATE` | Tạo giá trị ngày dùng hệ thống ngày 1900 | `DATE(2026,8,19)` |
| `DAYS` | Trả về số ngày giữa các ngày | `DAYS(B2,A2)` |
| `FIND` | Tìm một giá trị văn bản trong một giá trị khác | `FIND("-",A2)` |
| `FINDB` | Tìm văn bản theo byte | `FINDB("a",A2)` |
| `IF` | Kết quả có điều kiện | `IF(A2>0,A2,0)` |
| `INDEX` | Dạng tham chiếu | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Dạng vector | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Dạng vector | `MATCH(A2,B2:B5,0)` |
| `MAX` | Giá trị lớn nhất | `MAX(B2:B5)` |
| `SUM` | Tổng các giá trị | `SUM(B2:B5)` |
| `VLOOKUP` | Tìm ngang dọc | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Các hạn chế trong bảng là quan trọng: `INDEX` được mô tả ở dạng tham chiếu, trong khi `LOOKUP` và `MATCH` được mô tả ở dạng vector. `DATE` dùng hệ thống ngày 1900. Các tính năng và hàm không có trong danh sách này nên được coi là không được hỗ trợ bởi trình đánh giá công thức Aspose.Slides trừ khi chúng được tài liệu riêng.

## **Tính Lại và Giá Trị Được Lưu Trữ**

Các tệp bảng tính thường lưu cả công thức và giá trị đã tính cuối cùng. Vì vậy Aspose.Slides có thể đọc giá trị đã lưu từ [IChartDataCell::get_Value](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatacell/get_value/) khi bản trình chiếu được tải và dữ liệu biểu đồ liên quan chưa thay đổi.

Sau khi thay đổi các ô đầu vào hoặc công thức, không nên dựa vào kết quả đã lưu cũ. Gọi [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) trước khi đọc các giá trị đã tính hoặc lưu dữ liệu biểu đồ phụ thuộc vào chúng.

Đối với các công thức ngoài tập hợp được hỗ trợ, Aspose.Slides có thể không phân tích được công thức hoặc xác định được các phụ thuộc. Nếu workbook đã được sửa đổi, giá trị đã lưu trước đó không còn đáng tin cậy. Trong trường hợp đó, việc đọc giá trị của ô có dữ liệu không được hỗ trợ có thể gây ra [CellUnsupportedDataException](https://reference.aspose.com/slides/vi/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Nếu biểu đồ của bạn phụ thuộc vào các hàm Excel mà Aspose.Slides không tính toán, hãy tính các công thức đó bằng một engine bảng tính hỗ trợ và ghi lại các giá trị đã tính vào workbook biểu đồ. Đừng thay thế các công thức không hỗ trợ bằng giá trị đoán.

## **Xử Lý Lỗi Công Thức**

Có hai loại vấn đề cần phân biệt.

Một công thức có thể hợp lệ nhưng tạo ra kết quả lỗi bảng tính như `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` hoặc `#VALUE!`. Trong trường hợp này, token lỗi là kết quả của ô và có thể được trả về qua [IChartDataCell::get_Value](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatacell/get_value/).

Một công thức cũng có thể thất bại ở mức phân tích, tham chiếu, phụ thuộc hoặc dữ liệu không được hỗ trợ. Aspose.Slides cung cấp các ngoại lệ đặc thù cho những trường hợp này: [CellInvalidFormulaException](https://reference.aspose.com/slides/vi/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/vi/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/vi/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/), và [CellUnsupportedDataException](https://reference.aspose.com/slides/vi/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Khi công thức đến từ mẫu hoặc nhập từ người dùng, hãy bao quanh quá trình tính lại và truy cập giá trị bằng các ngoại lệ này:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Spreadsheet/CellCircularReferenceException.h>
#include <Spreadsheet/CellInvalidFormulaException.h>
#include <Spreadsheet/CellInvalidReferenceException.h>
#include <Spreadsheet/CellUnsupportedDataException.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Spreadsheet;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"SUM(B2:B5)");

try
{
    workbook->CalculateFormulas();
    auto value = cell->get_Value();
}
catch (CellInvalidFormulaException&)
{
    // Xử lý công thức không hợp lệ.
}
catch (CellInvalidReferenceException&)
{
    // Xử lý tham chiếu ô không hợp lệ.
}
catch (CellCircularReferenceException&)
{
    // Xử lý tham chiếu vòng.
}
catch (CellUnsupportedDataException&)
{
    // Xử lý dữ liệu bảng tính không được hỗ trợ.
}
```

## **Giới Hạn Thực Tế**

Việc hỗ trợ công thức trong worksheet biểu đồ chỉ nhằm một tập hợp con đã định của các tính toán bảng tính, không phải để tương thích đầy đủ với Excel. Hãy ghi nhớ các giới hạn này khi thiết kế quy trình báo cáo:

- Chỉ sử dụng các hằng, toán tử, tham chiếu và hàm được tài liệu ghi rõ khi cần Aspose.Slides tính lại công thức.
- Tính lại sau khi thay đổi các ô mà kết quả công thức phụ thuộc vào.
- Xem các giá trị đã lưu từ bản trình chiếu đã tải như các ảnh chụp nhanh, không thay thế việc tính lại sau khi chỉnh sửa.
- Kiểm tra các công thức từ mẫu hiện có trước khi dựa vào giá trị đã tính, đặc biệt khi chúng sử dụng các hàm ngoài danh sách tài liệu.
- Đối với các công thức cần engine tính toán bảng tính đầy đủ, hãy tính chúng bên ngoài rồi cập nhật workbook biểu đồ với các giá trị kết quả.

## **Câu Hỏi Thường Gặp**

**Sự khác biệt giữa `set_Formula` và `set_R1C1Formula` là gì?**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatacell/set_formula/) lưu biểu thức kiểu A1 như `B2-C2`. [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) lưu biểu thức kiểu R1C1 như `RC[-2]-RC[-1]`. Sử dụng ký hiệu phù hợp nhất với cách bạn tạo hoặc sao chép công thức.

**Tôi cần đọc ô hoặc giá trị của nó sau khi tính toán?**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) trả về một `IChartDataCell`. Để lấy kết quả đã tính, đọc giá trị của [IChartDataCell::get_Value](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatacell/get_value/) sau khi tính lại.

**Khi nào nên gọi `CalculateFormulas`?**

Gọi [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) sau khi thay đổi giá trị đầu vào hoặc công thức và trước khi bạn phụ thuộc vào kết quả đã tính. Điều này cập nhật các giá trị của các công thức mà trình đánh giá tích hợp hỗ trợ.

**Aspose.Slides có hỗ trợ mọi hàm Excel không?**

Không. Trình đánh giá tích hợp chỉ hỗ trợ một tập hợp hàm được tài liệu liệt kê. Các hàm ngoài tập hợp này không nên được cho là sẽ tính lại đúng. Nếu cần tính toán công thức Excel đầy đủ, hãy thực hiện tính toán bằng một engine bảng tính phù hợp và ghi giá trị cuối cùng vào workbook biểu đồ.

**Điều gì xảy ra nếu một bản trình chiếu đã tải chứa công thức không được hỗ trợ?**

Nếu dữ liệu biểu đồ chưa thay đổi, workbook có thể vẫn chứa giá trị đã lưu trước đó. Sau khi dữ liệu liên quan được sửa đổi, giá trị đã lưu có thể không còn hợp lệ. Truy cập vào ô có công thức không thể xử lý có thể gây ra [CellUnsupportedDataException](https://reference.aspose.com/slides/vi/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Giá trị lỗi công thức có giống với ngoại lệ C++ không?**

Không. Giá trị như `#DIV/0!` là một giá trị bảng tính được tạo ra bởi một phép tính hợp lệ. Các ngoại lệ như [CellInvalidFormulaException](https://reference.aspose.com/slides/vi/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) hoặc [CellCircularReferenceException](https://reference.aspose.com/slides/vi/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) cho biết công thức không thể được xử lý bình thường.

**Biểu đồ có tự động cập nhật khi ô công thức thay đổi không?**

Một series biểu đồ có thể tham chiếu các ô workbook. Tính lại workbook trước, sau đó lưu hoặc render bản trình chiếu. Nếu các điểm dữ liệu biểu đồ tham chiếu các ô đã tính, biểu đồ sẽ sử dụng các giá trị ô đã cập nhật; không cần phương thức làm mới biểu đồ riêng cho quy trình này.

**Biểu đồ có thể sử dụng workbook Excel ngoại vi không?**

Có, dữ liệu biểu đồ có thể được cấu hình để sử dụng workbook ngoại vi thông qua API dữ liệu biểu đồ. Tuy nhiên, quy trình tính công thức được mô tả trong bài viết này liên quan đến workbook dữ liệu biểu đồ và tập hợp công thức do Aspose.Slides đánh giá. Đừng cho rằng [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) cung cấp việc tính lại đầy đủ các công thức tùy ý trong một file XLSX ngoại vi.

**Tôi có thể sử dụng công thức tham chiếu đến worksheet hoặc workbook khác không?**

Các tham chiếu kiểu Excel có thể tồn tại trong workbook biểu đồ, nhưng việc đánh giá công thức bị giới hạn bởi trình phân tích và tập hợp hàm được hỗ trợ. Nếu tham chiếu đa sheet hoặc ngoại vi là thiết yếu, hãy xác nhận công thức chính xác với phiên bản Aspose.Slides bạn đang dùng. Đối với quy trình cần khả năng tham chiếu Excel rộng, hãy tính workbook bên ngoài và ghi lại các giá trị đã giải quyết vào dữ liệu biểu đồ.

**Chuỗi công thức có cần bắt đầu bằng `=` không?**

Các ví dụ API Aspose.Slides gán các biểu thức như `B2-C2` hoặc `SUM(B2:B5)` mà không có dấu `=` đầu. Sử dụng dạng này giúp công thức được tạo ra đồng nhất với các ví dụ trong tài liệu API.