---
title: Áp dụng công thức bảng tính biểu đồ trong bản trình chiếu bằng JavaScript
linktitle: Công thức bảng tính
type: docs
weight: 70
url: /vi/nodejs-java/chart-worksheet-formulas/
keywords:
- biểu đồ bảng tính
- bảng tính biểu đồ
- công thức biểu đồ
- công thức bảng tính
- công thức bảng tính
- sổ làm việc dữ liệu biểu đồ
- tính toán công thức
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
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Áp dụng công thức kiểu Excel trong Aspose.Slides cho Node.js qua bảng tính biểu đồ Java, tính lại các giá trị và sử dụng kết quả trong biểu đồ PowerPoint."
---
## **Tổng quan**

Biểu đồ PowerPoint thường lưu trữ dữ liệu nguồn trong một bảng tính được nhúng. Trong Aspose.Slides cho Node.js qua Java, bạn có thể truy cập bảng tính đó thông qua sổ làm việc dữ liệu biểu đồ, ghi giá trị đầu vào, gán công thức cho các ô, tính các công thức được hỗ trợ và sử dụng các ô đã tính làm dữ liệu biểu đồ.

Bài viết này giải thích quy trình công thức đầy đủ: tạo biểu đồ, điền dữ liệu vào bảng tính, gán công thức dạng A1 hoặc R1C1, tính lại chúng, đọc các giá trị đã tính, kết nối các ô đó với chuỗi dữ liệu biểu đồ và lưu bản trình chiếu. Nó cũng mô tả cú pháp công thức được hỗ trợ, tập hợp hàm tích hợp, giá trị đã lưu, công thức không được hỗ trợ và các lỗi đặc thù của bảng tính.

## **Bảng tính biểu đồ và công thức**

Một bảng tính biểu đồ chứa các danh mục, tên chuỗi và giá trị được biểu đồ sử dụng. Trong PowerPoint, bạn có thể kiểm tra bảng tính bằng cách mở trình chỉnh sửa dữ liệu biểu đồ:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

Trong Aspose.Slides, bảng tính được mở ra qua lớp [ChartDataWorkbook](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdataworkbook/). Sử dụng [ChartDataCell.setFormula](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) cho công thức kiểu A1 và [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) cho công thức kiểu R1C1. Sau khi thay đổi các ô đầu vào hoặc công thức, gọi [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) để tính lại các công thức được hỗ trợ và cập nhật giá trị ô tương ứng.

Một ô đã tính vẫn cung cấp kết quả của nó qua [ChartDataCell.getValue](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatacell/#getValue--). Điều này quan trọng khi bạn cần kiểm tra kết quả công thức trong mã hoặc sử dụng ô làm điểm dữ liệu cho biểu đồ.

## **Tạo biểu đồ và tính công thức trong bảng tính**

Ví dụ sau minh họa một quy trình từ đầu đến cuối. Nó tạo một biểu đồ cột nhóm, xoá dữ liệu mẫu, ghi giá trị doanh thu và chi phí theo quý, tính lợi nhuận bằng công thức, đọc kết quả, sử dụng các ô đã tính làm giá trị biểu đồ và lưu bản trình chiếu.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 350);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    const category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    const category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    const category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    const profit1 = workbook.getCell(worksheetIndex, "D2");
    const profit2 = workbook.getCell(worksheetIndex, "D3");
    const profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    const q1Profit = profit1.getValue(); // 40
    const q2Profit = profit2.getValue(); // 55
    const q3Profit = profit3.getValue(); // 25

    console.log("Q1 profit: " + q1Profit);
    console.log("Q2 profit: " + q2Profit);
    console.log("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    const profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Các điểm dữ liệu biểu đồ tham chiếu `D2:D4`, vì vậy biểu đồ sử dụng các giá trị lợi nhuận đã tính. Không có lời gọi làm mới biểu đồ riêng trong quy trình này: tính lại sổ làm việc trước, sau đó sử dụng hoặc lưu dữ liệu biểu đồ trỏ tới các ô đã tính.

## **Sử dụng công thức kiểu A1**

Ký hiệu A1 xác định cột bằng chữ và hàng bằng số. Gán biểu thức kiểu A1 qua [ChartDataCell.setFormula](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-).

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    const cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

Các dạng tham chiếu A1 thường gặp là:

| Tham chiếu | Tương đối | Tuyệt đối | Hỗn hợp |
|---|---|---|---|
| Ô | `A2` | `$A$2` | `A$2`, `$A2` |
| Hàng | `2:2` | `$2:$2` | — |
| Cột | `A:A` | `$A:$A` | — |
| Phạm vi | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Tham chiếu tương đối có thể thay đổi khi công thức được di chuyển hoặc sao chép bởi ứng dụng bảng tính. Tham chiếu tuyệt đối giữ cả hai tọa độ cố định, trong khi tham chiếu hỗn hợp chỉ cố định một hàng hoặc một cột.

## **Sử dụng công thức kiểu R1C1**

Ký hiệu R1C1 xác định cả hàng và cột bằng số. Tham chiếu tương đối sử dụng độ dịch trong dấu ngoặc vuông. Gán cú pháp này qua [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-).

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    const cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

Các dạng tham chiếu R1C1 thường gặp là:

| Tham chiếu | Tương đối | Tuyệt đối | Hỗn hợp |
|---|---|---|---|
| Ô | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Hàng | `R[2]` | `R2` | — |
| Cột | `C[3]` | `C3` | — |
| Phạm vi | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Ví dụ, trong ô `D2`, `RC[-2]` có nghĩa là ô cùng hàng, hai cột sang trái (`B2`).

## **Hằng số và toán tử công thức**

Bộ đánh giá công thức tích hợp hỗ trợ giá trị logic, literal số, chuỗi, giá trị lỗi bảng tính, toán tử số học và toán tử so sánh.

### **Hằng số và literal**

| Kiểu | Ví dụ | Ghi chú |
|---|---|---|
| Logic | `TRUE`, `FALSE` | Có thể dùng trực tiếp trong biểu thức logic như `A2=TRUE`. |
| Số | `1`, `0.5`, `.3`, `1E-2` | Hỗ trợ ký hiệu thập phân và khoa học. |
| Chuỗi | `"abc"`, `"2/3/2020 12:00"` | Literal văn bản được đặt trong dấu ngoặc kép trong công thức. |
| Kết quả lỗi | `#DIV/0!`, `#N/A`, `#REF!` | Một công thức hợp lệ có thể đánh giá thành giá trị lỗi bảng tính thay vì kết quả bình thường. |

Ví dụ này sử dụng một số loại hằng số:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    const logicalValue = workbook.getCell(0, "B2").getValue(); // sai
    const numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    const scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    const stringValue = workbook.getCell(0, "E2").getValue(); // abc
    const errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **Toán tử số học**

| Toán tử | Ý nghĩa | Ví dụ |
|---|---|---|
| `+` | Cộng hoặc dấu cộng một ngôi | `2+3` |
| `-` | Trừ hoặc phủ định | `2-3`, `-3` |
| `*` | Nhân | `2*3` |
| `/` | Chia | `2/3` |
| `%` | Phần trăm | `30%` |
| `^` | Lũy thừa | `2^3` |

Sử dụng dấu ngoặc để làm rõ thứ tự tính, ví dụ `(A2+B2)*C2`.

### **Toán tử so sánh**

Biểu thức so sánh trả về giá trị logic.

| Toán tử | Ý nghĩa | Ví dụ |
|---|---|---|
| `=` | Bằng | `A2=3` |
| `<>` | Khác | `A2<>3` |
| `>` | Lớn hơn | `A2>3` |
| `>=` | Lớn hơn hoặc bằng | `A2>=3` |
| `<` | Nhỏ hơn | `A2<3` |
| `<=` | Nhỏ hơn hoặc bằng | `A2<=3` |

## **Các hàm định nghĩa trước được hỗ trợ**

Aspose.Slides bao gồm bộ đánh giá công thức tích hợp cho các bảng tính biểu đồ, nhưng nó không phải là một động cơ tính toán Excel đầy đủ. Tập hợp hàm được tài liệu chỉ giới hạn ở các hàm dưới đây. Đừng cho rằng bất kỳ hàm Excel nào cũng có thể được tính lại bằng [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--).

| Hàm | Mục đích hoặc dạng hỗ trợ | Ví dụ |
|---|---|---|
| `ABS` | Giá trị tuyệt đối | `ABS(A2)` |
| `AVERAGE` | Trung bình cộng | `AVERAGE(B2:B5)` |
| `CEILING` | Làm tròn lên đến bội số | `CEILING(A2,5)` |
| `CHOOSE` | Chọn giá trị theo chỉ mục | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Nối giá trị văn bản | `CONCAT(A2,B2)` |
| `CONCATENATE` | Nối giá trị văn bản | `CONCATENATE(A2," ",B2)` |
| `DATE` | Tạo giá trị ngày theo hệ thống ngày 1900 | `DATE(2026,8,19)` |
| `DAYS` | Trả về số ngày giữa các ngày | `DAYS(B2,A2)` |
| `FIND` | Tìm một chuỗi trong chuỗi khác | `FIND("-",A2)` |
| `FINDB` | Tìm kiếm hướng byte | `FINDB("a",A2)` |
| `IF` | Kết quả có điều kiện | `IF(A2>0,A2,0)` |
| `INDEX` | Dạng tham chiếu | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Dạng vectơ | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Dạng vectơ | `MATCH(A2,B2:B5,0)` |
| `MAX` | Giá trị lớn nhất | `MAX(B2:B5)` |
| `SUM` | Tổng các giá trị | `SUM(B2:B5)` |
| `VLOOKUP` | Tìm kiếm dọc | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Các hạn chế trong bảng quan trọng: `INDEX` được tài liệu dưới dạng tham chiếu, trong khi `LOOKUP` và `MATCH` được tài liệu dưới dạng vectơ. `DATE` sử dụng hệ thống ngày 1900. Các tính năng và hàm không được liệt kê ở đây nên được coi là không được hỗ trợ bởi bộ đánh giá công thức Aspose.Slides trừ khi chúng được tài liệu riêng.

## **Tái tính và giá trị đã lưu**

Các tệp bảng tính thường lưu cả công thức và giá trị đã tính lần cuối. Aspose.Slides do đó có thể đọc giá trị đã lưu từ [ChartDataCell.getValue](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatacell/#getValue--) khi bản trình chiếu được tải và dữ liệu biểu đồ liên quan chưa bị thay đổi.

Sau khi thay đổi các ô đầu vào hoặc công thức, đừng dựa vào kết quả đã lưu cũ. Gọi [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) trước khi đọc các giá trị đã tính hoặc lưu dữ liệu biểu đồ phụ thuộc vào chúng.

Đối với các công thức ngoài tập hợp được hỗ trợ, Aspose.Slides có thể không phân tích được công thức hoặc thiết lập các phụ thuộc. Nếu sổ làm việc đã được sửa đổi, giá trị đã lưu trước đó không còn đáng tin cậy. Trong trường hợp đó, việc đọc giá trị của ô có dữ liệu không được hỗ trợ có thể gây ra [CellUnsupportedDataException](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/cellunsupporteddataexception/).

Nếu biểu đồ của bạn phụ thuộc vào các hàm Excel mà Aspose.Slides không đánh giá, hãy tính các công thức đó bằng một động cơ bảng tính hỗ trợ chúng và ghi lại các giá trị đã tính vào sổ làm việc biểu đồ. Đừng thay thế các công thức không được hỗ trợ bằng giá trị dự đoán.

## **Xử lý lỗi công thức**

Có hai loại vấn đề cần phân biệt.

Một công thức có thể hợp lệ nhưng tạo ra kết quả lỗi bảng tính như `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` hoặc `#VALUE!`. Trong trường hợp này, token lỗi là kết quả của ô và có thể được trả về qua [ChartDataCell.getValue](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatacell/#getValue--).

Một công thức cũng có thể thất bại ở mức phân tích, tham chiếu, phụ thuộc hoặc dữ liệu không được hỗ trợ. Aspose.Slides cung cấp các ngoại lệ đặc thù bảng tính cho những trường hợp này: [CellInvalidFormulaException](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/cellcircularreferenceexception/), và [CellUnsupportedDataException](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/cellunsupporteddataexception/).

Khi công thức đến từ mẫu hoặc đầu vào người dùng, bắt lỗi xung quanh việc tái tính và truy cập giá trị. Chi tiết lỗi chỉ ra vấn đề bảng tính cơ bản:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        console.log(cell.getValue());
    } catch (error) {
        console.error("Formula processing error: " + error.message);
    }
} finally {
    presentation.dispose();
}
```

## **Giới hạn thực tế**

Hỗ trợ công thức trong bảng tính biểu đồ được thiết kế cho một tập hợp tính toán bảng tính đã định, không phải cho khả năng tương thích đầy đủ với Excel. Hãy ghi nhớ các hạn chế này khi thiết kế quy trình báo cáo:

- Chỉ sử dụng các hằng số, toán tử, tham chiếu và hàm được tài liệu khi bạn muốn Aspose.Slides tái tính công thức.
- Tái tính sau khi thay đổi các ô mà kết quả công thức phụ thuộc vào.
- Xem các giá trị đã lưu từ bản trình chiếu đã tải như ảnh chụp nhanh, không phải là thay thế cho việc tái tính sau khi chỉnh sửa.
- Kiểm tra các công thức từ mẫu hiện có trước khi dựa vào giá trị đã tính, đặc biệt khi chúng sử dụng các hàm ngoài danh sách đã tài liệu.
- Đối với các công thức yêu cầu một động cơ tính toán bảng tính đầy đủ, hãy tính chúng ngoại vi rồi cập nhật sổ làm việc biểu đồ bằng các giá trị kết quả.

## **Câu hỏi thường gặp**

**Khác biệt giữa [ChartDataCell.setFormula](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) và [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) là gì?**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) lưu biểu thức kiểu A1 như `B2-C2`. [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) lưu biểu thức kiểu R1C1 như `RC[-2]-RC[-1]`. Sử dụng ký hiệu phù hợp với cách bạn tạo hoặc sao chép công thức.

**Tôi có cần đọc ô itself hay giá trị của nó sau khi tính không?**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdataworkbook/#getCell-int-java.lang.String-) trả về một [ChartDataCell](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatacell/). Để lấy kết quả đã tính, gọi phương thức [ChartDataCell.getValue](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatacell/#getValue--) của ô đó sau khi tái tính.

**Khi nào nên gọi [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--)?**

Gọi [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) sau khi thay đổi giá trị đầu vào hoặc công thức và trước khi bạn phụ thuộc vào các kết quả đã tính. Điều này cập nhật giá trị của các công thức mà bộ đánh giá tích hợp hỗ trợ.

**Aspose.Slides có hỗ trợ mọi hàm Excel không?**

Không. Bộ đánh giá tích hợp chỉ hỗ trợ một tập hợp hàm đã tài liệu. Các hàm ngoài tập hợp này không nên được cho là sẽ tính lại chính xác. Nếu cần khả năng tương thích công thức Excel đầy đủ, hãy thực hiện tính toán bằng một động cơ bảng tính thích hợp và ghi lại các giá trị cuối cùng vào sổ làm việc biểu đồ.

**Điều gì sẽ xảy ra nếu bản trình chiếu đã tải chứa công thức không được hỗ trợ?**

Nếu dữ liệu biểu đồ chưa thay đổi, sổ làm việc có thể vẫn chứa giá trị được lưu tính trước. Sau khi dữ liệu liên quan được sửa đổi, giá trị lưu đó có thể không còn hợp lệ. Truy cập ô có công thức không thể xử lý có thể gây ra [CellUnsupportedDataException](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/cellunsupporteddataexception/).

**Giá trị lỗi công thức có đồng nghĩa với ngoại lệ không?**

Không. Kết quả như `#DIV/0!` là một giá trị bảng tính được tạo ra bởi một phép tính hợp lệ. Các ngoại lệ như [CellInvalidFormulaException](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/cellinvalidformulaexception/) hoặc [CellCircularReferenceException](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/cellcircularreferenceexception/) cho biết công thức không thể được xử lý bình thường.

**Biểu đồ có tự động cập nhật khi ô công thức thay đổi không?**

Một chuỗi biểu đồ có thể tham chiếu các ô trong sổ làm việc. Tải lại sổ làm việc trước, sau đó lưu hoặc render bản trình chiếu. Nếu các điểm dữ liệu biểu đồ tham chiếu các ô đã tính, biểu đồ sẽ sử dụng các giá trị ô đã cập nhật; không cần phương thức làm mới biểu đồ riêng cho quy trình này.

**Biểu đồ có thể sử dụng một sổ làm việc Excel bên ngoài không?**

Có, dữ liệu biểu đồ có thể được cấu hình để sử dụng một sổ làm việc bên ngoài thông qua API dữ liệu biểu đồ. Tuy nhiên, quy trình tính công thức được mô tả trong bài này liên quan đến sổ làm việc dữ liệu biểu đồ và tập hợp công thức được Aspose.Slides đánh giá. Đừng cho rằng [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) cung cấp khả năng tái tính đầy đủ các công thức tùy ý trong tệp XLSX bên ngoài.

**Tôi có thể dùng công thức tham chiếu đến một bảng tính hoặc sổ làm việc khác không?**

Các tham chiếu kiểu Excel có thể tồn tại trong sổ làm việc biểu đồ, nhưng việc đánh giá công thức bị giới hạn bởi trình phân tích và tập hợp hàm được hỗ trợ. Nếu một tham chiếu xuyên bảng hoặc bên ngoài là thiết yếu, hãy xác nhận công thức chính xác với phiên bản Aspose.Slides bạn đang dùng. Đối với các quy trình đòi hỏi tính năng tham chiếu Excel rộng rãi, hãy tính sổ làm việc bên ngoài và ghi lại các giá trị đã giải quyết vào dữ liệu biểu đồ.

**Chuỗi công thức có nên bắt đầu bằng `=` không?**

Các ví dụ API Aspose.Slides gán biểu thức như `B2-C2` hoặc `SUM(B2:B5)` mà không có dấu `=` đầu. Sử dụng dạng này giúp công thức được tạo ra nhất quán với các ví dụ tài liệu của API.