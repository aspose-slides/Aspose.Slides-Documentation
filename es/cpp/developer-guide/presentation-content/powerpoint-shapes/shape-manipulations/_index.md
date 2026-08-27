---
title: Gestionar formas de presentación en C++
linktitle: Manipulación de Formas
type: docs
weight: 40
url: /es/cpp/shape-manipulations/
keywords:
- Forma de PowerPoint
- Forma de presentación
- Forma en diapositiva
- Buscar forma
- Clonar forma
- Eliminar forma
- Ocultar forma
- Cambiar orden de forma
- Obtener ID de forma interop
- Texto alternativo de forma
- Punto de ajuste de forma
- Ajuste de forma predefinido
- Geometría de forma
- Formatos de diseño de forma
- Forma como SVG
- Forma a SVG
- Alinear forma
- Voltear forma
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aprenda cómo identificar, ajustar, clonar, eliminar, ocultar, reordenar, exportar, alinear y voltear formas de presentación con Aspose.Slides para C++."
---
## **Visión general**

Aspose.Slides for C++ representa las formas de una diapositiva como una [IShapeCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishapecollection/) ordenada. La colección es tanto el lugar donde se encuentran y modifican las formas como la fuente de su orden de apilamiento: el índice `0` es la forma más trasera, mientras que el último índice es la forma más delantera.

Este artículo sigue ese modelo. Primero explica cómo identificar una forma de manera fiable y modificar los puntos de ajuste predefinidos, luego muestra cómo clonar, eliminar, ocultar y reordenar formas. Las secciones finales cubren el formato a nivel de diseño, la exportación a SVG, la alineación y la configuración de volteo. Cada ejemplo es independiente, por lo que puedes usar solo las operaciones que requiere tu flujo de trabajo.

## **Identificar y buscar formas**

Los índices de la colección son convenientes mientras se procesa un archivo conocido, pero no son identificadores estables. Añadir, eliminar o reordenar una forma puede cambiar su índice. Elige un identificador según cómo se autorice y mantenga la presentación:

- [Name](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/get_name/) es útil para plantillas controladas por desarrolladores y es fácil de inspeccionar en el Panel de selección de PowerPoint. Los nombres pueden editarse y no se garantiza que sean únicos, así que establece una convención de nombres si el código depende de ellos.
- [AlternativeText](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/get_alternativetext/) es útil cuando una descripción de accesibilidad o una etiqueta proporcionada por el autor ya identifica la forma. Es visible para los usuarios, puede localizarse o reescribirse para accesibilidad, y no se garantiza que sea único. No reutilices silenciosamente texto de accesibilidad significativo como clave de base de datos.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/get_officeinteropshapeid/) es un identificador de solo lectura que es único dentro de una diapositiva y corresponde al ID de forma usado por la interoperabilidad de PowerPoint. Úsalo al integrar con PowerPoint o cuando necesites una referencia inequívoca durante la vida útil de una forma. Una forma clonada o recreada es una forma diferente y recibe su propio ID.

La propiedad relacionada [UniqueId](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/get_uniqueid/) tiene alcance de presentación, pero está destinada a complementos y puede reasignarse. No debe tratarse como una clave externa permanente. Si la identidad a largo plazo es esencial, mantén el mapeo en datos de la aplicación y valida que la forma esperada siga existiendo.

El siguiente ejemplo busca por `Name` e informa el ID de interop con alcance de diapositiva. Cuando la plantilla no contiene la forma esperada, el código informa ese resultado en lugar de continuar con el objeto incorrecto.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> targetShape;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"RevenueChart")
    {
        targetShape = shape;
        break;
    }
}

if (targetShape == nullptr)
{
    Console::WriteLine(u"The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console::WriteLine(String::Format(u"Found {0}; interop ID: {1}", targetShape->get_Name(), targetShape->get_OfficeInteropShapeId()));
}

presentation->Dispose();
```

Cuando una operación es específica de un tipo de forma, comprueba la interfaz antes de usar miembros específicos del tipo. Este ejemplo actualiza el texto y el texto alternativo solo si el objeto nombrado es un [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/).

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> candidate;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"StatusLabel")
    {
        candidate = shape;
        break;
    }
}

if (candidate != nullptr && ObjectExt::Is<IAutoShape>(candidate))
{
    auto autoShape = ExplicitCast<IAutoShape>(candidate);
    autoShape->get_TextFrame()->set_Text(u"Approved");
    autoShape->set_AlternativeText(u"Approval status: approved");
    presentation->Save(u"identified-shape.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"'StatusLabel' is missing or is not an AutoShape.");
}

presentation->Dispose();
```

## **Identificar y modificar ajustes predefinidos de forma**

Las formas de geometría predefinida pueden exponer puntos de ajuste que controlan características como el tamaño de las esquinas, proporciones de flechas o ángulos de arcos. Accede a ellos a través de la colección de solo lectura [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/es/cpp/aspose.slides/igeometryshape/get_adjustments/). La colección la suministra la forma, pero cada [IAdjustValue](https://reference.aspose.com/slides/es/cpp/aspose.slides/iadjustvalue/) contiene un valor que puede cambiarse.

No confíes solo en un índice fijo de la colección. Itera por los ajustes e inspecciona la propiedad de solo lectura [IAdjustValue::get_Type](https://reference.aspose.com/slides/es/cpp/aspose.slides/iadjustvalue/get_type/), cuyo valor [ShapeAdjustmentType](https://reference.aspose.com/slides/es/cpp/aspose.slides/shapeadjustmenttype/) describe qué controla el ajuste. La propiedad de solo lectura [IAdjustValue::get_Name](https://reference.aspose.com/slides/es/cpp/aspose.slides/iadjustvalue/get_name/) proporciona información de identificación adicional y es especialmente útil cuando un predefinido contiene más de un ajuste con el mismo tipo semántico.

Utiliza la propiedad de valor que coincida con el significado del ajuste:

| Tipo de ajuste | Propósito | Valor a cambiar |
|---|---|---|
| `CornerSize` | Tamaño de las esquinas redondeadas | [RawValue](https://reference.aspose.com/slides/es/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | Grosor de la cola de una flecha | `RawValue` |
| `ArrowheadLength` | Longitud de la cabeza de flecha | `RawValue` |
| `ArrowheadWidth` | Ancho de la cabeza de flecha | `RawValue` |
| `StartAngle` | Ángulo inicial de una porción o arco | [AngleValue](https://reference.aspose.com/slides/es/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | Ángulo final de una porción o arco | `AngleValue` |

`Type` y `Name` no pueden asignarse. `RawValue` es un entero de lectura/escritura en las unidades nativas de geometría del predefinido, mientras que `AngleValue` es un ángulo de lectura/escritura en grados. El número, orden, significado y rango válido de ajustes dependen del predefinido [ShapeType](https://reference.aspose.com/slides/es/cpp/aspose.slides/igeometryshape/get_shapetype/). Un valor válido para un predefinido puede ser inválido o tener un efecto diferente para otro.

Cuando `Type` es `ShapeAdjustmentType::Custom`, la API no reconoce un significado semántico estándar. Inspecciona `Name`, el tipo de predefinido y el valor existente, y deja el ajuste sin cambios a menos que se conozca el significado y rango esperados. Incluso para tipos reconocidos, verifica si el mismo tipo aparece más de una vez antes de seleccionar un valor. El artículo [Connector](/slides/es/cpp/connector/) muestra esta situación con ajustes de curvatura de conectores.

El siguiente ejemplo completo crea versiones predeterminadas y modificadas de tres formas predefinidas. Itera por cada ajuste, informa su `Name` y `Type`, cambia los valores relacionados con el tamaño a través de `RawValue`, cambia los ángulos mediante `AngleValue` y guarda el resultado. La columna izquierda conserva la geometría predeterminada; la columna derecha muestra el rectángulo redondeado, la flecha de cuatro puntas y la porción ajustados.

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Añade encabezados para las columnas de forma predeterminada y ajustada.
auto defaultColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
defaultColumnLabel->get_TextFrame()->set_Text(u"Default preset geometry");
auto adjustedColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
adjustedColumnLabel->get_TextFrame()->set_Text(u"Modified adjustment values");

slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
auto modifiedRoundedRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle->set_Name(u"ModifiedRoundedRectangle");

slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
auto modifiedArrow = slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
modifiedArrow->set_Name(u"ModifiedQuadArrow");

slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 95, 330, 130, 130);
auto modifiedPie = slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 445, 330, 130, 130);
modifiedPie->set_Name(u"ModifiedPie");

auto shapesToAdjust = MakeArray<SharedPtr<IGeometryShape>>({modifiedRoundedRectangle, modifiedArrow, modifiedPie});

for (auto shape : shapesToAdjust)
{
    auto adjustments = shape->get_Adjustments();
    for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
    {
        auto adjustment = adjustments->idx_get(adjustmentIndex);
        Console::WriteLine(shape->get_Name() + u" / " + adjustment->get_Name() + u": " + ObjectExt::ToString(adjustment->get_Type()));

        switch (adjustment->get_Type())
        {
            case ShapeAdjustmentType::CornerSize:
                adjustment->set_RawValue(5000);
                break;
            case ShapeAdjustmentType::ArrowTailThickness:
                adjustment->set_RawValue(25000);
                break;
            case ShapeAdjustmentType::ArrowheadLength:
                adjustment->set_RawValue(30000);
                break;
            case ShapeAdjustmentType::ArrowheadWidth:
                adjustment->set_RawValue(40000);
                break;
            case ShapeAdjustmentType::StartAngle:
                adjustment->set_AngleValue(30);
                break;
            case ShapeAdjustmentType::EndAngle:
                adjustment->set_AngleValue(300);
                break;
            case ShapeAdjustmentType::Custom:
                Console::WriteLine(u"Custom adjustment '" + adjustment->get_Name() + u"' was not changed.");
                break;
        }
    }
}

presentation->Save(u"preset-shape-adjustments.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Comprobar el tipo semántico antes de cambiar un valor hace que el código sea explícito respecto a su intención y evita asumir que un índice de colección particular tiene el mismo significado en diferentes formas predefinidas.

## **Modificar la colección de formas**

Los métodos de añadir, clonar, eliminar y reordenar operan sobre la colección inmediatamente. Si una operación cambia el número o el orden de las formas, no continúes confiando en índices capturados antes de esa operación.

### **Clonar una forma**

[AddClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishapecollection/addclone/) crea una copia independiente y la agrega al final de la colección de destino. [InsertClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishapecollection/insertclone/) también crea una copia pero la coloca en un índice de orden Z especificado. Las sobrecargas que aceptan coordenadas mueven el clon sin cambiar su tamaño; las sobrecargas con ancho y alto pueden redimensionarlo también.

El ejemplo crea una diapositiva de destino, clona un rectángulo etiquetado al frente y inserta un segundo clon al fondo. Los cambios en cualquiera de los clones no modifican la forma original.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto sourceSlide = presentation->get_Slide(0);
auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
sourceShape->set_Name(u"SourceLabel");
sourceShape->get_TextFrame()->set_Text(u"Source");

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto destinationSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

auto frontCloneShape = destinationSlide->get_Shapes()->AddClone(sourceShape, 80, 80);
frontCloneShape->set_Name(u"FrontClone");
if (ObjectExt::Is<IAutoShape>(frontCloneShape))
{
    auto frontClone = ExplicitCast<IAutoShape>(frontCloneShape);
    frontClone->get_TextFrame()->set_Text(u"Front clone");
}
else
{
    Console::WriteLine(u"The front clone is not an AutoShape; its text was not changed.");
}

auto backCloneShape = destinationSlide->get_Shapes()->InsertClone(0, sourceShape, 80, 180);
backCloneShape->set_Name(u"BackClone");
if (ObjectExt::Is<IAutoShape>(backCloneShape))
{
    auto backClone = ExplicitCast<IAutoShape>(backCloneShape);
    backClone->get_TextFrame()->set_Text(u"Back clone");
}
else
{
    Console::WriteLine(u"The back clone is not an AutoShape; its text was not changed.");
}

presentation->Save(u"cloned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Clonar copia el contenido y el formato de la forma, incluido su nombre y texto alternativo. Asigna nuevos identificadores lógicos al clon cuando esos valores deben ser únicos. Los recursos utilizados por formas complejas son gestionados por la presentación, pero un clon sigue siendo un nuevo elemento de la colección con una nueva identidad de forma.

### **Eliminar formas**

[Remove](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishapecollection/remove/) elimina un objeto de forma específico de su colección. Al eliminar múltiples coincidencias durante una iteración indexada, recorre la colección desde el final para que cada índice restante siga siendo válido.

Este ejemplo elimina cada forma con un nombre designado. Lee la forma indexada actual, no un elemento de colección fijo, y no fuerza la conversión de la forma innecesariamente.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto keepShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
keepShape->set_Name(u"Keep");

auto firstTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
firstTemporaryShape->set_Name(u"Temporary");

auto secondTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
secondTemporaryShape->set_Name(u"Temporary");

for (int32_t i = slide->get_Shapes()->get_Count() - 1; i >= 0; --i)
{
    auto shape = slide->get_Shape(i);
    if (shape->get_Name() == u"Temporary")
    {
        slide->get_Shapes()->Remove(shape);
    }
}

presentation->Save(u"removed-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Después de la eliminación, el recuento de formas y los índices de las formas posteriores cambian. Las referencias a formas no afectadas siguen siendo más fiables que los índices guardados. También considera conectores, animaciones y otras características de la presentación que puedan referirse al objeto eliminado; eliminar una forma visible puede cambiar más que la apariencia de la diapositiva.

### **Ocultar una forma**

Establecer [Hidden](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/set_hidden/) a `true` mantiene la forma en la colección pero impide que aparezca en la presentación normal. Su índice, formato y contenido permanecen disponibles para el código, por lo que ocultar es apropiado para elementos opcionales que pueden restaurarse más tarde.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto visibleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
visibleShape->set_Name(u"VisibleLabel");

auto optionalShape = slide->get_Shapes()->AddAutoShape(ShapeType::Moon, 240, 40, 100, 100);
optionalShape->set_Name(u"OptionalDecoration");

for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"OptionalDecoration")
    {
        shape->set_Hidden(true);
    }
}

presentation->Save(u"hidden-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ocultar no es eliminación ni seguridad. El objeto aún puede ser descubierto y vuelto a mostrar por un usuario o por código, y sigue formando parte del archivo de la presentación.

### **Cambiar el orden Z**

Las formas superpuestas se pintan según el orden de la colección. [Reorder](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishapecollection/reorder/) mueve una forma existente a un índice objetivo sin clonarla. El índice `0` es el fondo; `Count - 1` es el frente.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto blueRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
blueRectangle->set_Name(u"BlueRectangle");
blueRectangle->get_FillFormat()->set_FillType(FillType::Solid);
blueRectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());

auto orangeEllipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
orangeEllipse->set_Name(u"OrangeEllipse");
orangeEllipse->get_FillFormat()->set_FillType(FillType::Solid);
orangeEllipse->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

slide->get_Shapes()->Reorder(slide->get_Shapes()->get_Count() - 1, blueRectangle);
presentation->Save(u"reordered-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El rectángulo se crea primero y inicialmente está detrás de la elipse. Moverlo al índice final lo coloca al frente. Finaliza el orden Z después de añadir o clonar todas las formas relacionadas, porque esas operaciones añaden o insertan nuevos elementos en la colección y pueden alterar la pila prevista.

## **Inspeccionar formas en diapositivas de diseño**

Las diapositivas normales, de diseño y maestras tienen colecciones de formas separadas. Una forma en una colección de diseño no es el mismo objeto que una forma posicionada de manera similar en una diapositiva normal. Inspecciona las formas de diseño cuando necesites comprender o cambiar el formato proporcionado por un diseño.

El siguiente ejemplo lee el [FillFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/get_fillformat/) y el [LineFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/get_lineformat/) de cada forma de diseño sin asumir que cada forma sea un `AutoShape`.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto layoutSlide : presentation->get_LayoutSlides())
{
    for (auto shape : layoutSlide->get_Shapes())
    {
        auto fillType = shape->get_FillFormat()->get_FillType();
        auto lineWidth = shape->get_LineFormat()->get_Width();
        Console::WriteLine(String::Format(u"{0} / {1}: fill={2}, line width={3}", layoutSlide->get_Name(), shape->get_Name(), fillType, lineWidth));
    }
}

presentation->Dispose();
```

Editar un diseño puede afectar a múltiples diapositivas que lo usan. Antes de cambiar una forma de diseño, determina si una diapositiva normal hereda el objeto o contiene una sobrescritura local, y prueba cada diapositiva que utilice ese diseño.

## **Exportar una forma a SVG**

[WriteAsSvg](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/writeassvg/) escribe el contenido renderizado de una forma a un flujo. El resultado contiene la forma, no el fondo completo de la diapositiva ni las formas vecinas.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

if (slide->get_Shapes()->get_Count() == 0)
{
    Console::WriteLine(u"Slide 1 does not contain a shape to export.");
}
else
{
    auto shape = slide->get_Shape(0);
    auto svgStream = File::Create(u"shape.svg");
    shape->WriteAsSvg(svgStream);
    svgStream->Close();
}

presentation->Dispose();
```

Mantén la presentación abierta mientras renderizas. La salida depende del formato de la forma y de recursos como fuentes e imágenes. Si necesitas toda la composición, exporta la diapositiva en lugar de una forma individual. El llamador es propietario del flujo y debe cerrarlo o disponer de él.

## **Alinear formas**

Los sobrecargas de [SlideUtil::AlignShapes](https://reference.aspose.com/slides/es/cpp/aspose.slides.util/slideutil/alignshapes/) alinean ya sea todas las formas o índices de colección seleccionados. [ShapesAlignmentType](https://reference.aspose.com/slides/es/cpp/aspose.slides/shapesalignmenttype/) especifica el borde, la línea central o el modo de distribución. Establece `alignToSlide` a `true` para usar los bordes de la diapositiva; establézcalo a `false` para alinear las formas seleccionadas entre sí.

Este ejemplo alinea tres formas al borde superior de la diapositiva. Las referencias a formas devueltas se convierten a sus índices actuales inmediatamente antes de la alineación.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/ShapesAlignmentType.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto firstShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
auto secondShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
auto thirdShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
firstShape->set_Name(u"FirstAlignedShape");
secondShape->set_Name(u"SecondAlignedShape");
thirdShape->set_Name(u"ThirdAlignedShape");

auto shapeIndexes = MakeArray<int32_t>({slide->get_Shapes()->IndexOf(firstShape), slide->get_Shapes()->IndexOf(secondShape), slide->get_Shapes()->IndexOf(thirdShape)});

SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, slide, shapeIndexes);
presentation->Save(u"aligned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

La alineación cambia posiciones, no el orden Z. La alineación relativa normalmente necesita al menos dos formas, mientras que la distribución horizontal o vertical requiere suficientes formas para definir el espaciado. Recalcula los índices si modificas la colección antes de llamar al método.

## **Voltear una forma**

La clase [ShapeFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/shapeframe/) almacena posición, tamaño, configuraciones de volteo horizontal y vertical, y rotación. Sus valores `FlipH` y `FlipV` usan [NullableBool](https://reference.aspose.com/slides/es/cpp/aspose.slides/nullablebool/): `True` habilita el volteo, `False` lo deshabilita, y `NotDefined` preserva el estado no especificado/predeterminado.

La presentación de entrada a continuación contiene una forma sin voltear.

![The shape before flipping](shape_to_be_flipped.png)

El ejemplo conserva todos los demás valores del marco y reemplaza solo las dos configuraciones de volteo. Esto es importante porque asignar un nuevo [Frame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/set_frame/) reemplaza todo el marco.

```cpp
#include <DOM/IShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto frame = shape->get_Frame();

Console::WriteLine(String::Format(u"Horizontal flip before change: {0}", frame->get_FlipH()));
Console::WriteLine(String::Format(u"Vertical flip before change: {0}", frame->get_FlipV()));

shape->set_Frame(MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y(), frame->get_Width(), frame->get_Height(), NullableBool::True, NullableBool::True, frame->get_Rotation()));

presentation->Save(u"flipped-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

La forma guardada se refleja horizontal y verticalmente mientras mantiene su posición, tamaño y rotación.

![The shape after flipping](flipped_shape.png)

## **Preguntas frecuentes**

**¿Debo usar un índice de colección como identificador de forma?**

Solo para procesamiento de corta duración cuando la colección no cambiará antes de usar el índice. Prefiere una convención validada de `Name` o `AlternativeText` para plantillas autoras, o `OfficeInteropShapeId` para trabajo de interop con alcance de diapositiva.

**¿Ocultar una forma la elimina del orden Z?**

No. Una forma oculta permanece en la colección en el mismo índice. Puede encontrarse, reordenarse, editarse o volver a hacerse visible.

**¿Por qué una forma clonada apareció delante de otra forma?**

`AddClone` agrega el clon al final de la colección, que es el frente del orden Z. Usa `InsertClone` para elegir el índice inicial o `Reorder` después de añadir todas las formas.

**¿Puedo usar un índice fijo para identificar un ajuste predefinido de forma?**

Solo después de validar el predefinido exacto y la disposición de la colección. Prefiere iterar a través de `IGeometryShape::get_Adjustments` y comprobar `IAdjustValue::get_Type`; usa `IAdjustValue::get_Name` como información adicional cuando el mismo tipo semántico aparece más de una vez.