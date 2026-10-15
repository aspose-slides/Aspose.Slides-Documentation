---
title: Quản lý đoạn văn bản PowerPoint trên Android
linktitle: Quản lý Đoạn
type: docs
weight: 40
url: /vi/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
  - /androidjava/portion/
keywords:
  - thêm văn bản
  - thêm đoạn
  - quản lý văn bản
  - quản lý đoạn
  - quản lý dấu đầu dòng
  - thụt đoạn
  - thụt treo
  - dấu đầu dòng đoạn
  - danh sách đánh số
  - danh sách dấu đầu dòng
  - thuộc tính đoạn
  - nhập HTML
  - văn bản sang HTML
  - đoạn sang HTML
  - đoạn sang hình ảnh
  - văn bản sang hình ảnh
  - xuất đoạn
  - PowerPoint
  - bản trình bày
  - Android
  - Java
  - Aspose.Slides
description: "Tìm hiểu cách tạo và định dạng các đoạn, phần, dấu đầu dòng, danh sách đánh số, thụt lề, nội dung HTML và hình ảnh đoạn với Aspose.Slides cho Android qua Java."
---
## **Tổng quan**

Aspose.Slides cho Android qua Java đại diện văn bản dưới dạng một cây phân cấp gồm các khung văn bản, đoạn văn và phần:

* [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) đại diện cho vùng chứa văn bản trong một hình dạng và cung cấp quyền truy cập vào bộ sưu tập đoạn văn của nó.
* [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) đại diện cho một đoạn văn trong khung văn bản và cung cấp quyền truy cập vào các phần và định dạng cấp đoạn.
* [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) đại diện cho một đoạn văn bản trong một đoạn. Mỗi phần có thể có văn bản và định dạng mức ký tự riêng.

Do đó, một đoạn văn có thể chứa văn bản với các phông chữ, màu sắc, kích thước và các định dạng khác nhau bằng cách sử dụng nhiều phần.

## **Tạo và Định dạng Đoạn văn**

Tạo các đoạn văn trong khung văn bản của một hình dạng và sử dụng các phần để định dạng các đoạn văn bản riêng lẻ. Phần này trình bày cách kết hợp nhiều phần trong mỗi đoạn và áp dụng các màu sắc, kích thước phông chữ và kiểu dáng khác nhau.

### **Tạo Đoạn Văn với Nhiều Phần**

Ví dụ Android qua Java sau tạo ba đoạn văn, mỗi đoạn chứa ba đoạn văn bản trong bộ sưu tập được trả về bởi [IParagraph.getPortions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getPortions--). Nó tái sử dụng đoạn mặc định và phần trống của nó, sau đó thêm các đoạn và phần còn lại. Định dạng được áp dụng qua [IPortion.getPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/#getPortionFormat--): phần đầu tiên trong mỗi đoạn có màu đỏ, đậm và kích thước 15 điểm; phần thứ hai có màu xanh, in nghiêng và kích thước 18 điểm. Phần thứ ba giữ định dạng mặc định của nó:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Tạo Danh sách Dấu đầu dòng và Đánh số**

Sắp xếp văn bản đoạn thành danh sách bằng ký hiệu, số hoặc hình ảnh tùy chỉnh. Các ví dụ trong phần này bao gồm định dạng dấu đầu dòng, danh sách đa cấp và số bắt đầu tùy chỉnh.

### **Tạo Danh sách Dấu đầu dòng hoặc Đánh số**

Dấu đầu dòng và đánh số giúp người dùng dễ dàng quét các mục liên quan. Trong Aspose.Slides, cài đặt danh sách được định nghĩa qua [IBulletFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/).

Ví dụ Android qua Java này thêm một dấu đầu dòng ký hiệu và một mục đánh số vào cùng một khung văn bản. [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) chọn loại dấu đầu dòng, trong khi [IBulletFormat.setChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setChar-char-) cung cấp ký hiệu và [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) chọn kiểu đánh số. Cả hai mục đều sử dụng dấu đầu dòng màu đen với độ cao 100% và thụt đoạn 25 điểm:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **Sử dụng Dấu đầu dòng Hình ảnh**

Dấu đầu dòng hình ảnh cho phép bạn sử dụng một hình ảnh tùy chỉnh thay vì ký hiệu hoặc số.

Ví dụ Android qua Java này thêm một hình ảnh vào bộ sưu tập hình ảnh của bản trình bày dưới dạng [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) và sử dụng nó làm dấu đầu dòng cho đoạn. Nó gọi [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) để sử dụng dấu đầu dòng hình ảnh và gán hình ảnh qua [IBulletFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#getPicture--). [IBulletFormat.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) được đặt thành 100% để kích thước dấu đầu dòng tương đối với văn bản đoạn:

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

### **Tạo Danh sách Đa cấp**

Đặt [IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) để đặt các đoạn ở các cấp độ khác nhau của danh sách. Cấp cao nhất có độ sâu `0`.

Ví dụ Android qua Java này gán các giá trị [IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) từ 0 đến 3 cho bốn đoạn, tạo ra một cây phân cấp trong một khung văn bản. Mỗi đoạn sử dụng dấu đầu dòng ký hiệu, với [IBulletFormat.setChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setChar-char-) thay đổi xen kẽ giữa dấu tròn và dấu gạch ngang để phân biệt các cấp độ liền kề:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **Bắt đầu các mục danh sách đánh số với Giá trị Tùy chỉnh**

Sử dụng [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) để đặt số đầu tiên hiển thị cho một đoạn đánh số.

Ví dụ Android qua Java này đặt [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) để sử dụng đánh số cho ba đoạn và gán các giá trị [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) là 2, 3 và 7. Giá trị bắt đầu được cấu hình riêng cho mỗi đoạn, cho phép các số hiển thị bỏ qua một số giá trị:

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

## **Kiểm soát Bố cục Đoạn và Thuộc tính Kết thúc**

Điều chỉnh lề và thụt lề của đoạn để kiểm soát vị trí của dòng đầu và các dòng gói. Bạn cũng có thể định dạng dấu kết thúc đoạn riêng biệt khỏi các phần văn bản hiển thị.

### **Đặt Thụt Dòng Dòng Đầu**

Sử dụng phương thức [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) để kiểm soát thụt dòng đầu tiên của một đoạn. Cài đặt này chỉ di chuyển dòng đầu tiên so với lề trái của đoạn. Giá trị dương dịch dòng đầu tiên sang phải, trong khi các dòng còn lại vẫn căn chỉnh với thân đoạn.

Sử dụng [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) khi cần di chuyển toàn bộ đoạn. Sử dụng [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) khi chỉ cần di chuyển dòng đầu tiên.

Ví dụ sau đặt ba đoạn cùng một giá trị [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) là 20 điểm và các giá trị [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) là 0, 20 và 40 điểm. Các dòng đầu tiên bắt đầu ở các khoảng cách ngày càng lớn, trong khi các dòng gói vẫn giữ cùng lề trái:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![Thụt dòng đầu của các đoạn](first_line_indent.png)

### **Đặt Thụt Dòng Treo**

Thụt dòng treo là một bố cục đoạn trong đó dòng đầu tiên bắt đầu bên trái các dòng còn lại. Trong Aspose.Slides, bạn tạo hiệu ứng này bằng thuộc tính [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). Đặt `Indent` thành giá trị âm để di chuyển dòng đầu tiên sang trái so với thân đoạn.

Thực tế, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) xác định vị trí bên trái của thân đoạn, và [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) xác định vị trí của dòng đầu tiên so với lề đó. Để tạo thụt dòng treo, đặt giá trị `MarginLeft` dương và giá trị `Indent` âm.

Định dạng này hữu ích cho thư mục, tham khảo, mục từ điển và các đoạn khác mà các dòng gói cần căn dưới thân đoạn thay vì dưới ký tự đầu tiên của dòng đầu.

Ví dụ Android qua Java sau kết hợp các giá trị [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) là 40 và 60 điểm với các giá trị [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) là -20 và -30 điểm. Trong mỗi đoạn, dòng đầu tiên bắt đầu bên trái các dòng gói; đoạn thứ hai có thụt dòng treo sâu hơn:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![Thụt dòng treo của các đoạn](hanging_indent.png)

### **Đặt Thuộc tính Chạy Kết thúc Đoạn**

Phương thức [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) kiểm soát định dạng của dấu kết thúc đoạn. Ví dụ sau tạo một [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/) với [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) được đặt thành 48 điểm và [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) được đặt thành Times New Roman. Nó gán định dạng này cho dấu kết thúc của đoạn thứ hai, để nguyên các phần văn bản hiển thị không thay đổi:

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

## **Đếm Số Dòng Được Hiển thị**

Đối với các quy tắc đoạn ảnh hưởng đến việc gói tự động và dấu câu ở cuối dòng, xem [Control Line Breaking](/slides/vi/androidjava/text-formatting/#control-line-breaking) và [Control Hanging Punctuation](/slides/vi/androidjava/text-formatting/#control-hanging-punctuation).

Sử dụng [IParagraph.getLinesCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) để đếm số dòng mà một đoạn chiếm sau khi bố trí văn bản, bao gồm việc gói tự động. Điều này hữu ích khi kiểm tra độ dài và bố cục văn bản trong các mẫu bản trình bày.

Một đoạn là một mục trong [ITextFrame.getParagraphs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParagraphs--) và nó có thể chiếm nhiều dòng hiển thị. Một ngắt dòng rõ ràng trong đoạn buộc tạo dòng mới mà không tạo đoạn mới. Gói tự động tạo các dòng dựa trên độ rộng có sẵn mà không chèn ký tự ngắt dòng vào văn bản. Do đó, việc đếm số đoạn hoặc ký tự ngắt dòng không cung cấp số dòng được hiển thị.

Ví dụ sau tạo một hình dạng văn bản, đếm các dòng của nó, thu hẹp hình dạng, và sau đó thay thế văn bản bằng một chuỗi ngắn hơn. Ví dụ này bật gói bằng [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) và tắt tự động vừa bằng [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) để độ rộng hình dạng kiểm soát việc gói mà không tự động thu nhỏ văn bản hoặc thay đổi kích thước hình dạng. Mỗi phép đo sử dụng [IParagraph.getLinesCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getLinesCount--). Kích thước hình dạng tính bằng điểm. Cuối cùng, ví dụ thêm một đoạn khác và cộng tổng số dòng trong khung văn bản.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    System.out.println("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    System.out.println("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    System.out.println("Shorter text: " + paragraph.getLinesCount());

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    int totalLineCount = 0;
    for (IParagraph currentParagraph : textFrame.getParagraphs()) {
        totalLineCount += currentParagraph.getLinesCount();
    }
    System.out.println("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

Với văn bản và các kích thước này, thu hẹp hình dạng làm tăng số dòng, trong khi thay thế văn bản bằng chuỗi ngắn giảm đi. Số đếm chính xác có thể thay đổi tùy thuộc vào sự khả dụng và thay thế phông chữ, kích thước phông, lề, thụt lề, gói và cài đặt tự động vừa. Hãy sử dụng các phông chữ và cài đặt bố cục dự định cho môi trường mục tiêu khi kiểm tra mẫu.

Số dòng một mình không quyết định liệu văn bản có tràn khỏi vùng chứa hay không. Chiều cao khả dụng, độ cao dòng, khoảng cách đoạn và dòng, và hành vi tự động vừa cũng quan trọng; ngay cả một dòng duy nhất cũng có thể vượt quá chiều rộng khả dụng khi tắt gói.

## **Nhập và Xuất Nội dung Đoạn**

Sử dụng HTML để đưa văn bản vào bản trình bày hoặc xuất các đoạn hiện có để sử dụng bên ngoài. Phần này cũng trình bày cách render các đoạn riêng lẻ thành hình ảnh, bao gồm các đoạn trong ô bảng.

### **Nhập Văn bản HTML vào Đoạn**

Sử dụng [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) để chuyển đổi mã HTML thành các đoạn và phần trong một khung văn bản.

Ví dụ Android qua Java này đọc HTML từ một tệp và truyền mã vào [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-). Nó xóa đoạn mặc định của khung văn bản để khung chỉ chứa nội dung đã nhập. Hình chữ nhật để lại lề 10 điểm ở mỗi cạnh của slide:

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

### **Xuất Văn bản Đoạn ra HTML**

Sử dụng [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) để xuất một phạm vi đoạn đã chọn dưới dạng HTML. Khi tái sử dụng văn bản bản trình bày trên một trang web, bạn có thể muốn giữ nguyên các nhấn mạnh nội địa mà không mang theo phông, kích thước hoặc kiểu hộp văn bản của bản trình bày. Đặt [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit-int-) để kiểm soát mức độ kế thừa định dạng của bộ xuất.

Tải xuống [bản mẫu](text-inheritance.pptx) và đặt nó vào thư mục làm việc của ứng dụng. Slide đầu tiên chứa một hình dạng văn bản với văn bản "Inherited text; explicit red 18pt". Đầu vào cố ý sử dụng nhiều cấp định dạng:

- Kiểu văn bản mặc định của bản trình bày cung cấp phông Calibri với kích thước 28 pt.
- Kiểu văn bản cấp một của khung văn bản cung cấp văn bản màu xanh và in nghiêng.
- Đoạn này đặt rõ ràng văn bản in đậm.
- Phần thứ hai, "explicit red 18pt", đặt rõ ràng văn bản màu đỏ và kích thước 18 pt.

Ví dụ đầy đủ sau xuất cùng các đoạn ba lần. Nó truyền [TextToHtmlConversionOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/texttohtmlconversionoptions/) vào phương thức xuất và ghi mỗi kết quả dưới dạng một tệp HTML UTF-8 riêng:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("text-inheritance.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            
            int[] modes = { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };
            String[] fileNames = { "All.html", "TextBox.html", "ParagraphOnly.html" };

            for (int i = 0; i < modes.length; i++) {
                TextToHtmlConversionOptions options = new TextToHtmlConversionOptions();
                options.setTextInheritanceLimit(modes[i]);

                String html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
                byte[] htmlBytes = html.getBytes(StandardCharsets.UTF_8);
                try {
                    Files.write(Paths.get(fileNames[i]), htmlBytes);
                } catch (IOException exception) {
                    System.out.println("The HTML file could not be written: " + exception.getMessage());
                }
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

HTML được tạo chứa CSS sau cho phần đầu tiên, "Inherited text; ". Bảng liệt kê các khai báo liên quan; các thuộc tính được tạo khác bị bỏ qua để rõ ràng.

| Đầu ra | CSS liên quan cho phần đầu tiên | Hiển thị |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Văn bản màu xanh, in đậm, in nghiêng kích thước 28 pt trong Calibri, nếu phông chữ đó khả dụng. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Văn bản màu xanh, in đậm, in nghiêng; trang hoặc trình duyệt bao quanh cung cấp phông chữ và kích thước. |
| `ParagraphOnly.html` | `font-weight:bold` | Văn bản in đậm; trang hoặc trình duyệt bao quanh cung cấp phông chữ, kích thước, màu và kiểu nghiêng. |

Phần thứ hai giữ nguyên `color:#ff0000`, `font-size:18pt`, và `font-weight:bold` trong cả ba đầu ra. Nó cũng giữ nguyên kiểu nghiêng với `All` và `TextBox`, nhưng không với `ParagraphOnly`. Do đó, việc hạn chế kế thừa không loại bỏ định dạng được gán rõ ràng cho một đoạn hoặc phần.

Mở các tệp trong cùng một trình duyệt để so sánh chúng. Trong hai chế độ bị giới hạn, các thuộc tính CSS bị bỏ qua sẽ được giải quyết bởi kiểu của trang đích hoặc cài đặt mặc định của trình duyệt, vì vậy giao diện kết quả phụ thuộc vào nơi HTML được sử dụng.

### **Render một Đoạn dưới dạng Hình ảnh**

[IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) render một đoạn riêng trực tiếp và trả về một [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/). Lưu kết quả vào tệp hoặc luồng bằng [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). Bạn không cần render hình dạng chứa hoặc cắt bitmap theo cách thủ công.

[IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) có thể trả về `null` nếu đoạn không tìm thấy trong bộ sưu tập cha, không có giới hạn render hợp lệ, hoặc không thể render. Kiểm tra kết quả trước khi lưu và giải phóng ảnh đã trả về sau khi sử dụng.

#### **Render một Đoạn ở Tỷ lệ Mặc định**

Ví dụ sử dụng một bản trình bày có một slide, trong đó hình dạng đầu tiên là một hộp văn bản chứa ba đoạn.

![Hộp văn bản với ba đoạn](paragraph_to_image_input.png)

Ví dụ sau chọn đoạn thứ hai tại chỉ mục 1 và gọi [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) mà không có tham số tỷ lệ. Nó kiểm tra rằng hình dạng chứa đoạn yêu cầu và việc render trả về một ảnh trước khi gọi [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) để lưu dưới định dạng PNG. Khối `finally` giải phóng ảnh sau khi sử dụng.

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

![Hình ảnh đoạn](paragraph_to_image_output.png)

#### **Render một Đoạn trong Ô Bảng với Tỷ lệ**

Sử dụng phiên bản [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) chấp nhận các tham số `float scaleX` và `float scaleY` để đặt hệ số tỷ lệ ngang và dọc. Ví dụ sau tạo một bảng, render đoạn trong ô đầu tiên với độ rộng và chiều cao gấp đôi mặc định, và lưu kết quả dưới dạng ảnh PNG.

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

Hệ số tỷ lệ `1` giữ trục đó ở kích thước pixel mặc định. Ví dụ, `2` cho cả hai hệ số tạo ra một ảnh có chiều rộng và chiều cao khoảng gấp đôi kích thước mặc định, dẫn đến bốn lần số pixel. Các hệ số lớn hơn thường tạo ra văn bản sắc nét hơn cho việc phóng to hoặc xuất khẩu độ phân giải cao, nhưng chúng cũng tăng việc sử dụng bộ nhớ và kích thước tệp. Các hệ số dưới `1` tạo ra ảnh nhỏ hơn với ít chi tiết hơn. Sử dụng các hệ số bằng nhau để giữ tỉ lệ khung của đoạn; các hệ số ngang và dọc khác nhau sẽ kéo dài đầu ra một cách độc lập.

Render toàn bộ hình dạng bằng [IShape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getImage--) vẫn hữu ích khi đầu ra cần bao gồm nền, viền hoặc ngữ cảnh hình ảnh khác của hình dạng. Đối với ảnh chỉ chứa đoạn, sử dụng [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--).

## **Câu hỏi thường gặp**

**Tôi có thể hoàn toàn tắt việc gói dòng bên trong khung văn bản không?**

Có. Đặt [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) để tắt việc gói, để các dòng không bị ngắt ở các cạnh của khung văn bản.

**Làm thế nào để tôi lấy được giới hạn chính xác trên slide của một đoạn cụ thể?**

Sử dụng [IParagraph.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getRect--) để lấy hình chữ nhật bao quanh của đoạn. [IPortion.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/#getRect--) cung cấp giới hạn của một phần riêng lẻ.

**Căn chỉnh đoạn (trái, phải, giữa, hoặc canh đều) được kiểm soát ở đâu?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) là cài đặt cấp đoạn và áp dụng cho toàn bộ đoạn bất kể định dạng của các phần riêng lẻ. Để căn chỉnh theo chiều dọc các phần có kích thước phông chữ khác nhau trong mỗi dòng, xem [Căn chỉnh phông chữ trong một dòng](/slides/vi/androidjava/text-formatting/#align-fonts-within-a-line).

**Tôi có thể đặt ngôn ngữ kiểm tra chính tả cho một phần của đoạn không?**

Có. Đặt [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) cho các phần riêng lẻ, để một đoạn có thể chứa văn bản bằng nhiều ngôn ngữ.