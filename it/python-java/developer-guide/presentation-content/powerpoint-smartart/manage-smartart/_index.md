---
title: Gestire SmartArt nelle presentazioni PowerPoint con Python
linktitle: Gestire SmartArt
type: docs
weight: 10
url: /it/python-java/manage-smartart/
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
description: "Impara a creare e modificare SmartArt di PowerPoint con Aspose.Slides per Python tramite Java usando esempi di codice chiari che accelerano la progettazione e l'automazione delle diapositive."
---
## **Panoramica**

SmartArt è un diagramma PowerPoint composto da nodi, forme dei nodi e un layout. Con Aspose.Slides per Python tramite Java, è possibile creare SmartArt, leggere il testo dai suoi nodi, modificare il layout, ispezionare i nodi nascosti, configurare i layout dei diagrammi organizzativi e creare diagrammi organizzativi con immagine.

## **Ottenere testo da un oggetto SmartArt**

Un nodo SmartArt può contenere una o più forme. Per leggere il testo visibile, iterare attraverso [SmartArt.getAllNodes](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartart/#getAllNodes), quindi leggere il [TextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/) restituito da [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartartshape/#getTextFrame).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, SmartArt):
        smart_art = shape

        for node in smart_art.getAllNodes():
            for node_shape in node.getShapes():
                if node_shape.getTextFrame() is not None:
                    print(node_shape.getTextFrame().getText())
finally:
    presentation.dispose()
```

## **Modificare il tipo di layout di un oggetto SmartArt**

Il layout di SmartArt controlla come i nodi sono disposti e collegati. L'esempio seguente crea un oggetto SmartArt con il valore `BasicBlockList` di [SmartArtLayoutType](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartartlayouttype/), lo modifica al valore `BasicProcess` e salva la presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)

    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Verificare se un nodo SmartArt è nascosto**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartartnode/#isHidden) indica se il nodo è nascosto nel modello di dati SmartArt. I nodi nascosti possono esistere nella struttura anche quando il layout selezionato non li visualizza come elementi del diagramma.

L'esempio seguente aggiunge un nodo a un oggetto SmartArt che utilizza il valore `RadialCycle` di [SmartArtLayoutType](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartartlayouttype/) e verifica lo stato di nascondimento del nodo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)

    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ottenere o impostare il layout del diagramma organizzativo**

Per i diagrammi SmartArt che utilizzano un layout di diagramma organizzativo, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) e [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) definiscono come i nodi figli sono disposti sotto un nodo genitore. Ad esempio, è possibile impostare i nodi figli per pendi a sinistra, a destra o su entrambi i lati, a seconda del [OrganizationChartLayoutType](https://reference.aspose.com/slides/it/python-java/aspose.slides/organizationchartlayouttype/) selezionato.

L'esempio seguente crea un diagramma organizzativo e imposta il layout del primo nodo al valore `LeftHanging` di [OrganizationChartLayoutType](https://reference.aspose.com/slides/it/python-java/aspose.slides/organizationchartlayouttype/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)

    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Creare un diagramma organizzativo con immagine**

Un diagramma organizzativo con immagine è un layout SmartArt progettato per diagrammi gerarchici che includono segnaposti per immagini. Utilizzare il valore `PictureOrganizationChart` di [SmartArtLayoutType](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartartlayouttype/) quando si aggiunge l'oggetto SmartArt a una diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**SmartArt supporta la riflessione o l'inversione per le lingue RTL?**

Sì. Il metodo [SmartArt.setReversed](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartart/#setReversed) cambia la direzione del diagramma da sinistra‑destra a destra‑sinistra, o viceversa, quando il layout SmartArt selezionato supporta l'inversione.

**Come posso copiare SmartArt nella stessa diapositiva o in un'altra presentazione mantenendo la formattazione?**

È possibile [clonare la forma SmartArt](/slides/it/python-java/shape-manipulations/) con [ShapeCollection.addClone](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addClone) o [clonare l'intera diapositiva](/slides/it/python-java/clone-slides/) che contiene lo SmartArt. Entrambi gli approcci conservano dimensione, posizione e formattazione.

**Come posso renderizzare SmartArt in un'immagine raster per l'anteprima o l'esportazione web?**

[Renderizzare la diapositiva](/slides/it/python-java/convert-powerpoint-to-png/) o l'intera presentazione in PNG o JPEG. SmartArt viene renderizzato come parte della diapositiva.

**Come posso trovare un oggetto SmartArt specifico su una diapositiva se ce ne sono diversi?**

Imposta un valore distintivo per [Shape.getAlternativeText](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getAlternativeText) o [Shape.getName](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getName) sulla forma SmartArt, cerca quel valore in [BaseSlide.getShapes](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslide/#getShapes) e verifica che la forma corrispondente sia un [SmartArt](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartart/).