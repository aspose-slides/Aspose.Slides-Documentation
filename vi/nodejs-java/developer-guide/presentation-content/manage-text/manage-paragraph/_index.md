---
title: Quản lý các đoạn văn bản PowerPoint trong JavaScript
linktitle: Quản lý Đoạn Văn
type: docs
weight: 40
url: /vi/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
keywords:
  - thêm văn bản
  - thêm đoạn
  - quản lý văn bản
  - quản lý đoạn
  - quản lý dấu đầu dòng
  - thụt lề đoạn
  - thụt lề treo
  - dấu đầu dòng đoạn
  - danh sách đánh số
  - danh sách có dấu đầu dòng
  - thuộc tính đoạn
  - nhập HTML
  - văn bản sang HTML
  - đoạn sang HTML
  - đoạn sang hình ảnh
  - văn bản sang hình ảnh
  - xuất đoạn
  - PowerPoint
  - OpenDocument
  - bản trình chiếu
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Thành thạo định dạng đoạn văn với Aspose.Slides cho Node.js qua Java—tối ưu căn chỉnh, khoảng cách và kiểu dáng trong các bản trình chiếu PPT, PPTX và ODP bằng JavaScript."
---
## **Giới thiệu**

Aspose.Slides cung cấp tất cả các lớp mà bạn cần để làm việc với văn bản, đoạn và các phần trong PowerPoint bằng Java.

* Aspose.Slides cung cấp lớp [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) để cho phép bạn thêm các đối tượng đại diện cho một đoạn. Một đối tượng `TextFame` có thể chứa một hoặc nhiều đoạn (mỗi đoạn được tạo bằng cách nhập ký tự xuống dòng).
* Aspose.Slides cung cấp lớp [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/) để cho phép bạn thêm các đối tượng đại diện cho các phần. Một đối tượng `Paragraph` có thể có một hoặc nhiều phần (tập hợp các đối tượng phần văn bản).
* Aspose.Slides cung cấp lớp [Portion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/) để cho phép bạn thêm các đối tượng đại diện cho văn bản và các thuộc tính định dạng của chúng.

Một đối tượng `Paragraph` có khả năng xử lý văn bản với các thuộc tính định dạng khác nhau thông qua các đối tượng `Portion` bên dưới.

## **Thêm Nhiều Đoạn Văn Chứa Nhiều Phần**

Các bước này cho bạn cách thêm một khung văn bản chứa 3 đoạn và mỗi đoạn chứa 3 phần:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Truy cập tham chiếu slide tương ứng bằng chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) dạng hình chữ nhật vào slide.
4. Lấy ITextFrame liên kết với [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/).
5. Tạo hai đối tượng [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/) và thêm chúng vào bộ sưu tập `IParagraphs` của [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/).
6. Tạo ba đối tượng [Portion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/) cho mỗi `Paragraph` mới (hai đối tượng Portion cho Paragraph mặc định) và thêm mỗi đối tượng `Portion` vào bộ sưu tập IPortion của từng `Paragraph`.
7. Đặt một số văn bản cho mỗi phần.
8. Áp dụng các tính năng định dạng mong muốn cho mỗi phần bằng các thuộc tính định dạng mà đối tượng `Portion` cung cấp.
9. Lưu bản trình chiếu đã sửa đổi.

```javascript
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Truy cập slide đầu tiên
    var slide = pres.getSlides().get_Item(0);
    // Thêm một AutoShape kiểu Hình chữ nhật
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // Truy cập TextFrame của AutoShape
    var tf = ashp.getTextFrame();
    // Tạo các Paragraph và Portion với các định dạng văn bản khác nhau
    var para0 = tf.getParagraphs().get_Item(0);
    var port01 = new aspose.slides.Portion();
    var port02 = new aspose.slides.Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);
    var para1 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para1);
    var port10 = new aspose.slides.Portion();
    var port11 = new aspose.slides.Portion();
    var port12 = new aspose.slides.Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);
    var para2 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para2);
    var port20 = new aspose.slides.Portion();
    var port21 = new aspose.slides.Portion();
    var port22 = new aspose.slides.Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);
    for (var i = 0; i < 3; i++) {
        for (var j = 0; j < 3; j++) {
            var portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j);
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }
    // Ghi PPTX ra đĩa
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Quản Lý Đánh Dấu Đoạn Văn**

Bullet lists help you to organize and present information quickly and efficiently. Bulleted paragraphs are always easier to read and understand.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Truy cập tham chiếu slide tương ứng bằng chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide đã chọn.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) của autoshape.
5. Xóa đoạn mặc định trong `TextFrame`.
6. Tạo thể hiện đoạn đầu tiên bằng cách sử dụng lớp [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/).
7. Đặt `Type` dấu đầu dòng cho đoạn thành `Symbol` và đặt ký tự dấu đầu dòng.
8. Đặt `Text` cho đoạn.
9. Đặt `Indent` cho đoạn để định dạng dấu đầu dòng.
10. Đặt màu cho dấu đầu dòng.
11. Đặt chiều cao cho dấu đầu dòng.
12. Thêm đoạn mới vào bộ sưu tập đoạn của `TextFrame`.
13. Thêm đoạn thứ hai và lặp lại quy trình đã nêu ở các bước 7 đến 13.
14. Lưu bản trình chiếu.

```javascript
// Khởi tạo một lớp Presentation đại diện cho tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Truy cập slide đầu tiên
    var slide = pres.getSlides().get_Item(0);
    // Thêm và truy cập Autoshape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Truy cập khung văn bản của autoshape
    var txtFrm = aShp.getTextFrame();
    // Xóa đoạn mặc định
    txtFrm.getParagraphs().removeAt(0);
    // Tạo một đoạn
    var para = new aspose.slides.Paragraph();
    // Đặt kiểu dấu đầu dòng và ký tự cho đoạn
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // Đặt văn bản cho đoạn
    para.setText("Welcome to Aspose.Slides");
    // Đặt thụt lề dấu đầu dòng
    para.getParagraphFormat().setIndent(25);
    // Đặt màu dấu đầu dòng
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// đặt IsBulletHardColor thành true để sử dụng màu dấu đầu dòng riêng
    // Đặt chiều cao dấu đầu dòng
    para.getParagraphFormat().getBullet().setHeight(100);
    // Thêm đoạn vào khung văn bản
    txtFrm.getParagraphs().add(para);
    // Tạo đoạn thứ hai
    var para2 = new aspose.slides.Paragraph();
    // Đặt loại và kiểu dấu đầu dòng cho đoạn
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // Thêm văn bản cho đoạn
    para2.setText("This is numbered bullet");
    // Đặt thụt lề dấu đầu dòng
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// đặt IsBulletHardColor thành true để sử dụng màu dấu đầu dòng riêng
    // Đặt chiều cao dấu đầu dòng
    para2.getParagraphFormat().getBullet().setHeight(100);
    // Thêm đoạn vào khung văn bản
    txtFrm.getParagraphs().add(para2);
    // Lưu bản trình chiếu đã chỉnh sửa
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Quản Lý Đánh Dấu Hình Ảnh**

Bullet lists help you to organize and present information quickly and efficiently. Picture paragraphs are easy to read and understand.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Truy cập tham chiếu slide tương ứng bằng chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) của autoshape.
5. Xóa đoạn mặc định trong `TextFrame`.
6. Tạo thể hiện đoạn đầu tiên bằng cách sử dụng lớp [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/).
7. Tải hình ảnh vào [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/).
8. Đặt loại dấu đầu dòng thành [Picture](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) và đặt hình ảnh.
9. Đặt `Text` cho Paragraph.
10. Đặt `Indent` cho Paragraph để định dạng dấu đầu dòng.
11. Đặt màu cho dấu đầu dòng.
12. Đặt chiều cao cho dấu đầu dòng.
13. Thêm đoạn mới vào bộ sưu tập đoạn của `TextFrame`.
14. Thêm đoạn thứ hai và lặp lại quy trình dựa trên các bước trước.
15. Lưu bản trình chiếu đã sửa đổi.

```javascript
// Khởi tạo một lớp Presentation đại diện cho tệp PPTX
var presentation = new aspose.slides.Presentation();
try {
    // Truy cập slide đầu tiên
    var slide = presentation.getSlides().get_Item(0);
    // Khởi tạo ảnh cho dấu đầu dòng
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Thêm và truy cập Autoshape
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Truy cập khung văn bản của autoshape
    var textFrame = autoShape.getTextFrame();
    // Xóa đoạn mặc định
    textFrame.getParagraphs().removeAt(0);
    // Tạo một đoạn mới
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // Đặt kiểu dấu đầu dòng và hình ảnh cho đoạn
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // Đặt chiều cao dấu đầu dòng
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // Thêm đoạn vào khung văn bản
    textFrame.getParagraphs().add(paragraph);
    // Ghi bản trình chiếu dưới dạng tệp PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // Ghi bản trình chiếu dưới dạng tệp PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Quản Lý Đánh Dấu Đa Cấp**

Bullet lists help you to organize and present information quickly and efficiently. Multilevel bullets are easy to read and understand.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Truy cập tham chiếu slide tương ứng bằng chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide mới.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) của autoshape.
5. Xóa đoạn mặc định trong `TextFrame`.
6. Tạo thể hiện đoạn đầu tiên bằng lớp [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/) và đặt độ sâu là 0.
7. Tạo thể hiện đoạn thứ hai bằng lớp `Paragraph` và đặt độ sâu là 1.
8. Tạo thể hiện đoạn thứ ba bằng lớp `Paragraph` và đặt độ sâu là 2.
9. Tạo thể hiện đoạn thứ tư bằng lớp `Paragraph` và đặt độ sâu là 3.
10. Thêm các đoạn mới vào bộ sưu tập đoạn của `TextFrame`.
11. Lưu bản trình chiếu đã sửa đổi.

```javascript
// Khởi tạo một lớp Presentation đại diện cho tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Truy cập slide đầu tiên
    var slide = pres.getSlides().get_Item(0);
    // Thêm và truy cập Autoshape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Truy cập khung văn bản của autoshape đã tạo
    var text = aShp.addTextFrame("");
    // Xóa đoạn mặc định
    text.getParagraphs().clear();
    // Thêm đoạn đầu tiên
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Đặt mức độ dấu đầu dòng
    para1.getParagraphFormat().setDepth(0);
    // Thêm đoạn thứ hai
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Đặt mức độ dấu đầu dòng
    para2.getParagraphFormat().setDepth(1);
    // Thêm đoạn thứ ba
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Đặt mức độ dấu đầu dòng
    para3.getParagraphFormat().setDepth(2);
    // Thêm đoạn thứ tư
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Đặt mức độ dấu đầu dòng
    para4.getParagraphFormat().setDepth(3);
    // Thêm các đoạn vào bộ sưu tập
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);
    // Ghi bản trình chiếu dưới dạng tệp PPTX
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Quản Lý Đoạn Văn Với Danh Sách Đánh Số Tùy Chỉnh**

The [BulletFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/bulletformat/) class provides the [NumberedBulletStartWith](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) property and others that allow you to manage paragraphs with custom numbering or formatting.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Truy cập slide chứa đoạn.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) của autoshape.
5. Xóa đoạn mặc định trong `TextFrame`.
6. Tạo thể hiện đoạn đầu tiên bằng lớp [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/) và đặt [NumberedBulletStartWith] thành 2.
7. Tạo thể hiện đoạn thứ hai bằng lớp `Paragraph` và đặt `NumberedBulletStartWith` thành 3.
8. Tạo thể hiện đoạn thứ ba bằng lớp `Paragraph` và đặt `NumberedBulletStartWith` thành 7.
9. Thêm các đoạn mới vào bộ sưu tập đoạn của `TextFrame`.
10. Lưu bản trình chiếu đã sửa đổi.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Truy cập khung văn bản của autoshape đã tạo
    var textFrame = shape.getTextFrame();
    // Xóa đoạn mặc định hiện có
    textFrame.getParagraphs().removeAt(0);
    // Danh sách đầu tiên
    var paragraph1 = new aspose.slides.Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth(4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
    paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);
    var paragraph2 = new aspose.slides.Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth(4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
    paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);
    var paragraph5 = new aspose.slides.Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth(4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(7);
    paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);
    presentation.save("SetCustomBulletsNumber-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Đặt Thụt Lề Dòng Đầu Cho Đoạn Văn**

Use the [ParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setindent/) method to control the first-line indent of a paragraph. This method moves only the first line relative to the paragraph's left margin. A positive value shifts the first line to the right, while the remaining lines stay aligned to the paragraph body.

Use [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) when you need to move the whole paragraph. Use [ParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setindent/) when you need to move only the first line.

The example below creates several paragraphs and applies different indent values to demonstrate how the first-line indent affects paragraph layout.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Truy cập slide mục tiêu.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) dạng hình chữ nhật vào slide.
4. Thêm một [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) trống vào hình dạng và xóa đoạn mặc định.
5. Tạo một số đoạn và đặt các giá trị [Indent](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setindent/) khác nhau cho chúng.
6. Thêm các đoạn vào khung văn bản.
7. Lưu bản trình chiếu đã sửa đổi.

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    let thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Kết quả:

![Thụt lề dòng đầu của các đoạn](first_line_indent.png)

## **Đặt Thụt Lề Treo Cho Đoạn Văn**

A hanging indent is a paragraph layout in which the first line starts to the left of the remaining lines. In Aspose.Slides, you create this effect with the [ParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setindent/) method. Set the indent to a negative value to move the first line to the left relative to the paragraph body.

In practice, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) defines the left position of the paragraph body, and [ParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setindent/) defines the position of the first line relative to that margin. To create a hanging indent, set a positive `MarginLeft` value and a negative `Indent` value.

This formatting is useful for bibliographies, references, glossary entries, and other paragraphs where wrapped lines must align under the paragraph body rather than under the first character of the first line.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Truy cập slide mục tiêu.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) dạng hình chữ nhật vào slide.
4. Thêm một [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) trống vào hình dạng và xóa đoạn mặc định.
5. Tạo các đoạn và đặt một giá trị [MarginLeft](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) dương cho mỗi đoạn.
6. Đặt một giá trị [Indent](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setindent/) âm để tạo hiệu ứng thụt lề treo.
7. Thêm các đoạn vào khung văn bản.
8. Lưu bản trình chiếu đã sửa đổi.

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Kết quả:

![Thụt lề treo của các đoạn](hanging_indent.png)

## **Quản Lý Thuộc Tính Chạy Cuối Đoạn Văn Cho Đoạn Văn**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
1. Lấy tham chiếu cho slide chứa đoạn thông qua vị trí của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) dạng hình chữ nhật vào slide.
1. Thêm một [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) có hai đoạn vào Rectangle.
1. Đặt `FontHeight` và kiểu Font cho các đoạn.
1. Đặt các thuộc tính End cho các đoạn.
1. Ghi bản trình chiếu đã sửa đổi thành tệp PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Sample text"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("Sample text 2"));
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);
    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);
    pres.save(resourcesOutputPath + "pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nhập Văn Bản HTML Vào Các Đoạn Văn**

Aspose.Slides provides enhanced support for importing HTML text into paragraphs.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Truy cập tham chiếu slide tương ứng bằng chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
4. Thêm và truy cập [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) của `AutoShape`.
5. Xóa đoạn mặc định trong `TextFrame`.
6. Đọc tệp HTML nguồn trong một TextReader.
7. Tạo thể hiện đoạn đầu tiên bằng lớp [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/).
8. Thêm nội dung tệp HTML đã đọc từ TextReader vào [ParagraphCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphcollection/) của TextFrame.
9. Lưu bản trình chiếu đã sửa đổi.

```javascript
// Tạo một thể hiện trình chiếu trống
var pres = new aspose.slides.Presentation();
try {
    // Truy cập slide đầu tiên mặc định của trình chiếu
    var slide = pres.getSlides().get_Item(0);
    // Thêm AutoShape để chứa nội dung HTML
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Thêm khung văn bản vào hình dạng
    ashape.addTextFrame("");
    // Xóa tất cả các đoạn trong khung văn bản đã thêm
    ashape.getTextFrame().getParagraphs().clear();
    // Tải tệp HTML bằng stream reader
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // Thêm văn bản từ stream reader HTML vào khung văn bản
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // Lưu trình chiếu
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Xuất Văn Bản Đoạn Văn Sang HTML**

Aspose.Slides provides enhanced support for exporting texts (contained in paragraphs) to HTML.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) và tải bản trình chiếu mong muốn.
2. Truy cập tham chiếu slide tương ứng bằng chỉ mục của nó.
3. Truy cập hình dạng chứa văn bản sẽ được xuất sang HTML.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) của hình dạng.
5. Tạo một thể hiện `StreamWriter` và thêm tệp HTML mới.
6. Cung cấp chỉ mục bắt đầu cho `StreamWriter` và xuất các đoạn mà bạn muốn.

```javascript
// Tải tệp trình chiếu
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // Truy cập slide đầu tiên mặc định của trình chiếu
    var slide = pres.getSlides().get_Item(0);
    // Chỉ số mong muốn
    var index = 0;
    // Truy cập hình dạng đã thêm
    var ashape = slide.getShapes().get_Item(index);
    // Tạo tệp HTML đầu ra
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // Trích xuất đoạn đầu tiên dạng HTML
    // Ghi dữ liệu các đoạn vào HTML bằng cách cung cấp chỉ số bắt đầu của đoạn và tổng số đoạn sẽ sao chép
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lưu Đoạn Văn Thành Hình Ảnh**

In this section, we will explore two examples that demonstrate how to save a text paragraph, represented by the [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/) class, as an image. Both examples include obtaining the image of a shape containing the paragraph using the `getImage` methods from the [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/) class, calculating the bounds of the paragraph within the shape, and exporting it as a bitmap image. These approaches allow you to extract specific parts of the text from PowerPoint presentations and save them as separate images, which can be useful for further use in various scenarios.

Let's assume we have a presentation file called sample.pptx with one slide, where the first shape is a text box containing three paragraphs.

![Hộp văn bản với ba đoạn](paragraph_to_image_input.png)

**Example 1**

In this example, we obtain the second paragraph as an image. To do this, we extract the image of the shape from the first slide of the presentation and then calculate the bounds of the second paragraph in the shape's text frame. The paragraph is then redrawn onto a new bitmap image, which is saved in PNG format. This method is especially useful when you need to save a specific paragraph as a separate image while preserving the exact dimensions and formatting of the text.

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Lưu hình dạng vào bộ nhớ dưới dạng bitmap.
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // Tạo bitmap cho hình dạng từ bộ nhớ.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Tính toán ranh giới của đoạn thứ hai.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // Tính toán tọa độ và kích thước cho hình ảnh đầu ra (kích thước tối thiểu - 1x1 pixel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Cắt bitmap hình dạng để chỉ lấy bitmap đoạn.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Kết quả:

![Hình ảnh đoạn văn](paragraph_to_image_output.png)

**Example 2**

In this example, we extend the previous approach by adding scaling factors to the paragraph image. The shape is extracted from the presentation and saved as an image with a scaling factor of `2`. This allows for a higher resolution output when exporting the paragraph. The paragraph bounds are then calculated considering the scale. Scaling can be particularly useful when a more detailed image is needed, for example, for use in high-quality printed materials.

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Lưu hình dạng vào bộ nhớ dưới dạng bitmap với tỷ lệ phóng đại.
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // Tạo bitmap cho hình dạng từ bộ nhớ.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Tính toán ranh giới của đoạn thứ hai.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // Tính toán tọa độ và kích thước cho hình ảnh đầu ra (kích thước tối thiểu - 1x1 pixel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Cắt bitmap hình dạng để chỉ lấy bitmap đoạn.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Câu Hỏi Thường Gặp**

**Tôi có thể hoàn toàn tắt việc ngắt dòng bên trong khung văn bản không?**

Có. Sử dụng cài đặt bao bọc của khung văn bản ([setWrapText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframeformat/setwraptext/)) để tắt việc bao bọc, vì vậy các dòng sẽ không bị ngắt ở cạnh của khung.

**Làm thế nào tôi có thể lấy tọa độ chính xác trên slide của một đoạn cụ thể?**

Bạn có thể truy xuất hình chữ nhật bao quanh của đoạn (hoặc thậm chí của một phần) để biết vị trí và kích thước chính xác của nó trên slide.

**Vị trí căn chỉnh đoạn (trái/phải/giữa/đều) được kiểm soát ở đâu?**

[setAlignment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setalignment/) là phương thức cho cài đặt cấp đoạn trong [ParagraphFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/); nó áp dụng cho toàn bộ đoạn bất kể định dạng của các phần riêng lẻ.

**Tôi có thể đặt ngôn ngữ kiểm tra chính tả cho chỉ một phần của đoạn (ví dụ: một từ) không?**

Có. Ngôn ngữ được đặt ở cấp phần ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)), vì vậy nhiều ngôn ngữ có thể cùng tồn tại trong một đoạn.