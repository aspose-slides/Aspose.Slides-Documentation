---
title: Commentaires de Présentation
type: docs
weight: 100
url: /net/presentation-comments/
keywords: "Commentaires, commentaires PowerPoint, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Ajouter des commentaires et des réponses dans une présentation PowerPoint en C# ou .NET"
---

Dans PowerPoint, un commentaire apparaît comme une note ou une annotation sur une diapositive. Lorsqu'un commentaire est cliqué, son contenu ou ses messages sont révélés.

## **Pourquoi Ajouter des Commentaires aux Présentations ?**

Vous souhaiterez peut-être utiliser des commentaires pour fournir des retours ou communiquer avec vos collègues lorsque vous examinez des présentations.

Pour vous permettre d'utiliser des commentaires dans les présentations PowerPoint, Aspose.Slides pour .NET fournit

* La classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), qui contient les collections d'auteurs (propriété [CommentAuthorCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/properties/index)). Les auteurs ajoutent des commentaires aux diapositives.
* L'interface [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection), qui contient la collection de commentaires pour des auteurs individuels.
* La classe [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment), qui contient des informations sur les auteurs et leurs commentaires : qui a ajouté le commentaire, le moment où le commentaire a été ajouté, la position du commentaire, etc.
* La classe [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor), qui contient des informations sur des auteurs individuels : le nom de l'auteur, ses initiales, les commentaires associés au nom de l'auteur, etc.

## **Ajouter un Commentaire de Diapositive**
Ce code C# vous montre comment ajouter un commentaire à une diapositive dans une présentation PowerPoint :

```c#
// Instancie la classe Presentation
using (Presentation presentation = new Presentation())
{
    // Ajoute une diapositive vide
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // Ajoute un auteur
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // Définit la position pour les commentaires
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // Ajoute un commentaire de diapositive pour un auteur sur la diapositive 1
    author.Comments.AddComment("Bonjour Jawad, ceci est un commentaire de diapositive", presentation.Slides[0], point, DateTime.Now);

    // Ajoute un commentaire de diapositive pour un auteur sur la diapositive 2
    author.Comments.AddComment("Bonjour Jawad, ceci est le deuxième commentaire de diapositive", presentation.Slides[1], point, DateTime.Now);

    // Accède à ISlide 1
    ISlide slide = presentation.Slides[0];

    // Lorsque null est passé comme argument, les commentaires de tous les auteurs sont apportés à la diapositive sélectionnée
    IComment[] Comments = slide.GetSlideComments(author);

    // Accède au commentaire à l'index 0 pour la diapositive 1
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // Sélectionne la collection de commentaires de l'auteur à l'index 0
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```

## **Accéder aux Commentaires de Diapositive**
Ce code C# vous montre comment accéder à un commentaire existant sur une diapositive dans une présentation PowerPoint :

```c#
// Instancie la classe Presentation
using (Presentation presentation = new Presentation("Comments1.pptx"))
{
    foreach (var commentAuthor in presentation.CommentAuthors)
    {
        var author = (CommentAuthor) commentAuthor;
        foreach (var comment1 in author.Comments)
        {
            var comment = (Comment) comment1;
            Console.WriteLine("ISlide :" + comment.Slide.SlideNumber + " a le commentaire : " + comment.Text + " avec l'Auteur : " + comment.Author.Name + " posté à : " + comment.CreatedTime + "\n");
        }
    }
}
```

## **Répondre aux Commentaires**
Un commentaire parent est le commentaire supérieur ou original dans une hiérarchie de commentaires ou de réponses. En utilisant la propriété [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) (de l'interface [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment)), vous pouvez définir ou obtenir un commentaire parent.

Ce code C# vous montre comment ajouter des commentaires et obtenir des réponses :

```c#
using (Presentation pres = new Presentation())
{
    // Ajoute un commentaire
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("commentaire1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // Ajoute une réponse au commentaire1
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("réponse 1 pour le commentaire 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // Ajoute une autre réponse au commentaire1
    IComment reply2 = author2.Comments.AddComment("réponse 2 pour le commentaire 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // Ajoute une réponse à la réponse existante
    IComment subReply = author1.Comments.AddComment("sous-réponse 3 pour la réponse 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("commentaire 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("commentaire 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("réponse 4 pour le commentaire 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // Affiche la hiérarchie des commentaires dans la console
    ISlide slide = pres.Slides[0];
    var comments = slide.GetSlideComments(null);
    for (int i = 0; i < comments.Length; i++)
    {
        IComment comment = comments[i];
        while (comment.ParentComment != null)
        {
            Console.Write("\t");
            comment = comment.ParentComment;
        }

        Console.Write("{0} : {1}", comments[i].Author.Name, comments[i].Text);
        Console.WriteLine();
    }

    pres.Save("parent_comment.pptx",SaveFormat.Pptx);

    // Supprime le commentaire1 et toutes les réponses à celui-ci
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" title="Attention" %}} 

* Lorsque la méthode [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/methods/remove) (de l'interface [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment)) est utilisée pour supprimer un commentaire, les réponses au commentaire sont également supprimées.
* Si le paramètre [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) entraîne une référence circulaire, une [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) sera levée.

{{% /alert %}}

## **Ajouter un Commentaire Modern**

En 2021, Microsoft a introduit des *commentaires modernes* dans PowerPoint. La fonctionnalité de commentaires modernes améliore considérablement la collaboration dans PowerPoint. Grâce aux commentaires modernes, les utilisateurs de PowerPoint peuvent résoudre des commentaires, ancrer des commentaires à des objets et des textes, et participer à des interactions beaucoup plus facilement qu'auparavant.

Dans [Aspose Slides pour .NET 21.11](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-11-release-notes/), nous avons mis en œuvre la prise en charge des commentaires modernes en ajoutant la classe [ModernComment](https://reference.aspose.com/slides/net/aspose.slides/moderncomment). Les méthodes [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/addmoderncomment) et [InsertModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/insertmoderncomment) ont été ajoutées à la classe [CommentCollection](https://reference.aspose.com/slides/net/aspose.slides/commentcollection).

Ce code C# vous montre comment ajouter un commentaire moderne à une diapositive dans une présentation PowerPoint :

```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Certains Auteur", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("Ceci est un commentaire moderne", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Supprimer un Commentaire**

### **Supprimer Tous les Commentaires et Auteurs**

Ce code C# vous montre comment supprimer tous les commentaires et auteurs dans une présentation :

```c#
using (var presentation = new Presentation("example.pptx"))
{
    // Supprime tous les commentaires de la présentation
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // Supprime tous les auteurs
    presentation.CommentAuthors.Clear();

    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

### **Supprimer des Commentaires Spécifiques**

Ce code C# vous montre comment supprimer des commentaires spécifiques sur une diapositive :

```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // ajoute des commentaires...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Auteur", "A");
    author.Comments.AddComment("commentaire 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("commentaire 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // supprime tous les commentaires qui contiennent le texte "commentaire 1"
    foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)
    {
        List<IComment> toRemove = new List<IComment>();
        foreach (IComment comment in slide.GetSlideComments(commentAuthor))
        {
            if (comment.Text == "commentaire 1")
            {
                toRemove.Add(comment);
            }
        }
        
        foreach (IComment comment in toRemove)
        {
            commentAuthor.Comments.Remove(comment);
        }
    }
    
    presentation.Save("pres.pptx", SaveFormat.Pptx);
}
```