---
title: Format Bentuk PowerPoint dalam Python via Java
linktitle: Pemformatan Bentuk
type: docs
weight: 20
url: /id/python-java/shape-formatting/
keywords:
- format bentuk
- format garis
- efek sketsa
- garis bentuk sketsa
- format gaya sambungan
- isian gradien
- isian pola
- isian gambar
- isian tekstur
- isian warna solid
- transparansi bentuk
- rendering bentuk hitam-putih
- rendering bentuk skala abu-abu
- putar bentuk
- efek bevel 3D
- efek rotasi 3D
- reset pemformatan
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Pelajari cara memformat bentuk PowerPoint dalam Python via Java menggunakan Aspose.Slides—tetapkan gaya isian, garis, dan efek untuk file PPT dan PPTX dengan presisi dan kontrol penuh."
---
## **Pendahuluan**

Format bentuk di PowerPoint dengan menyesuaikan garis tepi, isi, dan efeknya. Aspose.Slides for Python via Java memungkinkan Anda mengontrol pengaturan ini secara programatis, termasuk transparansi, rotasi, dan pemformatan 3D.

![Opsi pemformatan bentuk di PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python via Java menyediakan kelas dan metode yang memungkinkan Anda memformat bentuk menggunakan opsi yang sama dengan yang tersedia di PowerPoint.

## **Format Garis**

Gunakan [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) untuk mengontrol garis tepi sebuah bentuk. Contoh ini membuat persegi panjang tanpa isi dengan garis tepi biru, bergaris putus-putus. [LineFormat.setStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setStyle) memilih garis gabungan tebal-tipis, sementara [LineFormat.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) mengatur lebarnya menjadi 7 poin dan [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) memilih pola putus-putus.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hasilnya:

![Garis yang diformat dalam presentasi](formatted-lines.png)

### **Tetapkan Pola Garis Kustom**

Gunakan [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCustomDashPattern) saat gaya garis bawaan tidak menyediakan panjang dan celah yang Anda butuhkan, misalnya untuk garis tepi bermerek atau diagram teknis. Menetapkan pola secara otomatis mengubah gaya garis menjadi [LineDashStyle.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/).

Entri dalam array bergantian antara panjang dash dan celah, dimulai dengan dash. Setiap nilai merupakan kelipatan lebar garis: `[4, 2]` pada lebar 3 poin menghasilkan dash 12 poin diikuti celah 6 poin. Gunakan pasangan nilai hingga tak hingga, tidak negatif untuk mendefinisikan segmen dash‑dan‑celah lengkap. Contoh ini menggunakan nilai positif agar setiap dash dan celah terlihat.

Contoh ini membuat lima garis biru dengan panjang yang sama dan ujung datar. Tiga pertama membandingkan pola pada lebar 3 poin. Yang keempat mengulangi pola pertama dengan lebar dua kali, menggandakan panjang dash dan celah. Yang kelima beralih dari pola kustom ke garis solid.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, LineCapStyle, LineDashStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0)
        line.getLineFormat().setWidth(6 if i == 3 else 3)
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        line.getLineFormat().setCapStyle(LineCapStyle.Flat)
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setCustomDashPattern(jpype.JArray(jpype.JFloat)(pattern))

    # Kembalikan garis terakhir ke gaya solid.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid)

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Untuk kembali ke gaya dash bawaan, berikan [LineDashStyle.Dash](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) ke [LineFormat.setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle). Gaya yang dipilih mengontrol tampilan garis.

Hasil di PowerPoint, dari atas ke bawah: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; dan **Solid, 3 pt**.

![Tiga pola dash kustom, garis lebih lebar menggunakan pola pertama, dan garis solid di PowerPoint](custom-dash-patterns.png)

### **Tetapkan Ujung Garis**

Gunakan [LineFormat.setCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setCapStyle) untuk mengatur ujung garis terbuka. Kelas [LineCapStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linecapstyle/) menyediakan tiga gaya ujung eksplisit:

- `Flat`: Coretan berhenti pada titik akhir.
- `Round`: Ujung setengah lingkaran meluas melewati titik akhir sebesar setengah lebar garis.
- `Square`: Ujung persegi meluas melewati titik akhir sebesar setengah lebar garis.

Kelas ini juga mencakup `NotDefined`, yang berarti tidak ada gaya ujung yang ditetapkan secara eksplisit.

Ujung berbeda dari kepala panah, yang menambahkan simbol pada ujung garis, dan sambungan, yang mengontrol sudut antara segmen garis. Contoh ini menonaktifkan kepala panah melalui [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setBeginArrowheadStyle) dan [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setEndArrowheadStyle) sehingga hanya bentuk ujung yang dibandingkan.

Contoh berikut membuat tiga garis horizontal yang pada dasarnya identik, lebar 20 poin. Dari atas ke bawah, mereka menggunakan ujung flat, round, dan square. Titik akhir mereka memiliki koordinat horizontal yang sama; ujung round dan square meluas 10 poin di luar setiap titik akhir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, LineCapStyle, LineDashStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    cap_styles = [LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square]

    for i, cap_style in enumerate(cap_styles):
        line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0)
        line.getLineFormat().setWidth(20)
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        line.getLineFormat().setDashStyle(LineDashStyle.Solid)
        line.getLineFormat().setCapStyle(cap_style)
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None_)
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None_)

    presentation.save("line_caps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hasil di PowerPoint, dari atas ke bawah: **Flat**, **Round**, dan **Square**.

![Ujung flat, round, dan square pada garis tebal yang identik di PowerPoint](line-caps.png)

## **Terapkan Efek Sketsa pada Garis Bentuk**

Efek sketsa membuat garis bentuk terlihat seperti digambar tangan. Gunakan [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) untuk mengakses pengaturan garis, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) untuk mengakses pengaturan sketsa, dan [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) untuk memilih nilai dari kelas [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/).

Kode Python berikut menunjukkan cara menerapkan efek [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/), membaca nilai yang ditetapkan secara eksplisit, dan menghapus efek dengan [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LineSketchType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)

    sketch_format = shape.getLineFormat().getSketchFormat()
    sketch_format.setSketchType(LineSketchType.Curved)
    explicit_sketch_type = sketch_format.getSketchType()
    print("Explicit sketch type:", explicit_sketch_type)
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

Nilai yang dikembalikan oleh [SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) mewakili pengaturan yang langsung diterapkan pada bentuk. Jika pemformatan garis dapat diwarisi dari tema, master slide, atau layout slide, gunakan [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) dan baca jenis sketsa dari pemformatan garis efektif yang dikembalikan, seperti yang ditunjukkan di bawah. Nilai efektif mencerminkan pemformatan yang sebenarnya diterapkan setelah pewarisan diselesaikan. Contoh ini memerlukan presentasi yang sudah ada dengan setidaknya satu bentuk pada slide pertama dan mencetak kedua nilai:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    line_format = shape.getLineFormat()
    explicit_sketch_type = line_format.getSketchFormat().getSketchType()
    effective_line_format = line_format.getEffective()
    effective_sketch_type = effective_line_format.getSketchFormat().getSketchType()

    print("Explicit sketch type:", explicit_sketch_type)
    print("Effective sketch type:", effective_sketch_type)
finally:
    presentation.dispose()
```

## **Format Gaya Sambungan**

Berikut tiga pilihan tipe sambungan:

* Round
* Miter
* Bevel

Gaya sambungan mengontrol bagaimana dua segmen garis bertemu di sudut. Gunakan **Round** untuk sudut melengkung, **Miter** untuk sudut tajam, atau **Bevel** untuk sudut rata.

![Gaya sambungan dalam presentasi](join-style-powerpoint.png)

Contoh ini membuat tiga persegi panjang hitam dengan garis tepi biru lebar 15 poin. Ia menggunakan [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) untuk mengatur nilai miter, bevel, dan round pada [LineJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/), masing‑masing, untuk membandingkan bagaimana sudut digambar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Batasi Sambungan Miter pada Sudut Tajam**

Gunakan [LineFormat.setMiterLimit](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setMiterLimit) bersama [LineFormat.setJoinStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setJoinStyle) yang diatur ke [LineJoinStyle.Miter](https://reference.aspose.com/slides/python-java/aspose.slides/linejoinstyle/) untuk membatasi seberapa jauh sudut tajam dapat meluas.

Batasnya merupakan rasio antara jarak antara sudut dalam dan luar sambungan terhadap lebar garis. Misalnya, nilai `8` mengizinkan panjang miter hingga delapan kali lebar garis; ini bukan ukuran dalam poin. Jika sudut melebihi batas, PowerPoint memakai sambungan bevel pada sudut tersebut. Batas yang lebih besar memungkinkan titik yang lebih tajam. Pengaturan ini hanya memengaruhi sambungan miter, dan mengubahnya tidak menghasilkan efek terlihat ketika sudut tetap berada dalam kedua batas.

Contoh ini membuat dua segitiga tidak berisi identik dengan garis tepi lebar 20 poin. Segitiga kiri menggunakan batas `2`, dan yang kanan `8`. Setiap segitiga lebar 80 poin dan tinggi 160 poin, memberikan rasio panjang miter‑ke‑lebar‑garis pada sudut atas kira‑kira `4.12`. Akibatnya, PowerPoint menambah bevel pada puncak kiri dan mempertahankan puncak kanan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160)
        triangle.getFillFormat().setFillType(FillType.NoFill)
        triangle.getLineFormat().setWidth(20)
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        color = Color(0, 0, 139)
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
        triangle.getLineFormat().setMiterLimit(miter_limit)

    presentation.save("miter_limits.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hasil di PowerPoint: **Batas miter 2** di kiri dan **batas miter 8** di kanan.

![Puncak bevel dengan batas miter 2 dan puncak runcing dengan batas miter 8 di PowerPoint](miter-limits.png)

## **Isian Gradien**

Isian gradien mencampur warna di seluruh bentuk. Contoh ini mengisi elips dengan gradien linear pada sudut 45‑derajat dari merah ke ungu menggunakan [FillFormat.getGradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getGradientFormat). Metode [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) menempatkan titik henti warna pada 0 dan 1, awal dan akhir gradien. Menghapus titik henti yang ada memastikan hanya dua warna ini yang digunakan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45)
    shape.getFillFormat().getGradientFormat().getGradientStops().clear()
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hasilnya:

![Elips dengan isian gradien](gradient-fill.png)

Jika gradien terlihat berbeda dalam gambar yang diekspor dibandingkan dengan di PowerPoint, lihat [Pilih Gaya Rendering Gradien](/slides/id/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Anda dapat memilih gaya rendering tanpa mengubah gradien yang disimpan dalam presentasi.

### **Tetapkan Sudut Gradien Linear**

Gunakan [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle) untuk mengontrol orientasi isian [GradientShape.Linear](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/). Sudut diukur dalam derajat dan bertambah searah jarum jam: `0` dari kiri ke kanan, `90` dari atas ke bawah, `180` dari kanan ke kiri, dan `270` dari bawah ke atas. Sudut pecahan didukung. Sudut di luar `[0, 360)` dinormalisasi menjadi satu putaran; misalnya, `-45` menjadi `315` dan `360` menjadi `0`.

Contoh ini membuat enam persegi panjang dengan titik henti merah, hijau, dan biru yang identik pada posisi `0`, `0.5`, dan `1`. Skala dinonaktifkan sehingga sudut dapat dibandingkan secara independen dari proporsi persegi panjang. Sudut‑nya, dari kiri ke kanan, adalah `0`, `45`, dan `90` pada baris pertama, serta `135`, `180`, dan `270` pada baris kedua.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        shape.getFillFormat().setFillType(FillType.Gradient)

        gradient = shape.getFillFormat().getGradientFormat()
        gradient.setGradientShape(GradientShape.Linear)
        gradient.getGradientStops().clear()
        gradient.getGradientStops().add(0, Color.RED)
        gradient.getGradientStops().add(0.5, Color.GREEN)
        gradient.getGradientStops().add(1, Color.BLUE)
        gradient.setLinearGradientScaled(NullableBool.False_)
        gradient.setLinearGradientAngle(angle)

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hasil di PowerPoint:

![Gradien linear pada 0, 45, dan 90 derajat di baris atas, serta 135, 180, dan 270 derajat di baris bawah](linear-gradient-angles.png)

### **Skalakan Gradien Linear dengan Bentuk**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientScaled) menerima nilai [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/). Tetapkan secara eksplisit ke `False_` untuk menjaga sudut gradien geometris saat proporsi bentuk berubah, atau ke `True_` untuk menskalakan gradien bersama lebar dan tinggi bentuk. Dengan skala diaktifkan, sudut yang terlihat dapat berbeda dari sudut yang ditetapkan pada bentuk yang tidak persegi.

Contoh berikut menggunakan sudut `45`‑derajat dan titik henti warna yang sama seperti perbandingan sudut. Kolom kiri memakai `False_`; kolom kanan memakai `True_`. Setiap kolom berisi persegi panjang lebar di atas persegi panjang tinggi. Keduanya mulai dengan dimensi lebar yang sama; mengubah lebar dan tinggi persegi panjang kedua menunjukkan bagaimana isian merespons perubahan ukuran tanpa mengubah pengaturan gradien.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    scaling_options = [NullableBool.False_, NullableBool.True_]

    for column, scaled in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90)
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
            shape.getFillFormat().setFillType(FillType.Gradient)

            gradient = shape.getFillFormat().getGradientFormat()
            gradient.setGradientShape(GradientShape.Linear)
            gradient.getGradientStops().clear()
            gradient.getGradientStops().add(0, Color.RED)
            gradient.getGradientStops().add(0.5, Color.GREEN)
            gradient.getGradientStops().add(1, Color.BLUE)
            gradient.setLinearGradientAngle(45)
            gradient.setLinearGradientScaled(scaled)

            if row == 1:
                shape.setWidth(90)
                shape.setHeight(280)

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hasil di PowerPoint, dengan skala dinonaktifkan di kiri dan diaktifkan di kanan:

![Persegi panjang lebar dan tinggi dengan gradien 45‑derajat, membandingkan LinearGradientScaled False di kiri dengan True di kanan](linear-gradient-scaling.png)

Dengan skala dinonaktifkan, pita warna diagonal mempertahankan orientasi yang sama pada kedua persegi panjang. Dengan skala diaktifkan, pita memanjang bersama proporsi bentuk. Ini membantu mereproduksi gradien templat saat menyesuaikan bentuk ke ukuran yang berbeda. Pada bentuk persegi, mengaktifkan skala tidak mengubah tampilan gradien `45`‑derajat ini.

Baik sudut maupun pengaturan skala berlaku untuk gradien linear. Mereka tidak mengontrol isian [GradientShape.Radial atau GradientShape.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientshape/).

### **Gabungkan Sudut dengan Arah Gradien**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setGradientDirection) memilih gaya gradien dari kelas [GradientDirection](https://reference.aspose.com/slides/python-java/aspose.slides/gradientdirection/); ini bukan pengganti sudut numerik. Untuk gradien linear, gaya sudut dapat mengubah area distribusi warna tanpa mengubah sudut yang ditetapkan melalui [setLinearGradientAngle](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/#setLinearGradientAngle). Pertahankan arah tidak berubah saat membandingkan sudut atau skala.

Contoh berikut menerapkan pengaturan yang sama dalam urutan yang berlawanan. Kedua persegi panjang memiliki tampilan yang sama: menetapkan arah sebelum atau sesudah sudut tidak mengubah hasil.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, NullableBool, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    for i in range(2):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        shape.getFillFormat().setFillType(FillType.Gradient)

        gradient = shape.getFillFormat().getGradientFormat()
        gradient.setGradientShape(GradientShape.Linear)
        gradient.getGradientStops().clear()
        gradient.getGradientStops().add(0, Color.RED)
        gradient.getGradientStops().add(0.5, Color.GREEN)
        gradient.getGradientStops().add(1, Color.BLUE)
        gradient.setLinearGradientScaled(NullableBool.True_)

        if i == 0:
            gradient.setGradientDirection(GradientDirection.FromCorner1)
            gradient.setLinearGradientAngle(30)
        else:
            gradient.setLinearGradientAngle(30)
            gradient.setGradientDirection(GradientDirection.FromCorner1)

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Isian Pola**

Isian pola menerapkan desain dua warna, seperti titik, garis, atau cek. Contoh ini menggunakan [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#setPatternStyle) untuk memilih pola trellis. [PatternFormat.getBackColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) menyediakan latar belakang abu‑abu terang, dan [PatternFormat.getForeColor](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) menyediakan warna pola kuning.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Pattern)
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hasilnya:

![Persegi panjang dengan isian pola](pattern-fill.png)

## **Isian Gambar**

Isian gambar menggunakan gambar di dalam bentuk. Contoh ini memerlukan gambar lokal dan menggunakan [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) untuk memuatnya ke dalam koleksi gambar presentasi. Menetapkan [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) ke mode ubin mengulang gambar dalam persegi panjang. Gambar sumber yang digunakan ditampilkan di bawah:

![Gambar lotus](lotus.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    image = Images.fromFile("lotus.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hasilnya:

![Bentuk dengan isian gambar](picture-fill.png)

### **Ubin Gambar Sebagai Tekstur**

Jika Anda ingin menetapkan gambar ubin sebagai tekstur dan menyesuaikan perilaku ubin, Anda dapat menggunakan metode berikut dari kelas [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): Menetapkan mode isian gambar—`Tile` atau `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): Menentukan perataan ubin dalam bentuk.
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): Mengontrol apakah ubin dibalik secara horizontal, vertikal, atau keduanya.
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): Menetapkan offset horizontal ubin (dalam poin) dari asal bentuk.
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): Menetapkan offset vertikal ubin (dalam poin) dari asal bentuk.
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): Mendefinisikan skala horizontal ubin sebagai persentase.
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): Mendefinisikan skala vertikal ubin sebagai persentase.

Contoh ini memerlukan gambar lokal dan mengonfigurasi [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) untuk mengulangnya pada 50 % ukuran aslinya. Offset −32 poin menggeser ubin secara horizontal dan vertikal; perataan kanan‑bawah dan pembalikan di kedua arah menentukan bagaimana tekstur berulang diatur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)
    shape.getFillFormat().setFillType(FillType.Picture)

    source_image = Images.fromFile("lotus.png")
    try:
        presentation_image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hasilnya:

![Opsi ubin](tile-options.png)

## **Isian Warna Solid**

Isian solid memberikan bentuk warna tunggal yang seragam. Contoh ini menggunakan [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) untuk menetapkan mode isian solid dan menetapkan kuning melalui [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor), lalu menyimpan persegi panjang dalam presentasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hasilnya:

![Bentuk dengan isian warna solid](solid-color-fill.png)

### **Salin Warna Sambil Mempertahankan Referensi Tema**

Gunakan [ColorFormat.copyFrom](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#copyFrom) untuk menyalin definisi warna, termasuk tipe warna, referensi tema, dan transformasi. Ini berguna saat memindahkan warna isian antar bentuk yang harus tetap mengikuti tema presentasi. Metode ini hanya menyalin warna: tidak menyalin tipe isian, garis tepi, atau pemformatan bentuk lainnya. Tetapkan tipe isian tujuan secara eksplisit dengan [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType).

Contoh ini membuat tiga persegi panjang, dari kiri ke kanan: sumber, salinan yang sadar tema, dan salinan RGB tetap. Sumber menggunakan [ColorFormat.setSchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#setSchemeColor) untuk merujuk ke warna aksen pertama dan menambahkan tint melalui [ColorOperationCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/coloroperationcollection/#add). Salinan RGB menggunakan warna isian efektif sumber sehingga ketiganya pada awalnya tampak identik. Memanggil [ColorFormat.setColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#setColor) menetapkan nilai RGB tetap dan menghapus transformasi warna yang ada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FillType, ImageFormat, Presentation, SaveFormat, SchemeColor, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    accent_color = Color(65, 105, 225)
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(accent_color)

    source = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 40, 180, 140)
    theme_copy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 240, 40, 180, 140)
    rgb_copy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 450, 40, 180, 140)

    for shape in (source, theme_copy, rgb_copy):
        shape.getFillFormat().setFillType(FillType.Solid)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    source_color = source.getFillFormat().getSolidFillColor()
    source_color.setSchemeColor(SchemeColor.Accent1)
    source_color.getColorTransform().add(ColorTransformOperation.Tint, 0.75)

    theme_copy.getFillFormat().getSolidFillColor().copyFrom(source_color)
    rgb_copy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor())

    before = slide.getImage(1.0, 1.0)
    try:
        before.save("color-copy-before.png", ImageFormat.Png)
    finally:
        before.dispose()

    # Referensi tema mengikuti warna aksen baru; nilai RGB tetap tidak mengikutinya.
    accent_color = Color(255, 69, 0)
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(accent_color)

    after = slide.getImage(1.0, 1.0)
    try:
        after.save("color-copy-after.png", ImageFormat.Png)
    finally:
        after.dispose()
    presentation.save("copied_colors.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sebelum perubahan tema, ketiga isian cocok:

![Sumber, tujuan copyFrom, dan tujuan RGB tetap dengan isian biru identik](color-copy-before.png)

Setelah perubahan tema, sumber dan salinan yang sadar tema mengikuti warna aksen baru dan mempertahankan tintnya. Salinan RGB tetap tetap biru:

![Sumber dan tujuan copyFrom dengan isian oranye, sementara tujuan RGB tetap biru](color-copy-after.png)

Definisi yang disalin bersifat independen dari sumber. Mengubah referensi tema sumber, menetapkan warna lain, atau menambah atau menghapus transformasinya tidak mengubah tujuan. Perubahan tema tetap memengaruhi kedua bentuk karena masing‑masing merujuk secara independen ke warna tema yang sama.

Menyimpan dan membuka kembali file PPTX mempertahankan tipe warna yang disalin yang dikembalikan oleh [ColorFormat.getColorType](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getColorType), referensi tema, dan koleksi transformasi yang dikembalikan oleh [ColorFormat.getColorTransform](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getColorTransform); tidak mengubah definisi menjadi RGB.

Saat menyalin antar konteks tema yang berbeda, seperti presentasi dengan palet aksen yang berbeda, referensi yang disalin diselesaikan terhadap tema tujuan. Referensi dan transformasi yang sama dapat menghasilkan warna tampak yang berbeda. Lihat [Tema Presentasi](/slides/id/python-java/presentation-theme/) untuk informasi lebih lanjut tentang mengonfigurasi warna tema.

## **Gunakan Latar Belakang Slide sebagai Isian Bentuk**

Gunakan [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#setUseBackgroundFill) ketika sebuah bentuk harus menyesuaikan latar belakang slide, misalnya dalam templat presentasi. Tetapkan tipe isian dengan [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) ke [FillType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) terlebih dahulu untuk menghapus isian eksplisit apa pun. Dengan kombinasi ini, bentuk menggunakan latar belakang slide alih‑alih isian gaya. Mengaktifkan flag saja tidak menghapus isian eksplisit yang sudah ada.

Hal ini berbeda dari [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/): isian latar belakang menutupi objek di belakang bentuk dengan area latar belakang slide yang bersesuaian, sementara NoFill membuat objek tersebut tetap terlihat. Gradien tetap selaras dengan slide daripada memulai ulang di dalam setiap bentuk.

Contoh berikut membuat latar belakang master yang diwarisi oleh slide dan menempatkan pita magenta di belakang tiga persegi panjang. Persegi panjang kiri menggunakan latar belakang, persegi panjang tengah tidak memiliki isian, dan persegi panjang kanan beralih dari isian latar belakang ke isian oranye eksplisit.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, GradientShape, Presentation, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    # Warisi gradien dari master.
    slide.getBackground().setType(BackgroundType.NotDefined)
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined)
    background = slide.getLayoutSlide().getMasterSlide().getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Gradient)
    gradient = background.getFillFormat().getGradientFormat()
    gradient.setGradientShape(GradientShape.Linear)
    gradient.setLinearGradientAngle(0)
    gradient.getGradientStops().clear()
    color = Color(0, 0, 139)
    gradient.getGradientStops().add(0, color)
    color = Color(135, 206, 250)
    gradient.getGradientStops().add(1, color)

    # Tambahkan objek ini terlebih dahulu sehingga muncul di belakang persegi panjang.
    band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100)
    band.getFillFormat().setFillType(FillType.Solid)
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    background_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200)
    background_shape.getFillFormat().setFillType(FillType.NotDefined)
    background_shape.setUseBackgroundFill(True)

    no_fill_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200)
    no_fill_shape.getFillFormat().setFillType(FillType.NoFill)

    explicit_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200)
    explicit_shape.getFillFormat().setFillType(FillType.NotDefined)
    explicit_shape.setUseBackgroundFill(True)

    # Nonaktifkan isian latar belakang sebelum menerapkan isian eksplisit.
    explicit_shape.setUseBackgroundFill(False)
    explicit_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    explicit_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("background_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hasilnya, dari kiri ke kanan: **isian latar belakang**, **tanpa isian**, dan **isian eksplisit**. Pita magenta tersembunyi oleh persegi panjang kiri dan kanan tetapi tetap terlihat melalui persegi panjang tengah.

![Isian latar belakang, tanpa isian, dan isian oranye eksplisit di atas pita magenta](background-fill.png)

Perilaku yang sama berlaku untuk latar belakang yang didefinisikan langsung pada slide atau diwarisi dari layout. Bentuk menggunakan latar belakang slide yang telah diselesaikan; contoh ini membiarkan latar belakang slide dan layout tidak ditetapkan sehingga master yang menyediakannya.

## **Tetapkan Transparansi**

Untuk isian solid, komponen alfa warna mengontrol opasitas: 0 sepenuhnya transparan dan 255 sepenuhnya opaque. Contoh ini menggunakan nilai alfa 128 untuk persegi panjang kuning, menjadikannya kira‑kira 50 % transparan sehingga persegi panjang di bawahnya tetap terlihat. Warna ditetapkan melalui [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 255, 0, 128)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(color)

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hasilnya:

![Bentuk transparan](shape-transparency.png)

## **Putar Bentuk**

Gunakan [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) untuk memutar bentuk dalam bidang slide. Sudut diukur dalam derajat; contoh ini memutar persegi panjang 5 derajat searah jarum jam dan menyimpan presentasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    shape.setRotation(5)

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hasilnya:

![Rotasi bentuk](shape-rotation.png)

## **Tambahkan Efek Bevel 3D**

Gunakan [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) untuk memberikan kedalaman dan tepi bevel pada bentuk. Contoh ini membuat elips hijau dengan garis tepi oranye, menggunakan [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) untuk menetapkan kedalaman 4 poin, dan menerapkan bevel atas melingkar dengan lebar dan tinggi 6 poin melalui [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop). Kamera ortografik menghadap depan dan pencahayaan tiga‑titik membuat bevel terlihat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(0, 128, 0)
    shape.getFillFormat().getSolidFillColor().setColor(color)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(color)
    shape.getLineFormat().setWidth(2.0)
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hasilnya:

![Efek bevel 3D](3D-bevel-effect.png)

## **Tambahkan Efek Rotasi 3D**

Tampilan 3D sebuah bentuk dikontrol oleh pengaturan kameranya. Contoh ini menggunakan [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) dengan sudut lintang, bujur, dan revolusi masing‑masing 40, 35, dan 20 derajat. Ia memilih kamera isometrik melalui [Camera.setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) dan pencahayaan seimbang melalui [LightRig.setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType), lalu menyimpan persegi panjang yang diformat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hasilnya:

![Efek rotasi 3D](3D-rotation-effect.png)

## **Kendalikan Rendering Hitam‑Putih untuk Bentuk**

Metode [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) menentukan bagaimana sebuah bentuk individual dirender ketika presentasi dilihat atau diproses dalam mode hitam‑putih. Metode ini tidak mengaktifkan tampilan hitam‑putih sendiri, dan tidak mengubah isian, garis, atau pemformatan bentuk lainnya dalam mode warna normal.

Gunakan nilai dari kelas [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) untuk memilih perilaku yang diinginkan. Misalnya, `Automatic` membiarkan aplikasi rendering memilih konversi, `Gray` dan `LightGray` menggunakan warna abu‑abu, `BlackWhite` hanya menggunakan hitam dan putih, `Black` dan `White` memaksa satu warna, `Color` mempertahankan warna normal, dan `Hidden` menghilangkan bentuk dalam mode hitam‑putih. `NotDefined` berarti tidak ada mode tingkat bentuk yang ditetapkan.

Contoh ini membuat persegi panjang oranye dan menggunakan [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) untuk menetapkan mode ke abu‑abu. Bentuk yang disimpan mempertahankan isian oranye untuk tampilan warna normal dan meminta pewarnaan abu‑abu dari aplikasi yang menghormati pengaturan tampilan hitam‑putih:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteMode, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    color = Color(255, 165, 0)
    shape.getFillFormat().getSolidFillColor().setColor(color)
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Dalam mode warna normal, persegi panjang tetap berisi oranye. Dalam alur kerja tampilan hitam‑putih, ia menggunakan pewarnaan abu‑abu karena mode disetel ke `Gray`. Ini memungkinkan Anda mempertahankan slide berwarna penuh sambil mendefinisikan tampilan berbeda untuk pencetakan, pratinjau, atau alur kerja lain yang menghormati pengaturan tampilan hitam‑putih presentasi.

## **Setel Ulang Pemformatan**

Gunakan [Slide.reset](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#reset) untuk mengembalikan posisi, ukuran, dan pemformatan placeholder slide dari placeholder layout yang bersesuaian. Contoh ini memerlukan presentasi yang ada dengan placeholder yang ditautkan ke layout dan mereset setiap slide sebelum disimpan. Bentuk tanpa placeholder layout yang bersesuaian tidak direset.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah pemformatan bentuk memengaruhi ukuran file presentasi akhir?**

Warna, gaya garis, dan pengaturan efek umumnya menambah sedikit data dibandingkan dengan gambar dan media yang disematkan. Isian gambar dapat meningkatkan ukuran file karena gambarnya disimpan dalam presentasi.

**Bagaimana saya dapat mendeteksi bentuk pada slide yang memiliki pemformatan identik sehingga saya dapat mengelompokkannya?**

Bandingkan properti pemformatan utama setiap bentuk—isi, garis, dan pengaturan efek. Jika semua nilai yang bersesuaian cocok, perlakukan gaya mereka sebagai identik dan kelompokkan bentuk‑bentuk tersebut secara logis, yang menyederhanakan manajemen gaya selanjutnya.

**Bisakah saya menyimpan sekumpulan gaya bentuk kustom ke file terpisah untuk digunakan kembali di presentasi lain?**

Ya. Simpan contoh bentuk dengan gaya yang diinginkan dalam slide templat atau file .POTX. Saat membuat presentasi baru, buka templat, kloning bentuk bergaya yang diperlukan, dan terapkan kembali pemformatannya sesuai kebutuhan.