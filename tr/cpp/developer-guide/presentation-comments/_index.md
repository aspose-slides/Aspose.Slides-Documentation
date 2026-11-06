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
- yoruma yanıtla
- yorumu kaldır
- yorumu sil
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile sunum yorumlarını yönetin: PowerPoint sunumlarında yorum ekleyin, okuyun, düzenleyin, yanıtlayın ve kaldırın, hızlı ve kolay bir şekilde."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for C++ ile sunum yorumlarını nasıl yöneteceğinizi açıklar. Yorumlarla ilgili temel tipleri tanıtır ve slaytlara yorum ekleme, mevcut yorumlara erişme, yanıtlar ve modern yorumlarla çalışma ve bir sunumdan yorumları kaldırma konularını gösterir.

Örnekler, PowerPoint'teki yaygın inceleme ve işbirliği senaryolarını kapsar; yorumları yazarlara atama, yorum metnini ve meta verileri okuma, yanıt zincirleri oluşturma ve seçili yorumları ya da tüm yorumları kaldırma gibi.

PowerPoint'te yorumlar, slaytlarda açıklama şeklinde görünür. Bir yorumu seçmek, metnini ve ilgili tartışmayı gösterir.

Yorumların kendileri değiştirilmeden bir sunum açıldığında gösterilmesi veya gizlenmesi isteniyorsa, [Sunum Açılırken Yorumları Göster veya Gizle](/slides/tr/cpp/presentation-view-properties/) adresine bakın.

## **Neden Sunumlara Yorum Eklemelisiniz?**

Sunumları incelerken geri bildirim sağlamak ve iş arkadaşlarıyla işbirliği yapmak için yorumları kullanabilirsiniz.

* The [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfı, sunumun yorum yazarlarına erişim sağlar.
* The [ICommentCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/) arayüzü, belirli bir yazarla ilişkili yorumları temsil eder.
* The [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) arayüzü, bir yorum hakkında yazar, oluşturulma zamanı, konum ve metin dahil bilgi sağlar.
* The [CommentAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/commentauthor/) sınıfı, bir yazar hakkında ad, baş harfler ve ilişkili yorumlar dahil bilgi sağlar.

## **Slayt Yorumları Ekleme**

Örnek iki slayt oluşturur ve bir yorum yazarını [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/) ile kaydeder. Her slayta bir yorum yerleştirmek için [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) kullanır, ardından o yazar için ilk slaydın yorumlarını [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) ile alır. Konsol, ilk yorumun metnini iki kez gösterir; bu, slayt ve yazar üzerinden erişimi gösterir ve kaydedilen sunum her iki yorumu da içerir.

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto firstSlide = presentation->get_Slide(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlide(0));

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");
auto position = PointF(0.2f, 0.2f);
auto createdTime = DateTime::get_Now();

author->get_Comments()->AddComment(u"Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
author->get_Comments()->AddComment(u"Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

auto comments = firstSlide->GetSlideComments(author);
if (comments->get_Length() > 0)
{
    auto firstComment = comments[0];
    Console::WriteLine(firstComment->get_Text());

    auto commentText = firstComment->get_Author()->get_Comments()->idx_get(0)->get_Text();
    Console::WriteLine(commentText);
}

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);
```

## **Yorum Yazarını Bulma veya Oluşturma**

Otomatik bir inceleme aynı sunumu tekrar tekrar işlediğinde, bir yazar eklemeden önce [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/) tarafından döndürülen koleksiyonu arayın. [FindByNameAndInitials](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbynameandinitials/) hem adı hem de baş harfleri eşleştirir ve eşleşen yazarların bir dizisini döndürür; eşleşme yoksa boş bir dizi döner. Buna karşılık, [FindByName](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbyname/) yalnızca adı arar, baş harfleri göz ardı eder. Koleksiyonda zaten bulunan bir ad ve baş harflerle [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/) çağrısı bir istisna fırlatır.

Örnek, en az bir slayt içeren bir sunum dosyası gerektirir. İki turda da, ilk eşleşen yazarı yeniden kullanır veya sonuç boş olduğunda bir yazar oluşturur. Birden çok eşleşme olduğunda, diğer yazarları birleştirmeden veya kaldırmadan ilk dizi öğesini seçer. Ardından seçilen yazar için [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) çağırır ve sunumu kaydeder. İkinci tur, birinci turun çıktısını açar ve işlemi tekrarlar.

```cpp
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

const String authorName = u"Reviewer";
const String authorInitials = u"RV";

auto inputFile = String(u"input.pptx");
auto position = PointF(20.0f, 20.0f);

for (auto pass = 1; pass <= 2; pass++)
{
    auto presentation = MakeObject<Presentation>(inputFile);

    auto matches = presentation->get_CommentAuthors()->FindByNameAndInitials(authorName, authorInitials);

    auto author = matches->get_Length() > 0 ? matches[0] : presentation->get_CommentAuthors()->AddAuthor(authorName, authorInitials);
    author->get_Comments()->AddComment(u"Please review this slide.", presentation->get_Slide(0), position, DateTime::get_Now());

    auto outputFile = String::Format(u"review_pass_{0}.pptx", pass);
    presentation->Save(outputFile, SaveFormat::Pptx);
    inputFile = outputFile;
}
```

İkinci tur, başka bir yazar eklemeden veya mevcut yorumları kaldırmadan bir yorum daha ekler. Son dosya, `review_pass_2.pptx`, yeni yorumların yanı sıra orijinal yorumların da bulunduğu bir dosyadır. Bir yazarın yeniden kullanılması yorumları tekilleştirmez: aynı yorumun tekrar eklenmesini önlemek için eklemeden önce ayrı bir yinelenen algılama uygulayın.

## **Slayt Yorumlarına Erişim**

Örnek mevcut bir sunumu açar ve [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/) tarafından döndürülen koleksiyonu okur. Her yazar için, [get_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthor/get_comments/) tarafından döndürülen koleksiyonu döndürür ve slayt numarasını, yorum metnini, yazar adını ve oluşturulma zamanını yazdırır. Konsol çıktısı üretmek için girdi sunumunda yorumlar bulunmalıdır.

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Comments1.pptx");

for (auto&& author : presentation->get_CommentAuthors())
{
    for (auto&& comment : author->get_Comments())
    {
        Console::WriteLine(u"Slide: {0}", comment->get_Slide()->get_SlideNumber());
        Console::WriteLine(u"Comment: {0}", comment->get_Text());
        Console::WriteLine(u"Author: {0}", comment->get_Author()->get_Name());
        Console::WriteLine(u"Posted at: {0}", comment->get_CreatedTime());
        Console::WriteLine();
    }
}
```

## **Yorumlara Yanıt Verme**

Bir üst yorum, yanıt hiyerarşisinin en üstündeki orijinal yorumdur. [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) arayüzünün [get_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/get_parentcomment/) ve [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) yöntemleri, bir yorumun üstünü almanıza veya ayarlamanıza olanak tanır.

Örnek iki yazardan yorumlar oluşturur ve [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) kullanarak yanıtlar oluşturur; buna başka bir yanıtın yanıtı da dahildir. `nullptr` değerini [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) yöntemine geçirerek tüm yazarların yorumları alınır; konsol, her girişin yanıt hiyerarşisindeki derinliğine göre girinti yapar. Örnek tam tartışmayı kaydeder, ilk kök yorum üzerinde [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) çağırır ve bu yorum ve yanıtları kaldırılmış ikinci bir sunum kaydeder.

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto position = PointF(10.0f, 10.0f);
auto createdTime = DateTime::get_Now();

auto originalAuthor = presentation->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto rootComment = originalAuthor->get_Comments()->AddComment(u"comment 1", slide, position, createdTime);

auto reviewer = presentation->get_CommentAuthors()->AddAuthor(u"Author_2", u"B.B.");
auto firstReply = reviewer->get_Comments()->AddComment(u"reply 1 for comment 1", slide, position, createdTime);
firstReply->set_ParentComment(rootComment);

auto secondReply = reviewer->get_Comments()->AddComment(u"reply 2 for comment 1", slide, position, createdTime);
secondReply->set_ParentComment(rootComment);

auto subReply = originalAuthor->get_Comments()->AddComment(u"subreply 3 for reply 2", slide, position, createdTime);
subReply->set_ParentComment(secondReply);

reviewer->get_Comments()->AddComment(u"comment 2", slide, position, createdTime);
auto separateComment = reviewer->get_Comments()->AddComment(u"comment 3", slide, position, createdTime);

auto separateReply = originalAuthor->get_Comments()->AddComment(u"reply 4 for comment 3", slide, position, createdTime);
separateReply->set_ParentComment(separateComment);

auto comments = slide->GetSlideComments(nullptr);
for (auto i = 0; i < comments->get_Length(); i++)
{
    auto comment = comments[i];
    while (comment->get_ParentComment() != nullptr)
    {
        Console::Write(u"\t");
        comment = comment->get_ParentComment();
    }

    Console::WriteLine(u"{0}: {1}", comments[i]->get_Author()->get_Name(), comments[i]->get_Text());
}

presentation->Save(u"parent_comment.pptx", SaveFormat::Pptx);

rootComment->Remove();
presentation->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Warning" %}}
* [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) arayüzünün [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) yöntemi bir yorumu silmek için kullanıldığında, o yoruma ait tüm yanıtlar da silinir.
* [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) yöntemi dairesel bir referans oluşturursa, bir [PptxEditException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxeditexception/) fırlatılır.
{{% /alert %}}

## **Modern Yorumlar Ekleme**

Modern yorumlar slaytla, belirli bir şekille veya bir AutoShape içindeki bir metin aralığıyla ilişkilendirilebilir. [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) yöntemi, slayt ve yorum işaretleyici koordinatlarına ek olarak bir [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) argümanı alır.

`nullptr` şekil argümanı olarak verildiğinde yorum bir slayt düzeyinde yorum olur. İşaretleyici verilen koordinatlarla konumlanır, ancak belirli bir şekille ilişkilendirilmez; bu yüzden [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) `nullptr` döndürür. Bir [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) sağlandığında yorum o şekle bağlanır. Koordinatlar hâlâ yorum işaretleyicisinin slayttaki konumunu tanımlar, şekil ilişkilendirmesi ise [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) aracılığıyla alınabilir.

### **Modern Yorumu Bir Şekle Bağlama**

Örnek, [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) yöntemini iki kez çağırır: bir kez slayt düzeyinde yorum için `nullptr` şekil, bir kez de dikdörtgeni çapa olarak kullanır. [get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) çağrısı, slayt düzeyindeki yorumun null kontrolü için `True` ve bağlanmış yorum için `Revenue title` yazdırır. Her iki yorum da sunumla kaydedilir.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 300.0f, 80.0f);
shape->set_Name(u"Revenue title");
shape->get_TextFrame()->set_Text(u"Quarterly revenue");

auto createdTime = DateTime::get_Now();
auto slideCommentPosition = PointF(20.0f, 20.0f);
auto shapeCommentPosition = PointF(60.0f, 60.0f);
auto slideComment = author->get_Comments()->AddModernComment(u"Review the overall slide layout.", slide, nullptr, slideCommentPosition, createdTime);
auto shapeComment = author->get_Comments()->AddModernComment(u"Check this title.", slide, shape, shapeCommentPosition, createdTime);

Console::WriteLine(slideComment->get_Shape() == nullptr);
auto shapeAnchor = shapeComment->get_Shape();
if (shapeAnchor != nullptr)
{
    Console::WriteLine(shapeAnchor->get_Name());
}

presentation->Save(u"modern_comments.pptx", SaveFormat::Pptx);
```

### **Yorumları Farklı Şekil Türlerine Bağlama**

[IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) arayüzünü uygulayan herhangi bir slayt nesnesi şekil çapa olarak kullanılabilir. Yaygın örnekler arasında [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/cpp/aspose.slides/iconnector/) ve grafik nesneleri (örneğin grafikler) olarak [IGraphicalObject](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobject/) örnekleri bulunur.

Örnek, [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) kullanarak beş şekil türünden her biriyle bir yorum ilişkilendirir: bir AutoShape, bir resim çerçevesi, bir grup, bir bağlayıcı ve bir grafik. Resim gömülü görüntü verisi kullanır, bu nedenle dış görüntü gerekmez. Her yorumun kendi işaretleyici konumu vardır ve kaydedilen sunum beş şekil ilişkilendirmesini de tutar.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IConnector.h>
#include <DOM/IGroupShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/convert.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");
auto createdTime = DateTime::get_Now();

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 60.0f);
autoShape->get_TextFrame()->set_Text(u"AutoShape");

auto autoShapeCommentPosition = PointF(30.0f, 30.0f);
author->get_Comments()->AddModernComment(u"Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

auto imageBase64 = u"iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
auto imageData = Convert::FromBase64String(imageBase64);
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 120.0f, 80.0f, image);
auto pictureCommentPosition = PointF(230.0f, 30.0f);
author->get_Comments()->AddModernComment(u"Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

auto groupShape = slide->get_Shapes()->AddGroupShape();
groupShape->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0.0f, 0.0f, 80.0f, 40.0f);
groupShape->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 100.0f, 0.0f, 80.0f, 40.0f);
auto groupCommentPosition = PointF(40.0f, 150.0f);
author->get_Comments()->AddModernComment(u"Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

auto connector = slide->get_Shapes()->AddConnector(ShapeType::StraightConnector1, 220.0f, 150.0f, 140.0f, 40.0f);
auto connectorCommentPosition = PointF(240.0f, 150.0f);
author->get_Comments()->AddModernComment(u"Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 400.0f, 20.0f, 250.0f, 180.0f);
auto chartCommentPosition = PointF(420.0f, 40.0f);
author->get_Comments()->AddModernComment(u"Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

presentation->Save(u"modern_comment_shape_types.pptx", SaveFormat::Pptx);
```

### **Bir Yorumu Metne Bağlama ve Durumunu Ayarlama**

[IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ile ilişkili bir modern yorum için, [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/) ve [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/) şeklin metin çerçevesinde seçilen metnin başlangıç konumunu kontrol eder. Benzer şekilde, [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/) ve [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) seçimin uzunluğunu kontrol eder. Birlikte, bu yöntemler yorumu AutoShape içindeki belirli bir metin aralığıyla ilişkilendirir.

[IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) ve [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) yöntemleri, [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/) enumarasyonundan bir değer kullanır:
- `NotDefined` — belirli bir modern yorum durumu tanımlanmamıştır.
- `Active` — yorum aktiftir.
- `Resolved` — yorum çözülmüştür.
- `Closed` — yorum kapatılmıştır.

Örnek, bir dikdörtgenin metnindeki "quarterly revenue" kelimelerine bir modern yorum bağlar. Metinden sıfır tabanlı seçim başlangıcını hesaplar, bunu [set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/) metoduna geçirir ve seçili karakter sayısı ile [set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) metodunu çağırır. `Resolved` ile [set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) çağrıldıktan sonra sunumu kaydeder ve yeniden açar. Dört konsol kontrolü her biri `True` yazdırmalı, şekil çapasının, metin aralığının ve durumun korunduğunu onaylamalıdır.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ModernCommentStatus.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

const String outputFile = u"modern_comment_text_anchor.pptx";
const String shapeText = u"Review the quarterly revenue forecast.";
const String selectedText = u"quarterly revenue";
auto expectedSelectionStart = shapeText.IndexOf(selectedText);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 100.0f);
shape->set_Name(u"Forecast text");
shape->get_TextFrame()->set_Text(shapeText);

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");
auto commentPosition = PointF(60.0f, 60.0f);
auto comment = author->get_Comments()->AddModernComment(u"Verify this forecast wording.", slide, shape, commentPosition, DateTime::get_Now());
comment->set_TextSelectionStart(expectedSelectionStart);
comment->set_TextSelectionLength(selectedText.get_Length());
comment->set_Status(ModernCommentStatus::Resolved);

presentation->Save(outputFile, SaveFormat::Pptx);

auto reopenedPresentation = MakeObject<Presentation>(outputFile);
auto reopenedSlide = reopenedPresentation->get_Slide(0);
auto reopenedComments = reopenedSlide->GetSlideComments(nullptr);

for (auto&& reopenedComment : reopenedComments)
{
    auto modernComment = AsCast<IModernComment>(reopenedComment);
    if (modernComment == nullptr)
    {
        continue;
    }

    auto shapeAnchor = modernComment->get_Shape();
    auto shapeMatches = shapeAnchor != nullptr && shapeAnchor->get_Name() == u"Forecast text";
    auto selectionStartMatches = modernComment->get_TextSelectionStart() == expectedSelectionStart;
    auto selectionLengthMatches = modernComment->get_TextSelectionLength() == selectedText.get_Length();
    auto statusMatches = modernComment->get_Status() == ModernCommentStatus::Resolved;

    Console::WriteLine(u"Shape anchor preserved: {0}", shapeMatches);
    Console::WriteLine(u"Text selection start preserved: {0}", selectionStartMatches);
    Console::WriteLine(u"Text selection length preserved: {0}", selectionLengthMatches);
    Console::WriteLine(u"Resolved status preserved: {0}", statusMatches);
}
```

### **Mevcut Modern Yorumları İnceleme**

Örnek, modern yorumlar içeren mevcut bir sunum gerektirir ve bunların metnini, durumunu ve çapa detaylarını yazdırır. İncelemek için, hangi yorumların [IModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/) uyguladığını kontrol edin, ardından [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/), [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/), [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/) ve [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) yöntemlerini inceleyin. `nullptr` şekil bir slayt düzeyinde yorum olduğunu gösterir. Bir [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) çapa için, metin‑seçim yöntemleri şeklin metin çerçevesindeki ilgili aralığı belirler.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IComment.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ModernCommentStatus.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"comments.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto comments = slide->GetSlideComments(nullptr);
    for (auto&& comment : comments)
    {
        auto modernComment = AsCast<IModernComment>(comment);
        if (modernComment == nullptr)
        {
            continue;
        }

        Console::WriteLine(u"Slide: {0}", slide->get_SlideNumber());
        Console::WriteLine(u"Text: {0}", modernComment->get_Text());
        Console::WriteLine(u"Status: {0}", modernComment->get_Status());

        auto shape = modernComment->get_Shape();
        if (shape == nullptr)
        {
            Console::WriteLine(u"Anchor: slide level");
        }
        else
        {
            Console::WriteLine(u"Anchor shape: {0}", shape->get_Name());
            Console::WriteLine(u"Anchor type: {0}", shape->GetType().get_Name());

            auto autoShape = AsCast<IAutoShape>(shape);
            if (autoShape != nullptr)
            {
                Console::WriteLine(u"Text selection start: {0}", modernComment->get_TextSelectionStart());
                Console::WriteLine(u"Text selection length: {0}", modernComment->get_TextSelectionLength());
            }
        }

        Console::WriteLine();
    }
}
```

## **Yorumları Kaldırma**

Aspose.Slides for C++, bir sunumdan tüm yorumları ve yazarlarını kaldırmanıza ya da seçili yorumları geri kalanları koruyarak silmenize izin verir. Aşağıdaki örnekler her iki yaklaşımı gösterir ve güncellenmiş sunumu kaydeder.

### **Tüm Yorumları ve Yorum Yazarlarını Kaldırma**

Örnek mevcut bir sunumu açar ve her yazar için [ICommentCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/clear/) metodunu çağırır, ardından yazarları kendilerini kaldırmak için [ICommentAuthorCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/clear/) metodunu çağırır. Kaydedilen sunum ne yorum ne de yorum yazarları içerir. Kaldırmayı gözlemlemek için yorum içeren bir sunum kullanın.

```cpp
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"example.pptx");

for (auto&& author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}

presentation->get_CommentAuthors()->Clear();

presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

### **Belirli Yorumları Kaldırma**

Örnek bir slaytta iki yorum oluşturur ve [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) ile her yazarın yorumlarını bulur. [ICommentCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/remove/) çağrılmadan önce metni "comment 1" olan yorumları toplar; bu, seçim sırasında koleksiyonda değişiklik yapılmasını önler. Kaydedilen sunum yalnızca "comment 2" yorumunu tutar.

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/collections/list.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
auto createdTime = DateTime::get_Now();

auto firstCommentPosition = PointF(0.2f, 0.2f);
auto secondCommentPosition = PointF(0.3f, 0.2f);
author->get_Comments()->AddComment(u"comment 1", slide, firstCommentPosition, createdTime);
author->get_Comments()->AddComment(u"comment 2", slide, secondCommentPosition, createdTime);

for (auto&& commentAuthor : presentation->get_CommentAuthors())
{
    auto commentsToRemove = MakeObject<List<SharedPtr<IComment>>>();
    auto comments = slide->GetSlideComments(commentAuthor);

    for (auto&& comment : comments)
    {
        if (comment->get_Text() == u"comment 1")
        {
            commentsToRemove->Add(comment);
        }
    }

    for (auto&& comment : commentsToRemove)
    {
        commentAuthor->get_Comments()->Remove(comment);
    }
}

presentation->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Aspose.Slides modern yorumlar için çözülmüş (resolved) durumunu destekliyor mu?**

Evet. [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) ve [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) bir [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/) değeri kullanır, `Resolved` dahil. Durum sunumda depolanır ve dosya yeniden açıldığında tekrar okunabilir.

**İş parçacıklı tartışmalar (yanıt zincirleri) destekleniyor mu ve bir iç içeleme sınırı var mı?**

Evet. Her yorum, [parent comment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) referansını tutabilir; bu, yanıt zincirlerini etkinleştirir. API, belirli bir iç içeleme derinliği sınırı tanımlamaz.

**Bir slayttaki yorum işaretleyicisinin konumu hangi koordinat sisteminde tanımlanır?**

İşaretleyici konumu, slayt koordinat sistemindeki nokta‑kayan (floating‑point) koordinatlarla tanımlanır; bu, onu slayt üzerinde tam olarak yerleştirmenizi sağlar.