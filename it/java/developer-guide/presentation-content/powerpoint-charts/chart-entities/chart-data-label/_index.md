---
title: Gestisci le etichette dei dati del grafico nelle presentazioni usando Java
linktitle: Etichetta dati
type: docs
url: /it/java/chart-data-label/
keywords:
- grafico
- etichetta dati
- precisione dei dati
- percentuale
- distanza etichetta
- posizione etichetta
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri come aggiungere e formattare le etichette dei dati del grafico nelle presentazioni PowerPoint usando Aspose.Slides per Java per slide più coinvolgenti."
---
## **Introduzione**

Le etichette dei dati mostrano informazioni sulle serie del grafico e sui singoli punti dati, aiutando i lettori a identificare i valori e a comprendere il grafico. Questo articolo spiega come formattare i valori, visualizzare le percentuali, leggere il testo delle etichette, controllare le etichette oltre il massimo dell'asse, regolare la spaziatura delle etichette dell'asse delle categorie e posizionare le etichette nei grafici a torta.

## **Imposta la precisione dei dati nelle etichette del grafico**

Utilizzare [setNumberFormatOfValues](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) per formattare i valori della serie. Questo esempio crea un grafico a linee con dati predefiniti, visualizza la sua tabella dei dati e abilita le etichette dei valori per la prima serie. Il formato `#,##0.00` visualizza un separatore delle migliaia e due cifre decimali senza modificare i valori sottostanti.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Visualizza la percentuale come etichette**

Per un grafico a colonne impilate, calcolare ogni valore come percentuale del totale della sua categoria e assegnare il testo al frame di testo restituito da [getTextFrameForOverriding](https://reference.aspose.com/slides/it/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--). Questo esempio utilizza i dati del grafico predefiniti e visualizza le percentuali con due cifre decimali in un carattere da 8 punti. Le categorie con un totale pari a zero vengono ignorate per evitare divisioni per zero. Ricalcolare il testo personalizzato dell'etichetta se i dati del grafico cambiano.

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400);

    double[] categoryTotals = new double[chart.getChartData().getCategories().size()];
    for (int k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
            IChartSeries series = chart.getChartData().getSeries().get_Item(i);
            Number pointValue = (Number) series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += pointValue.doubleValue();
        }
    }

    for (int x = 0; x < chart.getChartData().getSeries().size(); x++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (int j = 0; j < series.getDataPoints().size(); j++) {
            IDataLabel label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            Number pointValue = (Number) series.getDataPoints().get_Item(j).getValue().getData();
            double dataPointPercent = (pointValue.doubleValue() / categoryTotals[j]) * 100;

            IPortion portion = new Portion();
            portion.setText(String.format(Locale.US, "%.2f %%", dataPointPercent));
            portion.getPortionFormat().setFontHeight(8f);

            label.getTextFrameForOverriding().setText("");
            IParagraph paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Imposta il segno percentuale con le etichette dei dati del grafico**

Quando i valori sono memorizzati come frazioni, utilizzare [setNumberFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) per visualizzare le percentuali. Passare `false` a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/it/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) per applicare il formato dell'etichetta in modo indipendente dalle celle di origine.

Questo esempio crea un grafico a colonne impilate al 100% con serie rossa e blu su quattro categorie. Ogni coppia di valori somma a 1. Il formato dell'etichetta `0.0%` visualizza 0.30 come 30.0%, mentre l'asse verticale utilizza due cifre decimali. Entrambe le serie usano testo etichetta bianco da 10 punti.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    for (int i = 0; i < 4; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    String[] seriesNames = { "Reds", "Blues" };
    Color[] seriesColors = { Color.RED, Color.BLUE };
    double[][] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

    for (int i = 0; i < seriesNames.length; i++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (int j = 0; j < 4; j++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(FillType.Solid);
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        IDataLabelFormat labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Leggi il testo effettivo delle etichette dei dati**

Utilizzare [getActualLabelText](https://reference.aspose.com/slides/it/java/com.aspose.slides/idatalabel/#getActualLabelText--) per recuperare il testo prodotto dalle impostazioni di un'etichetta dati. Ciò è utile quando si estraggono le etichette per report, si cerca contenuto nella presentazione o si convalidano i grafici generati. Nell'esempio seguente, il [formato predefinito delle etichette dati](https://reference.aspose.com/slides/it/java/com.aspose.slides/idatalabelformat/) combina il nome di ciascuna categoria, il nome della serie e il valore. Un punto formatta il valore come percentuale, e un altro utilizza testo personalizzato da [getTextFrameForOverriding](https://reference.aspose.com/slides/it/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    IChartDataCell secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    IChartDataCell northSeriesCell = workbook.getCell(0, 0, 1, "North");
    IChartSeries north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    IChartDataCell northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    IChartDataCell northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    IChartDataCell southSeriesCell = workbook.getCell(0, 0, 2, "South");
    IChartSeries south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    IChartDataCell southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    IChartDataCell southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (IChartSeries series : chart.getChartData().getSeries()) {
        for (IChartDataPoint point : series.getDataPoints()) {
            IDataLabel label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            System.out.println("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

Il numero memorizzato in un punto dati rimane `0.75`, anche quando la sua etichetta mostra `75%` insieme ai nomi di categoria e serie. Il testo personalizzato sostituisce il testo dell'etichetta generato. [getActualLabelText](https://reference.aspose.com/slides/it/java/com.aspose.slides/idatalabel/#getActualLabelText--) restituisce la stringa dell'etichetta risultante in entrambi i casi. Verificare [isVisible](https://reference.aspose.com/slides/it/java/com.aspose.slides/idatalabel/#isVisible--) separatamente, come mostrato sopra, quando si desidera estrarre solo le etichette visibili.

## **Controlla le etichette dei dati oltre il massimo dell'asse**

Quando si limita manualmente l'intervallo di un asse, alcuni punti dati possono superare il suo valore massimo. Utilizzare [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) per controllare se le loro etichette vengono mostrare. Questa impostazione modifica la visibilità delle etichette; non cambia l'intervallo dell'asse né i valori dei dati sottostanti.

L'esempio seguente crea un grafico a colonne raggruppate 2D con valori 60 e 120. Passa `false` a [setAutomaticMaxValue](https://reference.aspose.com/slides/it/java/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) e imposta il massimo a 100 con [setMaxValue](https://reference.aspose.com/slides/it/java/com.aspose.slides/iaxis/#setMaxValue-double-) sull'asse verticale. La prima diapositiva consente etichette oltre il massimo; una copia di quella diapositiva le disabilita. Entrambe le diapositive sono salvate in `DataLabelsOverMaximum.pptx`.

Abilitare le etichette valore con [setShowValue](https://reference.aspose.com/slides/it/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). L'impostazione a livello di grafico non abilita la visualizzazione del valore da sola né sovrascrive la visualizzazione disabilitata di un'etichetta individuale. Questo esempio abilita i valori per l'intera serie e utilizza [setPosition](https://reference.aspose.com/slides/it/java/com.aspose.slides/idatalabelformat/#setPosition-int-) per posizionare le etichette all'estremità esterna di ogni colonna.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    IChartDataCell firstCategory = workbook.getCell(0, 1, 0, "Within range");
    IChartDataCell secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Values");
    IChartSeries series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    IChartDataCell firstValue = workbook.getCell(0, 1, 1, 60);
    IChartDataCell secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    ISlide secondSlide = presentation.getSlides().addClone(slide);
    IChart secondChart = (IChart) secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le immagini seguenti mostrano le diapositive salvate renderizzate da Microsoft PowerPoint. Con `true`, l'etichetta **120** è visibile al limite superiore; con `false`, è nascosta. L'etichetta **60** rimane visibile, il massimo dell'asse resta **100** e il secondo punto dati rimane **120** in entrambi i casi.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![Grafico PowerPoint che mostra l'etichetta del valore 120 con un massimo dell'asse di 100](data-labels-over-maximum-true.png) | ![Grafico PowerPoint che nasconde l'etichetta del valore 120 con un massimo dell'asse di 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}

Questo esempio utilizza un grafico a colonne 2D con asse dei valori. I grafici senza asse dei valori, come i grafici a torta e a ciambella, non hanno un massimo dell'asse da limitare in questo modo.

{{% /alert %}}

## **Imposta la distanza dell'etichetta da un asse**

Utilizzare [setLabelOffset](https://reference.aspose.com/slides/it/java/com.aspose.slides/iaxis/#setLabelOffset-int-) per controllare la distanza tra le etichette dell'asse delle categorie e l'asse stesso. Il valore è una percentuale della dimensione massima del carattere delle etichette dell'asse. Questo esempio crea un grafico a colonne raggruppate e imposta l'offset dell'etichetta dell'asse orizzontale a 500. Questa impostazione influisce sulle etichette dell'asse delle categorie piuttosto che sulle etichette collegate ai singoli punti dati.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Regola la posizione dell'etichetta**

Su un grafico a torta, regolare le posizioni delle etichette dei dati per migliorare la spaziatura e fare spazio alle linee guida.

Questo esempio visualizza il valore del primo punto dati, posiziona la sua etichetta all'esterno della fetta e regola gli offset orizzontali e verticali usando [setX](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutable/#setX-float-) e [setY](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutable/#setY-float-). Questi offset sono relativi alla larghezza e all'altezza del grafico, rispettivamente.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    IDataLabel label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71f);
    label.setY(0.04f);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Grafico a torta con una posizione dell'etichetta dei dati regolata](pie-chart-adjusted-label.png)

## **FAQ**

**Come posso evitare che le etichette dei dati si sovrappongano in grafici densi?**

Combinare la posizione automatica delle etichette, le linee guida e una riduzione della dimensione del carattere; se necessario, nascondere alcuni campi (ad esempio la categoria) o mostrare le etichette solo per i valori estremi o i punti chiave.

**Come posso disabilitare le etichette solo per valori zero, negativi o vuoti?**

Filtrare i punti dati prima di abilitare le etichette e disattivare la visualizzazione per i valori pari a 0, per i valori negativi o per i valori mancanti secondo una regola definita.

**Come posso garantire uno stile di etichetta coerente durante l'esportazione in PDF/immagini?**

Impostare esplicitamente la famiglia e la dimensione del carattere e verificare che il font sia disponibile nell'ambiente di rendering per evitare il fallback.