---
title: Quản lý Hộp Văn Bản trong Bản Trình Chiếu bằng JavaScript
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
description: "Aspose.Slides cho Node.js giúp dễ dàng tạo, chỉnh sửa và sao chép hộp văn bản trong các tệp PowerPoint và OpenDocument, nâng cao khả năng tự động hóa bản trình chiếu của bạn."
---
## **Giới thiệu**

Văn bản trên các slide thường nằm trong các hộp văn bản hoặc hình dạng. Do đó, để thêm văn bản vào một slide, bạn phải thêm một hộp văn bản và sau đó đặt một số văn bản bên trong hộp văn bản. Aspose.Slides cho Node.js qua Java cung cấp lớp [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/AutoShape) cho phép bạn thêm một hình dạng chứa một số văn bản.

{{% alert title="Info" color="info" %}}
Aspose.Slides cũng cung cấp lớp [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape) cho phép bạn thêm các hình dạng vào slide. Tuy nhiên, không phải tất cả các hình dạng được thêm qua lớp `Shape` đều có thể chứa văn bản. Nhưng các hình dạng được thêm qua lớp [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/AutoShape) có thể chứa văn bản.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Do đó, khi làm việc với một hình dạng mà bạn muốn thêm văn bản, bạn có thể muốn kiểm tra và xác nhận rằng nó đã được ép kiểu qua lớp `AutoShape`. Chỉ khi đó bạn mới có thể làm việc với [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TextFrame), một thuộc tính của `AutoShape`. Xem phần [Update Text](https://docs.aspose.com/slides/vi/nodejs-java/manage-textbox/#update-text) trên trang này.
{{% /alert %}}

## **Tạo Hộp Văn Bản trên Slide**

Để tạo một hộp văn bản trên slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2. Lấy tham chiếu tới slide đầu tiên trong bản thuyết trình mới tạo.
3. Thêm một đối tượng [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/AutoShape) với [ShapeType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-) được đặt là `Rectangle` tại vị trí xác định trên slide và lấy tham chiếu tới đối tượng `AutoShape` vừa được thêm.
4. Thêm thuộc tính `TextFrame` vào đối tượng `AutoShape` sẽ chứa văn bản. Trong ví dụ dưới đây, chúng tôi đã thêm văn bản này: *Aspose TextBox*
5. Cuối cùng, ghi tệp PPTX thông qua đối tượng `Presentation`.

Mã JavaScript này—một triển khai các bước trên—cho bạn thấy cách thêm văn bản vào một slide:

```javascript
// Khởi tạo Presentation
var pres = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên trong bản trình chiếu
    var sld = pres.getSlides().get_Item(0);
    // Thêm AutoShape với loại được đặt là Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Thêm TextFrame vào Rectangle
    ashp.addTextFrame(" ");
    // Truy cập khung văn bản
    var txtFrame = ashp.getTextFrame();
    // Tạo đối tượng Paragraph cho khung văn bản
    var para = txtFrame.getParagraphs().get_Item(0);
    // Tạo đối tượng Portion cho đoạn văn
    var portion = para.getPortions().get_Item(0);
    // Đặt văn bản
    portion.setText("Aspose TextBox");
    // Lưu bản trình chiếu vào đĩa
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Kiểm tra Hình Hộp Văn Bản**

Aspose.Slides cung cấp phương thức [isTextBox](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/#isTextBox) từ lớp [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) cho phép bạn kiểm tra các hình dạng và xác định hộp văn bản.

![Hộp văn bản và hình dạng](istextbox.png)

Mã JavaScript này cho bạn thấy cách kiểm tra xem một hình dạng có được tạo thành hộp văn bản hay không:

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    java.callStaticMethodSync("ForEach", "shape", presentation, (shape, slide, index) -> {
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var autoShape = shape;
            console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

Lưu ý rằng nếu bạn chỉ thêm một autoshape bằng phương thức `addAutoShape` từ lớp [ShapeCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/), phương thức `isTextBox` của autoshape sẽ trả về `false`. Tuy nhiên, sau khi bạn thêm văn bản vào autoshape bằng phương thức `addTextFrame` hoặc phương thức `setText`, thuộc tính `isTextBox` sẽ trả về `true`.

```javascript
var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() trả về false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() trả về true

var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() trả về false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() trả về true

var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() trả về false
shape3.addTextFrame("");
// shape3.isTextBox() trả về false

var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() trả về false
shape4.getTextFrame().setText("");
// shape4.isTextBox() trả về false
```

## **Thêm Cột Trong Hộp Văn Bản**

Aspose.Slides cung cấp các phương thức [setColumnCount](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) và [setColumnSpacing](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TextFrameFormat) cho phép bạn thêm cột vào hộp văn bản. Bạn có thể chỉ định số cột trong một hộp văn bản và đặt khoảng cách giữa các cột tính bằng điểm.

Mã JavaScript này minh họa hoạt động trên:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên trong bản trình chiếu
    var slide = pres.getSlides().get_Item(0);
    // Thêm AutoShape với loại được đặt là Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Thêm TextFrame vào Rectangle
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!"));
    // Lấy định dạng văn bản của TextFrame
    var format = aShape.getTextFrame().getTextFrameFormat();
    // Xác định số cột trong TextFrame
    format.setColumnCount(3);
    // Xác định khoảng cách giữa các cột
    format.setColumnSpacing(10);
    // Lưu bản trình chiếu
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Thêm Cột Trong Khung Văn Bản**

Aspose.Slides cho Node.js qua Java cung cấp phương thức [setColumnCount](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TextFrameFormat) cho phép bạn thêm cột trong khung văn bản. Thông qua thuộc tính này, bạn có thể chỉ định số lượng cột mong muốn trong một khung văn bản.

Mã JavaScript này cho bạn thấy cách thêm một cột bên trong khung văn bản:

```javascript
var outPptxFileName = "ColumnsTest.pptx";
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    var format = shape1.getTextFrame().getTextFrameFormat();
    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " + "you can add or delete text - and the new or remaining text automatically adjusts " + "itself to stay within the container. You cannot have text spill over from one container " + "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test.getSlides().get_Item(0).getShapes().get_Item(0);
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", java.getStaticFieldValue("java.lang.Double", "NaN") == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) {
            test.dispose();
        }
    }
    format.setColumnSpacing(20);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test1 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test1.getSlides().get_Item(0).getShapes().get_Item(0);
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) {
            test1.dispose();
        }
    }
    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test2 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test2.getSlides().get_Item(0).getShapes().get_Item(0);
        java.callStaticMethodSync("Assert", "assertTrue", 3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) {
            test2.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Cập Nhật Văn Bản**

Aspose.Slides cho phép bạn thay đổi hoặc cập nhật văn bản chứa trong một hộp văn bản hoặc tất cả các văn bản trong một bản thuyết trình.

Mã JavaScript này minh họa một thao tác mà trong đó tất cả các văn bản trong bản thuyết trình được cập nhật hoặc thay đổi:

```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Kiểm tra xem hình dạng có hỗ trợ khung văn bản (IAutoShape) hay không.
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // Duyệt qua các đoạn trong khung văn bản
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // Duyệt qua từng phần trong đoạn văn
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// Thay đổi văn bản
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Thay đổi định dạng
                    }
                }
            }
        }
    }
    // Lưu bản trình chiếu đã chỉnh sửa
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Thêm Hộp Văn Bản với Liên Kết** 

Bạn có thể chèn một liên kết bên trong hộp văn bản. Khi hộp văn bản được nhấp, người dùng sẽ được chuyển đến mở liên kết.

Để thêm một hộp văn bản chứa liên kết, thực hiện các bước sau:

1. Tạo một thể hiện của lớp `Presentation`.
2. Lấy tham chiếu tới slide đầu tiên trong bản thuyết trình mới tạo.
3. Thêm một đối tượng `AutoShape` với `ShapeType` được đặt là `Rectangle` tại vị trí xác định trên slide và lấy tham chiếu của đối tượng AutoShape vừa được thêm.
4. Thêm một `TextFrame` vào đối tượng `AutoShape` chứa *Aspose TextBox* làm văn bản mặc định.
5. Khởi tạo lớp `HyperlinkManager`.
6. Gán đối tượng `HyperlinkManager` vào thuộc tính [HyperlinkClick](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape#getHyperlinkClick--) liên quan đến phần bạn muốn trong `TextFrame`.
7. Cuối cùng, ghi tệp PPTX thông qua đối tượng `Presentation`.

Mã JavaScript này—một triển khai các bước trên—cho bạn thấy cách thêm một hộp văn bản có siêu liên kết vào slide:

```javascript
// Khởi tạo một lớp Presentation đại diện cho file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên trong bản trình chiếu
    var slide = pres.getSlides().get_Item(0);
    // Thêm một đối tượng AutoShape với loại được đặt là Rectangle
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // Ép kiểu hình dạng thành AutoShape
    var pptxAutoShape = shape;
    // Truy cập thuộc tính ITextFrame liên kết với AutoShape
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // Thêm một số văn bản vào khung
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // Đặt Hyperlink cho văn bản phần
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // Lưu bản trình chiếu PPTX
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu Hỏi Thường Gặp**

**Sự khác biệt giữa hộp văn bản và trình giữ chỗ văn bản khi làm việc với các slide chủ là gì?**

Một [trình giữ chỗ](/slides/vi/nodejs-java/manage-placeholder/) thừa hưởng kiểu / vị trí từ [master](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslide/) và có thể được ghi đè trên [layouts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/), trong khi một hộp văn bản thông thường là một đối tượng độc lập trên một slide cụ thể và không thay đổi khi bạn chuyển đổi bố cục.

**Làm thế nào để thực hiện thay thế văn bản hàng loạt trên toàn bộ bản thuyết trình mà không ảnh hưởng đến văn bản trong biểu đồ, bảng và SmartArt?**

Hạn chế vòng lặp của bạn chỉ đối với các auto‑shape có khung văn bản và loại trừ các đối tượng nhúng ([charts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/smartart/)) bằng cách duyệt các bộ sưu tập của chúng riêng biệt hoặc bỏ qua các loại đối tượng đó.