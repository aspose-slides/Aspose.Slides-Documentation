---
title: "Felsorolásos és számozott listák kezelése prezentációkban .NET-ben"
linktitle: "Listák kezelése"
type: docs
weight: 70
url: /hu/net/manage-lists/
aliases:
  - /net/manage-bullet-and-numbered-lists/
keywords:
  - felsorolásjel
  - felsorolásjelű lista
  - számozott lista
  - szimbólum felsorolásjel
  - képes felsorolásjel
  - egyedi felsorolásjel
  - többszintű lista
  - felsorolásjel létrehozása
  - felsorolásjel hozzáadása
  - lista hozzáadása
  - PowerPoint
  - OpenDocument
  - prezentáció
  - .NET
  - C#
  - Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és formázhat felsorolásjelű, képes, többszintű és számozott listákat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for .NET használatával."
---
## **Áttekintés**

Az Aspose.Slides for .NET lehetővé teszi, hogy felsorolásjegyes és számozott listákat hozzon létre és formázzon PowerPoint és OpenDocument prezentációkban. Egy listaelem egy bekezdés, amelynek a felsorolásbeállításait a bekezdés formátuma vezérli.

Használja a [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) tulajdonságot a bekezdés szintű lista beállítások eléréséhez. A fő belépési pont a [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/), amely egy [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) objektumot ad vissza. Ezzel az objektummal beállíthatja a felsorolás típusát, szimbólumát, képét, színét, méretét, a számozási stílust és a kezdő számot.

Ez a cikk bemutatja, hogyan:

- létrehozni egy felsorolásjelű listát egy egyedi szimbólummal
- létrehozni egy képes felsorolásjelet
- létrehozni egy többszintű listát a bekezdés mélységének beállításával
- létrehozni egy számozott listát
- ellenőrizni és módosítani a lista formázását egy meglévő prezentációban
- beolvasni a tényleges listajelölőket és számokat a bekezdés szövege mellett

## **Felsorolásjeles lista létrehozása**

Felsorolásjeles lista létrehozásához adjon [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) objektumokat egy [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) elemhez, és állítsa a [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) értékét [BulletType.Symbol](https://reference.aspose.com/slides/net/aspose.slides/bullettype/). Ezután beállíthatja a [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/), a [IBulletFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/color/) és a [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) értékeket a felsorolás megjelenésének vezérléséhez.

Az alábbi C# kód bemutatja, hogyan hozhat létre felsorolásjeles listát egy dián:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

static Paragraph CreateParagraph(string text)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Bullet.Char = '*';
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
    paragraph.ParagraphFormat.Bullet.Color.Color = Color.IndianRed;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = CreateParagraph("The first paragraph");
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph");
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("symbol_bullets.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A szimbólum jelű felsorolás](symbol_bullets.png)

## **Számozott lista létrehozása**

Használjon számozott listákat, ha az elemek sorrendje fontos. Állítsa be a [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) értékét [BulletType.Numbered](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) értékre. A [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) segítségével kiválaszthat egy számozási formátumot, vagy beállíthatja a [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) értéket, ha a lista az 1-etől eltérő értékkel kell hogy kezdődjön.

Az alábbi C# kód megmutatja, hogyan hozhat létre számozott listát egy dián:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph1.Text = "Apple";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph2.Text = "Orange";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph3.Text = "Banana";
textFrame.Paragraphs.Add(paragraph3);

presentation.Save("numbered_bullets.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A számozott felsorolások](numbered_bullets.png)

## **Képes felsorolásjel létrehozása**

Az Aspose.Slides lehetővé teszi, hogy egy normál felsorolásjel szimbólumát képpel helyettesítse. A képes felsorolásjelek a legegyszerűbb képekkel működnek a legjobban, amelyek kis méretben is olvashatóak, például ikonok vagy kis átlátszó PNG fájlok.

{{% alert color="info" title="Note" %}}
Ideálisan, ha a normál felsorolásjel szimbólumát képpel szeretné helyettesíteni, a legjobb egy átlátszó háttérrel rendelkező egyszerű grafikát választani. Az ilyen képek jól működnek egyedi felsorolásjel szimbólumként.

Vegye figyelembe, hogy a képet nagyon kicsire lesz méretezve. Emiatt erősen javasoljuk, hogy olyan képet válasszon, amely tiszta és vizuálisan hatékony marad, amikor felsorolásjeleként használják a listában.
{{% /alert %}}

Képes felsorolásjel létrehozásához adjon egy képet a [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/images/) gyűjteményhez, és rendelje hozzá a visszakapott képobjektumot a [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/). A kép hozzárendelése előtt állítsa be a [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) értékét [BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) értékre.

Tegyük fel, hogy van egy „image.png” nevű fájlunk:

![Kép a felsorolásokhoz](picture_for_bullets.png)

Az alábbi C# kód megmutatja, hogyan hozhat létre képes felsorolásjeleket egy dián:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

static Paragraph CreateParagraph(string text, IPPImage image)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
    paragraph.ParagraphFormat.Bullet.Picture.Image = image;
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var imageBytes = File.ReadAllBytes("image.png");
var bulletImage = presentation.Images.AddImage(imageBytes);

var paragraph1 = CreateParagraph("The first paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("picture_bullets.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A képes felsorolások](picture_bullets.png)

## **Többszintű lista létrehozása**

Használja a [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) értéket, hogy a listaelemeket különböző szinteken helyezze el. A 0. szint a legfelső szint, az 1. szint alatta helyezkedik el, és így tovább.

Az alábbi C# kód megmutatja, hogyan hozhat létre többszintű felsorolásjeles listát:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Depth = 0;
paragraph1.Text = "My text - Depth 0";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Depth = 1;
paragraph2.Text = "My text - Depth 1";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Depth = 2;
paragraph3.Text = "My text - Depth 2";
textFrame.Paragraphs.Add(paragraph3);

var paragraph4 = new Paragraph();
paragraph4.ParagraphFormat.Depth = 3;
paragraph4.Text = "My text - Depth 3";
textFrame.Paragraphs.Add(paragraph4);

presentation.Save("multilevel_bullets.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A többszintű lista](multilevel_list.png)

## **Meglévő lista módosítása**

A listaformázás megváltoztatásához egy meglévő prezentációban érje el a célnak megfelelő bekezdést, és frissítse annak [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/) beállításait. Ugyanazok a tulajdonságok, amelyeket listák létrehozásához használnak, felhasználhatók a PPT, PPTX vagy ODP fájlból betöltött listák vizsgálatához vagy módosításához.

Az alábbi C# kód megváltoztatja a szövegdoboz első bekezdését, hogy számozott lista stílust használjon:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var autoShape = (IAutoShape)slide.Shapes[0];

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletRomanUCPeriod;
paragraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 1;
paragraph.ParagraphFormat.MarginLeft = 30;
paragraph.ParagraphFormat.Indent = -20;

presentation.Save("updated_list.pptx", SaveFormat.Pptx);
```

## **Tényleges felsorolásértékek beolvasása**

A prezentáció tartalmának kinyerésekor tartsa meg a listajelölőket a bekezdés szövege mellett. Hívja meg a [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/) metódust, és érje el a [IParagraphFormatEffectiveData.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformateffectivedata/bullet/) értéket a hatékony felsorolásformátum lekéréséhez. Olvasás előtt ellenőrizze a [Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/type/) értékét, mielőtt a [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) értéket olvasná.

Számozott listák esetén különböztesse meg ezeket a három értéket:

- [NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/numberedbulletstyle/) meghatározza a formátumot, például arab számok pont után vagy kisbetűk pont után.
- [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/numberedbulletstartwith/) adja meg a kezdő számot egy számozott bekezdéscsoportnak.
- [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) visszaadja egy adott bekezdés formázott jelölőjét. Például egy 5‑től induló lista második eleme `6.`‑ot ad.

Minden bekezdésnél őrizze meg a [Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) értékét, hogy megtartsa a beágyazottsági szintjét. A tényleges jelölő nem kódolja a teljes hierarchiát: egy beágyazott elem `c.`‑t adhat vissza a `6.c.`‑hoz hasonló kombinált címke helyett.

Az alábbi önálló példa listákat hoz létre, elmenti őket egy prezentációba, majd újratölti a prezentációt, hogy jelentést készítsen minden bekezdés szövegéről, mélységéről, felsorolás típusáról és tényleges értékéről. A kis kék képi jelölő inline SVG‑ből jön.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    presentation.SlideSize.SetSize(720, 440, SlideSizeScaleType.DoNotScale);
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20, 660, 400);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Paragraphs.Clear();

    // Készítsen egy képes jelölőt külső képfájl nélkül.
    var svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    var bulletImage = presentation.Images.AddImage(svg);

    void AddParagraph(string text, short depth, BulletType type, short start = 1, NumberedBulletStyle style = NumberedBulletStyle.BulletArabicPeriod)
    {
        var paragraph = new Paragraph { Text = text };

        var format = paragraph.ParagraphFormat;
        format.Depth = depth;
        format.MarginLeft = 30 + depth * 40;
        format.Indent = -28;
        format.SpaceAfter = 8;
        format.DefaultPortionFormat.FontHeight = 22;
        format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
        format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
        format.Bullet.Type = type;
        format.Bullet.IsBulletHardColor = NullableBool.True;
        format.Bullet.Color.Color = Color.Black;
        if (type == BulletType.Numbered)
        {
            format.Bullet.NumberedBulletStyle = style;
            format.Bullet.NumberedBulletStartWith = start;
        }
        else if (type == BulletType.Symbol)
        {
            format.Bullet.Char = '\u2022';
        }
        else if (type == BulletType.Picture)
        {
            format.Bullet.Picture.Image = bulletImage;
        }

        textFrame.Paragraphs.Add(paragraph);
    }

    AddParagraph("First item", 0, BulletType.Numbered, 5);
    AddParagraph("Second item", 0, BulletType.Numbered, 5);
    AddParagraph("Nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    AddParagraph("Next nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    AddParagraph("Deep item", 2, BulletType.Numbered, 4, NumberedBulletStyle.BulletRomanLCPeriod);
    AddParagraph("Back to top level", 0, BulletType.Numbered, 5);
    AddParagraph("Symbol marker", 0, BulletType.Symbol);
    AddParagraph("No bullet", 0, BulletType.None);
    AddParagraph("Picture marker", 0, BulletType.Picture);
    presentation.Save("actual_bullet_values.pptx", SaveFormat.Pptx);
}

using var loadedPresentation = new Presentation("actual_bullet_values.pptx");
var loadedShape = (IAutoShape)loadedPresentation.Slides[0].Shapes[0];
Console.WriteLine("Text | Depth | Type | Actual value");
foreach (var paragraph in loadedShape.TextFrame.Paragraphs)
{
    var bullet = paragraph.ParagraphFormat.GetEffective().Bullet;
    string marker;
    switch (bullet.Type)
    {
        case BulletType.Numbered:
        case BulletType.Symbol:
            marker = bullet.ActualBulletValue;
            break;
        case BulletType.None:
            marker = $"{bullet.ActualBulletValue ?? "null"} (no bullet)";
            break;
        case BulletType.Picture:
            marker = $"{bullet.ActualBulletValue ?? "null"} (image required)";
            break;
        default:
            marker = "unsupported bullet type";
            break;
    }
    Console.WriteLine($"{paragraph.Text} | {paragraph.ParagraphFormat.Depth} | {bullet.Type} | {marker}");
}
```

Az alábbiakban láthatóak a forráslisták.

![5-től kezdődő listák, beágyazott betű- és római számú elemek, szimbólum jelölő, egy bekezdés felsorolás nélkül, és egy kék képi jelölő](actual_bullet_values.png)

A jelentés megegyezik a PowerPointban megjelenített jelölőkkel:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

A [BulletType.None and BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) esetén az [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) `null` értéket ad vissza, nem üres karakterláncot. Kezelje ezeket a típusokat külön: az elsőnek nincs jelölője, míg a második esetén külön kell kinyerni a felsorolás képet. A képes felsorolásjelet nem lehet kizárólag szöveges jelölő kinyerésével reprodukálni.

## **FAQ**

**Exportálhatók a felsorolásjeles és számozott listák PDF‑re vagy képekre?**

Igen. Az Aspose.Slides megőrzi a lista formázását, ha a célformátum támogatja a megfelelő szövegelrendezést és felsorolás funkciókat.

**Szerkeszthetek listákat meglévő prezentációkban?**

Igen. Töltse be a prezentációt, érje el a célnak megfelelő bekezdést, vizsgálja vagy frissítse annak [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/) beállításait, és mentse a prezentációt.

**A listák tartalmazhatnak nem latin szöveget?**

Igen. A listaelemek szövege Unicode karaktereket is tartalmazhat, így többnyelvű prezentációkban is létrehozhat listákat. Győződjön meg róla, hogy a prezentációban használt betűkészletek támogatják a szükséges karaktereket.