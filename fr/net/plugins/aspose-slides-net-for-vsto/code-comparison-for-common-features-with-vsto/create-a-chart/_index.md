---
title: Créer un Graphique
type: docs
weight: 60
url: /net/create-a-chart/
---

Les exemples de code ci-dessous décrivent le processus d'ajout d'un graphique en colonnes groupées 3D simple à l'aide de VSTO. Vous créez une instance de présentation, y ajoutez un graphique par défaut. Ensuite, utilisez le classeur Microsoft Excel pour accéder et modifier les données du graphique ainsi que pour définir les propriétés du graphique. Enfin, enregistrez la présentation.
## **VSTO**
En utilisant VSTO, les étapes suivantes sont réalisées :

1. Créer une instance d'une présentation Microsoft PowerPoint.
1. Ajouter une diapositive vierge à la présentation.
1. Ajouter un graphique en colonnes groupées 3D et y accéder.
1. Créer une nouvelle instance de classeur Microsoft Excel et charger les données du graphique.
1. Accéder à la feuille de calcul des données du graphique à l'aide de l'instance du classeur Microsoft Excel.
1. Définir la plage du graphique dans la feuille de calcul et supprimer les séries 2 et 3 du graphique.
1. Modifier les données de catégorie du graphique dans la feuille de calcul des données du graphique.
1. Modifier les données de la série 1 dans la feuille de calcul des données du graphique.
1. Maintenant, accéder au titre du graphique et définir les propriétés liées à la police.
1. Accéder à l'axe des valeurs du graphique et définir l'unité principale, les unités mineures, la valeur maximale et la valeur minimale.
1. Accéder à la profondeur du graphique ou à l'axe des séries et le supprimer car dans cet exemple, seule une série est utilisée.
1. Maintenant, définir les angles de rotation du graphique dans les directions X et Y.
1. Enregistrer la présentation.
1. Fermer les instances de Microsoft Excel et PowerPoint.

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

	//Instancier l'objet diapositive

	Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

	//Accéder à la première diapositive de la présentation

	objSlide = objPres.Slides[1];

	//Sélectionner la première diapositive et définir sa mise en page

	objSlide.Select();

	objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

	//Ajouter un graphique par défaut à la diapositive

	objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20F, 30F, 400F, 300F);

	//Accéder au graphique ajouté

	Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

	//Accéder aux données du graphique

	Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

	//Créer une instance de classeur Excel pour travailler avec les données du graphique

	Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

	//Accéder à la feuille de calcul des données pour le graphique

	Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

	//Définir la plage du graphique

	Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

	//Appliquer la plage définie sur le tableau de données du graphique

	Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];

	tbl1.Resize(tRange);

	//Définir les valeurs pour les catégories et les données respectives des séries

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Vélos";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessoires";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Réparations";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Vêtements";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

	//Définir le titre du graphique

	ppChart.ChartTitle.Font.Italic = true;

	ppChart.ChartTitle.Text = "Ventes 2007";

	ppChart.ChartTitle.Font.Size = 18;

	ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();

	ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;

	ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

	//Accéder à l'axe des valeurs du graphique

	Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	//Définir les unités de l'axe des valeurs

	valaxis.MajorUnit = 2000.0F;

	valaxis.MinorUnit = 1000.0F;

	valaxis.MinimumScale = 0.0F;

	valaxis.MaximumScale = 4000.0F;

	//Accéder à l'axe de profondeur du graphique

	Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	Depthaxis.Delete();

	//Définir la rotation du graphique

	ppChart.Rotation = 20; //Valeur Y

	ppChart.Elevation = 15; //Valeur X

	ppChart.RightAngleAxes = false;

	// Enregistrer la présentation au format PPTX

	objPres.SaveAs("VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

	//Fermer le classeur et la présentation

	dataWorkbook.Application.Quit();

	objPres.Application.Quit();

}

//Méthodes supplémentaires

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

	//Essayez d'accéder à la propriété de nom. Si cela provoque une exception alors

	//commencez une nouvelle instance de PowerPoint

	try

	{

		strName = objPPT.Name;

	}

	catch (Exception ex)

	{

		StartPowerPoint();

	}

	//

	//blnAddPresentation est utilisé pour s'assurer qu'il y a une présentation chargée

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

	//BlnAddSlide est utilisé pour s'assurer qu'il y a au moins une diapositive dans la

	//présentation

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
En utilisant Aspose.Slides pour .NET, les étapes suivantes sont réalisées :

1. Créer une instance d'une présentation Microsoft PowerPoint.
1. Ajouter une diapositive vierge à la présentation.
1. Ajouter un graphique en colonnes groupées 3D et y accéder.
1. Accéder à la feuille de calcul des données du graphique à l'aide d'une instance de classeur Microsoft Excel.
1. Supprimer les séries inutilisées 2 et 3.
1. Accéder aux catégories de graphiques et modifier les étiquettes.
1. Accéder à la série 1 et modifier les valeurs de la série.
1. Maintenant, accéder au titre du graphique et définir les propriétés de la police.
1. Accéder à l'axe des valeurs du graphique et définir l'unité principale, les unités mineures, la valeur maximale et la valeur minimale.
1. Maintenant, définir les angles de rotation du graphique dans les directions X et Y.
1. Enregistrer la présentation au format PPTX.

``` csharp

 public static void GEN_ASPOSE_Chart()

{

	//Créer une présentation vide

	using (PresentationEx pres = new PresentationEx())

	{

		//Accéder à la première diapositive

		SlideEx slide = pres.Slides[0];

		//Ajouter un graphique par défaut

		ChartEx ppChart = slide.Shapes.AddChart(ChartTypeEx.ClusteredColumn3D, 20F, 30F, 400F, 300F);

		//Obtenir les données du graphique

		ChartDataEx chartData = ppChart.ChartData;

		//Supprimer les séries supplémentaires par défaut

		chartData.Series.RemoveAt(1);

		chartData.Series.RemoveAt(1);

		//Modifier les noms des catégories de graphique

		chartData.Categories[0].ChartDataCell.Value = "Vélos";

		chartData.Categories[1].ChartDataCell.Value = "Accessoires";

		chartData.Categories[2].ChartDataCell.Value = "Réparations";

		chartData.Categories[3].ChartDataCell.Value = "Vêtements";

		//Modifier les valeurs de la série de graphique pour la première catégorie

		chartData.Series[0].Values[0].Value = 1000;

		chartData.Series[0].Values[1].Value = 2500;

		chartData.Series[0].Values[2].Value = 4000;

		chartData.Series[0].Values[3].Value = 3000;

		//Définir le titre du graphique

		ppChart.HasTitle = true;

		ppChart.ChartTitle.Text.Text = "Ventes 2007";

		PortionFormatEx format = ppChart.ChartTitle.Text.Paragraphs[0].Portions[0].PortionFormat;

		format.FontItalic = NullableBool.True;

		format.FontHeight = 18;

		format.FillFormat.FillType = FillTypeEx.Solid;

		format.FillFormat.SolidFillColor.Color = Color.Black;


		//Définir les valeurs des axes

		ppChart.ValueAxis.IsAutomaticMaxValue = false;

		ppChart.ValueAxis.IsAutomaticMinValue = false;

		ppChart.ValueAxis.IsAutomaticMajorUnit = false;

		ppChart.ValueAxis.IsAutomaticMinorUnit = false;

		ppChart.ValueAxis.MaxValue = 4000.0F;

		ppChart.ValueAxis.MinValue = 0.0F;

		ppChart.ValueAxis.MajorUnit = 2000.0F;

		ppChart.ValueAxis.MinorUnit = 1000.0F;

		ppChart.ValueAxis.TickLabelPosition = TickLabelPositionType.NextTo;

		//Définir la rotation du graphique

		ppChart.Rotation3D.RotationX = 15;

		ppChart.Rotation3D.RotationY = 20;

		//Enregistrer la présentation

		pres.Write("AsposeSampleChart.pptx");

	}

``` 
## **Télécharger le Code Exemple**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772948)
- [Github](https://github.com/asposemarketplace/Aspose_for_VSTO/releases/download/3/Create.a.Chart.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Create%20a%20Chart%20\(Aspose.Slides\).zip)