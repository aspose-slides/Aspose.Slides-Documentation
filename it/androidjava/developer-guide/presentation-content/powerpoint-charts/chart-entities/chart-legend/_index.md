---
title: Personalizza le leggende dei grafici nelle presentazioni su Android
linktitle: Legenda del grafico
type: docs
url: /it/androidjava/chart-legend/
keywords:
- legenda del grafico
- posizione della leggenda
- dimensione del carattere
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Personalizza le leggende dei grafici con Aspose.Slides per Android via Java per ottimizzare le presentazioni PowerPoint con una formattazione della leggenda su misura."
---
## **Panoramica**

Aspose.Slides fornisce opzioni per personalizzare le legende dei grafici nelle presentazioni PowerPoint. Questo articolo mostra come posizionare e dimensionare una leggenda, impostare la dimensione del carattere per l'intera leggenda e applicare formattazioni a una voce di leggenda individuale.

Copre inoltre diversi comportamenti correlati nella FAQ, inclusa l'utilizzo della modalità non sovrapposta in modo che l'area del grafico lasci spazio per la leggenda, consentendo alle etichette lunghe di avvolgersi o di usare interruzioni di riga, e permettendo alla formattazione della leggenda di ereditare dal tema della presentazione quando non vengono impostati esplicitamente testo e riempimento.

## **Posizionamento della Leggenda**
In order to set the legend properties. Please follow the steps below:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) class.
- Ottieni il riferimento della diapositiva.
- Aggiungi un grafico alla diapositiva.
- Imposta le proprietà della leggenda.
- Scrivi la presentazione in un file PPTX.

Nell'esempio mostrato di seguito, abbiamo impostato la posizione e le dimensioni per la leggenda del grafico.

```java
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation();
try {
    // Ottieni il riferimento della diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Aggiungi un grafico a colonne raggruppate alla diapositiva
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Imposta le proprietà della leggenda
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // Scrivi la presentazione su disco
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Imposta la dimensione del carattere di una leggenda**
The Aspose.Slides for Android via Java lets developers allow to set font size of legend. Please follow the steps below: 

- Istanzia la classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) class.
- Crea il grafico predefinito.
- Imposta la dimensione del carattere.
- Imposta il valore minimo dell'asse.
- Imposta il valore massimo dell'asse.
- Scrivi la presentazione su disco.

```java
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);

    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Imposta la dimensione del carattere di una leggenda individuale**
The Aspose.Slides for Android via Java lets developers allow to set font size of individual legend entries. Please follow the steps below: 

- Istanzia la classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) class.
- Crea il grafico predefinito.
- Accedi alla voce della leggenda.
- Imposta la dimensione del carattere.
- Imposta il valore minimo dell'asse.
- Imposta il valore massimo dell'asse.
- Scrivi la presentazione su disco.

```java
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IChartTextFormat tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    tf.getPortionFormat().setFontBold(NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso abilitare la leggenda in modo che il grafico riservi automaticamente spazio per essa invece di sovrapporla?**

Sì. Usa la modalità non sovrapposta ([setOverlay(false)](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/legend/#setOverlay-boolean-)); in questo caso, l'area del grafico si ridurrà per accogliere la leggenda.

**Posso creare etichette della leggenda su più righe?**

Sì. Le etichette lunghe si avvolgono automaticamente quando lo spazio è insufficiente; le interruzioni di riga forzate sono supportate tramite caratteri di nuova linea nel nome della serie.

**Come posso fare in modo che la leggenda segua lo schema di colori del tema della presentazione?**

Non impostare colori/riempimenti/caratteri espliciti per la leggenda o il suo testo. In tal caso erediteranno dal tema e si aggiorneranno correttamente quando il design cambia.