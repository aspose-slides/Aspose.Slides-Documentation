---
title: Personalizar tablas de datos de gráficos en presentaciones usando C++
linktitle: Tabla de datos
type: docs
url: /es/cpp/chart-data-table/
keywords:
- datos de gráfico
- tabla de datos
- propiedades de fuente
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Personaliza las fuentes, los bordes y las claves de leyenda de la tabla de datos de gráficos en presentaciones de PowerPoint utilizando Aspose.Slides para C++."
---
## **Visión general**

Aspose.Slides for C++ le permite mostrar la tabla de datos de un gráfico y personalizar su formato de texto, bordes y claves de leyenda. Este artículo explica cómo habilitar la tabla, dar formato al texto, controlar cada tipo de borde y mostrar u ocultar las claves de leyenda. Los ejemplos guardan los gráficos configurados en archivos PPTX.

## **Establecer propiedades de fuente**

Para mostrar la tabla de datos de un gráfico, pase `true` a [IChart::set_HasDataTable](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichart/set_hasdatatable/). Utilice [IChart::get_ChartDataTable](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichart/get_chartdatatable/) para acceder a la tabla y configurar su formato de texto.

1. Cargue la presentación usando la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
1. Añada un gráfico de columnas agrupadas a la primera diapositiva.
1. Habilite la tabla de datos del gráfico.
1. Habilite texto en negrita con [IBasePortionFormat::set_FontBold](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibaseportionformat/set_fontbold/) y pase `20` a [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibaseportionformat/set_fontheight/) para texto de 20 puntos.
1. Guarde la presentación modificada.

El siguiente ejemplo requiere `test.pptx` en el directorio de trabajo con al menos una diapositiva. Añade un gráfico con datos predeterminados en la posición (50, 50), con un ancho de 600 puntos y una altura de 400 puntos. El `output.pptx` guardado contiene el gráfico con su tabla de datos habilitada y los ajustes de fuente especificados aplicados.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"test.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto portionFormat = chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat();
portionFormat->set_FontBold(NullableBool::True);
portionFormat->set_FontHeight(20.0f);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Personalizar bordes de la tabla de datos**

Habilite la tabla con [IChart::set_HasDataTable](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichart/set_hasdatatable/) y acceda a ella mediante [IChart::get_ChartDataTable](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichart/get_chartdatatable/). Puede controlar independientemente tres tipos de bordes:

- [IDataTable::set_HasBorderHorizontal](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/idatatable/set_hasborderhorizontal/) controla los bordes horizontales de las celdas.
- [IDataTable::set_HasBorderVertical](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/idatatable/set_hasbordervertical/) controla los bordes verticales de las celdas.
- [IDataTable::set_HasBorderOutline](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/idatatable/set_hasborderoutline/) controla el borde exterior de la tabla.

Pase `true` a cada setter para mostrar sus bordes o `false` para ocultarlos. El siguiente ejemplo crea un gráfico de columnas agrupadas con datos predeterminados, muestra los bordes horizontales y el borde exterior, y oculta los bordes verticales. No requiere archivo de entrada. La posición y el tamaño del gráfico se especifican en puntos.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(false);
dataTable->set_HasBorderOutline(true);

presentation->Save(u"data-table-borders.pptx", SaveFormat::Pptx);
```

La comparación a continuación utiliza los mismos datos del gráfico y la configuración de clave de leyenda en los cuatro casos. Partiendo de todos los bordes habilitados, cada variante restante desactiva solo una configuración de borde. La variante inferior izquierda coincide con la configuración de bordes del ejemplo.

![Tablas de datos de gráficos con todos los bordes habilitados, sin bordes horizontales, sin bordes verticales y sin borde exterior](data-table-borders.png)

## **Mostrar u ocultar claves de leyenda**

Las claves de leyenda son pequeños marcadores coloreados junto a los nombres de las series en la tabla de datos. Ayudan a los lectores a asociar cada fila de la tabla con una serie del gráfico. Pase `true` a [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) para mostrar estos marcadores o `false` para ocultarlos.

La leyenda separada del gráfico se controla mediante [IChart::set_HasLegend](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichart/set_haslegend/). Estas configuraciones son independientes: ocultar la leyenda separada no oculta las claves dentro de la tabla de datos, y ocultar las claves de la tabla no oculta la leyenda separada.

El siguiente ejemplo crea un gráfico con datos predeterminados, habilita su tabla de datos y muestra las claves de leyenda en ella mientras oculta la leyenda separada. Todos los bordes de la tabla están explícitamente habilitados. No se requiere una presentación de entrada. Para ocultar solo las claves de la tabla, pase `false` a [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/idatatable/set_showlegendkey/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);
chart->set_HasLegend(false);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(true);
dataTable->set_HasBorderOutline(true);
dataTable->set_ShowLegendKey(true);

presentation->Save(u"data-table-legend-keys.pptx", SaveFormat::Pptx);
```

La comparación a continuación muestra la misma tabla con las claves de leyenda habilitadas y deshabilitadas. Todos los bordes permanecen habilitados, y la leyenda separada del gráfico está oculta en ambos casos.

![Tablas de datos de gráficos con claves de leyenda mostradas a la izquierda y ocultas a la derecha](data-table-legend-keys.png)

## **FAQ**

**¿Puedo mostrar las claves de leyenda en la tabla de datos de un gráfico?**

Sí. Pase `true` a [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) para mostrar las claves de leyenda o `false` para ocultarlas.

**¿Se conservará la tabla de datos al exportar la presentación a PDF, HTML o imágenes?**

Sí. Aspose.Slides renderiza el gráfico y su tabla de datos mostrada como parte de la diapositiva al exportar a [PDF](/slides/es/cpp/convert-powerpoint-to-pdf/), [HTML](/slides/es/cpp/convert-powerpoint-to-html/) o [imágenes](/slides/es/cpp/convert-powerpoint-to-png/).

**¿Puedo trabajar con tablas de datos en gráficos cargados desde una plantilla?**

Sí. Para un gráfico cargado desde una presentación o plantilla existente, use [IChart::get_HasDataTable](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichart/get_hasdatatable/) para comprobar si su tabla de datos está visible y [IChart::set_HasDataTable](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichart/set_hasdatatable/) para cambiar su visibilidad.

**¿Cómo puedo encontrar los gráficos que tienen la tabla de datos habilitada?**

Itere a través de las formas de cada diapositiva, identifique los gráficos y compruebe su resultado de [IChart::get_HasDataTable](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichart/get_hasdatatable/). Un valor de `true` indica que la tabla de datos está habilitada.