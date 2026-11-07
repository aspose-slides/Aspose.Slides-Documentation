---
title: Operazioni di Presentazione Low-Code in .NET
linktitle: API Low-Code
type: docs
weight: 50
url: /it/net/low-code-presentation-operations/
keywords:
- API presentazione low-code
- convertire presentazione
- unire presentazioni
- iterare diapositive
- iterare forme
- iterare testo
- raccogliere forme
- comprimere presentazione
- rimuovere master diapositive inutilizzati
- rimuovere layout diapositive inutilizzati
- comprimere font incorporati
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Utilizza l'API low-code di Aspose.Slides in .NET per convertire e unire presentazioni, iterare il contenuto, raccogliere forme e ridurre le dimensioni della presentazione."
---
## **Panoramica**

Il namespace [Aspose.Slides.LowCode](https://reference.aspose.com/slides/net/aspose.slides.lowcode/) fornisce classi helper statiche per operazioni comuni su presentazioni. Questi helper avvolgono i flussi di lavoro più frequenti del modello di oggetti in metodi mirati, così è possibile convertire o unire file, elaborare gli elementi della presentazione, raccogliere forme e rimuovere contenuti inutilizzati con meno codice.

I helper low‑code sono più utili quando l’operazione si applica a un intero file o a una presentazione e il flusso di lavoro predefinito corrisponde alle tue esigenze. Usa il modello di oggetti completo di [Aspose.Slides](https://reference.aspose.com/slides/net/aspose.slides/) quando hai bisogno di un controllo dettagliato su singole diapositive, master, layout, forme, impostazioni di esportazione o relazioni tra gli elementi della presentazione.

La tabella seguente riassume gli helper disponibili:

| Helper | Scopo |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) | Convertire una presentazione in un altro formato con una chiamata file‑a‑file. |
| [Merger](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/) | Unire file di presentazione completi dello stesso formato. |
| [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) | Eseguire un’azione per ogni diapositiva, forma, paragrafo o porzione di testo. |
| [Collect](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/) | Recuperare le forme dall’intera presentazione per elaborazioni o analisi ripetute. |
| [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) | Rimuovere master/layout inutilizzati, ridurre i dati dei font incorporati e comprimere le immagini. |

## **Convertire una presentazione**

Utilizza [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/) quando l’estensione del file di output è sufficiente a selezionare il formato di esportazione. Il metodo apre la presentazione di origine, determina il formato richiesto dal percorso di output e scrive il risultato.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

La classe [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) fornisce anche metodi dedicati per output PDF, SVG, JPEG, PNG e TIFF. Usa il modello di oggetti completo quando devi ispezionare o modificare la presentazione prima dell’esportazione o configurare un’opzione di esportazione non esposta dall’helper selezionato. Vedi [Convert Presentation](/slides/it/net/convert-presentation/) per flussi di lavoro e opzioni specifici per formato.

## **Unire presentazioni**

Usa [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) per combinare file di presentazione completi con una sola chiamata. Le presentazioni di input devono avere lo stesso formato di file.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

L’helper è appropriato quando tutte le diapositive devono essere aggiunte a un risultato unico senza selezionarle o rimapparle individualmente. Usa il modello di oggetti completo quando devi unire diapositive selezionate, applicare un master o layout di destinazione, preservare sezioni in modo esplicito o conciliare dimensioni di diapositive diverse. Vedi [Merge Presentations](/slides/it/net/merge-presentation/) per questi scenari.

## **Iterare attraverso gli elementi della presentazione**

La classe [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) invoca un callback per ogni tipo richiesto di elemento della presentazione. Evita cicli di raccolta annidati ed è comoda per ispezioni o modifiche di formattazione a livello di presentazione.

L’esempio seguente utilizza [ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/) e [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) per ispezionare gli elementi corrispondenti:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

ForEach.Slide(presentation, (slide, index) =>
{
    Console.WriteLine($"Slide {index}: {slide.Shapes.Count} shapes");
});

ForEach.Shape(presentation, (shape, slide, index) =>
{
    Console.WriteLine($"Shape {index} on {slide.GetType().Name}: {shape.Name}");
});

ForEach.Paragraph(presentation, (paragraph, slide, index) =>
{
    Console.WriteLine($"Paragraph {index} on {slide.GetType().Name}: {paragraph.Text}");
});

ForEach.Portion(presentation, (portion, paragraph, slide, index) =>
{
    Console.WriteLine($"Portion {index} on {slide.GetType().Name}: {portion.Text}");
});
```

Per impostazione predefinita, l’attraversamento di forme e testo a livello di presentazione include diapositive normali, master e layout. Le versioni con un parametro `includeNotes` possono anche elaborare le diapositive delle note. Usa cicli di raccolta diretti quando l’ordine di attraversamento, l’uscita anticipata, il filtraggio prima della chiamata del callback o il controllo dettagliato genitore‑figlio sono importanti.

## **Raccogliere forme**

Usa [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) quando ti serve una collezione di tutte le forme in una presentazione anziché un callback per ogni forma. È utile quando lo stesso set verrà filtrato, contato o elaborato più volte.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
var shapes = Collect.Shapes(presentation);

foreach (var shape in shapes)
{
    Console.WriteLine($"{shape.Name}: {shape.GetType().Name}");
}
```

Utilizza [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) invece quando ogni forma può essere gestita immediatamente e non è necessario conservare il risultato raccolto.

## **Comprimere il contenuto della presentazione**

La classe [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) può rimuovere elementi strutturali inutilizzati e ridurre i dati dei font incorporati:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) rimuove le diapositive di layout a cui nessuna diapositiva normale fa riferimento.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) rimuove i master non più utilizzati.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) rimuove i caratteri inutilizzati dai font incorporati.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
Compress.RemoveUnusedMasterSlides(presentation);
Compress.CompressEmbeddedFonts(presentation);

presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

Rimuovi i layout inutilizzati prima dei master inutilizzati, così un master che diventa non referenziato dopo la pulizia dei layout può essere rimosso. Salva la presentazione ottimizzata in un nuovo file se potresti aver bisogno in seguito dei master, dei layout originali o dei dati completi dei font incorporati. Per maggiori dettagli, vedi [Slide Master](/slides/it/net/slide-master/) e [Embedded Font](/slides/it/net/embedded-font/).

### **Comprimere l'intera presentazione**

Aspose.Slides for .NET 26.11 aggiunge [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/). Combina la rimozione di layout/master inutilizzati, il subset dei font incorporati ai caratteri utilizzati e la compressione delle immagini a 150 DPI. Usa le operazioni individuali sopra quando devi controllare quali modifiche sono applicate.

Installa [Aspose.Slides for .NET](/slides/it/net/installation/) 26.11 o versioni successive e fornisci `input.pptx`. Salva in un file separato: layout rimossi, caratteri dei font e pixel delle immagini ritagliate potrebbero essere necessari per modifiche successive.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

### **Comprimere le immagini a una risoluzione scelta**

Usa [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/) per elaborare le immagini idonee senza rimuovere layout o ridurre i font. Questo esempio utilizza 96 DPI; seleziona un altro valore di [PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) per le esigenze di output.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressImages(presentation, PicturesCompression.Dpi96);
presentation.Save("compressed-images.pptx", SaveFormat.Pptx);
```

Entrambi gli helper usano il seguente ambito di elaborazione delle immagini:

| Contenuto | Trattamento |
| --- | --- |
| Immagini raster e riempimenti di forma con immagine su diapositive normali, master e layout, incluse forme raggruppate | Idonee per compressione. |
| Immagini già alla risoluzione richiesta o inferiore | Non ingrandite. Le aree ritagliate possono comunque essere rimosse. |
| Aree di immagine ritagliate | I pixel nascosti sono rimossi definitivamente e gli offset di ritaglio vengono azzerati. |
| Sfondi delle diapositive e riempimenti di celle di tabella | Non elaborate da questi helper. |
| Interni di grafici/SmartArt, GIF e formati vettoriali come SVG, EMF e WMF | Fuori dall’ambito documentato di compressione delle immagini. |

Nella versione 26.11, [PicturesCompression.DocumentResolution](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) evita il downsampling basato sulla risoluzione di un’immagine non ritagliata, ma **non preserva i pixel ritagliati**. Un’immagine ritagliata può comunque essere riscritta con le aree nascoste rimosse. Nessuno dei due helper espone un’opzione per preservare il ritaglio. Per un controllo individuale, vedi l’[esempio di compressione per immagine](/slides/it/net/examples/optimization-batch/compression/).

Confronta l’aspetto e la dimensione del file risultante prima di sostituire l’originale. I risparmi dipendono dalle immagini di origine, dalla loro dimensione visualizzata e dal contenuto inutilizzato; la compressione non garantisce un file più piccolo. Vedi [Embedded Fonts](/slides/it/net/embedded-font/) per le implicazioni del subset dei font.

## **FAQ**

**Quando dovrei usare l’API low‑code invece del modello di oggetti completo?**

Usa gli helper low‑code quando un’operazione standard si applica a un file o a una presentazione completa e non richiede un controllo dettagliato su elementi singoli. Usa il modello di oggetti completo quando devi selezionare diapositive specifiche, controllare le relazioni tra master e layout, ispezionare lo stato intermedio o configurare un comportamento non esposto dall’helper.

**Il Merger può combinare presentazioni in formati di file diversi?**

No. [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) richiede che le presentazioni di input siano nello stesso formato. Convertili prima in un formato comune, ad esempio con [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/), e quindi unisci i file convertiti.

**Il ForEach elabora le diapositive master, layout e di note?**

[ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/) itera sulle diapositive normali della presentazione. Le operazioni a livello di presentazione di [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/) e [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) includono diapositive normali, master e layout per impostazione predefinita. Usa le loro versioni con `includeNotes` impostato a `true` per includere le diapositive delle note.

**Qual è la differenza tra ForEach.Shape e Collect.Shapes?**

Usa [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) per elaborare ogni forma immediatamente tramite un callback. Usa [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) quando ti serve un risultato enumerabile che può essere conservato, filtrato, contato o attraversato più volte.

**Compress rende sempre il file della presentazione più piccolo?**

Non necessariamente. Il risparmio dipende da layout/master inutilizzati, font incorporati con caratteri non usati e immagini che beneficiano della compressione. Gli helper [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) possono lasciare la dimensione invariata o produrre un file più grande per alcuni input. Confronta sia la dimensione sia la qualità resa e conserva l’originale.

**Le modifiche apportate da ForEach o Compress vengono salvate automaticamente?**

No. Questi helper operano sull’oggetto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) caricato in memoria. Dopo aver modificato gli elementi in un callback di [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) o aver eseguito [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/), chiama [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) per scrivere il risultato.

## **Articoli correlati**

- [Convert Presentation](/slides/it/net/convert-presentation/)
- [Merge Presentations](/slides/it/net/merge-presentation/)
- [Slide Master](/slides/it/net/slide-master/)
- [Manage Text Box](/slides/it/net/manage-textbox/)
- [Embedded Font](/slides/it/net/embedded-font/)