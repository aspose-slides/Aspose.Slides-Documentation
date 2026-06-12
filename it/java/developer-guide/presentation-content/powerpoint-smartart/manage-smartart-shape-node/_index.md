---
title: Gestire i nodi di forma SmartArt nelle presentazioni usando Java
linktitle: Nodo di forma SmartArt
type: docs
weight: 30
url: /it/java/manage-smartart-shape-node/
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
- Java
- Aspose.Slides
description: "Gestisci i nodi di forma SmartArt in PPT e PPTX con Aspose.Slides per Java. Ottieni esempi di codice chiari e suggerimenti per semplificare le tue presentazioni."
---
## **Panoramica**

Le grafiche SmartArt nelle presentazioni PowerPoint sono organizzate tramite nodi che contengono testo e definiscono la struttura del diagramma. Aspose.Slides consente di lavorare con questi nodi SmartArt in modo programmatico: aggiungere nuovi nodi e nodi figlio, inserire nodi figlio in una posizione specifica, accedere ai nodi esistenti e leggere il loro testo, livello e posizione.

Questo articolo spiega come gestire i nodi di forma SmartArt. Mostra come rimuovere i nodi, lavorare con i nodi figlio per indice o posizione, trasformare un nodo assistente in un nodo normale, regolare posizione, dimensione e rotazione delle forme dei nodi SmartArt, impostare i formati di riempimento dei nodi e generare un’immagine in miniatura per un nodo figlio SmartArt.

## **Aggiungere un nodo SmartArt**
Aspose.Slides for Java ha fornito l’API più semplice per gestire le forme SmartArt nel modo più facile. Il seguente esempio di codice aiuta ad aggiungere un nodo e un nodo figlio all’interno di una forma SmartArt.

1. Crea un’istanza della classe [Presentazione](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) e carica la presentazione con la forma SmartArt.  
1. Ottieni il riferimento della prima diapositiva usando il suo indice.  
1. Scorri tutte le forme nella prima diapositiva.  
1. Verifica se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArt) e effettua il cast della forma selezionata a [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArt) se è SmartArt.  
1. [Aggiungi un nuovo nodo](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) nella forma SmartArt **NodeCollection** e imposta il testo nel TextFrame.  
1. Ora, [Aggiungi](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) un **nodo figlio** nella forma SmartArt appena aggiunta e imposta il testo nel TextFrame.  
1. Salva la presentazione.

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
    
            // Aggiungere un nuovo nodo SmartArt
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Aggiungere testo
            TemNode.getTextFrame().setText("Test");
    
            // Aggiungere un nuovo nodo figlio nel nodo genitore. Verrà aggiunto alla fine della collezione
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // Aggiungere testo
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
Nel seguente esempio di codice spieghiamo come aggiungere i nodi figlio appartenenti ai rispettivi nodi della forma SmartArt in una posizione particolare.

1. Crea un’istanza della classe Presentazione.  
1. Ottieni il riferimento della prima diapositiva usando il suo indice.  
1. Aggiungi una forma SmartArt di tipo [**StackedList**](https://reference.aspose.com/slides/it/java/com.aspose.slides/SmartArtLayoutType#StackedList) nella diapositiva acceduta.  
1. Accedi al primo nodo nella forma SmartArt aggiunta.  
1. Ora, aggiungi il **nodo figlio** per il **nodo** selezionato nella posizione 2 e imposta il suo testo.  
1. Salva la presentazione.

```java
// Creazione di un'istanza di presentazione
Presentation pres = new Presentation();
try {
    // Accedi alla diapositiva della presentazione
    ISlide slide = pres.getSlides().get_Item(0);

    // Aggiungi SmartArt IShape
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
Il seguente esempio di codice aiuta ad accedere ai nodi all’interno della forma SmartArt. Si noti che non è possibile modificare il LayoutType di SmartArt poiché è solo in lettura e viene impostato solo quando la forma SmartArt viene aggiunta.

1. Crea un’istanza della classe [Presentazione](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation) e carica la presentazione con la forma SmartArt.  
1. Ottieni il riferimento della prima diapositiva usando il suo indice.  
1. Scorri tutte le forme nella prima diapositiva.  
1. Verifica se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArt) e effettua il cast della forma selezionata a [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArt) se è SmartArt.  
1. Scorri tutti i **Nodi** all’interno della forma SmartArt.  
1. Accedi e visualizza le informazioni come posizione del nodo SmartArt, livello e testo.

```java
// Istanziare la classe Presentation
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

1. Crea un’istanza della classe [Presentazione](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation) e carica la presentazione con la forma SmartArt.  
1. Ottieni il riferimento della prima diapositiva usando il suo indice.  
1. Scorri tutte le forme nella prima diapositiva.  
1. Verifica se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArt) e effettua il cast della forma selezionata a [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArt) se è SmartArt.  
1. Scorri tutti i **Nodi** all’interno della forma SmartArt.  
1. Per ogni **Nodo** SmartArt selezionato, scorri tutti i **nodi figlio** all’interno del nodo specifico.  
1. Accedi e visualizza le informazioni come posizione del **nodo figlio**, livello e testo.

```java
// Istanziare la classe Presentation
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
                
                // Scorrimento dei nodi figlio nel nodo SmartArt all'indice i
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
In questo esempio impareremo a accedere ai nodi figlio in una posizione particolare appartenenti ai rispettivi nodi della forma SmartArt.

1. Crea un’istanza della classe [Presentazione](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation).  
1. Ottieni il riferimento della prima diapositiva usando il suo indice.  
1. Aggiungi una forma SmartArt di tipo [**StackedList**](https://reference.aspose.com/slides/it/java/com.aspose.slides/SmartArtLayoutType#StackedList).  
1. Accedi alla forma SmartArt aggiunta.  
1. Accedi al nodo con indice 0 della forma SmartArt acceduta.  
1. Ora, accedi al **nodo figlio** nella posizione 1 per il nodo SmartArt acceduto usando il metodo **get_Item()**.  
1. Accedi e visualizza le informazioni come posizione del **nodo figlio**, livello e testo.

```java
// Istanziare la presentazione
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
    
    // Stampa i parametri del nodo figlio SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Rimuovere un nodo SmartArt**
In questo esempio impareremo a rimuovere i nodi all’interno della forma SmartArt.

1. Crea un’istanza della classe [Presentazione](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation) e carica la presentazione con la forma SmartArt.  
1. Ottieni il riferimento della prima diapositiva usando il suo indice.  
1. Scorri tutte le forme nella prima diapositiva.  
1. Verifica se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArt) e effettua il cast della forma selezionata a [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArt) se è SmartArt.  
1. Verifica se lo SmartArt ha più di 0 nodi.  
1. Seleziona il nodo SmartArt da eliminare.  
1. Ora, rimuovi il nodo selezionato usando il metodo [**RemoveNode**](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).  
1. Salva la presentazione.

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
In questo esempio impareremo a rimuovere i nodi all’interno della forma SmartArt in una posizione particolare.

1. Crea un’istanza della classe [Presentazione](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation) e carica la presentazione con la forma SmartArt.  
1. Ottieni il riferimento della prima diapositiva usando il suo indice.  
1. Scorri tutte le forme nella prima diapositiva.  
1. Verifica se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArt) e effettua il cast della forma selezionata a [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArt) se è SmartArt.  
1. Seleziona il nodo della forma SmartArt con indice 0.  
1. Ora, verifica se il nodo SmartArt selezionato ha più di 2 nodi figlio.  
1. Ora, rimuovi il nodo nella **Posizione 1** usando il metodo [**RemoveNode**](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-).  
1. Salva la presentazione.

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
Ora Aspose.Slides for Java supporta l’impostazione delle proprietà [SmartArtShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShape#setX-float-) e [Y](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShape#setY-float-). Il frammento di codice sottostante mostra come impostare posizione, dimensione e rotazione personalizzate della SmartArtShape; si noti inoltre che l’aggiunta di nuovi nodi provoca una ricalcolazione di posizioni e dimensioni di tutti i nodi. Con le impostazioni di posizione personalizzate, l’utente può configurare i nodi secondo le esigenze.

```java
// Istanziare la classe Presentation
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
{{% alert color="primary" %}} 

In questo articolo approfondiremo le funzionalità delle forme SmartArt aggiunte alle diapositive della presentazione programmaticamente con Aspose.Slides for Java.

{{% /alert %}} 

Utilizzeremo la seguente forma SmartArt di origine per le indagini nelle diverse sezioni di questo articolo.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figura: Forma SmartArt di origine nella diapositiva**|

Nel seguente esempio di codice esamineremo come identificare **nodi assistenti** nella raccolta dei nodi SmartArt e modificarli.

1. Crea un’istanza della classe [Presentazione](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation) e carica la presentazione con la forma SmartArt.  
1. Ottieni il riferimento della seconda diapositiva usando il suo indice.  
1. Scorri tutte le forme nella prima diapositiva.  
1. Verifica se la forma è di tipo [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArt) e effettua il cast della forma selezionata a [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArt) se è SmartArt.  
1. Scorri tutti i nodi all’interno della forma SmartArt e verifica se sono **nodi assistenti**.  
1. Cambia lo stato del nodo assistente in nodo normale.  
1. Salva la presentazione.

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
    
            // Scorrere tutti i nodi della forma SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Verifica se il nodo è un nodo Assistente
                if (node.isAssistant()) 
                {
                    // Impostare il nodo Assistente a false e trasformarlo in nodo normale
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
Aspose.Slides for Java consente di aggiungere forme SmartArt personalizzate e impostare il loro formato di riempimento. Questo articolo spiega come creare e accedere a forme SmartArt e impostare il loro formato di riempimento usando Aspose.Slides for Java.

Segui i passaggi seguenti:

1. Crea un’istanza della classe [Presentazione](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation).  
1. Ottieni il riferimento di una diapositiva usando il suo indice.  
1. Aggiungi una forma [SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArt) impostando il suo **LayoutType**.  
1. Imposta il **FillFormat** per i nodi della forma SmartArt.  
1. Scrivi la presentazione modificata come file PPTX.

```java
// Istanziare la presentazione
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

1. Crea un’istanza della classe [Presentazione](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation).  
1. [Aggiungi SmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISmartArtNodeCollection#addNode--).  
1. Ottieni il riferimento di un nodo usando il suo indice.  
1. Ottieni l’immagine in miniatura.  
1. Salva l’immagine in miniatura nel formato immagine desiderato.

```java
// Istanziare la classe Presentation che rappresenta il file PPTX
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

**L'animazione SmartArt è supportata?**

Sì. SmartArt è trattato come una forma normale, quindi è possibile [applicare animazioni standard](/slides/it/java/shape-animation/) (entrata, uscita, enfasi, percorsi di movimento) e regolare la sequenza temporale. È inoltre possibile animare le forme all’interno dei nodi SmartArt quando necessario.

**Come posso trovare in modo affidabile una SmartArt specifica su una diapositiva se il suo ID interno è sconosciuto?**

Assegna e cerca tramite [testo alternativo](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/#getAlternativeText--). Impostare un AltText distintivo sulla SmartArt consente di individuarla programmaticamente senza dipendere dagli identificatori interni.

**L'aspetto della SmartArt sarà preservato durante la conversione della presentazione in PDF?**

Sì. Aspose.Slides rende la SmartArt con alta fedeltà visiva durante l’[esportazione in PDF](/slides/it/java/convert-powerpoint-to-pdf/), conservando layout, colori ed effetti.

**Posso estrarre un’immagine dell’intera SmartArt (per anteprime o report)?**

Sì. È possibile rendere una forma SmartArt in [formati raster](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/#getImage-int-float-float-) o in [SVG](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) per un output vettoriale scalabile, utile per miniature, report o utilizzo web.