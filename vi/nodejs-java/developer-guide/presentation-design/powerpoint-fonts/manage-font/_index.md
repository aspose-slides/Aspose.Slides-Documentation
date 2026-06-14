---
title: Quản lý phông chữ trong bản trình bày bằng JavaScript
linktitle: Quản lý phông chữ
type: docs
weight: 10
url: /vi/nodejs-java/manage-fonts/
keywords:
- quản lý phông chữ
- thuộc tính phông chữ
- đoạn văn
- định dạng văn bản
- PowerPoint
- OpenDocument
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Kiểm soát phông chữ với Aspose.Slides for Node.js via Java: nhúng, thay thế và tải phông chữ tùy chỉnh để giữ cho các bản trình bày PPT, PPTX và ODP rõ ràng và nhất quán."
---
## **Giới thiệu**

Các bản trình bày thường chứa cả văn bản và hình ảnh. Văn bản có thể được định dạng theo nhiều cách khác nhau, để làm nổi bật các phần và từ cụ thể hoặc để phù hợp với phong cách công ty. Định dạng văn bản giúp người dùng thay đổi giao diện của nội dung bản trình bày. Bài viết này trình bày cách sử dụng Aspose.Slides for Node.js via Java để cấu hình các thuộc tính phông chữ của các đoạn văn bản trên các slide.

## **Quản lý các thuộc tính liên quan đến phông chữ**

Để quản lý các thuộc tính phông chữ của một đoạn văn bằng Aspose.Slides for Node.js via Java:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).
1. Lấy tham chiếu của slide bằng cách sử dụng chỉ mục của nó.
1. Truy cập các hình dạng [Placeholder](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/placeholder/) trên slide và ép kiểu chúng thành [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/).
1. Lấy [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/) từ [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) được cung cấp bởi [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/).
1. Canh lề đoạn văn.
1. Truy cập văn bản [Portion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/) của một [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/).
1. Định nghĩa phông chữ bằng [FontData](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontdata/) và đặt **Font** cho [Portion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/) tương ứng.
   1. Đặt phông chữ in đậm.
   1. Đặt phông chữ in nghiêng.
1. Đặt màu phông chữ bằng [FillFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fillformat/) được cung cấp bởi đối tượng [Portion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/).
1. Lưu bản trình bày đã chỉnh sửa thành tệp PPTX.

Việc thực hiện các bước trên được trình bày dưới đây. Nó nhận một bản trình bày chưa được định dạng và định dạng phông chữ trên một trong các slide. Các ảnh chụp màn hình sau đây cho thấy tệp đầu vào và cách các đoạn mã thay đổi nó. Mã thay đổi phông chữ, màu sắc và kiểu phông chữ.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Hình: Văn bản trong tệp đầu vào**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Hình: Văn bản giống nhau với định dạng đã cập nhật**|

```javascript
// Tạo một đối tượng Presentation đại diện cho tệp PPTX
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // Truy cập slide bằng vị trí của nó
    var slide = pres.getSlides().get_Item(0);
    // Truy cập placeholder đầu tiên và thứ hai trong slide và ép kiểu thành AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // Truy cập Paragraph đầu tiên
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // Canh lề đoạn văn
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.JustifyLow);
    // Truy cập portion đầu tiên
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // Định nghĩa phông chữ mới
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // Gán phông chữ mới cho portion
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // Đặt phông chữ in đậm
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Đặt phông chữ in nghiêng
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Đặt màu phông chữ
    port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Lưu PPTX vào đĩa
    pres.save("WelcomeFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Đặt các thuộc tính phông chữ cho văn bản**
{{% alert color="primary" %}} 

Như đã đề cập trong **Quản lý các thuộc tính liên quan đến phông chữ**, một [Portion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/) được dùng để chứa văn bản có cùng kiểu định dạng trong một đoạn văn. Bài viết này chỉ ra cách sử dụng Aspose.Slides for Node.js via Java để tạo một hộp văn bản chứa một số văn bản và sau đó định nghĩa một phông chữ cụ thể, cùng các thuộc tính khác của danh mục họ phông chữ.

{{% /alert %}} 

Để tạo một hộp văn bản và đặt các thuộc tính phông chữ cho văn bản trong đó:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).
1. Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) loại **Rectangle** vào slide.
1. Xóa kiểu nền liên quan đến [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/).
1. Truy cập vào [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) của [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/).
1. Thêm một số văn bản vào [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/).
1. Truy cập đối tượng [Portion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/) liên kết với [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/).
1. Định nghĩa phông chữ sẽ được sử dụng cho [Portion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/).
1. Đặt các thuộc tính phông chữ khác như in đậm, in nghiêng, gạch chân, màu sắc và chiều cao bằng các thuộc tính tương ứng được cung cấp bởi đối tượng [Portion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/).
1. Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Việc thực hiện các bước trên được trình bày dưới đây.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Hình: Văn bản với một số thuộc tính phông chữ được đặt bởi Aspose.Slides for Node.js via Java**|

```javascript
// Tạo một đối tượng Presentation đại diện cho tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Thêm một AutoShape loại Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // Xóa bất kỳ kiểu nền nào gắn với AutoShape
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Truy cập TextFrame liên kết với AutoShape
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // Truy cập Portion liên kết với TextFrame
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // Đặt phông chữ cho Portion
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Đặt thuộc tính in đậm cho phông chữ
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Đặt thuộc tính in nghiêng cho phông chữ
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Đặt thuộc tính gạch chân cho phông chữ
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // Đặt chiều cao cho phông chữ
    port.getPortionFormat().setFontHeight(25);
    // Đặt màu cho phông chữ
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Lưu bản trình bày vào đĩa
    pres.save("pptxFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```