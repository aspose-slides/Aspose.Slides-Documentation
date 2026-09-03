---
title: Quản lý các hộp văn bản trong bản trình chiếu bằng JavaScript
linktitle: Quản lý Hộp Văn Bản
type: docs
weight: 20
url: /vi/nodejs-java/manage-textbox/
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
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tạo, xác định, định dạng và cập nhật các hộp văn bản trong bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Node.js qua Java."
---
## **Giới thiệu**

Trong Aspose.Slides cho Node.js qua Java, văn bản trên slide được lưu trong các khung văn bản thuộc về các hình dạng. Lớp [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) đại diện cho hình dạng chứa văn bản phổ biến nhất và cung cấp văn bản của nó thông qua phương thức [AutoShape.getTextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Note" %}}
Mỗi auto shape kế thừa từ [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/), nhưng không phải mọi shape đều là auto shape hoặc hỗ trợ khung văn bản. Khi xử lý một bản trình chiếu hiện có, hãy kiểm tra xem một shape có phải là một thể hiện của [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) trước khi truy cập văn bản của nó.
{{% /alert %}}

## **Tạo hộp văn bản trên một slide**

Để tạo một hộp văn bản, thêm một auto shape vào slide, thêm văn bản vào khung văn bản của nó và lưu bản trình chiếu. Ví dụ sau tạo một hộp văn bản hình chữ nhật:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Các tọa độ và kích thước truyền vào [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/#addAutoShape) được đo bằng điểm. [AutoShape.addTextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/#addTextFrame) khởi tạo khung văn bản với văn bản được cung cấp.

## **Kiểm tra hình dạng hộp văn bản**

Sử dụng phương thức [AutoShape.isTextBox](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/#isTextBox) để xác định xem một auto shape có được coi là hộp văn bản hay không. Điều này hữu ích khi một bản trình chiếu chứa cả các auto shape chứa văn bản và các auto shape chỉ là đồ họa thuần túy.

![Một hộp văn bản và một hình dạng](istextbox.png)

Ví dụ sau kiểm tra mọi auto shape trong một bản trình chiếu:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 150, 10, 40, 40);

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const currentSlide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < currentSlide.getShapes().size(); shapeIndex++) {
            const shape = currentSlide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                console.log(shape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Một auto shape mới được thêm vào sẽ không được coi là hộp văn bản cho đến khi nó chứa văn bản không rỗng. Bạn có thể cung cấp văn bản đó thông qua [AutoShape.addTextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/#addTextFrame) hoặc [TextFrame.setText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#setText). Thêm hoặc gán một chuỗi rỗng sẽ khiến [AutoShape.isTextBox](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/#isTextBox) trả về `false`:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    console.log(shape1.isTextBox());

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    console.log(shape2.isTextBox());

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    console.log(shape3.isTextBox());

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    console.log(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

Hai lời gọi đầu tiên in ra `true`; hai lời gọi cuối in ra `false`.

## **Tìm hình dạng sở hữu khung văn bản**

Mã xử lý văn bản tổng quát có thể nhận được một [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) mà không biết đối tượng bản trình chiếu nào chứa nó. Sử dụng phương thức chỉ đọc [TextFrame.getParentShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#getParentShape) để quay lại [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/) sở hữu nó.

Đối với một khung văn bản thuộc sở hữu của một auto shape hoặc một hình dạng chứa văn bản khác, [TextFrame.getParentShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#getParentShape) trả về chủ sở hữu và [TextFrame.getParentCell](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#getParentCell) trả về `null`. Kiểm tra giá trị trả về trước khi truy cập. Để xác định cả chủ sở hữu hình dạng và ô bảng, bao gồm các hình dạng liên quan tới nút SmartArt, xem mục [Search and Replace Text](/slides/vi/nodejs-java/search-and-replace-text/).

## **Thêm cột vào hộp văn bản**

Phương thức [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframeformat/#setColumnCount) chia khung văn bản thành các cột, trong khi [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing) đặt khoảng cách giữa các cột tính bằng điểm. Cả hai thiết lập đều thuộc về [TextFrameFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframeformat/) và có thể được thay đổi thông qua khung văn bản của một hộp văn bản hiện có. Văn bản sẽ được phân bố lại giữa các cột trong cùng một hình dạng; nó sẽ không tiếp tục sang một hình dạng khác.

Ví dụ sau tạo một hộp văn bản ba cột với khoảng cách 10 điểm giữa các cột, lưu bản trình chiếu và đọc lại các thiết lập đã lưu từ tệp đầu ra:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    const textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", aspose.slides.SaveFormat.Pptx);

    const savedPresentation = new aspose.slides.Presentation("TextBoxColumns.pptx");
    try {
        const savedTextBox = savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        console.log("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Trích xuất văn bản từ các cột riêng lẻ**

Sử dụng [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#splitTextByColumns) để lấy văn bản được gán cho mỗi cột hiển thị trong một khung văn bản hiện có. Phương thức trả về một chuỗi cho mỗi cột, theo thứ tự đọc dựa trên cột. Một khung văn bản một cột sẽ tạo ra một mảng với một phần tử, và một cột trống được biểu thị bằng một chuỗi rỗng. Các chuỗi chỉ chứa văn bản thuần; định dạng ở mức phần không được bảo tồn.

Điều này hữu ích khi bạn cần:

- Trích xuất văn bản đồng thời giữ nguyên thứ tự đọc dựa trên cột.
- Lập chỉ mục hoặc so sánh nội dung của các slide đa cột.
- Xuất mỗi cột ra một tệp riêng, trường cơ sở dữ liệu, hoặc đích khác.
- Kiểm tra cách văn bản được phân phối lại sau khi thay đổi số cột bằng [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframeformat/#setColumnCount), khoảng cách bằng [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing), phông chữ, hoặc kích thước khung văn bản.

Phương thức báo cáo văn bản được phân bố trong [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) hiện tại; nó không tự động di chuyển văn bản giữa các hình dạng hoặc hộp văn bản riêng biệt. Phân bố cột có thể phụ thuộc vào phông chữ có sẵn và các cài đặt bố cục văn bản khác, vì vậy hãy đảm bảo các phông chữ cần thiết có sẵn khi kết quả nhất quán là quan trọng.

Ví dụ sau tải một bản trình chiếu, tìm auto shape đa cột đầu tiên có khung văn bản, đọc số cột đã cấu hình và ghi văn bản từ mỗi cột ra một tệp riêng. Các hình dạng không cung cấp khung văn bản sẽ bị bỏ qua.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("MultiColumnText.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let textBox = null;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            const textFrame = shape.getTextFrame();
            if (textFrame != null) {
                const columnCount = textFrame.getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = shape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        console.log("No multi-column text frame was found.");
    } else {
        const textFrame = textBox.getTextFrame();
        const configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        const columnTexts = textFrame.splitTextByColumns();

        console.log("Configured columns: " + configuredColumnCount);

        for (let columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            const columnNumber = columnIndex + 1;
            const columnText = columnTexts[columnIndex];
            console.log("Column " + columnNumber + ": " + columnText);
            const outputPath = "Column-" + columnNumber + ".txt";
            try {
                fs.writeFileSync(outputPath, columnText, "utf8");
            } catch (error) {
                console.log("Could not write column " + columnNumber + ": " + error.message);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Cập nhật văn bản**

Để cập nhật văn bản trên toàn bộ bản trình chiếu, lặp qua các slide và shape, chọn các auto shape, sau đó chỉnh sửa các phần văn bản của chúng. Làm việc ở mức phần cho phép bạn thay đổi cả văn bản và định dạng ký tự.

Ví dụ sau thay thế mọi xuất hiện của `years` bằng `months` trong văn bản auto-shape và làm cho mỗi phần bị ảnh hưởng trở nên in đậm:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const fontBold = java.newByte(aspose.slides.NullableBool.True);
const presentation = new aspose.slides.Presentation("Text.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                continue;
            }

            const textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < textFrame.getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const text = portion.getText();
                    if (text != null && text.includes("years")) {
                        portion.setText(text.replace(/years/g, "months"));
                        portion.getPortionFormat().setFontBold(fontBold);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Quy trình này chỉ cập nhật văn bản trong các auto shape. Văn bản được lưu trong bảng, biểu đồ, SmartArt hoặc các shape nhóm yêu cầu duyệt qua các bộ sưu tập riêng của các đối tượng đó.

## **Thêm hộp văn bản có siêu liên kết**

Siêu liên kết có thể được gán cho một phần văn bản cụ thể, do đó chỉ phần văn bản đó hoạt động như liên kết có thể nhấp. Sử dụng [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) để liên kết phần đó với một URL bên ngoài.

Ví dụ sau tạo văn bản có liên kết và lưu nó vào một bản trình chiếu:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    const textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Khác biệt giữa hộp văn bản và trình giữ chỗ văn bản trên slide master hoặc layout là gì?**

Một [placeholder](/slides/vi/nodejs-java/manage-placeholder/) có thể kế thừa vị trí và định dạng từ một [master slide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslide/) hoặc [layout slide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/). Một hộp văn bản thông thường là một shape độc lập trên slide nơi nó được tạo và không nhận hành vi placeholder khi bố cục thay đổi.

**Làm sao tôi có thể thay thế văn bản mà không thay đổi văn bản trong biểu đồ, bảng hoặc SmartArt?**

Giới hạn việc duyệt chỉ các shape là thể hiện của [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/), như được mô tả trong ví dụ Cập nhật văn bản. Biểu đồ, bảng và SmartArt lưu văn bản trong mô hình đối tượng riêng của chúng, vì vậy chúng không bị thay đổi bởi vòng lặp đó.