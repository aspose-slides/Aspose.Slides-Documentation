---
title: Formattare il testo della presentazione su Android
linktitle: Formattazione del testo
type: docs
weight: 50
url: /it/androidjava/text-formatting/
keywords:
- allineamento paragrafo
- stile del testo
- sfondo del testo
- trasparenza del testo
- spaziatura dei caratteri
- proprietà del font
- famiglia di font
- rotazione del testo
- angolo di rotazione
- riquadro di testo
- interlinea
- proprietà autofit
- ancora riquadro di testo
- tabulazione del testo
- lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Formattare e stilizzare il testo in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Android via Java. Personalizza font, colori, allineamento e altro."
---
## **Panoramica**

Questo articolo mostra come formattare il testo nelle presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Android tramite Java. Copre colori di sfondo, trasparenza, interspazio tra caratteri, proprietà dei font, rotazione, interlinea dei paragrafi, comportamento di autofit, ancoraggio del testo, tabulazioni e impostazioni della lingua.

Salvo diversa indicazione, gli esempi utilizzano [sample.pptx](sample.pptx). La prima forma nella sua prima diapositiva è una casella di testo e il suo primo paragrafo contiene il testo mostrato di seguito. Sia gli indici delle diapositive che delle forme partono da zero. Gli esempi che selezionano parti in grassetto usano la formattazione effettiva, inclusa la formattazione in grassetto ereditata:

![Sample text](sample_text.png)

Per trovare e evidenziare testo letterale o corrispondenze di espressioni regolari, vedere [Search and Replace Text](/slides/it/androidjava/search-and-replace-text/).

## **Impostare il colore di sfondo del testo**

Usa [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) per impostare il colore di evidenziazione predefinito per un paragrafo, o usa [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) per singole parti di testo.

L’esempio seguente imposta un evidenziatore grigio chiaro come predefinito per il primo paragrafo. I colori di evidenziazione espliciti sulle singole parti hanno la precedenza su questo valore predefinito:

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

![The gray paragraph](gray_paragraph.png)

Il codice seguente dimostra come impostare il colore di sfondo per **parti di testo con un font in grassetto**:

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
            // Imposta il colore di evidenziazione per la parte di testo.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![The gray text portions](gray_text_portions.png)

## **Allineare i paragrafi di testo**

Usa [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) per impostare l’allineamento del paragrafo all’interno di un riquadro di testo. Il valore può essere centrato, allineato a sinistra, allineato a destra, giustificato, ecc.

L’esempio seguente mostra come allineare il paragrafo al **centro**:

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

![The aligned paragraph](aligned_paragraph.png)

## **Allineare i font all’interno di una riga**

Usa [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) per allineare verticalmente le parti di testo con dimensioni di font diverse all’interno di una riga. Questa impostazione si applica all’intero paragrafo e controlla l’allineamento all’interno di ciascuna delle sue righe.

L’esempio autonomo seguente crea quattro caselle di testo etichettate in una diapositiva. Ogni paragrafo contiene lo stesso testo a 18, 36 e 54 punti, con un diverso allineamento del font. Usa Arial, disabilita autofit e word‑wrap e mantiene i riquadri di testo abbastanza grandi per una sola riga.

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

![Comparison of Baseline, Top, Center, and Bottom font alignment with mixed font sizes](font_alignment.png)

L’allineamento del font usa le metriche del font, quindi i bordi visibili delle singole lettere non coincidono necessariamente esattamente. L’esempio include sia una lettera maiuscola sia un discendente per mostrare la differenza tra allineamento alla linea di base e allineamento al fondo. La disponibilità e sostituzione del font, i caratteri usati e la differenza di dimensioni del font influenzano il risultato. Dimensioni del riquadro, margini, interlinea, word‑wrap e autofit influiscono anch’essi sul layout; usa gli stessi font e le stesse impostazioni di layout quando confronti le modalità.

Questa impostazione differisce da [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-), che controlla l’allineamento orizzontale del paragrafo, e da [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-), che posiziona verticalmente il blocco di testo all’interno della forma. La formattazione apice e pedice tramite [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setEscapement-float-) sposta le singole parti rispetto alla linea di base anziché impostare l’allineamento del font per le righe del paragrafo.

## **Impostare la trasparenza del testo**

La trasparenza del testo è controllata tramite il componente alfa del colore assegnato a [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). Negli esempi seguenti, `alpha = 50` è un valore alfa ARGB su scala 0–255, non una percentuale di trasparenza.

Il codice seguente mostra come applicare la trasparenza all’**intero paragrafo**:

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

![The transparent paragraph](transparent_paragraph.png)

Il codice seguente mostra come applicare la trasparenza alle **parti di testo con un font in grassetto**:

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
            // Imposta la trasparenza della parte di testo.
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

![The transparent text portions](transparent_text_portions.png)

## **Impostare l’interspazio tra caratteri del testo**

Usa [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) per espandere o comprimere la spaziatura tra i caratteri in una casella di testo. Gli esempi aggiungono 3 punti di spaziatura; i valori negativi comprimono il testo.

Il codice Java seguente mostra come espandere l’interspazio tra caratteri nell’**intero paragrafo**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Nota: usa valori negativi per comprimere la spaziatura dei caratteri.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Espandi la spaziatura dei caratteri.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

Il codice seguente mostra come espandere l’interspazio tra caratteri nelle **parti di testo con un font in grassetto**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Nota: usa valori negativi per comprimere la spaziatura dei caratteri.
            portion.getPortionFormat().setSpacing(3); // Espandi la spaziatura dei caratteri.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Disabilitare il kerning per font specifici**

In alcuni casi, il testo renderizzato da Aspose.Slides può apparire leggermente più stretto rispetto allo stesso testo visualizzato in PowerPoint. Ciò può accadere perché PowerPoint può ignorare i dati di kerning per determinati font, anche quando il font contiene informazioni di kerning valide e il kerning è abilitato nelle impostazioni di PowerPoint.

Per avvicinare il risultato renderizzato a PowerPoint in tali casi, è possibile disabilitare il kerning per le parti di testo che usano il font interessato. Imposta [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) a un valore superiore alla dimensione effettiva del font. Questo esempio richiede “presentation.pptx” con una casella di testo come prima forma nella prima diapositiva. Controlla i nomi dei font effettivi, inclusi i font ereditati, e imposta una soglia di 100 punti per le parti che usano Roboto. Questo disabilita il kerning per le parti corrispondenti con una dimensione del font inferiore a 100 punti:

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

Per il testo corrispondente sotto la soglia, questa impostazione impedisce il kerning e può aiutare ad allineare il rendering di Aspose.Slides all’output visivo di PowerPoint per i font soggetti a questo comportamento specifico di PowerPoint.

## **Gestire le proprietà del font del testo**

Le proprietà del font possono essere impostate a livello di paragrafo tramite [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) o su singole parti tramite [IPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/).

L’esempio seguente imposta il font predefinito del primo paragrafo a Times New Roman 12 pt con grassetto, corsivo e sottolineatura puntinata. La formattazione esplicita su singole parti ha la precedenza su questi valori predefiniti.

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

![The font properties for the paragraph](font_properties_for_paragraph.png)

L’esempio seguente applica Times New Roman 13 pt, formattazione corsiva e sottolineatura puntinata alle parti la cui formattazione effettiva è in grassetto:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Imposta le proprietà del font per la parte di testo.
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

![The font properties for text portions](font_properties_for_text_portions.png)

## **Controllare la normalizzazione dell’altezza del testo**

Usa [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) quando si riproduce la tipografia di un modello o si investigano differenze nell’altezza dei caratteri. In PowerPoint, l’attivazione della normalizzazione allunga o comprime verticalmente i caratteri individuali per dare loro un’altezza visibile uniforme all’interno della parte di testo. Non garantisce altezze di testo uguali tra font diversi.

Imposta la proprietà su [NullableBool.True or False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) per abilitare o disabilitare esplicitamente la normalizzazione. `NullableBool.NotDefined` lascia l’impostazione locale non impostata così che la parte la erediti, ad esempio dal [getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) del paragrafo. Non equivale a `False`. Usa [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) e leggi [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) per ottenere il valore Boolean risolto.

L’esempio autonomo seguente richiede **Arial** installato. Crea due blocchi di testo contenenti le stesse lettere maiuscole, minuscole, discendenti e caratteri accentati a 54 pt. Entrambi i paragrafi abilitano la normalizzazione per impostazione predefinita. La parte superiore la disabilita esplicitamente; la parte inferiore la eredita. Le dimensioni dei riquadri, i margini e l’interlinea dei paragrafi sono identici, con word‑wrap e autofit disabilitati per mantenere il confronto coerente. L’esempio stampa `False: false` e `NotDefined: true`, quindi salva “text_height_normalization.pptx”.

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

Il confronto sotto è stato esportato dalla presentazione salvata. La riga superiore ha la normalizzazione disabilitata (`False`); la riga inferiore la eredita (`NotDefined` → `True`). Mantieni Arial installato per riprodurre questo aspetto.

![Arial 54-point text with normalization disabled above and inherited normalization enabled below](text_height_normalization.png)

La normalizzazione modifica l’altezza dei caratteri senza cambiare il valore assegnato a [getFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--), che specifica la dimensione del font in punti. [setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) del paragrafo controlla l’interlinea, mentre [setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) del riquadro di testo controlla come il testo o il suo contenitore si adattano. Queste impostazioni servono a scopi diversi e possono influenzare il layout complessivo in modo indipendente. Per maggiori informazioni sulla formattazione dei paragrafi e sull’ereditarietà, vedere [Manage Paragraph](/slides/it/androidjava/manage-paragraph/).

## **Applicare e rimuovere il barrato**

Usa [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) su una parte di testo per visualizzare correzioni, termini annullati o prezzi precedenti senza eliminare il testo originale. Impostalo su [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/) per una o due linee barrate.

Per rimuovere il barrato, passa [TextStrikethroughType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#None). Questo disabilita esplicitamente l’effetto, anche se la formattazione circostante prevede il barrato. Al contrario, [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#NotDefined) lascia l’impostazione locale non definita, consentendo alla parte di ereditare la formattazione, ad esempio dal paragrafo. Non garantisce che il barrato venga rimosso. Usa [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) per leggere la formattazione risultante, inclusi i valori ereditati.

L’esempio autonomo seguente crea tre confronti di prezzo. Ogni paragrafo ha parti separate per l’etichetta, il prezzo precedente e quello attuale, quindi solo il prezzo precedente è interessato. La prima riga applica e poi rimuove il barrato; le altre righe mantengono rispettivamente il barrato singolo e doppio. Cambiare questa impostazione preserva il testo e la sua altra formattazione, incluso il prezzo precedente in grassetto.

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

Il risultato, dall’alto verso il basso: nessun barrato, barrato singolo e barrato doppio.

![Previous prices without strikethrough, with single strikethrough, and with double strikethrough](strikethrough.png)

## **Impostare la rotazione del testo**

Usa [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) per impostare un orientamento predefinito del testo all’interno di una forma.

L’esempio seguente imposta l’orientamento del testo nella forma su [TextVerticalType.Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textverticaltype/), che ruota il testo **di 90 gradi in senso antiorario**:

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

![The text rotation](text_rotation.png)

## **Visualizzare le cifre affiancate in testo verticale**

Per mantenere insieme le due cifre di un numero in un’etichetta giapponese verticale, inserisci entrambe le cifre in un’unica parte di testo e chiama [IBasePortionFormat.setKumimoji](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setKumimoji-byte-) su quella parte. L’esempio usa [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textverticaltype/#EastAsianVertical) e MS Gothic 40 pt per entrambe le etichette. Solo il valore [NullableBool](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) passato alla parte numerica differisce.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

In PowerPoint, l’etichetta sinistra (`True`) mostra le cifre in piedi e affiancate tra 和 e 年. Nell’etichetta destra (`False`), la coppia è ruotata di 90 gradi in senso orario. I caratteri giapponesi circostanti rimangono verticali in entrambe le etichette.

![PowerPoint comparison of vertical date labels with upright digits on the left and rotated digits on the right.](vertical_date.png)

## **Impostare una rotazione personalizzata per i riquadri di testo**

Usa [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) per impostare un angolo di rotazione personalizzato per un [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/).

Il codice seguente ruota il riquadro di testo di 3 gradi in senso orario all’interno della forma:

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

![The custom text rotation](custom_text_rotation.png)

## **Impostare l’interlinea dei paragrafi**

Aspose.Slides fornisce [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) e [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) per controllare lo spazio dei paragrafi. Queste proprietà si usano così:

* Usa un valore positivo per specificare l’interlinea come percentuale dell’altezza della linea.
* Usa un valore negativo per specificare l’interlinea in punti.

L’esempio seguente imposta lo spazio interno al primo paragrafo al 200 % dell’altezza della linea (doppio interlinea):

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

![The line spacing within the paragraph](line_spacing.png)

## **Controllare l’interruzione di riga**

Le regole di interruzione di riga del paragrafo sono utili in blocchi di testo stretti e in presentazioni che mescolano testo latino e asiatico orientale. I metodi seguenti appartengono a [IParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/), quindi si applicano all’intero paragrafo:

- [setLatinLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) controlla le regole di interruzione per il testo latino. In testo misto, modificarlo può cambiare anche il punto di interruzione del testo e della punteggiatura asiatica orientale adiacenti.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) controlla le regole di interruzione per il testo asiatico orientale, comprese le restrizioni sui caratteri all’inizio e alla fine di una riga.

Queste regole non sostituiscono [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-), che abilita il word‑wrap automatico all’interno di un riquadro di testo. Influenzano il layout quando il wrap avviene; non inseriscono caratteri di interruzione di riga. Un’interruzione di riga esplicita fornisce una nuova riga nel paragrafo indipendentemente dalla larghezza disponibile.

L’esempio autonomo seguente crea un blocco di testo stretto contenente cinese e latino. Imposta esplicitamente entrambe le opzioni di interruzione e salva “line_breaking.pptx”. Per sperimentare con una delle regole, cambia il valore corrispondente mantenendo l’altra impostazione invariata. L’esempio usa Arial 24 pt e SimSun con larghezza del riquadro di 160 pt e margini orizzontali del riquadro di testo pari a zero. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) è chiamato con [TextAutofitType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textautofittype/) affinché la dimensione del testo e le dimensioni del riquadro rimangano fisse.

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

## **Controllare la punteggiatura sospesa**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) consente alla punteggiatura eleggibile di estendersi oltre il bordo destro della linea di testo anziché occupare la riga successiva. Si applica all’intero paragrafo ed è diversa da un rientro sospeso.

L’esempio autonomo seguente abilita la punteggiatura sospesa in un riquadro di testo largo 100 pt e salva “hanging_punctuation.pptx”. Con Arial 24 pt e margini orizzontali del riquadro pari a zero, il punto finale rimane dopo “sentence” e si estende oltre il bordo destro del testo. Imposta la proprietà su [NullableBool.False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) per confrontare: con queste impostazioni, il punto occupa una riga separata. Il wrap è abilitato e l’autofit disabilitato per mantenere la larghezza disponibile fissa.

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

Non tutti i segni di punteggiatura possono sospendersi. Le [condizioni di font e layout descritte sopra](#control-line-breaking) si applicano anche a questo confronto: modificare il font, la larghezza disponibile, i margini o le impostazioni di autofit può eliminare la differenza visibile.

## **Impostare il tipo di autofit per i riquadri di testo**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) determina come il testo si comporta quando supera i confini del suo contenitore. Usalo per controllare se il testo si riduce, trabocca o ridimensiona automaticamente la forma. L’esempio seguente configura la forma per ridimensionarsi in modo da adattarsi al testo e salva il risultato in “autofit_type.pptx”.

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

Per contare le linee dopo il wrap automatico e vedere come la larghezza del testo o della forma cambia il risultato, vedere [Count Rendered Lines](/slides/it/androidjava/manage-paragraph/). Il solo conteggio delle linee non indica se il testo trabocca dal contenitore.

## **Impostare l’ancora dei riquadri di testo**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) definisce come il testo è posizionato verticalmente all’interno di una forma, ad esempio in alto, al centro o in basso. L’esempio seguente ancora il testo al fondo della prima forma e salva il risultato in “text_anchor.pptx”.

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

Usa [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) e [IParagraphFormat.getTabs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) per configurare le tabulazioni in un paragrafo. L’esempio seguente imposta l’intervallo di tabulazione predefinito a 100 punti e aggiunge una tabulazione allineata a sinistra a 30 punti. Queste impostazioni influenzano il testo contenente caratteri di tabulazione.

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

![The paragraph tabs](paragraph_tabs.png)

## **Impostare la lingua di correzione**

Aspose.Slides fornisce [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), che permette di impostare la lingua di correzione per una parte di testo. La lingua di correzione determina la lingua usata per i controlli ortografici e grammaticali in PowerPoint.

L’esempio seguente richiede “presentation.pptx” con una casella di testo come prima forma nella prima diapositiva e almeno un paragrafo. Sostituisce il contenuto del primo paragrafo con “1。”, imposta SimSun come font e assegna la lingua di correzione Cinese semplificato (`zh-CN`). Salva il risultato in “proofing_language.pptx”:

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

    // Imposta l'ID di una lingua di correzione.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Copiare i metadati della lingua**

Quando si copia testo multilingue da un modello, conservare sia [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getLanguageId--) sia [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--). L’esempio autonomo seguente crea una parte sorgente con inglese americano come lingua e francese come lingua alternativa e copia il testo e gli identificatori in una parte di una nuova presentazione.

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

Per provare una sorgente senza lingua alternativa, ometti l’assegnazione di `"fr-FR"`. L’identificatore alternativo sarà allora `null` e la stessa istruzione di copia ne preserva l’assenza senza introdurre un valore predefinito, anche se la destinazione aveva precedentemente una lingua alternativa assegnata.

Questi identificatori sono metadati linguistici. Preservarli non stabilisce quale dizionario PowerPoint selezioni per i controlli ortografici o grammaticali.

## **Impostare la lingua predefinita**

Usa [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) per definire la lingua predefinita per il testo creato durante il caricamento o la creazione di una presentazione. L’esempio seguente crea una presentazione con l’inglese americano come lingua di testo predefinita, aggiunge una casella di testo e stampa `en-US` per la sua prima parte di testo.

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

Per applicare la formattazione di testo predefinita a livello di presentazione, usa [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

L’esempio seguente imposta un font grassetto da 14 pt come predefinito per i paragrafi di primo livello in una nuova presentazione e lo salva in “default_text_style.pptx”. Il testo può ereditare questi valori predefiniti a meno che una formattazione più specifica non li sovrascriva.

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

## **Estrarre il testo con l’effetto Maiuscoletto**

In PowerPoint, l’applicazione dell’effetto **Maiuscoletto** fa apparire il testo in maiuscolo nella diapositiva anche se originariamente è stato digitato in minuscolo. Quando recuperi una parte di testo con Aspose.Slides, la libreria ritorna il testo esattamente come inserito. Per corrispondere al testo visualizzato, verifica [TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/) e converte la stringa restituita in maiuscolo quando il valore è `All`.

Questo esempio richiede “sample2.pptx” con una casella di testo come prima forma nella prima diapositiva. La sua prima parte del primo paragrafo contiene “Hello, Aspose!” con l’effetto Maiuscoletto applicato, come mostrato di seguito.

![The All Caps effect](all_caps_effect.png)

Il codice seguente mostra come estrarre il testo con l’effetto **Maiuscoletto** applicato:

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

Per modificare il testo in una tabella su una diapositiva, usa [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/). Scorri le celle e aggiorna ciascuna cella tramite [ICell.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) e la formattazione dei paragrafi tramite [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Come applico un colore gradiente al testo su una diapositiva PowerPoint?**

Per applicare un colore gradiente al testo, usa [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). Imposta [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) su [FillType.Gradient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) e configura le fermate del gradiente, la direzione e la trasparenza.