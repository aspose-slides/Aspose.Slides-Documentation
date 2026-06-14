---
title: Áp dụng công thức worksheet biểu đồ trong bản trình chiếu bằng JavaScript
linktitle: Công thức Worksheet
type: docs
weight: 70
url: /vi/nodejs-java/chart-worksheet-formulas/
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
- hàm định sẵn
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Áp dụng công thức kiểu Excel trong Aspose.Slides cho Node.js thông qua worksheet biểu đồ Java và tự động hoá báo cáo trên các tệp PPT và PPTX bằng JavaScript."
---
## **Tổng quan**

Một trang tính biểu đồ là nguồn dữ liệu phía sau một biểu đồ trong bản trình chiếu. Nó lưu trữ tên danh mục và tên chuỗi cùng với các giá trị số hiển thị trên biểu đồ. Trong Aspose.Slides, trang tính này có sẵn thông qua chart data workbook, cho phép bạn làm việc với dữ liệu biểu đồ bằng cách lập trình.

Bài viết này giải thích cách sử dụng công thức trang tính trong dữ liệu biểu đồ để các giá trị ô có thể được tính toán và cập nhật tự động thay vì nhập tay. Nó cho thấy cách gán công thức, sử dụng tham chiếu kiểu A1 và R1C1, tính lại các công thức trong workbook, và làm việc với các hằng số, toán tử, tham chiếu ô và các hàm định sẵn được hỗ trợ cho trang tính biểu đồ trong bản trình chiếu.

## **Về công thức trang tính biểu đồ trong bản trình chiếu**
**Trang tính biểu đồ** (hoặc worksheet biểu đồ) trong bản trình chiếu là nguồn dữ liệu của biểu đồ. Trang tính biểu đồ chứa dữ liệu, được biểu diễn trên biểu đồ dưới dạng đồ họa. Khi bạn tạo một biểu đồ trong PowerPoint, trang tính liên kết với biểu đồ này cũng được tạo tự động. Trang tính biểu đồ được tạo cho mọi loại biểu đồ: biểu đồ đường, biểu đồ cột, biểu đồ sunburst, biểu đồ tròn, v.v. Để xem trang tính biểu đồ trong PowerPoint, bạn chỉ cần nhấp đúp vào biểu đồ:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Trang tính biểu đồ chứa tên các thành phần biểu đồ (Tên danh mục: *Category1*, Tên chuỗi) và một bảng dữ liệu số tương ứng với các danh mục và chuỗi này. Mặc định, khi bạn tạo một biểu đồ mới – dữ liệu trang tính biểu đồ được đặt với dữ liệu mặc định. Sau đó bạn có thể thay đổi dữ liệu trang tính trong worksheet một cách thủ công.

Thông thường, biểu đồ đại diện cho dữ liệu phức tạp (ví dụ: phân tích tài chính, phân tích khoa học), có các ô được tính từ giá trị của các ô khác hoặc từ dữ liệu động khác. Việc tính giá trị ô bằng tay và gõ cố định vào ô khiến việc thay đổi sau này trở nên khó khăn. Nếu bạn thay đổi giá trị của một ô nào đó, tất cả các ô phụ thuộc vào nó cũng cần được cập nhật. Hơn nữa, dữ liệu bảng có thể phụ thuộc vào dữ liệu từ các bảng khác, tạo ra một sơ đồ dữ liệu bản trình chiếu phức tạp cần được cập nhật một cách dễ dàng và linh hoạt.

**Công thức trang tính biểu đồ** trong bản trình chiếu là một biểu thức để tự động tính toán và cập nhật dữ liệu trang tính biểu đồ. Công thức trang tính xác định logic tính toán dữ liệu cho một ô hoặc một tập hợp các ô. Công thức trang tính là công thức toán học hoặc công thức logic, sử dụng: tham chiếu ô, hàm toán học, toán tử logic, toán tử số học, hàm chuyển đổi, hằng số chuỗi, v.v. Định nghĩa công thức được viết vào một ô, và ô này không chứa giá trị đơn giản. Công thức trang tính tính giá trị và trả về, sau đó giá trị này được gán cho ô. Công thức trang tính trong bản trình chiếu thực chất giống như công thức Excel, và hỗ trợ cùng các hàm, toán tử và hằng số mặc định để triển khai.

Trong [**Aspose.Slides**](https://products.aspose.com/slides/vi/nodejs-java/) trang tính biểu đồ được biểu diễn bằng phương thức
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--) của kiểu
[**ChartDataWorkbook**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartDataWorkbook).
Công thức trang tính có thể được gán và thay đổi bằng
[**ChartDataCell.setFormula**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) method.
Các chức năng sau được hỗ trợ cho công thức trong Aspose.Slides:

- Hằng số logic
- Hằng số số
- Hằng số chuỗi
- Hằng số lỗi
- Toán tử số học
- Toán tử so sánh
- Tham chiếu ô kiểu A1
- Tham chiếu ô kiểu R1C1
- Các hàm định sẵn


Thông thường, các bảng tính lưu trữ các giá trị công thức đã tính cuối cùng. Nếu sau khi tải bản trình chiếu, dữ liệu biểu đồ không bị thay đổi – phương thức [**ChartDataCell.getValue**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartDataCell#getValue--) trả về các giá trị đó khi đọc. Nhưng nếu dữ liệu bảng tính đã được thay đổi, khi đọc thuộc tính **ChartDataCell.Value** nó sẽ ném ra [**CellUnsupportedDataException**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/CellUnsupportedDataException) cho các công thức không được hỗ trợ. Điều này xảy ra vì khi công thức được phân tích thành công, các phụ thuộc ô được xác định và tính đúng đắn của các giá trị cuối cùng được xác nhận. Ngược lại, nếu công thức không thể phân tích, tính đúng đắn của giá trị ô không thể được đảm bảo.

## **Thêm công thức trang tính biểu đồ vào bản trình chiếu**
Đầu tiên, thêm một biểu đồ vào slide đầu tiên của bản trình chiếu mới với
[ShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection#addChart-int-float-float-float-float-).
Worksheet của biểu đồ được tạo tự động và có thể được truy cập bằng
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--) method:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 150, 150, 500, 300);
    var workbook = chart.getChartData().getChartDataWorkbook();
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Hãy ghi một số giá trị vào các ô bằng thuộc tính
[**ChartDataCell.setValue**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartDataCell#setValue-java.lang.Object-) của kiểu **Object**, nghĩa là bạn có thể đặt bất kỳ giá trị nào cho thuộc tính:

```javascript
workbook.getCell(0, "F2").setValue(-2.5);
workbook.getCell(0, "G3").setValue(6.3);
workbook.getCell(0, "H4").setValue(3);
```

Bây giờ để ghi công thức vào ô, bạn có thể sử dụng
[**ChartDataCell.setFormula**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) method:

*Note*: [**ChartDataCell.setFormula**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) method được dùng để đặt tham chiếu ô kiểu A1. 

Để đặt tham chiếu ô [R1C1Formula](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartDataCell#getR1C1Formula--) , bạn có thể dùng phương thức
[**ChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ChartDataCell#setR1C1Formula-java.lang.String-):

Sau khi đó, nếu bạn đọc giá trị từ các ô B2 và C2, chúng sẽ được tính toán:

```javascript
var value1 = cell1.getValue();// 7.8
var value2 = cell2.getValue();// 2.1
```

## **Hằng số logic**
Bạn có thể sử dụng các hằng số logic như *FALSE* và *TRUE* trong công thức ô:

```javascript
workbook.getCell(0, "A2").setValue(false);
var cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
var value = cell.getValue();// giá trị chứa boolean "false"
```

## **Hằng số số**
Số có thể được sử dụng ở dạng thường hoặc dạng khoa học để tạo công thức trang tính biểu đồ:

```javascript
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **Hằng số chuỗi**
Hằng số chuỗi (hoặc hằng literal) là một giá trị cụ thể được dùng nguyên trạng và không thay đổi. Hằng số chuỗi có thể là: ngày tháng, văn bản, số, v.v.:

```javascript
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Hằng số lỗi**
Đôi khi không thể tính toán kết quả bằng công thức. Trong trường hợp đó, mã lỗi sẽ hiển thị trong ô thay vì giá trị của nó. Mỗi loại lỗi có một mã cụ thể:

- #DIV/0! - công thức cố gắng chia cho zero.
- #GETTING_DATA - có thể hiển thị trên ô khi giá trị vẫn đang được tính.
- #N/A - thông tin bị thiếu hoặc không khả dụng. Một số nguyên nhân có thể là: các ô được dùng trong công thức rỗng, ký tự khoảng trắng thừa, lỗi đánh máy, v.v.
- #NAME? - không tìm thấy ô hoặc đối tượng công thức nào đó theo tên.
- #NULL! - có thể xuất hiện khi công thức có lỗi, như:  (,) hoặc ký tự khoảng trắng được dùng thay cho dấu hai chấm (:).
- #NUM! - giá trị số trong công thức không hợp lệ, quá dài hoặc quá nhỏ, v.v.
- #REF! - tham chiếu ô không hợp lệ.
- #VALUE! - kiểu giá trị không mong đợi. Ví dụ, giá trị chuỗi được đặt vào ô số.

```javascript
var cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
var value = cell.getValue();// giá trị chứa chuỗi "#DIV/0!"
```

## **Toán tử số học**
Bạn có thể sử dụng tất cả các toán tử số học trong công thức worksheet biểu đồ:

|**Toán tử**|**Ý nghĩa**|**Ví dụ**|
| :- | :- | :- |
|+ (dấu cộng)|Cộng hoặc dấu cộng một ngôi|2 + 3|
|- (dấu trừ)|Trừ hoặc dấu âm một ngôi|2 - 3<br>-3|
|* (dấu sao)|Nhân|2 * 3|
|/ (dấu gạch chéo)|Chia|2 / 3|
|% (dấu phần trăm)|Phần trăm|30%|
|^ (dấu mũ)|Lũy thừa|2 ^ 3|

*Note*: Để thay đổi thứ tự tính toán, bao quanh phần công thức cần tính trước bằng dấu ngoặc.

## **Toán tử so sánh**
Bạn có thể so sánh giá trị các ô bằng các toán tử so sánh. Khi hai giá trị được so sánh bằng các toán tử này, kết quả là một giá trị logic *TRUE* hoặc FALSE:

|**Toán tử**|**Ý nghĩa**|**Ví dụ**|
| :- | :- | :- |
|= (dấu bằng)|Bằng|A2 = 3|
|<> (dấu khác)|Không bằng|A2 <> 3|
|> (dấu lớn hơn)|Lớn hơn|A2 > 3|
|>= (dấu lớn hơn hoặc bằng)|Lớn hơn hoặc bằng|A2 >= 3|
|< (dấu nhỏ hơn)|Nhỏ hơn|A2 < 3|
|<= (dấu nhỏ hơn hoặc bằng)|Nhỏ hơn hoặc bằng|A2 <= 3|

## **Tham chiếu ô kiểu A1**
**Tham chiếu ô kiểu A1** được dùng cho các worksheet, trong đó cột có định danh là chữ (ví dụ “*A*”) và hàng có định danh là số (ví dụ “*1*”). Tham chiếu ô kiểu A1 có thể được sử dụng như sau:

|**Tham chiếu ô**|**Ví dụ**|||
| :- | :- | :- | :- |
||Tuyệt đối|Tương đối|Hỗn hợp|
|Ô|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Hàng|$2:$2|2:2|-|
|Cột|$A:$A|A:A|-|
|Phạm vi|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Ví dụ cách dùng tham chiếu ô kiểu A1 trong công thức:

```javascript
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **Tham chiếu ô kiểu R1C1**
**Tham chiếu ô kiểu R1C1** được dùng cho các worksheet, trong đó cả hàng và cột đều có định danh là số. Tham chiếu ô kiểu R1C1 có thể được sử dụng như sau:

|**Tham chiếu ô**|**Ví dụ**|||
| :- | :- | :- | :- |
||Tuyệt đối|Tương đối|Hỗn hợp|
|Ô|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Hàng|R2|R[2]|-|
|Cột|C3|C[3]|-|
|Phạm vi|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Ví dụ cách dùng tham chiếu ô kiểu R1C1 trong công thức:

```javascript
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Các hàm định sẵn**
Có một số hàm định sẵn có thể được dùng trong công thức để đơn giản hoá việc triển khai. Những hàm này bao gồm các thao tác thường dùng nhất, như:

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

**Có hỗ trợ sử dụng tệp Excel bên ngoài làm nguồn dữ liệu cho biểu đồ có công thức không?**

Có. Aspose.Slides hỗ trợ workbooks bên ngoài làm [nguồn dữ liệu cho biểu đồ](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatasourcetype/), cho phép bạn sử dụng công thức từ một tệp XLSX ngoài bản trình chiếu.

**Công thức biểu đồ có thể tham chiếu các sheet trong cùng workbook bằng tên sheet không?**

Có. Công thức tuân theo mô hình tham chiếu chuẩn của Excel, vì vậy bạn có thể tham chiếu các sheet khác trong cùng workbook hoặc một workbook bên ngoài. Đối với tham chiếu bên ngoài, bao gồm đường dẫn và tên workbook theo cú pháp của Excel.