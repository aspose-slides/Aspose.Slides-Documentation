---
title: Personalizza i grafici a torta nelle presentazioni su Android
linktitle: Grafico a torta
type: docs
url: /it/androidjava/pie-chart/
keywords:
- grafico a torta
- gestire il grafico
- personalizzare il grafico
- opzioni del grafico
- impostazioni del grafico
- opzioni di tracciamento
- colore della fetta
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Crea e personalizza grafici a torta su Android con Aspose.Slides per Android via Java. Configura grafici secondari, visualizza le etichette dei dati e applica colori automatici alle fette in PowerPoint."
---
## **Panoramica**

Questo articolo spiega come lavorare con i grafici a torta in Aspose.Slides. Mostra come configurare le opzioni del grafico secondario per i grafici Pie of Pie e Bar of Pie, e come abilitare la colorazione automatica delle fette per un grafico a torta standard.

Gli esempi si concentrano su attività di personalizzazione del grafico, come aggiungere un grafico a una diapositiva, regolare le impostazioni di serie e etichette, sostituire i dati predefiniti del grafico con categorie e valori personalizzati e salvare la presentazione aggiornata.

## **Opzioni del grafico secondario per i grafici Pie of Pie e Bar of Pie**

Aspose.Slides per Android via Java supporta le opzioni del grafico secondario per i grafici Pie of Pie e Bar of Pie. Queste opzioni controllano la dimensione del grafico secondario e come i punti dati vengono suddivisi tra i due grafici.

Il seguente esempio crea un grafico Pie of Pie in una nuova presentazione e visualizza i valori dei punti dati come etichette. Il metodo [setSecondPieSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setSecondPieSize-int-) imposta la dimensione del grafico secondario al 149% del grafico principale. Il metodo [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) seleziona la suddivisione basata sulla percentuale, e il metodo [setPieSplitPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitPosition-double-) imposta la soglia al 53%.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Visualizza i valori e configura il grafico secondario.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Seleziona categorie per il grafico secondario**

Utilizza la divisione personalizzata quando desideri raggruppare categorie specifiche nel grafico secondario indipendentemente dai loro valori percentuali. Ad esempio, un report di vendite potrebbe mostrare Online ed Eventi insieme affinché i lettori possano confrontare questi due canali, anche se rappresentano il 35% e il 10% delle vendite totali.

Chiama [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) con [PieSplitType.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplittype/#Custom) e seleziona i punti tramite [getPieSplitCustomPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#getPieSplitCustomPoints--). Il metodo [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#add-int-) della collezione accetta un indice basato su zero nella serie; usa [addItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#addItem-com.aspose.slides.IChartDataPoint-) per aggiungere un oggetto punto dati. In questo esempio, l'indice 1 seleziona Online e il punto all'indice 3 seleziona Eventi. Partners viene aggiunto temporaneamente, poi escluso utilizzando [removeItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#removeItem-com.aspose.slides.IChartDataPoint-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200);

    // Sostituisci i dati predefiniti con le vendite per canale.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "Retail", "Online", "Partners", "Events" };
    int[] values = { 40, 35, 15, 10 };
    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // Seleziona Online per il suo indice basato su zero ed Events per il suo oggetto punto dati.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Escludi Partners dalla selezione senza eliminare i suoi dati di origine.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) ed Eventi (10) appaiono come fette separate nel grafico secondario. Nel grafico primario, sono rappresentati da una singola fetta combinata con valore 45, accanto a Retail (40) e Partners (15). Rimuovere Partners dalla selezione personalizzata lo mantiene nel grafico primario; non rimuove la categoria né il suo valore dai dati di origine del grafico.

L'immagine seguente mostra la presentazione salvata in PowerPoint:

![Grafico Pie of Pie con Online ed Eventi nel grafico secondario e il loro valore combinato di 45 nel grafico primario](pie_of_pie_custom.png)

## **Imposta i colori automatici delle fette del grafico a torta**

Aspose.Slides per Android via Java può assegnare automaticamente colori diversi alle fette del grafico a torta. Il seguente esempio crea un grafico a torta con un titolo centrato e sostituisce i dati predefiniti con tre categorie trimestrali e i relativi valori. Il metodo [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) visualizza i valori 20, 50 e 30 come etichette, mentre il metodo [setColorVaried](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setColorVaried-boolean-) abilita un colore distinto per ogni fetta.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Aggiungi un titolo centrato al grafico.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Sostituisci i dati predefiniti usando il primo foglio di lavoro.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "First Qtr", "2nd Qtr", "3rd Qtr" };
    int[] values = { 20, 50, 30 };
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // Visualizza i valori e assegna colori diversi alle fette.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Le varianti Pie of Pie e Bar of Pie sono supportate?**

Sì, la libreria [supporta](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) un grafico secondario per i grafici a torta, includendo i tipi Pie of Pie e Bar of Pie.

**Posso esportare solo il grafico come immagine (ad esempio, PNG)?**

Sì, puoi [esportare il grafico stesso come immagine](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) (ad esempio PNG) senza esportare l'intera presentazione.