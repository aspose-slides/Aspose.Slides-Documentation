---
title: Δημιουργία διαγραμμάτων Excel και ενσωμάτωσή τους σε παρουσιάσεις ως αντικείμενα OLE
type: docs
weight: 40
url: /el/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Διάγραμμα Excel
- ενσωμάτωση διαγράμματος
- αντικείμενο OLE
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Δημιουργήστε διαγράμματα Excel και ενσωματώστε τα ως αντικείμενα OLE σε παρουσιάσεις PowerPoint και OpenDocument με C++. Οδηγός βήμα προς βήμα με δείγματα κώδικα."
---
## **Ιστορικό**

Στο PowerPoint, η χρήση επεξεργάσιμων διαγραμμάτων για την απεικόνιση δεδομένων γραφικά αποτελεί κοινή πρακτική. Το Aspose υποστηρίζει τη δημιουργία διαγραμμάτων Excel με το Aspose.Cells για C++, και αυτά τα διαγράμματα μπορούν στη συνέχεια να ενσωματωθούν ως αντικείμενα OLE στις διαφάνειες του PowerPoint μέσω του Aspose.Slides για C++. Αυτό το άρθρο καλύπτει τα απαραίτητα βήματα και παρέχει δείγματα κώδικα C++ για τη δημιουργία διαγράμματος Excel και την ενσωμάτωσή του ως αντικείμενο OLE σε παρουσίαση PowerPoint χρησιμοποιώντας τα Aspose.Cells και Aspose.Slides.

## **Απαιτούμενα Βήματα**

1. Δημιουργήστε ένα διάγραμμα Excel χρησιμοποιώντας το Aspose.Cells.
1. Ορίστε το μέγεθος OLE του διαγράμματος Excel χρησιμοποιώντας το Aspose.Cells.
1. Αποκτήστε μια εικόνα του διαγράμματος Excel με το Aspose.Cells.
1. Ενσωματώστε το διάγραμμα Excel ως αντικείμενο OLE σε μια παρουσίαση PPTX χρησιμοποιώντας το Aspose.Slides.
1. Αντικαταστήστε την εικόνα "EMBEDDED OLE OBJECT" με την εικόνα που ελήφθη στο βήμα 3 για την αντιμετώπιση του [object preview issue](/slides/el/cpp/object-preview-issue-when-adding-oleobjectframe/).
1. Αποθηκεύστε την παρουσίαση στο δίσκο σε μορφή PPTX.

## **Υλοποίηση των Απαιτούμενων Βημάτων**

```cpp
// Βήμα - 1: Δημιουργία διαγράμματος Excel χρησιμοποιώντας το Aspose.Cells.
// ---------------------------------------------------
// Δημιουργία βιβλίου εργασίας.
intrusive_ptr<Aspose::Cells::IWorkbook> workbook = Aspose::Cells::Factory::CreateIWorkbook();
// Προσθήκη διαγράμματος Excel.
int32_t chartRows = 55;
int32_t chartCols = 25;
int32_t chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Βήμα - 2: Ορισμός του μεγέθους OLE του διαγράμματος χρησιμοποιώντας το Aspose.Cells.
// -----------------------------------------------------------
workbook->GetIWorksheets()->SetOleSize(0, chartRows, 0, chartCols);

// Βήμα - 3: Λήψη της εικόνας του διαγράμματος με το Aspose.Cells.
// -------------------------------------------------------
System::SharedPtr<System::Drawing::Bitmap> chartImage = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex)->GetICharts()->GetObjectByIndex(0)->ToImage();
// Save the workbook to a stream.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

// Βήμα - 4 ΚΑΙ 5
// ==============
// Βήμα - 4: Ενσωμάτωση του διαγράμματος ως αντικείμενο OLE μέσα σε παρουσίαση .ppt χρησιμοποιώντας το Aspose.Slides.
// ------------------------------------------------------------------------------------------
// Βήμα - 5: Αντικατάσταση της εικόνας "EMBEDDED OLE OBJECT" με την εικόνα που ελήφθη στο βήμα 3 για την αντιμετώπιση του προβλήματος προεπισκόπησης αντικειμένου.
// --------------------------------------------------------------------------------------------------------------------
// Create a presentation.
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);
// Add the workbook to the slide.
AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

// Βήμα - 6: Αποθήκευση της εξόδου παρουσίασης στο δίσκο.
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
    // Πίνακας ονομάτων κελιών.
    System::ArrayPtr<System::String> cellNames = System::MakeArray<System::String>(
    { 
        u"A1", u"A2", u"A3", u"A4", 
        u"B1", u"B2", u"B3", u"B4",
        u"C1", u"C2", u"C3", u"C4",
        u"D1", u"D2", u"D3", u"D4",
        u"E1", u"E2", u"E3", u"E4" 
    });
    
    // Πίνακας δεδομένων κελιών.
    System::ArrayPtr<int32_t> cellValues = System::MakeArray<int32_t>(
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25 
    });

    // Προσθήκη νέου φύλλου εργασίας για την καταχώρηση κελιών με δεδομένα.
    int32_t dataSheetIndex = workbook->GetIWorksheets()->Add();
    intrusive_ptr<Aspose::Cells::IWorksheet> dataSheet = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIndex);
    intrusive_ptr<Aspose::Cells::Systems::String> sheetName = new Aspose::Cells::Systems::String("DataSheet");
    dataSheet->SetName(sheetName);

    // Συμπλήρωση του φύλλου δεδομένων με δεδομένα.
    for (int32_t i = 0; i < cellNames->get_Length(); i++)
    {
        System::String cellName = cellNames[i];
        int32_t cellValue = cellValues[i];
        dataSheet->GetICells()->GetObjectByIndex(new String(cellName.ToWCS().c_str()))->PutValue(cellValue);
    }

    // Προσθήκη φύλλου διαγράμματος.
    int32_t chartSheetIndex = workbook->GetIWorksheets()->Add(Aspose::Cells::SheetType::SheetType_Chart);
    intrusive_ptr<Aspose::Cells::IWorksheet> chartSheet = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex);
    chartSheet->SetName(new String("ChartSheet"));

    // Προσθήκη διαγράμματος στο φύλλο διαγράμματος με σειρές δεδομένων από το φύλλο δεδομένων.
    int32_t chartIndex = chartSheet->GetICharts()->Add(Aspose::Cells::Charts::ChartType::ChartType_Column, 0, chartRows, 0, chartCols);
    intrusive_ptr<Aspose::Cells::Charts::IChart> chart = chartSheet->GetICharts()->GetObjectByIndex(chartIndex);
    chart->GetNISeries()->Add(sheetName + "!A1:E1", false);
    chart->GetNISeries()->Add(sheetName + "!A2:E2", false);
    chart->GetNISeries()->Add(sheetName + "!A3:E3", false);
    chart->GetNISeries()->Add(sheetName + "!A4:E4", false);

    // Ορισμός του φύλλου διαγράμματος ως ενεργό φύλλο.
    workbook->GetIWorksheets()->SetActiveSheetIndex(chartSheetIndex);

    return chartSheetIndex;
}
```

Η παρουσίαση που δημιουργείται με τη παραπάνω μέθοδο θα περιέχει το διάγραμμα Excel ως αντικείμενο OLE που μπορεί να ενεργοποιηθεί με διπλό κλικ στο πλαίσιο του αντικειμένου OLE.

## **Συμπέρασμα**

Χρησιμοποιώντας το Aspose.Cells για C++ μαζί με το Aspose.Slides για C++, μπορούμε να δημιουργήσουμε οποιοδήποτε διάγραμμα Excel που υποστηρίζεται από το Aspose.Cells και να ενσωματώσουμε το διάγραμμα ως αντικείμενο OLE σε μια διαφάνεια PowerPoint. Το μέγεθος OLE του διαγράμματος Excel μπορεί επίσης να οριστεί. Οι τελικοί χρήστες μπορούν έπειτα να επεξεργαστούν το διάγραμμα Excel όπως οποιοδήποτε άλλο αντικείμενο OLE.

## **Σχετικές Ενότητες**

- [Λύση λειτουργίας για αλλαγή μεγέθους διαγράμματος σε PPTX](/slides/el/cpp/working-solution-for-chart-resizing-in-pptx/)
- [Πρόβλημα προεπισκόπησης αντικειμένου κατά την προσθήκη OleObjectFrame](/slides/el/cpp/object-preview-issue-when-adding-oleobjectframe/)