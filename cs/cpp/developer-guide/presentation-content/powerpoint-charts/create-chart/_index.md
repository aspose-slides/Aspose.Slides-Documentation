---
title: Vytvořit nebo aktualizovat grafy v PowerPoint prezentaci v С++
linktitle: Vytvořit nebo aktualizovat grafy
type: docs
weight: 10
url: /cs/cpp/create-chart/
keywords:
- přidat graf
- vytvořit graf
- upravit graf
- změnit graf
- aktualizovat graf
- rozptýlený graf
- koláčový graf
- čárový graf
- graf stromové mapy
- akciový graf
- box‑and‑whisker graf
- trychtýřový graf
- sunburst graf
- histogramový graf
- radarový graf
- vícekategoriový graf
- PowerPoint
- prezentace
- С++
- Aspose.Slides
description: "Vytvářejte a přizpůsobujte grafy v PowerPoint prezentacích pomocí Aspose.Slides pro С++. Přidávejte, formátujte a upravujte grafy s praktickými příklady kódu v С++."
---
## **Přehled**

Tento článek poskytuje komplexní průvodce, jak vytvářet a přizpůsobovat grafy pomocí Aspose.Slides. Naučíte se, jak programově přidat graf do snímku, naplnit jej údaji a použít různé možnosti formátování tak, aby odpovídal vašim konkrétním požadavkům na design. V celém článku jsou podrobně ilustrovány kódy, které ukazují každý krok – od inicializace prezentace a objektu grafu po konfiguraci sérií, os a legend. Dodržením tohoto průvodce získáte pevné pochopení toho, jak integrovat dynamické generování grafů do vašich aplikací a zjednodušit tvorbu datově orientovaných prezentací.

## **Vytvoření grafu**

Grafy pomáhají lidem rychle vizualizovat data a získat poznatky, které nemusí být okamžitě zřejmé z tabulky nebo tabulkového procesoru.

**Proč vytvářet grafy?**

Pomocí grafů můžete

* agregovat, zhušťovat nebo shrnovat velké množství dat na jediném snímku v prezentaci
* odhalit vzory a trendy v datech
* odvodit směr a dynamiku dat v čase nebo vzhledem k určité jednotce měření
* identifikovat odlehlé hodnoty, odchylky, chyby, nesmyslná data atd.
* komunikovat nebo prezentovat složitá data

V PowerPointu můžete grafy vytvářet pomocí funkce vložení, která poskytuje šablony pro návrh mnoha typů grafů. Pomocí Aspose.Slides můžete vytvářet běžné grafy (na základě populárních typů) i vlastní grafy.

{{% alert color="primary" %}} 

Aby bylo možné vytvářet grafy, Aspose.Slides poskytuje výčtový typ [ChartType](https://reference.aspose.com/slides/cs/cpp/namespace/aspose.slides.charts#a23ba9ea390f5be4c8f5ab18baf4f8c05) ve jmenném prostoru [Aspose::Slides::Charts](https://reference.aspose.com/slides/cs/cpp/namespace/aspose.slides.charts/). Hodnoty v tomto výčtu odpovídají různým typům grafů. 

{{% /alert %}} 

### **Vytvoření běžných grafů**
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte graf s nějakými daty a určete požadovaný typ grafu. 
1. Přidejte titulek k grafu. 
1. Získejte přístup k pracovním listům dat grafu. 
1. Vymažte všechny výchozí série a kategorie. 
1. Přidejte nové série a kategorie. 
1. Přidejte nová data do sérií grafu. 
1. Nastavte barvu výplně pro série grafu. 
1. Přidejte popisky pro série grafu. 
1. Uložte upravenou prezentaci jako soubor PPTX. 

Tento C++ kód ukazuje, jak vytvořit běžný graf:

```c++
// Cesta k adresáři dokumentů.
	const String outPath = u"../out/NormalCharts_out.pptx";

	// Vytvoří instanci třídy prezentace, která představuje soubor PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Přistupuje k prvnímu snímku
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Přidá graf s výchozími daty
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// Nastaví index listu s daty grafu
	int defaultWorksheetIndex = 0;

	// Získá pracovní list dat grafu
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// Nastaví titulek grafu
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText ( NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle( true);

	// Odstraní výchozí generované série a kategorie
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();
	int s = chart->get_ChartData()->get_Series()->get_Count();
	s = chart->get_ChartData()->get_Categories()->get_Count();


	// Přidá novou sérii
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());

	// Přidá kategorie
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"Caetegoty 1")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"Caetegoty 2")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"Caetegoty 3")));

	
	// Získá první sérii grafu
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// Naplní data série
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(30)));

	// Nastaví barvu výplně pro sérii
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());


	// Získá druhou sérii grafu
	 series = chart->get_ChartData()->get_Series()->idx_get(1);

	// Naplní data série
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(30)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(10)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(60)));

	// Nastaví barvu výplně pro sérii
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Green());


	// První popisek je nastaven tak, aby zobrazoval název kategorie
	SharedPtr<IDataLabel> lbl = series->get_DataPoints()->idx_get(0)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowCategoryName(true);

	lbl = series->get_DataPoints()->idx_get(1)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowSeriesName (true);

	// Zobrazí hodnotu pro třetí popisek
	lbl = series->get_DataPoints()->idx_get(2)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowValue (true);
	lbl->get_DataLabelFormat()->set_ShowSeriesName(true);
	lbl->get_DataLabelFormat()->set_Separator (u"/");

	// Uloží prezentaci
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

### **Vytvoření rozptýlených grafů**
Rozptýlené grafy (také nazývané rozptylové grafy nebo x‑y grafy) se často používají k ověření vzorů nebo demonstraci korelací mezi dvěma proměnnými. 

Můžete chtít použít rozptýlený graf, když

* máte spárovaná numerická data
* máte 2 proměnné, které spolu dobře korespondují
* chcete zjistit, zda jsou 2 proměnné vzájemně spojené
* máte nezávislou proměnnou s více hodnotami pro závislou proměnnou

Tento C++ kód ukazuje, jak vytvořit rozptýlený graf s různými sériemi značek: 

```c++
// Cesta k adresáři dokumentů.
	const String outPath = u"../out/ScatteredChart_out.pptx";

	// Vytvoří instanci třídy prezentace, která představuje soubor PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Přistupuje k prvnímu snímku
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Přidá graf s výchozími daty
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ScatterWithSmoothLines, 0, 0, 500, 500);

	// Nastaví titulek grafu
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// Odstraní výchozí generované série 
	chart->get_ChartData()->get_Series()->Clear();
	
	// Nastaví index listu s daty grafu
	int defaultWorksheetIndex = 0;

	// Získá pracovní list dat grafu
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Přidá novou sérii
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 3, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());

	// Získá první sérii grafu
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// Přidá nový bod (1:3)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(1)), fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(3)));

	// Přidá nový bod (2:10)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(10)));

	// Upraví typ série
	series->set_Type (ChartType::ScatterWithStraightLinesAndMarkers);

	// Změní marker série grafu
	series->get_Marker()->set_Size  (10);
	series->get_Marker()->set_Symbol(MarkerStyleType::Star);



	// Získá druhou sérii grafu
	series  = chart->get_ChartData()->get_Series()->idx_get(1);

	// Přidá nový bod (5:2)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 2, 4, ObjectExt::Box<double>(2)));

	// Přidá nový bod (3:1)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, ObjectExt::Box<double>(3)), fact->GetCell(defaultWorksheetIndex, 3, 4, ObjectExt::Box<double>(1)));

	// Přidá nový bod (2:2)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 4, 3, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 4, 4, ObjectExt::Box<double>(2)));

	// Přidá nový bod (5:1)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 5, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 5, 4, ObjectExt::Box<double>(1)));

	// Změní marker série grafu
	series->get_Marker()->set_Size ( 10);
	series->get_Marker()->set_Symbol(MarkerStyleType::Circle);



	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_IsColorVaried(true);

	SharedPtr<IChartDataPoint> point = series->get_DataPoints()->idx_get(0);
	point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Cyan());
	// Nastaví okraj sektoru
	point->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
	point->get_Format()->get_Line()->set_Width ( 3.0);
	point->get_Format()->get_Line()->set_Style(LineStyle::ThinThick);
	point->get_Format()->get_Line()->set_DashStyle(LineDashStyle::DashDot);

	SharedPtr<IChartDataPoint> point1 = series->get_DataPoints()->idx_get(1);
	point1->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Brown());

	// Nastaví okraj sektoru
	point1->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
	point1->get_Format()->get_Line()->set_Width (3.0);
	point1->get_Format()->get_Line()->set_Style(LineStyle::Single);
	point1->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDot);


	SharedPtr<IChartDataPoint> point2 = series->get_DataPoints()->idx_get(2);
	point2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Coral());

	// Nastaví okraj sektoru
	point2->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
	point2->get_Format()->get_Line()->set_Width ( 2.0);
	point2->get_Format()->get_Line()->set_Style(LineStyle::ThickThin);
	point2->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDotDot);


	// Vytvoří vlastní popisky pro každou kategorii nové série
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

	// Zobrazí čáry spojující popisky grafu
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines(true);

	// Nastaví úhel otočení pro sektory koláčového grafu
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle(180);


	// Uloží prezentaci
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Vytvoření koláčových grafů**
Koláčové grafy jsou nejvhodnější pro zobrazení vztahu část‑celku v datech, zejména když data obsahují kategoriální štítky s číselnými hodnotami. Pokud však vaše data obsahují mnoho částí nebo štítků, můžete zvažovat místo toho sloupcový graf. 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte graf s výchozími daty a požadovaným typem (v tomto případě `ChartType.Pie`).
1. Získejte přístup k objektu IChartDataWorkbook. 
1. Vymažte výchozí série a kategorie. 
1. Přidejte nové série a kategorie. 
1. Přidejte nová data pro série grafu. 
1. Přidejte nové body do grafu a nastavte vlastní barvy sektorů koláčového grafu. 
1. Nastavte popisky pro série. 
1. Nastavte čáry ukazatele pro popisky sérií. 
1. Nastavte úhel otočení pro slidy koláčového grafu. 
1. Uložte upravenou prezentaci jako soubor PPTX. 

Tento C++ kód ukazuje, jak vytvořit koláčový graf:

```c++
	// Cesta k adresáři dokumentů.
	const String outPath = u"../out/PieChart_out.pptx";

	//Vytvoří instanci třídy Presentation, která představuje soubor PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Přistupuje k prvnímu snímku
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Přidá graf s výchozími daty
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Pie, 0, 0, 500, 500);

	// Nastaví titulek grafu
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// Odstraní výchozí generované série a kategorie
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// Nastaví index listu s daty grafu
	int defaultWorksheetIndex = 0;

	// Získá pracovní list dat grafu
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// Přidá kategorie
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"First Qtr")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"2nd Qtr")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"3ed Qtr")));

	// Přidá novou sérii
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
	
	// Získá první sérii grafu
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// Naplní data série
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(30)));

	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_IsColorVaried(true);

	SharedPtr<IChartDataPoint> point = series->get_DataPoints()->idx_get(0);
	point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Cyan());
	// Nastaví okraj sektoru
	point->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
	point->get_Format()->get_Line()->set_Width ( 3.0);
	point->get_Format()->get_Line()->set_Style( LineStyle::ThinThick);
	point->get_Format()->get_Line()->set_DashStyle ( LineDashStyle::DashDot);

	SharedPtr<IChartDataPoint> point1 = series->get_DataPoints()->idx_get(1);
	point1->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Brown());

	// Nastaví okraj sektoru
	point1->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
	point1->get_Format()->get_Line()->set_Width (3.0);
	point1->get_Format()->get_Line()->set_Style(LineStyle::Single);
	point1->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDot);


	SharedPtr<IChartDataPoint> point2 = series->get_DataPoints()->idx_get(2);
	point2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Coral());

	// Nastaví okraj sektoru
	point2->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
	point2->get_Format()->get_Line()->set_Width (2.0);
	point2->get_Format()->get_Line()->set_Style(LineStyle::ThickThin);
	point2->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDotDot);


	// Vytvoří vlastní popisky pro každou kategorii nové série
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

	// Nastaví, aby série zobrazovala spojovací linky pro graf
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines ( true);

	// Nastaví úhel otočení pro sektory koláčového grafu
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle ( 180);


	// Uloží prezentaci
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Vytvoření čárových grafů**

Čárové grafy (také nazývané čárové diagramy) jsou nejvhodnější v situacích, kdy chcete ukázat změny hodnot v čase. Pomocí čárového grafu můžete najednou porovnat velké množství dat, sledovat změny a trendy v průběhu času, zvýraznit anomálie v sériích dat atd.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte graf s výchozími daty a požadovaným typem (v tomto případě `ChartType::Line`).
1. Získejte přístup k objektu IChartDataWorkbook. 
1. Vymažte výchozí série a kategorie. 
1. Přidejte nové série a kategorie. 
1. Přidejte nová data pro série grafu. 
1. Uložte upravenou prezentaci jako soubor PPTX. 

Tento C++ kód ukazuje, jak vytvořit čárový graf:

```c++
auto pres = System::MakeObject<Presentation>();

System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
pres->Save(u"lineChart.pptx", SaveFormat::Pptx);
```

Ve výchozím nastavení jsou body v čárovém grafu spojeny přímými spojnicemi. Pokud chcete, aby byly body spojeny čárkovanou čarou, můžete specifikovat požadovaný typ čárky takto:

```c++
System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
for (auto&& series : lineChart->get_ChartData()->get_Series())
{
    series->get_Format()->get_Line()->set_DashStyle(LineDashStyle::Dash);
}
```

### **Vytvoření grafů stromových map**

Grafy stromových map jsou nejvhodnější pro prodejní data, kdy chcete zobrazit relativní velikost kategorií a zároveň rychle upozornit na položky, které jsou velkými přispěvateli do každé kategorie. 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte graf s výchozími daty a požadovaným typem (v tomto případě `ChartType.TreeMap`).
1. Získejte přístup k objektu IChartDataWorkbook. 
1. Vymažte výchozí série a kategorie. 
1. Přidejte nové série a kategorie. 
1. Přidejte nová data pro série grafu. 
1. Uložte upravenou prezentaci jako soubor PPTX. 

Tento C++ kód ukazuje, jak vytvořit graf stromové mapy:

```c++
// Cesta k adresáři dokumentů.
	const String outPath = u"../out/TreemapChart_out.pptx";

	// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Přistupuje k prvnímu snímku
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Treemap, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	// Větev 1
	System::SharedPtr<IChartCategory> leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C1", System::ObjectExt::Box<System::String>(u"Leaf1")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem1"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch1"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C2", System::ObjectExt::Box<System::String>(u"Leaf2")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C3", System::ObjectExt::Box<System::String>(u"Leaf3")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C4", System::ObjectExt::Box<System::String>(u"Leaf4")));


	// Větev 2
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

	// Uloží prezentaci
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Vytvoření akciových grafů**
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte graf s výchozími daty a požadovaným typem (ChartType.OpenHighLowClose).
1. Získejte přístup k objektu IChartDataWorkbook. 
1. Vymažte výchozí série a kategorie. 
1. Přidejte nové série a kategorie. 
1. Přidejte nová data pro série grafu. 
1. Specifikujte formát HiLowLines. 
1. Uložte upravenou prezentaci jako soubor PPTX. 

Ukázkový C++ kód pro vytvoření akciového grafu:

```c++
	// Cesta k adresáři dokumentů.
	const String outPath = u"../out/AddStockChart_out.pptx";

	// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Přistupuje k prvnímu snímku
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Přidá graf s výchozími daty
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::OpenHighLowClose, 0, 0, 500, 500);


	// Nastaví index listu s daty grafu
	int defaultWorksheetIndex = 0;

	// Získá pracovní list dat grafu
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Odstraní výchozí generované série a kategorie
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// Přidá kategorie
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"A")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"B")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"C")));

	// Přidá novou sérii
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Open")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"High")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 3, ObjectExt::Box<System::String>(u"Low")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 4, ObjectExt::Box<System::String>(u"Close")), chart->get_Type());


	// Získá první sérii grafu
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);
	// Naplní data první série
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(72)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(25)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(38)));


	series = chart->get_ChartData()->get_Series()->idx_get(1);
	// Naplní data druhé série
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(172)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(57)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(57)));

	series = chart->get_ChartData()->get_Series()->idx_get(2);
	// Naplní data druhé série
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 3, ObjectExt::Box<double>(12)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, ObjectExt::Box<double>(12)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, ObjectExt::Box<double>(13)));


	series = chart->get_ChartData()->get_Series()->idx_get(3);
	// Naplní data druhé série
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 4, ObjectExt::Box<double>(25)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 4, ObjectExt::Box<double>(38)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 4, ObjectExt::Box<double>(50)));

	// Nastaví skupinu sérií
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->get_UpDownBars()->set_HasUpDownBars (true);
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->get_HiLowLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);


	for(int i=0;i<chart->get_ChartData()->get_Series()->get_Count();i++)
	{
		series = chart->get_ChartData()->get_Series()->idx_get(i);
		series->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
	}

	// Uloží prezentaci
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Vytvoření box‑and‑whisker grafů**
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte graf s výchozími daty a požadovaným typem (ChartType.BoxAndWhisker).
1. Získejte přístup k objektu IChartDataWorkbook. 
1. Vymažte výchozí série a kategorie. 
1. Přidejte nové série a kategorie. 
1. Přidejte nová data pro série grafu. 
1. Uložte upravenou prezentaci jako soubor PPTX. 

Tento C++ kód ukazuje, jak vytvořit box‑and‑whisker graf:

```c++
	// Cesta k adresáři dokumentů.
	const String outPath = u"../out/BoxAndWhisker_out.pptx";

	//Vytvoří instanci třídy Presentation, která představuje soubor PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Přistupuje k prvnímu snímku
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


	// Uloží prezentaci
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Vytvoření trychtýřových grafů**
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte graf s výchozími daty a požadovaným typem (ChartType.Funnel).
1. Uložte upravenou prezentaci jako soubor PPTX. 

Tento C++ kód ukazuje, jak vytvořit trychtýřový graf:

```c++
	// Cesta k adresáři dokumentů.
	const String outPath = u"../out/FunnelChart_out.pptx";

	// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Přistupuje k prvnímu snímku
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


	// Uloží prezentaci
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Vytvoření Sunburst grafů**
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte graf s výchozími daty a požadovaným typem (v tomto případě `ChartType.sunburst`).
1. Uložte upravenou prezentaci jako soubor PPTX. 

Tento C++ kód ukazuje, jak vytvořit Sunburst graf:

```c++
	// Cesta k adresáři dokumentů.
	const String outPath = u"../out/SunburstChart_out.pptx";

	// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Přistupuje k prvnímu snímku
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart=slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Sunburst, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	// Větev 1
	System::SharedPtr<IChartCategory> leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C1", System::ObjectExt::Box<System::String>(u"Leaf1")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem1"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch1"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C2", System::ObjectExt::Box<System::String>(u"Leaf2")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C3", System::ObjectExt::Box<System::String>(u"Leaf3")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C4", System::ObjectExt::Box<System::String>(u"Leaf4")));

	// Větev 2
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

	// Zapíše soubor prezentace na disk
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

### **Vytvoření histogramových grafů**
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
1. Získejte odkaz na snímek pomocí jeho indexu. 
1. Přidejte graf s nějakými daty a určete požadovaný typ (`ChartType.Histogram` v tomto případě).
1. Získejte přístup k objektu `IChartDataWorkbook`. 
1. Vymažte výchozí série a kategorie. 
1. Přidejte nové série a kategorie. 
1. Uložte upravenou prezentaci jako soubor PPTX. 

Tento C++ kód ukazuje, jak vytvořit histogramový graf:

```c++
	// Cesta k adresáři dokumentů.
	const String outPath = u"../out/HistogramChart_out.pptx";

	// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Přistupuje k prvnímu snímku
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

	// Uloží prezentaci
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Vytvoření radarových grafů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
1. Získejte odkaz na snímek pomocí jeho indexu. 
1. Přidejte graf s nějakými daty a určete požadovaný typ (`ChartType.Radar` v tomto případě).
1. Uložte upravenou prezentaci jako soubor PPTX. 

Tento C++ kód ukazuje, jak vytvořit radarový graf:

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Radar, 20.0f, 20.0f, 400.0f, 300.0f);
presentation->Save(u"Radar-chart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Vytvoření vícekategoriových grafů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte graf s výchozími daty a požadovaným typem (ChartType.ClusteredColumn).
1. Získejte přístup k objektu IChartDataWorkbook. 
1. Vymažte výchozí série a kategorie. 
1. Přidejte nové série a kategorie. 
1. Přidejte nová data pro série grafu. 
1. Uložte upravenou prezentaci jako soubor PPTX. 

Tento C++ kód ukazuje, jak vytvořit vícekategoriový graf:

```c++
	// Cesta k adresáři dokumentů.
	const String outPath = u"../out/MultiCategoryChart_out.pptx";

	// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Přistupuje k prvnímu snímku
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Přidá graf s výchozími daty
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);

	// Nastaví index listu s daty grafu
	int defaultWorksheetIndex = 0;

	// Získá pracovní list dat grafu
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// Vymaže sešit
	fact->Clear(defaultWorksheetIndex);

	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();


	// Přidá kategorie
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

	// Přidá novou sérii
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

	// Uloží prezentaci
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Vytvoření mapových grafů**

Mapový graf je vizualizace oblasti obsahující data. Mapové grafy jsou nejvhodnější pro srovnání dat nebo hodnot napříč geografickými regiony.

Tento C++ kód ukazuje, jak vytvořit mapový graf:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Map, 50.0f, 50.0f, 500.0f, 400.0f);
pres->Save(u"mapChart.pptx", SaveFormat::Pptx);
```

### **Vytvoření kombinovaných grafů**

Kombinovaný graf (nebo combo graf) spojuje dva nebo více typů grafů v jednom diagramu. Tento graf vám umožňuje zvýraznit, porovnat nebo zkoumat rozdíly mezi dvěma a více datovými sadami, což pomáhá identifikovat vztahy mezi nimi.

![Kombinovaný graf](combination_chart.png)

Následující C++ kód ukazuje, jak vytvořit výše uvedený kombinovaný graf v PowerPointové prezentaci:

```cpp
static SharedPtr<IChart> CreateChartWithFirstSeries(SharedPtr<ISlide> slide)
{
    auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    // Nastaví titulek grafu.
    chart->set_HasTitle(true);
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Chart Title");
    chart->get_ChartTitle()->set_Overlay(false);
    auto titleParagraph = chart->get_ChartTitle()->get_TextFrameForOverriding()->get_Paragraph(0);
    auto titleFormat = titleParagraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    titleFormat->set_FontBold(NullableBool::False);
    titleFormat->set_FontHeight(18.0);

    // Nastaví legendu grafu.
    chart->get_Legend()->set_Position(LegendPositionType::Bottom);
    chart->get_Legend()->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);

    // Odstraní výchozí generované série a kategorie.
    chart->get_ChartData()->get_Series()->Clear();
    chart->get_ChartData()->get_Categories()->Clear();

    const int worksheetIndex = 0;
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

    // Přidá nové kategorie.
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 4, 0, ObjectExt::Box<String>(u"Category 4")));

    // Přidá první sérii.
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
    // Nastaví vodorovnou osu.
    auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
    horizontalAxis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);
    horizontalAxis->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    SetAxisTitle(horizontalAxis, u"X Axis");

    // Nastaví svislou osu.
    auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
    verticalAxis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);
    verticalAxis->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    SetAxisTitle(verticalAxis, u"Y Axis 1");

    // Nastaví barvu hlavních mřížkových čar svislé osy.
    auto majorGridLinesFormat = verticalAxis->get_MajorGridLinesFormat()->get_Line()->get_FillFormat();
    majorGridLinesFormat->set_FillType(FillType::Solid);
    majorGridLinesFormat->get_SolidFillColor()->set_Color(Color::FromArgb(217, 217, 217));
}

static void SetSecondaryAxesFormat(SharedPtr<IChart> chart)
{
    // Nastaví sekundární vodorovnou osu.
    auto secondaryHorizontalAxis = chart->get_Axes()->get_SecondaryHorizontalAxis();
    secondaryHorizontalAxis->set_Position(AxisPositionType::Bottom);
    secondaryHorizontalAxis->set_CrossType(CrossesType::Maximum);
    secondaryHorizontalAxis->set_IsVisible(false);
    secondaryHorizontalAxis->get_MajorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
    secondaryHorizontalAxis->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    // Nastaví sekundární svislou osu.
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

## **Aktualizace grafů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation), která představuje prezentaci obsahující graf.
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Procházejte všechny tvary a najděte požadovaný graf.
4. Získejte přístup k pracovnímu listu dat grafu.
5. Modifikujte data sérií grafu změnou hodnot.
6. Přidejte novou sérii a naplňte ji daty.
7. Uložte upravenou prezentaci jako soubor PPTX.

Tento C++ kód ukazuje, jak aktualizovat graf:

```c++
	// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"ExistingChart.pptx");

	// Přistoupí k prvnímu snímku
System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

	// Přidá graf s výchozími daty
System::SharedPtr<IChart> chart = System::ExplicitCast<Aspose::Slides::Charts::IChart>(sld->get_Shapes()->idx_get(0));

	// Nastaví index listu s daty grafu
int32_t defaultWorksheetIndex = 0;

	// Získá pracovní list dat grafu
System::SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


// Změní název kategorie grafu
fact->GetCell(defaultWorksheetIndex, 1, 0, System::ObjectExt::Box<System::String>(u"Modified Category 1"));
fact->GetCell(defaultWorksheetIndex, 2, 0, System::ObjectExt::Box<System::String>(u"Modified Category 2"));

// Získá první sérii grafu
System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

// Aktualizuje data série
fact->GetCell(defaultWorksheetIndex, 0, 1, System::ObjectExt::Box<System::String>(u"New_Series1"));
// Úprava názvu série
series->get_DataPoints()->idx_get(0)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(90));
series->get_DataPoints()->idx_get(1)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(123));
series->get_DataPoints()->idx_get(2)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(44));

// Získá druhou sérii grafu
series = chart->get_ChartData()->get_Series()->idx_get(1);

// Nyní aktualizuje data série
fact->GetCell(defaultWorksheetIndex, 0, 2, System::ObjectExt::Box<System::String>(u"New_Series2"));
// Úprava názvu série
series->get_DataPoints()->idx_get(0)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(23));
series->get_DataPoints()->idx_get(1)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(67));
series->get_DataPoints()->idx_get(2)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(99));


// Nyní přidá novou sérii
chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 3, System::ObjectExt::Box<System::String>(u"Series 3")), chart->get_Type());

// Získá třetí sérii grafu
series = chart->get_ChartData()->get_Series()->idx_get(2);

// Nyní naplní data série
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 3, System::ObjectExt::Box<int32_t>(20)));
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, System::ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, System::ObjectExt::Box<int32_t>(30)));

chart->set_Type(Aspose::Slides::Charts::ChartType::ClusteredCylinder);

// Uloží prezentaci s grafem
pres->Save(u"AsposeChartModified_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Nastavení rozsahu dat pro grafy**

1. Otevřete instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation) obsahující graf.
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Procházejte všechny tvary a najděte požadovaný graf.
4. Získejte přístup k datům grafu a nastavte rozsah.
5. Uložte upravenou prezentaci jako soubor PPTX.

Tento C++ kód ukazuje, jak nastavit rozsah dat pro graf:

```cpp
// Cesta k adresáři dokumentů.
String dataDir = GetDataPath();

// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
auto presentation = System::MakeObject<Presentation>(dataDir + u"ExistingChart.pptx");

// Přistoupí k prvnímu snímku a přidá graf s výchozími daty
auto slide = presentation->get_Slides()->idx_get(0);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
chart->get_ChartData()->SetRange(u"Sheet1!A1:B4");
presentation->Save(dataDir + u"SetDataRange_out.pptx", SaveFormat::Pptx);
```

## **Použití výchozích markerů v grafech**

Když použijete výchozí marker v grafech, každá série grafu automaticky získá jiný výchozí symbol markeru.

Tento C++ kód ukazuje, jak automaticky nastavit marker pro sérii grafu:

```cpp
// Cesta k adresáři dokumentů.
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

// Takes the second chart series
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

## **Často kladené dotazy**

**Jaké typy grafů jsou podporovány v Aspose.Slides?**

Aspose.Slides podporuje širokou škálu typů grafů, včetně sloupcových, čárových, koláčových, plošných, rozptýlených, histogramových, radarových a mnoha dalších. Tato flexibilita vám umožní vybrat nejvhodnější typ grafu pro vaše potřeby vizualizace dat.

**Jak přidám nový graf do snímku?**

Pro přidání grafu nejprve vytvoříte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/), získáte požadovaný snímek pomocí jeho indexu a poté zavoláte metodu pro přidání grafu, přičemž specifikujete typ grafu a počáteční data. Tento proces integruje graf přímo do vaší prezentace.

**Jak mohu aktualizovat data zobrazovaná v grafu?**

Data grafu můžete aktualizovat přístupem k jeho sešitu dat ([IChartDataWorkbook](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdataworkbook/)), vymazáním výchozích sérií a kategorií a následným přidáním vlastních dat. Tím umožníte programově obnovit graf tak, aby odrážel nejnovější data.

**Je možné přizpůsobit vzhled grafu?**

Ano, Aspose.Slides poskytuje rozsáhlé možnosti přizpůsobení. Můžete upravit barvy, písma, popisky, legendy a další formátovací prvky, aby vzhled grafu odpovídal vašim konkrétním požadavkům na design.