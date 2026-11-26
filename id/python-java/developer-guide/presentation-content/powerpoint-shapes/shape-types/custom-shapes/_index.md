---
title: Sesuaikan Bentuk Presentasi di Python melalui Java
linktitle: Bentuk Kustom
type: docs
weight: 20
url: /id/python-java/custom-shape/
keywords: 
- bentuk kustom
- tambah bentuk
- buat bentuk
- ubah bentuk
- geometri bentuk
- jalur geometri
- titik jalur
- titik edit
- tambah titik
- hapus titik
- operasi penyuntingan
- sudut melengkung
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Buat dan sesuaikan bentuk dalam presentasi PowerPoint dengan Aspose.Slides untuk Python melalui Java: jalur geometri, sudut melengkung, bentuk gabungan."
---
## **Ikhtisar**

Artikel ini menjelaskan cara menyesuaikan bentuk presentasi di Aspose.Slides dengan mengedit geometri bentuk melalui titik edit dan jalur geometri. Artikel ini menunjukkan cara bekerja dengan [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) untuk memodifikasi bentuk yang ada, melakukan operasi penyuntingan jalur dasar, menambah atau menghapus titik, dan menerapkan geometri yang diperbarui kembali ke sebuah bentuk.

Artikel ini juga memperlihatkan cara membuat bentuk khusus dan gabungan, membangun bentuk dengan sudut melengkung, menentukan apakah geometri bentuk tertutup, memeriksa elemen bentuk, dan mengonversi kontur teks Java AWT menjadi jalur geometri.

## **Ubah Bentuk Menggunakan Titik Edit**

Di PowerPoint, Anda dapat menggunakan **Edit Points** untuk memodifikasi sebuah persegi:

* Memindahkan sudut ke dalam atau ke luar.
* Menyesuaikan kelengkungan pada sebuah titik.
* Menambah titik baru.

Mengedit titik memungkinkan Anda mengubah kontur sebuah bentuk atau menggunakan bentuk yang ada sebagai dasar untuk bentuk baru.

## **Tips Penyuntingan Bentuk**

![overview_image](custom_shape_0.png)

Saat menyunting bentuk PowerPoint, perhatikan konsep berikut:

* Sebuah bentuk (atau jalurnya) dapat berupa tertutup atau terbuka.
* Jalur sebuah bentuk terdiri dari titik jangkar yang dihubungkan oleh segmen.
* Sebuah segmen dapat lurus atau melengkung. Titik jangkar dan pegangan kontrol menentukan bentuknya.
* Titik jangkar dapat berupa titik sudut, titik lurus, atau titik halus:
  * Pada titik sudut, segmen yang bersebelahan dapat bertemu dengan sudut.
  * Pada titik halus, dua pegangan kontrol berada pada garis lurus dan berjarak sama dari titik jangkar.
  * Pada titik lurus, dua pegangan kontrol berada pada garis lurus tetapi dapat memiliki jarak yang berbeda dari titik jangkar.
* Memindahkan titik jangkar atau menyesuaikan pegangan mereka mengubah kontur bentuk.

Untuk menyunting bentuk PowerPoint melalui titik edit, **Aspose.Slides** menyediakan kelas [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

* Sebuah instance [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) mewakili jalur geometri dari objek [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/).
* Untuk mengambil [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) dari instance [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/), Anda dapat menggunakan metode [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths).
* Untuk mengatur [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) pada sebuah bentuk, Anda dapat menggunakan metode ini: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) untuk bentuk dengan satu jalur dan [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) untuk bentuk dengan beberapa jalur.
* Untuk menambah segmen, Anda dapat menggunakan metode di bawah [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).
* Dengan menggunakan metode [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) dan [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode), Anda dapat mengatur tampilan untuk sebuah jalur geometri.
* Dengan menggunakan metode [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData), Anda dapat mengambil jalur geometri dari sebuah [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) sebagai array segmen jalur.
* Untuk mengakses opsi kustomisasi geometri bentuk tambahan, Anda dapat membaca sebuah [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) melalui [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) dan memutar ulang segmen‑segmen tersebut pada sebuah [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

## **Operasi Penyuntingan Sederhana**

Gunakan metode berikut untuk menyunting sebuah jalur geometri. Overload yang menerima indeks menyisipkan segmen pada posisi berbasis nol dalam array segmen jalur.

| Operasi | Metode |
| --- | --- |
| Menambahkan atau menyisipkan garis lurus. | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| Menambahkan atau menyisipkan kurva Bézier kubik dengan dua titik kontrol dan satu titik akhir. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Menambahkan atau menyisipkan kurva Bézier kuadratik dengan satu titik kontrol dan satu titik akhir. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Menambahkan busur elips dengan dimensi dan sudut yang ditentukan dalam derajat. | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| Menutup gambar saat ini dengan menghubungkan titik akhirnya ke titik awalnya. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| Menetapkan titik awal sebuah gambar. | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| Menghapus segmen pada indeks berbasis nol. | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **Menambahkan Titik Kustom ke Bentuk**

Contoh ini menyisipkan dua titik ke dalam bentuk persegi panjang menggunakan [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) dan menerapkan jalur yang telah disunting dengan [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath). Koordinat bersifat lokal terhadap bentuk: kedua titik baru berada di tengahnya, 100 poin dari kiri dan 50 poin dari atas. Indeks segmen 1 dan 4 menempatkannya pada tepi atas dan bawah, menarik tepi‑tepi tersebut ke dalam.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```

![example1_image](custom_shape_1.png)

## **Menghapus Titik dari Bentuk**

Contoh ini mengubah kontur bentuk hati dengan menghapus segmen pada indeks berbasis nol 2 menggunakan [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt). Menerapkan jalur yang dimodifikasi dengan [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) memperbarui kontur bentuk.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **Membuat Bentuk Kustom**

Contoh ini membangun bintang lima sudut dengan [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/). Radius luar dan dalam yang bergantian sebesar 100 dan 50 poin menentukan puncak serta lekukan; langkah 72‑derajat menempatkan kelima puncak secara merata. Jalur ditutup dengan [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) dan diterapkan ke bentuk persegi panjang menggunakan [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), menggantikan konturnya.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

import math

points = []
outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + angle_step / 2)
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

star_path = GeometryPath()
star_path.moveTo(*points[0])
for point in points[1:]:
    star_path.lineTo(*point)
star_path.closeFigure()

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)

## **Membuat Bentuk Kustom Gabungan**

Contoh ini mendefinisikan dua objek [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) tertutup untuk sepertiga atas dan sepertiga bawah sebuah bentuk. Menerapkan kedua jalur dengan [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) menghasilkan satu bentuk gabungan dengan celah di sepertiga tengahnya.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    top_path = GeometryPath()
    top_path.moveTo(0, 0)
    top_path.lineTo(shape.getWidth(), 0)
    top_path.lineTo(shape.getWidth(), shape.getHeight() / 3)
    top_path.lineTo(0, shape.getHeight() / 3)
    top_path.closeFigure()

    bottom_path = GeometryPath()
    bottom_path.moveTo(0, shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight())
    bottom_path.lineTo(0, shape.getHeight())
    bottom_path.closeFigure()

    shape.setGeometryPaths([top_path, bottom_path])
finally:
    presentation.dispose()
```
![example4_image](custom_shape_4.png)

## **Membuat Bentuk Kustom dengan Sudut Melengkung**

Contoh ini menggabungkan segmen lurus dengan [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) untuk membuat bentuk dengan sudut melengkung ke dalam. Setiap ukuran sudut menentukan lebar dan tinggi busur dalam poin, dan sapuan -90‑derajat menggambar seperempat elips berlawanan arah jarum jam. Jalur selesai diterapkan dengan [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), dan presentasi disimpan dalam format PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, SaveFormat

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)

    geometry_path = GeometryPath()
    geometry_path.moveTo(left_top_size, 0)
    geometry_path.lineTo(shape_width - right_top_size, 0)
    geometry_path.arcTo(right_top_size, right_top_size, 180, -90)
    geometry_path.lineTo(shape_width, shape_height - right_bottom_size)
    geometry_path.arcTo(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.lineTo(left_bottom_size, shape_height)
    geometry_path.arcTo(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.lineTo(0, left_top_size)
    geometry_path.arcTo(left_top_size, left_top_size, 90, -90)
    geometry_path.closeFigure()
    
    shape.setGeometryPath(geometry_path)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Menentukan Apakah Geometri Bentuk Tertutup**

Helper berikut memeriksa apakah setiap jalur geometri yang tidak kosong diakhiri dengan segmen penutup. Ia membaca [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) dan membandingkan perintah segmen akhir [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) dengan [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/). Metode ini mengembalikan `False` bila tidak ada jalur yang tidak kosong. Pemeriksaan ini memperhatikan perintah akhir setiap jalur; ia tidak memeriksa setiap sub‑gambar di dalam jalur. Contoh mencetak `True` untuk sebuah persegi panjang.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, PathCommandType

def is_geometry_closed(geometry_shape):
    has_nonempty_path = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        has_nonempty_path = True
        if last_segment.getPathCommand() != PathCommandType.Close:
            return False
    return has_nonempty_path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    closed = is_geometry_closed(shape)
    print(closed)
finally:
    presentation.dispose()
```

## **Memeriksa Perintah Jalur Geometri**

Unduh [contour.pptx](contour.pptx) dan letakkan di direktori kerja aplikasi. Bentuk pertama pada slide pertama memiliki tepi atas lurus, sebuah kurva Bézier kubik, dan tepi penutup lurus. Gunakan [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) untuk membaca jalur bentuk dan [getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) untuk membaca segmen‑segmen setiap jalur dalam urutan menggambar. Untuk setiap segmen, [getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) mengidentifikasi perintah dan menentukan cara menafsirkan nilai yang dikembalikan oleh [getSegmentData](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getSegmentData).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PathCommandType, Presentation

presentation = Presentation("contour.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    for i, path in enumerate(shape.getGeometryPaths()):
        for j, segment in enumerate(path.getPathData()):
            command = segment.getPathCommand()
            data = segment.getSegmentData()
            if command in (PathCommandType.MoveTo, PathCommandType.LineTo):
                detail = f"destination=({data[0]}, {data[1]})"
            elif command == PathCommandType.CubicBezierTo:
                detail = f"control1=({data[0]}, {data[1]}) control2=({data[2]}, {data[3]}) end=({data[4]}, {data[5]})"
            elif command == PathCommandType.Close:
                detail = "no coordinates"
            else:
                detail = f"raw={list(data)}"
            name = PathCommandType.getName(PathCommandType.class_, command)
            print(f"Path {i}, segment {j}: {name} {detail}")
finally:
    presentation.dispose()
```

Bentuk berada pada posisi (200, 100) poin pada slide. Koordinat yang dilaporkan bersifat lokal terhadap bentuk, dengan (0, 0) di sudut kiri‑atasnya, x meningkat ke kanan, dan y meningkat ke bawah. Segmen penutup kembali ke titik awal tanpa koordinat tambahan.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Mengekstrak dan Memeriksa Elemen Bentuk**

Gunakan [GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements) untuk memeriksa sebuah bentuk yang ada sebagai elemen‑elemen yang berisi titik‑titik jalur dan tipe titik. Cast setiap elemen yang dikembalikan ke [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) dengan `jpype.JObject` untuk mengambil array titik dan tipe melalui metode [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) dan [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes). Representasi ini berguna untuk analisis kontur atau mengirim geometri ke alat gambar khusus.

Contoh membuka input.pptx, menemukan bentuk geometri pertama langsung pada slide pertama, dan mencetak segmen‑segmen jalurnya. Gunakan presentasi yang berisi bentuk dengan segmen lurus dan melengkung untuk melihat kedua jenis keluaran. Contoh tidak mencari di dalam grup.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, GeometryShape, ShapeElement

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = None
    for candidate in slide.getShapes():
        if isinstance(candidate, GeometryShape):
            shape = candidate
            break

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.createShapeElements():
            shape_element = jpype.JObject(element, ShapeElement)
            points = shape_element.getPathPoints()
            types = shape_element.getPathTypes()
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # Pertahankan tipe segmen, kecuali flag.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Gunakan kedua titik kontrol dan titik akhir.

                if types[i] & 0x80:
                    print("Close subpath back to its starting point.")
                i += 1
finally:
    presentation.dispose()
```

Array berkorespondensi berdasarkan indeks: `points[i]` adalah sebuah titik dan `types[i]` menjelaskan perannya. Tipe `0` memulai sebuah gambar, dan tipe `1` menggambar garis dari titik sebelumnya ke titik saat ini. Sebuah segmen Bézier kubik dimulai pada titik akhir sebelumnya dan menggunakan tiga entri tipe‑`3` berurutan: dua titik kontrol diikuti oleh titik akhir baru. Loop mengonsumsi ketiga entri tersebut sekaligus dan memeriksa titik akhir untuk penutupan.

Tipe titik juga mengandung flag. Mask dengan `0x07` untuk mengidentifikasi tipe segmen, dan uji `0x80` secara terpisah untuk mendeteksi sub‑path tertutup. Misalnya, `129` (`0x81`) berarti titik akhir garis yang menutup sub‑path, dan `131` (`0x83`) berarti titik akhir Bézier yang menutup satu. Java menyimpan flag‑flag ini dalam byte bertanda; masking mempertahankan nilai bit yang dimaksud. Membandingkan nilai mentah hanya dengan `1` atau `3` akan melewatkan kasus‑kasus ini. Flag lain, seperti dash (`0x10`) dan marker (`0x20`), tidak mengubah tipe segmen dasar.

**Koordinat dan transformasi.** Titik diukur dalam poin (1/72 inci), dengan X meningkat ke kanan dan Y meningkat ke bawah. Untuk sebuah bentuk yang tidak dikelompokkan, koordinat yang diekstrak sudah mencakup posisi yang dikembalikan oleh [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) dan [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) serta mencerminkan lebar dan tinggi saat ini. Misalnya, sebuah persegi panjang yang tidak diputar pada `(100, 200)` dengan ukuran `120 × 80` memiliki batas kontur `(100, 200)`–`(220, 280)`. Jangan menambahkan posisi bentuk lagi. Kurangi X dan Y untuk memperoleh koordinat relatif terhadap bingkai yang tidak diputar.

Titik yang diekstrak tidak menerapkan rotasi bentuk, yang dikembalikan oleh [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation), atau pembalikan horizontal dan vertikal. Untuk mereproduksi kontur yang terlihat, terapkan transformasi tersebut di sekitar pusat bentuk. Untuk bentuk yang dikelompokkan, perhitungkan juga pemetaan koordinat grup dan transformasinya; jangan menganggap titik yang diekstrak adalah koordinat slide yang sudah dirender akhir atau menerapkan translasi atau skala dua kali jika sudah tercermin dalam bingkai anak.

**Pemeriksaan vs penyuntingan.** Array yang diekstrak menggambarkan kontur; mengubahnya tidak memperbarui bentuk asli. Gunakan pendekatan ini bila analisis atau kode gambar Anda memerlukan array titik/tipe. Gunakan [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) bila Anda memerlukan perintah geometri dalam sistem koordinat lokal bentuk atau ingin menyunting geometri tersebut. Terapkan jalur yang disunting melalui [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) atau [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Mengonversi Java AWT Shape menjadi GeometryPath**

Contoh ini menggabungkan kontur persegi panjang dengan teks yang dikonversi menjadi geometri. Metode [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) pada kontur menonaktifkan isinya. Sebuah [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) membuat kontur teks dalam sebuah [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html)‑nya menyediakan segmen move, line, quadratic, cubic, dan closing, yang contoh ini mainkan kembali pada sebuah [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

Teks menggunakan font Arial 40 poin. Kontur digeser 20 poin secara horizontal dan diposisikan dengan bagian atas visualnya 10 poin di bawah tepi atas bentuk. Jalur teks diisi, sementara persegi panjang asli tetap menjadi kontur. Menerapkan kedua jalur dengan [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) menghasilkan satu bentuk yang berisi persegi panjang dan teks.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, PathFillModeType

from java.awt import Font
from java.awt.geom import PathIterator
from java.awt.image import BufferedImage

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # Dapatkan jalur geometri dari bentuk.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # Buat jalur grafis baru dengan teks.
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        font_context = graphics.getFontRenderContext()
        glyph_vector = font.createGlyphVector(font_context, text)
        text_bounds = glyph_vector.getVisualBounds()
        baseline = -text_bounds.getY() + 10
        graphics_path = glyph_vector.getOutline(20.0, baseline)
    finally:
        graphics.dispose()

    # Konversi jalur grafis menjadi jalur geometri.
    text_path = GeometryPath()
    path_iterator = graphics_path.getPathIterator(None)
    points = jpype.JArray(jpype.JFloat)(6)
    while not path_iterator.isDone():
        segment_type = path_iterator.currentSegment(points)
        if segment_type == PathIterator.SEG_MOVETO:
            text_path.moveTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_LINETO:
            text_path.lineTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_QUADTO:
            text_path.quadraticBezierTo(points[0], points[1], points[2], points[3])
        elif segment_type == PathIterator.SEG_CUBICTO:
            text_path.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5])
        elif segment_type == PathIterator.SEG_CLOSE:
            text_path.closeFigure()
        path_iterator.next()
    text_path.setFillMode(PathFillModeType.Normal)

    # Terapkan jalur teks bersama dengan jalur geometri asli.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Apa yang terjadi pada isian dan kontur setelah mengganti geometri?**

Gaya tetap melekat pada bentuk; hanya konturnya yang berubah. Isian dan kontur secara otomatis diterapkan pada geometri baru.

**Bagaimana cara memutar bentuk kustom bersama geometri secara benar?**

Gunakan metode [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) pada bentuk; geometri berputar bersama bentuk karena terikat pada sistem koordinat bentuk itu sendiri.

**Apakah saya dapat mengonversi bentuk kustom menjadi gambar untuk “mengunci” hasilnya?**

Ya. Ekspor area [slide](/slides/id/python-java/convert-powerpoint-to-png/) yang diperlukan atau [shape](/slides/id/python-java/create-shape-thumbnails/) itu sendiri ke format raster; hal ini menyederhanakan pekerjaan lanjutan dengan geometri yang kompleks.