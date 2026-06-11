---
title: Komentarz
type: docs
weight: 230
url: /pl/cpp/examples/elements/comment/
keywords:
- przykład kodu
- komentarz
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Pracuj z komentarzami slajdów w Aspose.Slides for C++: dodawaj, odpowiadaj, edytuj, rozwiązuj i eksportuj komentarze w prezentacjach PPT, PPTX i ODP przy użyciu przykładów kodu C++."
---
Ten artykuł demonstruje dodawanie, odczytywanie, usuwanie i odpowiadanie na nowoczesne komentarze przy użyciu **Aspose.Slides for C++**.

## **Dodaj nowoczesny komentarz**

Utwórz komentarz autorstwa użytkownika i zapisz prezentację.

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

## **Uzyskaj dostęp do nowoczesnego komentarza**

Odczytaj nowoczesny komentarz z istniejącej prezentacji.

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

## **Usuń nowoczesny komentarz**

Usuń komentarz i zapisz zaktualizowany plik.

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

## **Odpowiedz na nowoczesny komentarz**

Dodaj odpowiedzi do nadrzędnego nowoczesnego komentarza.

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