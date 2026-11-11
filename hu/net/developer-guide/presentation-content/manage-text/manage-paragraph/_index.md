---
title: PowerPoint szöveg bekezdések kezelése .NET-ben
linktitle: Bekezdés kezelése
type: docs
weight: 40
url: /hu/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- szöveg hozzáadása
- bekezdés hozzáadása
- szöveg kezelése
- bekezdés kezelése
- pont kezelése
- bekezdés behúzás
- függő behúzás
- bekezdés pont
- számozott lista
- pontozott lista
- bekezdés tulajdonságok
- HTML importálása
- szöveg HTML-re
- bekezdés HTML-re
- bekezdés képbe
- szöveg képbe
- bekezdés exportálása
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és formázhat bekezdéseket, részeket, pontokat, számozott listákat, behúzásokat, HTML-tartalmat és bekezdésképeket az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

Aspose.Slides for .NET a szöveget szövegkeretek, bekezdések és részek hierarchiájaként ábrázolja:

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) a szövegtárolót jelenti egy alakzatban, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) egy bekezdést képvisel egy szövegkeretben, és hozzáférést biztosít a részeihez és a bekezdés szintű formázáshoz.
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) egy szövegszakaszt jelöl egy bekezdésen belül. Minden rész saját szöveggel és karakter szintű formázással rendelkezhet.

Egy bekezdés ezért több különböző betűtípust, színt, méretet és egyéb formázást tartalmazhat több rész használatával.

## **Bekezdések létrehozása és formázása**

Hozzon létre bekezdéseket egy alakzat szövegkeretében, és használja a részeket egyedi szövegszakaszok formázásához. Ez a szakasz bemutatja, hogyan kombináljon több részt minden bekezdésben, és alkalmazzon különböző színeket, betűméreteket és stílusokat.

### **Bekezdések létrehozása több résszel**

Az alábbi C# példa három bekezdést hoz létre, mindegyik három szövegszakaszt tartalmaz a [IParagraph.Portions](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/portions/) gyűjteményében. Újrahasználja az alapértelmezett bekezdést és annak üres részét, majd hozzáadja a maradék bekezdéseket és részeket. A formázást a [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/) segítségével alkalmazza: az első rész minden bekezdésben piros, félkövér és 15 pont; a második kék, dőlt és 18 pont. A harmadik rész megtartja az alapértelmezett formázást:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
var textFrame = shape.TextFrame;

var firstParagraph = textFrame.Paragraphs[0];
firstParagraph.Portions.Add(new Portion());
firstParagraph.Portions.Add(new Portion());

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph();
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(thirdParagraph);

var paragraphCount = textFrame.Paragraphs.Count;
for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    var paragragaph = textFrame.Paragraphs[paragraphIndex];
    var portionCount = paragragaph.Portions.Count;
    for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        var portion = paragragaph.Portions[portionIndex];
        portion.Text = $"Portion {paragraphIndex + 1}.{portionIndex + 1}";

        if (portionIndex == 0)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
            portion.PortionFormat.FontBold = NullableBool.True;
            portion.PortionFormat.FontHeight = 15;
        }
        else if (portionIndex == 1)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontHeight = 18;
        }
    }
}

presentation.Save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
```

## **Pontozott és számozott listák létrehozása**

Szervezze a bekezdés szövegét listákba szimbólumokkal, számokkal vagy egyedi képekkel. E szakasz példái a pontformázást, a többszintű listákat és az egyedi kezdőszámokat fedik le.

### **Pontozott vagy számozott lista létrehozása**

A pontok és a számozás megkönnyítik a kapcsolódó elemek áttekintését. Az Aspose.Slides-ben a lista beállításait a [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) definiálja.

Ez a C# példa egy szimbólum pontot és egy számozott elemet ad ugyanahhoz a szövegkerethez. A [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) választja ki a pont típusát, a [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) adja meg a szimbólumot, a [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) pedig a számozási stílust. Mindkét elem fekete pontot használ 100 % magassággal és 25 pont bekezdés behúzással:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var symbolParagraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
symbolParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
symbolParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
symbolParagraph.ParagraphFormat.Indent = 25;
symbolParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
symbolParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
symbolParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
symbolParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(symbolParagraph);

var numberedParagraph = new Paragraph { Text = "This is a numbered item" };
numberedParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
numberedParagraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;
numberedParagraph.ParagraphFormat.Indent = 25;
numberedParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
numberedParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
numberedParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
numberedParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(numberedParagraph);

presentation.Save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
```

### **Képes pontok használata**

A képes pontok lehetővé teszik, hogy egy egyedi képet használjon szimbólum vagy szám helyett.

Ez a C# példa egy képet ad a bemutató képgyűjteményéhez egy [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/)ként, és bekezdés pontként használja. A [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) értékét képes pontként állítja be, és a képet a [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/) adja át. A [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) 100 %‑re van állítva, hogy a pont méretét a bekezdés szövegéhez viszonyítsa:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var bulletImage = Images.FromFile("bullets.png");
var presentationImage = presentation.Images.AddImage(bulletImage);

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = presentationImage;
paragraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(paragraph);

presentation.Save("picture_bullet.pptx", SaveFormat.Pptx);
presentation.Save("picture_bullet.ppt", SaveFormat.Ppt);
```

### **Többszintű lista létrehozása**

Állítsa be a [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) értékét, hogy a bekezdéseket a lista különböző szintjein helyezze el. A legfelső szint mélysége `0`.

Ez a C# példa a [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) értékeket 0‑tól 3‑ig rendeli négy bekezdéshez, egy hierarchiát létrehozva egy szövegkeretben. Minden bekezdés szimbólum pontot használ, a [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) váltakozik egy kör pont és egy kötőjel között a szomszédos szintek megkülönböztetéséhez:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Content" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
firstParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.Depth = 0;

var secondParagraph = new Paragraph { Text = "Second level" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
secondParagraph.ParagraphFormat.Bullet.Char = '-';
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.Depth = 1;

var thirdParagraph = new Paragraph { Text = "Third level" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
thirdParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.Depth = 2;

var fourthParagraph = new Paragraph { Text = "Fourth level" };
fourthParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
fourthParagraph.ParagraphFormat.Bullet.Char = '-';
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
fourthParagraph.ParagraphFormat.Depth = 3;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);
textFrame.Paragraphs.Add(fourthParagraph);

presentation.Save("multilevel_list.pptx", SaveFormat.Pptx);
```

### **Számozott listaelemek indítása egyedi értékekkel**

Használja a [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) beállítást, hogy megadja a számozott bekezdés kezdeti számát.

Ez a C# példa a [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) értékét számozásra állítja három bekezdéshez, és a [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) értékeit 2, 3 és 7‑re állítja. A kezdőérték minden bekezdésnél külön kerül beállításra, lehetővé téve a számok kihagyását:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Start at 2" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
firstParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
textFrame.Paragraphs.Add(firstParagraph);

var secondParagraph = new Paragraph { Text = "Start at 3" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
secondParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 3;
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph { Text = "Start at 7" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
thirdParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("custom_numbered_list.pptx", SaveFormat.Pptx);
```

## **Bekezdés elrendezésének és vége tulajdonságainak vezérlése**

Állítsa be a bekezdés margókat és behúzásokat, hogy szabályozza az első sor és a törött sorok helyzetét. A bekezdés végjeleket is formázhatja külön a látható szöveg részeitől.

### **Első sor behúzásának beállítása**

Használja az [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) tulajdonságot az első sor behúzásának szabályozásához. Ez a tulajdonság csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés törzséhez igazodik.

Használja az [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) tulajdonságot, ha az egész bekezdést szeretné eltolni. Használja az [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) tulajdonságot, ha csak az első sort akarja eltolni.

Az alábbi példa három bekezdésnek ugyanazt a [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) értéket 20 pont, valamint [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) értékeket 0, 20 és 40 pontot ad. Az első sorok fokozatosan nagyobb eltolással indulnak, míg a megtörött sorok ugyanazt a bal margót tartják:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "No first-line indent. Wrapped lines start at the same position as the first line." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 20;
firstParagraph.ParagraphFormat.Indent = 0;

var secondParagraph = new Paragraph { Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 20;
secondParagraph.ParagraphFormat.Indent = 20;

var thirdParagraph = new Paragraph { Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see." };
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.MarginLeft = 20;
thirdParagraph.ParagraphFormat.Indent = 40;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
```

Az eredmény:

![Az első sor behúzása a bekezdésekben](first_line_indent.png)

### **Függő behúzás beállítása**

A függő behúzás olyan bekezdéselrendezés, ahol az első sor balra indul a többi sorhoz képest. Az Aspose.Slides-ben ezt a hatást a [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) tulajdonsággal hozza létre. Az `Indent` értékét negatívra állítva az első sor balra mozdul a bekezdés törzséhez képest.

Gyakorlatban az [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) határozza meg a bekezdés törzsének bal pozícióját, az [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) pedig az első sor pozícióját ehhez a margóhoz képest. Függő behúzás létrehozásához állítson be egy pozitív `MarginLeft` értéket és egy negatív `Indent` értéket.

Ez a formázás bibliográfiák, hivatkozások, szószedetek és más bekezdések esetén hasznos, ahol a megtörött soroknak a bekezdés törzsének alá kell illeszkedniük, nem pedig az első sor első karaktere alá.

Az alábbi C# példa a [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) értékeit 40 és 60 ponttal párosítja a [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) -20 és -30 pont értékeivel. Minden bekezdésben az első sor balra indul a megtörött sorokhoz képest; a második bekezdés mélyebb függő behúzást kap:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 40;
firstParagraph.ParagraphFormat.Indent = -20;

var secondParagraph = new Paragraph { Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 60;
secondParagraph.ParagraphFormat.Indent = -30;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A függő behúzás a bekezdéseknél](hanging_indent.png)

### **Bekezdés végjellemzőinek beállítása**

Az [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) tulajdonság szabályozza a bekezdés végjellel kapcsolatos formázást. Az alábbi példa egy [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) objektumot hoz létre, amelynek [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) értéke 48 pont, és [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/) értéke Times New Roman. Ezt a formátumot a második bekezdés végjelére alkalmazza, miközben a látható szövegrésszek változatlanok maradnak:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph();
firstParagraph.Portions.Add(new Portion("Sample text"));

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion("Sample text 2"));

var endParagraphFormat = new PortionFormat();
endParagraphFormat.FontHeight = 48;
endParagraphFormat.LatinFont = new FontData("Times New Roman");
secondParagraph.EndParagraphPortionFormat = endParagraphFormat;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("end_paragraph_format.pptx", SaveFormat.Pptx);
```

## **Megjelenített sorok számlálása**

A bekezdés szabályai, amelyek az automatikus tördelést és a sorvégi írásjelek kezelését befolyásolják, megtalálhatók a [Control Line Breaking](/slides/hu/net/text-formatting/#control-line-breaking) és a [Control Hanging Punctuation](/slides/hu/net/text-formatting/#control-hanging-punctuation) oldalakon.

Használja az [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) metódust a bekezdés által elfoglalt sorok számának meghatározásához a szöveg elrendezése után, beleértve az automatikus tördelést. Ez hasznos a szöveg hossza és elrendezése ellenőrzésénél prezentációs sablonokban.

A bekezdés egy elem a [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/) gyűjteményben, és több megjelenített sort is elfoglalhat. Egy explicit sortörés a bekezdésen belül új sort hoz létre anélkül, hogy új bekezdést hozna létre. Az automatikus tördelés a rendelkezésre álló szélesség alapján hoz létre sorokat anélkül, hogy explicit sortöréseket illesztene a szövegbe. A bekezdések vagy sortörés karakterek számlálása ezért nem adja meg a megjelenített sorok számát.

Az alábbi példa létrehoz egy szöveg alakzatot, megszámolja annak sorait, szűkíti az alakzatot, majd rövidebb karakterláncra cseréli a szöveget. A példa engedélyezi az [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) beállítást, és letiltja az [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) opciót, így az alakzat szélessége szabályozza a tördelést anélkül, hogy automatikusan zsugorítaná a szöveget vagy átméretezné az alakzatot. Minden mérés a [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) metódust használja. Az alakzat méretei pontban vannak megadva. Végül a példa egy újabb bekezdést ad hozzá, és összeadja a sorok számát a szövegkeretben.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;

var paragraph = textFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
paragraph.Text = "This text demonstrates how automatic wrapping changes the number of rendered lines.";
Console.WriteLine($"Original width: {paragraph.GetLinesCount()}");

shape.Width = 150;
Console.WriteLine($"Narrower shape: {paragraph.GetLinesCount()}");

paragraph.Text = "Short text.";
Console.WriteLine($"Shorter text: {paragraph.GetLinesCount()}");

var secondParagraph = new Paragraph { Text = "Another paragraph." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
textFrame.Paragraphs.Add(secondParagraph);

var totalLineCount = 0;
foreach (var currentParagraph in textFrame.Paragraphs)
{
    totalLineCount += currentParagraph.GetLinesCount();
}
Console.WriteLine($"Total lines in the text frame: {totalLineCount}");
```

Ezzel a szöveggel és ezekkel a méretekkel a forma szűkítése megnöveli a sorok számát, míg a szöveg rövid karakterláncra cserélése csökkenti azt. A pontos számok betűkészlet elérhetőségtől és helyettesítéstől, betűmérettől, margóktól, behúzástól, tördeléstől és az automatikus illesztés beállításaitól függnek. Használja a célkörnyezetre szánt betűkészleteket és elrendezési beállításokat sablon ellenőrzésekor.

Maguk a sorok száma önmagában nem határozza meg, hogy a szöveg túlnyúlik-e a tárolón. A rendelkezésre álló magasság, sormagasságok, bekezdés‑ és sortávolság, valamint az automatikus illesztés viselkedése is számít; még egyetlen sor is meghaladhatja a rendelkezésre álló szélességet, ha a tördelés le van tiltva.

## **Bekezdés tartalom importálása és exportálása**

Használja a HTML‑t a szöveg bemutatóba történő importálásához vagy a meglévő bekezdések exportálásához, hogy azok külső felhasználásra is rendelkezésre álljanak. Ez a szakasz bemutatja, hogyan renderelhet egyedi bekezdéseket képként, beleértve a táblázatcellákban lévő bekezdéseket is.

### **HTML‑szöveg importálása bekezdésekbe**

Használja a [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) metódust, hogy HTML‑jelölést alakítson bekezdésekké és részekké egy szövegkeretben.

Ez a C# példa HTML‑t olvas be egy fájlból, és átadja a [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) metódusnak. Törli a szövegkeret alapértelmezett bekezdését, hogy a keret csak a importált tartalmat tartalmazza. A téglalap alakzat 10 pont margót hagy a dia minden oldalán:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shapeWidth = presentation.SlideSize.Size.Width - 20;
var shapeHeight = presentation.SlideSize.Size.Height - 20;
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
shape.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

using var reader = new StreamReader("file.html");
var html = reader.ReadToEnd();
shape.TextFrame.Paragraphs.AddFromHtml(html);

presentation.Save("html_text.pptx", SaveFormat.Pptx);
```

### **Bekezdés szöveg exportálása HTML‑be**

Használja a [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) metódust, hogy a kiválasztott bekezdéstartományt HTML‑ként exportálja. Ha egy prezentáció szövegét szeretné egy weboldalon újra felhasználni, előfordulhat, hogy meg akarja őrizni a helyi hangsúlyt anélkül, hogy a prezentáció betűtípusa, mérete vagy szövegdoboz‑stílusa átkerülne. Állítsa be a [TextToHtmlConversionOptions.TextInheritanceLimit](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/textinheritancelimit/) értékét, hogy szabályozza, mennyire követi a konvertáló a formázási öröklődést.

Töltse le a [mintaprezentációt](text-inheritance.pptx), és helyezze el az alkalmazás munkakönyvtárában. Az első dia egy szövegdobozt tartalmaz a "Inherited text; explicit red 18pt" szöveggel. A bemenet szándékosan több formázási szintet használ:

- A prezentáció alapértelmezett szövegstílusa Calibri‑t és 28 pt méretet ad.
- A szövegkeret első szintű szövegstílusa kék szöveget és dőlt betűt biztosít.
- A bekezdés kifejezetten félkövér szöveget állít be.
- A második rész, "explicit red 18pt", kifejezetten piros szöveget és 18 pt méretet állít be.

Az alábbi teljes példa háromszor exportálja ugyanazokat a bekezdéseket. A [TextToHtmlConversionOptions](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/) objektumot adja át az exportálási metódusnak, és minden eredményt külön UTF‑8 HTML‑fájlba ír:

```csharp
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("text-inheritance.pptx");
var textShape = (IAutoShape)presentation.Slides[0].Shapes[0];

var paragraphs = textShape.TextFrame.Paragraphs;
var modes = new[] { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };

foreach (var mode in modes)
{
    var options = new TextToHtmlConversionOptions { TextInheritanceLimit = mode };

    var html = paragraphs.ExportToHtml(0, paragraphs.Count, options);
    File.WriteAllText($"{mode}.html", html, Encoding.UTF8);
}
```

A generált HTML a következő CSS‑t tartalmazza az első részhez, "Inherited text; ". A táblázat a releváns deklarációkat sorolja; a többi generált tulajdonság a tisztaság kedvéért el van hagyva.

| Kimenet | Az első részhez tartozó releváns CSS | Megjelenés |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Kék, félkövér, dőlt szöveg 28 pt‑en Calibri‑val, ha az a betűtípus elérhető. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Kék, félkövér, dőlt szöveg; a környező oldal vagy böngésző biztosítja a betűcsaládot és a méretet. |
| `ParagraphOnly.html` | `font-weight:bold` | Félkövér szöveg; a környező oldal vagy böngésző biztosítja a betűcsaládot, méretet, színt és a dőlt stílust. |

A második rész megtartja a `color:#ff0000`, `font-size:18pt` és `font-weight:bold` értékeket mindhárom kimenetben. Emellett az `All` és a `TextBox` esetében megtartja a dőlt stílust, de a `ParagraphOnly` esetében nem. Az öröklődés korlátozása tehát nem távolítja el a bekezdéshez vagy részhez explicit módon hozzárendelt formázást.

Nyissa meg a fájlokat ugyanabban a böngészőben a összehasonlításhoz. A két korlátozott módban kihagyott CSS‑tulajdonságokat a céloldal stílusai vagy a böngésző alapbeállításai oldják fel, így a megjelenés attól függ, hol használják a HTML‑t.

### **HTML‑vágólap‑fragment generálása**

Állítsa a [AddClipboardFragmentHeader](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/addclipboardfragmentheader/) értékét `false`‑ra egyszerű HTML‑hez vagy `true`‑ra a vágólap‑fejléchez. Mindkét hívás egy karakterláncot ad vissza. A fejléc tartalmazza a környező HTML (`StartHTML` és `EndHTML`) valamint a beillesztendő tartalom (`StartFragment` és `EndFragment`) UTF‑8 bájteltolásait.

Ez a példa két formázott bekezdést exportál egyszerű HTML‑ként (`html`) és HTML‑vágólap‑fragmentként (`clipboardHtml`). A fragmentum rendszer‑vágólapra írása egy külön alkalmazási lépés. Egy vágólap‑API, amely nyers HTML‑vágólap‑bájtot fogad, UTF‑8‑at BOM nélkül igényel.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 400, 100);
var paragraphs = shape.TextFrame.Paragraphs;
paragraphs.Clear();
paragraphs.AddFromHtml("<p>Status: <b>Ready</b></p><p><i>Next steps</i></p>");

var options = new TextToHtmlConversionOptions { AddClipboardFragmentHeader = false };
var html = paragraphs.ExportToHtml(0, paragraphs.Count, options);

options.AddClipboardFragmentHeader = true;
var clipboardHtml = paragraphs.ExportToHtml(0, paragraphs.Count, options);
```

### **Bekezdés renderelése képként**

Az [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) közvetlenül renderel egy egyedi bekezdést, és egy [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) objektumot ad vissza. A végeredményt mentse fájlba vagy stream‑be a [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) metódussal. Nem szükséges a tartalmazó alakzatot renderelni vagy egy bitmap‑et manuálisan kivágni.

Az [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) `null`‑t ad vissza, ha a bekezdés nem található meg a szülő gyűjteményben, nincs érvényes renderelési határa, vagy nem renderelhető. Ellenőrizze az eredményt a mentés előtt, és a használat után szabadítsa fel a visszaadott képet.

#### **Bekezdés renderelése alapértelmezett mérettel**

A példa egy egyetlen diárral rendelkező prezentációt használ, amelynek első alakzata egy három bekezdést tartalmazó szövegdoboz.

![A három bekezdést tartalmazó szövegdoboz](paragraph_to_image_input.png)

Az alábbi példa a második bekezdést (index 1) választja ki, és a [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) metódust méretparaméterek nélkül hívja. Ellenőrzi, hogy az alakzat tartalmazza-e a szükséges bekezdést, és hogy a renderelés képet ad‑e vissza, mielőtt a [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) metódussal PNG formátumban mentené. A `using` deklaráció a kép felhasználása után felszabadítja azt.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && 
    textShape.TextFrame != null && 
    textShape.TextFrame.Paragraphs.Count > 1)
{
    var paragraph = textShape.TextFrame.Paragraphs[1];
    using var paragraphImage = paragraph.GetImage();

    if (paragraphImage != null)
    {
        paragraphImage.Save("paragraph.png", ImageFormat.Png);
    }
    else
    {
        Console.WriteLine("The paragraph could not be rendered.");
    }
}
else
{
    Console.WriteLine("The expected text shape or paragraph was not found.");
}
```

Az eredmény:

![A bekezdés képe](paragraph_to_image_output.png)

#### **Bekezdés renderelése táblázatcellában méretezéssel**

Használja az [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) túlterhelést, amely a `float scaleX` és `float scaleY` paramétereket fogadja, hogy beállítsa a vízszintes és függőleges méretezési tényezőket. Az alábbi példa egy táblázatot hoz létre, a bekezdést az első cellájában kétszeres alap‑szélesség és magasság mellett rendereli, és PNG képként menti el.

```csharp
using System;
using Aspose.Slides;

var scaleX = 2f;
var scaleY = 2f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var table = slide.Shapes.AddTable(50, 50, new[] { 300d }, new[] { 80d });
var paragraph = table[0, 0].TextFrame.Paragraphs[0];
paragraph.Text = "Text in a table cell";

using var paragraphImage = paragraph.GetImage(scaleX, scaleY);
if (paragraphImage != null)
{
    paragraphImage.Save("table_paragraph.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The paragraph could not be rendered.");
}
```

Az `1`‑es méretezési tényező az adott tengelyt az alap pixelméretén tartja. Például a `2` mindkét tényezőnél olyan képet eredményez, amelynek szélessége és magassága nagyjából kétszerese az alapméreteknek, így a pixel szám négyszeres lesz. A nagyobb tényezők általában élesebb szöveget adnak zoomoláshoz vagy nagy felbontású kimenethez, de a memóriafogyasztást és a fájlméretet is növelik. Az `1`‑nél kisebb tényezők kisebb képeket hoznak létre kevesebb részlettel. Az arányok megtartásához használjon egyenlő tényezőket; a különböző vízszintes és függőleges tényezők függetlenül nyújtják a kimenetet.

Az egész alakzat renderelése az [IShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/) segítségével akkor hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, szegélyét vagy egyéb vizuális kontextusát. Egy csak bekezdés‑képhez használja az [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) metódust.

## **GYIK**

**Teljesen le tudom tiltani a sorok automatikus tördelését egy szövegkeretben?**

Igen. Állítsa az [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) értékét a tördelés letiltásához, így a sorok nem törnek meg a szövegkeret szélén.

**Hogyan kaphatom meg egy adott bekezdés pontos diáposztályait?**

Használja az [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) metódust a bekezdés határoló téglalapjának lekéréséhez. Az [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) egyetlen rész határolóit adja vissza.

**Hol van szabályozva a bekezdés igazítása (balra, jobbra, középre vagy sorkizárt)?**

Az [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) egy bekezdés‑szintű beállítás, és az egész bekezdésre vonatkozik, függetlenül az egyes részek formázásától.

A különböző betűméretű részek függőleges igazításához egy soron belül lásd a [Align Fonts Within a Line](/slides/hu/net/text-formatting/#align-fonts-within-a-line) oldalt.

**Be tudok-e állítani helyesírási nyelvet a bekezdés egy részére?**

Igen. Állítsa az [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) értékét egyedi részekhez, így egy bekezdés több nyelven írt szöveget tartalmazhat.