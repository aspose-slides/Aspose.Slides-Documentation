---
title: Gestire i nodi forma SmartArt nelle presentazioni su Android
linktitle: Nodo forma SmartArt
type: docs
weight: 30
url: /it/androidjava/manage-smartart-shape-node/
keywords:
- nodo SmartArt
- nodo figlio
- aggiungere nodo
- posizione nodo
- accedere al nodo
- rimuovere nodo
- posizione personalizzata
- nodo assistente
- formato riempimento
- renderizzare nodo
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Gestisci i nodi forma SmartArt in PPT e PPTX con Aspose.Slides per Android. Ottieni esempi di codice Java chiari e suggerimenti per ottimizzare le tue presentazioni."
---
## **Panoramica**

Le grafiche SmartArt nelle presentazioni PowerPoint sono organizzate tramite nodi che contengono testo e definiscono la struttura del diagramma. Aspose.Slides consente di lavorare con questi nodi SmartArt in modo programmatico: aggiungere nuovi nodi e nodi figlio, inserire nodi figlio in una posizione specifica, accedere ai nodi esistenti e leggere il loro testo, livello e posizione.

Questo articolo spiega come gestire i nodi delle forme SmartArt. Mostra come rimuovere i nodi, lavorare con i nodi figlio per indice o posizione, trasformare un nodo assistente in un nodo normale, regolare posizione, dimensione e rotazione delle forme dei nodi SmartArt, impostare i formati di riempimento dei nodi e generare un’immagine miniatura per un nodo figlio SmartArt.

## **Aggiungere un nodo SmartArt**
Aspose.Slides for Android via Java ha fornito l’API più semplice per gestire le forme SmartArt nel modo più facile. Il seguente esempio di codice aiuta ad aggiungere un nodo e un nodo figlio all’interno della forma SmartArt.

1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) e caricare la presentazione con la forma SmartArt.  
1. Ottenere il riferimento della prima diapositiva utilizzando il suo indice.  
1. Scorrere tutte le forme all’interno della prima diapositiva.  
1. Verificare se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt) e castare la forma selezionata a [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt) se è SmartArt.  
1. [Add a new Node](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) nella [**NodeCollection**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) della forma SmartArt e impostare il testo nel TextFrame.  
1. Ora, [Add](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) un [**Child Node**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) al nodo SmartArt appena aggiunto e impostare il testo nel TextFrame.  
1. Salvare la presentazione.

```java
// Carica la presentazione desiderata
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Scorri tutte le forme nella prima diapositiva
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Verifica se la forma è di tipo SmartArt
        if (shape instanceof SmartArt) 
        {
            // Esegui il cast della forma a SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // Aggiungi un nuovo nodo SmartArt
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Aggiungi testo
            TemNode.getTextFrame().setText("Test");
    
            // Aggiungi un nuovo nodo figlio al nodo genitore. Verrà aggiunto alla fine della collezione
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // Aggiungi testo
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // Salva la presentazione
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aggiungere un nodo SmartArt in una posizione specifica**
Nel codice di esempio seguente è illustrato come aggiungere i nodi figlio appartenenti ai rispettivi nodi della forma SmartArt in una posizione particolare.

1. Creare un’istanza della classe Presentation.  
1. Ottenere il riferimento della prima diapositiva utilizzando il suo indice.  
1. Aggiungere una forma [**StackedList**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) di tipo [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArt) nella diapositiva di accesso.  
1. Accedere al primo nodo nella forma SmartArt aggiunta.  
1. Ora, aggiungere il [**Child Node**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) per il [**Node**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArtNode) selezionato alla posizione 2 e impostarne il testo.  
1. Salvare la presentazione.

```java
// Creazione di un'istanza di presentazione
Presentation pres = new Presentation();
try {
    // Accedi alla diapositiva della presentazione
    ISlide slide = pres.getSlides().get_Item(0);

    // Aggiungi Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Accesso al nodo SmartArt all'indice 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Aggiunta di un nuovo nodo figlio nella posizione 2 del nodo genitore
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Aggiungi testo
    chNode.getTextFrame().setText("Sample Text Added");

    // Salva la presentazione
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Accedere a un nodo SmartArt**
Il seguente esempio di codice aiuta ad accedere ai nodi all’interno della forma SmartArt. Si noti che non è possibile modificare il LayoutType di SmartArt poiché è di sola lettura e viene impostato solo quando la forma SmartArt viene aggiunta.

1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation) e caricare la presentazione con la forma SmartArt.  
1. Ottenere il riferimento della prima diapositiva utilizzando il suo indice.  
1. Scorrere tutte le forme all’interno della prima diapositiva.  
1. Verificare se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt) e castare la forma selezionata a [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt) se è SmartArt.  
1. Scorrere tutti i [**Nodes**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArt#getAllNodes--) all’interno della forma SmartArt.  
1. Accedere e visualizzare informazioni come posizione del nodo SmartArt, livello e testo.

```java
// Istanzia la classe Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Ottieni la prima diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Scorri tutte le forme nella prima diapositiva
    for (IShape shape : slide.getShapes()) 
    {
        // Verifica se la forma è di tipo SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Esegui il cast della forma a SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Scorri tutti i nodi all'interno di SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Accesso al nodo SmartArt all'indice i
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // Stampa i parametri del nodo SmartArt
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Accedere a un nodo figlio SmartArt**
Il seguente esempio di codice aiuta ad accedere ai nodi figlio appartenenti ai rispettivi nodi della forma SmartArt.

1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation) e caricare la presentazione con la forma SmartArt.  
1. Ottenere il riferimento della prima diapositiva utilizzando il suo indice.  
1. Scorrere tutte le forme all’interno della prima diapositiva.  
1. Verificare se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt) e castare la forma selezionata a [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt) se è SmartArt.  
1. Scorrere tutti i [**Nodes**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArt#getAllNodes--) all’interno della forma SmartArt.  
1. Per ogni [**Node**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArtNode) della forma SmartArt selezionata, scorrere tutti i [**Child Nodes**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) all’interno del nodo specifico.  
1. Accedere e visualizzare informazioni come posizione, livello e testo del [**Child Node**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
// Istanzia la classe Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Ottieni la prima diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Scorri tutte le forme nella prima diapositiva
    for (IShape shape : slide.getShapes()) 
    {
        // Verifica se la forma è di tipo SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Esegui il cast della forma a SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Scorri tutti i nodi all'interno di SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Accesso al nodo SmartArt all'indice i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Scorri i nodi figlio nel nodo SmartArt all'indice i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Accesso al nodo figlio nel nodo SmartArt
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // Stampa i parametri del nodo figlio SmartArt
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Accedere a un nodo figlio SmartArt in una posizione specifica**
In questo esempio impareremo ad accedere ai nodi figlio in una posizione particolare appartenenti ai rispettivi nodi della forma SmartArt.

1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).  
1. Ottenere il riferimento della prima diapositiva utilizzando il suo indice.  
1. Aggiungere una forma SmartArt di tipo [**StackedList**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList).  
1. Accedere alla forma SmartArt aggiunta.  
1. Accedere al nodo all’indice 0 per la forma SmartArt selezionata.  
1. Ora, accedere al [**Child Node**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) alla posizione 1 per il nodo SmartArt selezionato usando il metodo **get_Item()**.  
1. Accedere e visualizzare informazioni come posizione, livello e testo del [**Child Node**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
// Istanzia la presentazione
Presentation pres = new Presentation();
try {
    // Accesso alla prima diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Aggiunta della forma SmartArt nella prima diapositiva
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Accesso al nodo SmartArt all'indice 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Accesso al nodo figlio nella posizione 1 del nodo genitore
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // Stampa dei parametri del nodo figlio SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Rimuovere un nodo SmartArt**
In questo esempio impareremo a rimuovere i nodi all’interno della forma SmartArt.

1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation) e caricare la presentazione con la forma SmartArt.  
1. Ottenere il riferimento della prima diapositiva utilizzando il suo indice.  
1. Scorrere tutte le forme all’interno della prima diapositiva.  
1. Verificare se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt) e castare la forma selezionata a [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt) se è SmartArt.  
1. Verificare se lo [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt) contiene più di 0 nodi.  
1. Selezionare il nodo SmartArt da eliminare.  
1. Ora, rimuovere il nodo selezionato usando il metodo [**RemoveNode**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).  
1. Salvare la presentazione.

```java
// Carica la presentazione desiderata
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Scorri tutte le forme nella prima diapositiva
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Verifica se la forma è di tipo SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Esegui il cast della forma a SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Accesso al nodo SmartArt all'indice 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // Rimuovere il nodo selezionato
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // Salva la presentazione
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Rimuovere un nodo SmartArt da una posizione specifica**
In questo esempio impareremo a rimuovere i nodi all’interno della forma SmartArt in una posizione particolare.

1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation) e caricare la presentazione con la forma SmartArt.  
1. Ottenere il riferimento della prima diapositiva utilizzando il suo indice.  
1. Scorrere tutte le forme all’interno della prima diapositiva.  
1. Verificare se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt) e castare la forma selezionata a [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt) se è SmartArt.  
1. Selezionare il nodo della forma SmartArt all’indice 0.  
1. Verificare se il nodo SmartArt selezionato ha più di 2 nodi figlio.  
1. Rimuovere il nodo alla **Posizione 1** usando il metodo [**RemoveNode**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-).  
1. Salvare la presentazione.

```java
// Carica la presentazione desiderata
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Scorri tutte le forme nella prima diapositiva
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Verifica se la forma è di tipo SmartArt
        if (shape instanceof SmartArt) 
        {
            // Esegui il cast della forma a SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Accesso al nodo SmartArt all'indice 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // Rimuovi il nodo figlio nella posizione 1
                    (node.getChildNodes()).removeNode(1);
                }
            }
        }
    }
    
    // Salva la presentazione
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Impostare una posizione personalizzata per un nodo figlio in un oggetto SmartArt**
Ora Aspose.Slides for Android via Java supporta l’impostazione delle proprietà [X](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShape#setX-float-) e [Y](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShape#setY-float-) di [SmartArtShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArtShape). Lo snippet di codice qui sotto mostra come impostare posizione, dimensione e rotazione personalizzate per SmartArtShape; si noti inoltre che l’aggiunta di nuovi nodi provoca un ricalcolo di posizioni e dimensioni di tutti i nodi. Con le impostazioni di posizione personalizzata, l’utente può configurare i nodi secondo le proprie esigenze.

```java
// Instanzia la classe Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // Sposta la forma SmartArt in una nuova posizione
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Modifica le larghezze della forma SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // Modifica l'altezza della forma SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // Modifica la rotazione della forma SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **Controllare un nodo assistente**
{{% alert color="primary" %}} 

In questo articolo approfondiremo le funzionalità delle forme SmartArt aggiunte alle diapositive della presentazione in modo programmatico utilizzando Aspose.Slides for Android via Java.

{{% /alert %}} 

Utilizzeremo la seguente forma SmartArt di origine per le indagini nelle diverse sezioni di questo articolo.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figura: Forma SmartArt di origine nella diapositiva**|

Nel codice di esempio seguente esamineremo come identificare i **Assistant Nodes** nella collezione di nodi SmartArt e modificarli.

1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation) e caricare la presentazione con la forma SmartArt.  
1. Ottenere il riferimento della seconda diapositiva utilizzando il suo indice.  
1. Scorrere tutte le forme all’interno della prima diapositiva.  
1. Verificare se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt) e castare la forma selezionata a [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt) se è SmartArt.  
1. Scorrere tutti i nodi all’interno della forma SmartArt e verificare se sono [**Assistant Nodes**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArtNode#isAssistant--).  
1. Cambiare lo stato del nodo assistente in nodo normale.  
1. Salvare la presentazione.

```java
// Creazione di un'istanza di presentazione
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Scorri tutte le forme nella prima diapositiva
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Verifica se la forma è di tipo SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Esegui il cast della forma a SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Scorri tutti i nodi della forma SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Verifica se il nodo è un nodo assistente
                if (node.isAssistant()) 
                {
                    // Imposta il nodo assistente a false e trasformalo in nodo normale
                    node.isAssistant();
                }
            }
        }
    }
    
    // Salva la presentazione
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figura: Nodi assistenti modificati nella forma SmartArt nella diapositiva**|

## **Impostare il formato di riempimento di un nodo**
Aspose.Slides for Android via Java consente di aggiungere forme SmartArt personalizzate e impostare il loro formato di riempimento. Questo articolo spiega come creare e accedere a forme SmartArt e impostare il loro formato di riempimento usando Aspose.Slides for Android via Java.

Segui i passaggi seguenti:

1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).  
1. Ottenere il riferimento di una diapositiva usando il suo indice.  
1. Aggiungere una forma [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt) impostando il suo [**LayoutType**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).  
1. Impostare il [**FillFormat**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShape#getFillFormat--) per i nodi della forma SmartArt.  
1. Scrivere la presentazione modificata come file PPTX.

```java
// Istanzia la presentazione
Presentation pres = new Presentation();
try {
    // Accesso alla diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Aggiunta della forma SmartArt e dei nodi
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // Impostazione del colore di riempimento del nodo
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // Salva la presentazione
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Generare una miniatura di un nodo figlio SmartArt**
Gli sviluppatori possono generare una miniatura del nodo figlio di uno SmartArt seguendo i passaggi seguenti:

1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).  
1. [Add SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).  
1. Ottenere il riferimento di un nodo usando il suo indice.  
1. Ottenere l’immagine miniatura.  
1. Salvare l’immagine miniatura in qualsiasi formato immagine desiderato.

```java
// Istanzia la classe Presentation che rappresenta il file PPTX
Presentation pres = new Presentation();
try {
    // Aggiungi SmartArt 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Ottieni il riferimento di un nodo utilizzando il suo indice
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // Ottieni la miniatura
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // Salva la miniatura
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**L’animazione SmartArt è supportata?**

Sì. SmartArt è trattato come una forma normale, quindi è possibile [applicare animazioni standard](/slides/it/androidjava/shape-animation/) (entrata, uscita, enfasi, percorsi di movimento) e regolare la temporizzazione. È anche possibile animare le forme all’interno dei nodi SmartArt quando necessario.

**Come posso individuare in modo affidabile uno SmartArt specifico in una diapositiva se il suo ID interno è sconosciuto?**

Assegnare e cercare tramite [testo alternativo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shape/#getAlternativeText--). Impostare un AltText distintivo sullo SmartArt consente di trovarlo programmaticamente senza fare affidamento su identificatori interni.

**L’aspetto di SmartArt verrà preservato durante la conversione della presentazione in PDF?**

Sì. Aspose.Slides rende SmartArt con alta fedeltà visiva durante l’[esportazione PDF](/slides/it/androidjava/convert-powerpoint-to-pdf/), preservando layout, colori ed effetti.

**Posso estrarre un’immagine dell’intero SmartArt (per anteprime o report)?**

Sì. È possibile rendere una forma SmartArt in [formati raster](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) o in [SVG](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) per un output vettoriale scalabile, adatto per miniature, report o utilizzo web.