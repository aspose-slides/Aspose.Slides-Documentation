---
title: Personalizza le legende dei grafici nelle presentazioni con JavaScript
linktitle: Legenda del grafico
type: docs
url: /it/nodejs-java/chart-legend/
keywords:
- legenda del grafico
- posizione della legenda
- dimensione del carattere
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Personalizza le legende dei grafici con JavaScript e Aspose.Slides per Node.js per ottimizzare le presentazioni PowerPoint con una formattazione della legenda su misura."
---
## **Panoramica**

Aspose.Slides offre opzioni per personalizzare le legende dei grafici nelle presentazioni PowerPoint. Questo articolo mostra come posizionare e dimensionare una legenda, impostare la dimensione del carattere per l'intera legenda e applicare formattazioni a una voce di legenda individuale.

Copre anche diversi comportamenti correlati nella FAQ, inclusa l'uso della modalità non sovrapposta in modo che l'area del grafico lasci spazio alla legenda, consentendo alle etichette lunghe di andare a capo o utilizzare interruzioni di riga, e facendo ereditare la formattazione della legenda dal tema della presentazione quando non vengono applicate impostazioni esplicite di testo e riempimento.

## **Posizionamento della legenda**

Per impostare le proprietà della legenda, seguire i passaggi riportati di seguito:

- Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
- Ottenere il riferimento della diapositiva.
- Aggiungere un grafico alla diapositiva.
- Impostare le proprietà della legenda.
- Scrivere la presentazione in un file PPTX.

Nell'esempio mostrato di seguito, abbiamo impostato la posizione e le dimensioni della legenda del grafico.

```javascript
// Crea un'istanza della classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Ottieni il riferimento della diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Aggiungi un grafico a colonne raggruppate nella diapositiva
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);
    // Imposta le proprietà della legenda
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    // Scrivi la presentazione su disco
    pres.save("Legend_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Imposta la dimensione del carattere della legenda**

Aspose.Slides per Node.js via Java consente agli sviluppatori di impostare la dimensione del carattere della legenda. Seguire i passaggi riportati di seguito:

- Istanziare la classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
- Creare il grafico predefinito.
- Impostare la dimensione del carattere.
- Impostare il valore minimo dell'asse.
- Impostare il valore massimo dell'asse.
- Scrivere la presentazione su disco.

```javascript
// Crea un'istanza della classe Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Imposta la dimensione del carattere della legenda individuale**

Aspose.Slides per Node.js via Java consente agli sviluppatori di impostare la dimensione del carattere delle voci di legenda individuali. Seguire i passaggi riportati di seguito:

- Istanziare la classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
- Creare il grafico predefinito.
- Accedere alla voce della legenda.
- Impostare la dimensione del carattere.
- Impostare il valore minimo dell'asse.
- Impostare il valore massimo dell'asse.
- Scrivere la presentazione su disco.

```javascript
// Crea un'istanza della classe Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();
    tf.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Posso abilitare la legenda in modo che il grafico allochi automaticamente spazio per essa invece di sovrapporsi?**

Sì. Utilizzare la modalità non sovrapposta ([setOverlay(false)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/legend/setoverlay/)); in questo caso, l'area del grafico si ridurrà per ospitare la legenda.

**Posso creare etichette della legenda su più righe?**

Sì. Le etichette lunghe vanno a capo automaticamente quando lo spazio è insufficiente; le interruzioni di riga forzate sono supportate tramite caratteri di nuova linea nel nome della serie.

**Come faccio a far seguire alla legenda lo schema di colori del tema della presentazione?**

Non impostare colori/riempimenti/caratteri espliciti per la legenda o il suo testo. In tal modo erediteranno dal tema e si aggiorneranno correttamente quando il design viene modificato.