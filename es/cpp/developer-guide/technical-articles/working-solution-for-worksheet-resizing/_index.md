---
title: Solución práctica para el redimensionamiento de hojas de cálculo
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
description: "Solución práctica para el redimensionamiento de hojas de cálculo en presentaciones de PowerPoint usando C++"
---

{{% alert color="primary" %}}

Se ha observado que las hojas de cálculo de Excel incrustadas como objetos OLE en una presentación de PowerPoint mediante los componentes Aspose se redimensionan a una escala no identificada después de la primera activación. Este comportamiento crea una diferencia visual notable en la presentación entre los estados antes y después de la activación del objeto OLE. Hemos investigado este problema en detalle y proporcionado una solución, que se cubre en este artículo.

{{% /alert %}}

## **Antecedentes**

En el artículo [Manage OLE](/slides/es/cpp/manage-ole/), explicamos cómo añadir un marco OLE a una presentación de PowerPoint usando Aspose.Slides for C++. Para abordar el [object preview issue](/slides/es/cpp/object-preview-issue-when-adding-oleobjectframe/), asignamos una imagen del área de hoja de cálculo seleccionada al marco del objeto OLE. En la presentación resultante, cuando se hace doble clic en el marco del objeto OLE que muestra la imagen de la hoja, se activa el libro de Excel. Los usuarios finales pueden realizar los cambios deseados en el libro de Excel real y luego volver a la diapositiva haciendo clic fuera del libro de Excel activado. El tamaño del marco del objeto OLE cambiará cuando el usuario regrese a la diapositiva. El factor de redimensionado variará según el tamaño del marco del objeto OLE y del libro de Excel incrustado.

## **Causa del redimensionado**

Dado que el libro de Excel tiene su propio tamaño de ventana, intenta conservar su tamaño original tras la primera activación. Por otro lado, el marco del objeto OLE tiene su propio tamaño. Según Microsoft, cuando el libro de Excel se activa, Excel y PowerPoint negocian el tamaño para garantizar que mantenga las proporciones correctas como parte del proceso de incrustación. El redimensionado ocurre en función de las diferencias entre el tamaño de la ventana de Excel y el tamaño y posición del marco del objeto OLE.

## **Solución funcional**

Existen dos posibles soluciones para evitar el efecto de redimensionado.

- Escalar el tamaño del marco OLE en la presentación de PowerPoint para que coincida con la altura y anchura del número deseado de filas y columnas en el marco OLE.
- Mantener constante el tamaño del marco OLE y escalar el tamaño de las filas y columnas participantes para que encajen dentro del tamaño seleccionado del marco OLE.

### **Escalar el tamaño del marco OLE**

En este enfoque, aprenderemos a establecer el tamaño del marco OLE del libro de Excel incrustado para que coincida con el tamaño acumulado de las filas y columnas participantes en la hoja de Excel.

Supongamos que tenemos una hoja de Excel plantilla y queremos añadirla a una presentación como un marco OLE. En este escenario, el tamaño del marco del objeto OLE se calculará primero en función de la altura acumulada de las filas y el ancho acumulado de las columnas participantes en el libro. Luego, estableceremos el tamaño del marco OLE a este valor calculado. Para evitar el mensaje rojo “EMBEDDED OLE OBJECT” para el marco OLE en PowerPoint, también capturaremos una imagen de las porciones deseadas de las filas y columnas en el libro y la estableceremos como la imagen del marco OLE.
```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Set the displayed size when the workbook file is used as an OLE object in PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// We need to use the modified workbook.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Add the OLE image to the presentation resources.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Create the OLE object frame.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
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

En este enfoque, aprenderemos a escalar las alturas de las filas participantes y el ancho de las columnas participantes para que coincidan con un tamaño de marco OLE personalizado.

Supongamos que tenemos una hoja de Excel plantilla y queremos añadirla a una presentación como un marco OLE. En este escenario, estableceremos el tamaño del marco OLE y escalaremos el tamaño de las filas y columnas que participan en el área del marco OLE. Luego guardaremos el libro en un flujo para aplicar los cambios y lo convertiremos en una matriz de bytes para añadirlo al marco OLE. Para evitar el mensaje rojo “EMBEDDED OLE OBJECT” para el marco OLE en PowerPoint, también capturaremos una imagen de las porciones deseadas de las filas y columnas en el libro y la estableceremos como la imagen del marco OLE.
```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Establecer el tamaño visible cuando el archivo del libro de trabajo se usa como un objeto OLE en PowerPoint.
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

// Agregar la imagen OLE a los recursos de la presentación.
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

```cpp
/// <param name="width">El ancho esperado del rango de celdas en puntos.</param>
/// <param name="height">La altura esperada del rango de celdas en puntos.</param>
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

```cpp
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

{{% alert color="primary" %}}

Existen dos enfoques para corregir el problema de redimensionado de la hoja de cálculo. La selección del enfoque apropiado depende de los requisitos específicos y del caso de uso. Ambos enfoques funcionan de la misma manera, ya sea que las presentaciones se creen a partir de una plantilla o desde cero. Además, no hay límite para el tamaño del marco del objeto OLE en esta solución.

{{% /alert %}}

## **Preguntas frecuentes**

**¿Por qué una hoja de cálculo de Excel incrustada cambia de tamaño al activarse por primera vez en PowerPoint?**

Esto ocurre porque Excel intenta mantener el tamaño original de su ventana al activarse, mientras que el marco del objeto OLE en PowerPoint tiene sus propias dimensiones. PowerPoint y Excel negocian el tamaño para mantener la proporción de aspecto, lo que puede provocar el redimensionado.

**¿Es posible evitar este problema de redimensionado por completo?**

Sí. Escalando el marco OLE para que se ajuste al tamaño del rango de celdas de Excel o escalando el rango de celdas para que se ajuste al tamaño deseado del marco OLE, se puede evitar el redimensionado no deseado.

**¿Qué método de escalado debo usar, escalado del marco OLE o escalado del rango de celdas?**

Seleccione **escalado del marco OLE** si desea mantener los tamaños originales de filas y columnas de Excel. Seleccione **escalado del rango de celdas** si desea un tamaño fijo para el marco OLE en su presentación.

**¿Funcionarán estas soluciones si mi presentación se basa en una plantilla?**

Sí. Ambas soluciones funcionan para presentaciones creadas a partir de plantillas y desde cero.

**¿Existe un límite para el tamaño del marco OLE al usar estos métodos?**

No. Puede hacer el marco del objeto OLE del tamaño que desee siempre que establezca la escala apropiadamente.

**¿Hay alguna forma de evitar el texto de marcador de posición “EMBEDDED OLE OBJECT” en PowerPoint?**

Sí. Capturando una instantánea del rango de celdas de Excel objetivo y estableciéndola como la imagen de marcador de posición del marco OLE, puede mostrar una imagen de vista previa personalizada en lugar del marcador de posición predeterminado.

## **Artículos relacionados**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/es/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)