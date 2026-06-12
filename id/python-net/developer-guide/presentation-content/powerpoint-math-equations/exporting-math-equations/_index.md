---
title: Ekspor Persamaan Matematika dari Presentasi dalam Python
linktitle: Ekspor Persamaan
type: docs
weight: 30
url: /id/python-net/exporting-math-equations/
keywords:
- ekspor persamaan matematika
- MathML
- LaTeX
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Buka ekspor persamaan matematika secara mulus dari PowerPoint ke MathML menggunakan Aspose.Slides untuk Python via .NET—pertahankan format dan tingkatkan kompatibilitas."
---
## **Pendahuluan**

Aspose.Slides for Python melalui .NET memungkinkan Anda mengekspor persamaan matematika dari presentasi. Misalnya, Anda mungkin perlu mengekstrak persamaan dari slide tertentu dan menggunakannya kembali di program atau platform lain.

{{% alert color="primary" %}}

Anda dapat mengekspor persamaan ke MathML, standar yang banyak digunakan untuk merepresentasikan konten matematika di web dan banyak aplikasi.

{{% /alert %}}

## **Simpan Persamaan Matematika sebagai MathML**

Meskipun manusia dapat dengan mudah menulis LaTeX, MathML biasanya dihasilkan secara otomatis oleh aplikasi. Karena MathML berbasis XML, program dapat membaca dan memparsenya secara andal, sehingga sering digunakan sebagai format keluaran dan pencetakan di banyak bidang.

Kode contoh berikut menunjukkan cara mengekspor persamaan matematika dari sebuah presentasi ke MathML:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_math_shape(0, 0, 500, 50)
    math_paragraph = auto_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    math_paragraph.add(
        math.MathematicalText("a").
            set_superscript("2").
            join("+").
            join(math.MathematicalText("b").set_superscript("2")).
            join("=").
            join(math.MathematicalText("c").set_superscript("2")))

    with open("mathml.xml", "wb") as file_stream:
        math_paragraph.write_as_math_ml(file_stream)
```

## **Tanya Jawab**

**Apa yang sebenarnya diekspor ke MathML—sebuah paragraf atau blok formula individu?**

Anda dapat mengekspor baik seluruh paragraf matematika ([MathParagraph](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/mathparagraph/)) maupun blok individu ([MathBlock](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/mathblock/)) ke MathML. Kedua tipe menyediakan metode untuk menulis ke MathML.

**Bagaimana saya dapat mengetahui bahwa sebuah objek pada slide adalah formula matematika bukan teks biasa atau gambar?**

Sebuah formula berada dalam [MathPortion](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/mathportion/) dan memiliki [MathParagraph](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/mathparagraph/). Gambar dan teks biasa yang tidak memiliki [MathParagraph](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/mathparagraph/) tidak dapat diekspor sebagai formula.

**Dari mana MathML berasal dalam sebuah presentasi—apakah khusus PowerPoint atau standar?**

Ekspor menargetkan MathML standar (XML). Aspose menggunakan Presentation MathML—subset presentasi dari standar—yang banyak digunakan di aplikasi dan web.

**Apakah mengekspor formula di dalam tabel, SmartArt, grup, dll. didukung?**

Ya, jika objek tersebut berisi bagian teks dengan [MathParagraph](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/mathparagraph/) (yaitu formula PowerPoint yang sebenarnya), mereka akan diekspor. Jika formula disematkan sebagai gambar, tidak.

**Apakah mengekspor ke MathML mengubah presentasi asli?**

Tidak. Menulis MathML adalah serialisasi konten formula; tidak mengubah file presentasi.