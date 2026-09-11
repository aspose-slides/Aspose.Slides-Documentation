---
title: Dapatkan Properti Efektif Bentuk dari Presentasi dengan Python via Java
linktitle: Properti Efektif
type: docs
weight: 50
url: /id/python-java/shape-effective-properties/
keywords:
- properti bentuk
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
- Java
- Aspose.Slides
description: "Pelajari cara menggunakan Aspose.Slides untuk Python via Java untuk membedakan pemformatan bentuk lokal, diwariskan, dan efektif dalam presentasi PowerPoint."
---
## **Memahami Properti Lokal, Warisan, dan Efektif**

Pemformatan PowerPoint dapat berasal dari beberapa tempat. Nilai yang disimpan langsung pada sebuah objek adalah **nilai lokal**. Jika nilai tersebut tidak diatur, PowerPoint akan melihat sumber format induk, seperti default paragraf, gaya teks, tata letak atau slide master, tema, atau default tingkat presentasi. Nilai‑nilai tersebut adalah **nilai yang diwariskan**. Nilai yang tersisa setelah seluruh hierarki diselesaikan adalah **nilai efektif**—nilai yang digunakan untuk merender objek.

Sebagai contoh, sebuah bagian teks mungkin tidak menentukan tinggi fontnya sendiri. Nilai lokalnya [getFontHeight](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#getFontHeight) kemudian menjadi `float("nan")`, yang berarti "tidak diatur di sini." Bagian tersebut dapat mewarisi tinggi dari paragrafnya, gaya teks default presentasi, atau sumber lain yang berlaku. Memanggil [getEffective](https://reference.aspose.com/slides/id/python-java/aspose.slides/portionformat/#getEffective) pada format bagian mengembalikan tinggi yang telah diselesaikan akhir.

Gunakan dua jenis data pemformatan untuk tujuan yang berbeda:

- Baca atau ubah objek format lokal, seperti [PortionFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/portionformat/), ketika Anda perlu mengontrol di mana nilai didefinisikan.
- Baca objek data efektif, seperti `PortionFormatEffectiveData`, ketika Anda memerlukan hasil akhir yang dirender. Data efektif bersifat read‑only.

## **Bandingkan Nilai Lokal, Warisan, dan Efektif**

Contoh lengkap berikut membuat sebuah bentuk dan menerapkan tinggi font pada tingkat presentasi, paragraf, dan bagian. Setiap langkah mencetak nilai yang didefinisikan pada tingkat tersebut dan nilai efektif yang dihasilkan untuk bagian teks yang sama. Ini juga menunjukkan mengapa data efektif harus dibaca kembali setelah perubahan format.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from math import isnan
from asposeslides.api import Presentation, SaveFormat, ShapeType


def format_local_value(value):
    return "<not set>" if isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight()
    paragraph_value = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight()
    local_value = portion.getPortionFormat().getFontHeight()

    # Baca data efektif setelah perubahan sebelumnya.
    effective_value = portion.getPortionFormat().getEffective().getFontHeight()

    print(caption)
    print(f"  Presentation default: {format_local_value(presentation_value)}")
    print(f"  Paragraph default:    {format_local_value(paragraph_value)}")
    print(f"  Portion local:        {format_local_value(local_value)}")
    print(f"  Portion effective:    {effective_value}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, False)
    text_frame = shape.addTextFrame("Effective formatting")
    paragraph = text_frame.getParagraphs().get_Item(0)
    portion = paragraph.getPortions().get_Item(0)

    # Tentukan nilai yang diwariskan pada dua tingkat berbeda.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # Nilai lokal pada bagian mengesampingkan kedua nilai yang diwariskan.
    portion.getPortionFormat().setFontHeight(36)
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Mengubah nilai yang diwariskan tidak mengesampingkan nilai lokal yang sudah ada.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30)
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Bersihkan nilai lokal. Bagian kini mewarisi kembali dari paragraf.
    portion.getPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Bersihkan nilai paragraf. Default presentasi kini menyediakan hasilnya.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Prioritas dalam contoh ini adalah format lokal bagian, kemudian format paragraf, lalu default presentasi. Objekt lain dapat memiliki rantai pewarisan yang berbeda, tetapi prinsipnya sama: nilai eksplisit yang lebih spesifik menang, dan [getEffective](https://reference.aspose.com/slides/id/python-java/aspose.slides/portionformat/#getEffective) mengembalikan hasil akhir.

## **Dapatkan Properti Teks Efektif**

Pemformatan teks dibagi di antara beberapa objek:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/#getEffective) menyelesaikan properti bingkai teks seperti margin, penambatan, autofit, dan arah teks vertikal.
- [TextStyle.getEffective](https://reference.aspose.com/slides/id/python-java/aspose.slides/textstyle/#getEffective) menyelesaikan pemformatan paragraf untuk setiap tingkat gaya teks.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraphformat/#getEffective) menyelesaikan properti paragraf seperti perataan, indentasi, dan bullet.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/id/python-java/aspose.slides/portionformat/#getEffective) menyelesaikan properti karakter seperti tinggi font, jenis huruf, warna, tebal, dan miring.

Untuk contoh berikut, `text-formatting.pptx` harus berisi setidaknya satu slide dan satu [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/) dengan bingkai teks yang tidak kosong. AutoShape dapat muncul di posisi mana saja dalam koleksi bentuk; kode mencari objek yang cocok dan memvalidasinya sebelum digunakan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation


def has_non_empty_text(shape):
    text_frame = shape.getTextFrame()
    if text_frame is None or text_frame.getParagraphs().getCount() == 0:
        return False
    return text_frame.getParagraphs().get_Item(0).getPortions().getCount() > 0


def find_auto_shape_with_text(slide):
    for candidate in slide.getShapes():
        if isinstance(candidate, AutoShape) and has_non_empty_text(candidate):
            return candidate
    return None


presentation = Presentation("text-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        shape = find_auto_shape_with_text(presentation.getSlides().get_Item(0))
        if shape is None:
            print("The first slide must contain an AutoShape with non-empty text.")
        else:
            text_frame = shape.getTextFrame()
            paragraph = text_frame.getParagraphs().get_Item(0)
            portion = paragraph.getPortions().get_Item(0)

            text_frame_effective = text_frame.getTextFrameFormat().getEffective()
            paragraph_effective = paragraph.getParagraphFormat().getEffective()
            portion_effective = portion.getPortionFormat().getEffective()

            print("Text frame margins:")
            print(f"  Left: {text_frame_effective.getMarginLeft()}")
            print(f"  Top: {text_frame_effective.getMarginTop()}")
            print(f"  Right: {text_frame_effective.getMarginRight()}")
            print(f"  Bottom: {text_frame_effective.getMarginBottom()}")
            print(f"Paragraph alignment: {paragraph_effective.getAlignment()}")
            print(f"Font height: {portion_effective.getFontHeight()}")
            print(f"Bold: {portion_effective.getFontBold()}")

            effective_text_style = text_frame.getTextFrameFormat().getTextStyle().getEffective()
            for level in range(9):
                level_effective = effective_text_style.getLevel(level)
                print(f"Level {level} indent: {level_effective.getIndent()}")
finally:
    presentation.dispose()
```

## **Dapatkan Properti 3D Efektif**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#getEffective) mengembalikan satu objek `ThreeDFormatEffectiveData` yang mengelompokkan semua pengaturan 3D yang telah diselesaikan. Metode `getCamera`, `getLightRig`, `getBevelTop`, dan `getBevelBottom` menampilkan data efektif yang sesuai. Membaca pengaturan terkait ini bersama‑sama memudahkan pemahaman tampilan 3D akhir sebuah bentuk.

Untuk contoh ini, `shape-3d.pptx` harus berisi setidaknya satu bentuk pada slide pertamanya. Terapkan pengaturan kamera 3D, pencahayaan, atau bevel pada bentuk tersebut jika Anda menginginkan output berisi nilai selain default.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("shape-3d.pptx")
try:
    if presentation.getSlides().size() == 0 or presentation.getSlides().get_Item(0).getShapes().size() == 0:
        print("The first slide must contain a shape.")
    else:
        shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        three_d_effective = shape.getThreeDFormat().getEffective()

        print("Camera:")
        print(f"  Type: {three_d_effective.getCamera().getCameraType()}")
        print(f"  Field of view: {three_d_effective.getCamera().getFieldOfViewAngle()}")
        print(f"  Zoom: {three_d_effective.getCamera().getZoom()}")

        print("Light rig:")
        print(f"  Type: {three_d_effective.getLightRig().getLightType()}")
        print(f"  Direction: {three_d_effective.getLightRig().getDirection()}")

        print("Top bevel:")
        print(f"  Type: {three_d_effective.getBevelTop().getBevelType()}")
        print(f"  Width: {three_d_effective.getBevelTop().getWidth()}")
        print(f"  Height: {three_d_effective.getBevelTop().getHeight()}")
finally:
    presentation.dispose()
```

## **Dapatkan Pemformatan Tabel Efektif**

Pemformatan tabel dapat berasal dari gaya tabel dan dari format yang diterapkan pada seluruh tabel, kolom, baris, atau sel individu. Untuk konflik di antara isian yang didefinisikan secara eksplisit, prioritasnya adalah sel, baris, kolom, dan kemudian seluruh tabel. Format efektif sebuah sel adalah format akhir yang digunakan untuk menggambar sel tersebut.

Untuk contoh ini, `table-formatting.pptx` harus berisi setidaknya satu tabel pada slide pertamanya. Tabel harus memiliki setidaknya satu baris dan satu kolom. Kode mencari sebuah [Table](https://reference.aspose.com/slides/id/python-java/aspose.slides/table/) alih‑alih mengasumsikan bahwa `getShapes().get_Item(0)` adalah tabel.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table


def find_table(slide):
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            return shape
    return None


presentation = Presentation("table-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        table = find_table(presentation.getSlides().get_Item(0))
        if table is None:
            print("The first slide must contain a table.")
        elif table.getRows().size() == 0 or table.getColumns().size() == 0:
            print("The table must contain at least one cell.")
        else:
            table_effective = table.getTableFormat().getEffective()
            row_effective = table.getRows().get_Item(0).getRowFormat().getEffective()
            column_effective = table.getColumns().get_Item(0).getColumnFormat().getEffective()
            cell_effective = table.get_Item(0, 0).getCellFormat().getEffective()

            print(f"Table fill: {table_effective.getFillFormat().getFillType()}")
            print(f"Row fill: {row_effective.getFillFormat().getFillType()}")
            print(f"Column fill: {column_effective.getFillFormat().getFillType()}")
            print(f"Final cell fill: {cell_effective.getFillFormat().getFillType()}")
finally:
    presentation.dispose()
```

Jika Anda memerlukan warna bukan hanya jenis isian, pertama periksa `getFillType` yang efektif, lalu baca metode yang berlaku untuk tipe tersebut—misalnya, `getSolidFillColor` untuk isian padat.

## **Baca Ulang Data Efektif Setelah Perubahan**

Data efektif menggambarkan hierarki pemformatan pada saat diselesaikan. Panggil [getEffective](https://reference.aspose.com/slides/id/python-java/aspose.slides/portionformat/#getEffective) lagi setelah mengubah apa pun yang dapat berpartisipasi dalam hierarki tersebut, termasuk:

- format lokal objek;
- default paragraf atau bingkai teks;
- gaya tabel, tabel, kolom, baris, atau format sel;
- format tata letak atau slide master;
- data tema atau default tingkat presentasi;
- tata letak atau master yang ditetapkan ke slide.

Jangan menyimpan objek data efektif sebagai snapshot permanen. Aspose.Slides dapat menyimpan beberapa data efektif secara internal, dan pemanggilan [getEffective](https://reference.aspose.com/slides/id/python-java/aspose.slides/portionformat/#getEffective) berikutnya dapat memperbarui data tersebut. Jika Anda perlu membandingkan nilai sebelum dan sesudah perubahan, salin nilai skalar yang diperlukan—seperti tinggi font, warna, perataan, atau lebar bevel—ke variabel Anda sendiri sebelum melakukan perubahan.

Untuk mengubah nilai, perbarui objek format lokal yang sesuai lalu panggil [getEffective](https://reference.aspose.com/slides/id/python-java/aspose.slides/portionformat/#getEffective) untuk memverifikasi hasilnya. Objek data efektif itu sendiri bersifat read‑only.

## **FAQ**

**Bagaimana saya dapat mengetahui level mana yang memberikan nilai efektif?**

Data efektif berisi nilai akhir, bukan sumbernya. Periksa objek lokal yang berlaku mulai dari level paling spesifik ke luar. Untuk teks, ini dapat mencakup bagian, paragraf, bingkai teks, tata letak, master, tema, dan default presentasi. Nilai yang tidak terdefinisi seperti `float("nan")` atau `None` menunjukkan bahwa pencarian berlanjut ke level lain.

**Apa yang terjadi ketika tidak ada level yang mendefinisikan properti?**

Aspose.Slides menyelesaikan default PowerPoint atau perpustakaan yang sesuai. Nilai yang diselesaikan tersebut muncul dalam data efektif meskipun tidak ada objek lokal yang secara eksplisit mendefinisikannya.

**Mengapa nilai efektif kadang sama dengan nilai lokal?**

Nilai lokal memenangkan perhitungan pewarisan. Ini diharapkan ketika properti secara eksplisit diatur pada objek dan tidak ada aturan yang lebih spesifik yang mengatasinya.

**Kapan saya harus menggunakan data lokal daripada data efektif?**

Gunakan data lokal untuk memeriksa atau mengedit level pemformatan tertentu. Gunakan data efektif ketika Anda memerlukan tampilan akhir setelah pewarisan, aturan tema, dan gaya yang berlaku diselesaikan. [contoh perbandingan lengkap](#compare-local-inherited-and-effective-values) menunjukkan keduanya dalam alur kerja yang sama.