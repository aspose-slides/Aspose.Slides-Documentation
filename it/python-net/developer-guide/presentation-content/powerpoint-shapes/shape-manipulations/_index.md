---
title: Gestire le forme della presentazione in Python
linktitle: Manipolazione delle forme
type: docs
weight: 40
url: /it/python-net/shape-manipulations/
keywords:
- Forma PowerPoint
- Forma della presentazione
- Forma sulla diapositiva
- Trova forma
- Clona forma
- Rimuovi forma
- Nascondi forma
- Cambia ordine delle forme
- Ottieni ID forma interop
- Testo alternativo della forma
- Punto di regolazione della forma
- Regolazione predefinita della forma
- Geometria della forma
- Formati layout della forma
- Forma come SVG
- Forma in SVG
- Allinea forma
- Ribalta forma
- PowerPoint
- Presentazione
- Python
- Aspose.Slides
description: "Scopri come identificare, regolare, clonare, rimuovere, nascondere, riordinare, esportare, allineare e ribaltare le forme della presentazione con Aspose.Slides per Python via .NET."
---
## **Panoramica**

Aspose.Slides for Python via .NET rappresenta le forme su una diapositiva come una [ShapeCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/) ordinata. La collezione è sia il luogo in cui trovare e modificare le forme sia la fonte del loro ordine di impilamento: l'indice `0` è la forma più arretrata, mentre l'ultimo indice è la forma più anteriore.

Questo articolo segue quel modello. Prima spiega come identificare in modo affidabile una forma e modificare i punti di regolazione predefiniti, poi mostra come clonare, rimuovere, nascondere e riordinare le forme. Le sezioni finali coprono la formattazione a livello di layout, l'esportazione SVG, l'allineamento e le impostazioni di ribaltamento. Ogni esempio è indipendente, quindi è possibile utilizzare solo le operazioni richieste dal proprio flusso di lavoro.

## **Identificare e trovare le forme**

Gli indici della collezione sono comodi durante l'elaborazione di un file noto, ma non sono identificatori stabili. L'aggiunta, la rimozione o il riordino di una forma può modificarne l'indice. Scegli un identificatore in base a come la presentazione è creata e mantenuta:

- [Shape.name](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/name/) è utile per modelli controllati dagli sviluppatori ed è facile da ispezionare nel Pannello di selezione di PowerPoint. I nomi possono essere modificati e non sono garantiti unici, quindi definisci una convenzione di denominazione se il codice dipende da essi.
- [Shape.alternative_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/alternative_text/) è utile quando una descrizione di accessibilità o un tag fornito dall'autore identifica già la forma. È visibile agli utenti, può essere localizzato o riscritto per l'accessibilità e non è garantito unico. Non riutilizzare silenziosamente testi di accessibilità significativi come chiave di database.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/office_interop_shape_id/) è un identificatore di sola lettura unico all'interno di una diapositiva e corrisponde all'ID forma utilizzato dall'interoperabilità di PowerPoint. Usalo quando integri con PowerPoint o quando ti serve un riferimento inequivocabile durante la vita di una forma. Una forma clonata o ricreata è una forma diversa e riceve un proprio ID.

La proprietà correlata [Shape.unique_id](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/unique_id/) ha ambito di presentazione, ma è destinata a componenti aggiuntivi e può essere riassegnata. Non dovrebbe essere trattata come chiave esterna permanente. Se l'identità a lungo termine è essenziale, mantieni la mappatura nei dati dell'applicazione e verifica che la forma prevista esista ancora.

L'esempio seguente ricerca per `name` con confronto esatto e restituisce l'ID interop a livello di diapositiva. Quando il modello non contiene la forma prevista, il codice segnala quel risultato invece di continuare con l'oggetto errato.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    target_shape = None
    for shape in slide.shapes:
        if shape.name == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print("Found {}; interop ID: {}".format(target_shape.name, target_shape.office_interop_shape_id))
```

Quando un'operazione è specifica per un tipo di forma, verifica il tipo prima di utilizzare i membri specifici. Questo esempio aggiorna il testo e il testo alternativo solo se l'oggetto con nome è un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/).

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    candidate = None
    for shape in slide.shapes:
        if shape.name == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, slides.AutoShape):
        candidate.text_frame.text = "Approved"
        candidate.alternative_text = "Approval status: approved"
        presentation.save("identified-shape.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
```

## **Identificare e modificare le regolazioni predefinite della forma**

Le forme geometriche predefinite possono esporre punti di regolazione che controllano caratteristiche come la dimensione degli angoli, le proporzioni delle frecce o gli angoli degli archi. Accedili tramite la collezione di sola lettura [GeometryShape.adjustments](https://reference.aspose.com/slides/it/python-net/aspose.slides/geometryshape/adjustments/). La collezione stessa è fornita dalla forma, ma ciascun [AdjustValue](https://reference.aspose.com/slides/it/python-net/aspose.slides/adjustvalue/) contiene un valore modificabile.

Non fare affidamento solo su un indice fisso della collezione. Itera le regolazioni e ispeziona la proprietà di sola lettura [AdjustValue.type](https://reference.aspose.com/slides/it/python-net/aspose.slides/adjustvalue/type/), il cui valore [ShapeAdjustmentType](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapeadjustmenttype/) descrive ciò che la regolazione controlla. La proprietà di sola lettura [AdjustValue.name](https://reference.aspose.com/slides/it/python-net/aspose.slides/adjustvalue/name/) fornisce informazioni di identificazione aggiuntive ed è particolarmente utile quando un preset contiene più di una regolazione con lo stesso tipo semantico.

Usa la proprietà value che corrisponde al significato della regolazione:

| Tipo di regolazione | Scopo | Valore da modificare |
|---|---|---|
| `CORNER_SIZE` | Dimensione degli angoli arrotondati | [raw_value](https://reference.aspose.com/slides/it/python-net/aspose.slides/adjustvalue/raw_value/) |
| `ARROW_TAIL_THICKNESS` | Spessore della coda della freccia | `raw_value` |
| `ARROWHEAD_LENGTH` | Lunghezza della punta della freccia | `raw_value` |
| `ARROWHEAD_WIDTH` | Larghezza della punta della freccia | `raw_value` |
| `START_ANGLE` | Angolo iniziale di una fetta o di un arco | [angle_value](https://reference.aspose.com/slides/it/python-net/aspose.slides/adjustvalue/angle_value/) |
| `END_ANGLE` | Angolo finale di una fetta o di un arco | `angle_value` |

`type` e `name` non possono essere assegnati. `raw_value` è un intero leggibile/scrivibile nelle unità geometriche native del preset, mentre `angle_value` è un angolo leggibile/scrivibile in gradi. Il numero, l'ordine, il significato e l'intervallo valido delle regolazioni dipendono dal preset [GeometryShape.shape_type](https://reference.aspose.com/slides/it/python-net/aspose.slides/geometryshape/shape_type/). Un valore valido per un preset può essere non valido o avere un effetto diverso per un altro.

Quando `type` è `ShapeAdjustmentType.CUSTOM`, l'API non riconosce un significato semantico standard. Ispeziona `name`, il tipo di preset e il valore esistente, e lascia la regolazione invariata a meno che il significato e l'intervallo attesi non siano noti. Anche per i tipi riconosciuti, verifica se lo stesso tipo compare più di una volta prima di selezionare un valore. L'articolo [Connector](/slides/it/python-net/connector/) mostra questa situazione con le regolazioni di piegatura dei connettori.

L'esempio completo seguente crea versioni predefinite e modificate di tre forme predefinite. Itera ogni regolazione, segnala il suo `name` e `type`, modifica i valori legati alle dimensioni tramite `raw_value`, modifica gli angoli tramite `angle_value` e salva il risultato. La colonna di sinistra mantiene la geometria predefinita; la colonna di destra mostra il rettangolo arrotondato, la freccia a quattro punte e la fetta modificati.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Aggiungi intestazioni per le colonne della forma predefinita e modificata.
    default_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 250, 30)
    default_column_label.text_frame.text = "Default preset geometry"
    adjusted_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 390, 20, 250, 30)
    adjusted_column_label.text_frame.text = "Modified adjustment values"

    slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 430, 70, 160, 70)
    modified_rounded_rectangle.name = "ModifiedRoundedRectangle"

    slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 80, 180, 160, 110)
    modified_arrow = slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 430, 180, 160, 110)
    modified_arrow.name = "ModifiedQuadArrow"

    slide.shapes.add_auto_shape(slides.ShapeType.PIE, 95, 330, 130, 130)
    modified_pie = slide.shapes.add_auto_shape(slides.ShapeType.PIE, 445, 330, 130, 130)
    modified_pie.name = "ModifiedPie"

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment in shape.adjustments:
            print("{} / {}: {}".format(shape.name, adjustment.name, adjustment.type.name))

            if adjustment.type == slides.ShapeAdjustmentType.CORNER_SIZE:
                adjustment.raw_value = 5000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROW_TAIL_THICKNESS:
                adjustment.raw_value = 25000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_LENGTH:
                adjustment.raw_value = 30000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_WIDTH:
                adjustment.raw_value = 40000
            elif adjustment.type == slides.ShapeAdjustmentType.START_ANGLE:
                adjustment.angle_value = 30
            elif adjustment.type == slides.ShapeAdjustmentType.END_ANGLE:
                adjustment.angle_value = 300
            elif adjustment.type == slides.ShapeAdjustmentType.CUSTOM:
                print("Custom adjustment '{}' was not changed.".format(adjustment.name))

    presentation.save("preset-shape-adjustments.pptx", slides.export.SaveFormat.PPTX)
```

Controllare il tipo semantico prima di cambiare un valore rende il codice esplicito sull'intento ed evita di presumere che un particolare indice della collezione abbia lo stesso significato tra forme predefinite diverse.

## **Modificare la Shape Collection**

I metodi add, clone, remove e reorder operano sulla collezione immediatamente. Se un'operazione modifica il numero o l'ordine delle forme, non continuare a fare affidamento sugli indici catturati prima di quell'operazione.

### **Clonare una forma**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/add_clone/) crea una copia indipendente e la aggiunge alla collezione di destinazione. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/insert_clone/) crea anch'essa una copia ma la posiziona a un indice di ordine Z specificato. Le overload che accettano coordinate spostano il clone senza modificarne le dimensioni; le overload con larghezza e altezza possono anche ridimensionarlo.

L'esempio crea una diapositiva di destinazione, clona un rettangolo etichettato in primo piano e inserisce un secondo clone sul retro. Le modifiche a ciascun clone non alterano la forma sorgente.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    source_slide = presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 180, 60)
    source_shape.name = "SourceLabel"
    source_shape.text_frame.text = "Source"

    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    destination_slide = presentation.slides.add_empty_slide(blank_layout)

    front_clone_shape = destination_slide.shapes.add_clone(source_shape, 80, 80)
    front_clone_shape.name = "FrontClone"
    if isinstance(front_clone_shape, slides.AutoShape):
        front_clone_shape.text_frame.text = "Front clone"
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.shapes.insert_clone(0, source_shape, 80, 180)
    back_clone_shape.name = "BackClone"
    if isinstance(back_clone_shape, slides.AutoShape):
        back_clone_shape.text_frame.text = "Back clone"
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Il clonare copia il contenuto e la formattazione della forma, incluso il suo nome e il testo alternativo. Assegna nuovi identificatori logici al clone quando quei valori devono essere unici. Le risorse utilizzate da forme complesse sono gestite dalla presentazione, ma un clone rimane un nuovo elemento della collezione con una nuova identità di forma.

### **Rimuovere forme**

[ShapeCollection.remove](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/remove/) elimina un oggetto forma specifico dalla sua collezione. Quando si rimuovono più corrispondenze durante un'iterazione indicizzata, attraversa la collezione dal fondo in modo che ogni indice rimanente resti valido.

Questo esempio rimuove ogni forma con un nome designato. Legge `slide.shapes[index]`, non un elemento fisso della collezione, e non effettua cast non necessari sulla forma.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    keep_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 140, 60)
    keep_shape.name = "Keep"

    first_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 220, 40, 80, 80)
    first_temporary_shape.name = "Temporary"

    second_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 340, 40, 100, 80)
    second_temporary_shape.name = "Temporary"

    for index in range(len(slide.shapes) - 1, -1, -1):
        shape = slide.shapes[index]
        if shape.name == "Temporary":
            slide.shapes.remove(shape)

    presentation.save("removed-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Dopo la rimozione, il conteggio delle forme e gli indici delle forme successive cambiano. I riferimenti a forme non interessate rimangono più affidabili rispetto agli indici salvati. Considera anche connettori, animazioni e altre funzionalità della presentazione che potrebbero riferirsi all'oggetto rimosso; rimuovere una forma visibile può modificare più dell'aspetto della diapositiva.

### **Nascondere una forma**

Impostare [Shape.hidden](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/hidden/) su `True` mantiene la forma nella collezione ma impedisce la sua visualizzazione nella presentazione normale. Il suo indice, la formattazione e il contenuto rimangono disponibili al codice, quindi nascondere è appropriato per elementi opzionali che possono essere ripristinati in seguito.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    visible_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 160, 60)
    visible_shape.name = "VisibleLabel"

    optional_shape = slide.shapes.add_auto_shape(slides.ShapeType.MOON, 240, 40, 100, 100)
    optional_shape.name = "OptionalDecoration"

    for shape in slide.shapes:
        if shape.name == "OptionalDecoration":
            shape.hidden = True

    presentation.save("hidden-shape.pptx", slides.export.SaveFormat.PPTX)
```

Nascondere non è cancellazione né sicurezza. L'oggetto può ancora essere scoperto e resa visibile da un utente o dal codice, e rimane parte del file di presentazione.

### **Modificare lo Z-Order**

Le forme sovrapposte sono dipinte nell'ordine della collezione. [ShapeCollection.reorder](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/reorder/) sposta una forma esistente a un indice target senza clonarla. L'indice `0` è il retro; `len(slide.shapes) - 1` è il fronte.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    blue_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 220, 120)
    blue_rectangle.name = "BlueRectangle"
    blue_rectangle.fill_format.fill_type = slides.FillType.SOLID
    blue_rectangle.fill_format.solid_fill_color.color = draw.Color.steel_blue

    orange_ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 180, 140, 220, 120)
    orange_ellipse.name = "OrangeEllipse"
    orange_ellipse.fill_format.fill_type = slides.FillType.SOLID
    orange_ellipse.fill_format.solid_fill_color.color = draw.Color.orange

    slide.shapes.reorder(len(slide.shapes) - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Il rettangolo viene creato per primo e inizialmente si trova dietro l'ellisse. Spostandolo all'indice finale lo porta in primo piano. Finalizza lo Z-order dopo aver aggiunto o clonato tutte le forme correlate, poiché tali operazioni aggiungono o inseriscono nuovi elementi nella collezione e possono alterare la pila prevista.

## **Esaminare le forme nelle diapositive layout**

Diapositive normali, layout e master hanno collezioni di forme separate. Una forma nella collezione di layout non è lo stesso oggetto di una forma posizionata analogamente su una diapositiva normale. Esamina le forme di layout quando devi comprendere o modificare la formattazione fornita da un layout.

L'esempio seguente legge per ogni forma di layout il [Shape.fill_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/fill_format/) e il [Shape.line_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/line_format/) senza presumere che ogni forma sia un `AutoShape`.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

Modificare un layout può influire su più diapositive che lo utilizzano. Prima di cambiare una forma di layout, determina se una diapositiva normale eredita l'oggetto o contiene una sovrascrittura locale, e testa ogni diapositiva che utilizza quel layout.

## **Esportare una forma in SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/write_as_svg/) scrive il contenuto renderizzato di una singola forma in uno stream. Il risultato contiene la forma, non l'intero sfondo della diapositiva o le forme vicine.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.shapes[0]
        with open("shape.svg", "wb") as svg_stream:
            shape.write_as_svg(svg_stream)
```

Mantieni la presentazione aperta durante il rendering. L'output dipende dalla formattazione della forma e da risorse come font e immagini. Se ti serve l'intera composizione, esporta la diapositiva invece di una singola forma. Il chiamante possiede lo stream e deve chiuderlo.

## **Allineare le forme**

I sovraccarichi di [SlideUtil.align_shapes](https://reference.aspose.com/slides/it/python-net/aspose.slides.util/slideutil/align_shapes/) allineano tutte le forme o gli indici di collezione selezionati. [ShapesAlignmentType](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapesalignmenttype/) specifica il bordo, la linea centrale o la modalità di distribuzione. Imposta `align_to_slide` su `True` per utilizzare i bordi della diapositiva; impostalo su `False` per allineare le forme selezionate tra loro.

Questo esempio allinea tre forme al bordo superiore della diapositiva. I loro indici attuali sono risolti immediatamente prima dell'allineamento.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 60, 80, 120, 50)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 240, 160, 120, 50)
    third_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 420, 240, 120, 50)
    first_shape.name = "FirstAlignedShape"
    second_shape.name = "SecondAlignedShape"
    third_shape.name = "ThirdAlignedShape"

    shape_indexes = [
        slide.shapes.index_of(first_shape),
        slide.shapes.index_of(second_shape),
        slide.shapes.index_of(third_shape)
    ]

    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

L'allineamento modifica le posizioni, non lo Z-order. L'allineamento relativo normalmente richiede almeno due forme, mentre la distribuzione orizzontale o verticale necessita di un numero sufficiente di forme per definire la spaziatura. Ricalcola gli indici se modifichi la collezione prima di chiamare il metodo.

## **Ribaltare una forma**

La classe [ShapeFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapeframe/) memorizza posizione, dimensione, impostazioni di ribaltamento orizzontale e verticale e rotazione. I valori `flip_h` e `flip_v` usano [NullableBool](https://reference.aspose.com/slides/it/python-net/aspose.slides/nullablebool/): `TRUE` abilita il ribaltamento, `FALSE` lo disabilita e `NOT_DEFINED` mantiene lo stato non specificato o predefinito.

La presentazione di input sotto contiene una forma non ribaltata.

![The shape before flipping](shape_to_be_flipped.png)

L'esempio mantiene tutti gli altri valori del frame e sostituisce solo le due impostazioni di ribaltamento. Ciò è importante perché assegnare un nuovo [Shape.frame](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/frame/) sostituisce l'intero frame.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    frame = shape.frame

    print("Horizontal flip before change:", frame.flip_h)
    print("Vertical flip before change:", frame.flip_v)

    shape.frame = slides.ShapeFrame(
        frame.x, frame.y, frame.width, frame.height,
        slides.NullableBool.TRUE, slides.NullableBool.TRUE, frame.rotation)

    presentation.save("flipped-shape.pptx", slides.export.SaveFormat.PPTX)
```

La forma salvata è ribaltata orizzontalmente e verticalmente mantenendo posizione, dimensione e rotazione.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Devo usare un indice di collezione come identificatore di forma?**

Solo per elaborazioni di breve durata quando la collezione non cambierà prima dell'uso dell'indice. Preferisci una convenzione validata su `name` o `alternative_text` per modelli creati, o `office_interop_shape_id` per lavori di interop a livello di diapositiva.

**Nascondere una forma la rimuove dallo Z-order?**

No. Una forma nascosta rimane nella collezione allo stesso indice. Può essere trovata, riordinata, modificata o resa nuovamente visibile.

**Perché una forma clonata appare davanti a un'altra forma?**

`add_clone` aggiunge il clone alla fine della collezione, che è il fronte dello Z-order. Usa `insert_clone` per scegliere l'indice iniziale o `reorder` dopo aver aggiunto tutte le forme.

**Posso usare un indice fisso per identificare una regolazione predefinita della forma?**

Solo dopo aver validato il preset esatto e la disposizione della collezione. Preferisci iterare su `GeometryShape.adjustments` e controllare `AdjustValue.type`; usa `AdjustValue.name` come informazione aggiuntiva quando lo stesso tipo semantico appare più di una volta.