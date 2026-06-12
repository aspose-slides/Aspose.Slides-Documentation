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
- menambahkan komentar
- mengakses komentar
- mengedit komentar
- membalas komentar
- menghapus komentar
- menghapus komentar
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Kuasai komentar presentasi dengan Aspose.Slides untuk Python melalui .NET: tambahkan, baca, edit, dan hapus komentar dalam file PowerPoint dengan cepat dan mudah."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengelola komentar presentasi dalam Aspose.Slides. Artikel ini menampilkan tipe utama yang terkait dengan komentar dan memperlihatkan cara menambahkan komentar ke slide, mengakses komentar yang ada, bekerja dengan balasan, menggunakan komentar modern, dan menghapus komentar dari sebuah presentasi.

Contoh-contoh berfokus pada skenario peninjauan dan kolaborasi umum di PowerPoint, seperti menetapkan komentar kepada penulis, membaca konten komentar dan metadata, membangun rantai balasan, serta menghapus semua komentar atau menghapus yang dipilih.

Di PowerPoint, komentar muncul sebagai catatan atau anotasi pada sebuah slide. Ketika komentar diklik, isi atau pesannya akan ditampilkan.

## **Mengapa Menambahkan Komentar ke Presentasi?**

Anda mungkin ingin menggunakan komentar untuk memberikan umpan balik atau berkomunikasi dengan rekan kerja saat meninjau presentasi.

Untuk memungkinkan Anda menggunakan komentar dalam presentasi PowerPoint, Aspose.Slides untuk Python melalui .NET menyediakan

* Kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) , yang berisi koleksi penulis (dari properti [CommentAuthorCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/commentauthorcollection/)). Penulis menambahkan komentar ke slide. 
* Kelas [CommentCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/commentcollection/) , yang berisi koleksi komentar untuk masing-masing penulis. 
* Kelas [Comment](https://reference.aspose.com/slides/id/python-net/aspose.slides/comment/) , yang berisi informasi tentang penulis dan komentar mereka: siapa yang menambahkan komentar, waktu komentar ditambahkan, posisi komentar, dll. 
* Kelas [CommentAuthor](https://reference.aspose.com/slides/id/python-net/aspose.slides/commentauthor/) , yang berisi informasi tentang masing-masing penulis: nama penulis, inisialnya, komentar yang terkait dengan nama penulis, dll. 

## **Menambahkan Komentar Slide**
Kode Python ini menunjukkan cara menambahkan komentar ke slide dalam presentasi PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# Membuat instance kelas Presentation
with slides.Presentation() as presentation:
    # Menambahkan slide kosong
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # Menambahkan penulis
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # Mengatur posisi untuk komentar
    point = draw.PointF(0.2, 0.2)

    # Menambahkan komentar slide untuk seorang penulis pada slide 1
    author.comments.add_comment("Hello Jawad, this is slide comment", presentation.slides[0], point, datetime.date.today())

    # Menambahkan komentar slide untuk seorang penulis pada slide 2
    author.comments.add_comment("Hello Jawad, this is second slide comment", presentation.slides[1], point, datetime.date.today())

    # Mengakses ISlide 1
    slide = presentation.slides[0]

    # Ketika null diberikan sebagai argumen, komentar dari semua penulis dibawa ke slide yang dipilih
    comments = slide.get_slide_comments(author)

    # Mengakses komentar pada indeks 0 untuk slide 1
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # Memilih koleksi komentar Penulis pada indeks 0
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```



## **Mengakses Komentar Slide**
Kode Python ini menunjukkan cara mengakses komentar yang ada pada slide dalam presentasi PowerPoint:

```python
import aspose.slides as slides

# Membuat instance kelas Presentation
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " has comment: " + comment.text + 
            " with Author: " + comment.author.name + 
            " posted on time :" + str(comment.created_time) + "\n")
```


## **Balas Komentar**
Komentar induk adalah komentar utama atau asli dalam hierarki komentar atau balasan. Dengan menggunakan properti `parent_comment` (dari kelas [Comment](https://reference.aspose.com/slides/id/python-net/aspose.slides/comment/)), Anda dapat mengatur atau mengambil komentar induk. 

Kode Python ini menunjukkan cara menambahkan komentar dan mendapatkan balasan untuknya:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # Menambahkan komentar
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # Menambahkan balasan ke comment1
    author2 = pres.comment_authors.add_author("Autror_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # Menambahkan balasan lain ke comment1
    reply2 = author2.comments.add_comment("reply 2 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # Menambahkan balasan ke balasan yang ada
    subReply = author1.comments.add_comment("subreply 3 for reply 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("comment 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("reply 4 for comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # Menampilkan hierarki komentar di konsol
    slide = pres.slides[0]
    comments = slide.get_slide_comments(None)
    for i in range(comments.length):
        comment = comments[i]
        while comment.parent_comment is not None:
            print("\t")
            comment = comment.parent_comment

        print(comments[i].author.name + " : " + comments[i].text)
        print("\r\n")

    pres.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    # Menghapus comment1 dan semua balasan kepadanya
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Perhatian" %}} 

* Ketika metode `remove` (dari kelas [Comment](https://reference.aspose.com/slides/id/python-net/aspose.slides/comment/)) digunakan untuk menghapus komentar, balasan ke komentar tersebut juga akan dihapus. 
* Jika pengaturan `parent_comment` menghasilkan referensi melingkar, `PptxEditException` akan dilempar.

{{% /alert %}}

## **Menambahkan Komentar Modern**

Pada tahun 2021, Microsoft memperkenalkan *komentar modern* di PowerPoint. Fitur komentar modern secara signifikan meningkatkan kolaborasi di PowerPoint. Melalui komentar modern, pengguna PowerPoint dapat menyelesaikan komentar, menempelkan komentar pada objek dan teks, serta berinteraksi jauh lebih mudah daripada sebelumnya. 

Kami mengimplementasikan dukungan untuk komentar modern dengan menambahkan kelas [ModernComment](https://reference.aspose.com/slides/id/python-net/aspose.slides/moderncomment/). Metode `add_modern_comment` dan `insert_modern_comment` ditambahkan ke kelas [CommentCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/commentcollection/). 

Kode Python ini menunjukkan cara menambahkan komentar modern ke slide dalam presentasi PowerPoint:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Some Author", "SA")
    modernComment = newAuthor.comments.add_modern_comment("This is a modern comment", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **Menghapus Komentar**

### **Menghapus Semua Komentar dan Penulis**

Kode Python ini menunjukkan cara menghapus semua komentar dan penulis dalam sebuah presentasi:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # Menghapus semua komentar dari presentasi
    for author in presentation.comment_authors:
        author.comments.clear()

    # Menghapus semua penulis
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Menghapus Komentar Tertentu**

Kode Python ini menunjukkan cara menghapus komentar tertentu pada slide:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # menambahkan komentar...
    author = presentation.comment_authors.add_author("Author", "A")
    author.comments.add_comment("comment 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("comment 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # menghapus semua komentar yang berisi teks "comment 1"
    for commentAuthor in presentation.comment_authors:
        toRemove = []
        for comment in slide.get_slide_comments(commentAuthor):
            if comment.text == "comment 1":
                toRemove.append(comment)
        
        for comment in toRemove:
            commentAuthor.comments.remove(comment)
    
    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah Aspose.Slides mendukung status seperti 'resolved' untuk komentar modern?**

Ya. [Komentar modern](https://reference.aspose.com/slides/id/python-net/aspose.slides/moderncomment/) menyediakan properti [status](https://reference.aspose.com/slides/id/python-net/aspose.slides/moderncomment/status/); Anda dapat membaca dan mengatur [status komentar](https://reference.aspose.com/slides/id/python-net/aspose.slides/moderncommentstatus/) (misalnya, menandainya sebagai selesai), dan status ini disimpan dalam file serta dikenali oleh PowerPoint.

**Apakah diskusi berulir (rantai balasan) didukung, dan apakah ada batas kedalaman?**

Ya. Setiap komentar dapat merujuk ke [komentar induk](https://reference.aspose.com/slides/id/python-net/aspose.slides/moderncomment/parent_comment/), memungkinkan rantai balasan sewenang-wenang. API tidak menetapkan batas kedalaman penumpukan tertentu.

**Dalam sistem koordinat apa posisi penanda komentar didefinisikan pada slide?**

Posisi disimpan sebagai titik floating‑point dalam sistem koordinat slide. Ini memungkinkan Anda menempatkan penanda komentar secara tepat di mana Anda membutuhkannya.