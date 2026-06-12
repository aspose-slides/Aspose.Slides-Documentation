---
title: Ottieni le proprietà efficaci delle forme dalle presentazioni con Python
linktitle: Proprietà efficaci
type: docs
weight: 50
url: /it/python-net/shape-effective-properties/
keywords:
- proprietà della forma
- proprietà della fotocamera
- rig di luce
- forma con smusso
- riquadro di testo
- stile di testo
- altezza del carattere
- formato di riempimento
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Scopri come Aspose.Slides per Python via .NET calcola e applica le proprietà efficaci delle forme per una resa precisa di PowerPoint."
---
## **Panoramica**

Questo argomento spiega la differenza tra proprietà **locali** e **efficaci**. I valori locali sono valori impostati direttamente a un livello di formattazione specifico, ad esempio:

1. Proprietà della porzione su una diapositiva.
1. Stili di testo della forma prototipo in un layout o nella diapositiva master, quando la forma del riquadro di testo della porzione ne ha uno.
1. Impostazioni globali del testo in una presentazione.

I valori locali possono essere definiti o omessi a qualsiasi livello. Quando Aspose.Slides necessita della formattazione finale “come resa”, risolve la catena di ereditarietà e restituisce i valori **efficaci**. È possibile ottenerli chiamando il metodo `get_effective` sull'oggetto di formattazione locale.

Il seguente esempio mostra come ottenere i valori efficaci. Si assume che la prima forma sulla prima diapositiva sia un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) con un riquadro di testo e almeno una porzione.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    paragraph = shape.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    local_portion_format = portion.portion_format
    effective_portion_format = local_portion_format.get_effective()
```

{{% alert color="primary" %}}
I dati di formattazione efficaci rappresentano la formattazione calcolata corrente dopo l'applicazione dell'ereditarietà. Nell'implementazione attuale, alcuni oggetti di dati efficaci, come [IPortionFormatEffectiveData](https://reference.aspose.com/slides/it/python-net/aspose.slides/iportionformateffectivedata/), possono essere memorizzati nella cache internamente. Richiamare nuovamente `get_effective` dopo aver modificato la formattazione genitore o ereditata può aggiornare i dati nella cache, e un oggetto precedentemente ottenuto potrebbe non rappresentare più lo stato precedente. Se è necessario conservare i valori efficaci per un utilizzo successivo, copiare le proprietà richieste, come altezza del carattere, colore di riempimento, stile del carattere o allineamento, nel proprio oggetto dati.
{{% /alert %}}

## **Ottenere le proprietà efficaci di una Camera**

Aspose.Slides consente di ottenere le proprietà efficaci di una fotocamera. Il tipo [ICameraEffectiveData](https://reference.aspose.com/slides/it/python-net/aspose.slides/icameraeffectivedata/) rappresenta un oggetto immutabile che contiene le proprietà efficaci della fotocamera. Un'istanza di [ICameraEffectiveData](https://reference.aspose.com/slides/it/python-net/aspose.slides/icameraeffectivedata/) è esposta tramite [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/it/python-net/aspose.slides/ithreedformateffectivedata/), che fornisce valori efficaci per [ThreeDFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/).

Il seguente esempio di codice mostra come ottenere le proprietà efficaci per la fotocamera. Si assume che la prima forma sulla prima diapositiva abbia una formattazione 3D.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    camera = three_d_effective_data.camera

    camera_type = camera.camera_type
    field_of_view_angle = camera.field_of_view_angle
    zoom = camera.zoom

    print("= Effective camera properties =")
    print("Type: " + str(camera_type))
    print("Field of view: " + str(field_of_view_angle))
    print("Zoom: " + str(zoom))
```

## **Ottenere le proprietà efficaci di un rig di luce**

Aspose.Slides consente di ottenere le proprietà efficaci di un rig di luce. Il tipo [ILightRigEffectiveData](https://reference.aspose.com/slides/it/python-net/aspose.slides/ilightrigeffectivedata/) rappresenta un oggetto immutabile che contiene le proprietà efficaci del rig di luce. Un'istanza di [ILightRigEffectiveData](https://reference.aspose.com/slides/it/python-net/aspose.slides/ilightrigeffectivedata/) è esposta tramite [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/it/python-net/aspose.slides/ithreedformateffectivedata/), che fornisce valori efficaci per [ThreeDFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/).

Il seguente esempio di codice mostra come ottenere le proprietà efficaci per il rig di luce. Si assume che la prima forma sulla prima diapositiva abbia una formattazione 3D.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    light_rig = three_d_effective_data.light_rig

    light_type = light_rig.light_type
    direction = light_rig.direction

    print("= Effective light rig properties =")
    print("Type: " + str(light_type))
    print("Direction: " + str(direction))
```

## **Ottenere le proprietà efficaci di una forma con smusso**

Aspose.Slides consente di ottenere le proprietà efficaci di uno smusso di forma. Il tipo [IShapeBevelEffectiveData](https://reference.aspose.com/slides/it/python-net/aspose.slides/ishapebeveleffectivedata/) rappresenta un oggetto immutabile che contiene le proprietà efficaci di rilievo della faccia per una forma. Un'istanza di [IShapeBevelEffectiveData](https://reference.aspose.com/slides/it/python-net/aspose.slides/ishapebeveleffectivedata/) è esposta tramite [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/it/python-net/aspose.slides/ithreedformateffectivedata/), che fornisce valori efficaci per [ThreeDFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/).

Il seguente esempio di codice mostra come ottenere le proprietà efficaci per lo smusso superiore di una forma. Si assume che la prima forma sulla prima diapositiva abbia una formattazione 3D.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    top_bevel = three_d_effective_data.bevel_top

    bevel_type = top_bevel.bevel_type
    bevel_width = top_bevel.width
    bevel_height = top_bevel.height

    print("= Effective shape's top face relief properties =")
    print("Type: " + str(bevel_type))
    print("Width: " + str(bevel_width))
    print("Height: " + str(bevel_height))
```

## **Ottenere le proprietà efficaci di un riquadro di testo**

Utilizzando Aspose.Slides, è possibile ottenere le proprietà efficaci di un riquadro di testo. Il tipo [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/it/python-net/aspose.slides/itextframeformateffectivedata/) contiene le proprietà di formattazione efficaci del riquadro di testo.

Il seguente esempio di codice mostra come ottenere le proprietà di formattazione efficaci del riquadro di testo. Si assume che la prima forma sulla prima diapositiva sia un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) con un riquadro di testo.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = text_frame_format.get_effective()

    anchoring_type = effective_text_frame_format.anchoring_type
    autofit_type = effective_text_frame_format.autofit_type
    text_vertical_type = effective_text_frame_format.text_vertical_type
    margin_left = effective_text_frame_format.margin_left
    margin_top = effective_text_frame_format.margin_top
    margin_right = effective_text_frame_format.margin_right
    margin_bottom = effective_text_frame_format.margin_bottom

    print("Anchoring type: " + str(anchoring_type))
    print("Autofit type: " + str(autofit_type))
    print("Text vertical type: " + str(text_vertical_type))
    print("Margins")
    print("   Left: " + str(margin_left))
    print("   Top: " + str(margin_top))
    print("   Right: " + str(margin_right))
    print("   Bottom: " + str(margin_bottom))
```

## **Ottenere le proprietà efficaci di uno stile di testo**

Utilizzando Aspose.Slides, è possibile ottenere le proprietà efficaci di uno stile di testo. Il tipo [ITextStyleEffectiveData](https://reference.aspose.com/slides/it/python-net/aspose.slides/itextstyleeffectivedata/) contiene le proprietà efficaci dello stile di testo.

Il seguente esempio di codice mostra come ottenere le proprietà efficaci dello stile di testo. Si assume che la prima forma sulla prima diapositiva sia un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) con un riquadro di testo.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame_format = shape.text_frame.text_frame_format
    text_style = text_frame_format.text_style
    effective_text_style = text_style.get_effective()
    level_count = 9

    for level_index in range(level_count):
        effective_style_level = effective_text_style.get_level(level_index)
        depth = effective_style_level.depth
        indent = effective_style_level.indent
        alignment = effective_style_level.alignment
        font_alignment = effective_style_level.font_alignment

        print("= Effective paragraph formatting for style level #" + str(level_index) + " =")

        print("Depth: " + str(depth))
        print("Indent: " + str(indent))
        print("Alignment: " + str(alignment))
        print("Font alignment: " + str(font_alignment))
```

## **Ottenere il valore efficace dell'altezza del carattere**

Utilizzando Aspose.Slides, è possibile ottenere l'altezza efficace del carattere. Il codice seguente dimostra come l'altezza efficace del carattere di una porzione cambi dopo che i valori locali dell'altezza del carattere sono impostati a diversi livelli della struttura della presentazione.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)
    auto_shape.add_text_frame("")

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    first_portion = slides.Portion("Sample text with first portion")
    second_portion = slides.Portion(" and second portion.")

    paragraph.portions.add(first_portion)
    paragraph.portions.add(second_portion)

    print("Effective font height just after creation:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    default_text_style_level = presentation.default_text_style.get_level(0)
    default_text_style_level.default_portion_format.font_height = 24

    print("Effective font height after setting the presentation default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Effective font height after setting paragraph default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    first_portion.portion_format.font_height = 55

    print("Effective font height after setting portion #0 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    second_portion.portion_format.font_height = 18

    print("Effective font height after setting portion #1 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    presentation.save("SetLocalFontHeightValues.pptx", slides.export.SaveFormat.PPTX)
```

## **Ottenere il formato di riempimento efficace per una tabella**

Utilizzando Aspose.Slides, è possibile ottenere la formattazione di riempimento efficace per diverse parti della tabella. Il tipo [IFillFormatEffectiveData](https://reference.aspose.com/slides/it/python-net/aspose.slides/ifillformateffectivedata/) contiene le proprietà di formattazione di riempimento efficaci. La formattazione delle celle ha priorità maggiore rispetto alla formattazione delle righe, la formattazione delle righe ha priorità maggiore rispetto alla formattazione delle colonne, e la formattazione delle colonne ha priorità maggiore rispetto alla formattazione dell'intera tabella.

Di conseguenza, le proprietà di [ICellFormatEffectiveData](https://reference.aspose.com/slides/it/python-net/aspose.slides/icellformateffectivedata/) vengono utilizzate per disegnare la cella della tabella. Il seguente esempio di codice mostra come ottenere la formattazione di riempimento efficace per diverse parti della tabella. Si assume che la prima forma sulla prima diapositiva sia una [Table](https://reference.aspose.com/slides/it/python-net/aspose.slides/table/).

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    first_row = table.rows[0]
    first_column = table.columns[0]
    first_cell = first_row[0]

    table_format_effective = table.table_format.get_effective()
    row_format_effective = first_row.row_format.get_effective()
    column_format_effective = first_column.column_format.get_effective()
    cell_format_effective = first_cell.cell_format.get_effective()

    table_fill_format_effective = table_format_effective.fill_format
    row_fill_format_effective = row_format_effective.fill_format
    column_fill_format_effective = column_format_effective.fill_format
    cell_fill_format_effective = cell_format_effective.fill_format
```

## **FAQ**

**Restituisce `get_effective` un'istantanea?**

Non sempre. I dati efficaci rappresentano la formattazione calcolata dopo l'applicazione dell'ereditarietà, ma alcuni oggetti di dati efficaci possono essere memorizzati nella cache internamente. Una chiamata successiva a `get_effective` può ricalcolare la formattazione e aggiornare i dati nella cache, quindi un oggetto ottenuto in precedenza non dovrebbe essere considerato un'istantanea duratura.

**Quando dovrei leggere nuovamente le proprietà efficaci?**

Richiama `get_effective` nuovamente dopo aver modificato la formattazione locale, gli stili genitore, la formattazione del layout, la formattazione master o le impostazioni predefinite a livello di presentazione. La chiamata successiva rivaluta la gerarchia della formattazione e restituisce il risultato efficace corrente.

**Modificare o rimuovere una diapositiva layout/master influisce sulle proprietà efficaci già recuperate?**

Sì, ma la modifica è riflessa nella successiva chiamata a `get_effective`. Se una fonte di formattazione genitore viene modificata o rimossa, i dati efficaci ottenuti in precedenza possono diventare obsoleti. Dopo aver richiamato nuovamente `get_effective`, Aspose.Slides rivaluta l'albero di formattazione e i caratteri, i colori, le dimensioni o altri valori risultanti possono cambiare.

**Posso modificare i valori tramite gli oggetti di dati efficaci?**

No. Gli oggetti di dati efficaci espongono i valori calcolati. Apporta le modifiche negli oggetti di formattazione locali, quindi ottieni nuovamente i valori efficaci.

**Cosa succede se una proprietà non è impostata a livello di forma, né nel layout/master, né nelle impostazioni globali?**

Il valore efficace è determinato dal meccanismo predefinito, che include le impostazioni predefinite di PowerPoint e Aspose.Slides. Quel valore risolto diventa parte dei dati efficaci correnti.

**Da un valore efficace del carattere, posso capire a quale livello è stata fornita la dimensione o il tipo di carattere?**

Non direttamente. I dati efficaci restituiscono il valore finale. Per trovare la fonte, verifica i valori locali nella porzione, nel paragrafo, nel riquadro di testo e negli stili di testo a livello di layout, master e presentazione per vedere dove appare la prima definizione esplicita.

**Perché i valori efficaci a volte appaiono identici a quelli locali?**

Perché il valore locale è risultato finale (non è stata necessaria alcuna ereditarietà a un livello superiore). In tali casi, il valore efficace corrisponde a quello locale.

**Quando dovrei usare le proprietà efficaci e quando dovrei lavorare solo con quelle locali?**

Utilizza i dati efficaci quando hai bisogno del risultato "come renderizzato" dopo l'applicazione di tutta l'ereditarietà, ad esempio per allineare colori, rientri o dimensioni. Se devi conservare tali valori indipendentemente dalle successive modifiche di formattazione, copia le proprietà richieste nel tuo oggetto. Se devi modificare la formattazione a un livello specifico, modifica le proprietà locali e quindi, se necessario, leggi nuovamente i dati efficaci per verificare il risultato.