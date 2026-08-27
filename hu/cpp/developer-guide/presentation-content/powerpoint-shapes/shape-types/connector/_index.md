---
title: "Kötők kezelése prezentációkban C++-ban"
linktitle: "Kötő"
type: docs
weight: 10
url: /hu/cpp/connector/
keywords:
- "kötő"
- "kötő típus"
- "kötő pont"
- "kötő vonal"
- "kötő szög"
- "csatlakozási hely"
- "beállítási pont"
- "alakzatok összekapcsolása"
- "PowerPoint"
- "prezentáció"
- "C++"
- "Aspose.Slides"
description: "Tanulja meg, hogyan lehet hozzáadni, csatlakoztatni, újratervezni, módosítani és vizsgálni egyenes, hajlított és ívelt PowerPoint kötőket az Aspose.Slides for C++ segítségével."
---
## **Áttekintés**

Egy kapcsoló egy vonal, amely a két alakzat mozgatása esetén is a két alakzathoz csatlakozott marad. Végpontjai csatlakozási pontokhoz kapcsolódnak, amelyek a PowerPointban zöld pontokként jelennek meg. Egyes hajlított és ívelt kapcsolók narancssárga pontokként jelölt beállítási pontokkal rendelkeznek, amelyek az egyes kapcsoló szegmensek helyzetét szabályozzák.

Az Aspose.Slides a kapcsolókat a [IConnector](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iconnector/) felületen keresztül képviseli. Létrehozhatja őket, csatlakoztathatja a végpontjaikat alakzatokhoz, kiválaszthatja a csatlakozási pontokat, átirányíthatja őket, valamint módosíthatja a beállítási pontokkal rendelkező kapcsolók geometriáját.

## **Kapcsoló típusok**

A [ShapeType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shapetype/) felsorolás tartalmazza a egyenes, hajlított és ívelt kapcsoló előbeállításait. Az alábbi táblázat mutatja a rendelkezésre álló kapcsoló geometriákat és az egyes előbeállítások által definiált beállítási pontok számát.

| Kapcsoló | Kép | Beállítási pontok száma |
|---|---|---|
| `ShapeType::Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType::BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType::BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType::BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType::BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType::CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType::CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType::CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType::CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

A beállítási pontok száma és jelentése az adott kapcsoló előbeállítástól függ. Ne feltételezze, hogy két különböző kapcsoló típus ugyanazzal a gyűjtemény elrendezéssel rendelkezik.

## **Két alakzat összekapcsolása**

Használja a [IShapeCollection::AddConnector](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/addconnector/) metódust egy kapcsoló hozzáadásához, és hívja meg a [IConnector::set_StartShapeConnectedTo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iconnector/set_startshapeconnectedto/) és [IConnector::set_EndShapeConnectedTo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iconnector/set_endshapeconnectedto/) metódusokat a végpontok csatlakoztatásához. Miután mindkét végpont csatlakoztatva van, az [IConnector::Reroute](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iconnector/reroute/) egy rövid útvonalat választ a két alakzat között.

Az alábbi példa egy ellipszis és egy téglalap összekapcsolását mutatja hajlított kapcsolóval:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto ellipse = shapes->AddAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
auto rectangle = shapes->AddAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
auto connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

connector->set_StartShapeConnectedTo(ellipse);
connector->set_EndShapeConnectedTo(rectangle);
connector->Reroute();

presentation->Save(u"connected-shapes.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Warning" %}}

Az `IConnector::Reroute` meghívása megváltoztathatja a [IConnector::set_StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iconnector/set_startshapeconnectionsiteindex/) és [IConnector::set_EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iconnector/set_endshapeconnectionsiteindex/) értékeket. Ha a csatlakozási pontoknak rögzítve kell maradniuk, rendelje hozzá őket a újrairányítás után.

{{% /alert %}}

## **Csatlakozási pont kiválasztása**

Minden csatlakoztatható alakzat a [IShape::get_ConnectionSiteCount](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_connectionsitecount/) metódussal adja meg a rendelkezésre álló pontok számát. Érvényesítse a kívánt, nullához képest indexelt pontot, mielőtt a kapcsoló végpontjához rendeli; a pontok száma alakzat geometriától függ.

Ez a példa egy adott ponton csatlakoztatja a kapcsolót az ellipszishez, ha az a pont létezik:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto ellipse = shapes->AddAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
auto rectangle = shapes->AddAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
auto connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

connector->set_StartShapeConnectedTo(ellipse);
connector->set_EndShapeConnectedTo(rectangle);

int32_t preferredSiteIndex = 2;
if (preferredSiteIndex < ellipse->get_ConnectionSiteCount())
{
    connector->set_StartShapeConnectionSiteIndex(preferredSiteIndex);
}
else
{
    Console::WriteLine(u"The ellipse has only {0} connection sites.", ellipse->get_ConnectionSiteCount());
}

presentation->Save(u"specific-connection-site.pptx", SaveFormat::Pptx);
```

## **Kapcsoló pont módosítása**

A beállítási pontokkal rendelkező kapcsolók ezeket a pontokat a [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/hu/cpp/aspose.slides/igeometryshape/get_adjustments/) metóduson keresztül teszik elérhetővé. Minden [IAdjustValue](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iadjustvalue/) elemet vizsgáljon meg, és ellenőrizze a [IAdjustValue::get_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iadjustvalue/get_type/) típusát, mielőtt a [IAdjustValue::set_RawValue](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iadjustvalue/set_rawvalue/) értékét módosítaná. Az előre beállított alakzatbeállítások azonosításának általános szabályait a [Shape Manipulation](/slides/hu/cpp/shape-manipulations/) fejezetben találja.

A kapcsoló beállításainak száma, sorrendje, jelentése és érvényes értéktartománya a kapcsoló előbeállításától függ. A `IAdjustValue::get_Type` által visszaadott típus csak olvasható, míg a nyers beállítási érték írható. A csak olvasható [IAdjustValue::get_Name](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iadjustvalue/get_name/) metódus további azonosítást nyújt, ha a kapcsoló több azonos szemantikai típusú beállítással is rendelkezik.

### **Útvonal akadály körül**

Az alábbi elrendezésben egy `ShapeType::BentConnector5` kapcsoló két alakzat között egy harmadik alakzaton halad át:

![connector-obstruction](connector-obstruction.png)

Ez a kód hozza létre a blokkolt kapcsolót:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

shapes->AddAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
auto connector = shapes->AddConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_StartShapeConnectionSiteIndex(2);

presentation->Save(u"connector-obstruction.pptx", SaveFormat::Pptx);
```

A függőleges hajlítás elmozdítása megváltoztatja az útvonalat, így a kapcsoló megkerüli az akadályt:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Ahelyett, hogy feltételezné, hogy az `1` indexű elem mindig a függőleges hajlítást jelenti, ez a példa a `ShapeAdjustmentType::ConnectorBendPositionY` típusra keres, és csak akkor módosítja, ha a várt szemantikai típus jelen van:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

shapes->AddAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
auto connector = shapes->AddConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_StartShapeConnectionSiteIndex(2);

SharedPtr<IAdjustValue> verticalBend;
auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    Console::WriteLine(u"{0}: type = {1}, raw value = {2}", adjustment->get_Name(), static_cast<int32_t>(adjustment->get_Type()), adjustment->get_RawValue());
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        verticalBend = adjustment;
        break;
    }
}

if (verticalBend == nullptr)
{
    Console::WriteLine(u"The connector does not expose a vertical bend adjustment.");
}
else
{
    verticalBend->set_RawValue(60000);
    presentation->Save(u"connector-obstruction-fixed.pptx", SaveFormat::Pptx);
}
```

Egy `ShapeType::BentConnector5` két `ShapeAdjustmentType::ConnectorBendPositionX` és egy `ShapeAdjustmentType::ConnectorBendPositionY` beállítással rendelkezik. Ha a szükséges típus többször is előfordul, vizsgálja meg az `IAdjustValue::get_Name` értékét és az előbeállítás ismert geometriáját, mielőtt kiválasztana egyet. Ha egy beállítás `ShapeAdjustmentType::Custom` típust jelöl, tekintse jelentését és tartományát az adott előbeállításra jellemzőnek, és csak a szerződés tisztázása után módosítsa.

## **A beállítási értékek kapcsoló geometriához való viszonya**

A hajlított kapcsolók esetén a beállítási értékek felhasználhatók az egyes szegmensek pozíciójának becslésére. Ezek a számítások a konkrét kapcsoló előbeállítástól függenek:

- `ShapeType::BentConnector4` általában egy `ShapeAdjustmentType::ConnectorBendPositionX` és egy `ShapeAdjustmentType::ConnectorBendPositionY` beállítást tesz elérhetővé.
- Ezekhez a hajlítási pozíciókhoz a `RawValue / 100000.0f` a kapcsoló keret szélességének vagy magasságának arányát adja meg az alábbi példákban.
- A kapcsoló keret elforgatható vagy tükrözhető, ezért a keret koordinátáit a dia koordinátáival összehasonlítás előtt át kell alakítani.

Az alábbi példák először a `IAdjustValue::get_Type` használatával határozzák meg a beállításokat, és nem tekintik a gyűjtemény indexeit hordozható azonosítóknak.

### **Nem forgatott kapcsoló**

A kiinduló elrendezés két szöveges alakzatot kapcsol össze egy `ShapeType::BentConnector4` segítségével:

![connector-shape-complex](connector-shape-complex.png)

Ez a példa megvizsgálja a kapcsolót, és lekéri a vízszintes és függőleges hajlítási beállításokat:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
sourceShape->get_TextFrame()->set_Text(u"From");
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
targetShape->get_TextFrame()->set_Text(u"To");
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Crimson());
lineFormat->set_Width(3);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(2);

auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    Console::WriteLine(u"{0}: type = {1}, raw value = {2}", adjustment->get_Name(), static_cast<int32_t>(adjustment->get_Type()), adjustment->get_RawValue());
}
```

A mindkét hajlítás módosításához keresse meg a várt típusokat, és csak mindkettő megtalálása után módosítsa az értékeket:

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(2);

SharedPtr<IAdjustValue> horizontalBend;
SharedPtr<IAdjustValue> verticalBend;
auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend == nullptr || verticalBend == nullptr)
{
    Console::WriteLine(u"The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend->set_RawValue(horizontalBend->get_RawValue() + 20000);
    verticalBend->set_RawValue(verticalBend->get_RawValue() + 200000);
    presentation->Save(u"connector-adjusted.pptx", SaveFormat::Pptx);
}
```

Az eredmény egy olyan kapcsoló, amelynek a vízszintes és függőleges szegmensei elmozdultak:

![connector-adjusted-1](connector-adjusted-1.png)

Miután a szemantikai típusok ismertté váltak, azok értékei átalakíthatók a kapcsoló-keret koordinátákká. Ez a példa egy vékony téglalapot rajzol a két hajlítási beállítás által vezérelt függőleges szegmens fölé:

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(2);

SharedPtr<IAdjustValue> horizontalBend;
SharedPtr<IAdjustValue> verticalBend;
auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend == nullptr || verticalBend == nullptr)
{
    Console::WriteLine(u"The connector does not expose the expected bend adjustments.");
}
else
{
    float x = connector->get_X() + connector->get_Width() * horizontalBend->get_RawValue() / 100000.0f;
    float y = connector->get_Y();
    float height = connector->get_Height() * verticalBend->get_RawValue() / 100000.0f;
    shapes->AddAutoShape(ShapeType::Rectangle, x, y, 1, height);
    presentation->Save(u"connector-segment-guide.pptx", SaveFormat::Pptx);
}
```

A segéd alakzat a kiszámított szegmenst jelöli:

![connector-adjusted-2](connector-adjusted-2.png)

### **Forgatott vagy tükrözött kapcsoló**

Ha ugyanaz a kapcsoló geometria függőlegesen van elrendezve, akkor az [IShape::get_Frame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_frame/), [IShapeFrame::get_FlipH](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapeframe/get_fliph/) és [IShapeFrame::get_FlipV](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapeframe/get_flipv/) értékek befolyásolják a kapcsoló-keret koordináták dia koordinátákká konvertálását.

Ez a példa létrehozza és módosítja a függőlegesen orientált kapcsolót:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
sourceShape->get_TextFrame()->set_Text(u"From");
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
targetShape->get_TextFrame()->set_Text(u"To 1");
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_MediumAquamarine());
lineFormat->set_Width(3);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(3);

auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionX)
    {
        adjustment->set_RawValue(adjustment->get_RawValue() + 20000);
    }
    else if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        adjustment->set_RawValue(adjustment->get_RawValue() + 200000);
    }
}

presentation->Save(u"vertical-connector-adjusted.pptx", SaveFormat::Pptx);
```

A módosított kapcsoló függőlegesen jelenik meg az alakzatok között:

![connector-adjusted-3](connector-adjusted-3.png)

Tetszőleges forgatási szög `alpha` esetén egy kapcsoló-keret pont `(x, y)` forgatása a keret középpontja `(x0, y0)` körül:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Az alábbi kód kezeli a példában használt 90‑fokos orientációt, és piros segédvonallal jelöli a megfelelő kapcsoló szegmenst:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IShapeFrame.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(3);

SharedPtr<IAdjustValue> horizontalBend;
SharedPtr<IAdjustValue> verticalBend;
auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend == nullptr || verticalBend == nullptr)
{
    Console::WriteLine(u"The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend->set_RawValue(horizontalBend->get_RawValue() + 20000);
    verticalBend->set_RawValue(verticalBend->get_RawValue() + 200000);

    float x = connector->get_X();
    float y = connector->get_Y();
    auto frame = connector->get_Frame();
    if (frame->get_FlipH() == NullableBool::True)
    {
        x += connector->get_Width();
    }
    if (frame->get_FlipV() == NullableBool::True)
    {
        y += connector->get_Height();
    }

    x += connector->get_Width() * horizontalBend->get_RawValue() / 100000.0f;
    float rotatedX = frame->get_CenterX() - y + frame->get_CenterY();
    float rotatedY = x - frame->get_CenterX() + frame->get_CenterY();
    float segmentWidth = connector->get_Height() * verticalBend->get_RawValue() / 100000.0f;
    auto guide = shapes->AddAutoShape(ShapeType::Rectangle, rotatedX, rotatedY, segmentWidth, 1);
    auto guideLineFillFormat = guide->get_LineFormat()->get_FillFormat();
    guideLineFillFormat->set_FillType(FillType::Solid);
    guideLineFillFormat->get_SolidFillColor()->set_Color(Color::get_Red());

    presentation->Save(u"rotated-connector-segment-guide.pptx", SaveFormat::Pptx);
}
```

A piros segédvonal a koordinátatranszformáció után kiszámított szegmenst jelöli:

![connector-adjusted-4](connector-adjusted-4.png)

Ezek a képletek a példákban használt előbeállításokra vonatkoznak, nem egy általános kapcsoló modellre. Minden alkalommal ellenőrizze a beállítási típusokat, a keret orientációt és az értéktartományokat, mielőtt ugyanazt a számítást más előbeállításra alkalmazná.

## **Kapcsoló irányszöggének meghatározása**

Egy egyenes kapcsoló irányát a szélesség és magasság arányából, valamint a vízszintes és függőleges tükrözés alkalmazásával számíthatja ki. Az alábbi példa a dián lévő koordinátarendszerben a pozitív vízszintes tengelyhez viszonyított óramutató járásával megegyező szöget adja meg:

```cpp
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IShapeFrame.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/math.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto connector = slide->get_Shapes()->AddConnector(ShapeType::StraightConnector1, 100, 100, 200, 100);
auto frame = connector->get_Frame();

bool flipH = frame->get_FlipH() == NullableBool::True;
bool flipV = frame->get_FlipV() == NullableBool::True;
float deltaX = connector->get_Width() * (flipH ? -1 : 1);
float deltaY = connector->get_Height() * (flipV ? -1 : 1);
double angle = Math::Atan2(deltaY, deltaX) * 180.0 / Math::PI;

if (angle < 0)
{
    angle += 360;
}

Console::WriteLine(u"Connector direction: {0:F2} degrees", angle);
```

## **GYIK**

**Hogyan tudhatom meg, hogy egy kapcsoló csatlakozhat‑e egy alakzathoz?**

Ellenőrizze az alakzat `IShape::get_ConnectionSiteCount` értékét. A pozitív szám azt jelzi, hogy az alakzat rendelkezik csatlakozási pontokkal. Az indexet a csatlakoztatás előtt mindig ellenőrizze.

**Azonosíthatom‑e a kapcsoló beállítását a gyűjtemény indexe alapján?**

Az index csak egy ismert kapcsoló előbeállítás és gyűjtemény elrendezés esetén értelmezhető. Módosítás előtt ellenőrizze a `IAdjustValue::get_Type` értékét, és ha ugyanaz a szemantikai típus többször is előfordul, használja az `IAdjustValue::get_Name` metódust további információként.

**Mi történik, ha a kapcsolt alakzatot törlik?**

A megfelelő kapcsoló végpont leválik. A kapcsoló továbbra is a dián marad, és törölhető, szabad vonalként pozicionálható vagy egy másik alakzathoz csatlakoztatható.

**A kapcsolók kötései megmaradnak, ha a diát másoljuk?**

Általában megmaradnak, ha a kapcsolt alakzatokkal együtt másolják a diát. Ha egy kapcsolót anélkül másolnak, hogy a célalakzata megtartódna, az érintett végpontot újra csatlakoztatni kell.