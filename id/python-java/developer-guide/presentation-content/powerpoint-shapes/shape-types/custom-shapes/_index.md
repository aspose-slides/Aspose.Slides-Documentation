---
title: Kustomisasi Bentuk Presentasi di Python melalui Java
linktitle: Bentuk Kustom
type: docs
weight: 20
url: /id/python-java/custom-shape/
keywords:
- bentuk kustom
- tambahkan bentuk
- buat bentuk
- ubah bentuk
- geometri bentuk
- jalur geometri
- titik jalur
- titik penyuntingan
- tambahkan titik
- hapus titik
- operasi penyuntingan
- sudut melengkung
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Buat dan sesuaikan bentuk dalam presentasi PowerPoint dengan Aspose.Slides untuk Python melalui Java: jalur geometri, sudut melengkung, bentuk komposit."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menyesuaikan bentuk presentasi dalam Aspose.Slides dengan mengedit geometri bentuk melalui edit points dan geometry paths. Artikel ini menunjukkan cara bekerja dengan [GeometryPath](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometrypath/) untuk memodifikasi bentuk yang ada, melakukan operasi penyuntingan jalur dasar, menambah atau menghapus titik, dan menerapkan geometri yang diperbarui kembali ke sebuah bentuk.

Artikel ini juga memperlihatkan cara membuat bentuk kustom dan komposit, membangun bentuk dengan sudut melengkung, menentukan apakah geometri sebuah bentuk tertutup, dan mengonversi antara [GeometryPath](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometrypath/) dan [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) untuk skenario kustomisasi geometri tambahan.

## **Ubah Bentuk Menggunakan Edit Points**

Pertimbangkan sebuah persegi. Di PowerPoint, dengan menggunakan **edit points**, Anda dapat 

* memindahkan sudut persegi ke dalam atau ke luar
* menentukan kelengkungan untuk sebuah sudut atau titik
* menambahkan titik baru ke persegi
* memanipulasi titik pada persegi, dll. 

Intinya, Anda dapat melakukan tugas-tugas yang dijelaskan pada bentuk apa pun. Dengan edit points, Anda dapat mengubah sebuah bentuk atau membuat bentuk baru dari bentuk yang ada. 

## **Tips Penyuntingan Bentuk**

![overview_image](custom_shape_0.png)

Sebelum Anda mulai menyunting bentuk PowerPoint melalui edit points, Anda mungkin ingin mempertimbangkan poin-poin berikut tentang bentuk:

* Sebuah bentuk (atau jalurnya) dapat berupa tertutup atau terbuka.
* Ketika sebuah bentuk tertutup, tidak memiliki titik mulai atau akhir. Ketika sebuah bentuk terbuka, memiliki titik mulai dan akhir. 
* Semua bentuk terdiri dari setidaknya 2 titik jangkar yang terhubung satu sama lain oleh garis.
* Sebuah garis dapat lurus atau melengkung. Titik jangkar menentukan sifat garis. 
* Titik jangkar ada sebagai titik sudut, titik lurus, atau titik halus:
  * Titik sudut adalah titik di mana 2 garis lurus bertemu dengan suatu sudut. 
  * Titik halus adalah titik di mana 2 pegangan berada dalam satu garis lurus dan segmen garis bergabung dalam lengkungan halus. Pada kasus ini, semua pegangan dipisahkan dari titik jangkar dengan jarak yang sama. 
  * Titik lurus adalah titik di mana 2 pegangan berada dalam satu garis lurus dan segmen garis tersebut bergabung dalam lengkungan halus. Pada kasus ini, pegangan tidak harus dipisahkan dari titik jangkar dengan jarak yang sama. 
* Dengan memindahkan atau menyunting titik jangkar (yang mengubah sudut garis), Anda dapat mengubah tampilan sebuah bentuk. 

Untuk menyunting bentuk PowerPoint melalui edit points, **Aspose.Slides** menyediakan kelas [GeometryPath](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometrypath/). 

* Sebuah instance [GeometryPath](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometrypath/) mewakili jalur geometri dari objek [GeometryShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometryshape/). 
* Untuk mengambil [GeometryPath](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometrypath/) dari instance [GeometryShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometryshape/), Anda dapat menggunakan method [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometryshape/#getGeometryPaths). 
* Untuk menetapkan [GeometryPath](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometrypath/) pada sebuah bentuk, Anda dapat menggunakan method ini: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometryshape/#setGeometryPath) untuk *bentuk solid* dan [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometryshape/#setGeometryPaths) untuk *bentuk komposit*.
* Untuk menambahkan segmen, Anda dapat menggunakan method di bawah [GeometryPath](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometrypath/). 
* Dengan method [GeometryPath.setStroke](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometrypath/#setStroke) dan [GeometryPath.setFillMode](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometrypath/#setFillMode), Anda dapat mengatur tampilan untuk sebuah jalur geometri.
* Dengan method [GeometryPath.getPathData](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometrypath/#getPathData), Anda dapat mengambil jalur geometri dari sebuah [GeometryShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometryshape/) sebagai array segmen jalur. 
* Untuk mengakses opsi kustomisasi geometri bentuk tambahan, Anda dapat mengonversi [GeometryPath](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometrypath/) ke [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)
* Gunakan method [geometryPathToGraphicsPath](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapeutil/) dan [graphicsPathToGeometryPath](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapeutil/) (dari kelas [ShapeUtil](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapeutil/)) untuk mengonversi [GeometryPath](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometrypath/) ke [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) bolak‑balik. 

## **Operasi Penyuntingan Sederhana**

Tanda tangan berikut menunjukkan operasi penyuntingan dasar:

**Tambahkan sebuah garis** ke akhir jalur:

- `geometry_path.lineTo(point)`
- `geometry_path.lineTo(x, y)`

**Tambahkan sebuah garis** ke posisi tertentu pada jalur:

- `geometry_path.lineTo(point, index)`
- `geometry_path.lineTo(x, y, index)`

**Tambahkan sebuah kurva Bezier kubik** di akhir jalur:

- `geometry_path.cubicBezierTo(point1, point2, point3)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3)`

**Tambahkan sebuah kurva Bezier kubik** ke posisi tertentu pada jalur:

- `geometry_path.cubicBezierTo(point1, point2, point3, index)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3, index)`

**Tambahkan sebuah kurva Bezier kuadratik** di akhir jalur:

- `geometry_path.quadraticBezierTo(point1, point2)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2)`

**Tambahkan sebuah kurva Bezier kuadratik** ke posisi tertentu pada jalur:

- `geometry_path.quadraticBezierTo(point1, point2, index)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2, index)`

**Tambahkan sebuah busur** ke jalur:

- `geometry_path.arcTo(width, height, start_angle, sweep_angle)`

**Tutup gambar saat ini** pada jalur:

- `geometry_path.closeFigure()`

**Tetapkan posisi untuk titik berikutnya**:

- `geometry_path.moveTo(point)`
- `geometry_path.moveTo(x, y)`

**Hapus segmen jalur** pada indeks tertentu:

- `geometry_path.removeAt(index)`


## **Tambahkan Titik Kustom ke Bentuk**
1. Buat instance kelas [GeometryShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometryshape/) dan tetapkan tipe [ShapeType.Rectangle](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapetype/#Rectangle).
2. Dapatkan instance kelas [GeometryPath](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometrypath/) dari bentuk tersebut.
3. Tambahkan titik baru di antara dua titik atas pada jalur.
4. Tambahkan titik baru di antara dua titik bawah pada jalur.
5. Terapkan jalur ke bentuk.

Kode Python berikut menunjukkan cara menambahkan titik kustom ke sebuah bentuk:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)
    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example1_image](custom_shape_1.png)

## **Hapus Titik dari Bentuk**

1. Buat instance kelas [GeometryShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometryshape/) dan tetapkan tipe [ShapeType.Heart](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapetype/#Heart). 
2. Dapatkan instance kelas [GeometryPath](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometrypath/) dari bentuk tersebut.
3. Hapus segmen untuk jalur tersebut.
4. Terapkan jalur ke bentuk.

Kode Python berikut menunjukkan cara menghapus titik dari sebuah bentuk:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)
    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)
    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **Buat Bentuk Kustom**

1. Hitung titik‑titik untuk bentuk.
2. Buat instance kelas [GeometryPath](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometrypath/). 
3. Isi jalur dengan titik‑titik tersebut.
4. Buat instance kelas [GeometryShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometryshape/). 
5. Terapkan jalur ke bentuk.

Kode Python berikut menunjukkan cara membuat bentuk kustom:

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
step = 72

for angle in range(-90, 270, step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + step / 2)
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
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)


## **Buat Bentuk Kustom Komposit**

  1. Buat instance kelas [GeometryShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometryshape/).
  2. Buat instance pertama kelas [GeometryPath](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometrypath/).
  3. Buat instance kedua kelas [GeometryPath](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometrypath/).
  4. Terapkan jalur‑jalur ke bentuk.

Kode Python berikut menunjukkan cara membuat bentuk kustom komposit:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

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

## **Buat Bentuk Kustom dengan Sudut Melengkung**

Kode Python berikut menunjukkan cara membuat bentuk kustom dengan sudut melengkung (ke dalam):

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
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)
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

## **Temukan Apakah Geometri Bentuk Tertutup**

Sebuah bentuk tertutup didefinisikan sebagai bentuk di mana semua sisinya terhubung, membentuk satu batas tanpa celah. Bentuk semacam itu dapat berupa bentuk geometris sederhana atau kontur kustom yang kompleks. Contoh kode berikut menunjukkan cara memeriksa apakah geometri sebuah bentuk tertutup:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PathCommandType

def is_geometry_closed(geometry_shape):
    is_closed = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        is_closed = last_segment.getPathCommand() == PathCommandType.Close
        if not is_closed:
            return False
    return is_closed
```

## **Konversi GeometryPath ke java.awt.Shape** 

1. Buat instance kelas [GeometryShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometryshape/).
2. Buat instance kelas [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
3. Konversi instance [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) ke instance [GeometryPath](https://reference.aspose.com/slides/id/python-java/aspose.slides/geometrypath/) dengan berjalan melalui [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html)‑nya dan memutar ulang setiap segmen pada jalur.
4. Terapkan jalur‑jalur ke bentuk.

Kode Python berikut mengimplementasikan langkah‑langkah di atas untuk mengonversi jalur grafis ke jalur geometri:

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
    # Buat bentuk baru.
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # Dapatkan jalur geometri bentuk.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # Buat jalur grafis baru dengan teks.
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        glyph_vector = font.createGlyphVector(graphics.getFontRenderContext(), text)
        graphics_path = glyph_vector.getOutline(20.0, -glyph_vector.getVisualBounds().getY() + 10)
    finally:
        graphics.dispose()

    # Konversi jalur grafis ke jalur geometri.
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

**Apa yang terjadi pada isian dan garis tepi setelah mengganti geometri?**

Gaya tetap melekat pada bentuk; hanya kontur yang berubah. Isian dan garis tepi secara otomatis diterapkan pada geometri baru.

**Bagaimana cara memutar bentuk kustom beserta geometri secara tepat?**

Gunakan method [setRotation](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#setRotation) pada bentuk; geometri berputar bersama bentuk karena terikat pada sistem koordinat bentuk itu sendiri.

**Apakah saya dapat mengonversi bentuk kustom menjadi gambar untuk "mengunci" hasilnya?**

Ya. Ekspor area [slide](/slides/id/python-java/convert-powerpoint-to-png/) yang diperlukan atau [shape](/slides/id/python-java/create-shape-thumbnails/) itu sendiri ke format raster; ini menyederhanakan pekerjaan lanjutan dengan geometri yang kompleks.