---
title: Comprimi le presentazioni
description: Riduci le dimensioni della presentazione con la compressione delle immagini e salva le impostazioni.
type: docs
url: /it/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/image/
---
## **Panoramica**

Comprimi le immagini, rimuovi le aree ritagliate quando non sono più necessarie e scegli le impostazioni di compressione della presentazione prima di salvare. Questo è utile per presentazioni con fotografie di grandi dimensioni o media ripetuti. La quantità risparmiata dipende dal contenuto e dalle impostazioni scelte.

## **Esempio di utilizzo**

Questo esempio C# utilizza Aspose.Slides per .NET. Genera visibilmente un PNG a gradiente di 1600 × 900 pixel, lo inserisce in una piccola cornice immagine e salva *before.pptx*. Poi comprime quell'immagine a una risoluzione target di 96 DPI e salva *compressed.pptx*. Confronta le dimensioni dei file e le anteprime: il risparmio dipende dall'immagine di input e dalla dimensione visualizzata.

Per la configurazione, vedi [Installa Aspose.Slides per .NET](/slides/it/net/installation/).

```csharp
using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var bitmap = new Bitmap(1600, 900))
{
    for (var y = 0; y < bitmap.Height; y++)
        for (var x = 0; x < bitmap.Width; x++)
            bitmap.SetPixel(x, y, Color.FromArgb(x % 256, y % 256, (x + y) % 256));
    bitmap.Save("large.png", System.Drawing.Imaging.ImageFormat.Png);
}
using var presentation = new Presentation();
var title = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 500, 60);
title.TextFrame.Text = "Photo";
var bytes = File.ReadAllBytes("large.png");
var image = presentation.Images.AddImage(bytes);
var picture = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 40, 120, 240, 135, image);
presentation.Save("before.pptx", SaveFormat.Pptx);
var compressed = picture.PictureFormat.CompressImage(true, 96f);
Console.WriteLine($"Picture compressed: {compressed}");
presentation.Save("compressed.pptx", SaveFormat.Pptx);
using var preview = presentation.Slides[0].GetImage(1f, 1f);
preview.Save("compressed.png", ImageFormat.Png);
```

## **Domande frequenti**

### **È questa un'unica opzione di ottimizzazione per l'intero file?**

Aspose.Slides per .NET 26.11 aggiunge [Compress.CompressPresentation](/slides/it/net/low-code-presentation-operations/#compress-the-whole-presentation), che combina la rimozione di layout/master inutilizzati, il subset dei font incorporati e la compressione delle immagini a 150 DPI. Rimuove permanentemente le aree ritagliate delle immagini. Per l'elaborazione solo delle immagini, usa Compress.CompressImages; per un controllo più fine, mantieni il flusso di lavoro per immagine sopra. Questi nuovi helper sono specifici per la versione .NET indicata; verifica la guida corrispondente per altri SDK.

### **La compressione delle immagini modifica il testo modificabile o i grafici?**

La compressione delle immagini riguarda i dati delle immagini, non il testo modificabile o i dati dei grafici. Controlla le immagini perché il ridimensionamento o la ricompressione possono ridurne i dettagli.

### **Come dovrei scegliere una risoluzione per le immagini della presentazione?**

Scegli un target in base alle dimensioni visualizzate dell'immagine e all'uso previsto su schermo o stampa. Mantieni una risoluzione più alta per schermi grandi, stampa e diagrammi dettagliati, e confronta l'output renderizzato prima di eliminare l'originale.

## **Guide**

- [Ottimizza la gestione delle immagini nelle presentazioni in .NET](/slides/it/net/image/)

Funzionalità correlata: [Rimuovi master, layout e media inutilizzati](/slides/it/features/remove-unused-content/).

## Esempi .NET eseguibili

- [Riduci le dimensioni della presentazione](/slides/it/net/examples/optimization-batch/compression/)