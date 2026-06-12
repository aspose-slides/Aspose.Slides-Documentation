---
title: Mengelola Objek Tinta dalam Presentasi dengan Python
linktitle: Mengelola Tinta
type: docs
weight: 95
url: /id/python-net/manage-ink/
keywords:
- tinta
- objek tinta
- jejak tinta
- kelola tinta
- gambar tinta
- menggambar
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Kelola objek tinta PowerPoint—buat, edit & gaya tinta digital dengan Aspose.Slides untuk Python via .NET. Dapatkan contoh kode untuk jejak, warna kuas & ukuran."
---
## **Pendahuluan**

PowerPoint menyediakan fungsi tinta yang memungkinkan Anda menggambar bentuk non‑standar, yang dapat digunakan untuk menyorot objek lain, menunjukkan koneksi dan proses, serta menarik perhatian pada item tertentu di slide. 

Aspose.Slides menyediakan namespace [aspose.slides.ink](https://reference.aspose.com/slides/id/python-net/aspose.slides.ink/) , yang berisi tipe‑tipe yang Anda perlukan untuk membuat dan mengelola objek tinta. 

## **Perbedaan antara Objek Biasa dan Objek Tinta**

Objek pada slide PowerPoint biasanya direpresentasikan oleh objek shape. Sebuah objek shape, dalam bentuk paling sederhana, adalah sebuah kontainer yang menentukan area objek itu sendiri (frame‑nya) beserta propertinya. Yang terakhir mencakup ukuran area kontainer, bentuk kontainer, latar belakang kontainer, dll. Untuk informasi, lihat [Shape Layout Format](https://docs.aspose.com/slides/id/python-net/shape-manipulations/#access-layout-formats-for-shape).

Namun, ketika PowerPoint menangani objek tinta, ia mengabaikan semua properti frame objek (kontainer) kecuali ukurannya. Ukuran area kontainer ditentukan oleh nilai standar `width` dan `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Jejak Inkshape**

Jejak adalah elemen dasar atau standar yang digunakan untuk merekam lintasan pena saat pengguna menulis tinta digital. Jejak adalah rekaman yang menggambarkan urutan titik‑titik yang terhubung. 

Bentuk enkoding paling sederhana menentukan koordinat X dan Y dari setiap titik sampel. Ketika semua titik yang terhubung dirender, mereka menghasilkan gambar seperti ini:

![ink_powerpoint2](ink_powerpoint2.png)

## **Properti Kuas untuk Menggambar**

Anda dapat menggunakan kuas untuk menggambar garis yang menghubungkan titik‑titik elemen jejak. Kuas memiliki warna dan ukuran sendiri, yang sesuai dengan properti `Brush.color` dan `Brush.size`. 

### **Atur Warna Kuas Tinta**

Kode Python ini menunjukkan cara mengatur warna untuk kuas:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_color = brush.color
    brush.color = draw.Color.red
```

### **Atur Ukuran Kuas Tinta** 

Kode Python ini menunjukkan cara mengatur ukuran untuk kuas:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_size = brush.size
    brush.size = draw.SizeF(5.0, 10.0)
```

Umumnya, lebar dan tinggi kuas tidak cocok, sehingga PowerPoint tidak menampilkan ukuran kuas (bagian data berwarna abu‑abu). Namun ketika lebar dan tinggi kuas cocok, PowerPoint menampilkan ukurannya seperti ini:

![ink_powerpoint3](ink_powerpoint3.png)

Untuk kejelasan, mari tingkatkan tinggi objek tinta dan tinjau dimensi penting:

![ink_powerpoint4](ink_powerpoint4.png)

Kontainer (frame) tidak memperhitungkan ukuran kuas—selalu menganggap ketebalan garis adalah nol (lihat gambar terakhir). 

Oleh karena itu, untuk menentukan area yang terlihat dari seluruh objek tinta, kita harus mempertimbangkan ukuran kuas pada objek jejak. Di sini, objek target (objek jejak teks tulisan tangan) telah diskalakan ke ukuran kontainer (frame). Ketika ukuran kontainer (frame) berubah, ukuran kuas tetap konstan dan sebaliknya. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint menunjukkan perilaku yang sama saat menangani teks:

![ink_powerpoint6](ink_powerpoint6.png)

**Bacaan Lanjutan**

* Untuk membaca tentang shape secara umum, lihat bagian [PowerPoint Shapes](https://docs.aspose.com/slides/id/python-net/powerpoint-shapes/). 
* Untuk informasi lebih lanjut tentang nilai efektif, lihat [Shape Effective Properties](https://docs.aspose.com/slides/id/python-net/shape-effective-properties/#get-effective-font-height-value).