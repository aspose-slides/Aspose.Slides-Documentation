---
title: Định dạng các hình PowerPoint trong JavaScript
linktitle: Định dạng Hình
type: docs
weight: 20
url: /vi/nodejs-java/shape-formatting/
keywords:
- định dạng hình
- định dạng đường
- hiệu ứng phác họa
- đường hình phác họa
- định dạng kiểu nối
- đổ gradient
- đổ họa tiết
- đổ hình ảnh
- đổ kết cấu
- đổ màu đồng nhất
- độ trong suốt hình
- kết xuất hình đen‑trắng
- kết xuất hình xám
- xoay hình
- hiệu ứng viền 3D
- hiệu ứng xoay 3D
- đặt lại định dạng
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách định dạng các hình PowerPoint trong JavaScript bằng Aspose.Slides—đặt các kiểu đổ, đường viền và hiệu ứng cho các tệp PPT và PPTX với độ chính xác và kiểm soát hoàn toàn."
---
## **Giới thiệu**

Định dạng các hình dạng trong PowerPoint bằng cách điều chỉnh đường viền, màu nền và hiệu ứng của chúng. Aspose.Slides for Node.js qua Java cho phép bạn kiểm soát các cài đặt này bằng chương trình, bao gồm độ trong suốt, quay và định dạng 3D.

![Các tùy chọn định dạng hình trong PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js qua Java cung cấp các lớp và phương thức cho phép bạn định dạng các hình dạng bằng các tùy chọn giống như trong PowerPoint.

## **Định dạng Đường viền**

Sử dụng [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) để kiểm soát đường viền của một hình. Ví dụ này tạo một hình chữ nhật không nền với đường viền màu xanh dương, dạng gạch đứt. [LineFormat.setStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setStyle) chọn đường kết hợp dày-mỏng, trong khi [LineFormat.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setWidth) đặt độ rộng của nó là 7 điểm và [LineFormat.setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setDashStyle) chọn mẫu gạch.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Các đường đã định dạng trong bản trình bày](formatted-lines.png)

### **Đặt Mẫu Gạch Đường Tùy Chỉnh**

Sử dụng [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setCustomDashPattern) khi các kiểu đường đã định trước không cung cấp độ dài gạch và khoảng trống bạn cần, ví dụ cho các đường viền thương hiệu hoặc biểu đồ kỹ thuật. Gán một mẫu sẽ tự động thay đổi kiểu gạch của đường thành [LineDashStyle.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/).

Các mục trong mảng xen kẽ giữa độ dài gạch và khoảng trống, bắt đầu bằng gạch. Mỗi giá trị là bội số của độ rộng đường: `[4, 2]` với độ rộng 3 điểm tạo ra gạch 12 điểm rồi khoảng trống 6 điểm. Sử dụng các cặp giá trị hữu hạn, không âm để xác định các đoạn gạch-khoảng trống hoàn chỉnh. Ví dụ sử dụng các giá trị dương để giữ cho mọi gạch và khoảng trống đều hiển thị.

Ví dụ này tạo năm đường màu xanh dương có cùng độ dài và đầu mũi phẳng. Ba đường đầu tiên so sánh các mẫu với độ rộng 3 điểm. Đường thứ tư lặp lại mẫu đầu tiên với độ rộng gấp đôi, nhân đôi cả độ dài gạch và khoảng trống. Đường thứ năm chuyển từ mẫu tùy chỉnh sang đường đặc.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ];

    for (let i = 0; i < patterns.length; i++) {
        let line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        line.getLineFormat().setCapStyle(java.newByte(aspose.slides.LineCapStyle.Flat));
        line.getLineFormat().setBeginArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        line.getLineFormat().setEndArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        let pattern = java.newArray("float", patterns[i]);
        line.getLineFormat().setCustomDashPattern(pattern);
    }

    // Đặt dòng cuối cùng thành kiểu đặc.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Solid));

    presentation.save("custom_dash_patterns.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Để quay lại kiểu gạch đã định trước, hãy truyền [LineDashStyle.Dash](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) vào [LineFormat.setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setDashStyle). Kiểu đã chọn kiểm soát giao diện của đường.

Kết quả trong PowerPoint, từ trên xuống dưới: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; và **Solid, 3 pt**.

![Ba mẫu gạch tùy chỉnh, một đường rộng hơn sử dụng mẫu đầu tiên, và một dòng đặc trong PowerPoint](custom-dash-patterns.png)

### **Đặt Đầu Đường**

Sử dụng [LineFormat.setCapStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setCapStyle) để đặt đầu của một đường mở. Lớp [LineCapStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linecapstyle/) cung cấp ba kiểu đầu rõ ràng:

- `Flat`: Đường nét dừng lại tại điểm cuối.
- `Round`: Đầu nửa vòng tròn mở rộng ra ngoài điểm cuối một nửa độ rộng đường.
- `Square`: Đầu hình vuông mở rộng ra ngoài điểm cuối một nửa độ rộng đường.

Lớp còn bao gồm `NotDefined`, có nghĩa là không có kiểu đầu nào được gán rõ ràng.

Đầu khác với mũi tên, những thứ thêm ký hiệu vào đầu đường, và các nối, những thứ kiểm soát góc giữa các đoạn đường. Ví dụ này tắt mũi tên thông qua [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setBeginArrowheadStyle) và [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setEndArrowheadStyle) để chỉ so sánh các hình dạng đầu.

Ví dụ sau tạo ba đường ngang giống nhau, rộng 20 điểm. Từ trên xuống dưới, chúng sử dụng đầu phẳng, tròn và vuông. Các điểm cuối của chúng có cùng tọa độ ngang; đầu tròn và vuông mở rộng 10 điểm ra ngoài mỗi điểm cuối.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let capStyles = [aspose.slides.LineCapStyle.Flat, aspose.slides.LineCapStyle.Round, aspose.slides.LineCapStyle.Square];

    for (let i = 0; i < capStyles.length; i++) {
        let line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        line.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Solid));
        line.getLineFormat().setCapStyle(java.newByte(capStyles[i]));
        line.getLineFormat().setBeginArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        line.getLineFormat().setEndArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
    }

    presentation.save("line_caps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả trong PowerPoint, từ trên xuống dưới: **Flat**, **Round**, và **Square**.

![Đầu phẳng, tròn và vuông trên các đường dày giống nhau trong PowerPoint](line-caps.png)

## **Áp dụng Hiệu Ứng Phác Họa cho Đường Hình**

Một hiệu ứng phác họa làm cho đường của hình trông như được vẽ bằng tay. Sử dụng [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) để truy cập cài đặt đường, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getSketchFormat) để truy cập cài đặt phác họa, và [SketchFormat.setSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/#setSketchType) để chọn một giá trị từ lớp [LineSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/).

Đoạn mã JavaScript sau cho thấy cách áp dụng hiệu ứng [LineSketchType.Curved](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/), đọc giá trị đã gán rõ ràng, và loại bỏ hiệu ứng bằng [LineSketchType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    let sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Giá trị trả về bởi [SketchFormat.getSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/#getSketchType) đại diện cho cài đặt được gán trực tiếp cho hình. Nếu định dạng đường có thể được kế thừa từ chủ đề, slide chủ, hoặc slide bố cục, hãy sử dụng [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective), gọi `getSketchFormat` trên đối tượng trả về, sau đó gọi phương thức `getSketchType`. Giá trị hiệu quả phản ánh định dạng thực sự được áp dụng sau khi kế thừa được giải quyết. Ví dụ này yêu cầu một bản trình bày hiện có có ít nhất một hình trên slide đầu tiên và in ra cả hai giá trị:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    let lineFormat = shape.getLineFormat();
    let explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    let effectiveLineFormat = lineFormat.getEffective();
    let effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    console.log("Explicit sketch type: " + explicitSketchType);
    console.log("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Định dạng Kiểu Nối**

Dưới đây là ba tùy chọn kiểu nối:

* Round
* Miter
* Bevel

Kiểu nối kiểm soát cách hai đoạn viền gặp nhau ở góc. Sử dụng **Round** cho các góc bo tròn, **Miter** cho các góc nhọn, hoặc **Bevel** cho các góc phẳng.

![Kiểu nối trong bản trình bày](join-style-powerpoint.png)

Ví dụ này tạo ba hình chữ nhật đen với đường viền xanh dương rộng 15 điểm. Nó sử dụng [LineFormat.setJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setJoinStyle) để áp dụng các giá trị miter, bevel và round của [LineJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linejoinstyle/), tương ứng, để so sánh cách các góc được vẽ.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let miterShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let bevelShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let roundShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    miterShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    bevelShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    bevelShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    roundShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    roundShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    bevelShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    roundShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    miterShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    bevelShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    roundShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Giới hạn Nối Miter ở Các Góc Nhọn**

Sử dụng [LineFormat.setMiterLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setMiterLimit) với [LineFormat.setJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setJoinStyle) được đặt thành [LineJoinStyle.Miter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linejoinstyle/) để giới hạn độ kéo dài của góc nhọn.

Giới hạn là tỉ lệ giữa khoảng cách giữa góc trong và góc ngoài của nối so với độ rộng đường. Ví dụ, giá trị `8` cho phép độ dài miter lên tới tám lần độ rộng đường; đây không phải là một đo lường bằng điểm. Nếu góc vượt quá giới hạn, PowerPoint sẽ sử dụng nối bào góc tại góc đó. Giới hạn lớn hơn cho phép các điểm nhọn hơn. Cài đặt này chỉ ảnh hưởng đến các nối miter và việc thay đổi nó không gây ra hiệu ứng nhìn thấy khi góc vẫn nằm trong cả hai giới hạn.

Ví dụ này tạo hai tam giác không nền giống nhau với viền rộng 20 điểm. Tam giác bên trái sử dụng giới hạn `2`, còn bên phải sử dụng `8`. Mỗi tam giác rộng 80 điểm và cao 160 điểm, cho góc trên của nó tỉ lệ độ dài miter so với độ rộng đường khoảng `4.12`. Do đó, PowerPoint bào góc trái và giữ nguyên góc phải.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let miterLimits = [2, 8];

    for (let i = 0; i < miterLimits.length; i++) {
        let triangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        triangle.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
        triangle.getLineFormat().setMiterLimit(java.newFloat(miterLimits[i]));
    }

    presentation.save("miter_limits.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả trong PowerPoint: **Miter limit 2** ở bên trái và **miter limit 8** ở bên phải.

![Đỉnh bị bào góc với giới hạn miter 2 và đỉnh nhọn với giới hạn miter 8 trong PowerPoint](miter-limits.png)

## **Đổ Bóng Gradient**

Một đổ bóng gradient pha trộn các màu qua một hình. Ví dụ này đổ màu cho một hình ellip bằng gradient tuyến tính góc 45 độ từ đỏ sang tím bằng cách sử dụng [FillFormat.getGradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getGradientFormat). Phương thức [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientstopcollection/#addPresetColor) đặt các điểm dừng màu ở 0 và 1, bắt đầu và kết thúc của gradient. Xóa các điểm dừng hiện có đảm bảo chỉ hai màu này được dùng.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, aspose.slides.PresetColor.Red);

    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình ellip với đổ bóng gradient](gradient-fill.png)

Nếu một gradient trông khác nhau trong ảnh xuất ra so với trong PowerPoint, xem [Chọn Kiểu Kết Xuất Gradient](/slides/vi/nodejs-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Bạn có thể chọn kiểu kết xuất mà không thay đổi đổ bóng gradient được lưu trong bản trình bày.

### **Đặt Góc Gradient Tuyến Tính**

Sử dụng [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientAngle) để điều khiển hướng của một đổ [GradientShape.Linear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientshape/) . Góc được đo bằng độ và tăng theo chiều kim đồng hồ: `0` chạy từ trái sang phải, `90` từ trên xuống dưới, `180` từ phải sang trái, và `270` từ dưới lên trên. Hỗ trợ các góc phân số. Các góc hữu hạn ngoài phạm vi `[0, 360)` được chuẩn hoá thành một vòng quay; ví dụ, `-45` trở thành `315` và `360` trở thành `0`.

Ví dụ này tạo sáu hình chữ nhật với các điểm dừng màu đỏ, xanh lá và xanh dương giống nhau ở vị trí `0`, `0.5`, và `1`. Thu phóng bị tắt để góc có thể được so sánh độc lập với tỉ lệ của các hình. Các góc, từ trái sang phải, là `0`, `45`, và `90` ở hàng đầu, và `135`, `180`, và `270` ở hàng thứ hai.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let angles = [0, 45, 90, 135, 180, 270];

    for (let i = 0; i < angles.length; i++) {
        let x = 30 + (i % 3) * 230;
        let y = 30 + Math.floor(i / 3) * 190;

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

        let gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
        gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
        gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
        gradient.setLinearGradientScaled(java.newByte(aspose.slides.NullableBool.False));
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả trong PowerPoint:

![Gradient tuyến tính ở các góc 0, 45 và 90 độ trong hàng trên, và 135, 180 và 270 độ trong hàng dưới](linear-gradient-angles.png)

### **Phóng To/Phiểu Nhỏ Gradient Tuyến Tính với Hình**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientScaled) chấp nhận một giá trị [NullableBool](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/). Đặt rõ ràng thành `False` để giữ góc gradient hình học khi tỉ lệ hình thay đổi, hoặc thành `True` để thu phóng gradient cùng với chiều rộng và chiều cao của hình. Khi thu phóng được bật, góc nhìn thấy có thể khác với góc đã gán trên một hình không vuông.

Ví dụ sau sử dụng góc `45` độ và cùng các điểm dừng màu như so sánh góc. Cột bên trái dùng `False`; cột bên phải dùng `True`. Mỗi cột chứa một hình chữ nhật rộng phía trên một hình chữ nhật cao. Cả hai bắt đầu với cùng kích thước rộng; việc thay đổi chiều rộng và chiều cao của hình chữ nhật thứ hai minh họa cách màu nền phản hồi khi thay đổi kích thước mà không thay đổi cài đặt gradient.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let scalingOptions = [aspose.slides.NullableBool.False, aspose.slides.NullableBool.True];

    for (let column = 0; column < scalingOptions.length; column++) {
        for (let row = 0; row < 2; row++) {
            let x = 30 + column * 360;
            let y = row == 0 ? 30 : 150;

            let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

            let gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
            gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
            gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(java.newByte(scalingOptions[column]));

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả trong PowerPoint, với việc thu phóng bị tắt ở bên trái và bật ở bên phải:

![Hình chữ nhật rộng và cao với gradient 45 độ, so sánh LinearGradientScaled False ở bên trái với True ở bên phải](linear-gradient-scaling.png)

Với thu phóng bị tắt, các dải màu chéo giữ cùng hướng trong cả hai hình chữ nhật. Với thu phóng được bật, các dải kéo dài theo tỉ lệ của hình. Điều này giúp tái tạo gradient của mẫu khi điều chỉnh một hình sang kích thước khác. Trên một hình vuông, bật thu phóng không thay đổi ngoại hình của gradient `45` độ này.

Cả góc và cài đặt thu phóng đều áp dụng cho gradient tuyến tính. Chúng không điều khiển các đổ [GradientShape.Radial or GradientShape.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientshape/).

### **Kết Hợp Góc với Hướng Gradient**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setGradientDirection) chọn một kiểu gradient từ lớp [GradientDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientdirection/); nó không phải là sự thay thế cho một góc số. Đối với gradient tuyến tính, các kiểu góc có thể thay đổi khu vực phân phối màu mà không thay đổi góc được gán qua [setLinearGradientAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientAngle). Giữ hướng không đổi khi so sánh góc hoặc thu phóng.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < 2; i++) {
        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

        let gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
        gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
        gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
        gradient.setLinearGradientScaled(java.newByte(aspose.slides.NullableBool.True));

        if (i == 0) {
            gradient.setGradientDirection(aspose.slides.GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(aspose.slides.GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đổ Bóng Họa Tiết**

Một đổ bóng họa tiết áp dụng một thiết kế hai màu, chẳng hạn như chấm, sọc, hoặc ô vuông. Ví dụ này sử dụng [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#setPatternStyle) để chọn mẫu trellis. [PatternFormat.getBackColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor) cung cấp nền xám nhạt, và [PatternFormat.getForeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor) cung cấp màu vàng cho mẫu.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình chữ nhật với đổ bóng họa tiết](pattern-fill.png)

## **Đổ Bóng Hình Ảnh**

Một đổ bóng hình ảnh sử dụng một ảnh bên trong một hình. Ví dụ này yêu cầu một ảnh nội bộ và sử dụng [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) để tải nó vào bộ sưu tập ảnh của bản trình bày. Đặt [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode) ở chế độ lát sẽ lặp lại ảnh trong hình chữ nhật. Ảnh nguồn được dùng ở đây được hiển thị bên dưới:

![Hình ảnh sen](lotus.png)

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình dạng với đổ bóng hình ảnh](picture-fill.png)

### **Lát Hình Ảnh Thành Kết Cấu**

Nếu bạn muốn đặt một ảnh lát thành kết cấu và tùy chỉnh hành vi lát, bạn có thể sử dụng các phương thức sau của lớp [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Đặt chế độ đổ ảnh — `Tile` hoặc `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Xác định vị trí căn chỉnh của các ô trong hình.
- [setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Điều khiển việc lật ô theo chiều ngang, chiều dọc hoặc cả hai.
- [setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Đặt độ lệch ngang của ô (đơn vị điểm) so với gốc của hình.
- [setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Đặt độ lệch dọc của ô (đơn vị điểm) so với gốc của hình.
- [setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Xác định tỉ lệ ngang của ô dưới dạng phần trăm.
- [setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Xác định tỉ lệ dọc của ô dưới dạng phần trăm.

Ví dụ này yêu cầu một ảnh nội bộ và cấu hình [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) để lặp lại nó ở 50% kích thước gốc. Các độ lệch `‑32` điểm dịch các ô theo chiều ngang và dọc; căn chỉnh góc dưới‑phải và lật cả hai chiều xác định cách sắp xếp kết cấu lặp lại.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Các tùy chọn lát](tile-options.png)

## **Đổ Bóng Đơn Màu**

Một đổ bóng đơn màu cho hình một màu đồng nhất. Ví dụ này sử dụng [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) để chọn chế độ đổ đơn và gán màu vàng qua [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor), sau đó lưu hình chữ nhật trong bản trình bày.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình dạng với đổ bóng màu đơn](solid-color-fill.png)

### **Sao Chép Màu Khi Giữ Tham Chiếu Chủ Đề**

Sử dụng [ColorFormat.copyFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#copyFrom) để sao chép một định nghĩa màu, bao gồm loại màu, tham chiếu chủ đề và các biến đổi. Điều này hữu ích khi chuyển màu đổ giữa các hình cần tiếp tục tuân theo chủ đề bản trình bày. Phương thức chỉ sao chép màu: nó không sao chép kiểu đổ, viền, hoặc các định dạng hình khác. Đặt kiểu đổ của đích một cách rõ ràng bằng [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType).

Ví dụ này tạo ba hình chữ nhật, từ trái sang phải: nguồn, bản sao nhận thức chủ đề, và bản sao RGB cố định. Nguồn sử dụng [ColorFormat.setSchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#setSchemeColor) để tham chiếu màu nhấn đầu tiên và thêm một sắc thái qua [ColorOperationCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/coloroperationcollection/#add). Bản sao RGB dùng màu đổ hiệu quả của nguồn nên ba hình ban đầu trông giống nhau. Gọi [ColorFormat.setColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#setColor) đặt một giá trị RGB cố định và xóa mọi biến đổi màu hiện có.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(java.newInstanceSync("java.awt.Color", 65, 105, 225));

    let source = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 40, 180, 140);
    let themeCopy = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 240, 40, 180, 140);
    let rgbCopy = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 450, 40, 180, 140);

    for (let shape of [source, themeCopy, rgbCopy]) {
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }

    let sourceColor = source.getFillFormat().getSolidFillColor();
    sourceColor.setSchemeColor(aspose.slides.SchemeColor.Accent1);
    sourceColor.getColorTransform().add(aspose.slides.ColorTransformOperation.Tint, java.newFloat(0.75));

    themeCopy.getFillFormat().getSolidFillColor().copyFrom(sourceColor);
    rgbCopy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor());

    let before = slide.getImage(1, 1);
    try {
        before.save("color-copy-before.png", aspose.slides.ImageFormat.Png);
    } finally {
        before.dispose();
    }

    // Các tham chiếu chủ đề theo màu nhấn mới; giá trị RGB cố định không thay đổi.
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(java.newInstanceSync("java.awt.Color", 255, 69, 0));

    let after = slide.getImage(1, 1);
    try {
        after.save("color-copy-after.png", aspose.slides.ImageFormat.Png);
    } finally {
        after.dispose();
    }
    presentation.save("copied_colors.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Trước khi thay đổi chủ đề, ba màu đổ đều giống nhau:

![Nguồn, đích copyFrom, và đích RGB cố định với màu xanh đồng nhất](color-copy-before.png)

Sau khi thay đổi chủ đề, nguồn và bản sao nhận thức chủ đề sẽ theo màu nhấn mới và giữ độ sáng. Bản sao RGB cố định vẫn giữ màu xanh:

![Nguồn và đích copyFrom với màu cam, trong khi đích RGB cố định vẫn màu xanh](color-copy-after.png)

Định nghĩa đã sao chép độc lập với nguồn. Thay đổi sau này tham chiếu chủ đề của nguồn, gán màu khác, hoặc thêm/bỏ các biến đổi sẽ không thay đổi đích. Thay đổi chủ đề vẫn ảnh hưởng đến cả hai hình vì mỗi hình tự độc lập tham chiếu cùng một màu chủ đề.

Lưu và mở lại file PPTX giữ lại loại màu đã sao chép được trả về bởi [ColorFormat.getColorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#getColorType), tham chiếu chủ đề, và bộ sưu tập biến đổi trả về bởi [ColorFormat.getColorTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#getColorTransform); nó không làm phẳng định nghĩa thành RGB.

Khi sao chép giữa các ngữ cảnh chủ đề khác nhau, chẳng hạn bản trình bày có bảng màu nhấn khác nhau, tham chiếu đã sao chép sẽ được giải quyết theo chủ đề của đích. Tham chiếu và các biến đổi giống nhau do đó có thể tạo ra một màu hiển thị khác. Xem [Chủ Đề Bản Trình Bày](/slides/vi/nodejs-java/presentation-theme/) để biết thêm về cấu hình màu chủ đề.

## **Sử Dụng Nền Slide làm Đổ Bóng Hình**

Sử dụng [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#setUseBackgroundFill) khi một hình nên khớp với nền slide, ví dụ trong một mẫu bản trình bày. Đặt kiểu đổ bằng [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) thành [FillType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) trước để xóa bất kỳ đổ nào rõ ràng. Với sự kết hợp này, hình sẽ sử dụng nền slide thay vì đổ theo kiểu của nó. Bật cờ này một mình không xóa đổ rõ ràng hiện có.

Điều này khác với [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/): đổ nền phủ các đối tượng phía sau hình bằng khu vực tương ứng của nền slide, trong khi không đổ để các đối tượng đó hiển thị. Một gradient vẫn được căn chỉnh với slide thay vì khởi động lại bên trong mỗi hình.

Ví dụ sau tạo một nền master được kế thừa bởi slide và đặt một dải màu hồng tím phía sau ba hình chữ nhật. Hình chữ nhật bên trái dùng nền, hình ở giữa không có đổ, và hình bên phải chuyển từ đổ nền sang đổ màu cam rõ ràng.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    // Kế thừa gradient từ master.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.NotDefined));
    slide.getLayoutSlide().getBackground().setType(java.newByte(aspose.slides.BackgroundType.NotDefined));
    let background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    let gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, java.newInstanceSync("java.awt.Color", 0, 0, 139));
    gradient.getGradientStops().add(1, java.newInstanceSync("java.awt.Color", 135, 206, 250));

    // Thêm đối tượng này trước để nó nằm phía sau các hình chữ nhật.
    let band = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    band.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    band.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    let backgroundShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NotDefined));
    backgroundShape.setUseBackgroundFill(true);

    let noFillShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    let explicitShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NotDefined));
    explicitShape.setUseBackgroundFill(true);

    // Tắt đổ nền trước khi áp dụng đổ màu rõ ràng.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    explicitShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));

    presentation.save("background_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả, từ trái sang phải: **background fill**, **no fill**, và **explicit fill**. Dải màu hồng tím bị các hình trái và phải che khuất nhưng vẫn hiện ra qua hình giữa.

![Đổ nền, không đổ, và đổ màu cam đậm trên dải màu hồng tím](background-fill.png)

Hành vi tương tự áp dụng cho nền được định nghĩa trực tiếp trên slide hoặc kế thừa từ một bố cục. Hình sử dụng nền đã được giải quyết của slide; ví dụ để cả nền slide và bố cục không xác định để master cung cấp nó.

## **Đặt Độ Trong Suốt**

Đối với một đổ đơn, thành phần alpha của màu kiểm soát độ mờ: 0 là hoàn toàn trong suốt và 255 là hoàn toàn mờ. Ví dụ này sử dụng giá trị alpha 128 cho một hình chữ nhật màu vàng, làm nó khoảng 50% trong suốt để hình dưới vẫn nhìn thấy. Màu được gán qua [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 128));

    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hình dạng trong suốt](shape-transparency.png)

## **Xoay Hình Dạng**

Sử dụng [Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) để xoay một hình trong mặt phẳng slide. Góc được đo bằng độ; ví dụ này xoay một hình chữ nhật 5 độ theo chiều kim đồng hồ và lưu bản trình bày.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Xoay hình dạng](shape-rotation.png)

## **Thêm Hiệu Ứng Bờ Viền 3D**

Sử dụng [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) để cho một hình có độ sâu và các cạnh bào. Ví dụ này tạo một ellip màu xanh lá với viền màu cam, sử dụng [ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) để đặt độ sâu 4 điểm, và áp dụng một bề mặt trên tròn với chiều rộng và chiều cao 6 điểm qua [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop). Một camera trực diện dạng trực giao và ánh sáng ba‑điểm làm cho bề mặt này hiển thị.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hiệu ứng viền 3D](3D-bevel-effect.png)

## **Thêm Hiệu Ứng Xoay 3D**

Một hình 3D được kiểm soát bởi các cài đặt camera. Ví dụ này sử dụng [Camera.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation) với các góc vĩ độ, kinh độ và quay vòng là 40, 35 và 20 độ, tương ứng. Nó chọn một camera isometric qua [Camera.setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) và ánh sáng cân bằng qua [LightRig.setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType), sau đó lưu hình chữ nhật đã định dạng.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Hiệu ứng xoay 3D](3D-rotation-effect.png)

## **Kiểm Soát Kết Xuất Đen- Trắng cho Hình Dạng**

Phương thức [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) chỉ định cách một hình riêng lẻ được kết xuất khi một bản trình bày được xem hoặc xử lý ở chế độ đen‑trắng. Nó không tự kích hoạt hiển thị đen‑trắng và không thay đổi đổ, đường viền hoặc các định dạng khác của hình ở chế độ màu bình thường.

Sử dụng một giá trị từ lớp [BlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blackwhitemode/) để chọn hành vi mong muốn. Ví dụ, `Automatic` cho phép ứng dụng kết xuất chọn cách chuyển đổi, `Gray` và `LightGray` dùng màu xám, `BlackWhite` chỉ dùng đen và trắng, `Black` và `White` ép buộc một màu duy nhất, `Color` giữ nguyên màu bình thường, và `Hidden` bỏ qua hình trong chế độ đen‑trắng. `NotDefined` có nghĩa là không có chế độ cấp cho hình được gán.

Ví dụ này tạo một hình chữ nhật màu cam và sử dụng [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) để chọn màu xám. Hình đã lưu giữ màu đổ cam cho hiển thị màu bình thường và yêu cầu màu xám từ các ứng dụng tôn trọng cài đặt hiển thị đen‑trắng:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Trong chế độ màu bình thường, hình chữ nhật giữ màu đổ cam. Trong quy trình hiển thị đen‑trắng, nó dùng màu xám vì chế độ được đặt thành `Gray`. Điều này cho phép bạn giữ một slide đầy màu trong khi định nghĩa một ngoại hình riêng cho in, xem trước, hoặc các quy trình khác tôn trọng cài đặt hiển thị đen‑trắng của bản trình bày.

## **Đặt Lại Định Dạng**

Sử dụng [Slide.reset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#reset) để khôi phục vị trí, kích thước và định dạng của các trình giữ chỗ slide từ các trình giữ chỗ bố cục tương ứng. Ví dụ này yêu cầu một bản trình bày hiện có có các trình giữ chỗ liên kết bố cục và đặt lại mọi slide trước khi lưu. Các hình không có trình giữ chỗ bố cục tương ứng sẽ không được đặt lại.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Việc định dạng hình dạng có ảnh hưởng đến kích thước cuối cùng của tệp bản trình bày không?**

Màu sắc, kiểu đường và cài đặt hiệu ứng thường chỉ thêm ít dữ liệu so với hình ảnh và phương tiện nhúng. Đổ hình ảnh có thể làm tăng kích thước tệp vì các ảnh được lưu trong bản trình bày.

**Làm sao tôi có thể phát hiện các hình trên một slide có cùng định dạng để nhóm chúng lại?**

So sánh các thuộc tính định dạng chính của mỗi hình—đổ, đường viền và cài đặt hiệu ứng. Nếu tất cả các giá trị tương ứng đều khớp, coi chúng là cùng một kiểu và nhóm logic các hình đó, giúp đơn giản hoá việc quản lý kiểu sau này.

**Tôi có thể lưu một bộ kiểu hình tùy chỉnh vào một tệp riêng để tái sử dụng trong các bản trình bày khác không?**

Có. Lưu các hình mẫu với các kiểu mong muốn trong một bộ slide mẫu hoặc tệp mẫu .POTX. Khi tạo bản trình bày mới, mở mẫu, sao chép các hình đã định dạng cần thiết, và áp dụng lại định dạng của chúng ở bất kỳ nơi nào cần.