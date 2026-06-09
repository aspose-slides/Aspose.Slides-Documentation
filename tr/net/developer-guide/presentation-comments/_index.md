---
title: .NET'te Sunum Yorumlarını Yönet
linktitle: Sunum Yorumları
type: docs
weight: 100
url: /tr/net/presentation-comments/
keywords:
- yorum
- modern yorum
- PowerPoint yorumları
- sunum yorumları
- slayt yorumları
- yorum ekle
- yoruma eriş
- yorum düzenle
- yorum yanıtla
- yorum kaldır
- yorum sil
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile sunum yorumlarını ustalıkla yönetin: PowerPoint dosyalarında yorumları hızlı ve kolay bir şekilde ekleyin, okuyun, düzenleyin ve silin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta sunum yorumlarını nasıl yöneteceğinizi açıklar. Yorumlarla ilgili ana tipleri gösterir ve slaytlara yorum ekleme, mevcut yorumlara erişme, yanıtlarla çalışma, modern yorumları kullanma ve bir sunumdan yorumları kaldırma konularını gösterir.

Örnekler, PowerPoint'teki yaygın inceleme ve iş birliği senaryolarına odaklanır; örneğin yorumları yazarlara atama, yorum içeriğini ve meta verileri okuma, yanıt zincirleri oluşturma ve tüm yorumları temizleme veya seçilenleri silme.

PowerPoint'te bir yorum, bir slaytta not ya da ek açıklama olarak görünür. Yorum tıklandığında içeriği veya mesajları görüntülenir.  

## **Sunumlara Neden Yorum Eklenir?**

Sunumları incelerken geri bildirim sağlamak veya çalışma arkadaşlarınızla iletişim kurmak için yorumları kullanmak isteyebilirsiniz.

PowerPoint sunumlarında yorumları kullanabilmeniz için Aspose.Slides for .NET şunları sağlar

* The [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfı, yazar koleksiyonlarını ( [CommentAuthorCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/icommentauthorcollection/properties/index) özelliğinden) içerir. Yazarlar slaytlara yorum ekler. 
* The  [ICommentCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/icommentcollection) arayüzü, bireysel yazarlar için yorum koleksiyonunu içerir. 
* The  [IComment](https://reference.aspose.com/slides/tr/net/aspose.slides/icomment) sınıfı, yazarlar ve yorumları hakkında bilgi içerir: yorumu kimin eklediği, yorumun eklenme zamanı, yorumun konumu vb. 
* The [CommentAuthor](https://reference.aspose.com/slides/tr/net/aspose.slides/commentauthor) sınıfı, bireysel yazarlar hakkında bilgi içerir: yazarın adı, baş harfleri, yazar adına bağlı yorumlar vb.  

## **Slayt Yorumları Ekle**

Bu C# kodu, PowerPoint sunumundaki bir slayta nasıl yorum ekleyeceğinizi gösterir:

```c#
// Presentation sınıfının bir örneğini oluşturur
using (Presentation presentation = new Presentation())
{
    // Boş bir slayt ekler
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // Yazar ekler
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // Yorumların konumunu ayarlar
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // Yazar için slayt 1'de bir slayt yorumu ekler
    author.Comments.AddComment("Hello Jawad, this is slide comment", presentation.Slides[0], point, DateTime.Now);

    // Yazar için slayt 2'de bir slayt yorumu ekler
    author.Comments.AddComment("Hello Jawad, this is second slide comment", presentation.Slides[1], point, DateTime.Now);

    // ISlide 1'e erişir
    ISlide slide = presentation.Slides[0];

    // Argüman olarak null geçirildiğinde, tüm yazarların yorumları seçili slayta getirilir
    IComment[] Comments = slide.GetSlideComments(author);

    // Slayt 1 için indeks 0'daki yoruma erişir
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // Yazarın indeks 0'daki yorum koleksiyonunu seçer
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```

## **Slayt Yorumlarına Erişim**

Bu C# kodu, PowerPoint sunumundaki bir slaytta var olan bir yoruma nasıl erişeceğinizi gösterir:

```c#
// Presentation sınıfının bir örneğini oluşturur
using (Presentation presentation = new Presentation("Comments1.pptx"))
{
    foreach (var commentAuthor in presentation.CommentAuthors)
    {
        var author = (CommentAuthor) commentAuthor;
        foreach (var comment1 in author.Comments)
        {
            var comment = (Comment) comment1;
            Console.WriteLine("ISlide :" + comment.Slide.SlideNumber + " has comment: " + comment.Text + " with Author: " + comment.Author.Name + " posted on time :" + comment.CreatedTime + "\n");
        }
    }
}
```


## **Yorumlara Yanıt Verme**

Üst yorum, yorumlar veya yanıtlar hiyerarşisindeki en üst ya da orijinal yorumdur. [ParentComment](https://reference.aspose.com/slides/tr/net/aspose.slides/icomment/properties/parentcomment) özelliğini ([IComment](https://reference.aspose.com/slides/tr/net/aspose.slides/icomment) arayüzünden) kullanarak bir üst yorumu ayarlayabilir veya alabilirsiniz. 

Bu C# kodu, yorum eklemeyi ve onlara yanıt almayı gösterir:

```c#
using (Presentation pres = new Presentation())
{
    // Bir yorum ekler
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("comment1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // comment1'e bir yanıt ekler
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("reply 1 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // comment1'e bir başka yanıt ekler
    IComment reply2 = author2.Comments.AddComment("reply 2 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // Mevcut yanıta bir yanıt ekler
    IComment subReply = author1.Comments.AddComment("subreply 3 for reply 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("comment 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("reply 4 for comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // Yorum hiyerarşisini konsolda görüntüler
    ISlide slide = pres.Slides[0];
    var comments = slide.GetSlideComments(null);
    for (int i = 0; i < comments.Length; i++)
    {
        IComment comment = comments[i];
        while (comment.ParentComment != null)
        {
            Console.Write("\t");
            comment = comment.ParentComment;
        }

        Console.Write("{0} : {1}", comments[i].Author.Name, comments[i].Text);
        Console.WriteLine();
    }

    pres.Save("parent_comment.pptx",SaveFormat.Pptx);

    // comment1'i ve ona ait tüm yanıtları kaldırır
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" title="Attention" %}} 

* [Remove](https://reference.aspose.com/slides/tr/net/aspose.slides/icomment/methods/remove) metodu ([IComment](https://reference.aspose.com/slides/tr/net/aspose.slides/icomment) arayüzünden) bir yorumu silmek için kullanıldığında, yorumun yanıtları da silinir. 
* [ParentComment](https://reference.aspose.com/slides/tr/net/aspose.slides/icomment/properties/parentcomment) ayarı bir döngü referansı oluşturursa, [PptxEditException](https://reference.aspose.com/slides/tr/net/aspose.slides/pptxeditexception) fırlatılır.

{{% /alert %}}

## **Modern Yorumlar Ekle**

2021'de Microsoft, PowerPoint'te *modern yorumlar* özelliğini tanıttı. Modern yorumlar, PowerPoint'te iş birliğini önemli ölçüde iyileştirir. Modern yorumlar sayesinde PowerPoint kullanıcıları yorumları çözümlenebilir, yorumları nesnelere ve metinlere sabitleyebilir ve etkileşimlere çok daha kolay katılabilir. 

[Aspose Slides for .NET 21.11](https://docs.aspose.com/slides/tr/net/aspose-slides-for-net-21-11-release-notes/)’de, [ModernComment](https://reference.aspose.com/slides/tr/net/aspose.slides/moderncomment) sınıfını ekleyerek modern yorum desteği uyguladık. [AddModernComment](https://reference.aspose.com/slides/tr/net/aspose.slides/commentcollection/methods/addmoderncomment) ve [InsertModernComment](https://reference.aspose.com/slides/tr/net/aspose.slides/commentcollection/methods/insertmoderncomment) metodları [CommentCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/commentcollection) sınıfına eklendi. 

Bu C# kodu, PowerPoint sunumundaki bir slayta modern bir yorum nasıl eklenir gösterir: 

```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Some Author", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("This is a modern comment", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Yorumları Kaldır**

### **Tüm Yorumları ve Yazarları Sil**

Bu C# kodu, bir sunumdaki tüm yorumları ve yazarları nasıl kaldıracağınızı gösterir:

```c#
using (var presentation = new Presentation("example.pptx"))
{
    // Sunumdaki tüm yorumları siler
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // Tüm yazarları siler
    presentation.CommentAuthors.Clear();

    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

### **Belirli Yorumları Sil**

Bu C# kodu, bir slayttaki belirli yorumları nasıl sileceğinizi gösterir:

```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // yorum ekle...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Author", "A");
    author.Comments.AddComment("comment 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("comment 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // "comment 1" metnini içeren tüm yorumları kaldır
    foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)
    {
        List<IComment> toRemove = new List<IComment>();
        foreach (IComment comment in slide.GetSlideComments(commentAuthor))
        {
            if (comment.Text == "comment 1")
            {
                toRemove.Add(comment);
            }
        }
        
        foreach (IComment comment in toRemove)
        {
            commentAuthor.Comments.Remove(comment);
        }
    }
    
    presentation.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Aspose.Slides modern yorumlar için 'çözüldü' gibi bir durum destekliyor mu?**

Evet. [Modern comments](https://reference.aspose.com/slides/tr/net/aspose.slides/moderncomment/) bir [Status](https://reference.aspose.com/slides/tr/net/aspose.slides/moderncomment/status/) özelliği sunar; bir yorumun durumunu (örneğin, çözüldü olarak işaretleyebilirsiniz) okuyabilir ve ayarlayabilirsiniz ve bu durum dosyada kaydedilir ve PowerPoint tarafından tanınır.

**Havuzlu tartışmalar (yanıt zincirleri) destekleniyor mu ve bir iç içeleme sınırı var mı?**

Evet. Her yorum, kendi [parent comment](https://reference.aspose.com/slides/tr/net/aspose.slides/comment/parentcomment/) referansını tutabilir, bu da isteğe bağlı yanıt zincirlerini mümkün kılar. API belirli bir iç içeleme derinliği sınırı belirtmez.

**Bir slayttaki yorum işaretçisinin konumu hangi koordinat sisteminde tanımlanır?**

Konum, slaydın koordinat sisteminde kayan nokta bir nokta olarak saklanır. Bu sayede yorum işaretçisini ihtiyacınız olan yere tam olarak yerleştirebilirsiniz.