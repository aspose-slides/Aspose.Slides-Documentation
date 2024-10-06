---
title: Créer des graphiques de présentation PowerPoint en C++
linktitle: Créer un graphique
type: docs
weight: 10
url: /cpp/create-chart/
keywords: "Créer un graphique, graphique éparpillé, graphique à secteurs, graphique en arborescence, graphique boursier, graphique à moustaches, graphique histogramme, graphique en entonnoir, graphique en soleil, graphique multicatégorie, présentation PowerPoint, C++, CPP, Aspose.Slides pour C++"
description: "Créer un graphique dans une présentation PowerPoint en C++"
---

## **Créer un graphique**

Les graphiques aident les gens à visualiser rapidement les données et à tirer des conclusions qui ne sont pas immédiatement évidentes à partir d'un tableau ou d'une feuille de calcul.

**Pourquoi créer des graphiques ?**

Avec des graphiques, vous pouvez

* agréger, condenser ou résumer de grandes quantités de données sur une seule diapositive d'une présentation
* exposer des modèles et des tendances dans les données
* déduire la direction et l'élan des données au fil du temps ou par rapport à une unité de mesure spécifique
* repérer les valeurs aberrantes, les aberrations, les écarts, les erreurs, les données absurdes, etc.
* communiquer ou présenter des données complexes

Dans PowerPoint, vous pouvez créer des graphiques grâce à la fonction d'insertion, qui fournit des modèles utilisés pour concevoir de nombreux types de graphiques. En utilisant Aspose.Slides, vous pouvez créer des graphiques réguliers (basés sur des types de graphiques populaires) et des graphiques personnalisés.

{{% alert color="primary" %}} 

Pour vous permettre de créer des graphiques, Aspose.Slides fournit la classe énumérée [ChartType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.charts#a23ba9ea390f5be4c8f5ab18baf4f8c05) sous l'espace de noms [Aspose::Slides::Charts](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.charts/). Les valeurs de cette classe énumérée correspondent à différents types de graphiques.

{{% /alert %}} 

### **Créer des graphiques normaux**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtenez la référence d'une diapositive à partir de son index.
1. Ajoutez un graphique avec des données et spécifiez votre type de graphique préféré. 
1. Ajoutez un titre pour le graphique. 
1. Accédez à la feuille de données du graphique.
1. Effacez toutes les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Ajoutez des données de graphique pour les séries de graphique.
1. Ajoutez une couleur de remplissage pour les séries de graphique.
1. Ajoutez des étiquettes pour les séries de graphique. 
1. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ vous montre comment créer un graphique normal :

```c++
// Le chemin vers le répertoire des documents.
	const String outPath = u"../out/NormalCharts_out.pptx";

	//Instancie une classe de présentation qui représente un fichier PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Accède à la première diapositive
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Ajoute un graphique avec des données par défaut
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// Définit l'index de la feuille de données du graphique
	int defaultWorksheetIndex = 0;

	// Obtient la feuille de données du graphique
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// Définit le titre du graphique
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Titre d'exemple");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText ( NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle( true);

	// Supprime les séries et catégories par défaut générées
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();
	int s = chart->get_ChartData()->get_Series()->get_Count();
	s = chart->get_ChartData()->get_Categories()->get_Count();


	// Ajoute une nouvelle série
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Série 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Série 2")), chart->get_Type());

	// Ajoute des catégories
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"Catégorie 1")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"Catégorie 2")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"Catégorie 3")));

	
	// Prend la première série de graphiques
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// Remplit les données de la série
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(30)));

	// Définit la couleur de remplissage pour la série
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());


	// Prend la deuxième série de graphiques
	 series = chart->get_ChartData()->get_Series()->idx_get(1);

	// Remplit les données de la série
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(30)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(10)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(60)));

	// Définit la couleur de remplissage pour la série
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Green());


	// La première étiquette est définie pour montrer le nom de la catégorie
	SharedPtr<IDataLabel> lbl = series->get_DataPoints()->idx_get(0)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowCategoryName(true);

	lbl = series->get_DataPoints()->idx_get(1)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowSeriesName (true);

	// Affiche la valeur pour la troisième étiquette
	lbl = series->get_DataPoints()->idx_get(2)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowValue (true);
	lbl->get_DataLabelFormat()->set_ShowSeriesName(true);
	lbl->get_DataLabelFormat()->set_Separator (u"/");

	// Enregistre la présentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

### **Créer des graphiques éparpillés**
Les graphiques éparpillés (également connus sous le nom de graphiques éparpillés ou graphiques en x-y) sont souvent utilisés pour vérifier des modèles ou démontrer des corrélations entre deux variables. 

Vous pouvez vouloir utiliser un graphique éparpillé lorsque 

* vous avez des données numériques appariées
* vous avez 2 variables qui s'apparentent bien
* vous souhaitez déterminer si 2 variables sont liées
* vous avez une variable indépendante qui a plusieurs valeurs pour une variable dépendante

Ce code C++ vous montre comment créer des graphiques éparpillés avec une série différente de marqueurs : 

```c++
// Le chemin vers le répertoire des documents.
	const String outPath = u"../out/ScatteredChart_out.pptx";

	//Instancie une classe de présentation qui représente un fichier PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Accède à la première diapositive
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Ajoute un graphique avec des données par défaut
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ScatterWithSmoothLines, 0, 0, 500, 500);

	// Définit le titre du graphique
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Titre d'exemple");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// Supprime les séries par défaut générées 
	chart->get_ChartData()->get_Series()->Clear();
	
	// Définit l'index de la feuille de données du graphique
	int defaultWorksheetIndex = 0;

	// Obtient la feuille de données du graphique
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Ajoute une nouvelle série
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Série 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 3, ObjectExt::Box<System::String>(u"Série 2")), chart->get_Type());

	// Prend la première série de graphiques
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// Ajoute un nouveau point (1:3)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(1)), fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(3)));

	// Ajoute un nouveau point (2:10)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(10)));

	// Modifie le type de série
	series->set_Type (ChartType::ScatterWithStraightLinesAndMarkers);

	// Change le marqueur de la série de graphiques
	series->get_Marker()->set_Size  (10);
	series->get_Marker()->set_Symbol(MarkerStyleType::Star);



	// Prend la deuxième série de graphiques
	series  = chart->get_ChartData()->get_Series()->idx_get(1);

	// Ajoute un nouveau point (5:2)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 2, 4, ObjectExt::Box<double>(2)));

	// Ajoute un nouveau point (3:1)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, ObjectExt::Box<double>(3)), fact->GetCell(defaultWorksheetIndex, 3, 4, ObjectExt::Box<double>(1)));

	// Ajoute un nouveau point (2:2)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 4, 3, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 4, 4, ObjectExt::Box<double>(2)));

	// Ajoute un nouveau point (5:1)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 5, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 5, 4, ObjectExt::Box<double>(1)));

	// Change le marqueur de la série de graphiques
	series->get_Marker()->set_Size ( 10);
	series->get_Marker()->set_Symbol(MarkerStyleType::Circle);



	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_IsColorVaried(true);

	SharedPtr<IChartDataPoint> point = series->get_DataPoints()->idx_get(0);
	point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Cyan());
	// Définit la bordure du secteur
	point->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
	point->get_Format()->get_Line()->set_Width ( 3.0);
	point->get_Format()->get_Line()->set_Style(LineStyle::ThinThick);
	point->get_Format()->get_Line()->set_DashStyle(LineDashStyle::DashDot);

	SharedPtr<IChartDataPoint> point1 = series->get_DataPoints()->idx_get(1);
	point1->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Brown());

	// Définit la bordure du secteur
	point1->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
	point1->get_Format()->get_Line()->set_Width (3.0);
	point1->get_Format()->get_Line()->set_Style(LineStyle::Single);
	point1->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDot);


	SharedPtr<IChartDataPoint> point2 = series->get_DataPoints()->idx_get(2);
	point2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Coral());

	// Définit la bordure du secteur
	point2->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
	point2->get_Format()->get_Line()->set_Width (2.0);
	point2->get_Format()->get_Line()->set_Style(LineStyle::ThickThin);
	point2->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDotDot);


	// Crée les étiquettes personnalisées pour chaque catégorie de la nouvelle série
	SharedPtr<IDataLabel> lbl1 = series->get_DataPoints()->idx_get(0)->get_Label();

	// lbl.ShowCategoryName = true;
	lbl1->get_DataLabelFormat()->set_ShowValue(true);


	SharedPtr<IDataLabel> lbl2 = series->get_DataPoints()->idx_get(1)->get_Label();
	lbl2->get_DataLabelFormat()->set_ShowValue(true);
	lbl2->get_DataLabelFormat()->set_ShowLegendKey(true);
	lbl2->get_DataLabelFormat()->set_ShowPercentage(true);

	SharedPtr<IDataLabel> lbl3 = series->get_DataPoints()->idx_get(2)->get_Label();

	lbl3->get_DataLabelFormat()->set_ShowSeriesName(true);
	lbl3->get_DataLabelFormat()->set_ShowPercentage(true);

	// Affiche les lignes de leader pour le graphique
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines(true);

	// Définit l'angle de rotation pour les secteurs de graphique à secteurs
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle(180);


	// Enregistre la présentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Créer des graphiques à secteurs**
Les graphiques à secteurs sont mieux utilisés pour montrer la relation entre la partie et le tout dans les données, en particulier lorsque les données contiennent des étiquettes catégorielles avec des valeurs numériques. Cependant, si vos données contiennent de nombreuses parties ou étiquettes, vous pouvez envisager d'utiliser un graphique à barres à la place. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtenez la référence d'une diapositive à partir de son index.
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (dans ce cas, `ChartType.Pie`).
1. Accédez à la feuille de données IChartDataWorkbook du graphique.
1. Effacez les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Ajoutez de nouvelles données de graphique pour les séries de graphique.
1. Ajoutez de nouveaux points pour les graphiques et ajoutez des couleurs personnalisées pour les secteurs du graphique à secteurs.
1. Définissez des étiquettes pour les séries.
1. Définissez des lignes de leader pour les étiquettes des séries.
1. Définissez l'angle de rotation pour les secteurs de graphique à secteurs.
1. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ vous montre comment créer un graphique à secteurs :

```c++
	// Le chemin vers le répertoire des documents.
	const String outPath = u"../out/PieChart_out.pptx";

	//Instancie une classe de présentation qui représente un fichier PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Accède à la première diapositive
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Ajoute un graphique avec des données par défaut
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Pie, 0, 0, 500, 500);

	// Définit le titre du graphique
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Titre d'exemple");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// Supprime les séries et catégories par défaut générées
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// Définit l'index de la feuille de données du graphique
	int defaultWorksheetIndex = 0;

	// Obtient la feuille de données du graphique
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// Ajoute des catégories
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"Premier Trimestre")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"Deuxième Trimestre")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"Troisième Trimestre")));

	// Ajoute une nouvelle série
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Série 1")), chart->get_Type());
	
	// Prend la première série de graphiques
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// Remplit les données de la série
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(30)));

	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_IsColorVaried(true);

	SharedPtr<IChartDataPoint> point = series->get_DataPoints()->idx_get(0);
	point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Cyan());
	// Définit la bordure du secteur
	point->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
	point->get_Format()->get_Line()->set_Width ( 3.0);
	point->get_Format()->get_Line()->set_Style(LineStyle::ThinThick);
	point->get_Format()->get_Line()->set_DashStyle(LineDashStyle::DashDot);

	SharedPtr<IChartDataPoint> point1 = series->get_DataPoints()->idx_get(1);
	point1->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Brown());

	// Définit la bordure du secteur
	point1->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
	point1->get_Format()->get_Line()->set_Width (3.0);
	point1->get_Format()->get_Line()->set_Style(LineStyle::Single);
	point1->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDot);


	SharedPtr<IChartDataPoint> point2 = series->get_DataPoints()->idx_get(2);
	point2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Coral());

	// Définit la bordure du secteur
	point2->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
	point2->get_Format()->get_Line()->set_Width (2.0);
	point2->get_Format()->get_Line()->set_Style(LineStyle::ThickThin);
	point2->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDotDot);


	// Crée des étiquettes personnalisées pour chaque catégorie pour la nouvelle série
	SharedPtr<IDataLabel> lbl1 = series->get_DataPoints()->idx_get(0)->get_Label();

	// lbl.ShowCategoryName = true;
	lbl1->get_DataLabelFormat()->set_ShowValue(true);


	SharedPtr<IDataLabel> lbl2 = series->get_DataPoints()->idx_get(1)->get_Label();
	lbl2->get_DataLabelFormat()->set_ShowValue(true);
	lbl2->get_DataLabelFormat()->set_ShowLegendKey(true);
	lbl2->get_DataLabelFormat()->set_ShowPercentage(true);

	SharedPtr<IDataLabel> lbl3 = series->get_DataPoints()->idx_get(2)->get_Label();

	lbl3->get_DataLabelFormat()->set_ShowSeriesName(true);
	lbl3->get_DataLabelFormat()->set_ShowPercentage(true);

	// Définit les lignes de leader pour le graphique
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines ( true);

	// Définit l'angle de rotation pour les secteurs du graphique à secteurs
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle ( 180);


	// Enregistre la présentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Créer des graphiques linéaires**

Les graphiques linéaires (également appelés graphiques linéaires) sont mieux utilisés dans les situations où vous souhaitez démontrer les changements de valeur au fil du temps. En utilisant un graphique linéaire, vous pouvez comparer de nombreuses données à la fois, suivre les changements et les tendances au fil du temps, mettre en évidence les anomalies dans les séries de données, etc.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtenez la référence d'une diapositive à partir de son index.
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (dans ce cas, `ChartType::Line`).
1. Accédez à la feuille de données IChartDataWorkbook du graphique.
1. Effacez les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Ajoutez de nouvelles données de graphique pour les séries de graphique.
1. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ vous montre comment créer un graphique linéaire :

```c++
auto pres = System::MakeObject<Presentation>();

System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
pres->Save(u"lineChart.pptx", SaveFormat::Pptx);
```

Par défaut, les points sur un graphique linéaire sont reliés par des lignes droites continues. Si vous voulez que les points soient reliés par des tirets à la place, vous pouvez spécifier votre type de tiret préféré de cette manière :

```c++
System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
for (auto&& series : lineChart->get_ChartData()->get_Series())
{
    series->get_Format()->get_Line()->set_DashStyle(LineDashStyle::Dash);
}
```

### **Créer des graphiques de carte**

Un graphique de carte est une visualisation d'une zone contenant des données. Les graphiques de carte sont mieux utilisés pour comparer des données ou des valeurs à travers des régions géographiques.

Ce code C++ vous montre comment créer un graphique de carte :

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Map, 50.0f, 50.0f, 500.0f, 400.0f);
pres->Save(u"mapChart.pptx", SaveFormat::Pptx);
```

### **Mettre à jour des graphiques**

1. Instanciez une classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) qui représente la présentation contenant le graphique.
2. Obtenez la référence d'une diapositive à partir de son index.
3. Parcourez toutes les formes pour trouver le graphique souhaité.
4. Accédez à la feuille de données du graphique.
5. Modifiez les données de série de graphique en changeant les valeurs des séries.
6. Ajoutez une nouvelle série et remplissez les données dans celle-ci.
7. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ vous montre comment mettre à jour un graphique :

```c++
// Instancie une classe Presentation qui représente un fichier PPTX
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"ExistingChart.pptx");

// Accède à la première diapositive et ajoute un graphique avec des données par défaut
System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Ajoute un graphique avec des données par défaut
System::SharedPtr<IChart> chart = System::ExplicitCast<Aspose::Slides::Charts::IChart>(sld->get_Shapes()->idx_get(0));

// Définit l'index pour la feuille de données du graphique
int32_t defaultWorksheetIndex = 0;

// Obtient la feuille de données du graphique
System::SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


// Change le nom de la catégorie du graphique
fact->GetCell(defaultWorksheetIndex, 1, 0, System::ObjectExt::Box<System::String>(u"Catégorie modifiée 1"));
fact->GetCell(defaultWorksheetIndex, 2, 0, System::ObjectExt::Box<System::String>(u"Catégorie modifiée 2"));

// Prend la première série de graphiques
System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

// Met à jour les données de la série
fact->GetCell(defaultWorksheetIndex, 0, 1, System::ObjectExt::Box<System::String>(u"Nouveau_Série1"));
// Modification du nom de la série
series->get_DataPoints()->idx_get(0)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(90));
series->get_DataPoints()->idx_get(1)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(123));
series->get_DataPoints()->idx_get(2)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(44));

// Prend la deuxième série de graphiques
series = chart->get_ChartData()->get_Series()->idx_get(1);

// Met maintenant à jour les données de la série
fact->GetCell(defaultWorksheetIndex, 0, 2, System::ObjectExt::Box<System::String>(u"Nouveau_Série2"));
// Modification du nom de la série
series->get_DataPoints()->idx_get(0)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(23));
series->get_DataPoints()->idx_get(1)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(67));
series->get_DataPoints()->idx_get(2)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(99));


// Maintenant, ajoutons une nouvelle série
chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 3, System::ObjectExt::Box<System::String>(u"Série 3")), chart->get_Type());

// Prend la 3ème série de graphiques
series = chart->get_ChartData()->get_Series()->idx_get(2);

// Maintenant, en remplissant les données de la série
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 3, System::ObjectExt::Box<int32_t>(20)));
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, System::ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, System::ObjectExt::Box<int32_t>(30)));

chart->set_Type(Aspose::Slides::Charts::ChartType::ClusteredCylinder);

// Enregistre la présentation avec le graphique
pres->Save(u"AsposeChartModified_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Configurer la plage de données pour les graphiques**

1. Ouvrez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) contenant le graphique.
2. Obtenez la référence d'une diapositive à partir de son index.
3. Parcourez toutes les formes pour trouver le graphique souhaité.
4. Accédez aux données du graphique et définissez la plage.
5. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ vous montre comment définir la plage de données pour un graphique :

```cpp
// Le chemin vers le répertoire des documents.
String dataDir = GetDataPath();

// Instancie une classe Presentation qui représente un fichier PPTX
auto presentation = System::MakeObject<Presentation>(dataDir + u"ExistingChart.pptx");

// Accède à la première diapositive et ajoute un graphique avec des données par défaut
auto slide = presentation->get_Slides()->idx_get(0);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
chart->get_ChartData()->SetRange(u"Sheet1!A1:B4");
presentation->Save(dataDir + u"SetDataRange_out.pptx", SaveFormat::Pptx);
```

### **Utiliser des marqueurs par défaut dans les graphiques**
Lorsque vous utilisez un marqueur par défaut dans les graphiques, chaque série de graphiques reçoit automatiquement des symboles de marqueur différents par défaut.

Ce code C++ vous montre comment définir un marqueur de série de graphique automatiquement :

```cpp
// Le chemin vers le répertoire des documents.
String dataDir = GetDataPath();

auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::LineWithMarkers, 10.0f, 10.0f, 400.0f, 400.0f);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();
chart->get_ChartData()->get_Series()->Add(wb->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Série 1")), chart->get_Type());
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 1, 0, ObjectExt::Box<String>(u"C1")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 1, 1, ObjectExt::Box<int32_t>(24)));
chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 2, 0, ObjectExt::Box<String>(u"C2")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 2, 1, ObjectExt::Box<int32_t>(23)));
chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 3, 0, ObjectExt::Box<String>(u"C3")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 3, 1, ObjectExt::Box<int32_t>(-10)));
chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 4, 0, ObjectExt::Box<String>(u"C4")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 4, 1, nullptr));

chart->get_ChartData()->get_Series()->Add(wb->GetCell(0, 0, 2, ObjectExt::Box<String>(u"Série 2")), chart->get_Type());

// Prend la deuxième série de graphiques
auto series2 = chart->get_ChartData()->get_Series()->idx_get(1);

// Remplit les données de la série
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 1, 2, ObjectExt::Box<int32_t>(30)));
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 2, 2, ObjectExt::Box<int32_t>(10)));
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 3, 2, ObjectExt::Box<int32_t>(60)));
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 4, 2, ObjectExt::Box<int32_t>(40)));

chart->set_HasLegend(true);
chart->get_Legend()->set_Overlay(false);

pres->Save(dataDir + u"DefaultMarkersInChart.pptx", SaveFormat::Pptx);
```
