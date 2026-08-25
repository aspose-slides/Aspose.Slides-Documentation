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
- iterare slide
- iterare forme
- iterare testo
- raccogliere forme
- comprimere presentazione
- rimuovere master slide inutilizzati
- rimuovere layout slide inutilizzati
- comprimere font incorporati
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Usa l'API low-code di Aspose.Slides in .NET per convertire e unire presentazioni, iterare tra i contenuti, raccogliere forme e ridurre le dimensioni della presentazione."
---
## **Panoramica**

Lo spazio dei nomi [Aspose.Slides.LowCode](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/) fornisce classi helper statiche per operazioni comuni sulle presentazioni. Queste helper incapsulano flussi di lavoro del modello oggetto frequentemente usati in metodi specifici, così è possibile convertire o unire file, elaborare elementi della presentazione, raccogliere forme e rimuovere contenuti inutilizzati con meno codice.

Le helper low-code sono più utili quando l'operazione si applica a un intero file o presentazione e il flusso di lavoro predefinito soddisfa i requisiti. Utilizza l'intero [Aspose.Slides object model](https://reference.aspose.com/slides/it/net/aspose.slides/) quando è necessario un controllo dettagliato su slide individuali, master, layout, forme, impostazioni di esportazione o relazioni tra gli elementi della presentazione.

La tabella seguente riepiloga le helper disponibili:

| Helper | Use it for |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/convert/) | Convertire una presentazione in un altro formato con una chiamata diretta file‑a‑file. |
| [Merger](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/merger/) | Combinare file di presentazione completi dello stesso formato. |
| [ForEach](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/foreach/) | Eseguire un'azione per ogni slide, forma, paragrafo o porzione di testo. |
| [Collect](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/collect/) | Recuperare le forme dall'intera presentazione per elaborazioni o analisi ripetute. |
| [Compress](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/compress/) | Rimuovere master e layout inutilizzati e ridurre i dati dei caratteri incorporati. |

## **Convertire una Presentazione**

Utilizza [Convert.AutoByExtension](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/convert/autobyextension/) quando l'estensione del file di output è sufficiente per selezionare il formato di esportazione. Il metodo apre la presentazione di origine, determina il formato richiesto dal percorso di output e scrive il risultato.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

La classe [Convert](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/convert/) fornisce anche metodi dedicati per l'output PDF, SVG, JPEG, PNG e TIFF. Utilizza l'intero modello oggetto quando è necessario ispezionare o modificare la presentazione prima dell'esportazione o configurare un'opzione di esportazione non esposta dalla helper selezionata. Vedi [Convert Presentation](/slides/it/net/convert-presentation/) per flussi di lavoro e opzioni specifiche per formato.

## **Unire le Presentazioni**

Utilizza [Merger.Process](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/merger/process/) per combinare file di presentazione completi con una sola chiamata. Le presentazioni di input devono avere lo stesso formato di file.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

La helper è appropriata quando tutte le slide devono essere aggiunte a un unico risultato senza selezionarle o rimapparle singolarmente. Utilizza l'intero modello oggetto quando è necessario unire slide selezionate, applicare un master o layout di destinazione, preservare esplicitamente le sezioni o conciliare dimensioni di slide diverse. Vedi [Merge Presentations](/slides/it/net/merge-presentation/) per questi scenari.

## **Iterare Attraverso gli Elementi della Presentazione**

La classe [ForEach](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/foreach/) invoca una callback per ogni tipo richiesto di elemento della presentazione. Evita i cicli annidati sulle collezioni ed è comoda per ispezioni o modifiche di formattazione a livello di presentazione.

L'esempio seguente utilizza [ForEach.Slide](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/foreach/paragraph/), e [ForEach.Portion](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/foreach/portion/) per ispezionare gli elementi corrispondenti:

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

Per impostazione predefinita, l'attraversamento di forme e testo a livello di presentazione include slide normali, master e layout. Le overload con un parametro `includeNotes` possono anche elaborare le slide delle note. Utilizza cicli di collezione diretti quando l'ordine di attraversamento, l'uscita anticipata, il filtraggio prima della chiamata della callback o il controllo dettagliato genitore‑figlio è importante.

## **Raccogliere Forme**

Utilizza [Collect.Shapes](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/collect/shapes/) quando ti serve una collezione di tutte le forme in una presentazione invece di una callback per ogni forma. È utile quando lo stesso insieme sarà filtrato, contato o elaborato più volte.

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

Usa invece [ForEach.Shape](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/foreach/shape/) quando ogni forma può essere gestita immediatamente e non è necessario conservare il risultato raccolto.

## **Comprimere il Contenuto della Presentazione**

La classe [Compress](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/compress/) può rimuovere elementi strutturali inutilizzati e ridurre i dati dei caratteri incorporati:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) rimuove le slide di layout che nessuna slide normale fa riferimento.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) rimuove i master slide che non sono più utilizzati.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/compress/compressembeddedfonts/) rimuove i caratteri inutilizzati dai font incorporati.

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

Rimuovi i layout inutilizzati prima dei master inutilizzati in modo che un master che diventa non referenziato dopo la pulizia dei layout possa essere rimosso. Salva la presentazione ottimizzata in un nuovo file se potresti aver bisogno più tardi dei master, dei layout originali o dei dati completi dei font incorporati. Per maggiori dettagli, vedi [Slide Master](/slides/it/net/slide-master/) e [Embedded Font](/slides/it/net/embedded-font/).

## **FAQ**

**Quando dovrei usare l'API low‑code invece del modello oggetto completo?**

Utilizza le helper low‑code quando un'operazione standard si applica a un file o una presentazione completa e non richiede un controllo dettagliato sugli elementi individuali. Usa il modello oggetto completo quando è necessario selezionare slide specifiche, controllare le relazioni tra master e layout, ispezionare lo stato intermedio o configurare un comportamento che la helper non espone.

**Il Merger può combinare presentazioni in formati di file diversi?**

No. [Merger.Process](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/merger/process/) richiede che le presentazioni di input siano nello stesso formato. Converti prima i file di input in un formato comune, ad esempio con [Convert.AutoByExtension](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/convert/autobyextension/), e poi unisci i file convertiti.

**ForEach elabora master, layout e slide delle note?**

[ForEach.Slide](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/foreach/slide/) itera attraverso le slide di presentazione normali. Le operazioni a livello di presentazione di [ForEach.Shape](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/foreach/paragraph/) e [ForEach.Portion](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/foreach/portion/) includono per impostazione predefinita le slide normali, master e layout. Usa le loro overload con il parametro `includeNotes` impostato a `true` per includere le slide delle note.

**Qual è la differenza tra ForEach.Shape e Collect.Shapes?**

Utilizza [ForEach.Shape](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/foreach/shape/) per elaborare ogni forma immediatamente tramite una callback. Usa [Collect.Shapes](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/collect/shapes/) quando ti serve un risultato enumerabile che può essere conservato, filtrato, contato o attraversato più volte.

**Compress riduce sempre la dimensione del file della presentazione?**

Non necessariamente. Il risultato dipende dal fatto che la presentazione contenga layout inutilizzati, master inutilizzati o font incorporati con caratteri non usati. Se nessuno di questi è presente, le relative operazioni di [Compress](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/compress/) potrebbero non ridurre la dimensione del file.

**Le modifiche apportate da ForEach o Compress vengono salvate automaticamente?**

No. Queste helper operano sull'oggetto [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) caricato in memoria. Dopo aver modificato gli elementi in una callback di [ForEach](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/foreach/) o aver eseguito [Compress](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/compress/), chiama [Presentation.Save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/save/) per scrivere il risultato.

## **Articoli Correlati**

- [Convertire la Presentazione](/slides/it/net/convert-presentation/)
- [Unire le Presentazioni](/slides/it/net/merge-presentation/)
- [Master diapositive](/slides/it/net/slide-master/)
- [Gestire Casella di Testo](/slides/it/net/manage-textbox/)
- [Font Incorporato](/slides/it/net/embedded-font/)