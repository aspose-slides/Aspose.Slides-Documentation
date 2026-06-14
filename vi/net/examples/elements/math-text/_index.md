---
title: Văn Bản Toán Học
type: docs
weight: 160
url: /vi/net/examples/elements/math-text/
keywords:
- văn bản toán học
- thêm văn bản toán học
- truy cập văn bản toán học
- xóa văn bản toán học
- định dạng văn bản toán học
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Khám phá các ví dụ MathematicalText của Aspose.Slides cho .NET: tạo và định dạng phương trình, phân số, ma trận và ký hiệu bằng C# trong các bản trình chiếu PPT, PPTX và ODP."
---
Bài viết này giới thiệu cách làm việc với các hình dạng văn bản toán học và định dạng phương trình bằng **Aspose.Slides for .NET**.

## **Thêm Văn Bản Toán Học**

Tạo một hình dạng toán học chứa một phân số và công thức Pythagoras.

```csharp
static void AddMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Thêm một hình dạng Toán học vào slide.
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // Truy cập đoạn văn Toán học.
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

    // Thêm một phân số đơn giản: x / y
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    // Thêm phương trình: c² = a² + b²
    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);
}
```

## **Truy Cập Văn Bản Toán Học**

Xác định một hình dạng chứa đoạn văn toán học trên slide.

```csharp
static void AccessMathText()
{
    using var presentation = new Presentation("sample.pptx");
    var slide = presentation.Slides[0];

    // Tìm hình dạng đầu tiên chứa đoạn văn toán học.
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Ví dụ: tạo một phân số (không được thêm ở đây).
        var fraction = new MathematicalText("x").Divide("y");

        // Sử dụng mathParagraph hoặc fraction khi cần.
    }
}
```

## **Xóa Văn Bản Toán Học**

Xóa một hình dạng toán học khỏi slide.

```csharp
static void RemoveMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var mathShape = slide.Shapes.AddMathShape(50, 50, 100, 50);
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    slide.Shapes.Remove(mathShape);
}
```

## **Định Dạng Văn Bản Toán Học**

Đặt các thuộc tính phông chữ cho một phần toán học.

```csharp
static void FormatMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var mathShape = slide.Shapes.AddMathShape(50, 50, 100, 50);
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    mathShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 20;
}
```