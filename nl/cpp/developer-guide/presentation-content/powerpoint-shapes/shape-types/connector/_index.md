---
title: Beheer connectors in presentaties met C++
linktitle: Connector
type: docs
weight: 10
url: /nl/cpp/connector/
keywords:
- connector
- connector-type
- connectorpunt
- connectorlijn
- connectorhoek
- aansluitpunt
- aanpassingspunt
- vormen verbinden
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u rechte, gebogen en gekromde PowerPoint-connectors kunt toevoegen, koppelen, opnieuw routeren, aanpassen en inspecteren met Aspose.Slides voor C++."
---
## **Overzicht**

Een connector is een lijn die aan twee vormen kan blijven bevestigd wanneer een van beide vormen beweegt. De uiteinden worden bevestigd aan aansluitpunten, weergegeven door groene stippen in PowerPoint. Sommige gebogen en gekromde connectors hebben ook aanpassingspunten, weergegeven door oranje stippen, die de positie van individuele connectorsegmenten regelen.

Aspose.Slides vertegenwoordigt connectors via de [IConnector](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iconnector/) interface. U kunt ze maken, hun uiteinden aan vormen koppelen, verbindingstoepassingen kiezen, ze opnieuw routeren en de geometrie van connectors die aanpassingspunten hebben wijzigen.

## **Connector-typen**

De [ShapeType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shapetype/) enumeratie bevat rechte, gebogen en gekromde connector‑presets. De onderstaande tabel toont de beschikbare connector‑geometrieën en het aantal aanpassingspunten dat door elk preset wordt gedefinieerd.

| Connector | Image | Aantal aanpassingspunten |
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

Het aantal en de betekenis van aanpassingspunten maken deel uit van het gekozen connector‑preset. Ga er niet van uit dat twee verschillende connector‑typen dezelfde collectie‑indeling blootleggen.

## **Twee vormen verbinden**

Gebruik [IShapeCollection::AddConnector](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/addconnector/) om een connector toe te voegen, en roep [IConnector::set_StartShapeConnectedTo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iconnector/set_startshapeconnectedto/) en [IConnector::set_EndShapeConnectedTo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iconnector/set_endshapeconnectedto/) aan om de uiteinden te bevestigen. Nadat beide uiteinden zijn bevestigd, selecteert [IConnector::Reroute](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iconnector/reroute/) een korte route tussen de vormen.

Het volgende voorbeeld verbindt een ellips en een rechthoek met een gebogen connector:

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
Het aanroepen van `IConnector::Reroute` kan de waarden van [IConnector::set_StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iconnector/set_startshapeconnectionsiteindex/) en [IConnector::set_EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iconnector/set_endshapeconnectionsiteindex/) wijzigen. Wijs specifieke verbindingspunten toe na het opnieuw routeren als die punten vast moeten blijven.
{{% /alert %}}

## **Kies een verbindingspunt**

Elke verbindbare vorm meldt het aantal sites via [IShape::get_ConnectionSiteCount](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_connectionsitecount/). Valideer een voorkeurs‑index (nulgebaseerd) voordat u deze aan een connector‑uiteinde toewijst; het aantal sites verschilt per vormgeometrie.

Dit voorbeeld koppelt de connector aan een specifiek site op de ellips wanneer dat site bestaat:

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

## **Een connector‑punt aanpassen**

Connectors met aanpassingspunten maken ze beschikbaar via [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/nl/cpp/aspose.slides/igeometryshape/get_adjustments/). Inspecteer elke [IAdjustValue](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iadjustvalue/) en controleer zijn [IAdjustValue::get_Type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iadjustvalue/get_type/) voordat u zijn [IAdjustValue::set_RawValue](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iadjustvalue/set_rawvalue/) wijzigt. De algemene regels voor het identificeren van preset‑vormaanpassingen worden beschreven in [Shape Manipulation](/slides/nl/cpp/shape-manipulations/).

Het aantal, de volgorde, de betekenis en het geldige waardebereik van connector‑aanpassingen hangen af van het connector‑preset. Het type dat wordt geretourneerd door `IAdjustValue::get_Type` is alleen‑lezen, terwijl de ruwe aanpassingswaarde schrijfbaar is. De alleen‑lezen methode [IAdjustValue::get_Name](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iadjustvalue/get_name/) biedt extra identificatie wanneer een connector meer dan één aanpassing van hetzelfde semantische type bevat.

### **Omzeil een obstakel**

In de onderstaande opstelling passeert een `ShapeType::BentConnector5` connector tussen twee vormen door een derde vorm:

![connector-obstruction](connector-obstruction.png)

Deze code maakt de geblokkeerde connector:

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

Het verplaatsen van de verticale buiging wijzigt de route zodat de connector het obstakel omzeilt:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

In plaats van aan te nemen dat collectie‑index `1` altijd de verticale buiging vertegenwoordigt, zoekt dit voorbeeld naar `ShapeAdjustmentType::ConnectorBendPositionY` en wijzigt het alleen wanneer het verwachte semantische type aanwezig is:

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

Een `ShapeType::BentConnector5` heeft twee `ShapeAdjustmentType::ConnectorBendPositionX`‑aanpassingen en één `ShapeAdjustmentType::ConnectorBendPositionY`‑aanpassing. Als het type dat u nodig heeft meer dan eens voorkomt, inspecteer dan `IAdjustValue::get_Name` en de bekende geometrie van dat preset voordat u er één kiest. Als een aanpassing `ShapeAdjustmentType::Custom` rapporteert, beschouw dan de betekenis en het bereik als preset‑specifiek en wijzig het niet totdat dat contract bekend is.

## **Aanpassingswaarden relateren aan connector‑geometrie**

Voor gebogen connectors kunnen aanpassingswaarden worden gebruikt om de posities van individuele segmenten te schatten. Deze berekeningen zijn specifiek voor het connector‑preset:

- `ShapeType::BentConnector4` toont normaal één `ShapeAdjustmentType::ConnectorBendPositionX`‑ en één `ShapeAdjustmentType::ConnectorBendPositionY`‑aanpassing.
- Voor deze buigposities levert `RawValue / 100000.0f` de fractie van de connector‑frame‑breedte of -hoogte op die in de onderstaande voorbeelden wordt gebruikt.
- Een connector‑frame kan worden geroteerd of gespiegeld, dus frame‑coördinaten moeten worden getransformeerd vóór vergelijking met dia‑coördinaten.

De volgende voorbeelden gebruiken eerst `IAdjustValue::get_Type` om de aanpassingen te identificeren. Ze behandelen collectie‑indexen niet als draagbare identifiers.

### **Niet‑geroteerde connector**

De initiële opstelling bevat twee tekstvormen die verbonden zijn door een `ShapeType::BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Dit voorbeeld inspecteert de connector en verkrijgt zijn horizontale en verticale buig‑aanpassingen:

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

Om beide buigingen te wijzigen, zoek elke verwachte type op en wijzig de waarden pas nadat beide zijn gevonden:

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

Het resultaat is een connector waarvan de horizontale en verticale segmenten zijn verplaatst:

![connector-adjusted-1](connector-adjusted-1.png)

Zodra de semantische types bekend zijn, kunnen hun waarden worden omgezet naar connector‑frame‑coördinaten. Dit voorbeeld tekent een dunne rechthoek over het verticale segment dat wordt bestuurd door de twee buig‑aanpassingen:

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

De hulplijn‑vorm markeert het berekende segment:

![connector-adjusted-2](connector-adjusted-2.png)

### **Geroteerde of gespiegelde connector**

Wanneer dezelfde connector‑geometrie verticaal is georiënteerd, beïnvloeden de waarden van [IShape::get_Frame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_frame/), [IShapeFrame::get_FlipH](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapeframe/get_fliph/), en [IShapeFrame::get_FlipV](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapeframe/get_flipv/) de omzetting van connector‑frame‑coördinaten naar dia‑coördinaten.

Dit voorbeeld maakt en past de verticaal georiënteerde connector aan:

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

De aangepaste connector verschijnt verticaal tussen de vormen:

![connector-adjusted-3](connector-adjusted-3.png)

Voor een willekeurige rotatiehoek `alpha` roteert u een connector‑frame‑punt `(x, y)` rond het frame‑centrum `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

De volgende code behandelt de 90‑graden‑oriëntatie die in dit voorbeeld wordt gebruikt en tekent een rode hulplijn over het overeenkomende connector‑segment:

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

De rode hulplijn markeert het berekende segment na de coördinatentransformatie:

![connector-adjusted-4](connector-adjusted-4.png)

Deze formules beschrijven de presets die in de voorbeelden worden gebruikt, niet een universeel connector‑model. Valideer de aanpassingstypes, frame‑oriëntatie en waardebereiken voordat u dezelfde berekening op een ander preset toepast.

## **Zoek een connector‑richtingshoek**

De richting van een rechte connector kan worden berekend aan de hand van de breedte en hoogte, met horizontale en verticale flips toegepast. Het volgende voorbeeld geeft de klok‑wijze hoek ten opzichte van de positieve horizontale as in dia‑coördinaten weer:

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

## **FAQ**

**Hoe kan ik zien of een connector aan een vorm kan worden gekoppeld?**

Controleer de waarde van `IShape::get_ConnectionSiteCount` van de vorm. Een positieve telling betekent dat de vorm verbindingstoepassingen exposeert. Valideer de geselecteerde site‑index voordat u deze aan een connector‑uiteinde toewijst.

**Kan ik een connector‑aanpassing identificeren aan de hand van zijn collectie‑index?**

Een index is alleen betekenisvol voor een bekend connector‑preset en collectie‑lay-out. Controleer `IAdjustValue::get_Type` voordat u een waarde wijzigt, en gebruik `IAdjustValue::get_Name` als aanvullende informatie wanneer hetzelfde semantische type meer dan één keer voorkomt.

**Wat gebeurt er als een gekoppelde vorm wordt verwijderd?**

Het bijbehorende connector‑uiteinde wordt losgekoppeld. De connector blijft op de dia staan en kan worden verwijderd, gepositioneerd als een losse lijn, of gekoppeld aan een andere vorm.

**Worden connector‑koppelingen behouden wanneer een dia wordt gekopieerd?**

Koppelingen blijven over het algemeen behouden wanneer de gekoppelde vormen samen met de dia worden gekopieerd. Als een connector wordt gekopieerd zonder een van zijn doelvormen, moet het betreffende uiteinde opnieuw worden gekoppeld.