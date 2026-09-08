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
- edit komentar
- balas komentar
- hapus komentar
- menghapus komentar
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Kelola komentar presentasi dengan Aspose.Slides for Python via Java: tambahkan, baca, edit, balas, dan hapus komentar dalam presentasi PowerPoint dengan cepat dan mudah."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mengelola komentar presentasi dengan Aspose.Slides for Python via Java. Artikel ini memperkenalkan tipe terkait komentar utama dan mendemonstrasikan cara menambahkan komentar ke slide, mengakses komentar yang ada, bekerja dengan balasan dan komentar modern, serta menghapus komentar dari sebuah presentasi.

Contoh-contoh mencakup skenario peninjauan dan kolaborasi umum di PowerPoint, seperti menetapkan komentar ke penulis, membaca teks komentar dan metadata, membangun rantai balasan, serta menghapus komentar yang dipilih atau semua komentar.

Di PowerPoint, komentar muncul sebagai anotasi pada slide. Memilih komentar menampilkan teksnya dan diskusi terkait.

## **Mengapa Menambahkan Komentar ke Presentasi?**

Anda dapat menggunakan komentar untuk memberikan umpan balik dan berkolaborasi dengan rekan kerja saat meninjau presentasi.

Aspose.Slides for Python via Java menyediakan API berikut untuk bekerja dengan komentar:

* The [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) class, yang menyediakan akses ke penulis komentar presentasi.
* The [CommentCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/commentcollection/) class, yang mewakili komentar yang terkait dengan seorang penulis individu.
* The [Comment](https://reference.aspose.com/slides/id/python-java/aspose.slides/comment/) class, yang menyediakan informasi tentang sebuah komentar, termasuk penulisnya, waktu pembuatan, posisi, dan teks.
* The [CommentAuthor](https://reference.aspose.com/slides/id/python-java/aspose.slides/commentauthor/) class, yang menyediakan informasi tentang seorang penulis, termasuk nama, inisial, dan komentar yang terkait.

## **Menambahkan Komentar Slide**

Contoh berikut menunjukkan cara menambahkan komentar ke slide dalam sebuah presentasi PowerPoint:

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

## **Mengakses Komentar Slide**

Contoh berikut menunjukkan cara mengakses komentar yang ada dalam sebuah presentasi PowerPoint:

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

## **Membalas Komentar**

Komentar induk adalah komentar asli di puncak hierarki balasan. Metode [Comment.getParentComment](https://reference.aspose.com/slides/id/python-java/aspose.slides/comment/#getParentComment) dan [Comment.setParentComment](https://reference.aspose.com/slides/id/python-java/aspose.slides/comment/#setParentComment) memungkinkan Anda mendapatkan atau mengatur induk sebuah komentar.

Contoh berikut menunjukkan cara menambahkan balasan dan memeriksa hierarki komentar yang dihasilkan:

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
* Ketika metode [Comment.remove](https://reference.aspose.com/slides/id/python-java/aspose.slides/comment/#remove) digunakan untuk menghapus sebuah komentar, semua balasan ke komentar tersebut juga dihapus.
* Jika [Comment.setParentComment](https://reference.aspose.com/slides/id/python-java/aspose.slides/comment/#setParentComment) membuat referensi melingkar, sebuah [PptxEditException](https://reference.aspose.com/slides/id/python-java/aspose.slides/pptxeditexception/) dilempar.
{{% /alert %}}

## **Menambahkan Komentar Modern**

Komentar modern dapat dikaitkan dengan slide itu sendiri, dengan shape tertentu, atau dengan rentang teks di dalam [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/). Metode [CommentCollection.addModernComment](https://reference.aspose.com/slides/id/python-java/aspose.slides/commentcollection/#addModernComment) menerima argumen [Shape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/) selain slide dan koordinat penanda komentar.

Saat `None` diberikan untuk argumen shape, komentar menjadi komentar tingkat slide. Penanda ditempatkan oleh koordinat yang diberikan, tetapi tidak terkait dengan shape tertentu, sehingga [ModernComment.getShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/moderncomment/#getShape) mengembalikan `None`. Ketika sebuah [Shape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/) disediakan, komentar diikatkan pada shape tersebut. Koordinat tetap menentukan posisi penanda komentar pada slide, sementara asosiasi shape dapat diambil melalui [ModernComment.getShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/moderncomment/#getShape).

### **Menambatkan Komentar Modern ke Shape**

Contoh berikut membuat komentar modern tingkat slide serta komentar modern yang diikatkan pada sebuah [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/) tertentu. Kemudian membaca shape yang terkait dari masing-masing komentar.

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

### **Menambatkan Komentar ke Berbagai Jenis Shape**

Setiap objek slide yang mewarisi dari [Shape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/) dapat digunakan sebagai anchor shape. Contoh umum meliputi [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/id/python-java/aspose.slides/connector/), dan instance [GraphicalObject](https://reference.aspose.com/slides/id/python-java/aspose.slides/graphicalobject/) seperti diagram.

Contoh berikut membuat beberapa tipe shape umum dan mengaitkan komentar modern dengan masing‑masing.

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

### **Menambatkan Komentar ke Teks dan Mengatur Statusnya**

Untuk komentar modern yang terkait dengan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/), metode [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/id/python-java/aspose.slides/moderncomment/#getTextSelectionStart) dan [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/id/python-java/aspose.slides/moderncomment/#setTextSelectionStart) mengakses posisi awal teks yang dipilih dalam frame teks shape. Metode [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/id/python-java/aspose.slides/moderncomment/#getTextSelectionLength) dan [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/id/python-java/aspose.slides/moderncomment/#setTextSelectionLength) mengakses panjang seleksi. Bersama‑sama, nilai‑nilai ini mengaitkan komentar dengan rentang teks tertentu di dalam AutoShape.

Metode [ModernComment.getStatus](https://reference.aspose.com/slides/id/python-java/aspose.slides/moderncomment/#getStatus) dan [ModernComment.setStatus](https://reference.aspose.com/slides/id/python-java/aspose.slides/moderncomment/#setStatus) mengakses nilai dari konstanta [ModernCommentStatus](https://reference.aspose.com/slides/id/python-java/aspose.slides/moderncommentstatus/):

- [NotDefined](https://reference.aspose.com/slides/id/python-java/aspose.slides/moderncommentstatus/#NotDefined) — tidak ada status komentar modern tertentu yang didefinisikan.
- [Active](https://reference.aspose.com/slides/id/python-java/aspose.slides/moderncommentstatus/#Active) — komentar aktif.
- [Resolved](https://reference.aspose.com/slides/id/python-java/aspose.slides/moderncommentstatus/#Resolved) — komentar telah diselesaikan.
- [Closed](https://reference.aspose.com/slides/id/python-java/aspose.slides/moderncommentstatus/#Closed) — komentar ditutup.

Contoh berikut membuat komentar modern yang diikatkan pada shape, mengaitkannya dengan seleksi teks, menandainya sebagai resolved, menyimpan presentasi, dan memverifikasi nilai‑nilai tersebut setelah membuka kembali file.

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

Untuk memeriksa presentasi yang ada, periksa komentar mana yang merupakan instance dari [ModernComment](https://reference.aspose.com/slides/id/python-java/aspose.slides/moderncomment/), kemudian periksa [ModernComment.getShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/moderncomment/#getShape), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/id/python-java/aspose.slides/moderncomment/#getTextSelectionStart), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/id/python-java/aspose.slides/moderncomment/#getTextSelectionLength), dan [ModernComment.getStatus](https://reference.aspose.com/slides/id/python-java/aspose.slides/moderncomment/#getStatus). Shape `None` menunjukkan komentar tingkat slide. Untuk anchor [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/), metode seleksi teks mengidentifikasi rentang yang terkait dalam frame teks shape.

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

### **Menghapus Semua Komentar dan Penulis Komentar**

Contoh berikut menunjukkan cara menghapus semua komentar dan penulis komentar dari sebuah presentasi:

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

Contoh berikut menunjukkan cara menghapus komentar tertentu dari sebuah slide:

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

**Apakah Aspose.Slides mendukung status resolved untuk komentar modern?**

Ya. [ModernComment.getStatus](https://reference.aspose.com/slides/id/python-java/aspose.slides/moderncomment/#getStatus) dan [ModernComment.setStatus](https://reference.aspose.com/slides/id/python-java/aspose.slides/moderncomment/#setStatus) mengakses nilai [ModernCommentStatus](https://reference.aspose.com/slides/id/python-java/aspose.slides/moderncommentstatus/), termasuk `Resolved`. Status disimpan dalam presentasi dan dapat dibaca kembali setelah file dibuka kembali.

**Apakah diskusi berutas (rantai balasan) didukung, dan ada batas kedalaman nesting?**

Ya. Setiap komentar dapat merujuk ke [parent comment](https://reference.aspose.com/slides/id/python-java/aspose.slides/comment/#getParentComment)-nya, memungkinkan rantai balasan. API tidak mendefinisikan batas kedalaman nesting tertentu.

**Dalam sistem koordinat apa posisi penanda komentar didefinisikan pada slide?**

Posisi penanda didefinisikan oleh koordinat floating‑point dalam sistem koordinat slide, memungkinkan Anda menempatkannya secara tepat pada slide.