---
title: Excel 차트를 생성하고 프레젠테이션에 OLE 개체로 삽입
type: docs
weight: 40
url: /ko/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 차트
- 차트 삽입
- OLE 개체
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "C++를 사용하여 Excel 차트를 만들고 PowerPoint 및 OpenDocument 프레젠테이션에 OLE 개체로 삽입합니다. 단계별 가이드와 코드 샘플을 제공합니다."
---
## **배경**

PowerPoint에서 데이터를 그래픽으로 표시하기 위해 편집 가능한 차트를 사용하는 것은 일반적인 관행입니다. Aspose는 C++용 Aspose.Cells를 사용하여 Excel 차트를 생성하는 것을 지원하며, 이러한 차트를 C++용 Aspose.Slides를 통해 OLE 개체로 PowerPoint 슬라이드에 삽입할 수 있습니다. 이 문서에서는 필요한 단계를 설명하고 Aspose.Cells와 Aspose.Slides를 사용하여 Excel 차트를 생성하고 이를 OLE 개체로 PowerPoint 프레젠테이션에 삽입하는 C++ 코드 예제를 제공합니다.

## **필수 단계**

PowerPoint 슬라이드에 Excel 차트를 OLE 개체로 생성하고 삽입하려면 다음 순서대로 진행해야 합니다:

1. Aspose.Cells를 사용하여 Excel 차트를 생성합니다.
1. Aspose.Cells를 사용하여 Excel 차트의 OLE 크기를 설정합니다.
1. Aspose.Cells를 사용하여 Excel 차트의 이미지를 가져옵니다.
1. Aspose.Slides를 사용하여 Excel 차트를 PPTX 프레젠테이션에 OLE 개체로 삽입합니다.
1. 3단계에서 얻은 이미지로 "EMBEDDED OLE OBJECT" 이미지를 교체하여 [객체 미리 보기 문제](/slides/ko/cpp/object-preview-issue-when-adding-oleobjectframe/)를 해결합니다.
1. 프레젠테이션을 PPTX 형식으로 디스크에 저장합니다.

## **필수 단계 구현**

위 단계들의 C++ 구현은 다음과 같습니다:

```cpp
// Step - 1: Aspose.Cells를 사용하여 Excel 차트 만들기.
// ---------------------------------------------------
// 워크북 생성.
intrusive_ptr<Aspose::Cells::IWorkbook> workbook = Aspose::Cells::Factory::CreateIWorkbook();
// Excel 차트 추가.
int32_t chartRows = 55;
int32_t chartCols = 25;
int32_t chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Step - 2: Aspose.Cells를 사용하여 차트의 OLE 크기 설정.
// -----------------------------------------------------------
workbook->GetIWorksheets()->SetOleSize(0, chartRows, 0, chartCols);

// Step - 3: Aspose.Cells를 사용하여 차트 이미지 가져오기.
// -------------------------------------------------------
System::SharedPtr<System::Drawing::Bitmap> chartImage = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex)->GetICharts()->GetObjectByIndex(0)->ToImage();
// 워크북을 스트림에 저장.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

// Step - 4 및 5
// ==============
 // Step - 4: Aspose.Slides를 사용하여 .ppt 프레젠테이션에 차트를 OLE 개체로 삽입.
// ------------------------------------------------------------------------------------------
// Step - 5: "EMBEDDED OLE OBJECT" 이미지를 3단계에서 얻은 이미지로 교체하여 객체 미리 보기 문제 해결.
// --------------------------------------------------------------------------------------------------------------------
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);
// Add the workbook to the slide.
AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

// Step - 6: 출력 프레젠테이션을 디스크에 저장.
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
    // 셀 이름 배열.
    System::ArrayPtr<System::String> cellNames = System::MakeArray<System::String>(
    { 
        u"A1", u"A2", u"A3", u"A4", 
        u"B1", u"B2", u"B3", u"B4",
        u"C1", u"C2", u"C3", u"C4",
        u"D1", u"D2", u"D3", u"D4",
        u"E1", u"E2", u"E3", u"E4" 
    });
    
    // 셀 데이터 배열.
    System::ArrayPtr<int32_t> cellValues = System::MakeArray<int32_t>(
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25 
    });

    // 데이터로 셀을 채우기 위해 새 워크시트를 추가합니다.
    int32_t dataSheetIndex = workbook->GetIWorksheets()->Add();
    intrusive_ptr<Aspose::Cells::IWorksheet> dataSheet = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIndex);
    intrusive_ptr<Aspose::Cells::Systems::String> sheetName = new Aspose::Cells::Systems::String("DataSheet");
    dataSheet->SetName(sheetName);

    // 데이터 시트를 데이터로 채웁니다.
    for (int32_t i = 0; i < cellNames->get_Length(); i++)
    {
        System::String cellName = cellNames[i];
        int32_t cellValue = cellValues[i];
        dataSheet->GetICells()->GetObjectByIndex(new String(cellName.ToWCS().c_str()))->PutValue(cellValue);
    }

    // 차트 시트를 추가합니다.
    int32_t chartSheetIndex = workbook->GetIWorksheets()->Add(Aspose::Cells::SheetType::SheetType_Chart);
    intrusive_ptr<Aspose::Cells::IWorksheet> chartSheet = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex);
    chartSheet->SetName(new String("ChartSheet"));

    // 데이터 시트의 데이터 시리즈를 사용하여 차트 시트에 차트를 추가합니다.
    int32_t chartIndex = chartSheet->GetICharts()->Add(Aspose::Cells::Charts::ChartType::ChartType_Column, 0, chartRows, 0, chartCols);
    intrusive_ptr<Aspose::Cells::Charts::IChart> chart = chartSheet->GetICharts()->GetObjectByIndex(chartIndex);
    chart->GetNISeries()->Add(sheetName + "!A1:E1", false);
    chart->GetNISeries()->Add(sheetName + "!A2:E2", false);
    chart->GetNISeries()->Add(sheetName + "!A3:E3", false);
    chart->GetNISeries()->Add(sheetName + "!A4:E4", false);

    // 차트 시트를 활성 시트로 설정합니다.
    workbook->GetIWorksheets()->SetActiveSheetIndex(chartSheetIndex);

    return chartSheetIndex;
}
```

위 방법으로 생성된 프레젠테이션에는 OLE 개체 프레임을 더블 클릭하면 활성화할 수 있는 OLE 개체로서 Excel 차트가 포함됩니다.

## **결론**

C++용 Aspose.Cells와 C++용 Aspose.Slides를 함께 사용하면 Aspose.Cells에서 지원하는 모든 Excel 차트를 생성하고 해당 차트를 PowerPoint 슬라이드에 OLE 개체로 삽입할 수 있습니다. Excel 차트의 OLE 크기도 지정할 수 있습니다. 최종 사용자는 다른 OLE 개체와 마찬가지로 Excel 차트를 편집할 수 있습니다.

## **관련 섹션**

- [PPTX에서 차트 크기 조정을 위한 작업 솔루션](/slides/ko/cpp/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame 삽입 시 객체 미리 보기 문제](/slides/ko/cpp/object-preview-issue-when-adding-oleobjectframe/)