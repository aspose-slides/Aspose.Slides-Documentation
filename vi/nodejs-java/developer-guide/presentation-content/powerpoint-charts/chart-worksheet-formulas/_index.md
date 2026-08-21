---
title: "Áp dụng công thức bảng tính biểu đồ trong bản trình bày bằng JavaScript"
linktitle: "Công thức bảng tính"
type: docs
weight: 70
url: /vi/nodejs-java/chart-worksheet-formulas/
keywords:
- "bảng tính biểu đồ"
- "worksheet biểu đồ"
- "công thức biểu đồ"
- "công thức bảng tính"
- "công thức bảng tính"
- "workbook dữ liệu biểu đồ"
- "tính toán công thức"
- "ngôn ngữ ưu tiên"
- "công thức phụ thuộc ngôn ngữ"
- "DBCS"
- "hằng số logic"
- "hằng số số"
- "hằng số chuỗi"
- "hằng số lỗi"
- "toán tử số học"
- "toán tử so sánh"
- "kiểu A1"
- "kiểu R1C1"
- "hàm dựng sẵn"
- "PowerPoint"
- "bản trình bày"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Áp dụng các công thức kiểu Excel trong Aspose.Slides cho Node.js thông qua bảng tính biểu đồ Java, tính lại các giá trị và sử dụng kết quả trong biểu đồ PowerPoint."
---
## **Tổng quan**

Biểu đồ PowerPoint thường lưu trữ dữ liệu nguồn của chúng trong một bảng tính nhúng. Trong Aspose.Slides cho Node.js thông qua Java, bạn có thể truy cập bảng tính đó thông qua workbook dữ liệu biểu đồ, ghi các giá trị đầu vào, gán công thức cho các ô, tính toán các công thức được hỗ trợ và sử dụng các ô đã tính toán làm dữ liệu biểu đồ.

Bài viết này giải thích quy trình làm việc đầy đủ với công thức: tạo biểu đồ, điền dữ liệu vào bảng tính, gán công thức dạng A1 hoặc R1C1, tính lại chúng, đọc các giá trị đã tính, kết nối các ô đó với chuỗi biểu đồ và lưu bản trình bày. Nó cũng mô tả cú pháp công thức được hỗ trợ, tập hợp các hàm tích hợp, giá trị đã lưu, công thức không được hỗ trợ và các lỗi đặc thù của bảng tính.

## **Bảng tính biểu đồ và Công thức**

Một bảng tính biểu đồ chứa các danh mục, tên chuỗi và giá trị được biểu đồ sử dụng. Trong PowerPoint, bạn có thể kiểm tra bảng tính bằng cách mở trình chỉnh sửa dữ liệu biểu đồ:

![Biểu đồ PowerPoint với bảng tính nhúng mở, hiển thị dữ liệu danh mục và chuỗi](chart-worksheet-formulas_1.png)

Trong Aspose.Slides, bảng tính được hiển thị thông qua lớp [ChartDataWorkbook]. Sử dụng [ChartDataCell.setFormula] cho công thức kiểu A1 và [ChartDataCell.setR1C1Formula] cho công thức kiểu R1C1. Sau khi thay đổi các ô đầu vào hoặc công thức, gọi [ChartDataWorkbook.calculateFormulas] để tính lại các công thức được hỗ trợ và cập nhật giá trị các ô tương ứng.

Một ô đã tính vẫn cung cấp kết quả qua [ChartDataCell.getValue]. Điều này quan trọng khi bạn cần kiểm tra kết quả công thức trong mã hoặc sử dụng ô làm điểm dữ liệu biểu đồ.

## **Tạo biểu đồ và tính toán công thức trong bảng tính**

Ví dụ sau minh họa quy trình từ đầu đến cuối. Nó tạo một biểu đồ cột nhóm, xóa dữ liệu mẫu, ghi giá trị doanh thu và chi phí theo quý, tính lợi nhuận bằng công thức, đọc kết quả, sử dụng các ô đã tính làm giá trị biểu đồ và lưu bản trình bày.

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

Các điểm dữ liệu biểu đồ tham chiếu `D2:D4`, vì vậy biểu đồ sử dụng các giá trị lợi nhuận đã tính. Không có lời gọi làm mới biểu đồ riêng trong quy trình này: tính lại workbook trước, sau đó sử dụng hoặc lưu dữ liệu biểu đồ mà chỉ tới các ô đã tính.

## **Sử dụng Công thức kiểu A1**

Ký hiệu A1 xác định cột bằng chữ và hàng bằng số. Gán các biểu thức dạng A1 thông qua [ChartDataCell.setFormula].

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

Tham chiếu tương đối có thể thay đổi khi công thức được di chuyển hoặc sao chép bởi ứng dụng bảng tính. Tham chiếu tuyệt đối giữ cố định cả hai tọa độ, trong khi tham chiếu hỗn hợp chỉ cố định hàng hoặc cột.

## **Sử dụng Công thức kiểu R1C1**

Ký hiệu R1C1 xác định cả hàng và cột bằng số. Tham chiếu tương đối sử dụng khoảng cách trong dấu ngoặc vuông. Gán cú pháp này thông qua [ChartDataCell.setR1C1Formula].

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

Ví dụ, trong ô `D2`, `RC[-2]` có nghĩa là ô cùng hàng, hai cột phía trái (`B2`).

## **Hằng số và toán tử công thức**

Trình đánh giá công thức tích hợp hỗ trợ giá trị logic, số nguyên, chuỗi, giá trị lỗi bảng tính, các toán tử số học và các toán tử so sánh.

### **Hằng số và Literals**

| Kiểu | Ví dụ | Ghi chú |
|---|---|---|
| Logic | `TRUE`, `FALSE` | Có thể được dùng trực tiếp trong các biểu thức logic như `A2=TRUE`. |
| Số | `1`, `0.5`, `.3`, `1E-2` | Hỗ trợ ký hiệu thập phân và khoa học. |
| Chuỗi | `"abc"`, `"2/3/2020 12:00"` | Các giá trị chuỗi được đặt trong dấu ngoặc kép đôi trong công thức. |
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

    const logicalValue = workbook.getCell(0, "B2").getValue(); // false
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
| `+` | Cộng hoặc dấu cộng đơn | `2+3` |
| `-` | Trừ hoặc dấu trừ đơn | `2-3`, `-3` |
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

## **Các hàm định nghĩa sẵn được hỗ trợ**

Aspose.Slides bao gồm một trình đánh giá công thức tích hợp cho các bảng tính biểu đồ, nhưng không phải là một động cơ tính toán Excel đầy đủ. Bộ hàm được tài liệu hoá chỉ giới hạn ở các hàm dưới đây. Đừng cho rằng bất kỳ hàm Excel nào cũng có thể được tính lại bằng [ChartDataWorkbook.calculateFormulas].

| Hàm | Mục đích hoặc dạng được hỗ trợ | Ví dụ |
|---|---|---|
| `ABS` | Giá trị tuyệt đối | `ABS(A2)` |
| `AVERAGE` | Trung bình cộng | `AVERAGE(B2:B5)` |
| `CEILING` | Làm tròn lên tới bội số | `CEILING(A2,5)` |
| `CHOOSE` | Chọn giá trị theo chỉ số | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Nối các giá trị văn bản | `CONCAT(A2,B2)` |
| `CONCATENATE` | Nối các giá trị văn bản | `CONCATENATE(A2," ",B2)` |
| `DATE` | Tạo giá trị ngày theo hệ thống ngày 1900 | `DATE(2026,8,19)` |
| `DAYS` | Trả về số ngày giữa các ngày | `DAYS(B2,A2)` |
| `FIND` | Tìm một giá trị văn bản trong giá trị khác | `FIND("-",A2)` |
| `FINDB` | Tìm văn bản dựa trên byte | `FINDB("a",A2)` |
| `IF` | Kết quả điều kiện | `IF(A2>0,A2,0)` |
| `INDEX` | Dạng tham chiếu | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Dạng vector | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Dạng vector | `MATCH(A2,B2:B5,0)` |
| `MAX` | Giá trị lớn nhất | `MAX(B2:B5)` |
| `SUM` | Tổng các giá trị | `SUM(B2:B5)` |
| `VLOOKUP` | Tìm theo chiều dọc | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Các hạn chế trong bảng trên rất quan trọng: `INDEX` được mô tả ở dạng tham chiếu, trong khi `LOOKUP` và `MATCH` được mô tả ở dạng vector. `DATE` sử dụng hệ thống ngày 1900. Các tính năng và hàm không có trong danh sách này nên được xem là không được hỗ trợ bởi trình đánh giá công thức Aspose.Slides trừ khi chúng được tài liệu hoá riêng.

## **Tính công thức với Ngôn ngữ Ưu tiên**

Một số hàm workbook biểu đồ giải thích văn bản theo quy tắc ngôn ngữ cụ thể. Điều này đặc biệt quan trọng đối với các hàm dành cho các ngôn ngữ sử dụng bộ ký tự đôi (DBCS). Để tính các công thức này một cách chính xác, tạo [LoadOptions], đặt ngôn ngữ ưu tiên bằng [SpreadsheetOptions.setPreferredCulture], gán các tùy chọn bảng tính qua [LoadOptions.setSpreadsheetOptions], sau đó tải bản trình bày.

Ví dụ sau chọn ngôn ngữ Nhật Bản, mở một bản trình bày với các tùy chọn tải đã cấu hình và gọi [ChartDataWorkbook.calculateFormulas] cho mọi workbook biểu đồ:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const japaneseCulture = java.newInstanceSync("java.util.Locale", "ja", "JP");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const shapes = slides.get_Item(slideIndex).getShapes();
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            const shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                shape.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Ngôn ngữ ưu tiên là một phần của cấu hình tải bản trình bày, vì vậy hãy chỉ định nó trước khi tạo đối tượng [Presentation]. Sử dụng ngôn ngữ mà các công thức workbook mong đợi; ví dụ, dùng `ja-JP` cho các công thức cần tuân theo quy tắc tính DBCS của Nhật Bản.

## **Tính lại và Giá trị đã lưu**

Các tệp bảng tính thường lưu cả công thức và giá trị đã tính lần cuối. Vì vậy Aspose.Slides có thể đọc giá trị đã lưu từ [ChartDataCell.getValue] khi bản trình bày được tải và dữ liệu biểu đồ tương ứng chưa bị thay đổi.

Sau khi thay đổi các ô đầu vào hoặc công thức, đừng dựa vào kết quả lưu cũ. Gọi [ChartDataWorkbook.calculateFormulas] trước khi đọc các giá trị đã tính hoặc lưu dữ liệu biểu đồ phụ thuộc vào chúng.

Đối với các công thức nằm ngoài tập hợp được hỗ trợ, Aspose.Slides có thể không phân tích được công thức hoặc xác định được các phụ thuộc. Nếu workbook đã được sửa đổi, giá trị lưu trước đó không còn đáng tin cậy. Trong trường hợp đó, việc đọc giá trị của ô có dữ liệu không được hỗ trợ có thể gây ra [CellUnsupportedDataException].

Nếu biểu đồ của bạn phụ thuộc vào các hàm Excel mà Aspose.Slides không đánh giá, hãy tính các công thức đó bằng một động cơ bảng tính hỗ trợ và ghi các giá trị kết quả trở lại workbook biểu đồ. Đừng thay thế các công thức không được hỗ trợ bằng các giá trị đoán.

## **Xử lý lỗi công thức**

Có hai loại vấn đề cần phân biệt.

Một công thức có thể hợp lệ nhưng tạo ra kết quả lỗi bảng tính như `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` hoặc `#VALUE!`. Trong trường hợp này, token lỗi là kết quả của ô và có thể được trả về thông qua [ChartDataCell.getValue].

Một công thức cũng có thể thất bại ở mức phân tích, tham chiếu, phụ thuộc hoặc dữ liệu không được hỗ trợ. Aspose.Slides cung cấp các ngoại lệ đặc thù bảng tính cho những trường hợp này: [CellInvalidFormulaException], [CellInvalidReferenceException], [CellCircularReferenceException] và [CellUnsupportedDataException].

Khi công thức đến từ mẫu hoặc đầu vào người dùng, hãy bắt các lỗi xung quanh việc tính lại và truy cập giá trị. Chi tiết lỗi xác định vấn đề bảng tính cơ bản:

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

## **Hạn chế thực tiễn**

Hỗ trợ công thức trong bảng tính biểu đồ được thiết kế cho một tập hợp giới hạn các tính toán bảng tính, không phải cho khả năng tương thích đầy đủ với Excel. Hãy ghi nhớ các ràng buộc này khi thiết kế quy trình báo cáo:

- Chỉ sử dụng các hằng số, toán tử, tham chiếu và hàm được tài liệu hoá khi bạn cần Aspose.Slides tính lại công thức.
- Tính lại sau khi thay đổi các ô mà kết quả công thức phụ thuộc vào.
- Xem các giá trị đã lưu từ bản trình bày đã tải như những ảnh chụp nhanh, không phải là thay thế cho việc tính lại sau khi chỉnh sửa.
- Kiểm tra các công thức từ mẫu hiện có trước khi tin cậy vào giá trị đã tính, đặc biệt khi chúng sử dụng các hàm ngoài danh sách tài liệu.
- Đối với các công thức cần một động cơ tính toán bảng tính đầy đủ, hãy tính chúng bên ngoài và sau đó cập nhật workbook biểu đồ bằng các giá trị cuối cùng.

## **FAQ**

**Sự khác nhau giữa [ChartDataCell.setFormula] và [ChartDataCell.setR1C1Formula] là gì?**

[ChartDataCell.setFormula] lưu một biểu thức kiểu A1 như `B2-C2`. [ChartDataCell.setR1C1Formula] lưu một biểu thức kiểu R1C1 như `RC[-2]-RC[-1]`. Sử dụng ký hiệu phù hợp với cách bạn tạo hoặc sao chép công thức.

**Tôi cần đọc ô riêng hay giá trị của nó sau khi tính toán?**

[ChartDataWorkbook.getCell] trả về một [ChartDataCell]. Để lấy kết quả đã tính, gọi phương thức [ChartDataCell.getValue] của ô đó sau khi tính lại.

**Khi nào tôi nên gọi [ChartDataWorkbook.calculateFormulas]?**

Gọi [ChartDataWorkbook.calculateFormulas] sau khi thay đổi giá trị đầu vào hoặc công thức và trước khi bạn phụ thuộc vào các kết quả đã tính. Điều này cập nhật các giá trị của các công thức mà trình đánh giá tích hợp hỗ trợ.

**Aspose.Slides có hỗ trợ mọi hàm Excel không?**

Không. Trình đánh giá tích hợp chỉ hỗ trợ một tập hợp hàm đã được tài liệu hoá. Các hàm ngoài tập hợp này không nên được cho là sẽ tính lại đúng. Nếu cần khả năng tương thích công thức Excel đầy đủ, hãy thực hiện tính toán bằng một động cơ bảng tính thích hợp và ghi các giá trị cuối cùng vào workbook biểu đồ.

**Điều gì xảy ra nếu một bản trình bày đã tải chứa công thức không được hỗ trợ?**

Nếu dữ liệu biểu đồ chưa thay đổi, workbook có thể vẫn chứa giá trị đã tính lưu trước. Sau khi dữ liệu liên quan được sửa đổi, giá trị lưu này có thể không còn hợp lệ. Truy cập một ô có công thức không thể xử lý có thể gây ra [CellUnsupportedDataException].

**Giá trị lỗi công thức có giống ngoại lệ không?**

Không. Một kết quả như `#DIV/0!` là một giá trị bảng tính được tạo ra bởi một phép tính hợp lệ. Các ngoại lệ như [CellInvalidFormulaException] hoặc [CellCircularReferenceException] cho biết công thức không thể được xử lý bình thường.

**Biểu đồ có tự động cập nhật khi ô công thức thay đổi không?**

Một chuỗi biểu đồ có thể tham chiếu tới các ô workbook. Tính lại workbook trước, sau đó lưu hoặc render bản trình bày. Nếu các điểm dữ liệu biểu đồ tham chiếu tới các ô đã tính, biểu đồ sẽ sử dụng các giá trị ô đã cập nhật; không cần phương thức làm mới biểu đồ riêng trong quy trình này.

**Biểu đồ có thể sử dụng workbook Excel bên ngoài không?**

Có, dữ liệu biểu đồ có thể được cấu hình để sử dụng một workbook bên ngoài thông qua API dữ liệu biểu đồ. Tuy nhiên, quy trình tính công thức được mô tả trong bài này chỉ liên quan tới workbook dữ liệu biểu đồ và tập hợp công thức được Aspose.Slides đánh giá. Đừng cho rằng [ChartDataWorkbook.calculateFormulas] cung cấp việc tính lại đầy đủ các công thức bất kỳ trong tệp XLSX bên ngoài.

**Tôi có thể dùng công thức tham chiếu tới một bảng tính hoặc workbook khác không?**

Các tham chiếu kiểu Excel có thể tồn tại trong workbook biểu đồ, nhưng việc đánh giá công thức bị giới hạn bởi bộ phân tích và tập hợp hàm được hỗ trợ. Nếu một tham chiếu chéo sheet hoặc bên ngoài là thiết yếu, hãy xác thực công thức đó với phiên bản Aspose.Slides mà bạn đang sử dụng. Đối với các quy trình yêu cầu khả năng tham chiếu Excel rộng, hãy tính workbook bên ngoài và ghi các giá trị đã giải quyết trở lại dữ liệu biểu đồ.

**Chuỗi công thức có cần bắt đầu bằng `=` không?**

Các ví dụ API Aspose.Slides gán các biểu thức như `B2-C2` hoặc `SUM(B2:B5)` mà không có dấu `=` ở đầu. Sử dụng dạng này giúp các công thức được tạo ra nhất quán với các ví dụ tài liệu API.