---
title: C++ ile Sunum Yorumlarını Yönetme
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

Bu makale, Aspose.Slides for C++ ile sunum yorumlarını nasıl yöneteceğinizi açıklar. Yorumlarla ilgili temel türleri tanıtır ve slaytlara yorum ekleme, mevcut yorumlara erişme, yanıtlar ve modern yorumlarla çalışma ve bir sunumdan yorumları kaldırma konularını gösterir.

Örnekler, PowerPoint'te yaygın inceleme ve iş birliği senaryolarını kapsar; örneğin, yorumları yazarlarla ilişkilendirme, yorum metni ve meta verileri okuma, yanıt zincirleri oluşturma ve seçili yorumları ya da tüm yorumları kaldırma.

PowerPoint'te yorumlar slaytlar üzerindeki açıklama işaretleri olarak görünür. Bir yorumu seçmek, metnini ve ilgili tartışmayı gösterir.

## **Sunumlara Neden Yorum Eklenir?**

Sunumları incelerken geri bildirim sağlamak ve ekip arkadaşlarınızla iş birliği yapmak için yorumları kullanabilirsiniz.

Aspose.Slides for C++ aşağıdaki API'leri sağlar:

* [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfı, sunumun yorum yazarlarına erişim sağlar.
* [ICommentCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icommentcollection/) arayüzü, belirli bir yazarla ilişkili yorumları temsil eder.
* [IComment](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icomment/) arayüzü, bir yorum hakkında yazar, oluşturulma zamanı, konum ve metin gibi bilgileri sunar.
* [CommentAuthor](https://reference.aspose.com/slides/tr/cpp/aspose.slides/commentauthor/) sınıfı, bir yazar hakkında ad, baş harfler ve ilişkili yorumlar gibi bilgiler sağlar.

## **Slayta Yorum Ekleme**

Aşağıdaki örnek, bir PowerPoint sunumunda slaytlara yorum eklemenin nasıl yapılacağını gösterir:

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

## **Slayt Yorumlarına Erişim**

Aşağıdaki örnek, bir PowerPoint sunumunda mevcut yorumlara nasıl erişileceğini gösterir:

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

Üst yorum, yanıt hiyerarşisinin en üstündeki orijinal yorumdur. [IComment](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icomment/) arayüzünün [get_ParentComment](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icomment/get_parentcomment/) ve [set_ParentComment](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icomment/set_parentcomment/) yöntemleri, bir yorumun üst yorumunu almanızı veya ayarlamanızı sağlar.

Aşağıdaki örnek, yanıt eklemeyi ve ortaya çıkan yorum hiyerarşisini incelemeyi gösterir:

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

auto author1 = presentation->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment 1", slide, position, createdTime);

auto author2 = presentation->get_CommentAuthors()->AddAuthor(u"Author_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide, position, createdTime);
reply1->set_ParentComment(comment1);

auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide, position, createdTime);
reply2->set_ParentComment(comment1);

auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide, position, createdTime);
subReply->set_ParentComment(reply2);

author2->get_Comments()->AddComment(u"comment 2", slide, position, createdTime);
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide, position, createdTime);

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide, position, createdTime);
reply3->set_ParentComment(comment3);

auto comments = slide->GetSlideComments(nullptr);
for (int32_t i = 0; i < comments->get_Length(); i++)
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

comment1->Remove();
presentation->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Uyarı" %}}
* [IComment](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icomment/) arayüzünün [Remove](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icomment/remove/) yöntemi bir yorumu silmek için kullanıldığında, o yoruma ait tüm yanıtlar da silinir.
* [set_ParentComment](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icomment/set_parentcomment/) yöntemi dairesel bir referans oluşturursa, bir [PptxEditException](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pptxeditexception/) fırlatılır.
{{% /alert %}}

## **Modern Yorumlar Ekleme**

Modern yorumlar slaytın kendisine, belirli bir şekle veya bir AutoShape içindeki bir metin aralığına ilişkilendirilebilir. [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icommentcollection/addmoderncomment/) yöntemi, slayt ve yorum işaretçi koordinatlarının yanı sıra bir [IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) argümanını da kabul eder.

Şekil argümanı için `nullptr` geçildiğinde, yorum bir slayt‑seviyesi yorumdur. İşaretçi verilen koordinatlarla konumlandırılır, ancak belirli bir şekle bağlı değildir; bu nedenle [IModernComment::get_Shape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imoderncomment/get_shape/) `nullptr` döndürür. Bir [IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) sağlandığında, yorum o şekle bağlanır. Koordinatlar hâlâ yorum işaretçisinin slayttaki konumunu tanımlar, şekil ilişkisi ise [IModernComment::get_Shape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imoderncomment/get_shape/) üzerinden elde edilebilir.

### **Modern Bir Yorumu Şekle Bağlama**

Aşağıdaki örnek, bir slayt‑seviyesi modern yorum ile belirli bir AutoShape'e bağlanmış modern bir yorum oluşturur ve ardından her iki yorumdan da ilişkili şekli okur:

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

[IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) uygulayan herhangi bir slayt nesnesi şekil bağlama amacıyla kullanılabilir. Yaygın örnekler arasında [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iconnector/) ve grafik nesneleri (örneğin, grafikler) gibi [IGraphicalObject](https://reference.aspose.com/slides/tr/cpp/aspose.slides/igraphicalobject/) örnekleri bulunur.

Aşağıdaki örnek, çeşitli yaygın şekil türleri oluşturur ve her biriyle bir modern yorum ilişkilendirir:

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

### **Yorumu Metne Bağla ve Durumunu Ayarla**

[IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) ile ilişkilendirilen bir modern yorum için, [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imoderncomment/get_textselectionstart/) ve [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imoderncomment/set_textselectionstart/) yöntemi, şeklin metin çerçevesindeki seçili metnin başlangıç konumunu kontrol eder. Benzer şekilde, [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imoderncomment/get_textselectionlength/) ve [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imoderncomment/set_textselectionlength/) yöntemi seçimin uzunluğunu belirler. Bu yöntemler, yorumu AutoShape içindeki belirli bir metin aralığı ile ilişkilendirir.

[IModernComment::get_Status](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imoderncomment/get_status/) ve [IModernComment::set_Status](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imoderncomment/set_status/) yöntemleri, [ModernCommentStatus](https://reference.aspose.com/slides/tr/cpp/aspose.slides/moderncommentstatus/) enum değerlerinden birini kullanır:

- `NotDefined` — özel bir modern‑yorum durumu tanımlı değildir.
- `Active` — yorum aktiftir.
- `Resolved` — yorum çözülmüştür.
- `Closed` — yorum kapatılmıştır.

Aşağıdaki örnek, şekle bağlı bir modern yorum oluşturur, bir metin seçimiyle ilişkilendirir, çözülmüş olarak işaretler, sunumu kaydeder ve dosyayı yeniden açtıktan sonra değerleri doğrular:

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

Varolan bir sunumu incelemek için, hangi yorumların [IModernComment](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imoderncomment/) uyguladığını kontrol edin, ardından [IModernComment::get_Shape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imoderncomment/get_shape/), [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imoderncomment/get_textselectionstart/), [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imoderncomment/get_textselectionlength/) ve [IModernComment::get_Status](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imoderncomment/get_status/) özelliklerini inceleyin. `nullptr` bir şekil, slayt‑seviyesi bir yorum olduğunu gösterir. Bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) bağlaması için, metin‑seçim yöntemleri şeklin metin çerçevesindeki ilişkili aralığı tanımlar.

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

### **Tüm Yorumları ve Yorum Yazarlarını Kaldırma**

Aşağıdaki örnek, bir sunumdan tüm yorumları ve yorum yazarlarını nasıl kaldıracağınızı gösterir:

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

Aşağıdaki örnek, bir slayttan belirli yorumların nasıl kaldırılacağını gösterir:

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

## **SSS**

**Aspose.Slides modern yorumlar için çözülmüş durumunu destekliyor mu?**

Evet. [IModernComment::get_Status](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imoderncomment/get_status/) ve [IModernComment::set_Status](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imoderncomment/set_status/) bir [ModernCommentStatus](https://reference.aspose.com/slides/tr/cpp/aspose.slides/moderncommentstatus/) değeri, `Resolved` dahil olmak üzere, kullanır. Durum sunumda depolanır ve dosya yeniden açıldıktan sonra tekrar okunabilir.

**İşlemeli tartışmalar (yanıt zincirleri) destekleniyor mu ve bir iç içeleme sınırı var mı?**

Evet. Her yorum, bir [parent comment](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icomment/set_parentcomment/) referansı aracılığıyla başka bir yoruma bağlanabilir; bu da yanıt zincirlerini mümkün kılar. API, belirli bir iç içeleme derinliği sınırı tanımlamaz.

**Yorum işaretçisinin konumu slaytta hangi koordinat sistemine göre tanımlanır?**

İşaretçi konumu, slayt koordinat sistemindeki kayan nokta koordinatlarıyla tanımlanır; bu sayede işaretçiyi slayt üzerinde tam olarak istediğiniz yere yerleştirebilirsiniz.