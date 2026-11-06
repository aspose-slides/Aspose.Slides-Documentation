---
title: Kelola Komentar Presentasi di Node.js
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
- tambahkan komentar
- akses komentar
- edit komentar
- balas komentar
- hapus komentar
- menghapus komentar
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kelola komentar presentasi dengan Aspose.Slides untuk Node.js via Java: tambahkan, baca, edit, balas, dan hapus komentar dalam presentasi PowerPowerPoint."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengelola komentar presentasi dengan Aspose.Slides untuk Node.js via Java. Ini memperkenalkan tipe utama yang terkait dengan komentar dan mendemonstrasikan cara menambahkan komentar ke slide, mengakses komentar yang ada, bekerja dengan balasan dan komentar modern, serta menghapus komentar dari sebuah presentasi.

Contoh-contoh mencakup skenario peninjauan dan kolaborasi umum di PowerPoint, seperti menetapkan komentar kepada penulis, membaca teks komentar dan metadata, membangun rantai balasan, dan menghapus komentar yang dipilih atau semua komentar.

Di PowerPoint, komentar muncul sebagai anotasi pada slide. Memilih sebuah komentar menampilkan teksnya dan diskusi terkait.

Untuk meminta agar komentar ditampilkan atau disembunyikan saat presentasi dibuka tanpa mengubah komentar itu sendiri, lihat [Tampilkan atau Sembunyikan Komentar Saat Membuka Presentasi](/slides/id/nodejs-java/presentation-view-properties/).

## **Mengapa Menambahkan Komentar ke Presentasi?**

Anda dapat menggunakan komentar untuk memberikan masukan dan berkolaborasi dengan rekan saat meninjau presentasi.

Aspose.Slides untuk Node.js via Java menyediakan API berikut untuk bekerja dengan komentar:

* Kelas [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) yang menyediakan akses ke penulis komentar presentasi.
* Kelas [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/) yang mewakili komentar yang terkait dengan seorang penulis tertentu.
* Kelas [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/) yang menyediakan informasi tentang sebuah komentar, termasuk penulis, waktu pembuatan, posisi, dan teksnya.
* Kelas [CommentAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/) yang menyediakan informasi tentang seorang penulis, termasuk nama, inisial, dan komentar yang terkait.

## **Menambahkan Komentar Slide**

Contoh ini membuat dua slide dan mendaftarkan penulis komentar dengan [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/). Ia menggunakan [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) untuk menempatkan satu komentar pada setiap slide, kemudian mengambil komentar slide pertama untuk penulis tersebut dengan [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/). Konsol menampilkan teks komentar pertama dua kali, menunjukkan akses melalui slide dan penulis, dan presentasi yang disimpan berisi kedua komentar.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));

    const author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const createdTime = java.newInstanceSync("java.util.Date");

    author.getComments().addComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
    author.getComments().addComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

    const comments = firstSlide.getSlideComments(author);
    if (comments.length > 0) {
        const firstComment = comments[0];
        console.log(firstComment.getText());

        const commentText = firstComment.getAuthor().getComments().get_Item(0).getText();
        console.log(commentText);
    }

    presentation.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Menemukan atau Membuat Penulis Komentar**

Ketika peninjauan otomatis memproses presentasi yang sama berulang kali, cari dalam koleksi yang dikembalikan oleh [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/) sebelum menambahkan penulis. [findByNameAndInitials](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbynameandinitials/) mencocokkan baik nama maupun inisial dan mengembalikan array penulis yang cocok, atau array kosong jika tidak ada yang cocok. Sebaliknya, [findByName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbyname/) mencari hanya berdasarkan nama, tanpa mempedulikan inisial. Memanggil [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/) dengan nama dan inisial yang sudah ada dalam koleksi akan melemparkan pengecualian.

Contoh ini memerlukan file presentasi dengan setidaknya satu slide. Pada setiap dari dua putaran, ia menggunakan kembali penulis pertama yang cocok, atau membuat satu hanya ketika hasilnya kosong. Jika ada beberapa kecocokan, ia memilih elemen array pertama tanpa menggabungkan atau menghapus penulis lainnya. Kemudian ia memanggil [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) untuk penulis yang dipilih dan menyimpan presentasi. Putaran kedua membuka output putaran pertama dan mengulangi operasi tersebut.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const authorName = "Reviewer";
const authorInitials = "RV";

let inputFile = "input.pptx";
const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(20), java.newFloat(20));

for (let pass = 1; pass <= 2; pass++) {
    const presentation = new aspose.slides.Presentation(inputFile);
    try {
        const matches = presentation.getCommentAuthors().findByNameAndInitials(authorName, authorInitials);

        const author = matches.length > 0 ? matches[0] : presentation.getCommentAuthors().addAuthor(authorName, authorInitials);
        const createdTime = java.newInstanceSync("java.util.Date");
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, createdTime);

        const outputFile = "review_pass_" + pass + ".pptx";
        presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
        inputFile = outputFile;
    } finally {
        presentation.dispose();
    }
}
```

Putaran kedua menambahkan komentar lain tanpa menambahkan penulis lain atau menghapus komentar yang ada. File akhir, `review_pass_2.pptx`, berisi kedua komentar baru bersamaan dengan komentar asli apa pun. Menggunakan kembali penulis tidak menduplikasi komentar: untuk menghindari penambahan komentar yang sama berulang kali, terapkan deteksi duplikat terpisah sebelum menambahkannya.

## **Mengakses Komentar Slide**

Contoh ini membuka presentasi yang ada dan membaca koleksi yang dikembalikan oleh [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/). Untuk setiap penulis, ia mengiterasi melalui koleksi yang dikembalikan oleh [getComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/getcomments/) dan mencetak nomor slide, teks komentar, nama penulis, dan waktu pembuatan. Presentasi input harus berisi komentar agar menghasilkan output konsol.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("Comments1.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const author = authors.get_Item(authorIndex);
        const comments = author.getComments();

        for (let commentIndex = 0; commentIndex < comments.size(); commentIndex++) {
            const comment = comments.get_Item(commentIndex);
            console.log("Slide: " + comment.getSlide().getSlideNumber());
            console.log("Comment: " + comment.getText());
            console.log("Author: " + comment.getAuthor().getName());
            console.log("Posted at: " + comment.getCreatedTime());
            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Membalas Komentar**

Komentar induk adalah komentar asli di bagian atas hierarki balasan. Metode [Comment.getParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/) dan [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) memungkinkan Anda mendapatkan atau menetapkan induk sebuah komentar.

Contoh ini membuat komentar dari dua penulis dan menggunakan [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) untuk membangun balasan, termasuk balasan ke balasan lain. Mengirim `null` ke [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) mengambil komentar dari semua penulis; konsol memberi indentasi setiap entri sesuai kedalaman dalam hierarki balasan. Contoh menyimpan diskusi lengkap, memanggil [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) pada komentar akar pertama, dan menyimpan presentasi kedua dengan komentar tersebut serta balasannya dihapus.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10));
    const createdTime = java.newInstanceSync("java.util.Date");

    const originalAuthor = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    const rootComment = originalAuthor.getComments().addComment("comment 1", slide, position, createdTime);

    const reviewer = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    const firstReply = reviewer.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    firstReply.setParentComment(rootComment);

    const secondReply = reviewer.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    secondReply.setParentComment(rootComment);

    const subReply = originalAuthor.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(secondReply);

    reviewer.getComments().addComment("comment 2", slide, position, createdTime);
    const separateComment = reviewer.getComments().addComment("comment 3", slide, position, createdTime);

    const separateReply = originalAuthor.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    separateReply.setParentComment(separateComment);

    const comments = slide.getSlideComments(null);
    for (let index = 0; index < comments.length; index++) {
        let comment = comments[index];
        let indentation = "";
        while (comment.getParentComment() != null) {
            indentation += "\t";
            comment = comment.getParentComment();
        }

        console.log(indentation + comments[index].getAuthor().getName() + ": " + comments[index].getText());
    }

    presentation.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);

    rootComment.remove();
    presentation.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}

* Ketika metode [Comment.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) digunakan untuk menghapus sebuah komentar, semua balasan ke komentar tersebut juga dihapus.
* Jika [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) membuat referensi melingkar, sebuah [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxeditexception/) akan dilemparkan.

{{% /alert %}}

## **Menambahkan Komentar Modern**

Komentar modern dapat dikaitkan dengan slide itu sendiri, dengan bentuk tertentu, atau dengan rentang teks di dalam AutoShape. Metode [CommentCollection.addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) menerima argumen [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) selain slide dan koordinat penanda komentar.

Ketika `null` diberikan untuk argumen shape, komentar menjadi komentar tingkat slide. Penandanya diposisikan oleh koordinat yang diberikan, tetapi tidak dikaitkan dengan shape tertentu, sehingga [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) mengembalikan `null`. Ketika sebuah [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) disediakan, komentar diikat ke shape tersebut. Koordinat tetap menentukan posisi penanda komentar pada slide, sementara asosiasi shape dapat diambil melalui [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/).

### **Membuat Komentar Modern pada Shape**

Contoh memanggil [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) dua kali: sekali dengan shape `null` untuk komentar tingkat slide dan sekali dengan persegi panjang sebagai jangkar. Membaca [getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) mencetak `true` untuk pemeriksaan null pada komentar tingkat slide dan `Revenue title` untuk komentar yang dijadikan jangkar. Kedua komentar disimpan bersama presentasi.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    const createdTime = java.newInstanceSync("java.util.Date");
    const slideCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(20), java.newFloat(20));
    const shapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    const shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    console.log(slideComment.getShape() == null);
    console.log(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Membuat Komentar pada Berbagai Jenis Shape**

Setiap objek slide yang diturunkan dari [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) dapat digunakan sebagai jangkar shape. Contoh umum meliputi [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/), dan instance [GraphicalObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobject/) seperti diagram.

Contoh menggunakan [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) untuk mengaitkan komentar dengan masing-masing dari lima tipe shape: sebuah AutoShape, sebuah picture frame, sebuah grup, sebuah connector, dan sebuah diagram. Gambar menggunakan data gambar tersemat, jadi tidak diperlukan gambar eksternal. Setiap komentar memiliki posisi penanda masing‑misinya, dan presentasi yang disimpan mempertahankan semua lima asosiasi shape.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const createdTime = java.newInstanceSync("java.util.Date");

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");

    const autoShapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(30), java.newFloat(30));
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    const imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    const imageData = java.newArray("byte", Array.from(Buffer.from(imageBase64, "base64")));
    const image = presentation.getImages().addImage(imageData);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 120, 80, image);
    const pictureCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(230), java.newFloat(30));
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    const groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 100, 0, 80, 40);
    const groupCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(40), java.newFloat(150));
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.StraightConnector1, 220, 150, 140, 40);
    const connectorCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(240), java.newFloat(150));
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 400, 20, 250, 180);
    const chartCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(420), java.newFloat(40));
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Membuat Komentar pada Teks dan Mengatur Statusnya**

Untuk komentar modern yang terkait dengan sebuah [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) dan [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) mengakses posisi awal teks yang dipilih dalam bingkai teks shape. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) dan [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) mengakses panjang pilihan. Bersama-sama, nilai‑nilai ini mengaitkan komentar dengan rentang teks spesifik di dalam AutoShape.

Metode [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) dan [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) mengakses nilai dari enumerasi [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — tidak ada status komentar modern yang spesifik didefinisikan.
- `Active` — komentar sedang aktif.
- `Resolved` — komentar telah diselesaikan.
- `Closed` — komentar ditutup.

Contoh mengaitkan komentar modern dengan kata “quarterly revenue” dalam teks sebuah persegi panjang. Ia menghitung awal pilihan berbasis nol dari teks dan mengirimkannya ke [setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) serta menggunakan [setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) untuk menetapkan jumlah karakter yang dipilih. Setelah memanggil [setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) dengan `Resolved`, ia menyimpan dan membuka kembali presentasi. Empat pemeriksaan konsol masing‑masing harus mencetak `true`, mengonfirmasi bahwa jangkar shape, rentang teks, dan status dipertahankan.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const outputFile = "modern_comment_text_anchor.pptx";
const shapeText = "Review the quarterly revenue forecast.";
const selectedText = "quarterly revenue";
const expectedSelectionStart = shapeText.indexOf(selectedText);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.setName("Forecast text");
    shape.getTextFrame().setText(shapeText);

    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const commentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const createdTime = java.newInstanceSync("java.util.Date");
    const comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, commentPosition, createdTime);
    comment.setTextSelectionStart(expectedSelectionStart);
    comment.setTextSelectionLength(selectedText.length);
    comment.setStatus(java.newByte(aspose.slides.ModernCommentStatus.Resolved));

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedComments = reopenedSlide.getSlideComments(null);

    for (let index = 0; index < reopenedComments.length; index++) {
        const reopenedComment = reopenedComments[index];
        if (!java.instanceOf(reopenedComment, "com.aspose.slides.IModernComment")) {
            continue;
        }

        const shapeMatches = reopenedComment.getShape() != null && reopenedComment.getShape().getName() === "Forecast text";
        const selectionStartMatches = reopenedComment.getTextSelectionStart() === expectedSelectionStart;
        const selectionLengthMatches = reopenedComment.getTextSelectionLength() === selectedText.length;
        const statusMatches = reopenedComment.getStatus() === aspose.slides.ModernCommentStatus.Resolved;

        console.log("Shape anchor preserved: " + shapeMatches);
        console.log("Text selection start preserved: " + selectionStartMatches);
        console.log("Text selection length preserved: " + selectionLengthMatches);
        console.log("Resolved status preserved: " + statusMatches);
    }
} finally {
    reopenedPresentation.dispose();
}
```

### **Memeriksa Komentar Modern yang Ada**

Contoh ini memerlukan presentasi yang sudah ada yang berisi komentar modern dan mencetak teks, status, dan detail jangkar mereka. Untuk memeriksanya, periksa komentar mana yang merupakan instance dari [ModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/), kemudian periksa [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/), dan [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/). Sebuah shape `null` menunjukkan komentar tingkat slide. Untuk jangkar [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/), metode pemilihan teks mengidentifikasi rentang yang terkait dalam bingkai teks shape.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("comments.pptx");
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const slide = slides.get_Item(slideIndex);
        const comments = slide.getSlideComments(null);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (!java.instanceOf(comment, "com.aspose.slides.IModernComment")) {
                continue;
            }

            console.log("Slide: " + slide.getSlideNumber());
            console.log("Text: " + comment.getText());
            console.log("Status: " + comment.getStatus());

            const shape = comment.getShape();
            if (shape == null) {
                console.log("Anchor: slide level");
            } else {
                console.log("Anchor shape: " + shape.getName());
                console.log("Anchor type: " + shape.getClass().getSimpleName());

                if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                    console.log("Text selection start: " + comment.getTextSelectionStart());
                    console.log("Text selection length: " + comment.getTextSelectionLength());
                }
            }

            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Menghapus Komentar**

Aspose.Slides untuk Node.js via Java memungkinkan Anda menghapus semua komentar dan penulisnya dari sebuah presentasi atau menghapus komentar tertentu sambil mempertahankan yang lainnya. Contoh-contoh berikut mendemonstrasikan kedua pendekatan dan menyimpan presentasi yang diperbarui.

### **Menghapus Semua Komentar dan Penulis Komentar**

Contoh membuka presentasi yang ada dan memanggil [CommentCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/clear/) untuk setiap penulis, kemudian memanggil [CommentAuthorCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/clear/) untuk menghapus penulis itu sendiri. Presentasi yang disimpan tidak mengandung komentar maupun penulis komentar. Gunakan presentasi yang berisi komentar untuk melihat penghapusan.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let index = 0; index < authors.size(); index++) {
        authors.get_Item(index).getComments().clear();
    }

    authors.clear();

    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Menghapus Komentar Tertentu**

Contoh membuat dua komentar pada satu slide dan menggunakan [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) untuk menemukan komentar setiap penulis. Ia mengumpulkan komentar yang teksnya sama dengan “comment 1” sebelum memanggil [CommentCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/remove/), menghindari perubahan pada koleksi selama pemilihan. Presentasi yang disimpan hanya menyisakan “comment 2”.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const author = presentation.getCommentAuthors().addAuthor("Author", "A");
    const createdTime = java.newInstanceSync("java.util.Date");

    const firstCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const secondCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.3), java.newFloat(0.2));
    author.getComments().addComment("comment 1", slide, firstCommentPosition, createdTime);
    author.getComments().addComment("comment 2", slide, secondCommentPosition, createdTime);

    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const commentAuthor = authors.get_Item(authorIndex);
        const commentsToRemove = [];
        const comments = slide.getSlideComments(commentAuthor);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (comment.getText() === "comment 1") {
                commentsToRemove.push(comment);
            }
        }

        for (const comment of commentsToRemove) {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apakah Aspose.Slides mendukung status selesai untuk komentar modern?**

Ya. [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) dan [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) mengakses nilai [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/), termasuk `Resolved`. Status tersebut disimpan dalam presentasi dan dapat dibaca kembali setelah file dibuka kembali.

**Apakah diskusi berurutan (rantai balasan) didukung, dan apakah ada batasan kedalaman?**

Ya. Setiap komentar dapat merujuk ke [parent comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/), memungkinkan rantai balasan. API tidak mendefinisikan batas kedalaman tertentu.

**Dalam sistem koordinat apa posisi penanda komentar pada slide didefinisikan?**

Posisi penanda didefinisikan oleh koordinat floating‑point dalam sistem koordinat slide, memungkinkan Anda menempatkannya secara tepat pada slide.