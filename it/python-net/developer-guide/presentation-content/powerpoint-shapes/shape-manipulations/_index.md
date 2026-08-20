---
title: Gestire le forme della presentazione in Python
linktitle: Manipolazione delle forme
type: docs
weight: 40
url: /it/python-net/shape-manipulations/
keywords:
- Forma PowerPoint
- Forma di presentazione
- Forma sulla diapositiva
- Ricerca forma
- Clona forma
- Rimuovi forma
- Nascondi forma
- Modifica ordine forma
- Ottieni ID forma interop
- Testo alternativo della forma
- Formati layout della forma
- Forma come SVG
- Forma in SVG
- Allinea forma
- Capovolgi forma
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Scopri come identificare, clonare, rimuovere, nascondere, riordinare, esportare, allineare e capovolgere le forme della presentazione con Aspose.Slides per Python via .NET."
---
## **Panoramica**

Aspose.Slides per Python via .NET rappresenta le forme su una diapositiva come una ordinata [ShapeCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/). La collezione è sia il luogo in cui trovare e modificare le forme sia la fonte del loro ordine di sovrapposizione: l’indice `0` è la forma più arretrata, mentre l’ultimo indice è la forma più anteriore.

Questo articolo segue quel modello. Prima spiega come identificare in modo affidabile una forma, poi mostra come clonare, rimuovere, nascondere e riordinare le forme. Le sezioni finali coprono la formattazione a livello di layout, l’esportazione SVG, l’allineamento e le impostazioni di ribaltamento. Ogni esempio è indipendente, quindi è possibile utilizzare solo le operazioni richieste dal proprio flusso di lavoro.

## **Identificare e trovare le forme**

Gli indici della collezione sono comodi durante l’elaborazione di un file noto, ma non sono identificatori stabili. L’aggiunta, la rimozione o il riordino di una forma può modificare il suo indice. Scegliere un identificatore in base a come la presentazione è creata e mantenuta:

- [Shape.name](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/name/) è utile per template controllati dallo sviluppatore ed è facile da ispezionare nel Pannello di selezione di PowerPoint. I nomi possono essere modificati e non sono garantiti univoci, quindi stabilire una convenzione di denominazione se il codice dipende da essi.
- [Shape.alternative_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/alternative_text/) è utile quando una descrizione di accessibilità o un tag fornito dall’autore identifica già la forma. È visibile agli utenti, può essere localizzato o riscritto per l’accessibilità e non è garantito univoco. Non riutilizzare silenziosamente testo di accessibilità significativo come chiave di database.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/office_interop_shape_id/) è un identificatore di sola lettura, unico all’interno di una diapositiva e corrispondente all’ID forma usato dall’interoperabilità di PowerPoint. Usalo quando integri con PowerPoint o quando ti serve un riferimento inequivoco per la durata di una forma. Una forma clonata o ricreata è una forma diversa e riceve un proprio ID.

La proprietà correlata [Shape.unique_id](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/unique_id/) ha ambito di presentazione, ma è destinata ai componenti aggiuntivi e può essere riassegnata. Non deve essere trattata come chiave esterna permanente. Se l’identità a lungo termine è essenziale, conserva la mappatura nei dati dell’applicazione e verifica che la forma attesa esista ancora.

L’esempio seguente cerca per `name` con confronto esatto e restituisce l’ID interop limitato alla diapositiva. Quando il template non contiene la forma prevista, il codice riporta quel risultato invece di continuare con l’oggetto errato.

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

Quando un’operazione è specifica per un tipo di forma, verifica il tipo prima di utilizzare membri specifici. Questo esempio aggiorna il testo e il testo alternativo solo se l’oggetto denominato è un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/).

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

## **Modificare la collezione di forme**

I metodi aggiungi, clona, rimuovi e riordina operano sulla collezione immediatamente. Se un’operazione cambia il numero o l’ordine delle forme, non continuare a fare affidamento sugli indici catturati prima di quell’operazione.

### **Clonare una forma**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/add_clone/) crea una copia indipendente e la aggiunge alla collezione di destinazione. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/insert_clone/) crea anch’essa una copia ma la colloca in un indice di ordine Z specificato. Le versioni che accettano coordinate spostano il clone senza modificare le dimensioni; quelle con larghezza e altezza possono ridimensionarlo.

L’esempio crea una diapositiva di destinazione, clona un rettangolo etichettato in primo piano e inserisce un secondo clone sul retro. Le modifiche a ciascun clone non alterano la forma sorgente.

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

Il clonare copia il contenuto e la formattazione della forma, inclusi nome e testo alternativo. Assegna nuovi identificatori logici al clone quando tali valori devono essere univoci. Le risorse usate dalle forme complesse sono gestite dalla presentazione, ma un clone rimane un nuovo elemento della collezione con una nuova identità di forma.

### **Rimuovere le forme**

[ShapeCollection.remove](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/remove/) elimina un oggetto forma specifico dalla sua collezione. Quando si rimuovono più corrispondenze durante un’iterazione indicizzata, attraversa la collezione dal fondo così che ogni indice rimanente rimanga valido.

Questo esempio rimuove ogni forma con un nome designato. Legge `slide.shapes[index]`, non un elemento di collezione fisso, e non effettua cast non necessari.

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

Dopo la rimozione, il conteggio delle forme e gli indici delle forme successive cambiano. I riferimenti a forme non interessate rimangono più affidabili rispetto a indici salvati. Considera anche connettori, animazioni e altre funzionalità della presentazione che potrebbero riferirsi all’oggetto rimosso; la rimozione di una forma visibile può modificare più di quanto appaia nella diapositiva.

### **Nascondere una forma**

Impostare [Shape.hidden](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/hidden/) su `True` mantiene la forma nella collezione ma ne impedisce la visualizzazione nella presentazione normale. Il suo indice, la formattazione e il contenuto rimangono disponibili per il codice, quindi nascondere è appropriato per elementi opzionali che possono essere ripristinati in seguito.

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

Nascondere non equivale a cancellare o a proteggere. L’oggetto può ancora essere scoperto e visualizzato nuovamente da un utente o da codice, e rimane parte del file della presentazione.

### **Modificare l’ordine Z**

Le forme sovrapposte vengono disegnate secondo l’ordine della collezione. [ShapeCollection.reorder](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/reorder/) sposta una forma esistente a un indice di destinazione senza clonarla. L’indice `0` è il retro; `len(slide.shapes) - 1` è il fronte.

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

Il rettangolo è creato per primo e inizialmente si trova dietro l’ellisse. Spostandolo all’indice finale lo porta in primo piano. Finalizza l’ordine Z dopo aver aggiunto o clonato tutte le forme correlate, poiché tali operazioni aggiungono o inseriscono nuovi elementi nella collezione e possono alterare lo stack desiderato.

## **Ispezionare le forme nelle diapositive layout**

Le diapositive normali, le diapositive layout e le diapositive master hanno collezioni di forme separate. Una forma nella collezione layout non è lo stesso oggetto di una forma posizionata in modo simile su una diapositiva normale. Ispeziona le forme del layout quando devi comprendere o modificare la formattazione fornita da un layout.

L’esempio seguente legge per ciascuna forma del layout [Shape.fill_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/fill_format/) e [Shape.line_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/line_format/) senza presumere che ogni forma sia una `AutoShape`.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

Modificare un layout può influire su più diapositive che lo utilizzano. Prima di cambiare una forma del layout, determina se una diapositiva normale eredita l’oggetto o contiene una sovrascrittura locale, e verifica ogni diapositiva che utilizza quel layout.

## **Esportare una forma in SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/write_as_svg/) scrive il contenuto renderizzato di una singola forma su uno stream. Il risultato contiene solo la forma, non lo sfondo dell’intera diapositiva né le forme vicine.

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

Mantieni la presentazione aperta durante il rendering. L’output dipende dalla formattazione della forma e da risorse come font e immagini. Se ti serve l’intera composizione, esporta la diapositiva anziché una singola forma. Il chiamante possiede lo stream e deve chiuderlo.

## **Allineare le forme**

Le sovraccariche [SlideUtil.align_shapes](https://reference.aspose.com/slides/it/python-net/aspose.slides.util/slideutil/align_shapes/) allineano o tutte le forme o gli indici di collezione selezionati. [ShapesAlignmentType](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapesalignmenttype/) specifica il bordo, la linea centrale o la modalità di distribuzione. Imposta `align_to_slide` su `True` per usare i bordi della diapositiva; su `False` per allineare le forme selezionate tra loro.

Questo esempio allinea tre forme al bordo superiore della diapositiva. I loro indici attuali vengono risolti immediatamente prima dell’allineamento.

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

L’allineamento modifica le posizioni, non l’ordine Z. L’allineamento relativo richiede normalmente almeno due forme, mentre la distribuzione orizzontale o verticale necessita di un numero sufficiente di forme per definire la spaziatura. Ricomputa gli indici se modifichi la collezione prima di chiamare il metodo.

## **Capovolgere una forma**

La classe [ShapeFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapeframe/) memorizza posizione, dimensione, impostazioni di ribaltamento orizzontale e verticale e rotazione. I valori `flip_h` e `flip_v` usano [NullableBool](https://reference.aspose.com/slides/it/python-net/aspose.slides/nullablebool/): `TRUE` abilita il ribaltamento, `FALSE` lo disabilita, e `NOT_DEFINED` preserva lo stato non specificato o predefinito.

La presentazione di input qui sotto contiene una forma non ribaltata.

![La forma prima del ribaltamento](shape_to_be_flipped.png)

L’esempio conserva tutti gli altri valori del frame e sostituisce solo le due impostazioni di ribaltamento. Ciò è importante perché assegnare un nuovo [Shape.frame](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/frame/) sostituisce l’intero frame.

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

La forma salvata è riflessa orizzontalmente e verticalmente mantenendo posizione, dimensione e rotazione.

![La forma dopo il ribaltamento](flipped_shape.png)

## **FAQ**

**Devo usare un indice di collezione come identificatore di una forma?**

Solo per elaborazioni di breve durata quando la collezione non cambierà prima dell’uso dell’indice. Preferisci una convenzione validata basata su `name` o `alternative_text` per i template progettati, oppure `office_interop_shape_id` per lavori interop limitati alla diapositiva.

**Nascondere una forma la rimuove dall’ordine Z?**

No. Una forma nascosta rimane nella collezione allo stesso indice. Può essere trovata, riordinata, modificata o resa nuovamente visibile.

**Perché una forma clonata appare davanti a un’altra forma?**

`add_clone` aggiunge il clone alla fine della collezione, che corrisponde al fronte dell’ordine Z. Usa `insert_clone` per scegliere l’indice iniziale o `reorder` dopo aver aggiunto tutte le forme.