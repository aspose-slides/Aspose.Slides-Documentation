---
title: Quản lý các đoạn văn bản PowerPoint trên Android
linktitle: Quản lý đoạn văn
type: docs
weight: 40
url: /vi/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
keywords:
- thêm văn bản
- thêm đoạn văn
- quản lý văn bản
- quản lý đoạn văn
- quản lý dấu đầu mục
- thụt đoạn văn
- thụt treo
- dấu đầu mục đoạn văn
- danh sách đánh số
- danh sách có dấu đầu mục
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
- Android
- Java
- Aspose.Slides
description: "Thành thạo định dạng đoạn văn với Aspose.Slides cho Android—tối ưu căn chỉnh, khoảng cách và kiểu dáng trong các bản trình chiếu PPT, PPTX và ODP bằng Java."
---
## **Giới thiệu**

Aspose.Slides cung cấp tất cả các giao diện và lớp bạn cần để làm việc với văn bản, đoạn văn và phần trong PowerPoint bằng Java.

* Aspose.Slides cung cấp giao diện [ITextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/) để cho phép bạn thêm các đối tượng đại diện cho một đoạn văn. Một đối tượng `ITextFame` có thể chứa một hoặc nhiều đoạn văn (mỗi đoạn văn được tạo qua một ký tự xuống dòng).
* Aspose.Slides cung cấp giao diện [IParagraph](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraph/) để cho phép bạn thêm các đối tượng đại diện cho các phần. Một đối tượng `IParagraph` có thể chứa một hoặc nhiều phần (tập hợp các đối tượng iPortions).
* Aspose.Slides cung cấp giao diện [IPortion](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iportion/) để cho phép bạn thêm các đối tượng đại diện cho văn bản và các thuộc tính định dạng của chúng.

Một đối tượng `IParagraph` có khả năng xử lý văn bản với các thuộc tính định dạng khác nhau thông qua các đối tượng `IPortion` bên dưới của nó.

## **Thêm Nhiều Đoạn Văn Chứa Nhiều Phần Văn Bản**

Các bước sau cho bạn cách thêm một khung văn bản chứa 3 đoạn văn và mỗi đoạn văn chứa 3 phần:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
2. Truy cập tham chiếu slide liên quan thông qua chỉ mục của nó.
3. Thêm một hình chữ nhật [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) vào slide.
4. Lấy ITextFrame liên kết với [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/).
5. Tạo hai đối tượng [IParagraph](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraph/) và thêm chúng vào bộ sưu tập `IParagraphs` của [ITextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/).
6. Tạo ba đối tượng [IPortion](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iportion/) cho mỗi `IParagraph` mới (hai đối tượng Portion cho Paragraph mặc định) và thêm mỗi đối tượng `IPortion` vào bộ sưu tập IPortion của mỗi `IParagraph`.
7. Đặt một đoạn văn bản cho mỗi phần.
8. Áp dụng các tính năng định dạng mong muốn cho mỗi phần bằng các thuộc tính định dạng được cung cấp bởi đối tượng `IPortion`.
9. Lưu bản trình chiếu đã chỉnh sửa.

Mã Java này là triển khai các bước để thêm các đoạn văn chứa các phần:

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

    // Tạo Paragraphs và Portions với các định dạng văn bản khác nhau
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

## **Quản Lý Đánh Dấu Danh Sách Đoạn Văn**

Danh sách có dấu đầu mục giúp bạn tổ chức và trình bày thông tin một cách nhanh chóng và hiệu quả. Các đoạn văn có dấu đầu mục luôn dễ đọc và hiểu hơn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
2. Truy cập tham chiếu slide liên quan thông qua chỉ mục của nó.
3. Thêm một [autoshape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) vào slide đã chọn.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/) của autoshape.
5. Xóa đoạn văn mặc định trong `TextFrame`.
6. Tạo thể hiện đoạn văn đầu tiên bằng lớp [Paragraph](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/paragraph/).
7. Đặt `Type` dấu đầu mục cho đoạn văn thành `Symbol` và đặt ký tự dấu đầu mục.
8. Đặt `Text` cho đoạn văn.
9. Đặt `Indent` cho dấu đầu mục.
10. Đặt màu cho dấu đầu mục.
11. Đặt chiều cao cho dấu đầu mục.
12. Thêm đoạn văn mới vào bộ sưu tập đoạn văn của `TextFrame`.
13. Thêm đoạn văn thứ hai và lặp lại quy trình trong các bước 7 đến 13.
14. Lưu bản trình chiếu.

Mã Java này cho bạn cách thêm một dấu đầu mục cho đoạn văn:

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

    // Đặt kiểu và ký tự dấu đầu mục cho đoạn văn
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Đặt văn bản cho đoạn văn
    para.setText("Welcome to Aspose.Slides");

    // Đặt độ thụt dấu đầu mục
    para.getParagraphFormat().setIndent(25);

    // Đặt màu dấu đầu mục
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // đặt IsBulletHardColor thành true để sử dụng màu dấu đầu mục riêng

    // Đặt chiều cao dấu đầu mục
    para.getParagraphFormat().getBullet().setHeight(100);

    // Thêm Paragraph vào khung văn bản
    txtFrm.getParagraphs().add(para);

    // Tạo đoạn văn thứ hai
    Paragraph para2 = new Paragraph();

    // Đặt loại và kiểu dấu đầu mục cho đoạn văn
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Thêm văn bản đoạn văn
    para2.setText("This is numbered bullet");

    // Đặt độ thụt dấu đầu mục
    para2.getParagraphFormat().setIndent(25);

    // Đặt màu dấu đầu mục
    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // đặt IsBulletHardColor thành true để sử dụng màu dấu đầu mục riêng

    // Đặt chiều cao dấu đầu mục
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Thêm Paragraph vào khung văn bản
    txtFrm.getParagraphs().add(para2);
    
    // Lưu bản trình chiếu đã chỉnh sửa
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Quản Lý Dấu Đầu Mục Hình Ảnh**

Danh sách có dấu đầu mục giúp bạn tổ chức và trình bày thông tin một cách nhanh chóng và hiệu quả. Các đoạn văn dạng hình ảnh dễ đọc và hiểu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
2. Truy cập tham chiếu slide liên quan thông qua chỉ mục của nó.
3. Thêm một [autoshape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) vào slide.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/) của autoshape.
5. Xóa đoạn văn mặc định trong `TextFrame`.
6. Tạo thể hiện đoạn văn đầu tiên bằng lớp [Paragraph](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/paragraph/).
7. Tải hình ảnh trong [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ippimage/).
8. Đặt loại dấu đầu mục thành [Picture](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ippimage/) và đặt hình ảnh.
9. Đặt `Text` cho Paragraph.
10. Đặt `Indent` cho dấu đầu mục.
11. Đặt màu cho dấu đầu mục.
12. Đặt chiều cao cho dấu đầu mục.
13. Thêm đoạn văn mới vào bộ sưu tập đoạn văn của `TextFrame`.
14. Thêm đoạn văn thứ hai và lặp lại quy trình dựa trên các bước trước.
15. Lưu bản trình chiếu đã chỉnh sửa.

Mã Java này cho bạn cách thêm và quản lý dấu đầu mục hình ảnh:

```java
// Khởi tạo một lớp Presentation đại diện cho tệp PPTX
Presentation presentation = new Presentation();
try {
    // Truy cập slide đầu tiên
    ISlide slide = presentation.getSlides().get_Item(0);

    // Khởi tạo hình ảnh cho dấu đầu mục
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

    // Đặt kiểu dấu đầu mục và hình ảnh cho đoạn văn
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Đặt chiều cao dấu đầu mục
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

## **Quản Lý Dấu Đầu Mục Đa Cấp**

Danh sách có dấu đầu mục giúp bạn tổ chức và trình bày thông tin một cách nhanh chóng và hiệu quả. Dấu đầu mục đa cấp dễ đọc và hiểu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
2. Truy cập tham chiếu slide liên quan thông qua chỉ mục của nó.
3. Thêm một [autoshape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) vào slide mới.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/) của autoshape.
5. Xóa đoạn văn mặc định trong `TextFrame`.
6. Tạo thể hiện đoạn văn đầu tiên qua lớp [Paragraph](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/paragraph/) và đặt độ sâu là 0.
7. Tạo thể hiện đoạn văn thứ hai qua lớp `Paragraph` và đặt độ sâu là 1.
8. Tạo thể hiện đoạn văn thứ ba qua lớp `Paragraph` và đặt độ sâu là 2.
9. Tạo thể hiện đoạn văn thứ tư qua lớp `Paragraph` và đặt độ sâu là 3.
10. Thêm các đoạn văn mới vào bộ sưu tập đoạn văn của `TextFrame`.
11. Lưu bản trình chiếu đã chỉnh sửa.

Mã Java này cho bạn cách thêm và quản lý dấu đầu mục đa cấp:

```java
// Khởi tạo một lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Truy cập slide đầu tiên
    ISlide slide = pres.getSlides().get_Item(0);

    // Thêm và truy cập Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Truy cập khung văn bản của autoshape đã tạo
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
    // Đặt mức độ dấu đầu mục
    para1.getParagraphFormat().setDepth((short)0);

    // Thêm đoạn văn thứ hai
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Đặt mức độ dấu đầu mục
    para2.getParagraphFormat().setDepth((short)1);

    // Thêm đoạn văn thứ ba
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Đặt mức độ dấu đầu mục
    para3.getParagraphFormat().setDepth((short)2);

    // Thêm đoạn văn thứ tư
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Đặt mức độ dấu đầu mục
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

Giao diện [IBulletFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibulletformat/) cung cấp thuộc tính [NumberedBulletStartWith](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) và các thuộc tính khác cho phép bạn quản lý các đoạn văn với đánh số hoặc định dạng tùy chỉnh.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
2. Truy cập slide chứa đoạn văn.
3. Thêm một [autoshape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) vào slide.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/) của autoshape.
5. Xóa đoạn văn mặc định trong `TextFrame`.
6. Tạo thể hiện đoạn văn đầu tiên qua lớp [Paragraph](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/paragraph/) và đặt [NumberedBulletStartWith](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) thành 2.
7. Tạo thể hiện đoạn văn thứ hai qua lớp `Paragraph` và đặt `NumberedBulletStartWith` thành 3.
8. Tạo thể hiện đoạn văn thứ ba qua lớp `Paragraph` và đặt `NumberedBulletStartWith` thành 7.
9. Thêm các đoạn văn mới vào bộ sưu tập đoạn văn của `TextFrame`.
10. Lưu bản trình chiếu đã chỉnh sửa.

Mã Java này cho bạn cách thêm và quản lý các đoạn văn với đánh số hoặc định dạng tùy chỉnh:

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

## **Đặt Độ Thụt Dòng Dòng Đầu Cho Đoạn Văn**

Sử dụng phương thức [IParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) để kiểm soát độ thụt dòng đầu của một đoạn văn. Phương thức này chỉ di chuyển dòng đầu tiên so với lề trái của đoạn văn. Giá trị dương sẽ đẩy dòng đầu sang phải, trong khi các dòng còn lại vẫn được căn chỉnh với thân đoạn văn.

Sử dụng [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) khi bạn cần di chuyển toàn bộ đoạn văn. Sử dụng [IParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) khi bạn chỉ cần di chuyển dòng đầu.

Ví dụ dưới đây tạo một số đoạn văn và áp dụng các giá trị thụt khác nhau để minh họa cách độ thụt dòng đầu ảnh hưởng đến bố cục đoạn văn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
2. Truy cập slide mục tiêu.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/autoshape/) hình chữ nhật vào slide.
4. Thêm một [TextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textframe/) rỗng vào hình dạng và xóa đoạn văn mặc định.
5. Tạo một số đoạn văn và đặt các giá trị [Indent](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float/) khác nhau cho chúng.
6. Thêm các đoạn văn vào khung văn bản.
7. Lưu bản trình chiếu đã chỉnh sửa.

Mã này cho bạn cách đặt độ thụt cho đoạn văn:

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

![The first-line indent of the paragraphs](first_line_indent.png)

## **Đặt Độ Thụt Treo Cho Đoạn Văn**

Độ thụt treo là bố cục đoạn văn trong đó dòng đầu bắt đầu ở bên trái của các dòng còn lại. Trong Aspose.Slides, bạn tạo hiệu ứng này bằng phương thức [IParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). Đặt giá trị thụt âm để di chuyển dòng đầu sang trái so với thân đoạn văn.

Trong thực tế, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) xác định vị trí bên trái của thân đoạn văn, và [IParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) xác định vị trí của dòng đầu so với lề đó. Để tạo độ thụt treo, đặt giá trị `MarginLeft` dương và giá trị `Indent` âm.

Định dạng này hữu ích cho thư mục, tài liệu tham khảo, mục từ điển và các đoạn văn khác mà các dòng gập cần căn dưới thân đoạn văn thay vì dưới ký tự đầu tiên của dòng đầu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
2. Truy cập slide mục tiêu.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/autoshape/) hình chữ nhật vào slide.
4. Thêm một [TextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textframe/) rỗng vào hình dạng và xóa đoạn văn mặc định.
5. Tạo các đoạn văn và đặt giá trị [MarginLeft](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) dương cho mỗi đoạn.
6. Đặt giá trị [Indent](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) âm để tạo hiệu ứng độ thụt treo.
7. Thêm các đoạn văn vào khung văn bản.
8. Lưu bản trình chiếu đã chỉnh sửa.

Mã này cho bạn cách đặt độ thụt treo cho đoạn văn:

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

![The hanging indent of the paragraphs](hanging_indent.png)

## **Quản Lý Thuộc Tính Chạy Cuối Đoạn Văn**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
1. Lấy tham chiếu tới slide chứa đoạn văn thông qua vị trí của nó.
1. Thêm một hình chữ nhật [autoshape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) vào slide.
1. Thêm một [TextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/) có hai đoạn văn vào hình chữ nhật.
1. Đặt `FontHeight` và loại Font cho các đoạn văn.
1. Đặt các thuộc tính End cho các đoạn văn.
1. Ghi bản trình chiếu đã chỉnh sửa thành file PPTX.

Mã Java này cho bạn cách đặt các thuộc tính End cho các đoạn văn trong PowerPoint: 

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

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
2. Truy cập tham chiếu slide liên quan thông qua chỉ mục của nó.
3. Thêm một [autoshape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) vào slide.
4. Thêm và truy cập `autoshape` [ITextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/).
5. Xóa đoạn văn mặc định trong `ITextFrame`.
6. Đọc tệp HTML nguồn bằng một TextReader.
7. Tạo thể hiện đoạn văn đầu tiên qua lớp [Paragraph](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/paragraph/).
8. Thêm nội dung tệp HTML đã đọc từ TextReader vào [ParagraphCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/paragraphcollection/) của TextFrame.
9. Lưu bản trình chiếu đã chỉnh sửa.

Mã Java này là triển khai các bước để nhập văn bản HTML vào các đoạn văn:

```java
// Tạo một thể hiện Presentation trống
Presentation pres = new Presentation();
try {
    // Truy cập slide đầu tiên mặc định của bản trình chiếu
    ISlide slide = pres.getSlides().get_Item(0);

    // Thêm AutoShape để chứa nội dung HTML
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Thêm khung văn bản vào hình dạng
    ashape.addTextFrame("");

    // Xóa tất cả các đoạn văn trong khung văn bản đã thêm
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

Aspose.Slides cung cấp hỗ trợ nâng cao cho việc xuất văn bản (được chứa trong các đoạn văn) sang HTML.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) và tải bản trình chiếu mong muốn.
2. Truy cập tham chiếu slide liên quan thông qua chỉ mục của nó.
3. Truy cập hình dạng chứa văn bản sẽ được xuất sang HTML.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textframe/) của hình dạng.
5. Tạo một thể hiện của `StreamWriter` và thêm tệp HTML mới.
6. Cung cấp chỉ mục bắt đầu cho StreamWriter và xuất các đoạn văn bạn muốn.

Mã Java này cho bạn cách xuất văn bản đoạn văn PowerPoint sang HTML:

```java
// Tải tệp bản trình chiếu
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Truy cập slide đầu tiên mặc định của bản trình chiếu
    ISlide slide = pres.getSlides().get_Item(0);

    // Chỉ mục mong muốn
    int index = 0;

    // Truy cập hình dạng đã thêm
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Tạo tệp HTML đầu ra
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //Trích xuất đoạn văn đầu tiên dưới dạng HTML
    // Ghi dữ liệu các đoạn văn vào HTML bằng cách cung cấp chỉ mục bắt đầu của đoạn, tổng số đoạn cần sao chép
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lưu Đoạn Văn Thành Hình Ảnh**

Trong phần này, chúng ta sẽ khám phá hai ví dụ minh họa cách lưu một đoạn văn bản, được biểu diễn bằng giao diện [IParagraph](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraph/), thành hình ảnh. Cả hai ví dụ đều bao gồm việc lấy hình ảnh của một hình dạng chứa đoạn văn bằng các phương thức `getImage` từ giao diện [IShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/), tính toán giới hạn của đoạn văn trong hình dạng và xuất nó dưới dạng hình bitmap. Các cách tiếp cận này cho phép bạn trích xuất các phần cụ thể của văn bản từ bản trình chiếu PowerPoint và lưu chúng thành các hình ảnh riêng, hữu ích cho việc sử dụng tiếp trong các kịch bản khác nhau.

Giả sử chúng ta có một tệp bản trình chiếu tên là sample.pptx với một slide, trong đó hình dạng đầu tiên là một hộp văn bản chứa ba đoạn văn.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Ví dụ 1**

Trong ví dụ này, chúng ta lấy đoạn văn thứ hai dưới dạng hình ảnh. Để làm điều đó, chúng ta trích xuất hình ảnh của hình dạng từ slide đầu tiên của bản trình chiếu, sau đó tính toán giới hạn của đoạn văn thứ hai trong khung văn bản của hình dạng. Đoạn văn sau đó được vẽ lại lên một hình bitmap mới và lưu ở định dạng PNG. Phương pháp này đặc biệt hữu ích khi bạn cần lưu một đoạn văn cụ thể dưới dạng hình ảnh riêng, đồng thời bảo tồn kích thước và định dạng chính xác của văn bản.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Lưu hình dạng vào bộ nhớ dưới dạng bitmap.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Tạo bitmap hình dạng từ bộ nhớ.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Tính toán giới hạn của đoạn văn thứ hai.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();

    // Tính toán tọa độ và kích thước cho hình ảnh đầu ra (kích thước tối thiểu - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // Cắt bitmap hình dạng để lấy chỉ bitmap của đoạn văn.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

Kết quả:

![The paragraph image](paragraph_to_image_output.png)

**Ví dụ 2**

Trong ví dụ này, chúng ta mở rộng cách tiếp cận trước bằng cách thêm các hệ số tỷ lệ vào hình ảnh đoạn văn. Hình dạng được trích xuất từ bản trình chiếu và lưu dưới dạng hình ảnh với hệ số tỷ lệ `2`. Điều này cho phép xuất ra hình ảnh có độ phân giải cao hơn khi xuất đoạn văn. Giới hạn của đoạn văn sau đó được tính toán có xét đến tỷ lệ. Việc tỷ lệ hoá có thể đặc biệt hữu ích khi cần một hình ảnh chi tiết hơn, ví dụ, để sử dụng trong tài liệu in chất lượng cao.

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Lưu hình dạng vào bộ nhớ dưới dạng bitmap có tỷ lệ.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Tạo bitmap hình dạng từ bộ nhớ.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Tính toán giới hạn của đoạn văn thứ hai.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.set(
            paragraphRectangle.left * imageScaleX,
            paragraphRectangle.top * imageScaleY,
            paragraphRectangle.right * imageScaleX,
            paragraphRectangle.bottom * imageScaleY
    );

    // Tính toán tọa độ và kích thước cho hình ảnh đầu ra (kích thước tối thiểu - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // Cắt bitmap hình dạng để lấy chỉ bitmap của đoạn văn.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Câu Hỏi Thường Gặp**

**Tôi có thể tắt hoàn toàn việc ngắt dòng trong một khung văn bản không?**

Có. Sử dụng cài đặt đóng gói của khung văn bản ([setWrapText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)) để tắt đóng gói, vì vậy các dòng sẽ không bị ngắt ở cạnh của khung.

**Làm sao tôi có thể lấy giới hạn trên slide chính xác của một đoạn văn cụ thể?**

Bạn có thể lấy hình chữ nhật bao quanh của đoạn văn (và thậm chí của một phần riêng lẻ) để biết vị trí và kích thước chính xác của nó trên slide.

**Vị trí căn chỉnh đoạn văn (trái/phải/giữa/đều) được kiểm soát ở đâu?**

[Alignment](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/paragraphformat/#setAlignment-int-) là một cài đặt cấp độ đoạn văn trong [ParagraphFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/paragraphformat/); nó áp dụng cho toàn bộ đoạn văn bất kể định dạng riêng lẻ của các phần.

**Tôi có thể đặt ngôn ngữ kiểm tra chính tả cho một phần của đoạn văn (ví dụ, một từ) không?**

Có. Ngôn ngữ được đặt ở cấp độ phần ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), vì vậy nhiều ngôn ngữ có thể tồn tại trong cùng một đoạn văn.