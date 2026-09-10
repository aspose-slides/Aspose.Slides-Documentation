---
title: Áp dụng công thức bảng tính biểu đồ trong các bản trình chiếu bằng Python qua Java
linktitle: Công thức bảng tính
type: docs
weight: 70
url: /vi/python-java/chart-worksheet-formulas/
keywords:
- bảng tính biểu đồ
- bảng tính biểu đồ
- công thức biểu đồ
- công thức bảng tính
- công thức bảng tính
- sổ làm việc dữ liệu biểu đồ
- tính toán công thức
- ngôn ngữ ưu tiên
- công thức đặc trưng cho ngôn ngữ
- DBCS
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
- Python
- Java
- Aspose.Slides
description: "Áp dụng công thức kiểu Excel trong các bảng tính biểu đồ của Aspose.Slides cho Python qua Java, tính lại giá trị và sử dụng kết quả trong biểu đồ PowerPoint."
---
## **Tổng quan**

Biểu đồ PowerPoint thường lưu trữ dữ liệu nguồn của chúng trong một bảng tính được nhúng. Trong Aspose.Slides cho Python qua Java, bạn có thể truy cập bảng tính đó thông qua workbook dữ liệu biểu đồ, ghi giá trị đầu vào, gán công thức cho các ô, tính các công thức được hỗ trợ và sử dụng các ô đã tính làm dữ liệu biểu đồ.

Bài viết này giải thích quy trình công thức đầy đủ: tạo một biểu đồ, điền dữ liệu vào bảng tính của nó, gán công thức kiểu A1 hoặc R1C1, tính lại chúng, đọc các giá trị đã tính, kết nối các ô đó với một chuỗi biểu đồ, và lưu bản trình chiếu. Nó cũng mô tả cú pháp công thức được hỗ trợ, tập hợp các hàm tích hợp, giá trị đã lưu, công thức không được hỗ trợ và các lỗi đặc thù của bảng tính.

## **Bảng tính biểu đồ và công thức**

Bảng tính biểu đồ chứa các danh mục, tên chuỗi và giá trị được biểu đồ sử dụng. Trong PowerPoint, bạn có thể kiểm tra bảng tính bằng cách mở trình chỉnh sửa dữ liệu biểu đồ:

![Biểu đồ PowerPoint với bảng tính nhúng mở, hiển thị dữ liệu danh mục và chuỗi](chart-worksheet-formulas_1.png)

Trong Aspose.Slides, bảng tính được tiếp cận thông qua lớp [ChartDataWorkbook](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdataworkbook/). Sử dụng [ChartDataCell.setFormula](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdatacell/#setFormula) cho công thức kiểu A1 và [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdatacell/#setR1C1Formula) cho công thức kiểu R1C1. Sau khi thay đổi các ô đầu vào hoặc công thức, gọi [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) để tính lại các công thức được hỗ trợ và cập nhật giá trị ô tương ứng.

Một ô đã tính vẫn cung cấp kết quả của nó thông qua [ChartDataCell.getValue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdatacell/#getValue). Điều này quan trọng khi bạn cần kiểm tra kết quả công thức trong mã hoặc sử dụng ô đó như một điểm dữ liệu cho biểu đồ.

## **Tạo biểu đồ và tính công thức bảng tính**

Ví dụ sau minh họa quy trình từ đầu đến cuối. Nó tạo một biểu đồ cột cụm, xóa dữ liệu mẫu, ghi giá trị doanh thu và chi phí hàng quý, tính lợi nhuận bằng công thức, đọc kết quả, sử dụng các ô đã tính làm giá trị biểu đồ, và lưu bản trình chiếu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350)
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    workbook.clear(worksheet_index)

    category1 = workbook.getCell(worksheet_index, "A2", "Q1")
    category2 = workbook.getCell(worksheet_index, "A3", "Q2")
    category3 = workbook.getCell(worksheet_index, "A4", "Q3")

    workbook.getCell(worksheet_index, "B1", "Revenue")
    workbook.getCell(worksheet_index, "C1", "Expenses")
    workbook.getCell(worksheet_index, "D1", "Profit")

    workbook.getCell(worksheet_index, "B2").setValue(120.0)
    workbook.getCell(worksheet_index, "C2").setValue(80.0)
    workbook.getCell(worksheet_index, "B3").setValue(150.0)
    workbook.getCell(worksheet_index, "C3").setValue(95.0)
    workbook.getCell(worksheet_index, "B4").setValue(135.0)
    workbook.getCell(worksheet_index, "C4").setValue(110.0)

    profit1 = workbook.getCell(worksheet_index, "D2")
    profit2 = workbook.getCell(worksheet_index, "D3")
    profit3 = workbook.getCell(worksheet_index, "D4")

    profit1.setFormula("B2-C2")
    profit2.setFormula("B3-C3")
    profit3.setFormula("B4-C4")

    workbook.calculateFormulas()

    q1_profit = float(profit1.getValue()) # 40
    q2_profit = float(profit2.getValue()) # 55
    q3_profit = float(profit3.getValue()) # 25

    print("Q1 profit: ", q1_profit)
    print("Q2 profit: ", q2_profit)
    print("Q3 profit: ", q3_profit)

    chart.getChartData().getCategories().add(category1)
    chart.getChartData().getCategories().add(category2)
    chart.getChartData().getCategories().add(category3)

    profit_series = chart.getChartData().getSeries().add(workbook.getCell(worksheet_index, "D1"), chart.getType())
    profit_series.getDataPoints().addDataPointForBarSeries(profit1)
    profit_series.getDataPoints().addDataPointForBarSeries(profit2)
    profit_series.getDataPoints().addDataPointForBarSeries(profit3)
    profit_series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Các điểm dữ liệu của biểu đồ tham chiếu `D2:D4`, vì vậy biểu đồ sử dụng các giá trị lợi nhuận đã tính. Không có cuộc gọi làm mới biểu đồ riêng trong quy trình này: tính lại workbook trước, sau đó sử dụng hoặc lưu dữ liệu biểu đồ trỏ tới các ô đã tính.

## **Sử dụng công thức kiểu A1**

Cú pháp A1 xác định cột bằng chữ và hàng bằng số. Gán các biểu thức kiểu A1 thông qua [ChartDataCell.setFormula](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdatacell/#setFormula).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "C3").setValue(10)
    workbook.getCell(0, "F2").setValue(2)
    workbook.getCell(0, "G2").setValue(3)
    workbook.getCell(0, "H2").setValue(4)

    cell = workbook.getCell(0, "A2")
    cell.setFormula("C3+SUM(F2:H2)")

    workbook.calculateFormulas()

    value = cell.getValue() # 19
finally:
    presentation.dispose()
```

Các dạng tham chiếu A1 phổ biến là:

| Tham chiếu | Tương đối | Tuyệt đối | Kết hợp |
|---|---|---|---|
| Ô | `A2` | `$A$2` | `A$2`, `$A2` |
| Hàng | `2:2` | `$2:$2` | — |
| Cột | `A:A` | `$A:$A` | — |
| Phạm vi | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Tham chiếu tương đối có thể thay đổi khi công thức được di chuyển hoặc sao chép bởi ứng dụng bảng tính. Tham chiếu tuyệt đối giữ cả hai tọa độ cố định, trong khi tham chiếu kết hợp chỉ cố định một hàng hoặc một cột.

## **Sử dụng công thức kiểu R1C1**

Cú pháp R1C1 xác định cả hàng và cột bằng số. Tham chiếu tương đối sử dụng độ lệch trong dấu ngoặc vuông. Gán cú pháp này thông qua [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdatacell/#setR1C1Formula).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "B2").setValue(12)
    workbook.getCell(0, "C2").setValue(5)

    cell = workbook.getCell(0, "D2")
    cell.setR1C1Formula("RC[-2]-RC[-1]")

    workbook.calculateFormulas()

    value = cell.getValue() # 7
finally:
    presentation.dispose()
```

Các dạng tham chiếu R1C1 phổ biến là:

| Tham chiếu | Tương đối | Tuyệt đối | Kết hợp |
|---|---|---|---|
| Ô | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Hàng | `R[2]` | `R2` | — |
| Cột | `C[3]` | `C3` | — |
| Phạm vi | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Ví dụ, trong ô `D2`, `RC[-2]` có nghĩa là ô cùng hàng, hai cột sang trái (`B2`).

## **Hằng số và toán tử công thức**

Bộ đánh giá công thức tích hợp hỗ trợ giá trị logic, hằng số số, chuỗi, giá trị lỗi bảng tính, toán tử số học và toán tử so sánh.

### **Hằng số và Literal**

| Kiểu | Ví dụ | Ghi chú |
|---|---|---|
| Logic | `TRUE`, `FALSE` | Có thể được sử dụng trực tiếp trong biểu thức logic như `A2=TRUE`. |
| Số | `1`, `0.5`, `.3`, `1E-2` | Thông thường và ký hiệu khoa học được hỗ trợ. |
| Chuỗi | `"abc"`, `"2/3/2020 12:00"` | Các literal văn bản được đặt trong dấu ngoặc kép trong công thức. |
| Kết quả lỗi | `#DIV/0!`, `#N/A`, `#REF!` | Một công thức hợp lệ có thể đánh giá thành giá trị lỗi bảng tính thay vì kết quả bình thường. |

Ví dụ này sử dụng một số loại hằng số:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "A2").setValue(False)
    workbook.getCell(0, "B2").setFormula("A2=TRUE")
    workbook.getCell(0, "C2").setFormula("1+0.5")
    workbook.getCell(0, "D2").setFormula(".3*1E-2")
    workbook.getCell(0, "E2").setFormula("\"abc\"")
    workbook.getCell(0, "F2").setFormula("2/0")

    workbook.calculateFormulas()

    logical_value = workbook.getCell(0, "B2").getValue() # False
    numeric_value = workbook.getCell(0, "C2").getValue() # 1.5
    scientific_value = workbook.getCell(0, "D2").getValue() # 0.003
    string_value = workbook.getCell(0, "E2").getValue() # abc
    error_value = workbook.getCell(0, "F2").getValue() # #DIV/0!
finally:
    presentation.dispose()
```

### **Toán tử số học**

| Toán tử | Ý nghĩa | Ví dụ |
|---|---|---|
| `+` | Cộng hoặc dấu cộng một ngôi | `2+3` |
| `-` | Trừ hoặc dấu trừ một ngôi | `2-3`, `-3` |
| `*` | Nhân | `2*3` |
| `/` | Chia | `2/3` |
| `%` | Phần trăm | `30%` |
| `^` | Lũy thừa | `2^3` |

Sử dụng dấu ngoặc để làm rõ thứ tự tính, ví dụ `(A2+B2)*C2`.

### **Toán tử so sánh**

So sánh biểu thức trả về giá trị logic.

| Toán tử | Ý nghĩa | Ví dụ |
|---|---|---|
| `=` | Bằng | `A2=3` |
| `<>` | Không bằng | `A2<>3` |
| `>` | Lớn hơn | `A2>3` |
| `>=` | Lớn hơn hoặc bằng | `A2>=3` |
| `<` | Nhỏ hơn | `A2<3` |
| `<=` | Nhỏ hơn hoặc bằng | `A2<=3` |

## **Các hàm được hỗ trợ có sẵn**

Aspose.Slides bao gồm một bộ đánh giá công thức tích hợp cho các bảng tính biểu đồ, nhưng nó không phải là một công cụ tính toán Excel toàn diện. Bộ hàm được tài liệu ghi chú được giới hạn ở các hàm dưới đây. Đừng cho rằng một hàm Excel bất kỳ có thể được tính lại bằng [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdataworkbook/#calculateFormulas).

| Hàm | Mục đích hoặc dạng hỗ trợ | Ví dụ |
|---|---|---|
| `ABS` | Giá trị tuyệt đối | `ABS(A2)` |
| `AVERAGE` | Trung bình cộng | `AVERAGE(B2:B5)` |
| `CEILING` | Làm tròn lên tới bội số | `CEILING(A2,5)` |
| `CHOOSE` | Chọn giá trị theo chỉ số | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Nối các giá trị văn bản | `CONCAT(A2,B2)` |
| `CONCATENATE` | Nối các giá trị văn bản | `CONCATENATE(A2," ",B2)` |
| `DATE` | Tạo giá trị ngày sử dụng hệ thống ngày 1900 | `DATE(2026,8,19)` |
| `DAYS` | Trả về số ngày giữa các ngày | `DAYS(B2,A2)` |
| `FIND` | Tìm một giá trị văn bản trong một giá trị khác | `FIND("-",A2)` |
| `FINDB` | Tìm kiếm văn bản dựa trên byte | `FINDB("a",A2)` |
| `IF` | Kết quả có điều kiện | `IF(A2>0,A2,0)` |
| `INDEX` | Dạng tham chiếu | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Dạng vector | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Dạng vector | `MATCH(A2,B2:B5,0)` |
| `MAX` | Giá trị lớn nhất | `MAX(B2:B5)` |
| `SUM` | Tổng các giá trị | `SUM(B2:B5)` |
| `VLOOKUP` | Tìm kiếm dọc | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Những hạn chế trong bảng là quan trọng: `INDEX` được mô tả ở dạng tham chiếu, trong khi `LOOKUP` và `MATCH` được mô tả ở dạng vector. `DATE` sử dụng hệ thống ngày 1900. Các tính năng và hàm không được liệt kê ở đây sẽ được coi là không được hỗ trợ bởi bộ đánh giá công thức của Aspose.Slides trừ khi chúng được tài liệu mô tả riêng.

## **Tính công thức với ngôn ngữ ưu tiên**

Một số hàm workbook biểu đồ diễn giải văn bản theo quy tắc đặc thù của ngôn ngữ. Điều này đặc biệt quan trọng đối với các hàm dành cho các ngôn ngữ sử dụng bộ ký tự hai byte (DBCS). Để tính đúng các công thức như vậy, tạo [LoadOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/), thiết lập ngôn ngữ ưu tiên bằng [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/vi/python-java/aspose.slides/spreadsheetoptions/#setPreferredCulture), gán các tùy chọn bảng tính qua [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions), rồi tải bản trình chiếu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions
from java.util import Locale

japanese_culture = Locale.forLanguageTag("ja-JP")

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setPreferredCulture(japanese_culture)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                shape.getChartData().getChartDataWorkbook().calculateFormulas()
finally:
    presentation.dispose()
```

Ngôn ngữ ưu tiên là một phần của cấu hình tải bản trình chiếu, vì vậy hãy chỉ định nó trước khi tạo đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/). Sử dụng ngôn ngữ mà các công thức workbook mong đợi; ví dụ, dùng `ja-JP` cho các công thức cần tuân theo quy tắc tính DBCS của tiếng Nhật.

## **Tính lại và giá trị đã lưu**

Các tệp bảng tính thường lưu cả công thức và giá trị đã tính lần cuối. Vì vậy Aspose.Slides có thể đọc giá trị đã lưu từ [ChartDataCell.getValue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdatacell/#getValue) khi bản trình chiếu được tải và dữ liệu biểu đồ liên quan chưa bị thay đổi.

Sau khi thay đổi các ô đầu vào hoặc công thức, không nên dựa vào kết quả đã lưu cũ. Gọi [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) trước khi đọc các giá trị đã tính hoặc lưu dữ liệu biểu đồ phụ thuộc vào chúng.

Đối với các công thức nằm ngoài tập hợp được hỗ trợ, Aspose.Slides có thể không thể phân tích công thức hoặc xác định các phụ thuộc của nó. Nếu workbook đã được sửa đổi, giá trị đã lưu trước đó không còn đáng tin cậy. Trong trường hợp này, việc đọc giá trị của ô có dữ liệu không được hỗ trợ có thể gây ra [CellUnsupportedDataException](https://reference.aspose.com/slides/vi/python-java/aspose.slides/cellunsupporteddataexception/).

Nếu biểu đồ của bạn phụ thuộc vào các hàm Excel mà Aspose.Slides không đánh giá, hãy tính các công thức đó bằng một công cụ bảng tính hỗ trợ và ghi lại các giá trị thu được vào workbook biểu đồ. Đừng thay thế các công thức không được hỗ trợ bằng các giá trị ước đoán.

## **Xử lý lỗi công thức**

Có hai loại vấn đề khác nhau cần phân biệt.

Một công thức có thể hợp lệ nhưng tạo ra kết quả lỗi bảng tính như `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` hoặc `#VALUE!`. Trong trường hợp này, token lỗi là kết quả của ô và có thể được trả về qua [ChartDataCell.getValue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdatacell/#getValue).

Một công thức cũng có thể thất bại ở mức độ phân tích, tham chiếu, phụ thuộc hoặc dữ liệu không được hỗ trợ. Aspose.Slides cung cấp các ngoại lệ đặc thù của bảng tính cho những trường hợp này: [CellInvalidFormulaException](https://reference.aspose.com/slides/vi/python-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/vi/python-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/vi/python-java/aspose.slides/cellcircularreferenceexception/), và [CellUnsupportedDataException](https://reference.aspose.com/slides/vi/python-java/aspose.slides/cellunsupporteddataexception/).

Khi công thức đến từ mẫu hoặc đầu vào người dùng, hãy xử lý các ngoại lệ này quanh quá trình tính lại và truy cập giá trị:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CellCircularReferenceException, CellInvalidFormulaException, CellInvalidReferenceException, CellUnsupportedDataException, ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, "A2")
    cell.setFormula("SUM(B2:B5)")

    try:
        workbook.calculateFormulas()
        print(cell.getValue())
    except CellInvalidFormulaException as ex:
        print("Invalid formula: " + str(ex.getMessage()))
    except CellInvalidReferenceException as ex:
        print("Invalid cell reference: " + str(ex.getMessage()))
    except CellCircularReferenceException as ex:
        print("Circular reference: " + str(ex.getMessage()))
    except CellUnsupportedDataException as ex:
        print("Unsupported spreadsheet data: " + str(ex.getMessage()))
finally:
    presentation.dispose()
```

## **Hạn chế thực tế**

Sự hỗ trợ công thức trong các bảng tính biểu đồ được thiết kế cho một tập hợp giới hạn các phép tính bảng tính, không phải cho khả năng tương thích đầy đủ với Excel. Hãy lưu ý các ràng buộc này khi thiết kế quy trình báo cáo:

- Chỉ sử dụng các hằng số, toán tử, tham chiếu và hàm được tài liệu ghi chú khi bạn cần Aspose.Slides tính lại công thức.
- Tính lại sau khi thay đổi các ô mà kết quả công thức phụ thuộc.
- Xem các giá trị đã lưu từ bản trình chiếu đã tải như ảnh chụp nhanh, không phải là thay thế cho việc tính lại sau khi chỉnh sửa.
- Kiểm tra công thức từ các mẫu hiện có trước khi dựa vào giá trị đã tính của chúng, đặc biệt khi chúng sử dụng các hàm không nằm trong danh sách tài liệu.
- Đối với các công thức cần một công cụ tính toán bảng tính đầy đủ, hãy tính chúng bên ngoài rồi cập nhật workbook biểu đồ với các giá trị thu được.

## **Câu hỏi thường gặp**

**Sự khác nhau giữa [ChartDataCell.setFormula](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdatacell/#setFormula) và [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdatacell/#setR1C1Formula) là gì?**

[ChartDataCell.setFormula] lưu một biểu thức kiểu A1 như `B2-C2`. [ChartDataCell.setR1C1Formula] lưu một biểu thức kiểu R1C1 như `RC[-2]-RC[-1]`. Sử dụng cú pháp phù hợp nhất với cách bạn tạo hoặc sao chép công thức.

**Tôi có cần đọc chính ô hoặc giá trị của nó sau khi tính toán không?**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdataworkbook/#getCell) trả về một [ChartDataCell]. Để lấy kết quả đã tính, gọi phương thức [ChartDataCell.getValue](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdatacell/#getValue) của ô đó sau khi tính lại.

**Khi nào tôi nên gọi [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdataworkbook/#calculateFormulas)?**

Gọi [ChartDataWorkbook.calculateFormulas] sau khi thay đổi giá trị đầu vào hoặc công thức và trước khi bạn phụ thuộc vào các kết quả đã tính. Điều này cập nhật các giá trị của công thức mà bộ đánh giá tích hợp hỗ trợ.

**Aspose.Slides có hỗ trợ mọi hàm Excel không?**

Không. Bộ đánh giá tích hợp chỉ hỗ trợ một tập hợp các hàm được tài liệu ghi chú. Các hàm nằm ngoài tập hợp đó không nên được cho là sẽ được tính lại đúng. Nếu cần khả năng tương thích công thức Excel đầy đủ, hãy thực hiện tính toán bằng một công cụ bảng tính thích hợp và ghi các giá trị cuối cùng vào workbook biểu đồ.

**Điều gì xảy ra nếu một bản trình chiếu đã tải chứa công thức không được hỗ trợ?**

Nếu dữ liệu biểu đồ chưa thay đổi, workbook vẫn có thể chứa giá trị đã lưu tính toán trước đó. Sau khi dữ liệu liên quan được sửa đổi, giá trị đã lưu đó có thể không còn hợp lệ. Truy cập ô có công thức không thể xử lý có thể gây ra [CellUnsupportedDataException](https://reference.aspose.com/slides/vi/python-java/aspose.slides/cellunsupporteddataexception/).

**Giá trị lỗi công thức có giống như ngoại lệ không?**

Không. Kết quả như `#DIV/0!` là một giá trị bảng tính được tạo ra bởi một phép tính hợp lệ. Các ngoại lệ như [CellInvalidFormulaException](https://reference.aspose.com/slides/vi/python-java/aspose.slides/cellinvalidformulaexception/) hoặc [CellCircularReferenceException](https://reference.aspose.com/slides/vi/python-java/aspose.slides/cellcircularreferenceexception/) cho biết công thức không thể được xử lý bình thường.

**Biểu đồ có tự động cập nhật khi ô công thức thay đổi không?**

Một chuỗi biểu đồ có thể tham chiếu các ô workbook. Tính lại workbook trước, sau đó lưu hoặc render bản trình chiếu. Nếu các điểm dữ liệu biểu đồ tham chiếu các ô đã tính, biểu đồ sẽ sử dụng các giá trị ô đã cập nhật; không cần phương thức làm mới biểu đồ riêng cho quy trình này.

**Biểu đồ có thể sử dụng workbook Excel bên ngoài không?**

Đúng, dữ liệu biểu đồ có thể được cấu hình để sử dụng một workbook bên ngoài thông qua API dữ liệu biểu đồ. Tuy nhiên, quy trình tính công thức được mô tả trong bài viết này liên quan tới workbook dữ liệu biểu đồ và tập hợp công thức mà Aspose.Slides đánh giá. Đừng cho rằng [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) cung cấp khả năng tính lại đầy đủ các công thức bất kỳ trong một tệp XLSX bên ngoài.

**Tôi có thể sử dụng công thức tham chiếu tới một bảng tính hoặc workbook khác không?**

Tham chiếu kiểu Excel có thể tồn tại trong workbook biểu đồ, nhưng việc đánh giá công thức bị giới hạn bởi bộ phân tích và tập hợp hàm hỗ trợ. Nếu một tham chiếu giữa các sheet hoặc bên ngoài là cần thiết, hãy xác thực công thức chính xác đó với phiên bản Aspose.Slides mục tiêu. Đối với quy trình cần khả năng tương thích tham chiếu Excel rộng, hãy tính workbook bên ngoài và ghi lại các giá trị đã giải quyết vào dữ liệu biểu đồ.

**Chuỗi công thức có nên bắt đầu bằng `=` không?**

Các ví dụ API của Aspose.Slides gán các biểu thức như `B2-C2` hoặc `SUM(B2:B5)` mà không có dấu `=` ở đầu. Sử dụng dạng này giúp các công thức được tạo nhất quán với các ví dụ trong tài liệu API.