---
title: Salvare presentazioni in Python
linktitle: Salva presentazione
type: docs
weight: 80
url: /it/python-net/save-presentation/
keywords:
- salva PowerPoint
- salva OpenDocument
- salva presentazione
- salva diapositiva
- salva PPT
- salva PPTX
- salva ODP
- presentazione su file
- presentazione su stream
- tipo di visualizzazione predefinito
- Formato Office Open XML Strict
- modalità Zip64
- aggiornamento della miniatura
- avanzamento salvataggio
- Python
- Aspose.Slides
description: "Salva presentazioni PowerPoint e OpenDocument su file o stream in Python con Aspose.Slides e configura le opzioni di output PPTX."
---
## **Panoramica**

Dopo aver creato una presentazione o [aprire una esistente](/slides/it/python-net/open-presentation/), usa il metodo [Presentation.save](https://reference.aspose.com/slides/it/python-net/aspose.slides/ipresentation/save/) per scrivere il risultato. Aspose.Slides per Python via .NET può salvare una presentazione su file o stream in formati PowerPoint, OpenDocument, PDF e altri formati. Le sezioni seguenti coprono le operazioni di salvataggio standard e le opzioni disponibili per l'output PPTX.

## **Salva presentazioni su file**

Per salvare una presentazione su file, passa il percorso di output e un valore [SaveFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/saveformat/) al metodo [Presentation.save](https://reference.aspose.com/slides/it/python-net/aspose.slides/ipresentation/save/). Il valore del formato determina il tipo di file che Aspose.Slides crea.

Il seguente esempio crea una presentazione e la salva come file PPTX:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Aggiungi o modifica il contenuto della presentazione qui.

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX)
```

## **Salva presentazioni nel loro formato originale**

Per esempi di rilevamento di file e stream, il comportamento delle presentazioni create di recente e la distinzione tra formati di origine e di destinazione, consulta [Determina il formato originale della presentazione](/slides/it/python-net/detect-presentation-source-format/).

In un'applicazione di elaborazione batch, il formato di input potrebbe non essere noto in anticipo. Dopo aver caricato un file, leggi il suo formato originale dalla proprietà [Presentation.source_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/source_format/). Passa il valore [SourceFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/sourceformat/) risultante a [SlideUtil.to_save_format](https://reference.aspose.com/slides/it/python-net/aspose.slides.util/slideutil/to_save_format/) per ottenere il valore corrispondente di [SaveFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/saveformat/), e quindi usa [Presentation.save](https://reference.aspose.com/slides/it/python-net/aspose.slides/ipresentation/save/) per scrivere la presentazione modificata.

Il seguente esempio completo elabora tutti i file in una directory di input, aggiorna il titolo e lo salva in una directory di output nel formato da cui è stato caricato:

```py
from pathlib import Path

import aspose.slides as slides
from aspose.slides.util import SlideUtil

input_directory = Path("Input")
output_directory = Path("Output")

output_directory.mkdir(exist_ok=True)

for input_path in input_directory.iterdir():
    if not input_path.is_file():
        continue

    try:
        with slides.Presentation(str(input_path)) as presentation:
            source_format = presentation.source_format
            save_format = SlideUtil.to_save_format(source_format)

            presentation.document_properties.title = "Processed by the batch application"

            output_path = output_directory / input_path.name
            presentation.save(str(output_path), save_format)
    except Exception as exception:
        print(f"Cannot process '{input_path}': {exception}")
```

[SlideUtil.to_save_format](https://reference.aspose.com/slides/it/python-net/aspose.slides.util/slideutil/to_save_format/) mappa PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP e PowerPoint XML ai loro corrispondenti formati di salvataggio della presentazione. Mappa solo i formati di origine della presentazione; non è destinato a selezionare formati di esportazione come PDF, HTML, TIFF o immagini. Passare un valore [SourceFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/sourceformat/) non supportato o non valido solleva un'eccezione.

I file legacy PPT, PPS e POT utilizzano lo stesso contenitore binario. Quando una presentazione del genere viene caricata da uno stream senza estensione di file, un file PPS o POT può quindi essere identificato come PPT. Se è necessario preservare questi sottotipi legacy, conserva separatamente il nome file originale o i metadati del formato e usali quando scegli il nome file e il formato di output.

## **Salva presentazioni su stream**

Per scrivere una presentazione senza fare affidamento su un percorso di file definitivo, passa uno stream scrivibile [BinaryIO](https://docs.python.org/3/library/typing.html#typing.BinaryIO) e un valore [SaveFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/saveformat/) al metodo [Presentation.save](https://reference.aspose.com/slides/it/python-net/aspose.slides/ipresentation/save/). Questo approccio è utile quando l'output deve essere restituito da un servizio web, memorizzato in un database o elaborato in memoria.

Il seguente esempio salva una nuova presentazione su uno stream di file:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("Output.pptx", "wb") as output_stream:
        presentation.save(output_stream, slides.export.SaveFormat.PPTX)
```

## **Salva presentazioni con un tipo di visualizzazione predefinito**

Puoi specificare la visualizzazione con cui PowerPoint apre inizialmente una presentazione salvata. Imposta la proprietà [ViewProperties.last_view](https://reference.aspose.com/slides/it/python-net/aspose.slides/viewproperties/last_view/) su un valore [ViewType](https://reference.aspose.com/slides/it/python-net/aspose.slides/viewtype/) prima del salvataggio.

Il seguente esempio configura la visualizzazione Slide Master come visualizzazione iniziale:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("SlideMasterView.pptx", slides.export.SaveFormat.PPTX)
```

## **Salva presentazioni nel formato Office Open XML Strict**

Per creare un file PPTX che rispetti il profilo Strict di Office Open XML, crea un'istanza [PptxOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/pptxoptions/) e imposta la sua proprietà [conformance](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/pptxoptions/conformance/) su `Conformance.ISO_29500_2008_STRICT`. Quindi passa le opzioni al metodo [Presentation.save](https://reference.aspose.com/slides/it/python-net/aspose.slides/ipresentation/save/).

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

with slides.Presentation() as presentation:
    presentation.save("StrictOfficeOpenXml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Salva presentazioni nel formato Office Open XML in modalità Zip64**

Un archivio ZIP standard limita la dimensione compressa e non compressa di ogni voce, la dimensione totale dell'archivio e il numero di voci. Poiché un file PPTX è un archivio ZIP, una presentazione molto grande può superare tali limiti. Le estensioni ZIP64 aumentano i limiti di dimensione e di numero di voci applicabili.

Usa la proprietà [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) per controllare se Aspose.Slides scrive le estensioni ZIP64:

- `IF_NECESSARY` utilizza ZIP64 solo quando la presentazione supera i limiti ZIP standard. Questa è la modalità predefinita.
- `NEVER` disabilita le estensioni ZIP64.
- `ALWAYS` scrive sempre le estensioni ZIP64.

Il seguente esempio abilita sempre le estensioni ZIP64 per la presentazione di output:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

    presentation.save("OutputZip64.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="warning" title="Warning" %}}
Se `Zip64Mode.NEVER` viene usato e la presentazione non può essere contenuta nei limiti ZIP standard, l'operazione di salvataggio solleva una [PptxException](https://reference.aspose.com/slides/it/python-net/aspose.slides/pptxexception/).
{{% /alert %}}

## **Salva presentazioni nel formato Office Open XML con livelli di compressione**

Per output PPTX, è possibile bilanciare velocità di salvataggio e dimensione del file impostando la proprietà [PptxOptions.compression_level](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/pptxoptions/compression_level/). L'enumerazione [CompressionLevel](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/compressionlevel/) fornisce questi valori:

- `NONE` memorizza i dati senza compressione.
- `LEVEL1` offre la compressione più rapida e l'output compresso più grande.
- `LEVEL2` fino a `LEVEL5` favoriscono progressivamente un output più piccolo rispetto alla velocità di salvataggio.
- `LEVEL6` bilancia velocità di salvataggio e dimensione del file. Questo è il livello predefinito.
- `LEVEL7` e `LEVEL8` favoriscono ulteriormente un output più piccolo rispetto alla velocità di salvataggio.
- `LEVEL9` fornisce la compressione più forte e richiede il maggior tempo di elaborazione.

Il seguente esempio salva una presentazione senza compressione:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.NONE

    presentation.save("OutputNoCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

Il seguente esempio utilizza il livello massimo di compressione:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.LEVEL9

    presentation.save("OutputMaximumCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Salva presentazioni senza aggiornare la miniatura**

Quando una presentazione è salvata come PPTX, la proprietà [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) controlla la miniatura del documento:

- `True` rigenera la miniatura durante l'operazione di salvataggio. Questo è il valore predefinito.
- `False` preserva la miniatura esistente. Se la presentazione non ha una miniatura, Aspose.Slides non ne genera una.

Il seguente esempio salva una presentazione senza aggiornare la sua miniatura:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.refresh_thumbnail = False

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="info" title="Note" %}}
Disabilitare l'aggiornamento della miniatura può ridurre il tempo necessario per salvare un file PPTX.
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Aspose offre un gratuito [PowerPoint Splitter](https://products.aspose.app/slides/it/splitter) basato sull'API Aspose.Slides. Salva le diapositive selezionate da una presentazione come file PPT o PPTX separati.
{{% /alert %}}

## **FAQ**

**Aspose.Slides supporta il salvataggio incrementale o “fast save”?**

No. Ogni operazione di salvataggio scrive un file di output completo invece di aggiornare solo le parti modificate.

**Più thread possono salvare la stessa istanza Presentation?**

No. Un'istanza [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) [non è thread-safe](/slides/it/python-net/multithreading/). Accedi e salva ogni istanza da un solo thread alla volta.

**Cosa succede ai collegamenti ipertestuali e ai file collegati esternamente quando salvo una presentazione?**

[Hyperlinks](/slides/it/python-net/manage-hyperlinks/) rimangono nella presentazione. Aspose.Slides non copia i file collegati esternamente, quindi la presentazione salvata deve ancora poter accedere alle loro posizioni.

**Posso salvare i metadati del documento come autore, titolo, azienda e data di creazione?**

Sì. Imposta le appropriate [document properties](/slides/it/python-net/presentation-properties/) prima del salvataggio, e Aspose.Slides le scrive nel file di output.