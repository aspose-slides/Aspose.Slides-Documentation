---
title: Quản lý Hộp Văn Bản trong Bản Trình Chiếu bằng Java
linktitle: Quản lý Hộp Văn Bản
type: docs
weight: 20
url: /vi/java/manage-textbox/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java giúp bạn dễ dàng tạo, chỉnh sửa và sao chép hộp văn bản trong các tệp PowerPoint và OpenDocument, nâng cao khả năng tự động hoá bản trình chiếu của bạn."
---
## **Giới thiệu**

Văn bản trên các slide thường tồn tại trong các hộp văn bản hoặc hình dạng. Do đó, để thêm văn bản vào một slide, bạn phải thêm một hộp văn bản và sau đó đặt một số văn bản vào trong hộp văn bản. Aspose.Slides for Java cung cấp giao diện [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IAutoShape) cho phép bạn thêm một hình dạng chứa văn bản.

{{% alert title="Info" color="info" %}}
Aspose.Slides cũng cung cấp giao diện [IShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShape) cho phép bạn thêm các hình dạng vào slide. Tuy nhiên, không phải tất cả các hình dạng được thêm thông qua giao diện `IShape` đều có thể chứa văn bản. Nhưng các hình dạng được thêm thông qua giao diện [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IAutoShape) có thể chứa văn bản. 
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Do đó, khi làm việc với một hình dạng mà bạn muốn thêm văn bản, bạn có thể muốn kiểm tra và xác nhận rằng nó đã được ép kiểu qua giao diện `IAutoShape`. Chỉ khi đó bạn mới có thể làm việc với [TextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/TextFrame), là một thuộc tính dưới `IAutoShape`. Xem phần [Update Text](https://docs.aspose.com/slides/vi/java/manage-textbox/#update-text) trên trang này. 
{{% /alert %}}

## **Tạo một Hộp Văn Bản trên Slide**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation). 
2. Lấy tham chiếu đến slide đầu tiên trong bản trình chiếu mới tạo. 
3. Thêm một đối tượng [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IAutoShape) với [ShapeType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IGeometryShape#setShapeType-int-) được đặt là `Rectangle` tại vị trí xác định trên slide và lấy tham chiếu đến đối tượng `IAutoShape` mới thêm. 
4. Thêm thuộc tính `TextFrame` vào đối tượng `IAutoShape` sẽ chứa văn bản. Trong ví dụ dưới đây, chúng tôi đã thêm văn bản này: *Aspose TextBox*
5. Cuối cùng, ghi tệp PPTX thông qua đối tượng `Presentation`. 

Mã Java này—một triển khai của các bước trên—cho bạn thấy cách thêm văn bản vào slide:

```java
// Khởi tạo Presentation
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên trong bản trình chiếu
    ISlide sld = pres.getSlides().get_Item(0);

    // Thêm AutoShape với loại được đặt là Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Thêm TextFrame vào Rectangle
    ashp.addTextFrame(" ");

    // Truy cập khung văn bản
    ITextFrame txtFrame = ashp.getTextFrame();

    // Tạo đối tượng Paragraph cho khung văn bản
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Tạo đối tượng Portion cho đoạn văn
    IPortion portion = para.getPortions().get_Item(0);

    // Đặt Văn bản
    portion.setText("Aspose TextBox");

    // Lưu bản trình chiếu vào đĩa
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Kiểm tra Hình dạng Hộp Văn Bản**

Aspose.Slides cung cấp phương thức [isTextBox](https://reference.aspose.com/slides/vi/java/com.aspose.slides/autoshape/#isTextBox--) từ giao diện [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) , cho phép bạn kiểm tra các hình dạng và xác định các hộp văn bản.

![Hộp văn bản và hình dạng](istextbox.png)

Mã Java này cho bạn thấy cách kiểm tra xem một hình dạng có được tạo dưới dạng hộp văn bản hay không: 

```java
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

Lưu ý rằng nếu bạn chỉ thêm một autoshape bằng phương thức `addAutoShape` từ giao diện [IShapeCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/) , phương thức `isTextBox` của autoshape sẽ trả về `false`. Tuy nhiên, sau khi bạn thêm văn bản vào autoshape bằng phương thức `addTextFrame` hoặc phương thức `setText`, thuộc tính `isTextBox` sẽ trả về `true`.

```java
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

## **Thêm Cột vào Hộp Văn Bản**

Aspose.Slides cung cấp các thuộc tính [ColumnCount](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) và [ColumnSpacing](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (từ giao diện [ITextFrameFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ITextFrameFormat) và lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/TextFrameFormat) ) cho phép bạn thêm cột vào hộp văn bản. Bạn có thể chỉ định số lượng cột trong một hộp văn bản và đặt khoảng cách giữa các cột tính bằng điểm.

Mã Java này minh họa thao tác đã mô tả: 

```java
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên trong bản trình chiếu
    ISlide slide = pres.getSlides().get_Item(0);

    // Thêm AutoShape với loại được đặt là Rectangle
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

    // Lưu bản trình chiếu
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thêm Cột vào Khung Văn Bản**
Aspose.Slides for Java cung cấp thuộc tính [ColumnCount](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (từ giao diện [ITextFrameFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ITextFrameFormat) ) cho phép bạn thêm cột trong khung văn bản. Thông qua thuộc tính này, bạn có thể chỉ định số lượng cột mong muốn trong một khung văn bản. 

Mã Java này cho bạn thấy cách thêm một cột trong khung văn bản:

```java
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
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(Double.NaN == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Cập nhật Văn Bản**

Aspose.Slides cho phép bạn thay đổi hoặc cập nhật văn bản chứa trong hộp văn bản hoặc tất cả các văn bản trong một bản trình chiếu. 

Mã Java này minh họa một thao tác mà trong đó tất cả các văn bản trong một bản trình chiếu được cập nhật hoặc thay đổi:

```java
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
                    for (IPortion portion : paragraph.getPortions()) //Duyệt qua từng phần trong đoạn
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Thay đổi văn bản
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Thay đổi định dạng
                    }
                }
            }
        }
    }

    //Lưu bản trình chiếu đã chỉnh sửa
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thêm Hộp Văn Bản với Siêu Liên Kết** 

Bạn có thể chèn một liên kết vào trong hộp văn bản. Khi hộp văn bản được nhấp, người dùng sẽ được chuyển đến mở liên kết. 

Để thêm một hộp văn bản chứa liên kết, thực hiện các bước sau:

1. Tạo một thể hiện của lớp `Presentation`. 
2. Lấy tham chiếu đến slide đầu tiên trong bản trình chiếu mới tạo. 
3. Thêm một đối tượng `AutoShape` với `ShapeType` được đặt là `Rectangle` tại vị trí xác định trên slide và lấy tham chiếu đến đối tượng AutoShape mới thêm. 
4. Thêm một `TextFrame` vào đối tượng `AutoShape` chứa *Aspose TextBox* làm văn bản mặc định. 
5. Khởi tạo lớp `IHyperlinkManager`. 
6. Gán đối tượng `IHyperlinkManager` vào thuộc tính [HyperlinkClick](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Shape#getHyperlinkClick--) liên kết với phần bạn muốn trong `TextFrame`. 
7. Cuối cùng, ghi tệp PPTX thông qua đối tượng `Presentation`. 

Mã Java này—một triển khai của các bước trên—cho bạn thấy cách thêm một hộp văn bản với siêu liên kết vào slide:

```java
// Khởi tạo một lớp Presentation đại diện cho file PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên trong bản trình chiếu
    ISlide slide = pres.getSlides().get_Item(0);

    // Thêm một đối tượng AutoShape với loại được đặt là Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Ép kiểu hình dạng thành AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Truy cập thuộc tính ITextFrame liên quan đến AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Thêm một số văn bản vào khung
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Đặt Hyperlink cho đoạn văn bản
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Lưu bản trình chiếu PPTX
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Sự khác biệt giữa hộp văn bản và trình giữ chỗ văn bản khi làm việc với các slide master là gì?**

Một [placeholder](/slides/vi/java/manage-placeholder/) kế thừa kiểu dáng/vị trí từ [master](https://reference.aspose.com/slides/vi/java/com.aspose.slides/masterslide/) và có thể bị ghi đè trên [layouts](https://reference.aspose.com/slides/vi/java/com.aspose.slides/layoutslide/), trong khi một hộp văn bản thông thường là một đối tượng độc lập trên một slide cụ thể và không thay đổi khi bạn chuyển đổi layout.

**Làm thế nào để thực hiện việc thay thế văn bản hàng loạt trên toàn bộ bản trình chiếu mà không ảnh hưởng đến văn bản bên trong biểu đồ, bảng và SmartArt?**

Hạn chế vòng lặp của bạn chỉ với các auto-shape có khung văn bản và loại trừ các đối tượng nhúng ([charts](https://reference.aspose.com/slides/vi/java/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/vi/java/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/smartart/)) bằng cách duyệt các bộ sưu tập của chúng riêng biệt hoặc bỏ qua các loại đối tượng đó.