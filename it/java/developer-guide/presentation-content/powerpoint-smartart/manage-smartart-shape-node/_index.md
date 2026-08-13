---
title: Gestire i nodi delle forme SmartArt nelle presentazioni con Java
linktitle: Nodo forma SmartArt
type: docs
weight: 30
url: /it/java/manage-smartart-shape-node/
keywords:
- nodo SmartArt
- nodo figlio
- aggiungi nodo
- posizione del nodo
- accedi al nodo
- rimuovi nodo
- posizione personalizzata
- nodo assistente
- formato di riempimento
- nodo di rendering
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Gestisci i nodi delle forme SmartArt in PPT e PPTX con Aspose.Slides per Java. Ottieni esempi di codice chiari e suggerimenti per ottimizzare le tue presentazioni."
---
## **Panoramica**

Le grafiche SmartArt nelle presentazioni PowerPoint sono organizzate tramite nodi che contengono testo e definiscono la struttura del diagramma. Aspose.Slides consente di lavorare con questi nodi SmartArt in modo programmatico: aggiungere nuovi nodi e nodi figlio, inserire nodi figlio in una posizione specifica, accedere ai nodi esistenti e leggere il loro testo, livello e posizione.

Questo articolo spiega come gestire i nodi delle forme SmartArt. Mostra come rimuovere i nodi, lavorare con i nodi figlio per indice o posizione, trasformare un nodo assistente in un nodo normale, regolare la posizione, le dimensioni e la rotazione delle forme dei nodi SmartArt, impostare i formati di riempimento dei nodi e generare un'immagine di anteprima per un nodo figlio SmartArt.

## **Aggiungere un nodo SmartArt**
Aspose.Slides for Java ha fornito l'API più semplice per gestire le forme SmartArt nel modo più facile. Il codice di esempio seguente aiuterà ad aggiungere un nodo e un nodo figlio all'interno di una forma SmartArt.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) e caricare la presentazione con la forma SmartArt.  
2. Ottenere il riferimento della prima diapositiva utilizzando il suo indice.  
3. Scorrere tutte le forme all'interno della prima diapositiva.  
4. Verificare se la forma è del tipo [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArt) e convertire il tipo della forma selezionata in [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArt) se è SmartArt.  
5. [Aggiungere un nuovo nodo](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) nella forma SmartArt [**NodeCollection**](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArt#getAllNodes--) e impostare il testo nel TextFrame.  
6. Ora, [Aggiungere](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) un [**Child Node**](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArtNode#getChildNodes--) nel nodo [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArt) appena aggiunto e impostare il testo nel TextFrame.  
7. Salvare la presentazione.

```java
import com.aspose.slides.*;

// Carica la presentazione desiderata
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Scorri tutte le forme nella prima diapositiva
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Verifica se la forma è di tipo SmartArt
        if (shape instanceof SmartArt) 
        {
            // Converti la forma in SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // Aggiunta di un nuovo nodo SmartArt
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Aggiunta di testo
            TemNode.getTextFrame().setText("Test");
    
            // Aggiunta di un nuovo nodo figlio nel nodo padre. Verrà aggiunto alla fine della collezione
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // Aggiunta di testo
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // Salvataggio della presentazione
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aggiungere un nodo SmartArt in una posizione specifica**
Nel codice di esempio seguente abbiamo spiegato come aggiungere i nodi figlio appartenenti ai rispettivi nodi della forma SmartArt in una posizione particolare.

1. Creare un'istanza della classe Presentation.  
2. Ottenere il riferimento della prima diapositiva utilizzando il suo indice.  
3. Aggiungere una forma [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/SmartArt) di tipo [**StackedList**](https://reference.aspose.com/slides/it/java/com.aspose.slides/SmartArtLayoutType#StackedList) nella diapositiva selezionata.  
4. Accedere al primo nodo nella forma SmartArt aggiunta.  
5. Ora, aggiungere il [**Child Node**](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArtNode#getChildNodes--) per il [**Node**](https://reference.aspose.com/slides/it/java/com.aspose.slides/SmartArtNode) selezionato nella posizione 2 e impostare il suo testo.  
6. Salvare la presentazione.

```java
import com.aspose.slides.*;

// Creazione di un'istanza di presentazione
Presentation pres = new Presentation();
try {
    // Accedi alla diapositiva della presentazione
    ISlide slide = pres.getSlides().get_Item(0);

    // Aggiungi SmartArt IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Accesso al nodo SmartArt all'indice 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Aggiunta di un nuovo nodo figlio nella posizione 2 del nodo padre
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Aggiungi testo
    chNode.getTextFrame().setText("Sample Text Added");

    // Salva presentazione
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Accedere a un nodo SmartArt**
Il codice di esempio seguente aiuterà ad accedere ai nodi all'interno di una forma SmartArt. Si noti che non è possibile modificare il LayoutType dello SmartArt poiché è di sola lettura e viene impostato solo quando la forma SmartArt viene aggiunta.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation) e caricare la presentazione con la forma SmartArt.  
2. Ottenere il riferimento della prima diapositiva utilizzando il suo indice.  
3. Scorrere tutte le forme all'interno della prima diapositiva.  
4. Verificare se la forma è del tipo [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArt) e convertire il tipo della forma selezionata in [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArt) se è SmartArt.  
5. Scorrere tutti i [**Nodes**](https://reference.aspose.com/slides/it/java/com.aspose.slides/SmartArt#getAllNodes--) all'interno della forma SmartArt.  
6. Accedere e visualizzare informazioni come la posizione del nodo SmartArt, il livello e il testo.

```java
import com.aspose.slides.*;

// Instanzia classe Presentation
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
            // Converti la forma in SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Scorri tutti i nodi all'interno dello SmartArt
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
Il codice di esempio seguente aiuterà ad accedere ai nodi figlio appartenenti ai rispettivi nodi della forma SmartArt.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation) e caricare la presentazione con la forma SmartArt.  
2. Ottenere il riferimento della prima diapositiva utilizzando il suo indice.  
3. Scorrere tutte le forme all'interno della prima diapositiva.  
4. Verificare se la forma è del tipo [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArt) e convertire il tipo della forma selezionata in [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISSmartArt) se è SmartArt.  
5. Scorrere tutti i [**Nodes**](https://reference.aspose.com/slides/it/java/com.aspose.slides/SmartArt#getAllNodes--) all'interno della forma SmartArt.  
6. Per ogni [**Node**](https://reference.aspose.com/slides/it/java/com.aspose.slides/SmartArtNode) della forma SmartArt selezionata, scorrere tutti i [**Child Nodes**](https://reference.aspose.com/slides/it/java/com.aspose.slides/SmartArtNode#getChildNodes--) all'interno del nodo specifico.  
7. Accedere e visualizzare informazioni come la posizione, il livello e il testo del [**Child Node**](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
import com.aspose.slides.*;

// Instanzia la classe Presentation
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
            // Converti la forma in SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Scorri tutti i nodi all'interno dello SmartArt
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
In questo esempio, impareremo ad accedere ai nodi figlio in una posizione particolare appartenenti ai rispettivi nodi della forma SmartArt.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation).  
2. Ottenere il riferimento della prima diapositiva utilizzando il suo indice.  
3. Aggiungere una forma SmartArt di tipo [**StackedList**](https://reference.aspose.com/slides/it/java/com.aspose.slides/SmartArtLayoutType#StackedList).  
4. Accedere alla forma SmartArt aggiunta.  
5. Accedere al nodo all'indice 0 della forma SmartArt selezionata.  
6. Ora, accedere al [**Child Node**](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArtNode#getChildNodes--) nella posizione 1 del nodo SmartArt selezionato utilizzando il metodo **get_Item()**.  
7. Accedere e visualizzare informazioni come la posizione, il livello e il testo del [**Child Node**](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISSmartArtNode#getChildNodes--).

```java
import com.aspose.slides.*;

// Istanzia la presentazione
Presentation pres = new Presentation();
try {
    // Accesso alla prima diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Aggiunta della forma SmartArt nella prima diapositiva
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Accesso al nodo SmartArt all'indice 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Accesso al nodo figlio nella posizione 1 del nodo padre
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // Stampa dei parametri del nodo figlio SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Rimuovere un nodo SmartArt**
In questo esempio, impareremo a rimuovere i nodi all'interno della forma SmartArt.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation) e caricare la presentazione con la forma SmartArt.  
2. Ottenere il riferimento della prima diapositiva utilizzando il suo indice.  
3. Scorrere tutte le forme all'interno della prima diapositiva.  
4. Verificare se la forma è del tipo [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArt) e convertire il tipo della forma selezionata in [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArt) se è SmartArt.  
5. Verificare se lo [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArt) ha più di 0 nodi.  
6. Selezionare il nodo SmartArt da eliminare.  
7. Ora, rimuovere il nodo selezionato utilizzando il metodo [**RemoveNode**](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).  
8. Salvare la presentazione.

```java
import com.aspose.slides.*;

// Carica la presentazione desiderata
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Scorri tutte le forme nella prima diapositiva
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Verifica se la forma è di tipo SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Converti la forma in SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Accesso al nodo SmartArt all'indice 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // Rimozione del nodo selezionato
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
In questo esempio, impareremo a rimuovere i nodi all'interno della forma SmartArt in una posizione particolare.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation) e caricare la presentazione con la forma SmartArt.  
2. Ottenere il riferimento della prima diapositiva utilizzando il suo indice.  
3. Scorrere tutte le forme all'interno della prima diapositiva.  
4. Verificare se la forma è del tipo [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArt) e convertire il tipo della forma selezionata in [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISSmartArt) se è SmartArt.  
5. Selezionare il nodo della forma SmartArt all'indice 0.  
6. Ora, verificare se il nodo SmartArt selezionato ha più di 2 nodi figlio.  
7. Ora, rimuovere il nodo nella **Posizione 1** utilizzando il metodo [**RemoveNode**](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISSmartArtNodeCollection#removeNode-int-).  
8. Salvare la presentazione.

```java
import com.aspose.slides.*;

// Carica la presentazione desiderata
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Scorri tutte le forme nella prima diapositiva
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Verifica se la forma è di tipo SmartArt
        if (shape instanceof SmartArt) 
        {
            // Converti la forma in SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Accesso al nodo SmartArt all'indice 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // Rimozione del nodo figlio nella posizione 1
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
Ora Aspose.Slides per Java supporta l'impostazione delle proprietà [X](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShape#setX-float-) e [Y](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShape#setY-float-) del [SmartArtShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/SmartArtShape). Lo snippet di codice seguente mostra come impostare la posizione, le dimensioni e la rotazione personalizzate del SmartArtShape; si noti inoltre che l'aggiunta di nuovi nodi provoca un ricalcolo delle posizioni e delle dimensioni di tutti i nodi. Con le impostazioni di posizione personalizzate, l'utente può configurare i nodi secondo le necessità.

```java
import com.aspose.slides.*;

// Instanzia classe Presentation
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

## **Verificare un nodo assistente**
{{% alert color="info" %}} 

In questo articolo approfondiremo le funzionalità delle forme SmartArt aggiunte alle diapositive della presentazione programmaticamente usando Aspose.Slides per Java.

{{% /alert %}} 

Utilizzeremo la seguente forma SmartArt di origine per la nostra indagine nelle diverse sezioni di questo articolo.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figura: Forma SmartArt di origine nella diapositiva**|

Nel codice di esempio seguente indagheremo come identificare i **Assistant Nodes** nella collezione dei nodi SmartArt e modificarli.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation) e caricare la presentazione con la forma SmartArt.  
2. Ottenere il riferimento della seconda diapositiva utilizzando il suo indice.  
3. Scorrere tutte le forme all'interno della prima diapositiva.  
4. Verificare se la forma è del tipo [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISSmartArt) e convertire il tipo della forma selezionata in [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISSmartArt) se è SmartArt.  
5. Scorrere tutti i nodi all'interno della forma SmartArt e verificare se sono [**Assistant Nodes**](https://reference.aspose.com/slides/it/java/com.aspose.slides/SmartArtNode#isAssistant--).  
6. Modificare lo stato del nodo assistente in nodo normale.  
7. Salvare la presentazione.

```java
import com.aspose.slides.*;

// Creazione di un'istanza di presentazione
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Scorri tutte le forme nella prima diapositiva
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Verifica se la forma è di tipo SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Converti la forma in SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Scorri tutti i nodi della forma SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Verifica se il nodo è un nodo assistente
                if (node.isAssistant()) 
                {
                    // Imposta il nodo assistente su false e rendilo un nodo normale
                    node.setAssistant(false);
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
|**Figura: Nodi assistenti modificati nella forma SmartArt all'interno della diapositiva**|

## **Impostare il formato di riempimento di un nodo**
Aspose.Slides per Java permette di aggiungere forme SmartArt personalizzate e impostare il loro formato di riempimento. Questo articolo spiega come creare e accedere a forme SmartArt e impostare il loro formato di riempimento utilizzando Aspose.Slides per Java.

Seguite i passaggi seguenti:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation).  
2. Ottenere il riferimento di una diapositiva usando il suo indice.  
3. Aggiungere una forma [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArt) impostando il suo [**LayoutType**](https://reference.aspose.com/slides/it/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).  
4. Impostare il [**FillFormat**](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShape#getFillFormat--) per i nodi della forma SmartArt.  
5. Scrivere la presentazione modificata in un file PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation).  
2. [Aggiungere SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArtNodeCollection#addNode--).  
3. Ottenere il riferimento di un nodo utilizzando il suo indice.  
4. Ottenere l'immagine della miniatura.  
5. Salvare l'immagine della miniatura in qualsiasi formato immagine desiderato.

```java
import com.aspose.slides.*;

// Istanzia la classe Presentation che rappresenta il file PPTX
Presentation pres = new Presentation();
try {
    // Aggiungi SmartArt
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Ottieni il riferimento di un nodo usando il suo indice
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // Ottieni l'anteprima
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // Salva l'anteprima
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

### L'animazione SmartArt è supportata?

Sì. SmartArt è trattato come una forma normale, quindi è possibile [applicare animazioni standard](/slides/it/java/shape-animation/) (entrata, uscita, enfasi, percorsi di movimento) e regolare i tempi. È inoltre possibile animare le forme all'interno dei nodi SmartArt quando necessario.

### Come posso individuare in modo affidabile uno SmartArt specifico su una diapositiva se il suo ID interno è sconosciuto?

Assegnare e cercare tramite [testo alternativo](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/#getAlternativeText--). Impostare un AltText distintivo sullo SmartArt consente di trovarlo programmaticamente senza fare affidamento sugli identificatori interni.

### L'aspetto di SmartArt sarà preservato durante la conversione della presentazione in PDF?

Sì. Aspose.Slides rende SmartArt con alta fedeltà visiva durante l'[esportazione in PDF](/slides/it/java/convert-powerpoint-to-pdf/), preservando layout, colori ed effetti.

### Posso estrarre un'immagine dell'intero SmartArt (per anteprime o report)?

Sì. È possibile renderizzare una forma SmartArt in [formati raster](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/#getImage-int-float-float-) o in [SVG](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) per output vettoriale scalabile, rendendola adatta per miniature, report o utilizzo web.