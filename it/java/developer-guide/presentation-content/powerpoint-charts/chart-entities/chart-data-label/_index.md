---
title: Gestire le etichette dei dati del grafico nelle presentazioni con Java
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
description: "Scopri come aggiungere e formattare le etichette dei dati del grafico nelle presentazioni PowerPoint utilizzando Aspose.Slides per Java per slide più coinvolgenti."
---
## **Introduzione**

I data label visualizzano informazioni sulle serie del grafico e sui singoli punti dati, aiutando i lettori a identificare i valori e a comprendere il grafico. Questo articolo spiega come formattare i valori, visualizzare le percentuali, leggere il testo dell'etichetta, controllare le etichette oltre il valore massimo dell'asse, regolare la spaziatura delle etichette dell'asse delle categorie e posizionare le etichette dei grafici a torta.

## **Imposta la precisione dei dati nelle etichette dei grafici**

Usa [setNumberFormatOfValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) per formattare i valori delle serie. Questo esempio crea un grafico a linee con dati predefiniti, visualizza la sua tabella dati e abilita le etichette dei valori per la prima serie. Il formato `#,##0.00` visualizza un separatore delle migliaia e due decimali senza modificare i valori sottostanti.

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

Per un grafico a colonne impilate, calcola ogni valore come percentuale del totale della sua categoria e assegna il testo al riquadro di testo restituito da [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--). Questo esempio utilizza i dati predefiniti del grafico e visualizza le percentuali con due decimali in un carattere da 8 punti. Le categorie con un totale pari a zero vengono ignorate per evitare la divisione per zero. Ricalcola il testo dell'etichetta personalizzata se i dati del grafico cambiano.

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

## **Imposta il simbolo percentuale con le etichette dei dati del grafico**

Quando i valori sono memorizzati come frazioni, usa [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) per visualizzare le percentuali. Passa `false` a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) per applicare il formato dell'etichetta in modo indipendente dalle celle di origine.

Questo esempio crea un grafico a colonne impilate al 100% con serie rosse e blu su quattro categorie. Ogni coppia di valori somma a 1. Il formato dell'etichetta `0.0%` visualizza 0,30 come 30,0%, mentre l'asse verticale utilizza due decimali. Entrambe le serie usano un testo dell'etichetta bianco, di 10 punti.

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

Usa [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) per recuperare il testo prodotto dalle impostazioni di un'etichetta dati. Questo è utile quando si estraggono le etichette per i report, si ricerca il contenuto della presentazione o si convalidano i grafici generati. Nell'esempio sotto, il [formato predefinito delle etichette dati](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/) combina il nome di ciascuna categoria, il nome della serie e il valore. Un punto formatta il suo valore come percentuale, e un altro usa testo personalizzato da [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--).

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

Il numero memorizzato in un punto dati rimane `0.75`, anche quando la sua etichetta mostra `75%` insieme ai nomi di categoria e di serie. Il testo personalizzato sostituisce il testo dell'etichetta generato. [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) restituisce la stringa dell'etichetta risultante in entrambi i casi. Controlla [isVisible](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#isVisible--) separatamente, come mostrato sopra, quando vuoi estrarre solo le etichette visibili.

## **Controlla le etichette dei dati oltre il valore massimo dell'asse**

Quando limiti manualmente l'intervallo di un asse, alcuni punti dati possono superare il suo valore massimo. Usa [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) per controllare se le loro etichette dati vengono visualizzate. Questa impostazione modifica la visibilità delle etichette; non modifica l'intervallo dell'asse né i valori dei dati sottostanti.

L'esempio seguente crea un grafico a colonne raggruppate 2D con valori 60 e 120. Passa `false` a [setAutomaticMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) e imposta il massimo a 100 con [setMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMaxValue-double-) sull'asse verticale. La prima diapositiva consente etichette oltre il massimo; una copia di quella diapositiva le disabilita. Entrambe le diapositive vengono salvate in `DataLabelsOverMaximum.pptx`.

Abilita le etichette dei valori con [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). L'impostazione a livello di grafico non abilita la visualizzazione dei valori di per sé né sovrascrive la visualizzazione dei valori disabilitata per un'etichetta individuale. Questo esempio abilita i valori per l'intera serie e usa [setPosition](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setPosition-int-) per posizionare le etichette all'estremità esterna di ogni colonna.

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

Le immagini seguenti mostrano le diapositive salvate renderizzate da Microsoft PowerPoint. Con `true`, l'etichetta **120** è visibile al limite superiore; con `false`, è nascosta. L'etichetta **60** rimane visibile, il valore massimo dell'asse resta **100** e il secondo punto dati rimane **120** in entrambi i casi.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![Grafico PowerPoint che mostra l'etichetta valore 120 con un valore massimo dell'asse di 100](data-labels-over-maximum-true.png) | ![Grafico PowerPoint che nasconde l'etichetta valore 120 con un valore massimo dell'asse di 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Questo esempio utilizza un grafico a colonne 2D con un asse dei valori. I grafici senza un asse dei valori, come i grafici a torta e a ciambella, non hanno un valore massimo dell'asse da limitare in questo modo.
{{% /alert %}}

## **Imposta la distanza dell'etichetta dall'asse**

Usa [setLabelOffset](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setLabelOffset-int-) per controllare la distanza tra le etichette dell'asse delle categorie e l'asse. Il valore è una percentuale della dimensione massima del carattere delle etichette dell'asse. Questo esempio crea un grafico a colonne raggruppate e imposta l'offset delle etichette dell'asse orizzontale a 500. Questa impostazione influisce sulle etichette dell'asse delle categorie piuttosto che sulle etichette collegate a singoli punti dati.

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

In un grafico a torta, regola le posizioni delle etichette dei dati per migliorare la spaziatura e creare spazio per le linee guida.

Questo esempio visualizza il valore del primo punto dati, posiziona la sua etichetta all'esterno della fetta e regola gli offset orizzontali e verticali usando [setX](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setX-float-) e [setY](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setY-float-). Questi offset sono relativi alla larghezza e all'altezza del grafico, rispettivamente.

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

![Grafico a torta con una posizione dell'etichetta dati regolata](pie-chart-adjusted-label.png)

## **Aggiungi più righe di etichette dei dati sopra un grafico a colonne**

Questo esempio crea un grafico a colonne con due righe di etichette dei dati sopra l'area del grafico. La Serie A visualizza le colonne visibili, mentre le Serie B e C forniscono le etichette aggiuntive. Le loro colonne sono nascoste rimuovendo il riempimento e il contorno. Il metodo [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/chartseriesgroup/) allinea tutte e tre le serie con gli stessi centri di categoria.

Le impostazioni [ChartPlotArea](https://reference.aspose.com/slides/java/com.aspose.slides/chartplotarea/) riservano spazio per le righe di etichette. Dopo che [Chart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/) calcola le posizioni predefinite, [DataLabel.setX e DataLabel.setY](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/) preservano l'allineamento orizzontale e applicano offset verticali per organizzare le etichette in due righe. I numeri rimangono etichette dati collegate ai valori delle serie; solo le intestazioni delle righe sono forme di testo separate.

```java
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

## **FAQ**

**Come posso impedire che le etichette dei dati si sovrappongano in grafici densi?**

Combina il posizionamento automatico delle etichette, le linee guida e una dimensione del carattere ridotta; se necessario, nascondi alcuni campi (ad esempio, la categoria) o mostra le etichette solo per valori estremi o punti chiave.

**Come posso disabilitare le etichette solo per valori zero, negativi o vuoti?**

Filtra i punti dati prima di abilitare le etichette e spegni la visualizzazione per valori pari a 0, valori negativi o valori mancanti secondo una regola definita.

**Come posso garantire uno stile di etichetta coerente durante l'esportazione in PDF/immagini?**

Imposta esplicitamente la famiglia e la dimensione del carattere e verifica che il font sia disponibile nell'ambiente di rendering per evitare il fallback.