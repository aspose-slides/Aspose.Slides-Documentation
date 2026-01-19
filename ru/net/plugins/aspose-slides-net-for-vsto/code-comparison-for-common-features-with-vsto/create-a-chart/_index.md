---
title: Создать диаграмму
type: docs
weight: 60
url: /ru/net/create-a-chart/
---

Ниже приведённые примеры кода описывают процесс добавления простого 3‑D сгруппированного столбчатого графика с помощью VSTO. Вы создаёте экземпляр презентации, добавляете в неё диаграмму по умолчанию. Затем используете книгу Microsoft Excel для доступа к данным диаграммы и их изменения, а также для задания свойств диаграммы. В конце сохраняете презентацию.
## **VSTO**
При работе с VSTO выполняются следующие шаги:

1. Создать экземпляр презентации Microsoft PowerPoint.  
1. Добавить пустой слайд в презентацию.  
1. Добавить 3‑D сгруппированный столбчатый график и получить к нему доступ.  
1. Создать новый экземпляр книги Microsoft Excel и загрузить данные диаграммы.  
1. Получить доступ к листу данных диаграммы через экземпляр книги Microsoft Excel.  
1. Установить диапазон данных в листе и удалить серии 2 и 3 из диаграммы.  
1. Изменить категории данных диаграммы в листе данных.  
1. Изменить данные серии 1 в листе данных.  
1. Получить доступ к заголовку диаграммы и задать свойства шрифта.  
1. Получить доступ к оси значений диаграммы и задать основной и вспомогательный шаги, максимальное и минимальное значение.  
1. Получить доступ к оси глубины (или оси серии) и удалить её, поскольку в этом примере используется только одна серия.  
1. Задать углы вращения диаграммы по осям X и Y.  
1. Сохранить презентацию.  
1. Закрыть экземпляры Microsoft Excel и PowerPoint.  

``` csharp

 //Global Variables

public static Microsoft.Office.Interop.PowerPoint.Application objPPT;

public static Microsoft.Office.Interop.PowerPoint.Presentation objPres;

private void ThisAddIn_Startup(object sender, System.EventArgs e)

{

	GEN_VSTO_Chart();

}

public static void GEN_VSTO_Chart()

{


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

	objPres.SaveAs("VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

	//Close Workbook and presentation

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
## **Aspose.Slides**
При работе с Aspose.Slides for .NET выполняются следующие шаги:

1. Создать экземпляр презентации Microsoft PowerPoint.  
1. Добавить пустой слайд в презентацию.  
1. Добавить 3‑D сгруппированный столбчатый график и получить к нему доступ.  
1. Получить доступ к листу данных диаграммы через экземпляр книги Microsoft Excel.  
1. Удалить неиспользуемые серии 2 и 3.  
1. Получить доступ к категориям диаграммы и изменить подписи.  
1. Получить доступ к серии 1 и изменить её значения.  
1. Получить доступ к заголовку диаграммы и задать свойства шрифта.  
1. Получить доступ к оси значений диаграммы и задать основной и вспомогательный шаги, максимальное и минимальное значение.  
1. Задать углы вращения диаграммы по осям X и Y.  
1. Сохранить презентацию в формате PPTX.  

``` csharp

 public static void GEN_ASPOSE_Chart()

{

	//Create empty presentation

	using (PresentationEx pres = new PresentationEx())

	{

		//Accessing first slide

		SlideEx slide = pres.Slides[0];

		//Addding default chart

		ChartEx ppChart = slide.Shapes.AddChart(ChartTypeEx.ClusteredColumn3D, 20F, 30F, 400F, 300F);

		//Getting Chart data

		ChartDataEx chartData = ppChart.ChartData;

		//Removing Extra default series

		chartData.Series.RemoveAt(1);

		chartData.Series.RemoveAt(1);

		//Modifying chart categories names

		chartData.Categories[0].ChartDataCell.Value = "Bikes";

		chartData.Categories[1].ChartDataCell.Value = "Accessories";

		chartData.Categories[2].ChartDataCell.Value = "Repairs";

		chartData.Categories[3].ChartDataCell.Value = "Clothing";

		//Modifying chart series values for first category

		chartData.Series[0].Values[0].Value = 1000;

		chartData.Series[0].Values[1].Value = 2500;

		chartData.Series[0].Values[2].Value = 4000;

		chartData.Series[0].Values[3].Value = 3000;

		//Setting Chart title

		ppChart.HasTitle = true;

		ppChart.ChartTitle.Text.Text = "2007 Sales";

		PortionFormatEx format = ppChart.ChartTitle.Text.Paragraphs[0].Portions[0].PortionFormat;

		format.FontItalic = NullableBool.True;

		format.FontHeight = 18;

		format.FillFormat.FillType = FillTypeEx.Solid;

		format.FillFormat.SolidFillColor.Color = Color.Black;


		//Setting Axis values

		ppChart.ValueAxis.IsAutomaticMaxValue = false;

		ppChart.ValueAxis.IsAutomaticMinValue = false;

		ppChart.ValueAxis.IsAutomaticMajorUnit = false;

		ppChart.ValueAxis.IsAutomaticMinorUnit = false;

		ppChart.ValueAxis.MaxValue = 4000.0F;

		ppChart.ValueAxis.MinValue = 0.0F;

		ppChart.ValueAxis.MajorUnit = 2000.0F;

		ppChart.ValueAxis.MinorUnit = 1000.0F;

		ppChart.ValueAxis.TickLabelPosition = TickLabelPositionType.NextTo;

		//Setting Chart rotation

		ppChart.Rotation3D.RotationX = 15;

		ppChart.Rotation3D.RotationY = 20;

		//Saving Presentation

		pres.Write("AsposeSampleChart.pptx");

	}

}
``` 
## **Скачать пример кода**
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart/)