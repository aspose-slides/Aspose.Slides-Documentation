---
title: Lấy Các Thuộc Tính Effective của Hình Dạng từ Bài Thuyết Trình trên Android
linktitle: Thuộc Tính Effective
type: docs
weight: 50
url: /vi/androidjava/shape-effective-properties/
keywords:
- thuộc tính hình dạng
- thuộc tính camera
- bộ đèn
- hình dạng bevel
- khung văn bản
- kiểu văn bản
- độ cao phông chữ
- định dạng tô đầy
- PowerPoint
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Khám phá cách Aspose.Slides cho Android bằng Java tính toán và áp dụng các thuộc tính hình dạng effective để render PowerPoint một cách chính xác."
---
## **Tổng quan**

Chủ đề này giải thích sự khác nhau giữa **local** và **effective** property. Giá trị local là các giá trị được đặt trực tiếp ở mức định dạng cụ thể, chẳng hạn như:

1. Thuộc tính phần trong một slide.
1. Kiểu văn bản hình dạng mẫu trên bố cục hoặc slide master, khi hình dạng khung văn bản của phần có một kiểu.
1. Cài đặt văn bản toàn cục trong một bài thuyết trình.

Giá trị local có thể được định nghĩa hoặc bỏ qua ở bất kỳ cấp nào. Khi Aspose.Slides cần định dạng cuối cùng "as rendered", nó sẽ giải quyết chuỗi kế thừa và trả về các giá trị **effective**. Bạn có thể lấy chúng bằng cách gọi phương thức `getEffective()` trên đối tượng định dạng local.

Ví dụ sau cho thấy cách lấy các giá trị **effective**. Nó giả định rằng hình dạng đầu tiên trên slide đầu tiên là một [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) có khung văn bản và ít nhất một phần.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrame textFrame = shape.getTextFrame();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrame.getTextFrameFormat().getEffective();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormatEffectiveData effectivePortionFormat = portion.getPortionFormat().getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Dữ liệu định dạng **effective** đại diện cho định dạng tính toán hiện tại sau khi đã áp dụng kế thừa. Trong triển khai hiện tại, một số đối tượng dữ liệu **effective**, chẳng hạn như [IPortionFormatEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iportionformateffectivedata/), có thể được lưu trong bộ nhớ đệm nội bộ. Gọi lại `getEffective()` sau khi thay đổi định dạng cha hoặc kế thừa có thể làm mới dữ liệu đã được lưu, và một đối tượng đã lấy trước đó có thể không còn phản ánh trạng thái trước nữa. Nếu bạn cần lưu giữ các giá trị **effective** để sử dụng lại sau, hãy sao chép các thuộc tính cần thiết, chẳng hạn như độ cao phông chữ, màu nền, kiểu phông chữ hoặc căn chỉnh, vào đối tượng dữ liệu của riêng bạn.
{{% /alert %}}

## **Lấy các thuộc tính Effective của Camera**

Aspose.Slides cho phép bạn lấy các thuộc tính **effective** của một camera. Giao diện [ICameraEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icameraeffectivedata/) đại diện cho một đối tượng bất biến chứa các thuộc tính camera **effective**. Một thể hiện của [ICameraEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icameraeffectivedata/) được cung cấp thông qua [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformateffectivedata/), cung cấp các giá trị **effective** cho [IThreeDFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/).

Ví dụ mã sau cho thấy cách lấy các thuộc tính **effective** cho camera. Nó giả định rằng hình dạng đầu tiên trên slide đầu tiên có định dạng 3D.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraEffectiveData.getCameraType());
    System.out.println("Field of view: " + cameraEffectiveData.getFieldOfViewAngle());
    System.out.println("Zoom: " + cameraEffectiveData.getZoom());
} finally {
    presentation.dispose();
}
```

## **Lấy các thuộc tính Effective của Light Rig**

Aspose.Slides cho phép bạn lấy các thuộc tính **effective** của một light rig. Giao diện [ILightRigEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilightrigeffectivedata/) đại diện cho một đối tượng bất biến chứa các thuộc tính light rig **effective**. Một thể hiện của [ILightRigEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilightrigeffectivedata/) được cung cấp thông qua [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformateffectivedata/), cung cấp các giá trị **effective** cho [IThreeDFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/).

Ví dụ mã sau cho thấy cách lấy các thuộc tính **effective** cho light rig. Nó giả định rằng hình dạng đầu tiên trên slide đầu tiên có định dạng 3D.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightRigEffectiveData.getLightType());
    System.out.println("Direction: " + lightRigEffectiveData.getDirection());
} finally {
    presentation.dispose();
}
```

## **Lấy các thuộc tính Effective của Hình dạng Bevel**

Aspose.Slides cho phép bạn lấy các thuộc tính **effective** của một bevel shape. Giao diện [IShapeBevelEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapebeveleffectivedata/) đại diện cho một đối tượng bất biến chứa các thuộc tính relief mặt cho một hình dạng. Một thể hiện của [IShapeBevelEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapebeveleffectivedata/) được cung cấp thông qua [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformateffectivedata/), cung cấp các giá trị **effective** cho [IThreeDFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/).

Ví dụ mã sau cho thấy cách lấy các thuộc tính **effective** cho bevel trên của một hình dạng. Nó giả định rằng hình dạng đầu tiên trên slide đầu tiên có định dạng 3D.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTopEffectiveData = threeDEffectiveData.getBevelTop();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelTopEffectiveData.getBevelType());
    System.out.println("Width: " + bevelTopEffectiveData.getWidth());
    System.out.println("Height: " + bevelTopEffectiveData.getHeight());
} finally {
    presentation.dispose();
}
```

## **Lấy các thuộc tính Effective của Khung Văn bản**

Sử dụng Aspose.Slides, bạn có thể lấy các thuộc tính **effective** của một khung văn bản. Giao diện [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframeformateffectivedata/) chứa các thuộc tính định dạng khung văn bản **effective**.

Ví dụ mã sau cho thấy cách lấy các thuộc tính định dạng **effective** của khung văn bản. Nó giả định rằng hình dạng đầu tiên trên slide đầu tiên là một [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) có khung văn bản.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("Margins");
    System.out.println("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   Top: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   Right: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    presentation.dispose();
}
```

## **Lấy các thuộc tính Effective của Kiểu Văn bản**

Sử dụng Aspose.Slides, bạn có thể lấy các thuộc tính **effective** của một kiểu văn bản. Giao diện [ITextStyleEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextstyleeffectivedata/) chứa các thuộc tính kiểu văn bản **effective**.

Ví dụ mã sau cho thấy cách lấy các thuộc tính **effective** của kiểu văn bản. Nó giả định rằng hình dạng đầu tiên trên slide đầu tiên là một [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) có khung văn bản.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);

        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    presentation.dispose();
}
```

## **Lấy Giá trị Độ cao Phông chữ Effective**

Sử dụng Aspose.Slides, bạn có thể lấy độ cao phông chữ **effective**. Đoạn mã sau minh họa cách độ cao phông chữ **effective** của một phần thay đổi sau khi giá trị độ cao phông chữ local được đặt ở các cấp cấu trúc bài thuyết trình khác nhau.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    IPortion firstPortion = new Portion("Sample text with first portion");
    IPortion secondPortion = new Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    IPortionFormatEffectiveData firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    IPortionFormatEffectiveData secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height just after creation:");
    double firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    double secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting the presentation default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting paragraph default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting portion #0 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height after setting portion #1 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lấy Định dạng Fill Effective cho Bảng**

Sử dụng Aspose.Slides, bạn có thể lấy định dạng fill **effective** cho các phần khác nhau của bảng. Giao diện [IFillFormatEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifillformateffectivedata/) chứa các thuộc tính định dạng fill **effective**. Định dạng ô có ưu tiên cao hơn định dạng hàng, định dạng hàng có ưu tiên cao hơn định dạng cột, và định dạng cột có ưu tiên cao hơn định dạng toàn bảng.

Do đó, các thuộc tính [ICellFormatEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icellformateffectivedata/) được sử dụng để vẽ ô bảng. Ví dụ mã sau cho thấy cách lấy định dạng fill **effective** cho các phần khác nhau của bảng. Nó giả định rằng hình dạng đầu tiên trên slide đầu tiên là một [ITable](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itable/).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);

    IRow row = table.getRows().get_Item(0);
    IColumn column = table.getColumns().get_Item(0);
    ICell cell = table.get_Item(0, 0);

    IFillFormatEffectiveData tableFillFormatEffective = table.getTableFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = row.getRowFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = column.getColumnFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cell.getCellFormat().getEffective().getFillFormat();
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**`getEffective()` có trả về một ảnh chụp nhanh không?**

Không phải luôn luôn. Dữ liệu **effective** đại diện cho định dạng đã tính toán sau khi áp dụng kế thừa, nhưng một số đối tượng dữ liệu **effective** có thể được lưu trong bộ nhớ đệm nội bộ. Một lần gọi `getEffective()` tiếp theo có thể tính lại định dạng và làm mới dữ liệu đã lưu, vì vậy một đối tượng đã lấy trước đó không nên được coi là một ảnh chụp nhanh bền vững.

**Khi nào tôi nên đọc lại các thuộc tính effective?**

Gọi lại `getEffective()` sau khi thay đổi định dạng local, kiểu cha, định dạng bố cục, định dạng master, hoặc các mặc định ở cấp trình bày. Lần gọi tiếp theo sẽ đánh giá lại cây định dạng và trả về kết quả **effective** hiện tại.

**Việc thay đổi hoặc xóa một slide bố cục/master có ảnh hưởng đến các thuộc tính effective đã được lấy trước không?**

Có, nhưng thay đổi sẽ được phản ánh trong lần gọi `getEffective()` tiếp theo. Nếu nguồn định dạng cha bị thay đổi hoặc xóa, dữ liệu **effective** đã lấy trước có thể lỗi thời. Khi `getEffective()` được gọi lại, Aspose.Slides sẽ đánh giá lại cây định dạng và các phông chữ, màu sắc, kích thước hoặc các giá trị khác có thể thay đổi.

**Tôi có thể sửa đổi giá trị thông qua các đối tượng dữ liệu effective không?**

Không. Các đối tượng dữ liệu **effective** chỉ cung cấp các giá trị đã tính toán. Thực hiện các thay đổi trong các đối tượng định dạng local, sau đó lấy lại các giá trị **effective**.

**Điều gì xảy ra nếu một thuộc tính không được đặt ở mức hình dạng, cũng không ở bố cục/master, hoặc trong cài đặt toàn cục?**

Giá trị **effective** được xác định bằng cơ chế mặc định, bao gồm các giá trị mặc định của PowerPoint và Aspose.Slides. Giá trị đã giải quyết đó trở thành một phần của dữ liệu **effective** hiện tại.

**Từ một giá trị phông chữ effective, tôi có thể biết được cấp độ nào đã cung cấp kích thước hoặc kiểu phông không?**

Không trực tiếp. Dữ liệu **effective** trả về giá trị cuối cùng. Để tìm nguồn, kiểm tra các giá trị local ở phần, đoạn, khung văn bản và các kiểu văn bản ở cấp bố cục, master và trình bày để xem nơi định nghĩa rõ ràng đầu tiên xuất hiện.

**Tại sao đôi khi giá trị effective trông giống hệt với giá trị local?**

Bởi vì giá trị local đã trở thành giá trị cuối cùng (không cần kế thừa ở cấp cao hơn). Trong những trường hợp đó, giá trị **effective** trùng khớp với giá trị local.

**Khi nào tôi nên sử dụng các thuộc tính effective, và khi nào chỉ nên làm việc với các thuộc tính local?**

Sử dụng dữ liệu **effective** khi bạn cần kết quả "as rendered" sau khi tất cả các mức kế thừa đã được áp dụng, chẳng hạn để căn chỉnh màu sắc, thụt lề hoặc kích thước. Nếu bạn cần giữ lại các giá trị này bất kể các thay đổi định dạng sau này, hãy sao chép các thuộc tính cần thiết vào đối tượng của riêng bạn. Nếu bạn cần thay đổi định dạng ở một cấp độ cụ thể, sửa đổi các thuộc tính local và sau đó, nếu cần, đọc lại dữ liệu **effective** để xác nhận kết quả.