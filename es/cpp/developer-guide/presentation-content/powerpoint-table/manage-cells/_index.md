---
title: Gestionar celdas de tabla en presentaciones con C++
linktitle: Gestionar celdas
type: docs
weight: 30
url: /es/cpp/manage-cells/
keywords:
- celda de tabla
- fusionar celdas
- eliminar borde
- dividir celda
- imagen en celda
- color de fondo
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Gestiona celdas de tabla de PowerPoint en C++: identifica celdas fusionadas, elimina bordes, divide celdas y establece colores de fondo e imágenes con Aspose.Slides para C++."
---
## **Visión general**

Aspose.Slides permite acceder y modificar celdas de tabla en presentaciones de PowerPoint. Este artículo explica cómo identificar celdas de tabla fusionadas, eliminar bordes de celdas, trabajar con la numeración de celdas después de fusionar o dividir celdas, cambiar el color de fondo de una celda y añadir una imagen dentro de una celda de tabla. Los ejemplos muestran cómo crear o abrir una presentación, obtener una tabla de una diapositiva, actualizar el formato de la celda mediante sus propiedades y guardar la presentación modificada como archivo PPTX.

Aspose.Slides utiliza índices basados en cero para acceder a las celdas de tabla en el orden `(columna, fila)`.

## **Identificar una celda de tabla fusionada**

El ejemplo abre una presentación existente y accede a la primera forma de la primera diapositiva como una tabla. Supone que la diapositiva y la forma existen y que la forma es una tabla. A continuación recorre todas las filas y columnas y utiliza [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) para identificar celdas en regiones fusionadas. Para cada coincidencia, imprime las coordenadas de la celda en orden `fila;columna`, [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/), [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/) y las coordenadas iniciales de la región, [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) y [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/).

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_table.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto rowCount = table->get_Rows()->get_Count();
for (auto rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    auto columnCount = table->get_Columns()->get_Count();
    for (auto columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        auto cell = table->idx_get(columnIndex, rowIndex);
        if (cell->get_IsMergedCell())
        {
            Console::WriteLine(u"Cell {0};{1} belongs to a merged region with RowSpan={2} and ColSpan={3} starting at {4};{5}.", rowIndex, columnIndex, cell->get_RowSpan(), cell->get_ColSpan(), cell->get_FirstRowIndex(), cell->get_FirstColumnIndex());
        }
    }
}
```

## **Eliminar bordes de celdas de tabla**

Cree una [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) y añada una tabla a su primera diapositiva con [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/). Los anchos de columna, alturas de fila y la posición de la tabla se especifican en puntos. El ejemplo establece los cuatro bordes de la celda a [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/), haciéndolos invisibles.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <system/enumerator_adapter.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({50, 50, 50, 50});
auto rowHeights = MakeArray<double>({50, 30, 30, 30, 30});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

for (const auto& row : IterateOver(table->get_Rows()))
    for (const auto& cell : IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Fusionar celdas de tabla**

Utilice [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) para combinar un rango rectangular de celdas de tabla en una sola celda. Especifique las celdas en las esquinas superior‑izquierda e inferior‑derecha del rango. El último argumento controla si la fusión puede incluir celdas fuera del rango especificado; `false` mantiene la fusión dentro de ese rango.

El ejemplo crea una tabla de 4 × 4 con columnas y filas de 70 puntos, luego fusiona las cuatro celdas centrales desde `(1, 1)` hasta `(2, 2)`. La celda resultante abarca dos columnas y dos filas, mientras que la cuadrícula subyacente de la tabla sigue teniendo cuatro columnas y cuatro filas. Para acceder al contenido o formato de la celda fusionada, utilice su posición superior‑izquierda: `table->idx_get(1, 1)` en este ejemplo. Las demás posiciones del rango fusionado siguen formando parte de la cuadrícula de la tabla, por lo que los índices de las celdas fuera del rango no cambian.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 2), false);

presentation->Save(u"merged_cells.pptx", SaveFormat::Pptx);
```

## **Dividir celdas de tabla**

Fusionar celdas en el ejemplo anterior conserva la cuadrícula de la tabla. Dividir una celda puede introducir una nueva columna en la cuadrícula y cambiar los índices de columna de las celdas que están a su derecha. Aspose.Slides sigue el modelo de cuadrícula de tablas de PowerPoint.

Este ejemplo crea una tabla de 4 × 4 con columnas y filas de 70 puntos y llama a [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) sobre la celda `(1, 1)`. La mitad del ancho de 70 puntos de la celda se pasa para crear dos celdas de ancho igual.

Tras esta división, las dos mitades se acceden como `table->idx_get(1, 1)` y `table->idx_get(2, 1)`. La cuadrícula de la tabla ahora tiene cinco columnas: las celdas originalmente en las columnas 2 y 3 se desplazan a las columnas 3 y 4, respectivamente. Los índices de fila permanecen sin cambios. Utilice estos índices de columna actualizados al acceder a las celdas después de la división.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(1, 1)->SplitByWidth(table->idx_get(1, 1)->get_Width() / 2);

presentation->Save(u"split_cells.pptx", SaveFormat::Pptx);
```

### **Dividir celdas fusionadas por extensión de fila o columna**

Para preparar celdas de plantilla fusionadas para la población de datos, utilice [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) para dividir a lo largo de un límite de fila existente, o [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) para dividir a lo largo de un límite de columna.

El argumento `index` cuenta filas en la parte superior o columnas en la parte izquierda de la división; es relativo a la región fusionada:

- División de fila: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).
- División de columna: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

El ejemplo asume que una presentación tiene una tabla como primera forma en la primera diapositiva, con `(1, 2)` y `(1, 3)` fusionados verticalmente. Partiendo de la posición inferior, utiliza [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) y [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) para localizar el origen y comprueba ambas extensiones. `SplitByRowSpan(1)` separa entonces las filas 2 y 3 para los nombres de producto. Para una fusión horizontal de dos columnas, use `SplitByColSpan(1)` en su lugar.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table_template.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto selectedCell = table->idx_get(1, 3);
auto firstColumnIndex = selectedCell->get_FirstColumnIndex();
auto firstRowIndex = selectedCell->get_FirstRowIndex();
auto mergedCell = table->idx_get(firstColumnIndex, firstRowIndex);

if (mergedCell->get_IsMergedCell() && mergedCell->get_RowSpan() == 2 && mergedCell->get_ColSpan() == 1)
{
    mergedCell->SplitByRowSpan(1);

    // Obtenga las celdas resultantes de la tabla después de dividir.
    auto upperCell = table->idx_get(firstColumnIndex, firstRowIndex);
    auto lowerCell = table->idx_get(firstColumnIndex, firstRowIndex + 1);
    Console::WriteLine(u"Upper cell merged: {0}", upperCell->get_IsMergedCell());
    Console::WriteLine(u"Lower cell merged: {0}", lowerCell->get_IsMergedCell());

    upperCell->get_TextFrame()->set_Text(u"Product A");
    lowerCell->get_TextFrame()->set_Text(u"Product B");

    presentation->Save(u"split_template.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Select a merged region spanning exactly two rows and one column.");
}
```

La cuadrícula de la tabla y los índices de las celdas circundantes permanecen sin cambios. Recupere las celdas resultantes por sus coordenadas; aquí, ambas tienen extensiones de 1 y [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) muestra `False`. Regiones mayores pueden quedar parcialmente fusionadas después de una división.

El texto original y su formato permanecen en la celda superior (o izquierda); la nueva celda está vacía pero hereda el formato de la celda, como relleno, bordes y márgenes. Complete las celdas después de dividirlas y establezca cualquier formato de texto requerido explícitamente.

La presentación guardada contiene celdas separadas “Product A” y “Product B” con el formato de celda de la plantilla conservado. Consulte la [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) para obtener más detalles.

## **Cambiar el color de fondo de la celda de tabla**

Este ejemplo crea una tabla con columnas de 150 puntos y filas de 50 puntos. Utiliza [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) para seleccionar un relleno sólido y [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) para acceder al color de relleno y establecerlo a rojo para la celda `(2, 3)`, en la tercera columna y cuarta fila.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <drawing/color.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({50, 50, 50, 50, 50});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"cell_background_color.pptx", SaveFormat::Pptx);
```

## **Añadir una imagen dentro de una celda de tabla**

Coloque la imagen de entrada en el directorio de trabajo antes de ejecutar este ejemplo. Carga la imagen con [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) y la añade a la colección de imágenes de la presentación con [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/). A continuación asigna la imagen al relleno de imagen de la celda `(0, 0)`, la primera celda de la tabla.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) estira la imagen para que ocupe toda la celda, lo que puede modificar su relación de aspecto. Los anchos de columna y alturas de fila están en puntos. La imagen cargada se elimina después de haberse añadido a la presentación.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IImageCollection.h>
#include <IImage.h>
#include <DOM/IPPImage.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Table/ICellFormat.h>
#include <Util/Images.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({100, 100, 100, 100, 90});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto image = Images::FromFile(u"aspose_logo.jpg");
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Picture);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

presentation->Save(u"table_cell_with_image.pptx", SaveFormat::Pptx);
```

## **FAQ**

**¿Puedo establecer diferentes grosores y estilos de línea para los distintos lados de una única celda?**

Sí. Los bordes [top](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) tienen propiedades independientes, por lo que el grosor y el estilo de cada lado pueden diferir.

**¿Qué ocurre con la imagen si cambio el tamaño de la columna/fila después de establecer una foto como fondo de la celda?**

El comportamiento depende del [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) (stretch/tile). Con estiramiento, la imagen se adapta a la nueva celda; con mosaico, los mosaicos se recalculan.

**¿Puedo asignar un hipervínculo a todo el contenido de una celda?**

[Hyperlinks](/slides/es/cpp/manage-hyperlinks/) se establecen a nivel de texto (porción) dentro del marco de texto de la celda o a nivel de toda la tabla/forma. En la práctica, asigna el enlace a una porción o a todo el texto de la celda.

**¿Puedo establecer distintas fuentes dentro de una misma celda?**

Sí. El marco de texto de una celda admite [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (runs) con formato independiente: familia, estilo, tamaño y color de fuente.