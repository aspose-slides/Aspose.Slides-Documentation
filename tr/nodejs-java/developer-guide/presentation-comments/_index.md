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
description: "Aspose.Slides for Node.js via Java ile sunum yorumlarını yönetin: PowerPoint sunumlarında yorum ekleme, okuma, düzenleme, yanıtlama ve kaldırma."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Node.js via Java kullanarak sunum yorumlarını nasıl yöneteceğinizi açıklar. Ana yorumla ilgili tipleri tanıtır ve slaytlara yorum ekleme, mevcut yorumlara erişme, yanıtlar ve modern yorumlarla çalışma ve bir sunumdan yorumları kaldırma konularını gösterir.

Örnekler, PowerPoint'te yaygın inceleme ve işbirliği senaryolarını kapsar; örneğin yazarlarla yorum atama, yorum metni ve meta verilerini okuma, yanıt zincirleri oluşturma ve seçili yorumları ya da tüm yorumları silme.

PowerPoint'te yorumlar, slaytlardaki açıklama olarak görünür. Bir yorumu seçmek, metnini ve ilgili tartışmayı gösterir.

## **Sunumlara Neden Yorum Eklenir?**

Sunumları incelerken geri bildirim sağlamak ve meslektaşlarla işbirliği yapmak için yorumları kullanabilirsiniz.

Aspose.Slides for Node.js via Java, yorumlarla çalışmak için aşağıdaki API'leri sunar:

* [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfı, sunumun yorum yazarlarına erişim sağlar.
* [CommentCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/commentcollection/) sınıfı, tek bir yazarla ilişkili yorumları temsil eder.
* [Comment](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/comment/) sınıfı, bir yorum hakkında yazar, oluşturma zamanı, konum ve metin gibi bilgileri verir.
* [CommentAuthor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/commentauthor/) sınıfı, yazarın adı, baş harfleri ve ilişkili yorumları gibi bilgileri sağlar.

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

## **Slayt Yorumlarına Erişme**

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

Üst yorum, yanıt hiyerarşisinin en üstündeki orijinal yorumdur. [Comment.getParentComment](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/comment/getparentcomment/) ve [Comment.setParentComment](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/comment/setparentcomment/) yöntemleri, bir yorumun üst yorumunu almanıza veya ayarlamanıza olanak tanır.

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
* [Comment.remove](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/comment/remove/) yöntemi bir yorumu silmek için kullanıldığında, o yoruma ait tüm yanıtlar da silinir.
* [Comment.setParentComment](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/comment/setparentcomment/) döngüsel bir referans oluşturursa, bir [PptxEditException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pptxeditexception/) fırlatılır.
{{% /alert %}}

## **Modern Yorumlar Ekleme**

Modern yorumlar, doğrudan slayt, belirli bir şekil veya bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) içindeki metin aralığıyla ilişkilendirilebilir. [CommentCollection.addModernComment](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) yöntemi, slayt ve yorum işaretleyici koordinatlarının yanı sıra bir [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/) argümanı kabul eder.

Şekil argümanı için `null` geçildiğinde, yorum slayt‑seviyesinde bir yorum olur. İşaretleyici sağlanan koordinatlarla konumlandırılır, ancak belirli bir şekille ilişkilendirilmez, bu nedenle [ModernComment.getShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/getshape/) `null` döner. Bir [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/) sağlandığında, yorum o şekle bağlanır. Koordinatlar hâlâ yorum işaretleyicisinin slayt üzerindeki konumunu tanımlar, şekil ilişkisi ise [ModernComment.getShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/getshape/) ile alınabilir.

### **Bir Modern Yorumu Şekle Bağlama**

Aşağıdaki örnek, hem slayt‑seviyesinde bir modern yorum hem de belirli bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) üzerine bağlanmış bir modern yorum oluşturur. Ardından her yorumdan ilişkili şekli okur.

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

### **Yorumları Farklı Şekil Türlerine Bağlama**

[Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/) türevi herhangi bir slayt nesnesi, şekil bağlantısı olarak kullanılabilir. Yaygın örnekler arasında [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/connector/) ve grafik nesneleri (örneğin grafikler) yer alır.

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

### **Bir Yorumu Metne Bağlama ve Durumunu Ayarlama**

Bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) ile ilişkili modern yorum için, [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) ve [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) yöntemleri, şeklin metin çerçevesindeki seçili metnin başlangıç konumuna erişir. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) ve [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) ise seçimin uzunluğunu verir. Bu değerler birlikte, yorumu [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) içindeki belirli bir metin aralığıyla ilişkilendirir.

[ModernComment.getStatus](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/getstatus/) ve [ModernComment.setStatus](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/setstatus/) yöntemleri, [ModernCommentStatus](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncommentstatus/) enum'undan bir değere erişir:

- `NotDefined` — belirli bir modern yorum durumu tanımlanmamış.
- `Active` — yorum etkindir.
- `Resolved` — yorum çözülmüştür.
- `Closed` — yorum kapatılmıştır.

Aşağıdaki örnek, şekil‑bağlantılı bir modern yorum oluşturur, bir metin seçimiyle ilişkilendirir, çözülmüş olarak işaretler, sunumu kaydeder ve dosya yeniden açıldıktan sonra değerleri doğrular.

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

Mevcut bir sunumu incelemek için, hangi yorumların [ModernComment](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/) örneği olduğunu kontrol edin, ardından [ModernComment.getShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) ve [ModernComment.getStatus](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/getstatus/) yöntemlerine bakın. `null` bir şekil, slayt‑seviyesinde bir yorum olduğunu gösterir. Bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) bağlantısı için, metin‑seçim yöntemleri şeklin metin çerçevesindeki ilgili aralığı tanımlar.

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

**Aspose.Slides modern yorumlar için bir çözülmüş durumu destekliyor mu?**

Evet. [ModernComment.getStatus](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/getstatus/) ve [ModernComment.setStatus](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/setstatus/) bir [ModernCommentStatus](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncommentstatus/) değerine, `Resolved` dahil, erişir. Durum sunumda depolanır ve dosya yeniden açıldıktan sonra tekrar okunabilir.

**İşlemeli tartışmalar (yanıt zincirleri) destekleniyor mu, bir iç içe limit var mı?**

Evet. Her yorum, bir [parent comment](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/comment/getparentcomment/) referansı taşıyabilir; bu da yanıt zincirlerini mümkün kılar. API belirli bir iç içe derinlik sınırı tanımlamaz.

**Bir yorum işaretleyicisinin slayt üzerindeki konumu hangi koordinat sisteminde tanımlanır?**

İşaretleyici konumu, slayt koordinat sisteminde kayan nokta koordinatlarıyla tanımlanır; böylece işaretleyiciyi slayt üzerinde tam olarak konumlandırabilirsiniz.