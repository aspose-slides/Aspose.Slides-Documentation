---
title: Gestisci i nodi della forma SmartArt nelle presentazioni usando C++
linktitle: Nodo forma SmartArt
type: docs
weight: 30
url: /it/cpp/manage-smartart-shape-node/
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
- renderizzare nodo
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Gestisci i nodi della forma SmartArt in PPT e PPTX con Aspose.Slides per C++. Ottieni esempi di codice chiari e suggerimenti per ottimizzare le tue presentazioni."
---
## **Panoramica**

Le grafiche SmartArt nelle presentazioni PowerPoint sono organizzate tramite nodi che contengono testo e definiscono la struttura del diagramma. Aspose.Slides consente di lavorare con questi nodi SmartArt in modo programmatico: aggiungere nuovi nodi e nodi figlio, inserire nodi figlio in una posizione specifica, accedere ai nodi esistenti e leggere il loro testo, livello e posizione.

Questo articolo spiega come gestire i nodi della forma SmartArt. Mostra come rimuovere i nodi, lavorare con i nodi figlio per indice o posizione, trasformare un nodo assistente in un nodo normale, regolare posizione, dimensione e rotazione delle forme dei nodi SmartArt, impostare i formati di riempimento dei nodi e generare un’immagine miniatura per un nodo figlio SmartArt.

## **Aggiungere un nodo SmartArt**
Aspose.Slides for C++ ha fornito l’API più semplice per gestire le forme SmartArt nel modo più facile. Il codice di esempio seguente aiuterà ad aggiungere un nodo e un nodo figlio all’interno della forma SmartArt.

- Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) e carica la presentazione con la Forma SmartArt.  
- Ottieni il riferimento della prima diapositiva usando il suo Index.  
- Scorri tutte le forme all’interno della prima diapositiva.  
- Verifica se la forma è di tipo SmartArt e esegui il cast della forma selezionata a SmartArt se è SmartArt.  
- Aggiungi un nuovo Node nella NodeCollection della forma SmartArt e imposta il testo nel TextFrame.  
- Ora, aggiungi un Child Node nel Node SmartArt appena aggiunto e imposta il testo nel TextFrame.  
- Salva la Presentazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodes-AddNodes.cpp" >}}

## **Aggiungere un nodo SmartArt in una posizione specifica**
Nel codice di esempio seguente abbiamo spiegato come aggiungere i nodi figlio appartenenti ai rispettivi nodi della forma SmartArt in una posizione particolare.

- Crea un’istanza della classe `Presentation`.  
- Ottieni il riferimento della prima diapositiva usando il suo Index.  
- Aggiungi una forma SmartArt di tipo StackedList nella diapositiva di accesso.  
- Accedi al primo nodo nella forma SmartArt aggiunta.  
- Ora, aggiungi il Child Node per il nodo selezionato alla posizione 2 e imposta il suo testo.  
- Salva la Presentazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodesSpecificPosition-AddNodesSpecificPosition.cpp" >}}

## **Accedere a un nodo SmartArt**
Il codice di esempio seguente aiuterà ad accedere ai nodi all’interno della forma SmartArt. Si noti che non è possibile modificare il LayoutType dello SmartArt poiché è di sola lettura e viene impostato solo quando la forma SmartArt viene aggiunta.

- Crea un’istanza della classe `Presentation` e carica la presentazione con la Forma SmartArt.  
- Ottieni il riferimento della prima diapositiva usando il suo Index.  
- Scorri tutte le forme all’interno della prima diapositiva.  
- Verifica se la forma è di tipo SmartArt e esegui il cast della forma selezionata a SmartArt se è SmartArt.  
- Scorri tutti i Node all’interno della Forma SmartArt.  
- Accedi e visualizza informazioni come posizione del Node SmartArt, livello e testo.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArt-AccessSmartArt.cpp" >}}

## **Accedere a un nodo figlio SmartArt**
Il codice di esempio seguente aiuterà ad accedere ai nodi figlio appartenenti ai rispettivi nodi della forma SmartArt.

- Crea un’istanza della classe PresentationEx e carica la presentazione con la Forma SmartArt.  
- Ottieni il riferimento della prima diapositiva usando il suo Index.  
- Scorri tutte le forme all’interno della prima diapositiva.  
- Verifica se la forma è di tipo SmartArt e esegui il cast della forma selezionata a SmartArtEx se è SmartArt.  
- Scorri tutti i Node all’interno della Forma SmartArt.  
- Per ogni nodo della forma SmartArt selezionato, scorri tutti i Child Node all’interno del nodo specifico.  
- Accedi e visualizza informazioni come posizione del Child Node, livello e testo.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodes-AccessChildNodes.cpp" >}}

## **Accedere a un nodo figlio SmartArt in una posizione specifica**
In questo esempio impareremo a accedere ai nodi figlio in una posizione particolare appartenenti ai rispettivi nodi della forma SmartArt.

- Crea un’istanza della classe `Presentation`.  
- Ottieni il riferimento della prima diapositiva usando il suo Index.  
- Aggiungi una forma SmartArt di tipo StackedList.  
- Accedi alla forma SmartArt aggiunta.  
- Accedi al nodo all’indice 0 per la forma SmartArt di accesso.  
- Ora, accedi al Child Node alla posizione 1 per il nodo SmartArt di accesso usando il metodo GetNodeByPosition().  
- Accedi e visualizza informazioni come posizione del Child Node, livello e testo.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodeSpecificPosition-AccessChildNodeSpecificPosition.cpp" >}}

## **Rimuovere un nodo SmartArt**
In questo esempio impareremo a rimuovere i nodi all’interno della forma SmartArt.

- Crea un’istanza della classe `Presentation` e carica la presentazione con la Forma SmartArt.  
- Ottieni il riferimento della prima diapositiva usando il suo Index.  
- Scorri tutte le forme all’interno della prima diapositiva.  
- Verifica se la forma è di tipo SmartArt e esegui il cast della forma selezionata a SmartArt se è SmartArt.  
- Verifica che lo SmartArt abbia più di 0 nodi.  
- Seleziona il nodo SmartArt da eliminare.  
- Ora, rimuovi il nodo selezionato usando il metodo RemoveNode() * Salva la Presentazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNode-RemoveNode.cpp" >}}

## **Rimuovere un nodo SmartArt in una posizione specifica**
In questo esempio impareremo a rimuovere i nodi all’interno della forma SmartArt in una posizione particolare.

- Crea un’istanza della classe `Presentation` e carica la presentazione con la Forma SmartArt.  
- Ottieni il riferimento della prima diapositiva usando il suo Index.  
- Scorri tutte le forme all’interno della prima diapositiva.  
- Verifica se la forma è di tipo SmartArt e esegui il cast della forma selezionata a SmartArt se è SmartArt.  
- Seleziona il nodo della forma SmartArt all’indice 0.  
- Ora, verifica che il nodo SmartArt selezionato abbia più di 2 nodi figlio.  
- Ora, rimuovi il nodo alla Posizione 1 usando il metodo RemoveNodeByPosition().  
- Salva la Presentazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNodeSpecificPosition-RemoveNodeSpecificPosition.cpp" >}}

## **Impostare una posizione personalizzata per un nodo figlio SmartArt**
Ora Aspose.Slides supporta l’impostazione delle proprietà X e Y di SmartArtShape. Il frammento di codice seguente mostra come impostare posizione, dimensione e rotazione personalizzate di SmartArtShape; inoltre, si noti che l’aggiunta di nuovi nodi provoca un ricalcolo delle posizioni e delle dimensioni di tutti i nodi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomChildNodesInSmartArt-CustomChildNodesInSmartArt.cpp" >}}

## **Verificare un nodo assistente**
Nel codice di esempio seguente indagheremo come identificare i nodi assistenti nella raccolta di nodi SmartArt e modificarli.

- Crea un’istanza della classe PresentationEx e carica la presentazione con la Forma SmartArt.  
- Ottieni il riferimento della seconda diapositiva usando il suo Index.  
- Scorri tutte le forme all’interno della prima diapositiva.  
- Verifica se la forma è di tipo SmartArt e esegui il cast della forma selezionata a SmartArtEx se è SmartArt.  
- Scorri tutti i nodi all’interno della forma SmartArt e verifica se sono nodi assistenti.  
- Cambia lo stato del nodo assistente in nodo normale.  
- Salva la Presentazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AssistantNode-AssistantNode.cpp" >}}

## **Impostare il formato di riempimento di un nodo**
Aspose.Slides for C++ rende possibile aggiungere forme SmartArt personalizzate e impostare i loro formati di riempimento. Questo articolo spiega come creare e accedere a forme SmartArt e impostare il loro formato di riempimento utilizzando Aspose.Slides for C++.

Si prega di seguire i passaggi seguenti:

- Crea un’istanza della classe `Presentation`.  
- Ottieni il riferimento di una diapositiva usando il suo indice.  
- Aggiungi una forma SmartArt impostando il suo LayoutType.  
- Imposta il FillFormat per i nodi della forma SmartArt.  
- Scrivi la presentazione modificata come file PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillFormatSmartArtShapeNode-FillFormatSmartArtShapeNode.cpp" >}}

## **Generare una miniatura di un nodo figlio SmartArt**
Gli sviluppatori possono generare una miniatura del nodo figlio di uno SmartArt seguendo i passaggi seguenti:

1. Istanzia la classe `Presentation` che rappresenta il file PPTX.  
2. Aggiungi SmartArt.  
3. Ottieni il riferimento di un nodo usando il suo Index.  
4. Ottieni l’immagine miniatura.  
5. Salva l’immagine miniatura in qualsiasi formato immagine desiderato.

L’esempio sottostante genera una miniatura di un nodo figlio SmartArt

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
auto node = smartArt->get_Node(1);

auto image = node->get_Shape(0)->GetImage();
image->Save(u"SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**L'animazione SmartArt è supportata?**

Sì. SmartArt è trattato come una forma normale, quindi è possibile [applicare animazioni standard](/slides/it/cpp/shape-animation/) (entrata, uscita, enfasi, percorsi di movimento) e regolare i tempi. È inoltre possibile animare le forme all’interno dei nodi SmartArt quando necessario.

**Come posso individuare in modo affidabile uno SmartArt specifico su una diapositiva se il suo ID interno è sconosciuto?**

Assegna e cerca tramite [testo alternativo]https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/set_alternativetext/. Impostare un AltText distintivo sullo SmartArt consente di trovarlo programmaticamente senza dipendere da identificatori interni.

**L'aspetto dello SmartArt verrà preservato durante la conversione della presentazione in PDF?**

Sì. Aspose.Slides rende lo SmartArt con alta fedeltà visiva durante l’[esportazione PDF](/slides/it/cpp/convert-powerpoint-to-pdf/), preservando layout, colori ed effetti.

**Posso estrarre un’immagine dell’intero SmartArt (per anteprime o report)?**

Sì. Puoi renderizzare una forma SmartArt in [formati raster]https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/getimage/ o in [SVG]https://reference.aspose.com/slides/it/cpp/aspose.slides/shape/writeassvg/ per output vettoriale scalabile, rendendolo adatto per miniature, report o uso web.