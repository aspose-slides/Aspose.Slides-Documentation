---
title: Operazioni di presentazione Low-Code in Python
linktitle: API Low-Code
type: docs
weight: 50
url: /it/python-net/low-code-presentation-operations/
keywords:
- API di presentazione low-code
- convertire presentazione
- unire presentazioni
- raccogliere forme
- comprimere presentazione
- rimuovere master slide inutilizzati
- rimuovere layout slide inutilizzati
- comprimere font incorporati
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Utilizza l'API low-code di Aspose.Slides in Python per convertire e unire presentazioni, raccogliere forme e ridurre le dimensioni della presentazione."
---
## **Panoramica**

Il modulo [aspose.slides.lowcode](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/) fornisce classi di supporto per operazioni comuni sulle presentazioni. Queste classi avvolgono flussi di lavoro del modello oggetto frequentemente usati in metodi mirati, così è possibile convertire o unire file, raccogliere forme e rimuovere contenuti inutilizzati con meno codice.

Gli helper low-code sono più utili quando l'operazione si applica all'intero file o presentazione e il flusso di lavoro predefinito soddisfa i requisiti. Utilizza il modello completo [Aspose.Slides object model](https://reference.aspose.com/slides/it/python-net/aspose.slides/) quando hai bisogno di un controllo dettagliato su singole diapositive, master, layout, forme, impostazioni di esportazione o relazioni tra gli elementi della presentazione.

La tabella seguente riepiloga gli helper disponibili:

| Helper | Uso |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/convert/) | Convertire una presentazione in un altro formato con una chiamata file‑a‑file diretta. |
| [Merger](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/merger/) | Combinare file di presentazione completi dello stesso formato. |
| [Collect](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/collect/) | Recuperare le forme dall'intera presentazione per elaborazioni o analisi ripetute. |
| [Compress](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/compress/) | Rimuovere master e layout inutilizzati e ridurre i dati dei font incorporati. |

## **Convertire una presentazione**

Usa [Convert.auto_by_extension](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/convert/auto_by_extension/) quando l'estensione del file di output è sufficiente a selezionare il formato di esportazione. Il metodo apre la presentazione sorgente, determina il formato richiesto dal percorso di output e scrive il risultato.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

La classe [Convert](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/convert/) fornisce inoltre metodi dedicati per l'output in PDF, SVG, JPEG, PNG e TIFF. Usa il modello completo quando devi ispezionare o modificare la presentazione prima dell'esportazione o configurare un'opzione di esportazione non esposta dall'helper selezionato. Vedi [Convert Presentation](/slides/it/python-net/convert-presentation/) per flussi di lavoro e opzioni specifiche per formato.

## **Unire presentazioni**

Usa [Merger.process](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/merger/process/) per combinare file di presentazione completi con una sola chiamata. Le presentazioni di input devono avere lo stesso formato di file.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

L'helper è appropriato quando tutte le diapositive devono essere aggiunte a un unico risultato senza selezionarle o rimapparle singolarmente. Usa il modello completo quando devi unire diapositive selezionate, applicare un master o layout di destinazione, preservare le sezioni esplicitamente o riconciliare diverse dimensioni delle diapositive. Vedi [Merge Presentations](/slides/it/python-net/merge-presentation/) per questi scenari.

## **Raccogliere forme**

Usa [Collect.shapes](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/collect/shapes/) quando ti serve una collezione di tutte le forme in una presentazione. È utile quando lo stesso insieme verrà filtrato, contato o elaborato più volte.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

Usa cicli di raccolta diretti quando l'ordine di attraversamento, l'uscita anticipata, il filtraggio prima dell'elaborazione o il controllo dettagliato di genitore‑figlio sono importanti.

## **Comprimere il contenuto della presentazione**

La classe [Compress](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/compress/) può rimuovere elementi strutturali inutilizzati e ridurre i dati dei font incorporati:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) rimuove le diapositive layout che nessuna diapositiva normale riferisce.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) rimuove le diapositive master che non sono più utilizzate.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) rimuove i caratteri inutilizzati dai font incorporati.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

Rimuovi i layout inutilizzati prima dei master inutilizzati, così un master che diventa non referenziato dopo la pulizia dei layout può essere rimosso. Salva la presentazione ottimizzata in un nuovo file se potresti aver bisogno in seguito dei master, layout originali o dei dati completi dei font incorporati. Per maggiori dettagli, vedi [Slide Master](/slides/it/python-net/slide-master/) e [Embedded Font](/slides/it/python-net/embedded-font/).

## **FAQ**

**Quando dovrei utilizzare l'API low-code invece del modello completo?**

Utilizza gli helper low-code quando un'operazione standard si applica a un file o una presentazione completa e non richiede un controllo dettagliato sugli elementi individuali. Usa il modello completo quando devi selezionare diapositive specifiche, controllare le relazioni tra master e layout, ispezionare lo stato intermedio o configurare comportamenti non esposti dall'helper.

**Il Merger può combinare presentazioni in formati di file diversi?**

No. [Merger.process](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/merger/process/) richiede che le presentazioni di input siano nello stesso formato. Converti prima i file di input in un formato comune, ad esempio con [Convert.auto_by_extension](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/convert/auto_by_extension/), e quindi unisci i file convertiti.

**Cosa include Collect.shapes?**

[Collect.shapes](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/collect/shapes/) recupera le forme dalla presentazione in modo che possano essere conservate, filtrate, contate o attraversate più volte. Usa cicli di raccolta diretti quando hai bisogno di un controllo preciso su quali tipi di diapositiva o oggetti nidificati vengano visitati.

**Compress riduce sempre le dimensioni del file della presentazione?**

Non necessariamente. Il risultato dipende dal fatto che la presentazione contenga layout inutilizzati, master inutilizzati o font incorporati con caratteri inutilizzati. Se nessuno di questi è presente, le operazioni corrispondenti di [Compress](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/compress/) potrebbero non ridurre le dimensioni del file.

**Le modifiche apportate da Compress vengono salvate automaticamente?**

No. Questi helper operano sull'oggetto [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) caricato in memoria. Dopo aver eseguito [Compress](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/compress/), chiama [Presentation.save](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/save/) per scrivere il risultato.

## **Articoli correlati**

- [Convert Presentation](/slides/it/python-net/convert-presentation/)
- [Merge Presentations](/slides/it/python-net/merge-presentation/)
- [Slide Master](/slides/it/python-net/slide-master/)
- [Manage Text Box](/slides/it/python-net/manage-textbox/)
- [Embedded Font](/slides/it/python-net/embedded-font/)