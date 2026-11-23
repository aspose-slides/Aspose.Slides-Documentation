---
title: Formattare il testo della presentazione in Python tramite Java
linktitle: Formattazione del testo
type: docs
weight: 50
url: /it/python-java/text-formatting/
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
- ancora del riquadro di testo
- tabulazione del testo
- lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Formatta e stila il testo in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Python tramite Java. Personalizza font, colori, allineamento e altro."
---
## **Panoramica**

Questo articolo mostra come formattare il testo in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Python tramite Java. Tratta i colori di sfondo, la trasparenza, la spaziatura dei caratteri, le proprietà del font, la rotazione, la spaziatura dei paragrafi, il comportamento di autofit, l’ancoraggio del testo, le tabulazioni e le impostazioni della lingua.

Salvo indicazione diversa, gli esempi usano [sample.pptx](sample.pptx). La prima forma nella sua prima diapositiva è una casella di testo e il suo primo paragrafo contiene il testo mostrato di seguito. Sia gli indici delle diapositive che delle forme sono basati su zero. Gli esempi che selezionano porzioni in grassetto usano la formattazione effettiva, inclusa la formattazione ereditata in grassetto:

![Testo di esempio](sample_text.png)

Per trovare e evidenziare testo letterale o corrispondenze di espressioni regolari, vedere [Search and Replace Text](/slides/it/python-java/search-and-replace-text/).

## **Imposta colore di sfondo del testo**

Usa [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) per impostare il colore di evidenziazione predefinito per un paragrafo, oppure usa [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getHighlightColor) per porzioni di testo individuali.

L’esempio seguente imposta un’evidenziazione grigio chiaro come predefinita per il primo paragrafo. I colori di evidenziazione espliciti sulle singole porzioni hanno precedenza su questa impostazione predefinita:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Imposta il colore di evidenziazione per l'intero paragrafo.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Il paragrafo grigio](gray_paragraph.png)

Il codice di esempio qui sotto dimostra come impostare il colore di sfondo per **porzioni di testo con un carattere in grassetto**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Imposta il colore di evidenziazione per la porzione di testo.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Le porzioni di testo grigio](gray_text_portions.png)

## **Allinea i paragrafi di testo**

Usa [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) per impostare l’allineamento del paragrafo all’interno di un riquadro di testo. Il valore può essere centrato, allineato a sinistra, allineato a destra, giustificato, ecc.

Il codice di esempio seguente mostra come allineare il paragrafo al **centro**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Imposta l'allineamento del paragrafo al centro.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Il paragrafo allineato](aligned_paragraph.png)

## **Allinea i caratteri all’interno di una linea**

Usa [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setFontAlignment) per allineare verticalmente le porzioni di testo di dimensioni di carattere diverse all’interno di una linea. Questa impostazione si applica all’intero paragrafo e controlla l’allineamento all’interno di ciascuna delle sue linee.

L’esempio auto‑contenuto qui sotto crea quattro caselle di testo etichettate su una diapositiva. Ogni paragrafo contiene lo stesso testo a 18, 36 e 54 punti, con un diverso allineamento del carattere. Usa Arial, disabilita autofit e wrapping e mantiene i riquadri di testo sufficientemente grandi per una singola riga.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontAlignment, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    alignments = [FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom]
    alignment_names = ["Baseline", "Top", "Center", "Bottom"]
    font_sizes = [18.0, 36.0, 54.0]
    font = FontData("Arial")

    for i, alignment in enumerate(alignments):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)

        label = text_frame.getParagraphs().get_Item(0)
        label.setText(alignment_names[i])
        label.getParagraphFormat().setAlignment(TextAlignment.Left)
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14)
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)

        paragraph = Paragraph()
        paragraph.getParagraphFormat().setFontAlignment(alignment)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        for font_size in font_sizes:
            portion = Portion("Ag ")
            portion.getPortionFormat().setFontHeight(font_size)
            paragraph.getPortions().add(portion)

        text_frame.getParagraphs().add(paragraph)

    presentation.save("font_alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Confronto di Baseline, Top, Center e Bottom per l’allineamento del carattere con dimensioni di font miste](font_alignment.png)

L’allineamento dei caratteri utilizza le metriche del font, quindi i bordi visibili delle singole lettere non si allineano necessariamente in modo esatto. L’esempio include sia una lettera maiuscola sia un discendente per evidenziare la differenza tra allineamento baseline e bottom. Disponibilità e sostituzione del font, i caratteri usati e la differenza di dimensioni del font influenzano il risultato. Anche le dimensioni del riquadro, i margini, l’interlinea, il wrapping e l’autofit influiscono sul layout; usare gli stessi font e le stesse impostazioni di layout per confrontare le modalità.

Questa impostazione differisce da [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment), che controlla l’allineamento orizzontale del paragrafo, e da [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType), che posizione verticalmente il blocco di testo all’interno della forma. La formattazione di apice e pedice tramite [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setEscapement) sposta le singole porzioni rispetto alla baseline invece di impostare l’allineamento del font per le linee del paragrafo.

## **Imposta trasparenza per il testo**

La trasparenza del testo è controllata tramite la componente alfa del colore assegnato a [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat). Negli esempi seguenti, `alpha = 50` è un valore alfa ARGB su scala 0–255, non una percentuale di trasparenza.

Il codice di esempio qui sotto mostra come applicare la trasparenza a **l’intero paragrafo**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Imposta il colore di riempimento del testo su colore trasparente.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Il paragrafo trasparente](transparent_paragraph.png)

Il codice di esempio seguente mostra come applicare la trasparenza a **porzioni di testo con un carattere in grassetto**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Imposta la trasparenza della porzione di testo.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Le porzioni di testo trasparenti](transparent_text_portions.png)

## **Imposta spaziatura dei caratteri per il testo**

Usa [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpacing) per aumentare o ridurre la spaziatura tra i caratteri in una casella di testo. Gli esempi aggiungono 3 punti di spaziatura; valori negativi comprimono il testo.

Il seguente codice Python mostra come espandere la spaziatura dei caratteri in **l’intero paragrafo**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Nota: Usa valori negativi per comprimere la spaziatura dei caratteri.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # Espandi la spaziatura dei caratteri.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![La spaziatura dei caratteri nel paragrafo](character_spacing_in_paragraph.png)

Il codice di esempio qui sotto mostra come espandere la spaziatura dei caratteri in **porzioni di testo con un carattere in grassetto**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Nota: Usa valori negativi per comprimere la spaziatura dei caratteri.
            portion.getPortionFormat().setSpacing(3) # Espandi la spaziatura dei caratteri.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![La spaziatura dei caratteri nelle porzioni di testo](character_spacing_in_text_portions.png)

### **Disabilita il kerning per font specifici**

In alcuni casi, il testo renderizzato da Aspose.Slides può apparire leggermente più stretto rispetto allo stesso testo visualizzato in PowerPoint. Ciò può verificarsi perché PowerPoint può ignorare i dati di kerning per determinati font, anche quando il font contiene informazioni di kerning valide e il kerning è attivato nelle impostazioni di PowerPoint.

Per avvicinare il rendering a PowerPoint in tali casi, è possibile disabilitare il kerning per le porzioni di testo che usano il font interessato. Imposta [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) a un valore superiore alla dimensione reale del font. Questo esempio richiede "presentation.pptx" con una casella di testo come prima forma nella prima diapositiva. Controlla i nomi dei font effettivi, inclusi i font ereditati, e imposta una soglia di 100 punti per le porzioni che usano Roboto. Questo disabilita il kerning per le porzioni corrispondenti con una dimensione del font inferiore a 100 punti:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    target_font = "Roboto"

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            portion_format = portion.getPortionFormat().getEffective()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion.getPortionFormat().setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Per il testo corrispondente al di sotto della soglia, questa impostazione impedisce il kerning e può aiutare ad allineare il rendering di Aspose.Slides a quello visuale di PowerPoint per i font influenzati da questo comportamento specifico di PowerPoint.

## **Gestisci le proprietà del font del testo**

Le proprietà del font possono essere impostate a livello di paragrafo tramite [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) o su singole porzioni tramite [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/).

L’esempio seguente imposta il font predefinito del primo paragrafo a Times New Roman 12 punti con grassetto, corsivo e sottolineatura puntinata. La formattazione esplicita su singole porzioni ha precedenza su questi valori predefiniti.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Imposta le proprietà del font per il paragrafo.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
    font = FontData("Times New Roman")
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Le proprietà del font per il paragrafo](font_properties_for_paragraph.png)

L’esempio seguente applica Times New Roman 13 punti, formattazione corsiva e sottolineatura puntinata alle porzioni il cui formato effettivo è in grassetto:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Imposta le proprietà del font per la porzione di testo.
            portion.getPortionFormat().setFontHeight(13)
            portion.getPortionFormat().setFontItalic(NullableBool.True_)
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
            font = FontData("Times New Roman")
            portion.getPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Le proprietà del font per le porzioni di testo](font_properties_for_text_portions.png)

## **Controlla la normalizzazione dell’altezza del testo**

Usa [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setNormaliseHeight) quando si riproduce la tipografia di un modello o si indagano differenze nell’altezza dei caratteri. In PowerPoint, l’attivazione della normalizzazione allunga o comprime verticalmente i singoli caratteri per dare loro un’altezza visibile uniforme all’interno della porzione di testo. Non garantisce altezze di testo uguali tra font diversi.

Imposta la proprietà su [NullableBool.True_ o False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) per abilitare o disabilitare esplicitamente la normalizzazione. `NullableBool.NotDefined` lascia l’impostazione locale non impostata in modo che la porzione erediti il valore, ad esempio dal [getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) del paragrafo. Non equivale a `False`. Usa [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) e leggi `getNormaliseHeight` sul formato effettivo restituito per ottenere il valore booleano risolto.

L’esempio auto‑contenuto qui sotto richiede **Arial** installato. Crea due blocchi di testo contenenti le stesse lettere maiuscole, minuscole, discendenti e caratteri accentati a 54 punti. Entrambi i paragrafi abilitano la normalizzazione per impostazione predefinita. La porzione superiore la disabilita esplicitamente; quella inferiore la eredita. Le dimensioni dei riquadri, i margini e la spaziatura dei paragrafi sono identici, con wrapping e autofit disabilitati per mantenere il confronto coerente. L’esempio stampa `False: False` e `NotDefined: True`, quindi salva "text_height_normalization.pptx".

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    settings = [NullableBool.False_, NullableBool.NotDefined]
    setting_names = ["False", "NotDefined"]

    for i, setting in enumerate(settings):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.setText("Hxgjpq ÅÉ 0123")
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setMarginTop(0)
        text_frame.getTextFrameFormat().setMarginLeft(0)

        paragraph = text_frame.getParagraphs().get_Item(0)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceBefore(0)
        paragraph.getParagraphFormat().setSpaceAfter(0)
        paragraph.getParagraphFormat().setSpaceWithin(100)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True_)

        portion = paragraph.getPortions().get_Item(0)
        font = FontData("Arial")
        portion.getPortionFormat().setLatinFont(font)
        portion.getPortionFormat().setFontHeight(54)
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        portion.getPortionFormat().setNormaliseHeight(setting)

        print(f"{setting_names[i]}: {bool(portion.getPortionFormat().getEffective().getNormaliseHeight())}")

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il confronto sotto è stato esportato dalla presentazione salvata. La riga superiore ha la normalizzazione disabilitata (`False`); la riga inferiore eredita l’impostazione abilitata (`NotDefined` → `True`). Conserva Arial installato per riprodurre quest’aspetto.

![Testo Arial a 54 punti con normalizzazione disabilitata sopra e normalizzazione ereditata abilitata sotto](text_height_normalization.png)

La normalizzazione modifica l’altezza dei caratteri senza cambiare il valore assegnato a [getFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFontHeight), che specifica la dimensione del font in punti. La funzione [setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) del paragrafo controlla l’interlinea, mentre [setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) del riquadro di testo controlla come il testo o il suo contenitore si adattano. Queste impostazioni hanno scopi diversi e possono influenzare il layout complessivo in modo indipendente. Per ulteriori informazioni sulla formattazione dei paragrafi e sull’eredità, vedere [Manage Paragraph](/slides/it/python-java/manage-paragraph/).

## **Applica e rimuovi il barrato**

Usa [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setStrikethroughType) su una porzione di testo per visualizzare correzioni, termini cancellati o prezzi precedenti senza eliminare il testo originale. Impostala su [TextStrikethroughType.Single o Double](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/) per una o due linee attraverso il testo.

Per rimuovere il barrato, passa [TextStrikethroughType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#None). Questo disattiva esplicitamente l’effetto, anche se la formattazione circostante specifica il barrato. Al contrario, [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#NotDefined) lascia l’impostazione locale non definita, consentendo alla porzione di ereditare la formattazione, ad esempio dal paragrafo. Non garantisce che il barrato sia rimosso. Usa [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) per leggere la formattazione risultante, inclusi i valori ereditati.

L’esempio auto‑contenuto qui sotto crea tre confronti di prezzo. Ogni paragrafo ha porzioni separate per l’etichetta, il prezzo precedente e quello corrente, quindi solo il prezzo precedente è interessato. La prima riga applica e poi rimuove il barrato; le altre righe mantengono il barrato singolo e doppio. Modificando questa impostazione si preserva il testo e le altre formattazioni, incluso il prezzo precedente in grassetto.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextStrikethroughType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = Paragraph()
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceAfter(20)

        portion_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
        portion_format.setFontHeight(28)
        font = FontData("Arial")
        portion_format.setLatinFont(font)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        label_portion = Portion(label)
        paragraph.getPortions().add(label_portion)

        previous_price = Portion("$100")
        previous_price.getPortionFormat().setFontBold(NullableBool.True_)
        paragraph.getPortions().add(previous_price)
        current_price = Portion(" → $80")
        paragraph.getPortions().add(current_price)

        shape.getTextFrame().getParagraphs().add(paragraph)

    paragraphs = shape.getTextFrame().getParagraphs()

    # Applica il barrato, quindi rimuovilo esplicitamente dal primo prezzo precedente.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None_)

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double)

    presentation.save("strikethrough.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato, dall’alto verso il basso: nessun barrato, barrato singolo e barrato doppio.

![Prezzi precedenti senza barrato, con barrato singolo e con barrato doppio](strikethrough.png)

## **Imposta rotazione del testo**

Usa [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) per impostare un’orientazione predefinita del testo all’interno di una forma.

Il codice di esempio seguente imposta l’orientazione del testo nella forma su [TextVerticalType.Vertical270](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/), che ruota il testo **di 90 gradi in senso antiorario**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextVerticalType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![La rotazione del testo](text_rotation.png)

## **Visualizza le cifre affiancate nel testo verticale**

Per mantenere le cifre di un numero a due cifre affiancate in un’etichetta giapponese verticale, inserisci entrambe le cifre in un’unica porzione di testo e chiama [BasePortionFormat.setKumimoji](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKumimoji) su quella porzione. Entrambe le etichette in questo esempio usano [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/#EastAsianVertical) e MS Gothic 40 punti. Solo l’impostazione [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) per le cifre è diversa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Portion, Presentation, SaveFormat, ShapeType, TextVerticalType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    font = FontData("MS Gothic")

    for x, kumimoji in [(120, NullableBool.True_), (360, NullableBool.False_)]:
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 48, 120, 420)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        frame = label.addTextFrame("")
        frame.getTextFrameFormat().setTextVerticalType(TextVerticalType.EastAsianVertical)

        paragraph = frame.getParagraphs().get_Item(0)
        default_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
        default_format.setLatinFont(font)
        default_format.setEastAsianFont(font)
        default_format.setFontHeight(40)
        default_format.getFillFormat().setFillType(FillType.Solid)
        default_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        digits = Portion("12")
        digits.getPortionFormat().setKumimoji(kumimoji)
        
        portions = paragraph.getPortions()
        portions.clear()
        portions.add(Portion("令和"))
        portions.add(digits)
        portions.add(Portion("年"))

    presentation.save("vertical_date.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

In PowerPoint, l’etichetta sinistra (`True`) mostra le cifre erette e affiancate tra 和 e 年. Nell’etichetta destra (`False`), la coppia è ruotata di 90 gradi in senso orario. I caratteri giapponesi circostanti rimangono eretti in entrambe le etichette.

![Confronto PowerPoint di etichette di data verticali con cifre erette a sinistra e cifre ruotate a destra.](vertical_date.png)

## **Imposta rotazione personalizzata per i riquadri di testo**

Usa [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) per impostare un angolo di rotazione personalizzato per un [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/).

Il codice di esempio qui sotto ruota il riquadro di testo di 3 gradi in senso orario all’interno della forma:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setRotationAngle(3)

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![La rotazione personalizzata del testo](custom_text_rotation.png)

## **Imposta l’interlinea dei paragrafi**

Aspose.Slides fornisce [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) e [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) per controllare la spaziatura dei paragrafi. Queste proprietà si usano così:

* Usa un valore positivo per specificare l’interlinea come percentuale dell’altezza della linea.
* Usa un valore negativo per specificare l’interlinea in punti.

L’esempio seguente imposta la spaziatura interna del primo paragrafo al 200 % dell’altezza della linea (doppio spazio):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setSpaceWithin(200)

    presentation.save("line_spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![L’interlinea all’interno del paragrafo](line_spacing.png)

## **Controlla l’interruzione di riga**

Le regole di interruzione di riga dei paragrafi sono utili in blocchi di testo stretti e in presentazioni che mescolano testo latino e orientale. I seguenti metodi appartengono a [ParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/), quindi si applicano a tutto il paragrafo:

- [setLatinLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) controlla le regole di interruzione per il latino. In un testo misto, modificarlo può anche cambiare dove il testo e la punteggiatura orientale adiacenti vanno a capo.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) controlla le regole di interruzione per il testo orientale, comprese le restrizioni sui caratteri all’inizio e alla fine di una riga.

Queste regole non sostituiscono [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText), che abilita il wrapping automatico all’interno di un riquadro di testo. Influenzano il layout quando il wrapping avviene; non inseriscono caratteri di interruzione di riga. Un’interruzione di riga esplicita forza una nuova riga all’interno del paragrafo indipendentemente dalla larghezza disponibile.

L’esempio auto‑contenuto qui sotto crea un blocco di testo stretto contenente cinese e latino. Imposta entrambe le opzioni di interruzione di riga esplicitamente e salva "line_breaking.pptx". Per sperimentare una delle regole, modifica il valore corrispondente mantenendo invariata l’altra impostazione. L’esempio usa Arial 24 punti e SimSun con una larghezza del riquadro di 160 punti e margini orizzontali del riquadro pari a zero. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) è chiamato con [TextAutofitType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textautofittype/) affinché le dimensioni del testo e del riquadro rimangano fisse.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("中文排版测试，PowerPoint 中文演示。")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    east_asian_font = FontData("SimSun")
    paragraph_format.getDefaultPortionFormat().setEastAsianFont(east_asian_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setLatinLineBreak(NullableBool.False_)
    paragraph_format.setEastAsianLineBreak(NullableBool.True_)

    presentation.save("line_breaking.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Controlla la punteggiatura sospesa**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) consente ai segni di punteggiatura idonei di estendersi oltre il bordo destro della linea di testo invece di occupare la riga successiva. Si applica a tutto il paragrafo ed è diverso da un rientro sospeso.

L’esempio auto‑contenuto qui sotto abilita la punteggiatura sospesa in un riquadro di testo largo 100 punti e salva "hanging_punctuation.pptx". Con Arial 24 punti e margini orizzontali del riquadro pari a zero, il punto finale rimane dopo "sentence" ed esce oltre il bordo destro del testo. Imposta la proprietà su [NullableBool.False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) per confrontare: con queste impostazioni, il punto occupa una riga separata. Il wrapping è abilitato e l’autofit è disabilitato per mantenere fissa la larghezza disponibile.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("Simple text, next sentence.")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setHangingPunctuation(NullableBool.True_)

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Non tutti i segni di punteggiatura possono sospendersi. Le [condizioni di font e layout descritte sopra](#control-line-breaking) si applicano anche a questo confronto: cambiare il font, la larghezza disponibile, i margini o le impostazioni di autofit può rimuovere la differenza visibile.

## **Imposta il tipo di autofit per i riquadri di testo**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) determina come il testo si comporta quando supera i confini del contenitore. Usalo per controllare se il testo si riduce, trabocca o ridimensiona automaticamente la forma. L’esempio seguente configura la forma per ridimensionarsi in modo da contenere il testo e salva il risultato in "autofit_type.pptx".

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAutofitType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape)

    presentation.save("autofit_type.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Per contare le righe dopo il wrapping automatico e vedere come la larghezza del testo o della forma cambia il risultato, vedi [Count Rendered Lines](/slides/it/python-java/manage-paragraph/). Il conteggio delle righe da solo non indica se il testo trabocca dal contenitore.

## **Imposta l’ancora dei riquadri di testo**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) definisce come il testo è posizionato verticalmente all’interno di una forma, ad esempio in alto, al centro o in basso. L’esempio seguente ancora il testo al fondo della prima forma e salva il risultato in "text_anchor.pptx".

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAnchorType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom)

    presentation.save("text_anchor.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Imposta la tabulazione del testo**

Usa [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) e [ParagraphFormat.getTabs](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getTabs) per configurare le tabulazioni in un paragrafo. L’esempio seguente imposta l’intervallo di tabulazione predefinito a 100 punti e aggiunge una tabulazione allineata a sinistra a 30 punti. Queste impostazioni influiscono sul testo contenente caratteri di tabulazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TabAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setDefaultTabSize(100)
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left)

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Le tabulazioni del paragrafo](paragraph_tabs.png)

## **Imposta la lingua di revisione**

Aspose.Slides fornisce [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId), che consente di impostare la lingua di revisione per una porzione di testo. La lingua di revisione determina la lingua usata per i controlli ortografici e grammaticali in PowerPoint.

L’esempio seguente richiede "presentation.pptx" con una casella di testo come prima forma nella prima diapositiva e almeno un paragrafo. Sostituisce il contenuto del primo paragrafo con "1。", imposta SimSun come font e assegna la lingua di revisione cinese semplificata (`zh-CN`). Salva il risultato in "proofing_language.pptx":

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Portion, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    font = FontData("SimSun")

    text_portion = Portion()
    text_portion.getPortionFormat().setComplexScriptFont(font)
    text_portion.getPortionFormat().setEastAsianFont(font)
    text_portion.getPortionFormat().setLatinFont(font)

    # Imposta l'ID della lingua di revisione.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Copia i metadati della lingua**

Quando si copia testo multilingue da un modello, preserva sia [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getLanguageId) che [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getAlternativeLanguageId). L’esempio auto‑contenuto qui sotto crea una porzione sorgente con l’inglese americano come lingua e il francese come lingua alternativa e copia il testo e gli identificatori in una porzione di una nuova presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

source = Portion("Hello! Bonjour!")
source.getPortionFormat().setLanguageId("en-US")
source.getPortionFormat().setAlternativeLanguageId("fr-FR")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    destination = Portion()
    destination.setText(source.getText())
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId())
    # Se l'origine non ha una lingua alternativa, None cancella il valore di destinazione.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId())
    paragraph.getPortions().add(destination)

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Per provare una sorgente senza lingua alternativa, ometti l’assegnazione di `"fr-FR"`. L’identificatore alternativo sarà quindi `None`, e la stessa istruzione di copia ne preserva l’assenza senza introdurre un valore predefinito, anche se la destinazione aveva precedentemente una lingua alternativa assegnata.

Questi identificatori sono metadati della lingua. Preservarli non stabilisce quale dizionario PowerPoint seleziona per i controlli ortografici o grammaticali.

## **Imposta la lingua predefinita**

Usa [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) per definire la lingua predefinita per il testo creato durante il caricamento o la creazione di una presentazione. L’esempio seguente crea una presentazione con l’inglese americano come lingua predefinita del testo, aggiunge una casella di testo e stampa `en-US` per la sua prima porzione di testo.

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi una forma rettangolare con testo.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # Controlla la lingua della prima porzione.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Imposta lo stile di testo predefinito**

Per applicare la formattazione predefinita del testo a livello di presentazione, usa [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDefaultTextStyle).

L’esempio seguente imposta un font grassetto a 14 punti come predefinito per i paragrafi di livello superiore in una nuova presentazione e lo salva in "default_text_style.pptx". Il testo può ereditare questi valori predefiniti a meno che una formattazione più specifica non li sovrascriva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # Ottieni il formato del paragrafo di livello superiore.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Estrai il testo con l’effetto Tutto Maiuscolo**

In PowerPoint, l’applicazione dell’effetto font **All Caps** fa apparire il testo in maiuscolo nella diapositiva anche se è stato digitato originariamente in minuscolo. Quando si recupera tale porzione di testo con Aspose.Slides, la libreria restituisce il testo esattamente com’era stato inserito. Per corrispondere al testo visualizzato, controlla [TextCapType](https://reference.aspose.com/slides/python-java/aspose.slides/textcaptype/) e converti la stringa restituita in maiuscolo quando il valore è `All`.

Questo esempio richiede "sample2.pptx" con una casella di testo come prima forma nella prima diapositiva. Il suo primo paragrafo contiene "Hello, Aspose!" con l’effetto All Caps applicato, come mostrato di seguito.

![L’effetto All Caps](all_caps_effect.png)

Il codice di esempio qui sotto mostra come estrarre il testo con l’effetto **All Caps** applicato:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TextCapType

presentation = Presentation("sample2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    auto_shape = slide.getShapes().get_Item(0)
    text_portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)

    print("Original text: " + str(text_portion.getText()))

    text_format = text_portion.getPortionFormat().getEffective()
    if text_format.getTextCapType() == TextCapType.All:
        text = str(text_portion.getText()).upper()
        print("All-Caps effect: " + text)
finally:
    presentation.dispose()
```

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Come modifico il testo in una tabella su una diapositiva?**

Per modificare il testo in una tabella su una diapositiva, usa [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/). Itera attraverso le celle e aggiorna ciascuna cella tramite [Cell.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) e la formattazione del paragrafo tramite [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat).

**Come applico un colore sfumato al testo su una diapositiva PowerPoint?**

Per applicare un colore sfumato al testo, usa [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat). Imposta [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) su [FillType.Gradient](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) e configura le fermate del gradiente, la direzione e la trasparenza.