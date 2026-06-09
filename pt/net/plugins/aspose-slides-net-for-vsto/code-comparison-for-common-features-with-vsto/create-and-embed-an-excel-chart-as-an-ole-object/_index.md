---
title: Criar e Incorporar um Gráfico do Excel como um Objeto OLE
type: docs
weight: 70
url: /pt/net/create-and-embed-an-excel-chart-as-an-ole-object/
---
Os dois exemplos de código abaixo são longos e detalhados porque a tarefa que eles descrevem é complexa. Você cria uma pasta de trabalho do Microsoft Excel, cria um gráfico e depois cria a apresentação do Microsoft PowerPoint na qual você incorporará o gráfico. Objetos OLE contêm links para o documento original, de modo que um usuário que clicar duas vezes no arquivo incorporado abrirá o arquivo e seu aplicativo.
## **VSTO**
Usando VSTO, as seguintes etapas são realizadas:

1. Crie uma instância do objeto Microsoft Excel ApplicationClass.
1. Crie uma nova pasta de trabalho com uma planilha.
1. Adicione um gráfico à planilha.
1. Salve a pasta de trabalho.
1. Abra a pasta de trabalho do Excel que contém a planilha com os dados do gráfico.
1. Obtenha a coleção ChartObjects da planilha.
1. Obtenha o gráfico a ser copiado.
1. Crie uma apresentação do Microsoft PowerPoint.
1. Adicione um slide em branco à apresentação.
1. Copie o gráfico da planilha do Excel para a área de transferência.
1. Cole o gráfico na apresentação do PowerPoint.
1. Posicione o gráfico no slide.
1. Salve a apresentação.

``` csharp

 public void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)

{

	targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);

}

public void CreateNewChartInExcel()

{

	// Declare uma variável para a instância do Excel ApplicationClass.
	Microsoft.Office.Interop.Excel.Application excelApplication = new xlNS.Application() ;//new Microsoft.Office.Interop.Excel.ApplicationClass();
	// Declare variáveis para os parâmetros do método Workbooks.Open.
	string paramWorkbookPath = System.Windows.Forms.Application.StartupPath+@"\ChartData.xlsx";
	object paramMissing = Type.Missing;
	// Declare variáveis para o método Chart.ChartWizard.
	object paramChartFormat = 1;
	object paramCategoryLabels = 0;
	object paramSeriesLabels = 0;
	bool paramHasLegend = true;
	object paramTitle = "Sales by Quarter";
	object paramCategoryTitle = "Fiscal Quarter";
	object paramValueTitle = "Billions";
	try
	{
		// Crie uma instância do objeto Excel ApplicationClass.
	   // excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();
		// Crie uma nova pasta de trabalho com 1 planilha.
		xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);
		// Altere o nome da planilha.
		xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
		targetSheet.Name = "Quarterly Sales";
		// Insira alguns dados para o gráfico na planilha.
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
		// Obtenha o intervalo que contém os dados do gráfico.
		xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");
		// Obtenha a coleção ChartObjects para a planilha.
		xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));
		// Adicione um Gráfico à coleção.
		xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
		newChartObject.Name = "Sales Chart";
		// Crie um novo gráfico a partir dos dados.
		newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
			paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);
		// Salve a pasta de trabalho.
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
			// Feche o Excel.
			excelApplication.Quit();
		}
	}
}

public void UseCopyPaste()
{
	// Declare variáveis para armazenar referências aos objetos do PowerPoint.
	pptNS.Application powerpointApplication = null;
	pptNS.Presentation pptPresentation = null;
	pptNS.Slide pptSlide = null;
	pptNS.ShapeRange shapeRange = null;
	// Declare variáveis para armazenar referências aos objetos do Excel.
	xlNS.Application excelApplication = null;
	xlNS.Workbook excelWorkBook = null;
	xlNS.Worksheet targetSheet = null;
	xlNS.ChartObjects chartObjects = null;
	xlNS.ChartObject existingChartObject = null;
	string paramPresentationPath = System.Windows.Forms.Application.StartupPath + @"\ChartTest.pptx";
	string paramWorkbookPath = System.Windows.Forms.Application.StartupPath + @"\ChartData.xlsx";
	object paramMissing = Type.Missing;
	try
	{
		// Crie uma instância do PowerPoint.
		powerpointApplication =new pptNS.Application();
		// Crie uma instância do Excel.
		excelApplication = new xlNS.Application();
		// Abra a pasta de trabalho do Excel que contém a planilha com os dados do gráfico.
		excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
			paramMissing, paramMissing, paramMissing, paramMissing);
		// Obtenha a planilha que contém o gráfico.
		targetSheet =
			(xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);
		// Obtenha a coleção ChartObjects para a planilha.
		chartObjects =
			(xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));
		// Obtenha o gráfico a ser copiado.
		existingChartObject =
			(xlNS.ChartObject)(chartObjects.Item("Sales Chart"));
		// Crie uma apresentação do PowerPoint.
		pptPresentation =
			powerpointApplication.Presentations.Add(
			Microsoft.Office.Core.MsoTriState.msoTrue);
		// Adicione um slide em branco à apresentação.
		pptSlide =
			pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);
		// Copie o gráfico da planilha do Excel para a área de transferência.
		existingChartObject.Copy();
		// Cole o gráfico na apresentação do PowerPoint.
		shapeRange = pptSlide.Shapes.Paste();
		// Posicione o gráfico no slide.
		shapeRange.Left = 60;
		shapeRange.Top = 100;
		// Salve a apresentação.
		pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.Message);
	}
	finally
	{
		// Libere o objeto de slide do PowerPoint.
		shapeRange = null;
		pptSlide = null;
		// Feche e libere o objeto Presentation.
		if (pptPresentation != null)
		{
			pptPresentation.Close();
			pptPresentation = null;
		}
		// Encerre o PowerPoint e libere o objeto ApplicationClass.
		if (powerpointApplication != null)
		{
			powerpointApplication.Quit();
			powerpointApplication = null;
		}
		// Libere os objetos do Excel.
		targetSheet = null;
		chartObjects = null;
		existingChartObject = null;
		// Feche e libere o objeto Workbook do Excel.
		if (excelWorkBook != null)
		{
			excelWorkBook.Close(false, paramMissing, paramMissing);
			excelWorkBook = null;
		}
		// Encerre o Excel e libere o objeto ApplicationClass.
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

private void ThisAddIn_Startup(object sender, System.EventArgs e)
{
	CreateNewChartInExcel();
	UseCopyPaste();
}
``` 
## **Aspose.Slides**
Usando Aspose.Slides para .NET, as seguintes etapas são realizadas:

1. Crie uma pasta de trabalho usando Aspose.Cells para .NET.
1. Crie um gráfico do Microsoft Excel.
1. Defina o tamanho OLE do gráfico do Excel.
1. Obtenha uma imagem do gráfico.
1. Incorpore o gráfico do Excel como um Objeto OLE dentro da apresentação PPTX usando Aspose.Slides para .NET.
1. Substitua a imagem alterada do objeto pela imagem obtida na etapa 3 para lidar com o problema de objeto alterado.
1. Grave a apresentação resultante no disco no formato PPTX.

``` csharp

 static void Main(string[] args)

{

	//Crie uma pasta de trabalho
	Workbook wb = new Workbook();

	//Adicione um gráfico do Excel
	int chartSheetIndex = AddExcelChartInWorkbook(wb);

	wb.Worksheets.SetOleSize(0, 5, 0, 5);
	Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();

	//Salve a pasta de trabalho no stream
	MemoryStream wbStream = wb.SaveToStream();

	//Crie uma apresentação
	PresentationEx pres = new PresentationEx();
	SlideEx sld = pres.Slides[0];

	//Adicione a pasta de trabalho no slide
	AddExcelChartInPresentation(pres, sld, wbStream, imgChart);

	//Grave a apresentação de saída no disco
	pres.Write("chart.pptx");

}

static int AddExcelChartInWorkbook(Workbook wb)

{

	//Adicione uma nova planilha para preencher células com dados
	int dataSheetIdx = wb.Worksheets.Add();
	Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
	string sheetName = "DataSheet";
	dataSheet.Name = sheetName;

	//Preencha DataSheet com dados
	dataSheet.Cells["A2"].PutValue("N. America");
	dataSheet.Cells["A3"].PutValue("S. America");
	dataSheet.Cells["A4"].PutValue("Europe");
	dataSheet.Cells["A5"].PutValue("Asia");
	dataSheet.Cells["B1"].PutValue("Q1");
	dataSheet.Cells["B2"].PutValue(1.5);
	dataSheet.Cells["B3"].PutValue(2);
	dataSheet.Cells["B4"].PutValue(2.25);
	dataSheet.Cells["B5"].PutValue(2.5);
	dataSheet.Cells["C1"].PutValue("Q2");
	dataSheet.Cells["C2"].PutValue(2);
	dataSheet.Cells["C3"].PutValue(1.75);
	dataSheet.Cells["C4"].PutValue(2);
	dataSheet.Cells["C5"].PutValue(2.5);
	dataSheet.Cells["D1"].PutValue("Q3");
	dataSheet.Cells["D2"].PutValue(1.5);
	dataSheet.Cells["D3"].PutValue(2);
	dataSheet.Cells["D4"].PutValue(2.5);
	dataSheet.Cells["D5"].PutValue(2);
	dataSheet.Cells["E1"].PutValue("Q4");
	dataSheet.Cells["E2"].PutValue(2.5);
	dataSheet.Cells["E3"].PutValue(2);
	dataSheet.Cells["E4"].PutValue(2);
	dataSheet.Cells["E5"].PutValue(2.75);

	//Adicione uma planilha de gráfico
	int chartSheetIdx = wb.Worksheets.Add(SheetType.Chart);
	Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
	chartSheet.Name = "ChartSheet";

	//Adicione um gráfico em ChartSheet com a série de dados de DataSheet
	int chartIdx = chartSheet.Charts.Add(ChartType.Column3DClustered, 0, 5, 0, 5);
	Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
	chart.NSeries.Add(sheetName + "!A1:E5", false);

	//Definindo o Título do Gráfico
	chart.Title.Text = "Sales by Quarter";

	//Definindo a cor de primeiro plano da área de plotagem
	chart.PlotArea.Area.ForegroundColor = Color.White;

	//Definindo a cor de fundo da área de plotagem
	chart.PlotArea.Area.BackgroundColor = Color.White;

	//Definindo a cor de primeiro plano da área do gráfico
	chart.ChartArea.Area.BackgroundColor = Color.White;
	chart.Title.TextFont.Size = 16;

	//Definindo o título do eixo de categorias do gráfico
	chart.CategoryAxis.Title.Text = "Fiscal Quarter";

	//Definindo o título do eixo de valores do gráfico
	chart.ValueAxis.Title.Text = "Billions";

	//Defina ChartSheet como planilha ativa
	wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
	return chartSheetIdx;

}

private static void AddExcelChartInPresentation(PresentationEx pres, SlideEx sld, Stream wbStream, Bitmap imgChart)

{

	float oleWidth = pres.SlideSize.Size.Width;
	float oleHeight = pres.SlideSize.Size.Height;
	int x = 0;
	byte[] chartOleData = new byte[wbStream.Length];
	wbStream.Position = 0;
	wbStream.Read(chartOleData, 0, chartOleData.Length);
	OleObjectFrameEx oof = null;
	oof = sld.Shapes.AddOleObjectFrame(x, 0, oleWidth, oleHeight, "Excel.Sheet.8", chartOleData);
    using (MemoryStream imageStream = new MemoryStream())
    {
        imgChart.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
        imageStream.Position = 0;
        IPPImage ppImage = pres.Images.AddImage(imageStream);
        oof.SubstitutePictureFormat.Picture.Image = ppImage;
    }

}
``` 
## **Baixar Código de Exemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.and.Embed.an.Excel.Chart.as.an.OLE.Object.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object/)