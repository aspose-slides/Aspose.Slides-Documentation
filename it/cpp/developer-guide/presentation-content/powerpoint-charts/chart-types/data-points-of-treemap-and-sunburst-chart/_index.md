---
title: Personalizza i punti dati nei grafici Treemap e Sunburst usando C++
linktitle: Punti dati nei grafici Treemap e Sunburst
type: docs
url: /it/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- grafico treemap
- grafico sunburst
- punto dati
- colore etichetta
- colore ramo
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Scopri come gestire i punti dati nei grafici treemap e sunburst con Aspose.Slides per C++, compatibile con i formati PowerPoint."
---
## **Introduzione**

Tra gli altri tipi di grafici PowerPoint, esistono due tipi “gerarchici” - **Treemap** e **Sunburst** (noti anche come Grafico Sunburst, Diagramma Sunburst, Grafico Radiale, Grafico Radiale o Grafico a Torta Multi Livello). Questi grafici visualizzano dati gerarchici organizzati come un albero, dalle foglie fino alla parte superiore del ramo. Le foglie sono definite dai punti dati della serie, e ogni successivo livello di raggruppamento nidificato è definito dalla corrispondente categoria. Aspose.Slides per C++ consente di formattare i punti dati del grafico Sunburst e Treemap in C++.

Here is a Sunburst Chart, where data in Series1 column define the leaf nodes, while other columns define hierarchical datapoints:
![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Cominciamo aggiungendo un nuovo grafico Sunburst alla presentazione:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```

{{% alert color="primary" title="Vedi anche" %}} 
- [**Creare grafico Sunburst**](/slides/it/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}

Se è necessario formattare i punti dati del grafico, dovremmo utilizzare i seguenti:
Le classi [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/), [**IChartDataPointLevel**](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdatapointlevel/) e il metodo [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) forniscono l'accesso per formattare i punti dati dei grafici Treemap e Sunburst.  
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) è utilizzato per accedere a categorie a più livelli - rappresenta il contenitore degli oggetti [**IChartDataPointLevel**](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdatapointlevel/).  
Fondamentalmente è un wrapper per [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartcategorylevelsmanager/) con le proprietà aggiunte specifiche per i punti dati.  
La classe [**IChartDataPointLevel**](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdatapointlevel/) ha due metodi: [**get_Format()**](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdatapointlevel/get_format/) e [**get_Label()**](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdatapointlevel/get_label/) che forniscono l'accesso alle impostazioni corrispondenti.

## **Mostra il valore di un punto dati**
Mostra il valore del punto dati "Leaf 4":

``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Imposta etichetta e colore di un punto dati**
Imposta l'etichetta dati di "Branch 1" per mostrare il nome della serie ("Series1") invece del nome della categoria. Quindi imposta il colore del testo su giallo:

``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Imposta il colore del ramo del punto dati**

Cambia il colore del ramo "Stem 4":

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

auto stem4branch = dataPoints->idx_get(9)->get_DataPointLevels()->idx_get(1);
stem4branch->get_Format()->get_Fill()->set_FillType(FillType::Solid);
stem4branch->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Posso cambiare l'ordine (ordinamento) dei segmenti in Sunburst/Treemap?**

No. PowerPoint ordina i segmenti automaticamente (tipicamente per valori decrescenti, in senso orario). Aspose.Slides rispecchia questo comportamento: non è possibile modificare direttamente l'ordine; è necessario farlo pre-elaborando i dati.

**Come influisce il tema della presentazione sui colori dei segmenti e delle etichette?**

I colori del grafico ereditano il [tema/palette](/slides/it/cpp/presentation-theme/) della presentazione, a meno che non impostiate esplicitamente riempimenti/fondamenti dei caratteri. Per risultati coerenti, fissate riempimenti solidi e formattazioni del testo ai livelli richiesti.

**L'esportazione in PDF/PNG preserva i colori personalizzati dei rami e le impostazioni delle etichette?**

Sì. Durante l'esportazione della presentazione, le impostazioni del grafico (riempimenti, etichette) vengono mantenute nei formati di output perché Aspose.Slides rende il grafico con la formattazione applicata.

**Posso calcolare le coordinate effettive di un'etichetta/elemento per posizionare un overlay personalizzato sopra il grafico?**

Sì. Dopo che il layout del grafico è stato convalidato, le coordinate X reale e Y reale sono disponibili per gli elementi (ad esempio, un [DataLabel](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/datalabel/)), il che aiuta a posizionare con precisione gli overlay.