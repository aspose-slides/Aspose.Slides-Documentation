---
title: Formattare il testo della presentazione in Java
linktitle: Formattazione del testo
type: docs
weight: 50
url: /it/java/text-formatting/
keywords:
- allineare paragrafo
- stile del testo
- sfondo del testo
- trasparenza del testo
- spaziatura dei caratteri
- proprietà del carattere
- famiglia di caratteri
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
- Java
- Aspose.Slides
description: "Formatta e stila il testo in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Java. Personalizza caratteri, colori, allineamento e altro."
---
## **Panoramica**

Questo articolo mostra come formattare il testo in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Java. Copre i colori di sfondo, la trasparenza, la spaziatura dei caratteri, le proprietà del carattere, la rotazione, la spaziatura dei paragrafi, il comportamento di adattamento automatico, l’ancoraggio del testo, le tabulazioni e le impostazioni della lingua.

Salvo diversa indicazione, gli esempi usano [sample.pptx](sample.pptx). La prima forma nella sua prima diapositiva è una casella di testo e il suo primo paragrafo contiene il testo mostrato di seguito. Sia gli indici delle diapositive che delle forme partono da zero. Gli esempi che selezionano parti in grassetto usano la formattazione effettiva, inclusa la formattazione in grassetto ereditata:

![Testo di esempio](sample_text.png)

Per trovare e evidenziare testo letterale o corrispondenze di espressioni regolari, vedere [Cerca e Sostituisci Testo](/slides/it/java/search-and-replace-text/).

## **Impostare il colore di sfondo del testo**

Usa [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) per impostare il colore di evidenziazione predefinito per un paragrafo, o usa [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) per singole porzioni di testo.

L’esempio seguente imposta un’evidenziazione grigio chiaro come predefinita per il primo paragrafo. I colori di evidenziazione espliciti sulle singole porzioni hanno precedenza su questa impostazione predefinita:

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

L’esempio di codice qui sotto dimostra come impostare il colore di sfondo per **porzioni di testo con carattere in grassetto**:

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

![Le porzioni di testo grigie](gray_text_portions.png)

## **Allineare i paragrafi di testo**

Usa [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) per impostare l’allineamento del paragrafo all’interno di un riquadro di testo. Il valore può essere centrato, allineato a sinistra, allineato a destra, giustificato, ecc.

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

## **Allineare i caratteri all’interno di una riga**

Usa [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) per allineare verticalmente le porzioni di testo di diverse dimensioni del carattere all’interno di una riga. Questa impostazione si applica all’intero paragrafo e controlla l’allineamento all’interno di ciascuna delle sue righe.

Il seguente esempio autonomo crea quattro caselle di testo etichettate su una diapositiva. Ogni paragrafo contiene lo stesso testo a 18, 36 e 54 punti, con un diverso allineamento del carattere. Usa Arial, disattiva l’adattamento automatico e il ritorno a capo, e mantiene i riquadri di testo sufficientemente grandi per una singola riga.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] alignments = { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
    String[] alignmentNames = { "Baseline", "Top", "Center", "Bottom" };
    float[] fontSizes = { 18f, 36f, 54f };

    for (int i = 0; i < alignments.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);

        IParagraph label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        for (float fontSize : fontSizes) {
            Portion portion = new Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Confronto di allineamento di Base, Superiore, Centro e Inferiore con dimensioni del carattere miste](font_alignment.png)

L’allineamento del carattere utilizza metriche tipografiche, quindi i bordi visibili delle singole lettere non coincidono necessariamente esattamente. L’esempio include sia una lettera maiuscola sia un discendente per evidenziare la differenza tra l’allineamento alla linea di base e quello inferiore. Disponibilità e sostituzione dei caratteri, i caratteri usati e la differenza di dimensioni influenzano il risultato. Dimensioni del riquadro, margini, interlinea, ritorno a capo e adattamento automatico influiscono anche sul layout; utilizza gli stessi caratteri e le stesse impostazioni di layout quando confronti le modalità.

Questa impostazione differisce da [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-), che controlla l’allineamento orizzontale del paragrafo, e da [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-), che posiziona verticalmente il blocco di testo all’interno della sua forma. La formattazione a apice e pedice tramite [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setEscapement-float-) sposta le singole porzioni rispetto alla linea di base invece di impostare l’allineamento del carattere per le righe del paragrafo.

## **Impostare la trasparenza del testo**

La trasparenza del testo è controllata tramite la componente alfa del colore assegnato a [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Negli esempi seguenti, `alpha = 50` è un valore di canale alfa ARGB nella scala 0–255, non una percentuale di trasparenza.

L’esempio di codice qui sotto mostra come applicare la trasparenza all’**intero paragrafo**:

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

Il seguente esempio di codice mostra come applicare la trasparenza alle **porzioni di testo con carattere in grassetto**:

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

![Le porzioni di testo trasparenti](transparent_text_portions.png)

## **Impostare la spaziatura dei caratteri per il testo**

Usa [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) per espandere o comprimere la spaziatura tra i caratteri in una casella di testo. Gli esempi aggiungono 3 punti di spaziatura; valori negativi comprimono il testo.

Il seguente codice Java mostra come espandere la spaziatura dei caratteri nell’**intero paragrafo**:

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

L’esempio di codice qui sotto mostra come espandere la spaziatura dei caratteri nelle **porzioni di testo con carattere in grassetto**:

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

![La spaziatura dei caratteri nelle porzioni di testo](character_spacing_in_text_portions.png)

### **Disabilitare il kerning per caratteri specifici**

In alcuni casi, il testo renderizzato da Aspose.Slides può apparire leggermente più stretto rispetto allo stesso testo visualizzato in PowerPoint. Questo può accadere perché PowerPoint potrebbe ignorare i dati di kerning per determinati caratteri, anche quando il carattere contiene informazioni di kerning valide e il kerning è abilitato nelle impostazioni di PowerPoint.

Per avvicinare il risultato renderizzato a PowerPoint in tali casi, è possibile disabilitare il kerning per le porzioni di testo che utilizzano il carattere interessato. Imposta [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) a un valore superiore alla dimensione reale del carattere. Questo esempio richiede “presentation.pptx” con una casella di testo come prima forma sulla prima diapositiva. Verifica i nomi dei caratteri effettivi, inclusi quelli ereditati, e imposta una soglia di 100 punti per le porzioni che usano Roboto. Questo disabilita il kerning per le porzioni corrispondenti con una dimensione del carattere inferiore a 100 punti:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormatEffectiveData portionFormat = portion.getPortionFormat().getEffective();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per le porzioni di testo al di sotto della soglia, questa impostazione impedisce il kerning e può aiutare ad allineare il rendering di Aspose.Slides all’output visivo di PowerPoint per i caratteri interessati da questo comportamento specifico di PowerPoint.

## **Gestire le proprietà del carattere del testo**

Le proprietà del carattere possono essere impostate a livello di paragrafo tramite [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) o su singole porzioni tramite [IPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/).

Il seguente esempio imposta il carattere predefinito del primo paragrafo a Times New Roman 12 punti con formattazione in grassetto, corsivo e sottolineatura puntinata. La formattazione esplicita su singole porzioni ha precedenza su questi valori predefiniti.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Il seguente esempio applica Times New Roman 13 punti, formattazione corsiva e sottolineatura puntinata alle porzioni il cui formato effettivo è in grassetto:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
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

## **Controllare la normalizzazione dell’altezza del testo**

Usa [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) quando si riproduce la tipografia di un modello o si indagano differenze di altezza dei caratteri. In PowerPoint, abilitare la normalizzazione allunga o comprime verticalmente i singoli caratteri per dare loro un’altezza visibile uniforme all’interno della porzione di testo. Non garantisce altezze di testo uguali tra diversi caratteri.

Imposta la proprietà su [NullableBool.True or False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) per abilitare o disabilitare esplicitamente la normalizzazione. `NullableBool.NotDefined` lascia l’impostazione locale non impostata, così la porzione eredita il valore, ad esempio dal [getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) del paragrafo. Non equivale a `False`. Usa [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) e leggi [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) per ottenere il valore booleano risolto.

Il seguente esempio autonomo richiede **Arial** installato. Crea due blocchi di testo contenenti le stesse lettere maiuscole, minuscole, discendenti e caratteri accentati a 54 punti. Entrambi i paragrafi abilitano la normalizzazione per impostazione predefinita. La porzione superiore la disabilita esplicitamente; la porzione inferiore la eredita. Le dimensioni dei riquadri, i margini e la spaziatura dei paragrafi sono identici, con ritorno a capo e adattamento automatico disattivati per mantenere il confronto coerente. L’esempio stampa `False: false` e `NotDefined: true`, quindi salva “text_height_normalization.pptx”.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] settings = { NullableBool.False, NullableBool.NotDefined };
    String[] settingNames = { "False", "NotDefined" };

    for (int i = 0; i < settings.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True);

        IPortion portion = paragraph.getPortions().get_Item(0);
        FontData font = new FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        portion.getPortionFormat().setNormaliseHeight(settings[i]);

        System.out.println(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il confronto sotto è stato esportato dalla presentazione salvata. La riga superiore ha la normalizzazione disabilitata (`False`); la riga inferiore eredita l’impostazione abilitata (`NotDefined` → `True`). Mantieni Arial installato per riprodurre questa apparenza.

![Testo Arial 54 punti con normalizzazione disabilitata sopra e normalizzazione ereditata abilitata sotto](text_height_normalization.png)

La normalizzazione modifica l’altezza del carattere senza cambiare il valore assegnato a [getFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) che specifica la dimensione del carattere in punti. [setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) controlla l’interlinea, mentre [setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) controlla come il testo o il suo contenitore si adattano. Queste impostazioni hanno scopi diversi e possono influenzare il layout complessivo in modo indipendente. Per ulteriori informazioni sulla formattazione dei paragrafi e l’ereditarietà, vedere [Gestire i paragrafi](/slides/it/java/manage-paragraph/).

## **Applicare e rimuovere il barrato**

Usa [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) su una porzione di testo per mostrare correzioni, termini annullati o prezzi precedenti senza eliminare il testo originale. Impostala su [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/) per una o due linee attraverso il testo.

Per rimuovere il barrato, passa [TextStrikethroughType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#None). Questo disabilita esplicitamente l’effetto, anche se la formattazione circostante prevede il barrato. Al contrario, [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#NotDefined) lascia l’impostazione locale indefinita, consentendo alla porzione di ereditare la formattazione, ad esempio dal paragrafo. Non garantisce che il barrato sia rimosso. Usa [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) per leggere la formattazione risultante, inclusi i valori ereditati.

Il seguente esempio autonomo crea tre confronti di prezzo. Ogni paragrafo ha porzioni separate per l’etichetta, il prezzo precedente e il prezzo corrente, così solo il prezzo precedente è interessato. La prima riga applica e poi rimuove il barrato; le altre righe mantengono rispettivamente il barrato singolo e quello doppio. Modificare questa impostazione preserva il testo e la sua altra formattazione, incluso il prezzo precedente in grassetto.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    String[] labels = { "None: ", "Single: ", "Double: " };

    for (String label : labels) {
        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        IPortionFormat format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        FontData font = new FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(FillType.Solid);
        format.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        Portion labelPortion = new Portion(label);
        paragraph.getPortions().add(labelPortion);

        Portion previousPrice = new Portion("$100");
        previousPrice.getPortionFormat().setFontBold(NullableBool.True);
        paragraph.getPortions().add(previousPrice);
        Portion currentPrice = new Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    IParagraphCollection paragraphs = shape.getTextFrame().getParagraphs();

    // Applica il barrato, poi rimuovilo esplicitamente dal primo prezzo precedente.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None);

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double);

    presentation.save("strikethrough.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato, dall’alto verso il basso: nessun barrato, barrato singolo e barrato doppio.

![Prezzi precedenti senza barrato, con barrato singolo e con barrato doppio](strikethrough.png)

## **Impostare la rotazione del testo**

Usa [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) per impostare un’orientazione predefinita del testo all’interno di una forma.

Il seguente esempio di codice imposta l’orientazione del testo nella forma su [TextVerticalType.Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/), che ruota il testo **di 90 gradi in senso antiorario**:

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

## **Visualizzare cifre affiancate nel testo verticale**

Per mantenere insieme due cifre in un’etichetta giapponese verticale, inserisci entrambe le cifre in una sola porzione di testo e chiama [IBasePortionFormat.setKumimoji](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKumimoji-byte-) su quella porzione. L’esempio utilizza [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/#EastAsianVertical) e MS Gothic 40 punti per entrambe le etichette. Solo il valore [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) passato alla porzione numerica differisce.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] settings = { NullableBool.True, NullableBool.False };
    float x = 120;

    for (byte kumimoji : settings) {
        IAutoShape label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
        label.getFillFormat().setFillType(FillType.NoFill);
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame frame = label.addTextFrame("");
        frame.getTextFrameFormat().setTextVerticalType(TextVerticalType.EastAsianVertical);

        IParagraph paragraph = frame.getParagraphs().get_Item(0);
        IPortionFormat format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        FontData font = new FontData("MS Gothic");
        format.setLatinFont(font);
        format.setEastAsianFont(font);
        format.setFontHeight(40);
        format.getFillFormat().setFillType(FillType.Solid);
        format.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        Portion digits = new Portion("12");
        digits.getPortionFormat().setKumimoji(kumimoji);
        
        paragraph.getPortions().clear();
        paragraph.getPortions().add(new Portion("令和"));
        paragraph.getPortions().add(digits);
        paragraph.getPortions().add(new Portion("年"));

        x += 240;
    }
    presentation.save("vertical_date.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

In PowerPoint, l’etichetta sinistra (`True`) mostra le cifre in posizione verticale e affiancata tra 和 e 年. Nell’etichetta destra (`False`), la coppia è ruotata di 90 gradi in senso orario. I caratteri giapponesi circostanti rimangono verticali in entrambe le etichette.

![Confronto PowerPoint di etichette di data verticali con cifre verticali a sinistra e cifre ruotate a destra.](vertical_date.png)

## **Impostare una rotazione personalizzata per i riquadri di testo**

Usa [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) per impostare un angolo di rotazione personalizzato per un [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/).

L’esempio di codice qui sotto ruota il riquadro di testo di 3 gradi in senso orario all’interno della forma:

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

## **Impostare l’interlinea dei paragrafi**

Aspose.Slides fornisce [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) e [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) per controllare la spaziatura dei paragrafi. Queste proprietà si usano così:

* Usa un valore positivo per specificare l’interlinea come percentuale dell’altezza della riga.
* Usa un valore negativo per specificare l’interlinea in punti.

Il seguente esempio imposta la spaziatura interna del primo paragrafo al 200 % dell’altezza della riga (interlinea doppia):

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

![L’interlinea all’interno del paragrafo](line_spacing.png)

## **Controllare l’interruzione di riga**

Le regole di interruzione di riga dei paragrafi sono utili in blocchi di testo stretti e presentazioni che mescolano testo latino e asiatico orientale. I seguenti metodi appartengono a [IParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/), quindi si applicano all’intero paragrafo:

- [setLatinLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) controlla le regole di interruzione per il latino. In testo misto, modificarlo può anche cambiare dove il testo e la punteggiatura asiatica orientale adiacenti vanno a capo.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) controlla le regole di interruzione per l’asiatico orientale, incluse le restrizioni sui caratteri all’inizio e alla fine di una riga.

Queste regole non sostituiscono [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-), che abilita il ritorno a capo automatico all’interno di un riquadro di testo. Influenzano il layout quando avviene il ritorno a capo; non inseriscono caratteri di interruzione di riga. Un’interruzione di riga esplicita forza una nuova riga all’interno del paragrafo indipendentemente dalla larghezza disponibile.

Il seguente esempio autonomo crea un blocco di testo stretto contenente testo cinese e latino. Imposta entrambe le opzioni di interruzione di riga esplicitamente e salva “line_breaking.pptx”. Per sperimentare una delle regole, modifica il valore corrispondente mantenendo l’altra impostazione invariata. L’esempio usa Arial 24 punti e SimSun con una larghezza del riquadro di 160 punti e margini orizzontali del riquadro di testo pari a zero. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) è chiamato con [TextAutofitType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textautofittype/) così le dimensioni del testo e del riquadro rimangono fisse.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    FontData eastAsianFont = new FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setLatinLineBreak(NullableBool.False);
    format.setEastAsianLineBreak(NullableBool.True);

    presentation.save("line_breaking.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controllare la punteggiatura sospesa**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) consente ai segni di punteggiatura idonei di estendersi oltre il bordo destro della riga di testo invece di occupare la riga successiva. Si applica all’intero paragrafo ed è diversa da un rientro sospeso.

Il seguente esempio autonomo abilita la punteggiatura sospesa in un riquadro di testo largo 100 punti e salva “hanging_punctuation.pptx”. Con Arial 24 punti e margini orizzontali del riquadro pari a zero, il punto finale rimane dopo “sentence” e si estende oltre il bordo destro del testo. Imposta la proprietà su [NullableBool.False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) per confrontare: con queste impostazioni, il punto occupa una riga separata. Il ritorno a capo è abilitato e l’adattamento automatico è disabilitato per mantenere la larghezza disponibile fissa.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setHangingPunctuation(NullableBool.True);

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Non tutti i segni di punteggiatura possono sospendersi. Le [condizioni di carattere e layout descritte sopra](#control-line-breaking) si applicano anche a questo confronto: modificare il carattere, la larghezza disponibile, i margini o le impostazioni di adattamento automatico può eliminare la differenza visibile.

## **Impostare il tipo di adattamento automatico per i riquadri di testo**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) determina come il testo si comporta quando supera i confini del suo contenitore. Usalo per controllare se il testo si riduce, trabocca o ridimensiona automaticamente la forma. Il seguente esempio configura la forma per ridimensionarsi in modo da adattare il testo e salva il risultato in “autofit_type.pptx”.

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

Per contare le righe dopo il ritorno a capo automatico e vedere come la larghezza del testo o della forma cambia il risultato, vedere [Count Rendered Lines](/slides/it/java/manage-paragraph/). Il numero di righe da solo non indica se il testo trabocca dal contenitore.

## **Impostare l’ancora dei riquadri di testo**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) definisce come il testo è posizionato verticalmente all’interno di una forma, ad es. in alto, al centro o in basso. Il seguente esempio ancora il testo in basso della prima forma e salva il risultato in “text_anchor.pptx”.

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

Usa [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) e [IParagraphFormat.getTabs](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getTabs--) per configurare le tabulazioni in un paragrafo. Il seguente esempio imposta l’intervallo di tabulazione predefinito a 100 punti e aggiunge una tabulazione allineata a sinistra a 30 punti. Queste impostazioni influenzano il testo contenente caratteri di tabulazione.

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

Aspose.Slides fornisce [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), che consente di impostare la lingua di correzione per una porzione di testo. La lingua di correzione determina la lingua usata per i controlli ortografici e grammaticali in PowerPoint.

Il seguente esempio richiede “presentation.pptx” con una casella di testo come prima forma sulla prima diapositiva e almeno un paragrafo. Sostituisce il contenuto del primo paragrafo con “1。”, imposta SimSun come carattere e assegna la lingua di correzione cinese semplificata (`zh-CN`). Salva il risultato in “proofing_language.pptx”:

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

### **Copiare i metadati della lingua**

Quando si copia testo multilingue da un modello, conservare sia [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getLanguageId--) sia [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--). Il seguente esempio autonomo crea una porzione di origine con l’inglese statunitense come lingua e il francese come lingua alternativa e copia il testo e gli identificatori in una porzione di una nuova presentazione.

```java
import com.aspose.slides.*;

Portion source = new Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion destination = new Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // Se la sorgente non ha una lingua alternativa, null cancella il valore della destinazione.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per provare una sorgente senza lingua alternativa, ometti l’assegnazione di `"fr-FR"`. L’identificatore alternativo sarà quindi `null` e la stessa istruzione di copia preserva la sua assenza senza introdurre un valore predefinito, anche se la destinazione aveva precedentemente una lingua alternativa assegnata.

Questi identificatori sono metadati della lingua. Preservarli non stabilisce quale dizionario PowerPoint seleziona per i controlli ortografici o grammaticali.

## **Impostare la lingua predefinita**

Usa [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) per definire la lingua predefinita per il testo creato durante il caricamento o la creazione di una presentazione. Il seguente esempio crea una presentazione con l’inglese statunitense come lingua predefinita del testo, aggiunge una casella di testo e stampa `en-US` per la sua prima porzione di testo.

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

Per applicare la formattazione di testo predefinita a livello di presentazione, usa [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Il seguente esempio imposta un carattere in grassetto a 14 punti come predefinito per i paragrafi di livello superiore in una nuova presentazione e lo salva in “default_text_style.pptx”. Il testo può ereditare questi valori predefiniti a meno che una formattazione più specifica non li sovrascriva.

```java
import com.aspose.slides.*;

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

## **Estrarre il testo con l’effetto tutto maiuscolo**

In PowerPoint, l’applicazione dell’effetto carattere **All Caps** fa apparire il testo in maiuscolo nella diapositiva anche quando è stato digitato originariamente in minuscolo. Quando si recupera una porzione di testo con Aspose.Slides, la libreria restituisce il testo esattamente come inserito. Per corrispondere al testo visualizzato, verifica [TextCapType](https://reference.aspose.com/slides/java/com.aspose.slides/textcaptype/) e converti la stringa restituita in maiuscolo quando il valore è `All`.

Questo esempio richiede “sample2.pptx” con una casella di testo come prima forma sulla prima diapositiva. Il suo primo paragrafo contiene “Hello, Aspose!” nella prima porzione con l’effetto All Caps applicato, come mostrato di seguito.

![L’effetto All Caps](all_caps_effect.png)

Il codice di esempio qui sotto mostra come estrarre il testo con l’effetto **All Caps** applicato:

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

Per modificare il testo in una tabella su una diapositiva, usa [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/). Itera le celle e aggiorna ciascuna cella tramite [ICell.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) e la formattazione del paragrafo tramite [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Come applicare un colore sfumato al testo su una diapositiva PowerPoint?**

Per applicare un colore sfumato al testo, usa [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Imposta [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) su [FillType.Gradient](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) e configura le fermate del gradiente, la direzione e la trasparenza.

Funzionalità correlata: [Formattare il testo all’interno delle diapositive](/slides/it/features/text-formatting/).