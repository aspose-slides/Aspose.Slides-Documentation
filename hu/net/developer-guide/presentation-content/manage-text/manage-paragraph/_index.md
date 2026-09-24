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
- bullet kezelése
- bekezdés behúzás
- akasztott behúzás
- bekezdés bullet
- számozott lista
- felsoroláslista
- bekezdés tulajdonságai
- HTML importálás
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
description: "Tanulja meg, hogyan hozhat létre és formázhat bekezdéseket, szakaszokat, bullet‑eket, számozott listákat, behúzásokat, HTML‑tartalmat és bekezdésképeket az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

Az Aspose.Slides for .NET a szöveget szövegkeretek, bekezdések és szakaszok hierarchiájában jeleníti meg:

* [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) a szövegtárolót képviseli egy alakzatban, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [IParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/) egy bekezdést képvisel egy szövegkeretben, és hozzáférést biztosít a szakaszokhoz és a bekezdés szintű formázáshoz.
* [IPortion](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/) egy szövegrészt képvisel egy bekezdésen belül. Minden szakasz saját szöveggel és karakter szintű formázással rendelkezhet.

Ezáltal egy bekezdés különböző betűtípusokkal, színekkel, méretekkel és egyéb formázással ellátott szöveget tartalmazhat több szakasz használatával.

## **Bekezdések létrehozása és formázása**

### **Bekezdések létrehozása több szakaszszal**

A következő lépések egy szövegkeretet hoznak létre három bekezdéssel, mindegyik három szakaszt tartalmazva:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
2. Szerezze meg a megfelelő dia hivatkozását az indexe alapján.
3. Adjon egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diára.
4. Szerezze meg a alakzat [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) objektumát.
5. Használja az alapértelmezett bekezdést, és adjon hozzá két további [IParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/) objektumot a szövegkerethez.
6. Adjon elegendő [IPortion](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/) objektumot ahhoz, hogy minden bekezdés három szakaszt tartalmazzon. Az alapértelmezett bekezdés már egy üres szakaszt tartalmaz.
7. Állítsa be minden szakasz szövegét.
8. Alkalmazzon karakter szintű formázást az [IPortion.PortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/portionformat/) segítségével.
9. Mentse a módosított prezentációt.

Ez a C# példa végrehajtja a lépéseket:

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

## **Felsoroláspontok és számozott listák létrehozása**

### **Felsoroláspont vagy számozott lista létrehozása**

A felsoroláspontok és a számozás megkönnyítik a kapcsolódó elemek átláthatóságát. Az Aspose.Slides-ben a lista beállításait az [IBulletFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/) határozza meg.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
2. Szerezze meg a megfelelő dia hivatkozását az indexe alapján.
3. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a kiválasztott diára.
4. Szerezze meg a alakzat [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) objektumát.
5. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraph/) elemet egy szimbólum bullethez.
7. Állítsa az [IBulletFormat.Type](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/type/) értékét a [BulletType.Symbol](https://reference.aspose.com/slides/hu/net/aspose.slides/bullettype/) értékre, és adja meg a bullet karaktert.
8. Állítsa be a bekezdés szövegét, behúzását, a bullet színét és a bullet magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Hozzon létre egy második bekezdést, és állítsa az [IBulletFormat.Type](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/type/) értékét a [BulletType.Numbered](https://reference.aspose.com/slides/hu/net/aspose.slides/bullettype/) értékre.
11. Konfigurálja a számozott bullet stílusát, és adja hozzá a bekezdést a szövegkerethez.
12. Mentse a prezentációt.

Ez a C# példa egy szimbólum bullett és egy számozott bullett hoz létre:

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

### **Képes bullet használata**

A képes bullet lehetővé teszi egy saját képfájl használatát szimbólum vagy szám helyett.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
2. Szerezze meg a megfelelő dia hivatkozását az indexe alapján.
3. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet, és szerezze meg annak [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) objektumát.
4. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
5. Töltse be a bullet képet, és adja hozzá a prezentáció képgyűjteményéhez egy [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) objektumként.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraph/) elemet, és állítsa be annak szövegét.
7. Állítsa az [IBulletFormat.Type](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/type/) értékét a [BulletType.Picture](https://reference.aspose.com/slides/hu/net/aspose.slides/bullettype/) értékre.
8. Rendelje hozzá a képet az [IBulletFormat.Picture](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/picture/) segítségével, és állítsa be a bullet magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Mentse a módosított prezentációt.

Ez a C# példa egy képes bullett hoz létre:

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

Állítsa be az [IParagraphFormat.Depth](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/depth/) értékét, hogy a bekezdéseket a lista különböző szintjeire helyezze. A legfelső szint mélysége `0`.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) objektumot, és szerezze meg egy dia hivatkozását.
2. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet, és törölje az alapértelmezett bekezdést a szövegkeretből.
3. Hozzon létre négy bekezdést, és konfigurálja azok bullet szimbólumait.
4. Állítsa be a [IParagraphFormat.Depth](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/depth/) értékeit `0`, `1`, `2` és `3`-ra.
5. Adja hozzá a bekezdéseket a szövegkerethez, majd mentse a prezentációt.

Ez a C# példa egy négy szintű felsorolást hoz létre:

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

### **Számozott listaelemek kezdőértékének testreszabása**

Használja az [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/numberedbulletstartwith/) tulajdonságot a számozott bekezdés kezdeti számának beállításához.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) objektumot, és adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet egy diára.
2. Törölje az alapértelmezett bekezdést az alakzat szövegkeretéből.
3. Hozzon létre három számozott bekezdést.
4. Állítsa be az [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/numberedbulletstartwith/) értékét `2`, `3` és `7`-re a megfelelő bekezdésekhez.
5. Adja hozzá a bekezdéseket a szövegkerethez, majd mentse a prezentációt.

Ez a C# példa minden bekezdéshez egy egyéni kezdőszámot rendel:

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

## **Bekezdéselrendezés és végpont tulajdonságok vezérlése**

### **Első sor behúzásának beállítása**

Használja az [IParagraphFormat.Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) tulajdonságot a bekezdés első sorának behúzásához. Ez a tulajdonság csak az első sort mozdítja el a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdéstörzshez igazodik.

Használja az [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/marginleft/) tulajdonságot, ha a teljes bekezdést szeretné eltolni. Használja az [IParagraphFormat.Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) tulajdonságot, ha csak az első sort akarja eltolni.

Az alábbi példa több bekezdést hoz létre, és különböző [IParagraphFormat.Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) értékeket alkalmaz, hogy bemutassa, hogyan befolyásolja az első sor behúzása a bekezdéselrendezést.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példányt.
2. Szerezze meg a célzott diát.
3. Adjon egy téglalap [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diára.
4. Szerezze meg a alakzat [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) objektumát, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) értékeket számukra.
6. Adja hozzá a bekezdéseket a szövegkerethez.
7. Mentse a módosított prezentációt.

Ez a kód bemutatja, hogyan állíthat be bekezdésbehúzást:

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

### **Függőleges behúzás beállítása**

A függőleges behúzás olyan bekezdéselrendezés, ahol az első sor balra kezdődik a többi sorhoz képest. Az Aspose.Slides-ben ezt a hatást az [IParagraphFormat.Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) tulajdonsággal hozhatja létre. Állítson `Indent` értéket negatívra, hogy az első sort balra mozdítsa a bekezdéstörzshöz képest.

Gyakorlatban az [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/marginleft/) határozza meg a bekezdéstörzs bal pozícióját, míg az [IParagraphFormat.Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) határozza meg az első sor helyzetét ehhez a margóhoz képest. Függőleges behúzás létrehozásához állítson pozitív `MarginLeft` értéket, és negatív `Indent` értéket.

Ez a formázás hasznos például bibliográfiákhoz, hivatkozásokhoz, szószedet-bejegyzésekhez és más bekezdésekhez, ahol a tördelődő soroknak a bekezdéstörzs alatt kell elhelyezkedniük, nem pedig az első sor első karaktere alatt.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példányt.
2. Szerezze meg a célzott diát.
3. Adjon egy téglalap [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diára.
4. Szerezze meg a alakzat [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) objektumát, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és állítson be minden bekezdéshez pozitív [MarginLeft](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/marginleft/) értéket.
6. Állítson negatív [Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) értéket a függőleges behúzás hatásának létrehozásához.
7. Adja hozzá a bekezdéseket a szövegkerethez.
8. Mentse a módosított prezentációt.

Ez a kód bemutatja, hogyan állíthat be függőleges behúzást egy bekezdéshez:

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

![A bekezdések függőleges behúzása](hanging_indent.png)

### **Végpont bekezdésformázás beállítása**

Az [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/endparagraphportionformat/) tulajdonság szabályozza a bekezdés vége jel formázását. Az alábbi példa betűméretet és latin betűtípust állít be a második bekezdés végjelére:

1. Töltsön be egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) objektumot, és szerezze meg egy dia hivatkozását.
2. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet, és törölje az alapértelmezett bekezdést.
3. Hozzon létre két bekezdést, és adjon hozzá szövegszakaszokat.
4. Hozzon létre egy [PortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/portionformat/) objektumot a második bekezdés végjellel.
5. Állítsa be az [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseportionformat/fontheight/) és az [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseportionformat/latinfont/) értékeket.
6. Rendelje hozzá a formátumot az [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/endparagraphportionformat/) tulajdonsághoz, majd mentse a prezentációt.

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

## **Megjelenített sorok számolása**

Használja az [IParagraph.GetLinesCount](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/getlinescount/) metódust a bekezdés által elfoglalt sorok számának meghatározásához a szöveg elrendezése után, beleértve az automatikus sortörést. Ez hasznos a szöveghossz és az elrendezés ellenőrzéséhez a prezentációs sablonokban.

Egy bekezdés a [ITextFrame.Paragraphs](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/paragraphs/) gyűjtemény egyik eleme, és több megjelenített sort foglalhat el. Egy explicit sortörés a bekezdésen belül új sort kényszerít anélkül, hogy új bekezdést hozna létre. Az automatikus sortörés a rendelkezésre álló szélesség alapján hoz létre sorokat, anélkül, hogy explicit sortörő karaktereket illesztene a szövegbe. Így a bekezdések vagy sortörő karakterek számlálása nem adja meg a megjelenített sorok számát.

Az alábbi példa létrehoz egy szöveges alakzatot, megszámolja a sorait, szűkíti az alakzatot, majd egy rövidebb szövegre cseréli a tartalmat. A sortörés engedélyezett, az automatikus illeszkedés (autofit) le van tiltva, ezért a forma szélessége szabályozza a sortörést anélkül, hogy automatikusan zsugorítaná a szöveget vagy átméretezné az alakzatot. A forma méretei pontban vannak megadva. Végül a példa egy újabb bekezdést ad hozzá, és összeadja a sorok számát a szövegkeretben.

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

Ezzel a szöveggel és ezekkel a méretekkel a forma szűkítése növeli a sorok számát, míg a rövidebb szövegre cserélés csökkenti azt. A pontos számok változhatnak a betűtípus elérhetősége és helyettesítése, betűméret, margók, behúzások, sortörés és autofit beállítások függvényében. Használja a célkörnyezethez szánt betűtípusokat és elrendezési beállításokat a sablon ellenőrzésekor.

A sorok száma önmagában nem határozza meg, hogy a szöveg túlcsordul-e a tárolóból. A rendelkezésre álló magasság, sormagasságok, bekezdés- és sorköz, valamint az autofit viselkedés is számít; még egyetlen sor is meghaladhatja a rendelkezésre álló szélességet, ha a sortörés le van tiltva.

## **Bekezdés tartalmának importálása és exportálása**

### **HTML szöveg importálása bekezdésekbe**

Használja a [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraphcollection/addfromhtml/) metódust a HTML jelölés bekezdésekké és szakaszokká konvertálásához egy szövegkeretben.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) példányt.
2. Szerezzen egy diát, és adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet.
3. Szerezze meg a forma [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) objektumát, és törölje az alapértelmezett bekezdést.
4. Olvassa be a forrás HTML fájlt.
5. Adja át a HTML szöveget a [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraphcollection/addfromhtml/) metódusnak.
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

### **Paragraph szöveg exportálása HTML-be**

Használja a [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraphcollection/exporttohtml/) metódust a kiválasztott bekezdéstaromány HTML-ként történő exportálásához.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) példányt, és töltse be a kívánt prezentációt.
2. Szerezze meg a diát, és keresse meg a szöveget tartalmazó [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet.
3. Szerezze meg a forma [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) objektumát.
4. Hívja meg a [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraphcollection/exporttohtml/) metódust a kezdő bekezdés indexével és az exportálandó bekezdések számával.
5. Írja a visszakapott HTML szöveget egy fájlba.

Ez a C# példa exportálja az összes bekezdést az első szöveges alakzatról:

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

### **Bekezdés megjelenítése képként**

Az [IParagraph.GetImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/getimage/) közvetlenül megjeleníti az egyes bekezdéseket, és egy [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) objektumot ad vissza. A eredményt fájlba vagy adatfolamba mentheti az [IImage.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/save/) metódussal. Nem szükséges a környező alakzatot renderelni vagy bitmapet manuálisan vágni.

Az [IParagraph.GetImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/getimage/) `null` értéket adhat vissza, ha a bekezdés nem található a szülőgyűjteményben, nincs érvényes renderelési határa, vagy nem renderelhető. Ellenőrizze az eredményt a mentés előtt, és a használat után szabadítsa fel a visszakapott képet.

#### **Bekezdés renderelése alapértelmezett méretben**

Tegyük fel, hogy van egy sample.pptx nevű prezentációs fájlunk, amely egy diát tartalmaz, ahol az első alakzat egy három bekezdést tartalmazó szövegdoboz.

![A három bekezdést tartalmazó szövegdoboz](paragraph_to_image_input.png)

Az alábbi példa a második bekezdést rendereli egy szabályos szöveges alakzatban alapértelmezett méretben, és PNG formátumban menti a visszakapott képet. A `using` deklaráció biztosítja, hogy a kép helyesen felszabaduljon.

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

#### **Bekezdés renderelése táblázat cellájában méretezéssel**

Használja az [IParagraph.GetImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/getimage/) túlterhelését, amely `float scaleX` és `float scaleY` paramétereket fogad a vízszintes és függőleges méretezési faktort beállítva. Az alábbi példa egy táblázatot hoz létre, a bekezdést az első cellájában kétszeres alapméretű szélességgel és magassággal rendereli, majd PNG képként menti az eredményt.

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

Az `1` méretarány megtartja az adott tengely alap pixelméretét. Például a `2` mindkét tényezőnél olyan képet eredményez, amelynek szélessége és magassága körülbelül kétszerese az alapméreteknek, így négyszer annyi pixel keletkezik. A nagyobb tényezők általában élesebb szöveget eredményeznek nagyításhoz vagy nagy felbontású kimenethez, de növelik a memóriahasználatot és a fájlméretet. Az `1` alatti tényezők kisebb, kevesebb részletet tartalmazó képeket hoznak létre. Használjon egyenlő tényezőket a bekezdés arányának megőrzéséhez; a különböző vízszintes és függőleges tényezők önállóan nyújtják a kimenetet.

Egy egész alakzat renderelése az [IShape.GetImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/getimage/) metódussal továbbra is hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, szegélyét vagy egyéb vizuális kontextusát. Egy kizárólag bekezdés képe esetén használja az [IParagraph.GetImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/getimage/) metódust.

## **GYIK**

**Teljesen letilthatom a sortörést egy szövegkereten belül?**

Igen. Állítsa az [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/wraptext/) értékét a sortörés letiltásához, így a sorok nem törnek meg a szövegkeret szélén.

**Hogyan kaphatom meg egy adott bekezdés pontos helyi méreteit?**

Használja az [IParagraph.GetRect](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/getrect/) metódust a bekezdés körülhatároló téglalap lekéréséhez. Az [IPortion.GetRect](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/getrect/) egy adott szakasz határait adja vissza.

**Hol van szabályozva a bekezdés igazítása (balra, jobbra, középre vagy sorkizárt)?**

Az [IParagraphFormat.Alignment](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/alignment/) bekezdés szintű beállítás, amely az egész bekezdésre vonatkozik, függetlenül az egyes szakaszok formázásától.

**Beállíthatok lektorálási nyelvet a bekezdés egy részére?**

Igen. Állítsa az [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseportionformat/languageid/) értékét egyes szakaszoknál, így egy bekezdés több nyelvű szöveget is tartalmazhat.