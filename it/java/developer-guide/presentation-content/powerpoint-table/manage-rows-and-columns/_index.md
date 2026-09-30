---
title: Gestisci righe e colonne nelle tabelle PowerPoint usando Java
linktitle: Righe e colonne
type: docs
weight: 20
url: /it/java/manage-rows-and-columns/
keywords:
- riga della tabella
- colonna della tabella
- prima riga
- intestazione della tabella
- clonare riga
- clonare colonna
- copia riga
- copia colonna
- rimuovere riga
- rimuovere colonna
- formattazione testo riga
- formattazione testo colonna
- stile della tabella
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Gestisci righe e colonne delle tabelle in PowerPoint con Aspose.Slides per Java e velocizza la modifica delle presentazioni e l'aggiornamento dei dati."
---
## **Introduzione**

Aspose.Slides for Java ti consente di gestire la struttura e la formattazione delle tabelle nelle presentazioni PowerPoint tramite la classe [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/) e l'interfaccia [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/). Puoi designare una riga di intestazione, clonare o rimuovere righe e colonne, e applicare la formattazione del testo a un'intera riga o colonna.

Questo articolo spiega queste operazioni con esempi Java. Mostra anche come recuperare il preset di stile di una tabella in modo da poterlo riutilizzare. Gli indici di righe e colonne della tabella sono a base zero.

## **Controllo altezza riga**

Usa [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-) per impostare l'altezza minima di una riga in punti. È un limite inferiore, non un'altezza fissa. [IRow.getHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#getHeight--) restituisce l'altezza effettiva. Accedi alla riga tramite [ITable.getRows](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getRows--).

L'esempio carica [row-height-input.pptx](row-height-input.pptx), che contiene una tabella come prima forma nella prima diapositiva. La sua prima riga inizia a 70 punti. Le celle usano testo Arial da 18 punti, a capo automatico, e margini superiori e inferiori di 6 punti; il testo più lungo nella seconda colonna si avvolge su più righe. L'esempio aumenta il minimo a 100 punti, poi lo riduce a 20 punti, stampa l'altezza effettiva dopo ogni modifica e salva entrambi i risultati.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("row-height-input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    IRow row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    System.out.printf("Increased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx);

    row.setMinimalHeight(20);
    System.out.printf("Decreased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Con la presentazione fornita, aumentare il minimo aggiunge spazio alla riga. Ridurlo rimuove quello spazio extra, ma l'altezza effettiva rimane superiore a 20 punti perché il testo e i margini delle celle richiedono più spazio. Ridurre solo il minimo non può forzare la riga al di sotto dello spazio richiesto dal suo contenuto.

Diversi fattori influenzano l'altezza effettiva:

- **Testo e dimensione del carattere:** testo più lungo, interruzioni di riga esplicite o un carattere più grande possono richiedere più spazio verticale.
- **A capo e larghezza della colonna:** con l'auto‑a‑capo attivato, ridurre la larghezza della colonna con [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) può produrre più righe. Una colonna più larga può ridurre lo spazio necessario verticalmente.
- **Margini delle celle:** [ICell.setMarginTop](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginTop-double-) e [ICell.setMarginBottom](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginBottom-double-) aggiungono spazio verticale. [ICell.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginLeft-double-) e [ICell.setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginRight-double-) riducono la larghezza disponibile per il testo e possono causare un ulteriore a capo.

Per questa tabella senza celle unite, la cella che richiede più spazio verticale determina il limite inferiore determinato dal contenuto per l'intera riga. Per rendere la riga più corta, potresti anche dover accorciare il testo, ridurre la dimensione del carattere o i margini, o allargare una colonna.

Le immagini di seguito mostrano la stessa tabella alla stessa scala. Nei risultati illustrati, le altezze effettive erano 70, 100 e 55,2 punti: la riga finale è rimasta più alta del suo minimo di 20 punti. Le misurazioni esatte del testo possono variare con i caratteri disponibili nel tuo ambiente. Scarica i risultati salvati: [increased minimum](row-height-increased.pptx) e [decreased minimum](row-height-decreased.pptx).

| Originale: minimo 70 pt, effettivo 70 pt | Aumentato: minimo 100 pt, effettivo 100 pt | Ridotto: minimo 20 pt, effettivo 55,2 pt |
| --- | --- | --- |
| ![Tabella originale con prima riga di 70 punti.](row-height-before.png) | ![Tabella dopo aver aumentato il minimo della prima riga a 100 punti.](row-height-increased.png) | ![Tabella dopo aver diminuito il minimo della prima riga a 20 punti; il testo a capo mantiene la riga più alta del minimo.](row-height-decreased.png) |

## **Imposta la prima riga come intestazione**

Usa il metodo [setFirstRow](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setFirstRow-boolean-) per contrassegnare la prima riga per la formattazione dell'intestazione. Il suo aspetto dipende dallo stile della tabella applicato.

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Accedi alla prima diapositiva.
3. Accedi alla tabella memorizzata come prima forma nella diapositiva.
4. Abilita la formattazione dell'intestazione per la sua prima riga.
5. Salva la presentazione modificata.

L'esempio richiede `table.pptx` con una tabella come prima forma nella prima diapositiva. Abilita la formattazione dell'intestazione per la prima riga e salva `First_row_header.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Clona una riga o colonna di tabella**

Clona righe o colonne per riutilizzare il loro contenuto e formattazione. Puoi aggiungere una copia alla fine della tabella o inserirla in una posizione specifica.

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Accedi alla prima diapositiva.
3. Definisci le larghezze delle colonne e le altezze delle righe.
4. Aggiungi una tabella con il metodo [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
5. Clona le righe richieste.
6. Clona le colonne richieste.
7. Salva la presentazione modificata.

L'esempio richiede `Test.pptx` con almeno una diapositiva. Crea una tabella con tre colonne e cinque righe, con dimensioni specificate in punti. Aggiunge copie della prima riga e colonna, poi inserisce copie della seconda riga e colonna all'indice 3 (quarta posizione). La tabella risultante ha sette righe e cinque colonne. L'argomento `false` disabilita il clonaggio in righe o colonne unite adiacenti; questa tabella non ha celle unite.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 50, 50, 50 };
    double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Rimuovi una riga o colonna da una tabella**

Rimuovi righe o colonne non più necessarie in una tabella. Rimuovere un elemento sposta gli indici delle righe o colonne successive.

1. Crea una presentazione con la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Accedi alla prima diapositiva.
3. Definisci le larghezze delle colonne e le altezze delle righe.
4. Aggiungi una tabella con il metodo [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
5. Rimuovi la seconda riga e la seconda colonna.
6. Salva la presentazione modificata.

Questo esempio crea una tabella tre‑per‑tre e rimuove la riga e la colonna all'indice 1, lasciando una tabella due‑per‑due in `TestTable_out.pptx`. Le dimensioni sono in punti. L'argomento `false` disabilita la rimozione di righe o colonne unite adiacenti; questa tabella non ha celle unite.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 50, 30 };
    double[] rowHeights = new double[] { 30, 50, 30 };
    ITable table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Imposta la formattazione del testo a livello di riga della tabella**

Applica la formattazione del testo a un'intera riga per mantenere le celle coerenti. Puoi impostare le proprietà del carattere, la formattazione del paragrafo e la direzione del testo senza formattare ogni cella singolarmente.

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Accedi alla tabella nella prima diapositiva.
3. Usa [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) per la prima riga.
4. Usa [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) e [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) per la prima riga.
5. Usa [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) per la seconda riga.
6. Salva la presentazione modificata.

L'esempio richiede `table.pptx` con una tabella come prima forma nella prima diapositiva e almeno due righe. Applica testo da 25 punti, allineamento a destra e un margine di paragrafo destro di 20 punti alla prima riga, poi imposta il testo verticale nella seconda riga.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Imposta la formattazione del testo a livello di colonna della tabella**

Applica la formattazione del testo a un'intera colonna per mantenere le celle coerenti. Puoi impostare le proprietà del carattere, la formattazione del paragrafo e la direzione del testo senza formattare ogni cella singolarmente.

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Accedi alla tabella nella prima diapositiva.
3. Usa [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) per la prima colonna.
4. Usa [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) e [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) per la prima colonna.
5. Usa [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) per la seconda colonna.
6. Salva la presentazione modificata.

L'esempio richiede `table.pptx` con una tabella come prima forma nella prima diapositiva e almeno due colonne. Applica testo da 25 punti, allineamento a destra e un margine di paragrafo destro di 20 punti alla prima colonna, poi imposta il testo verticale nella seconda colonna.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ottieni le proprietà dello stile della tabella**

Usa il metodo [getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--) per recuperare il preset applicato a una tabella e riutilizzarlo su un'altra. Questo identifica il preset anziché le sovrascritture di formattazione di singole celle.

L'esempio crea una tabella, applica [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/#DarkStyle1) e legge il preset. Stampa il valore intero corrispondente a `DarkStyle1` e salva la tabella in `table.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 150 };
    double[] rowHeights = new double[] { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println(stylePreset);

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Posso applicare temi/stili di PowerPoint a una tabella già creata?**

Sì. La tabella eredita il tema della diapositiva/layout/master e puoi comunque sovrascrivere riempimenti, bordi e colori del testo sopra quel tema.

**Posso ordinare le righe della tabella come in Excel?**

No, le tabelle Aspose.Slides non hanno ordinamento o filtri integrati. Ordina i dati in memoria prima, poi ripopolare le righe della tabella in quell'ordine.

**Posso avere colonne a bande (a righe) mantenendo colori personalizzati su celle specifiche?**

Sì. Attiva le colonne a bande, poi sovrascrivi celle specifiche con formattazione locale; la formattazione a livello di cella ha precedenza sullo stile della tabella.