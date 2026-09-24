---
title: Personalizza le tabelle dei dati dei grafici nelle presentazioni usando Java
linktitle: Tabella dati
type: docs
url: /it/java/chart-data-table/
keywords:
- dati del grafico
- tabella dei dati
- proprietà del carattere
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Personalizza i caratteri, i bordi e le chiavi della legenda della tabella dei dati del grafico nelle presentazioni PowerPoint usando Aspose.Slides per Java."
---
## **Panoramica**

Aspose.Slides for Java consente di visualizzare la tabella dei dati di un grafico e di personalizzare la formattazione del testo, i bordi e le chiavi della legenda. Questo articolo spiega come abilitare la tabella, formattare il testo, controllare ogni tipo di bordo e mostrare o nascondere le chiavi della legenda. Gli esempi salvano i grafici configurati in file PPTX.

## **Imposta le proprietà del carattere**

Per visualizzare la tabella dei dati di un grafico, passare `true` a [setDataTable](https://reference.aspose.com/slides/it/java/com.aspose.slides/chart/#setDataTable-boolean-). Utilizzare [getChartDataTable](https://reference.aspose.com/slides/it/java/com.aspose.slides/chart/#getChartDataTable--) per accedere alla tabella e configurare la formattazione del testo.

1. Caricare la presentazione usando la classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
1. Aggiungere un grafico a colonne raggruppate alla prima diapositiva.
1. Abilitare la tabella dei dati del grafico.
1. Abilitare il testo in grassetto con [setFontBold](https://reference.aspose.com/slides/it/java/com.aspose.slides/baseportionformat/#setFontBold-byte-) e passare `20` a [setFontHeight](https://reference.aspose.com/slides/it/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) per un testo da 20 punti.
1. Salvare la presentazione modificata.

L'esempio seguente richiede `test.pptx` nella directory di lavoro con almeno una diapositiva. Aggiunge un grafico con dati predefiniti nella posizione (50, 50), con una larghezza di 600 punti e un'altezza di 400 punti. Il file `output.pptx` salvato contiene il grafico con la tabella dei dati abilitata e le impostazioni del carattere specificate applicate.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IChartPortionFormat portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(NullableBool.True);
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Personalizza i bordi della tabella dei dati**

Abilitare la tabella con [IChart.setDataTable](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichart/#setDataTable-boolean-) e accedervi tramite [IChart.getChartDataTable](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichart/#getChartDataTable--). È possibile controllare tre tipi di bordi in modo indipendente:

- [setBorderHorizontal](https://reference.aspose.com/slides/it/java/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) controlla i bordi orizzontali delle celle.
- [setBorderVertical](https://reference.aspose.com/slides/it/java/com.aspose.slides/idatatable/#setBorderVertical-boolean-) controlla i bordi verticali delle celle.
- [setBorderOutline](https://reference.aspose.com/slides/it/java/com.aspose.slides/idatatable/#setBorderOutline-boolean-) controlla il bordo esterno della tabella.

Passare `true` a ciascun metodo per visualizzare i bordi o `false` per nasconderli. L'esempio seguente crea un grafico a colonne raggruppate con dati predefiniti, visualizza i bordi orizzontali e il bordo esterno e nasconde i bordi verticali. Non richiede alcun file di input. La posizione e le dimensioni del grafico sono specificate in punti.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il confronto sotto utilizza gli stessi dati del grafico e l'impostazione della chiave della legenda in tutti e quattro i casi. Partendo da tutti i bordi abilitati, ogni variante rimanente disabilita solo un'impostazione del bordo. La variante in basso a sinistra corrisponde alle impostazioni dei bordi nell'esempio.

![Tabelle dei dati del grafico con tutti i bordi abilitati, senza bordi orizzontali, senza bordi verticali e senza bordo esterno](data-table-borders.png)

## **Mostra o nascondi le chiavi della legenda**

Le chiavi della legenda sono piccoli marcatori colorati accanto ai nomi delle serie nella tabella dei dati. Aiutano i lettori a associare ogni riga della tabella a una serie del grafico. Passare `true` a [setShowLegendKey](https://reference.aspose.com/slides/it/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) per mostrare questi marcatori o `false` per nasconderli.

La legenda separata del grafico è controllata da [IChart.setLegend](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichart/#setLegend-boolean-). Queste impostazioni sono indipendenti: nascondere la legenda separata non nasconde le chiavi all'interno della tabella dei dati, e nascondere le chiavi della tabella non nasconde la legenda separata.

L'esempio seguente crea un grafico con dati predefiniti, abilita la sua tabella dei dati e mostra le chiavi della legenda al suo interno nascondendo la legenda separata. Tutti i bordi della tabella sono esplicitamente abilitati. Non è necessaria alcuna presentazione di input. Per nascondere solo le chiavi della tabella, passare `false` a [setShowLegendKey](https://reference.aspose.com/slides/it/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il confronto sotto mostra la stessa tabella con le chiavi della legenda abilitate e disabilitate. Tutti i bordi rimangono abilitati e la legenda separata del grafico è nascosta in entrambi i casi.

![Tabelle dei dati del grafico con le chiavi della legenda mostrate a sinistra e nascoste a destra](data-table-legend-keys.png)

## **FAQ**

**Posso mostrare le chiavi della legenda nella tabella dei dati di un grafico?**

Sì. Passare `true` a [setShowLegendKey](https://reference.aspose.com/slides/it/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-) per visualizzare le chiavi della legenda o `false` per nasconderle.

**La tabella dei dati verrà conservata quando si esporta la presentazione in PDF, HTML o immagini?**

Sì. Aspose.Slides rende il grafico e la sua tabella dei dati visualizzata come parte della diapositiva durante l'esportazione in [PDF](/slides/it/java/convert-powerpoint-to-pdf/), [HTML](/slides/it/java/convert-powerpoint-to-html/), o [immagini](/slides/it/java/convert-powerpoint-to-png/).

**Posso lavorare con le tabelle dei dati nei grafici caricati da un modello?**

Sì. Per un grafico caricato da una presentazione o modello esistente, utilizzare [hasDataTable](https://reference.aspose.com/slides/it/java/com.aspose.slides/chart/#hasDataTable--) e [setDataTable](https://reference.aspose.com/slides/it/java/com.aspose.slides/chart/#setDataTable-boolean--) per verificare o modificare se la sua tabella dei dati è visualizzata.

**Come posso trovare i grafici che hanno la tabella dei dati abilitata?**

Iterare tra le forme di ogni diapositiva, identificare i grafici e chiamare il loro metodo [hasDataTable](https://reference.aspose.com/slides/it/java/com.aspose.slides/chart/#hasDataTable--). Un valore `true` indica che la tabella dei dati è abilitata.