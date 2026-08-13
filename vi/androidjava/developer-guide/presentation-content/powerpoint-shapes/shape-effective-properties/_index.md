---
title: Lấy Thuộc tính Effective của Shape từ Bài thuyết trình trên Android
linktitle: Thuộc tính Effective
type: docs
weight: 50
url: /vi/androidjava/shape-effective-properties/
keywords:
- thuộc tính shape
- thuộc tính camera
- light rig
- shape bevel
- khung văn bản
- kiểu văn bản
- chiều cao phông chữ
- định dạng đổ màu
- PowerPoint
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Khám phá cách Aspose.Slides cho Android qua Java tính toán và áp dụng các thuộc tính shape effective để hiển thị PowerPoint một cách chính xác."
---
## **Tổng quan**

Bài viết này giải thích sự khác biệt giữa các thuộc tính **local** và **effective**. Giá trị local là các giá trị được đặt trực tiếp ở một mức định dạng cụ thể, chẳng hạn như:

1. Thuộc tính portion trên một slide.  
2. Kiểu văn bản hình dạng prototype trên một bố cục hoặc slide master, khi shape khung văn bản của portion có một.  
3. Cài đặt văn bản toàn cục trong một bài thuyết trình.

Giá trị local có thể được định nghĩa hoặc bỏ qua ở bất kỳ mức nào. Khi Aspose.Slides cần định dạng cuối cùng "as rendered", nó giải quyết chuỗi kế thừa và trả về các giá trị **effective**. Bạn có thể lấy chúng bằng cách gọi phương thức `getEffective()` trên đối tượng định dạng local.

Ví dụ sau minh họa cách lấy các giá trị effective. Giả sử shape đầu tiên trên slide đầu tiên là một [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) có khung văn bản và ít nhất một portion.

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}}
Dữ liệu định dạng effective đại diện cho định dạng đã tính toán hiện tại sau khi áp dụng kế thừa. Trong triển khai hiện tại, một số đối tượng dữ liệu effective, chẳng hạn như [IPortionFormatEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iportionformateffectivedata/), có thể được lưu trong bộ nhớ đệm nội bộ. Gọi `getEffective()` lần nữa sau khi thay đổi định dạng cha hoặc định dạng kế thừa có thể làm mới dữ liệu đã được đệm, và một đối tượng đã lấy trước đó có thể không còn đại diện cho trạng thái trước đó. Nếu bạn cần giữ lại các giá trị effective để dùng lại sau, sao chép các thuộc tính cần thiết, chẳng hạn như chiều cao phông chữ, màu tô, kiểu phông chữ hoặc căn chỉnh, vào đối tượng dữ liệu của riêng bạn.
{{% /alert %}}

## **Lấy Thuộc tính Effective của Camera**

Aspose.Slides cho phép bạn lấy các thuộc tính effective của một camera. Giao diện [ICameraEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icameraeffectivedata/) đại diện cho một đối tượng bất biến chứa các thuộc tính camera effective. Một thể hiện [ICameraEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icameraeffectivedata/) được phơi bày thông qua [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformateffectivedata/), cung cấp các giá trị effective cho [IThreeDFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/).

```java
import com.aspose.slides.*;

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

## **Lấy Thuộc tính Effective của Light Rig**

Aspose.Slides cho phép bạn lấy các thuộc tính effective của một light rig. Giao diện [ILightRigEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilightrigeffectivedata/) đại diện cho một đối tượng bất biến chứa các thuộc tính light rig effective. Một thể hiện [ILightRigEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilightrigeffectivedata/) được phơi bày thông qua [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformateffectivedata/), cung cấp các giá trị effective cho [IThreeDFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/).

```java
import com.aspose.slides.*;

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

## **Lấy Thuộc tính Effective của Bevel Shape**

Aspose.Slides cho phép bạn lấy các thuộc tính effective của một shape bevel. Giao diện [IShapeBevelEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapebeveleffectivedata/) đại diện cho một đối tượng bất biến chứa các thuộc tính relief face cho một shape. Một thể hiện [IShapeBevelEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapebeveleffectivedata/) được phơi bày thông qua [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformateffectivedata/), cung cấp các giá trị effective cho [IThreeDFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/).

```java
import com.aspose.slides.*;

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

## **Lấy Thuộc tính Effective của Text Frame**

Sử dụng Aspose.Slides, bạn có thể lấy các thuộc tính effective của một khung văn bản. Giao diện [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframeformateffectivedata/) chứa các thuộc tính định dạng khung văn bản effective.

```java
import com.aspose.slides.*;

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

## **Lấy Thuộc tính Effective của Text Style**

Sử dụng Aspose.Slides, bạn có thể lấy các thuộc tính effective của một kiểu văn bản. Giao diện [ITextStyleEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextstyleeffectivedata/) chứa các thuộc tính kiểu văn bản effective.

```java
import com.aspose.slides.*;

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

## **Lấy Giá trị Chiều cao Phông chữ Effective**

Sử dụng Aspose.Slides, bạn có thể lấy chiều cao phông chữ effective. Đoạn mã sau minh họa cách chiều cao phông chữ effective của một portion thay đổi sau khi giá trị chiều cao phông chữ local được đặt ở các mức cấu trúc trình chiếu khác nhau.

```java
import com.aspose.slides.*;

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

## **Lấy Định dạng Đổ màu Effective cho Table**

Sử dụng Aspose.Slides, bạn có thể lấy định dạng đổ màu effective cho các phần khác nhau của bảng. Giao diện [IFillFormatEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifillformateffectivedata/) chứa các thuộc tính định dạng đổ màu effective. Định dạng ô có ưu tiên cao hơn định dạng dòng, định dạng dòng cao hơn định dạng cột, và định dạng cột cao hơn định dạng toàn bảng.

Kết quả, các thuộc tính [ICellFormatEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icellformateffectivedata/) được dùng để vẽ ô bảng. Đoạn mã sau cho thấy cách lấy định dạng đổ màu effective cho các phần khác nhau của bảng. Giả sử shape đầu tiên trên slide đầu tiên là một [ITable](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itable/).

```java
import com.aspose.slides.*;

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

### `getEffective()` có trả về một ảnh chụp nhanh (snapshot) không?

Không phải luôn luôn. Dữ liệu effective đại diện cho định dạng đã tính toán sau khi áp dụng kế thừa, nhưng một số đối tượng dữ liệu effective có thể được lưu trong bộ nhớ đệm nội bộ. Lần gọi `getEffective()` tiếp theo có thể tính lại định dạng và làm mới dữ liệu đã được đệm, vì vậy một đối tượng đã lấy trước không nên được coi là một ảnh chụp nhanh bền vững.

### Khi nào tôi nên đọc lại các thuộc tính effective?

Gọi `getEffective()` lại sau khi thay đổi định dạng local, kiểu cha, định dạng bố cục, định dạng master hoặc các mặc định ở mức bài thuyết trình. Lần gọi tiếp theo sẽ đánh giá lại cây định dạng và trả về kết quả effective hiện tại.

### Thay đổi hoặc xoá một slide bố cục/master có ảnh hưởng đến các thuộc tính effective đã được lấy trước không?

Có, nhưng thay đổi sẽ chỉ được phản ánh ở lần gọi `getEffective()` tiếp theo. Nếu nguồn định dạng cha được thay đổi hoặc xoá, dữ liệu effective đã lấy trước có thể trở nên lỗi thời. Khi `getEffective()` được gọi lại, Aspose.Slides sẽ đánh giá lại cây định dạng và các phông chữ, màu sắc, kích thước hoặc giá trị khác có thể thay đổi.

### Tôi có thể sửa đổi giá trị qua các đối tượng dữ liệu effective không?

Không. Các đối tượng dữ liệu effective chỉ cung cấp các giá trị đã được tính toán. Thực hiện thay đổi trong các đối tượng định dạng local, sau đó lấy lại các giá trị effective.

### Nếu một thuộc tính không được đặt ở mức shape, bố cục/master hoặc trong cài đặt toàn cục thì sao?

Giá trị effective sẽ được xác định bởi cơ chế mặc định, bao gồm các giá trị mặc định của PowerPoint và Aspose.Slides. Giá trị đã giải quyết sẽ trở thành một phần của dữ liệu effective hiện tại.

### Từ một giá trị phông chữ effective, tôi có thể biết được mức nào đã cung cấp kích thước hoặc kiểu chữ không?

Không trực tiếp. Dữ liệu effective chỉ trả về giá trị cuối cùng. Để tìm nguồn, kiểm tra các giá trị local ở mức portion, paragraph, text frame và các kiểu văn bản ở mức layout, master và presentation để xác định nơi xuất hiện định nghĩa đầu tiên.

### Tại sao các giá trị effective đôi khi trông giống hệt với giá trị local?

Bởi vì giá trị local đã trở thành giá trị cuối cùng (không cần kế thừa ở mức cao hơn). Trong các trường hợp này, giá trị effective trùng với giá trị local.

### Khi nào tôi nên sử dụng các thuộc tính effective, và khi nào chỉ làm việc với các thuộc tính local?

Sử dụng dữ liệu effective khi bạn cần kết quả "as rendered" sau khi mọi kế thừa được áp dụng, chẳng hạn để đồng bộ màu, lề hoặc kích thước. Nếu bạn muốn bảo lưu các giá trị này bất kể các thay đổi định dạng sau này, sao chép các thuộc tính cần thiết vào đối tượng của riêng bạn. Nếu bạn muốn thay đổi định dạng ở mức cụ thể, chỉnh sửa các thuộc tính local và, nếu cần, đọc lại dữ liệu effective để xác nhận kết quả.