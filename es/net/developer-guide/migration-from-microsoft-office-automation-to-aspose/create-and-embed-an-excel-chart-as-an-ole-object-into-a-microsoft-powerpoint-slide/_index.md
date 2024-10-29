---
title: Crear e incrustar un gráfico de Excel como un objeto OLE en una diapositiva de Microsoft PowerPoint
type: docs
weight: 70
url: /es/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
---

{{% alert color="primary" %}} 

 Los gráficos son representaciones visuales de sus datos y se utilizan ampliamente en las diapositivas de presentación. Este artículo le mostrará el código para crear e incrustar un gráfico de Excel como un objeto OLE en la diapositiva de PowerPoint programáticamente utilizando [VSTO](/slides/es/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) y [Aspose.Slides para .NET](/slides/es/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Creando e incrustando un gráfico de Excel**
Los dos ejemplos de código a continuación son largos y detallados porque la tarea que describen está involucrada. Creas un libro de trabajo de Microsoft Excel, creas un gráfico y luego creas la presentación de Microsoft PowerPoint en la que incrustarás el gráfico. Los objetos OLE contienen enlaces al documento original, por lo que un usuario que haga doble clic en el archivo incrustado abrirá el archivo y su aplicación.
## **Ejemplo de VSTO**
Utilizando VSTO, se realizan los siguientes pasos:

1. Crear una instancia del objeto Microsoft Excel ApplicationClass.
1. Crear un nuevo libro de trabajo con una hoja en él.
1. Agregar un gráfico a la hoja.
1. Guardar el libro de trabajo.
1. Abrir el libro de trabajo de Excel que contiene la hoja de cálculo con los datos del gráfico.
1. Obtener la colección ChartObjects para la hoja.
1. Obtener el gráfico para copiar.
1. Crear una presentación de Microsoft PowerPoint.
1. Agregar una diapositiva en blanco a la presentación.
1. Copiar el gráfico de la hoja de trabajo de Excel al portapapeles.
1. Pegar el gráfico en la presentación de PowerPoint.
1. Posicionar el gráfico en la diapositiva.
1. Guardar la presentación.

```c#
CreateNewChartInExcel();
UseCopyPaste();
```

```c#
static void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)
{
    targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);
}
```

```c#
static void CreateNewChartInExcel()
{
    // Declarar una variable para la instancia de Excel ApplicationClass.
    Microsoft.Office.Interop.Excel.ApplicationClass excelApplication = null;

    // Declarar variables para los parámetros del método Workbooks.Open.
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    // Declarar variables para el método Chart.ChartWizard.
    object paramChartFormat = 1;
    object paramCategoryLabels = 0;
    object paramSeriesLabels = 0;
    bool paramHasLegend = true;
    object paramTitle = "Ventas por Trimestre";
    object paramCategoryTitle = "Trimestre Fiscal";
    object paramValueTitle = "Miles de millones";

    try
    {
        // Crear una instancia del objeto Excel ApplicationClass.
        excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

        // Crear un nuevo libro de trabajo con 1 hoja en él.
        xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

        // Cambiar el nombre de la hoja.
        xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
        targetSheet.Name = "Ventas Trimestrales";

        // Insertar algunos datos para el gráfico en la hoja.
        //              A       B       C       D       E
        //     1                T1      T2      T3      T4
        //     2    N. América  1.5     2       1.5     2.5
        //     3    S. América  2       1.75    2       2
        //     4    Europa      2.25    2       2.5     2
        //     5    Asia        2.5     2.5     2       2.75

        SetCellValue(targetSheet, "A2", "N. América");
        SetCellValue(targetSheet, "A3", "S. América");
        SetCellValue(targetSheet, "A4", "Europa");
        SetCellValue(targetSheet, "A5", "Asia");

        SetCellValue(targetSheet, "B1", "T1");
        SetCellValue(targetSheet, "B2", 1.5);
        SetCellValue(targetSheet, "B3", 2);
        SetCellValue(targetSheet, "B4", 2.25);
        SetCellValue(targetSheet, "B5", 2.5);

        SetCellValue(targetSheet, "C1", "T2");
        SetCellValue(targetSheet, "C2", 2);
        SetCellValue(targetSheet, "C3", 1.75);
        SetCellValue(targetSheet, "C4", 2);
        SetCellValue(targetSheet, "C5", 2.5);

        SetCellValue(targetSheet, "D1", "T3");
        SetCellValue(targetSheet, "D2", 1.5);
        SetCellValue(targetSheet, "D3", 2);
        SetCellValue(targetSheet, "D4", 2.5);
        SetCellValue(targetSheet, "D5", 2);

        SetCellValue(targetSheet, "E1", "T4");
        SetCellValue(targetSheet, "E2", 2.5);
        SetCellValue(targetSheet, "E3", 2);
        SetCellValue(targetSheet, "E4", 2);
        SetCellValue(targetSheet, "E5", 2.75);

        // Obtener el rango que contiene los datos del gráfico.
        xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

        // Obtener la colección ChartObjects para la hoja.
        xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Añadir un gráfico a la colección.
        xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
        newChartObject.Name = "Gráfico de Ventas";

        // Crear un nuevo gráfico de los datos.
        newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
            paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

        // Guardar el libro de trabajo.
        newWorkbook.SaveAs(paramWorkbookPath, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, xlNS.XlSaveAsAccessMode.xlNoChange, paramMissing, paramMissing, paramMissing, paramMissing, paramMissing);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        if (excelApplication != null)
        {
            // Cerrar Excel.
            excelApplication.Quit();
        }
    }
}
```

```c#
static void UseCopyPaste()
{
    // Declarar variables para mantener referencias a los objetos de PowerPoint.
    pptNS.ApplicationClass powerpointApplication = null;
    pptNS.Presentation pptPresentation = null;
    pptNS.Slide pptSlide = null;
    pptNS.ShapeRange shapeRange = null;

    // Declarar variables para mantener referencias a los objetos de Excel.
    xlNS.ApplicationClass excelApplication = null;
    xlNS.Workbook excelWorkBook = null;
    xlNS.Worksheet targetSheet = null;
    xlNS.ChartObjects chartObjects = null;
    xlNS.ChartObject existingChartObject = null;

    string paramPresentationPath = Application.StartupPath + @"\ChartTest.pptx";
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    try
    {
        // Crear una instancia de PowerPoint.
        powerpointApplication = new pptNS.ApplicationClass();

        // Crear una instancia de Excel.
        excelApplication = new xlNS.ApplicationClass();

        // Abrir el libro de Excel que contiene la hoja de cálculo con los datos del gráfico.
        excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing);

        // Obtener la hoja de cálculo que contiene el gráfico.
        targetSheet =
            (xlNS.Worksheet)(excelWorkBook.Worksheets["Ventas Trimestrales"]);

        // Obtener la colección ChartObjects para la hoja.
        chartObjects =
            (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Obtener el gráfico para copiar.
        existingChartObject =
            (xlNS.ChartObject)(chartObjects.Item("Gráfico de Ventas"));

        // Crear una presentación de PowerPoint.
        pptPresentation =
            powerpointApplication.Presentations.Add(
            Microsoft.Office.Core.MsoTriState.msoTrue);

        // Agregar una diapositiva en blanco a la presentación.
        pptSlide =
            pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

        // Copiar el gráfico de la hoja de trabajo de Excel al portapapeles.
        existingChartObject.Copy();

        // Pegar el gráfico en la presentación de PowerPoint.
        shapeRange = pptSlide.Shapes.Paste();

        // Posicionar el gráfico en la diapositiva.
        shapeRange.Left = 60;
        shapeRange.Top = 100;

        // Guardar la presentación.
        pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        // Liberar el objeto de la diapositiva de PowerPoint.
        shapeRange = null;
        pptSlide = null;

        // Cerrar y liberar el objeto Presentación.
        if (pptPresentation != null)
        {
            pptPresentation.Close();
            pptPresentation = null;
        }

        // Salir de PowerPoint y liberar el objeto ApplicationClass.
        if (powerpointApplication != null)
        {
            powerpointApplication.Quit();
            powerpointApplication = null;
        }

        // Liberar los objetos de Excel.
        targetSheet = null;
        chartObjects = null;
        existingChartObject = null;

        // Cerrar y liberar el objeto Workbook de Excel.
        if (excelWorkBook != null)
        {
            excelWorkBook.Close(false, paramMissing, paramMissing);
            excelWorkBook = null;
        }

        // Salir de Excel y liberar el objeto ApplicationClass.
        if (excelApplication != null)
        {
            excelApplication.Quit();
            excelApplication = null;
        }

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}
```

## **Ejemplo de Aspose.Slides para .NET**
Usando Aspose.Slides para .NET, se realizan los siguientes pasos:

1. Crear un libro de trabajo utilizando Aspose.Cells para .NET.
1. Crear un gráfico de Microsoft Excel.
1. Establecer el tamaño OLE del gráfico de Excel.
1. Obtener una imagen del gráfico.
1. Incrustar el gráfico de Excel como un objeto OLE dentro de la presentación PPTX utilizando Aspose.Slides para .NET.
1. Reemplazar la imagen del objeto cambiada por la imagen obtenida en el paso 3 para abordar el problema del objeto cambiado.
1. Escribir la presentación de salida en el disco en formato PPTX.



```c#
//Paso - 1: Crear un gráfico de Excel utilizando Aspose.Cells
//--------------------------------------------------
//Crear un libro de trabajo
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Agregar un gráfico de Excel
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Paso - 2: Establecer el tamaño OLE del gráfico. usando Aspose.Cells
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//Paso - 3: Obtener la imagen del gráfico con Aspose.Cells
//-----------------------------------------------------------
Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
//Guardar el libro de trabajo en un stream
MemoryStream wbStream = wb.SaveToStream();
//Paso - 4 Y 5
//-----------------------------------------------------------
//Paso - 4: Incrustar el gráfico como un objeto OLE dentro de la presentación .ppt utilizando Aspose.Slides
//-----------------------------------------------------------
//Paso - 5: Reemplazar la imagen del objeto cambiada por la imagen obtenida en el paso 3 para abordar el Problema del Objeto Cambiado
//-----------------------------------------------------------
//Crear una presentación
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//Agregar el libro de trabajo en la diapositiva
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//Paso - 6: Escribir la presentación de salida en el disco
//-----------------------------------------------------------
pres.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

```c#
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, Stream workbookStream, Bitmap chartImage)
{
    float oleWidth = presentation.SlideSize.Size.Width;
    float oleHeight = presentation.SlideSize.Size.Height;

    byte[] chartOleData = new byte[workbookStream.Length];
    workbookStream.Position = 0;
    workbookStream.Read(chartOleData, 0, chartOleData.Length);

    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(0, 0, oleWidth, oleHeight, dataInfo);

    using (MemoryStream imageStream = new MemoryStream())
    {
        chartImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);

	imageStream.Position = 0;
        IPPImage image = presentation.Images.AddImage(imageStream);

        oleFrame.SubstitutePictureFormat.Picture.Image = image;
    }
}
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
    //Agregar una nueva hoja de trabajo para poblar las celdas con datos
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "HojaDeDatos";
    dataSheet.Name = sheetName;
    //Poblar HojaDeDatos con datos
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //Agregar una hoja de gráfico
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "HojaDeGráfico";
    //Agregar un gráfico en HojaDeGráfico con series de datos de HojaDeDatos
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //Establecer HojaDeGráfico como la hoja activa
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```