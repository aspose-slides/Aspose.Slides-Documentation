---
title: Beheer presentatieopmerkingen in C++
linktitle: Presentatieopmerkingen
type: docs
weight: 100
url: /nl/cpp/presentation-comments/
keywords:
- opmerking
- moderne opmerking
- PowerPoint-opmerkingen
- presentatie-opmerkingen
- dia-opmerkingen
- opmerking toevoegen
- opmerking benaderen
- opmerking bewerken
- opmerking beantwoorden
- opmerking verwijderen
- opmerking wissen
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Beheer presentatie‑opmerkingen met Aspose.Slides for C++: voeg toe, lees, bewerk, beantwoord en verwijder opmerkingen in PowerPoint‑presentaties snel en eenvoudig."
---
## **Overzicht**

Dit artikel legt uit hoe je presentatieopmerkingen beheert met Aspose.Slides for C++. Het introduceert de belangrijkste types die verband houden met opmerkingen en toont hoe je opmerkingen aan dia's toevoegt, bestaande opmerkingen benadert, werkt met antwoorden en moderne opmerkingen, en opmerkingen uit een presentatie verwijdert.

De voorbeelden behandelen veelvoorkomende beoordelings‑ en samenwerkingsscenario’s in PowerPoint, zoals het toewijzen van opmerkingen aan auteurs, het lezen van de opmerkingstekst en metadata, het opbouwen van antwoordketens, en het verwijderen van geselecteerde opmerkingen of alle opmerkingen.

In PowerPoint verschijnen opmerkingen als annotaties op dia’s. Het selecteren van een opmerking toont de tekst en de bijbehorende discussie.

Om aan te geven dat opmerkingen getoond of verborgen moeten worden wanneer een presentatie wordt geopend zonder de opmerkingen zelf te wijzigen, zie [Show or Hide Comments When Opening a Presentation](/slides/nl/cpp/presentation-view-properties/).

## **Waarom opmerkingen toevoegen aan presentaties?**

Je kunt opmerkingen gebruiken om feedback te geven en samen te werken met collega‑s bij het beoordelen van presentaties.

Aspose.Slides for C++ biedt de volgende API’s voor het werken met opmerkingen:

* De klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) die toegang biedt tot de commentauteurs van de presentatie.
* De interface [ICommentCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/) die de opmerkingen vertegenwoordigt die aan een individuele auteur zijn gekoppeld.
* De interface [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) die informatie over een opmerking levert, inclusief auteur, aanmaak‑tijd, positie en tekst.
* De klasse [CommentAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/commentauthor/) die informatie over een auteur geeft, zoals naam, initialen en bijbehorende opmerkingen.

## **Dia‑opmerkingen toevoegen**

Het voorbeeld maakt twee dia’s aan en registreert een commentauteur met [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/). Het gebruikt [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) om op elke dia één opmerking te plaatsen, haalt daarna de opmerkingen van de eerste dia op voor die auteur met [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/). De console toont de tekst van de eerste opmerking twee keer, waarmee toegang via zowel de dia als de auteur wordt gedemonstreerd, en de opgeslagen presentatie bevat beide opmerkingen.

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

## **Zoek of maak een commentauteur aan**

Wanneer een geautomatiseerde review dezelfde presentatie herhaaldelijk verwerkt, doorzoek dan de collectie die wordt geretourneerd door [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/) voordat je een auteur toevoegt. [FindByNameAndInitials](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbynameandinitials/) vergelijkt zowel de naam als de initialen en retourneert een array met overeenkomende auteurs, of een lege array als er geen overeenkomsten zijn. Daarentegen zoekt [FindByName](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbyname/) alleen op naam, ongeacht de initialen. Het aanroepen van [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/) met een naam en initialen die al in de collectie aanwezig zijn, werpt een uitzondering.

Het voorbeeld vereist een presentatiedocument met ten minste één dia. Tijdens elke van de twee passes wordt de eerst gevonden auteur hergebruikt, of wordt er een nieuwe aangemaakt alleen wanneer het resultaat leeg is. Als er meerdere overeenkomsten zijn, wordt het eerste array‑element geselecteerd zonder de andere auteurs samen te voegen of te verwijderen. Vervolgens wordt [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) aangeroepen voor de geselecteerde auteur en wordt de presentatie opgeslagen. De tweede pass opent de uitvoer van de eerste pass en herhaalt de bewerking.

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

De tweede pass voegt een extra opmerking toe zonder een extra auteur toe te voegen of bestaande opmerkingen te verwijderen. Het uiteindelijke bestand, `review_pass_2.pptx`, bevat beide nieuwe opmerkingen naast eventuele oorspronkelijke opmerkingen. Het hergebruiken van een auteur dedupliceert opmerkingen niet: om te voorkomen dat dezelfde opmerking herhaaldelijk wordt toegevoegd, implementeer je een aparte duplicaatdetectie vóór het toevoegen.

## **Toegang tot dia‑opmerkingen**

Het voorbeeld opent een bestaande presentatie en leest de collectie die wordt geretourneerd door [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/). Voor elke auteur wordt de collectie opgehaald via [get_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthor/get_comments/) en worden het dia‑nummer, de opmerkingstekst, de auteursnaam en de aanmaak‑tijd afgedrukt. De invoerpresentatie moet opmerkingen bevatten om console‑output te genereren.

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

## **Beantwoorden van opmerkingen**

Een bovenliggende opmerking is de oorspronkelijke opmerking bovenaan een antwoordhiërarchie. De methoden [get_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/get_parentcomment/) en [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) van de interface [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) laten je de ouder van een opmerking ophalen of instellen.

Het voorbeeld maakt opmerkingen van twee auteurs en gebruikt [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) om antwoorden op te bouwen, inclusief een antwoord op een ander antwoord. Het doorgeven van `nullptr` aan [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) haalt opmerkingen op van alle auteurs; de console indentieert elke entry volgens de diepte in de antwoordhiërarchie. Het voorbeeld slaat de volledige discussie op, roept [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) aan op de eerste root‑opmerking, en slaat een tweede presentatie op waarin die opmerking en diens antwoorden verwijderd zijn.

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
* Wanneer de [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/)‑methode van de interface [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) wordt gebruikt om een opmerking te verwijderen, worden alle antwoorden op die opmerking eveneens verwijderd.
* Als de [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/)‑methode een circulaire referentie creëert, wordt een [PptxEditException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxeditexception/) gegooid.
{{% /alert %}}

## **Moderne opmerkingen toevoegen**

Moderne opmerkingen kunnen worden gekoppeld aan de dia zelf, aan een specifieke vorm, of aan een tekstreeks binnen een AutoShape. De methode [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) accepteert een argument van het type [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) naast de dia‑ en marker‑coördinaten.

Wanneer `nullptr` wordt doorgegeven voor het vorm‑argument, is de opmerking een dia‑niveau opmerking. De marker wordt gepositioneerd volgens de opgegeven coördinaten, maar is niet gekoppeld aan een specifieke vorm, zodat [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) `nullptr` teruggeeft. Wanneer een [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) wordt opgegeven, wordt de opmerking aan die vorm verankerd. De coördinaten bepalen nog steeds de positie van de marker op de dia, terwijl de vormkoppeling kan worden opgehaald via [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/).

### **Een moderne opmerking aan een vorm verankeren**

Het voorbeeld roept [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) twee keer aan: één keer met een `nullptr` vorm voor een dia‑niveau opmerking en één keer met een rechthoek als anker. Het aanroepen van [get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) drukt `True` af voor de null‑check van de dia‑niveau opmerking en `Revenue title` voor de verankerde opmerking. Beide opmerkingen worden met de presentatie opgeslagen.

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

### **Opmerkingen verankeren aan verschillende vormtypes**

Elk dia‑object dat de interface [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) implementeert, kan worden gebruikt als anker. Veelvoorkomende voorbeelden zijn [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/cpp/aspose.slides/iconnector/) en [IGraphicalObject](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobject/) zoals grafieken.

Het voorbeeld gebruikt [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) om een opmerking aan elk van vijf vormtypes te koppelen: een AutoShape, een afbeelding, een groep, een connector en een grafiek. De afbeelding maakt gebruik van ingebedde afbeeldingsdata, dus er is geen externe afbeelding nodig. Elke opmerking heeft zijn eigen marker‑positie, en de opgeslagen presentatie behoudt alle vijf vormkoppelingen.

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

### **Een opmerking aan tekst verankeren en de status instellen**

Voor een moderne opmerking gekoppeld aan een [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), regelen [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/) en [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/) de startpositie van de geselecteerde tekst in het tekstvak van de vorm. Evenzo regelen [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/) en [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) de lengte van de selectie. Samen koppelen deze methoden de opmerking aan een specifiek tekstreeks binnen de AutoShape.

De methoden [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) en [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) gebruiken een waarde uit de enumeratie [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/):

- `NotDefined` — er is geen specifieke moderne‑opmerkingstatus gedefinieerd.
- `Active` — de opmerking is actief.
- `Resolved` — de opmerking is opgelost.
- `Closed` — de opmerking is gesloten.

Het voorbeeld verankert een moderne opmerking aan de woorden “quarterly revenue” in de tekst van een rechthoek. Het bepaalt de nul‑gebaseerde startpositie uit de tekst, geeft deze door aan [set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/), en roept [set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) aan met het aantal geselecteerde tekens. Na het aanroepen van [set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) met `Resolved` wordt de presentatie opgeslagen en opnieuw geopend. De vier console‑controles zouden elk `True` moeten afdrukken, waarmee wordt bevestigd dat het vorm‑anker, het tekstreeks‑gebied en de status behouden zijn gebleven.

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

Het voorbeeld vraagt een bestaande presentatie op die moderne opmerkingen bevat en drukt hun tekst, status en ankerdetails af. Om dit te inspecteren, controleer je welke opmerkingen de interface [IModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/) implementeren, en onderzoek je vervolgens [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/), [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/), [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/) en [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/). Een `nullptr`‑vorm duidt op een dia‑niveau opmerking. Voor een anker van het type [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) identificeren de tekst‑selectiemethoden het bijbehorende bereik in het tekstvak van de vorm.

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

Aspose.Slides for C++ stelt je in staat alle opmerkingen en hun auteurs uit een presentatie te verwijderen of geselecteerde opmerkingen te verwijderen terwijl de rest behouden blijft. De volgende voorbeelden demonstreren beide benaderingen en slaan de bijgewerkte presentatie op.

### **Alle opmerkingen en commentauteurs verwijderen**

Het voorbeeld opent een bestaande presentatie en roept voor elke auteur [ICommentCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/clear/) aan, waarna [ICommentAuthorCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/clear/) wordt aangeroepen om de auteurs zelf te verwijderen. De opgeslagen presentatie bevat geen opmerkingen of commentauteurs. Gebruik een presentatie met opmerkingen om de verwijdering te observeren.

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

Het voorbeeld maakt twee opmerkingen op één dia en gebruikt [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) om opmerkingen per auteur op te zoeken. Het verzamelt opmerkingen waarvan de tekst gelijk is aan “comment 1” voordat [ICommentCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/remove/) wordt aangeroepen, zodat de collectie niet wordt gewijzigd tijdens de selectie. De opgeslagen presentatie bevat alleen “comment 2”.

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

**Ondersteunt Aspose.Slides een resolved‑status voor moderne opmerkingen?**

Ja. Zowel [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) als [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) gebruiken een waarde uit de enumeratie [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/), inclusief `Resolved`. De status wordt opgeslagen in de presentatie en kan opnieuw worden gelezen nadat het bestand is heropend.

**Worden doorlopende discussies (antwoordketens) ondersteund, en is er een limiet aan het aantal niveaus?**

Ja. Elke opmerking kan een verwijzing naar zijn [parent comment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) bevatten, waardoor antwoordketens mogelijk zijn. De API definieert geen specifieke limiet voor de diepte van de nesting.

**In welk coördinatensysteem wordt de positie van een opmerkingen‑marker op een dia gedefinieerd?**

De marker‑positie wordt gedefinieerd door zwevende‑komma‑coördinaten in het dia‑coördinatensysteem, zodat je de marker nauwkeurig op de dia kunt plaatsen.