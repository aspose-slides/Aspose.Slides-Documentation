---
title: Salva presentazioni in Python
linktitle: Salva presentazioni
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
- tipo di visualizzazione predefinita
- Formato Strict Office Open XML
- modalità Zip64
- aggiornamento miniatura
- avanzamento salvataggio
- Python
- Aspose.Slides
description: "Scopri come salvare presentazioni in Python usando Aspose.Slides—esporta in PowerPoint o OpenDocument mantenendo layout, font ed effetti."
---
## **Panoramica**

[Apri una presentazione in Python](/slides/it/python-net/open-presentation/) descrive come utilizzare la classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) per aprire una presentazione. Questo articolo spiega come creare e salvare presentazioni. La classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) contiene il contenuto di una presentazione. Che tu stia creando una presentazione da zero o modificando una esistente, dovrai salvarla al termine. Con Aspose.Slides per Python, puoi salvare su un **file** o su **stream**. Questo articolo illustra i diversi metodi per salvare una presentazione.

## **Salvare le presentazioni su file**

Salva una presentazione su un file chiamando il metodo `save` della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/). Passa il nome del file e il formato di salvataggio al metodo. L’esempio seguente mostra come salvare una presentazione con Aspose.Slides per Python.

```py
import aspose.slides as slides

# Istanzia la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:
    
    # Esegui qualche operazione qui...

    # Salva la presentazione su un file.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Salvare le presentazioni su stream**

Puoi salvare una presentazione su uno stream passando uno stream di output al metodo `save` della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/). Una presentazione può essere scritta su molti tipi di stream. Nell’esempio qui sotto, creiamo una nuova presentazione, aggiungiamo del testo a una forma e la salviamo su uno stream.

```py
import aspose.slides as slides

# Istanzia la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # Salva la presentazione sullo stream.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **Salvare le presentazioni con un tipo di visualizzazione predefinito**

Aspose.Slides per Python ti consente di impostare la visualizzazione iniziale che PowerPoint utilizza quando la presentazione generata viene aperta tramite la classe [ViewProperties](https://reference.aspose.com/slides/it/python-net/aspose.slides/viewproperties/). Imposta la proprietà `last_view` su un valore dell’enumerazione [ViewType](https://reference.aspose.com/slides/it/python-net/aspose.slides/viewtype/).

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Salvare le presentazioni nel formato Strict Office Open XML**

Aspose.Slides consente di salvare una presentazione nel formato Strict Office Open XML. Usa la classe [PptxOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/pptxoptions/) e imposta la sua proprietà `conformance` durante il salvataggio. Se imposti `Conformance.ISO_29500_2008_STRICT`, il file di output viene salvato nel formato Strict Office Open XML.

L’esempio qui sotto crea una presentazione e la salva nel formato Strict Office Open XML.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# Istanzia la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:
    # Salva la presentazione nel formato Strict Office Open XML.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Salvare le presentazioni in Office Open XML in modalità Zip64**

Un file Office Open XML è un archivio ZIP che impone limiti di 4 GB (2^32 byte) per la dimensione non compressa di qualsiasi file, la dimensione compressa di qualsiasi file e la dimensione totale dell’archivio, oltre a limitare l’archivio a 65 535 (2^16‑1) file. Le estensioni del formato ZIP64 sollevano questi limiti a 2^64.

La proprietà [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) consente di scegliere quando utilizzare le estensioni del formato ZIP64 durante il salvataggio di un file Office Open XML.

Questa proprietà offre le seguenti modalità:

- `IF_NECESSARY` utilizza le estensioni ZIP64 solo se la presentazione supera le limitazioni sopra descritte. È la modalità predefinita.
- `NEVER` non utilizza mai le estensioni ZIP64.
- `ALWAYS` utilizza sempre le estensioni ZIP64.

Il codice seguente dimostra come salvare una presentazione come PPTX con le estensioni ZIP64 abilitate:

```py
pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}
Quando salvi con `Zip64Mode.NEVER`, viene sollevata una [PptxException](https://reference.aspose.com/slides/it/python-net/aspose.slides/pptxexception/) se la presentazione non può essere salvata in formato ZIP32.
{{% /alert %}}

## **Salvare le presentazioni senza aggiornare la miniatura**

La proprietà [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) controlla la generazione della miniatura durante il salvataggio di una presentazione in PPTX:

- Se impostata su `True`, la miniatura viene aggiornata durante il salvataggio. È il valore predefinito.
- Se impostata su `False`, la miniatura corrente viene preservata. Se la presentazione non ha una miniatura, non viene generata alcuna miniatura.

Nel codice qui sotto, la presentazione viene salvata in PPTX senza aggiornare la sua miniatura.

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
Aspose ha sviluppato un’app [gratuita PowerPoint Splitter](https://products.aspose.app/slides/it/splitter) utilizzando la propria API. L’app consente di dividere una presentazione in più file salvando le diapositive selezionate come nuovi file PPTX o PPT.
{{% /alert %}}

## **FAQ**

**Il “salvataggio rapido” (salvataggio incrementale) è supportato in modo che vengano scritte solo le modifiche?**

No. Il salvataggio crea l’intero file di destinazione ogni volta; il “salvataggio rapido” incrementale non è supportato.

**È thread‑safe salvare la stessa istanza di Presentation da più thread?**

No. Un’istanza di [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) [non è thread‑safe](/slides/it/python-net/multithreading/); salvala da un singolo thread.

**Cosa accade a hyperlink e file collegati esternamente durante il salvataggio?**

[Hyperlink](/slides/it/python-net/manage-hyperlinks/) vengono conservati. I file collegati esternamente (ad es. video tramite percorsi relativi) non vengono copiati automaticamente—assicurati che i percorsi di riferimento rimangano accessibili.

**Posso impostare/salvare i metadati del documento (Autore, Titolo, Azienda, Data)?**

Sì. Le proprietà standard del [documento](/slides/it/python-net/presentation-properties/) sono supportate e verranno scritte nel file al momento del salvataggio.