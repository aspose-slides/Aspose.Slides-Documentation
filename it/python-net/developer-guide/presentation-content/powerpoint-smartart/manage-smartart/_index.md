---
title: Gestire SmartArt nelle presentazioni PowerPoint usando Python
linktitle: Gestire SmartArt
type: docs
weight: 10
url: /it/python-net/manage-smartart/
keywords:
- SmartArt
- Testo SmartArt
- tipo di layout
- proprietà nascosta
- organigramma
- organigramma con immagine
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Impara a creare e modificare SmartArt di PowerPoint con Aspose.Slides per Python tramite .NET usando esempi di codice chiari che accelerano la progettazione e l'automazione delle diapositive."
---
## **Panoramica**

SmartArt è un diagramma PowerPoint composto da nodi, forme dei nodi e un layout. Con Aspose.Slides per Python tramite .NET, è possibile creare SmartArt, leggere il testo dai suoi nodi, modificare il layout, ispezionare i nodi nascosti, configurare i layout del diagramma organizzativo e creare diagrammi organizzativi con immagini.

## **Ottenere il testo da un oggetto SmartArt**

Un nodo SmartArt può contenere una o più forme. Per leggere il testo dalle forme del nodo, iterare attraverso [SmartArt.all_nodes](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/all_nodes/), quindi leggere il [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) restituito da [SmartArtShape.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/text_frame/).

L'esempio richiede una presentazione con almeno una diapositiva e un oggetto SmartArt come prima forma su quella diapositiva. Stampa ogni frame di testo disponibile nella console.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        for node in shape.all_nodes:
            for node_shape in node.shapes:
                if node_shape.text_frame is not None:
                    print(node_shape.text_frame.text)
```

## **Modificare il tipo di layout di un oggetto SmartArt**

Il layout SmartArt controlla come i nodi sono disposti e collegati. L'esempio seguente crea un oggetto SmartArt con il valore [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST`, lo cambia al valore `BASIC_PROCESS` e salva la presentazione. La posizione e la dimensione passate a [ShapeCollection.add_smart_art](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_smart_art/) sono misurate in punti. Impostare [SmartArt.layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/layout/) per modificare il layout.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Verificare se un nodo SmartArt è nascosto**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/is_hidden/) indica se il nodo è nascosto nel modello dati SmartArt. I nodi nascosti possono esistere nella struttura anche quando il layout selezionato non li visualizza come elementi del diagramma.

L'esempio seguente aggiunge un nodo a un oggetto SmartArt che utilizza il valore [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` e verifica lo stato nascosto del nodo aggiunto. Stampa un messaggio se il nodo è nascosto e salva il diagramma.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)
    node = smart_art.all_nodes.add_node()
    is_hidden = node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", slides.export.SaveFormat.PPTX)
```

## **Ottenere o impostare il layout del diagramma organizzativo**

Per i diagrammi SmartArt che usano un layout di diagramma organizzativo, [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) definisce come i nodi figli sono disposti sotto un nodo genitore. Ad esempio, è possibile impostare i nodi figli per pendere a sinistra, a destra o su entrambi i lati, a seconda del [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) selezionato.

L'esempio seguente crea un diagramma organizzativo e imposta il layout per il primo nodo al valore [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING`. L'indice basato su zero `0` seleziona il primo nodo di livello superiore; i suoi nodi figli usano la disposizione selezionata. La presentazione modificata viene quindi salvata.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)
    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Creare un diagramma organizzativo con immagine**

Un diagramma organizzativo con immagine è un layout SmartArt progettato per diagrammi gerarchici che includono segnaposto immagine. Usare il valore [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` quando si aggiunge l'oggetto SmartArt a una diapositiva. Questo esempio salva un diagramma con segnaposto immagine; non popola i segnaposto con immagini.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Convertire diagrammi legacy in gruppi di forme**

Durante la modernizzazione di una presentazione esistente, potrebbe essere necessario aggiornare un diagramma organizzativo creato originariamente in PowerPoint 97–2003. Aspose.Slides rappresenta questi diagrammi legacy come oggetti [LegacyDiagram](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/). Usare [LegacyDiagram.convert_to_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/convert_to_group_shape/) per convertire un diagramma in un gruppo di forme così da poter modificare gli elementi visivi individuali. Consultare il [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/) per i dettagli.

La conversione aggiunge un nuovo gruppo alla raccolta di forme senza rimuovere il diagramma originale. Dopo una conversione riuscita, rimuovere l'originale con [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) per evitare contenuti duplicati. Raccogliere i diagrammi legacy in un elenco prima di convertirli in modo che l'aggiunta e la rimozione di forme non interrompano l'iterazione.

L'esempio seguente apre una presentazione, ricerca ogni diapositiva, converte i diagrammi in gruppi di forme e salva la presentazione aggiornata come PPTX.

```python
import aspose.slides as slides

with slides.Presentation("legacy-diagrams.ppt") as presentation:
    for slide in presentation.slides:
        legacy_diagrams = [shape for shape in slide.shapes if isinstance(shape, slides.LegacyDiagram)]
        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convert_to_group_shape()

            if group_shape is not None:
                slide.shapes.remove(legacy_diagram)

    presentation.save("modernized.pptx", slides.export.SaveFormat.PPTX)
```

La presentazione salvata contiene gruppi di forme modificabili al posto dei diagrammi legacy convertiti, senza diagrammi originali rimasti accanto. Aprire il PPTX in PowerPoint per modificare gli elementi individuali all'interno di ogni gruppo, come testo, riempimento o posizione.

## **FAQ**

**SmartArt supporta il mirroring o l'inversione per le lingue RTL?**

Sì. La proprietà [SmartArt.is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) cambia la direzione del diagramma da sinistra‑destra a destra‑sinistra, o viceversa, quando il layout SmartArt selezionato supporta l'inversione.

**Come posso copiare SmartArt nella stessa diapositiva o in un'altra presentazione mantenendo la formattazione?**

È possibile [clonare la forma SmartArt](/slides/it/python-net/shape-manipulations/) con [ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/) o [clonare l'intera diapositiva](/slides/it/python-net/clone-slides/) che contiene lo SmartArt. Entrambi gli approcci conservano dimensioni, posizione e formattazione.

**Come posso rendere SmartArt in un'immagine raster per anteprima o esportazione web?**

[Render la diapositiva](/slides/it/python-net/convert-powerpoint-to-png/) o l'intera presentazione in PNG o JPEG. SmartArt viene renderizzato come parte della diapositiva.

**Come posso trovare un oggetto SmartArt specifico su una diapositiva se ce ne sono diversi?**

Impostare un valore distintivo per [Shape.alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) o [Shape.name](https://reference.aspose.com/slides/python-net/aspose.slides/shape/name/) sulla forma SmartArt, cercare quel valore in [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/), e verificare che la forma corrispondente sia un [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/).