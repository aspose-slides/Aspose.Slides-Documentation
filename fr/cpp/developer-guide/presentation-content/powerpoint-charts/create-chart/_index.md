---
title: Créer ou mettre à jour des graphiques de présentation PowerPoint en С++
linktitle: Créer ou mettre à jour des graphiques
type: docs
weight: 10
url: /fr/cpp/create-chart/
keywords:
- ajouter un graphique
- créer un graphique
- modifier un graphique
- changer un graphique
- mettre à jour un graphique
- graphique dispersé
- graphique circulaire
- graphique linéaire
- graphique en carte arborescente
- graphique boursier
- graphique boîte à moustaches
- graphique en entonnoir
- graphique Sunburst
- graphique histogramme
- graphique radar
- graphique multi-catégories
- PowerPoint
- présentation
- С++
- Aspose.Slides
description: "Créer et personnaliser des graphiques dans les présentations PowerPoint à l’aide d’Aspose.Slides pour С++. Ajouter, mettre en forme et modifier des graphiques avec des exemples de code pratiques en С++."
---

## **Créer un graphique**

Les graphiques aident les personnes à visualiser rapidement les données et à obtenir des insights, ce qui peut ne pas être immédiatement évident à partir d’un tableau ou d’une feuille de calcul. 

**Pourquoi créer des graphiques ?**

Utiliser des graphiques, vous pouvez

* agréger, condenser ou résumer de grandes quantités de données sur une seule diapositive d’une présentation
* exposer les motifs et les tendances dans les données
* déduire la direction et l’élan des données au fil du temps ou par rapport à une unité de mesure spécifique 
* détecter les valeurs aberrantes, les anomalies, les écarts, les erreurs, les données incohérentes, etc. 
* communiquer ou présenter des données complexes

Dans PowerPoint, vous pouvez créer des graphiques via la fonction d’insertion, qui fournit des modèles utilisés pour concevoir de nombreux types de graphiques. Avec Aspose.Slides, vous pouvez créer des graphiques standards (basés sur des types de graphiques populaires) et des graphiques personnalisés. 

{{% alert color="primary" %}} 

Pour vous permettre de créer des graphiques, Aspose.Slides fournit la classe d’énumération [ChartType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.charts#a23ba9ea390f5be4c8f5ab18baf4f8c05) sous l’espace de noms [Aspose::Slides::Charts](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.charts/). Les valeurs de cette classe d’énumération correspondent à différents types de graphiques. 

{{% /alert %}} 

### **Créer des graphiques normaux**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtenez une référence à une diapositive via son index.
1. Ajoutez un graphique avec des données et spécifiez le type de graphique souhaité. 
1. Ajoutez un titre au graphique. 
1. Accédez à la feuille de calcul des données du graphique.
1. Effacez toutes les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Ajoutez de nouvelles données de graphique pour les séries du graphique.
1. Ajoutez une couleur de remplissage pour les séries du graphique.
1. Ajoutez des étiquettes pour les séries du graphique. 
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ montre comment créer un graphique normal :
```c++
// Le chemin du répertoire des documents.
	const String outPath = u"../out/NormalCharts_out.pptx";

	//Instancie une classe de présentation qui représente un fichier PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Accède à la première diapositive
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Ajoute un graphique avec des données par défaut
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// Définir l'index de la feuille de données du graphique
	int defaultWorksheetIndex = 0;

	// Obtient la feuille de calcul des données du graphique
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// Définir le titre du graphique
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText ( NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle( true);

	// Supprime les séries et catégories générées par défaut
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();
	int s = chart->get_ChartData()->get_Series()->get_Count();
	s = chart->get_ChartData()->get_Categories()->get_Count();


	// Ajoute une nouvelle série
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());

	// Ajoute les catégories
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"Caetegoty 1")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"Caetegoty 2")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"Caetegoty 3")));

	
	// Prend la première série du graphique
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// Remplit les données de la série
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(30)));

	// Définir la couleur de remplissage pour la série
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());


	// Prend la deuxième série du graphique
	 series = chart->get_ChartData()->get_Series()->idx_get(1);

	// Remplit les données de la série
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(30)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(10)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(60)));

	// Définir la couleur de remplissage pour la série
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Green());


	// Le premier libellé est défini pour afficher le nom de la catégorie
	SharedPtr<IDataLabel> lbl = series->get_DataPoints()->idx_get(0)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowCategoryName(true);

	lbl = series->get_DataPoints()->idx_get(1)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowSeriesName (true);

	// Affiche la valeur pour le troisième libellé
	lbl = series->get_DataPoints()->idx_get(2)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowValue (true);
	lbl->get_DataLabelFormat()->set_ShowSeriesName(true);
	lbl->get_DataLabelFormat()->set_Separator (u"/");

	// Enregistre la présentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```


### **Créer des graphiques dispersés**
Les graphiques dispersés (également appelés nuages de points ou graphiques x‑y) sont souvent utilisés pour vérifier des motifs ou démontrer des corrélations entre deux variables. 

Vous pourriez vouloir utiliser un graphique dispersé lorsque 

* vous avez des données numériques appariées
* vous avez 2 variables qui se combinent bien
* vous souhaitez déterminer si 2 variables sont liées
* vous avez une variable indépendante qui possède plusieurs valeurs pour une variable dépendante

Ce code C++ montre comment créer des graphiques dispersés avec une série différente de marqueurs :
```c++
// Le chemin du répertoire des documents.
	const String outPath = u"../out/ScatteredChart_out.pptx";

	//Instancie une classe de présentation qui représente un fichier PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Accède à la première diapositive
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Ajoute un graphique avec des données par défaut
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ScatterWithSmoothLines, 0, 0, 500, 500);

	// Définit le titre du graphique
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// Supprime les séries générées par défaut 
	chart->get_ChartData()->get_Series()->Clear();
	
	// Définit l'index de la feuille de données du graphique
	int defaultWorksheetIndex = 0;

	// Obtient la feuille de calcul des données du graphique
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Ajoute une nouvelle série
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 3, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());

	// Prend la première série du graphique
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// Ajoute un nouveau point (1:3)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(1)), fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(3)));

	// Ajoute un nouveau point (2:10)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(10)));

	// Modifie le type de série
	series->set_Type (ChartType::ScatterWithStraightLinesAndMarkers);

	// Modifie le marqueur de la série du graphique
	series->get_Marker()->set_Size  (10);
	series->get_Marker()->set_Symbol(MarkerStyleType::Star);



	// Prend la deuxième série du graphique
	series  = chart->get_ChartData()->get_Series()->idx_get(1);

	// Ajoute un nouveau point (5:2)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 2, 4, ObjectExt::Box<double>(2)));

	// Ajoute un nouveau point (3:1)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, ObjectExt::Box<double>(3)), fact->GetCell(defaultWorksheetIndex, 3, 4, ObjectExt::Box<double>(1)));

	// Ajoute un nouveau point (2:2)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 4, 3, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 4, 4, ObjectExt::Box<double>(2)));

	// Ajoute un nouveau point (5:1)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 5, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 5, 4, ObjectExt::Box<double>(1)));

	// Modifie le marqueur de la série du graphique
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
	point2->get_Format()->get_Line()->set_Width ( 2.0);
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

	// Affiche les lignes de liaison pour le graphique
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines(true);

	// Définit l'angle de rotation pour les secteurs du graphique circulaire
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle(180);


	// Enregistre la présentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


### **Créer des graphiques circulaires**
Les graphiques circulaires sont les mieux adaptés pour montrer la relation partie‑tout dans les données, en particulier lorsque les données contiennent des libellés catégoriels avec des valeurs numériques. Cependant, si vos données contiennent de nombreuses parties ou libellés, vous pourriez envisager d’utiliser un graphique à barres à la place. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtenez une référence à une diapositive via son index.
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (dans ce cas, `ChartType.Pie`).
1. Accédez aux données du graphique IChartDataWorkbook.
1. Effacez les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Ajoutez de nouvelles données de graphique pour les séries du graphique.
1. Ajoutez de nouveaux points pour le graphique et ajoutez des couleurs personnalisées pour les secteurs du graphique circulaire.
1. Définissez les libellés pour les séries.
1. Définissez les lignes de repère pour les libellés des séries.
1. Définissez l’angle de rotation pour les graphiques circulaires.
1. Enregistrez la présentation modifiée dans un fichier PPTX

Ce code C++ montre comment créer un graphique circulaire :
```c++
	// Le chemin du répertoire des documents.
	const String outPath = u"../out/PieChart_out.pptx";

	//Instancie une classe Presentation qui représente un fichier PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Accède à la première diapositive
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Ajoute un graphique avec des données par défaut
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Pie, 0, 0, 500, 500);

	// Définit le titre du graphique
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// Supprime les séries et catégories générées par défaut
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// Définit l'index de la feuille de données du graphique
	int defaultWorksheetIndex = 0;

	// Obtient la feuille de calcul des données du graphique
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// Ajoute des catégories
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"First Qtr")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"2nd Qtr")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"3ed Qtr")));

	// Ajoute une nouvelle série
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
	
	// Prend la première série du graphique
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
	point->get_Format()->get_Line()->set_Style( LineStyle::ThinThick);
	point->get_Format()->get_Line()->set_DashStyle ( LineDashStyle::DashDot);

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


	// Crée des étiquettes personnalisées pour chaque catégorie de la nouvelle série
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

	// Définit la série pour afficher les lignes de liaison du graphique
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines ( true);

	// Définit l'angle de rotation pour les secteurs du graphique circulaire
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle ( 180);


	// Enregistre la présentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


### **Créer des graphiques linéaires**
Les graphiques linéaires (également appelés diagrammes en ligne) sont les mieux adaptés aux situations où vous souhaitez montrer des variations de valeur dans le temps. En utilisant un graphique linéaire, vous pouvez comparer de nombreuses données à la fois, suivre les changements et les tendances dans le temps, mettre en évidence les anomalies dans les séries de données, etc.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtenez une référence à une diapositive via son index.
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (dans ce cas, `ChartType::Line`).
1. Accédez aux données du graphique IChartDataWorkbook.
1. Effacez les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Ajoutez de nouvelles données de graphique pour les séries du graphique.
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ montre comment créer un graphique linéaire :
```c++
auto pres = System::MakeObject<Presentation>();

System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
pres->Save(u"lineChart.pptx", SaveFormat::Pptx);
```


Par défaut, les points d’un graphique linéaire sont reliés par des lignes continues droites. Si vous souhaitez que les points soient reliés par des tirets à la place, vous pouvez spécifier le type de tiret souhaité de cette manière :
```c++
System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
for (auto&& series : lineChart->get_ChartData()->get_Series())
{
    series->get_Format()->get_Line()->set_DashStyle(LineDashStyle::Dash);
}
```


### **Créer des graphiques en carte arborescente**
Les graphiques en carte arborescente sont les mieux adaptés aux données de ventes lorsque vous voulez montrer la taille relative des catégories de données et (en même temps) attirer rapidement l’attention sur les éléments qui contribuent fortement à chaque catégorie. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtenez une référence à une diapositive via son index.
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (dans ce cas, `ChartType.TreeMap`).
1. Accédez aux données du graphique IChartDataWorkbook.
1. Effacez les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Ajoutez de nouvelles données de graphique pour les séries du graphique.
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ montre comment créer un graphique en carte arborescente :
```c++
// Le chemin du répertoire des documents.
	const String outPath = u"../out/TreemapChart_out.pptx";

	//Instancie une classe Presentation qui représente un fichier PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Accède à la première diapositive
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Treemap, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	// Branche 1
	System::SharedPtr<IChartCategory> leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C1", System::ObjectExt::Box<System::String>(u"Leaf1")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem1"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch1"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C2", System::ObjectExt::Box<System::String>(u"Leaf2")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C3", System::ObjectExt::Box<System::String>(u"Leaf3")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C4", System::ObjectExt::Box<System::String>(u"Leaf4")));


	// Branche 2
	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C5", System::ObjectExt::Box<System::String>(u"Leaf5")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem3"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C6", System::ObjectExt::Box<System::String>(u"Leaf6")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C7", System::ObjectExt::Box<System::String>(u"Leaf7")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem4"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C8", System::ObjectExt::Box<System::String>(u"Leaf8")));

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::Treemap);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D1", System::ObjectExt::Box<int32_t>(4)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D2", System::ObjectExt::Box<int32_t>(5)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D3", System::ObjectExt::Box<int32_t>(3)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D4", System::ObjectExt::Box<int32_t>(6)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D5", System::ObjectExt::Box<int32_t>(9)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D6", System::ObjectExt::Box<int32_t>(9)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D7", System::ObjectExt::Box<int32_t>(4)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D8", System::ObjectExt::Box<int32_t>(3)));

	series->set_ParentLabelLayout(Aspose::Slides::Charts::ParentLabelLayoutType::Overlapping);

	// Enregistre la présentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


### **Créer des graphiques boursiers**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtenez une référence à une diapositive via son index.
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (ChartType.OpenHighLowClose).
1. Accédez aux données du graphique IChartDataWorkbook.
1. Effacez les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Ajoutez de nouvelles données de graphique pour les séries du graphique.
1. Spécifiez le format HiLowLines.
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Exemple de code C++ utilisé pour créer un graphique boursier :
```c++
	// Le chemin du répertoire des documents.
	const String outPath = u"../out/AddStockChart_out.pptx";

	//Instancie une classe Presentation qui représente un fichier PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Accède à la première diapositive
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Ajoute un graphique avec des données par défaut
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::OpenHighLowClose, 0, 0, 500, 500);


	// Définit l'index de la feuille de données du graphique
	int defaultWorksheetIndex = 0;

	// Obtient la feuille de calcul des données du graphique
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Supprime les séries et catégories générées par défaut
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// Ajoute des catégories
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"A")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"B")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"C")));

	// Ajoute une nouvelle série
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Open")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"High")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 3, ObjectExt::Box<System::String>(u"Low")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 4, ObjectExt::Box<System::String>(u"Close")), chart->get_Type());


	// Prend la première série du graphique
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);
	// Remplit les données de la première série
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(72)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(25)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(38)));


	series = chart->get_ChartData()->get_Series()->idx_get(1);
	// Remplit les données de la deuxième série
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(172)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(57)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(57)));

	series = chart->get_ChartData()->get_Series()->idx_get(2);
	// Remplit les données de la deuxième série
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 3, ObjectExt::Box<double>(12)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, ObjectExt::Box<double>(12)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, ObjectExt::Box<double>(13)));


	series = chart->get_ChartData()->get_Series()->idx_get(3);
	// Remplit les données de la deuxième série
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 4, ObjectExt::Box<double>(25)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 4, ObjectExt::Box<double>(38)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 4, ObjectExt::Box<double>(50)));

	// Définit le groupe de séries
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->get_UpDownBars()->set_HasUpDownBars (true);
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->get_HiLowLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);


	for(int i=0;i<chart->get_ChartData()->get_Series()->get_Count();i++)
	{
		series = chart->get_ChartData()->get_Series()->idx_get(i);
		series->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
	}

	// Enregistre la présentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


### **Créer des graphiques boîte à moustaches**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtenez une référence à une diapositive via son index.
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (ChartType.BoxAndWhisker).
1. Accédez aux données du graphique IChartDataWorkbook.
1. Effacez les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Ajoutez de nouvelles données de graphique pour les séries du graphique.
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ montre comment créer un graphique boîte à moustaches :
```c++
	// Le chemin du répertoire des documents.
	const String outPath = u"../out/BoxAndWhisker_out.pptx";

	//Instancie une classe Presentation qui représente un fichier PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Accède à la première diapositive
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::BoxAndWhisker, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A1", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A2", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A3", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A4", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A5", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A6", System::ObjectExt::Box<System::String>(u"Category 1")));

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::BoxAndWhisker);

	series->set_QuartileMethod(Aspose::Slides::Charts::QuartileMethodType::Exclusive);
	series->set_ShowMeanLine(true);
	series->set_ShowMeanMarkers(true);
	series->set_ShowInnerPoints(true);
	series->set_ShowOutlierPoints(true);

	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B1", System::ObjectExt::Box<int32_t>(15)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B2", System::ObjectExt::Box<int32_t>(41)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B3", System::ObjectExt::Box<int32_t>(16)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B4", System::ObjectExt::Box<int32_t>(10)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B5", System::ObjectExt::Box<int32_t>(23)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B6", System::ObjectExt::Box<int32_t>(16)));


	// Enregistre la présentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


### **Créer des graphiques en entonnoir**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtenez une référence à une diapositive via son index.
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (ChartType.Funnel).
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ montre comment créer un graphique en entonnoir :
```c++
	// Le chemin du répertoire des documents.
	const String outPath = u"../out/FunnelChart_out.pptx";

	//Instancie une classe Presentation qui représente un fichier PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Accède à la première diapositive
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Funnel, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A1", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A2", System::ObjectExt::Box<System::String>(u"Category 2")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A3", System::ObjectExt::Box<System::String>(u"Category 3")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A4", System::ObjectExt::Box<System::String>(u"Category 4")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A5", System::ObjectExt::Box<System::String>(u"Category 5")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A6", System::ObjectExt::Box<System::String>(u"Category 6")));

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::Funnel);

	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B1", System::ObjectExt::Box<int32_t>(50)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B2", System::ObjectExt::Box<int32_t>(100)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B3", System::ObjectExt::Box<int32_t>(200)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B4", System::ObjectExt::Box<int32_t>(300)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B5", System::ObjectExt::Box<int32_t>(400)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B6", System::ObjectExt::Box<int32_t>(500)));


	// Enregistre la présentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


### **Créer des graphiques Sunburst**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtenez une référence à une diapositive via son index.
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (dans ce cas, `ChartType.sunburst`).
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ montre comment créer un graphique Sunburst :
```c++
	// Le chemin du répertoire des documents.
	const String outPath = u"../out/SunburstChart_out.pptx";

	// Instancie une classe Presentation qui représente un fichier PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Accède à la première diapositive
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart=slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Sunburst, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	// Branche 1
	System::SharedPtr<IChartCategory> leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C1", System::ObjectExt::Box<System::String>(u"Leaf1")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem1"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch1"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C2", System::ObjectExt::Box<System::String>(u"Leaf2")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C3", System::ObjectExt::Box<System::String>(u"Leaf3")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C4", System::ObjectExt::Box<System::String>(u"Leaf4")));

	// Branche 2
	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C5", System::ObjectExt::Box<System::String>(u"Leaf5")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem3"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C6", System::ObjectExt::Box<System::String>(u"Leaf6")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C7", System::ObjectExt::Box<System::String>(u"Leaf7")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem4"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C8", System::ObjectExt::Box<System::String>(u"Leaf8")));

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::Sunburst);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D1", System::ObjectExt::Box<int32_t>(4)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D2", System::ObjectExt::Box<int32_t>(5)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D3", System::ObjectExt::Box<int32_t>(3)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D4", System::ObjectExt::Box<int32_t>(6)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D5", System::ObjectExt::Box<int32_t>(9)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D6", System::ObjectExt::Box<int32_t>(9)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D7", System::ObjectExt::Box<int32_t>(4)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D8", System::ObjectExt::Box<int32_t>(3)));

	// Écrit le fichier de présentation sur le disque
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


### **Créer des graphiques histogramme**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtenez une référence à une diapositive via son index. 
1. Ajoutez un graphique avec des données et spécifiez le type souhaité (`ChartType.Histogram` dans ce cas).
1. Accédez aux données du graphique `IChartDataWorkbook`.
1. Effacez les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ montre comment créer un graphique histogramme :
```c++
	// Le chemin du répertoire des documents.
	const String outPath = u"../out/HistogramChart_out.pptx";

	// Instancie une classe Presentation qui représente un fichier PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Accède à la première diapositive
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Histogram, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::Histogram);
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A1", System::ObjectExt::Box<int32_t>(15)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A2", System::ObjectExt::Box<int32_t>(-41)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A3", System::ObjectExt::Box<int32_t>(16)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A4", System::ObjectExt::Box<int32_t>(10)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A5", System::ObjectExt::Box<int32_t>(-23)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A6", System::ObjectExt::Box<int32_t>(16)));

	chart->get_Axes()->get_HorizontalAxis()->set_AggregationType(Aspose::Slides::Charts::AxisAggregationType::Automatic);

	// Enregistre la présentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


### **Créer des graphiques radar**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtenez une référence à une diapositive via son index. 
1. Ajoutez un graphique avec des données et spécifiez le type souhaité (`ChartType.Radar` dans ce cas).
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ montre comment créer un graphique radar :
```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Radar, 20.0f, 20.0f, 400.0f, 300.0f);
presentation->Save(u"Radar-chart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


### **Créer des graphiques multi‑catégories**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtenez une référence à une diapositive via son index.
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (ChartType.ClusteredColumn).
1. Accédez aux données du graphique IChartDataWorkbook.
1. Effacez les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Ajoutez de nouvelles données de graphique pour les séries du graphique.
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ montre comment créer un graphique multi‑catégories :
```c++
	// Le chemin du répertoire des documents.
	const String outPath = u"../out/MultiCategoryChart_out.pptx";

	// Instancie une classe Presentation qui représente un fichier PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Accède à la première diapositive
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Ajoute un graphique avec des données par défaut
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);

	// Définit l'index de la feuille de données du graphique
	int defaultWorksheetIndex = 0;

	// Obtient la feuille de calcul des données du graphique
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// Efface le classeur
	fact->Clear(defaultWorksheetIndex);

	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();


	// Ajoute des catégories
	SharedPtr<IChartCategory> category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c2", ObjectExt::Box<System::String>(u"A")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"Group1"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c3", ObjectExt::Box<System::String>(u"B")));
	
	category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c4", ObjectExt::Box<System::String>(u"C")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"Group2"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c5", ObjectExt::Box<System::String>(u"D")));

	category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c6", ObjectExt::Box<System::String>(u"E")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"Group3"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c7", ObjectExt::Box<System::String>(u"F")));


	category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c8", ObjectExt::Box<System::String>(u"G")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"Group4"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c9", ObjectExt::Box<System::String>(u"H")));

	// Ajoute une nouvelle série
	SharedPtr<IChartSeries>  series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(0, u"D1", ObjectExt::Box<System::String>(u"Series 1")),
		ChartType::ClusteredColumn);

	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D2", ObjectExt::Box<double>(10)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D3", ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D4", ObjectExt::Box<double>(30)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D5", ObjectExt::Box<double>(40)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D6", ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D7", ObjectExt::Box<double>(60)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D8", ObjectExt::Box<double>(70)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D9", ObjectExt::Box<double>(80)));

	// Enregistre la présentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


### **Créer des graphiques cartographiques**
Un graphique cartographique est une visualisation d’une zone contenant des données. Les graphiques cartographiques sont les mieux adaptés pour comparer des données ou des valeurs entre différentes régions géographiques.

Ce code C++ montre comment créer un graphique cartographique :
```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Map, 50.0f, 50.0f, 500.0f, 400.0f);
pres->Save(u"mapChart.pptx", SaveFormat::Pptx);
```


### **Créer des graphiques combinés**
Un graphique combiné (ou graphique combo) combine deux types de graphiques ou plus dans un même graphique. Ce type de graphique vous permet de mettre en évidence, de comparer ou d’examiner les différences entre deux ensembles de données ou plus, vous aidant à identifier les relations entre eux.

![Le graphique combiné](combination_chart.png)

Le code C++ suivant montre comment créer le graphique combiné présenté ci‑dessus dans une présentation PowerPoint :
```cpp
static SharedPtr<IChart> CreateChartWithFirstSeries(SharedPtr<ISlide> slide)
{
    auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    // Définir le titre du graphique.
    chart->set_HasTitle(true);
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Chart Title");
    chart->get_ChartTitle()->set_Overlay(false);
    auto titleParagraph = chart->get_ChartTitle()->get_TextFrameForOverriding()->get_Paragraph(0);
    auto titleFormat = titleParagraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    titleFormat->set_FontBold(NullableBool::False);
    titleFormat->set_FontHeight(18.0);

    // Définir la légende du graphique.
    chart->get_Legend()->set_Position(LegendPositionType::Bottom);
    chart->get_Legend()->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);

    // Supprimer les séries et catégories générées par défaut.
    chart->get_ChartData()->get_Series()->Clear();
    chart->get_ChartData()->get_Categories()->Clear();

    const int worksheetIndex = 0;
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

    // Ajouter de nouvelles catégories.
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 4, 0, ObjectExt::Box<String>(u"Category 4")));

    // Ajouter la première série.
    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1"));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

    series->get_ParentSeriesGroup()->set_Overlap(-25);
    series->get_ParentSeriesGroup()->set_GapWidth(220);

    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<double>(4.3)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<double>(2.5)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<double>(3.5)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 4, 1, ObjectExt::Box<double>(4.5)));

    return chart;
}

static void AddSecondSeriesToChart(SharedPtr<IChart> chart)
{
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    const int worksheetIndex = 0;

    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2"));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, ChartType::ClusteredColumn);

    series->get_ParentSeriesGroup()->set_Overlap(-25);
    series->get_ParentSeriesGroup()->set_GapWidth(220);

    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<double>(2.4)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<double>(4.4)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<double>(1.8)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 4, 2, ObjectExt::Box<double>(2.8)));
}

static void AddThirdSeriesToChart(SharedPtr<IChart> chart)
{
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    const int worksheetIndex = 0;

    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 3, ObjectExt::Box<String>(u"Series 3"));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, ChartType::Line);

    series->get_DataPoints()->AddDataPointForLineSeries(workbook->GetCell(worksheetIndex, 1, 3, ObjectExt::Box<double>(2.0)));
    series->get_DataPoints()->AddDataPointForLineSeries(workbook->GetCell(worksheetIndex, 2, 3, ObjectExt::Box<double>(2.0)));
    series->get_DataPoints()->AddDataPointForLineSeries(workbook->GetCell(worksheetIndex, 3, 3, ObjectExt::Box<double>(3.0)));
    series->get_DataPoints()->AddDataPointForLineSeries(workbook->GetCell(worksheetIndex, 4, 3, ObjectExt::Box<double>(5.0)));

    series->set_PlotOnSecondAxis(true);
}

static void SetAxisTitle(SharedPtr<IAxis> axis, String axisTitle)
{
    axis->set_HasTitle(true);
    axis->get_Title()->set_Overlay(false);
    auto titleParagraph = axis->get_Title()->AddTextFrameForOverriding(axisTitle)->get_Paragraph(0);
    auto titleFormat = titleParagraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    titleFormat->set_FontBold(NullableBool::False);
    titleFormat->set_FontHeight(12.0);
}

static void SetPrimaryAxesFormat(SharedPtr<IChart> chart)
{
    // Définir l'axe horizontal.
    auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
    horizontalAxis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);
    horizontalAxis->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    SetAxisTitle(horizontalAxis, u"X Axis");

    // Définir l'axe vertical.
    auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
    verticalAxis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);
    verticalAxis->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    SetAxisTitle(verticalAxis, u"Y Axis 1");

    // Définir la couleur des lignes de grille principales verticales.
    auto majorGridLinesFormat = verticalAxis->get_MajorGridLinesFormat()->get_Line()->get_FillFormat();
    majorGridLinesFormat->set_FillType(FillType::Solid);
    majorGridLinesFormat->get_SolidFillColor()->set_Color(Color::FromArgb(217, 217, 217));
}

static void SetSecondaryAxesFormat(SharedPtr<IChart> chart)
{
    // Définir l'axe horizontal secondaire.
    auto secondaryHorizontalAxis = chart->get_Axes()->get_SecondaryHorizontalAxis();
    secondaryHorizontalAxis->set_Position(AxisPositionType::Bottom);
    secondaryHorizontalAxis->set_CrossType(CrossesType::Maximum);
    secondaryHorizontalAxis->set_IsVisible(false);
    secondaryHorizontalAxis->get_MajorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
    secondaryHorizontalAxis->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    // Définir l'axe vertical secondaire.
    auto secondaryVerticalAxis = chart->get_Axes()->get_SecondaryVerticalAxis();
    secondaryVerticalAxis->set_Position(AxisPositionType::Right);
    secondaryVerticalAxis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);
    secondaryVerticalAxis->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
    secondaryVerticalAxis->get_MajorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
    secondaryVerticalAxis->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    SetAxisTitle(secondaryVerticalAxis, u"Y Axis 2");
}

static void CreateComboChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = CreateChartWithFirstSeries(slide);

    AddSecondSeriesToChart(chart);
    AddThirdSeriesToChart(chart);

    SetPrimaryAxesFormat(chart);
    SetSecondaryAxesFormat(chart);

    presentation->Save(u"combo-chart.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```


## **Mettre à jour les graphiques**

1. Instanciez une classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) qui représente la présentation contenant le graphique.
2. Obtenez une référence à une diapositive via son index.
3. Parcourez toutes les formes pour trouver le graphique souhaité.
4. Accédez à la feuille de calcul des données du graphique.
5. Modifiez les données des séries du graphique en changeant les valeurs des séries.
6. Ajoutez une nouvelle série et remplissez‑la de données.
7. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ montre comment mettre à jour un graphique :
```c++
// Instancie une classe Presentation qui représente un fichier PPTX
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"ExistingChart.pptx");

// Accède à la première diapositive
System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Ajoute un graphique avec des données par défaut
System::SharedPtr<IChart> chart = System::ExplicitCast<Aspose::Slides::Charts::IChart>(sld->get_Shapes()->idx_get(0));

// Définit l'index de la feuille de données du graphique
int32_t defaultWorksheetIndex = 0;

// Obtient la feuille de calcul des données du graphique
System::SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


// Modifie le nom de la catégorie du graphique
fact->GetCell(defaultWorksheetIndex, 1, 0, System::ObjectExt::Box<System::String>(u"Modified Category 1"));
fact->GetCell(defaultWorksheetIndex, 2, 0, System::ObjectExt::Box<System::String>(u"Modified Category 2"));

// Récupère la première série du graphique
System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

// Met à jour les données de la série
fact->GetCell(defaultWorksheetIndex, 0, 1, System::ObjectExt::Box<System::String>(u"New_Series1"));
// Modification du nom de la série
series->get_DataPoints()->idx_get(0)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(90));
series->get_DataPoints()->idx_get(1)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(123));
series->get_DataPoints()->idx_get(2)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(44));

// Récupère la deuxième série du graphique
series = chart->get_ChartData()->get_Series()->idx_get(1);

// Mise à jour des données de la série
fact->GetCell(defaultWorksheetIndex, 0, 2, System::ObjectExt::Box<System::String>(u"New_Series2"));
// Modification du nom de la série
series->get_DataPoints()->idx_get(0)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(23));
series->get_DataPoints()->idx_get(1)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(67));
series->get_DataPoints()->idx_get(2)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(99));


// Maintenant, ajout d'une nouvelle série
chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 3, System::ObjectExt::Box<System::String>(u"Series 3")), chart->get_Type());

// Récupère la troisième série du graphique
series = chart->get_ChartData()->get_Series()->idx_get(2);

// Remplissage des données de la série
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 3, System::ObjectExt::Box<int32_t>(20)));
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, System::ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, System::ObjectExt::Box<int32_t>(30)));

chart->set_Type(Aspose::Slides::Charts::ChartType::ClusteredCylinder);

// Enregistre la présentation avec le graphique
pres->Save(u"AsposeChartModified_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```



## **Définir la plage de données pour les graphiques**

1. Ouvrez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) contenant le graphique.
2. Obtenez une référence à une diapositive via son index.
3. Parcourez toutes les formes pour trouver le graphique souhaité.
4. Accédez aux données du graphique et définissez la plage.
5. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C++ montre comment définir la plage de données pour un graphique :
```cpp
// Le chemin du répertoire des documents.
String dataDir = GetDataPath();

// Instancie une classe Presentation qui représente un fichier PPTX
auto presentation = System::MakeObject<Presentation>(dataDir + u"ExistingChart.pptx");

// Accède à la première slideMarker et ajoute un graphique avec des données par défaut
auto slide = presentation->get_Slides()->idx_get(0);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
chart->get_ChartData()->SetRange(u"Sheet1!A1:B4");
presentation->Save(dataDir + u"SetDataRange_out.pptx", SaveFormat::Pptx);
```



## **Utiliser les repères par défaut dans les graphiques**
Lorsque vous utilisez un repère par défaut dans les graphiques, chaque série de graphique obtient automatiquement des symboles de repère différents.

Ce code C++ montre comment définir automatiquement un repère de série de graphique :
```cpp
// Le chemin du répertoire des documents.
String dataDir = GetDataPath();

auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::LineWithMarkers, 10.0f, 10.0f, 400.0f, 400.0f);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();
chart->get_ChartData()->get_Series()->Add(wb->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 1, 0, ObjectExt::Box<String>(u"C1")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 1, 1, ObjectExt::Box<int32_t>(24)));
chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 2, 0, ObjectExt::Box<String>(u"C2")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 2, 1, ObjectExt::Box<int32_t>(23)));
chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 3, 0, ObjectExt::Box<String>(u"C3")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 3, 1, ObjectExt::Box<int32_t>(-10)));
chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 4, 0, ObjectExt::Box<String>(u"C4")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 4, 1, nullptr));

chart->get_ChartData()->get_Series()->Add(wb->GetCell(0, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// Prend la deuxième série du graphique
auto series2 = chart->get_ChartData()->get_Series()->idx_get(1);

// Populates the series data
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 1, 2, ObjectExt::Box<int32_t>(30)));
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 2, 2, ObjectExt::Box<int32_t>(10)));
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 3, 2, ObjectExt::Box<int32_t>(60)));
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 4, 2, ObjectExt::Box<int32_t>(40)));

chart->set_HasLegend(true);
chart->get_Legend()->set_Overlay(false);

pres->Save(dataDir + u"DefaultMarkersInChart.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Quels types de graphiques sont pris en charge par Aspose.Slides ?**

Aspose.Slides prend en charge un large éventail de types de graphiques, notamment les graphiques à barres, lignes, circulaires, en aires, dispersés, histogrammes, radar, et bien d’autres. Cette flexibilité vous permet de choisir le type de graphique le plus approprié à vos besoins de visualisation de données.

**Comment ajouter un nouveau graphique à une diapositive ?**

Pour ajouter un graphique, créez d’abord une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) , récupérez la diapositive souhaitée à l’aide de son index, puis appelez la méthode pour ajouter un graphique en spécifiant le type de graphique et les données initiales. Ce processus intègre le graphique directement dans votre présentation.

**Comment mettre à jour les données affichées dans un graphique ?**

Vous pouvez mettre à jour les données d’un graphique en accédant à son classeur de données ([IChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/)), en supprimant les séries et catégories par défaut, puis en ajoutant vos propres données. Cela vous permet d’actualiser le graphique de façon programmatique pour refléter les dernières données.

**Est‑il possible de personnaliser l’apparence du graphique ?**

Oui, Aspose.Slides propose de nombreuses options de personnalisation. Vous pouvez modifier les couleurs, les polices, les libellés, les légendes et d’autres éléments de formatage afin d’adapter l’apparence du graphique à vos exigences de conception spécifiques.