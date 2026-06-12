---
title: Ekspor Persamaan Matematika dari Presentasi di .NET
linktitle: Ekspor Persamaan
type: docs
weight: 30
url: /id/net/exporting-math-equations/
keywords:
- ekspor persamaan matematika
- MathML
- LaTeX
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Buka ekspor mulus persamaan matematika dari PowerPoint ke MathML menggunakan Aspose.Slides untuk .NET—pertahankan pemformatan dan tingkatkan kompatibilitas."
---
## **Introduction**

Aspose.Slides untuk .NET memungkinkan Anda mengekspor persamaan matematika dari presentasi. Misalnya, Anda mungkin perlu mengekstrak persamaan matematika pada slide (dari presentasi tertentu) dan menggunakannya di program atau platform lain. 

{{% alert color="primary" %}} 

Anda dapat mengekspor persamaan ke MathML, format atau standar populer untuk persamaan matematika dan konten serupa yang terlihat di web dan banyak aplikasi. 

{{% /alert %}}

## **Save Math Equations as MathML**

Meskipun manusia dengan mudah menulis kode untuk beberapa format persamaan seperti LaTeX, mereka kesulitan menulis kode untuk MathML karena format tersebut dimaksudkan untuk dihasilkan secara otomatis oleh aplikasi. Program dapat membaca dan mengurai MathML dengan mudah karena kodenya dalam XML, sehingga MathML umum digunakan sebagai format keluaran dan pencetakan di banyak bidang. 

Kode contoh ini menunjukkan cara mengekspor persamaan matematika dari presentasi ke MathML:

```c#
using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```

## **FAQ**

**What exactly is exported to MathML—a paragraph or an individual formula block?**

Anda dapat mengekspor baik seluruh paragraf matematika ([MathParagraph](https://reference.aspose.com/slides/id/net/aspose.slides.mathtext/mathparagraph/)) atau blok individu ([MathBlock](https://reference.aspose.com/slides/id/net/aspose.slides.mathtext/mathblock/)) ke MathML. Kedua tipe menyediakan metode untuk menulis ke MathML.

**How can I tell that an object on a slide is a math formula rather than regular text or an image?**

Sebuah formula berada dalam [MathPortion](https://reference.aspose.com/slides/id/net/aspose.slides.mathtext/mathportion/) dan memiliki [MathParagraph](https://reference.aspose.com/slides/id/net/aspose.slides.mathtext/mathparagraph/). Gambar dan bagian teks biasa yang tidak memiliki [MathParagraph](https://reference.aspose.com/slides/id/net/aspose.slides.mathtext/mathparagraph/) tidak dapat diekspor sebagai formula.

**Where does the MathML come from in a presentation—is it PowerPoint-specific or a standard?**

Ekspor menargetkan MathML standar (XML). Aspose menggunakan Presentation MathML—subset presentasi dari standar—yang banyak digunakan di seluruh aplikasi dan web.

**Is exporting formulas inside tables, SmartArt, groups, etc., supported?**

Ya, jika objek tersebut berisi bagian teks dengan [MathParagraph](https://reference.aspose.com/slides/id/net/aspose.slides.mathtext/mathparagraph/) (yaitu formula PowerPoint yang asli), maka akan diekspor. Jika formula tersebut disisipkan sebagai gambar, tidak akan diekspor.

**Does exporting to MathML modify the original presentation?**

Tidak. Menulis MathML merupakan serialisasi konten formula; tidak mengubah file presentasi.