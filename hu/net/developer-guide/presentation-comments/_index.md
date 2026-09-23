---
title: Prezentációs megjegyzések kezelése .NET-ben
linktitle: Prezentációs megjegyzések
type: docs
weight: 100
url: /hu/net/presentation-comments/
keywords:
- megjegyzés
- modern megjegyzés
- PowerPoint megjegyzések
- prezentációs megjegyzések
- dia megjegyzések
- megjegyzés hozzáadása
- megjegyzés elérése
- megjegyzés szerkesztése
- megjegyzésre válasz
- megjegyzés eltávolítása
- megjegyzés törlése
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Kezelje a prezentációs megjegyzéseket az Aspose.Slides for .NET segítségével: gyorsan és egyszerűen adjon hozzá, olvasson, szerkesszen, válaszoljon, és távolítson el megjegyzéseket a PowerPoint prezentációkban."
---
## **Áttekintés**

Ez a cikk ismerteti, hogyan kezelhetők a prezentációs megjegyzések az Aspose.Slides for .NET segítségével. Bemutatja a megjegyzésekkel kapcsolatos fő típusokat, és demonstrálja, hogyan adhatunk megjegyzéseket a diákhoz, hogyan érhetjük el a meglévő megjegyzéseket, hogyan dolgozhatunk válaszokkal és modern megjegyzésekkel, illetve hogyan távolíthatunk el megjegyzéseket egy prezentációból.

Az példák a PowerPoint gyakori felülvizsgálati és együttműködési forgatókönyveit fedik le, például a megjegyzések szerzőkhöz rendelését, a megjegyzés szövegének és metaadatainak olvasását, válaszkövetések építését, valamint a kiválasztott vagy az összes megjegyzés eltávolítását.

PowerPointban a megjegyzések annotációként jelennek meg a diákon. Egy megjegyzés kiválasztása megjeleníti annak szövegét és a kapcsolódó vitát.

A megjegyzések megjelenítésének vagy elrejtésének kérése a prezentáció megnyitásakor, a megjegyzések magától függetlenül, lásd [Megjelenítse vagy rejtse el a megjegyzéseket a prezentáció megnyitásakor](/slides/hu/net/presentation-view-properties/).

## **Miért érdemes megjegyzéseket adni a prezentációkhoz?**

A megjegyzésekkel visszajelzést adhat, és együttműködhet a kollégákkal a prezentációk felülvizsgálata során.

Az Aspose.Slides for .NET a következő API‑kat biztosítja a megjegyzésekkel való munkához:

* A [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztály, amely hozzáférést biztosít a prezentáció megjegyzés szerzőihez.
* A [ICommentCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/icommentcollection) interfész, amely egy adott szerzőhöz kapcsolódó megjegyzéseket képviseli.
* A [IComment](https://reference.aspose.com/slides/hu/net/aspose.slides/icomment) interfész, amely információkat nyújt egy megjegyzésről, beleértve a szerzőt, a létrehozás időpontját, a pozíciót és a szöveget.
* A [CommentAuthor](https://reference.aspose.com/slides/hu/net/aspose.slides/commentauthor) osztály, amely információkat ad egy szerzőről, beleértve a nevét, monogramját és a kapcsolódó megjegyzéseket.

## **Dia megjegyzések hozzáadása**
A következő példa bemutatja, hogyan adhatunk megjegyzéseket a diákhoz egy PowerPoint prezentációban:

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

## **Dia megjegyzések elérése**
A következő példa bemutatja, hogyan érhetjük el a meglévő megjegyzéseket egy PowerPoint prezentációban:

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

## **Válasz a megjegyzésekre**
A szülő megjegyzés az eredeti megjegyzés a válasz‑hierarchia tetején. A [ParentComment](https://reference.aspose.com/slides/hu/net/aspose.slides/icomment/properties/parentcomment) tulajdonság a [IComment](https://reference.aspose.com/slides/hu/net/aspose.slides/icomment) interfészen lehetővé teszi a megjegyzés szülőjének lekérdezését vagy beállítását.

A következő példa bemutatja, hogyan adhatunk válaszokat, és hogyan vizsgálhatjuk meg a kialakult megjegyzés‑hierarchiát:

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

* Amikor a [Remove](https://reference.aspose.com/slides/hu/net/aspose.slides/icomment/methods/remove) metódus a [IComment](https://reference.aspose.com/slides/hu/net/aspose.slides/icomment) interfészen keresztül egy megjegyzés törlésére használatos, akkor a megjegyzéshez tartozó összes válasz is törlésre kerül.
* Ha a [ParentComment](https://reference.aspose.com/slides/hu/net/aspose.slides/icomment/properties/parentcomment) tulajdonság körkörös hivatkozást hoz létre, akkor [PptxEditException](https://reference.aspose.com/slides/hu/net/aspose.slides/pptxeditexception) kivétel keletkezik.

{{% /alert %}}

## **Modern megjegyzések hozzáadása**

A modern megjegyzések társíthatók közvetlenül a diára, egy adott alakzatra vagy egy AutoShape szövegtartományára. Az [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/hu/net/aspose.slides/icommentcollection/addmoderncomment/) metódus egy [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/) argumentumot is fogad a dia- és megjegyzés‑jelölő koordináták mellett.

Ha a shape argumentum `null`, a megjegyzés dia‑szintű megjegyzés. Jelölőjét a megadott koordináták határozzák meg, de nincs hozzárendelve konkrét alakzathoz, ezért az [IModernComment.Shape](https://reference.aspose.com/slides/hu/net/aspose.slides/imoderncomment/shape/) `null`‑t ad vissza. Ha egy [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/) van megadva, a megjegyzés az adott alakzathoz van rögzítve. A koordináták továbbra is a megjegyzés jelölőjének helyét definiálják a dián, míg az alakzat társítást a [IModernComment.Shape](https://reference.aspose.com/slides/hu/net/aspose.slides/imoderncomment/shape/) szolgáltatja.

### **Modern megjegyzés formához rögzítése**
A következő példa létrehoz egy dia‑szintű modern megjegyzést és egy adott AutoShape‑hez rögzített modern megjegyzést, majd kiolvassa az egyes megjegyzésekhez kapcsolódó alakzatot.

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

### **Megjegyzések rögzítése különböző alakzat típusokhoz**
Bármely diaobjektum, amely megvalósítja az [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/) interfészt, használható alakzat‑horgonyként. Gyakori példák: [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/hu/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/hu/net/aspose.slides/iconnector/), valamint [IGraphicalObject](https://reference.aspose.com/slides/hu/net/aspose.slides/igraphicalobject/) példányok, például diagramok.

A következő példa több gyakori alakzattípust hoz létre, és mindegyikhez modern megjegyzést társít.

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

### **Megjegyzés szöveghez rögzítése és állapotának beállítása**
Egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/)‑hez társított modern megjegyzésnél az [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/hu/net/aspose.slides/imoderncomment/textselectionstart/) a kijelölt szöveg kezdőpozícióját, míg az [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/hu/net/aspose.slides/imoderncomment/textselectionlength/) a kijelölés hosszát adja meg. Ezek a tulajdonságok a megjegyzést egy adott szövegtartományhoz kötik az AutoShape‑ben.

Az [IModernComment.Status](https://reference.aspose.com/slides/hu/net/aspose.slides/imoderncomment/status/) tulajdonságot a [ModernCommentStatus](https://reference.aspose.com/slides/hu/net/aspose.slides/moderncommentstatus/) felsorolás egy értékével lehet beolvasni vagy beállítani:

- `NotDefined` — nincs meghatározott modern megjegyzés állapot.
- `Active` — a megjegyzés aktív.
- `Resolved` — a megjegyzés megoldott.
- `Closed` — a megjegyzés lezárt.

A következő példa létrehoz egy alakzathoz rögzített modern megjegyzést, szövegkijelöléshez társítja, megoldottként jelöli, elmenti a prezentációt, majd a fájl újranyitása után ellenőrzi az értékeket.

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

### **Meglévő modern megjegyzések ellenőrzése**
Egy meglévő prezentáció ellenőrzéséhez először vizsgálja meg, mely megjegyzések implementálják az [IModernComment](https://reference.aspose.com/slides/hu/net/aspose.slides/imoderncomment/) interfészt, majd tekintse meg az [IModernComment.Shape](https://reference.aspose.com/slides/hu/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/hu/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/hu/net/aspose.slides/imoderncomment/textselectionlength/) és az [IModernComment.Status](https://reference.aspose.com/slides/hu/net/aspose.slides/imoderncomment/status/) értékeket. A `null` alakzat dia‑szintű megjegyzést jelez. Egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) horgony esetén a szövegkijelölés‑tulajdonságok határozzák meg a kapcsolódó tartományt az alakzat szövegkeretében.

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

## **Megjegyzések eltávolítása**

### **Minden megjegyzés és megjegyzés szerző eltávolítása**
A következő példa bemutatja, hogyan távolítható el az összes megjegyzés és a megjegyzés szerzői egy prezentációból:

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

### **Speciális megjegyzések eltávolítása**
A következő példa bemutatja, hogyan távolítható el egy konkrét megjegyzés egy diáról:

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

**Támogatja az Aspose.Slides a modern megjegyzések megoldott állapotát?**

Igen. Az [IModernComment.Status](https://reference.aspose.com/slides/hu/net/aspose.slides/imoderncomment/status/) beolvasható és beállítható egy [ModernCommentStatus](https://reference.aspose.com/slides/hu/net/aspose.slides/moderncommentstatus/) értékkel, beleértve a `Resolved`‑t. Az állapot a prezentációban tárolódik, és a fájl újranyitása után újra kiolvasható.

**Támogatottak a szálas viták (válasz‑láncok), és van-e mélységi korlátozás?**

Igen. Minden megjegyzés hivatkozhat a [parent comment](https://reference.aspose.com/slides/hu/net/aspose.slides/comment/parentcomment/)‑re, ami lehetővé teszi a válasz‑láncokat. Az API nem definiál konkrét mélységi korlátot.

**Milyen koordináta‑rendszerben van definiálva egy megjegyzés jelölőjének pozíciója a dián?**

A jelölő pozíciója lebegőpontos koordinátákkal van megadva a dia koordináta‑rendszerében, ami lehetővé teszi a pontos elhelyezést a dián.