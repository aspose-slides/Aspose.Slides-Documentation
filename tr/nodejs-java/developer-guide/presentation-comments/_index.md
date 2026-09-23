---
title: Node.js'te Sunum Yorumlarını Yönet
linktitle: Sunum Yorumları
type: docs
weight: 100
url: /tr/nodejs-java/presentation-comments/
keywords:
- yorum
- modern yorum
- PowerPoint yorumları
- sunum yorumları
- slayt yorumları
- yorum ekle
- yoruma eriş
- yorumu düzenle
- yoruma yanıt
- yorum kaldır
- yorum sil
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile sunum yorumlarını yönetin: PowerPoint sunumlarında yorum ekleme, okuma, düzenleme, yanıt verme ve kaldırma."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Node.js via Java ile sunum yorumlarını nasıl yöneteceğinizi açıklar. Ana yorumla ilişkili tipleri tanıtır ve slaytlara yorum ekleme, mevcut yorumlara erişme, yanıtlar ve modern yorumlarla çalışma ve bir sunumdan yorumları kaldırma konularını gösterir.

Örnekler, PowerPoint'te yorumları yazara atama, yorum metni ve meta verilerini okuma, yanıt zincirleri oluşturma ve seçili yorumları ya da tüm yorumları kaldırma gibi yaygın inceleme ve iş birliği senaryolarını kapsar.

PowerPoint'te yorumlar, slaytlardaki açıklamalar olarak görünür. Bir yorumu seçmek, metnini ve ilgili tartışmayı gösterir.

Sunum açıldığında yorumların gösterilmesini veya gizlenmesini, yorumların kendisini değiştirmeden isteğe bağlı olarak ayarlamak için [Show or Hide Comments When Opening a Presentation](/slides/tr/nodejs-java/presentation-view-properties/) bölümüne bakın.

## **Sunumlara Neden Yorum Eklenir?**

Sunumları incelerken geri bildirim sağlamak ve çalışanlarla iş birliği yapmak için yorumları kullanabilirsiniz.

Aspose.Slides for Node.js via Java, yorumlarla çalışma için aşağıdaki API'leri sunar:

* [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfı, sunumun yorum yazarlarına erişim sağlar.
* [CommentCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/commentcollection/) sınıfı, belirli bir yazarla ilişkili yorumları temsil eder.
* [Comment](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/comment/) sınıfı, bir yorumun yazarını, oluşturma zamanını, konumunu ve metnini içeren bilgileri sağlar.
* [CommentAuthor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/commentauthor/) sınıfı, yazarın adını, baş harflerini ve ilişkili yorumlarını içerir.

## **Slayt Yorumları Ekleme**

Aşağıdaki örnek, bir PowerPoint sunumunda slaytlara yorum eklemeyi gösterir:

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

## **Slayt Yorumlarına Erişim**

Aşağıdaki örnek, bir PowerPoint sunumunda mevcut yorumlara nasıl erişileceğini gösterir:

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

## **Yorumlara Yanıt Verme**

Üst yorum, yanıt hiyerarşisinin en üstündeki orijinal yorumdur. [Comment.getParentComment](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/comment/getparentcomment/) ve [Comment.setParentComment](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/comment/setparentcomment/) metotları, bir yorumun üst yorumunu almanızı veya ayarlamanızı sağlar.

Aşağıdaki örnek, yanıt eklemeyi ve ortaya çıkan yorum hiyerarşisini incelemeyi gösterir:

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
* [Comment.remove](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/comment/remove/) metodu kullanılarak bir yorum silindiğinde, o yoruma ait tüm yanıtlar da silinir.  
* [Comment.setParentComment](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/comment/setparentcomment/) dairesel bir referans oluşturursa, bir [PptxEditException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pptxeditexception/) fırlatılır.  
{{% /alert %}}

## **Modern Yorumlar Ekleme**

Modern yorumlar, slaytın kendisine, belirli bir şekle veya bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) içindeki metin aralığına ilişkilendirilebilir. [CommentCollection.addModernComment](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) metodu, slayt ve yorum işaretçisi koordinatlarının yanı sıra bir [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/) argümanı kabul eder.

Şekil argümanı için `null` geçirilirse, yorum bir slayt‑seviyesi yorum olur. İşaretçi sağlanan koordinatlarla konumlandırılır, ancak belirli bir şekle ilişkilendirilmez; bu nedenle [ModernComment.getShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/getshape/) `null` döndürür. Bir [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/) verildiğinde, yorum o şekle sabitlenir. Koordinatlar hâlâ yorum işaretçisinin slayttaki konumunu tanımlar, şekil ilişkisi ise [ModernComment.getShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/getshape/) ile alınabilir.

### **Modern Yorumu Bir Şekle Sabitleme**

Aşağıdaki örnek, hem bir slayt‑seviyesi modern yorum hem de belirli bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) üzerine sabitlenmiş bir modern yorum oluşturur. Ardından her yorumun ilişkili şekli okunur.

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

### **Yorumları Farklı Şekil Türlerine Sabitleme**

[Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/) türünden türetilen herhangi bir slayt nesnesi şekil sabitleme olarak kullanılabilir. Yaygın örnekler şunlardır: [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/connector/) ve grafik nesneleri (örneğin grafikler) gibi [GraphicalObject](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/graphicalobject/) örnekleri.

Aşağıdaki örnek, birkaç yaygın şekil türü oluşturur ve her birine modern bir yorum ilişkilendirir.

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

### **Yorumu Metne Sabitleme ve Durumunu Ayarlama**

Bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ile ilişkili modern yorum için, [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) ve [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) seçili metnin şeklin metin çerçevesindeki başlangıç konumuna erişir. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) ve [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) seçimin uzunluğunu alır. Bu değerler birlikte yorumun [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) içindeki belirli bir metin aralığıyla ilişkilendirilmesini sağlar.

[ModernComment.getStatus](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/getstatus/) ve [ModernComment.setStatus](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/setstatus/) metotları, [ModernCommentStatus](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncommentstatus/) enumarasyonundan bir değere erişir:

- `NotDefined` — belirli bir modern yorum durumu tanımlanmamıştır.  
- `Active` — yorum aktiftir.  
- `Resolved` — yorum çözülmüştür.  
- `Closed` — yorum kapatılmıştır.

Aşağıdaki örnek, şekle sabitlenmiş bir modern yorum oluşturur, bir metin seçimiyle ilişkilendirir, çözüldü olarak işaretler, sunumu kaydeder ve dosyayı tekrar açtıktan sonra değerleri doğrular.

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

### **Mevcut Modern Yorumları İnceleme**

Mevcut bir sunumu incelemek için, hangi yorumların [ModernComment](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/) örnekleri olduğunu kontrol edin, ardından [ModernComment.getShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) ve [ModernComment.getStatus](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/getstatus/) metotlarını inceleyin. `null` bir şekil, slayt‑seviyesi bir yorum olduğunu gösterir. Bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) sapanı için, metin‑seçim metodları şeklin metin çerçevesindeki ilişkili aralığı tanımlar.

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

## **Yorumları Kaldırma**

### **Tüm Yorumları ve Yorum Yazarlarını Kaldırma**

Aşağıdaki örnek, bir sunumdan tüm yorumları ve yorum yazarlarını kaldırmayı gösterir:

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

### **Belirli Yorumları Kaldırma**

Aşağıdaki örnek, bir slayttan belirli yorumları kaldırmayı gösterir:

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

## **SSS**

**Aspose.Slides modern yorumlar için çözüldü durumu destekliyor mu?**

Evet. [ModernComment.getStatus](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/getstatus/) ve [ModernComment.setStatus](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/setstatus/) [ModernCommentStatus](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncommentstatus/) değeri, `Resolved` dahil olmak üzere, erişir. Durum sunumda depolanır ve dosya tekrar açıldıktan sonra yeniden okunabilir.

**İşlemeli tartışmalar (yanıt zincirleri) destekleniyor mu, ve bir iç içe limit var mı?**

Evet. Her yorum, bir [parent comment](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/comment/getparentcomment/) referansı gösterebilir; bu sayede yanıt zincirleri oluşturulabilir. API, belirli bir iç içe derinlik sınırı tanımlamaz.

**Bir yorum işaretçisinin slayt üzerindeki konumu hangi koordinat sisteminde tanımlanır?**

İşaretçi konumu, slayt koordinat sistemindeki kayan nokta koordinatlarıyla tanımlanır; bu sayede işaretçi slayt üzerinde hassas bir konuma yerleştirilebilir.