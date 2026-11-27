---
title: Comprimi le presentazioni
description: Riduci le dimensioni della presentazione comprimendo le immagini e rimuovendo i contenuti inutilizzati.
type: docs
url: /it/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **Panoramica**

Comprimi le immagini, rimuovi le aree ritagliate quando non sono più necessarie e scegli le impostazioni di compressione della presentazione prima di salvare. È utile per presentazioni con foto di grandi dimensioni o media ripetuti. La quantità di spazio risparmiata dipende dal contenuto e dalle impostazioni scelte.

## **Esempio di utilizzo**

Questo esempio C# carica `input.pptx`, comprime la presentazione e la salva come `compressed.pptx`.

Utilizza Aspose.Slides per .NET 26.11 o versioni successive. Per la configurazione, consulta [Installa Aspose.Slides per .NET](/slides/it/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```


<!-- visual-explanation:compress-presentations:start -->
[![Rendering di immagini scalate identicamente prima e dopo la compressione, seguiti da barre di dimensione del file PPTX misurate e dalle dimensioni dell'immagine memorizzata.](visual-compress-presentations-1adbf86268a5.svg)](visual-compress-presentations-1adbf86268a5.svg)

*Misurato su una singola fixture di griglia di dettaglio sintetica: 584.030 → 128.323 byte. Entrambi i rendering usano la stessa scala e un fotogramma di 252 × 336 punti. La compressione rimuove i margini ritagliati e riduce l'immagine memorizzata a 525 × 700 pixel; il risparmio di spazio dipende dall'input.* 
<!-- visual-explanation:compress-presentations:end -->

## **FAQ**

### **È questa una singola opzione di ottimizzazione dell'intero file?**

Aspose.Slides per .NET 26.11 aggiunge [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/), che combina la rimozione di layout/master inutilizzati, il sottoinsieme di font incorporati e la compressione delle immagini a 150 DPI. Rimuove in modo permanente le aree ritagliate delle immagini. Per l'elaborazione solo di immagini, usa [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); per un controllo più fine, vedi [esempio di compressione di immagine individuale](/slides/it/net/examples/optimization-batch/compression/). Dalla versione 26.11, la stessa chiamata per l'intera presentazione è disponibile anche in Java, Node.js via Java, Python via .NET e C++. L'esempio e i collegamenti su questa pagina sono per .NET.

### **La compressione delle immagini modifica il testo o i grafici modificabili?**

La compressione delle immagini agisce sui dati delle immagini, non sul testo modificabile o sui dati dei grafici. Controlla le immagini perché il ridimensionamento o la ricompressione possono ridurne i dettagli.

### **Come dovrei scegliere la risoluzione per le immagini della presentazione?**

Scegli un valore target in base alle dimensioni dell'immagine visualizzata e all'uso previsto su schermo o stampa. Mantieni maggiore risoluzione per schermi grandi, stampe e diagrammi dettagliati, e confronta l'output renderizzato prima di scartare l'originale.

## **Guide**

- [Comprimi l'intera presentazione in .NET](/slides/it/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [Ottimizza la gestione delle immagini nelle presentazioni in .NET](/slides/it/net/image/)

Funzionalità correlata: [Rimuovi master, layout e media inutilizzati](/slides/it/features/remove-unused-content/).

## Esempi .NET eseguibili

- [Riduci la dimensione della presentazione](/slides/it/net/examples/optimization-batch/compression/)