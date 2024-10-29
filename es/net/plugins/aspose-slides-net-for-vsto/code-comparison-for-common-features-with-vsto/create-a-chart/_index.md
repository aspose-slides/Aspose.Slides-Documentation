---
title: Crear un Gráfico
type: docs
weight: 60
url: /es/net/create-a-chart/
---

Los ejemplos de código a continuación describen el proceso de agregar un gráfico de columnas agrupadas en 3D simple utilizando VSTO. Creas una instancia de presentación, le agregas un gráfico predeterminado. Luego, utilizas Microsoft Excel Workbook para acceder y modificar los datos del gráfico junto con la configuración de las propiedades del gráfico. Por último, guarda la presentación.
## **VSTO**
Usando VSTO, se realizan los siguientes pasos:

1. Crea una instancia de una presentación de Microsoft PowerPoint.
1. Agrega una diapositiva en blanco a la presentación.
1. Agrega un gráfico de columnas agrupadas en 3D y accede a él.
1. Crea una nueva instancia de Microsoft Excel Workbook y carga los datos del gráfico.
1. Accede a la hoja de datos del gráfico utilizando la instancia de Microsoft Excel Workbook desde el libro de trabajo.
1. Establece el rango del gráfico en la hoja de trabajo y elimina las series 2 y 3 del gráfico.
1. Modifica los datos de categoría del gráfico en la hoja de datos del gráfico.
1. Modifica los datos de la serie 1 en la hoja de datos del gráfico.
1. Ahora, accede al título del gráfico y establece las propiedades relacionadas con la fuente.
1. Accede al eje de valores del gráfico y establece la unidad mayor, las unidades menores, el valor máximo y el valor mínimo.
1. Accede al eje de profundidad o de series del gráfico y elimínalo, ya que en este ejemplo solo se utiliza una serie.
1. Ahora, establece los ángulos de rotación del gráfico en dirección X y Y.
1. Guarda la presentación.
1. Cierra las instancias de Microsoft Excel y PowerPoint.

``` csharp

 //Variables Globales

public static Microsoft.Office.Interop.PowerPoint.Application objPPT;

public static Microsoft.Office.Interop.PowerPoint.Presentation objPres;

private void ThisAddIn_Startup(object sender, System.EventArgs e)

{

	GEN_VSTO_Chart();

}

public static void GEN_VSTO_Chart()

{


	EnsurePowerPointIsRunning(true, true);

	//Instanciar objeto diapositiva

	Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

	//Acceder a la primera diapositiva de la presentación

	objSlide = objPres.Slides[1];

	//Seleccionar primera diapositiva y establecer su diseño

	objSlide.Select();

	objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

	//Agregar un gráfico predeterminado en la diapositiva

	objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20F, 30F, 400F, 300F);

	//Acceder al gráfico agregado

	Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

	//Acceder a los datos del gráfico

	Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

	//Crear instancia para trabajar con los datos del gráfico

	Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

	//Accediendo a la hoja de datos para el gráfico

	Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

	//Estableciendo el rango del gráfico

	Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

	//Aplicando el rango establecido a la tabla de datos del gráfico

	Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];

	tbl1.Resize(tRange);

	//Estableciendo valores para categorías y datos de series respectivas

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bicicletas";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accesorios";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Reparaciones";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Ropa";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

	//Estableciendo el título del gráfico

	ppChart.ChartTitle.Font.Italic = true;

	ppChart.ChartTitle.Text = "Ventas 2007";

	ppChart.ChartTitle.Font.Size = 18;

	ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();

	ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;

	ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

	//Accediendo al eje de valores del gráfico

	Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	//Estableciendo unidades de valores del eje

	valaxis.MajorUnit = 2000.0F;

	valaxis.MinorUnit = 1000.0F;

	valaxis.MinimumScale = 0.0F;

	valaxis.MaximumScale = 4000.0F;

	//Accediendo al eje de profundidad del gráfico

	Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	Depthaxis.Delete();

	//Estableciendo la rotación del gráfico

	ppChart.Rotation = 20; //Valor Y

	ppChart.Elevation = 15; //Valor X

	ppChart.RightAngleAxes = false;

	// Guardar la presentación como PPTX

	objPres.SaveAs("VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

	//Cerrar Workbook y presentación

	dataWorkbook.Application.Quit();

	objPres.Application.Quit();

}

//Métodos suplementarios

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

	//Intente acceder a la propiedad del nombre. Si causa una excepción entonces

	//inicie una nueva instancia de PowerPoint

	try

	{

		strName = objPPT.Name;

	}

	catch (Exception ex)

	{

		StartPowerPoint();

	}

	//

	//blnAddPresentation se usa para asegurarse de que hay una presentación cargada

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

	//BlnAddSlide se usa para asegurarse de que haya al menos una diapositiva en la

	//presentación

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
Usando Aspose.Slides para .NET, se realizan los siguientes pasos:

1. Crea una instancia de una presentación de Microsoft PowerPoint.
1. Agrega una diapositiva en blanco a la presentación.
1. Agrega un gráfico de columnas agrupadas en 3D y accede a él.
1. Accede a la hoja de datos del gráfico utilizando una instancia de Microsoft Excel Workbook desde el libro de trabajo.
1. Elimina las series 2 y 3 no utilizadas.
1. Accede a las categorías del gráfico y modifica las etiquetas.
1. Accede a la serie 1 y modifica los valores de la serie.
1. Ahora, accede al título del gráfico y establece las propiedades de la fuente.
1. Accede al eje de valores del gráfico y establece la unidad mayor, las unidades menores, el valor máximo y el valor mínimo.
1. Ahora, establece los ángulos de rotación del gráfico en dirección X y Y.
1. Guarda la presentación en formato PPTX.

``` csharp

 public static void GEN_ASPOSE_Chart()

{

	//Crear presentación vacía

	using (PresentationEx pres = new PresentationEx())

	{

		//Accediendo a la primera diapositiva

		SlideEx slide = pres.Slides[0];

		//Agregando gráfico predeterminado

		ChartEx ppChart = slide.Shapes.AddChart(ChartTypeEx.ClusteredColumn3D, 20F, 30F, 400F, 300F);

		//Obteniendo datos del gráfico

		ChartDataEx chartData = ppChart.ChartData;

		//Eliminando series extra predeterminadas

		chartData.Series.RemoveAt(1);

		chartData.Series.RemoveAt(1);

		//Modificando nombres de categorías del gráfico

		chartData.Categories[0].ChartDataCell.Value = "Bicicletas";

		chartData.Categories[1].ChartDataCell.Value = "Accesorios";

		chartData.Categories[2].ChartDataCell.Value = "Reparaciones";

		chartData.Categories[3].ChartDataCell.Value = "Ropa";

		//Modificando los valores de la serie del primer categoría

		chartData.Series[0].Values[0].Value = 1000;

		chartData.Series[0].Values[1].Value = 2500;

		chartData.Series[0].Values[2].Value = 4000;

		chartData.Series[0].Values[3].Value = 3000;

		//Estableciendo título del gráfico

		ppChart.HasTitle = true;

		ppChart.ChartTitle.Text.Text = "Ventas 2007";

		PortionFormatEx format = ppChart.ChartTitle.Text.Paragraphs[0].Portions[0].PortionFormat;

		format.FontItalic = NullableBool.True;

		format.FontHeight = 18;

		format.FillFormat.FillType = FillTypeEx.Solid;

		format.FillFormat.SolidFillColor.Color = Color.Black;


		//Estableciendo valores del eje

		ppChart.ValueAxis.IsAutomaticMaxValue = false;

		ppChart.ValueAxis.IsAutomaticMinValue = false;

		ppChart.ValueAxis.IsAutomaticMajorUnit = false;

		ppChart.ValueAxis.IsAutomaticMinorUnit = false;

		ppChart.ValueAxis.MaxValue = 4000.0F;

		ppChart.ValueAxis.MinValue = 0.0F;

		ppChart.ValueAxis.MajorUnit = 2000.0F;

		ppChart.ValueAxis.MinorUnit = 1000.0F;

		ppChart.ValueAxis.TickLabelPosition = TickLabelPositionType.NextTo;

		//Estableciendo rotación del gráfico

		ppChart.Rotation3D.RotationX = 15;

		ppChart.Rotation3D.RotationY = 20;

		//Guardando presentación

		pres.Write("AsposeSampleChart.pptx");

	}

``` 
## **Descargar Código de Ejemplo**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772948)
- [Github](https://github.com/asposemarketplace/Aspose_for_VSTO/releases/download/3/Create.a.Chart.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Create%20a%20Chart%20\(Aspose.Slides\).zip)