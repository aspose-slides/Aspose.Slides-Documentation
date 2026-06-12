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

Aspose.Slides offre opzioni per personalizzare le legende dei grafici nelle presentazioni PowerPoint. Questo articolo mostra come posizionare e dimensionare una legenda, impostare la dimensione del carattere per l'intera legenda e applicare la formattazione a una voce di legenda individuale.

Include inoltre diversi comportamenti correlati nella FAQ, tra cui l'uso della modalità non sovrapposta affinché l'area del grafico lasci spazio alla legenda, la possibilità di far avvolgere le etichette lunghe o di utilizzare interruzioni di riga, e il consentire alla formattazione della legenda di ereditare dallo schema del tema della presentazione quando non vengono applicate impostazioni esplicite di testo e riempimento.

## **Posizionamento della Legenda**
Per impostare le proprietà della legenda, seguire i passaggi seguenti:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
- Ottieni il riferimento della diapositiva.
- Aggiungi un grafico sulla diapositiva.
- Imposta le proprietà della legenda.
- Scrivi la presentazione come file PPTX.

Nell'esempio riportato di seguito, abbiamo impostato la posizione e le dimensioni della legenda del grafico.

```java
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation();
try {
    // Ottieni il riferimento della diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Aggiungi un grafico a colonne raggruppate sulla diapositiva
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Imposta le proprietà della legenda
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

## **Impostare la Dimensione del Carattere di una Legenda**
Aspose.Slides per Java consente agli sviluppatori di impostare la dimensione del carattere della legenda. Seguire i passaggi seguenti:

- Istanzia la classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
- Crea il grafico predefinito.
- Imposta la Dimensione del Carattere.
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

## **Impostare la Dimensione del Carattere di una Legenda Individuale**
Aspose.Slides per Java consente agli sviluppatori di impostare la dimensione del carattere delle voci individuali della legenda. Seguire i passaggi seguenti:

- Istanzia la classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
- Crea il grafico predefinito.
- Accedi alla voce della legenda.
- Imposta la Dimensione del Carattere.
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

**Posso abilitare la legenda in modo che il grafico riservi automaticamente spazio per essa invece di sovrapporla?**

Sì. Usa la modalità non sovrapposta ([setOverlay(false)](https://reference.aspose.com/slides/it/java/com.aspose.slides/legend/#setOverlay-boolean-)); in questo caso, l'area del grafico si ridurrà per ospitare la legenda.

**Posso creare etichette di legenda su più righe?**

Sì. Le etichette lunghe vanno a capo automaticamente quando lo spazio è insufficiente; i ritorni a capo forzati sono supportati tramite caratteri di nuova riga nel nome della serie.

**Come posso fare in modo che la legenda segua lo schema di colori del tema della presentazione?**

Non impostare colori, riempimenti o caratteri espliciti per la legenda o il suo testo. In questo modo erediteranno dal tema e si aggiorneranno correttamente quando il design cambia.