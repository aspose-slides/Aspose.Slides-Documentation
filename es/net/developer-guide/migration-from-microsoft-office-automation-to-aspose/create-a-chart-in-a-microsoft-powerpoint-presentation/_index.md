---
title: Crear gráficos usando VSTO y Aspose.Slides para .NET
linktitle: Crear gráfico
type: docs
weight: 80
url: /es/net/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- crear gráfico
- migración
- VSTO
- automatización de Office
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda cómo automatizar la creación de gráficos de PowerPoint en C#. Esta guía paso a paso muestra por qué Aspose.Slides para .NET es una alternativa más rápida y potente a Microsoft.Office.Interop."
---

## **Descripción general**

Este artículo muestra cómo crear y personalizar gráficos en presentaciones de Microsoft PowerPoint de forma programática usando C#. Con Aspose.Slides para .NET, puedes automatizar la generación de gráficos profesionales y basados en datos sin depender de Microsoft Office o bibliotecas Interop. La API ofrece un conjunto amplio de funciones para crear gráficos de columnas, de pastel, de líneas y más, con control total sobre la apariencia, los datos y el diseño. Ya sea que estés generando informes, paneles de control o presentaciones empresariales, Aspose.Slides te ayuda a ofrecer visualizaciones de alta calidad directamente desde tus aplicaciones .NET.

## **Ejemplo VSTO**

Esta sección muestra cómo crear un gráfico en una presentación de Microsoft PowerPoint usando **VSTO (Visual Studio Tools for Office)**. Con VSTO, puedes generar y personalizar gráficos de forma programática combinando la automatización de PowerPoint y Excel. El ejemplo proporcionado muestra cómo agregar un **gráfico de columnas agrupadas 3D**, rellenarlo con datos de una hoja de cálculo de Excel, ajustar el formato y el diseño, y guardar la presentación final, todo desde una aplicación .NET.

1. Crear una instancia de una presentación de Microsoft PowerPoint.  
2. Agregar una diapositiva en blanco a la presentación.  
3. Agregar un gráfico de columnas agrupadas 3D y acceder a él.  
4. Crear una nueva instancia de un libro de trabajo de Microsoft Excel y cargar los datos del gráfico.  
5. Acceder a la hoja de datos del gráfico usando la instancia del libro de trabajo de Excel.  
6. Establecer el rango del gráfico en la hoja y eliminar las series 2 y 3 del gráfico.  
7. Modificar los datos de categorías del gráfico en la hoja de datos del gráfico.  
8. Modificar los datos de la serie 1 en la hoja de datos del gráfico.  
9. Acceder al título del gráfico y establecer sus propiedades de fuente.  
10. Acceder al eje de valores del gráfico y establecer la unidad mayor, unidad menor, valor máximo y valor mínimo.  
11. Acceder al eje de profundidad (series) del gráfico y eliminarlo; solo se usa una serie en este ejemplo.  
12. Establecer los ángulos de rotación del gráfico en las direcciones X y Y.  
13. Guardar la presentación.  
14. Cerrar las instancias de Microsoft Excel y PowerPoint.  

```c#
EnsurePowerPointIsRunning(true, true);

// Instanciar un objeto de diapositiva.
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

// Acceder a la primera diapositiva de la presentación.
objSlide = objPres.Slides[1];

// Seleccionar la primera diapositiva y establecer su diseño.
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

// Agregar un gráfico predeterminado a la diapositiva.
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20, 30, 400, 300);

// Acceder al gráfico agregado.
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

// Acceder a los datos del gráfico.
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

// Crear una instancia del libro de trabajo de Excel para trabajar con los datos del gráfico.
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

// Acceder a la hoja de datos del gráfico.
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

// Establecer el rango de datos para el gráfico.
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

// Aplicar el rango especificado a la tabla de datos del gráfico.
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

// Establecer valores para las categorías y los datos de series correspondientes.
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

// Establecer el título del gráfico.
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "2007 Sales";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

// Acceder al eje de valores del gráfico.
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

// Establecer los valores para las unidades del eje.
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

// Acceder al eje de profundidad del gráfico.
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

// Establecer la rotación del gráfico.
ppChart.Rotation = 20;   // Valor Y
ppChart.Elevation = 15;  // Valor X
ppChart.RightAngleAxes = false;

// Guardar la presentación como archivo PPTX.
objPres.SaveAs("VSTO_Sample_Chart.pptx", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

// Cerrar el libro de trabajo y la presentación.
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

    // Intente acceder a la propiedad Name. Si lanza una excepción, inicie una nueva instancia de PowerPoint.
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }

    // blnAddPresentation se usa para asegurar que se cargue una presentación.
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

    // blnAddSlide se usa para asegurar que haya al menos una diapositiva en la presentación.
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


El resultado:

![El gráfico creado usando VSTO](chart-created-using-VSTO.png)

## **Ejemplo Aspose.Slides para .NET**

El siguiente ejemplo muestra cómo crear un gráfico sencillo en una presentación de PowerPoint usando Aspose.Slides para .NET. Este código demuestra cómo agregar un **gráfico de columnas agrupadas 3D**, rellenarlo con datos de ejemplo y personalizar su apariencia. Con solo unas pocas líneas de código, puedes generar gráficos dinámicamente e integrarlos en tus presentaciones sin usar Microsoft Office.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).  
2. Obtener una referencia a la primera diapositiva.  
3. Agregar un gráfico de columnas agrupadas 3D y acceder a él.  
4. Acceder a los datos del gráfico.  
5. Eliminar las series no usadas 2 y 3.  
6. Modificar las categorías del gráfico actualizando las etiquetas.  
7. Actualizar los valores de la serie 1.  
8. Acceder al título del gráfico y establecer sus propiedades de fuente.  
9. Configurar el eje de valores del gráfico, incluyendo la unidad mayor, unidad menor, valores máximo y mínimo.  
10. Establecer los ángulos de rotación del gráfico en los ejes X e Y.  
11. Guardar la presentación en formato PPTX.  

```cs
// Crear una presentación vacía.
using (Presentation presentation = new Presentation())
{
    // Acceder a la primera diapositiva.
    ISlide slide = presentation.Slides[0];

    // Agregar un gráfico predeterminado.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 20, 30, 400, 300);

    // Obtener los datos del gráfico.
    IChartData chartData = chart.ChartData;

    // Eliminar las series predeterminadas extra.
    chartData.Series.RemoveAt(1);
    chartData.Series.RemoveAt(1);

    // Modificar los nombres de las categorías del gráfico.
    chartData.Categories[0].AsCell.Value = "Bikes";
    chartData.Categories[1].AsCell.Value = "Accessories";
    chartData.Categories[2].AsCell.Value = "Repairs";
    chartData.Categories[3].AsCell.Value = "Clothing";

    // Establecer el índice de la hoja de datos del gráfico.
    int worksheetIndex = 0;

    // Obtener el libro de datos del gráfico.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Modificar los valores de las series del gráfico.
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 1000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2500));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 4000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 3000));

    // Establecer el título del gráfico.
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("2007 Sales");
    IPortionFormat format = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat;
    format.FontItalic = NullableBool.True;
    format.FontHeight = 18;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    // Establecer las opciones del eje.
    chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;

    chart.Axes.VerticalAxis.MaxValue = 4000.0F;
    chart.Axes.VerticalAxis.MinValue = 0.0F;
    chart.Axes.VerticalAxis.MajorUnit = 2000.0F;
    chart.Axes.VerticalAxis.MinorUnit = 1000.0F;
    chart.Axes.VerticalAxis.TickLabelPosition = TickLabelPositionType.NextTo;

    // Establecer la rotación del gráfico.
    chart.Rotation3D.RotationX = 15;
    chart.Rotation3D.RotationY = 20;

    // Guardar la presentación como archivo PPTX.
    presentation.Save("Aspose_Sample_Chart.pptx", SaveFormat.Pptx);
}
```


El resultado:

![El gráfico creado usando Aspose.Slides para .NET](chart-created-using-aspose-slides.png)

## **Preguntas frecuentes**

**¿Puedo crear otros tipos de gráficos como de pastel, línea o barras con Aspose.Slides?**

Sí. Aspose.Slides para .NET admite una amplia gama de [tipos de gráficos](https://docs.aspose.com/slides/net/create-chart/), incluidos gráficos de pastel, de línea, de barras, diagramas de dispersión, gráficos de burbujas y más. Puedes especificar el tipo de gráfico deseado usando la enumeración [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) al agregar un gráfico.

**¿Puedo aplicar estilos o temas personalizados al gráfico?**

Sí. Puedes personalizar completamente la apariencia del gráfico, incluidos colores, fuentes, rellenos, contornos, líneas de cuadrícula y diseño. Sin embargo, aplicar temas de Office exactamente como se ven en PowerPoint requiere establecer manualmente los estilos individuales.

**¿Puedo exportar el gráfico como una imagen por separado de la diapositiva?**

Sí, Aspose.Slides te permite exportar cualquier forma —incluidos los gráficos— como una imagen separada (p. ej., PNG, JPEG) usando el método `GetImage` en el [shape](https://reference.aspose.com/slides/net/aspose.slides/ishape/).