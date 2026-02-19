---
title: Kommentar
type: docs
weight: 230
url: /de/cpp/examples/elements/comment/
keywords:
- Codebeispiel
- Kommentar
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Arbeiten Sie mit Folienkommentaren in Aspose.Slides für C++: Hinzufügen, Antworten, Bearbeiten, Auflösen und Exportieren von Kommentaren in PPT-, PPTX- und ODP-Präsentationen mit C++-Codebeispielen."
---
Dieser Artikel demonstriert das Hinzufügen, Lesen, Entfernen und Antworten auf moderne Kommentare mit **Aspose.Slides for C++**.

## **Modernen Kommentar hinzufügen**

Erstellen Sie einen von einem Benutzer verfassten Kommentar und speichern Sie die Präsentation.

```cpp
static void AddModernComment()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto author = presentation->get_CommentAuthors()->AddAuthor(u"User", u"U1");

    author->get_Comments()->AddModernComment(
        u"This is a modern comment", slide, nullptr, PointF(100, 100), DateTime::get_Now());

    presentation->Save(u"modern_comment.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **Auf einen modernen Kommentar zugreifen**

Lesen Sie einen modernen Kommentar aus einer vorhandenen Präsentation.

```cpp
static void AccessModernComment()
{
    auto presentation = MakeObject<Presentation>(u"modern_comment.pptx");

    auto author = presentation->get_CommentAuthor(0);
    auto comment = ExplicitCast<SharedPtr<IModernComment>>(author->get_Comment(0));

    Console::WriteLine(u"Author: {0}, Comment: {1}, Position: {2}",
        author->get_Name(), comment->get_Text(), comment->get_Position());

    presentation->Dispose();
}
```

## **Modernen Kommentar entfernen**

Entfernen Sie einen Kommentar und speichern Sie die aktualisierte Datei.

```cpp
static void RemoveModernComment()
{
    auto presentation = MakeObject<Presentation>(u"modern_comment.pptx");
    auto author = presentation->get_CommentAuthor(0);

    auto comment = author->get_Comment(0);
    comment->Remove();

    presentation->Save(u"modern_comment_removed.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **Auf einen modernen Kommentar antworten**

Fügen Sie Antworten zu einem übergeordneten modernen Kommentar hinzu.

```cpp
static void ReplyToModernComment()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto author = presentation->get_CommentAuthors()->AddAuthor(u"User", u"U1");

    auto parentComment = author->get_Comments()->AddModernComment(
        u"Parent comment", slide, nullptr, PointF(100, 100), DateTime::get_Now());

    auto reply1 = author->get_Comments()->AddModernComment(
        u"Reply 1", slide, nullptr, PointF(110, 100), DateTime::get_Now());

    auto reply2 = author->get_Comments()->AddModernComment(
        u"Reply 2", slide, nullptr, PointF(120, 100), DateTime::get_Now());

    reply1->set_ParentComment(parentComment);
    reply2->set_ParentComment(parentComment);

    presentation->Save(u"modern_comment_replies.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```