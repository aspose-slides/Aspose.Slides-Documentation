---
title: 建立 Excel 圖表並將其作為 OLE 物件嵌入簡報
type: docs
weight: 40
url: /zh-hant/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 圖表
- 嵌入圖表
- OLE 物件
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 C++ 建立 Excel 圖表並將其作為 OLE 物件嵌入 PowerPoint 與 OpenDocument 簡報。逐步說明與程式碼範例。"
---
## **背景**

在 PowerPoint 中，使用可編輯的圖表以圖形方式顯示資料是一種常見做法。Aspose 支援使用 Aspose.Cells for C++ 建立 Excel 圖表，這些圖表隨後可透過 Aspose.Slides for C++ 以 OLE 物件的形式嵌入 PowerPoint 投影片中。本文說明必要的步驟，並提供 C++ 程式碼範例，用於建立 Excel 圖表並將其作為 OLE 物件嵌入 PowerPoint 簡報，使用 Aspose.Cells 與 Aspose.Slides。

## **必要步驟**

1. 使用 Aspose.Cells 建立 Excel 圖表。  
2. 使用 Aspose.Cells 設定 Excel 圖表的 OLE 大小。  
3. 使用 Aspose.Cells 取得 Excel 圖表的影像。  
4. 使用 Aspose.Slides 將 Excel 圖表以 OLE 物件的形式嵌入 PPTX 簡報。  
5. 以第 3 步獲得的影像取代 “EMBEDDED OLE OBJECT” 圖片，以解決[object preview issue](/slides/zh-hant/cpp/object-preview-issue-when-adding-oleobjectframe/)。  
6. 將簡報以 PPTX 格式儲存至磁碟。

## **必要步驟的實作**

上述步驟的 C++ 實作如下：

```cpp
// 步驟 1：使用 Aspose.Cells 建立 Excel 圖表。
// ---------------------------------------------------
// 建立工作簿。
intrusive_ptr<Aspose::Cells::IWorkbook> workbook = Aspose::Cells::Factory::CreateIWorkbook();
// 加入 Excel 圖表。
int32_t chartRows = 55;
int32_t chartCols = 25;
int32_t chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// 步驟 2：使用 Aspose.Cells 設定圖表的 OLE 大小。
// -----------------------------------------------------------
workbook->GetIWorksheets()->SetOleSize(0, chartRows, 0, chartCols);

// 步驟 3：使用 Aspose.Cells 取得圖表的影像。
// -------------------------------------------------------
System::SharedPtr<System::Drawing::Bitmap> chartImage = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex)->GetICharts()->GetObjectByIndex(0)->ToImage();
// Save the workbook to a stream.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

// 步驟 4 與 5
// ==============
 // 步驟 4：使用 Aspose.Slides 將圖表以 OLE 物件嵌入 .ppt 簡報中。
// ------------------------------------------------------------------------------------------
// 步驟 5：將「EMBEDDED OLE OBJECT」圖像替換為第 3 步取得的圖像，以解決物件預覽問題。
// --------------------------------------------------------------------------------------------------------------------
// 建立簡報。
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);
// 將工作簿加入投影片。
AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

// 步驟 6：將輸出簡報儲存至磁碟。
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
    // 儲存格名稱陣列。
    System::ArrayPtr<System::String> cellNames = System::MakeArray<System::String>(
    { 
        u"A1", u"A2", u"A3", u"A4", 
        u"B1", u"B2", u"B3", u"B4",
        u"C1", u"C2", u"C3", u"C4",
        u"D1", u"D2", u"D3", u"D4",
        u"E1", u"E2", u"E3", u"E4" 
    });
    
    // 儲存格資料陣列。
    System::ArrayPtr<int32_t> cellValues = System::MakeArray<int32_t>(
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25 
    });

    // 新增工作表以填入儲存格資料。
    int32_t dataSheetIndex = workbook->GetIWorksheets()->Add();
    intrusive_ptr<Aspose::Cells::IWorksheet> dataSheet = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIndex);
    intrusive_ptr<Aspose::Cells::Systems::String> sheetName = new Aspose::Cells::Systems::String("DataSheet");
    dataSheet->SetName(sheetName);

    // 將資料填入資料工作表。
    for (int32_t i = 0; i < cellNames->get_Length(); i++)
    {
        System::String cellName = cellNames[i];
        int32_t cellValue = cellValues[i];
        dataSheet->GetICells()->GetObjectByIndex(new String(cellName.ToWCS().c_str()))->PutValue(cellValue);
    }

    // 新增圖表工作表。
    int32_t chartSheetIndex = workbook->GetIWorksheets()->Add(Aspose::Cells::SheetType::SheetType_Chart);
    intrusive_ptr<Aspose::Cells::IWorksheet> chartSheet = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex);
    chartSheet->SetName(new String("ChartSheet"));

    // 在圖表工作表上加入圖表，資料系列來源於資料工作表。
    int32_t chartIndex = chartSheet->GetICharts()->Add(Aspose::Cells::Charts::ChartType::ChartType_Column, 0, chartRows, 0, chartCols);
    intrusive_ptr<Aspose::Cells::Charts::IChart> chart = chartSheet->GetICharts()->GetObjectByIndex(chartIndex);
    chart->GetNISeries()->Add(sheetName + "!A1:E1", false);
    chart->GetNISeries()->Add(sheetName + "!A2:E2", false);
    chart->GetNISeries()->Add(sheetName + "!A3:E3", false);
    chart->GetNISeries()->Add(sheetName + "!A4:E4", false);

    // 將圖表工作表設為作用中的工作表。
    workbook->GetIWorksheets()->SetActiveSheetIndex(chartSheetIndex);

    return chartSheetIndex;
}
```

上述方法建立的簡報將包含作為 OLE 物件的 Excel 圖表，使用者可透過雙擊 OLE 物件框架來啟用它。

## **結論**

透過結合使用 Aspose.Cells for C++ 與 Aspose.Slides for C++，我們能夠建立任何 Aspose.Cells 支援的 Excel 圖表，並將圖表以 OLE 物件的形式嵌入 PowerPoint 投影片中。Excel 圖表的 OLE 大小亦可自行定義。最終使用者即可像編輯其他 OLE 物件一樣編輯 Excel 圖表。

## **相關章節**

- [PPTX 中圖表調整大小的可行解決方案](/slides/zh-hant/cpp/working-solution-for-chart-resizing-in-pptx/)
- [加入 OleObjectFrame 時的物件預覽問題](/slides/zh-hant/cpp/object-preview-issue-when-adding-oleobjectframe/)