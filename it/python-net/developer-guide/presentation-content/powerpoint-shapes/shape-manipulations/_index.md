---
title: Gestire le forme nelle presentazioni usando Python
linktitle: Manipolazione delle forme
type: docs
weight: 40
url: /it/python-net/shape-manipulations/
keywords:
- Forma PowerPoint
- forma della presentazione
- forma su diapositiva
- trova forma
- clona forma
- rimuovi forma
- nascondi forma
- cambia ordine forma
- ottieni ID forma Interop
- testo alternativo della forma
- formati layout della forma
- forma come SVG
- forma in SVG
- allinea forma
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Impara a creare, modificare e ottimizzare le forme in Aspose.Slides per Python tramite .NET e fornire presentazioni PowerPoint e OpenDocument ad alte prestazioni."
---
## **Panoramica**

Questa guida introduce la manipolazione delle forme in Aspose.Slides per Python tramite .NET. Impara modelli pratici per trovare forme (incluso tramite Testo Alternativo), duplicare, eliminare o nascondere, riordinare, allineare e capovolgere, leggere ID e formattazione basata sul layout, ed esportare forme individuali in SVG usando le API [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/).

## **Trova forme nelle diapositive**

PowerPoint identifica le forme solo tramite ID interni. Assegna un Testo Alternativo unico alla forma target in PowerPoint, quindi apri la presentazione con Aspose.Slides per Python, itera le forme della diapositiva e seleziona quella il cui Testo Alternativo corrisponde. Il metodo `find_shape` implementa questo approccio e restituisce la forma corrispondente.

```py
import aspose.slides as slides

# Trova una forma su una diapositiva tramite il suo testo alternativo.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Istanzia la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Trova la forma con Alt Text "Shape1".
    shape = find_shape(slide, "Shape1")
    if shape is not None:
        print("Shape name:", shape.name)
```

## **Clona forme**

Per clonare forme da una diapositiva di origine a una nuova diapositiva in Aspose.Slides, segui questi passaggi:

1. Crea una [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) dal file sorgente.  
1. Ottieni la diapositiva di origine per indice e la sua raccolta di forme.  
1. Recupera un layout vuoto dalla diapositiva master.  
1. Aggiungi una diapositiva vuota usando quel layout e ottieni le sue forme.  
1. Clona le forme nella diapositiva di destinazione.  
1. Salva la presentazione come PPTX.

Il seguente esempio di codice clona le forme da una diapositiva all’altra.

```py
import aspose.slides as slides

# Istanzia la classe Presentation.
with slides.Presentation("sample.pptx") as presentation:
    source_shapes = presentation.slides[0].shapes
    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    target_slide = presentation.slides.add_empty_slide(blank_layout)
    target_shapes = target_slide.shapes
	
    target_shapes.add_clone(source_shapes[1], 50, 150 + source_shapes[0].height)
    target_shapes.add_clone(source_shapes[2])
    target_shapes.insert_clone(0, source_shapes[0], 50, 150)

    # Salva la presentazione su disco.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Rimuovi forme**

Aspose.Slides ti consente di rimuovere qualsiasi forma da una diapositiva. Ad esempio, per eliminare una forma dalla prima diapositiva tramite il suo Testo Alternativo, segui questi passaggi:

1. Crea un’istanza di [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e carica il file.  
1. Accedi alla prima diapositiva dalla raccolta di diapositive.  
1. Trova la forma per valore del Testo Alternativo.  
1. Rimuovi la forma dalla raccolta di forme della diapositiva.  
1. Salva la presentazione su disco in formato PPTX.

```py
import aspose.slides as slides

# Trova una forma su una diapositiva tramite il suo testo alternativo.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Istanzia la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Trova la forma con Alt Text "User Defined".
    shape = find_shape(slide, "User Defined")
    # Rimuovi la forma.
    slide.shapes.remove(shape)
    # Salva la presentazione su disco.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Nascondi forme**

Aspose.Slides ti consente di nascondere qualsiasi forma su una diapositiva. Ad esempio, per nascondere una forma sulla prima diapositiva tramite il suo Testo Alternativo, segui questi passaggi:

1. Crea un’istanza di [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e carica il file.  
1. Accedi alla prima diapositiva dalla raccolta di diapositive.  
1. Trova la forma per valore del Testo Alternativo.  
1. Nascondi la forma.  
1. Salva la presentazione su disco in formato PPTX.

```py
# Trova una forma su una diapositiva tramite il suo testo alternativo.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Istanzia la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Trova la forma con Alt Text "User Defined".
    shape = find_shape(slide, "User Defined")
    # Nascondi la forma.
    shape.hidden = True
    # Salva la presentazione su disco.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Modifica l'ordine delle forme**

Aspose.Slides consente agli sviluppatori di riordinare le forme (cambiare il loro z‑order). Il riordino determina quale forma appare davanti o dietro. Per esempio, per riordinare due forme sulla prima diapositiva, segui i passaggi seguenti:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).  
1. Accedi alla prima diapositiva.  
1. Aggiungi la prima forma (ad esempio, un rettangolo).  
1. Aggiungi la seconda forma (ad esempio, un triangolo).  
1. Riordina le forme spostando la seconda forma nella prima posizione della raccolta.  
1. Salva la presentazione su disco.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Aggiungi due forme alla diapositiva.
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 150)
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 20, 200, 200, 150)
    # Sposta la seconda forma nella prima posizione.
    slide.shapes.reorder(0, shape2)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ottieni l'ID della forma Interop**

Aspose.Slides ti consente di ottenere l'identificatore unico di una forma a livello di diapositiva, a differenza della proprietà `unique_id`, che è unica su tutta la presentazione. La proprietà `office_interop_shape_id` è disponibile sulla classe [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/). Il suo valore corrisponde all'`Id` dell'oggetto `Microsoft.Office.Interop.PowerPoint.Shape`. Un esempio di codice è mostrato di seguito.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Ottieni l'identificatore unico della forma all'interno della diapositiva.
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```

## **Imposta il Testo Alternativo per le forme**

Aspose.Slides consente agli sviluppatori di impostare il testo alternativo per qualsiasi forma. Puoi usare il testo alternativo per identificare e localizzare le forme in una presentazione. La proprietà del testo alternativo può essere letta e scritta sia tramite Aspose.Slides sia tramite Microsoft PowerPoint. Etichettando le forme con questa proprietà, potrai successivamente rimuoverle, nasconderle o riordinarle su una diapositiva.

Per impostare il testo alternativo di una forma, segui questi passaggi:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).  
1. Accedi alla prima diapositiva.  
1. Aggiungi una forma alla diapositiva.  
1. Imposta il testo alternativo.  
1. Salva la presentazione su disco.

```py
import aspose.slides as slides

# Instanzia la classe Presentation che rappresenta un file PPTX.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    # Aggiungi una forma.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    # Imposta il testo alternativo per la forma.
    shape.alternative_text = "User Defined"
    # Salva la presentazione su disco.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Accedi ai formati di layout per le forme**

Aspose.Slides fornisce un’API semplice per accedere ai formati di layout per le forme. Questa sezione mostra come accedere a tali formati.

```py
import aspose.slides as slides

with slides.Presentation(folder_path + "sample.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        fill_formats = list(map(lambda shape: shape.fill_format, layout_slide.shapes))
        line_formats = list(map(lambda shape: shape.line_format, layout_slide.shapes))
```

## **Renderizza forme come SVG**

Aspose.Slides supporta il rendering delle forme come SVG. Il metodo `write_as_svg` (e le sue sovraccariche) sulla classe [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/) permette di salvare il contenuto di una forma come immagine SVG. Il frammento di codice sotto mostra come esportare una forma in un file SVG.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    with open("output.svg", "wb") as image_stream:
        # Ottieni la prima forma sulla prima diapositiva.
        shape = presentation.slides[0].shapes[0]
        shape.write_as_svg(image_stream)
```

## **Allinea forma**

Utilizzando il metodo `align_shape` nella classe [SlidesUtil](https://reference.aspose.com/slides/it/python-net/aspose.slides.util/slideutil/), puoi:

* Allineare le forme rispetto ai margini della diapositiva (vedi Esempio 1).  
* Allineare le forme rispetto le une alle altre (vedi Esempio 2).

L’enumerazione [ShapesAlignmentType](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapesalignmenttype/) definisce le opzioni di allineamento disponibili.

**Esempio 1**

Questo codice Python mostra come allineare le forme con indice 1, 2 e 4 al bordo superiore della diapositiva:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_TOP
slide_indices = [1, 2, 4]

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    slides.util.SlideUtil.align_shapes(align_type, True, slide, slide_indices)
```

**Esempio 2**

Questo esempio Python mostra come allineare tutte le forme in una raccolta rispetto alla forma più in basso di quella raccolta:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_BOTTOM

with slides.Presentation("sample.pptx") as presentation:
    slides.util.SlideUtil.align_shapes(align_type, False, presentation.slides[0])
```

## **Proprietà di capovolgimento**

In Aspose.Slides, la classe [ShapeFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapeframe/) fornisce il controllo sul mirroring orizzontale e verticale delle forme tramite le proprietà `flip_h` e `flip_v`. Entrambe le proprietà sono di tipo [NullableBool](https://reference.aspose.com/slides/it/python-net/aspose.slides/nullablebool/), consentendo valori `TRUE` per indicare un capovolgimento, `FALSE` per nessun capovolgimento o `NOT_DEFINED` per usare il comportamento predefinito. Questi valori sono accessibili dal [Frame](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/frame/) di una forma.

Per modificare le impostazioni di capovolgimento, viene costruita una nuova istanza di [ShapeFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapeframe/) con la posizione e le dimensioni attuali della forma, i valori desiderati per `flip_h` e `flip_v` e l’angolo di rotazione. Assegnando questa istanza al [Frame](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/frame/) della forma e salvando la presentazione si applicano le trasformazioni di mirroring e si scrivono nel file di output.

Supponiamo di avere un file sample.pptx in cui la prima diapositiva contiene una sola forma con le impostazioni di capovolgimento predefinite, come mostrato di seguito.

![La forma da capovolgere](shape_to_be_flipped.png)

Il seguente esempio di codice recupera le attuali proprietà di capovolgimento della forma e la capovolge sia orizzontalmente che verticalmente.

```py
with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    # Recupera la proprietà di capovolgimento orizzontale della forma.
    horizontal_flip = shape.frame.flip_h
    print("Horizontal flip:", horizontal_flip)

    # Recupera la proprietà di capovolgimento verticale della forma.
    vertical_flip = shape.frame.flip_v
    print("Vertical flip:", vertical_flip)

    x, y = shape.frame.x, shape.frame.y
    width, height = shape.frame.width, shape.frame.height
    flip_h, flip_v = slides.NullableBool.TRUE, slides.NullableBool.TRUE  # Capovolgi orizzontalmente e verticalmente.
    rotation = shape.frame.rotation

    shape.frame = slides.ShapeFrame(x, y, width, height, flip_h, flip_v, rotation)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![La forma capovolta](flipped_shape.png)

## **FAQ**

**Posso combinare forme (unione/intersezione/sottrazione) su una diapositiva come in un editor desktop?**

Non esiste un’API di operazioni booleane integrata. Puoi approssimarla costruendo manualmente il contorno desiderato, ad esempio calcolando la geometria risultante (tramite [GeometryPath](https://reference.aspose.com/slides/it/python-net/aspose.slides/geometrypath/)) e creando una nuova forma con quel contorno, rimuovendo opzionalmente le originali.

**Come posso controllare l'ordine di impilamento (z‑order) in modo che una forma rimanga sempre “in cima”?**

Modifica l’ordine di inserimento/spostamento all’interno della raccolta [shapes](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/shapes/) della diapositiva. Per risultati prevedibili, finalizza lo z‑order dopo aver completato tutte le altre modifiche alla diapositiva.

**Posso “bloccare” una forma per impedire agli utenti di modificarla in PowerPoint?**

Sì. Imposta le [shape-level protection flags](/slides/it/python-net/applying-protection-to-presentation/) (ad es. blocca selezione, spostamento, ridimensionamento, modifica del testo). Se necessario, estendi le restrizioni al master o al layout. Nota che questa è una protezione a livello UI, non una misura di sicurezza; per una protezione più forte, combina con restrizioni a livello di file come [raccomandazioni di sola lettura o password](/slides/it/python-net/password-protected-presentation/).