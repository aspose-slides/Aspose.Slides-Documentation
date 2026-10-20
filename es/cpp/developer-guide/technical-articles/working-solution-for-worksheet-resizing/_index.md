---
title: Solución funcional para el redimensionamiento de la hoja de cálculo
type: docs
weight: 130
url: /es/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- imagen de vista previa
- redimensionamiento de imagen
- Excel
- hoja de cálculo
- PowerPoint
- presentación
- C++
- Aspose.Slides para C++
description: "Solución funcional para el redimensionamiento de la hoja de cálculo en presentaciones de PowerPoint usando C++"
---
{{% alert color="info" title="Note" %}}

Las hojas de cálculo de Excel incrustadas como objetos OLE en una presentación de PowerPoint mediante los componentes Aspose pueden cambiar de tamaño de forma inesperada después de su primera activación. Este comportamiento crea una diferencia visual notable entre el objeto OLE antes y después de la activación. Este artículo explica el problema y describe dos formas de solucionarlo.

{{% /alert %}}

## **Antecedentes**

En el artículo [Gestionar OLE](/slides/es/cpp/manage-ole/), explicamos cómo añadir un marco OLE a una presentación de PowerPoint usando Aspose.Slides para C++. Para abordar el [problema de vista previa del objeto](/slides/es/cpp/object-preview-issue-when-adding-oleobjectframe/), asignamos una imagen del área de la hoja de cálculo seleccionada al marco del objeto OLE. En la presentación resultante, cuando haces doble clic en el marco del objeto OLE que muestra la imagen de la hoja, se activa el libro de Excel. Los usuarios finales pueden realizar los cambios que deseen en el libro de Excel real y luego volver a la diapositiva haciendo clic fuera del libro de Excel activado. El tamaño del marco del objeto OLE cambiará cuando el usuario regrese a la diapositiva. El factor de cambio de tamaño variará según el tamaño del marco del objeto OLE y del libro de Excel incrustado.

## **Causa del cambio de tamaño**

Dado que el libro de Excel tiene su propio tamaño de ventana, intenta conservar su tamaño original al activarse por primera vez. Por otro lado, el marco del objeto OLE tiene su propio tamaño. Según Microsoft, cuando se activa el libro de Excel, Excel y PowerPoint negocian el tamaño para asegurarse de que mantenga las proporciones correctas como parte del proceso de incrustación. El cambio de tamaño ocurre en función de las diferencias entre el tamaño de la ventana de Excel y el tamaño y posición del marco del objeto OLE.

## **Solución funcional**

Existen dos soluciones posibles para evitar el efecto de cambio de tamaño.

- Escalar el marco OLE en la presentación de PowerPoint para que coincida con la altura y anchura totales de las filas y columnas seleccionadas.
- Mantener el tamaño del marco OLE constante y escalar las filas y columnas seleccionadas para que se ajusten a él.

### **Escalar el tamaño del marco OLE**

Este enfoque establece el tamaño del marco OLE para que coincida con la altura y anchura totales de las filas y columnas seleccionadas en la hoja de cálculo de Excel incrustada.

El ejemplo carga un libro de Excel existente y selecciona las primeras 10 filas y 13 columnas de su primera hoja de cálculo usando índices basados en cero. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) define el rango mostrado. La vista previa se renderiza a 96 DPI, y sus dimensiones en píxeles se convierten a puntos utilizando 72 puntos por pulgada. [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) incrusta el libro modificado en un marco con esas dimensiones. La vista previa se asigna mediante [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/) para sustituir el marcador de posición "EMBEDDED OLE OBJECT" en la presentación guardada.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/image.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Establecer el tamaño mostrado cuando el archivo de libro de trabajo se utiliza como objeto OLE en PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Obtener el ancho y la altura de la imagen OLE en puntos.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// Necesitamos usar el libro de trabajo modificado.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Añadir la imagen OLE a los recursos de la presentación.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Crear el marco del objeto OLE.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

El ayudante de vista previa utiliza [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) para seleccionar el rango y elimina márgenes, encabezados y pies de página. Con [ImageOrPrintOptions::SetOnlyArea](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/imageorprintoptions/setonlyarea/) habilitado, [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/) renderiza el rango como una imagen PNG. El ayudante copia los datos de la imagen renderizada a un nuevo flujo de memoria situado al inicio para su uso en la presentación.

```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"

using namespace System;
using namespace System::IO;

SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

### **Escalar el tamaño del rango de celdas**

Este enfoque escala las alturas de las filas seleccionadas y las anchuras de las columnas seleccionadas para que coincidan con un tamaño de marco OLE personalizado.

El ejemplo carga un libro de Excel existente y selecciona las primeras 10 filas y 13 columnas de su primera hoja de cálculo usando índices basados en cero. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) define el rango mostrado, y el ayudante a continuación escala ese rango para ajustarse a un marco de 400 puntos de ancho y 100 puntos de alto. Después de guardar el libro modificado en una matriz de bytes, [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) lo incrusta con el tamaño especificado. Una vista previa renderizada a 96 DPI se asigna mediante [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/), de modo que la presentación guardada muestra las celdas seleccionadas en lugar del marcador de posición predeterminado.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Establecer el tamaño mostrado cuando el archivo de libro de trabajo se usa como objeto OLE en PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Escalar el rango de celdas para ajustarlo al tamaño del marco.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// Necesitamos usar el libro de trabajo modificado.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Añadir la imagen OLE a los recursos de la presentación.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Crear el marco del objeto OLE.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

El ayudante de escalado calcula ratios de ancho y alto por separado para el rango seleccionado, preservando las anchuras relativas de sus columnas y las alturas relativas de sus filas. Convierte las dimensiones calculadas de puntos a pulgadas antes de aplicarlas con [Cells::SetColumnWidthInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setcolumnwidthinch/) y [Cells::SetRowHeightInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setrowheightinch/). El rango seleccionado debe tener ancho y alto diferentes de cero.

```cpp
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/CellsUnitType.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/Worksheet.h"

/// <param name="width">Ancho esperado del rango de celdas en puntos.</param>
/// <param name="height">Altura esperada del rango de celdas en puntos.</param>
void ScaleCellRange(Aspose::Cells::Range cellRange, float width, float height)
{
    auto rangeWidth = cellRange.GetWidth();
    auto rangeHeight = cellRange.GetHeight();

    for (int i = 0; i < cellRange.GetColumnCount(); i++)
    {
        auto columnIndex = cellRange.GetFirstColumn() + i;
        auto columnWidth = cellRange.GetWorksheet().GetCells().GetColumnWidth(columnIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newColumnWidth = columnWidth * width / rangeWidth;
        auto widthInInches = newColumnWidth / 72;
        cellRange.GetWorksheet().GetCells().SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.GetRowCount(); i++)
    {
        auto rowIndex = cellRange.GetFirstRow() + i;
        auto rowHeight = cellRange.GetWorksheet().GetCells().GetRowHeight(rowIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newRowHeight = rowHeight * height / rangeHeight;
        auto heightInInches = newRowHeight / 72;
        cellRange.GetWorksheet().GetCells().SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

Este ayudante de vista previa renderiza el rango redimensionado usando [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/). Utiliza [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) para limitar la impresión a ese rango, elimina márgenes, encabezados y pies de página, y devuelve un flujo PNG situado al inicio.

```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"

using namespace System;
using namespace System::IO;

SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

## **Conclusión**

{{% alert color="info" title="Note" %}}

Existen dos enfoques para solucionar el problema de cambio de tamaño de la hoja de cálculo. Elige el enfoque que mejor se adapte a tus requisitos y caso de uso. Ambos enfoques funcionan de la misma manera, tanto si las presentaciones se crean a partir de una plantilla como desde cero. Además, no hay límite en el tamaño del marco del objeto OLE en esta solución.

{{% /alert %}}

## **Preguntas frecuentes**

**¿Por qué una hoja de cálculo de Excel incrustada cambia de tamaño al activarse por primera vez en PowerPoint?**

Esto ocurre porque Excel intenta conservar el tamaño original de la ventana al activarse, mientras que el marco del objeto OLE en PowerPoint tiene sus propias dimensiones. PowerPoint y Excel negocian el tamaño para mantener la relación de aspecto, lo que puede provocar el cambio de tamaño.

**¿Es posible evitar este problema de cambio de tamaño por completo?**

Sí. Escalando el marco OLE para que se ajuste al tamaño del rango de celdas de Excel o escalando el rango de celdas para que se ajuste al tamaño deseado del marco OLE, puedes evitar el cambio de tamaño no deseado.

**¿Qué método de escalado debo usar, escalado del marco OLE o escalado del rango de celdas?**

Selecciona **escalado del marco OLE** si deseas mantener los tamaños originales de filas y columnas de Excel. Selecciona **escalado del rango de celdas** si deseas un tamaño fijo para el marco OLE en tu presentación.

**¿Funcionarán estas soluciones si mi presentación se basa en una plantilla?**

Sí. Ambas soluciones funcionan para presentaciones creadas a partir de plantillas y desde cero.

**¿Existe un límite al tamaño del marco OLE al usar estos métodos?**

No. Puedes hacer que el marco del objeto OLE tenga cualquier tamaño siempre que establezcas la escala de forma adecuada.

**¿Hay alguna manera de evitar el texto del marcador de posición "EMBEDDED OLE OBJECT" en PowerPoint?**

Sí. Capturando una instantánea del rango de celdas de Excel objetivo y configurándola como la imagen de marcador de posición del marco OLE, puedes mostrar una imagen de vista previa personalizada en lugar del marcador de posición predeterminado.

## **Artículos relacionados**

[Crear un gráfico de Excel e incrustarlo en una presentación como objeto OLE](/slides/es/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)