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
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Verwalten Sie Präsentationskommentare mit Aspose.Slides für C++: Kommentare in PowerPoint-Dateien schnell und einfach hinzufügen, lesen, bearbeiten und löschen."
---

In PowerPoint erscheint ein Kommentar als Hinweis oder Anmerkung auf einer Folie. Wenn ein Kommentar angeklickt wird, werden dessen Inhalt oder Nachrichten angezeigt. 

### **Warum Kommentare zu Präsentationen hinzufügen?**

Möglicherweise möchten Sie Kommentare verwenden, um Feedback zu geben oder mit Ihren Kollegen zu kommunizieren, wenn Sie Präsentationen überprüfen.

Damit Sie Kommentare in PowerPoint‑Präsentationen verwenden können, bietet Aspose.Slides für C++:

* Die [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse, die die Sammlungen der Autoren enthält (aus der Methode [get_CommentAuthors()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d)). Die Autoren fügen Folien Kommentare hinzu. 
* Die [ICommentCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment_collection) Schnittstelle, die die Sammlung von Kommentaren für einzelne Autoren enthält. 
* Die [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment) Klasse, die Informationen zu Autoren und deren Kommentaren enthält: wer den Kommentar hinzugefügt hat, wann der Kommentar hinzugefügt wurde, die Position des Kommentars usw. 
* Die [CommentAuthor](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_author) Klasse, die Informationen zu einzelnen Autoren enthält: den Namen des Autors, seine Initialen, dem Namen zugeordnete Kommentare usw. 

## **Ein Folienkommentar hinzufügen**
Dieser C++‑Code zeigt, wie Sie einen Kommentar zu einer Folie in einer PowerPoint‑Präsentation hinzufügen:
```cpp
// Instanziiert die Presentation-Klasse
auto presentation = System::MakeObject<Presentation>();
// Fügt eine leere Folie hinzu
presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlides()->idx_get(0));

// Fügt einen Autor hinzu
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");

// Setzt die Position für Kommentare
PointF point;
point.set_X(0.2f);
point.set_Y(0.2f);

// Greift auf ISlide 1 zu
auto slide1 = presentation->get_Slides()->idx_get(0);
// Greift auf ISlide 2 zu
auto slide2 = presentation->get_Slides()->idx_get(1);

// Fügt einen Folienkommentar für einen Autor auf Folie 1 hinzu
author->get_Comments()->AddComment(u"Hello Jawad, this is slide comment", slide1, point, DateTime::get_Now());

// Fügt einen Folienkommentar für einen Autor auf Folie 2 hinzu
author->get_Comments()->AddComment(u"Hello Jawad, this is second slide comment", slide2, point, DateTime::get_Now());

// Wenn null als Argument übergeben wird, werden Kommentare aller Autoren zur ausgewählten Folie gebracht
auto comments = slide1->GetSlideComments(author);

// Greift auf den Kommentar mit Index 0 für Folie 1 zu
String str = comments[0]->get_Text();

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);

if (comments->GetLength(0) > 0)
{
    // Wählt die Kommentar-Sammlung des Autors mit Index 0 aus
    auto commentCollection = comments[0]->get_Author()->get_Comments();
    String Comment = commentCollection->idx_get(0)->get_Text();
}
```


## **Zugriff auf Folienkommentare**
Dieser C++‑Code zeigt, wie Sie auf einen vorhandenen Kommentar einer Folie in einer PowerPoint‑Präsentation zugreifen:
```cpp
// Instanziiert die Presentation-Klasse
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


## **Antwortkommentare**
Ein übergeordneter Kommentar ist der oberste bzw. ursprüngliche Kommentar in einer Hierarchie von Kommentaren oder Antworten. Mit der [ParentComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) Eigenschaft (aus der [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment) Schnittstelle) können Sie einen übergeordneten Kommentar festlegen oder abrufen. 

Dieser C++‑Code zeigt, wie Sie Kommentare hinzufügen und Antworten darauf erhalten:
```cpp
auto pres = System::MakeObject<Presentation>();

// Greift auf ISlide 1 zu
auto slide1 = pres->get_Slides()->idx_get(0);

// Fügt einen Kommentar hinzu
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// Fügt eine Antwort zu comment1 hinzu
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Autror_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// Fügt eine weitere Antwort zu comment1 hinzu
auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// Fügt eine Antwort auf eine bestehende Antwort hinzu
auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"comment 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply3->set_ParentComment(comment3);

// Zeigt die Kommentarhierarchie in der Konsole an
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

// Entfernt comment1 und alle Antworten darauf
comment1->Remove();

pres->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```


{{% alert color="warning" title="Achtung" %}} 

* Wenn die [Remove](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#a8bb818ae804d142195c4edcf9012cccb) Methode (aus der [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment) Schnittstelle) verwendet wird, um einen Kommentar zu löschen, werden auch die Antworten auf den Kommentar gelöscht. 
* Wenn die Einstellung von [ParentComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) zu einer zirkulären Referenz führt, wird eine [PptxEditException](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) ausgelöst.

{{% /alert %}}

## **Einen modernen Kommentar hinzufügen**

Im Jahr 2021 hat Microsoft *moderne Kommentare* in PowerPoint eingeführt. Die Funktion für moderne Kommentare verbessert die Zusammenarbeit in PowerPoint erheblich. Durch moderne Kommentare können PowerPoint‑Benutzer Kommentare auflösen, Kommentare an Objekten und Texten verankern und viel einfacher interagieren als zuvor. 

In [Aspose Slides for C++ 21.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-11-release-notes/) haben wir Unterstützung für moderne Kommentare implementiert, indem wir die [ModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.modern_comment) Klasse hinzugefügt haben. Die Methoden [AddModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection#a3627fcb3b05cd639fd430bd8248fe66b) und [InsertModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection#ad11c3efb52f3c17f63238447dcc03c94) wurden zur [CommentCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection) Klasse hinzugefügt.

Dieser C++‑Code zeigt, wie Sie einen modernen Kommentar zu einer Folie in einer PowerPoint‑Präsentation hinzufügen: 
```cpp
auto pres = System::MakeObject<Presentation>();
// Greift auf ISlide 1 zu
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"Some Author", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"This is a modern comment", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **Einen Kommentar entfernen**

### **Alle Kommentare und Autoren löschen**

Dieser C++‑Code zeigt, wie Sie alle Kommentare und Autoren in einer Präsentation entfernen:
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// Löscht alle Kommentare aus der Präsentation
for (auto author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}
        
// Löscht alle Autoren
presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```


### **Bestimmte Kommentare löschen**

Dieser C++‑Code zeigt, wie Sie bestimmte Kommentare auf einer Folie löschen:
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
// Kommentare hinzufügen...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
author->get_Comments()->AddComment(u"comment 1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"comment 2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
// Entferne alle Kommentare, die den Text "comment 1" enthalten
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

**Unterstützt Aspose.Slides einen Status wie „gelöst“ für moderne Kommentare?**

Ja. [Modern comments](https://reference.aspose.com/slides/cpp/aspose.slides/moderncomment/) stellen die Methoden [get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/moderncomment/get_status/) und [set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/moderncomment/set_status/) bereit; Sie können den [Zustand eines Kommentars](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/) (z. B. als „gelöst“ markieren) auslesen und setzen, und dieser Zustand wird in der Datei gespeichert und von PowerPoint erkannt.

**Werden Threaded Discussions (Antwortketten) unterstützt und gibt es ein Begrenzung der Verschachtelung?**

Ja. Jeder Kommentar kann auf seinen [parent comment](https://reference.aspose.com/slides/cpp/aspose.slides/comment/set_parentcomment/) verweisen, was beliebige Antwortketten ermöglicht. Die API legt keine spezifische Begrenzung der Verschachtelungstiefe fest.

**In welchem Koordinatensystem ist die Position eines Kommentarmarkers auf einer Folie definiert?**

Die Position wird als Fließkommapunkt im Koordinatensystem der Folie gespeichert. Dadurch können Sie den Kommentarmarker genau dort platzieren, wo Sie ihn benötigen.