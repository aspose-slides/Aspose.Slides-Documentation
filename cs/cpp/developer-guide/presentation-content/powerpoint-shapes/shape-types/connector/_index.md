---
title: Správa konektorů v prezentacích pomocí C++
linktitle: Konektor
type: docs
weight: 10
url: /cs/cpp/connector/
keywords:
- konektor
- typ konektoru
- bod konektoru
- čára konektoru
- úhel konektoru
- místo připojení
- úpravový bod
- propojit tvary
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak pomocí Aspose.Slides pro C++ přidávat, připojovat, přesměrovávat, upravovat a zkoumat přímé, ohnuté a zakřivené konektory v PowerPointu."
---
## **Přehled**

Konektor je čára, která může zůstat připojena ke dvěma tvarem, i když se kterýkoli z tvarů pohybuje. Jeho konce se připojují k místům připojení, která jsou v PowerPointu zobrazena zelenými tečkami. Některé ohnuté a zakřivené konektory také nabízejí úpravové body, zobrazené oranžovými tečkami, které řídí polohu jednotlivých segmentů konektoru.

Aspose.Slides představuje konektory prostřednictvím rozhraní [IConnector](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iconnector/). Můžete je vytvářet, připojovat jejich konce k tvarům, vybírat místa připojení, přesměrovávat je a měnit geometrii konektorů, které mají úpravové body.

## **Typy konektorů**

Výčtový typ [ShapeType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shapetype/) zahrnuje předvolby pro přímé, ohnuté a zakřivené konektory. Následující tabulka ukazuje dostupné geometrie konektorů a počet úpravových bodů definovaných každou předvolbou.

| Konektor | Obrázek | Počet úpravových bodů |
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

Počet a význam úpravných bodů jsou součástí vybrané předvolby konektoru. Nepředpokládejte, že dva různé typy konektorů mají stejné rozložení kolekce.

## **Propojit dva tvary**

K přidání konektoru použijte [IShapeCollection::AddConnector](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/addconnector/) a zavolejte [IConnector::set_StartShapeConnectedTo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iconnector/set_startshapeconnectedto/) a [IConnector::set_EndShapeConnectedTo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iconnector/set_endshapeconnectedto/) k připojení jeho konců. Po připojení obou konců [IConnector::Reroute](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iconnector/reroute/) vybere krátkou cestu mezi tvary.

Následující příklad spojuje elipsu a obdélník pomocí ohnutého konektoru:

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
Volání `IConnector::Reroute` může změnit hodnoty [IConnector::set_StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iconnector/set_startshapeconnectionsiteindex/) a [IConnector::set_EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iconnector/set_endshapeconnectionsiteindex/). Po přesměrování přiřaďte konkrétní místa připojení, pokud musí zůstat pevná.
{{% /alert %}}

## **Vybrat připojovací místo**

Každý tvářitelné tvar uvádí počet svých míst pomocí [IShape::get_ConnectionSiteCount](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_connectionsitecount/). Ověřte preferovaný nulový index místa, než jej přiřadíte ke konci konektoru; počet míst se liší podle geometrie tvaru.

Tento příklad připojuje konektor k určitému místu na elipse, pokud toto místo existuje:

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

## **Upravit bod konektoru**

Konektory s úpravnými body je vystavují skrze [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/cs/cpp/aspose.slides/igeometryshape/get_adjustments/). Prohlédněte každou [IAdjustValue](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iadjustvalue/) a zkontrolujte její [IAdjustValue::get_Type](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iadjustvalue/get_type/) před změnou jejího [IAdjustValue::set_RawValue](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iadjustvalue/set_rawvalue/). Obecná pravidla pro identifikaci úprav předdefinovaných tvarů jsou popsána v dokumentaci [Shape Manipulation](/slides/cs/cpp/shape-manipulations/).

Počet, pořadí, význam a platný rozsah hodnot úprav konektoru závisejí na předvolbě konektoru. Typ vrácený metodou `IAdjustValue::get_Type` je pouze pro čtení, zatímco surová hodnota úpravy je zapisovatelná. Metoda pouze pro čtení [IAdjustValue::get_Name](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iadjustvalue/get_name/) poskytuje další identifikaci, když konektor obsahuje více úprav se stejným sémantickým typem.

### **Obejít překážku**

V následujícím uspořádání prochází konektor `ShapeType::BentConnector5` mezi dvěma tvary třetím tvarem:

![connector-obstruction](connector-obstruction.png)

Tento kód vytváří blokovaný konektor:

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

Posunutí svislého ohybu mění cestu tak, že konektor obchází překážku:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Místo předpokladu, že index kolekce `1` vždy představuje svislý ohyb, tento příklad hledá `ShapeAdjustmentType::ConnectorBendPositionY` a mění jej jen tehdy, když je přítomen očekávaný sémantický typ:

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

`ShapeType::BentConnector5` má dva úpravy typu `ShapeAdjustmentType::ConnectorBendPositionX` a jednu úpravu typu `ShapeAdjustmentType::ConnectorBendPositionY`. Pokud se požadovaný typ vyskytuje vícekrát, prozkoumejte `IAdjustValue::get_Name` a známou geometrii dané předvolby, než si vyberete konkrétní položku. Pokud úprava vrací `ShapeAdjustmentType::Custom`, považujte její význam a rozsah za specifické pro předvolbu a neměňte ji, dokud není smlouva známá.

## **Vztah hodnot úprav k geometrii konektoru**

U ohnutých konektorů lze hodnoty úprav použít k odhadu poloh jednotlivých segmentů. Tyto výpočty jsou specifické pro předvolbu konektoru:

- `ShapeType::BentConnector4` obvykle vystavuje jednu úpravu `ShapeAdjustmentType::ConnectorBendPositionX` a jednu `ShapeAdjustmentType::ConnectorBendPositionY`.
- Pro tyto pozice ohybu výpočet `RawValue / 100000.0f` dává zlomkovou část šířky nebo výšky rámce konektoru, jak je použito v níže uvedených příkladech.
- Rámec konektoru může být otočen nebo převrácen, takže souřadnice rámce musí být transformovány před porovnáním se souřadnicemi snímku.

Následující příklady nejprve identifikují úpravy pomocí `IAdjustValue::get_Type`. Nepoužívají indexy kolekce jako přenosné identifikátory.

### **Neotočený konektor**

Počáteční uspořádání obsahuje dva textové tvary spojené `ShapeType::BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Tento příklad prozkoumává konektor a získává jeho horizontální a vertikální úpravy ohybu:

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

Pro změnu obou ohybů najděte každý očekávaný typ a upravte hodnoty až po nalezení obou:

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

Výsledkem je konektor, jehož horizontální a vertikální segmenty se posunuly:

![connector-adjusted-1](connector-adjusted-1.png)

Jakmile jsou sémantické typy známy, lze jejich hodnoty převést na souřadnice rámce konektoru. Tento příklad nakreslí tenký obdélník přes vertikální segment řízený dvěma ohyby:

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

Vodicí tvar označuje vypočítaný segment:

![connector-adjusted-2](connector-adjusted-2.png)

### **Otočený nebo převrácený konektor**

Když je stejná geometrie konektoru orientována svisle, ovlivňují převod souřadnic hodnoty [IShape::get_Frame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_frame/), [IShapeFrame::get_FlipH](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapeframe/get_fliph/) a [IShapeFrame::get_FlipV](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapeframe/get_flipv/).

Tento příklad vytváří a upravuje svisle orientovaný konektor:

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

Upravený konektor se objeví svisle mezi tvary:

![connector-adjusted-3](connector-adjusted-3.png)

Pro libovolný úhel otočení `alpha` rotujte bod rámce konektoru `(x, y)` kolem středu rámce `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Následující kód řeší 90‑stupňovou orientaci použitou v tomto příkladu a vykresluje červenou vodítko přes odpovídající segment konektoru:

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

Červená vodítko označuje vypočítaný segment po transformaci souřadnic:

![connector-adjusted-4](connector-adjusted-4.png)

Tyto vzorce popisují předvolby použitých v příkladech, nikoli univerzální model konektoru. Ověřte typy úprav, orientaci rámce a rozsahy hodnot před aplikací stejného výpočtu na jinou předvolbu.

## **Najít úhel směru konektoru**

Směr přímého konektoru lze vypočítat ze šířky a výšky s aplikovanými horizontálními a vertikálními převráceními. Následující příklad uvádí úhel ve směru hodinových ručiček od kladné horizontální osy ve souřadnicích snímku:

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

## **Často kladené otázky**

**Jak zjistit, zda se může konektor připojit k tvaru?**

Zkontrolujte hodnotu `IShape::get_ConnectionSiteCount` tvaru. Kladný počet znamená, že tvar má místa připojení. Ověřte vybraný index místa před jeho přiřazením ke kterémukoli konci konektoru.

**Mohu identifikovat úpravu konektoru podle indexu v kolekci?**

Index má smysl pouze pro známou předvolbu konektoru a uspořádání kolekce. Před úpravou hodnoty zkontrolujte `IAdjustValue::get_Type` a použijte `IAdjustValue::get_Name` jako doplňující informaci, když se stejný sémantický typ vyskytuje vícekrát.

**Co se stane, když je spojený tvar smazán?**

Příslušný konec konektoru se odpojí. Konektor zůstane na snímku a může být smazán, umístěn jako volná čára nebo připojen k jinému tvaru.

**Zachovají se vazby konektorů při kopírování snímku?**

Vazby jsou obecně zachovány, když jsou spojené tvary kopírovány spolu se snímkem. Pokud je konektor zkopírován bez jednoho ze svých cílových tvarů, je třeba postižený konec připojit znovu.