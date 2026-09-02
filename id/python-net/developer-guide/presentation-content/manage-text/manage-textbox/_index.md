---
title: Mengelola Kotak Teks dalam Presentasi dengan Python
linktitle: Kelola Kotak Teks
type: docs
weight: 20
url: /id/python-net/manage-textbox/
keywords:
- kotak teks
- bingkai teks
- menambahkan teks
- memperbarui teks
- membuat kotak teks
- memeriksa kotak teks
- menambahkan kolom teks
- menambahkan hyperlink
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Aspose.Slides untuk Python melalui .NET memudahkan pembuatan, penyuntingan, dan penggandaan kotak teks dalam file PowerPoint dan OpenDocument, meningkatkan otomatisasi presentasi Anda."
---
## **Pengantar**

Teks pada slide biasanya berada di dalam kotak teks atau bentuk. Oleh karena itu, untuk menambahkan teks ke slide, Anda harus menambahkan kotak teks dan kemudian menempatkan beberapa teks di dalam kotak teks tersebut. Aspose.Slides for Python menyediakan kelas [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) yang memungkinkan Anda menambahkan bentuk yang berisi teks.

{{% alert title="Info" color="info" %}}
Aspose.Slides juga menyediakan kelas [Shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/). Namun, tidak semua bentuk dapat menampung teks.
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
Oleh karena itu, saat menangani sebuah bentuk yang ingin Anda tambahkan teks, Anda mungkin ingin memeriksa dan memastikan bahwa bentuk tersebut telah di-cast melalui kelas [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) . Hanya dengan begitu Anda dapat bekerja dengan [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/), yang merupakan properti di bawah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/). Lihat bagian [Update Text](/slides/id/python-net/manage-textbox/#update-text) pada halaman ini.
{{% /alert %}}

## **Membuat Kotak Teks pada Slide**

Untuk membuat kotak teks pada slide:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Dapatkan referensi ke slide pertama.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) dengan `ShapeType.RECTANGLE` pada posisi yang diinginkan di slide.
4. Setel teks pada [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) milik bentuk.
5. Simpan presentasi sebagai file PPTX.

Contoh Python berikut mengimplementasikan langkah‑langkah ini:

```py
import aspose.slides as slides

# Membuat instance kelas Presentation.
with slides.Presentation() as presentation:

    # Mendapatkan slide pertama dalam presentasi.
    slide = presentation.slides[0]

    # Menambahkan AutoShape tipe RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # Menyimpan presentasi ke disk.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **Memeriksa Apakah Sebuah Bentuk Merupakan Kotak Teks**

Aspose.Slides menyediakan properti [is_text_box](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/is_text_box/) pada kelas [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/), yang memungkinkan Anda menentukan apakah sebuah bentuk adalah kotak teks.

![Text box and shape](istextbox.png)

Contoh Python ini menunjukkan cara memeriksa apakah sebuah bentuk dibuat sebagai kotak teks:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

Perhatikan bahwa jika Anda menambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) menggunakan kelas [ShapeCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/), properti `is_text_box` pada bentuk akan mengembalikan `False`. Namun, setelah Anda menambahkan teks—baik dengan metode `add_text_frame` atau dengan menyetel properti `text`—`is_text_box` mengembalikan `True`.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box adalah false
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box adalah true

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box adalah false
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box adalah true

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box adalah false
    shape3.add_text_frame("")
    # shape3.is_text_box adalah false

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box adalah false
    shape4.text_frame.text = ""
    # shape4.is_text_box adalah false
```

## **Menemukan Bentuk yang Memiliki Text Frame**

Dalam kode pemrosesan teks umum, Anda mungkin menerima sebuah [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) tanpa mengetahui objek presentasi mana yang memilikinya. Gunakan properti [TextFrame.parent_shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/parent_shape/) untuk menavigasi kembali ke [Shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/) yang memilikinya.

Untuk sebuah text frame yang merupakan milik [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) atau bentuk lain yang berisi teks, [TextFrame.parent_shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/parent_shape/) diatur dan [TextFrame.parent_cell](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/parent_cell/) bernilai `None`. Kedua properti tersebut adalah properti navigasi read‑only, sehingga membacanya tidak mengubah kepemilikan. Selalu periksa nilai yang dikembalikan apakah `None` sebelum mengakses bentuk.

Untuk contoh lengkap yang mengidentifikasi pemilik shape dan sel tabel, termasuk shape yang terkait dengan node SmartArt, lihat [Search and Replace Text](/slides/id/python-net/search-and-replace-text/).

## **Menambahkan Kolom ke Kotak Teks**

Aspose.Slides menyediakan properti [column_count](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframeformat/column_count/) dan [column_spacing](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframeformat/column_spacing/) pada kelas [TextFrameFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframeformat/) untuk menambahkan kolom ke kotak teks. Anda dapat menentukan jumlah kolom dan mengatur jarak (dalam poin) antar kolom.

Kode Python berikut memperagakan operasi ini:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Dapatkan slide pertama dalam presentasi.
	slide = presentation.slides[0]

	# Tambahkan AutoShape tipe RECTANGLE.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# Tambahkan TextFrame ke persegi panjang.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# Dapatkan format teks dari TextFrame.
	format = shape.text_frame.text_frame_format

	# Tentukan jumlah kolom dalam TextFrame.
	format.column_count = 3

	# Tentukan jarak antar kolom.
	format.column_spacing = 10

	# Simpan presentasi.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **Memperbarui Teks**

Aspose.Slides memungkinkan Anda memperbarui teks dalam satu kotak teks atau di seluruh presentasi. 

Contoh Python berikut memperagakan cara memperbarui semua teks dalam sebuah presentasi:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE
  
    # Simpan presentasi yang dimodifikasi.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **Menambahkan Kotak Teks dengan Hyperlink** 

Anda dapat menyisipkan tautan dalam kotak teks. Saat kotak teks diklik, tautan akan terbuka.

Untuk menambahkan kotak teks yang berisi hyperlink, ikuti langkah‑langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Dapatkan referensi ke slide pertama.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) dengan `ShapeType.RECTANGLE` pada posisi yang diinginkan di slide.
4. Setel teks pada [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/).
5. Dapatkan referensi ke kelas [HyperlinkManager](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlinkmanager/).
6. Gunakan properti `hyperlink_manager` untuk mengatur hyperlink klik eksternal.
7. Simpan presentasi sebagai file PPTX.

Contoh Python ini menunjukkan cara menambahkan kotak teks dengan hyperlink ke slide:

```py
import aspose.slides as slides

# Membuat instance kelas Presentation.
with slides.Presentation() as presentation:

    # Dapatkan slide pertama dalam presentasi.
    slide = presentation.slides[0]

    # Tambahkan AutoShape tipe RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # Tambahkan teks ke frame.
    text_portion.text = "Aspose.Slides"

    # Atur hyperlink untuk teks bagian.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # Simpan presentasi sebagai file PPTX.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apa perbedaan antara kotak teks dan placeholder teks saat bekerja dengan master slide?**

Sebuah [placeholder](/slides/id/python-net/manage-placeholder/) mewarisi gaya/posisi dari [master](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterslide/) dan dapat ditimpa pada [layout](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutslide/), sementara kotak teks biasa adalah objek independen pada slide tertentu dan tidak berubah ketika Anda mengganti layout.

**Bagaimana saya dapat melakukan penggantian teks massal di seluruh presentasi tanpa menyentuh teks di dalam chart, tabel, dan SmartArt?**

Batasi iterasi Anda pada auto‑shape yang memiliki text frame dan kecualikan objek terpaut ([chart](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/), [table](https://reference.aspose.com/slides/id/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/id/python-net/aspose.slides.smartart/smartart/)) dengan menelusuri koleksi mereka secara terpisah atau melewatkan tipe objek tersebut.