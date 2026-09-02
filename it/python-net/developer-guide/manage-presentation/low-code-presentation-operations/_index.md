---
title: Operazioni di presentazione Low-Code in Python
linktitle: API Low-Code
type: docs
weight: 50
url: /it/python-net/low-code-presentation-operations/
keywords:
- API di presentazione low-code
- conversione presentazione
- unire presentazioni
- raccogli forme
- comprimere presentazione
- rimuovere slide master non utilizzate
- rimuovere slide layout non utilizzate
- comprimere font incorporati
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Utilizza l'API low-code di Aspose.Slides in Python per convertire e unire presentazioni, raccogliere forme e ridurre le dimensioni della presentazione."
---
## **Panoramica**

Il modulo [aspose.slides.lowcode](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/) fornisce classi helper per operazioni comuni sulle presentazioni. Queste helper avvolgono flussi di lavoro dell'object‑model spesso usati in metodi mirati, così è possibile convertire o unire file, raccogliere forme e rimuovere contenuti inutilizzati con meno codice.

Le helper low‑code sono più utili quando l'operazione si applica a un intero file o presentazione e il flusso di lavoro predefinito soddisfa i requisiti. Usa l'object model completo di [Aspose.Slides](https://reference.aspose.com/slides/it/python-net/aspose.slides/) quando necessiti di controllo dettagliato su singole diapositive, master, layout, forme, impostazioni di esportazione o relazioni tra gli elementi della presentazione.

La tabella seguente riepiloga le helper disponibili:

| Helper | Utilizzo |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/convert/) | Conversione di una presentazione in un altro formato con una chiamata diretta file‑a‑file. |
| [Merger](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/merger/) | Unione di file di presentazione completi dello stesso formato. |
| [Collect](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/collect/) | Recupero di forme dall'intera presentazione per elaborazioni o analisi ripetute. |
| [Compress](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/compress/) | Rimozione di master e layout non utilizzati e riduzione dei dati dei font incorporati. |

## **Convertire una presentazione**

Usa [Convert.auto_by_extension](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/convert/auto_by_extension/) quando l'estensione del file di output è sufficiente a selezionare il formato di esportazione. Il metodo apre la presentazione di origine, determina il formato necessario dal percorso di output e scrive il risultato.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

La classe [Convert](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/convert/) fornisce anche metodi dedicati per output PDF, SVG, JPEG, PNG e TIFF. Usa l'object model completo quando è necessario ispezionare o modificare la presentazione prima dell'esportazione o configurare un'opzione di esportazione non esposta dall'helper selezionato. Vedi [Convert Presentation](/python-net/convert-presentation/) per flussi di lavoro e opzioni specifiche per formato.

## **Unire presentazioni**

Usa [Merger.process](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/merger/process/) per combinare file di presentazione completi con una singola chiamata. Le presentazioni di input devono avere lo stesso formato di file.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

L'helper è appropriato quando tutte le diapositive devono essere aggiunte a un risultato unico senza selezionarle o rimapparle individualmente. Usa l'object model completo quando devi unire diapositive selezionate, applicare un master o layout di destinazione, preservare sezioni esplicitamente o gestire dimensioni diverse delle diapositive. Vedi [Merge Presentations](/python-net/merge-presentation/) per questi scenari.

## **Raccogliere forme**

Usa [Collect.shapes](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/collect/shapes/) quando ti serve una raccolta di tutte le forme in una presentazione. Questo è utile quando lo stesso insieme sarà filtrato, contato o elaborato più volte.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

Usa cicli di raccolta diretti quando l'ordine di traversamento, l'uscita anticipata, il filtraggio prima dell'elaborazione o il controllo dettagliato genitore‑figlio sono importanti.

## **Comprimere il contenuto della presentazione**

La classe [Compress](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/compress/) può rimuovere elementi strutturali inutilizzati e ridurre i dati dei font incorporati:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) rimuove le slide di layout che nessuna slide normale fa riferimento.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) rimuove i master slide non più utilizzati.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) rimuove i caratteri inutilizzati dai font incorporati.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

Rimuovi prima i layout inutilizzati e poi i master, così un master che diventa non referenziato dopo la pulizia dei layout può essere rimosso. Salva la presentazione ottimizzata in un nuovo file se potresti aver bisogno in seguito dei master, dei layout o dei dati completi dei font incorporati. Per maggiori dettagli, vedi [Slide Master](/python-net/slide-master/) e [Embedded Font](/python-net/embedded-font/).

## **FAQ**

**Quando dovrei usare l'API low‑code invece dell'object model completo?**

Usa le helper low‑code quando un'operazione standard si applica a un file o presentazione completo e non richiede controllo dettagliato su elementi singoli. Usa l'object model completo quando devi selezionare diapositive specifiche, controllare le relazioni tra master e layout, ispezionare lo stato intermedio o configurare comportamenti non esposti dall'helper.

**Può Merger combinare presentazioni in formati di file diversi?**

No. [Merger.process](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/merger/process/) richiede presentazioni di input nello stesso formato. Converte prima i file di input in un formato comune, ad esempio con [Convert.auto_by_extension](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/convert/auto_by_extension/), quindi unisci i file convertiti.

**Cosa include Collect.shapes?**

[Collect.shapes](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/collect/shapes/) recupera le forme dalla presentazione in modo che possano essere conservate, filtrate, contate o attraversate più volte. Usa cicli di raccolta diretti quando hai bisogno di un controllo preciso su quali tipi di diapositive o oggetti nidificati vengono visitati.

**Compress riduce sempre le dimensioni del file di presentazione?**

Non necessariamente. Il risultato dipende dal fatto che la presentazione contenga layout inutilizzati, master inutilizzati o font incorporati con caratteri non usati. Se nessuno di questi è presente, le operazioni corrispondenti di [Compress](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/compress/) potrebbero non ridurre la dimensione del file.

**Le modifiche apportate da Compress vengono salvate automaticamente?**

No. queste helper operano sull'oggetto [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) caricato in memoria. Dopo aver eseguito [Compress](https://reference.aspose.com/slides/it/python-net/aspose.slides.lowcode/compress/), chiama [Presentation.save](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/save/) per scrivere il risultato.

## **Articoli correlati**

- [Converti presentazione](/python-net/convert-presentation/)
- [Unisci presentazioni](/python-net/merge-presentation/)
- [Master di diapositiva](/python-net/slide-master/)
- [Gestisci casella di testo](/python-net/manage-textbox/)
- [Font incorporato](/python-net/embedded-font/)