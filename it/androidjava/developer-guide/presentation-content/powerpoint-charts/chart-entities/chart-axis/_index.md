---
title: Personalizza gli assi dei grafici nelle presentazioni su Android
linktitle: Asse del grafico
type: docs
url: /it/androidjava/chart-axis/
keywords:
- asse del grafico
- asse verticale
- asse orizzontale
- personalizza asse
- manipola asse
- gestisci asse
- proprietà dell'asse
- valore massimo
- valore minimo
- linea dell'asse
- formato data
- titolo dell'asse
- posizione dell'asse
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri come utilizzare Aspose.Slides per Android tramite Java per personalizzare gli assi dei grafici nelle presentazioni PowerPoint per report e visualizzazioni."
---
## **Panoramica**

Questo articolo spiega come personalizzare gli assi dei grafici con Aspose.Slides per Android tramite Java. Copre valori degli assi calcolati, scambio di righe e colonne del grafico, visibilità dell'asse, intervalli delle etichette di categoria e dei segni di divisione, categorie di data e formattazione, rotazione del titolo, posizionamento dell'asse, unità di visualizzazione e scala logaritmica.

## **Ottenere i valori massimi sull'asse verticale nei grafici**

Crea una [Presentazione](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) e aggiungi un grafico ad area con dati predefiniti. Chiama [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) prima di leggere i valori degli assi calcolati in modo che il layout del grafico sia aggiornato.

Leggi [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) e [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) per i limiti dell'asse, e [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) e [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) per gli intervalli dei segni di divisione. [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) e [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) forniscono le scale di unità di tempo, rilevanti per gli assi di data. L'esempio memorizza questi valori in variabili locali e salva il grafico.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    double majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    int majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    int minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Scambiare i dati tra gli assi**

Usa [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) per scambiare i ruoli di serie e categorie nei dati del grafico. Ogni categoria precedente diventa una serie, e ogni serie precedente diventa una categoria. Questo cambia il modo in cui i dati sono raggruppati; non scambia gli assi orizzontale e verticale. L'esempio utilizza [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) per collegare i dati predefiniti a `Sheet1!A1:D5`, includendo la riga dell'intestazione e la colonna della categoria, prima di scambiare righe e colonne. Salva un grafico con quattro serie e tre categorie.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Invertire l'ordine di tracciamento di un asse**

Usa [setPlotOrderReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) per invertire un asse di categoria o di valore. Per esempio, un grafico a barre orizzontali può mostrare le fasi del progetto dall'alto verso il basso nello stesso ordine del foglio di lavoro: Pianificazione, Sviluppo, Test. L'inversione di un asse cambia la direzione di tracciamento; non ordina né riorganizza i dati della cartella di lavoro. In confronto, [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) scambia i ruoli di serie e categorie.

L'esempio seguente crea un grafico a barre orizzontali con tre fasi e una serie. Salva una presentazione con tre diapositive: ordine normale, categorie invertite e valori invertiti. Ogni copia utilizza lo stesso set di dati, e solo un asse è invertito in ogni copia.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredBar);
    String[] stages = { "Planning", "Development", "Testing" };
    int[] values = { 10, 30, 20 };
    for (int i = 0; i < stages.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // Diapositiva 2: visualizza la prima categoria in alto.
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // Mantieni l'asse dei valori orizzontale in basso.
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // Diapositiva 3: inverte solo la scala numerica orizzontale.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Invertire un asse può anche spostare l'asse perpendicolare sul lato opposto del tracciato. [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) controlla dove l'altro asse incrocia l'asse in configurazione. Nella diapositiva 2, chiamandolo con `CrossesType.Maximum` sull'asse di categoria invertito, l'asse di valore orizzontale rimane in basso. Per un punto di incrocio specifico, usa [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). Controlla le impostazioni di incrocio quando cambi direzione, soprattutto se il grafico ha già un punto di incrocio personalizzato. Chiama `setPlotOrderReversed` con `false` per ripristinare la direzione di tracciamento normale; le impostazioni di incrocio sono separate.

| Ordine normale (diap. 1) | Categorie invertite (diap. 2) | Valori invertiti (diap. 3) |
| --- | --- | --- |
| ![Grafico a barre orizzontali con ordine normale di assi di categoria e valore](axis-order-normal.png) | ![Grafico a barre orizzontali con categorie visualizzate dall'alto verso il basso](axis-order-categories-reversed.png) | ![Grafico a barre orizzontali con asse di valore invertito e zero a destra](axis-order-values-reversed.png) |
| Le categorie vanno dal basso verso l'alto; i valori aumentano da sinistra a destra. | Pianificazione, Sviluppo e Test vanno dall'alto verso il basso. Valori e ordine delle righe della cartella di lavoro rimangono invariati. | Le categorie mantengono il loro ordine normale; i valori aumentano da destra a sinistra. L'asse di categoria incrocia a zero a destra. |

## **Disabilitare l'asse verticale per i grafici a linee**

Chiama [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) con `false` sull'asse verticale per nasconderlo. L'esempio crea un grafico a linee con dati predefiniti e lo salva con l'asse verticale nascosto.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Disabilitare l'asse orizzontale per i grafici a linee**

Chiama [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) con `false` sull'asse orizzontale per nasconderlo. L'esempio crea un grafico a linee con dati predefiniti e lo salva con l'asse orizzontale nascosto.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Modificare un asse di categoria**

Usa [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) per scegliere un asse di categoria data o testo. Questo esempio richiede `ExistingChart.pptx`, con un grafico come prima forma nella prima diapositiva e celle di categoria contenenti valori di data Excel numerici. Cambia l'asse orizzontale in un asse di data. Chiamando [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) con `false`, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) con `1` e [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) con `TimeUnitType.Months` posiziona i segni maggiori a intervalli di un mese.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = (IChart) slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controllare gli intervalli delle etichette dell'asse di categoria**

Quando un grafico ha molte categorie, riduci il numero di etichette dell'asse visibili senza rimuovere categorie o punti dati. Chiama [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) con `false`, quindi passa l'intervallo di categoria desiderato a [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). Per le categorie di testo nel loro ordine normale, il conteggio parte dalla prima categoria:

| Intervallo | Etichette visualizzate nell'esempio |
| --- | --- |
| `1` | Categoria 1, Categoria 2, Categoria 3, ... Categoria 24 |
| `2` | Categoria 1, Categoria 3, Categoria 5, ... Categoria 23 |
| `3` | Categoria 1, Categoria 4, Categoria 7, ... Categoria 22 |

Un intervallo di `3` visualizza ogni terza etichetta, lasciando due etichette nascoste tra quelle visualizzate. Non rimuove le colonne corrispondenti. La spaziatura automatica sceglie un intervallo in base allo spazio disponibile; non visualizza necessariamente ogni etichetta.

I segni di divisione hanno controlli separati. Chiama [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) con `false` e usa [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) per impostare il loro intervallo. Per esempio, `1` mantiene un segno di divisione a ogni intervallo di categoria mentre le etichette appaiono solo ogni terza categoria. Usa [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) con uno stile visibile così da vedere il risultato. Richiamare nuovamente il setter di spaziatura automatica con `true` consente al grafico di scegliere nuovamente quell'intervallo.

L'esempio autonomo seguente crea 24 categorie e una serie, quindi salva tre diapositive in `CategoryAxisIntervals.pptx`: spaziatura automatica, spaziatura manuale delle etichette con segni di divisione indipendenti e ripristino della spaziatura automatica. Le due copie conservano i dati originali del grafico. Non è necessaria una presentazione di input. Il testo delle etichette orizzontali rende evidente la differenza di densità.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn);
    for (int i = 0; i < 24; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // Diapositiva 2: mostra ogni terza etichetta, ma mantieni un segno di divisione per ogni categoria.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Diapositiva 3: lascia che il grafico scelga nuovamente entrambi gli intervalli.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Spaziatura automatica (diap. 1):** In questa resa, ogni seconda etichetta di categoria è visualizzata e avvolta su due righe. Il risultato automatico può variare con la dimensione del grafico, i caratteri e il renderer.

![Spaziatura automatica delle etichette di categoria con tutte le 24 colonne visibili](category-axis-automatic.png)

**Spaziatura manuale (diap. 2):** Ogni terza etichetta è visualizzata su una riga, mentre i segni di divisione rimangono a ogni intervallo di categoria. Tutte le 24 colonne, incluse quelle senza etichette, rimangono visibili con gli stessi valori. La diapositiva 3 ripristina l'aspetto automatico mostrato sopra.

![Intervallo manuale delle etichette di categoria di tre con tutte le 24 colonne visibili](category-axis-manual.png)

### **Scegliere l'asse e l'intervallo corretti**

Usa questo intervallo di conteggio delle categorie per un asse di categoria di testo, come l'asse di categoria di un grafico a colonne, a linee, ad area o a barre. In un grafico a colonne, è l'asse orizzontale. In un grafico a barre orizzontali, l'asse di categoria è verticale, quindi applica queste impostazioni all'asse restituito da [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). La spaziatura dei segni di divisione si applica anche a un asse di serie nei grafici che ne hanno uno.

Non usare la spaziatura delle etichette di categoria per impostare la scala numerica di un asse di valore. Su un asse di valore, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) specifica una differenza di valori: per esempio, un'unità maggiore di `10` produce segni a 0, 10, 20, ecc. quando l'asse parte da zero. Un intervallo di etichetta di categoria di `3` conta invece le posizioni di categoria, indipendentemente dai valori dei dati. I grafici a dispersione e a bolle usano assi di valore anziché un asse di categoria di testo. Per un asse di data, usa unità principali e scale basate sul tempo come descritto in [Modificare un asse di categoria](#modificare-un-asse-di-categoria).

## **Impostare il formato data per i valori dell'asse di categoria**

L'esempio sostituisce i dati predefiniti del grafico con quattro valori annuali. Le date sono memorizzate come numeri seriali OLE Automation nel primo foglio di lavoro (indice `0`), calcolati come numero di giorni dal 30 dicembre 1899 per queste date. Entrambi i calendari usano UTC e sono azzerati prima di impostare le date così da escludere l'ora legale e l'ora corrente dal calcolo. Usa [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) con `CategoryAxisType.Date`, chiama [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) con `false`, e passa `yyyy` a [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) affinché le etichette di categoria mostrino gli anni a quattro cifre indipendentemente dalla formattazione della cella.

```java
import com.aspose.slides.*;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    TimeZone timeZone = TimeZone.getTimeZone("UTC");
    Calendar baseDate = new GregorianCalendar(timeZone);
    baseDate.clear();
    baseDate.set(1899, Calendar.DECEMBER, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        Calendar date = new GregorianCalendar(timeZone);
        date.clear();
        date.set(2015 + i, Calendar.JANUARY, 1);
        double serialDate = (date.getTimeInMillis() - baseDate.getTimeInMillis()) / 86400000.0;
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, serialDate);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Impostare un angolo di rotazione per il titolo dell'asse del grafico**

Chiama [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) con `true` sull'asse verticale, fornisci il testo del titolo e usa [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) per ruotare il titolo. L'angolo è misurato in gradi; questo esempio salva un grafico a colonne con il titolo dell'asse dei valori ruotato di 90 gradi.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Impostare la posizione dell'asse su un asse di categoria o di valore**

Usa [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) per controllare se l'asse di valore incrocia l'asse di categoria tra le categorie o sui segni di divisione della categoria. Questa impostazione si applica agli assi di categoria. L'esempio la imposta su `true` sull'asse di categoria orizzontale di un grafico a colonne e ne salva il risultato.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Impostare l'unità di visualizzazione su un asse di valore del grafico**

Usa [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) per scalare le etichette su un asse di valore senza modificare i dati sottostanti. Con [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) impostato a `Millions`, un valore di 60 000 000 viene visualizzato come 60. L'esempio crea un grafico a colonne e applica l'unità di visualizzazione milioni al suo asse verticale.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Configurare un asse di valore logaritmico**

Un asse di valore logaritmico è utile quando i valori positivi coprono diversi ordini di grandezza. Per esempio, un servizio potrebbe ricevere 10, 100, 1 000, 10 000 e 100 000 richieste in cinque periodi. Su una scala lineare, i valori più piccoli appaiono vicini tra loro vicino a zero. Una scala logaritmica rende più facile confrontare la loro crescita relativa: distanze uguali rappresentano rapporti uguali anziché differenze uguali.

Chiama [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) con `true` sull'asse di valore e usa [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) per scegliere la base. Questo cambia come i valori esistenti sono visualizzati; non modifica i dati né aggiunge una linea di tendenza logaritmica. Una linea di tendenza rappresenta una relazione adattata ai dati ed è una funzionalità separata.

### **Scegliere l'asse di valore e la base**

Per un grafico a linee o a colonne, l'asse di valore è restituito da [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Per un grafico a barre orizzontali, è restituito da [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). I grafici a dispersione e a bolle hanno due assi di valore, quindi scegli l'asse orizzontale per i valori X, quello verticale per i valori Y, o entrambi. Non applicare la scala logaritmica a un asse di categoria.

La base logaritmica predefinita è `10`. Per i grafici PPTX, usa una base da `2` a `1000`, inclusi; le basi frazionarie come `2.5` sono supportate. Con base `10`, le potenze successive 10, 100, 1 000 e 10 000 sono equidistanti.

### **Confrontare scala lineare e logaritmica**

L'esempio autonomo seguente crea un grafico a linee con i cinque conteggi di richieste nella prima diapositiva, quindi clona quella diapositiva e abilita un asse di valore logaritmico base 10 nella seconda. Entrambe le diapositive conservano gli stessi dati.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    double[] values = { 10, 100, 1000, 10000, 100000 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Mantieni la prima diapositiva lineare e cambia solo la scala dell'asse dei valori della copia.
    ISlide logarithmicSlide = presentation.getSlides().addClone(slide);
    IChart logarithmicChart = (IChart)logarithmicSlide.getShapes().get_Item(0);
    IAxis valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Scala lineare (diap. 1):** Distanze verticali uguali rappresentano differenze uguali nei conteggi delle richieste. Il valore più grande domina il grafico, rendendo difficili da distinguere i valori più piccoli.

![Grafico a linee in PowerPoint che mostra cinque conteggi di richieste su un asse di valore lineare](value-axis-linear.png)

**Scala logaritmica (diap. 2):** Distanze verticali uguali rappresentano rapporti uguali. Ogni periodo ha dieci volte più richieste del precedente, così i punti formano una linea crescente su scala base 10. Le etichette dell'asse mostrano comunque i conteggi originali delle richieste.

![Gli stessi cinque conteggi di richieste in PowerPoint su un asse di valore logaritmico base 10](value-axis-logarithmic.png)

### **Gestire valori zero e negativi**

Una scala logaritmica può visualizzare solo valori strettamente positivi. Controlla i dati prima di abilitarla. Se zero o valori negativi sono significativi, mantieni una scala lineare o mostrali separatamente. Se escludere tali valori è appropriato per l'analisi, spiega l'omissione. Non sostituirli silenziosamente con numeri piccoli positivi, poiché ciò cambia il significato dei dati. Qualsiasi minimo o massimo configurato manualmente per un asse logaritmico deve essere anch'esso positivo.

## **FAQ**

**Come impostare il valore in cui un asse incrocia l'altro (incrocio degli assi)?**

Usa [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) per selezionare il comportamento di incrocio. Per specificare un valore numerico di incrocio, usa [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). Queste impostazioni ti consentono di spostare l'incrocio dell'asse su una linea di base adeguata.

**Come posso posizionare le etichette dei segni rispetto all'asse?**

Chiama [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) usando [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` o `None`. Per controllare i segni di divisione stessi, usa [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) o [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-); sono separati dal posizionamento delle etichette.