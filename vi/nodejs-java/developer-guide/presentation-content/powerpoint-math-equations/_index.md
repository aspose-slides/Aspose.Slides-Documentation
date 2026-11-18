---
title: Thêm Phương trình Toán học vào Bản trình bày PowerPoint trong JavaScript
linktitle: Phương trình Toán học PowerPoint
type: docs
weight: 80
url: /vi/nodejs-java/powerpoint-math-equations/
keywords:
- phương trình toán học
- ký hiệu toán học
- công thức toán học
- văn bản toán học
- thêm phương trình toán học
- thêm ký hiệu toán học
- thêm công thức toán học
- thêm văn bản toán học
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Chèn và chỉnh sửa các phương trình toán học trong PowerPoint PPT và PPTX bằng Aspose.Slides cho Node.js qua Java, hỗ trợ OMML, kiểm soát định dạng, và các mẫu mã JavaScript rõ ràng."
---
## **Tổng quan**

PowerPoint lưu phương trình dưới dạng Office Math Markup Language (OMML). Với Aspose.Slides cho Node.js thông qua Java, bạn có thể tạo cùng loại nội dung toán học một cách lập trình: phân số, căn bậc, hàm, giới hạn, toán tử N-ary, ma trận, mảng và các khối toán học được định dạng.

Trong PowerPoint, người dùng thường chèn phương trình từ **Insert > Equation**:

![PowerPoint Insert tab with the Equation command selected](powerpoint-math-equations_1.png)

Kết quả là văn bản toán học có thể chỉnh sửa trên slide:

![A PowerPoint slide containing an editable math equation](powerpoint-math-equations_2.png)

Aspose.Slides xây dựng văn bản toán học đó thông qua ba đối tượng chính:

- Một hình toán học, được tạo bằng [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape), là hình chứa phương trình.
- [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) lưu trữ nội dung toán học bên trong khung văn bản của hình.
- [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) chứa một hoặc nhiều đối tượng [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/).

Hầu hết các ví dụ dưới đây sử dụng [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) và các phương thức linh hoạt từ [MathElementBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) để giữ mã ngắn gọn và dễ đọc.

Đối với các trường hợp xuất MathML, xem [Xuất các phương trình toán học từ bản trình bày trong Node.js qua Java](/slides/vi/nodejs-java/exporting-math-equations/).

## **Tạo một Phương trình**

Ví dụ này sử dụng [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) để tạo một hình toán học và thêm định lý Pythagoras:

![The equation c squared equals a squared plus b squared](powerpoint-math-equations_3.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let equation = new aspose.slides.MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new aspose.slides.MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new aspose.slides.MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) tạo một hình đã chứa sẵn một đoạn toán học. Truy cập [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) đầu tiên, gọi [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph), và thêm các khối toán học hoặc phần tử toán học vào đó.
{{% /alert %}}

## **Thêm Phân Số**

Sử dụng [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#divide) để tạo một phân số. Bạn có thể chọn kiểu phân số bằng [MathFractionTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/).

![A skewed math fraction showing one divided by x](powerpoint-math-equations_4.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let fraction = new aspose.slides.MathematicalText("1")
            .divide("x", aspose.slides.MathFractionTypes.Skewed);

    mathParagraph.add(new aspose.slides.MathBlock(fraction));

    presentation.save("fraction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đối với phân số chồng, sử dụng [MathFractionTypes.Bar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/#Bar):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **Thêm Căn Bậc**

Sử dụng [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#radical) để tạo căn bậc hai, căn bậc ba hoặc các căn khác. Phần tử hiện tại trở thành cơ sở, và đối số trở thành độ bậc.

![An n-th root radical expression with x under the radical sign](powerpoint-math-equations_5.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let radical = new aspose.slides.MathematicalText("x")
            .radical("n");

    mathParagraph.add(new aspose.slides.MathBlock(radical));

    presentation.save("radical.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Hiển thị hoặc Ẩn Độ bậc của Căn bậc hai**

Căn bậc hai có thể hiển thị số 2 rõ ràng hoặc sử dụng ký hiệu chuẩn √x. Phương thức [setHideDegree](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/#setHideDegree) của [MathRadical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/) kiểm soát dạng nào được hiển thị. Cả hai dạng đều giữ độ bậc 2 và radicand x trong phương trình có thể chỉnh sửa.

![The same square root with the degree visible on the left and hidden on the right](square-root-degree.png)

Ví dụ lưu cùng một căn bậc hai hai lần. Trong `visible-degree.pptx`, số 2 được hiển thị. Trong `hidden-degree.pptx`, nó bị ẩn.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let radical = new aspose.slides.MathematicalText("x").radical("2");
    
    let shape = slide.getShapes().addMathShape(20, 20, 200, 100);
    let portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getMathParagraph().add(new aspose.slides.MathBlock(radical));

    radical.setHideDegree(false);
    presentation.save("visible-degree.pptx", aspose.slides.SaveFormat.Pptx);

    radical.setHideDegree(true);
    presentation.save("hidden-degree.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thêm Hàm và Giới Hạn**

Sử dụng [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) hoặc [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) cho các hàm như `sin(x)`, `log(x)` hoặc tên hàm tùy chỉnh. Đối với giới hạn, đặt `lim` trong một [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathlimit/) hoặc sử dụng [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setLowerLimit).

![The limit of x as x approaches infinity](powerpoint-math-equations_8.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let limit = new aspose.slides.MathematicalText("lim")
            .setLowerLimit("x\u2192\u221E")
            .function("x");

    mathParagraph.add(new aspose.slides.MathBlock(limit));

    presentation.save("functions-and-limits.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đối với tên hàm tùy chỉnh, đặt tên hàm làm phần tử hiện tại và gọi [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) với đối số của nó:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **Thêm Toán tử N-ary và Tích Phân**

Sử dụng [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#nary) cho các phép cộng, hợp, giao và các toán tử lớn khác. Sử dụng [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) cho tích phân. Cả hai phương thức cho phép bạn đặt giới hạn dưới và trên.

![A summation with lower and upper limits](powerpoint-math-equations_7.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let summationBase = new aspose.slides.MathematicalText("x")
            .setSuperscript("k")
            .join(new aspose.slides.MathematicalText("a").setSuperscript("n-k"));

    let summation = summationBase.nary(aspose.slides.MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new aspose.slides.MathBlock(summation));

    presentation.save("nary-operators.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Toán tử N-ary dành cho các toán tử lớn có tùy chọn giới hạn. Các toán tử đơn giản như `+`, `-`, và `=` thường được thêm dưới dạng [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) và nối vào biểu thức.

Đối với một tích phân, sử dụng [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **Thêm Ma Trận**

Sử dụng [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) cho các hàng và cột. Mặc định ma trận không có dấu ngoặc, vì vậy hãy bao quanh ma trận khi bạn cần dấu ngoặc đơn, dấu ngoặc vuông hoặc dấu ngoặc nhọn.

![A two-row math matrix with one empty cell](powerpoint-math-equations_10.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let matrix = new aspose.slides.MathMatrix(2, 3);
    matrix.set_Item(0, 0, new aspose.slides.MathematicalText("1"));
    matrix.set_Item(0, 1, new aspose.slides.MathematicalText("x"));
    matrix.set_Item(1, 0, new aspose.slides.MathematicalText("x"));
    matrix.set_Item(1, 1, new aspose.slides.MathematicalText("2"));
    matrix.set_Item(1, 2, new aspose.slides.MathematicalText("y"));

    mathParagraph.add(new aspose.slides.MathBlock(matrix));

    presentation.save("matrix.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Chỉnh sửa Ma Trận hiện có**

Giả sử một bài học đại số tuyến tính bắt đầu với ma trận hệ số trong `matrix.pptx`, được lưu bằng ví dụ trước. Đối với bài tập tiếp theo, giữ lại phương trình đầu tiên, thay thế phương trình thứ hai bằng hai phương trình mới, và sửa đổi tập các biến. Mở ma trận hiện có qua [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) để giữ lại các hệ số vẫn còn áp dụng.

![Original two-row coefficient matrix with entries 1, x, and an empty cell in the first row and x, 2, and y in the second](matrix-before-edit.png)

Chỉ số hàng và cột bắt đầu từ 0 và tham chiếu tới ma trận tại thời điểm mỗi lần gọi. Chèn một hàng trước chỉ số 1 sẽ đưa hàng thứ hai gốc lên chỉ số 2. Chèn sau chỉ số 2 sẽ thêm một hàng. Xóa hàng 2 sẽ loại bỏ phương trình thứ hai gốc và di chuyển hàng đã thêm lên một vị trí. Các cột cũng dịch chuyển tương tự.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("matrix.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    const matrix = portion.getMathParagraph().get_Item(0).get_Item(0);

    matrix.insertRowBefore(1);
    matrix.insertRowAfter(2);
    matrix.deleteRow(2);

    matrix.insertColumnBefore(1);
    matrix.insertColumnAfter(3);
    matrix.deleteColumn(3);

    // Các ô mới ban đầu là null. Đặt các hệ số khác 0 trước.
    matrix.set_Item(1, 0, new slides.MathematicalText("12"));
    matrix.set_Item(1, 1, new slides.MathematicalText("1"));
    matrix.set_Item(2, 2, new slides.MathematicalText("10"));
    matrix.set_Item(2, 3, new slides.MathematicalText("1"));
    for (let row = 0; row < matrix.getRowCount(); row++) {
        for (let column = 0; column < matrix.getColumnCount(); column++) {
            if (matrix.get_Item(row, column) == null) {
                matrix.set_Item(row, column, new slides.MathematicalText("0"));
            }
        }
    }

    matrix.setColumnAlignment(0, slides.MathHorizontalAlignment.Left);
    matrix.setColumnsAlignment(1, 3, slides.MathHorizontalAlignment.Right);

    presentation.save("updated-matrix.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setColumnAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/#setColumnAlignment) căn chỉnh cột đầu tiên sang trái. [setColumnsAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/#setColumnsAlignment) căn chỉnh ba cột liên tiếp sang phải, bắt đầu tại chỉ số 1. Trong `updated-matrix.pptx`, ma trận có ba phương trình và bốn biến. Các hệ số hàng đầu tiên gốc `1` và `x` hiện xuất hiện ở cột thứ nhất và thứ ba.

![Updated three-row matrix showing the rows 1, 0, x, 0; 12, 1, 0, 0; and 0, 0, 10, 1](matrix-after-edit.png)

## **Thêm Mảng Phương Trình**

Sử dụng [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toMathArray) khi bạn cần các phương trình căn chỉnh hoặc một chồng dọc các biểu thức.

![A vertical math array with x above y](powerpoint-math-equations_11.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let equationArray = new aspose.slides.MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new aspose.slides.MathBlock(equationArray));

    presentation.save("equation-array.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Căn chỉnh Mảng với Các Phần tử Xung quanh**

[setBaseJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setBaseJustification) kiểm soát việc căn dọc của một mảng so với các phần tử toán học bên cạnh nó. Ví dụ dưới đây so sánh việc căn chỉnh với hàng đầu tiên, giữa mảng, và hàng cuối cùng.

Ví dụ tạo ba mảng giống nhau, mỗi mảng có ba hàng và các phần tử lân cận `A=` và `=B`. Tất cả văn bản toán học sử dụng Cambria Math kích thước 24 điểm. Chỉ việc căn chỉnh mảng được thay đổi.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function createText(value) {
    const text = new slides.MathematicalText(value);
    text.getFormat().setFontHeight(24);
    text.getFormat().setLatinFont(new slides.FontData("Cambria Math"));
    return text;
}

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(780, 200, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const alignments = [slides.MathVerticalAlignment.Top, slides.MathVerticalAlignment.Center, slides.MathVerticalAlignment.Bottom];
    const alignmentNames = ["Top", "Center", "Bottom"];

    for (let i = 0; i < alignments.length; i++) {
        const label = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 20 + i * 260, 10, 240, 30);
        label.getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getTextFrame().setText(alignmentNames[i]);
        const labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(16);
        labelFormat.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
        labelFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        const mathShape = slide.getShapes().addMathShape(20 + i * 260, 60, 240, 130);
        mathShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(slides.TextAnchorType.Top));
        const mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
        mathParagraph.setJustification(slides.MathJustification.LeftJustified);

        const rows = [createText("x+y=3"), createText("x-y=1"), createText("x=2")];
        const equationArray = new slides.MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(alignments[i]);
        const leftText = createText("A=");
        const rightText = createText("=B");
        const equation = new slides.MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);
    }

    presentation.save("equation-array-alignment.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

So sánh dưới đây hiển thị bản trình chiếu đã lưu trong PowerPoint. Lưu ý vị trí của `A=` và `=B` bên cạnh mỗi mảng.

![Equation arrays in PowerPoint with Top, Center, and Bottom alignment and identical neighboring elements](equation-array-alignment.png)

### **Cấu hình Khoảng cách Hàng**

[setRowSpacingRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacingRule) chọn quy tắc khoảng cách cho các hàng trong mảng. [setRowSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacing) cung cấp một giá trị số cho quy tắc khoảng cách cụ thể và sẽ bị bỏ qua bởi các quy tắc mặc định.

Đối với khoảng cách chính xác, giá trị được đo bằng điểm. Đối với khoảng cách tỷ lệ, nó được đo bằng nửa dòng: giá trị `3` trong ví dụ tương đương 1.5 dòng. Khi chỉ định giá trị cụ thể, hãy đặt cả hai thuộc tính; việc chỉ thay đổi giá trị số không chọn quy tắc khoảng cách.

Ví dụ dưới đây lưu năm bản trình chiếu với cùng các phương trình, căn chỉnh và cài đặt phông chữ. Ba bản đầu tiên sử dụng cài đặt sẵn; hai bản cuối hiển thị các giá trị cụ thể.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function createText(value) {
    const text = new slides.MathematicalText(value);
    text.getFormat().setFontHeight(24);
    text.getFormat().setLatinFont(new slides.FontData("Cambria Math"));
    return text;
}

const rules = [slides.MathRowSpacingRule.SingleLineGap, slides.MathRowSpacingRule.OneAndAHalfLineGap, slides.MathRowSpacingRule.TwoLineGap, slides.MathRowSpacingRule.Exactly, slides.MathRowSpacingRule.Multiple];
const spacingValues = [0, 0, 0, 20, 3];
const ruleNames = ["SingleLineGap", "OneAndAHalfLineGap", "TwoLineGap", "Exactly", "Multiple"];

for (let i = 0; i < rules.length; i++) {
    const fileName = "equation-array-" + ruleNames[i] + ".pptx";
    const presentation = new slides.Presentation();
    try {
        const mathShape = presentation.getSlides().get_Item(0).getShapes().addMathShape(20, 20, 600, 300);
        const paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        const mathParagraph = paragraph.getPortions().get_Item(0).getMathParagraph();
        mathParagraph.setJustification(slides.MathJustification.LeftJustified);

        const rows = [createText("x+y=3"), createText("x-y=1"), createText("x=2")];
        const equationArray = new slides.MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(slides.MathVerticalAlignment.Center);
        equationArray.setRowSpacingRule(rules[i]);
        equationArray.setRowSpacing(java.newLong(spacingValues[i]));
        const leftText = createText("A=");
        const rightText = createText("=B");
        const equation = new slides.MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);

        presentation.save(fileName, slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

Khoảng cách hàng trong mảng riêng biệt với khoảng cách đoạn. [setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) và [setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter) thêm khoảng cách xung quanh đoạn chứa, không phải giữa các hàng của mảng. Tương tự, [MathParagraph.setJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#setJustification) định vị toàn bộ đoạn toán học theo chiều ngang; nó không thay thế thiết lập căn dọc của mảng.

## **Thêm Hàm lượng giác**

Sử dụng [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) khi đối số là phần tử hiện tại và tên hàm đã biết.

![The trigonometric function cos applied to 2x](powerpoint-math-equations_6.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let cosine = new aspose.slides.MathematicalText("2x")
            .asArgumentOfFunction(aspose.slides.MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new aspose.slides.MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thêm Chỉ số và Chỉ số mũ**

Sử dụng các trợ giúp chỉ số và chỉ số mũ cho các chỉ mục và lũy thừa. Khi các chỉ số phải xuất hiện phía bên trái của cơ sở, sử dụng [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![A capital Y with left-side subscript 1 and superscript n](powerpoint-math-equations_9.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let scripts = new aspose.slides.MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new aspose.slides.MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thêm Dấu phân cách**

Sử dụng [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#enclose) để đặt một biểu thức bên trong dấu phân cách. Bạn cũng có thể đặt ký tự phân tách cho các biểu thức dấu phân cách chứa nhiều phần tử.

![A delimiter expression containing x, y, and z separated by vertical bars](powerpoint-math-equations_13.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let delimiter = new aspose.slides.MathematicalText("x")
            .join("y")
            .join("z")
            .enclose(java.newChar('<'), java.newChar('>'));
    delimiter.setSeparatorCharacter(java.newChar('|'));

    mathParagraph.add(new aspose.slides.MathBlock(delimiter));

    presentation.save("delimiters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Kích thước và Căn chỉnh Dấu phân cách**

Đặt `true` cho [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) để cho ngoặc tròn mở rộng bao quanh một toán hạng cao, hoặc đặt `false` để giữ chúng ở kích thước bình thường. Sử dụng [setDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setDelimiterShape) với một trong hai giá trị của [MathDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimitershape/). `Centered` căn giữa ngoặc quanh trục toán học, đi qua giữa dấu bằng. `Match` căn chúng với nội dung bên trong. Cả hai cài đặt chỉ ảnh hưởng đến dấu phân cách. Biểu thức bên trong không thay đổi.

Ví dụ đặt một phân số trong lũy thừa của `x` để biểu thức mở rộng cao hơn so với đường cơ sở so với phía dưới. Bốn phương trình đều sử dụng cùng một dấu ngoặc và cài đặt phông chữ.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    for (let row = 0; row < 2; row++) {
        for (let column = 0; column < 2; column++) {
            const fraction = new slides.MathematicalText("a + b").divide("c + d");
            const power = new slides.MathematicalText("x").setSuperscript(fraction);
            const delimiter = power.enclose(java.newChar('('), java.newChar(')'));
            delimiter.setGrowToMatchOperandHeight(row === 0);
            delimiter.setDelimiterShape(column === 0 ? slides.MathDelimiterShape.Centered : slides.MathDelimiterShape.Match);

            const mathShape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100);
            const portion = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            portion.getPortionFormat().setFontHeight(32);
            const equation = new slides.MathematicalText("y = ").join(delimiter);
            portion.getMathParagraph().add(equation);
        }
    }
    presentation.save("delimiter-sizing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Trong PowerPoint, so sánh các hàng để thấy hiệu ứng mở rộng. Ở hàng trên, ngoặc mở rộng để bao quanh lũy thừa và trông giống nhau cho cả hai kiểu. Ở hàng dưới, tính năng mở rộng bị tắt. Các ngoặc nhỏ hơn bên trái (`Centered`) căn với dấu bằng, trong khi các ngoặc bên phải (`Match`) nằm cao hơn quanh biểu thức.

![Four equations in PowerPoint with delimiter growth enabled above and disabled below, and Centered on the left and Match on the right](delimiter-sizing.png)

## **Thêm Khung Viền**

Gọi [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toBorderBox) trên một phân số để tạo khung cho toàn bộ biểu thức. [MathBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/) trả về hiển thị cả bốn phía theo mặc định. Sử dụng [setHideTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideLeft), và [setHideRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideRight) để loại bỏ các phía riêng lẻ.

Ví dụ đặt sáu bản sao của cùng một phân số trên một slide. Để hiển thị việc hủy, ẩn cả bốn phía và đặt `true` cho [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) để tạo đường chéo lên (↗) hoặc [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) để tạo đường chéo xuống (↘). Bạn cũng có thể sử dụng [setStrikethroughHorizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) hoặc [setStrikethroughVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughVertical) với bất kỳ tổ hợp các phía hiển thị nào.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(540, 220, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    function addFraction(x, y, hideBorder) {
        const fraction = new slides.MathematicalText("x+1").divide("y+2");
        const box = fraction.toBorderBox();
        box.setHideTop(hideBorder);
        box.setHideBottom(hideBorder);
        box.setHideLeft(hideBorder);
        box.setHideRight(hideBorder);

        const shape = slide.getShapes().addMathShape(x, y, 160, 90);
        const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        portion.getPortionFormat().setFontHeight(28);
        const block = new slides.MathBlock(box);
        portion.getMathParagraph().add(block);
        return box;
    }

    addFraction(10, 10, false);

    const partial = addFraction(190, 10, false);
    partial.setHideTop(true);
    partial.setHideRight(true);

    addFraction(370, 10, true).setStrikethroughBottomLeftToTopRight(true);
    addFraction(10, 120, true).setStrikethroughTopLeftToBottomRight(true);
    addFraction(190, 120, true).setStrikethroughHorizontal(true);
    addFraction(370, 120, false).setStrikethroughVertical(true);

    presentation.save("border-box.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Six editable fractions in PowerPoint. Top row: full border, bottom and left sides, rising diagonal. Bottom row: falling diagonal, horizontal strike, vertical strike with a full border.](border-box-fractions.png)

Trong phân số này, nét gạch ngang chồng lên thanh phân số. Nét gạch dọc cắt cả tử và mẫu trong khi khung bao quanh vẫn hiển thị. Những đường này trang trí toàn bộ biểu thức. Gạch ngang văn bản thông thường áp dụng cho các ký tự trong một đoạn văn bản. Sau khi mở lại bản trình chiếu trong PowerPoint, bạn vẫn có thể chỉnh sửa tử và mẫu một cách độc lập.

## **Kiểm soát Hiển thị và Bố cục với Các Phần tử Phantom**

Bao bọc một biểu thức bằng [MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/) để kiểm soát khả năng hiển thị và không gian nó đóng góp cho một phương trình một cách độc lập. Các phương thức của [MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/) kiểm soát các mục sau:

| Method | Effect |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow) | Đặt `false` để ẩn biểu thức. Kích thước của nó vẫn đóng góp vào bố cục trừ khi các phương thức tương ứng phía dưới nhận `true`. |
| [setZeroWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroWidth) | Xem xét độ rộng ngang của biểu thức là zero, cho phép các phần tử lân cận di chuyển gần nhau hơn. |
| [setZeroAsc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroAsc) | Xem xét độ lên (ascent), chiều cao trên đường cơ sở, là zero. Điều này có thể giảm không gian dành cho phía trên các phần tử lân cận. |
| [setZeroDesc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroDesc) | Xem xét độ xuống (descent), chiều sâu dưới đường cơ sở, là zero. Điều này có thể di chuyển thanh phân số hoặc nội dung khác phía dưới biểu thức gần hơn các phần tử bên cạnh. |

Đường cơ sở là đường tham chiếu mà các ký tự toán học thường nằm trên. Ẩn nội dung không loại bỏ kích thước của nó, và xem một kích thước là zero không xóa biểu thức. Biểu thức nền vẫn có sẵn qua [getBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#getBase). Đặt `true` cho [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow) để hiển thị lại; các cài đặt kích thước vẫn không thay đổi.

Ví dụ dưới đây tạo năm biến thể đặt cạnh nhau: một phân số hiển thị, một phân số ẩn nhưng vẫn giữ không gian, và ba phân số ẩn với một kích thước được xem là zero. Mỗi biến thể sử dụng cùng một biểu thức bao quanh và Cambria Math kích thước 24 điểm. Tất cả các hình phương trình đều có vị trí trên cùng, được đánh dấu bằng hướng dẫn màu xám. Đặt phantom trong tử của một phân số ngoài giúp dễ dàng thấy các thay đổi bố cục dọc.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function createText(value) {
    const text = new slides.MathematicalText(value);
    text.getFormat().setFontHeight(24);
    text.getFormat().setLatinFont(new slides.FontData("Cambria Math"));
    return text;
}

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(1000, 180, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const labels = [ "Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc" ];

    const guide = slide.getShapes().addAutoShape(slides.ShapeType.Line, 10, 60, 980, 0);
    guide.getLineFormat().getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    for (let i = 0; i < labels.length; i++) {
        const left = 10 + i * 200;

        const label = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, left, 10, 190, 30);
        label.getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getTextFrame().setText(labels[i]);

        const labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(14);
        labelFormat.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
        labelFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        const fractionNumerator = createText("a+b");
        const fractionDenominator = createText("c+d");
        const fraction = new slides.MathFraction(fractionNumerator, fractionDenominator);
        const phantom = new slides.MathPhantom(fraction);
        phantom.setShow(i === 0);
        phantom.setZeroWidth(i === 2);
        phantom.setZeroAsc(i === 3);
        phantom.setZeroDesc(i === 4);

        const leftText = createText("x+");
        const rightText = createText("+y");
        const numerator = new slides.MathBlock(leftText).join(phantom).join(rightText);
        const denominator = createText("z");
        const equation = new slides.MathFraction(numerator, denominator);

        const shape = slide.getShapes().addMathShape(left, 60, 190, 100);
        shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(slides.TextAnchorType.Top));

        const mathPortion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        const mathParagraph = mathPortion.getMathParagraph();
        mathParagraph.add(new slides.MathBlock(equation));
    }

    presentation.save("math-phantom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Five equations in PowerPoint comparing a visible fraction, a hidden fraction that reserves space, and hidden fractions with ZeroWidth, ZeroAsc, or ZeroDesc enabled](math-phantom.png)

## **Nhóm Các Thuật Ngữ**

Sử dụng [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#group) để đặt một ký tự nhóm phía trên hoặc dưới một biểu thức. Thêm một giới hạn để đặt nhãn cho các thuật ngữ đã nhóm.

![The expression x plus y grouped with the label any text below it](powerpoint-math-equations_15.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let grouped = new aspose.slides.MathematicalText("x + y")
            .group(java.newChar('\u23DF'), aspose.slides.MathTopBotPositions.Bottom, aspose.slides.MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new aspose.slides.MathBlock(grouped));

    presentation.save("grouped-terms.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Định dạng Các Phần tử Toán học**

Sử dụng các trợ giúp định dạng chỉ khi chúng làm rõ công thức. Ví dụ, [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#overbar) đặt một thanh trên một phần tử toán học.

![A math expression ABC with an overbar](powerpoint-math-equations_14.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let overbar = new aspose.slides.MathematicalText("ABC").overbar();

    mathParagraph.add(new aspose.slides.MathBlock(overbar));

    presentation.save("overbar.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Định dạng Văn bản trong một Phương trình hiện có**

Để định dạng văn bản trong toàn bộ một phương trình hiện có, duyệt cây phần tử của mỗi khối toán học. [MathElementBase.getChildren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#getChildren) trả về chỉ các phần tử con trực tiếp, vì vậy gọi đệ quy để đạt tới văn bản bên trong phân số, chỉ số, căn bậc và các cấu trúc lồng nhau khác. Kiểm tra phần tử hiện tại cũng như các phần tử con để bao gồm phần tử bắt đầu khi nó là [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/).

Ví dụ này giả định rằng `input.pptx` chứa một phương trình như `z = xᵢ / ∛y`, với một phân số có chỉ số phụ trong tử và một căn bậc trong mẫu. Chỉ xử lý các phần tử cấp đầu của khối sẽ bỏ lỡ văn bản bên trong phân số. Ví dụ tìm các phần toán học trong khung văn bản slide, truy cập các khối của chúng qua [MathPortion.getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph), và sử dụng [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) để đặt kích thước phông chữ là 28 điểm cho mỗi phần tử văn bản thông qua phương thức [getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/#getFormat).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatMathText(element) {
    if (java.instanceOf(element, "com.aspose.slides.MathematicalText")) {
        element.getFormat().setFontHeight(28);
    }

    let children = element.getChildren();
    for (let i = 0; i < children.length; i++) {
        formatMathText(children[i]);
    }
}

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }

            let textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let k = 0; k < textFrame.getParagraphs().getCount(); k++) {
                let paragraph = textFrame.getParagraphs().get_Item(k);
                for (let l = 0; l < paragraph.getPortions().getCount(); l++) {
                    let portion = paragraph.getPortions().get_Item(l);
                    if (java.instanceOf(portion, "com.aspose.slides.IMathPortion")) {
                        let mathParagraph = portion.getMathParagraph();
                        for (let m = 0; m < mathParagraph.getCount(); m++) {
                            formatMathText(mathParagraph.get_Item(m));
                        }
                    }
                }
            }
        }
    }

    presentation.save("formatted-equations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bản trình chiếu đã lưu chứa định dạng văn bản đã cập nhật ở mọi cấp độ của mỗi phương trình đã xử lý, đồng thời giữ nguyên nội dung văn bản và cấu trúc toán học.

## **Tham chiếu nhanh**

| Nhiệm vụ | API chính |
| --- | --- |
| Tạo văn bản toán học | [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) |
| Kết hợp các phần tử | [join](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Tạo phân số | [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Thêm chỉ số mũ hoặc chỉ số phụ | [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Thêm hàm | [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Thêm căn bậc | [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Thêm giới hạn | [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Thêm chỉ số bên trái | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Thêm tổng và tích phân | [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Thêm ma trận | [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) |
| Thêm mảng phương trình | [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Thêm dấu phân cách | [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Thêm thanh và viền | [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Nhóm các thuật ngữ | [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |

## **Câu hỏi thường gặp**

**Tôi có thể chỉnh sửa một phương trình PowerPoint hiện có không?**

Có. Mở bản trình chiếu, tìm hình chứa một [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/), gọi [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph), và cập nhật các khối toán học trong đoạn đó.

**Phương trình có được lưu dưới dạng toán học PowerPoint có thể chỉnh sửa không?**

Có. Khi lưu dưới dạng PPTX, Aspose.Slides ghi phương trình dưới dạng nội dung Office math có thể chỉnh sửa.

**Tôi có thể xuất phương trình sang LaTeX không?**

Có. Lấy [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) của phương trình từ [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/), và gọi [MathParagraph.toLatex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#toLatex) để xuất trực tiếp. Đối với một ví dụ đầy đủ, xem [Xuất các phương trình toán học từ bản trình bày trong Node.js qua Java](/slides/vi/nodejs-java/exporting-math-equations/#export-math-equations-to-latex).