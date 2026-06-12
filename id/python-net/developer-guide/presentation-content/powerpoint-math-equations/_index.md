---
title: Tambahkan Persamaan Matematika ke Presentasi PowerPoint dalam Python
linktitle: Persamaan Matematika PowerPoint
type: docs
weight: 80
url: /id/python-net/powerpoint-math-equations/
keywords:
- persamaan matematika
- simbol matematika
- rumus matematika
- teks matematika
- tambahkan persamaan matematika
- tambahkan simbol matematika
- tambahkan rumus matematika
- tambahkan teks matematika
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Menyisipkan dan mengedit persamaan matematika dalam PowerPoint PPT dan PPTX dengan Aspose.Slides untuk Python via .NET, mendukung OMML, kontrol pemformatan, dan contoh kode Python yang jelas."
---
## **Ikhtisar**

PowerPoint menyimpan persamaan sebagai Office Math Markup Language (OMML). Dengan Aspose.Slides for Python via .NET, Anda dapat membuat konten matematika yang sama secara programatis: pecahan, radikal, fungsi, batas, operator N-ary, matriks, array, dan blok matematika yang diformat.

Di PowerPoint, pengguna biasanya menambahkan persamaan melalui **Insert > Equation**:

![Tab Sisipkan PowerPoint dengan perintah Persamaan dipilih](powerpoint-math-equations_1.png)

Hasilnya adalah teks matematika yang dapat diedit pada slide:

![Sebuah slide PowerPoint yang berisi persamaan matematika yang dapat diedit](powerpoint-math-equations_2.png)

Aspose.Slides membangun teks matematika tersebut melalui tiga objek utama:

- Sebuah bentuk matematika, yang dibuat dengan [add_math_shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/add_math_shape/), adalah bentuk yang berisi persamaan.
- [MathPortion](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/mathportion/) menyimpan konten matematika di dalam bingkai teks bentuk.
- [MathParagraph](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/mathparagraph/) berisi satu atau beberapa objek [MathBlock](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/mathblock/).

Sebagian besar contoh di bawah ini menggunakan [MathematicalText](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/mathematicaltext/) dan metode fluent dari [IMathElement](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/) untuk menjaga kode tetap singkat dan mudah dibaca.

Untuk skenario ekspor MathML, lihat [Export Math Equations from Presentations in Python via .NET](/slides/id/python-net/exporting-math-equations/).

## **Buat Persamaan**

Contoh ini membuat sebuah bentuk matematika dan menambahkan teorema Pythagoras:

![Persamaan c kuadrat sama dengan a kuadrat ditambah b kuadrat](powerpoint-math-equations_3.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    equation = (
        math.MathematicalText("c")
        .set_superscript("2")
        .join("=")
        .join(math.MathematicalText("a").set_superscript("2"))
        .join("+")
        .join(math.MathematicalText("b").set_superscript("2"))
    )

    math_paragraph.add(equation)

    presentation.save("pythagorean-theorem.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}}

`add_math_shape` membuat sebuah bentuk yang sudah berisi paragraf matematika. Akses `MathPortion` pertama, dapatkan `MathParagraph`‑nya, dan tambahkan blok matematika atau elemen matematika ke dalamnya.

{{% /alert %}}

## **Tambahkan Pecahan**

Gunakan [`divide`](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/divide/) untuk membuat sebuah pecahan. Anda dapat memilih gaya pecahan dengan [MathFractionTypes](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/mathfractiontypes/).

![Pecahan matematika miring yang menunjukkan satu dibagi x](powerpoint-math-equations_4.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    fraction = math.MathematicalText("1").divide("x", math.MathFractionTypes.SKEWED)

    math_paragraph.add(math.MathBlock(fraction))

    presentation.save("fraction.pptx", slides.export.SaveFormat.PPTX)
```

Untuk pecahan bertumpuk, gunakan `MathFractionTypes.BAR`:

```py
stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Tambahkan Radikal**

Gunakan [`radical`](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/radical/) untuk membuat akar kuadrat, akar kubik, atau akar lainnya. Elemen saat ini menjadi basis, dan argumen menjadi derajatnya.

![Ekspresi radikal akar ke-n dengan x di bawah tanda radikal](powerpoint-math-equations_5.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    radical = math.MathematicalText("x").radical("n")

    math_paragraph.add(math.MathBlock(radical))

    presentation.save("radical.pptx", slides.export.SaveFormat.PPTX)
```

## **Tambahkan Fungsi dan Batas**

Gunakan [`as_argument_of_function`](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) atau [`function`](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/function/) untuk fungsi seperti `sin(x)`, `log(x)`, atau nama fungsi khusus. Untuk batas, letakkan `lim` dalam sebuah [MathLimit](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/mathlimit/) atau gunakan [`set_lower_limit`](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/).

![Batas dari x saat x mendekati tak terhingga](powerpoint-math-equations_8.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    limit = (
        math.MathematicalText("lim")
        .set_lower_limit("x\u2192\u221E")
        .function("x")
    )

    math_paragraph.add(math.MathBlock(limit))

    presentation.save("functions-and-limits.pptx", slides.export.SaveFormat.PPTX)
```

Untuk nama fungsi khusus, jadikan nama fungsi sebagai elemen saat ini:

```py
custom_function = math.MathematicalText("f").function("x + 1")
```

## **Tambahkan Operator N-ary dan Integral**

Gunakan [`nary`](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/nary/) untuk penjumlahan, union, interseksi, dan operator besar lainnya. Gunakan [`integral`](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/integral/) untuk integral. Kedua metode memungkinkan Anda menambahkan batas bawah dan atas.

![Sebuah penjumlahan dengan batas bawah dan atas](powerpoint-math-equations_7.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    summation_base = (
        math.MathematicalText("x")
        .set_superscript("k")
        .join(math.MathematicalText("a").set_superscript("n-k"))
    )

    summation = summation_base.nary(math.MathNaryOperatorTypes.SUMMATION, "k=0", "n")

    math_paragraph.add(math.MathBlock(summation))

    presentation.save("nary-operators.pptx", slides.export.SaveFormat.PPTX)
```

Operator N-ary ditujukan untuk operator besar dengan batas opsional. Operator sederhana seperti `+`, `-`, dan `=` biasanya ditambahkan sebagai `MathematicalText` dan digabungkan ke dalam ekspresi.

Untuk integral, gunakan `integral`:

```py
integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Tambahkan Matriks**

Gunakan [MathMatrix](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/mathmatrix/) untuk baris dan kolom. Matriks secara default tidak menyertakan kurung, jadi bungkus matriks dengan tanda kurung, siku, atau kurawal bila diperlukan.

![Matriks matematika dua baris dengan satu sel kosong](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)
    matrix[0, 0] = math.MathematicalText("1")
    matrix[0, 1] = math.MathematicalText("x")
    matrix[1, 0] = math.MathematicalText("x")
    matrix[1, 1] = math.MathematicalText("2")
    matrix[1, 2] = math.MathematicalText("y")

    math_paragraph.add(math.MathBlock(matrix))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

## **Tambahkan Array Persamaan**

Gunakan [`to_math_array`](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/to_math_array/) ketika Anda membutuhkan persamaan yang diratakan atau tumpukan vertikal dari ekspresi.

![Array matematika vertikal dengan x di atas y](powerpoint-math-equations_11.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 140)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    equation_array = (
        math.MathematicalText("x")
        .join("y")
        .to_math_array()
    )

    math_paragraph.add(math.MathBlock(equation_array))

    presentation.save("equation-array.pptx", slides.export.SaveFormat.PPTX)
```

## **Tambahkan Fungsi Trigonometri**

Gunakan [`as_argument_of_function`](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) ketika argumen adalah elemen saat ini dan nama fungsi sudah diketahui.

![Fungsi trigonometri cos diterapkan pada 2x](powerpoint-math-equations_6.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    cosine = math.MathematicalText("2x").as_argument_of_function(
        math.MathFunctionsOfOneArgument.COS
    )

    math_paragraph.add(math.MathBlock(cosine))

    presentation.save("trigonometric-function.pptx", slides.export.SaveFormat.PPTX)
```

## **Tambahkan Subskrip dan Superskrip**

Gunakan pembantu subskrip dan superskrip untuk indeks dan pangkat. Ketika indeks harus muncul di sisi kiri basis, gunakan [`set_sub_superscript_on_the_left`](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/).

![Huruf Y kapital dengan subskrip sisi kiri 1 dan superskrip n](powerpoint-math-equations_9.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    scripts = math.MathematicalText("Y").set_sub_superscript_on_the_left("1", "n")

    math_paragraph.add(math.MathBlock(scripts))

    presentation.save("subscript-superscript.pptx", slides.export.SaveFormat.PPTX)
```

## **Tambahkan Delimiter**

Gunakan [`enclose`](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/enclose/) untuk menempatkan sebuah ekspresi di dalam delimiter. Anda juga dapat mengatur karakter pemisah untuk ekspresi delimiter yang berisi beberapa elemen.

![Ekspresi delimiter yang berisi x, y, dan z dipisahkan oleh garis vertikal](powerpoint-math-equations_13.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    delimiter = (
        math.MathematicalText("x")
        .join("y")
        .join("z")
        .enclose("<", ">")
    )
    delimiter.separator_character = "|"

    math_paragraph.add(math.MathBlock(delimiter))

    presentation.save("delimiters.pptx", slides.export.SaveFormat.PPTX)
```

## **Tambahkan Kotak Bingkai**

Gunakan [`to_border_box`](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/to_border_box/) ketika persamaan itu sendiri harus dibingkai.

![Persamaan dalam kotak yang menunjukkan a kuadrat sama dengan b kuadrat ditambah c kuadrat](powerpoint-math-equations_12.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    boxed_equation = (
        math.MathematicalText("a")
        .set_superscript("2")
        .join("=")
        .join(math.MathematicalText("b").set_superscript("2"))
        .join("+")
        .join(math.MathematicalText("c").set_superscript("2"))
        .to_border_box()
    )

    math_paragraph.add(math.MathBlock(boxed_equation))

    presentation.save("border-box.pptx", slides.export.SaveFormat.PPTX)
```

## **Kelompokkan Istilah**

Gunakan [`group`](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/group/) untuk menempatkan karakter pengelompokan di atas atau di bawah sebuah ekspresi. Tambahkan batas untuk memberi label pada istilah yang dikelompokkan.

![Ekspresi x plus y dikelompokkan dengan label teks apa saja di bawahnya](powerpoint-math-equations_15.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    grouped = (
        math.MathematicalText("x + y")
        .group(chr(0x23DF), math.MathTopBotPositions.BOTTOM, math.MathTopBotPositions.TOP)
        .set_lower_limit("any text")
    )

    math_paragraph.add(math.MathBlock(grouped))

    presentation.save("grouped-terms.pptx", slides.export.SaveFormat.PPTX)
```

## **Format Elemen Matematika**

Gunakan pembantu pemformatan hanya ketika mereka memperjelas rumus. Misalnya, [`overbar`](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/overbar/) menempatkan sebuah garis di atas elemen matematika.

![Ekspresi matematika ABC dengan overbar](powerpoint-math-equations_14.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    overbar = math.MathematicalText("ABC").overbar()

    math_paragraph.add(math.MathBlock(overbar))

    presentation.save("overbar.pptx", slides.export.SaveFormat.PPTX)
```

## **Referensi Cepat**

| Tugas | API Utama |
| --- | --- |
| Buat teks matematika | [MathematicalText](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Gabungkan elemen | [IMathElement.join](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/join/) |
| Buat pecahan | [IMathElement.divide](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/divide/) |
| Tambahkan superskrip atau subskrip | [set_superscript](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| Tambahkan fungsi | [function](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| Tambahkan radikal | [radical](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/radical/) |
| Tambahkan batas | [set_lower_limit](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| Tambahkan skrip sisi kiri | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| Tambahkan penjumlahan dan integral | [nary](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/integral/) |
| Tambahkan matriks | [MathMatrix](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/mathmatrix/) |
| Tambahkan array persamaan | [to_math_array](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| Tambahkan delimiter | [enclose](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| Tambahkan bar dan bingkai | [overbar](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| Kelompokkan istilah | [group](https://reference.aspose.com/slides/id/python-net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Apakah saya dapat mengedit persamaan PowerPoint yang ada?**

Ya. Buka presentasi, temukan bentuk yang berisi `MathPortion`, dapatkan `MathParagraph`‑nya, dan perbarui blok matematika dalam paragraf tersebut.

**Apakah persamaan disimpan sebagai matematika PowerPoint yang dapat diedit?**

Ya. Saat Anda menyimpan ke PPTX, Aspose.Slides menulis persamaan sebagai konten Office Math yang dapat diedit.

**Apakah saya dapat mengekspor persamaan ke LaTeX?**

Aspose.Slides mengekspor persamaan matematika ke MathML. Jika Anda memerlukan LaTeX, ekspor dulu ke MathML kemudian konversi MathML dengan alat yang mendukung dialek LaTeX target Anda.