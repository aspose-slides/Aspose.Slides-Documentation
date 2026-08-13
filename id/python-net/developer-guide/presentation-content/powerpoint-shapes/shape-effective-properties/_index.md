---
title: Dapatkan Properti Efektif Shape dari Presentasi dalam Python
linktitle: Properti Efektif
type: docs
weight: 50
url: /id/python-net/shape-effective-properties/
keywords:
- properti shape
- properti kamera
- rig cahaya
- bentuk bevel
- bingkai teks
- gaya teks
- tinggi font
- format isian
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara menggunakan Aspose.Slides untuk Python via .NET untuk membedakan pemformatan shape lokal, diwariskan, dan efektif dalam presentasi PowerPoint."
---
## **Memahami Properti Lokal, Warisan, dan Efektif**

Pemformatan PowerPoint dapat berasal dari beberapa tempat. Nilai yang disimpan langsung pada sebuah objek disebut **nilai lokal**. Jika nilai tersebut tidak diatur, PowerPoint akan melihat sumber pemformatan induk, seperti default paragraf, gaya teks, tata letak atau slide master, tema, atau default tingkat presentasi. Nilai-nilai tersebut disebut **nilai warisan**. Nilai yang tersisa setelah seluruh hierarki diselesaikan adalah **nilai efektif**, yang digunakan untuk merender objek.

Sebagai contoh, sebuah bagian teks mungkin tidak mendefinisikan tinggi fontnya sendiri. **font_height** lokalnya kemudian adalah `float("nan")`, yang berarti "tidak diset di sini." Bagian tersebut dapat mewarisi tinggi dari paragrafnya, gaya teks default pada presentasi, atau sumber lain yang berlaku. Memanggil [get_effective](https://reference.aspose.com/slides/id/python-net/aspose.slides/iportionformat/get_effective/) pada format bagian mengembalikan tinggi yang telah diselesaikan akhir.

Gunakan dua jenis data pemformatan untuk tujuan yang berbeda:

- Baca atau ubah objek format lokal, seperti [IPortionFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/iportionformat/), ketika Anda perlu mengontrol di mana nilai didefinisikan.
- Baca objek data efektif, seperti [IPortionFormatEffectiveData](https://reference.aspose.com/slides/id/python-net/aspose.slides/iportionformateffectivedata/), ketika Anda membutuhkan hasil akhir yang dirender. Data efektif bersifat read‑only.

## **Membandingkan Nilai Lokal, Warisan, dan Efektif**

Contoh lengkap berikut membuat sebuah shape dan menerapkan tinggi font pada tingkat presentasi, paragraf, dan bagian. Setiap langkah mencetak nilai yang didefinisikan pada tingkat tersebut serta nilai efektif yang dihasilkan untuk bagian teks yang sama. Contoh ini juga menunjukkan mengapa data efektif harus dibaca kembali setelah perubahan pemformatan.

```python
import math

import aspose.slides as slides


def format_local_value(value):
    return "<not set>" if math.isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.default_text_style.get_level(0).default_portion_format.font_height
    paragraph_value = paragraph.paragraph_format.default_portion_format.font_height
    local_value = portion.portion_format.font_height

    # Baca data efektif setelah perubahan sebelumnya.
    effective_value = portion.portion_format.get_effective().font_height

    print(caption)
    print("  Presentation default: " + format_local_value(presentation_value))
    print("  Paragraph default:    " + format_local_value(paragraph_value))
    print("  Portion local:        " + format_local_value(local_value))
    print("  Portion effective:    " + str(effective_value))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 80, False)
    text_frame = shape.add_text_frame("Effective formatting")
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    # Tentukan nilai warisan pada dua tingkat berbeda.
    presentation.default_text_style.get_level(0).default_portion_format.font_height = 20
    paragraph.paragraph_format.default_portion_format.font_height = 28

    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # Nilai lokal pada portion menggantikan kedua nilai warisan.
    portion.portion_format.font_height = 36
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Mengubah nilai warisan tidak menggantikan nilai lokal yang ada.
    paragraph.paragraph_format.default_portion_format.font_height = 30
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Hapus nilai lokal. Portion kini mewarisi dari paragraf lagi.
    portion.portion_format.font_height = float("nan")
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Hapus nilai paragraf. Default presentasi kini menyediakan hasil.
    paragraph.paragraph_format.default_portion_format.font_height = float("nan")
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", slides.export.SaveFormat.PPTX)
```

Prioritas dalam contoh ini adalah pemformatan lokal bagian, kemudian pemformatan paragraf, lalu default presentasi. Objek lain dapat memiliki rantai warisan yang berbeda, tetapi prinsipnya sama: nilai eksplisit yang lebih spesifik menang, dan [get_effective](https://reference.aspose.com/slides/id/python-net/aspose.slides/iportionformat/get_effective/) mengembalikan hasil akhir.

## **Mendapatkan Properti Teks Efektif**

Pemformatan teks terbagi menjadi beberapa objek:

- [ITextFrameFormat.get_effective()](https://reference.aspose.com/slides/id/python-net/aspose.slides/itextframeformat/get_effective/) menyelesaikan properti bingkai teks seperti margin, penempatan, autofit, dan arah teks vertikal.
- [ITextStyle.get_effective()](https://reference.aspose.com/slides/id/python-net/aspose.slides/itextstyle/get_effective/) menyelesaikan pemformatan paragraf untuk setiap tingkat gaya teks.
- [IParagraphFormat.get_effective()](https://reference.aspose.com/slides/id/python-net/aspose.slides/iparagraphformat/get_effective/) menyelesaikan properti paragraf seperti perataan, indentasi, dan bullet.
- [IPortionFormat.get_effective()](https://reference.aspose.com/slides/id/python-net/aspose.slides/iportionformat/get_effective/) menyelesaikan properti karakter seperti tinggi font, jenis huruf, warna, bold, dan italic.

Untuk contoh berikut, `text-formatting.pptx` harus berisi setidaknya satu slide dan satu [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) dengan bingkai teks yang tidak kosong. AutoShape dapat berada pada posisi mana pun dalam koleksi shape; kode akan mencari objek yang cocok dan memvalidasinya sebelum digunakan.

```python
import aspose.slides as slides


def has_non_empty_text(shape):
    if not isinstance(shape, slides.AutoShape):
        return False
    if shape.text_frame is None:
        return False
    if shape.text_frame.paragraphs.count == 0:
        return False
    return shape.text_frame.paragraphs[0].portions.count > 0


with slides.Presentation("text-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    shape = None
    for candidate in presentation.slides[0].shapes:
        if has_non_empty_text(candidate):
            shape = candidate
            break

    if shape is None:
        raise RuntimeError("The first slide must contain an AutoShape with non-empty text.")

    text_frame = shape.text_frame
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    text_frame_effective = text_frame.text_frame_format.get_effective()
    paragraph_effective = paragraph.paragraph_format.get_effective()
    portion_effective = portion.portion_format.get_effective()

    print("Text frame margins:")
    print("  Left: " + str(text_frame_effective.margin_left))
    print("  Top: " + str(text_frame_effective.margin_top))
    print("  Right: " + str(text_frame_effective.margin_right))
    print("  Bottom: " + str(text_frame_effective.margin_bottom))
    print("Paragraph alignment: " + str(paragraph_effective.alignment))
    print("Font height: " + str(portion_effective.font_height))
    print("Bold: " + str(portion_effective.font_bold))

    effective_text_style = text_frame.text_frame_format.text_style.get_effective()
    for level in range(9):
        level_effective = effective_text_style.get_level(level)
        print("Level " + str(level) + " indent: " + str(level_effective.indent))
```

## **Mendapatkan Properti 3D Efektif**

[IThreeDFormat.get_effective()](https://reference.aspose.com/slides/id/python-net/aspose.slides/ithreedformat/get_effective/) mengembalikan satu objek [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/id/python-net/aspose.slides/ithreedformateffectivedata/) yang mengelompokkan semua pengaturan 3D yang telah diselesaikan. Properti [camera](https://reference.aspose.com/slides/id/python-net/aspose.slides/ithreedformateffectivedata/camera/), [light_rig](https://reference.aspose.com/slides/id/python-net/aspose.slides/ithreedformateffectivedata/light_rig/), [bevel_top](https://reference.aspose.com/slides/id/python-net/aspose.slides/ithreedformateffectivedata/bevel_top/), dan [bevel_bottom](https://reference.aspose.com/slides/id/python-net/aspose.slides/ithreedformateffectivedata/bevel_bottom/) menampilkan data efektif yang bersangkutan. Membaca pengaturan terkait secara bersamaan memudahkan pemahaman tampilan 3D akhir sebuah shape.

Untuk contoh ini, `shape-3d.pptx` harus berisi setidaknya satu shape pada slide pertama. Terapkan kamera 3D, pencahayaan, atau pengaturan bevel pada shape tersebut jika Anda menginginkan output dengan nilai selain default.

```python
import aspose.slides as slides


with slides.Presentation("shape-3d.pptx") as presentation:
    if presentation.slides.count == 0 or presentation.slides[0].shapes.count == 0:
        raise RuntimeError("The first slide must contain a shape.")

    shape = presentation.slides[0].shapes[0]
    three_d_effective = shape.three_d_format.get_effective()

    print("Camera:")
    print("  Type: " + str(three_d_effective.camera.camera_type))
    print("  Field of view: " + str(three_d_effective.camera.field_of_view_angle))
    print("  Zoom: " + str(three_d_effective.camera.zoom))

    print("Light rig:")
    print("  Type: " + str(three_d_effective.light_rig.light_type))
    print("  Direction: " + str(three_d_effective.light_rig.direction))

    print("Top bevel:")
    print("  Type: " + str(three_d_effective.bevel_top.bevel_type))
    print("  Width: " + str(three_d_effective.bevel_top.width))
    print("  Height: " + str(three_d_effective.bevel_top.height))
```

## **Mendapatkan Pemformatan Tabel Efektif**

Pemformatan tabel dapat berasal dari gaya tabel dan dari format yang diterapkan pada seluruh tabel, kolom, baris, atau sel individu. Untuk konflik antara isi yang didefinisikan secara eksplisit, prioritasnya adalah sel, baris, kolom, dan kemudian seluruh tabel. Format efektif sebuah sel adalah format akhir yang digunakan untuk menggambar sel tersebut.

Untuk contoh ini, `table-formatting.pptx` harus berisi setidaknya satu tabel pada slide pertama. Tabel harus memiliki setidaknya satu baris dan satu kolom. Kode mencari sebuah [Table](https://reference.aspose.com/slides/id/python-net/aspose.slides/table/) alih‑alih mengasumsikan bahwa `shapes[0]` adalah tabel.

```python
import aspose.slides as slides


with slides.Presentation("table-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    table = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is None:
        raise RuntimeError("The first slide must contain a table.")

    if table.rows.count == 0 or table.columns.count == 0:
        raise RuntimeError("The table must contain at least one cell.")

    table_effective = table.table_format.get_effective()
    row_effective = table.rows[0].row_format.get_effective()
    column_effective = table.columns[0].column_format.get_effective()
    cell_effective = table.rows[0][0].cell_format.get_effective()

    print("Table fill: " + str(table_effective.fill_format.fill_type))
    print("Row fill: " + str(row_effective.fill_format.fill_type))
    print("Column fill: " + str(column_effective.fill_format.fill_type))
    print("Final cell fill: " + str(cell_effective.fill_format.fill_type))
```

Jika Anda membutuhkan warna alih‑alih hanya tipe isian, pertama periksa [fill_type](https://reference.aspose.com/slides/id/python-net/aspose.slides/ifillformateffectivedata/fill_type/) yang efektif, kemudian baca properti yang berlaku untuk tipe tersebut, misalnya [solid_fill_color](https://reference.aspose.com/slides/id/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) untuk isian solid.

## **Baca Ulang Data Efektif Setelah Perubahan**

Data efektif menggambarkan hierarki pemformatan pada saat diselesaikan. Panggil `get_effective` lagi setelah mengubah apa pun yang dapat berpartisipasi dalam hierarki tersebut, termasuk:

- pemformatan lokal objek;
- default paragraf atau bingkai teks;
- gaya tabel, tabel, kolom, baris, atau format sel;
- pemformatan tata letak atau slide master;
- data tema atau default tingkat presentasi;
- tata letak atau master yang ditetapkan pada slide.

Jangan menyimpan objek data efektif sebagai snapshot permanen. Aspose.Slides dapat menyimpan beberapa data efektif secara internal, dan panggilan `get_effective` berikutnya dapat menyegarkan data tersebut. Jika Anda perlu membandingkan nilai sebelum dan sesudah perubahan, salin nilai skalar yang diperlukan, seperti tinggi font, warna, perataan, atau lebar bevel, ke variabel Anda sendiri sebelum melakukan perubahan.

Untuk mengubah sebuah nilai, perbarui objek format lokal yang sesuai, lalu panggil `get_effective` untuk memverifikasi hasilnya. Objek data efektif bersifat read‑only.

## **FAQ**

**Bagaimana saya dapat mengetahui level mana yang menyediakan nilai efektif?**

Data efektif berisi nilai akhir, bukan sumbernya. Periksa objek lokal yang berlaku mulai dari level paling spesifik ke arah luar. Untuk teks, ini dapat mencakup bagian, paragraf, bingkai teks, tata letak, master, tema, dan default presentasi. Nilai yang tidak terdefinisi seperti `float("nan")` atau `None` menunjukkan bahwa pencarian berlanjut ke level lain.

**Apa yang terjadi jika tidak ada level yang mendefinisikan properti?**

Aspose.Slides menyelesaikan default PowerPoint atau library yang sesuai. Nilai yang diselesaikan muncul dalam data efektif meskipun tidak ada objek lokal yang secara eksplisit mendefinisikannya.

**Mengapa nilai efektif kadang‑kadang sama dengan nilai lokal?**

Nilai lokal memenangkan perhitungan warisan. Hal ini diharapkan ketika properti secara eksplisit diset pada objek dan tidak ada aturan yang lebih spesifik yang menimpanya.

**Kapan saya harus menggunakan data lokal daripada data efektif?**

Gunakan data lokal untuk memeriksa atau mengedit level pemformatan tertentu. Gunakan data efektif ketika Anda memerlukan tampilan akhir setelah warisan, aturan tema, dan gaya yang berlaku telah diselesaikan. Contoh perbandingan lengkap ([complete comparison example](#compare-local-inherited-and-effective-values)) memperlihatkan keduanya dalam alur kerja yang sama.