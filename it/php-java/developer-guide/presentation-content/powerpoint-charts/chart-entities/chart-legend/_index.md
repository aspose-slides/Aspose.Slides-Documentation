---
title: Personalizza le leggende dei grafici nelle presentazioni usando PHP
linktitle: Legenda del grafico
type: docs
url: /it/php-java/chart-legend/
keywords:
- legenda del grafico
- posizione della leggenda
- dimensione del carattere
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Personalizza le leggende dei grafici con Aspose.Slides per PHP via Java per ottimizzare le presentazioni PowerPoint con una formattazione della leggenda su misura."
---
## **Panoramica**

Aspose.Slides for PHP via Java offre opzioni per personalizzare le legende dei grafici nelle presentazioni PowerPoint. Questo articolo mostra come posizionare e dimensionare una leggenda, impostare la dimensione del carattere per l'intera leggenda, formattare una voce della leggenda individuale e nascondere o ripristinare voci selezionate.

La sezione FAQ copre comportamenti correlati, inclusa la riservazione di spazio per la leggenda, la visualizzazione di etichette multilinea e l'ereditarietà della formattazione dal tema della presentazione.

## **Posizionamento della leggenda**

Utilizza i metodi della leggenda [setX](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/php-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setwidth/) e [setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setheight/) per specificare la sua posizione e dimensione come frazioni delle dimensioni del grafico.

Questo esempio crea una presentazione e aggiunge un grafico a colonne raggruppate con dati predefiniti alla prima diapositiva. Dividendo gli offset e le dimensioni desiderate della leggenda per la larghezza e l'altezza del grafico si ottengono valori relativi: la leggenda è spostata di 50 punti dall'angolo in alto a sinistra del grafico e dimensionata a 100 × 100 punti. L'esempio utilizza java_values per convertire le dimensioni del grafico restituite da PHP/Java Bridge in numeri PHP prima della divisione.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

    $chartWidth = java_values($chart->getWidth());
    $chartHeight = java_values($chart->getHeight());

    // Esprimi la posizione e le dimensioni della leggenda rispetto al grafico.
    $chart->getLegend()->setX(50 / $chartWidth);
    $chart->getLegend()->setY(50 / $chartHeight);
    $chart->getLegend()->setWidth(100 / $chartWidth);
    $chart->getLegend()->setHeight(100 / $chartHeight);

    $presentation->save("legend_position.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Impostare la dimensione del carattere di una leggenda**

Usa il metodo della leggenda [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/gettextformat/) per accedere alla formattazione del testo e [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) per impostare la dimensione del carattere in punti.

Questo esempio crea un grafico con dati predefiniti e imposta il testo della leggenda a 20 punti. Disattiva inoltre i limiti automatici per l'asse verticale e ne imposta l'intervallo da -5 a 10.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);

    $presentation->save("legend_font_size.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Impostare la dimensione del carattere di una voce della leggenda individuale**

Usa la collezione restituita dal metodo [getEntries](https://reference.aspose.com/slides/php-java/aspose.slides/legend/getentries/) della leggenda per accedere alla formattazione di una voce specifica. Gli indici delle voci iniziano da zero, quindi l'indice `1` si riferisce alla seconda voce.

Questo esempio crea un grafico a colonne raggruppate il cui set di dati predefinito include almeno due serie. Formatta la seconda voce della leggenda con testo in grassetto, corsivo e colore blu da 20 punti.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $textFormat = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();

    $textFormat->getPortionFormat()->setFontBold(NullableBool::True);
    $textFormat->getPortionFormat()->setFontHeight(20);
    $textFormat->getPortionFormat()->setFontItalic(NullableBool::True);
    $textFormat->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $textFormat->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("legend_entry_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Nascondere voci della leggenda individuali**

Per escludere una serie ausiliaria dalla leggenda mantenendo visibili i suoi dati, chiama [LegendEntryProperties::setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) con `true` tramite [ChartSeries::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getrelatedlegendentry/). Questo nasconde solo la voce della leggenda selezionata; non rimuove la serie né i suoi punti dati. Al contrario, chiamare [Chart::setLegend](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setlegend/) con `false` nasconde l'intera leggenda.

L'esempio seguente crea un grafico a colonne raggruppate con più serie usando i dati predefiniti. Nasconde la voce della leggenda della seconda serie (indice `1`) e salva la presentazione. Successivamente ripristina la voce chiamando [setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) con `false` e salva una seconda copia. Le colonne rimangono visibili in entrambi i file.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(true);

    $legendEntry = $chart->getChartData()->getSeries()->get_Item(1)->getRelatedLegendEntry();

    $legendEntry->setHide(true);
    $presentation->save("hidden_legend_entry.pptx", SaveFormat::Pptx);

    // Ripristina la stessa voce senza modificare i dati del grafico.
    $legendEntry->setHide(false);
    $presentation->save("restored_legend_entry.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il confronto qui sotto mostra lo stesso grafico con tutte le voci visibili e con la seconda voce nascosta. Le colonne della seconda serie rimangono inalterate.

![Confronto di un grafico con tutte le voci della leggenda visibili e con la Serie 2 nascosta dalla leggenda; tutte le colonne rimangono visibili.](hide-legend-entry.png)

In grafici a colonne, barre e linee, le voci della leggenda identificano le serie. Nei grafici a torta, identificano i singoli punti dati (fette), quindi utilizza [ChartDataPoint::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) sulla fetta selezionata. L'API documenta questo metodo per i tipi di grafico `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` e `BarOfPie`. Non presumere che valga per i grafici a ciambella, che non sono inclusi nell'elenco.

## **FAQ**

**Posso far sì che il grafico riservi spazio per la leggenda invece di sovrapporla?**

Sì. Chiama [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setoverlay/) con `false` per riservare spazio alla leggenda anziché permettere che si sovrapponga all'area del grafico.

**Posso creare etichette della leggenda multilinea?**

Sì. Le etichette lunghe possono andare a capo quando la larghezza disponibile è insufficiente. È inoltre possibile usare caratteri di nuova riga nei nomi delle serie per richiedere interruzioni di linea.

**Come faccio a far sì che la leggenda segua lo schema di colori del tema della presentazione?**

Lascia i colori, i riempimenti e i caratteri della leggenda non impostati in modo che possano ereditare la formattazione del tema. Una formattazione esplicita sovrascrive le impostazioni corrispondenti del tema.