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
description: "Kezelje a szöveges és képes vízjeleket PowerPoint és OpenDocument prezentációkban C++-ban, hogy jelezze a vázlatot, bizalmas információkat, szerzői jogokat és egyebeket."
---
## **Bevezetés**

**A vízjel** egy prezentációban szöveg‑ vagy képmintás pecsét, amelyet egy diára vagy az összes diához helyeznek. Általában a vízjelet arra használják, hogy jelezzék, hogy a prezentáció vázlat (pl. „Draft” vízjel), hogy bizalmas információkat tartalmaz (pl. „Confidential” vízjel), hogy melyik vállalathoz tartozik (pl. „Company Name” vízjel), vagy hogy azonosítsák a szerzőt, stb. A vízjel segít megelőzni a szerzői jogok megsértését, mivel jelzi, hogy a prezentációt nem szabad másolni. A vízjeleket mind a PowerPoint, mind az OpenOffice prezentációformátumokban használják. Az Aspose.Slides‑ben különböző formátumok (PPT, PPTX, ODP) esetén adhatunk hozzá vízjelet.

A [**Aspose.Slides**](https://products.aspose.com/slides/hu/cpp/) számos módot kínál a vízjelek létrehozására PowerPoint vagy OpenOffice dokumentumokban, valamint azok megjelenésének és viselkedésének módosítására. A közös pont, hogy szöveges vízjelek hozzáadásához a [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) interfészt kell használni, képi vízjelekhez pedig a [PictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pictureframe/) osztályt vagy egy alakzat képkitöltését. A `PictureFrame` implementálja a [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/) interfészt, lehetővé téve az alakzat összes rugalmas beállításának használatát. Mivel az `ITextFrame` nem alakzat, ezért egy [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/) objektumba van ágyazva.

Két módon alkalmazható a vízjel: egyetlen diára vagy az összes diára. A Diamester (Slide Master) használható a vízjel minden diához való hozzáadására – a vízjelet a Diamesterhez adjuk, ott teljesen megtervezzük, és az összes diára alkalmazzuk anélkül, hogy korlátoznánk a vízjel egyedi diákon történő módosításának lehetőségét.

A vízjelet általában nem szerkeszthetőnek tekintik más felhasználók számára. A vízjel (pontosabban a vízjel szülő alakzata) szerkesztésének megakadályozásához az Aspose.Slides alakzatzáró funkciót biztosít. Egy specifikus alakzat lezárható egy normál dián vagy a Diamesteren. Ha a vízjel alakzata a Diamesteren van lezárva, akkor az minden diához le lesz zárva.

A vízjelnek adhatunk nevet, így a későbbi törlés vagy módosítás esetén név alapján megtalálhatjuk a diák alakzatai között.

A vízjelet bármilyen módon megtervezhetjük; általában középre igazítás, forgatás, előtér helyzet stb. közös jellemzőkkel rendelkeznek. Az alábbi példákban ezt is bemutatjuk.

## **Szöveges vízjel**

### **Szöveges vízjel hozzáadása egy diára**

A szöveges vízjel felvételéhez PPT, PPTX vagy ODP formátumban először egy alakzatot kell a diára helyezni, majd ehhez egy szövegtáblázatot (text frame). A szövegtáblázatot a [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) interfész képviseli. Ez a típus nem örököl a [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/)-től, ezért a [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) objektumot egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) objektumba ágyazzuk. A vízjel szövegének hozzáadásához használja a [AddTextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/addtextframe/) metódust, ahogy az alább látható.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="Lásd még" %}} 
- [Hogyan használjuk a TextFrame osztályt](/slides/hu/cpp/text-formatting/)
{{% /alert %}}

### **Szöveges vízjel hozzáadása egy prezentációhoz**

Ha a teljes prezentációhoz (azaz az összes diához egyszerre) szeretne szöveges vízjelet felvenni, adja hozzá a [MasterSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/masterslide/)‑hez. A logika ugyanaz, mint egyetlen diára történő felvételnél – hozzon létre egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) objektumot, majd a [AddTextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/addtextframe/) metódussal adja hozzá a vízjelet.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="Lásd még" %}} 
- [Hogyan használjuk a Diamestert](/slides/hu/cpp/slide-master/)
{{% /alert %}}

### **A vízjel alakzat átlátszóságának beállítása**

Alapértelmezés szerint a téglalap alakzat kitöltési és vonalszínekkel rendelkezik. Az alábbi kódsorok a alakzatot átlátszóvá teszik.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **A szöveges vízjel betűtípusának beállítása**

Az alábbi módon módosíthatja a szöveges vízjel betűtípusát.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **A vízjel szövegének színének beállítása**

A vízjel szövegének színét a következő kóddal állíthatja be:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **Szöveges vízjel középre helyezése**

A vízjel középre helyezhető a dián, a következő módon:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

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

## **Képi vízjel**

### **Képi vízjel hozzáadása egy prezentációhoz**

Képi vízjel felvételéhez egy prezentációs diára az alábbi lépéseket követheti:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **A vízjel szerkesztésének zárolása**

Ha meg kell akadályozni a vízjel szerkesztését, használja a [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/get_autoshapelock/) metódust az alakzaton. Ezzel a tulajdonsággal megvédheti az alakzatot a kiválasztástól, átméretezéstől, áthelyezéstől, csoportosítástól, a szöveg szerkesztésétől és még sok mást:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

// Zárolja a vízjel alakzatot a módosítástól
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->set_SizeLocked(true);
watermarkShape->get_AutoShapeLock()->set_TextLocked(true);
watermarkShape->get_AutoShapeLock()->set_PositionLocked(true);
watermarkShape->get_AutoShapeLock()->set_GroupingLocked(true);
```

## **A vízjel előtérbe hozása**

Az Aspose.Slides‑ben az alakzatok Z-sorrendjét a [IShapeCollection::Reorder](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/reorder/) metódussal állíthatja be. Ehhez hívja meg a metódust a prezentáció diáinak listájáról, és adja át az alakzat referenciáját és a kívánt sorrendszámot. Így egy alakzatot előtérbe hozhat vagy a háttérbe küldhet. Ez a funkció különösen hasznos, ha a vízjelet a prezentáció elejére szeretné helyezni:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **A vízjel forgatásának beállítása**

Az alábbi kódrészlet bemutatja, hogyan állítható be a vízjel forgatása úgy, hogy átlósan helyezkedjen el a dián:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/math.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto slideSize = presentation->get_SlideSize()->get_Size();

auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **A vízjel nevének beállítása**

Az Aspose.Slides lehetővé teszi egy alakzat nevének beállítását. A név használatával a jövőben egyszerűen elérhető a módosítás vagy törlés céljából. A vízjel alakzat nevének beállításához rendelje hozzá a [IAutoShape::set_Name](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/set_name/) metódust:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->set_Name(u"watermark");
```

## **Vízjel eltávolítása**

A vízjel alakzat eltávolításához használja a [IAutoShape::get_Name](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_name/) metódust a diák alakzatai közül való megtalálásához, majd adja át a vízjel alakzatot a [IShapeCollection::Remove](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/remove/) metódusnak:

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_watermark.pptx");
auto slide = presentation->get_Slide(0);

auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(shape);
    }
}
```

## **Élő példa**

Érdemes kipróbálni az **Aspose.Slides ingyenes** [Add Watermark](https://products.aspose.app/slides/hu/watermark) és [Remove Watermark](https://products.aspose.app/slides/hu/watermark/remove-watermark) online eszközöket.

![Online eszközök vízjelek hozzáadásához és eltávolításához](online_tools.png)

## **GYIK**

### Mi a vízjel és miért kellene használnom?

A vízjel egy szöveges vagy képes átfedés, amely a diákra kerül, és segít megvédeni a szellemi tulajdont, erősíti a márka felismerhetőségét, vagy megakadályozza a prezentációk jogosulatlan felhasználását.

### Hozzáadhatok vízjelet az összes diához egy prezentációban?

Igen, az Aspose.Slides lehetővé teszi, hogy programozottan vízjelet adjunk minden diához. Végigiterálhat a diákon, és egyenként alkalmazhatja a vízjel beállításait.

### Hogyan állíthatom be a vízjel átlátszóságát?

Az átlátszóságot a forma kitöltési beállításaival ([FillFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/get_fillformat/)) módosíthatja. Így a vízjel diszkrét marad, és nem vonja el a figyelmet a diák tartalmáról.

### Milyen képformátumok támogatottak a vízjelekhez?

Az Aspose.Slides számos formátumot támogat, például PNG, JPEG, GIF, BMP, SVG és továbbiakat.

### Testreszabhatom a szöveges vízjel betűtípusát és stílusát?

Igen, bármely betűtípust, méretet és stílust választhat, hogy illeszkedjen a prezentáció tervezéséhez és a márka konzisztenciájához.

### Hogyan változtathatom meg a vízjel pozícióját vagy tájolását?

Programozottan módosíthatja a vízjel pozícióját és tájolását a forma koordinátáinak, méretének és forgatási tulajdonságainak beállításával.