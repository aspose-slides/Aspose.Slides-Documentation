---
title: Mengelola Komentar Presentasi di PHP
linktitle: Komentar Presentasi
type: docs
weight: 100
url: /id/php-java/presentation-comments/
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
- PHP
- Aspose.Slides
description: "Kuasi komentar presentasi dengan Aspose.Slides untuk PHP via Java: tambahkan, baca, edit, dan hapus komentar dalam file PowerPoint dengan cepat dan mudah."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mengelola komentar presentasi di Aspose.Slides. Artikel ini menampilkan tipe utama yang terkait dengan komentar dan mendemonstrasikan cara menambahkan komentar ke slide, mengakses komentar yang ada, bekerja dengan balasan, menggunakan komentar modern, dan menghapus komentar dari sebuah presentasi.

Contoh-contoh fokus pada skenario peninjauan dan kolaborasi umum di PowerPoint, seperti menetapkan komentar kepada penulis, membaca konten dan metadata komentar, membangun rantai balasan, serta menghapus semua komentar atau menghapus komentar yang dipilih.

Di PowerPoint, komentar muncul sebagai catatan atau anotasi pada slide. Ketika komentar diklik, isi atau pesannya ditampilkan.

## **Mengapa Menambahkan Komentar ke Presentasi?**

Anda mungkin ingin menggunakan komentar untuk memberikan umpan balik atau berkomunikasi dengan rekan kerja saat meninjau presentasi.

Untuk memungkinkan Anda menggunakan komentar dalam presentasi PowerPoint, Aspose.Slides for PHP via Java menyediakan
* Kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) yang berisi koleksi penulis (dari kelas [CommentAuthorCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/commentauthorcollection/)). Penulis menambahkan komentar ke slide.
* Kelas [CommentCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/commentcollection/) yang berisi koleksi komentar untuk masing‑masing penulis.
* Kelas [Comment](https://reference.aspose.com/slides/id/php-java/aspose.slides/comment/) yang berisi informasi tentang penulis dan komentar mereka: siapa yang menambahkan komentar, waktu komentar ditambahkan, posisi komentar, dll.
* Kelas [CommentAuthor](https://reference.aspose.com/slides/id/php-java/aspose.slides/commentauthor/) yang berisi informasi tentang masing‑masing penulis: nama penulis, inisialnya, komentar yang terkait dengan nama penulis, dll.

## **Menambahkan Komentar Slide**
Kode PHP berikut menunjukkan cara menambahkan komentar ke slide dalam presentasi PowerPoint:

```php
  # Membuat instance kelas Presentation
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Menambahkan slide kosong
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # Menambahkan penulis
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # Menetapkan posisi untuk komentar
    $point = new Point2DFloat(0.2, 0.2);
    # Menambahkan komentar slide untuk penulis pada slide 1
    $author->getComments()->addComment("Hello Jawad, this is slide comment", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # Menambahkan komentar slide untuk penulis pada slide 2
    $author->getComments()->addComment("Hello Jawad, this is second slide comment", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # Mengakses ISlide 1
    $slide = $pres->getSlides()->get_Item(0);
    # Ketika null diberikan sebagai argumen, komentar dari semua penulis diambil ke slide yang dipilih
    $Comments = $slide->getSlideComments($author);
    # Mengakses komentar pada indeks 0 untuk slide 1
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # Memilih koleksi komentar Penulis pada indeks 0
      $commentCollection = $Comments[0]->getAuthor()->getComments();
      $Comment = $commentCollection->get_Item(0)->getText();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Mengakses Komentar Slide**
Kode PHP berikut menunjukkan cara mengakses komentar yang ada pada slide dalam presentasi PowerPoint:

```php
  # Membuat instance kelas Presentation
  $pres = new Presentation("Comments1.pptx");
  try {
    foreach($pres->getCommentAuthors() as $commentAuthor) {
      $author = $commentAuthor;
      foreach($author->getComments() as $comment1) {
        $comment = $comment1;
        echo("ISlide :" . $comment->getSlide()->getSlideNumber() . " has comment: " . $comment->getText() . " with Author: " . $comment->getAuthor()->getName() . " posted on time :" . $comment->getCreatedTime() . "\n");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Membalas Komentar**
Komentar induk adalah komentar utama atau asli dalam hirarki komentar atau balasan. Dengan menggunakan metode [getParentComment](https://reference.aspose.com/slides/id/php-java/aspose.slides/comment/getparentcomment/) atau [setParentComment](https://reference.aspose.com/slides/id/php-java/aspose.slides/comment/setparentcomment/) (dari kelas [Comment](https://reference.aspose.com/slides/id/php-java/aspose.slides/comment/)), Anda dapat menetapkan atau memperoleh komentar induk.

Kode PHP berikut menunjukkan cara menambahkan komentar dan mendapatkan balasannya:

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Menambahkan komentar
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # Menambahkan balasan ke komentar1
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # Menambahkan balasan lain ke komentar1
    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # Menambahkan balasan ke balasan yang ada
    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("comment 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # Menampilkan hierarki komentar di konsol
    $slide = $pres->getSlides()->get_Item(0);
    $comments = $slide->getSlideComments(null);
    for($i = 0; $i < java_values($Array->getLength($comments)) ; $i++) {
      $comment = $comments[$i];
      while (!java_is_null($comment->getParentComment())) {
        System->out->print("\t");
        $comment = $comment->getParentComment();
      } 
      echo($comments[$i]->getAuthor()->getName() . " : " . $comments[$i]->getText());
      echo();
    }
    $pres->save("parent_comment.pptx", SaveFormat::Pptx);
    # Menghapus komentar1 dan semua balasannya
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" title="Attention" %}} 
* Ketika metode [remove](https://reference.aspose.com/slides/id/php-java/aspose.slides/comment/remove/) (dari kelas [Comment](https://reference.aspose.com/slides/id/php-java/aspose.slides/comment/)) digunakan untuk menghapus sebuah komentar, balasan terhadap komentar tersebut juga akan dihapus.
* Jika pengaturan [setParentComment](https://reference.aspose.com/slides/id/php-java/aspose.slides/comment/setparentcomment/) menghasilkan referensi melingkar, [PptxEditException](https://reference.aspose.com/slides/id/php-java/aspose.slides/pptxeditexception/) akan dilempar.
{{% /alert %}}

## **Menambahkan Komentar Modern**

Pada tahun 2021, Microsoft memperkenalkan *komentar modern* di PowerPoint. Fitur komentar modern secara signifikan meningkatkan kolaborasi di PowerPoint. Melalui komentar modern, pengguna PowerPoint dapat menyelesaikan komentar, menambatkan komentar pada objek dan teks, serta berinteraksi jauh lebih mudah dibandingkan sebelumnya. 

Aspose Slides mendukung komentar modern melalui kelas [ModernComment](https://reference.aspose.com/slides/id/php-java/aspose.slides/moderncomment/). Metode [addModernComment](https://reference.aspose.com/slides/id/php-java/aspose.slides/commentcollection/addmoderncomment/) dan [insertModernComment](https://reference.aspose.com/slides/id/php-java/aspose.slides/commentcollection/insertmoderncomment/) ditambahkan ke kelas [CommentCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/commentcollection/).

Kode PHP berikut menunjukkan cara menambahkan komentar modern ke slide dalam presentasi PowerPoint:

```php
  $pres = new Presentation();
  try {
    $newAuthor = $pres->getCommentAuthors()->addAuthor("Some Author", "SA");
    $modernComment = $newAuthor->getComments()->addModernComment("This is a modern comment", $pres->getSlides()->get_Item(0), null, new Point2DFloat(100, 100), new Java("java.util.Date"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Menghapus Komentar**

### **Menghapus Semua Komentar dan Penulis**

Kode PHP berikut menunjukkan cara menghapus semua komentar dan penulis dalam sebuah presentasi:

```php
  $presentation = new Presentation("example.pptx");
  try {
    # Menghapus semua komentar dari presentasi
    foreach($presentation->getCommentAuthors() as $author) {
      $author->getComments()->clear();
    }
    # Menghapus semua penulis
    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **Menghapus Komentar Tertentu**

Kode PHP berikut menunjukkan cara menghapus komentar tertentu pada slide:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # menambahkan komentar...
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $author->getComments()->addComment("comment 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("comment 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # menghapus semua komentar yang berisi "comment 1" teks
    foreach($presentation->getCommentAuthors() as $commentAuthor) {
      $toRemove = new Java("java.util.ArrayList");
      foreach($slide->getSlideComments($commentAuthor) as $comment) {
        if ($comment->getText()->equals("comment 1")) {
          $toRemove->add($comment);
        }
      }
      foreach($toRemove as $comment) {
        $commentAuthor->getComments()->remove($comment);
      }
    }
    $presentation->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **FAQ**

**Apakah Aspose.Slides mendukung status seperti 'resolved' untuk komentar modern?**

Ya. [Modern comments](https://reference.aspose.com/slides/id/php-java/aspose.slides/moderncomment/) menyediakan metode [setStatus](https://reference.aspose.com/slides/id/php-java/aspose.slides/moderncomment/setstatus/); Anda dapat menulis [status komentar](https://reference.aspose.com/slides/id/php-java/aspose.slides/moderncommentstatus/) (misalnya menandainya sebagai resolved), dan status ini disimpan dalam file serta dikenali oleh PowerPoint.

**Apakah diskusi berulir (rantai balasan) didukung, dan apakah ada batas kedalaman?**

Ya. Setiap komentar dapat mereferensikan [parent comment](https://reference.aspose.com/slides/id/php-java/aspose.slides/comment/getparentcomment/), memungkinkan rantai balasan secara sewenang‑wenang. API tidak menetapkan batas kedalaman nesting tertentu.

**Dalam sistem koordinat apa posisi penanda komentar didefinisikan pada slide?**

Posisi disimpan sebagai titik floating‑point dalam sistem koordinat slide. Hal ini memungkinkan Anda menempatkan penanda komentar secara tepat di lokasi yang diinginkan.