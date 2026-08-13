---
title: Felsorolásjelek és számozott listák kezelése bemutatókban .NET-ben
linktitle: Listák kezelése
type: docs
weight: 70
url: /hu/net/manage-lists/
aliases:
  - /net/manage-bullet-and-numbered-lists/
keywords:
- jelölő
- felsoroláslista
- számozott lista
- szimbólum jelölő
- képes jelölő
- egyedi jelölő
- többszintű lista
- jelölő létrehozása
- jelölő hozzáadása
- lista hozzáadása
- PowerPoint
- OpenDocument
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és formázhat felsorolásjelek, képes, többszintű és számozott listákat PowerPoint és OpenDocument bemutatókban az Aspose.Slides for .NET használatával."
---
## **Áttekintés**

Aspose.Slides for .NET lehetővé teszi, hogy felsorolásjelekkel és számozott listákkal készítsen és formázzon PowerPoint és OpenDocument bemutatókat. Egy listaelem egy bekezdés, amelynek a jelölőbeállításait a bekezdésformátum vezérli.

Használja az [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/paragraphformat/) property-t a bekezdés‑szintű lista beállítások eléréséhez. A fő belépési pont az [IParagraphFormat.Bullet](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/bullet/), amely egy [IBulletFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/) objektumot ad vissza. Ezzel az objektummal beállíthatja a jelölő típusát, szimbólumát, képét, színét, méretét, számozási stílusát és kezdő számot.

Ez a cikk bemutatja, hogyan:

- létrehozzon egy egyedi szimbólummal ellátott felsorolásjelet tartalmazó listát
- létrehozzon egy képes jelölőt
- létrehozzon többszintű listát a bekezdés mélységének beállításával
- létrehozzon számozott listát
- ellenőrizze és módosítsa egy meglévő bemutató listaformázását

## **Felsorolásjeles lista létrehozása**

Felsorolásjeles lista létrehozásához adjon [IParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/) objektumokat egy [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) elemhez, és állítsa be az [IBulletFormat.Type](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/type/) értékét a [BulletType.Symbol](https://reference.aspose.com/slides/hu/net/aspose.slides/bullettype/) értékre. Ezután beállíthatja az [IBulletFormat.Char](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/color/), és [IBulletFormat.Height](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/height/) értékeket a jelölő megjelenésének szabályozásához.

The following C# code demonstrates how to create a bulleted list in a slide:

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

![A szimbólum jelölők](symbol_bullets.png)

## **Számozott lista létrehozása**

Számozott listákat akkor használjon, amikor az elemek sorrendje fontos. Állítsa be az [IBulletFormat.Type](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/type/) értékét a [BulletType.Numbered](https://reference.aspose.com/slides/hu/net/aspose.slides/bullettype/) értékre. A [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/numberedbulletstyle/) segítségével választhat számozási formátumot, vagy beállíthatja az [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/numberedbulletstartwith/) értéket, ha a lista 1‑től eltérő számmal kell induljon.

The following C# code shows how to create a numbered list in a slide:

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

![A számozott jelölők](numbered_bullets.png)

## **Képes jelölő létrehozása**

Az Aspose.Slides lehetővé teszi, hogy egy szabályos jelölő szimbólumát képpel helyettesítse. A képes jelölők a legegyszerűbb képekkel működnek a legjobban, amelyek kis méretben is olvashatóak, például ikonok vagy kis átlátható PNG fájlok.

 {{% alert color="info" %}}
Ideálisan, ha a szabályos jelölő szimbólumát képpel szeretné helyettesíteni, a legjobb egy egyszerű, átlátszó háttérrel rendelkező grafikát választani. Az ilyen képek jól működnek egyedi jelölőszimbólumokként.
Tartsa szem előtt, hogy a kép nagyon kicsire lesz méretezve. Emiatt erősen ajánljuk, hogy olyan képet válasszon, amely tiszta és vizuálisan hatékony marad, amikor listajelölőként használják.
{{% /alert %}}

A képes jelölő létrehozásához adjon képet a [Presentation.Images](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/images/) gyűjteményhez, és rendelje hozzá a visszaadott képobjektumot az [IBulletFormat.Picture](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/picture/) tulajdonsághoz. A képet hozzárendelése előtt állítsa be az [IBulletFormat.Type](https://reference.aspose.com/slides/hu/net/aspose.slides/ibulletformat/type/) értékét a [BulletType.Picture](https://reference.aspose.com/slides/hu/net/aspose.slides/bullettype/) értékre.

Legyen például egy "image.png" fájlunk:

![Kép a jelölőkhöz](picture_for_bullets.png)

The following C# code shows how to create picture bullets in a slide:

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

![A képes jelölők](picture_bullets.png)

## **Többszintű lista létrehozása**

A listaelemek különböző szintekre helyezéséhez használja az [IParagraphFormat.Depth](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/depth/) tulajdonságot. A 0‑szint a legfelső szint, az 1‑szint alatta helyezkedik el, stb.

The following C# code shows how to create a multilevel bulleted list:

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

Egy meglévő bemutató listaformázásának módosításához érje el a cél bekezdést, és frissítse annak [IParagraphFormat.Bullet](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/bullet/) beállításait. A listák létrehozásához használt ugyanazok a tulajdonságok használhatók a PPT, PPTX vagy ODP fájlból betöltött listák ellenőrzésére vagy módosítására.

The following C# code changes the first paragraph in a text frame to use a numbered list style:

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

## **FAQ**

### Exportálhatók-e a felsorolásjelekkel és számozott listákkal PDF‑be vagy képekké?

Igen. Az Aspose.Slides megőrzi a listaformázást, ha a célformátum támogatja a megfelelő szövegelrendezést és jelölőjellemzőket.

### Szerkeszthetek‑e listákat meglévő bemutatókban?

Igen. Töltse be a bemutatót, érje el a cél bekezdést, ellenőrizze vagy frissítse annak [IParagraphFormat.Bullet](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/bullet/) beállításait, majd mentse a bemutatót.

### Tartalmazhatnak‑e a listák nem latin szöveget?

Igen. A listaelemek szövege tartalmazhat Unicode karaktereket, így többnyelvű bemutatókban is létrehozhat listákat. Győződjön meg arról, hogy a bemutatóban használt betűtípusok támogatják a szükséges karaktereket.