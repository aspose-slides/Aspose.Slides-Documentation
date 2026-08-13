---
title: Ottieni le proprietà effettive della forma da presentazioni su Android
linktitle: Proprietà effettive
type: docs
weight: 50
url: /it/androidjava/shape-effective-properties/
keywords:
- proprietà della forma
- proprietà della camera
- rig di illuminazione
- forma con smussatura
- riquadro di testo
- stile di testo
- altezza carattere
- formato di riempimento
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri come Aspose.Slides per Android via Java calcola e applica le proprietà effettive della forma per una resa precisa di PowerPoint."
---
## **Panoramica**

Questo argomento spiega la differenza tra proprietà **locali** e **effettive**. I valori locali sono valori impostati direttamente a un livello di formattazione specifico, come ad esempio:

1. Proprietà della porzione su una diapositiva.
1. Stili di testo della forma prototipo in un layout o nella diapositiva master, quando la forma del riquadro di testo della porzione ne ha uno.
1. Impostazioni di testo globali in una presentazione.

I valori locali possono essere definiti o omessi a qualsiasi livello. Quando Aspose.Slides ha bisogno della formattazione finale "as rendered", risolve la catena di ereditarietà e restituisce i valori **effettivi**. È possibile ottenerli chiamando il metodo `getEffective()` sull'oggetto di formattazione locale.

L'esempio seguente mostra come ottenere i valori effettivi. Si assume che la prima forma sulla prima diapositiva sia un [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) con un riquadro di testo e almeno una porzione.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrame textFrame = shape.getTextFrame();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrame.getTextFrameFormat().getEffective();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormatEffectiveData effectivePortionFormat = portion.getPortionFormat().getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="info" %}}
I dati di formattazione effettiva rappresentano la formattazione calcolata corrente dopo l'applicazione dell'ereditarietà. Nell'implementazione attuale, alcuni oggetti di dati effettivi, come [IPortionFormatEffectiveData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iportionformateffectivedata/), possono essere memorizzati nella cache internamente. Richiamare nuovamente `getEffective()` dopo aver modificato la formattazione genitore o ereditata può aggiornare i dati nella cache, e un oggetto ottenuto in precedenza potrebbe non rappresentare più lo stato precedente. Se è necessario conservare i valori effettivi per un riutilizzo successivo, copiare le proprietà richieste, come altezza del carattere, colore di riempimento, stile del carattere o allineamento, nel proprio oggetto dati.
{{% /alert %}}

## **Ottenere le proprietà effettive di una Camera**

Aspose.Slides consente di ottenere le proprietà effettive di una camera. L'interfaccia [ICameraEffectiveData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/icameraeffectivedata/) rappresenta un oggetto immutabile che contiene le proprietà effettive della camera. Un'istanza di [ICameraEffectiveData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/icameraeffectivedata/) è esposta tramite [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformateffectivedata/), che fornisce valori effettivi per [IThreeDFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/).

Il seguente esempio di codice mostra come ottenere le proprietà effettive per la camera. Si assume che la prima forma sulla prima diapositiva abbia una formattazione 3D.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraEffectiveData.getCameraType());
    System.out.println("Field of view: " + cameraEffectiveData.getFieldOfViewAngle());
    System.out.println("Zoom: " + cameraEffectiveData.getZoom());
} finally {
    presentation.dispose();
}
```

## **Ottenere le proprietà effettive di un Light Rig**

Aspose.Slides consente di ottenere le proprietà effettive di un light rig. L'interfaccia [ILightRigEffectiveData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilightrigeffectivedata/) rappresenta un oggetto immutabile che contiene le proprietà effettive del light rig. Un'istanza di [ILightRigEffectiveData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilightrigeffectivedata/) è esposta tramite [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformateffectivedata/), che fornisce valori effettivi per [IThreeDFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/).

Il seguente esempio di codice mostra come ottenere le proprietà effettive per il light rig. Si assume che la prima forma sulla prima diapositiva abbia una formattazione 3D.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightRigEffectiveData.getLightType());
    System.out.println("Direction: " + lightRigEffectiveData.getDirection());
} finally {
    presentation.dispose();
}
```

## **Ottenere le proprietà effettive di una Bevel Shape**

Aspose.Slides consente di ottenere le proprietà effettive di un bevel di forma. L'interfaccia [IShapeBevelEffectiveData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishapebeveleffectivedata/) rappresenta un oggetto immutabile che contiene le proprietà effettive del rilievo facciale per una forma. Un'istanza di [IShapeBevelEffectiveData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishapebeveleffectivedata/) è esposta tramite [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformateffectivedata/), che fornisce valori effettivi per [IThreeDFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ithreedformat/).

Il seguente esempio di codice mostra come ottenere le proprietà effettive per il bevel superiore di una forma. Si assume che la prima forma sulla prima diapositiva abbia una formattazione 3D.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTopEffectiveData = threeDEffectiveData.getBevelTop();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelTopEffectiveData.getBevelType());
    System.out.println("Width: " + bevelTopEffectiveData.getWidth());
    System.out.println("Height: " + bevelTopEffectiveData.getHeight());
} finally {
    presentation.dispose();
}
```

## **Ottenere le proprietà effettive di un riquadro di testo**

Utilizzando Aspose.Slides, è possibile ottenere le proprietà effettive di un riquadro di testo. L'interfaccia [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframeformateffectivedata/) contiene le proprietà di formattazione effettiva del riquadro di testo.

Il seguente esempio di codice mostra come ottenere le proprietà di formattazione effettiva del riquadro di testo. Si assume che la prima forma sulla prima diapositiva sia un [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) con un riquadro di testo.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("Margins");
    System.out.println("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   Top: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   Right: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    presentation.dispose();
}
```

## **Ottenere le proprietà effettive di uno stile di testo**

Utilizzando Aspose.Slides, è possibile ottenere le proprietà effettive di uno stile di testo. L'interfaccia [ITextStyleEffectiveData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextstyleeffectivedata/) contiene le proprietà effettive dello stile di testo.

Il seguente esempio di codice mostra come ottenere le proprietà effettive dello stile di testo. Si assume che la prima forma sulla prima diapositiva sia un [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) con un riquadro di testo.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);

        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    presentation.dispose();
}
```

## **Ottenere il valore di altezza del carattere effettivo**

Utilizzando Aspose.Slides, è possibile ottenere l'altezza del carattere effettiva. Il seguente codice dimostra come l'altezza del carattere effettiva di una porzione cambi dopo che i valori locali di altezza del carattere sono impostati a diversi livelli della struttura della presentazione.

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

Utilizzando Aspose.Slides, è possibile ottenere la formattazione di riempimento efficace per diverse parti della tabella. L'interfaccia [IFillFormatEffectiveData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ifillformateffectivedata/) contiene le proprietà di formattazione di riempimento effettive. La formattazione delle celle ha priorità più alta rispetto alla formattazione delle righe, la formattazione delle righe ha priorità più alta rispetto a quella delle colonne e la formattazione delle colonne ha priorità più alta rispetto alla formattazione dell'intera tabella.

Di conseguenza, le proprietà di [ICellFormatEffectiveData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/icellformateffectivedata/) vengono utilizzate per disegnare la cella della tabella. Il seguente esempio di codice mostra come ottenere la formattazione di riempimento efficace per diverse parti della tabella. Si assume che la prima forma sulla prima diapositiva sia un [ITable](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itable/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);

    IRow row = table.getRows().get_Item(0);
    IColumn column = table.getColumns().get_Item(0);
    ICell cell = table.get_Item(0, 0);

    IFillFormatEffectiveData tableFillFormatEffective = table.getTableFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = row.getRowFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = column.getColumnFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cell.getCellFormat().getEffective().getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

### `getEffective()` restituisce un'istantanea?

Non sempre. I dati effettivi rappresentano la formattazione calcolata dopo l'applicazione dell'ereditarietà, ma alcuni oggetti di dati effettivi possono essere memorizzati nella cache internamente. Una chiamata successiva a `getEffective()` può ricalcolare la formattazione e aggiornare i dati nella cache, quindi un oggetto ottenuto in precedenza non dovrebbe essere considerato come una snapshot duratura.

### Quando devo leggere nuovamente le proprietà effettive?

Chiama nuovamente `getEffective()` dopo aver modificato la formattazione locale, gli stili genitore, la formattazione del layout, la formattazione master o le impostazioni predefinite a livello di presentazione. La chiamata successiva rivaluta la gerarchia di formattazione e restituisce il risultato effettivo corrente.

### Modificare o rimuovere una diapositiva layout/master influisce sulle proprietà effettive già recuperate?

Sì, ma la modifica viene riflessa nella successiva chiamata a `getEffective()`. Se una sorgente di formattazione genitore viene modificata o rimossa, i dati effettivi precedentemente ottenuti possono diventare obsoleti. Una volta chiamato nuovamente `getEffective()`, Aspose.Slides rivaluta l'albero di formattazione e i caratteri, i colori, le dimensioni o altri valori risultanti possono cambiare.

### Posso modificare i valori tramite gli oggetti di dati effettivi?

No. Gli oggetti di dati effettivi espongono i valori calcolati. Apporta le modifiche negli oggetti di formattazione locale, quindi ottieni nuovamente i valori effettivi.

### Cosa succede se una proprietà non è impostata a livello di forma, né nel layout/master, né nelle impostazioni globali?

Il valore effettivo è determinato dal meccanismo predefinito, che include i valori predefiniti di PowerPoint e di Aspose.Slides. Tale valore risolto diventa parte dei dati effettivi correnti.

### Dal valore di un carattere effettivo, posso capire a quale livello è stata fornita la dimensione o il tipo di carattere?

Non direttamente. I dati effettivi restituiscono il valore finale. Per trovare la fonte, controlla i valori locali nella porzione, nel paragrafo, nel riquadro di testo e negli stili di testo a livello di layout, master e presentazione per vedere dove appare la prima definizione esplicita.

### Perché i valori effettivi a volte sembrano identici a quelli locali?

Perché il valore locale è risultato finale (non è stato necessario alcun ereditamento a livelli superiori). In questi casi, il valore effettivo corrisponde a quello locale.

### Quando devo usare le proprietà effettive e quando devo lavorare solo con quelle locali?

Utilizza i dati effettivi quando hai bisogno del risultato "as rendered" dopo l'applicazione di tutta l'ereditarietà, ad esempio per allineare colori, rientri o dimensioni. Se devi conservare tali valori indipendentemente dalle modifiche di formattazione successive, copia le proprietà necessarie nel tuo oggetto. Se devi modificare la formattazione a un livello specifico, modifica le proprietà locali e, se necessario, leggi nuovamente i dati effettivi per verificare il risultato.