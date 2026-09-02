---
title: Android'de Sunum Yorumlarını Yönetme
linktitle: Sunum Yorumları
type: docs
weight: 100
url: /tr/androidjava/presentation-comments/
keywords:
- yorum
- modern yorum
- PowerPoint yorumları
- sunum yorumları
- slayt yorumları
- yorum ekle
- yoruma eriş
- yorumu düzenle
- yoruma yanıtla
- yorumu kaldır
- yorumu sil
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile sunum yorumlarını yönetin: PowerPoint sunumlarında yorum ekleme, okuma, düzenleme, yanıtlama ve kaldırma işlemlerini hızlı ve kolay bir şekilde yapın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Android via Java ile sunum yorumlarını nasıl yöneteceğinizi açıklar. Yorumlarla ilgili temel tipleri tanıtır ve slaytlara yorum ekleme, mevcut yorumlara erişme, yanıtlar ve modern yorumlarla çalışma ve bir sunumdan yorumları kaldırma konularını gösterir.

Örnekler, PowerPoint’te yaygın inceleme ve iş birliği senaryolarını kapsar; örneğin yorumları yazarlarına atama, yorum metnini ve meta verilerini okuma, yanıt zincirleri oluşturma ve seçili yorumları ya da tüm yorumları kaldırma.

PowerPoint’te yorumlar, slaytlar üzerindeki ek açıklamalar olarak görünür. Bir yorumu seçtiğinizde metni ve ilgili tartışma görüntülenir.

## **Sunumlara Neden Yorum Eklenir?**

Sunumları incelerken geri bildirim vermek ve meslektaşlarınızla iş birliği yapmak için yorumları kullanabilirsiniz.

Aspose.Slides for Android via Java, yorumlarla çalışmak için aşağıdaki API’leri sunar:

* [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfı, sunumun yorum yazarlarına erişim sağlar.
* [ICommentCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icommentcollection/) arayüzü, belirli bir yazarla ilişkilendirilmiş yorumları temsil eder.
* [IComment](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icomment/) arayüzü, bir yorumun yazarını, oluşturulma zamanını, konumunu ve metnini içeren bilgileri sağlar.
* [CommentAuthor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/commentauthor/) sınıfı, bir yazarın adını, baş harflerini ve ilişkili yorumlarını içerir.

## **Slayt Yorumları Ekleme**

Aşağıdaki örnek, bir PowerPoint sunumundaki slaytlara nasıl yorum ekleyeceğinizi gösterir:

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

## **Slayt Yorumlarına Erişme**

Aşağıdaki örnek, bir PowerPoint sunumundaki mevcut yorumlara nasıl erişileceğini gösterir:

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

## **Yorumlara Yanıt Verme**

Bir üst yorum, yanıt hiyerarşisinin en üstündeki orijinal yorumdur. [IComment.getParentComment](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icomment/#getParentComment--) ve [IComment.setParentComment](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) metodları, bir yorumun üst öğesini almanıza veya ayarlamanıza olanak tanır.

Aşağıdaki örnek, yanıtlar eklemeyi ve ortaya çıkan yorum hiyerarşisini incelemeyi gösterir:

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

* [IComment.remove](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icomment/#remove--) metodu bir yorumu silmek için kullanıldığında, o yoruma ait tüm yanıtlar da silinir.
* [IComment.setParentComment](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) dairesel bir referans oluşturursa, bir [PptxEditException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pptxeditexception/) fırlatılır.

{{% /alert %}}

## **Modern Yorumlar Ekleme**

Modern yorumlar, slaytın kendisine, belirli bir şekle veya bir AutoShape içindeki bir metin aralığına ilişkilendirilebilir. [ICommentCollection.addModernComment](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) metodu, slayt ve yorum işaretleyici koordinatlarına ek olarak bir [IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) parametresi alır.

Şekil parametresi için `null` gönderildiğinde yorum, slayt‑seviyesine ait bir yorum olur. İşaretleyici sağlanan koordinatlarla konumlandırılır, ancak belirli bir şekle bağlı değildir; bu nedenle [IModernComment.getShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imoderncomment/#getShape--) `null` döndürür. Bir [IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) sağlandığında yorum o şekle bağlanır. Koordinatlar hâlâ yorum işaretleyicisinin slayt üzerindeki konumunu tanımlar, şekil ilişkilendirmesi ise [IModernComment.getShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imoderncomment/#getShape--) aracılığıyla elde edilebilir.

### **Modern Yorumları Bir Şekle Bağlama**

Aşağıdaki örnek, hem slayt‑seviyesinde bir modern yorum hem de belirli bir AutoShape’e bağlanmış bir modern yorum oluşturur. Ardından her yorumdan ilişkili şekli okur.

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

### **Yorumları Farklı Şekil Türlerine Bağlama**

[IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) arayüzünü uygulayan herhangi bir slayt nesnesi şekil bağlantısı olarak kullanılabilir. Yaygın örnekler arasında [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iconnector/) ve grafik nesne örnekleri (örneğin grafikler) bulunur.

Aşağıdaki örnek, birkaç yaygın şekil türü oluşturur ve her birine bir modern yorum ilişkilendirir.

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

### **Yorumu Metne Bağlama ve Durumunu Ayarlama**

[IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) ile ilişkilendirilmiş bir modern yorum için, [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--) ve [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) metotları, şeklin metin çerçevesindeki seçili metnin başlangıç konumuna erişir. [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) ve [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) metotları ise seçimin uzunluğunu alır. Bu değerler, yorumu AutoShape içindeki belirli bir metin aralığıyla ilişkilendirir.

[IModernComment.getStatus](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imoderncomment/#getStatus--) ve [IModernComment.setStatus](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte--) metodları, [ModernCommentStatus](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/moderncommentstatus/) sabitlerinden bir değere erişir:

- `NotDefined` — özel bir modern‑yorum durumu tanımlanmamıştır.
- `Active` — yorum aktiftir.
- `Resolved` — yorum çözülmüştür.
- `Closed` — yorum kapatılmıştır.

Aşağıdaki örnek, şekle bağlanmış bir modern yorum oluşturur, metin seçimiyle ilişkilendirir, çözüldü olarak işaretler, sunumu kaydeder ve dosya yeniden açıldıktan sonra değerleri doğrular.

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

### **Mevcut Modern Yorumları İnceleme**

Mevcut bir sunumu incelemek için, hangi yorumların [IModernComment](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imoderncomment/) uyguladığını kontrol edin, ardından [IModernComment.getShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) ve [IModernComment.getStatus](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imoderncomment/#getStatus--) özelliklerine bakın. `null` bir şekil, slayt‑seviyesinde bir yorum olduğunu gösterir. Bir [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) bağlamı için metin‑seçim metodları, şeklin metin çerçevesindeki ilgili aralığı belirler.

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

## **Yorumları Kaldırma**

### **Tüm Yorumları ve Yorum Yazarlarını Kaldırma**

Aşağıdaki örnek, bir sunumdan tüm yorumları ve yorum yazarlarını nasıl kaldıracağınızı gösterir:

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

### **Belirli Yorumları Kaldırma**

Aşağıdaki örnek, bir slayttan belirli yorumları nasıl kaldıracağınızı gösterir:

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

## **SSS**

**Aspose.Slides modern yorumlar için çözülmüş (resolved) durumunu destekliyor mu?**

Evet. [IModernComment.getStatus](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imoderncomment/#getStatus--) ve [IModernComment.setStatus](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) bir [ModernCommentStatus](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/moderncommentstatus/) değerine, `Resolved` dahil, erişir. Durum sunumda depolanır ve dosya yeniden açıldıktan sonra tekrar okunabilir.

**İleti zincirleri (reply chains) destekleniyor mu ve bir derinlik sınırı var mı?**

Evet. Her yorum, [parent comment](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icomment/#getParentComment--) referansı aracılığıyla bir üst yoruma bağlanabilir; bu da yanıt zincirlerini mümkün kılar. API, belirli bir iç içe geçme derinliği sınırı tanımlamaz.

**Yorum işaretleyicisinin slayt üzerindeki konumu hangi koordinat sistemine göre tanımlanır?**

İşaretleyici konumu, slayt koordinat sistemindeki kayan nokta koordinatlarıyla tanımlanır; böylece işaretleyiciyi slayt üzerinde hassas bir şekilde konumlandırabilirsiniz.