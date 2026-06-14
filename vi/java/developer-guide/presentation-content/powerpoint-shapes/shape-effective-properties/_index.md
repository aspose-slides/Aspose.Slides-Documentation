---
title: Lấy Thuộc tính Hiệu lực của Hình dạng từ Bản trình chiếu trong Java
linktitle: Thuộc tính Hiệu lực
type: docs
weight: 50
url: /vi/java/shape-effective-properties/
keywords:
- thuộc tính hình dạng
- thuộc tính camera
- bộ ánh sáng
- hình dạng bevel
- khung văn bản
- kiểu văn bản
- chiều cao phông chữ
- định dạng đổ màu
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Khám phá cách Aspose.Slides cho Java tính toán và áp dụng các thuộc tính hiệu lực của hình dạng để hiển thị PowerPoint một cách chính xác."
---
## **Tổng quan**

Bài viết này giải thích sự khác nhau giữa các thuộc tính **cục bộ** và **hiệu lực**. Giá trị cục bộ là các giá trị được đặt trực tiếp ở một mức định dạng cụ thể, chẳng hạn như:

1. Thuộc tính đoạn trên một slide.  
1. Các kiểu văn bản hình dạng nguyên mẫu trên bố cục hoặc slide chủ, khi hình dạng khung văn bản của đoạn có một.  
1. Cài đặt văn bản toàn cục trong một bản thuyết trình.  

Giá trị cục bộ có thể được định nghĩa hoặc bỏ qua ở bất kỳ mức nào. Khi Aspose.Slides cần định dạng cuối cùng "được hiển thị", nó giải quyết chuỗi kế thừa và trả về các giá trị **hiệu lực**. Bạn có thể lấy chúng bằng cách gọi phương thức `getEffective` trên đối tượng định dạng cục bộ.

Ví dụ sau minh họa cách lấy các giá trị hiệu lực. Giả sử hình dạng đầu tiên trên slide đầu tiên là một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IAutoShape) có khung văn bản và ít nhất một đoạn.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = paragraph.getPortions().get_Item(0);
    IPortionFormat localPortionFormat = portion.getPortionFormat();
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Dữ liệu định dạng hiệu lực đại diện cho định dạng tính toán hiện tại sau khi áp dụng kế thừa. Trong triển khai hiện tại, một số đối tượng dữ liệu hiệu lực, như [IPortionFormatEffectiveData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IPortionFormatEffectiveData), có thể được lưu trong bộ nhớ đệm nội bộ. Gọi lại `getEffective` sau khi thay đổi định dạng cha hoặc kế thừa có thể làm mới dữ liệu đã cache, và một đối tượng đã lấy trước đó có thể không còn đại diện cho trạng thái trước đó. Nếu bạn cần bảo lưu các giá trị hiệu lực để sử dụng lại sau, sao chép các thuộc tính cần thiết, chẳng hạn như chiều cao phông chữ, màu nền, kiểu phông chữ hoặc căn chỉnh, vào đối tượng dữ liệu của riêng bạn.
{{% /alert %}}

## **Lấy Thuộc tính Hiệu lực của Camera**

Aspose.Slides cho phép bạn lấy các thuộc tính hiệu lực của camera. Giao diện [ICameraEffectiveData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICameraEffectiveData) đại diện cho một đối tượng bất biến chứa các thuộc tính camera hiệu lực. Một thể hiện [ICameraEffectiveData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICameraEffectiveData) được phơi bày thông qua [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IThreeDFormatEffectiveData), cung cấp các giá trị hiệu lực cho [IThreeDFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IThreeDFormat).

Mẫu mã dưới đây cho thấy cách lấy các thuộc tính hiệu lực cho camera. Giả sử hình dạng đầu tiên trên slide đầu tiên có định dạng 3D.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();
    int cameraType = cameraEffectiveData.getCameraType();
    double fieldOfViewAngle = cameraEffectiveData.getFieldOfViewAngle();
    double zoom = cameraEffectiveData.getZoom();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraType);
    System.out.println("Field of view: " + fieldOfViewAngle);
    System.out.println("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **Lấy Thuộc tính Hiệu lực của Light Rig**

Aspose.Slides cho phép bạn lấy các thuộc tính hiệu lực của Light Rig. Giao diện [ILightRigEffectiveData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ILightRigEffectiveData) đại diện cho một đối tượng bất biến chứa các thuộc tính Light Rig hiệu lực. Một thể hiện [ILightRigEffectiveData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ILightRigEffectiveData) được phơi bày thông qua [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IThreeDFormatEffectiveData), cung cấp các giá trị hiệu lực cho [IThreeDFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IThreeDFormat).

Mẫu mã dưới đây cho thấy cách lấy các thuộc tính hiệu lực cho Light Rig. Giả sử hình dạng đầu tiên trên slide đầu tiên có định dạng 3D.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();
    int lightType = lightRigEffectiveData.getLightType();
    int direction = lightRigEffectiveData.getDirection();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightType);
    System.out.println("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **Lấy Thuộc tính Hiệu lực của Đối tượng Bevel**

Aspose.Slides cho phép bạn lấy các thuộc tính hiệu lực của bevel hình dạng. Giao diện [IShapeBevelEffectiveData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeBevelEffectiveData) đại diện cho một đối tượng bất biến chứa các thuộc tính relief cho một hình dạng. Một thể hiện [IShapeBevelEffectiveData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShapeBevelEffectiveData) được phơi bày thông qua [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IThreeDFormatEffectiveData), cung cấp các giá trị hiệu lực cho [IThreeDFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IThreeDFormat).

Mẫu mã dưới đây cho thấy cách lấy các thuộc tính hiệu lực cho bevel trên cùng của một hình dạng. Giả sử hình dạng đầu tiên trên slide đầu tiên có định dạng 3D.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTop = threeDEffectiveData.getBevelTop();
    int bevelType = bevelTop.getBevelType();
    double bevelWidth = bevelTop.getWidth();
    double bevelHeight = bevelTop.getHeight();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelType);
    System.out.println("Width: " + bevelWidth);
    System.out.println("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **Lấy Thuộc tính Hiệu lực của Khung Văn bản**

Sử dụng Aspose.Slides, bạn có thể lấy các thuộc tính hiệu lực của khung văn bản. Giao diện [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ITextFrameFormatEffectiveData) chứa các thuộc tính định dạng khung văn bản hiệu lực.

Mẫu mã dưới đây cho thấy cách lấy các thuộc tính định dạng khung văn bản hiệu lực. Giả sử hình dạng đầu tiên trên slide đầu tiên là một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IAutoShape) có khung văn bản.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.getEffective();
    int anchoringType = effectiveTextFrameFormat.getAnchoringType();
    int autofitType = effectiveTextFrameFormat.getAutofitType();
    int textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    double marginLeft = effectiveTextFrameFormat.getMarginLeft();
    double marginTop = effectiveTextFrameFormat.getMarginTop();
    double marginRight = effectiveTextFrameFormat.getMarginRight();
    double marginBottom = effectiveTextFrameFormat.getMarginBottom();

    System.out.println("Anchoring type: " + anchoringType);
    System.out.println("Autofit type: " + autofitType);
    System.out.println("Text vertical type: " + textVerticalType);
    System.out.println("Margins");
    System.out.println("   Left: " + marginLeft);
    System.out.println("   Top: " + marginTop);
    System.out.println("   Right: " + marginRight);
    System.out.println("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **Lấy Thuộc tính Hiệu lực của Kiểu Văn bản**

Sử dụng Aspose.Slides, bạn có thể lấy các thuộc tính hiệu lực của kiểu văn bản. Giao diện [ITextStyleEffectiveData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ITextStyleEffectiveData) chứa các thuộc tính kiểu văn bản hiệu lực.

Mẫu mã dưới đây cho thấy cách lấy các thuộc tính kiểu văn bản hiệu lực. Giả sử hình dạng đầu tiên trên slide đầu tiên là một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IAutoShape) có khung văn bản.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);
    
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        int depth = effectiveStyleLevel.getDepth();
        double indent = effectiveStyleLevel.getIndent();
        int alignment = effectiveStyleLevel.getAlignment();
        int fontAlignment = effectiveStyleLevel.getFontAlignment();
        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + depth);
        System.out.println("Indent: " + indent);
        System.out.println("Alignment: " + alignment);
        System.out.println("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **Lấy Giá trị Chiều cao Phông chữ Hiệu lực**

Sử dụng Aspose.Slides, bạn có thể lấy chiều cao phông chữ hiệu lực. Mã dưới đây minh họa cách chiều cao phông chữ hiệu lực của một đoạn thay đổi sau khi các giá trị chiều cao phông chữ cục bộ được đặt ở các mức cấu trúc bản thuyết trình khác nhau.

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

## **Lấy Định dạng Đổ màu Hiệu lực cho Bảng**

Sử dụng Aspose.Slides, bạn có thể lấy định dạng đổ màu hiệu lực cho các phần khác nhau của bảng. Giao diện [IFillFormatEffectiveData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IFillFormatEffectiveData) chứa các thuộc tính định dạng đổ màu hiệu lực. Định dạng ô có ưu tiên cao hơn định dạng hàng, định dạng hàng cao hơn định dạng cột, và định dạng cột cao hơn định dạng toàn bảng.

Do đó, các thuộc tính của [ICellFormatEffectiveData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICellFormatEffectiveData) được sử dụng để vẽ ô bảng. Mẫu mã dưới đây cho thấy cách lấy định dạng đổ màu hiệu lực cho các phần khác nhau của bảng. Giả sử hình dạng đầu tiên trên slide đầu tiên là một [ITable](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ITable).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);
    
    ITableFormatEffectiveData tableFormatEffective = table.getTableFormat().getEffective();
    IRowFormatEffectiveData rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    IColumnFormatEffectiveData columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    ICellFormatEffectiveData cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**`getEffective` có trả về một bản sao không?**

Không phải luôn luôn. Dữ liệu hiệu lực đại diện cho định dạng đã tính toán sau khi áp dụng kế thừa, nhưng một số đối tượng dữ liệu hiệu lực có thể được lưu trong bộ nhớ đệm nội bộ. Một lời gọi `getEffective` tiếp theo có thể tính lại định dạng và làm mới dữ liệu đã cache, vì vậy một đối tượng đã lấy trước đó không nên được coi là một bản sao bền vững.

**Khi nào tôi nên đọc lại các thuộc tính hiệu lực?**

Gọi `getEffective` lại sau khi thay đổi định dạng cục bộ, kiểu cha, định dạng bố cục, định dạng master hoặc các mặc định ở mức bản thuyết trình. Lời gọi tiếp theo sẽ đánh giá lại cây định dạng và trả về kết quả hiệu lực hiện tại.

**Việc thay đổi hoặc xoá một slide bố cục/master có ảnh hưởng tới các thuộc tính hiệu lực đã được lấy trước không?**

Có, nhưng thay đổi sẽ được phản ánh ở lời gọi `getEffective` tiếp theo. Nếu nguồn định dạng cha bị thay đổi hoặc xoá, dữ liệu hiệu lực đã lấy trước có thể trở nên lỗi thời. Khi `getEffective` được gọi lại, Aspose.Slides sẽ đánh giá lại cây định dạng và các phông chữ, màu sắc, kích thước hoặc giá trị khác có thể thay đổi.

**Tôi có thể sửa đổi giá trị thông qua các đối tượng dữ liệu hiệu lực không?**

Không. Các đối tượng dữ liệu hiệu lực chỉ hiển thị các giá trị đã tính toán. Thực hiện thay đổi trong các đối tượng định dạng cục bộ, sau đó lại lấy các giá trị hiệu lực.

**Nếu một thuộc tính không được đặt ở mức hình dạng, cũng không ở bố cục/master, cũng không ở cài đặt toàn cục thì gì sẽ xảy ra?**

Giá trị hiệu lực được xác định bằng cơ chế mặc định, bao gồm các mặc định của PowerPoint và Aspose.Slides. Giá trị đã giải quyết sẽ trở thành một phần của dữ liệu hiệu lực hiện tại.

**Từ một giá trị phông chữ hiệu lực, tôi có thể biết mức nào đã cung cấp kích thước hoặc kiểu chữ không?**

Không trực tiếp. Dữ liệu hiệu lực chỉ trả về giá trị cuối cùng. Để tìm nguồn, kiểm tra các giá trị cục bộ ở đoạn, đoạn văn, khung văn bản và các kiểu văn bản ở mức bố cục, master và bản thuyết trình để xem nơi định nghĩa đầu tiên xuất hiện.

**Tại sao đôi khi các giá trị hiệu lực trông giống hệt với giá trị cục bộ?**

Bởi vì giá trị cục bộ đã trở thành giá trị cuối cùng (không cần kế thừa ở mức cao hơn). Trong các trường hợp đó, giá trị hiệu lực trùng với giá trị cục bộ.

**Khi nào tôi nên sử dụng thuộc tính hiệu lực, và khi nào chỉ làm việc với các thuộc tính cục bộ?**

Sử dụng dữ liệu hiệu lực khi bạn cần kết quả "được hiển thị" sau khi mọi kế thừa đã được áp dụng, chẳng hạn để đồng bộ màu sắc, thụt lề hoặc kích thước. Nếu bạn muốn bảo lưu các giá trị này bất chấp các thay đổi định dạng sau này, sao chép các thuộc tính cần thiết vào đối tượng riêng của bạn. Nếu bạn cần thay đổi định dạng ở một mức cụ thể, chỉnh sửa các thuộc tính cục bộ và sau đó, nếu cần, đọc lại dữ liệu hiệu lực để xác nhận kết quả.