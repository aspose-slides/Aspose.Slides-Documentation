---
title: Personalizza gli assi dei grafici nelle presentazioni con C++
linktitle: Asse del grafico
type: docs
url: /it/cpp/chart-axis/
keywords:
- asse del grafico
- asse verticale
- asse orizzontale
- personalizzare l'asse
- manipolare l'asse
- gestire l'asse
- proprietà dell'asse
- valore massimo
- valore minimo
- linea dell'asse
- formato data
- titolo dell'asse
- posizione dell'asse
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Scopri come utilizzare Aspose.Slides per C++ per personalizzare gli assi dei grafici nelle presentazioni PowerPoint per report e visualizzazioni."
---
## **Panoramica**

Questo articolo spiega come personalizzare gli assi dei grafici in Aspose.Slides. Mostra come ottenere i valori effettivi degli assi, scambiare i dati tra gli assi, nascondere l'asse verticale o orizzontale per i grafici a linee, modificare il tipo di asse delle categorie, impostare il formato data per i valori dell'asse delle categorie, ruotare il titolo di un asse, impostare la posizione dell'asse e visualizzare un'etichetta di unità sull'asse dei valori.

## **Ottenere i valori massimi sull'asse verticale**
Aspose.Slides per C++ consente di ottenere i valori minimo e massimo su un asse verticale. Segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
2. Accedi alla prima diapositiva.
3. Aggiungi un grafico con i dati predefiniti.
4. Ottieni il valore massimo effettivo sull'asse.
5. Ottieni il valore minimo effettivo sull'asse.
6. Ottieni l'unità principale effettiva dell'asse.
7. Ottieni l'unità secondaria effettiva dell'asse.
8. Ottieni la scala dell'unità principale effettiva dell'asse.
9. Ottieni la scala dell'unità secondaria effettiva dell'asse.

Questo codice di esempio — un'implementazione dei passaggi precedenti — mostra come ottenere i valori richiesti in C++:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = System::ExplicitCast<Chart>(shapes->AddChart(ChartType::Area, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

auto axes = chart->get_Axes();

double maxValue = axes->get_VerticalAxis()->get_ActualMaxValue();
double minValue = axes->get_VerticalAxis()->get_ActualMinValue();

double majorUnit = axes->get_HorizontalAxis()->get_ActualMajorUnit();
double minorUnit = axes->get_HorizontalAxis()->get_ActualMinorUnit();

// Salva la presentazione
pres->Save(u"ErrorBars_out.pptx", SaveFormat::Pptx);
```

## **Scambiare i dati tra gli assi**
Aspose.Slides consente di scambiare rapidamente i dati tra gli assi — i dati rappresentati sull'asse verticale (asse y) vengono spostati sull'asse orizzontale (asse x) e viceversa.

Questo codice C++ mostra come eseguire l'operazione di scambio dei dati tra gli assi in un grafico:

``` cpp
// Crea una presentazione vuota
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// Scambia righe e colonne
chart->get_ChartData()->SwitchRowColumn();

// Salva la presentazione
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **Disabilitare l'asse verticale per i grafici a linee**

Questo codice C++ mostra come nascondere l'asse verticale per un grafico a linee:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Disabilitare l'asse orizzontale per i grafici a linee**

Questo codice mostra come nascondere l'asse orizzontale per un grafico a linee:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Modificare un asse delle categorie**

Utilizzando il metodo **set_CategoryAxisType()**, è possibile specificare il tipo di asse delle categorie desiderato (**date** o **text**). Questo codice in C++ dimostra l'operazione:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto chart = System::AsCast<IChart>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();

horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsAutomaticMajorUnit(false);
horizontalAxis->set_MajorUnit(1);
horizontalAxis->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **Impostare il formato data per i valori dell'asse delle categorie**
Aspose.Slides per C++ consente di impostare il formato data per un valore dell'asse delle categorie. L'operazione è dimostrata in questo codice C++:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Area, 50.0f, 50.0f, 450.0f, 300.0f);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

wb->Clear(0);

chart->get_ChartData()->get_Series()->Clear();
auto areaCategories = chart->get_ChartData()->get_Categories();
areaCategories->Clear();
areaCategories->Add(wb->GetCell(0, u"A2", ObjectExt::Box<double>(DateTime(2015, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A3", ObjectExt::Box<double>(DateTime(2016, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A4", ObjectExt::Box<double>(DateTime(2017, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A5", ObjectExt::Box<double>(DateTime(2018, 1, 1).ToOADate())));

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto dataPoints = series->get_DataPoints();
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B2", ObjectExt::Box<int32_t>(1)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B3", ObjectExt::Box<int32_t>(2)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B4", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B5", ObjectExt::Box<int32_t>(4)));

auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsNumberFormatLinkedToSource(false);
horizontalAxis->set_NumberFormat(u"yyyy");

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **Impostare l'angolo di rotazione per il titolo di un asse**
Aspose.Slides per C++ consente di impostare l'angolo di rotazione per il titolo di un asse del grafico. Questo codice C++ dimostra l'operazione:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **Impostare la posizione dell'asse su un asse delle categorie o dei valori**
Aspose.Slides per C++ consente di impostare la posizione dell'asse su un asse delle categorie o dei valori. Questo codice C++ mostra come eseguire l'operazione:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **Abilitare la visualizzazione dell'etichetta di unità su un asse dei valori del grafico**
Aspose.Slides per C++ consente di configurare un grafico per mostrare un'etichetta di unità sul suo asse dei valori. Questo codice C++ dimostra l'operazione:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Come impostare il valore al quale un asse incrocia l'altro (incrocio degli assi)?**

Le assi offrono una [impostazione di incrocio](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/axis/set_crosstype/): è possibile scegliere di incrociare a zero, al valore massimo della categoria/valore, o a un valore numerico specifico. Questo è utile per spostare l'asse X verso l'alto o verso il basso o per evidenziare una linea di base.

**Come posizionare le etichette di graduazione rispetto all'asse (accanto, fuori, dentro)?**

Imposta la [posizione dell'etichetta](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/axis/set_majortickmark/) su "cross", "outside" o "inside". Questo influisce sulla leggibilità e aiuta a risparmiare spazio, specialmente sui grafici di piccole dimensioni.