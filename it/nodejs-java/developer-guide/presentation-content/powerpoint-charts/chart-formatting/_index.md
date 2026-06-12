---
title: Formattare i grafici delle presentazioni in JavaScript
linktitle: Formattazione del grafico
type: docs
weight: 60
url: /it/nodejs-java/chart-formatting/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Impara a formattare i grafici in Aspose.Slides per Node.js con JavaScript e migliora la tua presentazione PowerPoint con uno stile professionale e accattivante."
---
## **Panoramica**

Questo articolo spiega come formattare i grafici nelle presentazioni PowerPoint utilizzando Aspose.Slides. Mostra come personalizzare gli elementi chiave dei grafici, come assi, linee della griglia, titoli, legende, area del tracciato e riempimenti delle pareti, per migliorare l'aspetto e la leggibilità dei dati del grafico.

Dimostra inoltre come impostare le proprietà del carattere per il testo del grafico, applicare formati numerici predefiniti e personalizzati ai dati del grafico e abilitare gli angoli arrotondati per l'area del grafico. Insieme, questi esempi mostrano come controllare sia lo stile visivo sia la presentazione dei dati dei grafici in una presentazione.

## **Formattare le Entità del Grafico**

Aspose.Slides for Node.js via Java consente agli sviluppatori di aggiungere grafici personalizzati alle proprie diapositive da zero. Questo articolo spiega come formattare diverse entità del grafico, inclusi l'asse di categoria e l'asse dei valori.

Aspose.Slides for Node.js via Java fornisce un'API semplice per gestire diverse entità del grafico e formattarle utilizzando valori personalizzati:

1. Crea un'istanza della classe [**Presentation**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) .
1. Ottieni il riferimento di una diapositiva mediante il suo indice.
1. Aggiungi un grafico con dati predefiniti e il tipo desiderato (in questo esempio useremo ChartType.LineWithMarkers).
1. Accedi all'asse dei valori del grafico e imposta le seguenti proprietà:
   1. Impostare il **Line format** per le linee della griglia principale dell'asse dei valori
   1. Impostare il **Line format** per le linee della griglia secondaria dell'asse dei valori
   1. Impostare il **Number Format** per l'asse dei valori
   1. Impostare **Min, Max, Major and Minor units** per l'asse dei valori
   1. Impostare le **Text Properties** per i dati dell'asse dei valori
   1. Impostare **Title** per l'asse dei valori
   1. Impostare il **Line Format** per l'asse dei valori
1. Accedi all'asse di categoria del grafico e imposta le seguenti proprietà:
   1. Impostare il **Line format** per le linee della griglia principale dell'asse di categoria
   1. Impostare il **Line format** per le linee della griglia secondaria dell'asse di categoria
   1. Impostare le **Text Properties** per i dati dell'asse di categoria
   1. Impostare **Title** per l'asse di categoria
   1. Impostare **Label Positioning** per l'asse di categoria
   1. Impostare **Rotation Angle** per le etichette dell'asse di categoria
1. Accedi alla legenda del grafico e imposta le **Text Properties** per essa
1. Imposta la visualizzazione delle legende del grafico senza sovrapporle al grafico
1. Accedi all'**Secondary Value Axis** del grafico e imposta le seguenti proprietà:
   1. Abilita l'**Value Axis** secondario
   1. Impostare il **Line Format** per l'**Value Axis** secondario
   1. Impostare il **Number Format** per l'**Value Axis** secondario
   1. Impostare **Min, Max, Major and Minor units** per l'**Value Axis** secondario
1. Ora traccia la prima serie del grafico sull'**Secondary Value Axis**
1. Imposta il colore di riempimento della parete posteriore del grafico
1. Imposta il colore di riempimento dell'area di tracciamento del grafico
1. Scrivi la presentazione modificata in un file PPTX

```javascript
// Crea un'istanza della classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Accesso alla prima diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Aggiunta del grafico di esempio
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);
    // Impostazione del titolo del grafico
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    var chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Impostazione del formato delle linee della griglia principale per l'asse dei valori
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // Impostazione del formato delle linee della griglia secondaria per l'asse dei valori
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Impostazione del formato numerico dell'asse dei valori
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");
    // Impostazione dei valori massimo e minimo del grafico
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getVerticalAxis().setMaxValue(15.0);
    chart.getAxes().getVerticalAxis().setMinValue(-2.0);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0);
    // Impostazione delle proprietà testuali dell'asse dei valori
    var txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(aspose.slides.NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(aspose.slides.NullableBool.True);
    txtVal.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtVal.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkGreen));
    txtVal.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Impostazione del titolo dell'asse dei valori
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    var valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Impostazione del formato delle linee della griglia principale per l'asse di categoria
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    // Impostazione del formato delle linee della griglia secondaria per l'asse di categoria
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Impostazione delle proprietà testuali dell'asse di categoria
    var txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(aspose.slides.NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(aspose.slides.NullableBool.True);
    txtCat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtCat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    txtCat.setLatinFont(new aspose.slides.FontData("Arial"));
    // Impostazione del titolo della categoria
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");
    var catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Impostazione della posizione delle etichette dell'asse di categoria
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
    // Impostazione dell'angolo di rotazione delle etichette dell'asse di categoria
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);
    // Impostazione delle proprietà testuali delle legende
    var txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(aspose.slides.NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(aspose.slides.NullableBool.True);
    txtleg.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtleg.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkRed));
    // Imposta la visualizzazione delle legende senza sovrapporre il grafico
    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;
    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Impostazione dell'asse secondario dei valori
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);
    // Impostazione del formato numerico dell'asse secondario dei valori
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");
    // Impostazione dei valori massimo e minimo del grafico
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0);
    // Impostazione del colore della parete posteriore del grafico
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Impostazione del colore dell'area del tracciato
    chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.LightCyan));
    // Salva la presentazione
    pres.save("FormattedChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Impostare le Proprietà del Carattere per il Grafico**

Aspose.Slides for Node.js via Java offre il supporto per impostare le proprietà relative al carattere per il grafico. Segui i passaggi seguenti per impostare le proprietà del carattere del grafico.

- Istanza l'oggetto della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) .
- Aggiungi un grafico alla diapositiva.
- Imposta l'altezza del carattere.
- Salva la presentazione modificata.

Di seguito è riportato un esempio.

```javascript
// Crea un'istanza della classe Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    pres.save("FontPropertiesForChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Impostare il Formato dei Numeri**

Aspose.Slides for Node.js via Java fornisce un'API semplice per gestire il formato dei dati del grafico:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) .
1. Ottieni il riferimento di una diapositiva mediante il suo indice.
1. Aggiungi un grafico con dati predefiniti e il tipo desiderato (questo esempio utilizza **ChartType.ClusteredColumn**).
1. Imposta il formato numerico predefinito tra i valori predefiniti disponibili.
1. Scorri le celle dei dati del grafico in ogni serie e imposta il formato numerico dei dati del grafico.
1. Salva la presentazione.
1. Imposta il formato numerico personalizzato.
1. Scorri le celle dei dati del grafico in ogni serie e imposta un formato numerico diverso.
1. Salva la presentazione.

```javascript
// Crea un'istanza della classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Accedi alla prima diapositiva della presentazione
    var slide = pres.getSlides().get_Item(0);
    // Aggiungi un grafico a colonne raggruppate predefinito
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    // Accesso alla raccolta delle serie del grafico
    var series = chart.getChartData().getSeries();
    // Scorri tutte le serie del grafico
    for (var i = 0; i < series.size(); i++) {
        var ser = series.get_Item(i);
        // Scorri ogni cella dati nella serie
        for (var j = 0; j < ser.getDataPoints().size(); j++) {
            var cell = ser.getDataPoints().get_Item(j);
            // Impostazione del formato numerico
            cell.getValue().getAsCell().setPresetNumberFormat(java.newByte(10));// 0,00%
        }
    }
    // Salvataggio della presentazione
    pres.save("PresetNumberFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

I possibili valori di formato numerico predefiniti, insieme al loro indice predefinito e che possono essere usati, sono indicati di seguito:

|**0**|Generale|
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
|**47**mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Impostare i Bordi Arrotondati dell'Area del Grafico**

Aspose.Slides for Node.js via Java fornisce il supporto per impostare l'area del grafico. I metodi [**hasRoundedCorners**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Chart#hasRoundedCorners--) e [**setRoundedCorners**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Chart#setRoundedCorners-boolean-) sono stati aggiunti alla classe [Chart](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Chart) .

1. Istanza l'oggetto della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) .
1. Aggiungi un grafico alla diapositiva.
1. Imposta il tipo di riempimento e il colore di riempimento del grafico
1. Imposta la proprietà round corner a True.
1. Salva la presentazione modificata.

Di seguito è riportato un esempio.

```javascript
// Crea un'istanza della classe Presentation
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getLineFormat().setStyle(aspose.slides.LineStyle.Single);
    chart.setRoundedCorners(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Posso impostare riempimenti semi‑trasparenti per colonne/aree mantenendo il bordo opaco?**

Sì. La trasparenza del riempimento e il contorno vengono configurati separatamente. Questo è utile per migliorare la leggibilità della griglia e dei dati in visualizzazioni dense.

**Come posso gestire le etichette dei dati quando si sovrappongono?**

Riduci la dimensione del carattere, disabilita componenti di etichetta non essenziali (ad esempio, le categorie), imposta lo spostamento/posizione dell'etichetta, mostra le etichette solo per i punti selezionati se necessario, oppure passa al formato "valore + legenda".

**Posso applicare riempimenti a gradiente o a motivo alle serie?**

Sì. Sono generalmente disponibili sia riempimenti solidi che a gradiente/motivo. In pratica, usa i gradienti con parsimonia ed evita combinazioni che riducono il contrasto con la griglia e il testo.