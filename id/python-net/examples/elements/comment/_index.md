---
title: Komentar
type: docs
weight: 230
url: /id/python-net/examples/elements/comment/
keywords:
- komentar
- komentar modern
- menambahkan komentar
- mengakses komentar
- menghapus komentar
- membalas komentar
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Kelola komentar slide di Python dengan Aspose.Slides: menambahkan, membaca, membalas, mengedit, menghapus, dan bekerja dengan komentar berulir untuk PowerPoint dan OpenDocument."
---
Menunjukkan cara menambahkan, membaca, menghapus, dan membalas komentar modern menggunakan **Aspose.Slides for Python via .NET**.

## **Tambah Komentar Modern**

Buat komentar yang ditulis oleh pengguna dan simpan presentasi.

```py
def add_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Tambahkan penulis komentar.
        author = presentation.comment_authors.add_author("User", "U1")

        # Tambahkan komentar modern.
        author.comments.add_modern_comment(
            "This is a modern comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        presentation.save("modern_comment.pptx", slides.export.SaveFormat.PPTX)
```

## **Akses Komentar Modern**

Baca komentar modern dari presentasi yang ada.

```py
def access_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]

        # Akses komentar modern pertama.
        comment = author.comments[0]

        print(f"Author: {author.name}, Comment: {comment.text}")
```

## **Hapus Komentar Modern**

Hapus komentar dan simpan file yang diperbarui.

```py
def remove_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]
        comment = author.comments[0]

        # Hapus komentar.
        comment.remove()

        presentation.save("modern_comment_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Balas Komentar Modern**

Tambahkan balasan ke komentar modern induk.

```py
def reply_to_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        author = presentation.comment_authors.add_author("User", "U1")

        # Tambahkan komentar induk.
        parent = author.comments.add_modern_comment(
            "Parent comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        # Tambahkan balasan pertama.
        reply1 = author.comments.add_modern_comment(
            "Reply 1", slide, None, drawing.PointF(110, 100), datetime.date.today())

        # Tambahkan balasan kedua.
        reply2 = author.comments.add_modern_comment(
            "Reply 2", slide, None, drawing.PointF(120, 100), datetime.date.today())

        reply1.parent_comment = parent
        reply2.parent_comment = parent

        presentation.save("modern_comment_replies.pptx", slides.export.SaveFormat.PPTX)
```