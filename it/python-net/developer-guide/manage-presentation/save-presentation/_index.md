---
title: Salvare presentazioni in Python
linktitle: Salvare presentazioni
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
- Formato Strict Office Open XML
- modalità Zip64
- aggiornamento miniatura
- avanzamento salvataggio
- Python
- Aspose.Slides
description: "Scopri come salvare le presentazioni in Python usando Aspose.Slides—esporta in PowerPoint o OpenDocument mantenendo layout, caratteri ed effetti."
---
## **Panoramica**

[Open a Presentation in Python](/slides/it/python-net/open-presentation/) descrive come utilizzare la classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) per aprire una presentazione. Questo articolo spiega come creare e salvare le presentazioni. La classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) contiene il contenuto di una presentazione. Che tu stia creando una presentazione da zero o modificando una esistente, vorrai salvarla al termine. Con Aspose.Slides per Python, puoi salvare in un **file** o **stream**. Questo articolo spiega i diversi modi per salvare una presentazione.

## **Salva presentazioni su file**

Salva una presentazione su un file chiamando il metodo `save` della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/). Passa il nome del file e il formato di salvataggio al metodo. L'esempio seguente mostra come salvare una presentazione con Aspose.Slides per Python.

```py
import aspose.slides as slides

# Istanzia la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:
    
    # Esegui qualche operazione qui...

    # Salva la presentazione in un file.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Salva presentazioni su stream**

Puoi salvare una presentazione su uno stream passando uno stream di output al metodo `save` della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/). Una presentazione può essere scritta in molti tipi di stream. Nell'esempio seguente, creiamo una nuova presentazione e la salviamo su uno stream di file.

```py
import aspose.slides as slides

# Istanzia la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # Salva la presentazione nello stream.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **Salva presentazioni con un tipo di visualizzazione predefinito**

Aspose.Slides per Python ti consente di impostare la visualizzazione iniziale che PowerPoint utilizza quando la presentazione generata viene aperta tramite la classe [ViewProperties](https://reference.aspose.com/slides/it/python-net/aspose.slides/viewproperties/). Imposta la proprietà `last_view` a un valore dell'enumerazione [ViewType](https://reference.aspose.com/slides/it/python-net/aspose.slides/viewtype/).

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Salva presentazioni nel formato Strict Office Open XML**

Aspose.Slides ti consente di salvare una presentazione nel formato Strict Office Open XML. Usa la classe [PptxOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/pptxoptions/) e imposta la sua proprietà `conformance` durante il salvataggio. Se imposti `Conformance.ISO_29500_2008_STRICT`, il file di output viene salvato nel formato Strict Office Open XML.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# Istanzia la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:
    # Salva la presentazione nel formato Strict Office Open XML.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Salva presentazioni in formato Office Open XML in modalità Zip64**

Un file Office Open XML è un archivio ZIP che impone limiti di 4 GB (2^32 byte) sulla dimensione non compressa di qualsiasi file, sulla dimensione compressa di qualsiasi file e sulla dimensione totale dell'archivio, e limita anche l'archivio a 65.535 (2^16‑1) file. Le estensioni del formato ZIP64 aumentano questi limiti a 2^64.

La proprietà [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) consente di scegliere quando utilizzare le estensioni del formato ZIP64 durante il salvataggio di un file Office Open XML.

Questa proprietà offre i seguenti modi:

- `IF_NECESSARY` utilizza le estensioni del formato ZIP64 solo se la presentazione supera le limitazioni sopra. È la modalità predefinita.
- `NEVER` non utilizza mai le estensioni del formato ZIP64.
- `ALWAYS` utilizza sempre le estensioni del formato ZIP64.

Il codice seguente dimostra come salvare una presentazione come file PPTX con le estensioni del formato ZIP64 abilitate:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}
Quando salvi con `Zip64Mode.NEVER`, viene generata una [PptxException](https://reference.aspose.com/slides/it/python-net/aspose.slides/pptxexception/) se la presentazione non può essere salvata in formato ZIP32.
{{% /alert %}}

## **Salva presentazioni in formato Office Open XML con livelli di compressione**

Quando lavori con presentazioni di grandi dimensioni, puoi regolare il livello di compressione per bilanciare la dimensione del file e il tempo di elaborazione. In base alle tue esigenze, potresti preferire un'elaborazione più rapida o file di output più piccoli.

Aspose.Slides fornisce la proprietà [PptxOptions.compression_level](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/pptxoptions/compression_level/) che consente di specificare il livello di compressione da utilizzare quando si salva una presentazione nel formato Office Open XML.

Sono disponibili i seguenti livelli di compressione:

- [**NONE**](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/compressionlevel/): Nessuna compressione applicata. I file vengono memorizzati così come sono.
- [**LEVEL1**](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/compressionlevel/): La compressione più veloce con il rapporto di compressione più basso.
- [**LEVEL2**](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/compressionlevel/): Compressione più veloce con un rapporto di compressione leggermente migliore rispetto a **LEVEL1**.
- [**LEVEL3**](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/compressionlevel/): Fornisce una compressione migliore rispetto a **LEVEL2** con un impatto moderato sul tempo di elaborazione.
- [**LEVEL4**](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/compressionlevel/): Fornisce una compressione migliore rispetto a **LEVEL3**.
- [**LEVEL5**](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/compressionlevel/): Fornisce una compressione migliorata rispetto a **LEVEL4** con un ulteriore tempo di elaborazione.
- [**LEVEL6**](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/compressionlevel/): Compressione standard che offre un buon equilibrio tra velocità di elaborazione e dimensione del file. Questo è il *livello di compressione predefinito*.
- [**LEVEL7**](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/compressionlevel/): Fornisce una compressione migliore rispetto a **LEVEL6** con un'elaborazione più lenta.
- [**LEVEL8**](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/compressionlevel/): Fornisce una compressione migliore rispetto a **LEVEL7**.
- [**LEVEL9**](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/compressionlevel/): Compressone massima. Produce la dimensione di file più piccola al costo del più lungo tempo di elaborazione.

L'esempio seguente dimostra come salvare una presentazione come file PPTX *senza compressione*:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.NONE

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_out.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

Questo esempio mostra come salvare una presentazione come file PPTX con *compressone massima*:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.LEVEL9

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_level9.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

## **Salva presentazioni senza aggiornare la miniatura**

La proprietà [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) controlla la generazione della miniatura quando si salva una presentazione in PPTX:

- Se impostata su `True`, la miniatura viene aggiornata durante il salvataggio. È il valore predefinito.
- Se impostata su `False`, la miniatura corrente viene preservata. Se la presentazione non ha una miniatura, non ne viene generata alcuna.

Nel codice seguente, la presentazione viene salvata in PPTX senza aggiornare la sua miniatura.

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}
Questa opzione aiuta a ridurre il tempo necessario per salvare una presentazione in formato PPTX.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Aspose ha sviluppato una [app gratuita PowerPoint Splitter](https://products.aspose.app/slides/it/splitter) utilizzando la propria API. L'app consente di dividere una presentazione in più file salvando le diapositive selezionate come nuovi file PPTX o PPT.
{{% /alert %}}

## **FAQ**

**Il "fast save" (salvataggio incrementale) è supportato in modo che vengano scritte solo le modifiche?**

No. Il salvataggio crea l'intero file di destinazione ogni volta; il "fast save" incrementale non è supportato.

**È thread‑safe cancellare la stessa istanza di Presentation da più thread?**

No. Un'istanza di [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) [non è thread‑safe](/slides/it/python-net/multithreading/); salvala da un singolo thread.

**Cosa succede ai collegamenti ipertestuali e ai file collegati esternamente durante il salvataggio?**

[Hyperlinks](/slides/it/python-net/manage-hyperlinks/) sono conservati. I file collegati esternamente (ad es., video tramite percorsi relativi) non vengono copiati automaticamente — assicurati che i percorsi di riferimento rimangano accessibili.

**Posso impostare/salvare i metadati del documento (Autore, Titolo, Azienda, Data)?**

Sì. Le [proprietà del documento](/slides/it/python-net/presentation-properties/) standard sono supportate e verranno scritte nel file al momento del salvataggio.