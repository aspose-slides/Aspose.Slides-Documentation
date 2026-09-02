---
title: Presentatieopmerkingen beheren in C++
linktitle: Presentatieopmerkingen
type: docs
weight: 100
url: /nl/cpp/presentation-comments/
keywords:
- opmerking
- moderne opmerking
- PowerPoint-opmerkingen
- presentatieopmerkingen
- dia-opmerkingen
- opmerking toevoegen
- opmerking benaderen
- opmerking bewerken
- opmerking beantwoorden
- opmerking verwijderen
- opmerking verwijderen
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Beheer presentatieopmerkingen met Aspose.Slides voor C++: voeg opmerkingen toe, lees ze, bewerk ze, beantwoord ze en verwijder ze in PowerPoint‑presentaties, snel en eenvoudig."
---
## **Overzicht**

Dit artikel legt uit hoe u opmerkingen in een presentatie kunt beheren met Aspose.Slides voor C++. Het introduceert de belangrijkste types die met opmerkingen te maken hebben en laat zien hoe u opmerkingen aan dia's kunt toevoegen, bestaande opmerkingen kunt benaderen, met antwoorden en moderne opmerkingen kunt werken, en hoe u opmerkingen uit een presentatie kunt verwijderen.

De voorbeelden behandelen veelvoorkomende scenario's voor review en samenwerking in PowerPoint, zoals het toewijzen van opmerkingen aan auteurs, het lezen van de tekst en metadata van een opmerking, het bouwen van antwoordketens, en het verwijderen van geselecteerde opmerkingen of alle opmerkingen.

In PowerPoint verschijnen opmerkingen als annotaties op dia's. Het selecteren van een opmerking toont de tekst en de bijbehorende discussie.

## **Waarom opmerkingen toevoegen aan presentaties?**

U kunt opmerkingen gebruiken om feedback te geven en samen te werken met collega's bij het beoordelen van presentaties.

Aspose.Slides voor C++ biedt de volgende API's voor het werken met opmerkingen:

* De [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse, die toegang geeft tot de opmerking‑auteurs van de presentatie.
* De [ICommentCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icommentcollection/)‑interface, die de opmerkingen vertegenwoordigt die aan een individuele auteur zijn gekoppeld.
* De [IComment](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icomment/)‑interface, die informatie over een opmerking biedt, inclusief auteur, aanmaaktijd, positie en tekst.
* De [CommentAuthor](https://reference.aspose.com/slides/nl/cpp/aspose.slides/commentauthor/)‑klasse, die informatie over een auteur bevat, zoals naam, initialen en gekoppelde opmerkingen.

## **Opmerkingen aan dia's toevoegen**

Het volgende voorbeeld toont hoe u opmerkingen aan dia's in een PowerPoint‑presentatie kunt toevoegen:

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

## **Opmerkingen van dia's benaderen**

Het volgende voorbeeld toont hoe u bestaande opmerkingen in een PowerPoint‑presentatie kunt benaderen:

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

## **Reageren op opmerkingen**

Een bovenliggende opmerking is de oorspronkelijke opmerking bovenaan een antwoord‑hiërarchie. De methoden [get_ParentComment](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icomment/get_parentcomment/) en [set_ParentComment](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icomment/set_parentcomment/) van de [IComment](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icomment/)‑interface laten u de bovenliggende opmerking van een opmerking ophalen of instellen.

Het volgende voorbeeld toont hoe u antwoorden kunt toevoegen en de resulterende opmerking‑hiërarchie kunt inspecteren:

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
* Wanneer de [Remove](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icomment/remove/)‑methode van de [IComment](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icomment/)‑interface wordt gebruikt om een opmerking te verwijderen, worden ook alle antwoorden op die opmerking verwijderd.
* Als de [set_ParentComment](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icomment/set_parentcomment/)‑methode een circulaire verwijzing creëert, wordt een [PptxEditException](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pptxeditexception/) gegooid.
{{% /alert %}}

## **Moderne opmerkingen toevoegen**

Moderne opmerkingen kunnen worden gekoppeld aan de dia zelf, aan een specifieke vorm, of aan een tekstbereik binnen een AutoShape. De methode [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icommentcollection/addmoderncomment/) accepteert een [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/)‑argument naast de dia‑ en opmerking‑marker‑coördinaten.

Wanneer `nullptr` wordt doorgegeven voor het vorm‑argument, is de opmerking een dia‑niveau opmerking. De marker wordt gepositioneerd volgens de opgegeven coördinaten, maar is niet gekoppeld aan een specifieke vorm, zodat [IModernComment::get_Shape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imoderncomment/get_shape/) `nullptr` retourneert. Wanneer een [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/) wordt opgegeven, wordt de opmerking verankerd aan die vorm. De coördinaten definiëren nog steeds de positie van de opmerking‑marker op de dia, terwijl de vormkoppeling kan worden opgehaald via [IModernComment::get_Shape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imoderncomment/get_shape/).

### **Een moderne opmerking aan een vorm verankeren**

Het volgende voorbeeld maakt zowel een dia‑niveau moderne opmerking als een moderne opmerking verankerd aan een specifieke AutoShape. Vervolgens leest het de gekoppelde vorm van elke opmerking.

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

### **Opmerkingen verankeren aan verschillende vormtypen**

Elk dia‑object dat de [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/)‑interface implementeert, kan worden gebruikt als anker. Veelvoorkomende voorbeelden zijn [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iconnector/) en [IGraphicalObject](https://reference.aspose.com/slides/nl/cpp/aspose.slides/igraphicalobject/)-instanties zoals diagrammen.

Het volgende voorbeeld maakt verschillende veelvoorkomende vormtypen en koppelt een moderne opmerking aan elk van hen.

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

### **Een opmerking aan tekst anker en de status instellen**

Voor een moderne opmerking gekoppeld aan een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) regelen [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imoderncomment/get_textselectionstart/) en [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imoderncomment/set_textselectionstart/) de beginnende positie van de geselecteerde tekst in het tekstframe van de vorm. Evenzo bepalen [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imoderncomment/get_textselectionlength/) en [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imoderncomment/set_textselectionlength/) de lengte van de selectie. Samen koppelen deze methoden de opmerking aan een specifiek tekstbereik binnen de AutoShape.

De methoden [IModernComment::get_Status](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imoderncomment/get_status/) en [IModernComment::set_Status](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imoderncomment/set_status/) gebruiken een waarde uit de enumeratie [ModernCommentStatus](https://reference.aspose.com/slides/nl/cpp/aspose.slides/moderncommentstatus/):

- `NotDefined` — er is geen specifieke status voor de moderne opmerking gedefinieerd.
- `Active` — de opmerking is actief.
- `Resolved` — de opmerking is opgelost.
- `Closed` — de opmerking is gesloten.

Het volgende voorbeeld maakt een vorm‑verankerde moderne opmerking, koppelt deze aan een tekstselectie, markeert deze als opgelost, slaat de presentatie op en controleert de waarden na het heropenen van het bestand.

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

### **Bestaande moderne opmerkingen inspecteren**

Om een bestaande presentatie te inspecteren, controleert u welke opmerkingen de [IModernComment](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imoderncomment/)-interface implementeren, en onderzoekt u vervolgens [IModernComment::get_Shape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imoderncomment/get_shape/), [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imoderncomment/get_textselectionstart/), [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imoderncomment/get_textselectionlength/) en [IModernComment::get_Status](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imoderncomment/get_status/). Een `nullptr` vorm duidt op een opmerking op dia‑niveau. Voor een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/)‑anker identificeren de tekst‑selectiemethoden het gekoppelde bereik in het tekstframe van de vorm.

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

## **Opmerkingen verwijderen**

### **Alle opmerkingen en opmerkingauteurs verwijderen**

Het volgende voorbeeld toont hoe u alle opmerkingen en opmerkingauteurs uit een presentatie kunt verwijderen:

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

### **Specifieke opmerkingen verwijderen**

Het volgende voorbeeld toont hoe u specifieke opmerkingen van een dia kunt verwijderen:

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

**Ondersteunt Aspose.Slides een opgeloste status voor moderne opmerkingen?**

Ja. [IModernComment::get_Status](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imoderncomment/get_status/) en [IModernComment::set_Status](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imoderncomment/set_status/) gebruiken een [ModernCommentStatus](https://reference.aspose.com/slides/nl/cpp/aspose.slides/moderncommentstatus/)-waarde, inclusief `Resolved`. De status wordt opgeslagen in de presentatie en kan opnieuw gelezen worden nadat het bestand is heropend.

**Worden gestructureerde discussies (antwoordketens) ondersteund, en is er een limiet op nesting?**

Ja. Elke opmerking kan verwijzen naar zijn [parent comment](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icomment/set_parentcomment/), waardoor antwoordketens mogelijk zijn. De API definieert geen specifieke limiet voor de nestdiepte.

**In welk coördinatensysteem wordt de positie van een opmerking‑marker op een dia gedefinieerd?**

De marker‑positie wordt gedefinieerd door zwevende‑komma coördinaten in het dia‑coördinatensysteem, zodat u deze nauwkeurig op de dia kunt plaatsen.