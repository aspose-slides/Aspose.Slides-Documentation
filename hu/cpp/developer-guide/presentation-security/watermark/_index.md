---
title: Vízjelek hozzáadása prezentációkhoz C++-ban
linktitle: Vízjel
type: docs
weight: 40
url: /hu/cpp/watermark/
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
- prezentáció
- C++
- Aspose.Slides
description: "Kezelje a szöveges és képes vízjeleket PowerPoint és OpenDocument prezentációkban C++-ban, hogy vázlatot, bizalmas információkat, szerzői jogi védelmet és egyebeket jelezzen."
---
## **Bevezetés**

**A vízjel** egy prezentációban egy szöveges vagy képes pecsét, amelyet egy dián vagy az összes prezentációs dián alkalmaznak. Általában a vízjelet arra használják, hogy jelezzék, hogy a prezentáció vázlat (pl. „Draft” vízjel), hogy bizalmas információkat tartalmaz (pl. „Confidential” vízjel), megadja, melyik céghez tartozik (pl. „Company Name” vízjel), az előadó azonosítására stb. A vízjel segít megelőzni a szerzői jogi jogsértéseket, mivel jelzi, hogy a prezentációt nem szabad másolni. A vízjelek a PowerPoint és az OpenOffice prezentációs formátumokban egyaránt használatosak. Az Aspose.Slides segítségével vízjelet adhat hozzá a PowerPoint PPT, PPTX és az OpenOffice ODP fájlformátumokhoz.

Az [**Aspose.Slides**](https://products.aspose.com/slides/hu/cpp/) többféle módot kínál a vízjelek létrehozására PowerPoint vagy OpenOffice dokumentumokban, valamint a tervezésük és viselkedésük módosítására. A közös szempont, hogy szöveges vízjelek hozzáadásához használja az [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) interfészt, képes vízjelekhez pedig a [PictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pictureframe/) osztályt, vagy egy alakzat kitöltését képpel. A `PictureFrame` a [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/) interfészt valósítja meg, így az alakzat objektum összes rugalmas beállítását használhatja. Mivel az `ITextFrame` nem alakzat és beállításai korlátozottak, egy [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/) objektumba van csomagolva.

Két módja van a vízjel alkalmazásának: egyetlen diára vagy az összes diára. A Dia mester (Slide Master) használható a vízjel az összes dián való alkalmazásához – a vízjel a Dia mesterhez kerül hozzáadásra, ott teljesen megtervezésre, és minden diára alkalmazásra kerül anélkül, hogy befolyásolná a vízjel egyedi diákon való módosításának lehetőségét.

A vízjelet általában nem lehet szerkeszteni más felhasználók számára. A vízjel (pontosabban a vízjel szülő alakzata) szerkesztésének megakadályozásához az Aspose.Slides alakzat zárolási funkciót biztosít. Egy adott alakzat lezárható egy normál dián vagy a Dia mesteren. Ha a vízjel alakzat a Dia mesteren zárolva van, minden prezentációs dián le lesz zárolva.

Beállíthat nevet a vízjelnek, hogy a jövőben, ha törölni szeretné, megtalálja a diák alakzatai között név alapján.

A vízjelet bármilyen módon megtervezheti; azonban általában közös jellemzőik vannak, mint a középre igazítás, forgatás, előre helyezés stb. Az alábbi példákban bemutatjuk, hogyan használhatók ezek.

## **Szöveges vízjel**

### **Szöveges vízjel hozzáadása egy diára**

A szöveges vízjel hozzáadásához PPT, PPTX vagy ODP formátumban először egy alakzatot kell hozzáadni a diához, majd egy szövegkeretet ehhez az alakzathoz. A szövegkeret a [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) interfész által képviselt. Ez a típus nem öröklődik a [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/)‑től, amely széles körű tulajdonságokkal rendelkezik a vízjel rugalmas pozicionálásához. Ezért a [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) objektum egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) objektumba van csomagolva. A vízjel szövegének hozzáadásához használja a [AddTextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/addtextframe/) metódust az alábbiak szerint.

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="Lásd még" %}} 
- [A TextFrame osztály használata](/slides/hu/cpp/text-formatting/)
{{% /alert %}}

### **Szöveges vízjel hozzáadása egy prezentációhoz**

Ha egy szöveges vízjelet szeretne hozzáadni az egész prezentációhoz (azaz egyszerre az összes diához), adja hozzá a [MasterSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/masterslide/)-hez. A többi logika megegyezik az egyedi diára való vízjel hozzáadásával – hozzon létre egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) objektumot, majd adja hozzá a vízjelet a [AddTextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/addtextframe/) metódussal.

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="Lásd még" %}} 
- [A Dia mester használata](/slides/hu/cpp/slide-master/)
{{% /alert %}}

### **A vízjel alakzat átlátszóságának beállítása**

Alapértelmezés szerint a téglalap alakzat kitöltési és vonalszínekhez van stilizálva. A következő kódsorok teszik az alakzatot átlátszóvá.

```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **A szöveges vízjel betűtípusának beállítása**

Az alábbiak szerint módosíthatja a szöveges vízjel betűtípusát.

```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **A vízjel szövegszínének beállítása**

A vízjel szövegszínének beállításához használja ezt a kódot:

```cpp
auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **Szöveges vízjel középre helyezése**

Lehetséges a vízjelet középre helyezni egy dián, ehhez tegye a következőt:

```cpp
auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```

Az alábbi kép mutatja a végső eredményt.

![A szöveges vízjel](text_watermark.png)

## **Képes vízjel**

### **Képes vízjel hozzáadása egy prezentációhoz**

Képes vízjel hozzáadásához egy prezentációs diára a következőket teheti:

```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **Vízjel szerkesztésének letiltása**

Ha szükséges megakadályozni a vízjel szerkesztését, használja a [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/get_autoshapelock/) metódust az alakzaton. Ezzel a tulajdonsággal megvédheti az alakzatot a kiválasztástól, átméretezéstől, áthelyezéstől, más elemekkel való csoportosítástól, a szöveg szerkesztésétől és még sok mást:

```cpp
// A vízjel alakzatot a módosítástól zárolja
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```

## **Vízjel előre hozatala**

Az Aspose.Slides-ben az alakzatok Z-sorrendje a [IShapeCollection::Reorder](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/reorder/) metódussal állítható be. Ehhez hívja meg ezt a metódust a prezentáció diáinak listájáról, és adja át az alakzat hivatkozását és a kívánt sorrendszámot. Így egy alakzatot előre hozhat vagy hátra küldhet a dián. Ez a funkció különösen hasznos, ha a vízjelet a prezentáció elejére szeretné helyezni:

```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **Vízjel forgatásának beállítása**

Az alábbi kódrészlet mutatja, hogyan állítható be a vízjel forgatása, hogy átlósan helyezkedjen el a dián:

```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **Vízjel nevének beállítása**

Az Aspose.Slides lehetővé teszi egy alakzat nevének beállítását. A forma nevét felhasználva a jövőben elérheti, módosíthatja vagy törölheti azt. A vízjel alakzat nevének beállításához rendelje a [IAutoShape::set_Name](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/set_name/) metódusnak:

```cpp
watermarkShape->set_Name(u"watermark");
```

## **Vízjel eltávolítása**

A vízjel alakzat eltávolításához használja a [IAutoShape::get_Name](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_name/) metódust a diák alakzatai között való megtalálásához. Ezután adja át a vízjel alakzatot a [IShapeCollection::Remove](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/remove/) metódusnak:

```cpp
auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(watermarkShape);
    }
}
```

## **Élő példa**

Érdemes kipróbálni az **Aspose.Slides free** [Vízjel hozzáadása](https://products.aspose.app/slides/hu/watermark) és [Vízjel eltávolítása](https://products.aspose.app/slides/hu/watermark/remove-watermark) online eszközöket.

![Online eszközök a vízjelek hozzáadásához és eltávolításához](online_tools.png)

## **GYIK**

**Mi az a vízjel és miért kellene használni?**

A vízjel egy szöveges vagy képes átfedés, amely a diákon kerül alkalmazásra, és segít megvédeni a szellemi tulajdont, erősíti a márka felismerhetőségét vagy megakadályozza a prezentációk jogosulatlan használatát.

**Hozzáadhatok vízjelet az összes diához egy prezentációban?**

Igen, az Aspose.Slides programozottan képes vízjelet hozzáadni minden diához egy prezentációban. Végigiterálhat az összes dián, és egyenként alkalmazhatja a vízjel beállításait.

**Hogyan állíthatom be a vízjel átlátszóságát?**

Az átlátszóságot a forma kitöltési beállításainak ([FillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/get_fillformat/)) módosításával állíthatja be. Ez biztosítja, hogy a vízjel finom legyen, és ne vonja el a figyelmet a dia tartalmáról.

**Milyen képformátumok támogatottak a vízjelekhez?**

Az Aspose.Slides több képformátumot támogat, például PNG, JPEG, GIF, BMP, SVG és még sok más.

**Testreszabhatom a szöveges vízjel betűtípusát és stílusát?**

Igen, bármilyen betűtípust, méretet és stílust választhat, hogy illeszkedjen a prezentációja tervezéséhez és a márka konzisztenciáját megőrizze.

**Hogyan változtathatom meg a vízjel pozícióját vagy tájolását?**

Programozottan a forma koordinátáit, méretét és forgatási tulajdonságait módosítva állíthatja be a vízjel pozícióját és tájolását.