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
- lägga till kommentar
- åtkomst till kommentar
- redigera kommentar
- svara på kommentar
- ta bort kommentar
- radera kommentar
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Hantera presentationskommentarer med Aspose.Slides för C++: lägg till, läs, redigera, svara på och ta bort kommentarer i PowerPoint-presentationer snabbt och enkelt."
---
## **Översikt**

Den här artikeln förklarar hur du hanterar presentationskommentarer med Aspose.Slides för C++. Den introducerar de viktigaste typerna relaterade till kommentarer och demonstrerar hur du lägger till kommentarer på bilder, får åtkomst till befintliga kommentarer, arbetar med svar och moderna kommentarer samt tar bort kommentarer från en presentation.

Exemplen täcker vanliga gransknings- och samarbets scenarier i PowerPoint, såsom att tilldela kommentarer till författare, läsa kommentartext och metadata, bygga svarskedjor och ta bort valda kommentarer eller alla kommentarer.

I PowerPoint visas kommentarer som anteckningar på bilder. När du markerar en kommentar visas dess text och relaterade diskussion.

## **Varför lägga till kommentarer i presentationer?**

Du kan använda kommentarer för att ge feedback och samarbeta med kollegor när du granskar presentationer.

Aspose.Slides för C++ tillhandahåller följande API: för arbete med kommentarer:

* Klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) som ger åtkomst till presentationens kommentarförfattare.
* Interfacet [ICommentCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icommentcollection/) som representerar kommentarerna som är kopplade till en enskild författare.
* Interfacet [IComment](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icomment/) som ger information om en kommentar, inklusive dess författare, skapningstid, position och text.
* Klassen [CommentAuthor](https://reference.aspose.com/slides/sv/cpp/aspose.slides/commentauthor/) som ger information om en författare, inklusive namn, initialer och tillhörande kommentarer.

## **Lägg till bildkommentarer**

Följande exempel visar hur du lägger till kommentarer på bilder i en PowerPoint-presentation:

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

## **Åtkomst till bildkommentarer**

Följande exempel visar hur du får åtkomst till befintliga kommentarer i en PowerPoint-presentation:

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

## **Svara på kommentarer**

En föräldrakommentar är den ursprungliga kommentaren högst upp i en svarshierarki. Metoderna [get_ParentComment](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icomment/get_parentcomment/) och [set_ParentComment](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icomment/set_parentcomment/) i interfacet [IComment](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icomment/) låter dig hämta eller ange föräldern för en kommentar.

Följande exempel visar hur du lägger till svar och inspekterar den resulterande kommentarshierarkin:

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

{{% alert color="warning" title="Warning" %}}
* När metoden [Remove](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icomment/remove/) i interfacet [IComment](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icomment/) används för att ta bort en kommentar, tas alla svar till den kommentaren också bort.
* Om metoden [set_ParentComment](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icomment/set_parentcomment/) skapar en cirkulär referens, kastas ett [PptxEditException](https://reference.aspose.com/slides/sv/cpp/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Lägg till moderna kommentarer**

Moderna kommentarer kan kopplas till själva bilden, till en specifik form eller till ett textområde i en AutoShape. Metoden [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icommentcollection/addmoderncomment/) accepterar ett argument av typen [IShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/) utöver bild- och kommentarmärkeskoordinaterna.

När `nullptr` skickas för formargumentet blir kommentaren en bildnivåkommentar. Dess markör placeras enligt de angivna koordinaterna, men den är inte kopplad till någon specifik form, så [IModernComment::get_Shape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imoderncomment/get_shape/) returnerar `nullptr`. När en [IShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/) anges, förankras kommentaren till den formen. Koordinaterna definierar fortfarande positionen för kommentarmärket på bilden, medan formkopplingen kan hämtas via [IModernComment::get_Shape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imoderncomment/get_shape/).

### **Förankra en modern kommentar till en form**

Följande exempel skapar både en modern kommentar på bildnivå och en modern kommentar förankrad till en specifik AutoShape. Det läser sedan den associerade formen från varje kommentar.

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

### **Förankra kommentarer till olika formtyper**

Alla bildobjekt som implementerar [IShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/) kan användas som en formförankring. Vanliga exempel inkluderar [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iconnector/) och [IGraphicalObject](https://reference.aspose.com/slides/sv/cpp/aspose.slides/igraphicalobject/)-instanser såsom diagram.

Följande exempel skapar flera vanliga formtyper och associerar en modern kommentar med varje.

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

### **Förankra en kommentar till text och ange dess status**

För en modern kommentar som är associerad med en [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) styr [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imoderncomment/get_textselectionstart/) och [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imoderncomment/set_textselectionstart/) startpositionen för den markerade texten i formens textramar. På liknande sätt styr [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imoderncomment/get_textselectionlength/) och [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imoderncomment/set_textselectionlength/) längden på markeringen. Tillsammans associerar dessa metoder kommentaren med ett specifikt textområde i AutoShape.

[IModernComment::get_Status](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imoderncomment/get_status/) och [IModernComment::set_Status](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imoderncomment/set_status/) använder ett värde från uppräkningen [ModernCommentStatus](https://reference.aspose.com/slides/sv/cpp/aspose.slides/moderncommentstatus/):

- `NotDefined` — ingen specifik modern kommentarsstatus är definierad.
- `Active` — kommentaren är aktiv.
- `Resolved` — kommentaren har lösts.
- `Closed` — kommentaren är stängd.

Följande exempel skapar en formförankrad modern kommentar, associerar den med en textmarkering, markerar den som löst, sparar presentationen och verifierar värdena efter att filen har öppnats igen.

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

### **Inspektera befintliga moderna kommentarer**

För att inspektera en befintlig presentation, kontrollera vilka kommentarer som implementerar [IModernComment](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imoderncomment/), och granska sedan [IModernComment::get_Shape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imoderncomment/get_shape/), [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imoderncomment/get_textselectionstart/), [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imoderncomment/get_textselectionlength/) och [IModernComment::get_Status](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imoderncomment/get_status/). En `nullptr`-form indikerar en bildnivåkommentar. För en [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/)-förankring identifierar textmarkeringsmetoderna det associerade intervallet i formens textramar.

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

## **Ta bort kommentarer**

### **Ta bort alla kommentarer och kommentarförfattare**

Följande exempel visar hur du tar bort alla kommentarer och kommentarförfattare från en presentation:

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

### **Ta bort specifika kommentarer**

Följande exempel visar hur du tar bort specifika kommentarer från en bild:

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

**Stöder Aspose.Slides ett löst status för moderna kommentarer?**

Ja. [IModernComment::get_Status](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imoderncomment/get_status/) och [IModernComment::set_Status](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imoderncomment/set_status/) använder ett värde från [ModernCommentStatus](https://reference.aspose.com/slides/sv/cpp/aspose.slides/moderncommentstatus/), inklusive `Resolved`. Statusen lagras i presentationen och kan läsas igen efter att filen har öppnats på nytt.

**Stöds trådade diskussioner (svarskedjor) och finns det någon begränsning för nästning?**

Ja. Varje kommentar kan referera till sin [parent comment](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icomment/set_parentcomment/), vilket möjliggör svarskedjor. API:t definierar ingen specifik gräns för nästningsdjup.

**I vilket koordinatsystem definieras en kommentarmärkes position på en bild?**

Markörpositionen definieras av flyttalskoordinater i bildens koordinatsystem, vilket låter dig placera den exakt på bilden.