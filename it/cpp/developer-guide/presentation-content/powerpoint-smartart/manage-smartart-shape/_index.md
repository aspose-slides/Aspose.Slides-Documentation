---
title: Gestire le grafiche SmartArt nelle presentazioni con C++
linktitle: Grafiche SmartArt
type: docs
weight: 20
url: /it/cpp/manage-smartart-shape/
keywords:
- oggetto SmartArt
- grafica SmartArt
- stile SmartArt
- colore SmartArt
- creare SmartArt
- aggiungere SmartArt
- modificare SmartArt
- cambiare SmartArt
- accedere a SmartArt
- tipo di layout SmartArt
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Automatizza la creazione, modifica e stile delle SmartArt di PowerPoint in C++ usando Aspose.Slides, con esempi di codice concisi e indicazioni orientate alle prestazioni."
---
## **Panoramica**

Aspose.Slides consente di creare e gestire grafici SmartArt nelle presentazioni PowerPoint in modo programmatico. Questo articolo spiega come aggiungere una forma SmartArt a una diapositiva, accedere a forme SmartArt esistenti, trovare SmartArt in base a un tipo di layout specifico e aggiornare il suo aspetto visivo modificando lo stile SmartArt o lo stile colore.

Gli esempi mostrano come lavorare con le forme SmartArt attraverso la raccolta di forme della diapositiva della presentazione, verificare se una forma è SmartArt e quindi modificare o ispezionarne le proprietà.

## **Creare una forma SmartArt**
Aspose.Slides per C++ ora facilita l’aggiunta di forme SmartArt personalizzate nelle diapositive da zero. Aspose.Slides per C++ fornisce l’API più semplice per creare forme SmartArt nel modo più semplice. Per creare una forma SmartArt in una diapositiva, seguire i passaggi seguenti:

- Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) .
- Ottenere il riferimento di una diapositiva utilizzando il suo indice.
- Aggiungere una forma SmartArt impostando il LayoutType.
- Scrivere la presentazione modificata come file PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtShape-CreateSmartArtShape.cpp" >}}


## **Accedere a una forma SmartArt su una diapositiva**
Il codice seguente viene utilizzato per accedere alle forme SmartArt aggiunte nella diapositiva della presentazione. Nel codice di esempio attraverseremo ogni forma all’interno della diapositiva e verificheremo se è una forma SmartArt. Se la forma è di tipo SmartArt, la casteremo a istanza SmartArt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtShape-AccessSmartArtShape.cpp" >}}

## **Accedere a una forma SmartArt con un tipo di layout particolare**
Il codice di esempio seguente aiuta ad accedere alla forma SmartArt con un LayoutType specifico. Si noti che non è possibile modificare il LayoutType di SmartArt poiché è di sola lettura e viene impostato solo quando la forma SmartArt viene aggiunta.

- Creare un’istanza della classe `Presentation` e caricare la presentazione con la forma SmartArt.
- Ottenere il riferimento della prima diapositiva utilizzando il suo indice.
- Attraversare ogni forma all’interno della prima diapositiva.
- Verificare se la forma è di tipo SmartArt e castare la forma selezionata a SmartArt se è SmartArt.
- Controllare la forma SmartArt con il LayoutType specifico ed eseguire le operazioni necessarie successivamente.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cpp" >}}


## **Modificare lo stile di una forma SmartArt**
Il codice di esempio seguente aiuta ad accedere alla forma SmartArt con un LayoutType particolare.

- Creare un’istanza della classe `Presentation` e caricare la presentazione con la forma SmartArt.
- Ottenere il riferimento della prima diapositiva utilizzando il suo indice.
- Attraversare ogni forma all’interno della prima diapositiva.
- Verificare se la forma è di tipo SmartArt e castare la forma selezionata a SmartArt se è SmartArt.
- Trovare la forma SmartArt con lo stile specifico.
- Impostare il nuovo stile per la forma SmartArt.
- Salvare la presentazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cpp" >}}


## **Modificare lo stile colore di una forma SmartArt**
In questo esempio, impareremo a cambiare lo stile colore per qualsiasi forma SmartArt. Nel codice di esempio seguente verrà acceduta la forma SmartArt con uno stile colore particolare e ne verrà modificato lo stile.

- Creare un’istanza della classe `Presentation` e caricare la presentazione con la forma SmartArt.
- Ottenere il riferimento della prima diapositiva utilizzando il suo indice.
- Attraversare ogni forma all’interno della prima diapositiva.
- Verificare se la forma è di tipo SmartArt e castare la forma selezionata a SmartArt se è SmartArt.
- Trovare la forma SmartArt con lo stile colore specifico.
- Impostare il nuovo stile colore per la forma SmartArt.
- Salvare la presentazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cpp" >}}

## **FAQ**

**Posso animare SmartArt come un unico oggetto?**

Sì. SmartArt è una forma, quindi è possibile applicare [animazioni standard](/slides/it/cpp/powerpoint-animation/) tramite l’API delle animazioni (entrata, uscita, enfasi, percorsi di movimento) proprio come per le altre forme.

**Come posso trovare uno SmartArt specifico su una diapositiva se non ne conosco l’ID interno?**

Impostare e utilizzare il Testo alternativo (AltText) e cercare la forma in base a quel valore: è il metodo consigliato per individuare la forma desiderata.

**Posso raggruppare SmartArt con altre forme?**

Sì. È possibile raggruppare SmartArt con altre forme (immagini, tabelle, ecc.) e poi [manipolare il gruppo](/slides/it/cpp/group/).

**Come ottengo un’immagine di uno SmartArt specifico (ad es., per un’anteprima o un rapporto)?**

Esportare una miniatura/immagine della forma; la libreria può [renderizzare forme individuali](/slides/it/cpp/create-shape-thumbnails/) in file raster (PNG/JPG/TIFF).

**L’aspetto di SmartArt verrà preservato quando si converte l’intera presentazione in PDF?**

Sì. Il motore di rendering punta a un’elevata fedeltà per l’[esportazione PDF](/slides/it/cpp/convert-powerpoint-to-pdf/), con una gamma di opzioni di qualità e compatibilità.