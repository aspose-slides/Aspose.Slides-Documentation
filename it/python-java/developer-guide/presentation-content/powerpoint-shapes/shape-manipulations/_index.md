---
title: Gestire le forme della presentazione in Python tramite Java
linktitle: Manipolazione delle forme
type: docs
weight: 40
url: /it/python-java/shape-manipulations/
keywords:
- Forma PowerPoint
- Forma della presentazione
- Forma sulla diapositiva
- Trovare forma
- Clonare forma
- Rimuovere forma
- Nascondere forma
- Modificare ordine delle forme
- Ottenere ID forma interop
- Testo alternativo della forma
- Punto di regolazione della forma
- Regolazione predefinita della forma
- Geometria della forma
- Formati layout della forma
- Forma come SVG
- Forma in SVG
- Allineare forma
- Ribaltare forma
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Impara come identificare, regolare, clonare, rimuovere, nascondere, riordinare, esportare, allineare e ribaltare le forme della presentazione con Aspose.Slides per Python tramite Java."
---
## **Panoramica**

Aspose.Slides for Python via Java rappresenta le forme su una diapositiva come una [ShapeCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/) ordinata. La collezione è sia il luogo in cui trovare e modificare le forme sia la fonte del loro ordine di impilamento: l’indice `0` è la forma più arretrata, mentre l’ultimo indice è la forma più frontale.

Questo articolo segue quel modello. Prima spiega come identificare una forma in modo affidabile e modificare i punti di regolazione predefiniti, poi mostra come clonare, rimuovere, nascondere e riordinare le forme. Le sezioni finali coprono la formattazione a livello di layout, l’esportazione SVG, l’allineamento e le impostazioni di ribaltamento. Ogni esempio è indipendente, così è possibile utilizzare solo le operazioni richieste dal proprio flusso di lavoro.

## **Identificare e trovare le forme**

Gli indici della collezione sono comodi durante l’elaborazione di un file noto, ma non sono identificatori stabili. L’aggiunta, la rimozione o il riordino di una forma possono cambiarne l’indice. Scegli un identificatore in base al modo in cui la presentazione è creata e mantenuta:

- [Name](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getName) è utile per template controllati dallo sviluppatore ed è facile da esaminare nel Pannello di selezione di PowerPoint. I nomi possono essere modificati e non sono garantiti unici, quindi stabilisci una convenzione di denominazione se il codice dipende da essi.
- [AlternativeText](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getAlternativeText) è utile quando una descrizione di accessibilità o un tag fornito dall’autore identifica già la forma. È visibile agli utenti, può essere localizzato o riscritto per l’accessibilità e non è garantito unico. Non riutilizzare silenziosamente del testo di accessibilità significativo come chiave di database.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getOfficeInteropShapeId) è un identificatore di sola lettura unico all’interno di una diapositiva e corrisponde all’ID della forma usato dall’interoperabilità di PowerPoint. Usalo quando integri con PowerPoint o quando ti serve un riferimento univoco per tutta la durata di una forma. Una forma clonata o ricreata è una forma diversa e riceve un proprio ID.

Il metodo correlato [getUniqueId](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getUniqueId) restituisce un identificatore a livello di presentazione, ma quell’identificatore è pensato per componenti aggiuntivi e può essere riassegnato. Non deve essere trattato come una chiave esterna permanente. Se l’identità a lungo termine è essenziale, conserva la mappatura nei dati dell’applicazione e verifica che la forma prevista esista ancora.

L’esempio seguente cerca per nome con confronto esatto e riporta l’ID interop a livello di diapositiva. Quando il template non contiene la forma prevista, il codice riporta quel risultato anziché continuare con l’oggetto errato.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = None
    for shape in slide.getShapes():
        if shape.getName() == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print(f"Found {target_shape.getName()}; interop ID: {target_shape.getOfficeInteropShapeId()}")
finally:
    presentation.dispose()
```

Quando un’operazione è specifica a un tipo di forma, controlla il tipo prima di usare membri specifici. Questo esempio aggiorna il testo e il testo alternativo solo se l’oggetto nominato è un [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    candidate = None
    for shape in slide.getShapes():
        if shape.getName() == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, AutoShape):
        candidate.getTextFrame().setText("Approved")
        candidate.setAlternativeText("Approval status: approved")
        presentation.save("identified-shape.pptx", SaveFormat.Pptx)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
finally:
    presentation.dispose()
```

## **Identificare e modificare le regolazioni predefinite della forma**

Le forme di geometria predefinita possono esporre punti di regolazione che controllano caratteristiche come dimensione dell’angolo, proporzioni della freccia o angoli dell’arco. Accedili tramite la collezione di sola lettura [GeometryShape.getAdjustments](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometryshape/#getAdjustments). La collezione stessa è fornita dalla forma, ma ogni [AdjustValue](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/) contiene un valore che può essere modificato.

Non fare affidamento solo su un indice di collezione fisso. Itera attraverso le regolazioni e ispeziona il metodo di sola lettura [getType](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/#getType), il cui valore [ShapeAdjustmentType](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapeadjustmenttype/) descrive ciò che la regolazione controlla. Il metodo di sola lettura [getName](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/#getName) fornisce informazioni di identificazione aggiuntive ed è particolarmente utile quando un preset contiene più di una regolazione con lo stesso tipo semantico.

Usa il metodo valore che corrisponde al significato della regolazione:

| Tipo di regolazione | Scopo | Valore da modificare |
|---|---|---|
| [CornerSize](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapeadjustmenttype/#CornerSize) | Dimensione degli angoli arrotondati | [setRawValue](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowTailThickness](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapeadjustmenttype/#ArrowTailThickness) | Spessore della coda della freccia | [setRawValue](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadLength](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadLength) | Lunghezza della punta della freccia | [setRawValue](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadWidth](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadWidth) | Larghezza della punta della freccia | [setRawValue](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [StartAngle](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapeadjustmenttype/#StartAngle) | Angolo di inizio di una torta o di un arco | [setAngleValue](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/#setAngleValue) |
| [EndAngle](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapeadjustmenttype/#EndAngle) | Angolo di fine di una torta o di un arco | [setAngleValue](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/#setAngleValue) |

[getType](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/#getType) e [getName](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/#getName) restituiscono informazioni di sola lettura. [getRawValue](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/#getRawValue) e [setRawValue](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/#setRawValue) lavorano con un intero nelle unità native della geometria del preset, mentre [getAngleValue](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/#getAngleValue) e [setAngleValue](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/#setAngleValue) lavorano con un angolo in gradi. Il numero, l’ordine, il significato e l’intervallo valido delle regolazioni dipendono dal preset [ShapeType](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometryshape/#getShapeType). Un valore valido per un preset può essere non valido o avere un effetto diverso per un altro.

Quando [getType](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/#getType) restituisce [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapeadjustmenttype/#Custom), l’API non riconosce un significato semantico standard. Ispeziona [getName](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/#getName), il tipo di preset e il valore esistente, e lascia la regolazione invariata a meno che il significato e l’intervallo attesi non siano noti. Anche per i tipi riconosciuti, verifica se lo stesso tipo compare più volte prima di selezionare un valore. L’articolo [Connector](/slides/it/python-java/connector/) mostra questa situazione con le regolazioni di curvatura dei connettori.

L’esempio completo seguente crea versioni predefinite e modificate di tre forme predefinite. Itera attraverso ogni regolazione, riporta il suo nome e tipo, cambia i valori relativi alle dimensioni tramite [setRawValue](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/#setRawValue), cambia gli angoli tramite [setAngleValue](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/#setAngleValue) e salva il risultato. La colonna di sinistra mantiene la geometria predefinita; la colonna di destra mostra il rettangolo arrotondato, la freccia a quattro vie e la torta regolati.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeAdjustmentType, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Aggiunge intestazioni per le colonne di forma predefinita e regolata.
    default_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30)
    default_column_label.getTextFrame().setText("Default preset geometry")
    adjusted_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30)
    adjusted_column_label.getTextFrame().setText("Modified adjustment values")

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70)
    modified_rounded_rectangle.setName("ModifiedRoundedRectangle")

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110)
    modified_arrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110)
    modified_arrow.setName("ModifiedQuadArrow")

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130)
    modified_pie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130)
    modified_pie.setName("ModifiedPie")

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment_index in range(shape.getAdjustments().size()):
            adjustment = shape.getAdjustments().get_Item(adjustment_index)
            print(f"{shape.getName()} / {adjustment.getName()}: {adjustment.getType()}")

            if adjustment.getType() == ShapeAdjustmentType.CornerSize:
                adjustment.setRawValue(5000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowTailThickness:
                adjustment.setRawValue(25000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadLength:
                adjustment.setRawValue(30000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadWidth:
                adjustment.setRawValue(40000)
            elif adjustment.getType() == ShapeAdjustmentType.StartAngle:
                adjustment.setAngleValue(30)
            elif adjustment.getType() == ShapeAdjustmentType.EndAngle:
                adjustment.setAngleValue(300)
            elif adjustment.getType() == ShapeAdjustmentType.Custom:
                print(f"Custom adjustment '{adjustment.getName()}' was not changed.")

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Controllare il tipo semantico prima di modificare un valore rende il codice esplicito rispetto all’intento ed evita di presumere che un determinato indice di collezione abbia lo stesso significato across diverse forme predefinite.

## **Modificare la collezione di forme**

I metodi di aggiunta, clonazione, rimozione e riordino operano immediatamente sulla collezione. Se un’operazione cambia il numero o l’ordine delle forme, non continuare a fare affidamento su indici acquisiti prima di tale operazione.

### **Clonare una forma**

[addClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addClone) crea una copia indipendente e la aggiunge alla collezione di destinazione. [insertClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#insertClone) crea anch’essa una copia ma la inserisce a un indice di Z‑order specificato. Le sovraccariche che accettano coordinate spostano il clone senza cambiarne le dimensioni; quelle con larghezza e altezza possono ridimensionarlo.

L’esempio crea una diapositiva di destinazione, clona un rettangolo etichettato in primo piano e inserisce un secondo clone sullo sfondo. Le modifiche a ciascun clone non modificano la forma sorgente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    source_slide = presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60)
    source_shape.setName("SourceLabel")
    source_shape.getTextFrame().setText("Source")

    blank_layout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank)
    destination_slide = presentation.getSlides().addEmptySlide(blank_layout)

    front_clone_shape = destination_slide.getShapes().addClone(source_shape, 80, 80)
    front_clone_shape.setName("FrontClone")
    if isinstance(front_clone_shape, AutoShape):
        front_clone_shape.getTextFrame().setText("Front clone")
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.getShapes().insertClone(0, source_shape, 80, 180)
    back_clone_shape.setName("BackClone")
    if isinstance(back_clone_shape, AutoShape):
        back_clone_shape.getTextFrame().setText("Back clone")
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il cloning copia il contenuto e la formattazione della forma, inclusi nome e testo alternativo. Assegna nuovi identificatori logici al clone quando quei valori devono essere unici. Le risorse usate dalle forme complesse sono gestite dalla presentazione, ma un clone rimane un nuovo elemento della collezione con una nuova identità di forma.

### **Rimuovere forme**

[remove](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#remove) elimina un oggetto forma specifico dalla sua collezione. Quando si rimuovono più corrispondenze durante un’iterazione indicizzata, attraversa la collezione dal fondo in modo che ciascun indice rimanente resti valido.

Questo esempio rimuove ogni forma con un nome designato. Legge la forma all’indice corrente, non un elemento di collezione fisso, e non effettua cast inutili.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    keep_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60)
    keep_shape.setName("Keep")

    first_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80)
    first_temporary_shape.setName("Temporary")

    second_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80)
    second_temporary_shape.setName("Temporary")

    for i in range(slide.getShapes().size() - 1, -1, -1):
        shape = slide.getShapes().get_Item(i)
        if shape.getName() == "Temporary":
            slide.getShapes().remove(shape)

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Dopo la rimozione, il conteggio delle forme e gli indici delle forme successive cambiano. I riferimenti a forme non interessate rimangono più affidabili rispetto agli indici salvati. Considera anche connettori, animazioni e altre funzionalità della presentazione che potrebbero riferirsi all’oggetto rimosso; rimuovere una forma visibile può modificare più del semplice aspetto della diapositiva.

### **Nascondere una forma**

Impostare [Hidden](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#setHidden) a `True` mantiene la forma nella collezione ma impedisce che appaia nella presentazione normale. Il suo indice, la formattazione e il contenuto restano disponibili per il codice, quindi nascondere è appropriato per elementi opzionali che possono essere ripristinati in seguito.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    visible_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60)
    visible_shape.setName("VisibleLabel")

    optional_shape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100)
    optional_shape.setName("OptionalDecoration")

    for shape in slide.getShapes():
        if shape.getName() == "OptionalDecoration":
            shape.setHidden(True)

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Nascondere non è cancellazione né sicurezza. L’oggetto può ancora essere scoperto e riapparire da parte di un utente o da codice, e rimane parte del file della presentazione.

### **Modificare l’ordine Z**

Le forme sovrapposte vengono disegnate nell’ordine della collezione. [reorder](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#reorder) sposta una forma esistente a un indice target senza clonarla. L’indice `0` è lo sfondo; la [size](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#size) della collezione meno uno è il fronte.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    blue_rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120)
    blue_rectangle.setName("BlueRectangle")
    blue_rectangle.getFillFormat().setFillType(FillType.Solid)
    blue_rectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    orange_ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120)
    orange_ellipse.setName("OrangeEllipse")
    orange_ellipse.getFillFormat().setFillType(FillType.Solid)
    orange_ellipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    slide.getShapes().reorder(slide.getShapes().size() - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il rettangolo è creato per primo e inizialmente si trova dietro l’ellisse. Spostarlo all’indice finale lo porta in primo piano. Finalizza l’ordine Z dopo aver aggiunto o clonato tutte le forme correlate, perché tali operazioni aggiungono o inseriscono nuovi elementi nella collezione e possono alterare la pila prevista.

## **Ispezionare le forme sui layout di diapositiva**

Le diapositive normali, i layout di diapositiva e i master hanno collezioni di forme separate. Una forma in una collezione di layout non è lo stesso oggetto di una forma posizionata similmente su una diapositiva normale. Ispeziona le forme di layout quando devi comprendere o modificare la formattazione fornita da un layout.

L’esempio seguente legge per ogni forma del layout il suo [FillFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getFillFormat) e il suo [LineFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getLineFormat) senza presumere che ogni forma sia un [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for layout_slide in presentation.getLayoutSlides():
        for shape in layout_slide.getShapes():
            fill_type = shape.getFillFormat().getFillType()
            line_width = shape.getLineFormat().getWidth()
            print(f"{layout_slide.getName()} / {shape.getName()}: fill={fill_type}, line width={line_width}")
finally:
    presentation.dispose()
```

Modificare un layout può influire su più diapositive che lo usano. Prima di cambiare una forma di layout, determina se una diapositiva normale eredita l’oggetto o contiene una sovrascrittura locale, e testa ogni diapositiva che utilizza quel layout.

## **Esportare una forma in SVG**

Il metodo `writeAsSvg` di [Shape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/) scrive il contenuto renderizzato di una singola forma in uno stream. Il risultato contiene la forma, non l’intero sfondo della diapositiva o le forme vicine.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path
from java.io import ByteArrayOutputStream

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    if slide.getShapes().size() == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.getShapes().get_Item(0)
        svg_stream = ByteArrayOutputStream()
        try:
            shape.writeAsSvg(svg_stream)
            svg_bytes = bytes(svg_stream.toByteArray())
            Path("shape.svg").write_bytes(svg_bytes)
        except OSError as exception:
            print(f"The SVG file could not be written: {exception}")
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Mantieni la presentazione aperta durante il rendering. L’output dipende dalla formattazione della forma e da risorse quali caratteri e immagini. Se ti serve l’intera composizione, esporta la diapositiva anziché una singola forma. Chi chiama possiede lo stream e deve chiuderlo.

## **Allineare le forme**

Le sovraccariche di [SlideUtil.alignShapes](https://reference.aspose.com/slides/it/python-java/aspose.slides/slideutil/#alignShapes) allineano tutte le forme o gli indici di collezione selezionati. [ShapesAlignmentType](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapesalignmenttype/) specifica il bordo, la linea centrale o la modalità di distribuzione. Imposta `align_to_slide` a `True` per usare i bordi della diapositiva; impostalo a `False` per allineare le forme selezionate tra loro.

Questo esempio allinea tre forme al bordo superiore della diapositiva. I riferimenti alle forme restituiti vengono convertiti nei loro indici correnti immediatamente prima dell’allineamento.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, ShapesAlignmentType, SlideUtil

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50)
    third_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50)
    first_shape.setName("FirstAlignedShape")
    second_shape.setName("SecondAlignedShape")
    third_shape.setName("ThirdAlignedShape")

    shape_indexes = jpype.JArray(jpype.JInt)([slide.getShapes().indexOf(first_shape), slide.getShapes().indexOf(second_shape), slide.getShapes().indexOf(third_shape)])

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

L’allineamento modifica le posizioni, non l’ordine Z. L’allineamento relativo richiede normalmente almeno due forme, mentre la distribuzione orizzontale o verticale necessita di un numero sufficiente di forme per definire la spaziatura. Ricalcola gli indici se modifichi la collezione prima di chiamare il metodo.

## **Ribaltare una forma**

La classe [ShapeFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapeframe/) memorizza posizione, dimensione, impostazioni di ribaltamento orizzontale e verticale e rotazione. I suoi valori [getFlipH](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapeframe/#getFlipH) e [getFlipV](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapeframe/#getFlipV) usano [NullableBool](https://reference.aspose.com/slides/it/python-java/aspose.slides/nullablebool/): `True` abilita il ribaltamento, `False` lo disabilita, e `NotDefined` mantiene lo stato non specificato/predefinito.

La presentazione di input sottostante contiene una forma non ribaltata.

![The shape before flipping](shape_to_be_flipped.png)

L’esempio preserva tutti gli altri valori del frame e sostituisce solo le due impostazioni di ribaltamento. Questo è importante perché assegnare un nuovo [Frame](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#setFrame) sostituisce l’intero frame.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    frame = shape.getFrame()

    print(f"Horizontal flip before change: {frame.getFlipH()}")
    print(f"Vertical flip before change: {frame.getFlipV()}")

    flipped_frame = ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True_, NullableBool.True_, frame.getRotation())
    shape.setFrame(flipped_frame)

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La forma salvata è riflessa orizzontalmente e verticalmente mantenendo posizione, dimensione e rotazione.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Devo usare un indice di collezione come identificatore di forma?**

Solo per elaborazioni di breve durata quando la collezione non cambierà prima dell’uso dell’indice. Preferisci una convenzione con [Name](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getName) o [AlternativeText](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getAlternativeText) per template creati, o [OfficeInteropShapeId](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getOfficeInteropShapeId) per lavori di interop a livello di diapositiva.

**Nascondere una forma la rimuove dall’ordine Z?**

No. Una forma nascosta rimane nella collezione allo stesso indice. Può essere trovata, riordinata, modificata o resa nuovamente visibile.

**Perché una forma clonata è comparsa davanti a un’altra forma?**

[addClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addClone) aggiunge il clone alla fine della collezione, che è il fronte dell’ordine Z. Usa [insertClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#insertClone) per scegliere l’indice iniziale o [reorder](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#reorder) dopo aver aggiunto tutte le forme.

**Posso usare un indice fisso per identificare una regolazione predefinita della forma?**

Solo dopo aver validato il preset esatto e la disposizione della collezione. Preferisci iterare attraverso [GeometryShape.getAdjustments](https://reference.aspose.com/slides/it/python-java/aspose.slides/geometryshape/#getAdjustments) e controllare [AdjustValue.getType](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/#getType); usa [AdjustValue.getName](https://reference.aspose.com/slides/it/python-java/aspose.slides/adjustvalue/#getName) come informazione aggiuntiva quando lo stesso tipo semantico appare più di una volta.