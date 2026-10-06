---
title: Gestire SmartArt nelle presentazioni PowerPoint utilizzando Python
linktitle: Gestire SmartArt
type: docs
weight: 10
url: /it/python-java/manage-smartart/
keywords:
- SmartArt
- Testo SmartArt
- Tipo di layout
- Proprietà nascosta
- Organigramma
- Organigramma con immagine
- PowerPoint
- Presentazione
- Python
- Aspose.Slides
description: "Impara a creare e modificare SmartArt di PowerPoint con Aspose.Slides per Python tramite Java usando esempi di codice chiari che accelerano la progettazione e l'automazione delle diapositive."
---
## **Panoramica**

SmartArt è un diagramma PowerPoint composto da nodi, forme dei nodi e un layout. Con Aspose.Slides per Python tramite Java, è possibile creare SmartArt, leggere il testo dai suoi nodi, modificare il layout, ispezionare i nodi nascosti, configurare i layout dei grafici organizzativi e creare grafici organizzativi con immagini.

## **Ottenere il testo da un oggetto SmartArt**

Un nodo SmartArt può contenere una o più forme. Per leggere il testo dalle forme del nodo, itera attraverso [SmartArt.getAllNodes](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#getAllNodes), quindi leggi il [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) restituito da [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartshape/#getTextFrame).

L'esempio richiede una presentazione con almeno una diapositiva e un oggetto SmartArt come prima forma su quella diapositiva. Stampa ogni frame di testo disponibile sulla console.

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

Il layout di SmartArt controlla come i nodi sono disposti e collegati. L'esempio seguente crea un oggetto SmartArt con il valore `BasicBlockList` di [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/), lo cambia al valore `BasicProcess` e salva la presentazione. La posizione e le dimensioni passate a [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSmartArt) sono misurate in punti. Usa [SmartArt.setLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setLayout) per modificare il layout.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Verificare se un nodo SmartArt è nascosto**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#isHidden) indica se il nodo è nascosto nel modello dati di SmartArt. I nodi nascosti possono esistere nella struttura anche quando il layout selezionato non li visualizza come elementi del diagramma.

L'esempio seguente aggiunge un nodo a un oggetto SmartArt che utilizza il valore `RadialCycle` di [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) e verifica lo stato nascosto del nodo aggiunto. Stampa un messaggio se il nodo è nascosto e salva il diagramma.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)
    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ottenere o impostare il layout del grafico organizzativo**

Per i diagrammi SmartArt che utilizzano un layout di grafico organizzativo, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) e [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) definiscono come i nodi figlio sono disposti sotto un nodo genitore. Ad esempio, è possibile impostare i nodi figlio per pendere a sinistra, a destra o su entrambi i lati, a seconda del [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) selezionato.

L'esempio seguente crea un grafico organizzativo e imposta il layout per il primo nodo al valore `LeftHanging` di [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/). L'indice basato su zero `0` seleziona il primo nodo di livello superiore; i suoi nodi figlio usano la disposizione selezionata. La presentazione modificata viene quindi salvata.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)
    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Creare un grafico organizzativo con immagine**

Un grafico organizzativo con immagine è un layout SmartArt progettato per diagrammi gerarchici che includono segnaposti immagine. Usa il valore `PictureOrganizationChart` di [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) quando aggiungi l'oggetto SmartArt a una diapositiva. Questo esempio salva un diagramma con segnaposti immagine; non popola i segnaposti con immagini.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Convertire diagrammi legacy in gruppi di forme**

Durante la modernizzazione di una presentazione esistente, potrebbe essere necessario aggiornare un grafico organizzativo creato originariamente in PowerPoint 97–2003. Aspose.Slides rappresenta questi diagrammi legacy come oggetti [LegacyDiagram](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/). Usa [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/#convertToGroupShape) per convertire un diagramma in un gruppo di forme così da poter modificare singoli elementi visivi. Consulta il [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/) per i dettagli.

La conversione aggiunge un nuovo gruppo alla raccolta di forme senza rimuovere il diagramma originale. Dopo una conversione riuscita, rimuovi l'originale con [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) per evitare contenuti duplicati. Raccogli i diagrammi legacy in un elenco prima di convertirli in modo che l'aggiunta e la rimozione di forme non interrompano l'iterazione.

L'esempio seguente apre una presentazione, cerca in ogni diapositiva, converte i diagrammi in gruppi di forme e salva la presentazione aggiornata come PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LegacyDiagram, Presentation, SaveFormat

presentation = Presentation("legacy-diagrams.ppt")
try:
    for slide in presentation.getSlides():
        legacy_diagrams = []
        for shape in slide.getShapes():
            if isinstance(shape, LegacyDiagram):
                legacy_diagrams.append(shape)

        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convertToGroupShape()

            if group_shape is not None:
                slide.getShapes().remove(legacy_diagram)

    presentation.save("modernized.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La presentazione salvata contiene gruppi di forme modificabili al posto dei diagrammi legacy convertiti, senza diagrammi originali rimasti accanto. Apri il PPTX in PowerPoint per modificare gli elementi individuali all'interno di ogni gruppo, come il loro testo, riempimento o posizione.

## **Domande frequenti**

**SmartArt supporta il mirroring o l'inversione per le lingue RTL?**

Sì. Il metodo [SmartArt.setReversed](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setReversed) cambia la direzione del diagramma da sinistra‑destra a destra‑sinistra, o viceversa, quando il layout SmartArt selezionato supporta l'inversione.

**Come posso copiare SmartArt nella stessa diapositiva o in un'altra presentazione mantenendo la formattazione?**

Puoi [clonare la forma SmartArt](/slides/it/python-java/shape-manipulations/) con [ShapeCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addClone) o [clonare l'intera diapositiva](/slides/it/python-java/clone-slides/) che contiene lo SmartArt. Entrambi gli approcci preservano dimensione, posizione e formattazione.

**Come posso renderizzare SmartArt in un'immagine raster per l'anteprima o l'esportazione web?**

[Renderizza la diapositiva](/slides/it/python-java/convert-powerpoint-to-png/) o l'intera presentazione in PNG o JPEG. SmartArt viene renderizzato come parte della diapositiva.

**Come posso trovare un oggetto SmartArt specifico su una diapositiva se ce ne sono diversi?**

Usa [Shape.setAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setAlternativeText) o [Shape.setName](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setName) per assegnare un testo alternativo o un nome distintivo alla forma SmartArt, cerca quel valore in [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes), quindi verifica che la forma corrispondente sia un [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/).