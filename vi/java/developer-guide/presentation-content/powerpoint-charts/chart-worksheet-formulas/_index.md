---
title: Áp dụng công thức worksheet biểu đồ trong bản trình bày bằng Java
linktitle: Công thức Worksheet
type: docs
weight: 70
url: /vi/java/chart-worksheet-formulas/
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
- hàm định nghĩa trước
- PowerPoint
- bản trình bày
- Java
- Aspose.Slides
description: Áp dụng công thức kiểu Excel trong Aspose.Slides cho worksheet biểu đồ Java và tự động hoá báo cáo trên các tệp PPT và PPTX
---
## **Tổng quan**

Worksheet biểu đồ là nguồn dữ liệu phía sau một biểu đồ trong bản trình bày. Nó lưu trữ tên danh mục và chuỗi cùng với các giá trị số hiển thị trên biểu đồ. Trong Aspose.Slides, worksheet này có sẵn qua chart data workbook, cho phép bạn làm việc với dữ liệu biểu đồ bằng cách lập trình.

Bài viết này giải thích cách sử dụng công thức worksheet trong dữ liệu biểu đồ để các giá trị ô có thể được tính và cập nhật tự động thay vì nhập thủ công. Nó cho thấy cách gán công thức, sử dụng tham chiếu kiểu A1 và R1C1, tính lại công thức workbook, và làm việc với các hằng số, toán tử, tham chiếu ô và hàm định nghĩa trước được hỗ trợ cho worksheet biểu đồ trong bản trình bày.

## **Về công thức bảng tính biểu đồ trong bản trình bày**
**Bảng tính biểu đồ** (hoặc worksheet biểu đồ) trong bản trình bày là nguồn dữ liệu của biểu đồ. Bảng tính biểu đồ chứa dữ liệu, được biểu diễn trên biểu đồ dưới dạng đồ họa. Khi bạn tạo một biểu đồ trong PowerPoint, worksheet liên kết với biểu đồ này cũng được tạo tự động. Worksheet biểu đồ được tạo cho mọi loại biểu đồ: biểu đồ đường, biểu đồ cột, biểu đồ sunburst, biểu đồ tròn, v.v. Để xem bảng tính biểu đồ trong PowerPoint, bạn chỉ cần double‑click vào biểu đồ:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Bảng tính biểu đồ chứa tên các yếu tố biểu đồ (Category Name: *Category1*, Serie Name) và một bảng dữ liệu số phù hợp với các danh mục và chuỗi này. Mặc định, khi bạn tạo một biểu đồ mới – dữ liệu bảng tính biểu đồ được đặt với dữ liệu mặc định. Sau đó bạn có thể thay đổi dữ liệu bảng tính trong worksheet một cách thủ công.

Thông thường, biểu đồ thể hiện dữ liệu phức tạp (ví dụ: nhà phân tích tài chính, nhà phân tích khoa học), có các ô được tính từ giá trị của các ô khác hoặc từ dữ liệu động khác. Tính giá trị ô bằng tay và hard‑code vào ô khiến việc thay đổi trong tương lai trở nên khó khăn. Nếu bạn thay đổi giá trị của một ô nào đó, tất cả các ô phụ thuộc vào nó cũng sẽ cần được cập nhật. Hơn nữa, dữ liệu bảng có thể phụ thuộc vào dữ liệu từ các bảng khác, tạo ra một sơ đồ dữ liệu bản trình bày phức tạp với nhu cầu cập nhật dễ dàng và linh hoạt.

**Công thức bảng tính biểu đồ** trong bản trình bày là một biểu thức để tự động tính và cập nhật dữ liệu bảng tính biểu đồ. Công thức bảng tính định nghĩa logic tính dữ liệu cho một ô hoặc một tập hợp các ô. Công thức bảng tính là công thức toán học hoặc công thức logic, sử dụng: tham chiếu ô, hàm toán học, toán tử logic, toán tử số học, hàm chuyển đổi, hằng số chuỗi, v.v. Định nghĩa công thức được viết vào một ô, và ô này không chứa giá trị đơn giản. Công thức bảng tính tính giá trị và trả về, sau đó giá trị này được gán cho ô. Công thức bảng tính trong bản trình bày thực chất giống như công thức Excel, và hỗ trợ cùng các hàm mặc định, toán tử và hằng số để triển khai.

Trong [**Aspose.Slides**](https://products.aspose.com/slides/vi/java/) bảng tính biểu đồ được biểu diễn bằng 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartData#getChartDataWorkbook--) method của
[**IChartDataWorkbook**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartDataWorkbook) type. 
Công thức bảng tính có thể được gán và thay đổi bằng 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) method. 
Các chức năng sau được hỗ trợ cho công thức trong Aspose.Slides:

- Hằng số logic
- Hằng số số
- Hằng số chuỗi
- Hằng số lỗi
- Toán tử số học
- Toán tử so sánh
- Tham chiếu ô kiểu A1
- Tham chiếu ô kiểu R1C1
- Hàm định nghĩa trước


Thông thường, bảng tính lưu trữ các giá trị công thức đã tính cuối cùng. Nếu sau khi tải bản trình bày, dữ liệu biểu đồ không bị thay đổi – [**IChartDataCell.getValue**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartDataCell#getValue--) method sẽ trả về các giá trị đó khi đọc. Nhưng, nếu dữ liệu bảng tính đã bị thay đổi, khi đọc thuộc tính **ChartDataCell.Value** nó sẽ ném ra [**CellUnsupportedDataException**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/CellUnsupportedDataException) cho các công thức không được hỗ trợ. Điều này xảy ra vì khi công thức được phân tích thành công, các phụ thuộc ô được xác định và tính đúng đắn của các giá trị cuối cùng được xác nhận. Ngược lại, nếu công thức không thể phân tích, tính đúng đắn của giá trị ô không thể được đảm bảo.

## **Thêm công thức bảng tính biểu đồ vào bản trình bày**
Đầu tiên, thêm một biểu đồ vào slide đầu tiên của bản trình bày mới bằng 
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-). 
Worksheet của biểu đồ sẽ được tạo tự động và có thể truy cập bằng 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartData#getChartDataWorkbook--) method:

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

Hãy ghi một số giá trị vào các ô bằng 
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) property 
của kiểu **Object**, nghĩa là bạn có thể gán bất kỳ giá trị nào cho thuộc tính:

```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```

Bây giờ để ghi công thức vào ô, bạn có thể sử dụng 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) method:

*Note*: [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) method được dùng để đặt tham chiếu ô kiểu A1. 

Để đặt tham chiếu ô [R1C1Formula](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartDataCell#getR1C1Formula--) , bạn có thể dùng [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) method:

Sau khi đó, nếu bạn đọc giá trị từ các ô B2 và C2, chúng sẽ được tính:

```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```

## **Hằng số logic**
Bạn có thể sử dụng hằng số logic như *FALSE* và *TRUE* trong công thức ô:

```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // giá trị chứa kiểu boolean "false"
```

## **Hằng số số**
Các số có thể được sử dụng ở dạng thông thường hoặc khoa học để tạo công thức bảng tính biểu đồ:

```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **Hằng số chuỗi**
Hằng số chuỗi (hoặc literal) là một giá trị cụ thể được dùng nguyên trạng và không thay đổi. Hằng số chuỗi có thể là: ngày tháng, văn bản, số, v.v.:

```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Hằng số lỗi**
Đôi khi không thể tính kết quả bằng công thức. Khi đó, mã lỗi sẽ hiển thị trong ô thay vì giá trị thực. Mỗi loại lỗi có mã riêng:

- #DIV/0! - công thức cố gắng chia cho zero.
- #GETTING_DATA - có thể hiển thị trên ô khi giá trị vẫn đang được tính.
- #N/A - thông tin đang thiếu hoặc không khả dụng. Một số nguyên nhân có thể là: các ô được dùng trong công thức rỗng, ký tự khoảng trắng thừa, lỗi chính tả, v.v.
- #NAME? - không tìm thấy ô hoặc đối tượng công thức theo tên.
- #NULL! - có thể xuất hiện khi công thức có lỗi, như:  (,) hoặc ký tự khoảng trắng được dùng thay cho dấu hai chấm (:).
- #NUM! - số trong công thức không hợp lệ, quá dài hoặc quá ngắn, v.v.
- #REF! - tham chiếu ô không hợp lệ.
- #VALUE! - kiểu giá trị không mong đợi. Ví dụ, giá trị chuỗi được gán cho ô số.

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // giá trị chứa chuỗi "#DIV/0!"
```

## **Toán tử số học**
Bạn có thể sử dụng tất cả các toán tử số học trong công thức worksheet biểu đồ:

|**Toán tử**|**Ý nghĩa**|**Ví dụ**|
| :- | :- | :- |
|+ (dấu cộng)|Cộng hoặc dấu cộng một ngôi|2 + 3|
|- (dấu trừ)|Trừ hoặc phủ định|2 - 3<br>-3|
|* (dấu sao)|Nhân|2 * 3|
|/ (dấu gạch chéo)|Chia|2 / 3|
|% (dấu phần trăm)|Phần trăm|30%|
|^ (dấu mũ)|Lũy thừa|2 ^ 3|

*Note*: Để thay đổi thứ tự tính toán, đặt phần công thức cần tính trước trong dấu ngoặc.

## **Toán tử so sánh**
Bạn có thể so sánh giá trị các ô bằng các toán tử so sánh. Khi hai giá trị được so sánh bằng các toán tử này, kết quả là một giá trị logic *TRUE* hoặc FALSE:

|**Toán tử**|**Ý nghĩa**|**Ví dụ**|
| :- | :- | :- |
|= (dấu bằng)|Bằng|A2 = 3|
|<> (dấu không bằng)|Không bằng|A2 <> 3|
|> (dấu lớn hơn)|Lớn hơn|A2 > 3|
|>= (dấu lớn hơn hoặc bằng)|Lớn hơn hoặc bằng|A2 >= 3|
|< (dấu nhỏ hơn)|Nhỏ hơn|A2 < 3|
|<= (dấu nhỏ hơn hoặc bằng)|Nhỏ hơn hoặc bằng|A2 <= 3|

## **Tham chiếu ô kiểu A1**
**Tham chiếu ô kiểu A1** được dùng cho worksheets, trong đó cột có định danh bằng chữ (ví dụ "*A*") và hàng có định danh bằng số (ví dụ "*1*"). Tham chiếu ô kiểu A1 có thể được sử dụng như sau:

|**Tham chiếu ô**|**Ví dụ**|||
| :- | :- | :- | :- |
||Tuyệt đối|Tương đối|Kết hợp|
|Ô|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Hàng|$2:$2|2:2|-|
|Cột|$A:$A|A:A|-|
|Phạm vi|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Ví dụ sử dụng tham chiếu ô kiểu A1 trong công thức:

```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **Tham chiếu ô kiểu R1C1**
**Tham chiếu ô kiểu R1C1** được dùng cho worksheets, trong đó cả hàng và cột đều có định danh số. Tham chiếu ô kiểu R1C1 có thể được sử dụng như sau:

|**Tham chiếu ô**|**Ví dụ**|||
| :- | :- | :- | :- |
||Tuyệt đối|Tương đối|Kết hợp|
|Ô|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Hàng|R2|R[2]|-|
|Cột|C3|C[3]|-|
|Phạm vi|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Ví dụ sử dụng tham chiếu ô kiểu A1 trong công thức:

```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Hàm định nghĩa trước**
Có một số hàm định nghĩa trước, có thể được dùng trong công thức để đơn giản hóa việc triển khai. Các hàm này bao hàm các thao tác thường dùng nhất, như:

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

## **Câu hỏi thường gặp**

**Các tệp Excel bên ngoài có được hỗ trợ làm nguồn dữ liệu cho biểu đồ có công thức không?**

Có. Aspose.Slides hỗ trợ workbook bên ngoài làm [nguồn dữ liệu của biểu đồ](https://reference.aspose.com/slides/vi/java/com.aspose.slides/chartdatasourcetype/), cho phép bạn sử dụng công thức từ một tệp XLSX ngoài bản trình bày.

**Công thức biểu đồ có thể tham chiếu các sheet trong cùng một workbook bằng tên sheet không?**

Có. Công thức tuân theo mô hình tham chiếu chuẩn của Excel, vì vậy bạn có thể tham chiếu các sheet khác trong cùng một workbook hoặc một workbook bên ngoài. Đối với tham chiếu bên ngoài, bao gồm đường dẫn và tên workbook theo cú pháp Excel.