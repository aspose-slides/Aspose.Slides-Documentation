---
title: Formattare il testo della presentazione in Python
linktitle: Formattazione del testo
type: docs
weight: 50
url: /it/python-net/text-formatting/
keywords:
- allineare il paragrafo
- stile del testo
- sfondo del testo
- trasparenza del testo
- spaziatura dei caratteri
- proprietà del font
- famiglia di caratteri
- rotazione del testo
- angolo di rotazione
- riquadro di testo
- interlinea
- proprietà di autofit
- ancora del riquadro di testo
- tabulazione del testo
- lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Formatta e assegna stili al testo in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Python tramite .NET. Personalizza caratteri, colori, allineamento e altro."
---
## **Panoramica**

Questo articolo mostra come formattare il testo in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Python tramite .NET. Copre i colori di sfondo, la trasparenza, la spaziatura dei caratteri, le proprietà del carattere, la rotazione, la spaziatura dei paragrafi, il comportamento di autofit, l'ancoraggio del testo, le tabulazioni e le impostazioni della lingua.

Salvo indicazione diversa, gli esempi utilizzano [sample.pptx](sample.pptx). La prima forma nella sua prima diapositiva è una casella di testo e il suo primo paragrafo contiene il testo mostrato di seguito. Sia gli indici delle diapositive che delle forme partono da zero. Gli esempi che selezionano porzioni in grassetto usano la formattazione effettiva, inclusa la formattazione del grassetto ereditata:

![Testo di esempio](sample_text.png)

Per trovare e evidenziare testo letterale o corrispondenze di espressioni regolari, vedere [Cerca e sostituisci testo](/slides/it/python-net/search-and-replace-text/).

## **Imposta colore di sfondo del testo**

Usa [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) per impostare il colore di evidenziazione predefinito per un paragrafo, o usa [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) per porzioni di testo individuali.

Il seguente esempio imposta un'evidenziazione grigio chiaro come predefinita per il primo paragrafo. I colori di evidenziazione espliciti su singole porzioni hanno la precedenza rispetto a questa impostazione predefinita:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Imposta il colore di evidenziazione per l'intero paragrafo.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Il paragrafo grigio](gray_paragraph.png)

L'esempio di codice seguente dimostra come impostare il colore di sfondo per **porzioni di testo con un carattere in grassetto**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Imposta il colore di evidenziazione per la porzione di testo.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Le porzioni di testo grigie](gray_text_portions.png)

## **Allinea i paragrafi di testo**

Usa [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) per impostare l'allineamento del paragrafo all'interno di un riquadro di testo. Il valore può essere centrato, allineato a sinistra, allineato a destra, giustificato, ecc.

Il seguente esempio di codice mostra come allineare il paragrafo al **centro**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Imposta l'allineamento del paragrafo al centro.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CEN

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Il paragrafo allineato](aligned_paragraph.png)

## **Allinea i caratteri all'interno di una riga**

Usa [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) per allineare verticalmente le porzioni di testo di dimensioni di carattere diverse all'interno di una riga. Questa impostazione si applica all'intero paragrafo e controlla l'allineamento all'interno di ciascuna delle sue righe.

Il seguente esempio autonomo crea quattro caselle di testo etichettate su una singola diapositiva. Ogni paragrafo contiene lo stesso testo a 18, 36 e 54 punti, con un diverso allineamento del carattere. Usa Arial, disabilita autofit e a capo automatico e mantiene i riquadri di testo sufficientemente ampi per una singola riga.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    alignments = [slides.FontAlignment.BASELINE, slides.FontAlignment.TOP, slides.FontAlignment.CENTER, slides.FontAlignment.BOTTOM]
    font_sizes = [18, 36, 54]

    for i, alignment in enumerate(alignments):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20 + i * 130, 660, 120)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE

        label = text_frame.paragraphs[0]
        label.text = alignment.name.title()
        label.paragraph_format.alignment = slides.TextAlignment.LEFT
        label.paragraph_format.default_portion_format.font_height = 14
        label.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        label.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        label.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.gray

        paragraph = slides.Paragraph()
        paragraph.paragraph_format.font_alignment = alignment
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black

        for font_size in font_sizes:
            portion = slides.Portion("Ag ")
            portion.portion_format.font_height = font_size
            paragraph.portions.add(portion)

        text_frame.paragraphs.add(paragraph)

    presentation.save("font_alignment.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Confronto di allineamento basale, superiore, centrale e inferiore con caratteri di dimensioni miste](font_alignment.png)

L'allineamento dei caratteri utilizza metriche tipografiche, quindi i bordi visibili delle singole lettere non sempre coincidono esattamente. L'esempio include sia una lettera maiuscola sia un discendente per mostrare la differenza tra allineamento basale e inferiore. La disponibilità e la sostituzione dei caratteri, i caratteri utilizzati e la differenza di dimensioni influenzano il risultato. Le dimensioni del riquadro, i margini, l'interlinea, il wrapping e l'autofit influiscono anch'essi sul layout; usa gli stessi caratteri e le stesse impostazioni di layout quando confronti le modalità.

Questa impostazione differisce da [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/), che controlla l'allineamento orizzontale del paragrafo, e da [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/), che posiziona verticalmente il blocco di testo all'interno della sua forma. La formattazione superscript e subscript tramite [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) sposta le singole porzioni rispetto alla linea di base invece di impostare l'allineamento del carattere per le righe del paragrafo.

## **Imposta trasparenza per il testo**

La trasparenza del testo è controllata tramite il componente alfa del colore assegnato a [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Nei seguenti esempi, `alpha = 50` è un valore alfa ARGB su scala 0–255, non una percentuale di trasparenza.

L'esempio di codice seguente mostra come applicare la trasparenza all'**intero paragrafo**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Imposta un riempimento nero semitrasparente per il testo.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Il paragrafo trasparente](transparent_paragraph.png)

Il seguente esempio di codice mostra come applicare la trasparenza a **porzioni di testo con un carattere in grassetto**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Imposta la trasparenza della porzione di testo.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Le porzioni di testo trasparenti](transparent_text_portions.png)

## **Imposta spaziatura dei caratteri per il testo**

Usa [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) per espandere o comprimere la spaziatura tra i caratteri in una casella di testo. Gli esempi aggiungono 3 punti di spaziatura; i valori negativi comprimono il testo.

Il seguente codice Python mostra come espandere la spaziatura dei caratteri nell'**intero paragrafo**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Nota: Usa valori negativi per comprimere la spaziatura dei caratteri.
    paragraph.paragraph_format.default_portion_format.spacing = 3  #  Espandi la spaziatura dei caratteri.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![La spaziatura dei caratteri nel paragrafo](character_spacing_in_paragraph.png)

L'esempio di codice seguente mostra come espandere la spaziatura dei caratteri in **porzioni di testo con un carattere in grassetto**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Nota: Usa valori negativi per comprimere la spaziatura dei caratteri.
            portion.portion_format.spacing = 3  # Espandi la spaziatura dei caratteri.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![La spaziatura dei caratteri nelle porzioni di testo](character_spacing_in_text_portions.png)

### **Disabilita il kerning per caratteri specifici**

In alcuni casi, il testo renderizzato da Aspose.Slides può apparire leggermente più stretto rispetto allo stesso testo mostrato in PowerPoint. Ciò può accadere perché PowerPoint può ignorare i dati di kerning per determinati font, anche quando il font contiene informazioni di kerning valide e il kerning è abilitato nelle impostazioni di PowerPoint.

Per avvicinare il risultato renderizzato a PowerPoint in tali casi, è possibile disabilitare il kerning per le porzioni di testo che utilizzano il font interessato. Imposta [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) a un valore maggiore della dimensione reale del carattere. Questo esempio richiede "presentation.pptx" con una casella di testo come prima forma nella prima diapositiva. Controlla i nomi dei font effettivi, inclusi i font ereditati, e imposta una soglia di 100 punti per le porzioni che usano Roboto. Questo disabilita il kerning per le porzioni corrispondenti con una dimensione del carattere inferiore a 100 punti:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            text_format = portion.portion_format.get_effective()
            fonts = (text_format.latin_font, text_format.east_asian_font, text_format.complex_script_font)
            uses_target_font = any(font is not None and font.font_name == target_font for font in fonts)

            if uses_target_font:
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Per il testo corrispondente al di sotto della soglia, questa impostazione impedisce il kerning e può aiutare ad allineare il rendering di Aspose.Slides a quello visuale di PowerPoint per i font interessati da questo comportamento specifico di PowerPoint.

## **Gestisci le proprietà del carattere del testo**

Le proprietà del carattere possono essere impostate a livello di paragrafo tramite [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) o su singole porzioni tramite [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/).

Il seguente esempio imposta il carattere predefinito del primo paragrafo a Times New Roman 12 punti con formattazione grassetto, corsivo e sottolineatura a punti. La formattazione esplicita su singole porzioni ha la precedenza su questi valori predefiniti.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Imposta le proprietà del font per il paragrafo.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Le proprietà del carattere per il paragrafo](font_properties_for_paragraph.png)

Il seguente esempio applica Times New Roman 13 punti, formattazione corsiva e una sottolineatura a punti a tutte le porzioni il cui formattazione effettiva è grassetto:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Imposta le proprietà del font per la porzione di testo.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Le proprietà del carattere per le porzioni di testo](font_properties_for_text_portions.png)

## **Controlla la normalizzazione dell'altezza del testo**

Usa [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/) quando riproduci la tipografia di un modello o indaghi differenze nell'altezza dei caratteri. In PowerPoint, l'abilitazione della normalizzazione allunga o comprime verticalmente i singoli caratteri per dare loro un'altezza visibile uniforme all'interno della porzione di testo. Non garantisce altezze di testo uguali tra font diversi.

Imposta la proprietà su [NullableBool.TRUE o FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) per abilitare o disabilitare esplicitamente la normalizzazione. `NullableBool.NOT_DEFINED` lascia l'impostazione locale non definita affinché la porzione erediti il valore, ad esempio dal [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) del paragrafo. Non equivale a `False`. Usa [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) e leggi [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/) per ottenere il valore booleano risolto.

Il seguente esempio autonomo richiede **Arial** installato. Crea due blocchi di testo contenenti le stesse lettere maiuscole, minuscole, discendenti e caratteri accentati a 54 punti. Entrambi i paragrafi abilitano la normalizzazione di default. La porzione superiore la disabilita esplicitamente; quella inferiore la eredita. Le dimensioni del riquadro, i margini e la spaziatura dei paragrafi sono identiche, con wrapping e autofit disabilitati per mantenere il confronto coerente. L'esempio stampa `FALSE: False` e `NOT_DEFINED: True`, quindi salva "text_height_normalization.pptx".

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    settings = [slides.NullableBool.FALSE, slides.NullableBool.NOT_DEFINED]

    for i, setting in enumerate(settings):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 60 + i * 200, 660, 150)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text = "Hxgjpq ÅÉ 0123"
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.margin_top = 0
        text_frame.text_frame_format.margin_left = 0

        paragraph = text_frame.paragraphs[0]
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_before = 0
        paragraph.paragraph_format.space_after = 0
        paragraph.paragraph_format.space_within = 100
        paragraph.paragraph_format.default_portion_format.normalise_height = slides.NullableBool.TRUE

        portion = paragraph.portions[0]
        portion.portion_format.latin_font = slides.FontData("Arial")
        portion.portion_format.font_height = 54
        portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion.portion_format.fill_format.solid_fill_color.color = "black"
        portion.portion_format.normalise_height = setting

        print(f"{setting.name}: {portion.portion_format.get_effective().normalise_height}")

    presentation.save("text_height_normalization.pptx", slides.export.SaveFormat.PPTX)
```

Il confronto qui sotto è stato esportato dalla presentazione salvata. La riga superiore ha la normalizzazione disabilitata (`FALSE`); la riga inferiore eredita l'impostazione abilitata (`NOT_DEFINED` → `True`). Mantieni Arial installato per riprodurre quest'aspetto.

![Testo Arial 54 punti con normalizzazione disabilitata sopra e normalizzazione ereditata abilitata sotto](text_height_normalization.png)

La normalizzazione modifica l'altezza dei caratteri senza modificare il valore assegnato a [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/), che specifica la dimensione del carattere in punti. [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) controlla l'interlinea del paragrafo, mentre [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) controlla come il testo o il suo contenitore si adattano. Queste impostazioni hanno scopi diversi e possono influenzare il layout complessivo in modo indipendente. Per ulteriori dettagli su formattazione e ereditarietà dei paragrafi, vedi [Gestisci paragrafi](/slides/it/python-net/manage-paragraph/).

## **Applica e rimuovi il barrato**

Usa [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) su una porzione di testo per visualizzare correzioni, termini annullati o prezzi precedenti senza eliminare il testo originale. Impostalo su [TextStrikethroughType.SINGLE o DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) per una o due linee attraverso il testo.

Per rimuovere il barrato, assegna `TextStrikethroughType.NONE`. Questo disabilita esplicitamente l'effetto, anche se la formattazione circostante specifica il barrato. Al contrario, `TextStrikethroughType.NOT_DEFINED` lascia l'impostazione locale non definita, permettendo alla porzione di ereditare la formattazione, ad esempio dal paragrafo. Non garantisce che il barrato sia rimosso. Usa [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) per leggere la formattazione risultante, compresi i valori ereditati.

Il seguente esempio autonomo crea tre confronti di prezzo. Ogni paragrafo ha porzioni separate per l'etichetta, il prezzo precedente e il prezzo attuale, quindi solo il prezzo precedente è influenzato. La prima riga applica e poi rimuove il barrato; le altre righe mantengono barrato singolo e doppio. Cambiare questa proprietà preserva il testo e le altre formattazioni, incluso il prezzo precedente in grassetto.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 620, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = slides.Paragraph()
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_after = 20

        portion_format = paragraph.paragraph_format.default_portion_format
        portion_format.font_height = 28
        portion_format.latin_font = slides.FontData("Arial")
        portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion_format.fill_format.solid_fill_color.color = draw.Color.black

        paragraph.portions.add(slides.Portion(label))

        previous_price = slides.Portion("$100")
        previous_price.portion_format.font_bold = slides.NullableBool.TRUE
        paragraph.portions.add(previous_price)
        paragraph.portions.add(slides.Portion(" → $80"))

        shape.text_frame.paragraphs.add(paragraph)

    paragraphs = shape.text_frame.paragraphs

    # Applica il barrato, poi rimuovilo esplicitamente dal primo prezzo precedente.
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato, dall'alto verso il basso: nessun barrato, barrato singolo e barrato doppio.

![Prezzi precedenti senza barrato, con barrato singolo e con barrato doppio](strikethrough.png)

## **Imposta rotazione del testo**

Usa [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) per impostare un orientamento predefinito del testo all'interno di una forma.

Il seguente esempio di codice imposta l'orientamento del testo nella forma su [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/), che ruota il testo **90 gradi in senso antiorario**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![La rotazione del testo](text_rotation.png)

## **Visualizza le cifre affiancate nel testo verticale**

Per mantenere insieme due cifre in un'etichetta giapponese verticale, inserisci entrambe le cifre in una singola porzione di testo e imposta [BasePortionFormat.kumimoji](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kumimoji/) su quella porzione. L'esempio crea due etichette in una nuova presentazione usando [TextVerticalType.EAST_ASIAN_VERTICAL](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) e MS Gothic a 40 punti. Solo il valore [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) assegnato alla porzione numerica differisce.

```python
import aspose.slides as slides


def add_label(slide, x, kumimoji):
    label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, 48, 120, 420)
    label.fill_format.fill_type = slides.FillType.NO_FILL
    label.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    frame = label.add_text_frame("")
    frame.text_frame_format.text_vertical_type = slides.TextVerticalType.EAST_ASIAN_VERTICAL

    paragraph = frame.paragraphs[0]
    portion_format = paragraph.paragraph_format.default_portion_format
    font = slides.FontData("MS Gothic")
    portion_format.latin_font = font
    portion_format.east_asian_font = font
    portion_format.font_height = 40
    portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion_format.fill_format.solid_fill_color.color = "black"

    digits = slides.Portion("12")
    digits.portion_format.kumimoji = kumimoji

    paragraph.portions.clear()
    paragraph.portions.add(slides.Portion("令和"))
    paragraph.portions.add(digits)
    paragraph.portions.add(slides.Portion("年"))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    add_label(slide, 120, slides.NullableBool.TRUE)
    add_label(slide, 360, slides.NullableBool.FALSE)
    
    presentation.save("vertical_date.pptx", slides.export.SaveFormat.PPTX)
```

In PowerPoint, l'etichetta sinistra (`TRUE`) mostra le cifre dritte e affiancate tra 和 e 年. Nell'etichetta destra (`FALSE`), la coppia è ruotata di 90 gradi in senso orario. I caratteri giapponesi circostanti rimangono dritti in entrambe le etichette.

![Confronto PowerPoint di etichette di data verticali con cifre dritte a sinistra e cifre ruotate a destra.](vertical_date.png)

## **Imposta rotazione personalizzata per i riquadri di testo**

Usa [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) per impostare un angolo di rotazione personalizzato per un [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).

Il seguente esempio di codice ruota il riquadro di testo di 3 gradi in senso orario all'interno della forma:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![La rotazione personalizzata del testo](custom_text_rotation.png)

## **Imposta l'interlinea dei paragrafi**

Aspose.Slides fornisce [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) e [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) per controllare la spaziatura dei paragrafi. Queste proprietà vengono utilizzate come segue:

* Usa un valore positivo per specificare l'interlinea come percentuale dell'altezza della riga.
* Usa un valore negativo per specificare l'interlinea in punti.

Il seguente esempio imposta la spaziatura interna del primo paragrafo al 200 % dell'altezza della riga (doppia interlinea):

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![L'interlinea all'interno del paragrafo](line_spacing.png)

## **Controlla l'interruzione di riga**

Le regole di interruzione di riga del paragrafo sono utili in blocchi di testo stretti e in presentazioni che mescolano testo latino e asiatico orientale. Le seguenti proprietà appartengono a [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/), quindi si applicano all'intero paragrafo:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) controlla le regole di interruzione per il testo latino. In testo misto, modificarla può anche cambiare dove il testo e la punteggiatura asiatica orientale adiacenti vanno a capo.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) controlla le regole di interruzione per il testo asiatico orientale, incluse le restrizioni sui caratteri all'inizio e alla fine di una riga.

Queste regole non sostituiscono [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/), che abilita il wrapping automatico all'interno di un riquadro di testo. Influenzano il layout quando avviene il wrapping; non inseriscono caratteri di interruzione di riga. Un'interruzione di riga esplicita fornisce una nuova riga all'interno del paragrafo indipendentemente dalla larghezza disponibile.

Il seguente esempio autonomo crea un blocco di testo stretto contenente cinese e latino. Imposta entrambe le proprietà di interruzione di riga esplicitamente e salva "line_breaking.pptx". Per sperimentare con una delle regole, modifica il valore di quella proprietà mantenendo fisse le altre impostazioni. L'esempio usa Arial 24 pt e SimSun con una larghezza del riquadro di 160 pt e margini orizzontali del riquadro di testo pari a zero. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) è impostato su [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) in modo che la dimensione del testo e le dimensioni del riquadro rimangano fisse.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 160, 300)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "中文排版测试，PowerPoint 中文演示。"

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.east_asian_font = slides.FontData("SimSun")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.latin_line_break = slides.NullableBool.FALSE
    paragraph_format.east_asian_line_break = slides.NullableBool.TRUE

    presentation.save("line_breaking.pptx", slides.export.SaveFormat.PPTX)
```

## **Controlla la punteggiatura sospesa**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) consente alla punteggiatura ammissibile di estendersi oltre il bordo destro della linea di testo anziché occupare la riga successiva. Si applica all'intero paragrafo ed è diversa da un rientro sospeso.

Il seguente esempio autonomo abilita la punteggiatura sospesa in un riquadro di testo largo 100 pt e salva "hanging_punctuation.pptx". Con Arial 24 pt e margini orizzontali del riquadro pari a zero, il punto finale rimane dopo "sentence" ed esce oltre il bordo destro del testo. Imposta la proprietà su [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) per confrontare: con queste impostazioni, il punto occupa una riga separata. Il wrapping è abilitato e l'autofit è disabilitato per mantenere fissa la larghezza disponibile.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 200)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "Simple text, next sentence."

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.hanging_punctuation = slides.NullableBool.TRUE

    presentation.save("hanging_punctuation.pptx", slides.export.SaveFormat.PPTX)
```

Non tutti i segni di punteggiatura possono sospendere. Il risultato visibile dipende da [condizioni di font e layout](#control-line-breaking): modificare il font, la larghezza disponibile, i margini o le impostazioni di autofit può rimuovere la differenza visibile.

## **Imposta il tipo di autofit per i riquadri di testo**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) determina come il testo si comporta quando supera i confini del suo contenitore. Usalo per controllare se il testo si riduce, trabocca o ridimensiona automaticamente la forma. Il seguente esempio configura la forma per ridimensionarsi in modo da adattarsi al testo e salva il risultato in "autofit_type.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Per contare le righe dopo il wrapping automatico e vedere come il testo o la larghezza della forma cambiano il risultato, vedi [Conteggio righe renderizzate](/slides/it/python-net/manage-paragraph/). Il conteggio delle righe da solo non indica se il testo trabocca dal contenitore.

## **Imposta l'ancoraggio dei riquadri di testo**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) definisce come il testo è posizionato verticalmente all'interno di una forma, ad esempio in alto, al centro o in basso. Il seguente esempio ancora il testo al fondo della prima forma e salva il risultato in "text_anchor.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta la tabulazione del testo**

Usa [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) e [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) per configurare le tabulazioni in un paragrafo. Il seguente esempio imposta l'intervallo di tabulazione predefinito a 100 punti e aggiunge una tabulazione sinistra a 30 punti. Queste impostazioni influenzano il testo contenente caratteri di tabulazione.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Le tabulazioni del paragrafo](paragraph_tabs.png)

## **Imposta la lingua di correzione**

Aspose.Slides fornisce [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/), che consente di impostare la lingua di correzione per una porzione di testo. La lingua di correzione determina la lingua usata per il controllo ortografico e grammaticale in PowerPoint.

Il seguente esempio richiede "presentation.pptx" con una casella di testo come prima forma nella prima diapositiva e almeno un paragrafo. Sostituisce il contenuto del primo paragrafo con "1。", imposta SimSun come font e assegna la lingua di correzione cinese semplificato (`zh-CN`). Salva il risultato in "proofing_language.pptx":

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # Imposta la lingua di correzione a cinese semplificato.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

### **Copia i metadati della lingua**

Quando copi testo multilingue da un modello, conserva sia [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) sia [BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/). Il seguente esempio autonomo crea una porzione di origine con l'inglese statunitense come lingua e il francese come lingua alternativa e copia il testo e gli identificatori in una porzione di una nuova presentazione.

```python
import aspose.slides as slides

source = slides.Portion("Hello! Bonjour!")
source.portion_format.language_id = "en-US"
source.portion_format.alternative_language_id = "fr-FR"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    destination = slides.Portion()
    destination.text = source.text
    destination.portion_format.language_id = source.portion_format.language_id
    # Se la sorgente non ha lingua alternativa, None cancella il valore di destinazione.
    destination.portion_format.alternative_language_id = source.portion_format.alternative_language_id
    paragraph.portions.add(destination)

    presentation.save("copied_language_metadata.pptx", slides.export.SaveFormat.PPTX)
```

Per provare una sorgente senza lingua alternativa, ometti l'assegnazione di `"fr-FR"`. L'identificatore alternativo sarà quindi `None`, e la stessa istruzione di copia preserva l'assenza senza introdurre un valore predefinito, anche se la destinazione aveva precedentemente una lingua alternativa assegnata.

Questi identificatori sono metadati della lingua. La loro conservazione non stabilisce quale dizionario PowerPoint selezioni per il controllo ortografico o grammaticale.

## **Imposta la lingua predefinita**

Usa [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) per definire la lingua predefinita per il testo creato durante il caricamento o la creazione di una presentazione. Il seguente esempio crea una presentazione con l'inglese statunitense come lingua predefinita del testo, aggiunge una casella di testo e stampa `en-US` per la sua prima porzione di testo.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Aggiungi una nuova forma rettangolare con testo.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Controlla la lingua della prima porzione.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Imposta lo stile di testo predefinito**

Per applicare la formattazione predefinita del testo a livello di presentazione, usa [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/).

Il seguente esempio imposta un carattere grassetto a 14 pt come predefinito per i paragrafi di livello superiore in una nuova presentazione e lo salva in "default_text_style.pptx". Il testo può ereditare questi valori predefiniti a meno che una formattazione più specifica non li sovrascriva.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Ottieni il formato del paragrafo di livello superiore.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Estrai il testo con l'effetto tutto maiuscolo**

In PowerPoint, l'applicazione dell'effetto **All Caps** al carattere fa apparire il testo in maiuscolo nella diapositiva anche se originariamente digitato in minuscolo. Quando recuperi una tale porzione di testo con Aspose.Slides, la libreria restituisce il testo esattamente come è stato inserito. Per corrispondere al testo visualizzato, controlla [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) e converti la stringa restituita in maiuscolo quando il valore è `ALL`.

Questo esempio richiede "sample2.pptx" con una casella di testo come prima forma nella prima diapositiva. Il suo primo paragrafo contiene una prima porzione con "Hello, Aspose!" a cui è applicato l'effetto All Caps, come mostrato sotto.

![L'effetto All Caps](all_caps_effect.png)

Il seguente esempio di codice mostra come estrarre il testo con l'effetto **All Caps** applicato:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Come modifico il testo in una tabella su una diapositiva?**

Per modificare il testo in una tabella su una diapositiva, usa [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Itera attraverso le celle e aggiorna ciascuna cella tramite [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) e la formattazione del paragrafo tramite [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/).

**Come applico un colore gradiente al testo su una diapositiva PowerPoint?**

Per applicare un colore gradiente al testo, usa [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Imposta [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) su [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) e configura le fermate del gradiente, la direzione e la trasparenza.

Funzionalità correlata: [Formatta il testo nelle diapositive](/slides/it/features/text-formatting/).