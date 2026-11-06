---
title: "Prezentációs megjegyzések kezelése .NET-ben"
linktitle: "Prezentációs megjegyzések"
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
- megjegyzés válasz
- megjegyzés eltávolítása
- megjegyzés törlése
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Prezentációs megjegyzések kezelése az Aspose.Slides for .NET segítségével: megjegyzések hozzáadása, olvasása, szerkesztése, válaszolás és eltávolítás a PowerPoint prezentációkban gyorsan és egyszerűen."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kezelhetők a bemutató megjegyzései az Aspose.Slides for .NET segítségével. Bemutatja a megjegyzésekkel kapcsolatos fő típusokat, és demonstrálja, hogyan lehet megjegyzéseket hozzáadni a diákhoz, elérni a meglévő megjegyzéseket, kezelni a válaszokat és a modern megjegyzéseket, valamint eltávolítani a megjegyzéseket egy prezentációból.

A példák lefedik a PowerPointban gyakran előforduló felülvizsgálati és együttműködési scenáriókat, például a megjegyzések szerzőkhöz való hozzárendelését, a megjegyzés szövegének és metaadatainak olvasását, a válaszláncok felépítését, valamint a kiválasztott vagy az összes megjegyzés eltávolítását.

A PowerPointban a megjegyzések annotációkként jelennek meg a diákon. Egy megjegyzés kiválasztása megjeleníti a szövegét és a kapcsolódó vitát.

A megjegyzések megjelenítése vagy elrejtése egy prezentáció megnyitásakor [Megjegyzések megjelenítése vagy elrejtése egy prezentáció megnyitásakor](/slides/hu/net/presentation-view-properties/).

## **Miért adjunk megjegyzéseket a prezentációkhoz?**

A megjegyzéseket felhasználhatja visszajelzés nyújtására és a kollégákkal való együttműködésre a prezentációk felülvizsgálata során.

Az Aspose.Slides for .NET a következő API-kat biztosítja a megjegyzésekkel való munkához:

* The [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) osztály, amely hozzáférést biztosít a prezentáció megjegyzés szerzőihez.
* The [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) interfész, amely egy egyedi szerzőhöz társított megjegyzéseket képviseli.
* The [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) interfész, amely információkat biztosít egy megjegyzésről, beleértve annak szerzőjét, létrehozási időpontját, pozícióját és szövegét.
* The [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) osztály, amely információkat ad egy szerzőről, beleértve a nevét, monogramját és a hozzá tartozó megjegyzéseket.

## **Diák megjegyzéseinek hozzáadása**

A példa két diát hoz létre, és egy megjegyzés szerzőt regisztrál a [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/) metódussal. A [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) metódust használja, hogy minden diára egy megjegyzést helyezzen, majd a [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) segítségével lekéri az első dia megjegyzéseit az adott szerző számára. A konzol kétszer jeleníti meg az első megjegyzés szövegét, demonstrálva a hozzáférést mind a dia, mind a szerző útján, és a mentett prezentáció mindkét megjegyzést tartalmazza.

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

## **Megjegyzés szerző keresése vagy létrehozása**

Amikor egy automatizált felülvizsgálat többször feldolgozza ugyanazt a prezentációt, adjon hozzá szerzőt előtte keresse meg a [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/) gyűjteményét. A [FindByNameAndInitials](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbynameandinitials/) mind a nevet, mind a monogramot egyezteti, és visszaad egy tömböt a megfelelő szerzőkkel, vagy egy üres tömböt, ha nincs egyezés. Ezzel szemben a [FindByName](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbyname/) csak névre keres, a monogram figyelembevétele nélkül. Az [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/) hívása már a gyűjteményben lévő névvel és monogrammal kivételt dob.

A példához egy prezentációfájlra van szükség, amely legalább egy diát tartalmaz. Két átfutás során újból felhasználja az első egyező szerzőt, vagy csak akkor hoz létre újat, ha az eredmény üres. Ha több egyezés van, a tömb első elemét választja a többi szerző egyesítése vagy eltávolítása nélkül. Ezután a [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) metódust hívja a kiválasztott szerzőre, és menti a prezentációt. A második átfutás megnyitja az első átfutás kimenetét és megismétli a műveletet.

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

A második átfutás egy újabb megjegyzést ad hozzá anélkül, hogy új szerzőt hozna létre vagy a meglévő megjegyzéseket eltávolítaná. A végleges fájl, `review_pass_2.pptx`, mindkét új megjegyzést a korábbi megjegyzésekkel együtt tartalmazza. Egy szerző újbóli felhasználása nem deduplikálja a megjegyzéseket: a többszöri ugyanazon megjegyzés hozzáadásának elkerülése érdekében külön duplikátum-ellenőrzést kell megvalósítani a hozzáadás előtt.

## **Diák megjegyzéseinek elérése**

A példa megnyit egy létező prezentációt, és beolvassa a [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/) gyűjteményét. Minden szerzőnél végigiterál a [Comments](https://reference.aspose.com/slides/net/aspose.slides/icommentauthor/comments/) elemein, és kiírja a dia számát, a megjegyzés szövegét, a szerző nevét és a létrehozás időpontját. A bemeneti prezentációnak megjegyzéseket kell tartalmaznia ahhoz, hogy a konzol kimenet megjelenjen.

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

## **Válaszok a megjegyzésekhez**

A szülő megjegyzés a válaszhierarchia tetején lévő eredeti megjegyzés. A [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) tulajdonság a [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) interfészben lehetővé teszi a megjegyzés szülőjének lekérését vagy beállítását.

A példa két szerző megjegyzéseit hozza létre, és a [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) segítségével épít válaszokat, beleértve egy válasz egy másik válaszra. A `null` átadása a [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) hívásnak minden szerző megjegyzéseit lekéri; a konzol minden bejegyzést a válaszhierarchiában való mélységnek megfelelően behúz. A példa menti a teljes vitát, meghívja a [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) metódust az első gyökér megjegyzésen, és egy második prezentációt ment, amelyből az a megjegyzés és a válaszai eltávolításra kerülnek.

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
* Ha a [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) metódust a [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) interfészben egy megjegyzés törlésére használják, akkor a megjegyzés összes válasza is törlésre kerül.
* Ha a [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) tulajdonság körkörös hivatkozást hoz létre, akkor egy [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) kivétel dobásra kerül.
{{% /alert %}}

## **Modern megjegyzések hozzáadása**

Modern megjegyzések kapcsolhatók a dia magához, egy konkrét alakzathoz vagy egy AutoShape szövegterületéhez. Az [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) metódus egy [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) argumentumot fogad el a dia és a megjegyzésjelző koordinátái mellett.

Amikor `null` értéket adunk meg az alakzat argumentumként, a megjegyzés dia-szintű megjegyzés lesz. A jelölő a megadott koordináták alapján kerül elhelyezésre, de nincs konkrét alakzathoz kötve, ezért az [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) `null` értéket ad vissza. Ha egy [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) kerül megadásra, a megjegyzés az adott alakzathoz lesz rögzítve. A koordináták továbbra is a megjegyzésjelző pozícióját határozzák meg a dián, míg az alakzatkapcsolat az [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) segítségével kérdezhető le.

### **Modern megjegyzés rögzítése egy alakzathoz**

A példa kétszer hívja meg az [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) metódust: egyszer `null` alakzattal egy dia-szintű megjegyzéshez, és egyszer egy téglalappal, mint rögzítőpont. A [Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) kiolvasása `True` értéket ad a dia-szintű megjegyzés null-ellenőrzésére és `Revenue title`-t az rögzített megjegyzéshez. Mindkét megjegyzés a prezentációval együtt mentésre kerül.

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

### **Megjegyzések rögzítése különböző alakzattípusokra**

Bármely diaobjektum, amely implementálja az [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) interfészt, használható alakzat rögzítőpontként. Gyakori példák: [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/net/aspose.slides/iconnector/), valamint [IGraphicalObject](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobject/) példányok, mint például diagramok.

A példa az [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) metódust használja, hogy megjegyzést társítson öt alakzattípushoz: egy AutoShape-hez, egy képkerethez, egy csoporthoz, egy csatlakozóhoz és egy diagramhoz. A kép beágyazott képadatot használ, ezért nincs szükség külső képre. Minden megjegyzésnek saját jelölőpozíciója van, és a mentett prezentáció megtartja az összes öt alakzathoz való társítást.

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

### **Megjegyzés rögzítése szöveghez és állapotának beállítása**

Egy [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)-hoz társított modern megjegyzés esetén az [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) a kijelölt szöveg kezdőpozícióját adja meg az alakzat szövegdobozában, míg az [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) a kijelölés hosszát. Ezek a tulajdonságok együtt a megjegyzést egy adott szövegtartományhoz kötik az AutoShape-ben.

Az [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) tulajdonság olvasható és beállítható egy [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/) értékkel:

- `NotDefined` — nincs meghatározott modern megjegyzés állapot.
- `Active` — a megjegyzés aktív.
- `Resolved` — a megjegyzés megoldásra került.
- `Closed` — a megjegyzés lezárva.

A példa egy modern megjegyzést rögzít a „quarterly revenue” szavakhoz egy téglalap szövegében. Kiszámítja a nullától induló [TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) értéket a szövegből, és beállítja a [TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) értékét a kiválasztott karakterek számára. A [Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) értékét `Resolved`-re állítva menti és újra megnyitja a prezentációt. A négy konzol-ellenőrzésnek mind `True`-t kell kiírnia, ezzel megerősítve, hogy az alakzat rögzítés, a szövegtartomány és az állapot megmaradt.

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

### **Meglévő modern megjegyzések vizsgálata**

A példa egy meglévő, modern megjegyzéseket tartalmazó prezentációra van szüksége, és kiírja azok szövegét, állapotát és rögzítési részleteit. A vizsgálathoz ellenőrizze, melyik megjegyzés valósítja meg az [IModernComment](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/) interfészt, majd vizsgálja meg az [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) és [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) értékeket. A `null` alakzat dia-szintű megjegyzést jelez. Egy [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) rögzítésnél a szövegkijelölés tulajdonságai az alakzat szövegdobozában lévő tartományt azonosítják.

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

Az Aspose.Slides for .NET lehetővé teszi, hogy egy prezentációból eltávolítsa az összes megjegyzést és azok szerzőit, vagy csak a kiválasztott megjegyzéseket törölje a többit megtartva. Az alábbi példák bemutatják mindkét megközelítést, és a frissített prezentációt mentik.

### **Minden megjegyzés és megjegyzés szerző eltávolítása**

A példa megnyit egy meglévő prezentációt, és minden szerzőre meghívja az [ICommentCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/clear/) metódust, majd meghívja az [ICommentAuthorCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/clear/) metódust, hogy eltávolítsa magukat a szerzőket is. A mentett prezentáció nem tartalmaz sem megjegyzéseket, sem megjegyzés szerzőket. Használjon egy megjegyzéseket tartalmazó prezentációt, hogy megfigyelje az eltávolítást.

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

### **Specifikus megjegyzések eltávolítása**

A példa egy dián két megjegyzést hoz létre, és a [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) segítségével megtalálja a megjegyzéseket minden szerző szerint. Összegyűjti azokat a megjegyzéseket, amelyek szövege „comment 1”, mielőtt meghívná az [ICommentCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/remove/) metódust, ezzel elkerülve a gyűjtemény módosítását a kiválasztás közben. A mentett prezentáció csak a „comment 2” megjegyzést tartja meg.

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

## **GYIK**

**Támogatja-e az Aspose.Slides a megoldott állapotot a modern megjegyzésekhez?**

Igen. Az [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) értéke olvasható és beállítható egy [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/) értékkel, beleértve a `Resolved`-t is. Az állapot a prezentációban tárolódik, és a fájl újranyitása után ismét olvasható.

**Támogatottak-e a szálas megbeszélések (válaszláncok), és van-e beágyazási korlát?**

Igen. Minden megjegyzés hivatkozhat a [parent comment](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/) elemre, ezáltal lehetővé téve a válaszláncokat. Az API nem határoz meg konkrét beágyazási mélységkorlátot.

**Milyen koordináta‑rendszerben van meghatározva egy megjegyzés jelzőjének pozíciója a dián?**

A jelző pozíciója lebegőpontos koordinátákkal van meghatározva a dia koordináta‑rendszerében, így pontosan elhelyezhető a dián.