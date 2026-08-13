---
title: "Vízjelek hozzáadása prezentációkhoz .NET-ben"
linktitle: "Vízjel"
type: docs
weight: 40
url: /hu/net/watermark/
keywords:
- "vízjel"
- "szöveges vízjel"
- "képes vízjel"
- "vízjel hozzáadása"
- "vízjel módosítása"
- "vízjel eltávolítása"
- "vízjel törlése"
- "vízjel hozzáadása PPT-hez"
- "vízjel hozzáadása PPTX-hez"
- "vízjel hozzáadása ODP-hez"
- "vízjel eltávolítása PPT-ből"
- "vízjel eltávolítása PPTX-ből"
- "vízjel eltávolítása ODP-ből"
- "vízjel törlése PPT-ből"
- "vízjel törlése PPTX-ből"
- "vízjel törlése ODP-ből"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Szöveges és képes vízjelek kezelése PowerPoint és OpenDocument prezentációkban .NET alatt, hogy vázlatot, bizalmas információt, szerzői jogot és egyebeket jelöljen."
---
## **Bevezetés**

**A vízjel** egy prezentációban szöveges vagy képes pecsét, amely egy diára vagy az összes diára vonatkozik. Általában a vízjelet arra használják, hogy jelezzék, hogy a prezentáció vázlat (például „Draft” vízjel), bizalmas információt tartalmaz („Confidential” vízjel), megmutassák, melyik vállalathoz tartozik („Company Name” vízjel), azonosítsák a szerzőt stb. A vízjel segít megelőzni a szerzői jogok megsértését, mert jelzi, hogy a prezentációt nem szabad másolni. A vízjelek a PowerPoint és az OpenDocument prezentációformátumokban egyaránt használhatók. Az Aspose.Slides-ben hozzáadhat vízjelet PowerPoint PPT, PPTX és OpenDocument ODP fájlformátumokhoz.

A [**Aspose.Slides**](https://products.aspose.com/slides/hu/net/) számos módot kínál vízjelek létrehozására PowerPoint vagy OpenDocument dokumentumokban, valamint azok megjelenésének és viselkedésének módosítására. A közös vonás, hogy szöveges vízjelek hozzáadásához a [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) interfészt kell használni, képes vízjelekhez pedig a [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe/) osztályt vagy egy alakzat kitöltését képpel. A `PictureFrame` megvalósítja az [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape) interfészt, így a alakzat objektum összes rugalmas beállítását ki lehet használni. Mivel az `ITextFrame` nem alakzat, és a beállításai korlátozottak, egy [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape) objektumba van csomagolva.

A vízjelet kétféleképpen lehet alkalmazni: egyetlen diára vagy az összes diához. A Dia Mester (Slide Master) használható a vízjel minden diára való alkalmazásához – a vízjelet a Slide Masterhez adjuk, ott teljesen megtervezzük, és minden diára kiterjesztjük, anélkül, hogy az egyedi diák vízjellel kapcsolatos módosítási engedélyét befolyásolná.

A vízjelet általában nem szabad szerkeszteni más felhasználók számára. A vízjel (pontosabban a vízjel szülőalakzata) szerkesztésének megakadályozásához az Aspose.Slides alakzatzárolási funkciót biztosít. Egy adott alakzat lezárható egy normál dián vagy a Slide Masteren. Ha a vízjel alakzat a Slide Masteren van lezárva, akkor minden diához lezárásra kerül.

Beállíthat nevet a vízjelnek, így a jövőben, ha törölni szeretné, a név alapján megtalálható a diák alakzatai között.

A vízjelet bármilyen módon megtervezheti; általában közös jellemzői vannak, például középre igazítás, forgatás, előre helyezés stb. Az alábbi példákban bemutatjuk, hogyan használhatók ezek.

## **Szöveges vízjel**

### **Szöveges vízjel hozzáadása egy diához**

A szöveges vízjel PPT, PPTX vagy ODP formátumban való hozzáadásához először alakzatot kell létrehozni a dián, majd ehhez a szövegkeretet hozzáadni. A szövegkeretet az [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe) interfész képviseli. Ez a típus nem öröklődik az [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/)‑tól, amely széles körű pozicionálási tulajdonságokat biztosít a vízjel rugalmas elhelyezéséhez. Ezért az [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe) objektum egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) objektumba van csomagolva. A vízjel szövegének alakzatra való felviteléhez használja az [AddTextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/methods/addtextframe) metódust, ahogyan az alább látható.

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// A vízjel hozzáadása a diára.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="Lásd még" %}} 
- [Hogyan használjuk a TextFrame osztályt?](/slides/hu/net/text-formatting/)
{{% /alert %}}

### **Szöveges vízjel hozzáadása egy teljes prezentációhoz**

Ha a teljes prezentációra (azaz egyszerre az összes diára) szeretne szöveges vízjelet hozzáadni, tegye azt a [MasterSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/masterslide/)‑hez. A logika ugyanaz, mint egyetlen diához való hozzáadásnál – hozzon létre egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) objektumot, majd az [AddTextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/methods/addtextframe) metódussal adja hozzá a vízjelet.

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// A vízjel hozzáadása a mester diához.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="Lásd még" %}} 
- [Hogyan használjuk a Slide Master-t?](/slides/hu/net/slide-master/)
{{% /alert %}}

### **A vízjel alakzat átlátszóságának beállítása**

Alapértelmezésben a téglalap alakzat kitöltési és vonalszínekkel van formázva. Ez azt jelenti, hogy a vízjel hozzáadása után szilárd háttérrel vagy kerettel jelenhet meg, ami elvonhatja a figyelmet a dia tartalmáról. A vízjel finom, a prezentáció vizuális tervezését ne befolyásoló megjelenéséhez a alakzat teljesen átlátszóvá tehető.

Az alábbi kódsorok átlátszóvá teszik az alakzatot, eltávolítva mind a kitöltés, mind a keretszínt:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **A szöveges vízjel betűtípusának beállítása**

Mielőtt a szöveges vízjelet a diára alkalmazná, fontos testre szabni a megjelenését, hogy harmonizáljon az általános dizájnnal. Megváltoztathatja a betűtípust és a méretet, hogy a vízjel jól olvasható és esztétikus legyen. A betűtípus testreszabása segíthet a márkaidentitás erősítésében vagy egyszerűen a prezentáció stílusához illeszkedhet.

Az alábbi kódrészlet bemutatja, hogyan állíthatja be a vízjel betűtípusát egy adott latin betűtípussal és megfelelő betűmagassággal:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **A vízjel szövegszínének beállítása**

Mielőtt alkalmazná a vízjelet, fontos, hogy a szövegszín megfelelően legyen beállítva, így jól illeszkedik a dia tartalmához anélkül, hogy elnyomná azt. A szín átlátszóságának (alpha) valamint a vörös, zöld és kék komponensek módosításával finom, félig átlátszó vízjelet hozhat létre, amely látható, de nem tolakodó. Ez a megközelítés segít a fő prezentációra koncentrálni, miközben megvédi a tartalmat.

A vízjel szövegszínének beállításához használja a következő kódot:

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **Szöveges vízjel középre helyezése**

A szöveges vízjel megfelelő középre helyezése jelentősen javíthatja a prezentáció esztétikáját, mivel a vízjel szimmetrikusan helyezkedik el a dia méreteitől függetlenül. Ez a megközelítés professzionális megjelenést kölcsönöz, miközben a vízjel nem zavarja a dia fő tartalmát.

Az alábbi kódrészlet bemutatja, hogyan számítható ki a dia középpontja, és hogyan helyezhető el a szöveges vízjel ennek megfelelően:

```cs
using System.Drawing;
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

Az alábbi kép mutatja a végső eredményt.

![A szöveges vízjel](text_watermark.png)

## **Képes vízjel**

### **Képes vízjel hozzáadása egy prezentációhoz**

Sok esetben a képes vízjel egyedi márkaelemet vagy vizuálisan vonzóbb alternatívát nyújt a szöveges vízjelhez képest. A vízjel hozzáadása előtt győződjön meg arról, hogy a képfájl rendelkezésre áll (például PNG a transparent háttérhez). Az alábbi példa bemutatja, hogyan töltsön be egy képet a fájlrendszerből, adja hozzá a prezentációhoz, majd alakzat kitöltési tulajdonságai segítségével alkalmazza vízjelként.

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **Vízjel zárolása a szerkesztéstől**

Ha szükséges megakadályozni a vízjel szerkesztését, használja az alakzat [IAutoShape.ShapeLock](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/properties/shapelock) tulajdonságát. Ezzel a tulajdonsággal megvédheti az alakzatot a kiválasztástól, átméretezéstől, áthelyezéstől, csoportosítástól, szöveg szerkesztésének tiltásától és sok mástól:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// Zárolja a vízjel alakzat módosítását.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **Vízjel előre hozása**

Az Aspose.Slides-ben az alakzatok Z-sorrendje a [IShapeCollection.Reorder](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/reorder/#reorder) metódussal állítható be. Ehhez a metódust a prezentáció diáink listájáról kell meghívni, és átadni az alakzat hivatkozását valamint a kívánt sorrendszámot. Így egy alakzat előre hozható a diához, vagy a háttérbe küldhető. Ez a funkció különösen hasznos, ha a vízjelet a prezentáció elé szeretné helyezni:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **Vízjel forgatásának beállítása**

A vízjel forgatásának módosítása jelentősen fokozhatja a prezentáció vizuális hatását és finomságát. Például egy átlós vízjel kevésbé zavaró, miközben hatékony védelmet nyújt a jogosulatlan felhasználás ellen. Az alábbi példa a dia mérete alapján számítja ki a megfelelő szöget, hogy a vízjel átlósan helyezkedjen el a dián. Ez a dinamikus számítás biztosítja, hogy a vízjel hatékony marad a különböző dia méretek esetén is.

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

SizeF slideSize = presentation.SlideSize.Size;

double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **Vízjel nevének beállítása**

Az Aspose.Slides lehetővé teszi egy alakzat nevének beállítását. A név használatával a jövőben elérhető a vízjel alakzata módosításra vagy törlésre. A vízjel alakzat nevének beállításához adja meg a [IAutoShape.Name](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/properties/name) tulajdonságot:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.Name = "watermark";
```

## **Vízjel eltávolítása**

A vízjel alakzat eltávolításához használja a [IAutoShape.Name](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/properties/name) tulajdonságot a dia alakzatai közül történő megtalálásához. Ezután adja át a vízjel alakzatot az [IShapeCollection.Remove](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/remove/) metódusnak:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(shape);
    }
}
```

## **Élő példa**

Érdemes megtekinteni az **Aspose.Slides ingyenes** [Add Watermark](https://products.aspose.app/slides/hu/watermark) és [Remove Watermark](https://products.aspose.app/slides/hu/watermark/remove-watermark) online eszközöket.

![Online eszközök vízjelek hozzáadásához és eltávolításához](online_tools.png)

## **GYIK**

### Mi a vízjel és miért kellene használnom?

A vízjel egy szöveges vagy képes átfedés, amelyet a diákra alkalmaznak az értelmi tulajdon védelme, a márkaerősség növelése vagy a prezentációk jogosulatlan használatának megakadályozása érdekében.

### Hozzáadhatok vízjelet az összes diához egy prezentációban?

Igen, az Aspose.Slides programozott módon képes vízjelet hozzáadni minden diához a prezentációban. Végigiterálhat az összes dián, és egyenként alkalmazhatja a vízjel beállításait.

### Hogyan állíthatom be a vízjel átlátszóságát?

Az átlátszóságot a forma kitöltési beállításainak ([FillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/fillformat/)) módosításával szabályozhatja. Ez biztosítja, hogy a vízjel finom legyen és ne vonja el a figyelmet a dia tartalmáról.

### Milyen képformátumok támogatottak a vízjelekhez?

Az Aspose.Slides különféle képformátumokat támogat, például PNG, JPEG, GIF, BMP, SVG és továbbiakat.

### Testreszabhatom a szöveges vízjel betűtípusát és stílusát?

Igen, választhat tetszőleges betűtípust, méretet és stílust, hogy illeszkedjen a prezentáció tervezéséhez és megőrizze a márka konzisztenciáját.

### Hogyan változtathatom meg a vízjel pozícióját vagy orientációját?

A pozíciót és orientációt programozottan módosíthatja az alakzat koordinátáinak, méretének és forgatási tulajdonságainak módosításával.