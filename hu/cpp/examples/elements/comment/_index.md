---
title: Megjegyzés
type: docs
weight: 230
url: /hu/cpp/examples/elements/comment/
keywords:
- kód példa
- megjegyzés
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Dolgozzon a diák megjegyzéseivel az Aspose.Slides for C++-ban: adjon hozzá, válaszoljon, szerkesszen, oldjon meg, és exportáljon megjegyzéseket PPT, PPTX és ODP prezentációkban C++ kódpéldákkal."
---
Ez a cikk bemutatja a modern megjegyzések hozzáadását, olvasását, eltávolítását és válaszolását a **Aspose.Slides for C++** használatával.

## **Modern megjegyzés hozzáadása**

Hozzon létre egy felhasználó által írt megjegyzést, és mentse a prezentációt.

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

## **Modern megjegyzés elérése**

Olvasson egy modern megjegyzést egy meglévő prezentációból.

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

## **Modern megjegyzés eltávolítása**

Távolítson el egy megjegyzést, és mentse a frissített fájlt.

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

## **Válasz egy modern megjegyzésre**

Adjon válaszokat egy szülő modern megjegyzéshez.

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