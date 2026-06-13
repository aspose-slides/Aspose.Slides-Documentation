---
title: Excel चार्ट बनाएं और उन्हें OLE ऑब्जेक्ट के रूप में प्रस्तुतियों में एम्बेड करें
type: docs
weight: 40
url: /hi/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel चार्ट
- चार्ट एम्बेड करें
- OLE ऑब्जेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Excel चार्ट बनाएं और उन्हें PowerPoint और OpenDocument प्रस्तुतियों में C++ के साथ OLE ऑब्जेक्ट के रूप में एम्बेड करें। चरण-दर-चरण मार्गदर्शिका कोड नमूनों के साथ।"
---
## **पृष्ठभूमि**

PowerPoint में, ग्राफिकल रूप से डेटा प्रदर्शित करने के लिए संपादन योग्य चार्ट्स का उपयोग आम प्रथा है। Aspose, Aspose.Cells for C++ के साथ Excel चार्ट बनाने का समर्थन करता है, और इन्हें फिर Aspose.Slides for C++ के माध्यम से PowerPoint स्लाइड्स में OLE ऑब्जेक्ट के रूप में एम्बेड किया जा सकता है। यह लेख आवश्यक चरणों को कवर करता है और Aspose.Cells और Aspose.Slides का उपयोग करके Excel चार्ट बनाने और उसे PowerPoint प्रस्तुति में OLE ऑब्जेक्ट के रूप में एम्बेड करने के लिए C++ कोड नमूने प्रदान करता है।

## **आवश्यक चरण**

PowerPoint स्लाइड में Excel चार्ट को OLE ऑब्जेक्ट के रूप में बनाने और एम्बेड करने के लिए निम्न क्रम के चरण आवश्यक हैं:

1. Aspose.Cells का उपयोग करके एक Excel चार्ट बनाएं।
1. Aspose.Cells का उपयोग करके Excel चार्ट का OLE आकार सेट करें।
1. Aspose.Cells के साथ Excel चार्ट की छवि प्राप्त करें।
1. Aspose.Slides का उपयोग करके Excel चार्ट को PPTX प्रस्तुति में OLE ऑब्जेक्ट के रूप में एम्बेड करें।
1. चरण 3 में प्राप्त छवि के साथ "EMBEDDED OLE OBJECT" छवि को बदलें ताकि [object preview issue](/slides/hi/cpp/object-preview-issue-when-adding-oleobjectframe/) का समाधान हो सके।
1. प्रस्तुति को डिस्क पर PPTX फ़ॉर्मेट में सहेजें।

## **आवश्यक चरणों का कार्यान्वयन**

ऊपर दिए गए चरणों का C++ कार्यान्वयन इस प्रकार है:

```cpp
// चरण - 1: Aspose.Cells का उपयोग करके Excel चार्ट बनाएं।
// ---------------------------------------------------
// Create a workbook.
intrusive_ptr<Aspose::Cells::IWorkbook> workbook = Aspose::Cells::Factory::CreateIWorkbook();
// Add an Excel chart.
int32_t chartRows = 55;
int32_t chartCols = 25;
int32_t chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// चरण - 2: Aspose.Cells का उपयोग करके चार्ट का OLE आकार सेट करें।
// -----------------------------------------------------------
workbook->GetIWorksheets()->SetOleSize(0, chartRows, 0, chartCols);

// चरण - 3: Aspose.Cells के साथ चार्ट की छवि प्राप्त करें।
// -------------------------------------------------------
System::SharedPtr<System::Drawing::Bitmap> chartImage = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex)->GetICharts()->GetObjectByIndex(0)->ToImage();
// Save the workbook to a stream.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

// चरण - 4 और 5
// ==============
 // चरण - 4: Aspose.Slides का उपयोग करके .ppt प्रस्तुति में चार्ट को OLE ऑब्जेक्ट के रूप में एम्बेड करें।
 // ------------------------------------------------------------------------------------------
 // चरण - 5: "EMBEDDED OLE OBJECT" छवि को चरण 3 में प्राप्त छवि से बदलें ताकि ऑब्जेक्ट प्रीव्यू समस्या का समाधान हो सके।
 // --------------------------------------------------------------------------------------------------------------------
 // Create a presentation.
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);
// Add the workbook to the slide.
AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

// चरण - 6: आउटपुट प्रस्तुति को डिस्क पर सहेजें।
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

```cpp
int32_t AddExcelChartInWorkbook(intrusive_ptr<Aspose::Cells::IWorkbook> workbook, int32_t chartRows, int32_t chartCols)
{
    // सेल नामों की एक array।
    System::ArrayPtr<System::String> cellNames = System::MakeArray<System::String>(
    { 
        u"A1", u"A2", u"A3", u"A4", 
        u"B1", u"B2", u"B3", u"B4",
        u"C1", u"C2", u"C3", u"C4",
        u"D1", u"D2", u"D3", u"D4",
        u"E1", u"E2", u"E3", u"E4" 
    });
    
    // सेल डेटा की एक array।
    System::ArrayPtr<int32_t> cellValues = System::MakeArray<int32_t>(
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25 
    });

    // डेटा के साथ कोशिकाओं को भरने के लिए एक नया वर्कशीट जोड़ें।
    int32_t dataSheetIndex = workbook->GetIWorksheets()->Add();
    intrusive_ptr<Aspose::Cells::IWorksheet> dataSheet = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIndex);
    intrusive_ptr<Aspose::Cells::Systems::String> sheetName = new Aspose::Cells::Systems::String("DataSheet");
    dataSheet->SetName(sheetName);

    // डेटा शीट को डेटा से भरें।
    for (int32_t i = 0; i < cellNames->get_Length(); i++)
    {
        System::String cellName = cellNames[i];
        int32_t cellValue = cellValues[i];
        dataSheet->GetICells()->GetObjectByIndex(new String(cellName.ToWCS().c_str()))->PutValue(cellValue);
    }

    // एक चार्ट शीट जोड़ें।
    int32_t chartSheetIndex = workbook->GetIWorksheets()->Add(Aspose::Cells::SheetType::SheetType_Chart);
    intrusive_ptr<Aspose::Cells::IWorksheet> chartSheet = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex);
    chartSheet->SetName(new String("ChartSheet"));

    // डेटा शीट से डेटा श्रृंखला के साथ चार्ट शीट में चार्ट जोड़ें।
    int32_t chartIndex = chartSheet->GetICharts()->Add(Aspose::Cells::Charts::ChartType::ChartType_Column, 0, chartRows, 0, chartCols);
    intrusive_ptr<Aspose::Cells::Charts::IChart> chart = chartSheet->GetICharts()->GetObjectByIndex(chartIndex);
    chart->GetNISeries()->Add(sheetName + "!A1:E1", false);
    chart->GetNISeries()->Add(sheetName + "!A2:E2", false);
    chart->GetNISeries()->Add(sheetName + "!A3:E3", false);
    chart->GetNISeries()->Add(sheetName + "!A4:E4", false);

    // चार्ट शीट को सक्रिय शीट के रूप में सेट करें।
    workbook->GetIWorksheets()->SetActiveSheetIndex(chartSheetIndex);

    return chartSheetIndex;
}
```

उपरोक्त विधि से निर्मित प्रस्तुति में Excel चार्ट एक OLE ऑब्जेक्ट के रूप में रहेगा जिसे OLE ऑब्जेक्ट फ्रेम को दो बार क्लिक करके सक्रिय किया जा सकता है।

## **निष्कर्ष**

Aspose.Cells for C++ को Aspose.Slides for C++ के साथ उपयोग करके, हम Aspose.Cells द्वारा समर्थित कोई भी Excel चार्ट बना सकते हैं और उसे PowerPoint स्लाइड में OLE ऑब्जेक्ट के रूप में एम्बेड कर सकते हैं। Excel चार्ट का OLE आकार भी परिभाषित किया जा सकता है। अंत उपयोगकर्ता Excel चार्ट को किसी भी अन्य OLE ऑब्जेक्ट की तरह संपादित कर सकते हैं।

## **संबंधित अनुभाग**

- [PPTX में चार्ट रिसाइज़िंग के लिए कार्यशील समाधान](/slides/hi/cpp/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame जोड़ते समय ऑब्जेक्ट प्रीव्यू समस्या](/slides/hi/cpp/object-preview-issue-when-adding-oleobjectframe/)