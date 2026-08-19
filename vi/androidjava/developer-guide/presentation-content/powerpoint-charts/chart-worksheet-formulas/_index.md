---
title: Áp dụng công thức worksheet biểu đồ trong bản trình chiếu trên Android
linktitle: Công thức worksheet
type: docs
weight: 70
url: /vi/androidjava/chart-worksheet-formulas/
keywords:
- bảng tính biểu đồ
- worksheet biểu đồ
- công thức biểu đồ
- công thức worksheet
- công thức bảng tính
- workbook dữ liệu biểu đồ
- tính toán công thức
- hằng số logic
- hằng số số
- hằng số chuỗi
- hằng số lỗi
- toán tử số học
- toán tử so sánh
- kiểu A1
- kiểu R1C1
- hàm đã định nghĩa trước
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Áp dụng công thức kiểu Excel trong các worksheet biểu đồ của Aspose.Slides cho Android qua Java, tính lại giá trị và sử dụng kết quả trong các biểu đồ PowerPoint."
---
## **Tổng quan**

Biểu đồ PowerPoint thường lưu trữ dữ liệu nguồn của chúng trong một bảng tính được nhúng. Trong Aspose.Slides for Android via Java, bạn có thể truy cập bảng tính đó thông qua workbook dữ liệu biểu đồ, ghi các giá trị đầu vào, gán công thức cho các ô, tính các công thức được hỗ trợ và sử dụng các ô đã tính làm dữ liệu biểu đồ.

Bài viết này giải thích quy trình công thức đầy đủ: tạo biểu đồ, điền dữ liệu vào bảng tính, gán công thức kiểu A1 hoặc R1C1, tính lại chúng, đọc các giá trị đã tính, kết nối các ô đó với một chuỗi biểu đồ và lưu bản trình bày. Nó cũng mô tả cú pháp công thức được hỗ trợ, tập hợp hàm tích hợp, giá trị đã lưu trong bộ nhớ đệm, các công thức không được hỗ trợ và các lỗi đặc thù của bảng tính.

## **Bảng tính biểu đồ và công thức**

Bảng tính biểu đồ chứa các danh mục, tên chuỗi và giá trị được sử dụng bởi biểu đồ. Trong PowerPoint, bạn có thể kiểm tra bảng tính bằng cách mở trình chỉnh sửa dữ liệu biểu đồ:

![Biểu đồ PowerPoint với bảng tính được nhúng đang mở, hiển thị dữ liệu danh mục và chuỗi](chart-worksheet-formulas_1.png)

Trong Aspose.Slides, bảng tính được mở rộng thông qua giao diện [IChartDataWorkbook](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdataworkbook/). Sử dụng [IChartDataCell.setFormula](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) cho công thức kiểu A1 và [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) cho công thức kiểu R1C1. Sau khi thay đổi các ô đầu vào hoặc công thức, gọi [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) để tính lại các công thức được hỗ trợ và cập nhật giá trị ô tương ứng.

Một ô đã tính vẫn cung cấp kết quả của nó thông qua [IChartDataCell.getValue](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdatacell/#getValue--). Điều này quan trọng khi bạn cần kiểm tra kết quả công thức trong mã hoặc sử dụng ô làm điểm dữ liệu biểu đồ.

## **Tạo biểu đồ và tính công thức bảng tính**

Ví dụ sau đây minh họa quy trình làm việc từ đầu đến cuối. Nó tạo một biểu đồ cột nhóm, xóa dữ liệu mẫu, ghi giá trị doanh thu và chi phí quý, tính lợi nhuận bằng công thức, đọc kết quả, sử dụng các ô đã tính làm giá trị biểu đồ và lưu bản trình bày.

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

Các điểm dữ liệu biểu đồ tham chiếu `D2:D4`, vì vậy biểu đồ sử dụng các giá trị lợi nhuận đã tính. Không có cuộc gọi làm mới biểu đồ riêng trong quy trình này: tính lại workbook trước, sau đó sử dụng hoặc lưu dữ liệu biểu đồ trỏ tới các ô đã tính.

## **Sử dụng công thức kiểu A1**

Cú pháp A1 xác định cột bằng chữ và hàng bằng số. Gán biểu thức kiểu A1 thông qua [IChartDataCell.setFormula](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-).

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

Các dạng tham chiếu A1 thường gặp:

| Tham chiếu | Tương đối | Tuyệt đối | Hỗn hợp |
|---|---|---|---|
| Ô | `A2` | `$A$2` | `A$2`, `$A2` |
| Hàng | `2:2` | `$2:$2` | — |
| Cột | `A:A` | `$A:$A` | — |
| Vùng | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Tham chiếu tương đối có thể thay đổi khi công thức được di chuyển hoặc sao chép bởi ứng dụng bảng tính. Tham chiếu tuyệt đối giữ cố định cả hai tọa độ, trong khi tham chiếu hỗn hợp chỉ cố định một hàng hoặc một cột.

## **Sử dụng công thức kiểu R1C1**

Cú pháp R1C1 xác định cả hàng và cột bằng số. Tham chiếu tương đối sử dụng độ dịch trong dấu ngoặc vuông. Gán cú pháp này thông qua [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-).

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

Các dạng tham chiếu R1C1 thường gặp:

| Tham chiếu | Tương đối | Tuyệt đối | Hỗn hợp |
|---|---|---|---|
| Ô | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Hàng | `R[2]` | `R2` | — |
| Cột | `C[3]` | `C3` | — |
| Vùng | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Ví dụ, trong ô `D2`, `RC[-2]` có nghĩa là ô cùng hàng, hai cột về bên trái (`B2`).

## **Hằng số và toán tử công thức**

Bộ đánh giá công thức tích hợp hỗ trợ giá trị logic, số nguyên, chuỗi, giá trị lỗi bảng tính, toán tử số học và toán tử so sánh.

### **Hằng số và literal**

| Kiểu | Ví dụ | Ghi chú |
|---|---|---|
| Logic | `TRUE`, `FALSE` | Có thể dùng trực tiếp trong biểu thức logic như `A2=TRUE`. |
| Số | `1`, `0.5`, `.3`, `1E-2` | Hỗ trợ ký hiệu thập phân và khoa học. |
| Chuỗi | `"abc"`, `"2/3/2020 12:00"` | Literal văn bản được bao trong dấu ngoặc kép trong công thức. |
| Kết quả lỗi | `#DIV/0!`, `#N/A`, `#REF!` | Một công thức hợp lệ có thể đánh giá thành giá trị lỗi bảng tính thay vì kết quả bình thường. |

Ví dụ này sử dụng một số loại hằng số:

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
| `<>` | Không bằng | `A2<>3` |
| `>` | Lớn hơn | `A2>3` |
| `>=` | Lớn hơn hoặc bằng | `A2>=3` |
| `<` | Nhỏ hơn | `A2<3` |
| `<=` | Nhỏ hơn hoặc bằng | `A2<=3` |

## **Các hàm được định nghĩa trước được hỗ trợ**

Aspose.Slides bao gồm một bộ đánh giá công thức tích hợp cho các bảng tính biểu đồ, nhưng nó không phải là một động cơ tính toán Excel đầy đủ. Tập hợp hàm được tài liệu giới hạn ở các hàm dưới đây. Đừng cho rằng một hàm Excel bất kỳ có thể được tính lại bằng [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--).

| Hàm | Mục đích hoặc dạng được hỗ trợ | Ví dụ |
|---|---|---|
| `ABS` | Giá trị tuyệt đối | `ABS(A2)` |
| `AVERAGE` | Trung bình cộng | `AVERAGE(B2:B5)` |
| `CEILING` | Làm tròn lên đến bội số | `CEILING(A2,5)` |
| `CHOOSE` | Chọn giá trị theo chỉ số | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Nối các giá trị văn bản | `CONCAT(A2,B2)` |
| `CONCATENATE` | Nối các giá trị văn bản | `CONCATENATE(A2," ",B2)` |
| `DATE` | Tạo giá trị ngày theo hệ thống ngày 1900 | `DATE(2026,8,19)` |
| `DAYS` | Trả về số ngày giữa hai ngày | `DAYS(B2,A2)` |
| `FIND` | Tìm một chuỗi trong chuỗi khác | `FIND("-",A2)` |
| `FINDB` | Tìm văn bản dựa trên byte | `FINDB("a",A2)` |
| `IF` | Kết quả có điều kiện | `IF(A2>0,A2,0)` |
| `INDEX` | Dạng tham chiếu | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Dạng vector | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Dạng vector | `MATCH(A2,B2:B5,0)` |
| `MAX` | Giá trị lớn nhất | `MAX(B2:B5)` |
| `SUM` | Tổng các giá trị | `SUM(B2:B5)` |
| `VLOOKUP` | Tìm ngang | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Các hạn chế trong bảng trên là quan trọng: `INDEX` được tài liệu dưới dạng tham chiếu, trong khi `LOOKUP` và `MATCH` được tài liệu dưới dạng vector. `DATE` sử dụng hệ thống ngày 1900. Các tính năng và hàm không được liệt kê ở đây nên được xem là không được hỗ trợ bởi bộ đánh giá công thức Aspose.Slides trừ khi chúng được tài liệu riêng.

## **Tính lại và giá trị đã lưu trong bộ nhớ đệm**

Các tệp bảng tính thường lưu cả công thức và giá trị đã tính cuối cùng. Do đó Aspose.Slides có thể đọc giá trị đã lưu từ [IChartDataCell.getValue](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdatacell/#getValue--) khi một bản trình bày được tải và dữ liệu biểu đồ liên quan chưa thay đổi.

Sau khi thay đổi các ô đầu vào hoặc công thức, đừng dựa vào kết quả đã lưu cũ. Gọi [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) trước khi đọc các giá trị đã tính hoặc lưu dữ liệu biểu đồ phụ thuộc vào chúng.

Đối với các công thức nằm ngoài tập hợp được hỗ trợ, Aspose.Slides có thể không phân tích được công thức hoặc xác định các phụ thuộc. Nếu workbook đã được sửa đổi, giá trị đã lưu trước đó không còn đáng tin cậy. Trong trường hợp này, việc đọc giá trị của ô có dữ liệu không được hỗ trợ có thể gây ra [CellUnsupportedDataException](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/cellunsupporteddataexception/).

Nếu biểu đồ của bạn phụ thuộc vào các hàm Excel mà Aspose.Slides không đánh giá, hãy tính các công thức đó bằng một động cơ bảng tính hỗ trợ và ghi lại các giá trị kết quả vào workbook biểu đồ. Đừng thay thế các công thức không được hỗ trợ bằng giá trị ước tính.

## **Xử lý lỗi công thức**

Có hai loại vấn đề cần phân biệt.

Một công thức có thể hợp lệ nhưng tạo ra kết quả lỗi bảng tính như `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` hoặc `#VALUE!`. Trong trường hợp này, token lỗi là kết quả của ô và có thể được trả về qua [IChartDataCell.getValue](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdatacell/#getValue--).

Một công thức cũng có thể thất bại ở mức phân tích, tham chiếu, phụ thuộc hoặc dữ liệu không được hỗ trợ. Aspose.Slides cung cấp các ngoại lệ đặc thù cho bảng tính cho những trường hợp này: [CellInvalidFormulaException](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/cellcircularreferenceexception/) và [CellUnsupportedDataException](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/cellunsupporteddataexception/).

Khi công thức đến từ mẫu hoặc đầu vào người dùng, hãy bắt các ngoại lệ này xung quanh quá trình tính lại và truy cập giá trị:

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

## **Các hạn chế thực tế**

Hỗ trợ công thức trong bảng tính biểu đồ được thiết kế cho một tập hợp con đã định của các phép tính bảng tính, không phải cho khả năng tương thích đầy đủ với Excel. Hãy lưu ý các ràng buộc này khi thiết kế quy trình báo cáo:

- Chỉ sử dụng các hằng số, toán tử, tham chiếu và hàm được tài liệu khi bạn cần Aspose.Slides tính lại công thức.
- Tính lại sau khi thay đổi các ô mà kết quả công thức phụ thuộc vào.
- Xem các giá trị đã lưu trong bộ nhớ đệm từ các bản trình bày đã tải như là ảnh chụp nhanh, không thay thế cho việc tính lại sau khi chỉnh sửa.
- Kiểm tra các công thức từ mẫu hiện có trước khi tin cậy vào giá trị đã tính, đặc biệt khi chúng sử dụng các hàm ngoài danh sách được tài liệu.
- Đối với các công thức yêu cầu một động cơ tính toán bảng tính đầy đủ, hãy tính chúng bên ngoài và sau đó cập nhật workbook biểu đồ với các giá trị kết quả.

## **Câu hỏi thường gặp**

**Sự khác biệt giữa [IChartDataCell.setFormula](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) và [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) là gì?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) lưu một biểu thức kiểu A1 như `B2-C2`. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) lưu một biểu thức kiểu R1C1 như `RC[-2]-RC[-1]`. Sử dụng cú pháp phù hợp nhất với cách bạn tạo hoặc sao chép công thức.

**Tôi có cần đọc ô selbst hay giá trị của nó sau khi tính toán không?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) trả về một [IChartDataCell](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdatacell/). Để lấy kết quả đã tính, gọi phương thức [IChartDataCell.getValue](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdatacell/#getValue--) của ô đó sau khi tính lại.

**Khi nào tôi nên gọi [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)?**

Gọi [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) sau khi thay đổi giá trị đầu vào hoặc công thức và trước khi bạn phụ thuộc vào các kết quả đã tính. Điều này sẽ cập nhật các giá trị của các công thức mà bộ đánh giá tích hợp hỗ trợ.

**Aspose.Slides có hỗ trợ mọi hàm Excel không?**

Không. Bộ đánh giá tích hợp chỉ hỗ trợ một tập hợp hàm đã được tài liệu. Các hàm nằm ngoài tập hợp này không nên được cho là sẽ tính lại đúng. Nếu cần khả năng tương thích công thức Excel đầy đủ, thực hiện tính toán bằng một động cơ bảng tính thích hợp và ghi lại các giá trị cuối cùng vào workbook biểu đồ.

**Điều gì xảy ra nếu một bản trình bày đã tải chứa công thức không được hỗ trợ?**

Nếu dữ liệu biểu đồ không thay đổi, workbook có thể vẫn chứa giá trị đã lưu được tính trước đó. Sau khi dữ liệu liên quan được sửa đổi, giá trị đã lưu đó có thể không còn hợp lệ. Truy cập một ô có công thức không thể xử lý có thể gây ra [CellUnsupportedDataException](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/cellunsupporteddataexception/).

**Giá trị lỗi công thức có giống như ngoại lệ Java không?**

Không. Một kết quả như `#DIV/0!` là một giá trị bảng tính được tạo ra bởi một phép tính hợp lệ. Các ngoại lệ như [CellInvalidFormulaException](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/cellinvalidformulaexception/) hoặc [CellCircularReferenceException](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/cellcircularreferenceexception/) cho biết công thức không thể được xử lý bình thường.

**Biểu đồ có tự động cập nhật khi ô công thức thay đổi không?**

Một chuỗi biểu đồ có thể tham chiếu các ô trong workbook. Tính lại workbook trước, sau đó lưu hoặc render bản trình bày. Nếu các điểm dữ liệu biểu đồ tham chiếu các ô đã tính, biểu đồ sẽ sử dụng các giá trị ô đã cập nhật; không cần gọi phương thức làm mới biểu đồ riêng.

**Biểu đồ có thể sử dụng workbook Excel bên ngoài không?**

Có, dữ liệu biểu đồ có thể được cấu hình để sử dụng một workbook bên ngoài thông qua API dữ liệu biểu đồ. Tuy nhiên, quy trình tính công thức mô tả trong bài viết này liên quan đến workbook dữ liệu biểu đồ và tập hợp công thức được Aspose.Slides đánh giá. Đừng cho rằng [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) cung cấp việc tính lại đầy đủ các công thức tùy ý trong một tệp XLSX bên ngoài.

**Tôi có thể sử dụng công thức tham chiếu đến một worksheet hoặc workbook khác không?**

Các tham chiếu kiểu Excel có thể xuất hiện trong workbook biểu đồ, nhưng việc đánh giá công thức bị giới hạn bởi bộ phân tích và tập hợp hàm được hỗ trợ. Nếu một tham chiếu chéo sheet hoặc bên ngoài là bắt buộc, hãy xác nhận công thức đó với phiên bản Aspose.Slides mục tiêu của bạn. Đối với các quy trình cần khả năng tương thích tham chiếu Excel rộng, hãy tính workbook bên ngoài và ghi lại các giá trị đã giải quyết trở lại dữ liệu biểu đồ.

**Chuỗi công thức có bắt đầu bằng `=` không?**

Các ví dụ API Aspose.Slides gán các biểu thức như `B2-C2` hoặc `SUM(B2:B5)` mà không có dấu `=` phía trước. Sử dụng dạng này giúp công thức được tạo ra nhất quán với các ví dụ trong tài liệu API.