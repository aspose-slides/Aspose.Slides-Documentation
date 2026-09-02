---
title: Áp dụng công thức bảng tính biểu đồ trong bản trình bày bằng Python
linktitle: Công thức bảng tính
type: docs
weight: 70
url: /vi/python-net/chart-worksheet-formulas/
keywords:
- bảng tính biểu đồ
- bảng tính biểu đồ
- công thức biểu đồ
- công thức bảng tính
- công thức bảng tính
- sổ làm việc dữ liệu biểu đồ
- tính toán công thức
- ngôn ngữ ưu tiên
- công thức đặc thù ngôn ngữ
- DBCS
- hằng số logic
- hằng số số
- hằng số chuỗi
- hằng số lỗi
- toán tử số học
- toán tử so sánh
- kiểu A1
- kiểu R1C1
- hàm định nghĩa trước
- PowerPoint
- bản trình bày
- Python
- Aspose.Slides
description: Áp dụng công thức kiểu Excel trong Aspose.Slides cho Python qua .NET trên các bảng tính biểu đồ, tính lại các giá trị và sử dụng kết quả trong biểu đồ PowerPoint.
---
## **Tổng quan**

Biểu đồ PowerPoint thường lưu trữ dữ liệu nguồn trong một bảng tính nhúng. Trong Aspose.Slides for Python qua .NET, bạn có thể truy cập bảng tính đó thông qua workbook dữ liệu biểu đồ, ghi giá trị đầu vào, gán công thức cho các ô, tính các công thức được hỗ trợ và sử dụng các ô đã tính làm dữ liệu biểu đồ.

Bài viết này giải thích quy trình công thức hoàn chỉnh: tạo biểu đồ, điền dữ liệu vào bảng tính, gán công thức kiểu A1 hoặc R1C1, tính lại chúng, đọc các giá trị đã tính, kết nối các ô đó với chuỗi dữ liệu biểu đồ và lưu bản trình bày. Nó cũng mô tả cú pháp công thức được hỗ trợ, tập hợp hàm tích hợp, giá trị đã lưu, công thức không được hỗ trợ và các lỗi đặc thù của bảng tính.

## **Bảng tính biểu đồ và công thức**

Bảng tính biểu đồ chứa các danh mục, tên chuỗi và giá trị được biểu đồ sử dụng. Trong PowerPoint, bạn có thể kiểm tra bảng tính bằng cách mở trình chỉnh sửa dữ liệu biểu đồ:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

Trong Aspose.Slides, bảng tính được mở ra thông qua [bảng dữ liệu biểu đồ](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/ichartdataworkbook/). Sử dụng thuộc tính [formula](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/ichartdatacell/formula/) cho công thức kiểu A1 và thuộc tính [r1c1_formula](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) cho công thức kiểu R1C1. Sau khi thay đổi các ô đầu vào hoặc công thức, gọi [calculate_formulas](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) để tính lại các công thức được hỗ trợ và cập nhật các giá trị ô tương ứng.

Một ô đã tính vẫn cung cấp kết quả qua thuộc tính [value](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/ichartdatacell/value/). Điều này quan trọng khi bạn cần kiểm tra kết quả công thức trong mã hoặc sử dụng ô làm điểm dữ liệu biểu đồ.

## **Tạo biểu đồ và tính công thức trong bảng tính**

Ví dụ sau minh họa quy trình từ đầu đến cuối. Nó tạo một biểu đồ cột nhóm, xóa dữ liệu mẫu, ghi giá trị doanh thu và chi phí theo quý, tính lợi nhuận bằng công thức, đọc kết quả, sử dụng các ô đã tính làm giá trị biểu đồ và lưu bản trình bày.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 350)
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    workbook.clear(worksheet_index)

    category1 = workbook.get_cell(worksheet_index, "A2", "Q1")
    category2 = workbook.get_cell(worksheet_index, "A3", "Q2")
    category3 = workbook.get_cell(worksheet_index, "A4", "Q3")

    workbook.get_cell(worksheet_index, "B1", "Revenue")
    workbook.get_cell(worksheet_index, "C1", "Expenses")
    workbook.get_cell(worksheet_index, "D1", "Profit")

    workbook.get_cell(worksheet_index, "B2").value = 120.0
    workbook.get_cell(worksheet_index, "C2").value = 80.0
    workbook.get_cell(worksheet_index, "B3").value = 150.0
    workbook.get_cell(worksheet_index, "C3").value = 95.0
    workbook.get_cell(worksheet_index, "B4").value = 135.0
    workbook.get_cell(worksheet_index, "C4").value = 110.0

    profit1 = workbook.get_cell(worksheet_index, "D2")
    profit2 = workbook.get_cell(worksheet_index, "D3")
    profit3 = workbook.get_cell(worksheet_index, "D4")

    profit1.formula = "B2-C2"
    profit2.formula = "B3-C3"
    profit3.formula = "B4-C4"

    workbook.calculate_formulas()

    q1_profit = profit1.value  # 40
    q2_profit = profit2.value  # 55
    q3_profit = profit3.value  # 25

    print(f"Q1 profit: {q1_profit}")
    print(f"Q2 profit: {q2_profit}")
    print(f"Q3 profit: {q3_profit}")

    chart.chart_data.categories.add(category1)
    chart.chart_data.categories.add(category2)
    chart.chart_data.categories.add(category3)

    profit_series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, "D1"), chart.type)
    profit_series.data_points.add_data_point_for_bar_series(profit1)
    profit_series.data_points.add_data_point_for_bar_series(profit2)
    profit_series.data_points.add_data_point_for_bar_series(profit3)
    profit_series.labels.default_data_label_format.show_value = True

    presentation.save("chart-formulas.pptx", slides.export.SaveFormat.PPTX)
```

Các điểm dữ liệu biểu đồ tham chiếu `D2:D4`, vì vậy biểu đồ sử dụng các giá trị lợi nhuận đã tính. Không có lời gọi làm mới biểu đồ riêng trong quy trình này: tính lại workbook trước, sau đó sử dụng hoặc lưu dữ liệu biểu đồ trỏ tới các ô đã tính.

## **Sử dụng công thức kiểu A1**

Ký hiệu A1 xác định cột bằng chữ và hàng bằng số. Gán các biểu thức kiểu A1 thông qua [IChartDataCell.formula](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/ichartdatacell/formula/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "C3").value = 10
    workbook.get_cell(0, "F2").value = 2
    workbook.get_cell(0, "G2").value = 3
    workbook.get_cell(0, "H2").value = 4

    cell = workbook.get_cell(0, "A2")
    cell.formula = "C3+SUM(F2:H2)"

    workbook.calculate_formulas()

    value = cell.value  # 19
```

Các dạng tham chiếu A1 thường gặp là:

| Tham chiếu | Tương đối | Tuyệt đối | Hỗn hợp |
|---|---|---|---|
| Ô | `A2` | `$A$2` | `A$2`, `$A2` |
| Hàng | `2:2` | `$2:$2` | — |
| Cột | `A:A` | `$A:$A` | — |
| Vùng | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Tham chiếu tương đối có thể thay đổi khi công thức được di chuyển hoặc sao chép bởi ứng dụng bảng tính. Tham chiếu tuyệt đối giữ cố định cả hai tọa độ, trong khi tham chiếu hỗn hợp chỉ cố định một hàng hoặc một cột.

## **Sử dụng công thức kiểu R1C1**

Ký hiệu R1C1 xác định cả hàng và cột bằng số. Tham chiếu tương đối sử dụng offset trong dấu ngoặc vuông. Gán cú pháp này thông qua [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "B2").value = 12
    workbook.get_cell(0, "C2").value = 5

    cell = workbook.get_cell(0, "D2")
    cell.r1c1_formula = "RC[-2]-RC[-1]"

    workbook.calculate_formulas()

    value = cell.value  # 7
```

Các dạng tham chiếu R1C1 thường gặp là:

| Tham chiếu | Tương đối | Tuyệt đối | Hỗn hợp |
|---|---|---|---|
| Ô | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Hàng | `R[2]` | `R2` | — |
| Cột | `C[3]` | `C3` | — |
| Vùng | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Ví dụ, trong ô `D2`, `RC[-2]` nghĩa là ô cùng hàng, hai cột sang trái (`B2`).

## **Hằng số và toán tử công thức**

Bộ đánh giá công thức tích hợp hỗ trợ giá trị logic, số nguyên, chuỗi, giá trị lỗi bảng tính, toán tử số học và toán tử so sánh.

### **Hằng số và literal**

| Kiểu | Ví dụ | Ghi chú |
|---|---|---|
| Logic | `TRUE`, `FALSE` | Có thể dùng trực tiếp trong biểu thức logic như `A2=TRUE`. |
| Số | `1`, `0.5`, `.3`, `1E-2` | Hỗ trợ ký hiệu thập phân và khoa học. |
| Chuỗi | `"abc"`, `"2/3/2020 12:00"` | Literal văn bản được đặt trong dấu ngoặc kép trong công thức. |
| Kết quả lỗi | `#DIV/0!`, `#N/A`, `#REF!` | Một công thức hợp lệ có thể đánh giá thành giá trị lỗi bảng tính thay vì kết quả bình thường. |

Ví dụ này sử dụng nhiều kiểu hằng số:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "A2").value = False
    workbook.get_cell(0, "B2").formula = "A2=TRUE"
    workbook.get_cell(0, "C2").formula = "1+0.5"
    workbook.get_cell(0, "D2").formula = ".3*1E-2"
    workbook.get_cell(0, "E2").formula = "\"abc\""
    workbook.get_cell(0, "F2").formula = "2/0"

    workbook.calculate_formulas()

    logical_value = workbook.get_cell(0, "B2").value  # Sai
    numeric_value = workbook.get_cell(0, "C2").value  # 1.5
    scientific_value = workbook.get_cell(0, "D2").value  # 0.003
    string_value = workbook.get_cell(0, "E2").value  # abc
    error_value = workbook.get_cell(0, "F2").value  # #DIV/0!
```

### **Toán tử số học**

| Toán tử | Ý nghĩa | Ví dụ |
|---|---|---|
| `+` | Cộng hoặc dấu cộng đơn | `2+3` |
| `-` | Trừ hoặc phủ định | `2-3`, `-3` |
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

## **Các hàm tích hợp được hỗ trợ**

Aspose.Slides bao gồm bộ đánh giá công thức tích hợp cho bảng tính biểu đồ, nhưng không phải là một engine tính toán Excel đầy đủ. Tập hợp hàm được tài liệu giới hạn ở các hàm dưới đây. Đừng cho rằng một hàm Excel bất kỳ có thể được tính lại bằng [calculate_formulas](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/).

| Hàm | Mục đích hoặc dạng được hỗ trợ | Ví dụ |
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
| `FINDB` | Tìm kiếm dựa trên byte | `FINDB("a",A2)` |
| `IF` | Kết quả có điều kiện | `IF(A2>0,A2,0)` |
| `INDEX` | Dạng tham chiếu | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Dạng vector | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Dạng vector | `MATCH(A2,B2:B5,0)` |
| `MAX` | Giá trị tối đa | `MAX(B2:B5)` |
| `SUM` | Tổng giá trị | `SUM(B2:B5)` |
| `VLOOKUP` | Tìm kiếm dọc | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Các hạn chế trong bảng là quan trọng: `INDEX` được mô tả ở dạng tham chiếu, trong khi `LOOKUP` và `MATCH` ở dạng vector. `DATE` sử dụng hệ thống ngày 1900. Các tính năng và hàm không được liệt kê ở đây nên được coi là không được hỗ trợ bởi bộ đánh giá công thức Aspose.Slides trừ khi chúng được tài liệu riêng.

## **Tính công thức với ngôn ngữ ưu tiên**

Một số hàm workbook diễn giải văn bản dựa trên quy tắc ngôn ngữ cụ thể. Điều này đặc biệt quan trọng đối với các hàm dành cho ngôn ngữ sử dụng bộ ký tự đa byte (DBCS). Để tính đúng các công thức này, tạo [LoadOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/), đặt [SpreadsheetOptions.preferred_culture](https://reference.aspose.com/slides/vi/python-net/aspose.slides/spreadsheetoptions/) qua [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/spreadsheet_options/), rồi tải bản trình bày.

Ví dụ sau chọn ngôn ngữ Nhật Bản, mở một bản trình bày với tùy chọn tải đã cấu hình và gọi [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) cho mọi workbook biểu đồ:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.preferred_culture = "ja-JP"

with slides.Presentation("presentation.pptx", load_options) as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                shape.chart_data.chart_data_workbook.calculate_formulas()
```

Ngôn ngữ ưu tiên là một phần của cấu hình tải bản trình bày, vì vậy hãy chỉ định trước khi tạo đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/). Sử dụng ngôn ngữ mà các công thức workbook mong đợi; ví dụ, dùng `ja-JP` cho các công thức cần tuân theo quy tắc tính DBCS của tiếng Nhật.

## **Tính lại và giá trị đã lưu**

Các tệp bảng tính thường lưu cả công thức và giá trị đã tính cuối cùng. Aspose.Slides do đó có thể đọc giá trị đã lưu từ [IChartDataCell.value](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/ichartdatacell/value/) khi tải bản trình bày và dữ liệu biểu đồ chưa bị thay đổi.

Sau khi thay đổi các ô đầu vào hoặc công thức, đừng dựa vào kết quả đã lưu cũ. Gọi [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) trước khi đọc giá trị đã tính hoặc lưu dữ liệu biểu đồ phụ thuộc vào chúng.

Đối với các công thức ngoài tập hợp được hỗ trợ, Aspose.Slides có thể không phân tích được công thức hoặc xác định được các phụ thuộc. Nếu workbook đã được chỉnh sửa, giá trị đã lưu trước đây không còn đáng tin cậy. Trong trường hợp đó, việc đọc giá trị của ô có dữ liệu không được hỗ trợ có thể gây ra [CellUnsupportedDataException](https://reference.aspose.com/slides/vi/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Nếu biểu đồ của bạn phụ thuộc vào các hàm Excel mà Aspose.Slides không đánh giá, hãy tính các công thức đó bằng engine bảng tính hỗ trợ và ghi các giá trị đã tính lại vào workbook biểu đồ. Đừng thay thế công thức không được hỗ trợ bằng các giá trị suy đoán.

## **Xử lý lỗi công thức**

Có hai loại vấn đề cần phân biệt.

Một công thức có thể hợp lệ nhưng tạo ra kết quả lỗi bảng tính như `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` hoặc `#VALUE!`. Trong trường hợp này, token lỗi là kết quả của ô và có thể trả về qua `value`.

Một công thức cũng có thể thất bại ở mức phân tích, tham chiếu, phụ thuộc hoặc dữ liệu không được hỗ trợ. Aspose.Slides cung cấp các ngoại lệ đặc thù bảng tính cho các trường hợp này: [CellInvalidFormulaException](https://reference.aspose.com/slides/vi/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/vi/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/vi/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/), và [CellUnsupportedDataException](https://reference.aspose.com/slides/vi/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Khi công thức đến từ mẫu hoặc đầu vào người dùng, hãy xử lý các ngoại lệ này quanh việc tính lại và truy cập giá trị:

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.spreadsheet as spreadsheet

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    cell = workbook.get_cell(0, "A2")
    cell.formula = "SUM(B2:B5)"

    try:
        workbook.calculate_formulas()
        print(cell.value)
    except spreadsheet.CellInvalidFormulaException as ex:
        print(f"Invalid formula: {ex}")
    except spreadsheet.CellInvalidReferenceException as ex:
        print(f"Invalid cell reference: {ex}")
    except spreadsheet.CellCircularReferenceException as ex:
        print(f"Circular reference: {ex}")
    except spreadsheet.CellUnsupportedDataException as ex:
        print(f"Unsupported spreadsheet data: {ex}")
```

## **Hạn chế thực tế**

Hỗ trợ công thức trong bảng tính biểu đồ được thiết kế cho một tập hợp con đã định của các tính toán bảng tính, không phải để tương thích đầy đủ với Excel. Hãy ghi nhớ các ràng buộc này khi thiết kế quy trình báo cáo:

- Chỉ sử dụng các hằng số, toán tử, tham chiếu và hàm được tài liệu khi bạn cần Aspose.Slides tính lại công thức.
- Tính lại sau khi thay đổi các ô mà kết quả công thức phụ thuộc vào.
- Xem các giá trị đã lưu từ bản trình bày đã tải như các ảnh chụp nhanh, không thay thế cho việc tính lại sau khi chỉnh sửa.
- Kiểm tra các công thức từ mẫu hiện có trước khi dựa vào giá trị đã tính, đặc biệt khi chúng sử dụng hàm nằm ngoài danh sách đã tài liệu.
- Đối với các công thức yêu cầu engine tính toán bảng tính đầy đủ, hãy tính chúng bên ngoài và sau đó cập nhật workbook biểu đồ với các giá trị cuối cùng.

## **Câu hỏi thường gặp**

**Sự khác nhau giữa `formula` và `r1c1_formula` là gì?**

[formula](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/ichartdatacell/formula/) lưu một biểu thức kiểu A1 như `B2-C2`. [r1c1_formula](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) lưu một biểu thức kiểu R1C1 như `RC[-2]-RC[-1]`. Sử dụng ký hiệu phù hợp với cách bạn tạo hoặc sao chép công thức.

**Tôi có cần đọc ô nguyên bản hay giá trị của nó sau khi tính không?**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) trả về một `IChartDataCell`. Để lấy kết quả đã tính, đọc thuộc tính [value](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/ichartdatacell/value/) của ô đó sau khi tính lại.

**Khi nào nên gọi `calculate_formulas`?**

Gọi [calculate_formulas](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) sau khi thay đổi giá trị đầu vào hoặc công thức và trước khi bạn phụ thuộc vào kết quả đã tính. Lệnh này cập nhật các giá trị công thức mà bộ đánh giá tích hợp hỗ trợ.

**Aspose.Slides có hỗ trợ mọi hàm Excel không?**

Không. Bộ đánh giá tích hợp chỉ hỗ trợ một tập hợp hàm đã được tài liệu. Các hàm ngoài tập hợp này không nên được cho là sẽ tính lại đúng. Nếu cần tương thích công thức Excel đầy đủ, hãy thực hiện tính toán bằng engine bảng tính phù hợp và ghi giá trị cuối cùng vào workbook biểu đồ.

**Điều gì xảy ra nếu một bản trình bày đã tải chứa công thức không được hỗ trợ?**

Nếu dữ liệu biểu đồ không thay đổi, workbook có thể vẫn chứa giá trị đã lưu trước đó. Sau khi dữ liệu liên quan được sửa đổi, giá trị đã lưu có thể không còn hợp lệ. Truy cập một ô mà công thức không thể xử lý có thể gây ra [CellUnsupportedDataException](https://reference.aspose.com/slides/vi/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Giá trị lỗi công thức có giống như ngoại lệ Python không?**

Không. Một kết quả như `#DIV/0!` là giá trị bảng tính được tạo ra bởi một phép tính hợp lệ. Các ngoại lệ như [CellInvalidFormulaException](https://reference.aspose.com/slides/vi/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/) hoặc [CellCircularReferenceException](https://reference.aspose.com/slides/vi/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) cho biết công thức không thể được xử lý bình thường.

**Biểu đồ có tự động cập nhật khi ô công thức thay đổi không?**

Một chuỗi biểu đồ có thể tham chiếu các ô workbook. Tính lại workbook trước, sau đó lưu hoặc render bản trình bày. Nếu các điểm dữ liệu biểu đồ tham chiếu các ô đã tính, biểu đồ sẽ sử dụng các giá trị ô đã cập nhật; không cần phương thức làm mới biểu đồ riêng cho quy trình này.

**Biểu đồ có thể sử dụng workbook Excel bên ngoài không?**

Có, dữ liệu biểu đồ có thể được cấu hình để sử dụng workbook bên ngoài qua API dữ liệu biểu đồ. Tuy nhiên, quy trình tính công thức mô tả trong bài viết này chỉ liên quan đến workbook dữ liệu biểu đồ và tập hợp công thức được Aspose.Slides đánh giá. Đừng cho rằng [calculate_formulas](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) cung cấp tính toán đầy đủ cho các công thức tùy ý trong tệp XLSX bên ngoài.

**Tôi có thể sử dụng công thức tham chiếu tới bảng tính hoặc workbook khác không?**

Các tham chiếu kiểu Excel có thể tồn tại trong workbook biểu đồ, nhưng việc đánh giá công thức bị giới hạn bởi bộ phân tích và tập hợp hàm được hỗ trợ. Nếu tham chiếu chéo sheet hoặc bên ngoài là thiết yếu, hãy xác thực công thức đó với phiên bản Aspose.Slides bạn dùng. Đối với quy trình cần tương thích tham chiếu Excel rộng, hãy tính workbook bên ngoài và ghi lại các giá trị đã giải quyết vào dữ liệu biểu đồ.

**Chuỗi công thức có nên bắt đầu bằng `=` không?**

Các ví dụ API Aspose.Slides gán các biểu thức như `B2-C2` hoặc `SUM(B2:B5)` mà không có dấu `=` ở đầu. Sử dụng dạng này giúp công thức được tạo ra nhất quán với các ví dụ tài liệu API.