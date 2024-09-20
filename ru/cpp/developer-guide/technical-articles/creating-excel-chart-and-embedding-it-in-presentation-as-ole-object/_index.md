---
title: Создание диаграммы Excel и встраивание её в презентацию в качестве OLE-объекта
type: docs
weight: 40
url: /cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
---

{{% alert color="primary" %}} 

В слайдах PowerPoint использование редактируемых диаграмм для графического отображения данных является распространенной практикой. Aspose предоставляет поддержку создания диаграмм Excel с использованием Aspose.Cells для C++, и эти диаграммы могут быть встроены в слайд PowerPoint в качестве OLE-объекта с помощью Aspose.Slides для C++. Эта статья охватывает необходимые шаги вместе с реализацией на C++ для создания и встраивания диаграммы MS Excel в качестве OLE-объекта в презентацию PowerPoint с использованием Aspose.Cells для C++ и Aspose.Slides для C++.

{{% /alert %}} 
## **Необходимые шаги**
Следующая последовательность шагов необходима для создания и встраивания диаграммы Excel в качестве OLE-объекта в слайд PowerPoint:

1. Создать диаграмму Excel с использованием Aspose.Cells для C++.
2. Установить размер OLE диаграммы Excel с использованием Aspose.Cells для C++. 
3. Получить изображение диаграммы Excel с помощью Aspose.Cells для C++. 
4. Встроить диаграмму Excel в качестве OLE-объекта в презентацию PPTX с помощью Aspose.Slides для C++. 
5. Заменить изменённое изображение объекта изображением, полученным на шаге 3, чтобы устранить проблему изменения объекта.
6. Записать выходную презентацию на диск в формате PPTX.

## **Реализация необходимых шагов**
Реализация вышеуказанных шагов на C++ выглядит следующим образом:

``` cpp
//Шаг - 1: Создать диаграмму Excel с использованием Aspose.Cells
//--------------------------------------------------
//Создать рабочую книгу
intrusive_ptr<Aspose::Cells::IWorkbook> wb = Aspose::Cells::Factory::CreateIWorkbook();
//Добавить диаграмму Excel
int32_t chartRows = 55;
int32_t chartCols = 25;
int32_t chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Шаг - 2: Установить размер OLE диаграммы с использованием Aspose.Cells
//-----------------------------------------------------------
wb->GetIWorksheets()->SetOleSize(0, chartRows, 0, chartCols);
//Шаг - 3: Получить изображение диаграммы с помощью Aspose.Cells
//-----------------------------------------------------------
//System::SharedPtr<System::Drawing::Bitmap>
auto imgChart = wb->GetIWorksheets()->GetObjectByIndex(chartSheetIndex)->GetICharts()->GetObjectByIndex(0)->ToImage();
//Сохранить рабочую книгу в поток
System::SharedPtr<System::IO::MemoryStream> wbStream = ToSlidesMemoryStream(wb->SaveToStream());
//Шаг - 4 И 5
//-----------------------------------------------------------
//Шаг - 4: Встроить диаграмму в качестве OLE-объекта в презентацию .ppt с помощью Aspose.Slides
//-----------------------------------------------------------
//Шаг - 5: Заменить изменённое изображение объекта изображением, полученным на шаге 3, чтобы устранить проблему изменения объекта
//-----------------------------------------------------------
//Создать презентацию
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
System::SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Добавить рабочую книгу на слайд
AddExcelChartInPresentation(pres, slide, wbStream, imgChart);

//Шаг - 6: Записать выходную презентацию на диск
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
    // Массив имен ячеек
    System::ArrayPtr<System::String> cellsName = System::MakeArray<System::String>(
        { u"A1", u"A2", u"A3", u"A4", 
            u"B1", u"B2", u"B3", u"B4",
            u"C1", u"C2", u"C3", u"C4",
            u"D1", u"D2", u"D3", u"D4",
            u"E1", u"E2", u"E3", u"E4" });
    
    // Массив значений ячеек
    System::ArrayPtr<int32_t> cellsValue = System::MakeArray<int32_t>(
        { 67, 86, 68, 91,
            44, 64, 89, 48,
            46, 97, 78, 60,
            43, 29, 69, 26,
            24, 40, 38, 25 });

    // Добавить новый лист для заполнения ячеек данными
    int32_t dataSheetIdx = wb->GetIWorksheets()->Add();
    intrusive_ptr<Aspose::Cells::IWorksheet> dataSheet = wb->GetIWorksheets()->GetObjectByIndex(dataSheetIdx);
    intrusive_ptr<Aspose::Cells::Systems::String> sheetName = new Aspose::Cells::Systems::String("DataSheet");
    dataSheet->SetName(sheetName);

    // Заполнить DataSheet данными
    for (int32_t i = 0; i < cellsName->get_Length(); i++)
    {
        System::String cellName = cellsName[i];
        int32_t cellValue = cellsValue[i];
        dataSheet->GetICells()->GetObjectByIndex(new String(cellName.ToWCS().c_str()))->PutValue(cellValue);
    }

    // Добавить лист диаграммы
    int32_t chartSheetIdx = wb->GetIWorksheets()->Add(Aspose::Cells::SheetType::SheetType_Chart);
    intrusive_ptr<Aspose::Cells::IWorksheet> chartSheet = wb->GetIWorksheets()->GetObjectByIndex(chartSheetIdx);
    chartSheet->SetName(new String("ChartSheet"));

    // Добавить диаграмму в ChartSheet с сериями данных из DataSheet
    int32_t chartIdx = chartSheet->GetICharts()->Add(Aspose::Cells::Charts::ChartType::ChartType_Column, 0, chartRows, 0, chartCols);
    intrusive_ptr<Aspose::Cells::Charts::IChart> chart = chartSheet->GetICharts()->GetObjectByIndex(chartIdx);
    chart->GetNISeries()->Add(sheetName + "!A1:E1", false);
    chart->GetNISeries()->Add(sheetName + "!A2:E2", false);
    chart->GetNISeries()->Add(sheetName + "!A3:E3", false);
    chart->GetNISeries()->Add(sheetName + "!A4:E4", false);

    // Установить ChartSheet как активный лист
    wb->GetIWorksheets()->SetActiveSheetIndex(chartSheetIdx);

    return chartSheetIdx;
}
```

{{% alert color="primary" %}} 

Презентация, созданная указанным выше методом, будет содержать диаграмму Excel в качестве OLE-объекта, который можно активировать, дважды щелкнув на рамке OLE-объекта.

{{% /alert %}} 
## **Заключение**
{{% alert color="primary" %}} 

Используя Aspose.Cells для C++ вместе с Aspose.Slides для C++, мы можем создать любую из диаграмм Excel, поддерживаемых Aspose.Cells для C++, и встроить созданную диаграмму в качестве OLE-объекта в слайд PowerPoint. Размер OLE диаграммы Excel также может быть определён. Конечные пользователи могут дополнительно редактировать диаграмму Excel, как любой другой OLE-объект.

{{% /alert %}} 
## **Связанные разделы**
[Рабочее решение для изменения размера диаграммы](https://docs.aspose.com/slides/cpp/working-solution-for-chart-resizing-in-pptx/)