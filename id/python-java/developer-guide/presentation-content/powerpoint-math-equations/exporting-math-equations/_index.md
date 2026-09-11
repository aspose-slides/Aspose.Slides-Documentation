---
title: Ekspor Persamaan Matematika dari Presentasi dalam Python
linktitle: Ekspor Persamaan
type: docs
weight: 30
url: /id/python-java/exporting-math-equations/
keywords:
- ekspor persamaan matematika
- ekspor persamaan ke LaTeX
- PowerPoint ke LaTeX
- MathML
- LaTeX
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Ekspor persamaan matematika dari presentasi PowerPoint ke LaTeX atau MathML secara langsung dengan Aspose.Slides untuk Python via Java."
---
## **Pendahuluan**

Aspose.Slides memungkinkan Anda mengekspor persamaan matematika dari presentasi. Misalnya, Anda mungkin perlu mengekstrak persamaan matematika pada slide (dari presentasi tertentu) dan menggunakannya di program atau platform lain. 

{{% alert color="info" title="Catatan" %}} 
Anda dapat mengekspor persamaan secara langsung ke LaTeX atau ke MathML, standar populer untuk konten matematika yang digunakan di web dan banyak aplikasi.
{{% /alert %}}

## **Ekspor Persamaan Matematika ke LaTeX**

Aspose.Slides dapat mengonversi persamaan matematika PowerPoint langsung ke LaTeX; tidak diperlukan file MathML perantara atau konverter eksternal. Sebuah persamaan matematika disimpan dalam bingkai teks sebagai [MathPortion](https://reference.aspose.com/slides/id/python-java/aspose.slides/mathportion/). Gunakan [MathPortion.getMathParagraph](https://reference.aspose.com/slides/id/python-java/aspose.slides/mathportion/#getMathParagraph) untuk mendapatkan sebuah [MathParagraph](https://reference.aspose.com/slides/id/python-java/aspose.slides/mathparagraph/), lalu panggil [MathParagraph.toLatex](https://reference.aspose.com/slides/id/python-java/aspose.slides/mathparagraph/#toLatex). Metode ini mengembalikan string yang dapat Anda simpan, tampilkan, kirim ke aplikasi lain, atau proses lebih lanjut.

Contoh berikut memeriksa setiap bingkai teks pada setiap slide, menemukan semua bagian matematika, dan menulis setiap persamaan ke file `.tex` terpisah:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathPortion, Presentation, SlideUtil

presentation = Presentation("equations.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide_index + 1
        equation_number = 1
        text_frames = SlideUtil.getAllTextBoxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    if not isinstance(portion, MathPortion):
                        continue

                    math_paragraph = portion.getMathParagraph()
                    latex_file_name = f"slide_{slide_number}_equation_{equation_number}.tex"
                    latex_text = math_paragraph.toLatex()
                    latex_path = Path(latex_file_name)
                    latex_path.write_text(str(latex_text), encoding="utf-8")
                    equation_number += 1
finally:
    presentation.dispose()
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideutil/#getAllTextBoxes) mengembalikan semua bingkai teks yang ditemukan pada slide. Pemeriksaan tipe [MathPortion](https://reference.aspose.com/slides/id/python-java/aspose.slides/mathportion/) memisahkan persamaan yang dapat diedit dari teks biasa dan gambar.

Mesin LaTeX dan templat dokumen tidak semuanya mendukung perintah, paket, atau karakter Unicode yang sama. Uji string yang dikembalikan dengan mesin LaTeX yang digunakan aplikasi Anda. Jika sebuah simbol atau elemen Office Math tidak memiliki representasi yang cocok di lingkungan tersebut, gantilah dalam string yang dikembalikan dengan perintah khusus proyek atau lewati persamaan tersebut dan catat masalah untuk ditinjau.

## **Simpan Persamaan Matematika sebagai MathML**

Meskipun orang dapat dengan mudah menulis kode untuk beberapa format persamaan, seperti LaTeX, MathML lebih sulit ditulis secara manual karena dirancang untuk dihasilkan secara otomatis oleh aplikasi. Program dapat dengan mudah membaca dan mengurai MathML karena berbasis XML, sehingga MathML umum digunakan sebagai format output dan pencetakan di banyak bidang. 

Kode contoh ini menunjukkan cara mengekspor persamaan matematika dari presentasi ke MathML:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText, Presentation
from java.io import FileOutputStream

presentation = Presentation()
try:
    math_shape = presentation.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50)
    math_portion = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    math_paragraph = math_portion.getMathParagraph()

    a_squared = MathematicalText("a").setSuperscript("2")
    b_squared = MathematicalText("b").setSuperscript("2")
    c_squared = MathematicalText("c").setSuperscript("2")
    equation = a_squared.join("+").join(b_squared).join("=").join(c_squared)
    math_paragraph.add(equation)

    stream = FileOutputStream("mathml.xml")
    try:
        math_paragraph.writeAsMathMl(stream)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

## **FAQ**

**Apa yang sebenarnya diekspor ke MathML—paragraf atau blok formula individu?**

Anda dapat mengekspor seluruh paragraf matematika ([MathParagraph](https://reference.aspose.com/slides/id/python-java/aspose.slides/mathparagraph/)) atau blok individu ([MathBlock](https://reference.aspose.com/slides/id/python-java/aspose.slides/mathblock/)) ke MathML. Kedua tipe menyediakan metode untuk menulis ke MathML.

**Bagaimana saya dapat mengetahui bahwa sebuah objek pada slide adalah formula matematika bukan teks biasa atau gambar?**

Sebuah formula berada dalam [MathPortion](https://reference.aspose.com/slides/id/python-java/aspose.slides/mathportion/) dan memiliki [MathParagraph](https://reference.aspose.com/slides/id/python-java/aspose.slides/mathparagraph/). Gambar dan bagian teks biasa tanpa [MathParagraph](https://reference.aspose.com/slides/id/python-java/aspose.slides/mathparagraph/) tidak dapat diekspor sebagai formula.

**Dari mana MathML berasal dalam presentasi—apakah khusus PowerPoint atau standar?**

Target ekspor adalah MathML standar (XML). Aspose menggunakan Presentation MathML—subset presentasi dari standar—yang banyak digunakan di berbagai aplikasi dan web.

**Apakah mengekspor formula di dalam tabel, SmartArt, grup, dll. didukung?**

Ya, jika objek-objek tersebut berisi bagian teks dengan [MathParagraph](https://reference.aspose.com/slides/id/python-java/aspose.slides/mathparagraph/) (yaitu formula PowerPoint yang asli), maka akan diekspor. Jika sebuah formula tertanam sebagai gambar, maka tidak.

**Apakah mengekspor ke MathML mengubah presentasi asli?**

Tidak. Menulis MathML adalah proses serialisasi konten formula; tidak mengubah file presentasi.