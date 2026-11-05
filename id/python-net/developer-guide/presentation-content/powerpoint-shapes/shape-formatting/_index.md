---
title: Format Bentuk PowerPoint di Python
linktitle: Pemformatan Bentuk
type: docs
weight: 20
url: /id/python-net/shape-formatting/
keywords:
- format bentuk
- format garis
- efek sketsa
- garis bentuk sketsa
- format gaya sambungan
- isian gradasi
- isian pola
- isian gambar
- isian tekstur
- isian warna padat
- transparansi bentuk
- render bentuk hitam-putih
- render bentuk skala abu-abu
- putar bentuk
- efek bevel 3D
- efek rotasi 3D
- atur ulang pemformatan
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara memformat bentuk PowerPoint di Python menggunakan Aspose.Slides—atur isian, garis, dan gaya efek untuk file PPT, PPTX, dan ODP dengan presisi dan kontrol penuh."
---
## **Pendahuluan**

Format bentuk di PowerPoint dengan menyesuaikan outline, isian, dan efeknya. Aspose.Slides for Python via .NET memungkinkan Anda mengontrol pengaturan ini secara programatis, termasuk transparansi, rotasi, dan format 3D.

![Shape formatting options in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python via .NET menyediakan kelas dan properti yang memungkinkan Anda memformat bentuk menggunakan opsi yang sama dengan yang tersedia di PowerPoint.

## **Format Garis**

Gunakan [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) untuk mengontrol outline sebuah bentuk. Contoh ini membuat persegi panjang tanpa isian dengan outline biru bergaris putus-putus. [LineFormat.style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/style/) memilih garis gabungan tebal-tipis, sementara [LineFormat.width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) mengatur lebarnya menjadi 7 poin dan [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) memilih pola dash.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![The formatted lines in the presentation](formatted-lines.png)

### **Tetapkan Pola Dash Garis Kustom**

Gunakan [LineFormat.custom_dash_pattern](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/custom_dash_pattern/) ketika gaya garis bawaan tidak menyediakan panjang dash dan celah yang Anda butuhkan, misalnya untuk outline bermerek atau diagram teknis. Menetapkan pola secara otomatis mengatur [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) ke [LineDashStyle.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/).

Entri daftar bergantian antara panjang dash dan celah, dimulai dengan dash. Setiap nilai merupakan kelipatan lebar garis: `[4, 2]` pada lebar 3 poin menghasilkan dash 12 poin diikuti celah 6 poin. Gunakan pasangan nilai hingga, tidak negatif untuk mendefinisikan segmen dash‑dan‑celah lengkap. Contoh ini menggunakan nilai positif agar setiap dash dan celah terlihat.

Contoh ini membuat lima garis biru dengan panjang yang sama dan cap datar. Tiga pertama membandingkan pola pada lebar 3 poin. Yang keempat mengulangi pola pertama dengan lebar dua kali lipat, menggandakan panjang dash dan celah. Yang kelima beralih dari pola kustom ke garis padat.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(600, 300, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 50 + i * 50, 500, 0)
        line.line_format.width = 6 if i == 3 else 3
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.cap_style = slides.LineCapStyle.FLAT
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.custom_dash_pattern = pattern

    # Kembalikan garis terakhir ke gaya padat.
    slide.shapes[4].line_format.dash_style = slides.LineDashStyle.SOLID

    presentation.save("custom_dash_patterns.pptx", slides.export.SaveFormat.PPTX)
```

Untuk kembali ke gaya dash bawaan, tetapkan [LineDashStyle.DASH](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) ke [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/). Gaya yang dipilih mengontrol tampilan garis.

Hasilnya di PowerPoint, dari atas ke bawah: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; dan **Solid, 3 pt**.

![Three custom dash patterns, a wider line using the first pattern, and a solid line in PowerPoint](custom-dash-patterns.png)

### **Tetapkan Cap Garis**

Gunakan [LineFormat.cap_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/cap_style/) untuk mengatur ujung garis terbuka. Enumerasi [LineCapStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linecapstyle/) menyediakan tiga gaya cap eksplisit:

- `FLAT`: Stroke berhenti pada titik akhir.
- `ROUND`: Cap setengah lingkaran memanjang di luar titik akhir sebesar setengah lebar garis.
- `SQUARE`: Cap kotak memanjang di luar titik akhir sebesar setengah lebar garis.

Enumerasi juga mencakup `NOT_DEFINED`, yang berarti tidak ada gaya cap yang secara eksplisit ditetapkan.

Cap berbeda dari anak panah, yang menambahkan simbol pada ujung garis, dan sambungan, yang mengontrol sudut antara segmen garis. Contoh ini menonaktifkan anak panah melalui [LineFormat.begin_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/begin_arrowhead_style/) dan [LineFormat.end_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/end_arrowhead_style/) sehingga hanya bentuk cap yang dibandingkan.

Contoh berikut membuat tiga garis horizontal yang pada dasarnya identik, lebar 20 poin. Dari atas ke bawah, mereka menggunakan cap datar, bulat, dan kotak. Titik akhir mereka memiliki koordinat horizontal yang sama; cap bulat dan kotak memanjang 10 poin di luar setiap titik akhir.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 240, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    cap_styles = [slides.LineCapStyle.FLAT, slides.LineCapStyle.ROUND, slides.LineCapStyle.SQUARE]

    for i, cap_style in enumerate(cap_styles):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 100, 50 + i * 70, 300, 0)
        line.line_format.width = 20
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.dash_style = slides.LineDashStyle.SOLID
        line.line_format.cap_style = cap_style
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE

    presentation.save("line_caps.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya di PowerPoint, dari atas ke bawah: **Flat**, **Round**, dan **Square**.

![Flat, round, and square caps on identical thick lines in PowerPoint](line-caps.png)

## **Terapkan Efek Sketch pada Garis Bentuk**

Efek sketch membuat garis bentuk terlihat seperti digambar tangan. Gunakan [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) untuk mengakses pengaturan garis, [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) untuk mengakses pengaturan sketch, dan [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) untuk memilih nilai dari enumerasi [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/).

Kode Python berikut menunjukkan cara menerapkan efek [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/), membaca nilai yang ditetapkan secara eksplisit, dan menghapus efek dengan [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    sketch_format = shape.line_format.sketch_format
    sketch_format.sketch_type = slides.LineSketchType.CURVED
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

Nilai yang dikembalikan oleh [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) mewakili pengaturan yang ditetapkan langsung pada bentuk. Jika format garis dapat diwarisi dari tema, master slide, atau layout slide, gunakan [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/), akses [ILineFormatEffectiveData.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/sketch_format/), dan baca [ISketchFormatEffectiveData.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/isketchformateffectivedata/sketch_type/). Nilai efektif mencerminkan format yang sebenarnya diterapkan setelah pewarisan diselesaikan. Contoh ini memerlukan presentasi yang sudah ada dengan setidaknya satu bentuk pada slide pertama dan mencetak kedua nilai:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    line_format = shape.line_format
    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **Format Gaya Sambungan**

Berikut tiga opsi tipe sambungan:

* Round
* Miter
* Bevel

Gaya sambungan mengontrol bagaimana dua segmen outline bertemu di sudut. Gunakan **Round** untuk sudut melengkung, **Miter** untuk sudut tajam, atau **Bevel** untuk sudut rata.

![The join style in the presentation](join-style-powerpoint.png)

Contoh ini membuat tiga persegi panjang hitam dengan outline biru lebar 15 poin. Ia menetapkan [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) ke nilai miter, bevel, dan round dari [LineJoinStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/), masing‑masing, untuk membandingkan cara sudut digambar.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    miter_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
    bevel_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
    round_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

    miter_shape.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.fill_format.solid_fill_color.color = draw.Color.black
    bevel_shape.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.fill_format.solid_fill_color.color = draw.Color.black
    round_shape.fill_format.fill_type = slides.FillType.SOLID
    round_shape.fill_format.solid_fill_color.color = draw.Color.black

    miter_shape.line_format.width = 15
    bevel_shape.line_format.width = 15
    round_shape.line_format.width = 15

    miter_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    bevel_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    round_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    round_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    miter_shape.line_format.join_style = slides.LineJoinStyle.MITER
    bevel_shape.line_format.join_style = slides.LineJoinStyle.BEVEL
    round_shape.line_format.join_style = slides.LineJoinStyle.ROUND

    miter_shape.text_frame.text = "Miter Join Style"
    bevel_shape.text_frame.text = "Bevel Join Style"
    round_shape.text_frame.text = "Round Join Style"

    presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

### **Batasi Sambungan Miter pada Sudut Tajam**

Gunakan [LineFormat.miter_limit](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/miter_limit/) dengan [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) yang ditetapkan ke [LineJoinStyle.MITER](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) untuk membatasi seberapa jauh sudut tajam dapat memperluas.

Batasnya adalah rasio antara jarak sudut dalam dan luar sambungan terhadap lebar garis. Misalnya, nilai `8` mengizinkan panjang miter hingga delapan kali lebar garis; itu bukan ukuran dalam poin. Jika sudut melebihi batas, PowerPoint menggunakan sambungan bevel pada sudut tersebut. Batas yang lebih besar memungkinkan titik yang lebih tajam. Pengaturan ini hanya memengaruhi sambungan miter, dan mengubahnya tidak memberikan efek terlihat ketika sudut tetap berada dalam kedua batas.

Contoh ini membuat dua segitiga tanpa isian yang identik dengan outline lebar 20 poin. Segitiga kiri menggunakan batas `2`, dan yang kanan `8`. Setiap segitiga berukuran 80 poin lebar dan 160 poin tinggi, memberikan rasio panjang miter terhadap lebar garis sekitar `4.12`. Akibatnya, PowerPoint memberi bevel pada puncak kiri dan mempertahankan puncak kanan.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 320, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 90 + i * 240, 110, 80, 160)
        triangle.fill_format.fill_type = slides.FillType.NO_FILL
        triangle.line_format.width = 20
        triangle.line_format.fill_format.fill_type = slides.FillType.SOLID
        triangle.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        triangle.line_format.join_style = slides.LineJoinStyle.MITER
        triangle.line_format.miter_limit = miter_limit

    presentation.save("miter_limits.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya di PowerPoint: **Miter limit 2** di kiri dan **miter limit 8** di kanan.

![A beveled apex with miter limit 2 and a pointed apex with miter limit 8 in PowerPoint](miter-limits.png)

## **Isian Gradasi**

Isian gradasi mencampur warna di seluruh bentuk. Contoh ini mengisi elips dengan gradasi linear pada sudut 45 derajat dari merah ke ungu menggunakan [FillFormat.gradient_format](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/gradient_format/). Metode [GradientStopCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/gradientstopcollection/add/) menempatkan penghenti warna pada 0 dan 1, awal dan akhir gradasi. Menghapus penghenti yang ada memastikan hanya dua warna ini yang digunakan.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
    shape.fill_format.gradient_format.linear_gradient_angle = 45
    shape.fill_format.gradient_format.gradient_stops.clear()
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0.0, slides.PresetColor.RED)

    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![The ellipse with gradient fill](gradient-fill.png)

Jika gradasi terlihat berbeda dalam gambar yang diekspor dibandingkan di PowerPoint, lihat [Choose a Gradient Rendering Style](/slides/id/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Anda dapat memilih gaya render tanpa mengubah isian gradasi yang disimpan dalam presentasi.

### **Tetapkan Sudut Gradasi Linear**

Gunakan [GradientFormat.linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/) untuk mengontrol orientasi isian [GradientShape.LINEAR](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/). Sudut diukur dalam derajat dan bertambah searah jarum jam: `0` dari kiri ke kanan, `90` dari atas ke bawah, `180` dari kanan ke kiri, dan `270` dari bawah ke atas. Sudut pecahan didukung. Sudut finite di luar `[0, 360)` dinormalisasi menjadi satu revolusi; misalnya, `-45` menjadi `315` dan `360` menjadi `0`.

Contoh ini membuat enam persegi panjang dengan penghenti warna merah, hijau, dan biru yang identik pada posisi `0`, `0.5`, dan `1`. Skala dinonaktifkan sehingga sudut dapat dibandingkan terlepas dari proporsi persegi panjang. Sudut‑sudut, dari kiri ke kanan, adalah `0`, `45`, dan `90` pada baris pertama, serta `135`, `180`, dan `270` pada baris kedua.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 200, 150)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.FALSE
        gradient.linear_gradient_angle = angle

    presentation.save("linear_gradient_angles.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya di PowerPoint:

![Linear gradients at 0, 45, and 90 degrees in the top row, and 135, 180, and 270 degrees in the bottom row](linear-gradient-angles.png)

### **Skalakan Gradasi Linear dengan Bentuk**

[GradientFormat.linear_gradient_scaled](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_scaled/) menerima nilai [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/). Tetapkan secara eksplisit ke `FALSE` untuk mempertahankan sudut geometris gradasi saat proporsi bentuk berubah, atau ke `TRUE` untuk menskalakan gradasi bersama lebar dan tinggi bentuk. Dengan skala diaktifkan, sudut yang terlihat dapat berbeda dari sudut yang ditetapkan pada bentuk yang tidak berbentuk persegi.

Contoh berikut menggunakan sudut `45`‑derajat dan penghenti warna yang sama seperti perbandingan sudut. Kolom kiri menggunakan `FALSE`; kolom kanan menggunakan `TRUE`. Setiap kolom berisi persegi panjang lebar di atas persegi panjang tinggi. Keduanya memulai dengan dimensi lebar yang sama; mengubah lebar dan tinggi persegi panjang kedua menunjukkan cara isian merespon perubahan ukuran tanpa mengubah pengaturan gradasinya.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 460, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    scaling_options = [slides.NullableBool.FALSE, slides.NullableBool.TRUE]

    for column, scaling in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 300, 90)
            shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
            shape.fill_format.fill_type = slides.FillType.GRADIENT

            gradient = shape.fill_format.gradient_format
            gradient.gradient_shape = slides.GradientShape.LINEAR
            gradient.gradient_stops.clear()
            gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
            gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
            gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
            gradient.linear_gradient_angle = 45
            gradient.linear_gradient_scaled = scaling

            if row == 1:
                shape.width = 90
                shape.height = 280

    presentation.save("linear_gradient_scaling.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya di PowerPoint, dengan skala dinonaktifkan di kiri dan diaktifkan di kanan:

![Wide and tall rectangles with a 45-degree gradient, comparing linear_gradient_scaled FALSE on the left with TRUE on the right](linear-gradient-scaling.png)

Dengan skala dinonaktifkan, pita warna diagonal mempertahankan orientasi yang sama pada kedua persegi panjang. Dengan skala diaktifkan, pita-pita tersebut meregang mengikuti proporsi bentuk. Ini membantu mereproduksi gradasi templat saat menyesuaikan bentuk ke ukuran lain. Pada bentuk persegi, mengaktifkan skala tidak mengubah tampilan gradasi `45`‑derajat ini.

Baik sudut maupun pengaturan skala berlaku untuk gradasi linear. Mereka tidak mengontrol isian [GradientShape.RADIAL or GradientShape.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/).

### **Gabungkan Sudut dengan Arah Gradasi**

[GradientFormat.gradient_direction](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/gradient_direction/) memilih gaya gradasi dari enumerasi [GradientDirection](https://reference.aspose.com/slides/python-net/aspose.slides/gradientdirection/); ini bukan pengganti sudut numerik. Untuk gradasi linear, gaya sudut dapat mengubah area distribusi warna tanpa mengubah [linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/). Jaga arah tetap tidak berubah saat membandingkan sudut atau skala.

Contoh berikut menerapkan pengaturan yang sama tetapi dalam urutan yang berlawanan. Kedua persegi panjang memiliki tampilan yang sama: menetapkan arah sebelum atau sesudah sudut tidak mengubah hasil.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    for i in range(2):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30 + i * 140, 320, 100)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.TRUE

        if i == 0:
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1
            gradient.linear_gradient_angle = 30
        else:
            gradient.linear_gradient_angle = 30
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1

    presentation.save("linear_gradient_direction.pptx", slides.export.SaveFormat.PPTX)
```

## **Isian Pola**

Isian pola menerapkan desain dua warna, seperti titik, garis, atau kotak-kotak. Contoh ini menggunakan [PatternFormat.pattern_style](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/pattern_style/) untuk memilih pola trellis. [PatternFormat.back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) memberikan latar belakang abu‑abu muda, dan [PatternFormat.fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) memberikan warna kuning pada pola.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.PATTERN
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![The rectangle with pattern fill](pattern-fill.png)

## **Isian Gambar**

Isian gambar menggunakan gambar di dalam bentuk. Contoh ini memerlukan gambar lokal dan menggunakan [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) untuk memuatnya ke dalam koleksi gambar presentasi. Menetapkan [PictureFillFormat.picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) ke mode ubin mengulangi gambar di dalam persegi panjang. Gambar sumber yang digunakan ditampilkan di bawah:

![The lotus picture](lotus.png)

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 255, 130)
    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![The shape with picture fill](picture-fill.png)

### **Ubin Gambar Sebagai Tekstur**

Jika Anda ingin mengatur gambar ubin sebagai tekstur dan menyesuaikan perilaku ubin, Anda dapat menggunakan properti berikut dari kelas [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Menetapkan mode isian gambar—`TILE` atau `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): Menentukan perataan ubin dalam bentuk.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): Mengontrol apakah ubin dibalik secara horizontal, vertikal, atau keduanya.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): Menetapkan offset horizontal ubin (dalam poin) dari asal bentuk.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): Menetapkan offset vertikal ubin (dalam poin) dari asal bentuk.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): Mendefinisikan skala horizontal ubin sebagai persentase.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): Mendefinisikan skala vertikal ubin sebagai persentase.

Contoh ini memerlukan gambar lokal dan mengonfigurasi [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) untuk mengulangnya pada 50% ukuran aslinya. Offset −32 poin menggeser ubin secara horizontal dan vertikal; perataan kanan‑bawah dan pembalikan kedua arah menentukan bagaimana tekstur berulang disusun.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]

    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)
    shape.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![The tile options](tile-options.png)

## **Isian Warna Padat**

Isian padat memberikan bentuk satu warna seragam. Contoh ini menetapkan [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) ke mode isian padat dan menetapkan kuning melalui [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/), kemudian menyimpan persegi panjang dalam presentasi.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![The shape with solid color fill](solid-color-fill.png)

### **Salin Warna Sambil Mempertahankan Referensi Tema**

Gunakan [ColorFormat.copy_from](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/copy_from/) untuk menyalin definisi warna, termasuk tipe warna, referensi tema, dan transformasi. Ini berguna saat memindahkan warna isian antara bentuk yang harus tetap mengikuti tema presentasi. Metode ini menyalin hanya warna: tidak menyalin tipe isian, outline, atau format bentuk lainnya. Tetapkan [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) tujuan secara eksplisit.

Contoh ini membuat tiga persegi panjang, dari kiri ke kanan: sumber, salinan yang sadar tema, dan salinan RGB tetap. Sumber menggunakan [ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/) untuk merujuk ke warna aksen pertama dan menambahkan tint melalui [ColorOperationCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/coloroperationcollection/add/). Salinan RGB menggunakan warna isian efektif sumber sehingga ketiganya awalnya tampak identik. Menetapkan [ColorFormat.color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color/) menetapkan nilai RGB tetap dan menghapus semua transformasi warna yang ada.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(660, 220, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    presentation.master_theme.color_scheme.accent1.color = draw.Color.royal_blue

    source = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 40, 180, 140)
    theme_copy = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 240, 40, 180, 140)
    rgb_copy = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 450, 40, 180, 140)

    for shape in (source, theme_copy, rgb_copy):
        shape.fill_format.fill_type = slides.FillType.SOLID
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    source_color = source.fill_format.solid_fill_color
    source_color.scheme_color = slides.SchemeColor.ACCENT1
    source_color.color_transform.add(slides.ColorTransformOperation.TINT, 0.75)

    theme_copy.fill_format.solid_fill_color.copy_from(source_color)
    rgb_copy.fill_format.solid_fill_color.color = source.fill_format.get_effective().solid_fill_color

    with slide.get_image(1.0, 1.0) as before:
        before.save("color-copy-before.png", slides.ImageFormat.PNG)

    # Referensi tema mengikuti warna aksen baru; nilai RGB tetap tidak mengikutinya.
    presentation.master_theme.color_scheme.accent1.color = draw.Color.orange_red

    with slide.get_image(1.0, 1.0) as after:
        after.save("color-copy-after.png", slides.ImageFormat.PNG)
    presentation.save("copied_colors.pptx", slides.export.SaveFormat.PPTX)
```

Sebelum perubahan tema, ketiga isian cocok:

![Source, copy_from destination, and fixed RGB destination with identical blue fills](color-copy-before.png)

Setelah perubahan tema, sumber dan salinan yang sadar tema mengikuti warna aksen baru dan mempertahankan tintnya. Salinan RGB tetap biru:

![Source and copy_from destination with orange fills, while the fixed RGB destination remains blue](color-copy-after.png)

Definisi yang disalin bersifat independen dari sumber. Mengubah referensi tema sumber, menetapkan warna lain, atau menambah/menghapus transformasinya tidak mengubah tujuan. Perubahan tema tetap memengaruhi kedua bentuk karena masing‑masing merujuk ke warna tema yang sama.

Menyimpan dan membuka kembali PPTX mempertahankan [ColorFormat.color_type](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color_type/), referensi tema, dan koleksi [ColorFormat.color_transform](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color_transform/) pada warna yang disalin; tidak meratakan definisi menjadi RGB.

Saat menyalin antar konteks tema yang berbeda, seperti presentasi dengan palet aksen berbeda, referensi yang disalin diselesaikan terhadap tema tujuan. Referensi dan transformasi yang sama dapat menghasilkan warna yang terlihat berbeda. Lihat [Presentation Theme](/slides/id/python-net/presentation-theme/) untuk informasi lebih lanjut tentang mengonfigurasi warna tema.

## **Gunakan Latar Belakang Slide sebagai Isian Bentuk**

Gunakan [AutoShape.use_background_fill](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/use_background_fill/) ketika sebuah bentuk harus cocok dengan latar belakang slide, misalnya dalam templat presentasi. Tetapkan [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) ke [FillType.NOT_DEFINED](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) terlebih dahulu untuk menghapus isian eksplisit apa pun. Dengan kombinasi ini, bentuk menggunakan latar belakang slide alih‑alih isian gaya. Mengaktifkan flag saja tidak menghapus isian eksplisit yang ada.

Ini berbeda dari [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/): isian latar belakang menutupi objek di belakang bentuk dengan area latar belakang slide yang bersesuaian, sementara tanpa isian objek tetap terlihat. Gradasi tetap selaras dengan slide daripada dimulai kembali di dalam setiap bentuk.

Contoh berikut membuat latar belakang master yang diwarisi oleh slide dan menempatkan pita magenta di belakang tiga persegi panjang. Persegi panjang kiri menggunakan latar belakang, persegi panjang tengah tidak memiliki isian, dan persegi panjang kanan beralih dari isian latar belakang ke isian oranye eksplisit.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    # Warisi gradasi dari master.
    slide.background.type = slides.BackgroundType.NOT_DEFINED
    slide.layout_slide.background.type = slides.BackgroundType.NOT_DEFINED
    background = slide.layout_slide.master_slide.background
    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.GRADIENT
    gradient = background.fill_format.gradient_format
    gradient.gradient_shape = slides.GradientShape.LINEAR
    gradient.linear_gradient_angle = 0
    gradient.gradient_stops.clear()
    gradient.gradient_stops.add(0, draw.Color.dark_blue)
    gradient.gradient_stops.add(1, draw.Color.light_sky_blue)

    # Tambahkan objek ini terlebih dahulu sehingga muncul di belakang persegi panjang.
    band = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 25, 150, 670, 100)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.magenta
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    background_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 100, 160, 200)
    background_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    background_shape.use_background_fill = True

    no_fill_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 280, 100, 160, 200)
    no_fill_shape.fill_format.fill_type = slides.FillType.NO_FILL

    explicit_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 510, 100, 160, 200)
    explicit_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    explicit_shape.use_background_fill = True

    # Nonaktifkan isian latar belakang sebelum menerapkan isian eksplisit.
    explicit_shape.use_background_fill = False
    explicit_shape.fill_format.fill_type = slides.FillType.SOLID
    explicit_shape.fill_format.solid_fill_color.color = draw.Color.orange

    presentation.save("background_fill.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya, dari kiri ke kanan: **background fill**, **no fill**, dan **explicit fill**. Pita magenta tersembunyi oleh persegi panjang kiri dan kanan tetapi tetap terlihat melalui persegi panjang tengah.

![Background fill, no fill, and explicit orange fill over a magenta band](background-fill.png)

Perilaku yang sama berlaku untuk latar belakang yang didefinisikan langsung pada slide atau diwarisi dari layout. Bentuk menggunakan latar belakang slide yang telah diselesaikan; contoh ini membiarkan latar belakang slide dan layout tidak didefinisikan sehingga master yang menyediakannya.

## **Set Transparansi**

Untuk isian padat, komponen alfa warna mengontrol opasitas: 0 sepenuhnya transparan dan 255 sepenuhnya opak. Contoh ini menggunakan nilai alfa 128 untuk persegi panjang kuning, menjadikannya sekitar 50 % transparan sehingga persegi panjang di bawahnya tetap terlihat. Warna ditetapkan melalui [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/).

```python
import aspose.slides as slides
import aspose.pydrawing as draw

alpha = 128

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    solid_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    transparent_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    transparent_shape.fill_format.fill_type = slides.FillType.SOLID
    transparent_shape.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.yellow)

    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![The transparent shape](shape-transparency.png)

## **Putar Bentuk**

Gunakan [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) untuk memutar bentuk pada bidang slide. Sudut diukur dalam derajat; contoh ini memutar persegi panjang 5 derajat searah jarum jam dan menyimpan presentasi.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.rotation = 5

    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![The shape rotation](shape-rotation.png)

## **Tambahkan Efek Bevel 3D**

Gunakan [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) untuk memberi bentuk kedalaman dan tepi bevel. Contoh ini membuat elips hijau dengan outline oranye, menetapkan [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) ke 4 poin, dan menerapkan bevel atas melingkar dengan lebar dan tinggi 6 poin melalui [ThreeDFormat.bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/). Kamera ortografik menghadap depan dan pencahayaan tiga titik membuat bevel terlihat.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![The 3D bevel effect](3D-bevel-effect.png)

## **Tambahkan Efek Rotasi 3D**

Tampilan 3D bentuk dikontrol oleh pengaturan kamera. Contoh ini menggunakan [Camera.set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) dengan sudut lintang, bujur, dan revolusi masing‑masing 40, 35, dan 20 derajat. Ia memilih kamera isometrik melalui [Camera.camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) dan pencahayaan seimbang melalui [LightRig.light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/), kemudian menyimpan persegi panjang yang diformat.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![The 3D rotation effect](3D-rotation-effect.png)

## **Kontrol Rendering Hitam‑Putih untuk Bentuk**

Properti [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) menentukan bagaimana sebuah bentuk dirender ketika presentasi ditampilkan atau diproses dalam mode hitam‑putih. Ini tidak mengaktifkan tampilan hitam‑putih sendiri, dan tidak mengubah isian, garis, atau format lain bentuk dalam mode warna normal.

Gunakan nilai dari enumerasi [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) untuk memilih perilaku yang diinginkan. Misalnya, `AUTOMATIC` membiarkan aplikasi render memilih konversi, `GRAY` dan `LIGHT_GRAY` menggunakan warna abu‑abu, `BLACK_WHITE` hanya menggunakan hitam dan putih, `BLACK` dan `WHITE` memaksa satu warna, `COLOR` mempertahankan warna normal, dan `HIDDEN` menghilangkan bentuk dalam mode hitam‑putih. `NOT_DEFINED` berarti tidak ada mode tingkat bentuk yang ditetapkan.

Contoh ini membuat persegi panjang oranye dan menetapkan [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) ke abu‑abu. Bentuk yang disimpan mempertahankan isian oranye untuk tampilan warna normal dan meminta pewarnaan abu‑abu dari aplikasi yang menghormati pengaturan tampilan hitam‑putih:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

Dalam mode warna normal, persegi panjang mempertahankan isian oranye. Dalam alur kerja tampilan hitam‑putih, ia menggunakan warna abu‑abu karena mode‑nya diset ke `GRAY`. Ini memungkinkan Anda mempertahankan slide berwarna penuh sambil menentukan tampilan berbeda untuk pencetakan, pratinjau, atau alur kerja lain yang menghormati pengaturan tampilan hitam‑putih presentasi.

## **Atur Ulang Formatting**

Gunakan [Slide.reset](https://reference.aspose.com/slides/python-net/aspose.slides/slide/reset/) untuk memulihkan posisi, ukuran, dan format placeholder slide dari placeholder layout yang bersesuaian. Contoh ini memerlukan presentasi yang sudah ada dengan placeholder yang terhubung ke layout dan mengatur ulang setiap slide sebelum menyimpan. Bentuk tanpa placeholder layout yang bersesuaian tidak diatur ulang.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    for slide in presentation.slides:
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah pemformatan bentuk memengaruhi ukuran akhir file presentasi?**

Warna, gaya garis, dan pengaturan efek biasanya menambah data sedikit dibandingkan dengan gambar dan media yang disematkan. Isian gambar dapat meningkatkan ukuran file karena gambar mereka disimpan dalam presentasi.

**Bagaimana saya dapat mendeteksi bentuk pada slide yang memiliki format identik sehingga dapat dikelompokkan?**

Bandingkan setiap properti format utama bentuk—isian, garis, dan pengaturan efek. Jika semua nilai yang bersesuaian cocok, perlakukan gaya mereka sebagai identik dan kelompokkan bentuk‑bentuk tersebut secara logis, yang menyederhanakan manajemen gaya nanti.

**Dapatkah saya menyimpan sekumpulan gaya bentuk kustom ke file terpisah untuk digunakan kembali di presentasi lain?**

Ya. Simpan bentuk contoh dengan gaya yang diinginkan dalam deck slide templat atau file .POTX. Saat membuat presentasi baru, buka templat, kloning bentuk bergaya yang Anda perlukan, dan terapkan kembali formatnya di mana diperlukan.