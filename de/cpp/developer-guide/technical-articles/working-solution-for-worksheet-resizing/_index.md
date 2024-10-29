---
title: Arbeitslösung für die Größenänderung von Arbeitsblättern
type: docs
weight: 130
url: /de/cpp/working-solution-for-worksheet-resizing/
---

{{% alert color="primary" %}} 

Es wurde beobachtet, dass Excel-Arbeitsblätter, die als OLE in einer PowerPoint-Präsentation über Aspose-Komponenten eingebettet sind, nach der ersten Aktivierung auf einen nicht identifizierten Maßstab skaliert werden. Dieses Verhalten führt zu einem erheblichen visuellen Unterschied in der Präsentation zwischen dem Zustand vor und nach der Aktivierung des Diagramms. Wir haben dieses Problem im Detail untersucht und die Lösung für dieses Problem gefunden, die in diesem Artikel behandelt wird. 

{{% /alert %}} 
## **Hintergrund**
Im Artikel Hinzufügen von OLE-Frames haben wir erklärt, wie man einen OLE-Frame in einer PowerPoint-Präsentation mit Aspose.Slides für C++ hinzufügt. Um das Problem der geänderten Objekte zu beheben, haben wir das Arbeitsblattbild des ausgewählten Bereichs dem OLE-Objekt-Frame des Diagramms zugewiesen. In der Ausgabpräsentation wird das Excel-Diagramm aktiviert, wenn wir auf den OLE-Objekt-Frame doppelklicken, der das Arbeitsblattbild zeigt. Die Endbenutzer können beliebige gewünschte Änderungen in der tatsächlichen Excel-Arbeitsmappe vornehmen und dann zur entsprechenden Folie zurückkehren, indem sie außerhalb der aktivierten Excel-Arbeitsmappe klicken. Die Größe des OLE-Objekt-Frames ändert sich, wenn der Benutzer zur Folie zurückkehrt. Der Größenänderungsfaktor ist für unterschiedliche Größen des OLE-Objekt-Frames und der eingebetteten Excel-Arbeitsmappe unterschiedlich. 
## **Ursache der Größenänderung**
Da die Excel-Arbeitsmappe ihre eigene Fenstergröße hat, versucht sie, ihre ursprüngliche Größe bei der ersten Aktivierung beizubehalten. Auf der anderen Seite hat der OLE-Objekt-Frame seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint bei der Aktivierung der Excel-Arbeitsmappe über die Größe und stellen sicher, dass sie im richtigen Verhältnis im Rahmen des Einbettungsvorgangs ist. Basierend auf den Differenzen in der Größe und Position der Excel-Fenster und des OLE-Objekt-Frames erfolgt die Größenänderung. 
## **Arbeitslösung**
Es gibt zwei mögliche Lösungen, um den Größenänderungseffekt zu vermeiden.

- Skalierung der OLE-Frame-Größe in PPT, um die Größe in Bezug auf Höhe/Breite der gewünschten Anzahl von Zeilen/Spalten im OLE-Frame anzupassen.
- Beibehaltung der konstanten OLE-Frame-Größe und Skalierung der Größe der beteiligten Zeilen/Spalten, damit sie in die ausgewählte OLE-Frame-Größe passen.
## **OLE-Frame-Größe an die Größe der ausgewählten Zeilen/Spalten anpassen**
In diesem Ansatz werden wir lernen, wie man die OLE-Frame-Größe der eingebetteten Excel-Arbeitsmappe entsprechend der kumulierten Größe der beteiligten Zeilen und Spalten im Excel-Arbeitsblatt festlegt. 
## **Beispiel**
Angenommen, wir haben ein Vorlagen-Excel-Blatt definiert und möchten dies als OLE-Frame zur Präsentation hinzufügen. In diesem Szenario wird die Größe des OLE-Objekt-Frames zuerst basierend auf der kumulierten Höhe der Zeilen und Breite der Spalten der beteiligten Arbeitsmappenzeilen und -spalten berechnet. Danach setzen wir die Größe des OLE-Frames auf diesen berechneten Wert. Um die rote **Eingebettetes Objekt**-Nachricht für den OLE-Frame in PowerPoint zu vermeiden, werden wir auch das Bild der gewünschten Teile von Zeilen und Spalten in der Arbeitsmappe abrufen und dies als OLE-Frame-Bild festlegen. 

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

    // Neue Zeilen- und Spaltenhöhe festlegen
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

    // Aktiven Blätterindex der Arbeitsmappe festlegen
    workbookDesigner->GetIWorkbook()->GetIWorksheets()->SetActiveSheetIndex(dataSheetIdx);

    // Arbeitsmappe und ausgewähltes Arbeitsblatt abrufen  
    intrusive_ptr<Aspose::Cells::IWorkbook> workbook = workbookDesigner->GetIWorkbook();
    intrusive_ptr<Aspose::Cells::IWorksheet> work = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIdx);

    // OLE-Größe gemäß den ausgewählten Zeilen und Spalten festlegen
    System::Drawing::Size SlideOleSize = SetOleAccordingToSelectedRowsColumns(workbook, startRow, endRow, startCol, endCol, dataSheetIdx);
    OleWidth = SlideOleSize.get_Width();
    OleHeight = SlideOleSize.get_Height();

    // OLE-Größe in der Arbeitsmappe festlegen
    workbook->GetIWorksheets()->SetOleSize(startRow, endRow, startCol, endCol);

    workbook->GetIWorksheets()->GetObjectByIndex(0)->SetGridlinesVisible(false);

    // Bildoptionen festlegen, um das Arbeitsblattbild abzurufen
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

    // Bild zur Folienbildersammlung hinzufügen
    auto ppImage = presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(newTempFileName));

    // Arbeitsmappe in Stream speichern und in Byte-Array kopieren
    System::SharedPtr<System::IO::Stream> mstream = ToSlidesMemoryStream(workbook->SaveToStream());
    System::ArrayPtr<uint8_t> chartOleData = System::MakeArray<uint8_t>(mstream->get_Length(), 0);
    mstream->set_Position(0);
    mstream->Read(chartOleData, 0, chartOleData->get_Length());

    // OLE-Objekt-Frame hinzufügen
    System::SharedPtr<OleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(chartOleData, u"xls");
    System::SharedPtr<IOleObjectFrame> oleObjectFrame = slide->get_Shapes()->AddOleObjectFrame(x, y, OleWidth, OleHeight, dataInfo);

    // OLE-Frame-Bild und Alternativtext festlegen    
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

## **Die Höhe der Zeilen und die Breite der Spalten des Arbeitsblatts nach OLE-Frame-Größe skalieren**
In diesem Ansatz lernen wir, wie man die Höhen der beteiligten Zeilen und die Breite der beteiligten Spalten in Übereinstimmung mit der benutzerdefiniert festgelegten OLE-Frame-Größe skalieren kann.
## **Beispiel**
Angenommen, wir haben ein Vorlagen-Excel-Blatt definiert und möchten dies als OLE-Frame zur Präsentation hinzufügen. In diesem Szenario werden wir die Größe des OLE-Frames festlegen und die Größe der Zeilen und Spalten, die im OLE-Frame-Bereich teilnehmen, skalieren. Dann speichern wir die Arbeitsmappe im Stream, um die Änderungen zu speichern und sie in ein Byte-Array zu konvertieren, um sie im OLE-Frame hinzuzufügen. Um die rote **Eingebettetes Objekt**-Nachricht für den OLE-Frame in PowerPoint zu vermeiden, werden wir auch das Bild der gewünschten Teile von Zeilen und Spalten in der Arbeitsmappe abrufen und dies als OLE-Frame-Bild festlegen. 

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

    // Neue Zeilen- und Spaltenhöhe festlegen
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

    // Aktiven Blätterindex der Arbeitsmappe festlegen
    workbookDesigner->GetIWorkbook()->GetIWorksheets()->SetActiveSheetIndex(dataSheetIdx);

    // Arbeitsmappe und ausgewähltes Arbeitsblatt abrufen  
    intrusive_ptr<Aspose::Cells::IWorkbook> workbook = workbookDesigner->GetIWorkbook();
    intrusive_ptr<Aspose::Cells::IWorksheet> work = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIdx);

    // Zeilenhöhe und Spaltenbreite gemäß benutzerdefinierter OLE-Größe skalieren
    double height = OleHeight / 576.0f;
    double width = OleWidth / 576.0f;

    // OLE-Größe gemäß ausgewählten Zeilen und Spalten festlegen
    SetOleAccordingToCustomHeightWidth(workbook, startRow, endRow, startCol, endCol, width, height, dataSheetIdx);

    // OLE-Größe in der Arbeitsmappe festlegen
    workbook->GetIWorksheets()->SetOleSize(startRow, endRow, startCol, endCol);
    workbook->GetIWorksheets()->GetObjectByIndex(0)->SetGridlinesVisible(false);

    // Bildoptionen festlegen, um das Arbeitsblattbild abzurufen
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

    // Bild zur Folienbildersammlung hinzufügen
    auto ppImage = presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(newTempFileName));

    // Arbeitsmappe in Stream speichern und in Byte-Array kopieren
    System::SharedPtr<System::IO::Stream> mstream = ToSlidesMemoryStream(workbook->SaveToStream());
    System::ArrayPtr<uint8_t> chartOleData = System::MakeArray<uint8_t>(mstream->get_Length(), 0);
    mstream->set_Position(0);
    mstream->Read(chartOleData, 0, chartOleData->get_Length());

    // OLE-Objekt-Frame hinzufügen
    System::SharedPtr<OleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(chartOleData, u"xls");
    System::SharedPtr<IOleObjectFrame> oleObjectFrame = slide->get_Shapes()->AddOleObjectFrame(x, y, OleWidth, OleHeight, dataInfo);

    // OLE-Frame-Bild und Alternativtext festlegen    
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

## **Fazit**


{{% alert color="primary" %}}   {{% /alert %}} 

Es gibt zwei Ansätze zur Behebung des Problems der Größenänderung von Arbeitsblättern. Die Wahl des geeigneten Ansatzes hängt von den Anforderungen und dem Anwendungsfall ab. Beide Ansätze funktionieren auf die gleiche Weise, unabhängig davon, ob die Präsentationen aus einer Vorlage erstellt werden oder von Grund auf neu erstellt werden. Außerdem gibt es keine Begrenzung der OLE-Objekt-Frame-Größe in der Lösung. 


h4. {_}Verwandte Abschnitte
{_}

[Erstellen und Einbetten eines Excel-Diagramms als OLE-Objekt in einer Präsentation](/slides/de/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)