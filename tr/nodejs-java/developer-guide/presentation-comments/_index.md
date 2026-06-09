---
title: JavaScript ile Sunum Yorumlarını Yönetme
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
- yoruma yanıtla
- yorumu kaldır
- yorumu sil
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile sunum yorumlarını yönetin: JavaScript kullanarak PowerPoint dosyalarında yorumları hızlı ve kolay bir şekilde ekleyin, okuyun, düzenleyin ve silin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde sunum yorumlarını nasıl yöneteceğinizi açıklar. Ana yorumla ilgili tipleri gösterir ve slaytlara yorum ekleme, mevcut yorumlara erişme, yanıtlarla çalışma, modern yorumları kullanma ve bir sunumdan yorumları kaldırma konularını gösterir.

Örnekler, PowerPoint'teki yaygın inceleme ve iş birliği senaryolarına odaklanır; örneğin yorumları yazarlara atama, yorum içeriğini ve meta verilerini okuma, yanıt zincirleri oluşturma ve tüm yorumları temizleme veya seçilenleri silme.

PowerPoint'te bir yorum, bir slaytta not ya da ek açıklama olarak görünür. Bir yorum tıklandığında, içeriği veya mesajları ortaya çıkar.

## **Sunumlara Neden Yorum Eklenir?**

Sunumları incelerken geri bildirim sağlamak veya çalışma arkadaşlarınızla iletişim kurmak için yorumları kullanmak isteyebilirsiniz.

PowerPoint sunumlarında yorumları kullanabilmeniz için Aspose.Slides for Node.js via Java şunları sağlar

* The [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfı, yazar koleksiyonlarını ([CommentAuthorCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/CommentAuthorCollection) sınıfından) içerir. Yazarlar slaytlara yorum ekler.
* The  [CommentCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/CommentCollection) sınıfı, bireysel yazarlar için yorum koleksiyonunu içerir.
* The  [Comment](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Comment) sınıfı, yazarlar ve yorumlarıyla ilgili bilgileri içerir: yorumu kim eklemiş, yorum ne zaman eklenmiş, yorumun konumu vb.
* The [CommentAuthor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/CommentAuthor) sınıfı, bireysel yazarlar hakkında bilgi içerir: yazarın adı, baş harfleri, yazarın adıyla ilişkilendirilmiş yorumlar vb.

## **Slayta Yorum Ekle**
Bu JavaScript kodu, bir PowerPoint sunumundaki bir slayta yorum nasıl ekleyeceğinizi gösterir:

```javascript
// Presentation sınıfını örnekler
var pres = new aspose.slides.Presentation();
try {
    // Boş bir slayt ekler
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    // Bir yazar ekler
    var author = pres.getCommentAuthors().addAuthor("Jawad", "MF");
    // Yorumların konumunu ayarlar
    var point = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    // Yazar için slayt 1'de slayt yorumu ekler
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, java.newInstanceSync("java.util.Date"));
    // Yazar için slayt 2'de slayt yorumu ekler
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, java.newInstanceSync("java.util.Date"));
    // ISlide 1'e erişir
    var slide = pres.getSlides().get_Item(0);
    // Argüman olarak null verildiğinde, tüm yazarların yorumları seçili slayta getirilir
    var Comments = slide.getSlideComments(author);
    // Slayt 1 için indeks 0'daki yoruma erişir
    var str = Comments[0].getText();
    pres.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
    if (Comments.length > 0) {
        // Yazarın yorum koleksiyonunu indeks 0'da seçer
        var commentCollection = Comments[0].getAuthor().getComments();
        var Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Slayt Yorumlarına Erişim**
Bu JavaScript kodu, bir PowerPoint sunumundaki bir slaytta mevcut bir yoruma nasıl erişeceğinizi gösterir:

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

## **Yorumlara Yanıt Verme**
Üst yorum, yorumlar veya yanıtlar hiyerarşisindeki en üst ya da orijinal yorumdur. [getParentComment](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Comment#getParentComment--) veya [setParentComment](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) yöntemlerini ([Comment](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Comment) sınıfından) kullanarak bir üst yorum ayarlayabilir veya alabilirsiniz.

Bu JavaScript kodu, yorum eklemeyi ve onlara yanıt almayı nasıl yapacağınızı gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Bir yorum ekler
    var author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    var comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    // comment1 için bir yanıt ekler
    var author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    var reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply1.setParentComment(comment1);
    // comment1'e başka bir yanıt ekler
    var reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply2.setParentComment(comment1);
    // Mevcut bir yanıt için yanıt ekle
    var subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    subReply.setParentComment(reply2);
    var comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply3.setParentComment(comment3);
    // Yorum hiyerarşisini konsolda gösterir
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
    // comment1'i ve ona verilen tüm yanıtları kaldırır
    comment1.remove();
    pres.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" title="Attention" %}} 
* [Remove](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Comment#remove--) yöntemi ([Comment](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Comment) sınıfından) bir yorumu silmek için kullanıldığında, yorumun yanıtları da silinir.
* [setParentComment](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) ayarı döngüsel bir referansa yol açarsa, [PptxEditException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PptxEditException) fırlatılır.
{{% /alert %}}

## **Modern Yorum Ekle**

2021 yılında Microsoft, PowerPoint'te *modern yorumlar*ı tanıttı. Modern yorumlar özelliği PowerPoint'te iş birliğini önemli ölçüde iyileştirir. Modern yorumlar sayesinde PowerPoint kullanıcıları yorumları çözümleyebilir, yorumları nesnelere ve metinlere sabitleyebilir ve etkileşimlere çok daha kolay katılabilir.

Aspose.Slides, modern yorumları [ModernComment](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ModernComment) sınıfı ile destekler. [addModernComment](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) ve [insertModernComment](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) yöntemleri [CommentCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/CommentCollection) sınıfına eklendi.

Bu JavaScript kodu, bir PowerPoint sunumundaki bir slayta modern yorum nasıl ekleyeceğinizi gösterir:

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

## **Yorumu Kaldır**

### **Tüm Yorumları ve Yazarları Sil**

Bu JavaScript kodu, bir sunumdaki tüm yorumları ve yazarları nasıl kaldıracağınızı gösterir:

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // Sunumdan tüm yorumları siler
    for (let i = 0; i < presentation.getCommentAuthors().size(); i++) {
    var author = presentation.getCommentAuthors().get_Item(i)
        author.getComments().clear();
    }
    // Tüm yazarları siler
    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **Belirli Yorumları Sil**

Bu JavaScript kodu, bir slaytta belirli yorumları nasıl sileceğinizi gösterir:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // yorum ekle...
    var author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.2), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    author.getComments().addComment("comment 2", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.3), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    // \"comment 1\" metnini içeren tüm yorumları kaldır
    
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

**Aspose.Slides modern yorumlar için 'çözülmüş' gibi bir durumu destekliyor mu?**

Evet. [Modern comments](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/) bir [getStatus](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/getstatus/) ve [setStatus](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncomment/setStatus/) metodları sunar; bir [yorumun durumunu](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/moderncommentstatus/) (örneğin, çözülmüş olarak işaretleyebilirsiniz) okuyabilir ve ayarlayabilirsiniz ve bu durum dosyada kaydedilir ve PowerPoint tarafından tanınır.

**İplikli tartışmalar (yanıt zincirleri) destekleniyor mu ve bir iç içeleme sınırı var mı?**

Evet. Her yorum, [üst yorum](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/comment/getparentcomment/) referansını alabilir, bu da keyfi yanıt zincirlerini mümkün kılar. API, belirli bir iç içeleme derinlik sınırı belirtmez.

**Bir slayttaki yorum işaretçisinin konumu hangi koordinat sisteminde tanımlanır?**

Konum, slaydın koordinat sisteminde kayan nokta bir nokta olarak saklanır. Bu, yorum işaretçisini tam olarak ihtiyaç duyduğunuz yere yerleştirmenizi sağlar.