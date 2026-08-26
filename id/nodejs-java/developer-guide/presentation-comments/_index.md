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
- menambahkan komentar
- mengakses komentar
- mengedit komentar
- membalas komentar
- menghapus komentar
- menghilangkan komentar
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kelola komentar presentasi dengan Aspose.Slides untuk Node.js via Java: menambah, membaca, mengedit, membalas, dan menghapus komentar dalam presentasi PowerPoint."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mengelola komentar presentasi dengan Aspose.Slides for Node.js via Java. Artikel ini memperkenalkan tipe utama yang terkait dengan komentar dan menunjukkan cara menambahkan komentar ke slide, mengakses komentar yang ada, bekerja dengan balasan dan komentar modern, serta menghapus komentar dari sebuah presentasi.

Contoh-contoh mencakup skenario peninjauan dan kolaborasi umum di PowerPoint, seperti menetapkan komentar kepada penulis, membaca teks komentar dan metadata, membangun rantai balasan, serta menghapus komentar yang dipilih atau semua komentar.

Di PowerPoint, komentar muncul sebagai anotasi pada slide. Memilih sebuah komentar menampilkan teksnya dan diskusi terkait.

## **Mengapa Menambahkan Komentar ke Presentasi?**

Anda dapat menggunakan komentar untuk memberikan masukan dan berkolaborasi dengan rekan kerja saat meninjau presentasi.

Aspose.Slides for Node.js via Java menyediakan API berikut untuk bekerja dengan komentar:

* Kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) yang menyediakan akses ke penulis komentar presentasi.
* Kelas [CommentCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/commentcollection/) yang mewakili komentar yang terkait dengan seorang penulis.
* Kelas [Comment](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/comment/) yang menyediakan informasi tentang sebuah komentar, termasuk penulisnya, waktu pembuatan, posisi, dan teks.
* Kelas [CommentAuthor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/commentauthor/) yang menyediakan informasi tentang seorang penulis, termasuk nama, inisial, dan komentar yang terkait.

## **Menambahkan Komentar Slide**

Contoh berikut menunjukkan cara menambahkan komentar ke slide dalam presentasi PowerPoint:

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

        const authorComments = firstComment.getAuthor().getComments();
        const commentText = authorComments.get_Item(0).getText();
        console.log(commentText);
    }

    presentation.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mengakses Komentar Slide**

Contoh berikut menunjukkan cara mengakses komentar yang ada dalam presentasi PowerPoint:

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

Komentar induk adalah komentar asli di puncak hierarki balasan. Metode [Comment.getParentComment](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/comment/getparentcomment/) dan [Comment.setParentComment](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/comment/setparentcomment/) memungkinkan Anda mengambil atau mengatur induk sebuah komentar.

Contoh berikut menunjukkan cara menambahkan balasan dan memeriksa hierarki komentar yang dihasilkan:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10));
    const createdTime = java.newInstanceSync("java.util.Date");

    const author1 = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    const comment1 = author1.getComments().addComment("comment 1", slide, position, createdTime);

    const author2 = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    const reply1 = author2.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    reply1.setParentComment(comment1);

    const reply2 = author2.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    reply2.setParentComment(comment1);

    const subReply = author1.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(reply2);

    author2.getComments().addComment("comment 2", slide, position, createdTime);
    const comment3 = author2.getComments().addComment("comment 3", slide, position, createdTime);

    const reply3 = author1.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    reply3.setParentComment(comment3);

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

    comment1.remove();
    presentation.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* Ketika metode [Comment.remove](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/comment/remove/) digunakan untuk menghapus sebuah komentar, semua balasan terhadap komentar tersebut juga dihapus.
* Jika [Comment.setParentComment](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/comment/setparentcomment/) membuat referensi melingkar, sebuah [PptxEditException](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pptxeditexception/) akan dilempar.
{{% /alert %}}

## **Menambahkan Komentar Modern**

Komentar modern dapat dikaitkan dengan slide itu sendiri, dengan bentuk tertentu, atau dengan rentang teks di dalam sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/). Metode [CommentCollection.addModernComment](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) menerima argumen [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/) selain slide dan koordinat penanda komentar.

Ketika `null` diberikan untuk argumen shape, komentar menjadi komentar tingkat slide. Penandanya diposisikan oleh koordinat yang diberikan, tetapi tidak terkait dengan bentuk tertentu, sehingga [ModernComment.getShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/moderncomment/getshape/) mengembalikan `null`. Ketika sebuah [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/) disediakan, komentar diikat ke bentuk tersebut. Koordinat tetap menentukan posisi penanda komentar pada slide, sementara asosiasi bentuk dapat diambil melalui [ModernComment.getShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/moderncomment/getshape/).

### **Menambatkan Komentar Modern ke Bentuk**

Contoh berikut membuat komentar modern tingkat slide serta komentar modern yang ditambatkan ke sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) tertentu. Kemudian membaca bentuk yang terkait dari masing‑masing komentar.

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

### **Menambatkan Komentar ke Berbagai Tipe Bentuk**

Setiap objek slide yang diturunkan dari [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/) dapat digunakan sebagai jangkar bentuk. Contoh umum meliputi [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/connector/), dan contoh [GraphicalObject](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/graphicalobject/) seperti bagan.

Contoh berikut membuat beberapa tipe bentuk umum dan mengaitkan komentar modern dengan masing‑masing.

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

### **Menambatkan Komentar ke Teks dan Menetapkan Statusnya**

Untuk komentar modern yang terkait dengan sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) dan [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) mengakses posisi awal teks yang dipilih dalam bingkai teks bentuk. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) dan [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) mengakses panjang seleksi. Bersama‑sama, nilai‑nilai ini mengaitkan komentar dengan rentang teks tertentu di dalam [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/).

[ModernComment.getStatus](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/moderncomment/getstatus/) dan [ModernComment.setStatus](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/moderncomment/setstatus/) mengakses nilai dari enumerasi [ModernCommentStatus](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — tidak ada status komentar modern tertentu yang didefinisikan.
- `Active` — komentar aktif.
- `Resolved` — komentar telah diselesaikan.
- `Closed` — komentar ditutup.

Contoh berikut membuat komentar modern yang ditambatkan pada bentuk, mengaitkannya dengan seleksi teks, menandainya sebagai diselesaikan, menyimpan presentasi, dan memverifikasi nilai‑nilai setelah membuka kembali file.

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
    comment.setStatus(aspose.slides.ModernCommentStatus.Resolved);

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

Untuk memeriksa presentasi yang ada, periksa komentar mana yang merupakan instance [ModernComment](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/moderncomment/), kemudian tinjau [ModernComment.getShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/), dan [ModernComment.getStatus](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/moderncomment/getstatus/). Bentuk `null` menunjukkan komentar tingkat slide. Untuk jangkar [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/), metode seleksi teks mengidentifikasi rentang yang terkait dalam bingkai teks bentuk.

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

### **Menghapus Semua Komentar dan Penulis Komentar**

Contoh berikut menunjukkan cara menghapus semua komentar dan penulis komentar dari sebuah presentasi:

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

Contoh berikut menunjukkan cara menghapus komentar tertentu dari sebuah slide:

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

**Apakah Aspose.Slides mendukung status diselesaikan untuk komentar modern?**

Ya. [ModernComment.getStatus](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/moderncomment/getstatus/) dan [ModernComment.setStatus](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/moderncomment/setstatus/) mengakses nilai [ModernCommentStatus](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/moderncommentstatus/), termasuk `Resolved`. Status tersebut disimpan dalam presentasi dan dapat dibaca kembali setelah file dibuka kembali.

**Apakah diskusi berulir (rantai balasan) didukung, dan apakah ada batas kedalaman?**

Ya. Setiap komentar dapat merujuk ke [parent comment](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/comment/getparentcomment/)‑nya, memungkinkan rantai balasan. API tidak mendefinisikan batas kedalaman tertentu.

**Pada sistem koordinat apa posisi penanda komentar didefinisikan pada slide?**

Posisi penanda didefinisikan oleh koordinat floating‑point dalam sistem koordinat slide, memungkinkan Anda menempatkannya secara tepat pada slide.