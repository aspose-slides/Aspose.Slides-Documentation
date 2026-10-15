---
title: PowerPoint szövegbekezdések kezelése .NET-ben
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
- felsorolás kezelése
- bekezdés behúzás
- függő behúzás
- bekezdés felsorolás
- számozott lista
- felsorolás lista
- bekezdés tulajdonságok
- HTML importálása
- szöveg HTML-re
- bekezdés HTML-re
- bekezdés képként
- szöveg képként
- bekezdés exportálása
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és formázhat bekezdéseket, részeket, felsorolásjeleket, számozott listákat, behúzásokat, HTML tartalmat és bekezdésképeket az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

Az Aspose.Slides for .NET a szöveget szövegkeretek, bekezdések és részek hierarchiájában ábrázolja:

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) a szövegkonténert képviseli egy alakzatban, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) egy bekezdést képvisel egy szövegkeretben, és hozzáférést biztosít a részeihez és a bekezdés-szintű formázáshoz.
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) egy szövegrészt (run) képvisel egy bekezdésen belül. Minden rész saját szöveggel és karakter-szintű formázással rendelkezhet.

Egy bekezdés tehát több részt használva tartalmazhat különböző betűtípusú, színű, méretű és egyéb formázású szöveget.

## **Bekezdések létrehozása és formázása**

Készíts bekezdéseket egy alakzat szövegkeretében, és használj részeket az egyes szövegrészek formázásához. Ez a szakasz bemutatja, hogyan lehet több részt kombinálni minden bekezdésben, és különböző színeket, betűméreteket és stílusokat alkalmazni.

### **Bekezdések létrehozása több részzel**

A következő C# példa három bekezdést hoz létre, mindegyik három szövegrészt tartalmazva a [IParagraph.Portions](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/portions/) gyűjteményében. Újra felhasználja az alapértelmezett bekezdést és annak üres részét, majd hozzáadja a maradék bekezdéseket és részeket. A formázás a [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/) segítségével történik: az első rész minden bekezdésben piros, félkövér és 15 pont; a második kék, dőlt és 18 pont. A harmadik rész az alapértelmezett formázást megtartja:

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

## **Felsorolás- és számozott listák létrehozása**

Rendezd a bekezdés szövegét listákba szimbólumokkal, számokkal vagy egyéni képekkel. Ebben a szakaszban a felsorolás formázását, a több szintű listákat és az egyéni kezdőszámokat mutatjuk be.

### **Felsorolás vagy számozott lista létrehozása**

A felsorolások és a számozás megkönnyítik a kapcsolódó elemek áttekintését. Az Aspose.Slides-ben a lista beállításait a [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) segítségével definiáljuk.

Ez a C# példa egy szimbólumú felsorolást és egy számozott elemet ad hozzá ugyanahhoz a szövegkerethez. A [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) választja ki a felsorolás típusát, míg a [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) adja meg a szimbólumot és a [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) a számozás stílusát. Mindkét elem fekete felsorolást használ, 100 százalékos magassággal és 25 pont bekezdésbehúzással:

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

### **Képes felsorolások használata**

A képes felsorolások lehetővé teszik, hogy egy egyéni képet használj szimbólum vagy szám helyett.

Ez a C# példa egy képet ad a bemutató képgyűjteményéhez [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) formájában, és azt használja bekezdés felsorolásként. Beállítja a [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) értékét képes felsorolásra, és a képet a [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/) segítségével rendeli hozzá. A [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) 100 százalékra van állítva, hogy a felsorolás mérete a bekezdés szövegéhez viszonyítva legyen:

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

Állítsd be a [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) értékét, hogy a bekezdéseket a lista különböző szintjeire helyezd. A legfelső szint mélysége `0`.

Ez a C# példa a [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) értékeket 0‑tól 3‑ig rendeli négy bekezdéshez, egy szövegkeretben hierarchiát létrehozva. Minden bekezdés szimbólum felsorolást használ, a [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) váltakozva kör alakú és kötőjelként jelenik meg a szomszédos szintek megkülönböztetésére:

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

### **Számozott listaelemek kezdőértékének beállítása egyéni értékekkel**

A [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) segítségével állítható be a számozott bekezdés kezdeti száma.

Ez a C# példa a [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) értékét számozásra állítja három bekezdésnél, és a [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) értékeit 2, 3 és 7‑re állítja. A kezdőérték minden bekezdésnél külön van konfigurálva, lehetővé téve a számok átugrását:

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

## **Bekezdéselrendezés és befejezési tulajdonságok vezérlése**

Állítsd be a bekezdés margóit és behúzásait, hogy a első sor és a sortöréses sorok pozícióját szabályozd. A bekezdés befejezési jelét is formázhatod külön a látható szövegrészekkel.

### **Első sor behúzásának beállítása**

Használd a [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) tulajdonságot az első sor behúzásának szabályozásához. Ez a tulajdonság csak az első sort mozdítja el a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés törzséhez igazodik.

Használd a [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) értéket, ha az egész bekezdést szeretnéd elmozdítani. Használd a [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) értéket, ha csak az első sort szeretnéd elmozdítani.

A következő példa három bekezdést ugyanazzal a [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) 20 pont értékkel és a [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) 0, 20 illetve 40 pont értékekkel lát el. Az első sorok fokozatosan nagyobb eltolással kezdődnek, míg a sortöréses sorok ugyanazt a bal margót megtartják:

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

A függő behúzás egy olyan bekezdéselrendezés, ahol az első sor a többi sor bal oldalán kezdődik. Az Aspose.Slides-ben ezt a hatást a [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) tulajdonsággal hozhatod létre. Az `Indent` negatív értéke balra mozgatja az első sort a bekezdés törzséhez képest.

Gyakorlatban a [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) határozza meg a bekezdés törzsének bal pozícióját, a [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) pedig az első sor helyzetét ehhez a margóhoz képest. Függő behúzás létrehozásához állíts be pozitív `MarginLeft` értéket és negatív `Indent` értéket.

Ez a formázás hasznos bibliográfiákhoz, hivatkozásokhoz, szószedet-bejegyzésekhez és más bekezdésekhez, ahol a sortöréses soroknak a bekezdés törzsének alá kell igazulniuk, nem pedig az első sor első karakteréhez.

A következő C# példa a [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) 40 és 60 pont értékeket párosítja a [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) -20 és -30 pont értékekkel. Minden bekezdésben az első sor a sortöréses sorok bal oldalán kezdődik; a második bekezdés mélyebb függő behúzást kap:

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

![A függő behúzás a bekezdésekben](hanging_indent.png)

### **A bekezdés vége futtatási tulajdonságainak beállítása**

Az [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) tulajdonság vezérli a bekezdés befejező jelének formázását. A következő példa egy [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) létrehozását mutatja, amelynek [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) 48 pont, a [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/) Times New Roman. Ezt a formátumot a második bekezdés befejező jelére rendeli, a látható szövegrészeket változatlanul hagyva:

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

Lásd a [Sor tördelésének vezérlése](/slides/hu/net/text-formatting/#control-line-breaking) és a [Függő írásjelek vezérlése](/slides/hu/net/text-formatting/#control-hanging-punctuation) szakaszokat.

Használd a [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) metódust a bekezdés által elfoglalt sorok számának meghatározására a szöveg elrendezése után, beleértve az automatikus sortörést. Ez hasznos a szöveg hossza és elrendezése ellenőrzésénél prezentációs sablonokban.

Egy bekezdés egy eleme az [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/) gyűjteménynek, és több megjelenített sort is elfoglalhat. Egy explicitt sortörés egy bekezdésen belül új sorot hoz létre anélkül, hogy új bekezdést hozna létre. Az automatikus sortörés a rendelkezésre álló szélesség alapján hoz létre sorokat anélkül, hogy explicitt sortörés karaktereket szúrna a szövegbe. A bekezdések vagy sortörés karakterek számlálása ezért nem adja meg a megjelenített sorok számát.

A következő példa létrehoz egy szöveges alakzatot, megszámolja a sorait, szűkíti az alakzatot, majd a szöveget egy rövidebb karakterláncra cseréli. A példa engedélyezi az [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) beállítást, és letiltja az [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) opciót, hogy az alakzat szélessége szabályozza a sortörést anélkül, hogy automatikusan kicsinyítené a szöveget vagy átméretezné az alakzatot. Minden mérés a [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) használatával történik. Az alakzat méretei pontban vannak. Végül a példa egy újabb bekezdést ad hozzá és összeadja a sorok számát a szövegkeretben.

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

Ezzel a szöveggel és ezekkel a méretekkel az alakzat szűkítése növeli a sorok számát, míg a szöveg rövid karakterláncra cserélése csökkenti azt. A pontos számok a betűtípus elérhetőségétől és helyettesítésétől, a betűmérettől, a margóktól, a behúzástól, a sortöréstől és az automatikus illesztéstől függenek. A célkörnyezethez szánt betűtípusokat és elrendezési beállításokat használd a sablon ellenőrzésekor.

A sorok száma önmagában nem határozza meg, hogy a szöveg túllépi-e a tárolót. A rendelkezésre álló magasság, sormagasságok, bekezdés- és sortávolság, valamint az automatikus illesztés is számít; még egyetlen sor is túllépheti a rendelkezésre álló szélességet, ha a sortörés ki van kapcsolva.

## **Bekezdés tartalmának importálása és exportálása**

Használd a HTML-t szöveg prezentációba való beillesztéshez vagy a meglévő bekezdések exportálásához, hogy azok kívülről is felhasználhatók legyenek. Ez a szakasz bemutatja, hogyan lehet egyedi bekezdéseket képként megjeleníteni, beleértve a táblázatcellák bekezdéseit is.

### **HTML szöveg importálása bekezdésekbe**

Használd a [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) metódust a HTML jelölőnyelv bekezdésekké és részekké alakításához egy szövegkeretben.

Ez a C# példa egy fájlból olvas HTML-t, és a jelölőt átadja a [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) metódusnak. Törli a szövegkeret alapértelmezett bekezdését, így a keret csak a importált tartalmat tartalmazza. A téglalap alakzat 10 pont margót hagy a dia minden oldalán:

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

### **Bekezdés szövegének exportálása HTML-be**

Használd a [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) metódust a kiválasztott bekezdésszakasz HTML-be exportálásához. Ha a prezentáció szövegét weboldalon szeretnéd újra felhasználni, lehet, hogy meg akarod őrizni a helyi hangsúlyt anélkül, hogy a prezentáció betűtípusa, mérete vagy szövegdoboz stílusa átkerülne. Állítsd a [TextToHtmlConversionOptions.TextInheritanceLimit](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/textinheritancelimit/) értékét, hogy szabályozd, mennyire követi a exportáló a formázási öröklődést.

Töltsd le a [példa prezentációt](text-inheritance.pptx) és helyezd az alkalmazás munkakönyvtárába. Első diája egy szöveg alakzatot tartalmaz a „Inherited text; explicit red 18pt” szöveggel. A bemenet szándékosan több formázási szintet használ:

- A prezentáció alapértelmezett szövegstílusa a Calibri betűtípust és 28 pt méretet biztosít.
- A szövegkeret első szintű szövegstílusa kék szöveget és dőlt betűt biztosít.
- A bekezdés kifejezetten félkövér szöveget állít be.
- A második rész, "explicit red 18pt", kifejezetten piros szöveget és 18 pt méretet állít be.

A következő teljes példa háromszor exportálja ugyanazokat a bekezdéseket. A [TextToHtmlConversionOptions](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/) példányt átadja az exportáló metódusnak, és minden eredményt külön UTF‑8 HTML fájlba ír:

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

A generált HTML a következő CSS-t tartalmazza az első részhez, "Inherited text; ". A táblázat felsorolja a releváns deklarációkat; a többi generált tulajdonság ki van hagyva az átláthatóság kedvéért.

| Kimenet | Az első részhez releváns CSS | Megjelenés |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Kék, félkövér, dőlt szöveg 28 pt-en Calibriban, ha a betűtípus elérhető. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Kék, félkövér, dőlt szöveg; a környező oldal vagy böngésző biztosítja a betűcsaládot és méretet. |
| `ParagraphOnly.html` | `font-weight:bold` | Félkövér szöveg; a környező oldal vagy böngésző biztosítja a betűcsaládot, méretet, színt és dőlt stílust. |

A második rész megtartja a `color:#ff0000`, `font-size:18pt`, és `font-weight:bold` beállításokat minden három kimenetben. Emellett megtartja a dőlt formátumot az `All` és `TextBox` esetén, de nem a `ParagraphOnly` esetén. Így az öröklődés korlátozása nem távolítja el a bekezdéshez vagy részhez kifejezetten hozzárendelt formázást.

Nyisd meg a fájlokat ugyanabban a böngészőben, hogy összehasonlítsd őket. A két korlátozott mód esetén a kihagyott CSS tulajdonságokat a céloldal stílusai vagy a böngésző alapértelmezései oldják fel, ezért a végső megjelenés attól függ, ahol a HTML-t használják.

### **Bekezdés megjelenítése képként**

Az [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) egy egyedi bekezdést jelenít meg közvetlenül, és egy [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) objektumot ad vissza. Az eredményt fájlba vagy adatfolyamba mentheted az [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) segítségével. Nem szükséges a tartalmazó alakzatot megjeleníteni vagy bitmapet manuálisan kivágni.

Az [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) `null` értéket adhat vissza, ha a bekezdés nem található a szülőgyűjteményben, nincs érvényes renderelési határa, vagy nem lehet renderelni. Ellenőrizd az eredményt mentés előtt, és a visszaadott képet használt után szabadítsd fel.

#### **Bekezdés megjelenítése az alapértelmezett méretezésben**

A példa egy egydiadiós prezentációt használ, ahol az első alakzat egy három bekezdést tartalmazó szövegdoboz.

![A szövegdoboz három bekezdéssel](paragraph_to_image_input.png)

A következő példa a második bekezdést (index 1) választja ki, és a [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) metódust hívja skálaparaméterek nélkül. Ellenőrzi, hogy az alakzat tartalmazza-e a szükséges bekezdést, és hogy a renderelés képet ad-e vissza, mielőtt az [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) segítségével PNG formátumban mentené. A `using` deklaráció elpusztítja a képet használat után.

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

#### **Bekezdés megjelenítése táblázatcellában méretezéssel**

Használd az [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) túlterhelést, amely `float scaleX` és `float scaleY` paramétereket fogad a vízszintes és függőleges méretezési tényezők beállításához. A következő példa létrehoz egy táblázatot, a bekezdést az első cellájában kétszeres alap szélesség és magasság mellett rendereli, és PNG képként menti az eredményt.

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

Az `1` méretarány az adott tengelyt az alap pixelméretén tartja. Például a `2` mindkét tényező esetén olyan képet eredményez, amelynek szélessége és magassága megközelítőleg duplája az alap méreteknek, így a pixelek négyszeresek. A nagyobb tényezők általában élesebb szöveget eredményeznek nagyításhoz vagy nagy felbontású kimenethez, de növelik a memóriahasználatot és a fájlméretet. Az `1` alatti tényezők kisebb képeket hoznak kevesebb részlettel. Használj egyenlő tényezőket a bekezdés arányának megőrzéséhez; a különböző vízszintes és függőleges tényezők önállóan nyújtják a képet.

Egy teljes alakzat megjelenítése az [IShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/) segítségével továbbra is hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, szegélyét vagy egyéb vizuális kontextusát. Egy csak bekezdéses képhez használd az [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) metódust.

## **GYIK**

**Teljesen le lehet tiltani a sortörést egy szövegkereten belül?**

Igen. Állítsd a [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) értékét úgy, hogy letiltsa a sortörést, így a sorok nem törnek meg a szövegkeret szélén.

**Hogyan kaphatom meg egy adott bekezdés pontos dián lévő határait?**

Használd a [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) metódust a bekezdés határoló téglalapjának lekérdezéséhez. Az [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) egyetlen rész határait adja meg.

**Hol van szabályozva a bekezdés igazítása (bal, jobb, közép vagy sorkizárt)?**

Az [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) egy bekezdés‑szintű beállítás, amely az egész bekezdésre érvényes, függetlenül az egyes részek formázásától. A különböző betűméretű részek függőleges igazításához egy soron belül, lásd a [Betűk függőleges igazítása egy sorban](/slides/hu/net/text-formatting/#align-fonts-within-a-line).

**Beállítható‑e a helyesírási nyelv a bekezdés egy részéhez?**

Igen. Állítsd be az [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) értékét az egyes részeknél, így egy bekezdés több nyelven írt szöveget is tartalmazhat.