---
title: Kelola Komentar Presentasi di Java
linktitle: Komentar Presentasi
type: docs
weight: 100
url: /id/java/presentation-comments/
keywords:
- komentar
- komentar modern
- komentar PowerPoint
- komentar presentasi
- komentar slide
- tambah komentar
- akses komentar
- sunting komentar
- balas komentar
- hapus komentar
- menghapus komentar
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Kuasai komentar presentasi dengan Aspose.Slides untuk Java: tambahkan, baca, edit, dan hapus komentar dalam file PowerPoint dengan cepat dan mudah."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengelola komentar presentasi di Aspose.Slides. Artikel ini menampilkan jenis-jenis utama yang terkait dengan komentar dan menunjukkan cara menambahkan komentar ke slide, mengakses komentar yang ada, bekerja dengan balasan, menggunakan komentar modern, dan menghapus komentar dari sebuah presentasi.

Contoh-contoh berfokus pada skenario peninjauan dan kolaborasi umum di PowerPoint, seperti menetapkan komentar kepada penulis, membaca isi dan metadata komentar, membangun rantai balasan, serta menghapus semua komentar atau menghapus komentar yang dipilih.

Di PowerPoint, komentar muncul sebagai catatan atau anotasi pada slide. Ketika komentar diklik, isinya atau pesannya akan ditampilkan.

## **Mengapa Menambahkan Komentar ke Presentasi?**

Bisa jadi Anda ingin menggunakan komentar untuk memberikan umpan balik atau berkomunikasi dengan rekan kerja saat meninjau presentasi.

Untuk memungkinkan Anda menggunakan komentar dalam presentasi PowerPoint, Aspose.Slides for Java menyediakan

* Kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) yang berisi koleksi penulis (dari antarmuka [ICommentAuthorCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/ICommentAuthorCollection) ). Penulis menambahkan komentar ke slide. 
* Antarmuka [ICommentCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/ICommentCollection) yang berisi koleksi komentar untuk setiap penulis. 
* Kelas [IComment](https://reference.aspose.com/slides/id/java/com.aspose.slides/IComment) yang berisi informasi tentang penulis dan komentar mereka: siapa yang menambahkan komentar, waktu komentar ditambahkan, posisi komentar, dll. 
* Kelas [CommentAuthor](https://reference.aspose.com/slides/id/java/com.aspose.slides/CommentAuthor) yang berisi informasi tentang masing-masing penulis: nama penulis, inisialnya, komentar yang terkait dengan nama penulis, dll. 

## **Menambahkan Komentar Slide**
Kode Java berikut menunjukkan cara menambahkan komentar ke slide dalam presentasi PowerPoint:

```java
// Menginstansiasi kelas Presentation
Presentation pres = new Presentation();
try {
    // Menambahkan slide kosong
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // Menambahkan penulis
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // Mengatur posisi untuk komentar
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // Menambahkan komentar slide untuk penulis pada slide 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // Menambahkan komentar slide untuk penulis pada slide 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // Mengakses ISlide 1
    ISlide slide = pres.getSlides().get_Item(0);

    // Ketika null diberikan sebagai argumen, komentar dari semua penulis dibawa ke slide yang dipilih
    IComment[] Comments = slide.getSlideComments(author);

    // Mengakses komentar pada indeks 0 untuk slide 1
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // Memilih koleksi komentar Penulis pada indeks 0
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Mengakses Komentar Slide**
Kode Java berikut menunjukkan cara mengakses komentar yang ada pada slide dalam presentasi PowerPoint:

```java
// Membuat instance kelas Presentation
Presentation pres = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor commentAuthor : pres.getCommentAuthors())
    {
        CommentAuthor author = (CommentAuthor) commentAuthor;
        for (IComment comment1 : author.getComments())
        {
            Comment comment = (Comment) comment1;
            System.out.println("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() +
                    " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Membalas Komentar**
Komentar induk adalah komentar utama atau asli dalam hierarki komentar atau balasan. Dengan menggunakan metode [getParentComment](https://reference.aspose.com/slides/id/java/com.aspose.slides/IComment#getParentComment--) atau [setParentComment](https://reference.aspose.com/slides/id/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (dari antarmuka [IComment](https://reference.aspose.com/slides/id/java/com.aspose.slides/IComment)), Anda dapat mengatur atau mengambil komentar induk. 

Kode Java berikut menunjukkan cara menambahkan komentar dan mendapatkan balasannya:

```java
Presentation pres = new Presentation();
try {
    // Menambahkan komentar
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // Menambahkan balasan untuk comment1
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // Menambahkan balasan lain untuk comment1
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // Menambahkan balasan ke balasan yang sudah ada
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // Menampilkan hierarki komentar di konsol
    ISlide slide = pres.getSlides().get_Item(0);
    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++)
    {
        IComment comment = comments[i];
        while (comment.getParentComment() != null)
        {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() +  " : " + comments[i].getText());
        System.out.println();
    }
    pres.save("parent_comment.pptx",SaveFormat.Pptx);

    // Menghapus comment1 dan semua balasannya
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" title="Attention" %}} 
* Ketika metode [Remove](https://reference.aspose.com/slides/id/java/com.aspose.slides/IComment#remove--) (dari antarmuka [IComment](https://reference.aspose.com/slides/id/java/com.aspose.slides/IComment)) digunakan untuk menghapus komentar, balasan terhadap komentar tersebut juga akan dihapus. 
* Jika pengaturan [setParentComment](https://reference.aspose.com/slides/id/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) menghasilkan referensi melingkar, [PptxEditException](https://reference.aspose.com/slides/id/java/com.aspose.slides/PptxEditException) akan dilempar.
{{% /alert %}}

## **Menambahkan Komentar Modern**

Pada tahun 2021, Microsoft memperkenalkan *komentar modern* di PowerPoint. Fitur komentar modern secara signifikan meningkatkan kolaborasi di PowerPoint. Melalui komentar modern, pengguna PowerPoint dapat menyelesaikan komentar, menambatkan komentar pada objek dan teks, serta berinteraksi jauh lebih mudah daripada sebelumnya. 

Pada [Aspose Slides for Java 21.11](https://docs.aspose.com/slides/id/java/aspose-slides-for-java-21-11-release-notes/), kami menambahkan dukungan untuk komentar modern dengan menambahkan kelas [ModernComment](https://reference.aspose.com/slides/id/java/com.aspose.slides/ModernComment). Metode [addModernComment](https://reference.aspose.com/slides/id/java/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) dan [insertModernComment](https://reference.aspose.com/slides/id/java/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) ditambahkan ke kelas [CommentCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/CommentCollection). 

Kode Java berikut menunjukkan cara menambahkan komentar modern ke slide dalam presentasi PowerPoint: 

```java
Presentation pres = new Presentation();
try {
    ICommentAuthor newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    IModernComment modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, new Point2D.Float(100, 100), new Date());

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Menghapus Komentar**

### **Menghapus Semua Komentar dan Penulis**
Kode Java berikut menunjukkan cara menghapus semua komentar dan penulis dalam sebuah presentasi:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    // Menghapus semua komentar dari presentasi
    for (ICommentAuthor author : presentation.getCommentAuthors())
    {
        author.getComments().clear();
    }

    // Menghapus semua penulis
    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Menghapus Komentar Tertentu**
Kode Java berikut menunjukkan cara menghapus komentar tertentu pada slide:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // menambahkan komentar...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // menghapus semua komentar yang berisi teks "comment 1"
    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors())
    {
        ArrayList<IComment> toRemove = new ArrayList<IComment>();
        for (IComment comment : slide.getSlideComments(commentAuthor))
        {
            if (comment.getText().equals("comment 1"))
            {
                toRemove.add(comment);
            }
        }

        for (IComment comment : toRemove)
        {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Apakah Aspose.Slides mendukung status seperti 'resolved' untuk komentar modern?**

Ya. [Modern comments](https://reference.aspose.com/slides/id/java/com.aspose.slides/moderncomment/) menyediakan metode [setStatus](https://reference.aspose.com/slides/id/java/com.aspose.slides/moderncomment/#setStatus-byte-); Anda dapat menulis [status komentar](https://reference.aspose.com/slides/id/java/com.aspose.slides/moderncommentstatus/) (misalnya menandainya sebagai resolved), dan status ini disimpan dalam file serta dikenali oleh PowerPoint.

**Apakah diskusi berutas (rantai balasan) didukung, dan apakah ada batas kedalaman?**

Ya. Setiap komentar dapat merujuk ke [parent comment](https://reference.aspose.com/slides/id/java/com.aspose.slides/comment/#getParentComment--), memungkinkan rantai balasan secara arbitrer. API tidak menyatakan batas kedalaman nesting tertentu.

**Dalam sistem koordinat apa posisi penanda komentar didefinisikan pada slide?**

Posisi disimpan sebagai titik floating-point dalam sistem koordinat slide. Ini memungkinkan Anda menempatkan penanda komentar dengan tepat di lokasi yang diinginkan.