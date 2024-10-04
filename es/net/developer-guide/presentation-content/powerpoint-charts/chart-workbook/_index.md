---
title: Libro de Gráficos
type: docs
weight: 70
url: /es/net/chart-workbook/
keywords: "Libro de gráficos, datos de gráficos, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Libro de gráficos en presentación de PowerPoint en C# o .NET"
---

## **Establecer Datos de Gráficos desde el Libro**
Aspose.Slides proporciona los métodos [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) y [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) que permiten leer y escribir libros de datos de gráficos (que contienen datos de gráficos editados con Aspose.Cells). **Nota** que los datos del gráfico deben estar organizados de la misma manera o deben tener una estructura similar a la fuente.

Este código C# demuestra una operación de ejemplo:

```c#
using (Presentation pres = new Presentation("chart.pptx"))
{
    Chart chart = (Chart) pres.Slides[0].Shapes[0];
    IChartData data = chart.ChartData;

    MemoryStream stream = data.ReadWorkbookStream();

    data.Series.Clear();
    data.Categories.Clear();

    stream.Position = 0;
    data.WriteWorkbookStream(stream);
}
```


## **Establecer Celda de Libro como Etiqueta de Datos de Gráfico**
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega un gráfico de burbujas con algunos datos.
1. Accede a las series del gráfico.
1. Establece la celda del libro como una etiqueta de datos.
1. Guarda la presentación.

Este código C# te muestra cómo establecer una celda del libro como una etiqueta de datos de gráfico:

```c#
string lbl0 = "Valor de la celda Etiqueta 0";
string lbl1 = "Valor de la celda Etiqueta 1";
string lbl2 = "Valor de la celda Etiqueta 2";

// Instancia una clase de presentación que representa un archivo de presentación 

using (Presentation pres = new Presentation("chart2.pptx"))
{
    ISlide slide = pres.Slides[0];

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);

    IChartSeriesCollection series = chart.ChartData.Series;

    series[0].Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

    IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

    series[0].Labels[0].ValueFromCell = wb.GetCell(0, "A10", lbl0);
    series[0].Labels[1].ValueFromCell = wb.GetCell(0, "A11", lbl1);
    series[0].Labels[2].ValueFromCell = wb.GetCell(0, "A12", lbl2);

    pres.Save("resultchart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Gestionar Hojas de Cálculo**

Este código C# demuestra una operación donde se utiliza la propiedad [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) para acceder a una colección de hojas de cálculo:

``` csharp
using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **Especificar Tipo de Fuente de Datos**

Este código C# te muestra cómo especificar un tipo para una fuente de datos:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.ChartData.Series[0].Name;
    
    val.DataSourceType = DataSourceType.StringLiterals;
    val.Data = "LiteralString";

    val = chart.ChartData.Series[1].Name;
    val.Data = chart.ChartData.ChartDataWorkbook.GetCell(0, "B1", "NuevaCelda");

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Libro Externo**

{{% alert color="primary" %}} 
En [Aspose.Slides 19.4](https://docs.aspose.com/slides/net/aspose-slides-for-net-19-4-release-notes/), implementamos soporte para libros externos como fuente de datos para gráficos.
{{% /alert %}} 

### **Crear Libro Externo**
Usando los métodos **`ReadWorkbookStream`** y **`SetExternalWorkbook`**, puedes crear un libro externo desde cero o hacer que un libro interno sea externo.

Este código C# demuestra el proceso de creación de un libro externo:

```c#
using (Presentation pres = new Presentation())
{
    const string workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
    using (FileStream fileStream = new FileStream(workbookPath, FileMode.Create))
    {
        byte[] workbookData = chart.ChartData.ReadWorkbookStream().ToArray();
        fileStream.Write(workbookData, 0, workbookData.Length);
    }
    
    chart.ChartData.SetExternalWorkbook(Path.GetFullPath(workbookPath));

    pres.Save("externalWorkbook.pptx", SaveFormat.Pptx);
}
```


### **Establecer Libro Externo**
Usando el método **`SetExternalWorkbook`**, puedes asignar un libro externo a un gráfico como su fuente de datos. Este método también puede ser utilizado para actualizar una ruta al libro externo (si este último ha sido movido).

Mientras no puedes editar los datos en libros almacenados en ubicaciones o recursos remotos, aún puedes utilizar tales libros como una fuente de datos externa. Si se proporciona la ruta relativa para un libro externo, se convierte automáticamente en una ruta completa.

Este código C# te muestra cómo establecer un libro externo:

```c#
// La ruta al directorio de documentos.
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.ChartData;
                    
    chartData.SetExternalWorkbook(Path.GetFullPath("externalWorkbook.xlsx"));
                  

    chartData.Series.Add(chartData.ChartDataWorkbook.GetCell(0, "B1"), ChartType.Pie);
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B2"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B3"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B4"));

    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A2"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A3"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A4"));
    pres.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
}
```

El parámetro `ChartData` (bajo el método `SetExternalWorkbook`) se utiliza para especificar si se cargará o no un libro de Excel. 

* Cuando el valor de `ChartData` se establece en `false`, solo se actualiza la ruta del libro: los datos del gráfico no se cargarán ni actualizarán desde el libro objetivo. Puedes querer usar esta configuración cuando te encuentres en una situación donde el libro objetivo no exista o no esté disponible. 
* Cuando el valor de `ChartData` se establece en `true`, los datos del gráfico se actualizan desde el libro objetivo.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Obtener Ruta del Libro de Fuente de Datos Externo del Gráfico**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Crea un objeto para la forma del gráfico.
1. Crea un objeto para el tipo de fuente (`ChartDataSourceType`) que representa la fuente de datos del gráfico.
1. Especifica la condición relevante según el tipo de fuente siendo el mismo que el tipo de fuente de datos del libro externo.

Este código C# demuestra la operación:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[1];
    IChart chart = (IChart)slide.Shapes[0];
    ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        string path = chart.ChartData.ExternalWorkbookPath;
    }
    
    // Guarda la presentación
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **Editar Datos del Gráfico**

Puedes editar los datos en libros externos de la misma manera que haces cambios en los contenidos de libros internos. Cuando un libro externo no se puede cargar, se lanza una excepción.

Este código C# es una implementación del proceso descrito:

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```