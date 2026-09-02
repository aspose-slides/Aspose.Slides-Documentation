---
title: Kelola Komentar Presentasi di Python
linktitle: Komentar Presentasi
type: docs
weight: 100
url: /id/python-net/presentation-comments/
keywords:
- komentar
- komentar modern
- komentar PowerPoint
- komentar presentasi
- komentar slide
- tambah komentar
- akses komentar
- edit komentar
- balas komentar
- hapus komentar
- menghapus komentar
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Kelola komentar presentasi dengan Aspose.Slides untuk Python via .NET: menambah, membaca, mengedit, membalas, dan menghapus komentar dalam presentasi PowerPoint."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengelola komentar presentasi dengan Aspose.Slides untuk Python via .NET. Artikel ini memperkenalkan tipe utama yang terkait dengan komentar dan memperlihatkan cara menambahkan komentar ke slide, mengakses komentar yang ada, bekerja dengan balasan dan komentar modern, serta menghapus komentar dari presentasi.

Contoh-contoh mencakup skenario peninjauan dan kolaborasi umum di PowerPoint, seperti menetapkan komentar kepada penulis, membaca teks komentar dan metadata, membuat rantai balasan, serta menghapus komentar yang dipilih atau semua komentar.

Di PowerPoint, komentar muncul sebagai anotasi pada slide. Memilih sebuah komentar menampilkan teksnya dan diskusi terkait.

## **Mengapa Menambahkan Komentar ke Presentasi?**

Anda dapat menggunakan komentar untuk memberikan umpan balik dan berkolaborasi dengan rekan kerja saat meninjau presentasi.

Aspose.Slides untuk Python via .NET menyediakan API berikut untuk bekerja dengan komentar:

* Kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) yang menyediakan akses ke penulis komentar presentasi.
* Kelas [CommentCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/commentcollection/) yang mewakili komentar yang terkait dengan penulis tertentu.
* Kelas [Comment](https://reference.aspose.com/slides/id/python-net/aspose.slides/comment/) yang menyediakan informasi tentang sebuah komentar, termasuk penulisnya, waktu pembuatan, posisi, dan teks.
* Kelas [CommentAuthor](https://reference.aspose.com/slides/id/python-net/aspose.slides/commentauthor/) yang menyediakan informasi tentang seorang penulis, termasuk nama, inisial, dan komentar terkait.

## **Menambahkan Komentar Slide**

Contoh berikut menunjukkan cara menambahkan komentar ke slide dalam presentasi PowerPoint:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = draw.PointF(0.2, 0.2)
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

## **Mengakses Komentar Slide**

Contoh berikut menunjukkan cara mengakses komentar yang ada dalam presentasi PowerPoint:

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

Komentar induk adalah komentar asli di puncak hierarki balasan. Properti [parent_comment](https://reference.aspose.com/slides/id/python-net/aspose.slides/comment/parent_comment/) dari kelas [Comment](https://reference.aspose.com/slides/id/python-net/aspose.slides/comment/) memungkinkan Anda mendapatkan atau mengatur induk sebuah komentar.

Contoh berikut menunjukkan cara menambahkan balasan dan memeriksa hierarki komentar yang dihasilkan:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    position = draw.PointF(10, 10)
    created_time = datetime.now()

    author1 = presentation.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment 1", slide, position, created_time)

    author2 = presentation.comment_authors.add_author("Author_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    reply1.parent_comment = comment1

    reply2 = author2.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    reply2.parent_comment = comment1

    sub_reply = author1.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = reply2

    author2.comments.add_comment("comment 2", slide, position, created_time)
    comment3 = author2.comments.add_comment("comment 3", slide, position, created_time)

    reply3 = author1.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    reply3.parent_comment = comment3

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    comment1.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
* Saat metode [remove](https://reference.aspose.com/slides/id/python-net/aspose.slides/comment/remove/) dari kelas [Comment](https://reference.aspose.com/slides/id/python-net/aspose.slides/comment/) digunakan untuk menghapus sebuah komentar, semua balasan terhadap komentar tersebut juga dihapus.
* Jika properti [parent_comment](https://reference.aspose.com/slides/id/python-net/aspose.slides/comment/parent_comment/) membuat referensi melingkar, sebuah [PptxEditException](https://reference.aspose.com/slides/id/python-net/aspose.slides/pptxeditexception/) akan dilempar.
{{% /alert %}}

## **Menambahkan Komentar Modern**

Komentar modern dapat dikaitkan dengan slide itu sendiri, dengan bentuk tertentu, atau dengan rentang teks di dalam AutoShape. Metode [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/id/python-net/aspose.slides/commentcollection/add_modern_comment/) menerima argumen [Shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/) selain slide dan koordinat penanda komentar.

Ketika `None` diberikan untuk argumen shape, komentar tersebut menjadi komentar tingkat slide. Penandanya diposisikan oleh koordinat yang diberikan, namun tidak terkait dengan shape tertentu, sehingga [ModernComment.shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/moderncomment/shape/) mengembalikan `None`. Ketika sebuah [Shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/) diberikan, komentar dipasang pada shape tersebut. Koordinat tetap menentukan posisi penanda komentar pada slide, sementara asosiasi shape dapat diambil melalui [ModernComment.shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/moderncomment/shape/).

### **Menyambungkan Komentar Modern ke Sebuah Shape**

Contoh berikut membuat komentar modern tingkat slide dan komentar modern yang dipasang pada AutoShape tertentu. Kemudian membaca shape yang terkait dari setiap komentar.

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = draw.PointF(20, 20)
    shape_comment_position = draw.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **Menyambungkan Komentar ke Berbagai Jenis Shape**

Setiap objek slide yang diturunkan dari [Shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/) dapat digunakan sebagai jangkar shape. Contoh umum meliputi [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/id/python-net/aspose.slides/connector/), dan instance [GraphicalObject](https://reference.aspose.com/slides/id/python-net/aspose.slides/graphicalobject/) seperti diagram.

Contoh berikut membuat beberapa jenis shape umum dan mengaitkan komentar modern dengan masing-masing.

```python
import base64
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"
    auto_shape_comment_position = draw.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = draw.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = draw.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = draw.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = draw.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **Menyambungkan Komentar ke Teks dan Mengatur Statusnya**

Untuk komentar modern yang terkait dengan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/id/python-net/aspose.slides/moderncomment/text_selection_start/) menentukan posisi awal teks yang dipilih dalam bingkai teks shape, sedangkan [ModernComment.text_selection_length](https://reference.aspose.com/slides/id/python-net/aspose.slides/moderncomment/text_selection_length/) menentukan panjang pilihan. Bersama-sama, properti ini mengaitkan komentar dengan rentang teks tertentu di dalam AutoShape.

Properti [ModernComment.status](https://reference.aspose.com/slides/id/python-net/aspose.slides/moderncomment/status/) dapat dibaca atau diperbarui dengan nilai dari enumerasi [ModernCommentStatus](https://reference.aspose.com/slides/id/python-net/aspose.slides/moderncommentstatus/):

- `NOT_DEFINED` — tidak ada status komentar modern yang spesifik yang didefinisikan.
- `ACTIVE` — komentar aktif.
- `RESOLVED` — komentar telah diselesaikan.
- `CLOSED` — komentar ditutup.

Contoh berikut membuat komentar modern yang dipasang pada shape, mengaitkannya dengan seleksi teks, menandainya sebagai terselesaikan, menyimpan presentasi, dan memverifikasi nilai-nilai setelah membuka kembali file.

```python
from datetime import datetime

import aspose.pydrawing as draw
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
    comment_position = draw.PointF(60, 60)
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

Untuk memeriksa presentasi yang ada, periksa komentar mana yang merupakan instance [ModernComment](https://reference.aspose.com/slides/id/python-net/aspose.slides/moderncomment/), kemudian periksa [ModernComment.shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/id/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/id/python-net/aspose.slides/moderncomment/text_selection_length/), dan [ModernComment.status](https://reference.aspose.com/slides/id/python-net/aspose.slides/moderncomment/status/). Shape `None` menunjukkan komentar tingkat slide. Untuk jangkar [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/), properti seleksi teks mengidentifikasi rentang yang terkait dalam bingkai teks shape.

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

### **Menghapus Semua Komentar dan Penulis Komentar**

Contoh berikut menunjukkan cara menghapus semua komentar dan penulis komentar dari sebuah presentasi:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()
    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Menghapus Komentar Tertentu**

Contoh berikut menunjukkan cara menghapus komentar tertentu dari sebuah slide:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = draw.PointF(0.2, 0.2)
    second_comment_position = draw.PointF(0.3, 0.2)
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

**Apakah Aspose.Slides mendukung status terselesaikan untuk komentar modern?**

Ya. [ModernComment.status](https://reference.aspose.com/slides/id/python-net/aspose.slides/moderncomment/status/) dapat dibaca dan diatur dengan nilai [ModernCommentStatus](https://reference.aspose.com/slides/id/python-net/aspose.slides/moderncommentstatus/), termasuk `RESOLVED`. Status tersebut disimpan dalam presentasi dan dapat dibaca kembali setelah file dibuka kembali.

**Apakah diskusi berulir (rantai balasan) didukung, dan apakah ada batas kedalaman nesting?**

Ya. Setiap komentar dapat merujuk ke [parent comment](https://reference.aspose.com/slides/id/python-net/aspose.slides/comment/parent_comment/)‑nya, memungkinkan rantai balasan. API tidak menetapkan batas kedalaman nesting yang spesifik.

**Dalam sistem koordinat apa posisi penanda komentar didefinisikan pada slide?**

Posisi penanda didefinisikan oleh koordinat floating-point dalam sistem koordinat slide, memungkinkan Anda menempatkannya secara tepat pada slide.