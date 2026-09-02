---
title: Kelola Komentar Presentasi di Android
linktitle: Komentar Presentasi
type: docs
weight: 100
url: /id/androidjava/presentation-comments/
keywords:
- komentar
- komentar modern
- komentar PowerPoint
- komentar presentasi
- komentar slide
- menambah komentar
- mengakses komentar
- mengedit komentar
- membalas komentar
- menghapus komentar
- menghapus komentar
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Kelola komentar presentasi dengan Aspose.Slides untuk Android via Java: menambah, membaca, mengedit, membalas, dan menghapus komentar dalam presentasi PowerPoint dengan cepat dan mudah."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengelola komentar presentasi dengan Aspose.Slides for Android via Java. Artikel ini memperkenalkan tipe utama yang terkait dengan komentar dan mendemonstrasikan cara menambahkan komentar ke slide, mengakses komentar yang ada, bekerja dengan balasan dan komentar modern, serta menghapus komentar dari sebuah presentasi.

Contoh-contoh mencakup skenario peninjauan dan kolaborasi umum di PowerPoint, seperti menugaskan komentar kepada penulis, membaca teks komentar dan metadata, membangun rantai balasan, dan menghapus komentar yang dipilih atau semua komentar.

Di PowerPoint, komentar muncul sebagai anotasi pada slide. Memilih sebuah komentar menampilkan teksnya dan diskusi terkait.

## **Mengapa Menambahkan Komentar ke Presentasi?**

Anda dapat menggunakan komentar untuk memberikan umpan balik dan berkolaborasi dengan rekan kerja saat meninjau presentasi.

Aspose.Slides for Android via Java menyediakan API berikut untuk bekerja dengan komentar:

* The [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) class, which provides access to the presentation's comment authors. → kelas yang menyediakan akses ke penulis komentar presentasi.
* The [ICommentCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icommentcollection/) interface, which represents the comments associated with an individual author. → antarmuka yang mewakili komentar yang terkait dengan seorang penulis.
* The [IComment](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icomment/) interface, which provides information about a comment, including its author, creation time, position, and text. → antarmuka yang menyediakan informasi tentang sebuah komentar, termasuk penulis, waktu pembuatan, posisi, dan teks.
* The [CommentAuthor](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/commentauthor/) class, which provides information about an author, including their name, initials, and associated comments. → kelas yang menyediakan informasi tentang seorang penulis, termasuk nama, inisial, dan komentar yang terkait.

## **Menambahkan Komentar Slide**

Contoh berikut menunjukkan cara menambahkan komentar ke slide dalam presentasi PowerPoint:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ICommentCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    PointF position = new PointF(0.2f, 0.2f);
    Date createdTime = new Date();

    author.getComments().addComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
    author.getComments().addComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

    IComment[] comments = firstSlide.getSlideComments(author);
    if (comments.length > 0) {
        IComment firstComment = comments[0];
        System.out.println(firstComment.getText());

        ICommentCollection authorComments = firstComment.getAuthor().getComments();
        String commentText = authorComments.get_Item(0).getText();
        System.out.println(commentText);
    }

    presentation.save("Comments_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mengakses Komentar Slide**

Contoh berikut menunjukkan cara mengakses komentar yang ada dalam presentasi PowerPoint:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor author : presentation.getCommentAuthors()) {
        for (IComment comment : author.getComments()) {
            System.out.println("Slide: " + comment.getSlide().getSlideNumber());
            System.out.println("Comment: " + comment.getText());
            System.out.println("Author: " + comment.getAuthor().getName());
            System.out.println("Posted at: " + comment.getCreatedTime());
            System.out.println();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Membalas Komentar**

Komentar induk adalah komentar asli di bagian atas hierarki balasan. Metode [IComment.getParentComment](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icomment/#getParentComment--) dan [IComment.setParentComment](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) memungkinkan Anda mendapatkan atau mengatur induk sebuah komentar.

Contoh berikut menunjukkan cara menambahkan balasan dan memeriksa hierarki komentar yang dihasilkan:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    PointF position = new PointF(10, 10);
    Date createdTime = new Date();

    ICommentAuthor author1 = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment 1", slide, position, createdTime);

    ICommentAuthor author2 = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    reply1.setParentComment(comment1);

    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    reply2.setParentComment(comment1);

    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(reply2);

    author2.getComments().addComment("comment 2", slide, position, createdTime);
    IComment comment3 = author2.getComments().addComment("comment 3", slide, position, createdTime);

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    reply3.setParentComment(comment3);

    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++) {
        IComment comment = comments[i];
        while (comment.getParentComment() != null) {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() + ": " + comments[i].getText());
    }

    presentation.save("parent_comment.pptx", SaveFormat.Pptx);

    comment1.remove();
    presentation.save("remove_comment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* Ketika metode [IComment.remove](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icomment/#remove--) digunakan untuk menghapus sebuah komentar, semua balasan ke komentar tersebut juga dihapus.
* Jika [IComment.setParentComment](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) membuat referensi melingkar, sebuah [PptxEditException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pptxeditexception/) akan dilemparkan.
{{% /alert %}}

## **Menambahkan Komentar Modern**

Komentar modern dapat dikaitkan dengan slide itu sendiri, dengan bentuk tertentu, atau dengan rentang teks di dalam AutoShape. Metode [ICommentCollection.addModernComment](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) menerima argumen [IShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/) selain slide dan koordinat penanda komentar.

Ketika `null` diberikan untuk argumen shape, komentar menjadi komentar tingkat slide. Penandanya diposisikan oleh koordinat yang diberikan, tetapi tidak dikaitkan dengan bentuk tertentu, sehingga [IModernComment.getShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imoderncomment/#getShape--) mengembalikan `null`. Ketika sebuah [IShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/) disediakan, komentar dipasang pada shape tersebut. Koordinat tetap menentukan posisi penanda komentar pada slide, sementara asosiasi shape dapat diambil melalui [IModernComment.getShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imoderncomment/#getShape--).

### **Menambat Komentar Modern pada Bentuk**

Contoh berikut membuat komentar modern tingkat slide dan komentar modern yang dipasang pada AutoShape tertentu. Kemudian contoh tersebut membaca shape yang terkait dari masing‑masing komentar.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import android.graphics.PointF;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    Date createdTime = new Date();
    PointF slideCommentPosition = new PointF(20, 20);
    PointF shapeCommentPosition = new PointF(60, 60);
    IModernComment slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    IModernComment shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    System.out.println(slideComment.getShape() == null);
    System.out.println(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Menambat Komentar ke Berbagai Tipe Bentuk**

Setiap objek slide yang mengimplementasikan [IShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/) dapat digunakan sebagai penambat shape. Contoh umum termasuk [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iconnector/), dan instance [IGraphicalObject](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/igraphicalobject/) seperti bagan.

Contoh berikut membuat beberapa tipe shape umum dan mengaitkan komentar modern dengan masing‑masing.

```java
import com.aspose.slides.ChartType;
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IChart;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IConnector;
import com.aspose.slides.IGroupShape;
import com.aspose.slides.IPPImage;
import com.aspose.slides.IPictureFrame;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import android.graphics.PointF;
import java.util.Base64;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    Date createdTime = new Date();

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");
    PointF autoShapeCommentPosition = new PointF(30, 30);
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    String imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    byte[] imageData = Base64.getDecoder().decode(imageBase64);
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image);
    PointF pictureCommentPosition = new PointF(230, 30);
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    IGroupShape groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40);
    PointF groupCommentPosition = new PointF(40, 150);
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40);
    PointF connectorCommentPosition = new PointF(240, 150);
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180);
    PointF chartCommentPosition = new PointF(420, 40);
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Menambat Komentar pada Teks dan Menetapkan Statusnya**

Untuk komentar modern yang terkait dengan sebuah [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/), metode [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--) dan [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) mengakses posisi awal teks yang dipilih dalam bingkai teks shape. Metode [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) dan [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) mengakses panjang pilihan. Bersama‑sama, nilai‑nilai ini mengaitkan komentar dengan rentang teks tertentu di dalam AutoShape.

Metode [IModernComment.getStatus](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imoderncomment/#getStatus--) dan [IModernComment.setStatus](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) mengakses nilai dari konstanta [ModernCommentStatus](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/moderncommentstatus/):

- `NotDefined` — tidak ada status komentar modern tertentu yang didefinisikan.
- `Active` — komentar aktif.
- `Resolved` — komentar telah diselesaikan.
- `Closed` — komentar ditutup.

Contoh berikut membuat komentar modern yang dipasang pada shape, mengaitkannya dengan pilihan teks, menandainya sebagai diselesaikan, menyimpan presentasi, dan memverifikasi nilai‑nilai setelah file dibuka kembali.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.ModernCommentStatus;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import android.graphics.PointF;
import java.util.Date;

String outputFile = "modern_comment_text_anchor.pptx";
String shapeText = "Review the quarterly revenue forecast.";
String selectedText = "quarterly revenue";
int expectedSelectionStart = shapeText.indexOf(selectedText);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.setName("Forecast text");
    shape.getTextFrame().setText(shapeText);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    PointF commentPosition = new PointF(60, 60);
    IModernComment comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, commentPosition, new Date());
    comment.setTextSelectionStart(expectedSelectionStart);
    comment.setTextSelectionLength(selectedText.length());
    comment.setStatus(ModernCommentStatus.Resolved);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IComment[] reopenedComments = reopenedSlide.getSlideComments(null);

    for (IComment reopenedComment : reopenedComments) {
        if (!(reopenedComment instanceof IModernComment)) {
            continue;
        }

        IModernComment modernComment = (IModernComment) reopenedComment;
        boolean shapeMatches = modernComment.getShape() != null && "Forecast text".equals(modernComment.getShape().getName());
        boolean selectionStartMatches = modernComment.getTextSelectionStart() == expectedSelectionStart;
        boolean selectionLengthMatches = modernComment.getTextSelectionLength() == selectedText.length();
        boolean statusMatches = modernComment.getStatus() == ModernCommentStatus.Resolved;

        System.out.println("Shape anchor preserved: " + shapeMatches);
        System.out.println("Text selection start preserved: " + selectionStartMatches);
        System.out.println("Text selection length preserved: " + selectionLengthMatches);
        System.out.println("Resolved status preserved: " + statusMatches);
    }
} finally {
    reopenedPresentation.dispose();
}
```

### **Memeriksa Komentar Modern yang Ada**

Untuk memeriksa presentasi yang ada, periksa komentar mana yang mengimplementasikan [IModernComment](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imoderncomment/), kemudian periksa [IModernComment.getShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--), dan [IModernComment.getStatus](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imoderncomment/#getStatus--). Sebuah shape `null` menunjukkan komentar tingkat slide. Untuk penambat [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/), metode pilihan teks mengidentifikasi rentang yang terkait dalam bingkai teks shape.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IComment;
import com.aspose.slides.IModernComment;
import com.aspose.slides.IShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("comments.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        IComment[] comments = slide.getSlideComments(null);
        for (IComment comment : comments) {
            if (!(comment instanceof IModernComment)) {
                continue;
            }

            IModernComment modernComment = (IModernComment) comment;
            System.out.println("Slide: " + slide.getSlideNumber());
            System.out.println("Text: " + modernComment.getText());
            System.out.println("Status: " + modernComment.getStatus());

            IShape shape = modernComment.getShape();
            if (shape == null) {
                System.out.println("Anchor: slide level");
            } else {
                System.out.println("Anchor shape: " + shape.getName());
                System.out.println("Anchor type: " + shape.getClass().getSimpleName());

                if (shape instanceof IAutoShape) {
                    System.out.println("Text selection start: " + modernComment.getTextSelectionStart());
                    System.out.println("Text selection length: " + modernComment.getTextSelectionLength());
                }
            }

            System.out.println();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Menghapus Komentar**

### **Menghapus Semua Komentar dan Penulis Komentar**

Contoh berikut menunjukkan cara menghapus semua komentar dan penulis komentar dari sebuah presentasi:

```java
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("example.pptx");
try {
    for (ICommentAuthor author : presentation.getCommentAuthors()) {
        author.getComments().clear();
    }

    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Menghapus Komentar Tertentu**

Contoh berikut menunjukkan cara menghapus komentar tertentu dari sebuah slide:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    Date createdTime = new Date();

    PointF firstCommentPosition = new PointF(0.2f, 0.2f);
    PointF secondCommentPosition = new PointF(0.3f, 0.2f);
    author.getComments().addComment("comment 1", slide, firstCommentPosition, createdTime);
    author.getComments().addComment("comment 2", slide, secondCommentPosition, createdTime);

    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors()) {
        List<IComment> commentsToRemove = new ArrayList<IComment>();
        IComment[] comments = slide.getSlideComments(commentAuthor);

        for (IComment comment : comments) {
            if ("comment 1".equals(comment.getText())) {
                commentsToRemove.add(comment);
            }
        }

        for (IComment comment : commentsToRemove) {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apakah Aspose.Slides mendukung status diselesaikan untuk komentar modern?**

Ya. Metode [IModernComment.getStatus](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imoderncomment/#getStatus--) dan [IModernComment.setStatus](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) mengakses nilai [ModernCommentStatus](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/moderncommentstatus/), termasuk `Resolved`. Status tersebut disimpan dalam presentasi dan dapat dibaca kembali setelah file dibuka kembali.

**Apakah diskusi beruntai (rantai balasan) didukung, dan apakah ada batas kedalaman?**

Ya. Setiap komentar dapat merujuk ke [parent comment](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icomment/#getParentComment--)‑nya, memungkinkan rantai balasan. API tidak menentukan batas kedalaman penumpukan tertentu.

**Dalam sistem koordinat apa posisi penanda komentar didefinisikan pada slide?**

Posisi penanda didefinisikan oleh koordinat floating‑point dalam sistem koordinat slide, memungkinkan Anda menempatkannya secara tepat pada slide.