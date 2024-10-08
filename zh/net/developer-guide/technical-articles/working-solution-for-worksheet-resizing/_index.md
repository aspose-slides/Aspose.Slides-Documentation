---
title: 工作表调整大小的有效解决方案
type: docs
weight: 40
url: /net/working-solution-for-worksheet-resizing/
---

{{% alert color="primary" %}} 

观察到通过 Aspose 组件在 PowerPoint 演示文稿中作为 OLE 嵌入的 Excel 工作表在第一次激活后被调整到一个未知比例。此行为在图表激活前后，相同幻灯片中的视觉差异非常显著。我们已详细调查此问题，并找到了解决方案，本文对此问题进行了说明。

{{% /alert %}} 
## **背景**
在[添加 OLE 框架文章]()中，我们解释了如何使用 Aspose.Slides for .NET 在 PowerPoint 演示文稿中添加 OLE 框架。为了处理 [对象更改问题](/slides/net/object-changed-issue-when-adding-oleobjectframe/)，我们将所选区域的工作表图像分配给图表 OLE 对象框。在输出的演示文稿中，当我们双击显示工作表图像的 OLE 对象框时，Excel 图表将被激活。最终用户可以在实际的 Excel 工作簿中进行任何所需的更改，然后通过点击激活的 Excel 工作簿外部返回到相关幻灯片。当用户返回幻灯片时，OLE 对象框的大小会发生变化。不同大小的 OLE 对象框和嵌入的 Excel 工作簿的调整大小因子会有所不同。
## **调整大小的原因**
由于 Excel 工作簿有自己的窗口大小，它会尝试在第一次激活时保持其原始大小。另一方面，OLE 对象框也会有其自己的大小。根据微软的说法，在激活 Excel 工作簿时，Excel 和 PowerPoint 通过协商大小并确保其在嵌入操作中保持正确的比例来处理此事。基于 Excel 窗口大小和 OLE 对象框的大小/位置之差，调整大小发生了。
## **有效解决方案**
有两种可能的解决方案可以避免调整大小的效果。

- 调整 PPT 中 OLE 框的大小，以匹配 OLE 框中所需行/列数量的高度/宽度。
- 保持 OLE 框的大小不变，并调整参与行/列的大小以适应所选的 OLE 框大小。
## **调整 OLE 框大小以匹配工作表选定的行/列大小**
在这个方法中，我们将学习如何将嵌入的 Excel 工作簿的 OLE 框大小设置为参与行和列在 Excel 工作表中的累计大小。
## **示例**
假设我们已定义一个模板 Excel 表，并希望将其作为 OLE 框添加到演示文稿中。在这种情况下，OLE 对象框的大小首先将根据参与工作簿的行和列的累计高度和宽度进行计算。然后，我们会将 OLE 框的大小设为该计算值。为了避免在 PowerPoint 中出现红色的 **嵌入对象** 消息，我们还将获取工作簿中所需行和列部分的图像，并将其设为 OLE 框图像。

```csharp
WorkbookDesigner workbookDesigner = new WorkbookDesigner();
workbookDesigner.Workbook = new Workbook("AsposeTest.xls");

Presentation presentation = new Presentation("AsposeTest.ppt");

Slide slide = (Slide)presentation.Slides[0];

AddOleFrame(slide, 0, 15, 0, 3, 0, 300, 1100, 0, 0, presentation, workbookDesigner, true, 0, 0);

String fileName = "AsposeTest_Ole.ppt";
presentation.Save(fileName, Aspose.Slides.Export.SaveFormat.Ppt);
```

```csharp
private static Size SetOleAccordingToSelectedRowsCloumns(Workbook workbook, Int32 startRow, Int32 endRow, Int32 startCol, Int32 endCol, Int32 dataSheetIdx)
{
    Worksheet work = workbook.Worksheets[dataSheetIdx];

    double actualHeight = 0, actualWidth = 0;

    for (int i = startRow; i <= endRow; i++)
        actualHeight += work.Cells.GetRowHeightInch(i);

    for (int i = startCol; i <= endCol; i++)
        actualWidth += work.Cells.GetColumnWidthInch(i);
    //设置新的行和列高度

    return new Size((int)(Math.Round(actualWidth, 2) * 576), (int)(Math.Round(actualHeight, 2) * 576));
}
```
```csharp
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

    //设置工作簿的活跃表索引
    workbookDesigner.Workbook.Worksheets.ActiveSheetIndex = dataSheetIdx;

    //获取工作簿和选定的工作表  
    Workbook workbook = workbookDesigner.Workbook;
    Worksheet work = workbook.Worksheets[dataSheetIdx];

    //根据所选行和列设置 OLE 大小
    Size SlideOleSize = SetOleAccordingToSelectedRowsCloumns(workbook, startRow, endRow, startCol, endCol, dataSheetIdx);
    OleWidth = SlideOleSize.Width;
    OleHeight = SlideOleSize.Height;

    //在工作簿中设置 OLE 大小
    workbook.Worksheets.SetOleSize(startRow, endRow, startCol, endCol);

    workbook.Worksheets[0].IsGridlinesVisible = false;

    //设置图像选项以获取工作表图像
    ImageOrPrintOptions imageOrPrintOptions = new ImageOrPrintOptions();
    imageOrPrintOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Bmp;
    imageOrPrintOptions.OnePagePerSheet = onePagePerSheet;

    SheetRender render = new SheetRender(workbookDesigner.Workbook.Worksheets[dataSheetIdx], imageOrPrintOptions);
    String ext = ".bmp";
    render.ToImage(0, tempFileName + ext);
    Image image = ScaleImage(Image.FromFile(tempFileName + ext), outputWidth, outputHeight);
    String newTempFileName = tempFileName.Replace(".tmp", ".tmp1") + ext;
    image.Save(newTempFileName, System.Drawing.Imaging.ImageFormat.Bmp);

    //将图像添加到幻灯片图片集合中
    var ppImage = presentation.Images.AddImage(File.ReadAllBytes(newTempFileName));

    //将工作簿保存到流并复制到字节数组中
    Stream mstream = workbook.SaveToStream();
    byte[] chartOleData = new byte[mstream.Length];
    mstream.Position = 0;
    mstream.Read(chartOleData, 0, chartOleData.Length);

    //添加 OLE 对象框
    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(x, y, Convert.ToInt32(OleWidth),
        Convert.ToInt32(OleHeight), dataInfo);

    //设置 oel 框图像和替代文本属性    
    oleObjectFrame.SubstitutePictureFormat.Picture.Image = ppImage;
    oleObjectFrame.AlternativeText = "image" + ppImage;
}
```

```csharp
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

## **根据 OLE 框大小调整工作表的行高和列宽**
在这个方法中，我们将学习如何根据自定义设置的 OLE 框大小调整参与行的高度和参与列的宽度。
## **示例**
假设我们已定义一个模板 Excel 表，并希望将其作为 OLE 框添加到演示文稿中。在这种情况下，我们将设置 OLE 框的大小，并调整参与 OLE 框区域的行和列的大小。然后我们将在流中保存工作簿以保存更改，并将其转换为字节数组以添加到 OLE 框中。为了避免在 PowerPoint 中出现红色的 **嵌入对象** 消息，我们还将获取工作簿中所需行和列部分的图像，并将其设为 OLE 框图像。

```csharp
WorkbookDesigner workbookDesigner = new WorkbookDesigner();
workbookDesigner.Workbook = new Workbook("AsposeTest.xls");

Presentation presentation = new Presentation("AsposeTest.ppt");

Slide slide = (Slide)presentation.Slides[0];

AddOleFrame(slide, 0, 15, 0, 3, 0, 300, 1100, 0, 0, presentation, workbookDesigner, true, 0, 0);

String fileName = "AsposeTest_Ole.ppt";
presentation.Save(fileName, Aspose.Slides.Export.SaveFormat.Ppt);
```

```csharp
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
    ///设置新行和列高度

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
```

```csharp
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

    //设置工作簿的活跃表索引
    workbookDesigner.Workbook.Worksheets.ActiveSheetIndex = dataSheetIdx;

    //获取工作簿和选定的工作表  
    Workbook workbook = workbookDesigner.Workbook;
    Worksheet work = workbook.Worksheets[dataSheetIdx];

    //根据所选行和列设置 OLE 大小
    Size SlideOleSize = SetOleAccordingToSelectedRowsCloumns(workbook, startRow, endRow, startCol, endCol, dataSheetIdx);
    OleWidth = SlideOleSize.Width;
    OleHeight = SlideOleSize.Height;

    //在工作簿中设置 OLE 大小
    workbook.Worksheets.SetOleSize(startRow, endRow, startCol, endCol);

    workbook.Worksheets[0].IsGridlinesVisible = false;

    //设置图像选项以获取工作表图像
    ImageOrPrintOptions imageOrPrintOptions = new ImageOrPrintOptions();
    imageOrPrintOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Bmp;
    imageOrPrintOptions.OnePagePerSheet = onePagePerSheet;

    SheetRender render = new SheetRender(workbookDesigner.Workbook.Worksheets[dataSheetIdx], imageOrPrintOptions);
    String ext = ".bmp";
    render.ToImage(0, tempFileName + ext);
    Image image = ScaleImage(Image.FromFile(tempFileName + ext), outputWidth, outputHeight);
    String newTempFileName = tempFileName.Replace(".tmp", ".tmp1") + ext;
    image.Save(newTempFileName, System.Drawing.Imaging.ImageFormat.Bmp);

    //将图像添加到幻灯片图片集合中
    var ppImage = presentation.Images.AddImage(File.ReadAllBytes(newTempFileName));

    //将工作簿保存到流并复制到字节数组中
    Stream mstream = workbook.SaveToStream();
    byte[] chartOleData = new byte[mstream.Length];
    mstream.Position = 0;
    mstream.Read(chartOleData, 0, chartOleData.Length);

    //添加 OLE 对象框
    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(x, y, Convert.ToInt32(OleWidth),
        Convert.ToInt32(OleHeight), dataInfo);

    //设置 oel 框图像和替代文本属性    
    oleObjectFrame.SubstitutePictureFormat.Picture.Image = ppImage;
    oleObjectFrame.AlternativeText = "image" + ppImage;
}
```

```csharp
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


## **结论**


{{% alert color="primary" %}}  有两种方法可以解决工作表调整大小的问题。选择合适的方法取决于需求和使用场景。这两种方法在创建演示文稿时无论是基于模板还是从头开始都能以相同的方式工作。此外，解决方案中并没有对 OLE 对象框的大小设限。{{% /alert %}} 
## **相关章节**
[在演示文稿中创建并嵌入 Excel 图表作为 OLE 对象](/slides/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[自动更新 OLE 对象](/slides/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)