---
title: Gestire le serie di dati dei grafici nelle presentazioni usando C++
linktitle: Serie di dati
type: docs
url: /it/cpp/chart-series/
keywords:
- serie di grafico
- sovrapposizione serie
- colore serie
- colore categoria
- nome serie
- punto dati
- intervallo serie
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Scopri come gestire le serie di grafici in C++ per PowerPoint (PPT/PPTX) con esempi di codice pratici e migliori pratiche per migliorare le tue presentazioni di dati."
---
## **Panoramica**

Questo articolo descrive il ruolo di [ChartSeries](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/chartseries/) in Aspose.Slides, concentrandosi su come i dati sono strutturati e visualizzati nelle presentazioni. Questi oggetti forniscono gli elementi di base che definiscono insiemi individuali di punti dati, categorie e parametri di aspetto in un grafico. Lavorando con [ChartSeries](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/chartseries/), gli sviluppatori possono integrare senza problemi le fonti dati sottostanti e mantenere il pieno controllo su come le informazioni vengono visualizzate, ottenendo presentazioni dinamiche e guidate dai dati che comunicano chiaramente intuizioni e analisi.

Una serie è una riga o una colonna di numeri tracciata in un grafico.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Impostare la sovrapposizione della serie di dati**

Con il metodo [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb) è possibile specificare quanto le barre e le colonne devono sovrapporsi in un grafico 2D (intervallo: -100 a 100). Questa proprietà si applica a tutte le serie del gruppo di serie padre: è una proiezione della proprietà di gruppo appropriata.

Utilizzare il metodo `get_ParentSeriesGroup()::set_Overlap()` per impostare il valore desiderato per `Overlap`.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
1. Aggiungere un grafico a colonne raggruppate su una diapositiva.
1. Accedere alla prima serie del grafico.
1. Accedere a `ParentSeriesGroup` della serie e impostare il valore di sovrapposizione desiderato.
1. Scrivere la presentazione modificata in un file PPTX.

Questo codice C++ mostra come impostare la sovrapposizione per una serie di grafico:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Adds chart
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // Imposta la sovrapposizione della serie
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// Writes the presentation file to disk
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **Modificare il colore della serie di dati**

Aspose.Slides per C++ consente di modificare il colore di una serie in questo modo:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
1. Aggiungere un grafico alla diapositiva.
1. Accedere alla serie di cui si desidera cambiare il colore.
1. Impostare il tipo di riempimento e il colore di riempimento desiderati.
1. Salvare la presentazione modificata.

Questo codice C++ mostra come modificare il colore di una serie:

```cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Pie, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(1);

point->set_Explosion(30);
point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Modificare il colore di una categoria della serie di dati**

Aspose.Slides per C++ consente di modificare il colore di una categoria di serie in questo modo:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
1. Aggiungere un grafico alla diapositiva.
1. Accedere alla categoria della serie di cui si desidera cambiare il colore.
1. Impostare il tipo di riempimento e il colore di riempimento desiderati.
1. Salvare la presentazione modificata.

Questo codice C++ mostra come modificare il colore di una categoria della serie:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Modificare il nome della serie di dati**

Per impostazione predefinita, i nomi della legenda di un grafico sono i contenuti delle celle sopra ogni colonna o riga di dati.

Nel nostro esempio (immagine di esempio),

* le colonne sono *Series 1, Series 2,* e *Series 3*;
* le righe sono *Category 1, Category 2, Category 3,* e *Category 4*.

Aspose.Slides per C++ consente di aggiornare o modificare il nome di una serie nei dati del grafico e nella legenda.

Questo codice C++ mostra come modificare il nome di una serie nei dati del grafico `ChartDataWorkbook`:

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

Questo codice C++ mostra come modificare il nome di una serie nella legenda tramite `Series`:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```

## **Impostare il colore di riempimento della serie di dati**

Aspose.Slides per C++ consente di impostare il colore di riempimento automatico per le serie di grafico all'interno dell'area di tracciamento in questo modo:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
1. Ottenere il riferimento di una diapositiva tramite il suo indice.
1. Aggiungere un grafico con dati predefiniti basato sul tipo desiderato (nell'esempio sotto, abbiamo usato `ChartType::ClusteredColumn`).
1. Accedere alla serie del grafico e impostare il colore di riempimento su Automatic.
1. Salvare la presentazione in un file PPTX.

Questo codice C++ mostra come impostare il colore di riempimento automatico per una serie di grafico:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Crea un grafico a colonne raggruppate
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// Imposta il formato di riempimento della serie su automatico
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// Scrive il file della presentazione su disco
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **Impostare la serie di dati con inversione dei colori di riempimento**

Aspose.Slides consente di impostare l'inversione del colore di riempimento per le serie di grafico all'interno dell'area di tracciamento in questo modo:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
1. Ottenere il riferimento di una diapositiva tramite il suo indice.
1. Aggiungere un grafico con dati predefiniti basato sul tipo desiderato (nell'esempio sotto, abbiamo usato `ChartType::ClusteredColumn`).
1. Accedere alla serie del grafico e impostare il colore di riempimento su invert.
1. Salvare la presentazione in un file PPTX.

Questo codice C++ dimostra l'operazione:

```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// Adds new series and categories
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Takes the first chart series and populates its series data.
auto series = chartData->get_Series()->idx_get(0);
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 1, 1, ObjectExt::Box<int32_t>(-20)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 2, 1, ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 3, 1, ObjectExt::Box<int32_t>(-30)));
Color seriesColor = series->GetAutomaticSeriesColor();
series->set_InvertIfNegative(true);
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);
series->get_InvertedSolidFillColor()->set_Color(inverColor);
pres->Save(u"SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
```

## **Impostare l'inversione del colore di riempimento per una serie di grafico**

Aspose.Slides consente di impostare l'inversione tramite i metodi `IChartDataPoint::set_InvertIfNegative()` e `ChartDataPoint.set_InvertIfNegative()`. Quando l'inversione è impostata con questi metodi, il punto dati inverte i colori quando riceve un valore negativo.

Questo codice C++ dimostra l'operazione:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
chart->get_ChartData()->get_Series()->Clear();

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
series->Add(workBook->GetCell(0, u"B1"), chart->get_Type());
auto dataPoints = series->idx_get(0)->get_DataPoints();
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B2", ObjectExt::Box<int32_t>(-5)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B3", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B4", ObjectExt::Box<int32_t>(-2)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B5", ObjectExt::Box<int32_t>(1)));

series->idx_get(0)->set_InvertIfNegative(false);

series->idx_get(0)->get_DataPoints()->idx_get(2)->set_InvertIfNegative(true);

pres->Save(u"out.pptx", SaveFormat::Pptx);
```

## **Cancella i valori di punti dati specifici**

Aspose.Slides per C++ consente di cancellare i dati `DataPoints` per una serie di grafico specifica in questo modo:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
2. Ottenere il riferimento di una diapositiva tramite il suo indice.
3. Ottenere il riferimento di un grafico tramite il suo indice.
4. Iterare tutti i `DataPoints` del grafico e impostare `XValue` e `YValue` su null.
5. Cancellare tutti i `DataPoints` per la serie di grafico specifica.
6. Scrivere la presentazione modificata in un file PPTX.

Questo codice C++ dimostra l'operazione:

```cpp
auto pres = System::MakeObject<Presentation>(u"TestChart.pptx");
auto sl = pres->get_Slides()->idx_get(0);

auto chart = System::ExplicitCast<IChart>(sl->get_Shapes()->idx_get(0));
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

for (const auto& dataPoint : dataPoints)
{
    dataPoint->get_XValue()->get_AsCell()->set_Value(nullptr);
    dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);
}

dataPoints->Clear();

pres->Save(u"ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
```

## **Impostare la larghezza dello spazio tra le serie di dati**

Aspose.Slides per C++ consente di impostare la larghezza dello spazio (`GapWidth`) di una serie tramite il metodo **`set_GapWidth()`** in questo modo:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
1. Accedere alla prima diapositiva.
1. Aggiungere un grafico con dati predefiniti.
1. Accedere a una qualsiasi serie del grafico.
1. Impostare la proprietà `GapWidth`.
1. Scrivere la presentazione modificata in un file PPTX.

Questo codice C++ mostra come impostare la larghezza dello spazio per una serie:

```cpp
// Crea una presentazione vuota 
// Accede alla prima diapositiva della presentazione
// Aggiunge un grafico con dati predefiniti
// Imposta l'indice del foglio dati del grafico
// Ottiene il foglio dati del grafico
// Aggiunge le serie
// Aggiunge le categorie
// Prende la seconda serie del grafico
// Popola i dati della serie
// Imposta il valore di GapWidth
// Salva la presentazione su disco
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);
int32_t worksheetIndex = 0;
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));
series->get_ParentSeriesGroup()->set_GapWidth(50);
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Esiste un limite al numero di serie che un singolo grafico può contenere?**

Aspose.Slides non impone un limite fisso al numero di serie aggiunte. Il limite pratico è determinato dalla leggibilità del grafico e dalla memoria disponibile per l'applicazione.

**Cosa succede se le colonne all'interno di un gruppo sono troppo vicine o troppo distanti?**

Regolare l'impostazione della larghezza dello spazio per quella serie (o per il suo gruppo di serie padre). Aumentare il valore amplia lo spazio tra le colonne, mentre diminuirlo le avvicina.