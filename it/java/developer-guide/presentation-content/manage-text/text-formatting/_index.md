---
title: Formattare il testo della presentazione in Java
linktitle: Formattazione del testo
type: docs
weight: 50
url: /it/java/text-formatting/
keywords:
- evidenziare testo
- espressione regolare
- allineare paragrafo
- stile del testo
- sfondo del testo
- trasparenza del testo
- spaziatura dei caratteri
- proprietà dei caratteri
- famiglia di caratteri
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
- Java
- Aspose.Slides
description: "Formatta e stila il testo nelle presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Java. Personalizza caratteri, colori, allineamento e altro."
---
## **Panoramica**

Questo articolo mostra come formattare il testo nelle presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Java. Copre l'evidenziazione, i colori di sfondo, la trasparenza, la spaziatura dei caratteri, le proprietà dei caratteri, la rotazione, la spaziatura dei paragrafi, il comportamento di adattamento automatico, l'ancoraggio del testo, le tabulazioni e le impostazioni della lingua.

Negli esempi seguenti, utilizzeremo un file denominato \"sample.pptx\", che contiene una singola casella di testo nella prima diapositiva con il seguente testo:

![Testo di esempio](sample_text.png)

## **Evidenziare il testo**

Utilizza il metodo [ITextFrame.highlightText](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-) quando è necessario evidenziare il testo che corrisponde a un determinato campione all'interno di un frame di testo. Il metodo applica un colore di evidenziazione ai frammenti di testo corrispondenti e può essere usato con [TextSearchOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/textsearchoptions/) per controllare come viene eseguita la ricerca, ad esempio per corrispondere solo parole intere.

L'esempio di codice seguente evidenzia tutte le occorrenze dei caratteri **\"try\"** e poi evidenzia solo la parola intera **\"to\"**.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // Ottieni la prima forma dalla prima diapositiva.
    IAutoShape shape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Evidenzia la parola "try" nella forma.
    shape.getTextFrame().highlightText("try", Color.LIGHT_GRAY);

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // Evidenzia la parola "to" nella forma.
    shape.getTextFrame().highlightText("to", Color.MAGENTA, searchOptions, null);

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Il testo evidenziato](highlighted_text.png)

## **Evidenziare il testo usando le espressioni regolari**

Il metodo [ITextFrame.highlightRegex](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) evidenzia le corrispondenze di testo trovate da un'espressione regolare. In Java, questa API è esposta su [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/).

L'esempio di codice seguente evidenzia tutte le parole che contengono **sette o più caratteri**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape shape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

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

## **Impostare il colore di sfondo del testo**

Utilizza [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) per impostare il colore di evidenziazione predefinito per un paragrafo, oppure usa [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) per singole parti di testo.

Il seguente esempio di codice mostra come impostare il colore di sfondo per **l'intero paragrafo**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Imposta il colore di evidenziazione per l'intero paragrafo.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Il paragrafo grigio](gray_paragraph.png)

L'esempio di codice seguente dimostra come impostare il colore di sfondo per **le parti di testo con un carattere in grassetto**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Imposta il colore di evidenziazione per la parte di testo.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Le parti di testo grigie](gray_text_portions.png)

## **Allineare i paragrafi di testo**

Utilizza [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) per impostare l'allineamento del paragrafo all'interno di un frame di testo. Il valore può essere centrato, allineato a sinistra, allineato a destra, giustificato, e così via.

Il seguente esempio di codice mostra come allineare il paragrafo al **centro**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

## **Impostare la trasparenza del testo**

La trasparenza del testo è controllata tramite la componente alfa del colore assegnato a [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Negli esempi seguenti, `alpha = 50` è un valore del canale alfa ARGB sulla scala 0-255, non una percentuale di trasparenza.

L'esempio di codice seguente mostra come applicare la trasparenza all'**intero paragrafo**:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Imposta il colore di riempimento del testo a colore trasparente.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Il paragrafo trasparente](transparent_paragraph.png)

Il seguente esempio di codice mostra come applicare la trasparenza alle **parti di testo con un carattere in grassetto**:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Imposta la trasparenza della parte di testo.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Le parti di testo trasparenti](transparent_text_portions.png)

## **Impostare la spaziatura dei caratteri per il testo**

Utilizza [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) per espandere o ridurre la spaziatura tra i caratteri in una casella di testo.

Il seguente codice Java mostra come espandere la spaziatura dei caratteri nell'**intero paragrafo**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

L'esempio di codice seguente mostra come espandere la spaziatura dei caratteri nelle **parti di testo con un carattere in grassetto**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
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

![La spaziatura dei caratteri nelle parti di testo](character_spacing_in_text_portions.png)

### **Disabilitare il kerning per font specifici**

In alcuni casi, il testo renderizzato da Aspose.Slides può apparire leggermente più compresso rispetto allo stesso testo visualizzato in PowerPoint. Ciò può accadere perché PowerPoint potrebbe ignorare i dati di kerning per alcuni font, anche quando il font contiene informazioni di kerning valide e il kerning è abilitato nelle impostazioni di PowerPoint.

Per avvicinare l'output renderizzato a PowerPoint in tali casi, è possibile disabilitare il kerning per le parti di testo che utilizzano il font interessato. Imposta [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) a un valore notevolmente più grande della dimensione effettiva del font:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormat portionFormat = portion.getPortionFormat();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Questa impostazione impedisce l'applicazione del kerning alle parti di testo corrispondenti e può aiutare ad allineare il rendering di Aspose.Slides all'output visivo di PowerPoint per i font interessati da questo comportamento specifico di PowerPoint.

## **Gestire le proprietà dei caratteri del testo**

Le proprietà dei caratteri possono essere impostate a livello di paragrafo tramite [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) o su singole parti tramite [IPortionFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/iportionformat/).

Il seguente codice imposta il carattere e lo stile del testo per l'intero paragrafo: applica la dimensione del carattere, il grassetto, il corsivo, la sottolineatura puntinata e il carattere Times New Roman a tutte le parti del paragrafo.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

L'esempio di codice seguente applica proprietà simili alle **parti di testo con un carattere in grassetto**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Imposta le proprietà del carattere per la parte di testo.
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

![Le proprietà del carattere per le parti di testo](font_properties_for_text_portions.png)

## **Impostare la rotazione del testo**

Utilizza [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) per impostare un orientamento di testo predefinito all'interno di una forma.

Il seguente esempio di codice imposta l'orientamento del testo nella forma a `Vertical270`, che ruota il testo di **90 gradi in senso antiorario**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La rotazione del testo](text_rotation.png)

## **Impostare rotazione personalizzata per i frame di testo**

Utilizza [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) per impostare un angolo di rotazione personalizzato per un [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/).

L'esempio di codice seguente ruota il frame di testo di 3 gradi in senso orario all'interno della forma:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La rotazione personalizzata del testo](custom_text_rotation.png)

## **Impostare l'interlinea dei paragrafi**

Aspose.Slides fornisce [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-), e [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) per controllare la spaziatura dei paragrafi. queste proprietà vengono usate come segue:

* Usa un valore positivo per specificare l'interlinea come percentuale dell'altezza della linea.
* Usa un valore negativo per specificare l'interlinea in punti.

Il seguente esempio di codice mostra come specificare l'interlinea all'interno del paragrafo:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![L'interlinea all'interno del paragrafo](line_spacing.png)

## **Impostare il tipo di adattamento automatico per i frame di testo**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) determina come il testo si comporta quando supera i confini del suo contenitore. Usalo per controllare se il testo si riduce, trabocca o ridimensiona automaticamente la forma.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Impostare l'ancoraggio dei frame di testo**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) definisce come il testo è posizionato verticalmente all'interno di una forma, ad esempio in alto, al centro o in basso.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Impostare la tabulazione del testo**

Utilizza [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) e [IParagraphFormat.getTabs](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#getTabs--) per configurare le tabulazioni in un paragrafo.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

## **Impostare la lingua di correzione**

Aspose.Slides fornisce [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), che consente di impostare la lingua di correzione per una parte di testo. La lingua di correzione determina la lingua usata per i controlli ortografici e grammaticali in PowerPoint.

Il seguente esempio di codice mostra come impostare la lingua di correzione per una parte di testo:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Imposta l'Id di una lingua di correzione.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1.");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Impostare la lingua predefinita**

Utilizza [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) per definire la lingua predefinita per il testo creato durante il caricamento o la creazione di una presentazione.

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungi una nuova forma rettangolare con testo.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Verifica la lingua della prima porzione.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Impostare lo stile di testo predefinito**

Per applicare la formattazione di testo predefinita a livello di presentazione, utilizza [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Il seguente esempio di codice mostra come impostare un carattere in grassetto predefinito con dimensione 14 pt per tutto il testo su tutte le diapositive in una nuova presentazione.

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

## **Estrarre il testo con l'effetto tutto maiuscolo**

In PowerPoint, l'applicazione dell'effetto **All Caps** al carattere fa apparire il testo in maiuscolo nella diapositiva anche se è stato digitato inizialmente in minuscolo. Quando si recupera una tale parte di testo con Aspose.Slides, la libreria restituisce il testo esattamente com'era stato inserito. Per corrispondere al testo visualizzato, controlla [TextCapType](https://reference.aspose.com/slides/it/java/com.aspose.slides/textcaptype/) e converte la stringa restituita in maiuscolo quando il valore è `All`.

Supponiamo di avere la seguente casella di testo nella prima diapositiva del file sample2.pptx.

![L'effetto tutto maiuscolo](all_caps_effect.png)

L'esempio di codice seguente mostra come estrarre il testo con l'effetto **All Caps** applicato:

```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

Per modificare il testo in una tabella su una diapositiva, utilizza [ITable](https://reference.aspose.com/slides/it/java/com.aspose.slides/itable/). Itera attraverso le celle e aggiorna ciascuna cella tramite [ICell.getTextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/icell/#getTextFrame--) e la formattazione del paragrafo tramite [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Come applicare un colore gradiente al testo in una diapositiva PowerPoint?**

Per applicare un colore gradiente al testo, utilizza [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Imposta [IFillFormat.setFillType](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifillformat/#setFillType-byte-) su [FillType.Gradient](https://reference.aspose.com/slides/it/java/com.aspose.slides/filltype/) e configura le fermate del gradiente, la direzione e la trasparenza.