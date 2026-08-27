---
title: Kelola Bentuk Presentasi di Python
linktitle: Manipulasi Bentuk
type: docs
weight: 40
url: /id/python-net/shape-manipulations/
keywords:
- Bentuk PowerPoint
- Bentuk presentasi
- Bentuk di slide
- Temukan bentuk
- Salin bentuk
- Hapus bentuk
- Sembunyikan bentuk
- Ubah urutan bentuk
- Dapatkan ID bentuk interop
- Teks alternatif bentuk
- Titik penyesuaian bentuk
- Penyesuaian bentuk bawaan
- Geometri bentuk
- Format tata letak bentuk
- Bentuk sebagai SVG
- Bentuk ke SVG
- Ratakan bentuk
- Balikkan bentuk
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara mengidentifikasi, menyesuaikan, menyalin, menghapus, menyembunyikan, mengubah urutan, mengekspor, meratakan, dan membalikkan bentuk presentasi dengan Aspose.Slides untuk Python melalui .NET."
---
## **Gambaran Umum**

Aspose.Slides for Python via .NET merepresentasikan bentuk‑bentuk pada sebuah slide sebagai sebuah [ShapeCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/) yang berurutan. Koleksi ini sekaligus menjadi tempat Anda menemukan dan memodifikasi bentuk serta sumber urutan tumpukannya: indeks `0` adalah bentuk paling belakang, sedangkan indeks terakhir adalah bentuk paling depan.

Artikel ini mengikuti model tersebut. Pertama dijelaskan cara mengidentifikasi bentuk secara andal dan memodifikasi titik penyesuaian bentuk bawaan, kemudian ditunjukkan cara menyalin, menghapus, menyembunyikan, dan mengubah urutan bentuk. Bagian akhir mencakup pemformatan tingkat tata letak, ekspor SVG, perataan, dan pengaturan pembalikan. Setiap contoh bersifat independen, sehingga Anda dapat menggunakan hanya operasi yang diperlukan dalam alur kerja Anda.

## **Identifikasi dan Temukan Bentuk**

Indeks dalam koleksi memang praktis saat memproses file yang sudah diketahui, tetapi bukan pengidentifikasi yang stabil. Menambah, menghapus, atau mengubah urutan sebuah bentuk dapat mengubah indeksnya. Pilih pengidentifikasi sesuai dengan cara presentasi dibuat dan dipelihara:

- [Shape.name](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/name/) berguna untuk templat yang dikendalikan pengembang dan mudah dilihat di Panel Seleksi PowerPoint. Nama dapat diedit dan tidak dijamin unik, sehingga tetapkan konvensi penamaan bila kode bergantung pada nama tersebut.
- [Shape.alternative_text](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/alternative_text/) berguna ketika deskripsi aksesibilitas atau tag yang disediakan penulis sudah mengidentifikasi bentuk. Teks ini terlihat oleh pengguna, dapat dilokalisasi atau ditulis ulang untuk aksesibilitas, dan tidak dijamin unik. Jangan diam‑diam menggunakan kembali teks aksesibilitas yang bermakna sebagai kunci basis data.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/office_interop_shape_id/) adalah pengidentifikasi baca‑saja yang unik dalam satu slide dan sesuai dengan ID bentuk yang digunakan oleh interop PowerPoint. Gunakan ini ketika berintegrasi dengan PowerPoint atau saat Anda memerlukan referensi yang tidak ambigu selama masa hidup sebuah bentuk. Bentuk yang disalin atau dibuat kembali merupakan bentuk berbeda dan mendapatkan ID‑nya masing‑masing.

Properti terkait [Shape.unique_id](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/unique_id/) memiliki ruang lingkup presentasi, tetapi ditujukan untuk add‑in dan dapat dipertukarkan kembali. Jangan memperlakukannya sebagai kunci eksternal permanen. Jika identitas jangka panjang penting, simpan pemetaan di data aplikasi dan validasi bahwa bentuk yang diharapkan masih ada.

Contoh berikut mencari berdasarkan `name` dengan perbandingan tepat dan melaporkan ID interop yang berskala slide. Ketika templat tidak berisi bentuk yang diharapkan, kode melaporkan hasil tersebut alih‑alih melanjutkan dengan objek yang salah.

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

Ketika sebuah operasi spesifik untuk tipe bentuk tertentu, periksa tipe dulu sebelum menggunakan anggota tipe‑spesifik. Contoh ini memperbarui teks dan teks alternatif hanya bila objek bernama tersebut merupakan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/).

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

## **Identifikasi dan Modifikasi Penyesuaian Bentuk Bawaan**

Bentuk geometri bawaan dapat mengekspos titik penyesuaian yang mengontrol fitur‑fitur seperti ukuran sudut, proporsi panah, atau sudut busur. Akses mereka melalui koleksi baca‑saja [GeometryShape.adjustments](https://reference.aspose.com/slides/id/python-net/aspose.slides/geometryshape/adjustments/). Koleksi itu sendiri disediakan oleh bentuk, tetapi setiap [AdjustValue](https://reference.aspose.com/slides/id/python-net/aspose.slides/adjustvalue/) berisi nilai yang dapat diubah.

Jangan bergantung hanya pada indeks koleksi yang tetap. Iterasi melalui penyesuaian dan periksa properti baca‑saja [AdjustValue.type](https://reference.aspose.com/slides/id/python-net/aspose.slides/adjustvalue/type/), yang nilai [ShapeAdjustmentType](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapeadjustmenttype/)‑nya menjelaskan apa yang dikendalikan penyesuaian tersebut. Properti baca‑saja [AdjustValue.name](https://reference.aspose.com/slides/id/python-net/aspose.slides/adjustvalue/name/) menyediakan informasi identifikasi tambahan dan sangat berguna ketika sebuah preset berisi lebih dari satu penyesuaian dengan tipe semantik yang sama.

Gunakan properti nilai yang sesuai dengan makna penyesuaian:

| Tipe penyesuaian | Tujuan | Nilai yang diubah |
|---|---|---|
| `CORNER_SIZE` | Ukuran sudut melengkung | [raw_value](https://reference.aspose.com/slides/id/python-net/aspose.slides/adjustvalue/raw_value/) |
| `ARROW_TAIL_THICKNESS` | Ketebalan ekor panah | `raw_value` |
| `ARROWHEAD_LENGTH` | Panjang kepala panah | `raw_value` |
| `ARROWHEAD_WIDTH` | Lebar kepala panah | `raw_value` |
| `START_ANGLE` | Sudut awal sebuah irisan atau busur | [angle_value](https://reference.aspose.com/slides/id/python-net/aspose.slides/adjustvalue/angle_value/) |
| `END_ANGLE` | Sudut akhir sebuah irisan atau busur | `angle_value` |

`type` dan `name` tidak dapat di‑assign. `raw_value` adalah integer baca‑tulis dalam satuan geometri asli preset, sedangkan `angle_value` adalah sudut baca‑tulis dalam derajat. Jumlah, urutan, makna, dan rentang nilai yang valid bergantung pada preset [GeometryShape.shape_type](https://reference.aspose.com/slides/id/python-net/aspose.slides/geometryshape/shape_type/). Nilai yang valid untuk satu preset mungkin tidak valid atau memiliki efek berbeda untuk preset lain.

Ketika `type` adalah `ShapeAdjustmentType.CUSTOM`, API tidak mengenali makna semantik standar. Periksa `name`, tipe preset, dan nilai yang ada, serta biarkan penyesuaian tidak berubah kecuali makna dan rentang yang diharapkan diketahui. Bahkan untuk tipe yang dikenali, periksa apakah tipe yang sama muncul lebih dari satu kali sebelum memilih nilai. Artikel [Connector](/slides/id/python-net/connector/) menunjukkan situasi ini dengan penyesuaian bengkok konektor.

Contoh lengkap berikut membuat versi default dan dimodifikasi dari tiga bentuk preset. Ia mengiterasi setiap penyesuaian, melaporkan `name` dan `type`‑nya, mengubah nilai yang berhubungan dengan ukuran melalui `raw_value`, mengubah sudut melalui `angle_value`, dan menyimpan hasilnya. Kolom kiri mempertahankan geometri default; kolom kanan menunjukkan persegi panjang melengkung yang disesuaikan, panah empat arah, dan irisan.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Tambahkan header untuk kolom bentuk default dan yang disesuaikan.
    default_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 250, 30)
    default_column_label.text_frame.text = "Default preset geometry"
    adjusted_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 390, 20, 250, 30)
    adjusted_column_label.text_frame.text = "Modified adjustment values"

    slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 430, 70, 160, 70)
    modified_rounded_rectangle.name = "ModifiedRoundedRectangle"

    slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 80, 180, 160, 110)
    modified_arrow = slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 430, 180, 160, 110)
    modified_arrow.name = "ModifiedQuadArrow"

    slide.shapes.add_auto_shape(slides.ShapeType.PIE, 95, 330, 130, 130)
    modified_pie = slide.shapes.add_auto_shape(slides.ShapeType.PIE, 445, 330, 130, 130)
    modified_pie.name = "ModifiedPie"

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment in shape.adjustments:
            print("{} / {}: {}".format(shape.name, adjustment.name, adjustment.type.name))

            if adjustment.type == slides.ShapeAdjustmentType.CORNER_SIZE:
                adjustment.raw_value = 5000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROW_TAIL_THICKNESS:
                adjustment.raw_value = 25000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_LENGTH:
                adjustment.raw_value = 30000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_WIDTH:
                adjustment.raw_value = 40000
            elif adjustment.type == slides.ShapeAdjustmentType.START_ANGLE:
                adjustment.angle_value = 30
            elif adjustment.type == slides.ShapeAdjustmentType.END_ANGLE:
                adjustment.angle_value = 300
            elif adjustment.type == slides.ShapeAdjustmentType.CUSTOM:
                print("Custom adjustment '{}' was not changed.".format(adjustment.name))

    presentation.save("preset-shape-adjustments.pptx", slides.export.SaveFormat.PPTX)
```

Memeriksa tipe semantik sebelum mengubah nilai membuat kode lebih eksplisit mengenai niatnya dan menghindari asumsi bahwa indeks koleksi tertentu memiliki makna yang sama pada berbagai bentuk preset.

## **Modifikasi Shape Collection**

Metode tambah, salin, hapus, dan ubah urutan bekerja pada koleksi secara langsung. Jika sebuah operasi mengubah jumlah atau urutan bentuk, jangan terus mengandalkan indeks yang diambil sebelum operasi tersebut.

### **Salin (Clone) Sebuah Bentuk**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/add_clone/) membuat salinan independen dan menambahkannya ke koleksi target. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/insert_clone/) juga membuat salinan tetapi menempatkannya pada indeks z‑order yang ditentukan. Overload yang menerima koordinat memindahkan salinan tanpa mengubah ukuran; overload dengan lebar dan tinggi dapat meresize juga.

Contoh ini membuat slide tujuan, menyalin sebuah persegi berlabel ke depan, dan menyisipkan salinan kedua di belakang. Perubahan pada salah satu salinan tidak memodifikasi bentuk sumber.

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

Penyalinan menyalin konten dan pemformatan bentuk, termasuk nama dan teks alternatifnya. Berikan pengidentifikasi logis baru pada salinan bila nilai‑nilai tersebut harus unik. Sumber daya yang dipakai oleh bentuk kompleks ditangani oleh presentasi, tetapi salinan tetap menjadi item koleksi baru dengan identitas bentuk yang baru.

### **Hapus Bentuk**

[ShapeCollection.remove](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/remove/) menghapus objek bentuk tertentu dari koleksinya. Saat menghapus beberapa kecocokan selama iterasi indeks, lakukan penelusuran dari akhir sehingga setiap indeks yang tersisa tetap valid.

Contoh ini menghapus setiap bentuk dengan nama yang ditentukan. Ia membaca `slide.shapes[index]`, bukan item koleksi tetap, dan tidak melakukan cast bentuk yang tidak diperlukan.

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

Setelah penghapusan, jumlah bentuk dan indeks bentuk‑bentuk selanjutnya berubah. Referensi ke bentuk yang tidak terpengaruh tetap lebih dapat diandalkan daripada menyimpan indeks. Pertimbangkan juga konektor, animasi, dan fitur presentasi lain yang mungkin merujuk pada objek yang dihapus; menghapus bentuk yang terlihat dapat mengubah lebih dari sekadar penampilan slide.

### **Sembunyikan Sebuah Bentuk**

Menetapkan [Shape.hidden](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/hidden/) ke `True` menjaga bentuk tetap berada di koleksi tetapi mencegahnya muncul dalam tayangan slide normal. Indeks, pemformatan, dan kontennya tetap tersedia bagi kode, sehingga menyembunyikan cocok untuk elemen opsional yang mungkin dipulihkan nanti.

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

### **Ubah Z‑Order**

Bentuk yang saling tumpang tindih digambar menurut urutan koleksi. [ShapeCollection.reorder](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/reorder/) memindahkan bentuk yang ada ke indeks target tanpa menyalinnya. Indeks `0` adalah paling belakang; `len(slide.shapes) - 1` adalah paling depan.

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

Persegi dibuat pertama dan awalnya berada di belakang elips. Memindahkannya ke indeks akhir menempatkannya di depan. Finalisasikan urutan z setelah menambah atau menyalin semua bentuk terkait, karena operasi‑operasi tersebut menambahkan atau menyisipkan item koleksi baru dan dapat mengubah tumpukan yang diinginkan.

## **Periksa Bentuk pada Slide Tata Letak**

Slide normal, slide tata letak, dan slide master memiliki koleksi bentuk yang terpisah. Sebuah bentuk dalam koleksi tata letak bukan objek yang sama dengan bentuk yang berada pada posisi serupa di slide normal. Periksa bentuk tata letak ketika Anda perlu memahami atau mengubah pemformatan yang disediakan oleh tata letak.

Contoh berikut membaca masing‑masing [Shape.fill_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/fill_format/) dan [Shape.line_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/line_format/) pada setiap bentuk tata letak tanpa mengasumsikan bahwa setiap bentuk adalah sebuah `AutoShape`.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

Menyunting tata letak dapat memengaruhi beberapa slide yang menggunakannya. Sebelum mengubah bentuk tata letak, tentukan apakah slide normal mewarisi objek tersebut atau memiliki penimpaan lokal, dan uji setiap slide yang memakai tata letak itu.

## **Ekspor Bentuk ke SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/write_as_svg/) menulis konten terrender satu bentuk ke sebuah aliran. Hasilnya berisi bentuk itu, bukan latar belakang slide secara keseluruhan atau bentuk‑bentuk tetangganya.

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

Biarkan presentasi tetap terbuka saat melakukan rendering. Output bergantung pada pemformatan bentuk serta sumber daya seperti font dan gambar. Jika Anda memerlukan keseluruhan komposisi, ekspor slide alih‑alih bentuk individu. Pemanggil yang memiliki aliran harus menutupnya.

## **Ratakan Bentuk**

Overload [SlideUtil.align_shapes](https://reference.aspose.com/slides/id/python-net/aspose.slides.util/slideutil/align_shapes/) dapat meratakan semua bentuk atau indeks koleksi yang dipilih. [ShapesAlignmentType](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapesalignmenttype/) menentukan tepi, garis tengah, atau mode distribusi. Setel `align_to_slide` ke `True` untuk menggunakan tepi slide; setel ke `False` untuk meratakan bentuk yang dipilih relatif satu sama lain.

Contoh ini meratakan tiga bentuk ke tepi atas slide. Indeks mereka yang saat ini digunakan diselesaikan segera sebelum perataan.

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

Perataan mengubah posisi, bukan z‑order. Perataan relatif biasanya memerlukan minimal dua bentuk, sedangkan distribusi horizontal atau vertikal memerlukan cukup bentuk untuk menentukan jarak. Hitung kembali indeks jika Anda memodifikasi koleksi sebelum memanggil metode.

## **Balikkan (Flip) Sebuah Bentuk**

Kelas [ShapeFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapeframe/) menyimpan posisi, ukuran, pengaturan flip horizontal dan vertikal, serta rotasi. Nilai `flip_h` dan `flip_v`‑nya memakai [NullableBool](https://reference.aspose.com/slides/id/python-net/aspose.slides/nullablebool/): `TRUE` mengaktifkan flip, `FALSE` menonaktifkannya, dan `NOT_DEFINED` mempertahankan keadaan yang tidak ditentukan atau default.

Presentasi masukan di bawah berisi satu bentuk yang tidak dibalik.

![Bentuk sebelum dibalik](shape_to_be_flipped.png)

Contoh ini mempertahankan semua nilai frame lainnya dan mengganti hanya dua pengaturan flip. Ini penting karena menetapkan [Shape.frame](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/frame/) yang baru akan menggantikan seluruh frame.

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

Bentuk yang disimpan kini tercermin secara horizontal dan vertikal sambil mempertahankan posisi, ukuran, dan rotasinya.

![Bentuk setelah dibalik](flipped_shape.png)

## **FAQ**

**Haruskah saya menggunakan indeks koleksi sebagai pengidentifikasi bentuk?**

Hanya untuk pemrosesan jangka pendek ketika koleksi tidak akan berubah sebelum indeks digunakan. Lebih baik menggunakan konvensi `name` atau `alternative_text` yang tervalidasi untuk templat yang dibuat, atau `office_interop_shape_id` untuk pekerjaan interop berskala slide.

**Apakah menyembunyikan bentuk menghapusnya dari z‑order?**

Tidak. Bentuk tersembunyi tetap berada di koleksi pada indeks yang sama. Bentuk tersebut dapat ditemukan, diubah urutannya, diedit, atau ditampilkan kembali.

**Mengapa bentuk yang disalin muncul di depan bentuk lain?**

`add_clone` menambahkan salinan ke akhir koleksi, yang merupakan depan urutan z. Gunakan `insert_clone` untuk memilih indeks awal atau `reorder` setelah semua bentuk ditambahkan.

**Bisakah saya menggunakan indeks tetap untuk mengidentifikasi penyesuaian bentuk preset?**

Hanya setelah memvalidasi preset dan tata letak koleksi secara tepat. Lebih baik iterasi melalui `GeometryShape.adjustments` dan periksa `AdjustValue.type`; gunakan `AdjustValue.name` sebagai informasi tambahan ketika tipe semantik yang sama muncul lebih dari satu kali.