---
title: Nhận các Thuộc tính Hiệu quả của Hình từ Bài thuyết trình trong JavaScript
linktitle: Thuộc tính Hiệu quả
type: docs
weight: 50
url: /vi/nodejs-java/shape-effective-properties/
keywords:
- thuộc tính hình
- thuộc tính camera
- bộ đèn
- hình bevel
- khung văn bản
- kiểu văn bản
- chiều cao phông chữ
- định dạng nền
- PowerPoint
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Khám phá cách Aspose.Slides cho Node.js thông qua Java tính toán và áp dụng các thuộc tính hình hiệu quả để hiển thị PowerPoint một cách chính xác."
---
## **Tổng quan**

Bài viết này giải thích sự khác biệt giữa các thuộc tính **cục bộ** và **hiệu quả**. Giá trị cục bộ là các giá trị được đặt trực tiếp ở một mức định dạng cụ thể, chẳng hạn như:

1. Thuộc tính đoạn văn trên một slide.  
1. Kiểu văn bản của hình mẫu trên bố cục hoặc slide chính, khi hình dạng khung văn bản của đoạn có kiểu này.  
1. Cài đặt văn bản toàn cục trong một bài thuyết trình.

Giá trị cục bộ có thể được định nghĩa hoặc bỏ qua ở bất kỳ mức nào. Khi Aspose.Slides cần định dạng cuối cùng “as rendered”, nó sẽ giải quyết chuỗi kế thừa và trả về các giá trị **hiệu quả**. Bạn có thể lấy chúng bằng cách gọi phương pháp `getEffective` trên đối tượng định dạng cục bộ.

Ví dụ dưới đây cho thấy cách lấy các giá trị hiệu quả. Nó giả định rằng hình dạng đầu tiên trên slide đầu tiên là một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) có khung văn bản và ít nhất một đoạn.

```javascript

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    let localPortionFormat = paragraph.getPortions().get_Item(0).getPortionFormat();
    let effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Dữ liệu định dạng hiệu quả đại diện cho định dạng tính toán hiện tại sau khi áp dụng kế thừa. Trong triển khai hiện tại, một số đối tượng dữ liệu hiệu quả có thể được lưu trong bộ nhớ đệm nội bộ. Gọi lại `getEffective` sau khi thay đổi định dạng cha hoặc định dạng kế thừa có thể làm mới dữ liệu đã được đệm, và một đối tượng đã lấy trước đây có thể không còn đại diện cho trạng thái trước đó. Nếu bạn cần giữ lại các giá trị hiệu quả để sử dụng lại sau này, sao chép các thuộc tính cần thiết, chẳng hạn như chiều cao phông chữ, màu nền, kiểu phông hoặc căn chỉnh, vào đối tượng dữ liệu của riêng bạn.
{{% /alert %}}

## **Lấy Thuộc tính Hiệu quả của Camera**

Aspose.Slides cho phép bạn lấy các thuộc tính hiệu quả của camera. Đối tượng dữ liệu camera hiệu quả chứa các thuộc tính camera bất biến và được cung cấp thông qua các giá trị hiệu quả trả về cho [ThreeDFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/).

Mã mẫu dưới đây cho thấy cách lấy các thuộc tính hiệu quả cho camera. Nó giả định rằng hình dạng đầu tiên trên slide đầu tiên có định dạng 3D.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let camera = threeDEffectiveData.getCamera();
    let cameraType = camera.getCameraType();
    let fieldOfViewAngle = camera.getFieldOfViewAngle();
    let zoom = camera.getZoom();

    console.log("= Effective camera properties =");
    console.log("Type: " + cameraType);
    console.log("Field of view: " + fieldOfViewAngle);
    console.log("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **Lấy Thuộc tính Hiệu quả của Light Rig**

Aspose.Slides cho phép bạn lấy các thuộc tính hiệu quả của light rig. Đối tượng dữ liệu light rig hiệu quả chứa các thuộc tính light rig bất biến và được cung cấp thông qua các giá trị hiệu quả trả về cho [ThreeDFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/).

Mã mẫu dưới đây cho thấy cách lấy các thuộc tính hiệu quả cho light rig. Nó giả định rằng hình dạng đầu tiên trên slide đầu tiên có định dạng 3D.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let lightRig = threeDEffectiveData.getLightRig();
    let lightType = lightRig.getLightType();
    let direction = lightRig.getDirection();

    console.log("= Effective light rig properties =");
    console.log("Type: " + lightType);
    console.log("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **Lấy Thuộc tính Hiệu quả của Hình Bevel**

Aspose.Slides cho phép bạn lấy các thuộc tính hiệu quả của bevel hình. Đối tượng dữ liệu bevel hình hiệu quả chứa các thuộc tính relief bất biến cho một hình và được cung cấp thông qua các giá trị hiệu quả trả về cho [ThreeDFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/).

Mã mẫu dưới đây cho thấy cách lấy các thuộc tính hiệu quả cho bevel trên cùng của một hình. Nó giả định rằng hình dạng đầu tiên trên slide đầu tiên có định dạng 3D.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let bevelTop = threeDEffectiveData.getBevelTop();
    let bevelType = bevelTop.getBevelType();
    let bevelWidth = bevelTop.getWidth();
    let bevelHeight = bevelTop.getHeight();

    console.log("= Effective shape's top face relief properties =");
    console.log("Type: " + bevelType);
    console.log("Width: " + bevelWidth);
    console.log("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **Lấy Thuộc tính Hiệu quả của Khung Văn bản**

Sử dụng Aspose.Slides, bạn có thể lấy các thuộc tính hiệu quả của khung văn bản. Đối tượng dữ liệu hiệu quả trả về chứa các thuộc tính định dạng khung văn bản.

Mã mẫu dưới đây cho thấy cách lấy các thuộc tính định dạng khung văn bản hiệu quả. Nó giả định rằng hình dạng đầu tiên trên slide đầu tiên là một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) có khung văn bản.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = textFrameFormat.getEffective();
    let anchoringType = effectiveTextFrameFormat.getAnchoringType();
    let autofitType = effectiveTextFrameFormat.getAutofitType();
    let textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    let marginLeft = effectiveTextFrameFormat.getMarginLeft();
    let marginTop = effectiveTextFrameFormat.getMarginTop();
    let marginRight = effectiveTextFrameFormat.getMarginRight();
    let marginBottom = effectiveTextFrameFormat.getMarginBottom();

    console.log("Anchoring type: " + anchoringType);
    console.log("Autofit type: " + autofitType);
    console.log("Text vertical type: " + textVerticalType);
    console.log("Margins");
    console.log("   Left: " + marginLeft);
    console.log("   Top: " + marginTop);
    console.log("   Right: " + marginRight);
    console.log("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **Lấy Thuộc tính Hiệu quả của Kiểu Văn bản**

Sử dụng Aspose.Slides, bạn có thể lấy các thuộc tính hiệu quả của kiểu văn bản. Đối tượng dữ liệu hiệu quả trả về chứa các thuộc tính kiểu văn bản.

Mã mẫu dưới đây cho thấy cách lấy các thuộc tính kiểu văn bản hiệu quả. Nó giả định rằng hình dạng đầu tiên trên slide đầu tiên là một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) có khung văn bản.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);
    let effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    let levelCount = 9;

    for (let levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        let effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        let depth = effectiveStyleLevel.getDepth();
        let indent = effectiveStyleLevel.getIndent();
        let alignment = effectiveStyleLevel.getAlignment();
        let fontAlignment = effectiveStyleLevel.getFontAlignment();

        console.log("= Effective paragraph formatting for style level #" + levelIndex + " =");

        console.log("Depth: " + depth);
        console.log("Indent: " + indent);
        console.log("Alignment: " + alignment);
        console.log("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **Lấy Giá trị Chiều cao Phông chữ Hiệu quả**

Sử dụng Aspose.Slides, bạn có thể lấy chiều cao phông chữ hiệu quả. Mã dưới đây minh họa cách chiều cao phông chữ hiệu quả của một đoạn thay đổi khi giá trị chiều cao phông chữ cục bộ được đặt ở các mức cấu trúc bài thuyết trình khác nhau.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shapeType = aspose.slides.ShapeType.Rectangle;
    let autoShape = slide.getShapes().addAutoShape(shapeType, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    let firstPortion = new aspose.slides.Portion("Sample text with first portion");
    let secondPortion = new aspose.slides.Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    let firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    let secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    let firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    let secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height just after creation:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting the presentation default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting paragraph default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #0 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #1 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    let saveFormat = aspose.slides.SaveFormat.Pptx;
    presentation.save("SetLocalFontHeightValues.pptx", saveFormat);
} finally {
    presentation.dispose();
}
```

## **Lấy Định dạng Điền Hiệu quả cho Bảng**

Sử dụng Aspose.Slides, bạn có thể lấy định dạng điền hiệu quả cho các phần khác nhau của bảng. Đối tượng dữ liệu hiệu quả trả về chứa các thuộc tính định dạng điền. Định dạng ô có ưu tiên cao hơn định dạng hàng, định dạng hàng có ưu tiên cao hơn định dạng cột, và định dạng cột có ưu tiên cao hơn định dạng toàn bảng.

Kết quả là, các thuộc tính định dạng ô hiệu quả được sử dụng để vẽ ô bảng. Mã mẫu dưới đây cho thấy cách lấy định dạng điền hiệu quả cho các phần khác nhau của bảng. Nó giả định rằng hình dạng đầu tiên trên slide đầu tiên là một [Table](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/table/).

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let table = slide.getShapes().get_Item(0);

    let tableFormatEffective = table.getTableFormat().getEffective();
    let rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    let columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    let cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    let tableFillFormatEffective = tableFormatEffective.getFillFormat();
    let rowFillFormatEffective = rowFormatEffective.getFillFormat();
    let columnFillFormatEffective = columnFormatEffective.getFillFormat();
    let cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**`getEffective` có trả về một bản sao không?**

Không phải luôn luôn. Dữ liệu hiệu quả đại diện cho định dạng đã tính toán sau khi áp dụng kế thừa, nhưng một số đối tượng dữ liệu hiệu quả có thể được lưu trong bộ nhớ đệm nội bộ. Lần gọi `getEffective` tiếp theo có thể tính lại định dạng và làm mới dữ liệu đã đệm, vì vậy một đối tượng đã lấy trước không nên được coi là một bản sao bền vững.

**Khi nào tôi nên đọc lại các thuộc tính hiệu quả?**

Gọi lại `getEffective` sau khi thay đổi định dạng cục bộ, kiểu cha, định dạng bố cục, định dạng master hoặc các giá trị mặc định ở mức bài thuyết trình. Lần gọi tiếp theo sẽ đánh giá lại cây định dạng và trả về kết quả hiệu quả hiện tại.

**Việc thay đổi hoặc xóa một slide bố cục/chính có ảnh hưởng đến các thuộc tính hiệu quả đã được lấy trước đó không?**

Có, nhưng thay đổi sẽ được phản ánh ở lần gọi `getEffective` tiếp theo. Nếu nguồn định dạng cha bị thay đổi hoặc xóa, dữ liệu hiệu quả đã lấy trước có thể trở nên lỗi thời. Khi `getEffective` được gọi lại, Aspose.Slides sẽ đánh giá lại cây định dạng và các phông chữ, màu sắc, kích thước hoặc giá trị khác có thể thay đổi.

**Tôi có thể sửa đổi giá trị thông qua các đối tượng dữ liệu hiệu quả không?**

Không. Các đối tượng dữ liệu hiệu quả chỉ cung cấp các giá trị đã tính toán. Thực hiện thay đổi trong các đối tượng định dạng cục bộ, sau đó lấy lại các giá trị hiệu quả.

**Nếu một thuộc tính không được đặt ở mức hình dạng, cũng không ở bố cục/chính, và không trong cài đặt toàn cục thì điều gì xảy ra?**

Giá trị hiệu quả được xác định bởi cơ chế mặc định, bao gồm các mặc định của PowerPoint và Aspose.Slides. Giá trị đã giải quyết sẽ trở thành một phần của dữ liệu hiệu quả hiện tại.

**Từ giá trị phông chữ hiệu quả, tôi có thể biết mức nào đã cung cấp kích thước hoặc kiểu phông không?**

Không trực tiếp. Dữ liệu hiệu quả trả về giá trị cuối cùng. Để tìm nguồn, hãy kiểm tra các giá trị cục bộ tại đoạn, đoạn văn, khung văn bản và các kiểu văn bản ở mức bố cục, master và bài thuyết trình để xem nơi định nghĩa rõ ràng đầu tiên xuất hiện.

**Tại sao đôi khi các giá trị hiệu quả trông giống hệt với các giá trị cục bộ?**

Bởi vì giá trị cục bộ đã trở thành giá trị cuối cùng (không cần kế thừa ở mức cao hơn). Trong các trường hợp đó, giá trị hiệu quả trùng với giá trị cục bộ.

**Khi nào tôi nên sử dụng các thuộc tính hiệu quả, và khi nào chỉ làm việc với các thuộc tính cục bộ?**

Sử dụng dữ liệu hiệu quả khi bạn cần kết quả “as rendered” sau khi tất cả kế thừa được áp dụng, chẳng hạn để đồng bộ màu, lề hoặc kích thước. Nếu bạn muốn giữ các giá trị này bất chấp các thay đổi định dạng sau này, sao chép các thuộc tính cần thiết vào đối tượng riêng của mình. Nếu bạn muốn thay đổi định dạng ở mức cụ thể, chỉnh sửa các thuộc tính cục bộ và sau đó, nếu cần, đọc lại dữ liệu hiệu quả để xác nhận kết quả.