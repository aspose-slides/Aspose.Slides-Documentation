---
title: Comprimi le presentazioni
description: Riduci le dimensioni della presentazione comprimendo le immagini e rimuovendo i contenuti non utilizzati.
type: docs
url: /it/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operazioni
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **Panoramica**

Comprimi le immagini, rimuovi le aree ritagliate quando non sono più necessarie e scegli le impostazioni di compressione della presentazione prima di salvare. Questo è utile per presentazioni con foto di grandi dimensioni o media ripetuti. La quantità risparmiata dipende dal contenuto e dalle impostazioni scelte.

## **Esempio di utilizzo**

Questo esempio C# carica `input.pptx`, comprime la presentazione e la salva come `compressed.pptx`.

Usa Aspose.Slides per .NET 26.11 o versioni successive. Per la configurazione, vedi [Installa Aspose.Slides per .NET](/slides/it/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Questo è un interruttore di ottimizzazione per l'intero file?**

Aspose.Slides per .NET 26.11 aggiunge [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/), che combina la rimozione di layout/master non utilizzati, il sottoinsieme di caratteri incorporati e la compressione delle immagini a 150 DPI. Rimuove in modo permanente le aree ritagliate delle immagini. Per l'elaborazione solo immagini, usa [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); per un controllo più preciso, consulta l'[esempio di compressione di immagine singola](/slides/it/net/examples/optimization-batch/compression/). Questi nuovi helper sono specifici per la versione .NET indicata; verifica la guida corrispondente per altri SDK.

### **La compressione delle immagini modifica il testo modificabile o i grafici?**

La compressione delle immagini mira ai dati delle immagini, non al testo modificabile o ai dati dei grafici. Controlla le immagini perché il ridimensionamento o la ricompressione possono ridurne i dettagli.

### **Come devo scegliere una risoluzione per le immagini della presentazione?**

Scegli un valore target in base alle dimensioni dell'immagine visualizzata e all'uso previsto su schermo o stampa. Mantieni una maggiore risoluzione per schermi grandi, stampa e diagrammi dettagliati, e confronta l'output renderizzato prima di eliminare l'originale.

## **Guide**

- [Comprimi l'intera presentazione in .NET](/slides/it/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [Ottimizza la gestione delle immagini nelle presentazioni in .NET](/slides/it/net/image/)

Funzionalità correlata: [Rimuovi master, layout e media inutilizzati](/slides/it/features/remove-unused-content/).

## Esempi .NET eseguibili

- [Riduci le dimensioni della presentazione](/slides/it/net/examples/optimization-batch/compression/)