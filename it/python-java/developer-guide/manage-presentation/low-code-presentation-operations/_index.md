---
title: Operazioni di Presentazione Low-Code in Python via Java
linktitle: API Low-Code
type: docs
weight: 50
url: /it/python-java/low-code-presentation-operations/
keywords:
- API di presentazione low-code
- convertire presentazione
- unire presentazioni
- iterare diapositive
- iterare forme
- iterare testo
- raccogliere forme
- comprimere presentazione
- rimuovere master slide inutili
- rimuovere layout slide inutili
- comprimere font incorporati
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Utilizza l'API low-code di Aspose.Slides in Python via Java per convertire e unire presentazioni, scorrere il contenuto, raccogliere forme e ridurre le dimensioni della presentazione."
---
## **Panoramica**

L'API [Aspose.Slides for Python via Java](https://reference.aspose.com/slides/it/python-java/aspose.slides/) fornisce classi helper statiche per operazioni comuni sulle presentazioni. Queste utility racchiudono flussi di lavoro frequenti del modello a oggetti in metodi mirati, così è possibile convertire o unire file, elaborare elementi della presentazione, raccogliere forme e rimuovere contenuti inutilizzati con meno codice.

Le utility a basso codice sono più utili quando l'operazione si applica a un intero file o presentazione e il flusso di lavoro predefinito soddisfa i requisiti. Utilizza il modello a oggetti completo di [Aspose.Slides](https://reference.aspose.com/slides/it/python-java/aspose.slides/) quando hai bisogno di un controllo fine su diapositive individuali, master, layout, forme, impostazioni di esportazione o relazioni tra gli elementi della presentazione.

La tabella seguente riepiloga le utility disponibili:

| Helper | Utilizzo |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/it/python-java/aspose.slides/convert/) | Conversione di una presentazione in un altro formato con una chiamata file‑to‑file diretta. |
| [Merger](https://reference.aspose.com/slides/it/python-java/aspose.slides/merger/) | Unione di file di presentazione completi dello stesso formato. |
| [ForEach](https://reference.aspose.com/slides/it/python-java/aspose.slides/foreach/) | Esecuzione di un'azione per ogni diapositiva, forma, paragrafo o porzione di testo. |
| [Collect](https://reference.aspose.com/slides/it/python-java/aspose.slides/collect/) | Recupero delle forme da tutta la presentazione per elaborazioni o analisi ripetute. |
| [Compress](https://reference.aspose.com/slides/it/python-java/aspose.slides/compress/) | Rimozione di master e layout inutilizzati e riduzione dei dati dei font incorporati. |

## **Convertire una Presentazione**

Usa [Convert.autoByExtension](https://reference.aspose.com/slides/it/python-java/aspose.slides/convert/#autoByExtension) quando l'estensione del file di output è sufficiente a selezionare il formato di esportazione. Il metodo apre la presentazione sorgente, determina il formato richiesto dal percorso di output e scrive il risultato.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Convert

Convert.autoByExtension("input.pptx", "output.pdf")
```

La classe [Convert](https://reference.aspose.com/slides/it/python-java/aspose.slides/convert/) offre anche metodi dedicati per output PDF, SVG, JPEG, PNG e TIFF. Usa il modello a oggetti completo quando devi ispezionare o modificare la presentazione prima dell'esportazione o configurare un'opzione di esportazione non esposta dalla utility selezionata. Vedi [Convert Presentation](/slides/it/python-java/convert-presentation/) per flussi di lavoro e opzioni specifiche per formato.

## **Unire Presentazioni**

Usa [Merger.process](https://reference.aspose.com/slides/it/python-java/aspose.slides/merger/#process) per combinare file di presentazione completi con una sola chiamata. Le presentazioni di input devono avere lo stesso formato di file.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Merger

input_files = jpype.JArray(jpype.JString)(["part-1.pptx", "part-2.pptx"])
Merger.process(input_files, "merged.pptx")
```

La utility è appropriata quando tutte le diapositive devono essere aggiunte a un risultato unico senza selezionarle o rimapparle individualmente. Usa il modello a oggetti completo quando devi unire diapositive selezionate, applicare un master o layout di destinazione, preservare sezioni esplicitamente o conciliare differenti dimensioni di diapositive. Vedi [Merge Presentations](/slides/it/python-java/merge-presentation/) per questi scenari.

## **Iterare Attraverso gli Elementi della Presentazione**

La classe [ForEach](https://reference.aspose.com/slides/it/python-java/aspose.slides/foreach/) invoca una callback per ciascun tipo richiesto di elemento della presentazione. Evita loop annidati su collezioni ed è comoda per ispezioni o modifiche di formattazione a livello di presentazione.

L'esempio seguente utilizza [ForEach.slide](https://reference.aspose.com/slides/it/python-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/it/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/it/python-java/aspose.slides/foreach/#paragraph) e [ForEach.portion](https://reference.aspose.com/slides/it/python-java/aspose.slides/foreach/#portion) per ispezionare gli elementi corrispondenti:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ForEach, Presentation

def print_slide(slide, index):
    print(f"Slide {index}: {slide.getShapes().size()} shapes")

def print_shape(shape, slide, index):
    print(f"Shape {index} on {slide.getClass().getSimpleName()}: {shape.getName()}")

def print_paragraph(paragraph, slide, index):
    print(f"Paragraph {index} on {slide.getClass().getSimpleName()}: {paragraph.getText()}")

def print_portion(portion, paragraph, slide, index):
    print(f"Portion {index} on {slide.getClass().getSimpleName()}: {portion.getText()}")

presentation = Presentation("input.pptx")
try:
    ForEach.slide(presentation, print_slide)
    ForEach.shape(presentation, print_shape)
    ForEach.paragraph(presentation, print_paragraph)
    ForEach.portion(presentation, print_portion)
finally:
    presentation.dispose()
```

Per impostazione predefinita, l'attraversamento di forme e testo a livello di presentazione include diapositive normali, master e layout. Le varianti con parametro `includeNotes` possono anche elaborare le diapositive delle note. Usa loop di collezioni diretti quando l'ordine di attraversamento, l'uscita anticipata, il filtraggio prima della chiamata della callback o il controllo dettagliato padre‑figlio sono importanti.

## **Raccogliere Forme**

Usa [Collect.shapes](https://reference.aspose.com/slides/it/python-java/aspose.slides/collect/#shapes) quando ti serve una collezione di tutte le forme in una presentazione anziché una callback per ogni forma. Questo è utile quando lo stesso set verrà filtrato, contato o elaborato più volte.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Collect, Presentation

presentation = Presentation("input.pptx")
try:
    shapes = Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.getName()}: {shape.getClass().getSimpleName()}")
finally:
    presentation.dispose()
```

Utilizza [ForEach.shape](https://reference.aspose.com/slides/it/python-java/aspose.slides/foreach/#shape) invece quando ogni forma può essere gestita immediatamente e non è necessario conservare il risultato raccolto.

## **Comprimere il Contenuto della Presentazione**

La classe [Compress](https://reference.aspose.com/slides/it/python-java/aspose.slides/compress/) può rimuovere elementi strutturali inutilizzati e ridurre i dati dei font incorporati:

- [removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) rimuove i layout diapositive non referenziati da alcuna diapositiva normale.
- [removeUnusedMasterSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/compress/#removeUnusedMasterSlides) rimuove i master slide non più usati.
- [compressEmbeddedFonts](https://reference.aspose.com/slides/it/python-java/aspose.slides/compress/#compressEmbeddedFonts) rimuove i caratteri inutilizzati dai font incorporati.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    Compress.removeUnusedMasterSlides(presentation)
    Compress.compressEmbeddedFonts(presentation)

    presentation.save("compressed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Rimuovi prima i layout inutilizzati e poi i master inutilizzati, così un master che diventa non referenziato dopo la pulizia dei layout può essere anch'esso rimosso. Salva la presentazione ottimizzata in un nuovo file se potresti aver bisogno in seguito dei master, layout o dei dati completi dei font incorporati. Per maggiori dettagli, vedi [Slide Master](/slides/it/python-java/slide-master/) e [Embedded Font](/slides/it/python-java/embedded-font/).

## **FAQ**

**Quando dovrei usare l'API a basso codice invece del modello a oggetti completo?**

Usa le utility a basso codice quando un'operazione standard si applica a un file o presentazione completa e non richiede un controllo dettagliato su elementi individuali. Usa il modello a oggetti completo quando devi selezionare diapositive specifiche, controllare le relazioni tra master e layout, ispezionare lo stato intermedio o configurare comportamenti non esposti dalla utility.

**Il Merger può combinare presentazioni in formati di file diversi?**

No. [Merger.process](https://reference.aspose.com/slides/it/python-java/aspose.slides/merger/#process) richiede presentazioni di input nello stesso formato. Converti prima i file di input in un formato comune, ad esempio con [Convert.autoByExtension](https://reference.aspose.com/slides/it/python-java/aspose.slides/convert/#autoByExtension), e poi unisci i file convertiti.

**ForEach elabora master, layout e diapositive delle note?**

[ForEach.slide](https://reference.aspose.com/slides/it/python-java/aspose.slides/foreach/#slide) itera solo sulle diapositive normali della presentazione. Le operazioni a livello di presentazione di [ForEach.shape](https://reference.aspose.com/slides/it/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/it/python-java/aspose.slides/foreach/#paragraph) e [ForEach.portion](https://reference.aspose.com/slides/it/python-java/aspose.slides/foreach/#portion) includono diapositive normali, master e layout per impostazione predefinita. Usa le loro varianti con `includeNotes` impostato a `True` per includere le diapositive delle note.

**Qual è la differenza tra ForEach.shape e Collect.shapes?**

Usa [ForEach.shape](https://reference.aspose.com/slides/it/python-java/aspose.slides/foreach/#shape) per elaborare immediatamente ogni forma tramite una callback. Usa [Collect.shapes](https://reference.aspose.com/slides/it/python-java/aspose.slides/collect/#shapes) quando ti serve un risultato iterabile da conservare, filtrare, contare o attraversare più volte.

**Compress riduce sempre le dimensioni del file della presentazione?**

Non necessariamente. Il risultato dipende dal fatto che la presentazione contenga layout inutilizzati, master inutilizzati o font incorporati con caratteri inutilizzati. Se nessuno di questi elementi è presente, le operazioni corrispondenti di [Compress](https://reference.aspose.com/slides/it/python-java/aspose.slides/compress/) potrebbero non ridurre la dimensione del file.

**Le modifiche apportate da ForEach o Compress vengono salvate automaticamente?**

No. Queste utility operano sull'oggetto [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) caricato in memoria. Dopo aver modificato gli elementi in una callback di [ForEach](https://reference.aspose.com/slides/it/python-java/aspose.slides/foreach/) o aver eseguito [Compress](https://reference.aspose.com/slides/it/python-java/aspose.slides/compress/), chiama [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) per scrivere il risultato.

## **Articoli Correlati**

- [Convert Presentation](/slides/it/python-java/convert-presentation/)
- [Merge Presentations](/slides/it/python-java/merge-presentation/)
- [Slide Master](/slides/it/python-java/slide-master/)
- [Manage Text Box](/slides/it/python-java/manage-textbox/)
- [Embedded Font](/slides/it/python-java/embedded-font/)