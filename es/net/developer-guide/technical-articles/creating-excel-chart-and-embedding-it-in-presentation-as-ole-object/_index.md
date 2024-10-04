---
title: Creando un gráfico de Excel e incrustándolo en una presentación como objeto OLE
type: docs
weight: 50
url: /net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
---

{{% alert color="primary" %}} 

En las diapositivas de PowerPoint, el uso de gráficos editables para la representación gráfica de los datos es una actividad común. Aspose proporciona el soporte para crear gráficos de Excel mediante el uso de Aspose.Cells para .NET y, posteriormente, estos gráficos se pueden incrustar como un objeto OLE en la diapositiva de PowerPoint a través de Aspose.Slides para .NET. Este artículo cubre los pasos requeridos junto con la implementación en C# y VB.NET para crear e incrustar un gráfico de MS Excel como un objeto OLE en una presentación de PowerPoint utilizando Aspose.Cells para .NET y Aspose.Slides para .NET.

{{% /alert %}} 
## **Pasos Requeridos**
La siguiente secuencia de pasos es necesaria para crear e incrustar un gráfico de Excel como un objeto OLE en la diapositiva de PowerPoint:

1. Crear un gráfico de Excel usando Aspose.Cells para .NET.
2. Establecer el tamaño OLE del gráfico de Excel utilizando Aspose.Cells para .NET.
3. Obtener la imagen del gráfico de Excel con Aspose.Cells para .NET.
4. Incrustar el gráfico de Excel como un objeto OLE dentro de la presentación PPTX usando Aspose.Slides para .NET.
5. Reemplazar la imagen del objeto cambiado con la imagen obtenida en el paso 3 para solucionar el problema del objeto cambiado.
6. Escribir la presentación de salida en disco en formato PPTX.

## **Implementación de los Pasos Requeridos**
La implementación de los pasos anteriores en C# y Visual Basic es la siguiente:

```c#
//Paso - 1: Crear un gráfico de Excel usando Aspose.Cells
//--------------------------------------------------
//Crear un libro de trabajo
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Agregar un gráfico de Excel
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Paso - 2: Establecer el tamaño OLE del gráfico utilizando Aspose.Cells
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//Paso - 3: Obtener la imagen del gráfico con Aspose.Cells
//-----------------------------------------------------------
Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
//Guardar el libro de trabajo en un stream
MemoryStream wbStream = wb.SaveToStream();
//Paso - 4  Y 5
//-----------------------------------------------------------
//Paso - 4: Incrustar el gráfico como un objeto OLE dentro de la presentación .ppt usando Aspose.Slides
//-----------------------------------------------------------
//Paso - 5: Reemplazar la imagen del objeto cambiado con la imagen obtenida en el paso 3 para solucionar el problema del objeto cambiado
//-----------------------------------------------------------
//Crear una presentación
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//Agregar el libro de trabajo en la diapositiva
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//Paso - 6: Escribir la presentación de salida en disco
//-----------------------------------------------------------
pres.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

```c#
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook wb, int chartRows, int chartCols)
{
    //Array de nombres de celdas
    string[] cellsName = new string[] 
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    //Array de datos de celdas
    int[] cellsValue = new int[] 
    {
        67,86,68,91,
        44,64,89,48,
        46,97,78,60,
        43,29,69,26,
        24,40,38,25
    };
    //Agregar una nueva hoja de trabajo para llenar las celdas con datos
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;
    //Llenar la DataSheet con datos
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //Agregar una hoja de gráfico
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    //Agregar un gráfico en ChartSheet con series de datos de DataSheet
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //Establecer ChartSheet como la hoja activa
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```

```c#
static void AddExcelChartInPresentation(Presentation pres, ISlide sld, Stream wbStream, Bitmap imgChart)
{
    float oleWidth = pres.SlideSize.Size.Width;
    float oleHeight = pres.SlideSize.Size.Height;

    byte[] chartOleData = new byte[wbStream.Length];
    wbStream.Position = 0;
    wbStream.Read(chartOleData, 0, chartOleData.Length);

    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oof = sld.Shapes.AddOleObjectFrame(0, 0, oleWidth, oleHeight, dataInfo);

    using (MemoryStream imageStream = new MemoryStream())
    {
        imgChart.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);

        imageStream.Position = 0;
        IPPImage ppImage = pres.Images.AddImage(imageStream);

        oof.SubstitutePictureFormat.Picture.Image = ppImage;
    }
}
```

{{% alert color="primary" %}} 

La presentación creada a través del método anterior, llevará el gráfico de Excel como objeto OLE que se puede activar haciendo doble clic en el marco de objeto OLE.

{{% /alert %}} 
## **Conclusión**
{{% alert color="primary" %}} 

Utilizando Aspose.Cells para .NET junto con Aspose.Slides para .NET, podemos crear cualquier gráfico de Excel compatible con Aspose.Cells para .NET e incrustar el gráfico creado como un objeto OLE en una diapositiva de PowerPoint. También se puede definir el tamaño OLE del gráfico de Excel. Los usuarios finales pueden editar adicionalmente el gráfico de Excel como cualquier otro objeto OLE.

{{% /alert %}} 
## **Secciones Relacionadas**
[Solución Funcional para el Cambio de Tamaño de Gráfico](/slides/net/working-solution-for-chart-resizing-in-pptx/)[Problema del Objeto Cambiado](/slides/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)