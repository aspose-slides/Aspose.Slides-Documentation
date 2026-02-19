---
title: Commentaire
type: docs
weight: 230
url: /fr/cpp/examples/elements/comment/
keywords:
- exemple de code
- commentaire
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Travaillez avec les commentaires de diapositive dans Aspose.Slides for C++ : ajoutez, répondez, modifiez, résolvez et exportez les commentaires dans les présentations PPT, PPTX et ODP avec des exemples de code C++."
---
Cet article montre comment ajouter, lire, supprimer et répondre aux commentaires modernes à l'aide de **Aspose.Slides for C++**.

## **Ajouter un commentaire moderne**

Créez un commentaire rédigé par un utilisateur et enregistrez la présentation.

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

## **Accéder à un commentaire moderne**

Lisez un commentaire moderne à partir d'une présentation existante.

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

## **Supprimer un commentaire moderne**

Supprimez un commentaire et enregistrez le fichier mis à jour.

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

## **Répondre à un commentaire moderne**

Ajoutez des réponses à un commentaire moderne parent.

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