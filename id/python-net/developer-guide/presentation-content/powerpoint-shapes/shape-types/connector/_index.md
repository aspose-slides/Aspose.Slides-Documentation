---
title: Kelola Penghubung dalam Presentasi dengan Python
linktitle: Penghubung
type: docs
weight: 10
url: /id/python-net/connector/
keywords:
- penghubung
- tipe penghubung
- titik penghubung
- garis penghubung
- sudut penghubung
- sambungkan bentuk
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Berikan kemampuan pada aplikasi Python untuk menggambar, menyambungkan, dan mengatur otomatis jalur garis pada slide PowerPoint & OpenDocument—dapatkan kontrol penuh atas penghubung lurus, siku, dan melengkung."
---
## **Pendahuluan**

Penghubung PowerPoint adalah garis khusus yang menghubungkan dua bentuk dan tetap melekat ketika bentuk tersebut dipindahkan atau diposisikan ulang pada slide. Penghubung menempel pada **titik sambungan** (titik hijau) pada bentuk. Titik sambungan muncul ketika penunjuk mendekatinya. **Pegangan penyesuaian** (titik kuning), yang tersedia pada penghubung tertentu, memungkinkan Anda mengubah posisi dan bentuk penghubung.

## **Jenis Penghubung**

Di PowerPoint, Anda dapat menggunakan tiga jenis penghubung: lurus, siku (berpaut sudut), dan melengkung.  
Aspose.Slides mendukung tipe penghubung berikut:

| Tipe Penghubung                  | Gambar                                                     | Jumlah titik penyesuaian |
| ------------------------------- | --------------------------------------------------------- | ------------------------ |
| `ShapeType.LINE`                | ![Penghubung Garis](shapetype-lineconnector.png)            | 0                        |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![Penghubung Lurus 1](shapetype-straightconnector1.png) | 0                        |
| `ShapeType.BENT_CONNECTOR2`     | ![Penghubung Bengkok 2](shapetype-bent-connector2.png)        | 0                        |
| `ShapeType.BENT_CONNECTOR3`     | ![Penghubung Bengkok 3](shapetype-bentconnector3.png)         | 1                        |
| `ShapeType.BENT_CONNECTOR4`     | ![Penghubung Bengkok 4](shapetype-bentconnector4.png)         | 2                        |
| `ShapeType.BENT_CONNECTOR5`     | ![Penghubung Bengkok 5](shapetype-bentconnector5.png)         | 3                        |
| `ShapeType.CURVED_CONNECTOR2`   | ![Penghubung Lengkung 2](shapetype-curvedconnector2.png)     | 0                        |
| `ShapeType.CURVED_CONNECTOR3`   | ![Penghubung Lengkung 3](shapetype-curvedconnector3.png)     | 1                        |
| `ShapeType.CURVED_CONNECTOR4`   | ![Penghubung Lengkung 4](shapetype-curvedconnector4.png)     | 2                        |
| `ShapeType.CURVED_CONNECTOR5`   | ![Penghubung Lengkung 5](shapetype.curvedconnector5.png)     | 3                        |

## **Hubungkan Bentuk dengan Penghubung**

Bagian ini menunjukkan cara menghubungkan bentuk dengan penghubung di Aspose.Slides. Anda akan menambahkan penghubung ke slide, menempelkan awal dan akhir ke bentuk target. Menggunakan situs sambungan memastikan penghubung tetap "menempel" pada bentuk bahkan ketika mereka dipindahkan atau diubah ukurannya.

1. Buat sebuah instance dari kelas [Presentasi](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan dua objek [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) ke slide menggunakan metode `add_auto_shape` yang tersedia pada objek [ShapeCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/) .
4. Tambahkan sebuah penghubung menggunakan metode `add_connector` yang tersedia pada objek [ShapeCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/) dan tentukan tipe penghubung.
5. Hubungkan bentuk-bentuk dengan penghubung.
6. Panggil metode `reroute` untuk menerapkan jalur sambungan terpendek.
7. Simpan presentasi.

```python
import aspose.slides as slides

# Membuat instance kelas Presentation untuk membuat file PPTX.
with slides.Presentation() as presentation:

    # Akses koleksi bentuk pada slide pertama.
    shapes = presentation.slides[0].shapes

    # Tambahkan AutoShape elips.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Tambahkan AutoShape persegi panjang.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Tambahkan penghubung ke slide.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # Sambungkan bentuk-bentuk dengan penghubung.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Panggil reroute untuk mengatur jalur terpendek.
    connector.reroute()

    # Simpan presentasi.
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Metode `connector.reroute` mengubah jalur penghubung, memaksanya mengambil jalur terpendek antara bentuk-bentuk. Untuk melakukan ini, metode dapat mengubah nilai `start_shape_connection_site_index` dan `end_shape_connection_site_index` .
{{% /alert %}}

## **Tentukan Titik Sambungan**

Bagian ini menjelaskan cara menempelkan penghubung ke titik sambungan tertentu pada sebuah bentuk di Aspose.Slides. Dengan menargetkan situs sambungan yang tepat, Anda dapat mengontrol jalur dan tata letak penghubung, menghasilkan diagram yang bersih dan dapat diprediksi dalam presentasi Anda.

1. Buat sebuah instance dari kelas [Presentasi](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan dua objek [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) ke slide menggunakan metode `add_auto_shape` yang tersedia pada objek [ShapeCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/) .
4. Tambahkan sebuah penghubung menggunakan metode `add_connector` pada objek [ShapeCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/) dan tentukan tipe penghubung.
5. Hubungkan bentuk-bentuk dengan penghubung.
6. Atur titik sambungan pilihan Anda pada bentuk-bentuk.
7. Simpan presentasi.

```python
import aspose.slides as slides

# Membuat instance kelas Presentation untuk membuat file PPTX.
with slides.Presentation() as presentation:

    # Akses koleksi bentuk pada slide pertama.
    shapes = presentation.slides[0].shapes

    # Tambahkan AutoShape elips.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Tambahkan AutoShape persegi panjang.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Tambahkan penghubung ke koleksi bentuk slide.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # Sambungkan bentuk-bentuk dengan penghubung.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Atur indeks situs sambungan pilihan pada elips.
    site_index = 6

    # Periksa apakah indeks pilihan berada dalam jumlah situs yang tersedia.
    if  ellipse.connection_site_count > site_index:
        # Tetapkan situs sambungan pilihan pada AutoShape elips.
        connector.start_shape_connection_site_index = site_index

    # Simpan presentasi.
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **Sesuaikan Titik Penghubung**

Anda dapat memodifikasi penghubung menggunakan titik penyesuaian mereka. Hanya penghubung yang menyediakan titik penyesuaian yang dapat diedit dengan cara ini. Untuk detail tentang penghubung mana yang mendukung penyesuaian, lihat tabel di bawah [Jenis Penghubung](/slides/id/python-net/connector/#connector-types).

### **Kasus Sederhana**

Pertimbangkan kasus di mana sebuah penghubung antara dua bentuk (A dan B) memotong bentuk ketiga (C):

![Penghalang Penghubung](connector-obstruction.png)

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)
    
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    
    connector.start_shape_connected_to = shape_from
    connector.end_shape_connected_to = shape_to
    connector.start_shape_connection_site_index = 2
```

Untuk menghindari bentuk ketiga, sesuaikan penghubung dengan memindahkan segmen vertikalnya ke kiri:

![Penghalang Penghubung yang Diperbaiki](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **Kasus Kompleks**

Untuk penyesuaian yang lebih maju, pertimbangkan hal berikut:

- Titik yang dapat disesuaikan pada penghubung diatur oleh sebuah formula yang menentukan posisinya. Mengubah titik ini dapat mengubah bentuk keseluruhan penghubung.
- Titik penyesuaian penghubung disimpan dalam array yang terurut secara ketat, diberi nomor dari awal penghubung hingga akhir.
- Nilai titik penyesuaian mewakili persentase lebar/tinggi bentuk penghubung.
  - Bentuk dibatasi oleh titik awal dan akhir penghubung serta diskalakan dengan faktor 1000.
  - Titik penyesuaian pertama, kedua, dan ketiga masing-masing mewakili: persentase lebar, persentase tinggi, dan persentase lebar (lagi).
- Saat menghitung koordinat titik penyesuaian, perhitungkan rotasi dan refleksi penghubung. **Catatan:** Untuk semua penghubung yang tercantum di bawah [Jenis Penghubung](/slides/id/python-net/connector/#connector-types), sudut rotasi adalah 0.

#### **Kasus 1**

Pertimbangkan kasus di mana dua objek bingkai teks dihubungkan dengan sebuah penghubung:

![Bentuk Terhubung](connector-shape-complex.png)

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Membuat instance kelas Presentation untuk membuat file PPTX.
with slides.Presentation() as presentation:

    # Dapatkan slide pertama.
    slide = presentation.slides[0]

    # Dapatkan slide pertama.
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # Tambahkan penghubung.
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # Atur arah penghubung.
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # Atur warna penghubung.
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # Atur ketebalan garis penghubung.
    connector.line_format.width = 3

    # Hubungkan bentuk-bentuk dengan penghubung.
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # Dapatkan titik penyesuaian penghubung.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**Penyesuaian**

Ubah nilai titik penyesuaian penghubung dengan meningkatkan persentase lebar sebesar 20% dan persentase tinggi sebesar 200%, masing-masing:

```python
    # Ubah nilai titik penyesuaian.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

Hasilnya:

![Penyesuaian Penghubung 1](connector-adjusted-1.png)

Untuk mendefinisikan model yang memungkinkan kita menentukan koordinat dan bentuk segmen penghubung, buat sebuah bentuk yang sesuai dengan komponen vertikal penghubung pada `connector.adjustments[0]`:

```python
    # Gambar komponen vertikal penghubung.
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

Hasilnya:

![Penyesuaian Penghubung 2](connector-adjusted-2.png)

#### **Kasus 2**

Pada **Kasus 1**, kami menunjukkan penyesuaian penghubung sederhana menggunakan prinsip dasar. Dalam skenario umum, Anda harus memperhitungkan rotasi penghubung dan pengaturan tampilan (dikendalikan oleh `connector.rotation`, `connector.frame.flip_h`, dan `connector.frame.flip_v`). Berikut cara prosesnya.

Pertama, tambahkan sebuah objek bingkai teks baru (**To 1**) ke slide (untuk sambungan), dan buat sebuah penghubung hijau baru yang menghubungkannya ke objek yang ada.

```python
    # Buat objek target baru.
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    # Buat penghubung baru.
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    # Hubungkan objek-objek menggunakan penghubung yang baru dibuat.
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # Dapatkan titik penyesuaian penghubung.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # Ubah nilai titik penyesuaian.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

Hasilnya:

![Penyesuaian Penghubung 3](connector-adjusted-3.png)

Kedua, buat sebuah bentuk yang sesuai dengan segmen **horizontal** penghubung yang melewati titik penyesuaian penghubung baru, `connector.adjustments[0]`. Gunakan nilai dari `connector.rotation`, `connector.frame.flip_h`, dan `connector.frame.flip_v`, serta terapkan formula konversi koordinat standar untuk rotasi sekitar titik tertentu `x0`:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Dalam kasus kami, sudut rotasi objek adalah 90 derajat dan penghubung ditampilkan secara vertikal, sehingga kode yang sesuai adalah:

```python
    # Simpan koordinat penghubung.
    x = connector.x
    y = connector.y
    
    # Perbaiki koordinat penghubung jika dibalik.
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # Gunakan nilai titik penyesuaian sebagai koordinat.
    x += connector.width * adjValue_0.raw_value / 100000
    
    # Konversi koordinat karena sin(90°) = 1 dan cos(90°) = 0.
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # Tentukan lebar segmen horizontal menggunakan nilai titik penyesuaian kedua.
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

Hasilnya:

![Penyesuaian Penghubung 4](connector-adjusted-4.png)

Kami mendemonstrasikan perhitungan yang melibatkan penyesuaian sederhana dan titik penyesuaian yang lebih kompleks (yang memperhitungkan rotasi). Dengan pengetahuan ini, Anda dapat mengembangkan model Anda sendiri—atau menulis kode—untuk memperoleh objek `GraphicsPath` atau bahkan mengatur nilai titik penyesuaian penghubung berdasarkan koordinat slide tertentu.

## **Temukan Sudut Garis Penghubung**

Gunakan contoh di bawah untuk menentukan sudut garis penghubung pada slide dengan Aspose.Slides. Anda akan belajar cara membaca titik akhir penghubung dan menghitung orientasinya sehingga Anda dapat menyelaraskan panah, label, dan bentuk lainnya dengan tepat.

1. Buat sebuah instance dari kelas [Presentasi](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeks.
3. Akses bentuk garis penghubung.
4. Gunakan lebar dan tinggi garis, serta lebar dan tinggi bingkai bentuk, untuk menghitung sudutnya.

```python
import aspose.slides as slides
import math

def get_direction(w, h, flip_h, flip_v):
    end_line_x = w * (-1 if flip_h else 1)
    end_line_y = h * (-1 if flip_v else 1)
    end_y_axis_x = 0
    end_y_axis_y = h
    angle = math.atan2(end_y_axis_y, end_y_axis_x) - math.atan2(end_line_y, end_line_x)
    if (angle < 0):
         angle += 2 * math.pi
    return angle * 180.0 / math.pi

with slides.Presentation("connector_line_angle.pptx") as presentation:
    slide = presentation.slides[0]
    for shape_index in range(len(slide.shapes)):
        direction = 0.0
        shape = slide.shapes[shape_index]
        if type(shape) is slides.AutoShape and shape.shape_type == slides.ShapeType.LINE:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        elif type(shape) is slides.Connector:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        print(direction)
```

## **FAQ**

**Bagaimana saya dapat mengetahui apakah sebuah penghubung dapat "menempel" pada bentuk tertentu?**  
Periksa apakah bentuk tersebut menyediakan [situs sambungan](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/connection_site_count/). Jika tidak ada atau jumlahnya nol, penempelan tidak tersedia; dalam hal ini, gunakan titik akhir bebas dan posisikan secara manual. Sebaiknya periksa jumlah situs sebelum menempelkan.

**Apa yang terjadi pada penghubung jika saya menghapus salah satu bentuk yang terhubung?**  
Ujung-ujungnya akan terlepas; penghubung tetap berada di slide sebagai garis biasa dengan awal/akhir bebas. Anda dapat menghapusnya atau menetapkan kembali sambungan dan, jika diperlukan, [reroute](https://reference.aspose.com/slides/id/python-net/aspose.slides/connector/reroute/) .

**Apakah ikatan penghubung tetap terjaga saat menyalin slide ke presentasi lain?**  
Umumnya ya, asalkan bentuk target juga disalin. Jika slide dimasukkan ke file lain tanpa bentuk yang terhubung, ujung-ujungnya menjadi bebas dan Anda harus menempelkannya kembali.