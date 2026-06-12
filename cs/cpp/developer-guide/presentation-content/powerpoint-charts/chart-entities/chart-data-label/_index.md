---
title: Spravujte popisky dat v grafech v prezentacích pomocí С++
linktitle: Popisek dat
type: docs
url: /cs/cpp/chart-data-label/
keywords:
- graf
- popisek dat
- přesnost dat
- procento
- vzdálenost popisku
- umístění popisku
- PowerPoint
- prezentace
- С++
- Aspose.Slides
description: "Naučte se přidávat a formátovat popisky dat v grafech v prezentacích PowerPoint pomocí Aspose.Slides pro С++ pro poutavější snímky."
---
## **Úvod**

Popisky dat v grafu zobrazují podrobnosti o sériích dat grafu nebo jednotlivých bodech. Umožňují čtenářům rychle rozpoznat sérii a také usnadňují pochopení grafu.

## **Nastavení přesnosti dat v popiscích grafu**

Tento kód v C++ vám ukazuje, jak nastavit přesnost dat v popisku grafu:

```c++
	// Cesta k adresáři dokumentů
	const String outPath = u"../out/SettingPrecisionOfDataLabel_out.pptx";

	// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Získá první snímek
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Přidá graf s výchozími daty
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Line, 0, 0, 500, 500);

	// Nastaví formát čísla řady
	chart->set_HasDataTable( true);
	chart->get_ChartData()->get_Series()->idx_get(0)->set_NumberFormatOfValues (u"#,##0.00");

	// Zapíše soubor prezentace na disk
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Zobrazení procent jako popisků**

Aspose.Slides pro C++ umožňuje nastavit procentuální popisky v zobrazených grafech. Tento kód v C++ demonstruje tuto operaci:

```c++
	// Cesta k adresáři dokumentů
	const String outPath = u"../out/DisplayPercentageAsLabels_out.pptx";

	// Vytvoří instanci třídy Presentation
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

	// Uloží prezentaci obsahující graf
	presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Nastavení znaku procenta v popiscích grafu**

Tento kód v C++ vám ukazuje, jak nastavit znak procenta pro popisek grafu:

```c++
	// Cesta k adresáři dokumentů.
	const String outPath = u"../out/DataLabelsPercentageSign_out.pptx";

	// Vytvoří instanci třídy Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Získá referenci snímku podle jeho indexu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Vytvoří graf PercentsStackedColumn na snímku
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// Nastaví NumberFormatLinkedToSource na false
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource ( false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// Nastaví index listu dat grafu
	int defaultWorksheetIndex = 0;

	// Získá sešit dat grafu
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Odstraní výchozí vygenerované řady 
	chart->get_ChartData()->get_Series()->Clear();
	

	// Přidá novou řadu
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());


	// Načte první řadu grafu
	SharedPtr<IChartSeries> series=chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Red")), chart->get_Type());
	// Naplní data řady
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(0.80)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(0.65)));

	// Nastaví barvu výplně pro řadu
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// Nastaví vlastnosti LabelFormat
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource ( false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat (u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight ( 10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Načte druhou řadu grafu
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Blues")), chart->get_Type());
	// Naplní data řady
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(0.70)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(0.50)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(0.20)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 2, ObjectExt::Box<double>(0.35)));

	// Nastaví barvu výplně pro řadu
	series2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// Nastaví vlastnosti LabelFormat
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Zapíše soubor prezentace na disk
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Nastavení vzdálenosti popisku od osy**

Tento kód v C++ vám ukazuje, jak nastavit vzdálenost popisku od kategoriální osy při práci s grafem vykresleným z os:

```c++
	// Cesta k adresáři dokumentů
	const String outPath = u"../out/CategoryAxisLabelDistance_out.pptx";

	// Vytvoří instanci třídy Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Získá referenci snímku
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Vytvoří graf na snímku
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// Získá kolekci řad grafu
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// Nastaví vzdálenost popisku od osy
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset ( 500);

	// Zapíše soubor prezentace na disk
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Úprava umístění popisku**

Když vytvoříte graf, který nezávisí na žádné ose, například koláčový graf, mohou být popisky dat grafu příliš blízko jeho okraje. V takovém případě musíte upravit umístění popisku, aby byly čáry spojující (leader lines) zobrazeny jasně.

Tento kód v C++ vám ukazuje, jak upravit umístění popisku v koláčovém grafu:

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

## **Často kladené otázky**

**Jak mohu zabránit překrývání popisků dat v hustých grafech?**

Kombinujte automatické umísťování popisků, čáry spojující (leader lines) a zmenšení velikosti písma; v případě potřeby skryjte některá pole (například kategorii) nebo zobrazte popisky jen pro krajní/klíčové body.

**Jak mohu zakázat popisky pouze pro nulové, záporné nebo prázdné hodnoty?**

Před povolením popisků filtrujte datové body a vypněte jejich zobrazování pro hodnoty 0, záporné hodnoty nebo chybějící hodnoty podle definovaného pravidla.

**Jak mohu zajistit konzistentní styl popisků při exportu do PDF/obrázků?**

Explicitně nastavte písma (rodinu, velikost) a ověřte, že písmo je k dispozici na straně vykreslování, aby se předešlo náhradnímu písmu.