---
title: 创建Excel图表并将其嵌入演示文稿作为OLE对象
type: docs
weight: 40
url: /cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
---

{{% alert color="primary" %}} 

在PowerPoint幻灯片中，使用可编辑的图表图形展示数据是一项常见活动。Aspose通过使用Aspose.Cells for C++提供创建Excel图表的支持，进一步通过Aspose.Slides for C++将这些图表嵌入到PowerPoint幻灯片中作为OLE对象。本文涵盖了创建和嵌入MS Excel图表作为OLE对象到PowerPoint演示文稿中所需的步骤，以及在C++中的实现方法，使用Aspose.Cells for C++和Aspose.Slides for C++。

{{% /alert %}} 
## **所需步骤**
创建并将Excel图表嵌入PowerPoint幻灯片作为OLE对象所需的步骤如下：

1. 使用Aspose.Cells for C++创建Excel图表。
2. 使用Aspose.Cells for C++设置Excel图表的OLE大小。 
3. 使用Aspose.Cells for C++获取Excel图表的图像。 
4. 使用Aspose.Slides for C++将Excel图表嵌入PPTX演示文稿作为OLE对象。 
5. 用第3步中获得的图像替换对象更改的图像，以解决对象更改问题。
6. 将输出演示文稿以PPTX格式写入磁盘。

## **所需步骤的实现**
在C++中实现上述步骤如下：

``` cpp
//步骤 - 1：使用Aspose.Cells创建Excel图表
//--------------------------------------------------
//创建工作簿
intrusive_ptr<Aspose::Cells::IWorkbook> wb = Aspose::Cells::Factory::CreateIWorkbook();
//添加Excel图表
int32_t chartRows = 55;
int32_t chartCols = 25;
int32_t chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//步骤 - 2：使用Aspose.Cells设置图表的OLE大小
//-----------------------------------------------------------
wb->GetIWorksheets()->SetOleSize(0, chartRows, 0, chartCols);
//步骤 - 3：使用Aspose.Cells获取图表的图像
//-----------------------------------------------------------
//System::SharedPtr<System::Drawing::Bitmap>
auto imgChart = wb->GetIWorksheets()->GetObjectByIndex(chartSheetIndex)->GetICharts()->GetObjectByIndex(0)->ToImage();
//将工作簿保存到流中
System::SharedPtr<System::IO::MemoryStream> wbStream = ToSlidesMemoryStream(wb->SaveToStream());
//步骤 - 4 和 5
//-----------------------------------------------------------
//步骤 - 4：使用Aspose.Slides将图表嵌入.ppt演示文稿作为OLE对象
//-----------------------------------------------------------
//步骤 - 5：用第3步中获得的图像替换对象更改的图像，以解决对象更改问题
//-----------------------------------------------------------
//创建演示文稿
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
System::SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// 在幻灯片上添加工作簿
AddExcelChartInPresentation(pres, slide, wbStream, imgChart);

//步骤 - 6：将输出演示文稿写入磁盘
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
    // 单元格名称数组
    System::ArrayPtr<System::String> cellsName = System::MakeArray<System::String>(
        { u"A1", u"A2", u"A3", u"A4", 
            u"B1", u"B2", u"B3", u"B4",
            u"C1", u"C2", u"C3", u"C4",
            u"D1", u"D2", u"D3", u"D4",
            u"E1", u"E2", u"E3", u"E4" });
    
    // 单元格数据数组
    System::ArrayPtr<int32_t> cellsValue = System::MakeArray<int32_t>(
        { 67, 86, 68, 91,
            44, 64, 89, 48,
            46, 97, 78, 60,
            43, 29, 69, 26,
            24, 40, 38, 25 });

    // 添加一个新工作表以填充数据
    int32_t dataSheetIdx = wb->GetIWorksheets()->Add();
    intrusive_ptr<Aspose::Cells::IWorksheet> dataSheet = wb->GetIWorksheets()->GetObjectByIndex(dataSheetIdx);
    intrusive_ptr<Aspose::Cells::Systems::String> sheetName = new Aspose::Cells::Systems::String("数据表");
    dataSheet->SetName(sheetName);

    // 用数据填充数据表
    for (int32_t i = 0; i < cellsName->get_Length(); i++)
    {
        System::String cellName = cellsName[i];
        int32_t cellValue = cellsValue[i];
        dataSheet->GetICells()->GetObjectByIndex(new String(cellName.ToWCS().c_str()))->PutValue(cellValue);
    }

    // 添加图表工作表
    int32_t chartSheetIdx = wb->GetIWorksheets()->Add(Aspose::Cells::SheetType::SheetType_Chart);
    intrusive_ptr<Aspose::Cells::IWorksheet> chartSheet = wb->GetIWorksheets()->GetObjectByIndex(chartSheetIdx);
    chartSheet->SetName(new String("图表工作表"));

    // 在图表工作表中添加图表，使用数据表中的数据系列
    int32_t chartIdx = chartSheet->GetICharts()->Add(Aspose::Cells::Charts::ChartType::ChartType_Column, 0, chartRows, 0, chartCols);
    intrusive_ptr<Aspose::Cells::Charts::IChart> chart = chartSheet->GetICharts()->GetObjectByIndex(chartIdx);
    chart->GetNISeries()->Add(sheetName + "!A1:E1", false);
    chart->GetNISeries()->Add(sheetName + "!A2:E2", false);
    chart->GetNISeries()->Add(sheetName + "!A3:E3", false);
    chart->GetNISeries()->Add(sheetName + "!A4:E4", false);

    // 设置图表工作表为活动工作表
    wb->GetIWorksheets()->SetActiveSheetIndex(chartSheetIdx);

    return chartSheetIdx;
}
```

{{% alert color="primary" %}} 

通过上述方法创建的演示文稿将包含作为OLE对象的Excel图表，可以通过双击OLE对象框来激活它。

{{% /alert %}} 
## **结论**
{{% alert color="primary" %}} 

通过使用Aspose.Cells for C++以及Aspose.Slides for C++，我们可以创建所支持的任何Excel图表，并将创建的图表嵌入到PowerPoint幻灯片中作为OLE对象。Excel图表的OLE大小也可以定义。最终用户可以进一步像其他OLE对象一样编辑Excel图表。

{{% /alert %}} 
## **相关部分**
[图表调整大小的有效解决方案](https://docs.aspose.com/slides/cpp/working-solution-for-chart-resizing-in-pptx/)