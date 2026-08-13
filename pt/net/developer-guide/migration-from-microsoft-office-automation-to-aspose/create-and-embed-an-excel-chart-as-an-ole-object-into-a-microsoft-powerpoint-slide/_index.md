---
title: Criar e Incorporar Gráficos do Excel como Objetos OLE Usando VSTO e Aspose.Slides for .NET
linktitle: Criar e Incorporar Gráficos do Excel como Objetos OLE
type: docs
weight: 70
url: /pt/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- criar gráfico
- incorporar gráfico do Excel
- objeto OLE
- migração
- VSTO
- automação do Office
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Migrar da automação do Microsoft Office para Aspose.Slides for .NET e incorporar gráficos do Excel como objetos OLE em slides do PowerPoint (PPT, PPTX) em C#."
---
{{% alert color="info" %}} 

 Gráficos são representações visuais dos seus dados e amplamente usados em slides de apresentação. Este artigo mostrará o código para criar e incorporar um Gráfico do Excel como um Objeto OLE em um slide do PowerPoint programaticamente usando [VSTO](/slides/pt/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) e [Aspose.Slides for .NET](/slides/pt/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Criando e Incorporando um Gráfico do Excel**
Os dois exemplos de código abaixo são longos e detalhados porque a tarefa que descrevem é complexa. Você cria uma pasta de trabalho do Microsoft Excel, cria um gráfico e depois cria a apresentação do Microsoft PowerPoint na qual incorporará o gráfico. Objetos OLE contêm links para o documento original, de modo que um usuário que clicar duas vezes no arquivo incorporado abrirá o arquivo e sua aplicação.
## **Exemplo VSTO**
Usando VSTO, as etapas a seguir são realizadas:

1. Criar uma instância do objeto Microsoft Excel ApplicationClass.
1. Criar uma nova pasta de trabalho com uma planilha.
1. Adicionar gráfico à planilha.
1. Salvar a pasta de trabalho.
1. Abrir a pasta de trabalho do Excel que contém a planilha com os dados do gráfico.
1. Obter a coleção ChartObjects da planilha.
1. Obter o gráfico para copiar.
1. Criar uma apresentação do Microsoft PowerPoint.
1. Adicionar um slide em branco à apresentação.
1. Copiar o gráfico da planilha do Excel para a área de transferência.
1. Colar o gráfico na apresentação do PowerPoint.
1. Posicionar o gráfico no slide.
1. Salvar a apresentação.

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
    // Declarar uma variável para a instância do Excel ApplicationClass.
    Microsoft.Office.Interop.Excel.ApplicationClass excelApplication = null;

    // Declarar variáveis para os parâmetros do método Workbooks.Open.
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    // Declarar variáveis para o método Chart.ChartWizard.
    object paramChartFormat = 1;
    object paramCategoryLabels = 0;
    object paramSeriesLabels = 0;
    bool paramHasLegend = true;
    object paramTitle = "Sales by Quarter";
    object paramCategoryTitle = "Fiscal Quarter";
    object paramValueTitle = "Billions";

    try
    {
        // Criar uma instância do objeto Excel ApplicationClass.
        excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

        // Criar uma nova pasta de trabalho com 1 planilha.
        xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

        // Alterar o nome da planilha.
        xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
        targetSheet.Name = "Quarterly Sales";

        // Inserir alguns dados para o gráfico na planilha.
        //              A       B       C       D       E
        //     1                Q1      Q2      Q3      Q4
        //     2    N. America  1.5     2       1.5     2.5
        //     3    S. America  2       1.75    2       2
        //     4    Europe      2.25    2       2.5     2
        //     5    Asia        2.5     2.5     2       2.75

        SetCellValue(targetSheet, "A2", "N. America");
        SetCellValue(targetSheet, "A3", "S. America");
        SetCellValue(targetSheet, "A4", "Europe");
        SetCellValue(targetSheet, "A5", "Asia");

        SetCellValue(targetSheet, "B1", "Q1");
        SetCellValue(targetSheet, "B2", 1.5);
        SetCellValue(targetSheet, "B3", 2);
        SetCellValue(targetSheet, "B4", 2.25);
        SetCellValue(targetSheet, "B5", 2.5);

        SetCellValue(targetSheet, "C1", "Q2");
        SetCellValue(targetSheet, "C2", 2);
        SetCellValue(targetSheet, "C3", 1.75);
        SetCellValue(targetSheet, "C4", 2);
        SetCellValue(targetSheet, "C5", 2.5);

        SetCellValue(targetSheet, "D1", "Q3");
        SetCellValue(targetSheet, "D2", 1.5);
        SetCellValue(targetSheet, "D3", 2);
        SetCellValue(targetSheet, "D4", 2.5);
        SetCellValue(targetSheet, "D5", 2);

        SetCellValue(targetSheet, "E1", "Q4");
        SetCellValue(targetSheet, "E2", 2.5);
        SetCellValue(targetSheet, "E3", 2);
        SetCellValue(targetSheet, "E4", 2);
        SetCellValue(targetSheet, "E5", 2.75);

        // Obter o intervalo que contém os dados do gráfico.
        xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

        // Obter a coleção ChartObjects da planilha.
        xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Adicionar um Gráfico à coleção.
        xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
        newChartObject.Name = "Sales Chart";

        // Criar um novo gráfico a partir dos dados.
        newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
            paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

        // Salvar a pasta de trabalho.
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
            // Fechar o Excel.
            excelApplication.Quit();
        }
    }
}
```

```c#
static void UseCopyPaste()
{
    // Declarar variáveis para armazenar referências aos objetos do PowerPoint.
    pptNS.ApplicationClass powerpointApplication = null;
    pptNS.Presentation pptPresentation = null;
    pptNS.Slide pptSlide = null;
    pptNS.ShapeRange shapeRange = null;

    // Declarar variáveis para armazenar referências aos objetos do Excel.
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
        // Criar uma instância do PowerPoint.
        powerpointApplication = new pptNS.ApplicationClass();

        // Criar uma instância do Excel.
        excelApplication = new xlNS.ApplicationClass();

        // Abrir a pasta de trabalho do Excel que contém a planilha com os dados do gráfico.
        excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing);

        // Obter a planilha que contém o gráfico.
        targetSheet =
            (xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

        // Obter a coleção ChartObjects da planilha.
        chartObjects =
            (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Obter o gráfico para copiar.
        existingChartObject =
            (xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

        // Criar uma apresentação do PowerPoint.
        pptPresentation =
            powerpointApplication.Presentations.Add(
            Microsoft.Office.Core.MsoTriState.msoTrue);

        // Adicionar um slide em branco à apresentação.
        pptSlide =
            pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

        // Copiar o gráfico da planilha do Excel para a área de transferência.
        existingChartObject.Copy();

        // Colar o gráfico na apresentação do PowerPoint.
        shapeRange = pptSlide.Shapes.Paste();

        // Posicionar o gráfico no slide.
        shapeRange.Left = 60;
        shapeRange.Top = 100;

        // Salvar a apresentação.
        pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        // Liberar o objeto de slide do PowerPoint.
        shapeRange = null;
        pptSlide = null;

        // Fechar e liberar o objeto Presentation.
        if (pptPresentation != null)
        {
            pptPresentation.Close();
            pptPresentation = null;
        }

        // Encerrar o PowerPoint e liberar o objeto ApplicationClass.
        if (powerpointApplication != null)
        {
            powerpointApplication.Quit();
            powerpointApplication = null;
        }

        // Liberar os objetos do Excel.
        targetSheet = null;
        chartObjects = null;
        existingChartObject = null;

        // Fechar e liberar o objeto Workbook do Excel.
        if (excelWorkBook != null)
        {
            excelWorkBook.Close(false, paramMissing, paramMissing);
            excelWorkBook = null;
        }

        // Encerrar o Excel e liberar o objeto ApplicationClass.
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




## **Exemplo Aspose.Slides for .NET**
Usando Aspose.Slides for .NET, as etapas a seguir são realizadas:

1. Criar uma pasta de trabalho usando Aspose.Cells for .NET.
1. Criar um gráfico do Microsoft Excel.
1. Definir o tamanho OLE do Gráfico do Excel.
1. Obter uma imagem do gráfico.
1. Incorporar o gráfico do Excel como um Objeto OLE dentro da apresentação PPTX usando Aspose.Slides for .NET.
1. Substituir a imagem do objeto alterado pela imagem obtida na etapa 3 para contornar o problema de objeto alterado.
1. Gravar a apresentação de saída no disco no formato PPTX.



```c#
using System.Drawing;
using Aspose.Slides;

//Etapa - 1: Criar um gráfico Excel usando Aspose.Cells
//--------------------------------------------------
//Criar uma pasta de trabalho
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Adicionar um gráfico Excel
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Etapa - 2: Definir o tamanho OLE do gráfico usando Aspose.Cells
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//Etapa - 3: Obter a imagem do gráfico com Aspose.Cells
//-----------------------------------------------------------
MemoryStream chartImageStream = new MemoryStream();
wb.Worksheets[chartSheetIndex].Charts[0].ToImage(chartImageStream, Aspose.Cells.Drawing.ImageType.Png);
chartImageStream.Position = 0;
Bitmap imgChart = new Bitmap(chartImageStream);
//Salvar a pasta de trabalho no stream
MemoryStream wbStream = wb.SaveToStream();
//Etapa - 4 e 5
//-----------------------------------------------------------
//Etapa - 4: Incorporar o gráfico como objeto OLE dentro de uma apresentação .ppt usando Aspose.Slides
//-----------------------------------------------------------
//Etapa - 5: Substituir a imagem de objeto alterado pela imagem obtida na etapa 3 para resolver o problema de objeto alterado
//-----------------------------------------------------------
//Criar uma apresentação
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//Adicionar a pasta de trabalho no slide
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//Etapa - 6: Gravar a apresentação de saída no disco
//-----------------------------------------------------------
pres.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

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
    //Array de nomes de células
    string[] cellsName = new string[]
      {
  "A1", "A2", "A3", "A4",
  "B1", "B2", "B3", "B4",
  "C1", "C2", "C3", "C4",
  "D1", "D2", "D3", "D4",
  "E1", "E2", "E3", "E4"
      };

    //Array de dados das células
    int[] cellsValue = new int[]
      {
 67,86,68,91,
 44,64,89,48,
 46,97,78,60,
 43,29,69,26,
 24,40,38,25
      };
    //Adicionar uma nova planilha para preencher células com dados
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;
    //Preencher DataSheet com dados
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //Adicionar uma planilha de gráfico
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    //Adicionar um gráfico na ChartSheet com séries de dados da DataSheet
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //Definir ChartSheet como planilha ativa
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```