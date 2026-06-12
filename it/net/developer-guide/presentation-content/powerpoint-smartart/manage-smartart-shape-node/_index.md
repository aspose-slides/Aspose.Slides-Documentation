---
title: Gestire i nodi delle forme SmartArt nelle presentazioni in .NET
linktitle: Nodo Forma SmartArt
type: docs
weight: 30
url: /it/net/manage-smartart-shape-node/
keywords:
- nodo SmartArt
- nodo figlio
- aggiungere nodo
- posizione nodo
- accesso nodo
- rimuovere nodo
- posizione personalizzata
- nodo assistente
- formato di riempimento
- render nodo
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Gestisci i nodi delle forme SmartArt in PPT e PPTX con Aspose.Slides per .NET. Ottieni esempi di codice chiari e consigli per ottimizzare le tue presentazioni."
---
## **Panoramica**

Le grafiche SmartArt nelle presentazioni PowerPoint sono organizzate tramite nodi che contengono testo e definiscono la struttura del diagramma. Aspose.Slides consente di lavorare con questi nodi SmartArt in modo programmatico: aggiungere nuovi nodi e nodi figlio, inserire nodi figlio in una posizione specifica, accedere ai nodi esistenti e leggere il loro testo, livello e posizione.

Questo articolo spiega come gestire i nodi delle forme SmartArt. Mostra come rimuovere i nodi, lavorare con i nodi figlio per indice o posizione, trasformare un nodo assistente in un nodo normale, regolare posizione, dimensione e rotazione delle forme dei nodi SmartArt, impostare i formati di riempimento dei nodi e generare un’immagine in miniatura per un nodo figlio SmartArt.

## **Aggiungere un nodo SmartArt**
Aspose.Slides per .NET fornisce l’API più semplice per gestire le forme SmartArt nel modo più facile. Il codice di esempio seguente aiuterà ad aggiungere un nodo e un nodo figlio all’interno di una forma SmartArt.

- Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) e carica la presentazione con la forma SmartArt.  
- Ottieni il riferimento della prima diapositiva usando il suo indice.  
- Scorri tutte le forme presenti nella prima diapositiva.  
- Verifica se la forma è di tipo SmartArt e effettua il cast della forma selezionata a SmartArt, se è SmartArt.  
- Aggiungi un nuovo nodo nella NodeCollection della forma SmartArt e imposta il testo nel TextFrame.  
- Ora, aggiungi un nodo figlio al nodo SmartArt appena aggiunto e imposta il testo nel TextFrame.  
- Salva la presentazione.

```c#
// Carica la presentazione desiderata
Presentation pres = new Presentation("AddNodes.pptx");

// Scorri tutte le forme nella prima diapositiva
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Verifica se la forma è di tipo SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Esegui il cast della forma a SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Aggiungere un nuovo nodo SmartArt
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // Aggiungere testo
        TemNode.TextFrame.Text = "Test";

        // Aggiungere un nuovo nodo figlio nel nodo padre. Verrà aggiunto alla fine della collezione
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // Aggiungere testo
        newNode.TextFrame.Text = "New Node Added";

    }
}

// Salva la presentazione
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Aggiungere un nodo SmartArt in una posizione specifica**
Nel codice di esempio seguente spieghiamo come aggiungere i nodi figlio appartenenti ai rispettivi nodi della forma SmartArt in una posizione particolare.

- Crea un’istanza della classe `Presentation`.  
- Ottieni il riferimento della prima diapositiva usando il suo indice.  
- Aggiungi una forma SmartArt di tipo StackedList nella diapositiva acceduta.  
- Accedi al primo nodo nella forma SmartArt aggiunta.  
- Ora, aggiungi il nodo figlio per il nodo selezionato nella posizione 2 e imposta il suo testo.  
- Salva la presentazione.

```c#
// Creazione di un'istanza di presentazione
Presentation pres = new Presentation();

// Access the presentation slide
ISlide slide = pres.Slides[0];

// Add Smart Art IShape
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Accessing the SmartArt node at index 0
ISmartArtNode node = smart.AllNodes[0];

// Adding new child node at position 2 in parent node
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// Add Text
chNode.TextFrame.Text = "Sample Text Added";

// Save Presentation
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Accedere a un nodo SmartArt**
Il codice di esempio seguente aiuterà ad accedere ai nodi all’interno della forma SmartArt. Si noti che non è possibile modificare il LayoutType di SmartArt poiché è di sola lettura ed è impostato solo quando la forma SmartArt viene aggiunta.

- Crea un’istanza della classe `Presentation` e carica la presentazione con la forma SmartArt.  

- Ottieni il riferimento della prima diapositiva usando il suo indice.  

- Scorri tutte le forme presenti nella prima diapositiva.  

- Verifica se la forma è di tipo SmartArt e effettua il cast della forma selezionata a SmartArt, se è SmartArt.  

- Scorri tutti i nodi all’interno della forma SmartArt.  

- Accedi e visualizza informazioni come posizione del nodo SmartArt, livello e testo.  

  ```c#
  // Carica la presentazione desiderata
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // Scorri tutte le forme nella prima diapositiva
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // Verifica se la forma è di tipo SmartArt
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // Esegui il cast della forma a SmartArt
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // Scorri tutti i nodi all'interno di SmartArt
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // Accesso al nodo SmartArt all'indice i
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // Stampa i parametri del nodo SmartArt
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
```

## **Accedere a un nodo figlio SmartArt**
Il codice di esempio seguente aiuterà ad accedere ai nodi figlio appartenenti ai rispettivi nodi della forma SmartArt.

- Crea un’istanza della classe PresentationEx e carica la presentazione con la forma SmartArt.  
- Ottieni il riferimento della prima diapositiva usando il suo indice.  
- Scorri tutte le forme presenti nella prima diapositiva.  
- Verifica se la forma è di tipo SmartArt e effettua il cast della forma selezionata a SmartArtEx, se è SmartArt.  
- Scorri tutti i nodi all’interno della forma SmartArt.  
- Per ogni nodo della forma SmartArt selezionato, scorri tutti i nodi figlio all’interno del nodo specifico.  
- Accedi e visualizza informazioni come posizione del nodo figlio, livello e testo.

```c#
// Carica la presentazione desiderata
Presentation pres = new Presentation("AccessChildNodes.pptx");

// Scorri tutte le forme nella prima diapositiva
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Verifica se la forma è di tipo SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Esegui il cast della forma a SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Scorri tutti i nodi all'interno di SmartArt
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // Accesso al nodo SmartArt all'indice i
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // Scorrendo i nodi figlio nel nodo SmartArt all'indice i
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // Accesso al nodo figlio nel nodo SmartArt
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // Stampa i parametri del nodo figlio SmartArt
                string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```

## **Accedere a un nodo figlio SmartArt in una posizione specifica**
In questo esempio impareremo a accedere ai nodi figlio in una posizione particolare appartenenti ai rispettivi nodi della forma SmartArt.

- Crea un’istanza della classe `Presentation`.  
- Ottieni il riferimento della prima diapositiva usando il suo indice.  
- Aggiungi una forma SmartArt di tipo StackedList.  
- Accedi alla forma SmartArt aggiunta.  
- Accedi al nodo all’indice 0 della forma SmartArt.  
- Ora, accedi al nodo figlio nella posizione 1 del nodo SmartArt selezionato usando il metodo GetNodeByPosition().  
- Accedi e visualizza informazioni come posizione del nodo figlio, livello e testo.

```c#
// Istanziare la presentazione
Presentation pres = new Presentation();

// Accesso alla prima diapositiva
ISlide slide = pres.Slides[0];

// Aggiunta della forma SmartArt nella prima diapositiva
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Accesso al nodo SmartArt all'indice 0
ISmartArtNode node = smart.AllNodes[0];

// Accesso al nodo figlio alla posizione 1 nel nodo padre
int position = 1;
SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

// Stampa dei parametri del nodo figlio SmartArt
string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
Console.WriteLine(outString);
```

## **Rimuovere un nodo SmartArt**
In questo esempio impareremo a rimuovere i nodi all’interno della forma SmartArt.

- Crea un’istanza della classe `Presentation` e carica la presentazione con la forma SmartArt.  
- Ottieni il riferimento della prima diapositiva usando il suo indice.  
- Scorri tutte le forme presenti nella prima diapositiva.  
- Verifica se la forma è di tipo SmartArt e effettua il cast della forma selezionata a SmartArt, se è SmartArt.  
- Verifica se lo SmartArt contiene più di 0 nodi.  
- Seleziona il nodo SmartArt da eliminare.  
- Ora, rimuovi il nodo selezionato usando il metodo RemoveNode() e salva la presentazione.

```c#
// Carica la presentazione desiderata
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // Scorri tutte le forme nella prima diapositiva
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // Verifica se la forma è di tipo SmartArt
        if (shape is ISmartArt)
        {
            // Esegui il cast della forma a SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            if (smart.AllNodes.Count > 0)
            {
                // Accesso al nodo SmartArt all'indice 0
                ISmartArtNode node = smart.AllNodes[0];

                // Rimozione del nodo selezionato
                smart.AllNodes.RemoveNode(node);

            }
        }
    }

    // Salva la presentazione
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Rimuovere un nodo SmartArt in una posizione specifica**
In questo esempio impareremo a rimuovere i nodi all’interno della forma SmartArt in una posizione particolare.

- Crea un’istanza della classe `Presentation` e carica la presentazione con la forma SmartArt.  
- Ottieni il riferimento della prima diapositiva usando il suo indice.  
- Scorri tutte le forme presenti nella prima diapositiva.  
- Verifica se la forma è di tipo SmartArt e effettua il cast della forma selezionata a SmartArt, se è SmartArt.  
- Seleziona il nodo della forma SmartArt all’indice 0.  
- Ora, verifica se il nodo SmartArt selezionato contiene più di 2 nodi figlio.  
- Ora, rimuovi il nodo nella posizione 1 usando il metodo RemoveNodeByPosition().  
- Salva la presentazione.

```c#
// Carica la presentazione desiderata             
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// Scorri tutte le forme nella prima diapositiva
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // Verifica se la forma è di tipo SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // Esegui il cast della forma a SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // Accesso al nodo SmartArt all'indice 0
            Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

            if (node.ChildNodes.Count >= 2)
            {
                // Rimozione del nodo figlio alla posizione 1
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// Salva la presentazione
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Impostare una posizione personalizzata per un nodo figlio in un oggetto SmartArt**
Ora Aspose.Slides per .NET supporta l’impostazione delle proprietà X e Y di SmartArtShape. Il frammento di codice sotto mostra come impostare posizione, dimensione e rotazione personalizzate di SmartArtShape; si noti inoltre che l’aggiunta di nuovi nodi provoca una ricalcolazione di posizioni e dimensioni di tutti i nodi.

```c#
// Carica la presentazione desiderata
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// Sposta la forma SmartArt in una nuova posizione
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// Modifica le larghezze della forma SmartArt
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// Modifica l'altezza della forma SmartArt
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// Modifica la rotazione della forma SmartArt
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```

## **Verificare un nodo assistente**
Nel codice di esempio seguente esamineremo come identificare i nodi assistenti nella collezione di nodi SmartArt e modificarli.

- Crea un’istanza della classe PresentationEx e carica la presentazione con la forma SmartArt.  
- Ottieni il riferimento della seconda diapositiva usando il suo indice.  
- Scorri tutte le forme presenti nella prima diapositiva.  
- Verifica se la forma è di tipo SmartArt e effettua il cast della forma selezionata a SmartArtEx, se è SmartArt.  
- Scorri tutti i nodi all’interno della forma SmartArt e verifica se sono nodi assistenti.  
- Cambia lo stato del nodo assistente in nodo normale.  
- Salva la presentazione.

```c#
// Creazione di un'istanza di presentazione
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // Scorri tutte le forme nella prima diapositiva
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Verifica se la forma è di tipo SmartArt
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // Esegui il cast della forma a SmartArtEx
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // Scorri tutti i nodi della forma SmartArt

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // Verifica se il nodo è un nodo Assistente
                if (node.IsAssistant)
                {
                    // Imposta il nodo Assistente a false e trasformalo in nodo normale
                    node.IsAssistant = false;
                }
            }
        }
    }
    // Salva la presentazione
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Impostare il formato di riempimento di un nodo**
Aspose.Slides per .NET consente di aggiungere forme SmartArt personalizzate e impostarne i formati di riempimento. Questo articolo spiega come creare e accedere a forme SmartArt e impostare il loro formato di riempimento usando Aspose.Slides per .NET.

Seguire i passaggi seguenti:

- Crea un’istanza della classe `Presentation`.  
- Ottieni il riferimento di una diapositiva usando il suo indice.  
- Aggiungi una forma SmartArt impostando il suo LayoutType.  
- Imposta il FillFormat per i nodi della forma SmartArt.  
- Scrivi la presentazione modificata come file PPTX.

```c#
using (Presentation presentation = new Presentation())
{
    // Accesso alla diapositiva
    ISlide slide = presentation.Slides[0];

    // Aggiunta della forma SmartArt e dei nodi
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Some text";

    // Impostazione del colore di riempimento del nodo
    foreach (var item in node.Shapes)
    {
        item.FillFormat.FillType = FillType.Solid;
        item.FillFormat.SolidFillColor.Color = Color.Red;
    }

    // Salvataggio della presentazione
    presentation.Save("FillFormat_SmartArt_ShapeNode_out.pptx", SaveFormat.Pptx);
}
```

## **Generare una miniatura di un nodo figlio SmartArt**
Gli sviluppatori possono generare una miniatura del nodo figlio di un SmartArt seguendo i passaggi seguenti:

1. Istanziare la classe `Presentation` che rappresenta il file PPTX.  
2. Aggiungere SmartArt.  
3. Ottenere il riferimento di un nodo usando il suo indice.  
4. Ottenerne l’immagine in miniatura.  
5. Salvare l’immagine in miniatura nel formato immagine desiderato.

L’esempio seguente genera una miniatura del nodo figlio SmartArt

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);
    ISmartArtNode node = smartArt.Nodes[1];

    using (IImage image = node.Shapes[0].GetImage())
    {
        image.Save("SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat.Jpeg);
    }
}
```

## **FAQ**

**L’animazione SmartArt è supportata?**

Sì. SmartArt è trattato come una forma comune, quindi è possibile [applicare animazioni standard](/slides/it/net/shape-animation/) (entrata, uscita, enfasi, percorsi di movimento) e regolare i tempi. È anche possibile animare le forme all’interno dei nodi SmartArt quando necessario.

**Come posso individuare in modo affidabile uno SmartArt specifico su una diapositiva se il suo ID interno è sconosciuto?**

Assegna e cerca tramite [testo alternativo]https://reference.aspose.com/slides/it/net/aspose.slides/shape/alternativetext/. Impostare un AltText distintivo sullo SmartArt permette di trovarlo programmaticamente senza fare affidamento su identificatori interni.

**L’aspetto dello SmartArt verrà conservato durante la conversione della presentazione in PDF?**

Sì. Aspose.Slides rende lo SmartArt con alta fedeltà visiva durante l’[esportazione PDF](/slides/it/net/convert-powerpoint-to-pdf/), preservando layout, colori ed effetti.

**Posso estrarre un’immagine dell’intero SmartArt (per anteprime o report)?**

Sì. È possibile rendere una forma SmartArt in [formati raster]https://reference.aspose.com/slides/it/net/aspose.slides/shape/getimage/ o in [SVG]https://reference.aspose.com/slides/it/net/aspose.slides/shape/writeassvg/ per output vettoriale scalabile, rendendola adatta a miniature, report o utilizzo web.