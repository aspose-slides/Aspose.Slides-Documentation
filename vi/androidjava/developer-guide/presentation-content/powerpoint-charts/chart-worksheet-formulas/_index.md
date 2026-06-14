---
title: Áp dụng công thức worksheet biểu đồ trong bản trình chiếu trên Android
linktitle: Công thức Worksheet
type: docs
weight: 70
url: /vi/androidjava/chart-worksheet-formulas/
keywords:
- bảng tính biểu đồ
- worksheet biểu đồ
- công thức biểu đồ
- công thức worksheet
- công thức bảng tính
- nguồn dữ liệu
- hằng số logic
- hằng số số
- hằng số chuỗi
- hằng số lỗi
- hằng số số học
- toán tử so sánh
- kiểu A1
- kiểu R1C1
- hàm định nghĩa sẵn
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Áp dụng công thức kiểu Excel trong Aspose.Slides cho Android qua các worksheet biểu đồ Java và tự động hoá báo cáo trên các tệp PPT và PPTX."
---
## **Tổng quan**

Một chart worksheet là nguồn dữ liệu phía sau một biểu đồ trong bản trình chiếu. Nó lưu trữ tên danh mục và tên chuỗi cùng với các giá trị số được biểu đồ hiển thị. Trong Aspose.Slides, worksheet này được truy cập thông qua chart data workbook, cho phép bạn làm việc với dữ liệu biểu đồ một cách chương trình.

Bài viết này giải thích cách sử dụng công thức trong worksheet để các giá trị ô có thể được tính toán và cập nhật tự động thay vì nhập thủ công. Nó chỉ ra cách gán công thức, sử dụng tham chiếu kiểu A1 và R1C1, tính lại công thức workbook, và làm việc với các hằng số, toán tử, tham chiếu ô và hàm được hỗ trợ cho chart worksheet trong bản trình chiếu.

## **Về công thức bảng tính biểu đồ trong bản trình chiếu**
**Chart spreadsheet** (hoặc chart worksheet) trong bản trình chiếu là nguồn dữ liệu của biểu đồ. Chart spreadsheet chứa dữ liệu, được biểu diễn trên biểu đồ dưới dạng đồ họa. Khi bạn tạo một biểu đồ trong PowerPoint, worksheet liên kết với biểu đồ này cũng được tạo tự động. Chart worksheet được tạo cho mọi loại biểu đồ: line chart, bar chart, sunburst chart, pie chart, v.v. Để xem chart spreadsheet trong PowerPoint, bạn nhấp đúp vào biểu đồ:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Chart spreadsheet chứa tên các thành phần biểu đồ (Category Name: *Category1*, Serie Name) và một bảng dữ liệu số phù hợp với các danh mục và chuỗi này. Theo mặc định, khi bạn tạo một biểu đồ mới – dữ liệu chart spreadsheet được đặt với dữ liệu mặc định. Sau đó bạn có thể thay đổi dữ liệu spreadsheet trong worksheet một cách thủ công.

Thông thường, biểu đồ thể hiện dữ liệu phức tạp (ví dụ: nhà phân tích tài chính, nhà phân tích khoa học), có các ô được tính từ giá trị của các ô khác hoặc từ dữ liệu động khác. Tính giá trị ô bằng tay và ghi cứng vào ô khiến việc thay đổi trong tương lai trở nên khó khăn. Nếu bạn thay đổi giá trị của một ô nào đó, tất cả các ô phụ thuộc vào nó cũng sẽ cần được cập nhật. Hơn nữa, dữ liệu bảng có thể phụ thuộc vào dữ liệu từ các bảng khác, tạo ra một sơ đồ dữ liệu bản trình chiếu phức tạp cần được cập nhật một cách dễ dàng và linh hoạt.

**Công thức chart spreadsheet** trong bản trình chiếu là biểu thức để tự động tính toán và cập nhật dữ liệu chart spreadsheet. Công thức spreadsheet xác định logic tính toán dữ liệu cho một ô hoặc một tập hợp ô. Công thức spreadsheet là công thức toán học hoặc logic, sử dụng: tham chiếu ô, hàm toán học, toán tử logic, toán tử số học, hàm chuyển đổi, hằng số chuỗi, v.v. Định nghĩa công thức được ghi vào một ô, ô này không chứa giá trị đơn giản. Công thức spreadsheet tính giá trị và trả về, sau đó giá trị này được gán cho ô. Công thức chart spreadsheet trong bản trình chiếu thực chất giống với công thức Excel, và hỗ trợ cùng các hàm, toán tử và hằng số mặc định.

Trong [**Aspose.Slides**](https://products.aspose.com/slides/vi/androidjava/) chart spreadsheet được biểu diễn bằng phương thức [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) của kiểu [**IChartDataWorkbook**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartDataWorkbook). Công thức spreadsheet có thể được gán và thay đổi bằng [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) . Các chức năng sau được hỗ trợ cho công thức trong Aspose.Slides:

- Logical constants
- Numerical constants
- String constants
- Error constants
- Arithmetic operators
- Comparison operators
- A1-style cell references
- R1C1-style cell references
- Predefined functions


Thông thường, các spreadsheet lưu trữ giá trị công thức đã tính cuối cùng. Nếu sau khi tải bản trình chiếu, dữ liệu biểu đồ không thay đổi – [**IChartDataCell.getValue**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartDataCell#getValue--) trả về các giá trị đó khi đọc. Nhưng, nếu dữ liệu spreadsheet đã được thay đổi, khi đọc thuộc tính **ChartDataCell.Value** nó sẽ ném ra [**CellUnsupportedDataException**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/CellUnsupportedDataException) vì các công thức không được hỗ trợ. Điều này xảy ra vì khi công thức được phân tích thành công, các phụ thuộc ô được xác định và tính đúng đắn của các giá trị cuối cùng được kiểm tra. Ngược lại, nếu công thức không thể phân tích, tính đúng đắn của giá trị ô không thể được đảm bảo.

## **Thêm công thức chart spreadsheet vào bản trình chiếu**
Đầu tiên, thêm một biểu đồ vào slide đầu tiên của bản trình chiếu mới bằng 
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-). 
Worksheet của biểu đồ được tạo tự động và có thể truy cập bằng [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) :

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

Hãy ghi một số giá trị vào các ô bằng [**IChartDataCell.setValue**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) thuộc tính của kiểu **Object**, nghĩa là bạn có thể đặt bất kỳ giá trị nào cho thuộc tính:

```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```

Bây giờ để ghi công thức vào ô, bạn có thể sử dụng phương thức 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-):

*Note*: [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) được dùng để đặt tham chiếu ô kiểu A1. 

Để đặt tham chiếu ô [R1C1Formula](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartDataCell#getR1C1Formula--) , bạn có thể dùng phương thức [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-):

Sau đó nếu bạn đọc giá trị từ các ô B2 và C2, chúng sẽ được tính:

```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```

## **Logical Constants**
Bạn có thể dùng các hằng số logic như *FALSE* và *TRUE* trong công thức ô:

```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // giá trị chứa boolean "false"
```

## **Numerical Constants**
Số có thể được dùng ở dạng thông thường hoặc dạng khoa học để tạo công thức chart spreadsheet:

```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **String Constants**
Hằng số chuỗi (hoặc literal) là giá trị cụ thể được sử dụng nguyên trạng và không thay đổi. Hằng số chuỗi có thể là: ngày tháng, văn bản, số, v.v.:

```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Error Constants**
Đôi khi không thể tính kết quả bằng công thức. Trong trường hợp đó, mã lỗi sẽ hiển thị trong ô thay vì giá trị. Mỗi loại lỗi có mã riêng:

- #DIV/0! - công thức cố gắng chia cho zero.
- #GETTING_DATA - có thể hiển thị trên ô khi giá trị vẫn đang được tính.
- #N/A - thông tin thiếu hoặc không khả dụng. Một số nguyên nhân: các ô dùng trong công thức rỗng, có ký tự khoảng trắng thừa, lỗi chính tả, v.v.
- #NAME? - không tìm thấy một ô hoặc đối tượng công thức nào đó theo tên.
- #NULL! - có thể xuất hiện khi công thức có lỗi, như:  (,) hoặc ký tự khoảng trắng dùng thay cho dấu hai chấm (:).
- #NUM! - số trong công thức không hợp lệ, quá dài hoặc quá ngắn, v.v.
- #REF! - tham chiếu ô không hợp lệ.
- #VALUE! - kiểu giá trị không mong đợi. Ví dụ, giá trị chuỗi được đặt vào ô số.

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // giá trị chứa chuỗi "#DIV/0!"
```

## **Arithmetic Operators**
Bạn có thể dùng tất cả các toán tử số học trong công thức worksheet:

|**Toán tử**|**Ý nghĩa**|**Ví dụ**|
| :- | :- | :- |
|+ (dấu cộng)|Cộng hoặc dấu cộng một phần tử|2 + 3|
|- (dấu trừ)|Trừ hoặc phủ định|2 - 3<br>-3|
|* (dấu sao)|Nhân|2 * 3|
|/ (dấu gạch chéo)|Chia|2 / 3|
|% (dấu phần trăm)|Phần trăm|30%|
|^ (dấu mũ)|Lũy thừa|2 ^ 3|

*Note*: Để thay đổi thứ tự tính toán, đặt phần cần tính trước vào ngoặc.

## **Comparison Operators**
Bạn có thể so sánh giá trị các ô bằng các toán tử so sánh. Khi hai giá trị được so sánh bằng các toán tử này, kết quả là giá trị logic *TRUE* hoặc FALSE:

|**Toán tử**|**Ý nghĩa**|**Ví dụ**|
| :- | :- | :- |
|= (dấu bằng)|Bằng|A2 = 3|
|<> (dấu không bằng)|Không bằng|A2 <> 3|
|> (dấu lớn hơn)|Lớn hơn|A2 > 3|
|>= (dấu lớn hơn hoặc bằng)|Lớn hơn hoặc bằng|A2 >= 3|
|< (dấu nhỏ hơn)|Nhỏ hơn|A2 < 3|
|<= (dấu nhỏ hơn hoặc bằng)|Nhỏ hơn hoặc bằng|A2 <= 3|

## **A1-style Cell References**
**A1-style cell references** được dùng cho các worksheet, trong đó cột có ký tự định danh (ví dụ "*A*") và hàng có số định danh (ví dụ "*1*"). Tham chiếu ô kiểu A1 có thể được sử dụng như sau:

|**Tham chiếu ô**|**Ví dụ**| | |
| :- | :- | :- | :- |
| |Tuyệt đối|Tương đối|Hỗn hợp|
|Ô|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Hàng|$2:$2|2:2|-|
|Cột|$A:$A|A:A|-|
|Phạm vi|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Ví dụ sử dụng tham chiếu ô kiểu A1 trong công thức:

```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **R1C1-style Cell References**
**R1C1-style cell references** được dùng cho các worksheet, trong đó cả hàng và cột đều có định danh số. Tham chiếu ô kiểu R1C1 có thể được sử dụng như sau:

|**Tham chiếu ô**|**Ví dụ**| | |
| :- | :- | :- | :- |
| |Tuyệt đối|Tương đối|Hỗn hợp|
|Ô|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Hàng|R2|R[2]|-|
|Cột|C3|C[3]|-|
|Phạm vi|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Ví dụ sử dụng tham chiếu ô kiểu R1C1 trong công thức:

```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Predefined Functions**
Có các hàm được định nghĩa sẵn, có thể dùng trong công thức để đơn giản hoá việc triển khai. Những hàm này bao gồm các thao tác thường dùng nhất, như:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (hệ thống ngày 1900)
- DAYS
- FIND
- FINDB
- IF
- INDEX (dạng tham chiếu)
- LOOKUP (dạng vector)
- MATCH (dạng vector)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**Liệu các tệp Excel bên ngoài có được hỗ trợ làm nguồn dữ liệu cho biểu đồ có công thức không?**

Có. Aspose.Slides hỗ trợ workbooks bên ngoài như một [chart's data source](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/chartdatasourcetype/), cho phép bạn sử dụng công thức từ file XLSX nằm ngoài bản trình chiếu.

**Công thức biểu đồ có thể tham chiếu các sheet trong cùng một workbook bằng tên sheet không?**

Có. Công thức tuân theo mô hình tham chiếu chuẩn của Excel, vì vậy bạn có thể tham chiếu các sheet khác trong cùng workbook hoặc workbook bên ngoài. Đối với tham chiếu bên ngoài, bao gồm đường dẫn và tên workbook theo cú pháp Excel.