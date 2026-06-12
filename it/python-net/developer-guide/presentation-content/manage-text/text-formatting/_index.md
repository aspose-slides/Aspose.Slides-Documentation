---
title: Formattare il testo della presentazione in Python
linktitle: Formattazione del testo
type: docs
weight: 50
url: /it/python-net/text-formatting/
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
- proprietà autofit
- ancora del frame di testo
- tabulazione del testo
- lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Formattare e stilizzare il testo in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Python tramite .NET. Personalizza caratteri, colori, allineamento e altro."
---
## **Panoramica**

Questo articolo mostra come formattare il testo nelle presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Python tramite .NET. Copre evidenziazione, colori di sfondo, trasparenza, spaziatura dei caratteri, proprietà del carattere, rotazione, spaziatura dei paragrafi, comportamento di autofit, ancoraggio del testo, tabulazioni e impostazioni della lingua.

Negli esempi seguenti, useremo un file denominato "sample.pptx", che contiene una singola casella di testo nella prima diapositiva con il seguente contenuto:

![Testo di esempio](sample_text.png)

## **Evidenziare il testo**

Utilizza il metodo [TextFrame.highlight_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/highlight_text/) quando è necessario evidenziare il testo che corrisponde a un campione specifico all'interno di un frame di testo. Il metodo applica un colore di evidenziazione ai frammenti di testo corrispondenti e può essere usato con [TextSearchOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides/textsearchoptions/) per controllare come viene eseguita la ricerca, ad esempio per corrispondere solo parole intere.

L'esempio di codice seguente evidenzia tutte le occorrenze dei caratteri **"try"** e poi evidenzia solo la parola intera **"to"**.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Ottieni la prima forma dalla prima diapositiva.
    shape = presentation.slides[0].shapes[0]

    # Evidenzia la parola "try" nella forma.
    shape.text_frame.highlight_text("try", draw.Color.light_blue)

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True

    # Evidenzia la parola "to" nella forma.
    shape.text_frame.highlight_text("to", draw.Color.violet, search_options, None)

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Il testo evidenziato](highlighted_text.png)

## **Evidenziare il testo usando le espressioni regolari**

Il metodo [TextFrame.highlight_regex](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/highlight_regex/) evidenzia le corrispondenze di testo trovate da un'espressione regolare. In Python, questa API è esposta su [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/).

L'esempio di codice seguente evidenzia tutte le parole che contengono **sette o più caratteri**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    regex = r"\b[^\s]{7,}\b"

    # Evidenzia tutte le parole con sette o più caratteri.
    shape.text_frame.highlight_regex(regex, draw.Color.yellow, None)

    presentation.save("highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Il testo evidenziato usando l'espressione regolare](highlighted_text_using_regex.png)

## **Impostare il colore di sfondo del testo**

Usa [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/default_portion_format/) per impostare il colore di evidenziazione predefinito per un paragrafo, oppure usa [PortionFormat.highlight_color](https://reference.aspose.com/slides/it/python-net/aspose.slides/portionformat/highlight_color/) per singole parti di testo.

Il seguente esempio di codice mostra come impostare il colore di sfondo per il **paragrafo intero**:

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

L'esempio di codice seguente dimostra come impostare il colore di sfondo per **porzioni di testo con un carattere in grassetto**:

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

## **Allineare i paragrafi di testo**

Usa [ParagraphFormat.alignment](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/alignment/) per impostare l'allineamento del paragrafo all'interno di un frame di testo. Il valore può essere centrato, allineato a sinistra, a destra, giustificato, ecc.

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

## **Impostare la trasparenza per il testo**

La trasparenza del testo è controllata tramite la componente alfa del colore assegnato a [PortionFormat.fill_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/portionformat/fill_format/). Negli esempi seguenti, `alpha = 50` è un valore del canale alfa ARGB su scala 0‑255, non una percentuale di trasparenza.

L'esempio di codice seguente mostra come applicare la trasparenza al **paragrafo intero**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Imposta il colore di riempimento del testo su colore trasparente.
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

## **Impostare la spaziatura dei caratteri per il testo**

Usa [BasePortionFormat.spacing](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseportionformat/spacing/) per espandere o ridurre la spaziatura tra i caratteri in una casella di testo.

Il seguente codice Python mostra come espandere la spaziatura dei caratteri nel **paragrafo intero**:

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

L'esempio di codice seguente mostra come espandere la spaziatura dei caratteri in **porzioni di testo con un carattere in grassetto**:

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

### **Disabilitare il kerning per font specifici**

In alcuni casi, il testo renderizzato da Aspose.Slides può apparire leggermente più stretto rispetto allo stesso testo visualizzato in PowerPoint. Ciò può accadere perché PowerPoint può ignorare i dati di kerning per alcuni font, anche quando il font contiene informazioni di kerning valide e il kerning è abilitato nelle impostazioni di PowerPoint.

Per avvicinare il risultato renderizzato a PowerPoint in tali casi, è possibile disabilitare il kerning per le porzioni di testo che usano il font interessato. Imposta [PortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) a un valore significativamente più grande della dimensione reale del font:

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

Questa impostazione impedisce l'applicazione del kerning alle porzioni di testo corrispondenti e può aiutare ad allineare il rendering di Aspose.Slides a quello visivo di PowerPoint per i font colpiti da questo comportamento specifico di PowerPoint.

## **Gestire le proprietà del carattere del testo**

Le proprietà del carattere possono essere impostate a livello di paragrafo tramite [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/default_portion_format/) o su singole porzioni tramite [PortionFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/portionformat/).

Il seguente codice imposta il carattere e lo stile del testo per l'intero paragrafo: applica la dimensione del carattere, il grassetto, il corsivo, la sottolineatura puntinata e il font Times New Roman a tutte le porzioni del paragrafo.

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

L'esempio di codice seguente applica proprietà simili a **porzioni di testo con un carattere in grassetto**:

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

## **Impostare la rotazione del testo**

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

## **Impostare una rotazione personalizzata per i frame di testo**

Usa [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/rotation_angle/) per impostare un angolo di rotazione personalizzato per un [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/).

L'esempio di codice seguente ruota il frame di testo di 3 gradi in senso orario all'interno della forma:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![La rotazione personalizzata del testo](custom_text_rotation.png)

## **Impostare l'interlinea dei paragrafi**

Aspose.Slides fornisce [ParagraphFormat.space_after](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/space_before/) e [ParagraphFormat.space_within](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraphformat/space_within/) per controllare la spaziatura dei paragrafi. Queste proprietà vengono usate così:

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

## **Impostare il tipo di Autofit per i frame di testo**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/autofit_type/) determina come il testo si comporta quando supera i confini del suo contenitore. Usalo per controllare se il testo si riduce, trabocca o ridimensiona automaticamente la forma.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

## **Impostare l'ancora dei frame di testo**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/anchoring_type/) definisce come il testo è posizionato verticalmente all'interno di una forma, ad esempio in alto, al centro o in basso.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Impostare la tabulazione del testo**

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

## **Impostare la lingua di correzione**

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

    text_portion.text = "1."
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Impostare la lingua predefinita**

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

## **Impostare lo stile di testo predefinito**

Per applicare la formattazione di testo predefinita a livello di presentazione, usa [Presentation.default_text_style](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/default_text_style/).

Il seguente esempio di codice mostra come impostare un carattere in grassetto con dimensione 14 pt per tutto il testo di tutte le diapositive in una nuova presentazione.

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

## **Estrarre il testo con l'effetto Tutte le lettere maiuscole**

In PowerPoint, l'applicazione dell'effetto **All Caps** (tutte le lettere maiuscole) fa apparire il testo in maiuscolo nella diapositiva anche quando è stato digitato originalmente in minuscolo. Quando si recupera una tale porzione di testo con Aspose.Slides, la libreria restituisce il testo esattamente come è stato inserito. Per corrispondere al testo visualizzato, verifica [TextCapType](https://reference.aspose.com/slides/it/python-net/aspose.slides/textcaptype/) e converti la stringa restituita in maiuscolo quando il valore è `ALL`.

Supponiamo di avere la seguente casella di testo nella prima diapositiva del file sample2.pptx.

![L'effetto All Caps](all_caps_effect.png)

L'esempio di codice seguente mostra come estrarre il testo con l'effetto **All Caps** applicato:

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

Per modificare il testo in una tabella su una diapositiva, usa [Table](https://reference.aspose.com/slides/it/python-net/aspose.slides/table/). Itera attraverso le celle e aggiorna ogni cella tramite [Cell.text_frame](https://reference.aspose.com/slides/it/python-net/aspose.slides/cell/text_frame/) e la formattazione del paragrafo tramite [Paragraph.paragraph_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/paragraph_format/).

**Come applicare un colore sfumato al testo in una diapositiva PowerPoint?**

Per applicare un colore sfumato al testo, usa [PortionFormat.fill_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/portionformat/fill_format/). Imposta [FillFormat.fill_type](https://reference.aspose.com/slides/it/python-net/aspose.slides/fillformat/fill_type/) su [FillType.GRADIENT](https://reference.aspose.com/slides/it/python-net/aspose.slides/filltype/) e configura le fermate della sfumatura, la direzione e la trasparenza.