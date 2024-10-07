---  
title: Erstellung eines Excel-Diagramms und Einbettung als OLE-Objekt in die Präsentation  
type: docs  
weight: 40  
url: /cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/  
---  

{{% alert color="primary" %}}  

In PowerPoint-Folien ist die Verwendung von editierbaren Diagrammen zur grafischen Darstellung der Daten eine gängige Aktivität. Aspose bietet die Unterstützung zur Erstellung von Excel-Diagrammen mithilfe von Aspose.Cells für C++, und diese Diagramme können dann als OLE-Objekt in die PowerPoint-Folie über Aspose.Slides für C++ eingebettet werden. Dieser Artikel beschreibt die erforderlichen Schritte sowie die Implementierung in C++, um ein MS Excel-Diagramm als OLE-Objekt in einer PowerPoint-Präsentation zu erstellen und einzubetten, indem Aspose.Cells für C++ und Aspose.Slides für C++ verwendet werden.  

{{% /alert %}}  
## **Erforderliche Schritte**  
Die folgende Abfolge von Schritten ist erforderlich, um ein Excel-Diagramm als OLE-Objekt in der PowerPoint-Folie zu erstellen und einzubetten:  

1. Erstellen Sie ein Excel-Diagramm mit Aspose.Cells für C++.  
2. Legen Sie die OLE-Größe des Excel-Diagramms mit Aspose.Cells für C++ fest.  
3. Holen Sie das Bild des Excel-Diagramms mit Aspose.Cells für C++.  
4. Betten Sie das Excel-Diagramm als OLE-Objekt in die PPTX-Präsentation mit Aspose.Slides für C++ ein.  
5. Ersetzen Sie das geänderte Objektbild durch das in Schritt 3 erhaltene Bild, um das Problem „Objekt geändert“ zu beheben.  
6. Schreiben Sie die Ausgabpräsentation auf die Festplatte im PPTX-Format.  

## **Implementierung der erforderlichen Schritte**  
Die Implementierung der oben genannten Schritte in C++ sieht wie folgt aus:  

``` cpp  
// Schritt - 1: Erstellen Sie ein Excel-Diagramm mit Aspose.Cells  
//--------------------------------------------------  
// Erstellen Sie ein Arbeitsbuch  
intrusive_ptr<Aspose::Cells::IWorkbook> wb = Aspose::Cells::Factory::CreateIWorkbook();  
// Fügen Sie ein Excel-Diagramm hinzu  
int32_t chartRows = 55;  
int32_t chartCols = 25;  
int32_t chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);  
// Schritt - 2: Legen Sie die OLE-Größe des Diagramms mit Aspose.Cells fest  
//-----------------------------------------------------------  
wb->GetIWorksheets()->SetOleSize(0, chartRows, 0, chartCols);  
// Schritt - 3: Holen Sie das Bild des Diagramms mit Aspose.Cells  
//-----------------------------------------------------------  
//System::SharedPtr<System::Drawing::Bitmap>  
auto imgChart = wb->GetIWorksheets()->GetObjectByIndex(chartSheetIndex)->GetICharts()->GetObjectByIndex(0)->ToImage();  
// Speichern Sie das Arbeitsbuch im Stream  
System::SharedPtr<System::IO::MemoryStream> wbStream = ToSlidesMemoryStream(wb->SaveToStream());  
// Schritt - 4 UND 5  
//-----------------------------------------------------------  
// Schritt - 4: Betten Sie das Diagramm als OLE-Objekt in die .ppt-Präsentation mit Aspose.Slides ein  
//-----------------------------------------------------------  
// Schritt - 5: Ersetzen Sie das geänderte Objektbild durch das in Schritt 3 erhaltene Bild, um das Problem „Objekt geändert“ zu beheben  
//-----------------------------------------------------------  
// Erstellen Sie eine Präsentation  
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();  
System::SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);  

// Fügen Sie das Arbeitsbuch in die Folie ein  
AddExcelChartInPresentation(pres, slide, wbStream, imgChart);  

// Schritt - 6: Schreiben Sie die Ausgabpräsentation auf die Festplatte  
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
    // Array von Zellnamen  
    System::ArrayPtr<System::String> cellsName = System::MakeArray<System::String>(  
        { u"A1", u"A2", u"A3", u"A4",  
            u"B1", u"B2", u"B3", u"B4",  
            u"C1", u"C2", u"C3", u"C4",  
            u"D1", u"D2", u"D3", u"D4",  
            u"E1", u"E2", u"E3", u"E4" });  

    // Array von Zellwerten  
    System::ArrayPtr<int32_t> cellsValue = System::MakeArray<int32_t>(  
        { 67, 86, 68, 91,  
            44, 64, 89, 48,  
            46, 97, 78, 60,  
            43, 29, 69, 26,  
            24, 40, 38, 25 });  

    // Fügen Sie ein neues Arbeitsblatt hinzu, um Zellen mit Daten zu füllen  
    int32_t dataSheetIdx = wb->GetIWorksheets()->Add();  
    intrusive_ptr<Aspose::Cells::IWorksheet> dataSheet = wb->GetIWorksheets()->GetObjectByIndex(dataSheetIdx);  
    intrusive_ptr<Aspose::Cells::Systems::String> sheetName = new Aspose::Cells::Systems::String("DataSheet");  
    dataSheet->SetName(sheetName);  

    // Füllen Sie das DataSheet mit Daten  
    for (int32_t i = 0; i < cellsName->get_Length(); i++)  
    {  
        System::String cellName = cellsName[i];  
        int32_t cellValue = cellsValue[i];  
        dataSheet->GetICells()->GetObjectByIndex(new String(cellName.ToWCS().c_str()))->PutValue(cellValue);  
    }  

    // Fügen Sie ein Diagrammblatt hinzu  
    int32_t chartSheetIdx = wb->GetIWorksheets()->Add(Aspose::Cells::SheetType::SheetType_Chart);  
    intrusive_ptr<Aspose::Cells::IWorksheet> chartSheet = wb->GetIWorksheets()->GetObjectByIndex(chartSheetIdx);  
    chartSheet->SetName(new String("ChartSheet"));  

    // Fügen Sie ein Diagramm im Diagrammblatt mit Datenreihen vom DataSheet hinzu  
    int32_t chartIdx = chartSheet->GetICharts()->Add(Aspose::Cells::Charts::ChartType::ChartType_Column, 0, chartRows, 0, chartCols);  
    intrusive_ptr<Aspose::Cells::Charts::IChart> chart = chartSheet->GetICharts()->GetObjectByIndex(chartIdx);  
    chart->GetNISeries()->Add(sheetName + "!A1:E1", false);  
    chart->GetNISeries()->Add(sheetName + "!A2:E2", false);  
    chart->GetNISeries()->Add(sheetName + "!A3:E3", false);  
    chart->GetNISeries()->Add(sheetName + "!A4:E4", false);  

    // Setzen Sie das Diagrammblatt als aktives Blatt  
    wb->GetIWorksheets()->SetActiveSheetIndex(chartSheetIdx);  

    return chartSheetIdx;  
}  
```  

{{% alert color="primary" %}}  

Die durch die oben beschriebene Methode erstellte Präsentation enthält das Excel-Diagramm als OLE-Objekt, das durch Doppelklicken auf den OLE-Objektrahmen aktiviert werden kann.  

{{% /alert %}}  
## **Fazit**  
{{% alert color="primary" %}}  

Durch die Verwendung von Aspose.Cells für C++ zusammen mit Aspose.Slides für C++ können wir jedes der Excel-Diagramme erstellen, die von Aspose.Cells für C++ unterstützt werden, und das erstellte Diagramm als OLE-Objekt in eine PowerPoint-Folie einbetten. Die OLE-Größe des Excel-Diagramms kann ebenfalls definiert werden. Die Endbenutzer können das Excel-Diagramm wie jedes andere OLE-Objekt weiter bearbeiten.  

{{% /alert %}}  
## **Verwandte Abschnitte**  
[Arbeitslösung für die Diagrammgrößenänderung](https://docs.aspose.com/slides/cpp/working-solution-for-chart-resizing-in-pptx/)  
