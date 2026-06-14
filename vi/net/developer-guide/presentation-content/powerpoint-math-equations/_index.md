---
title: Thêm công thức toán học vào bài thuyết trình PowerPoint trong .NET
linktitle: Công thức toán học PowerPoint
type: docs
weight: 80
url: /vi/net/powerpoint-math-equations/
keywords:
- công thức toán học
- ký hiệu toán học
- công thức
- văn bản toán học
- thêm công thức toán học
- thêm ký hiệu toán học
- thêm công thức
- thêm văn bản toán học
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Chèn và chỉnh sửa công thức toán học trong PowerPoint PPT và PPTX bằng Aspose.Slides cho .NET, hỗ trợ OMML, điều khiển định dạng, và các mẫu mã C# rõ ràng."
---
## **Tổng quan**

PowerPoint lưu các công thức dưới dạng Office Math Markup Language (OMML). Với Aspose.Slides cho .NET, bạn có thể tạo cùng loại nội dung toán học một cách lập trình: phân số, căn bậc, hàm số, giới hạn, toán tử N-ary, ma trận, mảng và các khối toán học đã định dạng.

Trong PowerPoint, người dùng thường thêm công thức từ **Insert > Equation**:

![Tab Insert của PowerPoint với lệnh Equation được chọn](powerpoint-math-equations_1.png)

Kết quả là văn bản toán học có thể chỉnh sửa trên slide:

![Một slide PowerPoint chứa một công thức toán học có thể chỉnh sửa](powerpoint-math-equations_2.png)

Aspose.Slides xây dựng văn bản toán học đó thông qua ba đối tượng chính:

- Một hình dạng toán học, được tạo bằng [AddMathShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/addmathshape/), là hình dạng chứa công thức.
- [MathPortion](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/mathportion/) lưu nội dung toán học trong khung văn bản của hình dạng.
- [MathParagraph](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/mathparagraph/) chứa một hoặc nhiều đối tượng [MathBlock](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/mathblock/) .

Hầu hết các ví dụ dưới đây sử dụng [MathematicalText](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/mathematicaltext/) và các phương thức linh hoạt từ [IMathElement](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/imathelement/) để giữ mã ngắn gọn và dễ đọc.

Đối với các trường hợp xuất MathML, xem [Xuất các công thức toán học từ bản trình bày trong .NET](/slides/vi/net/exporting-math-equations/).

## **Tạo công thức**

Ví dụ này tạo một hình dạng toán học và thêm định lý Pythagoras:

![Phương trình c bình phương bằng a bình phương cộng b bình phương](powerpoint-math-equations_3.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equation = new MathematicalText("c")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("a").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("b").SetSuperscript("2"));

mathParagraph.Add(equation);

presentation.Save("pythagorean-theorem.pptx", SaveFormat.Pptx);
```

{{% alert color="primary" %}}
`AddMathShape` tạo một hình dạng đã bao gồm một đoạn toán học. Truy cập `MathPortion` đầu tiên, lấy `MathParagraph` của nó và thêm các khối toán học hoặc các phần tử toán học vào đó.
{{% /alert %}}

## **Thêm phân số**

Sử dụng `Divide` để tạo một phân số. Bạn có thể chọn kiểu phân số bằng [MathFractionTypes](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/mathfractiontypes/).

![Một phân số toán học nghiêng hiển thị 1 chia cho x](powerpoint-math-equations_4.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var fraction = new MathematicalText("1")
    .Divide("x", MathFractionTypes.Skewed);

mathParagraph.Add(new MathBlock(fraction));

presentation.Save("fraction.pptx", SaveFormat.Pptx);
```

Đối với phân số xếp chồng, sử dụng `MathFractionTypes.Bar`:

```csharp
var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **Thêm căn bậc**

Sử dụng `Radical` để tạo căn bậc hai, căn bậc ba hoặc các căn khác. Phần tử hiện tại trở thành cơ số, và đối số trở thành bậc.

![Một biểu thức căn bậc n với x nằm dưới dấu căn](powerpoint-math-equations_5.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var radical = new MathematicalText("x")
    .Radical("n");

mathParagraph.Add(new MathBlock(radical));

presentation.Save("radical.pptx", SaveFormat.Pptx);
```

## **Thêm hàm và giới hạn**

Sử dụng `AsArgumentOfFunction` hoặc `Function` cho các hàm như `sin(x)`, `log(x)` hoặc tên hàm tùy chỉnh. Đối với giới hạn, đặt `lim` trong một [MathLimit](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/mathlimit/) hoặc sử dụng `SetLowerLimit`.

![Giới hạn của x khi x tiến tới vô hạn](powerpoint-math-equations_8.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var limit = new MathematicalText("lim")
    .SetLowerLimit("x→∞")
    .Function("x");

mathParagraph.Add(new MathBlock(limit));

presentation.Save("functions-and-limits.pptx", SaveFormat.Pptx);
```

Đối với tên hàm tùy chỉnh, đặt tên hàm làm phần tử hiện tại:

```csharp
var customFunction = new MathematicalText("f").Function("x + 1");
```

## **Thêm toán tử N-ary và tích phân**

Sử dụng `Nary` cho tổng, hợp, giao và các toán tử lớn khác. Sử dụng `Integral` cho tích phân. Cả hai phương thức đều cho phép đặt giới hạn dưới và trên.

![Một phép cộng với giới hạn dưới và trên](powerpoint-math-equations_7.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var summationBase = new MathematicalText("x")
    .SetSuperscript("k")
    .Join(new MathematicalText("a").SetSuperscript("n-k"));

var summation = summationBase.Nary(MathNaryOperatorTypes.Summation, "k=0", "n");

mathParagraph.Add(new MathBlock(summation));

presentation.Save("nary-operators.pptx", SaveFormat.Pptx);
```

Các toán tử N-ary dùng cho các toán tử lớn có thể có hoặc không có giới hạn. Các toán tử đơn giản như `+`, `-`, và `=` thường được thêm dưới dạng `MathematicalText` và nối vào biểu thức.

Đối với một tích phân, sử dụng `Integral`:

```csharp
var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Thêm ma trận**

Sử dụng [MathMatrix](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/mathmatrix/) cho các hàng và cột. Mặc định, ma trận không bao gồm dấu ngoặc, vì vậy hãy bao quanh ma trận khi bạn cần dấu ngoặc tròn, dấu ngoặc vuông hoặc dấu ngoặc nhọn.

![Một ma trận toán học hai hàng với một ô trống](powerpoint-math-equations_10.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var matrix = new MathMatrix(2, 3);
matrix[0, 0] = new MathematicalText("1");
matrix[0, 1] = new MathematicalText("x");
matrix[1, 0] = new MathematicalText("x");
matrix[1, 1] = new MathematicalText("2");
matrix[1, 2] = new MathematicalText("y");

mathParagraph.Add(new MathBlock(matrix));

presentation.Save("matrix.pptx", SaveFormat.Pptx);
```

## **Thêm mảng công thức**

Sử dụng `ToMathArray` khi bạn cần các công thức căn chỉnh hoặc một cột dọc các biểu thức.

![Một mảng toán học dọc với x ở trên y](powerpoint-math-equations_11.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 140);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equationArray = new MathematicalText("x")
    .Join("y")
    .ToMathArray();

mathParagraph.Add(new MathBlock(equationArray));

presentation.Save("equation-array.pptx", SaveFormat.Pptx);
```

## **Thêm hàm lượng giác**

Sử dụng `AsArgumentOfFunction` khi đối số là phần tử hiện tại và tên hàm đã biết.

![Hàm lượng giác cos áp dụng cho 2x](powerpoint-math-equations_6.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var cosine = new MathematicalText("2x")
    .AsArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

mathParagraph.Add(new MathBlock(cosine));

presentation.Save("trigonometric-function.pptx", SaveFormat.Pptx);
```

## **Thêm chỉ số dưới và chỉ số trên**

Sử dụng các trợ giúp subscript và superscript cho chỉ mục và lũy thừa. Khi chỉ mục cần xuất hiện ở phía bên trái của cơ số, sử dụng `SetSubSuperscriptOnTheLeft`.

![Một chữ Y in hoa với chỉ số dưới 1 ở phía bên trái và chỉ số trên n](powerpoint-math-equations_9.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var scripts = new MathematicalText("Y")
    .SetSubSuperscriptOnTheLeft("1", "n");

mathParagraph.Add(new MathBlock(scripts));

presentation.Save("subscript-superscript.pptx", SaveFormat.Pptx);
```

## **Thêm dấu phân cách**

Sử dụng `Enclose` để đặt một biểu thức bên trong dấu phân cách. Bạn cũng có thể đặt ký tự phân tách cho các biểu thức dấu phân cách chứa nhiều phần tử.

![Một biểu thức dấu phân cách chứa x, y và z được ngăn cách bằng các dấu gạch đứng](powerpoint-math-equations_13.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var delimiter = new MathematicalText("x")
    .Join("y")
    .Join("z")
    .Enclose('<', '>');
delimiter.SeparatorCharacter = '|';

mathParagraph.Add(new MathBlock(delimiter));

presentation.Save("delimiters.pptx", SaveFormat.Pptx);
```

## **Thêm hộp viền**

Sử dụng `ToBorderBox` khi công thức cần được bao khung.

![Một công thức đóng khung hiển thị a bình phương bằng b bình phương cộng c bình phương](powerpoint-math-equations_12.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var boxedEquation = new MathematicalText("a")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("b").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("c").SetSuperscript("2"))
    .ToBorderBox();

mathParagraph.Add(new MathBlock(boxedEquation));

presentation.Save("border-box.pptx", SaveFormat.Pptx);
```

## **Nhóm các thuật ngữ**

Sử dụng `Group` để đặt ký tự nhóm phía trên hoặc dưới một biểu thức. Thêm giới hạn để gắn nhãn cho các thuật ngữ đã nhóm.

![Biểu thức x cộng y được nhóm với nhãn bất kỳ văn bản nào phía dưới](powerpoint-math-equations_15.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var grouped = new MathematicalText("x + y")
    .Group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
    .SetLowerLimit("any text");

mathParagraph.Add(new MathBlock(grouped));

presentation.Save("grouped-terms.pptx", SaveFormat.Pptx);
```

## **Định dạng các phần tử toán học**

Chỉ sử dụng các trợ giúp định dạng khi chúng làm rõ công thức. Ví dụ, `Overbar` đặt một thanh ngang phía trên một phần tử toán học.

![Một biểu thức toán học ABC có thanh ngang phía trên](powerpoint-math-equations_14.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var overbar = new MathematicalText("ABC").Overbar();

mathParagraph.Add(new MathBlock(overbar));

presentation.Save("overbar.pptx", SaveFormat.Pptx);
```

## **Tham chiếu nhanh**

| Nhiệm vụ | API chính |
| --- | --- |
| Tạo văn bản toán học | [MathematicalText](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/mathematicaltext/) |
| Kết hợp các phần tử | [IMathElement.Join](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/imathelement/join/) |
| Tạo phân số | [IMathElement.Divide](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/imathelement/divide/) |
| Thêm chỉ số trên hoặc chỉ số dưới | [SetSuperscript](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| Thêm hàm | [Function](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Thêm căn bậc | [IMathElement.Radical](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/imathelement/radical/) |
| Thêm giới hạn | [SetLowerLimit](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Thêm chỉ số bên trái | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Thêm tổng và tích phân | [Nary](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/imathelement/integral/) |
| Thêm ma trận | [MathMatrix](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/mathmatrix/) |
| Thêm mảng công thức | [ToMathArray](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| Thêm dấu phân cách | [Enclose](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/imathelement/enclose/) |
| Thêm thanh và viền | [Overbar](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| Nhóm các thuật ngữ | [Group](https://reference.aspose.com/slides/vi/net/aspose.slides.mathtext/imathelement/group/) |

## **Câu hỏi thường gặp**

**Tôi có thể chỉnh sửa một công thức PowerPoint hiện có không?**

Có. Mở bản trình bày, tìm hình dạng chứa `MathPortion`, lấy `MathParagraph` của nó và cập nhật các khối toán học trong đoạn đó.

**Các công thức có được lưu dưới dạng toán học PowerPoint có thể chỉnh sửa không?**

Có. Khi lưu thành PPTX, Aspose.Slides ghi công thức dưới dạng nội dung Office math có thể chỉnh sửa.

**Tôi có thể xuất công thức sang LaTeX không?**

Aspose.Slides xuất các công thức toán học sang MathML. Nếu bạn cần LaTeX, hãy xuất sang MathML trước rồi chuyển đổi MathML bằng công cụ hỗ trợ định dạng LaTeX mục tiêu của bạn.