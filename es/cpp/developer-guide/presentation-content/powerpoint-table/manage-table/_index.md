---
title: Gestionar tablas de presentación en C++
linktitle: Gestionar tabla
type: docs
weight: 10
url: /es/cpp/manage-table/
keywords:
- añadir tabla
- crear tabla
- acceder a tabla
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

Una tabla en PowerPoint es una forma eficaz de mostrar y representar información. La información en una cuadrícula de celdas (dispuestas en filas y columnas) es directa y fácil de entender.

Aspose.Slides proporciona la clase [Table](https://reference.aspose.com/slides/es/cpp/aspose.slides/table/), la interfaz [ITable](https://reference.aspose.com/slides/es/cpp/aspose.slides/itable/), la clase [Cell](https://reference.aspose.com/slides/es/cpp/aspose.slides/cell/), la interfaz [ICell](https://reference.aspose.com/slides/es/cpp/aspose.slides/icell/) y otros tipos que le permiten crear, actualizar y gestionar tablas en todo tipo de presentaciones. 

## **Crear una tabla desde cero**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Obtenga la referencia de una diapositiva a través de su índice. 
3. Defina una matriz de `columnWidth`.
4. Defina una matriz de `rowHeight`.
5. Añada un objeto [ITable](https://reference.aspose.com/slides/es/cpp/aspose.slides/itable/) a la diapositiva mediante el método [AddTable()](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishapecollection/addtable/).
6. Itere a través de cada [ICell](https://reference.aspose.com/slides/es/cpp/aspose.slides/icell/) para aplicar formato a los bordes superior, inferior, derecho e izquierdo.
7. Combine las dos primeras celdas de la primera fila de la tabla. 
8. Acceda al [TextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/textframe/) de un [ICell](https://reference.aspose.com/slides/es/cpp/aspose.slides/icell/). 
9. Añada texto al [TextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/textframe/).
10. Guarde la presentación modificada.

Este código C++ le muestra cómo crear una tabla en una presentación:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// Instancia una clase Presentation que representa un archivo PPTX
auto pres = System::MakeObject<Presentation>();

// Accede a la primera diapositiva
auto sld = pres->get_Slides()->idx_get(0);

// Define columnas con anchos y filas con alturas
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// Añade una forma de tabla a la diapositiva
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Establece el formato del borde para cada celda
for (int32_t row = 0; row < tbl->get_Rows()->get_Count(); row++)
{
    for (int32_t cell = 0; cell < tbl->get_Rows()->idx_get(row)->get_Count(); cell++)
    {
        auto cellFormat = tbl->get_Rows()->idx_get(row)->idx_get(cell)->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType((FillType::Solid));
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
// Fusiona las celdas 1 y 2 de la fila 1
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// Añade texto a la celda fusionada
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// Guarda la presentación en disco
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Numeración en una tabla estándar**

En una tabla estándar, la numeración de las celdas es sencilla y comienza en cero. La primera celda de una tabla se indexa como 0,0 (columna 0, fila 0). 

Por ejemplo, las celdas de una tabla con 4 columnas y 4 filas se numeran de la siguiente manera:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este código C++ le muestra cómo especificar la numeración de las celdas en una tabla:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// Instancia una clase Presentation que representa un archivo PPTX
auto pres = System::MakeObject<Presentation>();

// Accede a la primera diapositiva
auto sld = pres->get_Slides()->idx_get(0);

// Define columnas con anchos y filas con alturas
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// Añade una forma de tabla a la diapositiva
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Establece el formato del borde para cada celda
for (const auto& row : tbl->get_Rows())
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

// Guarda la presentación en disco
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Acceder a una tabla existente**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).

2. Obtenga una referencia a la diapositiva que contiene la tabla mediante su índice. 

3. Cree un objeto [ITable](https://reference.aspose.com/slides/es/cpp/aspose.slides/itable/) y establézcalo a null.

4. Itere a través de todos los objetos [IShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/) hasta que se encuentre la tabla.

   Si sospecha que la diapositiva con la que está trabajando contiene una única tabla, puede simplemente comprobar todas las formas que contiene. Cuando una forma se identifica como una tabla, puede convertirla a un objeto [Table](https://reference.aspose.com/slides/es/cpp/aspose.slides/table/). Pero si la diapositiva contiene varias tablas, es mejor buscar la tabla que necesita mediante su [set_AlternativeText()](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/set_alternativetext/).

5. Utilice el objeto [ITable](https://reference.aspose.com/slides/es/cpp/aspose.slides/itable/) para trabajar con la tabla. En el ejemplo a continuación, añadimos una nueva fila a la tabla.

6. Guarde la presentación modificada.

Este código C++ le muestra cómo acceder y trabajar con una tabla existente:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Instancia una clase Presentation que representa un archivo PPTX
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// Accede a la primera diapositiva
auto sld = pres->get_Slides()->idx_get(0);

// Inicializa una tabla nula
System::SharedPtr<ITable> tbl;

// Itera a través de las formas y establece una referencia a la tabla encontrada
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Establece el texto para la primera columna de la segunda fila
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// Guarda la presentación modificada en disco
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **Encontrar la celda que posee un marco de texto**

Cuando el código genérico de procesamiento de texto recibe un [ITextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/) de una tabla, utilice [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/get_parentcell/) para recuperar la [ICell] propietaria. Para un marco de texto de celda de tabla, [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/get_parentcell/) devuelve el propietario y [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/get_parentshape/) devuelve `nullptr`, aunque la tabla en sí es una forma.

Las coordenadas de la celda están disponibles mediante los métodos de solo lectura [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/es/cpp/aspose.slides/icell/get_firstcolumnindex/) y [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/es/cpp/aspose.slides/icell/get_firstrowindex/). [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/get_parentcell/) también ofrece navegación de solo lectura: devuelve el propietario pero no cambia la titularidad. Siempre verifique que la celda devuelta no sea `nullptr` antes de usarla.

Para un ejemplo completo que identifica propietarios de celdas de tabla y de formas, incluidas las formas asociadas a nodos de SmartArt, vea [Search and Replace Text](/slides/es/cpp/search-and-replace-text/).

## **Alinear texto en una tabla**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Obtenga la referencia de una diapositiva a través de su índice. 
3. Añada un objeto [ITable](https://reference.aspose.com/slides/es/cpp/aspose.slides/itable/) a la diapositiva. 
4. Acceda a un objeto [ITextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/) de la tabla. 
5. Acceda al [IParagraph](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraph/) del [ITextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/).
6. Alinee el texto verticalmente.
7. Guarde la presentación modificada.

Este código C++ le muestra cómo alinear el texto en una tabla:

```c++
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
#include <DOM/ISlideCollection.h>
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

// Crea una instancia de la clase Presentation
auto presentation = System::MakeObject<Presentation>();

// Obtiene la primera diapositiva
auto slide = presentation->get_Slides()->idx_get(0);

// Define columnas con anchos y filas con alturas
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// Añade la forma de tabla a la diapositiva
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// Accede al marco de texto
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// Crea el objeto Paragraph para el marco de texto
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Crea el objeto Portion para el párrafo
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Alinea el texto verticalmente
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// Guarda la presentación en disco
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Establecer formato de texto a nivel de tabla**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Obtenga la referencia de una diapositiva a través de su índice. 
3. Acceda a un objeto [ITable](https://reference.aspose.com/slides/es/cpp/aspose.slides/itable/) de la diapositiva.
4. Establezca la [set_FontHeight()](https://reference.aspose.com/slides/es/cpp/aspose.slides/baseportionformat/set_fontheight/) para el texto. 
5. Establezca la [set_Alignment()](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphformat/set_alignment/) y la [set_MarginRight()](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. Establezca la [set_TextVerticalType()](https://reference.aspose.com/slides/es/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. Guarde la presentación modificada. 

Este código C++ le muestra cómo aplicar sus opciones de formato preferidas al texto en una tabla:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// Crea una instancia de la clase Presentation
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// Supongamos que la primera forma de la primera diapositiva es una tabla
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// Establece la altura de fuente de las celdas de la tabla
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// Establece la alineación del texto y el margen derecho de las celdas de la tabla en una sola llamada
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// Establece el tipo de orientación vertical del texto de las celdas de la tabla
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Obtener propiedades de estilo de tabla**

Aspose.Slides le permite recuperar las propiedades de estilo de una tabla para que pueda usar esos detalles en otra tabla o en otro lugar. Este código C++ le muestra cómo obtener las propiedades de estilo de un estilo predefinido de tabla:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Bloquear proporción de aspecto de una tabla**

La proporción de aspecto de una forma geométrica es la relación entre sus dimensiones. Aspose.Slides proporciona la propiedad `AspectRatioLocked()` para permitirle bloquear la configuración de proporción de aspecto para tablas y otras formas. 

Este código C++ le muestra cómo bloquear la proporción de aspecto para una tabla:

```c++
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **Preguntas frecuentes**

**¿Puedo habilitar la dirección de lectura de derecha a izquierda (RTL) para toda la tabla y el texto en sus celdas?**

Sí. La tabla expone el método [set_RightToLeft](https://reference.aspose.com/slides/es/cpp/aspose.slides/table/set_righttoleft/), y los párrafos tienen [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/es/cpp/aspose.slides/paragraphformat/set_righttoleft/). Usar ambos garantiza el orden RTL correcto y la renderización dentro de las celdas.

**¿Cómo puedo evitar que los usuarios muevan o cambien el tamaño de una tabla en el archivo final?**

Utilice [shape locks](/slides/es/cpp/applying-protection-to-presentation/) para desactivar el movimiento, el cambio de tamaño, la selección, etc. Estos bloqueos también se aplican a las tablas.

**¿Se admite insertar una imagen dentro de una celda como fondo?**

Sí. Puede establecer un [picture fill](https://reference.aspose.com/slides/es/cpp/aspose.slides/picturefillformat/) para una celda; la imagen cubrirá el área de la celda según el modo elegido (estirado o mosaico).