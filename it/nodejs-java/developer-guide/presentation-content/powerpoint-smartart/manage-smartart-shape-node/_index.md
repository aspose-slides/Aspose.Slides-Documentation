---
title: Gestire i nodi delle forme SmartArt nelle presentazioni usando JavaScript
linktitle: Nodo forma SmartArt
type: docs
weight: 30
url: /it/nodejs-java/manage-smartart-shape-node/
keywords:
- nodo SmartArt
- nodo figlio
- aggiungere nodo
- posizione nodo
- accedere nodo
- rimuovere nodo
- posizione personalizzata
- nodo assistente
- formato riempimento
- renderizzare nodo
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestisci i nodi delle forme SmartArt in PPT e PPTX con Aspose.Slides per Node.js. Ottieni esempi di codice JavaScript chiari e consigli per ottimizzare le tue presentazioni."
---
## **Panoramica**

Le grafiche SmartArt nelle presentazioni PowerPoint sono organizzate tramite nodi che contengono testo e definiscono la struttura del diagramma. Aspose.Slides consente di lavorare con questi nodi SmartArt in modo programmatico: aggiungere nuovi nodi e nodi figlio, inserire nodi figlio in una posizione specifica, accedere ai nodi esistenti e leggere il loro testo, livello e posizione.

Questo articolo spiega come gestire i nodi delle forme SmartArt. Mostra come rimuovere i nodi, lavorare con i nodi figlio per indice o posizione, trasformare un nodo assistente in un nodo normale, regolare la posizione, la dimensione e la rotazione delle forme dei nodi SmartArt, impostare i formati di riempimento dei nodi e generare un'immagine miniatura per un nodo figlio SmartArt.

## **Aggiungere un nodo SmartArt in una presentazione PowerPoint usando JavaScript**
Aspose.Slides per Node.js via Java ha fornito l'API più semplice per gestire le forme SmartArt nel modo più facile. Il codice di esempio seguente aiuterà ad aggiungere un nodo e un nodo figlio all'interno di una forma SmartArt.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) e caricare la presentazione con una forma SmartArt.
1. Ottenere il riferimento della prima diapositiva utilizzando il suo indice.
1. Scorrere tutte le forme all'interno della prima diapositiva.
1. Verificare se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArt) e effettuare il cast al tipo [SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArt) se è una SmartArt.
1. [Aggiungere un nuovo nodo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) nella forma SmartArt [**NodeCollection**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArt#getAllNodes--) e impostare il testo nel TextFrame.
1. Ora, [Aggiungere](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) un [**Nodo figlio**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) nel nodo [SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArt) appena aggiunto e impostare il testo nel TextFrame
1. Salvare la presentazione.

```javascript
// Carica la presentazione desiderata
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Scorri tutte le forme nella prima diapositiva
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Verifica se la forma è di tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Esegui il cast della forma a SmartArt
            var smart = shape;
            // Aggiunta di un nuovo nodo SmartArt
            var TemNode = smart.getAllNodes().addNode();
            // Aggiunta di testo
            TemNode.getTextFrame().setText("Test");
            // Aggiunta di un nuovo nodo figlio nel nodo padre. Verrà aggiunto alla fine della collezione
            var newNode = TemNode.getChildNodes().addNode();
            // Aggiunta di testo
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    // Salvataggio della presentazione
    pres.save("AddSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Aggiungere un nodo SmartArt in una posizione specifica**
Nel codice di esempio seguente abbiamo spiegato come aggiungere i nodi figlio appartenenti ai rispettivi nodi della forma SmartArt in una posizione particolare.

1. Creare un'istanza della classe Presentation.
1. Ottenere il riferimento della prima diapositiva utilizzando il suo indice.
1. Aggiungere una forma [SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArt) di tipo [**StackedList**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList) nella diapositiva acceduta.
1. Accedere al primo nodo nella forma SmartArt aggiunta.
1. Ora, aggiungere il [**Nodo figlio**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) per il [**Nodo**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArtNode) selezionato alla posizione 2 e impostare il suo testo.
1. Salvare la presentazione.

```javascript
// Creazione di un'istanza della presentazione
var pres = new aspose.slides.Presentation();
try {
    // Accedi alla diapositiva della presentazione
    var slide = pres.getSlides().get_Item(0);
    // Aggiungi Smart Art IShape
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // Accesso al nodo SmartArt all'indice 0
    var node = smart.getAllNodes().get_Item(0);
    // Aggiunta di un nuovo nodo figlio alla posizione 2 nel nodo padre
    var chNode = node.getChildNodes().addNodeByPosition(2);
    // Aggiungi testo
    chNode.getTextFrame().setText("Sample Text Added");
    // Salva la presentazione
    pres.save("AddSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Accedere al nodo SmartArt in una presentazione PowerPoint usando JavaScript**
Il codice di esempio seguente aiuterà ad accedere ai nodi all'interno di una forma SmartArt. Si noti che non è possibile modificare il LayoutType della SmartArt poiché è di sola lettura e viene impostato solo quando la forma SmartArt viene aggiunta.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation) e caricare la presentazione con una forma SmartArt.
1. Ottenere il riferimento della prima diapositiva utilizzando il suo indice.
1. Scorrere tutte le forme all'interno della prima diapositiva.
1. Verificare se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArt) e effettuare il cast al tipo [SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArt) se è una SmartArt.
1. Scorrere tutti i [**Nodi**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArt#getAllNodes--) all'interno della forma SmartArt.
1. Accedere e visualizzare informazioni come la posizione, il livello e il testo del nodo SmartArt.

```javascript
// Istanziare la classe Presentation
var pres = new aspose.slides.Presentation("SmartArtShape.pptx");
try {
    // Recupera la prima diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Scorri tutte le forme nella prima diapositiva
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Verifica se la forma è di tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Esegui il cast della forma a SmartArt
            var smart = shape;
            // Scorri tutti i nodi all'interno di SmartArt
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                // Accesso al nodo SmartArt all'indice i
                var node = smart.getAllNodes().get_Item(j);
                // Stampa i parametri del nodo SmartArt
                console.log(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Accedere al nodo figlio SmartArt**
Il codice di esempio seguente aiuterà ad accedere ai nodi figlio appartenenti ai rispettivi nodi della forma SmartArt.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation) e caricare la presentazione con una forma SmartArt.
1. Ottenere il riferimento della prima diapositiva utilizzando il suo indice.
1. Scorrere tutte le forme all'interno della prima diapositiva.
1. Verificare se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArt) e effettuare il cast al tipo [SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArt) se è una SmartArt.
1. Scorrere tutti i [**Nodi**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArt#getAllNodes--) all'interno della forma SmartArt.
1. Per ogni [**Nodo**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArtNode) selezionato, scorrere tutti i [**Nodi figlio**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) all'interno del nodo specifico.
1. Accedere e visualizzare informazioni come la posizione, il livello e il testo del [**Nodo figlio**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--).

```javascript
// Istanziare la classe Presentation
var pres = new aspose.slides.Presentation("AccessChildNodes.pptx");
try {
    // Ottieni la prima diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Scorri tutte le forme nella prima diapositiva
    for (let s = 0; s < slide.getShapes().size(); s++) {
        let shape = slide.getShapes().get_Item(s);
        // Verifica se la forma è di tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Esegui il cast della forma a SmartArt
            var smart = shape;
            // Scorri tutti i nodi all'interno di SmartArt
            for (var i = 0; i < smart.getAllNodes().size(); i++) {
                // Accesso al nodo SmartArt all'indice i
                var node0 = smart.getAllNodes().get_Item(i);
                // Scorrendo i nodi figlio nel nodo SmartArt all'indice i
                for (var j = 0; j < node0.getChildNodes().size(); j++) {
                    // Accesso al nodo figlio nel nodo SmartArt
                    var node = node0.getChildNodes().get_Item(j);
                    // Stampa i parametri del nodo figlio SmartArt
                    console.log("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Accedere al nodo figlio SmartArt in una posizione specifica**
In questo esempio impareremo ad accedere ai nodi figlio in una posizione particolare appartenenti ai rispettivi nodi della forma SmartArt.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).
1. Ottenere il riferimento della prima diapositiva utilizzando il suo indice.
1. Aggiungere una forma SmartArt di tipo [**StackedList**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList).
1. Accedere alla forma SmartArt aggiunta.
1. Accedere al nodo all'indice 0 per la forma SmartArt selezionata.
1. Ora, accedere al [**Nodo figlio**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) alla posizione 1 per il nodo SmartArt selezionato usando il metodo **get_Item()**.
1. Accedere e visualizzare informazioni come la posizione, il livello e il testo del [**Nodo figlio**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--).

```javascript
// Istanziare la presentazione
var pres = new aspose.slides.Presentation();
try {
    // Accesso alla prima diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Aggiunta della forma SmartArt nella prima diapositiva
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // Accesso al nodo SmartArt all'indice 0
    var node = smart.getAllNodes().get_Item(0);
    // Accesso al nodo figlio alla posizione 1 nel nodo padre
    var position = 1;
    var chNode = node.getChildNodes().get_Item(position);
    // Stampa dei parametri del nodo figlio SmartArt
    console.log("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Rimuovere il nodo SmartArt in una presentazione PowerPoint usando JavaScript**
In questo esempio impareremo a rimuovere i nodi all'interno della forma SmartArt.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation) e caricare la presentazione con una forma SmartArt.
1. Ottenere il riferimento della prima diapositiva utilizzando il suo indice.
1. Scorrere tutte le forme all'interno della prima diapositiva.
1. Verificare se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArt) e effettuare il cast al tipo [SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArt) se è una SmartArt.
1. Verificare se la [SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArt) ha più di 0 nodi.
1. Selezionare il nodo SmartArt da eliminare.
1. Ora, rimuovere il nodo selezionato usando il metodo [**RemoveNode**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-aspose.slides.ISmartArtNode-).
1. Salvare la presentazione.

```javascript
// Carica la presentazione desiderata
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Scorri tutte le forme nella prima diapositiva
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Verifica se la forma è di tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Esegui il cast della forma a SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // Accesso al nodo SmartArt all'indice 0
                var node = smart.getAllNodes().get_Item(0);
                // Rimozione del nodo selezionato
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    // Salva la presentazione
    pres.save("RemoveSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Rimuovere il nodo SmartArt in una posizione specifica**
In questo esempio impareremo a rimuovere i nodi all'interno della forma SmartArt in una posizione particolare.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation) e caricare la presentazione con una forma SmartArt.
1. Ottenere il riferimento della prima diapositiva utilizzando il suo indice.
1. Scorrere tutte le forme all'interno della prima diapositiva.
1. Verificare se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArt) e effettuare il cast al tipo [SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArt) se è una SmartArt.
1. Selezionare il nodo della forma SmartArt all'indice 0.
1. Verificare se il nodo SmartArt selezionato ha più di 2 nodi figlio.
1. Rimuovere il nodo alla **Posizione 1** usando il metodo [**RemoveNode**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-int-).
1. Salvare la presentazione.

```javascript
// Carica la presentazione desiderata
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Scorri tutte le forme nella prima diapositiva
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Verifica se la forma è di tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Esegui il cast della forma a SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // Accesso al nodo SmartArt all'indice 0
                var node = smart.getAllNodes().get_Item(0);
                if (node.getChildNodes().size() >= 2) {
                    // Rimozione del nodo figlio alla posizione 1
                    node.getChildNodes().removeNode(1);
                }
            }
        }
    }
    // Salva la presentazione
    pres.save("RemoveSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Impostare una posizione personalizzata per il nodo figlio in SmartArt**
Ora Aspose.Slides per Node.js via Java supporta l'impostazione delle proprietà [SmartArtShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Shape#setX-float-) e [Y](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Shape#setY-float-). Il frammento di codice seguente mostra come impostare posizione, dimensione e rotazione personalizzate della SmartArtShape; notare inoltre che l'aggiunta di nuovi nodi provoca un ricalcolo delle posizioni e delle dimensioni di tutti i nodi. Inoltre, con le impostazioni di posizione personalizzate, l'utente può impostare i nodi secondo le esigenze.

```javascript
// Istanziare la classe Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // Sposta la forma SmartArt in una nuova posizione
    var node = smart.getAllNodes().get_Item(1);
    var shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + (shape.getWidth() * 2));
    shape.setY(shape.getY() - (shape.getHeight() * 2));
    // Modifica le larghezze della forma SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + (shape.getWidth() * 2));
    // Modifica l'altezza della forma SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + (shape.getHeight() * 2));
    // Modifica la rotazione della forma SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);
    pres.save("SmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Verificare il nodo assistente**
{{% alert color="primary" %}} 

In questo articolo approfondiremo le funzionalità delle forme SmartArt aggiunte alle diapositive della presentazione in modo programmatico usando Aspose.Slides per Node.js via Java.

{{% /alert %}} 

Utilizzeremo la seguente forma SmartArt di origine per la nostra indagine nelle diverse sezioni di questo articolo.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figura: Forma SmartArt di origine nella diapositiva**|

Nel codice di esempio seguente indagheremo su come identificare i **Nodi assistenti** nella raccolta dei nodi SmartArt e modificarli.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation) e caricare la presentazione con una forma SmartArt.
1. Ottenere il riferimento della seconda diapositiva utilizzando il suo indice.
1. Scorrere tutte le forme all'interno della prima diapositiva.
1. Verificare se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArt) e effettuare il cast al tipo [SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArt) se è una SmartArt.
1. Scorrere tutti i nodi all'interno della forma SmartArt e verificare se sono [**Nodi assistenti**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArtNode#isAssistant--).
1. Cambiare lo stato del nodo assistente in nodo normale.
1. Salvare la presentazione.

```javascript
// Creazione di un'istanza della presentazione
var pres = new aspose.slides.Presentation("AddNodes.pptx");
try {
    // Scorri tutte le forme nella prima diapositiva
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Verifica se la forma è di tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Esegui il cast della forma a SmartArt
            var smart = shape;
            // Scorrendo tutti i nodi della forma SmartArt
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                var node = smart.getAllNodes().get_Item(j);
                // Verifica se il nodo è un nodo Assistente
                if (node.isAssistant()) {
                    // Impostazione del nodo Assistente a false e conversione in nodo normale
                    node.isAssistant();
                }
            }
        }
    }
    // Salva la presentazione
    pres.save("ChangeAssitantNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figura: Nodi assistenti modificati nella forma SmartArt all'interno della diapositiva**|

## **Impostare il formato di riempimento del nodo**
Aspose.Slides per Node.js via Java consente di aggiungere forme SmartArt personalizzate e impostare il loro formato di riempimento. Questo articolo spiega come creare e accedere alle forme SmartArt e impostare il loro formato di riempimento usando Aspose.Slides per Node.js via Java.

Si prega di seguire i passaggi seguenti:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).
1. Ottenere il riferimento di una diapositiva usando il suo indice.
1. Aggiungere una forma [SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArt) impostando il suo [**LayoutType**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
1. Impostare il [**FillFormat**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Shape#getFillFormat--) per i nodi della forma SmartArt.
1. Scrivere la presentazione modificata come file PPTX.

```javascript
// Istanziare la presentazione
var pres = new aspose.slides.Presentation();
try {
    // Accesso alla diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Aggiunta della forma SmartArt e dei nodi
    var chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, aspose.slides.SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    // Impostazione del colore di riempimento del nodo
    for (let i = 0; i < node.getShapes().size(); i++) {
        let item = node.getShapes().get_Item(i);
        item.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        item.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    // Salva la presentazione
    pres.save("TestSmart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Generare una miniatura del nodo figlio SmartArt**
Gli sviluppatori possono generare una miniatura del nodo figlio di una SmartArt seguendo i passaggi seguenti:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).
1. [Aggiungere SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--).
1. Ottenere il riferimento di un nodo usando il suo indice
1. Ottenere l'immagine miniatura.
1. Salvare l'immagine miniatura in qualsiasi formato immagine desiderato.

```javascript
// Istanziare la classe Presentation che rappresenta il file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Aggiungi SmartArt
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicCycle);
    // Ottieni il riferimento di un nodo usando il suo indice
    var node = smart.getNodes().get_Item(1);
    // Ottieni la miniatura
    var slideImage = node.getShapes().get_Item(0).getImage();
    // Salva la miniatura
    try {
        slideImage.save("SmartArt_ChildNote_Thumbnail.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**L'animazione SmartArt è supportata?**

Sì. SmartArt è trattata come una forma normale, quindi è possibile [applicare animazioni standard](/slides/it/nodejs-java/shape-animation/) (entrata, uscita, enfasi, percorsi di movimento) e regolare i tempi. È inoltre possibile animare le forme all'interno dei nodi SmartArt quando necessario.

**Come posso individuare in modo affidabile uno SmartArt specifico su una diapositiva se il suo ID interno è sconosciuto?**

Assegnare e cercare tramite [testo alternativo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/getalternativetext/). Impostare un AltText distintivo sullo SmartArt consente di trovarlo senza fare affidamento sugli identificatori interni.

**L'aspetto dello SmartArt verrà preservato durante la conversione della presentazione in PDF?**

Sì. Aspose.Slides rende lo SmartArt con alta fedeltà visiva durante l'[esportazione in PDF](/slides/it/nodejs-java/convert-powerpoint-to-pdf/), preservando layout, colori ed effetti.

**Posso estrarre un'immagine dell'intero SmartArt (per anteprime o report)?**

Sì. È possibile renderizzare una forma SmartArt in [formati raster](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#getImage) o in [SVG](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/writeassvg/) per un output vettoriale scalabile, rendendola adatta a thumbnail, report o utilizzo web.