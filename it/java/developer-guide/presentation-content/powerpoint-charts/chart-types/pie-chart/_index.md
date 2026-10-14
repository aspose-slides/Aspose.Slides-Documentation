---
title: Personalizza i grafici a torta nelle presentazioni con Java
linktitle: Grafico a torta
type: docs
url: /it/java/pie-chart/
keywords:
- grafico a torta
- gestire il grafico
- personalizzare il grafico
- opzioni del grafico
- impostazioni del grafico
- opzioni di trama
- colore della fetta
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Crea e personalizza grafici a torta in Java con Aspose.Slides. Configura trame secondarie, visualizza le etichette dei dati e applica colori automatici alle fette in PowerPoint."
---
## **Panoramica**

Questo articolo spiega come lavorare con i grafici a torta in Aspose.Slides. Mostra come configurare le opzioni di trama secondaria per i grafici Pie of Pie e Bar of Pie e come abilitare la colorazione automatica delle fette per un grafico a torta standard.

Gli esempi si concentrano su attività di personalizzazione del grafico, come aggiungere un grafico a una diapositiva, regolare le impostazioni delle serie e delle etichette, sostituire i dati predefiniti del grafico con categorie e valori personalizzati e salvare la presentazione aggiornata.

## **Opzioni di Trama Secondaria per i Grafici Pie of Pie e Bar of Pie**

Aspose.Slides per Java supporta le opzioni di trama secondaria per i grafici Pie of Pie e Bar of Pie. Queste opzioni controllano la dimensione della trama secondaria e come i punti dati sono suddivisi tra le due trame.

Il seguente esempio crea un grafico Pie of Pie in una nuova presentazione e mostra i valori dei punti dati come etichette. Il metodo [setSecondPieSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setSecondPieSize-int-) imposta la dimensione della trama secondaria al 149% della trama principale. [setPieSplitBy](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) seleziona la suddivisione basata su percentuale e [setPieSplitPosition](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitPosition-double-) imposta la soglia al 53%.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Visualizza i valori e configura la trama secondaria.
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

### **Selezionare le Categorie per la Trama Secondaria**

Utilizza la suddivisione personalizzata quando desideri raggruppare categorie specifiche nella trama secondaria indipendentemente dai loro valori percentuali. Per esempio, un rapporto di vendite potrebbe mostrare Online ed Eventi insieme così i lettori possono confrontare questi due canali, anche se rappresentano il 35% e il 10% delle vendite totali.

Chiama [setPieSplitBy](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) con [PieSplitType.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/piesplittype/#Custom) e seleziona i punti tramite [getPieSplitCustomPoints](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#getPieSplitCustomPoints--). Il metodo [add](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#add-int-) della collezione accetta un indice basato su zero nella serie; usa [addItem](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#addItem-com.aspose.slides.IChartDataPoint-) per aggiungere un oggetto punto dati. In questo esempio, l'indice 1 seleziona Online e il punto all'indice 3 seleziona Eventi. Partners viene aggiunto temporaneamente, poi escluso usando [removeItem](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#removeItem-com.aspose.slides.IChartDataPoint-).

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

    // Seleziona Online tramite il suo indice basato su zero e Eventi tramite il suo oggetto punto dati.
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

Online (35) e Eventi (10) compaiono come fette separate nella trama secondaria. Nella trama principale, sono rappresentati da una fetta combinata con valore 45, insieme a Retail (40) e Partners (15). Rimuovere Partners dalla selezione personalizzata lo mantiene nella trama principale; non rimuove la categoria o il suo valore dai dati di origine del grafico.

L'immagine seguente mostra la presentazione salvata in PowerPoint:

![Grafico Pie of Pie con Online ed Eventi nella trama secondaria e il loro valore combinato di 45 nella trama principale](pie_of_pie_custom.png)

## **Impostare i Colori Automatici delle Fette del Grafico a Torta**

Aspose.Slides per Java può assegnare automaticamente colori diversi alle fette di un grafico a torta. Il seguente esempio crea un grafico a torta con un titolo centrato e sostituisce i dati predefiniti con tre categorie trimestrali e i loro valori. Il metodo [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) visualizza i valori 20, 50 e 30 come etichette, mentre [setColorVaried](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setColorVaried-boolean-) abilita un colore distinto per ogni fetta.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Aggiungi un titolo del grafico centrato.
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

    // Mostra i valori e assegna colori diversi alle fette.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Le varianti Pie of Pie e Bar of Pie sono supportate?**

Sì, la libreria [supporta](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) una trama secondaria per i grafici a torta, inclusi i tipi Pie of Pie e Bar of Pie.

**Posso esportare solo il grafico come immagine (ad esempio, PNG)?**

Sì, è possibile [esportare il grafico stesso come immagine](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) (ad esempio PNG) senza esportare l'intera presentazione.