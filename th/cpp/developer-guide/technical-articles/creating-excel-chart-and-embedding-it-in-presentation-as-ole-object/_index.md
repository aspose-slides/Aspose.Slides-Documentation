---
title: "สร้างแผนภูมิ Excel และฝังลงในการนำเสนอเป็นวัตถุ OLE"
type: docs
weight: 40
url: /th/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- แผนภูมิ Excel
- ฝังแผนภูมิ
- วัตถุ OLE
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "สร้างแผนภูมิ Excel และฝังเป็นวัตถุ OLE ในการนำเสนอ PowerPoint และ OpenDocument ด้วย C++ คู่มือแบบขั้นตอนพร้อมตัวอย่างโค้ด"
---
## **พื้นหลัง**

ใน PowerPoint การใช้แผนภูมิที่แก้ไขได้เพื่อแสดงข้อมูลในรูปกราฟิกเป็นการปฏิบัติที่พบทั่วไป Aspose รองรับการสร้างแผนภูมิ Excel ด้วย Aspose.Cells for C++ และแผนภูมิเหล่านี้สามารถฝังเป็นวัตถุ OLE ในสไลด์ PowerPoint ผ่าน Aspose.Slides for C++ บทความนี้อธิบายขั้นตอนที่จำเป็นและให้ตัวอย่างโค้ด C++ สำหรับการสร้างแผนภูมิ Excel และฝังเป็นวัตถุ OLE ในการนำเสนอ PowerPoint โดยใช้ Aspose.Cells และ Aspose.Slides

## **ขั้นตอนที่จำเป็น**

ต้องทำตามขั้นตอนต่อไปนี้เพื่อสร้างและฝังแผนภูมิ Excel เป็นวัตถุ OLE ในสไลด์ PowerPoint:

1. สร้างแผนภูมิ Excel ด้วย Aspose.Cells
1. ตั้งค่าขนาด OLE ของแผนภูมิ Excel ด้วย Aspose.Cells
1. รับรูปภาพของแผนภูมิ Excel ด้วย Aspose.Cells
1. ฝังแผนภูมิ Excel เป็นวัตถุ OLE ในการนำเสนอ PPTX ด้วย Aspose.Slides
1. แทนที่รูปภาพ "EMBEDDED OLE OBJECT" ด้วยรูปภาพที่ได้จากขั้นตอนที่ 3 เพื่อแก้ไขปัญหา[object preview issue](/slides/th/cpp/object-preview-issue-when-adding-oleobjectframe/)
1. บันทึกการนำเสนอลงดิสก์ในรูปแบบ PPTX

## **การดำเนินการตามขั้นตอนที่จำเป็น**

การทำงานด้วย C++ สำหรับขั้นตอนข้างต้นมีดังนี้:

```cpp
// ขั้นตอน - 1: สร้างแผนภูมิ Excel ด้วย Aspose.Cells.
// ---------------------------------------------------
// สร้างเวิร์กบุ๊ก.
intrusive_ptr<Aspose::Cells::IWorkbook> workbook = Aspose::Cells::Factory::CreateIWorkbook();
// เพิ่มแผนภูมิ Excel.
int32_t chartRows = 55;
int32_t chartCols = 25;
int32_t chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// ขั้นตอน - 2: ตั้งค่าขนาด OLE ของแผนภูมิด้วย Aspose.Cells.
// -----------------------------------------------------------
workbook->GetIWorksheets()->SetOleSize(0, chartRows, 0, chartCols);

// ขั้นตอน - 3: ดึงรูปภาพของแผนภูมิด้วย Aspose.Cells.
// -------------------------------------------------------
System::SharedPtr<System::Drawing::Bitmap> chartImage = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex)->GetICharts()->GetObjectByIndex(0)->ToImage();
// บันทึกเวิร์กบุ๊กไปยังสตรีม.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

// ขั้นตอน - 4 และ 5
// ==============
// ขั้นตอน - 4: ฝังแผนภูมิเป็นวัตถุ OLE ภายในงานนำเสนอ .ppt ด้วย Aspose.Slides.
// ------------------------------------------------------------------------------------------
// ขั้นตอน - 5: แทนที่รูปภาพ "EMBEDDED OLE OBJECT" ด้วยรูปภาพที่ได้จากขั้นตอนที่ 3 เพื่อแก้ไขปัญหาแสดงตัวอย่างวัตถุ.
// --------------------------------------------------------------------------------------------------------------------
// สร้างการนำเสนอ.
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);
// Add the workbook to the slide.
AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

// ขั้นตอน - 6: บันทึกการนำเสนอผลลัพธ์ลงดิสก์.
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
    // อาร์เรย์ของชื่อเซลล์.
    System::ArrayPtr<System::String> cellNames = System::MakeArray<System::String>(
    { 
        u"A1", u"A2", u"A3", u"A4", 
        u"B1", u"B2", u"B3", u"B4",
        u"C1", u"C2", u"C3", u"C4",
        u"D1", u"D2", u"D3", u"D4",
        u"E1", u"E2", u"E3", u"E4" 
    });
    
    // อาร์เรย์ของข้อมูลเซลล์.
    System::ArrayPtr<int32_t> cellValues = System::MakeArray<int32_t>(
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25 
    });

    // เพิ่มเวิร์กชีตใหม่เพื่อเติมข้อมูลลงในเซลล์.
    int32_t dataSheetIndex = workbook->GetIWorksheets()->Add();
    intrusive_ptr<Aspose::Cells::IWorksheet> dataSheet = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIndex);
    intrusive_ptr<Aspose::Cells::Systems::String> sheetName = new Aspose::Cells::Systems::String("DataSheet");
    dataSheet->SetName(sheetName);

    // เติมข้อมูลลงในแผ่นข้อมูล.
    for (int32_t i = 0; i < cellNames->get_Length(); i++)
    {
        System::String cellName = cellNames[i];
        int32_t cellValue = cellValues[i];
        dataSheet->GetICells()->GetObjectByIndex(new String(cellName.ToWCS().c_str()))->PutValue(cellValue);
    }

    // เพิ่มแผ่นชาร์ต.
    int32_t chartSheetIndex = workbook->GetIWorksheets()->Add(Aspose::Cells::SheetType::SheetType_Chart);
    intrusive_ptr<Aspose::Cells::IWorksheet> chartSheet = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex);
    chartSheet->SetName(new String("ChartSheet"));

    // เพิ่มแผนภูมิลงในแผ่นชาร์ตโดยใช้ชุดข้อมูลจากแผ่นข้อมูล.
    int32_t chartIndex = chartSheet->GetICharts()->Add(Aspose::Cells::Charts::ChartType::ChartType_Column, 0, chartRows, 0, chartCols);
    intrusive_ptr<Aspose::Cells::Charts::IChart> chart = chartSheet->GetICharts()->GetObjectByIndex(chartIndex);
    chart->GetNISeries()->Add(sheetName + "!A1:E1", false);
    chart->GetNISeries()->Add(sheetName + "!A2:E2", false);
    chart->GetNISeries()->Add(sheetName + "!A3:E3", false);
    chart->GetNISeries()->Add(sheetName + "!A4:E4", false);

    // ตั้งค่าแผ่นชาร์ตให้เป็นแผ่นทำงานที่ใช้งานอยู่.
    workbook->GetIWorksheets()->SetActiveSheetIndex(chartSheetIndex);

    return chartSheetIndex;
}
```

การนำเสนอที่สร้างด้วยวิธีข้างต้นจะมีแผนภูมิ Excel อยู่เป็นวัตถุ OLE ที่สามารถเปิดใช้งานได้โดยการคลิกสองครั้งบนกรอบวัตถุ OLE

## **สรุป**

โดยใช้ Aspose.Cells for C++ ร่วมกับ Aspose.Slides for C++ เราสามารถสร้างแผนภูมิ Excel ใด ๆ ที่รองรับโดย Aspose.Cells และฝังแผนภูมินั้นเป็นวัตถุ OLE ในสไลด์ PowerPoint ได้ ขนาด OLE ของแผนภูมิ Excel ยังสามารถกำหนดได้ ผู้ใช้ขั้นสุดท้ายจึงสามารถแก้ไขแผนภูมิ Excel ได้เช่นเดียวกับวัตถุ OLE อื่น ๆ

## **ส่วนที่เกี่ยวข้อง**

- [Working Solution for Chart Resizing in PPTX](/slides/th/cpp/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/th/cpp/object-preview-issue-when-adding-oleobjectframe/)