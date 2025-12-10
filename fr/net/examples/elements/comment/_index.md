---
title: Commentaire
type: docs
weight: 230
url: /fr/net/examples/elements/comment/
keywords:
- exemple de commentaire
- commentaire moderne
- ajouter un commentaire
- accès au commentaire
- supprimer le commentaire
- répondre au commentaire
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Gérez les commentaires de diapositives en C# avec Aspose.Slides : ajoutez, lisez, répondez, modifiez, supprimez et travaillez avec des commentaires en fil pour PowerPoint et OpenDocument."
---

Démontre comment ajouter, lire, supprimer et répondre aux commentaires modernes à l'aide de **Aspose.Slides for .NET**.

## **Add a Modern Comment**
Créez un commentaire rédigé par un utilisateur et enregistrez la présentation.
```csharp
static void Add_Modern_Comment()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var author = pres.CommentAuthors.AddAuthor("User", "U1");
    author.Comments.AddModernComment("This is a modern comment", slide, null, new PointF(100, 100), DateTime.Now);

    pres.Save("modern_comment.pptx", SaveFormat.Pptx);
}
```


## **Access a Modern Comment**
Lisez un commentaire moderne à partir d'une présentation existante.
```csharp
static void Access_Modern_Comment()
{
    using var pres = new Presentation("modern_comment.pptx");
    var author = pres.CommentAuthors[0];

    var comment = (IModernComment)author.Comments[0];
    Console.WriteLine($"Author: {author.Name}, Comment: {comment.Text}, Position: {comment.Position}");
}
```


## **Remove a Modern Comment**
Supprimez un commentaire et enregistrez le fichier mis à jour.
```csharp
static void Remove_Modern_Comment()
{
    using var pres = new Presentation("modern_comment.pptx");
    var author = pres.CommentAuthors[0];

    var comment = author.Comments[0];
    comment.Remove();

    pres.Save("modern_comment_removed.pptx", SaveFormat.Pptx);
}
```


## **Reply to a Modern Comment**
Ajoutez des réponses à un commentaire moderne parent.
```csharp
static void Reply_To_Modern_Comment()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var author = pres.CommentAuthors.AddAuthor("User", "U1");

    var parent = author.Comments.AddModernComment("Parent comment", slide, null, new PointF(100, 100), DateTime.Now);
    var reply1 = author.Comments.AddModernComment("Reply 1", slide, null, new PointF(110, 100), DateTime.Now);
    var reply2 = author.Comments.AddModernComment("Reply 2", slide, null, new PointF(120, 100), DateTime.Now);

    reply1.ParentComment = parent;
    reply2.ParentComment = parent;

    pres.Save("modern_comment_replies.pptx", SaveFormat.Pptx);
}
```
