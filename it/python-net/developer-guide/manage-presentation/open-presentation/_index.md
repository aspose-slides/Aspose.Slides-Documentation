---
title: Aprire presentazioni in Python
linktitle: Aprire presentazioni
type: docs
weight: 20
url: /it/python-net/open-presentation/
keywords:
- aprire PowerPoint
- aprire presentazione
- aprire PPTX
- aprire PPT
- aprire ODP
- caricare presentazione
- caricare PPTX
- caricare PPT
- caricare ODP
- presentazione protetta
- presentazione di grandi dimensioni
- risorsa esterna
- oggetto binario
- Python
- Aspose.Slides
description: "Apri presentazioni PowerPoint (.pptx, .ppt) e OpenDocument (.odp) con facilità grazie ad Aspose.Slides per Python via .NET—veloce, affidabile, completamente funzionale."
---
## **Introduzione**

Oltre a creare presentazioni PowerPoint da zero, Aspose.Slides ti consente anche di aprire presentazioni esistenti. Dopo aver caricato una presentazione, puoi recuperare informazioni su di essa, modificare il contenuto delle diapositive, aggiungere nuove diapositive, rimuovere quelle esistenti e altro ancora.

## **Aprire le presentazioni**

Per aprire una presentazione esistente, istanzia la classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e passa il percorso del file al suo costruttore.

Il seguente esempio Python mostra come aprire una presentazione e ottenere il conteggio delle diapositive:

```python
import aspose.slides as slides

# Crea un'istanza della classe Presentation e passa un percorso di file al suo costruttore.
with slides.Presentation("sample.pptx") as presentation:
    # Stampa il numero totale di diapositive nella presentazione.
    print(presentation.slides.length)
```

## **Aprire presentazioni protette da password**

Quando è necessario aprire una presentazione protetta da password, passa la password tramite la proprietà [password](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/password/) della classe [LoadOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/) per decrittarla e caricarla. Il seguente codice Python dimostra questa operazione:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # Esegui operazioni sulla presentazione decrittata.
```

## **Aprire presentazioni di grandi dimensioni**

Aspose.Slides offre opzioni—in particolare la proprietà [blob_management_options](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/blob_management_options/) nella classe [LoadOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/)—per aiutarti a caricare presentazioni di grandi dimensioni.

Questo codice Python dimostra come caricare una presentazione di grandi dimensioni (ad esempio, 2 GB):

```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# Scegli il comportamento KeepLocked — il file della presentazione rimarrà bloccato per tutta la durata dell'
# istanza Presentation, ma non è necessario caricarlo in memoria o copiarlo in un file temporaneo.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 MB

with slides.Presentation(file_path, load_options) as presentation:
    # La grande presentazione è stata caricata e può essere usata, mentre il consumo di memoria rimane basso.

    # Apporta modifiche alla presentazione.
    presentation.slides[0].name = "Large presentation"

    # Salva la presentazione in un altro file. Il consumo di memoria rimane basso durante questa operazione.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # Non farlo! Verrà sollevata un'eccezione I/O perché il file è bloccato finché l'oggetto Presentation non viene eliminato.
    os.remove(file_path)

# È ok farlo qui. Il file sorgente non è più bloccato dall'oggetto presentation.
os.remove(file_path)
```

{{% alert color="info" title="Info" %}}
Per aggirare alcune limitazioni quando si lavora con gli stream, Aspose.Slides può copiare il contenuto di uno stream. Caricare una presentazione di grandi dimensioni da uno stream causa la copia della presentazione e può rallentare il caricamento. Pertanto, quando è necessario caricare una presentazione di grandi dimensioni, consigliamo vivamente di utilizzare il percorso del file della presentazione anziché uno stream.

Quando si crea una presentazione che contiene oggetti di grandi dimensioni (video, audio, immagini ad alta risoluzione, ecc.), è possibile utilizzare la [BLOB management](/slides/it/python-net/manage-blob/) per ridurre il consumo di memoria.
{{%/alert %}}

## **Caricare presentazioni senza oggetti binari incorporati**

Una presentazione PowerPoint può contenere i seguenti tipi di oggetti binari incorporati:

- Progetto VBA (accessibile tramite [Presentation.vba_project](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/vba_project/));
- Dati incorporati di oggetti OLE (accessibili tramite [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/it/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/));
- Dati binari di controlli ActiveX (accessibili tramite [Control.active_x_control_binary](https://reference.aspose.com/slides/it/python-net/aspose.slides/control/active_x_control_binary/)).

Utilizzando la proprietà [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/), è possibile caricare una presentazione senza alcun oggetto binario incorporato.

Questa proprietà è utile per rimuovere contenuti binari potenzialmente dannosi. Il seguente codice Python dimostra come caricare una presentazione senza alcun contenuto binario incorporato:

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # Esegui operazioni sulla presentazione.
```

## **FAQ**

**Come posso capire se un file è corrotto e non può essere aperto?**

Otterrai un'eccezione di convalida del parsing/formato durante il caricamento. Tali errori spesso menzionano una struttura ZIP non valida o record PowerPoint danneggiati.

**Cosa succede se i caratteri richiesti mancano durante l'apertura?**

Il file si aprirà, ma successivamente il [rendering/export](/slides/it/python-net/convert-presentation/) potrebbe sostituire i caratteri. [Configure font substitutions](/slides/it/python-net/font-substitution/) o [add the required fonts](/slides/it/python-net/custom-font/) all'ambiente di runtime.

**Che cosa succede ai media incorporati (video/audio) durante l'apertura?**

Diventano disponibili come risorse della presentazione. Se i media sono referenziati tramite percorsi esterni, assicurati che tali percorsi siano accessibili nel tuo ambiente; altrimenti il [rendering/export](/slides/it/python-net/convert-presentation/) potrebbe omettere i media.