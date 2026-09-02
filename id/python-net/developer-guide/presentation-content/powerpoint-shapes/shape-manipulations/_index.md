---
title: Kelola Bentuk Presentasi di Python
linktitle: Manipulasi Bentuk
type: docs
weight: 40
url: /id/python-net/shape-manipulations/
keywords:
- Bentuk PowerPoint
- Bentuk presentasi
- Bentuk pada slide
- Temukan bentuk
- Gandakan bentuk
- Hapus bentuk
- Sembunyikan bentuk
- Ubah urutan bentuk
- Dapatkan ID bentuk interop
- Teks alternatif bentuk
- Format tata letak bentuk
- Bentuk sebagai SVG
- Bentuk ke SVG
- Rata bentuk
- Balikkan bentuk
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara mengidentifikasi, menggandakan, menghapus, menyembunyikan, mengubah urutan, mengekspor, meratakan, dan membalik bentuk presentasi dengan Aspose.Slides untuk Python via .NET."
---
## **Gambaran Umum**

Aspose.Slides for Python via .NET merepresentasikan bentuk pada slide sebagai [ShapeCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/). Koleksi ini sekaligus merupakan tempat Anda menemukan dan memodifikasi bentuk serta sumber urutan penumpukannya: indeks `0` adalah bentuk paling belakang, sedangkan indeks terakhir adalah bentuk paling depan.

Artikel ini mengikuti model tersebut. Pertama dijelaskan cara mengidentifikasi bentuk secara andal, kemudian ditunjukkan cara mengkloning, menghapus, menyembunyikan, dan mengubah urutan bentuk. Bagian akhir mencakup pemformatan tingkat tata letak, ekspor SVG, penyelarasan, dan pengaturan flip. Setiap contoh bersifat independen, sehingga Anda dapat menggunakan hanya operasi yang diperlukan oleh alur kerja Anda.

## **Identifikasi dan Menemukan Bentuk**

Indeks koleksi memang praktis saat memproses file yang sudah diketahui, tetapi bukan pengenal yang stabil. Penambahan, penghapusan, atau pengubahan urutan bentuk dapat mengubah indeksnya. Pilih pengenal sesuai cara presentasi dibuat dan dipelihara:

- [Shape.name](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/name/) berguna untuk templat yang dikendalikan pengembang dan mudah diperiksa di Panel Seleksi PowerPoint. Nama dapat diedit dan tidak dijamin unik, jadi tetapkan konvensi penamaan bila kode bergantung padanya.
- [Shape.alternative_text](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/alternative_text/) berguna ketika deskripsi aksesibilitas atau tag yang disediakan penulis sudah mengidentifikasi bentuk. Teks ini terlihat oleh pengguna, dapat dilokalisasi atau ditulis ulang untuk aksesibilitas, dan tidak dijamin unik. Jangan diam‑diam menggunakan teks aksesibilitas yang bermakna sebagai kunci basis data.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/office_interop_shape_id/) adalah pengenal read‑only yang unik dalam satu slide dan sesuai dengan ID bentuk yang digunakan oleh interop PowerPoint. Gunakan ini saat berintegrasi dengan PowerPoint atau ketika Anda memerlukan referensi yang tidak ambigu selama masa hidup suatu bentuk. Bentuk yang diklon atau dibuat ulang merupakan bentuk yang berbeda dan menerima IDnya sendiri.

Properti terkait [Shape.unique_id](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/unique_id/) memiliki cakupan presentasi, tetapi dimaksudkan untuk add‑in dan dapat dipindahtugaskan kembali. Itu tidak boleh diperlakukan sebagai kunci eksternal permanen. Jika identitas jangka panjang penting, simpan pemetaan dalam data aplikasi dan validasikan bahwa bentuk yang diharapkan masih ada.

Contoh berikut mencari berdasarkan `name` dengan perbandingan tepat dan melaporkan ID interop berskala slide. Ketika templat tidak berisi bentuk yang diharapkan, kode melaporkan hasil itu alih‑alih melanjutkan dengan objek yang salah.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    target_shape = None
    for shape in slide.shapes:
        if shape.name == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print("Found {}; interop ID: {}".format(target_shape.name, target_shape.office_interop_shape_id))
```

Ketika operasi spesifik untuk tipe bentuk tertentu, periksa tipenya sebelum menggunakan anggota khusus tipe. Contoh ini memperbarui teks dan teks alternatif hanya bila objek bernama merupakan [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/).

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    candidate = None
    for shape in slide.shapes:
        if shape.name == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, slides.AutoShape):
        candidate.text_frame.text = "Approved"
        candidate.alternative_text = "Approval status: approved"
        presentation.save("identified-shape.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
```

## **Modifikasi Koleksi Bentuk**

Metode penambahan, pengklonan, penghapusan, dan pengubahan urutan beroperasi pada koleksi secara langsung. Jika suatu operasi mengubah jumlah atau urutan bentuk, jangan terus mengandalkan indeks yang diambil sebelum operasi tersebut.

### **Klon Bentuk**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/add_clone/) membuat salinan independen dan menambahkannya ke koleksi target. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/insert_clone/) juga membuat salinan tetapi menempatkannya pada indeks z‑order yang ditentukan. Overload yang menerima koordinat memindahkan klon tanpa mengubah ukurannya; overload dengan lebar dan tinggi dapat mengubah ukuran juga.

Contoh ini membuat slide tujuan, mengklon persegi panjang berlabel ke depan, dan menyisipkan klon kedua di belakang. Perubahan pada salah satu klon tidak memodifikasi bentuk sumber.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    source_slide = presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 180, 60)
    source_shape.name = "SourceLabel"
    source_shape.text_frame.text = "Source"

    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    destination_slide = presentation.slides.add_empty_slide(blank_layout)

    front_clone_shape = destination_slide.shapes.add_clone(source_shape, 80, 80)
    front_clone_shape.name = "FrontClone"
    if isinstance(front_clone_shape, slides.AutoShape):
        front_clone_shape.text_frame.text = "Front clone"
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.shapes.insert_clone(0, source_shape, 80, 180)
    back_clone_shape.name = "BackClone"
    if isinstance(back_clone_shape, slides.AutoShape):
        back_clone_shape.text_frame.text = "Back clone"
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Pengklonan menyalin konten dan pemformatan bentuk, termasuk nama dan teks alternatifnya. Tetapkan pengenal logis baru pada klon bila nilai‑nilai tersebut harus unik. Sumber daya yang digunakan oleh bentuk kompleks ditangani oleh presentasi, tetapi klon tetap menjadi item koleksi baru dengan identitas bentuk baru.

### **Hapus Bentuk**

[ShapeCollection.remove](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/remove/) menghapus objek bentuk tertentu dari koleksinya. Saat menghapus beberapa kecocokan selama iterasi berindeks, telusuri dari akhir sehingga setiap indeks yang tersisa tetap valid.

Contoh ini menghapus setiap bentuk dengan nama yang ditentukan. Ia membaca `slide.shapes[index]`, bukan item koleksi tetap, dan tidak melakukan cast bentuk secara tidak perlu.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    keep_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 140, 60)
    keep_shape.name = "Keep"

    first_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 220, 40, 80, 80)
    first_temporary_shape.name = "Temporary"

    second_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 340, 40, 100, 80)
    second_temporary_shape.name = "Temporary"

    for index in range(len(slide.shapes) - 1, -1, -1):
        shape = slide.shapes[index]
        if shape.name == "Temporary":
            slide.shapes.remove(shape)

    presentation.save("removed-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Setelah penghapusan, jumlah bentuk dan indeks bentuk‑bentuk berikutnya berubah. Referensi ke bentuk yang tidak terpengaruh tetap lebih dapat diandalkan daripada indeks yang disimpan. Pertimbangkan juga konektor, animasi, dan fitur presentasi lain yang mungkin merujuk pada objek yang dihapus; menghapus bentuk yang terlihat dapat mengubah lebih dari sekadar tampilan slide.

### **Sembunyikan Bentuk**

Menetapkan [Shape.hidden](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/hidden/) ke `True` menjaga bentuk tetap berada dalam koleksi tetapi mencegahnya muncul dalam tampilan slide normal. Indeks, pemformatan, dan kontennya tetap tersedia bagi kode, sehingga menyembunyikan cocok untuk elemen opsional yang mungkin dipulihkan kemudian.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    visible_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 160, 60)
    visible_shape.name = "VisibleLabel"

    optional_shape = slide.shapes.add_auto_shape(slides.ShapeType.MOON, 240, 40, 100, 100)
    optional_shape.name = "OptionalDecoration"

    for shape in slide.shapes:
        if shape.name == "OptionalDecoration":
            shape.hidden = True

    presentation.save("hidden-shape.pptx", slides.export.SaveFormat.PPTX)
```

Menyembunyikan bukan berarti menghapus atau mengamankan. Objek masih dapat ditemukan dan ditampilkan kembali oleh pengguna atau kode, dan tetap menjadi bagian dari berkas presentasi.

### **Ubah Urutan Z**

Bentuk yang saling tumpang tindih digambar sesuai urutan dalam koleksi. [ShapeCollection.reorder](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/reorder/) memindahkan bentuk yang ada ke indeks target tanpa mengklonnya. Indeks `0` adalah belakang; `len(slide.shapes) - 1` adalah depan.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    blue_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 220, 120)
    blue_rectangle.name = "BlueRectangle"
    blue_rectangle.fill_format.fill_type = slides.FillType.SOLID
    blue_rectangle.fill_format.solid_fill_color.color = draw.Color.steel_blue

    orange_ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 180, 140, 220, 120)
    orange_ellipse.name = "OrangeEllipse"
    orange_ellipse.fill_format.fill_type = slides.FillType.SOLID
    orange_ellipse.fill_format.solid_fill_color.color = draw.Color.orange

    slide.shapes.reorder(len(slide.shapes) - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Persegi panjang dibuat terlebih dahulu dan pada awalnya berada di belakang elips. Memindahkannya ke indeks akhir menempatkannya di depan. Selesaikan urutan z setelah menambahkan atau mengklon semua bentuk terkait, karena operasi tersebut menambah atau menyisipkan item koleksi baru dan dapat mengubah tumpukan yang dimaksud.

## **Inspeksi Bentuk pada Slide Tata Letak**

Slide normal, slide tata letak, dan slide master memiliki koleksi bentuk yang terpisah. Bentuk dalam koleksi tata letak bukan objek yang sama dengan bentuk yang posisinya serupa pada slide normal. Inspeksi bentuk tata letak ketika Anda perlu memahami atau mengubah pemformatan yang disediakan oleh tata letak.

Contoh berikut membaca setiap [Shape.fill_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/fill_format/) dan [Shape.line_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/line_format/) dari bentuk tata letak tanpa mengasumsikan bahwa setiap bentuk adalah `AutoShape`.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

Mengedit tata letak dapat memengaruhi banyak slide yang menggunakannya. Sebelum mengubah bentuk tata letak, tentukan apakah slide normal mewarisi objek tersebut atau berisi penimpaan lokal, dan uji setiap slide yang menggunakan tata letak itu.

## **Ekspor Bentuk ke SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/write_as_svg/) menulis konten yang dirender dari satu bentuk ke aliran. Hasilnya berisi bentuk tersebut, bukan latar belakang slide secara keseluruhan atau bentuk tetangga.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.shapes[0]
        with open("shape.svg", "wb") as svg_stream:
            shape.write_as_svg(svg_stream)
```

Tetap buka presentasi selama proses rendering. Output bergantung pada pemformatan bentuk serta sumber daya seperti font dan gambar. Jika Anda memerlukan seluruh komposisi, ekspor slide bukan bentuk individual. Pemanggil memiliki aliran dan harus menutupnya.

## **Ratakan Bentuk**

[SlideUtil.align_shapes](https://reference.aspose.com/slides/id/python-net/aspose.slides.util/slideutil/align_shapes/) memiliki overload yang meratakan semua bentuk atau indeks koleksi yang dipilih. [ShapesAlignmentType](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapesalignmenttype/) menentukan tepi, garis tengah, atau mode distribusi. Atur `align_to_slide` ke `True` untuk menggunakan tepi slide; atur ke `False` untuk meratakan bentuk terpilih relatif satu sama lain.

Contoh ini meratakan tiga bentuk ke tepi atas slide. Indeks mereka saat ini diselesaikan tepat sebelum penyelarasan.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 60, 80, 120, 50)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 240, 160, 120, 50)
    third_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 420, 240, 120, 50)
    first_shape.name = "FirstAlignedShape"
    second_shape.name = "SecondAlignedShape"
    third_shape.name = "ThirdAlignedShape"

    shape_indexes = [
        slide.shapes.index_of(first_shape),
        slide.shapes.index_of(second_shape),
        slide.shapes.index_of(third_shape)
    ]

    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Penyelarasan mengubah posisi, bukan urutan z. Penyelarasan relatif biasanya memerlukan setidaknya dua bentuk, sementara distribusi horizontal atau vertikal memerlukan cukup bentuk untuk menentukan jarak. Hitung ulang indeks jika Anda memodifikasi koleksi sebelum memanggil metode.

## **Balikkan Bentuk**

Kelas [ShapeFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapeframe/) menyimpan posisi, ukuran, pengaturan flip horizontal dan vertikal, serta rotasi. Nilai `flip_h` dan `flip_v`‑nya menggunakan [NullableBool](https://reference.aspose.com/slides/id/python-net/aspose.slides/nullablebool/): `TRUE` mengaktifkan flip, `FALSE` menonaktifkannya, dan `NOT_DEFINED` mempertahankan keadaan tak ditentukan atau default.

Presentasi masukan di bawah ini berisi satu bentuk yang tidak dibalik.

![Bentuk sebelum dibalik](shape_to_be_flipped.png)

Contoh ini mempertahankan semua nilai frame lainnya dan hanya mengganti dua pengaturan flip. Hal ini penting karena menetapkan [Shape.frame](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/frame/) yang baru menggantikan seluruh frame.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    frame = shape.frame

    print("Horizontal flip before change:", frame.flip_h)
    print("Vertical flip before change:", frame.flip_v)

    shape.frame = slides.ShapeFrame(
        frame.x, frame.y, frame.width, frame.height,
        slides.NullableBool.TRUE, slides.NullableBool.TRUE, frame.rotation)

    presentation.save("flipped-shape.pptx", slides.export.SaveFormat.PPTX)
```

Bentuk yang disimpan tercermin secara horizontal dan vertikal sementara posisi, ukuran, dan rotasinya tetap.

![Bentuk setelah dibalik](flipped_shape.png)

## **Tanya Jawab**

**Apakah saya harus menggunakan indeks koleksi sebagai pengenal bentuk?**

Hanya untuk pemrosesan singkat ketika koleksi tidak akan berubah sebelum indeks digunakan. Lebih baik gunakan konvensi `name` atau `alternative_text` yang tervalidasi untuk templat yang dibuat, atau `office_interop_shape_id` untuk pekerjaan interop berskala slide.

**Apakah menyembunyikan bentuk menghapusnya dari urutan z?**

Tidak. Bentuk yang disembunyikan tetap berada dalam koleksi pada indeks yang sama. Bentuk tersebut dapat ditemukan, diubah urutannya, diedit, atau dibuat terlihat kembali.

**Mengapa bentuk yang diklon muncul di depan bentuk lain?**

`add_clone` menambahkan klon ke akhir koleksi, yang merupakan depan urutan z. Gunakan `insert_clone` untuk memilih indeks awal atau `reorder` setelah semua bentuk ditambahkan.