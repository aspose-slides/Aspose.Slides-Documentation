---
title: Gestire SmartArt nelle presentazioni PowerPoint con Python
linktitle: Gestire SmartArt
type: docs
weight: 10
url: /it/python-net/manage-smartart/
keywords:
- SmartArt
- testo da SmartArt
- tipo di layout
- proprietà nascosta
- diagramma organizzativo
- diagramma organizzativo con immagine
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Impara a creare e modificare SmartArt PowerPoint con Aspose.Slides per Python tramite .NET usando chiari esempi di codice che accelerano la progettazione e l'automazione delle diapositive."
---
## **Panoramica**

SmartArt è un diagramma di PowerPoint composto da nodi, forme dei nodi e un layout. Con Aspose.Slides per Python tramite .NET, è possibile creare SmartArt, leggere il testo dai suoi nodi, modificarne il layout, ispezionare i nodi nascosti, configurare i layout dei diagrammi organizzativi e creare diagrammi organizzativi con immagini.

## **Recuperare il testo da un oggetto SmartArt**

Un nodo SmartArt può contenere una o più forme. Per leggere il testo visibile, iterare attraverso [SmartArt.all_nodes](https://reference.aspose.com/slides/it/python-net/aspose.slides.smartart/smartart/all_nodes/), quindi leggere il [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/) restituito da [SmartArtShape.text_frame](https://reference.aspose.com/slides/it/python-net/aspose.slides.smartart/smartartshape/text_frame/).

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        smart_art = shape

        for smart_art_node in smart_art.all_nodes:
            for smart_art_shape in smart_art_node.shapes:
                if smart_art_shape.text_frame is not None:
                    print(smart_art_shape.text_frame.text)
```

## **Modificare il tipo di layout di un oggetto SmartArt**

Il layout di SmartArt controlla come i nodi sono disposti e collegati. L'esempio seguente crea un oggetto SmartArt con il valore [SmartArtLayoutType](https://reference.aspose.com/slides/it/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST`, lo cambia al valore `BASIC_PROCESS` e salva la presentazione.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Verificare se un nodo SmartArt è nascosto**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/it/python-net/aspose.slides.smartart/smartartnode/is_hidden/) indica se il nodo è nascosto nel modello dati di SmartArt. I nodi nascosti possono esistere nella struttura anche quando il layout selezionato non li mostra come elementi visibili del diagramma.

L'esempio seguente aggiunge un nodo a un oggetto SmartArt che utilizza il valore [SmartArtLayoutType](https://reference.aspose.com/slides/it/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` e verifica lo stato di nascondimento del nodo.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    smart_art_node = smart_art.all_nodes.add_node()
    is_hidden = smart_art_node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ottenere o impostare il layout del diagramma organizzativo**

Per i diagrammi SmartArt che usano un layout di diagramma organizzativo, [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/it/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) definisce come i nodi figli sono disposti sotto un nodo genitore. Per esempio, è possibile impostare i nodi figli in modo che pendano a sinistra, a destra o su entrambi i lati, a seconda del [OrganizationChartLayoutType](https://reference.aspose.com/slides/it/python-net/aspose.slides.smartart/organizationchartlayouttype/) selezionato.

L'esempio seguente crea un diagramma organizzativo e imposta il layout del primo nodo al valore [OrganizationChartLayoutType](https://reference.aspose.com/slides/it/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING`.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Creare un diagramma organizzativo con immagine**

Un diagramma organizzativo con immagine è un layout SmartArt progettato per diagrammi gerarchici che includono segnaposti immagine. Utilizzare il valore [SmartArtLayoutType](https://reference.aspose.com/slides/it/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` quando si aggiunge l'oggetto SmartArt a una diapositiva.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**SmartArt supporta il mirroring o l'inversione per le lingue RTL?**

Sì. La proprietà [SmartArt.is_reversed](https://reference.aspose.com/slides/it/python-net/aspose.slides.smartart/smartart/is_reversed/) inverte la direzione del diagramma da sinistra‑destra a destra‑sinistra, o viceversa, quando il layout SmartArt selezionato supporta l'inversione.

**Come posso copiare SmartArt nella stessa diapositiva o in un'altra presentazione mantenendo la formattazione?**

È possibile [clonare la forma SmartArt](/slides/it/python-net/shape-manipulations/) con [ShapeCollection.add_clone](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/add_clone/) o [clonare l'intera diapositiva](/slides/it/python-net/clone-slides/) che contiene lo SmartArt. Entrambi gli approcci conservano dimensione, posizione e formattazione.

**Come posso renderizzare SmartArt in un'immagine raster per l'anteprima o l'esportazione web?**

[Renderizza la diapositiva](/slides/it/python-net/convert-powerpoint-to-png/) o l'intera presentazione in PNG o JPEG. SmartArt viene renderizzato come parte della diapositiva.

**Come posso trovare uno specifico oggetto SmartArt in una diapositiva se ce ne sono diversi?**

Imposta un valore distintivo per [Shape.alternative_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/alternative_text/) o [Shape.name](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/name/) sulla forma SmartArt, cerca tale valore in [Slide.shapes](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/shapes/), e quindi verifica che la forma corrispondente sia un [SmartArt](https://reference.aspose.com/slides/it/python-net/aspose.slides.smartart/smartart/).