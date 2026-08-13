---
title: Recupera le proprietà effective della forma dalle presentazioni su Android
linktitle: Proprietà Effective
type: docs
weight: 50
url: /it/androidjava/shape-effective-properties/
keywords:
- proprietà della forma
- proprietà della fotocamera
- impianto di luce
- forma smussata
- frame di testo
- stile di testo
- altezza del carattere
- formato di riempimento
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri come utilizzare Aspose.Slides per Android tramite Java per distinguere la formattazione locale, ereditata ed effective delle forme nelle presentazioni PowerPoint."
---
## **Comprendere le proprietà locali, ereditate ed effettive**

La formattazione di PowerPoint può provenire da diversi luoghi. Il valore memorizzato direttamente su un oggetto è il suo **valore locale**. Se quel valore non è impostato, PowerPoint controlla le fonti di formattazione genitori, come il valore predefinito di un paragrafo, uno stile di testo, un layout o diapositiva master, un tema o i valori predefiniti a livello di presentazione. Questi valori sono **valori ereditati**. Il valore che rimane dopo che l'intera gerarchia è stata risolta è il **valore effettivo**—il valore usato per renderizzare l'oggetto.

Ad esempio, una porzione di testo potrebbe non definire la propria altezza del carattere. Il suo valore locale [getFontHeight](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--) è quindi `Float.NaN`, che significa "non impostato qui". La porzione può ereditare un'altezza dal suo paragrafo, dallo stile di testo predefinito della presentazione o da un'altra fonte applicabile. Chiamare [getEffective](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iportionformat/#getEffective--) sul formato della porzione restituisce l'altezza finale risolta.

Utilizza i due tipi di dati di formattazione per scopi diversi:

- Leggi o modifica un oggetto di formato locale, come [IPortionFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iportionformat/), quando è necessario controllare dove viene definito un valore.
- Leggi un oggetto di dati effective, come [IPortionFormatEffectiveData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iportionformateffectivedata/), quando è necessario il risultato finale renderizzato. I dati effective sono in sola lettura.

## **Confrontare i valori locali, ereditati ed effective**

L'esempio completo seguente crea una forma e applica altezze del carattere a livello di presentazione, paragrafo e porzione. Ogni passaggio stampa i valori definiti a quei livelli e il valore effective risultante per la stessa porzione di testo. Dimostra anche perché i dati effective devono essere letti nuovamente dopo modifiche alla formattazione.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
            ITextFrame textFrame = shape.addTextFrame("Effective formatting");
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            // Definisci i valori ereditati a due livelli diversi.
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // Un valore locale sulla porzione sovrascrive entrambi i valori ereditati.
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // Modificare un valore ereditato non sovrascrive un valore locale esistente.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // Cancella il valore locale. La porzione ora eredita di nuovo dal paragrafo.
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // Cancella il valore del paragrafo. Il valore predefinito della presentazione ora fornisce il risultato.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

            presentation.save("effective-properties.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static void printFontHeights(String caption, Presentation presentation, IParagraph paragraph, IPortion portion) {
        float presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
        float paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
        float localValue = portion.getPortionFormat().getFontHeight();

        // Leggi i dati effective dopo le modifiche precedenti.
        float effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

        System.out.println(caption);
        System.out.println("  Presentation default: " + formatLocalValue(presentationValue));
        System.out.println("  Paragraph default:    " + formatLocalValue(paragraphValue));
        System.out.println("  Portion local:        " + formatLocalValue(localValue));
        System.out.println("  Portion effective:    " + effectiveValue);
    }

    private static String formatLocalValue(float value) {
        return Float.isNaN(value) ? "<not set>" : Float.toString(value);
    }
}
```

La priorità in questo esempio è la formattazione locale della porzione, seguita da quella del paragrafo e poi dal valore predefinito della presentazione. Altri oggetti possono avere catene di ereditarietà diverse, ma il principio è lo stesso: un valore esplicito più specifico prevale, e [getEffective](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iportionformat/#getEffective--) restituisce il risultato finale.

## **Ottenere le proprietà di testo effective**

La formattazione del testo è suddivisa tra diversi oggetti:

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframeformat/#getEffective--) risolve le proprietà del frame di testo come margini, ancoraggio, adattamento automatico e direzione verticale del testo.
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextstyle/#getEffective--) risolve la formattazione del paragrafo per ciascun livello di stile di testo.
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iparagraphformat/#getEffective--) risolve le proprietà del paragrafo come allineamento, rientro e elenchi puntati.
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iportionformat/#getEffective--) risolve le proprietà dei caratteri come altezza del carattere, famiglia di font, colore, grassetto e corsivo.

Per il prossimo esempio, `text-formatting.pptx` deve contenere almeno una diapositiva e una [AutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/autoshape/) con un frame di testo non vuoto. L'AutoShape può trovarsi in qualsiasi posizione nella collezione di forme; il codice cerca un oggetto adatto e lo convalida prima dell'uso.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("text-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            IAutoShape shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
            if (shape == null) {
                throw new IllegalStateException("The first slide must contain an AutoShape with non-empty text.");
            }

            ITextFrame textFrame = shape.getTextFrame();
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            ITextFrameFormatEffectiveData textFrameEffective = textFrame.getTextFrameFormat().getEffective();
            IParagraphFormatEffectiveData paragraphEffective = paragraph.getParagraphFormat().getEffective();
            IPortionFormatEffectiveData portionEffective = portion.getPortionFormat().getEffective();

            System.out.println("Text frame margins:");
            System.out.println("  Left: " + textFrameEffective.getMarginLeft());
            System.out.println("  Top: " + textFrameEffective.getMarginTop());
            System.out.println("  Right: " + textFrameEffective.getMarginRight());
            System.out.println("  Bottom: " + textFrameEffective.getMarginBottom());
            System.out.println("Paragraph alignment: " + paragraphEffective.getAlignment());
            System.out.println("Font height: " + portionEffective.getFontHeight());
            System.out.println("Bold: " + portionEffective.getFontBold());

            ITextStyleEffectiveData effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
            for (int level = 0; level < 9; level++) {
                IParagraphFormatEffectiveData levelEffective = effectiveTextStyle.getLevel(level);
                System.out.println("Level " + level + " indent: " + levelEffective.getIndent());
            }
        } finally {
            presentation.dispose();
        }
    }

    private static IAutoShape findAutoShapeWithText(ISlide slide) {
        for (IShape candidate : slide.getShapes()) {
            if (candidate instanceof IAutoShape && hasNonEmptyText((IAutoShape)candidate)) {
                return (IAutoShape)candidate;
            }
        }
        return null;
    }

    private static boolean hasNonEmptyText(IAutoShape shape) {
        if (shape.getTextFrame() == null) {
            return false;
        }
        if (shape.getTextFrame().getParagraphs().getCount() == 0) {
            return false;
        }
        return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
    }
}
```

## **Ottenere le proprietà 3D effective**

[IThreeDFormat.getEffective()](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/#getEffective--) restituisce un oggetto [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformateffectivedata/) che raggruppa tutte le impostazioni 3D risolte. I suoi metodi [getCamera](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformateffectivedata/#getCamera--), [getLightRig](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformateffectivedata/#getLightRig--), [getBevelTop](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--), e [getBevelBottom](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) espongono i corrispondenti dati effective. Leggere queste impostazioni correlate insieme facilita la comprensione dell'aspetto 3D finale di una forma.

Per questo esempio, `shape-3d.pptx` deve contenere almeno una forma nella sua prima diapositiva. Applica impostazioni di telecamera 3D, illuminazione o smussatura a quella forma se desideri che l'output contenga valori diversi da quelli predefiniti.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("shape-3d.pptx");
        try {
            if (presentation.getSlides().size() == 0 || presentation.getSlides().get_Item(0).getShapes().size() == 0) {
                throw new IllegalStateException("The first slide must contain a shape.");
            }

            IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
            IThreeDFormatEffectiveData threeDEffective = shape.getThreeDFormat().getEffective();

            System.out.println("Camera:");
            System.out.println("  Type: " + threeDEffective.getCamera().getCameraType());
            System.out.println("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
            System.out.println("  Zoom: " + threeDEffective.getCamera().getZoom());

            System.out.println("Light rig:");
            System.out.println("  Type: " + threeDEffective.getLightRig().getLightType());
            System.out.println("  Direction: " + threeDEffective.getLightRig().getDirection());

            System.out.println("Top bevel:");
            System.out.println("  Type: " + threeDEffective.getBevelTop().getBevelType());
            System.out.println("  Width: " + threeDEffective.getBevelTop().getWidth());
            System.out.println("  Height: " + threeDEffective.getBevelTop().getHeight());
        } finally {
            presentation.dispose();
        }
    }
}
```

## **Ottenere la formattazione della tabella effective**

La formattazione della tabella può derivare dallo stile della tabella e dai formati applicati all'intera tabella, a una colonna, a una riga o a una singola cella. In caso di conflitti tra riempimenti definiti esplicitamente, la priorità è: cella, riga, colonna e infine l'intera tabella. Il formato effective di una cella è il formato finale usato per disegnarla.

Per questo esempio, `table-formatting.pptx` deve contenere almeno una tabella nella sua prima diapositiva. La tabella deve avere almeno una riga e una colonna. Il codice cerca un [ITable](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itable/) invece di presumere che `getShapes().get_Item(0)` sia una tabella.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("table-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            ITable table = findTable(presentation.getSlides().get_Item(0));
            if (table == null) {
                throw new IllegalStateException("The first slide must contain a table.");
            }
            if (table.getRows().size() == 0 || table.getColumns().size() == 0) {
                throw new IllegalStateException("The table must contain at least one cell.");
            }

            ITableFormatEffectiveData tableEffective = table.getTableFormat().getEffective();
            IRowFormatEffectiveData rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
            IColumnFormatEffectiveData columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
            ICellFormatEffectiveData cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

            System.out.println("Table fill: " + tableEffective.getFillFormat().getFillType());
            System.out.println("Row fill: " + rowEffective.getFillFormat().getFillType());
            System.out.println("Column fill: " + columnEffective.getFillFormat().getFillType());
            System.out.println("Final cell fill: " + cellEffective.getFillFormat().getFillType());
        } finally {
            presentation.dispose();
        }
    }

    private static ITable findTable(ISlide slide) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                return (ITable)shape;
            }
        }
        return null;
    }
}
```

Se hai bisogno del colore invece solo del tipo di riempimento, controlla prima il valore effective di [getFillType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ifillformateffectivedata/#getFillType--), quindi leggi il metodo corrispondente a quel tipo—ad esempio, [getSolidFillColor](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--) per un riempimento solido.

## **Rileggere i dati effective dopo le modifiche**

I dati effective descrivono la gerarchia di formattazione al momento della loro risoluzione. Chiama nuovamente `getEffective` dopo aver modificato qualsiasi elemento che può partecipare a quella gerarchia, includendo:

- la formattazione locale dell'oggetto;
- i valori predefiniti del paragrafo o del frame di testo;
- uno stile di tabella, la tabella, una colonna, una riga o il formato della cella;
- la formattazione del layout o della diapositiva master;
- i dati del tema o i valori predefiniti a livello di presentazione;
- il layout o il master assegnato a una diapositiva.

Non mantenere un oggetto di dati effective come istantanea permanente. Aspose.Slides può memorizzare nella cache alcuni dati effective internamente, e una chiamata successiva a `getEffective` può aggiornare quei dati. Se hai bisogno di confrontare valori prima e dopo una modifica, copia i valori scalari di cui hai bisogno—come altezza del carattere, colore, allineamento o larghezza della smussatura—nelle tue variabili prima di apportare la modifica.

Per modificare un valore, aggiorna l'oggetto di formato locale appropriato e poi chiama `getEffective` per verificare il risultato. Gli oggetti di dati effective sono in sola lettura.

## **FAQ**

**Come posso capire quale livello ha fornito un valore effective?**

I dati effective contengono il valore finale, non la sua origine. Esamina gli oggetti locali applicabili a partire dal livello più specifico verso l'esterno. Per il testo, ciò può includere la porzione, il paragrafo, il frame di testo, il layout, il master, il tema e i valori predefiniti della presentazione. Valori non definiti come `Float.NaN` o `null` indicano che la ricerca continua a un altro livello.

**Cosa succede quando nessun livello definisce una proprietà?**

Aspose.Slides risolve il valore predefinito appropriato di PowerPoint o della libreria. Quel valore risolto appare nei dati effective anche se nessun oggetto locale lo definisce esplicitamente.

**Perché a volte un valore effective è uguale al valore locale?**

Il valore locale ha vinto il calcolo dell'ereditarietà. Questo è previsto quando la proprietà è impostata esplicitamente sull'oggetto e nessuna regola più specifica la sovrascrive.

**Quando dovrei usare i dati locali invece dei dati effective?**

Usa i dati locali per ispezionare o modificare un livello specifico di formattazione. Usa i dati effective quando ti serve l'aspetto finale dopo che ereditarietà, regole del tema e stili applicabili sono stati risolti. Il [complete comparison example](#compare-local-inherited-and-effective-values) dimostra entrambi nello stesso flusso di lavoro.