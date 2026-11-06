---
title: "Kelola Komentar Presentasi dalam Python"
linktitle: "Komentar Presentasi"
type: docs
weight: 100
url: /id/python-net/presentation-comments/
keywords:
- komentar
- komentar modern
- komentar PowerPoint
- komentar presentasi
- komentar slide
- tambahkan komentar
- akses komentar
- edit komentar
- balas komentar
- hapus komentar
- hapus komentar
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Kelola komentar presentasi dengan Aspose.Slides untuk Python via .NET: tambahkan, baca, edit, balas, dan hapus komentar dalam presentasi PowerPoint."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengelola komentar presentasi dengan Aspose.Slides untuk Python via .NET. Artikel ini memperkenalkan tipe utama yang terkait dengan komentar dan mendemonstrasikan cara menambahkan komentar ke slide, mengakses komentar yang ada, bekerja dengan balasan dan komentar modern, serta menghapus komentar dari presentasi.

Contoh‑contoh mencakup skenario peninjauan dan kolaborasi umum di PowerPoint, seperti menetapkan komentar kepada penulis, membaca teks komentar dan metadata, membangun rantai balasan, serta menghapus komentar yang dipilih atau semua komentar.

Di PowerPoint, komentar muncul sebagai anotasi pada slide. Memilih sebuah komentar menampilkan teksnya dan diskusi terkait.

Untuk meminta agar komentar ditampilkan atau disembunyikan saat presentasi dibuka tanpa mengubah komentar itu sendiri, lihat [Tampilkan atau Sembunyikan Komentar saat Membuka Presentasi](/slides/id/python-net/presentation-view-properties/).

## **Mengapa Menambahkan Komentar ke Presentasi?**

Anda dapat menggunakan komentar untuk memberikan umpan balik dan berkolaborasi dengan rekan kerja saat meninjau presentasi.

Aspose.Slides untuk Python via .NET menyediakan API berikut untuk bekerja dengan komentar:

* Kelas [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) yang memberikan akses ke penulis komentar presentasi.
* Kelas [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) yang mewakili komentar yang terkait dengan masing-masing penulis.
* Kelas [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) yang menyediakan informasi tentang sebuah komentar, termasuk penulis, waktu pembuatan, posisi, dan teks.
* Kelas [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) yang menyediakan informasi tentang seorang penulis, termasuk nama, inisial, dan komentar yang terkait.

## **Menambahkan Komentar Slide**

Contoh ini membuat dua slide dan mendaftarkan penulis komentar dengan [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/). Ia menggunakan [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) untuk menempatkan satu komentar pada setiap slide, kemudian mengambil komentar slide pertama untuk penulis tersebut dengan [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/). Konsol menampilkan teks komentar pertama dua kali, menunjukkan akses melalui slide dan penulis, dan presentasi yang disimpan berisi kedua komentar.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])

    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = slides.PointF(0.2, 0.2)
    created_time = datetime.now()

    author.comments.add_comment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.comments.add_comment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.get_slide_comments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.text)

        comment_text = first_comment.author.comments[0].text
        print(comment_text)

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Temukan atau Buat Penulis Komentar**

Ketika ulasan otomatis memproses presentasi yang sama berulang kali, cari koleksi [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/) terlebih dahulu sebelum menambahkan penulis. Metode [find_by_name_and_initials](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name_and_initials/) mencocokkan nama dan inisial serta mengembalikan array penulis yang cocok, atau array kosong bila tidak ada yang cocok. Sebaliknya, [find_by_name](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name/) mencari hanya berdasarkan nama, terlepas dari inisial. Memanggil [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/) dengan nama dan inisial yang sudah ada di koleksi akan menghasilkan pengecualian.

Contoh ini memerlukan file presentasi dengan setidaknya satu slide. Pada masing‑masing dua putaran, ia kembali menggunakan penulis pertama yang cocok, atau membuat satu hanya bila hasilnya kosong. Jika ada beberapa cocok, ia memilih elemen array pertama tanpa menggabungkan atau menghapus penulis lain. Kemudian ia memanggil [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) untuk penulis terpilih dan menyimpan presentasi. Putaran kedua membuka hasil putaran pertama dan mengulangi operasi.

```python
from datetime import datetime

import aspose.slides as slides

author_name = "Reviewer"
author_initials = "RV"

input_file = "input.pptx"
position = slides.PointF(20, 20)

for pass_number in range(1, 3):
    with slides.Presentation(input_file) as presentation:
        matches = presentation.comment_authors.find_by_name_and_initials(author_name, author_initials)

        author = matches[0] if len(matches) > 0 else presentation.comment_authors.add_author(author_name, author_initials)
        author.comments.add_comment("Please review this slide.", presentation.slides[0], position, datetime.now())

        output_file = f"review_pass_{pass_number}.pptx"
        presentation.save(output_file, slides.export.SaveFormat.PPTX)
        input_file = output_file
```

Putaran kedua menambahkan komentar lain tanpa menambahkan penulis lain atau menghapus komentar yang ada. File akhir, `review_pass_2.pptx`, berisi kedua komentar baru bersamaan dengan komentar asli apa pun. Menggunakan kembali penulis tidak menduplikasi komentar: untuk menghindari penambahan komentar yang sama berulang‑ulang, terapkan deteksi duplikat terpisah sebelum menambahkannya.

## **Akses Komentar Slide**

Contoh ini membuka presentasi yang ada dan membaca koleksi [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/). Untuk setiap penulis, ia menelusuri [comments](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/comments/) dan mencetak nomor slide, teks komentar, nama penulis, serta waktu pembuatan. Presentasi masukan harus berisi komentar agar menghasilkan output konsol.

```python
import aspose.slides as slides

with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("Slide: " + str(comment.slide.slide_number))
            print("Comment: " + comment.text)
            print("Author: " + comment.author.name)
            print("Posted at: " + str(comment.created_time))
            print()
```

## **Membalas Komentar**

Komentar induk adalah komentar asli di puncak hierarki balasan. Properti [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) pada kelas [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) memungkinkan Anda mendapatkan atau mengatur induk sebuah komentar.

Contoh ini membuat komentar dari dua penulis dan menggunakan [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) untuk membangun balasan, termasuk balasan ke balasan lain. Menyerahkan `None` ke [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) mengambil komentar dari semua penulis; konsol memberi indentasi tiap entri sesuai kedalaman dalam hierarki balasan. Contoh menyimpan seluruh diskusi, memanggil [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) pada komentar akar pertama, dan menyimpan presentasi kedua dengan komentar tersebut serta balasannya dihapus.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    position = slides.PointF(10, 10)
    created_time = datetime.now()

    original_author = presentation.comment_authors.add_author("Author_1", "A.A.")
    root_comment = original_author.comments.add_comment("comment 1", slide, position, created_time)

    reviewer = presentation.comment_authors.add_author("Author_2", "B.B.")
    first_reply = reviewer.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    first_reply.parent_comment = root_comment

    second_reply = reviewer.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    second_reply.parent_comment = root_comment

    sub_reply = original_author.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = second_reply

    reviewer.comments.add_comment("comment 2", slide, position, created_time)
    separate_comment = reviewer.comments.add_comment("comment 3", slide, position, created_time)

    separate_reply = original_author.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    separate_reply.parent_comment = separate_comment

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    root_comment.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
* Ketika metode [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) pada kelas [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) digunakan untuk menghapus sebuah komentar, semua balasan ke komentar tersebut juga dihapus.
* Jika properti [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) membuat referensi melingkar, sebuah [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/) akan dilemparkan.
{{% /alert %}}

## **Menambahkan Komentar Modern**

Komentar modern dapat dikaitkan dengan slide itu sendiri, dengan bentuk tertentu, atau dengan rentang teks di dalam AutoShape. Metode [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) menerima argumen [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) selain slide dan koordinat penanda komentar.

Ketika `None` diberikan untuk argumen shape, komentar menjadi komentar tingkat slide. Penanda ditempatkan oleh koordinat yang diberikan, tetapi tidak terkait dengan shape tertentu, sehingga [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) mengembalikan `None`. Ketika sebuah [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) disediakan, komentar diikat ke shape tersebut. Koordinat tetap menentukan posisi penanda komentar pada slide, sementara asosiasi shape dapat diambil melalui [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/).

### **Menambatkan Komentar Modern ke Bentuk**

Contoh memanggil [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) dua kali: sekali dengan shape `None` untuk komentar tingkat slide dan sekali dengan persegi panjang sebagai jangkar. Membaca [shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) mencetak `True` untuk pemeriksaan null pada komentar tingkat slide dan `Revenue title` untuk komentar yang dijangkarkan. Kedua komentar disimpan bersama presentasi.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Reviewer", "RV")

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = slides.PointF(20, 20)
    shape_comment_position = slides.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **Menambatkan Komentar ke Berbagai Jenis Bentuk**

Setiap objek slide yang diturunkan dari [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) dapat digunakan sebagai jangkar bentuk. Contoh umum meliputi [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/), dan instance [GraphicalObject](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobject/) seperti diagram.

Contoh menggunakan [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) untuk mengaitkan komentar dengan masing‑masing lima jenis bentuk: sebuah AutoShape, sebuah picture frame, sebuah grup, sebuah connector, dan sebuah diagram. Gambar menggunakan data gambar tersemat, jadi tidak memerlukan gambar eksternal. Setiap komentar memiliki posisi penanda masing‑masing, dan presentasi yang disimpan mempertahankan kelima asosiasi bentuk tersebut.

```python
import base64
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"

    auto_shape_comment_position = slides.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = slides.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = slides.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = slides.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = slides.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **Menambatkan Komentar ke Teks dan Menetapkan Statusnya**

Untuk komentar modern yang terkait dengan sebuah [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), properti [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) menentukan posisi mulai teks yang dipilih dalam frame teks shape, sedangkan [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) menentukan panjang seleksi. Kedua properti ini mengaitkan komentar dengan rentang teks tertentu di dalam AutoShape.

Properti [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) dapat dibaca atau diperbarui dengan nilai dari enumerasi [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/):

- `NOT_DEFINED` — tidak ada status komentar modern yang khusus.
- `ACTIVE` — komentar aktif.
- `RESOLVED` — komentar telah diselesaikan.
- `CLOSED` — komentar ditutup.

Contoh menambatkan komentar modern ke kata “quarterly revenue” dalam teks persegi panjang. Ia menghitung [text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) berbasis nol dari teks dan mengatur [text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) ke jumlah karakter yang dipilih. Setelah menetapkan [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) ke `RESOLVED`, ia menyimpan dan membuka kembali presentasi. Empat pemeriksaan konsol masing‑masing harus mencetak `True`, mengonfirmasi bahwa jangkar bentuk, rentang teks, dan status tetap terjaga.

```python
from datetime import datetime

import aspose.slides as slides

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.index(selected_text)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 100)
    shape.name = "Forecast text"
    shape.text_frame.text = shape_text

    author = presentation.comment_authors.add_author("Reviewer", "RV")
    comment_position = slides.PointF(60, 60)
    comment = author.comments.add_modern_comment("Verify this forecast wording.", slide, shape, comment_position, datetime.now())
    comment.text_selection_start = expected_selection_start
    comment.text_selection_length = len(selected_text)
    comment.status = slides.ModernCommentStatus.RESOLVED

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_comments = reopened_slide.get_slide_comments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, slides.ModernComment):
            continue

        shape_matches = reopened_comment.shape.name == "Forecast text"
        selection_start_matches = reopened_comment.text_selection_start == expected_selection_start
        selection_length_matches = reopened_comment.text_selection_length == len(selected_text)
        status_matches = reopened_comment.status == slides.ModernCommentStatus.RESOLVED

        print("Shape anchor preserved: " + str(shape_matches))
        print("Text selection start preserved: " + str(selection_start_matches))
        print("Text selection length preserved: " + str(selection_length_matches))
        print("Resolved status preserved: " + str(status_matches))
```

### **Memeriksa Komentar Modern yang Ada**

Contoh ini memerlukan presentasi yang sudah ada dan berisi komentar modern, kemudian mencetak teks, status, dan detail jangkarnya. Untuk memeriksanya, periksa komentar mana yang merupakan instance [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/), lalu tinjau [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/), dan [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/). Sebuah shape `None` menandakan komentar tingkat slide. Untuk jangkar [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), properti pemilihan‑teks mengidentifikasi rentang yang terkait dalam frame teks shape.

```python
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    for slide in presentation.slides:
        comments = slide.get_slide_comments(None)
        for comment in comments:
            if not isinstance(comment, slides.ModernComment):
                continue

            print("Slide: " + str(slide.slide_number))
            print("Text: " + comment.text)
            print("Status: " + str(comment.status))

            shape = comment.shape
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: " + shape.name)
                print("Anchor type: " + type(shape).__name__)

                if isinstance(shape, slides.AutoShape):
                    print("Text selection start: " + str(comment.text_selection_start))
                    print("Text selection length: " + str(comment.text_selection_length))

            print()
```

## **Menghapus Komentar**

Aspose.Slides untuk Python via .NET memungkinkan Anda menghapus semua komentar dan penulisnya dari sebuah presentasi atau menghapus komentar terpilih sementara membiarkan yang lain tetap ada. Contoh‑contoh berikut menunjukkan kedua pendekatan dan menyimpan presentasi yang telah diperbarui.

### **Menghapus Semua Komentar dan Penulis Komentar**

Contoh ini membuka presentasi yang ada dan memanggil [CommentCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/clear/) untuk setiap penulis, kemudian memanggil [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/clear/) untuk menghapus penulis itu sendiri. Presentasi yang disimpan tidak mengandung komentar maupun penulis komentar. Gunakan sebuah presentasi yang berisi komentar untuk melihat proses penghapusan.

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Menghapus Komentar Tertentu**

Contoh ini membuat dua komentar pada satu slide dan menggunakan [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) untuk menemukan komentar masing‑masing penulis. Ia mengumpulkan komentar yang teksnya sama dengan “comment 1” sebelum memanggil [CommentCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/remove/), menghindari perubahan pada koleksi selama pemilihan. Presentasi yang disimpan hanya menyisakan “comment 2”.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = slides.PointF(0.2, 0.2)
    second_comment_position = slides.PointF(0.3, 0.2)
    author.comments.add_comment("comment 1", slide, first_comment_position, created_time)
    author.comments.add_comment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.comment_authors:
        comments_to_remove = []
        comments = slide.get_slide_comments(comment_author)

        for comment in comments:
            if comment.text == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.comments.remove(comment)

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah Aspose.Slides mendukung status selesai untuk komentar modern?**

Ya. [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) dapat dibaca dan diatur dengan nilai dari [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/), termasuk `RESOLVED`. Status disimpan dalam presentasi dan dapat dibaca kembali setelah file dibuka kembali.

**Apakah diskusi beruntai (rantai balasan) didukung, dan apakah ada batas kedalaman?**

Ya. Setiap komentar dapat merujuk ke [parent comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/), memungkinkan rantai balasan. API tidak menetapkan batas kedalaman penumpukan tertentu.

**Dalam sistem koordinat apa posisi penanda komentar didefinisikan pada slide?**

Posisi penanda didefinisikan oleh koordinat titik mengambang dalam sistem koordinat slide, memungkinkan penempatan yang tepat pada slide.