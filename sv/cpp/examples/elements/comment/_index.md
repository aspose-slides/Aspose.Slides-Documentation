---
title: Kommentar
type: docs
weight: 230
url: /sv/cpp/examples/elements/comment/
keywords:
- kodexempel
- kommentar
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Arbeta med bildkommentarer i Aspose.Slides för C++: lägg till, svara, redigera, lösa och exportera kommentarer i PPT, PPTX och ODP-presentationer med C++-kodexempel."
---
Denna artikel demonstrerar hur man lägger till, läser, tar bort och svarar på moderna kommentarer med **Aspose.Slides for C++**.

## **Lägg till en modern kommentar**

Skapa en kommentar skriven av en användare och spara presentationen.

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

## **Åtkomst till en modern kommentar**

Läs en modern kommentar från en befintlig presentation.

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

## **Ta bort en modern kommentar**

Ta bort en kommentar och spara den uppdaterade filen.

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

## **Svara på en modern kommentar**

Lägg till svar på en överordnad modern kommentar.

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