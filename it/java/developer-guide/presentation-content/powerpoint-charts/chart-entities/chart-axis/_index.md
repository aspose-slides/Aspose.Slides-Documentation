---
title: Personalizza gli assi dei grafici nelle presentazioni usando Java
linktitle: Asse del grafico
type: docs
url: /it/java/chart-axis/
keywords:
- asse del grafico
- asse verticale
- asse orizzontale
- personalizzare asse
- manipolare asse
- gestire asse
- proprietà dell'asse
- valore massimo
- valore minimo
- linea dell'asse
- formato data
- titolo dell'asse
- posizione dell'asse
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri come usare Aspose.Slides per Java per personalizzare gli assi dei grafici nelle presentazioni PowerPoint per report e visualizzazioni."
---
## **Panoramica**

Questo articolo spiega come personalizzare gli assi dei grafici in Aspose.Slides. Mostra come ottenere i valori effettivi dell’asse, scambiare i dati tra gli assi, nascondere l’asse verticale o orizzontale nei grafici a linee, modificare il tipo di asse delle categorie, impostare il formato data per i valori dell’asse delle categorie, ruotare il titolo di un asse, impostare la posizione dell’asse e visualizzare un’etichetta di unità sull’asse dei valori.

## **Ottenere i valori massimi sull’asse verticale nei grafici**
Aspose.Slides per Java consente di ottenere i valori minimo e massimo su un asse verticale. Segui questi passaggi:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
1. Accedi alla prima diapositiva.
1. Aggiungi un grafico con dati predefiniti.
1. Ottieni il valore massimo effettivo sull’asse.
1. Ottieni il valore minimo effettivo sull’asse.
1. Ottieni l’unità principale effettiva dell’asse.
1. Ottieni l’unità secondaria effettiva dell’asse.
1. Ottieni la scala dell’unità principale effettiva dell’asse.
1. Ottieni la scala dell’unità secondaria effettiva dell’asse.

Questo codice di esempio—un’implementazione dei passaggi sopra—mostra come ottenere i valori richiesti in Java:

```java
Presentation pres = new Presentation();
try {
	Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
	chart.validateChartLayout();

	double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
	double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

	double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
	double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();

	// Salva la presentazione
	pres.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Scambiare i dati tra gli assi**
Aspose.Slides consente di scambiare rapidamente i dati tra gli assi: i dati rappresentati sull’asse verticale (asse y) vengono spostati sull’asse orizzontale (asse x) e viceversa.

Questo codice Java mostra come eseguire lo scambio di dati tra gli assi di un grafico:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	// Scambia righe e colonne
	chart.getChartData().switchRowColumn();

	// Salva la presentazione
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Disabilitare l’asse verticale per i grafici a linee**

Questo codice Java mostra come nascondere l’asse verticale per un grafico a linee:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
	chart.getAxes().getVerticalAxis().setVisible(false);

	pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Disabilitare l’asse orizzontale per i grafici a linee**

Questo codice mostra come nascondere l’asse orizzontale per un grafico a linee:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
	chart.getAxes().getHorizontalAxis().setVisible(false);

	pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Modificare un asse di categoria**

Utilizzando la proprietà **CategoryAxisType**, è possibile specificare il tipo di asse di categoria desiderato (**date** o **text**). Questo codice in Java dimostra l’operazione:

```java
Presentation presentation = new Presentation("ExistingChart.pptx");
try {
	IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
	chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
	chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
	chart.getAxes().getHorizontalAxis().setMajorUnit(1);
	chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);
	presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```

## **Impostare il formato data per i valori dell’asse di categoria**
Aspose.Slides per Java consente di impostare il formato data per un valore dell’asse di categoria. L’operazione è dimostrata in questo codice Java:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
	
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
public static String convertToOADate(GregorianCalendar date) throws ParseException
{
    double oaDate;
    SimpleDateFormat myFormat = new SimpleDateFormat("dd MM yyyy");
    java.util.Date baseDate = myFormat.parse("30 12 1899");
    Long days = TimeUnit.DAYS.convert(date.getTimeInMillis() - baseDate.getTime(), TimeUnit.MILLISECONDS);
    oaDate = (double) days + ((double) date.get(Calendar.HOUR_OF_DAY) / 24) + ((double) date.get(Calendar.MINUTE) / (60 * 24)) + ((double) date.get(Calendar.SECOND) / (60 * 24 * 60));
    return String.valueOf(oaDate);
}
```

## **Impostare l’angolo di rotazione per il titolo di un asse del grafico**
Aspose.Slides per Java consente di impostare l’angolo di rotazione per il titolo di un asse del grafico. Questo codice Java dimostra l’operazione:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Impostare la posizione dell’asse su un asse di categoria o di valore**
Aspose.Slides per Java consente di impostare la posizione dell’asse in un asse di categoria o di valore. Questo codice Java mostra come eseguire l’attività:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Abilitare la visualizzazione dell’etichetta di unità sull’asse dei valori del grafico**
Aspose.Slides per Java consente di configurare un grafico per mostrare un’etichetta di unità sul suo asse dei valori. Questo codice Java dimostra l’operazione:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Come posso impostare il valore al quale un asse incrocia l’altro (incrocio degli assi)?**

Gli assi forniscono una [crossing setting](https://reference.aspose.com/slides/it/java/com.aspose.slides/axis/#setCrossType-int-): è possibile scegliere di incrociare a zero, al valore massimo della categoria/valore o a un valore numerico specifico. Questo è utile per spostare l’asse X verso l’alto o verso il basso o per enfatizzare una linea di base.

**Come posso posizionare le etichette dei tic rispetto all’asse (accanto, all’esterno, all’interno)?**

Imposta la [label position](https://reference.aspose.com/slides/it/java/com.aspose.slides/axis/#setMajorTickMark-int-) su “cross”, “outside” o “inside”. Questo influisce sulla leggibilità e aiuta a risparmiare spazio, soprattutto su grafici di piccole dimensioni.