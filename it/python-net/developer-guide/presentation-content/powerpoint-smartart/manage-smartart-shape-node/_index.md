---
title: Gestisci i nodi di forma SmartArt nelle presentazioni usando Python
linktitle: Nodo di forma SmartArt
type: docs
weight: 30
url: /it/python-net/manage-smartart-shape-node/
keywords:
- nodo SmartArt
- nodo figlio
- aggiungi nodo
- posizione nodo
- accedi al nodo
- rimuovi nodo
- posizione personalizzata
- nodo assistente
- formato di riempimento
- nodo di rendering
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Gestisci i nodi di forma SmartArt in PPT, PPTX e ODP con Aspose.Slides per Python via .NET. Ottieni esempi di codice chiari e consigli per semplificare le tue presentazioni."
---
## **Panoramica**

Le grafiche SmartArt nelle presentazioni PowerPoint sono organizzate tramite nodi che contengono testo e definiscono la struttura del diagramma. Aspose.Slides consente di lavorare con questi nodi SmartArt in modo programmatico: aggiungere nuovi nodi e nodi figlio, inserire nodi figlio in una posizione specifica, accedere ai nodi esistenti e leggere il loro testo, livello e posizione.

Questo articolo spiega come gestire i nodi di forma SmartArt. Mostra come rimuovere i nodi, lavorare con i nodi figlio per indice o posizione, trasformare un nodo assistente in un nodo normale, regolare la posizione, le dimensioni e la rotazione delle forme dei nodi SmartArt, impostare i formati di riempimento dei nodi e generare un'immagine in miniatura per un nodo figlio SmartArt.

## **Aggiungi nodo SmartArt**
Aspose.Slides per Python via .NET ha fornito l'API più semplice per gestire le forme SmartArt nel modo più facile. Il codice di esempio seguente aiuterà ad aggiungere un nodo e un nodo figlio all'interno di una forma SmartArt.

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e carica la presentazione con la forma SmartArt.
- Ottieni il riferimento della prima slide utilizzando il suo indice.
- Scorri ogni forma all'interno della prima slide.
- Verifica se la forma è di tipo SmartArt e effettua il cast della forma selezionata a SmartArt se lo è.
- Aggiungi un nuovo Node alla NodeCollection della forma SmartArt e imposta il testo nel TextFrame.
- Ora, aggiungi un Node figlio al Node SmartArt appena aggiunto e imposta il testo nel TextFrame.
- Salva la presentazione.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Carica la presentazione desiderata
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # Scorri ogni forma all'interno della prima slide
    for shape in pres.slides[0].shapes:

        # Verifica se la forma è di tipo SmartArt
        if type(shape) is art.SmartArt:
            # Aggiunta di un nuovo nodo SmartArt
            node1 = shape.all_nodes.add_node()
            # Aggiunge testo
            node1.text_frame.text = "Test"

            # Aggiunta di un nuovo nodo figlio nel nodo genitore. Verrà aggiunto alla fine della collezione
            new_node = node1.child_nodes.add_node()

            # Aggiunge testo
            new_node.text_frame.text = "New Node Added"

    # Salvataggio della presentazione
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Aggiungi nodo SmartArt in posizione specifica**
Nel codice di esempio seguente abbiamo spiegato come aggiungere i nodi figlio appartenenti ai rispettivi nodi della forma SmartArt in una posizione particolare.

- Crea un'istanza della classe `Presentation`.
- Ottieni il riferimento della prima slide utilizzando il suo indice.
- Aggiungi una forma SmartArt di tipo StackedList nella slide selezionata.
- Accedi al primo nodo nella forma SmartArt aggiunta.
- Ora, aggiungi il Node figlio per il nodo selezionato alla posizione 2 e imposta il suo testo.
- Salva la presentazione.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Creazione di un'istanza della presentazione
with slides.Presentation() as pres:
    # Accesso alla slide della presentazione
    slide = pres.slides[0]

    # Aggiungi Smart Art IShape
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # Accesso al nodo SmartArt all'indice 0
    node = smart.all_nodes[0]

    # Aggiunta di un nuovo nodo figlio alla posizione 2 nel nodo genitore
    chNode = node.child_nodes.add_node_by_position(2)

    # Aggiungi testo
    chNode.text_frame.text = "Sample text Added"

    # Salva presentazione
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Accedi al nodo SmartArt**
Il codice di esempio seguente aiuterà ad accedere ai nodi all'interno della forma SmartArt. Nota che non è possibile modificare il LayoutType di SmartArt poiché è di sola lettura e viene impostato solo quando la forma SmartArt viene aggiunta.

- Crea un'istanza della classe `Presentation` e carica la presentazione con la forma SmartArt.
- Ottieni il riferimento della prima slide utilizzando il suo indice.
- Scorri ogni forma all'interno della prima slide.
- Verifica se la forma è di tipo SmartArt e effettua il cast della forma selezionata a SmartArt se lo è.
- Scorri tutti i Node all'interno della forma SmartArt.
- Accedi e visualizza informazioni come la posizione, il livello e il testo del nodo SmartArt.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Carica la presentazione desiderata
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # Scorri ogni forma all'interno della prima slide
    for shape in pres.slides[0].shapes:
        # Verifica se la forma è di tipo SmartArt
        if type(shape) is art.SmartArt:
            # Scorri tutti i nodi all'interno di SmartArt
            for i in range(len(shape.all_nodes)):
                # Accesso al nodo SmartArt all'indice i
                node = shape.all_nodes[i]

                # Stampa i parametri del nodo SmartArt
                print("i = {0}, text = {1},  level = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
```

## **Accedi al nodo figlio SmartArt**
Il codice di esempio seguente aiuterà ad accedere ai nodi figlio appartenenti ai rispettivi nodi della forma SmartArt.

- Crea un'istanza della classe PresentationEx e carica la presentazione con la forma SmartArt.
- Ottieni il riferimento della prima slide utilizzando il suo indice.
- Scorri ogni forma all'interno della prima slide.
- Verifica se la forma è di tipo SmartArt e effettua il cast della forma selezionata a SmartArtEx se lo è.
- Scorri tutti i Node all'interno della forma SmartArt.
- Per ogni Node della forma SmartArt selezionato, scorri tutti i Node figlio all'interno del nodo specifico.
- Accedi e visualizza informazioni come la posizione, il livello e il testo del nodo figlio.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Carica la presentazione desiderata
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # Scorri ogni forma all'interno della prima slide
    for shape in pres.slides[0].shapes:
        # Verifica se la forma è di tipo SmartArt
        if type(shape) is art.SmartArt:
            # Scorri tutti i nodi all'interno di SmartArt
            for node0 in shape.all_nodes:
                # Scorrendo i nodi figli
                for j in range(len(node0.child_nodes)):
                    # Accesso al nodo figlio nel nodo SmartArt
                    node = node0.child_nodes[j]

                    # Stampa i parametri del nodo figlio SmartArt
                    print("j = {0}, text = {1},  level = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))

```

## **Accedi al nodo figlio SmartArt in posizione specifica**
In questo esempio, impareremo ad accedere ai nodi figlio in una posizione particolare appartenenti ai rispettivi nodi della forma SmartArt.

- Crea un'istanza della classe `Presentation`.
- Ottieni il riferimento della prima slide utilizzando il suo indice.
- Aggiungi una forma SmartArt di tipo StackedList.
- Accedi alla forma SmartArt aggiunta.
- Accedi al nodo all'indice 0 per la forma SmartArt selezionata.
- Ora, accedi al nodo figlio alla posizione 1 per il nodo SmartArt selezionato usando il metodo GetNodeByPosition().
- Accedi e visualizza informazioni come la posizione, il livello e il testo del nodo figlio.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Istanzia la presentazione
with slides.Presentation() as pres:
    # Accesso alla prima slide
    slide = pres.slides[0]
    # Aggiunta della forma SmartArt nella prima slide
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)
    # Accesso al nodo SmartArt all'indice 0
    node = smart.all_nodes[0]
    # Accesso al nodo figlio alla posizione 1 nel nodo genitore
    position = 1
    chNode = node.child_nodes[position] 
    # Stampa dei parametri del nodo figlio SmartArt
    print("j = {0}, text = {1},  level = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))

```

## **Rimuovi nodo SmartArt**
In questo esempio, impareremo a rimuovere i nodi all'interno della forma SmartArt.

- Crea un'istanza della classe `Presentation` e carica la presentazione con la forma SmartArt.
- Ottieni il riferimento della prima slide utilizzando il suo indice.
- Scorri ogni forma all'interno della prima slide.
- Verifica se la forma è di tipo SmartArt e effettua il cast della forma selezionata a SmartArt se lo è.
- Verifica se lo SmartArt ha più di 0 nodi.
- Seleziona il nodo SmartArt da eliminare.
- Ora, rimuovi il nodo selezionato usando il metodo RemoveNode() * Salva la presentazione.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Carica la presentazione desiderata
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # Scorri ogni forma all'interno della prima slide
    for shape in pres.slides[0].shapes:
        # Verifica se la forma è di tipo SmartArt
        if type(shape) is art.SmartArt:
            # Esegui il cast della forma a SmartArtEx
            if len(shape.all_nodes) > 0:
                # Accesso al nodo SmartArt all'indice 0
                node = shape.all_nodes[0]

                # Rimozione del nodo selezionato
                shape.all_nodes.remove_node(node)

    # Salva la presentazione
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Rimuovi nodo SmartArt in posizione specifica**
In questo esempio, impareremo a rimuovere i nodi all'interno della forma SmartArt in una posizione particolare.

- Crea un'istanza della classe `Presentation` e carica la presentazione con la forma SmartArt.
- Ottieni il riferimento della prima slide utilizzando il suo indice.
- Scorri ogni forma all'interno della prima slide.
- Verifica se la forma è di tipo SmartArt e effettua il cast della forma selezionata a SmartArt se lo è.
- Seleziona il nodo della forma SmartArt all'indice 0.
- Ora, verifica se il nodo SmartArt selezionato ha più di 2 nodi figlio.
- Ora, rimuovi il nodo alla Posizione 1 usando il metodo RemoveNodeByPosition().
- Salva la presentazione.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Carica la presentazione desiderata
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # Scorri ogni forma all'interno della prima slide
    for shape in pres.slides[0].shapes:
        # Verifica se la forma è di tipo SmartArt
        if type(shape) is art.SmartArt:
            # Esegui il cast della forma a SmartArt
            if len(shape.all_nodes) > 0:
                # Accesso al nodo SmartArt all'indice 0
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # Rimozione del nodo figlio alla posizione 1
                    node.child_nodes.remove_node(1)

    # Salva la presentazione
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta posizione personalizzata per il nodo figlio in SmartArt**
Ora Aspose.Slides per Python via .NET supporta l'impostazione delle proprietà X e Y di SmartArtShape. Lo snippet di codice seguente mostra come impostare posizione, dimensione e rotazione personalizzate di SmartArtShape; nota inoltre che l'aggiunta di nuovi nodi provoca un ricalcolo delle posizioni e delle dimensioni di tutti i nodi.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Carica la presentazione desiderata
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
	smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

	# Sposta la forma SmartArt in una nuova posizione
	node = smart.all_nodes[1]
	shape = node.shapes[1]
	shape.x += (shape.width * 2)
	shape.y -= (shape.height / 2)

	# Modifica la larghezza della forma SmartArt
	node = smart.all_nodes[2]
	shape = node.shapes[1]
	shape.width += (shape.width / 2)

	# Modifica l'altezza della forma SmartArt
	node = smart.all_nodes[3]
	shape = node.shapes[1]
	shape.height += (shape.height / 2)

	# Modifica la rotazione della forma SmartArt
	node = smart.all_nodes[4]
	shape = node.shapes[1]
	shape.rotation = 90

	pres.save("SmartArt.pptx", slides.export.SaveFormat.PPTX)
```

## **Verifica nodo assistente**
Nel codice di esempio seguente indagheremo come identificare i nodi Assistente nella collezione di nodi SmartArt e modificarli.

- Crea un'istanza della classe PresentationEx e carica la presentazione con la forma SmartArt.
- Ottieni il riferimento della seconda slide utilizzando il suo indice.
- Scorri ogni forma all'interno della prima slide.
- Verifica se la forma è di tipo SmartArt e effettua il cast della forma selezionata a SmartArtEx se lo è.
- Scorri tutti i nodi all'interno della forma SmartArt e verifica se sono nodi Assistente.
- Cambia lo stato del nodo Assistente in nodo normale.
- Salva la presentazione.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Creazione di un'istanza della presentazione
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # Scorri ogni forma all'interno della prima slide
    for shape in pres.slides[0].shapes:
        # Verifica se la forma è di tipo SmartArt
        if type(shape) is art.SmartArt:
            # Scorrendo tutti i nodi della forma SmartArt
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # Verifica se il nodo è un nodo Assistente
                if node.is_assistant:
                    # Impostando il nodo Assistente a false e rendendolo un nodo normale
                    node.is_assistant = False
    # Salva la presentazione
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta formato di riempimento del nodo**
Aspose.Slides per Python via .NET consente di aggiungere forme SmartArt personalizzate e impostare i loro formati di riempimento. Questo articolo spiega come creare e accedere a forme SmartArt e impostare il loro formato di riempimento usando Aspose.Slides per Python via .NET.

Segui i passaggi seguenti:

- Crea un'istanza della classe `Presentation`.
- Ottieni il riferimento di una slide usando il suo indice.
- Aggiungi una forma SmartArt impostando il suo LayoutType.
- Imposta il FillFormat per i nodi della forma SmartArt.
- Scrivi la presentazione modificata come file PPTX.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation: 
    # Accesso alla slide
    slide = presentation.slides[0]

    # Aggiunta della forma SmartArt e dei nodi
    chevron = slide.shapes.add_smart_art(10, 10, 800, 60, art.SmartArtLayoutType.CLOSED_CHEVRON_PROCESS)
    node = chevron.all_nodes.add_node()
    node.text_frame.text = "Some text"

    # Impostazione del colore di riempimento del nodo
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # Salvataggio della presentazione
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Genera miniatura del nodo figlio SmartArt**
Gli sviluppatori possono generare una miniatura del nodo figlio di un SmartArt seguendo i passaggi seguenti:

1. Istanzia la classe `Presentation` che rappresenta il file PPTX.
2. Aggiungi SmartArt.
3. Ottieni il riferimento di un nodo usando il suo indice
4. Ottieni l'immagine miniatura.
5. Salva l'immagine miniatura in qualsiasi formato immagine desiderato.

L'esempio seguente genera una miniatura del nodo figlio SmartArt

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# Istanzia la classe Presentation che rappresenta il file PPTX
with slides.Presentation() as presentation: 
    # Aggiungi SmartArt
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # Ottieni il riferimento di un nodo usando il suo indice
    node = smart.nodes[1]

    # Ottieni la miniatura
    with node.shapes[0].get_image() as bmp:
        # salva la miniatura
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```

## **FAQ**

**L'animazione SmartArt è supportata?**

Sì. SmartArt è trattata come una forma normale, quindi puoi [applica animazioni standard](/slides/it/python-net/shape-animation/) (entrata, uscita, enfasi, percorsi di movimento) e regolare il timing. Puoi anche animare le forme all'interno dei nodi SmartArt quando necessario.

**Come posso individuare in modo affidabile uno SmartArt specifico su una slide se il suo ID interno è sconosciuto?**

Assegna e cerca tramite [testo alternativo](https://reference.aspose.com/slides/it/python-net/aspose.slides.smartart/smartart/alternative_text/). Impostare un AltText distintivo sullo SmartArt ti permette di trovarlo programmaticamente senza fare affidamento sugli identificatori interni.

**L'aspetto dello SmartArt verrà preservato durante la conversione della presentazione in PDF?**

Sì. Aspose.Slides renderizza SmartArt con alta fedeltà visiva durante [l'esportazione PDF](/slides/it/python-net/convert-powerpoint-to-pdf/), preservando layout, colori ed effetti.

**Posso estrarre un'immagine dell'intero SmartArt (per anteprime o report)?**

Sì. Puoi renderizzare una forma SmartArt in [formati raster](https://reference.aspose.com/slides/it/python-net/aspose.slides.smartart/smartart/get_image/) o in [SVG](https://reference.aspose.com/slides/it/python-net/aspose.slides.smartart/smartart/write_as_svg/) per output vettoriale scalabile, rendendola adatta a miniature, report o uso web.