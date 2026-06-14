---
title: Áp dụng công thức worksheet biểu đồ trong bản trình bày bằng PHP
linktitle: Công thức Worksheet
type: docs
weight: 70
url: /vi/php-java/chart-worksheet-formulas/
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
- bản trình bày
- PHP
- Aspose.Slides
description: "Áp dụng công thức kiểu Excel trong Aspose.Slides cho PHP thông qua các worksheet biểu đồ Java và tự động hoá báo cáo trên các tệp PPT và PPTX."
---
## **Tổng quan**

Bảng tính biểu đồ là nguồn dữ liệu cho biểu đồ trong một bản trình bày. Nó lưu trữ tên danh mục và chuỗi cùng với các giá trị số được hiển thị bởi biểu đồ. Trong Aspose.Slides, bảng tính này có sẵn thông qua workbook dữ liệu biểu đồ, cho phép bạn làm việc với dữ liệu biểu đồ bằng lập trình.

Bài viết này giải thích cách sử dụng công thức trong bảng tính biểu đồ sao cho các giá trị ô có thể được tính toán và cập nhật tự động thay vì nhập thủ công. Nó cho thấy cách gán công thức, sử dụng cả tham chiếu kiểu A1 và kiểu R1C1, tính lại công thức workbook, và làm việc với các hằng số, toán tử, tham chiếu ô và hàm được hỗ trợ cho bảng tính biểu đồ trong bản trình bày.

## **Về công thức bảng tính biểu đồ trong bản trình bày**
**Bảng tính biểu đồ** (hoặc bảng tính worksheet) trong bản trình bày là nguồn dữ liệu của biểu đồ. Bảng tính biểu đồ chứa dữ liệu, được biểu diễn trên biểu đồ dưới dạng đồ họa. Khi bạn tạo biểu đồ trong PowerPoint, bảng tính liên kết với biểu đồ này cũng được tạo tự động. Bảng tính biểu đồ được tạo cho mọi loại biểu đồ: biểu đồ đường, biểu đồ cột, biểu đồ sunburst, biểu đồ tròn, v.v. Để xem bảng tính biểu đồ trong PowerPoint, bạn chỉ cần nhấp đúp vào biểu đồ:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Bảng tính biểu đồ chứa tên các phần tử biểu đồ (Tên danh mục: *Category1*, Tên chuỗi) và một bảng dữ liệu số tương ứng với các danh mục và chuỗi này. Theo mặc định, khi bạn tạo một biểu đồ mới – dữ liệu bảng tính biểu đồ được đặt với dữ liệu mặc định. Sau đó bạn có thể thay đổi dữ liệu bảng tính thủ công trong worksheet.

Thông thường, biểu đồ đại diện cho dữ liệu phức tạp (ví dụ: nhà phân tích tài chính, nhà phân tích khoa học), có các ô được tính từ giá trị của các ô khác hoặc từ dữ liệu động khác. Việc tính giá trị ô bằng tay và gán cố định vào ô khiến việc thay đổi trong tương lai trở nên khó khăn. Nếu bạn thay đổi giá trị của một ô nào đó, tất cả các ô phụ thuộc vào nó cũng phải được cập nhật. Hơn nữa, dữ liệu bảng có thể phụ thuộc vào dữ liệu từ các bảng khác, tạo ra một sơ đồ dữ liệu bản trình bày phức tạp cần được cập nhật một cách dễ dàng và linh hoạt.

**Công thức bảng tính biểu đồ** trong bản trình bày là một biểu thức để tự động tính toán và cập nhật dữ liệu bảng tính biểu đồ. Công thức bảng tính định nghĩa logic tính toán dữ liệu cho một ô hoặc một nhóm ô. Công thức bảng tính có thể là công thức toán học hoặc công thức logic, sử dụng: tham chiếu ô, hàm toán học, toán tử logic, toán tử số học, hàm chuyển đổi, hằng số chuỗi, v.v. Định nghĩa công thức được viết vào một ô, và ô này không chứa giá trị đơn giản. Công thức bảng tính tính giá trị và trả lại, sau đó giá trị này được gán cho ô. Công thức bảng tính trong bản trình bày thực chất giống công thức Excel, và hỗ trợ cùng các hàm, toán tử và hằng số mặc định như trong Excel.

Trong [**Aspose.Slides**](https://products.aspose.com/slides/vi/php-java/) bảng tính biểu đồ được biểu diễn bằng phương thức
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/#getChartDataWorkbook) của kiểu
[**ChartDataWorkbook**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/).
Công thức bảng tính có thể được gán và thay đổi bằng
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatacell/#setFormula). Các tính năng sau được hỗ trợ cho công thức trong Aspose.Slides:

- Hằng số logic
- Hằng số số
- Hằng số chuỗi
- Hằng số lỗi
- Toán tử số học
- Toán tử so sánh
- Tham chiếu ô kiểu A1
- Tham chiếu ô kiểu R1C1
- Các hàm định nghĩa sẵn

Thông thường, bảng tính lưu trữ các giá trị công thức đã tính cuối cùng. Nếu sau khi tải bản trình bày, dữ liệu biểu đồ không bị thay đổi – phương thức [**ChartDataCell::getValue**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatacell/#getValue) sẽ trả về các giá trị đó khi đọc. Tuy nhiên, nếu dữ liệu bảng tính đã bị thay đổi, khi đọc giá trị, nó sẽ ném ra ngoại lệ [**CellUnsupportedDataException**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/CellUnsupportedDataException) cho các công thức không được hỗ trợ. Điều này xảy ra vì khi công thức được phân tích thành công, các phụ thuộc ô được xác định và tính đúng đắn của các giá trị cuối cùng được xác nhận. Nếu công thức không thể phân tích, tính đúng đắn của giá trị ô không thể được đảm bảo.

## **Thêm công thức bảng tính biểu đồ vào bản trình bày**
Đầu tiên, thêm một biểu đồ vào slide đầu tiên của bản trình bày mới bằng
[ShapeCollection::addChart](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/#addChart).
Worksheet của biểu đồ sẽ được tạo tự động và có thể truy cập bằng
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/#getChartDataWorkbook) method:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 150, 150, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Hãy ghi một số giá trị vào các ô bằng phương thức
[**ChartDataCell::setValue**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatacell/#setValue) của kiểu **Object**, nghĩa là bạn có thể đặt bất kỳ giá trị nào:

```php
  $workbook->getCell(0, "F2")->setValue(-2.5);
  $workbook->getCell(0, "G3")->setValue(6.3);
  $workbook->getCell(0, "H4")->setValue(3);

```

Bây giờ để ghi công thức vào ô, bạn có thể sử dụng phương thức
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatacell/#setFormula).

*Lưu ý*: phương thức [**ChartDataCell::setFormula**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatacell/#setFormula) được dùng để đặt tham chiếu ô kiểu A1.

Để đặt công thức kiểu R1C1, bạn có thể dùng phương thức [**ChartDataCell::setR1C1Formula**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatacell/#setR1C1Formula).

Sau đó nếu bạn đọc giá trị từ các ô B2 và C2, chúng sẽ được tính toán:

```php
  $value1 = $cell1->getValue();// 7.8

  $value2 = $cell2->getValue();// 2.1


```

## **Hằng số Logic**
Bạn có thể sử dụng các hằng số logic như *FALSE* và *TRUE* trong công thức ô:

```php
  $workbook->getCell(0, "A2")->setValue(false);
  $cell = $workbook->getCell(0, "B2");
  $cell->setFormula("A2 = TRUE");
  $value = $cell->getValue();// giá trị chứa boolean "false"
```

## **Hằng số Số**
Số có thể được sử dụng ở dạng thông thường hoặc khoa học để tạo công thức bảng tính biểu đồ:

```php
  $workbook->getCell(0, "A2")->setFormula("1 + 0.5");
  $workbook->getCell(0, "B2")->setFormula(".3 * 1E-2");

```

## **Hằng số Chuỗi**
Hằng số chuỗi (hoặc hằng số literal) là giá trị cố định được sử dụng nguyên bản và không thay đổi. Hằng số chuỗi có thể là: ngày, văn bản, số, v.v.:

```php
  $workbook->getCell(0, "A2")->setFormula("\"abc\"");
  $workbook->getCell(0, "B2")->setFormula("\"2/3/2020 12:00\"");

```

## **Hằng số Lỗi**
Đôi khi không thể tính toán kết quả bằng công thức. Trong trường hợp đó, mã lỗi sẽ hiển thị trong ô thay vì giá trị. Mỗi loại lỗi có mã cụ thể:

- #DIV/0! – công thức cố gắng chia cho zero.
- #GETTING_DATA – có thể xuất hiện trên ô khi giá trị của nó vẫn đang được tính.
- #N/A – thông tin bị thiếu hoặc không có. Một số nguyên nhân có thể là: các ô được sử dụng trong công thức rỗng, có ký tự khoảng trắng thừa, lỗi đánh máy, v.v.
- #NAME? – không tìm thấy một ô hoặc đối tượng công thức nào đó theo tên.
- #NULL! – có thể xuất hiện khi có lỗi trong công thức, như: (,) hoặc ký tự khoảng trắng được dùng thay cho dấu hai chấm (:).
- #NUM! – số trong công thức có thể không hợp lệ, quá lớn hoặc quá nhỏ, v.v.
- #REF! – tham chiếu ô không hợp lệ.
- #VALUE! – kiểu giá trị không mong đợi. Ví dụ, giá trị chuỗi được đặt vào ô số.

```php
  $cell = $workbook->getCell(0, "A2");
  $cell->setFormula("2 / 0");
  $value = $cell->getValue();// giá trị chứa chuỗi "#DIV/0!"


```

## **Toán tử Số học**
Bạn có thể sử dụng tất cả các toán tử số học trong công thức worksheet biểu đồ:

|**Toán tử**|**Ý nghĩa**|**Ví dụ**|
| :- | :- | :- |
|+ (dấu cộng)|Cộng hoặc dấu cộng một ngôi|2 + 3|
|- (dấu trừ)|Trừ hoặc phủ định|- 3<br>-3|
|* (dấu sao)|Nhân|2 * 3|
|/ (dấu gạch chéo)|Chia|2 / 3|
|% (dấu phần trăm)|Phần trăm|30%|
|^ (dấu mũ)|Lũy thừa|2 ^ 3|

*Lưu ý*: Để thay đổi thứ tự tính toán, đặt phần công thức cần tính trước trong dấu ngoặc.

## **Toán tử So sánh**
Bạn có thể so sánh các giá trị của ô bằng các toán tử so sánh. Khi hai giá trị được so sánh bằng các toán tử này, kết quả là một giá trị logic là *TRUE* hoặc FALSE:

|**Toán tử**|**Ý nghĩa**|**Ví dụ**|
| :- | :- | :- |
|= (dấu bằng)|Bằng|A2 = 3|
|<> (dấu không bằng)|Không bằng|A2 <> 3|
|> (dấu lớn hơn)|Lớn hơn|A2 > 3|
|>= (dấu lớn hơn hoặc bằng)|Lớn hơn hoặc bằng|A2 >= 3|
|< (dấu nhỏ hơn)|Nhỏ hơn|A2 < 3|
|<= (dấu nhỏ hơn hoặc bằng)|Nhỏ hơn hoặc bằng|A2 <= 3|

## **Tham chiếu Ô Kiểu A1**
**Tham chiếu ô kiểu A1** được dùng cho các worksheet, trong đó cột có ký tự định danh (ví dụ “*A*”) và hàng có số định danh (ví dụ “*1*”). Tham chiếu ô kiểu A1 có thể được sử dụng như sau:

|**Tham chiếu ô**|**Ví dụ**|||
| :- | :- | :- | :- |
||Tuyệt đối|Tương đối|Hỗn hợp|
|Ô|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Hàng|$2:$2|2:2|-|
|Cột|$A:$A|A:A|-|
|Phạm vi|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Dưới đây là ví dụ cách dùng tham chiếu ô kiểu A1 trong công thức:

```php
  $workbook->getCell(0, "A2")->setFormula("C3 + SUM(F2:H5)");

```

## **Tham chiếu Ô Kiểu R1C1**
**Tham chiếu ô kiểu R1C1** được dùng cho các worksheet, trong đó cả hàng và cột đều có định danh số. Tham chiếu ô kiểu R1C1 có thể được sử dụng như sau:

|**Tham chiếu ô**|**Ví dụ**|||
| :- | :- | :- | :- |
||Tuyệt đối|Tương đối|Hỗn hợp|
|Ô|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Hàng|R2|R[2]|-|
|Cột|C3|C[3]|-|
|Phạm vi|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Dưới đây là ví dụ cách dùng tham chiếu ô kiểu A1 trong công thức:

```php
  $workbook->getCell(0, "A2")->setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");

```

## **Hàm Định nghĩa sẵn**
Có một số hàm định nghĩa sẵn, có thể được dùng trong công thức để đơn giản hoá việc triển khai. Các hàm này bao gồm các thao tác thường dùng nhất, như:

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

**Có hỗ trợ các tệp Excel bên ngoài làm nguồn dữ liệu cho biểu đồ có công thức không?**

Có. Aspose.Slides hỗ trợ workbooks bên ngoài như một [nguồn dữ liệu cho biểu đồ](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatasourcetype/), cho phép bạn sử dụng công thức từ một tệp XLSX bên ngoài bản trình bày.

**Công thức biểu đồ có thể tham chiếu các sheet trong cùng workbook bằng tên sheet không?**

Có. Công thức tuân theo mô hình tham chiếu chuẩn của Excel, vì vậy bạn có thể tham chiếu các sheet khác trong cùng workbook hoặc một workbook bên ngoài. Đối với tham chiếu bên ngoài, bao gồm đường dẫn và tên workbook theo cú pháp Excel.