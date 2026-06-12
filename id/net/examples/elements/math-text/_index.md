---
title: Teks Matematika
type: docs
weight: 160
url: /id/net/examples/elements/math-text/
keywords:
- teks matematika
- tambah teks matematika
- akses teks matematika
- hapus teks matematika
- format teks matematika
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Jelajahi contoh MathematicalText Aspose.Slides untuk .NET: buat dan format persamaan, pecahan, matriks, serta simbol dengan C# dalam presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara bekerja dengan bentuk teks matematika dan memformat persamaan menggunakan **Aspose.Slides for .NET**.

## **Tambah Teks Matematika**

Buat bentuk matematika yang berisi sebuah pecahan dan rumus Pythagoras.

```csharp
static void AddMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Tambahkan bentuk Math ke slide.
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // Akses paragraf matematika.
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

    // Tambahkan pecahan sederhana: x / y
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    // Tambahkan persamaan: c² = a² + b²
    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);
}
```

## **Akses Teks Matematika**

Temukan bentuk yang berisi paragraf matematika pada slide.

```csharp
static void AccessMathText()
{
    using var presentation = new Presentation("sample.pptx");
    var slide = presentation.Slides[0];

    // Temukan shape pertama yang berisi paragraf matematika.
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Contoh: buat sebuah pecahan (tidak ditambahkan di sini).
        var fraction = new MathematicalText("x").Divide("y");

        // Gunakan mathParagraph atau fraction sesuai kebutuhan...
    }
}
```

## **Hapus Teks Matematika**

Hapus bentuk matematika dari slide.

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

## **Format Teks Matematika**

Atur properti font untuk bagian matematika.

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