---
title: Kelola Kotak Teks dalam Presentasi dengan Python
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
- menambahkan tautan
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Aspose.Slides untuk Python via .NET memudahkan pembuatan, pengeditan, dan duplikasi kotak teks dalam file PowerPoint dan OpenDocument, meningkatkan otomatisasi presentasi Anda."
---
## **Introduction**

Teks pada slide biasanya berada di dalam kotak teks atau shape. Oleh karena itu, untuk menambahkan teks ke slide, Anda harus menambahkan kotak teks kemudian menuliskan beberapa teks di dalamnya. Aspose.Slides untuk Python menyediakan kelas [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) yang memungkinkan Anda menambahkan shape yang berisi teks.

{{% alert title="Info" color="info" %}}
Aspose.Slides juga menyediakan kelas [Shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/). Namun, tidak semua shape dapat menampung teks.
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
Karena itu, ketika berurusan dengan shape yang ingin Anda tambahkan teks, sebaiknya periksa dan pastikan bahwa shape tersebut telah di‑cast melalui kelas [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/). Hanya setelah itu Anda dapat bekerja dengan [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/), yang merupakan properti di bawah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/). Lihat bagian [Update Text](/slides/id/python-net/manage-textbox/#update-text) pada halaman ini.
{{% /alert %}}

## **Create Text Boxes on Slides**

Untuk membuat kotak teks pada slide:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Dapatkan referensi ke slide pertama.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) dengan `ShapeType.RECTANGLE` pada posisi yang diinginkan di slide.
4. Atur teks pada [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) shape tersebut.
5. Simpan presentasi sebagai file PPTX.

Contoh Python berikut mengimplementasikan langkah‑langkah tersebut:

```py
import aspose.slides as slides

# Membuat instance dari kelas Presentation.
with slides.Presentation() as presentation:

    # Dapatkan slide pertama dalam presentasi.
    slide = presentation.slides[0]

    # Tambahkan AutoShape dengan tipe RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # Simpan presentasi ke disk.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **Check Whether a Shape Is a Text Box**

Aspose.Slides menyediakan properti [is_text_box](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/is_text_box/) pada kelas [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) yang memungkinkan Anda menentukan apakah suatu shape adalah kotak teks.

![Kotak teks dan shape](istextbox.png)

Contoh Python ini menunjukkan cara memeriksa apakah sebuah shape dibuat sebagai kotak teks:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

Perhatikan bahwa jika Anda menambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) menggunakan kelas [ShapeCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/), properti `is_text_box` pada shape tersebut akan mengembalikan `False`. Namun, setelah Anda menambahkan teks—baik dengan metode `add_text_frame` maupun dengan menyetel properti `text`—`is_text_box` akan mengembalikan `True`.

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

## **Add Columns to Text Boxes**

Aspose.Slides menyediakan properti [column_count](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframeformat/column_count/) dan [column_spacing](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframeformat/column_spacing/) pada kelas [TextFrameFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframeformat/) untuk menambahkan kolom ke kotak teks. Anda dapat menentukan jumlah kolom dan mengatur jarak (dalam poin) antar kolom.

Kode Python berikut mendemonstrasikan operasi ini:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Dapatkan slide pertama dalam presentasi.
	slide = presentation.slides[0]

	# Tambahkan AutoShape dengan tipe RECTANGLE.
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

## **Update Text**

Aspose.Slides memungkinkan Anda memperbarui teks dalam satu kotak teks atau di seluruh presentasi.

Contoh Python berikut memperlihatkan cara memperbarui semua teks dalam sebuah presentasi:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = 1
  
    # Simpan presentasi yang telah dimodifikasi.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **Add Text Boxes with Hyperlinks**

Anda dapat menyisipkan tautan dalam kotak teks. Saat kotak teks diklik, tautan akan terbuka.

Untuk menambahkan kotak teks yang berisi hyperlink, ikuti langkah‑langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Dapatkan referensi ke slide pertama.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) dengan `ShapeType.RECTANGLE` pada posisi yang diinginkan di slide.
4. Atur teks pada [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) shape tersebut.
5. Dapatkan referensi ke [HyperlinkManager](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlinkmanager/).
6. Gunakan properti `hyperlink_manager` untuk menetapkan hyperlink klik eksternal.
7. Simpan presentasi sebagai file PPTX.

Contoh Python ini menunjukkan cara menambahkan kotak teks dengan hyperlink ke slide:

```py
import aspose.slides as slides

# Membuat instance kelas Presentation.
with slides.Presentation() as presentation:

    # Dapatkan slide pertama dalam presentasi.
    slide = presentation.slides[0]

    # Tambahkan AutoShape dengan tipe RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # Tambahkan teks ke dalam frame.
    text_portion.text = "Aspose.Slides"

    # Atur hyperlink untuk teks bagian.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # Simpan presentasi sebagai file PPTX.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apa perbedaan antara kotak teks dan placeholder teks saat bekerja dengan master slide?**

Sebuah [placeholder](/slides/id/python-net/manage-placeholder/) mewarisi gaya/posisi dari [master](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterslide/) dan dapat ditimpa pada [layout](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutslide/), sementara kotak teks biasa adalah objek independen pada slide tertentu dan tidak berubah ketika Anda beralih layout.

**Bagaimana cara melakukan penggantian teks secara massal di seluruh presentasi tanpa menyentuh teks di dalam grafik, tabel, dan SmartArt?**

Batasi iterasi Anda pada auto‑shape yang memiliki frame teks dan kecualikan objek tersemat ([chart](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/), [table](https://reference.aspose.com/slides/id/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/id/python-net/aspose.slides.smartart/smartart/)) dengan menelusuri koleksi masing‑masing secara terpisah atau melewati tipe objek tersebut.