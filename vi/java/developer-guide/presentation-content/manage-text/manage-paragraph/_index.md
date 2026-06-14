---
title: Quản lý đoạn văn bản PowerPoint trong Java
linktitle: Quản lý Đoạn Văn
type: docs
weight: 40
url: /vi/java/manage-paragraph/
keywords:
- thêm văn bản
- thêm đoạn văn
- quản lý văn bản
- quản lý đoạn văn
- quản lý dấu đầu dòng
- thụt lề đoạn văn
- thụt lề treo
- dấu đầu dòng đoạn văn
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
- bản trình chiếu
- Java
- Aspose.Slides
description: "Nắm bắt việc định dạng đoạn văn với Aspose.Slides cho Java—tối ưu căn chỉnh, khoảng cách và kiểu dáng trong các bản trình chiếu PPT, PPTX và ODP bằng Java."
---
## **Giới thiệu**

Aspose.Slides cung cấp tất cả các giao diện và lớp mà bạn cần để làm việc với văn bản, đoạn văn và phần trong PowerPoint bằng Java.

* Aspose.Slides cung cấp giao diện [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/) cho phép bạn thêm các đối tượng đại diện cho một đoạn văn. Một đối tượng `ITextFame` có thể chứa một hoặc nhiều đoạn văn (mỗi đoạn văn được tạo bằng ký tự xuống dòng).
* Aspose.Slides cung cấp giao diện [IParagraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraph/) cho phép bạn thêm các đối tượng đại diện cho các phần. Một đối tượng `IParagraph` có thể chứa một hoặc nhiều phần (tập hợp các đối tượng iPortions).
* Aspose.Slides cung cấp giao diện [IPortion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iportion/) cho phép bạn thêm các đối tượng đại diện cho văn bản và các thuộc tính định dạng của chúng. 

Một đối tượng `IParagraph` có khả năng xử lý văn bản với các thuộc tính định dạng khác nhau thông qua các đối tượng `IPortion` cơ bản của nó.

## **Thêm Nhiều Đoạn Văn Chứa Nhiều Phần**

Những bước sau đây cho bạn biết cách thêm một khung văn bản chứa 3 đoạn và mỗi đoạn chứa 3 phần:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Truy cập tham chiếu của slide tương ứng thông qua chỉ mục của nó.
3. Thêm một hình chữ nhật [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
4. Lấy ITextFrame liên kết với [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) .
5. Tạo hai đối tượng [IParagraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraph/) và thêm chúng vào bộ sưu tập `IParagraphs` của [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/) .
6. Tạo ba đối tượng [IPortion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iportion/) cho mỗi `IParagraph` mới (hai đối tượng Portion cho Đoạn Văn mặc định) và thêm mỗi đối tượng `IPortion` vào bộ sưu tập IPortion của từng `IParagraph` .
7. Đặt một số văn bản cho mỗi phần.
8. Áp dụng các tính năng định dạng mong muốn cho mỗi phần bằng cách sử dụng các thuộc tính định dạng do đối tượng `IPortion` cung cấp.
9. Lưu bản trình chiếu đã chỉnh sửa.

Mã Java này là một triển khai của các bước để thêm các đoạn chứa các phần:
```java
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Truy cập slide đầu tiên
    ISlide slide = pres.getSlides().get_Item(0);

    // Thêm một AutoShape loại Hình chữ nhật
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Truy cập TextFrame của AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // Tạo các Paragraph và Portion với các định dạng văn bản khác nhau
    IParagraph para0 = tf.getParagraphs().get_Item(0);
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);

    IParagraph para1 = new Paragraph();
    tf.getParagraphs().add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);

    IParagraph para2 = new Paragraph();
    tf.getParagraphs().add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);

    for (int i = 0; i < 3; i++) 
    {
        for (int j = 0; j < 3; j++) 
        {
            IPortion portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j); 
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    // Ghi PPTX ra đĩa
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Quản Lý Dấu Đầu Dòng Đoạn Văn**

Danh sách dấu đầu dòng giúp bạn tổ chức và trình bày thông tin một cách nhanh chóng và hiệu quả. Các đoạn văn có dấu đầu dòng luôn dễ đọc và hiểu hơn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Truy cập tham chiếu của slide tương ứng thông qua chỉ mục của nó.
3. Thêm một [autoshape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide được chọn.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/) của autoshape.
5. Xóa đoạn văn mặc định trong `TextFrame`.
6. Tạo thể hiện đoạn văn đầu tiên bằng lớp [Paragraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/paragraph/) .
7. Đặt thuộc tính `Type` của dấu đầu dòng cho đoạn văn thành `Symbol` và đặt ký tự dấu đầu dòng.
8. Đặt `Text` cho đoạn văn.
9. Đặt `Indent` cho dấu đầu dòng của đoạn văn.
10. Đặt màu cho dấu đầu dòng.
11. Đặt chiều cao cho dấu đầu dòng.
12. Thêm đoạn văn mới vào bộ sưu tập đoạn văn của `TextFrame`.
13. Thêm đoạn văn thứ hai và lặp lại quy trình được mô tả trong các bước 7 đến 13.
14. Lưu bản trình chiếu.

Mã Java này cho bạn thấy cách thêm một dấu đầu dòng cho đoạn văn:
```java
// Khởi tạo một lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Truy cập slide đầu tiên
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Thêm và truy cập Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Truy cập khung văn bản của autoshape
    ITextFrame txtFrm = aShp.getTextFrame();

    // Xóa đoạn văn mặc định
    txtFrm.getParagraphs().removeAt(0);

    // Tạo một đoạn văn
    Paragraph para = new Paragraph();

    // Đặt kiểu dấu đầu dòng và ký tự cho đoạn văn
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Đặt văn bản cho đoạn văn
    para.setText("Welcome to Aspose.Slides");

    // Đặt thụt lề dấu đầu dòng
    para.getParagraphFormat().setIndent(25);

    // Đặt màu cho dấu đầu dòng
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // đặt IsBulletHardColor thành true để sử dụng màu dấu đầu dòng riêng

    // Đặt chiều cao dấu đầu dòng
    para.getParagraphFormat().getBullet().setHeight(100);

    // Thêm đoạn văn vào khung văn bản
    txtFrm.getParagraphs().add(para);

    // Tạo đoạn văn thứ hai
    Paragraph para2 = new Paragraph();

    // Đặt loại và kiểu dấu đầu dòng cho đoạn văn
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Thêm văn bản cho đoạn văn
    para2.setText("This is numbered bullet");

    // Đặt thụt lề dấu đầu dòng
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // đặt IsBulletHardColor thành true để sử dụng màu dấu đầu dòng riêng

    // Đặt chiều cao dấu đầu dòng
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Thêm đoạn văn vào khung văn bản
    txtFrm.getParagraphs().add(para2);
    
    // Lưu bản trình chiếu đã chỉnh sửa
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Quản Lý Dấu Đầu Dòng Hình Ảnh**

Danh sách dấu đầu dòng giúp bạn tổ chức và trình bày thông tin một cách nhanh chóng và hiệu quả. Các đoạn văn có hình ảnh dễ đọc và hiểu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Truy cập tham chiếu của slide tương ứng thông qua chỉ mục của nó.
3. Thêm một [autoshape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/) của autoshape.
5. Xóa đoạn văn mặc định trong `TextFrame`.
6. Tạo thể hiện đoạn văn đầu tiên bằng lớp [Paragraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/paragraph/) .
7. Tải hình ảnh vào [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/) .
8. Đặt loại dấu đầu dòng thành [Picture](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/) và đặt hình ảnh.
9. Đặt `Text` cho Paragraph.
10. Đặt `Indent` cho dấu đầu dòng của Paragraph.
11. Đặt màu cho dấu đầu dòng.
12. Đặt chiều cao cho dấu đầu dòng.
13. Thêm đoạn văn mới vào bộ sưu tập đoạn văn của `TextFrame`.
14. Thêm đoạn văn thứ hai và lặp lại quy trình dựa trên các bước trước.
15. Lưu bản trình chiếu đã chỉnh sửa.

Mã Java này cho bạn thấy cách thêm và quản lý dấu đầu dòng dạng hình ảnh:
```java
// Tạo một lớp Presentation đại diện cho tệp PPTX
Presentation presentation = new Presentation();
try {
    // Truy cập slide đầu tiên
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tạo ảnh cho dấu đầu dòng
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Thêm và truy cập Autoshape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Truy cập khung văn bản của autoshape
    ITextFrame textFrame = autoShape.getTextFrame();

    // Xóa đoạn văn mặc định
    textFrame.getParagraphs().removeAt(0);

    // Tạo một đoạn văn mới
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // Đặt kiểu dấu đầu dòng và hình ảnh cho đoạn văn
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Đặt chiều cao dấu đầu dòng
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // Thêm đoạn văn vào khung văn bản
    textFrame.getParagraphs().add(paragraph);

    // Ghi bản trình chiếu dưới dạng tệp PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // Ghi bản trình chiếu dưới dạng tệp PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Quản Lý Dấu Đầu Dòng Đa Cấp**

Danh sách dấu đầu dòng giúp bạn tổ chức và trình bày thông tin một cách nhanh chóng và hiệu quả. Dấu đầu dòng đa cấp dễ đọc và hiểu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Truy cập tham chiếu của slide tương ứng thông qua chỉ mục của nó.
3. Thêm một [autoshape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide mới.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/) của autoshape.
5. Xóa đoạn văn mặc định trong `TextFrame`.
6. Tạo thể hiện đoạn văn đầu tiên thông qua lớp [Paragraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/paragraph/) và đặt độ sâu thành 0.
7. Tạo thể hiện đoạn văn thứ hai thông qua lớp `Paragraph` và đặt độ sâu thành 1.
8. Tạo thể hiện đoạn văn thứ ba thông qua lớp `Paragraph` và đặt độ sâu thành 2.
9. Tạo thể hiện đoạn văn thứ tư thông qua lớp `Paragraph` và đặt độ sâu thành 3.
10. Thêm các đoạn văn mới vào bộ sưu tập đoạn văn của `TextFrame`.
11. Lưu bản trình chiếu đã chỉnh sửa.

Mã Java này cho bạn thấy cách thêm và quản lý dấu đầu dòng đa cấp:
```java
// Khởi tạo một lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Truy cập slide đầu tiên
    ISlide slide = pres.getSlides().get_Item(0);

    // Thêm và truy cập Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Truy cập khung văn bản của autoshape được tạo
    ITextFrame text = aShp.addTextFrame("");

    // Xóa đoạn văn mặc định
    text.getParagraphs().clear();

    // Thêm đoạn văn đầu tiên
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Đặt mức độ dấu đầu dòng
    para1.getParagraphFormat().setDepth((short)0);

    // Thêm đoạn văn thứ hai
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Đặt mức độ dấu đầu dòng
    para2.getParagraphFormat().setDepth((short)1);

    // Thêm đoạn văn thứ ba
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Đặt mức độ dấu đầu dòng
    para3.getParagraphFormat().setDepth((short)2);

    // Thêm đoạn văn thứ tư
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Đặt mức độ dấu đầu dòng
    para4.getParagraphFormat().setDepth((short)3);

    // Thêm các đoạn văn vào bộ sưu tập
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // Ghi bản trình chiếu dưới dạng tệp PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Quản Lý Đoạn Văn Với Danh Sách Đánh Số Tùy Chỉnh**

Giao diện [IBulletFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibulletformat/) cung cấp thuộc tính [NumberedBulletStartWith](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) và các thuộc tính khác cho phép bạn quản lý các đoạn văn với đánh số hoặc định dạng tùy chỉnh.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Truy cập slide chứa đoạn văn.
3. Thêm một [autoshape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/) của autoshape.
5. Xóa đoạn văn mặc định trong `TextFrame`.
6. Tạo thể hiện đoạn văn đầu tiên thông qua lớp [Paragraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/paragraph/) và đặt [NumberedBulletStartWith] thành 2.
7. Tạo thể hiện đoạn văn thứ hai thông qua lớp `Paragraph` và đặt `NumberedBulletStartWith` thành 3.
8. Tạo thể hiện đoạn văn thứ ba thông qua lớp `Paragraph` và đặt `NumberedBulletStartWith` thành 7.
9. Thêm các đoạn văn mới vào bộ sưu tập đoạn văn của `TextFrame`.
10. Lưu bản trình chiếu đã chỉnh sửa.

Mã Java này cho bạn thấy cách thêm và quản lý các đoạn văn với việc đánh số hoặc định dạng tùy chỉnh:
```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Truy cập khung văn bản của autoshape đã tạo
    ITextFrame textFrame = shape.getTextFrame();

    // Xóa đoạn văn mặc định hiện có
    textFrame.getParagraphs().removeAt(0);

    // Danh sách đầu tiên
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)7);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);

    presentation.save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Đặt Thụt Dòng Dòng Đầu Cho Đoạn Văn**

Sử dụng phương thức [IParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setIndent-float-) để kiểm soát thụt đầu dòng của một đoạn văn. Phương thức này chỉ di chuyển dòng đầu tiên so với lề trái của đoạn văn. Giá trị dương dịch dòng đầu tiên sang bên phải, trong khi các dòng còn lại vẫn căn chỉnh với thân đoạn.

Sử dụng [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) khi bạn cần di chuyển toàn bộ đoạn văn. Sử dụng [IParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setIndent-float-) khi bạn chỉ cần di chuyển dòng đầu tiên.

Ví dụ dưới đây tạo nhiều đoạn văn và áp dụng các giá trị thụt khác nhau để minh họa cách thụt đầu dòng ảnh hưởng đến bố cục đoạn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Truy cập slide mục tiêu.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/autoshape/) hình chữ nhật vào slide.
4. Thêm một [TextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/textframe/) trống vào hình và xóa đoạn văn mặc định.
5. Tạo một số đoạn văn và đặt các giá trị [Indent](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setIndent-float-) khác nhau cho chúng.
6. Thêm các đoạn văn vào khung văn bản.
7. Lưu bản trình chiếu đã chỉnh sửa.

Mã này cho bạn thấy cách đặt thụt lề cho đoạn văn:
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Kết quả:
![Thụt đầu dòng của các đoạn văn](first_line_indent.png)

## **Đặt Thụt Lề Treo Cho Đoạn Văn**

Thụt lề treo là một bố cục đoạn văn trong đó dòng đầu tiên bắt đầu bên trái các dòng còn lại. Trong Aspose.Slides, bạn tạo hiệu ứng này bằng phương thức [IParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setIndent-float-). Đặt giá trị thụt là số âm để di chuyển dòng đầu tiên sang bên trái so với thân đoạn văn.

Trong thực tế, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) xác định vị trí bên trái của thân đoạn văn, và [IParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setIndent-float-) xác định vị trí của dòng đầu tiên so với lề đó. Để tạo thụt lề treo, đặt giá trị `MarginLeft` dương và giá trị `Indent` âm.

Định dạng này hữu ích cho danh mục tài liệu, tham chiếu, mục từ điển, và các đoạn văn khác nơi các dòng đã gói cần căn chỉnh dưới thân đoạn văn thay vì dưới ký tự đầu tiên của dòng đầu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Truy cập slide mục tiêu.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/autoshape/) hình chữ nhật vào slide.
4. Thêm một [TextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/textframe/) trống vào hình và xóa đoạn văn mặc định.
5. Tạo các đoạn văn và đặt một giá trị [MarginLeft](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) dương cho mỗi đoạn văn.
6. Đặt một giá trị [Indent](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setIndent-float-) âm để tạo hiệu ứng thụt lề treo.
7. Thêm các đoạn văn vào khung văn bản.
8. Lưu bản trình chiếu đã chỉnh sửa.

Mã này cho bạn thấy cách đặt thụt lề treo cho đoạn văn:
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Kết quả:
![Thụt lề treo của các đoạn văn](hanging_indent.png)

## **Quản Lý Thuộc Tính Chạy Kết Thúc Đoạn Văn**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Lấy tham chiếu cho slide chứa đoạn văn thông qua vị trí của nó.
3. Thêm một [autoshape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) hình chữ nhật vào slide.
4. Thêm một [TextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/) có hai đoạn văn vào hình chữ nhật.
5. Đặt `FontHeight` và kiểu Font cho các đoạn văn.
6. Đặt các thuộc tính End cho các đoạn văn.
7. Ghi bản trình chiếu đã chỉnh sửa thành file PPTX.

Mã Java này cho bạn thấy cách đặt các thuộc tính End cho các đoạn văn trong PowerPoint:
```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Sample text"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("Sample text 2"));

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);

    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);

    pres.save(resourcesOutputPath+"pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nhập Văn Bản HTML Vào Các Đoạn Văn**

Aspose.Slides cung cấp hỗ trợ nâng cao cho việc nhập văn bản HTML vào các đoạn văn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Truy cập tham chiếu của slide tương ứng thông qua chỉ mục của nó.
3. Thêm một [autoshape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide.
4. Thêm và truy cập [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/) của `autoshape` .
5. Xóa đoạn văn mặc định trong `ITextFrame`.
6. Đọc tệp HTML nguồn bằng một TextReader.
7. Tạo thể hiện đoạn văn đầu tiên thông qua lớp [Paragraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/paragraph/) .
8. Thêm nội dung tệp HTML đã đọc từ TextReader vào [ParagraphCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/paragraphcollection/) của TextFrame.
9. Lưu bản trình chiếu đã chỉnh sửa.

Mã Java này là một triển khai các bước để nhập văn bản HTML vào các đoạn văn:
```java
// Tạo một thể hiện Presentation rỗng
Presentation pres = new Presentation();
try {
    // Truy cập slide đầu tiên mặc định của bản trình chiếu
    ISlide slide = pres.getSlides().get_Item(0);

    // Thêm AutoShape để chứa nội dung HTML
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Thêm khung văn bản vào hình
    ashape.addTextFrame("");

    // Xóa tất cả các đoạn trong khung văn bản đã thêm
    ashape.getTextFrame().getParagraphs().clear();

    // Tải tệp HTML bằng stream reader
    TextReader tr = new StreamReader("file.html");

    // Thêm văn bản từ stream reader HTML vào khung văn bản
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Lưu bản trình chiếu
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Xuất Văn Bản Đoạn Văn Sang HTML**

Aspose.Slides cung cấp hỗ trợ nâng cao để xuất văn bản (được chứa trong các đoạn) sang HTML.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) và tải bản trình chiếu mong muốn.
2. Truy cập tham chiếu của slide tương ứng thông qua chỉ mục của nó.
3. Truy cập hình chứa văn bản sẽ được xuất sang HTML.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/textframe/) của hình.
5. Tạo một thể hiện của `StreamWriter` và thêm tệp HTML mới.
6. Cung cấp chỉ mục bắt đầu cho StreamWriter và xuất các đoạn văn bạn muốn.

Mã Java này cho bạn thấy cách xuất các văn bản đoạn PowerPoint sang HTML:
```java
// Tải tệp bản trình chiếu
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Truy cập slide đầu tiên mặc định của bản trình chiếu
    ISlide slide = pres.getSlides().get_Item(0);

    // Chỉ mục mong muốn
    int index = 0;

    // Truy cập hình đã thêm
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Tạo tệp HTML đầu ra
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //Trích xuất đoạn đầu tiên dưới dạng HTML
    // Ghi dữ liệu các đoạn vào HTML bằng cách cung cấp chỉ số bắt đầu của đoạn và tổng số đoạn cần sao chép
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lưu Đoạn Văn Dưới Dạng Hình Ảnh**

Trong phần này, chúng ta sẽ khám phá hai ví dụ minh họa cách lưu một đoạn văn bản, được đại diện bởi giao diện [IParagraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraph/), dưới dạng hình ảnh. Cả hai ví dụ đều bao gồm việc lấy hình ảnh của một hình chứa đoạn văn bằng các phương thức `getImage` từ giao diện [IShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/), tính toán giới hạn của đoạn văn trong hình, và xuất nó dưới dạng ảnh bitmap. Các cách tiếp cận này cho phép bạn trích xuất các phần cụ thể của văn bản từ bản trình chiếu PowerPoint và lưu chúng dưới dạng hình ảnh riêng, hữu ích cho các trường hợp sử dụng khác nhau.

Giả sử chúng ta có một tệp bản trình chiếu tên sample.pptx với một slide, trong đó hình đầu tiên là một hộp văn bản chứa ba đoạn.
![Hộp văn bản với ba đoạn](paragraph_to_image_input.png)

**Ví dụ 1**

Trong một ví dụ này, chúng ta lấy đoạn văn thứ hai dưới dạng hình ảnh. Để thực hiện, chúng ta trích xuất hình ảnh của hình từ slide đầu tiên của bản trình chiếu và sau đó tính toán giới hạn của đoạn văn thứ hai trong khung văn bản của hình. Đoạn văn sau đó được vẽ lại lên một ảnh bitmap mới, được lưu ở định dạng PNG. Phương pháp này đặc biệt hữu ích khi bạn cần lưu một đoạn cụ thể dưới dạng hình ảnh riêng, đồng thời giữ nguyên kích thước và định dạng của văn bản.
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Lưu hình dạng vào bộ nhớ dưới dạng bitmap.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Tạo bitmap cho hình dạng từ bộ nhớ.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Tính toán giới hạn của đoạn văn thứ hai.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();

    // Tính toán tọa độ và kích thước cho ảnh đầu ra (kích thước tối thiểu - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // Cắt bitmap của hình để chỉ lấy bitmap của đoạn văn.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

Kết quả:
![Hình ảnh đoạn văn](paragraph_to_image_output.png)

**Ví dụ 2**

Trong ví dụ này, chúng ta mở rộng cách tiếp cận trước bằng cách thêm các yếu tố tỷ lệ vào hình ảnh đoạn văn. Hình được trích xuất từ bản trình chiếu và lưu dưới dạng hình ảnh với hệ số tỷ lệ là `2`. Điều này cho phép đầu ra có độ phân giải cao hơn khi xuất đoạn văn. Các giới hạn của đoạn văn sau đó được tính toán dựa trên tỷ lệ. Việc tỷ lệ có thể đặc biệt hữu ích khi cần một hình ảnh chi tiết hơn, ví dụ, cho việc sử dụng trong tài liệu in chất lượng cao.
```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Lưu hình dạng vào bộ nhớ dưới dạng bitmap với tỷ lệ phóng đại.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Tạo bitmap cho hình dạng từ bộ nhớ.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Tính toán giới hạn của đoạn văn thứ hai.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // Tính toán tọa độ và kích thước cho ảnh đầu ra (kích thước tối thiểu - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // Cắt bitmap của hình để chỉ lấy bitmap của đoạn văn.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể tắt hoàn toàn việc ngắt dòng trong một khung văn bản không?**

Có. Sử dụng cài đặt ngắt dòng của khung văn bản ([setWrapText](https://reference.aspose.com/slides/vi/java/com.aspose.slides/textframeformat/#setWrapText-byte-)) để tắt tính năng ngắt dòng, do đó các dòng sẽ không bị cắt ở các cạnh của khung.

**Làm thế nào tôi có thể lấy giới hạn chính xác trên slide của một đoạn văn cụ thể?**

Bạn có thể lấy hình chữ nhật bao quanh của đoạn văn (hoặc thậm chí của một phần riêng lẻ) để biết vị trí và kích thước chính xác của nó trên slide.

**Căn chỉnh đoạn văn (trái/phải/giữa/đều) được kiểm soát ở đâu?**

[Alignment](https://reference.aspose.com/slides/vi/java/com.aspose.slides/paragraphformat/#setAlignment-int-) là một cài đặt ở mức đoạn văn trong [ParagraphFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/paragraphformat/); nó áp dụng cho toàn bộ đoạn văn bất kể định dạng của từng phần.

**Tôi có thể đặt ngôn ngữ kiểm tra chính tả cho chỉ một phần của đoạn văn (ví dụ, một từ) không?**

Có. Ngôn ngữ được đặt ở mức phần ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), do đó nhiều ngôn ngữ có thể cùng tồn tại trong một đoạn văn.