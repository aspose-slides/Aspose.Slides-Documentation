---
title: Operazioni di presentazione low-code in .NET
linktitle: API low-code
type: docs
weight: 50
url: /it/net/low-code-presentation-operations/
keywords:
- API di presentazione low-code
- convertire presentazione
- unire presentazioni
- iterare diapositive
- iterare forme
- iterare testo
- raccogliere forme
- comprimere presentazione
- rimuovere master diapositive non utilizzati
- rimuovere layout diapositive non utilizzati
- comprimere font incorporati
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Usa l'API low-code di Aspose.Slides in .NET per convertire e unire presentazioni, iterare il contenuto, raccogliere forme e ridurre le dimensioni della presentazione."
---
## **Panoramica**

Il namespace [Aspose.Slides.LowCode](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/) fornisce classi helper statiche per le operazioni comuni sulle presentazioni. Questi helper racchiudono i flussi di lavoro dell'object‑model più usati in metodi dedicati, così è possibile convertire o unire file, elaborare gli elementi della presentazione, raccogliere forme e rimuovere contenuti non utilizzati con meno codice.

Gli helper low‑code sono più utili quando l'operazione si applica a un intero file o a una presentazione e il flusso di lavoro predefinito soddisfa i requisiti. Usa l'intero [Aspose.Slides object model](https://reference.aspose.com/slides/it/net/aspose.slides/) quando hai bisogno di un controllo granulare su diapositive singole, master, layout, forme, impostazioni di esportazione o relazioni tra gli elementi della presentazione.

La tabella seguente riassume gli helper disponibili:

| Helper | Utilizzo |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/convert/) | Convertire una presentazione in un altro formato con una chiamata file‑a‑file diretta. |
| [Merger](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/merger/) | Combinare file di presentazione completi dello stesso formato. |
| [ForEach](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/foreach/) | Eseguire un'azione per ogni diapositiva, forma, paragrafo o porzione di testo. |
| [Collect](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/collect/) | Recuperare le forme dall'intera presentazione per elaborazioni o analisi ripetute. |
| [Compress](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/compress/) | Rimuovere master e layout non utilizzati e ridurre i dati dei font incorporati. |

## **Convertire una Presentazione**

Usa [Convert.AutoByExtension](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/convert/autobyextension/) quando l'estensione del file di output è sufficiente a selezionare il formato di esportazione. Il metodo apre la presentazione sorgente, determina il formato necessario dal percorso di output e scrive il risultato.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

La classe [Convert](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/convert/) fornisce anche metodi dedicati per output PDF, SVG, JPEG, PNG e TIFF. Usa l'object model completo quando devi ispezionare o modificare la presentazione prima dell'esportazione o configurare un'opzione di esportazione non esposta dall'helper selezionato. Vedi [Convert Presentation](/net/convert-presentation/) per flussi di lavoro e opzioni specifiche per formato.

## **Unire le Presentazioni**

Usa [Merger.Process](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/merger/process/) per combinare file di presentazione completi con una sola chiamata. Le presentazioni di input devono avere lo stesso formato di file.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

L'helper è appropriato quando tutte le diapositive devono essere aggiunte a un risultato unico senza selezionarle o rimapparle individualmente. Usa l'object model completo quando devi unire diapositive selezionate, applicare un master o layout di destinazione, preservare sezioni in modo esplicito o conciliare dimensioni di diapositive diverse. Vedi [Merge Presentations](/net/merge-presentation/) per questi scenari.

## **Iterare Attraverso gli Elementi della Presentazione**

La classe [ForEach](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/foreach/) invoca un callback per ogni tipo richiesto di elemento della presentazione. Evita loop di raccolta annidati ed è comoda per ispezioni o modifiche di formattazione a livello di intera presentazione.

L'esempio seguente utilizza [ForEach.Slide](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/foreach/paragraph/) e [ForEach.Portion](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/foreach/portion/) per ispezionare gli elementi corrispondenti:

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

Per impostazione predefinita, il traversal di forme e testo a livello di presentazione include diapositive normali, master e layout. Le sovraccarichi con un parametro `includeNotes` possono anche elaborare le diapositive delle note. Usa loop di raccolta diretti quando l'ordine di traversal, l'uscita anticipata, il filtraggio prima della chiamata al callback o il controllo dettagliato genitore‑figlio sono importanti.

## **Raccogliere Forme**

Usa [Collect.Shapes](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/collect/shapes/) quando ti serve una raccolta di tutte le forme in una presentazione anziché un callback per ogni forma. È utile quando lo stesso set verrà filtrato, contato o elaborato più volte.

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

La classe [Compress](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/compress/) può rimuovere elementi strutturali non utilizzati e ridurre i dati dei font incorporati:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) rimuove le diapositive di layout non referenziate da alcuna diapositiva normale.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) rimuove i master non più utilizzati.
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

Rimuovi prima i layout non utilizzati e poi i master non utilizzati, così un master che diventa non referenziato dopo la pulizia dei layout può essere rimosso. Salva la presentazione ottimizzata in un nuovo file se potresti aver bisogno dei master, dei layout o dei dati completi dei font incorporati in seguito. Per maggiori dettagli, consulta [Slide Master](/net/slide-master/) e [Embedded Font](/net/embedded-font/).

## **FAQ**

**Quando dovrei usare l'API low‑code invece dell'object model completo?**

Usa gli helper low‑code quando un'operazione standard si applica a un file o a una presentazione completa e non richiede un controllo dettagliato sugli elementi individuali. Usa l'object model completo quando devi selezionare diapositive specifiche, controllare le relazioni tra master e layout, ispezionare lo stato intermedio o configurare comportamenti non esposti dall'helper.

**Il Merger può combinare presentazioni in formati di file diversi?**

No. [Merger.Process](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/merger/process/) richiede che le presentazioni di input siano nello stesso formato. Converti prima i file di input in un formato comune, ad esempio con [Convert.AutoByExtension](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/convert/autobyextension/), e poi unisci i file convertiti.

**ForEach elabora le diapositive master, layout e note?**

[ForEach.Slide](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/foreach/slide/) itera le diapositive di presentazione normali. Le operazioni a livello di presentazione di [ForEach.Shape](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/foreach/paragraph/) e [ForEach.Portion](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/foreach/portion/) includono per impostazione predefinita diapositive normali, master e layout. Usa le loro sovraccarichi con `includeNotes` impostato a `true` per includere le diapositive delle note.

**Qual è la differenza tra ForEach.Shape e Collect.Shapes?**

Usa [ForEach.Shape](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/foreach/shape/) per elaborare ogni forma immediatamente tramite un callback. Usa [Collect.Shapes](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/collect/shapes/) quando ti serve un risultato enumerabile che può essere conservato, filtrato, contato o attraversato più volte.

**Compress rende sempre più piccolo il file della presentazione?**

Non necessariamente. Il risultato dipende dal fatto che la presentazione contenga layout non utilizzati, master non utilizzati o font incorporati con caratteri inutilizzati. Se nessuno di questi è presente, le relative operazioni di [Compress](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/compress/) potrebbero non ridurre le dimensioni del file.

**Le modifiche apportate da ForEach o Compress vengono salvate automaticamente?**

No. Questi helper operano sull'oggetto [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) caricato in memoria. Dopo aver modificato gli elementi in un callback di [ForEach](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/foreach/) o eseguito [Compress](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/compress/), chiama [Presentation.Save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/save/) per scrivere il risultato.

## **Articoli Correlati**

- [Convert Presentation](/net/convert-presentation/)
- [Merge Presentations](/net/merge-presentation/)
- [Slide Master](/net/slide-master/)
- [Manage Text Box](/net/manage-textbox/)
- [Embedded Font](/net/embedded-font/)