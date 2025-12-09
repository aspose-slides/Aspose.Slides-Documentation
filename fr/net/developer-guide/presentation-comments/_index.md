---
title: Gérer les commentaires de présentation dans .NET
linktitle: Commentaires de présentation
type: docs
weight: 100
url: /fr/net/presentation-comments/
keywords:
- commentaire
- commentaire moderne
- commentaires PowerPoint
- commentaires de présentation
- commentaires de diapositive
- ajouter un commentaire
- accéder au commentaire
- modifier le commentaire
- répondre au commentaire
- supprimer le commentaire
- effacer le commentaire
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Maîtrisez les commentaires de présentation avec Aspose.Slides pour .NET : ajoutez, lisez, modifiez et supprimez les commentaires dans les fichiers PowerPoint rapidement et facilement."
---

Dans PowerPoint, un commentaire apparaît comme une note ou une annotation sur une diapositive. Lorsqu'un commentaire est cliqué, son contenu ou ses messages sont révélés. 

## **Pourquoi ajouter des commentaires aux présentations ?**

Vous pouvez souhaiter utiliser les commentaires pour fournir des retours ou communiquer avec vos collègues lors de la révision des présentations.

Pour vous permettre d'utiliser les commentaires dans les présentations PowerPoint, Aspose.Slides pour .NET propose

* La classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) qui contient les collections d'auteurs (via la propriété [CommentAuthorCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/properties/index)). Les auteurs ajoutent des commentaires aux diapositives. 
* L'interface [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) qui contient la collection de commentaires pour chaque auteur. 
* La classe [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) qui contient des informations sur les auteurs et leurs commentaires : qui a ajouté le commentaire, la date d'ajout, la position du commentaire, etc. 
* La classe [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) qui contient des informations sur chaque auteur : le nom de l'auteur, ses initiales, les commentaires associés à son nom, etc. 

## **Ajouter un commentaire de diapositive**
Ce code C# montre comment ajouter un commentaire à une diapositive dans une présentation PowerPoint :
```c#
// Instancie la classe Presentation
using (Presentation presentation = new Presentation())
{
    // Ajoute une diapositive vide
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // Ajoute un auteur
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // Définit la position des commentaires
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // Ajoute un commentaire de diapositive pour un auteur sur la diapositive 1
    author.Comments.AddComment("Hello Jawad, this is slide comment", presentation.Slides[0], point, DateTime.Now);

    // Ajoute un commentaire de diapositive pour un auteur sur la diapositive 2
    author.Comments.AddComment("Hello Jawad, this is second slide comment", presentation.Slides[1], point, DateTime.Now);

    // Accède à ISlide 1
    ISlide slide = presentation.Slides[0];

    // Lorsqu'un null est passé en argument, les commentaires de tous les auteurs sont récupérés pour la diapositive sélectionnée
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


## **Accéder aux commentaires de diapositive**
Ce code C# montre comment accéder à un commentaire existant sur une diapositive dans une présentation PowerPoint :
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
            Console.WriteLine("ISlide :" + comment.Slide.SlideNumber + " has comment: " + comment.Text + " with Author: " + comment.Author.Name + " posted on time :" + comment.CreatedTime + "\n");
        }
    }
}
```


## **Répondre aux commentaires**
Un commentaire parent est le commentaire principal ou original dans une hiérarchie de commentaires ou de réponses. En utilisant la propriété [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) (de l'interface [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment)), vous pouvez définir ou obtenir un commentaire parent. 

Ce code C# montre comment ajouter des commentaires et obtenir leurs réponses :
```c#
using (Presentation pres = new Presentation())
{
    // Ajoute un commentaire
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("comment1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // Ajoute une réponse au commentaire 1
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("reply 1 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // Ajoute une autre réponse au commentaire 1
    IComment reply2 = author2.Comments.AddComment("reply 2 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // Ajoute une réponse à une réponse existante
    IComment subReply = author1.Comments.AddComment("subreply 3 for reply 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("comment 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("reply 4 for comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // Affiche la hiérarchie des commentaires sur la console
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

    // Supprime le commentaire 1 et toutes ses réponses
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```


{{% alert color="warning" title="Attention" %}} 

* Lorsque la méthode [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/methods/remove) de l'interface [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) est utilisée pour supprimer un commentaire, les réponses à ce commentaire sont également supprimées. 
* Si le paramètre [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/properties/parentcomment) entraîne une référence circulaire, une [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) sera levée.

{{% /alert %}}

## **Ajouter un commentaire moderne**

En 2021, Microsoft a introduit les *commentaires modernes* dans PowerPoint. La fonctionnalité de commentaires modernes améliore considérablement la collaboration dans PowerPoint. Grâce aux commentaires modernes, les utilisateurs de PowerPoint peuvent résoudre les commentaires, ancrer les commentaires à des objets et du texte, et interagir beaucoup plus facilement qu'auparavant. 

Dans [Aspose Slides for .NET 21.11](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-11-release-notes/), nous avons implémenté la prise en charge des commentaires modernes en ajoutant la classe [ModernComment](https://reference.aspose.com/slides/net/aspose.slides/moderncomment). Les méthodes [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/addmoderncomment) et [InsertModernComment](https://reference.aspose.com/slides/net/aspose.slides/commentcollection/methods/insertmoderncomment) ont été ajoutées à la classe [CommentCollection](https://reference.aspose.com/slides/net/aspose.slides/commentcollection). 

Ce code C# montre comment ajouter un commentaire moderne à une diapositive dans une présentation PowerPoint : 
```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Some Author", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("This is a modern comment", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Supprimer un commentaire**

### **Supprimer tous les commentaires et auteurs**
Ce code C# montre comment supprimer tous les commentaires et auteurs d'une présentation :
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


### **Supprimer des commentaires spécifiques**
Ce code C# montre comment supprimer des commentaires spécifiques sur une diapositive :
```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // ajouter des commentaires...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Author", "A");
    author.Comments.AddComment("comment 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("comment 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // supprimer tous les commentaires contenant le texte "comment 1"
    foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)
    {
        List<IComment> toRemove = new List<IComment>();
        foreach (IComment comment in slide.GetSlideComments(commentAuthor))
        {
            if (comment.Text == "comment 1")
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


## **FAQ**

**Aspose.Slides prend-il en charge un statut tel que « résolu » pour les commentaires modernes ?**

Oui. Les [commentaires modernes](https://reference.aspose.com/slides/net/aspose.slides/moderncomment/) exposent une propriété [Status](https://reference.aspose.com/slides/net/aspose.slides/moderncomment/status/). Vous pouvez lire et définir l'[état du commentaire](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/) (par exemple, le marquer comme résolu), et cet état est enregistré dans le fichier et reconnu par PowerPoint.

**Les discussions en fil (chaînes de réponses) sont‑elles prises en charge, et existe‑t‑il une limite de profondeur ?**

Oui. Chaque commentaire peut référencer son [commentaire parent](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/), ce qui permet des chaînes de réponses arbitraires. L'API ne déclare pas de limite spécifique de profondeur d'imbrication.

**Dans quel système de coordonnées la position du marqueur de commentaire est‑elle définie sur une diapositive ?**

La position est stockée sous forme de point à virgule flottante dans le système de coordonnées de la diapositive. Cela vous permet de placer le marqueur de commentaire exactement à l'endroit souhaité.