---
title: Gérer les commentaires de présentation avec .NET
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
- accéder à un commentaire
- modifier un commentaire
- répondre à un commentaire
- supprimer un commentaire
- effacer un commentaire
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Gérez les commentaires de présentation avec Aspose.Slides pour .NET : ajoutez, lisez, modifiez, répondez et supprimez les commentaires dans les présentations PowerPoint rapidement et facilement."
---
## **Vue d'ensemble**

Cet article explique comment gérer les commentaires de présentation avec Aspose.Slides pour .NET. Il presente les principaux types lies aux commentaires et montre comment ajouter des commentaires aux diapositives, acceder aux commentaires existants, travailler avec les reponses et les commentaires modernes, et supprimer les commentaires d'une presentation.

Les exemples couvrent des scénarios courants de revision et de collaboration dans PowerPoint, tels que l'attribution de commentaires aux auteurs, la lecture du texte des commentaires et des metadonnees, la construction de chaines de reponses et la suppression de commentaires selectionnes ou de tous les commentaires.

Dans PowerPoint, les commentaires apparaissent comme des annotations sur les diapositives. Selectionner un commentaire affiche son texte et la discussion associee.

Pour demander que les commentaires soient affiches ou masques lors de l'ouverture d'une presentation sans modifier les commentaires eux-memes, voir [Afficher ou masquer les commentaires lors de l'ouverture d'une presentation](/slides/fr/net/presentation-view-properties/).

## **Pourquoi ajouter des commentaires aux présentations ?**

Vous pouvez utiliser les commentaires pour fournir des retours et collaborer avec des collègues lors de la revision des présentations.

Aspose.Slides pour .NET fournit les API suivantes pour travailler avec les commentaires :

* La classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) qui fournit l'accès aux auteurs de commentaires de la presentation.
* L'interface [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) qui représente les commentaires associes a un auteur individuel.
* L'interface [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) qui fournit des informations sur un commentaire, y compris son auteur, la date de creation, la position et le texte.
* La classe [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) qui fournit des informations sur un auteur, y compris son nom, ses initiales et les commentaires associes.

## **Ajouter des commentaires aux diapositives**

L'exemple cree deux diapositives et enregistre un auteur de commentaire avec [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/). Il utilise [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) pour placer un commentaire sur chaque diapositive, puis recupere les commentaires de la première diapositive pour cet auteur avec [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/). La console affiche le texte du premier commentaire deux fois, demontrant l'acces via la diapositive et via l'auteur, et la presentation enregistree contient les deux commentaires.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

var author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");
var position = new PointF(0.2f, 0.2f);
var createdTime = DateTime.Now;

author.Comments.AddComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
author.Comments.AddComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

var comments = firstSlide.GetSlideComments(author);
if (comments.Length > 0)
{
    var firstComment = comments[0];
    Console.WriteLine(firstComment.Text);

    var commentText = firstComment.Author.Comments[0].Text;
    Console.WriteLine(commentText);
}

presentation.Save("Comments_out.pptx", SaveFormat.Pptx);
```

## **Trouver ou créer un auteur de commentaire**

Lorsque un examen automatise traite la meme presentation a plusieurs reprises, recherchez dans sa collection [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/) avant d'ajouter un auteur. [FindByNameAndInitials](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbynameandinitials/) correspond a la fois au nom et aux initiales et renvoie un tableau d'auteurs correspondants, ou un tableau vide s'il n'y a aucune correspondance. En revanche, [FindByName](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbyname/) recherche uniquement par nom, quelles que soient les initiales. Appeler [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/) avec un nom et des initiales deja presents dans la collection genere une exception.

L'exemple necessite un fichier de presentation contenant au moins une diapositive. A chaque passe (deux passes au total), il reutilise le premier auteur correspondant, ou cree un nouvel auteur uniquement si le resultat est vide. S'il y a plusieurs correspondances, il selectionne le premier element du tableau sans fusionner ni supprimer les autres auteurs. Il appelle ensuite [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) pour l'auteur selectionne et enregistre la presentation. La seconde passe ouvre la sortie de la premiere passe et repete l'operation.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const string authorName = "Reviewer";
const string authorInitials = "RV";

var inputFile = "input.pptx";
var position = new PointF(20, 20);

for (var pass = 1; pass <= 2; pass++)
{
    using var presentation = new Presentation(inputFile);

    var matches = presentation.CommentAuthors.FindByNameAndInitials(authorName, authorInitials);
    
    var author = matches.Length > 0 ? matches[0] : presentation.CommentAuthors.AddAuthor(authorName, authorInitials);
    author.Comments.AddComment("Please review this slide.", presentation.Slides[0], position, DateTime.Now);

    var outputFile = $"review_pass_{pass}.pptx";
    presentation.Save(outputFile, SaveFormat.Pptx);
    inputFile = outputFile;
}
```

La seconde passe ajoute un autre commentaire sans ajouter un autre auteur ni supprimer les commentaires existants. Le fichier final, `review_pass_2.pptx`, contient les deux nouveaux commentaires ainsi que tous les commentaires originaux. Reutiliser un auteur ne deduplicate pas les commentaires : pour eviter d'ajouter repetitivement le meme commentaire, implementez une detection de duplicata avant de l'ajouter.

## **Accéder aux commentaires des diapositives**

L'exemple ouvre une presentation existante et lit sa collection [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/). Pour chaque auteur, il itere sur [Comments](https://reference.aspose.com/slides/net/aspose.slides/icommentauthor/comments/) et affiche le numero de la diapositive, le texte du commentaire, le nom de l'auteur et la date de creation. La presentation d'entree doit contenir des commentaires pour produire une sortie console.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Comments1.pptx");

foreach (var author in presentation.CommentAuthors)
{
    foreach (var comment in author.Comments)
    {
        Console.WriteLine($"Slide: {comment.Slide.SlideNumber}");
        Console.WriteLine($"Comment: {comment.Text}");
        Console.WriteLine($"Author: {comment.Author.Name}");
        Console.WriteLine($"Posted at: {comment.CreatedTime}");
        Console.WriteLine();
    }
}
```

## **Répondre aux commentaires**

Un commentaire parent est le commentaire original situe au sommet d'une hierarchie de reponses. La propriete [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) de l'interface [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) vous permet d'obtenir ou de definir le parent d'un commentaire.

L'exemple cree des commentaires provenant de deux auteurs et utilise [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) pour construire des reponses, y compris une reponse a une autre reponse. Passer `null` a [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) recupere les commentaires de tous les auteurs ; la console indente chaque entree en fonction de sa profondeur dans la hierarchie de reponses. L'exemple enregistre la discussion complete, appelle [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) sur le premier commentaire racine, et enregistre une seconde presentation avec ce commentaire et ses reponses supprimes.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var position = new PointF(10, 10);
var createdTime = DateTime.Now;

var originalAuthor = presentation.CommentAuthors.AddAuthor("Author_1", "A.A.");
var rootComment = originalAuthor.Comments.AddComment("comment 1", slide, position, createdTime);

var reviewer = presentation.CommentAuthors.AddAuthor("Author_2", "B.B.");
var firstReply = reviewer.Comments.AddComment("reply 1 for comment 1", slide, position, createdTime);
firstReply.ParentComment = rootComment;

var secondReply = reviewer.Comments.AddComment("reply 2 for comment 1", slide, position, createdTime);
secondReply.ParentComment = rootComment;

var subReply = originalAuthor.Comments.AddComment("subreply 3 for reply 2", slide, position, createdTime);
subReply.ParentComment = secondReply;

reviewer.Comments.AddComment("comment 2", slide, position, createdTime);
var separateComment = reviewer.Comments.AddComment("comment 3", slide, position, createdTime);

var separateReply = originalAuthor.Comments.AddComment("reply 4 for comment 3", slide, position, createdTime);
separateReply.ParentComment = separateComment;

var comments = slide.GetSlideComments(null);
for (var i = 0; i < comments.Length; i++)
{
    var comment = comments[i];
    while (comment.ParentComment != null)
    {
        Console.Write("\t");
        comment = comment.ParentComment;
    }

    Console.WriteLine($"{comments[i].Author.Name}: {comments[i].Text}");
}

presentation.Save("parent_comment.pptx", SaveFormat.Pptx);

rootComment.Remove();
presentation.Save("remove_comment.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Warning" %}}
* Lorsque la methode [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) de l'interface [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) est utilisee pour supprimer un commentaire, toutes les réponses a ce commentaire sont egalement supprimees.
* Si la propriete [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) cree une reference circulaire, une [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) est levee.
{{% /alert %}}

## **Ajouter des commentaires modernes**

Les commentaires modernes peuvent etre associes a la diapositive elle-meme, a une forme specifique, ou a une plage de texte dans une AutoShape. La methode [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) accepte un argument [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) en plus de la diapositive et des coordonnees du marqueur de commentaire.

Lorsque `null` est passe pour le parametre de forme, le commentaire est un commentaire au niveau de la diapositive. Son marqueur est positionne selon les coordonnees fournies, mais il n'est associe a aucune forme particuliere, de sorte que [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) renvoie `null`. Lorsqu'une [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) est fournie, le commentaire est ancre a cette forme. Les coordonnees definissent toujours la position du marqueur de commentaire sur la diapositive, tandis que l'association de forme peut etre recuperee via [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/).

### **Ancrer un commentaire moderne à une forme**

L'exemple appelle [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) deux fois : une fois avec une forme `null` pour un commentaire au niveau de la diapositive et une fois avec un rectangle comme ancre. Lire [Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) affiche `True` pour le test de null du commentaire au niveau de la diapositive et `Revenue title` pour le commentaire ancre. Les deux commentaires sont enregistres avec la presentation.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 300, 80);
shape.Name = "Revenue title";
shape.TextFrame.Text = "Quarterly revenue";

var createdTime = DateTime.Now;
var slideCommentPosition = new PointF(20, 20);
var shapeCommentPosition = new PointF(60, 60);
var slideComment = author.Comments.AddModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
var shapeComment = author.Comments.AddModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

Console.WriteLine(slideComment.Shape == null);
Console.WriteLine(shapeComment.Shape?.Name);

presentation.Save("modern_comments.pptx", SaveFormat.Pptx);
```

### **Ancrer des commentaires à différents types de formes**

Tout objet de diapositive qui implemente [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) peut etre utilise comme ancre de forme. Les exemples courants incluent [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/net/aspose.slides/iconnector/), et des instances [IGraphicalObject](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobject/) telles que des graphiques.

L'exemple utilise [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) pour associer un commentaire a chacun des cinq types de forme : une AutoShape, un cadre d'image, un groupe, un connecteur et un graphique. L'image utilise des donnees d'image embarquees, aucune image externe n'est requise. Chaque commentaire a sa propre position de marqueur, et la presentation enregistree conserve les cinq associations de forme.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");
var createdTime = DateTime.Now;

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 180, 60);
autoShape.TextFrame.Text = "AutoShape";

var autoShapeCommentPosition = new PointF(30, 30);
author.Comments.AddModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

var imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
var imageData = Convert.FromBase64String(imageBase64);
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image);
var pictureCommentPosition = new PointF(230, 30);
author.Comments.AddModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

var groupShape = slide.Shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 80, 40);
groupShape.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 0, 80, 40);
var groupCommentPosition = new PointF(40, 150);
author.Comments.AddModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

var connector = slide.Shapes.AddConnector(ShapeType.StraightConnector1, 220, 150, 140, 40);
var connectorCommentPosition = new PointF(240, 150);
author.Comments.AddModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 400, 20, 250, 180);
var chartCommentPosition = new PointF(420, 40);
author.Comments.AddModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

presentation.Save("modern_comment_shape_types.pptx", SaveFormat.Pptx);
```

### **Ancrer un commentaire à du texte et definir son statut**

Pour un commentaire moderne associe a une [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) indique la position de depart du texte selectionne dans le cadre de texte de la forme, tandis que [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) indique la longueur de la selection. Ensemble, ces proprietes associent le commentaire a une plage de texte specifique dans l'AutoShape.

La propriete [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) peut etre lue ou mise a jour avec une valeur de l'enumeration [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/) :

- `NotDefined` — aucun statut de commentaire moderne specifique n'est defini.
- `Active` — le commentaire est actif.
- `Resolved` — le commentaire a ete resolu.
- `Closed` — le commentaire est ferme.

L'exemple ancre un commentaire moderne aux mots "quarterly revenue" dans le texte d'un rectangle. Il calcule le [TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) base zero a partir du texte et definit [TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) au nombre de caracteres selectionnes. Apres avoir definit [Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) a `Resolved`, il enregistre et rouvre la presentation. Les quatre verifications console doivent chacune afficher `True`, confirmant que l'ancre de forme, la plage de texte et le statut ont ete preserves.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputFile = "modern_comment_text_anchor.pptx";
const string shapeText = "Review the quarterly revenue forecast.";
const string selectedText = "quarterly revenue";
var expectedSelectionStart = shapeText.IndexOf(selectedText, StringComparison.Ordinal);

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.Name = "Forecast text";
shape.TextFrame.Text = shapeText;

var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");
var commentPosition = new PointF(60, 60);
var comment = author.Comments.AddModernComment("Verify this forecast wording.", slide, shape, commentPosition, DateTime.Now);
comment.TextSelectionStart = expectedSelectionStart;
comment.TextSelectionLength = selectedText.Length;
comment.Status = ModernCommentStatus.Resolved;

presentation.Save(outputFile, SaveFormat.Pptx);

using var reopenedPresentation = new Presentation(outputFile);
var reopenedSlide = reopenedPresentation.Slides[0];
var reopenedComments = reopenedSlide.GetSlideComments(null);

foreach (var reopenedComment in reopenedComments)
{
    if (reopenedComment is not IModernComment modernComment)
    {
        continue;
    }

    var shapeMatches = modernComment.Shape?.Name == "Forecast text";
    var selectionStartMatches = modernComment.TextSelectionStart == expectedSelectionStart;
    var selectionLengthMatches = modernComment.TextSelectionLength == selectedText.Length;
    var statusMatches = modernComment.Status == ModernCommentStatus.Resolved;

    Console.WriteLine($"Shape anchor preserved: {shapeMatches}");
    Console.WriteLine($"Text selection start preserved: {selectionStartMatches}");
    Console.WriteLine($"Text selection length preserved: {selectionLengthMatches}");
    Console.WriteLine($"Resolved status preserved: {statusMatches}");
}
```

### **Inspecter les commentaires modernes existants**

L'exemple necessite une presentation existante contenant des commentaires modernes et affiche leur texte, statut et details d'ancrage. Pour l'inspecter, verifiez quels commentaires implémentent [IModernComment](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/), puis examinez [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) et [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/). Une forme `null` indique un commentaire au niveau de la diapositive. Pour une ancre [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), les proprietes de selection de texte identifient la plage associee dans le cadre de texte de la forme.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("comments.pptx");

foreach (var slide in presentation.Slides)
{
    var comments = slide.GetSlideComments(null);
    foreach (var comment in comments)
    {
        if (comment is not IModernComment modernComment)
        {
            continue;
        }

        Console.WriteLine($"Slide: {slide.SlideNumber}");
        Console.WriteLine($"Text: {modernComment.Text}");
        Console.WriteLine($"Status: {modernComment.Status}");

        var shape = modernComment.Shape;
        if (shape == null)
        {
            Console.WriteLine("Anchor: slide level");
        }
        else
        {
            Console.WriteLine($"Anchor shape: {shape.Name}");
            Console.WriteLine($"Anchor type: {shape.GetType().Name}");

            if (shape is IAutoShape)
            {
                Console.WriteLine($"Text selection start: {modernComment.TextSelectionStart}");
                Console.WriteLine($"Text selection length: {modernComment.TextSelectionLength}");
            }
        }

        Console.WriteLine();
    }
}
```

## **Supprimer les commentaires**

Aspose.Slides pour .NET vous permet de supprimer tous les commentaires et leurs auteurs d'une presentation ou de supprimer des commentaires selectionnes tout en conservant le reste. Les exemples suivants demonstrent les deux approches et enregistrent la presentation mise a jour.

### **Supprimer tous les commentaires et les auteurs de commentaires**

L'exemple ouvre une presentation existante et appelle [ICommentCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/clear/) pour chaque auteur, puis appelle [ICommentAuthorCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/clear/) pour supprimer les auteurs eux-memes. La presentation enregistree ne contient ni commentaires ni auteurs de commentaires. Utilisez une presentation contenant des commentaires pour observer la suppression.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("example.pptx");

foreach (var author in presentation.CommentAuthors)
{
    author.Comments.Clear();
}

presentation.CommentAuthors.Clear();

presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

### **Supprimer des commentaires spécifiques**

L'exemple cree deux commentaires sur une diapositive et utilise [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) pour trouver les commentaires de chaque auteur. Il collecte les commentaires dont le texte egal "comment 1" avant d'appeler [ICommentCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/remove/), evitant ainsi des modifications de la collection pendant la selection. La presentation enregistree ne conserve que "comment 2".

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var author = presentation.CommentAuthors.AddAuthor("Author", "A");
var createdTime = DateTime.Now;

var firstCommentPosition = new PointF(0.2f, 0.2f);
var secondCommentPosition = new PointF(0.3f, 0.2f);
author.Comments.AddComment("comment 1", slide, firstCommentPosition, createdTime);
author.Comments.AddComment("comment 2", slide, secondCommentPosition, createdTime);

foreach (var commentAuthor in presentation.CommentAuthors)
{
    var commentsToRemove = new List<IComment>();
    var comments = slide.GetSlideComments(commentAuthor);

    foreach (var comment in comments)
    {
        if (comment.Text == "comment 1")
        {
            commentsToRemove.Add(comment);
        }
    }

    foreach (var comment in commentsToRemove)
    {
        commentAuthor.Comments.Remove(comment);
    }
}

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Aspose.Slides prend‑il en charge un statut résolu pour les commentaires modernes ?**

Oui. [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) peut être lu et défini avec une valeur de l'énumération [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/), y compris `Resolved`. Le statut est stocké dans la presentation et peut être lu de nouveau après la réouverture du fichier.

**Les discussions en fil (chaînes de réponses) sont‑elles prises en charge, et existe‑t‑il une limite de profondeur ?**

Oui. Chaque commentaire peut référencer son [parent comment](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/), ce qui permet des chaînes de réponses. L'API ne définit pas de limite spécifique à la profondeur d'imbrication.

**Dans quel système de coordonnées la position du marqueur d'un commentaire est‑elle définie sur une diapositive ?**

La position du marqueur est définie par des coordonnées à virgule flottante dans le système de coordonnées de la diapositive, ce qui vous permet de le placer précisément sur la diapositive.