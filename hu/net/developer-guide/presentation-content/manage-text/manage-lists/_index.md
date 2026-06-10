---
title: "Felsorolási és számozott listák kezelése prezentációkban .NET-ben"
linktitle: "Listák kezelése"
type: docs
weight: 70
url: /hu/net/manage-lists/
keywords:
- felsorolásjel
- felsorolási lista
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
description: "Ismerje meg, hogyan hozhat létre és formázhat felsorolási, képes, többszintű és számozott listákat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

Az Aspose.Slides for .NET lehetővé teszi felsorolási és számozott listák létrehozását és formázását PowerPoint és OpenDocument bemutatókban. A listaelem egy bekezdés, amelynek felsorolás beállításait a bekezdés formátumán keresztül szabályozzák.

Használja az [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/paragraphformat/) tulajdonságot a bekezdés‑szintű lista beállítások eléréséhez. A fő belépési pont az [IParagraphFormat.Bullet](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/bullet/), amely egy [IBulletFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/) objektumot ad vissza. Ezzel az objektummal beállíthatja a felsorolás típusát, szimbólumát, képét, színét, méretét, számozási stílusát és a kezdő számot.

Ez a cikk bemutatja, hogyan:

- egy egyedi szimbóllal ellátott felsorolási lista létrehozása
- képes felsorolójel létrehozása
- többszintű lista létrehozása a bekezdés mélységének beállításával
- számozott lista létrehozása
- lista formázásának ellenőrzése és módosítása egy meglévő bemutatóban

## **Felsorolási lista létrehozása**

A felsorolási lista létrehozásához adjon [IParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/) objektumokat egy [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/)‑hez, és állítsa be az [IBulletFormat.Type](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/type/) értékét a [BulletType.Symbol](https://reference.aspose.com/slides/hu/net/aspose.slides/bullettype/) típusra. Ezután beállíthatja az [IBulletFormat.Char](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/color/) és [IBulletFormat.Height](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/height/) értékeket a felsorolás megjelenésének szabályozásához.

Az alábbi C# kód bemutatja, hogyan hozhatunk létre felsorolási listát egy dián:

```csharp
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

![A szimbólum felsorolások](symbol_bullets.png)

## **Számozott lista létrehozása**

Használjon számozott listákat, ha az elemek sorrendje fontos. Állítsa be az [IBulletFormat.Type](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/type/) értékét a [BulletType.Numbered](https://reference.aspose.com/slides/hu/net/aspose.slides/bullettype/) típusra. A [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/numberedbulletstyle/) segítségével választhat számozási formátumot, vagy beállíthatja a [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/numberedbulletstartwith/) értéket, ha a lista 1‑nél más értékkel kell, hogy kezdődjön.

Az alábbi C# kód megmutatja, hogyan hozhatunk létre számozott listát egy dián:

```csharp
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

## **Képes felsorolójel létrehozása**

Az Aspose.Slides lehetővé teszi, hogy egy szabályos felsorolási szimbólumot egy képpel helyettesítsen. A képes felsorolások leginkább egyszerű, kis méretben is olvasható képekkel működnek, például ikonokkal vagy kis átlátszó PNG fájlokkal.

{{% alert color="primary" %}}
Ideális esetben, ha a szabályos felsorolási szimbólumot egy képpel szeretné helyettesíteni, egy egyszerű, átlátszó háttérrel rendelkező grafikát válasszon. Az ilyen képek jól működnek egyedi felsorolási szimbólumokként.

Ne feledje, hogy a kép nagyon kis méretre lesz leméretezve. Emiatt határozottan javasoljuk, hogy olyan képet válasszon, amely tiszta marad és vizuálisan hatékony, amikor listában felsorolási jelként használják.
{{% /alert %}}

A képes felsoroláshoz adjon képet a [Presentation.Images](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/images/) gyűjteményhez, és rendelje hozzá a visszaadott kép objektumot az [IBulletFormat.Picture](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/picture/) tulajdonsághoz. Mielőtt a képet hozzárendeli, állítsa be az [IBulletFormat.Type](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/type/) értékét a [BulletType.Picture](https://reference.aspose.com/slides/hu/net/aspose.slides/bullettype/) típusra.

Tegyük fel, hogy van egy „image.png” fájlunk:

![Kép a felsorolásokhoz](picture_for_bullets.png)

Az alábbi C# kód bemutatja, hogyan hozhatunk létre képes felsorolásokat egy dián:

```csharp
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

Használja az [IParagraphFormat.Depth](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/depth/) beállítást a listaelemek különböző szinteken való elhelyezéséhez. A 0. szint a legfelső szint, az 1. szint alatta van, és így tovább.

Az alábbi C# kód megmutatja, hogyan hozhatunk létre többszintű felsorolási listát:

```csharp
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

A lista formázásának módosításához egy meglévő bemutatóban nyissa meg a cél bekezdést, és frissítse annak [IParagraphFormat.Bullet](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/bullet/) beállításait. A listák létrehozásához használt ugyanazok a tulajdonságok használhatók a PPT, PPTX vagy ODP fájlból betöltött listák ellenőrzésére vagy módosítására.

Az alábbi C# kód megváltoztatja az első bekezdést egy szövegkeretben, hogy számozott lista stílust használjon:

```csharp
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

## **GYIK**

**Exportálhatók-e a felsorolási és számozott listák PDF vagy képek formátumba?**

Igen. Az Aspose.Slides megőrzi a lista formázását, ha a célformátum támogatja a megfelelő szövegelrendezést és felsorolási funkciókat.

**Szerkeszthetek-e listákat meglévő bemutatókban?**

Igen. Töltse be a bemutatót, érje el a cél bekezdést, vizsgálja vagy frissítse annak [IParagraphFormat.Bullet](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/bullet/) beállításait, majd mentse a bemutatót.

**Tartalmazhatnak-e a listák nem latin szöveget?**

Igen. A listaelemek szövege tartalmazhat Unicode karaktereket, így többenyelvű bemutatókban is létrehozhat listákat. Győződjön meg arról, hogy a bemutatóban használt betűtípusok támogatják a szükséges karaktereket.