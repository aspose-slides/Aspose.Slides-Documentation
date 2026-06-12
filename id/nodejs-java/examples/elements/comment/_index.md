---
title: Komentar
type: docs
weight: 230
url: /id/nodejs-java/examples/elements/comment/
keywords:
- contoh kode
- komentar
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Bekerja dengan komentar slide di Aspose.Slides untuk Node.js: menambahkan, membalas, mengedit, menyelesaikan, dan mengekspor komentar dalam presentasi PPT, PPTX, dan ODP dengan contoh kode."
---
Artikel ini menunjukkan cara menambahkan, membaca, menghapus, dan membalas komentar modern menggunakan **Aspose.Slides for Node.js via Java**.

## **Menambahkan Komentar Modern**

Buat komentar yang ditulis oleh pengguna dan simpan presentasi.

```js
function addModernComment() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let author = presentation.getCommentAuthors().addAuthor("Jhon Smith", "JS");
        let position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(100), java.newFloat(100));
        let date = java.newInstanceSync("java.util.Date");

        author.getComments().addModernComment("This is a modern comment", slide, null, position, date);

        presentation.save("modern_comment.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Mengakses Komentar Modern**

Baca komentar modern dari presentasi yang ada.

```js
function accessModernComment() {
    let presentation = new aspose.slides.Presentation("modern_comment.pptx");
    try {
        let author = presentation.getCommentAuthors().get_Item(0);
        let comment = author.getComments().get_Item(0);
        
        console.log("Author: " + author.getName() + ", Comment: " + comment.getText());
    } finally {
        presentation.dispose();
    }
}
```

## **Menghapus Komentar Modern**

Hapus komentar dan simpan file yang diperbarui.

```js
function removeModernComment() {
    let presentation = new aspose.slides.Presentation("modern_comment.pptx");
    try {
        let author = presentation.getCommentAuthors().get_Item(0);

        let comment = author.getComments().get_Item(0);
        comment.remove();

        presentation.save("modern_comment_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Membalas Komentar Modern**

Tambahkan balasan ke komentar modern induk.

```js
function replyToModernComment() {
    let presentation = new aspose.slides.Presentation("modern_comment.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let author = presentation.getCommentAuthors().get_Item(0);
        let comment = author.getComments().get_Item(0);

        let position1 = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(110), java.newFloat(100));
        let date1 = java.newInstanceSync("java.util.Date");
        let reply1 = author.getComments().addModernComment("Reply 1", slide, null, position1, date1);

        let position2 = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(120), java.newFloat(100));
        let date2 = java.newInstanceSync("java.util.Date");
        let reply2 = author.getComments().addModernComment("Reply 2", slide, null, position2, date2);

        reply1.setParentComment(comment);
        reply2.setParentComment(comment);

        presentation.save("modern_comment_replies.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```