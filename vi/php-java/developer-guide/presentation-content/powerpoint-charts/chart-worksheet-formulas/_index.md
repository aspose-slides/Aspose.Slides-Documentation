---
title: Áp dụng công thức bảng tính biểu đồ trong bản trình bày bằng PHP
linktitle: Công thức bảng tính
type: docs
weight: 70
url: /vi/php-java/chart-worksheet-formulas/
keywords:
- bảng tính biểu đồ
- bảng tính biểu đồ
- công thức biểu đồ
- công thức bảng tính
- công thức bảng tính
- workbook dữ liệu biểu đồ
- tính toán công thức
- hằng logic
- hằng số nguyên
- hằng chuỗi
- hằng lỗi
- toán tử số học
- toán tử so sánh
- kiểu A1
- kiểu R1C1
- hàm định trước
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Áp dụng công thức kiểu Excel trong các bảng tính biểu đồ của Aspose.Slides cho PHP thông qua Java, tính lại giá trị và sử dụng kết quả trong biểu đồ PowerPoint."
---
## **Tổng quan**

Biểu đồ PowerPoint thường lưu trữ dữ liệu nguồn của chúng trong một bảng tính nhúng. Trong Aspose.Slides for PHP via Java, bạn có thể truy cập bảng tính đó thông qua workbook dữ liệu biểu đồ, ghi các giá trị đầu vào, gán công thức cho các ô, tính các công thức được hỗ trợ và sử dụng các ô đã tính làm dữ liệu biểu đồ.

Bài viết này giải thích quy trình công thức hoàn chỉnh: tạo một biểu đồ, điền dữ liệu vào bảng tính của nó, gán công thức kiểu A1 hoặc R1C1, tính lại chúng, đọc các giá trị đã tính, kết nối các ô đó với một chuỗi biểu đồ và lưu bản trình bày. Nó cũng mô tả cú pháp công thức được hỗ trợ, tập hợp hàm tích hợp, giá trị được lưu trong bộ nhớ đệm, các công thức không được hỗ trợ và các lỗi đặc thù của bảng tính.

## **Bảng tính biểu đồ và công thức**

Một bảng tính biểu đồ chứa các danh mục, tên chuỗi và giá trị được biểu đồ sử dụng. Trong PowerPoint, bạn có thể kiểm tra bảng tính bằng cách mở trình chỉnh sửa dữ liệu biểu đồ:

![Biểu đồ PowerPoint với bảng tính nhúng mở, hiển thị dữ liệu danh mục và chuỗi](chart-worksheet-formulas_1.png)

Trong Aspose.Slides, bảng tính được lộ ra thông qua lớp [ChartDataWorkbook](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/). Sử dụng [ChartDataCell::setFormula](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatacell/#setFormula) cho công thức kiểu A1 và [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatacell/#setR1C1Formula) cho công thức kiểu R1C1. Sau khi thay đổi các ô đầu vào hoặc công thức, gọi [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) để tính lại các công thức được hỗ trợ và cập nhật các giá trị ô tương ứng.

Một ô đã tính vẫn cung cấp kết quả của nó thông qua [ChartDataCell::getValue](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatacell/#getValue). Điều này quan trọng khi bạn cần kiểm tra kết quả công thức trong mã hoặc sử dụng ô làm điểm dữ liệu cho biểu đồ.

## **Tạo biểu đồ và tính công thức trong bảng tính**

Ví dụ sau minh họa một quy trình từ đầu đến cuối. Nó tạo một biểu đồ cột nhóm, xóa dữ liệu mẫu, ghi các giá trị doanh thu và chi phí hàng quý, tính lợi nhuận bằng công thức, đọc kết quả, sử dụng các ô đã tính làm giá trị biểu đồ và lưu bản trình bày.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 350);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $workbook->clear($worksheetIndex);

    $category1 = $workbook->getCell($worksheetIndex, "A2", "Q1");
    $category2 = $workbook->getCell($worksheetIndex, "A3", "Q2");
    $category3 = $workbook->getCell($worksheetIndex, "A4", "Q3");

    $workbook->getCell($worksheetIndex, "B1", "Revenue");
    $workbook->getCell($worksheetIndex, "C1", "Expenses");
    $workbook->getCell($worksheetIndex, "D1", "Profit");

    $workbook->getCell($worksheetIndex, "B2")->setValue(120.0);
    $workbook->getCell($worksheetIndex, "C2")->setValue(80.0);
    $workbook->getCell($worksheetIndex, "B3")->setValue(150.0);
    $workbook->getCell($worksheetIndex, "C3")->setValue(95.0);
    $workbook->getCell($worksheetIndex, "B4")->setValue(135.0);
    $workbook->getCell($worksheetIndex, "C4")->setValue(110.0);

    $profit1 = $workbook->getCell($worksheetIndex, "D2");
    $profit2 = $workbook->getCell($worksheetIndex, "D3");
    $profit3 = $workbook->getCell($worksheetIndex, "D4");

    $profit1->setFormula("B2-C2");
    $profit2->setFormula("B3-C3");
    $profit3->setFormula("B4-C4");

    $workbook->calculateFormulas();

    $q1Profit = java_values($profit1->getValue()); // 40
    $q2Profit = java_values($profit2->getValue()); // 55
    $q3Profit = java_values($profit3->getValue()); // 25

    echo "Q1 profit: " . $q1Profit . PHP_EOL;
    echo "Q2 profit: " . $q2Profit . PHP_EOL;
    echo "Q3 profit: " . $q3Profit . PHP_EOL;

    $chart->getChartData()->getCategories()->add($category1);
    $chart->getChartData()->getCategories()->add($category2);
    $chart->getChartData()->getCategories()->add($category3);

    $profitSeries = $chart->getChartData()->getSeries()->add($workbook->getCell($worksheetIndex, "D1"), $chart->getType());
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit1);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit2);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit3);
    $profitSeries->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("chart-formulas.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Các điểm dữ liệu biểu đồ tham chiếu `D2:D4`, vì vậy biểu đồ sử dụng các giá trị lợi nhuận đã tính. Không có lệnh làm mới biểu đồ riêng trong quy trình này: tính lại workbook trước, sau đó sử dụng hoặc lưu dữ liệu biểu đồ mà nó trỏ tới các ô đã tính.

## **Sử dụng công thức kiểu A1**

Ký hiệu A1 xác định các cột bằng chữ và các hàng bằng số. Gán các biểu thức kiểu A1 thông qua [ChartDataCell::setFormula](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatacell/#setFormula).

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "C3")->setValue(10);
    $workbook->getCell(0, "F2")->setValue(2);
    $workbook->getCell(0, "G2")->setValue(3);
    $workbook->getCell(0, "H2")->setValue(4);

    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("C3+SUM(F2:H2)");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 19
} finally {
    $presentation->dispose();
}
```

Các dạng tham chiếu A1 thông dụng là:

| Tham chiếu | Tương đối | Tuyệt đối | Hỗn hợp |
|---|---|---|---|
| Ô | `A2` | `$A$2` | `A$2`, `$A2` |
| Hàng | `2:2` | `$2:$2` | — |
| Cột | `A:A` | `$A:$A` | — |
| Phạm vi | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Các tham chiếu tương đối có thể thay đổi khi công thức được di chuyển hoặc sao chép bởi ứng dụng bảng tính. Các tham chiếu tuyệt đối giữ cố định cả hai tọa độ, trong khi các tham chiếu hỗn hợp chỉ cố định một hàng hoặc một cột.

## **Sử dụng công thức kiểu R1C1**

Ký hiệu R1C1 xác định cả hàng và cột bằng số. Các tham chiếu tương đối sử dụng độ dịch trong dấu ngoặc vuông. Gán cú pháp này thông qua [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatacell/#setR1C1Formula).

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "B2")->setValue(12);
    $workbook->getCell(0, "C2")->setValue(5);

    $cell = $workbook->getCell(0, "D2");
    $cell->setR1C1Formula("RC[-2]-RC[-1]");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 7
} finally {
    $presentation->dispose();
}
```

Các dạng tham chiếu R1C1 thông dụng là:

| Tham chiếu | Tương đối | Tuyệt đối | Hỗn hợp |
|---|---|---|---|
| Ô | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Hàng | `R[2]` | `R2` | — |
| Cột | `C[3]` | `C3` | — |
| Phạm vi | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Ví dụ, trong ô `D2`, `RC[-2]` có nghĩa là ô cùng hàng, hai cột về trái (`B2`).

## **Hằng số và toán tử công thức**

Trình đánh giá công thức tích hợp hỗ trợ các giá trị logic, hằng số số, chuỗi, giá trị lỗi bảng tính, các toán tử số học và các toán tử so sánh.

### **Hằng số và hằng số nguyên văn**

| Kiểu | Ví dụ | Ghi chú |
|---|---|---|
| Logic | `TRUE`, `FALSE` | Có thể dùng trực tiếp trong biểu thức logic như `A2=TRUE`. |
| Số | `1`, `0.5`, `.3`, `1E-2` | Hỗ trợ ký hiệu thập phân và khoa học. |
| Chuỗi | `"abc"`, `"2/3/2020 12:00"` | Các hằng chuỗi được đặt trong dấu ngoặc kép đôi trong công thức. |
| Kết quả lỗi | `#DIV/0!`, `#N/A`, `#REF!` | Một công thức hợp lệ có thể đánh giá thành giá trị lỗi bảng tính thay vì kết quả bình thường. |

Ví dụ này sử dụng một số loại hằng số:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "A2")->setValue(false);
    $workbook->getCell(0, "B2")->setFormula("A2=TRUE");
    $workbook->getCell(0, "C2")->setFormula("1+0.5");
    $workbook->getCell(0, "D2")->setFormula(".3*1E-2");
    $workbook->getCell(0, "E2")->setFormula("\"abc\"");
    $workbook->getCell(0, "F2")->setFormula("2/0");

    $workbook->calculateFormulas();

    $logicalValue = java_values($workbook->getCell(0, "B2")->getValue()); // false
    $numericValue = java_values($workbook->getCell(0, "C2")->getValue()); // 1.5
    $scientificValue = java_values($workbook->getCell(0, "D2")->getValue()); // 0.003
    $stringValue = java_values($workbook->getCell(0, "E2")->getValue()); // abc
    $errorValue = java_values($workbook->getCell(0, "F2")->getValue()); // #DIV/0!
} finally {
    $presentation->dispose();
}
```

### **Toán tử số học**

| Toán tử | Ý nghĩa | Ví dụ |
|---|---|---|
| `+` | Cộng hoặc dấu cộng một ngôi | `2+3` |
| `-` | Trừ hoặc đảo dấu | `2-3`, `-3` |
| `*` | Nhân | `2*3` |
| `/` | Chia | `2/3` |
| `%` | Phần trăm | `30%` |
| `^` | Lũy thừa | `2^3` |

Sử dụng dấu ngoặc để làm rõ thứ tự tính toán, ví dụ `(A2+B2)*C2`.

### **Toán tử so sánh**

Các biểu thức so sánh trả về giá trị logic.

| Toán tử | Ý nghĩa | Ví dụ |
|---|---|---|
| `=` | Bằng | `A2=3` |
| `<>` | Không bằng | `A2<>3` |
| `>` | Lớn hơn | `A2>3` |
| `>=` | Lớn hơn hoặc bằng | `A2>=3` |
| `<` | Nhỏ hơn | `A2<3` |
| `<=` | Nhỏ hơn hoặc bằng | `A2<=3` |

## **Các hàm định trước được hỗ trợ**

Aspose.Slides bao gồm một trình đánh giá công thức tích hợp cho các bảng tính biểu đồ, nhưng nó không phải là một công cụ tính toán Excel đầy đủ. Bộ hàm được tài liệu hoá giới hạn ở các hàm dưới đây. Đừng cho rằng bất kỳ hàm Excel nào cũng có thể được tính lại bởi [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/#calculateFormulas).

| Hàm | Mục đích hoặc dạng được hỗ trợ | Ví dụ |
|---|---|---|
| `ABS` | Giá trị tuyệt đối | `ABS(A2)` |
| `AVERAGE` | Trung bình số học | `AVERAGE(B2:B5)` |
| `CEILING` | Làm tròn lên tới bội số | `CEILING(A2,5)` |
| `CHOOSE` | Chọn giá trị theo chỉ số | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Nối các giá trị văn bản | `CONCAT(A2,B2)` |
| `CONCATENATE` | Nối các giá trị văn bản | `CONCATENATE(A2," ",B2)` |
| `DATE` | Tạo giá trị ngày theo hệ thống ngày 1900 | `DATE(2026,8,19)` |
| `DAYS` | Trả về số ngày giữa các ngày | `DAYS(B2,A2)` |
| `FIND` | Tìm một chuỗi trong chuỗi khác | `FIND("-",A2)` |
| `FINDB` | Tìm chuỗi theo byte | `FINDB("a",A2)` |
| `IF` | Kết quả có điều kiện | `IF(A2>0,A2,0)` |
| `INDEX` | Dạng tham chiếu | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Dạng vector | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Dạng vector | `MATCH(A2,B2:B5,0)` |
| `MAX` | Giá trị lớn nhất | `MAX(B2:B5)` |
| `SUM` | Tổng các giá trị | `SUM(B2:B5)` |
| `VLOOKUP` | Tìm kiếm dọc | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Những hạn chế trong bảng trên là quan trọng: `INDEX` được tài liệu hoá ở dạng tham chiếu, trong khi `LOOKUP` và `MATCH` được tài liệu hoá ở dạng vector. `DATE` sử dụng hệ thống ngày 1900. Các tính năng và hàm không được liệt kê ở đây nên được coi là không được hỗ trợ bởi trình đánh giá công thức Aspose.Slides trừ khi chúng được tài liệu hoá riêng.

## **Tính lại và giá trị được lưu trong bộ nhớ đệm**

Các tệp bảng tính thường lưu cả công thức và giá trị đã tính cuối cùng của nó. Vì vậy, Aspose.Slides có thể đọc một giá trị đã lưu trong bộ nhớ đệm từ [ChartDataCell::getValue](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatacell/#getValue) khi bản trình bày được tải và dữ liệu biểu đồ liên quan chưa thay đổi.

Sau khi thay đổi các ô đầu vào hoặc công thức, không nên dựa vào kết quả đã lưu cũ. Gọi [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) trước khi đọc các giá trị đã tính hoặc lưu dữ liệu biểu đồ phụ thuộc vào chúng.

Đối với các công thức nằm ngoài tập con được hỗ trợ, Aspose.Slides có thể không thể phân tích công thức hoặc xác định các phụ thuộc của nó. Nếu workbook đã được chỉnh sửa, giá trị được lưu trước đó không còn đáng tin cậy. Trong trường hợp đó, việc đọc giá trị của ô có dữ liệu không được hỗ trợ có thể gây ra [CellUnsupportedDataException](https://reference.aspose.com/slides/vi/php-java/aspose.slides/cellunsupporteddataexception/).

Nếu biểu đồ của bạn phụ thuộc vào các hàm Excel mà Aspose.Slides không đánh giá, hãy tính các công thức đó bằng một công cụ bảng tính hỗ trợ chúng và ghi các giá trị kết quả trở lại workbook biểu đồ. Đừng thay thế các công thức không được hỗ trợ bằng các giá trị dự đoán.

## **Xử lý lỗi công thức**

Có hai loại vấn đề cần phân biệt.

Một công thức có thể hợp lệ nhưng tạo ra kết quả lỗi bảng tính như `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` hoặc `#VALUE!`. Trong trường hợp này, token lỗi là kết quả của ô và có thể được trả về qua [ChartDataCell::getValue](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatacell/#getValue).

Một công thức cũng có thể thất bại ở mức phân tích, tham chiếu, phụ thuộc hoặc dữ liệu không được hỗ trợ. Aspose.Slides cung cấp các ngoại lệ đặc thù cho bảng tính cho những trường hợp này: [CellInvalidFormulaException](https://reference.aspose.com/slides/vi/php-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/vi/php-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/vi/php-java/aspose.slides/cellcircularreferenceexception/), và [CellUnsupportedDataException](https://reference.aspose.com/slides/vi/php-java/aspose.slides/cellunsupporteddataexception/).

Trong PHP via Java, các ngoại lệ Java được hiển thị qua `JavaException`. Khi công thức đến từ mẫu hoặc đầu vào của người dùng, hãy xử lý chúng xung quanh việc tính lại và truy cập giá trị. Ngoại lệ Java được báo trong stack trace xác định lỗi bảng tính cụ thể:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("SUM(B2:B5)");

    try {
        $workbook->calculateFormulas();
        echo java_values($cell->getValue()) . PHP_EOL;
    } catch (JavaException $ex) {
        $ex->printStackTrace();
    }
} finally {
    $presentation->dispose();
}
```

## **Giới hạn thực tế**

Việc hỗ trợ công thức trong các bảng tính biểu đồ nhằm cho một tập con xác định của các phép tính bảng tính, không phải để tương thích toàn bộ Excel. Hãy ghi nhớ các ràng buộc này khi thiết kế quy trình báo cáo:

- Chỉ sử dụng các hằng số, toán tử, tham chiếu và hàm được tài liệu hoá khi bạn muốn Aspose.Slides tính lại công thức.
- Tính lại sau khi thay đổi các ô mà kết quả công thức phụ thuộc vào.
- Xem các giá trị được lưu trong bộ nhớ đệm từ các bản trình bày đã tải như là các ảnh chụp nhanh, không phải là sự thay thế cho việc tính lại sau khi chỉnh sửa.
- Kiểm tra các công thức từ các mẫu hiện có trước khi dựa vào các giá trị đã tính, đặc biệt là khi chúng sử dụng các hàm nằm ngoài danh sách được tài liệu hoá.
- Đối với các công thức yêu cầu một công cụ tính toán bảng tính đầy đủ, hãy tính chúng bên ngoài và sau đó cập nhật workbook biểu đồ với các giá trị kết quả.

## **Câu hỏi thường gặp**

**Sự khác biệt giữa [ChartDataCell::setFormula](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatacell/#setFormula) và [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatacell/#setR1C1Formula) là gì?**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatacell/#setFormula) lưu một biểu thức kiểu A1 như `B2-C2`. [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatacell/#setR1C1Formula) lưu một biểu thức kiểu R1C1 như `RC[-2]-RC[-1]`. Hãy dùng ký hiệu phù hợp nhất với cách bạn tạo hoặc sao chép công thức.

**Tôi có cần đọc ô itself hay giá trị của nó sau khi tính không?**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/#getCell) trả về một [ChartDataCell](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatacell/). Để lấy kết quả đã tính, gọi phương thức [ChartDataCell::getValue](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatacell/#getValue) của ô đó sau khi tính lại.

**Khi nào tôi nên gọi [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/#calculateFormulas)?**

Gọi [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) sau khi thay đổi giá trị đầu vào hoặc công thức và trước khi bạn phụ thuộc vào các kết quả đã tính. Lệnh này cập nhật các giá trị của các công thức mà bộ đánh giá tích hợp hỗ trợ.

**Aspose.Slides có hỗ trợ mọi hàm Excel không?**

Không. Bộ đánh giá tích hợp chỉ hỗ trợ một tập con hàm đã được tài liệu hoá. Các hàm nằm ngoài tập con đó không nên được cho là có thể tính lại đúng. Nếu cần tương thích công thức Excel đầy đủ, thực hiện tính toán bằng một công cụ bảng tính thích hợp và ghi các giá trị cuối cùng vào workbook biểu đồ.

**Nếu một bản trình bày đã tải chứa công thức không được hỗ trợ thì sẽ xảy ra gì?**

Nếu dữ liệu biểu đồ không thay đổi, workbook có thể vẫn chứa giá trị đã lưu trong bộ nhớ đệm trước đó. Sau khi dữ liệu liên quan được sửa đổi, giá trị đã lưu có thể không còn hợp lệ. Truy cập vào ô có công thức không thể xử lý có thể gây ra [CellUnsupportedDataException](https://reference.aspose.com/slides/vi/php-java/aspose.slides/cellunsupporteddataexception/).

**Giá trị lỗi công thức có giống ngoại lệ PHP không?**

Không. Một kết quả như `#DIV/0!` là một giá trị bảng tính được tạo ra bởi một phép tính hợp lệ. Các lỗi xử lý bảng tính như [CellInvalidFormulaException](https://reference.aspose.com/slides/vi/php-java/aspose.slides/cellinvalidformulaexception/) hoặc [CellCircularReferenceException](https://reference.aspose.com/slides/vi/php-java/aspose.slides/cellcircularreferenceexception/) là các ngoại lệ Java được bộc lộ cho PHP qua `JavaException`.

**Biểu đồ có tự động cập nhật khi ô công thức thay đổi không?**

Một chuỗi biểu đồ có thể tham chiếu các ô trong workbook. Tính lại workbook trước, sau đó lưu hoặc render bản trình bày. Nếu các điểm dữ liệu biểu đồ tham chiếu các ô đã tính, biểu đồ sẽ sử dụng các giá trị ô đã cập nhật; không cần phương thức làm mới biểu đồ riêng cho quy trình này.

**Biểu đồ có thể sử dụng một workbook Excel bên ngoài không?**

Có, dữ liệu biểu đồ có thể được cấu hình để sử dụng một workbook bên ngoài thông qua API dữ liệu biểu đồ. Tuy nhiên, quy trình tính công thức mô tả trong bài viết này chỉ liên quan đến workbook dữ liệu biểu đồ và tập con công thức được Aspose.Slides đánh giá. Đừng cho rằng [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) cung cấp việc tính lại đầy đủ các công thức tùy ý trong một tệp XLSX bên ngoài.

**Tôi có thể dùng công thức tham chiếu tới một worksheet hoặc workbook khác không?**

Các tham chiếu kiểu Excel có thể tồn tại trong workbook biểu đồ, nhưng việc đánh giá công thức bị giới hạn bởi bộ phân tích và tập hợp hàm được hỗ trợ. Nếu một tham chiếu xuyên sheet hoặc bên ngoài là bắt buộc, hãy xác thực công thức đó với phiên bản Aspose.Slides bạn đang dùng. Đối với các quy trình yêu cầu khả năng tương thích tham chiếu Excel rộng, hãy tính workbook bên ngoài và ghi các giá trị đã giải quyết trở lại dữ liệu biểu đồ.

**Chuỗi công thức có phải bắt đầu bằng `=` không?**

Các ví dụ API Aspose.Slides gán các biểu thức như `B2-C2` hoặc `SUM(B2:B5)` mà không có dấu `=` đầu. Sử dụng dạng này giúp các công thức được tạo ra nhất quán với các ví dụ API được tài liệu hoá.