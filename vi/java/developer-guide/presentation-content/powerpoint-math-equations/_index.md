---
title: Thêm các Phương trình Toán học vào Bản trình chiếu PowerPoint trong Java
linktitle: Phương trình Toán học PowerPoint
type: docs
weight: 80
url: /vi/java/powerpoint-math-equations/
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
- bản trình chiếu
- Java
- Aspose.Slides
description: "Chèn và chỉnh sửa các phương trình toán học trong PowerPoint PPT và PPTX với Aspose.Slides cho Java, hỗ trợ OMML, điều khiển định dạng và các mẫu mã Java rõ ràng."
---
## **Tổng quan**

PowerPoint lưu trữ các phương trình dưới dạng Office Math Markup Language (OMML). Với Aspose.Slides cho Java, bạn có thể tạo nội dung toán học tương tự một cách lập trình: phân số, căn bậc, hàm số, giới hạn, toán tử N-ary, ma trận, mảng và các khối toán học đã định dạng.

Trong PowerPoint, người dùng thường thêm phương trình từ **Insert > Equation**:

![Tab Insert của PowerPoint với lệnh Equation đã được chọn](powerpoint-math-equations_1.png)

Kết quả là văn bản toán học có thể chỉnh sửa trên slide:

![Slide PowerPoint chứa một phương trình toán học có thể chỉnh sửa](powerpoint-math-equations_2.png)

Aspose.Slides xây dựng văn bản toán học đó thông qua ba đối tượng chính:

- Một hình toán học, được tạo bằng [addMathShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-), là hình chứa phương trình.
- [MathPortion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/mathportion/) lưu trữ nội dung toán học bên trong khung văn bản của hình.
- [MathParagraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/mathparagraph/) chứa một hoặc nhiều đối tượng [MathBlock](https://reference.aspose.com/slides/vi/java/com.aspose.slides/mathblock/).

Hầu hết các ví dụ dưới đây sử dụng [MathematicalText](https://reference.aspose.com/slides/vi/java/com.aspose.slides/mathematicaltext/) và các phương thức fluent từ [IMathElement](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imathelement/) để giữ cho mã ngắn gọn và dễ đọc.

Đối với các kịch bản xuất MathML, xem [Xuất các phương trình toán học từ bản trình chiếu trong Java](/slides/vi/java/exporting-math-equations/).

## **Tạo phương trình**

Ví dụ này tạo một hình toán học và thêm định lý Pythagoras:

![Phương trình c bình phương bằng a bình phương cộng b bình phương](powerpoint-math-equations_3.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock equation = new MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
`addMathShape` tạo một hình đã chứa sẵn một đoạn toán học. Truy cập `MathPortion` đầu tiên, lấy `MathParagraph` của nó và thêm các khối toán học hoặc phần tử toán học vào.
{{% /alert %}}

## **Thêm phân số**

Sử dụng `divide` để tạo một phân số. Bạn có thể chọn kiểu phân số bằng [MathFractionTypes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/mathfractiontypes/).

![Một phân số toán học nghiêng hiển thị 1 chia cho x](powerpoint-math-equations_4.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFraction fraction = new MathematicalText("1")
            .divide("x", MathFractionTypes.Skewed);

    mathParagraph.add(new MathBlock(fraction));

    presentation.save("fraction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đối với phân số chồng, sử dụng `MathFractionTypes.Bar`:

```java
IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **Thêm căn bậc**

Sử dụng `radical` để tạo căn bậc hai, căn bậc ba hoặc các căn bậc khác. Phần tử hiện tại trở thành cơ sở, và đối số trở thành bậc.

![Một biểu thức căn bậc n với x dưới dấu căn](powerpoint-math-equations_5.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathRadical radical = new MathematicalText("x")
            .radical("n");

    mathParagraph.add(new MathBlock(radical));

    presentation.save("radical.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thêm hàm và giới hạn**

Sử dụng `asArgumentOfFunction` hoặc `function` cho các hàm như `sin(x)`, `log(x)`, hoặc tên hàm tùy chỉnh. Đối với giới hạn, đặt `lim` trong một [MathLimit](https://reference.aspose.com/slides/vi/java/com.aspose.slides/mathlimit/) hoặc sử dụng `setLowerLimit`.

![Giới hạn của x khi x tiến tới vô cùng](powerpoint-math-equations_8.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction limit = new MathematicalText("lim")
            .setLowerLimit("x\u2192\u221E")
            .function("x");

    mathParagraph.add(new MathBlock(limit));

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đối với tên hàm tùy chỉnh, đặt tên hàm làm phần tử hiện tại:

```java
IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **Thêm toán tử N-ary và tích phân**

Sử dụng `nary` cho các phép cộng, hợp, giao và các toán tử lớn khác. Sử dụng `integral` cho các tích phân. Cả hai phương thức cho phép bạn đặt giới hạn dưới và trên.

![Một phép cộng với giới hạn dưới và trên](powerpoint-math-equations_7.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock summationBase = new MathematicalText("x")
            .setSuperscript("k")
            .join(new MathematicalText("a").setSuperscript("n-k"));

    IMathNaryOperator summation = summationBase.nary(MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new MathBlock(summation));

    presentation.save("nary-operators.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Các toán tử N-ary dành cho các toán tử lớn có thể có hoặc không có giới hạn. Các toán tử đơn giản như `+`, `-` và `=` thường được thêm dưới dạng `MathematicalText` và nối vào biểu thức.

Đối với một tích phân, sử dụng `integral`:

```java
IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **Thêm ma trận**

Sử dụng [MathMatrix](https://reference.aspose.com/slides/vi/java/com.aspose.slides/mathmatrix/) cho các hàng và cột. Mặc định ma trận không có dấu ngoặc, vì vậy hãy bao quanh ma trận khi bạn cần dấu ngoặc tròn, dấu ngoặc vuông hoặc dấu ngoặc nhọn.

![Một ma trận toán học hai hàng với một ô trống](powerpoint-math-equations_10.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    MathMatrix matrix = new MathMatrix(2, 3);
    matrix.set_Item(0, 0, new MathematicalText("1"));
    matrix.set_Item(0, 1, new MathematicalText("x"));
    matrix.set_Item(1, 0, new MathematicalText("x"));
    matrix.set_Item(1, 1, new MathematicalText("2"));
    matrix.set_Item(1, 2, new MathematicalText("y"));

    mathParagraph.add(new MathBlock(matrix));

    presentation.save("matrix.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thêm mảng phương trình**

Sử dụng `toMathArray` khi bạn cần các phương trình căn chỉnh hoặc một chồng dọc các biểu thức.

![Một mảng toán học dọc với x ở trên y](powerpoint-math-equations_11.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathArray equationArray = new MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new MathBlock(equationArray));

    presentation.save("equation-array.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thêm hàm lượng giác**

Sử dụng `asArgumentOfFunction` khi đối số là phần tử hiện tại và tên hàm đã biết.

![Hàm lượng giác cos áp dụng cho 2x](powerpoint-math-equations_6.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction cosine = new MathematicalText("2x")
            .asArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thêm chỉ số và mũ**

Sử dụng các trợ giúp chỉ số dưới và chỉ số trên cho các chỉ mục và lũy thừa. Khi các chỉ mục phải xuất hiện ở phía bên trái của cơ sở, sử dụng `setSubSuperscriptOnTheLeft`.

![Chữ Y in hoa với chỉ số dưới bên trái 1 và chỉ số trên n](powerpoint-math-equations_9.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLeftSubSuperscriptElement scripts = new MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thêm dấu phân cách**

Sử dụng `enclose` để đặt một biểu thức bên trong dấu phân cách. Bạn cũng có thể đặt ký tự phân cách cho các biểu thức dấu phân cách chứa nhiều phần tử.

![Một biểu thức dấu phân cách chứa x, y và z được ngăn bằng các dấu gạch đứng](powerpoint-math-equations_13.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathDelimiter delimiter = new MathematicalText("x")
            .join("y")
            .join("z")
            .enclose('<', '>');
    delimiter.setSeparatorCharacter('|');

    mathParagraph.add(new MathBlock(delimiter));

    presentation.save("delimiters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thêm hộp viền**

Sử dụng `toBorderBox` khi phương trình cần được đóng khung.

![Một phương trình được đóng khung cho thấy a bình phương bằng b bình phương cộng c bình phương](powerpoint-math-equations_12.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBorderBox boxedEquation = new MathematicalText("a")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("b").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("c").setSuperscript("2"))
            .toBorderBox();

    mathParagraph.add(new MathBlock(boxedEquation));

    presentation.save("border-box.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nhóm các hạng tử**

Sử dụng `group` để đặt một ký tự nhóm lên trên hoặc dưới một biểu thức. Thêm một giới hạn để gắn nhãn cho các hạng tử đã nhóm.

![Biểu thức x cộng y được nhóm với nhãn bất kỳ dưới nó](powerpoint-math-equations_15.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLimit grouped = new MathematicalText("x + y")
            .group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new MathBlock(grouped));

    presentation.save("grouped-terms.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Định dạng các phần tử toán học**

Sử dụng các trợ giúp định dạng chỉ khi chúng làm rõ công thức. Ví dụ, `overbar` đặt một thanh trên một phần tử toán học.

![Một biểu thức toán học ABC có thanh trên](powerpoint-math-equations_14.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBar overbar = new MathematicalText("ABC").overbar();

    mathParagraph.add(new MathBlock(overbar));

    presentation.save("overbar.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tham khảo nhanh**

| Nhiệm vụ | API chính |
| --- | --- |
| Tạo văn bản toán học | [MathematicalText](https://reference.aspose.com/slides/vi/java/com.aspose.slides/mathematicaltext/) |
| Kết hợp các phần tử | [IMathElement.join](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imathelement/#join-com.aspose.slides.IMathElement-) |
| Tạo phân số | [IMathElement.divide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) |
| Thêm chỉ số trên hoặc chỉ số dưới | [setSuperscript](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imathelement/#setSuperscript-com.aspose.slides.IMathElement-), [setSubscript](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imathelement/#setSubscript-com.aspose.slides.IMathElement-) |
| Thêm hàm | [function](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-), [asArgumentOfFunction](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) |
| Thêm căn bậc | [IMathElement.radical](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) |
| Thêm giới hạn | [setLowerLimit](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-), [setUpperLimit](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imathelement/#setUpperLimit-com.aspose.slides.IMathElement-) |
| Thêm chỉ số bên trái | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| Thêm tổng và tích phân | [nary](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-), [integral](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| Thêm ma trận | [MathMatrix](https://reference.aspose.com/slides/vi/java/com.aspose.slides/mathmatrix/) |
| Thêm mảng phương trình | [toMathArray](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imathelement/#toMathArray--) |
| Thêm dấu phân cách | [enclose](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imathelement/#enclose-char-char-) |
| Thêm thanh trên và hộp viền | [overbar](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imathelement/#overbar--), [toBorderBox](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imathelement/#toBorderBox--) |
| Nhóm các hạng tử | [group](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imathelement/#group-char-int-int-) |

## **Câu hỏi thường gặp**

**Tôi có thể chỉnh sửa một phương trình PowerPoint hiện có không?**

Có. Mở bản trình chiếu, tìm hình chứa `MathPortion`, lấy `MathParagraph` của nó và cập nhật các khối toán học trong đoạn đó.

**Các phương trình có được lưu dưới dạng toán học PowerPoint có thể chỉnh sửa không?**

Có. Khi lưu thành PPTX, Aspose.Slides ghi phương trình dưới dạng nội dung toán học Office có thể chỉnh sửa.

**Tôi có thể xuất phương trình sang LaTeX không?**

Aspose.Slides xuất các phương trình toán học sang MathML. Nếu bạn cần LaTeX, hãy xuất sang MathML trước và sau đó chuyển đổi MathML bằng công cụ hỗ trợ định dạng LaTeX mục tiêu của bạn.