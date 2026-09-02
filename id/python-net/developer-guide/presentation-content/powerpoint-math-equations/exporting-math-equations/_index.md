---
title: Ekspor Persamaan Matematika dari Presentasi dalam Python
linktitle: Ekspor Persamaan
type: docs
weight: 30
url: /id/python-net/exporting-math-equations/
keywords:
- ekspor persamaan matematika
- ekspor persamaan ke LaTeX
- PowerPoint ke LaTeX
- MathML
- LaTeX
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Ekspor persamaan matematika dari presentasi PowerPoint ke LaTeX atau MathML secara langsung dengan Aspose.Slides untuk Python via .NET."
---
## **Pendahuluan**

Aspose.Slides untuk Python via .NET memungkinkan Anda mengekspor persamaan matematika dari presentasi. Misalnya, Anda mungkin perlu mengekstrak persamaan dari slide tertentu dan menggunakan kembali di program atau platform lain.

{{% alert color="primary" %}}
Anda dapat mengekspor persamaan langsung ke LaTeX atau ke MathML, standar populer untuk konten matematika yang digunakan di web dan banyak aplikasi.
{{% /alert %}}

## **Ekspor Persamaan Matematika ke LaTeX**

Aspose.Slides dapat mengonversi persamaan matematika PowerPoint langsung ke LaTeX; file MathML perantara dan konverter eksternal tidak diperlukan. Persamaan matematika disimpan dalam bingkai teks sebagai sebuah [MathPortion](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/mathportion/). Gunakan [MathPortion.math_paragraph](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) untuk mendapatkan sebuah [MathParagraph](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/mathparagraph/), kemudian panggil [MathParagraph.to_latex](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/mathparagraph/to_latex/). Metode tersebut mengembalikan string yang dapat Anda simpan, tampilkan, kirim ke aplikasi lain, atau proses lebih lanjut.

Contoh berikut memeriksa setiap bingkai teks pada setiap slide, menemukan semua bagian matematika, dan menulis setiap persamaan ke file `.tex` terpisah:

```py
import aspose.slides as slides

with slides.Presentation("equations.pptx") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        equation_number = 1
        text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.paragraphs:
                for portion in paragraph.portions:
                    if not isinstance(portion, slides.mathtext.MathPortion):
                        continue

                    math_paragraph = portion.math_paragraph
                    latex_path = f"slide_{slide_number}_equation_{equation_number}.tex"

                    latex_text = math_paragraph.to_latex()
                    with open(latex_path, "w", encoding="utf-8") as latex_file:
                        latex_file.write(latex_text)
                    equation_number += 1
```

[SlideUtil.get_all_text_boxes](https://reference.aspose.com/slides/id/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) mengembalikan semua bingkai teks yang ditemukan pada sebuah slide. Pemeriksaan tipe [MathPortion](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/mathportion/) memisahkan persamaan yang dapat diedit secara nyata dari teks dan gambar biasa.

Mesin LaTeX dan templat dokumen tidak semuanya mendukung perintah, paket, atau karakter Unicode yang sama. Uji string yang dikembalikan dengan mesin LaTeX yang digunakan oleh aplikasi Anda. Jika sebuah simbol atau elemen Office Math tidak memiliki representasi yang sesuai dalam lingkungan tersebut, gantilah dalam string yang dikembalikan dengan perintah khusus proyek atau lewati persamaan tersebut dan catat masalahnya untuk ditinjau.

## **Simpan Persamaan Matematika sebagai MathML**

Meskipun manusia dapat dengan mudah menulis LaTeX, MathML biasanya dihasilkan secara otomatis oleh aplikasi. Karena MathML berbasis XML, program dapat membaca dan mem‑parsenya dengan andal, sehingga sering digunakan sebagai format output dan pencetakan di berbagai bidang.

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

## **FAQ**

**Apa yang sebenarnya diekspor ke MathML—sebuah paragraf atau blok formula individual?**

Anda dapat mengekspor seluruh paragraf matematika ([MathParagraph](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/mathparagraph/)) atau sebuah blok individual ([MathBlock](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/mathblock/)) ke MathML. Kedua tipe menyediakan metode untuk menulis ke MathML.

**Bagaimana saya tahu bahwa sebuah objek pada slide adalah formula matematika bukan teks biasa atau gambar?**

Sebuah formula berada dalam sebuah [MathPortion](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/mathportion/) dan memiliki sebuah [MathParagraph](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/mathparagraph/). Gambar dan potongan teks biasa tanpa [MathParagraph](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/mathparagraph/) tidak dapat diekspor sebagai formula.

**Dari mana MathML berasal dalam sebuah presentasi—apakah khusus PowerPoint?**

Ekspor menargetkan MathML standar (XML). Aspose menggunakan Presentation MathML—subset presentasi dari standar tersebut—yang banyak digunakan di aplikasi dan web.

**Apakah mengekspor formula dalam tabel, SmartArt, grup, dll., didukung?**

Ya, jika objek-objek tersebut berisi potongan teks dengan [MathParagraph](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/mathparagraph/) (yaitu formula PowerPoint yang sebenarnya), maka akan diekspor. Jika sebuah formula disematkan sebagai gambar, maka tidak akan diekspor.

**Apakah mengekspor ke MathML mengubah presentasi asli?**

Tidak. Menulis MathML adalah proses serialisasi konten formula; tidak mengubah file presentasi.