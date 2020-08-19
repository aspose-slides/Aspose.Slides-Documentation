---
title: Working Solution for Worksheet Resizing
type: docs
weight: 130
url: /cpp/working-solution-for-worksheet-resizing/
---

{{% alert color="primary" %}} 

It has been observed that Excel Worksheets embedded as OLE in a PowerPoint Presentation through Aspose components are resized to an unidentified scale after first time activation. This behavior creates a considerable visual difference of the presentation between pre and post chart activation states. We have investigated this issue in detail and found the solution to this issue that has been covered in this article. 

{{% /alert %}} 
#### **Background**
In [Adding Ole Frames article](), we have explained how to add an Ole Frame in presentation in a PowerPoint Presentation using Aspose.Slides for C++. In order to accommodate the [object changed issue](https://docs.aspose.com/display/slidesnet/Object+Changed+Issue+When+Adding+OleObjectFrame), we assigned the worksheet image of selected area to the Chart OLE Object Frame. In the output presentation, when we double click the OLE Object Frame showing the worksheet Image, the Excel Chart is activated. The end users can make any desired changes in the actual Excel Workbook and then return to the concerned Slide by clicking outside the activated Excel Workbook. The size of the OLE Object Frame will change when the user gets back to the slide. The resizing factor will be different for different sizes of OLE Object Frame and embedded Excel Workbook. 
#### **Cause of Resizing**
Since the Excel Workbook has its own window size, it tries to retain its original size on first time activation. On the other hand, the OLE Object Frame will have its own size. According to Microsoft, on activation of the Excel Workbook, Excel and PowerPoint negotiate the size and ensure it is in the correct proportions as part of the embedding operation. Based on the differences in the Excel Windows size and OLE Object Frame size / position, the resizing takes place. 
#### **Working Solution**
There are two possible solutions to avoid the re-sizing effect.

- Scale the Ole frame size in PPT to match the size in terms of height/width of desired number of rows/columns in Ole Frame
- Keeping the Ole frame size constant and scale the size of participating rows/columns to get fit in selected Ole frame size
#### **Scale Ole frame size to Worksheet's selected rows/ columns size**
In this approach, we will learn how to set the Ole frame size of the embedded Excel Workbook equivalent to the cumulative size of number of participating rows and columns in Excel Worksheet. 
#### **Example**
Suppose, we have defined a template excel sheet and and desire to add that to presentation as Ole frame. In this scenario, the size of the OLE Object Frame will be calculated first based on cumulative rows height and columns widths of participating workbook's rows and columns respectively. Then we will set the size of Ole frame to that calculated value. In order to avoid the red **Embedded Object** message for Ole frame in PowerPoint we will also get the image of desired portions of rows and columns in Workbook and set that as Ole frame image. 



[**C#**]()

``` cpp

 WorkbookDesigner workbookDesigner = new WorkbookDesigner();

workbookDesigner.Workbook = new Workbook("AsposeTest.xls");

Presentation presentation = new Presentation("AsposeTest.ppt");

Slide slide = presentation.Slides[0];

AddOleFrame(slide, 0, 15, 0, 3, 0, 300, 1100, 0, 0, presentation, workbookDesigner, true, 0, 0);

String fileName = "AsposeTest_Ole.ppt";

presentation.Save(fileName, Aspose.Slides.Export.SaveFormat.Ppt);


/***********Methods used*****************/

private static Size SetOleAccordingToSelectedRowsCloumns(Workbook workbook, Int32 startRow, Int32 endRow, Int32 startCol,

                     Int32 endCol, Int32 dataSheetIdx)

{

    Worksheet work = workbook.Worksheets[dataSheetIdx];

    double actualHeight = 0, actualWidth = 0;

    for (int i = startRow; i <= endRow; i++)

        actualHeight += work.Cells.GetRowHeightInch(i);

    for (int i = startCol; i <= endCol; i++)

        actualWidth += work.Cells.GetColumnWidthInch(i);

    //Setting new Row and Column Height

    return new Size((int)(Math.Round(actualWidth, 2) * 576), (int)(Math.Round(actualHeight, 2) * 576));

}


private static void AddOleFrame(Slide slide, Int32 startRow, Int32 endRow, Int32 startCol, Int32 endCol,

    Int32 dataSheetIdx, Int32 x, Int32 y, Double OleWidth, Double OleHeight,

    Presentation presentation, WorkbookDesigner workbookDesigner,

    Boolean onePagePerSheet, Int32 outputWidth, Int32 outputHeight) 

{

    String tempFileName = Path.GetTempFileName();

    if (startRow == 0)

    {

	startRow++;

	endRow++;

    }

    //Setting active sheet index of workbook

    workbookDesigner.Workbook.Worksheets.ActiveSheetIndex = dataSheetIdx;

    //Getting Workbook and selected worksheet  

    Workbook workbook = workbookDesigner.Workbook;

    Worksheet work=workbook.Worksheets[dataSheetIdx];

    //Setting Ole Size according to selected rows and columns

    Size SlideOleSize=SetOleAccordingToSelectedRowsCloumns(workbook, startRow, endRow, startCol, endCol,  dataSheetIdx);

    OleWidth = SlideOleSize.Width;

    OleHeight = SlideOleSize.Height;

    //Set Ole Size in Workbook

    workbook.Worksheets.SetOleSize(startRow, endRow, startCol, endCol);

    workbook.Worksheets[0].IsGridlinesVisible = false;



    //Setting Image Options to take the worksheet Image

    ImageOrPrintOptions imageOrPrintOptions = new ImageOrPrintOptions();

    imageOrPrintOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Bmp;

    imageOrPrintOptions.OnePagePerSheet = onePagePerSheet;



    SheetRender render = new SheetRender(workbookDesigner.Workbook.Worksheets[dataSheetIdx], imageOrPrintOptions);

    String ext = ".bmp";

    render.ToImage(0, tempFileName + ext);

    Image image = ScaleImage(Image.FromFile(tempFileName + ext), outputWidth, outputHeight);

    String newTempFileName = tempFileName.Replace(".tmp", ".tmp1") + ext;

    image.Save(newTempFileName, ImageFormat.Bmp);

    //Adding Image to slide picture collection

    Picture pic = new Picture(presentation, newTempFileName);

    int picId = presentation.Pictures.Add(pic);

    //Saving worbook to stream and copying in byte array

    Stream mstream = workbook.SaveToStream();

    byte[] chartOleData = new byte[mstream.Length];

    mstream.Position = 0;

    mstream.Read(chartOleData, 0, chartOleData.Length);

    //Adding Ole Object frame

    OleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(x, y, Convert.ToInt32(OleWidth),

  Convert.ToInt32(OleHeight), "Excel.Sheet.8", chartOleData);



    //Setting ole frame Imnae and Alternative Text property    

    oleObjectFrame.PictureId = picId;

    oleObjectFrame.AlternativeText = "image" + picId;

}


private static Image ScaleImage(Image image, Int32 outputWidth, Int32 outputHeight)

{

    if (outputWidth == 0 && outputHeight == 0)

    {

        outputWidth = image.Width;

        outputHeight = image.Height;

    }

    Bitmap outputImage = new Bitmap(outputWidth, outputHeight, image.PixelFormat);

    outputImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

    Graphics graphics = Graphics.FromImage(outputImage);

    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

    System.Drawing.Rectangle srcDestRect = new System.Drawing.Rectangle(0, 0, outputWidth, outputHeight);

    graphics.DrawImage(image, srcDestRect, srcDestRect, GraphicsUnit.Pixel);

    graphics.Dispose();

    return outputImage;

}




```




#### **Scale worksheet's row height and column width according to Ole Frame size**
In this approach, we will learn how to scale the heights of participating rows and width of participating column in accordance with custom set ole frame size
#### **Example**
Suppose, we have defined a template excel sheet and and desire to add that to presentation as Ole frame. In this scenario, we will set the size of Ole frame and scale the size of rows and columns participating in Ole Frame area. We will then save the workbook in stream to save changes and convert that to byte array for adding it in Ole frame. In order to avoid the red **Embedded Object** message for Ole frame in PowerPoint we will also get the image of desired portions of rows and columns in Workbook and set that as Ole frame image. 



[**C#**]()

``` cpp

 WorkbookDesigner workbookDesigner = new WorkbookDesigner();

workbookDesigner.Workbook = new Workbook("AsposeTest.xls");

Presentation presentation = new Presentation("AsposeTest.ppt");

Slide slide = presentation.Slides[0];

AddOleFrame(slide, 0, 15, 0, 3, 0, 300, 1100, 0, 0, presentation, workbookDesigner, true, 0, 0);

String fileName = "AsposeTest_Ole.ppt";

presentation.Save(fileName, Aspose.Slides.Export.SaveFormat.Ppt);


/***********Methods used*****************/

private static void SetOleAccordingToCustomHeighWidth(Workbook workbook, Int32 startRow,

                            Int32 endRow, Int32 startCol, Int32 endCol, double slideWidth, double slideHeight, Int32 dataSheetIdx)

{

    Worksheet work = workbook.Worksheets[dataSheetIdx];

    double actualHeight = 0, actualWidth = 0;

    double newHeight = slideHeight;

    double newWidth = slideWidth;

    double tem = 0;

    double newTem = 0;

    for (int i = startRow; i <= endRow; i++)

        actualHeight += work.Cells.GetRowHeightInch(i);

    for (int i = startCol; i <= endCol; i++)

        actualWidth += work.Cells.GetColumnWidthInch(i);

    ///Setting new Row and Column Height

    for (int i = startRow; i <= endRow; i++)

    {

        tem = work.Cells.GetRowHeightInch(i);

        newTem = (tem / actualHeight) * newHeight;

        work.Cells.SetRowHeightInch(i, newTem);

    }

    for (int i = startCol; i <= endCol; i++)

    {

        tem = work.Cells.GetColumnWidthInch(i);

        newTem = (tem / actualWidth) * newWidth;

        work.Cells.SetColumnWidthInch(i, newTem);

    }

}


private static void AddOleFrame(Slide slide, Int32 startRow, Int32 endRow, Int32 startCol, Int32 endCol,

    Int32 dataSheetIdx, Int32 x, Int32 y, Double OleWidth, Double OleHeight,

    Presentation presentation, WorkbookDesigner workbookDesigner,

    Boolean onePagePerSheet, Int32 outputWidth, Int32 outputHeight) 

{

    String tempFileName = Path.GetTempFileName();

    if (startRow == 0)

    {

	startRow++;

	endRow++;

    }

    //Setting active sheet index of workbook

    workbookDesigner.Workbook.Worksheets.ActiveSheetIndex = dataSheetIdx;

    //Getting Workbook and selected worksheet  

    Workbook workbook = workbookDesigner.Workbook;

    Worksheet work=workbook.Worksheets[dataSheetIdx];

    //Scaling rows height and coluumns width according to custom Ole size

    double height = OleHeight / 576f;

    double width = OleWidth / 576f;



    SetOleAccordingToCustomHeighWidth(workbook, startRow, endRow, startCol, endCol, width, height, dataSheetIdx);

    //Set Ole Size in Workbook

    workbook.Worksheets.SetOleSize(startRow, endRow, startCol, endCol);

    workbook.Worksheets[0].IsGridlinesVisible = false;



    //Setting Image Options to take the worksheet Image

    ImageOrPrintOptions imageOrPrintOptions = new ImageOrPrintOptions();

    imageOrPrintOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Bmp;

    imageOrPrintOptions.OnePagePerSheet = onePagePerSheet;



    SheetRender render = new SheetRender(workbookDesigner.Workbook.Worksheets[dataSheetIdx], imageOrPrintOptions);

    String ext = ".bmp";

    render.ToImage(0, tempFileName + ext);

    Image image = ScaleImage(Image.FromFile(tempFileName + ext), outputWidth, outputHeight);

    String newTempFileName = tempFileName.Replace(".tmp", ".tmp1") + ext;

    image.Save(newTempFileName, ImageFormat.Bmp);

    //Adding Image to slide picture collection

    Picture pic = new Picture(presentation, newTempFileName);

    int picId = presentation.Pictures.Add(pic);

    //Saving worbook to stream and copying in byte array

    Stream mstream = workbook.SaveToStream();

    byte[] chartOleData = new byte[mstream.Length];

    mstream.Position = 0;

    mstream.Read(chartOleData, 0, chartOleData.Length);

    //Adding Ole Object frame

    OleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(x, y, Convert.ToInt32(OleWidth),

  Convert.ToInt32(OleHeight), "Excel.Sheet.8", chartOleData);



    //Setting ole frame Imnae and Alternative Text property    

    oleObjectFrame.PictureId = picId;

    oleObjectFrame.AlternativeText = "image" + picId;

}


private static Image ScaleImage(Image image, Int32 outputWidth, Int32 outputHeight)

{

    if (outputWidth == 0 && outputHeight == 0)

    {

        outputWidth = image.Width;

        outputHeight = image.Height;

    }

    Bitmap outputImage = new Bitmap(outputWidth, outputHeight, image.PixelFormat);

    outputImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

    Graphics graphics = Graphics.FromImage(outputImage);

    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

    System.Drawing.Rectangle srcDestRect = new System.Drawing.Rectangle(0, 0, outputWidth, outputHeight);

    graphics.DrawImage(image, srcDestRect, srcDestRect, GraphicsUnit.Pixel);

    graphics.Dispose();

    return outputImage;

}




```




#### **Conclusion**


{{% alert color="primary" %}}   {{% /alert %}} 

There are two approaches to fix the worksheet resizing issue. The selection of the appropriate approach depends upon the requirement and the use case. Both approaches work in the same way whether the presentations are created from a template or create from scratch. Also, there is no limit of the OLE Object Frame size in the solution. 


h4. {_}Related Sections 
{_}

[Creating and Embedding an Excel Chart as OLE Object in Presentation](https://docs.aspose.com/display/slidesnet/Creating+Excel+Chart+and+Embedding+it+in+Presentation+as+OLE+Object)

[Updating OLE Objects automatically](https://docs.aspose.com/display/slidesnet/Updating+OLE+objects+automatically+using+MS+PowerPoint+Add+In)
