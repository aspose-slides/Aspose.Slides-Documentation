---
title: إنشاء مخطط إكسل وتضمينه في العرض كمكون OLE
type: docs
weight: 40
url: /ar/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
---

{{% alert color="primary" %}} 

في شرائح PowerPoint، يُعتبر استخدام المخططات القابلة للتعديل لعرض البيانات بشكل رسومي نشاطًا شائعًا. توفر Aspose دعمًا لإنشاء مخططات إكسل باستخدام Aspose.Cells لـ C++، ويمكن بعد ذلك تضمين هذه المخططات كمكون OLE في شريحة PowerPoint من خلال Aspose.Slides لـ C++. تغطي هذه المقالة الخطوات المطلوبة جنبًا إلى جنب مع التنفيذ في C++ لإنشاء وتضمين مخطط MS Excel كمكون OLE في عرض PowerPoint باستخدام Aspose.Cells لـ C++ وAspose.Slides لـ C++.

{{% /alert %}} 
## **الخطوات المطلوبة**
تتطلب عملية إنشاء وتضمين مخطط إكسل كمكون OLE في شريحة PowerPoint التسلسل التالي من الخطوات:

1. إنشاء مخطط إكسل باستخدام Aspose.Cells لـ C++.
2. تعيين حجم OLE لمخطط إكسل باستخدام Aspose.Cells لـ C++. 
3. الحصول على صورة لمخطط إكسل باستخدام Aspose.Cells لـ C++. 
4. تضمين مخطط إكسل كمكون OLE داخل عرض PPTX باستخدام Aspose.Slides لـ C++. 
5. استبدال الصورة التي تم تغييرها بالصورة التي تم الحصول عليها في الخطوة 3 لتجنب مشكلة تغيير الكائن
6. كتابة العرض الناتج إلى القرص بصيغة PPTX

## **تنفيذ الخطوات المطلوبة**
يتم تنفيذ الخطوات أعلاه في C++ كما يلي:

``` cpp
//Step - 1: Create an excel chart using Aspose.Cells
//--------------------------------------------------
//Create a workbook
intrusive_ptr<Aspose::Cells::IWorkbook> wb = Aspose::Cells::Factory::CreateIWorkbook();
//Add an excel chart
int32_t chartRows = 55;
int32_t chartCols = 25;
int32_t chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Step - 2: Set the OLE size of the chart. using Aspose.Cells
//-----------------------------------------------------------
wb->GetIWorksheets()->SetOleSize(0, chartRows, 0, chartCols);
//Step - 3: Get the image of the chart with Aspose.Cells
//-----------------------------------------------------------
//System::SharedPtr<System::Drawing::Bitmap>
auto imgChart = wb->GetIWorksheets()->GetObjectByIndex(chartSheetIndex)->GetICharts()->GetObjectByIndex(0)->ToImage();
//Save the workbook to stream
System::SharedPtr<System::IO::MemoryStream> wbStream = ToSlidesMemoryStream(wb->SaveToStream());
//Step - 4  AND 5
//-----------------------------------------------------------
//Step - 4: Embed the chart as an OLE object inside .ppt presentation using Aspose.Slides
//-----------------------------------------------------------
//Step - 5: Replace the object changed image with the image obtained in step 3 to cater Object Changed Issue
//-----------------------------------------------------------
//Create a presentation
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
System::SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Add the workbook on slide
AddExcelChartInPresentation(pres, slide, wbStream, imgChart);

//Step - 6: Write the output presentation on disk
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
    // Array of cell names
    System::ArrayPtr<System::String> cellsName = System::MakeArray<System::String>(
        { u"A1", u"A2", u"A3", u"A4", 
            u"B1", u"B2", u"B3", u"B4",
            u"C1", u"C2", u"C3", u"C4",
            u"D1", u"D2", u"D3", u"D4",
            u"E1", u"E2", u"E3", u"E4" });
    
    // Array of cell data
    System::ArrayPtr<int32_t> cellsValue = System::MakeArray<int32_t>(
        { 67, 86, 68, 91,
            44, 64, 89, 48,
            46, 97, 78, 60,
            43, 29, 69, 26,
            24, 40, 38, 25 });

    // Add a new worksheet to populate cells with data
    int32_t dataSheetIdx = wb->GetIWorksheets()->Add();
    intrusive_ptr<Aspose::Cells::IWorksheet> dataSheet = wb->GetIWorksheets()->GetObjectByIndex(dataSheetIdx);
    intrusive_ptr<Aspose::Cells::Systems::String> sheetName = new Aspose::Cells::Systems::String("DataSheet");
    dataSheet->SetName(sheetName);

    // Populate DataSheet with data
    for (int32_t i = 0; i < cellsName->get_Length(); i++)
    {
        System::String cellName = cellsName[i];
        int32_t cellValue = cellsValue[i];
        dataSheet->GetICells()->GetObjectByIndex(new String(cellName.ToWCS().c_str()))->PutValue(cellValue);
    }

    // Add a chart sheet
    int32_t chartSheetIdx = wb->GetIWorksheets()->Add(Aspose::Cells::SheetType::SheetType_Chart);
    intrusive_ptr<Aspose::Cells::IWorksheet> chartSheet = wb->GetIWorksheets()->GetObjectByIndex(chartSheetIdx);
    chartSheet->SetName(new String("ChartSheet"));

    // Add a chart in ChartSheet with data series from DataSheet
    int32_t chartIdx = chartSheet->GetICharts()->Add(Aspose::Cells::Charts::ChartType::ChartType_Column, 0, chartRows, 0, chartCols);
    intrusive_ptr<Aspose::Cells::Charts::IChart> chart = chartSheet->GetICharts()->GetObjectByIndex(chartIdx);
    chart->GetNISeries()->Add(sheetName + "!A1:E1", false);
    chart->GetNISeries()->Add(sheetName + "!A2:E2", false);
    chart->GetNISeries()->Add(sheetName + "!A3:E3", false);
    chart->GetNISeries()->Add(sheetName + "!A4:E4", false);

    // Set ChartSheet an active sheet
    wb->GetIWorksheets()->SetActiveSheetIndex(chartSheetIdx);

    return chartSheetIdx;
}
```

{{% alert color="primary" %}} 

سيحمل العرض الذي تم إنشاؤه من خلال الطريقة أعلاه مخطط إكسل كمكون OLE يمكن تفعيله من خلال النقر المزدوج على إطار مكون OLE.

{{% /alert %}} 
## **الخاتمة**
{{% alert color="primary" %}} 

باستخدام Aspose.Cells لـ C++ بالإضافة إلى Aspose.Slides لـ C++، يمكننا إنشاء أي من مخططات إكسل المدعومة من قبل Aspose.Cells لـ C++ وتضمين المخطط الذي تم إنشاؤه كمكون OLE في شريحة PowerPoint. يمكن أيضًا تحديد حجم OLE لمخطط إكسل. يمكن لمستخدمي النهاية تعديل مخطط إكسل كما هو الحال مع أي مكون OLE آخر.

{{% /alert %}} 
## **الأقسام ذات الصلة**
[حل عملي لتعديل حجم المخطط](https://docs.aspose.com/slides/cpp/working-solution-for-chart-resizing-in-pptx/)