---
title: Ekspor Persamaan Matematika dari Presentasi di .NET
linktitle: Ekspor Persamaan
type: docs
weight: 30
url: /id/net/exporting-math-equations/
keywords:
- ekspor persamaan matematika
- ekspor persamaan ke LaTeX
- PowerPoint ke LaTeX
- MathML
- LaTeX
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Ekspor persamaan matematika dari presentasi PowerPoint ke LaTeX atau MathML secara langsung dengan Aspose.Slides untuk .NET."
---
## **Introduction**

Aspose.Slides for .NET memungkinkan Anda mengekspor persamaan matematika dari presentasi. Misalnya, Anda mungkin perlu mengekstrak persamaan matematika pada slide (dari presentasi tertentu) dan menggunakannya di program atau platform lain. 

{{% alert color="primary" %}} 
Anda dapat mengekspor persamaan secara langsung ke LaTeX atau ke MathML, standar populer untuk konten matematika yang digunakan di web dan banyak aplikasi.
{{% /alert %}}

## **Export Math Equations to LaTeX**

Aspose.Slides dapat mengonversi persamaan matematika PowerPoint secara langsung ke LaTeX; file MathML antara dan konverter eksternal tidak diperlukan. Persamaan matematika disimpan dalam bingkai teks sebagai [MathPortion](https://reference.aspose.com/slides/id/net/aspose.slides.mathtext/mathportion/). Gunakan [MathPortion.MathParagraph](https://reference.aspose.com/slides/id/net/aspose.slides.mathtext/mathportion/mathparagraph/) untuk mendapatkan [IMathParagraph](https://reference.aspose.com/slides/id/net/aspose.slides.mathtext/imathparagraph/), dan kemudian panggil [IMathParagraph.ToLatex](https://reference.aspose.com/slides/id/net/aspose.slides.mathtext/imathparagraph/tolatex/). Metode ini mengembalikan string yang dapat Anda simpan, tampilkan, kirim ke aplikasi lain, atau proses lebih lanjut.

Contoh berikut memeriksa setiap bingkai teks pada setiap slide, menemukan semua math portions, dan menulis setiap persamaan ke file `.tex` terpisah:

```csharp
using var presentation = new Presentation("equations.pptx");

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    var slideNumber = slideIndex + 1;
    var equationNumber = 1;
    var textFrames = SlideUtil.GetAllTextBoxes(slide);

    foreach (var textFrame in textFrames)
    {
        foreach (var paragraph in textFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is not MathPortion mathPortion)
                    continue;

                IMathParagraph mathParagraph = mathPortion.MathParagraph;
                var latexPath = $"slide_{slideNumber}_equation_{equationNumber}.tex";

                var latexText = mathParagraph.ToLatex();
                File.WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}
```

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/id/net/aspose.slides.util/slideutil/getalltextboxes/) mengembalikan semua bingkai teks yang ditemukan pada sebuah slide. Pemeriksaan tipe [MathPortion](https://reference.aspose.com/slides/id/net/aspose.slides.mathtext/mathportion/) memisahkan persamaan yang dapat diedit secara nyata dari teks biasa dan gambar.

Mesin LaTeX dan templat dokumen tidak semuanya mendukung perintah, paket, atau karakter Unicode yang sama. Uji string yang dikembalikan dengan mesin LaTeX yang digunakan oleh aplikasi Anda. Jika sebuah simbol atau elemen Office Math tidak memiliki representasi yang cocok di lingkungan tersebut, gantilah dalam string yang dikembalikan dengan perintah khusus proyek atau lewati persamaan tersebut dan catat masalahnya untuk ditinjau.

## **Save Math Equations as MathML**

Walaupun manusia dapat dengan mudah menulis kode untuk beberapa format persamaan seperti LaTeX, mereka kesulitan menulis kode untuk MathML karena yang terakhir dimaksudkan untuk dihasilkan secara otomatis oleh aplikasi. Program dapat membaca dan mengurai MathML dengan mudah karena kodenya berbentuk XML, sehingga MathML umum digunakan sebagai format output dan pencetakan di banyak bidang. 

Contoh kode berikut menunjukkan cara mengekspor persamaan matematika dari sebuah presentasi ke MathML:

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

**Apa yang sebenarnya diekspor ke MathML—sebuah paragraf atau blok formula individu?**

Anda dapat mengekspor baik seluruh paragraf matematika ([MathParagraph](https://reference.aspose.com/slides/id/net/aspose.slides.mathtext/mathparagraph/)) maupun blok individu ([MathBlock](https://reference.aspose.com/slides/id/net/aspose.slides.mathtext/mathblock/)) ke MathML. Kedua tipe menyediakan metode untuk menulis ke MathML.

**Bagaimana saya dapat mengetahui bahwa sebuah objek pada slide adalah formula matematika, bukan teks biasa atau gambar?**

Sebuah formula berada dalam [MathPortion](https://reference.aspose.com/slides/id/net/aspose.slides.mathtext/mathportion/) dan memiliki [MathParagraph](https://reference.aspose.com/slides/id/net/aspose.slides.mathtext/mathparagraph/). Gambar dan bagian teks biasa tanpa [MathParagraph](https://reference.aspose.com/slides/id/net/aspose.slides.mathtext/mathparagraph/) tidak dapat diekspor sebagai formula.

**Dari mana MathML berasal dalam sebuah presentasi—apakah khusus PowerPoint atau standar?**

Ekspor menargetkan MathML standar (XML). Aspose menggunakan Presentation MathML—subset presentasi dari standar—yang banyak digunakan di berbagai aplikasi dan web.

**Apakah mengekspor formula di dalam tabel, SmartArt, grup, dll. didukung?**

Ya, jika objek tersebut berisi bagian teks dengan [MathParagraph](https://reference.aspose.com/slides/id/net/aspose.slides.mathtext/mathparagraph/) (yaitu formula PowerPoint yang sebenarnya), maka akan diekspor. Jika sebuah formula disematkan sebagai gambar, maka tidak.

**Apakah mengekspor ke MathML mengubah presentasi asli?**

Tidak. Menulis MathML adalah serialisasi konten formula; tidak mengubah file presentasi.