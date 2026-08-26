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
description: "Gérer les commentaires de présentation avec Aspose.Slides pour .NET : ajouter, lire, modifier, répondre et supprimer des commentaires dans les présentations PowerPoint rapidement et facilement."
---
## **Vue d'ensemble**

Cet article explique comment gérer les commentaires de présentation avec Aspose.Slides pour .NET. Il présente les principaux types liés aux commentaires et montre comment ajouter des commentaires aux diapositives, accéder aux commentaires existants, travailler avec les réponses et les commentaires modernes, et supprimer des commentaires d’une présentation.

Les exemples couvrent les scénarios courants de révision et de collaboration dans PowerPoint, tels que l’attribution de commentaires à des auteurs, la lecture du texte et des métadonnées des commentaires, la création de chaînes de réponses, et la suppression de commentaires sélectionnés ou de tous les commentaires.

Dans PowerPoint, les commentaires apparaissent sous forme d’annotations sur les diapositives. La sélection d’un commentaire affiche son texte et la discussion associée.

## **Pourquoi ajouter des commentaires aux présentations ?**

Vous pouvez utiliser les commentaires pour fournir des retours et collaborer avec vos collègues lors de la révision de présentations.

Aspose.Slides pour .NET propose les API suivantes pour travailler avec les commentaires :

* La classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation) qui donne accès aux auteurs de commentaires de la présentation.
* L’interface [ICommentCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/icommentcollection) qui représente les commentaires associés à un auteur individuel.
* L’interface [IComment](https://reference.aspose.com/slides/fr/net/aspose.slides/icomment) qui fournit des informations sur un commentaire, y compris son auteur, l’heure de création, la position et le texte.
* La classe [CommentAuthor](https://reference.aspose.com/slides/fr/net/aspose.slides/commentauthor) qui fournit des informations sur un auteur, notamment son nom, ses initiales et les commentaires associés.

## **Ajouter des commentaires aux diapositives**
L’exemple suivant montre comment ajouter des commentaires aux diapositives d’une présentation PowerPoint :

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

## **Accéder aux commentaires des diapositives**
L’exemple suivant montre comment accéder aux commentaires existants dans une présentation PowerPoint :

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
Un commentaire parent est le commentaire original au sommet d’une hiérarchie de réponses. La propriété [ParentComment](https://reference.aspose.com/slides/fr/net/aspose.slides/icomment/properties/parentcomment) de l’interface [IComment](https://reference.aspose.com/slides/fr/net/aspose.slides/icomment) vous permet d’obtenir ou de définir le parent d’un commentaire.

L’exemple suivant montre comment ajouter des réponses et inspecter la hiérarchie de commentaires résultante :

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var position = new PointF(10, 10);
var createdTime = DateTime.Now;

var author1 = presentation.CommentAuthors.AddAuthor("Author_1", "A.A.");
var comment1 = author1.Comments.AddComment("comment 1", slide, position, createdTime);

var author2 = presentation.CommentAuthors.AddAuthor("Author_2", "B.B.");
var reply1 = author2.Comments.AddComment("reply 1 for comment 1", slide, position, createdTime);
reply1.ParentComment = comment1;

var reply2 = author2.Comments.AddComment("reply 2 for comment 1", slide, position, createdTime);
reply2.ParentComment = comment1;

var subReply = author1.Comments.AddComment("subreply 3 for reply 2", slide, position, createdTime);
subReply.ParentComment = reply2;

author2.Comments.AddComment("comment 2", slide, position, createdTime);
var comment3 = author2.Comments.AddComment("comment 3", slide, position, createdTime);

var reply3 = author1.Comments.AddComment("reply 4 for comment 3", slide, position, createdTime);
reply3.ParentComment = comment3;

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

comment1.Remove();
presentation.Save("remove_comment.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Attention" %}} 
* Lorsque la méthode [Remove](https://reference.aspose.com/slides/fr/net/aspose.slides/icomment/methods/remove) de l’interface [IComment](https://reference.aspose.com/slides/fr/net/aspose.slides/icomment) est utilisée pour supprimer un commentaire, toutes les réponses à ce commentaire sont également supprimées.
* Si la propriété [ParentComment](https://reference.aspose.com/slides/fr/net/aspose.slides/icomment/properties/parentcomment) crée une référence circulaire, une [PptxEditException](https://reference.aspose.com/slides/fr/net/aspose.slides/pptxeditexception) est levée.
{{% /alert %}}

## **Ajouter des commentaires modernes**

Les commentaires modernes peuvent être associés à la diapositive elle‑même, à une forme spécifique ou à une plage de texte à l’intérieur d’une AutoShape. La méthode [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/fr/net/aspose.slides/icommentcollection/addmoderncomment/) accepte un argument [IShape](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/) en plus de la diapositive et des coordonnées du marqueur de commentaire.

Lorsque `null` est passé pour l’argument shape, le commentaire est un commentaire au niveau de la diapositive. Son marqueur est positionné selon les coordonnées fournies, mais il n’est pas associé à une forme particulière, de sorte que [IModernComment.Shape](https://reference.aspose.com/slides/fr/net/aspose.slides/imoderncomment/shape/) renvoie `null`. Lorsqu’une [IShape](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/) est fournie, le commentaire est ancré à cette forme. Les coordonnées définissent toujours la position du marqueur de commentaire sur la diapositive, tandis que l’association de forme peut être récupérée via [IModernComment.Shape](https://reference.aspose.com/slides/fr/net/aspose.slides/imoderncomment/shape/).

### **Ancrer un commentaire moderne à une forme**

L’exemple suivant crée à la fois un commentaire moderne au niveau de la diapositive et un commentaire moderne ancré à une AutoShape spécifique. Il lit ensuite la forme associée à chaque commentaire.

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

Tout objet de diapositive implémentant [IShape](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/) peut être utilisé comme ancre de forme. Parmi les exemples courants figurent [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/fr/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/fr/net/aspose.slides/iconnector/) et les instances [IGraphicalObject](https://reference.aspose.com/slides/fr/net/aspose.slides/igraphicalobject/) telles que les graphiques.

L’exemple suivant crée plusieurs types de formes courantes et associe un commentaire moderne à chacune d’elles.

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

### **Ancrer un commentaire à du texte et définir son statut**

Pour un commentaire moderne associé à une [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/), la propriété [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/fr/net/aspose.slides/imoderncomment/textselectionstart/) indique la position de départ du texte sélectionné dans le cadre de texte de la forme, tandis que [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/fr/net/aspose.slides/imoderncomment/textselectionlength/) indique la longueur de la sélection. Ensemble, ces propriétés associent le commentaire à une plage de texte spécifique à l’intérieur de l’AutoShape.

La propriété [IModernComment.Status](https://reference.aspose.com/slides/fr/net/aspose.slides/imoderncomment/status/) peut être lue ou mise à jour avec une valeur de l’énumération [ModernCommentStatus](https://reference.aspose.com/slides/fr/net/aspose.slides/moderncommentstatus/) :

- `NotDefined` — aucun statut de commentaire moderne spécifique n’est défini.
- `Active` — le commentaire est actif.
- `Resolved` — le commentaire a été résolu.
- `Closed` — le commentaire est fermé.

L’exemple suivant crée un commentaire moderne ancré à une forme, l’associe à une sélection de texte, le marque comme résolu, enregistre la présentation et vérifie les valeurs après réouverture du fichier.

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

Pour examiner une présentation existante, identifiez les commentaires implémentant [IModernComment](https://reference.aspose.com/slides/fr/net/aspose.slides/imoderncomment/), puis examinez [IModernComment.Shape](https://reference.aspose.com/slides/fr/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/fr/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/fr/net/aspose.slides/imoderncomment/textselectionlength/) et [IModernComment.Status](https://reference.aspose.com/slides/fr/net/aspose.slides/imoderncomment/status/). Une forme `null` indique un commentaire au niveau de la diapositive. Pour une ancre [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/), les propriétés de sélection de texte identifient la plage associée dans le cadre de texte de la forme.

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

### **Supprimer tous les commentaires et leurs auteurs**

L’exemple suivant montre comment supprimer tous les commentaires et leurs auteurs d’une présentation :

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

L’exemple suivant montre comment supprimer des commentaires spécifiques d’une diapositive :

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

Oui. La propriété [IModernComment.Status](https://reference.aspose.com/slides/fr/net/aspose.slides/imoderncomment/status/) peut être lue et définie avec une valeur de l’énumération [ModernCommentStatus](https://reference.aspose.com/slides/fr/net/aspose.slides/moderncommentstatus/), y compris `Resolved`. Le statut est stocké dans la présentation et peut être relu après réouverture du fichier.

**Les discussions en chaîne (réponses imbriquées) sont‑elles prises en charge, et existe‑t‑il une limite de profondeur ?**

Oui. Chaque commentaire peut référencer son [parent comment](https://reference.aspose.com/slides/fr/net/aspose.slides/comment/parentcomment/), ce qui permet des chaînes de réponses. L’API ne définit pas de limite spécifique de profondeur d’imbrication.

**Dans quel système de coordonnées la position du marqueur de commentaire est‑elle définie sur une diapositive ?**

La position du marqueur est définie par des coordonnées à virgule flottante dans le système de coordonnées de la diapositive, ce qui vous permet de le placer avec précision sur la diapositive.