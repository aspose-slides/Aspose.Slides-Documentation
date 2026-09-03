---
title: Quản lý các hộp văn bản trong bản trình bày bằng Java
linktitle: Quản lý Hộp Văn Bản
type: docs
weight: 20
url: /vi/java/manage-textbox/
keywords:
- hộp văn bản
- khung văn bản
- thêm văn bản
- cập nhật văn bản
- tạo hộp văn bản
- kiểm tra hộp văn bản
- thêm cột văn bản
- thêm siêu liên kết
- PowerPoint
- bản trình bày
- Java
- Aspose.Slides
description: "Tạo, xác định, định dạng và cập nhật các hộp văn bản trong các bản thuyết trình PowerPoint và OpenDocument bằng cách sử dụng Aspose.Slides cho Java."
---
## **Giới thiệu**

Trong Aspose.Slides for Java, văn bản của slide được lưu trong các khung văn bản thuộc về các shape. Giao diện [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) đại diện cho hình dạng chứa văn bản phổ biến nhất và cung cấp văn bản của nó thông qua phương thức [IAutoShape.getTextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/#getTextFrame--) .

{{% alert color="info" title="Note" %}}
Mỗi auto shape đều triển khai [IShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/), nhưng không phải mọi shape đều là auto shape hoặc hỗ trợ khung văn bản. Khi xử lý một bản trình bày hiện có, hãy kiểm tra xem một shape có triển khai [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) trước khi truy cập văn bản của nó.
{{% /alert %}}

## **Tạo một hộp văn bản trên slide**

Để tạo một hộp văn bản, thêm một auto shape vào slide, thêm văn bản vào khung văn bản của nó và lưu bản trình bày. Ví dụ sau tạo một hộp văn bản hình chữ nhật:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Các tọa độ và kích thước truyền cho [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) được đo bằng điểm. [IAutoShape.addTextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) khởi tạo khung văn bản với văn bản được cung cấp.

## **Kiểm tra hình dạng hộp văn bản**

Sử dụng phương thức [IAutoShape.isTextBox](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/#isTextBox--) để xác định liệu một auto shape có được coi là hộp văn bản hay không. Điều này hữu ích khi một bản trình bày chứa cả các auto shape chứa văn bản và các auto shape chỉ là đồ họa.

![Hộp văn bản và một shape](istextbox.png)

Ví dụ sau kiểm tra mọi auto shape trong một bản trình bày:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

    for (ISlide currentSlide : presentation.getSlides()) {
        for (IShape shape : currentSlide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                System.out.println(autoShape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Một auto shape mới thêm sẽ không được coi là hộp văn bản cho đến khi nó chứa văn bản không rỗng. Bạn có thể cung cấp văn bản đó qua [IAutoShape.addTextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) hoặc [ITextFrame.setText](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/#setText-java.lang.String-). Thêm hoặc gán một chuỗi rỗng sẽ khiến [IAutoShape.isTextBox](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/#isTextBox--) trả về `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    System.out.println(shape1.isTextBox());

    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    System.out.println(shape2.isTextBox());

    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    System.out.println(shape3.isTextBox());

    IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    System.out.println(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

Hai lời gọi đầu tiên in ra `true`; hai lời gọi cuối in ra `false`.

## **Tìm hình dạng sở hữu khung văn bản**

Mã xử lý văn bản chung có thể nhận một [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/) mà không biết đối tượng trình bày nào chứa nó. Sử dụng phương thức chỉ đọc [ITextFrame.getParentShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/#getParentShape--) để điều hướng trở lại [IShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/) sở hữu nó.

Đối với khung văn bản thuộc sở hữu của một auto shape hoặc một shape chứa văn bản khác, [ITextFrame.getParentShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/#getParentShape--) trả về chủ sở hữu và [ITextFrame.getParentCell](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/#getParentCell--) trả về `null`. Kiểm tra giá trị trả về trước khi truy cập. Để xác định cả chủ sở hữu shape và ô bảng, bao gồm các shape liên kết với nút SmartArt, xem [Search and Replace Text](/slides/vi/java/search-and-replace-text/).

## **Thêm cột vào hộp văn bản**

Phương thức [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/#setColumnCount-int-) chia khung văn bản thành các cột, trong khi [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) đặt khoảng cách giữa các cột bằng điểm. Cả hai thiết lập đều thuộc về [ITextFrameFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/) và có thể thay đổi thông qua khung văn bản của một hộp văn bản hiện có. Văn bản sẽ tái luồng giữa các cột trong cùng một shape; nó sẽ không tiếp tục sang shape khác.

Ví dụ sau tạo một hộp văn bản ba cột với 10 điểm giữa các cột, lưu bản trình bày và đọc lại các thiết lập đã lưu từ tệp đầu ra:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    ITextFrameFormat textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx);

    Presentation savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        IAutoShape savedTextBox = (IAutoShape) savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        ITextFrameFormat savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        System.out.println("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Trích xuất văn bản từ từng cột**

Sử dụng [ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/#splitTextByColumns--) để lấy văn bản được gán cho mỗi cột hiển thị trong một khung văn bản hiện có. Phương thức trả về một chuỗi cho mỗi cột, theo thứ tự đọc dựa trên cột. Một khung văn bản một cột tạo ra một mảng với một phần tử, và một cột trống được biểu diễn bằng một chuỗi rỗng. Các chuỗi chỉ chứa văn bản thuần; định dạng cấp phần không được bảo lưu.

Điều này hữu ích khi bạn cần:
- Trích xuất văn bản trong khi giữ nguyên thứ tự đọc dựa trên cột.
- Lập chỉ mục hoặc so sánh nội dung của các slide đa cột.
- Xuất mỗi cột ra một tệp riêng, trường cơ sở dữ liệu, hoặc đích khác.
- Kiểm tra cách văn bản được phân phối lại sau khi thay đổi số cột bằng [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/#setColumnCount-int-), khoảng cách bằng [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-), phông chữ, hoặc kích thước khung văn bản.

Phương thức báo cáo văn bản được phân phối trong [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/) hiện tại; nó không tự động chuyển văn bản giữa các shape hoặc hộp văn bản riêng biệt. Phân phối cột có thể phụ thuộc vào phông chữ có sẵn và các thiết lập bố cục văn bản khác, vì vậy hãy đảm bảo các phông chữ cần thiết có sẵn khi kết quả nhất quán là quan trọng.

Ví dụ sau tải một bản trình bày, tìm auto shape đa cột đầu tiên có khung văn bản, đọc số cột đã cấu hình và ghi văn bản từ mỗi cột ra một tệp riêng. Các shape không cung cấp khung văn bản sẽ bị bỏ qua.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("MultiColumnText.pptx");
try {
    IAutoShape textBox = null;
    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            if (autoShape.getTextFrame() != null) {
                int columnCount = autoShape.getTextFrame().getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = autoShape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        System.out.println("No multi-column text frame was found.");
    } else {
        ITextFrame textFrame = textBox.getTextFrame();
        int configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        String[] columnTexts = textFrame.splitTextByColumns();

        System.out.println("Configured columns: " + configuredColumnCount);

        for (int columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            int columnNumber = columnIndex + 1;
            String columnText = columnTexts[columnIndex];
            System.out.println("Column " + columnNumber + ": " + columnText);
            Path outputPath = Paths.get("Column-" + columnNumber + ".txt");
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try {
                Files.write(outputPath, textBytes);
            } catch (IOException exception) {
                System.out.println("Could not write column " + columnNumber + ": " + exception.getMessage());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Cập nhật văn bản**

Để cập nhật văn bản trên toàn bộ bản trình bày, lặp qua các slide và shape, chọn auto shape, sau đó chỉnh sửa các phần văn bản của chúng. Làm việc ở mức phần cho phép bạn thay đổi cả văn bản và định dạng ký tự.

Ví dụ sau thay thế mọi lần xuất hiện của `years` bằng `months` trong văn bản auto-shape và làm cho mỗi phần bị ảnh hưởng trở nên in đậm:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Text.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }

            IAutoShape autoShape = (IAutoShape) shape;
            ITextFrame textFrame = autoShape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    String text = portion.getText();
                    if (text != null && text.contains("years")) {
                        portion.setText(text.replace("years", "months"));
                        portion.getPortionFormat().setFontBold(NullableBool.True);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Quá trình duyệt này chỉ cập nhật văn bản trong auto shape. Văn bản lưu trong bảng, biểu đồ, SmartArt hoặc các shape được nhóm yêu cầu duyệt các bộ sưu tập riêng của các đối tượng đó.

## **Thêm một hộp văn bản với siêu liên kết**

Siêu liên kết có thể được gán cho một phần văn bản cụ thể, vì vậy chỉ phần văn bản đó hoạt động như liên kết có thể nhấp. Sử dụng [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) để liên kết phần đó với một URL bên ngoài.

Ví dụ sau tạo văn bản có liên kết và lưu nó vào một bản trình bày:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    IPortion textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Sự khác nhau giữa hộp văn bản và placeholder văn bản trên slide master hoặc layout là gì?**

Một [placeholder](/slides/vi/java/manage-placeholder/) có thể kế thừa vị trí và định dạng từ một [master slide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/masterslide/) hoặc [layout slide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/layoutslide/). Một hộp văn bản thường là một shape độc lập trên slide mà nó được tạo và không nhận hành vi placeholder khi layout thay đổi.

**Làm thế nào để thay thế văn bản mà không thay đổi văn bản trong biểu đồ, bảng hoặc SmartArt?**

Hạn chế việc duyệt chỉ đến các shape triển khai [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/), như trong ví dụ Cập nhật Văn bản. Biểu đồ, bảng và SmartArt lưu văn bản trong mô hình đối tượng riêng của chúng, vì vậy chúng không bị thay đổi bởi vòng lặp đó.