---
title: Formattare i grafici delle presentazioni in Java
linktitle: Formattazione del grafico
type: docs
weight: 60
url: /it/java/chart-formatting/
keywords:
- formattare grafico
- formattazione del grafico
- entità del grafico
- proprietà del grafico
- impostazioni del grafico
- opzioni del grafico
- proprietà del carattere
- bordo arrotondato
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Impara a formattare i grafici in Aspose.Slides per Java e migliora la tua presentazione PowerPoint con uno stile professionale e accattivante."
---
## **Panoramica**

Questo articolo spiega come formattare i grafici nelle presentazioni PowerPoint utilizzando Aspose.Slides. Mostra come personalizzare gli elementi chiave del grafico come assi, linee della griglia, titoli, legende, l'area del tracciato e i riempimenti delle pareti per migliorare l'aspetto e la leggibilità dei dati del grafico.

Mostra inoltre come impostare le proprietà del carattere per il testo del grafico, applicare formati numerici predefiniti e personalizzati ai dati del grafico e abilitare gli angoli arrotondati per l'area del grafico. Insieme, questi esempi mostrano come controllare sia lo stile visivo sia la presentazione dei dati dei grafici in una presentazione.

## **Formattare le entità del grafico**
Aspose.Slides for Java consente agli sviluppatori di aggiungere grafici personalizzati alle proprie diapositive da zero. Questo articolo spiega come formattare diverse entità del grafico, inclusi gli assi di categoria e di valore.

Aspose.Slides for Java fornisce un'API semplice per gestire diverse entità del grafico e formattarle usando valori personalizzati:

1. Crea un'istanza della classe [**Presentation**](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
1. Ottieni il riferimento di una diapositiva tramite il suo indice.
1. Aggiungi un grafico con dati predefiniti insieme a uno dei tipi desiderati (in questo esempio utilizzeremo ChartType.LineWithMarkers).
1. Accedi all'asse dei valori del grafico e imposta le seguenti proprietà:
   1. Impostazione del **Line format** per le linee della griglia principale dell'asse dei valori
   1. Impostazione del **Line format** per le linee della griglia secondaria dell'asse dei valori
   1. Impostazione del **Number Format** per l'asse dei valori
   1. Impostazione di **Min, Max, Major and Minor units** per l'asse dei valori
   1. Impostazione delle **Text Properties** per i dati dell'asse dei valori
   1. Impostazione del **Title** per l'asse dei valori
   1. Impostazione del **Line Format** per l'asse dei valori
1. Accedi all'asse di categoria del grafico e imposta le seguenti proprietà:
   1. Impostazione del **Line format** per le linee della griglia principale dell'asse di categoria
   1. Impostazione del **Line format** per le linee della griglia secondaria dell'asse di categoria
   1. Impostazione delle **Text Properties** per i dati dell'asse di categoria
   1. Impostazione del **Title** per l'asse di categoria
   1. Impostazione del **Label Positioning** per l'asse di categoria
   1. Impostazione dell'**Rotation Angle** per le etichette dell'asse di categoria
1. Accedi alla legenda del grafico e imposta le **Text Properties**.
1. Imposta la visualizzazione delle legende del grafico senza sovrapporle al grafico.
1. Accedi all'**Secondary Value Axis** del grafico e imposta le seguenti proprietà:
   1. Abilita l'**Secondary Value Axis**
   1. Impostazione del **Line Format** per l'**Secondary Value Axis**
   1. Impostazione del **Number Format** per l'**Secondary Value Axis**
   1. Impostazione di **Min, Max, Major and Minor units** per l'**Secondary Value Axis**
1. Ora traccia la prima serie del grafico sull'**Secondary Value Axis**
1. Imposta il colore di riempimento della parete posteriore del grafico
1. Imposta il colore di riempimento dell'area del tracciato del grafico
1. Scrivi la presentazione modificata in un file PPTX

```java
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation();
try {
    // Accesso alla prima diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Aggiunta del grafico di esempio
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // Impostazione del titolo del grafico
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Impostazione del formato delle linee della griglia principale per l'asse dei valori
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // Impostazione del formato delle linee della griglia secondaria per l'asse dei valori
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Impostazione del formato numerico dell'asse dei valori
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // Impostazione dei valori massimo e minimo del grafico
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // Impostazione delle proprietà del testo dell'asse dei valori
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // Impostazione del titolo dell'asse dei valori
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Impostazione del formato delle linee della griglia principale per l'asse di categoria
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // Impostazione del formato delle linee della griglia secondaria per l'asse di categoria
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Impostazione delle proprietà del testo dell'asse di categoria
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // Impostazione del titolo della categoria
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Impostazione della posizione delle etichette dell'asse di categoria
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // Impostazione dell'angolo di rotazione delle etichette dell'asse di categoria
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // Impostazione delle proprietà del testo delle legende
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // Imposta la visualizzazione delle legende del grafico senza sovrapporle al grafico

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Impostazione dell'asse dei valori secondario
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // Impostazione del formato numerico dell'asse dei valori secondario
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // Impostazione dei valori massimo e minimo del grafico
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // Impostazione del colore della parete posteriore del grafico
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // Impostazione del colore dell'area del tracciato
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // Salva la presentazione
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Impostare le proprietà del carattere per un grafico**
Aspose.Slides for Java fornisce il supporto per impostare le proprietà relative al carattere per il grafico. Segui i passaggi seguenti per impostare le proprietà del carattere per il grafico.

- Istanzia un oggetto della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
- Aggiungi un grafico alla diapositiva.
- Imposta l'altezza del carattere.
- Salva la presentazione modificata.

Di seguito è riportato un esempio.

```java
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    pres.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Impostare il formato numerico**
Aspose.Slides for Java fornisce un'API semplice per gestire il formato dei dati del grafico:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
1. Ottieni il riferimento di una diapositiva tramite il suo indice.
1. Aggiungi un grafico con dati predefiniti insieme a uno dei tipi desiderati (questo esempio utilizza **ChartType.ClusteredColumn**).
1. Imposta il formato numerico predefinito tra i valori predefiniti disponibili.
1. Scorri le celle dei dati del grafico in ogni serie e imposta il formato numerico dei dati del grafico.
1. Salva la presentazione.
1. Imposta il formato numerico personalizzato.
1. Scorri le celle dei dati del grafico in ogni serie e imposta un formato numerico diverso per i dati del grafico.
1. Salva la presentazione.

```java
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation();
try {
    // Accedi alla prima diapositiva della presentazione
    ISlide slide = pres.getSlides().get_Item(0);

    // Aggiunta di un grafico a colonne raggruppate predefinito
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // Accesso alla collezione delle serie del grafico
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // Scorri ogni serie del grafico
    for (IChartSeries ser : series) 
    {
        // Scorri ogni cella dati nella serie
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // Impostazione del formato numerico
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // Salvataggio della presentazione
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Di seguito sono riportati i possibili valori di formato numerico predefiniti insieme al loro indice predefinito, che possono essere utilizzati:

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Impostare i bordi arrotondati dell'area del grafico**
Aspose.Slides for Java fornisce il supporto per impostare l'area del grafico. I metodi [**hasRoundedCorners**](https://reference.aspose.com/slides/it/java/com.aspose.slides/IChart#hasRoundedCorners--) e [**setRoundedCorners**](https://reference.aspose.com/slides/it/java/com.aspose.slides/IChart#setRoundedCorners-boolean-) sono stati aggiunti all'interfaccia [IChart](https://reference.aspose.com/slides/it/java/com.aspose.slides/IChart) e alla classe [Chart](https://reference.aspose.com/slides/it/java/com.aspose.slides/Chart).

1. Istanzia un oggetto della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
1. Aggiungi un grafico alla diapositiva.
1. Imposta il tipo di riempimento e il colore di riempimento del grafico
1. Imposta la proprietà round corner su True.
1. Salva la presentazione modificata.

Di seguito è riportato un esempio.  

```java
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso impostare riempimenti semi-trasparenti per colonne/aree mantenendo il bordo opaco?**

Sì. La trasparenza del riempimento e il contorno vengono configurati separatamente. Questo è utile per migliorare la leggibilità della griglia e dei dati in visualizzazioni dense.

**Come posso gestire le etichette dei dati quando si sovrappongono?**

Riduci la dimensione del carattere, disabilita componenti non essenziali dell'etichetta (ad esempio le categorie), imposta l'offset/posizione dell'etichetta, mostra le etichette solo per i punti selezionati se necessario, oppure passa al formato "valore + legenda".

**Posso applicare riempimenti a gradiente o a motivo alle serie?**

Sì. Sono generalmente disponibili sia riempimenti solidi che a gradiente/motivo. In pratica, usa i gradienti con parsimonia ed evita combinazioni che riducono il contrasto con la griglia e il testo.