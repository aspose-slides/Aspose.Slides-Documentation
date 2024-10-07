---
title: Präsentationskommentare
type: docs
weight: 100
url: /cpp/presentation-comments/
keywords: "Kommentare, PowerPoint-Kommentare, PowerPoint-Präsentation, C++, Aspose.Slides für C++"
description: "Fügen Sie Kommentare und Antworten in PowerPoint-Präsentationen in C++ hinzu"
---

In PowerPoint erscheint ein Kommentar als Notiz oder Anmerkung auf einer Folie. Wenn ein Kommentar angeklickt wird, werden dessen Inhalte oder Nachrichten angezeigt.

### **Warum Kommentare zu Präsentationen hinzufügen?**

Sie möchten möglicherweise Kommentare verwenden, um Feedback zu geben oder mit Ihren Kollegen zu kommunizieren, wenn Sie Präsentationen überprüfen.

Um Ihnen die Verwendung von Kommentaren in PowerPoint-Präsentationen zu ermöglichen, bietet Aspose.Slides für C++ 

* Die [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse, die Sammlungen von Autoren enthält (aus der [get_CommentAuthors()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d) Methode). Die Autoren fügen Folien Kommentare hinzu. 
* Die [ICommentCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment_collection) Schnittstelle, die die Sammlung von Kommentaren für einzelne Autoren enthält. 
* Die [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment) Klasse, die Informationen zu Autoren und ihren Kommentaren enthält: Wer den Kommentar hinzugefügt hat, wann der Kommentar hinzugefügt wurde, die Position des Kommentars usw. 
* Die [CommentAuthor](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_author) Klasse, die Informationen zu einzelnen Autoren enthält: den Namen des Autors, seine Initialen, Kommentare, die mit dem Namen des Autors verbunden sind, usw.

## **Kommentar zu Folie hinzufügen**
Dieser C++-Code zeigt Ihnen, wie Sie einen Kommentar zu einer Folie in einer PowerPoint-Präsentation hinzufügen:

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
author->get_Comments()->AddComment(u"Hallo Jawad, dies ist ein Folienkommentar", slide1, point, DateTime::get_Now());

// Fügt einen Folienkommentar für einen Autor auf Folie 2 hinzu
author->get_Comments()->AddComment(u"Hallo Jawad, dies ist der zweite Folienkommentar", slide2, point, DateTime::get_Now());

// Wenn null als Argument übergeben wird, werden Kommentare von allen Autoren auf die ausgewählte Folie geholt
auto comments = slide1->GetSlideComments(author);

// Greift auf den Kommentar an Index 0 für Folie 1 zu
String str = comments[0]->get_Text();

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);

if (comments->GetLength(0) > 0)
{
    // Wählt die Kommentarsammlung des Autors am Index 0 aus
    auto commentCollection = comments[0]->get_Author()->get_Comments();
    String Comment = commentCollection->idx_get(0)->get_Text();
}
```

## **Zugriff auf Folienkommentare**
Dieser C++-Code zeigt Ihnen, wie Sie auf einen vorhandenen Kommentar auf einer Folie in einer PowerPoint-Präsentation zugreifen:

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
                        + u" hat Kommentar: " + comment->get_Text()
                        + u" mit Autor: " + comment->get_Author()->get_Name()
                        + u" gepostet zur Zeit :" + comment->get_CreatedTime() + u"\n");
    }
}
```


## **Antworten auf Kommentare**
Ein Elternkommentar ist der oberste oder ursprüngliche Kommentar in einer Hierarchie von Kommentaren oder Antworten. Mithilfe der [ParentComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) Eigenschaft (aus der [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment) Schnittstelle) können Sie einen Elternkommentar festlegen oder abrufen.

Dieser C++-Code zeigt Ihnen, wie Sie Kommentare hinzufügen und Antworten darauf erhalten:

```cpp
auto pres = System::MakeObject<Presentation>();

// Greift auf ISlide 1 zu
auto slide1 = pres->get_Slides()->idx_get(0);

// Fügt einen Kommentar hinzu
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Autor_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"Kommentar 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// Fügt eine Antwort auf comment1 hinzu
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Autror_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"Antwort 1 für Kommentar 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// Fügt eine weitere Antwort auf comment1 hinzu
auto reply2 = author2->get_Comments()->AddComment(u"Antwort 2 für Kommentar 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// Fügt eine Antwort auf die vorhandene Antwort hinzu
auto subReply = author1->get_Comments()->AddComment(u"Unterantwort 3 für Antwort 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"Kommentar 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"Kommentar 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"Antwort 4 für Kommentar 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply3->set_ParentComment(comment3);

// Zeigt die Kommentarthierarchie auf der Konsole an
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
* Wenn die [ParentComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) Einstellung zu einer zirkulären Referenz führt, wird eine [PptxEditException](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) ausgelöst.

{{% /alert %}}

## **Moderner Kommentar hinzufügen**

Im Jahr 2021 führte Microsoft *moderne Kommentare* in PowerPoint ein. Die Funktion moderne Kommentare verbessert die Zusammenarbeit in PowerPoint erheblich. Durch moderne Kommentare können PowerPoint-Benutzer Kommentare lösen, Kommentare an Objekte und Texte anheften und einfacher interagieren als zuvor. 

In [Aspose Slides für C++ 21.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-11-release-notes/) haben wir die Unterstützung für moderne Kommentare implementiert, indem wir die [ModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.modern_comment) Klasse hinzugefügt haben. Die [AddModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection#a3627fcb3b05cd639fd430bd8248fe66b) und [InsertModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection#ad11c3efb52f3c17f63238447dcc03c94) Methoden wurden zur [CommentCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection) Klasse hinzugefügt.

Dieser C++-Code zeigt Ihnen, wie Sie einen modernen Kommentar zu einer Folie in einer PowerPoint-Präsentation hinzufügen: 

```cpp
auto pres = System::MakeObject<Presentation>();
// Greift auf ISlide 1 zu
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"Ein Autor", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"Dies ist ein moderner Kommentar", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Kommentar entfernen**

### **Alle Kommentare und Autoren löschen**

Dieser C++-Code zeigt Ihnen, wie Sie alle Kommentare und Autoren in einer Präsentation entfernen:

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

Dieser C++-Code zeigt Ihnen, wie Sie bestimmte Kommentare auf einer Folie löschen:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
// Kommentare hinzufügen...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Autor", u"A");
author->get_Comments()->AddComment(u"Kommentar 1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"Kommentar 2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
// Entfernt alle Kommentare, die den Text "Kommentar 1" enthalten
for (auto commentAuthor : presentation->get_CommentAuthors())
{
    auto toRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IComment>>>();
    for (auto comment : slide->GetSlideComments(commentAuthor))
    {
        if (comment->get_Text() == u"Kommentar 1")
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