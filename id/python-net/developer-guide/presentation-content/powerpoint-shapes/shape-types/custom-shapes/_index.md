---
title: Sesuaikan Bentuk dalam Presentasi dengan Python
linktitle: Bentuk Kustom
type: docs
weight: 20
url: /id/python-net/custom-shape/
keywords:
- bentuk kustom
- tambahkan bentuk
- buat bentuk
- ubah bentuk
- geometri bentuk
- jalur geometri
- titik jalur
- edit titik
- tambahkan titik
- hapus titik
- operasi penyuntingan
- sudut melengkung
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Buat dan sesuaikan bentuk dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk Python via .NET: jalur geometri, sudut melengkung, bentuk komposit."
---
## **Pendahuluan**

Pertimbangkan sebuah persegi. Di PowerPoint, menggunakan **Edit Points**, Anda dapat:

* memindahkan sudut persegi ke dalam atau ke luar,
* menyesuaikan kelengkungan sudut atau titik,
* menambahkan titik baru ke persegi,
* memanipulasi titik‑titiknya.

Anda dapat menerapkan operasi ini pada bentuk apa pun. Dengan **Edit Points**, Anda dapat memodifikasi sebuah bentuk atau membuat yang baru dari bentuk yang sudah ada.

## **Tips Penyuntingan Bentuk**

![\"Perintah Edit Points\" command](custom_shape_0.png)

Sebelum Anda mulai menyunting bentuk PowerPoint menggunakan **Edit Points**, pertimbangkan catatan berikut tentang bentuk:

* Sebuah bentuk (atau jalurnya) dapat **tertutup** atau **terbuka**.
* Bentuk tertutup tidak memiliki titik awal atau akhir; bentuk terbuka memiliki awal dan akhir.
* Setiap bentuk memiliki setidaknya dua titik jangkar yang dihubungkan oleh segmen garis.
* Sebuah segmen bisa lurus atau melengkung; titik jangkar menentukan sifat segmen.
* Titik jangkar dapat berupa **corner**, **smooth**, atau **straight**:
  * Titik **corner** adalah tempat dua segmen lurus bertemu pada sebuah sudut.
  * Titik **smooth** memiliki dua pegangan yang kolinear, dan segmen yang bersebelahan membentuk lengkungan halus. Dalam hal ini, kedua pegangan berada pada jarak yang sama dari titik jangkar.
  * Titik **straight** juga memiliki dua pegangan kolinear, dan segmen yang bersebelahan membentuk lengkungan halus. Dalam hal ini, pegangan tidak harus berada pada jarak yang sama dari titik jangkar.
* Dengan memindahkan atau menyunting titik jangkar (sehingga mengubah sudut segmen), Anda dapat mengubah penampilan bentuk.

Untuk menyunting bentuk PowerPoint, Aspose.Slides menyediakan kelas [GeometryPath](https://reference.aspose.com/slides/id/python-net/aspose.slides/geometrypath/) .

* Sebuah instance [GeometryPath](https://reference.aspose.com/slides/id/python-net/aspose.slides/geometrypath/) mewakili jalur geometris dari sebuah objek [GeometryShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/geometryshape/) .
* Untuk mengambil [GeometryPath](https://reference.aspose.com/slides/id/python-net/aspose.slides/geometrypath/) dari instance [GeometryShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/geometryshape/) , gunakan metode [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/id/python-net/aspose.slides/geometryshape/get_geometry_paths/) .
* Untuk menetapkan [GeometryPath](https://reference.aspose.com/slides/id/python-net/aspose.slides/geometrypath/) pada sebuah bentuk, gunakan [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/id/python-net/aspose.slides/geometryshape/set_geometry_path/) untuk *bentuk padat* dan [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/id/python-net/aspose.slides/geometryshape/set_geometry_paths/) untuk *bentuk komposit*.
* Untuk menambahkan segmen, gunakan metode pada [GeometryPath](https://reference.aspose.com/slides/id/python-net/aspose.slides/geometrypath/) .
* Gunakan properti [GeometryPath.stroke](https://reference.aspose.com/slides/id/python-net/aspose.slides/geometrypath/stroke/) dan [GeometryPath.fill_mode](https://reference.aspose.com/slides/id/python-net/aspose.slides/geometrypath/fill_mode/) untuk mengontrol tampilan jalur geometris.
* Gunakan properti [GeometryPath.path_data](https://reference.aspose.com/slides/id/python-net/aspose.slides/geometrypath/path_data/) untuk mengambil jalur geometris sebuah bentuk sebagai array segmen jalur.

## **Operasi Penyuntingan Sederhana**

Metode berikut digunakan untuk operasi penyuntingan sederhana.

**Tambahkan garis** ke akhir jalur:

```py
line_to(point)
line_to(x, y)
```

**Tambahkan garis** pada posisi tertentu dalam jalur:

```py    
line_to(point, index)
line_to(x, y, index)
```

**Tambahkan kurva Bezier kubik** ke akhir jalur:

```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```

**Tambahkan kurva Bezier kubik** pada posisi tertentu dalam jalur:

```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```

**Tambahkan kurva Bezier kuadratik** ke akhir jalur:

```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```

**Tambahkan kurva Bezier kuadratik** pada posisi tertentu dalam jalur:

```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```

**Tambahkan sebuah busur** ke jalur:

```py
arc_to(width, heigth, startAngle, sweepAngle)
```

**Tutup bentuk saat ini** dalam jalur:

```py
close_figure()
```

**Atur posisi untuk titik berikutnya**:

```py
move_to(point)
move_to(x, y)
```

**Hapus segmen jalur** pada indeks tertentu:

```py
remove_at(index)
```

## **Tambahkan Titik Kustom ke Bentuk**

Di sini Anda akan belajar cara mendefinisikan bentuk bebas dengan menambahkan urutan titik Anda sendiri. Dengan menentukan titik yang berurutan dan jenis segmen (lurus atau melengkung) serta secara opsional menutup jalur, Anda dapat menggambar grafik kustom yang presisi—poligon, ikon, balon penjelas, atau logo—langsung pada slide Anda.

1. Buat sebuah instance kelas [GeometryShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/geometryshape/) dan atur [ShapeType.RECTANGLE](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapetype/) .
2. Dapatkan sebuah instance [GeometryPath](https://reference.aspose.com/slides/id/python-net/aspose.slides/geometrypath/) dari bentuk.
3. Sisipkan titik baru di antara dua titik atas pada jalur.
4. Sisipkan titik baru di antara dua titik bawah pada jalur.
5. Terapkan jalur yang diperbarui ke bentuk.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)

    presentation.save("custom_points.pptx", slides.export.SaveFormat.PPTX)
```

![Titik kustom](custom_shape_1.png)

## **Hapus Titik dari Bentuk**

Terkadang sebuah bentuk kustom berisi titik yang tidak diperlukan yang mempersulit geometri atau memengaruhi cara tampilannya. Bagian ini menunjukkan cara menghapus titik tertentu dari jalur bentuk sehingga Anda dapat menyederhanakan kontur dan mencapai hasil yang lebih bersih dan presisi.

1. Buat sebuah instance kelas [GeometryShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/geometryshape/) dan atur tipe [ShapeType.HEART](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapetype/) .
2. Dapatkan sebuah instance [GeometryPath](https://reference.aspose.com/slides/id/python-net/aspose.slides/geometrypath/) dari bentuk.
3. Hapus sebuah segmen dari jalur.
4. Terapkan jalur yang diperbarui ke bentuk.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)

    presentation.save("removed_points.pptx", slides.export.SaveFormat.PPTX)
```

![Titik yang dihapus](custom_shape_2.png)

## **Buat Bentuk Kustom**

Buat bentuk vektor khusus dengan mendefinisikan sebuah [GeometryPath](https://reference.aspose.com/slides/id/python-net/aspose.slides/geometrypath/) dan menyusunnya dari garis, busur, dan kurva Bézier. Bagian ini menunjukkan cara membuat geometri kustom dari awal dan menambahkan bentuk yang dihasilkan ke slide Anda.

1. Hitung titik-titik untuk bentuk.
2. Buat sebuah instance kelas [GeometryPath](https://reference.aspose.com/slides/id/python-net/aspose.slides/geometrypath/) .
3. Isi jalur dengan titik-titik tersebut.
4. Buat sebuah instance kelas [GeometryShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/geometryshape/) .
5. Terapkan jalur ke bentuk.

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

R = 100
r = 50
step = 72

for angle in range(-90, 270, step):
    radians = angle * (math.pi / 180)
    x = R * math.cos(radians)
    y = R * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

    radians = math.pi * (angle + step / 2) / 180.0
    x = r * math.cos(radians)
    y = r * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, R * 2, R * 2)
    shape.set_geometry_path(star_path)

    presentation.save("custom_shape.pptx", slides.export.SaveFormat.PPTX)
```

![Bentuk kustom](custom_shape_3.png)

## **Buat Bentuk Kustom Komposit**

Membuat bentuk kustom komposit memungkinkan Anda menggabungkan beberapa jalur geometri menjadi satu bentuk yang dapat digunakan kembali pada slide. Definisikan dan gabungkan jalur-jalur ini untuk membangun visual kompleks yang melampaui set bentuk standar.

1. Buat sebuah instance kelas [GeometryShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/geometryshape/) .
2. Buat instance pertama dari kelas [GeometryPath](https://reference.aspose.com/slides/id/python-net/aspose.slides/geometrypath/) .
3. Buat instance kedua dari kelas [GeometryPath](https://reference.aspose.com/slides/id/python-net/aspose.slides/geometrypath/) .
4. Terapkan kedua jalur ke bentuk.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path_0 = slides.GeometryPath()
    geometry_path_0.move_to(0, 0)
    geometry_path_0.line_to(shape.width, 0)
    geometry_path_0.line_to(shape.width, shape.height/3)
    geometry_path_0.line_to(0, shape.height / 3)
    geometry_path_0.close_figure()

    geometry_path_1 = slides.GeometryPath()
    geometry_path_1.move_to(0, shape.height/3 * 2)
    geometry_path_1.line_to(shape.width, shape.height / 3 * 2)
    geometry_path_1.line_to(shape.width, shape.height)
    geometry_path_1.line_to(0, shape.height)
    geometry_path_1.close_figure()

    shape.set_geometry_paths([ geometry_path_0, geometry_path_1])

    presentation.save("composite_shape.pptx", slides.export.SaveFormat.PPTX)
```

![Bentuk komposit](custom_shape_4.png)

## **Buat Bentuk Kustom dengan Sudut Melengkung**

Bagian ini menunjukkan cara menggambar bentuk kustom dengan sudut melengkung secara halus menggunakan jalur geometri. Anda akan menggabungkan segmen lurus dan busur melingkar untuk membentuk kontur dan menambahkan bentuk selesai ke slide Anda.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(
        slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    point1 = draw.PointF(left_top_size, 0)
    point2 = draw.PointF(shape_width - right_top_size, 0)
    point3 = draw.PointF(shape_width, shape_height - right_bottom_size)
    point4 = draw.PointF(left_bottom_size, shape_height)
    point5 = draw.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(point1)
    geometry_path.line_to(point2)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(point3)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(point4)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(point5)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("curved_corners.pptx", slides.export.SaveFormat.PPTX)
```

![Sudut melengkung](custom_shape_6.png)

## **Tentukan Apakah Geometri Bentuk Tertutup**

Suatu bentuk tertutup didefinisikan sebagai bentuk di mana semua sisinya terhubung, membentuk satu batas tanpa celah. Bentuk semacam itu dapat berupa bentuk geometris sederhana atau kontur kustom yang kompleks. Contoh kode berikut menunjukkan cara memeriksa apakah geometri sebuah bentuk tertutup:

```py
def is_geometry_closed(geometry_shape):
    is_closed = None

    for geometry_path in geometry_shape.get_geometry_paths():
        data_length = len(geometry_path.path_data)
        if data_length == 0:
            continue

        last_segment = geometry_path.path_data[data_length - 1]
        is_closed = last_segment.path_command == PathCommandType.CLOSE

        if not is_closed:
            return False

    return is_closed
```

## **FAQ**

**Apa yang akan terjadi pada isian dan garis tepi setelah mengganti geometri?**

Gaya tetap menyertai bentuk; hanya kontur yang berubah. Isian dan garis tepi secara otomatis diterapkan pada geometri baru.

**Bagaimana cara memutar bentuk kustom bersama geometri secara benar?**

Gunakan properti [rotation](https://reference.aspose.com/slides/id/python-net/aspose.slides/geometryshape/rotation/) pada bentuk; geometri berputar bersama bentuk karena terikat pada sistem koordinat bentuk itu sendiri.

**Bisakah saya mengonversi bentuk kustom menjadi gambar untuk "mengunci" hasilnya?**

Ya. Ekspor area [slide](/slides/id/python-net/convert-powerpoint-to-png/) yang diperlukan atau [bentuk](/slides/id/python-net/create-shape-thumbnails/) itu sendiri ke format raster; ini menyederhanakan pekerjaan lanjutan dengan geometri yang kompleks.