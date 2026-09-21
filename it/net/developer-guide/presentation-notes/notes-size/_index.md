---
title: Modifica dimensione e orientamento della pagina delle note in .NET
linktitle: Dimensione pagina note
type: docs
weight: 10
url: /it/net/notes-size/
keywords:
- dimensione pagina note
- orientamento note
- note in orizzontale
- note in verticale
- dimensione foglio illustrativo
- PowerPoint
- presentazione
- PPT
- PPTX
- C#
- Aspose.Slides
description: "Leggi e modifica le dimensioni della pagina delle note in Aspose.Slides per .NET, cambia l'orientamento, verifica le dimensioni salvate e esporta note o fogli illustrativi in PDF e immagini."
---
## **Panoramica**

Utilizza [Presentation.NotesSize](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/notessize/) per accedere alle impostazioni della pagina delle note della presentazione. Restituisce un oggetto [INotesSize](https://reference.aspose.com/slides/it/net/aspose.slides/inotessize/) il cui proprietà [Size](https://reference.aspose.com/slides/it/net/aspose.slides/inotessize/size/) è scrivibile. Sebbene l'oggetto delle impostazioni sia di sola lettura, è possibile assegnare nuove dimensioni alla proprietà size.

Larghezza e altezza sono specificate in **punti**, con 72 punti per pollice. Ad esempio, 900 × 600 punti corrispondono a 12,5 × 8⅓ pollici. Queste impostazioni si applicano alla presentazione, anziché alle note di una singola diapositiva.

| Impostazione | Scopo |
| --- | --- |
| [Presentation.NotesSize](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/notessize/) | Controlla le dimensioni della pagina delle note e le dimensioni della pagina usate per l'esportazione dei fogli illustrativi. |
| [Presentation.SlideSize](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/slidesize/) | Controlla le dimensioni standard delle diapositive della presentazione tramite [ISlideSize](https://reference.aspose.com/slides/it/net/aspose.slides/islidesize/). |

Modificare una delle impostazioni non cambia automaticamente l'altra. Cambiare l'orientamento della pagina delle note non ruota nemmeno le diapositive standard. Vedi [Slide Size](/slides/it/net/slide-size/) per ridimensionare le diapositive standard.

Gli esempi seguenti utilizzano un file `sample.pptx` esistente. Per gli esempi di esportazione, usa una presentazione con almeno una diapositiva che contiene note del relatore. Ogni esempio può essere eseguito in modo indipendente.

## **Leggi le dimensioni e l'orientamento della pagina delle note**

Leggi larghezza e altezza e confrontale per determinare l'orientamento: una pagina più larga è orizzontale, una più alta è verticale, e dimensioni uguali descrivono una pagina quadrata. Questo esempio stampa le dimensioni effettive in punti, senza assumere una dimensione di carta standard.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;
var orientation = "Square";

if (size.Width > size.Height)
    orientation = "Landscape";
else if (size.Width < size.Height)
    orientation = "Portrait";

Console.WriteLine($"Notes page: {size.Width} x {size.Height} points");
Console.WriteLine($"Orientation: {orientation}");
```

## **Passa al formato orizzontale senza modificare le dimensioni della carta**

Per cambiare solo l'orientamento, scambia la larghezza e l'altezza esistenti. Questo preserva le lunghezze di entrambi i lati, comprese quelle di una dimensione di carta personalizzata. La condizione sottostante impedisce a una pagina già orizzontale di tornare in verticale e lascia invariata una pagina quadrata.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;

if (size.Width < size.Height)
    presentation.NotesSize.Size = new SizeF(size.Height, size.Width);

presentation.Save("landscape-notes.pptx", SaveFormat.Pptx);
```

Per l'orientamento verticale, usa la stessa assegnazione quando `size.Width > size.Height`. Non sostituire le dimensioni di A4 o Letter a meno che tu non voglia anche modificare la dimensione della carta.

## **Imposta e verifica una dimensione personalizzata della pagina delle note**

Assegna entrambe le dimensioni insieme, quindi usa [Presentation.Save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/save/) per scrivere la presentazione. Questo esempio imposta una pagina orizzontale di 900 × 600 punti, la salva come PPTX e apre nuovamente il file salvato per controllare i valori persistiti. Il confronto consente una tolleranza di 0,01 punti per i valori a virgola mobile; non è una garanzia di precisione per ogni formato di file.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var expectedSize = new SizeF(900, 600);
presentation.NotesSize.Size = expectedSize;
presentation.Save("custom-notes.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom-notes.pptx");
var actualSize = reopened.NotesSize.Size;
var widthMatches = Math.Abs(actualSize.Width - expectedSize.Width) < 0.01f;
var heightMatches = Math.Abs(actualSize.Height - expectedSize.Height) < 0.01f;
var preserved = widthMatches && heightMatches;

Console.WriteLine($"Stored notes page: {actualSize.Width} x {actualSize.Height} points");
Console.WriteLine($"Size preserved: {preserved}");
```

Il risultato atteso è `900 x 600 points` e `Size preserved: True`. Controllare una presentazione appena aperta verifica il file salvato, anziché solo le impostazioni in memoria.

## **Esporta note e fogli illustrativi**

Le dimensioni della pagina definiscono l'area disponibile per i layout di note o di fogli illustrativi. Non abilitano questi layout da sole: configura anche le opzioni di esportazione. L'esportazione delle diapositive standard continua a usare le dimensioni della diapositiva.

### **Esporta note in PDF e PNG**

Assegna [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/notescommentslayoutingoptions/) a [PdfOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/pdfoptions/slideslayoutoptions/) per includere le note nel PDF. Questo esempio rende anche la prima diapositiva con note in PNG usando [Slide.GetImage](https://reference.aspose.com/slides/it/net/aspose.slides/slide/getimage/) e [RenderingOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/renderingoptions/).

La modalità [BottomTruncated](https://reference.aspose.com/slides/it/net/aspose.slides.export/notespositions/) mantiene le note su una sola pagina; le note che non entrano possono essere troncate. Il PDF utilizza pagine di 900 × 600 punti. Alla scala dell'immagine di 1 × 1 usata di seguito, il PNG è 900 × 600 pixel. I punti descrivono la geometria della pagina; i pixel descrivono l'output raster, le cui dimensioni dipendono anche dalla scala di rendering.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("notes.pdf", SaveFormat.Pdf, pdfOptions);

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layout };
using var image = presentation.Slides[0].GetImage(renderingOptions, 1, 1);
image.Save("first-slide-notes.png", ImageFormat.Png);
```

Per l'esportazione PDF con note lunghe, [BottomFull](https://reference.aspose.com/slides/it/net/aspose.slides.export/notespositions/) consente pagine aggiuntive secondo necessità. Non usare quella modalità con la chiamata immagine a diapositiva singola sopra, che non la supporta. Dopo aver ridimensionato, ispeziona l'output per note tagliate e la posizione degli oggetti master delle note esistenti; cambiare solo le dimensioni della pagina non dovrebbe essere considerato una garanzia che tutti i contenuti si adattino. Vedi [Convert PowerPoint to PDF with Notes](/slides/it/net/convert-powerpoint-to-pdf-with-notes/) per ulteriori informazioni sull'esportazione delle note.

### **Esporta i fogli illustrativi in PDF**

Usa [HandoutLayoutingOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/handoutlayoutingoptions/) per più miniature di diapositive su una pagina. L'esempio seguente imposta una pagina di 900 × 600 punti e utilizza [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/it/net/aspose.slides.export/handouttype/) per disporre fino a quattro diapositive per pagina. Il predefinito orizzontale controlla l'ordine delle diapositive; l'orientamento della pagina deriva dalla sua larghezza e altezza.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new HandoutLayoutingOptions
{
    Handout = HandoutType.Handouts4Horizontal
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
```

Modificare la dimensione della pagina cambia l'area disponibile per la griglia del foglio illustrativo senza modificare le dimensioni delle diapositive di origine. Per le immagini dei fogli illustrativi, usa [Presentation.GetImages](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/getimages/) con il layout del foglio illustrativo, anziché il metodo immagine di una singola diapositiva. In Aspose.Slides, il rendering dei fogli illustrativi a livello di presentazione utilizza le dimensioni della pagina delle note, mentre la chiamata immagine di diapositiva individuale non produce la pagina del foglio illustrativo. Vedi [Handout Mode](/slides/it/net/convert-powerpoint-in-handout-mode/) per le opzioni di layout.

## **Dimensione della pagina in visualizzatori, esportazione e stampa**

Mantieni distinte la dimensione della presentazione archiviata, la dimensione della pagina esportata e la dimensione della carta stampata:

- **Visualizzatori di presentazione:** Un visualizzatore può visualizzare o stampare le note usando le proprie regole di layout. Se un'altra applicazione salva il file, riaprilo e controlla nuovamente le dimensioni; la conversione di formato di quell'applicazione potrebbe normalizzarle.
- **Formati di esportazione:** Gli esempi PDF di note e fogli illustrativi sopra usano le dimensioni della pagina configurate. Le immagini raster usano dimensioni intere di pixel e una scala di rendering, quindi i valori frazionari dei punti possono essere arrotondati nell'output immagine. L'esportazione delle diapositive regolari non applica la dimensione della pagina delle note.
- **Driver di stampa:** La selezione della carta, la rotazione automatica e le impostazioni di adattamento alla pagina possono modificare l'output fisico senza cambiare le dimensioni archiviate nella presentazione o nel PDF. Per una dimensione di carta specifica, imposta le opzioni della stampante e ispeziona l'anteprima di stampa.

## **FAQ**

**Posso impostare le dimensioni delle note per una sola diapositiva?**

Le dimensioni della pagina delle note sono un'impostazione a livello di presentazione. Le singole diapositive possono avere contenuti di note diversi, ma questa proprietà non fornisce una dimensione di pagina separata per ciascuna diapositiva.

**Perché cambiare l'orientamento delle note non ha modificato le mie diapositive?**

Le pagine delle note e le diapositive regolari hanno dimensioni indipendenti. Usa le impostazioni di dimensione delle diapositive regolari quando vuoi ridimensionare le diapositive stesse.

**Perché il risultato salvato o stampato ha una dimensione diversa?**

Riapri prima la presentazione salvata e confronta le sue dimensioni delle note. Se sono cambiate, verifica se il salvataggio o la conversione del file in un'altra applicazione ha modificato le impostazioni della pagina. Se non l'hanno fatto, controlla il layout di esportazione, la scala dell'immagine, le impostazioni del visualizzatore e la selezione della carta della stampante.