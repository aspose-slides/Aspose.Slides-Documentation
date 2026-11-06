---
title: Správa komentářů v prezentaci v .NET
linktitle: Komentáře v prezentaci
type: docs
weight: 100
url: /cs/net/presentation-comments/
keywords:
- komentář
- moderní komentář
- komentáře PowerPoint
- komentáře v prezentaci
- komentáře na snímcích
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
description: "Spravujte komentáře v prezentacích pomocí Aspose.Slides pro .NET: přidávejte, čtěte, upravujte, odpovídejte na a odstraňujte komentáře v prezentacích PowerPoint rychle a snadno."
---
## **Přehled**

Tento článek vysvětluje, jak spravovat poznámky v prezentaci pomocí Aspose.Slides pro .NET. Představuje hlavní typy související s poznámkami a ukazuje, jak přidávat poznámky do snímků, přistupovat k existujícím poznámkám, pracovat s odpověďmi a moderními poznámkami a odstraňovat poznámky z prezentace.

Příklady pokrývají běžné scénáře recenzí a spolupráce v PowerPointu, jako je přiřazování poznámek autorům, čtení textu a metadat poznámky, vytváření řetězců odpovědí a odstraňování vybraných nebo všech poznámek.

V PowerPointu se poznámky zobrazují jako anotace na snímcích. Po výběru poznámky se zobrazí její text a související diskuse.

Chcete‑li, aby se při otevření prezentace zobrazily nebo skryly poznámky, aniž byste měnili samotné poznámky, viz [Zobrazit nebo skrýt poznámky při otevírání prezentace](/slides/cs/net/presentation-view-properties/).

## **Proč přidávat poznámky do prezentací?**

Poznámky můžete použít k poskytnutí zpětné vazby a spolupráci s kolegy při recenzování prezentací.

Aspose.Slides pro .NET poskytuje následující rozhraní pro práci s poznámkami:

* Třídu [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), která umožňuje přístup k autorům poznámek v prezentaci.
* Rozhraní [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection), které představuje poznámky přiřazené k jednotlivému autorovi.
* Rozhraní [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment), které poskytuje informace o poznámce, včetně autora, času vytvoření, polohy a textu.
* Třídu [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor), která poskytuje informace o autorovi, včetně jména, iniciál a přiřazených poznámek.

## **Přidání poznámek ke snímkům**

Příklad vytvoří dva snímky a zaregistruje autora poznámek pomocí [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/). Použije [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) k umístění jedné poznámky na každý snímek, poté získá poznámky z prvního snímku pro daného autora pomocí [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/). Konzole vypíše text první poznámky dvakrát, čímž demonstruje přístup jak přes snímek, tak přes autora, a uložená prezentace obsahuje obě poznámky.

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

## **Vyhledání nebo vytvoření autora poznámek**

Když automatizovaný proces recenze opakovaně zpracovává stejnou prezentaci, před přidáním autora prohledá kolekci [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/). Metoda [FindByNameAndInitials](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbynameandinitials/) porovná jak jméno, tak iniciály a vrátí pole odpovídajících autorů nebo prázdné pole, pokud žádná shoda neexistuje. Naopak [FindByName](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbyname/) hledá pouze podle jména, bez ohledu na iniciály. Volání [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/) s již existujícím jménem a iniciálami v kolekci vyvolá výjimku.

Příklad vyžaduje soubor prezentace s alespoň jedním snímkem. V každém ze dvou průchodů znovu použije první nalezeného autora nebo jej vytvoří jen v případě, že výsledek je prázdný. Pokud existuje více shod, vybere první prvek pole bez slučování nebo odstraňování ostatních autorů. Poté zavolá [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) pro vybraného autora a uloží prezentaci. Druhý průchod otevře výstup z prvního průchodu a operaci opakuje.

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

Druhý průchod přidá další poznámku bez vytvoření dalšího autora nebo odstraňování existujících poznámek. Výsledný soubor `review_pass_2.pptx` obsahuje obě nové poznámky vedle všech původních. Znovupoužití autora neduplikovat poznámky: aby se zabránilo opakovanému přidávání stejné poznámky, implementujte samostatnou detekci duplicit před jejím přidáním.

## **Přístup k poznámkám ve snímcích**

Příklad otevře existující prezentaci a načte její kolekci [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/). Pro každého autora iteruje přes [Comments](https://reference.aspose.com/slides/net/aspose.slides/icommentauthor/comments/) a vypíše číslo snímku, text poznámky, jméno autora a čas vytvoření. Vstupní prezentace musí obsahovat poznámky, aby byl generován výstup v konzoli.

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

## **Odpovídání na poznámky**

Rodičovská poznámka je původní poznámka na vrcholu hierarchie odpovědí. Vlastnost [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) rozhraní [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) umožňuje získat nebo nastavit rodiče poznámky.

Příklad vytvoří poznámky od dvou autorů a použije [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) k vytvoření odpovědí, včetně odpovědi na další odpověď. Předání `null` do [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) načte poznámky od všech autorů; konzole odsazuje každý záznam podle hloubky v hierarchii odpovědí. Příklad uloží celou diskusi, zavolá [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) na první kořenovou poznámku a uloží druhou prezentaci, ve které je tato poznámka spolu s odpověďmi odstraněna.

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
* Když se metodou [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) rozhraní [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) smaže poznámka, všechny odpovědi na tuto poznámku jsou také smazány.
* Pokud vlastnost [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) vytvoří kruhový odkaz, je vyvolána výjimka [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception).
{{% /alert %}}

## **Přidání moderních poznámek**

Moderní poznámky mohou být přiřazeny přímo ke snímku, k určitému tvaru nebo k textovému úseku uvnitř AutoShape. Metoda [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) přijímá argument [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) vedle snímku a souřadnic značky poznámky.

Když je jako argument tvaru předáno `null`, jedná se o poznámku na úrovni snímku. Její značka je umístěna podle zadaných souřadnic, ale není svázána s konkrétním tvarem, takže [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) vrací `null`. Když je předán [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), je poznámka ukotvena k tomuto tvaru. Souřadnice i nadále určují pozici značky na snímku, zatímco vazba na tvar je získatelná přes [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/).

### **Ukotvení moderní poznámky k tvaru**

Příklad dvakrát zavolá [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/): jednou s `null` tvarem pro poznámku na úrovni snímku a podruhé s obdélníkem jako ukotvením. Načtení [Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) vypíše `True` pro kontrolu null u poznámky na úrovni snímku a `Revenue title` pro ukotvenou poznámku. Obě poznámky jsou uloženy s prezentací.

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

### **Ukotvení poznámek k různým typům tvarů**

Každý objekt snímku, který implementuje [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), může být použit jako ukotvení. Běžné příklady zahrnují [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/net/aspose.slides/iconnector/) a instance [IGraphicalObject](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobject/) jako jsou grafy.

Příklad použije [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) k přiřazení poznámky k pěti typům tvarů: AutoShape, obrázku, skupině, spojce a grafu. Obrázek používá vložená data, takže není potřeba externí soubor. Každá poznámka má vlastní pozici značky a uložená prezentace si zachová všech pět vazeb na tvary.

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

### **Ukotvení poznámky k textu a nastavení jejího stavu**

Pro moderní poznámku přiřazenou k [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) určuje [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) počáteční pozici vybraného textu v textovém rámci tvaru, zatímco [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) stanovuje délku výběru. Společně tyto vlastnosti spojují poznámku s konkrétním textovým úsekem uvnitř AutoShape.

Vlastnost [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) může být čtena nebo aktualizována hodnotou z výčtu [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/):

- `NotDefined` — není definován žádný konkrétní stav moderní poznámky.
- `Active` — poznámka je aktivní.
- `Resolved` — poznámka byla vyřešena.
- `Closed` — poznámka je uzavřena.

Příklad ukotví moderní poznámku k výrazům „quarterly revenue“ v textu obdélníka. Vypočítá nulově‑základní [TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) z textu a nastaví [TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) na počet vybraných znaků. Po nastavení [Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) na `Resolved` prezentaci uloží a znovu otevře. Čtyři kontroly v konzoli by měly každá vypsat `True`, což potvrzuje zachování ukotvení tvaru, textového úseku a stavu.

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

### **Prohlédnutí existujících moderních poznámek**

Příklad vyžaduje existující prezentaci obsahující moderní poznámky a vypíše jejich text, stav a podrobnosti ukotvení. Pro inspekci zkontrolujte, které poznámky implementují [IModernComment](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/), poté prohlédněte [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) a [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/). `null` tvar naznačuje poznámku na úrovni snímku. Pro ukotvení k [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) vlastnosti výběru textu určují odpovídající úsek v textovém rámci tvaru.

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

## **Odstranění poznámek**

Aspose.Slides pro .NET umožňuje odstranit všechny poznámky a jejich autory z prezentace nebo smazat vybrané poznámky a ponechat ostatní. Následující příklady ukazují oba přístupy a ukládají aktualizovanou prezentaci.

### **Odstranění všech poznámek a autorů poznámek**

Příklad otevře existující prezentaci a pro každého autora zavolá [ICommentCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/clear/), poté zavolá [ICommentAuthorCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/clear/) k odstranění samotných autorů. Uložená prezentace neobsahuje ani poznámky, ani autory poznámek. Použijte prezentaci obsahující poznámky, abyste viděli výsledek odstranění.

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

### **Odstranění konkrétních poznámek**

Příklad vytvoří dvě poznámky na jednom snímku a pomocí [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) najde poznámky podle každého autora. Shromáždí poznámky, jejichž text je roven „comment 1“, před voláním [ICommentCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/remove/), aby nedošlo ke změně kolekce během výběru. Uložená prezentace si ponechá jen „comment 2“.

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

**Podporuje Aspose.Slides stav „vyřešeno“ pro moderní poznámky?**

Ano. [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) lze číst a nastavit hodnotou z [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/), včetně `Resolved`. Stav je uložen v prezentaci a lze jej opět přečíst po opětovném otevření souboru.

**Jsou podporovány vlákna diskusí (řetězce odpovědí) a existuje limit hloubky vnoření?**

Ano. Každá poznámka může odkazovat na svou [parent comment](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/), což umožňuje řetězce odpovědí. API nedefinuje konkrétní limit hloubky vnoření.

**V jakém souřadnicovém systému je definována pozice značky poznámky na snímku?**

Pozice značky je definována jako desetinné souřadnice v souřadnicovém systému snímku, což umožňuje přesné umístění na snímku.