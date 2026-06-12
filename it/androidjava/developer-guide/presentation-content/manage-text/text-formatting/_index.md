---
title: Formattare il testo della presentazione su Android
linktitle: Formattazione del testo
type: docs
weight: 50
url: /it/androidjava/text-formatting/
keywords:
- evidenziazione testo
- espressione regolare
- allineare paragrafo
- stile del testo
- sfondo del testo
- trasparenza del testo
- spaziatura dei caratteri
- proprietà del carattere
- famiglia di caratteri
- rotazione del testo
- angolo di rotazione
- frame di testo
- interlinea
- proprietà di adattamento automatico
- ancoraggio del frame di testo
- tabulazione del testo
- lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Formattare e stilizzare il testo in presentazioni PowerPoint e OpenDocument usando Aspose.Slides per Android tramite Java. Personalizza caratteri, colori, allineamento e altro."
---
## **Panoramica**

Questo articolo mostra come formattare il testo nelle presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Android tramite Java. Copre l'evidenziazione, i colori di sfondo, la trasparenza, la spaziatura dei caratteri, le proprietà del carattere, la rotazione, la spaziatura dei paragrafi, il comportamento di autofit, l'ancoraggio del testo, le tabulazioni e le impostazioni della lingua.

Negli esempi seguenti, utilizzeremo un file chiamato "sample.pptx", che contiene una singola casella di testo nella prima diapositiva con il seguente testo:

![Testo di esempio](sample_text.png)

## **Evidenzia testo**

Utilizza il metodo [ITextFrame.highlightText](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.lang.Integer-) quando è necessario evidenziare il testo che corrisponde a un modello specifico all'interno di un frame di testo. Il metodo applica un colore di evidenziazione ai frammenti di testo corrispondenti e può essere usato con [ITextSearchOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ITextSearchOptions) per controllare come viene eseguita la ricerca, ad esempio per corrispondere solo parole intere.

Il seguente esempio di codice evidenzia tutte le occorrenze dei caratteri **"try"** e poi evidenzia solo la parola intera **"to"**.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // Ottieni la prima forma dalla prima diapositiva.
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Evidenzia la parola "try" nella forma.
    shape.getTextFrame().highlightText("try", Color.rgb(173, 216, 230));

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // Evidenzia la parola "to" nella forma.
    int violetColor = Color.rgb(238, 130, 238);
    shape.getTextFrame().highlightText("to", violetColor, searchOptions, null);

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Il testo evidenziato](highlighted_text.png)

## **Evidenzia testo usando le espressioni regolari**

Il metodo [ITextFrame.highlightRegex](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ITextFrame#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) evidenzia le corrispondenze di testo trovate tramite un'espressione regolare.

Il seguente esempio di codice evidenzia tutte le parole che contengono **sette o più caratteri**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    java.util.regex.Pattern regex = java.util.regex.Pattern.compile("\\b[^\\s]{7,}\\b");

    // Evidenzia tutte le parole con sette o più caratteri.
    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, null);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Il testo evidenziato usando l'espressione regolare](highlighted_text_using_regex.png)

## **Imposta colore di sfondo del testo**

Utilizza [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IParagraphFormat#getDefaultPortionFormat--) per impostare il colore di evidenziazione predefinito per un paragrafo, oppure usa [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IBasePortionFormat#getHighlightColor--) per singole porzioni di testo.

Il seguente esempio di codice mostra come impostare il colore di sfondo per l'**intero paragrafo**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Imposta il colore di evidenziazione per l'intero paragrafo.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Il paragrafo grigio](gray_paragraph.png)

Il seguente esempio di codice dimostra come impostare il colore di sfondo per le **porzioni di testo con un carattere in grassetto**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Imposta il colore di evidenziazione per la porzione di testo.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Le porzioni di testo grigie](gray_text_portions.png)

## **Allinea paragrafi di testo**

Utilizza [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IParagraphFormat#setAlignment-byte-) per impostare l'allineamento del paragrafo all'interno di un frame di testo. Il valore può essere centrato, allineato a sinistra, allineato a destra, giustificato, ecc.

Il seguente esempio di codice mostra come allineare il paragrafo al **centro**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Imposta l'allineamento del paragrafo al centro.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Il paragrafo allineato](aligned_paragraph.png)

## **Imposta trasparenza per il testo**

La trasparenza del testo è controllata tramite il componente alfa del colore assegnato a [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--). Negli esempi seguenti, `alpha = 50` è un valore del canale alfa ARGB su scala 0-255, non una percentuale di trasparenza.

Il seguente esempio di codice mostra come applicare la trasparenza all'**intero paragrafo**:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Imposta il colore di riempimento del testo a colore trasparente.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Il paragrafo trasparente](transparent_paragraph.png)

Il seguente esempio di codice mostra come applicare la trasparenza alle **porzioni di testo con un carattere in grassetto**:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Imposta la trasparenza della porzione di testo.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Le porzioni di testo trasparenti](transparent_text_portions.png)

## **Imposta spaziatura dei caratteri per il testo**

Utilizza [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IBasePortionFormat#setSpacing-float-) per espandere o ridurre la spaziatura tra i caratteri in una casella di testo.

Il seguente codice Java mostra come espandere la spaziatura dei caratteri nell'**intero paragrafo**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Nota: Usa valori negativi per comprimere la spaziatura dei caratteri.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Espandi la spaziatura dei caratteri.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La spaziatura dei caratteri nel paragrafo](character_spacing_in_paragraph.png)

Il seguente esempio di codice mostra come espandere la spaziatura dei caratteri nelle **porzioni di testo con un carattere in grassetto**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Nota: Usa valori negativi per comprimere la spaziatura dei caratteri.
            portion.getPortionFormat().setSpacing(3); // Espandi la spaziatura dei caratteri.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La spaziatura dei caratteri nelle porzioni di testo](character_spacing_in_text_portions.png)

### **Disabilita il kerning per caratteri specifici**

In alcuni casi, il testo renderizzato da Aspose.Slides può apparire leggermente più stretto rispetto allo stesso testo visualizzato in PowerPoint. Ciò può accadere perché PowerPoint può ignorare i dati di kerning per alcuni caratteri, anche quando il carattere contiene informazioni di kerning valide e il kerning è abilitato nelle impostazioni di PowerPoint.

Per rendere l'output renderizzato più simile a PowerPoint in tali casi, è possibile disabilitare il kerning per le porzioni di testo che usano il carattere interessato. Imposta [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IBasePortionFormat#setKerningMinimalSize-float-) a un valore notevolmente più grande della dimensione effettiva del carattere:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (int paragraphIndex = 0; paragraphIndex < autoShape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
        IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

        for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            IFontData latinFont = portion.getPortionFormat().getLatinFont();
            IFontData eastAsianFont = portion.getPortionFormat().getEastAsianFont();
            IFontData complexScriptFont = portion.getPortionFormat().getComplexScriptFont();

            boolean usesTargetFont =
                    latinFont != null && targetFont.equals(latinFont.getFontName()) ||
                    eastAsianFont != null && targetFont.equals(eastAsianFont.getFontName()) ||
                    complexScriptFont != null && targetFont.equals(complexScriptFont.getFontName());

            if (usesTargetFont) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Questa impostazione impedisce l'applicazione del kerning alle porzioni di testo corrispondenti e può aiutare ad allineare il rendering di Aspose.Slides all'output visivo di PowerPoint per i caratteri interessati da questo comportamento specifico di PowerPoint.

## **Gestisci proprietà del carattere del testo**

Le proprietà del carattere possono essere impostate a livello di paragrafo tramite [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IParagraphFormat#getDefaultPortionFormat--) o su singole porzioni tramite [IPortionFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPortionFormat).

Il codice seguente imposta il carattere e lo stile del testo per l'intero paragrafo: applica la dimensione del carattere, il grassetto, il corsivo, la sottolineatura punteggiata e il carattere Times New Roman a tutte le porzioni del paragrafo.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Imposta le proprietà del carattere per il paragrafo.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Le proprietà del carattere per il paragrafo](font_properties_for_paragraph.png)

Il seguente esempio di codice applica proprietà simili alle **porzioni di testo con un carattere in grassetto**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Imposta le proprietà del carattere per la porzione di testo.
            portion.getPortionFormat().setFontHeight(13);
            portion.getPortionFormat().setFontItalic(NullableBool.True);
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
            portion.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Le proprietà del carattere per le porzioni di testo](font_properties_for_text_portions.png)

## **Imposta rotazione del testo**

Utilizza [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-) per impostare un'orientazione del testo predefinita all'interno di una forma.

Il seguente esempio di codice imposta l'orientazione del testo nella forma a `Vertical270`, che ruota il testo di **90 gradi in senso antiorario**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La rotazione del testo](text_rotation.png)

## **Imposta rotazione personalizzata per i frame di testo**

Utilizza [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) per impostare un angolo di rotazione personalizzato per un [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ITextFrame).

Il seguente esempio di codice ruota il frame di testo di 3 gradi in senso orario all'interno della forma:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La rotazione personalizzata del testo](custom_text_rotation.png)

## **Imposta interlinea dei paragrafi**

Aspose.Slides fornisce [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IParagraphFormat#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IParagraphFormat#setSpaceBefore-float-), e [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IParagraphFormat#setSpaceWithin-float-) per controllare la spaziatura dei paragrafi. Queste proprietà vengono utilizzate come segue:

* Usa un valore positivo per specificare l'interlinea come percentuale dell'altezza della riga.
* Usa un valore negativo per specificare l'interlinea in punti.

Il seguente esempio di codice mostra come specificare l'interlinea all'interno del paragrafo:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![L'interlinea all'interno del paragrafo](line_spacing.png)

## **Imposta tipo di adattamento automatico per i frame di testo**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) determina come il testo si comporta quando supera i limiti del suo contenitore. Usalo per controllare se il testo si riduce, trabocca o ridimensiona automaticamente la forma.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Imposta ancoraggio dei frame di testo**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) definisce come il testo è posizionato verticalmente all'interno di una forma, ad esempio in alto, al centro o in basso.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Imposta tabulazione del testo**

Utilizza [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IParagraphFormat#setDefaultTabSize-float-) e [IParagraphFormat.getTabs](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IParagraphFormat#getTabs--) per configurare le tabulazioni in un paragrafo.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Le tabulazioni del paragrafo](paragraph_tabs.png)

## **Imposta lingua di correzione**

Aspose.Slides fornisce [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-), che consente di impostare la lingua di correzione per una porzione di testo. La lingua di correzione determina la lingua usata per i controlli ortografici e grammaticali in PowerPoint.

Il seguente esempio di codice mostra come impostare la lingua di correzione per una porzione di testo:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Imposta l'ID della lingua di correzione.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Imposta lingua predefinita**

Utilizza [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/LoadOptions#setDefaultTextLanguage-java.lang.String-) per definire la lingua predefinita per il testo creato durante il caricamento o la creazione di una presentazione.

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungi una nuova forma rettangolare con testo.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Controlla la lingua della prima porzione.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Imposta stile di testo predefinito**

Per applicare la formattazione di testo predefinita a livello di presentazione, utilizza [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPresentation#getDefaultTextStyle--).

Il seguente esempio di codice mostra come impostare un carattere in grassetto predefinito con dimensione 14 pt per tutto il testo di tutte le diapositive in una nuova presentazione.

```java
Presentation presentation = new Presentation();
try {
    // Ottieni il formato del paragrafo di livello superiore.
    IParagraphFormat paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(NullableBool.True);
    }

    presentation.save("default_text_style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Estrai testo con l'effetto tutto maiuscolo**

In PowerPoint, l'applicazione dell'effetto **All Caps** al carattere fa sì che il testo appaia in maiuscolo sulla diapositiva anche se è stato originariamente digitato in minuscolo. Quando si recupera una tale porzione di testo con Aspose.Slides, la libreria restituisce il testo esattamente come è stato inserito. Per corrispondere al testo visualizzato, controlla [TextCapType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/TextCapType) e converte la stringa restituita in maiuscolo quando il valore è `All`.

Supponiamo di avere la seguente casella di testo nella prima diapositiva del file sample2.pptx.

![L'effetto All Caps](all_caps_effect.png)

Il seguente esempio di codice mostra come estrarre il testo con l'effetto **All Caps** applicato:

```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortion textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    System.out.println("Original text: " + textPortion.getText());

    IPortionFormatEffectiveData textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == TextCapType.All) {
        String text = textPortion.getText().toUpperCase();
        System.out.println("All-Caps effect: " + text);
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

Per modificare il testo in una tabella su una diapositiva, utilizza [ITable](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ITable). Itera attraverso le celle e aggiorna ciascuna cella tramite [ICell.getTextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ICell#getTextFrame--) e la formattazione del paragrafo tramite [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IParagraph#getParagraphFormat--).

**Come applicare un colore sfumato al testo in una diapositiva PowerPoint?**

Per applicare un colore sfumato al testo, utilizza [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--). Imposta [IFillFormat.setFillType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IFillFormat#setFillType-int-) a [FillType.Gradient](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/FillType) e configura le fermate del gradiente, la direzione e la trasparenza.