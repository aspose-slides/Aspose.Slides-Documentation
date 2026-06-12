---
title: Formattare il testo della presentazione in JavaScript
linktitle: Formattazione del testo
type: docs
weight: 50
url: /it/nodejs-java/text-formatting/
keywords:
- evidenziare il testo
- espressione regolare
- allineare il paragrafo
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
- ancoraggio del riquadro di testo
- tabulazione del testo
- lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Formattare e stilizzare il testo in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Node.js tramite Java. Personalizza caratteri, colori, allineamento e altro."
---
## **Panoramica**

Questo articolo mostra come formattare il testo nelle presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Node.js tramite Java. Copre l'evidenziazione, i colori di sfondo, la trasparenza, la spaziatura dei caratteri, le proprietà dei caratteri, la rotazione, la spaziatura dei paragrafi, il comportamento di adattamento automatico, l'ancoraggio del testo, le tabulazioni e le impostazioni della lingua.

Negli esempi seguenti, useremo un file denominato "sample.pptx", che contiene una singola casella di testo nella prima diapositiva con il seguente contenuto:

![Testo di esempio](sample_text.png)

## **Evidenziare il testo**

Utilizza il metodo [TextFrame.highlightText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-) quando devi evidenziare il testo che corrisponde a un determinato campione all'interno di un frame di testo. Il metodo applica un colore di evidenziazione ai frammenti di testo corrispondenti e può essere usato con [TextSearchOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textsearchoptions/) per controllare come viene eseguita la ricerca, ad esempio per corrispondere solo parole intere.

Il frammento di codice sottostante evidenzia tutte le occorrenze dei caratteri **"try"** e poi evidenzia solo la parola intera **"to"**.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const textFrame = shape.getTextFrame();

    // Evidenzia la parola "try" nella forma.
    textFrame.highlightText("try", java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // Evidenzia la parola "to" nella forma.
    textFrame.highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), searchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Il testo evidenziato](highlighted_text.png)

## **Evidenziare il testo usando espressioni regolari**

Il metodo [TextFrame.highlightRegex](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-aspose.slides.IFindResultCallback-) evidenzia le corrispondenze di testo trovate mediante un'espressione regolare. In Node.js tramite Java, questa API è esposta su [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/).

Il frammento di codice sottostante evidenzia tutte le parole che contengono **sette o più caratteri**:

```javascript
const Pattern = java.import("java.util.regex.Pattern");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    // Evidenzia tutte le parole con sette o più caratteri.
    shape.getTextFrame().highlightRegex(regex, java.getStaticFieldValue("java.awt.Color", "YELLOW"), null);

    presentation.save("highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Il testo evidenziato usando l'espressione regolare](highlighted_text_using_regex.png)

## **Impostare il colore di sfondo del testo**

Usa [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) per impostare il colore di evidenziazione predefinito per un paragrafo, oppure usa [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portionformat/#getHighlightColor--) per porzioni di testo individuali.

Il seguente frammento di codice mostra come impostare il colore di sfondo per il **intero paragrafo**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Imposta il colore di evidenziazione per l'intero paragrafo.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Il paragrafo grigio](gray_paragraph.png)

Il frammento di codice sottostante dimostra come impostare il colore di sfondo per **porzioni di testo con carattere grassetto**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

## **Allineare i paragrafi di testo**

Usa [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/#setAlignment-byte-) per impostare l'allineamento del paragrafo all'interno di un frame di testo. Il valore può essere centrato, allineato a sinistra, allineato a destra, giustificato, ecc.

Il seguente frammento di codice mostra come allineare il paragrafo al **centro**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Imposta l'allineamento del paragrafo al centro.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Il paragrafo allineato](aligned_paragraph.png)

## **Impostare la trasparenza per il testo**

La trasparenza del testo è controllata tramite la componente alfa del colore assegnato a [PortionFormat.getFillFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portionformat/#getFillFormat--). Negli esempi seguenti, `alpha = 50` è un valore alfa ARGB su scala 0‑255, non una percentuale di trasparenza.

Il frammento di codice sottostante mostra come applicare la trasparenza al **intero paragrafo**:

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

![Il paragrafo trasparente](transparent_paragraph.png)

Il seguente frammento di codice mostra come applicare la trasparenza a **porzioni di testo con carattere grassetto**:

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

## **Impostare la spaziatura dei caratteri per il testo**

Usa [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) per espandere o contrarre la spaziatura tra i caratteri in una casella di testo.

Il seguente codice JavaScript mostra come espandere la spaziatura dei caratteri nel **intero paragrafo**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Nota: usa valori negativi per comprimere la spaziatura dei caratteri.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Espandi la spaziatura dei caratteri.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La spaziatura dei caratteri nel paragrafo](character_spacing_in_paragraph.png)

Il frammento di codice sottostante mostra come espandere la spaziatura dei caratteri in **porzioni di testo con carattere grassetto**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

![La spaziatura dei caratteri nelle porzioni di testo](character_spacing_in_text_portions.png)

### **Disabilitare il kerning per caratteri specifici**

In alcuni casi, il testo renderizzato da Aspose.Slides può sembrare leggermente più stretto rispetto al medesimo testo visualizzato in PowerPoint. Ciò può accadere perché PowerPoint può ignorare i dati di kerning per alcuni caratteri, anche quando il carattere contiene informazioni di kerning valide e il kerning è abilitato nelle impostazioni di PowerPoint.

Per avvicinare l'output renderizzato a quello di PowerPoint in tali casi, è possibile disabilitare il kerning per le porzioni di testo che usano il carattere interessato. Imposta [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) a un valore notevolmente più grande della dimensione effettiva del carattere:

```javascript
const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Questa impostazione impedisce l'applicazione del kerning alle porzioni di testo corrispondenti e può contribuire a far coincidere il rendering di Aspose.Slides con l'output visivo di PowerPoint per i caratteri interessati da questo comportamento specifico di PowerPoint.

## **Gestire le proprietà dei caratteri del testo**

Le proprietà dei caratteri possono essere impostate a livello di paragrafo tramite [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) o su singole porzioni tramite [PortionFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portionformat/).

Il seguente codice imposta il carattere e lo stile del testo per l'intero paragrafo: applica la dimensione del carattere, il grassetto, il corsivo, la sottolineatura puntinata e il carattere Times New Roman a tutte le porzioni nel paragrafo.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

![Le proprietà dei caratteri per il paragrafo](font_properties_for_paragraph.png)

Il frammento di codice sottostante applica proprietà simili a **porzioni di testo con carattere grassetto**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

![Le proprietà dei caratteri per le porzioni di testo](font_properties_for_text_portions.png)

## **Impostare la rotazione del testo**

Usa [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) per impostare un orientamento di testo predefinito all'interno di una forma.

Il seguente frammento di codice imposta l'orientamento del testo nella forma su `Vertical270`, che ruota il testo **di 90 gradi in senso antiorario**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La rotazione del testo](text_rotation.png)

## **Impostare rotazione personalizzata per i frame di testo**

Usa [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) per impostare un angolo di rotazione personalizzato per un [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/).

Il frammento di codice sottostante ruota il frame di testo di 3 gradi in senso orario all'interno della forma:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La rotazione del testo personalizzata](custom_text_rotation.png)

## **Impostare l'interlinea dei paragrafi**

Aspose.Slides fornisce [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-) e [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) per controllare la spaziatura dei paragrafi. Queste proprietà si usano come segue:

* Utilizzare un valore positivo per specificare l'interlinea come percentuale dell'altezza della riga.
* Utilizzare un valore negativo per specificare l'interlinea in punti.

Il seguente frammento di codice mostra come specificare l'interlinea all'interno del paragrafo:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![L'interlinea nel paragrafo](line_spacing.png)

## **Impostare il tipo di adattamento automatico per i frame di testo**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) determina come il testo si comporta quando supera i limiti del suo contenitore. Usalo per controllare se il testo si riduce, trabocca o ridimensiona automaticamente la forma.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Impostare l'ancoraggio dei frame di testo**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) definisce come il testo è posizionato verticalmente all'interno di una forma, ad esempio in alto, al centro o in basso.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Impostare la tabulazione del testo**

Usa [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) e [ParagraphFormat.getTabs](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraphformat/#getTabs--) per configurare le tabulazioni in un paragrafo.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

## **Impostare la lingua di revisione**

Aspose.Slides fornisce [PortionFormat.setLanguageId](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-), che consente di impostare la lingua di revisione per una porzione di testo. La lingua di revisione determina la lingua utilizzata per i controlli ortografici e grammaticali in PowerPoint.

Il seguente frammento di codice mostra come impostare la lingua di revisione per una porzione di testo:

```javascript
const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Imposta l'Id della lingua di correzione.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1.");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Impostare la lingua predefinita**

Usa [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) per definire la lingua predefinita per il testo creato durante il caricamento o la creazione di una presentazione.

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // Aggiungi una nuova forma rettangolare con testo.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Verifica la lingua della prima porzione.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Impostare lo stile di testo predefinito**

Per applicare la formattazione di testo predefinita a livello di presentazione, usa [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--).

Il seguente frammento di codice mostra come impostare un carattere grassetto predefinito con dimensione 14 pt per tutto il testo di tutte le diapositive in una nuova presentazione.

```javascript
const presentation = new aspose.slides.Presentation();
try {
    // Ottieni il formato del paragrafo di livello superiore.
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

## **Estrarre il testo con l'effetto Maiuscole**

In PowerPoint, l'applicazione dell'effetto **All Caps** fa sì che il testo appaia in maiuscolo sulla diapositiva anche se originariamente è stato digitato in minuscolo. Quando recuperi una tale porzione di testo con Aspose.Slides, la libreria restituisce il testo esattamente come è stato inserito. Per far corrispondere il testo visualizzato, controlla [TextCapType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textcaptype/) e converti la stringa restituita in maiuscolo quando il valore è `All`.

Supponiamo di avere la seguente casella di testo sulla prima diapositiva del file sample2.pptx.

![L'effetto Maiuscole](all_caps_effect.png)

Il frammento di codice sottostante mostra come estrarre il testo con l'effetto **All Caps** applicato:

```javascript
const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

**Come modificare il testo in una tabella su una diapositiva?**

Per modificare il testo in una tabella su una diapositiva, usa [Table](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/table/). Itera attraverso le celle e aggiorna ogni cella tramite [Cell.getTextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/cell/#getTextFrame--) e la formattazione del paragrafo tramite [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--).

**Come applicare un colore a gradiente al testo in una diapositiva PowerPoint?**

Per applicare un colore a gradiente al testo, usa [PortionFormat.getFillFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portionformat/#getFillFormat--). Imposta [FillFormat.setFillType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) su [FillType.Gradient](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/filltype/) e configura le fermate del gradiente, la direzione e la trasparenza.