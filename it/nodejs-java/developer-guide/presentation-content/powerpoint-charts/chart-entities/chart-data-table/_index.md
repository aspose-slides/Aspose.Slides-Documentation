---
title: Personalizza le tabelle dei dati dei grafici nelle presentazioni usando JavaScript
linktitle: Tabella dati
type: docs
url: /it/nodejs-java/chart-data-table/
keywords:
- dati del grafico
- tabella dati
- proprietà del carattere
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Personalizza i caratteri, i bordi e le chiavi della legenda della tabella dei dati del grafico nelle presentazioni PowerPoint usando Aspose.Slides per Node.js tramite Java."
---
## **Panoramica**

Aspose.Slides per Node.js tramite Java consente di visualizzare la tabella dei dati di un grafico e personalizzare la formattazione del testo, i bordi e le chiavi della legenda. Questo articolo spiega come abilitare la tabella, formattare il suo testo, controllare ciascun tipo di bordo e mostrare o nascondere le chiavi della legenda. Gli esempi salvano i grafici configurati in file PPTX.

## **Imposta proprietà del carattere**

Per visualizzare la tabella dei dati di un grafico, passare `true` a [setDataTable](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chart/setdatatable/). Utilizzare [getChartDataTable](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chart/getchartdatatable/) per accedere alla tabella e configurarne la formattazione del testo.

1. Carica la presentazione usando la classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Aggiungi un grafico a colonne raggruppate alla prima diapositiva.
1. Abilita la tabella dei dati del grafico.
1. Abilita il testo in grassetto con [setFontBold](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseportionformat/#setfontbold) e passa `20` a [setFontHeight](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseportionformat/#setfontheight) per un testo di 20 punti.
1. Salva la presentazione modificata.

L'esempio seguente richiede `input.pptx` nella directory di lavoro con almeno una diapositiva. Aggiunge un grafico con dati predefiniti nella posizione (50, 50), con una larghezza di 600 punti e un'altezza di 400 punti. Il file `output.pptx` salvato contiene il grafico con la tabella dei dati abilitata e le impostazioni del carattere specificate applicate.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Personalizza i bordi della tabella dei dati**

Abilita la tabella con [Chart.setDataTable](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chart/setdatatable/) e accedila tramite [Chart.getChartDataTable](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chart/getchartdatatable/). È possibile controllare tre tipi di bordi in modo indipendente:

- [setBorderHorizontal](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/datatable/setborderhorizontal/) controlla i bordi orizzontali delle celle.
- [setBorderVertical](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/datatable/setbordervertical/) controlla i bordi verticali delle celle.
- [setBorderOutline](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/datatable/setborderoutline/) controlla il bordo esterno della tabella.

Passare `true` a ciascun metodo per visualizzare i relativi bordi o `false` per nasconderli. L'esempio seguente crea un grafico a colonne raggruppate con dati predefiniti, visualizza i bordi orizzontali e il bordo esterno, e nasconde i bordi verticali. Non richiede alcun file di input. La posizione e le dimensioni del grafico sono specificate in punti.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il confronto riportato di seguito utilizza gli stessi dati del grafico e le stesse impostazioni delle chiavi della legenda in tutti e quattro i casi. Partendo da tutti i bordi abilitati, ciascuna variante rimanente disabilita solo un'impostazione del bordo. La variante in basso a sinistra corrisponde alle impostazioni dei bordi dell'esempio.

![Tabelle dei dati del grafico con tutti i bordi abilitati, senza bordi orizzontali, senza bordi verticali e senza bordo esterno](data-table-borders.png)

## **Mostra o nascondi le chiavi della legenda**

Le chiavi della legenda sono piccoli marcatori colorati accanto ai nomi delle serie nella tabella dei dati. Aiutano i lettori a collegare ogni riga della tabella a una serie del grafico. Passare `true` a [setShowLegendKey](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/datatable/setshowlegendkey/) per mostrare questi marcatori o `false` per nasconderli.

La legenda separata del grafico è controllata da [Chart.setLegend](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chart/setlegend/). Queste impostazioni sono indipendenti: nascondere la legenda separata non nasconde le chiavi all'interno della tabella dei dati, e nascondere le chiavi della tabella non nasconde la legenda separata.

L'esempio seguente crea un grafico con dati predefiniti, abilita la sua tabella dei dati e mostra le chiavi della legenda al suo interno nascondendo la legenda separata. Tutti i bordi della tabella sono esplicitamente abilitati. Non è necessaria alcuna presentazione di input. Per nascondere solo le chiavi della tabella, passare `false` a [setShowLegendKey](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/datatable/setshowlegendkey/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il confronto riportato di seguito mostra la stessa tabella con le chiavi della legenda abilitate e disabilitate. Tutti i bordi rimangono abilitati e la legenda separata del grafico è nascosta in entrambi i casi.

![Tabelle dei dati del grafico con le chiavi della legenda mostrate a sinistra e nascoste a destra](data-table-legend-keys.png)

## **FAQ**

**Posso mostrare le chiavi della legenda nella tabella dei dati di un grafico?**

Sì. Passare `true` a [setShowLegendKey](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/datatable/setshowlegendkey/) per visualizzare le chiavi della legenda o `false` per nasconderle.

**La tabella dei dati verrà preservata durante l'esportazione della presentazione in PDF, HTML o immagini?**

Sì. Aspose.Slides rende il grafico e la sua tabella dei dati visualizzata come parte della diapositiva durante l'esportazione in [PDF](/slides/it/nodejs-java/convert-powerpoint-to-pdf/), [HTML](/slides/it/nodejs-java/convert-powerpoint-to-html/) o [images](/slides/it/nodejs-java/convert-powerpoint-to-png/).

**Posso lavorare con le tabelle dei dati nei grafici caricati da un modello?**

Sì. Per un grafico caricato da una presentazione o modello esistente, utilizzare [hasDataTable](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chart/hasdatatable/) e [setDataTable](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chart/setdatatable/) per verificare o modificare se la sua tabella dei dati è visualizzata.

**Come posso trovare i grafici che hanno la tabella dei dati abilitata?**

Iterare attraverso le forme di ogni diapositiva, identificare i grafici e chiamare il loro metodo [hasDataTable](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chart/hasdatatable/). Un valore `true` indica che la tabella dei dati è abilitata.