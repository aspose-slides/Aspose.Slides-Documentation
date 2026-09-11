---
title: Ottenere le proprietà effettive della forma dalle presentazioni in Python via Java
linktitle: Proprietà effettive
type: docs
weight: 50
url: /it/python-java/shape-effective-properties/
keywords:
- proprietà della forma
- proprietà della telecamera
- rig di illuminazione
- forma smussata
- riquadro di testo
- stile di testo
- altezza del carattere
- formato riempimento
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri come usare Aspose.Slides per Python via Java per distinguere la formattazione locale, ereditata ed efficace delle forme in presentazioni PowerPoint."
---
## **Comprendere le proprietà locali, ereditate ed effettive**

Il formattazione di PowerPoint può provenire da diversi luoghi. Il valore memorizzato direttamente su un oggetto è il suo **valore locale**. Se quel valore non è impostato, PowerPoint consulta le sorgenti di formattazione dei genitori, come il valore predefinito di un paragrafo, uno stile di testo, un layout o un master slide, un tema o i valori predefiniti a livello di presentazione. Quei valori sono **valori ereditati**. Il valore che rimane dopo che l’intera gerarchia è stata risolta è il **valore effettivo** — il valore usato per renderizzare l’oggetto.

Ad esempio, una porzione di testo potrebbe non definire la propria altezza del carattere. Il suo valore locale [getFontHeight](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#getFontHeight) è quindi `float("nan")`, il che significa “non impostato qui”. La porzione può ereditare un’altezza dal paragrafo, dallo stile di testo predefinito della presentazione o da un’altra sorgente applicabile. Chiamare [getEffective](https://reference.aspose.com/slides/it/python-java/aspose.slides/portionformat/#getEffective) sul formato della porzione restituisce l’altezza finale risolta.

Usa i due tipi di dati di formattazione per scopi diversi:

- Leggi o modifica un oggetto di formato locale, come [PortionFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/portionformat/), quando devi controllare dove è definito un valore.
- Leggi un oggetto di dati effettivi, come `PortionFormatEffectiveData`, quando ti serve il risultato finale renderizzato. I dati effettivi sono di sola lettura.

## **Confrontare valori locali, ereditati ed effettivi**

L’esempio completo seguente crea una forma e applica altezze del carattere a livello di presentazione, paragrafo e porzione. Ogni passaggio stampa i valori definiti a quei livelli e il valore effettivo risultante per la stessa porzione di testo. Dimostra anche perché i dati effettivi devono essere letti nuovamente dopo le modifiche di formattazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from math import isnan
from asposeslides.api import Presentation, SaveFormat, ShapeType


def format_local_value(value):
    return "<not set>" if isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight()
    paragraph_value = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight()
    local_value = portion.getPortionFormat().getFontHeight()

    # Leggi i dati effettivi dopo le modifiche precedenti.
    effective_value = portion.getPortionFormat().getEffective().getFontHeight()

    print(caption)
    print(f"  Presentation default: {format_local_value(presentation_value)}")
    print(f"  Paragraph default:    {format_local_value(paragraph_value)}")
    print(f"  Portion local:        {format_local_value(local_value)}")
    print(f"  Portion effective:    {effective_value}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, False)
    text_frame = shape.addTextFrame("Effective formatting")
    paragraph = text_frame.getParagraphs().get_Item(0)
    portion = paragraph.getPortions().get_Item(0)

    # Definisci i valori ereditati a due diversi livelli.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # Un valore locale sulla porzione sovrascrive entrambi i valori ereditati.
    portion.getPortionFormat().setFontHeight(36)
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Modificare un valore ereditato non sovrascrive un valore locale esistente.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30)
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Cancella il valore locale. La porzione ora eredita nuovamente dal paragrafo.
    portion.getPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Cancella il valore del paragrafo. Il valore predefinito della presentazione ora fornisce il risultato.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La priorità in questo esempio è la formattazione locale della porzione, seguita da quella del paragrafo e infine dal valore predefinito della presentazione. Altri oggetti possono avere catene di ereditarietà diverse, ma il principio è lo stesso: un valore esplicito più specifico prevale, e [getEffective](https://reference.aspose.com/slides/it/python-java/aspose.slides/portionformat/#getEffective) restituisce il risultato finale.

## **Ottenere le proprietà di testo effettive**

La formattazione del testo è suddivisa in diversi oggetti:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#getEffective) risolve le proprietà del riquadro di testo, come margini, ancoraggio, adattamento automatico e direzione verticale del testo.
- [TextStyle.getEffective](https://reference.aspose.com/slides/it/python-java/aspose.slides/textstyle/#getEffective) risolve la formattazione del paragrafo per ogni livello di stile di testo.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraphformat/#getEffective) risolve le proprietà del paragrafo, come allineamento, rientro e elenchi puntati.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/it/python-java/aspose.slides/portionformat/#getEffective) risolve le proprietà dei caratteri, come altezza del carattere, famiglia, colore, grassetto e corsivo.

Per l’esempio successivo, `text-formatting.pptx` deve contenere almeno una diapositiva e una [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/) con un riquadro di testo non vuoto. L’AutoShape può trovarsi in qualsiasi posizione nella raccolta di forme; il codice cerca un oggetto idoneo e lo convalida prima dell’uso.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation


def has_non_empty_text(shape):
    text_frame = shape.getTextFrame()
    if text_frame is None or text_frame.getParagraphs().getCount() == 0:
        return False
    return text_frame.getParagraphs().get_Item(0).getPortions().getCount() > 0


def find_auto_shape_with_text(slide):
    for candidate in slide.getShapes():
        if isinstance(candidate, AutoShape) and has_non_empty_text(candidate):
            return candidate
    return None


presentation = Presentation("text-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        shape = find_auto_shape_with_text(presentation.getSlides().get_Item(0))
        if shape is None:
            print("The first slide must contain an AutoShape with non-empty text.")
        else:
            text_frame = shape.getTextFrame()
            paragraph = text_frame.getParagraphs().get_Item(0)
            portion = paragraph.getPortions().get_Item(0)

            text_frame_effective = text_frame.getTextFrameFormat().getEffective()
            paragraph_effective = paragraph.getParagraphFormat().getEffective()
            portion_effective = portion.getPortionFormat().getEffective()

            print("Text frame margins:")
            print(f"  Left: {text_frame_effective.getMarginLeft()}")
            print(f"  Top: {text_frame_effective.getMarginTop()}")
            print(f"  Right: {text_frame_effective.getMarginRight()}")
            print(f"  Bottom: {text_frame_effective.getMarginBottom()}")
            print(f"Paragraph alignment: {paragraph_effective.getAlignment()}")
            print(f"Font height: {portion_effective.getFontHeight()}")
            print(f"Bold: {portion_effective.getFontBold()}")

            effective_text_style = text_frame.getTextFrameFormat().getTextStyle().getEffective()
            for level in range(9):
                level_effective = effective_text_style.getLevel(level)
                print(f"Level {level} indent: {level_effective.getIndent()}")
finally:
    presentation.dispose()
```

## **Ottenere le proprietà 3D effettive**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/it/python-java/aspose.slides/threedformat/#getEffective) restituisce un oggetto `ThreeDFormatEffectiveData` che raggruppa tutte le impostazioni 3D risolte. I suoi metodi `getCamera`, `getLightRig`, `getBevelTop` e `getBevelBottom` espongono i corrispondenti dati effettivi. Leggere questi settaggi correlati insieme rende più semplice comprendere l’aspetto 3D finale di una forma.

Per questo esempio, `shape-3d.pptx` deve contenere almeno una forma nella prima diapositiva. Applica una telecamera 3D, illuminazione o impostazioni di smussatura a quella forma se desideri che l’output contenga valori diversi da quelli predefiniti.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("shape-3d.pptx")
try:
    if presentation.getSlides().size() == 0 or presentation.getSlides().get_Item(0).getShapes().size() == 0:
        print("The first slide must contain a shape.")
    else:
        shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        three_d_effective = shape.getThreeDFormat().getEffective()

        print("Camera:")
        print(f"  Type: {three_d_effective.getCamera().getCameraType()}")
        print(f"  Field of view: {three_d_effective.getCamera().getFieldOfViewAngle()}")
        print(f"  Zoom: {three_d_effective.getCamera().getZoom()}")

        print("Light rig:")
        print(f"  Type: {three_d_effective.getLightRig().getLightType()}")
        print(f"  Direction: {three_d_effective.getLightRig().getDirection()}")

        print("Top bevel:")
        print(f"  Type: {three_d_effective.getBevelTop().getBevelType()}")
        print(f"  Width: {three_d_effective.getBevelTop().getWidth()}")
        print(f"  Height: {three_d_effective.getBevelTop().getHeight()}")
finally:
    presentation.dispose()
```

## **Ottenere la formattazione della tabella effettiva**

La formattazione di una tabella può provenire dallo stile della tabella e da formati applicati all’intera tabella, a una colonna, a una riga o a una singola cella. In caso di conflitti tra riempimenti definiti esplicitamente, la priorità è: cella, riga, colonna e infine l’intera tabella. Il formato effettivo di una cella è il formato finale usato per disegnarla.

Per questo esempio, `table-formatting.pptx` deve contenere almeno una tabella nella prima diapositiva. La tabella deve avere almeno una riga e una colonna. Il codice cerca una [Table](https://reference.aspose.com/slides/it/python-java/aspose.slides/table/) invece di assumere che `getShapes().get_Item(0)` sia una tabella.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table


def find_table(slide):
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            return shape
    return None


presentation = Presentation("table-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        table = find_table(presentation.getSlides().get_Item(0))
        if table is None:
            print("The first slide must contain a table.")
        elif table.getRows().size() == 0 or table.getColumns().size() == 0:
            print("The table must contain at least one cell.")
        else:
            table_effective = table.getTableFormat().getEffective()
            row_effective = table.getRows().get_Item(0).getRowFormat().getEffective()
            column_effective = table.getColumns().get_Item(0).getColumnFormat().getEffective()
            cell_effective = table.get_Item(0, 0).getCellFormat().getEffective()

            print(f"Table fill: {table_effective.getFillFormat().getFillType()}")
            print(f"Row fill: {row_effective.getFillFormat().getFillType()}")
            print(f"Column fill: {column_effective.getFillFormat().getFillType()}")
            print(f"Final cell fill: {cell_effective.getFillFormat().getFillType()}")
finally:
    presentation.dispose()
```

Se ti serve il colore anziché solo il tipo di riempimento, verifica prima il `getFillType` effettivo, quindi leggi il metodo corrispondente a quel tipo — ad esempio, `getSolidFillColor` per un riempimento solido.

## **Rileggere i dati effettivi dopo le modifiche**

I dati effettivi descrivono la gerarchia di formattazione al momento della risoluzione. Richiama nuovamente [getEffective](https://reference.aspose.com/slides/it/python-java/aspose.slides/portionformat/#getEffective) dopo aver modificato qualsiasi elemento che possa partecipare a quella gerarchia, inclusi:

- il formato locale dell’oggetto;
- i valori predefiniti di paragrafo o riquadro di testo;
- lo stile di una tabella, la tabella stessa, il formato di colonna, riga o cella;
- il formato di layout o master slide;
- i dati del tema o i valori predefiniti a livello di presentazione;
- il layout o il master assegnato a una diapositiva.

Non conservare un oggetto di dati effettivi come istantanea permanente. Aspose.Slides può memorizzare internamente alcuni dati effettivi nella cache, e una chiamata successiva a [getEffective](https://reference.aspose.com/slides/it/python-java/aspose.slides/portionformat/#getEffective) può aggiornare tali dati. Se devi confrontare i valori prima e dopo una modifica, copia i valori scalari di cui hai bisogno — ad esempio, altezza del carattere, colore, allineamento o larghezza dello smusso—nelle tue variabili prima di effettuare la modifica.

Per modificare un valore, aggiorna l’oggetto di formato locale appropriato e poi chiama [getEffective](https://reference.aspose.com/slides/it/python-java/aspose.slides/portionformat/#getEffective) per verificare il risultato. Gli oggetti di dati effettivi stessi sono di sola lettura.

## **FAQ**

**Come posso sapere quale livello ha fornito un valore effettivo?**

I dati effettivi contengono il valore finale, non la sua origine. Esamina gli oggetti locali applicabili a partire dal livello più specifico verso l’esterno. Per il testo, ciò può includere la porzione, il paragrafo, il riquadro di testo, il layout, il master, il tema e i valori predefiniti della presentazione. Valori non definiti come `float("nan")` o `None` indicano che la ricerca continua a un altro livello.

**Cosa succede quando nessun livello definisce una proprietà?**

Aspose.Slides risolve il valore predefinito appropriato di PowerPoint o della libreria. Tale valore risolto appare nei dati effettivi anche se nessun oggetto locale lo ha definito esplicitamente.

**Perché a volte un valore effettivo coincide con il valore locale?**

Il valore locale ha vinto il calcolo di ereditarietà. Questo è previsto quando la proprietà è impostata esplicitamente sull’oggetto e nessuna regola più specifica lo sovrascrive.

**Quando dovrei usare i dati locali anziché i dati effettivi?**

Usa i dati locali per ispezionare o modificare un livello di formattazione specifico. Usa i dati effettivi quando ti serve l’aspetto finale dopo l’eredità, le regole del tema e gli stili applicabili. L’[esempio completo di confronto](#compare-local-inherited-and-effective-values) dimostra entrambi nello stesso flusso di lavoro.