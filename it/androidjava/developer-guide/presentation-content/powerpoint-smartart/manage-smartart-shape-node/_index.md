---
title: Gestire i nodi di forma SmartArt nelle presentazioni su Android
linktitle: Nodo di forma SmartArt
type: docs
weight: 30
url: /it/androidjava/manage-smartart-shape-node/
keywords:
- nodo SmartArt
- nodo figlio
- aggiungere nodo
- posizione nodo
- accedere nodo
- rimuovere nodo
- posizione personalizzata
- nodo assistente
- formato di riempimento
- render nodo
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Gestisci i nodi di forma SmartArt in PPT e PPTX con Aspose.Slides per Android. Ottieni esempi di codice Java chiari e suggerimenti per ottimizzare le tue presentazioni."
---
## **Panoramica**

Le grafiche SmartArt nelle presentazioni PowerPoint sono organizzate tramite nodi che contengono testo e definiscono la struttura del diagramma. Aspose.Slides consente di lavorare con questi nodi SmartArt in modo programmatico: aggiungere nuovi nodi e nodi figlio, inserire nodi figlio in una posizione specifica, accedere ai nodi esistenti e leggere il loro testo, livello e posizione.

Questo articolo spiega come gestire i nodi delle forme SmartArt. Mostra come rimuovere i nodi, lavorare con i nodi figlio per indice o posizione, trasformare un nodo assistente in un nodo normale, regolare posizione, dimensione e rotazione delle forme dei nodi SmartArt, impostare i formati di riempimento dei nodi e generare un'immagine miniatura per un nodo SmartArt.

## **Aggiungere un nodo SmartArt**

Aspose.Slides per Android via Java ha fornito l'API più semplice per gestire le forme SmartArt nel modo più facile. Il codice di esempio seguente aiuterà ad aggiungere un nodo e un nodo figlio all'interno della forma SmartArt.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) e carica la presentazione con la forma SmartArt.  
2. Ottieni il riferimento della prima diapositiva usando il suo indice.  
3. Scorri ogni forma all'interno della prima diapositiva.  
4. Verifica se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt) e, se lo è, esegui il cast della forma selezionata a [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt).  
5. [Aggiungi un nuovo nodo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) nella forma SmartArt [**NodeCollection**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) e imposta il testo nel TextFrame.  
6. Ora, [Aggiungi](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) un [**Child Node**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) al nodo [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt) appena aggiunto e imposta il testo nel TextFrame.  
7. Salva la presentazione.

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
            // Esegui il cast della forma a SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // Aggiunta di un nuovo nodo SmartArt
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Aggiunta di testo
            TemNode.getTextFrame().setText("Test");
    
            // Aggiunta di un nuovo nodo figlio nel nodo genitore. Verrà aggiunto alla fine della collezione
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

1. Crea un'istanza della classe Presentation.  
2. Ottieni il riferimento della prima diapositiva usando il suo indice.  
3. Aggiungi una forma [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArt) di tipo [**StackedList**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) nella diapositiva acceduta.  
4. Accedi al primo nodo nella forma SmartArt aggiunta.  
5. Ora, aggiungi il [**Child Node**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) per il [**Node**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArtNode) selezionato alla posizione 2 e imposta il suo testo.  
6. Salva la presentazione.

```java
import com.aspose.slides.*;

// Creazione di un'istanza di presentazione
Presentation pres = new Presentation();
try {
    // Accedi alla diapositiva della presentazione
    ISlide slide = pres.getSlides().get_Item(0);

    // Aggiungi Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Accesso al nodo SmartArt all'indice 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Aggiunta di un nuovo nodo figlio in posizione 2 nel nodo genitore
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

Il codice di esempio seguente ti aiuterà ad accedere ai nodi all'interno della forma SmartArt. Nota che il LayoutType dello SmartArt viene scelto al momento dell'aggiunta della forma; modificarlo successivamente con **setLayout** ricostruisce l'intero diagramma, quindi le posizioni e le dimensioni dei nodi impostate vengono ricalcolate.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation) e carica la presentazione con la forma SmartArt.  
2. Ottieni il riferimento della prima diapositiva usando il suo indice.  
3. Scorri ogni forma all'interno della prima diapositiva.  
4. Verifica se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt) e, se lo è, esegui il cast della forma selezionata a [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt).  
5. Scorri tutti i [**Nodes**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArt#getAllNodes--) all'interno della forma SmartArt.  
6. Accedi e visualizza informazioni come posizione del nodo SmartArt, livello e testo.

```java
import com.aspose.slides.*;

// Instanzia la classe Presentation
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

Il codice di esempio seguente ti aiuterà ad accedere ai nodi figlio appartenenti ai rispettivi nodi della forma SmartArt.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation) e carica la presentazione con la forma SmartArt.  
2. Ottieni il riferimento della prima diapositiva usando il suo indice.  
3. Scorri ogni forma all'interno della prima diapositiva.  
4. Verifica se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt) e, se lo è, esegui il cast della forma selezionata a [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt).  
5. Scorri tutti i [**Nodes**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArt#getAllNodes--) all'interno della forma SmartArt.  
6. Per ogni [**Node**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArtNode) della forma SmartArt selezionata, scorri tutti i [**Child Nodes**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) all'interno del nodo specifico.  
7. Accedi e visualizza informazioni come posizione, livello e testo del [**Child Node**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--).

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

In questo esempio, impareremo ad accedere ai nodi figlio in una posizione particolare appartenenti ai rispettivi nodi della forma SmartArt.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).  
2. Ottieni il riferimento della prima diapositiva usando il suo indice.  
3. Aggiungi una forma SmartArt di tipo [**StackedList**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList).  
4. Accedi alla forma SmartArt aggiunta.  
5. Accedi al nodo all'indice 0 della forma SmartArt acceduta.  
6. Ora, accedi al [**Child Node**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) alla posizione 1 del nodo SmartArt acceduto usando il metodo **get_Item()**.  
7. Accedi e visualizza informazioni come posizione, livello e testo del [**Child Node**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
import com.aspose.slides.*;

// Instanzia la presentazione
Presentation pres = new Presentation();
try {
    // Accesso alla prima diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Aggiunta della forma SmartArt nella prima diapositiva
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Accesso al nodo SmartArt all'indice 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Accesso al nodo figlio alla posizione 1 nel nodo genitore
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

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation) e carica la presentazione con la forma SmartArt.  
2. Ottieni il riferimento della prima diapositiva usando il suo indice.  
3. Scorri ogni forma all'interno della prima diapositiva.  
4. Verifica se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt) e, se lo è, esegui il cast della forma selezionata a [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt).  
5. Verifica se il [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt) ha più di 0 nodi.  
6. Seleziona il nodo SmartArt da eliminare.  
7. Ora, rimuovi il nodo selezionato usando il metodo [**RemoveNode**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).  
8. Salva la presentazione.

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
            // Esegui il cast della forma a SmartArt
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

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation) e carica la presentazione con la forma SmartArt.  
2. Ottieni il riferimento della prima diapositiva usando il suo indice.  
3. Scorri ogni forma all'interno della prima diapositiva.  
4. Verifica se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt) e, se lo è, esegui il cast della forma selezionata a [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt).  
5. Seleziona il nodo della forma SmartArt all'indice 0.  
6. Ora, verifica se il nodo SmartArt selezionato ha più di 2 nodi figlio.  
7. Ora, rimuovi il nodo alla **Posizione 1** usando il metodo [**RemoveNode**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-).  
8. Salva la presentazione.

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
            // Esegui il cast della forma a SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Accesso al nodo SmartArt all'indice 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // Rimozione del nodo figlio alla posizione 1
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

Ora Aspose.Slides per Android via Java supporta l'impostazione delle proprietà [X](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShape#setX-float-) e [Y](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShape#setY-float-) di [SmartArtShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArtShape). Lo snippet di codice sottostante mostra come impostare una posizione, dimensione e rotazione personalizzate di SmartArtShape; nota anche che l'aggiunta di nuovi nodi causa un ricalcolo delle posizioni e delle dimensioni di tutti i nodi. Inoltre, con le impostazioni di posizione personalizzate, l'utente può impostare i nodi secondo le proprie esigenze.

```java
import com.aspose.slides.*;

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

## **Verificare un nodo assistente**

{{% alert color="info" %}} 

In questo articolo indagheremo ulteriormente le funzionalità delle forme SmartArt aggiunte nelle diapositive della presentazione in modo programmatico usando Aspose.Slides per Android via Java.

{{% /alert %}} 

Utilizzeremo la seguente forma SmartArt di origine per la nostra indagine nelle diverse sezioni di questo articolo.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figura: Forma SmartArt di origine nella diapositiva**|

Nel codice di esempio seguente indagheremo come identificare i **Nodi assistente** nella raccolta dei nodi SmartArt e modificarli.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation) e carica la presentazione con la forma SmartArt.  
2. Ottieni il riferimento della prima diapositiva usando il suo indice.  
3. Scorri ogni forma all'interno della prima diapositiva.  
4. Verifica se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt) e, se lo è, esegui il cast della forma selezionata a [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt).  
5. Scorri tutti i nodi all'interno della forma SmartArt e verifica se sono [**Assistant Nodes**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArtNode#isAssistant--).  
6. Cambia lo stato del nodo assistente in nodo normale.  
7. Salva la presentazione.

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
            // Esegui il cast della forma a SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Scorri tutti i nodi della forma SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Verifica se il nodo è un nodo Assistente
                if (node.isAssistant()) 
                {
                    // Imposta il nodo Assistente a false e trasformalo in nodo normale
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
|**Figura: Nodi assistente modificati nella forma SmartArt nella diapositiva**|

## **Impostare il formato di riempimento di un nodo**

Aspose.Slides per Android via Java permette di aggiungere forme SmartArt personalizzate e impostare il loro formato di riempimento. Questo articolo spiega come creare e accedere alle forme SmartArt e impostare il loro formato di riempimento usando Aspose.Slides per Android via Java.

Segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation) .  
2. Ottieni il riferimento di una diapositiva usando il suo indice.  
3. Aggiungi una forma [SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArt) impostando il suo [**LayoutType**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).  
4. Imposta il [**FillFormat**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShape#getFillFormat--) per i nodi della forma SmartArt.  
5. Scrivi la presentazione modificata in un file PPTX.

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

## **Generare una miniatura di un nodo SmartArt**

Gli sviluppatori possono generare una miniatura di un nodo di un SmartArt seguendo i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).  
2. [Aggiungi SmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).  
3. Ottieni il riferimento di un nodo usando il suo indice.  
4. Ottieni l'immagine miniatura.  
5. Salva l'immagine miniatura in qualsiasi formato immagine desiderato.

```java
import com.aspose.slides.*;

// Instanzia la classe Presentation che rappresenta il file PPTX
Presentation pres = new Presentation();
try {
    // Aggiungi SmartArt
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Ottieni il riferimento di un nodo usando il suo indice
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

### L'animazione SmartArt è supportata?

Sì. SmartArt è trattata come una forma normale, quindi puoi [applica animazioni standard](/slides/it/androidjava/shape-animation/) (entrata, uscita, enfasi, percorsi di movimento) e regolare i tempi. Puoi anche animare le forme all'interno dei nodi SmartArt quando necessario.

### Come posso individuare in modo affidabile uno SmartArt specifico su una diapositiva se il suo ID interno è sconosciuto?

Assegna e ricerca tramite [testo alternativo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shape/#getAlternativeText--). Impostare un AltText distintivo sullo SmartArt ti consente di trovarlo programmaticamente senza fare affidamento sugli identificatori interni.

### L'aspetto di SmartArt sarà mantenuto durante la conversione della presentazione in PDF?

Sì. Aspose.Slides rende SmartArt con alta fedeltà visiva durante l'[esportazione PDF](/slides/it/androidjava/convert-powerpoint-to-pdf/), mantenendo layout, colori ed effetti.

### Posso estrarre un'immagine dell'intero SmartArt (per anteprime o report)?

Sì. Puoi renderizzare una forma SmartArt in [formati raster](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) o in [SVG](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) per output vettoriale scalabile, rendendola adatta per miniature, report o uso web.