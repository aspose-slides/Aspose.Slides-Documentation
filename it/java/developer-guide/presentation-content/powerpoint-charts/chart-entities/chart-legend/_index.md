---
title: Personalizza le legende dei grafici nelle presentazioni usando Java
linktitle: Legenda del grafico
type: docs
url: /it/java/chart-legend/
keywords:
- legenda del grafico
- posizione della legenda
- dimensione del carattere
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Personalizza le legende dei grafici con Aspose.Slides per Java per ottimizzare le presentazioni PowerPoint con una formattazione della legenda su misura."
---
## **Panoramica**

Aspose.Slides per Java offre opzioni per personalizzare le legende dei grafici nelle presentazioni PowerPoint. Questo articolo mostra come posizionare e dimensionare una legenda, impostare la dimensione del carattere per l'intera legenda, formattare una voce di legenda individuale e nascondere o ripristinare voci selezionate.

La sezione FAQ copre comportamenti correlati, inclusa la riserva di spazio per la legenda, la visualizzazione di etichette multilinea e l'ereditarietà della formattazione dal tema della presentazione.

## **Posizionamento della Legenda**

Utilizza i metodi [setX](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setWidth-float-), e [setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setHeight-float-) della legenda per specificarne la posizione e le dimensioni come frazioni delle dimensioni del grafico.

Questo esempio crea una presentazione e aggiunge un grafico a colonne raggruppate con dati predefiniti nella prima diapositiva. Dividendo gli offset e le dimensioni desiderati della legenda per la larghezza e l'altezza del grafico, si ottengono valori relativi: la legenda è spostata di 50 punti dall'angolo superiore sinistro del grafico e dimensionata a 100 per 100 punti.

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

## **Imposta la dimensione del carattere della Legenda**

Utilizza il metodo [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getTextFormat--) della legenda per accedere alla formattazione del testo e usa [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) per impostare la dimensione del carattere in punti.

Questo esempio crea un grafico con dati predefiniti e imposta il testo della legenda a 20 punti. Disattiva inoltre i limiti automatici per l'asse verticale e imposta il suo intervallo da -5 a 10.

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

## **Imposta la dimensione del carattere di una voce di legenda individuale**

Usa la collezione restituita dal metodo [getEntries](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getEntries--) della legenda per accedere alla formattazione di una voce specifica. Gli indici delle voci sono zero‑based, quindi l'indice `1` si riferisce alla seconda voce.

Questo esempio crea un grafico a colonne raggruppate i cui dati predefiniti includono almeno due serie. Formatta la seconda voce della legenda con testo grassetto, corsivo e blu da 20 punti.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Nascondi voci di legenda individuali**

Per escludere una serie ausiliaria dalla legenda mantenendo i dati visibili, chiama [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) con `true` tramite [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getRelatedLegendEntry--). Questo nasconde solo la voce della legenda selezionata; non rimuove la serie né i suoi punti dati. Al contrario, chiamare [IChart.setLegend](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setLegend-boolean-) con `false` nasconde l'intera legenda.

L'esempio seguente crea un grafico a colonne raggruppate con più serie usando dati predefiniti. Nasconde la voce della legenda della seconda serie (indice `1`) e salva la presentazione. Quindi ripristina la voce chiamando [setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) con `false` e salva una seconda copia. Le colonne rimangono visibili in entrambi i file.

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

![Confronto di un grafico con tutte le voci della legenda visibili e con la Serie 2 nascosta dalla legenda; tutte le colonne rimangono visibili.](hide-legend-entry.png)

Nei grafici a colonne, barre e linee, le voci della legenda identificano le serie. Nei grafici a torta, identificano i singoli punti dati (fette), quindi utilizza [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) sulla fetta selezionata. L'API documenta questo metodo per i punti dati per i tipi di grafico `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` e `BarOfPie`. Non presumere che si applichi ai grafici a ciambella, che non sono inclusi in quell'elenco.

## **FAQ**

**Posso fare in modo che il grafico riservi spazio per la legenda invece di sovrapporla?**

Sì. Chiama [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-) con `false` per riservare spazio per la legenda invece di consentire che si sovrapponga all'area del grafico.

**Posso creare etichette della legenda multilinea?**

Sì. Le etichette lunghe possono andare a capo quando la larghezza disponibile è insufficiente. È inoltre possibile utilizzare caratteri di nuova riga nei nomi delle serie per richiedere interruzioni di riga.

**Come faccio a far sì che la legenda segua lo schema di colori del tema della presentazione?**

Lascia le proprietà di colore, riempimento e carattere della legenda non impostate in modo che possa ereditare la formattazione del tema. La formattazione esplicita sovrascrive le impostazioni corrispondenti del tema.