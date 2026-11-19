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
description: "Menyisipkan dan mengedit persamaan matematika dalam PPT dan PPTX PowerPoint dengan Aspose.Slides untuk Python via .NET, mendukung OMML, kontrol pemformatan, dan contoh kode Python yang jelas."
---
## **Gambaran Umum**

PowerPoint menyimpan persamaan sebagai Office Math Markup Language (OMML). Dengan Aspose.Slides untuk Python via .NET, Anda dapat membuat konten matematika yang sama secara programatik: pecahan, radikal, fungsi, limit, operator N-ary, matriks, array, dan blok matematika yang diformat.

Di PowerPoint, pengguna biasanya menambahkan persamaan melalui **Insert > Equation**:

![Tab Insert PowerPoint dengan perintah Equation dipilih](powerpoint-math-equations_1.png)

Hasilnya adalah teks matematika yang dapat diedit pada slide:

![Slide PowerPoint yang berisi persamaan matematika yang dapat diedit](powerpoint-math-equations_2.png)

Aspose.Slides membangun teks matematika tersebut melalui tiga objek utama:

- Sebuah shape matematika, dibuat dengan [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/), adalah shape yang berisi persamaan.
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) menyimpan konten matematika di dalam bingkai teks shape.
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) berisi satu atau beberapa objek [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/).

Sebagian besar contoh di bawah menggunakan [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) dan metode fluent dari [MathElementBase](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/) untuk menjaga kode tetap singkat dan mudah dibaca.

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
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) membuat shape yang sudah berisi paragraf matematika. Akses [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) pertama, dapatkan [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), dan tambahkan blok matematika atau elemen matematika ke dalamnya.
{{% /alert %}}

### **Gabungkan Blok Matematika**

Ketika bagian-bagian persamaan dibangun secara terpisah sebagai objek [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/), gunakan [join_block](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/join_block/) untuk menggabungkannya. Contoh ini membuat `c² =` di blok kiri dan `a² + b²` di blok kanan. [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_superscript/) membuat superskrip matematika yang dapat diedit untuk ketiga pangkat.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_math_shape(20, 20, 600, 100)
    math_paragraph = shape.text_frame.paragraphs[0].portions[0].math_paragraph

    left_block = math.MathBlock()
    left_block.add(math.MathematicalText("c").set_superscript("2"))
    left_block.add(math.MathematicalText("="))

    right_block = math.MathBlock()
    right_block.add(math.MathematicalText("a").set_superscript("2"))
    right_block.add(math.MathematicalText("+"))
    right_block.add(math.MathematicalText("b").set_superscript("2"))

    combined_block = left_block.join_block(right_block)
    math_paragraph.add(combined_block)

    presentation.save("equation.pptx", slides.export.SaveFormat.PPTX)
```

[join_block](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/join_block/) mengembalikan `left_block` itu sendiri, yang kini berisi kedua bagian secara berurutan, dan meninggalkan `right_block` kosong. Tambahkan blok yang digabungkan ke [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) hanya sekali. Setelah membuka kembali `equation.pptx`, paragraf berisi satu blok yang mewakili `c² = a² + b²`, dengan ketiga pangkat tetap sebagai superskrip matematika.

Memanggil [add](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/add/) sebagai `left_block.add(right_block)` justru mencoba menanam satu blok langsung di dalam blok lain dan menghasilkan `RuntimeError` yang membungkus .NET `InvalidOperationException`.

## **Tambahkan Pecahan**

Gunakan [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/divide/) untuk membuat pecahan. Anda dapat memilih gaya pecahan dengan [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/).

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

## **Tambahkan Radikal**

Gunakan [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/radical/) untuk membuat akar kuadrat, akar kubik, atau akar lainnya. Elemen saat ini menjadi basis, dan argumen menjadi derajat.

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

### **Tampilkan atau Sembunyikan Derajat Akar Kuadrat**

Akar kuadrat dapat menampilkan angka 2 secara eksplisit atau menggunakan notasi √x konvensional. Properti [hide_degree](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/hide_degree/) dari [MathRadical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/) mengontrol bentuk yang muncul. Kedua bentuk tetap mempertahankan derajat 2 dan radikand x dalam persamaan yang dapat diedit.

![Akar kuadrat x dengan derajat 2 terlihat di kiri dan disembunyikan di kanan](square-root-degree.png)

Contoh ini menyimpan akar kuadrat yang sama dua kali. Angka 2 terlihat pada `visible-degree.pptx` dan disembunyikan pada `hidden-degree.pptx`.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    radical = math.MathematicalText("x").radical("2")

    shape = slide.shapes.add_math_shape(20, 20, 200, 100)
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.math_paragraph.add(math.MathBlock(radical))

    radical.hide_degree = False
    presentation.save("visible-degree.pptx", slides.export.SaveFormat.PPTX)

    radical.hide_degree = True
    presentation.save("hidden-degree.pptx", slides.export.SaveFormat.PPTX)
```

## **Tambahkan Fungsi dan Batas**

Gunakan [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) atau [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/) untuk fungsi seperti `sin(x)`, `log(x)`, atau nama fungsi khusus. Untuk batas, letakkan `lim` dalam [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) atau gunakan [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_lower_limit/).

![Batas x ketika x mendekati tak terhingga](powerpoint-math-equations_8.png)

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

Untuk nama fungsi kustom, jadikan nama fungsi sebagai elemen saat ini dan panggil [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/) dengan argumennya:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **Tambahkan Operator N-ary dan Integral**

Gunakan [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/nary/) untuk penjumlahan, unifikasi, interseksi, dan operator besar lainnya. Gunakan [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) untuk integral. Kedua metode memungkinkan Anda mengatur batas bawah dan atas.

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

Operator N-ary digunakan untuk operator besar dengan batas opsional. Operator sederhana seperti `+`, `-`, dan `=` biasanya ditambahkan sebagai [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) dan digabungkan ke dalam ekspresi.

Untuk integral, gunakan [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/):

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Tambahkan Matriks**

Gunakan [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) untuk baris dan kolom. Matriks secara default tidak menyertakan kurung, jadi balut matriks dengan tanda kurung, kurung siku, atau kurung kurawal bila diperlukan.

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

### **Sunting Matriks yang Ada**

Misalkan pelajaran aljabar linear dimulai dengan matriks koefisien dalam `matrix.pptx`, yang disimpan oleh contoh sebelumnya. Untuk latihan berikutnya, pertahankan persamaan pertama, ganti yang kedua dengan dua persamaan baru, dan revisi himpunan variabel. Akses matriks yang ada sebagai [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) untuk mempertahankan koefisien yang masih berlaku.

![Matriks koefisien dua baris asli dengan entri 1, x, dan satu sel kosong pada baris pertama serta x, 2, dan y pada baris kedua](matrix-before-edit.png)

Baris dan kolom indeks dimulai dari nol dan merujuk pada matriks pada setiap pemanggilan. Menyisipkan baris sebelum indeks 1 memindahkan baris kedua asli ke indeks 2. Menyisipkan setelah indeks 2 kemudian menambahkan satu baris. Menghapus baris 2 menghapus persamaan kedua asli dan memindahkan baris yang ditambahkan naik satu posisi. Kolom bergeser dengan cara yang sama.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation("matrix.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    portion = shape.text_frame.paragraphs[0].portions[0]
    matrix = portion.math_paragraph[0][0]

    matrix.insert_row_before(1)
    matrix.insert_row_after(2)
    matrix.delete_row(2)

    matrix.insert_column_before(1)
    matrix.insert_column_after(3)
    matrix.delete_column(3)

    matrix[1, 0] = math.MathematicalText("12")
    matrix[1, 1] = math.MathematicalText("1")
    matrix[2, 2] = math.MathematicalText("10")
    matrix[2, 3] = math.MathematicalText("1")
    for row in range(matrix.row_count):
        for column in range(matrix.column_count):
            if matrix[row, column] is None:
                matrix[row, column] = math.MathematicalText("0")

    matrix.set_column_alignment(0, math.MathHorizontalAlignment.LEFT)
    matrix.set_columns_alignment(1, 3, math.MathHorizontalAlignment.RIGHT)

    presentation.save("updated-matrix.pptx", slides.export.SaveFormat.PPTX)
```

[set_column_alignment](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/set_column_alignment/) menyelaraskan kolom pertama ke kiri. [set_columns_alignment](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/set_columns_alignment/) menyelaraskan tiga kolom berurutan ke kanan, mulai dari indeks 1. Dalam `updated-matrix.pptx`, matriks memiliki tiga persamaan dan empat variabel. Koefisien baris pertama asli `1` dan `x` kini muncul di kolom pertama dan ketiga.

![Matriks tiga baris yang diperbarui menampilkan baris 1, 0, x, 0; 12, 1, 0, 0; dan 0, 0, 10, 1](matrix-after-edit.png)

## **Tambahkan Array Persamaan**

Gunakan [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_math_array/) ketika Anda membutuhkan persamaan yang sejajar atau tumpukan vertikal ekspresi.

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

### **Menyelaraskan Array dengan Elemen Sekitar**

[MathArray.base_justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/base_justification/) mengontrol perataan vertikal array relatif terhadap elemen matematika di sampingnya. Contoh di bawah membandingkan perataan dengan baris pertama, tengah array, dan baris terakhir.

Contoh berikut membuat tiga array identik, masing‑masing tiga baris dan elemen tetangga `A=` serta `=B`. Semua teks matematika menggunakan Cambria Math ukuran 24 poin. Hanya perataan array yang berubah.

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

Perbandingan berikut menunjukkan presentasi yang disimpan di PowerPoint. Perhatikan posisi `A=` dan `=B` di sebelah masing‑masing array.

![Array persamaan di PowerPoint dengan perataan Atas, Tengah, dan Bawah serta elemen tetangga yang identik](equation-array-alignment.png)

### **Konfigurasi Jarak Baris**

[row_spacing_rule](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/row_spacing_rule/) memilih aturan jarak untuk baris dalam array. [row_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/row_spacing/) memberikan nilai numerik untuk aturan jarak eksplisit dan diabaikan oleh aturan preset.

Untuk jarak tepat, nilai diukur dalam poin. Untuk jarak proporsional, diukur dalam setengah baris: nilai `3` pada contoh berarti 1,5 baris. Tetapkan kedua properti saat menentukan nilai eksplisit; mengubah nilai numerik saja tidak memilih aturan jarak.

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

Jarak baris array terpisah dari jarak paragraf. [space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) dan [space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/) menambah ruang di sekitar paragraf yang membungkus, bukan di antara baris array. Demikian pula, [MathParagraph.justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/justification/) memposisikan seluruh paragraf matematika secara horizontal; ini tidak menggantikan pengaturan perataan vertikal array.

## **Tambahkan Fungsi Trigonometri**

Gunakan [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) ketika argumen adalah elemen saat ini dan nama fungsi sudah diketahui.

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

Gunakan pembantu subskrip dan superskrip untuk indeks dan pangkat. Ketika indeks harus muncul di sisi kiri basis, gunakan [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_sub_superscript_on_the_left/).

![Huruf Y kapital dengan subskrip 1 di sisi kiri dan superskrip n](powerpoint-math-equations_9.png)

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

Gunakan [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/enclose/) untuk menempatkan ekspresi di dalam pembatas. Anda juga dapat menetapkan karakter pemisah untuk ekspresi pembatas yang berisi beberapa elemen.

![Ekspresi pembatas yang berisi x, y, dan z dipisahkan oleh bar vertikal](powerpoint-math-equations_13.png)

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

Setel [grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/grow_to_match_operand_height/) ke `True` agar tanda kurung tumbuh di sekitar operand tinggi, atau ke `False` agar tetap pada ukuran normal. [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/delimiter_shape/) menerima salah satu dari dua nilai [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/). `CENTERED` menempatkan tanda kurung di tengah sumbu matematika, yang melintasi tengah tanda sama dengan. `MATCH` menyelaraskan tanda kurung dengan konten yang dibungkus. Kedua pengaturan hanya memengaruhi pembatas. Ekspresi di dalam tetap sama.

Contoh menempatkan pecahan pada eksponen `x` sehingga ekspresi memanjang lebih tinggi di atas garis dasar daripada di bawahnya. Semua empat persamaan menggunakan tanda kurung dan pengaturan font yang sama.

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

Di PowerPoint, bandingkan baris‑baris untuk melihat efek pertumbuhan. Pada baris atas, tanda kurung tumbuh menutupi eksponen dan tampak serupa untuk kedua bentuk. Pada baris bawah, pertumbuhan dimatikan. Tanda kurung kecil di kiri (`CENTERED`) sejajar dengan tanda sama dengan, sementara yang di kanan (`MATCH`) berada lebih tinggi di sekitar ekspresi.

![Empat persamaan di PowerPoint dengan pertumbuhan pembatas diaktifkan di atas dan dinonaktifkan di bawah, serta Centered di kiri dan Match di kanan](delimiter-sizing.png)

## **Tambahkan Kotak Bingkai**

Panggil [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_border_box/) pada sebuah pecahan untuk membingkai seluruh ekspresi. [MathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/) yang dikembalikan menampilkan keempat sisi secara default. Gunakan [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_top/), [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_bottom/), [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_left/), dan [hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_right/) untuk menghapus sisi tertentu.

Contoh menempatkan enam salinan pecahan yang sama pada satu slide. Untuk menunjukkan pembatalan, sembunyikan keempat sisi dan atur [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_bottom_left_to_top_right/) untuk diagonal naik (↗) atau [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_top_left_to_bottom_right/) untuk diagonal turun (↘). Anda juga dapat menggunakan [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_horizontal/) atau [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_vertical/) dengan kombinasi sisi yang terlihat.

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

![Enam pecahan dapat diedit di PowerPoint. Baris atas: bingkai penuh, sisi bawah dan kiri, diagonal naik. Baris bawah: diagonal turun, garis horizontal, garis vertikal dengan bingkai penuh.](border-box-fractions.png)

Pada pecahan ini, garis horizontal menutupi garis pecahan. Garis vertikal melintasi pembilang dan penyebut sekaligus sementara bingkai di sekeliling tetap terlihat. Garis‑garis ini menghias seluruh ekspresi. Coret teks biasa hanya berlaku pada karakter dalam satu run teks. Setelah membuka kembali presentasi di PowerPoint, Anda masih dapat menyunting pembilang dan penyebut secara terpisah.

## **Kontrol Visibilitas dan Tata Letak dengan Elemen Phantom**

Balut sebuah ekspresi dengan [MathPhantom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/) untuk mengontrol visibilitasnya serta ruang yang disumbangkannya pada persamaan secara terpisah. Properti‑nya mengontrol hal berikut:

| Property | Effect |
| --- | --- |
| [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/show/) | Atur ke `False` untuk menyembunyikan ekspresi. Dimensinya tetap berkontribusi pada tata letak kecuali properti terkait di bawah diatur ke `True`. |
| [zero_width](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_width/) | Perlakukan lebar horizontal ekspresi sebagai nol, memungkinkan elemen tetangga mendekat. |
| [zero_asc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_asc/) | Perlakukan ascent‑nya (tinggi di atas garis dasar) sebagai nol. Ini dapat mengurangi ruang yang dicadangkan di atas elemen tetangga. |
| [zero_desc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_desc/) | Perlakukan descent‑nya (kedalaman di bawah garis dasar) sebagai nol. Ini dapat memindahkan batang pecahan atau konten lain di bawah ekspresi lebih dekat ke tetangganya. |

Garis dasar adalah garis referensi tempat huruf‑huruf matematika biasa berbaris. Menyembunyikan konten tidak menghapus dimensinya, dan memperlakukan suatu dimensi sebagai nol tidak menghapus ekspresi. Ekspresi dasar tetap tersedia melalui [base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/base/). Atur [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/show/) kembali ke `True` untuk menampilkannya lagi; pengaturan dimensi tetap tidak berubah.

Contoh di bawah menciptakan lima varian berdampingan: sebuah pecahan terlihat, pecahan tersembunyi yang menahan ruang, dan tiga pecahan tersembunyi dengan satu dimensi diperlakukan sebagai nol. Setiap varian menggunakan ekspresi di sekitarnya yang sama serta Cambria Math ukuran 24 poin. Semua shape persamaan memiliki posisi atas yang sama, ditandai oleh panduan abu‑abu. Menempatkan phantom pada pembilang pecahan luar memudahkan melihat perubahan tata letak vertikal.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def create_text(value):
    text = math.MathematicalText(value)
    text.format.font_height = 24
    text.format.latin_font = slides.FontData("Cambria Math")
    return text


with slides.Presentation() as presentation:
    presentation.slide_size.set_size(1000, 180, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]
    labels = ["Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc"]

    guide = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 10, 60, 980, 0)
    guide.line_format.fill_format.fill_type = slides.FillType.SOLID
    guide.line_format.fill_format.solid_fill_color.color = slides.Color.light_gray

    for i, label_text in enumerate(labels):
        left = 10 + i * 200
        label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, left, 10, 190, 30)
        label.fill_format.fill_type = slides.FillType.NO_FILL
        label.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        label.text_frame.text = label_text
        label_format = label.text_frame.paragraphs[0].portions[0].portion_format
        label_format.font_height = 14
        label_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.fill_format.solid_fill_color.color = slides.Color.black

        fraction_numerator = create_text("a+b")
        fraction_denominator = create_text("c+d")
        fraction = math.MathFraction(fraction_numerator, fraction_denominator)
        phantom = math.MathPhantom(fraction)
        phantom.show = i == 0
        phantom.zero_width = i == 2
        phantom.zero_asc = i == 3
        phantom.zero_desc = i == 4

        left_text = create_text("x+")
        right_text = create_text("+y")
        numerator = math.MathBlock(left_text).join(phantom).join(right_text)
        denominator = create_text("z")
        equation = math.MathFraction(numerator, denominator)

        shape = slide.shapes.add_math_shape(left, 60, 190, 100)
        shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        math_paragraph = shape.text_frame.paragraphs[0].portions[0].math_paragraph
        math_paragraph.add(math.MathBlock(equation))

    presentation.save("math-phantom.pptx", slides.export.SaveFormat.PPTX)
```

![Lima persamaan di PowerPoint membandingkan pecahan terlihat, pecahan tersembunyi yang menahan ruang, dan pecahan tersembunyi dengan ZeroWidth, ZeroAsc, atau ZeroDesc diaktifkan](math-phantom.png)

## **Kelompokkan Istilah**

Gunakan [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/group/) untuk menempatkan karakter pengelompokan di atas atau di bawah sebuah ekspresi. Tambahkan batas untuk memberi label pada istilah‑istilah yang dikelompokkan.

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

Gunakan pembantu format hanya di tempat yang memperjelas rumus. Misalnya, [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/overbar/) menempatkan sebuah bar di atas elemen matematika.

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

Untuk memformat teks di seluruh persamaan yang ada, telusuri setiap pohon elemen blok matematika. [MathElementBase.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/get_children/) mengembalikan hanya anak‑anak langsung, sehingga panggil secara rekursif untuk mencapai teks di dalam pecahan, skrip, radikal, dan struktur bersarang lainnya. Periksa elemen saat ini serta anak‑nya untuk menyertakan elemen awal bila itu adalah [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/).

Contoh ini mengasumsikan bahwa `input.pptx` berisi persamaan seperti `z = xᵢ / ∛y`, dengan pecahan yang memuat subskrip di pembilangnya dan radikal di penyebutnya. Memproses hanya elemen‑elemen tingkat atas blok akan melewatkan teks di dalam pecahan. Contoh menemukan bagian‑bagian matematika dalam frame teks slide, mengakses blok‑blaknya melalui [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), dan menetapkan [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) ke 28 poin melalui properti [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) masing‑masing elemen teks.

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

Presentasi yang disimpan berisi format teks yang diperbarui di setiap tingkat masing‑masing persamaan yang diproses, sambil mempertahankan konten teks dan struktur matematika.

## **Referensi Cepat**

| Tugas | API Utama |
| --- | --- |
| Buat teks matematika | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Gabungkan elemen | [MathElementBase.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/join/) |
| Buat pecahan | [MathElementBase.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/divide/) |
| Tambahkan superskrip atau subskrip | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_subscript/) |
| Tambahkan fungsi | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) |
| Tambahkan radikal | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/radical/) |
| Tambahkan batas | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_upper_limit/) |
| Tambahkan skrip sisi kiri | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_sub_superscript_on_the_left/) |
| Tambahkan penjumlahan dan integral | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) |
| Tambahkan matriks | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| Tambahkan array persamaan | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_math_array/) |
| Tambahkan pembatas | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/enclose/) |
| Tambahkan bar dan bingkai | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_border_box/) |
| Kelompokkan istilah | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/group/) |

## **Tanya Jawab**

**Apakah saya dapat menyunting persamaan PowerPoint yang ada?**

Ya. Buka presentasi, temukan shape yang berisi [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), dapatkan [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), dan perbarui blok‑blok matematika dalam paragraf tersebut.

**Apakah persamaan disimpan sebagai matematika PowerPoint yang dapat diedit?**

Ya. Saat Anda menyimpan ke PPTX, Aspose.Slides menuliskan persamaan sebagai konten Office math yang dapat diedit.

**Apakah saya dapat mengekspor persamaan ke LaTeX?**

Ya. Dapatkan [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) persamaan dari [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), lalu panggil [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) untuk mengekspornya langsung. Untuk contoh lengkap, lihat [Ekspor Persamaan Matematika dari Presentasi di Python via .NET](/slides/id/python-net/exporting-math-equations/#export-math-equations-to-latex).