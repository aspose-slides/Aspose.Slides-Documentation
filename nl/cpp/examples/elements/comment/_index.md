---
title: Opmerking
type: docs
weight: 230
url: /nl/cpp/examples/elements/comment/
keywords:
- codevoorbeeld
- opmerking
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Werk met dia-opmerkingen in Aspose.Slides voor C++: toevoegen, antwoorden, bewerken, oplossen en opmerkingen exporteren in PPT-, PPTX- en ODP-presentaties met C++-codevoorbeelden."
---
Dit artikel toont het toevoegen, lezen, verwijderen en beantwoorden van moderne opmerkingen met **Aspose.Slides for C++**.

## **Moderne opmerking toevoegen**

Maak een opmerking gemaakt door een gebruiker en sla de presentatie op.

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

## **Toegang tot een moderne opmerking**

Lees een moderne opmerking uit een bestaande presentatie.

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

## **Een moderne opmerking verwijderen**

Verwijder een opmerking en sla het bijgewerkte bestand op.

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

## **Reageren op een moderne opmerking**

Voeg antwoorden toe aan een bovenliggende moderne opmerking.

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