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
- golyó kezelése
- bekezdés behúzás
- függő behúzás
- bekezdés golyó
- számozott lista
- golyós lista
- bekezdés tulajdonságok
- HTML importálása
- szöveg HTML-re
- bekezdés HTML-re
- bekezdés képre
- szöveg képre
- bekezdés exportálása
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és formázhat bekezdéseket, részeket, golyókat, számozott listákat, behúzásokat, HTML tartalmat és bekezdés képeket az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

Az Aspose.Slides for .NET a szöveget szövegkeretek, bekezdések és részek (portion) hierarchiájaként képviseli:

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) a szövegkonténer egy alakzatban, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) egy bekezdést képvisel egy szövegkeretben, és hozzáférést biztosít a részeihez és a bekezdésszintű formázáshoz.
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) egy szövegrészt képvisel egy bekezdésben. Minden résznek saját szövege és karakter szintű formázása lehet.

Ezért egy bekezdés különböző betűtípusokkal, színekkel, méretekkel és egyéb formázásokkal tartalmazhat szöveget, ha több részt (portion) használ.

## **Bekezdések létrehozása és formázása**

### **Bekezdések létrehozása több részzel**

Az alábbi lépések egy szövegkeretet hoznak létre három bekezdéssel, melyek mindegyike három részt tartalmaz:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) osztályból.
2. Hozzáférés a megfelelő dia hivatkozásához az indexén keresztül.
3. Adj hozzá egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) elemet a diára.
4. Hozzáférés az alakzat [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).
5. Használja az alapértelmezett bekezdést, és adjon még két [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) objektumot a szövegkerethez.
6. Adj elegendő [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) objektumot minden bekezdéshez, hogy három részt tartalmazzanak. Az alapértelmezett bekezdés már tartalmaz egy üres részt.
7. Állítsa be minden rész szövegét.
8. Alkalmazzon karakter szintű formázást a [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/) használatával.
9. Mentse a módosított prezentációt.

Ez a C# példa megvalósítja a lépéseket:

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

## **Golyó- és számozott listák létrehozása**

### **Golyó- vagy számozott lista létrehozása**

A golyók és a számozás könnyebbé teszik a kapcsolódó elemek áttekintését. Az Aspose.Slides-ben a lista beállításait a [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) definiálja.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) osztályból.
2. Hozzáférés a megfelelő dia hivatkozásához az indexén keresztül.
3. Adj egy [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) elemet a kiválasztott diára.
4. Hozzáférés az alakzat [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).
5. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) elemet egy szimbólum golyóhoz.
7. Állítsa a [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) értékét [BulletType.Symbol](https://reference.aspose.com/slides/net/aspose.slides/bullettype/)-ra, és adja meg a golyó karaktert.
8. Állítsa be a bekezdés szövegét, behúzását, golyó színét és golyó magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Hozzon létre egy második bekezdést, és állítsa a [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) értékét [BulletType.Numbered](https://reference.aspose.com/slides/net/aspose.slides/bullettype/)-ra.
11. Konfigurálja a számozott golyó stílusát, és adja hozzá a bekezdést a szövegkerethez.
12. Mentse a prezentációt.

Ez a C# példa szimbólum golyót és számozott golyót hoz létre:

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

### **Képgolyók használata**

A képgolyók lehetővé teszik, hogy egy egyéni képet használjon szimbólum vagy szám helyett.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) osztályból.
2. Hozzáférés a megfelelő dia hivatkozásához az indexén keresztül.
3. Adj egy [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) elemet, és hozzáférés annak [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).
4. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
5. Töltse be a golyó képet, és adja hozzá a prezentáció képgyűjteményéhez [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) formájában.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) elemet, és állítsa be a szövegét.
7. Állítsa a [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) értékét [BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/)-ra.
8. Rendelje hozzá a képet a [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/) segítségével, és állítsa be a golyó magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Mentse a módosított prezentációt.

Ez a C# példa képgolyót hoz létre:

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

Állítsa be a [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) értékét, hogy a bekezdéseket a lista különböző szintjeire helyezze. A legfelső szint mélysége `0`.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) elemet, és érje el egy diát.
2. Adj egy [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) elemet, és törölje az alapértelmezett bekezdést a szövegkeretéből.
3. Hozzon létre négy bekezdést, és állítsa be golyó szimbólumaikat.
4. Állítsa be a [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) értékeket `0`, `1`, `2` és `3`-ra.
5. Adja hozzá a bekezdéseket a szövegkerethez, és mentse a prezentációt.

Ez a C# példa négy szintű golyós listát hoz létre:

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

### **Számozott listaelemek elindítása egyéni értékekkel**

Használja a [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) beállítást, hogy az egyes számozott bekezdések kezdeti számát meghatározza.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) elemet, és adj egy [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) elemet egy diára.
2. Törölje az alapértelmezett bekezdést az alakzat szövegkeretéből.
3. Hozzon létre három számozott bekezdést.
4. Állítsa a [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) értékét `2`, `3` és `7`-re a megfelelő bekezdésekhez.
5. Adja hozzá a bekezdéseket a szövegkerethez, és mentse a prezentációt.

Ez a C# példa egyedi kezdőszámot ad minden bekezdéshez:

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

## **Bekezdéselrendezés és végjellemzők vezérlése**

### **Első sor behúzásának beállítása**

Használja az [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) tulajdonságot az első sor behúzásának vezérlésére. Ez a tulajdonság csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a maradék sorok a bekezdés törzséhez igazodnak.

Használja az [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) tulajdonságot, ha az egész bekezdést szeretné eltolni. Az [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) csak az első sor eltolására szolgál.

Az alábbi példa több bekezdést hoz létre, és különböző [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) értékeket alkalmaz, hogy bemutassa, hogyan befolyásolja a bekezdéselrendezést az első sor behúzása.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) osztályból.
2. Hozzáférés a cél diához.
3. Adj egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) elemet a diára.
4. Hozzáférés az alakzat [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) eleméhez, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) értékeket.
6. Adja hozzá a bekezdéseket a szövegkerethez.
7. Mentse a módosított prezentációt.

Ez a kód megmutatja, hogyan állíthat be bekezdésbehúzást:

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

![A bekezdések első sorának behúzása](first_line_indent.png)

### **Függő behúzás beállítása**

A függő behúzás egy olyan bekezdéselrendezés, amelyben az első sor balra indul a többi sorhoz képest. Az Aspose.Slides-ben ezt az effektust az [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) tulajdonság segítségével hozhatja létre. A `Indent` negatív értékre állítása balra mozgatja az első sort a bekezdés törzséhez képest.

Gyakorlatban az [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) definiálja a bekezdés törzsének bal pozícióját, míg az [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) határozza meg az első sor helyzetét ehhez a margóhoz képest. Függő behúzás létrehozásához állítson be pozitív `MarginLeft` értéket és negatív `Indent` értéket.

Ez a formázás hasznos bibliográfiák, hivatkozások, szószedetek és más bekezdések esetén, ahol a sortörésnek a bekezdés törzsének alá kell igazodnia, nem pedig az első karakter alá.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) osztályból.
2. Hozzáférés a cél diához.
3. Adj egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) elemet a diára.
4. Hozzáférés az alakzat [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) eleméhez, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és állítson be minden bekezdéshez pozitív [MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) értéket.
6. Állítson be negatív [Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) értéket a függő behúzás hatás eléréséhez.
7. Adja hozzá a bekezdéseket a szövegkerethez.
8. Mentse a módosított prezentációt.

Ez a kód megmutatja, hogyan állíthat be függő behúzást egy bekezdéshez:

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

![A bekezdések függő behúzása](hanging_indent.png)

### **Bekezdés végjellemzőinek beállítása**

Az [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) tulajdonság vezérli a bekezdés végjellel (end mark) kapcsolatos formázást. Az alábbi példa egy betűméretet és latin betűtípust rendel a második bekezdés végjeléhez:

1. Töltsön be egy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) elemet, és érje el egy diát.
2. Adj egy [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) elemet, és törölje annak alapértelmezett bekezdését.
3. Hozzon létre két bekezdést, és adjon szövegrészeket hozzájuk.
4. Hozzon létre egy [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) objektumot a második bekezdés végjeléhez.
5. Állítsa be a [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) és a [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/) értékeket.
6. Rendelje hozzá a formátumot az [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) tulajdonsághoz, majd mentse a prezentációt.

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

Az automatikus sortörésre és a sorvégi írásjelekre vonatkozó szabályok megszerzéséhez lásd a [Control Line Breaking](/slides/hu/net/text-formatting/#control-line-breaking) és a [Control Hanging Punctuation](/slides/hu/net/text-formatting/#control-hanging-punctuation) cikkeket.

Használja az [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) metódust a bekezdés által elfoglalt sorok számának meghatározásához a szöveg elrendezése után, beleértve az automatikus sortörést. Ez hasznos a szöveg hosszának és elrendezésének ellenőrzésénél prezentációs sablonokban.

Egy bekezdés egy elem a [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/) gyűjteményben, és több megjelenített sort is elfoglalhat. Egy explicit sortörés a bekezdésen belül új sort kényszerít anélkül, hogy új bekezdést hozna létre. Az automatikus sortörés a rendelkezésre álló szélesség alapján hoz létre sorokat anélkül, hogy explicit sortöréseket szúrna be a szövegbe. Ezért a bekezdések vagy sortörés karakterek számlálása nem adja meg a renderelt sorok számát.

Az alábbi példa egy szövegalakzatot hoz létre, megszámolja a sorokat, szűkíti az alakzatot, majd egy rövidebb szöveggel helyettesíti azt. A sortörés engedélyezett, az automatikus illesztés le van tiltva, így az alakzat szélessége szabályozza a sortörést anélkül, hogy automatikusan zsugorítaná a szöveget vagy átméretezné az alakzatot. Az alakzat méretei pontban vannak megadva. Végül a példa egy újabb bekezdést ad hozzá, és összeadja a sorok számát a szövegkeretben.

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

Ezzel a szöveggel és ezekkel a méretekkel, az alakzat szűkítése növeli a sorok számát, míg a szöveg rövid stringgel való helyettesítése csökkenti azt. A pontos számok változhatnak a betűkészlet elérhetőségétől és helyettesítésétől, a betűmérettől, a margóktól, a behúzástól, a sortöréstől és az automatikus illesztés beállításaitól. A sablon ellenőrzésekor használja a cél környezethez szánt betűtípusokat és elrendezési beállításokat.

A sorok számának önmagában nem határozza meg, hogy a szöveg túlcsordul-e a tárolójában. A rendelkezésre álló magasság, a sormagasságok, a bekezdés- és sortávolság, valamint az automatikus illesztés viselkedése is számít; még egyetlen sor is meghaladhatja a rendelkezésre álló szélességet, ha a sortörés le van tiltva.

## **Bekezdés tartalmának importálása és exportálása**

### **HTML szöveg importálása bekezdésekbe**

Használja a [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) metódust a HTML jelölők bekezdésekké és részekké (portions) konvertálásához egy szövegkeretben.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) osztályból.
2. Hozzáférés egy diához, és adj egy [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) elemet.
3. Hozzáférés az alakzat [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) eleméhez, és törölje az alapértelmezett bekezdést.
4. Olvassa be a forrás HTML fájlt.
5. Adja át a HTML karakterláncot a [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) metódusnak.
6. Mentse a módosított prezentációt.

Ez a C# példa HTML-t importál egy szövegkeretbe:

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

### **Bekezdés szövegének exportálása HTML-re**

Használja a [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) metódust a kiválasztott bekezdés-tartomány HTML-ként történő exportálásához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) osztályból, és töltse be a kívánt prezentációt.
2. Hozzáférés a diához, és keresse meg a szöveget tartalmazó [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) elemet.
3. Hozzáférés az alakzat [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).
4. Hívja meg a [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) metódust a kezdő bekezdés indexével és az exportálandó bekezdések számával.
5. Írja a visszakapott HTML karakterláncot egy fájlba.

Ez a C# példa az első szövegalkotó összes bekezdését exportálja:

```csharp
using System;
using System.IO;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("ExportingHTMLText.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && textShape.TextFrame != null)
{
    var paragraphs = textShape.TextFrame.Paragraphs;
    var html = paragraphs.ExportToHtml(0, paragraphs.Count, null);
    using var writer = new StreamWriter("paragraphs.html", false, Encoding.UTF8);
    writer.Write(html);
}
else
{
    Console.WriteLine("The first shape is not a text shape.");
}
```

### **Bekezdés renderelése képként**

Az [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) egyéni bekezdést renderel közvetlenül, és egy [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) objektumot ad vissza. Mentse az eredményt egy fájlba vagy adatfolyamba az [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) segítségével. Nem szükséges a környező alakzatot renderelni vagy a bitmapet manuálisan vágni.

Az [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) `null` értéket adhat vissza, ha a bekezdés nem található meg a szülőgyűjteményében, nincs érvényes renderelési határa, vagy nem renderelhető. Ellenőrizze az eredményt a mentés előtt, és használat után szabadítsa fel a visszakapott képet.

#### **Bekezdés renderelése alapértelmezett méretezésben**

Tegyük fel, hogy van egy *sample.pptx* nevű prezentációfájl egy diával, ahol az első alakzat egy három bekezdést tartalmazó szövegdoboz.

![A szövegdoboz három bekezdéssel](paragraph_to_image_input.png)

Az alábbi példa a második bekezdést egy szabályos szövegalkotásban alapértelmezett méretezésben rendereli, és a visszakapott képet PNG formátumban menti. A `using` deklaráció biztosítja, hogy a kép helyesen legyen felszabadítva.

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

Használja az [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) olyan túlterhelését, amely a `float scaleX` és `float scaleY` paramétereket fogadja, a vízszintes és függőleges méretezési tényezők beállításához. Az alábbi példa egy táblázatot hoz létre, a bekezdést az első cellájában a kétszeres alap szélességgel és magassággal rendereli, majd PNG képként menti az eredményt.

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

Az `1` méretarány megtartja az adott tengely alap pixelméretét. Például a `2` mindkét tényezőnél olyan képet eredményez, amelynek szélessége és magassága nagyjából a dupla alapméret, ez négyzetes pixelarányú növekedést jelent. A nagyobb tényezők általában élesebb szöveget eredményeznek nagyítás vagy nagy felbontású kimenet esetén, de növelik a memóriahasználatot és a fájlméretet. Az `1` alatti tényezők kisebb képet hoznak létre részletveszteséggel. Használjon egyenlő tényezőket a bekezdés arányának megtartásához; a különböző vízszintes és függőleges tényezők függetlenül nyújtják a kimenetet.

Egy egész alakzat renderelése az [IShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/) metódussal továbbra is hasznos, ha a kimenetnek a alakzat kitöltését, szegélyét vagy egyéb vizuális kontextusát is tartalmaznia kell. Csak a bekezdésre vonatkozó képnél használja az [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) metódust.

## **GYIK**

**Teljesen letilthatom a sorok megtörését egy szövegkeretben?**

Igen. Állítsa a [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) értékét a sortörés letiltásához, így a sorok nem törnek meg a szövegkeret szélén.

**Hogyan szerezhetem meg egy adott bekezdés pontos diára vonatkozó határait?**

Használja az [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) metódust a bekezdés határoló téglalapjának lekérdezéséhez. Az [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) egyedi rész határait adja vissza.

**Hol vezérlik a bekezdés igazítását (balra, jobbra, középre vagy sorkizárásra)?**

Az [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) bekezdés szintű beállítás, amely az egész bekezdésre vonatkozik, függetlenül az egyes részek formázásától.

A különböző betűméretű részek függőleges igazításához egy soron belül lásd: [Align Fonts Within a Line](/slides/hu/net/text-formatting/#align-fonts-within-a-line).

**Beállíthatom a nyelvellenőrzés nyelvét a bekezdés egy részére?**

Igen. Állítsa be az [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) értékét egyes részeknél, így egy bekezdés több nyelven is tartalmazhat szöveget.