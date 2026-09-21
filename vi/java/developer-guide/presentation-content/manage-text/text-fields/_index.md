---
title: Quản lý Trường Văn bản trong Bài thuyết trình PowerPoint bằng Java
linktitle: Trường Văn bản
type: docs
weight: 52
url: /vi/java/text-fields/
keywords:
- trường văn bản
- văn bản tự động
- số slide
- ngày và giờ
- đầu trang
- chân trang
- phần văn bản
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Tạo, kiểm tra, sửa đổi và xóa các trường văn bản trong bài thuyết trình PowerPoint bằng Aspose.Slides cho Java. Bảo tồn định dạng và xác minh các tệp PPTX và PPT đã lưu."
---
## **Tổng quan**

Một đoạn văn bản bao gồm các phần. Một [IPortion] thông thường chứa văn bản nguyên thủy; một phần trường cũng có một [IField] mà loại của nó xác định một giá trị được cập nhật tự động, chẳng hạn như số slide hoặc ngày tháng. Hai phần có thể hiển thị cùng các ký tự trong khi chỉ một phần chứa trường.

Sử dụng [IPortion.getField](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iportion/#getField--) để phân biệt chúng: giá trị sẽ là `null` đối với văn bản thông thường. [IPortion.addField](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) chuyển một phần đã tồn tại thành trường. Giữ nhãn và giá trị động của nó trong các phần riêng biệt để việc chuyển đổi giá trị không thay thế cả nhãn.

Hướng dẫn này đề cập đến các trường trong văn bản, cách định dạng chúng và cách lưu chúng trong PPTX và PPT. Đối với khung văn bản và đoạn, xem [Manage Text](/slides/vi/java/manage-text/).

## **Tạo Trường Số Slide**

Ví dụ đầy đủ sau tạo một hộp văn bản chứa nhãn nguyên thủy `Slide ` theo sau là một số được cập nhật tự động. Nó đặt kích thước, độ đậm và màu của số trước khi thêm trường, sau đó mở lại bản trình chiếu đã lưu và kiểm tra loại trường, văn bản và định dạng. Không cần tệp đầu vào.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    Color numberColor = new Color(0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(NullableBool.True);
    numberPortion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("slide_number.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        IField savedField = savedNumber.getField();
        boolean hasNumberField = savedField != null && FieldType.getSlideNumber().getInternalString().equals(savedField.getType().getInternalString());
        IPortionFormat format = savedNumber.getPortionFormat();
        boolean formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == NullableBool.True;
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        System.out.println("Text: " + savedShape.getTextFrame().getText());
        System.out.println("Slide number field: " + hasNumberField);
        System.out.println("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Bản trình chiếu mới bắt đầu với số slide 1, vì vậy văn bản là `Slide 1`, và cả hai kiểm tra đều in `true`. Số vẫn là một trường sau khi mở lại; nó không phải là một ký tự nguyên thủy `1`. Các phép ép kiểu và chỉ mục trong việc xác minh đề cập đến hình dạng và các phần được tạo bởi ví dụ này.

## **Chọn Kiểu Trường**

[FieldType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fieldtype/) thực thi [IFieldType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifieldtype/) và cung cấp các phương thức sau để lấy các giá trị đã được định nghĩa trước. Gửi giá trị phù hợp tới [addField](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-).

| Phương thức | Mục đích |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fieldtype/#getSlideNumber--) | Số slide hiện tại. |
| [getDateTime](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fieldtype/#getDateTime--) | Ngày/giờ theo định dạng mặc định của ứng dụng render. |
| [getDateTime1](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fieldtype/#getDateTime9--) | Định dạng ngày hoặc ngày/giờ kết hợp đã được định nghĩa trước. |
| [getDateTime10](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fieldtype/#getDateTime13--) | Định dạng thời gian đã được định nghĩa trước, kèm tùy chọn giây và đồng hồ 12 giờ. |
| [getHeader](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fieldtype/#getHeader--) | Trường tiêu đề; xem các giới hạn về trình giữ chỗ và định dạng bên dưới. |
| [getFooter](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fieldtype/#getFooter--) | Trường chân trang. |

Ví dụ, [getDateTime3](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fieldtype/#getDateTime3--) đại diện cho ngày, tên tháng đầy đủ và năm bằng tiếng Anh. Đây là các định dạng trường đã được định nghĩa trước, không phải chuỗi định dạng ngày Java tùy ý. Ngôn ngữ được thiết lập bằng [setLanguageId](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) và ứng dụng xử lý bản trình chiếu có thể ảnh hưởng đến kết quả hiển thị.

## **Tạo Trường từ Chuỗi Nội Bộ**

Phiên bản nhận chuỗi của [addField](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iportion/#addField-java.lang.String-) chấp nhận một định danh trường nội bộ. Sử dụng nó khi muốn bảo tồn định danh được cung cấp bởi một ứng dụng khác mà không có giá trị đã được định nghĩa trước. Bạn cũng có thể tạo một [FieldType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) từ định danh đó. [IFieldType.getInternalString](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifieldtype/#getInternalString--) cung cấp định danh để kiểm tra.

Ví dụ này lưu một trường `custom-report-id` đặc thù của ứng dụng với văn bản dự phòng `Report-042`. Định danh không đăng ký phép tính: Aspose.Slides không tạo ID báo cáo cho loại không xác định. Ứng dụng hiểu định danh này phải cung cấp ý nghĩa và cập nhật giá trị của nó.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom_field.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        IField savedField = savedPortion.getField();
        String typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        System.out.println("Type: " + typeName);
        System.out.println("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Sau vòng quay PPTX này, kiểu là `custom-report-id` và văn bản là `Report-042`. Gửi một chuỗi như `yyyy-MM-dd` sẽ đặt tên cho một kiểu trường; nó sẽ không cấu hình định dạng ngày tùy chỉnh. Đối với một ngày cố định ở định dạng tùy ý, hãy sử dụng văn bản thông thường.

## **Kiểm Tra, Sửa Đổi và Xóa Trường Ngày/Giờ**

Thay đổi một trường hiện có thông qua [IField.setType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-). Kiểm tra trường tồn tại trước khi truy cập kiểu của nó. Để dừng cập nhật tự động, gọi [IPortion.removeField](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iportion/#removeField--). Thao tác này giữ phần và văn bản hiện tại trong khi loại bỏ liên kết trường. Nếu bạn cần một giá trị cố định cụ thể, gán văn bản đó sau khi xóa trường.

Đối với thiết lập API liên quan đến xử lý trường ngày/giờ, xem [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-). Ví dụ dưới đây sử dụng ngày phê duyệt rõ ràng khi chuyển một trường thành văn bản thông thường.

Tải xuống [sample.pptx](sample.pptx) và đặt nó vào thư mục làm việc. Nó chứa hai hình dạng văn bản có tên, `UpdatedAt` và `ApprovedDate`, mỗi hình dạng có một trường ngày/giờ, cộng với các nhãn văn bản thông thường. Ví dụ sau đây duyệt các hình dạng văn bản cấp cao trên các slide bình thường. Nó thay đổi các trường ngày/giờ thành định dạng ngày dài và làm chúng in nghiêng, trong khi giữ các định dạng khác của chúng. Chỉ các trường trong `ApprovedDate` trở thành văn bản cố định.

Mẫu nhận diện các định danh nội bộ tích hợp `datetime` và `datetime1` đến `datetime13`. Các nhóm, bảng, ghi chú, bố cục và mẫu yêu cầu duyệt các container văn bản riêng của chúng và nằm ngoài phạm vi ví dụ này.

```java
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Locale;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    LocalDate approvalDate = LocalDate.of(2030, 4, 5);
    DateTimeFormatter dateFormat = DateTimeFormatter.ofPattern("dd MMMM yyyy", Locale.US);

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }

            for (IParagraph paragraph : textShape.getTextFrame().getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    IField field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    String typeName = field.getType().getInternalString();
                    boolean isDateTime = typeName != null && typeName.matches("datetime([1-9]|1[0-3])?");
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(NullableBool.True);

                    if ("ApprovedDate".equals(textShape.getName())) {
                        portion.removeField();
                        String fixedDate = approvalDate.format(dateFormat);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("updated_dates.pptx");
    try {
        for (IShape shape : reopened.getSlides().get_Item(0).getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }
            if (!"UpdatedAt".equals(textShape.getName()) && !"ApprovedDate".equals(textShape.getName())) {
                continue;
            }

            IPortion portion = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            IField field = portion.getField();
            String typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            System.out.println(textShape.getName() + ": " + typeName + "; " + portion.getText());
            System.out.println("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Sau khi mở lại, `UpdatedAt` có kiểu `datetime3` và vẫn động. `ApprovedDate` không có trường và chứa `05 April 2030`. Cả hai phần ngày đều in nghiêng, và kích thước phông chữ, thiết lập đậm và màu gốc của chúng vẫn giữ nguyên. Các nhãn văn bản thông thường không thay đổi. Việc xác minh đọc phần đầu tiên của hai hình dạng đã biết trong mẫu được cung cấp.

## **Bảo Vệ Định Dạng Văn Bản**

Làm việc với phần hiện có khi thêm trường, thay đổi kiểu hoặc xóa nó. Những thao tác này giữ lại định dạng của phần đó. Sử dụng [IPortion.getPortionFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iportion/#getPortionFormat--) để thay đổi chỉ các thuộc tính cần thiết, như các ví dụ làm màu hoặc in nghiêng.

Tránh xây dựng lại toàn bộ khung văn bản chỉ để cập nhật một trường: việc này có thể làm mất ranh giới phần gốc và định dạng riêng của chúng. Cũng cần phân biệt định dạng được đặt một cách rõ ràng với định dạng được kế thừa từ đoạn, bố cục hoặc chủ đề. Xem [Text Formatting](/slides/vi/java/text-formatting/) để biết các tùy chọn định dạng rộng hơn.

## **Trường và Trình Giữ Chỗ Đầu/Cuối Trang**

Một trường là một phần của đoạn văn bản. Một trình giữ chỗ là một hình dạng có vai trò trong bản trình chiếu, chẳng hạn như chân trang hoặc số slide. Thêm một trường vào hộp văn bản thông thường không biến hình dạng đó thành trình giữ chỗ.

Các quản lý đầu/chân trang kiểm soát văn bản và tính hiển thị của trình giữ chỗ trên slide, bố cục và mẫu, bao gồm việc lan truyền tới các slide phụ thuộc. Vì vậy, một trường số trong hộp văn bản tùy chỉnh vẫn hữu ích ngay cả khi bạn không sử dụng trình giữ chỗ số slide. Ngược lại, việc thay đổi tính hiển thị của trình giữ chỗ không xóa trường khỏi một hộp văn bản không liên quan.

Các kiểu đầu và chân trang được định nghĩa trước không tạo ra các trình giữ chỗ tương ứng hoặc cung cấp nội dung cho chúng. Đặc biệt, một slide PowerPoint thông thường không có trình giữ chỗ đầu; các đầu thuộc về trang ghi chú và tài liệu phát tay. Đừng cho rằng một trường đầu hoặc chân trang trong một hình dạng bất kỳ sẽ tự động nhận văn bản được cấu hình qua trình quản lý trình giữ chỗ. Đối với quy trình đó, xem [Presentation Headers and Footers](/slides/vi/java/presentation-header-and-footer/).

## **Giới Hạn của PPTX và PPT**

Kiểm tra cả kiểu trường và văn bản kết quả sau khi lưu và mở lại. Bảo tồn một định danh không chứng minh rằng ứng dụng có thể tính toán hoặc hiển thị giá trị của nó.

| Định Dạng | Hành vi và giới hạn của trường |
|---|---|
| PPTX | Lưu các định danh trường nội bộ cùng với văn bản trường. Trong các kiểm tra vòng quay, các kiểu đã định nghĩa trước và định danh tùy chỉnh được sử dụng ở trên vẫn tồn tại sau khi lưu và mở lại. Kiểu tùy chỉnh không biết vẫn giữ văn bản dự phòng; nó không nhận được logic tính toán tự động. Ứng dụng khác có thể xử lý các định danh không hỗ trợ theo cách khác. |
| PPT | Sử dụng biểu diễn trường legacy và có khả năng tương thích hạn chế hơn. Trong các kiểm tra vòng quay, các trường số slide và ngày/giờ đã định nghĩa trước vẫn tồn tại sau khi lưu và mở lại. Một trường tùy chỉnh trong hộp văn bản slide thông thường mở lại với định danh nhưng văn bản là `*`; một trường đầu trong cùng ngữ cảnh cũng tạo ra `*`. Đừng dựa vào việc các trường tùy chỉnh hoặc ngữ cảnh trường không được hỗ trợ giữ được văn bản hiển thị. |

Đối với đầu ra cố định, di chuyển các trường không được hỗ trợ thành văn bản thông thường và gán giá trị mong muốn trước khi lưu. Điều này giữ lại văn bản đã chọn nhưng ngăn chặn cập nhật tự động. Cũng hãy kiểm tra ứng dụng đích khi việc tái tính toán trường là một phần trong quy trình của bạn.

## **Câu Hỏi Thường Gặp**

**Làm sao tôi biết một số hoặc ngày hiển thị là trường?**

Kiểm tra [IPortion.getField](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iportion/#getField--). Giá trị không null xác định là một trường; chỉ dựa vào văn bản hiển thị không đủ.

**Việc xóa trường có xóa cả văn bản hoặc định dạng của nó không?**

Không. [removeField](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iportion/#removeField--) chuyển phần hiện có thành văn bản thông thường. Gán một giá trị cụ thể sau đó nếu bạn cần một ngày cố định hoặc văn bản dự phòng.

**Một chuỗi nội bộ có thể định nghĩa định dạng ngày mới hoặc công thức không?**

Không. Nó chỉ xác định một kiểu trường. Định danh không biết không cung cấp bộ đánh giá hoặc mẫu định dạng ngày Java. Sử dụng một kiểu đã được hỗ trợ hoặc tự định dạng giá trị dưới dạng văn bản thông thường.

**Tại sao phải kiểm tra lại bản trình chiếu sau khi lưu?**

Các định danh trường, văn bản đã tính và định dạng là các yếu tố riêng biệt cần xác minh. Việc chuyển đổi định dạng có thể thay đổi kết quả hiển thị ngay cả khi định danh trường vẫn còn.