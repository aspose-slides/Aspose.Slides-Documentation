---
title: Étiquette de Données du Graphique
type: docs
url: /cpp/chart-data-label/
keywords: "Étiquette de données du graphique, distance de l'étiquette, C++, CPP, Aspose.Slides pour C++"
description: "Définir l'étiquette de données du graphique PowerPoint et la distance en C++"
---

Les étiquettes de données sur un graphique montrent des détails sur les séries de données du graphique ou des points de données individuels. Elles permettent aux lecteurs d'identifier rapidement les séries de données et rendent également les graphiques plus faciles à comprendre.

## **Définir la Précision des Données dans l'Étiquette de Données du Graphique**

Ce code C++ vous montre comment définir la précision des données dans une étiquette de données de graphique :

```c++
	// Le chemin vers le répertoire des documents
	const String outPath = u"../out/SettingPrecisionOfDataLabel_out.pptx";

	// Instancie une classe Presentation qui représente un fichier PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Obtient la première diapositive
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Ajoute un graphique avec des données par défaut
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Line, 0, 0, 500, 500);

	// Définit le format numérique de la série
	chart->set_HasDataTable( true);
	chart->get_ChartData()->get_Series()->idx_get(0)->set_NumberFormatOfValues (u"#,##0.00");

	// Écrit le fichier de présentation sur le disque
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Afficher des Pourcentages en tant qu'Étiquettes**
Aspose.Slides pour C++ vous permet de définir des étiquettes de pourcentage sur des graphiques affichés. Ce code C++ démontre l'opération :

```c++
	// Le chemin vers le répertoire des documents
	const String outPath = u"../out/DisplayPercentageAsLabels_out.pptx";

	// Crée une instance de la classe Presentation
	System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

	System::SharedPtr<ISlide> slide = presentation->get_Slides()->idx_get(0);
	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::StackedColumn, 20, 20, 400, 400);
	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);
	System::SharedPtr<IChartCategory> cat;
	System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(chart->get_ChartData()->get_Categories()->get_Count(), 0);
	for (int32_t k = 0; k < chart->get_ChartData()->get_Categories()->get_Count(); k++)
	{
		cat = chart->get_ChartData()->get_Categories()->idx_get(k);

		for (int32_t i = 0; i < chart->get_ChartData()->get_Series()->get_Count(); i++)
		{
			total_for_Cat[k] = total_for_Cat[k] + System::Convert::ToDouble(chart->get_ChartData()->get_Series()->idx_get(i)->get_DataPoints()->idx_get(k)->get_Value()->get_Data());
		}
	}

	double dataPontPercent = 0.f;

	for (int32_t x = 0; x < chart->get_ChartData()->get_Series()->get_Count(); x++)
	{
		series = chart->get_ChartData()->get_Series()->idx_get(x);
		series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLegendKey(false);

		for (int32_t j = 0; j < series->get_DataPoints()->get_Count(); j++)
		{
			System::SharedPtr<IDataLabel> lbl = series->get_DataPoints()->idx_get(j)->get_Label();
			dataPontPercent = (System::Convert::ToDouble(series->get_DataPoints()->idx_get(j)->get_Value()->get_Data()) / total_for_Cat[j]) * 100;

			System::SharedPtr<IPortion> port = System::MakeObject<Portion>();
			port->set_Text(System::String::Format(u"{0:F2} %", dataPontPercent));
			port->get_PortionFormat()->set_FontHeight(8.f);
			lbl->get_TextFrameForOverriding()->set_Text(u"");
			System::SharedPtr<IParagraph> para = lbl->get_TextFrameForOverriding()->get_Paragraphs()->idx_get(0);
			para->get_Portions()->Add(port);

			lbl->get_DataLabelFormat()->set_ShowSeriesName(false);
			lbl->get_DataLabelFormat()->set_ShowPercentage(false);
			lbl->get_DataLabelFormat()->set_ShowLegendKey(false);
			lbl->get_DataLabelFormat()->set_ShowCategoryName(false);
			lbl->get_DataLabelFormat()->set_ShowBubbleSize(false);

		}

	}

	// Sauvegarde la présentation contenant le graphique
	presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Définir le Signe de Pourcentage avec l'Étiquette de Données du Graphique**
Ce code C++ vous montre comment définir le signe de pourcentage pour une étiquette de données de graphique :

```c++
	// Le chemin vers le répertoire des documents.
	const String outPath = u"../out/DataLabelsPercentageSign_out.pptx";

	// Crée une instance de la classe Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Obtient la référence d'une diapositive par son index
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Crée le graphique PercentsStackedColumn sur une diapositive
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// Définit le NumberFormatLinkedToSource sur false
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource ( false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// Définit l'index de la feuille de données du graphique
	int defaultWorksheetIndex = 0;

	// Obtient la feuille de calcul des données du graphique
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Supprime les séries générées par défaut 
	chart->get_ChartData()->get_Series()->Clear();
	

	// Ajoute une nouvelle série
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Série 2")), chart->get_Type());


	// Prend la première série de graphique
	SharedPtr<IChartSeries> series=chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Rouge")), chart->get_Type());
	// Remplit les données de la série
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(0.80)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(0.65)));

	// Définit la couleur de remplissage pour la série
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// Définit les propriétés LabelFormat
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource ( false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat (u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight ( 10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Prend la deuxième série de graphique
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Bleus")), chart->get_Type());
	// Remplit les données de la série
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(0.70)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(0.50)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(0.20)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 2, ObjectExt::Box<double>(0.35)));

	// Définit la couleur de remplissage pour la série
	series2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// Définit les propriétés LabelFormat
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Écrit le fichier de présentation sur le disque
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```


## **Définir la Distance de l'Étiquette par Rapport à l'Axe**
Ce code C++ vous montre comment définir la distance de l'étiquette par rapport à un axe de catégorie lorsque vous travaillez avec un graphique tracé à partir des axes :

```c++
	// Le chemin vers le répertoire des documents
	const String outPath = u"../out/CategoryAxisLabelDistance_out.pptx";

	// Crée une instance de la classe Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Obtient la référence d'une diapositive
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Crée un graphique sur la diapositive
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// Obtient la collection de séries de graphique
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// Définit la distance de l'étiquette par rapport à un axe
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset ( 500);

	// Écrit le fichier de présentation sur le disque
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ajuster l'Emplacement de l'Étiquette**

Lorsque vous créez un graphique qui ne dépend d'aucun axe, comme un graphique circulaire, les étiquettes de données du graphique peuvent se retrouver trop près de son bord. Dans ce cas, vous devez ajuster l'emplacement de l'étiquette de données afin que les lignes de direction soient affichées clairement.

Ce code C++ vous montre comment ajuster l'emplacement de l'étiquette sur un graphique circulaire :

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<IChart> chart = pres->get_Slide(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 200.0f, 200.0f);

System::SharedPtr<IChartSeriesCollection> series = chart->get_ChartData()->get_Series();
System::SharedPtr<IDataLabel> label = series->idx_get(0)->get_Label(0);
System::SharedPtr<IDataLabelFormat> dataLabelFormat = label->get_DataLabelFormat();

dataLabelFormat->set_ShowValue(true);
dataLabelFormat->set_Position(LegendDataLabelPosition::OutsideEnd);
label->set_X(0.71f);
label->set_Y(0.04f);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)