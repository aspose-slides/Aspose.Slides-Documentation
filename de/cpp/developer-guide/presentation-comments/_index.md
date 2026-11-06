---
title: Verwalten von Präsentationskommentaren in C++
linktitle: Präsentationskommentare
type: docs
weight: 100
url: /de/cpp/presentation-comments/
keywords:
- Kommentar
- moderner Kommentar
- PowerPoint-Kommentare
- Präsentationskommentare
- Folienkommentare
- Kommentar hinzufügen
- Kommentar zugreifen
- Kommentar bearbeiten
- Kommentar beantworten
- Kommentar entfernen
- Kommentar löschen
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Verwalten Sie Präsentationskommentare mit Aspose.Slides für C++: Kommentare in PowerPoint‑Präsentationen schnell und einfach hinzufügen, lesen, bearbeiten, beantworten und entfernen."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Präsentationskommentare mit Aspose.Slides für C++ verwaltet. Er führt die wichtigsten kommentarbezogenen Typen ein und demonstriert, wie Kommentare zu Folien hinzugefügt, vorhandene Kommentare abgerufen, mit Antworten und modernen Kommentaren gearbeitet und Kommentare aus einer Präsentation entfernt werden.

Die Beispiele decken gängige Überprüfungs‑ und Zusammenarbeitsszenarien in PowerPoint ab, z. B. das Zuweisen von Kommentaren zu Autoren, das Auslesen von Kommentartext und Metadaten, das Erstellen von Antwortketten und das Entfernen ausgewählter Kommentare oder aller Kommentare.

In PowerPoint erscheinen Kommentare als Anmerkungen auf Folien. Durch Auswählen eines Kommentars wird dessen Text und die zugehörige Diskussion angezeigt.

Um zu verlangen, dass Kommentare beim Öffnen einer Präsentation angezeigt oder ausgeblendet werden, ohne die Kommentare selbst zu ändern, siehe [Kommentare beim Öffnen einer Präsentation ein- oder ausblenden](/slides/de/cpp/presentation-view-properties/).

## **Warum Kommentare zu Präsentationen hinzufügen?**

Sie können Kommentare verwenden, um Feedback zu geben und bei der Durchsicht von Präsentationen mit Kollegen zusammenzuarbeiten.

Aspose.Slides für C++ stellt die folgenden APIs für die Arbeit mit Kommentaren bereit:

* The [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class, die Zugriff auf die Kommentarautoren der Präsentation bietet.
* The [ICommentCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/) interface, die die mit einem einzelnen Autor verbundenen Kommentare darstellt.
* The [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) interface, die Informationen über einen Kommentar bereitstellt, einschließlich Autor, Erstellungszeit, Position und Text.
* The [CommentAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/commentauthor/) class, die Informationen über einen Autor bereitstellt, einschließlich Name, Initialen und zugehöriger Kommentare.

## **Folienkommentare hinzufügen**

Das Beispiel erstellt zwei Folien und registriert einen Kommentarautor mit [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/). Es verwendet [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/), um auf jeder Folie einen Kommentar zu platzieren, ruft dann die Kommentare der ersten Folie für diesen Autor mit [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) ab. Die Konsole gibt den Text des ersten Kommentars zweimal aus, wodurch der Zugriff sowohl über die Folie als auch über den Autor demonstriert wird, und die gespeicherte Präsentation enthält beide Kommentare.

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

## **Einen Kommentarautor finden oder erstellen**

Wenn eine automatisierte Überprüfung dieselbe Präsentation wiederholt verarbeitet, durchsuchen Sie die Sammlung, die von [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/) zurückgegeben wird, bevor Sie einen Autor hinzufügen. [FindByNameAndInitials](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbynameandinitials/) stimmt sowohl Name als auch Initialen überein und gibt ein Array passender Autoren zurück, oder ein leeres Array, wenn keine Übereinstimmungen existieren. Im Gegensatz dazu durchsucht [FindByName](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbyname/) nur nach dem Namen, unabhängig von den Initialen. Der Aufruf von [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/) mit einem Namen und Initialen, die bereits in der Sammlung vorhanden sind, löst eine Ausnahme aus.

Das Beispiel benötigt eine Präsentationsdatei mit mindestens einer Folie. In jedem der beiden Durchläufe wird der zuerst passende Autor wiederverwendet oder nur dann ein neuer erstellt, wenn das Ergebnis leer ist. Gibt es mehrere Treffer, wird das erste Array‑Element ausgewählt, ohne die anderen Autoren zu zusammenzuführen oder zu entfernen. Anschließend wird [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) für den ausgewählten Autor aufgerufen und die Präsentation gespeichert. Der zweite Durchlauf öffnet die Ausgabe des ersten Durchlaufs und wiederholt den Vorgang.

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

Der zweite Durchlauf fügt einen weiteren Kommentar hinzu, ohne einen weiteren Autor zu erzeugen oder vorhandene Kommentare zu entfernen. Die endgültige Datei `review_pass_2.pptx` enthält beide neuen Kommentare neben etwaigen Originalkommentaren. Das Wiederverwenden eines Autors dedupliziert Kommentare nicht: Um zu vermeiden, dass derselbe Kommentar wiederholt hinzugefügt wird, implementieren Sie eine separate Duplikaterkennung, bevor Sie ihn hinzufügen.

## **Auf Folienkommentare zugreifen**

Das Beispiel öffnet eine vorhandene Präsentation und liest die Sammlung, die von [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/) zurückgegeben wird. Für jeden Autor iteriert es über die Sammlung, die von [get_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthor/get_comments/) zurückgegeben wird, und gibt die Foliennummer, den Kommentartext, den Autorennamen und die Erstellungszeit aus. Die Eingabepäsentation muss Kommentare enthalten, damit Konsolenausgaben erzeugt werden.

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

## **Auf Kommentare antworten**

Ein Elternkommentar ist der ursprüngliche Kommentar an der Spitze einer Antworthierarchie. Die Methoden [get_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/get_parentcomment/) und [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) des [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) Interfaces ermöglichen das Abrufen bzw. Setzen des Elternteils eines Kommentars.

Das Beispiel erstellt Kommentare von zwei Autoren und verwendet [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/), um Antworten zu erstellen, einschließlich einer Antwort auf eine weitere Antwort. Das Übergeben von `nullptr` an [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) ruft Kommentare aller Autoren ab; die Konsole rückt jeden Eintrag gemäß seiner Tiefe in der Antworthierarchie ein. Das Beispiel speichert die komplette Diskussion, ruft [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) für den ersten Root‑Kommentar auf und speichert eine zweite Präsentation, in der dieser Kommentar und seine Antworten entfernt sind.

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
* Wenn die [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/)‑Methode des [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) Interfaces verwendet wird, um einen Kommentar zu löschen, werden auch alle Antworten auf diesen Kommentar gelöscht.
* Wenn die [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/)‑Methode eine zirkuläre Referenz erzeugt, wird eine [PptxEditException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxeditexception/) ausgelöst.
{{% /alert %}}

## **Moderne Kommentare hinzufügen**

Moderne Kommentare können der Folie selbst, einem bestimmten Shape oder einem Textbereich innerhalb eines AutoShape zugeordnet werden. Die Methode [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) akzeptiert zusätzlich zum Slide‑ und Marker‑Koordinaten ein [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)-Argument.

Wird `nullptr` für das Shape‑Argument übergeben, handelt es sich um einen Folien‑Comment. Sein Marker wird über die übergebenen Koordinaten positioniert, ist aber nicht einem bestimmten Shape zugeordnet, sodass [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) `nullptr` zurückgibt. Wird ein [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) übergeben, wird der Kommentar an diesem Shape verankert. Die Koordinaten definieren weiterhin die Position des Markers auf der Folie, während die Shape‑Zuordnung über [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) abgerufen werden kann.

### **Einen modernen Kommentar an ein Shape anheften**

Das Beispiel ruft [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) zweimal auf: einmal mit einem `nullptr`‑Shape für einen Folien‑Comment und einmal mit einem Rechteck als Anker. Der Aufruf von [get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) gibt für den Folien‑Comment `True` (Null‑Prüfung) und für den verankerten Kommentar `Revenue title` aus. Beide Kommentare werden mit der Präsentation gespeichert.

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

### **Kommentare an verschiedene Shape‑Typen anheften**

Jedes Folienobjekt, das [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) implementiert, kann als Shape‑Anker verwendet werden. Häufige Beispiele sind [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/cpp/aspose.slides/iconnector/) und [IGraphicalObject](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobject/)-Instanzen wie Diagramme.

Das Beispiel verwendet [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/), um einem AutoShape, einem Bildrahmen, einer Gruppe, einem Connector und einem Diagramm jeweils einen Kommentar zuzuordnen. Das Bild verwendet eingebettete Bilddaten, so dass kein externes Bild erforderlich ist. Jeder Kommentar hat seine eigene Marker‑Position, und die gespeicherte Präsentation behält alle fünf Shape‑Zuordnungen bei.

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

### **Einen Kommentar an Text anheften und dessen Status setzen**

Für einen modernen Kommentar, der einem [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) zugeordnet ist, steuern [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/) und [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/) die Startposition des ausgewählten Textes im Textfeld des Shapes. Ebenso steuern [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/) und [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) die Länge der Auswahl. Zusammen verknüpfen diese Methoden den Kommentar mit einem bestimmten Textbereich innerhalb des AutoShape.

Die Methoden [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) und [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) verwenden einen Wert aus der Aufzählung [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/):

- `NotDefined` — kein spezifischer moderner Kommentarstatus definiert.
- `Active` — der Kommentar ist aktiv.
- `Resolved` — der Kommentar wurde gelöst.
- `Closed` — der Kommentar ist geschlossen.

Das Beispiel verankert einen modernen Kommentar an den Worten „quarterly revenue“ im Text eines Rechtecks. Es berechnet den nullbasierten Auswahlstart aus dem Text, übergibt ihn an [set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/) und ruft [set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) mit der Anzahl ausgewählter Zeichen auf. Nach dem Aufruf von [set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) mit `Resolved` wird die Präsentation gespeichert und erneut geöffnet. Die vier Konsolenprüfungen sollten jeweils `True` ausgeben und bestätigen, dass Shape‑Anker, Textbereich und Status erhalten geblieben sind.

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

### **Vorhandene moderne Kommentare untersuchen**

Das Beispiel erfordert eine vorhandene Präsentation mit modernen Kommentaren und gibt deren Text, Status und Ankerdetails aus. Zur Untersuchung prüfen Sie, welche Kommentare [IModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/) implementieren, und untersuchen dann [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/), [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/), [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/) sowie [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/). Ein `nullptr`‑Shape weist auf einen Folien‑Comment hin. Für einen [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)‑Anker identifizieren die Text‑Auswahl‑Methoden den zugehörigen Bereich im Textfeld des Shapes.

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

## **Kommentare entfernen**

Aspose.Slides für C++ ermöglicht das Entfernen aller Kommentare und ihrer Autoren aus einer Präsentation oder das Löschen ausgewählter Kommentare bei Beibehaltung der übrigen. Die folgenden Beispiele demonstrieren beide Vorgehensweisen und speichern die aktualisierte Präsentation.

### **Alle Kommentare und Kommentarautoren entfernen**

Das Beispiel öffnet eine vorhandene Präsentation und ruft für jeden Autor [ICommentCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/clear/) auf, danach [ICommentAuthorCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/clear/), um die Autoren selbst zu entfernen. Die gespeicherte Präsentation enthält weder Kommentare noch Kommentarautoren. Verwenden Sie eine Präsentation mit Kommentaren, um die Entfernung zu beobachten.

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

### **Spezifische Kommentare entfernen**

Das Beispiel erstellt zwei Kommentare auf einer Folie und verwendet [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/), um Kommentare jedes Autors zu finden. Es sammelt Kommentare, deren Text gleich „comment 1“ ist, bevor [ICommentCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/remove/) aufgerufen wird, um Änderungen an der Sammlung während der Auswahl zu vermeiden. Die gespeicherte Präsentation enthält nur „comment 2“.

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

**Unterstützt Aspose.Slides einen gelösten Status für moderne Kommentare?**

Ja. [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) und [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) verwenden einen [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/)-Wert, einschließlich `Resolved`. Der Status wird in der Präsentation gespeichert und kann nach erneutem Öffnen der Datei wieder ausgelesen werden.

**Werden verschachtelte Diskussionen (Antwortketten) unterstützt, und gibt es ein Limit für die Verschachtelungstiefe?**

Ja. Jeder Kommentar kann auf seinen [parent comment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) verweisen, wodurch Antwortketten ermöglicht werden. Die API definiert kein spezifisches Limit für die Tiefe der Verschachtelung.

**In welchem Koordinatensystem ist die Position eines Kommentarmarkers auf einer Folie definiert?**

Die Marker‑Position wird durch Gleitkomma‑Koordinaten im Folien‑Koordinatensystem definiert, sodass Sie sie exakt auf der Folie platzieren können.