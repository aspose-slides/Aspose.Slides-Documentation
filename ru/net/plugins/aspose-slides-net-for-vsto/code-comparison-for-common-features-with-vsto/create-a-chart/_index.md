---
title: Создать график
type: docs
weight: 60
url: /ru/net/create-a-chart/
---

Примеры кода ниже описывают процесс добавления простого 3D столбчатого графика с помощью VSTO. Вы создаете экземпляр презентации, добавляете к нему стандартный график. Затем используете книгу Microsoft Excel для доступа и изменения данных графика, а также для установки свойств графика. Наконец, сохраняете презентацию.
## **VSTO**
Используя VSTO, выполняются следующие шаги:

1. Создайте экземпляр презентации Microsoft PowerPoint.
1. Добавьте пустой слайд в презентацию.
1. Добавьте 3D столбчатый график и получите к нему доступ.
1. Создайте новый экземпляр книги Microsoft Excel и загрузите данные графика.
1. Получите доступ к рабочему листу данных графика с использованием экземпляра книги Microsoft Excel.
1. Установите диапазон графика на рабочем листе и удалите серии 2 и 3 из графика.
1. Измените данные категории графика на рабочем листе данных графика.
1. Измените данные серии 1 на рабочем листе данных графика.
1. Теперь получите доступ к заголовку графика и задайте свойства, связанные со шрифтом.
1. Получите доступ к оси значений графика и установите большие единицы, малые единицы, максимальное и минимальное значения.
1. Получите доступ к глубине графика или оси серии и удалите ее, так как в этом примере используется только одна серия.
1. Теперь установите углы поворота графика в направлениях X и Y.
1. Сохраните презентацию.
1. Закройте экземпляры Microsoft Excel и PowerPoint.

``` csharp

 //Глобальные переменные

public static Microsoft.Office.Interop.PowerPoint.Application objPPT;

public static Microsoft.Office.Interop.PowerPoint.Presentation objPres;

private void ThisAddIn_Startup(object sender, System.EventArgs e)

{

	GEN_VSTO_Chart();

}

public static void GEN_VSTO_Chart()

{


	EnsurePowerPointIsRunning(true, true);

	//Создание объекта слайда

	Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

	//Получение доступа к первому слайду презентации

	objSlide = objPres.Slides[1];

	//Выбор первого слайда и установка его макета

	objSlide.Select();

	objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

	//Добавление стандартного графика на слайд

	objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20F, 30F, 400F, 300F);

	//Получение доступа к добавленному графику

	Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

	//Получение доступа к данным графика

	Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

	//Создание экземпляра книги Excel для работы с данными графика

	Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

	//Получение доступа к рабочему листу данных графика

	Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

	//Установка диапазона графика

	Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

	//Применение установленного диапазона к таблице данных графика

	Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];

	tbl1.Resize(tRange);

	//Установка значений для категорий и соответствующих данных серии

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Велосипеды";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Аксессуары";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Ремонт";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Одежда";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

	//Установка заголовка графика

	ppChart.ChartTitle.Font.Italic = true;

	ppChart.ChartTitle.Text = "Продажи 2007 года";

	ppChart.ChartTitle.Font.Size = 18;

	ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();

	ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;

	ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

	//Получение доступа к оси значений графика

	Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	//Установка единиц оси значений

	valaxis.MajorUnit = 2000.0F;

	valaxis.MinorUnit = 1000.0F;

	valaxis.MinimumScale = 0.0F;

	valaxis.MaximumScale = 4000.0F;

	//Получение доступа к оси глубины графика

	Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	Depthaxis.Delete();

	//Установка поворота графика

	ppChart.Rotation = 20; //Y-значение

	ppChart.Elevation = 15; //X-значение

	ppChart.RightAngleAxes = false;

	// Сохранение презентации как PPTX

	objPres.SaveAs("VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

	//Закрытие книги и презентации

	dataWorkbook.Application.Quit();

	objPres.Application.Quit();

}

//Дополнительные методы

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

	//Попытка доступа к свойству имени. Если вызовет исключение, то

	//запустите новый экземпляр PowerPoint

	try

	{

		strName = objPPT.Name;

	}

	catch (Exception ex)

	{

		StartPowerPoint();

	}

	//

	//blnAddPresentation используется для обеспечения наличия загруженной презентации

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

	//BlnAddSlide используется для обеспечения наличия хотя бы одного слайда в

	//презентации

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

``` 
## **Aspose.Slides**
Используя Aspose.Slides для .NET, выполняются следующие шаги:

1. Создайте экземпляр презентации Microsoft PowerPoint.
1. Добавьте пустой слайд в презентацию.
1. Добавьте 3D столбчатый график и получите к нему доступ.
1. Получите доступ к рабочему листу данных графика с использованием экземпляра книги Microsoft Excel.
1. Удалите неиспользуемые серии 2 и 3.
1. Получите доступ к категориям графика и измените метки.
1. Получите доступ к серии 1 и измените значения серии.
1. Теперь получите доступ к заголовку графика и задайте свойства шрифта.
1. Получите доступ к оси значений графика и установите большие единицы, малые единицы, максимальное и минимальное значения.
1. Теперь установите углы поворота графика в направлениях X и Y.
1. Сохраните презентацию в формате PPTX.

``` csharp

 public static void GEN_ASPOSE_Chart()

{

	//Создание пустой презентации

	using (PresentationEx pres = new PresentationEx())

	{

		//Получение доступа к первому слайду

		SlideEx slide = pres.Slides[0];

		//Добавление стандартного графика

		ChartEx ppChart = slide.Shapes.AddChart(ChartTypeEx.ClusteredColumn3D, 20F, 30F, 400F, 300F);

		//Получение данных графика

		ChartDataEx chartData = ppChart.ChartData;

		//Удаление лишних стандартных серий

		chartData.Series.RemoveAt(1);

		chartData.Series.RemoveAt(1);

		//Изменение названий категорий графика

		chartData.Categories[0].ChartDataCell.Value = "Велосипеды";

		chartData.Categories[1].ChartDataCell.Value = "Аксессуары";

		chartData.Categories[2].ChartDataCell.Value = "Ремонт";

		chartData.Categories[3].ChartDataCell.Value = "Одежда";

		//Изменение значений серий графика для первой категории

		chartData.Series[0].Values[0].Value = 1000;

		chartData.Series[0].Values[1].Value = 2500;

		chartData.Series[0].Values[2].Value = 4000;

		chartData.Series[0].Values[3].Value = 3000;

		//Установка заголовка графика

		ppChart.HasTitle = true;

		ppChart.ChartTitle.Text.Text = "Продажи 2007 года";

		PortionFormatEx format = ppChart.ChartTitle.Text.Paragraphs[0].Portions[0].PortionFormat;

		format.FontItalic = NullableBool.True;

		format.FontHeight = 18;

		format.FillFormat.FillType = FillTypeEx.Solid;

		format.FillFormat.SolidFillColor.Color = Color.Black;


		//Установка значений оси

		ppChart.ValueAxis.IsAutomaticMaxValue = false;

		ppChart.ValueAxis.IsAutomaticMinValue = false;

		ppChart.ValueAxis.IsAutomaticMajorUnit = false;

		ppChart.ValueAxis.IsAutomaticMinorUnit = false;

		ppChart.ValueAxis.MaxValue = 4000.0F;

		ppChart.ValueAxis.MinValue = 0.0F;

		ppChart.ValueAxis.MajorUnit = 2000.0F;

		ppChart.ValueAxis.MinorUnit = 1000.0F;

		ppChart.ValueAxis.TickLabelPosition = TickLabelPositionType.NextTo;

		//Установка поворота графика

		ppChart.Rotation3D.RotationX = 15;

		ppChart.Rotation3D.RotationY = 20;

		//Сохранение презентации

		pres.Write("AsposeSampleChart.pptx");

	}

``` 
## **Скачать пример кода**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772948)
- [Github](https://github.com/asposemarketplace/Aspose_for_VSTO/releases/download/3/Create.a.Chart.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Create%20a%20Chart%20\(Aspose.Slides\).zip)