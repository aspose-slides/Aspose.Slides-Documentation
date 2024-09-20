---  
title: Рабочее решение проблемы изменения размера листа  
type: docs  
weight: 130  
url: /cpp/working-solution-for-worksheet-resizing/  
---  

{{% alert color="primary" %}}  

Было отмечено, что листы Excel, встроенные как OLE в презентацию PowerPoint с помощью компонентов Aspose, изменяются до неопознанного масштаба после первого активации. Это поведение создает значительную визуальную разницу в презентации между состояниями до и после активации диаграммы. Мы подробно изучили эту проблему и нашли решение, которое рассматривается в этой статье.  

{{% /alert %}}  
## **Фон**  
В статье "Добавление OLE-рамок" мы объяснили, как добавить OLE-рамку в презентацию PowerPoint с использованием Aspose.Slides для C++. Чтобы учесть проблему изменения объекта, мы назначили изображение листа в выбранной области OLE-объектной рамки диаграммы. В выходной презентации при двойном клике на OLE-объектную рамку, показывающую изображение листа, активируется диаграмма Excel. Конечные пользователи могут вносить любые необходимые изменения в фактическую книгу Excel, а затем вернуться к соответствующему слайду, щелкнув вне активной книги Excel. Размер OLE-объектной рамки изменится, когда пользователь вернется к слайду. Фактор изменения размера будет различаться для различных размеров OLE-объектной рамки и встроенной книги Excel.  
## **Причина изменения размера**  
Поскольку книга Excel имеет свой собственный размер окна, она пытается сохранить свой исходный размер при первой активации. С другой стороны, OLE-объектная рамка будет иметь свой собственный размер. Согласно данным Microsoft, при активации книги Excel Excel и PowerPoint согласуют размер и обеспечивают правильные пропорции в рамках операции встраивания. На основе различий в размере окон Excel и размере / позиции OLE-объектной рамки происходит изменение размера.  
## **Рабочее решение**  
Существует два возможных решения для избежания эффекта изменения размера.

- Измените размер OLE-рамки в PPT, чтобы он соответствовал размеру по высоте/ширине желаемого числа строк/столбцов в OLE-рамке.  
- Сохраняя постоянный размер OLE-рамки, измените размер участвующих строк/столбцов, чтобы они вписывались в выбранный размер OLE-рамки.  
## **Изменение размера OLE-рамки в соответствии с выбранными строками/столбцами листа**  
В этом подходе мы научимся устанавливать размер OLE-рамки встроенной книги Excel, равный совокупному размеру числа участвующих строк и столбцов в листе Excel.  
## **Пример**  
Предположим, мы определили шаблонный Excel-лист и хотим добавить его в презентацию как OLE-рамку. В этом сценарии размер OLE-объектной рамки будет сначала рассчитан на основе совокупной высоты строк и ширины столбцов участвующих строк и столбцов книги. Затем мы установим размер OLE-рамки на это рассчитанное значение. Чтобы избежать сообщения **Встроенный объект** для OLE-рамки в PowerPoint, мы также получим изображение желаемых частей строк и столбцов в книге и установим его как изображение OLE-рамки.  

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

    // Установка новой высоты строки и ширины столбца  
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

    // Установка активного индекса листа книги  
    workbookDesigner->GetIWorkbook()->GetIWorksheets()->SetActiveSheetIndex(dataSheetIdx);  

    // Получение книги и выбранного листа  
    intrusive_ptr<Aspose::Cells::IWorkbook> workbook = workbookDesigner->GetIWorkbook();  
    intrusive_ptr<Aspose::Cells::IWorksheet> work = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIdx);  

    // Установка размера OLE в соответствии с выбранными строками и столбцами  
    System::Drawing::Size SlideOleSize = SetOleAccordingToSelectedRowsColumns(workbook, startRow, endRow, startCol, endCol, dataSheetIdx);  
    OleWidth = SlideOleSize.get_Width();  
    OleHeight = SlideOleSize.get_Height();  

    // Установка размера OLE в книге  
    workbook->GetIWorksheets()->SetOleSize(startRow, endRow, startCol, endCol);  

    workbook->GetIWorksheets()->GetObjectByIndex(0)->SetGridlinesVisible(false);  

    // Установка параметров изображения для получения изображения листа  
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

    // Добавление изображения в коллекцию изображений слайда  
    auto ppImage = presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(newTempFileName));  

    // Сохранение книги в поток и копирование в массив байтов  
    System::SharedPtr<System::IO::Stream> mstream = ToSlidesMemoryStream(workbook->SaveToStream());  
    System::ArrayPtr<uint8_t> chartOleData = System::MakeArray<uint8_t>(mstream->get_Length(), 0);  
    mstream->set_Position(0);  
    mstream->Read(chartOleData, 0, chartOleData->get_Length());  

    // Добавление OLE-объектной рамки  
    System::SharedPtr<OleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(chartOleData, u"xls");  
    System::SharedPtr<IOleObjectFrame> oleObjectFrame = slide->get_Shapes()->AddOleObjectFrame(x, y, OleWidth, OleHeight, dataInfo);  

    // Установка изображения OLE-рамки и альтернативного текста    
    oleObjectFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(ppImage);  
    oleObjectFrame->set_AlternativeText(System::String(u"изображение") + ppImage);  
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

## **Изменение высоты строк и ширины столбцов листа в соответствии с размером OLE-рамки**  
В этом подходе мы научимся изменять размеры высоты участвуемых строк и ширины участвующих столбцов в соответствии с заданным размером OLE-рамки  
## **Пример**  
Предположим, мы определили шаблонный Excel-лист и хотим добавить его в презентацию как OLE-рамку. В этом сценарии мы установим размер OLE-рамки и изменим размер строк и столбцов, участвующих в области OLE-рамки. Затем мы сохраним книгу в потоке, чтобы сохранить изменения и преобразовать её в массив байтов для добавления в OLE-рамку. Чтобы избежать сообщения **Встроенный объект** для OLE-рамки в PowerPoint, мы также получим изображение желаемых частей строк и столбцов в книге и установим его как изображение OLE-рамки.  

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

    // Установка новой высоты строк и ширины столбцов  
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

    // Установка активного индекса листа книги  
    workbookDesigner->GetIWorkbook()->GetIWorksheets()->SetActiveSheetIndex(dataSheetIdx);  

    // Получение книги и выбранного листа  
    intrusive_ptr<Aspose::Cells::IWorkbook> workbook = workbookDesigner->GetIWorkbook();  
    intrusive_ptr<Aspose::Cells::IWorksheet> work = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIdx);  

    // Масштабирование высоты строк и ширины столбцов в соответствии с пользовательским размером OLE  
    double height = OleHeight / 576.0f;  
    double width = OleWidth / 576.0f;  

    // Установка размера OLE в соответствии с выбранными строками и столбцами  
    SetOleAccordingToCustomHeightWidth(workbook, startRow, endRow, startCol, endCol, width, height, dataSheetIdx);  

    // Установка размера OLE в книге  
    workbook->GetIWorksheets()->SetOleSize(startRow, endRow, startCol, endCol);  
    workbook->GetIWorksheets()->GetObjectByIndex(0)->SetGridlinesVisible(false);  

    // Установка параметров изображения для получения изображения листа  
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

    // Добавление изображения в коллекцию изображений слайда  
    auto ppImage = presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(newTempFileName));  

    // Сохранение книги в поток и копирование в массив байтов  
    System::SharedPtr<System::IO::Stream> mstream = ToSlidesMemoryStream(workbook->SaveToStream());  
    System::ArrayPtr<uint8_t> chartOleData = System::MakeArray<uint8_t>(mstream->get_Length(), 0);  
    mstream->set_Position(0);  
    mstream->Read(chartOleData, 0, chartOleData->get_Length());  

    // Добавление OLE-объектной рамки  
    System::SharedPtr<OleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(chartOleData, u"xls");  
    System::SharedPtr<IOleObjectFrame> oleObjectFrame = slide->get_Shapes()->AddOleObjectFrame(x, y, OleWidth, OleHeight, dataInfo);  

    // Установка изображения OLE-рамки и альтернативного текста    
    oleObjectFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(ppImage);  
    oleObjectFrame->set_AlternativeText(System::String(u"изображение") + ppImage);  
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

## **Заключение**  

{{% alert color="primary" %}}   {{% /alert %}}  

Существует два подхода для устранения проблемы изменения размера листа. Выбор подходящего подхода зависит от требований и конкретного случая использования. Оба подхода работают одинаково, независимо от того, создаются ли презентации из шаблона или с нуля. Кроме того, в решении нет ограничения на размер OLE-объектной рамки. 

h4. {_}Связанные разделы  
{_}  

[Создание и встраивание диаграммы Excel в качестве OLE-объекта в презентацию](/slides/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)  