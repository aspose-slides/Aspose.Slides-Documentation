---
title: Crear gráficos de Excel e incrustarlos en presentaciones como objetos OLE
type: docs
weight: 40
url: /es/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- gráfico de Excel
- incrustar gráfico
- objeto OLE
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Crear un gráfico de Excel con Aspose.Cells for C++ e incrustar el libro de trabajo en una presentación de PowerPoint con Aspose.Slides, incluyendo una vista previa del gráfico."
---
## **Visión general**

Este artículo muestra cómo crear un gráfico de columnas de Excel con Aspose.Cells for C++ e incrustar su libro de trabajo en una presentación de PowerPoint con Aspose.Slides for C++. El libro incrustado contiene tanto los datos de origen como el gráfico. Una vista previa PNG separada muestra el gráfico en la diapositiva antes de que se active el objeto OLE.

El resultado es un objeto Excel incrustado, no un gráfico nativo de PowerPoint. Editar el libro mediante OLE requiere una aplicación de escritorio que admita la activación OLE y una instalación compatible de Excel.

## **Requisitos previos**

Configure su proyecto C++ con los encabezados y bibliotecas de Aspose.Cells for C++ y Aspose.Slides for C++. Coloque el código de ejemplo en el punto de entrada de su aplicación, con las declaraciones include a nivel de archivo. Microsoft Office no es necesario para generar la presentación con estas bibliotecas.

No se requieren archivos de entrada: el ejemplo crea los datos y el gráfico en memoria, luego escribe `OutputChart.pptx` en el directorio de trabajo actual. Aplique licencias para ambos productos al ejecutar fuera del modo de evaluación.

## **Cómo funciona la incrustación**

1. Cree un libro de trabajo con una hoja de datos y una hoja de gráfico.  
1. Active la hoja de gráfico para que el libro se abra en el gráfico.  
1. Establezca el rango de visualización OLE del libro y renderice el gráfico a PNG.  
1. Guarde el libro como XLSX en memoria e incruste esos bytes en una diapositiva.  
1. Asigne el PNG como vista previa del objeto OLE y guarde la presentación como PPTX.

El rango de visualización del libro y el marco en la diapositiva tienen roles diferentes. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) toma índices de fila y columna de inicio/fin basados en cero. [ChartCollection::Add](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chartcollection/add/) en su lugar toma la fila superior, columna izquierda, fila inferior y columna derecha. El ejemplo usa el índice de fila 55 y el índice de columna 25 como los límites inferior‑derechos; estos valores son decisiones de diseño, no el número de filas o columnas de datos.

El marco de la diapositiva utiliza puntos. El ejemplo lo ajusta dentro de la diapositiva y lo centra preservando la proporción del PNG, en lugar de estirar la vista previa para rellenar la diapositiva.

## **Crear e incrustar el gráfico**

El siguiente ejemplo completo rellena `DataSheet` con cuatro filas y cinco columnas de valores. Cada fila se convierte en una serie del gráfico. `ChartSheet` se selecciona como hoja activa antes de guardar el libro.

El libro se guarda explícitamente como XLSX, coincidiendo con la extensión `xlsx` pasada a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/). El PNG se carga desde un flujo en memoria sin una conversión intermedia a bitmap. Aspose.Cells devuelve vectores de bytes, que el ejemplo copia al tipo de arreglo aceptado por Aspose.Slides. Inicialice Aspose.Cells antes de usar sus objetos y libere sus recursos después de que esos objetos se hayan destruido. Asignarlo mediante [IOleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/get_substitutepictureformat/) reemplaza el marcador de posición OLE predeterminado.

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <Util/Images.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <algorithm>
#include <IImage.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

// Inicializar Cells antes de crear cualquiera de sus objetos.
Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"DataSheet");

    int32_t values[4][5] =
    {
        { 67, 44, 46, 43, 24 },
        { 86, 64, 97, 29, 40 },
        { 68, 89, 78, 69, 38 },
        { 91, 48, 60, 26, 25 }
    };

    for (auto row = 0; row < 4; row++)
    {
        for (auto column = 0; column < 5; column++)
        {
            dataSheet.GetCells().Get(row, column).PutValue(values[row][column]);
        }
    }

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    chartSheet.SetName(u"ChartSheet");

    auto lastChartRow = 55;
    auto lastChartColumn = 25;
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, lastChartRow, lastChartColumn);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    const char16_t* seriesRanges[] = { u"DataSheet!A1:E1", u"DataSheet!A2:E2", u"DataSheet!A3:E3", u"DataSheet!A4:E4" };
    for (auto range : seriesRanges)
    {
        chart.GetNSeries().Add(range, false);
    }

    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);
    workbook.GetWorksheets().SetOleSize(0, lastChartRow, 0, lastChartColumn);

    // Renderizar la vista previa del gráfico y serializar el libro de trabajo editable por separado.
    auto chartImageData = chart.ToImage(Aspose::Cells::Drawing::ImageType::Png);
    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);

    // Copiar los buffers de Cells en el tipo de arreglo usado por Slides.
    auto toSlidesArray = [](const Aspose::Cells::Vector<uint8_t>& buffer)
    {
        auto result = System::MakeArray<uint8_t>(buffer.GetLength(), 0);
        std::copy(buffer.GetData(), buffer.GetData() + buffer.GetLength(), result->data_ptr());
        return result;
    };
    auto chartImageBytes = toSlidesArray(chartImageData);
    auto workbookBytes = toSlidesArray(workbookData);
    auto chartImageStream = System::MakeObject<System::IO::MemoryStream>(chartImageBytes);
    auto chartImage = Images::FromStream(chartImageStream);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto slideSize = presentation->get_SlideSize()->get_Size();

    // Ajustar la vista previa dentro de la diapositiva sin cambiar su relación de aspecto.
    auto scale = (std::min)(slideSize.get_Width() / chartImage->get_Width(), slideSize.get_Height() / chartImage->get_Height());
    auto frameWidth = chartImage->get_Width() * scale;
    auto frameHeight = chartImage->get_Height() * scale;
    auto frameX = (slideSize.get_Width() - frameWidth) / 2;
    auto frameY = (slideSize.get_Height() - frameHeight) / 2;

    auto embeddedData = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xlsx");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
    auto previewImage = presentation->get_Images()->AddImage(chartImage);
    oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(previewImage);

    presentation->Save(u"OutputChart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
    chartImage->Dispose();
    chartImageStream->Dispose();
}
// Liberar los recursos de Cells después de que todos los objetos de Cells hayan sido destruidos.
Aspose::Cells::Cleanup();
```

## **Resultado esperado**

`OutputChart.pptx` contiene una diapositiva con un libro de Excel incrustado y una vista previa del gráfico. El libro contiene los datos originales y un gráfico de columnas con cuatro series. La vista previa está centrada en la diapositiva y conserva sus proporciones.

![Gráfico de columnas de Excel mostrado como vista previa de un libro incrustado](excel-chart-ole-preview.png)

En un entorno de escritorio PowerPoint compatible con Excel disponible, haga doble clic en el objeto para activar y editar el libro incrustado. La activación y edición dependen del soporte OLE de la aplicación anfitriona y de la configuración de seguridad.

## **Preguntas frecuentes**

**¿Por qué se necesita una imagen de vista previa?**

El libro incrustado y su vista previa en la diapositiva son contenido separado. Proporcione una imagen del gráfico para que la diapositiva muestre el gráfico en lugar del marcador de posición predeterminado "EMBEDDED OLE OBJECT". Consulte [Problema de vista previa del objeto al agregar OleObjectFrame](/slides/es/cpp/object-preview-issue-when-adding-oleobjectframe/).

**¿Se actualiza automáticamente la vista previa cuando modifico el libro en el código?**

Considere la vista previa como una instantánea. Al actualizar los datos del libro mediante código, regenere la imagen del gráfico y reemplace la vista previa así como los datos del libro incrustado.

**¿Puedo usar XLS en lugar de XLSX?**

Sí. Guarde el libro en formato XLS y use `xls` como extensión de datos incrustada. La extensión debe coincidir con el formato real del libro; cambiar solo la extensión no convierte los datos.

**¿Por qué el objeto podría cambiar de tamaño después de la activación?**

La aplicación anfitriona puede actualizar la presentación del objeto OLE cuando activa el libro. Tanto el rango de visualización OLE del libro como las dimensiones del marco de la diapositiva son importantes. Consulte [Solución funcional para cambiar el tamaño del gráfico en PPTX](/slides/es/cpp/working-solution-for-chart-resizing-in-pptx/).

## **Secciones relacionadas**

- [Solución funcional para cambiar el tamaño del gráfico en PPTX](/slides/es/cpp/working-solution-for-chart-resizing-in-pptx/)
- [Problema de vista previa del objeto al agregar OleObjectFrame](/slides/es/cpp/object-preview-issue-when-adding-oleobjectframe/)