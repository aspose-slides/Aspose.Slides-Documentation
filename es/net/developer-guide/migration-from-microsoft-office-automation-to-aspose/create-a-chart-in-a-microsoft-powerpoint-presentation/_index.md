---
title: Crear un gráfico en una presentación de Microsoft PowerPoint
type: docs
weight: 80
url: /net/create-a-chart-in-a-microsoft-powerpoint-presentation/
---

{{% alert color="primary" %}} 

 Los gráficos son representaciones visuales de datos que se utilizan ampliamente en presentaciones. Este artículo muestra el código para crear un gráfico en Microsoft PowerPoint programáticamente utilizando [VSTO](/slides/net/create-a-chart-in-a-microsoft-powerpoint-presentation/) y [Aspose.Slides para .NET](/slides/net/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **Creando un gráfico**
Los ejemplos de código a continuación describen el proceso de agregar un gráfico de columnas agrupadas 3D simple utilizando VSTO. Creas una instancia de presentación, le agregas un gráfico predeterminado. Luego, usas un libro de trabajo de Microsoft Excel para acceder y modificar los datos del gráfico junto con establecer las propiedades del gráfico. Por último, guarda la presentación.
## **Ejemplo de VSTO**
Usando VSTO, se realizan los siguientes pasos:

1. Crea una instancia de una presentación de Microsoft PowerPoint.
1. Agrega una diapositiva en blanco a la presentación.
1. Agrega un gráfico de **columnas agrupadas 3D** y accede a él.
1. Crea una nueva instancia de un libro de trabajo de Microsoft Excel y carga los datos del gráfico.
1. Accede a la hoja de datos del gráfico utilizando la instancia del libro de trabajo de Microsoft Excel.
1. Establece el rango del gráfico en la hoja de trabajo y elimina las series 2 y 3 del gráfico.
1. Modifica los datos de categoría del gráfico en la hoja de datos del gráfico.
1. Modifica los datos de la serie 1 en la hoja de datos del gráfico.
1. Ahora, accede al título del gráfico y establece las propiedades relacionadas con la fuente.
1. Accede al eje de valores del gráfico y establece la unidad mayor, las unidades menores, el valor máximo y los valores mínimos.
1. Accede al eje de profundidad o de series del gráfico y elimina eso, ya que en este ejemplo solo se usa una serie.
1. Ahora, establece los ángulos de rotación del gráfico en dirección X e Y.
1. Guarda la presentación.
1. Cierra las instancias de Microsoft Excel y PowerPoint.

**La presentación de salida, creada con VSTO** 

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

((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bicicletas";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accesorios";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Reparaciones";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Ropa";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

//Setting chart title
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "Ventas 2007";
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




## **Ejemplo de Aspose.Slides para .NET**
Utilizando Aspose.Slides para .NET, se realizan los siguientes pasos:

1. Crea una instancia de una presentación de Microsoft PowerPoint.
1. Agrega una diapositiva en blanco a la presentación.
1. Agrega un gráfico de **columnas agrupadas 3D** y accede a él.
1. Accede a la hoja de datos del gráfico utilizando una instancia de un libro de trabajo de Microsoft Excel.
1. Elimina las series 2 y 3 no utilizadas.
1. Accede a las categorías del gráfico y modifica las etiquetas.
1. Accede a la serie 1 y modifica los valores de la serie.
1. Ahora, accede al título del gráfico y establece las propiedades de la fuente.
1. Accede al eje de valores del gráfico y establece la unidad mayor, las unidades menores, el valor máximo y los valores mínimos.
1. Ahora, establece los ángulos de rotación del gráfico en dirección X e Y.
1. Guarda la presentación en formato PPTX.

**La presentación de salida, creada con Aspose.Slides**

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
    chartData.Categories[0].AsCell.Value = "Bicicletas";
    chartData.Categories[1].AsCell.Value = "Accesorios";
    chartData.Categories[2].AsCell.Value = "Reparaciones";
    chartData.Categories[3].AsCell.Value = "Ropa";

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
    ppChart.ChartTitle.AddTextFrameForOverriding("Ventas 2007");
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

## **Recursos**
Los proyectos y archivos utilizados en este artículo se pueden descargar desde nuestro sitio web:

- [Descargar la presentación generada por VSTO](http://docs.aspose.com:8082/docs/download/attachments/87523560/VSTOSampleChart.pptx).
- [Descargar el gráfico de muestra generado por Aspose.Slides](http://docs.aspose.com:8082/docs/download/attachments/87523560/AsposeSampleChart.pptx).

{{% /alert %}}