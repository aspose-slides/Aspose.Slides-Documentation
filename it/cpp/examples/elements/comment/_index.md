---
title: Commento
type: docs
weight: 230
url: /it/cpp/examples/elements/comment/
keywords:
- esempio di codice
- commento
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Lavora con i commenti delle diapositive in Aspose.Slides per C++: aggiungi, rispondi, modifica, risolvi ed esporta i commenti in presentazioni PPT, PPTX e ODP con esempi di codice C++."
---
Questo articolo dimostra come aggiungere, leggere, rimuovere e rispondere ai commenti moderni utilizzando **Aspose.Slides for C++**.

## **Aggiungi un commento moderno**

Crea un commento scritto da un utente e salva la presentazione.

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

## **Accedi a un commento moderno**

Leggi un commento moderno da una presentazione esistente.

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

## **Rimuovi un commento moderno**

Rimuovi un commento e salva il file aggiornato.

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

## **Rispondi a un commento moderno**

Aggiungi risposte a un commento moderno principale.

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