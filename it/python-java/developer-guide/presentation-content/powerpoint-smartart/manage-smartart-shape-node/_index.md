---
title: Gestire i nodi di forma SmartArt nelle presentazioni usando Python
linktitle: Nodo forma SmartArt
type: docs
weight: 30
url: /it/python-java/manage-smartart-shape-node/
keywords:
- nodo SmartArt
- nodo figlio
- aggiungere nodo
- posizione nodo
- accedere al nodo
- rimuovere nodo
- posizione personalizzata
- nodo assistente
- formato di riempimento
- nodo di rendering
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Gestisci i nodi di forma SmartArt in PPT e PPTX con Aspose.Slides for Python via Java. Ottieni esempi di codice chiari e suggerimenti per ottimizzare le tue presentazioni."
---
## **Panoramica**

I grafici SmartArt nelle presentazioni PowerPoint sono organizzati tramite nodi che contengono testo e definiscono la struttura del diagramma. Aspose.Slides consente di lavorare con questi nodi SmartArt in modo programmatico: aggiungere nuovi nodi e nodi figlio, inserire nodi figlio in una posizione specifica, accedere ai nodi esistenti e leggere il loro testo, livello e posizione.

Questo articolo spiega come gestire i nodi delle forme SmartArt. Mostra come rimuovere i nodi, lavorare con i nodi figlio per indice o posizione, trasformare un nodo assistente in un nodo normale, regolare la posizione, le dimensioni e la rotazione delle forme dei nodi SmartArt, impostare i formati di riempimento dei nodi e generare un'immagine miniatura per un nodo figlio SmartArt.

## **Aggiungere un nodo SmartArt**
Aspose.Slides for Python via Java fornisce un'API per gestire le forme SmartArt. L'esempio seguente aggiunge un nodo e un nodo figlio a una forma SmartArt.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e carica la presentazione contenente una forma SmartArt.
1. Ottieni la prima diapositiva per indice.
1. Itera su ogni forma nella prima diapositiva.
1. Verifica se la forma è un'istanza di [SmartArt](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartart/).
1. [Add a new node](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartartnodecollection/#addNode) alla [node collection](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartart/#getAllNodes) della forma SmartArt e imposta il suo testo tramite [TextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/).
1. [Add](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartartnodecollection/#addNode) un [child node](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartartnode/#getChildNodes) al nuovo nodo e imposta il suo testo tramite [TextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/).
1. Salva la presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("SimpleSmartArt.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            node = smart_art.getAllNodes().addNode()
            node.getTextFrame().setText("Test")
            child_node = node.getChildNodes().addNode()
            child_node.getTextFrame().setText("New Node Added")
    presentation.save("AddSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Aggiungere un nodo SmartArt in una posizione specifica**
L'esempio seguente aggiunge un nodo figlio in una posizione specifica in un nodo SmartArt.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Ottieni la prima diapositiva per indice.
1. Aggiungi una forma [SmartArt](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartart/) con il layout [StackedList](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartartlayouttype/#StackedList) alla diapositiva.
1. Accedi al primo nodo nella forma SmartArt aggiunta.
1. Aggiungi un nodo figlio al nodo selezionato nella posizione 2 usando [addNodeByPosition](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartartnodecollection/#addNodeByPosition) e imposta il suo testo.
1. Salva la presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    child_node = node.getChildNodes().addNodeByPosition(2)
    child_node.getTextFrame().setText("Sample Text Added")
    presentation.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Accedere a un nodo SmartArt**
L'esempio seguente accede ai nodi in una forma SmartArt. Il layout restituito da [getLayout](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartart/#getLayout) è di sola lettura ed è impostato quando la forma SmartArt viene aggiunta.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e carica la presentazione contenente una forma SmartArt.
1. Ottieni la prima diapositiva per indice.
1. Itera su ogni forma nella prima diapositiva.
1. Verifica se la forma è un'istanza di [SmartArt](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartart/).
1. Itera su tutti i [nodes](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartart/#getAllNodes) nella forma SmartArt.
1. Leggi e visualizza la posizione, il livello e il testo di ciascun nodo SmartArt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("SmartArtShape.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                print(node.getTextFrame().getText(), " ", node.getLevel(), " ", node.getPosition())
finally:
    presentation.dispose()
```

## **Accedere a un nodo figlio SmartArt**
L'esempio seguente accede ai nodi figlio di ciascun nodo in una forma SmartArt.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e carica la presentazione contenente una forma SmartArt.
1. Ottieni la prima diapositiva per indice.
1. Itera su ogni forma nella prima diapositiva.
1. Verifica se la forma è un'istanza di [SmartArt](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartart/).
1. Itera su tutti i [nodes](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartart/#getAllNodes) nella forma SmartArt.
1. Per ciascun nodo, iterare sui suoi [child nodes](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartartnode/#getChildNodes).
1. Leggi e visualizza la posizione, il livello e il testo del [child node](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartartnode/#getChildNodes).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessChildNodes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                parent_node = smart_art.getAllNodes().get_Item(i)
                for j in range(parent_node.getChildNodes().size()):
                    node = parent_node.getChildNodes().get_Item(j)
                    print("j = ", j, ", Text = ", node.getTextFrame().getText(), ",  Level = ", node.getLevel(), ", Position = ", node.getPosition())
finally:
    presentation.dispose()
```

## **Accedere a un nodo figlio SmartArt in una posizione specifica**
L'esempio seguente accede a un nodo figlio in un indice specifico nella collezione del nodo genitore.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Ottieni la prima diapositiva per indice.
1. Aggiungi una forma SmartArt con il layout [StackedList](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartartlayouttype/#StackedList).
1. Accedi alla forma SmartArt aggiunta.
1. Accedi al nodo all'indice 0 nella forma SmartArt.
1. Accedi al nodo figlio all'indice 1 usando [get_Item](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartartnodecollection/#get_Item).
1. Leggi e visualizza la posizione, il livello e il testo del [child node](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartartnode/#getChildNodes).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    position = 1
    child_node = node.getChildNodes().get_Item(position)
    print("Text = ", child_node.getTextFrame().getText(), ",  Level = ", child_node.getLevel(), ", Position = ", child_node.getPosition())
finally:
    presentation.dispose()
```

## **Rimuovere un nodo SmartArt**
L'esempio seguente rimuove un nodo da una forma SmartArt.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e carica la presentazione contenente una forma SmartArt.
1. Ottieni la prima diapositiva per indice.
1. Itera su ogni forma nella prima diapositiva.
1. Verifica se la forma è un'istanza di [SmartArt](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartart/).
1. Verifica che la forma [SmartArt](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartart/) contenga almeno un nodo.
1. Seleziona il nodo SmartArt da eliminare.
1. Rimuovi il nodo selezionato usando [removeNode](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartartnodecollection/#removeNode).
1. Salva la presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                smart_art.getAllNodes().removeNode(node)
    presentation.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Rimuovere un nodo SmartArt da una posizione specifica**
L'esempio seguente rimuove un nodo figlio in un indice specifico nella collezione di un nodo SmartArt.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e carica la presentazione contenente una forma SmartArt.
1. Ottieni la prima diapositiva per indice.
1. Itera su ogni forma nella prima diapositiva.
1. Verifica se la forma è un'istanza di [SmartArt](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartart/).
1. Accedi al nodo SmartArt all'indice 0 se esiste.
1. Verifica che il nodo SmartArt selezionato abbia almeno due nodi figlio.
1. Rimuovi il nodo figlio all'indice 1 usando [removeNode](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartartnodecollection/#removeNode).
1. Salva la presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                if node.getChildNodes().size() >= 2:
                    node.getChildNodes().removeNode(1)
    presentation.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Impostare una posizione personalizzata per un nodo figlio in un oggetto SmartArt**
Aspose.Slides for Python via Java supporta l'impostazione della posizione di uno [SmartArtShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartartshape/) usando [setX](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#setX) e [setY](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#setY). L'esempio seguente imposta una posizione, dimensione e rotazione personalizzate per le forme dei nodi SmartArt. L'aggiunta di nuovi nodi ricalcola le posizioni e le dimensioni di tutti i nodi. Il posizionamento personalizzato consente di disporre i nodi secondo le necessità.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart)
    node = smart_art.getAllNodes().get_Item(1)
    shape = node.getShapes().get_Item(1)
    shape.setX(shape.getX() + shape.getWidth() * 2)
    shape.setY(shape.getY() - shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(2)
    shape = node.getShapes().get_Item(1)
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2)
    node = smart_art.getAllNodes().get_Item(3)
    shape = node.getShapes().get_Item(1)
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(4)
    shape = node.getShapes().get_Item(1)
    shape.setRotation(90)
    presentation.save("SmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Verificare un nodo assistente**
{{% alert color="info" title="Note" %}} 

Questa sezione esplora le forme SmartArt aggiunte alle diapositive della presentazione programmaticamente usando Aspose.Slides for Python via Java.

{{% /alert %}} 

La forma SmartArt di origine utilizzata in questo esempio è la seguente.

|![SmartArt shape](https://i.imgur.com/FITWcZy.png)|
| :- |
|**Figura: Forma SmartArt di origine su una diapositiva**|

L'esempio seguente identifica i nodi assistente in una collezione di nodi SmartArt e li trasforma in nodi normali.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e carica la presentazione contenente una forma SmartArt.
1. Ottieni la prima diapositiva per indice.
1. Itera su ogni forma nella prima diapositiva.
1. Verifica se la forma è un'istanza di [SmartArt](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartart/).
1. Itera su tutti i nodi nella forma SmartArt e verifica se sono [Assistant Nodes](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartartnode/#isAssistant).
1. Cambia ciascun nodo assistente in un nodo normale.
1. Salva la presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddNodes.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                if node.isAssistant():
                    node.setAssistant(False)
    presentation.save("ChangeAssistantNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figura: Nodi assistente modificati in una forma SmartArt su una diapositiva**|

## **Impostare il formato di riempimento di un nodo**
Aspose.Slides for Python via Java rende possibile aggiungere forme SmartArt personalizzate e impostare il loro formato di riempimento. Questo articolo spiega come creare e accedere alle forme SmartArt e impostare il loro formato di riempimento usando Aspose.Slides for Python via Java.

Si prega di seguire i passi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Ottieni una diapositiva per indice.
1. Aggiungi una forma [SmartArt](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartart/) con il layout [ClosedChevronProcess](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartartlayouttype/#ClosedChevronProcess).
1. Imposta il [FillFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getFillFormat) per i nodi della forma SmartArt.
1. Scrivi la presentazione modificata come file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess)
    node = chevron.getAllNodes().addNode()
    node.getTextFrame().setText("Some text")
    for item in node.getShapes():
        item.getFillFormat().setFillType(FillType.Solid)
        item.getFillFormat().getSolidFillColor().setColor(Color.RED)
    presentation.save("TestSmart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Generare una miniatura di un nodo figlio SmartArt**
Per generare una miniatura di un nodo figlio SmartArt, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. [Add a SmartArt shape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addSmartArt).
1. Ottieni un nodo per indice.
1. Ottieni l'immagine miniatura.
1. Salva l'immagine miniatura in qualsiasi formato immagine desiderato.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType, ImageFormat

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle)
    node = smart_art.getNodes().get_Item(1)
    image = node.getShapes().get_Item(0).getImage()
    try:
        image.save("SmartArt_ChildNode_Thumbnail.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**L'animazione SmartArt è supportata?**

Sì. SmartArt è trattato come una forma normale, quindi è possibile [applicare animazioni standard](/slides/it/python-java/shape-animation/) (entrata, uscita, enfasi, percorsi di movimento) e regolare i tempi. È inoltre possibile animare le forme all'interno dei nodi SmartArt quando necessario.

**Come posso individuare in modo affidabile uno SmartArt specifico su una diapositiva se il suo ID interno è sconosciuto?**

Assegna e cerca tramite [alternative text](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getAlternativeText). Impostare un testo alternativo distintivo sullo SmartArt permette di trovarlo programmaticamente senza fare affidamento sugli identificatori interni.

**L'aspetto di SmartArt verrà conservato durante la conversione della presentazione in PDF?**

Sì. Aspose.Slides rende SmartArt con alta fedeltà visiva durante l'[esportazione PDF](/slides/it/python-java/convert-powerpoint-to-pdf/), preservando layout, colori ed effetti.

**Posso estrarre un'immagine dell'intero SmartArt (per anteprime o report)?**

Sì. È possibile rendere una forma SmartArt in [formati raster](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getImage) o in [SVG](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#writeAsSvgToBytes) per output vettoriale scalabile, rendendola adatta per miniature, report o utilizzo web.