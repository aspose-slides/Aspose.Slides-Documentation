---
title: Formattare il testo della presentazione in Python
linktitle: Formattazione del testo
type: docs
weight: 50
url: /it/python-net/text-formatting/
keywords:
- allineamento paragrafo
- stile testo
- sfondo testo
- trasparenza testo
- spaziatura caratteri
- proprietà font
- famiglia font
- rotazione testo
- angolo rotazione
- riquadro testo
- interlinea
- proprietà autofit
- ancora riquadro testo
- tabulazione testo
- lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Formattare e stilizzare il testo in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Python via .NET. Personalizza font, colori, allineamento e molto altro."
---
## **Panoramica**

Questo articolo mostra come formattare il testo nelle presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Python via .NET. Copre i colori di sfondo, la trasparenza, la spaziatura dei caratteri, le proprietà dei caratteri, la rotazione, la spaziatura dei paragrafi, il comportamento di adattamento automatico, l'ancoraggio del testo, le tabulazioni e le impostazioni della lingua.

Salvo indicazione contraria, gli esempi utilizzano [sample.pptx](sample.pptx). La prima forma nella sua prima diapositiva è una casella di testo e il suo primo paragrafo contiene il testo mostrato di seguito. Gli indici di diapositiva e di forma sono basati su zero. Gli esempi che selezionano parti in grassetto usano la formattazione efficace, inclusa la formattazione in grassetto ereditata:

![Testo di esempio](sample_text.png)

Per trovare e evidenziare testo letterale o corrispondenze di espressioni regolari, vedere [Cerca e sostituisci testo](/slides/it/python-net/search-and-replace-text/).

## **Imposta colore di sfondo del testo**

Utilizza [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/default_portion_format/) per impostare il colore di evidenziazione predefinito per un paragrafo, oppure usa [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseportionformat/highlight_color/) per singole parti di testo.

Il seguente esempio imposta un evidenziazione grigio chiaro come predefinita per il primo paragrafo. I colori di evidenziazione espliciti su singole parti hanno la precedenza su questo valore predefinito:

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

L'esempio di codice seguente dimostra come impostare il colore di sfondo per **parti di testo con un carattere in grassetto**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Imposta il colore di evidenziazione per la parte di testo.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Le parti di testo grigie](gray_text_portions.png)

## **Allinea paragrafi di testo**

Utilizza [ParagraphFormat.alignment](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/alignment/) per impostare l'allineamento del paragrafo all'interno di un riquadro di testo. Il valore può essere centrato, allineato a sinistra, allineato a destra, giustificato e così via.

Il seguente esempio di codice mostra come allineare il paragrafo al **centro**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Imposta l'allineamento del paragrafo al centro.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Il paragrafo allineato](aligned_paragraph.png)

## **Imposta trasparenza per il testo**

La trasparenza del testo è controllata tramite il componente alfa del colore assegnato a [BasePortionFormat.fill_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseportionformat/fill_format/). Negli esempi seguenti, `alpha = 50` è un valore del canale alfa ARGB su scala 0–255, non una percentuale di trasparenza.

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

Il seguente esempio di codice mostra come applicare la trasparenza a **parti di testo con un carattere in grassetto**:

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
            # Imposta la trasparenza della parte di testo.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Le parti di testo trasparenti](transparent_text_portions.png)

## **Imposta spaziatura dei caratteri per il testo**

Utilizza [BasePortionFormat.spacing](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseportionformat/spacing/) per aumentare o ridurre la spaziatura tra i caratteri in una casella di testo. Gli esempi aggiungono 3 punti di spaziatura; i valori negativi comprimono il testo.

Il seguente codice Python mostra come espandere la spaziatura dei caratteri nell'**intero paragrafo**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Nota: usa valori negativi per comprimere la spaziatura dei caratteri.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Espandi la spaziatura dei caratteri.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![La spaziatura dei caratteri nel paragrafo](character_spacing_in_paragraph.png)

L'esempio di codice seguente mostra come espandere la spaziatura dei caratteri in **parti di testo con un carattere in grassetto**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Nota: usa valori negativi per comprimere la spaziatura dei caratteri.
            portion.portion_format.spacing = 3  # Espandi la spaziatura dei caratteri.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![La spaziatura dei caratteri nelle parti di testo](character_spacing_in_text_portions.png)

### **Disabilita il kerning per font specifici**

In alcuni casi, il testo renderizzato da Aspose.Slides può apparire leggermente più stretto rispetto allo stesso testo visualizzato in PowerPoint. Ciò può accadere perché PowerPoint può ignorare i dati di kerning per alcuni font, anche quando il font contiene informazioni di kerning valide e il kerning è abilitato nelle impostazioni di PowerPoint.

Per avvicinare l'output renderizzato a quello di PowerPoint in tali casi, è possibile disabilitare il kerning per le parti di testo che utilizzano il font interessato. Imposta [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) a un valore superiore alla dimensione effettiva del font. Questo esempio richiede "presentation.pptx" con una casella di testo come prima forma della prima diapositiva. Verifica i nomi dei font effettivi, inclusi i font ereditati, e imposta una soglia di 100 punti per le parti che usano Roboto. Questo disabilita il kerning per le parti corrispondenti con una dimensione del font inferiore a 100 punti:

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

Per il testo corrispondente al di sotto della soglia, questa impostazione impedisce il kerning e può aiutare ad allineare il rendering di Aspose.Slides all'output visivo di PowerPoint per i font interessati da questo comportamento specifico di PowerPoint.

## **Gestisci le proprietà dei caratteri del testo**

Le proprietà dei caratteri possono essere impostate a livello di paragrafo tramite [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/default_portion_format/) o su singole parti tramite [PortionFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/portionformat/).

Il seguente esempio imposta il font predefinito del primo paragrafo a Times New Roman 12 punti con formattazione in grassetto, corsivo e sottolineatura puntata. La formattazione esplicita su singole parti ha la precedenza su questi valori predefiniti.

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

![Le proprietà del font per il paragrafo](font_properties_for_paragraph.png)

Il seguente esempio applica Times New Roman 13 punti, formattazione corsiva e una sottolineatura puntata alle parti la cui formattazione efficace è in grassetto:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Imposta le proprietà del font per la parte di testo.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Le proprietà del font per le parti di testo](font_properties_for_text_portions.png)

## **Imposta rotazione del testo**

Utilizza [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/text_vertical_type/) per impostare un'orientazione del testo predefinita all'interno di una forma.

Il seguente esempio di codice imposta l'orientazione del testo nella forma a [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/it/python-net/aspose.slides/textverticaltype/), che ruota il testo di **90 gradi in senso antiorario**:

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

## **Imposta rotazione personalizzata per i riquadri di testo**

Utilizza [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/rotation_angle/) per impostare un angolo di rotazione personalizzato per un [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/).

L'esempio di codice seguente ruota il riquadro di testo di 3 gradi in senso orario all'interno della forma:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![La rotazione del testo personalizzata](custom_text_rotation.png)

## **Imposta interlinea dei paragrafi**

Aspose.Slides fornisce [ParagraphFormat.space_after](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/space_before/), e [ParagraphFormat.space_within](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/space_within/) per controllare la spaziatura dei paragrafi. Queste proprietà vengono utilizzate come segue:

* Usa un valore positivo per specificare l'interlinea come percentuale dell'altezza della linea.
* Usa un valore negativo per specificare l'interlinea in punti.

Il seguente esempio imposta la spaziatura all'interno del primo paragrafo al 200% dell'altezza della linea (doppia interlinea):

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

## **Controlla l'interruzione di linea**

Le regole di interruzione di linea dei paragrafi sono utili in blocchi di testo stretti e presentazioni che mescolano testo latino e dell'Est asiatico. Le seguenti proprietà appartengono a [ParagraphFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/), quindi si applicano a un intero paragrafo:

- [latin_line_break](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/latin_line_break/) controlla le regole di interruzione di linea per il latino. In testo misto, modificarla può anche cambiare dove il testo e la punteggiatura dell'Est asiatico adiacenti vanno a capo.
- [east_asian_line_break](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/east_asian_line_break/) controlla le regole di interruzione di linea per l'Est asiatico, incluse le restrizioni sui caratteri all'inizio e alla fine di una linea.

Queste regole non sostituiscono [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/wrap_text/), che abilita l'andare a capo automatico all'interno di un riquadro di testo. Influenzano il layout quando avviene l'andare a capo; non inseriscono caratteri di interruzione di linea. Un'interruzione di linea esplicita forz a una nuova riga all'interno del paragrafo indipendentemente dalla larghezza disponibile.

Il seguente esempio autonomo crea un blocco di testo stretto contenente testo cinese e latino. Imposta entrambe le proprietà di interruzione di linea in modo esplicito e salva "line_breaking.pptx". Per sperimentare una delle due regole, modifica il valore di quella proprietà mantenendo fissi gli altri settaggi. L'esempio utilizza Arial 24 punti e SimSun con una larghezza del riquadro di 160 punti e margini orizzontali del riquadro pari a zero. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/autofit_type/) è impostato su [TextAutofitType.NONE](https://reference.aspose.com/slides/it/python-net/aspose.slides/textautofittype/) affinché la dimensione del testo e le dimensioni del riquadro rimangano fisse.

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

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/hanging_punctuation/) consente alla punteggiatura ammissibile di estendersi oltre il bordo destro della linea di testo invece di occupare la riga successiva. Si applica a tutto il paragrafo ed è differente da un rientro appeso.

Il seguente esempio autonomo abilita la punteggiatura sospesa in un riquadro di testo largo 100 punti e salva "hanging_punctuation.pptx". Con Arial 24 punti e margini orizzontali del riquadro pari a zero, il punto finale rimane dopo "sentence" e si estende oltre il bordo destro del testo. Imposta la proprietà su [NullableBool.FALSE](https://reference.aspose.com/slides/it/python-net/aspose.slides/nullablebool/) per confrontare: con queste impostazioni, il punto occupa una riga separata. L'andare a capo è abilitato e l'autofit è disabilitato per mantenere fissa la larghezza disponibile.

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

Non tutti i segni di punteggiatura possono sospendersi. Il risultato visibile dipende dal font e dalle condizioni di layout: cambiare il font, la larghezza disponibile, i margini o le impostazioni di autofit può rimuovere la differenza visibile.

## **Imposta tipo di autofit per i riquadri di testo**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/autofit_type/) determina come il testo si comporta quando supera i confini del suo contenitore. Usalo per controllare se il testo si riduce, trabocca o ridimensiona automaticamente la forma. Il seguente esempio configura la forma per ridimensionarsi in modo da adattarsi al testo e salva il risultato in "autofit_type.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Per contare le righe dopo l'andare a capo automatico e vedere come la larghezza del testo o della forma modifica il risultato, vedere [Conta le righe renderizzate](/slides/it/python-net/manage-paragraph/). Il semplice conteggio delle righe non indica se il testo trabocca dal contenitore.

## **Imposta ancoraggio dei riquadri di testo**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/anchoring_type/) definisce come il testo è posizionato verticalmente all'interno di una forma, ad esempio in alto, al centro o in basso. Il seguente esempio ancorra il testo al fondo della prima forma e salva il risultato in "text_anchor.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta tabulazione del testo**

Utilizza [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/default_tab_size/) e [ParagraphFormat.tabs](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/tabs/) per configurare le tabulazioni in un paragrafo. Il seguente esempio imposta l'intervallo predefinito delle tabulazioni a 100 punti e aggiunge una tabulazione allineata a sinistra a 30 punti. Queste impostazioni influenzano il testo contenente caratteri di tabulazione.

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

## **Imposta lingua di revisione**

Aspose.Slides fornisce [BasePortionFormat.language_id](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseportionformat/language_id/), che consente di impostare la lingua di revisione per una parte di testo. La lingua di revisione determina la lingua utilizzata per i controlli ortografici e grammaticali in PowerPoint.

Il seguente esempio richiede "presentation.pptx" con una casella di testo come prima forma della prima diapositiva e almeno un paragrafo. Sostituisce il contenuto del primo paragrafo con "1。", imposta SimSun come font e assegna la lingua di revisione cinese semplificata (`zh-CN`). Salva il risultato in "proofing_language.pptx":

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

    # Imposta la lingua di revisione al cinese semplificato.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta lingua predefinita**

Utilizza [LoadOptions.default_text_language](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/default_text_language/) per definire la lingua predefinita per il testo creato durante il caricamento o la creazione di una presentazione. Il seguente esempio crea una presentazione con l'inglese americano come lingua di testo predefinita, aggiunge una casella di testo e stampa `en-US` per la sua prima parte di testo.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Aggiungi una nuova forma rettangolare con testo.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Verifica la lingua della prima porzione.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Imposta stile di testo predefinito**

Per applicare la formattazione di testo predefinita a livello di presentazione, utilizza [Presentation.default_text_style](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/default_text_style/).

Il seguente esempio imposta un font in grassetto da 14 punti come predefinito per i paragrafi di livello superiore in una nuova presentazione e lo salva in "default_text_style.pptx". Il testo può ereditare questi valori predefiniti a meno che una formattazione più specifica non li sovrascriva.

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

## **Estrai il testo con l'effetto Tutte Maiuscole**

In PowerPoint, l'applicazione dell'effetto carattere **All Caps** fa apparire il testo in maiuscolo nella diapositiva anche se è stato digitato originariamente in minuscolo. Quando si recupera una tale parte di testo con Aspose.Slides, la libreria restituisce il testo esattamente come è stato inserito. Per corrispondere al testo visualizzato, controlla [TextCapType](https://reference.aspose.com/slides/it/python-net/aspose.slides/textcaptype/) e converte la stringa restituita in maiuscolo quando il valore è `ALL`.

Questo esempio richiede "sample2.pptx" con una casella di testo come prima forma della prima diapositiva. La prima parte del primo paragrafo contiene "Hello, Aspose!" con l'effetto All Caps applicato, come mostrato di seguito.

![L'effetto All Caps](all_caps_effect.png)

L'esempio di codice seguente mostra come estrarre il testo con l'effetto **All Caps** applicato:

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

Per modificare il testo in una tabella su una diapositiva, utilizza [Table](https://reference.aspose.com/slides/it/python-net/aspose.slides/table/). Itera tra le celle e aggiorna ciascuna cella tramite [Cell.text_frame](https://reference.aspose.com/slides/it/python-net/aspose.slides/cell/text_frame/) e la formattazione del paragrafo tramite [Paragraph.paragraph_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/paragraph_format/).

**Come applico un colore gradiente al testo su una diapositiva PowerPoint?**

Per applicare un colore gradiente al testo, utilizza [BasePortionFormat.fill_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseportionformat/fill_format/). Imposta [FillFormat.fill_type](https://reference.aspose.com/slides/it/python-net/aspose.slides/fillformat/fill_type/) su [FillType.GRADIENT](https://reference.aspose.com/slides/it/python-net/aspose.slides/filltype/) e configura le fermate del gradiente, la direzione e la trasparenza.