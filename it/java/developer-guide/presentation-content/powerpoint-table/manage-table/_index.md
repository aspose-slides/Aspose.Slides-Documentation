---
title: Gestire le tabelle delle presentazioni in Java
linktitle: Gestisci tabella
type: docs
weight: 10
url: /it/java/manage-table/
keywords:
- aggiungere tabella
- creare tabella
- accedere tabella
- rapporto d'aspetto
- allineare testo
- formattazione testo
- stile tabella
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Crea e modifica tabelle nelle diapositive PowerPoint con Aspose.Slides per Java. Scopri semplici esempi di codice per semplificare i tuoi flussi di lavoro con le tabelle."
---
## **Introduzione**

Le tabelle in PowerPoint organizzano le informazioni in righe e colonne, rendendo più facile la lettura e il confronto dei valori.

Aspose.Slides provides the [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/) class, [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) interface, [Cell](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) class, [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) interface, and other types to allow you to create, update, and manage tables in presentations.

## **Creare una tabella da zero**

Create a table by specifying its position, column widths, and row heights. After adding it to a slide, you can format cell borders, merge cells, and insert text.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Ottieni un riferimento alla diapositiva tramite il suo indice.
3. Definisci un array di larghezze delle colonne in punti.
4. Definisci un array di altezze delle righe in punti.
5. Aggiungi un oggetto [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) alla diapositiva tramite il metodo [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
6. Itera su ciascun [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) per applicare la formattazione ai bordi superiore, inferiore, destro e sinistro.
7. Unisci le prime due celle della prima riga della tabella.
8. Accedi alla cella unita tramite il suo metodo [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--).
9. Imposta il testo nella cella unita.
10. Salva la presentazione modificata.

L'esempio riportato di seguito crea una tabella con tre colonne e cinque righe a (100, 50) punti. Applica bordi rossi con una larghezza di 5 punti, unisce le prime due celle nella prima riga e salva il risultato come `table.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Numerazione in una tabella standard**

In una tabella standard, gli indici delle celle sono basati su zero e usano l'ordine (colonna, riga). La prima cella ha indice (0, 0).

Ad esempio, le celle di una tabella con 4 colonne e 4 righe sono numerate in questo modo:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

L'esempio crea la tabella 4 × 4 illustrata sopra, con larghezze delle colonne e altezze delle righe di 70 punti e bordi delle celle rossi con una larghezza di 5 punti. Le coordinate illustrano gli indici delle celle; l'esempio lascia le celle vuote e salva la tabella come `StandardTables_out.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Accedere a una tabella esistente**

Le tabelle sono memorizzate nella collezione di forme di una diapositiva. Itera tra le forme per individuare una tabella, quindi utilizza l'interfaccia [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) per leggere o aggiornare le sue celle.

1. Carica la presentazione utilizzando la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Ottieni un riferimento alla diapositiva che contiene la tabella tramite il suo indice.
3. Itera tra gli oggetti [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) e interrompi quando trovi una tabella. Se la diapositiva contiene diverse tabelle, utilizza [getAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getAlternativeText--) per identificare quella di cui hai bisogno.
4. Aggiorna il testo nella cella target.
5. Salva la presentazione modificata.

L'esempio riportato di seguito apre `UpdateExistingTable.pptx` e trova la prima tabella nella prima diapositiva. Imposta la cella nella colonna 0, riga 1 a `New` e salva il risultato come `table1_out.pptx`. L'input deve contenere almeno una diapositiva, e la prima tabella su quella diapositiva deve avere almeno una colonna e due righe.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("UpdateExistingTable.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof ITable) {
            table = (ITable) shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Per ridimensionare una riga in una tabella esistente e capire perché la sua altezza reale può superare il minimo richiesto, vedi [Controlla l'altezza della riga](/slides/it/java/manage-rows-and-columns/#control-row-height).

## **Trovare la cella che possiede un frame di testo**

Quando un codice generico di elaborazione del testo riceve un [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) da una tabella, utilizza il metodo [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) per recuperare la [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) proprietaria. Per un frame di testo di una cella di tabella, [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) restituisce il proprietario e [ITextFrame.getParentShape](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentShape--) restituisce `null`, anche se la tabella stessa è una forma.

Le coordinate della cella sono disponibili tramite i metodi di sola lettura [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) e [ICell.getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--). [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) fornisce anche una navigazione di sola lettura: restituisce il proprietario ma non ne modifica la proprietà. Controlla sempre se la cella restituita è `null` prima di usarla.

Per un esempio completo che identifica i proprietari di celle e forme, incluse le forme associate a nodi SmartArt, vedi [Cerca e sostituisci testo](/slides/it/java/search-and-replace-text/).

## **Allineare il testo in una tabella**

Puoi controllare l'ancoraggio verticale e la direzione del testo delle singole celle della tabella. L'esempio in questa sezione centra il testo nella prima cella e lo ruota di 270 gradi.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Ottieni un riferimento alla diapositiva tramite il suo indice.
3. Aggiungi un oggetto [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) alla diapositiva.
4. Accedi a un oggetto [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) dalla tabella.
5. Accedi al primo [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) e imposta il suo testo e colore.
6. Imposta l'ancoraggio verticale della cella e la direzione del testo utilizzando [setTextAnchorType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextAnchorType-byte-) e [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextVerticalType-byte-).
7. Salva la presentazione modificata.

Questo esempio crea una tabella 4 × 4 con larghezze delle colonne di 120 punti e altezze delle righe di 100 punti. Formatta il testo nella cella (0, 0), aggiunge valori alle restanti celle della prima riga e salva il risultato come `Vertical_Align_Text_out.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 120, 120, 120, 120 };
    double[] rowHeights = { 100, 100, 100, 100 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    ITextFrame textFrame = table.get_Item(0, 0).getTextFrame();
    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);

    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ICell cell = table.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Impostare la formattazione del testo a livello di tabella**

Usa [setTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) per applicare la formattazione del testo a tutte le celle di una tabella. Le sue overload accettano la formattazione di porzione, paragrafo e frame di testo, così puoi impostare queste proprietà senza iterare le singole celle.

1. Carica la presentazione usando la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Ottieni un riferimento alla diapositiva tramite il suo indice.
3. Accedi a un oggetto [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) dalla diapositiva.
4. Imposta la dimensione del carattere usando [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) per il testo.
5. Imposta l'allineamento del paragrafo e il margine destro usando [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) e [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Imposta la direzione del testo usando [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Salva la presentazione modificata.

L'esempio riportato di seguito apre `table.pptx`, che deve contenere almeno una diapositiva con una tabella come prima forma. Imposta la dimensione del carattere a 25 punti, allinea a destra i paragrafi con un margine destro di 20 punti e rende il testo verticale. La presentazione formattata viene salvata come `result.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ottenere le proprietà di stile della tabella**

Usa [getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--) per leggere lo stile predefinito di una tabella e [setStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setStylePreset-int-) per assegnarlo. Questo esempio applica [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/) a una tabella, stampa il valore del preset e assegna lo stesso preset a una seconda tabella. Entrambe le tabelle vengono salvate in `table-style.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 100, 150 };
    double[] rowHeights = { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    ITable anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bloccare il rapporto d'aspetto di una tabella**

Il rapporto d'aspetto di una tabella è il rapporto tra la sua larghezza e la sua altezza. Usa [setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) per bloccare questo rapporto per una tabella.

L'esempio riportato di seguito apre `pres.pptx`, che deve contenere almeno una diapositiva con una tabella come prima forma. Stampa lo stato di blocco corrente, abilita il blocco del rapporto d'aspetto, stampa lo stato aggiornato (`true`) e salva il risultato come `pres-out.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable) slide.getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Posso abilitare la direzione di lettura da destra a sinistra (RTL) per un'intera tabella e il testo nelle sue celle?**

Sì. La tabella espone un metodo [setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/table/#setRightToLeft-boolean-), e i paragrafi hanno [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). L'uso di entrambi garantisce l'ordine RTL corretto e il rendering all'interno delle celle.

**Come posso impedire agli utenti di spostare o ridimensionare una tabella nel file finale?**

Usa [blocchi di forma](/slides/it/java/applying-protection-to-presentation/) per disabilitare lo spostamento, il ridimensionamento, la selezione, ecc. Questi blocchi si applicano anche alle tabelle.

**È supportato inserire un'immagine all'interno di una cella come sfondo?**

Sì. È possibile impostare un [riempimento immagine](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) per una cella; l'immagine coprirà l'area della cella secondo la modalità scelta (allungamento o affiancamento).