---
title: Thêm Phương Trình Toán Học vào Bản Trình Bày PowerPoint trong .NET
linktitle: Phương Trình Toán Học PowerPoint
type: docs
weight: 80
url: /vi/net/powerpoint-math-equations/
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
- .NET
- C#
- Aspose.Slides
description: "Chèn và chỉnh sửa các phương trình toán học trong PowerPoint PPT và PPTX bằng Aspose.Slides cho .NET, hỗ trợ OMML, điều khiển định dạng, và các mẫu mã C# rõ ràng."
---
## **Tổng quan**

PowerPoint lưu trữ các phương trình dưới dạng Office Math Markup Language (OMML). Với Aspose.Slides cho .NET, bạn có thể tạo cùng kiểu nội dung toán học một cách lập trình: các phân số, căn bậc, hàm, giới hạn, toán tử N-ary, ma trận, mảng và các khối toán học đã định dạng.

Trong PowerPoint, người dùng thường thêm các phương trình từ **Insert > Equation**:

![Tab Chèn của PowerPoint với lệnh Phương trình đã được chọn](powerpoint-math-equations_1.png)

Kết quả là văn bản toán học có thể chỉnh sửa trên slide:

![Một slide PowerPoint chứa một phương trình toán học có thể chỉnh sửa](powerpoint-math-equations_2.png)

Aspose.Slides xây dựng văn bản toán học đó thông qua ba đối tượng chính:

- Một hình toán, được tạo bằng [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/), là hình chứa phương trình.
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) lưu trữ nội dung toán học bên trong khung văn bản của hình.
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) chứa một hoặc nhiều đối tượng [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/).

Hầu hết các ví dụ dưới đây sử dụng [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) và các phương thức thông suốt từ [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) để giữ mã ngắn gọn và dễ đọc.

Đối với các kịch bản xuất MathML, xem [Export Math Equations from Presentations in .NET](/slides/vi/net/exporting-math-equations/).

## **Tạo phương trình**

Ví dụ này sử dụng [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) để tạo một hình toán và thêm định lý Pythagoras:

![Phương trình c bình phương bằng a bình phương cộng b bình phương](powerpoint-math-equations_3.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

{{% alert color="info" title="Note" %}}
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) tạo ra một hình đã chứa sẵn một đoạn toán. Truy cập [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) đầu tiên, lấy [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) của nó, và thêm các khối hoặc phần tử toán vào đó.
{{% /alert %}}

## **Thêm phân số**

Sử dụng [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) để tạo một phân số. Bạn có thể chọn kiểu phân số bằng [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/).

![Một phân số nghiêng hiển thị một chia cho x](powerpoint-math-equations_4.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var fraction = new MathematicalText("1")
    .Divide("x", MathFractionTypes.Skewed);

mathParagraph.Add(new MathBlock(fraction));

presentation.Save("fraction.pptx", SaveFormat.Pptx);
```

Đối với phân số dạng chồng, sử dụng [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/):

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **Thêm căn bậc**

Sử dụng [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) để tạo căn bậc hai, bậc ba hoặc các căn bậc khác. Phần tử hiện tại trở thành cơ số, và đối số trở thành cấp số.

![Biểu thức căn bậc n với x ở dưới dấu căn](powerpoint-math-equations_5.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var radical = new MathematicalText("x")
    .Radical("n");

mathParagraph.Add(new MathBlock(radical));

presentation.Save("radical.pptx", SaveFormat.Pptx);
```

### **Hiển thị hoặc ẩn cấp của căn bậc hai**

Căn bậc hai có thể hiển thị số 2 rõ ràng hoặc sử dụng ký hiệu truyền thống √x. Thuộc tính [HideDegree](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/hidedegree/) của [IMathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/) kiểm soát dạng hiển thị. Cả hai dạng đều giữ cấp 2 và căn bậc x trong phương trình có thể chỉnh sửa.

![Cùng một căn bậc hai với HideDegree = false ở bên trái và true ở bên phải](square-root-degree.png)

Ví dụ lưu cùng một căn bậc hai hai lần. Trong `visible-degree.pptx` số 2 hiển thị. Trong `hidden-degree.pptx` nó bị ẩn.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var radical = new MathematicalText("x").Radical("2");

var shape = slide.Shapes.AddMathShape(20, 20, 200, 100);
var portion = (IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
portion.MathParagraph.Add(new MathBlock(radical));

radical.HideDegree = false;
presentation.Save("visible-degree.pptx", SaveFormat.Pptx);

radical.HideDegree = true;
presentation.Save("hidden-degree.pptx", SaveFormat.Pptx);
```

## **Thêm hàm và giới hạn**

Sử dụng [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) hoặc [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) cho các hàm như `sin(x)`, `log(x)`, hoặc tên hàm tùy chỉnh. Đối với giới hạn, đặt `lim` trong một [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) hoặc sử dụng [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/).

![Giới hạn của x khi x tiến tới vô cùng](powerpoint-math-equations_8.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

Đối với tên hàm tùy chỉnh, đặt tên hàm làm phần tử hiện tại và gọi [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) với đối số của nó:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **Thêm toán tử N-ary và tích phân**

Sử dụng [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) cho các phép cộng, hợp, giao và các toán tử lớn khác. Sử dụng [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) cho tích phân. Cả hai phương pháp đều cho phép đặt giới hạn dưới và trên.

![Một phép cộng với giới hạn dưới và trên](powerpoint-math-equations_7.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

Toán tử N-ary dùng cho các toán tử lớn có tùy chọn giới hạn. Các toán tử đơn như `+`, `-`, và `=` thường được thêm bằng [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) và nối vào biểu thức.

Đối với một tích phân, sử dụng [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/):

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Thêm ma trận**

Sử dụng [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) cho các hàng và cột. Mặc định ma trận không có dấu ngoặc, vì vậy hãy bao quanh ma trận khi cần dấu ngoặc tròn, vuông hoặc nhọn.

![Một ma trận toán có hai hàng, một ô trống](powerpoint-math-equations_10.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

### **Chỉnh sửa một ma trận hiện có**

Giả sử một bài học đại số tuyến tính bắt đầu với ma trận hệ số trong `matrix.pptx`, được lưu bởi ví dụ trước. Đối với bài tập tiếp theo, giữ phương trình đầu tiên, thay thế phương trình thứ hai bằng hai phương trình mới, và sửa đổi tập biến. Mở ma trận hiện có qua [IMathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/) để giữ lại các hệ số vẫn áp dụng.

![Ma trận hệ số hai hàng gốc với các mục 1, x và một ô trống ở hàng đầu, và x, 2, y ở hàng thứ hai](matrix-before-edit.png)

Chỉ số hàng và cột bắt đầu từ 0 và tham chiếu tới ma trận tại thời điểm mỗi lần gọi. Chèn một hàng trước chỉ số 1 sẽ đưa hàng thứ hai gốc xuống chỉ số 2. Chèn sau chỉ số 2 sẽ thêm một hàng vào cuối. Xóa hàng 2 sẽ loại bỏ phương trình thứ hai gốc và dời hàng mới lên một vị trí. Các cột di chuyển tương tự.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation("matrix.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var portion = (IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
var matrix = (IMathMatrix)portion.MathParagraph[0][0];

matrix.InsertRowBefore(1);
matrix.InsertRowAfter(2);
matrix.DeleteRow(2);

matrix.InsertColumnBefore(1);
matrix.InsertColumnAfter(3);
matrix.DeleteColumn(3);

// Các ô mới ban đầu là null. Đặt các hệ số khác không trước tiên.
matrix[1, 0] = new MathematicalText("12");
matrix[1, 1] = new MathematicalText("1");
matrix[2, 2] = new MathematicalText("10");
matrix[2, 3] = new MathematicalText("1");
for (var row = 0; row < matrix.RowCount; row++)
{
    for (var column = 0; column < matrix.ColumnCount; column++)
    {
        matrix[row, column] ??= new MathematicalText("0");
    }
}

matrix.SetColumnAlignment(0, MathHorizontalAlignment.Left);
matrix.SetColumnsAlignment(1, 3, MathHorizontalAlignment.Right);

presentation.Save("updated-matrix.pptx", SaveFormat.Pptx);
```

[SetColumnAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnalignment/) căn lề trái cho cột đầu tiên. [SetColumnsAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnsalignment/) căn lề phải cho ba cột liên tiếp, bắt đầu từ chỉ số 1. Trong `updated-matrix.pptx`, ma trận có ba phương trình và bốn biến. Các hệ số hàng đầu tiên `1` và `x` giờ xuất hiện ở cột thứ nhất và thứ ba.

![Ma trận ba hàng đã cập nhật, hiển thị các hàng 1,0,x,0; 12,1,0,0; và 0,0,10,1](matrix-after-edit.png)

## **Thêm mảng phương trình**

Sử dụng [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) khi cần các phương trình căn chỉnh hoặc một ngăn xếp dọc các biểu thức.

![Một mảng toán dọc với x ở trên y](powerpoint-math-equations_11.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

### **Căn chỉnh mảng với các phần tử xung quanh**

[IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) kiểm soát căn dọc của mảng so với các phần tử toán học bên cạnh. Ví dụ dưới so sánh căn chỉnh với hàng đầu tiên, trung tâm mảng và hàng cuối cùng.

Ví dụ sau tạo ba mảng giống hệt, mỗi mảng có ba hàng và các phần tử lân cận `A=` và `=B`. Toàn bộ văn bản toán học đều dùng Cambria Math 24pt. Chỉ có căn chỉnh mảng thay đổi.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(780, 200, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var alignments = new[] { MathVerticalAlignment.Top, MathVerticalAlignment.Center, MathVerticalAlignment.Bottom };

for (int i = 0; i < alignments.Length; i++)
{
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20 + i * 260, 10, 240, 30);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;
    label.TextFrame.Text = alignments[i].ToString();
    var labelFormat = label.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    labelFormat.FontHeight = 16;
    labelFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var mathShape = slide.Shapes.AddMathShape(20 + i * 260, 60, 240, 130);
    mathShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    var mathParagraph = ((IMathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    mathParagraph.Justification = MathJustification.LeftJustified;

    var rows = new IMathElement[] { CreateText("x+y=3"), CreateText("x-y=1"), CreateText("x=2") };
    var equationArray = new MathArray(rows);
    equationArray.BaseJustification = alignments[i];
    var equation = new MathBlock(CreateText("A=")).Join(equationArray).Join(CreateText("=B"));
    mathParagraph.Add(equation);
}

presentation.Save("equation-array-alignment.pptx", SaveFormat.Pptx);

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

So sánh dưới đây cho thấy bản trình chiếu đã lưu trong PowerPoint. Lưu ý vị trí của `A=` và `=B` bên cạnh mỗi mảng.

![Mảng phương trình trong PowerPoint với căn trên, giữa và dưới cùng các phần tử lân cận giống nhau](equation-array-alignment.png)

### **Cấu hình khoảng cách hàng**

[RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) chọn quy tắc khoảng cách cho các hàng trong mảng. [RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) cung cấp giá trị số cho quy tắc cụ thể và bị bỏ qua khi dùng các quy tắc mặc định.

Đối với khoảng cách chính xác, giá trị đo bằng điểm. Đối với khoảng cách tỷ lệ, đo bằng nửa dòng: giá trị `3` trong ví dụ tương đương 1,5 dòng. Khi chỉ định giá trị cụ thể, hãy đặt cả hai thuộc tính; thay đổi chỉ số mà không thay đổi quy tắc sẽ không có hiệu lực.

Ví dụ dưới lưu năm bản trình chiếu với cùng các phương trình, căn chỉnh và cài đặt phông chữ. Ba cái đầu dùng cài đặt mặc định; hai cái cuối dùng giá trị cụ thể.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

var settings = new (MathRowSpacingRule Rule, uint Spacing)[]
{
    (MathRowSpacingRule.SingleLineGap, 0),
    (MathRowSpacingRule.OneAndAHalfLineGap, 0),
    (MathRowSpacingRule.TwoLineGap, 0),
    (MathRowSpacingRule.Exactly, 20),
    (MathRowSpacingRule.Multiple, 3)
};

foreach (var setting in settings)
{
    var fileName = $"equation-array-{setting.Rule}.pptx";
    using (var presentation = new Presentation())
    {
        var mathShape = presentation.Slides[0].Shapes.AddMathShape(20, 20, 600, 300);
        var paragraph = mathShape.TextFrame.Paragraphs[0];
        paragraph.ParagraphFormat.SpaceBefore = 0;
        paragraph.ParagraphFormat.SpaceAfter = 0;
        var mathParagraph = ((IMathPortion)paragraph.Portions[0]).MathParagraph;
        mathParagraph.Justification = MathJustification.LeftJustified;

        var rows = new IMathElement[] { CreateText("x+y=3"), CreateText("x-y=1"), CreateText("x=2") };
        var equationArray = new MathArray(rows);
        equationArray.BaseJustification = MathVerticalAlignment.Center;
        equationArray.RowSpacingRule = setting.Rule;
        equationArray.RowSpacing = setting.Spacing;
        var equation = new MathBlock(CreateText("A=")).Join(equationArray).Join(CreateText("=B"));
        mathParagraph.Add(equation);

        presentation.Save(fileName, SaveFormat.Pptx);
    }

}

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

Khoảng cách hàng trong mảng riêng biệt với khoảng cách đoạn. [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) và [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) thêm không gian quanh đoạn chứa, không phải giữa các hàng mảng. Tương tự, [IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) định vị toàn bộ đoạn toán học theo chiều ngang; nó không thay thế cài đặt căn dọc của mảng.

## **Thêm hàm lượng giác**

Sử dụng [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) khi đối số là phần tử hiện tại và tên hàm đã biết.

![Hàm lượng giác cos áp dụng cho 2x](powerpoint-math-equations_6.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var cosine = new MathematicalText("2x")
    .AsArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

mathParagraph.Add(new MathBlock(cosine));

presentation.Save("trigonometric-function.pptx", SaveFormat.Pptx);
```

## **Thêm chỉ số và lũy thừa**

Sử dụng các trợ giúp chỉ số và lũy thừa cho các chỉ số và mũ. Khi chỉ số phải xuất hiện ở phía trái của cơ sở, dùng [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/).

![Chữ Y hoa với chỉ số trái 1 và lũy thừa phải n](powerpoint-math-equations_9.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var scripts = new MathematicalText("Y")
    .SetSubSuperscriptOnTheLeft("1", "n");

mathParagraph.Add(new MathBlock(scripts));

presentation.Save("subscript-superscript.pptx", SaveFormat.Pptx);
```

## **Thêm dấu ngoặc**

Sử dụng [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) để đặt một biểu thức bên trong dấu ngoặc. Bạn cũng có thể đặt ký tự phân tách cho các biểu thức dấu ngoặc chứa nhiều phần tử.

![Biểu thức dấu ngoặc chứa x, y và z tách nhau bằng các dấu gạch đứng](powerpoint-math-equations_13.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

### **Kích thước và căn chỉnh dấu ngoặc**

Đặt [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) thành `true` để cho ngoặc mở rộng quanh toán tử cao, hoặc `false` để giữ kích thước bình thường. [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) nhận một trong hai giá trị [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/). `Centered` canh giữa ngoặc trên trục toán học, trục chạy qua trung tâm dấu bằng. `Match` căn theo nội dung bao quanh. Cả hai chỉ ảnh hưởng đến dấu ngoặc; biểu thức bên trong không thay đổi.

Ví dụ đặt một phân số ở mũ của `x` để biểu thức mở rộng lên trên đường cơ sở hơn so với phía dưới. Bốn phương trình đều dùng cùng một dấu ngoặc và cài đặt phông chữ.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

void AddExpression(float left, float top, bool grow, MathDelimiterShape shape)
{
    var fraction = new MathematicalText("a + b").Divide("c + d");
    var power = new MathematicalText("x").SetSuperscript(fraction);
    var delimiter = power.Enclose('(', ')');
    delimiter.GrowToMatchOperandHeight = grow;
    delimiter.DelimiterShape = shape;

    var mathShape = slide.Shapes.AddMathShape(left, top, 300, 100);
    var portion = (MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FontHeight = 32;
    var equation = new MathematicalText("y = ").Join(delimiter);
    portion.MathParagraph.Add(equation);
}

AddExpression(20, 20, true, MathDelimiterShape.Centered);
AddExpression(350, 20, true, MathDelimiterShape.Match);
AddExpression(20, 140, false, MathDelimiterShape.Centered);
AddExpression(350, 140, false, MathDelimiterShape.Match);

presentation.Save("delimiter-sizing.pptx", SaveFormat.Pptx);
```

Trong PowerPoint, so sánh các hàng để thấy hiệu ứng mở rộng. Ở hàng trên, ngoặc mở rộng để bao quanh mũ và trông giống nhau cho cả hai dạng. Ở hàng dưới, tính năng mở rộng tắt. Các ngoặc nhỏ hơn bên trái (`Centered`) căn với dấu bằng, trong khi các ngoặc bên phải (`Match`) ở vị trí cao hơn quanh biểu thức.

![Bốn phương trình trong PowerPoint với dấu ngoặc mở rộng bật trên và tắt dưới, và `Centered` bên trái, `Match` bên phải](delimiter-sizing.png)

## **Thêm hộp viền**

Gọi [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) trên một phân số để đóng khung toàn bộ biểu thức. [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) trả về mặc định hiển thị cả bốn cạnh. Dùng [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/), [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/), [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/), và [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) để loại bỏ các cạnh riêng lẻ.

Ví dụ đặt sáu bản sao của cùng một phân số trên một slide. Để hiển thị gạch bỏ, ẩn cả bốn cạnh và đặt [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) cho đường chéo lên (`↗`) hoặc [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) cho đường chéo xuống (`↘`). Bạn cũng có thể dùng [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) hoặc [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) kết hợp với bất kỳ các cạnh hiển thị nào.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(540, 220, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

IMathBorderBox AddFraction(float x, float y, bool hideBorder = false)
{
    var fraction = new MathematicalText("x+1").Divide("y+2");
    var box = fraction.ToBorderBox();
    box.HideTop = box.HideBottom = box.HideLeft = box.HideRight = hideBorder;

    var shape = slide.Shapes.AddMathShape(x, y, 160, 90);
    var portion = (MathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FontHeight = 28;
    portion.MathParagraph.Add(new MathBlock(box));
    return box;
}

AddFraction(10, 10);

var partial = AddFraction(190, 10);
partial.HideTop = true;
partial.HideRight = true;

AddFraction(370, 10, hideBorder: true).StrikethroughBottomLeftToTopRight = true;
AddFraction(10, 120, hideBorder: true).StrikethroughTopLeftToBottomRight = true;
AddFraction(190, 120, hideBorder: true).StrikethroughHorizontal = true;
AddFraction(370, 120).StrikethroughVertical = true;

presentation.Save("border-box.pptx", SaveFormat.Pptx);
```

![Sáu phân số có thể chỉnh sửa trong PowerPoint. Dòng trên: viền đầy đủ, các cạnh dưới và trái, đường chéo lên. Dòng dưới: đường chéo xuống, gạch ngang, gạch dọc với viền đầy đủ.](border-box-fractions.png)

Trên phân số này, gạch ngang chồng lên thanh phân số. Gạch dọc cắt cả tử và mẫu trong khi viền xung quanh vẫn hiển thị. Các đường này trang trí toàn bộ biểu thức. Gạch bỏ thông thường áp dụng cho các ký tự trong một đoạn văn bản. Sau khi mở lại bản trình chiếu trong PowerPoint, bạn vẫn có thể chỉnh sửa tử và mẫu một cách độc lập.

## **Kiểm soát hiển thị và bố cục bằng phần tử ảo**

Bao bọc một biểu thức trong [MathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathphantom/) để kiểm soát khả năng hiển thị và không gian nó chiếm trong một phương trình một cách độc lập. Thuộc tính của [IMathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/) điều khiển các yếu tố sau:

| Property | Effect |
| --- | --- |
| [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) | Đặt `false` để ẩn biểu thức. Kích thước của nó vẫn đóng góp vào bố cục trừ khi các thuộc tính dưới đây được đặt `true`. |
| [ZeroWidth](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerowidth/) | Xem chiều rộng ngang của biểu thức như bằng 0, cho phép các phần tử lân cận di chuyển gần nhau hơn. |
| [ZeroAsc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zeroasc/) | Xem độ lên (chiều cao phía trên đường cơ sở) như bằng 0. Điều này có thể giảm không gian dành cho phần trên các phần tử lân cận. |
| [ZeroDesc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerodesc/) | Xem độ xuống (chiều sâu phía dưới đường cơ sở) như bằng 0. Điều này có thể đưa thanh phân số hoặc nội dung khác dưới biểu thức gần hơn đến các phần tử lân cận. |

Đường cơ sở là đường tham chiếu mà các ký tự toán học thường ngồi trên. Ẩn nội dung không loại bỏ kích thước của nó, và xem một kích thước là 0 không xóa biểu thức. Biểu thức gốc vẫn tồn tại thông qua [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/base/). Đặt [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) lại `true` để hiển thị lại; các cài đặt kích thước vẫn giữ nguyên.

Ví dụ dưới tạo năm biến thể đứng cạnh nhau: một phân số hiển thị, một phân số ẩn nhưng giữ không gian, và ba phân số ẩn với một trong các kích thước được xử lý là 0. Mỗi biến thể dùng cùng một biểu thức bao quanh và Cambria Math 24pt. Tất cả các hình phương trình có cùng vị trí trên cùng, được đánh dấu bằng hướng dẫn màu xám. Đặt phantom trong tử của một phân số bên ngoài giúp dễ dàng quan sát thay đổi bố cục dọc.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(1000, 180, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var labels = new[] { "Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc" };

var guide = slide.Shapes.AddAutoShape(ShapeType.Line, 10, 60, 980, 0);
guide.LineFormat.FillFormat.FillType = FillType.Solid;
guide.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightGray;

for (var i = 0; i < labels.Length; i++)
{
    var left = 10 + i * 200;
    
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, left, 10, 190, 30);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;
    label.TextFrame.Text = labels[i];

    var labelFormat = label.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    labelFormat.FontHeight = 14;
    labelFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var fraction = new MathFraction(CreateText("a+b"), CreateText("c+d"));
    var phantom = new MathPhantom(fraction);
    phantom.Show = i == 0;
    phantom.ZeroWidth = i == 2;
    phantom.ZeroAsc = i == 3;
    phantom.ZeroDesc = i == 4;

    var numerator = new MathBlock(CreateText("x+")).Join(phantom).Join(CreateText("+y"));
    var equation = new MathFraction(numerator, CreateText("z"));

    var shape = slide.Shapes.AddMathShape(left, 60, 190, 100);
    shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;

    var mathParagraph = ((IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    mathParagraph.Add(new MathBlock(equation));
}

presentation.Save("math-phantom.pptx", SaveFormat.Pptx);

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

![Năm phương trình trong PowerPoint so sánh một phân số hiển thị, một phân số ẩn giữ không gian, và các phân số ẩn với ZeroWidth, ZeroAsc hoặc ZeroDesc bật](math-phantom.png)

## **Nhóm các phần tử**

Sử dụng [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) để đặt một ký tự nhóm phía trên hoặc dưới một biểu thức. Thêm một giới hạn để ghi nhãn các phần tử được nhóm.

![Biểu thức x cộng y được nhóm với nhãn bất kỳ bên dưới](powerpoint-math-equations_15.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

Chỉ sử dụng các trợ giúp định dạng khi chúng làm rõ công thức. Ví dụ, [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) đặt một thanh trên một phần tử toán học.

![Biểu thức toán học ABC có một thanh trên](powerpoint-math-equations_14.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var overbar = new MathematicalText("ABC").Overbar();

mathParagraph.Add(new MathBlock(overbar));

presentation.Save("overbar.pptx", SaveFormat.Pptx);
```

### **Định dạng văn bản trong một phương trình hiện có**

Để định dạng văn bản trong toàn bộ một phương trình hiện có, duyệt cây phần tử của mỗi khối toán. [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) chỉ trả về các con trực tiếp, vì vậy hãy gọi đệ quy để tới văn bản trong phân số, chỉ số, căn bậc và các cấu trúc lồng nhau khác. Kiểm tra phần tử hiện tại cũng như các con của nó để bao gồm phần tử bắt đầu khi nó là [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/).

Ví dụ này giả định một bản trình chiếu có một phương trình như `z = xᵢ / ∛y`, với một phân số chứa chỉ số trong tử và một căn bậc trong mẫu. Xử lý chỉ các phần tử cấp cao của khối sẽ bỏ sót văn bản trong phân số. Ví dụ tìm các phần toán trong khung văn bản slide, truy cập các khối qua [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/), và đặt [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) thành 28pt cho mỗi phần tử văn bản thông qua thuộc tính [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape || autoShape.TextFrame == null)
            continue;

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is IMathPortion mathPortion)
                {
                    foreach (var block in mathPortion.MathParagraph)
                        FormatMathText(block);
                }
            }
        }
    }
}

presentation.Save("formatted-equations.pptx", SaveFormat.Pptx);

void FormatMathText(IMathElement element)
{
    if (element is MathematicalText text)
        text.Format.FontHeight = 28;

    foreach (var child in element.GetChildren())
        FormatMathText(child);
}
```

Bản trình chiếu đã lưu chứa định dạng văn bản được cập nhật ở mọi cấp của mỗi phương trình đã xử lý, đồng thời giữ nguyên nội dung văn bản và cấu trúc toán học.

## **Tham khảo nhanh**

| Task | Main API |
| --- | --- |
| Tạo văn bản toán | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| Kết hợp các phần tử | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| Tạo phân số | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| Thêm lũy thừa hoặc chỉ số | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| Thêm hàm | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Thêm căn bậc | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| Thêm giới hạn | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Thêm chỉ số bên trái | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Thêm tổng và tích phân | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| Thêm ma trận | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| Thêm mảng phương trình | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| Thêm dấu ngoặc | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| Thêm thanh và viền | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| Nhóm các phần tử | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Có thể chỉnh sửa một phương trình PowerPoint hiện có không?**

Có. Mở bản trình chiếu, tìm hình chứa một [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), lấy [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) của nó, và cập nhật các khối toán trong đoạn đó.

**Các phương trình có được lưu dưới dạng toán học PowerPoint có thể chỉnh sửa không?**

Có. Khi lưu dưới dạng PPTX, Aspose.Slides ghi phương trình dưới dạng nội dung Office math có thể chỉnh sửa.

**Có thể xuất phương trình sang LaTeX không?**

Có. Lấy [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) của [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), và gọi [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) để xuất trực tiếp. Đối với ví dụ đầy đủ, xem [Export Math Equations from Presentations in .NET](/slides/vi/net/exporting-math-equations/#export-math-equations-to-latex).