---
title: Zarządzanie etykietami danych wykresu w prezentacjach przy użyciu C++
linktitle: Etykieta danych
type: docs
url: /pl/cpp/chart-data-label/
keywords:
- wykres
- etykieta danych
- precyzja danych
- procent
- odległość etykiety
- położenie etykiety
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak dodawać i formatować etykiety danych wykresu w prezentacjach PowerPoint przy użyciu Aspose.Slides dla C++ aby uzyskać bardziej angażujące slajdy."
---
## **Wprowadzenie**

Etykiety danych na wykresie wyświetlają szczegóły dotyczące serii danych wykresu lub poszczególnych punktów danych. Umożliwiają czytelnikom szybkie rozpoznanie serii danych i ułatwiają zrozumienie wykresów.

## **Ustaw precyzję danych w etykietach wykresu**

Ten kod C++ pokazuje, jak ustawić precyzję danych w etykiecie wykresu:

```c++
	// Ścieżka do katalogu dokumentów
	const String outPath = u"../out/SettingPrecisionOfDataLabel_out.pptx";

	// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Pobiera pierwszy slajd
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Dodaje wykres z domyślnymi danymi
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Line, 0, 0, 500, 500);

	// Ustawia format liczb dla serii
	chart->set_HasDataTable( true);
	chart->get_ChartData()->get_Series()->idx_get(0)->set_NumberFormatOfValues (u"#,##0.00");

	// Zapisuje plik prezentacji na dysku
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Wyświetlaj procenty jako etykiety**

Aspose.Slides for C++ umożliwia ustawianie etykiet procentowych na wyświetlanych wykresach. Ten kod C++ demonstruje działanie:

```c++
	// Ścieżka do katalogu dokumentów
	const String outPath = u"../out/DisplayPercentageAsLabels_out.pptx";

	// Tworzy instancję klasy Presentation
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

	// Zapisuje prezentację zawierającą wykres
	presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ustaw znak procenta w etykietach danych wykresu**

Ten kod C++ pokazuje, jak ustawić znak procenta w etykiecie danych wykresu:

```c++
	// Ścieżka do katalogu dokumentów.
	const String outPath = u"../out/DataLabelsPercentageSign_out.pptx";

	// Tworzy instancję klasy Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Pobiera referencję slajdu przez jego indeks
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Tworzy wykres PercentsStackedColumn na slajdzie
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// Ustawia NumberFormatLinkedToSource na false
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource ( false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// Ustawia indeks arkusza danych wykresu
	int defaultWorksheetIndex = 0;

	// Pobiera arkusz danych wykresu
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Usuwa domyślnie wygenerowaną serię 
	chart->get_ChartData()->get_Series()->Clear();
	

	// Dodaje nową serię
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());


	// Pobiera pierwszą serię wykresu
	SharedPtr<IChartSeries> series=chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Red")), chart->get_Type());
	// Wypełnia dane serii
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(0.80)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(0.65)));

	// Ustawia kolor wypełnienia serii
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// Ustawia właściwości LabelFormat
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource ( false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat (u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight ( 10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Pobiera drugą serię wykresu
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Blues")), chart->get_Type());
	// Wypełnia dane serii
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(0.70)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(0.50)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(0.20)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 2, ObjectExt::Box<double>(0.35)));

	// Ustawia kolor wypełnienia serii
	series2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// Ustawia właściwości LabelFormat
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Zapisuje plik prezentacji na dysku
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ustaw odległość etykiety od osi**

Ten kod C++ pokazuje, jak ustawić odległość etykiety od osi kategorii, gdy pracujesz z wykresem rysowanym na osiach:

```c++
	// Ścieżka do katalogu dokumentów
	const String outPath = u"../out/CategoryAxisLabelDistance_out.pptx";

	// Tworzy instancję klasy Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Pobiera referencję slajdu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Tworzy wykres na slajdzie
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// Pobiera kolekcję serii wykresu
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// Ustawia odległość etykiety od osi
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset ( 500);

	// Zapisuje plik prezentacji na dysku
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Dostosuj położenie etykiety**

Gdy tworzysz wykres, który nie opiera się na żadnej osi, np. wykres kołowy, etykiety danych wykresu mogą znajdować się zbyt blisko krawędzi. W takim przypadku należy dostosować położenie etykiety danych, aby linie prowadzące były wyraźnie widoczne.

Ten kod C++ pokazuje, jak dostosować położenie etykiety na wykresie kołowym:

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

**Jak mogę zapobiec nakładaniu się etykiet danych na gęstych wykresach?**

Połącz automatyczne rozmieszczanie etykiet, linie prowadzące oraz zmniejszoną wielkość czcionki; w razie potrzeby ukryj niektóre pola (np. kategorię) lub wyświetlaj etykiety tylko dla skrajnych/kluczowych punktów.

**Jak mogę wyłączyć etykiety tylko dla wartości zerowych, ujemnych lub pustych?**

Przefiltruj punkty danych przed włączeniem etykiet i wyłącz ich wyświetlanie dla wartości 0, wartości ujemnych lub brakujących zgodnie z określoną regułą.

**Jak zapewnić spójny styl etykiet przy eksportowaniu do PDF/obrazów?**

Jawnie ustaw czcionki (rodzina, rozmiar) i zweryfikuj, że czcionka jest dostępna po stronie renderującej, aby uniknąć domyślnego zastąpienia.