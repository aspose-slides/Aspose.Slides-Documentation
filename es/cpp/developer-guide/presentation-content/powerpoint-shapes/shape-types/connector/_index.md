---
title: Administrar conectores en presentaciones usando C++
linktitle: Conector
type: docs
weight: 10
url: /es/cpp/connector/
keywords:
- conector
- tipo de conector
- punto de conector
- línea de conector
- ángulo del conector
- sitio de conexión
- punto de ajuste
- conectar formas
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aprende a añadir, unir, reenrutar, ajustar e inspeccionar conectores rectos, doblados y curvos de PowerPoint con Aspose.Slides para C++."
---
## **Visión general**

Un conector es una línea que puede permanecer unida a dos formas cuando cualquiera de las formas se mueve. Sus extremos se unen a puntos de conexión, representados por puntos verdes en PowerPoint. Algunos conectores doblados y curvos también exponen puntos de ajuste, representados por puntos naranjas, que controlan la posición de segmentos individuales del conector.

Aspose.Slides representa los conectores a través de la interfaz [IConnector](https://reference.aspose.com/slides/es/cpp/aspose.slides/iconnector/). Puedes crear los conectores, unir sus extremos a formas, elegir puntos de conexión, reenrutarlos y modificar la geometría de los conectores que tienen puntos de ajuste.

## **Tipos de conector**

La enumeración [ShapeType](https://reference.aspose.com/slides/es/cpp/aspose.slides/shapetype/) incluye predefinidos de conectores rectos, doblados y curvos. La tabla siguiente muestra las geometrías de conector disponibles y el número de puntos de ajuste definidos por cada predefinido.

| Conector | Imagen | Número de puntos de ajuste |
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

El número y el significado de los puntos de ajuste forman parte del predefinido de conector seleccionado. No asumas que dos tipos de conector diferentes exponen la misma disposición de la colección.

## **Conectar dos formas**

Utiliza [IShapeCollection::AddConnector](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishapecollection/addconnector/) para añadir un conector, y llama a [IConnector::set_StartShapeConnectedTo](https://reference.aspose.com/slides/es/cpp/aspose.slides/iconnector/set_startshapeconnectedto/) y a [IConnector::set_EndShapeConnectedTo](https://reference.aspose.com/slides/es/cpp/aspose.slides/iconnector/set_endshapeconnectedto/) para unir sus extremos. Tras unir ambos extremos, [IConnector::Reroute](https://reference.aspose.com/slides/es/cpp/aspose.slides/iconnector/reroute/) selecciona una ruta corta entre las formas.

El siguiente ejemplo conecta una elipse y un rectángulo con un conector doblado:

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

{{% alert color="warning" title="Advertencia" %}}
Llamar a `IConnector::Reroute` puede cambiar los valores de [IConnector::set_StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/es/cpp/aspose.slides/iconnector/set_startshapeconnectionsiteindex/) y de [IConnector::set_EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/es/cpp/aspose.slides/iconnector/set_endshapeconnectionsiteindex/). Asigna puntos de conexión específicos después de reenrutar si esos puntos deben permanecer fijos.
{{% /alert %}}

## **Elegir un punto de conexión**

Cada forma conectable informa su número de puntos a través de [IShape::get_ConnectionSiteCount](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/get_connectionsitecount/). Valida un índice de punto basado en cero antes de asignarlo a un extremo del conector; el recuento de puntos varía según la geometría de la forma.

Este ejemplo une el conector a un punto concreto de la elipse cuando ese punto existe:

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

## **Ajustar un punto de conector**

Los conectores con puntos de ajuste los exponen a través de [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/es/cpp/aspose.slides/igeometryshape/get_adjustments/). Inspecciona cada [IAdjustValue](https://reference.aspose.com/slides/es/cpp/aspose.slides/iadjustvalue/) y comprueba su [IAdjustValue::get_Type](https://reference.aspose.com/slides/es/cpp/aspose.slides/iadjustvalue/get_type/) antes de cambiar su [IAdjustValue::set_RawValue](https://reference.aspose.com/slides/es/cpp/aspose.slides/iadjustvalue/set_rawvalue/). Las reglas generales para identificar los ajustes predefinidos de forma se describen en [Manipulación de formas](/slides/es/cpp/shape-manipulations/).

El número, orden, significado y rango válido de los ajustes del conector dependen del predefinido del conector. El tipo devuelto por `IAdjustValue::get_Type` es de solo lectura, mientras que el valor bruto del ajuste es modificable. El método de solo lectura [IAdjustValue::get_Name](https://reference.aspose.com/slides/es/cpp/aspose.slides/iadjustvalue/get_name/) proporciona una identificación adicional cuando un conector contiene más de un ajuste del mismo tipo semántico.

### **Ruta alrededor de un obstáculo**

En el siguiente esquema, un conector `ShapeType::BentConnector5` entre dos formas atraviesa una tercera forma:

![connector-obstruction](connector-obstruction.png)

Este código crea el conector obstruido:

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

Mover la curva vertical cambia la ruta de modo que el conector evita el obstáculo:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

En lugar de asumir que el índice de colección `1` siempre representa la curva vertical, este ejemplo busca `ShapeAdjustmentType::ConnectorBendPositionY` y lo cambia solo cuando el tipo semántico esperado está presente:

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

Un `ShapeType::BentConnector5` tiene dos ajustes `ShapeAdjustmentType::ConnectorBendPositionX` y un ajuste `ShapeAdjustmentType::ConnectorBendPositionY`. Si el tipo que necesitas ocurre más de una vez, inspecciona `IAdjustValue::get_Name` y la geometría conocida de ese predefinido antes de seleccionar uno. Si un ajuste informa `ShapeAdjustmentType::Custom`, trata su significado y rango como específicos del predefinido y no lo cambies hasta que ese contrato sea conocido.

## **Relacionar los valores de ajuste con la geometría del conector**

Para los conectores doblados, los valores de ajuste pueden usarse para estimar las posiciones de segmentos individuales. Estos cálculos son específicos del predefinido del conector:

- `ShapeType::BentConnector4` normalmente expone un ajuste `ShapeAdjustmentType::ConnectorBendPositionX` y uno `ShapeAdjustmentType::ConnectorBendPositionY`.
- Para estas posiciones de curva, `RawValue / 100000.0f` produce la fracción del ancho o alto del marco del conector utilizada en los ejemplos siguientes.
- Un marco de conector puede rotarse o voltearse, por lo que las coordenadas del marco deben transformarse antes de compararse con las coordenadas de la diapositiva.

Los ejemplos siguientes usan `IAdjustValue::get_Type` para identificar primero los ajustes. No tratan los índices de colección como identificadores portátiles.

### **Conector no rotado**

El esquema inicial contiene dos formas de texto conectadas por un `ShapeType::BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Este ejemplo inspecciona el conector y obtiene sus ajustes de curvatura horizontal y vertical:

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

Para cambiar ambas curvas, localiza cada tipo esperado y modifica los valores solo después de haber encontrado ambos:

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

El resultado es un conector cuyas segmentos horizontales y verticales se han desplazado:

![connector-adjusted-1](connector-adjusted-1.png)

Una vez conocidos los tipos semánticos, sus valores pueden convertirse en coordenadas del marco del conector. Este ejemplo dibuja un rectángulo delgado sobre el segmento vertical controlado por los dos ajustes de curva:

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

La forma guía marca el segmento calculado:

![connector-adjusted-2](connector-adjusted-2.png)

### **Conector rotado o volteado**

Cuando la misma geometría de conector se orienta verticalmente, sus valores de [IShape::get_Frame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/get_frame/), [IShapeFrame::get_FlipH](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishapeframe/get_fliph/) y [IShapeFrame::get_FlipV](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishapeframe/get_flipv/) afectan la conversión de coordenadas del marco del conector a coordenadas de la diapositiva.

Este ejemplo crea y ajusta el conector orientado verticalmente:

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

El conector ajustado aparece verticalmente entre las formas:

![connector-adjusted-3](connector-adjusted-3.png)

Para un ángulo de rotación arbitrario `alpha`, rota un punto del marco del conector `(x, y)` alrededor del centro del marco `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

El siguiente código gestiona la orientación de 90 grados usada en este ejemplo y dibuja una guía roja sobre el segmento correspondiente del conector:

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

La guía roja marca el segmento calculado tras la transformación de coordenadas:

![connector-adjusted-4](connector-adjusted-4.png)

Estas fórmulas describen los predefinidos usados en los ejemplos, no un modelo universal de conector. Valida los tipos de ajuste, la orientación del marco y los rangos de valores antes de aplicar el mismo cálculo a un predefinido diferente.

## **Encontrar el ángulo de dirección de un conector**

La dirección de un conector recto puede calcularse a partir de su ancho y alto, con los volteos horizontal y vertical aplicados. El siguiente ejemplo informa el ángulo en sentido horario desde el eje horizontal positivo en coordenadas de la diapositiva:

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

**¿Cómo puedo saber si un conector puede unirse a una forma?**

Comprueba el valor de `IShape::get_ConnectionSiteCount` de la forma. Un recuento positivo indica que la forma expone puntos de conexión. Valida el índice del punto seleccionado antes de asignarlo a cualquiera de los extremos del conector.

**¿Puedo identificar un ajuste de conector por su índice de colección?**

Un índice tiene sentido solo para un predefinido de conector conocido y su disposición de colección. Verifica `IAdjustValue::get_Type` antes de modificar un valor, y usa `IAdjustValue::get_Name` como información adicional cuando el mismo tipo semántico ocurre más de una vez.

**¿Qué ocurre cuando se elimina una forma conectada?**

El extremo correspondiente del conector queda desacoplado. El conector permanece en la diapositiva y puede eliminarse, posicionarse como una línea libre o unirse a otra forma.

**¿Se conservan los enlaces de los conectores al copiar una diapositiva?**

Los enlaces se conservan generalmente cuando las formas conectadas se copian junto con la diapositiva. Si se copia un conector sin una de sus formas objetivo, el extremo afectado debe volverse a unir.