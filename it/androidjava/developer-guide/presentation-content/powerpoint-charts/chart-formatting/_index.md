---
title: Formato dei grafici della presentazione su Android
linktitle: Formattazione dei grafici
type: docs
weight: 60
url: /it/androidjava/chart-formatting/
keywords:
- formato grafico
- formattazione del grafico
- entità del grafico
- proprietà del grafico
- impostazioni del grafico
- opzioni del grafico
- proprietà del carattere
- bordo arrotondato
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Impara la formattazione dei grafici in Aspose.Slides per Android via Java e migliora la tua presentazione PowerPoint con uno stile professionale e accattivante."
---
## **Panoramica**

Questo articolo spiega come formattare i grafici nelle presentazioni PowerPoint utilizzando Aspose.Slides. Mostra come personalizzare gli elementi chiave del grafico, come assi, linee della griglia, titoli, legende, area del tracciato e riempimenti delle pareti, per migliorare l'aspetto e la leggibilità dei dati del grafico. Dimostra inoltre come impostare le proprietà del carattere per il testo del grafico, applicare formati numerici predefiniti e personalizzati ai dati del grafico e abilitare gli angoli arrotondati per l'area del grafico. Insieme, questi esempi mostrano come controllare sia lo stile visivo sia la presentazione dei dati dei grafici in una presentazione.

## **Formattare le entità del grafico**
Aspose.Slides per Android tramite Java consente agli sviluppatori di aggiungere grafici personalizzati alle proprie diapositive da zero. Questo articolo spiega come formattare diverse entità del grafico, inclusi l'asse delle categorie e l'asse dei valori.

Aspose.Slides per Android tramite Java fornisce un'API semplice per gestire diverse entità del grafico e formattarle utilizzando valori personalizzati:

1. Creare un'istanza della classe [**Presentation**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) class.
2. Ottenere il riferimento di una diapositiva tramite il suo indice.
3. Aggiungere un grafico con dati predefiniti insieme a uno dei tipi desiderati (in questo esempio utilizzeremo ChartType.LineWithMarkers).
4. Accedere all'asse dei valori del grafico e impostare le seguenti proprietà:
   1. Impostare **Line format** per le linee della griglia principale dell'asse dei valori
   2. Impostare **Line format** per le linee della griglia secondaria dell'asse dei valori
   3. Impostare **Number Format** per l'asse dei valori
   4. Impostare **Min, Max, Major and Minor units** per l'asse dei valori
   5. Impostare **Text Properties** per i dati dell'asse dei valori
   6. Impostare **Title** per l'asse dei valori
   7. Impostare **Line Format** per l'asse dei valori
5. Accedere all'asse delle categorie del grafico e impostare le seguenti proprietà:
   1. Impostare **Line format** per le linee della griglia principale dell'asse delle categorie
   2. Impostare **Line format** per le linee della griglia secondaria dell'asse delle categorie
   3. Impostare **Text Properties** per i dati dell'asse delle categorie
   4. Impostare **Title** per l'asse delle categorie
   5. Impostare **Label Positioning** per l'asse delle categorie
   6. Impostare **Rotation Angle** per le etichette dell'asse delle categorie
6. Accedere alla legenda del grafico e impostare le **Text Properties** per essa
7. Impostare la visualizzazione delle legende del grafico senza sovrapposizionarle al grafico
8. Accedere all'**Secondary Value Axis** del grafico e impostare le seguenti proprietà:
   1. Abilitare l'**Value Axis** secondario
   2. Impostare **Line Format** per l'**Secondary Value Axis**
   3. Impostare **Number Format** per l'**Secondary Value Axis**
   4. Impostare **Min, Max, Major and Minor units** per l'**Secondary Value Axis**
9. Ora tracciare la prima serie del grafico sull'**Secondary Value Axis**
10. Impostare il colore di riempimento della parete posteriore del grafico
11. Impostare il colore di riempimento dell'area del tracciato del grafico
12. Scrivere la presentazione modificata in un file PPTX

```java
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation();
try {
    // Accedere alla prima diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Aggiungere il grafico di esempio
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // Impostare il titolo del grafico
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Impostare il formato delle linee della griglia principale per l'asse dei valori
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // Impostare il formato delle linee della griglia secondaria per l'asse dei valori
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Impostare il formato numerico dell'asse dei valori
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // Impostare i valori massimi e minimi del grafico
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // Impostare le proprietà del testo dell'asse dei valori
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // Impostare il titolo dell'asse dei valori
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Impostare il formato delle linee della griglia principale per l'asse delle categorie
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // Impostare il formato delle linee della griglia secondaria per l'asse delle categorie
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Impostare le proprietà del testo dell'asse delle categorie
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // Impostare il titolo dell'asse delle categorie
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Impostare la posizione dell'etichetta dell'asse delle categorie
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // Impostare l'angolo di rotazione dell'etichetta dell'asse delle categorie
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // Impostare le proprietà del testo delle legende
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // Impostare la visualizzazione delle legende del grafico senza sovrapporle al grafico

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Impostare l'asse dei valori secondario
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // Impostare il formato numerico dell'asse dei valori secondario
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // Impostare i valori massimi e minimi del grafico
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // Impostare il colore della parete posteriore del grafico
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // Impostare il colore dell'area del tracciato
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // Salvare la presentazione
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Impostare le proprietà del carattere per un grafico**
Aspose.Slides per Android tramite Java fornisce il supporto per impostare le proprietà relative al carattere per il grafico. Seguendo i passaggi seguenti è possibile impostare le proprietà del carattere per il grafico.

- Istanziare l'oggetto della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) class.
- Aggiungere un grafico alla diapositiva.
- Impostare l'altezza del carattere.
- Salvare la presentazione modificata.

Di seguito è fornito un esempio di codice.

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
Aspose.Slides per Android tramite Java fornisce un'API semplice per gestire il formato dei dati del grafico:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) class.
2. Ottenere il riferimento di una diapositiva tramite il suo indice.
3. Aggiungere un grafico con dati predefiniti insieme a uno dei tipi desiderati (questo esempio utilizza **ChartType.ClusteredColumn**).
4. Impostare il formato numerico predefinito tra i valori predefiniti disponibili.
5. Scorrere le celle dei dati del grafico in ogni serie e impostare il formato numerico dei dati del grafico.
6. Salvare la presentazione.
7. Impostare il formato numerico personalizzato.
8. Scorrere le celle dei dati del grafico all'interno di ogni serie e impostare un formato numerico diverso per i dati del grafico.
9. Salvare la presentazione.

```java
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation();
try {
    // Accedi alla prima diapositiva della presentazione
    ISlide slide = pres.getSlides().get_Item(0);

    // Aggiungi un grafico a colonne raggruppate predefinito
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // Accedi alla collezione delle serie del grafico
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // Scorri ogni serie del grafico
    for (IChartSeries ser : series) 
    {
        // Scorri ogni cella dati nella serie
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // Impostare il formato numerico
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // Salva la presentazione
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

I possibili valori di formato numerico predefiniti, insieme al loro indice predefinito, che possono essere utilizzati, sono elencati di seguito:

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
Aspose.Slides per Android tramite Java fornisce il supporto per impostare l'area del grafico. I metodi [**hasRoundedCorners**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChart#hasRoundedCorners--) e [**setRoundedCorners**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChart#setRoundedCorners-boolean-) sono stati aggiunti all'interfaccia [IChart](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChart) e alla classe [Chart](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Chart).

1. Istanziare l'oggetto della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) class.
2. Aggiungere un grafico alla diapositiva.
3. Impostare il tipo di riempimento e il colore di riempimento del grafico
4. Impostare la proprietà round corner su True.
5. Salvare la presentazione modificata.

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

**Posso impostare riempimenti semitrasparenti per colonne/aree mantenendo il bordo opaco?**

Sì. La trasparenza del riempimento e il contorno sono configurati separatamente. Questo è utile per migliorare la leggibilità della griglia e dei dati in visualizzazioni dense.

**Come posso gestire le etichette dei dati quando si sovrappongono?**

Ridurre la dimensione del carattere, disabilitare componenti non essenziali delle etichette (ad esempio le categorie), impostare l'offset/posizione dell'etichetta, mostrare le etichette solo per i punti selezionati se necessario, oppure passare al formato "valore + legenda".

**Posso applicare riempimenti a gradiente o a trama alle serie?**

Sì. Sono generalmente disponibili sia riempimenti solidi sia a gradiente/trama. In pratica, utilizzare i gradienti con parsimonia ed evitare combinazioni che riducono il contrasto con la griglia e il testo.