---
title: Správa komentářů prezentace v .NET
linktitle: Komentáře k prezentaci
type: docs
weight: 100
url: /cs/net/presentation-comments/
keywords:
- komentář
- moderní komentář
- komentáře PowerPoint
- komentáře prezentace
- komentáře snímků
- přidat komentář
- přístup ke komentáři
- upravit komentář
- odpověď na komentář
- odstranit komentář
- smazat komentář
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Spravujte komentáře prezentací pomocí Aspose.Slides pro .NET: přidávejte, čtěte, upravujte, odpovídejte a odstraňujte komentáře v PowerPoint prezentacích rychle a snadno."
---
## **Přehled**

Tento článek vysvětluje, jak spravovat komentáře prezentací pomocí Aspose.Slides pro .NET. Představuje hlavní typy související s komentáři a ukazuje, jak přidávat komentáře do snímků, přistupovat k existujícím komentářům, pracovat s odpověďmi a moderními komentáři a odstraňovat komentáře z prezentace.

Příklady pokrývají běžné scénáře revize a spolupráce v PowerPointu, jako je přiřazování komentářů autorům, čtení textu a metadat komentářů, vytváření řetězců odpovědí a odstraňování vybraných nebo všech komentářů.

V PowerPointu se komentáře zobrazují jako anotace na snímcích. Výběrem komentáře se zobrazí jeho text a související diskuse.

## **Proč přidávat komentáře do prezentací?**

Komentáře můžete použít k poskytování zpětné vazby a spolupráci s kolegy při revizi prezentací.

Aspose.Slides pro .NET poskytuje následující API pro práci s komentáři:

* Třída [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation), která poskytuje přístup k autorům komentářů prezentace.
* Rozhraní [ICommentCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/icommentcollection), které představuje komentáře spojené s jednotlivým autorem.
* Rozhraní [IComment](https://reference.aspose.com/slides/cs/net/aspose.slides/icomment), které poskytuje informace o komentáři, včetně jeho autora, času vytvoření, pozice a textu.
* Třída [CommentAuthor](https://reference.aspose.com/slides/cs/net/aspose.slides/commentauthor), která poskytuje informace o autorovi, včetně jeho jména, iniciál a souvisejících komentářů.

## **Přidání komentářů ke snímku**
Následující příklad ukazuje, jak přidat komentáře do snímků v prezentaci PowerPoint:

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

## **Přístup ke komentářům snímku**
Následující příklad ukazuje, jak získat přístup k existujícím komentářům v prezentaci PowerPoint:

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

## **Odpovídání na komentáře**
Nadřazený komentář je původní komentář na vrcholu hierarchie odpovědí. Vlastnost [ParentComment](https://reference.aspose.com/slides/cs/net/aspose.slides/icomment/properties/parentcomment) rozhraní [IComment](https://reference.aspose.com/slides/cs/net/aspose.slides/icomment) vám umožňuje získat nebo nastavit nadřazený komentář.

Následující příklad ukazuje, jak přidávat odpovědi a prozkoumat výslednou hierarchii komentářů:

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

* Když je metoda [Remove](https://reference.aspose.com/slides/cs/net/aspose.slides/icomment/methods/remove) rozhraní [IComment](https://reference.aspose.com/slides/cs/net/aspose.slides/icomment) použita k smazání komentáře, jsou také smazány všechny odpovědi na tento komentář.
* Pokud vlastnost [ParentComment](https://reference.aspose.com/slides/cs/net/aspose.slides/icomment/properties/parentcomment) vytvoří cyklický odkaz, je vyhozena výjimka [PptxEditException](https://reference.aspose.com/slides/cs/net/aspose.slides/pptxeditexception).

{{% /alert %}}

## **Přidání moderních komentářů**

Moderní komentáře mohou být přiřazeny přímo ke snímku, k určitému tvaru nebo k rozsahu textu uvnitř AutoShape. Metoda [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/cs/net/aspose.slides/icommentcollection/addmoderncomment/) přijímá argument [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/) kromě snímku a souřadnic značky komentáře.

Když je pro argument tvaru předáno `null`, jedná se o komentář na úrovni snímku. Jeho značka je umístěna podle zadaných souřadnic, ale není svázána s konkrétním tvarem, takže [IModernComment.Shape](https://reference.aspose.com/slides/cs/net/aspose.slides/imoderncomment/shape/) vrací `null`. Když je zadán [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/), komentář je ukotven k tomuto tvaru. Souřadnice i nadále určují pozici značky komentáře na snímku, zatímco svázání s tvarem lze získat přes [IModernComment.Shape](https://reference.aspose.com/slides/cs/net/aspose.slides/imoderncomment/shape/).

### **Ukotvení moderního komentáře ke tvaru**

Následující příklad vytvoří jak moderní komentář na úrovni snímku, tak moderní komentář ukotvený k určitému AutoShape. Poté z každého komentáře načte související tvar.

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

### **Ukotvení komentářů k různým typům tvarů**

Jakýkoli objekt snímku, který implementuje [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/), může být použit jako ukotvení tvaru. Běžné příklady zahrnují [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/cs/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/cs/net/aspose.slides/iconnector/) a instance [IGraphicalObject](https://reference.aspose.com/slides/cs/net/aspose.slides/igraphicalobject/) jako jsou grafy.

Následující příklad vytvoří několik běžných typů tvarů a ke každému přiřadí moderní komentář.

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

### **Ukotvení komentáře k textu a nastavení jeho stavu**

Pro moderní komentář spojený s [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/cs/net/aspose.slides/imoderncomment/textselectionstart/) určuje počáteční pozici vybraného textu v textovém rámci tvaru, zatímco [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/cs/net/aspose.slides/imoderncomment/textselectionlength/) určuje délku výběru. Tyto vlastnosti společně svazují komentář s konkrétním textovým rozsahem uvnitř AutoShape.

Vlastnost [IModernComment.Status](https://reference.aspose.com/slides/cs/net/aspose.slides/imoderncomment/status/) může být čtena nebo aktualizována hodnotou z výčtu [ModernCommentStatus](https://reference.aspose.com/slides/cs/net/aspose.slides/moderncommentstatus/):

- `NotDefined` — není definován žádný konkrétní stav moderního komentáře.
- `Active` — komentář je aktivní.
- `Resolved` — komentář byl vyřešen.
- `Closed` — komentář je uzavřen.

Následující příklad vytvoří moderní komentář ukotvený k tvaru, přiřadí jej k výběru textu, označí jej jako vyřešený, uloží prezentaci a po opětovném otevření souboru ověří hodnoty.

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

### **Prohlédnutí existujících moderních komentářů**

Pro prohlédnutí existující prezentace zkontrolujte, které komentáře implementují [IModernComment](https://reference.aspose.com/slides/cs/net/aspose.slides/imoderncomment/), poté prozkoumejte [IModernComment.Shape](https://reference.aspose.com/slides/cs/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/cs/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/cs/net/aspose.slides/imoderncomment/textselectionlength/) a [IModernComment.Status](https://reference.aspose.com/slides/cs/net/aspose.slides/imoderncomment/status/). `null` tvar označuje komentář na úrovni snímku. Pro ukotvení k [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) vlastnosti výběru textu určují související rozsah v textovém rámci tvaru.

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

## **Odstranění komentářů**

### **Odstranění všech komentářů a autorů komentářů**

Následující příklad ukazuje, jak odstranit všechny komentáře a autory komentářů z prezentace:

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

### **Odstranění konkrétních komentářů**

Následující příklad ukazuje, jak odstranit konkrétní komentáře ze snímku:

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

## **Často kladené otázky**

**Podporuje Aspose.Slides stav resolved pro moderní komentáře?**

Ano. [IModernComment.Status](https://reference.aspose.com/slides/cs/net/aspose.slides/imoderncomment/status/) může být čten a nastaven hodnotou z výčtu [ModernCommentStatus](https://reference.aspose.com/slides/cs/net/aspose.slides/moderncommentstatus/), včetně `Resolved`. Stav je uložen v prezentaci a může být znovu načten po opětovném otevření souboru.

**Jsou podporovány vlákna diskuzí (řetězce odpovědí) a existuje omezení zanoření?**

Ano. Každý komentář může odkazovat na svůj [parent comment](https://reference.aspose.com/slides/cs/net/aspose.slides/comment/parentcomment/), což umožňuje řetězce odpovědí. API neudává konkrétní limit hloubky zanoření.

**V jakém souřadnicovém systému je definována pozice značky komentáře na snímku?**

Pozice značky je definována pomocí číslicových souřadnic v souřadnicovém systému snímku, což vám umožňuje umístit ji přesně na snímek.