---
title: Komentar
type: docs
weight: 230
url: /id/php-java/examples/elements/comment/
keywords:
- komentar
- komentar modern
- tambahkan komentar
- akses komentar
- hapus komentar
- balas komentar
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Kelola komentar slide di PHP dengan Aspose.Slides: tambahkan, baca, balas, edit, hapus, dan kerja dengan komentar berulir untuk PowerPoint dan OpenDocument."
---
Menunjukkan cara menambah, membaca, menghapus, dan membalas komentar modern menggunakan **Aspose.Slides for PHP via Java**.

## **Tambah Komentar Modern**

Buat komentar yang ditulis oleh pengguna dan simpan presentasi.

```php
function addModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Tambahkan komentar modern.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");
        $author->getComments()->addModernComment("This is a modern comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));

        $presentation->save("modern_comment.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Akses Komentar Modern**

Baca komentar modern dari presentasi yang ada.

```php
function accessModernComment() {
    $presentation = new Presentation("modern_comment.pptx");
    try {
        $author = $presentation->getCommentAuthors()->get_Item(0);
        $comment = $author->getComments()->get_Item(0);
        echo "Author: " . $author->getName() . ", Comment: " . $comment->getText() . PHP_EOL;
    } finally {
        $presentation->dispose();
    }
}
```

## **Hapus Komentar Modern**

Hapus komentar dan simpan berkas yang diperbarui.

```php
function removeModernComment() {
    $presentation = new Presentation("modern_comment.pptx");
    try {
        $author = $presentation->getCommentAuthors()->get_Item(0);
        $comment = $author->getComments()->get_Item(0);

        $comment->remove();

        $presentation->save("modern_comment_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Balas Komentar Modern**

Tambahkan balasan ke komentar modern induk.

```php
function replyToModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Tambahkan penulis komentar.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");

        // Tambahkan komentar induk dan balasannya.
        $parent = $author->getComments()->addModernComment("Parent comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));
        $reply1 = $author->getComments()->addModernComment("Reply 1", $slide, null, new Point2DFloat(110, 100), new Java("java.util.Date"));
        $reply2 = $author->getComments()->addModernComment("Reply 2", $slide, null, new Point2DFloat(120, 100), new Java("java.util.Date"));

        // Atur komentar induk untuk balasan.
        $reply1->setParentComment($parent);
        $reply2->setParentComment($parent);

        // Simpan presentasi dengan balasan.
        $presentation->save("modern_comment_replies.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```