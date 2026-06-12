---
title: Kelola Bentuk dalam Presentasi Menggunakan Python
linktitle: Manipulasi Bentuk
type: docs
weight: 40
url: /id/python-net/shape-manipulations/
keywords:
- Bentuk PowerPoint
- Bentuk presentasi
- Bentuk pada slide
- temukan bentuk
- klon bentuk
- hapus bentuk
- sembunyikan bentuk
- ubah urutan bentuk
- dapatkan ID bentuk interop
- teks alternatif bentuk
- format tata letak bentuk
- bentuk sebagai SVG
- bentuk ke SVG
- rata bentuk
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara membuat, mengedit, dan mengoptimalkan bentuk dalam Aspose.Slides untuk Python melalui .NET serta menghasilkan presentasi PowerPoint dan OpenDocument dengan kinerja tinggi."
---
## **Gambaran Umum**

Panduan ini memperkenalkan manipulasi bentuk dalam Aspose.Slides untuk Python melalui .NET. Pelajari pola praktis untuk menemukan bentuk (termasuk melalui Teks Alternatif), menduplikasi, menghapus atau menyembunyikan, mengubah urutan, meratakan dan memutar, membaca ID dan pemformatan berbasis tata letak, serta mengekspor bentuk individu ke SVG menggunakan API [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dan [Shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/).

## **Temukan Bentuk di Slide**

PowerPoint mengidentifikasi bentuk hanya berdasarkan ID internal. Tetapkan Teks Alternatif yang unik pada bentuk target di PowerPoint, kemudian buka presentasi dengan Aspose.Slides untuk Python, iterasi bentuk-bentuk slide, dan pilih yang Teks Alternatifnya cocok. Metode `find_shape` mengimplementasikan pendekatan ini dan mengembalikan bentuk yang cocok.

```py
import aspose.slides as slides

# Menemukan sebuah bentuk pada slide berdasarkan teks alternatifnya.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Membuat instance kelas Presentation yang merepresentasikan file presentasi.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Temukan bentuk dengan Teks Alternatif "Shape1".
    shape = find_shape(slide, "Shape1")
    if shape is not None:
        print("Shape name:", shape.name)
```

## **Klon Bentuk**

Untuk mengklon bentuk dari slide sumber ke slide baru dalam Aspose.Slides, ikuti langkah-langkah berikut:

1. Buat sebuah [Presentation] dari file sumber.
1. Dapatkan slide sumber berdasarkan indeks dan koleksi bentuknya.
1. Ambil tata letak kosong dari slide master.
1. Tambahkan slide kosong menggunakan tata letak tersebut dan dapatkan bentuk-bentuknya.
1. Klon bentuk ke slide target.
1. Simpan presentasi sebagai PPTX.

Contoh kode berikut mengklon bentuk dari satu slide ke slide lain.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation.
with slides.Presentation("sample.pptx") as presentation:
    source_shapes = presentation.slides[0].shapes
    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    target_slide = presentation.slides.add_empty_slide(blank_layout)
    target_shapes = target_slide.shapes
	
    target_shapes.add_clone(source_shapes[1], 50, 150 + source_shapes[0].height)
    target_shapes.add_clone(source_shapes[2])
    target_shapes.insert_clone(0, source_shapes[0], 50, 150)

    # Simpan presentasi ke disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Hapus Bentuk**

Aspose.Slides memungkinkan Anda menghapus bentuk apa pun dari slide. Misalnya, untuk menghapus bentuk dari slide pertama berdasarkan Teks Alternatifnya, ikuti langkah-langkah berikut:

1. Buat sebuah [Presentation] dan muat file.
1. Akses slide pertama dari koleksi slide.
1. Temukan bentuk berdasarkan nilai Teks Alternatif.
1. Hapus bentuk dari koleksi bentuk slide.
1. Simpan presentasi ke disk dalam format PPTX.

```py
import aspose.slides as slides

# Menemukan sebuah bentuk pada slide berdasarkan teks alternatifnya.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Membuat instance kelas Presentation yang merepresentasikan file presentasi.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Temukan bentuk dengan Teks Alternatif "User Defined".
    shape = find_shape(slide, "User Defined")
    # Hapus bentuk.
    slide.shapes.remove(shape)
    # Simpan presentasi ke disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Sembunyikan Bentuk**

Aspose.Slides memungkinkan Anda menyembunyikan bentuk apa pun pada slide. Misalnya, untuk menyembunyikan bentuk pada slide pertama berdasarkan Teks Alternatifnya, ikuti langkah-langkah berikut:

1. Buat sebuah [Presentation] dan muat file.
1. Akses slide pertama dari koleksi slide.
1. Temukan bentuk berdasarkan nilai Teks Alternatif.
1. Sembunyikan bentuk.
1. Simpan presentasi ke disk dalam format PPTX.

```py
# Menemukan sebuah bentuk pada slide berdasarkan teks alternatifnya.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Membuat instance kelas Presentation yang merepresentasikan file presentasi.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Temukan bentuk dengan Teks Alternatif "User Defined".
    shape = find_shape(slide, "User Defined")
    # Sembunyikan bentuk.
    shape.hidden = True
    # Simpan presentasi ke disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ubah Urutan Bentuk**

Aspose.Slides memungkinkan pengembang mengubah urutan bentuk (mengubah z-order). Mengubah urutan menentukan bentuk mana yang muncul di depan atau di belakang. Misalnya, untuk mengubah urutan dua bentuk pada slide pertama, ikuti langkah-langkah di bawah ini:

1. Buat instance kelas [Presentation].
1. Akses slide pertama.
1. Tambahkan bentuk pertama (misalnya, persegi panjang).
1. Tambahkan bentuk kedua (misalnya, segitiga).
1. Ubah urutan bentuk dengan memindahkan bentuk kedua ke posisi pertama dalam koleksi.
1. Simpan presentasi ke disk.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Tambahkan dua bentuk ke slide.
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 150)
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 20, 200, 200, 150)
    # Pindahkan bentuk kedua ke posisi pertama.
    slide.shapes.reorder(0, shape2)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Dapatkan ID Bentuk Interop**

Aspose.Slides memungkinkan Anda memperoleh pengidentifikasi unik sebuah bentuk pada tingkat slide, berbeda dengan properti `unique_id` yang unik di seluruh presentasi. Properti `office_interop_shape_id` tersedia pada kelas [Shape]. Nilainya sesuai dengan `Id` dari objek `Microsoft.Office.Interop.PowerPoint.Shape`. Contoh kode sampel ditampilkan di bawah.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Dapatkan pengidentifikasi unik bentuk dalam slide.
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```

## **Setel Teks Alternatif untuk Bentuk**

Aspose.Slides memungkinkan pengembang menambahkan teks alternatif untuk bentuk apa pun. Anda dapat menggunakan teks alternatif untuk mengidentifikasi dan menemukan bentuk dalam presentasi. Properti teks alternatif dapat dibaca dan ditulis melalui Aspose.Slides maupun Microsoft PowerPoint. Dengan menandai bentuk menggunakan properti ini, Anda dapat kemudian menghapus, menyembunyikan, atau mengubah urutannya pada slide.

Untuk menetapkan teks alternatif sebuah bentuk, ikuti langkah-langkah berikut:

1. Buat instance kelas [Presentation].
1. Akses slide pertama.
1. Tambahkan sebuah bentuk ke slide.
1. Setel teks alternatif.
1. Simpan presentasi ke disk.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation yang merepresentasikan file PPTX.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    # Tambahkan sebuah bentuk.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    # Atur teks alternatif untuk bentuk.
    shape.alternative_text = "User Defined"
    # Simpan presentasi ke disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Akses Format Tata Letak untuk Bentuk**

Aspose.Slides menyediakan API sederhana untuk mengakses format tata letak bentuk. Bagian ini menunjukkan cara mengakses format tata letak.

```py
import aspose.slides as slides

with slides.Presentation(folder_path + "sample.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        fill_formats = list(map(lambda shape: shape.fill_format, layout_slide.shapes))
        line_formats = list(map(lambda shape: shape.line_format, layout_slide.shapes))
```

## **Render Bentuk sebagai SVG**

Aspose.Slides mendukung rendering bentuk sebagai SVG. Metode `write_as_svg` (dan overload-nya) pada kelas [Shape] memungkinkan Anda menyimpan konten bentuk sebagai gambar SVG. Potongan kode di bawah ini menunjukkan cara mengekspor bentuk ke file SVG.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    with open("output.svg", "wb") as image_stream:
        # Dapatkan bentuk pertama pada slide pertama.
        shape = presentation.slides[0].shapes[0]
        shape.write_as_svg(image_stream)
```

## **Ratakan Bentuk**

Dengan menggunakan metode `align_shape` dalam kelas [SlidesUtil], Anda dapat:

* Merapatkan bentuk relatif terhadap margin slide (lihat **Contoh 1**).
* Merapatkan bentuk relatif terhadap satu sama lain (lihat **Contoh 2**).

Enumerasi [ShapesAlignmentType] mendefinisikan opsi perataan yang tersedia.

**Contoh 1**

Kode Python ini menunjukkan cara meratakan bentuk dengan indeks 1, 2, dan 4 ke tepi atas slide:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_TOP
slide_indices = [1, 2, 4]

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    slides.util.SlideUtil.align_shapes(align_type, True, slide, slide_indices)
```

**Contoh 2**

Contoh Python ini menunjukkan cara meratakan semua bentuk dalam sebuah koleksi relatif terhadap bentuk paling bawah dalam koleksi tersebut:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_BOTTOM

with slides.Presentation("sample.pptx") as presentation:
    slides.util.SlideUtil.align_shapes(align_type, False, presentation.slides[0])
```

## **Properti Flip**

Dalam Aspose.Slides, kelas [ShapeFrame] menyediakan kontrol atas pencerminan horizontal dan vertikal bentuk melalui properti `flip_h` dan `flip_v`. Kedua properti bertipe [NullableBool], memungkinkan nilai `TRUE` untuk menunjukkan flip, `FALSE` untuk tidak flip, atau `NOT_DEFINED` untuk menggunakan perilaku default. Nilai-nilai ini dapat diakses dari [Frame] bentuk.

Untuk mengubah pengaturan flip, sebuah instance baru [ShapeFrame] dibangun dengan posisi dan ukuran saat ini dari bentuk, nilai yang diinginkan untuk `flip_h` dan `flip_v`, serta sudut rotasi. Menetapkan instance ini ke [Frame] bentuk dan menyimpan presentasi menerapkan transformasi cermin dan menuliskannya ke file output.

Misalkan kami memiliki file sample.pptx di mana slide pertama berisi satu bentuk dengan pengaturan flip default, seperti gambar di bawah.

![Bentuk yang akan diputar](shape_to_be_flipped.png)

Contoh kode berikut mengambil properti flip bentuk saat ini dan memflipnya baik secara horizontal maupun vertikal.

```py
with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    # Dapatkan properti flip horizontal dari bentuk.
    horizontal_flip = shape.frame.flip_h
    print("Horizontal flip:", horizontal_flip)

    # Dapatkan properti flip vertikal dari bentuk.
    vertical_flip = shape.frame.flip_v
    print("Vertical flip:", vertical_flip)

    x, y = shape.frame.x, shape.frame.y
    width, height = shape.frame.width, shape.frame.height
    flip_h, flip_v = slides.NullableBool.TRUE, slides.NullableBool.TRUE  # Flip secara horizontal dan vertikal.
    rotation = shape.frame.rotation

    shape.frame = slides.ShapeFrame(x, y, width, height, flip_h, flip_v, rotation)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![Bentuk yang diputar](flipped_shape.png)

## **FAQ**

**Apakah saya dapat menggabungkan bentuk (union/intersect/subtract) pada slide seperti di editor desktop?**

Tidak ada API operasi Boolean bawaan. Anda dapat memperkirakannya dengan membangun outline yang diinginkan sendiri—misalnya, menghitung geometri hasil (via [GeometryPath]) dan membuat bentuk baru dengan kontur tersebut, opsional menghapus yang asli.

**Bagaimana cara mengontrol urutan tumpukan (z-order) sehingga sebuah bentuk selalu berada “di atas”?**

Ubah urutan penyisipan/perpindahan dalam koleksi [shapes] slide. Untuk hasil yang dapat diprediksi, finalisasi z-order setelah semua modifikasi slide lainnya.

**Apakah saya dapat “mengunci” sebuah bentuk agar pengguna tidak dapat mengeditnya di PowerPoint?**

Ya. Setel flag perlindungan tingkat bentuk ([shape-level protection flags]) (misalnya, kunci pemilihan, perpindahan, perubahan ukuran, pengeditan teks). Jika diperlukan, terapkan pembatasan pada master atau layout. Perlu dicatat bahwa ini adalah perlindungan level UI, bukan fitur keamanan; untuk perlindungan lebih kuat, gabungkan dengan pembatasan tingkat file seperti rekomendasi baca-saja atau sandi.