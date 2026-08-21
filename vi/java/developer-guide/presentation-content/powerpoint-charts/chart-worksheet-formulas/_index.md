---
title: Áp dụng Công thức Bảng tính Biểu đồ trong Bản trình bày bằng Java
linktitle: Công thức Bảng tính
type: docs
weight: 70
url: /vi/java/chart-worksheet-formulas/
keywords:
- bảng tính biểu đồ
- worksheet biểu đồ
- công thức biểu đồ
- công thức worksheet
- công thức bảng tính
- workbook dữ liệu biểu đồ
- tính toán công thức
- văn hoá ưu tiên
- công thức theo văn hoá
- DBCS
- hằng số logic
- hằng số số học
- hằng số chuỗi
- hằng số lỗi
- toán tử số học
- toán tử so sánh
- kiểu A1
- kiểu R1C1
- hàm định nghĩa sẵn
- PowerPoint
- bản trình bày
- Java
- Aspose.Slides
description: "Áp dụng công thức kiểu Excel trong bảng tính biểu đồ của Aspose.Slides cho Java, tính lại các giá trị và sử dụng kết quả trong biểu đồ PowerPoint."
---
## **Tổng quan**

Biểu đồ PowerPoint thường lưu trữ dữ liệu nguồn trong một bảng tính nhúng. Trong Aspose.Slides for Java, bạn có thể truy cập bảng tính đó thông qua workbook dữ liệu biểu đồ, ghi các giá trị đầu vào, gán công thức cho các ô, tính các công thức được hỗ trợ và sử dụng các ô đã tính làm dữ liệu biểu đồ.

Bài viết này giải thích quy trình công thức đầy đủ: tạo một biểu đồ, điền dữ liệu vào bảng tính của nó, gán công thức theo kiểu A1 hoặc R1C1, tính lại chúng, đọc các giá trị đã tính, kết nối các ô đó với một chuỗi dữ liệu biểu đồ và lưu bản trình bày. Nó cũng mô tả cú pháp công thức được hỗ trợ, tập hợp các hàm tích hợp, giá trị được lưu trong bộ nhớ đệm, các công thức không được hỗ trợ và các lỗi đặc thù của bảng tính.

## **Bảng tính biểu đồ và công thức**

Một bảng tính biểu đồ chứa các danh mục, tên chuỗi và giá trị được biểu đồ sử dụng. Trong PowerPoint, bạn có thể kiểm tra bảng tính bằng cách mở trình chỉnh sửa dữ liệu biểu đồ:

![Biểu đồ PowerPoint với bảng tính nhúng mở, hiển thị dữ liệu danh mục và chuỗi](chart-worksheet-formulas_1.png)

Trong Aspose.Slides, bảng tính được cung cấp thông qua giao diện [IChartDataWorkbook](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdataworkbook/) . Sử dụng [IChartDataCell.setFormula](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) cho công thức kiểu A1 và [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) cho công thức kiểu R1C1. Sau khi thay đổi các ô đầu vào hoặc công thức, gọi [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) để tính lại các công thức được hỗ trợ và cập nhật giá trị của các ô tương ứng.

Một ô đã tính vẫn cung cấp kết quả của mình thông qua [IChartDataCell.getValue](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdatacell/#getValue--) . Điều này quan trọng khi bạn cần kiểm tra kết quả công thức trong mã hoặc sử dụng ô làm điểm dữ liệu cho biểu đồ.

## **Tạo biểu đồ và tính công thức bảng tính**

Ví dụ sau đây minh họa quy trình từ đầu đến cuối. Nó tạo một biểu đồ cột nhóm, xóa dữ liệu mẫu, ghi các giá trị doanh thu và chi phí theo quý, tính lợi nhuận bằng công thức, đọc các kết quả, sử dụng các ô đã tính làm giá trị biểu đồ và lưu bản trình bày.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    IChartDataCell category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    IChartDataCell category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    IChartDataCell category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    IChartDataCell profit1 = workbook.getCell(worksheetIndex, "D2");
    IChartDataCell profit2 = workbook.getCell(worksheetIndex, "D3");
    IChartDataCell profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    double q1Profit = ((Number) profit1.getValue()).doubleValue(); // 40
    double q2Profit = ((Number) profit2.getValue()).doubleValue(); // 55
    double q3Profit = ((Number) profit3.getValue()).doubleValue(); // 25

    System.out.println("Q1 profit: " + q1Profit);
    System.out.println("Q2 profit: " + q2Profit);
    System.out.println("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    IChartSeries profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Các điểm dữ liệu biểu đồ tham chiếu `D2:D4`, vì vậy biểu đồ sử dụng các giá trị lợi nhuận đã tính. Không có lời gọi làm mới biểu đồ riêng trong quy trình này: tính lại workbook trước, sau đó sử dụng hoặc lưu dữ liệu biểu đồ mà trỏ tới các ô đã tính.

## **Sử dụng công thức kiểu A1**

Ký hiệu A1 xác định các cột bằng chữ và các hàng bằng số. Gán các biểu thức kiểu A1 thông qua [IChartDataCell.setFormula](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) .

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

Các dạng tham chiếu A1 thông thường là:

| Tham chiếu | Tương đối | Tuyệt đối | Hỗn hợp |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Row | `2:2` | `$2:$2` | — |
| Column | `A:A` | `$A:$A` | — |
| Range | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Tham chiếu tương đối có thể thay đổi khi công thức được di chuyển hoặc sao chép bởi ứng dụng bảng tính. Tham chiếu tuyệt đối giữ cố định cả hai tọa độ, trong khi tham chiếu hỗn hợp chỉ cố định một hàng hoặc một cột.

## **Sử dụng công thức kiểu R1C1**

Ký hiệu R1C1 xác định cả hàng và cột bằng số. Tham chiếu tương đối sử dụng độ dịch trong dấu ngoặc vuông. Gán cú pháp này thông qua [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) .

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    IChartDataCell cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

Các dạng tham chiếu R1C1 thông thường là:

| Tham chiếu | Tương đối | Tuyệt đối | Hỗn hợp |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Row | `R[2]` | `R2` | — |
| Column | `C[3]` | `C3` | — |
| Range | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Ví dụ, trong ô `D2`, `RC[-2]` có nghĩa là ô cùng hàng, hai cột bên trái (`B2`).

## **Hằng số và toán tử công thức**

Bộ đánh giá công thức tích hợp hỗ trợ các giá trị logic, hằng số số, chuỗi, giá trị lỗi bảng tính, toán tử số học và toán tử so sánh.

### **Hằng số và Giá trị Hằng**

| Kiểu | Ví dụ | Ghi chú |
|---|---|---|
| Logical | `TRUE`, `FALSE` | Có thể được sử dụng trực tiếp trong biểu thức logic như `A2=TRUE`. |
| Numeric | `1`, `0.5`, `.3`, `1E-2` | Hỗ trợ ký hiệu thập phân thông thường và khoa học. |
| String | `"abc"`, `"2/3/2020 12:00"` | Giá trị chuỗi được đặt trong dấu ngoặc kép trong công thức. |
| Error result | `#DIV/0!`, `#N/A`, `#REF!` | Một công thức hợp lệ có thể trả về giá trị lỗi của bảng tính thay vì kết quả bình thường. |

Ví dụ này sử dụng một số kiểu hằng số:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // false
    Object numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    Object scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    Object stringValue = workbook.getCell(0, "E2").getValue(); // abc
    Object errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **Toán tử số học**

| Toán tử | Ý nghĩa | Ví dụ |
|---|---|---|
| `+` | Cộng hoặc dấu cộng đơn vị | `2+3` |
| `-` | Trừ hoặc phủ định | `2-3`, `-3` |
| `*` | Nhân | `2*3` |
| `/` | Chia | `2/3` |
| `%` | Phần trăm | `30%` |
| `^` | Lũy thừa | `2^3` |

Sử dụng ngoặc để chỉ rõ thứ tự tính toán, ví dụ `(A2+B2)*C2`.

### **Toán tử so sánh**

Biểu thức so sánh trả về giá trị logic.

| Toán tử | Ý nghĩa | Ví dụ |
|---|---|---|
| `=` | Bằng | `A2=3` |
| `<>` | Không bằng | `A2<>3` |
| `>` | Lớn hơn | `A2>3` |
| `>=` | Lớn hơn hoặc bằng | `A2>=3` |
| `<` | Nhỏ hơn | `A2<3` |
| `<=` | Nhỏ hơn hoặc bằng | `A2<=3` |

## **Các hàm tích hợp được hỗ trợ**

Aspose.Slides bao gồm một bộ đánh giá công thức tích hợp cho các bảng tính biểu đồ, nhưng không phải là một động cơ tính toán Excel đầy đủ. Bộ hàm được tài liệu giới hạn chỉ các hàm dưới đây. Không giả định rằng một hàm Excel bất kỳ có thể được tính lại bằng [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) .

| Hàm | Mục đích hoặc dạng hỗ trợ | Ví dụ |
|---|---|---|
| `ABS` | Giá trị tuyệt đối | `ABS(A2)` |
| `AVERAGE` | Trung bình cộng | `AVERAGE(B2:B5)` |
| `CEILING` | Làm tròn lên tới bội số | `CEILING(A2,5)` |
| `CHOOSE` | Chọn giá trị theo chỉ số | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Nối các giá trị văn bản | `CONCAT(A2,B2)` |
| `CONCATENATE` | Nối các giá trị văn bản | `CONCATENATE(A2," ",B2)` |
| `DATE` | Tạo giá trị ngày theo hệ thống ngày 1900 | `DATE(2026,8,19)` |
| `DAYS` | Trả về số ngày giữa các ngày | `DAYS(B2,A2)` |
| `FIND` | Tìm một chuỗi văn bản trong chuỗi khác | `FIND("-",A2)` |
| `FINDB` | Tìm kiếm văn bản theo byte | `FINDB("a",A2)` |
| `IF` | Kết quả có điều kiện | `IF(A2>0,A2,0)` |
| `INDEX` | Dạng tham chiếu | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Dạng vector | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Dạng vector | `MATCH(A2,B2:B5,0)` |
| `MAX` | Giá trị tối đa | `MAX(B2:B5)` |
| `SUM` | Tổng các giá trị | `SUM(B2:B5)` |
| `VLOOKUP` | Tra cứu dọc | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Các hạn chế được hiển thị trong bảng là quan trọng: `INDEX` được tài liệu hoá dưới dạng tham chiếu, trong khi `LOOKUP` và `MATCH` được tài liệu hoá dưới dạng vector. `DATE` sử dụng hệ thống ngày 1900. Các tính năng và hàm không được liệt kê ở đây nên được coi là không được hỗ trợ bởi bộ đánh giá công thức Aspose.Slides trừ khi chúng được tài liệu hoá riêng.

## **Tính công thức với văn hóa ưu tiên**

Một số hàm workbook biểu đồ diễn giải văn bản dựa trên quy tắc riêng của văn hóa. Điều này đặc biệt quan trọng đối với các hàm dành cho ngôn ngữ sử dụng bộ ký tự đôi byte (DBCS). Để tính các công thức như vậy một cách chính xác, tạo [LoadOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/), đặt văn hóa ưu tiên bằng [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/vi/java/com.aspose.slides/spreadsheetoptions/#setPreferredCulture-java.util.Locale-), gán các tùy chọn bảng tính qua [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), và sau đó tải bản trình bày.

```java
import com.aspose.slides.*;
import java.util.Locale;

Locale japaneseCulture = Locale.forLanguageTag("ja-JP");

ISpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                chart.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Văn hóa ưu tiên là một phần của cấu hình tải bản trình bày, vì vậy hãy chỉ định nó trước khi tạo đối tượng [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) . Sử dụng văn hóa mà các công thức workbook mong đợi; ví dụ, dùng `ja-JP` cho các công thức cần tuân theo quy tắc tính toán DBCS của Nhật Bản.

## **Tính toán lại và giá trị được lưu trữ**

Tệp bảng tính thường lưu cả công thức và giá trị đã tính cuối cùng. Do đó Aspose.Slides có thể đọc một giá trị được lưu trong bộ nhớ đệm từ [IChartDataCell.getValue](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdatacell/#getValue--) khi một bản trình bày được tải và dữ liệu biểu đồ liên quan chưa bị thay đổi.

Sau khi thay đổi các ô đầu vào hoặc công thức, không nên dựa vào kết quả được lưu cũ. Gọi [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) trước khi đọc các giá trị đã tính hoặc lưu dữ liệu biểu đồ phụ thuộc vào chúng.

Đối với các công thức nằm ngoài tập hợp được hỗ trợ, Aspose.Slides có thể không thể phân tích công thức hoặc thiết lập các phụ thuộc. Nếu workbook đã được sửa đổi, giá trị được lưu trước đây không còn đáng tin cậy. Trong trường hợp đó, việc đọc giá trị của ô có dữ liệu không được hỗ trợ có thể gây ra [CellUnsupportedDataException](https://reference.aspose.com/slides/vi/java/com.aspose.slides/cellunsupporteddataexception/) .

Nếu biểu đồ của bạn phụ thuộc vào các hàm Excel mà Aspose.Slides không tính toán, hãy tính các công thức đó bằng một động cơ bảng tính hỗ trợ và ghi lại các giá trị kết quả vào workbook biểu đồ. Không thay thế các công thức không được hỗ trợ bằng giá trị ước đoán.

## **Xử lý lỗi công thức**

Có hai loại vấn đề khác nhau cần phân biệt.

Một công thức có thể hợp lệ nhưng tạo ra kết quả lỗi của bảng tính như `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, hoặc `#VALUE!`. Trong trường hợp này, token lỗi là kết quả của ô và có thể được trả về qua [IChartDataCell.getValue](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdatacell/#getValue--) .

Một công thức cũng có thể thất bại ở mức phân tích, tham chiếu, phụ thuộc hoặc dữ liệu được hỗ trợ. Aspose.Slides cung cấp các ngoại lệ đặc thù cho các trường hợp này: [CellInvalidFormulaException](https://reference.aspose.com/slides/vi/java/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/vi/java/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/vi/java/com.aspose.slides/cellcircularreferenceexception/), và [CellUnsupportedDataException](https://reference.aspose.com/slides/vi/java/com.aspose.slides/cellunsupporteddataexception/) .

Khi công thức đến từ mẫu hoặc đầu vào người dùng, hãy xử lý các ngoại lệ này quanh việc tính lại và truy cập giá trị:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        System.out.println(cell.getValue());
    } catch (CellInvalidFormulaException ex) {
        System.err.println("Invalid formula: " + ex.getMessage());
    } catch (CellInvalidReferenceException ex) {
        System.err.println("Invalid cell reference: " + ex.getMessage());
    } catch (CellCircularReferenceException ex) {
        System.err.println("Circular reference: " + ex.getMessage());
    } catch (CellUnsupportedDataException ex) {
        System.err.println("Unsupported spreadsheet data: " + ex.getMessage());
    }
} finally {
    presentation.dispose();
}
```

## **Giới hạn thực tế**

Hỗ trợ công thức trong bảng tính biểu đồ được thiết kế cho một tập hợp con đã định nghĩa của các phép tính bảng tính, không phải cho tính tương thích đầy đủ với Excel. Hãy ghi nhớ các ràng buộc này khi thiết kế quy trình báo cáo:

- Chỉ sử dụng các hằng số, toán tử, tham chiếu và hàm được tài liệu hoá khi bạn cần Aspose.Slides tính lại công thức.
- Tính lại sau khi thay đổi các ô mà kết quả công thức phụ thuộc.
- Xem các giá trị được lưu trong bộ nhớ đệm từ bản trình bày đã tải như các ảnh chụp, không phải là sự thay thế cho việc tính lại sau khi chỉnh sửa.
- Kiểm tra các công thức từ mẫu hiện có trước khi dựa vào giá trị đã tính, đặc biệt khi chúng sử dụng các hàm ngoài danh sách tài liệu.
- Đối với các công thức cần một động cơ tính toán bảng tính đầy đủ, tính chúng bên ngoài và sau đó cập nhật workbook biểu đồ với các giá trị kết quả.

## **Câu hỏi thường gặp**

**Sự khác biệt giữa [IChartDataCell.setFormula](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) và [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) lưu một biểu thức kiểu A1 như `B2-C2`. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) lưu một biểu thức kiểu R1C1 như `RC[-2]-RC[-1]`. Sử dụng ký hiệu phù hợp nhất với cách bạn tạo hoặc sao chép công thức.

**Có cần phải đọc ô itself hay giá trị của nó sau khi tính không?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) trả về một [IChartDataCell](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdatacell/) . Để lấy kết quả đã tính, gọi phương thức [IChartDataCell.getValue](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdatacell/#getValue--) của ô đó sau khi tính lại.

**Khi nào nên gọi [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)?**

Gọi [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) sau khi thay đổi giá trị đầu vào hoặc công thức và trước khi bạn phụ thuộc vào các kết quả đã tính. Điều này cập nhật giá trị của các công thức mà bộ đánh giá tích hợp hỗ trợ.

**Aspose.Slides có hỗ trợ mọi hàm Excel không?**

Không. Bộ đánh giá tích hợp hỗ trợ một tập hợp con đã tài liệu hoá các hàm. Các hàm nằm ngoài tập hợp này không nên được giả định sẽ tính lại đúng. Nếu cần tính toán đầy đủ với Excel, hãy thực hiện tính toán bằng một động cơ bảng tính thích hợp và ghi các giá trị cuối cùng vào workbook biểu đồ.

**Sẽ xảy ra điều gì nếu một bản trình bày đã tải chứa công thức không được hỗ trợ?**

Nếu dữ liệu biểu đồ chưa thay đổi, workbook có thể vẫn chứa giá trị đã tính được lưu trong bộ nhớ đệm. Sau khi dữ liệu liên quan được sửa đổi, giá trị đã lưu này có thể không còn hợp lệ. Truy cập vào ô có công thức không thể xử lý có thể gây ra [CellUnsupportedDataException](https://reference.aspose.com/slides/vi/java/com.aspose.slides/cellunsupporteddataexception/) .

**Giá trị lỗi công thức có giống với ngoại lệ Java không?**

Không. Kết quả như `#DIV/0!` là một giá trị bảng tính được tạo ra bởi một phép tính hợp lệ. Các ngoại lệ như [CellInvalidFormulaException](https://reference.aspose.com/slides/vi/java/com.aspose.slides/cellinvalidformulaexception/) hoặc [CellCircularReferenceException](https://reference.aspose.com/slides/vi/java/com.aspose.slides/cellcircularreferenceexception/) cho biết công thức không thể được xử lý bình thường.

**Biểu đồ có tự động cập nhật khi ô công thức thay đổi không?**

Một chuỗi dữ liệu biểu đồ có thể tham chiếu tới các ô workbook. Tính lại workbook trước, sau đó lưu hoặc render bản trình bày. Nếu các điểm dữ liệu biểu đồ tham chiếu các ô đã tính, biểu đồ sẽ sử dụng các giá trị ô cập nhật; không cần gọi phương thức làm mới biểu đồ riêng.

**Biểu đồ có thể sử dụng một workbook Excel bên ngoài không?**

Có, dữ liệu biểu đồ có thể được cấu hình để sử dụng một workbook bên ngoài thông qua API dữ liệu biểu đồ. Tuy nhiên, quy trình tính công thức được mô tả trong bài này chỉ áp dụng cho workbook dữ liệu biểu đồ và tập hợp con công thức được Aspose.Slides đánh giá. Không giả định rằng [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) cung cấp tính toán đầy đủ cho các công thức bất kỳ trong tệp XLSX bên ngoài.

**Có thể sử dụng công thức tham chiếu tới một worksheet hoặc workbook khác không?**

Các tham chiếu kiểu Excel có thể tồn tại trong workbook biểu đồ, nhưng việc đánh giá công thức bị giới hạn bởi bộ phân tích và tập hợp hàm được hỗ trợ. Nếu một tham chiếu chéo sheet hoặc bên ngoài là thiết yếu, hãy xác thực công thức đó với phiên bản Aspose.Slides mục tiêu của bạn. Đối với quy trình yêu cầu tương thích tham chiếu Excel rộng, hãy tính toán workbook bên ngoài và ghi các giá trị đã giải quyết trở lại dữ liệu biểu đồ.

**Chuỗi công thức có cần bắt đầu bằng `=` không?**

Các ví dụ API Aspose.Slides gán các biểu thức như `B2-C2` hoặc `SUM(B2:B5)` mà không có dấu `=` ở đầu. Sử dụng dạng này giúp công thức nhất quán với các ví dụ API được tài liệu hoá.