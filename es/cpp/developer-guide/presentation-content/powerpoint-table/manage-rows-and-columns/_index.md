---
title: "Gestionar filas y columnas en tablas de PowerPoint usando C++"
linktitle: "Filas y columnas"
type: docs
weight: 20
url: /es/cpp/manage-rows-and-columns/
keywords:
- fila de tabla
- columna de tabla
- primera fila
- encabezado de tabla
- clonar fila
- clonar columna
- copiar fila
- copiar columna
- eliminar fila
- eliminar columna
- formato de texto de fila
- formato de texto de columna
- estilo de tabla
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Gestiona filas y columnas de tablas en PowerPoint con Aspose.Slides para C++ y acelera la edición de presentaciones y la actualización de datos."
---
## **Introducción**

Aspose.Slides for C++ le permite gestionar la estructura y el formato de tablas en presentaciones de PowerPoint mediante la clase [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) y la interfaz [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/). Puede designar una fila de encabezado, clonar o eliminar filas y columnas, y aplicar formato de texto a una fila o columna completa.

Este artículo explica estas operaciones con ejemplos en C++. También muestra cómo obtener el estilo predefinido de una tabla para poder reutilizarlo. Los índices de filas y columnas de la tabla comienzan en cero.

## **Controlar la altura de la fila**

Utilice [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) para establecer la altura mínima de una fila en puntos. Es un límite inferior, no una altura fija. [IRow::get_Height](https://reference.aspose.com/slides/cpp/aspose.slides/irow/get_height/) devuelve la altura real; este valor no puede establecerse directamente. Acceda a la fila a través de [ITable::get_Rows](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_rows/).

El ejemplo carga [row-height-input.pptx](row-height-input.pptx), que tiene una tabla como la primera forma en la primera diapositiva. Su primera fila comienza en 70 puntos. Las celdas usan texto Arial de 18 puntos, ajuste y márgenes superior e inferior de 6 puntos; el texto más largo en la segunda columna se ajusta en varias líneas. El ejemplo aumenta el mínimo a 100 puntos, luego lo reduce a 20 puntos, imprime la altura real después de cada cambio y guarda ambos resultados.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRow.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"row-height-input.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
auto row = table->get_Rows()->idx_get(0);

row->set_MinimalHeight(100);
Console::WriteLine(u"Increased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-increased.pptx", SaveFormat::Pptx);

row->set_MinimalHeight(20);
Console::WriteLine(u"Decreased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-decreased.pptx", SaveFormat::Pptx);
```

Con la presentación suministrada, aumentar el mínimo añade espacio a la fila. Reducirlo elimina ese espacio adicional, pero la altura real permanece superior a 20 puntos porque el texto y los márgenes de celda necesitan más espacio. Reducir solo el mínimo no puede forzar a la fila a quedar por debajo del espacio requerido por su contenido.

Varios factores influyen en la altura real:

- **Texto y tamaño de fuente:** texto más largo, saltos de línea explícitos o una fuente mayor pueden requerir más espacio vertical.
- **Ajuste y ancho de columna:** con el ajuste habilitado, reducir el ancho de la columna con [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) puede generar más líneas. Una columna más ancha puede reducir el espacio necesario verticalmente.
- **Márgenes de celda:** [ICell::set_MarginTop](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_margintop/) y [ICell::set_MarginBottom](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginbottom/) controlan los márgenes que añaden espacio vertical. [ICell::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginleft/) y [ICell::set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginright/) controlan los márgenes que reducen el ancho disponible para el texto y pueden provocar un ajuste adicional.

Para esta tabla sin celdas combinadas, la celda que necesita más espacio vertical determina el límite inferior impulsado por el contenido para toda la fila. Para acortar la fila, quizá también deba acortar el texto, reducir el tamaño de fuente o los márgenes, o ampliar una columna.

Las imágenes a continuación muestran la misma tabla a la misma escala. En la ejecución de referencia .NET mostrada aquí, las alturas reales fueron 70, 100 y 55.2 puntos: la fila final siguió siendo más alta que su mínimo de 20 puntos. Las mediciones exactas del texto pueden variar con las fuentes disponibles en su entorno. Descargue los resultados guardados: [increased minimum](row-height-increased.pptx) y [decreased minimum](row-height-decreased.pptx).

| Original: mínimo 70 pt, real 70 pt | Aumentado: mínimo 100 pt, real 100 pt | Disminuido: mínimo 20 pt, real 55.2 pt |
| --- | --- | --- |
| ![Tabla original con una primera fila de 70 puntos.](row-height-before.png) | ![Tabla después de aumentar el mínimo de la primera fila a 100 puntos.](row-height-increased.png) | ![Tabla después de reducir el mínimo de la primera fila a 20 puntos; el texto ajustado mantiene la fila más alta que el mínimo.](row-height-decreased.png) |

## **Establecer la primera fila como encabezado**

Utilice el método [set_FirstRow](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_firstrow/) para marcar la primera fila como encabezado. Su apariencia depende del estilo de tabla aplicado.

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Acceda a la primera diapositiva.
3. Acceda a la tabla almacenada como la primera forma en la diapositiva.
4. Habilite el formato de encabezado para su primera fila.
5. Guarde la presentación modificada.

El ejemplo requiere `table.pptx` con una tabla como la primera forma en la primera diapositiva. Habilita el formato de encabezado para la primera fila y guarda `First_row_header.pptx`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
table->set_FirstRow(true);

presentation->Save(u"First_row_header.pptx", SaveFormat::Pptx);
```

## **Clonar una fila o columna de tabla**

Clone filas o columnas para reutilizar su contenido y formato. Puede añadir una copia al final de la tabla o insertarla en una posición específica.

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Acceda a la primera diapositiva.
3. Defina los anchos de columna y las alturas de fila.
4. Añada una tabla con el método [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
5. Clone las filas requeridas.
6. Clone las columnas requeridas.
7. Guarde la presentación modificada.

El ejemplo requiere `Test.pptx` con al menos una diapositiva. Crea una tabla con tres columnas y cinco filas, con dimensiones especificadas en puntos. Añade copias de la primera fila y columna, luego inserta copias de la segunda fila y columna en el índice 3 (la cuarta posición). La tabla resultante tiene siete filas y cinco columnas. El argumento `false` desactiva la clonación en filas o columnas combinadas adyacentes; esta tabla no tiene celdas combinadas.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 50, 50, 50 });
auto rowHeights = MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 1");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 2");
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

table->idx_get(0, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 1");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 2");
table->get_Rows()->InsertClone(3, table->get_Rows()->idx_get(1), false);

table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);
table->get_Columns()->InsertClone(3, table->get_Columns()->idx_get(1), false);

presentation->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **Eliminar una fila o columna de una tabla**

Elimine filas o columnas que ya no son necesarias en una tabla. Eliminar un elemento desplaza los índices de las filas o columnas que le siguen.

1. Cree una presentación con la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Acceda a la primera diapositiva.
3. Defina los anchos de columna y las alturas de fila.
4. Añada una tabla con el método [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
5. Elimine la segunda fila y la segunda columna.
6. Guarde la presentación modificada.

Este ejemplo crea una tabla de tres por tres y elimina la fila y la columna en el índice 1, dejando una tabla de dos por dos en `TestTable_out.pptx`. Las dimensiones están en puntos. El argumento `false` desactiva la eliminación de filas o columnas combinadas adyacentes; esta tabla no tiene celdas combinadas.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 50, 30 });
auto rowHeights = MakeArray<double>({ 30, 50, 30 });
auto table = slide->get_Shapes()->AddTable(100, 100, columnWidths, rowHeights);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);

presentation->Save(u"TestTable_out.pptx", SaveFormat::Pptx);
```

## **Establecer formato de texto a nivel de fila de tabla**

Aplique formato de texto a toda una fila para mantener la coherencia de sus celdas. Puede establecer propiedades de fuente, formato de párrafo y dirección del texto sin formatear cada celda individualmente.

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Acceda a la tabla en la primera diapositiva.
3. Establezca la altura de la fuente con [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) para la primera fila.
4. Establezca la alineación y el margen derecho del párrafo con [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) y [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) para la primera fila.
5. Establezca la dirección del texto con [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) para la segunda fila.
6. Guarde la presentación modificada.

El ejemplo requiere `table.pptx` con una tabla como la primera forma en la primera diapositiva y al menos dos filas. Aplica texto de 25 puntos, alineación a la derecha y un margen derecho del párrafo de 20 puntos a la primera fila, luego establece texto vertical en la segunda fila.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IRow.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"row_formatting.pptx", SaveFormat::Pptx);
```

## **Establecer formato de texto a nivel de columna de tabla**

Aplique formato de texto a toda una columna para mantener la coherencia de sus celdas. Puede establecer propiedades de fuente, formato de párrafo y dirección del texto sin formatear cada celda individualmente.

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Acceda a la tabla en la primera diapositiva.
3. Establezca la altura de la fuente con [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) para la primera columna.
4. Establezca la alineación y el margen derecho del párrafo con [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) y [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) para la primera columna.
5. Establezca la dirección del texto con [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) para la segunda columna.
6. Guarde la presentación modificada.

El ejemplo requiere `table.pptx` con una tabla como la primera forma en la primera diapositiva y al menos dos columnas. Aplica texto de 25 puntos, alineación a la derecha y un margen derecho del párrafo de 20 puntos a la primera columna, luego establece texto vertical en la segunda columna.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IColumn.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"column_formatting.pptx", SaveFormat::Pptx);
```

## **Obtener propiedades del estilo de tabla**

Utilice el método [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) para recuperar el estilo predefinido aplicado a una tabla y reutilizarlo en otra tabla. Esto identifica el preset en lugar de las sobrescrituras de formato de celdas individuales.

El ejemplo crea una tabla, aplica [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) y lee el preset nuevamente. Imprime `DarkStyle1` y guarda la tabla en `table.pptx`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <DOM/TableStylePreset.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 150 });
auto rowHeights = MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

Console::WriteLine(u"{0}", table->get_StylePreset());

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Preguntas frecuentes**

**¿Puedo aplicar temas/estilos de PowerPoint a una tabla que ya está creada?**

Sí. La tabla hereda el tema de la diapositiva/disposición/maestra, y aún puede anular los rellenos, bordes y colores de texto sobre ese tema.

**¿Puedo ordenar filas de tabla como en Excel?**

No, las tablas de Aspose.Slides no disponen de ordenación ni filtros integrados. Ordene sus datos en memoria primero y, a continuación, vuelva a poblar las filas de la tabla en ese orden.

**¿Puedo tener columnas con bandas (a rayas) manteniendo colores personalizados en celdas específicas?**

Sí. Active las columnas con bandas y, después, sobrescriba celdas específicas con formato local; el formato a nivel de celda tiene prioridad sobre el estilo de tabla.