---
title: Criar um Gráfico
type: docs
weight: 60
url: /pt/net/create-a-chart/
---
Os exemplos de código abaixo descrevem o processo de adição de um gráfico de colunas agrupadas 3D simples usando VSTO. Você cria uma instância de apresentação, adiciona um gráfico padrão a ela. Em seguida, usa a pasta de trabalho do Microsoft Excel para acessar e modificar os dados do gráfico, além de definir as propriedades do gráfico. Por fim, salve a apresentação.

## **VSTO**
Usando VSTO, as etapas a seguir são realizadas:

1. Crie uma instância de uma apresentação do Microsoft PowerPoint.
1. Adicione um slide em branco à apresentação.
1. Adicione um gráfico de colunas agrupadas 3D e acesse-o.
1. Crie uma nova instância de Microsoft Excel Workbook e carregue os dados do gráfico.
1. Acesse a planilha de dados do gráfico usando a instância Microsoft Excel Workbook da pasta de trabalho.
1. Defina o intervalo do gráfico na planilha e remova as séries 2 e 3 do gráfico.
1. Modifique os dados de categoria do gráfico na planilha de dados do gráfico.
1. Modifique os dados da série 1 do gráfico na planilha de dados do gráfico.
1. Agora, acesse o título do gráfico e defina as propriedades relacionadas à fonte.
1. Acesse o eixo de valores do gráfico e defina a unidade maior, unidades menores, valor máximo e valores mínimos.
1. Acesse a profundidade do gráfico ou eixo de séries e remova‑o, pois neste exemplo apenas uma série é usada.
1. Agora, defina os ângulos de rotação do gráfico nas direções X e Y.
1. Salve a apresentação.
1. Feche as instâncias do Microsoft Excel e do PowerPoint.

```csharp

 //Variáveis Globais

public static Microsoft.Office.Interop.PowerPoint.Application objPPT;

public static Microsoft.Office.Interop.PowerPoint.Presentation objPres;

private void ThisAddIn_Startup(object sender, System.EventArgs e)

{

	GEN_VSTO_Chart();

}

public static void GEN_VSTO_Chart()

{


	EnsurePowerPointIsRunning(true, true);

	//Instanciar objeto de slide

	Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

	//Acessar o primeiro slide da apresentação

	objSlide = objPres.Slides[1];

	//Selecionar o primeiro slide e definir seu layout

	objSlide.Select();

	objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

	//Adicionar um gráfico padrão no slide

	objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20F, 30F, 400F, 300F);

	//Acessar o gráfico adicionado

	Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

	//Acessar os dados do gráfico

	Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

	//Criar instância da pasta de trabalho do Excel para trabalhar com os dados do gráfico

	Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

	//Acessando a planilha de dados do gráfico

	Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

	//Definindo o intervalo do gráfico

	Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

	//Aplicando o intervalo definido na tabela de dados do gráfico

	Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];

	tbl1.Resize(tRange);

	//Definindo valores para categorias e dados das séries correspondentes

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

	//Definindo o título do gráfico

	ppChart.ChartTitle.Font.Italic = true;

	ppChart.ChartTitle.Text = "2007 Sales";

	ppChart.ChartTitle.Font.Size = 18;

	ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();

	ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;

	ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

	//Acessando eixo de valores do gráfico

	Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	//Definindo unidades do eixo de valores

	valaxis.MajorUnit = 2000.0F;

	valaxis.MinorUnit = 1000.0F;

	valaxis.MinimumScale = 0.0F;

	valaxis.MaximumScale = 4000.0F;

	//Acessando eixo de profundidade do gráfico

	Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	Depthaxis.Delete();

	//Definindo rotação do gráfico

	ppChart.Rotation = 20; //Valor Y

	ppChart.Elevation = 15; //Valor X

	ppChart.RightAngleAxes = false;

	// Salvar a apresentação como PPTX

	objPres.SaveAs("VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

	//Fechar pasta de trabalho e apresentação

	dataWorkbook.Application.Quit();

	objPres.Application.Quit();

}

//Supplementary methods

public static void StartPowerPoint()

{

	objPPT = new Microsoft.Office.Interop.PowerPoint.Application();

	objPPT.Visible = MsoTriState.msoTrue;

	//  objPPT.WindowState = PowerPoint.PpWindowState.ppWindowMaximized

}

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

	//Tente acessar a propriedade Name. Se gerar uma exceção então

	//inicie uma nova instância do PowerPoint

	try

	{

		strName = objPPT.Name;

	}

	catch (Exception ex)

	{

		StartPowerPoint();

	}

	//

	//blnAddPresentation é usado para garantir que haja uma apresentação carregada

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

	//BlnAddSlide é usado para garantir que haja ao menos um slide no

	//apresentação

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
## **Aspose.Slides**
Usando Aspose.Slides para .NET, as etapas a seguir são realizadas:

1. Crie uma instância de uma apresentação do Microsoft PowerPoint.
1. Adicione um slide em branco à apresentação.
1. Adicione um gráfico de colunas agrupadas 3D e acesse‑o.
1. Acesse a planilha de dados do gráfico usando uma instância de Microsoft Excel Workbook da pasta de trabalho.
1. Remova as séries 2 e 3 não utiliz­adas.
1. Acesse as categorias do gráfico e modifique os rótulos.
1. Acesse a série 1 e modifique os valores da série.
1. Agora, acesse o título do gráfico e defina as propriedades da fonte.
1. Acesse o eixo de valores do gráfico e defina a unidade maior, unidades menores, valor máximo e valores mínimos.
1. Agora, defina os ângulos de rotação do gráfico nas direções X e Y.
1. Salve a apresentação no formato PPTX.

```csharp

 public static void GEN_ASPOSE_Chart()

{

	//Criar apresentação vazia

	using (PresentationEx pres = new PresentationEx())

	{

		//Acessando o primeiro slide

		SlideEx slide = pres.Slides[0];

		//Adicionando gráfico padrão

		ChartEx ppChart = slide.Shapes.AddChart(ChartTypeEx.ClusteredColumn3D, 20F, 30F, 400F, 300F);

		//Obtendo dados do gráfico

		ChartDataEx chartData = ppChart.ChartData;

		//Removendo séries padrão extras

		chartData.Series.RemoveAt(1);

		chartData.Series.RemoveAt(1);

		//Modificando nomes das categorias do gráfico

		chartData.Categories[0].ChartDataCell.Value = "Bikes";

		chartData.Categories[1].ChartDataCell.Value = "Accessories";

		chartData.Categories[2].ChartDataCell.Value = "Repairs";

		chartData.Categories[3].ChartDataCell.Value = "Clothing";

		//Modificando valores das séries do gráfico para a primeira categoria

		chartData.Series[0].Values[0].Value = 1000;

		chartData.Series[0].Values[1].Value = 2500;

		chartData.Series[0].Values[2].Value = 4000;

		chartData.Series[0].Values[3].Value = 3000;

		//Definindo título do gráfico

		ppChart.HasTitle = true;

		ppChart.ChartTitle.Text.Text = "2007 Sales";

		PortionFormatEx format = ppChart.ChartTitle.Text.Paragraphs[0].Portions[0].PortionFormat;

		format.FontItalic = NullableBool.True;

		format.FontHeight = 18;

		format.FillFormat.FillType = FillTypeEx.Solid;

		format.FillFormat.SolidFillColor.Color = Color.Black;


		//Definindo valores dos eixos

		ppChart.ValueAxis.IsAutomaticMaxValue = false;

		ppChart.ValueAxis.IsAutomaticMinValue = false;

		ppChart.ValueAxis.IsAutomaticMajorUnit = false;

		ppChart.ValueAxis.IsAutomaticMinorUnit = false;

		ppChart.ValueAxis.MaxValue = 4000.0F;

		ppChart.ValueAxis.MinValue = 0.0F;

		ppChart.ValueAxis.MajorUnit = 2000.0F;

		ppChart.ValueAxis.MinorUnit = 1000.0F;

		ppChart.ValueAxis.TickLabelPosition = TickLabelPositionType.NextTo;

		//Definindo rotação do gráfico

		ppChart.Rotation3D.RotationX = 15;

		ppChart.Rotation3D.RotationY = 20;

		//Salvando apresentação

		pres.Write("AsposeSampleChart.pptx");

	}

}
``` 
## **Baixar Código de Exemplo**
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart/)