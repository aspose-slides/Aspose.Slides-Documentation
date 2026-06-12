---
title: Gestisci le etichette dati del grafico nelle presentazioni usando C++
linktitle: Etichetta dati
type: docs
url: /it/cpp/chart-data-label/
keywords:
- grafico
- etichetta dati
- precisione dati
- percentuale
- distanza etichetta
- posizione etichetta
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Impara ad aggiungere e formattare le etichette dati del grafico nelle presentazioni PowerPoint usando Aspose.Slides per C++ per slide più coinvolgenti."
---
## **Introduzione**

Le etichette dati su un grafico mostrano i dettagli relativi alla serie di dati del grafico o ai singoli punti dati. Consentono ai lettori di identificare rapidamente le serie di dati e rendono i grafici più facili da comprendere.

## **Imposta la precisione dei dati nelle etichette del grafico**

Questo codice C++ mostra come impostare la precisione dei dati in un'etichetta del grafico:

```c++
	// Il percorso della directory dei documenti
	const String outPath = u"../out/SettingPrecisionOfDataLabel_out.pptx";

	// Istanzia una classe Presentation che rappresenta un file PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Ottiene la prima diapositiva
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Aggiunge un grafico con dati predefiniti
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Line, 0, 0, 500, 500);

	// Imposta il formato numerico della serie
	chart->set_HasDataTable( true);
	chart->get_ChartData()->get_Series()->idx_get(0)->set_NumberFormatOfValues (u"#,##0.00");

	// Scrive il file di presentazione su disco
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Visualizza le percentuali come etichette**
Aspose.Slides per C++ consente di impostare etichette percentuali sui grafici visualizzati. Questo codice C++ dimostra l'operazione:

```c++
	// Il percorso della directory dei documenti
	const String outPath = u"../out/DisplayPercentageAsLabels_out.pptx";

	// Crea un'istanza della classe Presentation
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

	// Salva la presentazione contenente il grafico
	presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Imposta il segno percentuale con le etichette dei dati del grafico**
Questo codice C++ mostra come impostare il segno percentuale per un'etichetta dati del grafico:

```c++
	// Il percorso della directory dei documenti.
	const String outPath = u"../out/DataLabelsPercentageSign_out.pptx";

	// Crea un'istanza della classe Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Ottiene il riferimento di una diapositiva tramite il suo indice
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Crea il grafico PercentsStackedColumn su una diapositiva
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// Imposta NumberFormatLinkedToSource su false
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource ( false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// Imposta l'indice del foglio dati del grafico
	int defaultWorksheetIndex = 0;

	// Ottiene il foglio di lavoro dei dati del grafico
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Elimina la serie generata per impostazione predefinita
	chart->get_ChartData()->get_Series()->Clear();
	

	// Aggiunge una nuova serie
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());


	// Prende la prima serie del grafico
	SharedPtr<IChartSeries> series=chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Red")), chart->get_Type());
	// Popola i dati della serie
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(0.80)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(0.65)));

	// Imposta il colore di riempimento per la serie
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// Imposta le proprietà di LabelFormat
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource ( false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat (u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight ( 10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Prende la seconda serie del grafico
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Blues")), chart->get_Type());
	// Popola i dati della serie
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(0.70)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(0.50)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(0.20)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 2, ObjectExt::Box<double>(0.35)));

	// Imposta il colore di riempimento per la serie
	series2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// Imposta le proprietà di LabelFormat
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Scrive il file della presentazione su disco
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Imposta la distanza dell'etichetta dall'asse**
Questo codice C++ mostra come impostare la distanza dell'etichetta da un asse di categoria quando si lavora con un grafico tracciato da assi:

```c++
	// Il percorso della directory dei documenti
	const String outPath = u"../out/CategoryAxisLabelDistance_out.pptx";

	// Crea un'istanza della classe Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Ottiene il riferimento di una diapositiva
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Crea un grafico sulla diapositiva
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// Ottiene la collezione di serie del grafico
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// Imposta la distanza dell'etichetta dall'asse
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset ( 500);

	// Scrive il file della presentazione su disco
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Regola la posizione dell'etichetta**

Quando crei un grafico che non si basa su alcun asse, come un grafico a torta, le etichette dati del grafico potrebbero finire troppo vicine al suo bordo. In tal caso, è necessario regolare la posizione dell'etichetta dati affinché le linee guida vengano visualizzate chiaramente.

Questo codice C++ mostra come regolare la posizione dell'etichetta su un grafico a torta:

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

**Come posso evitare che le etichette dati si sovrappongano su grafici densi?**

Combina il posizionamento automatico delle etichette, le linee guida e una riduzione della dimensione del carattere; se necessario, nascondi alcuni campi (ad esempio, la categoria) o mostra le etichette solo per i punti estremi/chiave.

**Come posso disabilitare le etichette solo per valori zero, negativi o vuoti?**

Filtra i punti dati prima di abilitare le etichette e disattiva la visualizzazione per valori pari a 0, valori negativi o valori mancanti secondo una regola definita.

**Come posso garantire uno stile coerente delle etichette esportando in PDF/immagini?**

Imposta esplicitamente i font (famiglia, dimensione) e verifica che il font sia disponibile sul lato di rendering per evitare il fallback.