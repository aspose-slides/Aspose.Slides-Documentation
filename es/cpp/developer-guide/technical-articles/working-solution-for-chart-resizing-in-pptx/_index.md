---
title: Solución práctica para el redimensionado de gráficos en PPTX
type: docs
weight: 60
url: /es/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionado de gráfico
- gráfico de Excel
- objeto OLE
- incrustar gráfico
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Corrija el redimensionado inesperado de gráficos en PPTX al usar objetos OLE de Excel incrustados con Aspose.Slides para C++. Establezca dimensiones fijas del gráfico para mantener consistentes los tamaños del gráfico y del marco OLE."
---
## **Antecedentes**

Los gráficos de Excel incrustados como objetos OLE en presentaciones de PowerPoint mediante los componentes Aspose pueden cambiar de tamaño tras su primera activación. Esto puede provocar una diferencia notable en la apariencia del gráfico antes y después de la activación. Este artículo explica por qué se produce el cambio de tamaño y muestra cómo evitarlo haciendo coincidir las dimensiones fijas del gráfico con el marco OLE.

En [Crear gráficos de Excel e incrustarlos como objetos OLE en presentaciones](/slides/es/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), explicamos cómo crear un gráfico de Excel con Aspose.Cells para C++ e incrustarlo en una presentación de PowerPoint usando Aspose.Slides para C++. Para abordar el [problema de vista previa del objeto](/slides/es/cpp/object-preview-issue-when-adding-oleobjectframe/), asignamos la imagen del gráfico al marco del objeto OLE del gráfico. En la presentación resultante, al hacer doble clic en el marco del objeto OLE que muestra la imagen del gráfico, se activa el gráfico de Excel. Los usuarios pueden editar el libro de trabajo de Excel incrustado y luego volver a la diapositiva haciendo clic fuera del libro de trabajo activado. El tamaño del marco del objeto OLE cambia cuando el usuario vuelve a la diapositiva, y el factor de redimensionado varía según los tamaños originales tanto del marco del objeto OLE como del libro de trabajo de Excel incrustado.

## **Causa del cambio de tamaño**

El libro de trabajo de Excel incrustado tiene sus propias dimensiones de ventana, que Excel intenta conservar cuando el objeto se activa por primera vez. El marco OLE en la diapositiva tiene dimensiones definidas de forma independiente. Cuando el libro de trabajo de Excel se activa, Excel y PowerPoint negocian el tamaño del objeto para mantener sus proporciones como parte del proceso de incrustación. Por lo tanto, las diferencias entre la ventana del libro de trabajo y el marco OLE pueden provocar que el objeto cambie de tamaño.

## **Solución funcional**

Haga coincidir el tamaño del gráfico con el marco OLE en la diapositiva y mantenga las dimensiones del gráfico independientes de la ventana del libro de trabajo. Esta solución funciona con una presentación nueva o con una plantilla existente.

El ejemplo requiere Aspose.Cells para C++ y Aspose.Slides para C++. Crea un gráfico de columnas sencillo en una hoja de gráficos activa e incrusta el libro de trabajo en formato XLS. No se asigna ninguna imagen de vista previa del gráfico; el gráfico se vuelve visible cuando el objeto OLE se activa en PowerPoint.

Coloque el código de ejemplo en el punto de entrada de su aplicación, con las declaraciones de inclusión a nivel de archivo. Inicialice Aspose.Cells antes de crear sus objetos y libere sus recursos después de que dichos objetos hayan sido destruidos. El ejemplo copia el vector de bytes del libro de trabajo devuelto por Aspose.Cells en el tipo de arreglo aceptado por Aspose.Slides.

El ejemplo crea una nueva presentación con un marco OLE de 9,5 × 4 pulgadas ubicado a 0,5 pulgadas del borde izquierdo y a 1 pulgada de la parte superior. Las coordenadas y dimensiones de la diapositiva están en puntos (72 puntos por pulgada). Para una presentación existente, consulte [Usar una plantilla](#use-a-template).

## **Establecer un tamaño de gráfico fijo**

Establezca [Chart::SetSizeWithWindow](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setsizewithwindow/) a false para que las dimensiones del gráfico sean independientes de la ventana del libro de trabajo. Establezca las dimensiones del [Chart::GetChartObject](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/getchartobject/) a través de [Shape::SetWidth](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setwidth/) y [Shape::SetHeight](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setheight/), convirtiendo puntos a píxeles usando 96 píxeles por pulgada: un marco de 684 × 288 puntos corresponde a un gráfico de 912 × 384 píxeles. Establezca [Chart::SetPrintSize](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setprintsize/) al valor Custom de [PrintSizeType](https://reference.aspose.com/cells/cpp/aspose.cells/printsizetype/). El ejemplo incrusta el libro de trabajo con [IShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addoleobjectframe/) y guarda una presentación con un marco OLE de 9,5 × 4 pulgadas.

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartShape.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/PrintSizeType.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <algorithm>
#include <cstdint>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"Data");
    dataSheet.GetCells().Get(u"A1").PutValue(10);
    dataSheet.GetCells().Get(u"A2").PutValue(20);

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, 20, 10);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    chart.GetNSeries().Add(u"Data!A1:A2", true);
    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Las coordenadas y dimensiones de la diapositiva están en puntos (72 puntos por pulgada).
    auto width = 684.f; // 9,5 pulgadas.
    auto height = 288.f; // 4 pulgadas.

    chart.SetSizeWithWindow(false);
    // Convertir puntos a píxeles del gráfico usando 96 píxeles por pulgada.
    chart.GetChartObject().SetWidth(static_cast<int32_t>(width / 72.f * 96.f));
    chart.GetChartObject().SetHeight(static_cast<int32_t>(height / 72.f * 96.f));
    chart.SetPrintSize(Aspose::Cells::PrintSizeType::Custom);

    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Excel97To2003);
    // Copiar el vector de bytes de Cells en el tipo de arreglo aceptado por Slides.
    auto workbookBytes = System::MakeArray<uint8_t>(workbookData.GetLength(), 0);
    std::copy(workbookData.GetData(), workbookData.GetData() + workbookData.GetLength(), workbookBytes->data_ptr());
    auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xls");
    slide->get_Shapes()->AddOleObjectFrame(36, 72, width, height, dataInfo);

    presentation->Save(u"chart-fixed-size.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
}
Aspose::Cells::Cleanup();
```

## **Usar una plantilla**

La lógica de dimensionado es la misma para una presentación existente. Para adaptar el ejemplo:

1. Cargue la presentación de plantilla en lugar de crear una presentación vacía.
1. Compruebe que la primera diapositiva contenga al menos tres formas y luego use la forma en el índice 2 como marcador de posición.
1. Obtenga el ancho y alto del marco de esa forma en lugar de usar los valores fijos 684 y 288. Mantenga los cálculos de dimensionado sin cambios.
1. Añada el marco OLE en la posición del marcador de posición en lugar de las coordenadas fijas 36 y 72.
1. Elimine el marcador de posición antes de guardar la presentación.

## **Preguntas frecuentes**

**¿Por qué mi gráfico de Excel incrustado cambia de tamaño después de activarlo en PowerPoint?**

Esto ocurre porque Excel intenta restaurar el tamaño original de la ventana al activarse por primera vez, mientras que el marco del objeto OLE en PowerPoint tiene sus propias dimensiones. PowerPoint y Excel negocian el tamaño para mantener la proporción, lo que puede provocar el redimensionado.

**¿Cómo puedo mantener consistentes los tamaños del gráfico y del marco OLE?**

Establezca dimensiones fijas del gráfico que coincidan con el marco OLE y use un tamaño de impresión de gráfico personalizado antes de incrustar el libro de trabajo. El ejemplo anterior muestra la configuración necesaria y las conversiones de unidades.

**¿Es suficiente igualar el tamaño de la ventana del libro de trabajo?**

Igualar solo el tamaño de la ventana del libro de trabajo no garantiza que el marco OLE no cambie de tamaño tras la activación. Utilice dimensiones fijas del gráfico como se muestra en el ejemplo.

**¿Esta solución funciona tanto con presentaciones basadas en plantillas como con presentaciones nuevas?**

Sí. Para una plantilla, utilice las dimensiones y la posición del marcador de posición. Para una presentación nueva, especifique directamente las dimensiones y la posición del marco.

**¿Puedo usar este ejemplo con gráficos creados en otros programas de hoja de cálculo?**

El ejemplo usa un libro de trabajo de Excel creado con Aspose.Cells. No muestra el comportamiento de activación para otros programas de hoja de cálculo.

## **Secciones relacionadas**

- [Crear gráficos de Excel e incrustarlos como objetos OLE en presentaciones](/slides/es/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)