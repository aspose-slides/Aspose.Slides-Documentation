---
title: Ottieni le proprietà effettive della forma da presentazioni in Java
linktitle: Proprietà effettive
type: docs
weight: 50
url: /it/java/shape-effective-properties/
keywords:
- proprietà della forma
- proprietà della fotocamera
- impianto di illuminazione
- forma smussata
- riquadro di testo
- stile di testo
- altezza del carattere
- formato di riempimento
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri come Aspose.Slides per Java calcola e applica le proprietà effettive della forma per una resa precisa di PowerPoint."
---
## **Panoramica**

Questo argomento spiega la differenza tra le proprietà **locali** e **effettive**. I valori locali sono valori impostati direttamente a un livello di formattazione specifico, ad esempio:

1. Proprietà della porzione su una diapositiva.
1. Stili di testo della forma prototipo su un layout o su una diapositiva master, quando la forma del riquadro di testo della porzione ne ha uno.
1. Impostazioni di testo globali in una presentazione.

I valori locali possono essere definiti o omessi a qualsiasi livello. Quando Aspose.Slides ha bisogno della formattazione finale “come renderizzata”, risolve la catena di ereditarietà e restituisce i valori **effettivi**. È possibile ottenerli chiamando il metodo `getEffective` sull'oggetto di formato locale.

Il seguente esempio mostra come ottenere i valori effettivi. Si presume che la prima forma nella prima diapositiva sia un [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/IAutoShape) con un riquadro di testo e almeno una porzione.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = paragraph.getPortions().get_Item(0);
    IPortionFormat localPortionFormat = portion.getPortionFormat();
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="info" %}}
I dati di formattazione effettiva rappresentano la formattazione calcolata corrente dopo l'applicazione dell'ereditarietà. Nell'implementazione attuale, alcuni oggetti di dati effettivi, come [IPortionFormatEffectiveData](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPortionFormatEffectiveData), possono essere memorizzati nella cache internamente. Richiamare nuovamente `getEffective` dopo aver modificato la formattazione del genitore o quella ereditata può aggiornare i dati memorizzati, e un oggetto precedentemente ottenuto potrebbe non rappresentare più lo stato precedente. Se è necessario conservare i valori effettivi per un utilizzo futuro, copiare le proprietà richieste, come altezza del carattere, colore di riempimento, stile del carattere o allineamento, nel proprio oggetto dati.
{{% /alert %}}

## **Ottenere le proprietà effettive di una fotocamera**

Aspose.Slides consente di ottenere le proprietà effettive di una fotocamera. L'interfaccia [ICameraEffectiveData](https://reference.aspose.com/slides/it/java/com.aspose.slides/ICameraEffectiveData) rappresenta un oggetto immutabile che contiene le proprietà della fotocamera effettive. Un'istanza di [ICameraEffectiveData](https://reference.aspose.com/slides/it/java/com.aspose.slides/ICameraEffectiveData) è esposta tramite [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/it/java/com.aspose.slides/IThreeDFormatEffectiveData), che fornisce valori effettivi per [IThreeDFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/IThreeDFormat).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();
    int cameraType = cameraEffectiveData.getCameraType();
    double fieldOfViewAngle = cameraEffectiveData.getFieldOfViewAngle();
    double zoom = cameraEffectiveData.getZoom();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraType);
    System.out.println("Field of view: " + fieldOfViewAngle);
    System.out.println("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **Ottenere le proprietà effettive di un impianto di illuminazione**

Aspose.Slides consente di ottenere le proprietà effettive di un impianto di illuminazione. L'interfaccia [ILightRigEffectiveData](https://reference.aspose.com/slides/it/java/com.aspose.slides/ILightRigEffectiveData) rappresenta un oggetto immutabile che contiene le proprietà dell'impianto di illuminazione effettive. Un'istanza di [ILightRigEffectiveData](https://reference.aspose.com/slides/it/java/com.aspose.slides/ILightRigEffectiveData) è esposta tramite [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/it/java/com.aspose.slides/IThreeDFormatEffectiveData), che fornisce valori effettivi per [IThreeDFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/IThreeDFormat).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();
    int lightType = lightRigEffectiveData.getLightType();
    int direction = lightRigEffectiveData.getDirection();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightType);
    System.out.println("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **Ottenere le proprietà effettive di una forma smussata**

Aspose.Slides consente di ottenere le proprietà effettive di una smussatura di forma. L'interfaccia [IShapeBevelEffectiveData](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeBevelEffectiveData) rappresenta un oggetto immutabile che contiene le proprietà effettive di rilievo per una forma. Un'istanza di [IShapeBevelEffectiveData](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeBevelEffectiveData) è esposta tramite [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/it/java/com.aspose.slides/IThreeDFormatEffectiveData), che fornisce valori effettivi per [IThreeDFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/IThreeDFormat).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTop = threeDEffectiveData.getBevelTop();
    int bevelType = bevelTop.getBevelType();
    double bevelWidth = bevelTop.getWidth();
    double bevelHeight = bevelTop.getHeight();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelType);
    System.out.println("Width: " + bevelWidth);
    System.out.println("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **Ottenere le proprietà effettive di un riquadro di testo**

Utilizzando Aspose.Slides, è possibile ottenere le proprietà effettive di un riquadro di testo. L'interfaccia [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/it/java/com.aspose.slides/ITextFrameFormatEffectiveData) contiene le proprietà di formattazione effettiva del riquadro di testo.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.getEffective();
    int anchoringType = effectiveTextFrameFormat.getAnchoringType();
    int autofitType = effectiveTextFrameFormat.getAutofitType();
    int textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    double marginLeft = effectiveTextFrameFormat.getMarginLeft();
    double marginTop = effectiveTextFrameFormat.getMarginTop();
    double marginRight = effectiveTextFrameFormat.getMarginRight();
    double marginBottom = effectiveTextFrameFormat.getMarginBottom();

    System.out.println("Anchoring type: " + anchoringType);
    System.out.println("Autofit type: " + autofitType);
    System.out.println("Text vertical type: " + textVerticalType);
    System.out.println("Margins");
    System.out.println("   Left: " + marginLeft);
    System.out.println("   Top: " + marginTop);
    System.out.println("   Right: " + marginRight);
    System.out.println("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **Ottenere le proprietà effettive di uno stile di testo**

Utilizzando Aspose.Slides, è possibile ottenere le proprietà effettive di uno stile di testo. L'interfaccia [ITextStyleEffectiveData](https://reference.aspose.com/slides/it/java/com.aspose.slides/ITextStyleEffectiveData) contiene le proprietà effettive dello stile di testo.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);
    
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        int depth = effectiveStyleLevel.getDepth();
        double indent = effectiveStyleLevel.getIndent();
        int alignment = effectiveStyleLevel.getAlignment();
        int fontAlignment = effectiveStyleLevel.getFontAlignment();
        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + depth);
        System.out.println("Indent: " + indent);
        System.out.println("Alignment: " + alignment);
        System.out.println("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **Ottenere il valore effettivo dell'altezza del carattere**

Utilizzando Aspose.Slides, è possibile ottenere l'altezza del carattere effettiva. Il codice seguente dimostra come l'altezza del carattere effettiva di una porzione cambi dopo che i valori locali dell'altezza del carattere sono stati impostati a diversi livelli della struttura della presentazione.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    IPortion firstPortion = new Portion("Sample text with first portion");
    IPortion secondPortion = new Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    IPortionFormatEffectiveData firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    IPortionFormatEffectiveData secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height just after creation:");
    double firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    double secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting the presentation default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting paragraph default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting portion #0 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height after setting portion #1 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ottenere il formato di riempimento effettivo per una tabella**

Utilizzando Aspose.Slides, è possibile ottenere la formattazione di riempimento effettiva per diverse parti di una tabella. L'interfaccia [IFillFormatEffectiveData](https://reference.aspose.com/slides/it/java/com.aspose.slides/IFillFormatEffectiveData) contiene le proprietà di formattazione di riempimento effettive. La formattazione delle celle ha priorità più alta rispetto a quella delle righe, la formattazione delle righe ha priorità più alta rispetto a quella delle colonne e la formattazione delle colonne ha priorità più alta rispetto a quella dell'intera tabella.

Di conseguenza, le proprietà di [ICellFormatEffectiveData](https://reference.aspose.com/slides/it/java/com.aspose.slides/ICellFormatEffectiveData) vengono utilizzate per disegnare la cella della tabella. Il seguente esempio di codice mostra come ottenere la formattazione di riempimento effettiva per diverse parti della tabella. Si presume che la prima forma nella prima diapositiva sia una [ITable](https://reference.aspose.com/slides/it/java/com.aspose.slides/ITable).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);
    
    ITableFormatEffectiveData tableFormatEffective = table.getTableFormat().getEffective();
    IRowFormatEffectiveData rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    IColumnFormatEffectiveData columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    ICellFormatEffectiveData cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

### `getEffective` restituisce un'istantanea?

Non sempre. I dati effettivi rappresentano la formattazione calcolata dopo l'applicazione dell'ereditarietà, ma alcuni oggetti di dati effettivi possono essere memorizzati nella cache internamente. Una chiamata successiva a `getEffective` può ricalcolare la formattazione e aggiornare i dati memorizzati, quindi un oggetto ottenuto in precedenza non dovrebbe essere considerato un'istantanea permanente.

### Quando dovrei leggere nuovamente le proprietà effettive?

Chiamare nuovamente `getEffective` dopo aver modificato la formattazione locale, gli stili genitore, la formattazione del layout, la formattazione master o le impostazioni predefinite a livello di presentazione. La chiamata successiva rivaluta la gerarchia di formattazione e restituisce il risultato effettivo corrente.

### La modifica o la rimozione di una diapositiva layout/master influisce sulle proprietà effettive già recuperate?

Sì, ma la modifica viene riflessa nella successiva chiamata a `getEffective`. Se una fonte di formattazione genitore viene modificata o rimossa, i dati effettivi ottenuti in precedenza potrebbero diventare obsoleti. Una volta che `getEffective` viene chiamato nuovamente, Aspose.Slides rivaluta l'albero di formattazione e i caratteri, i colori, le dimensioni o altri valori risultanti possono cambiare.

### Posso modificare i valori tramite oggetti di dati effettivi?

No. Gli oggetti di dati effettivi espongono valori calcolati. Apporta le modifiche negli oggetti di formattazione locale, quindi ottieni nuovamente i valori effettivi.

### Cosa accade se una proprietà non è impostata a livello di forma, né nel layout/master, né nelle impostazioni globali?

Il valore effettivo è determinato dal meccanismo predefinito, che include i valori predefiniti di PowerPoint e Aspose.Slides. Tale valore risolto diventa parte dei dati effettivi correnti.

### Da un valore di carattere effettivo, posso capire a quale livello è stato fornito la dimensione o il tipo di carattere?

Non direttamente. I dati effettivi restituiscono il valore finale. Per individuare la fonte, controlla i valori locali nella porzione, nel paragrafo, nel riquadro di testo e negli stili di testo a livello di layout, master e presentazione per vedere dove appare la prima definizione esplicita.

### Perché i valori effettivi a volte sembrano identici a quelli locali?

Perché il valore locale è risultato finale (non è stata necessaria alcuna ereditarietà di livello superiore). In questi casi, il valore effettivo coincide con quello locale.

### Quando dovrei usare le proprietà effettive e quando dovrei lavorare solo con quelle locali?

Utilizza i dati effettivi quando ti serve il risultato “come renderizzato” dopo l'applicazione di tutta l'ereditarietà, ad esempio per allineare colori, rientri o dimensioni. Se devi conservare tali valori indipendentemente dalle modifiche di formattazione successive, copia le proprietà necessarie nel tuo oggetto. Se devi modificare la formattazione a un livello specifico, modifica le proprietà locali e poi, se necessario, leggi nuovamente i dati effettivi per verificare il risultato.