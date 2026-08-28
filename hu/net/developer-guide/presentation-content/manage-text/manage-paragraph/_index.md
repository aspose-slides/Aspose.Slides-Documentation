---
title: PowerPoint szöveg bekezdéseinek kezelése .NET-ben
linktitle: Bekezdések kezelése
type: docs
weight: 40
url: /hu/net/manage-paragraph/
aliases:
  - /net/bekezdes/
  - /net/rész/
keywords:
  - szöveg hozzáadása
  - bekezdés hozzáadása
  - szöveg kezelése
  - bekezdés kezelése
  - felsorolás kezelése
  - bekezdés behúzása
  - függő behúzás
  - bekezdés felsorolás
  - számozott lista
  - felsoroláslista
  - bekezdés tulajdonságok
  - HTML importálása
  - szöveg HTML-be
  - bekezdés HTML-be
  - bekezdés képpé
  - szöveg képpé
  - bekezdés exportálása
  - PowerPoint
  - prezentáció
  - .NET
  - C#
  - Aspose.Slides
description: "Tanulja meg, hogyan hozhat létre és formázhat bekezdéseket, részeket, felsorolásjeleket, számozott listákat, behúzásokat, HTML tartalmat és bekezdés képeket az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

Aspose.Slides for .NET a szöveget szövegdobozok, bekezdések és részek (portions) hierarchiájában ábrázolja:

* [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) a szöveg tárolója egy alakzatban, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [IParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/) egy bekezdést képvisel egy szövegdobozban, és hozzáférést biztosít a részeihez és a bekezdés‑szintű formázáshoz.
* [IPortion](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/) egy szövegrészt (run) képvisel egy bekezdésen belül. Minden rész saját szöveggel és karakter‑szintű formázással rendelkezhet.

Egy bekezdés ezért több rész segítségével különböző betűtípusú, színű, méretű és egyéb formázású szöveget is tartalmazhat.

## **Bekezdések létrehozása és formázása**

### **Bekezdések létrehozása több részzel**

Az alábbi lépések egy szövegdobozt hoznak létre három bekezdéssel, melyek mindegyike három részt tartalmaz:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
2. Érje el a megfelelő diát a indexén keresztül.
3. Adjon hozzá egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) a diához.
4. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/)‑jét.
5. Használja az alapértelmezett bekezdést, és adjon hozzá két további [IParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/) objektumot a szövegdobozhoz.
6. Adjon elegendő [IPortion](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/) objektumot minden bekezdéshez, hogy három részt tartalmazzanak. Az alapértelmezett bekezdés már tartalmaz egy üres részt.
7. Állítsa be minden rész szövegét.
8. Alkalmazzon karakter szintű formázást a [IPortion.PortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/portionformat/) segítségével.
9. Mentse el a módosított prezentációt.

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

## **Felsorolás és számozott listák létrehozása**

### **Felsorolás vagy számozott lista létrehozása**

A felsorolás‑ és számjelölések megkönnyítik a kapcsolódó elemek átláthatóságát. Az Aspose.Slides-ban a lista beállításait az [IBulletFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/) segítségével definiálhatja.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
2. Érje el a megfelelő diát a indexén keresztül.
3. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) a kiválasztott diára.
4. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/)‑jét.
5. Távolítsa el az alapértelmezett bekezdést a szövegdobozból.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraph/) a szimbólum felsoroláshoz.
7. Állítsa be a [IBulletFormat.Type](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/type/)‑t [BulletType.Symbol](https://reference.aspose.com/slides/hu/net/aspose.slides/bullettype/)‑ra, és adja meg a jel karakterét.
8. Állítsa be a bekezdés szövegét, a behúzást, a felsorolás színét és a felsorolás magasságát.
9. Adja hozzá a bekezdést a szövegdobozhoz.
10. Hozzon létre egy második bekezdést, és állítsa be a [IBulletFormat.Type](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/type/)‑t [BulletType.Numbered](https://reference.aspose.com/slides/hu/net/aspose.slides/bullettype/)‑ra.
11. Konfigurálja a számozott felsorolás stílusát, és adja hozzá a bekezdést a szövegdobozhoz.
12. Mentse el a prezentációt.

Ez a C# példa egy szimbólum és egy számozott felsorolást hoz létre:

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

A képes felsorolások lehetővé teszik, hogy egy egyedi képet használjon szimbólum vagy szám helyett.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
2. Érje el a megfelelő diát a indexén keresztül.
3. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) és érje el annak [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/)‑jét.
4. Távolítsa el az alapértelmezett bekezdést a szövegdobozból.
5. Töltse be a felsorolás képet, és adja hozzá a prezentáció képgyűjteményéhez [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) objektumként.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraph/) és állítsa be a szövegét.
7. Állítsa be a [IBulletFormat.Type](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/type/)‑t [BulletType.Picture](https://reference.aspose.com/slides/hu/net/aspose.slides/bullettype/)‑ra.
8. Rendelje hozzá a képet a [IBulletFormat.Picture](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/picture/) segítségével, és állítsa be a felsorolás magasságát.
9. Adja hozzá a bekezdést a szövegdobozhoz.
10. Mentse el a módosított prezentációt.

Ez a C# példa egy képes felsorolást hoz létre:

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

Állítsa be a [IParagraphFormat.Depth](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/depth/)‑t, hogy a bekezdéseket a lista különböző szintjeire helyezze. A felső szint mélysége `0`.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/)‑t, és érje el egy diát.
2. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/)‑t, és törölje az alapértelmezett bekezdést a szövegdobozából.
3. Hozzon létre négy bekezdést, és állítsa be a felsorolás szimbólumaikat.
4. Állítsa be a [IParagraphFormat.Depth](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/depth/) értékét `0`, `1`, `2` és `3`‑ra.
5. Adja hozzá a bekezdéseket a szövegdobozhoz, és mentse el a prezentációt.

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

### **Számozott listaelemek indítása egyedi értékekkel**

Használja a [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/numberedbulletstartwith/) beállítást, hogy megadja a számozott bekezdés kiinduló számát.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation)‑t, és adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/)‑t a diához.
2. Törölje az alapértelmezett bekezdést az alakzat szövegdobozából.
3. Hozzon létre három számozott bekezdést.
4. Állítsa be a [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/numberedbulletstartwith/) értékét `2`, `3` és `7`‑re a megfelelő bekezdéseknél.
5. Adja hozzá a bekezdéseket a szövegdobozhoz, és mentse el a prezentációt.

Ez a C# példa egyedi kiinduló számot rendel minden bekezdéshez:

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

## **Bekezdés elrendezésének és befejező tulajdonságainak vezérlése**

### **Első sor behúzás beállítása**

Használja az [IParagraphFormat.Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) tulajdonságot a bekezdés első sorának behúzásának szabályozásához. Ez a tulajdonság csak az első sort mozdítja el a bekezdés bal margójához képest. Pozitív érték esetén az első sor jobbra tolódik, míg a többi sor a bekezdés törzséhez igazodik.

Használja az [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/marginleft/)‑t, ha az egész bekezdést szeretné elmozdítani. Használja az [IParagraphFormat.Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/)‑t, ha csak az első sort akarja elmozdítani.

Az alábbi példa több bekezdést hoz létre, és különböző [IParagraphFormat.Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) értékeket alkalmaz, hogy bemutassa, hogyan befolyásolja a bekezdéselrendezést az első sor behúzása.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
2. Érje el a célzott diát.
3. Adjon hozzá egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/)‑t a diához.
4. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/)‑jét, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) értékeket számukra.
6. Adja hozzá a bekezdéseket a szövegdobozhoz.
7. Mentse el a módosított prezentációt.

Ez a kód megmutatja, hogyan állítható be a bekezdés behúzása:

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

![The first-line indent of the paragraphs](first_line_indent.png)

### **Függő behúzás beállítása**

A függő behúzás egy olyan bekezdéselrendezés, ahol az első sor balra kezdődik a többi sorhoz képest. Az Aspose.Slides-ban ezt a hatást az [IParagraphFormat.Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) tulajdonsággal hozhatja létre. Állítsa az `Indent` értékét negatívra, hogy az első sor balra mozduljon a bekezdés törzséhez képest.

Gyakorlatban az [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/marginleft/) definiálja a bekezdés törzsének bal pozícióját, míg az [IParagraphFormat.Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) meghatározza az első sor helyzetét ehhez a margóhoz képest. Függő behúzás létrehozásához állítson be egy pozitív `MarginLeft` értéket és egy negatív `Indent` értéket.

Ez a formázás hasznos bibliográfiák, hivatkozások, szószedetek és egyéb bekezdések esetén, ahol a tördelődő soroknak a bekezdés törzsének alatt kell elhelyezkedniük, nem pedig az első sor első karaktere alatt.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
2. Érje el a célzott diát.
3. Adjon hozzá egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/)‑t a diához.
4. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/)‑jét, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és állítson be egy pozitív [MarginLeft](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/marginleft/) értéket minden bekezdéshez.
6. Állítson be egy negatív [Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) értéket a függő behúzás létrehozásához.
7. Adja hozzá a bekezdéseket a szövegdobozhoz.
8. Mentse el a módosított prezentációt.

Ez a kód megmutatja, hogyan állítható be a függő behúzás egy bekezdéshez:

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

![The hanging indent of the paragraphs](hanging_indent.png)

### **A bekezdés végének futtatási tulajdonságainak beállítása**

Az [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/endparagraphportionformat/) tulajdonság szabályozza a bekezdés végjelének formázását. Az alábbi példa egy betűméretet és egy latin betűtípust rendel a második bekezdés végjeléhez:

1. Töltsön be egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/)‑t, és érje el egy diát.
2. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/)‑t, és törölje az alapértelmezett bekezdést.
3. Hozzon létre két bekezdést, és adjon hozzá szövegrészeket.
4. Hozzon létre egy [PortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/portionformat/)‑t a második bekezdés végjeléhez.
5. Állítsa be a [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseportionformat/fontheight/) és a [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseportionformat/latinfont/) értékeket.
6. Rendelje hozzá a formázást az [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/endparagraphportionformat/)‑hez, és mentse el a prezentációt.

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

## **Bekezdés tartalom importálása és exportálása**

### **HTML szöveg importálása bekezdésekbe**

Használja a [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraphcollection/addfromhtml/)‑t, hogy a HTML jelölőnyelvet bekezdésekké és részekké alakítsa egy szövegdobozban.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
2. Érje el egy diát, és adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/)‑t.
3. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/)‑jét, és törölje az alapértelmezett bekezdést.
4. Olvassa be a forrás HTML fájlt.
5. Adja át a HTML karakterláncot a [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraphcollection/addfromhtml/)‑nek.
6. Mentse el a módosított prezentációt.

Ez a C# példa HTML-t importál egy szövegdobozba:

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

### **Bekezdésszöveg exportálása HTML-be**

Használja a [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraphcollection/exporttohtml/)‑t, hogy a kijelölt bekezdéstartományt HTML-ként exportálja.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból, és töltse be a kívánt prezentációt.
2. Érje el a diát, és keresse meg a szöveget tartalmazó [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/)‑t.
3. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/)‑jét.
4. Hívja meg a [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraphcollection/exporttohtml/)‑t a kezdő bekezdés indexével és az exportálandó bekezdések számával.
5. Írja a visszakapott HTML karakterláncot egy fájlba.

Ez a C# példa az első szöveges alakzat összes bekezdését exportálja:

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

[IParagraph.GetImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/getimage/) közvetlenül egy bekezdést renderel, és egy [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/)‑t ad vissza. A visszakapott képet fájlba vagy stream‑be mentheti a [IImage.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/save/)‑vel. Nem kell a tartalmazó alakzatot renderelni vagy a bitmapet manuálisan kivágni.

[IParagraph.GetImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/getimage/) `null` értéket adhat vissza, ha a bekezdés nem található a szülő gyűjteményben, nincs érvényes renderelési határa, vagy nem renderelhető. Ellenőrizze az eredményt a mentés előtt, és a használat után szabadítsa fel a visszakapott képet.

#### **Bekezdés renderelése az alapértelmezett méretezésben**

Tegyük fel, hogy van egy sample.pptx nevű prezentációs fájlunk egy diával, ahol az első alakzat egy három bekezdést tartalmazó szövegdoboz.

![The text box with three paragraphs](paragraph_to_image_input.png)

Az alábbi példa a második bekezdést egy általános szöveges alakzatban az alapértelmezett méretezésben rendereli, és a visszakapott képet PNG formátumban menti. A `using` deklaráció biztosítja, hogy a kép helyesen felszabaduljon.

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

![The paragraph image](paragraph_to_image_output.png)

#### **Bekezdés renderelése táblázatcellában méretezéssel**

Használja a [IParagraph.GetImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/getimage/) túlterhelést, amely `float scaleX` és `float scaleY` paramétereket fogad a vízszintes és függőleges méretezési tényezők beállításához. Az alábbi példa egy táblázatot hoz létre, a bekezdést az első cellájában kétszeres szélességre és magasságra rendereli, majd a eredményt PNG képként menti.

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

Az `1` méretezési tényező az adott tengelyt az alapértelmezett pixelméretben tartja. Például a `2` mindkét tényező esetén a kép szélessége és magassága nagyjából kétszerese az alapértelmezett méretnek, ami négyszeres pixel számot eredményez. A nagyobb tényezők általában élesebb szöveget biztosítanak nagyításkor vagy nagy felbontású kimenetnél, de növelik a memóriahasználatot és a fájlméretet. Az `1`‑nél kisebb tényezők kisebb, kevésbé részletgazdag képeket adnak. Azonos tényezők használata megőrzi a bekezdés oldalarányát; különböző vízszintes és függőleges tényezők külön-külön nyújtják a kimenetet.

Egy teljes alakzat renderelése a [IShape.GetImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/getimage/)‑val akkor hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, szegélyét vagy egyéb vizuális kontextusát. Ha csak a bekezdés képe a cél, használja az [IParagraph.GetImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/getimage/)‑t.

## **GYIK**

**Teljesen letilthatom a sortörést egy szövegdobozban?**

Igen. Állítsa be az [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/wraptext/) tulajdonságot, hogy letiltsa a sortörést, így a sorok nem törnek a szövegdoboz szélén.

**Hogyan kaphatom meg egy adott bekezdés pontos dián belüli határait?**

Használja az [IParagraph.GetRect](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/getrect/)‑t a bekezdés határoló téglalapjának lekéréséhez. Az [IPortion.GetRect](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/getrect/) egy egyedi rész határait adja vissza.

**Hol szabályozható a bekezdés igazítása (balra, jobbra, középre vagy sorkizárt)?**

Az [IParagraphFormat.Alignment](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/alignment/) egy bekezdés‑szintű beállítás, amely a teljes bekezdésre vonatkozik, függetlenül az egyes részek formázásától.

**Beállíthatok bizonyos nyelvet egy bekezdés részére?**

Igen. Állítsa be az [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseportionformat/languageid/)‑t az egyes részeknél, így egy bekezdés több nyelven is tartalmazhat szöveget.