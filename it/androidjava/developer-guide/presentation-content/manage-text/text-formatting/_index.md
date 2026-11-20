---
title: Formattare il testo della presentazione su Android
linktitle: Formattazione del testo
type: docs
weight: 50
url: /it/androidjava/text-formatting/
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
- Android
- Java
- Aspose.Slides
description: "Formattare e stilizzare il testo in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Android tramite Java. Personalizza caratteri, colori, allineamento e altro."
---
## **Panoramica**

Questo articolo mostra come formattare il testo nelle presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Android tramite Java. Copre colori di sfondo, trasparenza, spaziatura dei caratteri, proprietà dei caratteri, rotazione, spaziatura dei paragrafi, comportamento di adattamento automatico, ancoraggio del testo, tabulazioni e impostazioni della lingua.

Salvo indicazione contraria, gli esempi utilizzano [sample.pptx](sample.pptx). La prima forma nella sua prima diapositiva è una casella di testo e il suo primo paragrafo contiene il testo mostrato di seguito. Sia gli indici delle diapositive che delle forme sono basati su zero. Gli esempi che selezionano porzioni in grassetto usano la formattazione effettiva, compresa la formattazione in grassetto ereditata:

![Testo di esempio](sample_text.png)

Per trovare e evidenziare testo letterale o corrispondenze di espressioni regolari, vedere [Cerca e sostituisci testo](/slides/it/androidjava/search-and-replace-text/).

## **Imposta colore di sfondo del testo**

Utilizza [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) per impostare il colore di evidenziazione predefinito per un paragrafo, oppure utilizza [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) per singole porzioni di testo.

L'esempio seguente imposta un'evidenziazione grigio chiaro come predefinita per il primo paragrafo. I colori di evidenziazione espliciti sulle singole porzioni hanno la precedenza su questa impostazione predefinita:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

L'esempio di codice seguente mostra come impostare il colore di sfondo per **porzioni di testo con carattere in grassetto**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
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

Utilizza [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) per impostare l'allineamento del paragrafo all'interno di un riquadro di testo. Il valore può essere centrato, allineato a sinistra, allineato a destra, giustificato, ecc.

L'esempio di codice seguente mostra come allineare il paragrafo al **centro**:

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

## **Allinea i caratteri all'interno di una riga**

Utilizza [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) per allineare verticalmente le porzioni di testo di diverse dimensioni di carattere all'interno di una riga. Questa impostazione si applica a tutto il paragrafo e controlla l'allineamento all'interno di ciascuna delle sue righe.

L'esempio autonomo seguente crea quattro caselle di testo etichettate su una diapositiva. Ogni paragrafo contiene lo stesso testo a 18, 36 e 54 punti, con un diverso allineamento del carattere. Utilizza Arial, disabilita l'adattamento automatico e l'andare a capo, e mantiene i riquadri di testo sufficientemente grandi per una singola riga.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![Confronto di allineamento baseline, alto, centro e basso con dimensioni di carattere miste](font_alignment.png)

L'allineamento del carattere utilizza le metriche dei caratteri, quindi i bordi visibili delle singole lettere non sono necessariamente allineati esattamente. L'esempio include sia una lettera maiuscola sia un discendente per aiutare a mostrare la differenza tra allineamento baseline e bottom. La disponibilità e la sostituzione dei caratteri, i caratteri usati e la differenza nelle dimensioni dei caratteri influenzano il risultato. Le dimensioni del riquadro, i margini, l'interlinea, l'andare a capo e l'adattamento automatico influenzano anche il layout; utilizzare gli stessi caratteri e impostazioni di layout quando si confrontano le modalità.

Questa impostazione differisce da [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-), che controlla l'allineamento orizzontale del paragrafo, e da [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-), che posiziona il blocco di testo verticalmente all'interno della forma. La formattazione apice e pedice tramite [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setEscapement-float-) sposta le singole porzioni rispetto alla baseline invece di impostare l'allineamento del carattere per le righe del paragrafo.

## **Imposta trasparenza per il testo**

La trasparenza del testo è controllata tramite il componente alfa del colore assegnato a [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). Negli esempi seguenti, `alpha = 50` è un valore del canale alfa ARGB nella scala 0–255, non una percentuale di trasparenza.

L'esempio di codice seguente mostra come applicare la trasparenza a **l'intero paragrafo**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Il seguente esempio di codice mostra come applicare la trasparenza a **porzioni di testo con carattere in grassetto**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Utilizza [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) per espandere o comprimere la spaziatura tra i caratteri in una casella di testo. Gli esempi aggiungono 3 punti di spaziatura; i valori negativi comprimono il testo.

Il seguente codice Java mostra come espandere la spaziatura dei caratteri nell'**intero paragrafo**:

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

L'esempio di codice seguente mostra come espandere la spaziatura dei caratteri in **porzioni di testo con carattere in grassetto**:

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

### **Disabilita il kerning per caratteri specifici**

In alcuni casi, il testo renderizzato da Aspose.Slides può apparire leggermente più stretto rispetto allo stesso testo visualizzato in PowerPoint. Ciò può accadere perché PowerPoint può ignorare i dati di kerning per alcuni font, anche quando il font contiene informazioni di kerning valide e il kerning è abilitato nelle impostazioni di PowerPoint.

Per rendere l'output renderizzato più vicino a PowerPoint in tali casi, è possibile disabilitare il kerning per le porzioni di testo che utilizzano il font interessato. Imposta [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) a un valore maggiore della dimensione reale del font. Questo esempio richiede "presentation.pptx" con una casella di testo come prima forma nella prima diapositiva. Controlla i nomi dei font effettivi, inclusi i font ereditati, e imposta una soglia di 100 punti per le porzioni che utilizzano Roboto. Questo disabilita il kerning per le porzioni corrispondenti con una dimensione del font inferiore a 100 punti:

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

Per il testo corrispondente al di sotto della soglia, questa impostazione impedisce il kerning e può aiutare ad allineare il rendering di Aspose.Slides con l'output visivo di PowerPoint per i font interessati da questo comportamento specifico di PowerPoint.

## **Gestisci proprietà del carattere del testo**

Le proprietà del carattere possono essere impostate a livello di paragrafo tramite [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) o su singole porzioni tramite [IPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/).

L'esempio seguente imposta il carattere predefinito del primo paragrafo a Times New Roman 12 punti con formattazione grassetto, corsivo e sottolineatura puntinata. La formattazione esplicita su singole porzioni ha la precedenza su questi valori predefiniti:

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

L'esempio seguente applica Times New Roman 13 punti, formattazione corsiva e una sottolineatura puntinata a porzioni la cui formattazione effettiva è in grassetto:

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

## **Controlla normalizzazione altezza del testo**

Utilizza [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) quando si riproduce la tipografia del modello o si indagano le differenze nell'altezza dei caratteri. In PowerPoint, abilitare la normalizzazione allunga o comprime verticalmente i singoli caratteri per dare loro un'altezza visibile uniforme all'interno della porzione di testo. Non garantisce altezze del testo uguali tra font diversi.

Imposta la proprietà a [NullableBool.True or False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) per abilitare o disabilitare esplicitamente la normalizzazione. `NullableBool.NotDefined` lascia l'impostazione locale non impostata così che la porzione erediti il valore, ad esempio dal [getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) del paragrafo. Non equivale a `False`. Usa [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) e leggi [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) per ottenere il valore booleano risolto.

L'esempio autonomo seguente richiede che **Arial** sia installato. Crea due blocchi di testo contenenti le stesse lettere maiuscole, minuscole, discendenti e caratteri accentati a 54 punti. Entrambi i paragrafi abilitano la normalizzazione per impostazione predefinita. La porzione superiore la disabilita esplicitamente; la porzione inferiore la eredita. Le dimensioni del riquadro, i margini e la spaziatura dei paragrafi sono identici, con andare a capo e adattamento automatico disabilitati per mantenere coerente il confronto. L'esempio stampa `False: false` e `NotDefined: true`, quindi salva "text_height_normalization.pptx".

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Il confronto qui sotto è stato esportato dalla presentazione salvata. La riga superiore ha la normalizzazione disabilitata (`False`); la riga inferiore eredita l'impostazione abilitata (`NotDefined` → `True`). Mantieni Arial installato per riprodurre questa visuale.

![Testo Arial 54 punti con normalizzazione disabilitata sopra e normalizzazione ereditata abilitata sotto](text_height_normalization.png)

La normalizzazione modifica l'altezza dei caratteri senza cambiare il valore assegnato a [getFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--) , che specifica la dimensione del carattere in punti. Il [setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) del paragrafo controlla l'interlinea, mentre il [setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) del riquadro di testo controlla come il testo o il suo contenitore si adattano per adattarsi. Queste impostazioni hanno scopi diversi e possono influenzare il layout complessivo in modo indipendente. Per ulteriori informazioni sulla formattazione dei paragrafi e l'ereditarietà, vedere [Gestisci paragrafi](/slides/it/androidjava/manage-paragraph/).

## **Applica e rimuovi barrato**

Utilizza [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) su una porzione di testo per visualizzare correzioni, termini annullati o prezzi precedenti senza eliminare il testo originale. Impostalo su [TextStrikethroughType.Single o Double](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/) per una o due linee barrate sul testo.

Per rimuovere il barrato, passa [TextStrikethroughType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#None). Questo disabilita esplicitamente l'effetto, anche se la formattazione circostante specifica il barrato. Al contrario, [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#NotDefined) lascia l'impostazione locale indefinita, consentendo alla porzione di ereditare la formattazione, ad esempio dal paragrafo. Non garantisce che il barrato venga rimosso. Usa [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) per leggere la formattazione risultante, incluse i valori ereditati.

L'esempio autonomo seguente crea tre confronti di prezzo. Cada paragrafo ha porzioni separate per l'etichetta, il prezzo precedente e il prezzo attuale, così solo il prezzo precedente è influenzato. La prima riga applica e poi rimuove il barrato; le altre righe mantengono il barrato singolo e doppio. Modificando questa impostazione si preserva il testo e le altre formattazioni, incluso il prezzo precedente in grassetto.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Il risultato, dall'alto al basso: nessun barrato, barrato singolo e barrato doppio.

![Prezzi precedenti senza barrato, con barrato singolo e con barrato doppio](strikethrough.png)

## **Imposta rotazione del testo**

Utilizza [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) per impostare un orientamento del testo predefinito all'interno di una forma.

L'esempio di codice seguente imposta l'orientamento del testo nella forma a [TextVerticalType.Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textverticaltype/), che ruota il testo **di 90 gradi in senso antiorario**:

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

## **Imposta rotazione personalizzata per i riquadri di testo**

Utilizza [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) per impostare un angolo di rotazione personalizzato per un [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/).

L'esempio di codice seguente ruota il riquadro di testo di 3 gradi in senso orario all'interno della forma:

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

## **Imposta interlinea dei paragrafi**

Aspose.Slides fornisce [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) e [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) per controllare la spaziatura dei paragrafi. Queste proprietà vengono usate come segue:

* Usa un valore positivo per specificare l'interlinea come percentuale dell'altezza della linea.
* Usa un valore negativo per specificare l'interlinea in punti.

L'esempio seguente imposta la spaziatura all'interno del primo paragrafo al 200% dell'altezza della linea (interlinea doppia):

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

![L'interlinea all'interno del paragrafo](line_spacing.png)

## **Controlla interruzione di riga**

Le regole di interruzione di riga del paragrafo sono utili in blocchi di testo stretti e presentazioni che mescolano testo latino e asiatico orientale. I seguenti metodi appartengono a [IParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/), quindi si applicano a un intero paragrafo:

- [setLatinLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) controlla le regole di interruzione di riga per il latino. In testo misto, cambiarlo può anche modificare dove il testo e la punteggiatura asiatica orientale adiacenti vanno a capo.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) controlla le regole di interruzione di riga per il asiatico orientale, comprese le restrizioni sui caratteri all'inizio e alla fine di una linea.

Queste regole non sostituiscono [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-), che abilita l'andare a capo automatico all'interno di un riquadro di testo. Influenzano il layout quando avviene l'andare a capo; non inseriscono caratteri di interruzione di riga. Un'interruzione di riga esplicita forza una nuova riga all'interno del paragrafo indipendentemente dalla larghezza disponibile.

L'esempio autonomo seguente crea un blocco di testo stretto contenente testo cinese e latino. Imposta entrambe le opzioni di interruzione di riga esplicitamente e salva "line_breaking.pptx". Per sperimentare con ciascuna regola, cambia il valore corrispondente mantenendo fissi gli altri impostazioni. L'esempio utilizza Arial 24 punti e SimSun con una larghezza del riquadro di 160 punti e margini orizzontali del riquadro di testo pari a zero. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) è chiamato con [TextAutofitType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textautofittype/) in modo che la dimensione del testo e le dimensioni del riquadro rimangano fisse.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Controlla punteggiatura sospesa**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) consente alla punteggiatura idonea di estendersi oltre il bordo destro della linea di testo invece di occupare la riga successiva. Si applica a tutto il paragrafo ed è diverso da un rientro sospeso.

L'esempio autonomo seguente abilita la punteggiatura sospesa in un riquadro di testo largo 100 punti e salva "hanging_punctuation.pptx". Con Arial 24 punti e margini orizzontali del riquadro pari a zero, il punto finale rimane dopo "sentence" e si estende oltre il bordo destro del testo. Imposta la proprietà a [NullableBool.False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) per confrontare: con queste impostazioni, il punto occupa una riga separata. L'andare a capo è abilitato e l'adattamento automatico è disabilitato per mantenere fissa la larghezza disponibile.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Non tutti i segni di punteggiatura possono sospendersi. Le [condizioni di font e layout descritte sopra](#control-line-breaking) si applicano anche a questo confronto: modificare il font, la larghezza disponibile, i margini o le impostazioni di adattamento automatico può rimuovere la differenza visibile.

## **Imposta tipo di adattamento automatico per i riquadri di testo**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) determina come il testo si comporta quando supera i confini del contenitore. Usalo per controllare se il testo si riduce, trabocca o ridimensiona automaticamente la forma. L'esempio seguente configura la forma per ridimensionarsi per adattare il suo testo e salva il risultato in "autofit_type.pptx".

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

Per contare le linee dopo l'andare a capo automatico e vedere come la larghezza del testo o della forma cambia il risultato, vedere [Conta linee renderizzate](/slides/it/androidjava/manage-paragraph/). Il conteggio delle linee da solo non indica se il testo trabocca dal contenitore.

## **Imposta ancora dei riquadri di testo**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) definisce come il testo è posizionato verticalmente all'interno di una forma, ad esempio in alto, al centro o in basso. L'esempio seguente ancora il testo nella parte inferiore della prima forma e salva il risultato in "text_anchor.pptx".

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

## **Imposta tabulazione del testo**

Utilizza [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) e [IParagraphFormat.getTabs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) per configurare le tabulazioni in un paragrafo. L'esempio seguente imposta l'intervallo di tabulazione predefinito a 100 punti e aggiunge una tabulazione allineata a sinistra a 30 punti. Queste impostazioni influenzano il testo contenente caratteri di tabulazione.

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

## **Imposta lingua di controllo ortografico**

Aspose.Slides fornisce [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), che consente di impostare la lingua di controllo ortografico per una porzione di testo. La lingua di controllo determina la lingua usata per i controlli ortografici e grammaticali in PowerPoint.

L'esempio seguente richiede "presentation.pptx" con una casella di testo come prima forma nella prima diapositiva e almeno un paragrafo. Sostituisce il contenuto del primo paragrafo con "1。", imposta SimSun come suo font, e assegna la lingua di controllo cinese semplificata (`zh-CN`). Salva il risultato in "proofing_language.pptx":

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

### **Copia i metadati della lingua**

Quando si copia testo multilingue da un modello, conservare sia [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getLanguageId--) sia [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--). L'esempio autonomo seguente crea una porzione di origine con l'inglese statunitense come lingua e il francese come lingua alternativa e copia il testo e gli identificatori in una porzione di una nuova presentazione.

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
    // Se l'origine non ha una lingua alternativa, null cancella il valore di destinazione.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per provare una fonte senza lingua alternativa, ometti l'assegnazione di "fr-FR". L'identificatore alternativo sarà quindi `null`, e la stessa istruzione di copia ne preserva l'assenza senza introdurre un valore predefinito, anche se la destinazione aveva precedentemente una lingua alternativa assegnata.

Questi identificatori sono metadati della lingua. Preservarli non stabilisce quale dizionario PowerPoint selezioni per i controlli ortografici o grammaticali.

## **Imposta lingua predefinita**

Utilizza [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) per definire la lingua predefinita per il testo creato durante il caricamento o la creazione di una presentazione. L'esempio seguente crea una presentazione con l'inglese statunitense come lingua predefinita del testo, aggiunge una casella di testo e stampa `en-US` per la sua prima porzione di testo.

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

    // Controlla la lingua della prima porzione.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Imposta stile predefinito del testo**

Per applicare la formattazione testuale predefinita a livello di presentazione, utilizza [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

L'esempio seguente imposta un carattere in grassetto da 14 punti come predefinito per i paragrafi di primo livello in una nuova presentazione e lo salva in "default_text_style.pptx". Il testo può ereditare questi valori predefiniti a meno che una formattazione più specifica non li sovrascriva.

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

## **Estrai testo con effetto tutto maiuscolo**

In PowerPoint, l'applicazione dell'effetto **All Caps** al carattere fa apparire il testo in maiuscolo nella diapositiva anche se originariamente era digitato in minuscolo. Quando recuperi una tale porzione di testo con Aspose.Slides, la libreria restituisce il testo esattamente com'era stato inserito. Per corrispondere al testo visualizzato, controlla [TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/) e converte la stringa restituita in maiuscolo quando il valore è `All`.

Questo esempio richiede "sample2.pptx" con una casella di testo come prima forma nella prima diapositiva. La prima porzione del primo paragrafo contiene "Hello, Aspose!" con l'effetto All Caps applicato, come mostrato di seguito.

![L'effetto All Caps](all_caps_effect.png)

L'esempio di codice seguente mostra come estrarre il testo con l'effetto **All Caps** applicato:

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

**Come modifico il testo in una tabella su una diapositiva?**

Per modificare il testo in una tabella su una diapositiva, utilizza [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/). Itera attraverso le celle e aggiorna ciascuna cella tramite [ICell.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) e la formattazione del paragrafo tramite [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Come applico un colore sfumato al testo su una diapositiva PowerPoint?**

Per applicare un colore sfumato al testo, utilizza [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). Imposta [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) su [FillType.Gradient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) e configura le fermate del gradiente, la direzione e la trasparenza.