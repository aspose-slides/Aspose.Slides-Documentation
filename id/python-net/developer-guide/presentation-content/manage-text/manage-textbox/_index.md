---
title: Kelola Kotak Teks dalam Presentasi dengan Python
linktitle: Kelola Kotak Teks
type: docs
weight: 20
url: /id/python-net/manage-textbox/
keywords:
- kotak teks
- bingkai teks
- tambahkan teks
- perbarui teks
- buat kotak teks
- periksa kotak teks
- tambahkan kolom teks
- tambahkan tautan hiper
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Buat, identifikasi, format, dan perbarui kotak teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python via .NET."
---
## **Pendahuluan**

Dalam Aspose.Slides untuk Python via .NET, teks slide disimpan dalam bingkai teks yang merupakan bagian dari bentuk. Kelas [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) mewakili bentuk yang paling umum membawa teks dan mengekspos teksnya melalui properti [AutoShape.text_frame](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/text_frame/).

{{% alert color="info" title="Catatan" %}}
Setiap auto shape mewarisi dari [Shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/), tetapi tidak setiap bentuk adalah auto shape atau mendukung bingkai teks. Saat memproses presentasi yang ada, gunakan `isinstance(shape, slides.AutoShape)` untuk memeriksa jenis bentuk sebelum mengakses teksnya.
{{% /alert %}}

## **Buat Kotak Teks pada Slide**

Untuk membuat kotak teks, tambahkan auto shape ke slide, tambahkan teks ke bingkai teksnya, dan simpan presentasi. Contoh berikut membuat kotak teks berbentuk persegi panjang:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 300, 50)
    text_box.add_text_frame("Aspose TextBox")

    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

Koordinat dan dimensi yang diberikan ke [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/add_auto_shape/) diukur dalam poin. [AutoShape.add_text_frame](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/add_text_frame/) menginisialisasi bingkai teks dengan teks yang diberikan.

## **Periksa Apakah Suatu Bentuk Merupakan Kotak Teks**

Gunakan properti [AutoShape.is_text_box](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/is_text_box/) untuk menentukan apakah auto shape diperlakukan sebagai kotak teks. Ini berguna ketika sebuah presentasi berisi baik auto shape yang membawa teks maupun yang hanya grafis.

![Kotak teks dan sebuah bentuk](istextbox.png)

Contoh berikut memeriksa setiap auto shape dalam sebuah presentasi:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 120, 40)
    text_box.add_text_frame("Text box")
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 10, 40, 40)

    for current_slide in presentation.slides:
        for shape in current_slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("The shape is a text box." if shape.is_text_box else "The shape is not a text box.")
```

Auto shape yang baru ditambahkan tidak dianggap sebagai kotak teks hingga berisi teks yang tidak kosong. Anda dapat menyediakan teks tersebut melalui [AutoShape.add_text_frame](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/add_text_frame/) atau [TextFrame.text](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/text/). Menambahkan atau menetapkan string kosong membuat [is_text_box](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/is_text_box/) tetap `False`:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    shape1.add_text_frame("Shape 1")
    print(shape1.is_text_box)

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 100, 40)
    shape2.text_frame.text = "Shape 2"
    print(shape2.is_text_box)

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 100, 40)
    shape3.add_text_frame("")
    print(shape3.is_text_box)

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 100, 40)
    shape4.text_frame.text = ""
    print(shape4.is_text_box)
```

Dua pemanggilan pertama mencetak `True`; dua pemanggilan terakhir mencetak `False`.

## **Temukan Bentuk yang Memiliki Bingkai Teks**

Kode pemrosesan teks umum mungkin menerima sebuah [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) tanpa mengetahui objek presentasi mana yang memuatnya. Gunakan properti baca-saja [TextFrame.parent_shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/parent_shape/) untuk menavigasi kembali ke [Shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/) pemiliknya.

Untuk bingkai teks yang dimiliki oleh auto shape atau bentuk lain yang membawa teks, [parent_shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/parent_shape/) berisi pemiliknya dan [TextFrame.parent_cell](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/parent_cell/) bernilai `None`. Periksa nilai yang dikembalikan sebelum mengaksesnya. Untuk mengidentifikasi baik pemilik bentuk maupun sel tabel, termasuk bentuk yang terkait dengan node SmartArt, lihat [Search and Replace Text](/slides/id/python-net/search-and-replace-text/).

## **Tambahkan Kolom ke Kotak Teks**

Properti [TextFrameFormat.column_count](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframeformat/column_count/) membagi bingkai teks menjadi kolom, sementara [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframeformat/column_spacing/) mengatur jarak antara kolom dalam poin. Kedua pengaturan termasuk dalam [TextFrameFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframeformat/) dan dapat diubah melalui bingkai teks kotak teks yang ada. Teks mengalir kembali antar kolom di dalam bentuk yang sama; tidak berlanjut ke bentuk lain.

Contoh berikut membuat kotak teks tiga kolom dengan jarak 10 poin antar kolom, menyimpan presentasi, dan membaca kembali pengaturan yang disimpan dari file output:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 200)
    text_box.add_text_frame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.text_frame.text_frame_format
    text_frame_format.column_count = 3
    text_frame_format.column_spacing = 10

    presentation.save("TextBoxColumns.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("TextBoxColumns.pptx") as saved_presentation:
    saved_text_box = saved_presentation.slides[0].shapes[0]
    if isinstance(saved_text_box, slides.AutoShape):
        saved_format = saved_text_box.text_frame.text_frame_format
        print(f"Columns: {saved_format.column_count}; spacing: {saved_format.column_spacing} points")
```

## **Ekstrak Teks dari Setiap Kolom**

Gunakan [TextFrame.split_text_by_columns](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/split_text_by_columns/) untuk mengambil teks yang ditetapkan ke setiap kolom visual dalam bingkai teks yang ada. Metode ini mengembalikan satu string untuk setiap kolom, dalam urutan baca berbasis kolom. Bingkai teks satu kolom menghasilkan daftar dengan satu elemen, dan kolom kosong direpresentasikan oleh string kosong. String yang dihasilkan hanya berisi teks biasa; pemformatan tingkat bagian tidak dipertahankan.

Ini berguna ketika Anda perlu:

- Mengekstrak teks sambil mempertahankan urutan baca berbasis kolom.
- Mengindeks atau membandingkan konten slide multi‑kolom.
- Mengekspor setiap kolom ke file terpisah, bidang basis data, atau tujuan lain.
- Memeriksa bagaimana teks didistribusikan kembali setelah mengubah [TextFrameFormat.column_count](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframeformat/column_count/), [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframeformat/column_spacing/), font, atau ukuran bingkai teks.

Metode ini melaporkan teks yang tersebar dalam [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) saat ini; ia tidak secara otomatis mengalirkan teks antar bentuk atau kotak teks yang terpisah. Distribusi kolom dapat bergantung pada font yang tersedia dan pengaturan tata letak teks lainnya, jadi pastikan font yang diperlukan tersedia ketika hasil yang konsisten penting.

Contoh berikut memuat sebuah presentasi, menemukan auto shape multi‑kolom pertama dengan bingkai teks, membaca jumlah kolom yang dikonfigurasi, dan menulis teks dari setiap kolom ke file terpisah. Bentuk yang tidak menyediakan bingkai teks dilewati.

```python
import aspose.slides as slides

with slides.Presentation("MultiColumnText.pptx") as presentation:
    text_box = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
            column_count = shape.text_frame.text_frame_format.column_count
            if column_count > 1:
                text_box = shape
                break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.text_frame
        configured_column_count = text_frame.text_frame_format.column_count
        column_texts = text_frame.split_text_by_columns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            with open(f"Column-{column_number}.txt", "w", encoding="utf-8") as column_file:
                column_file.write(column_text)
```

## **Perbarui Teks**

Untuk memperbarui teks di seluruh presentasi, iterasikan slide dan bentuk, pilih auto shape, dan kemudian edit bagian teksnya. Bekerja pada tingkat bagian memungkinkan Anda mengubah teks serta pemformatan karakter.

Contoh berikut menggantikan setiap kemunculan `years` dengan `months` dalam teks auto‑shape dan menjadikan setiap bagian yang terpengaruh tebal:

```python
import aspose.slides as slides

with slides.Presentation("Text.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if "years" in portion.text:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

Penelusuran ini memperbarui teks hanya pada auto shape. Teks yang disimpan dalam tabel, diagram, SmartArt, atau bentuk berkelompok memerlukan penelusuran koleksi masing‑masing objek tersebut.

## **Tambahkan Kotak Teks dengan Tautan Hiper**

Tautan hiper dapat ditetapkan ke bagian teks tertentu, sehingga hanya teks itu yang berfungsi sebagai tautan yang dapat diklik. Gunakan [HyperlinkManager.set_external_hyperlink_click](https://reference.aspose.com/slides/id/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/) untuk mengaitkan bagian tersebut dengan URL eksternal.

Contoh berikut membuat teks bertautan dan menyimpannya ke dalam presentasi:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 200, 50)
    text_box.add_text_frame("Aspose.Slides")

    text_portion = text_box.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apa perbedaan antara kotak teks dan placeholder teks pada slide master atau layout?**

Sebuah [placeholder](/slides/id/python-net/manage-placeholder/) dapat mewarisi posisi dan pemformatannya dari [master slide](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterslide/) atau [layout slide](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutslide/). Kotak teks biasa adalah bentuk independen pada slide tempat ia dibuat dan tidak memperoleh perilaku placeholder ketika tata letak berubah.

**Bagaimana cara mengganti teks tanpa mengubah teks dalam diagram, tabel, atau SmartArt?**

Batasi penelusuran hanya pada instance [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) seperti yang ditunjukkan pada contoh Perbarui Teks. Diagram, tabel, dan SmartArt menyimpan teks dalam model objek mereka masing‑masing, sehingga tidak dimodifikasi oleh loop tersebut.