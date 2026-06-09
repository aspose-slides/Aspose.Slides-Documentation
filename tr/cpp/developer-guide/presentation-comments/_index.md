---
title: C++'ta Sunum Yorumlarını Yönetme
linktitle: Sunum Yorumları
type: docs
weight: 100
url: /tr/cpp/presentation-comments/
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
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile sunum yorumlarını yönetin: PowerPoint dosyalarında yorumları hızlı ve kolay bir şekilde ekleyin, okuyun, düzenleyin ve silin."
---
## **Genel Bakış**

Bu makale Aspose.Slides içinde sunum yorumlarını nasıl yöneteceğinizi açıklar. Ana yorumla ilgili türleri gösterir ve slaytlara yorum ekleme, mevcut yorumlara erişme, yanıtlarla çalışma, modern yorumları kullanma ve bir sunumdan yorumları kaldırma konularını demonstrasyonla gösterir.

Örnekler, PowerPoint’te yaygın inceleme ve iş birliği senaryolarına odaklanır; yazarlarla yorumları ilişkilendirme, yorum içeriği ve meta verilerini okuma, yanıt zincirleri oluşturma ve tüm yorumları temizleme veya seçilenleri silme gibi işlemler.

PowerPoint’te bir yorum, slayt üzerinde bir not ya da ek açıklama olarak görünür. Bir yorum tıklandığında içeriği veya mesajları ortaya çıkar.

### **Sunumlara Neden Yorum Eklenir?**

Sunumları incelerken geri bildirim sağlamak veya meslektaşlarınızla iletişim kurmak için yorumları kullanmak isteyebilirsiniz.

PowerPoint sunumlarında yorumları kullanabilmeniz için Aspose.Slides for C++ aşağıdakileri sağlar:

* The [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfı, yazar koleksiyonlarını ([get_CommentAuthors()](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d) yöntemi) içerir. Yazarlar slaytlara yorum ekler. 
* The [ICommentCollection](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_comment_collection) arayüzü, bireysel yazarlar için yorum koleksiyonunu içerir. 
* The [IComment](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_comment) sınıfı, yazarlar ve onların yorumları hakkında bilgi içerir: yorumu kim eklemiş, yorum ne zaman eklenmiş, yorumun konumu vb. 
* The [CommentAuthor](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.comment_author) sınıfı, bireysel yazarlar hakkında bilgi içerir: yazarın adı, baş harfleri, yazar adıyla ilişkili yorumlar vb. 

## **Bir Slayt Yorumunu Ekle**
Bu C++ kodu, PowerPoint sunumunda bir slayta yorum eklemenizi gösterir:

```cpp
// Presentation sınıfını örnekler
auto presentation = System::MakeObject<Presentation>();
// Boş bir slayt ekler
presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlides()->idx_get(0));

// Bir yazar ekler
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");

// Yorumların konumunu ayarlar
PointF point;
point.set_X(0.2f);
point.set_Y(0.2f);

// ISlide 1'e erişir
auto slide1 = presentation->get_Slides()->idx_get(0);
// ISlide 2'ye erişir
auto slide2 = presentation->get_Slides()->idx_get(1);

// Yazar için slayt 1'de slayt yorumu ekler
author->get_Comments()->AddComment(u"Hello Jawad, this is slide comment", slide1, point, DateTime::get_Now());

// Yazar için slayt 2'de slayt yorumu ekler
author->get_Comments()->AddComment(u"Hello Jawad, this is second slide comment", slide2, point, DateTime::get_Now());

// Argüman olarak null geçirildiğinde, tüm yazarların yorumları seçili slayta getirilir
auto comments = slide1->GetSlideComments(author);

// Slayt 1 için indeks 0'daki yoruma erişir
String str = comments[0]->get_Text();

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);

if (comments->GetLength(0) > 0)
{
    // Yazarın yorum koleksiyonunu indeks 0'da seçer
    auto commentCollection = comments[0]->get_Author()->get_Comments();
    String Comment = commentCollection->idx_get(0)->get_Text();
}
```

## **Slayt Yorumlarına Eriş**
Bu C++ kodu, PowerPoint sunumunda bir slaytta mevcut bir yoruma nasıl erişileceğini gösterir:

```cpp
// Presentation sınıfını örnekler
auto presentation = System::MakeObject<Presentation>(u"Comments1.pptx");

for (auto&& commentAuthor : presentation->get_CommentAuthors())
{
    auto author = System::ExplicitCast<CommentAuthor>(commentAuthor);
    for (auto&& comment1 : System::IterateOver(author->get_Comments()))
    {
        SmartPtr<Comment> comment = System::ExplicitCast<Comment>(comment1);
        Console::WriteLine(String(u"ISlide :")
                        + comment->get_Slide()->get_SlideNumber()
                        + u" has comment: " + comment->get_Text()
                        + u" with Author: " + comment->get_Author()->get_Name()
                        + u" posted on time :" + comment->get_CreatedTime() + u"\n");
    }
}
```

## **Yorumlara Yanıt Verme**
Bir üst yorum, yorum ve yanıt hiyerarşisindeki en üst ya da orijinal yorumdur. [ParentComment](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) özelliğini ([IComment](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_comment) arayüzünden) kullanarak bir üst yorum ayarlayabilir veya alabilirsiniz. 

Bu C++ kodu, yorum eklemeyi ve bunlara yanıt almayı gösterir:

```cpp
auto pres = System::MakeObject<Presentation>();

// ISlide 1'e erişir
auto slide1 = pres->get_Slides()->idx_get(0);

// Yorum ekler
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// comment1'e yanıt ekler
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Autror_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// comment1'e bir yanıt daha ekler
auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// Mevcut yanıtın üzerine bir yanıt ekler
auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"comment 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply3->set_ParentComment(comment3);

// Yorum hiyerarşisini konsolda gösterir
auto comments = slide1->GetSlideComments(nullptr);
for (int32_t i = 0; i < comments->get_Length(); i++)
{
    auto comment = comments[i];
    while (comment->get_ParentComment() != nullptr)
    {
        Console::Write(u"\t");
        comment = comment->get_ParentComment();
    }

    Console::Write(u"{0} : {1}", comments[i]->get_Author()->get_Name(), comments[i]->get_Text());
    Console::WriteLine();
}

pres->Save(u"parent_comment.pptx", SaveFormat::Pptx);

// comment1'i ve ona ait tüm yanıtları kaldırır
comment1->Remove();

pres->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Dikkat" %}} 

* [Remove](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_comment#a8bb818ae804d142195c4edcf9012cccb) yöntemi ([IComment](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_comment) arayüzünden) bir yorumu silmek için kullanıldığında, yorumun yanıtları da silinir. 
* [ParentComment](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) ayarı dairesel bir başvuru oluşturursa, [PptxEditException](https://reference.aspose.com/slides/tr/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) ortaya çıkar.

{{% /alert %}}

## **Modern Yorum Ekleme**

2021 yılında Microsoft, PowerPoint’te *modern yorumlar* özelliğini tanıttı. Modern yorumlar özelliği, PowerPoint’te iş birliğini önemli ölçüde geliştirir. Modern yorumlar sayesinde PowerPoint kullanıcıları yorumları çözümleyebilir, yorumları nesnelere ve metinlere sabitleyebilir ve etkileşimlerde çok daha kolay bir şekilde yer alabilir.

[Aspose Slides for C++ 21.11](https://docs.aspose.com/slides/tr/cpp/aspose-slides-for-cpp-21-11-release-notes/) sürümünde, [ModernComment](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.modern_comment) sınıfını ekleyerek modern yorum desteği ekledik. [AddModernComment](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.comment_collection#a3627fcb3b05cd639fd430bd8248fe66b) ve [InsertModernComment](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.comment_collection#ad11c3efb52f3c17f63238447dcc03c94) yöntemleri [CommentCollection](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.comment_collection) sınıfına eklendi.

Bu C++ kodu, PowerPoint sunumunda bir slayta modern yorum eklemenizi gösterir: 

```cpp
auto pres = System::MakeObject<Presentation>();
// ISlide 1'e erişir
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"Some Author", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"This is a modern comment", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Yorum Kaldırma**

### **Tüm Yorumları ve Yazarları Sil**

Bu C++ kodu, bir sunumdaki tüm yorumları ve yazarları nasıl kaldıracağınızı gösterir:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// Sunumdan tüm yorumları siler
for (auto author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}
        
// Tüm yazarları siler
presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

### **Belirli Yorumları Sil**

Bu C++ kodu, bir slayttaki belirli yorumları nasıl sileceğinizi gösterir:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
// yorum ekle...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
author->get_Comments()->AddComment(u"comment 1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"comment 2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
// \"comment 1\" metnini içeren tüm yorumları kaldır
for (auto commentAuthor : presentation->get_CommentAuthors())
{
    auto toRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IComment>>>();
    for (auto comment : slide->GetSlideComments(commentAuthor))
    {
        if (comment->get_Text() == u"comment 1")
        {
            toRemove->Add(comment);
        }
    }
    for (auto comment : toRemove)
    {
        commentAuthor->get_Comments()->Remove(comment);
    }
}
        
presentation->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **SSS**

**Aspose.Slides modern yorumlar için “çözülmüş” gibi bir durum desteği sağlıyor mu?**

Evet. [Modern comments](https://reference.aspose.com/slides/tr/cpp/aspose.slides/moderncomment/) bir [get_Status](https://reference.aspose.com/slides/tr/cpp/aspose.slides/moderncomment/get_status/) ve [set_Status](https://reference.aspose.com/slides/tr/cpp/aspose.slides/moderncomment/set_status/) yöntemi sunar; bir [yorumun durumunu](https://reference.aspose.com/slides/tr/cpp/aspose.slides/moderncommentstatus/) (örneğin çözülmüş olarak işaretleme) okuyabilir ve ayarlayabilirsiniz ve bu durum dosyada saklanır ve PowerPoint tarafından tanınır.

**Zincirleme tartışmalar (yanıt zincirleri) destekleniyor mu ve bir iç içeleme sınırı var mı?**

Evet. Her yorum, [parent comment](https://reference.aspose.com/slides/tr/cpp/aspose.slides/comment/set_parentcomment/) referansına sahip olabilir, bu da istendiği kadar uzun yanıt zincirleri oluşturulmasını sağlar. API, belirli bir iç içeleme derinliği sınırı tanımlamaz.

**Bir yorum işaretçisinin konumu slayt üzerinde hangi koordinat sisteminde tanımlanır?**

Konum, slaytın koordinat sisteminde kayan nokta bir nokta olarak saklanır. Bu, yorum işaretçisini tam olarak istediğiniz yere yerleştirmenizi sağlar.