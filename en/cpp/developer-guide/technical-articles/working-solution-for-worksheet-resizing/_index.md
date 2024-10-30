---
title: Working Solution for Worksheet Resizing
type: docs
weight: 130
url: /cpp/working-solution-for-worksheet-resizing/
---

{{% alert color="primary" %}} 

It has been observed that Excel Worksheets embedded as OLE in a PowerPoint Presentation through Aspose components are resized to an unidentified scale after first time activation. This behavior creates a considerable visual difference of the presentation between pre and post chart activation states. We have investigated this issue in detail and found the solution to this issue that has been covered in this article. 

{{% /alert %}} 
## **Background**
In the article [Manage OLE](/slides/cpp/manage-ole/), we have explained how to add an OLE frame in a PowerPoint presentation using Aspose.Slides for C++. In order to accommodate the [object preview issue](/slides/cpp/object-preview-issue-when-adding-oleobjectframe/), we assigned the worksheet image of selected area to the Chart OLE Object Frame. In the output presentation, when we double click the OLE Object Frame showing the worksheet Image, the Excel Chart is activated. The end users can make any desired changes in the actual Excel Workbook and then return to the concerned Slide by clicking outside the activated Excel Workbook. The size of the OLE Object Frame will change when the user gets back to the slide. The resizing factor will be different for different sizes of OLE Object Frame and embedded Excel Workbook. 
## **Cause of Resizing**
Since the Excel Workbook has its own window size, it tries to retain its original size on first time activation. On the other hand, the OLE Object Frame will have its own size. According to Microsoft, on activation of the Excel Workbook, Excel and PowerPoint negotiate the size and ensure it is in the correct proportions as part of the embedding operation. Based on the differences in the Excel Windows size and OLE Object Frame size / position, the resizing takes place. 
## **Working Solution**
There are two possible solutions to avoid the re-sizing effect.

- Scale the Ole frame size in PPT to match the size in terms of height/width of desired number of rows/columns in Ole Frame
- Keeping the Ole frame size constant and scale the size of participating rows/columns to get fit in selected Ole frame size
## **Scale Ole frame size to Worksheet's selected rows/ columns size**
In this approach, we will learn how to set the Ole frame size of the embedded Excel Workbook equivalent to the cumulative size of number of participating rows and columns in Excel Worksheet. 
## **Example**
Suppose, we have defined a template excel sheet and and desire to add that to presentation as Ole frame. In this scenario, the size of the OLE Object Frame will be calculated first based on cumulative rows height and columns widths of participating workbook's rows and columns respectively. Then we will set the size of Ole frame to that calculated value. In order to avoid the red **Embedded Object** message for Ole frame in PowerPoint we will also get the image of desired portions of rows and columns in Workbook and set that as Ole frame image. 

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

    // Setting new Row and Column Height
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

    // Setting active sheet index of workbook
    workbookDesigner->GetIWorkbook()->GetIWorksheets()->SetActiveSheetIndex(dataSheetIdx);

    // Getting Workbook and selected worksheet  
    intrusive_ptr<Aspose::Cells::IWorkbook> workbook = workbookDesigner->GetIWorkbook();
    intrusive_ptr<Aspose::Cells::IWorksheet> work = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIdx);

    // Setting Ole Size according to selected rows and columns
    System::Drawing::Size SlideOleSize = SetOleAccordingToSelectedRowsColumns(workbook, startRow, endRow, startCol, endCol, dataSheetIdx);
    OleWidth = SlideOleSize.get_Width();
    OleHeight = SlideOleSize.get_Height();

    // Set Ole Size in Workbook
    workbook->GetIWorksheets()->SetOleSize(startRow, endRow, startCol, endCol);

    workbook->GetIWorksheets()->GetObjectByIndex(0)->SetGridlinesVisible(false);

    // Setting Image Options to take the worksheet Image
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

    // Adding Image to slide picture collection
    auto ppImage = presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(newTempFileName));

    // Saving worbook to stream and copying in byte array
    System::SharedPtr<System::IO::Stream> mstream = ToSlidesMemoryStream(workbook->SaveToStream());
    System::ArrayPtr<uint8_t> chartOleData = System::MakeArray<uint8_t>(mstream->get_Length(), 0);
    mstream->set_Position(0);
    mstream->Read(chartOleData, 0, chartOleData->get_Length());

    // Adding Ole Object frame
    System::SharedPtr<OleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(chartOleData, u"xls");
    System::SharedPtr<IOleObjectFrame> oleObjectFrame = slide->get_Shapes()->AddOleObjectFrame(x, y, OleWidth, OleHeight, dataInfo);

    // Setting ole frame Imnae and Alternative Text    
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

## **Scale worksheet's row height and column width according to Ole Frame size**
In this approach, we will learn how to scale the heights of participating rows and width of participating column in accordance with custom set ole frame size
## **Example**
Suppose, we have defined a template excel sheet and and desire to add that to presentation as Ole frame. In this scenario, we will set the size of Ole frame and scale the size of rows and columns participating in Ole Frame area. We will then save the workbook in stream to save changes and convert that to byte array for adding it in Ole frame. In order to avoid the red **Embedded Object** message for Ole frame in PowerPoint we will also get the image of desired portions of rows and columns in Workbook and set that as Ole frame image. 


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

    // Setting new Row and Column Height
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

    // Setting active sheet index of workbook
    workbookDesigner->GetIWorkbook()->GetIWorksheets()->SetActiveSheetIndex(dataSheetIdx);

    // Getting Workbook and selected worksheet  
    intrusive_ptr<Aspose::Cells::IWorkbook> workbook = workbookDesigner->GetIWorkbook();
    intrusive_ptr<Aspose::Cells::IWorksheet> work = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIdx);

    // Scaling rows height and coluumns width according to custom Ole size
    double height = OleHeight / 576.0f;
    double width = OleWidth / 576.0f;

    // Setting Ole Size according to selected rows and columns
    SetOleAccordingToCustomHeightWidth(workbook, startRow, endRow, startCol, endCol, width, height, dataSheetIdx);

    // Set Ole Size in Workbook
    workbook->GetIWorksheets()->SetOleSize(startRow, endRow, startCol, endCol);
    workbook->GetIWorksheets()->GetObjectByIndex(0)->SetGridlinesVisible(false);

    // Setting Image Options to take the worksheet Image
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

    // Adding Image to slide picture collection
    auto ppImage = presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(newTempFileName));

    // Saving worbook to stream and copying in byte array
    System::SharedPtr<System::IO::Stream> mstream = ToSlidesMemoryStream(workbook->SaveToStream());
    System::ArrayPtr<uint8_t> chartOleData = System::MakeArray<uint8_t>(mstream->get_Length(), 0);
    mstream->set_Position(0);
    mstream->Read(chartOleData, 0, chartOleData->get_Length());

    // Adding Ole Object frame
    System::SharedPtr<OleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(chartOleData, u"xls");
    System::SharedPtr<IOleObjectFrame> oleObjectFrame = slide->get_Shapes()->AddOleObjectFrame(x, y, OleWidth, OleHeight, dataInfo);

    // Setting ole frame Image and Alternative Text    
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

## **Conclusion**


{{% alert color="primary" %}}   {{% /alert %}} 

There are two approaches to fix the worksheet resizing issue. The selection of the appropriate approach depends upon the requirement and the use case. Both approaches work in the same way whether the presentations are created from a template or create from scratch. Also, there is no limit of the OLE Object Frame size in the solution. 


h4. {_}Related Sections 
{_}

[Creating and Embedding an Excel Chart as OLE Object in Presentation](/slides/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

