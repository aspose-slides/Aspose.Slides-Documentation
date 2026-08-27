---
title: Verwalten von Verbindern in Präsentationen mit C++
linktitle: Verbinder
type: docs
weight: 10
url: /de/cpp/connector/
keywords:
- Verbinder
- Verbindertyp
- Verbinderpunkt
- Verbinderlinie
- Verbinderwinkel
- Verbindungsstelle
- Anpassungspunkt
- Formen verbinden
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie gerade, gebogene und gekrümmte PowerPoint-Verbinder mit Aspose.Slides für C++ hinzufügen, anhängen, umleiten, anpassen und untersuchen."
---
## **Überblick**

Ein Verbinder ist eine Linie, die an zwei Formen angeheftet bleiben kann, wenn sich eine der Formen bewegt. Seine Enden werden an Verbindungsstellen angeheftet, die in PowerPoint durch grüne Punkte dargestellt werden. Einige gebogene und gekrümmte Verbinder stellen außerdem Anpassungspunkte bereit, die durch orange Punkte dargestellt werden und die Position einzelner Verbindersegmente steuern.

Aspose.Slides stellt Verbinder über das Interface [IConnector](https://reference.aspose.com/slides/de/cpp/aspose.slides/iconnector/) dar. Sie können sie erstellen, ihre Enden an Formen anheften, Verbindungsstellen auswählen, sie umleiten und die Geometrie von Verbindern mit Anpassungspunkten ändern.

## **Verbindertypen**

Die Aufzählung [ShapeType](https://reference.aspose.com/slides/de/cpp/aspose.slides/shapetype/) enthält Vorgaben für gerade, gebogene und gekrümmte Verbinder. Die folgende Tabelle zeigt die verfügbaren Verbindergeometrien und die Anzahl der für jede Vorgabe definierten Anpassungspunkte.

| Verbinder | Bild | Anzahl der Anpassungspunkte |
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

Die Anzahl und Bedeutung der Anpassungspunkte ist Teil der gewählten Verbinder-Vorgabe. Gehen Sie nicht davon aus, dass zwei verschiedene Verbindertypen dieselbe Sammlungsstruktur aufweisen.

## **Zwei Formen verbinden**

Verwenden Sie [IShapeCollection::AddConnector](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/addconnector/), um einen Verbinder hinzuzufügen, und rufen Sie [IConnector::set_StartShapeConnectedTo](https://reference.aspose.com/slides/de/cpp/aspose.slides/iconnector/set_startshapeconnectedto/) sowie [IConnector::set_EndShapeConnectedTo](https://reference.aspose.com/slides/de/cpp/aspose.slides/iconnector/set_endshapeconnectedto/) auf, um seine Enden anzuhängen. Sobald beide Enden angeheftet sind, wählt [IConnector::Reroute](https://reference.aspose.com/slides/de/cpp/aspose.slides/iconnector/reroute/) einen kurzen Weg zwischen den Formen.

Das folgende Beispiel verbindet eine Ellipse und ein Rechteck mit einem gebogenen Verbinder:

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

{{% alert color="warning" title="Warnung" %}}

Der Aufruf von `IConnector::Reroute` kann die Werte von [IConnector::set_StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/de/cpp/aspose.slides/iconnector/set_startshapeconnectionsiteindex/) und [IConnector::set_EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/de/cpp/aspose.slides/iconnector/set_endshapeconnectionsiteindex/) ändern. Weisen Sie nach dem Umleiten bestimmte Verbindungsstellen zu, wenn diese Stellen fest bleiben müssen.

{{% /alert %}}

## **Eine Verbindungsstelle auswählen**

Jede verbindbare Form meldet ihre Anzahl von Stellen über [IShape::get_ConnectionSiteCount](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_connectionsitecount/). Validieren Sie einen bevorzugten nullbasierten Stellenindex, bevor Sie ihn einem Verbinderende zuweisen; die Stellenzahlen variieren je nach Formgeometrie.

Dieses Beispiel hängt den Verbinder an eine bestimmte Stelle der Ellipse, sofern diese Stelle existiert:

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

## **Einen Verbinderpunkt anpassen**

Verbinder mit Anpassungspunkten stellen diese über [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/de/cpp/aspose.slides/igeometryshape/get_adjustments/) bereit. Inspizieren Sie jedes [IAdjustValue](https://reference.aspose.com/slides/de/cpp/aspose.slides/iadjustvalue/) und prüfen Sie dessen [IAdjustValue::get_Type](https://reference.aspose.com/slides/de/cpp/aspose.slides/iadjustvalue/get_type/), bevor Sie den [IAdjustValue::set_RawValue](https://reference.aspose.com/slides/de/cpp/aspose.slides/iadjustvalue/set_rawvalue/) ändern. Die allgemeinen Regeln zur Identifizierung vordefinierter Formanpassungen sind in [Shape Manipulation](/slides/de/cpp/shape-manipulations/) beschrieben.

Die Anzahl, Reihenfolge, Bedeutung und der zulässige Wertebereich von Verbinderanpassungen hängen von der Verbinder-Vorgabe ab. Der von `IAdjustValue::get_Type` zurückgegebene Typ ist schreibgeschützt, während der Rohwert der Anpassung schreibbar ist. Die schreibgeschützte Methode [IAdjustValue::get_Name](https://reference.aspose.com/slides/de/cpp/aspose.slides/iadjustvalue/get_name/) liefert zusätzliche Identifikation, wenn ein Verbinder mehr als eine Anpassung desselben semantischen Typs enthält.

### **Umweg um ein Hindernis**

Im folgenden Layout führt ein `ShapeType::BentConnector5` zwischen zwei Formen durch eine dritte Form:

![connector-obstruction](connector-obstruction.png)

Dieser Code erzeugt den blockierten Verbinder:

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

Das Verschieben der vertikalen Biegung ändert den Weg, sodass der Verbinder das Hindernis umgeht:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Anstatt anzunehmen, dass der Sammlungsindex `1` immer die vertikale Biegung darstellt, sucht dieses Beispiel nach `ShapeAdjustmentType::ConnectorBendPositionY` und ändert sie nur, wenn der erwartete semantische Typ vorhanden ist:

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

Ein `ShapeType::BentConnector5` hat zwei `ShapeAdjustmentType::ConnectorBendPositionX`‑Anpassungen und eine `ShapeAdjustmentType::ConnectorBendPositionY`‑Anpassung. Wenn der benötigte Typ mehrfach vorkommt, prüfen Sie `IAdjustValue::get_Name` und die bekannte Geometrie dieser Vorgabe, bevor Sie einen auswählen. Gibt eine Anpassung `ShapeAdjustmentType::Custom` zurück, behandeln Sie deren Bedeutung und Wertebereich als vorspezifisch und ändern Sie sie nicht, bis der Vertrag bekannt ist.

## **Anpassungswerte mit Verbindergeometrie in Beziehung setzen**

Bei gebogenen Verbindern können Anpassungswerte verwendet werden, um die Positionen einzelner Segmente abzuschätzen. Diese Berechnungen sind spezifisch für die Verbinder‑Vorgabe:

- `ShapeType::BentConnector4` stellt normalerweise eine `ShapeAdjustmentType::ConnectorBendPositionX`‑ und eine `ShapeAdjustmentType::ConnectorBendPositionY`‑Anpassung bereit.
- Für diese Biegungspositionen erzeugt `RawValue / 100000.0f` den Bruchteil der Verbinderrahmen‑Breite bzw. -Höhe, der in den nachfolgenden Beispielen verwendet wird.
- Ein Verbinderrahmen kann gedreht oder gespiegelt werden, sodass Rahmenkoordinaten vor dem Vergleich mit Folienkoordinaten transformiert werden müssen.

Die folgenden Beispiele verwenden `IAdjustValue::get_Type`, um die Anpassungen zuerst zu identifizieren. Sie behandeln Sammlungsindizes nicht als portable Kennungen.

### **Nicht gedrehter Verbinder**

Das Ausgangslayout enthält zwei Textformen, die durch einen `ShapeType::BentConnector4` verbunden sind:

![connector-shape-complex](connector-shape-complex.png)

Dieses Beispiel inspiziert den Verbinder und ermittelt seine horizontalen und vertikalen Biegungsanpassungen:

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

Um beide Biegungen zu ändern, lokalisieren Sie jeden erwarteten Typ und modifizieren Sie die Werte erst, nachdem beide gefunden wurden:

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

Das Ergebnis ist ein Verbinder, dessen horizontale und vertikale Segmente verschoben wurden:

![connector-adjusted-1](connector-adjusted-1.png)

Sobald die semantischen Typen bekannt sind, können deren Werte in Verbinder‑Rahmenkoordinaten umgerechnet werden. Dieses Beispiel zeichnet ein schmales Rechteck über das vertikale Segment, das von den beiden Biegungsanpassungen gesteuert wird:

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

Die Hilfsform markiert das berechnete Segment:

![connector-adjusted-2](connector-adjusted-2.png)

### **Gedrehter oder gespiegelter Verbinder**

Wenn dieselbe Verbindergeometrie vertikal ausgerichtet ist, beeinflussen die Werte von [IShape::get_Frame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_frame/), [IShapeFrame::get_FlipH](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapeframe/get_fliph/) und [IShapeFrame::get_FlipV](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapeframe/get_flipv/) die Umrechnung von Rahmen‑ zu Folienkoordinaten.

Dieses Beispiel erzeugt und passt den vertikal ausgerichteten Verbinder an:

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

Der angepasste Verbinder erscheint vertikal zwischen den Formen:

![connector-adjusted-3](connector-adjusted-3.png)

Für einen beliebigen Rotationswinkel `alpha` wird ein Punkt `(x, y)` des Verbinderrahmens um das Rahmencentrum `(x0, y0)` rotiert:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Der folgende Code behandelt die in diesem Beispiel genutzte 90‑Grad‑Ausrichtung und zeichnet einen roten Leitfaden über das entsprechende Verbindersgment:

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

Der rote Leitfaden markiert das berechnete Segment nach der Koordinatentransformation:

![connector-adjusted-4](connector-adjusted-4.png)

Diese Formeln beschreiben die in den Beispielen verwendeten Vorgaben, nicht ein universelles Verbinder‑Modell. Validieren Sie die Anpassungstypen, Rahmenorientierung und Wertebereiche, bevor Sie dieselbe Berechnung auf eine andere Vorgabe anwenden.

## **Winkel der Verbinder­richtung ermitteln**

Die Richtung eines geraden Verbinders kann aus seiner Breite und Höhe berechnet werden, wobei horizontale und vertikale Spiegelungen berücksichtigt werden. Das folgende Beispiel gibt den im Uhrzeigersinn gemessenen Winkel von der positiven Horizontalachse in Folienkoordinaten aus:

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

**Wie kann ich feststellen, ob ein Verbinder an eine Form angeheftet werden kann?**

Prüfen Sie den Wert von `IShape::get_ConnectionSiteCount` der Form. Ein positiver Wert bedeutet, dass die Form Verbindungsstellen bereitstellt. Validieren Sie den gewählten Stellen‑Index, bevor Sie ihn einem Verbinderende zuweisen.

**Kann ich eine Verbinder‑Anpassung über ihren Sammlungs‑Index identifizieren?**

Ein Index ist nur für eine bekannte Verbinder‑Vorgabe und Sammlungsstruktur sinnvoll. Prüfen Sie `IAdjustValue::get_Type`, bevor Sie einen Wert ändern, und nutzen Sie `IAdjustValue::get_Name` als zusätzliche Information, wenn derselbe semantische Typ mehrmals vorkommt.

**Was passiert, wenn eine verbundene Form gelöscht wird?**

Das entsprechende Verbinderende wird gelöst. Der Verbinder bleibt auf der Folie und kann gelöscht, als freie Linie positioniert oder an eine andere Form angeheftet werden.

**Werden Verbinderbindungen beim Kopieren einer Folie erhalten?**

Verbindungen werden im Allgemeinen erhalten, wenn die verbundenen Formen mit der Folie kopiert werden. Wird ein Verbinder ohne eine seiner Ziel‑Formen kopiert, muss das betroffene Ende erneut angeheftet werden.