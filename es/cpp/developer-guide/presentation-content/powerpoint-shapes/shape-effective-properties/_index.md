---
title: Obtener propiedades efectivas de la forma en presentaciones C++
linktitle: Propiedades efectivas
type: docs
weight: 50
url: /es/cpp/shape-effective-properties/
keywords:
- propiedades de forma
- propiedades de cámara
- sistema de luces
- forma biselada
- marco de texto
- estilo de texto
- altura de fuente
- formato de relleno
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aprenda a utilizar Aspose.Slides para C++ para distinguir el formato local, heredado y efectivo de formas en presentaciones PowerPoint."
---
## **Entender las propiedades locales, heredadas y efectivas**

El formato de PowerPoint puede provenir de varios orígenes. El valor almacenado directamente en un objeto es su **valor local**. Si ese valor no está definido, PowerPoint consulta fuentes de formato superiores, como el valor predeterminado de un párrafo, un estilo de texto, una diapositiva de diseño o maestra, un tema o los valores predeterminados a nivel de presentación. Esos valores son **valores heredados**. El valor que queda después de resolver toda la jerarquía es el **valor efectivo**: el valor utilizado para representar el objeto.

Por ejemplo, una porción de texto puede no definir su propia altura de fuente. Su **[altura de fuente](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibaseportionformat/)** local es entonces `std::numeric_limits<float>::quiet_NaN()`, lo que significa “no está establecido aquí”. La porción puede heredar una altura de su párrafo, del estilo de texto predeterminado de la presentación o de otra fuente aplicable. Llamar a **[GetEffective](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportionformat/)** sobre el formato de la porción devuelve la altura final resuelta.

Utilice los dos tipos de datos de formato para diferentes propósitos:

- Lea o modifique un objeto de formato local, como **[IPortionFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportionformat/)**, cuando necesite controlar dónde se define un valor.
- Lea un objeto de datos efectivo, como **[IPortionFormatEffectiveData](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportionformateffectivedata/)**, cuando necesite el resultado final renderizado. Los datos efectivos son de solo lectura.

## **Comparar valores locales, heredados y efectivos**

El siguiente ejemplo completo crea una forma y aplica alturas de fuente a nivel de presentación, párrafo y porción. Cada paso muestra los valores definidos en esos niveles y el valor efectivo resultante para la misma porción de texto. También muestra por qué los datos efectivos deben leerse nuevamente después de los cambios de formato.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <cmath>
#include <limits>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 500.0f, 80.0f, false);
auto textFrame = shape->AddTextFrame(u"Effective formatting");
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

// Definir valores heredados en dos niveles diferentes.
presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(20.0f);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);

auto formatLocalValue = [](float value) -> System::String
{
    return std::isnan(value) ? System::String(u"<not set>") : System::ObjectExt::ToString(value);
};

auto printFontHeights = [&](System::String caption)
{
    auto presentationValue = presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->get_FontHeight();
    auto paragraphValue = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FontHeight();
    auto localValue = portion->get_PortionFormat()->get_FontHeight();

    // Leer datos efectivos después de los cambios anteriores.
    auto effectiveValue = portion->get_PortionFormat()->GetEffective()->get_FontHeight();

    System::Console::WriteLine(caption);
    System::Console::WriteLine(System::String(u"  Presentation default: ") + formatLocalValue(presentationValue));
    System::Console::WriteLine(System::String(u"  Paragraph default:    ") + formatLocalValue(paragraphValue));
    System::Console::WriteLine(System::String(u"  Portion local:        ") + formatLocalValue(localValue));
    System::Console::WriteLine(System::String(u"  Portion effective:    ") + effectiveValue);
};

printFontHeights(u"The portion inherits from the paragraph");

// Un valor local en la porción sobrescribe ambos valores heredados.
portion->get_PortionFormat()->set_FontHeight(36.0f);
printFontHeights(u"A local value overrides inherited values");

// Cambiar un valor heredado no sobrescribe un valor local existente.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(30.0f);
printFontHeights(u"The local value still has priority");

// Borrar el valor local. La porción vuelve a heredar del párrafo.
portion->get_PortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The local value is cleared");

// Borrar el valor del párrafo. El valor predeterminado de la presentación suministra ahora el resultado.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The paragraph value is cleared");

presentation->Save(u"effective-properties.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

La prioridad en este ejemplo es el formato local de la porción, luego el formato del párrafo y, por último, el predeterminado de la presentación. Otros objetos pueden tener cadenas de herencia diferentes, pero el principio es el mismo: un valor explícito más específico prevalece, y **[GetEffective](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportionformat/)** devuelve el resultado final.

## **Obtener propiedades de texto efectivas**

El formato de texto se reparte entre varios objetos:

- **[ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframeformat/)** resuelve propiedades del marco de texto como márgenes, anclaje, ajuste automático y dirección vertical del texto.
- **[ITextStyle::GetEffective](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextstyle/)** resuelve el formato de párrafo para cada nivel de estilo de texto.
- **[IParagraphFormat::GetEffective](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphformat/)** resuelve propiedades de párrafo como alineación, sangría y viñetas.
- **[IPortionFormat::GetEffective](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportionformat/)** resuelve propiedades de carácter como altura de fuente, tipografía, color, negrita e itálica.

Para el siguiente ejemplo, `text-formatting.pptx` debe contener al menos una diapositiva y una **[IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/)** con un marco de texto no vacío. La IAutoShape puede aparecer en cualquier posición de la colección de formas; el código busca un objeto adecuado y lo valida antes de usarlo.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"text-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<IAutoShape> shape;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (!System::ObjectExt::Is<IAutoShape>(candidate))
        continue;

    auto autoShape = System::ExplicitCast<IAutoShape>(candidate);
    auto candidateTextFrame = autoShape->get_TextFrame();

    if (candidateTextFrame == nullptr || candidateTextFrame->get_Paragraphs()->get_Count() == 0)
        continue;

    if (candidateTextFrame->get_Paragraph(0)->get_Portions()->get_Count() == 0)
        continue;

    shape = autoShape;
    break;
}

if (shape == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain an IAutoShape with non-empty text.");

auto textFrame = shape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

auto textFrameEffective = textFrame->get_TextFrameFormat()->GetEffective();
auto paragraphEffective = paragraph->get_ParagraphFormat()->GetEffective();
auto portionEffective = portion->get_PortionFormat()->GetEffective();

System::Console::WriteLine(u"Text frame margins:");
System::Console::WriteLine(System::String(u"  Left: ") + textFrameEffective->get_MarginLeft());
System::Console::WriteLine(System::String(u"  Top: ") + textFrameEffective->get_MarginTop());
System::Console::WriteLine(System::String(u"  Right: ") + textFrameEffective->get_MarginRight());
System::Console::WriteLine(System::String(u"  Bottom: ") + textFrameEffective->get_MarginBottom());
System::Console::WriteLine(System::String(u"Paragraph alignment: ") + System::ObjectExt::ToString(paragraphEffective->get_Alignment()));
System::Console::WriteLine(System::String(u"Font height: ") + portionEffective->get_FontHeight());
System::Console::WriteLine(System::String(u"Bold: ") + System::ObjectExt::ToString(portionEffective->get_FontBold()));

auto effectiveTextStyle = textFrame->get_TextFrameFormat()->get_TextStyle()->GetEffective();
for (int level = 0; level < 9; ++level)
{
    auto levelEffective = effectiveTextStyle->GetLevel(level);
    System::Console::WriteLine(System::String(u"Level ") + level + u" indent: " + levelEffective->get_Indent());
}

presentation->Dispose();
```

## **Obtener propiedades 3D efectivas**

**[IThreeDFormat::GetEffective](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/)** devuelve un objeto **[IThreeDFormatEffectiveData](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformateffectivedata/)** que agrupa todas las configuraciones 3D resueltas. Sus datos de **[camera](https://reference.aspose.com/slides/es/cpp/aspose.slides/icameraeffectivedata/)**, **[light rig](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilightrigeffectivedata/)**, **[top bevel](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishapebeveleffectivedata/)** y **[bottom bevel](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishapebeveleffectivedata/)** exponen la configuración efectiva correspondiente. Leer estos ajustes relacionados juntos facilita la comprensión de la apariencia 3D final de una forma.

Para este ejemplo, `shape-3d.pptx` debe contener al menos una forma en su primera diapositiva. Aplique ajustes de cámara 3D, iluminación o biselado a esa forma si desea que la salida contenga valores diferentes de los predeterminados.

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"shape-3d.pptx");

if (presentation->get_Slides()->get_Count() == 0 || presentation->get_Slide(0)->get_Shapes()->get_Count() == 0)
    throw System::InvalidOperationException(u"The first slide must contain a shape.");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto threeDEffective = shape->get_ThreeDFormat()->GetEffective();

System::Console::WriteLine(u"Camera:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_Camera()->get_CameraType()));
System::Console::WriteLine(System::String(u"  Field of view: ") + threeDEffective->get_Camera()->get_FieldOfViewAngle());
System::Console::WriteLine(System::String(u"  Zoom: ") + threeDEffective->get_Camera()->get_Zoom());

System::Console::WriteLine(u"Light rig:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_LightType()));
System::Console::WriteLine(System::String(u"  Direction: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_Direction()));

System::Console::WriteLine(u"Top bevel:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_BevelTop()->get_BevelType()));
System::Console::WriteLine(System::String(u"  Width: ") + threeDEffective->get_BevelTop()->get_Width());
System::Console::WriteLine(System::String(u"  Height: ") + threeDEffective->get_BevelTop()->get_Height());

presentation->Dispose();
```

## **Obtener formato de tabla efectivo**

El formato de tabla puede provenir del estilo de tabla y de los formatos aplicados a toda la tabla, a una columna, a una fila o a una celda individual. En caso de conflictos entre rellenos definidos explícitamente, la prioridad es: celda, fila, columna y, finalmente, tabla completa. El formato efectivo de una celda es el formato final utilizado para dibujar esa celda.

Para este ejemplo, `table-formatting.pptx` debe contener al menos una tabla en su primera diapositiva. La tabla debe tener al menos una fila y una columna. El código busca una **[ITable](https://reference.aspose.com/slides/es/cpp/aspose.slides/itable/)** en lugar de asumir que la primera forma es una tabla.

```cpp
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"table-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (System::ObjectExt::Is<ITable>(candidate))
    {
        table = System::ExplicitCast<ITable>(candidate);
        break;
    }
}

if (table == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain a table.");

if (table->get_Rows()->get_Count() == 0 || table->get_Columns()->get_Count() == 0)
    throw System::InvalidOperationException(u"The table must contain at least one cell.");

auto tableEffective = table->get_TableFormat()->GetEffective();
auto rowEffective = table->get_Row(0)->get_RowFormat()->GetEffective();
auto columnEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective();
auto cellEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective();

System::Console::WriteLine(System::String(u"Table fill: ") + System::ObjectExt::ToString(tableEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Row fill: ") + System::ObjectExt::ToString(rowEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Column fill: ") + System::ObjectExt::ToString(columnEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Final cell fill: ") + System::ObjectExt::ToString(cellEffective->get_FillFormat()->get_FillType()));

presentation->Dispose();
```

Si necesita el color y no solo el tipo de relleno, primero compruebe el **[FillType](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifillformateffectivedata/)** efectivo y, a continuación, lea la propiedad que corresponde a ese tipo —por ejemplo, **[SolidFillColor](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifillformateffectivedata/)** para un relleno sólido.

## **Volver a leer datos efectivos después de los cambios**

Los datos efectivos describen la jerarquía de formato en el momento en que se resuelve. Llame a `GetEffective` nuevamente después de cambiar cualquier elemento que pueda participar en esa jerarquía, incluidos:

- el formato local del objeto;
- los valores predeterminados de párrafo o de marco de texto;
- el estilo de tabla, la tabla, la columna, la fila o el formato de celda;
- el formato de diseño o de diapositiva maestra;
- los datos del tema o los valores predeterminados a nivel de presentación;
- el diseño o la maestra asignados a una diapositiva.

No conserve un objeto de datos efectivo como una instantánea permanente. Aspose.Slides puede almacenar en caché algunos datos efectivos internamente, y una llamada posterior a `GetEffective` puede actualizar esos datos. Si necesita comparar valores antes y después de un cambio, copie los valores escalares que necesite —como altura de fuente, color, alineación o ancho de bisel— en sus propias variables antes de efectuar el cambio.

Para cambiar un valor, actualice el objeto de formato local correspondiente y, a continuación, llame a `GetEffective` para verificar el resultado. Los objetos de datos efectivos son de solo lectura.

## **FAQ**

**¿Cómo puedo saber qué nivel proporcionó un valor efectivo?**

Los datos efectivos contienen el valor final, no su origen. Inspeccione los objetos locales aplicables desde el nivel más específico hacia afuera. Para el texto, esto puede incluir la porción, el párrafo, el marco de texto, el diseño, la maestra, el tema y los valores predeterminados de la presentación. Los valores indefinidos como `std::numeric_limits<float>::quiet_NaN()` o `nullptr` indican que la búsqueda continúa a otro nivel.

**¿Qué ocurre cuando ningún nivel define una propiedad?**

Aspose.Slides resuelve el valor predeterminado apropiado de PowerPoint o de la biblioteca. Ese valor resuelto aparece en los datos efectivos aunque ningún objeto local lo haya definido explícitamente.

**¿Por qué a veces un valor efectivo coincide con el valor local?**

El valor local ganó el cálculo de herencia. Esto es esperable cuando la propiedad está establecida explícitamente en el objeto y ninguna regla más específica la sobrescribe.

**¿Cuándo debo usar datos locales en lugar de datos efectivos?**

Use datos locales para inspeccionar o editar un nivel de formato específico. Use datos efectivos cuando necesite la apariencia final después de que la herencia, las reglas del tema y los estilos aplicables se hayan resuelto. El **[ejemplo completo de comparación](#compare-local-inherited-and-effective-values)** muestra ambos en el mismo flujo de trabajo.