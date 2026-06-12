---
title: Ottimizza i calcoli dei grafici per le presentazioni in C++
linktitle: Calcoli del grafico
type: docs
weight: 50
url: /it/cpp/chart-calculations/
keywords:
- calcoli del grafico
- elementi del grafico
- posizione dell'elemento
- posizione reale
- elemento figlio
- elemento genitore
- valori del grafico
- valore reale
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Comprendi i calcoli dei grafici, gli aggiornamenti dei dati e il controllo di precisione in Aspose.Slides per C++ per PPT e PPTX, con esempi pratici di codice C++."
---
## **Panoramica**

Aspose.Slides fornisce API per lavorare con i calcoli dei grafici e i dati di layout nelle presentazioni. Questo articolo mostra come recuperare i valori effettivi degli elementi del grafico, inclusa la posizione reale e le dimensioni degli elementi che implementano `IActualLayout` e i valori effettivi degli assi del grafico. Spiega inoltre che questi valori vengono popolati dopo la convalida del layout del grafico.

Inoltre, l'articolo dimostra come ottenere la posizione reale degli elementi grafico genitore e come nascondere componenti del grafico come il titolo, gli assi, la legenda e le linee della griglia. Insieme, questi esempi ti aiutano a ispezionare le informazioni di layout del grafico e a controllare la visibilità degli elementi del grafico nelle presentazioni PowerPoint in modo programmatico.

## **Calcolare i valori effettivi degli elementi del grafico**
Aspose.Slides per C++ fornisce un'API semplice per ottenere queste proprietà. Questo ti aiuterà a calcolare i valori effettivi degli elementi del grafico. I valori effettivi includono la posizione degli elementi che implementano l'interfaccia IActualLayout (IActualLayout::get_ActualX(), IActualLayout::get_ActualY(), IActualLayout::get_ActualWidth(), IActualLayout::get_ActualHeight()) e i valori effettivi degli assi (IAxis::get_ActualMaxValue(), IAxis::get_ActualMinValue(), IAxis::get_ActualMajorUnit(), IAxis::get_ActualMinorUnit(), IAxis::get_ActualMajorUnitScale(), IAxis::get_ActualMinorUnitScale()).

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Salvataggio della presentazione
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **Calcolare la posizione reale degli elementi grafico genitore**
Aspose.Slides per C++ fornisce un'API semplice per ottenere queste proprietà. I metodi di IActualLayout forniscono informazioni sulla posizione reale dell'elemento grafico genitore. È necessario chiamare il metodo IChart::ValidateChartLayout() in precedenza per popolare le proprietà con i valori effettivi.

``` cpp
// Creazione di una presentazione vuota
auto pres = System::MakeObject<Presentation>();

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();
```

## **Nascondere gli elementi del grafico**
Questo argomento ti aiuta a capire come nascondere le informazioni da un grafico. Utilizzando Aspose.Slides per C++ puoi nascondere **Titolo, Asse verticale, Asse orizzontale** e **Linee della griglia** dal grafico. Il seguente esempio di codice mostra come utilizzare queste proprietà.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **Impostare un intervallo di dati per un grafico**
Aspose.Slides per C++ ha fornito l'API più semplice per impostare l'intervallo di dati di un grafico nel modo più facile. Per impostare l'intervallo di dati di un grafico:

- Apri un'istanza della classe Presentation che contiene il grafico.
- Ottieni il riferimento di una diapositiva usando il suo indice.
- Scorri tutte le forme per trovare il grafico desiderato.
- Accedi ai dati del grafico e imposta l'intervallo.
- Salva la presentazione modificata come file PPTX.

Gli esempi di codice seguenti mostrano come aggiornare un grafico.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}

## **FAQ**

**Le cartelle di lavoro Excel esterne funzionano come origine dati e come influiscono sul ricalcolo?**

Sì. Un grafico può fare riferimento a una cartella di lavoro esterna: quando colleghi o aggiorni la sorgente esterna, le formule e i valori vengono prelevati da quella cartella di lavoro e il grafico riflette gli aggiornamenti durante le operazioni di apertura/modifica. L'API consente di [specificare il percorso della cartella di lavoro esterna](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) e gestire i dati collegati.

**Posso calcolare e visualizzare le linee di tendenza senza implementare io stesso la regressione?**

Sì. Le [linee di tendenza](/slides/it/cpp/trend-line/) (lineari, esponenziali e altre) sono aggiunte e aggiornate da Aspose.Slides; i loro parametri vengono ricalcolati automaticamente dai dati delle serie, quindi non è necessario implementare i propri calcoli.

**Se una presentazione contiene più grafici con collegamenti esterni, posso controllare quale cartella di lavoro utilizza ciascun grafico per i valori calcolati?**

Sì. Ogni grafico può puntare a una propria [cartella di lavoro esterna](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/chartdata/setexternalworkbook/), oppure è possibile creare/sostituire una cartella di lavoro esterna per ogni grafico in modo indipendente dalle altre.