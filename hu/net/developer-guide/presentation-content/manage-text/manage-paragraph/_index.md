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
- felsorolásjel kezelése
- bekezdés behúzás
- függő behúzás
- bekezdés felsorolásjel
- számozott lista
- felsoroláslista
- bekezdés tulajdonságok
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
description: "Ismerje meg, hogyan hozhat létre és formázhat bekezdéseket, részeket, felsorolásjeleket, számozott listákat, behúzásokat, HTML tartalmakat és bekezdés képeket az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

Az Aspose.Slides for .NET a szöveget szövegkeretek, bekezdések és részek (portion) hierarchiájában ábrázolja:

* [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) egy alakzatban a szöveg tárolóját képviseli, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [IParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/) egy bekezdést képvisel egy szövegkeretben, és hozzáférést ad a részeihez és a bekezdés szintű formázáshoz.
* [IPortion](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/) egy szövegtöredéket (run) képvisel egy bekezdésen belül. Minden résznek saját szövege és karakter szintű formázása lehet.

Ezért egy bekezdés több rész használatával különböző betűtípusú, színű, méretű és egyéb formázású szöveget tartalmazhat.

## **Bekezdések létrehozása és formázása**

### **Több részt (Portion) tartalmazó bekezdések létrehozása**

Az alábbi lépések egy szövegkeretet hoznak létre három bekezdéssel, mindegyik három részt tartalmazva:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
2. Hozzáférés a megfelelő dia hivatkozásához az indexe alapján.
3. Adjon hozzá egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diára.
4. Érje el a forma [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) objektumát.
5. Használja az alapértelmezett bekezdést, és adjon hozzá még két [IParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/) objektumot a szövegkerethez.
6. Adjon elegendő [IPortion](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/) objektumot minden bekezdéshez, hogy három részt tartalmazzanak. Az alapértelmezett bekezdés már egy üres részt tartalmaz.
7. Állítsa be minden rész szövegét.
8. Alkalmazzon karakter szintű formázást a [IPortion.PortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/portionformat/) segítségével.
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

## **Számozott és felsorolásos listák létrehozása**

### **Felsorolás vagy számozott lista létrehozása**

A felsorolásjelek és a számozás megkönnyítik a kapcsolódó elemek áttekintését. Az Aspose.Slides-ben a lista beállításait az [IBulletFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/) határozza meg.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
2. Hozzáférés a megfelelő dia hivatkozásához az indexe alapján.
3. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a kiválasztott diára.
4. Érje el a forma [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) objektumát.
5. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraph/) objektumot egy szimbólum felsoroláshoz.
7. Állítsa be a [IBulletFormat.Type](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/type/) értékét [BulletType.Symbol](https://reference.aspose.com/slides/hu/net/aspose.slides/bullettype/)‑ra, és adja meg a felsorolás karakterét.
8. Állítsa be a bekezdés szövegét, behúzását, a felsorolás színét és magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Hozzon létre egy második bekezdést, és állítsa be a [IBulletFormat.Type](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/type/) értékét [BulletType.Numbered](https://reference.aspose.com/slides/hu/net/aspose.slides/bullettype/)‑ra.
11. Konfigurálja a számozott felsorolás stílusát, és adja hozzá a bekezdést a szövegkerethez.
12. Mentse a prezentációt.

Ez a C# példa szimbólum és számozott felsorolást hoz létre:

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

A képes felsorolások lehetővé teszik egy egyéni kép használatát szimbólum vagy szám helyett.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
2. Hozzáférés a megfelelő dia hivatkozásához az indexe alapján.
3. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet, és érje el annak [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) objektumát.
4. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
5. Töltse be a felsorolás képet, és adja hozzá a prezentáció képgyűjteményéhez egy [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) objektumként.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraph/) objektumot, és állítsa be a szövegét.
7. Állítsa be a [IBulletFormat.Type](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/type/) értékét [BulletType.Picture](https://reference.aspose.com/slides/hu/net/aspose.slides/bullettype/)‑ra.
8. Adja meg a képet a [IBulletFormat.Picture](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/picture/) segítségével, és állítsa be a felsorolás magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Mentse a módosított prezentációt.

Ez a C# példa képes felsorolást hoz létre:

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

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) objektumot, és nyisson meg egy diát.
2. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet, és tisztítsa meg a szövegkeret alapértelmezett bekezdését.
3. Hozzon létre négy bekezdést, és állítsa be azok felsorolás szimbólumait.
4. Állítsa be a [IParagraphFormat.Depth](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/depth/) értékeket `0`, `1`, `2`, és `3`‑ra.
5. Adja hozzá a bekezdéseket a szövegkerethez, majd mentse a prezentációt.

Ez a C# példa négyszintű felsorolást hoz létre:

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

### **Számozott listaelemek egyéni kezdőértékkel**

Használja az [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/numberedbulletstartwith/) tulajdonságot a számozott bekezdés kezdeti számának beállításához.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) objektumot, és adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet egy diára.
2. Törölje a forma szövegkeretének alapértelmezett bekezdését.
3. Hozzon létre három számozott bekezdést.
4. Állítsa be az [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/numberedbulletstartwith/) értékét `2`, `3`, és `7`‑re a megfelelő bekezdésekhez.
5. Adja hozzá a bekezdéseket a szövegkerethez, és mentse a prezentációt.

Ez a C# példa egyedi kezdőszámot rendel minden bekezdéshez:

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

## **Bekezdéselrendezés és befejező tulajdonságok szabályozása**

### **Első sor behúzásának beállítása**

Az [IParagraphFormat.Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) tulajdonsággal szabályozható a bekezdés első sorának behúzása. Ez a tulajdonság csak az első sort mozdítja el a bekezdés bal margójához képest. Pozitív érték esetén az első sor jobbra tolódik, míg a többi sor a bekezdés törzséhez igazodik.

Ha a teljes bekezdést szeretné eltolni, használja az [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/marginleft/) értékét. Ha csak az első sort akarja eltolni, használja az [IParagraphFormat.Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) értékét.

Az alábbi példa több bekezdést hoz létre, és különböző [IParagraphFormat.Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) értékeket alkalmaz, hogy bemutassa, miként befolyásolja a behúzás a bekezdés elrendezését.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példányt.
2. Érje el a cél-diat.
3. Adjon hozzá egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diára.
4. Érje el a forma [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) objektumát, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) értékeket.
6. Adja hozzá a bekezdéseket a szövegkerethez.
7. Mentse a módosított prezentációt.

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

![Az első sor behúzása a bekezdéseknél](first_line_indent.png)

### **Függő behúzás beállítása**

A függőbehúzás olyan bekezdéselrendezés, ahol az első sor a többi sor bal oldalán kezdődik. Az Aspose.Slides-ben ezt a [IParagraphFormat.Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) tulajdonsággal érhetjük el. Állítsa az `Indent` értékét negatívra, hogy az első sor balra mozduljon el a bekezdés törzséhez képest.

Gyakorlatban az [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/marginleft/) meghatározza a bekezdés törzs bal pozícióját, az [IParagraphFormat.Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) pedig az első sor helyzetét ehhez a margóhoz képest. Függőbehúzáshoz állítson be pozitív `MarginLeft` értéket, és negatív `Indent` értéket.

Ez a formázás hasznos bibliográfiák, hivatkozások, szószedet-bejegyzések és más olyan bekezdések esetén, ahol a tördelődő soroknak a bekezdés törzse alatt kell elhelyezkedniük, nem pedig az első sor első karaktere alatti.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példányt.
2. Érje el a cél-diat.
3. Adjon hozzá egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diára.
4. Érje el a forma [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) objektumát, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és minden bekezdéshez állítson be egy pozitív [MarginLeft](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/marginleft/) értéket.
6. Állítson be egy negatív [Indent](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/indent/) értéket a függőbehúzás létrehozásához.
7. Adja hozzá a bekezdéseket a szövegkerethez.
8. Mentse a módosított prezentációt.

Ez a kód megmutatja, hogyan állítható be a függőbehúzás egy bekezdéshez:

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

![A függőbehúzás a bekezdéseknél](hanging_indent.png)

### **Befejező bekezdésrészek tulajdonságainak beállítása**

Az [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/endparagraphportionformat/) tulajdonság szabályozza a bekezdés végét jelző jel (end mark) formázását. Az alábbi példa a második bekezdés végjeléhez betűméretet és latin betűtípust rendel:

1. Töltsön be egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) fájlt, és érje el egy diát.
2. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet, és távolítsa el az alapértelmezett bekezdést.
3. Hozzon létre két bekezdést, és adjon hozzá szövegrétegeket (portions) hozzájuk.
4. Hozzon létre egy [PortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/portionformat/) objektumot a második bekezdés végjeléhez.
5. Állítsa be az [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseportionformat/fontheight/) és [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseportionformat/latinfont/) értékeket.
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

## **Megjelenített sorok számlálása**

A bekezdésre vonatkozó szabályok, amelyek az automatikus tördelést és a sortörésnél lévő írásjeleket érintik, megtalálhatók a [Control Line Breaking](/slides/hu/net/text-formatting/#control-line-breaking) és a [Control Hanging Punctuation](/slides/hu/net/text-formatting/#control-hanging-punctuation) című részekben.

Használja az [IParagraph.GetLinesCount](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/getlinescount/) metódust a bekezdés által a szöveg elrendezése után elfoglalt sorok számának meghatározásához, beleértve az automatikus tördelést is. Ez hasznos szöveghossz és elrendezés ellenőrzésére prezentációs sablonokban.

Egy bekezdés a [ITextFrame.Paragraphs](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/paragraphs/) egyik eleme, és több megjelenített sort is elfoglalhat. Egy explicite sortörés egy bekezdésen belül új sort hoz létre anélkül, hogy új bekezdést generálna. Az automatikus tördelés a rendelkezésre álló szélesség alapján hoz létre sorokat, anélkül, hogy explicite sortöréseket szúrna be a szövegbe. Ezért a bekezdések vagy sortörés karakterek számlálása nem ad pontos megjelenített sorok számát.

Az alábbi példa egy szöveges alakzatot hoz létre, megszámolja a sorait, szűkíti az alakzatot, majd rövidebb szöveggel helyettesíti a tartalmat. A tördelés engedélyezett, az automatikus méretezés (autofit) le van tiltva, így az alakzat szélessége szabályozza a tördelést anélkül, hogy a szöveg automatikusan zsugorodna vagy az alakzat mérete változna. Az alakzat mérete pontban van megadva. Végül a példa egy újabb bekezdést ad hozzá, és összeadja a sorok számát a teljes szövegkeretben.

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

Ezekkel a szöveggel és méretekkel a forma szűkítése növeli a sorok számát, míg a rövid szövegre cserélés csökkenti azt. A pontos számok a betűtípus elérhetőségétől, helyettesítésétől, méretétől, margóktól, behúzásoktól, tördeléstől és az autofit beállításoktól függnek. A célkörnyezetben használandó betűtípusok és elrendezési beállítások ellenőrzésekor vegye figyelembe ezeket.

A sorok száma önmagában nem határozza meg, hogy a szöveg túllépi-e a konténerét. A rendelkezésre álló magasság, sormagasságok, bekezdés- és sorközök, valamint az autofit viselkedése is számít; még egyetlen sor is meghaladhatja a rendelkezésre álló szélességet, ha a tördelés ki van kapcsolva.

## **Bekezdés tartalmának importálása és exportálása**

### **HTML szöveg importálása bekezdésekbe**

Használja a [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraphcollection/addfromhtml/) metódust a HTML jelölés bekezdésekké és részekké (portion) konvertálásához egy szövegkeretben.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) példányt.
2. Nyisson meg egy diát, és adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet.
3. Érje el a forma [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) objektumát, és távolítsa el az alapértelmezett bekezdést.
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

Használja a [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraphcollection/exporttohtml/) metódust a kiválasztott bekezdéstartomány HTML formátumba exportálásához.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) példányt, és töltse be a kívánt prezentációt.
2. Nyissa meg a diát, és keresse meg azt a [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet, amelyik a szöveget tartalmazza.
3. Érje el a forma [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) objektumát.
4. Hívja meg a [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraphcollection/exporttohtml/) metódust a kezdő bekezdés indexével és a exportálandó bekezdések számával.
5. Írja a visszaadott HTML szöveget egy fájlba.

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

Az [IParagraph.GetImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/getimage/) egyetlen bekezdést renderel közvetlenül, és visszaad egy [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) objektumot. A visszakapott képet a [IImage.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/save/) metódussal mentheti fájlba vagy adatfolyamba. Nem szükséges a tartalmazó alakzatot renderelni vagy a bitmapet manuálisan kivágni.

Az [IParagraph.GetImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/getimage/) `null`‑t adhat vissza, ha a bekezdés nem található a szülőgyűjteményben, nincs érvényes megjelenítési határa, vagy nem renderelhető. Ellenőrizze az eredményt a mentés előtt, és a felhasználás után szabadítsa fel a visszakapott képet.

#### **Bekezdés renderelése alapértelmezett méretarányban**

Tegyük fel, hogy van egy `sample.pptx` nevű prezentációfájl egy diával, ahol az első alakzat egy három bekezdést tartalmazó szövegdoboz.

![A szövegdoboz három bekezdéssel](paragraph_to_image_input.png)

Az alábbi példa a második bekezdést egy szabályos szöveges alakzatban rendereli alapértelmezett méretarányban, és PNG formátumban menti a visszakapott képet. A `using` deklaráció biztosítja, hogy a kép megfelelően legyen elengedve.

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

Használja az [IParagraph.GetImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/getimage/) túlterhelését, amely a `float scaleX` és `float scaleY` paramétereket fogadja a vízszintes és függőleges méretezési tényezők beállításához. Az alábbi példa egy táblázatot hoz létre, a bekezdést az első cellájában a kétszeres alapértelmezett szélesség és magasság mellett rendereli, majd PNG képként menti az eredményt.

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

Az `1` méretezési tényező megtartja az adott tengelyt az alapértelmezett pixelméretén. Például a `2` mindkét tényezőre azt eredményezi, hogy a kép szélessége és magassága hozzávetőlegesen kétszeresére nő, így a pixelek száma négyszeres lesz. A nagyobb tényezők általában élesebb szöveget eredményeznek nagyítás vagy nagy felbontású kimenet esetén, de növelik a memóriahasználatot és a fájlméretet. Az `1` alatti tényezők kisebb, kevésbé részletes képet adnak. A képarány megtartásához használjon egyenlő tényezőket; a különböző vízszintes és függőleges tényezők függetlenül nyújtják a kimenetet.

Teljes alakzat renderelése az [IShape.GetImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/getimage/) segítségével akkor hasznos, amikor a kimenetnek tartalmaznia kell az alakzat kitöltését, szegélyét vagy egyéb vizuális kontextusát. Egy csak bekezdésből álló képhez használja az [IParagraph.GetImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/getimage/) metódust.

## **GYIK**

**Teljesen letiltható a sortördelés egy szövegkereten belül?**

Igen. Állítsa az [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/wraptext/) értékét a sorok tördelésének letiltásához, így a sorok nem törnek meg a szövegkeret szélén.

**Hogyan kaphatom meg egy adott bekezdés pontos helyi (slide) határait?**

Használja az [IParagraph.GetRect](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/getrect/) metódust a bekezdés határoló téglalapjának lekéréséhez. Az [IPortion.GetRect](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/getrect/) egy adott rész határait adja vissza.

**Hol van szabályozva a bekezdés igazítása (balra, jobbra, középre vagy sorkizárásra)?**

Az [IParagraphFormat.Alignment](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/alignment/) egy bekezdés szintű beállítás, amely a teljes bekezdésre érvényes, függetlenül az egyes részek formázásától.

**Beállítható a helyesírás-ellenőrzés nyelve a bekezdés egy részére?**

Igen. Az [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseportionformat/languageid/) beállítható egyes részeknél, így egy bekezdés több nyelven is tartalmazhat szöveget.