---
title: Crea grafici Excel e incorporali in presentazioni come oggetti OLE
type: docs
weight: 40
url: /it/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Grafico Excel
- incorporare grafico
- oggetto OLE
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Crea grafici Excel e incorporali come oggetti OLE in presentazioni PowerPoint e OpenDocument con C++. Guida passo passo con esempi di codice."
---
## **Contesto**

In PowerPoint, l'utilizzo di grafici editabili per visualizzare i dati in modo grafico è una pratica comune. Aspose supporta la creazione di grafici Excel con Aspose.Cells per C++, e questi grafici possono essere incorporati come oggetti OLE nelle diapositive PowerPoint tramite Aspose.Slides per C++. Questo articolo descrive i passaggi necessari e fornisce esempi di codice C++ per creare un grafico Excel e incorporarlo come oggetto OLE in una presentazione PowerPoint utilizzando Aspose.Cells e Aspose.Slides.

## **Passaggi richiesti**

La seguente sequenza di passaggi è necessaria per creare e incorporare un grafico Excel come oggetto OLE in una diapositiva PowerPoint:

1. Creare un grafico Excel utilizzando Aspose.Cells.
1. Impostare la dimensione OLE del grafico Excel utilizzando Aspose.Cells.
1. Ottenere un'immagine del grafico Excel con Aspose.Cells.
1. Incorporare il grafico Excel come oggetto OLE in una presentazione PPTX utilizzando Aspose.Slides.
1. Sostituire l'immagine "EMBEDDED OLE OBJECT" con l'immagine ottenuta al punto 3 per risolvere il [problema di anteprima dell'oggetto](/slides/it/cpp/object-preview-issue-when-adding-oleobjectframe/).
1. Salvare la presentazione su disco in formato PPTX.

## **Implementazione dei passaggi richiesti**

L'implementazione C++ dei passaggi sopra indicati è la seguente:

```cpp
// Passo - 1: Crea un grafico Excel usando Aspose.Cells.
// ---------------------------------------------------
// Crea una cartella di lavoro.
intrusive_ptr<Aspose::Cells::IWorkbook> workbook = Aspose::Cells::Factory::CreateIWorkbook();
// Aggiungi un grafico Excel.
int32_t chartRows = 55;
int32_t chartCols = 25;
int32_t chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Passo - 2: Imposta la dimensione OLE del grafico usando Aspose.Cells.
// -----------------------------------------------------------
workbook->GetIWorksheets()->SetOleSize(0, chartRows, 0, chartCols);

// Passo - 3: Ottieni l'immagine del grafico con Aspose.Cells.
// -------------------------------------------------------
System::SharedPtr<System::Drawing::Bitmap> chartImage = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex)->GetICharts()->GetObjectByIndex(0)->ToImage();
// Salva la cartella di lavoro in un flusso.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

// Passo - 4 E 5
// ==============
 // Passo - 4: Incorpora il grafico come oggetto OLE all'interno di una presentazione .ppt usando Aspose.Slides.
// ------------------------------------------------------------------------------------------
 // Passo - 5: Sostituisci l'immagine "EMBEDDED OLE OBJECT" con l'immagine ottenuta al passo 3 per risolvere il problema di anteprima dell'oggetto.
// --------------------------------------------------------------------------------------------------------------------
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);
// Aggiungi la cartella di lavoro alla diapositiva.
AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

// Passo - 6: Salva la presentazione di output su disco.
// -----------------------------------------------
presentation->Save(u"OutputChart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

```cpp
void AddExcelChartInPresentation(System::SharedPtr<Presentation> presentation, System::SharedPtr<ISlide> slide, 
                                 System::SharedPtr<System::IO::Stream> workbookStream, 
                                 intrusive_ptr<Aspose::Cells::Systems::Drawing::Bitmap> chartImage)
{
    float oleWidth = presentation->get_SlideSize()->get_Size().get_Width();
    float oleHeight = presentation->get_SlideSize()->get_Size().get_Height();
    int32_t x = 0;
    System::ArrayPtr<uint8_t> oleData = System::MakeArray<uint8_t>(workbookStream->get_Length(), 0);
    workbookStream->set_Position(0);
    workbookStream->Read(oleData, 0, oleData->get_Length());

    System::SharedPtr<OleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(oleData, u"xls");
    System::SharedPtr<IOleObjectFrame> oleFrame;
    oleFrame = slide->get_Shapes()->AddOleObjectFrame(static_cast<float>(x), 0.0f, oleWidth, oleHeight, dataInfo);

    intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
    chartImage->Save(cellsOutputStream, Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetBmp());

    auto slidesImage = Images::FromStream(ToSlidesMemoryStream(cellsOutputStream));
    oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(slidesImage));
}
```

```cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    System::ArrayPtr<uint8_t> outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

``` cpp
int32_t AddExcelChartInWorkbook(intrusive_ptr<Aspose::Cells::IWorkbook> workbook, int32_t chartRows, int32_t chartCols)
{
    // Un array di nomi di celle.
    System::ArrayPtr<System::String> cellNames = System::MakeArray<System::String>(
    { 
        u"A1", u"A2", u"A3", u"A4", 
        u"B1", u"B2", u"B3", u"B4",
        u"C1", u"C2", u"C3", u"C4",
        u"D1", u"D2", u"D3", u"D4",
        u"E1", u"E2", u"E3", u"E4" 
    });
    
    // Un array di dati di celle.
    System::ArrayPtr<int32_t> cellValues = System::MakeArray<int32_t>(
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25 
    });

    // Aggiungi un nuovo foglio di lavoro per popolare le celle con i dati.
    int32_t dataSheetIndex = workbook->GetIWorksheets()->Add();
    intrusive_ptr<Aspose::Cells::IWorksheet> dataSheet = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIndex);
    intrusive_ptr<Aspose::Cells::Systems::String> sheetName = new Aspose::Cells::Systems::String("DataSheet");
    dataSheet->SetName(sheetName);

    // Popola il foglio dati con i dati.
    for (int32_t i = 0; i < cellNames->get_Length(); i++)
    {
        System::String cellName = cellNames[i];
        int32_t cellValue = cellValues[i];
        dataSheet->GetICells()->GetObjectByIndex(new String(cellName.ToWCS().c_str()))->PutValue(cellValue);
    }

    // Aggiungi un foglio grafico.
    int32_t chartSheetIndex = workbook->GetIWorksheets()->Add(Aspose::Cells::SheetType::SheetType_Chart);
    intrusive_ptr<Aspose::Cells::IWorksheet> chartSheet = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex);
    chartSheet->SetName(new String("ChartSheet"));

    // Aggiungi un grafico al foglio grafico con serie di dati dal foglio dati.
    int32_t chartIndex = chartSheet->GetICharts()->Add(Aspose::Cells::Charts::ChartType::ChartType_Column, 0, chartRows, 0, chartCols);
    intrusive_ptr<Aspose::Cells::Charts::IChart> chart = chartSheet->GetICharts()->GetObjectByIndex(chartIndex);
    chart->GetNISeries()->Add(sheetName + "!A1:E1", false);
    chart->GetNISeries()->Add(sheetName + "!A2:E2", false);
    chart->GetNISeries()->Add(sheetName + "!A3:E3", false);
    chart->GetNISeries()->Add(sheetName + "!A4:E4", false);

    // Imposta il foglio grafico come foglio attivo.
    workbook->GetIWorksheets()->SetActiveSheetIndex(chartSheetIndex);

    return chartSheetIndex;
}
```

La presentazione creata con il metodo sopra conterrà il grafico Excel come oggetto OLE che può essere attivato facendo doppio clic sul frame dell'oggetto OLE.

## **Conclusione**

Utilizzando Aspose.Cells per C++ insieme ad Aspose.Slides per C++, è possibile creare qualsiasi grafico Excel supportato da Aspose.Cells e incorporare il grafico come oggetto OLE in una diapositiva PowerPoint. È anche possibile definire la dimensione OLE del grafico Excel. Gli utenti finali possono quindi modificare il grafico Excel come qualsiasi altro oggetto OLE.

## **Sezioni correlate**

- [Soluzione funzionante per il ridimensionamento dei grafici in PPTX](/slides/it/cpp/working-solution-for-chart-resizing-in-pptx/)
- [Problema di anteprima dell'oggetto quando si aggiunge OleObjectFrame](/slides/it/cpp/object-preview-issue-when-adding-oleobjectframe/)