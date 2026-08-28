---
title: Quản lý các đoạn văn bản PowerPoint trong Java
linktitle: Quản lý đoạn
type: docs
weight: 40
url: /vi/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
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
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tìm hiểu cách tạo và định dạng các đoạn, phần, dấu đầu dòng, danh sách đánh số, thụt lề, nội dung HTML và hình ảnh đoạn với Aspose.Slides cho Java."
---
## **Tổng quan**

Aspose.Slides for Java đại diện cho văn bản dưới dạng một hệ thống phân cấp gồm khung văn bản, đoạn và phần:

* [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/) đại diện cho vùng chứa văn bản trong một hình dạng và cung cấp quyền truy cập vào bộ sưu tập đoạn.
* [IParagraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraph/) đại diện cho một đoạn trong khung văn bản và cung cấp quyền truy cập vào các phần và định dạng ở mức đoạn.
* [IPortion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iportion/) đại diện cho một đoạn chạy văn bản trong một đoạn. Mỗi phần có thể có văn bản và định dạng ký tự riêng.

Do đó, một đoạn có thể chứa văn bản có các phông chữ, màu sắc, kích thước và định dạng khác nhau bằng cách sử dụng nhiều phần.

## **Tạo và Định dạng Đoạn Văn**

### **Tạo Đoạn Văn với Nhiều Phần**

Những bước sau tạo một khung văn bản với ba đoạn, mỗi đoạn chứa ba phần:

1. Tạo một đối tượng của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Truy cập slide liên quan qua chỉ mục của nó.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) hình chữ nhật vào slide.
4. Truy cập [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/) của hình.
5. Sử dụng đoạn mặc định và thêm hai đối tượng [IParagraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraph/) nữa vào khung văn bản.
6. Thêm đủ các đối tượng [IPortion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iportion/) cho mỗi đoạn để chứa ba phần. Đoạn mặc định đã chứa một phần trống.
7. Đặt văn bản cho mỗi phần.
8. Áp dụng định dạng ký tự thông qua [IPortion.getPortionFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iportion/#getPortionFormat--) .
9. Lưu bản trình chiếu đã sửa đổi.

Ví dụ Java này thực hiện các bước:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
    ITextFrame textFrame = shape.getTextFrame();

    IParagraph firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new Portion());
    firstParagraph.getPortions().add(new Portion());

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(secondParagraph);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    int paragraphCount = textFrame.getParagraphs().getCount();
    for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        IParagraph paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        int portionCount = paragraph.getPortions().getCount();
        for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tạo Danh Sách Đánh Dấu và Đánh Số**

### **Tạo danh sách có dấu đầu dòng hoặc đánh số**

Dấu đầu dòng và đánh số giúp các mục liên quan dễ dàng quét. Trong Aspose.Slides, cài đặt danh sách được định nghĩa thông qua [IBulletFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibulletformat/) .

1. Tạo một đối tượng của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Truy cập slide liên quan qua chỉ mục của nó.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào slide đã chọn.
4. Truy cập [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/) của hình.
5. Xóa đoạn mặc định khỏi khung văn bản.
6. Tạo một [Paragraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/paragraph/) cho một dấu đầu dòng ký hiệu.
7. Đặt [IBulletFormat.setType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibulletformat/#setType-int-) thành [BulletType.Symbol](https://reference.aspose.com/slides/vi/java/com.aspose.slides/bullettype/) và chỉ định ký tự dấu đầu dòng.
8. Đặt văn bản đoạn, thụt lề, màu dấu đầu dòng và chiều cao dấu đầu dòng.
9. Thêm đoạn vào khung văn bản.
10. Tạo một đoạn thứ hai và đặt [IBulletFormat.setType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibulletformat/#setType-int-) thành [BulletType.Numbered](https://reference.aspose.com/slides/vi/java/com.aspose.slides/bullettype/) .
11. Cấu hình kiểu dấu đầu dòng đánh số và thêm đoạn vào khung văn bản.
12. Lưu bản trình chiếu.

Ví dụ Java này tạo một dấu đầu dòng ký hiệu và một dấu đầu dòng đánh số:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph symbolParagraph = new Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    symbolParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    Paragraph numberedParagraph = new Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Sử dụng Dấu Đầu Dòng Hình Ảnh**

Dấu đầu dòng hình ảnh cho phép bạn sử dụng một hình tùy chỉnh thay cho ký hiệu hoặc số.

1. Tạo một đối tượng của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Truy cập slide liên quan qua chỉ mục của nó.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) và truy cập [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/) .
4. Xóa đoạn mặc định khỏi khung văn bản.
5. Tải hình ảnh dấu đầu dòng và thêm nó vào bộ sưu tập hình ảnh của bản trình chiếu dưới dạng một [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/) .
6. Tạo một [Paragraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/paragraph/) và đặt văn bản của nó.
7. Đặt [IBulletFormat.setType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibulletformat/#setType-int-) thành [BulletType.Picture](https://reference.aspose.com/slides/vi/java/com.aspose.slides/bullettype/) .
8. Gán hình ảnh qua [IBulletFormat.getPicture](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibulletformat/#getPicture--) và đặt chiều cao dấu đầu dòng.
9. Thêm đoạn vào khung văn bản.
10. Lưu bản trình chiếu đã sửa đổi.

Ví dụ Java này tạo một dấu đầu dòng hình ảnh:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage bulletImage = Images.fromFile("bullets.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **Tạo Danh Sách Đa Cấp**

Đặt [IParagraphFormat.setDepth](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setDepth-short-) để đặt các đoạn ở các cấp độ khác nhau của danh sách. Cấp độ trên cùng có độ sâu là `0` .

1. Tạo một [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) và truy cập một slide.
2. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) và xóa đoạn mặc định khỏi khung văn bản của nó.
3. Tạo bốn đoạn và cấu hình các ký hiệu dấu đầu dòng cho chúng.
4. Đặt giá trị [IParagraphFormat.setDepth](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setDepth-short-) của chúng thành `0`, `1`, `2`, và `3` .
5. Thêm các đoạn vào khung văn bản và lưu bản trình chiếu.

Ví dụ Java này tạo một danh sách có bốn cấp độ:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    IParagraph firstParagraph = new Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    firstParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setDepth((short) 0);

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    secondParagraph.getParagraphFormat().getBullet().setChar('-');
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setDepth((short) 1);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    thirdParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setDepth((short) 2);

    IParagraph fourthParagraph = new Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    fourthParagraph.getParagraphFormat().getBullet().setChar('-');
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    fourthParagraph.getParagraphFormat().setDepth((short) 3);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Bắt Đầu Các Mục Đánh Số Với Giá Trị Tùy Chỉnh**

Sử dụng [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) để đặt số ban đầu hiển thị cho một đoạn đánh số.

1. Tạo một [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) và thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) vào một slide.
2. Xóa đoạn mặc định khỏi khung văn bản của hình.
3. Tạo ba đoạn đánh số.
4. Đặt [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) thành `2`, `3`, và `7` cho các đoạn tương ứng.
5. Thêm các đoạn vào khung văn bản và lưu bản trình chiếu.

Ví dụ Java này gán một số bắt đầu tùy chỉnh cho mỗi đoạn:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 2);
    textFrame.getParagraphs().add(firstParagraph);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 3);
    textFrame.getParagraphs().add(secondParagraph);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 7);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kiểm Soát Bố Cục Đoạn Văn và Thuộc Tính Kết Thúc**

### **Đặt Thụt Lề Dòng Đầu**

Sử dụng [IParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setIndent-float-) để kiểm soát thụt lề dòng đầu của một đoạn văn. Phương thức này chỉ di chuyển dòng đầu tiên so với lề trái của đoạn. Giá trị dương đẩy dòng đầu sang phải, trong khi các dòng còn lại vẫn căn chỉnh với phần thân đoạn.

Sử dụng [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) khi bạn cần di chuyển toàn bộ đoạn. Sử dụng [IParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setIndent-float-) khi bạn chỉ cần di chuyển dòng đầu tiên.

Ví dụ dưới đây tạo một số đoạn và áp dụng các giá trị [IParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setIndent-float-) khác nhau để minh họa cách thụt lề dòng đầu ảnh hưởng đến bố cục đoạn.

1. Tạo một đối tượng của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Truy cập slide mục tiêu.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) hình chữ nhật vào slide.
4. Truy cập [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/) của hình và xóa đoạn mặc định.
5. Tạo một số đoạn và đặt các giá trị [IParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setIndent-float-) khác nhau cho chúng.
6. Thêm các đoạn vào khung văn bản.
7. Lưu bản trình chiếu đã sửa đổi.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Thụt lề dòng đầu của các đoạn](first_line_indent.png)

### **Đặt Thụt Lề Treo**

Thụt lề treo là một bố cục đoạn trong đó dòng đầu bắt đầu bên trái các dòng còn lại. Trong Aspose.Slides, bạn tạo hiệu ứng này bằng [IParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setIndent-float-). Đưa một giá trị âm để di chuyển dòng đầu sang trái so với phần thân đoạn.

Trong thực tế, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) xác định vị trí bên trái của phần thân đoạn, và [IParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setIndent-float-) xác định vị trí của dòng đầu so với lề đó. Để tạo thụt lề treo, đưa một giá trị dương cho `setMarginLeft` và một giá trị âm cho `setIndent`.

Định dạng này hữu ích cho thư mục, tham chiếu, mục lục và các đoạn khác mà các dòng gói cần căn dưới phần thân đoạn thay vì dưới ký tự đầu tiên của dòng đầu.

1. Tạo một đối tượng của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Truy cập slide mục tiêu.
3. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) hình chữ nhật vào slide.
4. Truy cập [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/) của hình và xóa đoạn mặc định.
5. Tạo các đoạn và đưa một giá trị dương cho [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) cho mỗi đoạn.
6. Đưa một giá trị âm cho [IParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setIndent-float-) để tạo hiệu ứng thụt lề treo.
7. Thêm các đoạn vào khung văn bản.
8. Lưu bản trình chiếu đã sửa đổi.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Thụt lề treo của các đoạn](hanging_indent.png)

### **Đặt Thuộc Tính Đoạn Kết Thúc**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) kiểm soát định dạng của ký hiệu kết thúc đoạn. Ví dụ sau gán kích thước phông chữ và phông Latin cho ký hiệu kết thúc của đoạn thứ hai:

1. Tải một [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) và truy cập một slide.
2. Thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) và xóa đoạn mặc định của nó.
3. Tạo hai đoạn và thêm các phần văn bản vào chúng.
4. Tạo một [PortionFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/portionformat/) cho ký hiệu kết thúc của đoạn thứ hai.
5. Đặt [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) và [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) .
6. Gán định dạng với [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) và lưu bản trình chiếu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getPortions().add(new Portion("Sample text"));

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion("Sample text 2"));

    PortionFormat endParagraphFormat = new PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nhập và Xuất Nội Dung Đoạn Văn**

### **Nhập Văn bản HTML vào Đoạn Văn**

Sử dụng [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/vi/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) để chuyển đổi mã HTML thành các đoạn và phần trong một khung văn bản.

1. Tạo một đối tượng của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Truy cập một slide và thêm một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) .
3. Truy cập [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/) của hình và xóa đoạn mặc định.
4. Đọc tệp HTML nguồn.
5. Chuyển chuỗi HTML tới [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/vi/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) .
6. Lưu bản trình chiếu đã sửa đổi.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    float shapeWidth = (float) presentation.getSlideSize().getSize().getWidth() - 20;
    float shapeHeight = (float) presentation.getSlideSize().getSize().getHeight() - 20;
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    try {
        byte[] htmlBytes = Files.readAllBytes(Paths.get("file.html"));
        String html = new String(htmlBytes, StandardCharsets.UTF_8);
        shape.getTextFrame().getParagraphs().addFromHtml(html);
        presentation.save("html_text.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("The HTML file could not be read: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Xuất Văn bản Đoạn sang HTML**

Sử dụng [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/vi/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) để xuất một dải đoạn đã chọn dưới dạng HTML.

1. Tạo một đối tượng của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) và tải bản trình chiếu mong muốn.
2. Truy cập slide và tìm [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) chứa văn bản.
3. Truy cập [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/) của hình.
4. Gọi [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/vi/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) với chỉ số đoạn bắt đầu và số lượng đoạn cần xuất.
5. Ghi chuỗi HTML trả về vào một tệp.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ExportingHTMLText.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            String html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            try {
                Files.write(Paths.get("paragraphs.html"), html.getBytes(StandardCharsets.UTF_8));
            } catch (IOException exception) {
                System.out.println("The HTML file could not be written: " + exception.getMessage());
            }
        } else {
            System.out.println("The first shape does not contain a text frame.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **Kết Xuất Đoạn Văn dưới Dạng Hình Ảnh**

[IParagraph.getImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraph/#getImage--) kết xuất trực tiếp một đoạn riêng lẻ và trả về một [IImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/). Lưu kết quả vào tệp hoặc luồng với [IImage.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/#save-java.lang.String-int-) . Bạn không cần phải kết xuất hình chứa hoặc cắt thủ công một bitmap.

[IParagraph.getImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraph/#getImage--) có thể trả về `null` nếu đoạn không thể tìm thấy trong bộ sưu tập cha, không có giới hạn vẽ hợp lệ, hoặc không thể được kết xuất. Kiểm tra kết quả trước khi lưu và giải phóng hình ảnh đã trả về sau khi sử dụng.

#### **Kết Xuất Đoạn Văn ở Tỷ Lệ Mặc Định**

Giả sử chúng ta có một tệp trình chiếu có tên sample.pptx với một slide, trong đó hình đầu tiên là một hộp văn bản chứa ba đoạn.

![Hộp văn bản với ba đoạn](paragraph_to_image_input.png)

Ví dụ sau kết xuất đoạn thứ hai trong một hình văn bản thường ở tỷ lệ mặc định và lưu hình trả về dưới dạng PNG. Khối `finally` đảm bảo rằng hình được giải phóng đúng cách.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null && textFrame.getParagraphs().getCount() > 1) {
            IParagraph paragraph = textFrame.getParagraphs().get_Item(1);
            IImage paragraphImage = paragraph.getImage();

            if (paragraphImage != null) {
                try {
                    paragraphImage.save("paragraph.png", ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                System.out.println("The paragraph could not be rendered.");
            }
        } else {
            System.out.println("The expected paragraph was not found.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình ảnh đoạn văn](paragraph_to_image_output.png)

#### **Kết Xuất Đoạn Văn trong Ô Bảng với Tỷ Lệ**

Sử dụng phương thức quá tải [IParagraph.getImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraph/#getImage-float-float-) chấp nhận các tham số `float scaleX` và `float scaleY` để đặt các hệ số tỷ lệ ngang và dọc. Ví dụ sau tạo một bảng, kết xuất đoạn trong ô đầu tiên với chiều rộng và chiều cao gấp đôi so với mặc định, và lưu kết quả dưới dạng PNG.

```java
import com.aspose.slides.*;

float scaleX = 2f;
float scaleY = 2f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = slide.getShapes().addTable(50, 50, new double[] { 300 }, new double[] { 80 });
    IParagraph paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    IImage paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage != null) {
        try {
            paragraphImage.save("table_paragraph.png", ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        System.out.println("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

Một hệ số `1` giữ kích thước pixel mặc định cho trục tương ứng. Ví dụ, `2` cho cả hai hệ số sẽ tạo ra một hình ảnh có chiều rộng và chiều cao khoảng gấp đôi kích thước mặc định, tức là có bốn lần số pixel. Hệ số lớn hơn thường cho văn bản sắc nét hơn khi phóng to hoặc xuất với độ phân giải cao, nhưng cũng làm tăng bộ nhớ và kích thước tệp. Hệ số dưới `1` tạo hình ảnh nhỏ hơn với ít chi tiết hơn. Sử dụng các hệ số bằng nhau để giữ tỉ lệ khía cạnh của đoạn; các hệ số ngang và dọc khác nhau sẽ kéo dài đầu ra một cách độc lập.

Kết xuất toàn bộ hình bằng [IShape.getImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getImage--) vẫn hữu ích khi đầu ra cần bao gồm màu nền, viền hoặc ngữ cảnh hình ảnh khác. Đối với hình chỉ chứa đoạn, hãy sử dụng [IParagraph.getImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraph/#getImage--) .

## **Câu hỏi thường gặp**

**Tôi có thể tắt hoàn toàn việc ngắt dòng trong khung văn bản không?**

Có. Đặt [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) để tắt việc ngắt dòng, vì vậy các dòng sẽ không bị cắt ở các cạnh của khung văn bản.

**Làm sao tôi có thể lấy kích thước chính xác trên slide của một đoạn cụ thể?**

Sử dụng [IParagraph.getRect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraph/#getRect--) để lấy hình chữ nhật bao quanh đoạn. [IPortion.getRect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iportion/#getRect--) cung cấp giới hạn của một phần riêng lẻ.

**Căn chỉnh đoạn (trái, phải, trung tâm, hoặc căn đều) được điều khiển ở đâu?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) là cài đặt ở mức đoạn và áp dụng cho toàn bộ đoạn bất kể định dạng phần riêng lẻ.

**Tôi có thể đặt ngôn ngữ kiểm tra chính tả cho một phần của đoạn không?**

Có. Đặt [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) cho các phần riêng lẻ, vì vậy một đoạn có thể chứa văn bản bằng nhiều ngôn ngữ.