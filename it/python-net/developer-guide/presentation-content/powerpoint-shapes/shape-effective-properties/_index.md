---
title: Ottenere le proprietà efficaci della forma dalle presentazioni in Python
linktitle: Proprietà efficaci
type: docs
weight: 50
url: /it/python-net/shape-effective-properties/
keywords:
- proprietà della forma
- proprietà della fotocamera
- impianto di illuminazione
- forma smussata
- frame di testo
- stile di testo
- altezza carattere
- formato di riempimento
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Scopri come utilizzare Aspose.Slides per Python tramite .NET per distinguere la formattazione locale, ereditata ed efficace delle forme nelle presentazioni PowerPoint."
---
## **Comprendere le proprietà locali, ereditate ed efficaci**

La formattazione di PowerPoint può provenire da diversi luoghi. Il valore memorizzato direttamente su un oggetto è il suo **valore locale**. Se tale valore non è impostato, PowerPoint consulta le sorgenti di formattazione genitore, come il valore predefinito di un paragrafo, uno stile di testo, un layout o una diapositiva master, un tema o i valori predefiniti a livello di presentazione. Quei valori sono **valori ereditati**. Il valore che rimane dopo che l'intera gerarchia è risolta è il **valore efficace**, che è usato per rendere l'oggetto.

Ad esempio, una porzione di testo potrebbe non definire la propria altezza del carattere. Il suo [font_height](https://reference.aspose.com/slides/it/python-net/aspose.slides/ibaseportionformat/font_height/) locale è allora `float("nan")`, il che significa "non impostato qui". La porzione può ereditare un'altezza dal suo paragrafo, dallo stile di testo predefinito della presentazione o da un'altra fonte applicabile. Chiamando [get_effective](https://reference.aspose.com/slides/it/python-net/aspose.slides/iportionformat/get_effective/) sul formato della porzione si ottiene l'altezza finale risolta.

Usa i due tipi di dati di formattazione per scopi diversi:

- Leggi o modifica un oggetto di formato locale, come [IPortionFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/iportionformat/), quando è necessario controllare dove è definito un valore.
- Leggi un oggetto di dati efficace, come [IPortionFormatEffectiveData](https://reference.aspose.com/slides/it/python-net/aspose.slides/iportionformateffectivedata/), quando è necessario il risultato finale renderizzato. I dati efficaci sono di sola lettura.

## **Confrontare valori locali, ereditati e efficaci**

Il seguente esempio completo crea una forma e applica altezze del carattere a livello di presentazione, paragrafo e porzione. Ogni passaggio stampa i valori definiti a quei livelli e il valore efficace risultante per la stessa porzione di testo. Dimostra anche perché i dati efficaci devono essere letti nuovamente dopo le modifiche alla formattazione.

```python
import math

import aspose.slides as slides


def format_local_value(value):
    return "<not set>" if math.isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.default_text_style.get_level(0).default_portion_format.font_height
    paragraph_value = paragraph.paragraph_format.default_portion_format.font_height
    local_value = portion.portion_format.font_height

    # Leggi i dati efficaci dopo le modifiche precedenti.
    effective_value = portion.portion_format.get_effective().font_height

    print(caption)
    print("  Presentation default: " + format_local_value(presentation_value))
    print("  Paragraph default:    " + format_local_value(paragraph_value))
    print("  Portion local:        " + format_local_value(local_value))
    print("  Portion effective:    " + str(effective_value))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 80, False)
    text_frame = shape.add_text_frame("Effective formatting")
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    # Definisci i valori ereditati a due livelli diversi.
    presentation.default_text_style.get_level(0).default_portion_format.font_height = 20
    paragraph.paragraph_format.default_portion_format.font_height = 28

    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # Un valore locale sulla porzione sovrascrive entrambi i valori ereditati.
    portion.portion_format.font_height = 36
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Modificare un valore ereditato non sovrascrive un valore locale esistente.
    paragraph.paragraph_format.default_portion_format.font_height = 30
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Cancella il valore locale. La porzione ora eredita nuovamente dal paragrafo.
    portion.portion_format.font_height = float("nan")
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Cancella il valore del paragrafo. Il valore predefinito della presentazione ora fornisce il risultato.
    paragraph.paragraph_format.default_portion_format.font_height = float("nan")
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", slides.export.SaveFormat.PPTX)
```

La priorità in questo esempio è la formattazione locale della porzione, poi la formattazione del paragrafo, poi il valore predefinito della presentazione. Altri oggetti possono avere catene di ereditarietà diverse, ma il principio è lo stesso: un valore esplicito più specifico vince, e [get_effective](https://reference.aspose.com/slides/it/python-net/aspose.slides/iportionformat/get_effective/) restituisce il risultato finale.

## **Ottenere le proprietà di testo efficaci**

La formattazione del testo è suddivisa tra diversi oggetti:

- [ITextFrameFormat.get_effective()](https://reference.aspose.com/slides/it/python-net/aspose.slides/itextframeformat/get_effective/) risolve le proprietà del frame di testo come margini, ancoraggio, adattamento automatico e direzione verticale del testo.
- [ITextStyle.get_effective()](https://reference.aspose.com/slides/it/python-net/aspose.slides/itextstyle/get_effective/) risolve la formattazione dei paragrafi per ogni livello di stile di testo.
- [IParagraphFormat.get_effective()](https://reference.aspose.com/slides/it/python-net/aspose.slides/iparagraphformat/get_effective/) risolve le proprietà del paragrafo come allineamento, rientro e elenchi puntati.
- [IPortionFormat.get_effective()](https://reference.aspose.com/slides/it/python-net/aspose.slides/iportionformat/get_effective/) risolve le proprietà dei caratteri come altezza del carattere, tipo di carattere, colore, grassetto e corsivo.

Per l'esempio successivo, `text-formatting.pptx` deve contenere almeno una diapositiva e una [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) con un frame di testo non vuoto. L'AutoShape può trovarsi in qualsiasi posizione nella collezione di forme; il codice cerca un oggetto idoneo e lo convalida prima dell'uso.

```python
import aspose.slides as slides


def has_non_empty_text(shape):
    if not isinstance(shape, slides.AutoShape):
        return False
    if shape.text_frame is None:
        return False
    if shape.text_frame.paragraphs.count == 0:
        return False
    return shape.text_frame.paragraphs[0].portions.count > 0


with slides.Presentation("text-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    shape = None
    for candidate in presentation.slides[0].shapes:
        if has_non_empty_text(candidate):
            shape = candidate
            break

    if shape is None:
        raise RuntimeError("The first slide must contain an AutoShape with non-empty text.")

    text_frame = shape.text_frame
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    text_frame_effective = text_frame.text_frame_format.get_effective()
    paragraph_effective = paragraph.paragraph_format.get_effective()
    portion_effective = portion.portion_format.get_effective()

    print("Text frame margins:")
    print("  Left: " + str(text_frame_effective.margin_left))
    print("  Top: " + str(text_frame_effective.margin_top))
    print("  Right: " + str(text_frame_effective.margin_right))
    print("  Bottom: " + str(text_frame_effective.margin_bottom))
    print("Paragraph alignment: " + str(paragraph_effective.alignment))
    print("Font height: " + str(portion_effective.font_height))
    print("Bold: " + str(portion_effective.font_bold))

    effective_text_style = text_frame.text_frame_format.text_style.get_effective()
    for level in range(9):
        level_effective = effective_text_style.get_level(level)
        print("Level " + str(level) + " indent: " + str(level_effective.indent))
```

## **Ottenere le proprietà 3D efficaci**

[IThreeDFormat.get_effective()](https://reference.aspose.com/slides/it/python-net/aspose.slides/ithreedformat/get_effective/) restituisce un oggetto [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/it/python-net/aspose.slides/ithreedformateffectivedata/) che raggruppa tutte le impostazioni 3D risolte. Le sue proprietà [camera](https://reference.aspose.com/slides/it/python-net/aspose.slides/ithreedformateffectivedata/camera/), [light_rig](https://reference.aspose.com/slides/it/python-net/aspose.slides/ithreedformateffectivedata/light_rig/), [bevel_top](https://reference.aspose.com/slides/it/python-net/aspose.slides/ithreedformateffectivedata/bevel_top/) e [bevel_bottom](https://reference.aspose.com/slides/it/python-net/aspose.slides/ithreedformateffectivedata/bevel_bottom/) espongono i relativi dati efficaci. Leggere queste impostazioni correlate insieme facilita la comprensione dell'aspetto 3D finale di una forma.

Per questo esempio, `shape-3d.pptx` deve contenere almeno una forma nella sua prima diapositiva. Applica impostazioni di telecamera 3D, illuminazione o smussatura a quella forma se desideri che l'output contenga valori diversi da quelli predefiniti.

```python
import aspose.slides as slides


with slides.Presentation("shape-3d.pptx") as presentation:
    if presentation.slides.count == 0 or presentation.slides[0].shapes.count == 0:
        raise RuntimeError("The first slide must contain a shape.")

    shape = presentation.slides[0].shapes[0]
    three_d_effective = shape.three_d_format.get_effective()

    print("Camera:")
    print("  Type: " + str(three_d_effective.camera.camera_type))
    print("  Field of view: " + str(three_d_effective.camera.field_of_view_angle))
    print("  Zoom: " + str(three_d_effective.camera.zoom))

    print("Light rig:")
    print("  Type: " + str(three_d_effective.light_rig.light_type))
    print("  Direction: " + str(three_d_effective.light_rig.direction))

    print("Top bevel:")
    print("  Type: " + str(three_d_effective.bevel_top.bevel_type))
    print("  Width: " + str(three_d_effective.bevel_top.width))
    print("  Height: " + str(three_d_effective.bevel_top.height))
```

## **Ottenere la formattazione della tabella efficace**

La formattazione di una tabella può provenire dallo stile della tabella e dai formati applicati all'intera tabella, a una colonna, a una riga o a una singola cella. In caso di conflitti tra riempimenti definiti esplicitamente, la priorità è cella, riga, colonna e infine intera tabella. Il formato efficace di una cella è il formato finale usato per disegnare quella cella.

Per questo esempio, `table-formatting.pptx` deve contenere almeno una tabella nella sua prima diapositiva. La tabella deve avere almeno una riga e una colonna. Il codice cerca una [Table](https://reference.aspose.com/slides/it/python-net/aspose.slides/table/) invece di presumere che `shapes[0]` sia una tabella.

```python
import aspose.slides as slides


with slides.Presentation("table-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    table = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is None:
        raise RuntimeError("The first slide must contain a table.")

    if table.rows.count == 0 or table.columns.count == 0:
        raise RuntimeError("The table must contain at least one cell.")

    table_effective = table.table_format.get_effective()
    row_effective = table.rows[0].row_format.get_effective()
    column_effective = table.columns[0].column_format.get_effective()
    cell_effective = table.rows[0][0].cell_format.get_effective()

    print("Table fill: " + str(table_effective.fill_format.fill_type))
    print("Row fill: " + str(row_effective.fill_format.fill_type))
    print("Column fill: " + str(column_effective.fill_format.fill_type))
    print("Final cell fill: " + str(cell_effective.fill_format.fill_type))
```

Se ti serve il colore anziché solo il tipo di riempimento, controlla prima l'[fill_type](https://reference.aspose.com/slides/it/python-net/aspose.slides/ifillformateffectivedata/fill_type/) efficace, quindi leggi la proprietà corrispondente a quel tipo, ad esempio [solid_fill_color](https://reference.aspose.com/slides/it/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) per un riempimento solido.

## **Rileggere i dati efficaci dopo le modifiche**

I dati efficaci descrivono la gerarchia di formattazione al momento della risoluzione. Richiama nuovamente `get_effective` dopo aver modificato qualsiasi elemento che può partecipare a tale gerarchia, inclusi:

- la formattazione locale dell'oggetto;
- i valori predefiniti di paragrafo o di frame di testo;
- lo stile della tabella, la tabella, il formato di colonna, riga o cella;
- la formattazione del layout o della diapositiva master;
- i dati del tema o i valori predefiniti a livello di presentazione;
- il layout o il master assegnato a una diapositiva.

Non conservare un oggetto di dati efficaci come snapshot permanente. Aspose.Slides può memorizzare nella cache alcuni dati efficaci internamente, e una successiva chiamata a `get_effective` può aggiornare tali dati. Se devi confrontare valori prima e dopo una modifica, copia i valori scalari di cui hai bisogno, come altezza del carattere, colore, allineamento o larghezza dello smusso, nelle tue variabili prima di effettuare la modifica.

Per modificare un valore, aggiorna l'oggetto di formato locale appropriato e poi chiama `get_effective` per verificare il risultato. Gli oggetti di dati efficaci sono di sola lettura.

## **FAQ**

**Come posso capire quale livello ha fornito un valore efficace?**

I dati efficaci contengono il valore finale, non la sua origine. Ispeziona gli oggetti locali applicabili dal livello più specifico verso l'esterno. Per il testo, ciò può includere la porzione, il paragrafo, il frame di testo, il layout, il master, il tema e i valori predefiniti della presentazione. Valori non definiti come `float("nan")` o `None` indicano che la ricerca continua a un altro livello.

**Cosa accade quando nessun livello definisce una proprietà?**

Aspose.Slides risolve il valore predefinito appropriato di PowerPoint o della libreria. Quel valore risolto appare nei dati efficaci anche se nessun oggetto locale lo definisce esplicitamente.

**Perché un valore efficace a volte coincide con il valore locale?**

Il valore locale ha vinto il calcolo di ereditarietà. Ciò è previsto quando la proprietà è impostata esplicitamente sull'oggetto e nessuna regola più specifica lo sovrascrive.

**Quando devo usare i dati locali invece dei dati efficaci?**

Usa i dati locali per ispezionare o modificare un livello di formattazione specifico. Usa i dati efficaci quando ti serve l'aspetto finale dopo che ereditarietà, regole del tema e stili applicabili sono stati risolti. L'[esempio completo di confronto](#compare-local-inherited-and-effective-values) dimostra entrambi nello stesso flusso di lavoro.