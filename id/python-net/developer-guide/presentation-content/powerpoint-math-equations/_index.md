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
description: "Menyisipkan dan mengedit persamaan matematika dalam file PowerPoint PPT dan PPTX dengan Aspose.Slides untuk Python via .NET, mendukung OMML, kontrol pemformatan, dan contoh kode Python yang jelas."
---
## **Gambaran Umum**

PowerPoint menyimpan persamaan sebagai Office Math Markup Language (OMML). Dengan Aspose.Slides untuk Python via .NET, Anda dapat membuat konten matematika yang sama secara programatis: pecahan, radikal, fungsi, limit, operator N-ary, matriks, array, dan blok matematika yang diformat.

Di PowerPoint, pengguna biasanya menambahkan persamaan dari **Insert > Equation**:

![Tab Sisipkan PowerPoint dengan perintah Persamaan dipilih](powerpoint-math-equations_1.png)

Hasilnya adalah teks matematika yang dapat diedit pada slide:

![Slide PowerPoint berisi persamaan matematika yang dapat diedit](powerpoint-math-equations_2.png)

Aspose.Slides membangun teks matematika tersebut melalui tiga objek utama:

- Sebuah shape matematika, dibuat dengan [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/), adalah shape yang berisi persamaan.
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) menyimpan konten matematika di dalam bingkai teks shape.
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) berisi satu atau lebih objek [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/).

Sebagian besar contoh di bawah menggunakan [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) dan metode fluency dari [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) untuk menjaga kode tetap singkat dan mudah dibaca.

Untuk skenario ekspor MathML, lihat [Ekspor Persamaan Matematika dari Presentasi di Python via .NET](/slides/id/python-net/exporting-math-equations/).

## **Buat Persamaan**

Contoh ini menggunakan [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) untuk membuat shape matematika dan menambahkan teorema Pythagoras:

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

{{% alert color="info" title="Note" %}}
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) membuat sebuah shape yang sudah berisi paragraf matematika. Akses [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), dapatkan [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), dan tambahkan blok matematika atau elemen matematika ke dalamnya.
{{% /alert %}}

## **Tambahkan Pecahan**

Gunakan [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) untuk membuat pecahan. Anda dapat memilih gaya pecahan dengan [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/).

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

Untuk pecahan bertumpuk, gunakan [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/):

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Tambahkan Akar**

Gunakan [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) untuk membuat akar kuadrat, akar kubik, atau akar lainnya. Elemen saat ini menjadi basis, dan argumen menjadi derajat.

![Ekspresi akar ke-n dengan x di bawah tanda akar](powerpoint-math-equations_5.png)

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

Gunakan [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) atau [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) untuk fungsi seperti `sin(x)`, `log(x)`, atau nama fungsi khusus. Untuk batas, letakkan `lim` dalam [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) atau gunakan [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/).

![Batas x saat x mendekati tak terhingga](powerpoint-math-equations_8.png)

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

Untuk nama fungsi khusus, buat nama fungsi menjadi elemen saat ini dan panggil [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) dengan argumennya:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **Tambahkan Operator N-ary dan Integral**

Gunakan [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/) untuk penjumlahan, union, interseksi, dan operator besar lainnya. Gunakan [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) untuk integral. Kedua metode memungkinkan Anda mengatur batas bawah dan atas.

![Penjumlahan dengan batas bawah dan atas](powerpoint-math-equations_7.png)

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

Operator N-ary digunakan untuk operator besar dengan batas opsional. Operator sederhana seperti `+`, `-`, dan `=` biasanya ditambahkan sebagai [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) dan digabungkan ke dalam ekspresi.

Untuk integral, gunakan [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/):

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Tambahkan Matriks**

Gunakan [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) untuk baris dan kolom. Matriks tidak menyertakan tanda kurung secara default, jadi balut matriks ketika Anda memerlukan kurung, tanda siku, atau kurung kurawal.

![Matriks matematika dua baris dengan satu sel kosong](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)

    # Sebuah matriks tidak memiliki kurung sendiri, jadi balutkan dengan tanda kurung.
    math_paragraph.add(math.MathBlock(matrix.enclose("(", ")")))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
`MathMatrix` membangun kisi baris dan kolom, mengatur celah di antara mereka, dan meratakan kolom, tetapi Aspose.Slides untuk Python via .NET tidak mengekspos accessor untuk sel matriks individual. Matriks yang dibuat dalam kode oleh karena itu mempertahankan sel kosong; sel-sel matriks yang berasal dari presentasi yang ada dapat dibaca dengan `get_children`. Gunakan array persamaan ketika Anda perlu mengisi baris dari kode.
{{% /alert %}}

## **Tambahkan Array Persamaan**

Gunakan [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) ketika Anda memerlukan persamaan yang selaras atau tumpukan vertikal ekspresi.

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

### **Selaraskan Array dengan Elemen Sekitar**

[IMathArray.base_justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/base_justification/) mengontrol perataan vertikal sebuah array relatif terhadap elemen matematika di sisinya. Contoh di bawah membandingkan perataan dengan baris pertama, tengah array, dan baris terakhir.

Contoh berikut membuat tiga array identik, masing‑masing dengan tiga baris dan elemen tetangga `A=` dan `=B`. Semua teks matematika menggunakan Cambria Math ukuran 24 poin. Hanya perataan array yang berubah.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def create_text(value):
    text = math.MathematicalText(value)
    text.format.font_height = 24
    text.format.latin_font = slides.FontData("Cambria Math")
    return text


with slides.Presentation() as presentation:
    presentation.slide_size.set_size(780, 200, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]
    alignments = [math.MathVerticalAlignment.TOP, math.MathVerticalAlignment.CENTER, math.MathVerticalAlignment.BOTTOM]
    labels = ["Top", "Center", "Bottom"]

    for i, alignment in enumerate(alignments):
        label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20 + i * 260, 10, 240, 30)
        label.fill_format.fill_type = slides.FillType.NO_FILL
        label.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        label.text_frame.text = labels[i]
        label_format = label.text_frame.paragraphs[0].portions[0].portion_format
        label_format.font_height = 16
        label_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.fill_format.solid_fill_color.color = slides.Color.black

        math_shape = slide.shapes.add_math_shape(20 + i * 260, 60, 240, 130)
        math_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph
        math_paragraph.justification = math.MathJustification.LEFT_JUSTIFIED

        rows = [create_text("x+y=3"), create_text("x-y=1"), create_text("x=2")]
        equation_array = math.MathArray(rows)
        equation_array.base_justification = alignment
        left_text = create_text("A=")
        right_text = create_text("=B")
        equation = math.MathBlock(left_text).join(equation_array).join(right_text)
        math_paragraph.add(equation)

    presentation.save("equation-array-alignment.pptx", slides.export.SaveFormat.PPTX)
```

Perbandingan berikut menunjukkan presentasi yang disimpan di PowerPoint. Perhatikan posisi `A=` dan `=B` di sebelah tiap array.

![Array persamaan di PowerPoint dengan perataan Atas, Tengah, dan Bawah serta elemen sebelah yang identik](equation-array-alignment.png)

### **Konfigurasikan Jarak Baris**

[row_spacing_rule](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing_rule/) memilih aturan jarak untuk baris dalam array. [row_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imatharray/row_spacing/) menyediakan nilai numerik untuk aturan jarak eksplisit dan diabaikan oleh aturan preset.

Untuk jarak tepat, nilai diukur dalam poin. Untuk jarak proporsional, diukur dalam setengah garis: nilai `3` pada contoh menentukan 1,5 garis. Atur kedua properti ketika menentukan nilai eksplisit; mengubah nilai numerik saja tidak memilih aturan jarak.

Contoh di bawah menyimpan lima presentasi dengan persamaan, perataan, dan pengaturan font yang sama. Tiga pertama menggunakan preset; dua terakhir menunjukkan nilai eksplisit.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def create_text(value):
    text = math.MathematicalText(value)
    text.format.font_height = 24
    text.format.latin_font = slides.FontData("Cambria Math")
    return text


settings = [
    (math.MathRowSpacingRule.SINGLE_LINE_GAP, 0),
    (math.MathRowSpacingRule.ONE_AND_A_HALF_LINE_GAP, 0),
    (math.MathRowSpacingRule.TWO_LINE_GAP, 0),
    (math.MathRowSpacingRule.EXACTLY, 20),
    (math.MathRowSpacingRule.MULTIPLE, 3)
]

for rule, spacing in settings:
    file_name = f"equation-array-{rule.name}.pptx"
    with slides.Presentation() as presentation:
        math_shape = presentation.slides[0].shapes.add_math_shape(20, 20, 600, 300)
        paragraph = math_shape.text_frame.paragraphs[0]
        paragraph.paragraph_format.space_before = 0
        paragraph.paragraph_format.space_after = 0
        math_paragraph = paragraph.portions[0].math_paragraph
        math_paragraph.justification = math.MathJustification.LEFT_JUSTIFIED

        rows = [create_text("x+y=3"), create_text("x-y=1"), create_text("x=2")]
        equation_array = math.MathArray(rows)
        equation_array.base_justification = math.MathVerticalAlignment.CENTER
        equation_array.row_spacing_rule = rule
        equation_array.row_spacing = spacing
        left_text = create_text("A=")
        right_text = create_text("=B")
        equation = math.MathBlock(left_text).join(equation_array).join(right_text)
        math_paragraph.add(equation)

        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

Jarak baris array terpisah dari jarak paragraf. [space_before](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_before/) dan [space_after](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformat/space_after/) menambah ruang di sekitar paragraf yang mengandungnya, bukan di antara baris array. Demikian pula, [IMathParagraph.justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathparagraph/justification/) memposisikan seluruh paragraf matematika secara horizontal; tidak menggantikan pengaturan perataan vertikal array.

## **Tambahkan Fungsi Trigonometri**

Gunakan [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) ketika argumen adalah elemen saat ini dan nama fungsi sudah diketahui.

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

Gunakan helper subskrip dan superskrip untuk indeks dan pangkat. Ketika indeks harus muncul di sisi kiri basis, gunakan [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/).

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

## **Tambahkan Pembatas**

Gunakan [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) untuk menempatkan ekspresi di dalam pembatas. Anda juga dapat menentukan karakter pemisah untuk ekspresi pembatas yang berisi beberapa elemen.

![Ekspresi pembatas yang berisi x, y, dan z dipisahkan oleh batang vertikal](powerpoint-math-equations_13.png)

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

### **Ukuran dan Penjajaran Pembatas**

Setel [grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/grow_to_match_operand_height/) ke `True` agar tanda kurung tumbuh mengelilingi operand tinggi, atau ke `False` agar tetap pada ukuran normal. [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/delimiter_shape/) menerima salah satu dari dua nilai [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/). `CENTERED` memusatkan tanda kurung pada sumbu matematika, yang melewati tengah tanda sama dengan. `MATCH` menyelaraskannya dengan konten yang dibungkus. Kedua pengaturan memengaruhi hanya pembatas. Ekspresi di dalam tetap sama.

Contoh menempatkan pecahan di pangkat `x` sehingga ekspresi memanjang lebih tinggi di atas garis dasar daripada di bawahnya. Keempat persamaan menggunakan tanda kurung dan pengaturan font yang sama.

```python
import aspose.slides as slides
import aspose.slides.mathtext as math


def add_expression(slide, left, top, grow, shape):
    fraction = math.MathematicalText("a + b").divide("c + d")
    power = math.MathematicalText("x").set_superscript(fraction)
    delimiter = power.enclose("(", ")")
    delimiter.grow_to_match_operand_height = grow
    delimiter.delimiter_shape = shape

    math_shape = slide.shapes.add_math_shape(left, top, 300, 100)
    portion = math_shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.font_height = 32
    equation = math.MathematicalText("y = ").join(delimiter)
    portion.math_paragraph.add(equation)


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    add_expression(slide, 20, 20, True, math.MathDelimiterShape.CENTERED)
    add_expression(slide, 350, 20, True, math.MathDelimiterShape.MATCH)
    add_expression(slide, 20, 140, False, math.MathDelimiterShape.CENTERED)
    add_expression(slide, 350, 140, False, math.MathDelimiterShape.MATCH)

    presentation.save("delimiter-sizing.pptx", slides.export.SaveFormat.PPTX)
```

Di PowerPoint, bandingkan baris untuk melihat efek pertumbuhan. Pada baris atas, tanda kurung tumbuh mengelilingi pangkat dan tampak serupa untuk kedua bentuk. Pada baris bawah, pertumbuhan dimatikan. Tanda kurung lebih kecil di kiri (`CENTERED`) beralign dengan tanda sama dengan, sementara yang di kanan (`MATCH`) berada lebih tinggi di sekitar ekspresi.

![Empat persamaan di PowerPoint dengan pertumbuhan pembatas diaktifkan di atas dan dinonaktifkan di bawah, serta Centered di kiri dan Match di kanan](delimiter-sizing.png)

## **Tambahkan Kotak Garis Batas**

Panggil [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) pada pecahan untuk membingkai seluruh ekspresi. [IMathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/) yang dikembalikan menampilkan keempat sisi secara default. Gunakan [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_top/), [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_bottom/), [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_left/), dan [hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_right/) untuk menghapus sisi individu.

Contoh menempatkan enam salinan pecahan yang sama pada satu slide. Untuk menunjukkan pembatalan, sembunyikan keempat sisi dan setel [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_bottom_left_to_top_right/) untuk diagonal naik (↗) atau [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_top_left_to_bottom_right/) untuk diagonal turun (↘). Anda juga dapat menggunakan [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_horizontal/) atau [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_vertical/) dengan kombinasi sisi yang terlihat mana pun.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def add_fraction(slide, x, y, hide_border=False):
    fraction = math.MathematicalText("x+1").divide("y+2")
    box = fraction.to_border_box()
    box.hide_top = box.hide_bottom = box.hide_left = box.hide_right = hide_border

    shape = slide.shapes.add_math_shape(x, y, 160, 90)
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.font_height = 28
    portion.math_paragraph.add(math.MathBlock(box))
    return box


with slides.Presentation() as presentation:
    presentation.slide_size.set_size(540, 220, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    add_fraction(slide, 10, 10)

    partial = add_fraction(slide, 190, 10)
    partial.hide_top = True
    partial.hide_right = True

    add_fraction(slide, 370, 10, hide_border=True).strikethrough_bottom_left_to_top_right = True
    add_fraction(slide, 10, 120, hide_border=True).strikethrough_top_left_to_bottom_right = True
    add_fraction(slide, 190, 120, hide_border=True).strikethrough_horizontal = True
    add_fraction(slide, 370, 120).strikethrough_vertical = True

    presentation.save("border-box.pptx", slides.export.SaveFormat.PPTX)
```

![Enam pecahan yang dapat diedit di PowerPoint. Baris atas: batas penuh, sisi bawah dan kiri, diagonal naik. Baris bawah: diagonal turun, garis horizontal, garis vertikal dengan batas penuh.](border-box-fractions.png)

Pada pecahan ini, garis horizontal menutupi batang pecahan. Garis vertikal menyeberang numerator dan denominator sekaligus batas di sekitarnya tetap terlihat. Garis‑garis ini menghias seluruh ekspresi. Strikethrough teks biasa berlaku pada karakter dalam satu run teks. Setelah membuka kembali presentasi di PowerPoint, Anda masih dapat mengedit numerator dan denominator secara terpisah.

## **Kelompokkan Istilah**

Gunakan [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) untuk menempatkan karakter pengelompokan di atas atau di bawah ekspresi. Tambahkan batas untuk memberi label pada istilah yang dikelompokkan.

![Ekspresi x plus y dikelompokkan dengan label teks apa pun di bawahnya](powerpoint-math-equations_15.png)

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

Gunakan helper format hanya bila memperjelas formula. Misalnya, [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) menempatkan bar di atas elemen matematika.

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

### **Format Teks dalam Persamaan yang Ada**

Untuk memformat teks di seluruh persamaan yang ada, telusuri setiap pohon elemen blok matematika. [IMathElement.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/get_children/) mengembalikan hanya anak langsung, sehingga panggil secara rekursif untuk mencapai teks di dalam pecahan, skrip, radikal, dan struktur bersarang lainnya. Periksa elemen saat ini serta anak‑nya untuk menyertakan elemen awal bila itu adalah [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/).

Contoh ini mengasumsikan bahwa `input.pptx` berisi persamaan seperti `z = xᵢ / ∛y`, dengan pecahan yang mengandung subskrip di numerator dan radikal di denominator. Memproses hanya elemen tingkat atas blok akan melewatkan teks di dalam pecahan. Contoh menemukan bagian matematika dalam bingkai teks slide, mengakses blok‑nya melalui [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), dan menetapkan [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) menjadi 28 poin melalui properti [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) setiap elemen teks.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def format_math_text(element):
    if isinstance(element, math.MathematicalText):
        element.format.font_height = 28

    for child in element.get_children():
        format_math_text(child)


with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if isinstance(portion, math.MathPortion):
                        for block in portion.math_paragraph:
                            format_math_text(block)

    presentation.save("formatted-equations.pptx", slides.export.SaveFormat.PPTX)
```

Presentasi yang disimpan berisi pemformatan teks yang diperbarui pada setiap tingkatan masing‑masing persamaan yang diproses, sambil mempertahankan konten teks dan struktur matematika.

## **Referensi Cepat**

| Task | Main API |
| --- | --- |
| Buat teks matematika | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Gabungkan elemen | [IMathElement.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/) |
| Buat pecahan | [IMathElement.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) |
| Tambahkan superskrip atau subskrip | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| Tambahkan fungsi | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| Tambahkan radikal | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) |
| Tambahkan batas | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| Tambahkan skrip sisi kiri | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| Tambahkan penjumlahan dan integral | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) |
| Tambahkan matriks | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| Tambahkan array persamaan | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| Tambahkan pembatas | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| Tambahkan bar dan batas | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| Kelompokkan istilah | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Bisakah saya mengedit persamaan PowerPoint yang ada?**

Ya. Buka presentasi, temukan shape yang berisi [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), dapatkan [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), dan perbarui blok‑blok matematika dalam paragraf tersebut.

**Apakah persamaan disimpan sebagai matematika PowerPoint yang dapat diedit?**

Ya. Saat Anda menyimpan ke PPTX, Aspose.Slides menulis persamaan sebagai konten Office Math yang dapat diedit.

**Bisakah saya mengekspor persamaan ke LaTeX?**

Ya. Dapatkan [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) dari [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), dan panggil [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) untuk mengekspornya secara langsung. Untuk contoh lengkap, lihat [Ekspor Persamaan Matematika dari Presentasi di Python via .NET](/slides/id/python-net/exporting-math-equations/#export-math-equations-to-latex).