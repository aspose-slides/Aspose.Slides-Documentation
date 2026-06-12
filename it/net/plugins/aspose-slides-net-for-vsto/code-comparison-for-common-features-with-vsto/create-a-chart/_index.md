---
title: Crea un grafico
type: docs
weight: 60
url: /it/net/create-a-chart/
---
Gli esempi di codice seguenti descrivono il processo di aggiunta di un semplice diagramma a colonne raggruppate 3D usando VSTO. Si crea un'istanza di presentazione, si aggiunge un diagramma predefinito. Poi si utilizza la cartella di lavoro di Microsoft Excel per accedere e modificare i dati del diagramma insieme all'impostazione delle proprietà del diagramma. Infine, si salva la presentazione.
## **VSTO**
Utilizzando VSTO, vengono eseguiti i seguenti passaggi:

1. Crea un'istanza di una presentazione Microsoft PowerPoint.
1. Aggiungi una diapositiva vuota alla presentazione.
1. Aggiungi un diagramma a colonne raggruppate 3D e accedilo.
1. Crea una nuova istanza di Microsoft Excel Workbook e carica i dati del diagramma.
1. Accedi al foglio di lavoro dei dati del diagramma utilizzando l'istanza di Microsoft Excel Workbook.
1. Imposta l'intervallo del diagramma nel foglio di lavoro e rimuovi le serie 2 e 3 dal diagramma.
1. Modifica i dati delle categorie del diagramma nel foglio di lavoro dei dati.
1. Modifica i dati della serie 1 del diagramma nel foglio di lavoro dei dati.
1. Ora, accedi al titolo del diagramma e imposta le proprietà relative al carattere.
1. Accedi all'asse dei valori del diagramma e imposta l'unità principale, le unità minori, il valore massimo e i valori minimi.
1. Accedi alla profondità del diagramma o all'asse delle serie e rimuovilo poiché in questo esempio viene utilizzata una sola serie.
1. Ora, imposta gli angoli di rotazione del diagramma nelle direzioni X e Y.
1. Salva la presentazione.
1. Chiudi le istanze di Microsoft Excel e PowerPoint.

``` csharp

 //Variabili globali

public static Microsoft.Office.Interop.PowerPoint.Application objPPT;

public static Microsoft.Office.Interop.PowerPoint.Presentation objPres;

private void ThisAddIn_Startup(object sender, System.EventArgs e)

{

	GEN_VSTO_Chart();

}

public static void GEN_VSTO_Chart()

{


	EnsurePowerPointIsRunning(true, true);

	//Instanziare oggetto slide

	Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

	//Accedere alla prima diapositiva della presentazione

	objSlide = objPres.Slides[1];

	//Seleziona la prima diapositiva e imposta il suo layout

	objSlide.Select();

	objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

	//Aggiungere un diagramma predefinito nella diapositiva

	objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20F, 30F, 400F, 300F);

	//Accedere al diagramma aggiunto

	Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

	//Accedere ai dati del diagramma

	Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

	//Creare un'istanza della cartella di lavoro Excel per lavorare con i dati del diagramma

	Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

	//Accesso al foglio di lavoro dei dati per il diagramma

	Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

	//Impostare l'intervallo del diagramma

	Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

	//Applicare l'intervallo impostato alla tabella dei dati del diagramma

	Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];

	tbl1.Resize(tRange);

	//Impostare i valori per le categorie e i dati delle rispettive serie

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

	//Impostare il titolo del diagramma

	ppChart.ChartTitle.Font.Italic = true;

	ppChart.ChartTitle.Text = "2007 Sales";

	ppChart.ChartTitle.Font.Size = 18;

	ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();

	ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;

	ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

	//Accesso all'asse dei valori del diagramma

	Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	//Impostare le unità dell'asse dei valori

	valaxis.MajorUnit = 2000.0F;

	valaxis.MinorUnit = 1000.0F;

	valaxis.MinimumScale = 0.0F;

	valaxis.MaximumScale = 4000.0F;

	//Accesso all'asse di profondità del diagramma

	Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	Depthaxis.Delete();

	//Impostare la rotazione del diagramma

	ppChart.Rotation = 20; //Valore-Y

	ppChart.Elevation = 15; //Valore-X

	ppChart.RightAngleAxes = false;

	// Salvare la presentazione in formato PPTX

	objPres.SaveAs("VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

	//Chiudere la cartella di lavoro e la presentazione

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

	//Prova ad accedere alla proprietà Name. Se genera un'eccezione allora

	//avvia una nuova istanza di PowerPoint

	try

	{

		strName = objPPT.Name;

	}

	catch (Exception ex)

	{

		StartPowerPoint();

	}

	//

	//blnAddPresentation è usato per garantire che una presentazione sia caricata

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

	//BlnAddSlide è usato per garantire che ci sia almeno una diapositiva nella

	//presentazione

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
Utilizzando Aspose.Slides per .NET, vengono eseguiti i seguenti passaggi:

1. Crea un'istanza di una presentazione Microsoft PowerPoint.
1. Aggiungi una diapositiva vuota alla presentazione.
1. Aggiungi un diagramma a colonne raggruppate 3D e accedilo.
1. Accedi al foglio di lavoro dei dati del diagramma utilizzando un'istanza di Microsoft Excel Workbook.
1. Rimuovi le serie 2 e 3 non utilizzate.
1. Accedi alle categorie del diagramma e modifica le etichette.
1. Accedi alla serie 1 e modifica i valori della serie.
1. Ora, accedi al titolo del diagramma e imposta le proprietà del carattere.
1. Accedi all'asse dei valori del diagramma e imposta l'unità principale, le unità minori, il valore massimo e i valori minimi.
1. Ora, imposta gli angoli di rotazione del diagramma nelle direzioni X e Y.
1. Salva la presentazione in formato PPTX.

``` csharp

 public static void GEN_ASPOSE_Chart()
{
	//Crea una presentazione vuota
	using (PresentationEx pres = new PresentationEx())
	{
		//Accedi alla prima diapositiva
		SlideEx slide = pres.Slides[0];
		//Aggiunta del diagramma predefinito
		ChartEx ppChart = slide.Shapes.AddChart(ChartTypeEx.ClusteredColumn3D, 20F, 30F, 400F, 300F);
		//Ottenere i dati del diagramma
		ChartDataEx chartData = ppChart.ChartData;
		//Rimuovere le serie predefinite extra
		chartData.Series.RemoveAt(1);
		chartData.Series.RemoveAt(1);
		//Modifica i nomi delle categorie del diagramma
		chartData.Categories[0].ChartDataCell.Value = "Bikes";
		chartData.Categories[1].ChartDataCell.Value = "Accessories";
		chartData.Categories[2].ChartDataCell.Value = "Repairs";
		chartData.Categories[3].ChartDataCell.Value = "Clothing";
		//Modifica i valori delle serie del diagramma per la prima categoria
		chartData.Series[0].Values[0].Value = 1000;
		chartData.Series[0].Values[1].Value = 2500;
		chartData.Series[0].Values[2].Value = 4000;
		chartData.Series[0].Values[3].Value = 3000;
		//Impostazione del titolo del diagramma
		ppChart.HasTitle = true;
		ppChart.ChartTitle.Text.Text = "2007 Sales";
		PortionFormatEx format = ppChart.ChartTitle.Text.Paragraphs[0].Portions[0].PortionFormat;
		format.FontItalic = NullableBool.True;
		format.FontHeight = 18;
		format.FillFormat.FillType = FillTypeEx.Solid;
		format.FillFormat.SolidFillColor.Color = Color.Black;

		//Impostazione dei valori dell'asse
		ppChart.ValueAxis.IsAutomaticMaxValue = false;
		ppChart.ValueAxis.IsAutomaticMinValue = false;
		ppChart.ValueAxis.IsAutomaticMajorUnit = false;
		ppChart.ValueAxis.IsAutomaticMinorUnit = false;
		ppChart.ValueAxis.MaxValue = 4000.0F;
		ppChart.ValueAxis.MinValue = 0.0F;
		ppChart.ValueAxis.MajorUnit = 2000.0F;
		ppChart.ValueAxis.MinorUnit = 1000.0F;
		ppChart.ValueAxis.TickLabelPosition = TickLabelPositionType.NextTo;
		//Impostazione della rotazione del diagramma
		ppChart.Rotation3D.RotationX = 15;
		ppChart.Rotation3D.RotationY = 20;
		//Salvataggio della presentazione
		pres.Write("AsposeSampleChart.pptx");
	}
}
``` 
## **Download Sample Code**
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart/)