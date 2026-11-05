---
title: Formato de formas de PowerPoint en C++
linktitle: Formato de formas
type: docs
weight: 20
url: /es/cpp/shape-formatting/
keywords:
- formato de forma
- formato de línea
- efecto de boceto
- línea de forma boceto
- formato de estilo de unión
- relleno degradado
- relleno de patrón
- relleno de imagen
- relleno de textura
- relleno de color sólido
- transparencia de forma
- representación en blanco y negro de forma
- representación en escala de grises de forma
- rotar forma
- efecto de bisel 3D
- efecto de rotación 3D
- restablecer formato
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aprenda a formatear formas de PowerPoint en C++ usando Aspose.Slides—establezca estilos de relleno, línea y efecto para archivos PPT y PPTX con precisión y control total."
---
## **Introducción**

Formatee formas en PowerPoint ajustando sus contornos, rellenos y efectos. Aspose.Slides for C++ le permite controlar estos ajustes mediante código, incluida la transparencia, rotación y formato 3D.

![Opciones de formato de forma en PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for C++ proporciona interfaces y métodos que le permiten dar formato a las formas usando las mismas opciones disponibles en PowerPoint.

## **Formato de líneas**

Utilice [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) para controlar el contorno de una forma. Este ejemplo crea un rectángulo sin relleno con un contorno azul y de trazos discontinuos. [ILineFormat::set_Style](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_style/) selecciona una línea compuesta gruesa‑delgada, mientras que [ILineFormat::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/) establece su ancho en 7 puntos y [ILineFormat::set_DashStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_dashstyle/) elige el patrón de guiones.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineDashStyle.h>
#include <DOM/LineStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El resultado:

![Las líneas con formato en la presentación](formatted-lines.png)

### **Establecer patrones de guiones personalizados**

Utilice [ILineFormat::set_CustomDashPattern](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_customdashpattern/) cuando los estilos de línea predefinidos no proporcionan las longitudes de guiones y espacios que necesita, por ejemplo para contornos de marca o diagramas técnicos. Asignar un patrón cambia automáticamente el estilo de guión a [LineDashStyle::Custom](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/).

Las entradas del arreglo alternan entre longitudes de guión y espacio, comenzando con un guión. Cada valor es un múltiplo del ancho de la línea: `{ 4, 2 }` con un ancho de 3 puntos produce un guión de 12 puntos seguido de un espacio de 6 puntos. Utilice pares de valores finitos y no negativos para definir segmentos completos de guión‑espacio. El ejemplo usa valores positivos para que cada guión y espacio sean visibles.

Este ejemplo crea cinco líneas azules con la misma longitud y extremos planos. Las tres primeras comparan patrones con un ancho de 3 puntos. La cuarta repite el primer patrón al doble de ancho, duplicando tanto los guiones como los espacios. La quinta cambia de un patrón personalizado a una línea sólida.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/LineCapStyle.h>
#include <DOM/LineDashStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/array.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(600, 300, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto patterns = std::array<ArrayPtr<float>, 5>{
    MakeArray<float>({ 4, 2 }),
    MakeArray<float>({ 1, 2 }),
    MakeArray<float>({ 6, 2, 1, 2 }),
    MakeArray<float>({ 4, 2 }),
    MakeArray<float>({ 4, 2 })
};

for (auto i = 0; i < patterns.size(); i++)
{
    auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 50, 50 + i * 50, 500, 0);
    line->get_LineFormat()->set_Width(i == 3 ? 6 : 3);
    line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    line->get_LineFormat()->set_CapStyle(LineCapStyle::Flat);
    line->get_LineFormat()->set_BeginArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_EndArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_CustomDashPattern(patterns[i]);
}

// Return the last line to a solid style.
slide->get_Shape(4)->get_LineFormat()->set_DashStyle(LineDashStyle::Solid);

presentation->Save(u"custom_dash_patterns.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Para volver a un estilo de guiones predefinido, pase [LineDashStyle::Dash](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) a [ILineFormat::set_DashStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_dashstyle/). El estilo seleccionado controla la apariencia de la línea.

El resultado en PowerPoint, de arriba a abajo: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; y **Solid, 3 pt**.

![Tres patrones de guiones personalizados, una línea más ancha usando el primer patrón y una línea sólida en PowerPoint](custom-dash-patterns.png)


### **Establecer extremos de línea**

Utilice [ILineFormat::set_CapStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_capstyle/) para definir los extremos de una línea abierta. La enumeración [LineCapStyle](https://reference.aspose.com/slides/cpp/aspose.slides/linecapstyle/) ofrece tres estilos de extremo explícitos:

- `Flat`: El trazo termina en el punto final.
- `Round`: Un extremo semicircular se extiende más allá del punto final la mitad del ancho de la línea.
- `Square`: Un extremo cuadrado se extiende más allá del punto final la mitad del ancho de la línea.

La enumeración también incluye `NotDefined`, que significa que no se asigna un estilo de extremo de forma explícita.

Los extremos son diferentes de las puntas de flecha, que añaden símbolos a los finales de la línea, y de las uniones, que controlan las esquinas entre segmentos de línea. Este ejemplo desactiva las puntas de flecha mediante [ILineFormat::set_BeginArrowheadStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_beginarrowheadstyle/) y [ILineFormat::set_EndArrowheadStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_endarrowheadstyle/) para que sólo se comparen las formas de los extremos.

El siguiente ejemplo crea tres líneas horizontales idénticas, de 20 puntos de ancho. De arriba a abajo, utilizan extremos plano, redondo y cuadrado. Sus puntos finales comparten las mismas coordenadas horizontales; los extremos redondos y cuadrados se extienden 10 puntos más allá de cada punto final.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/LineCapStyle.h>
#include <DOM/LineDashStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(500, 240, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto capStyles = std::array<LineCapStyle, 3>{ LineCapStyle::Flat, LineCapStyle::Round, LineCapStyle::Square };

for (auto i = 0; i < capStyles.size(); i++)
{
    auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 100, 50 + i * 70, 300, 0);
    line->get_LineFormat()->set_Width(20);
    line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    line->get_LineFormat()->set_DashStyle(LineDashStyle::Solid);
    line->get_LineFormat()->set_CapStyle(capStyles[i]);
    line->get_LineFormat()->set_BeginArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_EndArrowheadStyle(LineArrowheadStyle::None);
}

presentation->Save(u"line_caps.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El resultado en PowerPoint, de arriba a abajo: **Flat**, **Round** y **Square**.

![Extremos plano, redondo y cuadrado en líneas gruesas idénticas en PowerPoint](line-caps.png)

## **Aplicar efectos de boceto a las líneas de forma**

Un efecto de boceto hace que la línea de una forma parezca dibujada a mano. Utilice [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) para acceder a la configuración de la línea, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_sketchformat/) para acceder a la configuración de boceto y [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/set_sketchtype/) para seleccionar un valor de la enumeración [LineSketchType](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/).

El siguiente código C++ muestra cómo aplicar un efecto [LineSketchType::Curved](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/), leer el valor asignado explícitamente y eliminar el efecto con [LineSketchType::None](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISketchFormat.h>
#include <DOM/ISlide.h>
#include <DOM/LineSketchType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();
sketchFormat->set_SketchType(LineSketchType::Curved);
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

El valor devuelto por [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/get_sketchtype/) representa la configuración asignada directamente a la forma. Si el formato de línea puede heredarse de un tema, diapositiva maestra o diapositiva de diseño, utilice [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/), acceda a [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) y lea [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). El valor efectivo refleja el formato realmente aplicado tras resolverse la herencia. Este ejemplo requiere una presentación existente con al menos una forma en su primera diapositiva y muestra ambos valores:

```cpp
#include <DOM/ILineFormat.h>
#include <DOM/ILineFormatEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISketchFormat.h>
#include <DOM/ISketchFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/LineSketchType.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto lineFormat = shape->get_LineFormat();
auto explicitSketchType = lineFormat->get_SketchFormat()->get_SketchType();
auto effectiveLineFormat = lineFormat->GetEffective();
auto effectiveSketchType = effectiveLineFormat->get_SketchFormat()->get_SketchType();

Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
Console::WriteLine(u"Effective sketch type: {0}", effectiveSketchType);
presentation->Dispose();
```

## **Formato de estilos de unión**

Aquí están las tres opciones de tipo de unión:

* Round
* Miter
* Bevel

El estilo de unión controla cómo se encuentran dos segmentos de contorno en una esquina. Utilice **Round** para esquinas redondeadas, **Miter** para esquinas puntiagudas o **Bevel** para esquinas aplanadas.

![El estilo de unión en la presentación](join-style-powerpoint.png)

Este ejemplo crea tres rectángulos negros con contornos azules de 15 puntos de ancho. Establece [ILineFormat::set_JoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_joinstyle/) en los valores miter, bevel y round de [LineJoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/linejoinstyle/), respectivamente, para comparar cómo se dibujan las esquinas.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto miterShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto bevelShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto roundShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

miterShape->get_FillFormat()->set_FillType(FillType::Solid);
miterShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
bevelShape->get_FillFormat()->set_FillType(FillType::Solid);
bevelShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
roundShape->get_FillFormat()->set_FillType(FillType::Solid);
roundShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

miterShape->get_LineFormat()->set_Width(15);
bevelShape->get_LineFormat()->set_Width(15);
roundShape->get_LineFormat()->set_Width(15);

miterShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
miterShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
bevelShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
bevelShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
roundShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
roundShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

miterShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
bevelShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
roundShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

miterShape->get_TextFrame()->set_Text(u"Miter Join Style");
bevelShape->get_TextFrame()->set_Text(u"Bevel Join Style");
roundShape->get_TextFrame()->set_Text(u"Round Join Style");

presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Limitar uniones en ángulo agudo**

Utilice [ILineFormat::set_MiterLimit](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_miterlimit/) con [ILineFormat::set_JoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_joinstyle/) establecido en [LineJoinStyle::Miter](https://reference.aspose.com/slides/cpp/aspose.slides/linejoinstyle/) para limitar cuánto puede extenderse una esquina aguda.

El límite es una relación entre la distancia entre las esquinas interna y externa de la unión y el ancho de la línea. Por ejemplo, un valor de `8` permite una longitud de inglete de hasta ocho veces el ancho de la línea; no es una medida en puntos. Si la esquina excediera el límite, PowerPoint usa una unión biselada en esa esquina. Un límite mayor permite puntas más agudas. La configuración afecta sólo a las uniones de tipo miter y no produce ningún efecto visible cuando la esquina se mantiene dentro de ambos límites.

Este ejemplo crea dos triángulos idénticos sin relleno, con contornos de 20 puntos de ancho. El triángulo izquierdo usa un límite de `2` y el derecho `8`. Cada triángulo mide 80 puntos de ancho y 160 puntos de alto, lo que da a su esquina superior una relación longitud‑inglete‑a‑ancho‑de‑línea de aproximadamente `4.12`. Por consiguiente, PowerPoint bisela el ápice izquierdo y conserva el ápice derecho.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(500, 320, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto miterLimits = std::array<float, 2>{ 2.0f, 8.0f };

for (auto i = 0; i < miterLimits.size(); i++)
{
    auto triangle = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 90 + i * 240, 110, 80, 160);
    triangle->get_FillFormat()->set_FillType(FillType::NoFill);
    triangle->get_LineFormat()->set_Width(20);
    triangle->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    triangle->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    triangle->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
    triangle->get_LineFormat()->set_MiterLimit(miterLimits[i]);
}

presentation->Save(u"miter_limits.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El resultado en PowerPoint: **Límite de inglete 2** a la izquierda y **límit de inglete 8** a la derecha.

![Un ápice biselado con límite de inglete 2 y un ápice puntiagudo con límite de inglete 8 en PowerPoint](miter-limits.png)

## **Relleno degradado**

Un relleno degradado mezcla colores a lo largo de una forma. Este ejemplo rellena una elipse con un degradado lineal a 45 grados de rojo a púrpura usando [IFillFormat::get_GradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_gradientformat/). El método [IGradientStopCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/igradientstopcollection/add/) coloca las paradas de color en 0 y 1, el inicio y el final del degradado. Eliminar las paradas existentes asegura que sólo se usen estos dos colores.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);
shape->get_FillFormat()->get_GradientFormat()->set_LinearGradientAngle(45);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Clear();
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El resultado:

![La elipse con relleno degradado](gradient-fill.png)

Si un degradado se ve diferente en una imagen exportada que en PowerPoint, consulte [Choose a Gradient Rendering Style](/slides/es/cpp/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Puede seleccionar un estilo de renderizado sin cambiar el degradado almacenado en la presentación.

### **Establecer el ángulo del degradado lineal**

Utilice [IGradientFormat::set_LinearGradientAngle](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientangle/) para controlar la orientación de un relleno [GradientShape::Linear](https://reference.aspose.com/slides/cpp/aspose.slides/gradientshape/). El ángulo se mide en grados y aumenta en sentido horario: `0` va de izquierda a derecha, `90` de arriba a abajo, `180` de derecha a izquierda y `270` de abajo a arriba. Se admiten ángulos fraccionarios. Los ángulos finitos fuera de `[0, 360)` se normalizan a una revolución; por ejemplo, `-45` se convierte en `315` y `360` en `0`.

Este ejemplo crea seis rectángulos con paradas de color rojo, verde y azul idénticas en las posiciones `0`, `0.5` y `1`. El escalado está desactivado para que el ángulo pueda compararse independientemente de las proporciones de los rectángulos. Los ángulos, de izquierda a derecha, son `0`, `45` y `90` en la primera fila, y `135`, `180` y `270` en la segunda fila.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 400, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto angles = std::array<float, 6>{ 0, 45, 90, 135, 180, 270 };

for (auto i = 0; i < angles.size(); i++)
{
    auto x = 30 + (i % 3) * 230;
    auto y = 30 + (i / 3) * 190;

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, x, y, 200, 150);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_FillFormat()->set_FillType(FillType::Gradient);

    auto gradient = shape->get_FillFormat()->get_GradientFormat();
    gradient->set_GradientShape(GradientShape::Linear);
    gradient->get_GradientStops()->Clear();
    gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
    gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
    gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
    gradient->set_LinearGradientScaled(NullableBool::False);
    gradient->set_LinearGradientAngle(angles[i]);
}

presentation->Save(u"linear_gradient_angles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El resultado en PowerPoint:

![Degradados lineales a 0, 45 y 90 grados en la fila superior, y 135, 180 y 270 grados en la fila inferior](linear-gradient-angles.png)

### **Escalar un degradado lineal con la forma**

[IGradientFormat::set_LinearGradientScaled](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientscaled/) acepta un valor [NullableBool](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/). Asigne explícitamente `False` para mantener el ángulo geométrico del degradado cuando cambien las proporciones de la forma, o `True` para escalar el degradado con el ancho y alto de la forma. Con el escalado activado, el ángulo visible puede diferir del ángulo asignado en una forma no cuadrada.

El siguiente ejemplo usa un ángulo de `45` grados y las mismas paradas de color que la comparación de ángulos. La columna izquierda usa `False`; la derecha usa `True`. Cada columna contiene un rectángulo ancho sobre un rectángulo alto. Ambos comienzan con las mismas dimensiones amplias; cambiar el ancho y alto del segundo rectángulo muestra cómo responde el relleno al redimensionado sin cambiar su configuración de degradado.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 460, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto scalingOptions = std::array<NullableBool, 2>{ NullableBool::False, NullableBool::True };

for (auto column = 0; column < scalingOptions.size(); column++)
{
    for (auto row = 0; row < 2; row++)
    {
        auto x = 30 + column * 360;
        auto y = row == 0 ? 30 : 150;

        auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, x, y, 300, 90);
        shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
        shape->get_FillFormat()->set_FillType(FillType::Gradient);

        auto gradient = shape->get_FillFormat()->get_GradientFormat();
        gradient->set_GradientShape(GradientShape::Linear);
        gradient->get_GradientStops()->Clear();
        gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
        gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
        gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
        gradient->set_LinearGradientAngle(45);
        gradient->set_LinearGradientScaled(scalingOptions[column]);

        if (row == 1)
        {
            shape->set_Width(90);
            shape->set_Height(280);
        }
    }
}

presentation->Save(u"linear_gradient_scaling.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El resultado en PowerPoint, con el escalado desactivado a la izquierda y activado a la derecha:

![Rectángulos anchos y altos con un degradado de 45 grados, comparando LinearGradientScaled False a la izquierda con True a la derecha](linear-gradient-scaling.png)

Con el escalado desactivado, las bandas de color diagonal mantienen la misma orientación en ambos rectángulos. Con el escalado activado, las bandas se estiran con las proporciones de la forma. Esto ayuda a reproducir el degradado de una plantilla al adaptar una forma a un tamaño diferente. En una forma cuadrada, habilitar el escalado no cambia la apariencia de este degradado de `45` grados.

Tanto el ángulo como la configuración de escalado se aplican a los degradados lineales. No controlan los rellenos [GradientShape::Radial o GradientShape::Rectangle](https://reference.aspose.com/slides/cpp/aspose.slides/gradientshape/).

### **Combinar el ángulo con la dirección del degradado**

[IGradientFormat::set_GradientDirection](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_gradientdirection/) selecciona un estilo de degradado de la enumeración [GradientDirection](https://reference.aspose.com/slides/cpp/aspose.slides/gradientdirection/); no sustituye a un ángulo numérico. Para un degradado lineal, los estilos de esquina pueden cambiar el área sobre la que se distribuyen los colores sin cambiar el ángulo asignado mediante [IGradientFormat::set_LinearGradientAngle](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientangle/). Mantenga la dirección sin cambios al comparar ángulos o escalado.

El siguiente ejemplo aplica la misma configuración en órdenes opuestos. Los dos rectángulos tienen la misma apariencia: asignar la dirección antes o después del ángulo no altera el resultado.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientDirection.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

for (auto i = 0; i < 2; i++)
{
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 30 + i * 140, 320, 100);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_FillFormat()->set_FillType(FillType::Gradient);

    auto gradient = shape->get_FillFormat()->get_GradientFormat();
    gradient->set_GradientShape(GradientShape::Linear);
    gradient->get_GradientStops()->Clear();
    gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
    gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
    gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
    gradient->set_LinearGradientScaled(NullableBool::True);

    if (i == 0)
    {
        gradient->set_GradientDirection(GradientDirection::FromCorner1);
        gradient->set_LinearGradientAngle(30);
    }
    else
    {
        gradient->set_LinearGradientAngle(30);
        gradient->set_GradientDirection(GradientDirection::FromCorner1);
    }
}

presentation->Save(u"linear_gradient_direction.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Relleno de patrón**

Un relleno de patrón aplica un diseño bicolores, como puntos, rayas o cuadros. Este ejemplo usa [IPatternFormat::set_PatternStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/set_patternstyle/) para seleccionar un patrón de celosía. [IPatternFormat::get_BackColor](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) proporciona el fondo gris claro, y [IPatternFormat::get_ForeColor](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) el color amarillo del patrón.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Pattern);
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El resultado:

![El rectángulo con relleno de patrón](pattern-fill.png)

## **Relleno de imagen**

Un relleno de imagen usa una imagen dentro de una forma. Este ejemplo requiere una imagen local y usa [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) para cargarla en la colección de imágenes de la presentación. Establecer [IPictureFillFormat::set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/) al modo mosaico repite la imagen dentro del rectángulo. La imagen fuente utilizada aquí se muestra a continuación:

![La imagen de loto](lotus.png)

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);
shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

auto image = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(image);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(presentationImage);

presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
image->Dispose();
presentation->Dispose();
```

El resultado:

![La forma con relleno de imagen](picture-fill.png)

### **Mosaico de imagen como textura**

Si desea establecer una imagen en mosaico como textura y personalizar el comportamiento del mosaico, puede usar los siguientes métodos de la interfaz [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) y la clase [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/):

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Establece el modo de relleno de imagen—`Tile` o `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Especifica la alineación de los mosaicos dentro de la forma.
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Controla si el mosaico se voltea horizontalmente, verticalmente o en ambas direcciones.
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Establece el desplazamiento horizontal del mosaico (en puntos) desde el origen de la forma.
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Establece el desplazamiento vertical del mosaico (en puntos) desde el origen de la forma.
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Define la escala horizontal del mosaico como porcentaje.
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Define la escala vertical del mosaico como porcentaje.

Este ejemplo requiere una imagen local y configura [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) para repetirla al 50 % de su tamaño original. Desplazamientos de −32 puntos mueven los mosaicos horizontal y verticalmente; la alineación inferior‑derecha y el volteo en ambas direcciones determinan cómo se dispone la textura repetida.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto firstSlide = presentation->get_Slide(0);

auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);
shape->get_FillFormat()->set_FillType(FillType::Picture);

auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);

auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

presentation->Save(u"tile.pptx", SaveFormat::Pptx);
sourceImage->Dispose();
presentation->Dispose();
```

El resultado:

![Las opciones de mosaico](tile-options.png)

## **Relleno de color sólido**

Un relleno sólido otorga a una forma un único color uniforme. Este ejemplo establece [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) en el modo de relleno sólido y asigna amarillo mediante [IFillFormat::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/), luego guarda el rectángulo en una presentación.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El resultado:

![La forma con relleno de color sólido](solid-color-fill.png)

### **Copiar colores preservando referencias de tema**

Utilice [IColorFormat::CopyFrom](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/copyfrom/) para copiar una definición de color, incluida su tipo de color, referencia de tema y transformaciones. Esto es útil al transferir un color de relleno entre formas que deben seguir el tema de la presentación. El método copia solo el color: no copia el tipo de relleno, contorno u otro formato de forma. Establezca el tipo de relleno del destino explícitamente con [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/).

Este ejemplo crea tres rectángulos, de izquierda a derecha: el origen, una copia consciente del tema y una copia RGB fija. El origen usa [IColorFormat::set_SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/set_schemecolor/) para referenciar el primer color de acento y añade una tonalidad mediante [IColorOperationCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/icoloroperationcollection/add/). La copia RGB usa el color de relleno efectivo del origen, de modo que los tres inicialmente se vean idénticos. Llamar a [IColorFormat::set_Color](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/set_color/) establece un valor RGB fijo y elimina cualquier transformación de color existente.

```cpp
#include <DOM/ColorTransformOperation.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(660, 220, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

presentation->get_MasterTheme()->get_ColorScheme()->get_Accent1()->set_Color(Color::get_RoyalBlue());

auto source = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 40, 180, 140);
auto themeCopy = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 240, 40, 180, 140);
auto rgbCopy = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 450, 40, 180, 140);

for (auto shape : { source, themeCopy, rgbCopy })
{
    shape->get_FillFormat()->set_FillType(FillType::Solid);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
}

auto sourceColor = source->get_FillFormat()->get_SolidFillColor();
sourceColor->set_SchemeColor(SchemeColor::Accent1);
sourceColor->get_ColorTransform()->Add(ColorTransformOperation::Tint, 0.75f);

themeCopy->get_FillFormat()->get_SolidFillColor()->CopyFrom(sourceColor);
auto effectiveFill = source->get_FillFormat()->GetEffective();
rgbCopy->get_FillFormat()->get_SolidFillColor()->set_Color(effectiveFill->get_SolidFillColor());

auto before = slide->GetImage(1.0f, 1.0f);
before->Save(u"color-copy-before.png", ImageFormat::Png);
before->Dispose();

// Las referencias de tema siguen el nuevo color de acento; el valor RGB fijo no lo hace.
presentation->get_MasterTheme()->get_ColorScheme()->get_Accent1()->set_Color(Color::get_OrangeRed());

auto after = slide->GetImage(1.0f, 1.0f);
after->Save(u"color-copy-after.png", ImageFormat::Png);
after->Dispose();
presentation->Save(u"copied_colors.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Antes del cambio de tema, los tres rellenos coinciden:

![Origen, destino CopyFrom y destino RGB fijo con rellenos azules idénticos](color-copy-before.png)

Después del cambio de tema, el origen y la copia consciente del tema siguen el nuevo color de acento y conservan su tonalidad. La copia RGB fija permanece azul:

![Origen y destino CopyFrom con rellenos naranjas, mientras que el destino RGB fijo sigue siendo azul](color-copy-after.png)

La definición copiada es independiente del origen. Cambiar posteriormente la referencia de tema del origen, asignar otro color o añadir o eliminar sus transformaciones no afecta al destino. Un cambio de tema sigue afectando a ambas formas porque cada una hace referencia independientemente al mismo color de tema.

Guardar y volver a abrir el PPTX preserva el tipo de color copiado, accesible a través de [IColorFormat::get_ColorType](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/get_colortype/), su referencia de tema y la colección de transformaciones devuelta por [IColorFormat::get_ColorTransform](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/get_colortransform/); no aplana la definición a RGB.

Al copiar entre contextos temáticos diferentes, como presentaciones con paletas de acento distintas, la referencia copiada se resuelve contra el tema del destino. La misma referencia y transformaciones pueden, por tanto, producir un color visible diferente. Consulte [Presentation Theme](/slides/es/cpp/presentation-theme/) para obtener más información sobre la configuración de colores de tema.

## **Usar el fondo de la diapositiva como relleno de forma**

Utilice [IAutoShape::set_UseBackgroundFill](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/set_usebackgroundfill/) cuando una forma debe coincidir con el fondo de la diapositiva, por ejemplo en una plantilla de presentación. Establezca [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) en [FillType::NotDefined](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) primero para eliminar cualquier relleno explícito. Con esta combinación, la forma usa el fondo de la diapositiva en lugar de su relleno de estilo. Activar solo la bandera no elimina un relleno explícito existente.

Esto difiere de [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/): el relleno de fondo cubre los objetos detrás de la forma con el área correspondiente del fondo de la diapositiva, mientras que sin relleno esos objetos permanecen visibles. Un degradado permanece alineado con la diapositiva en lugar de reiniciarse dentro de cada forma.

El siguiente ejemplo crea un fondo maestro heredado por la diapositiva y coloca una banda magenta detrás de tres rectángulos. El rectángulo izquierdo usa el fondo, el del medio no tiene relleno y el derecho pasa de relleno de fondo a un relleno naranja explícito.

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 400, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

// Heredar el degradado del maestro.
slide->get_Background()->set_Type(BackgroundType::NotDefined);
slide->get_LayoutSlide()->get_Background()->set_Type(BackgroundType::NotDefined);
auto background = slide->get_LayoutSlide()->get_MasterSlide()->get_Background();
background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Gradient);
auto gradient = background->get_FillFormat()->get_GradientFormat();
gradient->set_GradientShape(GradientShape::Linear);
gradient->set_LinearGradientAngle(0);
gradient->get_GradientStops()->Clear();
gradient->get_GradientStops()->Add(0, Color::get_DarkBlue());
gradient->get_GradientStops()->Add(1, Color::get_LightSkyBlue());

// Añadir este objeto primero para que aparezca detrás de los rectángulos.
auto band = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 25, 150, 670, 100);
band->get_FillFormat()->set_FillType(FillType::Solid);
band->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Magenta());
band->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

auto backgroundShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 100, 160, 200);
backgroundShape->get_FillFormat()->set_FillType(FillType::NotDefined);
backgroundShape->set_UseBackgroundFill(true);

auto noFillShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 280, 100, 160, 200);
noFillShape->get_FillFormat()->set_FillType(FillType::NoFill);

auto explicitShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 510, 100, 160, 200);
explicitShape->get_FillFormat()->set_FillType(FillType::NotDefined);
explicitShape->set_UseBackgroundFill(true);

// Desactivar el relleno de fondo antes de aplicar un relleno explícito.
explicitShape->set_UseBackgroundFill(false);
explicitShape->get_FillFormat()->set_FillType(FillType::Solid);
explicitShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

presentation->Save(u"background_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El resultado, de izquierda a derecha: **relleno de fondo**, **sin relleno** y **relleno explícito**. La banda magenta está oculta por los rectángulos izquierdo y derecho pero sigue visible a través del rectángulo del medio.

![Relleno de fondo, sin relleno y relleno naranja explícito sobre una banda magenta](background-fill.png)

El mismo comportamiento se aplica a un fondo definido directamente en la diapositiva o heredado de un diseño. La forma usa el fondo resuelto de la diapositiva; el ejemplo deja tanto el fondo de la diapositiva como el del diseño sin definir para que lo proporcione el maestro.

## **Establecer transparencia**

Para un relleno sólido, el componente alfa del color controla la opacidad: 0 es completamente transparente y 255 es completamente opaco. Este ejemplo usa un valor alfa de 128 para un rectángulo amarillo, haciéndolo aproximadamente 50 % transparente para que el rectángulo subyacente siga visible. El color se asigna mediante [IFillFormat::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/).

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const int alpha = 128;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, Color::get_Yellow()));

presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El resultado:

![La forma transparente](shape-transparency.png)

## **Rotar formas**

Utilice [IShape::set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_rotation/) para rotar una forma en el plano de la diapositiva. El ángulo se mide en grados; este ejemplo rota un rectángulo 5 grados en sentido horario y guarda la presentación.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->set_Rotation(5);

presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El resultado:

![La rotación de la forma](shape-rotation.png)

## **Añadir efectos de bisel 3D**

Utilice [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) para dar profundidad y bordes biselados a una forma. Este ejemplo crea una elipse verde con contorno naranja, establece [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) en 4 puntos y aplica un bisel superior circular con ancho y alto de 6 puntos mediante [IThreeDFormat::get_BevelTop](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_beveltop/). Una cámara ortográfica frontal y una iluminación de tres puntos hacen visible el bisel.

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);
shape->get_ThreeDFormat()->set_Depth(4);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El resultado:

![El efecto de bisel 3D](3D-bevel-effect.png)

## **Añadir efectos de rotación 3D**

La vista 3D de una forma se controla mediante la configuración de su cámara. Este ejemplo usa [ICamera::SetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/setrotation/) con ángulos de latitud, longitud y revolución de 40, 35 y 20 grados, respectivamente. Selecciona una cámara isométrica mediante [ICamera::set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) y una iluminación equilibrada mediante [ILightRig::set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/), luego guarda el rectángulo formateado.

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
autoShape->get_TextFrame()->set_Text(u"Hello, Aspose!");
autoShape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
autoShape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
autoShape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El resultado:

![El efecto de rotación 3D](3D-rotation-effect.png)

## **Controlar la representación en blanco y negro para formas**

El método [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) especifica cómo se representa una forma individual cuando una presentación se visualiza o procesa en modo blanco y negro. No habilita la visualización en blanco y negro por sí mismo, y no cambia el relleno, contorno u otro formateo de la forma en modo de color normal.

Utilice un valor de la enumeración [BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/blackwhitemode/) para seleccionar el comportamiento deseado. Por ejemplo, `Automatic` permite que la aplicación de renderizado elija la conversión, `Gray` y `LightGray` usan tonalidades de gris, `BlackWhite` solo negro y blanco, `Black` y `White` fuerzan un único color, `Color` conserva el color normal, y `Hidden` omite la forma en modo blanco y negro. `NotDefined` indica que no se asigna ningún modo a nivel de forma.

Este ejemplo crea un rectángulo naranja y establece [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) en gris. La forma guardada conserva su relleno naranja para la visualización en color normal y solicita coloración gris a las aplicaciones que respeten la configuración de visualización en blanco y negro:

```cpp
#include <DOM/BlackWhiteMode.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

En modo de color normal, el rectángulo conserva su relleno naranja. En un flujo de trabajo de visualización en blanco y negro, usa coloración gris porque su modo está configurado a `Gray`. Esto permite conservar una diapositiva a todo color mientras se define una apariencia distinta para impresión, vista previa u otros flujos que respeten la configuración de visualización en blanco y negro de la presentación.

## **Restablecer formato**

Utilice [ISlide::Reset](https://reference.aspose.com/slides/cpp/aspose.slides/islide/reset/) para restaurar la posición, tamaño y formato de los marcadores de posición de diapositiva a partir de sus marcadores correspondientes en el diseño. Este ejemplo requiere una presentación existente con marcadores vinculados a diseños y restablece cada diapositiva antes de guardar. Las formas sin marcadores de posición correspondientes en el diseño no se restablecen.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**¿El formato de forma afecta al tamaño final del archivo de la presentación?**

Los colores, estilos de línea y ajustes de efectos añaden pocos datos en comparación con imágenes y medios incrustados. Los rellenos de imagen pueden incrementar el tamaño del archivo porque sus imágenes se almacenan en la presentación.

**¿Cómo puedo detectar formas en una diapositiva que comparten el mismo formato para agruparlas?**

Compare las propiedades clave de formato de cada forma—relleno, línea y ajustes de efectos. Si todos los valores correspondientes coinciden, trate sus estilos como idénticos y agrupe lógicamente esas formas, lo que simplifica la gestión de estilos posterior.

**¿Puedo guardar un conjunto de estilos de forma personalizados en un archivo separado para reutilizarlos en otras presentaciones?**

Sí. Guarde formas de ejemplo con los estilos deseados en una diapositiva de plantilla o en un archivo .POTX. Al crear una nueva presentación, abra la plantilla, clone las formas con estilo que necesite y vuelva a aplicar su formato donde sea necesario.