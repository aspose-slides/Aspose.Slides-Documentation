---
title: Gérer les étiquettes de données de graphique dans les présentations avec С++
linktitle: Étiquette de données
type: docs
url: /fr/cpp/chart-data-label/
keywords:
- graphique
- étiquette de données
- précision des données
- pourcentage
- distance de l'étiquette
- position de l'étiquette
- PowerPoint
- présentation
- С++
- Aspose.Slides
description: "Apprenez à ajouter et à formater les étiquettes de données de graphique dans les présentations PowerPoint en utilisant Aspose.Slides pour С++ afin de créer des diapositives plus attrayantes."
---

Les étiquettes de données d’un graphique affichent des détails sur les séries de données du graphique ou sur des points de données individuels. Elles permettent aux lecteurs d’identifier rapidement les séries de données et facilitent également la compréhension des graphiques.

## **Définir la précision des données dans les étiquettes de graphique**

Ce code C++ montre comment définir la précision des données dans une étiquette de graphique :
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

	// Enregistre le fichier de présentation sur le disque
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Afficher les pourcentages comme étiquettes**

Aspose.Slides for C++ vous permet de définir des étiquettes de pourcentage sur les graphiques affichés. Ce code C++ illustre l’opération :
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

	// Enregistre la présentation contenant le graphique
	presentation->Save(outPath, Aspise::Slides::Export::SaveFormat::Pptx);
```


## **Définir le signe de pourcentage avec les étiquettes de données du graphique**

Ce code C++ montre comment définir le signe de pourcentage pour une étiquette de données de graphique :
```c++
	// Le chemin vers le répertoire des documents.
	const String outPath = u"../out/DataLabelsPercentageSign_out.pptx";

	// Crée une instance de la classe Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Obtient la référence d'une diapositive par son indice
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Crée le graphique PercentsStackedColumn sur une diapositive
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// Définit NumberFormatLinkedToSource sur false
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource ( false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// Définit l'index de la feuille de données du graphique
	int defaultWorksheetIndex = 0;

	// Obtient la feuille de calcul des données du graphique
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Supprime les séries générées par défaut 
	chart->get_ChartData()->get_Series()->Clear();
	

	// Ajoute une nouvelle série
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());


	// Prend la première série du graphique
	SharedPtr<IChartSeries> series=chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Red")), chart->get_Type());
	// Remplit les données de la série
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(0.80)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(0.65)));

	// Définit la couleur de remplissage pour la série
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// Définit les propriétés de LabelFormat
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource ( false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat (u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight ( 10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Prend la deuxième série du graphique
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Blues")), chart->get_Type());
	// Remplit les données de la série
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(0.70)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(0.50)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(0.20)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 2, ObjectExt::Box<double>(0.35)));

	// Définit la couleur de remplissage pour la série
	series2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// Définit les propriétés de LabelFormat
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Enregistre le fichier de présentation sur le disque
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Définir la distance de l’étiquette par rapport à l’axe**

Ce code C++ montre comment définir la distance de l’étiquette par rapport à un axe de catégorie lorsque vous travaillez avec un graphique tracé à partir d’axes :
```c++
	// Le chemin vers le répertoire des documents
	const String outPath = u"../out/CategoryAxisLabelDistance_out.pptx";

	// Crée une instance de la classe Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Obtient une référence à une diapositive
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Crée un graphique sur la diapositive
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// Obtient la collection des séries du graphique
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// Définit la distance de l'étiquette par rapport à un axe
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset ( 500);

	// Enregistre le fichier de présentation sur le disque
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Ajuster la position de l’étiquette**

Lorsque vous créez un graphique qui ne repose sur aucun axe, comme un diagramme circulaire, les étiquettes de données du graphique peuvent se retrouver trop proches de son bord. Dans ce cas, vous devez ajuster la position de l’étiquette afin que les lignes de liaison s’affichent clairement.

Ce code C++ montre comment ajuster la position de l’étiquette sur un diagramme circulaire :
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

## **FAQ**

**Comment éviter que les étiquettes de données se chevauchent sur des graphiques denses ?**

Combinez le placement automatique des étiquettes, les lignes de liaison et une taille de police réduite ; si nécessaire, masquez certains champs (par exemple, la catégorie) ou n’affichez les étiquettes que pour les points extrêmes/clé.

**Comment désactiver les étiquettes uniquement pour les valeurs zéro, négatives ou vides ?**

Filtrez les points de données avant d’activer les étiquettes et désactivez l’affichage pour les valeurs égales à 0, les valeurs négatives ou les valeurs manquantes selon une règle définie.

**Comment garantir un style d’étiquette cohérent lors de l’exportation vers PDF/images ?**

Définissez explicitement les polices (famille, taille) et vérifiez que la police est disponible du côté du rendu pour éviter le recours à une police de secours.