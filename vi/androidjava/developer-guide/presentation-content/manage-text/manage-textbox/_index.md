---
title: Quản lý Hộp Văn Bản trong Bản Trình Bày trên Android
linktitle: Quản lý Hộp Văn Bản
type: docs
weight: 20
url: /vi/androidjava/manage-textbox/
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
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides cho Android qua Java giúp dễ dàng tạo, chỉnh sửa và sao chép hộp văn bản trong các tệp PowerPoint và OpenDocument, nâng cao khả năng tự động hoá bản trình bày."
---
## **Giới thiệu**

Văn bản trên các slide thường nằm trong các hộp văn bản hoặc hình dạng. Do đó, để thêm một văn bản vào slide, bạn phải thêm một hộp văn bản và sau đó đặt một số văn bản bên trong hộp. Aspose.Slides cho Android qua Java cung cấp giao diện [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IAutoShape) cho phép bạn thêm một hình dạng chứa một số văn bản.

{{% alert title="Thông tin" color="info" %}}

Aspose.Slides cũng cung cấp giao diện [IShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShape) cho phép bạn thêm các hình dạng vào slide. Tuy nhiên, không phải tất cả các hình dạng được thêm qua giao diện `IShape` đều có thể chứa văn bản. Nhưng các hình dạng được thêm qua giao diện [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IAutoShape) có thể chứa văn bản.

{{% /alert %}}

{{% alert title="Lưu ý" color="warning" %}} 

Do vậy, khi làm việc với một hình dạng mà bạn muốn thêm văn bản, bạn có thể muốn kiểm tra và xác nhận rằng nó đã được ép kiểu qua giao diện `IAutoShape`. Chỉ khi đó bạn mới có thể làm việc với [TextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/TextFrame), một thuộc tính dưới `IAutoShape`. Xem phần [Cập nhật văn bản](https://docs.aspose.com/slides/vi/androidjava/manage-textbox/#update-text) trên trang này.

{{% /alert %}}

## **Tạo một Hộp Văn Bản trên Slide**

Để tạo một hộp văn bản trên slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy một tham chiếu cho slide đầu tiên trong bản trình bày mới tạo. 
3. Thêm một đối tượng [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IAutoShape) với [ShapeType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) được đặt là `Rectangle` tại vị trí xác định trên slide và lấy tham chiếu cho đối tượng `IAutoShape` vừa thêm.
4. Thêm thuộc tính `TextFrame` vào đối tượng `IAutoShape` sẽ chứa văn bản. Trong ví dụ dưới đây, chúng tôi đã thêm văn bản: *Aspose TextBox*
5. Cuối cùng, ghi tệp PPTX thông qua đối tượng `Presentation`. 

Mã Java—một triển khai của các bước trên—cho bạn biết cách thêm văn bản vào slide:

```java
import com.aspose.slides.*;

// Khởi tạo Presentation
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên trong bản trình bày
    ISlide sld = pres.getSlides().get_Item(0);

    // Thêm AutoShape với kiểu được đặt là Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Thêm TextFrame vào Rectangle
    ashp.addTextFrame(" ");

    // Truy cập khung văn bản
    ITextFrame txtFrame = ashp.getTextFrame();

    // Tạo đối tượng Paragraph cho khung văn bản
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Tạo đối tượng Portion cho đoạn văn
    IPortion portion = para.getPortions().get_Item(0);

    // Đặt văn bản
    portion.setText("Aspose TextBox");

    // Lưu bản trình bày vào đĩa
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Kiểm tra Hình Dạng Hộp Văn Bản**

Aspose.Slides cung cấp phương thức [isTextBox](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/#isTextBox--) từ giao diện [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) cho phép bạn kiểm tra các hình dạng và xác định các hộp văn bản.

![Text box and shape](istextbox.png)

Mã Java này cho bạn biết cách kiểm tra xem một hình dạng có được tạo dưới dạng hộp văn bản hay không: 

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ForEach.shape(presentation, (shape, slide, index) -> {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            System.out.println(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

Lưu ý rằng nếu bạn chỉ thêm một autoshape bằng phương thức `addAutoShape` từ giao diện [IShapeCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapecollection/), phương thức `isTextBox` của autoshape sẽ trả về `false`. Tuy nhiên, sau khi bạn thêm văn bản vào autoshape bằng phương thức `addTextFrame` hoặc phương thức `setText`, thuộc tính `isTextBox` sẽ trả về `true`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() trả về false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() trả về true

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() trả về false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() trả về true

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() trả về false
shape3.addTextFrame("");
// shape3.isTextBox() trả về false

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() trả về false
shape4.getTextFrame().setText("");
// shape4.isTextBox() trả về false
```

## **Tìm Kiếm Hình Dạng Sở Hữu Text Frame**

Trong mã xử lý văn bản chung, bạn có thể nhận được một [ITextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/) mà chưa biết đối tượng bản trình bày nào chứa nó. Sử dụng phương thức [ITextFrame.getParentShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#getParentShape--) để quay lại hình dạng sở hữu [IShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/).

Đối với một text frame thuộc về một [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) hoặc một hình dạng khác chứa văn bản, [ITextFrame.getParentShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#getParentShape--) trả về chủ sở hữu và [ITextFrame.getParentCell](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#getParentCell--) trả về `null`. Cả hai phương thức đều cung cấp khả năng điều hướng chỉ đọc, vì vậy việc gọi chúng không thay đổi quyền sở hữu. Luôn kiểm tra giá trị trả về có phải `null` trước khi truy cập hình dạng.

Đối với một ví dụ hoàn chỉnh xác định chủ sở hữu hình dạng và ô bảng, bao gồm các hình dạng liên quan tới nút SmartArt, xem mục [Search and Replace Text](/slides/vi/androidjava/search-and-replace-text/).

## **Thêm Cột vào Hộp Văn Bản**

Aspose.Slides cung cấp các thuộc tính [ColumnCount](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) và [ColumnSpacing](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (từ giao diện [ITextFrameFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITextFrameFormat) và lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/TextFrameFormat)) cho phép bạn thêm cột vào hộp văn bản. Bạn có thể chỉ định số lượng cột trong hộp văn bản và đặt khoảng cách (điểm) giữa các cột.

Mã Java dưới đây minh họa thao tác đã mô tả: 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên trong bản trình bày
    ISlide slide = pres.getSlides().get_Item(0);

    // Thêm một AutoShape với kiểu được đặt là Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Thêm TextFrame vào Rectangle
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // Lấy định dạng văn bản của TextFrame
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // Xác định số cột trong TextFrame
    format.setColumnCount(3);

    // Xác định khoảng cách giữa các cột
    format.setColumnSpacing(10);

    // Lưu bản trình bày
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thêm Cột vào Text Frame**
Aspose.Slides cho Android qua Java cung cấp thuộc tính [ColumnCount](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (từ giao diện [ITextFrameFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITextFrameFormat)) cho phép bạn thêm cột trong text frame. Thông qua thuộc tính này, bạn có thể chỉ định số lượng cột mong muốn trong một text frame.

Mã Java này cho bạn biết cách thêm một cột vào trong text frame:

```java
import com.aspose.slides.*;

String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0));
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Cập nhật Văn bản**

Aspose.Slides cho phép bạn thay đổi hoặc cập nhật văn bản chứa trong một hộp văn bản hoặc tất cả các văn bản trong một bản trình bày. 

Mã Java này minh họa một thao tác trong đó tất cả các văn bản trong một bản trình bày được cập nhật hoặc thay đổi:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //Kiểm tra xem hình dạng có hỗ trợ khung văn bản (IAutoShape) hay không.
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //Duyệt qua các đoạn trong khung văn bản
                {
                    for (IPortion portion : paragraph.getPortions()) //Duyệt qua từng phần trong đoạn văn
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Thay đổi văn bản
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Thay đổi định dạng
                    }
                }
            }
        }
    }

    //Lưu bản trình bày đã sửa đổi
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thêm Hộp Văn Bản có Siêu Liên Kết** 

Bạn có thể chèn một liên kết bên trong một hộp văn bản. Khi người dùng nhấp vào hộp văn bản, họ sẽ được chuyển tới liên kết.

Để thêm một hộp văn bản chứa liên kết, thực hiện các bước sau:

1. Tạo một thể hiện của lớp `Presentation`. 
2. Lấy một tham chiếu cho slide đầu tiên trong bản trình bày mới tạo. 
3. Thêm một đối tượng `AutoShape` với `ShapeType` được đặt là `Rectangle` tại vị trí xác định trên slide và lấy tham chiếu của đối tượng AutoShape vừa thêm.
4. Thêm một `TextFrame` vào đối tượng `AutoShape` và đặt văn bản cho phần đầu tiên của nó. Trong ví dụ dưới đây, chúng tôi đã sử dụng văn bản: *Aspose.Slides*
5. Lấy đối tượng [IHyperlinkManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlinkmanager/) từ `PortionFormat` của phần bạn muốn trong `TextFrame`.
6. Gọi [setExternalHyperlinkClick](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) trên đối tượng đó để thiết lập liên kết sẽ mở khi văn bản được nhấp.
7. Cuối cùng, ghi tệp PPTX thông qua đối tượng `Presentation`. 

Mã Java—một triển khai của các bước trên—cho bạn biết cách thêm một hộp văn bản có siêu liên kết vào slide:

```java
import com.aspose.slides.*;

// Khởi tạo một lớp Presentation đại diện cho file PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên trong bản trình bày
    ISlide slide = pres.getSlides().get_Item(0);

    // Thêm một đối tượng AutoShape với loại được đặt là Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Ép kiểu hình dạng sang AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Truy cập thuộc tính ITextFrame liên kết với AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Thêm một số văn bản vào khung
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Đặt siêu liên kết cho văn bản phần
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Lưu bản trình bày PPTX
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Sự khác nhau giữa hộp văn bản và placeholder văn bản khi làm việc với master slides là gì?**

Một [placeholder](/slides/vi/androidjava/manage-placeholder/) kế thừa kiểu dáng/vị trí từ [master](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/masterslide/) và có thể được ghi đè trên [layouts](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/layoutslide/), trong khi một hộp văn bản thường là một đối tượng độc lập trên một slide cụ thể và không thay đổi khi bạn chuyển layout.

**Làm thế nào để thực hiện thay thế văn bản hàng loạt trên toàn bộ bản trình bày mà không ảnh hưởng đến văn bản trong biểu đồ, bảng và SmartArt?**

Hạn chế vòng lặp của bạn chỉ đối với các auto‑shape có text frame và loại trừ các đối tượng nhúng ([charts](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/smartart/)) bằng cách duyệt các bộ sưu tập của chúng riêng biệt hoặc bỏ qua các loại đối tượng đó.