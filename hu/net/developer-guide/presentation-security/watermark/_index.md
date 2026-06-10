---
title: Vízjelek hozzáadása bemutatókhoz .NET-ben
linktitle: Vízjel
type: docs
weight: 40
url: /hu/net/watermark/
keywords:
- vízjel
- szöveges vízjel
- képes vízjel
- vízjel hozzáadása
- vízjel módosítása
- vízjel eltávolítása
- vízjel törlése
- vízjel hozzáadása PPT-hez
- vízjel hozzáadása PPTX-hez
- vízjel hozzáadása ODP-hez
- vízjel eltávolítása PPT-ből
- vízjel eltávolítása PPTX-ből
- vízjel eltávolítása ODP-ből
- vízjel törlése PPT-ből
- vízjel törlése PPTX-ből
- vízjel törlése ODP-ből
- PowerPoint
- OpenDocument
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Kezelje a szöveges és képes vízjeleket PowerPoint és OpenDocument bemutatókban .NET környezetben, hogy jelezzenek vázlatot, bizalmas információkat, szerzői jogot és egyebeket."
---
## **Bevezetés**

**A vízjel** egy bemutatóban egy szöveges vagy képes bélyeg, amely egy dián vagy az összes diámon használható. Általában akkor használják, ha a bemutató vázlat (például „Draft” vízjel), bizalmas információkat tartalmaz (például „Confidential” vízjel), meg kell határozni, melyik céghez tartozik (például „Company Name” vízjel), vagy a szerzőt szeretnénk azonosítani. A vízjel segít megelőzni a szerzői jogi jogsértéseket, mert jelzi, hogy a bemutatót nem szabad másolni. A vízjelek a PowerPoint és az OpenDocument bemutatóformátumokban egyaránt használhatók. Az Aspose.Slides segítségével vízjelet adhat hozzá a PowerPoint PPT, PPTX és az OpenDocument ODP fájlformátumokhoz.

A [**Aspose.Slides**](https://products.aspose.com/slides/hu/net/) különféle módokat biztosít a vízjelek létrehozására PowerPoint vagy OpenDocument dokumentumokban, valamint a megjelenésük és viselkedésük testreszabására. A közös vonás, hogy szöveges vízjel hozzáadásához a [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) interfészt kell használni, képes vízjelhez pedig a [PictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/pictureframe/) osztályt vagy egy alakzat kitöltését képpel. A `PictureFrame` a [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape) interfészt valósítja meg, így a formaobjektum összes rugalmas beállítását használhatja. Mivel az `ITextFrame` nem alakzat, korlátozottabb beállításokkal rendelkezik, ezért egy [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape) objektumba van csomagolva.

Két módon lehet vízjelet alkalmazni: egyetlen diára vagy az összes diához. A Slide Master használható a vízjel minden diára való alkalmazásához – a vízjelet a Slide Masterhez adjuk hozzá, ott teljesen megtervezzük, és minden diára alkalmazzuk anélkül, hogy befolyásolná a vízjel egyedi diákon való módosítási engedélyét.

A vízjelet általában nem szerkeszthetővé teszik más felhasználók számára. A vízjel (vagy inkább a vízjel szülő alakzata) szerkesztésének megakadályozására az Aspose.Slides alakzatzárolási funkciót kínál. Egy adott alakzatot lehet lezárni egy normál dián vagy egy Slide Masteren. Amikor a vízjel alakzat a Slide Masteren van lezárva, minden diához lezárva lesz.

Beállíthat egy nevet a vízjelnek, hogy a jövőben, ha törölni szeretné, a név alapján megtalálja a dia alakzatai között.

A vízjelet bármilyen módon megtervezheti; a gyakorlatban azonban a vízjeleknek gyakran közös jellemzői vannak, mint például a középre igazítás, forgatás, előre helyezés stb. Az alábbi példákban ezt fogjuk szemléltetni.

## **Szöveges vízjel**

### **Szöveges vízjel hozzáadása egy diához**

Szöveges vízjel PPT, PPTX vagy ODP formátumban történő hozzáadásához először alakzatot adjon a diához, majd egy szövegkeretet ehhez az alakzathoz. A szövegkeretet a [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe) interfész képviseli. Ez a típus nem örököl a [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/)‑től, amely széles tulajdonságkészlettel rendelkezik a vízjel rugalmas elhelyezéséhez. Ezért a [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe) objektum egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) objektumba van becsomagolva. A vízjel szövegének alakzathoz való hozzáadásához használja a [AddTextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/methods/addtextframe) metódust az alábbiak szerint.

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Vízjelet ad a diára.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="Lásd még" %}} 
- [Hogyan használjuk a TextFrame osztályt?](/slides/hu/net/text-formatting/)
{{% /alert %}}

### **Szöveges vízjel hozzáadása egy teljes bemutatóhoz**

Ha egy szöveges vízjelet szeretne hozzáadni a teljes bemutatóhoz (azaz egyszerre az összes diára), adja hozzá a [MasterSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/masterslide/)-hez. A logika megegyezik a egyetlen diára történő vízjel hozzáadásával – hozzon létre egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) objektumot, majd a [AddTextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/methods/addtextframe) metódussal adja hozzá a vízjelet.

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// Vízjelet ad a master diára.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="Lásd még" %}} 
- [Hogyan használjuk a Slide Master-t?](/slides/hu/net/slide-master/)
{{% /alert %}}

### **A vízjel alakzat átlátszóságának beállítása**

Alapértelmezés szerint a téglalap alakzat kitöltési és vonal színekkel van formázva. Ez azt jelenti, hogy a vízjel hozzáadása után szilárd háttérrel vagy kerettel jelenhet meg, ami elvonhatja a figyelmet a dia tartalmáról. A vízjel finom, visszafogott megjelenéséhez teljesen átlátszóvá teheti az alakzatot.

Az alábbi kódrészlet eltávolítja mind a kitöltés, mind a keret színét, így átlátszóvá teszi az alakzatot:

```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **Betűtípus beállítása egy szöveges vízjelhez**

A szöveges vízjel diára történő alkalmazása előtt fontos testre szabni a megjelenését, hogy harmonizáljon a teljes dizájnnal. Megváltoztathatja a betűtípus típusát és méretét, hogy a vízjel jól olvasható és esztétikus legyen. A betűtípus testreszabása segíthet a márkaazonosító erősítésében vagy egyszerűen a bemutató stílusának illesztésében.

Az alábbi kódrészlet egy speciális latin betűtípust választ, és megfelelő betűmagasságot állít be a vízjelhez:

```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **A vízjel szövegszínének beállítása**

A vízjel alkalmazása előtt fontos, hogy a szövegszín megfelelően legyen beállítva, hogy harmonizáljon a dia tartalmával anélkül, hogy elnyomná azt. A szín átlátszóságának (alfa) valamint a vörös, zöld és kék komponensek módosításával finom, félig átlátszó vízjelet hozhat létre, amely látható, de nem tolakodó. Ez a megközelítés segít a fő bemutató fókuszának megtartásában, miközben mégis védi a tartalmat.

A vízjel szövegének színét az alábbi kóddal állíthatja be:

```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **Szöveges vízjel középre helyezése**

A szöveges vízjel megfelelő középre helyezése jelentősen javíthatja a bemutató esztétikáját, mivel a vízjel szimmetrikusan helyezkedik el, függetlenül a dia méreteitől. Ez a megközelítés professzionális megjelenést kölcsönöz a diáknak, és biztosítja, hogy a vízjel ne zavarja meg a fő tartalmat.

Az alábbi kódrészlet kiszámítja a dia középpontját, és ennek megfelelően helyezi el a szöveges vízjelet:

```cs
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

### **Képes vízjel hozzáadása egy bemutatóhoz**

Sok esetben a képes vízjel egyedi márkanevet vagy vizuálisan vonzóbb alternatívát nyújt a szöveges vízjel helyett. A vízjel hozzáadása előtt győződjön meg arról, hogy a képfájl elérhető (például PNG a transparenciához). Az alábbi példa bemutatja, hogyan töltsön be egy képet a fájlrendszerből, adja hozzá a bemutatóhoz, majd alkalmazza vízjelként az alakzat kitöltési tulajdonságaival.

```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **Vízjel szerkesztés elleni zárolása**

Ha meg kell akadályozni a vízjel szerkesztését, használja a [IAutoShape.ShapeLock](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/properties/shapelock) tulajdonságot az alakzaton. Ezzel a tulajdonsággal megvédheti az alakzatot a kiválasztástól, átméretezéstől, áthelyezéstől, más elemekkel való csoportosítástól, a szöveg szerkesztésének zárolásától és még sok mástól:

```cs
// Zárolja a vízjel alakzatot a módosítástól.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **Vízjel előre hozása**

Az Aspose.Slides-ben az alakzatok Z-sorrendjét a [IShapeCollection.Reorder](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/reorder/#reorder) metódussal állíthatja be. Ehhez a metódust a bemutató diái listájáról kell meghívni, és átadni az alakzat referenciáját és a kívánt sorrend számmát. Így egy alakzat előre hozható vagy hátra küldhető a dián. Ez a funkció különösen hasznos, ha a vízjelet a bemutató előterébe szeretné helyezni:

```cs
int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **Vízjel forgatásának beállítása**

A vízjel forgatásának beállítása jelentősen fokozhatja a bemutató vizuális hatását és finomságát. Például egy átlós vízjel kevésbé tolakodó lehet, miközben erős védelmet nyújt a jogosulatlan felhasználás ellen. Az alábbi példa a dia méretei alapján számítja ki a megfelelő szöget, hogy a vízjel átlósan helyezkedjen el a dián. Ez a dinamikus számítás biztosítja, hogy a vízjel hatékony maradjon a különböző dia méretek esetén is.

```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **Vízjel nevének beállítása**

Az Aspose.Slides lehetővé teszi egy alakzat nevének beállítását. A forma név használatával a jövőben könnyen megtalálhatja, módosíthatja vagy törölheti azt. A vízjel alakzat nevének beállításához rendelje hozzá a [IAutoShape.Name](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/properties/name) tulajdonságot:

```cs
watermarkShape.Name = "watermark";
```

## **Vízjel eltávolítása**

A vízjel alakzat eltávolításához használja a [IAutoShape.Name](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/properties/name) tulajdonságot a dia alakzatai között való megtaláláshoz. Ezután adja át a vízjel alakzatot a [IShapeCollection.Remove](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/remove/) metódusnak:

```cs
List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(watermarkShape);
    }
}
```

## **Élő példa**

Érdemes kipróbálni az **Aspose.Slides ingyenes** [Vízjel hozzáadása](https://products.aspose.app/slides/hu/watermark) és [Vízjel eltávolítása](https://products.aspose.app/slides/hu/watermark/remove-watermark) online eszközeit.

![Online eszközök a vízjelek hozzáadásához és eltávolításához](online_tools.png)

## **GYIK**

**Mi az a vízjel, és miért kellene használnom?**

A vízjel egy szöveges vagy képes átfedés, amelyet a diákkra helyeznek, hogy megvédje a szellemi tulajdont, erősítse a márka felismerhetőségét, vagy megakadályozza a bemutatók jogosulatlan használatát.

**Hozzáadhatok vízjelet az összes diához egy bemutatóban?**

Igen, az Aspose.Slides programozottan képes vízjelet hozzáadni minden diához egy bemutatóban. A diákon iterálva egyenként alkalmazhatja a vízjel beállításait.

**Hogyan állíthatom be a vízjel átlátszóságát?**

A vízjel átlátszóságát a forma kitöltési beállításainak ([FillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/fillformat/)) módosításával szabályozhatja. Így a vízjel finom marad, és nem vonja el a figyelmet a dia tartalmáról.

**Milyen képformátumok támogatottak a vízjelekhez?**

Az Aspose.Slides számos képformátumot támogat, például PNG, JPEG, GIF, BMP, SVG és még sok más.

**Testreszabhatom a szöveges vízjel betűtípusát és stílusát?**

Igen, választania bármilyen betűtípust, méretet és stílust, amely illeszkedik a bemutató tervezéséhez és fenntartja a márka konzisztenciáját.

**Hogyan változtathatom meg a vízjel pozícióját vagy tájolását?**

Programozottan módosíthatja a vízjel pozícióját és tájolását az alakzat koordinátáinak, méretének és forgatás tulajdonságainak beállításával.