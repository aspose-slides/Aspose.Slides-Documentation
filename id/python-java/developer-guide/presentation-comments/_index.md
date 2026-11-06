---
title: Kelola Komentar Presentasi di Python via Java
linktitle: Komentar Presentasi
type: docs
weight: 100
url: /id/python-java/presentation-comments/
keywords:
- komentar
- komentar modern
- komentar PowerPoint
- komentar presentasi
- komentar slide
- tambahkan komentar
- akses komentar
- sunting komentar
- balas komentar
- hapus komentar
- hapus komentar
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Kelola komentar presentasi dengan Aspose.Slides untuk Python via Java: tambahkan, baca, sunting, balas, dan hapus komentar dalam presentasi PowerPoint dengan cepat dan mudah."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mengelola komentar presentasi dengan Aspose.Slides untuk Python via Java. Artikel ini memperkenalkan tipe‑tipe utama terkait komentar dan mendemonstrasikan cara menambahkan komentar ke slide, mengakses komentar yang ada, bekerja dengan balasan dan komentar modern, serta menghapus komentar dari sebuah presentasi.

Contoh‑contoh mencakup skenario peninjauan dan kolaborasi umum di PowerPoint, seperti menetapkan komentar kepada penulis, membaca teks komentar dan metadata, membangun rantai balasan, serta menghapus komentar yang dipilih atau semua komentar.

Di PowerPoint, komentar muncul sebagai anotasi pada slide. Memilih sebuah komentar menampilkan teksnya dan diskusi terkait.

Untuk meminta agar komentar ditampilkan atau disembunyikan saat presentasi dibuka tanpa mengubah komentar itu sendiri, lihat [Tampilkan atau Sembunyikan Komentar Saat Membuka Presentasi](/slides/id/python-java/presentation-view-properties/).

## **Mengapa Menambahkan Komentar ke Presentasi?**

Anda dapat menggunakan komentar untuk memberikan masukan dan berkolaborasi dengan rekan kerja saat meninjau presentasi.

Aspose.Slides for Python via Java menyediakan API berikut untuk bekerja dengan komentar:

* The [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class, yang memberikan akses ke penulis komentar presentasi.
* The [CommentCollection](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/) class, yang mewakili komentar yang terkait dengan seorang penulis.
* The [Comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/) class, yang memberikan informasi tentang sebuah komentar, termasuk penulisnya, waktu pembuatan, posisi, dan teks.
* The [CommentAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/) class, yang memberikan informasi tentang seorang penulis, termasuk nama, inisial, dan komentar yang terkait.

## **Menambahkan Komentar Slide**

Contoh ini membuat dua slide dan mendaftarkan penulis komentar dengan [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor). Ia menggunakan [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment) untuk menempatkan satu komentar pada setiap slide, kemudian mengambil komentar slide pertama untuk penulis tersebut dengan [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments). Konsol menampilkan teks komentar pertama dua kali, memperlihatkan akses melalui slide maupun penulis, dan presentasi yang disimpan berisi kedua komentar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0))

    author = presentation.getCommentAuthors().addAuthor("Jawad", "MF")
    position = Point2DFloat(0.2, 0.2)
    created_time = Date()

    author.getComments().addComment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.getComments().addComment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.getSlideComments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.getText())

        author_comments = first_comment.getAuthor().getComments()
        comment_text = author_comments.get_Item(0).getText()
        print(comment_text)

    presentation.save("Comments_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Temukan atau Buat Penulis Komentar**

Ketika peninjauan otomatis memproses presentasi yang sama berulang kali, cari dalam koleksi yang dikembalikan oleh [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors) sebelum menambahkan penulis. [findByNameAndInitials](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByNameAndInitials) mencocokkan nama dan inisial serta mengembalikan array penulis yang cocok, atau array kosong jika tidak ada yang cocok. Sebaliknya, [findByName](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByName) mencari hanya berdasarkan nama, terlepas dari inisial. Memanggil [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor) dengan nama dan inisial yang sudah ada dalam koleksi akan melempar pengecualian.

Contoh ini memerlukan file presentasi dengan setidaknya satu slide. Pada masing‑masing dari dua kali proses, ia menggunakan kembali penulis pertama yang cocok, atau membuat satu hanya ketika hasilnya kosong. Jika ada beberapa kecocokan, ia memilih elemen array pertama tanpa menggabungkan atau menghapus penulis lain. Kemudian ia memanggil [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment) untuk penulis yang dipilih dan menyimpan presentasi. Proses kedua membuka keluaran proses pertama dan mengulangi operasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

author_name = "Reviewer"
author_initials = "RV"

input_file = "input.pptx"
position = Point2DFloat(20, 20)

for pass_number in range(1, 3):
    presentation = Presentation(input_file)
    try:
        matches = presentation.getCommentAuthors().findByNameAndInitials(author_name, author_initials)

        author = matches[0] if len(matches) > 0 else presentation.getCommentAuthors().addAuthor(author_name, author_initials)
        created_time = Date()
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, created_time)

        output_file = f"review_pass_{pass_number}.pptx"
        presentation.save(output_file, SaveFormat.Pptx)
        input_file = output_file
    finally:
        presentation.dispose()
```

Proses kedua menambahkan komentar lain tanpa menambahkan penulis lain atau menghapus komentar yang ada. Berkas akhir, `review_pass_2.pptx`, berisi kedua komentar baru bersama komentar asli apa pun. Menggunakan kembali penulis tidak menduplikasi komentar: untuk menghindari penambahan komentar yang sama berulang‑ulang, terapkan deteksi duplikat terpisah sebelum menambahkannya.

## **Akses Komentar Slide**

Contoh ini membuka presentasi yang ada dan membaca koleksi yang dikembalikan oleh [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors). Untuk setiap penulis, ia mengiterasi koleksi yang dikembalikan oleh [getComments](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/#getComments) dan mencetak nomor slide, teks komentar, nama penulis, dan waktu pembuatan. Presentasi masukan harus berisi komentar agar menghasilkan output konsol.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Comments1.pptx")
try:
    for author in presentation.getCommentAuthors():
        for comment in author.getComments():
            print("Slide: ", comment.getSlide().getSlideNumber())
            print("Comment: ", comment.getText())
            print("Author: ", comment.getAuthor().getName())
            print("Posted at: ", comment.getCreatedTime())
            print()
finally:
    presentation.dispose()
```

## **Balas Komentar**

Sebuah komentar induk adalah komentar asli di puncak hierarki balasan. Metode [Comment.getParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment) dan [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) memungkinkan Anda mengambil atau mengatur induk sebuah komentar.

Contoh ini membuat komentar dari dua penulis dan menggunakan [setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) untuk membangun balasan, termasuk balasan ke balasan lain. Mengirimkan `None` ke [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) mengambil komentar dari semua penulis; konsol memberikan indentasi tiap entri sesuai kedalaman dalam hierarki balasan. Contoh menyimpan diskusi lengkap, memanggil [remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove) pada komentar akar pertama, dan menyimpan presentasi kedua dengan komentar tersebut serta balasannya dihapus.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    position = Point2DFloat(10, 10)
    created_time = Date()

    thread_author = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.")
    root_comment = thread_author.getComments().addComment("comment 1", slide, position, created_time)

    responding_author = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.")
    direct_reply = responding_author.getComments().addComment("reply 1 for comment 1", slide, position, created_time)
    direct_reply.setParentComment(root_comment)

    branch_reply = responding_author.getComments().addComment("reply 2 for comment 1", slide, position, created_time)
    branch_reply.setParentComment(root_comment)

    nested_reply = thread_author.getComments().addComment("subreply 3 for reply 2", slide, position, created_time)
    nested_reply.setParentComment(branch_reply)

    responding_author.getComments().addComment("comment 2", slide, position, created_time)
    separate_thread_comment = responding_author.getComments().addComment("comment 3", slide, position, created_time)

    separate_thread_reply = thread_author.getComments().addComment("reply 4 for comment 3", slide, position, created_time)
    separate_thread_reply.setParentComment(separate_thread_comment)

    comments = slide.getSlideComments(None)
    for i in range(len(comments)):
        comment = comments[i]
        while comment.getParentComment() is not None:
            print("\t", end="")
            comment = comment.getParentComment()

        print(f"{comments[i].getAuthor().getName()}: {comments[i].getText()}")

    presentation.save("parent_comment.pptx", SaveFormat.Pptx)

    root_comment.remove()
    presentation.save("remove_comment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
* Ketika metode [Comment.remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove) digunakan untuk menghapus sebuah komentar, semua balasan terhadap komentar tersebut juga akan dihapus.
* Jika [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) membuat referensi melingkar, sebuah [PptxEditException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxeditexception/) akan dilempar.
{{% /alert %}}

## **Menambahkan Komentar Modern**

Komentar modern dapat dikaitkan dengan slide itu sendiri, dengan bentuk tertentu, atau dengan rentang teks di dalam sebuah [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/). Metode [CommentCollection.addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) menerima argumen [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) selain slide dan koordinat penanda komentar.

Ketika `None` dipassing untuk argumen shape, komentar menjadi komentar level slide. Penandanya diposisikan oleh koordinat yang diberikan, namun tidak terkait dengan bentuk tertentu, sehingga [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) mengembalikan `None`. Ketika sebuah [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) disediakan, komentar diancangkan pada bentuk tersebut. Koordinat tetap menentukan posisi penanda komentar pada slide, sementara asosiasi bentuk dapat diambil melalui [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape).

### **Menambatkan Komentar Modern ke Bentuk**

Contoh ini memanggil [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) dua kali: sekali dengan shape `None` untuk komentar level slide dan sekali dengan persegi panjang sebagai jangkar. Membaca [getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) mencetak `True` untuk pemeriksaan `None` pada komentar level slide dan `Revenue title` untuk komentar yang dijadikan jangkar. Kedua komentar disimpan bersama presentasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80)
    shape.setName("Revenue title")
    shape.getTextFrame().setText("Quarterly revenue")

    created_time = Date()
    slide_comment_position = Point2DFloat(20, 20)
    shape_comment_position = Point2DFloat(60, 60)
    slide_comment = author.getComments().addModernComment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.getComments().addModernComment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.getShape() is None)
    print(shape_comment.getShape().getName())

    presentation.save("modern_comments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Menambatkan Komentar ke Berbagai Jenis Bentuk**

Setiap objek slide yang mewarisi dari [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) dapat digunakan sebagai jangkar bentuk. Contoh umum meliputi [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/python-java/aspose.slides/connector/), dan [GraphicalObject](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobject/) seperti bagan.

Contoh ini menggunakan [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) untuk mengaitkan komentar dengan masing‑masing dari lima tipe bentuk: sebuah AutoShape, sebuah frame gambar, sebuah grup, sebuah connector, dan sebuah bagan. Gambar menggunakan data gambar tersemat, sehingga tidak memerlukan gambar eksternal. Setiap komentar memiliki posisi penanda masing‑masing, dan presentasi yang disimpan mempertahankan semua lima asosiasi bentuk.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")
Base64 = jpype.JClass("java.util.Base64")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    created_time = Date()

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60)
    auto_shape.getTextFrame().setText("AutoShape")

    auto_shape_comment_position = Point2DFloat(30, 30)
    author.getComments().addModernComment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = Base64.getDecoder().decode(image_base64)
    image = presentation.getImages().addImage(image_data)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image)
    picture_comment_position = Point2DFloat(230, 30)
    author.getComments().addModernComment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.getShapes().addGroupShape()
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40)
    group_shape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40)
    group_comment_position = Point2DFloat(40, 150)
    author.getComments().addModernComment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40)
    connector_comment_position = Point2DFloat(240, 150)
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180)
    chart_comment_position = Point2DFloat(420, 40)
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Menambatkan Komentar ke Teks dan Menetapkan Statusnya**

Untuk komentar modern yang terkait dengan sebuah [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart) dan [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart) mengakses posisi awal teks yang dipilih dalam bingkai teks bentuk. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength) dan [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength) mengakses panjang seleksi. Bersama‑sama, nilai‑nilai ini mengaitkan komentar dengan rentang teks tertentu di dalam AutoShape.

[ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) dan [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) mengakses nilai dari konstanta [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/):

- [NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#NotDefined) — tidak ada status komentar modern yang spesifik didefinisikan.
- [Active](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Active) — komentar aktif.
- [Resolved](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Resolved) — komentar telah diselesaikan.
- [Closed](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Closed) — komentar ditutup.

Contoh ini menambatkan komentar modern ke kata “quarterly revenue” dalam teks sebuah persegi panjang. Ia menghitung posisi mulai seleksi berbasis nol dari teks dan mengirimkannya ke [setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart) serta menggunakan [setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength) untuk menetapkan jumlah karakter yang dipilih. Setelah memanggil [setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) dengan `Resolved`, ia menyimpan dan membuka kembali presentasi. Empat pemeriksaan konsol masing‑masing harus mencetak `True`, mengonfirmasi bahwa jangkar bentuk, rentang teks, dan status dipertahankan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ModernComment, ModernCommentStatus, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.find(selected_text)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    shape.setName("Forecast text")
    shape.getTextFrame().setText(shape_text)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    comment_position = Point2DFloat(60, 60)
    created_time = Date()
    comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, comment_position, created_time)
    comment.setTextSelectionStart(expected_selection_start)
    comment.setTextSelectionLength(len(selected_text))
    comment.setStatus(ModernCommentStatus.Resolved)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_comments = reopened_slide.getSlideComments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, ModernComment):
            continue

        modern_comment = reopened_comment
        shape_matches = modern_comment.getShape() is not None and modern_comment.getShape().getName() == "Forecast text"
        selection_start_matches = modern_comment.getTextSelectionStart() == expected_selection_start
        selection_length_matches = modern_comment.getTextSelectionLength() == len(selected_text)
        status_matches = modern_comment.getStatus() == ModernCommentStatus.Resolved

        print("Shape anchor preserved: ", shape_matches)
        print("Text selection start preserved: ", selection_start_matches)
        print("Text selection length preserved: ", selection_length_matches)
        print("Resolved status preserved: ", status_matches)
finally:
    reopened_presentation.dispose()
```

### **Memeriksa Komentar Modern yang Ada**

Contoh ini memerlukan presentasi yang ada berisi komentar modern dan mencetak teks, status, serta detail jangkarnya. Untuk memeriksanya, periksa komentar mana yang merupakan instance dari [ModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/), kemudian periksa [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength), dan [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus). Sebuah shape `None` menunjukkan komentar level slide. Untuk jangkar [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), metode seleksi‑teks mengidentifikasi rentang terkait dalam bingkai teks bentuk.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ModernComment, Presentation

presentation = Presentation("comments.pptx")
try:
    for slide in presentation.getSlides():
        comments = slide.getSlideComments(None)
        for comment in comments:
            if not isinstance(comment, ModernComment):
                continue

            modern_comment = comment
            print("Slide: ", slide.getSlideNumber())
            print("Text: ", modern_comment.getText())
            print("Status: ", modern_comment.getStatus())

            shape = modern_comment.getShape()
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: ", shape.getName())
                print("Anchor type: ", shape.getClass().getSimpleName())

                if isinstance(shape, AutoShape):
                    print("Text selection start: ", modern_comment.getTextSelectionStart())
                    print("Text selection length: ", modern_comment.getTextSelectionLength())

            print()
finally:
    presentation.dispose()
```

## **Menghapus Komentar**

Aspose.Slides for Python via Java memungkinkan Anda menghapus semua komentar dan penulisnya dari sebuah presentasi atau menghapus komentar tertentu sambil mempertahankan yang lain. Contoh‑contoh berikut mendemonstrasikan kedua pendekatan dan menyimpan presentasi yang diperbarui.

### **Menghapus Semua Komentar dan Penulis Komentar**

Contoh ini membuka presentasi yang ada dan memanggil [CommentCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#clear) untuk setiap penulis, kemudian memanggil [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#clear) untuk menghapus penulisnya. Presentasi yang disimpan tidak berisi komentar maupun penulis komentar. Gunakan presentasi yang berisi komentar untuk melihat penghapusan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("example.pptx")
try:
    for author in presentation.getCommentAuthors():
        author.getComments().clear()

    presentation.getCommentAuthors().clear()

    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Menghapus Komentar Tertentu**

Contoh ini membuat dua komentar pada satu slide dan menggunakan [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) untuk menemukan komentar masing‑masing penulis. Ia mengumpulkan komentar yang teksnya sama dengan "comment 1" sebelum memanggil [CommentCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#remove), menghindari perubahan pada koleksi selama pemilihan. Presentasi yang disimpan hanya menyisakan "comment 2".

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    author = presentation.getCommentAuthors().addAuthor("Author", "A")
    created_time = Date()

    first_comment_position = Point2DFloat(0.2, 0.2)
    second_comment_position = Point2DFloat(0.3, 0.2)
    author.getComments().addComment("comment 1", slide, first_comment_position, created_time)
    author.getComments().addComment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.getCommentAuthors():
        comments_to_remove = []
        comments = slide.getSlideComments(comment_author)

        for comment in comments:
            if comment.getText() == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.getComments().remove(comment)

    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah Aspose.Slides mendukung status terselesaikan untuk komentar modern?**

Ya. [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) dan [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) mengakses nilai [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/), termasuk `Resolved`. Status disimpan dalam presentasi dan dapat dibaca kembali setelah file dibuka kembali.

**Apakah diskusi berulir (rantai balasan) didukung, dan apakah ada batas kedalaman nesting?**

Ya. Setiap komentar dapat merujuk ke [parent comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment)-nya, memungkinkan rantai balasan. API tidak menentukan batas kedalaman nesting tertentu.

**Dalam sistem koordinat apa posisi penanda komentar pada slide didefinisikan?**

Posisi penanda didefinisikan oleh koordinat floating‑point dalam sistem koordinat slide, memungkinkan Anda menempatkannya secara tepat pada slide.