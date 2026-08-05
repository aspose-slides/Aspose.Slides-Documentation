---
title: Thêm các Phương trình Toán học vào Bài thuyết trình PowerPoint trong JavaScript
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
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Chèn và chỉnh sửa các phương trình toán học trong PowerPoint PPT và PPTX bằng Aspose.Slides cho Node.js qua Java, hỗ trợ OMML, các điều khiển định dạng, và các mẫu mã JavaScript rõ ràng."
---
## **Tổng quan**

PowerPoint lưu các công thức dưới dạng Office Math Markup Language (OMML). Với Aspose.Slides cho Node.js via Java, bạn có thể tạo cùng loại nội dung toán học một cách lập trình: phân số, căn bậc, hàm, giới hạn, N-ary operators, ma trận, mảng và các khối toán học định dạng.

Trong PowerPoint, người dùng thường thêm công thức từ **Insert > Equation**:

![Tab Insert của PowerPoint với lệnh Equation được chọn](powerpoint-math-equations_1.png)

Kết quả là văn bản toán học có thể chỉnh sửa trên slide:

![Một slide PowerPoint chứa một công thức toán học có thể chỉnh sửa](powerpoint-math-equations_2.png)

Aspose.Slides xây dựng văn bản toán học đó thông qua ba đối tượng chính:

- Một hình toán học, được tạo bằng [addMathShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/#addMathShape), là hình chứa công thức.
- [MathPortion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathportion/) lưu trữ nội dung toán học trong khung văn bản của hình.
- [MathParagraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathparagraph/) chứa một hoặc nhiều đối tượng [MathBlock](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathblock/).

Hầu hết các ví dụ dưới đây sử dụng [MathematicalText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathematicaltext/) và các phương thức fluent từ [MathElementBase](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/) để giữ cho mã ngắn gọn và dễ đọc.

Đối với các kịch bản xuất MathML, xem [Export Math Equations from Presentations in Node.js via Java](/slides/vi/nodejs-java/exporting-math-equations/).

## **Tạo một công thức**

Ví dụ này tạo một hình toán học và thêm định lý Pythagoras:

![Phương trình c bình phương bằng a bình phương cộng b bình phương](powerpoint-math-equations_3.png)

```javascript
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

{{% alert color="primary" %}}
`addMathShape` tạo một hình đã chứa sẵn một đoạn toán học. Truy cập `MathPortion` đầu tiên, lấy `MathParagraph` của nó, và thêm các khối toán hoặc phần tử toán học vào đó.
{{% /alert %}}

## **Thêm phân số**

Sử dụng [`divide`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/) để tạo một phân số. Bạn có thể chọn kiểu phân số với [MathFractionTypes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathfractiontypes/).

![Một phân số toán học lệch cho thấy 1 chia cho x](powerpoint-math-equations_4.png)

```javascript
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

Đối với phân số xếp chồng, sử dụng `MathFractionTypes.Bar`:

```javascript
let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **Thêm căn bậc**

Sử dụng [`radical`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/) để tạo căn bậc hai, căn bậc ba hoặc các căn khác. Phần tử hiện tại trở thành cơ số và đối số trở thành độ bậc.

![Một biểu thức căn bậc n với x dưới dấu căn](powerpoint-math-equations_5.png)

```javascript
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

## **Thêm hàm và giới hạn**

Sử dụng [`asArgumentOfFunction`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/) hoặc [`function`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/) cho các hàm như `sin(x)`, `log(x)`, hoặc tên hàm tùy chỉnh. Đối với giới hạn, đặt `lim` trong một [MathLimit](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathlimit/) hoặc sử dụng [`setLowerLimit`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/).

![Giới hạn của x khi x tiến tới vô hạn](powerpoint-math-equations_8.png)

```javascript
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

Đối với tên hàm tùy chỉnh, đặt tên hàm làm phần tử hiện tại:

```javascript
let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **Thêm toán tử N-ary và tích phân**

Sử dụng [`nary`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/) cho các phép cộng, hợp, giao và các toán tử lớn khác. Sử dụng [`integral`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/) cho tích phân. Cả hai phương thức cho phép bạn đặt giới hạn dưới và trên.

![Một tổng với giới hạn dưới và trên](powerpoint-math-equations_7.png)

```javascript
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

Các toán tử N-ary dành cho các toán tử lớn có thể có giới hạn tùy chọn. Các toán tử đơn giản như `+`, `-`, và `=` thường được thêm dưới dạng `MathematicalText` và ghép vào biểu thức.

Đối với tích phân, sử dụng `integral`:

```javascript
let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **Thêm ma trận**

Sử dụng [MathMatrix](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathmatrix/) cho các hàng và cột. Ma trận mặc định không có ngoặc, vì vậy hãy bao quanh ma trận khi bạn cần dấu ngoặc tròn, ngoặc vuông hoặc ngoặc nhọn.

![Một ma trận toán học hai hàng với một ô trống](powerpoint-math-equations_10.png)

```javascript
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

## **Thêm mảng công thức**

Sử dụng [`toMathArray`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/) khi bạn cần các công thức căn chỉnh hoặc một chồng dọc các biểu thức.

![Một mảng toán học dọc với x phía trên y](powerpoint-math-equations_11.png)

```javascript
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

## **Thêm hàm lượng giác**

Sử dụng [`asArgumentOfFunction`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/) khi đối số là phần tử hiện tại và tên hàm đã biết.

![Hàm lượng giác cos áp dụng cho 2x](powerpoint-math-equations_6.png)

```javascript
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

## **Thêm chỉ số dưới và chỉ số trên**

Sử dụng các trợ giúp chỉ số dưới và chỉ số trên cho chỉ mục và lũy thừa. Khi các chỉ số phải xuất hiện ở phía trái của cơ sở, sử dụng [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/).

![Một chữ Y in hoa với chỉ số dưới 1 ở phía trái và chỉ số trên n](powerpoint-math-equations_9.png)

```javascript
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

## **Thêm dấu bao**

Sử dụng [`enclose`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/) để bao một biểu thức trong dấu bao. Bạn cũng có thể đặt ký tự phân tách cho các biểu thức dấu bao chứa nhiều phần tử.

![Một biểu thức dấu bao chứa x, y và z được ngăn cách bằng các dấu gạch đứng](powerpoint-math-equations_13.png)

```javascript
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

## **Thêm khung viền**

Sử dụng [`toBorderBox`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/) khi công thức cần được đóng khung.

![Một công thức a bình phương bằng b bình phương cộng c bình phương được đóng khung](powerpoint-math-equations_12.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let boxedEquation = new aspose.slides.MathematicalText("a")
            .setSuperscript("2")
            .join("=")
            .join(new aspose.slides.MathematicalText("b").setSuperscript("2"))
            .join("+")
            .join(new aspose.slides.MathematicalText("c").setSuperscript("2"))
            .toBorderBox();

    mathParagraph.add(new aspose.slides.MathBlock(boxedEquation));

    presentation.save("border-box.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nhóm các thuật ngữ**

Sử dụng [`group`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/) để đặt ký tự nhóm phía trên hoặc phía dưới một biểu thức. Thêm giới hạn để gắn nhãn cho các thuật ngữ được nhóm.

![Biểu thức x cộng y được nhóm với nhãn bất kỳ văn bản nào ở phía dưới](powerpoint-math-equations_15.png)

```javascript
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

## **Định dạng các phần tử toán học**

Chỉ sử dụng các trợ giúp định dạng khi chúng làm rõ công thức. Ví dụ, [`overbar`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/) đặt một thanh phía trên một phần tử toán học.

![Một biểu thức toán học ABC có thanh trên](powerpoint-math-equations_14.png)

```javascript
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

## **Tham khảo nhanh**

| Task | Main API |
| --- | --- |
| Tạo văn bản toán học | [MathematicalText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathematicaltext/) |
| Kết hợp các phần tử | [join](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/) |
| Tạo phân số | [divide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/) |
| Thêm chỉ số trên hoặc chỉ số dưới | [setSuperscript](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/) |
| Thêm hàm | [function](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/) |
| Thêm căn bậc | [radical](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/) |
| Thêm giới hạn | [setLowerLimit](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/) |
| Thêm chỉ số phía trái | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/) |
| Thêm tổng và tích phân | [nary](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/) |
| Thêm ma trận | [MathMatrix](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathmatrix/) |
| Thêm mảng công thức | [toMathArray](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/) |
| Thêm dấu bao | [enclose](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/) |
| Thêm thanh và viền | [overbar](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/) |
| Nhóm các thuật ngữ | [group](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathelementbase/) |

## **Câu hỏi thường gặp**

**Tôi có thể chỉnh sửa một công thức PowerPoint hiện có không?**

Có. Mở bản trình chiếu, tìm hình chứa `MathPortion`, lấy `MathParagraph` của nó và cập nhật các khối toán trong đoạn đó.

**Các công thức có được lưu dưới dạng toán học PowerPoint có thể chỉnh sửa không?**

Có. Khi lưu dưới dạng PPTX, Aspose.Slides ghi công thức dưới dạng nội dung toán học Office có thể chỉnh sửa.

**Tôi có thể xuất công thức sang LaTeX không?**

Có. Lấy [MathParagraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathparagraph/) của công thức từ [MathPortion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathportion/), và gọi [MathParagraph.toLatex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mathparagraph/#toLatex--) để xuất trực tiếp. Đối với một ví dụ đầy đủ, xem [Export Math Equations from Presentations in Node.js via Java](/slides/vi/nodejs-java/exporting-math-equations/#export-math-equations-to-latex).