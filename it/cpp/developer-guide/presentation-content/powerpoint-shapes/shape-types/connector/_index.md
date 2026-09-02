---
title: Gestire i connettori nelle presentazioni usando C++
linktitle: Connettore
type: docs
weight: 10
url: /it/cpp/connector/
keywords:
- connettore
- tipo di connettore
- punto del connettore
- linea del connettore
- angolo del connettore
- punto di connessione
- punto di regolazione
- collegare forme
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Impara come aggiungere, collegare, ricalcolare, regolare e ispezionare i connettori PowerPoint lineari, piegati e curvi con Aspose.Slides per C++."
---
## **Panoramica**

Un connettore è una linea che può rimanere collegata a due forme quando una delle due forme si muove. Le sue estremità si collegano a punti di connessione, rappresentati da punti verdi in PowerPoint. Alcuni connettori piegati e curvi espongono anche punti di regolazione, rappresentati da punti arancioni, che controllano la posizione dei singoli segmenti del connettore.

Aspose.Slides rappresenta i connettori tramite l’interfaccia [IConnector](https://reference.aspose.com/slides/it/cpp/aspose.slides/iconnector/). Puoi crearli, collegare le loro estremità alle forme, scegliere i punti di connessione, ricalcolarli e modificare la geometria dei connettori che hanno punti di regolazione.

## **Tipi di connettore**

L’enumerazione [ShapeType](https://reference.aspose.com/slides/it/cpp/aspose.slides/shapetype/) include preset di connettori lineari, piegati e curvi. La tabella seguente mostra le geometrie dei connettori disponibili e il numero di punti di regolazione definiti da ogni preset.

| Connettore | Immagine | Numero di punti di regolazione |
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

Il numero e il significato dei punti di regolazione fanno parte del preset di connettore selezionato. Non presumere che due tipi di connettore diversi espongano la stessa disposizione della collezione.

## **Collega due forme**

Usa [IShapeCollection::AddConnector](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/addconnector/) per aggiungere un connettore e chiama [IConnector::set_StartShapeConnectedTo](https://reference.aspose.com/slides/it/cpp/aspose.slides/iconnector/set_startshapeconnectedto/) e [IConnector::set_EndShapeConnectedTo](https://reference.aspose.com/slides/it/cpp/aspose.slides/iconnector/set_endshapeconnectedto/) per collegare le sue estremità. Dopo che entrambe le estremità sono collegate, [IConnector::Reroute](https://reference.aspose.com/slides/it/cpp/aspose.slides/iconnector/reroute/) seleziona un percorso breve tra le forme.

Il seguente esempio collega un'ellisse e un rettangolo con un connettore piegato:

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

{{% alert color="warning" title="Attenzione" %}}
Chiamare `IConnector::Reroute` può modificare i valori di [IConnector::set_StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/it/cpp/aspose.slides/iconnector/set_startshapeconnectionsiteindex/) e [IConnector::set_EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/it/cpp/aspose.slides/iconnector/set_endshapeconnectionsiteindex/). Assegna punti di connessione specifici dopo il ricalcolo se tali punti devono rimanere fissi.
{{% /alert %}}

## **Scegli un punto di connessione**

Ogni forma collegabile espone il proprio numero di punti tramite [IShape::get_ConnectionSiteCount](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_connectionsitecount/). Convalida un indice di punto basato su zero prima di assegnarlo a un’estremità del connettore; il conteggio varia a seconda della geometria della forma.

Questo esempio collega il connettore a un punto particolare sull'ellisse quando tale punto esiste:

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

## **Regola un punto del connettore**

I connettori con punti di regolazione li espongono tramite [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/it/cpp/aspose.slides/igeometryshape/get_adjustments/). Ispeziona ogni [IAdjustValue](https://reference.aspose.com/slides/it/cpp/aspose.slides/iadjustvalue/) e verifica il suo [IAdjustValue::get_Type](https://reference.aspose.com/slides/it/cpp/aspose.slides/iadjustvalue/get_type/) prima di modificare il suo [IAdjustValue::set_RawValue](https://reference.aspose.com/slides/it/cpp/aspose.slides/iadjustvalue/set_rawvalue/). Le regole generali per identificare le regolazioni di forma preset sono descritte in [Shape Manipulation](/slides/it/cpp/shape-manipulations/).

Il numero, l’ordine, il significato e l’intervallo di valori validi delle regolazioni del connettore dipendono dal preset del connettore. Il tipo restituito da `IAdjustValue::get_Type` è a sola lettura, mentre il valore di regolazione grezzo è modificabile. Il metodo a sola lettura [IAdjustValue::get_Name](https://reference.aspose.com/slides/it/cpp/aspose.slides/iadjustvalue/get_name/) fornisce un’identificazione aggiuntiva quando un connettore contiene più di una regolazione dello stesso tipo semantico.

### **Aggirare un ostacolo**

Nel layout seguente, un connettore `ShapeType::BentConnector5` tra due forme attraversa una terza forma:

![connector-obstruction](connector-obstruction.png)

Questo codice crea il connettore ostacolato:

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

Spostare la curva verticale modifica il percorso in modo che il connettore aggiri l’ostacolo:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Invece di presumere che l’indice della collezione `1` rappresenti sempre la curva verticale, questo esempio ricerca `ShapeAdjustmentType::ConnectorBendPositionY` e la modifica solo quando il tipo semantico previsto è presente:

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

Un `ShapeType::BentConnector5` ha due regolazioni `ShapeAdjustmentType::ConnectorBendPositionX` e una `ShapeAdjustmentType::ConnectorBendPositionY`. Se il tipo di cui hai bisogno compare più volte, ispeziona `IAdjustValue::get_Name` e la geometria nota di quel preset prima di selezionare una regolazione. Se una regolazione restituisce `ShapeAdjustmentType::Custom`, trattane significato e intervallo come specifici del preset e non modificarla finché il contratto non è noto.

## **Relaziona i valori di regolazione alla geometria del connettore**

Per i connettori piegati, i valori di regolazione possono essere usati per stimare le posizioni dei singoli segmenti. Questi calcoli sono specifici per il preset del connettore:

- `ShapeType::BentConnector4` normalmente espone una regolazione `ShapeAdjustmentType::ConnectorBendPositionX` e una `ShapeAdjustmentType::ConnectorBendPositionY`.
- Per queste posizioni di curva, `RawValue / 100000.0f` produce la frazione della larghezza o altezza del riquadro del connettore utilizzata negli esempi seguenti.
- Un riquadro del connettore può essere ruotato o capovolto, quindi le coordinate del riquadro devono essere trasformate prima di confrontarle con le coordinate della diapositiva.

Gli esempi seguenti usano `IAdjustValue::get_Type` per identificare prima le regolazioni. Non trattano gli indici della collezione come identificatori portabili.

### **Connettore non ruotato**

Il layout iniziale contiene due forme di testo collegate da un `ShapeType::BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Questo esempio ispeziona il connettore e ottiene le sue regolazioni di curva orizzontale e verticale:

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

Per modificare entrambe le curve, individua ogni tipo previsto e cambia i valori solo dopo aver trovato entrambi:

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

Il risultato è un connettore i cui segmenti orizzontali e verticali sono stati spostati:

![connector-adjusted-1](connector-adjusted-1.png)

Una volta noti i tipi semantici, i loro valori possono essere convertiti in coordinate del riquadro del connettore. Questo esempio disegna un rettangolo sottile sul segmento verticale controllato dalle due regolazioni di curva:

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

La forma guida indica il segmento calcolato:

![connector-adjusted-2](connector-adjusted-2.png)

### **Connettore ruotato o capovolto**

Quando la stessa geometria del connettore è orientata verticalmente, i valori di [IShape::get_Frame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/get_frame/), [IShapeFrame::get_FlipH](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapeframe/get_fliph/) e [IShapeFrame::get_FlipV](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapeframe/get_flipv/) influiscono sulla conversione dalle coordinate del riquadro del connettore a quelle della diapositiva.

Questo esempio crea e regola il connettore orientato verticalmente:

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

Il connettore regolato appare verticalmente tra le forme:

![connector-adjusted-3](connector-adjusted-3.png)

Per un angolo di rotazione arbitrario `alpha`, ruota un punto del riquadro del connettore `(x, y)` attorno al centro del riquadro `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Il codice seguente gestisce l’orientamento a 90 gradi usato in questo esempio e disegna una guida rossa sul segmento corrispondente del connettore:

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

La guida rossa indica il segmento calcolato dopo la trasformazione delle coordinate:

![connector-adjusted-4](connector-adjusted-4.png)

Queste formule descrivono i preset utilizzati negli esempi, non un modello di connettore universale. Convalida i tipi di regolazione, l’orientamento del riquadro e gli intervalli di valore prima di applicare lo stesso calcolo a un preset diverso.

## **Trova l'angolo di direzione di un connettore**

La direzione di un connettore lineare può essere calcolata dalla sua larghezza e altezza, tenendo conto delle inversioni orizzontali e verticali. Il seguente esempio restituisce l’angolo in senso orario rispetto all’asse orizzontale positivo nelle coordinate della diapositiva:

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

**Come posso capire se un connettore può collegarsi a una forma?**

Controlla il valore di `IShape::get_ConnectionSiteCount` della forma. Un conteggio positivo indica che la forma espone punti di connessione. Convalida l’indice del punto selezionato prima di assegnarlo a una delle estremità del connettore.

**Posso identificare una regolazione del connettore tramite il suo indice nella collezione?**

Un indice è significativo solo per un preset di connettore noto e per la disposizione della collezione. Verifica `IAdjustValue::get_Type` prima di modificare un valore e usa `IAdjustValue::get_Name` come informazione aggiuntiva quando lo stesso tipo semantico si verifica più volte.

** Cosa succede quando una forma collegata viene eliminata?**

L’estremità corrispondente del connettore viene staccata. Il connettore rimane nella diapositiva e può essere eliminato, lasciato come linea libera o collegato a un’altra forma.

**I collegamenti del connettore vengono mantenuti quando una diapositiva viene copiata?**

I collegamenti sono generalmente mantenuti quando le forme collegate vengono copiate insieme alla diapositiva. Se un connettore viene copiato senza una delle sue forme di destinazione, l’estremità interessata deve essere ricollegata.