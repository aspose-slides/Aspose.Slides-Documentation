---
title: Personalizza le legende dei grafici nelle presentazioni su Android
linktitle: Legenda del grafico
type: docs
url: /it/androidjava/chart-legend/
keywords:
- legenda del grafico
- posizione della legenda
- dimensione del carattere
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Personalizza le legende dei grafici con Aspose.Slides per Android tramite Java per ottimizzare le presentazioni PowerPoint con una formattazione della legenda su misura."
---
## **Panoramica**

Aspose.Slides for Android via Java offre opzioni per personalizzare le legende dei grafici nelle presentazioni PowerPoint. Questo articolo mostra come posizionare e dimensionare una leggenda, impostare la dimensione del carattere per l’intera leggenda, formattare una voce specifica della leggenda e nascondere o ripristinare voci selezionate.

Le FAQ coprono comportamenti correlati, tra cui la riserva di spazio per la leggenda, la visualizzazione di etichette multilinea e l’ereditarietà della formattazione dal tema della presentazione.

## **Posizionamento della leggenda**

Usa i metodi della leggenda [setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setWidth-float-), e [setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setHeight-float-) per specificare la posizione e le dimensioni come frazioni delle dimensioni del grafico.

Questo esempio crea una presentazione e aggiunge un grafico a colonne raggruppate con dati predefiniti alla prima diapositiva. Dividendo gli offset e le dimensioni desiderate della leggenda per la larghezza e l’altezza del grafico si ottengono valori relativi: la leggenda è spostata di 50 punti dall’angolo superiore sinistro del grafico e dimensionata a 100 × 100 punti.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Espressione della posizione e delle dimensioni della legenda rispetto al grafico.
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Imposta la dimensione del carattere di una leggenda**

Usa [getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getTextFormat--) della leggenda per accedere alla formattazione del testo e [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) per impostare la dimensione del carattere in punti.

Questo esempio crea un grafico con dati predefiniti e imposta il testo della leggenda a 20 punti. Disabilita inoltre i limiti automatici per l’asse verticale e ne imposta l’intervallo da ‑5 a 10.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Imposta la dimensione del carattere di una voce della leggenda individuale**

Usa la raccolta restituita dal metodo [getEntries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getEntries--) della leggenda per accedere alla formattazione di una voce specifica. Gli indici delle voci partono da zero, quindi l’indice `1` si riferisce alla seconda voce.

Questo esempio crea un grafico a colonne raggruppate i cui dati predefiniti includono almeno due serie. Formatta la seconda voce della leggenda con grassetto, corsivo e testo blu di 20 punti.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartTextFormat textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(NullableBool.True);
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(NullableBool.True);
    textFormat.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nascondi voci della leggenda individuali**

Per escludere una serie ausiliaria dalla leggenda mantenendo i suoi dati visibili, chiama [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) con `true` tramite [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getRelatedLegendEntry--). Questo nasconde solo la voce della leggenda selezionata; non rimuove la serie né i suoi punti dati. Chiamare [IChart.setLegend](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setLegend-boolean-) con `false`, al contrario, nasconde l’intera leggenda.

L’esempio seguente crea un grafico a colonne raggruppate con più serie usando dati predefiniti. Nasconde la voce della leggenda della seconda serie (indice `1`) e salva la presentazione. Poi ripristina la voce chiamando [setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) con `false` e salva una seconda copia. Le colonne rimangono visibili in entrambi i file.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    ILegendEntryProperties legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx);

    // Ripristina la stessa voce senza modificare i dati del grafico.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il confronto seguente mostra lo stesso grafico con tutte le voci visibili e con la seconda voce nascosta. Le colonne della seconda serie rimangono inalterate.

![Confronto tra un grafico con tutte le voci della leggenda visibili e con la Serie 2 nascosta dalla leggenda; tutte le colonne rimangono visibili.](hide-legend-entry.png)

In grafici a colonne, barre e linee, le voci della leggenda identificano le serie. Nei grafici a torta, identificano i singoli punti dati (fette), quindi utilizza [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) sulla fetta selezionata. L’API documenta questo metodo per i tipi di grafico `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` e `BarOfPie`. Non presumere che valga per i grafici a ciambella, che non sono inclusi in tale elenco.

## **FAQ**

**Posso fare in modo che il grafico riservi spazio per la leggenda anziché sovrapporla?**

Sì. Chiama [setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setOverlay-boolean-) con `false` per riservare spazio alla leggenda invece di permettere che si sovrapponga all’area del grafico.

**Posso creare etichette della leggenda su più righe?**

Sì. Le etichette lunghe possono andare a capo quando la larghezza disponibile è insufficiente. È inoltre possibile usare caratteri di nuova riga nei nomi delle serie per richiedere interruzioni di riga.

**Come faccio a far sì che la leggenda segua lo schema colori del tema della presentazione?**

Lascia i colori, i riempimenti e i caratteri della leggenda non impostati affinché erediti la formattazione del tema. Una formattazione esplicita sovrascrive le impostazioni corrispondenti del tema.