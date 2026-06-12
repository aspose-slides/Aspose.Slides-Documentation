---
title: Kelola Komentar Presentasi dalam JavaScript
linktitle: Komentar Presentasi
type: docs
weight: 100
url: /id/nodejs-java/presentation-comments/
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
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kuasai komentar presentasi dengan Aspose.Slides untuk Node.js: tambahkan, baca, edit, dan hapus komentar dalam file PowerPoint menggunakan JavaScript dengan cepat dan mudah."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mengelola komentar presentasi di Aspose.Slides. Artikel ini menampilkan tipe utama yang terkait dengan komentar dan memperlihatkan cara menambahkan komentar ke slide, mengakses komentar yang sudah ada, bekerja dengan balasan, menggunakan komentar modern, serta menghapus komentar dari sebuah presentasi.

Contoh-contoh berfokus pada skenario peninjauan dan kolaborasi umum di PowerPoint, seperti menetapkan komentar kepada penulis, membaca isi komentar dan metadata, membangun rantai balasan, serta menghapus semua komentar atau menghapus komentar yang dipilih.

Di PowerPoint, komentar muncul sebagai catatan atau anotasi pada slide. Ketika komentar diklik, isinya atau pesannya ditampilkan.

## **Mengapa Menambahkan Komentar ke Presentasi?**

Anda mungkin ingin menggunakan komentar untuk memberikan masukan atau berkomunikasi dengan rekan kerja saat meninjau presentasi.

Untuk memungkinkan Anda menggunakan komentar dalam presentasi PowerPoint, Aspose.Slides untuk Node.js via Java menyediakan

* Kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) yang berisi koleksi penulis (dari kelas [CommentAuthorCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/CommentAuthorCollection)). Penulis menambahkan komentar ke slide.
* Kelas [CommentCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/CommentCollection) yang berisi koleksi komentar untuk masing‑masing penulis.
* Kelas [Comment](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Comment) yang berisi informasi tentang penulis dan komentar mereka: siapa yang menambahkan komentar, waktu komentar ditambahkan, posisi komentar, dll.
* Kelas [CommentAuthor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/CommentAuthor) yang berisi informasi tentang masing‑masing penulis: nama penulis, inisialnya, komentar yang terkait dengan nama penulis, dll.

## **Menambahkan Komentar Slide**
Kode JavaScript ini menunjukkan cara menambahkan komentar ke slide dalam presentasi PowerPoint:

```javascript
    // Menginisialisasi kelas Presentation
    var pres = new aspose.slides.Presentation();
    try {
        // Menambahkan slide kosong
        pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
        // Menambahkan penulis
        var author = pres.getCommentAuthors().addAuthor("Jawad", "MF");
        // Menetapkan posisi untuk komentar
        var point = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
        // Menambahkan komentar slide untuk penulis pada slide 1
        author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, java.newInstanceSync("java.util.Date"));
        // Menambahkan komentar slide untuk penulis pada slide 2
        author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, java.newInstanceSync("java.util.Date"));
        // Mengakses ISlide 1
        var slide = pres.getSlides().get_Item(0);
        // Ketika null diberikan sebagai argumen, komentar dari semua penulis dibawa ke slide yang dipilih
        var Comments = slide.getSlideComments(author);
        // Mengakses komentar pada indeks 0 untuk slide 1
        var str = Comments[0].getText();
        pres.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
        if (Comments.length > 0) {
            // Memilih koleksi komentar Penulis pada indeks 0
            var commentCollection = Comments[0].getAuthor().getComments();
            var Comment = commentCollection.get_Item(0).getText();
        }
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Mengakses Komentar Slide**
Kode JavaScript ini menunjukkan cara mengakses komentar yang sudah ada pada slide dalam presentasi PowerPoint:

```javascript
var pres = new aspose.slides.Presentation("Comments1.pptx");
try {
    for (let i = 0; i < pres.getCommentAuthors().size(); i++) {
        let commentAuthor = pres.getCommentAuthors().get_Item(i);
        for (let j = 0; j < commentAuthor.getComments().size(); j++) {
            const comment = commentAuthor.getComments().get_Item(j);
            console.log("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() + " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Balas Komentar**
Komentar induk adalah komentar teratas atau asli dalam hierarki komentar atau balasan. Menggunakan metode [getParentComment](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Comment#getParentComment--) atau [setParentComment](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) (dari kelas [Comment](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Comment)), Anda dapat mengatur atau mengambil komentar induk.

Kode JavaScript ini menunjukkan cara menambahkan komentar dan mengambil balasan untuknya:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Menambahkan komentar
    var author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    var comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    // Menambahkan balasan ke comment1
    var author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    var reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply1.setParentComment(comment1);
    // Menambahkan balasan lain ke comment1
    var reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply2.setParentComment(comment1);
    // Menambahkan balasan ke balasan yang ada
    var subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    subReply.setParentComment(reply2);
    var comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply3.setParentComment(comment3);
    // Menampilkan hierarki komentar pada konsol
    var slide = pres.getSlides().get_Item(0);
    var comments = slide.getSlideComments(null);
    for (var i = 0; i < comments.length; i++) {
        var comment = comments[i];
        while (comment.getParentComment() != null) {
            console.log("\t");
            comment = comment.getParentComment();
        }
        console.log((comments[i].getAuthor().getName() + " : ") + comments[i].getText());
        console.log();
    }
    pres.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);
    // Menghapus comment1 dan semua balasannya
    comment1.remove();
    pres.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" title="Attention" %}} 

* Ketika metode [Remove](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Comment#remove--) (dari kelas [Comment](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Comment)) digunakan untuk menghapus sebuah komentar, balasan terhadap komentar tersebut juga akan dihapus.
* Jika pengaturan [setParentComment](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) menghasilkan referensi melingkar, [PptxEditException](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/PptxEditException) akan dilemparkan.

{{% /alert %}}

## **Menambahkan Komentar Modern**

Pada tahun 2021, Microsoft memperkenalkan *komentar modern* di PowerPoint. Fitur komentar modern secara signifikan meningkatkan kolaborasi di PowerPoint. Melalui komentar modern, pengguna PowerPoint dapat menyelesaikan komentar, menambatkan komentar pada objek dan teks, serta berinteraksi jauh lebih mudah dibandingkan sebelumnya. 

Aspose.Slides mendukung komentar modern melalui kelas [ModernComment](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ModernComment). Metode [addModernComment](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) dan [insertModernComment](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) ditambahkan ke kelas [CommentCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/CommentCollection).

Kode JavaScript ini menunjukkan cara menambahkan komentar modern ke slide dalam presentasi PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    var modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(100), java.newFloat(100)), java.newInstanceSync("java.util.Date"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Menghapus Komentar**

### **Menghapus Semua Komentar dan Penulis**

Kode JavaScript ini menunjukkan cara menghapus semua komentar dan penulis dalam sebuah presentasi:

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // Menghapus semua komentar dari presentasi
    for (let i = 0; i < presentation.getCommentAuthors().size(); i++) {
    var author = presentation.getCommentAuthors().get_Item(i)
        author.getComments().clear();
    }
    // Menghapus semua penulis
    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **Menghapus Komentar Tertentu**

Kode JavaScript ini menunjukkan cara menghapus komentar tertentu pada slide:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // menambahkan komentar...
    var author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.2), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    author.getComments().addComment("comment 2", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.3), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    // hapus semua komentar yang berisi teks "comment 1" text
    
    
    for (var i = 0; i < presentation.getCommentAuthors().length; i++) {
        var commentAuthor = presentation.getCommentAuthors().get_Item(i);
        var toRemove = java.newInstanceSync("java.util.ArrayList");
        for (let j = 0; j < slide.getSlideComments(commentAuthor).size(); j++) {
            let comment = slide.getSlideComments(commentAuthor).get_Item(j);
            if (comment.getText() === "comment 1") {
                toRemove.add(comment);
            }
        }
        for (var i = 0; i < toRemove.length; i++) {
            var comment = toRemove.get_Item(i);
            commentAuthor.getComments().remove(comment);
        }
    }
    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**Apakah Aspose.Slides mendukung status seperti 'resolved' untuk komentar modern?**

Ya. [Komentar modern](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/moderncomment/) menyediakan metode [getStatus](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/moderncomment/getstatus/) dan [setStatus](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/moderncomment/setStatus/); Anda dapat membaca dan mengatur [status komentar](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/moderncommentstatus/) (misalnya menandainya sebagai selesai), dan status ini disimpan dalam file serta dikenali oleh PowerPoint.

**Apakah diskusi berulir (rantai balasan) didukung, dan apakah ada batas kedalaman penumpukan?**

Ya. Setiap komentar dapat merujuk ke [parent comment](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/comment/getparentcomment/)-nya, memungkinkan rantai balasan tak terbatas. API tidak menetapkan batas kedalaman penumpukan tertentu.

**Dalam sistem koordinat apa posisi penanda komentar didefinisikan pada slide?**

Posisi disimpan sebagai titik floating‑point dalam sistem koordinat slide. Ini memungkinkan Anda menempatkan penanda komentar tepat pada lokasi yang diinginkan.