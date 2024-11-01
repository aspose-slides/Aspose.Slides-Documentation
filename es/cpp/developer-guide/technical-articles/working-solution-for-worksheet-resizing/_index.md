---
title: Solución Funcional para el Redimensionamiento de Hojas de Cálculo
type: docs
weight: 130
url: /es/cpp/working-solution-for-worksheet-resizing/
---

{{% alert color="primary" %}} 

Se ha observado que las Hojas de Cálculo de Excel incrustadas como OLE en una Presentación de PowerPoint a través de componentes de Aspose se redimensionan a una escala no identificada después de la activación por primera vez. Este comportamiento crea una diferencia visual considerable en la presentación entre los estados de activación de gráficos previos y posteriores. Hemos investigado este problema en detalle y hemos encontrado la solución a este problema que se ha cubierto en este artículo. 

{{% /alert %}} 
## **Antecedentes**
En el artículo Agregar Marcos Ole, hemos explicado cómo agregar un Marco Ole en una presentación en una Presentación de PowerPoint utilizando Aspose.Slides para C++. Con el fin de acomodar el problema de objeto cambiado, asignamos la imagen de la hoja de cálculo del área seleccionada al Marco de Objeto OLE de Gráfico. En la presentación de salida, cuando hacemos doble clic en el Marco de Objeto OLE que muestra la Imagen de la hoja de cálculo, se activa el Gráfico de Excel. Los usuarios finales pueden hacer cualquier cambio deseado en el Libro de Trabajo de Excel real y luego regresar a la Diapositiva correspondiente haciendo clic fuera del Libro de Trabajo de Excel activado. El tamaño del Marco de Objeto OLE cambiará cuando el usuario regrese a la diapositiva. El factor de redimensionamiento será diferente para diferentes tamaños de Marco de Objeto OLE y Libro de Trabajo de Excel incrustado. 
## **Causa del Redimensionamiento**
Dado que el Libro de Trabajo de Excel tiene su propio tamaño de ventana, intenta mantener su tamaño original en la primera activación. Por otro lado, el Marco de Objeto OLE tendrá su propio tamaño. Según Microsoft, al activar el Libro de Trabajo de Excel, Excel y PowerPoint negocian el tamaño y aseguran que esté en las proporciones correctas como parte de la operación de incrustación. Basado en las diferencias en el tamaño de las Ventanas de Excel y el tamaño / posición del Marco de Objeto OLE, se produce el redimensionamiento. 
## **Solución Funcional**
Hay dos posibles soluciones para evitar el efecto de redimensionamiento.

- Escalar el tamaño del marco Ole en PPT para hacer coincidir el tamaño en términos de altura/ancho del número deseado de filas/columnas en el Marco Ole
- Mantener el tamaño del marco Ole constante y escalar el tamaño de las filas/columnas participantes para que se ajusten al tamaño del marco Ole seleccionado
## **Escalar el tamaño del marco Ole al tamaño de las filas/columnas seleccionadas de la hoja de cálculo**
En este enfoque, aprenderemos cómo establecer el tamaño del marco Ole del Libro de Trabajo de Excel incrustado equivalente al tamaño acumulativo del número de filas y columnas participantes en la Hoja de Cálculo de Excel. 
## **Ejemplo**
Supongamos que hemos definido una hoja de cálculo de Excel de plantilla y deseamos agregarla a la presentación como marco Ole. En este escenario, el tamaño del Marco de Objeto OLE se calculará primero en base a la altura acumulada de las filas y el ancho de las columnas de las filas y columnas del libro de trabajo participantes, respectivamente. Luego estableceremos el tamaño del marco Ole a ese valor calculado. Para evitar el mensaje de **Objeto Incrustado** rojo para el marco Ole en PowerPoint, también obtendremos la imagen de las porciones deseadas de filas y columnas en el Libro de Trabajo y establecemos eso como la imagen del marco Ole. 

``` cpp
auto workbookDesigner = Aspose::Cells::Factory::CreateIWorkbookDesigner();
workbookDesigner->SetIWorkbook(Aspose::Cells::Factory::CreateIWorkbook(new Aspose::Cells::Systems::String("d:/AsposeTest.xls")));

System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>(u"d:/AsposeTest.ppt");
System::SharedPtr<ISlide> slide = presentation->get_Slides()->idx_get(0);

AddOleFrame(slide, 0, 15, 0, 3, 0, 300, 1100, 0, 0, presentation, workbookDesigner, true, 0, 0);

System::String fileName = u"d:/AsposeTest_Ole.ppt";
presentation->Save(fileName, Export::SaveFormat::Pptx);
```

``` cpp
System::Drawing::Size SetOleAccordingToSelectedRowsColumns(intrusive_ptr<Aspose::Cells::IWorkbook> workbook, int32_t startRow, int32_t endRow, int32_t startCol, int32_t endCol, int32_t dataSheetIdx)
{
    intrusive_ptr<Aspose::Cells::IWorksheet> work = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIdx);

    double actualHeight = 0, actualWidth = 0;

    for (int32_t i = startRow; i <= endRow; i++)
    {
        actualHeight += work->GetICells()->GetRowHeightInch(i);
    }

    for (int32_t i = startCol; i <= endCol; i++)
    {
        actualWidth += work->GetICells()->GetColumnWidthInch(i);
    }

    // Establecer nueva altura de fila y ancho de columna
    return System::Drawing::Size((int32_t)(System::Math::Round(actualWidth, 2) * 576), (int32_t)(System::Math::Round(actualHeight, 2) * 576));
}
```

``` cpp
void AddOleFrame(System::SharedPtr<ISlide> slide, int32_t startRow, int32_t endRow,
    int32_t startCol, int32_t endCol, int32_t dataSheetIdx, int32_t x, int32_t y,
    double OleWidth, double OleHeight, System::SharedPtr<IPresentation> presentation, 
    intrusive_ptr<Aspose::Cells::IWorkbookDesigner> workbookDesigner, 
    bool onePagePerSheet, int32_t outputWidth, int32_t outputHeight)
{
    std::wstring tempFileName = System::IO::Path::GetTempFileName_().ToWCS();
    if (startRow == 0)
    {
        startRow++;
        endRow++;
    }

    // Establecer índice de hoja activa del libro de trabajo
    workbookDesigner->GetIWorkbook()->GetIWorksheets()->SetActiveSheetIndex(dataSheetIdx);

    // Obtener Libro de Trabajo y hoja de cálculo seleccionada  
    intrusive_ptr<Aspose::Cells::IWorkbook> workbook = workbookDesigner->GetIWorkbook();
    intrusive_ptr<Aspose::Cells::IWorksheet> work = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIdx);

    // Establecer tamaño de Ole según filas y columnas seleccionadas
    System::Drawing::Size SlideOleSize = SetOleAccordingToSelectedRowsColumns(workbook, startRow, endRow, startCol, endCol, dataSheetIdx);
    OleWidth = SlideOleSize.get_Width();
    OleHeight = SlideOleSize.get_Height();

    // Establecer tamaño Ole en el Libro de Trabajo
    workbook->GetIWorksheets()->SetOleSize(startRow, endRow, startCol, endCol);

    workbook->GetIWorksheets()->GetObjectByIndex(0)->SetGridlinesVisible(false);

    // Establecer opciones de imagen para tomar la imagen de la hoja de cálculo
    intrusive_ptr<Aspose::Cells::Rendering::IImageOrPrintOptions> imageOrPrintOptions = Aspose::Cells::Factory::CreateIImageOrPrintOptions();
    imageOrPrintOptions->SetImageFormat(Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetBmp());
    imageOrPrintOptions->SetOnePagePerSheet(onePagePerSheet);

    intrusive_ptr<Aspose::Cells::Rendering::ISheetRender> render = Aspose::Cells::Factory::CreateISheetRender(workbookDesigner->GetIWorkbook()->GetIWorksheets()->GetObjectByIndex(dataSheetIdx), imageOrPrintOptions);
    tempFileName.append(L".bmp");
    render->ToImage(0, new String(tempFileName.c_str()));
    
    System::String slidesTempFileName = System::String::FromWCS(tempFileName);
    System::SharedPtr<System::Drawing::Image> image = ScaleImage(System::Drawing::Image::FromFile(slidesTempFileName), outputWidth, outputHeight);
    System::String newTempFileName = slidesTempFileName.Replace(u".tmp", u".tmp1");
    image->Save(newTempFileName, System::Drawing::Imaging::ImageFormat::get_Bmp());

    // Agregar imagen a la colección de imágenes de la diapositiva
    auto ppImage = presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(newTempFileName));

    // Guardar libro de trabajo en flujo y copiar en array de bytes
    System::SharedPtr<System::IO::Stream> mstream = ToSlidesMemoryStream(workbook->SaveToStream());
    System::ArrayPtr<uint8_t> chartOleData = System::MakeArray<uint8_t>(mstream->get_Length(), 0);
    mstream->set_Position(0);
    mstream->Read(chartOleData, 0, chartOleData->get_Length());

    // Agregar marco de objeto Ole
    System::SharedPtr<OleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(chartOleData, u"xls");
    System::SharedPtr<IOleObjectFrame> oleObjectFrame = slide->get_Shapes()->AddOleObjectFrame(x, y, OleWidth, OleHeight, dataInfo);

    // Establecer imagen de marco ole y texto alternativo    
    oleObjectFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(ppImage);
    oleObjectFrame->set_AlternativeText(System::String(u"image") + ppImage);
}
```

``` cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    System::ArrayPtr<uint8_t> outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

``` cpp
System::SharedPtr<System::Drawing::Image> ScaleImage(System::SharedPtr<System::Drawing::Image> image, int32_t outputWidth, int32_t outputHeight)
{
    if (outputWidth == 0 && outputHeight == 0)
    {
        outputWidth = image->get_Width();
        outputHeight = image->get_Height();
    }
    System::SharedPtr<System::Drawing::Bitmap> outputImage = System::MakeObject<System::Drawing::Bitmap>(outputWidth, outputHeight, image->get_PixelFormat());
    outputImage->SetResolution(image->get_HorizontalResolution(), image->get_VerticalResolution());
    System::SharedPtr<System::Drawing::Graphics> graphics = System::Drawing::Graphics::FromImage(outputImage);
    graphics->set_InterpolationMode(System::Drawing::Drawing2D::InterpolationMode::HighQualityBicubic);
    System::Drawing::Rectangle srcDestRect(0, 0, outputWidth, outputHeight);
    graphics->DrawImage(image, srcDestRect, srcDestRect, System::Drawing::GraphicsUnit::Pixel);
    graphics->Dispose();

    return outputImage;
}
```

## **Escalar altura de filas y ancho de columnas de la hoja de cálculo de acuerdo con el tamaño del Marco Ole**
En este enfoque, aprenderemos cómo escalar las alturas de las filas participantes y el ancho de las columnas participantes de acuerdo con el tamaño del marco ole establecido de forma personalizada. 
## **Ejemplo**
Supongamos, que hemos definido una hoja de cálculo de Excel de plantilla y deseamos agregarla a la presentación como marco Ole. En este escenario, estableceremos el tamaño del marco Ole y escalaremos el tamaño de las filas y columnas que participan en el área del marco Ole. Luego guardaremos el libro de trabajo en flujo para guardar cambios y convertir eso a un array de bytes para agregarlo en el marco ole. Para evitar el mensaje de **Objeto Incrustado** rojo para el marco Ole en PowerPoint, también obtendremos la imagen de las porciones deseadas de filas y columnas en el Libro de Trabajo y estableceremos eso como la imagen del marco Ole. 

``` cpp
auto workbookDesigner = Aspose::Cells::Factory::CreateIWorkbookDesigner();
workbookDesigner->SetIWorkbook(Aspose::Cells::Factory::CreateIWorkbook(new Aspose::Cells::Systems::String("d:/AsposeTest.xls")));

System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>(u"d:/AsposeTest.ppt");
System::SharedPtr<ISlide> slide = presentation->get_Slides()->idx_get(0);

AddOleFrame(slide, 0, 15, 0, 3, 0, 300, 1100, 0, 0, presentation, workbookDesigner, true, 0, 0);

System::String fileName = u"d:/AsposeTest_Ole.ppt";
presentation->Save(fileName, Export::SaveFormat::Pptx);
```

``` cpp
void SetOleAccordingToCustomHeightWidth(intrusive_ptr<Aspose::Cells::IWorkbook> workbook, int32_t startRow, int32_t endRow, int32_t startCol, int32_t endCol, double slideWidth, double slideHeight, int32_t dataSheetIdx)
{
    auto work = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIdx);

    double actualHeight = 0, actualWidth = 0;

    double newHeight = slideHeight;
    double newWidth = slideWidth;
    double tem = 0;
    double newTem = 0;

    for (int32_t i = startRow; i <= endRow; i++)
    {
        actualHeight += work->GetICells()->GetRowHeightInch(i);
    }

    for (int32_t i = startCol; i <= endCol; i++)
    {
        actualWidth += work->GetICells()->GetColumnWidthInch(i);
    }

    // Establecer nueva altura de fila y ancho de columna
    for (int32_t i = startRow; i <= endRow; i++)
    {
        tem = work->GetICells()->GetRowHeightInch(i);
        newTem = (tem / actualHeight) * newHeight;
        work->GetICells()->SetRowHeightInch(i, newTem);
    }

    for (int32_t i = startCol; i <= endCol; i++)
    {
        tem = work->GetICells()->GetColumnWidthInch(i);
        newTem = (tem / actualWidth) * newWidth;
        work->GetICells()->SetColumnWidthInch(i, newTem);
    }
}
```

``` cpp
void AddOleFrame(System::SharedPtr<ISlide> slide, int32_t startRow, int32_t endRow,
        int32_t startCol, int32_t endCol, int32_t dataSheetIdx, int32_t x, int32_t y,
        double OleWidth, double OleHeight, System::SharedPtr<IPresentation> presentation,
        intrusive_ptr<Aspose::Cells::IWorkbookDesigner> workbookDesigner,
        bool onePagePerSheet, int32_t outputWidth, int32_t outputHeight)
{
    std::wstring tempFileName = System::IO::Path::GetTempFileName_().ToWCS();
    if (startRow == 0)
    {
        startRow++;
        endRow++;
    }

    // Establecer índice de hoja activa del libro de trabajo
    workbookDesigner->GetIWorkbook()->GetIWorksheets()->SetActiveSheetIndex(dataSheetIdx);

    // Obtener Libro de Trabajo y hoja de cálculo seleccionada  
    intrusive_ptr<Aspose::Cells::IWorkbook> workbook = workbookDesigner->GetIWorkbook();
    intrusive_ptr<Aspose::Cells::IWorksheet> work = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIdx);

    // Escalar altura de filas y ancho de columnas de acuerdo con el tamaño del Ole personalizado
    double height = OleHeight / 576.0f;
    double width = OleWidth / 576.0f;

    // Establecer Ole según filas y columnas seleccionadas
    SetOleAccordingToCustomHeightWidth(workbook, startRow, endRow, startCol, endCol, width, height, dataSheetIdx);

    // Establecer tamaño Ole en el Libro de Trabajo
    workbook->GetIWorksheets()->SetOleSize(startRow, endRow, startCol, endCol);
    workbook->GetIWorksheets()->GetObjectByIndex(0)->SetGridlinesVisible(false);

    // Establecer opciones de imagen para tomar la imagen de la hoja de cálculo
    intrusive_ptr<Aspose::Cells::Rendering::IImageOrPrintOptions> imageOrPrintOptions = Aspose::Cells::Factory::CreateIImageOrPrintOptions();
    imageOrPrintOptions->SetImageFormat(Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetBmp());
    imageOrPrintOptions->SetOnePagePerSheet(onePagePerSheet);

    intrusive_ptr<Aspose::Cells::Rendering::ISheetRender> render = Aspose::Cells::Factory::CreateISheetRender(workbookDesigner->GetIWorkbook()->GetIWorksheets()->GetObjectByIndex(dataSheetIdx), imageOrPrintOptions);
    tempFileName.append(L".bmp");
    render->ToImage(0, new String(tempFileName.c_str()));

    System::String slidesTempFileName = System::String::FromWCS(tempFileName);
    System::SharedPtr<System::Drawing::Image> image = ScaleImage(System::Drawing::Image::FromFile(slidesTempFileName), outputWidth, outputHeight);
    System::String newTempFileName = slidesTempFileName.Replace(u".tmp", u".tmp1");
    image->Save(newTempFileName, System::Drawing::Imaging::ImageFormat::get_Bmp());

    // Agregar imagen a la colección de imágenes de la diapositiva
    auto ppImage = presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(newTempFileName));

    // Guardar libro de trabajo en flujo y copiando en array de bytes
    System::SharedPtr<System::IO::Stream> mstream = ToSlidesMemoryStream(workbook->SaveToStream());
    System::ArrayPtr<uint8_t> chartOleData = System::MakeArray<uint8_t>(mstream->get_Length(), 0);
    mstream->set_Position(0);
    mstream->Read(chartOleData, 0, chartOleData->get_Length());

    // Agregar marco de objeto Ole
    System::SharedPtr<OleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(chartOleData, u"xls");
    System::SharedPtr<IOleObjectFrame> oleObjectFrame = slide->get_Shapes()->AddOleObjectFrame(x, y, OleWidth, OleHeight, dataInfo);

    // Establecer imagen de marco ole y texto alternativo    
    oleObjectFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(ppImage);
    oleObjectFrame->set_AlternativeText(System::String(u"image") + ppImage);
}
```

``` cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    System::ArrayPtr<uint8_t> outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

``` cpp
System::SharedPtr<System::Drawing::Image> ScaleImage(System::SharedPtr<System::Drawing::Image> image, int32_t outputWidth, int32_t outputHeight)
{
    if (outputWidth == 0 && outputHeight == 0)
    {
        outputWidth = image->get_Width();
        outputHeight = image->get_Height();
    }
    System::SharedPtr<System::Drawing::Bitmap> outputImage = System::MakeObject<System::Drawing::Bitmap>(outputWidth, outputHeight, image->get_PixelFormat());
    outputImage->SetResolution(image->get_HorizontalResolution(), image->get_VerticalResolution());
    System::SharedPtr<System::Drawing::Graphics> graphics = System::Drawing::Graphics::FromImage(outputImage);
    graphics->set_InterpolationMode(System::Drawing::Drawing2D::InterpolationMode::HighQualityBicubic);
    System::Drawing::Rectangle srcDestRect(0, 0, outputWidth, outputHeight);
    graphics->DrawImage(image, srcDestRect, srcDestRect, System::Drawing::GraphicsUnit::Pixel);
    graphics->Dispose();

    return outputImage;
}
```

## **Conclusión**


{{% alert color="primary" %}}   {{% /alert %}} 

Hay dos enfoques para solucionar el problema de redimensionamiento de la hoja de cálculo. La selección del enfoque apropiado depende de los requisitos y del caso de uso. Ambos enfoques funcionan de la misma manera ya sea que las presentaciones se creen a partir de una plantilla o se creen desde cero. Además, no hay límite en el tamaño del Marco de Objeto OLE en la solución. 


h4. {_}Secciones Relacionadas 
{_}

[Creación e Incrustación de un Gráfico de Excel como Objeto OLE en la Presentación](/slides/es/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)