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
- Kommentar abrufen
- Kommentar bearbeiten
- Kommentar beantworten
- Kommentar entfernen
- Kommentar löschen
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Verwalten Sie Präsentationskommentare mit Aspose.Slides für C++: Kommentare in PowerPoint-Präsentationen schnell und einfach hinzufügen, lesen, bearbeiten, beantworten und entfernen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Kommentare in Präsentationen mit Aspose.Slides für C++ verwaltet werden. Er stellt die wichtigsten kommentarbezogenen Typen vor und zeigt, wie Kommentare zu Folien hinzugefügt, vorhandene Kommentare abgerufen, mit Antworten und modernen Kommentaren gearbeitet und Kommentare aus einer Präsentation entfernt werden.

Die Beispiele decken gängige Szenarien für Überprüfung und Zusammenarbeit in PowerPoint ab, wie das Zuweisen von Kommentaren zu Autoren, das Auslesen von Kommentartext und Metadaten, das Erstellen von Antwortketten und das Entfernen ausgewählter Kommentare oder aller Kommentare.

In PowerPoint erscheinen Kommentare als Anmerkungen auf Folien. Durch Auswählen eines Kommentars wird dessen Text und die zugehörige Diskussion angezeigt.

Um zu verlangen, dass Kommentare beim Öffnen einer Präsentation ein- oder ausgeblendet werden, ohne die Kommentare selbst zu ändern, siehe [Show or Hide Comments When Opening a Presentation](/slides/de/cpp/presentation-view-properties/).

## **Warum Kommentare zu Präsentationen hinzufügen?**

Sie können Kommentare verwenden, um Feedback zu geben und mit Kollegen bei der Durchsicht von Präsentationen zusammenzuarbeiten.

Aspose.Slides für C++ bietet die folgenden APIs zum Arbeiten mit Kommentaren:

* Die [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Klasse, die Zugriff auf die Kommentarautoren der Präsentation bietet.
* Die [ICommentCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/icommentcollection/) Schnittstelle, die die Kommentare eines einzelnen Autors darstellt.
* Die [IComment](https://reference.aspose.com/slides/de/cpp/aspose.slides/icomment/) Schnittstelle, die Informationen zu einem Kommentar liefert, einschließlich Autor, Erstellungszeit, Position und Text.
* Die [CommentAuthor](https://reference.aspose.com/slides/de/cpp/aspose.slides/commentauthor/) Klasse, die Informationen zu einem Autor liefert, einschließlich Name, Initialen und zugehöriger Kommentare.

## **Folienkommentare hinzufügen**

Das folgende Beispiel zeigt, wie Kommentare zu Folien in einer PowerPoint‑Präsentation hinzugefügt werden:

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

## **Zugriff auf Folienkommentare**

Das folgende Beispiel zeigt, wie vorhandene Kommentare in einer PowerPoint‑Präsentation abgerufen werden:

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

Ein übergeordneter Kommentar ist der ursprüngliche Kommentar an der Spitze einer Antwort‑Hierarchie. Die [get_ParentComment](https://reference.aspose.com/slides/de/cpp/aspose.slides/icomment/get_parentcomment/) und [set_ParentComment](https://reference.aspose.com/slides/de/cpp/aspose.slides/icomment/set_parentcomment/) Methoden der [IComment](https://reference.aspose.com/slides/de/cpp/aspose.slides/icomment/) Schnittstelle ermöglichen das Abrufen bzw. Festlegen des übergeordneten Kommentars.

Das folgende Beispiel zeigt, wie Antworten hinzugefügt und die resultierende Kommentar‑Hierarchie inspiziert werden:

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
* Wenn die [Remove](https://reference.aspose.com/slides/de/cpp/aspose.slides/icomment/remove/) Methode der [IComment](https://reference.aspose.com/slides/de/cpp/aspose.slides/icomment/) Schnittstelle verwendet wird, um einen Kommentar zu löschen, werden auch alle Antworten auf diesen Kommentar gelöscht.
* Wenn die [set_ParentComment](https://reference.aspose.com/slides/de/cpp/aspose.slides/icomment/set_parentcomment/) Methode eine zirkuläre Referenz erzeugt, wird eine [PptxEditException](https://reference.aspose.com/slides/de/cpp/aspose.slides/pptxeditexception/) ausgelöst.
{{% /alert %}}

## **Moderne Kommentare hinzufügen**

Moderne Kommentare können der Folie selbst, einer bestimmten Form oder einem Textbereich innerhalb einer AutoShape zugeordnet werden. Die [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/de/cpp/aspose.slides/icommentcollection/addmoderncomment/) Methode akzeptiert ein [IShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/) Argument zusätzlich zu den Folien‑ und Marker‑Koordinaten.

Wird für das Shape‑Argument `nullptr` übergeben, ist der Kommentar ein Folien‑Kommentar. Sein Marker wird anhand der angegebenen Koordinaten positioniert, ist jedoch keiner bestimmten Form zugeordnet, sodass [IModernComment::get_Shape](https://reference.aspose.com/slides/de/cpp/aspose.slides/imoderncomment/get_shape/) `nullptr` zurückgibt. Wird ein [IShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/) übergeben, wird der Kommentar an dieser Form verankert. Die Koordinaten bestimmen weiterhin die Position des Kommentar‑Markers auf der Folie, während die Formzuordnung über [IModernComment::get_Shape](https://reference.aspose.com/slides/de/cpp/aspose.slides/imoderncomment/get_shape/) abgerufen werden kann.

### **Ein modernes Kommentar an einer Form verankern**

Das folgende Beispiel erstellt sowohl einen Folien‑Kommentar als auch einen modernen Kommentar, der an einer bestimmten AutoShape verankert ist. Anschließend wird die zugehörige Form aus jedem Kommentar ausgelesen.

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

### **Kommentare an verschiedenen Formtypen verankern**

Jedes Folien‑Objekt, das [IShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/) implementiert, kann als Formverankerung verwendet werden. Häufige Beispiele sind [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/de/cpp/aspose.slides/iconnector/) und [IGraphicalObject](https://reference.aspose.com/slides/de/cpp/aspose.slides/igraphicalobject/) Instanzen wie Diagramme.

Das folgende Beispiel erstellt mehrere gängige Formtypen und ordnet jedem einen modernen Kommentar zu.

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

### **Einen Kommentar an Text verankern und seinen Status festlegen**

Für einen modernen Kommentar, der mit einer [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) verknüpft ist, steuern [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/de/cpp/aspose.slides/imoderncomment/get_textselectionstart/) und [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/de/cpp/aspose.slides/imoderncomment/set_textselectionstart/) die Startposition des ausgewählten Textes im Textfeld der Form. Ebenso steuern [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/de/cpp/aspose.slides/imoderncomment/get_textselectionlength/) und [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/de/cpp/aspose.slides/imoderncomment/set_textselectionlength/) die Länge der Auswahl. Zusammen ordnen diese Methoden den Kommentar einem bestimmten Textbereich innerhalb der AutoShape zu.

Die [IModernComment::get_Status](https://reference.aspose.com/slides/de/cpp/aspose.slides/imoderncomment/get_status/) und [IModernComment::set_Status](https://reference.aspose.com/slides/de/cpp/aspose.slides/imoderncomment/set_status/) Methoden verwenden einen Wert aus der Aufzählung [ModernCommentStatus](https://reference.aspose.com/slides/de/cpp/aspose.slides/moderncommentstatus/):

- `NotDefined` — Es ist kein spezifischer moderner Kommentar‑Status definiert.
- `Active` — Der Kommentar ist aktiv.
- `Resolved` — Der Kommentar wurde als erledigt markiert.
- `Closed` — Der Kommentar ist geschlossen.

Das folgende Beispiel erstellt einen an einer Form verankerten modernen Kommentar, ordnet ihn einer Textauswahl zu, markiert ihn als erledigt, speichert die Präsentation und prüft die Werte nach erneutem Öffnen der Datei.

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

### **Vorhandene moderne Kommentare prüfen**

Um eine bestehende Präsentation zu untersuchen, prüfen Sie, welche Kommentare [IModernComment](https://reference.aspose.com/slides/de/cpp/aspose.slides/imoderncomment/) implementieren, und betrachten Sie anschließend [IModernComment::get_Shape](https://reference.aspose.com/slides/de/cpp/aspose.slides/imoderncomment/get_shape/), [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/de/cpp/aspose.slides/imoderncomment/get_textselectionstart/), [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/de/cpp/aspose.slides/imoderncomment/get_textselectionlength/) sowie [IModernComment::get_Status](https://reference.aspose.com/slides/de/cpp/aspose.slides/imoderncomment/get_status/). Ein `nullptr` Shape bedeutet, dass es sich um einen Folien‑Kommentar handelt. Bei einer [IAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/iautoshape/) Verankerung geben die Textauswahl‑Methoden den zugehörigen Bereich im Textfeld der Form an.

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

### **Alle Kommentare und Kommentarautoren entfernen**

Das folgende Beispiel zeigt, wie alle Kommentare und Kommentarautoren aus einer Präsentation entfernt werden:

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

### **Bestimmte Kommentare entfernen**

Das folgende Beispiel zeigt, wie bestimmte Kommentare von einer Folie entfernt werden:

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

**Unterstützt Aspose.Slides einen „Resolved“-Status für moderne Kommentare?**

Ja. Die [IModernComment::get_Status](https://reference.aspose.com/slides/de/cpp/aspose.slides/imoderncomment/get_status/) und [IModernComment::set_Status](https://reference.aspose.com/slides/de/cpp/aspose.slides/imoderncomment/set_status/) Methoden verwenden einen Wert aus der Aufzählung [ModernCommentStatus](https://reference.aspose.com/slides/de/cpp/aspose.slides/moderncommentstatus/), einschließlich `Resolved`. Der Status wird in der Präsentation gespeichert und kann nach erneutem Öffnen der Datei wieder ausgelesen werden.

**Werden verschachtelte Diskussionen (Antwortketten) unterstützt und gibt es eine Begrenzung für die Verschachtelungstiefe?**

Ja. Jeder Kommentar kann auf seinen [parent comment](https://reference.aspose.com/slides/de/cpp/aspose.slides/icomment/set_parentcomment/) verweisen, wodurch Antwortketten ermöglicht werden. Die API definiert keine spezifische Begrenzung der Verschachtelungstiefe.

**In welchem Koordinatensystem ist die Position eines Kommentar‑Markers auf einer Folie definiert?**

Die Marker‑Position wird durch Gleitkomma‑Koordinaten im Folien‑Koordinatensystem definiert, sodass Sie ihn exakt auf der Folie platzieren können.