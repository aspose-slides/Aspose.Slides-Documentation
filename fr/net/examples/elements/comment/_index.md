---
title: Commentaire
type: docs
weight: 230
url: /fr/net/examples/elements/comment/
keywords:
- commentaire
- commentaire moderne
- ajouter un commentaire
- accéder au commentaire
- supprimer un commentaire
- répondre au commentaire
- exemple de code
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Travailler avec les commentaires de diapositives dans Aspose.Slides for .NET : ajouter, répondre, modifier, résoudre et exporter les commentaires dans les présentations PPT, PPTX et ODP avec des exemples de code C#."
---
Cet article montre comment ajouter, lire, supprimer et répondre aux commentaires modernes à l'aide de **Aspose.Slides for .NET**.

## **Ajouter un commentaire moderne**

Créez un commentaire rédigé par un utilisateur et enregistrez la présentation.

```csharp
static void AddModernComment()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var author = presentation.CommentAuthors.AddAuthor("User", "U1");
    author.Comments.AddModernComment("This is a modern comment", slide, null, new PointF(100, 100), DateTime.Now);

    presentation.Save("modern_comment.pptx", SaveFormat.Pptx);
}
```

## **Accéder à un commentaire moderne**

Lisez un commentaire moderne à partir d'une présentation existante.

```csharp
static void AccessModernComment()
{
    using var presentation = new Presentation("modern_comment.pptx");
    var author = presentation.CommentAuthors[0];

    var comment = (IModernComment)author.Comments[0];
    Console.WriteLine($"Author: {author.Name}, Comment: {comment.Text}, Position: {comment.Position}");
}
```

## **Supprimer un commentaire moderne**

Supprimez un commentaire et enregistrez le fichier mis à jour.

```csharp
static void RemoveModernComment()
{
    using var presentation = new Presentation("modern_comment.pptx");
    var author = presentation.CommentAuthors[0];

    var comment = author.Comments[0];
    comment.Remove();

    presentation.Save("modern_comment_removed.pptx", SaveFormat.Pptx);
}
```

## **Répondre à un commentaire moderne**

Ajoutez des réponses à un commentaire moderne parent.

```csharp
static void ReplyToModernComment()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var author = presentation.CommentAuthors.AddAuthor("User", "U1");

    var parentComment = author.Comments.AddModernComment("Parent comment", slide, null, new PointF(100, 100), DateTime.Now);
    var reply1 = author.Comments.AddModernComment("Reply 1", slide, null, new PointF(110, 100), DateTime.Now);
    var reply2 = author.Comments.AddModernComment("Reply 2", slide, null, new PointF(120, 100), DateTime.Now);

    reply1.ParentComment = parentComment;
    reply2.ParentComment = parentComment;

    presentation.Save("modern_comment_replies.pptx", SaveFormat.Pptx);
}
```