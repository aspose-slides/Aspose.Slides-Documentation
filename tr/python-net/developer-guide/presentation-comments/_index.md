---
title: Python ile Sunum Yorumlarını Yönetme
linktitle: Sunum Yorumları
type: docs
weight: 100
url: /tr/python-net/presentation-comments/
keywords:
- yorum
- modern yorum
- PowerPoint yorumları
- sunum yorumları
- slayt yorumları
- yorum ekle
- yoruma eriş
- yorum düzenle
- yorum yanıtı
- yorum kaldır
- yorum sil
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile sunum yorumlarını ustaca yönetin: PowerPoint dosyalarında yorumları hızlı ve kolay bir şekilde ekleyin, okuyun, düzenleyin ve silin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta sunum yorumlarını nasıl yöneteceğinizi açıklar. Ana yorumla ilgili türleri gösterir ve slaytlara yorum ekleme, mevcut yorumlara erişme, yanıtlarla çalışma, modern yorumları kullanma ve bir sunumdan yorumları kaldırma konularını gösterir.

Örnekler, PowerPoint'te yaygın inceleme ve iş birliği senaryolarına odaklanır; örneğin yorumları yazarlara atama, yorum içeriği ve meta verileri okuma, yanıt zincirleri oluşturma ve tüm yorumları temizleme ya da seçilenleri silme.

PowerPoint'te bir yorum, slaytta bir not veya açıklama olarak görünür. Bir yorum tıklandığında, içeriği veya mesajları ortaya çıkar.

## **Sunumlara Neden Yorum Eklenir?**

Sunumları incelerken geri bildirim sağlamak veya iş arkadaşlarınızla iletişim kurmak için yorumları kullanmak isteyebilirsiniz.

PowerPoint sunumlarında yorumları kullanmanıza olanak tanımak için Aspose.Slides for Python via .NET şunları sağlar:

* [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfı, yazar koleksiyonlarını ([CommentAuthorCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/commentauthorcollection/) özelliğinden) içerir. Yazarlar slaytlara yorum ekler.
* [CommentCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/commentcollection/) sınıfı, bireysel yazarlar için yorum koleksiyonunu içerir.
* [Comment](https://reference.aspose.com/slides/tr/python-net/aspose.slides/comment/) sınıfı, yazarlar ve yorumları hakkında bilgi içerir: yorumu kim ekledi, yorumun eklenme zamanı, yorumun konumu vb.
* [CommentAuthor](https://reference.aspose.com/slides/tr/python-net/aspose.slides/commentauthor/) sınıfı, bireysel yazarlar hakkında bilgi içerir: yazarın adı, baş harfleri, yazarın adıyla ilişkili yorumlar vb.

## **Slayt Yorumunu Ekle**

Bu Python kodu, PowerPoint sunumunda bir slayta nasıl yorum ekleneceğini gösterir:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# Presentation sınıfını örnekler
with slides.Presentation() as presentation:
    # Boş bir slayt ekler
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # Bir yazar ekler
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # Yorumların konumunu ayarlar
    point = draw.PointF(0.2, 0.2)

    # Yazar için slayt 1'de slayt yorumu ekler
    author.comments.add_comment("Hello Jawad, this is slide comment", presentation.slides[0], point, datetime.date.today())

    # Yazar için slayt 2'de slayt yorumu ekler
    author.comments.add_comment("Hello Jawad, this is second slide comment", presentation.slides[1], point, datetime.date.today())

    # ISlide 1'e erişim
    slide = presentation.slides[0]

    # Argüman olarak null geçirildiğinde, tüm yazarların yorumları seçili slayta getirilir
    comments = slide.get_slide_comments(author)

    # Slayt 1 için indeks 0'daki yoruma erişir
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # Yazarın yorum koleksiyonunu indeks 0'da seçer
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```

## **Slayt Yorumlarına Erişme**

Bu Python kodu, PowerPoint sunumunda bir slaytta mevcut bir yoruma nasıl erişileceğini gösterir:

```python
import aspose.slides as slides

# Presentation sınıfını örnekler
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " has comment: " + comment.text + 
            " with Author: " + comment.author.name + 
            " posted on time :" + str(comment.created_time) + "\n")
```

## **Yorum Yanıtları**

Üst yorum, bir yorum hiyerarşisindeki en üst veya orijinal yorumdur. [Comment](https://reference.aspose.com/slides/tr/python-net/aspose.slides/comment/) sınıfının `parent_comment` özelliğini kullanarak bir üst yorum ayarlayabilir veya alabilirsiniz.

Bu Python kodu, yorum ekleme ve yanıtlarını alma konularını gösterir:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # Bir yorum ekler
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # comment1'e bir yanıt ekler
    author2 = pres.comment_authors.add_author("Autror_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # comment1'e başka bir yanıt ekler
    reply2 = author2.comments.add_comment("reply 2 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # Mevcut bir yanıta yanıt ekler
    subReply = author1.comments.add_comment("subreply 3 for reply 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("comment 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("reply 4 for comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # Yorum hiyerarşisini konsolda görüntüler
    slide = pres.slides[0]
    comments = slide.get_slide_comments(None)
    for i in range(comments.length):
        comment = comments[i]
        while comment.parent_comment is not None:
            print("\t")
            comment = comment.parent_comment

        print(comments[i].author.name + " : " + comments[i].text)
        print("\r\n")

    pres.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    # comment1'i ve ona bağlı tüm yanıtları kaldırır
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Attention" %}} 
* `remove` yöntemi ([Comment](https://reference.aspose.com/slides/tr/python-net/aspose.slides/comment/) sınıfından) bir yorumu silmek için kullanıldığında, yorumun yanıtları da silinir.
* `parent_comment` ayarı döngüsel bir referansa yol açarsa, `PptxEditException` fırlatılır.
{{% /alert %}}

## **Modern Yorum Ekle**

2021'de Microsoft, PowerPoint'te *modern yorumlar* özelliğini tanıttı. Modern yorumlar, PowerPoint'te iş birliğini büyük ölçüde geliştirir. Modern yorumlar sayesinde PowerPoint kullanıcıları yorumları çözümleyebilir, yorumları nesnelere ve metinlere sabitleyebilir ve etkileşimde çok daha kolay bulunabilir.

Modern yorumlar desteğini, [ModernComment](https://reference.aspose.com/slides/tr/python-net/aspose.slides/moderncomment/) sınıfını ekleyerek sağladık. `add_modern_comment` ve `insert_modern_comment` yöntemleri, [CommentCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/commentcollection/) sınıfına eklendi.

Bu Python kodu, PowerPoint sunumunda bir slayta modern yorum nasıl eklenir gösterir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Some Author", "SA")
    modernComment = newAuthor.comments.add_modern_comment("This is a modern comment", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **Yorumu Kaldır**

### **Tüm Yorumları ve Yazarları Sil**

Bu Python kodu, bir sunumda tüm yorumları ve yazarları nasıl kaldıracağınızı gösterir:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # Sunumdan tüm yorumları siler
    for author in presentation.comment_authors:
        author.comments.clear()

    # Tüm yazarları siler
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Belirli Yorumları Sil**

Bu Python kodu, bir slayttaki belirli yorumları nasıl sileceğinizi gösterir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # yorum ekle...
    author = presentation.comment_authors.add_author("Author", "A")
    author.comments.add_comment("comment 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("comment 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # \"comment 1\" metnini içeren tüm yorumları kaldır
    for commentAuthor in presentation.comment_authors:
        toRemove = []
        for comment in slide.get_slide_comments(commentAuthor):
            if comment.text == "comment 1":
                toRemove.append(comment)
        
        for comment in toRemove:
            commentAuthor.comments.remove(comment)
    
    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Aspose.Slides modern yorumlar için 'çözülmüş' gibi bir durum desteği sağlıyor mu?**

Evet. [Modern comments](https://reference.aspose.com/slides/tr/python-net/aspose.slides/moderncomment/) bir [status](https://reference.aspose.com/slides/tr/python-net/aspose.slides/moderncomment/status/) özelliği sunar; bir [yorumun durumunu](https://reference.aspose.com/slides/tr/python-net/aspose.slides/moderncommentstatus/) okuyabilir ve ayarlayabilirsiniz (örneğin, çözülmüş olarak işaretleyebilirsiniz) ve bu durum dosyada kaydedilir ve PowerPoint tarafından tanınır.

**İş parçacıklı tartışmalar (yanıt zincirleri) destekleniyor mu ve bir iç içe limit var mı?**

Evet. Her yorum, kendi [parent comment](https://reference.aspose.com/slides/tr/python-net/aspose.slides/moderncomment/parent_comment/) özelliğiyle bir üst yorumu referans alabilir; bu sayede isteğe bağlı yanıt zincirleri oluşturulabilir. API belirli bir iç içe derinlik limitini belirtmez.

**Bir slayttaki yorum işaretleyicisinin konumu hangi koordinat sisteminde tanımlanır?**

Konum, slaydın koordinat sisteminde kayan nokta olarak saklanır. Bu, yorum işaretleyicisini tam olarak istediğiniz konuma yerleştirmenizi sağlar.