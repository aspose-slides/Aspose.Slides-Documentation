---
title: Hantera presentationskommentarer i C++
linktitle: Presentationskommentarer
type: docs
weight: 100
url: /sv/cpp/presentation-comments/
keywords:
- kommentar
- modern kommentar
- PowerPoint-kommentarer
- presentationskommentarer
- bildkommentarer
- lägg till kommentar
- åtkomst till kommentar
- redigera kommentar
- svara på kommentar
- ta bort kommentar
- radera kommentar
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Behärska presentationskommentarer med Aspose.Slides för C++: lägg till, läs, redigera och radera kommentarer i PowerPoint-filer snabbt och enkelt."
---
## **Översikt**

Den här artikeln förklarar hur du hanterar presentationskommentarer i Aspose.Slides. Den visar de viktigaste typerna relaterade till kommentarer och demonstrerar hur du lägger till kommentarer på bilder, får åtkomst till befintliga kommentarer, arbetar med svar, använder moderna kommentarer och tar bort kommentarer från en presentation.

Exemplen fokuserar på vanliga gransknings- och samarbets scenarier i PowerPoint, såsom att tilldela kommentarer till författare, läsa kommentarers innehåll och metadata, bygga svarskedjor och rensa alla kommentarer eller ta bort markerade.

I PowerPoint visas en kommentar som en anteckning eller annotation på en bild. När du klickar på en kommentar visas dess innehåll eller meddelanden.

### **Varför lägga till kommentarer i presentationer?**

Du kan vilja använda kommentarer för att ge feedback eller kommunicera med dina kollegor när du granskar presentationer.

För att du ska kunna använda kommentarer i PowerPoint-presentationer tillhandahåller Aspose.Slides för C++:

* Klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation) som innehåller samlingarna av författare (från metoden [get_CommentAuthors()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d)). Författarna lägger till kommentarer på bilder. 
* Gränssnittet [ICommentCollection](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_comment_collection) som innehåller samlingen av kommentarer för enskilda författare. 
* Klassen [IComment](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_comment) som innehåller information om författare och deras kommentarer: vem som lade till kommentaren, tidpunkten då kommentaren lades till, kommentarens position osv. 
* Klassen [CommentAuthor](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.comment_author) som innehåller information om enskilda författare: författarens namn, deras initialer, kommentarer associerade med författarens namn osv. 

## **Lägg till en bildkommentar**
Denna C++-kod visar hur du lägger till en kommentar på en bild i en PowerPoint-presentation:

```cpp
// Instansierar Presentation-klassen
auto presentation = System::MakeObject<Presentation>();
// Lägger till en tom bild
presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlides()->idx_get(0));

// Lägger till en författare
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");

// Anger positionen för kommentarer
PointF point;
point.set_X(0.2f);
point.set_Y(0.2f);

// Hämtar ISlide 1
auto slide1 = presentation->get_Slides()->idx_get(0);
// Hämtar ISlide 2
auto slide2 = presentation->get_Slides()->idx_get(1);

// Lägger till bildkommentar för en författare på bild 1
author->get_Comments()->AddComment(u"Hello Jawad, this is slide comment", slide1, point, DateTime::get_Now());

// Lägger till bildkommentar för en författare på bild 2
author->get_Comments()->AddComment(u"Hello Jawad, this is second slide comment", slide2, point, DateTime::get_Now());

// När null skickas som argument hämtas kommentarer från alla författare till den valda bilden
auto comments = slide1->GetSlideComments(author);

// Hämtar kommentaren på index 0 för bild 1
String str = comments[0]->get_Text();

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);

if (comments->GetLength(0) > 0)
{
    // Väljer författarens kommentarsamling på index 0
    auto commentCollection = comments[0]->get_Author()->get_Comments();
    String Comment = commentCollection->idx_get(0)->get_Text();
}
```

## **Åtkomst till bildkommentarer**
Denna C++-kod visar hur du får åtkomst till en befintlig kommentar på en bild i en PowerPoint-presentation:

```cpp
// Instansierar Presentation-klassen
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

## **Svara på kommentarer**

En föräldrakommentar är den översta eller ursprungliga kommentaren i en hierarki av kommentarer eller svar. Genom att använda egenskapen [ParentComment](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) (från gränssnittet [IComment](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_comment)) kan du ange eller hämta en föräldrakommentar. 

Denna C++-kod visar hur du lägger till kommentarer och får svar på dem:

```cpp
auto pres = System::MakeObject<Presentation>();

// Hämtar ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

// Lägger till en kommentar
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// Lägger till ett svar på comment1
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Autror_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// Lägger till ytterligare ett svar på comment1
auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// Lägger till ett svar på befintligt svar
auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"comment 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply3->set_ParentComment(comment3);

// Visar kommentarhierarkin i konsolen
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

// Tar bort comment1 och alla svar på den
comment1->Remove();

pres->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Attention" %}} 

* När metoden [Remove](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_comment#a8bb818ae804d142195c4edcf9012cccb) (från gränssnittet [IComment](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_comment)) används för att ta bort en kommentar tas svaren på kommentaren också bort. 
* Om inställningen [ParentComment](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) resulterar i en cirkulär referens, kastas ett [PptxEditException](https://reference.aspose.com/slides/sv/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d). 

{{% /alert %}}

## **Lägg till en modern kommentar**

År 2021 introducerade Microsoft *moderna kommentarer* i PowerPoint. Funktionen med moderna kommentarer förbättrar samarbetet i PowerPoint avsevärt. Genom moderna kommentarer kan PowerPoint-användare lösa kommentarer, fästa kommentarer på objekt och texter samt delta i interaktioner mycket enklare än tidigare. 

I [Aspose Slides for C++ 21.11](https://docs.aspose.com/slides/sv/cpp/aspose-slides-for-cpp-21-11-release-notes/) implementerade vi stöd för moderna kommentarer genom att lägga till klassen [ModernComment](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.modern_comment). Metoderna [AddModernComment](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.comment_collection#a3627fcb3b05cd639fd430bd8248fe66b) och [InsertModernComment](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.comment_collection#ad11c3efb52f3c17f63238447dcc03c94) lades till i klassen [CommentCollection](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.comment_collection).

Denna C++-kod visar hur du lägger till en modern kommentar på en bild i en PowerPoint-presentation: 

```cpp
auto pres = System::MakeObject<Presentation>();
// Hämtar ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"Some Author", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"This is a modern comment", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Ta bort en kommentar**

### **Ta bort alla kommentarer och författare**

Denna C++-kod visar hur du tar bort alla kommentarer och författare i en presentation:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// Raderar alla kommentarer från presentationen
for (auto author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}
        
// Raderar alla författare
presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

### **Ta bort specifika kommentarer**

Denna C++-kod visar hur du tar bort specifika kommentarer på en bild:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
// lägg till kommentarer...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
author->get_Comments()->AddComment(u"comment 1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"comment 2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
// ta bort alla kommentarer som innehåller texten "comment 1"
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

## **FAQ**

**Stöder Aspose.Slides en status som 'lösta' för moderna kommentarer?**

Ja. [Modern comments](https://reference.aspose.com/slides/sv/cpp/aspose.slides/moderncomment/) exponerar metoderna [get_Status](https://reference.aspose.com/slides/sv/cpp/aspose.slides/moderncomment/get_status/) och [set_Status](https://reference.aspose.com/slides/sv/cpp/aspose.slides/moderncomment/set_status/); du kan läsa och sätta ett [kommentars tillstånd](https://reference.aspose.com/slides/sv/cpp/aspose.slides/moderncommentstatus/) (t.ex. markera det som löst), och detta tillstånd sparas i filen och känns igen av PowerPoint.

**Stöds trådade diskussioner (svarskedjor) och finns det någon begränsning för djupet?**

Ja. Varje kommentar kan referera till sin [parent comment](https://reference.aspose.com/slides/sv/cpp/aspose.slides/comment/set_parentcomment/), vilket möjliggör godtyckliga svarskedjor. API:et specificerar ingen specifik begränsning för nästningsdjupet.

**I vilket koordinatsystem definieras en kommentarmärknings position på en bild?**

Positionen lagras som en flyttalspunkt i bildens koordinatsystem. Detta gör att du kan placera kommentarmärkningspunkten exakt där du behöver den.