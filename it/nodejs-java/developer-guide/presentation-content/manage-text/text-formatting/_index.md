---
title: Formattare il Testo della Presentazione in JavaScript
linktitle: Formattazione del Testo
type: docs
weight: 50
url: /it/nodejs-java/text-formatting/
keywords:
- allineare paragrafo
- stile del testo
- sfondo del testo
- trasparenza del testo
- spaziatura dei caratteri
- proprietà del carattere
- famiglia del carattere
- rotazione del testo
- angolo di rotazione
- riquadro di testo
- interlinea
- proprietà di adattamento automatico
- ancora del riquadro di testo
- tabulazione del testo
- lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Formattare e stilizzare il testo in presentazioni PowerPoint e OpenDocument usando Aspose.Slides per Node.js via Java. Personalizza caratteri, colori, allineamento e altro."
---
## **Panoramica**

Questo articolo mostra come formattare il testo in presentazioni PowerPoint e OpenDocument usando Aspose.Slides per Node.js via Java. Copre colori di sfondo, trasparenza, spaziatura dei caratteri, proprietà dei caratteri, rotazione, spaziatura dei paragrafi, comportamento di adattamento automatico, ancoraggio del testo, tabulazioni e impostazioni della lingua.

Salvo diversa indicazione, gli esempi usano [sample.pptx](sample.pptx). La prima forma nella sua prima diapositiva è una casella di testo, e il suo primo paragrafo contiene il testo mostrato di seguito. Sia gli indici della diapositiva che della forma sono a base zero. Gli esempi che selezionano parti in grassetto usano la formattazione efficace, inclusa la formattazione in grassetto ereditata:

![Testo di esempio](sample_text.png)

Per trovare e evidenziare testo letterale o corrispondenze con espressioni regolari, vedere [Cerca e Sostituisci Testo](/slides/it/nodejs-java/search-and-replace-text/).

## **Imposta colore di sfondo del testo**

Usa [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) per impostare il colore di evidenziazione predefinito per un paragrafo, o usa [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor) per porzioni di testo individuali.

L'esempio seguente imposta un'evidenziazione grigio chiaro come predefinita per il primo paragrafo. I colori di evidenziazione espliciti su porzioni individuali hanno la precedenza su questa impostazione predefinita:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Imposta il colore di evidenziazione per l'intero paragrafo.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Paragrafo grigio](gray_paragraph.png)

L'esempio di codice seguente dimostra come impostare il colore di sfondo per **porzioni di testo con un carattere in grassetto**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Imposta il colore di evidenziazione per la porzione di testo.
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Le porzioni di testo grigie](gray_text_portions.png)

## **Allinea paragrafi di testo**

Usa [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment) per impostare l'allineamento del paragrafo all'interno di un riquadro di testo. Il valore può essere centrato, allineato a sinistra, allineato a destra, giustificato, ecc.

L'esempio di codice seguente mostra come allineare il paragrafo al **centro**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Imposta l'allineamento del paragrafo al centro.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Paragrafo allineato](aligned_paragraph.png)

## **Allinea i caratteri all'interno di una riga**

Usa [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setFontAlignment) per allineare verticalmente le porzioni di testo di diverse dimensioni di carattere all'interno di una riga. Questa impostazione si applica all'intero paragrafo e controlla l'allineamento all'interno di ciascuna delle sue linee.

L'esempio autonomo seguente crea quattro caselle di testo etichettate su una diapositiva. Ogni paragrafo contiene lo stesso testo a 18, 36 e 54 punti, con un diverso allineamento del carattere. Usa Arial, disabilita l'adattamento automatico e l'andare a capo, e mantiene i riquadri di testo sufficientemente grandi per una singola riga.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const alignments = [aspose.slides.FontAlignment.Baseline, aspose.slides.FontAlignment.Top, aspose.slides.FontAlignment.Center, aspose.slides.FontAlignment.Bottom];
    const alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    const fontSizes = [18, 36, 54];

    for (let i = 0; i < alignments.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));

        const label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        for (const fontSize of fontSizes) {
            const portion = new aspose.slides.Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Confronto tra allineamento Baseline, Top, Center e Bottom con dimensioni di carattere miste](font_alignment.png)

L'allineamento dei caratteri utilizza le metriche del carattere, quindi i bordi visibili delle singole lettere non coincidono necessariamente esattamente. L'esempio include sia una lettera maiuscola sia un discendente per evidenziare la differenza tra allineamento baseline e bottom. La disponibilità e la sostituzione del carattere, i caratteri usati e la differenza di dimensioni influenzano il risultato. Le dimensioni del riquadro, i margini, la spaziatura delle linee, l'andare a capo e l'adattamento automatico influiscono anch'essi sul layout; usa gli stessi caratteri e le stesse impostazioni di layout quando confronti le modalità.

Questa impostazione differisce da [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment), che controlla l'allineamento orizzontale del paragrafo, e da [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType), che posiziona il blocco di testo verticalmente all'interno della sua forma. La formattazione apice e pedice tramite [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setEscapement) sposta le singole porzioni rispetto alla baseline invece di impostare l'allineamento del carattere per le linee del paragrafo.

## **Imposta trasparenza per il testo**

La trasparenza del testo è controllata attraverso il componente alfa del colore assegnato a [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat). Negli esempi seguenti, `alpha = 50` è un valore alfa ARGB nella scala 0–255, non una percentuale di trasparenza.

L'esempio di codice seguente mostra come applicare la trasparenza all'**intero paragrafo**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const fillFormat = paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat();

    // Imposta il colore di riempimento del testo a colore trasparente.
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Paragrafo trasparente](transparent_paragraph.png)

Il codice seguente mostra come applicare la trasparenza a **porzioni di testo con un carattere in grassetto**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const fillFormat = portion.getPortionFormat().getFillFormat();

            // Imposta la trasparenza della porzione di testo.
            fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
            fillFormat.getSolidFillColor().setColor(transparentBlack);
        }
    }

    presentation.save("transparent_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Le porzioni di testo trasparenti](transparent_text_portions.png)

## **Imposta spaziatura dei caratteri per il testo**

Usa [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setSpacing) per espandere o comprimere la spaziatura tra i caratteri in una casella di testo. Gli esempi aggiungono 3 punti di spaziatura; valori negativi comprimono il testo.

Il seguente codice JavaScript mostra come espandere la spaziatura dei caratteri nell'**intero paragrafo**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Nota: usa valori negativi per comprimere la spaziatura dei caratteri.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Espandi la spaziatura dei caratteri.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Spaziatura dei caratteri nel paragrafo](character_spacing_in_paragraph.png)

Il codice seguente mostra come espandere la spaziatura dei caratteri in **porzioni di testo con un carattere in grassetto**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Nota: usa valori negativi per comprimere la spaziatura dei caratteri.
            portion.getPortionFormat().setSpacing(3); // Espandi la spaziatura dei caratteri.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Spaziatura dei caratteri nelle porzioni di testo](character_spacing_in_text_portions.png)

### **Disabilita il kerning per caratteri specifici**

In alcuni casi, il testo renderizzato da Aspose.Slides può apparire leggermente più compatto rispetto allo stesso testo visualizzato in PowerPoint. Ciò può accadere perché PowerPoint può ignorare i dati di kerning per alcuni caratteri, anche quando il carattere contiene informazioni di kerning valide e il kerning è abilitato nelle impostazioni di PowerPoint.

Per avvicinare l'output renderizzato a PowerPoint in tali casi, è possibile disabilitare il kerning per le porzioni di testo che usano il carattere interessato. Imposta [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize) a un valore maggiore della dimensione effettiva del carattere. Questo esempio richiede "presentation.pptx" con una casella di testo come prima forma sulla prima diapositiva. Controlla i nomi dei caratteri efficaci, inclusi i caratteri ereditati, e imposta una soglia di 100 punti per le porzioni che usano Roboto. Ciò disabilita il kerning per le porzioni corrispondenti con una dimensione del carattere inferiore a 100 punti:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat().getEffective();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per il testo corrispondente al di sotto della soglia, questa impostazione impedisce il kerning e può aiutare ad allineare il rendering di Aspose.Slides a quello visivo di PowerPoint per i caratteri interessati da questo comportamento specifico di PowerPoint.

## **Gestisci le proprietà dei caratteri del testo**

Le proprietà dei caratteri possono essere impostate a livello di paragrafo tramite [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) o su porzioni individuali tramite [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/).

L'esempio seguente imposta il carattere predefinito del primo paragrafo a Times New Roman 12 punti con formattazione grassetto, corsivo e sottolineatura puntinata. La formattazione esplicita su porzioni individuali ha precedenza su queste impostazioni predefinite.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // Imposta le proprietà del carattere per il paragrafo.
    defaultPortionFormat.setFontHeight(12);
    defaultPortionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
    defaultPortionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Le proprietà del carattere per il paragrafo](font_properties_for_paragraph.png)

L'esempio seguente applica Times New Roman 13 punti, formattazione corsiva e sottolineatura puntinata a porzioni il cui formato efficace è in grassetto:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const portionFormat = portion.getPortionFormat();

            // Imposta le proprietà del carattere per la porzione di testo.
            portionFormat.setFontHeight(13);
            portionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
            portionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
            portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Le proprietà del carattere per le porzioni di testo](font_properties_for_text_portions.png)

## **Controlla la normalizzazione dell'altezza del testo**

Usa [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setNormaliseHeight) quando si riproduce la tipografia di un modello o si indagano differenze nell'altezza dei caratteri. In PowerPoint, abilitare la normalizzazione allunga o comprime verticalmente i singoli caratteri per dare loro un'altezza visibile uniforme all'interno della porzione di testo. Non garantisce altezze di testo uguali tra caratteri diversi.

Imposta la proprietà su [NullableBool.True o False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) per abilitare o disabilitare esplicitamente la normalizzazione. `NullableBool.NotDefined` lascia l'impostazione locale non impostata in modo che la porzione erediti il suo valore, ad esempio dal [getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) del paragrafo. Non significa `False`. Usa [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) e leggi [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) per ottenere il valore booleano risolto.

L'esempio autonomo seguente richiede **Arial** installato. Crea due blocchi di testo contenenti le stesse lettere maiuscole, minuscole, discendenti e caratteri accentati a 54 punti. Entrambi i paragrafi abilitano la normalizzazione per impostazione predefinita. La porzione superiore la disabilita esplicitamente; la porzione inferiore la eredita. Le dimensioni del riquadro, i margini e la spaziatura del paragrafo sono identici, con l'andare a capo e l'adattamento automatico disabilitati per mantenere la comparazione coerente. L'esempio stampa `False: false` e `NotDefined: true`, quindi salva "text_height_normalization.pptx".

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const settings = [aspose.slides.NullableBool.False, aspose.slides.NullableBool.NotDefined];
    const settingNames = ["False", "NotDefined"];

    for (let i = 0; i < settings.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        const paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(java.newByte(aspose.slides.NullableBool.True));

        const portion = paragraph.getPortions().get_Item(0);
        const font = new aspose.slides.FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
        portion.getPortionFormat().setNormaliseHeight(java.newByte(settings[i]));

        console.log(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il confronto sotto è stato esportato dalla presentazione salvata. La riga superiore ha la normalizzazione disabilitata (`False`); la riga inferiore eredita l'impostazione abilitata (`NotDefined` → `True`). Mantieni Arial installato per ricreare quest'aspetto.

![Testo Arial 54 punti con normalizzazione disabilitata sopra e normalizzazione ereditata abilitata sotto](text_height_normalization.png)

La normalizzazione modifica l'altezza dei caratteri senza modificare il valore assegnato a [getFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFontHeight), che specifica la dimensione del carattere in punti. Il [setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) del paragrafo controlla la spaziatura delle linee, mentre il [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) del riquadro di testo controlla come il testo o il suo contenitore si adattano per stare dentro. Queste impostazioni hanno scopi diversi e possono influenzare il layout complessivo in modo indipendente. Per ulteriori informazioni sulla formattazione dei paragrafi e l'ereditarietà, vedere [Gestisci Paragrafo](/slides/it/nodejs-java/manage-paragraph/).

## **Applica e rimuovi il barrato**

Usa [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setStrikethroughType) su una porzione di testo per visualizzare correzioni, termini cancellati o prezzi precedenti senza eliminare il testo originale. Impostala su [TextStrikethroughType.Single o Double](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/) per una o due linee attraverso il testo.

Per rimuovere il barrato, passa [TextStrikethroughType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#None). Questo disabilita esplicitamente l'effetto, anche se la formattazione circostante specifica il barrato. Al contrario, [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#NotDefined) lascia l'impostazione locale non definita, consentendo alla porzione di ereditare la formattazione, ad esempio dal paragrafo. Non garantisce che il barrato venga rimosso. Usa [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) per leggere la formattazione risultante, inclusi i valori ereditati.

L'esempio autonomo seguente crea tre confronti di prezzo. Ogni paragrafo ha porzioni separate per l'etichetta, il prezzo precedente e quello corrente, quindi solo il prezzo precedente è interessato. La prima riga applica e poi rimuove il barrato; le altre righe mantengono rispettivamente il barrato singolo e doppio. Modificando questa impostazione si preserva il testo e le altre formattazioni, incluso il prezzo precedente in grassetto.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const labels = ["None: ", "Single: ", "Double: "];

    for (const label of labels) {
        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        const format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        const font = new aspose.slides.FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        format.getFillFormat().getSolidFillColor().setColor(textColor);

        const labelPortion = new aspose.slides.Portion(label);
        paragraph.getPortions().add(labelPortion);

        const previousPrice = new aspose.slides.Portion("$100");
        previousPrice.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
        paragraph.getPortions().add(previousPrice);
        const currentPrice = new aspose.slides.Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    const paragraphs = shape.getTextFrame().getParagraphs();

    // Applica il barrato, poi rimuovilo esplicitamente dal primo prezzo precedente.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.None));

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Double));

    presentation.save("strikethrough.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato, dall'alto al basso: nessun barrato, barrato singolo e barrato doppio.

![Prezzi precedenti senza barrato, con barrato singolo e con barrato doppio](strikethrough.png)

## **Imposta rotazione del testo**

Usa [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType) per impostare un orientamento predefinito del testo all'interno di una forma.

Il seguente esempio di codice imposta l'orientamento del testo nella forma su [TextVerticalType.Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/), che ruota il testo **di 90 gradi in senso antiorario**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Rotazione del testo](text_rotation.png)

## **Visualizza cifre affiancate nel testo verticale**

Per mantenere insieme due cifre in un'etichetta giapponese verticale, inserisci entrambe le cifre in un'unica porzione di testo e chiama [BasePortionFormat.setKumimoji](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKumimoji) sulla formattazione di quella porzione. L'esempio usa [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/#EastAsianVertical) e MS Gothic 40 punti per entrambe le etichette. Solo il valore [NullableBool](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) passato alla porzione numerica differisce.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const font = new aspose.slides.FontData("MS Gothic");
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const settings = [aspose.slides.NullableBool.True, aspose.slides.NullableBool.False];
    let x = 120;

    for (const kumimoji of settings) {
        const label = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, 48, 120, 420);
        label.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const frame = label.addTextFrame("");
        frame.getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.EastAsianVertical));

        const paragraph = frame.getParagraphs().get_Item(0);
        const format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setLatinFont(font);
        format.setEastAsianFont(font);
        format.setFontHeight(40);
        format.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        format.getFillFormat().getSolidFillColor().setColor(textColor);

        const digits = new aspose.slides.Portion("12");
        digits.getPortionFormat().setKumimoji(java.newByte(kumimoji));

        const portions = paragraph.getPortions();
        portions.clear();
        portions.add(new aspose.slides.Portion("令和"));
        portions.add(digits);
        portions.add(new aspose.slides.Portion("年"));
        x += 240;
    }
    presentation.save("vertical_date.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

In PowerPoint, l'etichetta di sinistra (`True`) mostra le cifre in verticale e affiancate tra 和 e 年. Nell'etichetta di destra (`False`), la coppia è ruotata di 90 gradi in senso orario. I caratteri giapponesi circostanti rimangono verticali in entrambe le etichette.

![Confronto PowerPoint di etichette di data verticali con cifre verticali a sinistra e cifre ruotate a destra.](vertical_date.png)

## **Imposta rotazione personalizzata per i riquadri di testo**

Usa [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) per impostare un angolo di rotazione personalizzato per un [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).

Il codice seguente ruota il riquadro di testo di 3 gradi in senso orario all'interno della forma:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Rotazione personalizzata del testo](custom_text_rotation.png)

## **Imposta interlinea dei paragrafi**

Aspose.Slides fornisce [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) e [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) per controllare la spaziatura dei paragrafi. Queste proprietà si usano come segue:

* Usa un valore positivo per specificare l'interlinea come percentuale dell'altezza della linea.
* Usa un valore negativo per specificare l'interlinea in punti.

L'esempio seguente imposta la spaziatura interna del primo paragrafo al 200 % dell'altezza della linea (interlinea doppia):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Interlinea all'interno del paragrafo](line_spacing.png)

## **Controlla l'interruzione di linea**

Le regole di interruzione di linea dei paragrafi sono utili in blocchi di testo stretti e in presentazioni che mescolano testo latino e orientale. I seguenti metodi appartengono a [ParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/), quindi si applicano all'intero paragrafo:

- [setLatinLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak) controlla le regole di interruzione di linea per il latino. In testo misto, cambiarlo può anche modificare dove il testo e la punteggiatura orientale avvolgono.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) controlla le regole di interruzione di linea orientale, inclusi i limiti sui caratteri all'inizio e alla fine di una linea.

Queste regole non sostituiscono [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setWrapText), che abilita l'andare a capo automatico all'interno di un riquadro di testo. Influenzano il layout quando si verifica l'andare a capo; non inseriscono caratteri di interruzione di linea. Un'interruzione di linea esplicita fornisce una nuova linea nel paragrafo indipendentemente dalla larghezza disponibile.

L'esempio autonomo seguente crea un blocco di testo stretto contenente cinese e latino. Imposta esplicitamente entrambe le opzioni di interruzione di linea e salva "line_breaking.pptx". Per sperimentare con una delle due regole, modifica il valore corrispondente mantenendo le altre impostazioni fisse. L'esempio usa Arial 24 punti e SimSun con una larghezza del riquadro di 160 punti e margini orizzontali a zero. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) è chiamato con [TextAutofitType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textautofittype/) in modo che dimensione del testo e del riquadro rimangano fissi.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    const eastAsianFont = new aspose.slides.FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setLatinLineBreak(java.newByte(aspose.slides.NullableBool.False));
    format.setEastAsianLineBreak(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("line_breaking.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controlla la punteggiatura sospesa**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation) consente alla punteggiatura idonea di estendersi oltre il margine destro della linea di testo invece di occupare la linea successiva. Si applica all'intero paragrafo ed è diverso da un rientro sospeso.

L'esempio autonomo seguente abilita la punteggiatura sospesa in un riquadro di testo largo 100 punti e salva "hanging_punctuation.pptx". Con Arial 24 punti e margini orizzontali a zero, il punto finale rimane dopo la parola "sentence" e si estende oltre il bordo destro del testo. Imposta la proprietà su [NullableBool.False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) per confrontare: con queste impostazioni, il punto occupa una linea separata. L'andare a capo è abilitato e l'adattamento automatico è disabilitato per mantenere fissa la larghezza disponibile.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setHangingPunctuation(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("hanging_punctuation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Non tutte le punteggiature possono sospendersi. Le [condizioni di carattere e layout descritte sopra](#control-line-breaking) si applicano anche a questo confronto: modificare il carattere, la larghezza disponibile, i margini o le impostazioni di adattamento automatico può rimuovere la differenza visibile.

## **Imposta il tipo di adattamento automatico per i riquadri di testo**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) determina come il testo si comporta quando supera i limiti del suo contenitore. Usalo per controllare se il testo si riduce, trabocca o ridimensiona automaticamente la forma. L'esempio seguente configura la forma per ridimensionarsi in base al testo e salva il risultato in "autofit_type.pptx".

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per contare le linee dopo l'andare a capo automatico e vedere come cambia il risultato in base al testo o alla larghezza della forma, vedere [Count Rendered Lines](/slides/it/nodejs-java/manage-paragraph/). Il conteggio delle linee da solo non indica se il testo trabocca dal contenitore.

## **Imposta l'ancora dei riquadri di testo**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType) definisce come il testo è posizionato verticalmente all'interno di una forma, ad esempio in alto, al centro o in basso. L'esempio seguente ancora il testo al fondo della prima forma e salva il risultato in "text_anchor.pptx".

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Imposta la tabulazione del testo**

Usa [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize) e [ParagraphFormat.getTabs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getTabs) per configurare le fermate di tabulazione in un paragrafo. L'esempio seguente imposta l'intervallo predefinito della tabulazione a 100 punti e aggiunge una fermata di tabulazione allineata a sinistra a 30 punti. Queste impostazioni influenzano il testo contenente caratteri di tabulazione.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, java.newByte(aspose.slides.TabAlignment.Left));

    presentation.save("paragraph_tabs.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Le tabulazioni del paragrafo](paragraph_tabs.png)

## **Imposta la lingua di correzione**

Aspose.Slides fornisce [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId), che consente di impostare la lingua di correzione per una porzione di testo. La lingua di correzione determina la lingua utilizzata per il controllo ortografico e grammaticale in PowerPoint.

L'esempio seguente richiede "presentation.pptx" con una casella di testo come prima forma sulla prima diapositiva e almeno un paragrafo. Sostituisce il contenuto del primo paragrafo con "1。", imposta SimSun come carattere e assegna la lingua di correzione cinese semplificato (`zh-CN`). Salva il risultato in "proofing_language.pptx":

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Imposta l'Id di una lingua di correzione.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Copia i metadati della lingua**

Quando si copia testo multilingue da un modello, conserva sia [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getLanguageId) sia [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getAlternativeLanguageId). L'esempio autonomo seguente crea una porzione sorgente con lingua inglese USA e lingua alternativa francese, e copia il testo e gli identificatori a una porzione in una nuova presentazione.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const source = new aspose.slides.Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const destination = new aspose.slides.Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // Se la sorgente non ha una lingua alternativa, null cancella il valore di destinazione.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per provare una sorgente senza lingua alternativa, ometti l'assegnazione di `"fr-FR"`. L'identificatore alternativo sarà quindi `null`, e la stessa istruzione di copia preserva la sua assenza senza introdurre un valore predefinito, anche se la destinazione aveva precedentemente una lingua alternativa assegnata.

Questi identificatori sono metadati della lingua. Preservarli non stabilisce quale dizionario PowerPoint seleziona per il controllo ortografico o grammaticale.

## **Imposta la lingua predefinita**

Usa [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage) per definire la lingua predefinita per il testo creato durante il caricamento o la creazione di una presentazione. L'esempio seguente crea una presentazione con lingua di testo predefinita inglese USA, aggiunge una casella di testo e stampa `en-US` per la sua prima porzione di testo.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // Aggiungi una nuova forma rettangolare con testo.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Controlla la lingua della prima porzione.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Imposta lo stile di testo predefinito**

Per applicare la formattazione di testo predefinita a livello di presentazione, usa [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle).

L'esempio seguente imposta un carattere in grassetto da 14 punti come predefinito per i paragrafi di livello superiore in una nuova presentazione e la salva in "default_text_style.pptx". Il testo può ereditare queste impostazioni predefinite a meno che una formattazione più specifica non le sovrascriva.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // Recupera il formato del paragrafo di livello superiore.
    const paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat !== null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    }

    presentation.save("default_text_style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Estrai testo con l'effetto Tutte Maiuscole**

In PowerPoint, l'applicazione dell'effetto carattere **All Caps** fa apparire il testo in maiuscolo nella diapositiva anche quando è stato digitato originariamente in minuscolo. Quando si recupera tale porzione di testo con Aspose.Slides, la libreria restituisce il testo esattamente come inserito. Per corrispondere al testo visualizzato, controlla [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/) e converti la stringa restituita in maiuscolo quando il valore è `All`.

Questo esempio richiede "sample2.pptx" con una casella di testo come prima forma sulla prima diapositiva. Il suo primo paragrafo contiene "Hello, Aspose!" con l'effetto All Caps applicato, come mostrato sotto.

![Effetto All Caps](all_caps_effect.png)

Il codice seguente mostra come estrarre il testo con l'effetto **All Caps** applicato:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const autoShape = slide.getShapes().get_Item(0);
    const textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    console.log("Original text: " + textPortion.getText());

    const textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() === aspose.slides.TextCapType.All) {
        const text = textPortion.getText().toUpperCase();
        console.log("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Come modifico il testo in una tabella su una diapositiva?**

Per modificare il testo in una tabella su una diapositiva, usa [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/). Itera le celle e aggiorna ciascuna cella tramite [Cell.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame) e la formattazione dei paragrafi tramite [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getParagraphFormat).

**Come applico un colore sfumato al testo su una diapositiva PowerPoint?**

Per applicare un colore sfumato al testo, usa [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat). Imposta [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) su [FillType.Gradient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) e configura le fermate, la direzione e la trasparenza del gradiente.