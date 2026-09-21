---
title: Quản lý các trường văn bản trong bản trình chiếu PowerPoint trên Android
linktitle: Trường văn bản
type: docs
weight: 52
url: /vi/androidjava/text-fields/
keywords:
- trường văn bản
- văn bản tự động
- số slide
- ngày và giờ
- tiêu đề
- chân trang
- phần văn bản
- PowerPoint
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Tạo, kiểm tra, sửa đổi và xóa các trường văn bản trong bản trình chiếu PowerPoint bằng Aspose.Slides cho Android qua Java. Bảo tồn định dạng và xác minh các tệp PPTX và PPT đã lưu."
---
## **Tổng quan**

Một đoạn văn bản bao gồm các phần. Một [IPortion](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iportion/) thông thường chứa văn bản nguyên thủy; một phần trường còn có một [IField](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifield/) mà kiểu xác định một giá trị tự động cập nhật, chẳng hạn như số slide hoặc ngày tháng. Hai phần có thể hiển thị cùng ký tự trong khi chỉ một phần chứa trường.

Sử dụng [IPortion.getField](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iportion/#getField--) để phân biệt chúng: nó trả về `null` cho văn bản thường. [IPortion.addField](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) chuyển một phần hiện có thành trường. Giữ một nhãn và giá trị động của nó trong các phần riêng biệt để việc chuyển đổi giá trị không đồng thời thay thế nhãn.

Hướng dẫn này đề cập đến các trường trong văn bản, cách định dạng chúng và cách lưu chúng trong PPTX và PPT. Đối với khung văn bản và đoạn, xem mục [Manage Text](/slides/vi/androidjava/manage-text/).

## **Tạo trường số slide**

Ví dụ đầy đủ dưới đây tạo một hộp văn bản chứa nhãn nguyên thủy `Slide ` tiếp theo là một số tự động cập nhật. Nó đặt kích thước, độ đậm và màu của số trước khi thêm trường, sau đó mở lại bản trình chiếu đã lưu và kiểm tra kiểu trường, văn bản và định dạng. Không cần tệp đầu vào.

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    int numberColor = Color.rgb(0, 0, 139);
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
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor() == numberColor;

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

Bản trình chiếu mới bắt đầu với số slide 1, vì vậy văn bản là `Slide 1`, và cả hai kiểm tra đều in ra `true`. Số vẫn là một trường sau khi mở lại; nó không phải là văn bản nguyên thủy `1`. Các ép kiểu và chỉ mục trong phần xác minh tham chiếu đến shape và các phần được tạo bởi ví dụ này.

## **Chọn kiểu trường**

[FieldType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fieldtype/) triển khai [IFieldType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifieldtype/) và cung cấp các phương thức sau để lấy các giá trị được định trước. Gửi giá trị phù hợp tới [addField](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-).

| Phương thức | Mục đích |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fieldtype/#getSlideNumber--) | Số slide hiện tại. |
| [getDateTime](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fieldtype/#getDateTime--) | Ngày/giờ theo định dạng mặc định của ứng dụng render. |
| [getDateTime1](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fieldtype/#getDateTime9--) | Các định dạng ngày hoặc ngày/giờ kết hợp được định trước. |
| [getDateTime10](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fieldtype/#getDateTime13--) | Các định dạng thời gian được định trước, có tùy chọn hiển thị giây và đồng hồ 12 giờ. |
| [getHeader](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fieldtype/#getHeader--) | Trường tiêu đề; xem các giới hạn placeholder và định dạng bên dưới. |
| [getFooter](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fieldtype/#getFooter--) | Trường chân trang. |

Ví dụ, [getDateTime3](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fieldtype/#getDateTime3--) đại diện cho ngày, tên tháng đầy đủ và năm bằng tiếng Anh. Đây là các định dạng trường được định trước, không phải chuỗi định dạng ngày Java tùy ý. Ngôn ngữ được đặt bằng [setLanguageId](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) và ứng dụng xử lý bản trình chiếu có thể ảnh hưởng đến kết quả hiển thị.

## **Tạo trường từ chuỗi nội bộ**

Phủ định dạng chuỗi của [addField](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iportion/#addField-java.lang.String-) chấp nhận một định danh trường nội bộ. Sử dụng nó khi muốn bảo toàn một định danh do ứng dụng khác cung cấp mà không có giá trị được định trước. Bạn cũng có thể xây dựng một [FieldType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) từ định danh đó. [IFieldType.getInternalString](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifieldtype/#getInternalString--) cung cấp định danh để kiểm tra.

Ví dụ này lưu trữ một trường `custom-report-id` đặc thù của ứng dụng với văn bản dự phòng `Report-042`. Định danh này không đăng ký phép tính: Aspose.Slides không tạo ID báo cáo cho loại không xác định. Ứng dụng hiểu định danh này phải cung cấp ý nghĩa và cập nhật giá trị của nó.

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

Sau vòng quay PPTX, kiểu trường là `custom-report-id` và văn bản là `Report-042`. Việc truyền một chuỗi như `yyyy-MM-dd` sẽ tạo một kiểu trường; nó sẽ không cấu hình định dạng ngày tùy chỉnh. Đối với một ngày cố định ở định dạng bất kỳ, hãy dùng văn bản thường.

## **Kiểm tra, sửa đổi và xóa trường ngày/giờ**

Thay đổi một trường hiện có bằng [IField.setType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-). Kiểm tra trường tồn tại trước khi truy cập kiểu của nó. Để dừng việc tự động cập nhật, gọi [IPortion.removeField](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iportion/#removeField--). Thao tác này giữ lại phần và văn bản hiện tại trong khi xóa liên kết với trường. Nếu bạn cần một giá trị cố định cụ thể, gán văn bản đó sau khi xóa trường.

Đối với cài đặt API liên quan đến xử lý trường ngày/giờ, xem [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-). Ví dụ dưới đây sử dụng ngày phê duyệt cụ thể khi chuyển một trường thành văn bản thường.

Tải [sample.pptx](sample.pptx) và đặt nó trong thư mục làm việc. Tệp chứa hai shape văn bản có tên, `UpdatedAt` và `ApprovedDate`, mỗi shape có một trường ngày/giờ, cùng với các nhãn văn bản thường. Ví dụ sau duyệt các shape văn bản cấp cao trên các slide bình thường. Nó thay đổi trường ngày/giờ thành định dạng ngày dài và in nghiêng, đồng thời giữ các định dạng khác. Chỉ các trường trong `ApprovedDate` sẽ trở thành văn bản cố định.

Các định danh nội bộ được tích hợp `datetime` và `datetime1` tới `datetime13` được nhận dạng. Nhóm, bảng, ghi chú, bố cục và master yêu cầu duyệt các container văn bản riêng và nằm ngoài phạm vi ví dụ này.

```java
import java.util.Calendar;
import java.text.SimpleDateFormat;
import java.util.Locale;
import java.util.Date;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    Calendar approvalDate = Calendar.getInstance();
    approvalDate.clear();
    approvalDate.set(2030, Calendar.APRIL, 5);
    SimpleDateFormat dateFormat = new SimpleDateFormat("dd MMMM yyyy", Locale.US);

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
                        Date dateValue = approvalDate.getTime();
                        String fixedDate = dateFormat.format(dateValue);
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

Sau khi mở lại, `UpdatedAt` có kiểu `datetime3` và vẫn động. `ApprovedDate` không còn trường và chứa `05 April 2030`. Cả hai phần ngày đều in nghiêng, và kích thước phông chữ, thiết lập đậm và màu gốc vẫn giữ nguyên. Các nhãn văn bản thường không thay đổi. Phần xác minh đọc phần đầu tiên của hai shape đã biết trong mẫu cung cấp.

## **Bảo tồn định dạng văn bản**

Làm việc với phần hiện có khi thêm trường, thay đổi kiểu hoặc xóa nó. Các thao tác này giữ lại định dạng của phần đó. Sử dụng [IPortion.getPortionFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iportion/#getPortionFormat--) để thay đổi chỉ những thuộc tính cần thiết, như các ví dụ về màu hoặc in nghiêng.

Tránh xây dựng lại toàn bộ khung văn bản chỉ để cập nhật một trường: việc này có thể làm mất ranh giới phần gốc và định dạng riêng của chúng. Ngoài ra, phân biệt định dạng được thiết lập một cách rõ ràng với định dạng kế thừa từ đoạn, bố cục hoặc theme. Xem mục [Text Formatting](/slides/vi/androidjava/text-formatting/) để biết các tùy chọn định dạng rộng hơn.

## **Trường và các placeholder tiêu đề/chân trang**

Một trường là một phần của đoạn văn bản. Một placeholder là một shape có vai trò trong bản trình chiếu, chẳng hạn như chân trang hoặc số slide. Thêm một trường vào hộp văn bản thường không biến shape đó thành placeholder.

Các trình quản lý tiêu đề/chân trang kiểm soát văn bản placeholder và khả năng hiển thị trên slide, layout và master, bao gồm việc lan truyền tới các slide phụ thuộc. Vì vậy, một trường số trong hộp văn bản tùy chỉnh vẫn hữu ích ngay cả khi bạn không sử dụng placeholder số slide. Ngược lại, việc thay đổi hiển thị placeholder không xóa trường khỏi hộp văn bản không liên quan.

Các kiểu tiêu đề và chân trang được định trước không tạo ra các placeholder tương ứng hay cung cấp nội dung cho chúng. Cụ thể, một slide PowerPoint thông thường không có placeholder tiêu đề; tiêu đề thuộc về trang ghi chú và tài liệu phát tay. Đừng giả định rằng một trường tiêu đề hoặc chân trang trong một shape bất kỳ sẽ tự động nhận được văn bản được cấu hình qua trình quản lý placeholder. Đối với quy trình đó, xem mục [Presentation Headers and Footers](/slides/vi/androidjava/presentation-header-and-footer/).

## **Giới hạn PPTX và PPT**

Kiểm tra cả kiểu trường và văn bản kết quả sau khi lưu và mở lại. Bảo toàn một định danh không có nghĩa là ứng dụng có thể tính toán hoặc hiển thị giá trị của nó.

| Định dạng | Hành vi và giới hạn của trường |
|---|---|
| PPTX | Lưu trữ định danh trường nội bộ cùng với văn bản trường. Trong các kiểm tra vòng quay, các kiểu được định trước và định danh tuỳ chỉnh đã dùng ở trên vẫn tồn tại sau khi lưu và mở lại. Kiểu tuỳ chỉnh không biết trước giữ lại văn bản dự phòng; nó không có logic tính tự động. Ứng dụng khác có thể xử lý các định danh không hỗ trợ khác nhau. |
| PPT | Sử dụng đại diện trường legacy và có khả năng tương thích hạn chế hơn. Trong các kiểm tra vòng quay, trường số slide và các trường ngày/giờ được định trước vẫn tồn tại sau khi lưu và mở lại. Một trường tuỳ chỉnh trong hộp văn bản slide thường mở lại với định danh nhưng văn bản là `*`; một trường tiêu đề trong cùng ngữ cảnh cũng cho ra `*`. Đừng dựa vào việc các trường tuỳ chỉnh hoặc ngữ cảnh trường không được hỗ trợ sẽ giữ lại văn bản hiển thị. |

Đối với đầu ra cố định, di chuyển các trường không được hỗ trợ thành văn bản thường và gán giá trị mong muốn trước khi lưu. Điều này giữ lại văn bản đã chọn nhưng cố tình ngừng cập nhật tự động. Hãy kiểm tra ứng dụng đích khi việc tính lại trường của nó là một phần của quy trình làm việc.

## **Câu hỏi thường gặp**

**Làm sao tôi biết một số hoặc ngày hiển thị có phải là trường không?**

Kiểm tra [IPortion.getField](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iportion/#getField--). Giá trị khác `null` xác định một trường; chỉ nhìn vào văn bản hiển thị không đủ.

**Việc xóa trường có xóa cả văn bản hoặc định dạng không?**

Không. [removeField](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iportion/#removeField--) chuyển phần hiện có thành văn bản thường. Gán một giá trị cụ thể sau đó nếu bạn cần một ngày cố định hoặc văn bản dự phòng.

**Chuỗi nội bộ có thể định nghĩa một định dạng ngày mới hoặc công thức không?**

Không. Nó chỉ xác định một kiểu trường. Một định danh không biết trước không cung cấp bộ đánh giá hay mẫu định dạng ngày Java. Hãy dùng kiểu được hỗ trợ hoặc tự định dạng giá trị thành văn bản thường.

**Tại sao phải kiểm tra lại bản trình chiếu sau khi lưu?**

Định danh trường, văn bản đã tính và định dạng là các yếu tố riêng biệt cần xác minh. Việc chuyển đổi định dạng có thể thay đổi kết quả hiển thị ngay khi định danh trường vẫn còn.