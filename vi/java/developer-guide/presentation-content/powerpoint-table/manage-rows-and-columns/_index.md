---
title: Quản lý hàng và cột trong bảng PowerPoint bằng Java
linktitle: Hàng và Cột
type: docs
weight: 20
url: /vi/java/manage-rows-and-columns/
keywords:
- hàng bảng
- cột bảng
- hàng đầu tiên
- tiêu đề bảng
- sao chép hàng
- sao chép cột
- chép hàng
- chép cột
- xóa hàng
- xóa cột
- định dạng văn bản hàng
- định dạng văn bản cột
- kiểu bảng
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Quản lý các hàng và cột của bảng trong PowerPoint bằng Aspose.Slides cho Java và tăng tốc việc chỉnh sửa bản trình chiếu cũng như cập nhật dữ liệu."
---
## **Giới thiệu**

Aspose.Slides for Java cho phép bạn quản lý cấu trúc và định dạng bảng trong các bản trình chiếu PowerPoint thông qua lớp [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/) và giao diện [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/). Bạn có thể chỉ định một hàng tiêu đề, sao chép hoặc xóa các hàng và cột, và áp dụng định dạng văn bản cho toàn bộ hàng hoặc cột.

Bài viết này giải thích các thao tác này bằng các ví dụ Java. Nó cũng chỉ ra cách lấy mẫu kiểu bảng để bạn có thể tái sử dụng. Các chỉ số hàng và cột trong bảng bắt đầu từ 0.

## **Kiểm soát chiều cao hàng**

Sử dụng [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-) để đặt chiều cao tối thiểu của một hàng tính bằng điểm. Đây là một giới hạn dưới, không phải chiều cao cố định. [IRow.getHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#getHeight--) trả về chiều cao thực tế. Truy cập hàng thông qua [ITable.getRows](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getRows--).

Ví dụ tải tệp [row-height-input.pptx](row-height-input.pptx), trong đó có một bảng là hình dạng đầu tiên trên slide đầu tiên. Hàng đầu tiên bắt đầu ở 70 điểm. Các ô sử dụng văn bản Arial 18‑point, có ngắt dòng và lề trên dưới 6 point; văn bản dài hơn trong cột thứ hai ngắt dòng thành nhiều dòng. Ví dụ tăng chiều cao tối thiểu lên 100 point, rồi giảm xuống 20 point, in chiều cao thực tế sau mỗi thay đổi và lưu cả hai kết quả.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("row-height-input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    IRow row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    System.out.printf("Increased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx);

    row.setMinimalHeight(20);
    System.out.printf("Decreased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Với bản trình chiếu được cung cấp, việc tăng chiều cao tối thiểu sẽ thêm không gian vào hàng. Việc giảm nó sẽ loại bỏ không gian thêm đó, nhưng chiều cao thực tế vẫn lớn hơn 20 point vì văn bản và lề ô cần nhiều không gian hơn. Chỉ giảm chiều cao tối thiểu không thể ép hàng giảm xuống dưới mức không gian cần thiết cho nội dung của nó.

Một số yếu tố ảnh hưởng đến chiều cao thực tế:

- **Văn bản và kích thước phông chữ:** văn bản dài hơn, ngắt dòng thủ công hoặc phông chữ lớn hơn có thể yêu cầu nhiều không gian dọc hơn.
- **Ngắt dòng và độ rộng cột:** khi bật ngắt dòng, giảm độ rộng cột bằng [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) có thể tạo ra nhiều dòng hơn. Một cột rộng hơn có thể giảm không gian cần thiết theo chiều dọc.
- **Lề ô:** [ICell.setMarginTop](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginTop-double-) và [ICell.setMarginBottom](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginBottom-double-) thêm không gian dọc. [ICell.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginLeft-double-) và [ICell.setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginRight-double-) giảm độ rộng có sẵn cho văn bản và có thể gây ngắt dòng thêm.

Đối với bảng này không có ô hợp nhất, ô cần nhiều không gian dọc nhất sẽ quyết định giới hạn dưới do nội dung gây ra cho toàn bộ hàng. Để làm hàng ngắn hơn, bạn có thể cần rút ngắn văn bản, giảm kích thước phông chữ hoặc lề, hoặc làm rộng một cột.

Các hình ảnh dưới đây cho thấy cùng một bảng ở cùng tỷ lệ. Trong các kết quả minh hoạ, chiều cao thực tế là 70, 100 và 55,2 point: hàng cuối cùng vẫn cao hơn mức tối thiểu 20 point. Các đo lường văn bản chính xác có thể thay đổi tùy vào phông chữ có sẵn trong môi trường của bạn. Tải kết quả đã lưu: [increased minimum](row-height-increased.pptx) và [decreased minimum](row-height-decreased.pptx).

| Original: minimum 70 pt, actual 70 pt | Increased: minimum 100 pt, actual 100 pt | Decreased: minimum 20 pt, actual 55.2 pt |
| --- | --- | --- |
| ![Original table with a 70-point first row.](row-height-before.png) | ![Table after increasing the first row minimum to 100 points.](row-height-increased.png) | ![Table after decreasing the first row minimum to 20 points; wrapped text keeps the row taller than the minimum.](row-height-decreased.png) |

## **Đặt Hàng Đầu Tiên Là Tiêu Đề**

Sử dụng phương thức [setFirstRow](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setFirstRow-boolean-) để đánh dấu hàng đầu tiên cho định dạng tiêu đề. Hiển thị của nó phụ thuộc vào kiểu bảng được áp dụng cho bảng.

1. Tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Truy cập slide đầu tiên.
3. Truy cập bảng được lưu làm hình dạng đầu tiên trên slide.
4. Bật định dạng tiêu đề cho hàng đầu tiên.
5. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ yêu cầu `table.pptx` có một bảng làm hình dạng đầu tiên trên slide đầu tiên. Nó bật định dạng tiêu đề cho hàng đầu tiên và lưu thành `First_row_header.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sao Chép Hàng Hoặc Cột Bảng**

Sao chép các hàng hoặc cột để tái sử dụng nội dung và định dạng của chúng. Bạn có thể thêm bản sao vào cuối bảng hoặc chèn vào một vị trí cụ thể.

1. Tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Truy cập slide đầu tiên.
3. Xác định độ rộng cột và chiều cao hàng.
4. Thêm bảng bằng phương thức [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
5. Sao chép các hàng cần thiết.
6. Sao chép các cột cần thiết.
7. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ yêu cầu `Test.pptx` có ít nhất một slide. Nó tạo một bảng với ba cột và năm hàng, các kích thước được xác định bằng điểm. Nó thêm bản sao của hàng và cột đầu tiên, sau đó chèn bản sao của hàng và cột thứ hai tại chỉ mục 3 (vị trí thứ tư). Bảng kết quả có bảy hàng và năm cột. Tham số `false` vô hiệu hoá việc sao chép vào các hàng hoặc cột hợp nhất liền kề; bảng này không có ô hợp nhất.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 50, 50, 50 };
    double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Xóa Hàng Hoặc Cột Khỏi Bảng**

Xóa các hàng hoặc cột không còn cần thiết trong bảng. Khi xóa một mục, các chỉ số của các hàng hoặc cột phía sau sẽ được dịch chuyển.

1. Tạo một bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Truy cập slide đầu tiên.
3. Xác định độ rộng cột và chiều cao hàng.
4. Thêm bảng bằng phương thức [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
5. Xóa hàng thứ hai và cột thứ hai.
6. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ này tạo một bảng ba‑by‑ba và xóa hàng và cột tại chỉ mục 1, để lại một bảng hai‑by‑hai trong `TestTable_out.pptx`. Các kích thước tính bằng điểm. Tham số `false` vô hiệu hoá việc xóa các hàng hoặc cột hợp nhất liền kề; bảng này không có ô hợp nhất.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 50, 30 };
    double[] rowHeights = new double[] { 30, 50, 30 };
    ITable table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt Định Dạng Văn Bản ở Cấp Độ Hàng Bảng**

Áp dụng định dạng văn bản cho toàn bộ một hàng để các ô của nó đồng nhất. Bạn có thể thiết lập thuộc tính phông chữ, định dạng đoạn văn và hướng văn bản mà không cần định dạng từng ô riêng lẻ.

1. Tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Truy cập bảng trên slide đầu tiên.
3. Sử dụng [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) cho hàng đầu tiên.
4. Sử dụng [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) và [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) cho hàng đầu tiên.
5. Sử dụng [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) cho hàng thứ hai.
6. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ yêu cầu `table.pptx` có một bảng làm hình dạng đầu tiên trên slide đầu tiên và ít nhất hai hàng. Nó áp dụng văn bản 25 point, căn phải và lề đoạn văn bên phải 20 point cho hàng đầu tiên, rồi đặt văn bản dọc cho hàng thứ hai.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt Định Dạng Văn Bản ở Cấp Độ Cột Bảng**

Áp dụng định dạng văn bản cho toàn bộ một cột để các ô của nó đồng nhất. Bạn có thể thiết lập thuộc tính phông chữ, định dạng đoạn văn và hướng văn bản mà không cần định dạng từng ô riêng lẻ.

1. Tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Truy cập bảng trên slide đầu tiên.
3. Sử dụng [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) cho cột đầu tiên.
4. Sử dụng [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) và [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) cho cột đầu tiên.
5. Sử dụng [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) cho cột thứ hai.
6. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ yêu cầu `table.pptx` có một bảng làm hình dạng đầu tiên trên slide đầu tiên và ít nhất hai cột. Nó áp dụng văn bản 25 point, căn phải và lề đoạn văn bên phải 20 point cho cột đầu tiên, rồi đặt văn bản dọc cho cột thứ hai.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lấy Thuộc Tính Kiểu Bảng**

Sử dụng phương thức [getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--) để lấy mẫu kiểu đã áp dụng cho một bảng và tái sử dụng nó cho bảng khác. Phương thức này xác định mẫu thay vì các ghi đè định dạng riêng lẻ của ô.

Ví dụ tạo một bảng, áp dụng [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/#DarkStyle1), và đọc lại mẫu. Nó in ra giá trị nguyên tương ứng với `DarkStyle1` và lưu bảng trong `table.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 150 };
    double[] rowHeights = new double[] { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println(stylePreset);

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu Hỏi Thường Gặp**

**Tôi có thể áp dụng chủ đề/kiểu PowerPoint cho một bảng đã tạo chưa?**

Có. Bảng sẽ kế thừa chủ đề slide/bố cục/màn hình chủ, và bạn vẫn có thể ghi đè màu nền, đường viền và màu chữ lên trên chủ đề đó.

**Tôi có thể sắp xếp các hàng bảng như trong Excel không?**

Không, các bảng Aspose.Slides không có tính năng sắp xếp hoặc lọc tích hợp. Hãy sắp xếp dữ liệu trong bộ nhớ trước, sau đó điền lại các hàng bảng theo thứ tự đó.

**Tôi có thể có các cột sọc (banded) trong khi giữ màu tùy chỉnh cho các ô riêng biệt không?**

Có. Bật cột sọc, rồi ghi đè các ô cụ thể bằng định dạng cục bộ; định dạng ở mức ô sẽ có ưu tiên hơn kiểu bảng.