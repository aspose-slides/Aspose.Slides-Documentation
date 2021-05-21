---
title: Create a Chart  in a Microsoft PowerPoint Presentation
type: docs
weight: 80
url: /net/create-a-chart-in-a-microsoft-powerpoint-presentation/
---

{{% alert color="primary" %}} 

 Charts are visual representations of data that are widely used in presentations. This article shows the code for create a chart in Microsoft PowerPoint programmatically by using [VSTO](/slides/net/create-a-chart-in-a-microsoft-powerpoint-presentation/) and [Aspose.Slides for .NET](/slides/net/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **Creating a Chart**
The code examples below describe the process of adding a simple 3D clustered column chart using VSTO. You create a presentation instance, add a default chart to it. Then use Microsoft Excel workbook to access and modify chart data along with setting chart properties. Lastly, save the presentation.
## **VSTO Example**
Using VSTO, the following steps are performed:

1. Create an instance of a Microsoft PowerPoint presentation.
1. Add a blank slide to the presentation.
1. Add a **3D clustered column** chart and access it.
1. Create a new Microsoft Excel Workbook instance and load chart data.
1. Access the chart data worksheet using Microsoft Excel Workbook instance from workbook.
1. Set the chart range in the worksheet and remove series 2 and 3 from the chart.
1. Modify the chart category data in the chart data worksheet.
1. Modify chart series 1 data in the chart data worksheet.
1. Now, access the chart title and set the font related properties.
1. Access the chart value axis and set the major unit, minor units, max value and min values.
1. Access the chart depth or series axis and remove that as in this example, only one serie is used.
1. Now, set the chart rotation angles in X and Y direction.
1. Save the presentation.
1. Close the instances of Microsoft Excel and PowerPoint.

**The output presentation, created with VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



```c#
EnsurePowerPointIsRunning(true, true);

//Instantiate slide object
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

//Access the first slide of presentation
objSlide = objPres.Slides[1];

//Select firs slide and set its layout
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

//Add a default chart in slide
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20F, 30F, 400F, 300F);

//Access the added chart
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

//Access the chart data
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

//Create instance to Excel workbook to work with chart data
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

//Accessing the data worksheet for chart
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

//Setting the range of chart
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

//Applying the set range on chart data table
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

//Setting values for categories and respective series data

((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

//Setting chart title
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "2007 Sales";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

//Accessing Chart value axis
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

//Setting values axis units
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

//Accessing Chart Depth axis
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

//Setting chart rotation
ppChart.Rotation = 20; //Y-Value
ppChart.Elevation = 15; //X-Value
ppChart.RightAngleAxes = false;

// Save the presentation as a PPTX
objPres.SaveAs("C:\\VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);
//objPres.SaveAs(@"..\..\..\VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

//Close Workbook and presentation
dataWorkbook.Application.Quit();
objPres.Application.Quit();
```



```c#
public static void EnsurePowerPointIsRunning(bool blnAddPresentation)
{
    EnsurePowerPointIsRunning(blnAddPresentation, false);
}

public static void EnsurePowerPointIsRunning()
{
    EnsurePowerPointIsRunning(false, false);
}

public static void EnsurePowerPointIsRunning(bool blnAddPresentation, bool blnAddSlide)
{
    string strName = null;
    //
    //Try accessing the name property. If it causes an exception then
    //start a new instance of PowerPoint
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }
    //
    //blnAddPresentation is used to ensure there is a presentation loaded
    if (blnAddPresentation == true)
    {
        try
        {
            strName = objPres.Name;
        }
        catch (Exception ex)
        {
            objPres = objPPT.Presentations.Add(MsoTriState.msoTrue);
        }
    }
    //
    //BlnAddSlide is used to ensure there is at least one slide in the
    //presentation
    if (blnAddSlide)
    {
        try
        {
            strName = objPres.Slides[1].Name;
        }
        catch (Exception ex)
        {
            Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;
            Microsoft.Office.Interop.PowerPoint.CustomLayout objCustomLayout = null;
            objCustomLayout = objPres.SlideMaster.CustomLayouts[1];
            objSlide = objPres.Slides.AddSlide(1, objCustomLayout);
            objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutText;
            objCustomLayout = null;
            objSlide = null;
        }
    }
}
```




## **Aspose.Slides for .NET Example**
Using Aspose.Slides for .NET, the following steps are performed:

1. Create an instance of a Microsoft PowerPoint presentation.
1. Add a blank slide to the presentation.
1. Add a **3D clustered column** chart and access that.
1. Access the chart data worksheet using a Microsoft Excel Workbook instance from workbook.
1. Remove unused series 2 and 3.
1. Access chart categories and modify the labels.
1. Acces series 1 and modify the series values.
1. Now, access the chart title and set the font properties.
1. Access the chart value axis and set the major unit, minor units, max value and min values.
1. Now, set the chart rotation angles in X and Y direction.
1. Save the presentation to PPTX format.

**The output presentation, created with Aspose.Slides**

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

```csharp
//Create empty presentation
using (Presentation pres = new Presentation())
{

    //Accessing first slide
    ISlide slide = pres.Slides[0];

    //Addding default chart
    IChart ppChart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 20F, 30F, 400F, 300F);

    //Getting Chart data
    IChartData chartData = ppChart.ChartData;

    //Removing Extra default series
    chartData.Series.RemoveAt(1);
    chartData.Series.RemoveAt(1);

    //Modifying chart categories names
    chartData.Categories[0].AsCell.Value = "Bikes";
    chartData.Categories[1].AsCell.Value = "Accessories";
    chartData.Categories[2].AsCell.Value = "Repairs";
    chartData.Categories[3].AsCell.Value = "Clothing";

    //Setting the index of chart data sheet
    int defaultWorksheetIndex = 0;


    //Getting the chart data worksheet
    IChartDataWorkbook fact = ppChart.ChartData.ChartDataWorkbook;

    //Modifying chart series values for first category
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 1000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 2500));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 4000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 4, 1, 3000));

    //Setting Chart title
    ppChart.HasTitle = true;
    ppChart.ChartTitle.AddTextFrameForOverriding("2007 Sales");
    IPortionFormat format = ppChart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat;
    format.FontItalic = NullableBool.True;
    format.FontHeight = 18;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;


    ////Setting Axis values
    ppChart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
    ppChart.Axes.VerticalAxis.IsAutomaticMinValue = false;
    ppChart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
    ppChart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;

    ppChart.Axes.VerticalAxis.MaxValue = 4000.0F;
    ppChart.Axes.VerticalAxis.MinValue = 0.0F;
    ppChart.Axes.VerticalAxis.MajorUnit = 2000.0F;
    ppChart.Axes.VerticalAxis.MinorUnit = 1000.0F;
    ppChart.Axes.VerticalAxis.TickLabelPosition = TickLabelPositionType.NextTo;

    //Setting Chart rotation
    ppChart.Rotation3D.RotationX = 15;
    ppChart.Rotation3D.RotationY = 20;

    //Saving Presentation
    pres.Save("AsposeSampleChart.pptx", SaveFormat.Pptx);
}
```



{{% alert color="primary" %}} 

## **Resources**
The projects and files used in this article can be downloaded from our website:

- [Download the VSTO generated presentation](http://docs.aspose.com:8082/docs/download/attachments/87523560/VSTOSampleChart.pptx).
- [Download the sample chart generated by Aspose.Slides](http://docs.aspose.com:8082/docs/download/attachments/87523560/AsposeSampleChart.pptx).

{{% /alert %}}
