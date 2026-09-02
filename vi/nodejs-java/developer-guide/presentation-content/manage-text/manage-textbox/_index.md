---
title: Quản lý hộp văn bản trong bản trình chiếu bằng JavaScript
linktitle: Quản lý hộp văn bản
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
description: "Aspose.Slides for Node.js giúp bạn dễ dàng tạo, chỉnh sửa và sao chép các hộp văn bản trong tệp PowerPoint và OpenDocument, nâng cao khả năng tự động hoá bản trình chiếu của bạn."
---
## **Giới thiệu**

Văn bản trên các slide thường nằm trong các hộp văn bản hoặc hình dạng. Do đó, để thêm văn bản vào một slide, bạn phải thêm một hộp văn bản và sau đó đặt một số văn bản bên trong hộp văn bản. Aspose.Slides for Node.js via Java cung cấp lớp [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/AutoShape) cho phép bạn thêm một hình dạng chứa một số văn bản.

{{% alert title="Thông tin" color="info" %}}

Aspose.Slides cũng cung cấp lớp [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape) cho phép bạn thêm các hình dạng vào slide. Tuy nhiên, không phải tất cả các hình dạng được thêm thông qua lớp `Shape` đều có thể chứa văn bản. Nhưng các hình dạng được thêm thông qua lớp [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/AutoShape) có thể chứa văn bản.

{{% /alert %}}

{{% alert title="Lưu ý" color="warning" %}} 

Do đó, khi làm việc với một hình dạng mà bạn muốn thêm văn bản, bạn có thể muốn kiểm tra và xác nhận rằng nó đã được ép kiểu qua lớp `AutoShape`. Chỉ khi đó bạn mới có thể làm việc với [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TextFrame), một thuộc tính của `AutoShape`. Xem phần [Update Text](https://docs.aspose.com/slides/vi/nodejs-java/manage-textbox/#update-text) trên trang này.

{{% /alert %}}

## **Tạo Hộp Văn Bản trên Slide**

Để tạo một hộp văn bản trên slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2. Lấy tham chiếu đến slide đầu tiên trong bản trình bày mới tạo. 
3. Thêm một đối tượng [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/AutoShape) với [ShapeType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-) được đặt là `Rectangle` tại vị trí chỉ định trên slide và lấy tham chiếu đến đối tượng `AutoShape` vừa được thêm.
4. Thêm thuộc tính `TextFrame` vào đối tượng `AutoShape` để chứa văn bản. Trong ví dụ dưới đây, chúng tôi đã thêm văn bản: *Aspose TextBox*
5. Cuối cùng, ghi tệp PPTX thông qua đối tượng `Presentation`. 

Đoạn mã JavaScript—một triển khai của các bước trên—cho bạn thấy cách thêm văn bản vào slide:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Kiểm tra Hình dạng Hộp Văn Bản**

Aspose.Slides cung cấp phương thức [isTextBox](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/#isTextBox) từ lớp [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) cho phép bạn kiểm tra các hình dạng và xác định hộp văn bản.

![Hộp văn bản và hình dạng](istextbox.png)

Đoạn mã JavaScript này cho bạn thấy cách kiểm tra xem một hình dạng có được tạo dưới dạng hộp văn bản hay không:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (var slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        var slide = presentation.getSlides().get_Item(slideIndex);
        for (var shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            var shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Lưu ý rằng nếu bạn chỉ thêm một autoshape bằng phương thức `addAutoShape` từ lớp [ShapeCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/), phương thức `isTextBox` của autoshape sẽ trả về `false`. Tuy nhiên, sau khi bạn thêm văn bản vào autoshape bằng phương thức `addTextFrame` hoặc `setText`, thuộc tính `isTextBox` sẽ trả về `true`.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Tìm Hình Dạng Sở Hữu Khung Văn Bản**

Trong mã xử lý văn bản chung, bạn có thể nhận được một [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) mà chưa biết đối tượng trình chiếu nào chứa nó. Sử dụng phương thức [TextFrame.getParentShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#getParentShape--) để điều hướng trở lại hình dạng sở hữu [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/).

Đối với một khung văn bản thuộc về một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) hoặc một hình dạng chứa văn bản khác, [TextFrame.getParentShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#getParentShape--) trả về chủ sở hữu và [TextFrame.getParentCell](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#getParentCell--) trả về `null`. Cả hai phương thức đều cung cấp điều hướng chỉ đọc, vì vậy việc gọi chúng không thay đổi quyền sở hữu. Luôn kiểm tra giá trị trả về có phải `null` trước khi truy cập vào hình dạng.

Đối với một ví dụ đầy đủ xác định chủ sở hữu hình dạng và ô bảng, bao gồm các hình dạng liên kết với nút SmartArt, xem [Search and Replace Text](/slides/vi/nodejs-java/search-and-replace-text/).

## **Thêm Cột trong Hộp Văn Bản**

Aspose.Slides cung cấp các phương thức [setColumnCount](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) và [setColumnSpacing](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TextFrameFormat) cho phép bạn thêm các cột vào hộp văn bản. Bạn có thể chỉ định số cột trong hộp văn bản và đặt khoảng cách giữa các cột tính bằng điểm.

Đoạn mã JavaScript dưới đây minh họa thao tác đã mô tả:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên trong bản trình chiếu
    var slide = pres.getSlides().get_Item(0);
    // Thêm một AutoShape với loại được đặt là Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Thêm TextFrame vào Rectangle
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
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

## **Thêm Cột trong Khung Văn Bản**

Aspose.Slides for Node.js via Java cung cấp phương thức [setColumnCount](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TextFrameFormat) cho phép bạn thêm các cột trong khung văn bản. Thông qua thuộc tính này, bạn có thể chỉ định số cột mong muốn trong một khung văn bản.

Đoạn mã JavaScript này cho bạn thấy cách thêm một cột vào trong khung văn bản:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const assert = require("assert");

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
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        // Khoảng cách cột chưa bao giờ được đặt, vì vậy nó được báo là NaN.
        assert.ok(Number.isNaN(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing()));
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
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 20);
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
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 3);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 15);
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

## **Cập nhật Văn Bản**

Aspose.Slides cho phép bạn thay đổi hoặc cập nhật văn bản chứa trong một hộp văn bản hoặc tất cả các văn bản trong một bản trình chiếu.

Đoạn mã JavaScript này minh họa một thao tác mà trong đó tất cả các văn bản trong bản trình chiếu được cập nhật hoặc thay đổi:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Kiểm tra nếu hình dạng hỗ trợ khung văn bản (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // Duyệt qua các đoạn trong khung văn bản
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // Duyệt qua mỗi phần trong đoạn
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

## **Thêm Hộp Văn Bản với Siêu Liên Kết** 

Bạn có thể chèn một liên kết bên trong hộp văn bản. Khi hộp văn bản được nhấp, người dùng sẽ được chuyển hướng đến liên kết đó.

Để thêm một hộp văn bản chứa liên kết, thực hiện các bước sau:

1. Tạo một thể hiện của lớp `Presentation`. 
2. Lấy tham chiếu đến slide đầu tiên trong bản trình chiếu mới tạo. 
3. Thêm một đối tượng `AutoShape` với `ShapeType` được đặt là `Rectangle` tại vị trí chỉ định trên slide và lấy tham chiếu đến đối tượng AutoShape vừa được thêm.
4. Thêm một `TextFrame` vào đối tượng `AutoShape` và đặt văn bản cho phần đầu tiên của nó. Trong ví dụ dưới đây, chúng tôi đã sử dụng văn bản: *Aspose.Slides*
5. Lấy `HyperlinkManager` của phần đó thông qua `PortionFormat` của nó.
6. Gọi `setExternalHyperlinkClick` trên `HyperlinkManager` để gắn liên kết vào phần đó.
7. Cuối cùng, ghi tệp PPTX thông qua đối tượng `Presentation`. 

Đoạn mã JavaScript—một triển khai của các bước trên—cho bạn thấy cách thêm một hộp văn bản có siêu liên kết vào slide:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Khởi tạo một lớp Presentation đại diện cho file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên trong bản trình chiếu
    var slide = pres.getSlides().get_Item(0);
    // Thêm một đối tượng AutoShape với loại được đặt là Rectangle
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // Ép kiểu shape thành AutoShape
    var pptxAutoShape = shape;
    // Truy cập thuộc tính ITextFrame liên kết với AutoShape
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // Thêm một số văn bản vào khung
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // Đặt siêu liên kết cho phần văn bản
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

**Sự khác nhau giữa hộp văn bản và trình giữ chỗ văn bản khi làm việc với các slide master là gì?**

Một [placeholder](/slides/vi/nodejs-java/manage-placeholder/) kế thừa kiểu/định vị từ [master](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslide/) và có thể được ghi đè trên [layouts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/), trong khi một hộp văn bản thông thường là một đối tượng độc lập trên một slide cụ thể và không thay đổi khi bạn chuyển đổi layout.

**Làm thế nào để thực hiện thay thế văn bản hàng loạt trên toàn bộ bản trình chiếu mà không ảnh hưởng đến văn bản trong biểu đồ, bảng và SmartArt?**

Hạn chế vòng lặp của bạn chỉ đối với các auto-shape có khung văn bản và loại bỏ các đối tượng nhúng ([charts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/smartart/)) bằng cách duyệt các bộ sưu tập của chúng riêng biệt hoặc bỏ qua các loại đối tượng đó.