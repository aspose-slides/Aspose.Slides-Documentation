---
title: Beheer presentatiecommentaren in C++
linktitle: Presentatiecommentaren
type: docs
weight: 100
url: /nl/cpp/presentation-comments/
keywords:
- commentaar
- modern commentaar
- PowerPoint-commentaren
- presentatiecommentaren
- dia-commentaren
- commentaar toevoegen
- commentaar benaderen
- commentaar bewerken
- commentaar beantwoorden
- commentaar verwijderen
- commentaar wissen
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Beheer presentatiecommentaren met Aspose.Slides voor C++: voeg toe, lees, bewerk, beantwoord en verwijder commentaren in PowerPoint-presentaties snel en eenvoudig."
---
## **Overzicht**

Dit artikel legt uit hoe je presentatiecommentaren kunt beheren met Aspose.Slides for C++. Het introduceert de belangrijkste typen met betrekking tot commentaren en laat zien hoe je commentaren aan dia's kunt toevoegen, bestaande commentaren kunt benaderen, met antwoorden en moderne commentaren kunt werken, en commentaren uit een presentatie kunt verwijderen.

De voorbeelden behandelen veelvoorkomende beoordelings- en samenwerkingsscenario's in PowerPoint, zoals commentaren toewijzen aan auteurs, commentaartekst en metadata lezen, antwoordketens opbouwen, en geselecteerde commentaren of alle commentaren verwijderen.

In PowerPoint verschijnen commentaren als annotaties op dia's. Het selecteren van een commentaar toont de tekst en de bijbehorende discussie.

Om commentaren bij het openen van een presentatie te tonen of te verbergen zonder de commentaren zelf te wijzigen, zie [Toon of verberg commentaren bij het openen van een presentatie](/slides/nl/cpp/presentation-view-properties/).

## **Waarom commentaren aan presentaties toevoegen?**

Je kunt commentaren gebruiken om feedback te geven en samen te werken met collega's bij het beoordelen van presentaties.

Aspose.Slides for C++ biedt de volgende API's voor het werken met commentaren:

* De [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse, die toegang biedt tot de commentaarauteurs van de presentatie.
* De [ICommentCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icommentcollection/) interface, die de commentaren vertegenwoordigt die aan een individuele auteur zijn gekoppeld.
* De [IComment](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icomment/) interface, die informatie over een commentaar biedt, inclusief auteur, aanmaaktijd, positie en tekst.
* De [CommentAuthor](https://reference.aspose.com/slides/nl/cpp/aspose.slides/commentauthor/) klasse, die informatie over een auteur biedt, inclusief naam, initialen en bijbehorende commentaren.

## **Commentaren aan dia's toevoegen**

Het volgende voorbeeld toont hoe je commentaren aan dia's in een PowerPoint‑presentatie kunt toevoegen:

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

## **Commentaren op dia's benaderen**

Het volgende voorbeeld toont hoe je bestaande commentaren in een PowerPoint‑presentatie kunt benaderen:

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

## **Antwoorden op commentaren**

Een hoofdcommentaar is het oorspronkelijke commentaar bovenaan een antwoordhiërarchie. De [get_ParentComment](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icomment/get_parentcomment/)‑ en [set_ParentComment](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icomment/set_parentcomment/)‑methoden van de [IComment](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icomment/) interface laten je het hoofdcommentaar van een commentaar ophalen of instellen.

Het volgende voorbeeld toont hoe je antwoorden kunt toevoegen en de resulterende commentaariharchie kunt inspecteren:

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
* Wanneer de [Remove](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icomment/remove/)‑methode van de [IComment]‑interface wordt gebruikt om een commentaar te verwijderen, worden ook alle antwoorden op dat commentaar verwijderd.
* Als de [set_ParentComment](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icomment/set_parentcomment/)‑methode een circulaire verwijzing creëert, wordt een [PptxEditException] gegooid.
{{% /alert %}}

## **Moderne commentaren toevoegen**

Moderne commentaren kunnen worden gekoppeld aan de dia zelf, aan een specifieke vorm, of aan een tekstreeks binnen een AutoShape. De [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icommentcollection/addmoderncomment/)‑methode accepteert een [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/)‑argument naast de dia‑ en commentaar‑markercoördinaten.

Wanneer `nullptr` wordt doorgegeven voor het vorm‑argument, is het commentaar een dia‑niveau commentaar. De marker wordt gepositioneerd volgens de opgegeven coördinaten, maar is niet gekoppeld aan een specifieke vorm, zodat [IModernComment::get_Shape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imoderncomment/get_shape/) `nullptr` retourneert. Wanneer een [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/) wordt opgegeven, wordt het commentaar aan die vorm verankerd. De coördinaten bepalen nog steeds de positie van de commentaar‑marker op de dia, terwijl de vormkoppeling kan worden opgehaald via [IModernComment::get_Shape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imoderncomment/get_shape/).

### **Een modern commentaar aan een vorm verankeren**

Het volgende voorbeeld maakt zowel een modern commentaar op dia‑niveau als een modern commentaar verankerd aan een specifieke AutoShape. Het leest vervolgens de bijbehorende vorm uit elk commentaar.

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

### **Commentaren aan verschillende vormtypen verankeren**

Elk dia‑object dat [IShape] implementeert kan gebruikt worden als vorm‑ankerpunt. Veelvoorkomende voorbeelden omvatten [IAutoShape], [IPictureFrame], [IGroupShape], [IConnector] en [IGraphicalObject]‑instanties zoals diagrammen.

Het volgende voorbeeld maakt verschillende veelvoorkomende vormtypen en koppelt een modern commentaar aan elk van hen.

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

### **Een commentaar aan tekst verankeren en de status instellen**

Voor een modern commentaar gekoppeld aan een [IAutoShape] bepalen [IModernComment::get_TextSelectionStart] en [IModernComment::set_TextSelectionStart] de startpositie van de geselecteerde tekst in het tekstvak van de vorm. Op dezelfde manier bepalen [IModernComment::get_TextSelectionLength] en [IModernComment::set_TextSelectionLength] de lengte van de selectie. Samen koppelen deze methoden het commentaar aan een specifieke tekstreeks binnen de AutoShape.

De [IModernComment::get_Status]‑ en [IModernComment::set_Status]‑methoden gebruiken een waarde uit de [ModernCommentStatus]‑enumeratie:

- `NotDefined` — er is geen specifieke status voor modern commentaar gedefinieerd.
- `Active` — het commentaar is actief.
- `Resolved` — het commentaar is opgelost.
- `Closed` — het commentaar is gesloten.

Het volgende voorbeeld maakt een aan een vorm verankerd modern commentaar, koppelt het aan een tekstselectie, markeert het als opgelost, slaat de presentatie op, en controleert de waarden na het opnieuw openen van het bestand.

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

### **Bestaande moderne commentaren inspecteren**

Om een bestaande presentatie te inspecteren, controleer welke commentaren [IModernComment] implementeren, en bekijk daarna [IModernComment::get_Shape], [IModernComment::get_TextSelectionStart], [IModernComment::get_TextSelectionLength] en [IModernComment::get_Status]. Een `nullptr`‑vorm duidt op een commentaar op dia‑niveau. Voor een [IAutoShape]‑anker identificeren de tekstselectiemethoden het bijbehorende bereik in het tekstvak van de vorm.

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

## **Commentaren verwijderen**

### **Alle commentaren en commentaarauteurs verwijderen**

Het volgende voorbeeld toont hoe je alle commentaren en commentaarauteurs uit een presentatie kunt verwijderen:

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

### **Specifieke commentaren verwijderen**

Het volgende voorbeeld toont hoe je specifieke commentaren van een dia kunt verwijderen:

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

**Ondersteunt Aspose.Slides een opgeloste status voor moderne commentaren?**

Ja. De [IModernComment::get_Status]‑ en [IModernComment::set_Status]‑methoden gebruiken een [ModernCommentStatus]‑waarde, inclusief `Resolved`. De status wordt opgeslagen in de presentatie en kan opnieuw worden gelezen nadat het bestand opnieuw geopend is.

**Worden draadgesprekken (antwoordketens) ondersteund en is er een limiet op de nesting?**

Ja. Elk commentaar kan naar zijn [parent comment](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icomment/set_parentcomment/) verwijzen, waardoor antwoordketens mogelijk zijn. De API definieert geen specifieke limiet voor de nesting‑diepte.

**In welk coördinatensysteem wordt de positie van een commentaar‑marker op een dia gedefinieerd?**

De marker‑positie wordt gedefinieerd door zwevende‑kommagetallen in het dia‑coördinatensysteem, waardoor je deze nauwkeurig op de dia kunt plaatsen.