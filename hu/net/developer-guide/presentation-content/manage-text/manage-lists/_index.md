---
title: "Felsorolás- és számozott listák kezelése prezentációkban .NET-ben"
linktitle: "Listák kezelése"
type: docs
weight: 70
url: /hu/net/manage-lists/
aliases:
  - /net/manage-bullet-and-numbered-lists/
keywords:
  - "felsorolásjel"
  - "felsoroláslista"
  - "számozott lista"
  - "szimbólum felsorolásjel"
  - "képes felsorolásjel"
  - "egyéni felsorolásjel"
  - "többszintű lista"
  - "felsorolásjel létrehozása"
  - "felsorolásjel hozzáadása"
  - "lista hozzáadása"
  - "PowerPoint"
  - "OpenDocument"
  - "prezentáció"
  - ".NET"
  - "C#"
  - "Aspose.Slides"
description: "Ismerje meg, hogyan hozhat létre és formázhat felsorolás-, képes-, többszintű- és számozott listákat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for .NET használatával."
---
## **Áttekintés**

Az Aspose.Slides for .NET lehetővé teszi, hogy felsorolásjelekkel és számozott listákkal hozzon létre és formázzon PowerPoint és OpenDocument prezentációkat. A listaelem egy bekezdés, amelynek a felsorolásjel beállításait a bekezdés formátuma szabályozza.

Használja a [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/paragraphformat/) tulajdonságot a bekezdés szintű lista beállítások eléréséhez. A fő belépési pont a [IParagraphFormat.Bullet](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/bullet/), amely egy [IBulletFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/) objektumot ad vissza. Ezzel az objektummal beállíthatja a felsorolásjel típusát, szimbólumát, képét, színét, méretét, számozási stílusát és a kezdő számot.

Ez a cikk bemutatja, hogyan:

- hozzon létre egy felsoroláslistát egy egyéni szimbólummal
- hozzon létre képes felsorolásjelet
- hozzon létre többszintű listát a bekezdés mélységének beállításával
- hozzon létre számozott listát
- vizsgálja meg és módosítsa a lista formázását egy meglévő prezentációban

## **Felsoroláslista létrehozása**

A felsoroláslista létrehozásához adjon [IParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/) objektumokat egy [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/)-hez, és állítsa be a [IBulletFormat.Type](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/type/) értékét a [BulletType.Symbol](https://reference.aspose.com/slides/hu/net/aspose.slides/bullettype/) típusra. Ezután beállíthatja a [IBulletFormat.Char](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/color/) és [IBulletFormat.Height](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/height/) értékeket a felsorolásjel megjelenésének vezérléséhez.

Az alábbi C# kód bemutatja, hogyan hozhat létre felsoroláslistát egy dián:

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

![A szimbólum felsorolásjelek](symbol_bullets.png)

## **Számozott lista létrehozása**

Használjon számozott listákat, ha az elemek sorrendje fontos. Állítsa be a [IBulletFormat.Type](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/type/) értékét a [BulletType.Numbered](https://reference.aspose.com/slides/hu/net/aspose.slides/bullettype/) típusra. Választhat számozási formátumot a [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/numberedbulletstyle/) segítségével, vagy megadhatja a [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/numberedbulletstartwith/) értékét, ha a lista 1 helyett más értékkel kezdődjön.

Az alábbi C# kód bemutatja, hogyan hozhat létre számozott listát egy dián:

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

![A számozott felsorolásjelek](numbered_bullets.png)

## **Képes felsorolásjel létrehozása**

Az Aspose.Slides lehetővé teszi, hogy egy szabályos felsorolásjel helyett képet használjon. A képes felsorolásjelek leginkább egyszerű képekkel működnek, amelyek kis méretben is olvashatóak, például ikonokkal vagy kis átlátszó PNG fájlokkal.

{{% alert color="primary" %}}
Ideális esetben, ha a szabályos felsorolásjelet képpel szeretnéd helyettesíteni, a legjobb, ha egy egyszerű, átlátszó háttérrel rendelkező grafikát választasz. Az ilyen képek jól működnek egyéni felsorolásjel szimbólumként.

Ne feledd, hogy a képet nagyon kis méretre lesz méretezve. Emiatt erősen ajánljuk, hogy olyan képet válassz, amely kicsinyítés után is tiszta és vizuálisan hatékony marad a lista felsorolásjelének.
{{% /alert %}}

Képes felsorolásjel létrehozásához adjon egy képet a [Presentation.Images](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/images/) gyűjteményhez, és rendelje a visszaadott képobjektumot a [IBulletFormat.Picture](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/picture/) tulajdonsághoz. A [IBulletFormat.Type](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/type/) értékét állítsa a [BulletType.Picture](https://reference.aspose.com/slides/hu/net/aspose.slides/bullettype/) típusra a kép hozzárendelése előtt.

Tegyük fel, hogy van egy „image.png” nevű fájlunk:

![Kép a felsorolásjelekhez](picture_for_bullets.png)

Az alábbi C# kód bemutatja, hogyan hozhat létre képes felsorolásjeleket egy dián:

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

![A képes felsorolásjelek](picture_bullets.png)

## **Többszintű lista létrehozása**

Használja a [IParagraphFormat.Depth](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/depth/) tulajdonságot a listaelemek különböző szintekre helyezéséhez. A 0. szint a legfelső szint, az 1. szint alatta, és így tovább.

Az alábbi C# kód bemutatja, hogyan hozhat létre többszintű felsoroláslistát:

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

A lista formázásának módosításához egy meglévő prezentációban érje el a cél bekezdést, és frissítse annak a [IParagraphFormat.Bullet](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/bullet/) beállításait. A listák létrehozásához használt ugyanazok a tulajdonságok használhatók a PPT, PPTX vagy ODP fájlból betöltött listák megtekintésére vagy módosítására.

Az alábbi C# kód a szövegkeret első bekezdését számozott lista stílusra állítja:

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

**Exportálhatók a felsorolás- és számozott listák PDF vagy képek formátumba?**

Igen. Az Aspose.Slides megőrzi a lista formázását, ha a célformátum támogatja a megfelelő szövegelrendezést és felsorolásjel funkciókat.

**Szerkeszthetek listákat meglévő prezentációkban?**

Igen. Töltse be a prezentációt, érje el a cél bekezdést, vizsgálja meg vagy frissítse annak a [IParagraphFormat.Bullet](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/bullet/) beállításait, majd mentse a prezentációt.

**Tartalmazhatnak a listák nem latin szöveget?**

Igen. A listaelemek szövege Unicode karaktereket is tartalmazhat, így többnyelvű prezentációkban is létrehozhat listákat. Győződjön meg róla, hogy a prezentációban használt betűtípusok támogatják a szükséges karaktereket.