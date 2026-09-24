---
title: Formattare il testo della presentazione in Java
linktitle: Formattazione del testo
type: docs
weight: 50
url: /it/java/text-formatting/
keywords:
- allineare il paragrafo
- stile del testo
- sfondo del testo
- trasparenza del testo
- spaziatura dei caratteri
- proprietà del font
- famiglia del font
- rotazione del testo
- angolo di rotazione
- cornice del testo
- interlinea
- proprietà autofit
- ancoraggio della cornice del testo
- tabulazione del testo
- lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Formattare e stilizzare il testo in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Java. Personalizza font, colori, allineamento e altro."
---
## **Panoramica**

Questo articolo mostra come formattare il testo in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Java. Copre colori di sfondo, trasparenza, spaziatura dei caratteri, proprietà dei font, rotazione, spaziatura dei paragrafi, comportamento di autofit, ancoraggio del testo, tabulazioni e impostazioni della lingua.

Negli esempi seguenti, utilizzeremo un file denominato "sample.pptx", che contiene una singola casella di testo nella prima diapositiva con il seguente contenuto:

![Testo di esempio](sample_text.png)

Per trovare e evidenziare testo letterale o corrispondenze di espressioni regolari, vedere [Cerca e Sostituisci Testo](/slides/it/java/search-and-replace-text/).

## **Impostare il colore di sfondo del testo**

Utilizzare [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) per impostare il colore di evidenziazione predefinito per un paragrafo, o utilizzare [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) per singole sezioni di testo.

Il seguente esempio di codice mostra come impostare il colore di sfondo per **l'intero paragrafo**:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

L'esempio di codice sottostante dimostra come impostare il colore di sfondo per **sezioni di testo con un font in grassetto**:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Imposta il colore di evidenziazione per la porzione di testo.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Le sezioni di testo grigie](gray_text_portions.png)

## **Allineare i paragrafi di testo**

Utilizzare [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) per impostare l'allineamento del paragrafo all'interno di una casella di testo. Il valore può essere centrato, allineato a sinistra, allineato a destra, giustificato, ecc.

Il seguente esempio di codice mostra come allineare il paragrafo al **centro**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

## **Impostare la trasparenza per il testo**

La trasparenza del testo è controllata tramite il componente alfa del colore assegnato a [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Negli esempi seguenti, `alpha = 50` è un valore ARGB del canale alfa su scala 0–255, non una percentuale di trasparenza.

L'esempio di codice sottostante mostra come applicare la trasparenza a **l'intero paragrafo**:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Il seguente esempio di codice mostra come applicare la trasparenza a **sezioni di testo con un font in grassetto**:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Imposta la trasparenza della porzione di testo.
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

![Le sezioni di testo trasparenti](transparent_text_portions.png)

## **Impostare la spaziatura dei caratteri per il testo**

Utilizzare [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) per espandere o ridurre la spaziatura tra i caratteri in una casella di testo.

Il seguente codice Java mostra come espandere la spaziatura dei caratteri in **l'intero paragrafo**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

L'esempio di codice sottostante mostra come espandere la spaziatura dei caratteri in **sezioni di testo con un font in grassetto**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

![La spaziatura dei caratteri nelle sezioni di testo](character_spacing_in_text_portions.png)

### **Disabilitare il kerning per font specifici**

In alcuni casi, il testo renderizzato da Aspose.Slides può apparire leggermente più stretto rispetto al medesimo testo visualizzato in PowerPoint. Questo può accadere perché PowerPoint può ignorare i dati di kerning per determinati font, anche quando il font contiene informazioni di kerning valide e il kerning è abilitato nelle impostazioni di PowerPoint.

Per avvicinare l'output renderizzato a quello di PowerPoint in tali situazioni, è possibile disabilitare il kerning per le sezioni di testo che utilizzano il font interessato. Impostare [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) a un valore significativamente più grande rispetto alla dimensione effettiva del font:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Questa impostazione impedisce l'applicazione del kerning alle sezioni di testo corrispondenti e può aiutare ad allineare il rendering di Aspose.Slides all'output visivo di PowerPoint per i font soggetti a questo comportamento specifico di PowerPoint.

## **Gestire le proprietà del font del testo**

Le proprietà del font possono essere impostate a livello di paragrafo tramite [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) o su singole sezioni tramite [IPortionFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/iportionformat/).

Il seguente codice imposta il font e lo stile del testo per l'intero paragrafo: applica la dimensione del font, il grassetto, il corsivo, la sottolineatura punteggiata e il font Times New Roman a tutte le sezioni del paragrafo.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Imposta le proprietà del font per il paragrafo.
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

![Le proprietà del font per il paragrafo](font_properties_for_paragraph.png)

L'esempio di codice sottostante applica proprietà analoghe a **sezioni di testo con un font in grassetto**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Imposta le proprietà del font per la porzione di testo.
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

![Le proprietà del font per le sezioni di testo](font_properties_for_text_portions.png)

## **Impostare la rotazione del testo**

Utilizzare [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) per impostare un orientamento predefinito del testo all'interno di una forma.

Il seguente esempio di codice imposta l'orientamento del testo nella forma su `Vertical270`, che ruota il testo **di 90 gradi in senso antiorario**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La rotazione del testo](text_rotation.png)

## **Impostare una rotazione personalizzata per le caselle di testo**

Utilizzare [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) per impostare un angolo di rotazione personalizzato per un [ITextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/).

L'esempio di codice sottostante ruota la casella di testo di 3 gradi in senso orario all'interno della forma:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La rotazione personalizzata del testo](custom_text_rotation.png)

## **Impostare l'interlinea dei paragrafi**

Aspose.Slides fornisce [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) e [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) per controllare la spaziatura dei paragrafi. Queste proprietà vengono usate come segue:

* Utilizzare un valore positivo per specificare l'interlinea come percentuale dell'altezza della riga.
* Utilizzare un valore negativo per specificare l'interlinea in punti.

Il seguente esempio di codice mostra come specificare l'interlinea all'interno del paragrafo:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![L'interlinea nel paragrafo](line_spacing.png)

## **Impostare il tipo di autofit per le caselle di testo**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) determina come il testo si comporta quando supera i limiti del suo contenitore. Usalo per controllare se il testo si riduce, trabocca o ridimensiona automaticamente la forma.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per contare le righe dopo l'adattamento automatico e vedere come la larghezza del testo o della forma modifica il risultato, vedere [Conteggio delle righe renderizzate](/slides/it/java/manage-paragraph/). Il semplice conteggio delle righe non indica se il testo trabocca dal contenitore.

## **Impostare l'ancoraggio delle caselle di testo**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) definisce come il testo è posizionato verticalmente all'interno di una forma, ad esempio in alto, al centro o in basso.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Impostare la tabulazione del testo**

Utilizzare [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) e [IParagraphFormat.getTabs](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraphformat/#getTabs--) per configurare le tabulazioni in un paragrafo.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Aspose.Slides fornisce [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), che consente di impostare la lingua di correzione per una sezione di testo. La lingua di correzione determina la lingua usata per il controllo ortografico e grammaticale in PowerPoint.

Il seguente esempio di codice mostra come impostare la lingua di correzione per una sezione di testo:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Imposta l'Id di una lingua di correzione.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Impostare la lingua predefinita**

Utilizzare [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) per definire la lingua predefinita per il testo creato durante il caricamento o la creazione di una presentazione.

```java
import com.aspose.slides.*;

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

Per applicare la formattazione di testo predefinita a livello di presentazione, utilizzare [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Il seguente esempio di codice mostra come impostare un font in grassetto predefinito con dimensione 14 pt per tutto il testo nelle diapositive di una nuova presentazione.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Recupera il formato del paragrafo di livello superiore.
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

## **Estrarre il testo con l'effetto Maiuscole**

In PowerPoint, l'applicazione dell'effetto **Maiuscole** fa sì che il testo appaia in maiuscolo sulla diapositiva anche se originariamente digitato in minuscolo. Quando si recupera una tale sezione di testo con Aspose.Slides, la libreria restituisce il testo esattamente come è stato inserito. Per corrispondere al testo visualizzato, controllare [TextCapType](https://reference.aspose.com/slides/it/java/com.aspose.slides/textcaptype/) e convertire la stringa restituita in maiuscolo quando il valore è `All`.

Supponiamo di avere la seguente casella di testo nella prima diapositiva del file sample2.pptx.

![L'effetto Maiuscole](all_caps_effect.png)

Il codice sottostante mostra come estrarre il testo con l'effetto **Maiuscole** applicato:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Per modificare il testo in una tabella su una diapositiva, utilizzare [ITable](https://reference.aspose.com/slides/it/java/com.aspose.slides/itable/). Iterare attraverso le celle e aggiornare ciascuna cella tramite [ICell.getTextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/icell/#getTextFrame--) e la formattazione dei paragrafi tramite [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Come applicare un colore gradiente al testo in una diapositiva PowerPoint?**

Per applicare un colore gradiente al testo, utilizzare [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Impostare [IFillFormat.setFillType](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifillformat/#setFillType-byte-) su [FillType.Gradient](https://reference.aspose.com/slides/it/java/com.aspose.slides/filltype/) e configurare le fermate del gradiente, la direzione e la trasparenza.