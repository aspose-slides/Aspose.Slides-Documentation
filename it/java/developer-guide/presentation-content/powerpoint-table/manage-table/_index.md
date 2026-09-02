---
title: Gestire le tabelle di presentazione in Java
linktitle: Gestisci tabella
type: docs
weight: 10
url: /it/java/manage-table/
keywords:
- aggiungi tabella
- crea tabella
- accedi tabella
- rapporto d'aspetto
- allinea testo
- formattazione testo
- stile tabella
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Crea e modifica tabelle nelle diapositive PowerPoint con Aspose.Slides per Java. Scopri semplici esempi di codice per ottimizzare i tuoi flussi di lavoro con le tabelle."
---
## **Introduzione**

Una tabella in PowerPoint è un modo efficiente per visualizzare e rappresentare le informazioni. Le informazioni in una griglia di celle (disposte in righe e colonne) sono semplici e facili da comprendere.

Aspose.Slides fornisce la classe [Table](https://reference.aspose.com/slides/it/java/com.aspose.slides/Table), l'interfaccia [ITable](https://reference.aspose.com/slides/it/java/com.aspose.slides/ITable), la classe [Cell](https://reference.aspose.com/slides/it/java/com.aspose.slides/cell/), l'interfaccia [ICell](https://reference.aspose.com/slides/it/java/com.aspose.slides/icell/) e altri tipi per consentirti di creare, aggiornare e gestire le tabelle in tutti i tipi di presentazioni. 

## **Crea una tabella da zero**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
2. Ottieni il riferimento di una diapositiva tramite il suo indice. 
3. Definisci un array di `columnWidth`.
4. Definisci un array di `rowHeight`.
5. Aggiungi un oggetto [ITable](https://reference.aspose.com/slides/it/java/com.aspose.slides/ITable) alla diapositiva tramite il metodo [addTable](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Itera attraverso ciascun [ICell](https://reference.aspose.com/slides/it/java/com.aspose.slides/icell/) per applicare la formattazione ai bordi superiore, inferiore, destro e sinistro.
7. Unisci le prime due celle della prima riga della tabella. 
8. Accedi al [TextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/textframe/) di un [ICell](https://reference.aspose.com/slides/it/java/com.aspose.slides/icell/). 
9. Aggiungi del testo al [TextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/textframe/).
10. Salva la presentazione modificata.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Istanzia una classe Presentation che rappresenta un file PPTX
Presentation pres = new Presentation();
try {
    // Accede alla prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Definisce colonne con larghezze e righe con altezze
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // Aggiunge una forma tabella alla diapositiva
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Imposta il formato del bordo per ogni cella
    for (int row = 0; row < tbl.getRows().size(); row++)
    {
        for (int cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++)
        {
            ICellFormat cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            
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
    // Unisce le celle 1 e 2 della riga 1
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(0).get_Item(1), false);

    // Aggiunge del testo alla cella unita
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // Salva la presentazione su disco
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Numerazione in una tabella standard**

In una tabella standard, la numerazione delle celle è semplice e a base zero. La prima cella di una tabella è indicizzata come 0,0 (colonna 0, riga 0). 

Ad esempio, le celle di una tabella con 4 colonne e 4 righe sono numerate in questo modo:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Questo codice Java mostra come specificare la numerazione delle celle in una tabella:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Istanzia una classe Presentation che rappresenta un file PPTX
Presentation pres = new Presentation();
try {
    // Accede alla prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Definisce colonne con larghezze e righe con altezze
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Aggiunge una forma tabella alla diapositiva
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Imposta il formato del bordo per ogni cella
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Salva la presentazione su disco
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Accedi a una tabella esistente**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).

2. Ottieni un riferimento alla diapositiva che contiene la tabella tramite il suo indice. 

3. Crea un oggetto [ITable](https://reference.aspose.com/slides/it/java/com.aspose.slides/ITable) e impostalo a null.

4. Itera attraverso tutti gli oggetti [IShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/) fino a trovare la tabella.

   Se sospetti che la diapositiva in questione contenga una sola tabella, puoi semplicemente controllare tutte le forme che contiene. Quando una forma è identificata come una tabella, puoi eseguirne il cast a oggetto [Table](https://reference.aspose.com/slides/it/java/com.aspose.slides/Table). Tuttavia, se la diapositiva contiene diverse tabelle, è consigliabile cercare la tabella necessaria tramite il suo metodo [setAlternativeText(String value)](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-).

5. Utilizza l'oggetto [ITable](https://reference.aspose.com/slides/it/java/com.aspose.slides/ITable) per lavorare con la tabella. Nell'esempio seguente, abbiamo aggiunto una nuova riga alla tabella.

6. Salva la presentazione modificata.

```java
import com.aspose.slides.*;

// Instanzia la classe Presentation che rappresenta un file PPTX
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // Accede alla prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Inizializza la tabella a null
    ITable tbl = null;

    // Itera tra le forme e imposta un riferimento alla tabella trovata
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // Imposta il testo per la prima colonna della seconda riga
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // Salva la presentazione modificata su disco
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Trova la cella che possiede un TextFrame**

Quando del codice generico di elaborazione del testo riceve un [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/) da una tabella, utilizza il metodo [ITextFrame.getParentCell](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/#getParentCell--) per recuperare la [ICell](https://reference.aspose.com/slides/it/java/com.aspose.slides/icell/) proprietaria. Per un TextFrame di una cella di tabella, [ITextFrame.getParentCell](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/#getParentCell--) restituisce il proprietario e [ITextFrame.getParentShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/#getParentShape--) restituisce `null`, anche se la tabella stessa è una forma.

Le coordinate della cella sono disponibili tramite i metodi di sola lettura [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/it/java/com.aspose.slides/icell/#getFirstColumnIndex--) e [ICell.getFirstRowIndex](https://reference.aspose.com/slides/it/java/com.aspose.slides/icell/#getFirstRowIndex--) . Anche [ITextFrame.getParentCell](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/#getParentCell--) fornisce una navigazione di sola lettura: restituisce il proprietario ma non ne cambia la proprietà. Verifica sempre che la cella restituita non sia `null` prima di usarla.

Per un esempio completo che identifica i proprietari di celle e forme, incluse le forme associate ai nodi SmartArt, vedi [Cerca e sostituisci testo](/slides/it/java/search-and-replace-text/).

## **Allinea il testo in una tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
2. Ottieni il riferimento di una diapositiva tramite il suo indice. 
3. Aggiungi un oggetto [ITable](https://reference.aspose.com/slides/it/java/com.aspose.slides/ITable) alla diapositiva. 
4. Accedi a un oggetto [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/) dalla tabella. 
5. Accedi all'[IParagraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraph/) del [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/).
6. Allinea il testo verticalmente.
7. Salva la presentazione modificata.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Crea un'istanza della classe Presentation
Presentation pres = new Presentation();
try {
    // Ottiene la prima diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Definisce colonne con larghezze e righe con altezze
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // Aggiunge la forma tabella alla diapositiva
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // Accede al TextFrame
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // Crea l'oggetto Paragraph per il TextFrame
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // Crea l'oggetto Portion per il paragrafo
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Allinea il testo verticalmente
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // Salva la presentazione su disco
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Imposta la formattazione del testo a livello di tabella**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
2. Ottieni il riferimento di una diapositiva tramite il suo indice. 
3. Accedi a un oggetto [ITable](https://reference.aspose.com/slides/it/java/com.aspose.slides/ITable) dalla diapositiva.
4. Imposta il metodo [setFontHeight(float value)](https://reference.aspose.com/slides/it/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) per il testo. 
5. Imposta i metodi [setAlignment(int value)](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) e [setMarginRight(float value)](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-). 
6. Imposta il metodo [setTextVerticalType(byte value)](https://reference.aspose.com/slides/it/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Salva la presentazione modificata. 

```java
import com.aspose.slides.*;

// Crea un'istanza della classe Presentation
Presentation pres = new Presentation("simpletable.pptx");
try {
    // Supponiamo che la prima forma nella prima diapositiva sia una tabella
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // Imposta l'altezza del font delle celle della tabella
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // Imposta l'allineamento del testo e il margine destro delle celle della tabella in un'unica chiamata
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // Imposta il tipo di orientamento verticale del testo delle celle della tabella
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ottieni le proprietà di stile della tabella**

Aspose.Slides consente di recuperare le proprietà di stile di una tabella in modo da poter utilizzare tali dettagli per un'altra tabella o altrove. Questo codice Java mostra come ottenere le proprietà di stile da uno stile predefinito di tabella:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // modifica il tema predefinito dello stile preimpostato

    // Ottiene lo stile preimpostato della tabella
    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    // Applica lo stile preimpostato recuperato a un'altra tabella
    ITable anotherTable = pres.getSlides().get_Item(0).getShapes().addTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.setStylePreset(stylePreset);

    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Blocca il rapporto d'aspetto di una tabella**

Il rapporto d'aspetto di una forma geometrica è il rapporto tra le sue dimensioni in diverse dimensioni. Aspose.Slides fornisce la proprietà [**setAspectRatioLocked**](https://reference.aspose.com/slides/it/java/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) per consentire di bloccare l'impostazione del rapporto d'aspetto per tabelle e altre forme. 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // inverti

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso abilitare la direzione di lettura da destra a sinistra (RTL) per un'intera tabella e il testo nelle sue celle?**

Sì. La tabella espone il metodo [setRightToLeft](https://reference.aspose.com/slides/it/java/com.aspose.slides/table/#setRightToLeft-boolean-), e i paragrafi hanno [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/it/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). L'uso di entrambi garantisce l'ordine RTL corretto e il rendering all'interno delle celle.

**Come posso impedire agli utenti di spostare o ridimensionare una tabella nel file finale?**

Utilizza i [blocchi di forma](/slides/it/java/applying-protection-to-presentation/) per disabilitare spostamento, ridimensionamento, selezione, ecc. Queste protezioni si applicano anche alle tabelle.

**L'inserimento di un'immagine all'interno di una cella come sfondo è supportato?**

Sì. È possibile impostare un [picture fill](https://reference.aspose.com/slides/it/java/com.aspose.slides/picturefillformat/) per una cella; l'immagine coprirà l'area della cella secondo la modalità scelta (distensione o mosaico).