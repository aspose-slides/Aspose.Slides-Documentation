---
title: Formattare i grafici di presentazione in Java
linktitle: Formattazione del grafico
type: docs
weight: 60
url: /it/java/chart-formatting/
keywords:
- formattare grafico
- formattazione grafico
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
description: "Impara la formattazione dei grafici in Aspose.Slides per Java e migliora la tua presentazione PowerPoint con assi personalizzati, caratteri, formati numerici e bordi arrotondati dei grafici."
---
## **Panoramica**

Questo articolo spiega come formattare i grafici nelle presentazioni PowerPoint utilizzando Aspose.Slides. Mostra come personalizzare gli elementi chiave del grafico, come assi, linee della griglia, titoli, legende, area del grafico e riempimenti delle pareti, per migliorare l’aspetto e la leggibilità dei dati del grafico.

Dimostra inoltre come impostare le proprietà dei caratteri per il testo del grafico, applicare formati numerici predefiniti ai dati del grafico e abilitare gli angoli arrotondati per l’area del grafico. Insieme, questi esempi mostrano come controllare sia lo stile visivo sia la presentazione dei dati dei grafici in una presentazione.

Per riempimenti e contorni separati su intervalli crescenti e decrescenti, vedere l’[esempio di grafico azionario](/slides/it/java/create-chart/#create-stock-charts).

## **Formattare le entità del grafico**

Utilizzare [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) per formattare titoli del grafico, assi, linee della griglia, legende e area del grafico. Questo esempio crea un grafico a linee con marcatori e dati predefiniti, quindi applica stili di testo e di linea separati ai suoi assi dei valori e delle categorie. Le dimensioni del carattere e gli spessori delle linee sono specificati in punti; le etichette delle categorie sono ruotate di 45 gradi.

L'asse dei valori utilizza [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) indipendentemente dalle celle di origine. La sua scala va da -2 a 15, con intervalli principali di 2 e intervalli secondari di 0,5. L’esempio combina anche la formattazione percentuale con [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setDisplayUnit-int-) impostata su migliaia, quindi adatta queste impostazioni al significato e alla magnitudine dei tuoi dati. La legenda rimane fuori dall’area del grafico perché [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/ilegend/#setOverlay-boolean-) viene chiamato con `false`. I riempimenti del retro-parete e del pavimento sono configurati tramite [getBackWall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--) e [getFloor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--), ma queste superfici sono visibili solo nei grafici 3D.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    IChartPortionFormat valueAxisText = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    valueAxisText.setFontBold(NullableBool.True);
    valueAxisText.setFontHeight(16);
    valueAxisText.setFontItalic(NullableBool.True);
    valueAxisText.getFillFormat().setFillType(FillType.Solid);
    valueAxisText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen);
    valueAxisText.setLatinFont(new FontData("Times New Roman"));

    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valueAxisTitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valueAxisTitle.setText("Primary Axis");
    valueAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valueAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valueAxisTitle.getPortionFormat().setFontHeight(20);
    valueAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    valueAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(new Color(0, 128, 0));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    IChartPortionFormat categoryAxisText = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    categoryAxisText.setFontBold(NullableBool.True);
    categoryAxisText.setFontHeight(16);
    categoryAxisText.setFontItalic(NullableBool.True);
    categoryAxisText.getFillFormat().setFillType(FillType.Solid);
    categoryAxisText.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    categoryAxisText.setLatinFont(new FontData("Arial"));

    chart.getAxes().getHorizontalAxis().setTitle(true);
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion categoryAxisTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    categoryAxisTitle.setText("Sample Category");
    categoryAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    categoryAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    categoryAxisTitle.getPortionFormat().setFontHeight(20);
    categoryAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    categoryAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    IChartPortionFormat legendText = chart.getLegend().getTextFormat().getPortionFormat();
    legendText.setFontBold(NullableBool.True);
    legendText.setFontHeight(16);
    legendText.setFontItalic(NullableBool.True);
    legendText.getFillFormat().setFillType(FillType.Solid);
    legendText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed);

    chart.getLegend().setOverlay(false);

    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(new Color(255, 165, 0));

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan);

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Impostare le proprietà del carattere per un grafico**

Impostare la dimensione predefinita del carattere per il testo del grafico tramite [Chart.getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getTextFormat--). L’esempio crea un grafico a colonne raggruppate con un carattere da 20 punti e abilita le etichette dei valori per la prima serie tramite [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). Gli elementi di testo con impostazioni di carattere esplicite possono sovrascrivere il valore predefinito del grafico.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Riutilizzare la formattazione del riquadro di testo per la legenda del grafico**

Per far corrispondere una legenda a un’intestazione della diapositiva, impostare il carattere dell’intestazione tramite [getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) nel primo paragrafo. Chiamare [copyFrom](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextformat/#copyFrom-com.aspose.slides.ITextFrame-) sul formato restituito dal [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iformattedtextcontainer/#getTextFormat--) della legenda. Copia le impostazioni del riquadro di testo, la formattazione del primo paragrafo e le proprietà del carattere predefinite di quel paragrafo. La formattazione applicata direttamente a singole porzioni o a paragrafi successivi resta locale alla sorgente.

L’esempio utilizza un’intestazione in grassetto, 26 punti, Calibri, di colore navy come modello. Dopo aver stilizzato la legenda, chiama [copyTo](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextformat/#copyTo-com.aspose.slides.ITextFrame-) per applicare la stessa formattazione a una didascalia separata.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    
    IAutoShape heading = shapes.addAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
    ITextFrame sourceTextFrame = heading.addTextFrame("Quarterly sales");
    IPortionFormat font = sourceTextFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    font.setLatinFont(new FontData("Calibri"));
    font.setFontHeight(26);
    font.setFontBold(NullableBool.True);
    font.getFillFormat().setFillType(FillType.Solid);
    font.getFillFormat().getSolidFillColor().setColor(new Color(32, 64, 96));

    IChart chart = shapes.addChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
    chart.setStyle(StyleType.Style3);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.getCell(0, 0, 1).setValue("Retail");
    workbook.getCell(0, 0, 2).setValue("Online");
    workbook.getCell(0, 0, 3).setValue("Wholesale");
    for (int quarter = 1; quarter <= 4; quarter++) {
        workbook.getCell(0, quarter, 0).setValue("Q" + quarter);
    }

    chart.setLegend(true);
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    IChartTextFormat legendFormat = chart.getLegend().getTextFormat();
    legendFormat.copyFrom(sourceTextFrame);

    IAutoShape caption = shapes.addAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
    ITextFrame captionTextFrame = caption.addTextFrame("Sales in millions of dollars");
    legendFormat.copyTo(captionTextFrame);

    presentation.save("legend-formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nella presentazione salvata, la legenda e la didascalia corrispondono all’intestazione per dimensione, peso e colore. La legenda continua a visualizzare i nomi delle serie, e la didascalia mantiene il proprio testo. Se una porzione nella didascalia ha già una dimensione del carattere esplicita, tale dimensione ha la precedenza sul valore predefinito del paragrafo copiato.

| Prima della copia | Dopo la copia |
| --- | --- |
| ![Grafico delle vendite trimestrali con etichette della legenda nera regolare e didascalia nera](legend-formatting-before.png) | ![Lo stesso grafico con etichette della legenda più grandi, in grassetto e navy, e didascalia corrispondente](legend-formatting.png) |

## **Impostare il formato numerico**

Utilizzare [IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-) per applicare un formato numerico integrato alle celle del foglio di lavoro del grafico. Questo esempio crea un grafico a colonne raggruppate con dati predefiniti basati su celle e applica l’indice di formato 10 (`0.00%`) a ciascuna cella dei valori della serie. Cambia il modo in cui i valori sono visualizzati nel foglio di lavoro senza alterare i numeri sottostanti; ad esempio, 0,25 viene visualizzato come 25,00 %. I formati per gli assi e le etichette dei dati possono essere configurati separatamente.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    for (IChartSeries chartSeries : series)
    {
        for (IChartDataPoint dataPoint : chartSeries.getDataPoints())
        {
            dataPoint.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La tabella seguente elenca gli indici dei formati numerici integrati con i formati Excel rappresentativi per la locale English (United States). Le stringhe di formato esatte e la loro visualizzazione possono variare a seconda dell’applicazione e della locale, in particolare per valute e date. Alcuni formati Excel differiscono dai valori predefiniti nello standard OOXML, come descritto nelle [note di implementazione del formato numerico di Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Indice | Formato |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Impostare bordi arrotondati per l’area del grafico**

Chiamare [IChart.setRoundedCorners](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setRoundedCorners-boolean-) con `true` per arrotondare gli angoli dell’area del grafico. L’esempio crea un grafico a colonne raggruppate e utilizza [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) per assegnare al contorno un colore grigio solido e uno stile a linea singola prima di salvare la presentazione.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    presentation.save("out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Modificare le annotazioni di un grafico esistente**

Un grafico può contenere forme personalizzate, come un’annotazione di testo che spiega lo stato di un report. Accedere a queste forme tramite [IChart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getUserShapes--), elencate anche sotto [Chart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getUserShapes--) nella Documentazione API di Chart. La raccolta restituita da [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) contiene le forme di proprietà del grafico.

Una casella di testo ordinaria posizionata sopra un grafico appartiene alla diapositiva, anche se sembra parte del grafico. Iterare attraverso [Slide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) individua il grafico e le forme ortogonalmente della diapositiva, ma non enumera le singole forme all’interno del grafico. Titoli del grafico ed etichette dei dati sono elementi separati del grafico, non annotazioni personalizzate in questa raccolta.

Scaricare [chart-annotations.pptx](chart-annotations.pptx) e posizionarlo nella directory di lavoro dell’applicazione. La sua prima diapositiva contiene un grafico con un’annotazione non raggruppata che recita “Preliminary results”, una linea di proprietà del grafico e una casella di testo della diapositiva che recita “Slide overlay”. L’esempio trova il primo grafico su quella diapositiva e cambia l’annotazione in “Final results” quando il report è pronto per la pubblicazione. Controlla una raccolta vuota e modifica solo un [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) con un riquadro di testo non nullo restituito da [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#getTextFrame--) e con il testo previsto.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-annotations.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IChart) {
            chart = (IChart) shape;
            break;
        }
    }

    if (chart == null || chart.getUserShapes().getShapes().size() == 0) {
        System.out.println("No chart or chart-owned shapes found.");
        return;
    }

    boolean updated = false;
    for (IShape shape : chart.getUserShapes().getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape annotation = (IAutoShape) shape;
            if (annotation.getTextFrame() != null && "Preliminary results".equals(annotation.getTextFrame().getText())) {
                annotation.getTextFrame().setText("Final results");
                updated = true;
                break;
            }
        }
    }

    if (updated) {
        presentation.save("chart-annotations-updated.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No matching text annotation found.");
    }
} finally {
    presentation.dispose();
}
```

La linea e la casella di testo della diapositiva rimangono inalterate. Le immagini seguenti mostrano l’input e il risultato salvato, riaperto:

| Prima della modifica | Dopo la modifica |
| --- | --- |
| ![Annotazione del grafico con testo Preliminary results](chart-annotations-before.png) | ![Annotazione del grafico con testo Final results](chart-annotations-after.png) |

{{% alert color="info" title="Nota" %}}
L’esempio esamina solo le forme di proprietà del grafico di livello superiore. Se un’annotazione è all’interno di un [IGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/), ispezionare anche la raccolta [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) di quel gruppo. Ripetere ricorsivamente per gruppi nidificati, applicando gli stessi controlli di testo alle loro forme figlie. Un gruppo è un contenitore; non trattarlo come una casella di testo.
{{% /alert %}}

## **FAQ**

**Posso impostare riempimenti semitrasparenti per colonne/aree mantenendo il contorno opaco?**

Sì. La trasparenza del riempimento e il contorno sono configurati separatamente. Questo è utile per migliorare la leggibilità della griglia e dei dati in visualizzazioni dense.

**Come gestire le etichette dei dati quando si sovrappongono?**

Ridurre la dimensione del carattere, disabilitare componenti di etichetta non essenziali (ad esempio, le categorie), regolare la posizione dell’etichetta, mostrare le etichette solo per i punti selezionati se necessario, oppure passare al formato “valore + legenda”.

**Posso applicare riempimenti a gradiente o a trama alle serie?**

Sì. Le serie supportano riempimenti solidi, a gradiente e a trama. In pratica, utilizzare i gradienti con parsimonia ed evitare combinazioni che riducono il contrasto con la griglia e il testo.