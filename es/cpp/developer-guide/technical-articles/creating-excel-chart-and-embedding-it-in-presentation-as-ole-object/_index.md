---
title: Creando un gráfico de Excel e insertándolo en una presentación como objeto OLE
type: docs
weight: 40
url: /cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
---

{{% alert color="primary" %}} 

En las diapositivas de PowerPoint, el uso de gráficos editables para la representación gráfica de los datos es una actividad común. Aspose proporciona el soporte para crear gráficos de Excel utilizando Aspose.Cells para C++ y, además, estos gráficos pueden ser incrustados como un objeto OLE en la diapositiva de PowerPoint a través de Aspose.Slides para C++. Este artículo cubre los pasos requeridos junto con la implementación en C++ para crear e incrustar un gráfico de MS Excel como un objeto OLE en una presentación de PowerPoint utilizando Aspose.Cells para C++ y Aspose.Slides para C++.

{{% /alert %}} 
## **Pasos Requeridos**
La siguiente secuencia de pasos es necesaria para crear e incrustar un gráfico de Excel como un objeto OLE en la diapositiva de PowerPoint:

1. Crear un gráfico de Excel utilizando Aspose.Cells para C++.
2. Establecer el tamaño OLE del gráfico de Excel utilizando Aspose.Cells para C++. 
3. Obtener la imagen del gráfico de Excel con Aspose.Cells para C++. 
4. Incrustar el gráfico de Excel como un objeto OLE dentro de la presentación PPTX utilizando Aspose.Slides para C++. 
5. Reemplazar la imagen del objeto cambiado con la imagen obtenida en el paso 3 para atender el problema de objeto cambiado.
6. Escribir la presentación de salida en el disco en formato PPTX.

## **Implementación de los Pasos Requeridos**
La implementación de los pasos anteriores en C++ es la siguiente:

``` cpp
//Paso - 1: Crear un gráfico de Excel utilizando Aspose.Cells
//--------------------------------------------------
//Crear un libro de trabajo
intrusive_ptr<Aspose::Cells::IWorkbook> wb = Aspose::Cells::Factory::CreateIWorkbook();
//Agregar un gráfico de Excel
int32_t chartRows = 55;
int32_t chartCols = 25;
int32_t chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Paso - 2: Establecer el tamaño OLE del gráfico utilizando Aspose.Cells
//----------------------------------------------------------- 
wb->GetIWorksheets()->SetOleSize(0, chartRows, 0, chartCols);
//Paso - 3: Obtener la imagen del gráfico con Aspose.Cells
//-----------------------------------------------------------
//System::SharedPtr<System::Drawing::Bitmap>
auto imgChart = wb->GetIWorksheets()->GetObjectByIndex(chartSheetIndex)->GetICharts()->GetObjectByIndex(0)->ToImage();
//Guardar el libro de trabajo en un flujo
System::SharedPtr<System::IO::MemoryStream> wbStream = ToSlidesMemoryStream(wb->SaveToStream());
//Paso - 4 Y 5
//-----------------------------------------------------------
//Paso - 4: Incrustar el gráfico como un objeto OLE dentro de la presentación .ppt utilizando Aspose.Slides
//-----------------------------------------------------------
//Paso - 5: Reemplazar la imagen del objeto cambiado con la imagen obtenida en el paso 3 para atender el problema de objeto cambiado
//-----------------------------------------------------------
//Crear una presentación
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
System::SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Agregar el libro de trabajo en la diapositiva
AddExcelChartInPresentation(pres, slide, wbStream, imgChart);

//Paso - 6: Escribir la presentación de salida en el disco
//----------------------------------------------------------- 
pres->Save(u"d:/OutputChart.pptx", SaveFormat::Pptx);
```

``` cpp
void AddExcelChartInPresentation(System::SharedPtr<Presentation> pres, System::SharedPtr<ISlide> sld, 
                                    System::SharedPtr<System::IO::Stream> wbStream, 
                                    intrusive_ptr<Aspose::Cells::Systems::Drawing::Bitmap> imgChart)
{
    float oleWidth = pres->get_SlideSize()->get_Size().get_Width();
    float oleHeight = pres->get_SlideSize()->get_Size().get_Height();
    int32_t x = 0;
    System::ArrayPtr<uint8_t> chartOleData = System::MakeArray<uint8_t>(wbStream->get_Length(), 0);
    wbStream->set_Position(0);
    wbStream->Read(chartOleData, 0, chartOleData->get_Length());

    System::SharedPtr<OleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(chartOleData, u"xls");
    System::SharedPtr<IOleObjectFrame> oof;
    oof = sld->get_Shapes()->AddOleObjectFrame(static_cast<float>(x), 0.0f, oleWidth, oleHeight, dataInfo);

    intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
    imgChart->Save(cellsOutputStream, Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetBmp());

    auto imgChartSlides = Images::FromStream(ToSlidesMemoryStream(cellsOutputStream));
    oof->get_SubstitutePictureFormat()->get_Picture()->set_Image(pres->get_Images()->AddImage(imgChartSlides));
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
int32_t AddExcelChartInWorkbook(intrusive_ptr<Aspose::Cells::IWorkbook> wb, int32_t chartRows, int32_t chartCols)
{
    // Arreglo de nombres de celdas
    System::ArrayPtr<System::String> cellsName = System::MakeArray<System::String>(
        { u"A1", u"A2", u"A3", u"A4", 
            u"B1", u"B2", u"B3", u"B4",
            u"C1", u"C2", u"C3", u"C4",
            u"D1", u"D2", u"D3", u"D4",
            u"E1", u"E2", u"E3", u"E4" });
    
    // Arreglo de valores de celdas
    System::ArrayPtr<int32_t> cellsValue = System::MakeArray<int32_t>(
        { 67, 86, 68, 91,
            44, 64, 89, 48,
            46, 97, 78, 60,
            43, 29, 69, 26,
            24, 40, 38, 25 });

    // Agregar una nueva hoja de trabajo para llenar celdas con datos
    int32_t dataSheetIdx = wb->GetIWorksheets()->Add();
    intrusive_ptr<Aspose::Cells::IWorksheet> dataSheet = wb->GetIWorksheets()->GetObjectByIndex(dataSheetIdx);
    intrusive_ptr<Aspose::Cells::Systems::String> sheetName = new Aspose::Cells::Systems::String("DataSheet");
    dataSheet->SetName(sheetName);

    // Llenar la hoja de datos con datos
    for (int32_t i = 0; i < cellsName->get_Length(); i++)
    {
        System::String cellName = cellsName[i];
        int32_t cellValue = cellsValue[i];
        dataSheet->GetICells()->GetObjectByIndex(new String(cellName.ToWCS().c_str()))->PutValue(cellValue);
    }

    // Agregar una hoja de gráfico
    int32_t chartSheetIdx = wb->GetIWorksheets()->Add(Aspose::Cells::SheetType::SheetType_Chart);
    intrusive_ptr<Aspose::Cells::IWorksheet> chartSheet = wb->GetIWorksheets()->GetObjectByIndex(chartSheetIdx);
    chartSheet->SetName(new String("ChartSheet"));

    // Agregar un gráfico en la hoja de gráfico con series de datos de la hoja de datos
    int32_t chartIdx = chartSheet->GetICharts()->Add(Aspose::Cells::Charts::ChartType::ChartType_Column, 0, chartRows, 0, chartCols);
    intrusive_ptr<Aspose::Cells::Charts::IChart> chart = chartSheet->GetICharts()->GetObjectByIndex(chartIdx);
    chart->GetNISeries()->Add(sheetName + "!A1:E1", false);
    chart->GetNISeries()->Add(sheetName + "!A2:E2", false);
    chart->GetNISeries()->Add(sheetName + "!A3:E3", false);
    chart->GetNISeries()->Add(sheetName + "!A4:E4", false);

    // Establecer la hoja de gráfico como hoja activa
    wb->GetIWorksheets()->SetActiveSheetIndex(chartSheetIdx);

    return chartSheetIdx;
}
```

{{% alert color="primary" %}} 

La presentación creada a través del método anterior llevará el gráfico de Excel como objeto OLE que puede ser activado haciendo doble clic en el marco del objeto OLE.

{{% /alert %}} 
## **Conclusión**
{{% alert color="primary" %}} 

Al utilizar Aspose.Cells para C++ junto con Aspose.Slides para C++, podemos crear cualquiera de los gráficos de Excel que son compatibles con Aspose.Cells para C++ e incrustar el gráfico creado como un objeto OLE en una diapositiva de PowerPoint. El tamaño OLE del gráfico de Excel también se puede definir. Los usuarios finales pueden editar aún más el gráfico de Excel como cualquier otro objeto OLE.

{{% /alert %}} 
## **Secciones Relacionadas**
[Solución Funcional para el Redimensionamiento de Gráficos](https://docs.aspose.com/slides/cpp/working-solution-for-chart-resizing-in-pptx/)