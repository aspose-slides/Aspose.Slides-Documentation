---
title: Gestionar tablas de presentación en C++
linktitle: Gestionar tabla
type: docs
weight: 10
url: /es/cpp/manage-table/
keywords:
- añadir tabla
- crear tabla
- acceder tabla
- relación de aspecto
- alinear texto
- formato de texto
- estilo de tabla
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Crear y editar tablas en diapositivas de PowerPoint con Aspose.Slides para C++. Descubra ejemplos de código simples para optimizar sus flujos de trabajo con tablas."
---
## **Introducción**

Las tablas en PowerPoint organizan la información en filas y columnas, lo que facilita la lectura y la comparación de valores.

Aspose.Slides proporciona la clase [Tabla](https://reference.aspose.com/slides/cpp/aspose.slides/table/), la interfaz [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/), la clase [Celda](https://reference.aspose.com/slides/cpp/aspose.slides/cell/), la interfaz [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) y otros tipos que le permiten crear, actualizar y gestionar tablas en presentaciones.

## **Crear una tabla desde cero**

Cree una tabla especificando su posición, los anchos de columna y las alturas de fila. Después de añadirla a una diapositiva, puede dar formato a los bordes de las celdas, combinar celdas e insertar texto.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtenga una referencia a la diapositiva por su índice.
3. Defina una matriz con los anchos de columna en puntos.
4. Defina una matriz con las alturas de fila en puntos.
5. Añada un objeto [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) a la diapositiva mediante el método [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
6. Itere a través de cada [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) para aplicar formato a los bordes superior, inferior, derecho e izquierdo.
7. Combine las dos primeras celdas de la primera fila de la tabla.
8. Acceda a la celda combinada mediante su método [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/).
9. Establezca el texto en la celda combinada.
10. Guarde la presentación modificada.

El ejemplo siguiente crea una tabla con tres columnas y cinco filas en la posición (100, 50) puntos. Aplica bordes rojos con un grosor de 5 puntos, combina las dos primeras celdas de la primera fila y guarda el resultado como `table.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 50, 50, 50 });
auto rowHeights = System::MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 0), false);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Merged Cells");

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Numeración en una tabla estándar**

En una tabla estándar, los índices de las celdas comienzan en cero y se usan en el orden (columna, fila). La primera celda tiene el índice (0, 0).

Por ejemplo, las celdas de una tabla con 4 columnas y 4 filas se numeran de la siguiente manera:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este ejemplo crea la tabla 4 × 4 ilustrada arriba, con anchos de columna y alturas de fila de 70 puntos y bordes de celda rojos con un grosor de 5 puntos. Las coordenadas ilustran los índices de las celdas; el ejemplo deja las celdas vacías y guarda la tabla como `StandardTables_out.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 70, 70, 70, 70 });
auto rowHeights = System::MakeArray<double>({ 70, 70, 70, 70 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();
        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

presentation->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Acceder a una tabla existente**

Las tablas se almacenan en la colección de formas de una diapositiva. Recorrga las formas para localizar una tabla y, a continuación, utilice la interfaz [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) para leer o actualizar sus celdas.

1. Cargue la presentación mediante la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtenga una referencia a la diapositiva que contiene la tabla por su índice.
3. Recorrga los objetos [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) y deténgase cuando se encuentre una tabla. Si la diapositiva contiene varias tablas, utilice [get_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_alternativetext/) para identificar la que necesita.
4. Actualice el texto de la celda objetivo.
5. Guarde la presentación modificada.

El ejemplo siguiente abre `UpdateExistingTable.pptx` y encuentra la primera tabla en la primera diapositiva. Establece la celda en la columna 0, fila 1 a `New` y guarda el resultado como `table1_out.pptx`. La entrada debe contener al menos una diapositiva, y la primera tabla de esa diapositiva debe tener al menos una columna y dos filas.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");
auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (const auto& shape : System::IterateOver(slide->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shape))
    {
        table = System::ExplicitCast<ITable>(shape);
        break;
    }
}

if (table != nullptr)
{
    table->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");
    presentation->Save(u"table1_out.pptx", SaveFormat::Pptx);
}
```

Para cambiar el tamaño de una fila en una tabla existente y comprender por qué su altura real puede superar la mínima solicitada, consulte [Control Row Height](/slides/es/cpp/manage-rows-and-columns/#control-row-height).

## **Encontrar la celda que posee un marco de texto**

Cuando el código genérico de procesamiento de texto recibe un [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) de una tabla, use [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) para obtener la [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) propietaria. Para el marco de texto de una celda de tabla, [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) devuelve al propietario y [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentshape/) devuelve `nullptr`, aunque la tabla en sí sea una forma.

Las coordenadas de la celda están disponibles a través de los métodos de solo lectura [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) y [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/). [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) también proporciona navegación de solo lectura: devuelve al propietario pero no cambia la propiedad. Siempre verifique que la celda devuelta no sea `nullptr` antes de usarla.

Para un ejemplo completo que identifica a los propietarios de celdas de tabla y de forma, incluidas las formas asociadas a nodos de SmartArt, consulte [Search and Replace Text](/slides/es/cpp/search-and-replace-text/).

## **Alinear texto en una tabla**

Puede controlar el anclaje vertical y la dirección del texto de celdas de tabla individuales. El ejemplo de esta sección centra el texto dentro de la primera celda y lo rota 270 grados.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtenga una referencia a la diapositiva por su índice.
3. Añada un objeto [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) a la diapositiva.
4. Acceda a un objeto [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) de la tabla.
5. Acceda al primer [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) y establezca su texto y color.
6. Defina el anclaje vertical y la dirección del texto de la celda mediante [set_TextAnchorType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textanchortype/) y [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textverticaltype/).
7. Guarde la presentación modificada.

Este ejemplo crea una tabla 4 × 4 con anchos de columna de 120 puntos y alturas de fila de 100 puntos. Da formato al texto en la celda (0, 0), añade valores a las celdas restantes de la primera fila y guarda el resultado como `Vertical_Align_Text_out.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 120, 120, 120, 120 });
auto rowHeights = System::MakeArray<double>({ 100, 100, 100, 100 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

auto cell = table->idx_get(0, 0);
auto paragraph = cell->get_TextFrame()->get_Paragraphs()->idx_get(0);

auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Establecer formato de texto a nivel de tabla**

Utilice [SetTextFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulktextformattable/settextformat/) para aplicar formato de texto a todas las celdas de una tabla. Sus sobrecargas aceptan formato de porción, párrafo y marco de texto, por lo que puede establecer estas propiedades sin iterar por celdas individuales.

1. Cargue la presentación mediante la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtenga una referencia a la diapositiva por su índice.
3. Acceda a un objeto [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) de la diapositiva.
4. Establezca el tamaño de la fuente usando [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) para el texto.
5. Defina la alineación del párrafo y el margen derecho mediante [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) y [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/).
6. Establezca la dirección del texto con [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. Guarde la presentación modificada.

El ejemplo siguiente abre `table.pptx`, que debe contener al menos una diapositiva con una tabla como su primera forma. Establece el tamaño de fuente a 25 puntos, alinea a la derecha los párrafos con un margen derecho de 20 puntos y hace que el texto sea vertical. La presentación formateada se guarda como `result.pptx`.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
table->SetTextFormat(portionFormat);

auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
table->SetTextFormat(paragraphFormat);

auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Obtener propiedades de estilo de tabla**

Use [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) para leer el estilo predefinido de una tabla y [set_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_stylepreset/) para asignarlo. Este ejemplo aplica [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) a una tabla, muestra el nombre del preset y asigna el mismo preset a una segunda tabla. Ambas tablas se guardan en `table-style.pptx`.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 100, 150 });
auto rowHeights = System::MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

auto stylePreset = table->get_StylePreset();
System::Console::WriteLine(u"Table style preset: {0}", stylePreset);

auto anotherTable = slide->get_Shapes()->AddTable(10, 100, columnWidths, rowHeights);
anotherTable->set_StylePreset(stylePreset);

presentation->Save(u"table-style.pptx", SaveFormat::Pptx);
```

## **Bloquear la relación de aspecto de una tabla**

La relación de aspecto de una tabla es la proporción entre su anchura y su altura. Utilice [set_AspectRatioLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/set_aspectratiolocked/) para bloquear esta proporción en una tabla.

El ejemplo siguiente abre `pres.pptx`, que debe contener al menos una diapositiva con una tabla como su primera forma. Muestra el estado actual del bloqueo, habilita el bloqueo de la relación de aspecto, muestra el estado actualizado (`True`) y guarda el resultado como `pres-out.pptx`.

```cpp
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

table->get_GraphicalObjectLock()->set_AspectRatioLocked(true);
Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

presentation->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **Preguntas frecuentes**

**¿Puedo habilitar la dirección de lectura de derecha a izquierda (RTL) para toda una tabla y el texto de sus celdas?**

Sí. La tabla expone un método [set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/table/set_righttoleft/), y los párrafos tienen [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_righttoleft/). Usar ambos garantiza el orden RTL correcto y la representación dentro de las celdas.

**¿Cómo puedo evitar que los usuarios muevan o redimensionen una tabla en el archivo final?**

Utilice [bloqueos de forma](/slides/es/cpp/applying-protection-to-presentation/) para desactivar el movimiento, el redimensionado, la selección, etc. Estos bloqueos se aplican también a las tablas.

**¿Se admite insertar una imagen dentro de una celda como fondo?**

Sí. Puede establecer un [relleno de imagen](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) para una celda; la imagen cubrirá el área de la celda según el modo elegido (estirar o mosaico).