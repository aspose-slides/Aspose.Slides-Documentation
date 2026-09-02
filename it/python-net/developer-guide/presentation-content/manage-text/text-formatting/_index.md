---
title: Formatta il testo della presentazione in Python
linktitle: Formattazione del testo
type: docs
weight: 50
url: /it/python-net/text-formatting/
keywords:
- allinea paragrafo
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
- ancoraggio del riquadro di testo
- tabulazione del testo
- lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Formatta e aggiungi stile al testo in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Python via .NET. Personalizza caratteri, colori, allineamento e altro."
---
## **Panoramica**

Questo articolo mostra come formattare il testo nelle presentazioni PowerPoint e OpenDocument usando Aspose.Slides per Python via .NET. Copre i colori di sfondo, la trasparenza, la spaziatura dei caratteri, le proprietà dei caratteri, la rotazione, la spaziatura dei paragrafi, il comportamento di adattamento automatico, l'ancoraggio del testo, le tabulazioni e le impostazioni della lingua.

Negli esempi seguenti, utilizzeremo un file chiamato "sample.pptx", che contiene una singola casella di testo nella prima diapositiva con il seguente testo:

![Testo di esempio](sample_text.png)

Per trovare e evidenziare testo letterale o corrispondenze di espressioni regolari, vedi [Cerca e sostituisci testo](/slides/it/python-net/search-and-replace-text/).

## **Imposta colore di sfondo del testo**

Usa [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/default_portion_format/) per impostare il colore di evidenziazione predefinito per un paragrafo, oppure usa [PortionFormat.highlight_color](https://reference.aspose.com/slides/it/python-net/aspose.slides/portionformat/highlight_color/) per singole porzioni di testo.

Il seguente esempio di codice mostra come impostare il colore di sfondo per il **intero paragrafo**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Imposta il colore di evidenziazione per l'intero paragrafo.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Il paragrafo grigio](gray_paragraph.png)

L'esempio di codice sotto dimostra come impostare il colore di sfondo per **porzioni di testo con un carattere in grassetto**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Imposta il colore di evidenziazione per la porzione di testo.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Le porzioni di testo grigie](gray_text_portions.png)

## **Allinea paragrafi di testo**

Usa [ParagraphFormat.alignment](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/alignment/) per impostare l'allineamento del paragrafo all'interno di un riquadro di testo. Il valore può essere centrato, allineato a sinistra, allineato a destra, giustificato, ecc.

Il seguente esempio di codice mostra come allineare il paragrafo al **centro**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Imposta l'allineamento del paragrafo al centro.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Il paragrafo allineato](aligned_paragraph.png)

## **Imposta trasparenza per il testo**

La trasparenza del testo è controllata tramite la componente alfa del colore assegnato a [PortionFormat.fill_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/portionformat/fill_format/). Negli esempi seguenti, `alpha = 50` è un valore alfa ARGB su scala 0-255, non una percentuale di trasparenza.

L'esempio di codice sotto mostra come applicare la trasparenza al **intero paragrafo**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Imposta il colore di riempimento del testo al colore trasparente.
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
    auto_shape = presentation.slides[0].shapes[0]
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

Usa [BasePortionFormat.spacing](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseportionformat/spacing/) per espandere o comprimere la spaziatura tra i caratteri in una casella di testo.

Il seguente codice Python mostra come espandere la spaziatura dei caratteri nel **intero paragrafo**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Nota: Usa valori negativi per comprimere la spaziatura dei caratteri.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Espandi la spaziatura dei caratteri.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![La spaziatura dei caratteri nel paragrafo](character_spacing_in_paragraph.png)

L'esempio di codice sotto mostra come espandere la spaziatura dei caratteri in **porzioni di testo con un carattere in grassetto**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Nota: Usa valori negativi per comprimere la spaziatura dei caratteri.
            portion.portion_format.spacing = 3  # Espandi la spaziatura dei caratteri.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![La spaziatura dei caratteri nelle porzioni di testo](character_spacing_in_text_portions.png)

### **Disattiva Kerning per caratteri specifici**

In alcuni casi, il testo renderizzato da Aspose.Slides può apparire leggermente più stretto rispetto allo stesso testo visualizzato in PowerPoint. Questo può accadere perché PowerPoint può ignorare i dati di kerning per determinati caratteri, anche quando il carattere contiene informazioni di kerning valide e il kerning è abilitato nelle impostazioni di PowerPoint.

Per rendere l'output renderizzato più vicino a PowerPoint in tali casi, è possibile disattivare il kerning per le porzioni di testo che utilizzano il carattere interessato. Imposta [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) a un valore significativamente più grande della dimensione effettiva del carattere:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            latin_font = portion.portion_format.latin_font
            east_asian_font = portion.portion_format.east_asian_font
            complex_script_font = portion.portion_format.complex_script_font

            if ((latin_font is not None and latin_font.font_name == target_font) or
                    (east_asian_font is not None and east_asian_font.font_name == target_font) or
                    (complex_script_font is not None and complex_script_font.font_name == target_font)):
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Gestisci proprietà dei caratteri del testo**

Le proprietà dei caratteri possono essere impostate a livello di paragrafo tramite [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/default_portion_format/) o su singole porzioni tramite [PortionFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/portionformat/).

Il codice seguente imposta il carattere e lo stile del testo per l'intero paragrafo: applica dimensione, grassetto, corsivo, sottolineatura puntinata e il carattere Times New Roman a tutte le porzioni del paragrafo.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Imposta le proprietà del carattere per il paragrafo.
    paragraph.paragraph_format.default_portion_format.font_height = 12
    paragraph.paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_italic = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_underline = slides.TextUnderlineType.DOTTED
    paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Le proprietà del carattere per il paragrafo](font_properties_for_paragraph.png)

L'esempio di codice sotto applica proprietà simili a **porzioni di testo con un carattere in grassetto**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Imposta le proprietà del carattere per la porzione di testo.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Le proprietà del carattere per le porzioni di testo](font_properties_for_text_portions.png)

## **Imposta rotazione del testo**

Usa [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/text_vertical_type/) per impostare un orientamento predefinito del testo all'interno di una forma.

Il seguente esempio di codice imposta l'orientamento del testo nella forma su `VERTICAL270`, che ruota il testo **di 90 gradi in senso antiorario**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![La rotazione del testo](text_rotation.png)

## **Imposta rotazione personalizzata per i riquadri di testo**

Usa [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/rotation_angle/) per impostare un angolo di rotazione personalizzato per un [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/).

L'esempio di codice sotto ruota il riquadro di testo di 3 gradi in senso orario all'interno della forma:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![La rotazione personalizzata del testo](custom_text_rotation.png)

## **Imposta interlinea dei paragrafi**

Aspose.Slides fornisce [ParagraphFormat.space_after](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/space_before/), e [ParagraphFormat.space_within](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/space_within/) per controllare la spaziatura dei paragrafi. Queste proprietà si usano come segue:

* Usa un valore positivo per specificare l'interlinea come percentuale dell'altezza della linea.
* Usa un valore negativo per specificare l'interlinea in punti.

Il seguente esempio di codice mostra come specificare l'interlinea all'interno del paragrafo:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![L'interlinea all'interno del paragrafo](line_spacing.png)

## **Imposta tipo di adattamento automatico per i riquadri di testo**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/autofit_type/) determina come il testo si comporta quando supera i limiti del contenitore. Usalo per controllare se il testo si riduce, trabocca o ridimensiona automaticamente la forma.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta ancoraggio dei riquadri di testo**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/anchoring_type/) definisce come il testo è posizionato verticalmente all'interno di una forma, ad esempio in alto, al centro o in basso.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta tabulazione del testo**

Usa [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/default_tab_size/) e [ParagraphFormat.tabs](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/tabs/) per configurare le tabulazioni in un paragrafo.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Le tabulazioni del paragrafo](paragraph_tabs.png)

## **Imposta lingua di correzione**

Aspose.Slides fornisce [PortionFormat.language_id](https://reference.aspose.com/slides/it/python-net/aspose.slides/portionformat/language_id/), che consente di impostare la lingua di correzione per una porzione di testo. La lingua di correzione determina la lingua usata per i controlli ortografici e grammaticali in PowerPoint.

Il seguente esempio di codice mostra come impostare la lingua di correzione per una porzione di testo:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # Imposta l'Id di una lingua di correzione.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta lingua predefinita**

Usa [LoadOptions.default_text_language](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/default_text_language/) per definire la lingua predefinita per il testo creato durante il caricamento o la creazione di una presentazione.

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

## **Imposta stile di testo predefinito**

Per applicare una formattazione di testo predefinita a livello di presentazione, usa [Presentation.default_text_style](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/default_text_style/).

Il seguente esempio di codice mostra come impostare un carattere in grassetto predefinito con dimensione 14 pt per tutto il testo nelle diapositive di una nuova presentazione.

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

## **Estrai testo con effetto tutto maiuscolo**

In PowerPoint, applicare l'effetto **All Caps** al carattere fa apparire il testo in maiuscolo sulla diapositiva anche se è stato digitato originariamente in minuscolo. Quando recuperi una tale porzione di testo con Aspose.Slides, la libreria restituisce il testo esattamente come inserito. Per corrispondere al testo visualizzato, verifica [TextCapType](https://reference.aspose.com/slides/it/python-net/aspose.slides/textcaptype/) e converti la stringa restituita in maiuscolo quando il valore è `ALL`.

Supponiamo di avere la seguente casella di testo nella prima diapositiva del file sample2.pptx.

![L'effetto tutto maiuscolo](all_caps_effect.png)

Il codice seguente mostra come estrarre il testo con l'effetto **All Caps** applicato:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

**Come modificare il testo in una tabella su una diapositiva?**

Per modificare il testo in una tabella su una diapositiva, usa [Table](https://reference.aspose.com/slides/it/python-net/aspose.slides/table/). Itera attraverso le celle e aggiorna ciascuna cella tramite [Cell.text_frame](https://reference.aspose.com/slides/it/python-net/aspose.slides/cell/text_frame/) e la formattazione del paragrafo tramite [Paragraph.paragraph_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/paragraph_format/).

**Come applicare un colore sfumato al testo in una diapositiva PowerPoint?**

Per applicare un colore sfumato al testo, usa [PortionFormat.fill_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/portionformat/fill_format/). Imposta [FillFormat.fill_type](https://reference.aspose.com/slides/it/python-net/aspose.slides/fillformat/fill_type/) su [FillType.GRADIENT](https://reference.aspose.com/slides/it/python-net/aspose.slides/filltype/) e configura le fermate del gradiente, la direzione e la trasparenza.