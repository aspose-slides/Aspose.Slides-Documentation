---
title: "Android'de Sunum Yorumlarını Yönet"
linktitle: "Sunum Yorumları"
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
- yoruma yanıt
- yorumu kaldır
- yorumu sil
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile sunum yorumlarını ustaca yönetin: PowerPoint dosyalarında yorumları hızlı ve kolay bir şekilde ekleyin, okuyun, düzenleyin ve silin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te sunum yorumlarını nasıl yöneteceğinizi açıklar. Ana yorumla ilgili türleri gösterir ve slaytlara yorum ekleme, mevcut yorumlara erişme, yanıtlarla çalışma, modern yorumları kullanma ve bir sunumdan yorumları kaldırma konularını gösterir.

Örnekler, PowerPoint'te yaygın inceleme ve iş birliği senaryolarına odaklanır; örneğin yorumları yazarlarla ilişkilendirme, yorum içeriğini ve meta verilerini okuma, yanıt zincirleri oluşturma ve tüm yorumları temizleme ya da seçilenleri silme.

PowerPoint'te bir yorum, bir slayt üzerindeki bir not ya da açıklama olarak görünür. Bir yoruma tıklandığında içeriği veya mesajları ortaya çıkar.

### **Sunumlara Neden Yorum Eklenir?**

Sunumları incelerken geri bildirim sağlamak veya meslektaşlarınızla iletişim kurmak için yorumları kullanmak isteyebilirsiniz.

PowerPoint sunumlarında yorumları kullanabilmeniz için Aspose.Slides for Android via Java şunları sunar:

* [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfı, yazar koleksiyonlarını ( [ICommentAuthorCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICommentAuthorCollection) arayüzünden ) içerir. Yazarlar slaytlara yorum ekler.
* [ICommentCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ICommentCollection) arayüzü, tek tek yazarlar için yorum koleksiyonunu içerir.
* [IComment](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IComment) sınıfı, yazarlar ve yorumları hakkında bilgi içerir: yorumu kim eklemiş, ne zaman eklenmiş, yorumun konumu vb.
* [CommentAuthor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/CommentAuthor) sınıfı, tek bir yazar hakkında bilgi içerir: yazarın adı, baş harfleri, yazarın adıyla ilişkilendirilen yorumlar vb.

## **Bir Slayt Yorumu Ekleyin**
Bu Java kodu, bir PowerPoint sunumundaki bir slayta nasıl yorum ekleyeceğinizi gösterir:

```java
// Presentation sınıfını örnekler
Presentation pres = new Presentation();
try {
    // Boş bir slayt ekler
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // Yazar ekler
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // Yorumların konumunu ayarlar
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // Yazar için slayt 1'de slayt yorumu ekler
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // Yazar için slayt 2'de slayt yorumu ekler
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // ISlide 1'e erişir
    ISlide slide = pres.getSlides().get_Item(0);

    // Argüman olarak null verildiğinde, tüm yazarların yorumları seçili slayta getirilir
    IComment[] Comments = slide.getSlideComments(author);

    // Slayt 1 için indeks 0'daki yoruma erişir
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // Yazarın indeks 0'ındaki yorum koleksiyonunu seçer
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Slayt Yorumlarına Erişin**
Bu Java kodu, bir PowerPoint sunumundaki bir slaytta mevcut bir yoruma nasıl erişeceğinizi gösterir:

```java
// Presentation sınıfını örnekler
Presentation pres = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor commentAuthor : pres.getCommentAuthors())
    {
        CommentAuthor author = (CommentAuthor) commentAuthor;
        for (IComment comment1 : author.getComments())
        {
            Comment comment = (Comment) comment1;
            System.out.println("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() +
                    " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Yorumlara Yanıt Verin**
Üst yorum, bir yorum zinciri veya yanıtlar hiyerarşisindeki en üst ya da orijinal yorumdur. [IComment](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IComment) arayüzündeki [getParentComment](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IComment#getParentComment--) veya [setParentComment](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) yöntemlerini kullanarak bir üst yorumu alabilir veya ayarlayabilirsiniz.

Bu Java kodu, yorum eklemeyi ve yanıtları almayı gösterir:

```java
Presentation pres = new Presentation();
try {
    // Bir yorum ekler
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // comment1'e bir yanıt ekler
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // comment1'e başka bir yanıt ekler
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // Mevcut bir yanıta yanıt ekle
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // Yorum hiyerarşisini konsolda gösterir
    ISlide slide = pres.getSlides().get_Item(0);
    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++)
    {
        IComment comment = comments[i];
        while (comment.getParentComment() != null)
        {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() +  " : " + comments[i].getText());
        System.out.println();
    }
    pres.save("parent_comment.pptx",SaveFormat.Pptx);

    // comment1'i ve ona ait tüm yanıtları kaldırır
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" title="Dikkat" %}} 
* [IComment](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IComment) arayüzündeki [Remove](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IComment#remove--) yöntemiyle bir yorum silindiğinde, yorumun yanıtları da silinir.
* [setParentComment](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) ayarı bir döngüsel referansa yol açarsa, [PptxEditException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/PptxEditException) fırlatılır.
{{% /alert %}}

## **Modern Bir Yorum Ekleyin**

2021 yılında Microsoft, PowerPoint'te *modern yorumlar* özelliğini tanıttı. Modern yorumlar, PowerPoint'te iş birliğini büyük ölçüde geliştirir. Modern yorumlar sayesinde PowerPoint kullanıcıları yorumları çözebilir, yorumları nesnelere ve metinlere bağlayabilir ve etkileşimleri çok daha kolay gerçekleştirebilir.

Aspose.Slides, [ModernComment](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ModernComment) sınıfı ile modern yorumları destekler. [CommentCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/CommentCollection) sınıfına eklenen [addModernComment](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) ve [insertModernComment](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) yöntemleri bulunur.

Bu Java kodu, bir PowerPoint sunumundaki bir slayta modern yorum eklemeyi gösterir:

```java
Presentation pres = new Presentation();
try {
    ICommentAuthor newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    IModernComment modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, new Point2D.Float(100, 100), new Date());

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir Yorumu Kaldırın**

### **Tüm Yorumları ve Yazarları Silin**

Bu Java kodu, bir sunumdaki tüm yorumları ve yazarları nasıl kaldıracağınızı gösterir:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    // Sunumdan tüm yorumları siler
    for (ICommentAuthor author : presentation.getCommentAuthors())
    {
        author.getComments().clear();
    }

    // Tüm yazarları siler
    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Belirli Yorumları Silin**

Bu Java kodu, bir slayttaki belirli yorumları nasıl sileceğinizi gösterir:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // yorum ekle...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // \"comment 1\" metnini içeren tüm yorumları kaldır
    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors())
    {
        ArrayList<IComment> toRemove = new ArrayList<IComment>();
        for (IComment comment : slide.getSlideComments(commentAuthor))
        {
            if (comment.getText().equals("comment 1"))
            {
                toRemove.add(comment);
            }
        }

        for (IComment comment : toRemove)
        {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **SSS**

**Aspose.Slides, modern yorumlar için 'çözüldü' gibi bir durum destekliyor mu?**

Evet. [Modern comments](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/moderncomment/) bir [setStatus](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/moderncomment/#setStatus-byte-) yöntemi sunar; yorumun durumunu (örneğin, çözüldü olarak işaretleme) yazabilir ve bu durum dosyada kaydedilir ve PowerPoint tarafından tanınır.

**İplikli tartışmalar (yanıt zincirleri) destekleniyor mu ve bir iç içeleme sınırı var mı?**

Evet. Her yorum, [üst yorum](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/comment/#getParentComment--)na referans verebilir, bu da isteğe bağlı yanıt zincirlerine izin verir. API belirli bir iç içeleme derinliği sınırı belirtmez.

**Bir yorum işaretçisinin slayt üzerindeki konumu hangi koordinat sisteminde tanımlanır?**

Konum, slaytın koordinat sisteminde kayan nokta bir nokta olarak depolanır. Bu, yorum işaretçisini tam olarak ihtiyaç duyduğunuz yere yerleştirmenizi sağlar.