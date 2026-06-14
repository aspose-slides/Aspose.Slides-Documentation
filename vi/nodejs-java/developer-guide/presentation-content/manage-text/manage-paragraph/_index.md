---
title: Quản lý các đoạn văn bản PowerPoint trong JavaScript
linktitle: Quản lý Đoạn văn
type: docs
weight: 40
url: /vi/nodejs-java/manage-paragraph/
keywords:
- thêm văn bản
- thêm đoạn văn
- quản lý văn bản
- quản lý đoạn văn
- quản lý dấu đầu dòng
- thụt đoạn
- thụt lồng
- dấu đầu dòng đoạn
- danh sách đánh số
- danh sách có dấu đầu dòng
- thuộc tính đoạn văn
- nhập HTML
- văn bản sang HTML
- đoạn văn sang HTML
- đoạn văn sang hình ảnh
- văn bản sang hình ảnh
- xuất đoạn văn
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Nắm vững định dạng đoạn văn với Aspose.Slides cho Node.js qua Java—tối ưu căn chỉnh, khoảng cách và kiểu trong các bản trình bày PPT, PPTX và ODP bằng JavaScript."
---
## **Giới thiệu**

Aspose.Slides cung cấp tất cả các lớp bạn cần để làm việc với văn bản, đoạn văn và phần trong PowerPoint bằng Java.

* Aspose.Slides cung cấp lớp [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) cho phép bạn thêm các đối tượng đại diện cho một đoạn văn. Một đối tượng `TextFame` có thể chứa một hoặc nhiều đoạn văn (mỗi đoạn được tạo bằng ký tự xuống dòng).
* Aspose.Slides cung cấp lớp [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/) cho phép bạn thêm các đối tượng đại diện cho các phần. Một đối tượng `Paragraph` có thể chứa một hoặc nhiều phần (tập hợp các đối tượng phần văn bản).
* Aspose.Slides cung cấp lớp [Portion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/) cho phép bạn thêm các đối tượng đại diện cho văn bản và các thuộc tính định dạng của chúng.

Một đối tượng `Paragraph` có khả năng xử lý văn bản với các thuộc tính định dạng khác nhau thông qua các đối tượng `Portion` bên dưới.

## **Thêm Nhiều Đoạn Văn Chứa Nhiều Phần**

Các bước sau cho bạn cách thêm một khung văn bản chứa 3 đoạn và mỗi đoạn chứa 3 phần:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Truy cập tham chiếu của slide tương ứng qua chỉ mục của nó.
3. Thêm một hình chữ nhật [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
4. Lấy ITextFrame liên kết với [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/).
5. Tạo hai đối tượng [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/) và thêm chúng vào bộ sưu tập `IParagraphs` của [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/).
6. Tạo ba đối tượng [Portion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/) cho mỗi `Paragraph` mới (hai đối tượng Portion cho Paragraph mặc định) và thêm mỗi đối tượng `Portion` vào bộ sưu tập IPortion của từng `Paragraph`.
7. Đặt một số văn bản cho mỗi phần.
8. Áp dụng các tính năng định dạng ưa thích cho mỗi phần bằng các thuộc tính định dạng được cung cấp bởi đối tượng `Portion`.
9. Lưu bản trình bày đã chỉnh sửa.

```javascript
// Khởi tạo lớp Presentation biểu thị một tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Truy cập slide đầu tiên
    var slide = pres.getSlides().get_Item(0);
    // Thêm một AutoShape loại Rectangle
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

## **Quản lý Đánh dấu Đoạn Văn**

Danh sách dấu đầu dòng giúp bạn tổ chức và trình bày thông tin nhanh chóng và hiệu quả. Các đoạn có dấu đầu dòng luôn dễ đọc và hiểu hơn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Truy cập tham chiếu của slide tương ứng qua chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide được chọn.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) của autoshape.
5. Xóa đoạn mặc định trong `TextFrame`.
6. Tạo đối tượng đoạn đầu tiên bằng lớp [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/).
7. Đặt `Type` dấu đầu dòng cho đoạn văn thành `Symbol` và đặt ký tự dấu đầu dòng.
8. Đặt `Text` cho đoạn văn.
9. Đặt `Indent` cho dấu đầu dòng của đoạn văn.
10. Đặt màu cho dấu đầu dòng.
11. Đặt chiều cao cho dấu đầu dòng.
12. Thêm đoạn mới vào bộ sưu tập đoạn của `TextFrame`.
13. Thêm đoạn thứ hai và lặp lại quy trình từ bước 7 đến 13.
14. Lưu bản trình bày.

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
    // Tạo một đoạn văn
    var para = new aspose.slides.Paragraph();
    // Đặt kiểu dấu đầu dòng và ký hiệu cho đoạn văn
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // Đặt văn bản cho đoạn
    para.setText("Welcome to Aspose.Slides");
    // Đặt thụt dấu đầu dòng
    para.getParagraphFormat().setIndent(25);
    // Đặt màu dấu đầu dòng
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// đặt IsBulletHardColor thành true để sử dụng màu dấu đầu dòng riêng
    // Đặt chiều cao dấu đầu dòng
    para.getParagraphFormat().getBullet().setHeight(100);
    // Thêm Paragraph vào khung văn bản
    txtFrm.getParagraphs().add(para);
    // Tạo đoạn văn thứ hai
    var para2 = new aspose.slides.Paragraph();
    // Đặt loại và kiểu dấu đầu dòng cho đoạn văn
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // Thêm văn bản đoạn
    para2.setText("This is numbered bullet");
    // Đặt thụt dấu đầu dòng
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// đặt IsBulletHardColor thành true để sử dụng màu dấu đầu dòng riêng
    // Đặt chiều cao dấu đầu dòng
    para2.getParagraphFormat().getBullet().setHeight(100);
    // Thêm Paragraph vào khung văn bản
    txtFrm.getParagraphs().add(para2);
    // Lưu bản trình chiếu đã chỉnh sửa
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Quản lý Dấu đầu dòng Hình ảnh**

Danh sách dấu đầu dòng giúp bạn tổ chức và trình bày thông tin nhanh chóng và hiệu quả. Các đoạn hình ảnh dễ đọc và hiểu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Truy cập tham chiếu của slide tương ứng qua chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) của autoshape.
5. Xóa đoạn mặc định trong `TextFrame`.
6. Tạo đối tượng đoạn đầu tiên bằng lớp [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/).
7. Tải hình ảnh vào [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/).
8. Đặt kiểu dấu đầu dòng thành [Picture](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) và đặt hình ảnh.
9. Đặt `Text` cho đoạn văn.
10. Đặt `Indent` cho dấu đầu dòng của đoạn văn.
11. Đặt màu cho dấu đầu dòng.
12. Đặt chiều cao cho dấu đầu dòng.
13. Thêm đoạn mới vào bộ sưu tập đoạn của `TextFrame`.
14. Thêm đoạn thứ hai và lặp lại quy trình dựa trên các bước trước.
15. Lưu bản trình chiếu đã chỉnh sửa.

```javascript
// Khởi tạo một lớp Presentation đại diện cho tệp PPTX
var presentation = new aspose.slides.Presentation();
try {
    // Truy cập slide đầu tiên
    var slide = presentation.getSlides().get_Item(0);
    // Khởi tạo hình ảnh cho dấu đầu dòng
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
    // Ghi bản trình chiếu thành tệp PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // Ghi bản trình chiếu thành tệp PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Quản lý Dấu đầu dòng Đa cấp**

Danh sách dấu đầu dòng giúp bạn tổ chức và trình bày thông tin nhanh chóng và hiệu quả. Dấu đầu dòng đa cấp dễ đọc và hiểu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Truy cập tham chiếu của slide tương ứng qua chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) trong slide mới.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) của autoshape.
5. Xóa đoạn mặc định trong `TextFrame`.
6. Tạo đoạn đầu tiên thông qua lớp [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/) và đặt độ sâu thành 0.
7. Tạo đoạn thứ hai thông qua lớp `Paragraph` và đặt độ sâu thành 1.
8. Tạo đoạn thứ ba thông qua lớp `Paragraph` và đặt độ sâu thành 2.
9. Tạo đoạn thứ tư thông qua lớp `Paragraph` và đặt độ sâu thành 3.
10. Thêm các đoạn mới vào bộ sưu tập đoạn của `TextFrame`.
11. Lưu bản trình bày đã chỉnh sửa.

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
    // Thêm đoạn thứ nhất
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

## **Quản lý Đoạn Văn với Danh sách Đánh số tùy chỉnh**

Lớp [BulletFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/bulletformat/) cung cấp thuộc tính [NumberedBulletStartWith](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) và các thuộc tính khác cho phép bạn quản lý các đoạn văn với đánh số hoặc định dạng tùy chỉnh.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Truy cập slide chứa đoạn văn.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) của autoshape.
5. Xóa đoạn mặc định trong `TextFrame`.
6. Tạo đoạn đầu tiên qua lớp [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/) và đặt [NumberedBulletStartWith](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) thành 2.
7. Tạo đoạn thứ hai qua lớp `Paragraph` và đặt `NumberedBulletStartWith` thành 3.
8. Tạo đoạn thứ ba qua lớp `Paragraph` và đặt `NumberedBulletStartWith` thành 7.
9. Thêm các đoạn mới vào bộ sưu tập đoạn của `TextFrame`.
10. Lưu bản trình bày đã chỉnh sửa.

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

## **Đặt Thụt đầu dòng Dòng đầu cho Đoạn Văn**

Sử dụng phương thức [ParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setindent/) để kiểm soát thụt đầu dòng của dòng đầu cho một đoạn. Phương thức này chỉ di chuyển dòng đầu tiên so với lề trái của đoạn. Giá trị dương đẩy dòng đầu tiên sang phải, trong khi các dòng còn lại vẫn căn theo thân đoạn.

Sử dụng [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) khi bạn cần di chuyển toàn bộ đoạn. Sử dụng [ParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setindent/) khi bạn chỉ muốn di chuyển dòng đầu tiên.

Ví dụ dưới đây tạo một số đoạn và áp dụng các giá trị thụt khác nhau để minh họa cách thụt đầu dòng ảnh hưởng đến bố cục đoạn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Truy cập slide mục tiêu.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) hình chữ nhật vào slide.
4. Thêm một [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) trống vào hình dạng và xóa đoạn mặc định.
5. Tạo một số đoạn và đặt các giá trị [Indent](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setindent/) khác nhau cho chúng.
6. Thêm các đoạn vào khung văn bản.
7. Lưu bản trình bày đã chỉnh sửa.

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

![Thụt đầu dòng Dòng đầu của các đoạn](first_line_indent.png)

## **Đặt Thụt lồng nhau cho Đoạn Văn**

Thụt lồng nhau là bố cục đoạn trong đó dòng đầu tiên bắt đầu ở bên trái các dòng còn lại. Trong Aspose.Slides, bạn tạo hiệu ứng này bằng phương thức [ParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setindent/). Đặt thụt thành giá trị âm để di chuyển dòng đầu tiên sang trái so với thân đoạn.

Thực tế, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) xác định vị trí trái của thân đoạn, và [ParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setindent/) xác định vị trí của dòng đầu tiên so với lề đó. Để tạo thụt lồng, đặt giá trị `MarginLeft` dương và giá trị `Indent` âm.

Định dạng này hữu ích cho thư mục, tham chiếu, mục lục và các đoạn khác nơi các dòng gập phải căn dưới thân đoạn thay vì dưới ký tự đầu tiên của dòng đầu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Truy cập slide mục tiêu.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) hình chữ nhật vào slide.
4. Thêm một [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) trống vào hình dạng và xóa đoạn mặc định.
5. Tạo các đoạn và đặt giá trị [MarginLeft](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) dương cho mỗi đoạn.
6. Đặt giá trị [Indent](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setindent/) âm để tạo hiệu ứng thụt lồng.
7. Thêm các đoạn vào khung văn bản.
8. Lưu bản trình bày đã chỉnh sửa.

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

![Thụt lồng của các đoạn](hanging_indent.png)

## **Quản lý Thuộc tính Chạy Kết thúc Đoạn Văn**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Lấy tham chiếu cho slide chứa đoạn qua vị trí của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) hình chữ nhật vào slide.
4. Thêm một [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) có hai đoạn vào hình chữ nhật.
5. Đặt `FontHeight` và kiểu Font cho các đoạn.
6. Đặt các thuộc tính End cho các đoạn.
7. Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

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

## **Nhập Văn bản HTML vào Đoạn Văn**

Aspose.Slides cung cấp hỗ trợ nâng cao cho việc nhập văn bản HTML vào các đoạn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Truy cập tham chiếu của slide tương ứng qua chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) vào slide.
4. Thêm và truy cập [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) của `AutoShape`.
5. Xóa đoạn mặc định trong `TextFrame`.
6. Đọc tệp HTML nguồn bằng một TextReader.
7. Tạo đoạn đầu tiên qua lớp [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/).
8. Thêm nội dung tệp HTML đã đọc từ TextReader vào [ParagraphCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphcollection/) của TextFrame.
9. Lưu bản trình bày đã chỉnh sửa.

```javascript
// Tạo một thể hiện Presentation rỗng
var pres = new aspose.slides.Presentation();
try {
    // Truy cập slide đầu tiên mặc định của bản trình chiếu
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
    // Lưu Presentation
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Xuất Văn bản Đoạn Văn ra HTML**

Aspose.Slides cung cấp hỗ trợ nâng cao cho việc xuất văn bản (trong các đoạn) ra HTML.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) và tải bản trình bày mong muốn.
2. Truy cập tham chiếu của slide tương ứng qua chỉ mục của nó.
3. Truy cập hình dạng chứa văn bản sẽ được xuất ra HTML.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) của hình dạng.
5. Tạo một thể hiện của `StreamWriter` và thêm tệp HTML mới.
6. Cung cấp chỉ mục bắt đầu cho StreamWriter và xuất các đoạn bạn muốn.

```javascript
// Tải tệp trình chiếu
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // Truy cập slide đầu tiên mặc định của bản trình chiếu
    var slide = pres.getSlides().get_Item(0);
    // Chỉ mục mong muốn
    var index = 0;
    // Truy cập hình dạng đã thêm
    var ashape = slide.getShapes().get_Item(index);
    // Tạo tệp HTML đầu ra
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // Trích xuất đoạn đầu tiên dưới dạng HTML
    // Ghi dữ liệu các đoạn vào HTML bằng cách cung cấp chỉ mục bắt đầu của đoạn và tổng số đoạn cần sao chép
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lưu Đoạn Văn dưới dạng Hình ảnh**

Trong phần này, chúng tôi sẽ khám phá hai ví dụ minh họa cách lưu một đoạn văn bản, được đại diện bởi lớp [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/), dưới dạng hình ảnh. Cả hai ví dụ đều bao gồm việc lấy hình ảnh của một hình dạng chứa đoạn bằng các phương thức `getImage` từ lớp [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/), tính toán giới hạn của đoạn trong hình dạng và xuất nó dưới dạng hình bitmap. Những cách tiếp cận này cho phép bạn trích xuất các phần cụ thể của văn bản từ bản trình chiếu PowerPoint và lưu chúng dưới dạng hình ảnh riêng biệt, hữu ích cho các kịch bản sử dụng khác nhau.

Giả sử chúng ta có một tệp trình chiếu tên là sample.pptx với một slide, trong đó hình dạng đầu tiên là một hộp văn bản chứa ba đoạn.

![Hộp văn bản với ba đoạn](paragraph_to_image_input.png)

**Example 1**

Trong ví dụ này, chúng ta lấy đoạn thứ hai dưới dạng hình ảnh. Để thực hiện, chúng ta trích xuất hình ảnh của hình dạng từ slide đầu tiên của bản trình chiếu và sau đó tính toán giới hạn của đoạn thứ hai trong khung văn bản của hình dạng. Đoạn văn sau đó được vẽ lại lên một hình bitmap mới, được lưu ở định dạng PNG. Phương pháp này đặc biệt hữu ích khi bạn cần lưu một đoạn cụ thể dưới dạng hình ảnh riêng biệt trong khi giữ nguyên kích thước và định dạng chính xác của văn bản.

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

    // Tính toán giới hạn của đoạn văn thứ hai.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // Tính toán tọa độ và kích thước cho hình ảnh xuất ra (kích thước tối thiểu - 1x1 pixel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Cắt bitmap của hình dạng để lấy bitmap chỉ của đoạn văn.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

![Hình ảnh đoạn văn](paragraph_to_image_output.png)

**Example 2**

Trong ví dụ này, chúng ta mở rộng cách tiếp cận trước đó bằng cách thêm các hệ số tỷ lệ vào hình ảnh đoạn văn. Hình dạng được trích xuất từ bản trình chiếu và lưu dưới dạng hình ảnh với hệ số tỷ lệ `2`. Điều này cho phép xuất ra độ phân giải cao hơn khi xuất đoạn văn. Sau đó, giới hạn của đoạn được tính toán dựa trên tỷ lệ. Việc tỷ lệ có thể đặc biệt hữu ích khi cần một hình ảnh chi tiết hơn, ví dụ để sử dụng trong tài liệu in chất lượng cao.

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Lưu hình dạng vào bộ nhớ dưới dạng bitmap có tỷ lệ.
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

    // Tính toán giới hạn của đoạn văn thứ hai.
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

    // Cắt bitmap của hình dạng để chỉ lấy bitmap của đoạn văn.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Tôi có thể tắt hoàn toàn việc ngắt dòng trong một khung văn bản không?**

Có. Sử dụng thiết lập ngắt dòng của khung văn bản ([setWrapText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframeformat/setwraptext/)) để tắt tính năng ngắt dòng, vì vậy các dòng sẽ không bị ngắt ở các cạnh của khung.

**Làm thế nào tôi có thể lấy vị trí và kích thước chính xác trên slide của một đoạn cụ thể?**

Bạn có thể lấy hình chữ nhật bao quanh của đoạn (hoặc thậm chí của một phần riêng lẻ) để biết vị trí và kích thước chính xác của nó trên slide.

**Căn chỉnh đoạn văn (trái/phải/giữa/đều) được kiểm soát ở đâu?**

[setAlignment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/setalignment/) là một phương thức thiết lập mức độ đoạn trong [ParagraphFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/); nó áp dụng cho toàn bộ đoạn bất kể định dạng của từng phần riêng lẻ.

**Tôi có thể đặt ngôn ngữ kiểm tra chính tả cho chỉ một phần của đoạn (ví dụ, một từ) không?**

Có. Ngôn ngữ được đặt ở mức độ phần ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)), vì vậy có thể có nhiều ngôn ngữ tồn tại trong cùng một đoạn.