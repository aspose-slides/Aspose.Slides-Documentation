---
title: Komentář
type: docs
weight: 230
url: /cs/cpp/examples/elements/comment/
keywords:
- ukázka kódu
- komentář
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Práce s komentáři snímků v Aspose.Slides pro C++: přidávejte, odpovídejte, upravujte, řešte a exportujte komentáře v prezentacích PPT, PPTX a ODP pomocí ukázek kódu v C++."
---
Tento článek ukazuje, jak přidávat, číst, odstraňovat a odpovídat na moderní komentáře pomocí **Aspose.Slides for C++**.

## **Přidat moderní komentář**

Vytvořte komentář od uživatele a uložte prezentaci.

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

## **Přístup k modernímu komentáři**

Přečtěte moderní komentář ze stávající prezentace.

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

## **Odstranit moderní komentář**

Odstraňte komentář a uložte aktualizovaný soubor.

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

## **Odpovědět na moderní komentář**

Přidejte odpovědi k nadřazenému modernímu komentáři.

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